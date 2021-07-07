using System;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {12, 11, 13, 5, 6, 7, 77, 9};
            Heap.Sort(arr);
            PrintArray(arr);
        }


        public static void PrintArray<T>(T[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i.ToString()} ");
            }

            Console.WriteLine();
        }


        public static class Heap
        {
            // max heap
            public static void Sort<T>(T[] array) where T : IComparable
            {
                // build heap starting from 0
                int n = array.Length;
                for (int i = GetParentIndex(n - 1); i >= 0; i -= 1)
                {
                    Sink(array, i, n);
                }



                // sort
                while (n > 1)
                {
                    swap(array, n - 1, 0);
                    Sink(array, 0, --n);
                }
            }


            private static void Sink<T>(T[] array, int k, int n) where T : IComparable
            {
                while (GetLeftChildIndex(k) < n)
                {
                    int j = GetLeftChildIndex(k);
                    if (j + 1 < n)
                        if (less(array, j, j + 1))
                            ++j; // bigger child index = j
                    if (less(array, j, k)) return;
                    swap(array, k, j);
                    k = j;
                }
            }


            private static void swap<T>(T[] array, int i, int j)
            {
                if (i == j) return;

                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            private static bool less<T>(T[] array, int i, int j) where T : IComparable
            {
                return array[i].CompareTo(array[j]) == -1;
            }

            public static int GetParentIndex(int i)
            {
                return (i + 1) / 2 - 1;
            }

            public static int GetLeftChildIndex(int i)
            {
                return GetRightChildIndex(i) - 1;
            }

            public static int GetRightChildIndex(int i)
            {
                return (i + 1) * 2;
            }
        }
    }
}
