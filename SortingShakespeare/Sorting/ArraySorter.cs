    using System;
    using System.Diagnostics;

    namespace Sorting
    {
        public class ArraySorter<T> where T : IComparable<T>
        {
            private readonly T[] _queue;
            private int _heapSize;
            private bool _isSortedAscending;

            // Max size of the entire tree
            private readonly int _maxHeapSize;


            public ArraySorter(T[] items, int heapSize)
            {
                _queue = new T[heapSize];
                _heapSize = items.Length;
                _maxHeapSize = heapSize;
                // Copy contents of items array to the queue.
                for (var i = 0; i < items.Length; i++) _queue[i] = items[i];
            }

            public void SortAscending()
            {
                Sort((x, y) => x.CompareTo(y) > 0);
            }

            public void SortDescending()
            {
                
                Sort((x,y) => x.CompareTo(y) < 0);
            }
            

            /// <summary>
            /// Heapsort using a lambda expression. Example: arraySorter.Sort((x,y) => x.compareTo(y) > 0); for an ascending sort
            /// </summary>
            /// <param name="lambda">A lambda expression with 2 types T and should return a bool</param>
            public void Sort(Func<T, T, bool> lambda)
            {
                var length = _heapSize;
                BuildHeap(lambda);

                for (var i = length - 1; i >= 0; i--)
                {
                    // Move current root to end 
                    Exchange(_queue, 0, i);

                    // call heapify on the reduced heap 
                    Heapify(_queue, i, 0, lambda);
                }
                // Get the sorting order by comparing root to the last element
                _isSortedAscending = _queue[0].CompareTo(_queue[_heapSize - 1]) < 0;
            }

            private void BuildHeap(Func<T, T, bool> lambda)
            {
                for (var i = _heapSize / 2 - 1; i >= 0; i--)
                {
                    Heapify(_queue, _heapSize, i, lambda);
                }
            }


            /// <summary>
            /// Heapifies using a lambda expression to compare children
            /// </summary>
            /// <param name="arr">Array to heapify</param>
            /// <param name="size">Size of heap</param>
            /// <param name="i">Current index</param>
            /// <param name="lambda">Lambda expression to compare children</param>
            private void Heapify(T[] arr, int size, int i, Func<T, T, bool> lambda)
            {
                
                var parent = i;
                var leftChild = i * 2 + 1;
                var rightChild = i * 2 + 2;

                if (leftChild < size && lambda(arr[leftChild], arr[parent])) parent = leftChild;
                if (rightChild < size && lambda(arr[rightChild], arr[parent])) parent = rightChild;
                if (parent != i)
                {
                    Exchange(arr, i, parent);
                    Heapify(arr, size, parent, lambda);
                }
            }

            /// <summary>
            /// Insert an item into the queue
            /// </summary>
            /// <param name="item">Item to be inserted</param>
            /// <exception cref="Exception">Throws exception if queue is full</exception>
            public void Enqueue(T item)
            {
                if (_heapSize == _maxHeapSize) throw new Exception("Queue is full!");
                _queue[_heapSize++] = item;

                if (_isSortedAscending)
                    BuildHeap((x, y) => x.CompareTo(y) < 0);
                else
                {
                    BuildHeap((x, y) => x.CompareTo(y) > 0);
                }
            }

            /// <summary>
            /// Dequeue the root of the tree
            /// </summary>
            /// <returns>Value of type T</returns>
            /// <exception cref="Exception">Throws exception if the queue is empty</exception>
            public T Dequeue()
            {
                if (_heapSize == 0)
                    throw new Exception("Queue is empty, can't dequeue.");
                var root = _queue[0];
                // Move last element to the root
                _queue[0] = _queue[--_heapSize];
                _queue[_heapSize] = default;

                if(_isSortedAscending)
                    BuildHeap((x, y) => x.CompareTo(y) < 0);
                else
                {
                    BuildHeap((x, y) => x.CompareTo(y) > 0);
                }
                return root;
            }

            /// <summary>
            /// Switches the index of 2 values
            /// </summary>
            /// <param name="arr">Array in which the switch should take place</param>
            /// <param name="firstIndex"></param>
            /// <param name="secondIndex"></param>
            private void Exchange(T[] arr, int firstIndex, int secondIndex)
            {
                var temp = arr[firstIndex];
                arr[firstIndex] = arr[secondIndex];
                arr[secondIndex] = temp;
            }
        }
    }