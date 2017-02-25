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
        #region Constructors

        /// <summary>
        /// This constructor initializes the properties of the form not set in the designer.
        /// </summary>
        public ProjectEulerSolverForm()
        {
            InitializeComponent(); // Built-in call

            // Set tool tips (cannot preset in the designer)
            ToolTip tooltip1 = new ToolTip();
            tooltip1.SetToolTip(this.buttonSolve, "Run the solution to the selected problem. Current sample problems run " + 
                                                  "quickly, but future problems may have solutions that require up to a minute to run.");
            tooltip1.SetToolTip(this.buttonInputFile, "Select or modify the input file for the selected problem.");
            tooltip1.SetToolTip(this.buttonOutputCopy, "Copy the solution string to the clipboard for easy entry into the " + 
                                                       "solution box on the Project Euler website.");

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
                if (inputFile.Equals("No Input File Selected"))
                {
                    inputFile = null;
                }
            }

            // Run the solution algorithm
            double timeToSolve;
            string sol = myProblem.MySolution(out timeToSolve, inputFile);
            
            // Display solution
            if (sol == null)
            {
                this.labelSolution.Text = "N/A";
                this.labelTimeElapsed.Text = "N/A";
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
            this.labelSolution.Text = "N/A";
            this.labelTimeElapsed.Text = "N/A";
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
                linkLabelInput.Text = "No Input File Selected";
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