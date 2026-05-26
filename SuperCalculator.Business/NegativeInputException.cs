using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalculator.Business
{
    public class NegativeInputException : ApplicationException
    {
        public NegativeInputException(string msg = null, Exception innerExp = null) : base(msg, innerExp)
        {
            
        }
    }
}
