using System;

namespace FactorialFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0}! is " + FindFactorial(number), number);
            Console.ReadLine();
        }

        static int FindFactorial(int num)
        {
            int f = 1;
            for (int i = 2; i < num + 1; i++)
            {
                f *= i;
            }

            return f;
        }
    }
}
