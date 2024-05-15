using System;
using System.Windows.Forms;

namespace FlapyBird
{
    public partial class HighScoresForm : Form
    {
        public HighScoresForm()
        {
            InitializeComponent();
        }

        public void LoadHighScores(string[] highScores)
        {
            foreach (string score in highScores)
            {
                listBoxHighScores.Items.Add(score);
            }
        }
    }
}
