using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Sorting
{
    //Top down merge sort
    public class Merge
    {
        private static IComparable[] _aux;

        /// <summary>
        /// Copies array a into auxiliary array
        /// </summary>
        /// <param name="arr">An array of objects implementing the IComparable interface</param>
        public static void Sort(IComparable[] arr)
        {
            _aux = new IComparable[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }
        /// <summary>
        /// Sort an array by first sorting the left half, then the right half, and finally merging the two into a single array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private static void Sort(IComparable[] arr, int low, int high)
        {
            // When the array is sorted jump out of the recursion loop
            if (high <= low) return;
            var mid = low + (high - low) / 2;
            Sort(arr, low, mid); // sort left half
            Sort(arr, mid + 1, high); // sort right half
            MergeArray(arr, low, mid, high); // merge arrays
        }

        /// <summary>
        /// This method merges by first copying into the auxiliary array aux[] then merging back to a[] . In the
        /// merge (the second for loop), there are four conditions: left half exhausted (take from the right), right
        /// half exhausted (take from the left), current key on right less than current key on left (take from the
        /// right), and current key on right greater than or equal to current key on left (take from the left).
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        private static void MergeArray(IComparable[] arr, in int low, in int mid, in int high)
        {
            int i = low, j = mid + 1;
            for (var k = low; k <= high; k++) // Copy array to auxiliary array
            {
                _aux[k] = arr[k];
            }

            for (var k = low; k <= high; k++)
            {
                if (i > mid) arr[k] = _aux[j++]; // If left half is exhausted take from the right
                else if (j > high) arr[k] = _aux[i++]; // if right half is exhausted take from the left
                else if (Less(_aux[j], _aux[i])) arr[k] = _aux[j++]; // current key on the right less than current key on the left, take from right
                else arr[k] = arr[i++]; // current key on the right >= current key on the left, take from the left
            }
        }

        /// <summary>
        /// Check if v is less than w
        /// </summary>
        /// <param name="a">The first value to compare</param>
        /// <param name="b">The second value to compare</param>
        /// <returns>Returns <c>true</c> if v is smaller than w else <c>false</c></returns>
        private static bool Less(IComparable a, IComparable b)
        {
            return a.CompareTo(b) < 0;
        }

        /// <summary>
        /// Swap index of values at position i and j
        /// </summary>
        /// <param name="arr">The array in which i and j are contained</param>
        /// <param name="i">The first value with the index to be swapped</param>
        /// <param name="j">The second value with the index to be swapped</param>
        private static void Exch(IComparable[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /// <summary>
        /// Prints the contents of an array
        /// </summary>
        /// <param name="arr">The array of the contents that should be printed</param>
        internal static void Show(IComparable[] arr)
        {
            foreach (var t in arr)
            {
                Console.Write(t + " ");
            }
        }

        /// <summary>
        /// Check if the array is sorted
        /// </summary>
        /// <param name="arr">The array which you want to check if it is sorted</param>
        /// <returns>Return <c>true</c> if the array is sorted otherwise <c>false</c></returns>
        internal static bool IsSorted(IComparable[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                if (Less(arr[i], arr[i - 1])) return false;
            }

            return true;
        }
    }
}