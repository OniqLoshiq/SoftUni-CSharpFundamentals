using _04_WorkForce.Interfaces;

namespace _04_WorkForce.Models
{
    public abstract class Employee : IEmployable
    {
        public string Name { get; }

        public int WorkHoursPerWeek { get; }

        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }
    }
}
