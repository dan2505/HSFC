using System;

namespace BusTimetable
{
    class Program
    {
        static void Main(string[] args)
        {
            Routes routes = new Routes();
            routes.DisplayTimetable();

            Console.WriteLine("\n" + "Route Origin: ");
            string origin = Console.ReadLine();

            Console.WriteLine("\n" + "Route Destination: ");
            string destination = Console.ReadLine();

            Console.WriteLine("\n" + "Start Time: ");
            int start = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n" + "End Time: ");
            int end = Convert.ToInt32(Console.ReadLine());

            routes.FindJourneys(origin, destination, start, end);
            Console.ReadLine();
        }
    }
}