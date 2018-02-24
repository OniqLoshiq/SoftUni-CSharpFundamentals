using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    string name;
    string birthDate;

    public Person()
    {

    }

    public Person(string name, string birthDate)
    {
        this.name = name;
        this.birthDate = birthDate;
    }

    public string Name { get => name; set => name = value; }
    public string BirthDate { get => birthDate; set => birthDate = value; }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthDate}";
    }
}