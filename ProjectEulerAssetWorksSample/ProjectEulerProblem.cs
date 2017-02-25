using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProjectEulerAssetWorksSample
{
    /// <summary>
    /// Class encompassing common aspects of a Project Euler problem.
    /// </summary>
    public class ProjectEulerProblem
    {
        /// <summary>
        /// // Each problem has its own solve implementation that will be delegated.
        /// </summary>
        /// <returns>Some problems do not have numeric answers so return a string.</returns>
        public delegate string Solve(string inputFile = null); 

        #region Fields

        private readonly string myTitle; // Title of the problem
        private readonly uint problemNumber; // Problem number
        private readonly bool requiresInputFile; // True if the problem has an associated input file (no cases where multiple input files are required)
        private readonly Solve solutionMethod; // Algorithm to solve the problem

        #endregion

        #region Properties

        /// <summary>
        /// Return the method used to solve the problem.
        /// </summary>
        private Solve MySolutionMethod
        {
            get { return this.solutionMethod; }
        }

        /// <summary>
        /// Return the problem number.
        /// </summary>
        public uint ProblemNumber
        {
            get { return this.problemNumber; }
        }

        /// <summary>
        /// Return true if the problem has an associated input file.
        /// </summary>
        public bool RequiresInputFile
        {
            get { return this.requiresInputFile; }
        }

        /// <summary>
        /// Returns the title of the problem.
        /// </summary>
        public string Title
        {
            get { return myTitle; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor for a Project Euler problem.
        /// </summary>
        /// <param name="num">The problem number.</param>
        /// <param name="input">True if the problem has an associated input file and false otherwise.</param>
        /// <param name="solMethod">Method used to solve the problem.</param>
        public ProjectEulerProblem(uint num, string title, bool input, Solve solMethod)
        {
            this.myTitle = title;
            this.problemNumber = num;
            this.requiresInputFile = input;
            this.solutionMethod = solMethod;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Override the ToString method. Returns a string containing the problem number and title.
        /// </summary>
        /// <returns>A string describing the problem.</returns>
        public override string ToString()
        {
            return "Problem " + this.ProblemNumber + " - " + this.Title;
        }

        /// <summary>
        /// Get a hyperlink to the URL of the problem.
        /// </summary>
        /// <returns>The associated hyperlink.</returns>
        public string Hyperlink()
        {
            return "https://projecteuler.net/problem=" + this.ProblemNumber;
        }

        /// <summary>
        /// Runs the solution method to the problem, returning the solution and the time required to solve (which is a large component of Project 
        /// Euler problems).
        /// </summary>
        /// <param name="timeToSolve">The time required to perform the solution method. Does not include time required prior to execution of 
        /// the solution method (e.g. time to select an input file).</param>
        /// <param name="inputFile">The full path to the required input file, if any.</param>
        /// <returns>The solution given in the form of a string</returns>
        public string RunSolution(out double timeToSolve, string inputFile = null)
        {
            timeToSolve = 0; // Default value (cannot be assigned in method declaration)

            // Check that required input file present
            if (this.RequiresInputFile)
            {
                if (inputFile == null)
                {
                    MessageBox.Show("This problem requires an input file.", "Input File Required", MessageBoxButtons.OK);
                    return null;
                }
                if (!File.Exists(inputFile))
                {
                    MessageBox.Show("The given input file no longer exists.", "Missing Input File", MessageBoxButtons.OK);
                    return null;
                }
            }
            
            // Solve with a stopwatch running to get elapsed time
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            string sol = this.MySolutionMethod(inputFile);
            myStopwatch.Stop();
            timeToSolve = myStopwatch.ElapsedMilliseconds / 1000.0; // Divide by 1000 to get seconds (the ".0" is to avoid integer truncation)

            return sol;
        }

        #endregion
    }
}