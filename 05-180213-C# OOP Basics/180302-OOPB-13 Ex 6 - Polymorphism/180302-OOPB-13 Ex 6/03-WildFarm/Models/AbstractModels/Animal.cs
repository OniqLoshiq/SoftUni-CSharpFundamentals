using System;
using System.Collections.Generic;

public abstract class Animal : IAnimal
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name { get; private set; }
    public double Weight { get; protected set; }
    public int FoodEaten { get; private set; }

    protected virtual List<string> FoodToEat { get; set; }
    protected virtual double WeightIncreasePerPieceFood => 0.0;

    public abstract string ProduceSound();

    public void Eat(Food food)
    {
        Console.WriteLine(ProduceSound());

        if (!FoodToEat.Contains(food.GetType().Name))
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType()}!");

        this.FoodEaten = food.Quantity;
        this.Weight += this.FoodEaten * WeightIncreasePerPieceFood;
    }
}
