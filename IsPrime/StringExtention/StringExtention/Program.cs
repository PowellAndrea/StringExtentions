using StringExtention;
using System;
while (true) {
        Console.WriteLine("Word up!");
        Console.WriteLine("<ctrl> <c> to quit");
        string input = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Your word is " + input + "\n");

        // Method 1:  Is Palindrome
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


        // Method 2: Reverse
        Console.WriteLine("\tBackwards your word is " + input.Reverse(false) + ".\n");

        // Method 2a: Reverse and preserve location of caps
        Console.WriteLine("\tOverload to preserve location of the capital letters: " + input.Reverse(true) + ".\n");
    };