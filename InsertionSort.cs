using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Insertion.Sort(new int[] {1, 25, 5, 5, 5, 3, 4,});

            foreach (var VARIABLE in arr)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        static class Insertion
        {
            public static T[] Sort<T>(T[] array) where T : System.IComparable<T>
            {
                int n = array.Length;

                for (int i = 1; i < n; i++)
                {
                    int j = i;
                    while (j > 0 && array[j - 1].CompareTo(array[j]) == 1)
                    {
                        swap(array, j, j-1);
                        --j;
                    }
                }
                return array;

            }
        }

        private static void swap<T>(T[] array, int i, int j)
        {
            if (i == j) return;
            T temp;
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void swapNums(int[] array, int i, int j)
        {
            if (i == j) return;
            array[i] ^= array[j];
            array[j] ^= array[i];
            array[i] ^= array[j];
        }
    }
}

