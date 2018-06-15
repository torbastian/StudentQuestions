using System;
using System.Windows.Forms;

namespace StudentQuestions
{
    public partial class frmTimerInterval : Form
    {
        //Create public variable
        public int intTimerInterval { get; set; }

        public frmTimerInterval()
        {
            InitializeComponent();
        }

        private void TimerInterval_Load(object sender, EventArgs e)
        {
            //Set the Numeric Up down to the Current Timer interval, and write the interval to a label
            nudInterval.Value = intTimerInterval;
            lblCurrentInterval.Text = string.Format("Current Interval: {0}", intTimerInterval);
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            //When the Numeric up down has changed, also change the intTimerInterval
            intTimerInterval = decimal.ToInt32(nudInterval.Value);
        }
    }
}