using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Form1 : Form
    {

        ulong tick;
        ulong StartTick;

        byte year;
        byte month;
        byte day;
        byte hour;
        byte minute;
        byte second;
        ushort dayy;

        long pEpoch;
        long epoch;

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
            FieldDayofmonth.Value = day;
            FieldMonth.Value = month;
            FieldYear.Value = year;
            FieldDayofyear.Value = dayy;
            FieldHour.Value = hour;
            FieldMinute.Value = minute;
            FieldSecond.Value = second;
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            /*if(running)
            {
                time.Text = DateTime.Now.ToString();
            }*/
            if (running)
            {
                tickout.Text = $"Tick: {tick}";
                EpochDiffOut.Text = $"Epoch difference: {epoch - pEpoch}";

                // Spaghetti bullshit that prints stuffs to the console. i want to kms btw
                date.Text = $"{ForceDd(day + 1)}/{ForceDd(month + 1)}/{ForceDd(year)}";
                time.Text = $"{ForceDd(hour)}:{ForceDd(minute)}:{ForceDd(second)}";
                //time.Text = $"{tick}";

                // If we have an abnormal epoch change, write it to the part of the console that isnt being rewritten, and offset our line for doing this by 1 for the next time.
                if (!(epoch - pEpoch == 1) && !ErrorShowing && (tick - StartTick > 1))
                {
                    ErrorShowing = true;
                    running = false;
                    start.Text = "Start";
                    MessageBox.Show($"Abnormal epoch difference!\nDifference: {epoch - pEpoch}",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    ErrorShowing = false;
                }

                if(tick - StartTick < 1)
                {
                    IgnoreOut.Text = "== Ignoring Epoch Difference ==";
                }
                else
                {
                    IgnoreOut.Text = "";
                }

                // Our program speed. Comment out this line to time travel with the speed of 10 billion sonics.
                Count();
                ++tick;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            StartTick = tick;
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

        public void Count()
        {
            ++second;

            if (second >= 60)
            {
                second = 0;
                ++minute;
            }

            if (minute >= 60)
            {
                minute = 0;
                ++hour;
            }

            if (hour >= 24)
            {
                hour = 0;
                ++day;
                ++dayy;
            }

            if (dayy > 364)
            {
                dayy = 0;
            }

            switch (month)
            {
                // February
                case 1:
                    if (day > 27)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // April
                case 3:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // June
                case 5:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // September
                case 8:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // November
                case 10:
                    if (day > 29)
                    {
                        day = 0;
                        ++month;
                    }
                    break;

                // January, March, May July, August, October, December
                default:
                    if (day > 30)
                    {
                        day = 0;
                        ++month;
                    }
                    break;
            }

            if (month >= 12)
            {
                month = 0;
                ++year;
            }

            if (year > 99)
            {
                year = 0;
            }

            pEpoch = (long)epoch;

            epoch = ((long)year * 31536000);
            epoch +=
                ((long)dayy * 86400) +
                (hour * 3600) +
                (minute * 60) +
                second;
        }

        public static string ForceDd(int num)
        {
            if (num >= 10)
            {
                return (Convert.ToString(num));
            }
            else
            {
                return ($"0{Convert.ToString(num)}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!running)
            {
                day = (byte)FieldDayofmonth.Value;
                //--day;
                month = (byte)FieldMonth.Value;
                //--month;
                year = (byte)FieldYear.Value;
                dayy = (ushort)FieldDayofyear.Value;
                //--dayy;
                hour = (byte)FieldHour.Value;
                minute = (byte)FieldMinute.Value;
                second = (byte)FieldSecond.Value;

                epoch = ((long)year * 31536000);
                epoch +=
                    ((long)dayy * 86400) +
                    (hour * 3600) +
                    (minute * 60) +
                    second;

                pEpoch = epoch;
                
                date.Text = $"{ForceDd(day + 1)}/{ForceDd(month + 1)}/{ForceDd(year)}";
                time.Text = $"{ForceDd(hour)}:{ForceDd(minute)}:{ForceDd(second)}";
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
                FieldDayofmonth.Value = day;
                FieldMonth.Value = month;
                FieldYear.Value = year;
                FieldDayofyear.Value = dayy;
                FieldHour.Value = hour;
                FieldMinute.Value = minute;
                FieldSecond.Value = second;
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
                day = 0;
                month = 0;
                year = 0;
                dayy = 0;
                hour = 0;
                minute = 0;
                second = 0;

                FieldDayofmonth.Value = day;
                FieldMonth.Value = month;
                FieldYear.Value = year;
                FieldDayofyear.Value = dayy;
                FieldHour.Value = hour;
                FieldMinute.Value = minute;
                FieldSecond.Value = second;

                epoch = ((long)year * 31536000);
                epoch +=
                    ((long)dayy * 86400) +
                    (hour * 3600) +
                    (minute * 60) +
                    second;

                pEpoch = epoch;

                date.Text = $"{ForceDd(day + 1)}/{ForceDd(month + 1)}/{ForceDd(year)}";
                time.Text = $"{ForceDd(hour)}:{ForceDd(minute)}:{ForceDd(second)}";

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
                year = 99;
                month = 11;
                day = 30;
                hour = 23;
                minute = 59;
                second = 50;
                dayy = 364;

                FieldDayofmonth.Value = day;
                FieldMonth.Value = month;
                FieldYear.Value = year;
                FieldDayofyear.Value = dayy;
                FieldHour.Value = hour;
                FieldMinute.Value = minute;
                FieldSecond.Value = second;

                epoch = ((long)year * 31536000);
                epoch +=
                    ((long)dayy * 86400) +
                    (hour * 3600) +
                    (minute * 60) +
                    second;

                pEpoch = epoch;

                date.Text = $"{ForceDd(day + 1)}/{ForceDd(month + 1)}/{ForceDd(year)}";
                time.Text = $"{ForceDd(hour)}:{ForceDd(minute)}:{ForceDd(second)}";

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
