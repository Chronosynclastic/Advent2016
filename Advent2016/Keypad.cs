using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
	public class KeypadController
	{
		private IKeypad keypad;

		public KeypadController(int xStart, int yStart, KeypadType type = KeypadType.Decimal)
		{
			switch(type)
			{
				case KeypadType.Decimal:
					xStart = (xStart == -1) ? 1 : xStart;
					yStart = (yStart == -1) ? 1 : yStart;
					keypad = new DecimalKeypad(xStart, yStart);
					break;
				case KeypadType.Hexagonal:
					xStart = (xStart == -1) ? 2 : xStart;
					yStart = (yStart == -1) ? 0 : yStart;
					keypad = new HexagonalKeypad(xStart, yStart);
					break;
				default:
					break;
			}
		}

		public KeypadController() : this(-1, -1, KeypadType.Decimal)
		{ }

		/// <summary>
		/// Applies the passed set of instructions and determines the key that it finishes on
		/// </summary>
		/// <param name="instructions"></param>
		/// <returns></returns>
		public string DetermineNextKeyFromInstruction(string instructions)
		{
			foreach (var step in instructions)
			{
				keypad.MakeStep(step);
			}

			return keypad.GetCurrentKey();
		}

		public string DetermineCodeFromInstructionSet(string instructionSet, char separator)
		{
			string code = "";

			List<string> instructions = new List<string>(instructionSet.Split(separator));

			foreach (var instruction in instructions)
			{
				var newKey = DetermineNextKeyFromInstruction(instruction);

				code += newKey;
			}

			return code;
		}
	}


	interface IKeypad
	{
		string GetCurrentKey();
		void MakeStep(char step);
	}

	public enum KeypadType
	{
		Decimal = 0,
		Hexagonal
	}

	public class DecimalKeypad : IKeypad
	{
		private string[,] keypad = new string[3,3];
		private int xPad;
		private int yPad;

		public DecimalKeypad(int xStart, int yStart)
		{
			CreateKeypad();
			xPad = xStart;
			yPad = yStart;
		}

		private void CreateKeypad()
		{
			keypad[0, 0] = "1";
			keypad[0, 1] = "2";
			keypad[0, 2] = "3";
			keypad[1, 0] = "4";
			keypad[1, 1] = "5";
			keypad[1, 2] = "6";
			keypad[2, 0] = "7";
			keypad[2, 1] = "8";
			keypad[2, 2] = "9";
		}

		public string GetCurrentKey()
		{
			return keypad[xPad, yPad];
		}

		public void MakeStep(char step)
		{
			switch (step)
			{
				case 'U':
					if (xPad > 0)
					{
						xPad--;
					}
					break;
				case 'D':
					if (xPad < (keypad.GetLength(0) - 1))
					{
						xPad++;
					}
					break;
				case 'L':
					if (yPad > 0)
					{
						yPad--;
					}
					break;
				case 'R':
					if (yPad < (keypad.GetLength(1) - 1))
					{
						yPad++;
					}
					break;
				default:
					//Unknown Key!!
					break;
			}
		}
	}

	public class HexagonalKeypad : IKeypad
	{
		private string[,] keypad = new string[5,5];
		private int xPad;
		private int yPad;

		public HexagonalKeypad(int xStart, int yStart)
		{
			CreateKeypad();
			xPad = xStart;
			yPad = yStart;
		}

		private void CreateKeypad()
		{
			/*
			X X 1 X X
			X 2 3 4 X
			5 6 7 8 9
			X A B C X
			X X	D X X
			*/

			keypad[0, 2] = "1";
			keypad[1, 1] = "2";
			keypad[1, 2] = "3";
			keypad[1, 3] = "4";
			keypad[2, 0] = "5";
			keypad[2, 1] = "6";
			keypad[2, 2] = "7";
			keypad[2, 3] = "8";
			keypad[2, 4] = "9";
			keypad[3, 1] = "A";
			keypad[3, 2] = "B";
			keypad[3, 3] = "C";
			keypad[4, 2] = "D";
		}

		public string GetCurrentKey()
		{
			return keypad[xPad, yPad];
		}

		public void MakeStep(char step)
		{
			switch (step)
			{
				case 'U':
					if (xPad > 0 && keypad[xPad - 1, yPad] != null)
					{
						xPad--;
					}
					break;
				case 'D':
					if (xPad < (keypad.GetLength(0) - 1) && keypad[xPad + 1, yPad] != null)
					{
						xPad++;
					}
					break;
				case 'L':
					if (yPad > 0 && keypad[xPad, yPad -1] != null)
					{
						yPad--;
					}
					break;
				case 'R':
					if (yPad < (keypad.GetLength(1) - 1) && keypad[xPad, yPad + 1] != null)
					{
						yPad++;
					}
					break;
				default:
					//Unknown Key!!
					break;
			}
		}
	}
}
