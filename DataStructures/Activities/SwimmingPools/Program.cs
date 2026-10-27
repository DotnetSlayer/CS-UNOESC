using System.Collections.Generic;
using SwimmingPools;

public class Program  
{
    // Class that represents a Random Function  
    private static Random random = new Random();
    private static bool GetRandomBoolean()
    {
        return random.Next(2) == 1;
    }


    static void Main(string[] args)
    {
        // Dictionary with the Pool categories
        Dictionary<PoolTypeEnum, HashSet<int>> tickets = new Dictionary<PoolTypeEnum, HashSet<int>>()
        {
            {PoolTypeEnum.RECREATION, new HashSet<int>()},
            {PoolTypeEnum.COMPETITION, new HashSet<int>()},
            {PoolTypeEnum.THERMAL, new HashSet<int>()},
            {PoolTypeEnum.KIDS, new HashSet<int>()}
        };

        // Random number of tickets that will enter the Swimming Pools
        for(int i=1; i<100; i++)
        {
            foreach(KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
            {
                if(GetRandomBoolean())
                {
                    type.Value.Add(i);
                }
            }
        }

        // Prints the visitors in each pool type
        Console.WriteLine("Number of Visitors by a Pool type: ");
        foreach(KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
        {
            Console.WriteLine($" - {type.Key.ToString().ToLower()}:{type.Value.Count}");
        }


        // Selecting and randomizing the most popular pool
        PoolTypeEnum maxVisitors = tickets
        .OrderByDescending(t => t.Value.Count)
        .Select(t => t.Key)
        .FirstOrDefault();
        Console.WriteLine($"Pool '{maxVisitors.ToString().ToLower()}' was the most popular!");

        // Union of the sets
        HashSet<int> any =
        new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);
        any.UnionWith(tickets[PoolTypeEnum.COMPETITION]);
        any.UnionWith(tickets[PoolTypeEnum.THERMAL]);
        any.UnionWith(tickets[PoolTypeEnum.KIDS]);
        Console.WriteLine($"{any.Count} people visited at least one pool!");

        // Intersection of the sets
        HashSet<int> all =
        new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);
        all.IntersectWith(tickets[PoolTypeEnum.COMPETITION]);
        all.IntersectWith(tickets[PoolTypeEnum.THERMAL]);
        all.IntersectWith(tickets[PoolTypeEnum.KIDS]);
        Console.WriteLine($"{all.Count} people visited all Pools!");

    }
}