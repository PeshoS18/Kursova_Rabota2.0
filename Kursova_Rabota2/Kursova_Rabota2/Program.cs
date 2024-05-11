using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kursova_Rabota2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Изберете фигура за изчисляване:");
                Console.WriteLine("1. Правоъгълник");
                Console.WriteLine("2. Полигон");
                Console.WriteLine("3. Кръг");
                Console.WriteLine("4. Изход");

                Console.Write("Избери число:");
                int choice = int.Parse(Console.ReadLine());
                Shape shape = null;

                switch (choice)
                {
                    case 1:
                        shape = new Rectangle();
                        break;
                    case 2:
                        shape = new Polygon();
                        break;
                    case 3:
                        shape = new Circle();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Невалиден избор. Моля, изберете отново.");
                        continue;
                }

                shape.Input();
                shape.Output();
            }

        }
    }
}
