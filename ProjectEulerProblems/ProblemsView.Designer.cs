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
            this.SolvingTimeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProblemRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ListViewAndDetailsSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewAndDetailsSplitContainer)).BeginInit();
            this.ListViewAndDetailsSplitContainer.Panel1.SuspendLayout();
            this.ListViewAndDetailsSplitContainer.Panel2.SuspendLayout();
            this.ListViewAndDetailsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProblemsListView
            // 
            this.ProblemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProblemIdCol,
            this.ProblemDescriptionCol,
            this.SolutionCol,
            this.SolvingTimeCol});
            this.ProblemsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProblemsListView.FullRowSelect = true;
            this.ProblemsListView.GridLines = true;
            this.ProblemsListView.Location = new System.Drawing.Point(0, 0);
            this.ProblemsListView.Name = "ProblemsListView";
            this.ProblemsListView.Size = new System.Drawing.Size(628, 319);
            this.ProblemsListView.TabIndex = 0;
            this.ProblemsListView.UseCompatibleStateImageBehavior = false;
            this.ProblemsListView.View = System.Windows.Forms.View.Details;
            this.ProblemsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProblemsListView_KeyUp);
            this.ProblemsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ProblemsListView_MouseDoubleClick);
            // 
            // ProblemIdCol
            // 
            this.ProblemIdCol.Text = "Problem ID";
            this.ProblemIdCol.Width = 100;
            // 
            // ProblemDescriptionCol
            // 
            this.ProblemDescriptionCol.Text = "Description";
            this.ProblemDescriptionCol.Width = 100;
            // 
            // SolutionCol
            // 
            this.SolutionCol.Text = "Solution";
            this.SolutionCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SolutionCol.Width = 100;
            // 
            // SolvingTimeCol
            // 
            this.SolvingTimeCol.Text = "Solving Time (Milliseconds)";
            this.SolvingTimeCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SolvingTimeCol.Width = 100;
            // 
            // ProblemRichTextBox
            // 
            this.ProblemRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProblemRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.ProblemRichTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.ProblemRichTextBox.Name = "ProblemRichTextBox";
            this.ProblemRichTextBox.Size = new System.Drawing.Size(628, 187);
            this.ProblemRichTextBox.TabIndex = 1;
            this.ProblemRichTextBox.Text = "";
            this.ProblemRichTextBox.Visible = false;
            // 
            // ListViewAndDetailsSplitContainer
            // 
            this.ListViewAndDetailsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewAndDetailsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ListViewAndDetailsSplitContainer.Name = "ListViewAndDetailsSplitContainer";
            this.ListViewAndDetailsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ListViewAndDetailsSplitContainer.Panel1
            // 
            this.ListViewAndDetailsSplitContainer.Panel1.Controls.Add(this.ProblemsListView);
            // 
            // ListViewAndDetailsSplitContainer.Panel2
            // 
            this.ListViewAndDetailsSplitContainer.Panel2.Controls.Add(this.ProblemRichTextBox);
            this.ListViewAndDetailsSplitContainer.Size = new System.Drawing.Size(628, 510);
            this.ListViewAndDetailsSplitContainer.SplitterDistance = 319;
            this.ListViewAndDetailsSplitContainer.TabIndex = 2;
            // 
            // ProblemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(628, 510);
            this.Controls.Add(this.ListViewAndDetailsSplitContainer);
            this.Name = "ProblemsView";
            this.Text = "Problems from Project Euler";
            this.ListViewAndDetailsSplitContainer.Panel1.ResumeLayout(false);
            this.ListViewAndDetailsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListViewAndDetailsSplitContainer)).EndInit();
            this.ListViewAndDetailsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ProblemsListView;
        private System.Windows.Forms.ColumnHeader ProblemIdCol;
        private System.Windows.Forms.ColumnHeader ProblemDescriptionCol;
        private System.Windows.Forms.ColumnHeader SolutionCol;
        private System.Windows.Forms.RichTextBox ProblemRichTextBox;
        private System.Windows.Forms.ColumnHeader SolvingTimeCol;
        private System.Windows.Forms.SplitContainer ListViewAndDetailsSplitContainer;
    }
}

