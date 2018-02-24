using System;
using System.Collections.Generic;
using System.Text;


public class Square : DrawFig
{
    int size;

    public Square(int size)
    {
        this.size = size;
    }

    public int Size { get => size; set => size = value; }

    public override void Draw()
    {
        Console.WriteLine("|{0}|", new string('-', Size));
        for (int i = 0; i < size - 2; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', Size));
        }
        Console.WriteLine("|{0}|", new string('-', Size));
    }
}
