namespace _07_InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int BASE_STRENGTH = 7;
        private const int BASE_AGILITY = 2;
        private const int BASE_VITALITY = 5;

        public Ruby(string clarity) 
            : base(clarity, BASE_STRENGTH, BASE_AGILITY, BASE_VITALITY)
        {
        }
    }
}
