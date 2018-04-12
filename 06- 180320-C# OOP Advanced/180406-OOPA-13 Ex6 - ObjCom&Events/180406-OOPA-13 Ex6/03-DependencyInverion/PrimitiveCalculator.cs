using _03_DependencyInverion.Interfaces;
using _03_DependencyInverion.Strategies;

namespace _03_DependencyInverion
{
    public class PrimitiveCalculator : ICalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.ChangeStrategy(strategy);
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
