using StringExtention;
using System;
using System.Xml.Schema;

while (true) {
        Console.WriteLine("Word up!");
        Console.WriteLine("<ctrl> <c> to quit");
        string input = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Your word is " + input + "\n");

    #region Method 1:  Is Palindrome
    if (input.IsPalindrome())
        {
            Console.WriteLine("\tNot case sensative: " + input + " is a palindrome.\n");
        }
        else
        {
            Console.WriteLine("\tNot case sensative: " + input + " is not palindrome.\n");
        }

        // Method 1 a:  Case sensitive palindrome
        if (input.IsPalindrome(true))
        {
            Console.WriteLine("\tCase sensative: " + input + " is a palindrome.\n");
        }
        else
        {
            Console.WriteLine("\tCase sensative: " + input + " is not palindrome.\n");
        }
    #endregion
    
    #region Method 2: Reverse
    Console.WriteLine("\tBackwards your word is " + input.Reverse(false) + "\n");

    // Method 2a: Reverse and preserve location of caps
    Console.WriteLine("\tOverload to preserve location of the capital letters: " + input.Reverse(true) + "\n");
    #endregion

    #region Method 4: Remove Duplicates
    Console.WriteLine("Without duplictes your word is:" + input.RemoveDuplicates() + "\n");
    #endregion

    #region Method 5:  Min/Max
    // Calling these to fire methods for testing - I left the console logic in the extention class because I did not think you would care
    input.MinMax(SillyString.MinMaxType.MAX_OCCURANCE);
    input.MinMax(SillyString.MinMaxType.MIN_OCCURANCE);
    input.MinMax(SillyString.MinMaxType.MAX_OCCURANCE_VOWELS);
    input.MinMax(SillyString.MinMaxType.MAX_OCCURANCE_VOWELS);
    #endregion

    #region Method 3: Search param
    Console.WriteLine("\nEnter a string to search and a pattern to search for.");
    Console.Write("String to Search:");
    string myString = Console.ReadLine();
    Console.Write("Pattern to search for:");

    string pattern = Console.ReadLine();
    int result = myString.SearchPattern(pattern);
    if (result == -1)
    {
        Console.WriteLine(pattern + " does not appear in " + myString);
    }
    else
    {
        Console.WriteLine(pattern + " appears " + result + " times in " + myString);
    }
    Console.WriteLine("\n\n\n");

    #endregion

};