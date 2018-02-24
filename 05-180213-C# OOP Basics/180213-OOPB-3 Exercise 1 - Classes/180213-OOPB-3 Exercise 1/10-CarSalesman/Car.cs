using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    string model;
    Engine engine;
    string weight;
    string color;

    public Car()
    {

    }

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }

    public Car(string model, Engine engine, string weightOrColor) : this(model, engine)
    {
        if(double.TryParse(weightOrColor, out _))
        {
            this.weight = weightOrColor;
        }
        else
        {
            this.color = weightOrColor;
        }
    }

    public Car(string model, Engine engine, string weight, string color) : this(model, engine, weight)
    {
        this.color = color;
    }

    public string Model { get => model; }
    public Engine Engine { get => engine; }
    public string Weight { get => weight; }
    public string Color { get => color; }
}

