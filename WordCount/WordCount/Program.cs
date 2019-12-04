using System;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            WordCounter dictionary = new WordCounter(100);
            dictionary.LoadWordsFromFile("H:/Computer Science/HSFC/WordCount/WordCount/poem.txt");

            for (int i = 0; i < dictionary.GetNextFreeLocation(); i++)
            {
                Console.WriteLine(dictionary.GetList()[i].GetWord() + " - " + dictionary.GetList()[i].GetCount());
            }
            Console.ReadLine();
        }
    }
}
