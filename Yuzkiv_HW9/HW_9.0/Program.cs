﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shape = new List<Shape>();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Enter type: Circle or Square!");
                string typeString = Console.ReadLine();
                if (typeString == "Circle")
                {
                    Console.WriteLine("Enter name of Circle: ");
                    string circleName = Console.ReadLine();
                    Console.WriteLine("Enter radius: ");
                    int circleRadius = Convert.ToInt32(Console.ReadLine());

                    shape.Add(new Circle(circleName, circleRadius));
                }
                else if (typeString == "Square")
                {
                    Console.WriteLine("Enter name: ");
                    string squareName = Console.ReadLine();
                    Console.WriteLine("Enter side of Squere: ");
                    int sideSquere = Convert.ToInt32(Console.ReadLine());

                    shape.Add(new Square(squareName, sideSquere));
                }
                else
                {
                    Console.WriteLine("Not found shape!");
                }

            }

            foreach (Shape c in shape)
            {
                c.Print();
            }

            Console.WriteLine("___________________________________________________");

            string writePath = @"D:\Learn .Net\SoftServeHomeTasks\HW_9\AreaInRange.txt";
            string writeNewPath = @"D:\Learn .Net\SoftServeHomeTasks\HW_9\NamesWithA.txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.UTF8))
            {
                var areaInRange = shape.Where(x => x.Area() >= 10 && x.Area() <= 100);

                foreach (Shape item in areaInRange)
                {
                    sw.WriteLine($"{item.name} : {item.Area()}");
                }
            }

            using (StreamWriter sw = new StreamWriter(writeNewPath, false, Encoding.UTF8))
            {
                var word = shape.Where(o => o.name.Contains("a"));

                foreach (Shape item in word)
                {
                    sw.WriteLine($"{item.name}");
                }
            }

            var itemsToRemove = shape.Where(i => i.Perimetr() <= 5).ToList();

            foreach (var item in itemsToRemove)
            {
                Console.WriteLine($"{item.Name} - {item.Perimetr()}");
                shape.Remove(item);
            }
        }
    }
}
