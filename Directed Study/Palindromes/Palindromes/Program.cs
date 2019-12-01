using System;
using System.Linq;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your word?");

            if (IsPalindrome(Console.ReadLine().ToLower())) {
                Console.WriteLine("This is a palidrome.");
                return;
            }
            Console.WriteLine("This is not a palidrome.");

            Console.ReadLine();
        }

        static bool IsPalindrome(string palindrome)
        {
            return palindrome.SequenceEqual(palindrome.Reverse());
        }
    }
}