using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProjectEulerAssetWorksSample
{
    /// <summary>
    /// This class contains the code for the main Project Euler GUI form.
    /// </summary>
    public partial class ProjectEulerSolverForm : Form
    {
        // Initial strings for certain labels (assigned in constructor)
        private string InitialFileString;
        private string InitialSolutionString;
        
        #region Constructors

        /// <summary>
        /// This constructor initializes the properties of the form not set in the designer.
        /// </summary>
        public ProjectEulerSolverForm()
        {
            InitializeComponent(); // Built-in call

            // Determine what is initially displayed in certain labels - may need to revert to those labels later
            InitialFileString = this.linkLabelInput.Text;
            InitialSolutionString = this.labelSolution.Text;

            // Set tool tips (cannot preset in the designer)
            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(this.buttonSolve, "Run the solution to the selected problem. Current sample problems run " + 
                                                  "quickly, but future problems may have solutions that require up to a minute to run.");
            tooltip1.SetToolTip(this.buttonInputFile, "Select or modify the input file for the selected problem.");
            tooltip1.SetToolTip(this.buttonOutputCopy, "Copy the solution string to the clipboard for easy entry into the " + 
                                                       "solution box on the Project Euler website.");
            tooltip1.SetToolTip(this.buttonOutputFile, "Write the current problem information, including the solution, to a .csv file.");

            // Get the set list of problems (built-in for now - could partially be moved to a file)
            List<ProjectEulerProblem> myProblems = Program.InitializeMySolvedProblems();
            this.comboBoxProblem.DataSource = myProblems;
        }

        #endregion

        #region Events

        /// <summary>
        /// Capture the click event for the close button. This button will close the form.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        /// <summary>
        /// Capture the click event for the select input file button. This button allows the user to select
        /// a new text file to be used as the input file for the selected problem.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void buttonInputFile_Click(object sender, EventArgs e)
        {
            ProjectEulerProblem myProblem = this.MyCurrentProblem();
            if (myProblem.RequiresInputFile) // Need user to select a file
            {
                // Set open file dialog properties
                OpenFileDialog myOpenFileDialog = new OpenFileDialog();
                if (this.linkLabelInput.Enabled) // already have a file selected so start there
                {
                    myOpenFileDialog.InitialDirectory = Path.GetDirectoryName(this.linkLabelInput.Text);
                }
                myOpenFileDialog.Filter = "Text Files|*.txt"; // All inputs are text files
                myOpenFileDialog.Multiselect = false;
                myOpenFileDialog.Title = "Select Problem " + myProblem.ProblemNumber + " Input File";

                // Show the dialog and check if user clicked OK.
                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.linkLabelInput.Text = myOpenFileDialog.FileName;
                    this.linkLabelInput.Enabled = true; // Allow hyperlink
                }
            }
        }

        /// <summary>
        /// Capture the click event for the copy output button. This button copies the current solution string
        /// to the clipboard for easy entry into the solution box of the Project Euler website.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void buttonOutputCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.labelSolution.Text);
        }

        /// <summary>
        /// Capture the click event for the file output button. This button exports the current solution to a .csv file.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void buttonOutputFile_Click(object sender, EventArgs e)
        {
            // Set file dialog properties
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.Filter = "Comma-Separated Values Files|*.csv"; // Only write CSV
            myOpenFileDialog.Title = "Select Output File";
            myOpenFileDialog.Multiselect = false;

            // Show the dialog and check if user clicked OK.
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Determine whether to append or overwrite
                bool append = false;
                if (File.Exists(myOpenFileDialog.FileName))
                {
                    DialogResult result = MessageBox.Show("Append to existing file contents? (Otherwise, file contents will be overwritten.)", 
                                                          "File Append", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        append = true;
                    }
                    else if (result == DialogResult.No)
                    {
                        append = false;
                    }
                    else
                    {
                        return; // Early return
                    }
                }
                else
                {
                    append = false;
                }

                // Write problem information to file
                ProjectEulerProblem myProblem = this.MyCurrentProblem();
                List<string> lines = new List<string>();
                if (!append) // Write headers
                {
                    lines.Add(string.Join(",", "Full Description", "Number", "Title", "Link",
                                          "Solution", "Time To Solve"));
                }
                lines.Add(string.Join(",", myProblem.ToString(), myProblem.ProblemNumber, myProblem.Title,
                                      this.linkLabelHyperlink.Text, this.labelSolution.Text, this.labelTimeElapsed.Text));
                try
                {
                    if (append)
                    {
                        File.AppendAllLines(myOpenFileDialog.FileName, lines);
                    }
                    else
                    {
                        File.WriteAllLines(myOpenFileDialog.FileName, lines);
                    }
                }
                catch // catch any IO exception - could make more specific in future iterations
                {
                    MessageBox.Show("Unexpected error writing to file. Check file permissions and try again.", "Unexpected Error", 
                                    MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Capture the click event for the solve button. This button will run the solution method for the 
        /// selected problem.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            // Gather the input file string if necessary
            ProjectEulerProblem myProblem = this.MyCurrentProblem();
            string inputFile = null;
            if (myProblem.RequiresInputFile)
            {
                inputFile = this.linkLabelInput.Text;
                if (inputFile.Equals(InitialFileString))
                {
                    inputFile = null;
                }
            }

            // Run the solution algorithm
            double timeToSolve;
            string sol = myProblem.RunSolution(out timeToSolve, inputFile);
            
            // Display solution
            if (sol == null)
            {
                this.labelSolution.Text = InitialSolutionString;
                this.labelTimeElapsed.Text = InitialSolutionString;
            }
            else
            {
                this.labelSolution.Text = sol;
                this.labelTimeElapsed.Text = timeToSolve.ToString();
            }
        }

        /// <summary>
        /// Capture the selected index change event for the problem combobox. This will update the display
        /// for controls below the combobox.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void comboBoxProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectEulerProblem myProblem = this.MyCurrentProblem();
            
            // Show/hide input file controls
            bool showInput = myProblem.RequiresInputFile;
            this.linkLabelInput.Visible = showInput;
            this.labelStaticInput.Visible = showInput;
            this.buttonInputFile.Visible = showInput;

            this.linkLabelHyperlink.Text = myProblem.Hyperlink(); // Update hyperlink
            
            // Update solution controls
            this.labelSolution.Text = InitialSolutionString;
            this.labelTimeElapsed.Text = InitialSolutionString;
        }

        /// <summary>
        /// Capture the text change event for the label.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void labelSolution_TextChanged(object sender, EventArgs e)
        {
            bool enabled = (labelSolution.Text != InitialSolutionString);
            this.buttonOutputCopy.Enabled = enabled;
            this.buttonOutputFile.Enabled = enabled;
        }

        /// <summary>
        /// Capture the click event for the hypelink label. This will follow the given link.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void linkLabelHyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FollowHyperlink(linkLabelHyperlink.Text);
        }

        /// <summary>
        /// Capture the click event for the input file label. This will follow the given link.
        /// </summary>
        /// <param name="sender">Built-in parameter.</param>
        /// <param name="e">Built-in parameter.</param>
        private void linkLabelInput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Check if file still exists
            string myFile = linkLabelInput.Text;
            if (!File.Exists(myFile)) // Remove selected file text
            {
                MessageBox.Show("Selected file no longer exists.", "Missing File", MessageBoxButtons.OK);
                linkLabelInput.Text = InitialFileString;
                linkLabelInput.Enabled = false;
            }
            else // Follow link
            {
                FollowHyperlink(linkLabelInput.Text);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method follows a hyperlink with the given text.
        /// </summary>
        /// <param name="text">File or URL text to go to.</param>
        private void FollowHyperlink(string text)
        {
            System.Diagnostics.Process.Start(text);
        }

        /// <summary>
        /// Return the currently selected Project Euler problem.
        /// </summary>
        /// <returns></returns>
        private ProjectEulerProblem MyCurrentProblem()
        {
            return (ProjectEulerProblem)this.comboBoxProblem.SelectedItem; // Combobox tied to list of Project Euler instances so hard casting okay
        }

        #endregion
    }
}