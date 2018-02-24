using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    string id;
    double width;
    double height;
    double topLeftX;
    double topLeftY;

    public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
    }

    public string Id { get => id; }

    public bool DoesIntersect(Rectangle secondRec)
    {
        double rectsWidthSum = (width + secondRec.width) / 2.0;
        double rectsHeightSum = (height + secondRec.height) / 2.0;
        double x1 = width / 2.0 + topLeftX;
        double y1 = height / 2.0 + topLeftY;

        double x2 = secondRec.width / 2.0 + secondRec.topLeftX;
        double y2 = secondRec.height / 2.0 + secondRec.topLeftY;

        return (Math.Abs(x1 - x2) <= rectsWidthSum) && (Math.Abs(y1 - y2) <= rectsHeightSum);
    }
}
