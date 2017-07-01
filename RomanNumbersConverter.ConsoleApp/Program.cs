using RomanNumbersConverter.Contract;
using RomanNumbersConverter.Impl;
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
            IRomanConverter _converter;

            IValidator<string> _validator;

            _validator = new RomanValidator();
            _converter = new RomanConverter();

            string userCommand = "";
            while (userCommand != "exit")
            {
                Console.WriteLine("Please input a value in roman numerals:");
                userCommand = Console.ReadLine();

                var validateResult = _validator.Validate(userCommand);
                if (!validateResult.Result)
                {
                    Console.WriteLine(validateResult.Message);
                }
                

                if (!string.IsNullOrEmpty(userCommand) && validateResult.Result)
                {
                    var result = userCommand.RomanToArabic();
                    Console.WriteLine(string.Format("Converted: {0}",result.ToString()));
                }

            }
            Console.ReadKey();
        }
    }
}
