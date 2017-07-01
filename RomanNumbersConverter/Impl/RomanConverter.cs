using RomanNumbersConverter.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.Impl
{
    public class RomanConverter : IRomanConverter
    {
        public int Convert(string romanNumber)
        {
            return  romanNumber.RomanToArabic();
        }
    }
}
