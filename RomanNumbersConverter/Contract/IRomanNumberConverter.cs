using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.Contract
{
    public interface IRomanNumberConverter<out T, in U>
    {
        #region Public Methods

        T Convert(U romanNumber);

        #endregion
    }
}
