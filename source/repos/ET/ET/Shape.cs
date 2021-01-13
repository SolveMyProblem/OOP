
using System;
using System.Collections.Generic;
using System.Drawing;


namespace ET
{
    public interface Line
    {
        public double distanceTwoPoint(Point a, Point b);
    }
    public interface Shapee
    {
            
        public double area();
        public double circuit();

    }      
    public class Rec : Shapee, Line
    {
        private int height;
        private int width;
        public Rec() { }

        public Rec(int height, int width)
        {
            if(height == 0 || width == 0) { throw new Exception("Value is not invalid !!!. Please enter positve numbers"); }
            this.Height = height;
            this.Width = width;
            
        }
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }

        public virtual List<Point> creatPoint(ref List<Point> lst)
        {
            Point p = new Point();
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Point " + (i + 1) + " :");
                Console.Write("x = ");
                string x = Console.ReadLine();
                p.X = Convert.ToInt32(x);
                Console.Write("y = ");
                string y = Console.ReadLine();
                p.Y = Convert.ToInt32(y);
                lst.Add(p);
            }
            return lst;
        }
        public virtual double area()
        {
            return Height * Width;
        }

        public virtual double circuit()
        {
            return (Height + Width) / 2;
        }

        public virtual double distanceTwoPoint(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.X - a.Y, 2));
        }
        public override string ToString()
        {
            return "Rectangle has height = " + Height + ", width = " + Width;

        }
    }
    public class Squa : Rec
    {
        public Squa() { }
        public Squa(int height)
        {
            base.Height = base.Width = height;

        }
        public Squa(int height, int width) : base(height, width)
        {
        }

        public override double area()
        {
            return Width * Height;

        }
        public override double circuit()
        {
            return 4 * Height;
        }
        public override double distanceTwoPoint(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.X - a.Y, 2));
        }
        public override List<Point> creatPoint(ref List<Point> lst)
        {
            return base.creatPoint(ref lst);
        }
        public override string ToString()
        {
            return "Square has edge = " + Height;

        }
    }
    public class Tritang : Shapee, Line
    {
        private double a;
        private double b;
        private double c;
        public Tritang() { }
        public Tritang(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 ) { throw new Exception("Value is not invalid !!!. Please enter positve numbers"); }
            this.a = a;
            this.b = b;
            this.c = c;
            if (!check())
            {
                throw new Exception("3 Points is Straight");
            }
        }
        public double A
        {
            get { return a; }
            set
            {
                a = value;
                if (value <= 0)
                {
                    throw new Exception("The length value be positive number ");
                }
            }
        }
        public double B {
            get { return b; }
            set
            {
                b = value;
                if (value <= 0)
                {
                    throw new Exception("The length value be positive number ");
                }
            }
        }
        public double C {
            get { return c; }
            set
            {
                c = value;
                if (value <= 0)
                {
                    throw new Exception("The length value be positive number ");
                }
            }
        }

        public bool check()
        {
            if (A + B > C && A + C > b && B + C > A)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void angle()
        {
            double cosA = (B * B + C * C - A * A) / (2 * B * C);
            double cosB = (A * A + C * C - B * B) / (2 * A * C);
            double cosC = (A * A + B * B - C * C) / (2 * A * B);

            Console.WriteLine("A = " + ((Math.Acos(cosA) * Math.PI) / 180) + " rad");
            Console.WriteLine("B = " + ((Math.Acos(cosB) * Math.PI) / 180) + " rad");
            Console.WriteLine("C = " + ((Math.Acos(cosC) * Math.PI) / 180) + " rad");
        }
        public override string ToString()
        {
            if (A == B && B == C && C == A)
            {
                return "This is Equilateral Triangle";
            }
            else if (A * A == B * B + C * C
                || B  * B == A * A + C * C
                || C * C == B * B + A * A)
            {
                return "This is Right Triangle";
            }
            else if (A == B || B == C || C == B)
            {
                return "This Isosceles Triangle";
            }
            else
            {
                return "This is Normal Triangle";
            }
        }
        public double area()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double circuit()
        {
            return A + B + C;
        }

        public double distanceTwoPoint(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.X - a.Y, 2));
        }
        

    }
    public class Cir : Shapee, Line
    {
        private Point o;
        private double radius;
        public Cir() { }
        public Cir(double radius)
        {
            if (radius <= 0) { throw new Exception("Value is not invalid !!!. Please enter positve numbers"); }
            this.radius = radius;
        }
        public Point O { get => o; set => o = value; }
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                if (value <= 0) { throw new Exception("The length value be positive number "); }
            }
        }

        public double area()
        {
            return Math.PI * Radius * Radius;
        }

        public double circuit()
        {
            return Math.PI * 2 * Radius;
        }

        public double distanceTwoPoint(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.X - a.Y, 2));
        }
        public bool belongCircle(Point p)
        {
            if(distanceTwoPoint(O, p) == Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Circle has radius = " + Radius;
        }
    }

   class Test
    {
        public static void Main()
        {
            Rec rec1 = new Rec(3, 4);
            Cir circle1 = new Cir(10);
            circle1.O = new Point(0, 2);
            Tritang tritang = new Tritang(3, 4, 5);
            Squa squa = new Squa(5);

            Console.WriteLine(rec1.ToString());
            Console.WriteLine("Area of Rectangle " +rec1.area());
            Console.WriteLine("Circuit of Rectangle " + rec1.circuit());
            Console.WriteLine();
            Console.WriteLine(circle1.ToString());
            Console.WriteLine("Area of Circle " + circle1.area());
            Console.WriteLine("Circuit of Circle " + circle1.circuit());
            Console.WriteLine();
            Console.WriteLine(tritang.ToString());
            Console.WriteLine("Area of Triangle " + tritang.area());
            Console.WriteLine("Circuit of Triangle " + tritang.circuit());
            Console.WriteLine();
            Console.WriteLine(squa.ToString());
            Console.WriteLine("Area of Square " + squa.area());
            Console.WriteLine("Circuit of Square " + squa.circuit());

        }
    }
}
