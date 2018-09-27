using System;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        DateTime Date = new DateTime(1, 1, 1, 0, 0, 0);

        ulong Tick;
        ulong StartTick;

        bool running;
        bool ErrorShowing;

        public Form1()
        {
            InitializeComponent();

            var Timer1 = new Timer();

            // Call this procedure when the application starts.  
            // Set to 1 second.  
            Timer1.Interval = 1000;
            Timer1.Tick += new EventHandler(Timer1_Tick);

            // Enable timer.  
            Timer1.Enabled = true;

            // Set defaults
            
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            if(running)
            {
                Date = Date.AddSeconds(1);
                DisplayDates();
                ++Tick;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            StartTick = Tick;
            if(!running)
            {
                running = true;
                start.Text = "Stop";
            }
            else
            {
                running = false;
                start.Text = "Start";
            }
        }

        public void DisplayDates()
        {
            date.Text = $"{Date.Day}/{Date.Month}/{Date.Year}";
            time.Text = $"{Date.Hour}:{Date.Minute}:{Date.Second}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!running)
            {
                Date = new DateTime((int)FieldYear.Value,
                    (int)FieldMonth.Value,
                    (int)FieldDayofmonth.Value,
                    (int)FieldHour.Value,
                    (int)FieldMinute.Value,
                    (int)FieldSecond.Value);
                DisplayDates();
            }
            else
            {
                MessageBox.Show("Please press the stop button before changing values!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                FieldYear.Value = Date.Year;
                FieldMonth.Value = Date.Month;
                FieldDayofmonth.Value = Date.Day;
                FieldHour.Value = Date.Hour;
                FieldMinute.Value = Date.Minute;
                FieldSecond.Value = Date.Second;
            }
            else
            {
                MessageBox.Show("Please press the stop button before changing values!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutWindow = new AboutBox1();
            aboutWindow.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                Date = new DateTime(1, 1, 1, 0, 0, 0);
                DisplayDates();

                MessageBox.Show($"Loaded preset.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please press the stop button before changing values!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void t10sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                Date = new DateTime(1999, 12, 31, 12, 59, 50);
                DisplayDates();

                MessageBox.Show($"Loaded preset.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please press the stop button before changing values!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void problemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                Date = new DateTime(2038, 1, 19, 03, 10, 0);
                DisplayDates();

                MessageBox.Show($"Loaded preset.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please press the stop button before changing values!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
