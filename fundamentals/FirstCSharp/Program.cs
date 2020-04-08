using System;

namespace FirstCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine("Value of i: {0}", i);
            }
            for (int num = 1; num < 101; num++)
            {
                if (num % 3 == 0 && num % 5 == 0)
                    Console.WriteLine("Value of num: {0}", num);
            }
            for (int num = 1; num < 101; num++)
            {
                if (num % 3 == 0)
                    Console.WriteLine("Fizz {0}", num);
                if (num % 5 == 0)
                    Console.WriteLine("Buzz {0}", num);
                if (num % 3 == 0 && num % 5 == 0)
                    Console.WriteLine("FizzBuzz {0}", num);
            }
            int nums = 1;
            while (nums < 256)
            {
                Console.WriteLine(nums);
                nums = nums + 1;
            }
        }
    }
}
