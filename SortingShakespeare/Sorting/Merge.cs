using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Sorting
{
    //Top down merge sort
    public class Merge
    {
        private static IComparable[] aux;

        /// <summary>
        /// Copies array a into auxiliary array
        /// </summary>
        /// <param name="arr">An array of objects implementing the IComparable interface</param>
        public static void Sort(IComparable[] arr)
        {
            aux = new IComparable[arr.Length];
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
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        private static void MergeArray(IComparable[] a, in int low, in int mid, in int high)
        {
            int i = low, j = mid + 1;
            for (var k = low; k <= high; k++) // Copy array to auxiliary array
            {
                aux[k] = a[k];
            }

            for (var k = low; k <= high; k++)
            {
                if (i > mid) a[k] = aux[j++]; // If left half is exhausted take from the right
                else if (j > high) a[k] = aux[i++]; // if right half is exhausted take from the left
                else if (Less(aux[j], aux[i])) a[k] = aux[j++]; // current key on the right less than current key on the left, take from right
                else a[k] = a[i++]; // current key on the right >= current key on the left, take from the left
            }
        }

        /// <summary>
        /// Check if v is less than w
        /// </summary>
        /// <param name="v">The first value to compare</param>
        /// <param name="w">The second value to compare</param>
        /// <returns>Returns <c>true</c> if v is smaller than w else <c>false</c></returns>
        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// Swap index of values at position i and j
        /// </summary>
        /// <param name="a">The array in which i and j are contained</param>
        /// <param name="i">The first value with the index to be swapped</param>
        /// <param name="j">The second value with the index to be swapped</param>
        private static void Exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        /// <summary>
        /// Prints the contents of an array
        /// </summary>
        /// <param name="a">The array of the contents that should be printed</param>
        internal static void Show(IComparable[] a)
        {
            foreach (var t in a)
            {
                Console.Write(t + " ");
            }
        }

        /// <summary>
        /// Check if the array is sorted
        /// </summary>
        /// <param name="a">The array which you want to check if it is sorted</param>
        /// <returns>Return <c>true</c> if the array is sorted otherwise <c>false</c></returns>
        internal static bool IsSorted(IComparable[] a)
        {
            for (var i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }

            return true;
        }
    }
}