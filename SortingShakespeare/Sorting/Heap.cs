    using System;
    using System.Diagnostics;

    namespace Sorting
    {
        public class ArraySorter<T> where T : IComparable<T>
        {
            private static bool _isSortedAscending;
            public static void SortAscending(T[] items)
            {
                Sort(items, (x, y) => x.CompareTo(y) > 0);
            }

            public static void SortDescending(T[] items)
            {
                
                Sort(items, (x,y) => x.CompareTo(y) < 0);
            }
            

            /// <summary>
            /// Heapsort using a lambda expression. Example: arraySorter.Sort((x,y) => x.compareTo(y) > 0); for an ascending sort
            /// </summary>
            /// <param name="lambda">A lambda expression with 2 types T and should return a bool</param>
            public static void Sort(T[] items, Func<T, T, bool> lambda)
            {
                var length = items.Length;
                BuildHeap(items, lambda);

                for (var i = length - 1; i >= 0; i--)
                {
                    // Move current root to end 
                    Exchange(items, 0, i);

                    // call heapify on the reduced heap 
                    Heapify(items, i, 0, lambda);
                }
                // Get the sorting order by comparing root to the last element
                _isSortedAscending = items[0].CompareTo(items[length - 1]) < 0;
            }

            private static void BuildHeap(T[] items, Func<T, T, bool> lambda)
            {
                for (var i = items.Length / 2 - 1; i >= 0; i--)
                {
                    Heapify(items, items.Length, i, lambda);
                }
            }


            /// <summary>
            /// Heapifies using a lambda expression to compare children
            /// </summary>
            /// <param name="arr">Array to heapify</param>
            /// <param name="size">Size of heap</param>
            /// <param name="i">Current index</param>
            /// <param name="lambda">Lambda expression to compare children</param>
            private static void Heapify(T[] arr, int size, int i, Func<T, T, bool> lambda)
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
            /// Switches the index of 2 values
            /// </summary>
            /// <param name="arr">Array in which the switch should take place</param>
            /// <param name="firstIndex"></param>
            /// <param name="secondIndex"></param>
            private static void Exchange(T[] arr, int firstIndex, int secondIndex)
            {
                var temp = arr[firstIndex];
                arr[firstIndex] = arr[secondIndex];
                arr[secondIndex] = temp;
            }
        }
    }