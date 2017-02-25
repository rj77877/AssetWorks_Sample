namespace ProjectEulerAssetWorksSample
{
    partial class ProjectEulerSolverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxProblem = new System.Windows.Forms.ComboBox();
            this.labelStaticProblem = new System.Windows.Forms.Label();
            this.labelStaticLink = new System.Windows.Forms.Label();
            this.linkLabelHyperlink = new System.Windows.Forms.LinkLabel();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.labelStaticSolution = new System.Windows.Forms.Label();
            this.labelSolution = new System.Windows.Forms.Label();
            this.labelStaticTime = new System.Windows.Forms.Label();
            this.labelTimeElapsed = new System.Windows.Forms.Label();
            this.labelStaticInput = new System.Windows.Forms.Label();
            this.linkLabelInput = new System.Windows.Forms.LinkLabel();
            this.buttonInputFile = new System.Windows.Forms.Button();
            this.buttonOutputCopy = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOutputFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxProblem
            // 
            this.comboBoxProblem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProblem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProblem.FormattingEnabled = true;
            this.comboBoxProblem.Location = new System.Drawing.Point(74, 22);
            this.comboBoxProblem.Name = "comboBoxProblem";
            this.comboBoxProblem.Size = new System.Drawing.Size(250, 21);
            this.comboBoxProblem.TabIndex = 1;
            this.comboBoxProblem.SelectedIndexChanged += new System.EventHandler(this.comboBoxProblem_SelectedIndexChanged);
            // 
            // labelStaticProblem
            // 
            this.labelStaticProblem.AutoSize = true;
            this.labelStaticProblem.Location = new System.Drawing.Point(10, 26);
            this.labelStaticProblem.Name = "labelStaticProblem";
            this.labelStaticProblem.Size = new System.Drawing.Size(58, 13);
            this.labelStaticProblem.TabIndex = 0;
            this.labelStaticProblem.Text = "Problem #:";
            // 
            // labelStaticLink
            // 
            this.labelStaticLink.AutoSize = true;
            this.labelStaticLink.Location = new System.Drawing.Point(10, 90);
            this.labelStaticLink.Name = "labelStaticLink";
            this.labelStaticLink.Size = new System.Drawing.Size(117, 13);
            this.labelStaticLink.TabIndex = 6;
            this.labelStaticLink.Text = "Project Euler Hyperlink:";
            // 
            // linkLabelHyperlink
            // 
            this.linkLabelHyperlink.AutoSize = true;
            this.linkLabelHyperlink.Location = new System.Drawing.Point(133, 90);
            this.linkLabelHyperlink.Name = "linkLabelHyperlink";
            this.linkLabelHyperlink.Size = new System.Drawing.Size(144, 13);
            this.linkLabelHyperlink.TabIndex = 7;
            this.linkLabelHyperlink.TabStop = true;
            this.linkLabelHyperlink.Text = "[PLACE HYPERLINK HERE]";
            this.linkLabelHyperlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHyperlink_LinkClicked);
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(330, 20);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(100, 25);
            this.buttonSolve.TabIndex = 2;
            this.buttonSolve.Text = "Solve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // labelStaticSolution
            // 
            this.labelStaticSolution.AutoSize = true;
            this.labelStaticSolution.Location = new System.Drawing.Point(10, 129);
            this.labelStaticSolution.Name = "labelStaticSolution";
            this.labelStaticSolution.Size = new System.Drawing.Size(48, 13);
            this.labelStaticSolution.TabIndex = 8;
            this.labelStaticSolution.Text = "Solution:";
            // 
            // labelSolution
            // 
            this.labelSolution.AutoSize = true;
            this.labelSolution.Location = new System.Drawing.Point(64, 129);
            this.labelSolution.Name = "labelSolution";
            this.labelSolution.Size = new System.Drawing.Size(27, 13);
            this.labelSolution.TabIndex = 9;
            this.labelSolution.Text = "N/A";
            this.labelSolution.TextChanged += new System.EventHandler(this.labelSolution_TextChanged);
            // 
            // labelStaticTime
            // 
            this.labelStaticTime.AutoSize = true;
            this.labelStaticTime.Location = new System.Drawing.Point(10, 167);
            this.labelStaticTime.Name = "labelStaticTime";
            this.labelStaticTime.Size = new System.Drawing.Size(125, 13);
            this.labelStaticTime.TabIndex = 11;
            this.labelStaticTime.Text = "Time Elapsed (Seconds):";
            // 
            // labelTimeElapsed
            // 
            this.labelTimeElapsed.AutoSize = true;
            this.labelTimeElapsed.Location = new System.Drawing.Point(141, 167);
            this.labelTimeElapsed.Name = "labelTimeElapsed";
            this.labelTimeElapsed.Size = new System.Drawing.Size(27, 13);
            this.labelTimeElapsed.TabIndex = 12;
            this.labelTimeElapsed.Text = "N/A";
            // 
            // labelStaticInput
            // 
            this.labelStaticInput.AutoSize = true;
            this.labelStaticInput.Location = new System.Drawing.Point(10, 61);
            this.labelStaticInput.Name = "labelStaticInput";
            this.labelStaticInput.Size = new System.Drawing.Size(53, 13);
            this.labelStaticInput.TabIndex = 3;
            this.labelStaticInput.Text = "Input File:";
            // 
            // linkLabelInput
            // 
            this.linkLabelInput.AutoSize = true;
            this.linkLabelInput.Enabled = false;
            this.linkLabelInput.Location = new System.Drawing.Point(69, 61);
            this.linkLabelInput.Name = "linkLabelInput";
            this.linkLabelInput.Size = new System.Drawing.Size(112, 13);
            this.linkLabelInput.TabIndex = 4;
            this.linkLabelInput.TabStop = true;
            this.linkLabelInput.Text = "No Input File Selected";
            this.linkLabelInput.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInput_LinkClicked);
            // 
            // buttonInputFile
            // 
            this.buttonInputFile.Location = new System.Drawing.Point(570, 55);
            this.buttonInputFile.Name = "buttonInputFile";
            this.buttonInputFile.Size = new System.Drawing.Size(100, 25);
            this.buttonInputFile.TabIndex = 5;
            this.buttonInputFile.Text = "Select Input File...";
            this.buttonInputFile.UseVisualStyleBackColor = true;
            this.buttonInputFile.Click += new System.EventHandler(this.buttonInputFile_Click);
            // 
            // buttonOutputCopy
            // 
            this.buttonOutputCopy.Enabled = false;
            this.buttonOutputCopy.Location = new System.Drawing.Point(163, 113);
            this.buttonOutputCopy.Name = "buttonOutputCopy";
            this.buttonOutputCopy.Size = new System.Drawing.Size(100, 44);
            this.buttonOutputCopy.TabIndex = 10;
            this.buttonOutputCopy.Text = "Copy Solution To Clipboard";
            this.buttonOutputCopy.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(570, 190);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 25);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOutputFile
            // 
            this.buttonOutputFile.Enabled = false;
            this.buttonOutputFile.Location = new System.Drawing.Point(280, 113);
            this.buttonOutputFile.Name = "buttonOutputFile";
            this.buttonOutputFile.Size = new System.Drawing.Size(100, 44);
            this.buttonOutputFile.TabIndex = 14;
            this.buttonOutputFile.Text = "Write Solution(s) to CSV File";
            this.buttonOutputFile.UseVisualStyleBackColor = true;
            this.buttonOutputFile.Click += new System.EventHandler(this.buttonOutputFile_Click);
            // 
            // ProjectEulerSolverForm
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(685, 231);
            this.Controls.Add(this.buttonOutputFile);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOutputCopy);
            this.Controls.Add(this.buttonInputFile);
            this.Controls.Add(this.linkLabelInput);
            this.Controls.Add(this.labelStaticInput);
            this.Controls.Add(this.labelTimeElapsed);
            this.Controls.Add(this.labelStaticTime);
            this.Controls.Add(this.labelSolution);
            this.Controls.Add(this.labelStaticSolution);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.linkLabelHyperlink);
            this.Controls.Add(this.labelStaticLink);
            this.Controls.Add(this.labelStaticProblem);
            this.Controls.Add(this.comboBoxProblem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectEulerSolverForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Euler Problems";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProblem;
        private System.Windows.Forms.Label labelStaticProblem;
        private System.Windows.Forms.Label labelStaticLink;
        private System.Windows.Forms.LinkLabel linkLabelHyperlink;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Label labelStaticSolution;
        private System.Windows.Forms.Label labelSolution;
        private System.Windows.Forms.Label labelStaticTime;
        private System.Windows.Forms.Label labelTimeElapsed;
        private System.Windows.Forms.Label labelStaticInput;
        private System.Windows.Forms.LinkLabel linkLabelInput;
        private System.Windows.Forms.Button buttonInputFile;
        private System.Windows.Forms.Button buttonOutputCopy;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOutputFile;
    }
}

