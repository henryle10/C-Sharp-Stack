using System;

namespace Iron_Ninja
{
    class SpiceHound : Ninja
    {
        public SpiceHound(string name) : base(name)
        {
            calorieIntake = calorieIntake;
        }
        public override bool IsFull
        {
            get
            {
                if (this.calorieIntake > 1200)
                {
                    return true;
                }
                return false;
            }
        }
        public override void Consume(IConsumable item)
        {
            if (this.IsFull == false)
            {
                this.calorieIntake += item.Calories;
                ConsumptionHistory.Add(item);
                Console.WriteLine("Calories:" + item.Calories);
                Console.WriteLine($"{Name} {item.Name}");

            }
            else
            {
                Console.WriteLine($"{Name} is full");
            }
        }
    }
}