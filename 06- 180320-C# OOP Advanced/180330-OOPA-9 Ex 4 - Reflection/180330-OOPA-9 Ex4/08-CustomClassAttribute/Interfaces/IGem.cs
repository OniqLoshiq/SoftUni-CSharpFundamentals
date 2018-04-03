using _07_InfernoInfinity.Enums;

namespace _07_InfernoInfinity.Interfaces
{
    public interface IGem
    {
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        GemClarityIncreaser Clarity { get; }
        int BonusMinDamage { get; }
        int BonusMaxDamage { get; }
    }
}
