using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.Contract
{
    public interface IValidator<T>
    {
        #region Public Methods

        ValidateResult Validate(T input);

        #endregion
    }

    public class ValidateResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
