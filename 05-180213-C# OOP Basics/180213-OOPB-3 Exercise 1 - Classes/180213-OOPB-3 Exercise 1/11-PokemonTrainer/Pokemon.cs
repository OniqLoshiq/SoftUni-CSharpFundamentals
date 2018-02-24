using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    string name;
    string element;
    double health;

    public Pokemon(string name, string element, double health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public string Name { get => name; }
    public string Element { get => element; }
    public double Health { get => health; set => this.health = value;  }
}

