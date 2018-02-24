using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Pizza pizza = GetPizza();

            Console.WriteLine(pizza.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Pizza GetPizza()
    {
        string[] pizzaName = Console.ReadLine().Split();

        Dough dough = GetDough();

        Pizza pizza = new Pizza(pizzaName[1], dough);

        AddToppings(pizza);

        return pizza;
    }

    private static void AddToppings(Pizza pizza)
    {
        string toppingsInput = String.Empty;

        while ((toppingsInput = Console.ReadLine()) != "END")
        {
            string[] tokens = toppingsInput.Split();
            string toppingName = tokens[1];
            int weight = int.Parse(tokens[2]);

            Topping topping = new Topping(toppingName, weight);

            pizza.AddToppingToPizza(topping);
        }
    }

    private static Dough GetDough()
    {
        string[] doughInput = Console.ReadLine().Split();
        string doughType = doughInput[1];
        string doughBakingTechnique = doughInput[2];
        int doughWeight = int.Parse(doughInput[3]);

        return new Dough(doughType, doughBakingTechnique, doughWeight);
    }
}
