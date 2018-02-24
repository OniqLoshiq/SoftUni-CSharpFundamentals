using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            box.GetSurfaceArea();
            box.GetLateralArea();
            box.GetVolume();
        }
        catch (Exception invalidData)
        {
            Console.WriteLine(invalidData.Message);
        }
    }
}
