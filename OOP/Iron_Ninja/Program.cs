using System;

namespace Iron_Ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet HomeTownBuffet = new Buffet();
            SweetTooth Hillary = new SweetTooth("Hillary");
            SpiceHound Henry = new SpiceHound("Henry");

            System.Console.WriteLine($"Ninja Name: {Henry.Name} Ninja Calories: {Henry.calorieIntake}");
            HomeTownBuffet.Serve();

            Henry.Consume(HomeTownBuffet.Serve());
            Henry.Consume(HomeTownBuffet.OrderDrink());
            Henry.Consume(HomeTownBuffet.Serve());
            Henry.Consume(HomeTownBuffet.OrderDrink());
            Hillary.Consume(HomeTownBuffet.Serve());
            Hillary.Consume(HomeTownBuffet.OrderDrink());
            Hillary.Consume(HomeTownBuffet.Serve());
            Hillary.Consume(HomeTownBuffet.OrderDrink());

            System.Console.WriteLine($"Ninja Name: {Henry.Name} Ninja Calories: {Henry.calorieIntake} Food/Drinks I Consume: {Henry.ConsumptionHistory.Count}");

            System.Console.WriteLine($"Ninja Name: {Hillary.Name} Ninja Calories: {Hillary.calorieIntake} Food/Drinks I Consume: {Hillary.ConsumptionHistory.Count}");

        }
    }
}
