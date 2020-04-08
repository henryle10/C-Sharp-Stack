using System;

namespace Basic_13
{
    class Program
    {
        public static void PrintNumbers()
        {
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void PrintOdds()
        {
            for (int nums = 0; nums < 256; nums++)
            {
                if (nums % 2 == 1)
                {
                    Console.WriteLine(nums);
                }
            }
        }

        public static void PrintSum()
        {
            var sum = 0;
            for (int nums = 0; nums < 256; nums++)
            {
                sum += nums;
                Console.WriteLine($"New number:{nums} Sum: {sum}", nums, sum);
            }
        }

        public static void LoopArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);

            }
        }

        public static void FindMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine("Max is:" + max);
        }

        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            double avg = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            avg = sum / numbers.Length;
            Console.WriteLine("Average is:" + avg);
        }

        public static int[] OddArray()
        {
            int[] answer = new int[128];

            for (int i = 0; i <= 255; i++)
            {
                for (int j = 1; j <= 128; j++)
                {
                    if (i % 2 != 0)
                    {
                        System.Console.WriteLine("oddArray" + i);
                        answer[j] = i;
                        break;
                    }
                }
            }
            return answer;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            return count;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
                Console.WriteLine(numbers[i]);
            }
        }

        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = numbers[i] * -1;
                }
                Console.WriteLine(numbers[i]);
            }
        }

        public static void MinMaxAverage(int[] numbers)
        {
            int sum = 0;
            int max = numbers[0];
            int min = numbers[0];
            double avg = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                sum += numbers[i];
            }
            avg = sum / numbers.Length;
            Console.WriteLine($"max: {max} avg: {avg} min: {min}");
        }

        public static void ShiftValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];

            }
            numbers[numbers.Length - 1] = 0;
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
        }

        public static object[] NumToString(int[] numbers)
        {
            object[] str = new object[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    str[i] = "Dojo";
                }
                else
                {
                    str[i] = numbers[i];
                }
            }
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
            return str;
        }

        static void Main(string[] args)
        {
            PrintNumbers();
            PrintOdds();
            PrintSum();
            int[] arr = { -2, 7, -6, 30, 0 };
            int[] arr2 = { 1, 5, 10, -2 };
            int[] arr3 = { 1, -5, -50, -2 };

            LoopArray(arr);
            FindMax(arr);
            GetAverage(arr);
            OddArray();
            GreaterThanY(arr, 0);
            SquareArrayValues(arr);
            EliminateNegatives(arr2);
            MinMaxAverage(arr2);
            ShiftValues(arr2);
            NumToString(arr3);
        }
    }
}
