using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Advent2016.Test
{
    /*  aaaaa-bbb-z-y-x-123[abxyz] is a real room because the most common letters are a (5), b (3), and then a tie between x, y, and z, which are listed alphabetically.
        a-b-c-d-e-f-g-h-987[abcde] is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
        not-a-real-room-404[oarel] is a real room.
        totally-real-room-200[decoy] is not.


        Of the real rooms from the list above, the sum of their sector IDs is 1514.
*/


    [TestClass]
    public class Day4Tests
    {
        #region extract
        [TestMethod]
        public void Checksum1ExtractedCorrectly()
        {
            string checksum = "";
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";

            var decoder = new RoomDecoder();

            checksum = decoder.ExtractChecksum(input);

            Assert.AreEqual("abxyz", checksum);

        }

        [TestMethod]
        public void Checksum2ExtractedCorrectly()
        {
            string checksum = "";
            string input = "a-b-c-d-e-f-g-h-987[abcde]";

            var decoder = new RoomDecoder();

            checksum = decoder.ExtractChecksum(input);

            Assert.AreEqual("abcde", checksum);

        }

        [TestMethod]
        public void Checksum3ExtractedCorrectly()
        {
            string checksum = "";
            string input = "not-a-real-room-404[oarel]";

            var decoder = new RoomDecoder();

            checksum = decoder.ExtractChecksum(input);

            Assert.AreEqual("oarel", checksum);

        }

        [TestMethod]
        public void Checksum4ExtractedCorrectly()
        {
            string checksum = "";
            string input = "totally-real-room-200[decoy]";

            var decoder = new RoomDecoder();

            checksum = decoder.ExtractChecksum(input);

            Assert.AreEqual("decoy", checksum);

        }
        #endregion

        #region Calculate
        [TestMethod]
        public void Checksum1CalculatedCorrectly()
        {
            string checksum = "";
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";

            var decoder = new RoomDecoder();

            checksum = decoder.CalculateChecksum(input);

            Assert.AreEqual("abxyz", checksum);

        }

        [TestMethod]
        public void Checksum2CalculatedCorrectly()
        {
            string checksum = "";
            string input = "a-b-c-d-e-f-g-h-987[abcde]";

            var decoder = new RoomDecoder();

            checksum = decoder.CalculateChecksum(input);

            Assert.AreEqual("abcde", checksum);

        }

        [TestMethod]
        public void Checksum3CalculatedCorrectly()
        {
            string checksum = "";
            string input = "not-a-real-room-404[oarel]";

            var decoder = new RoomDecoder();

            checksum = decoder.CalculateChecksum(input);

            Assert.AreEqual("oarel", checksum);

        }

        [TestMethod]
        public void Checksum4CalculatedCorrectly()
        {
            string checksum = "";
            string input = "totally-real-room-200[decoy]";

            var decoder = new RoomDecoder();

            checksum = decoder.CalculateChecksum(input);

            Assert.AreEqual("loart", checksum);

        }

#endregion

        [TestMethod]
        public void Checksum1Validate()
        {
            bool checksumIsValid = false;
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";

            var decoder = new RoomDecoder();

            checksumIsValid = decoder.ValidateChecksum(input);

            Assert.IsTrue(checksumIsValid);
        }

        [TestMethod]
        public void Checksum4Validate()
        {
            bool checksumIsValid = false;
            string input = "totally-real-room-200[decoy]";

            var decoder = new RoomDecoder();

            checksumIsValid = decoder.ValidateChecksum(input);

            Assert.IsFalse(checksumIsValid);
        }

        [TestMethod]
        public void GetSortCode1()
        {
            int sortCode = -1;
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";

            var decoder = new RoomDecoder();

            sortCode = decoder.GetSortCode(input);

            Assert.AreEqual(123, sortCode);
        }

        [TestMethod]
        public void GetAnswerPart1()
        {
            IEnumerable<string> list = System.IO.File.ReadAllLines("../../../ChecksumList.txt");
            var decoder = new RoomDecoder();
            var sortCodeSum = 0;

            foreach (var input in list)
            {
                if(decoder.ValidateChecksum(input))
                {
                    sortCodeSum += decoder.GetSortCode(input);
                }
            }

            Assert.AreEqual(158835, sortCodeSum);
        }

        [TestMethod]
        public void DecryptString()
        {
            /*To decrypt a room name, rotate each letter forward through the alphabet a number of times equal to the room's sector ID. 
             * A becomes B, B becomes C, Z becomes A, and so on. Dashes become spaces.

            For example, the real name for qzmt - zixmtkozy - ivhz - 343 is very encrypted name.*/

            var input = "qzmt-zixmtkozy-ivhz-343";
            var decryptResult = "";
            var decoder = new RoomDecoder();

            decryptResult = decoder.DecryptString(input);

            Assert.AreEqual("very encrypted name", decryptResult);
        }

        [TestMethod]
        public void GetAnswer2()
        {
            IEnumerable<string> list = System.IO.File.ReadAllLines("../../../ChecksumList.txt");
            var decoder = new RoomDecoder();
            var rightString = "north pole objects";
            var rightSortCode = -2;

            foreach(var input in list)
            {
                var decryptResult = decoder.DecryptString(input);

                if(decryptResult.Contains("north"))
                {
                    rightSortCode = decoder.GetSortCode(input);
                }

                if (String.Equals(rightString, decryptResult, StringComparison.CurrentCultureIgnoreCase))
                {
                    
                    break;
                }
            }

            Assert.AreEqual(993, rightSortCode);
        }
    }
}
