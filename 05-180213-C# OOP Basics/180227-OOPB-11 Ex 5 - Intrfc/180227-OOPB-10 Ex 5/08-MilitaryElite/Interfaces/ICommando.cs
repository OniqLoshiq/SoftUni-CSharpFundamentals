using System.Collections.Generic;

public interface ICommando : IPrivate
{
    IReadOnlyCollection<IMissionable> Missions { get; }
    void AddMission(IMissionable mission);
    void CompleteMission(string missionCodeName);
}
