using System;
using System.Collections.Generic;

namespace Puzzle
{
    class Program
    {

        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values
        public static void RandomArray()
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randInt = random.Next(5, 25);
                array[i] = randInt;
                Console.WriteLine(array[i]);
            }
        }

        public static string TossCoin()
        {
            Random random = new Random();
            int randNum = random.Next(0, 2);
            string result = "";
            if (randNum == 0)
            {
                Console.WriteLine("Heads");
                result = "Heads";
            }
            if (randNum == 1)
            {
                Console.WriteLine("Tails");
                result = "Tails";
            }
            return result;
        }

        public static double TossMultipleCoin(int num)
        {
            double headCount = 0;
            int tailCount = 0;
            for (int i = 0; i < num; i++)
            {
                string result = TossCoin();
                if (result == "Heads")
                {
                    headCount++;
                }
                if (result == "Tails")
                {
                    tailCount++;
                }
            }
            Console.WriteLine(headCount / num);
            return headCount / num;
        }

        public static List<string> RandomNames()
        {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiff");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            Random random = new Random();
            for (int i = 0; i < names.Count; i++)
            {
                int randIndex = random.Next(0, names.Count);
                string temp = names[randIndex];
                names[randIndex] = names[i];
                names[i] = temp;
            }
            Console.WriteLine(string.Join(", ", names));
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i].Length < 6)
                {
                    names.RemoveAt(i);
                }
            }
            Console.WriteLine(string.Join(", ", names));
            return names;
        }



        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoin(10);
            RandomNames();
        }
    }
}
