using System;

namespace Geometry
{
    /*
     *    ----------------------------------------------------------------
     *    |                        REgularHeptagon                       |
     *    |--------------------------------------------------------------|
     *    | center: Point                                                |
     *    | radius: numeric                                              |
     *    | apothem: numeric                                             |
     *    | side: numeric                                                |
     *    | vertices: Point (collection)                                 |
     *    | area: numeric                                                |
     *    | perimeter: numeric                                           |
     *    |--------------------------------------------------------------|
     *    | <<constructor> RegularHeptagon(center: Point, vertex: Point) |
     *    | translate(dx: numeric, dy: numeric)                          |
     *    | resize(radius: numeric)                                      |
     *    | rotate(angle: numeric)                                       |
     *    ----------------------------------------------------------------
     *    
     */
    internal class RegularHeptagon
    {
        #region INTERNAL FIELDS

        /* 
         * REMEMBER: Internal fields are variables that ALWAYS must be
         *           private (encapsulation) and they are used to store
         *           object data.
         */

        private Point center;
        private double radius;
        private double apothem;
        private double side;
        private Point[] vertices;
        private double area;
        private double perimeter;

        #endregion

        #region PROPERTIES

        /* REMEMBER: Properties are a protection mechanism to accomplish
         *           encapsulation. Any property may have 2 components:
         *           a) ACCESSOR, responsible to give access to the
         *              internal field (read).
         *           b) MUTATOR, responsible to allow modification of
         *              the internal field (write).
         *           Properties with both accessor and mutator are READ/WRITE.
         *           Properties with only accessor are READ-ONLY.
         *           Properties with only mutator are WRITE-ONLY.
         */

        public Point Center
        {
            get
            {
                return this.center;
            }
        }
        public double Radius
        {
            get
            {
                return this.radius;
            }
        }
        public double Apothem
        {
            get
            {
                return this.apothem;
            }
        }
        public double Side
        {
            get
            {
                return this.side;
            }
        }
        public double Area
        {
            get
            {
                return this.area;
            }
        }
        public double Perimeter
        {
            get
            {
                return this.perimeter;
            }
        }
        public Point this[int i]
        {
            get
            {
                return this.vertices[i];
            }
        }

        #endregion

        #region CONSTRUCTORS

        /* REMEMBER: Constructors are special functions whose name is 
         *           always the same of the class. Its responsibility
         *           is to establish an initial VALID state of the object.
         */

        // Builds a heptagon from its center and first vertex, calculating
        // other vertices counterclockwise.
        public RegularHeptagon(Point center, Point vertex)
        {
            // Center and vertex cannot be the same point.
            if (!(center.X == vertex.X && center.Y == vertex.Y))
            {
                // Stores the center.
                this.center = center;
                // Calculates radius (distance from center to vertex).
                this.radius = center.DistanceTo(vertex);
                // Calculates vertices.
                this.vertices = new Point[7];
                this.vertices[0] = vertex;
                double x, y;
                double angle = Math.PI * 2 / 7;
                for (int i = 1; i < 7; i++)
                {
                    x = Math.Cos(i * angle) * (vertex.X - center.X) - Math.Sin(i * angle) * (vertex.Y - center.Y) + center.X;
                    y = Math.Sin(i * angle) * (vertex.X - center.X) + Math.Cos(i * angle) * (vertex.Y - center.Y) + center.Y;
                    this.vertices[i] = new Point(x, y);
                }
                // Calculates apothem (radius multiplied by the cosine of PI/7).
                this.apothem = this.radius * Math.Cos(Math.PI / 7);
                // Calculates side (distance between 2 consecutive vertices).
                this.side = this.vertices[0].DistanceTo(this.vertices[1]);
                // Calculates perimeter (side length multiplied by seven).
                this.perimeter = this.side * 7;
                // Calculates area (half the product of its perimeter and its apothem).
                this.area = this.perimeter * this.apothem / 2;
            }
            else
            {
                throw new ArgumentException("ERR: Center and vertex cannot be the same point.");
            }    
        }

        #endregion

        #region METHODS

        /* REMEMBER: Methods are functions inside the class that defines
         *           the behaviour of the objects.
         */

        // Moves the heptagon offsetting its center and vertices a given
        // horizontal and vertical distance. All other properties remains
        // the same.
        public void Translate(double dx, double dy)
        {
            this.center.Translate(dx, dy);
            foreach (Point vertex in this.vertices)
            {
                vertex.Translate(dx, dy);
            }
        }
        
        // Resizes the heptagon based on its circumscribed radius. Some
        // of its properties must be recalculated.
        public void Resize(double radius)
        {
            // The radius must be positive.
            if (radius > 0)
            {
                // Stores the radius.
                this.radius = radius;
                // Calculates the slope of the segment from center
                // to first vertex, and then the new vertex in that
                // direction from center.
                double slope, theta;
                double dx = this.vertices[0].X - this.center.X;
                double dy = this.vertices[0].Y - this.center.Y;
                if (dx != 0)
                {
                    slope = dy / dx;
                    theta = Math.Atan(slope);
                }
                else if (dy > 0)
                    theta = Math.PI / 2;
                else
                    theta = 3 * Math.PI / 2;
                double x = this.center.X + radius * Math.Cos(theta);
                double y = this.center.Y + radius * Math.Sin(theta);
                // Calculates the new vertices.
                Point vertex = new Point(x, y);
                this.vertices[0] = vertex;
                double angle = Math.PI * 2 / 7;
                for (int i = 1; i < 7; i++)
                {
                    x = Math.Cos(i * angle) * (vertex.X - this.center.X) - 
                        Math.Sin(i * angle) * (vertex.Y - this.center.Y) + 
                        this.center.X;
                    y = Math.Sin(i * angle) * (vertex.X - this.center.X) + 
                        Math.Cos(i * angle) * (vertex.Y - this.center.Y) + 
                        this.center.Y;
                    this.vertices[i] = new Point(x, y);
                }
                // Calculates apothem (radius multiplied by the cosine of PI/7).
                this.apothem = this.radius * Math.Cos(Math.PI / 7);
                // Calculates side (distance between 2 consecutive vertices).
                this.side = this.vertices[0].DistanceTo(this.vertices[1]);
                // Calculates perimeter (side length multiplied by seven).
                this.perimeter = this.side * 7;
                // Calculates area (half the product of its perimeter and its apothem).
                this.area = this.perimeter * this.apothem / 2;
            }
            else
            {
                throw new ArgumentException("ERR: Radius cannot be zero or negative.");
            }
        }

        // Rotates the heptagon around its center (the parameter is in degrees).
        public void Rotate(double angle)
        {
            double x, y;
            double theta = Math.PI * angle / 180;
            for(int i=0; i < 7; i++)
            {
                x = Math.Cos(theta) * (this.vertices[i].X - this.center.X) - 
                    Math.Sin(theta) * (this.vertices[i].Y - this.center.Y) + this.center.X;
                y = Math.Sin(theta) * (this.vertices[i].X - this.center.X) + 
                    Math.Cos(theta) * (this.vertices[i].Y - this.center.Y) + this.center.Y;
                this.vertices[i] = new Point(x, y);
            }
        }

        #endregion
    }
}
