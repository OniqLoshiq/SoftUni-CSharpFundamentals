using System;


class Program
{
    static void Main(string[] args)
    {
        Person pesho = new Person();
        pesho.Age = 20;
        pesho.Name = "Pesho";

        Person gosho = new Person { Age = 18, Name = "Gosho" };

        Person stamat = new Person(18, "Stamat");
    }
}

