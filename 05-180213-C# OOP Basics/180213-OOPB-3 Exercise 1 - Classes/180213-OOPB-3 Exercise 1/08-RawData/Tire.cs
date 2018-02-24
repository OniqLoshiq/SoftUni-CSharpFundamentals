using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    int age;
    double pressure;

    public double Pressure { get => pressure; set => pressure = value; }
    public int Age { get => age; set => age = value; }

    public Tire(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}

