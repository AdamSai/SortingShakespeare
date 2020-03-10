using System;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    public class Trie
    {
        private static int _currentIndex;

        public static void Sort(string[] str)
        {
            var root = new TrieNode();
            foreach (var s in str)
            {
                root.Insert(root, s, s);
            }

            TrieToArray(root, str);
        }
        /// <summary>
        /// Recursively adds node values to the given array
        /// </summary>
        /// <param name="node">Current node</param>
        /// <param name="arr">Array for elements to be inserted into</param>
        private static void TrieToArray(TrieNode node, String[] arr)
        {
            if (node == null) return;
            // If the node actually has a value, add it/them to the array
            if (!string.IsNullOrEmpty(node.Value))
            {
                for (var i = 0; i < node.Count; i++)
                {
                    arr[_currentIndex++] = node.Value;
                }
            }
            
            foreach (var child in node.Children)
            {
                TrieToArray(child, arr);
            }
        }


        public class TrieNode
        {
            public readonly TrieNode[] Children;
            public int Count;
            // value of the node
            public string Value;

            public TrieNode()
            {
                Count = 0;
                Value = "";
                Children = new TrieNode[28];
            }

            public void Insert(TrieNode node, string str, string value)
            {
                foreach (var c in str)
                {
                    var currentIndex = GetHashValue(c);
                    var childNode = node.Children[currentIndex];
                    // If the current character does not exist in the array, insert it
                    if (childNode == null)
                    {
                        node.Children[currentIndex] = new TrieNode();
                    }

                    // Move to the next child
                    node = node.Children[currentIndex];
                }
                if(string.IsNullOrEmpty(node.Value))
                    node.Value = value;
                node.Count++;
            }

            public static void PrintTrie(TrieNode node)
            {
                if (node == null) return;
                if (!string.IsNullOrEmpty(node.Value))
                    Console.WriteLine($"{node.Value} {node.Count}");
                // here you can play with the order of the children
                foreach (var child in node.Children)
                {
                        PrintTrie(child);
                }
            }

            private static int GetHashValue(char c)
            {
                // Return 26 if char is -
                // Return 27 if char is '
                // Default return value is char - 97
                return c switch
                {
                    '-' => 0,
                    '\'' => 1,
                    _ => c - 95
                };
            }
        }
    }
}