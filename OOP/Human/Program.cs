using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human("Henry", 10, 100, 100, 100);
            Human human2 = new Human("Justin", 5, 100, 100, 100);
            Console.WriteLine(human2.Health);
            human1.Attack(human2);
            Console.WriteLine(human2.Health);
        }
    }
}
