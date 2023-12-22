using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eye_Helper
{
    public partial class EyeHelper : Form
    {
        public EyeHelper()
        {
            InitializeComponent();
        }

        int timeLeftSeconds = 0;
        int timeLeftMinutes = 20;
        int restSeconds = 21;
        bool isResting = false;

        private void SecondsTimer_Tick(object sender, EventArgs e)
        {
            // Decrement seconds
            if(timeLeftSeconds > 0 && timeLeftMinutes > 0)
            {
                timeLeftSeconds--;
                TimerLabel.Text = timeLeftMinutes + " Minutes " + timeLeftSeconds + " Seconds";
            }
            // Decrement minutes
            else if(timeLeftMinutes > 0 && timeLeftSeconds == 0)
            {
                timeLeftMinutes--;
                timeLeftSeconds = 60;
                TimerLabel.Text = timeLeftMinutes + " Minutes " + timeLeftSeconds + " Seconds";  
            }
            // Remove minutes from the TimerLabel when equal to 0.
            else if (timeLeftMinutes == 0 && timeLeftSeconds > 0)
            {
                timeLeftSeconds--;
                TimerLabel.Text = timeLeftSeconds + " Seconds";
            }
            // Stop the timer
            else
            {
  
                SecondsTimer.Stop();
                isResting = true;
                TimerLabel.Text = "Time to rest! Click Start and focus your eyes on something over 20 meters away";
            }
        }

        private void RestTimer_Tick(object sender, EventArgs e)
        {
            if(restSeconds > 0)
            {
                restSeconds--;
                TimerLabel.Text = "Rest for " + restSeconds + " Seconds";
            }
            else
            {
                TimerLabel.Text = "Rest Completed";
                RestTimer.Stop();
                ResetValues();
            }   
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(isResting==false)
            {
                SecondsTimer.Start();
            }
            else if(isResting==true)
            {
                RestTimer.Start();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (isResting == false)
            {
                SecondsTimer.Stop();
            }
            else if (isResting == true)
            {
                RestTimer.Stop();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            SecondsTimer.Stop();
            RestTimer.Stop();
            timeLeftSeconds = 0;
            timeLeftMinutes = 20;
            TimerLabel.Text = timeLeftMinutes + " Minutes " + timeLeftSeconds + " Seconds";
        }

        private void ResetValues()
        {
            timeLeftSeconds = 0;
            timeLeftMinutes = 20;
            restSeconds = 21;
            isResting = false;
        }
       
    }


}
