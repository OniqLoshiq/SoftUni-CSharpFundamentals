using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            name = value;
        }
    }

    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");
            money = value;
        }
    }

    private List<Product> Bag { get => bag; set => bag = value; }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public void AddProductToBag(Product product)
    {
        if(Money - product.Cost < 0)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
        else
        {
            Money -= product.Cost;
            Bag.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (Bag.Count == 0)
        {
            sb.AppendFormat($"{Name} - Nothing bought");
        }
        else
        {
            sb.AppendFormat("{0} - {1}", Name, string.Join(", ", Bag));
        }

        string result = sb.ToString();
        return result;
    }
}
