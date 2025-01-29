//christopher hercules, lab 3, 1/29/2025

class Task
{
    public int ID { get; set; }  
    public string Title { get; set; }  
    public string Description { get; set; }  
    public bool IsComplete { get; set; }  

    public Task(int id, string title, string description)
    {
        ID = id;
        Title = title;
        Description = description;
        IsComplete = false; // Default new tasks as incomplete
    }

    // (used in task list)
    public void DisplayTask()
    {
        string status = IsComplete ? "[X]" : "[ ]";  
        Console.WriteLine($"{status} {ID}  {Title}");
    }

    // details of a task
    public void DisplayDescription()
    {
        Console.WriteLine($"Task ID: {ID}\nTitle: {Title}\nDescription: {Description}\nCompleted: {IsComplete}");
    }

    //  task completion status
    public void ToggleCompletion()
    {
        IsComplete = !IsComplete; // true/false
    }
}

class Program
{
    static int nextID = 1;  // tracks the next unique ID for new tasks

    static void Main()
    {
        List<Task> taskList = new List<Task>();  // Store tasks 

        while (true)  // user interaction
        {
            Console.Clear();  // clean UI each cycle
            Console.WriteLine("    ID  Task");
            Console.WriteLine("-----------------------------------");
            foreach (var task in taskList)  // loop through all tasks display them
            {
                task.DisplayTask();
            }

            // Instructions for user interaction
            Console.WriteLine("\nPress '+' to add a task, 'x' to toggle completion, 'i' for task info, or 'q' to quit.");
            ConsoleKey key = Console.ReadKey(true).Key;  // reads the key input without displaying it

            if (key == ConsoleKey.OemPlus || key == ConsoleKey.Add)  // Handles both '+' keys
            {
                Console.Write("Enter task title: ");
                string title = Console.ReadLine();
                Console.Write("Enter task description: ");
                string description = Console.ReadLine();
                
                // Add new task with unique ID, then increment `nextID`
                taskList.Add(new Task(nextID++, title, description));
            }
            else if (key == ConsoleKey.X)  // Toggle task completion
            {
                Console.Write("Enter task ID to toggle completion: ");
                if (int.TryParse(Console.ReadLine(), out int id))  // Check if input is a valid integer
                {
                    Task task = taskList.Find(t => t.ID == id);  // Search for task by ID
                    if (task != null) task.ToggleCompletion();  // Toggle if found
                }
            }
            else if (key == ConsoleKey.I)  // Display task 
            {
                Console.Write("Enter task ID for more info: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Task task = taskList.Find(t => t.ID == id);  // Search for task by ID
                    if (task != null)
                    {
                        Console.Clear();
                        task.DisplayDescription();  // Show full details
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();  // Wait for user input before returning to the list
                    }
                }
            }
            else if (key == ConsoleKey.Q)  // Quit the program
            {
                break;  // Exit loop 
            }
        }
    }
}
