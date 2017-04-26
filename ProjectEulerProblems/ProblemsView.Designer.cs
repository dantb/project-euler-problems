namespace ProjectEulerProblems
{
    partial class ProblemsView
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
            this.ProblemsListView = new System.Windows.Forms.ListView();
            this.ProblemIdCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProblemDescriptionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SolutionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ProblemsListView
            // 
            this.ProblemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProblemIdCol,
            this.ProblemDescriptionCol,
            this.SolutionCol});
            this.ProblemsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProblemsListView.GridLines = true;
            this.ProblemsListView.Location = new System.Drawing.Point(0, 0);
            this.ProblemsListView.Name = "ProblemsListView";
            this.ProblemsListView.Size = new System.Drawing.Size(295, 243);
            this.ProblemsListView.TabIndex = 0;
            this.ProblemsListView.UseCompatibleStateImageBehavior = false;
            this.ProblemsListView.View = System.Windows.Forms.View.Details;
            // 
            // ProblemIdCol
            // 
            this.ProblemIdCol.Text = "Problem ID";
            this.ProblemIdCol.Width = 100;
            // 
            // ProblemDescriptionCol
            // 
            this.ProblemDescriptionCol.Text = "Description";
            this.ProblemDescriptionCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProblemDescriptionCol.Width = 100;
            // 
            // SolutionCol
            // 
            this.SolutionCol.Text = "Solution";
            this.SolutionCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SolutionCol.Width = 100;
            // 
            // Problems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(295, 243);
            this.Controls.Add(this.ProblemsListView);
            this.Name = "Problems";
            this.Text = "Problems from Project Euler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ProblemsListView;
        private System.Windows.Forms.ColumnHeader ProblemIdCol;
        private System.Windows.Forms.ColumnHeader ProblemDescriptionCol;
        private System.Windows.Forms.ColumnHeader SolutionCol;
    }
}

