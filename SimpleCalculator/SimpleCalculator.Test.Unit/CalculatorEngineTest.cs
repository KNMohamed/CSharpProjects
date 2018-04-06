using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            double result;
            int n1 = 1;
            int n2 = 2;

            result = _calculatorEngine.Calculate("add",n1,n2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            double result;
            int n1 = 1;
            int n2 = 2;

            result = _calculatorEngine.Calculate("+", n1, n2);
            Assert.AreEqual(3, result);
        }
    }
}
