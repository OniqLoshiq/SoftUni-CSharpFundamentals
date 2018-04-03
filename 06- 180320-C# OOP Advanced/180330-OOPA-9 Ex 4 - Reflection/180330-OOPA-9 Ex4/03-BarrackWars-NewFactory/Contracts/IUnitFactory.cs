namespace _03_BarrackWars.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
