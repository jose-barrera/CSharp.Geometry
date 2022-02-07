using System;

namespace Geometry
{
    internal class Program
    {
        static void TestingClassPoint()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("***   CLASS Point   ***");
            Console.WriteLine("***********************");
            Console.WriteLine();
            Console.WriteLine("1. Create the origin point");
            Point pointA = new Point();
            Console.WriteLine("   (" + pointA.X + "," + pointA.Y + ")");
            Console.WriteLine();
            Console.WriteLine("2. Create the point in -3.4 y 4.35");
            Point pointB = new Point(-3.4, 4.35);
            Console.WriteLine("   (" + pointB.X + "," + pointB.Y + ")");
            Console.WriteLine();
            Console.WriteLine("3. Calculate distance between them");
            Console.WriteLine("   " + pointA.DistanceTo(pointB));
            Console.WriteLine();
            Console.WriteLine("4. Move both points 1.4 right and 3.7 down");
            pointA.Translate(1.4, -3.7);
            pointB.Translate(1.4, -3.7);
            Console.WriteLine("   (" + pointA.X + "," + pointA.Y + ")");
            Console.WriteLine("   (" + pointB.X + "," + pointB.Y + ")");
            Console.WriteLine();
            Console.WriteLine("5. Calculate distance again");
            Console.WriteLine("   " + pointA.DistanceTo(pointB));
            Console.WriteLine();
            Console.WriteLine();
        }

        static void TestingClassCircle()
        {
            Console.WriteLine("************************");
            Console.WriteLine("***   CLASS Circle   ***");
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine("1. Create circle in (-3,-7.4) with 3.77 radius");
            Point center = new Point(-3, -7.4);
            Circle circle = new Circle(center, 3.77);
            Console.WriteLine();
            Console.WriteLine("2. Print its information");
            Console.WriteLine("   Center: (" + circle.Center.X + "," + circle.Center.Y + ")");
            Console.WriteLine("   Radius: " + circle.Radius);
            Console.WriteLine("   Diameter: " + circle.Diameter);
            Console.WriteLine("   Area: " + circle.Area);
            Console.WriteLine("   Perimeter: " + circle.Perimeter);
            Console.WriteLine();
            Console.WriteLine("3. Move its center to (3,3) and after move its center 1.4 right and 3.7 down");
            circle.Translate(new Point(3,3));
            circle.Translate(1.4, -3.7);
            Console.WriteLine();
            Console.WriteLine("4. Print its information");
            Console.WriteLine("   Center: (" + circle.Center.X + "," + circle.Center.Y + ")");
            Console.WriteLine("   Radius: " + circle.Radius);
            Console.WriteLine("   Diameter: " + circle.Diameter);
            Console.WriteLine("   Area: " + circle.Area);
            Console.WriteLine("   Perimeter: " + circle.Perimeter);
            Console.WriteLine();
            Console.WriteLine("5. Resize its radius to 10");
            circle.Resize(10);
            Console.WriteLine();
            Console.WriteLine("6. Print its information");
            Console.WriteLine("   Center: (" + circle.Center.X + "," + circle.Center.Y + ")");
            Console.WriteLine("   Radius: " + circle.Radius);
            Console.WriteLine("   Diameter: " + circle.Diameter);
            Console.WriteLine("   Area: " + circle.Area);
            Console.WriteLine("   Perimeter: " + circle.Perimeter);
            Console.WriteLine();
            Console.WriteLine();
        }

        static void TestingClassEllipse()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("***   CLASS Ellipse   ***");
            Console.WriteLine("*************************");
            Console.WriteLine();
            Console.WriteLine("1. Create an horizontal ellipse with center in (7.5, -2.3),");
            Console.WriteLine("   semi-major axis 3.5, and semi-minor axis 2");
            Point center = new Point(7.5, -2.3);
            Ellipse ellipse = new Ellipse(center, 3.5, 2, "Horizontal");
            Console.WriteLine();
            Console.WriteLine("2. Print its information");
            Console.WriteLine("   Center: (" + ellipse.Center.X + "," + ellipse.Center.Y + ")");
            Console.WriteLine("   Semi-major axis: " + ellipse.SemiMajorAxis);
            Console.WriteLine("   Semi-minor axis: " + ellipse.SemiMinorAxis);
            Console.WriteLine("   Orientation: " + ellipse.Orientation);
            Console.WriteLine("   Eccentricity: " + ellipse.Eccentricity);
            Console.WriteLine("   Area: " + ellipse.Area);
            Console.WriteLine("   Perimeter: " + ellipse.Perimeter);
            Console.WriteLine("   Focus 1: (" + ellipse.Focus1.X + "," + ellipse.Focus1.Y + ")");
            Console.WriteLine("   Focus 2: (" + ellipse.Focus2.X + "," + ellipse.Focus2.Y + ")");
            Console.WriteLine("   Vertex 1: (" + ellipse.Vertex1.X + "," + ellipse.Vertex1.Y + ")");
            Console.WriteLine("   Vertex 2: (" + ellipse.Vertex2.X + "," + ellipse.Vertex2.Y + ")");
            Console.WriteLine("   Covertex 1: (" + ellipse.Covertex1.X + "," + ellipse.Covertex1.Y + ")");
            Console.WriteLine("   Covertex 2: (" + ellipse.Covertex2.X + "," + ellipse.Covertex2.Y + ")");
            Console.WriteLine();
            Console.WriteLine("3. Move the ellipse 1.4 right and 3.7 down");
            ellipse.Translate(1.4, -3.7);
            Console.WriteLine();
            Console.WriteLine("4. Print its information");
            Console.WriteLine("   Center: (" + ellipse.Center.X + "," + ellipse.Center.Y + ")");
            Console.WriteLine("   Semi-major axis: " + ellipse.SemiMajorAxis);
            Console.WriteLine("   Semi-minor axis: " + ellipse.SemiMinorAxis);
            Console.WriteLine("   Orientation: " + ellipse.Orientation);
            Console.WriteLine("   Eccentricity: " + ellipse.Eccentricity);
            Console.WriteLine("   Area: " + ellipse.Area);
            Console.WriteLine("   Perimeter: " + ellipse.Perimeter);
            Console.WriteLine("   Focus 1: (" + ellipse.Focus1.X + "," + ellipse.Focus1.Y + ")");
            Console.WriteLine("   Focus 2: (" + ellipse.Focus2.X + "," + ellipse.Focus2.Y + ")");
            Console.WriteLine("   Vertex 1: (" + ellipse.Vertex1.X + "," + ellipse.Vertex1.Y + ")");
            Console.WriteLine("   Vertex 2: (" + ellipse.Vertex2.X + "," + ellipse.Vertex2.Y + ")");
            Console.WriteLine("   Covertex 1: (" + ellipse.Covertex1.X + "," + ellipse.Covertex1.Y + ")");
            Console.WriteLine("   Covertex 2: (" + ellipse.Covertex2.X + "," + ellipse.Covertex2.Y + ")");
            Console.WriteLine();
            Console.WriteLine("5. Resize the ellipse by 1.7 factor");
            ellipse.Resize(1.7);
            Console.WriteLine();
            Console.WriteLine("6. Print its information");
            Console.WriteLine("   Center: (" + ellipse.Center.X + "," + ellipse.Center.Y + ")");
            Console.WriteLine("   Semi-major axis: " + ellipse.SemiMajorAxis);
            Console.WriteLine("   Semi-minor axis: " + ellipse.SemiMinorAxis);
            Console.WriteLine("   Orientation: " + ellipse.Orientation);
            Console.WriteLine("   Eccentricity: " + ellipse.Eccentricity);
            Console.WriteLine("   Area: " + ellipse.Area);
            Console.WriteLine("   Perimeter: " + ellipse.Perimeter);
            Console.WriteLine("   Focus 1: (" + ellipse.Focus1.X + "," + ellipse.Focus1.Y + ")");
            Console.WriteLine("   Focus 2: (" + ellipse.Focus2.X + "," + ellipse.Focus2.Y + ")");
            Console.WriteLine("   Vertex 1: (" + ellipse.Vertex1.X + "," + ellipse.Vertex1.Y + ")");
            Console.WriteLine("   Vertex 2: (" + ellipse.Vertex2.X + "," + ellipse.Vertex2.Y + ")");
            Console.WriteLine("   Covertex 1: (" + ellipse.Covertex1.X + "," + ellipse.Covertex1.Y + ")");
            Console.WriteLine("   Covertex 2: (" + ellipse.Covertex2.X + "," + ellipse.Covertex2.Y + ")");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void TestingClassRegularHeptagon()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("***   CLASS RegularHeptagon   ***");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine("1. Create an heptagon with center in (1,1) and first vertex in (1,6)");
            Point center = new Point(1, 1);
            Point vertex = new Point(1, 6);
            RegularHeptagon heptagon = new RegularHeptagon(center, vertex);
            Console.WriteLine();
            Console.WriteLine("2. Print its information");
            Console.WriteLine("   Center: (" + heptagon.Center.X + "," + heptagon.Center.Y + ")");
            Console.WriteLine("   Radius: " + heptagon.Radius);
            Console.WriteLine("   Apothem: " + heptagon.Apothem);
            Console.WriteLine("   Side: " + heptagon.Side);
            Console.WriteLine("   Perimeter: " + heptagon.Perimeter);
            Console.WriteLine("   Area: " + heptagon.Area);
            Console.WriteLine("   Vertices:");
            for (int i = 0; i < 7; i++)
                Console.WriteLine("      Vertex " + (i + 1) + ": (" + heptagon[i].X + "," + heptagon[i].Y + ")");
            Console.WriteLine();
            Console.WriteLine("3. Move the heptagon 1.4 right and 3.7 down");
            heptagon.Translate(1.4, -3.7);
            Console.WriteLine();
            Console.WriteLine("4. Print its information");
            Console.WriteLine("   Center: (" + heptagon.Center.X + "," + heptagon.Center.Y + ")");
            Console.WriteLine("   Radius: " + heptagon.Radius);
            Console.WriteLine("   Apothem: " + heptagon.Apothem);
            Console.WriteLine("   Side: " + heptagon.Side);
            Console.WriteLine("   Perimeter: " + heptagon.Perimeter);
            Console.WriteLine("   Area: " + heptagon.Area);
            Console.WriteLine("   Vertices:");
            for (int i = 0; i < 7; i++)
                Console.WriteLine("      Vertex " + (i + 1) + ": (" + heptagon[i].X + "," + heptagon[i].Y + ")");
            Console.WriteLine();
            Console.WriteLine("5. Resize the heptagon to have 7.7 radius");
            heptagon.Resize(7.7);
            Console.WriteLine();
            Console.WriteLine("6. Print its information");
            Console.WriteLine("   Center: (" + heptagon.Center.X + "," + heptagon.Center.Y + ")");
            Console.WriteLine("   Radius: " + heptagon.Radius);
            Console.WriteLine("   Apothem: " + heptagon.Apothem);
            Console.WriteLine("   Side: " + heptagon.Side);
            Console.WriteLine("   Perimeter: " + heptagon.Perimeter);
            Console.WriteLine("   Area: " + heptagon.Area);
            Console.WriteLine("   Vertices:");
            for (int i = 0; i < 7; i++)
                Console.WriteLine("      Vertex " + (i + 1) + ": (" + heptagon[i].X + "," + heptagon[i].Y + ")");
            Console.WriteLine();
            Console.WriteLine("7. Rotate the heptagon 37 degrees counterclockwise");
            heptagon.Rotate(37);
            Console.WriteLine();
            Console.WriteLine("8. Print its information");
            Console.WriteLine("   Center: (" + heptagon.Center.X + "," + heptagon.Center.Y + ")");
            Console.WriteLine("   Radius: " + heptagon.Radius);
            Console.WriteLine("   Apothem: " + heptagon.Apothem);
            Console.WriteLine("   Side: " + heptagon.Side);
            Console.WriteLine("   Perimeter: " + heptagon.Perimeter);
            Console.WriteLine("   Area: " + heptagon.Area);
            Console.WriteLine("   Vertices:");
            for (int i = 0; i < 7; i++)
                Console.WriteLine("      Vertex " + (i + 1) + ": (" + heptagon[i].X + "," + heptagon[i].Y + ")");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            TestingClassPoint();
            TestingClassCircle();
            TestingClassEllipse();
            TestingClassRegularHeptagon();

            Console.WriteLine("ALL DONE!");
            Console.ReadLine();
        }
    }
}
