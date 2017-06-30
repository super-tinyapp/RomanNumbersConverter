using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string userCommand = "";
            while (userCommand != "exit")
            {
                Console.WriteLine("Please input a value in roman numerals:");
                userCommand = Console.ReadLine();
                if (!string.IsNullOrEmpty(userCommand))
                {
                    var result = userCommand.RomanToArabic();
                    Console.WriteLine(result); ;
                }

            }
            Console.ReadKey();
        }
    }
}
