using System.Collections.Generic;

public interface IEngineer : IPrivate
{
    IReadOnlyCollection<IRepairable> Repairs { get; }
    void AddRepair(IRepairable repair);
}
