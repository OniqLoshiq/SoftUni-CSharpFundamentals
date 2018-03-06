public static class FoodFactory
{
    public static Food ProduceFood(string[] foodData)
    {
        Food food = null;

        string foodType = foodData[0];
        int foodQuantity = int.Parse(foodData[1]);

        switch (foodType)
        {
            case "Vegetable": food = new Vegetable(foodQuantity); break;
            case "Fruit": food = new Fruit(foodQuantity); break;
            case "Meat": food = new Meat(foodQuantity); break;
            case "Seeds": food = new Seeds(foodQuantity); break;

            default:
                break;
        }

        return food;
    }
}
