using System;
using System.Linq;
using System.Collections.Generic;

namespace Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            for (int i = 1; i <= n; i++)
            {
                string plantsInfo = Console.ReadLine();
                string[] tokens = plantsInfo.Split("<->");
                string plant = tokens[0];
                double rarity = double.Parse(tokens[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double>());
                    plants[plant].Add(rarity);
                }
                else
                {
                    plants[plant][0] = rarity;
                }
            }
            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                char[] separators = new char[] { ' ', '-' };
                string[] tokens = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string plant = tokens[1];

                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    input = Console.ReadLine();
                    continue;
                }
                if (command == "Rate:")
                {
                    double rate = double.Parse(tokens[2]);
                    plants[plant].Add(rate);
                }
                else if (command == "Update:")
                {
                    double newRarity = double.Parse(tokens[2]);
                    plants[plant][0] = newRarity;
                }
                else if (command == "Reset:")
                {
                    plants[plant].RemoveRange(1, plants[plant].Count - 1);
                }
                input = Console.ReadLine();
            }
            foreach (var item in plants)
            {
                double average = 0.00;
                double rarity = item.Value[0];
                item.Value.RemoveAt(0);

                if (item.Value.Count > 0)
                {
                    average = item.Value.Average();
                }
                item.Value.Clear();
                item.Value.Add(rarity);
                item.Value.Add(average);
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {item.Value[1]:F2}");
            }
        }
    }
}