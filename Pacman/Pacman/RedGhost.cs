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
	class RedGhost
	{
		public RedGhost(Game game,PacmanClass pacman)
		{
			this.pacman = pacman;
			this.game = game;
		}
		PacmanClass pacman;
		Game game;
		public PictureBox redGhost;
		double redGhostWaysLenght;
		int redGhostDirection;
		int ghostSteps = 0;
		public int redGhostCenterX;
		public int redGhostCenterY;
		public void RedGhostMove()
		{
			if (ghostSteps < chunkSize / step)
			{
				switch (redGhostDirection)
				{
					case 1:
						redGhost.Location = new Point(redGhost.Location.X, redGhost.Location.Y - step);
						break;
					case 2:
						if (redGhostCenterX - step < 0)
							redGhost.Location = new Point(width - chunkSize / 2 - step, redGhost.Location.Y);
						else
							redGhost.Location = new Point(redGhost.Location.X - step, redGhost.Location.Y);
						break;
					case 3:
						redGhost.Location = new Point(redGhost.Location.X, redGhost.Location.Y + step);
						break;
					case 0:
						if (redGhostCenterX + step == width)
							Console.WriteLine();
						if (redGhostCenterX + step >= width)
							redGhost.Location = new Point(-1 * chunkSize / 2, redGhost.Location.Y);
						else
							redGhost.Location = new Point(redGhost.Location.X + step, redGhost.Location.Y);
						break;
				}
				redGhostCenterX = redGhost.Location.X + chunkSize / 2;
				redGhostCenterY = redGhost.Location.Y + chunkSize / 2;
				ghostSteps++;
			}
			else
			{
				redGhostDirection = redGhostChase();
				ghostSteps = 0;
			}
		}
		int redGhostChase()
		{
			int upChunkValue = game.GameMap[redGhostCenterX / chunkSize, (redGhostCenterY / chunkSize) - 1];
			int downChunkValue = game.GameMap[redGhostCenterX / chunkSize, (redGhostCenterY / chunkSize) + 1];
			int rightChunkValue = 0;
			int leftChunkValue = 0;

			if ((redGhostCenterX / chunkSize) + 1 == 28)
				rightChunkValue = game.GameMap[0, redGhostCenterY / chunkSize];
			else
				rightChunkValue = game.GameMap[(redGhostCenterX / chunkSize) + 1, redGhostCenterY / chunkSize];

			if ((redGhostCenterX / chunkSize) - 1 == -1)
				rightChunkValue = game.GameMap[width / chunkSize - 1, redGhostCenterY / chunkSize];
			else
				leftChunkValue = game.GameMap[(redGhostCenterX / chunkSize) - 1, redGhostCenterY / chunkSize];


			int nextDirection = 0;

			double lenght;

			redGhostWaysLenght = 1000000000;

			if ((upChunkValue == 0 || upChunkValue == 2) && (redGhostDirection + 2) % 4 != 1)
			{
				redGhostWaysLenght = Math.Sqrt(Math.Pow(redGhostCenterX - pacman.PacmanPctCenterX, 2) + Math.Pow(redGhostCenterY - chunkSize - pacman.PacmanPctCenterY, 2));
				nextDirection = 1;
			}
			if ((leftChunkValue == 0 || leftChunkValue == 2) && (redGhostDirection + 2) % 4 != 2)
			{
				lenght = Math.Sqrt(Math.Pow(redGhostCenterX - chunkSize - pacman.PacmanPctCenterX, 2) + Math.Pow(redGhostCenterY - pacman.PacmanPctCenterY, 2));
				if (lenght < redGhostWaysLenght)
				{
					redGhostWaysLenght = lenght;
					nextDirection = 2;
				}
			}
			if ((downChunkValue == 0 || downChunkValue == 2) && (redGhostDirection + 2) % 4 != 3)
			{
				Console.WriteLine();
				lenght = Math.Sqrt(Math.Pow(redGhostCenterX - pacman.PacmanPctCenterX, 2) + Math.Pow(redGhostCenterY + chunkSize - pacman.PacmanPctCenterY, 2));
				if (lenght < redGhostWaysLenght)
				{
					redGhostWaysLenght = lenght;
					nextDirection = 3;
				}
			}
			if ((rightChunkValue == 0 || rightChunkValue == 2) && (redGhostDirection + 2) % 4 != 0)
			{
				lenght = Math.Sqrt(Math.Pow(redGhostCenterX + chunkSize - pacman.PacmanPctCenterX, 2) + Math.Pow(redGhostCenterY - pacman.PacmanPctCenterY, 2));
				if (lenght < redGhostWaysLenght)
				{
					redGhostWaysLenght = lenght;
					nextDirection = 0;
				}
			}
			return nextDirection;
		}
	}
}
