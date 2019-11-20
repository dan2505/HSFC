using System;

namespace RemoteControl
{
    class Program
    {
        private static bool running = true;
        private static string[] commands = new string[10];

        static void Main(string[] args)
        {
            while (running) DisplayMenu();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Welcome to Remote Control\n");
            Console.WriteLine("Which option do you require?");
            Console.WriteLine("1 | Program your remote control.");
            Console.WriteLine("2 | Display commands.");
            Console.WriteLine("3 | Run.");
            Console.WriteLine("4 | Quit.");

            switch(Console.ReadLine())
            {
                case "1":
                    ProgramRemote();
                    break;
                case "2":
                    Console.WriteLine("You have chosen to display commands: ");
                    DisplayCommands();
                    break;
                case "3":
                    RunCommand();
                    break;
                case "4":
                    running = false;
                    break;
            }
        }

        public static void DisplayCommands()
        {
            string temp = "";
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == null)
                {
                    temp = temp + i + " | UNSET\n";
                } else
                {
                    temp = temp + i + " | " + commands[i] + "\n";
                }
            }
            Console.WriteLine(temp);
        }

        public static void ProgramRemote()
        {
            DisplayCommands();
            Console.WriteLine("Which button?");
            int button = Convert.ToInt32(Console.ReadLine());
            if (button > commands.Length) return;

            Console.WriteLine("What function?");
            string function = Console.ReadLine();
            commands[button] = function;
        }

        public static void RunCommand()
        {
            DisplayCommands();
            Console.WriteLine("Which button?");
            int button = Convert.ToInt32(Console.ReadLine());
            if (button > commands.Length) return;

            Console.WriteLine(commands[button] + " executed");
        }
    }
}