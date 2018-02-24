using System;
using System.Collections.Generic;
using System.Text;


public class StreetExtraordinaire : Cat
{
    int decibels;

    public StreetExtraordinaire(int decibels, string name, string breed) : base(name, breed)
    {
        this.decibels = decibels;
    }

    public int Decibels { get => decibels; set => decibels = value; }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.Decibels}";
    }
}
