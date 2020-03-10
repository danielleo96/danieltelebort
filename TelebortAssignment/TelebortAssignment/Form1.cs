using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Reflection;

namespace TelebortAssignment
{
    public partial class Form1 : Form
    {
        int start = 0;
        int end = 1;
        int score = 0;
        
        public Form1()
        {
            InitializeComponent();
            WordLabel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Points.Text = "0";
            TimerLabel.Text = "20"; //start from 20 seconds
            timer1.Start();
            playGame();
            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerLabel.Text = (int.Parse(TimerLabel.Text) - 1).ToString();
            if (int.Parse(TimerLabel.Text) == 0)  //if the countdown reaches '0', we stop it
            {
                timer1.Stop();
                
                button1.Visible = true;
                WordLabel.Text = "Game Over";
                WordLabel.ForeColor = Color.Red;
            }
        }


        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            string s = WordLabel.Text;
            char[] charArray = s.ToCharArray();
            
                foreach (var letter in charArray)
                {
                    
                    if (e.KeyCode.ToString().ToUpper() == charArray[start].ToString())
                    {

                        WordLabel.Select(0, end);
                        WordLabel.SelectionBackColor = Color.Blue;
                        if (start < charArray.Length - 1)
                        {
                            start++; // duplicate letters
                            end++;
                        break;  
                        }
                        else
                        {
                            score++;
                            Points.Text = score.ToString();
                            playGame();
                        }

                    }
               
                }
            
        }
        private void playGame()
        {
            string file_name = @"WordsFolder\words.txt";
            string[] files = File.ReadAllLines(file_name);

            int index = new Random().Next(0, files.Length);
            var name = files[index];
            IList<string> stringList = files.ToList();

            stringList.RemoveAt(index);
            string s = files[index].ToUpper();

            button1.Visible = false;
            WordLabel.Visible = true;
            WordLabel.Text = s;
            WordLabel.ForeColor = Color.Black;
            start = 0;
            end = 1;
        }

    }
}
