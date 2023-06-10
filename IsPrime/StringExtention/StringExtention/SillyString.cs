//https://centralia.instructure.com/courses/2326195/assignments/29997941

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

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

        public static int MinMax(this string input, MinMaxType method)
        {
            string noDup = input.RemoveDuplicates();
            var results = new List<Tuple<char, int>>();
            string vowels = "aeiou";

            foreach (char letter in noDup)
            {
                results.Add(Tuple.Create(letter, input.SearchPattern(letter)));
            }

            Console.WriteLine("Count of letters in " + input);
            foreach (Tuple<char, int> pair in results)
            {
                Console.WriteLine("\t" + pair.Item1.ToString() + ": " + pair.Item2.ToString());
            }

            switch (method)
            {
                // Left Console writes left here for testing
                case MinMaxType.MAX_OCCURANCE:
                    { 
                        var x = results.MaxBy(x => x.Item2);
                        Console.WriteLine("First maximum is " + x.Item1 + " at " + x.Item2);
                        return x.Item2;}

                case MinMaxType.MIN_OCCURANCE:
                    {
                        var x = results.MinBy(x => x.Item2);
                        Console.WriteLine("First minimum is " + x.Item1 + " at " + x.Item2);
                        return x.Item2;
                    }

                case MinMaxType.MAX_OCCURANCE_VOWELS:
                    {
                        var newResults = new List<Tuple<char, int>>();

                        foreach (var item in results)
                        {
                            if (!vowels.Contains(item.Item1))
                            {
                                newResults.Add(item);
                            }
                        }
                        var x = newResults.MaxBy(x => x.Item2);
                        Console.WriteLine("First maximum vowel is " + x.Item1 + " at " + x.Item2);
                        return x.Item2;
                    }
// Create 'removeVowels' method and redo these if time
                case MinMaxType.MIN_OCCURANCE_VOWELS:
                    {
                        var newResults = new List<Tuple<char, int>>();

                        foreach (var item in results)
                        {
                            if (vowels.Contains(item.Item1))
                            {
                                newResults.Append(item);
                            }
                        }
                        var x = newResults.MinBy(x => x.Item2);
                        Console.WriteLine("First minimum vowel is " + x.Item1 + " at " + x.Item2);
                        return x.Item2;
                    }
            }
            return 0;
        }
    }
}
