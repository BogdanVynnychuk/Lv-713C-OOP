﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShokunHW6
{
    internal class Program
    {
        static void Main(string[] args)
        {
        label2:
            int[] numbers = new int[10];
            Console.WriteLine("Enter start number");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter end number");
            int end = Convert.ToInt32(Console.ReadLine());
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    int input = ReadNumber(start, end);
                    if(input < start) { throw new ArgumentOutOfRangeException($"Number must be greater than {start}"); }
                    if(input > end) { throw new ArgumentOutOfRangeException($"Number must be less than {end}"); }
                    numbers[i] = input;
                    start = input;
                }
                foreach(int i in numbers)
                {
                    Console.WriteLine(i);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                goto label2;
            }

            Console.ReadKey();

        }

        public static int ReadNumber(int start, int end)
        {
        label1:
            Console.WriteLine($"Enter a number greater than {start} and less than {end}");
            var number = Console.ReadLine();
            if (int.TryParse(number, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter an integer");
                goto label1;
            }
        }

    }
}
