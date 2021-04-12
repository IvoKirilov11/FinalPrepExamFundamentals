using System;
using System.Linq;
using System.Text;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] tolkens = input.Split(":|:");
                string command = tolkens[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(tolkens[1]);

                    text = text.Insert(index, " ");
                    Console.WriteLine(text);
                }
                else if (command == "Reverse")
                {
                    string substring = tolkens[1];

                    if (text.Contains(substring))
                    {
                        int index = text.IndexOf(substring);
                        text = text.Remove(index, substring.Length);
                        substring = String.Concat(substring.Reverse());
                        text = text.Insert(text.Length, substring);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    var substr = tolkens[1];
                    var newSubstr = tolkens[2];

                    text = text.Replace(substr, newSubstr);
                    Console.WriteLine(text);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}