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
            
            return result;
        }
    }
}
