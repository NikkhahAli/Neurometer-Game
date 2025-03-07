using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargahPage166
{
    public partial class Form1 : Form
    {
        bool isActiveGame = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        int seconds = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (label9.Text == "label9")
            {
                MessageBox.Show("قبل از شروع بازی باید یک اسم انتخاب کنید");
            }
            else
            {
                isActiveGame = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = textBox1.Text;
            textBox1.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActiveGame)
            {
                seconds++;
                label8.Text = seconds.ToString();
                timer1.Start();
            }
        }

        bool showMessage = false;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isActiveGame)
            {
                for (int i = 1; i <= 7; i++)
                {
                    if (Controls["label" + i].Location != e.Location)
                    {
                        isActiveGame = false;
                        if (isActiveGame == false)
                        {
                            timer1.Stop();
                            MessageBox.Show("شما باختید");
                            isActiveGame = false;
                            label10.Text = "" + seconds;
                            break;
                        }
                    }
                   
                }
            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            for (int k = 0; k < 1; k++)
            {
                isActiveGame = false;
                if (isActiveGame == false)
                {
                    timer1.Stop();
                    label10.Text = "" + seconds;
                    MessageBox.Show("شما بردید", "" + k);
                    break;
                }
            }
        }
    }
}
