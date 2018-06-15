namespace StudentQuestions
{
    partial class frmStudenQuestions
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
            this.components = new System.ComponentModel.Container();
            this.nudNumOfStudents = new System.Windows.Forms.NumericUpDown();
            this.flpStudents = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsFlp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmFlpAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPickStudent = new System.Windows.Forms.Button();
            this.lblRandomStudent = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTextbox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrFlare = new System.Windows.Forms.Timer(this.components);
            this.cbQuestions = new System.Windows.Forms.CheckBox();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerIntervalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createQuestionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfStudents)).BeginInit();
            this.cmsFlp.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cmsTextbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudNumOfStudents
            // 
            this.nudNumOfStudents.Location = new System.Drawing.Point(16, 38);
            this.nudNumOfStudents.Margin = new System.Windows.Forms.Padding(4);
            this.nudNumOfStudents.Name = "nudNumOfStudents";
            this.nudNumOfStudents.Size = new System.Drawing.Size(57, 22);
            this.nudNumOfStudents.TabIndex = 0;
            this.nudNumOfStudents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudNumOfStudents_KeyDown);
            // 
            // flpStudents
            // 
            this.flpStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpStudents.AutoScroll = true;
            this.flpStudents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpStudents.ContextMenuStrip = this.cmsFlp;
            this.flpStudents.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpStudents.Location = new System.Drawing.Point(16, 90);
            this.flpStudents.Margin = new System.Windows.Forms.Padding(4);
            this.flpStudents.Name = "flpStudents";
            this.flpStudents.Size = new System.Drawing.Size(448, 371);
            this.flpStudents.TabIndex = 1;
            // 
            // cmsFlp
            // 
            this.cmsFlp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFlp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFlpAdd});
            this.cmsFlp.Name = "cmsFlp";
            this.cmsFlp.Size = new System.Drawing.Size(113, 30);
            // 
            // tsmFlpAdd
            // 
            this.tsmFlpAdd.Name = "tsmFlpAdd";
            this.tsmFlpAdd.Size = new System.Drawing.Size(112, 26);
            this.tsmFlpAdd.Text = "&Add";
            this.tsmFlpAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(80, 35);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 28);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnPickStudent
            // 
            this.btnPickStudent.Location = new System.Drawing.Point(188, 35);
            this.btnPickStudent.Margin = new System.Windows.Forms.Padding(4);
            this.btnPickStudent.Name = "btnPickStudent";
            this.btnPickStudent.Size = new System.Drawing.Size(100, 28);
            this.btnPickStudent.TabIndex = 3;
            this.btnPickStudent.Text = "Pick Student";
            this.btnPickStudent.UseVisualStyleBackColor = true;
            this.btnPickStudent.Click += new System.EventHandler(this.btnPickStudent_Click);
            // 
            // lblRandomStudent
            // 
            this.lblRandomStudent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRandomStudent.Location = new System.Drawing.Point(296, 38);
            this.lblRandomStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomStudent.Name = "lblRandomStudent";
            this.lblRandomStudent.Size = new System.Drawing.Size(168, 22);
            this.lblRandomStudent.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFIleToolStripMenuItem,
            this.openQuestionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.openFileToolStripMenuItem.Text = "&Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFIleToolStripMenuItem
            // 
            this.saveFIleToolStripMenuItem.Name = "saveFIleToolStripMenuItem";
            this.saveFIleToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.saveFIleToolStripMenuItem.Text = "&Save File...";
            this.saveFIleToolStripMenuItem.Click += new System.EventHandler(this.saveFIleToolStripMenuItem_Click);
            // 
            // openQuestionsToolStripMenuItem
            // 
            this.openQuestionsToolStripMenuItem.Name = "openQuestionsToolStripMenuItem";
            this.openQuestionsToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.openQuestionsToolStripMenuItem.Text = "&Open Questions...";
            this.openQuestionsToolStripMenuItem.Click += new System.EventHandler(this.openQuestionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // cmsTextbox
            // 
            this.cmsTextbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTextbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRemove,
            this.tsmAdd});
            this.cmsTextbox.Name = "contextMenuStrip1";
            this.cmsTextbox.Size = new System.Drawing.Size(139, 56);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(138, 26);
            this.tsmRemove.Text = "&Remove";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(138, 26);
            this.tsmAdd.Text = "&Add";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tmrFlare
            // 
            this.tmrFlare.Tick += new System.EventHandler(this.tmrFlare_Tick);
            // 
            // cbQuestions
            // 
            this.cbQuestions.AutoSize = true;
            this.cbQuestions.Location = new System.Drawing.Point(16, 67);
            this.cbQuestions.Name = "cbQuestions";
            this.cbQuestions.Size = new System.Drawing.Size(94, 21);
            this.cbQuestions.TabIndex = 6;
            this.cbQuestions.Text = "Questions";
            this.cbQuestions.UseVisualStyleBackColor = true;
            this.cbQuestions.CheckedChanged += new System.EventHandler(this.cbQuestions_CheckedChanged);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerIntervalToolStripMenuItem1,
            this.createQuestionsToolStripMenuItem1,
            this.resetQuestionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // timerIntervalToolStripMenuItem1
            // 
            this.timerIntervalToolStripMenuItem1.Name = "timerIntervalToolStripMenuItem1";
            this.timerIntervalToolStripMenuItem1.Size = new System.Drawing.Size(196, 26);
            this.timerIntervalToolStripMenuItem1.Text = "&Timer Interval";
            this.timerIntervalToolStripMenuItem1.Click += new System.EventHandler(this.timerIntervalToolStripMenuItem_Click);
            // 
            // createQuestionsToolStripMenuItem1
            // 
            this.createQuestionsToolStripMenuItem1.Name = "createQuestionsToolStripMenuItem1";
            this.createQuestionsToolStripMenuItem1.Size = new System.Drawing.Size(196, 26);
            this.createQuestionsToolStripMenuItem1.Text = "&Create Questions";
            this.createQuestionsToolStripMenuItem1.Click += new System.EventHandler(this.createQuestionsToolStripMenuItem_Click);
            // 
            // resetQuestionsToolStripMenuItem
            // 
            this.resetQuestionsToolStripMenuItem.Name = "resetQuestionsToolStripMenuItem";
            this.resetQuestionsToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.resetQuestionsToolStripMenuItem.Text = "&Reset Questions";
            this.resetQuestionsToolStripMenuItem.Click += new System.EventHandler(this.resetQuestionsToolStripMenuItem_Click);
            // 
            // frmStudenQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 477);
            this.Controls.Add(this.cbQuestions);
            this.Controls.Add(this.lblRandomStudent);
            this.Controls.Add(this.btnPickStudent);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.flpStudents);
            this.Controls.Add(this.nudNumOfStudents);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStudenQuestions";
            this.ShowIcon = false;
            this.Text = "Student Questions";
            this.Load += new System.EventHandler(this.frmStudenQuestions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfStudents)).EndInit();
            this.cmsFlp.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsTextbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudNumOfStudents;
        private System.Windows.Forms.FlowLayoutPanel flpStudents;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPickStudent;
        private System.Windows.Forms.Label lblRandomStudent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsTextbox;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ContextMenuStrip cmsFlp;
        private System.Windows.Forms.ToolStripMenuItem tsmFlpAdd;
        public System.Windows.Forms.Timer tmrFlare;
        private System.Windows.Forms.CheckBox cbQuestions;
        private System.Windows.Forms.ToolStripMenuItem openQuestionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerIntervalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createQuestionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetQuestionsToolStripMenuItem;
    }
}

