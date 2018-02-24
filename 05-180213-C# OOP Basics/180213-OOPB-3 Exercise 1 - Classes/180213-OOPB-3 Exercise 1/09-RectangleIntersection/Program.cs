using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<Rectangle> allRects = new List<Rectangle>();

        for (int i = 0; i < tokens[0]; i++)
        {
            string[] rectData = Console.ReadLine().Split();
            string id = rectData[0];
            double width = double.Parse(rectData[1]);
            double height = double.Parse(rectData[2]);
            double topLeftX = double.Parse(rectData[3]);
            double topLeftY = double.Parse(rectData[4]);

            Rectangle newRect = new Rectangle(id, width, height, topLeftX, topLeftY);
            allRects.Add(newRect);
        }

        for (int i = 0; i < tokens[1]; i++)
        {
            string[] rectsToCheck = Console.ReadLine().Split();
            Rectangle rect1 = allRects.First(x => x.Id == rectsToCheck[0]);
            Rectangle rect2 = allRects.First(x => x.Id == rectsToCheck[1]);

            string output = rect1.DoesIntersect(rect2) ? "true" : "false";

            Console.WriteLine(output);
        }

    }
}

