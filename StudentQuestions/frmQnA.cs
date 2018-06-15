using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StudentQuestions
{
    public partial class frmQnA : Form
    {
        //Define lists, and varibles
        List<string> lstQnA = frmStudenQuestions.lstQnA;
        List<int> lstUsedQuestions = frmStudenQuestions.lstUsedQuestions;
        List<TextBox> lstAnswers = new List<TextBox>();
        List<int> lstQuestionIndex = new List<int>();

        public static int QnANumOfQuestions;
        public int Question;
        public string Student;

        public frmQnA()
        {
            InitializeComponent();
        }

        private void QnA_Load(object sender, EventArgs e)
        {
            //Set the title, enable scrolling and run routine
            lstUsedQuestions = frmStudenQuestions.lstUsedQuestions;
            this.Text += " - " + Student + "!";
            btnOk.Enabled = false;
            tlpAnswers.HorizontalScroll.Maximum = 0;
            tlpAnswers.AutoScroll = true;
            vGetQuestionAmount();
        }

        private void vGetQuestionAmount()
        {
            //Loop through the questions list and for each '?' add 1 to NumOfQuestions
            //And add i as Index, then run Next routine
            QnANumOfQuestions = 0;

            for (int i = 0; i < lstQnA.Count; i++)
            {
                if (lstQnA[i][0] == '?')
                {
                    QnANumOfQuestions++;
                    lstQuestionIndex.Add(i);
                }
            }
            vWriteQuestions();
        }

        private void vWriteQuestions()
        {
            //Pick a random question, then create Radiobuttons and Textboxes, untill the loop reaches the next question
            if (QnANumOfQuestions == lstUsedQuestions.Count)
            {
                MessageBox.Show(this, "Out of Questions", "Attention!");
                Close();
            }
            else
            {
                Random rdm = new Random();
                for (int i = 0; i < lstUsedQuestions.Count + 4; i++)
                {
                    Question = rdm.Next(0, QnANumOfQuestions);
                    if (!lstUsedQuestions.Contains(Question))
                        break;
                }

                rtbQuestion.Text = lstQnA[lstQuestionIndex[Question]];
                rtbQuestion.Text = rtbQuestion.Text.Substring(2);

                for (int i = lstQuestionIndex[Question] + 1; i < lstQnA.Count; i++)
                {
                    if (lstQnA[i][0] != '?')
                    {
                        RadioButton rdbAnswer = new RadioButton();
                        tlpAnswers.Controls.Add(rdbAnswer);
                        rdbAnswer.Tag = i.ToString();
                        rdbAnswer.CheckedChanged += RdbAnswer_CheckedChanged;

                        TextBox txtAnswer = new TextBox();
                        txtAnswer.Text = lstQnA[i];
                        txtAnswer.Text = txtAnswer.Text.Substring(2);
                        txtAnswer.ReadOnly = true;
                        tlpAnswers.Controls.Add(txtAnswer);
                        txtAnswer.Width = tlpAnswers.Width - 50;
                        txtAnswer.Tag = i.ToString();
                        lstAnswers.Add(txtAnswer);

                        txtAnswer.Name += i.ToString();
                        rdbAnswer.Name += i.ToString();
                    }
                    else
                        break;
                }
            }
        }

        private void RdbAnswer_CheckedChanged(object sender, EventArgs e)
        { 
            btnOk.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Disable button, then run through loop and set the backcolour according to answer correctness
            btnOk.Enabled = false;
            int counter = 0;
            for (int i = lstQuestionIndex[Question] + 1; i < lstQnA.Count; i++)
            {
                if (lstQnA[i][0] == '-')
                    lstAnswers[counter].BackColor = Color.Red;
                else if (lstQnA[i][0] == '+')
                    lstAnswers[counter].BackColor = Color.Green;
                else if (lstQnA[i][0] == '?')
                    break;

                counter++;
            }
            lstUsedQuestions.Add(Question);
            frmStudenQuestions.lstUsedQuestions = lstUsedQuestions;
        }
    }   
}