using System;

namespace CoachProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Coach myCoach = new Coach(52);
            bool running = true;
            while (running)
            {
                Console.WriteLine(" ");
                Console.WriteLine("C O A C H  P R O G R A M");
                Console.WriteLine("1 | Add a passenger to the coach.");
                Console.WriteLine("2 | Remove a passenger from the coach.");
                Console.WriteLine("3 | Get the seat number from a passenger's name.");
                Console.WriteLine("4 | Get the amount of passengers on the coach.");
                Console.WriteLine("5 | Exit the program.");
                Console.WriteLine(" ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Passenger's name:");
                        String name = Console.ReadLine();

                        Console.WriteLine("Passenger's age:");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Passenger's seat:");
                        int seat = Convert.ToInt32(Console.ReadLine());

                        if (myCoach.AddPassenger(new Passenger(name, age, seat)))
                        {
                            Console.WriteLine(name + " is now seated in " + seat);
                            break;
                        }
                        Console.WriteLine("Couldn't add " + name + " to the coach in seat " + seat);
                        break;
                    case 2:
                        Console.WriteLine("Passenger's name:");
                        String removeName = Console.ReadLine();

                        Passenger removePass = myCoach.GetPassengerByName(removeName);
                        if (myCoach.RemovePassenger(removePass))
                        {
                            Console.WriteLine(removeName + " has been removed from the coach.");
                            break;
                        }
                        Console.WriteLine("Couldn't remove " + removeName + " from the coach.");
                        break;
                    case 3:
                        Console.WriteLine("Passenger's name:");
                        String seatName = Console.ReadLine();
                        if (myCoach.GetSeatByName(seatName) != -1)
                        {
                            Console.WriteLine(seatName + "'s seat is " + myCoach.GetSeatByName(seatName));
                        }
                        Console.WriteLine("Couldn't find " + seatName + " on the coach.");
                        break;
                    case 4:
                        Console.WriteLine(myCoach.GetSize());
                        break;
                    case 5:
                        running = false;
                        Console.WriteLine("Exitting the program, bye!");
                        break;
                    default:
                        break;

                }
            }
        }
    }
}