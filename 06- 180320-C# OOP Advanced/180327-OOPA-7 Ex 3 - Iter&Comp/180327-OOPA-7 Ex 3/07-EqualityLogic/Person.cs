using System;
using System.Collections.Generic;
using System.Text;

public class Person : IPerson, IComparable<Person>
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if(result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Person)) return false;
        Person p = (Person)obj;
        return this.Name == p.Name & this.Age == p.Age;
    }

    public override int GetHashCode()
    {
        return Tuple.Create(this.Name, this.Age).GetHashCode();
    }
}
