using _03_DependencyInverion.Interfaces;
using _03_DependencyInverion.Strategies;
using System;

namespace _03_DependencyInverion
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End") 
            {
                string[] tokens = input.Split();

                bool result = Int32.TryParse(tokens[0], out int firstOperand);

                if (result)
                {
                    int secondOperand = int.Parse(tokens[1]);

                    Console.WriteLine(calculator.PerformCalculation(firstOperand, secondOperand));
                }
                else
                {
                    char @operator = tokens[1][0];

                    switch (@operator)
                    {
                        case '+':
                            calculator.ChangeStrategy(new AdditionStrategy());
                            break;
                        case '-':
                            calculator.ChangeStrategy(new SubtractionStrategy());
                            break;
                        case '*':
                            calculator.ChangeStrategy(new MultiplicationStrategy());
                            break;
                        case '/':
                            calculator.ChangeStrategy(new DivisionStrategy());
                            break;
                    }
                }
            }
        }
    }
}
