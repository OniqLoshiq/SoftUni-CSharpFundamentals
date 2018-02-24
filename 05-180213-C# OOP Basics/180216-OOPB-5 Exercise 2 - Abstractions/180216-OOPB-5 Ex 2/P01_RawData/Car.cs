using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine { get => engine; }
    public Cargo Cargo { get => cargo; }
    public List<Tire> Tires { get => tires; }

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
}
