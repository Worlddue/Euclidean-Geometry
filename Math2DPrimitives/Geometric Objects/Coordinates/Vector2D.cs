﻿namespace MathEuclideanPrimitives
{
    using System;

    /// <summary>
    /// A struct representing a vector in R2 space.
    /// <seealso href="https://en.wikipedia.org/wiki/Linear_algebra#Vector_spaces"/>
    /// </summary>
    public class Vector2D
    {
        private double x;
        private double y;
        private double magintude;

        /// <summary>
        /// The magnitude of the vector.
        /// </summary>
        public double Magintude { get => magintude; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        /// <summary>
        /// A vector moving 1 unit length in the X axis.
        /// </summary>
        public static Vector2D BasisX => new Vector2D(1, 0);
        /// <summary>
        /// A vector moving 1 unit length in the Y axis.
        /// </summary>
        public static Vector2D BasisY => new Vector2D(0, 1);
        /// <summary>
        /// A vector composed of the origin zero coordinates.
        /// </summary>
        public static Vector2D Origin => new Vector2D(0, 0);

        /// <summary>
        /// Instantiates a vector with X and Y coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
            magintude = Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Instantiates a vector moving from start point to end point.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Vector2D(Point2D start, Point2D end)
        {
            x = end.X - start.X;
            y = end.Y - start.Y;
            magintude = Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// instantiates a vector with zero coordinates.
        /// </summary>
        public Vector2D()
        {

        }


        /// <summary>
        /// Instantiates a new vector with the same X and Y coordinated values.
        /// </summary>
        /// <param name="value"></param>
        public Vector2D(double value)
        {
            x = y = value;
            magintude = Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Performs a dot product.
        /// </summary>
        /// <param name="v1">First Vector.</param>
        /// <seealso cref="https://en.wikipedia.org/wiki/Dot_product"/>
        /// <returns>Double value of the Dot product.</returns>
        public double Dot(Vector2D v) => x * v.x + y * v.y;

        /// <summary>
        /// Performs a 2D Cross product which is the value of a determinant.
        /// </summary>
        /// <param name="v1">First Vector.</param>
        /// <returns>Double Value of the Cross Product.</returns>
        public double Cross(Vector2D v) => x * v.y - (y * v.x);


        /// <summary>
        /// Using dot product to compute the angle in degrees between Vectors.
        /// <see href="https://en.wikipedia.org/wiki/Dot_product"/>
        /// </summary>
        /// <param name="v">The other Vector.</param>
        /// <returns>Double Angle in Degrees.</returns>
        public double ComputeAngle(Vector2D v)
        {
            double magProduct = this.Magintude * v.Magintude;
            var dotproduct = this.Dot(v);
            double value = (Math.Acos(dotproduct / magProduct)) * 180 / Math.PI;
            return value;
        }

        /// <summary>
        /// Computes the angle between 2 vectors with directions. 
        /// Anti clock wise is the positive direction.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double ComputeDirectionalAngle(Vector2D v)
        {
            double angle = this.ComputeAngle(v);
            double determinant = this.x * v.y - this.y * v.x;
            var sign = determinant > 0 ? 1 : -1;
            return angle * sign;
        }

        /// <summary>
        /// Returns a normalized vector with the same direction but a unit length.
        /// </summary>
        /// <returns></returns>
        public Vector2D Normalize() => Normalize(this);


        /// <summary>
        /// Returns a normalized vector with the same direction but a unit length.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2D Normalize(Vector2D vector)
        {
            var magnitude = Math.Sqrt(vector.x * vector.x + vector.y * vector.y);
            return new Vector2D(vector.x / magnitude, vector.y / magnitude);
        }


        /// <summary>
        /// Converts the given vector into a point with same coordinates.
        /// </summary>
        /// <returns></returns>
        public Point2D ToPoint() => ToPoint(this);

        /// <summary>
        /// Converts the given vector into a point with same coordinates.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Point2D ToPoint(Vector2D vector)
        {
            return new Point2D((float)vector.x, (float)vector.y);
        }


        /// <summary>
        /// Performs a dot product.
        /// </summary>
        /// <param name="v1">First Vector.</param>
        /// <param name="v2">Second Vector.</param>
        /// <seealso cref="https://en.wikipedia.org/wiki/Dot_product"/>
        /// <returns>Double value of the Dot product.</returns>
        public static double Dot(Vector2D v1, Vector2D v2) => v1.Dot(v2);

        /// <summary>
        /// Performs a 2D Cross product which is the value of a determinant.
        /// </summary>
        /// <param name="v1">First Vector.</param>
        /// <param name="v2">Second Vector.</param>
        /// <returns>Double Value of the Cross Product.</returns>
        public static double Cross(Vector2D v1, Vector2D v2) => v1.Cross(v2);

        /// <summary>
        /// Using dot product to compute the angle between Vectors.
        /// <see href="https://en.wikipedia.org/wiki/Dot_product"/>
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The other Vector.</param>
        /// <returns>Double Angle in Degrees.</returns>
        public static double ComputeAngle(Vector2D v1, Vector2D v2) => v1.ComputeAngle(v2);

        public static Vector2D operator +(Vector2D v1, Vector2D v2) => new Vector2D(v1.x + v2.x, v1.y + v2.y);

        public static Vector2D operator -(Vector2D v1, Vector2D v2) => new Vector2D(v1.x - v2.x, v1.y - v2.y);



        public static Vector2D operator *(double value, Vector2D vRight) => new Vector2D(vRight.x * value, vRight.y * value);
        public static Vector2D operator *(Vector2D vLeft, double value) => new Vector2D(vLeft.x * value, vLeft.y * value);
        public static double operator *(Vector2D vLeft, Vector2D vRight) => vLeft.Dot(vRight);




    }
}
