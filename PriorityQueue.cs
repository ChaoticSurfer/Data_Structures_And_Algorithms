using System;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {12, 11, 13, 5, 6, 7, 77, 77, 3, 5, 3, 2, 2, 111, 6666, 3, 54};
            var pq = new PriorityQueue<int>();
            foreach (var i in arr)
            {
                pq.Add(i);
            }


            Console.WriteLine();
            foreach (var _ in arr)
            {
                Console.Write($"{pq.RemoveMax().ToString()} ");
            }
        }


        class PriorityQueue<T> where T : IComparable
        {
            // max heap
            private int n_lastIndex;
            private T[] _array;

            public PriorityQueue(T[] array)
            {
                this.n_lastIndex = array.Length - 1;
                this._array = array;
            }

            public PriorityQueue(int n)
            {
                _array = new T[n + 1];
            }

            public PriorityQueue() : this(16)
            {
            }

            public bool isEmpty()
            {
                return n_lastIndex == 0;
            }

            private bool isFull()
            {
                return _array.Length - 1 == n_lastIndex;
            }

            public void DoubleArraySize()
            {
                var arr = new T[n_lastIndex * 2];
                Array.Copy(_array, 1, arr, 1, n_lastIndex - 1);
                _array = arr;
            }


            private void Swim(int k)
            {
                while (k > 1 && less(_array[k / 2], _array[k]))
                {
                    int j = k / 2;
                    swap(_array, k, j);
                    k = j;
                }
            }

            private void Sink(int k)
            {
                while (k * 2 <= n_lastIndex)
                {
                    int j = k * 2;
                    if (less(_array[j], _array[j + 1])) ++j; // bigger child index = j
                    if (less(_array[j], _array[k])) return;
                    swap(_array, k, j);
                    k = j;
                }
            }


            public void Add(T elem)
            {
                if (isFull())
                {
                    DoubleArraySize();
                }

                _array[++n_lastIndex] = elem;
                Swim(n_lastIndex);
            }

            public T RemoveMax()
            {
                if (isEmpty())
                {
                    throw new Exception("Empty Priority Queue");
                }
                
                T max = _array[1];
                swap(_array, 1, n_lastIndex);
                // _array[n_lastIndex--] = null;
                --n_lastIndex;
                Sink(1);
                return max;
            }

            private static void swap(T[] array, int i, int j)
            {
                if (i == j) return;

                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            private static bool less(T i, T j)
            {
                return i.CompareTo(j) == -1;
            }
        }
    }
}
