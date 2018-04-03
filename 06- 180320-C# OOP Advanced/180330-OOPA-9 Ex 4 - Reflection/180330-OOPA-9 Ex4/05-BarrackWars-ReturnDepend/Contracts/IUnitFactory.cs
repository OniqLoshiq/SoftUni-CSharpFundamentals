namespace _05_BarrackWars.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
