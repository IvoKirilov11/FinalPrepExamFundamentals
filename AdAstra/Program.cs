﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|\|)([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,4}|10000)\1";
            Regex regex = new Regex(pattern);

            string data = Console.ReadLine();

            var maches = regex.Matches(data);
            int calories = maches
                .Select(x => int.Parse(x.Groups[4].ToString()))
                .Sum();

            Console.WriteLine($"You have food to last you for: {calories/2000} days!");

            foreach (Match match in maches)
            {
                Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: {match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}");
            }
        }
    }
}
