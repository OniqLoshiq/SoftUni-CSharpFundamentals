using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EnteringObject> objects = new List<EnteringObject>();

            GetObjects(objects);
            PrintDetainedObjects(objects);
        }

        private static void PrintDetainedObjects(List<EnteringObject> objects)
        {
            string fakeEndIds = Console.ReadLine();
            objects.Where(x => x.Id.EndsWith(fakeEndIds)).ToList().ForEach(x => Console.WriteLine(x.Id));
        }

        private static void GetObjects(List<EnteringObject> objects)
        {
            string objectData = String.Empty;

            while((objectData = Console.ReadLine()) != "End")
            {
                string[] tokens = objectData.Split();

                if(tokens.Length == 3)
                {
                    objects.Add(new Person(tokens[0], tokens[2], int.Parse(tokens[1])));
                }
                else
                {
                    objects.Add(new Robot(tokens[0], tokens[1]));
                }
            }
        }
    }
}
