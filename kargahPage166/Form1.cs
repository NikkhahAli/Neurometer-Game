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
        public void resetGame()
        {
            isActiveGame = false;
            seconds = 0;
            label8.Text = "" + seconds;
        }
        private void Form1_Load(object sender, EventArgs e) { }

        int seconds = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < comboBox1.Items.Count; k++)
            {
                if (comboBox1.Items[k].ToString() == "")
                {
                    MessageBox.Show("You have to enter something ");
                }
                else
                {
                    isActiveGame = true;

                    if (isActiveGame == true)
                    {
                        timer1.Start();
                    }
                    else
                    {
                        timer1.Stop();
                    }
                }
            }
        }

        bool check = true;
        public void checkName()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("you have to enter a name");
            }
            else
            {
                if (check)
                {
                    comboBox1.Items.Add(textBox1.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < comboBox1.Items.Count; k++)
            {
                if (comboBox1.Items[k].ToString() == textBox1.Text)
                {
                    MessageBox.Show("You have to enter a new name");
                    check = false;
                }
                else
                {
                    check = true;
                }
            }

            this.checkName();
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

                            DialogResult results = MessageBox.Show("warning", "You have lost Do you want to play again ?", MessageBoxButtons.OKCancel);

                            if (results == DialogResult.OK)
                            {
                                this.resetGame();
                            }
                            break;
                        }
                    }
                }
            }
        }

        int max;
        int counter = 0;
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            for (int k = 0; k < 1; k++)
            {
                isActiveGame = false;
                if (isActiveGame == false)
                {
                    timer1.Stop();

                    if (counter == 0)
                    {
                        max = seconds;
                        counter++;
                    }
                    else if (counter >= 1)
                    {
                        if (max > seconds)
                        {
                            max = seconds;
                        }
                    }

                    comboBox2.Items.Add(seconds);

                    MessageBox.Show("شما بردید");

                    DialogResult result = MessageBox.Show("warning", "You have lost Do you want to play again ?", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.resetGame();
                    }
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < comboBox2.Items.Count; k++)
            {
                int index = comboBox2.Items.IndexOf(max);

                if (k == index)
                {
                    MessageBox.Show("Won the game" + comboBox1.Items[k]);
                }
                
            }
        }
    }
}
