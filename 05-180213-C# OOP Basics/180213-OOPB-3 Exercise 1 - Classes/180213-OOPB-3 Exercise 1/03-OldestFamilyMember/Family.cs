using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    List<Person> people;

    public Family()
    {
        this.people = new List<Person>();
    }

    public void AddMember(Person person)
    {
        people.Add(person);
    }

    public Person GetOldestMember()
    {
        return this.people.FirstOrDefault(x => x.Age == people.Max(y => y.Age));
    }
}
