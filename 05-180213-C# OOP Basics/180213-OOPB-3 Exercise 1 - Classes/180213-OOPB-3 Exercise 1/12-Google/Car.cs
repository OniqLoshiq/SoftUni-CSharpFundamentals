using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    string model;
    double speed;

    public Car(string model, double speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public string Model { get => model; set => model = value; }
    public double Speed { get => speed; set => speed = value; }
}
