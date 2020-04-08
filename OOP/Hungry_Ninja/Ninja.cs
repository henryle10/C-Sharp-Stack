using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{
    public class Ninja
    {
        public string Name { get; set; }
        private int _calorieIntake { get; set; }
        public List<Food> FoodHistory;
        public int CalorieIntake { get { return _calorieIntake; } }


        // add a constructor
        public Ninja(string name)
        {
            Name = name;
            _calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull"
        public bool IsFull
        {
            get
            {
                if (this._calorieIntake > 1200)
                {
                    return true;
                }
                return false;
            }

        }


        // build out the Eat method
        public void Eat(Food item)
        {
            if (this.IsFull == false)
            {
                this._calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine("Calories:" + item.Calories);
                Console.WriteLine("I ate " + item.Name);
                string phrase = item.Name;
                if (item.IsSpicy)
                {
                    phrase += " is spicy";
                }
                if (item.IsSweet)
                {
                    phrase += " is sweet";
                }
                System.Console.WriteLine(phrase);
            }
            else
            {
                Console.WriteLine("I'm full");
            }
        }
    }
}