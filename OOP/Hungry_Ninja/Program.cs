using System;

namespace Hungry_Ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet Resturant = new Buffet();
            Resturant.Serve();
            Ninja Henry = new Ninja("Henry");
            System.Console.WriteLine($"Ninja Name: {Henry.Name} Ninja Calories: {Henry.CalorieIntake}");

            Henry.Eat(Resturant.Serve());
            Henry.Eat(Resturant.Serve());
            Henry.Eat(Resturant.Serve());
            Henry.Eat(Resturant.Serve());

            System.Console.WriteLine($"Ninja Name: {Henry.Name} Ninja Calories: {Henry.CalorieIntake}");
        }
    }
}
