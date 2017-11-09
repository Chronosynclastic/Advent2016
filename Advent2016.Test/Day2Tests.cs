using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
1 2 3
4 5 6
7 8 9
Suppose your instructions are:

ULL
RRDDD
LURDL
UUUUD
You start at "5" and move up (to "2"), left (to "1"), and left (you can't, and stay on "1"), so the first button is 1.
Starting from the previous button ("1"), you move right twice (to "3") and then down three times (stopping at "9" after two moves and ignoring the third), ending up with 9.
Continuing from "9", you move left, up, right, down, and left, ending with 8.
Finally, you move up four times (stopping at "2"), then down once, ending with 5.
So, in this example, the bathroom code is 1985.
*/


namespace Advent2016.Test
{
	[TestClass]
	public class Day2Tests
	{
		string answerString = "RLRDDRLLDLRLUDDULLDRUUULDDLRLUDDDLDRRDUDDDLLURDDDLDDDRDURUDRDRRULUUDUDDRRRLRRRRRLRULRLLRULDRUUDRLRRURDDRLRULDLDULLLRULURRUULLRLLDDDDLLDURRUDLDLURDRDRDLUUUDDRDUUDDULLUURRDRLDDULURRRUDLLULULDLLURURUDRRRRUDRLRDLRRLDDRDDLULDLLLURURDUDRRRRUULURLRDULDRLUDRRUDDUULDURUDLDDURRRDLULLUUDRLLDUUDLDRUDDRLLLLLLDUDUDDLRDLRRDRUDDRRRLLRRDLLRLDDURUURRRDDLDUULLDLDLRURDLLLDDRUUDRUDDDDULRLLDUULRUULLLULURRRLLULDLDUDLDLURUDUDULLDLLUUDRRDRLUURURURURDLURUUDLDRLUDDUUDULDULULLLDLDDULLULLDULRRDRULLURRRULLDDDULULURLRDURLLURUDDULLRUDLRURURRDRDUULDRUUDURDURDDLRDUUULDUUDRDURURDRRRURLLDDLLLURURULULUDLRDLDRDRURLRLULRDLU,UDLDURRULDRDDLDUULUDLDUULUURDDRUDRURRRUDRURLLDDRURLDLRDUUURDLLULURDDUDDDRRRURLLDLDLULRDULRLULDLUUDLLRLDLRUUULDDUURDLDDRRDLURLDUDDRURDRRURDURRRLUULURDDLRDLDRRRLDUDRLRLLRLDDUULDURUUULLLRRRRRRRDRRRDRLUULDLDDLULDRDUDLLUDRRUDRUUDULRLUURDDDDRRUUDLURULLLURDULUURDRDDURULRUDRRDLRDUUUUUDDDRDRDDRUDRDDDRLRUUDRDRDDDLUDRDRLDRDDRULURDRLDRUDUDRUULRLLUDRDRLLLLDUDRRLLURDLLLDRRUDDUDRLRLDUDRLURRUUULURDDRUURRLDRLRRRUUDLULDDDRDLDUUURLLUULDDRRUDLDDRUDUDUURURDDRDULLLLLULRRRDLRRRDDDLURDDDDLUULLLRDDURRRRLURRLDDLRUULULRDRDDDDLDUUUUUUDRRULUUUDD,UURDRRUDLURRDDDLUDLRDURUDURDLLLLRDLRLRDDRDRDUUULRDLLDLULULRDUDDRRUUDURULDLUDLRDRUDLDDULLLDDRDLLDULLLURLLRDDLDRDULRRDDULRDURLLRUDRLRRLUDURLDRDLDLRLLLURLRRURDLDURDLUDULRDULLLDRDDRDLDRDULUULURDRRRLDRRUULULLDDRRLDLRUURLRUURLURRLLULUUULRLLDDUDDLRLDUURURUDLRDLURRLLURUDLDLLUDDUULUUUDDDURDLRRDDDLDRUDRLRURUUDULDDLUUDDULLDDRRDDRRRUDUDUDLDLURLDRDLLLLDURDURLRLLLUUDLRRRRUDUDDLDLRUURRLRRLUURRLUDUDRRRRRRRLDUDDRUDDLUDLRDDDRLDUULDRDRRDLDRURDLDRULRLRLUDRDLRRUURUUUUDLDUUULLLRRRRRDLRRURDDLLLLUULDLLRULLUDLLDLLUDLRLRRLRURDDRRL,URDRDLLRDDDLLLDDLURLRURUURRRLUURURDURRLLUDURRLRLDLUURDLULRRDRUDDLULDLDRLDLRLRRLLLDDDUDDDLRURURRLLDRRRURUDLRDDLLDULDDLDRLUUUDRRRULDUULRDDDLRRLLURDDURLULRDUDURRLLDLLRLDUDDRRDDLRLLLDUDRLUURRLLDULRLDLUUUUUDULUDLULUDDUURRURLDLDRRLDLRRUDUDRRDLDUDDLULLDLLRDRURDRDRRLDDDDRDDRLLDDDLLUDRURLURDRRRRRUDDDUDUDDRDUUDRRUDUDRLULDDURULUURUUUURDRULRLRULLDDRRRUULRRRRURUDLDLRDLLDRLURLRUULLURDUDULRRURLRLLRRLLLURULRRRLDDUULLUUULRRDRULUUUUDRDRRDLRURLRLLRLRRRDRDRLDLUURUURULLDLULRRLRRDRULRRLLLDDURULLDLDLDLUUURDLDLUUDULRLLUDDRRDLLDLDLDURLUURRDDRRURDRLUDRLUUUDLDULDLUDRLDUDDLLRUDULLLLLDRRLLUULLUUURRDDUURDLLRDDLRLLU,LDUDRRDLUUDDRLLUUULURLDUDLUDLRLDRURLULRLLDDLRRUUUDDDDRDULDDUUDLRUULDRULLRDRUDDURLDUUURRUDUDRDRDURRDLURRRDRLDLRRRLLLRLURUURRDLLRDLDDLLRDUDDRDUULRULRRURLUDDUDDDUULLUURDULDULLLLRUUUDDRRRLDDDLDLRRDRDRDLUULRLULDRULDLRDRRUDULUDLLUDUULRDLRRUUDDLLDUDDRULURRLULDLDRRULDDRUUDDLURDLRDRLULRRLURRULDUURDLUDLLDRLDULLULDLLRDRDLLLUDLRULLRLDRDDDLDDDLRULDLULLRUUURRLLDUURRLRLDUUULDUURDURRULULRUUURULLLRULLURDDLDRLLRDULLUDLDRRRLLLLDUULRRLDURDURDULULDUURLDUDRLRURRDLUUULURRUDRUUUDRUR";

		[TestMethod]
		public void DetermineNextKeyFromKnownStart1()
		{
			//Start on 5, "ULL"
			string codeKey = "";
			string instructions = "ULL";

			var keypad = new KeypadController();
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("1", codeKey);
		}

		[TestMethod]
		public void DetermineNextKeyFromKnownStart2()
		{
			//Start on 1, RRDDD
			string codeKey = "";
			string instructions = "RRDDD";

			var keypad = new KeypadController(0,0);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("9", codeKey);
		}

		[TestMethod]
		public void DetermineNextKeyFromKnownStart3()
		{
			//Start on 9, LURDL
			string codeKey = "";
			string instructions = "LURDL";

			var keypad = new KeypadController(2,2);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("8", codeKey);
		}

		[TestMethod]
		public void DetermineNextKeyFromKnownStart4()
		{
			//Start on 8, UUUUD
			string codeKey = "";
			string instructions = "UUUUD";

			var keypad = new KeypadController(2,1);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("5", codeKey);

		}

		[TestMethod]
		public void DetermineFullCodeInAC()
		{
			//Start on 5, ULL, RRDDD, LURDL, UUUUD
			string codeResponse = "";
			string instructions = "ULL,RRDDD,LURDL,UUUUD";

			var keypad = new KeypadController();

			codeResponse = keypad.DetermineCodeFromInstructionSet(instructions, ',');

			Assert.AreEqual("1985", codeResponse);
		}

		[TestMethod]
		public void FindAnswerStep1()
		{
			//Start on 5, ULL, RRDDD, LURDL, UUUUD
			string codeResponse = "";
			string instructions = answerString;

			var keypad = new KeypadController();

			codeResponse = keypad.DetermineCodeFromInstructionSet(instructions, ',');

			Assert.AreEqual("18843", codeResponse);
		}

		[TestMethod]
		public void HexagonalNextKey1()
		{
			//Start on 5, "ULL"
			string codeKey = "";
			string instructions = "ULL";

			var keypad = new KeypadController(2,0,KeypadType.Hexagonal);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("5", codeKey);
		}

		[TestMethod]
		public void HexagonalNextKey2()
		{
			//Start on 5, RRDDD
			string codeKey = "";
			string instructions = "RRDDD";

			var keypad = new KeypadController(2,0, KeypadType.Hexagonal);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("D", codeKey);
		}

		[TestMethod]
		public void HexagonalNextKey3()
		{
			//Start on D, LURDL
			string codeKey = "";
			string instructions = "LURDL";

			var keypad = new KeypadController(4,2, KeypadType.Hexagonal);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("B", codeKey);
		}

		[TestMethod]
		public void HexagonalNextKey4()
		{
			//Start on B, UUUUD
			string codeKey = "";
			string instructions = "UUUUD";

			var keypad = new KeypadController(3,2, KeypadType.Hexagonal);
			codeKey = keypad.DetermineNextKeyFromInstruction(instructions);

			Assert.AreEqual("3", codeKey);
		}

		[TestMethod]
		public void GetHexagonalAnswer()
		{
			string codeResponse = "";
			string instructions = answerString;

			var keypad = new KeypadController(2,0,KeypadType.Hexagonal);

			codeResponse = keypad.DetermineCodeFromInstructionSet(instructions, ',');

			Assert.AreEqual("67BB9", codeResponse);
		}
	}
}
