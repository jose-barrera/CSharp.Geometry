using System;

/*
 *    ----------------------------------------------------------------
 *    |                        Ellipse                               |
 *    |--------------------------------------------------------------|
 *    | center: Point                                                |
 *    | semi-major axis: numeric                                     |
 *    | semi-minor axis: numeric                                     |
 *    | orientation: text                                            |
 *    | eccentricity: numeric                                        |
 *    | focus1: Point                                                |
 *    | focus2: Point                                                |
 *    | vertex1: Point                                               |
 *    | vertex2: Point                                               |
 *    | covertex1: Point                                             |
 *    | covertex2: Point                                             |
 *    | area: numeric                                                |
 *    | perimeter: numeric                                           |
 *    |--------------------------------------------------------------|
 *    | <<constructor> Ellipse(center: Point,                        |
 *    |                        semi-major axis: numeric,             |
 *    |                        semi-minor axis: numeric,             |
 *    |                        orientation: text)                    |
 *    | translate(dx: numeric, dy: numeric)                          |
 *    | resize(factor: numeric)                                      |
 *    ----------------------------------------------------------------
 *    
 */
namespace Geometry
{
    internal class Ellipse
    {
        #region INTERNAL FIELDS

        /* 
         * REMEMBER: Internal fields are variables that ALWAYS must be
         *           private (encapsulation) and they are used to store
         *           object data.
         */

        private Point center;
        private double semiMajorAxis;
        private double semiMinorAxis;
        private string orientation;
        private double eccentricity;
        private Point focus1;
        private Point focus2;
        private Point vertex1;
        private Point vertex2;
        private Point covertex1;
        private Point covertex2;
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
        public double SemiMajorAxis
        {
            get
            {
                return this.semiMajorAxis;
            }
        }
        public double SemiMinorAxis
        {
            get
            {
                return this.semiMinorAxis;
            }
        }
        public string Orientation
        {
            get
            {
                return this.orientation;
            }
        }
        public double Eccentricity
        {
            get
            {
                return this.eccentricity;
            }
        }
        public Point Focus1
        {
            get
            {
                return this.focus1;
            }
        }
        public Point Focus2
        {
            get
            {
                return this.focus2;
            }
        }
        public Point Vertex1
        {
            get
            {
                return this.vertex1;
            }
        }
        public Point Vertex2
        {
            get
            {
                return this.vertex2;
            }
        }
        public Point Covertex1
        {
            get
            {
                return this.covertex1;
            }
        }
        public Point Covertex2
        {
            get
            {
                return this.covertex2;
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

        #endregion

        #region CONSTRUCTORS

        /* REMEMBER: Constructors are special functions whose name is 
         *           always the same of the class. Its responsibility
         *           is to establish an initial VALID state of the object.
         */

        public Ellipse(Point center, double semiMajorAxis, double semiMinorAxis, string orientation)
        {
            // Axes must be positive values, major axis must be greater
            // than minor axis, and valid orientations are "Horizontal"
            // and "Vertical". If any of these conditions is not met, 
            // object cannot be created and an error will be generated.
            if (semiMajorAxis > 0 && semiMinorAxis > 0)
            {
                if (semiMajorAxis > semiMinorAxis)
                {
                    // Stores the data.
                    this.center = center;
                    this.semiMajorAxis = semiMajorAxis;
                    this.semiMinorAxis = semiMinorAxis;
                    this.orientation = orientation;
                    // Makes general calculations.
                    double linearEccentricity = Math.Sqrt(Math.Pow(semiMajorAxis, 2) -
                                                          Math.Pow(semiMinorAxis, 2));
                    this.eccentricity = linearEccentricity / semiMajorAxis;
                    this.area = Math.PI * semiMajorAxis * semiMinorAxis;
                    // Calculates the approximation of perimeter
                    double h = Math.Pow(this.semiMajorAxis - this.semiMinorAxis, 2) /
                               Math.Pow(this.semiMajorAxis + this.semiMinorAxis, 2);
                    double seriesApproximation = 1 + h / 4 + Math.Pow(h, 2) / 64 + 
                        Math.Pow(h, 3) / 256 + 25 * Math.Pow(h, 4) / 16384 + 
                        49 * Math.Pow(h, 5) / 655536 + 441 * Math.Pow(h, 6) / 1048576; 
                    this.perimeter = Math.PI * (semiMajorAxis + semiMinorAxis) * seriesApproximation;
                    // Calculates points according to orientation.
                    switch (orientation)
                    {
                        case "Horizontal":
                            this.focus1 = new Point(center.X - linearEccentricity, center.Y);
                            this.focus2 = new Point(center.X + linearEccentricity, center.Y);
                            this.vertex1 = new Point(center.X - semiMajorAxis, center.Y);
                            this.vertex2 = new Point(center.X + semiMajorAxis, center.Y);
                            this.covertex1 = new Point(center.X, center.Y - semiMinorAxis);
                            this.covertex2 = new Point(center.X, center.Y + semiMinorAxis);
                            break;
                        case "Vertical":
                            this.focus1 = new Point(center.X, center.Y - linearEccentricity);
                            this.focus2 = new Point(center.X, center.Y + linearEccentricity);
                            this.vertex1 = new Point(center.X, center.Y - semiMajorAxis);
                            this.vertex2 = new Point(center.X, center.Y + semiMajorAxis);
                            this.covertex1 = new Point(center.X - semiMinorAxis, center.Y);
                            this.covertex2 = new Point(center.X + semiMinorAxis, center.Y);
                            break;
                        default:
                            throw new ArgumentException("ERR: Orientation is invalid.");
                    }
                }
                else
                {
                    throw new ArgumentException("ERR: Semi-major axis cannot be equal or smaller than semi-minor axis.");
                }
            }
            else
            {
                throw new ArgumentException("ERR: Semi-axes cannot be zero or negative.");
            }
        }

        #endregion

        #region METHODS

        /* REMEMBER: Methods are functions inside the class that defines
         *           the behaviour of the objects.
         */

        // Moves the ellipse offsetting its center a given horizontal
        // and vertical distance. It is necessary to recalculate some of
        // its properties.
        public void Translate(double dx, double dy)
        {
            // Updates the data.
            this.center.Translate(dx, dy);
            double linearEccentricity = Math.Sqrt(Math.Pow(this.semiMajorAxis, 2) -
                                                    Math.Pow(this.semiMinorAxis, 2));
            // Calculates points according to orientation.
            switch (this.orientation)
            {
                case "Horizontal":
                    this.focus1 = new Point(this.center.X - linearEccentricity, this.center.Y);
                    this.focus2 = new Point(this.center.X + linearEccentricity, this.center.Y);
                    this.vertex1 = new Point(this.center.X - this.semiMajorAxis, this.center.Y);
                    this.vertex2 = new Point(this.center.X + this.semiMajorAxis, this.center.Y);
                    this.covertex1 = new Point(this.center.X, this.center.Y - this.semiMinorAxis);
                    this.covertex2 = new Point(this.center.X, this.center.Y + this.semiMinorAxis);
                    break;
                case "Vertical":
                    this.focus1 = new Point(this.center.X, this.center.Y - linearEccentricity);
                    this.focus2 = new Point(this.center.X, this.center.Y + linearEccentricity);
                    this.vertex1 = new Point(this.center.X, this.center.Y - this.semiMajorAxis);
                    this.vertex2 = new Point(this.center.X, this.center.Y + this.semiMajorAxis);
                    this.covertex1 = new Point(this.center.X - this.semiMinorAxis, this.center.Y);
                    this.covertex2 = new Point(this.center.X + this.semiMinorAxis, this.center.Y);
                    break;
            }
        }

        // Resizes the ellipse multiplying their axes by a factor. 
        // If factor > 1 the ellipse grows, if factor < 1 the ellipse
        // shrinks. It is necessary to recalculate some of its properties.
        public void Resize(double factor)
        {
            // Factor must be positive; otherwise, the ellipse cannot be
            // resized and an error will be generated.
            if (factor > 0)
            {
                // Updates the data.
                this.semiMajorAxis *= factor;
                this.semiMinorAxis *= factor;
                double linearEccentricity = Math.Sqrt(Math.Pow(this.semiMajorAxis, 2) -
                                                     Math.Pow(this.semiMinorAxis, 2));
                this.eccentricity = linearEccentricity / this.semiMajorAxis;
                this.area = Math.PI * this.semiMajorAxis * this.semiMinorAxis;
                // Calculates the approximation of perimeter
                double h = Math.Pow(this.semiMajorAxis - this.semiMinorAxis, 2) /
                           Math.Pow(this.semiMajorAxis + this.semiMinorAxis, 2);
                double seriesApproximation = 1 + h / 4 + Math.Pow(h, 2) / 64 +
                    Math.Pow(h, 3) / 256 + 25 * Math.Pow(h, 4) / 16384 +
                    49 * Math.Pow(h, 5) / 655536 + 441 * Math.Pow(h, 6) / 1048576;
                this.perimeter = Math.PI * (this.semiMajorAxis + this.semiMinorAxis) * seriesApproximation;
                // Calculates points according to orientation.
                switch (this.orientation)
                {
                    case "Horizontal":
                        this.focus1 = new Point(this.center.X - linearEccentricity, this.center.Y);
                        this.focus2 = new Point(this.center.X + linearEccentricity, this.center.Y);
                        this.vertex1 = new Point(this.center.X - this.semiMajorAxis, this.center.Y);
                        this.vertex2 = new Point(this.center.X + this.semiMajorAxis, this.center.Y);
                        this.covertex1 = new Point(this.center.X, this.center.Y - this.semiMinorAxis);
                        this.covertex2 = new Point(this.center.X, this.center.Y + this.semiMinorAxis);
                        break;
                    case "Vertical":
                        this.focus1 = new Point(this.center.X, this.center.Y - linearEccentricity);
                        this.focus2 = new Point(this.center.X, this.center.Y + linearEccentricity);
                        this.vertex1 = new Point(this.center.X, this.center.Y - this.semiMajorAxis);
                        this.vertex2 = new Point(this.center.X, this.center.Y + this.semiMajorAxis);
                        this.covertex1 = new Point(this.center.X - this.semiMinorAxis, this.center.Y);
                        this.covertex2 = new Point(this.center.X + this.semiMinorAxis, this.center.Y);
                        break;
                }
            }
            else
            {
                throw new ArgumentException("ERR: Factor cannot be zero or negative.");
            }    
        }

        #endregion
    }
}
