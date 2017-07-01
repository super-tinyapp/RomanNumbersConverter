using RomanNumbersConverter.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.Impl
{
    public class RomanValidator : IValidator<string>
    {
        public ValidateResult Validate(string input)
        {
            ValidateResult result = new ValidateResult();
            result.Result = true;
            result.Message = "Great, the input is valid value.";

            if (string.IsNullOrEmpty(input))
            {
                result = new ValidateResult();
                result.Result = false;
                result.Message = "You should input someting.";
            }

            int numberInput;
            if (int.TryParse(input,out numberInput))
            {
                result.Result = false;
                result.Message = "Invalid input, please try again.";
            }

            var chars = input.ToCharArray();

            RomanNumberSymbol symbolResult;

            for (int i = 0; i < chars.Count(); i++)
            {
                bool isValidDigit = Enum.TryParse<RomanNumberSymbol>(chars.ElementAt(i).ToString(), out symbolResult);
                if (!isValidDigit)
                {
                    result.Result = false;
                    result.Message = "Invalid input, please try again.";
                }
            }

            return result;
        }


        private static RomanNumberSymbol GetRomanSymbol(char romanDigit)
        {
            RomanNumberSymbol result;

            bool isValidDigit = Enum.TryParse<RomanNumberSymbol>(romanDigit.ToString(), out result);
            if (!isValidDigit)
                throw new ArgumentException("Invalid character encountered. Please use only Roman digits (I, V, X, L, C, D, M)");

            return result;
        }
    }
}
