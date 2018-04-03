namespace _04_BarrackWars.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
