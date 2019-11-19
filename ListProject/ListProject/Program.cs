using System;

namespace ListProject
{
    class Program
    {
        static void Main(String[] args)
        {
            ListExercises myList = new ListExercises();

            Console.WriteLine("Enter five names, one per line");
            for (int i = 0; i < 5; i++)
            {
                myList.AddNameToList(Console.ReadLine());
            }
            Console.WriteLine("Results are " + myList.GetListAsString());
            Console.ReadLine();
        }
    }
}
