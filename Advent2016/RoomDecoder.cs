using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2016
{
    public class RoomDecoder
    {
        private Regex checksumExtractRegex = new Regex(@"(?<=\[)[^\[]+?(?=\])");
        private Regex checksumCalculateRegex = new Regex(@"^.*?(?=\d)");
        private Regex checksumSortCode = new Regex(@"\d(\d+?)\d");
        private List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();

        public string ExtractChecksum(string input)
        {
            //String format: 
            string checksum = "";

            checksum = checksumExtractRegex.Match(input).Value;

            return checksum;
        }

        public string CalculateChecksum(string input)
        {
            string checksum = "";

            var rawString = checksumCalculateRegex.Match(input).Value;

            rawString = rawString.Replace("-", "");

            //Count each char

            checksum = GetTopFiveFromString(rawString);

            return checksum;
        }

        private static string GetTopFiveFromString(string rawString)
        {
            var charFrequencies = new Dictionary<char, int>();

            foreach (var character in rawString)
            {
                if (charFrequencies.ContainsKey(character))
                {
                    charFrequencies[character]++;
                }
                else
                {
                    charFrequencies[character] = 1;
                }
            }

            var top5 = charFrequencies.ToList()
                                      .OrderByDescending(entry => entry.Value)
                                      .ThenBy(entry => entry.Key)
                                      .Take(5)
                                      .Select(entry => entry.Key);

            return String.Join("", top5);
        }

        public bool ValidateChecksum(string input)
        {
            var extractedChecksum = this.ExtractChecksum(input);

            var calculatedChecksum = this.CalculateChecksum(input);

            return (extractedChecksum == calculatedChecksum);
        }

        public int GetSortCode(string input)
        {
            int sortCode = -1;

            var sortCodeString = checksumSortCode.Match(input).Value;

            int.TryParse(sortCodeString, out sortCode);

            return sortCode;
        }

        public string DecryptString(string input)
        {
            var decryptedString = "";

            //Get the string to decrypt
            var rawString = checksumCalculateRegex.Match(input).Value;

            var sortCode = this.GetSortCode(input);

            foreach (var character in rawString)
            {
                if (character == '-')
                {
                    decryptedString += " ";
                }
                else
                {
                    int currentLetter = alphabet.IndexOf(character);

                    int decryptedIndex = (currentLetter + sortCode) % 26;

                    decryptedString += alphabet[decryptedIndex];
                }
            }

            return decryptedString.Trim();
        }
    }
}
