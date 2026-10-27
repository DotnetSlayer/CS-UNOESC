// Creating and initializing the Sorted Dictionary
SortedDictionary<string, string> encyclopedia = new SortedDictionary<string, string>();

// Displaying the menu
do
{
    Console.Write("Choose an Option ([A] - Add, [L] - List) ");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    Console.WriteLine();

    // Adding an entry and definition
    if(keyInfo.Key == ConsoleKey.A)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter the Name of the Entry: ");
        string name = Console.ReadLine();
        Console.Write("Enter the Definition of the Entry: ");
        string definition = Console.ReadLine();
        encyclopedia[name] = definition;
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    // Listing all entries and definitions
    else if(keyInfo.Key == ConsoleKey.L)
    {
        Console.ForegroundColor = ConsoleColor.White;

        foreach(KeyValuePair<string, string> entry in encyclopedia)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    // Exiting and shutting down the program
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Do you want to Exit the program? (Y/N)");
        Console.ForegroundColor = ConsoleColor.Gray;

        if(Console.ReadKey().Key == ConsoleKey.Y)
        {
            Environment.Exit(0);
        }
    }
}

while(true);
