using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        try
        {
            GetPeopleData(people);
            GetProductsData(products);

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd.Split();
                string personName = cmdArgs[0];
                string productName = cmdArgs[1];

                Person thisPerson = people.FirstOrDefault(p => p.Name == personName);
                Product thisProduct = products.FirstOrDefault(p => p.Name == productName);
                
                thisPerson.AddProductToBag(thisProduct);
            }

            people.ForEach(p => Console.WriteLine(p));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void GetProductsData(List<Product> products)
    {
        string[] productsInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < productsInput.Length; i++)
        {
            string productName = productsInput[i].Substring(0, productsInput[i].IndexOf('='));
            decimal productCost = decimal.Parse(productsInput[i].Substring(productsInput[i].IndexOf('=') + 1));

            Product newProduct = new Product(productName, productCost);
            products.Add(newProduct);
        } 
    }

    private static void GetPeopleData(List<Person> people)
    {
        string[] peopleInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < peopleInput.Length; i++)
        {
            string personName = peopleInput[i].Substring(0, peopleInput[i].IndexOf('='));
            decimal personMoney = decimal.Parse(peopleInput[i].Substring(peopleInput[i].IndexOf('=') + 1));

            Person newPerson = new Person(personName, personMoney);
            people.Add(newPerson);
        }
    }
}
