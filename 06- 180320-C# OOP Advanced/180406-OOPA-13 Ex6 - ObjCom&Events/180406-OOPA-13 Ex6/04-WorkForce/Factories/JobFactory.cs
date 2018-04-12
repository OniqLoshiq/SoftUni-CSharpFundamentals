using _04_WorkForce.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace _04_WorkForce.Factories
{
    public class JobFactory : IJobFactory
    {
        public IJob CreateJob(string[] data, IEmployable employee)
        {
            string taskType = data[0];
            string name = data[1];
            int requiredHours = int.Parse(data[2]);

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == taskType);

            if(type == null)
            {
                throw new ArgumentException("Invalid task type!");
            }
            if(!typeof(IJob).IsAssignableFrom(type))
            {
                throw new ArgumentException("This is not a task type");
            }

            object[] ctorArgs = new object[] { requiredHours, name, employee};

            IJob job = (IJob)Activator.CreateInstance(type, ctorArgs);

            return job;
        }
    }
}
