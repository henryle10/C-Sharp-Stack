using System;
using System.Collections.Generic;

namespace Iron_Ninja
{
    abstract class Ninja
    {
        public virtual string Name { get; set; }
        public int calorieIntake { get; set; }
        public List<IConsumable> ConsumptionHistory;
        public Ninja(string name)
        {
            Name = name;
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        public abstract bool IsFull { get; }
        public abstract void Consume(IConsumable item);
    }
}