using System;
using System.Collections.Generic;
using System.Text;


public class Children
{
    string name;
    string birthDay;

    public Children(string name, string birthDay)
    {
        this.name = name;
        this.birthDay = birthDay;
    }

    public string BirthDay { get => birthDay; set => birthDay = value; }
    public string Name { get => name; set => name = value; }
}
