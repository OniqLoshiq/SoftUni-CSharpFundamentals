using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    string name;
    string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public string Type { get => type; set => type = value; }
    public string Name { get => name; set => name = value; }
}
