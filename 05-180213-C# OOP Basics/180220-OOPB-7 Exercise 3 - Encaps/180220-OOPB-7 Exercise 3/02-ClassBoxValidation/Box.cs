using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    private double Height
    {
        set
        {
            ValidateDataInput(value, "Height");
            height = value;
        }
    }

    private double Length
    {
        set
        {
            ValidateDataInput(value, "Length");
            length = value;
        }
    }

    private double Width
    {
        set
        {
            ValidateDataInput(value, "Width");
            width = value;
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    private void ValidateDataInput(double fieldValue, string propName)
    {
        if (fieldValue <= 0)
            throw new ArgumentException($"{propName} cannot be zero or negative.");
    }

    public void GetVolume()
    {
        double volume = length * height * width;
        Console.WriteLine($"Volume - {volume:f2}");
    }
    public void GetLateralArea()
    {
        double lateralArea = 2 * (width * height) + 2 * (length * height);
        Console.WriteLine($"Lateral Surface Area - {lateralArea:f2}");
    }
    public void GetSurfaceArea()
    {
        double surfaceArea = 2 * (width * height) + 2 * (length * height) + 2 * (length * width);
        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
    }
}
