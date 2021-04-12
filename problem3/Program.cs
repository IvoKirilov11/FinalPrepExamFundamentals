using System;
using System.Collections.Generic;

namespace problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<string>> statistic = new Dictionary<string, List<string>>();
            int unlike = 0;
            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string guest = line.Split("-")[1];
                string meal = line.Split("-")[2];

                if(line.Contains("Like") == true)
                {
                    if(statistic.ContainsKey(guest) == false)
                    {
                        statistic.Add(guest, new List<string>());
                    }
                    if (statistic[guest].Contains(meal) == false)
                    {
                        statistic[guest].Add(meal);
                    }
                }
                if(line.Contains("Unlike") == true)
                {
                    if (statistic.ContainsKey(guest) == false)
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if(statistic[guest].Contains(meal) == false)
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        statistic[guest].Remove(meal);
                        unlike++;
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }
                }
            }

            string[] names = new string[statistic.Keys.Count];
            List<string>[] dishes = new List<string>[names.Length];
            int k = 0;
            foreach (string kay in statistic.Keys)
            {
                
            }
            
                

            
        }
    }
}
