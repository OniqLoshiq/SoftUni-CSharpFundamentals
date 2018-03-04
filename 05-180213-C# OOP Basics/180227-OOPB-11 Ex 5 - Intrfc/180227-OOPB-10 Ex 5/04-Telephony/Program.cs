using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> sites = Console.ReadLine().Split().ToList();

            var smartphone = new Smartphone();
            numbers.ForEach(x => 
            {
                try
                {
                    Console.WriteLine(smartphone.Calling(x));
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            );
            sites.ForEach(x =>
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(x));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            );
        }
    }
}
