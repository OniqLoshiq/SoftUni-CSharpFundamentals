﻿public class Rebel : IPerson
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public int Food { get; private set; }
    public string Group { get; private set; }

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Food = 0;
        Group = group;
    }

    public void BuyFood()
    {
        Food += 5;
    }
}
