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
            string num = "MCMLXXXIX";
            string num2 = "XXK";

            int res = num.RomanToArabic();
            Console.WriteLine(res);

            int number = 1914;

            string roman = number.ToClassicRoman();

            Console.WriteLine(roman);

            Console.Read();
        }
    }
}
