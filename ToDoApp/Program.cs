using System;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ListTasks list = new ListTasks();

            Console.WriteLine("Command Line Todo application");
            Console.WriteLine("Command line arguments:");
            Console.WriteLine("- l   Lists all the tasks");
            Console.WriteLine("- a   Adds a new task");
            Console.WriteLine("- r   Removes an task");
            Console.WriteLine("- c   Completes an task");
            Console.WriteLine("- x   Exit");
            Console.WriteLine();
            string argument = Console.ReadLine();
            Console.WriteLine();
            while (argument != "x")
            {
                switch (argument)
                {
                    case "l":
                        list.ListAllTasks();
                        Console.WriteLine();
                        Console.WriteLine("What´s next?");
                        break;
                    case "a":
                        list.AddNewTask();
                        Console.WriteLine();
                        Console.WriteLine("Done! What´s next?");
                        break;
                    case "r":
                        list.RemoveTask();
                        Console.WriteLine();
                        Console.WriteLine("Done! What´s next?");
                        break;
                    case "c":
                        list.Check();
                        Console.WriteLine();
                        Console.WriteLine("Done! What´s next?");
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        Console.WriteLine();
                        Console.WriteLine("Command line arguments:");
                        Console.WriteLine("- l   Lists all the tasks");
                        Console.WriteLine("- a   Adds a new task");
                        Console.WriteLine("- r   Removes an task");
                        Console.WriteLine("- c   Completes an task");
                        Console.WriteLine("- x   Exit");
                        Console.WriteLine();
                        break;
                }
                argument = Console.ReadLine();
            }

        }

    }
}
