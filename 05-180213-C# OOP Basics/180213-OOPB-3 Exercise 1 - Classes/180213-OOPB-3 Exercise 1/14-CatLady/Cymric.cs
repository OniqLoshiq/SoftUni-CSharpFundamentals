using System;
using System.Collections.Generic;
using System.Text;


public class Cymric : Cat
{
    double furLength;

    public Cymric(double furLength, string name, string breed) : base(name, breed)
    {
        this.furLength = furLength;
    }

    public double FurLength { get => furLength; set => furLength = value; }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.FurLength:f2}";
    }
}
