using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdds
{
    public partial class FlappyBird : Form
    {
        // === Variables ===
        int gravity = 2;       // gravity force pulling the bird down
        int birdSpeedY = 0;    // bird's vertical speed
        int score = 0;         // game score

        public FlappyBird()
        {
            InitializeComponent();
        }

        // === Timer Event ===
        private void timer1_Tick(object sender, EventArgs e)
        {
            // bird movement
            bird.Top += birdSpeedY;
            birdSpeedY += gravity;

            // move pipes
            pipeTop.Left -= 5;
            pipeBottom.Left -= 5;

            // reset pipes if off-screen
            if (pipeTop.Left < -100)
            {
                pipeTop.Left = 400;
                score++;  // increment score when passing pipes
                scoreText.Text = "Score: " + score;
            }
            if (pipeBottom.Left < -100)
            {
                pipeBottom.Left = 400;
            }

            // collision check
            if (bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
        }

        // === Space key makes the bird jump ===
        private void FlappyBird_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                birdSpeedY = -15; // jump upwards
            }
        }

        // === End Game Method ===
        private void endGame()
        {
            timer1.Stop();
            MessageBox.Show("Game Over!\nYour Score: " + score);
        }
    }
}

