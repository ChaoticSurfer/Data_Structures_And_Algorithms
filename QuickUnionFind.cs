using System;

namespace AlgoTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var unionFind = new QuickUnion(10);
            unionFind.Union(1, 2);
            unionFind.Union(3, 4);
            unionFind.Union(1, 4);
            Console.WriteLine(unionFind.Connected(2, 3));
            // near linear Connection check. 
        }
    }

    class QuickUnion
    {
        private int[] id;
        private int[] size;

        public QuickUnion(int N)
        {
            size = new int[N];
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                size[i] = 1;
            }
        }

        public bool Connected(int i, int j)
        {
            return FindRoot(i) == FindRoot(j);
        }

        public void Union(int i, int j)
        {
            if (size[i]> size[j])
                id[FindRoot(j)] = FindRoot(i);
            else
            {
                id[FindRoot(i)] = FindRoot(j);
            }
        }

        public int FindRoot(int i)
        {
            while (id[i] != i)
            {            
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }
    }
}
