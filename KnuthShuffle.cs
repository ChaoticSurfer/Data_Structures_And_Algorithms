using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        // uniformly random shuffle algorithm
        
            var arr = new[] {12, 11, 13, 5, 6, 7};
            printArray(arr);
            KnuthShuffle(arr);
            printArray(arr);
        }



        public static T[] KnuthShuffle<T>(T[] array)
        {
            var random = new Random();
            var n = array.Length;
            for (int i = 0; i < n; i++)
            {
                var randomNumber = random.Next(0, n + 1);
                swap(array, i, randomNumber);
            }

            return array;
        }
        
        // UTILITY FUNCTIONS
        public static void printArray(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
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
