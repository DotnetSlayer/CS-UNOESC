using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleSort
{
    public static class BubbleSort
    {
        public static T[] Sort<T>(T[] array) where T : IComparable
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                bool isAnyChange = false;
                for(int j = 0; j < array.Length - 1; j++)
                {
                    if(array[j].CompareTo(array [j+1]) > 0)
                    {   
                        isAnyChange = true;
                        Swap(array, j, j + 1);
                    }
                }

                if(!isAnyChange)
                {
                    break;
                }
            }

            return array;
        }

        public static void Swap<T>(T[] array, int first, int second)
        {
            T temp = array [first];
            array [first] = array [second];
            array [second] = temp;
        }

        public static void Print<T>(T[] array)
        {
            Console.Write('[');

            foreach (T i in array)
            {
                Console.Write($"{i} ");

            }

            Console.Write(']');

        }
    }
}