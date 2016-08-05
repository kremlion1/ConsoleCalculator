using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ParserTests
    {
        [Fact]        
        public void ReversePolishParserTest()
        {
            ICalculator parser = new Calculator();
            string expression = "1+1";
            string result = parser.Parse(expression);
            string expected = "1 1 + ";
            Assert.Equal(expected, result);

            expression = "2*(3/2)";
            result = parser.Parse(expression);
            expected = "2 3 2 / * ";
            Assert.Equal(expected, result);
        }

    }
}
