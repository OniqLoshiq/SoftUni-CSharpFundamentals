using System;
using System.Collections.Generic;
using System.Text;

public class GandalfsFood
{
    private Dictionary<string, int> foodPoits = new Dictionary<string, int>
    {
        ["cram"] = 2,
        ["lembas"] = 3,
        ["apple"] = 1,
        ["melon"] = 1,
        ["honeycake"] = 5,
        ["mushrooms"] = -10
    };

    private List<string> Food { get; set; }

    public GandalfsFood(List<string> food)
    {
        Food = food;
    }

    private int CalcedFoodPoints
    {
        get
        {
            int points = 0;

            foreach (var item in Food)
            {
                if (foodPoits.ContainsKey(item))
                {
                    points += foodPoits[item];
                }
                else points--;
            }
            return points;
        }
    }

    private string GetMood()
    {
        string mood = String.Empty;

        if (CalcedFoodPoints > 15) mood = "JavaScript";
        else if (CalcedFoodPoints >= 1) mood = "Happy";
        else if (CalcedFoodPoints >= -5) mood = "Sad";
        else mood = "Angry";

        return mood;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(CalcedFoodPoints.ToString())
            .AppendLine(GetMood());

        return sb.ToString();
    }
}
