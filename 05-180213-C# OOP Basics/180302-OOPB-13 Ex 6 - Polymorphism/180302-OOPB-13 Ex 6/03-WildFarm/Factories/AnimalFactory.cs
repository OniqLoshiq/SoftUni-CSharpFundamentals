public static class AnimalFactory
{
    public static Animal ProduceAnimal(string[] animalTokens)
    {
        Animal animal = null;

        string animalType = animalTokens[0];
        string name = animalTokens[1];
        double weight = double.Parse(animalTokens[2]);

        switch (animalType)
        {
            case "Owl": animal = new Owl(name, weight, double.Parse(animalTokens[3])); break;
            case "Hen": animal = new Hen(name, weight, double.Parse(animalTokens[3])); break;
            case "Mouse": animal = new Mouse(name, weight, animalTokens[3]); break;
            case "Dog": animal = new Dog(name, weight, animalTokens[3]); break;
            case "Cat": animal = new Cat(name, weight, animalTokens[3], animalTokens[4]); break;
            case "Tiger": animal = new Tiger(name, weight, animalTokens[3], animalTokens[4]); break;

            default:
                break;
        }

        return animal;
    }
}
