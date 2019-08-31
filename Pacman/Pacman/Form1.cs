using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
	public partial class Pacman : Form
	{
		int[,] startMap =
		{
			{1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1},
			{1,2,2,2,2,0,0,0,0,0,0,0,0,3,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,1,0,1},
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,0,1},
			{1,0,1,1,0,1,1,0,0,0,0,1,1,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,1},
			{1,0,1,1,0,1,1,0,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1},
			{1,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,1},
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,1},
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,1},
			{1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,0,1},
			{1,1,1,1,0,1,1,0,1,1,0,1,0,0,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,0,1,1,0,1,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,1,1,0,1},
			{1,0,1,1,1,1,1,1,1,1,0,1,0,0,0,1,0,1,1,1,1,1,0,1,1,1,0,1,1,0,1},
			{1,0,1,1,1,1,1,1,1,1,0,1,0,0,0,1,0,1,1,1,1,1,0,1,1,1,0,1,1,0,1},
			{1,0,0,0,0,0,0,0,1,1,0,1,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,1,1,0,1},
			{1,1,1,1,0,1,1,0,1,1,0,1,0,0,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,0,1},
			{1,1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,0,1},
			{1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,1},
			{1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,1},
			{1,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,1},
			{1,0,1,1,0,1,1,0,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1},
			{1,0,1,1,0,1,1,0,0,0,0,1,1,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,1},
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,0,1},
			{1,0,1,1,0,1,1,1,1,1,0,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1}
		};
		int[,] gameMap;
		Direction direction = 0;
		Label scoreCounter;
		Label livesCounter;
		int step = 2;
		PictureBox pctPacman;

		Keys previosDirectionCode;
		int height = 720;
		int width = 560;
		int chunkSize = 20;
		int pacmanPctCenterX;
		int pacmanPctCenterY;
		int score;
		int lives;
		PictureBox[,] pictures;
		public Pacman()
		{
			InitializeComponent();
		}
		enum Direction : int
		{
			Up = 1,
			Right = 2,
			Down = 3,
			Left = 4
		}
		private void Pacman_KeyDown(object sender, KeyEventArgs e)
		{
			if (previosDirectionCode == e.KeyCode)
				return;
			switch (e.KeyCode)
			{
				case Keys.Up:
					pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanUp.png";
					direction = Direction.Up;
					break;
				case Keys.Down:
					pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanDown.png";
					direction = Direction.Down;
					break;
				case Keys.Right:
					pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanRight.png";
					direction = Direction.Right;
					break;
				case Keys.Left:
					pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanLeft.png";
					direction = Direction.Left;
					break;
			}
			previosDirectionCode = e.KeyCode;
		}



		private void pacmanMove_Tick(object sender, EventArgs e)
		{
			pacmanPctCenterX = pctPacman.Location.X + chunkSize / 2;
			pacmanPctCenterY = pctPacman.Location.Y + chunkSize / 2;
			switch ((int)direction)
			{
				case 1:
					if (gameMap[pacmanPctCenterX / chunkSize, (pacmanPctCenterY - step) / chunkSize] == 1)
						break;
					if(pctPacman.Location.Y -step < 0)
						pctPacman.Location = new Point(pctPacman.Location.X, height - step);
					else
						pctPacman.Location = new Point(pctPacman.Location.X, pctPacman.Location.Y - step);
					break;
				case 3:
					if (gameMap[pacmanPctCenterX / chunkSize, (pacmanPctCenterY + step) / chunkSize] == 1)
						break;
					if (pctPacman.Location.Y + step >= Height)
						pctPacman.Location = new Point(pctPacman.Location.X, 0);
					else
						pctPacman.Location = new Point(pctPacman.Location.X, pctPacman.Location.Y + step);
					break;
				case 2:
					if (gameMap[(pacmanPctCenterX + step) / chunkSize, pacmanPctCenterY / chunkSize] == 1)
						break;
					if (pctPacman.Location.X + step >= Width)
						pctPacman.Location = new Point(0, pctPacman.Location.Y);
					else
						pctPacman.Location = new Point(pctPacman.Location.X + step, pctPacman.Location.Y);
					break;
				case 4:
					if (gameMap[(pacmanPctCenterX - step) / chunkSize, pacmanPctCenterY / chunkSize] == 1)
						break;
					if (pctPacman.Location.X - step < 0)
						pctPacman.Location = new Point(width - step, pctPacman.Location.Y);
					else
						pctPacman.Location = new Point(pctPacman.Location.X - step, pctPacman.Location.Y);
					break;
				case 0:
					break;
			}
			if (gameMap[pacmanPctCenterX / chunkSize, pacmanPctCenterY / chunkSize] == 2)
			{
				gameMap[pacmanPctCenterX / chunkSize, pacmanPctCenterY / chunkSize] = 0;
				score += 10;
				scoreCounter.Text = score.ToString();
				pictures[pacmanPctCenterX / chunkSize, pacmanPctCenterY / chunkSize].ImageLocation = null;
			}
			else if (gameMap[pacmanPctCenterX / chunkSize, pacmanPctCenterY / chunkSize] == 3)
			{
				lives -= 1;
				livesCounter.Text = lives.ToString();
				if (lives == 0)
				{
					pacmanMove.Enabled = false;
					MessageBox.Show("you died");
					Controls.Clear();
					lives = 3;
					score = 0;
					direction = 0;
					gameMap = (int[,])startMap.Clone();
					DrawSchene();
					pctPacman.Location = new Point(chunkSize, chunkSize);
					scoreCounter.Text = score.ToString();
					livesCounter.Text = lives.ToString();
					pctPacman = new PictureBox();
					pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanRight.png";
					pctPacman.Location = new Point(chunkSize, chunkSize);
					pctPacman.Size = new Size(chunkSize, chunkSize);
					pctPacman.SizeMode = PictureBoxSizeMode.Zoom;
					pctPacman.Name = "pctPacman";
					Controls.Add(pctPacman);
					pctPacman.BringToFront();
					pacmanMove.Enabled = true;
				}
			}
		}

		public void DrawSchene()
		{
			pictures = new PictureBox[width / chunkSize, height / chunkSize];
			for (int i = 0; i < 28; i++)
			{
				for (int j = 0; j < 31; j++)
				{
					if(i==1&j==1)
						Console.WriteLine();
					switch (gameMap[i, j])
					{
						case 0:
							break;
						case 1:
							PictureBox stone = new PictureBox();
							stone.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\stone2.jpg";
							stone.Size = new Size(chunkSize, chunkSize);
							stone.SizeMode = PictureBoxSizeMode.Zoom;
							stone.Location = new Point(i * chunkSize, j * chunkSize);
							Controls.Add(stone);
							pictures[i, j] = stone;
							break;
						case 2:
							PictureBox scorePicture = new PictureBox();
							scorePicture.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\score2.jpg";
							scorePicture.Size = new Size(chunkSize, chunkSize);
							scorePicture.SizeMode = PictureBoxSizeMode.Zoom;
							scorePicture.Location = new Point(i * chunkSize, j * chunkSize);
							Controls.Add(scorePicture);
							pictures[i, j] = scorePicture;
							break;
						case 3:
							PictureBox redGhost = new PictureBox();
							redGhost.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\redGhost.jpg";
							redGhost.Size = new Size(chunkSize, chunkSize);
							redGhost.SizeMode = PictureBoxSizeMode.Zoom;
							redGhost.Location = new Point(i * chunkSize, j * chunkSize);
							Controls.Add(redGhost);
							pictures[i, j] = redGhost;
							break;

					}
				}
			}
			Console.WriteLine();
		}

		private void start_Click(object sender, EventArgs e)
		{
			gameMap = (int[,])startMap.Clone();
			start.Visible = false;
			DrawSchene();

			pctPacman = new PictureBox();
			pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanRight.png";
			pctPacman.Location = new Point(chunkSize,chunkSize);
			pctPacman.Size = new Size(chunkSize, chunkSize);
			pctPacman.SizeMode = PictureBoxSizeMode.Zoom;
			pctPacman.Name = "pctPacman";
			Controls.Add(pctPacman);
			pctPacman.BringToFront();

			scoreCounter = new Label();
			scoreCounter.Text = "Scores\n" + score.ToString();
			scoreCounter.Location = new Point(width + 100, 50);
			scoreCounter.Size = new Size(100, 60);
			scoreCounter.Name = "scoreCounter";
			scoreCounter.BackColor = Color.White;
			scoreCounter.TextAlign = ContentAlignment.MiddleCenter;
			scoreCounter.Font = new Font("Times New Roman", 20f);
			Controls.Add(scoreCounter);

			lives = 3;
			livesCounter = new Label();
			livesCounter.Text = "Lives\n" + lives.ToString();
			livesCounter.Location = new Point(width + 100, 130);
			livesCounter.Size = new Size(100, 60);
			livesCounter.Name = "livesCounter";
			livesCounter.BackColor = Color.White;
			livesCounter.TextAlign = ContentAlignment.MiddleCenter;
			livesCounter.Font = new Font("Times New Roman", 20f);
			Controls.Add(livesCounter);

			pacmanMove.Enabled = true;
			this.Focus();
		}
	}
}
