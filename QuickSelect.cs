using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
        // Select N th smallest element from the array.
            // Theta(N) , O(N^2) but there is probabilistic guarantee that it will not happen. consumes constant additional memory.
            var arr = new[] {12, 11, 13, 5, 6, 7, 77, 77, 3, 5, 3, 2, 2, 111, 6666, 3, 54};
            printArray(arr);
            Console.WriteLine(Quick.SelectNth(arr, 2));
        }

        public static void printArray(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }

    public static class Quick
    {
        public static T SelectNth<T>(T[] array, int n) where T : IComparable
        {
            KnuthShuffle(array);
            int high = array.Length - 1;
            int low = 0;
            int k = Partition(array, low, high);
            while (k != n)
            {
                if (less(k, n))
                {
                    low = k + 1;
                }
                else
                {
                    high = k - 1;
                }

                k = Partition(array, low, high);
            }

            return array[k];
        }

        public static int Partition<T>(T[] array, int lo, int hi) where T : IComparable
        {
            int i = lo;

            int j = hi + 1;
            var v = array[lo];
            while (true)
            {
                while (less(array[++i], v))
                    if (i == hi)
                        break;


                while (less(v, array[--j]))
                    if (j == lo)
                        break;

                if (i >= j)
                    break;

                swap(array, i, j);
            }

            swap(array, j, lo);

            // now, a[lo .. j-1] <= a[j] <= a[j+1 .. hi]
            return j;
        }


        private static bool less(IComparable i, IComparable j)
        {
            return i.CompareTo(j) == -1;
        }

        private static T[] KnuthShuffle<T>(T[] array)
        {
            var random = new Random();
            var n = array.Length;
            for (int i = 0; i < n; i++)
            {
                var randomNumber = random.Next(0, n);
                swap(array, i, randomNumber);
            }

            return array;
        }

        private static void swap<T>(T[] array, int i, int j)
        {
            if (i == j) return;

            T temp;
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
