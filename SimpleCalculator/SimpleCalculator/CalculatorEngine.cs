using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double Calculate(string op, double n1, double n2)
        {
            double result;
            switch (op.ToLower())
            {
                case "add":
                case "+":
                    result = n1 + n2;
                    break;
                case "subtract":
                case "sub":
                case "-":
                    result = n1 - n2;
                    break;
                case "multiply":
                case "mult":
                case "*":
                    result = n1 * n2;
                    break;
                case "divide":
                case "div":
                case "/":
                    if (n2 == 0) throw new DivideByZeroException("Can't divide by zero");
                    result = n1 / n2;
                    break;
                default:
                    throw new InvalidOperationException("Specified operation is not recognized");

            }
            return result;
        }
    }
}
