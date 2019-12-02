using System;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string:");
            string[] words = Console.ReadLine().Split(" ");

            WordCounter dictionary = new WordCounter(words.Length);

            for (int i = 0; i < words.Length; i++)
            {
                dictionary.AddWordToList(words[i].ToLower());
            }

            for (int i = 0; i < dictionary.GetNextFreeLocation(); i++)
            {
                Console.WriteLine(dictionary.GetList()[i].GetWord() + " - " + dictionary.GetList()[i].GetCount());
            }

            Console.ReadLine();
        }
    }
}
