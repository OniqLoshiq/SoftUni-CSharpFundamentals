using System;


class Program
{
    static void Main(string[] args)
    {
        string figure = Console.ReadLine();

        if (figure == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            Square square = new Square(size);
            square.Draw();
        }
        else if(figure == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Rectangle rect = new Rectangle(width, height);
            rect.Draw();
        }
    }
}
