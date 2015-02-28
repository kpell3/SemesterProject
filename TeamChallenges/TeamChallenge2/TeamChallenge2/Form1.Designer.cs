namespace TeamChallenge2
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ShowButton = new System.Windows.Forms.Button();
            this.AddMemberName = new System.Windows.Forms.TextBox();
            this.AddMemberNameLabel = new System.Windows.Forms.Label();
            this.DataView1 = new System.Windows.Forms.DataGridView();
            this.AddMemberJob = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Remove = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jobs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateMemberButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 301);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(95, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Add A Member";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(121, 216);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(152, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove Selected Member(s)";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(12, 216);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(103, 23);
            this.ShowButton.TabIndex = 1;
            this.ShowButton.Text = "Show Members";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // AddMemberName
            // 
            this.AddMemberName.Location = new System.Drawing.Point(12, 275);
            this.AddMemberName.Name = "AddMemberName";
            this.AddMemberName.Size = new System.Drawing.Size(100, 20);
            this.AddMemberName.TabIndex = 3;
            // 
            // AddMemberNameLabel
            // 
            this.AddMemberNameLabel.AutoSize = true;
            this.AddMemberNameLabel.Location = new System.Drawing.Point(12, 259);
            this.AddMemberNameLabel.Name = "AddMemberNameLabel";
            this.AddMemberNameLabel.Size = new System.Drawing.Size(35, 13);
            this.AddMemberNameLabel.TabIndex = 5;
            this.AddMemberNameLabel.Text = "Name";
            // 
            // DataView1
            // 
            this.DataView1.AllowUserToAddRows = false;
            this.DataView1.AllowUserToDeleteRows = false;
            this.DataView1.AllowUserToResizeColumns = false;
            this.DataView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove,
            this.Names,
            this.Jobs});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataView1.Location = new System.Drawing.Point(12, 12);
            this.DataView1.Name = "DataView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataView1.Size = new System.Drawing.Size(423, 200);
            this.DataView1.TabIndex = 0;
            // 
            // AddMemberJob
            // 
            this.AddMemberJob.Location = new System.Drawing.Point(118, 275);
            this.AddMemberJob.Name = "AddMemberJob";
            this.AddMemberJob.Size = new System.Drawing.Size(100, 20);
            this.AddMemberJob.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Job";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Add/Update Member";
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Change";
            this.Remove.Name = "Remove";
            this.Remove.Width = 60;
            // 
            // Names
            // 
            this.Names.HeaderText = "Names";
            this.Names.Name = "Names";
            this.Names.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Names.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Names.Width = 160;
            // 
            // Jobs
            // 
            this.Jobs.HeaderText = "Jobs";
            this.Jobs.Name = "Jobs";
            this.Jobs.Width = 160;
            // 
            // UpdateMemberButton
            // 
            this.UpdateMemberButton.Location = new System.Drawing.Point(121, 301);
            this.UpdateMemberButton.Name = "UpdateMemberButton";
            this.UpdateMemberButton.Size = new System.Drawing.Size(152, 23);
            this.UpdateMemberButton.TabIndex = 6;
            this.UpdateMemberButton.Text = "Update Selected Member(s)";
            this.UpdateMemberButton.UseVisualStyleBackColor = true;
            this.UpdateMemberButton.Click += new System.EventHandler(this.UpdateMemberButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 347);
            this.Controls.Add(this.UpdateMemberButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddMemberJob);
            this.Controls.Add(this.DataView1);
            this.Controls.Add(this.AddMemberNameLabel);
            this.Controls.Add(this.AddMemberName);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Name = "Form1";
            this.Text = "TeamChallenge2";
            ((System.ComponentModel.ISupportInitialize)(this.DataView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.TextBox AddMemberName;
        private System.Windows.Forms.Label AddMemberNameLabel;
        private System.Windows.Forms.DataGridView DataView1;
        private System.Windows.Forms.TextBox AddMemberJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jobs;
        private System.Windows.Forms.Button UpdateMemberButton;
    }
}

