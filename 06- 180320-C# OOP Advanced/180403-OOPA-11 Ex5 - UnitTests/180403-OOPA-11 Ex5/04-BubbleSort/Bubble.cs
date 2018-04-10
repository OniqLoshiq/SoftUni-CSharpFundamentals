using System;

namespace _04_BubbleSort
{
    public class Bubble
    {
        public int[] BubbleSort(int[] arr)
        {
            int temp;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int y = 0; y < arr.Length - 1; y++)
                {
                    if(arr[y] > arr[y + 1])
                    {
                        temp = arr[y + 1];
                        arr[y + 1] = arr[y];
                        arr[y] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
