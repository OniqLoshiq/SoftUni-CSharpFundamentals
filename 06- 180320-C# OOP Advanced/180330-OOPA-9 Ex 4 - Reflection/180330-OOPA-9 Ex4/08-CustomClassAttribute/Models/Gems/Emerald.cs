namespace _07_InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int BASE_STRENGTH = 1;
        private const int BASE_AGILITY = 4;
        private const int BASE_VITALITY = 9;

        public Emerald(string clarity)
            : base(clarity, BASE_STRENGTH, BASE_AGILITY, BASE_VITALITY)
        {
        }
    }
}
