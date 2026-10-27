using System;
using System.Collections;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating and initializing the phone book
            Hashtable phoneBook = new Hashtable();

            // Adding some entries to the phone book
            phoneBook.Add("Marcin Jamro", "000-000-000");
            phoneBook.Add("John Smith", "111-111-111");
            phoneBook.Add("Lilly Smith", "333-333-333");

            // Another form of adding entries to the phone book
            try
            {
                phoneBook.Add("Mary Fox", "222-222-222");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This contact already exists!");
            }

            // Displaying the phone book
            Console.WriteLine("Phone Numbers:");


            // Checking if the phone book is empty
            if (phoneBook.Count == 0)
            {
                Console.WriteLine("Phone book is empty!");
            }

            // Displaying the phone book entries
            else
            {
                foreach (DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($"{entry.Key} - {entry.Value}");
                }
            }

            // System that searches for a contact by a name typed by the user
            Console.WriteLine();
            Console.Write("Search by Name: ");
            string name = Console.ReadLine();

            // Checks if the name searched is in the phone book
            if (phoneBook.ContainsKey(name))
            {
                string number = (string)phoneBook[name];
                Console.WriteLine($"Found phone number: {number}");
            }

            // If the name is not in the phone book
            else
            {
                Console.WriteLine("This contact does not exist!"); 
            }
        }
    }
}

