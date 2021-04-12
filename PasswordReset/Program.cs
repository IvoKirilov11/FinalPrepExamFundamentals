using System;
using System.Text;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (input != "Done")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                
                if(command[0] == "TakeOdd")
                {
                    for (int i = 1; i < password.Length; i+=2)
                    {
                        char currChar = password[i];
                        sb.Append(currChar);
                    }
                    password = sb.ToString();
                    Console.WriteLine(sb.ToString());
                }
                if(command[0] == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);
                    password = password.Remove(index, length); 
                    Console.WriteLine(password);
                }
                else if(command[0] == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if(password.Contains(substring))
                    {
                     password = password.Replace(substring, substitute);
                    Console.WriteLine(password);
                    }
                    else
                    {
                    Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine();

            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
