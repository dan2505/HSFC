using System;
namespace ListProject
{
    class ListExercises
    {
        private string[] names = new string[10];
        private int nextFreeLocation;

        // addName takes in a name, adds it to the list maintaining the order
        // passes back an integer (-1 if error), giving inserted location
        public int AddNameToList(string theName)
        {
            if (nextFreeLocation > names.Length) return -1;

            int position = 0;
            while ((position < nextFreeLocation) && (string.Compare(theName, names[position], StringComparison.Ordinal) > 0))
            {
                position++;
            }

            for (int i = nextFreeLocation; i > position; i--)
            {
                names[i] = names[i - 1];
            }

            names[position] = theName;
            nextFreeLocation++;
            return position;
        }

        // FindPositionOfName locates a name in the list
        // passes back an integer (-1 if error), giving inserted location
        public int FindPositionOfName(string theName)
        {
            return BinarySearch(names,theName);
        }

        // RemoveByPosition returns a boolean to indicate success
        public bool RemoveByPosition(int position)
        {
            // 1) Make sure number inserted is within the range 0 to nextfreelocation –1
            // if not, return false
            if ((position >= nextFreeLocation) || (position < 0)) return false;
            //  2) to remove a name, go from position  to nextFreeLocation - 1
            //  shunt all the other items up (names[i] = names[i+1])
            for (int i = position; i < nextFreeLocation; i++)
            {
                names[i] = names[i + 1];
            }
            nextFreeLocation--;

            return true;
        }

        // GetListAsString just returns a formatted string of List
        public string GetListAsString()
        {
            string temp = "";
            for (int i = 0; i < nextFreeLocation; i++)
            {
                temp = temp + names[i] + "\n";
            }
            return temp;
        }

        public int BinarySearch(String[] theList, String itemToSearchFor)
        {
            int min = 0, mid;                 // the start of the array
            int max = theList.Length - 1;  // the end of the array
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (itemToSearchFor == theList[mid])
                {
                    return mid;
                }
                else if (string.Compare(itemToSearchFor, theList[mid], StringComparison.Ordinal) < 0)   // found the item
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;   // if we get here, we haven't found it, so return -1
        }

    }
}
