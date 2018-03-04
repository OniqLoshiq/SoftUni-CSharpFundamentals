using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private ICollection<IMissionable> missions;

    public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<IMissionable>();
    }

    public IReadOnlyCollection<IMissionable> Missions => (IReadOnlyCollection<IMissionable>)this.missions;

    public void AddMission(IMissionable mission)
    {
        this.missions.Add(mission);
    }

    public void CompleteMission(string missionCodeName)
    {
        IMissionable mission = this.Missions.FirstOrDefault(m => m.CodeName == missionCodeName);

        if (mission != null)
            mission.Complete();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corp}")
            .AppendLine($"Missions:");

        foreach (var mission in this.Missions)
        {
            sb.AppendLine($"  {mission.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}
