using System;

namespace Wizard_Ninja_Samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Henry = new Wizard("Henry");
            Wizard Justin = new Wizard("Justin");
            Ninja Jimmy = new Ninja("Jimmy");
            Samurai Scott = new Samurai("Scott");

            Henry.Attack(Justin);
            Jimmy.Attack(Henry);
            Henry.Heal(Jimmy);
            Scott.Attack(Jimmy);
            Jimmy.Attack(Scott);
            Scott.Meditate();
            Jimmy.Steal(Scott);
        }
    }
}
