using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace StudentQuestions
{
    public partial class frmStudenQuestions : Form
    {
        //Define Lists
        List<TextBox> lstTextboxes = new List<TextBox>();
        List<string> lstStudents = new List<string>();
        public static List<int> lstUsedQuestions = new List<int>();
        public static List<string> lstQnA = new List<string>();

        bool QuestionLimitReached = false;

        //Define number of students
        int NumOfStudents;

        //Define Variables mostly used for flare colour wheel
        int Counter = 0;
        int SecondaryCounter = 0;
        int RandomStudent;
        bool StudentPicked = false;

        //Define Default and Selected Colours
        Color Default = Color.White;
        Color Selected = Color.Green;

        bool QuestionsLoaded = false;

        public frmStudenQuestions()
        {
            InitializeComponent();
        }

        private void frmStudenQuestions_Load(object sender, EventArgs e)
        {
            vGetSetRegistryInterval(false);

            //Check if btnPickStudents should be enabled or not
            vEnableButton();        
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            vGenerateStudentTextboxes();
        }

        private void vGenerateStudentTextboxes()
        {
            StudentPicked = false;
            NumOfStudents = decimal.ToInt32(nudNumOfStudents.Value);

            //If the value of students is greater than zero generate textboxes
            if (NumOfStudents > 0)
            {
                //Clear
                lblRandomStudent.Text = string.Empty;
                lstTextboxes.Clear();
                flpStudents.Controls.Clear();

                //Add a textbox for each number of students
                for (int i = 0; i < NumOfStudents; i++)
                {
                    vAddTextBox();
                }

                vEnableButton();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount of students!", "Attention!");
            }
        }

        private void vAddTextBox()
        {
            //Create new textbox and add them to lstTextBoxes and flpTextBoxes
            TextBox txtStudent = new TextBox();
            txtStudent.Anchor = AnchorStyles.None;
            flpStudents.Controls.Add(txtStudent);
            lstTextboxes.Add(txtStudent);
            txtStudent.ContextMenuStrip = cmsTextbox;
            txtStudent.Name += lstTextboxes.Count.ToString();
        }

        private void vWriteStudents()
        {
            //Write the students to the textboxes
            for (int i = 0; i < lstStudents.Count; i++)
            {
                lstTextboxes[i].Text = lstStudents[i];
            }
        }

        private void vPickStudent()
        {
            Random rdm = new Random();
            NumOfStudents = lstTextboxes.Count();

            if(StudentPicked == true)
            {
                lstTextboxes[RandomStudent].BackColor = Default;
            }

            //Pick a random student
            RandomStudent = rdm.Next(0, NumOfStudents);

            tmrFlare.Enabled = true;
            StudentPicked = true;
            Counter = 0;
            lblRandomStudent.Text = string.Empty;
            vEnableButton();
            btnGenerate.Enabled = false;
        }

        private void btnPickStudent_Click(object sender, EventArgs e)
        {
            //If none of the textboxes are empty run pickStudent routine
            if (!flpStudents.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                if(!cbQuestions.Checked)
                {
                    vPickStudent();
                }
                else if(cbQuestions.Checked && QuestionsLoaded)
                {
                    vPickStudent();
                }    
            }
            else
            {
                MessageBox.Show("One or more textbox(es), does not have a value!", "Attention!");
            }
        }

        private void vWriteStudentsToList()
        {
            //add Students to listbox
            lstStudents.Clear();

            for(int i = 0; i < lstTextboxes.Count; i++)
            {
                lstStudents.Add(lstTextboxes[i].Text);
            }
        }

        private void vEnableButton()
        {
            //Check if btnPickStudent should be enabled or not
            if (flpStudents.Controls.Count != 0 && !tmrFlare.Enabled && QuestionLimitReached == false)
            {
                btnPickStudent.Enabled = true;
            }
            else
            {
                btnPickStudent.Enabled = false;
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create new openfiledialog to open a textfile and add the contents to a list
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text Files (*.txt)|*.txt";
            ofd.Title = "Open Text File - Students";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lstStudents.Clear();
                    vResetQuestions();
                    lstStudents = System.IO.File.ReadAllLines(ofd.FileName).ToList();
                    nudNumOfStudents.Value = lstStudents.Count;
                    vGenerateStudentTextboxes();                
                    vWriteStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            ofd.Dispose();
        }

        private void saveFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save the contents of the textboxes to a user specified .txt file
            vWriteStudentsToList();
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.Title = "Save Text File - Students";
            sfd.RestoreDirectory = true;

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(sfd.FileName, lstStudents.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            //Get the clicked control and remove it
            var txtBox = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;

            if(txtBox != null)
            {
                flpStudents.Controls.Remove(txtBox);
                lstStudents.Remove(txtBox.Name);
                lstTextboxes.Remove((TextBox)txtBox);

                nudNumOfStudents.Value -= 1;
                vEnableButton();
            }
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            //Add a new textbox without messing with the current textboxes
            nudNumOfStudents.Value += 1;
            vAddTextBox();
            vEnableButton();
        }

        private void tmrFlare_Tick(object sender, EventArgs e)
        {
            //Run ChangeColour Routine
            vChangeColour();
        }

        private void vChangeColour()
        {
            //Check if the counter exceeds the count of lstTextboxes, and if it does, set it to 0
            if (Counter > lstTextboxes.Count - 1)
            {
                lstTextboxes[Counter - 1].BackColor = Default;
                Counter = 0;
            }

            //If the BackColour of [0] is Green, which it'll only be once per loop, set it to Default
            if (lstTextboxes[0].BackColor == Selected)
            {
                lstTextboxes[0].BackColor = Default;
            }

            //Change the current Textbox backcolour to green
            lstTextboxes[Counter].BackColor = Selected;
            
            //Check if the counter is greater than 1, and the previous textbox.backcolor is green, set it to default
            if (Counter > 1 && lstTextboxes[Counter - 1].BackColor == Selected)
            {
                lstTextboxes[Counter - 1].BackColor = Default;
            }

            //If the secondary counter has looped through the list X times continue loop untill Randomstudent is reached
            if (SecondaryCounter >= (lstTextboxes.Count * 3))
            {
                if(lstTextboxes[Counter] == lstTextboxes[RandomStudent])
                {
                    lblRandomStudent.Text = lstTextboxes[RandomStudent].Text;
                    tmrFlare.Enabled = false;
                    Counter = 0;
                    SecondaryCounter = 0;
                    btnGenerate.Enabled = true;
                    if (cbQuestions.Checked)
                    {
                        using (frmQnA frmQuestion = new frmQnA())
                        {
                            frmQuestion.Student = lstTextboxes[RandomStudent].Text;
                            frmQuestion.ShowDialog();
                            this.Text = string.Format("Student Questions {0} - {1}", lstUsedQuestions.Count, frmQnA.QnANumOfQuestions);
                            if (frmQnA.QnANumOfQuestions == lstUsedQuestions.Count)
                                QuestionLimitReached = true;
                                
                        }
                        
                    }

                    vEnableButton();
                }
            }
        //add 1 to Counter and SecondaryCounter
        Counter++;
        SecondaryCounter++;         
    }

        private void timerIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open a dialog with the second form, and change the timer interval based on the value entered
            using (frmTimerInterval frmTI = new frmTimerInterval())
            {
                frmTI.intTimerInterval = tmrFlare.Interval;
                tmrFlare.Interval = frmTI.intTimerInterval;

                if (frmTI.ShowDialog() == DialogResult.OK)
                {
                    tmrFlare.Interval = frmTI.intTimerInterval;
                    vGetSetRegistryInterval(true);
                }
            }     
        }

        private void nudNumOfStudents_KeyDown(object sender, KeyEventArgs e)
        {
            //If enter is hit in the Numeric up down, run the routine.
            if(e.KeyCode == Keys.Return)
            {
                vGenerateStudentTextboxes();
                e.SuppressKeyPress = true;
            }
        }

        private void vGetSetRegistryInterval(bool GetOrSet)
        {
            //Create or get a RegistryKey
            Microsoft.Win32.RegistryKey RegKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey SubKey = RegKey.CreateSubKey(@"SOFTWARE\Student Questions");

            //Set the value of Interval to timer interval
            if(GetOrSet)
            {  
                SubKey.SetValue("Interval", tmrFlare.Interval);
            }
            //Get the value of Interval in the registry, if none exists, default to 100
            else if(!GetOrSet)
            {    
                tmrFlare.Interval = (int)SubKey.GetValue("Interval", 100);     
            }
            //Close RegKey & SubKey
            SubKey.Close();
            RegKey.Close();
        }

        private void cbQuestions_CheckedChanged(object sender, EventArgs e)
        { 
            if (QuestionsLoaded == false)
                vOpenQuestionFile();
        }

        private void createQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuestionCreator frmCreator = new frmQuestionCreator();
            frmCreator.Show();
        }

        private void openQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vOpenQuestionFile();
        }

        private void vOpenQuestionFile()
        {       
            //This Openfiledialog Gets a user specefied .txt file and adds the content to a list
            lstUsedQuestions.Clear();
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text files (*.txt)|*.txt";
            ofd.Title = "Open Text File - Question";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lstQnA.Clear();
                    vResetQuestions();
                    lstQnA = System.IO.File.ReadAllLines(ofd.FileName).ToList();
                    QuestionsLoaded = true;
                    vGetQuestionAmount();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            ofd.Dispose();
        }

        private void resetQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vResetQuestions();
        }

        private void vResetQuestions()
        {
            //Resets the used questions so that they can be used again
            lstUsedQuestions.Clear();
            QuestionLimitReached = false;
            vGetQuestionAmount();
            vEnableButton();
        }

        private void vGetQuestionAmount()
        {
            //Get Amount of Questions and write the form text accordingly
            frmQnA.QnANumOfQuestions = 0;

            for (int i = 0; i < lstQnA.Count; i++)
            {
                if (lstQnA[i][0] == '?')
                {
                    frmQnA.QnANumOfQuestions++;
                }
            }
            this.Text = string.Format("Student Questions {0} - {1}", lstUsedQuestions.Count, frmQnA.QnANumOfQuestions);
        }
    }
}