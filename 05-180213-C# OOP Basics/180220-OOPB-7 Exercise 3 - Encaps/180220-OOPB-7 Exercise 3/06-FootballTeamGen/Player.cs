using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player
{
    private const int minStatValue = 0;
    private const int maxStatValue = 100;
    string[] statsName = { "Endurance", "Sprint", "Dribble", "Passing", "Shooting" };

    private string name;
    private int[] stats;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A name should not be empty.");
            name = value;
        }
    }

    private int[] Stats
    {
        get { return stats; }
        set
        {
            int problemStat = value.FirstOrDefault(x => x < minStatValue || x > maxStatValue);
            if (problemStat != 0)
                throw new ArgumentException($"{statsName[Array.IndexOf(value, problemStat)]} should be between {minStatValue} and {maxStatValue}.");

            stats = value;
        }
    }

    public Player(string name, int[] stats)
    {
        Name = name;
        Stats = stats;
    }

    public double Skill => Stats.Average();
}