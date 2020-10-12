using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GenericStackTask
{
    /// <summary>
    /// Represents extendable last-in-first-out (LIFO) collection of the specified type T.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Initializes a new instance of the stack class that is empty and has the default initial capacity.
        /// </summary>
        private const int DefaultSize = 100;

        private T[] _arr;
        private int _index;
        private int _version;

        public Stack()
        {
            _arr = new T[DefaultSize];
            _version = 0;
            _index = -1;
        }

        /// <summary>
        /// Initializes a new instance of the stack class that is empty and has
        /// the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements of stack.</param>
        public Stack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "capacity out of range");
            }

            _arr = new T[capacity];
            _version = 0;
            _index = -1;
        }

        /// <summary>
        /// Initializes a new instance of the stack class that contains elements copied
        /// from the specified collection and has sufficient capacity to accommodate the
        /// number of elements copied.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public Stack(IEnumerable<T> collection)
        {
            _version = 0;

            if (collection == null)
                throw new ArgumentNullException(nameof(collection), "collection is null ");

            _arr = collection.ToArray();
            _index = _arr.Length - 1;
        }

        // public Stack

        /// <summary>
        /// Gets the number of elements contained in the stack.
        /// </summary>
        public int Count => _index + 1;


        /// <summary>
        /// Removes and returns the object at the top of the stack.
        /// </summary>
        /// <returns>The object removed from the top of the stack.</returns>
        public T Pop()
        {
            _version++;
            if (_index == -1)
            {
                throw new InvalidOperationException("Invalid operation pop, stack is empty.");
            }

            return _arr[_index--];
        }

        /// <summary>
        /// Returns the object at the top of the stack without removing it.
        /// </summary>
        /// <returns>The object at the top of the stack.</returns>
        public T Peek()
        {
            if (_index <= -1)
            {
                throw new InvalidOperationException("Nothing to see.");
            }

            return _arr[_index];
        }

        /// <summary>
        /// Inserts an object at the top of the stack.
        /// </summary>
        /// <param name="item">The object to push onto the stack.
        /// The value can be null for reference types.</param>
        public void Push(T item)
        {
            _version++;
            if (Count >= _arr.Length)
            {
                var n_arr = new T[(_arr.Length + 1) * 2];
                Array.Copy(_arr, n_arr, _arr.Length);
                _arr = n_arr;
                // Array.Resize(ref _arr, _arr.Length * 2);
            }

            _arr[++_index] = item;
        }

        /// <summary>
        /// Copies the elements of stack to a new array.
        /// </summary>
        /// <returns>A new array containing copies of the elements of the stack.</returns>
        public T[] ToArray()
        {
            var res = new T[Count];
            Array.Copy(_arr, res, Count);
            return res;
        }

        /// <summary>
        /// Determines whether an element is in the stack.
        /// </summary>
        /// <param name="item">The object to locate in the stack. The value can be null for reference types.</param>
        /// <returns>Return true if item is found in the stack; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return Count != 0 && Array.LastIndexOf(_arr, item, _index) != -1;
        }

        /// <summary>
        /// Removes all objects from the stack.
        /// </summary>
        public void Clear()
        {
            _version++;
            _arr = new T[_arr.Length];
            Array.Clear(_arr, 0, _arr.Length);
            _index = -1;
        }


        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator : IEnumerator<T>
        {
            private readonly int version;
            private Stack<T> __stack;

            private int indexForEnumerator;


            internal Enumerator(Stack<T> stack)
            {
                __stack = stack;
                version = __stack._version;

                indexForEnumerator = __stack.Count;
            }

            public bool MoveNext()
            {
                if (version != __stack._version)
                {
                    throw new InvalidOperationException("Stack cannot be changed during iteration.");
                }

                indexForEnumerator--;

                if (indexForEnumerator < 0)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                if (version != __stack._version)
                {
                    throw new InvalidOperationException("Stack cannot be changed during iteration.");
                }

                indexForEnumerator = __stack.Count;
            }


            public T Current
            {
                get
                {
                    return __stack._arr[indexForEnumerator];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return __stack._arr[indexForEnumerator];
                }
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
