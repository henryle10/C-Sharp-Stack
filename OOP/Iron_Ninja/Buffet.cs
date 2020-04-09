using System;
using System.Collections.Generic;

namespace Iron_Ninja
{
    class Buffet
    {
        public List<Food> Menu;
        public List<Drink> Drinks;

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
            Drinks = new List<Drink>()
        {
            new Drink("Coke", 200, false),
            new Drink("Sprite", 300, false),
            new Drink("Coffee", 100, false),
            new Drink("Rockstar", 50, true),
            new Drink("Orange Juice", 100, false),
        };
        }

        public Food Serve()
        {
            Random random = new Random();
            int index = random.Next(0, Menu.Count);
            System.Console.WriteLine(Menu[index].Name);
            return (Menu[index]);
        }
        public Drink OrderDrink()
        {
            Random random = new Random();
            int index = random.Next(0, Drinks.Count);
            System.Console.WriteLine(Drinks[index].Name);
            return (Drinks[index]);
        }
    }
}