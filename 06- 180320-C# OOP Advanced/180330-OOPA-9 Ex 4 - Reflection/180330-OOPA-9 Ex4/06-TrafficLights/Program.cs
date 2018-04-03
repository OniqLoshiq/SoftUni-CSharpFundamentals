using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            Light[] input = Console.ReadLine().Split().Select(l => (Light)Enum.Parse(typeof(Light),l)).ToArray();
            List<ITrafficLight> trafficLights = new List<ITrafficLight>(input.Length);

            foreach (var light in input)
            {
                trafficLights.Add(new TrafficLight(light));
            }

            int trafficLightCycles = int.Parse(Console.ReadLine());

            for (int i = 0; i < trafficLightCycles; i++)
            {
                trafficLights.ForEach(tl => tl.ChangeLight());
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
