
namespace _04_WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int PartTime_Working_Hours_PerWeek = 20;

        public PartTimeEmployee(string name) 
            : base(name, PartTime_Working_Hours_PerWeek)
        {
        }
    }
}
