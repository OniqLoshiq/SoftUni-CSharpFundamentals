using System;
using System.Collections.Generic;
using System.Text;


public class Cat
{
    string name;
    string breed;

    public Cat(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }

    public string Breed { get => breed; set => breed = value; }
    public string Name { get => name; set => name = value; }
}
