using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    string model;
    Engine engine;
    Cargo cargo;
    Tire[] tires;
    
    public Car(Engine engine, Cargo cargo, Tire[] tires, string model)
    {
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
        this.model = model;
    }

    public string Model { get => model;}
    public Cargo Cargo { get => cargo; }
    public Tire[] Tires { get => tires; }
    public Engine Engine { get => engine; }

}

