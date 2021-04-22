using System;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point();
            Console.WriteLine($"Setting coordinates for Point #{point1.GetID()}");
            Console.Write("x = ");
            point1.SetX(int.Parse(Console.ReadLine()));
            Console.Write("y = ");
            point1.SetY(int.Parse(Console.ReadLine()));

            Console.WriteLine();

            Point point2 = new Point();
            Console.WriteLine($"Setting coordinates for Point #{point2.GetID()}");
            Console.Write("x = ");
            point2.SetX(int.Parse(Console.ReadLine()));
            Console.Write("y = ");
            point2.SetY(int.Parse(Console.ReadLine()));

            Console.WriteLine();

            new Segment(point1, point2);


        }
    }

    class Point
    {
        private static int COUNTER = 0;
        private int x, y,id;
        public Point()
        {
            this.id = ++COUNTER;
            this.x = 0;
            this.y = 0;
            Console.WriteLine($"Created Point #{this.id}");
        }
        public int GetID()
        {
            return this.id;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public int GetX()
        {
            return this.x;
        }
        public int GetY()
        {
            return this.y;
        }

        public override string ToString()
        {
            return $"Point #{this.id}({this.x},{this.y})";
        }
    }

    class Segment
    {
        private static int COUNTER = 0;
        private int id;
        private Point point1, point2;

        public Segment(Point point1,Point point2)
        {
            this.id = ++COUNTER;
            this.point1 = point1;
            this.point2 = point2;
            Console.WriteLine($"Created Segment #{this.id} with edges: {this.point1.ToString()} , {this.point2.ToString()}");
        }
        public int GetID()
        {
            return this.id;
        }
        public void SetPoint1(Point p)
        {
            this.point1 = p;
        }
        public void SetPoint2(Point p)
        {
            this.point2 = p;
        }
        public Point GetPoint1()
        {
            return this.point1;
        }
        public Point GetPoint2()
        {
            return this.point2;
        }
    }
}
