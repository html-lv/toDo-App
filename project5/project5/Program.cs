using System;
using System.Collections.Generic;
using static Task;

public class Task
{
    public string Description { get; set; }
    public bool IsDone { get; set; }

    public Task(string description)
    {
        Description = description;
        IsDone = false;
    }

    public override string ToString()
    {
        return $"{(IsDone ? "[Done]" : "[Not Done]")} {Description}";
    }

public class ToDoList
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(string description)
    {
        tasks.Add(new Task(description));
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the list.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    public void MarkTaskAsDone(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsDone = true;
        }
    }

    public void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
    }
   }
class Program
{
    static void Main()
    {
        ToDoList toDoList = new ToDoList();

        while (true)
        {
            Console.WriteLine("To-Do List Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Done");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice)) {
                switch (choice) {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        toDoList.AddTask(description);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Tasks:");
                        toDoList.ViewTasks();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter task index to mark as done: ");
                        if (int.TryParse(Console.ReadLine(), out int doneIndex))
                        {
                            toDoList.MarkTaskAsDone(doneIndex - 1);
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Enter task index to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeIndex)) {
                            toDoList.RemoveTask(removeIndex - 1);
                        }
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}

}
