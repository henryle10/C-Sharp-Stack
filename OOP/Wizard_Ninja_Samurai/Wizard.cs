using System;

namespace Wizard_Ninja_Samurai
{
    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Intelligence = 25;
            Health = 50;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            int dmgHeal = Intelligence * 5;
            target.Intelligence -= dmgHeal;
            Health += dmgHeal;
            Console.WriteLine($"{Name} reduced {target.Name} intelligence by {dmgHeal}");
            Console.WriteLine($"{Name} healed {dmgHeal}");
            Console.WriteLine($"{target.Name} intelligence: {target.Intelligence}");
            Console.WriteLine($"{Name} Health: {Health}");
            Console.WriteLine($"{target.Name} Health:{target.Health}");
            return target.Intelligence;
        }
        public int Heal(Human target)
        {
            int heal = Intelligence * 10;
            target.Health += heal;
            Console.WriteLine($"{Name} Healed {target.Name} for {heal}");
            Console.WriteLine(target.Health);
            return target.Health;
        }
    }
}