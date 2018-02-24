using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    int speed;
    int power;

    public int Power { get => power; set => power = value; }
    public int Speed { get => speed; set => speed = value; }

    public Engine(int speed, int power)
    {
        Speed = speed;
        Power = power;
    }
}

