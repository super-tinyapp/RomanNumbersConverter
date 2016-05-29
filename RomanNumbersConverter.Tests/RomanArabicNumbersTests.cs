using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.Tests
{
    [TestFixture]
    public class RomanArabicNumbersTests
    {
        [Test]
        public void CanConvertRomanToArabic()
        {
            string num = "MCMLXXXIX";

            int res = num.RomanToArabic();
            Assert.True(res == 1989);
        }

        [Test]
        public void CanConvertArabicToRoman()
        {
            int num = 1914;

            string res = num.ToClassicRoman();
            Assert.True(res.Equals("MDCCCCXIIII"));
        }

        [Test]
        public void AttemptingToConvertIncorrectNumberThrowsException()
        {
            string wrongNum = "MLLLCCCIIIXX";

            Assert.Throws<ArgumentException>(() => wrongNum.RomanToArabic());
        }

        [Test]
        public void AttemptingToConvertNotARomanNumberThrowsException()
        {
            string notARomanNumber = "MMXTQWE";

            Assert.Throws<ArgumentException>(() => notARomanNumber.RomanToArabic());
        }
    }
}
