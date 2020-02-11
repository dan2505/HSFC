using System;
using System.IO;

namespace BusTimetable
{
    class Routes
    {
        private readonly Route[] _routes = new Route[100];
        private int _nextFreeLocation;

        public Routes()
        {
            LoadRoutesFromFile();
        }

        private void AddRoute(Route route)
        {
            _routes[_nextFreeLocation] = route;
            _nextFreeLocation++;
        }

        public void DisplayTimetable()
        {
            for (int i = 0; i < _nextFreeLocation; i ++)
            {
                Route route = _routes[i];

                string temp = "";
                for (int times = 0; times < route.GetRouteCount(); times++)
                {
                    temp = temp + route.GetStartTimes()[times] + "  ";
                }
                Console.WriteLine(route.GetOrigin() + " --> " + route.GetDestination() + " : " + temp);
            }
        }

        public void FindJourneys(string origin, int startTime, int endTime)
        {
            Route[] temp = new Route[_nextFreeLocation];

            int counter = 0;
            for (int i = 0; i < _nextFreeLocation; i++)
            {
                Route route = _routes[i];
                if (route.GetOrigin() == origin)
                {
                    for (int times = 0; times < route.GetRouteCount(); times++)
                    {
                        int time = Convert.ToInt32(route.GetStartTimes()[times]);
                        if ((time >= startTime) && (time <= endTime))
                        {
                            temp[counter] = _routes[i];
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
                Console.Write(route.GetDestination() + " : ");
                for (int times = 0; times < route.GetRouteCount(); times++)
                {
                    int time = Convert.ToInt32(route.GetStartTimes()[times]);
                    if ((time >= startTime) && (time <= endTime))
                    {
                        Console.Write(route.GetStartTimes()[times] + "  ");
                    }
                }
                Console.WriteLine("");
            }
        }

        private void LoadRoutesFromFile()
        {
            StreamReader theInputStream = new StreamReader("/Users/danwilliams/Projects/HSFC/BusTimetable/BusTimetable/data.txt");

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
