using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private ICollection<IRepairable> repairs;

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepairable>();
    }

    public IReadOnlyCollection<IRepairable> Repairs => (IReadOnlyCollection<IRepairable>)this.repairs;

    public void AddRepair(IRepairable repair)
    {
        this.repairs.Add(repair);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corp.ToString()}")
            .AppendLine($"Repairs:");


        foreach (var repair in this.Repairs)
        {
            sb.AppendLine($"  {repair.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}
