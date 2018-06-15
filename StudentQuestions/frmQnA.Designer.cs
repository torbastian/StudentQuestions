namespace StudentQuestions
{
    partial class frmQnA
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
            this.rtbQuestion = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.tlpAnswers = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // rtbQuestion
            // 
            this.rtbQuestion.Location = new System.Drawing.Point(12, 12);
            this.rtbQuestion.Name = "rtbQuestion";
            this.rtbQuestion.ReadOnly = true;
            this.rtbQuestion.Size = new System.Drawing.Size(635, 110);
            this.rtbQuestion.TabIndex = 2;
            this.rtbQuestion.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 321);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinue.Location = new System.Drawing.Point(93, 321);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(106, 23);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // tlpAnswers
            // 
            this.tlpAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpAnswers.ColumnCount = 2;
            this.tlpAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.72441F));
            this.tlpAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.27559F));
            this.tlpAnswers.Location = new System.Drawing.Point(12, 128);
            this.tlpAnswers.Name = "tlpAnswers";
            this.tlpAnswers.RowCount = 2;
            this.tlpAnswers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAnswers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAnswers.Size = new System.Drawing.Size(635, 187);
            this.tlpAnswers.TabIndex = 5;
            // 
            // frmQnA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 350);
            this.Controls.Add(this.tlpAnswers);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rtbQuestion);
            this.Name = "frmQnA";
            this.ShowIcon = false;
            this.Text = "Question";
            this.Load += new System.EventHandler(this.QnA_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TableLayoutPanel tlpAnswers;
    }
}