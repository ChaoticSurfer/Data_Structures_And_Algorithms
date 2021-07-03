using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {12, 11, 13, 5, 6, 7};
            printArray(arr);
            Quick.Sort(arr);
            printArray(arr);
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
            if (hi - lo > CUT_OFF) Insertion.Sort(array);// cut off for small sub arrays
            
            if (hi <= lo)
                return;
            int j = Partition(array, lo, hi);
            Sort(array, lo, j - 1);
            Sort(array, j + 1, hi);
        }

        // UTILITY FUNCTIONS

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


                while (less(v, array[--j])) ;
                // if (j == lo)
                //     break;

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
