using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Creating and initializing a HashSet
HashSet<int> usedCoupons = new HashSet<int>();

do
{
    // The program will interact and ask the user to enter a coupon
    Console.Write("Enter the coupon number: ");
    string couponString = Console.ReadLine();

    if(int.TryParse(couponString, out int coupon))
    {
        // If the coupon is already used, it will inform the user
        if(usedCoupons.Contains(coupon))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It has been already used :(");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // If the coupon is not used yet, it will be used and then added to the set of used coupons
        else
        {
            usedCoupons.Add(coupon);
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Thank You! :)");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    else
    {
        break;
    }

}

while(true);

// Prints the list of used coupons at the end of the program execution
Console.WriteLine();
Console.WriteLine("A list of used Coupons: ");

foreach(int coupon in usedCoupons)
{
    Console.WriteLine("" + coupon);
}