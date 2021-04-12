using System;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regexDigit = new Regex(@"\d");
            Regex emojiRegex = new Regex(@"(::|\*\*)([A-Z][a-z]{2,})+\1");

            string text = Console.ReadLine();

            MatchCollection allDigits = regexDigit.Matches(text);

            long threshhold = CalculateThreshold(allDigits);
            Console.WriteLine($"Cool threshold: {threshhold}");


            MatchCollection emojiMatches = emojiRegex.Matches(text);

            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");


            foreach (Match emojiMatch in emojiMatches)
            {
                string emojiText = emojiMatch.Groups[2].Value;

                long coolnest = GetAsciiSum(emojiText);
                if(coolnest >threshhold)
                {
                    Console.WriteLine(emojiMatch.Value);
                }

            }
        }

        private static long GetAsciiSum(string text)
        {
            long result = 0;
            foreach (char letter in text)
            {
                result += letter;
            }
            return result;
        }

        private static long CalculateThreshold(MatchCollection digits)
        {

            long result = 1;
            foreach (Match digit in digits)
            {
                result *= int.Parse(digit.Value);
            }
            return result;
        }
    }
}
