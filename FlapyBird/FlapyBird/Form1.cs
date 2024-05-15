using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FlapyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;
        int checkpoint = 0;

        Boolean gameOver = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void ground_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreLabel.Text ="Score: " + score.ToString();


            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 500;
                score++;
            }
            if (pipeTop.Left < -160)
            {
                pipeTop.Left = 750;
                score++;
            }
            if(flappyBird.Top < -25)
            {
                endGame();
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if(score > checkpoint + 5)
            {
                checkpoint += 10;
                pipeSpeed += 5;
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
            if(e.KeyCode == Keys.R && gameOver == true)
            {
                restartGame();
            }
        }

        private void restartGame()
        {
            gameOver = false;
            flappyBird.Location = new Point(89, 206);
            pipeTop.Left = 800;
            pipeBottom.Left = 1200;

            score = 0;
            checkpoint = 0;
            pipeSpeed = 8;
            scoreLabel.Text = "Score: 0";
            gameTimer.Start();
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreLabel.Text += " Game Over! Press R to restart! ";
            string playerName = GetNameFromInput();
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                SaveScore(playerName, score);
            }
            ShowHighScores();
            gameOver = true;
        }

        private string GetNameFromInput()
        {
            string name = "";
            Form inputForm = new Form();
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.Width = 350;
            inputForm.Height = 150;
            inputForm.Text = "Enter your name";

            Label nameLabel = new Label();
            nameLabel.Text = "Name:";
            nameLabel.SetBounds(10, 20, 80, 20);

            TextBox nameTextBox = new TextBox();
            nameTextBox.SetBounds(100, 20, 120, 20);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;
            okButton.SetBounds(10, 50, 80, 30);

            inputForm.Controls.AddRange(new Control[] { nameLabel, nameTextBox, okButton });

            inputForm.AcceptButton = okButton;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                name = nameTextBox.Text;
            }

            return name;
        }

        private void ShowHighScores()
        {
            HighScoresForm highScoresForm = new HighScoresForm();
            string[] highScores = GetHighScores();
            highScoresForm.LoadHighScores(highScores);
            highScoresForm.ShowDialog();
        }

        private string[] GetHighScores()
        {
            List<string> highScores = new List<string>();
            string filePath = "scores.txt";
            if (System.IO.File.Exists(filePath))
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                Array.Sort(lines, (a, b) => int.Parse(b.Split(',')[1]).CompareTo(int.Parse(a.Split(',')[1])));
                foreach (string line in lines.Take(10))
                {
                    highScores.Add(line.Replace(",", " - Score: "));
                }
            }
            return highScores.ToArray();
        }


        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void SaveScore(string playerName, int playerScore)
        {
            string filePath = "scores.txt";

            List<string> scores = new List<string>();
            if (System.IO.File.Exists(filePath))
            {
                scores = System.IO.File.ReadAllLines(filePath).ToList();
            }

            scores.Add(playerName + "," + playerScore);

            scores = scores.OrderByDescending(s => int.Parse(s.Split(',')[1])).ToList();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                foreach (string score in scores)
                {
                    file.WriteLine(score);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowHighScores();
        }
    }


}
