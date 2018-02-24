using System;
using System.Collections.Generic;
using System.Text;


public class Siamese : Cat
{
    int earSize;

    public Siamese(int earSize, string name, string breed) : base(name, breed)
    {
        this.earSize = earSize;
    }

    public int EarSize { get => earSize; set => earSize = value; }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.EarSize}";
    }
}
