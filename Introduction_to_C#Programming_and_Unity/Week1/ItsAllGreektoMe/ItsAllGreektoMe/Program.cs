using System;

namespace ItsAllGreektoMe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double x1, y1, x2, y2;
            Function function = new Function();

            Console.WriteLine("Welcome! You could enter the coordinates of two points and get the distance and angle between them!");
            Console.WriteLine("Point 1 X :");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 1 Y :");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 2 X :");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Point 2 X :");
            y2 = Convert.ToDouble(Console.ReadLine());

            function.CalculateDistance(x1, y1, x2, y2);
            function.CalculateAngle(x1, y1, x2, y2);
        }
    }


    class Function
    {
        public double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double xDistance = Math.Pow(x2 - x1, 2);
            double yDistance = Math.Pow(y2 - y1, 2);
            double finalDistance = Math.Sqrt(xDistance + yDistance);
            Console.WriteLine("Distance between points:" + finalDistance);
            return finalDistance;
        }

        public double CalculateAngle(double x1,double y1,double x2,double y2)
        {
            double angle = Math.Atan2((y2 - y1), (x2 - x1)) * 180 / Math.PI;
            Console.WriteLine("Angle between points:" + angle);
            return angle;
        }


    }
}