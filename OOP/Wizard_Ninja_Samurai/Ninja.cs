using System;

namespace Wizard_Ninja_Samurai
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
            Health = 100;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            Random rand = new Random();
            if (rand.Next(1, 6) == 1)
            {
                target.Health -= 10;
                Console.WriteLine($"{Name} attacked {target.Name} for an additional 10 points");
            }
            int dmgDex = Dexterity * 5;
            target.Dexterity -= dmgDex;
            Console.WriteLine($"{Name} reduced {target.Name} Dexterity by {dmgDex}");
            Console.WriteLine($"{target.Name} Health:{target.Health}");
            return dmgDex;
        }
        public int Steal(Human target)
        {
            int steal = 5;
            target.Health -= steal;
            Health += steal;
            Console.WriteLine($"{Name} stole {target.Name} Health by 5");
            Console.WriteLine($"{Name} Health: {Health}");
            Console.WriteLine($"{target.Name} Health: {target.Health}");
            return Health;
        }
    }
}