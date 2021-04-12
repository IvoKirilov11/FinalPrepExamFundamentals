using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = (@"(=|\/)([A-Z][a-zA-Z]{2,})\1");
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);

            MatchCollection cities = regex.Matches(input);

            if (cities.Count == 0)
            {
                Console.WriteLine("Destinations: ");
                Console.WriteLine("Travel Points: 0");
                return;

            }

            int travelPoints = 0;
            foreach (Match item in cities)
            {
                travelPoints += item.Groups[2].Value.Length;
            }

            List<string> output = new List<string>();

            foreach (Match item in cities)
            {
                output.Add(item.Groups[2].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", output)}");
            Console.WriteLine($"Travel Points: {travelPoints}");

        }
    }
}
