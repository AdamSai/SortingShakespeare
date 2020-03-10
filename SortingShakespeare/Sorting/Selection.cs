using System;
using System.Diagnostics;

namespace Sorting
{
    public class Selection
    {
        /// <summary>
        /// Sorts an array by setting the current value as the min value, then iterating through the array
        /// and comparing if any numbers are smaller than the min value. If a smaller number is found
        /// it is moved to the current position.
        /// </summary>
        /// <param name="a">An array of objects implementing the IComparable interface</param>
        public static void Sort(IComparable[] a)
        {
            var N = a.Length;
            for (var i = 0; i < N; i++)
            {
                // Find the smallest value in the array and replace a[i] with said value
                var min = i;
                for (var j = i + 1 ; j < N; j++)
                {
                    if (Less(a[j], a[min])) min = j;
                }
                Exch(a, i, min);
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