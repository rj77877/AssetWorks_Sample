using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectEulerAssetWorksSample
{
    /// <summary>
    /// This class contains all of the static solve methods for each individual Project Euler problem.
    /// </summary>
    public class ProjectEulerSolveMethods
    {
        /// <summary>
        /// This method solves problems 18 and 67. These problems involve taking a pyramid of integers and finding the sum of the maximal path 
        /// from the top to bottom of the pyramid. Both problems are the exact same type of problem, just with different inputs (a much larger 
        /// input file for problem 67).
        /// </summary>
        /// <param name="inputFile">The input file required.</param>
        /// <returns>The solution to the problem.</returns>
        public static string Problem18Or67Solver(string inputFile)
        {
            // Read the file
            string[] lines = File.ReadAllLines(inputFile);
            if (lines.Length == 0) // Validate file contents
            {
                MessageBox.Show("The input file is empty.", "Empty File", MessageBoxButtons.OK);
                return null;
            }

            // Populate a numeric pyramid instance with the file contents
            NumericPyramid pyramid = new NumericPyramid();
            int count = 0;
            foreach (string line in lines)
            {
                ++count;
                string[] fields = line.Split(' ');
                if (fields.Length != count) // Validate file contents
                {
                    MessageBox.Show("The input file is not in a valid format. Line " + count + " should contain " + 
                                    count + " integers.", "Invalid File Format", MessageBoxButtons.OK);
                    return null;
                }

                double[] myValues = new double[fields.Length];
                for (int i = 0; i < fields.Length; ++i)
                {
                    double temp;
                    if (!double.TryParse(fields[i], out temp)) // Validate file contents
                    {
                        MessageBox.Show("The input file is not in a valid format. Line " + count + 
                                        " contains a non-numeric value.", "Invalid File Format", MessageBoxButtons.OK);
                        return null;
                    }
                    myValues[i] = temp;
                }
                pyramid.AddRow(myValues); // Add row to pyramid
            }
            return pyramid.MaxPath().ToString(); // Maximum path calculation
        }
        
        /// <summary>
        /// This method solves problem 81. This problem involves finding the minimal sum when traveling from the top left to bottom
        /// right corners of a matrix, only allowing moves down and to the right.
        /// </summary>
        /// <param name="inputFile">The input file required.</param>
        /// <returns>The solution to the problem.</returns>
        public static string Problem81Solver(string inputFile)
        {
            // Read the file
            string[] lines = File.ReadAllLines(inputFile);
            if (lines.Length == 0) // Validate file contents
            {
                MessageBox.Show("The input file is empty.", "Empty File", MessageBoxButtons.OK);
                return null;
            }

            // Read the file and populate a matrix with the contents
            int numRows = lines.Length;
            int numCols = 0; // Get one first line is read
            double[,] myMatrix = null; // Will dimension once columns read
            for (int row = 0; row < numRows; ++row)
            {
                string[] fields = lines[row].Split(',');
                if (row == 0)
                {
                    numCols = fields.Length;
                    myMatrix = new double[numRows, numCols];
                }

                if (fields.Length != numCols) // Validate file contents
                {
                    MessageBox.Show("The input file is not in a valid format. Line " + (row + 1) + 
                                    " has a different number of values than previous lines.", 
                                    "Invalid File Format", MessageBoxButtons.OK);
                    return null;
                }

                for (int col = 0; col < numCols; ++col)
                {
                    double temp;
                    if (!double.TryParse(fields[col], out temp)) // Validate file contents
                    {
                        MessageBox.Show("The input file is not in a valid format. Line " + (row + 1) + 
                                        " contains a non-numeric value.", "Invalid File Format", 
                                        MessageBoxButtons.OK);
                        return null;
                    }
                    myMatrix[row,col] = temp;
                }
            }

            // Perform the minimal path calculation. Starting from the two values surrounding the bottom right, 
            // add the minimal next step to the current value. Repeat until the top left is reached, at which 
            // point the minimal sum will be in that top left entry.
            for (int row = numRows - 1; row >= 0; --row)
            {
                for (int col = numCols - 1; col >= 0; --col)
                {
                    // Get the two possible steps from the current point
                    double[] path = new double[2] { -1, -1 };
                    if (row + 1 < numRows)
                    {
                        path[0] = myMatrix[row + 1, col]; // Down a row
                    }
                    if (col + 1 < numCols)
                    {
                        path[1] = myMatrix[row, col + 1]; // Column to the right
                    }

                    // Catch for being exactly at the bottom right, which is the end point and
                    // has no next step
                    if (path.Max() < 0)
                    {
                        continue;
                    }

                    myMatrix[row, col] += path.Where(x => (x >= 0)).Min(); // Add the minimum value to the current point
                }
            }
            return myMatrix[0, 0].ToString(); // Minimal sum populated in top left
        }

        /// <summary>
        /// This method solves problem 102. This problem involves determining how many given triangles contain the origin.
        /// </summary>
        /// <param name="inputFile">The input file required.</param>
        /// <returns>The solution to the problem.</returns>
        public static string Problem102Solver(string inputFile)
        {
            // Read the file
            string[] lines = File.ReadAllLines(inputFile);
            if (lines.Length == 0) // Validate file contents
            {
                MessageBox.Show("The input file is empty.", "Empty File", MessageBoxButtons.OK);
                return null;
            }

            const int NUM_FIELDS = Triangle.NUM_POINTS * 2; // Number of fields required to specify a triangle

            // Read the file
            int count = 0; // Number of triangles containing origin
            int lineCount = 0;
            foreach (string line in lines)
            {
                ++lineCount;
                string[] fields = line.Split(',');
                if (fields.Length != NUM_FIELDS) // Validate file contents
                {
                    MessageBox.Show("The input file is not in a valid format. Line " + lineCount + " does not contain " + 
                                    NUM_FIELDS + " values.", "Invalid File Format", MessageBoxButtons.OK);
                    return null;
                }

                // Populate a triangle instance
                double[,] coordinates = new double[Triangle.NUM_POINTS, 2];
                for (int i = 0; i < NUM_FIELDS; ++i)
                {
                    double temp;
                    if (!double.TryParse(fields[i], out temp)) // Validate file contents
                    {
                        MessageBox.Show("The input file is not in a valid format. Line " + lineCount + 
                                        " contains a non-numeric value.", "Invalid File Format", MessageBoxButtons.OK);
                        return null;
                    }

                    coordinates[i / 2, i % 2] = temp;
                }
                Triangle t = new Triangle(coordinates);

                // Determine if triangle contains origin
                if (t.ContainsPoint(0, 0))
                {
                    ++count;
                }
            }
            return count.ToString();
        }

        /// <summary>
        /// This method solves problem 190. This problem involves maximising a specific multivariate function.
        /// </summary>
        /// <param name="inputFile">A dummy variable for the input file. Unused for this problem but still required due to nature of C# delegates</param>
        /// <returns>The solution to the problem.</returns>
        public static string Problem190Solver(string inputFile = null)
        {
            // Compute the sum of the maximised function values for the required values of m
            long lSum = 0;
            for (int m = 2; m <= 15; ++m) // 2-15 based on problem definition
            {
                double P = 1;
                for (int k = 1; k <= m; ++k)
                {
                    // The optimal x_i was computed by hand using Lagrange multipliers
                    double x = 2.0 * k / (m + 1.0); 
                    P *= Math.Pow(x, k);
                }
                lSum += (long)Math.Floor(P);
            }
            return lSum.ToString();
        }
    }
}