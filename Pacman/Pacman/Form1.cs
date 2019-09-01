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
		List<Ghost> ghosts = new List<Ghost>();
		int[,] gameMap;
		Random random = new Random();
		PacmanClass pacman;
		GhostsMoving ghostsMoving;
		Ghost redGhost;
		Ghost yellowGhost;
		Ghost pinkGhost;
		public int[,] GameMap { get { return gameMap; }}
		Button retry;
		Label scoreCounter;
		Label livesCounter;
		Label levelCounter;
		System.Windows.Forms.Timer ghostMoveTypeTimer;
		int ballsCount;
		int score;
		int lives = 3;
		int level = 1;
		PictureBox[,] pictures;
		Label endLabel;

		public Game()
		{
			InitializeComponent();
			pacman = new PacmanClass();
			ghostsMoving = new GhostsMoving(this, pacman);
			ghostMoveTypeTimer = new System.Windows.Forms.Timer();
			ghostMoveTypeTimer.Interval = 10000;
			ghostMoveTypeTimer.Tick += new EventHandler(ghostMoveTypeTimer_Tick);
			redGhost = new Ghost();
			yellowGhost = new Ghost();
			pinkGhost = new Ghost();
		}

		private void Pacman_KeyDown(object sender, KeyEventArgs e)
		{
			pacman.PacmanDirection(e);
		}

		private void pacmanMove_Tick(object sender, EventArgs e)
		{
			pacman.PacmanMove(gameMap);
			AddScores();
			if (ballsCount == 0)
			{
				pacmanMove.Enabled = false;
				redGhostMove.Enabled = false;
				yellowGhostMove.Enabled = false;
				pinkGhostMove.Enabled = false;
				NextLevel();
			}
			TakeOffLive();
		}
		void AddScores()
		{
			if (gameMap[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize] == 2)
			{
				gameMap[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize] = 0;
				score += 10;
				ballsCount--;
				scoreCounter.Text = "Scores\n" + score.ToString();
				pictures[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize].Image = null;
			}
			if (gameMap[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize] == 4)
			{
				gameMap[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize] = 0;
				score += random.Next(100, 500);
				ballsCount--;
				scoreCounter.Text = "Scores\n" + score.ToString();
				pictures[pacman.PacmanPctCenterX / chunkSize, pacman.PacmanPctCenterY / chunkSize].Image = null;
				ghostsMoving.ghostMoveType = 2;
				foreach (var ghost in ghosts)
				{
					ghost.pctGhost.Image = Properties.Resources.scaredGhost;
				}
				ghostMoveTypeTimer.Enabled = true;
			}
		}
		void ghostMoveTypeTimer_Tick(object sender, EventArgs e)
		{
			ghostsMoving.ghostMoveType = 1;
			foreach (var ghost in ghosts)
			{
				ghost.pctGhost.Image = Properties.Resources.redGhost;
			}
			ghostMoveTypeTimer.Enabled = false;
		}
		void NextLevel()
		{
			Button nextLvl;
			Label congratulations;
			congratulations = AddLabel("Good Job", width/2,height/2);
			nextLvl = AddButton("Next lvl");
			Controls.Add(nextLvl);
			nextLvl.BringToFront();
			congratulations.BringToFront();
			nextLvl.Click += new EventHandler(nextLvl_Click);
		}
		void nextLvl_Click(object snder, EventArgs e)
		{
			level++;
			Controls.Clear();
			DrawSchene();
			pacman.direction = 0;
			pacman.previosDirectionCode = 0;
			pacmanMove.Enabled = true;
			redGhostMove.Enabled = true;
			yellowGhostMove.Enabled = true;
			pinkGhostMove.Enabled = true;
		}
		void TakeOffLive()
		{
			foreach(var ghost in ghosts)
			{
				if ((pacman.PacmanPctCenterX / chunkSize) == (ghost.GhostCenterX / chunkSize) && (pacman.PacmanPctCenterY / chunkSize) == (ghost.GhostCenterY / chunkSize))
				{
					if (ghost.PacmanUndead > 0) { }
					else
					{
						lives -= 1;
						livesCounter.Text = "Lives\n" + lives.ToString();
						if (lives == 0)
						{
							pacmanMove.Enabled = false;
							redGhostMove.Enabled = false;
							yellowGhostMove.Enabled = false;
							pinkGhostMove.Enabled = false;
							endLabel = AddLabel("You died", width / 2, height / 2);
							retry = AddButton("Retry");
							Controls.Add(retry);
							retry.BringToFront();
							endLabel.BringToFront();
							retry.Click += new EventHandler(retry_Click);
						}
						ghost.PacmanUndead = 30;
					}
				}
				if (ghost.PacmanUndead > 0)
					ghost.PacmanUndead--;
			}
		}
		Button AddButton(string text)
		{
			Button button = new Button();
			button.Location = new Point(width / 2, height / 2 + 100);
			button.Size = new Size(140, 80);
			button.Text = text;
			button.BackColor = Color.White;
			button.TextAlign = ContentAlignment.MiddleCenter;
			button.Font = new Font("Times New Roman", 20f);
			return button;
		}
		private void retry_Click(object sender, EventArgs e)
		{
			Controls.Clear();
			level = 1;
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

			levelCounter = AddLabel("Level\n" + level.ToString(), width + 100, 250);

			pictures = new PictureBox[width / chunkSize, height / chunkSize];
			for (int i = 0; i < 28; i++)
			{
				for (int j = 0; j < 31; j++)
				{
					switch (gameMap[i, j])
					{
						case 0:
							if (ballsCount == 3)
								break;
							if (random.Next(0, 10) > 5)
							{
								ballsCount++;
								gameMap[i, j] = 2;
								pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
								pictures[i, j].Image = Properties.Resources.score2;
							}
							break;
						case 1:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							pictures[i, j].Image = Properties.Resources.stone2;
							break;
						case 3:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							redGhost.pctGhost = pictures[i, j];
							redGhost.pctGhost.Image = Properties.Resources.redGhost;
							redGhost.Name = "Red";
							redGhost.pctGhost.BringToFront();
							ghosts.Add(redGhost);
							break;
						case 4:
							ballsCount++;
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							pictures[i, j].Image = Properties.Resources.treasure;
							break;
						case 5:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							yellowGhost.pctGhost = pictures[i, j];
							yellowGhost.pctGhost.Image = Properties.Resources.redGhost;
							yellowGhost.Name = "Yellow";
							yellowGhost.pctGhost.BringToFront();
							ghosts.Add(yellowGhost);
							break;
						case 6:
							pictures[i, j] = AddPictureBox(i * chunkSize, j * chunkSize);
							pinkGhost.pctGhost = pictures[i, j];
							pinkGhost.pctGhost.Image = Properties.Resources.redGhost;
							pinkGhost.Name = "Pink";
							pinkGhost.pctGhost.BringToFront();
							ghosts.Add(pinkGhost);
							break;
					}
				}
			}
			this.Focus();
			pacmanMove.Enabled = true;
			redGhostMove.Enabled = true;
			yellowGhostMove.Enabled = true;
			pinkGhostMove.Enabled = true;
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
			ghostsMoving.GhostsMove(redGhost);
		}

		private void yellowGhostMove_Tick(object sender, EventArgs e)
		{
			ghostsMoving.GhostsMove(yellowGhost);
		}

		private void pinkGhostMove_Tick(object sender, EventArgs e)
		{
			ghostsMoving.GhostsMove(pinkGhost);
		}
	}
}
