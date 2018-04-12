
namespace _03_DependencyInverion.Interfaces
{
    public interface ICalculator
    {
        void ChangeStrategy(IStrategy strategy);
        int PerformCalculation(int firstOperand, int secondOperand);
    }
}
