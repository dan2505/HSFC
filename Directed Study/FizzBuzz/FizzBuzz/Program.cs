using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maximum number?");
            int max = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Fizz number? (e.g. 3)");
            int fizz = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Buzz number? (e.g. 5)");
            int buzz = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < max; i++)
            {
                bool IsFizz = (i % fizz == 0);
                bool IsBuzz = (i % buzz == 0);

                if (IsFizz)
                {
                    Console.Write("Fizz");
                }

                if (IsBuzz)
                {
                    Console.Write("Buzz");
                }

                if (IsPrime(i))
                {
                    Console.Write("OOPS!");
                }

                if (!IsBuzz && !IsFizz && !IsPrime(i))
                {
                    Console.Write(i);
                }

                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static bool IsPrime(int number)
        {
            if (number <= 1 || (number % 2 == 0)) return false;
            if (number == 2) return true;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
