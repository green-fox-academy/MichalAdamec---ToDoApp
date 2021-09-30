using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Given the terminal opened in the project directory
//And the file where you store your data                            X
//And a task with the description Walk the dog stored in the file   X
//And a task with the description Buy milk stored in the file       X
//And a task with the description Do homework stored in the file    X
//When the application is ran with -l argument                      X
//Then it should print the tasks that are stored in the file        X
//And it should add numbers before each                             X

//Empty list        X
//Add new task      X
//Remove task       X
//Check task        X
//Check task error handling     X
//Add new task error handling   X
//Remove task error handling    X



namespace ToDoApp
{
    class ListTasks
    {
        string path = @"C:\Users\micha\greenfox\MichalAdamec---ToDoApp\ToDoApp\Tasks.txt";

        public void Check()
        {
            Console.WriteLine("Write the number of the task you want to mark as done!");
            string[] toDo = File.ReadAllLines(path);                            //přečte soubor a uloží ho do array
            int taskChecked;
            bool check = Int32.TryParse(Console.ReadLine(), out taskChecked) && (taskChecked <= toDo.Length); //Error handling: input větší než počet položek/string/prázdný
            while (check == false)
            {
                Console.WriteLine("Argument is not a number of the task.");
                Console.WriteLine("Write the number of task you want to mark as done!");
                Console.WriteLine();
                check = Int32.TryParse(Console.ReadLine(), out taskChecked) && (taskChecked <= toDo.Length);
            }
            string singleTask = toDo[taskChecked - 1];                          //převede index arraye na string
            singleTask = singleTask.Replace("[ ]", "[X]");      //nahradí část řetězce (stringu) novou hodnotou
            toDo[taskChecked - 1] = singleTask;                         //převede string zpět na index arraye toDo
            File.WriteAllLines(path, toDo);                   //zapíše array do souboru
        }
        public void RemoveTask()
        {
            Console.WriteLine("Write the number of the task you want to delete!");
            string[] toDo = File.ReadAllLines(path);                    //přečte soubor a uloží ho do array
            int taskDelete;
            bool check = Int32.TryParse(Console.ReadLine(), out taskDelete) && (taskDelete <= toDo.Length); //Error handling: input větší než počet položek/string/prázdný
            while (check == false)
            {
                Console.WriteLine("Argument is not a number of the task.");
                Console.WriteLine("Write the number of thetask you want to delete!");
                Console.WriteLine();
                check = Int32.TryParse(Console.ReadLine(), out taskDelete) && (taskDelete <= toDo.Length);
            }
            List<string> toDoList = toDo.ToList();                      //převede array na list (kvůli metodě listů .RemoveAt)
            toDoList.RemoveAt(taskDelete - 1);                          //odstraní index listu
            File.WriteAllLines(path, toDoList.ToArray());               //převede list na array a array zapíše do souboru
        }
        public void AddNewTask()
        {
            Console.WriteLine("Write new task:");
            string task = Console.ReadLine();
            while (task == "")                          //error handling: prázndé pole
            {
                Console.WriteLine("No task provided. Enter a task!");
                Console.WriteLine();
                task = Console.ReadLine();
            }
            string[] toDo = File.ReadAllLines(path);
            List<string> toDoList = toDo.ToList();
            toDoList.Add($" [ ] {task}");
            File.WriteAllLines(path, toDoList.ToArray());
        }
        public void ListAllTasks()
        {
            string[] toDo = File.ReadAllLines(path);
            List<string> toDoList = toDo.ToList();
            if (toDoList.Count > 0)
            {
                Console.WriteLine("List of tasks:");
                for (int a = 0; a < toDoList.Count; a++)
                {
                    Console.WriteLine($"{a + 1}. {toDo[a]}");
                }
            }
            else
            { Console.WriteLine("No todos for today!"); }
        }
    }
}
