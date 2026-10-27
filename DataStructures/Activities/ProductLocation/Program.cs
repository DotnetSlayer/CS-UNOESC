using System;
using System.Collections;

namespace ProductLocation
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creating and initializing a dictionary
            Dictionary<string, string> productLocations = new Dictionary<string,string>
            {
                // Adding key-value pairs to the dictionary
                {"1001", "A1"},
                {"1002", "A2"},
                {"1003", "A3"},
                {"1004", "A4"},
                {"1005", "A5"},
                {"1006", "A6"},
                {"1007", "A7"},
                {"1008", "A8"},
                {"1009", "A9"}

            };

            // Adding a new key-value pair to the dictionary
            productLocations["2001"] = "B1";
            productLocations["2002"] = "B2";
            productLocations["2003"] = "B3";
            productLocations["2004"] = "B4";
            productLocations["2005"] = "B5";
            productLocations["2006"] = "B6";
            productLocations["2007"] = "B7";
            productLocations["2008"] = "B8";
            productLocations["2009"] = "B9";

            try
            {
                // Adding a key-value pair to the dictionary with a different method 
                productLocations.Add("3001", "C1");
                productLocations.Add("3002","C2");
                productLocations.Add("3003","C3");
                productLocations.Add("3004","C4");
                productLocations.Add("3005","C5");
                productLocations.Add("3006","C6");
                productLocations.Add("3007","C7");
                productLocations.Add("3008","C8");
                productLocations.Add("3009","C9");
            }
            catch (ArgumentException)
            {
                // If the key already exists, catch the exception and display a message
                Console.WriteLine("Product already exists!");
            }

            Console.WriteLine("All Products: ");

            // If there are no products, display a message
            if(productLocations.Count == 0)
            {
                Console.WriteLine("No products found!");
            }

            else
            {
                // Iterate through the dictionary and display the key-value pairs
                foreach (KeyValuePair<string, string> product in productLocations)
                {
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.WriteLine($"Product ID: {product.Key}, Location: {product.Value}");
                }
            }

            Console.WriteLine();

            // Search manually for a product with the ID
            Console.WriteLine("Search by Product ID: ");
            string productId = Console.ReadLine();

            if(productLocations.TryGetValue(productId, out string location))
            {
                // If the product is found, display the location
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The product is located at {location}.");
            }

            else
            {
                // If the product is not found, display a message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found!");
            }
        }
    }
}