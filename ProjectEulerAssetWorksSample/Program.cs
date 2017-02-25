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
        static void Main()
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
        public static List<ProjectEulerProblem> InitializeMySolvedProblems()
        {
            List<ProjectEulerProblem> solvedProblems = new List<ProjectEulerProblem>();
            solvedProblems.Add(new ProjectEulerProblem(18, true, ProjectEulerSolveMethods.Problem18Or67Solver));
            solvedProblems.Add(new ProjectEulerProblem(67, true, ProjectEulerSolveMethods.Problem18Or67Solver));
            solvedProblems.Add(new ProjectEulerProblem(81, true, ProjectEulerSolveMethods.Problem81Solver));
            solvedProblems.Add(new ProjectEulerProblem(102, true, ProjectEulerSolveMethods.Problem102Solver));
            solvedProblems.Add(new ProjectEulerProblem(190, false, ProjectEulerSolveMethods.Problem190Solver));

            return solvedProblems;
        }
    }
}