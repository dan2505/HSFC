using System;
using System.IO;

namespace WordCount
{
    class WordCounter
    {
        private readonly WordCountPair[] collection;
        private int nextFreeLocation;

        public WordCounter(int maxSize)
        {
            collection = new WordCountPair[maxSize];
        }

        // AddWordToList takes in a new word, adds it to the collection and returns current count for that word
        // passes back -1 if it can't be added.
        public int AddWordToList(string theWord)
        {
            for (int i = 0; i < nextFreeLocation; i++)
            {
                if (collection[i].GetWord() == theWord)
                {
                    collection[i].BumpCount();
                    return collection[i].GetCount();
                }
            }

            if (nextFreeLocation > collection.Length) return -1;

            int position = 0;
            while ((position < nextFreeLocation) && (string.Compare(theWord, collection[position].GetWord(), StringComparison.Ordinal) > 0))
            {
                position++;
            }

            for (int i = nextFreeLocation; i > position; i--)
            {
                collection[i] = collection[i - 1];
            }

            collection[position] = new WordCountPair(theWord, 1);
            nextFreeLocation++;
            return collection[position].GetCount();
        }

        public int GetNextFreeLocation()
        {
            return nextFreeLocation;
        }

        public WordCountPair[] GetList()
        {
            return collection;
        }

        // loadWordsFromFile loads a file and processes text
        public void LoadWordsFromFile(String fileName)
        {
            StreamReader theInputStream = new StreamReader(fileName);
            char[] delimiter = new char[] { ' ', '.', ',', '\n', ';', ':' };

            // Now let's process the file, a line at a time
            while (!theInputStream.EndOfStream)
            {
                // now process the line
                string[] tokenizedString = theInputStream.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                // Now we process each String in the string array
                for (int i = 0; i < tokenizedString.Length; i++)
                {
                    AddWordToList(tokenizedString[i].ToLower());
                }
            }
            theInputStream.Close();
        }
    }
}