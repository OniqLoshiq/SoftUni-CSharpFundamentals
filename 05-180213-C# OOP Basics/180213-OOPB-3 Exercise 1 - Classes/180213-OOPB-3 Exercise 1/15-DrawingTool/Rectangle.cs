using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle : DrawFig
{
    int width;
    int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }

    public override void Draw()
    {
        Console.WriteLine("|{0}|", new string('-', Width));
        for (int i = 0; i < Height - 2; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', Width));
        }
        Console.WriteLine("|{0}|", new string('-', Width));
    }
}
