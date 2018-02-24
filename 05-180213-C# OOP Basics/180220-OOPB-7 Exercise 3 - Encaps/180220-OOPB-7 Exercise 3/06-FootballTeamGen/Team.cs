using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private List<Player> players;

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

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
       if (!players.Any(x => x.Name == playerName))
           throw new ArgumentException($"Player {playerName} is not in {Name} team.");
        else
        {
            players.Remove(players.First(x => x.Name == playerName));
        }
    }

    public int Rating => players.Count > 0 ? (int)Math.Round(players.Sum(x => x.Skill), 0) : 0;

    public override string ToString()
    {
        return $"{Name} - {Rating}";
    }
}
