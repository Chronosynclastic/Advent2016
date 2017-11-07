using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Advent2016
{
	public class MovementTracker
	{
		private Point Origin = new Point(0 ,0);
		private Point Location = new Point(0 ,0);
		private Aspect CurrentAspect = Aspect.North;

		private HashSet<Point> VisitedPoints { get; set; } = new HashSet<Point>();

		public int CalculateDisplacement(string stepsInput)
		{
			int displacement = -1; //Invalid displacement, indicates error if not modified

			var steps = stepsInput.Replace(" ", "").Split(',');

			foreach (var step in steps)
			{
				//Add validation
				WalkStep(step);
			}

			displacement = DetermineDisplacementBetweenTwoPoints(Origin, Location);

			return displacement;
		}

		public int DetermineDisplacementBetweenTwoPoints(Point origin, Point location)
		{
			int totalDisplacement = -1;

			int xDisplacement = Math.Abs(origin.X - location.X);
			int yDisplacement = Math.Abs(origin.Y - location.Y);

			totalDisplacement = xDisplacement + yDisplacement;

			return totalDisplacement;
		}

		public Point? FindFirstRecurranceInPath(string path)
		{
			Point? recurringPoint = null;
			bool pointFound = false;

			var steps = path.Replace(" ", "").Split(',');

			VisitedPoints.Add(Origin);

			foreach (var step in steps)
			{
				//Add validation
				var newPoints = WalkStep(step);
				
				foreach (var newPoint in newPoints)
				{
					if (VisitedPoints.Contains(newPoint))
					{
						recurringPoint = newPoint;
						pointFound = true;
						break;
					}
					VisitedPoints.Add(newPoint);
				}

				if (pointFound)
				{
					break;
				}

			}

			return recurringPoint;
		}

		private List<Point> WalkStep(string step)
		{
			var direction = (Direction)step[0];
			var distance = int.Parse(step.Substring(1));
			//First char is direction, followed by the number
			UpdateAspect(direction);
			var newPoints = Walk(distance);

			return newPoints;
		}

		private List<Point> Walk(int distance)
		{
			int step = 0;
			var newPoints = new List<Point>();
			var currentPoint = new Point();

			switch(CurrentAspect)
			{
				case Aspect.North:
					while (step < distance)
					{
						step++;
						currentPoint = new Point(Location.X, (Location.Y + step));
						newPoints.Add(currentPoint);
					}
					Location = currentPoint;
					break;
				case Aspect.South:
					while (step < distance)
					{
						step++;
						currentPoint = new Point(Location.X, (Location.Y - step));
						newPoints.Add(currentPoint);
					}
					Location = currentPoint;
					break;
				case Aspect.East:
					while (step < distance)
					{
						step++;
						currentPoint = new Point((Location.X + step), Location.Y);
						newPoints.Add(currentPoint);
					}
					Location = currentPoint;
					break;
				case Aspect.West:
					while (step < distance)
					{
						step++;
						currentPoint = new Point((Location.X - step), Location.Y);
						newPoints.Add(currentPoint);
					}
					Location = currentPoint;
					break;
				default:
					//Error
					break;
			}

			return newPoints;
		}

		private void UpdateAspect(Direction direction)
		{
			//Depending on your Aspect, "Left" and "Right" are different directions
			switch(CurrentAspect)
			{
				case Aspect.North:
					if (direction == Direction.Left)
					{
						CurrentAspect = Aspect.West;
					}
					else if (direction == Direction.Right)
					{
						CurrentAspect = Aspect.East;
					}
					break;
				case Aspect.South:
					if (direction == Direction.Left)
					{
						CurrentAspect = Aspect.East;
					}
					else if (direction == Direction.Right)
					{
						CurrentAspect = Aspect.West;
					}
					break;
				case Aspect.East:
					if (direction == Direction.Left)
					{
						CurrentAspect = Aspect.North;
					}
					else if (direction == Direction.Right)
					{
						CurrentAspect = Aspect.South;
					}
					break;
				case Aspect.West:
					if (direction == Direction.Left)
					{
						CurrentAspect = Aspect.South;
					}
					else if (direction == Direction.Right)
					{
						CurrentAspect = Aspect.North;
					}
					break;
				default:
					//Error!
					break;
			}	
		}
	}

	enum Direction
	{
		Left = 'L',
		Right = 'R'
	}

	enum Aspect
	{
		North = 0,
		South,
		East,
		West,
	}

	//public class Point : IEqualityComparer<Point>
	//{
	//	public int X { get; private set; }
	//	public int Y { get; private set; }

	//	private bool isImmutable { get; set; }

	//	public Point(int xInput, int yInput)
	//	{
	//		this.X = xInput;
	//		this.Y = yInput;
	//	}

	//	public bool Equals(Point x, Point y)
	//	{
	//		return (x.X == y.X && x.Y == y.Y);
	//	}

	//	public int GetHashCode(Point obj)
	//	{
	//		return this.X.GetHashCode() + this.Y.GetHashCode();
	//	}
	//}
}
