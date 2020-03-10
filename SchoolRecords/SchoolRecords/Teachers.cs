using System;

namespace SchoolRecords
{
    public class Teachers
    {
        private readonly Teacher[] contents;
        private int currentSize;

        public Teachers(int maxSize)
        {
            contents = new Teacher[maxSize];
        }

        public int getCurrentSize()
        {
            return currentSize;
        }

        public int addTeacher(ref Teacher theTeacher)
        {
            if (currentSize >= contents.Length) return -1;

            contents[currentSize] = theTeacher;
            currentSize++;
            return 0;
        }

        public Teacher getTeacher(string theFirstName, string theLastName)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if ((contents[i].getFirstName() == theFirstName) && (contents[i].getLastName() == theLastName))
                    return contents[i];
            }

            return null;
        }

        public int removeTeacher(string theFirstName, string theLastName)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if ((contents[i].getFirstName() == theFirstName) && (contents[i].getLastName() == theLastName))
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
            string temp = "";
            for (int i = 0; i < currentSize - 1; i++)
            {
                temp = temp + contents[i];
            }

            return temp + Environment.NewLine;
        }
    }
}