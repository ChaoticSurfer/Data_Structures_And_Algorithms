class RingBuffer<T> : IEnumerable<T>
        {
            T[] _arr;
            private int defaultSize = 20;
            private int count = 0;
            int startIndex = 0;

            public RingBuffer()
            {
                _arr = new T[defaultSize];
            }

            public RingBuffer(int size)
            {
                _arr = new T[size];
            }

            public RingBuffer(T[] array)
            {
                _arr = array;
                count = array.Length;
            }

            public RingBuffer(T[] array, int size)
            {
                _arr = new T[size];
                Array.Copy(array, _arr, array.Length);
                count = array.Length;
            }

            T[] ToArray()
            {
                var sh = new T[count];
                for (int i = 0; i < count; i++)
                {
                    sh[i] = _arr[i];
                }
                return sh;
            }

            List<T> ToList()
            {
                return ToArray().ToList();
            }

            public int GetCount => count;
            public bool IsEmpty => count == 0;
            public bool IsFull => count == _arr.Length;

            public void Clear()
            {
                Array.Clear(_arr, 0, count);
            }

            private void RightShift1Less()
            {
                for (int i = count - 1; i > startIndex; i--)
                {
                    _arr[i] = _arr[i - 1];
                }
            }

            private void LeftShift1Less()
            {
                for (int i = startIndex; i < count - 1; i++)
                {
                    _arr[i] = _arr[i + 1];
                }
            }

            public void PushBack(T value)
            {
                if (IsFull)
                {
                    return;
                }

                _arr[count++] = value;
            }

            public void pushFront(T value)
            {
                if (IsFull)
                {
                    return;
                }

                RightShift1Less();
                _arr[startIndex] = value;
                count++;
            }


            public T PopBack()
            {
                if (IsEmpty)
                {
                    throw new ArgumentException("poping while empty");
                }

                T PopedValue = _arr[count - 1];
                RightShift1Less();
                _arr[startIndex] = PopedValue;

                return PopedValue;
            }

            public T PopFront()
            {
                if (IsEmpty)
                {
                    throw new ArgumentException("poping while empty");
                }
            
                T PopedValue = _arr[startIndex];
                LeftShift1Less();
                _arr[count - 1] = PopedValue;
                return PopedValue;
            }

            public void Print()
            {
                foreach (var x1 in _arr)
                {
                    Console.Write($"{x1} ");
                }

                Console.WriteLine();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return ToArray().Cast<T>().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ToArray().GetEnumerator();
            }
        }
