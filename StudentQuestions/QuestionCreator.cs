using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentQuestions
{
    public partial class frmQuestionCreator : Form
    {
        //Define lists & Variables
        List<Control> lstTextboxes = new List<Control>();
        List<CheckBox> lstCheckboxes = new List<CheckBox>();
        List<string> lstQnA = new List<string>();
        List<int> lstQuestionIndex = new List<int>();

        byte NumOfQuestions;
        int width = 455;
        int Row = 1;

        public frmQuestionCreator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tabQuestions.TabPages.Clear();
            lstTextboxes.Clear();
            lstCheckboxes.Clear();
            //Set NumOfQuestions value to the NumericUpDown value
            NumOfQuestions = decimal.ToByte(nudQuestionAmount.Value);
            //Run routine with no PredefinedQuestions
            vGenerateTabs(false);
        }

        private void vGenerateTabs(bool PredefinedQuestions)
        {
            //Generate the question tabs
            for (int i = 0; i < NumOfQuestions; i++)
            {
                //Generate the tab
                string TabTitle = "Question" + (tabQuestions.TabCount + 1).ToString();
                TabPage TabPageQuestion = new TabPage(TabTitle);
                tabQuestions.TabPages.Add(TabPageQuestion);
                TabPageQuestion.HorizontalScroll.Maximum = 0;
                TabPageQuestion.AutoScroll = true;

                //Add a flowLayouPanel to the tab
                TableLayoutPanel tlpQuestions = new TableLayoutPanel();
                TabPageQuestion.Controls.Add(tlpQuestions);
                tlpQuestions.Size = tabQuestions.Size;
                tlpQuestions.ColumnCount = 2;
                tlpQuestions.AutoSize = true;
                tlpQuestions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                tlpQuestions.ContextMenuStrip = cmsFlowLayoutPanel;

                //Add a RichTextBox to the tab
                RichTextBox rtbQuestion = new RichTextBox();
                tlpQuestions.Controls.Add(rtbQuestion, 1, 0);
                rtbQuestion.Width = width;

                //check if there are predefined questions or not
                if (PredefinedQuestions == true)
                {
                    rtbQuestion.Text = lstQnA[lstQuestionIndex[i]];
                    if (!string.IsNullOrWhiteSpace(rtbQuestion.Text) && rtbQuestion.Text[0] == '?')
                        rtbQuestion.Text = rtbQuestion.Text.Substring(2, rtbQuestion.TextLength - 2);
                }
                        
                lstTextboxes.Add(rtbQuestion);
                rtbQuestion.Name += i.ToString();

                //If there are no predefined questions generate X amount of possible answers
                if (PredefinedQuestions == false)    
                    for (int b = 0; b < 4; b++)
                    {
                        vCreateAnswer(i, b, tlpQuestions, String.Empty, false);
                    }
                else
                    for (int b = lstQuestionIndex[i] + 1; b < lstQnA.Count; b++)
                    {
                        //Check if the predefined question contains a +, - or ?, then remove them
                        //and set Checked boolean of vCreateAnswer to true or false depending on the answer
                        if (lstQnA[b][0] != '?')
                            if (lstQnA[b][0] == '+')
                            {
                                lstQnA[b] = lstQnA[b].Substring(2, lstQnA[b].Length - 2);
                                vCreateAnswer(i, b, tlpQuestions, lstQnA[b], true);
                            }
                            else if (lstQnA[b][0] == '-')
                            {
                                lstQnA[b] = lstQnA[b].Substring(2, lstQnA[b].Length - 2);
                                vCreateAnswer(i, b, tlpQuestions, lstQnA[b], false);
                            }
                            else
                                vCreateAnswer(i, b, tlpQuestions, lstQnA[b], false);
                        else
                            break;               
                    }
                Row = 2;
                tlpQuestions.Name += i.ToString();
            }
        }

        private void FlpQuestions_ControlAdded(object sender, ControlEventArgs e)
        {
            //Make the textboxes a single line
            var flp = sender as FlowLayoutPanel;
            if (flp.Controls.Count % 1 == 0)
                flp.SetFlowBreak(e.Control as Control, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           //Opens a dialog with the user, to make sure that the user wants to cancel the operation
           var dialog = MessageBox.Show(this, "Are you sure you want to cancel?", "Attention!", MessageBoxButtons.OKCancel);
           if (dialog == DialogResult.OK)
                this.Close();
        }

        private void vWriteQuestionsToList()
        {
            string Tag1 = null;
            string Tag2 = null;
            string Text = null;

            lstQnA.Clear();
            //Checks tag of Textboxes, if the tag is null its a question, and is added to list
            //If its Diffrent to null, check if its a right or wrong answer, and write it to list accordingly
            //This also checks if there is any text at all, if there is none, it will not be added to the list
            for (int i = 0; i < lstTextboxes.Count; i++)
            {
                if (lstTextboxes[i].Tag != null)
                { 
                    Tag1 = lstTextboxes[i].Tag.ToString();

                    for (int b = 0; b < lstCheckboxes.Count; b++)
                    {
                        Tag2 = lstCheckboxes[b].Tag.ToString();
                        if (Tag1 == Tag2)
                        {
                            if (!string.IsNullOrWhiteSpace(lstTextboxes[i].Text))
                            { 
                                if (lstCheckboxes[b].Checked)
                                   Text = "+ " + lstTextboxes[i].Text;
                                else if (!lstCheckboxes[b].Checked)
                                   Text = "- " + lstTextboxes[i].Text;
                            }
                        }
                    }
                }
                else
                {
                    Text = "? " + lstTextboxes[i].Text;
                }

                if (!string.IsNullOrWhiteSpace(lstTextboxes[i].Text))
                    lstQnA.Add(Text);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vSaveFile();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vOpenFile();
        }

        private void vSaveFile()
        {
            //SaveFileDialog Saves questions and answers to a user specefied location
            vWriteQuestionsToList();
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.Title = "Save Text File - Question";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(sfd.FileName, lstQnA.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void vOpenFile()
        {
            //This Openfiledialog Gets a user specefied .txt file and adds the content to a list
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text files (*.txt)|*.txt";
            ofd.Title = "Open Text File - Question";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tabQuestions.TabPages.Clear();
                    lstTextboxes.Clear();
                    lstQnA.Clear();
                    lstQnA = System.IO.File.ReadAllLines(ofd.FileName).ToList();
                    vGetAmountOfQuestions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            ofd.Dispose();
        }

        private void vGetAmountOfQuestions()
        {
            //Checks first char, and if it's '?' Add its index to list, and add 1 to NumOfQuestions 
            lstQuestionIndex.Clear();
            NumOfQuestions = 0;

            for (int i = 0; i < lstQnA.Count; i++)
            {
                if (lstQnA[i][0] == '?')
                {
                    NumOfQuestions++;
                    lstQuestionIndex.Add(i);
                }
            }

            nudQuestionAmount.Value = NumOfQuestions;
            vGenerateTabs(true);
        }

        private void vCreateAnswer(int i, int b, TableLayoutPanel tlpQuestions, string Text, bool Checked)
        {
            //Create a new textbox and checkbox in defined tab          
            TextBox txtAnswers = new TextBox();
            txtAnswers.ContextMenuStrip = cmsTextboxes;
            txtAnswers.Width = width;
            tlpQuestions.Controls.Add(txtAnswers, 1, Row);
            lstTextboxes.Add(txtAnswers);
            txtAnswers.Text = Text;
            txtAnswers.Tag = "T" + i.ToString() + "Q" + b.ToString();

            CheckBox cbAnswers = new CheckBox();
            tlpQuestions.Controls.Add(cbAnswers, 0, Row);
            lstCheckboxes.Add(cbAnswers);

            if (Checked)
                cbAnswers.Checked = true;
            else if (!Checked)
                cbAnswers.Checked = false;

            cbAnswers.TabStop = false;
            cbAnswers.Tag = "T" + i.ToString() + "Q" + b.ToString();

            cbAnswers.Name += cbAnswers.Tag;
            txtAnswers.Name += txtAnswers.Tag;
            Row++;
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Get the TableLayoutPanel then run create answer routine
            var tlp = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            TabPage Tab = (TabPage)tlp.Parent;
            TabControl TabCtrl = (TabControl)Tab.Parent;

            int i = TabCtrl.TabPages.IndexOf(Tab);
            int b = lstTextboxes.Count + 1;

            Row = lstTextboxes.Count + 1;
            vCreateAnswer(i, b, (TableLayoutPanel)tlp, string.Empty, false);
            Row = 2;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Would've liked to reuse this bit of code, but i dont know how to check if i pressed the flp or txt yet.
            var txtBox = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            TableLayoutPanel tlp = (TableLayoutPanel)txtBox.Parent;
            TabPage Tab = (TabPage)tlp.Parent;
            TabControl TabCtrl = (TabControl)Tab.Parent;

            int i = TabCtrl.TabPages.IndexOf(Tab);
            int b = lstTextboxes.Count + 1;

            Row = lstTextboxes.Count + 1;
            vCreateAnswer(i, b, (TableLayoutPanel)tlp, String.Empty, false);
            Row = 2;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove textbox, get parent and remove the textbox from the list and Flowlayoutpanel
            var txtBox = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            TableLayoutPanel tlp = (TableLayoutPanel)txtBox.Parent;

            tlp.Controls.Remove(txtBox);
            lstTextboxes.Remove(txtBox);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            vSaveFile();
            Close();
        }
    }
}