using System;
using System.Windows;

namespace ProjectEulerAssetWorksSample
{
    /// <summary>
    /// This class represents a triangle object in the 2-D cartesian plane.
    /// </summary>
    internal class Triangle
    {
        public const int NUM_POINTS = 3; // Three points to a triangle
        
        #region Fields

        private Point[] myPoints; // Use the built-in point class

        #endregion

        #region Properties

        /// <summary>
        /// Returns the points of the triangle.
        /// </summary>
        public Point[] MyPoints
        {
            get { return myPoints; }
            private set { myPoints = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new triangle instance with the given coordinate points.
        /// </summary>
        /// <param name="coordinates">A 3x2 numeric matrix consisting of three points each with an X and Y value.</param>
        public Triangle(double[,] coordinates)
        {
            // Validate size of input
            if (coordinates.GetLength(0) != NUM_POINTS)
            {
                throw new Exception("Invalid number of points passed to Triangle constructor.");
            }
            if (coordinates.GetLength(1) != 2)
            {
                throw new Exception("Invalid number of dimensions in a point passed to Triangle constructor.");
            }
            
            // Populate triangle
            MyPoints = new Point[Triangle.NUM_POINTS];
            for (int i = 0; i < Triangle.NUM_POINTS; ++i)
            {
                MyPoints[i] = new Point(coordinates[i, 0], coordinates[i, 1]);
            }

            // Validate duplicates
            for (int i = 0; i < Triangle.NUM_POINTS; ++i)
            {
                for (int j = 0; j < Triangle.NUM_POINTS; ++j)
                {
                    if (j == i) // Don't check against self
                    {
                        continue;
                    }

                    if (MyPoints[j].Equals(MyPoints[i]))
                    {
                        throw new Exception("Duplicate points passed to Triangle constructor.");
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method determines if the given 2-D point falls within the bounds of the triangle.
        /// </summary>
        /// <returns>True if the triangle contains the point and false otherwise.</returns>
        public bool ContainsPoint(double x, double y)
        {
            // Compute the three barycentric coordinates with respect to given point - these values are solutions easily looked-up
            double denom = (MyPoints[1].Y - MyPoints[2].Y) * (MyPoints[0].X - MyPoints[2].X) + (MyPoints[2].X - MyPoints[1].X) * (MyPoints[0].Y - MyPoints[2].Y);
            double lambda1 = ((MyPoints[1].Y - MyPoints[2].Y) * (x - MyPoints[2].X) + (MyPoints[2].X - MyPoints[1].X) * (y - MyPoints[2].Y)) / denom;
            double lambda2 = ((MyPoints[2].Y - MyPoints[0].Y) * (x - MyPoints[2].X) + (MyPoints[0].X - MyPoints[2].X) * (y - MyPoints[2].Y)) / denom;
            double lambda3 = 1 - lambda1 - lambda2;

            // Point is contained within triangle if signs of barycentric coordinates are all equal
            return (Math.Sign(lambda1) == Math.Sign(lambda2) && Math.Sign(lambda1) == Math.Sign(lambda3));
        }

        #endregion
    }
}