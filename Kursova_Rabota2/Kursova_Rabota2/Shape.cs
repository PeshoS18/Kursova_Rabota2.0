using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_Rabota2
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public abstract class Shape
    {
        public string Name { get; set; }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        public abstract void Input();
        public abstract void Output();
    }

    public class Rectangle : Shape
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public override double CalculateArea()
        {
            double width = Math.Abs(BottomRight.X - TopLeft.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            double width = Math.Abs(BottomRight.X - TopLeft.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            return 2 * (width + height);
        }

        public override void Input()
        {
            Console.WriteLine("Въведете горна-лява точка (x y):");
            string[] topLeftInput = Console.ReadLine().Split();
            double topLeftX = double.Parse(topLeftInput[0]);
            double topLeftY = double.Parse(topLeftInput[1]);
            TopLeft = new Point(topLeftX, topLeftY);

            Console.WriteLine("Въведете долна-дясна точка (x y):");
            string[] bottomRightInput = Console.ReadLine().Split();
            double bottomRightX = double.Parse(bottomRightInput[0]);
            double bottomRightY = double.Parse(bottomRightInput[1]);
            BottomRight = new Point(bottomRightX, bottomRightY);
        }

        public override void Output()
        {
            Console.WriteLine($"Правоъгълник: Площ = {CalculateArea()}, Периметър = {CalculatePerimeter()}");
        }
    }

    public class Polygon : Shape
    {
        public List<Point> Points { get; set; }

        public override double CalculateArea()
        {
            // Изчисляване на площ за полигон, ако приемем, че е обикновен полигон
            throw new NotImplementedException();
        }

        public override double CalculatePerimeter()
        {
            // Изчисляване на периметър за полигон
            // Сума от разстоянията между последователни точки
            double perimeter = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                Point current = Points[i];
                Point next = Points[(i + 1) % Points.Count]; // Обвиване до първата точка
                perimeter += Distance(current, next);
            }
            return perimeter;
        }

        private double Distance(Point a, Point b)
        {
            // Изчисляване на евклидовото разстояние между две точки
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        public override void Input()
        {
            Points = new List<Point>();
            Console.WriteLine("Въведете броя на точките в полигона:");
            int numPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < numPoints; i++)
            {
                Console.WriteLine($"Въведете точка {i + 1} (x y):");
                string[] pointInput = Console.ReadLine().Split();
                double x = double.Parse(pointInput[0]);
                double y = double.Parse(pointInput[1]);
                Points.Add(new Point(x, y));
            }
        }

        public override void Output()
        {
            Console.WriteLine($"Полигон: Периметър = {CalculatePerimeter()} (Изчислението на площта не е изпълнено)");
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override void Input()
        {
            Console.WriteLine("Въведете радиусът на гръга:");
            Radius = double.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            Console.WriteLine($"Кръг: Площ = {CalculateArea()}, Периметър = {CalculatePerimeter()}");
        }
    }
}
