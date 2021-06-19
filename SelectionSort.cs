using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Selection.Sort(new int[] {1, 25, 5, 5, 5, 3, 4,});

            foreach (var VARIABLE in arr)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        static class Selection
        {
            public static T[] Sort<T>(T[] array) where T: System.IComparable<T>
            {
                int n = array.Length;


                for (int index = 0; index < n; index++)
                {
                    T minValue = array[index];
                    int minIndex = index;

                    for (int i = index; i < n; i++)
                    {
                        if (minValue.CompareTo(array[i]) == 1)
                        {
                            minIndex = i;
                            minValue = array[i];
                        }
                    }
                    swap(array, index, minIndex);
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
