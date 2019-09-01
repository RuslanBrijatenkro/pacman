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
			ghostMoveTypeTimer = new System.Windows.Forms.Timer
			{
				Interval = 10000
			};
			ghostMoveTypeTimer.Tick += new EventHandler(GhostMoveTypeTimer_Tick);
			redGhost = new Ghost();
			yellowGhost = new Ghost();
			pinkGhost = new Ghost();
		}

		private void Pacman_KeyDown(object sender, KeyEventArgs e)
		{
			pacman.PacmanDirection(e);
		}

		private void PacmanMove_Tick(object sender, EventArgs e)
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
		void GhostMoveTypeTimer_Tick(object sender, EventArgs e)
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
			nextLvl.Click += new EventHandler(NextLvl_Click);
		}
		void NextLvl_Click(object snder, EventArgs e)
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
							retry.Click += new EventHandler(Retry_Click);
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
			Button button = new Button
			{
				Location = new Point(width / 2, height / 2 + 100),
				Size = new Size(140, 80),
				Text = text,
				BackColor = Color.White,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Times New Roman", 20f)
			};
			return button;
		}
		private void Retry_Click(object sender, EventArgs e)
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

		private void Start_Click(object sender, EventArgs e)
		{
			start.Visible = false;
			DrawSchene();
		}
		PictureBox AddPictureBox(int locationX, int locationY)
		{
			PictureBox pictureBox = new PictureBox
			{
				Location = new Point(locationX, locationY),
				Size = new Size(chunkSize, chunkSize),
				SizeMode = PictureBoxSizeMode.Zoom
			};
			Controls.Add(pictureBox);
			return pictureBox;
		}
		Label AddLabel(string text, int locationX, int locationY)
		{
			Label label = new Label
			{
				Text = text,
				Location = new Point(locationX, locationY),
				Size = new Size(140, 80),
				BackColor = Color.White,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Times New Roman", 20f)
			};
			Controls.Add(label);
			return label;
		}

		private void RedGhostMove_Tick(object sender, EventArgs e)
		{
			ghostsMoving.GhostsMove(redGhost);
		}

		private void YellowGhostMove_Tick(object sender, EventArgs e)
		{
			ghostsMoving.GhostsMove(yellowGhost);
		}

		private void PinkGhostMove_Tick(object sender, EventArgs e)
		{
			ghostsMoving.GhostsMove(pinkGhost);
		}
	}
}
