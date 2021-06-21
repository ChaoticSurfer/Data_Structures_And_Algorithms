using System;
using System.Collections.Generic;


namespace ConsoleAppTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Shell.Sort(new int[] {4, 2, 5, 9, 666, 91, 7, 11});
            foreach (var elem in arr)
            {
                Console.Write($"{elem} ");
            }
        }


        public class Shell
        {
            public static T[] Sort<T>(T[] array) where T : System.IComparable<T>
            {
                int n = array.Length;
                var stack = new Stack<int>();
                for (int h = 1; h < n; h = 3 * h + 1) // or X*X - 1      x = 1 2 3 4...
                {
                    stack.Push(h);
                }


                foreach (var h in stack)
                {
                    for (int i = h; i < n; i += h)
                    {
                        int j = i;
                        while ((j - h) >= 0 && array[j - h].CompareTo(array[j]) == 1)
                        {
                            swap(array, j, j - h);
                            j -= h;
                        }
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

            private static void swapNums(int[] array, int i, int j)
            {
                if (i == j) return;
                array[i] ^= array[j];
                array[j] ^= array[i];
                array[i] ^= array[j];
            }
        }
    }
}
