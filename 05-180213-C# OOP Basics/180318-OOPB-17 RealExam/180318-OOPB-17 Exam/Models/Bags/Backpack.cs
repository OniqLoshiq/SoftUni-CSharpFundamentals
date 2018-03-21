namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Backpack : Bag
    {
        private const int BACKPACK_CAPACITY = 100;
        public Backpack() : base(BACKPACK_CAPACITY)
        {
        }
    }
}
