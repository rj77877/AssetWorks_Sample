using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerAssetWorksSample
{
    /// <summary>
    /// This class represents a pyramid of numeric values (e.g. a Pascal Triangle like structure).
    /// </summary>
    internal class NumericPyramid
    {
        #region Fields

        private List<double[]> myValues; // List of values of pyramid - use list to more readily allow for variable number of rows

        #endregion

        #region Properties

        /// <summary>
        /// Returns the number of rows in the pyramid.
        /// </summary>
        internal int NumRows
        {
            get { return myValues.Count; }
        }

        /// <summary>
        /// Returns and privately sets the values in the pyramid.
        /// </summary>
        internal List<double[]> MyValues
        {
            get { return myValues; }
            private set { myValues = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new pyramid instance.
        /// </summary>
        internal NumericPyramid()
        {
            MyValues = new List<double[]>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a row to the pyramid populated with the given array of doubles.
        /// </summary>
        /// <param name="rowValues"></param>
        internal void AddRow(double[] rowValues)
        {
            MyValues.Add(new double[NumRows + 1]);
            double[] rowToAssignTo = MyValues.Last();
            if (rowValues.Length == rowToAssignTo.Length)
            {
                for (int i = 0; i < rowValues.Length; ++i)
                {
                    rowToAssignTo[i] = rowValues[i];
                }
            }
            else // Invalid length
            {
                throw new Exception("Invalid row length assigned to pyramid.");
            }
        }

        /// <summary>
        /// This function returns the sum of the maximal path down the pyramid. In a future implementation, this algorithm could be 
        /// generalized to return the minimal path as well.
        /// </summary>
        /// <returns>The sum of the maximal path down the pyramid.</returns>
        internal double MaxPath()
        {
            // The algorithm involves modifying the values field, so this should be done on a copy of the variable.
            List<double[]> myValuesCopy = MyValues;
            if (myValuesCopy.Count == 0)
            {
                return 0;
            }

            // When traveling down the pyramid, at any point the next number must be one of two options. So to find the maximum sum,
            // start at the bottom and for each value in the previous row, add to it the maximum value that it could travel to next.
            // Continue this until the single value at the top is reached, and the maximum sum is achieved.
            for (int iRow = NumRows - 2; iRow >= 0; --iRow)
            {
                for (int iCol = 0; iCol < myValuesCopy[iRow].Length; ++iCol)
                {
                    myValuesCopy[iRow][iCol] += Math.Max(myValuesCopy[iRow + 1][iCol], myValuesCopy[iRow + 1][iCol + 1]);
                }
            }
            return myValuesCopy[0][0]; // After all the adding above, the top of the pyramid now contains the sum of the maximal path.
        }

        #endregion
    }
}