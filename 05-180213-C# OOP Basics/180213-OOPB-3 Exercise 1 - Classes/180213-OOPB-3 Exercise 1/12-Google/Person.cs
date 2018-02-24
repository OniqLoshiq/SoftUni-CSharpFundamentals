using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    string name;
    Company company;
    Car car;
    List<Parents> parents;
    List<Children> children;
    List<Pokemon> pokemons;

    public Person(string name)
    {
        this.name = name;
        this.parents = new List<Parents>();
        this.children = new List<Children>();
        this.pokemons = new List<Pokemon>();
    }
    public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }
    public List<Children> Children { get => children; set => children = value; }
    public List<Parents> Parents { get => parents; set => parents = value; }
    public Car Car { get => car; set => car = value; }
    public Company Company { get => company; set => company = value; }
    public string Name { get => name; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.Name);
        sb.AppendLine("Company:");

        if(this.Company != null)
        {
            sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salay:f2}");
        }
        
        sb.AppendLine("Car:");
        if(this.Car != null)
        {
            sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }
        
        sb.AppendLine("Pokemon:");

        if(this.Pokemons.Count > 0)
        {
            foreach (var pokemon in this.Pokemons)
            {
                sb.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }
        }

        sb.AppendLine("Parents:");

        if(this.Parents.Count > 0)
        {
            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.BirthDay}");
            }
        }

        sb.AppendLine("Children:");

        if(this.Children.Count > 0)
        {
            foreach (var child in this.Children)
            {
                sb.AppendLine($"{child.Name} {child.BirthDay}");
            }
        }

        return sb.ToString();
    }
}
