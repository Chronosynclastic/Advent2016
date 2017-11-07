using System;
using System.Drawing;
using Advent2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Test
{
	[TestClass]
	public class Day1Tests
	{
		const string knownPath = "R2, L1, R2, R1, R1, L3, R3, L5, L5, L2, L1, R4, R1, R3, L5, L5, R3, L4, L4, R5, R4, R3, L1, L2, R5, R4, L2, R1, R4, R4, L2, L1, L1, R190, R3, L4, R52, R5, R3, L5, R3, R2, R1, L5, L5, L4, R2, L3, R3, L1, L3, R5, L3, L4, R3, R77, R3, L2, R189, R4, R2, L2, R2, L1, R5, R4, R4, R2, L2, L2, L5, L1, R1, R2, L3, L4, L5, R1, L1, L2, L2, R2, L3, R3, L4, L1, L5, L4, L4, R3, R5, L2, R4, R5, R3, L2, L2, L4, L2, R2, L5, L4, R3, R1, L2, R2, R4, L1, L4, L4, L2, R2, L4, L1, L1, R4, L1, L3, L2, L2, L5, R5, R2, R5, L1, L5, R2, R4, R4, L2, R5, L5, R5, R5, L4, R2, R1, R1, R3, L3, L3, L4, L3, L2, L2, L2, R2, L1, L3, R2, R5, R5, L4, R3, L3, L4, R2, L5, R5";
		[TestMethod]
		public void TestCircleDisplacement()
		{
			var steps = "L1, L1, L1, L1";

			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(steps);

			Assert.AreEqual(0, displacement);
		}

		[TestMethod]
		public void TestLinearDisplacement()
		{
			var steps = "L1, R1, L1, R1";

			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(steps);

			Assert.AreEqual(4, displacement);
		}

		[TestMethod]
		public void TestTriangleDisplacement()
		{
			/*
			O X X X X X
			Z Z       Y  
			  Z Z     Y
			    Z Z   Y
				  Z Z Y
				    Z Y
			*/


			var steps = "L5, R5";

			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(steps);

			Assert.AreEqual(10, displacement);
		}

		/*Following R2, L3 leaves you 2 blocks East and 3 blocks North, or 5 blocks away.
R2, R2, R2 leaves you 2 blocks due South of your starting position, which is 2 blocks away.
R5, L5, R5, R3 leaves you 12 blocks away.*/

		[TestMethod]
		public void TestDisplacementAC1()
		{
			var knownPath = "R2, L3";

			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(knownPath);

			Assert.AreEqual(5, displacement);
		}

		[TestMethod]
		public void TestDisplacementAC2()
		{
			var knownPath = "R2, R2, R2";

			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(knownPath);

			Assert.AreEqual(2, displacement);
		}

		[TestMethod]
		public void TestDisplacementAC3()
		{
			var knownPath = "R5, L5, R5, R3";

			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(knownPath);

			Assert.AreEqual(12, displacement);
		}

		[TestMethod]
		public void TestDisplacementOfKnownPath()
		{
			var movementCalculator = new MovementTracker();

			var displacement = movementCalculator.CalculateDisplacement(knownPath);

			Assert.AreEqual(234, displacement);
		}
		
		[TestMethod]
		public void TestFirstRecurrance()
		{
			var steps = "R2, L1, L1, L1, L1, R5, L1, L1, L1, L1";
			var location = new Point(1,0);

			var movementCalculator = new MovementTracker();

			var firstRecurringPoint = movementCalculator.FindFirstRecurranceInPath(steps);

			Assert.AreEqual(location, firstRecurringPoint);
		}

		[TestMethod]
		public void TestFirstRecurranceAC()
		{
			var knownPath = "R8, R4, R4, R8";
			var knownDisplacement = 4;

			var movementCalculator = new MovementTracker();
			var firstRecurringPoint = movementCalculator.FindFirstRecurranceInPath(knownPath);

			if(!firstRecurringPoint.HasValue)
			{
				Assert.Fail("No Recurrance Found");
			}

			var displacement = movementCalculator.DetermineDisplacementBetweenTwoPoints(firstRecurringPoint.Value, new Point(0,0));

			Assert.AreEqual(knownDisplacement, displacement);
		}

		[TestMethod]
		public void TestFirstRecurranceInKnownPath()
		{
			var knownPoint = new Point(16, -97);
			var knownDisplacement = 113;

			var movementCalculator = new MovementTracker();

			var firstRecurringPoint = movementCalculator.FindFirstRecurranceInPath(knownPath);
			var displacement = movementCalculator.DetermineDisplacementBetweenTwoPoints(firstRecurringPoint.Value, new Point(0,0));


			Assert.AreEqual(knownPoint, firstRecurringPoint);
			Assert.AreEqual(knownDisplacement, displacement);
		}
	}
}
