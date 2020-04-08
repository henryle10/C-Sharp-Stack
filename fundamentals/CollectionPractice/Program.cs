using System;
using System.Collections.Generic;

namespace CollectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] names = new string[] { "Tim", "Martin", "Nikki", "Sara" };
            foreach (string name in names)
            {
                Console.WriteLine($"these are the names:{name}");
            }
            bool[] numArray2 = new bool[10];
            for (int i = 0; i < numArray2.Length; i++)
            {
                numArray2[0] = true;
                numArray2[1] = false;
                numArray2[2] = true;
                numArray2[3] = false;
                numArray2[4] = true;
                numArray2[5] = false;
                numArray2[6] = true;
                numArray2[7] = false;
                numArray2[8] = true;
                numArray2[9] = false;
                Console.WriteLine(numArray2[i]);
            }
            List<string> flavors = new List<string> { "bithday cake" };
            flavors.Add("chocolate");
            flavors.Add("mint");
            flavors.Add("vanilla");
            flavors.Add("pistachio");
            flavors.Add("strawberry");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            var random = new Random();
            var list = flavors;

            Dictionary<string, string> profile = new Dictionary<string, string>();
            profile.Add(names[0], list[random.Next(list.Count)]);
            profile.Add(names[1], list[random.Next(list.Count)]);
            profile.Add(names[2], list[random.Next(list.Count)]);
            profile.Add(names[3], list[random.Next(list.Count)]);
            foreach (var entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
