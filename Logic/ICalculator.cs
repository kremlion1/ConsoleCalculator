using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICalculator
    {
        double Calculate(string expression);

        double Counting(string expression);
        double performOperation(char c, double a, double b);
        string Parse(string expression);
    }
}
