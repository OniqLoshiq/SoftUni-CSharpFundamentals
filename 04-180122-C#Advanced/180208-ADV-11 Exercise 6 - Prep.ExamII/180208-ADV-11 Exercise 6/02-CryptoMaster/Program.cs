using System;
using System.Linq;

namespace _02_CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxSeq = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int currentIndex = i;
                    int nextIndex = (i + step) % numbers.Length;
                    int currentSeq = 1;

                    while(numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentSeq++;
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                    }

                    if (maxSeq < currentSeq)
                        maxSeq = currentSeq;
                }
            }

            Console.WriteLine(maxSeq);
        }
    }
}
