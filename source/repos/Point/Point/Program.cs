using System;

namespace Point
{
    public class Point
    {
        private double x;
        private double y;
        public Point() { }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public static double distanceBetweenTwoPoint(Point p1, Point p2)
        {
            double d = Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
            return d;
        }
        public static Point vector(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p2.x - p1.x;
            p.y = p2.y - p1.y;
            return p;
        }
        public static bool direction(Point p1, Point p2, Point p3) {
            double k1 = (double)(p2.x - p1.x / p3.x - p2.x);
            double k2 = (double)(p2.y - p1.y / p3.y - p2.y);
            if(k1 == k2)
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
            return "<" + X + ", " + Y + ">";
        }
    }
    public abstract class Shape
    { 

        public abstract double area();
        public abstract double perimeter();
    }
    public class Rectangle : Shape{
        private Point p1;
        private Point p2;
        private Point p3;
        private Point p4;
        public Rectangle() { }
        public Rectangle(Point p1, Point p2, Point p3, Point p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }
        internal Point P1 { get => p1; set => p1 = value; }
        internal Point P2 { get => p2; set => p2 = value; }
        internal Point P3 { get => p3; set => p3 = value; }
        internal Point P4 { get => p4; set => p4 = value; }

        public override double area()
        {
            return Point.distanceBetweenTwoPoint(P1, P2) * Point.distanceBetweenTwoPoint(P2, P3);
        }

        public override double perimeter()
        {
            return (Point.distanceBetweenTwoPoint(P1, P2) + Point.distanceBetweenTwoPoint(P2, P3)) * 2;
        }
        public class Square : Rectangle
        {
            public override double area()
            {
                return base.area();
            }
            public override double perimeter()
            {
                return base.perimeter();
            }
        }

    }
    class Triangle : Shape
    {
        Point p1;
        Point p2;
        Point p3;
        public Triangle() { }
        public Triangle(Point p1, Point p2, Point p3)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.P3 = p3;
        }

        public Point P1 { get => p1; set => p1 = value; }
        public Point P2 { get => p2; set => p2 = value; }
        public Point P3 { get => p3; set => p3 = value; }

        public bool checkCondition()
        {
            if(Point.direction(P1, P2, P3))
            {
                return true;
            }
            else
            {
                throw new Exception("Invalid");
            }
        }
        public override double area()
        {
            throw new NotImplementedException();
        }

        public override double perimeter()
        {
            throw new NotImplementedException();
        }
    }
    class Tester
    {
        public static void Main()
        {
            Rectangle rec1 = new Rectangle();
            rec1.P1 = new Point(3, 4);
            
        }
    }
}
