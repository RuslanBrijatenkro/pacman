using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pacman.Map;

namespace Pacman
{
	public partial class Game : Form
	{ 
		int[,] gameMap;
		PacmanClass pacman;
		RedGhost redGhost;
		public int[,] GameMap { get { return gameMap; }}

		Label scoreCounter;
		Label livesCounter;


		int undead;
		int score;
		int lives = 3;

		PictureBox[,] pictures;
		Label endLabel;

		public Game()
		{
			InitializeComponent();
			pacman = new PacmanClass();
			redGhost = new RedGhost(this, pacman);
		}

		private void Pacman_KeyDown(object sender, KeyEventArgs e)
		{
			pacman.PacmanDirection(e);
		}

		private void pacmanMove_Tick(object sender, EventArgs e)
		{
			pacman.PacmanMove(gameMap);
			AddScores();
			TakeOffLive();
		}
		void AddScores()
		{
			if (gameMap[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize] == 2)
			{
				gameMap[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize] = 0;
				score += 10;
				scoreCounter.Text = "Scores\n" + score.ToString();
				pictures[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize].Image = null;
			}
		}
		void TakeOffLive()
		{
			if ((pacman.PacmanPctCenterX / chunkSize) == (redGhost.redGhostCenterX / chunkSize) && (pacman.PacmanPctCenterY / chunkSize) == (redGhost.redGhostCenterY / chunkSize))
			{
				if (undead > 0) { }
				else
				{
					lives -= 1;
					livesCounter.Text = "Lives\n" + lives.ToString();
					if (lives == 0)
					{
						pacmanMove.Enabled = false;
						redGhostMove.Enabled = false;
						endLabel = AddLabel("You died", width / 2, height / 2);
						Button retry = new Button();
						retry.Location = new Point(width / 2, height / 2 + 100);
						retry.Size = new Size(140, 80);
						retry.Text = "Retry";
						retry.BackColor = Color.White;
						retry.TextAlign = ContentAlignment.MiddleCenter;
						retry.Font = new Font("Times New Roman", 20f);
						Controls.Add(retry);
						retry.BringToFront();
						endLabel.BringToFront();
						retry.Click += new EventHandler(retry_Click);
					}
					undead = 30;
				}
			}
			if (undead > 0)
				undead--;
		}
		private void retry_Click(object sender, EventArgs e)
		{
			Controls.Clear();
			lives = 3;
			score = 0;
			DrawSchene();
			pacman.direction = 0;
			pacman.previosDirectionCode = 0;
		}

		public void DrawSchene()
		{
			gameMap = (int[,])Map.startMap.Clone();
			pacman.pctPacman = AddPictureBox(chunkSize, chunkSize);
			pacman.pctPacman.Image = Properties.Resources.pacmanRight;
			pacman.pctPacman.BringToFront();

			scoreCounter = AddLabel("Scores\n" + score.ToString(), width + 100, 50);

			livesCounter = AddLabel("Lives\n" + lives.ToString(), width + 100, 150);

			pictures = new PictureBox[width / chunkSize, height / chunkSize];
			for (int i = 0; i < 28; i++)
			{
				for (int j = 0; j < 31; j++)
				{
					switch (gameMap[i, j])
					{
						case 0:
							break;
						case 1:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							pictures[i, j].Image = Properties.Resources.stone2;
							break;
						case 2:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							pictures[i, j].Image = Properties.Resources.score2;
							break;
						case 3:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							redGhost.redGhost = pictures[i, j];
							redGhost.redGhost.Image = Properties.Resources.redGhost;
							redGhost.redGhost.BringToFront();
							break;

					}
				}
			}
			this.Focus();
			pacmanMove.Enabled = true;
			redGhostMove.Enabled = true;
		}

		private void start_Click(object sender, EventArgs e)
		{
			start.Visible = false;
			DrawSchene();
		}
		PictureBox AddPictureBox(int locationX, int locationY)
		{
			PictureBox pictureBox = new PictureBox();
			pictureBox.Location = new Point(locationX, locationY);
			pictureBox.Size = new Size(chunkSize, chunkSize);
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			Controls.Add(pictureBox);
			return pictureBox;
		}
		Label AddLabel(string text, int locationX, int locationY)
		{
			Label label = new Label();
			label.Text = text;
			label.Location = new Point(locationX, locationY);
			label.Size = new Size(140, 80);
			label.BackColor = Color.White;
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.Font = new Font("Times New Roman", 20f);
			Controls.Add(label);
			return label;
		}

		private void redGhostMove_Tick(object sender, EventArgs e)
		{
			redGhost.RedGhostMove();
		}

		
	}
}
