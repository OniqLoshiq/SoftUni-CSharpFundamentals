using System;
using System.Collections.Generic;
using System.Text;

public class Cargo
{
    private int weight;
    private string type;

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }
}
