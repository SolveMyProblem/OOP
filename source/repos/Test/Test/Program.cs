using System;

namespace Test
{
    abstract class Shape
    {
        public abstract double area();
        public abstract double circuit();
    }

    public class Triangle : Shape
    {
        private double leg1, leg2, leg3;

        public Triangle() { }
        public Triangle(double a, double b, double c)
        {
            this.leg1 = a;
            this.leg2 = b;
            this.leg3 = c;
        }

        public double Leg_1
        {
            get { return leg1; }
            set
            {
                leg1 = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }
        public double Leg_2
        {
            get { return leg2; }
            set
            {
                leg2 = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }
        public double Leg_3
        {
            get { return leg3; }
            set
            {
                leg3 = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }
        public static bool checkCondition(Triangle t)
        {
            if ((t.Leg_1 + t.Leg_2 > t.Leg_3) && (t.Leg_2 + t.Leg_3 > t.Leg_1) && (t.Leg_1 + t.Leg_3 > t.Leg_2))
            {
                return true;
            }
            else
            {
                throw new Exception("Wrong entered edges");
            }
        }

        public override double area()
        {
            double p = (Leg_1 + Leg_2 + Leg_3) / 2;
            return Math.Sqrt(p * (p - Leg_1) * (p - Leg_2) * (p - Leg_3));
        }
        public override double circuit()
        {

            return Leg_1 + Leg_2 + Leg_3;

        }
        public override string ToString()
        {
            if (Leg_1 == Leg_2 && Leg_2 == Leg_3 && Leg_3 == Leg_1)
            {
                return "Equilateral Triangle";
            }
            else if (Leg_1 * Leg_1 == Leg_2 * Leg_2 + Leg_3 * Leg_3
                || Leg_2 * Leg_3 == Leg_1 * Leg_1 + Leg_3 * Leg_3
                || Leg_3 * Leg_3 == Leg_2 * Leg_2 + Leg_1 * Leg_1)
            {
                return "Right Triangle";
            }
            else if (Leg_1 == Leg_2 || Leg_2 == Leg_3 || Leg_3 == Leg_2)
            {
                return "Isosceles Triangle";
            }
            else
            {
                return "Normal Triangle";
            }
        }
        public static void angle(Triangle t)
        {
            double cosA = (t.Leg_2 * t.Leg_2 + t.Leg_3 * t.Leg_3 - t.Leg_1 * t.Leg_1) / (2 * t.Leg_2 * t.Leg_3);
            double cosB = (t.Leg_1 * t.Leg_1 + t.Leg_3 * t.Leg_3 - t.Leg_2 * t.Leg_2) / (2 * t.Leg_1 * t.Leg_3);
            double cosC = (t.Leg_2 * t.Leg_2 + t.Leg_1 * t.Leg_1 - t.Leg_3 * t.Leg_3) / (2 * t.Leg_1 * t.Leg_2);

            Console.WriteLine("A = " + ((Math.Acos(cosA) * Math.PI) / 180) + " rad");
            Console.WriteLine("B = " + ((Math.Acos(cosB) * Math.PI) / 180) + " rad");
            Console.WriteLine("C = " + ((Math.Acos(cosC) * Math.PI) / 180) + " rad");
        }
    }
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle() { }
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }

            }
        }
        public override double area()
        {
            return Height * Width;
        }
        public override double circuit()
        {
            return (Height + Width) * 2;
        }
        public override string ToString()
        {
            return "Rectangle has height: " + Height + ", width: " + Width;
        }
    }
    class Square : Rectangle
    {
        public Square() { }
        public Square(double height)
        {
            base.Height = base.Width = height;

        }
        public override double area()
        {
            return Width * Height;

        }
        public override double circuit()
        {
            return 4 * Height;
        }
        public override string ToString()
        {
            return "Square has edge = " + Height;

        }

    }
    class Circle : Shape
    {
        private double radius;
        public Circle() { }
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Radius { get => radius; set => radius = value; }
        public override double area()
        {
            return Math.PI * Radius * Radius;
        }
        public override double circuit()
        {
            return Math.PI * 2 * Radius;
        }
        public override string ToString()
        {
            return "Circle has radius = " + Radius;
        }
    }
    class Tester
    {
        public static void Main()
        {
            Square square = new Square(4);
            Console.WriteLine(square.ToString());
        }
    }
}

