using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> data = new List<object>();
            data.Add(7);
            data.Add(28);
            data.Add(-1);
            data.Add(true);
            data.Add("chair");

            foreach (object entry in data)
            {
                Console.WriteLine(entry);
            }
            var sum = 0;
            foreach (object entry in data)
            {
                if (entry is int)
                {
                    sum = (int)entry + sum;
                    Console.WriteLine(sum);
                }
            }
        }
    }
}

