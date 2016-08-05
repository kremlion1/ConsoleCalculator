using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;


namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Консольный калькулятор:");
            System.Console.WriteLine("Для выхода нажмите Ctrl+C");            
            Console.CancelKeyPress += (sender, e) =>
            {

                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            };
            while (true)
            {
                Console.WriteLine("Введите выражение:");
                string expression = System.Console.ReadLine();
                ICalculator calculator = new Calculator();
                try
                {
                    if (expression != null) 
                        Console.WriteLine(calculator.Calculate(expression));
                }
                catch (CalculateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
