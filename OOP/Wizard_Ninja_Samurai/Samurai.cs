using System;

namespace Wizard_Ninja_Samurai
{
    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Health = 200;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.Health < 50)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} health was under 50 so {Name} killed {target.Name}");
            }
            return target.Health;
        }
        public void Meditate()
        {
            Health = 200;
            Console.WriteLine($"{Name} has meditated back to full Health");
            Console.WriteLine($"{Name} Health:{Health}");
        }
    }
}