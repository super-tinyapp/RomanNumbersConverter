using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter
{
    public static class RomanExtensions
    {
        public static int RomanToArabic(this string numberStr)
        {
            int res = 0;
            bool isLastDigit = false;
            bool skipNextDigit = false;

            var chars = numberStr.ToCharArray();

            for (int i = 0; i < chars.Count(); i++)
            {
                if (skipNextDigit)
                {
                    skipNextDigit = false;
                    continue;
                }

                RomanNumberSymbol currentSymbol = GetRomanSymbol(chars.ElementAt(i));
                isLastDigit = i == chars.Count() - 1;

                int currentNumber = 0;
                RomanNumberSymbol? nextSymbol = (isLastDigit) ? (RomanNumberSymbol?)null : GetRomanSymbol(chars.ElementAt(i + 1));

                if (!isLastDigit && nextSymbol.HasValue && IsSpecialCase(currentSymbol, nextSymbol.Value))
                {
                    currentNumber = (int)nextSymbol - (int)currentSymbol;
                    skipNextDigit = true;
                }
                else
                {
                    currentNumber = (int)currentSymbol;
                }

                res += currentNumber;
            }

            return res;
        }

        /// <summary>
        /// In classic roman numbers are recorded left to right, from largest to smallest digits, similar digits grouped together
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToClassicRoman(this int number)
        {
            if (number > 4999)
                throw new ArgumentException("Can't convert number larger than 4999, as classic roman number can have at most 4 similar digits.");

            StringBuilder result = new StringBuilder();

            AppendDigits(ref number, RomanNumberSymbol.M, result);
            AppendDigits(ref number, RomanNumberSymbol.D, result);
            AppendDigits(ref number, RomanNumberSymbol.C, result);
            AppendDigits(ref number, RomanNumberSymbol.L, result);
            AppendDigits(ref number, RomanNumberSymbol.X, result);
            AppendDigits(ref number, RomanNumberSymbol.V, result);
            AppendDigits(ref number, RomanNumberSymbol.I, result);

            return result.ToString();
        }

        private static void AppendDigits(ref int number, RomanNumberSymbol romanDigit, StringBuilder str)
        {
            decimal digitsCount = number / (decimal)romanDigit;
            if (digitsCount < 0)
                return;

            int subtrahend = (int)(Math.Floor(digitsCount) * (int)romanDigit);
            number -= subtrahend;

            int intCount = (int)Math.Floor(digitsCount);
            for (int i = 0; i < intCount; i++)
            {
                str.Append(romanDigit.ToString());
            }
        }

        private static bool IsSpecialCase(RomanNumberSymbol first, RomanNumberSymbol second)
        {
            if (first == second || first > second)
                return false;

            if (first == RomanNumberSymbol.I && second == RomanNumberSymbol.V ||
                first == RomanNumberSymbol.I && second == RomanNumberSymbol.X ||
                first == RomanNumberSymbol.X && second == RomanNumberSymbol.L ||
                first == RomanNumberSymbol.X && second == RomanNumberSymbol.C ||
                first == RomanNumberSymbol.C && second == RomanNumberSymbol.D ||
                first == RomanNumberSymbol.C && second == RomanNumberSymbol.M)
            {
                return true;
            }

            throw new ArgumentException("Invalid Roman digit composition. Roman digits in numbers generally go from highest to lowest, " +
                "only exception beeing 6 special cases when it's used for brevity, e.g. IV instead of IIII.");
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
