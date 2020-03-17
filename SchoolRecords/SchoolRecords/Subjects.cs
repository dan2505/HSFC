using System;

namespace SchoolRecords
{
    public class Subjects
    {
        private readonly int maxSize;
        private readonly Subject[] contents;
        private int currentSize;

        public Subjects(int maxNum)
        {
            maxSize = maxNum;
            contents = new Subject[maxNum];
        }

        public int getCurrentSize()
        {
            return currentSize;
        }

        public int addSubject(Subject theSubject)
        {
            if (currentSize < maxSize)
            {
                contents[currentSize] = theSubject;
                currentSize++;
                return 0;
            }
            
            return -1;
        }

        public Subject getSubject(int position)
        {
            if ((position < 0) | (position >= currentSize))
            {
                return null;
            }
            return contents[position];
        }

        public Subject getSubject(string theName, string theLevel)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if ((contents[i].getName() == theName) & (contents[i].getLevel() == theLevel))
                    return contents[i];
            }

            return null;
        }

        public int removeSubject(string theName, string theLevel)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if ((contents[i].getName() == theName) & (contents[i].getLevel() == theLevel))
                {
                    contents[i] = contents[currentSize - 1];
                    contents[currentSize - 1] = null;
                    currentSize--;
                    return 0;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            string temp = "Subjects: ";
            for (int i = 0; i < currentSize - 1; i++)
            {
                temp = temp + contents[i];
            }

            return temp + Environment.NewLine;
        }
    }
}