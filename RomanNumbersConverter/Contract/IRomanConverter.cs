﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConverter.Contract
{
    public interface IRomanConverter : IRomanNumberConverter<int, string>
    {
    }
}
