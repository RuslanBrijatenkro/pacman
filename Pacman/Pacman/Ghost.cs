using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
	class Ghost
	{
		public int PacmanUndead { get; set; }
		public int GhostSteps { get; set; }
		public PictureBox pctGhost;
		public int GhostDirection { get; set;}
		public int GhostCenterX { get; set; }
		public int GhostCenterY { get; set; }
		public string Name { get; set; }


	}
}
