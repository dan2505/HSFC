using System;

namespace WordCount
{
    class WordCountPair
    {
        private readonly string word;
        private int count;

        public WordCountPair(string word, int count)
        {
            this.word = word;
            this.count = count;
        }
        // simple sets and gets for the class

        // SetCount allows a user to set the Count element of Word Count pair
        public void BumpCount()
        {
            count = count + 1;
        }

        // GetWord allows a user to get the Word element of Word Count pair
        public string GetWord()
        {
            return word;
        }

        // GetCount allows a user to get the Count element of Word Count pair
        public int GetCount()
        {
            return count;
        }
    }
}
