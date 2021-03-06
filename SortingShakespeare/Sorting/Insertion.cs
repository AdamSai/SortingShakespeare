using System;
using System.Diagnostics;

namespace Sorting
{
    /// <summary>
    /// This class is used for Selection sorting.
    /// </summary>
    public class Insertion
    {
        /// <summary>
        /// Iterates through the array and checks if the current j value is smaller than the current i value 
        /// if it is, switch the positions of the two. This ensures that the array is always sorted on the left side.
        /// </summary>
        /// <param name="arr">An array of objects implementing the IComparable interface</param>
        public static void Sort(IComparable[] arr)
        {
            var N = arr.Length;
            for (var i = 1; i < N; i++)
            {
                for (var j = i ; j > 0 && Less(arr[j], arr[j - 1]); j--)
                {
                    Exch(arr, j, j-1);
                }
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
        public static void Show(IComparable[] arr)
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