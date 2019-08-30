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
		int[,] map =
		{
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1}
		};

		Direction direction = 0;
		int step = 2;
		PictureBox pctPacman;
		Keys previosCode;
		public Pacman()
		{
			InitializeComponent();
			//DrawSchene();
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
			if (previosCode == e.KeyCode)
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
			previosCode = e.KeyCode;
		}

		private void pacmanMove_Tick(object sender, EventArgs e)
		{
			switch ((int)direction)
			{
				case 1:
					if(pctPacman.Location.Y -step < 0)
						pctPacman.Location = new Point(pctPacman.Location.X, Height - step);
					else
						pctPacman.Location = new Point(pctPacman.Location.X, pctPacman.Location.Y - step);
					break;
				case 3:
					if (pctPacman.Location.Y + step >= Height)
						pctPacman.Location = new Point(pctPacman.Location.X, 0);
					else
						pctPacman.Location = new Point(pctPacman.Location.X, pctPacman.Location.Y + step);
					break;
				case 2:

					if (pctPacman.Location.X + step >= Width)
						pctPacman.Location = new Point(0, pctPacman.Location.Y);
					else
						pctPacman.Location = new Point(pctPacman.Location.X + step, pctPacman.Location.Y);
					break;
				case 4:
					if (pctPacman.Location.X - step < 0)
						pctPacman.Location = new Point(Width - step, pctPacman.Location.Y);
					else
						pctPacman.Location = new Point(pctPacman.Location.X - step, pctPacman.Location.Y);
					break;
				case 0:
					break;
			}
		}

		public void DrawSchene()
		{
			for (int i = 0; i < 28; i++)
			{
				for (int j = 0; j < 36; j++)
				{
					switch (map[i, j])
					{
						case 0:
							break;
						case 1:
							PictureBox stone = new PictureBox();
							stone.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\stone2.jpg";
							stone.Size = new Size(10, 10);
							stone.SizeMode = PictureBoxSizeMode.Zoom;
							stone.Location = new Point(i * 10, j * 10);
							Controls.Add(stone);
							break;
					}
				}
			}
			Console.WriteLine();
		}

		private void start_Click(object sender, EventArgs e)
		{
			start.Visible = false;
			DrawSchene();
			pctPacman = new PictureBox();
			pctPacman.ImageLocation = @"C:\Users\brija\Desktop\pacman\Pacman\Pacman\images\pacmanRight.png";
			pctPacman.Location = new Point(0,0);
			pctPacman.Size = new Size(10, 10);
			pctPacman.SizeMode = PictureBoxSizeMode.Zoom;
			pctPacman.Name = "pctPacman";
			Controls.Add(pctPacman);
			pacmanMove.Enabled = true;
			this.Focus();
		}
	}
}
