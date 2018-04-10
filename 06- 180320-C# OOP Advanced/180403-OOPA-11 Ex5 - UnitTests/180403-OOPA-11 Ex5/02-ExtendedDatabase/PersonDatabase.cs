using _01_Database;
using System;
using System.Linq;

namespace _02_ExtendedDatabase
{
    public class PersonDatabase : Database<IPerson>
    {
        public override void Add(IPerson element)
        {
            if(base.Storage.First() != null)
            CheckIfPersonIsUnique(element);

            base.Add(element);
        }

        public IPerson FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("Username cannot be blank!");

            IPerson person = base.Storage.FirstOrDefault(p => p.Username.Equals(username));

            if (person == null)
                throw new InvalidOperationException("No Person was found with this Username!");

            return person;
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id should have positive value!");

            IPerson person = base.Storage.FirstOrDefault(p => p.Id.Equals(id));

            if (person == null)
                throw new InvalidOperationException("No Person was found with this id!");

            return person;
        }

        private void CheckIfPersonIsUnique(IPerson element)
        {
            if (base.Storage.Any(p => p.Id.Equals(element.Id)))
                throw new InvalidOperationException("Person with such Id already exists!");

            if (base.Storage.Any(p => p.Username.Equals(element.Username)))
                throw new InvalidOperationException("Person with such Username already exists!");
        }
    }
}
