using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            AddElementsToCollections(addCollection, addRemoveCollection, myList);
            RemoveElementsFromCollections(addRemoveCollection, myList);
        }

        private static void RemoveElementsFromCollections(AddRemoveCollection addRemoveCollection, MyList myList)
        {
            int elementsToRemove = int.Parse(Console.ReadLine());

            RemoveElements(addRemoveCollection, elementsToRemove);
            RemoveElements(myList, elementsToRemove);
        }

        private static void RemoveElements(IAddRemoveCollection collection, int elementsToRemove)
        {
            List<string> output = new List<string>(elementsToRemove);

            for (int i = 0; i < elementsToRemove; i++)
            {
                output.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", output));
        }

        private static void AddElementsToCollections(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList)
        {
            List<string> data = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            AddElements(addCollection, data);
            AddElements(addRemoveCollection, data);
            AddElements(myList, data);
        }

        private static void AddElements(IAddCollection collection, List<string> data)
        {
            List<int> output = new List<int>(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                output.Add(collection.Add(data[i]));
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
