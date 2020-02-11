using System;
using System.IO;

namespace BusTimetable
{
    class Routes
    {
        private Route[] routes = new Route[100];
        private int nextFreeLocation = 0;

        public Routes()
        {
            LoadRoutesFromFile();
        }

        public void AddRoute(Route route)
        {
            routes[nextFreeLocation] = route;
            nextFreeLocation++;
        }

        public void DisplayTimetable()
        {
            for (int i = 0; i < nextFreeLocation; i ++)
            {
                Route route = routes[i];

                string temp = "";
                for (int times = 0; times < route.getRouteCount(); times++)
                {
                    temp = temp + route.getStartTimes()[times] + "  ";
                }
                Console.WriteLine(route.getOrigin() + " --> " + route.getDestination() + " : " + temp);
            }
        }

        public void FindJourneys(string origin, int startTime, int endTime)
        {
            Route[] temp = new Route[nextFreeLocation];

            int counter = 0;
            for (int i = 0; i < nextFreeLocation; i++)
            {
                Route route = routes[i];
                if (route.getOrigin() == origin)
                {
                    for (int times = 0; times < route.getRouteCount(); times++)
                    {
                        int time = Convert.ToInt32(route.getStartTimes()[times]);
                        if ((time >= startTime) && (time <= endTime))
                        {
                            temp[counter] = routes[i];
                            counter++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("\n" + "Routes from " + origin);
            for (int i = 0; i < counter; i++)
            {
                Route route = temp[i];
                Console.Write(route.getDestination() + " : ");
                for (int times = 0; times < route.getRouteCount(); times++)
                {
                    int time = Convert.ToInt32(route.getStartTimes()[times]);
                    if ((time >= startTime) && (time <= endTime))
                    {
                        Console.Write(route.getStartTimes()[times] + "  ");
                    }
                }
                Console.WriteLine("");
            }
        }

        private void LoadRoutesFromFile()
        {
            StreamReader theInputStream = new StreamReader("H:/Computer Science/HSFC/BusTimetable/BusTimetable/data.txt");

            while (!theInputStream.EndOfStream)
            {
                string[] tokenizedString = theInputStream.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string origin = "", destination = "";
                string[] startTime = new string[100];

                int slot = 0;
                foreach (string str in tokenizedString)
                {
                    switch (slot)
                    {
                        case (0):
                            origin = str;
                            break;
                        case (1):
                            destination = str;
                            break;
                        default:
                            startTime[slot - 2] = str;
                            break;
                    }
                    slot++;
                }
                AddRoute(new Route(origin, destination, startTime, slot - 2));
            }
            theInputStream.Close();
        }
    }
}
