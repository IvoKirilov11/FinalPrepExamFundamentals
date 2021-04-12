using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = (@"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+");
            int count = int.Parse(Console.ReadLine());

            Regex barcodeRegex = new Regex(pattern);

            while (count-- > 0)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string productGroup = "";
                    for (int i = 0; i < match.Value.Length; i++)
                    {
                        if (char.IsDigit(match.Value[i]))
                        {
                            productGroup += match.Value[i];
                        }
                    }
                    if (productGroup != "")
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
