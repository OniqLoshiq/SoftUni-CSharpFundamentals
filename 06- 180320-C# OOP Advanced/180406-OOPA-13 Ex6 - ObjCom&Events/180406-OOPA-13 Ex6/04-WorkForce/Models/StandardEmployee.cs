
namespace _04_WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private const int Standart_Working_Hours_PerWeek = 40;

        public StandardEmployee(string name) 
            : base(name, Standart_Working_Hours_PerWeek)
        {
        }
    }
}
