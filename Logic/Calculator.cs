using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Calculator:ICalculator
    {
        
        public double Calculate(string expression)
        {
            string polishExpression = Parse(expression);
            double result = Counting(polishExpression);
            return result;
        }

        public string Parse(string expression)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsDelimeter(expression[i]))
                    continue;

                if (Char.IsDigit(expression[i]))
                {
                    while (!IsDelimeter(expression[i]) && !IsOperator(expression[i]))
                    {
                        output += expression[i];
                        i++;

                        if (i == expression.Length) break;
                    }
                    output += " ";
                    i--;
                }

                if (IsOperator(expression[i]))
                {
                    if (expression[i] == '(')
                        operStack.Push(expression[i]);
                    else if (expression[i] == ')')
                    {
                        char s = operStack.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (GetPriority(expression[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " "; 
                        operStack.Push(char.Parse(expression[i].ToString()));
                    }
                }
            }

            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }
        private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        private int GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        public double Counting(string polishExpression)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>(); 

            for (int i = 0; i < polishExpression.Length; i++) 
            {
                if (Char.IsDigit(polishExpression[i]))
                {
                    string a = "";
                    while (!IsDelimeter(polishExpression[i]) && !IsOperator(polishExpression[i])) 
                    {
                        a += polishExpression[i]; 
                        i++;
                        if (i == polishExpression.Length) break;
                    }
                    try
                    {
                        temp.Push(double.Parse(a));
                    }
                    catch (FormatException ex)
                    {
                        throw new CalculateException("Дробное число записано неверно");
                    }
                    i--;
                }
                else if (IsOperator(polishExpression[i])) 
                {                    
                    try
                    {
                        double a = temp.Pop();
                        double b = temp.Pop();

                        result = performOperation(polishExpression[i], a, b);
                        temp.Push(result); 
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new CalculateException("Большое количество операций");
                    }

                }
                else if (!IsDelimeter(polishExpression[i]))
                {
                    throw new CalculateException("Неверный символ");
                }
            }
            if (temp.Count == 0)
            {
                throw new CalculateException("Пустое выражение");
            }
            return temp.Peek(); 
        }

        public double performOperation(char c, double a, double b)
        {

            switch (c)
            {
                case '+': return b + a; break;
                case '-': return b - a; break;
                case '*': return b * a; break;
                case '/': if (a == 0) { throw new CalculateException("Нельзя делить на ноль"); }
                    return b / a; break;
                case '^': return double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                default: throw new CalculateException("неизвестный оператор");
            }
        }
    }
}
