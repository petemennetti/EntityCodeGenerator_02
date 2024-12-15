namespace EntityCodeGenerator_02
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboDatabases = new ComboBox();
            label1 = new Label();
            lstTables = new CheckedListBox();
            label4 = new Label();
            txtOutputPath = new TextBox();
            btnGenerate = new Button();
            optTables = new RadioButton();
            optViews = new RadioButton();
            label2 = new Label();
            txtNameSpace = new TextBox();
            txtServerName = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // cboDatabases
            // 
            cboDatabases.FormattingEnabled = true;
            cboDatabases.Location = new Point(12, 101);
            cboDatabases.Name = "cboDatabases";
            cboDatabases.Size = new Size(236, 23);
            cboDatabases.TabIndex = 0;
            cboDatabases.SelectedIndexChanged += cboDatabases_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 83);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Databases:";
            // 
            // lstTables
            // 
            lstTables.CheckOnClick = true;
            lstTables.FormattingEnabled = true;
            lstTables.Location = new Point(12, 224);
            lstTables.Name = "lstTables";
            lstTables.Size = new Size(557, 364);
            lstTables.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 33);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 10;
            label4.Text = "Output Path:";
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(254, 51);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(315, 23);
            txtOutputPath.TabIndex = 9;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 594);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(557, 74);
            btnGenerate.TabIndex = 12;
            btnGenerate.Text = "Generate Entity";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // optTables
            // 
            optTables.AutoSize = true;
            optTables.Location = new Point(254, 128);
            optTables.Name = "optTables";
            optTables.Size = new Size(57, 19);
            optTables.TabIndex = 13;
            optTables.TabStop = true;
            optTables.Text = "Tables";
            optTables.UseVisualStyleBackColor = true;
            optTables.CheckedChanged += optTables_CheckedChanged;
            // 
            // optViews
            // 
            optViews.AutoSize = true;
            optViews.Location = new Point(254, 153);
            optViews.Name = "optViews";
            optViews.Size = new Size(55, 19);
            optViews.TabIndex = 14;
            optViews.TabStop = true;
            optViews.Text = "Views";
            optViews.UseVisualStyleBackColor = true;
            optViews.CheckedChanged += optViews_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 83);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 16;
            label2.Text = "Name Space:";
            // 
            // txtNameSpace
            // 
            txtNameSpace.Location = new Point(254, 101);
            txtNameSpace.Name = "txtNameSpace";
            txtNameSpace.Size = new Size(315, 23);
            txtNameSpace.TabIndex = 15;
            // 
            // txtServerName
            // 
            txtServerName.Location = new Point(12, 51);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(236, 23);
            txtServerName.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 33);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 18;
            label3.Text = "Server:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 675);
            Controls.Add(label3);
            Controls.Add(txtServerName);
            Controls.Add(label2);
            Controls.Add(txtNameSpace);
            Controls.Add(optViews);
            Controls.Add(optTables);
            Controls.Add(btnGenerate);
            Controls.Add(label4);
            Controls.Add(txtOutputPath);
            Controls.Add(lstTables);
            Controls.Add(label1);
            Controls.Add(cboDatabases);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "C# Entity Code Generator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboDatabases;
        private Label label1;
        private CheckedListBox lstTables;
        private Label label4;
        private TextBox txtOutputPath;
        private Button btnGenerate;
        private RadioButton optTables;
        private RadioButton optViews;
        private Label label2;
        private TextBox txtNameSpace;
        private TextBox txtServerName;
        private Label label3;
    }
}
