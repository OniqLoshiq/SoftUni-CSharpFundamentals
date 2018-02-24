using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();
        GetTeams(teams);
    }

    private static void GetTeams(List<Team> teams)
    {
        string cmdInput = String.Empty;

        while ((cmdInput = Console.ReadLine()) != "END")
        {
            try
            {
                string[] tokens = cmdInput.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string cmd = tokens[0];
                string teamName = tokens[1];

                if (cmd == "Team")
                {
                    Team newTeam = new Team(teamName);
                    teams.Add(newTeam);
                }
                else
                {
                    if (!teams.Any(x => x.Name == teamName))
                        throw new ArgumentException($"Team {teamName} does not exist.");

                    switch (cmd)
                    {
                        case "Add":
                            Player newPlayer = new Player(tokens[2], tokens.Skip(3).Select(int.Parse).ToArray());
                            teams.First(x => x.Name == teamName).AddPlayer(newPlayer);
                            break;
                        case "Remove":
                            string playerName = tokens[2];
                            teams.First(x => x.Name == teamName).RemovePlayer(playerName);
                            break;
                        case "Rating":
                            Console.WriteLine(teams.First(x => x.Name == teamName).ToString());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
