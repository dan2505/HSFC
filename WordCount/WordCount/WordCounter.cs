using System;
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

        public int AddWordToList(string theWord)
        {
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

            for (int i = 0; i < nextFreeLocation; i++)
            {
                if (collection[i].GetWord() == theWord)
                {
                    collection[i].BumpCount();
                    return i;
                }
            }

            collection[position] = new WordCountPair(theWord, 1);
            nextFreeLocation++;
            return position;
        }

        public int GetNextFreeLocation()
        {
            return nextFreeLocation;
        }

        public WordCountPair[] GetList()
        {
            return collection;
        }

    }
}