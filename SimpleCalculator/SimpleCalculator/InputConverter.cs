using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumeric(string str)
        {
            double convertedNumber;
            if (!double.TryParse(str, out convertedNumber))
            {
                throw new ArgumentException("expected a numeric value");
            }
            return convertedNumber;

        }
    }
}