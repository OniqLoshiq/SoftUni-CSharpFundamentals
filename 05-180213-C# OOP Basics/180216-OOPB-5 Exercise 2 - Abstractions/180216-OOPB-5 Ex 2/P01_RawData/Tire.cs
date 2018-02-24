using System;
using System.Collections.Generic;
using System.Text;

public class Tire
{
    private double pressure;
    private int age;
    private List<Tire> tires;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }

    public Tire(string[] tireParams)
    {
        tires = new List<Tire>();

        for (int tire = 0; tire < tireParams.Length; tire += 2)
        {
            double tirePressure = double.Parse(tireParams[tire]);
            int tireAge = int.Parse(tireParams[tire + 1]);

            tires.Add(new Tire(tirePressure, tireAge));
        }
    }

    public List<Tire> Tires { get => tires; }
}
