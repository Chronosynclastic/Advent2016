using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2016
{
    public class TriangleChecker
    {
        public bool isValidTriangle(int[] sideSizes)
        {
            bool isValidTriangle = true;

            if (sideSizes.Length > 3)
            {
                Console.WriteLine("That's not a Triangle: Too many sides!");
                isValidTriangle = false;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (sideSizes[i] >= sideSizes[(i + 1) % 3] + sideSizes[(i + 2) % 3])
                    {
                        isValidTriangle = false;
                    }
                }
            }

            return isValidTriangle;
        }

        public int GetValidTriangleCountFromList(IEnumerable<string> triangleList)
        {
            int validTriangleCount = 0;
            int rowCount = 0;
            List<List<int>> sideRows = new List<List<int>>();

            foreach ( var triangleString in triangleList)
            {
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);

                //Split up the input into strings to parse
                var splitStrings = regex.Replace(triangleString.TrimStart(), " ").Split(' ');
                List<int> sides = new List<int>();

                //Split up the strings and parts into an int Array
                foreach(var sidestring in splitStrings)
                {
                    sides.Add(int.Parse(sidestring));
                }

                sideRows.Add(sides);
                rowCount++;

                if (rowCount == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int[] triangleArray = { sideRows[0][i], sideRows[1][i], sideRows[2][i] };

                        var thisTriangleIsValid = isValidTriangle(triangleArray);

                        if (thisTriangleIsValid)
                        {
                            validTriangleCount++;
                        }
                    }

                    rowCount = 0;
                    sideRows.Clear();
                }
            }

            return validTriangleCount;
        }
    }
}
