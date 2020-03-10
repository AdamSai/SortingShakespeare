using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Shakespeare
{
    public class TextProcessor
    {
        public string[] ProcessedStrings {  get; private set; }
        /// <summary>
        /// Reads a text file and returns it as a string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ReadText(string path)
        {
            return File.ReadAllText(path);
        }
        /// <summary>
        /// Reads a text file and finds elements that matches a regex pattern and adds the matching strings to the ProcessedStrings array.
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="regexPattern"></param>
        public void ProcessTextFile(string path, string regexPattern)
        {
            var text = ReadText(path).ToLower();
            ProcessedStrings = SanitizeText(text, regexPattern);
        }
        /// <summary>
        /// Find elements matching a regex pattern and returns an array with all the matches
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private string[] SanitizeText(string text, string pattern)
        {
            var matches = Regex.Matches(text, pattern);
            var matchedStrings = new string[matches.Count];
            for (var i = 0; i < matches.Count(); i++)
            {
                matchedStrings[i] = matches[i].ToString();
            }

            return matchedStrings;
        }
    }
}