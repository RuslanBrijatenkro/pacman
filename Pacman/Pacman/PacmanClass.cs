using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pacman.Map;

namespace Pacman
{
	class PacmanClass
	{
		int pacmanPctCenterX;
		int pacmanPctCenterY;

		public int PacmanPctCenterX { get { return pacmanPctCenterX; }}
		public int PacmanPctCenterY { get { return pacmanPctCenterY; }}

		public PictureBox pctPacman;

		public Direction direction = 0;
		public Keys previosDirectionCode;

		public enum Direction : int
		{
			Up = 1,
			Right = 4,
			Down = 3,
			Left = 2
		}

		public void PacmanDirection(KeyEventArgs e)
		{
			if (previosDirectionCode == e.KeyCode)
			{
				Console.WriteLine();
				return;
			}
			switch (e.KeyCode)
			{
				case Keys.Up:
					pctPacman.Image = Properties.Resources.pacmanUp;
					direction = Direction.Up;
					break;
				case Keys.Down:
					pctPacman.Image = Properties.Resources.pacmanDown;
					direction = Direction.Down;
					break;
				case Keys.Right:
					pctPacman.Image = Properties.Resources.pacmanRight;
					direction = Direction.Right;
					break;
				case Keys.Left:
					pctPacman.Image = Properties.Resources.pacmanLeft;
					direction = Direction.Left;
					break;
			}
			previosDirectionCode = e.KeyCode;
		}
		public void PacmanMove(int[,] gameMap)
		{
			pacmanPctCenterX = pctPacman.Location.X + chunkSize / 2;
			pacmanPctCenterY = pctPacman.Location.Y + chunkSize / 2;

			switch ((int)direction)
			{
				case 1:
					if (gameMap[pacmanPctCenterX / chunkSize, (pacmanPctCenterY - step) / chunkSize] == 1)
						break;
					if (pctPacman.Location.Y - step < 0)
						pctPacman.Location = new Point(pctPacman.Location.X, height - step);
					else
						pctPacman.Location = new Point(pctPacman.Location.X, pctPacman.Location.Y - step);
					break;
				case 3:
					if (gameMap[pacmanPctCenterX / chunkSize, (pacmanPctCenterY + step) / chunkSize] == 1)
						break;
					if (pctPacman.Location.Y + step >= height)
						pctPacman.Location = new Point(pctPacman.Location.X, 0);
					else
						pctPacman.Location = new Point(pctPacman.Location.X, pctPacman.Location.Y + step);
					break;
				case 4:
					if (pacmanPctCenterX + step >= width)
						pctPacman.Location = new Point(-1 * chunkSize / 2 + step, pctPacman.Location.Y);
					else
					{
						if (gameMap[(pacmanPctCenterX + step) / chunkSize, pacmanPctCenterY / chunkSize] == 1)
							break;
						pctPacman.Location = new Point(pctPacman.Location.X + step, pctPacman.Location.Y);
					}
					break;
				case 2:
					if (gameMap[(pacmanPctCenterX - step) / chunkSize, pacmanPctCenterY / chunkSize] == 1)
						break;
					if (pacmanPctCenterX - step < 0)
						pctPacman.Location = new Point(width - step - chunkSize / 2, pctPacman.Location.Y);
					else
						pctPacman.Location = new Point(pctPacman.Location.X - step, pctPacman.Location.Y);
					break;
				case 0:
					break;
			}
		}

	}
}
