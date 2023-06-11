//https://centralia.instructure.com/courses/2326195/assignments/29997941

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace StringExtention
{
    public static class SillyString
    {
        public enum MinMaxType { MAX_OCCURANCE, MIN_OCCURANCE, MAX_OCCURANCE_VOWELS, MIN_OCCURANCE_VOWELS }
        
        public static bool IsPalindrome(this string input)
        {
        // Default palindrome is not case sensative.
            return input.IsPalindrome(false);
        }

        public static bool IsPalindrome(this string input, bool caseSensitive)
        {
            // fix this to use overload in the Reverse class?
            if (!caseSensitive)
            {
                input = input.ToLower();
            }
            string newWord = input.Reverse();
            if (newWord.Equals(input)) { return true; }
            else { return false; }
        }

        public static string Reverse(this string input)
        {
            return input.Reverse(false);
        }

        public static string Reverse(this string input, bool casing)
        {
        //Create an Extension Method which would reverse a string.
        //By default the casing moves with the letter.
        //Overload to allow for the casing to remain at the original string location (true)
        //or travel with the character (false and the default)

            List<int> upperIndexes = new List<int>();

            StringBuilder sb = new();

            for (int i = input.Length-1; i>=0; i--)
            {
                sb.Append(input[i]);
                if (Char.IsUpper(input[i]))
                    upperIndexes.Add(i); 
            }

            if (casing)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    sb[i] = char.ToLower(sb[i]);
                }
                foreach (int i in upperIndexes)
                {
                    sb[i] = char.ToUpper(sb[i]);
                  
                }
            }
            return sb.ToString().Trim();

        }

        /*Create an Extension Method which allows for a search parameter or either char or string;
         * and returns the number of occurrences of the pattern as an int;
         * with -1 returned if no match is found
         */
        public static int SearchPattern(this string input, char pattern)
        {
            string s = pattern.ToString();
            return input.SearchPattern(s);
        }

        public static int SearchPattern(this string input, string pattern)
        {
            var searchPattern = new Regex(@pattern);
            int count = searchPattern.Matches(input).Count();
            if (count > 0 ) { return count; }
            else { return -1; }
        }

        public static string RemoveDuplicates(this string input)
        {
            string newString = new(input[0].ToString());

            foreach (char c in input)
            {
                if (newString.SearchPattern(c).Equals(-1))
                {
                    newString = newString + c;
                }
            }     
            return newString.ToString();
        }

        public static bool IsVowel(char letter)
        {
            string vowels = "aeiou";        // but don't ask Y
            if(vowels.Contains(letter)) {
                return true;    
            }
            return false;
        }

        public static string OnlyVowels(this string input)
        {
            StringBuilder onlyVowels = new();

            foreach (char letter in input)
            {
                if (IsVowel(letter))
                {
                    onlyVowels.Append(letter);
                }
            }
            return onlyVowels.ToString();
        }

        #region Method 5:  MinMax

        internal static List<Tuple<char, int>> GetCounts(this string input)
        {
            var results = new List<Tuple<char, int>>();
            string noDup = input.RemoveDuplicates();

            // Create tuple list for [letter],[count]
            foreach (char letter in noDup)
            {
                results.Add(Tuple.Create(letter, input.SearchPattern(letter)));
            }
            return results;
        }

        public static string MinMax(this string input)
        {
            // Passes back human readable string with all [letter],[count] pairs
            StringBuilder output = new();
            output.Append("Count of letters in " + input + "\n");

            foreach (Tuple<char, int> pair in GetCounts(input))
            {
                output.Append("\t" + pair.Item1.ToString() + ": " + pair.Item2.ToString() + "\n");
            }

            return output.ToString();
        }

        public static int MinMax(this string input, MinMaxType method)
        {
            var results = new List<Tuple<char, int>>();
            string myLetter = "letter";
            string searchString = input;

            // Restrict to vowels as needed
            if (method == MinMaxType.MIN_OCCURANCE_VOWELS || method == MinMaxType.MAX_OCCURANCE_VOWELS)
            {
                searchString = searchString.OnlyVowels();
                myLetter = "vowel";
            }
            
            results = searchString.GetCounts();

            // Return either MaxBy or MinBy
            if(method == MinMaxType.MAX_OCCURANCE_VOWELS || method == MinMaxType.MAX_OCCURANCE)
            {
                var x = results.MaxBy(x => x.Item2);
                Console.WriteLine("First maximum " + myLetter + " is " + x.Item1 + " at " + x.Item2);
                return x.Item2;
            }
            else // only dealing with the 4 options in the enumeration
            {
                var x = results.MinBy(x => x.Item2);
                Console.WriteLine("First minimum " + myLetter + " is " + x.Item1 + " at " + x.Item2);
                return x.Item2;
            }



        }
    #endregion
}
}
