using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
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
