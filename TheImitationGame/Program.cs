using System;

namespace TheImitationGame
{
    class Program
    {
        static void Main()
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while(command != "Decode")
            {
                string[] token = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                
                switch (token[0])
                {
                    case "Move":
                        int ceracterCount = int.Parse(token[1]);
                        string ceracters = message.Substring(0, ceracterCount);
                        message = message.Substring(ceracterCount) + ceracters;
                        break;
                   
                    case "Insert":
                        int index = int.Parse(token[1]);
                        message= message.Insert(index, token[2]);
                        break;
                       
                    case "ChangeAll":
                        while (message.Contains(token[1]))
                        {
                            message = message.Replace(token[1], token[2]);
                        }

                        break;
                }



                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
