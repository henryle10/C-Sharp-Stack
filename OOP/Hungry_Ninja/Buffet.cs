using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{
    public class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
        {
            new Food("BQQ Chicken", 1000, true, false),
            new Food("Chow Mein", 500, false, false),
            new Food("Hamburger", 800, true, true),
            new Food("Pho", 2000, false, true),
            new Food("Rice", 100, false, false),
            new Food("Clam Chowder", 200, false, false),
            new Food("Lobster", 3000, true, false)
        };
        }

        public Food Serve()
        {
            Random random = new Random();
            int index = random.Next(0, 7);
            System.Console.WriteLine(Menu[index].Name);
            return (Menu[index]);
        }
    }
}