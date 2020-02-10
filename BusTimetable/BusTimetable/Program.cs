using System;
using System.IO;

namespace BusTimetable
{
    class Program
    {
        private static Route[] routes = new Route[100];
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LoadWordsFromFile();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(routes[0].getStartTimes()[i]);
            }
            Console.ReadLine();
        }

        private static void LoadWordsFromFile()
        {
            // Load the file.
            StreamReader theInputStream =
                new StreamReader("H:/Computer Science/HSFC/BusTimetable/BusTimetable/data.txt");

            // Word counter.
            int routescount = 0;

            // Process the file line by line
            while (!theInputStream.EndOfStream)
            {
                // Split the words (I suppose this could help with any thing with multiple words in the future)
                string[] tokenizedString = theInputStream.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string origin = "", destination = "";
                string[] startTime = new string[100];
                int counter = 0;
                // Process each string in the array.
                foreach (string str in tokenizedString)
                {
                    switch(counter)
                    {
                        case (0):
                            origin = str;
                            break;
                        case (1):
                            destination = str;
                            break;
                        default:
                            startTime[counter - 2] = str;
                            break;                    
                    }
                    counter++;
                }
                routes[routescount] = new Route(origin, destination, startTime);
                routescount++;
            }
            theInputStream.Close();
            Console.WriteLine(routescount);
        }
    }
}
