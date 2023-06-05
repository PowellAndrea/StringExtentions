//https://centralia.instructure.com/courses/2326195/assignments/29997941

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace StringExtention
{
    public static class SillyString
    {
        public static string TitleCase(this string str, string sentance)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = sentance.Split(new char[]
            {
                ' ','.' ,'?'
            }, StringSplitOptions.None);

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
                sb.Append(words[i] + " ");
            }
            return sb.ToString().Trim();
        }



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

        public static int Method3(this string input)
        {
            //Create an Extension Method which allows for a search parameter
            //or either char or string and
            //returns the number of occurrences of the pattern as an int,
            //with -1 returned if no match is found
            return 0;
        }

        public static string Method4(string str)
        {
        //Create an Extension Method which removes any duplicate characters
        //found and preserves one of the duplicates("dogfood" returns "dog")
        //all visible characters(spaces, punctuation, etc.) are targets
            return str;
        }

        public static int Method5(string str)
        {
            //Create an Extension Method which returns the
            //maximum occurrences of a character in the string as an int;
            //overload to allow for an enumeration of
            //MAX_OCCURANCE
            //MIN_OCCURANCE
            //MAX_OCCURANCE_VOWELS
            //MIN_OCCURANCE_VOWELS

            return 0;
        }
    }
}
