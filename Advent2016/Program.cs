using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter step string");
			//var input = Console.ReadLine();

			//IGNORE INPUT!!!

			var input = "R2, L1, R2, R1, R1, L3, R3, L5, L5, L2, L1, R4, R1, R3, L5, L5, R3, L4, L4, R5, R4, R3, L1, L2, R5, R4, L2, R1, R4, R4, L2, L1, L1, R190, R3, L4, R52, R5, R3, L5, R3, R2, R1, L5, L5, L4, R2, L3, R3, L1, L3, R5, L3, L4, R3, R77, R3, L2, R189, R4, R2, L2, R2, L1, R5, R4, R4, R2, L2, L2, L5, L1, R1, R2, L3, L4, L5, R1, L1, L2, L2, R2, L3, R3, L4, L1, L5, L4, L4, R3, R5, L2, R4, R5, R3, L2, L2, L4, L2, R2, L5, L4, R3, R1, L2, R2, R4, L1, L4, L4, L2, R2, L4, L1, L1, R4, L1, L3, L2, L2, L5, R5, R2, R5, L1, L5, R2, R4, R4, L2, R5, L5, R5, R5, L4, R2, R1, R1, R3, L3, L3, L4, L3, L2, L2, L2, R2, L1, L3, R2, R5, R5, L4, R3, L3, L4, R2, L5, R5";
			var movementTracker = new MovementTracker();

			var displacement = movementTracker.CalculateDisplacement(input);
			var point = movementTracker.FindFirstRecurranceInPath(input);

			var finalDisplacement = movementTracker.DetermineDisplacementBetweenTwoPoints(new System.Drawing.Point(0,0), point.Value);

			Console.WriteLine("Displacement is: {0}", displacement);
			Console.WriteLine("First Recurring Point is: {0}", point);
			Console.WriteLine("final disp: {0}", finalDisplacement);

			Console.ReadKey();
		}
	}
}
