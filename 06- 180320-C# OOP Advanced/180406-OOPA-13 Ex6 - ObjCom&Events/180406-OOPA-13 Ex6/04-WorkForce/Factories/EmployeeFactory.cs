using _04_WorkForce.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _04_WorkForce.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployable CreateEmployee(string[] data)
        {
            string employeeType = data[0];
            string name = data[1];

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == employeeType);

            if(type == null)
            {
                throw new ArgumentException("Invalid employee type!");
            }
            if(!typeof(IEmployable).IsAssignableFrom(type))
            {
                throw new ArgumentException("This is not an employee type!");
            }

            IEmployable employee = (IEmployable)Activator.CreateInstance(type, new object[] { name });

            return employee;
        }
    }
}
