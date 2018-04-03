namespace _07_InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int BASE_STRENGTH = 2;
        private const int BASE_AGILITY = 8;
        private const int BASE_VITALITY = 4;

        public Amethyst(string clarity)
            : base(clarity, BASE_STRENGTH, BASE_AGILITY, BASE_VITALITY)
        {
        }
    }
}
