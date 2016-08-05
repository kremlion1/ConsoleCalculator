using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logic
{
    public class CalculateTest
    {
        [Fact]
        public void CalculateTest1()
        {
            ICalculator calculator = new Calculator();
            string expression = "1 1 +";
            double value = calculator.Counting(expression);
            Assert.Equal(2, value);

            expression = "2 3 2 / * ";
            value = calculator.Counting(expression);
            Assert.Equal(3, value);

            expression = "2 1,5 * ";
            value = calculator.Counting(expression);
            Assert.Equal(3, value);

        }
        [Fact]
        public void CalculateDoubleFailTest()
        {
            ICalculator calculator = new Calculator();            
            Assert.Throws<CalculateException>(() => calculator.Counting("1 1.12 +"));
        }
        [Fact]
        public void CalculateNullArgumentFailTest()
        {
            ICalculator calculator = new Calculator();
            Assert.Throws<CalculateException>(() => calculator.Counting("1 + /"));
            Assert.Throws<CalculateException>(() => calculator.Counting(""));
        }
        [Fact]
        public void CalculateCharFailTest()
        {
            ICalculator calculator = new Calculator();
            Assert.Throws<CalculateException>(() => calculator.Counting("abc"));
            Assert.Throws<CalculateException>(() => calculator.Counting("1 a +"));
        }
    }
}
