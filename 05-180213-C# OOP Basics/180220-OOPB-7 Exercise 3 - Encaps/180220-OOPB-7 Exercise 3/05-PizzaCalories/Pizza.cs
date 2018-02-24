using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    const int minToppingsNum = 0;
    const int maxToppingsNum = 10;
    const int pizzaMinNameLenght = 1;
    const int pizzaMaxNameLenght = 15;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length < pizzaMinNameLenght || value.Length > pizzaMaxNameLenght)
                throw new ArgumentException($"Pizza name should be between {pizzaMinNameLenght} and {pizzaMaxNameLenght} symbols.");
            name = value;
        }
    }

    public Dough Dough { get => dough; private set => dough = value; }

    public Pizza()
    {
        toppings = new List<Topping>();
    }

    public Pizza(string name) : this()
    {
        Name = name;
    }

    public Pizza(string name, Dough dough):this(name)
    {
        Dough = dough;
    }

    public void AddToppingToPizza(Topping topping)
    {
        if (toppings.Count > 10)
            throw new ArgumentException($"Number of toppings should be in range [{minToppingsNum}..{maxToppingsNum}].");

        toppings.Add(topping);        
    }

    public double CalculatePizzaCalories()
    {
        double totalPizzaCalories = 0.0;

        totalPizzaCalories += Dough.DoughCalories();

        foreach (var topping in toppings)
        {
            totalPizzaCalories += topping.ToppingCalories();
        }
        return totalPizzaCalories;
    }

    public override string ToString()
    {
        return $"{Name} - {CalculatePizzaCalories():f2} Calories.";
    }
}
