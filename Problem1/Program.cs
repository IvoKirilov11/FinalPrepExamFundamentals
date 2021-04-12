using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            while (true)
            {
                string line = Console.ReadLine();

                if(line == "Finish")
                {
                    break;
                }

                string[] tolkens = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string command = tolkens[0];

                if(command == "Replace")
                {
                    char currentChar =char.Parse (tolkens[1]);
                    char newChar = char.Parse(tolkens[2]);

                    text = text.Replace(currentChar, newChar);
                    Console.WriteLine(text);

                }
                else if(command == "Cut")
                {
                    int startIndex = int.Parse(tolkens[1]);
                    int endIndex = int.Parse(tolkens[2]);

                    if(startIndex < 0 || startIndex > text.Length || endIndex < 0 || endIndex > text.Length)
                    {
                        Console.WriteLine("Invalid indices!");
                        continue;
                    }
                    int count = endIndex - startIndex + 1;
                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }
                else if(command == "Make")
                {
                    string cases = tolkens[1];
                    text = cases == "Upper"
                        ? text.ToUpper()
                        : text.ToLower();
                    Console.WriteLine(text);
                    
                }
                else if(command == "Check")
                {
                    string massage = tolkens[1];
                    if(text.Contains(massage))
                    {
                        Console.WriteLine($"Message contains {massage}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {massage}");
                    }
                }
                else if (command == "Sum")
                {
                    int startIndex = int.Parse(tolkens[1]);
                    int endIndex = int.Parse(tolkens[2]);

                    if (startIndex < 0 || startIndex > text.Length || endIndex < 0 || endIndex > text.Length)
                    {
                        Console.WriteLine("Invalid indices!");
                        continue;
                    }

                    int sum = 0;
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        sum += (int)text[i];
                    }
                    Console.WriteLine(sum);

                }

                line = Console.ReadLine();

            }
            Console.WriteLine(text);

        }
    }
}
