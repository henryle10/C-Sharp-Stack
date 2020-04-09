using System;

namespace Iron_Ninja
{
    class SweetTooth : Ninja
    {
        public SweetTooth(string name) : base(name)
        {

        }
        public override bool IsFull
        {
            get
            {
                if (this.calorieIntake > 1500)
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
                Console.WriteLine($"{Name} consumed {item.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} is full");
            }
        }
    }
}