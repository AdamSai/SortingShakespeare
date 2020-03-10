using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Shakespeare;
using Sorting;

namespace SortingShakespeare
{
    class Program
    {
        static void Main(string[] args)
        {
            var textProcessor = new TextProcessor();
            var regexPattern = @"[a-zA-ZæøåÆØÅ]+'?-?[a-zA-ZæøåÆØÅ]*";
            textProcessor.ProcessTextFile(@"..\..\..\shakespeare-complete-works.txt", regexPattern);
            var dataLength = textProcessor.ProcessedStrings.Length;
            
            var stopwatch = Stopwatch.StartNew();
            
            
            #region Selection Sort
            
            // Take the first 10.000 elements from the original array
            var sampleData = textProcessor.ProcessedStrings.Take(10000).ToArray();
            Selection.Sort(sampleData);
            stopwatch.Stop();
            PrintElapsedTime(sampleData.Length, stopwatch.ElapsedMilliseconds, "Selection Sort");
            
            #endregion
            
            #region Insertion sort
            
            sampleData = textProcessor.ProcessedStrings.Take(10000).ToArray();
            stopwatch = Stopwatch.StartNew();
            Insertion.Sort(sampleData);
            stopwatch.Stop();
            PrintElapsedTime(sampleData.Length, stopwatch.ElapsedMilliseconds, "Insertion Sort");
            
            #endregion
            

            
            
            #region Merge Sort
            
            stopwatch = Stopwatch.StartNew();
            Merge.Sort(textProcessor.ProcessedStrings);
            stopwatch.Stop();
            PrintElapsedTime(dataLength, stopwatch.ElapsedMilliseconds, "Merge Sort");
            
            #endregion


            #region Heap Sort
            
            // Read the file again so the array is back in it's original state
            textProcessor.ProcessTextFile(@"..\..\..\shakespeare-complete-works.txt", regexPattern);
            
            stopwatch = Stopwatch.StartNew();
            ArraySorter<string> arraySorter = new ArraySorter<string>(textProcessor.ProcessedStrings, textProcessor.ProcessedStrings.Length);
            arraySorter.SortAscending();
            stopwatch.Stop();
            PrintElapsedTime(dataLength, stopwatch.ElapsedMilliseconds, "Heap Sort");
            
            #endregion

            #region Trie Sort
            
            textProcessor.ProcessTextFile(@"..\..\..\shakespeare-complete-works.txt", regexPattern);
            stopwatch = Stopwatch.StartNew();
            Trie.Sort(textProcessor.ProcessedStrings);
            stopwatch.Stop();
            PrintElapsedTime(dataLength, stopwatch.ElapsedMilliseconds, "Trie");

            #endregion


        }

        static void PrintElapsedTime(int arrayLength, long elapsedTimeInMS, string name)
        {
            Console.WriteLine($"Sorted {arrayLength:N0} strings in {elapsedTimeInMS:N0} MS using {name}. That is {(double) arrayLength / elapsedTimeInMS:N2} words sorted per millisecond.");
        }
    }
}