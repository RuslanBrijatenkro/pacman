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
	class GhostsMoving
	{
		public int ghostMoveType = 1;
		PacmanClass pacman;
		Game game;
		double ghostWayLenght;
		public GhostsMoving(Game game,PacmanClass pacman)
		{
			this.pacman = pacman;
			this.game = game;
		}
		public void GhostsMove(Ghost ghost)
		{
			if (ghost.GhostSteps < chunkSize / step)
			{
				switch (ghost.GhostDirection)
				{
					case 1:
						ghost.pctGhost.Location = new Point(ghost.pctGhost.Location.X, ghost.pctGhost.Location.Y - step);
						break;
					case 2:
						if (ghost.GhostCenterX - step < 0)
							ghost.pctGhost.Location = new Point(width - chunkSize / 2 - step, ghost.pctGhost.Location.Y);
						else
							ghost.pctGhost.Location = new Point(ghost.pctGhost.Location.X - step, ghost.pctGhost.Location.Y);
						break;
					case 3:
						ghost.pctGhost.Location = new Point(ghost.pctGhost.Location.X, ghost.pctGhost.Location.Y + step);
						break;
					case 0:
						if (ghost.GhostCenterX + step >= width)
							ghost.pctGhost.Location = new Point(-1 * chunkSize / 2, ghost.pctGhost.Location.Y);
						else
							ghost.pctGhost.Location = new Point(ghost.pctGhost.Location.X + step, ghost.pctGhost.Location.Y);
						break;
				}
				ghost.GhostCenterX = ghost.pctGhost.Location.X + chunkSize / 2;
				ghost.GhostCenterY = ghost.pctGhost.Location.Y + chunkSize / 2;
				ghost.GhostSteps++;
			}
			else
			{
				if(ghostMoveType==1)
				{
					if(ghost.Name=="Yellow")
					{
						switch ((int)pacman.direction)
						{
							case 1:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX, pacman.PacmanPctCenterY - 4 * chunkSize);
								break;
							case 2:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX - 4 * chunkSize, pacman.PacmanPctCenterY);
								break;
							case 3:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX, pacman.PacmanPctCenterY + 4 * chunkSize);
								break;
							case 4:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX + 4 * chunkSize, pacman.PacmanPctCenterY);
								break;
						}
					}
					else if(ghost.Name=="Red")
					{
						ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX, pacman.PacmanPctCenterY);
					}
					else if(ghost.Name=="Pink")
					{
						switch ((int)pacman.direction)
						{
							case 1:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX, pacman.PacmanPctCenterY + 4 * chunkSize);
								break;
							case 2:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX + 4 * chunkSize, pacman.PacmanPctCenterY);
								break;
							case 3:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX, pacman.PacmanPctCenterY - 4 * chunkSize);
								break;
							case 4:
								ghost.GhostDirection = GhostsDirection(ghost,pacman.PacmanPctCenterX - 4 * chunkSize, pacman.PacmanPctCenterY);
								break;
						}
					}
					ghost.GhostSteps = 0;
				}
				else if(ghostMoveType==2)
				{
					if(ghost.Name=="Yellow")
						ghost.GhostDirection = GhostsDirection(ghost,560,10);
					else if(ghost.Name=="Red")
						ghost.GhostDirection = GhostsDirection(ghost,10, 10);
					else if(ghost.Name=="Pink")
						ghost.GhostDirection = GhostsDirection(ghost,10, 620);
					ghost.GhostSteps = 0;
				}
			}
		}
		int GhostsDirection(Ghost ghost,int targetX, int targetY)
		{
			int upChunkValue = game.GameMap[ghost.GhostCenterX / chunkSize, (ghost.GhostCenterY / chunkSize) - 1];
			int downChunkValue = game.GameMap[ghost.GhostCenterX / chunkSize, (ghost.GhostCenterY / chunkSize) + 1];
			int rightChunkValue = 0;
			int leftChunkValue = 0;

			if ((ghost.GhostCenterX / chunkSize) + 1 == 28)
				rightChunkValue = game.GameMap[0, ghost.GhostCenterY / chunkSize];
			else
				rightChunkValue = game.GameMap[(ghost.GhostCenterX / chunkSize) + 1, ghost.GhostCenterY / chunkSize];

			if ((ghost.GhostCenterX / chunkSize) - 1 == -1)
				rightChunkValue = game.GameMap[width / chunkSize - 1, ghost.GhostCenterY / chunkSize];
			else
				leftChunkValue = game.GameMap[(ghost.GhostCenterX / chunkSize) - 1, ghost.GhostCenterY / chunkSize];


			int nextDirection = 0;

			double lenght;

			ghostWayLenght = 1000000000;

			if ( upChunkValue!=1 && (ghost.GhostDirection + 2) % 4 != 1)
			{
				ghostWayLenght = Math.Sqrt(Math.Pow(ghost.GhostCenterX - targetX, 2) + Math.Pow(ghost.GhostCenterY - chunkSize - targetY, 2));
				nextDirection = 1;
			}
			if (leftChunkValue != 1 && (ghost.GhostDirection + 2) % 4 != 2)
			{
				lenght = Math.Sqrt(Math.Pow(ghost.GhostCenterX - chunkSize - targetX, 2) + Math.Pow(ghost.GhostCenterY - targetY, 2));
				if (lenght < ghostWayLenght)
				{
					ghostWayLenght = lenght;
					nextDirection = 2;
				}
			}
			if (downChunkValue != 1 && (ghost.GhostDirection + 2) % 4 != 3)
			{
				lenght = Math.Sqrt(Math.Pow(ghost.GhostCenterX - targetX, 2) + Math.Pow(ghost.GhostCenterY + chunkSize - targetY, 2));
				if (lenght < ghostWayLenght)
				{
					ghostWayLenght = lenght;
					nextDirection = 3;
				}
			}
			if (rightChunkValue != 1 && (ghost.GhostDirection + 2) % 4 != 0)
			{
				lenght = Math.Sqrt(Math.Pow(ghost.GhostCenterX + chunkSize - targetX, 2) + Math.Pow(ghost.GhostCenterY - targetY, 2));
				if (lenght < ghostWayLenght)
				{
					ghostWayLenght = lenght;
					nextDirection = 0;
				}
			}
			return nextDirection;
		}
	}
}
