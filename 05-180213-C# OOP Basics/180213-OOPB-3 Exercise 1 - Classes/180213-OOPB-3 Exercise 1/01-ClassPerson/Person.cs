using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    int age;
    string name;

    public int Age
    {
        get { return this.age = age; }
        set { this.age = value; }
    }

    public string Name
    {
        get { return this.name = name; }
        set { this.name = value; }
    }

    public Person()
    {

    }

    public Person(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}


