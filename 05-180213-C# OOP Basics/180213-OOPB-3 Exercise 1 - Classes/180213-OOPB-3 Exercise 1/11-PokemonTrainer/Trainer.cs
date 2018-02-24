using System;
using System.Collections.Generic;
using System.Text;


public class Trainer
{
    string name;
    int badges;
    List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        this.pokemons = new List<Pokemon>();
        this.badges = 0;
    }

    public string Name { get => name; }
    public int Badges { get => badges; set => this.badges = value; }
    public List<Pokemon> Pokemons { get => pokemons; set => this.pokemons = value; }
}

