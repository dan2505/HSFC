using System;

namespace BusTimetable
{
    class Program
    {
        static void Main(string[] args)
        {
            Routes routes = new Routes();
            routes.DisplayTimetable();
            routes.FindJourneys("Hereford", 0800, 1300);
            Console.ReadLine();
        }
    }
}
