using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectEulerAssetWorksSample
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProjectEulerSolverForm());
        }

        /// <summary>
        /// Initializes the list of solved Project Euler problems. Due to the sample size, this is easily hard-coded.
        /// If expanded, at least some of this information would likely move to a file.
        /// </summary>
        /// <returns>A list of Project Euler problem instances.</returns>
        internal static List<ProjectEulerProblem> InitializeMySolvedProblems()
        {
            List<ProjectEulerProblem> solvedProblems = new List<ProjectEulerProblem>();
            solvedProblems.Add(new ProjectEulerProblem(18, "Maximum path sum I", true, ProjectEulerSolveMethods.Problem18Or67Solver));
            solvedProblems.Add(new ProjectEulerProblem(67, "Maximum path sum II", true, ProjectEulerSolveMethods.Problem18Or67Solver));
            solvedProblems.Add(new ProjectEulerProblem(81, "Path sum: two ways", true, ProjectEulerSolveMethods.Problem81Solver));
            solvedProblems.Add(new ProjectEulerProblem(102, "Triangle containment", true, ProjectEulerSolveMethods.Problem102Solver));
            solvedProblems.Add(new ProjectEulerProblem(190, "Maximising a weighted product", false, ProjectEulerSolveMethods.Problem190Solver));

            return solvedProblems;
        }
    }
}