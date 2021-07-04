using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {12, 11, 13, 5, 6, 7, 77,77,3, 5, 3, 2, 2, 111, 6666, 3, 54};
            printArray(arr);
            Quick.Sort(arr);
            printArray(arr);
            
            // quickSort implemented using three way partition, works well for array with duplicate keys,
            // while using old implementation it will take N^2 time average and quicksort loses its effectiveness.
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
        private static int CUT_OFF = 10;

        public static void Sort<T>(T[] array) where T : IComparable
        {
            KnuthShuffle(array);
            Quick.Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int lo, int hi) where T : IComparable
        {
            if (hi - lo > CUT_OFF) Insertion.Sort(array); // cut off for small sub arrays

            if (hi <= lo)
                return;

            // Three way partition

            int i = lo;
            T v = array[lo];
            int gt = hi;
            int lt = lo;

            while (i <= gt)
            {
                int cmp = array[i].CompareTo(v);
                if (cmp == -1)
                    swap(array, i++, lt++);

                else if (cmp == 1)
                    swap(array, i, gt--);

                else ++i;
            }

            Sort(array, lo, lt - 1);
            Sort(array, gt + 1, hi);
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

    static class Insertion
    {
        public static T[] Sort<T>(T[] array) where T : System.IComparable
        {
            int n = array.Length;

            for (int i = 1; i < n; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1].CompareTo(array[j]) == 1)
                {
                    swap(array, j, j - 1);
                    --j;
                }
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
