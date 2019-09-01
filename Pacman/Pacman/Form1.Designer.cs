namespace Pacman
{
	partial class Game
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pacmanMove = new System.Windows.Forms.Timer(this.components);
			this.start = new System.Windows.Forms.Button();
			this.redGhostMove = new System.Windows.Forms.Timer(this.components);
			this.yellowGhostMove = new System.Windows.Forms.Timer(this.components);
			this.pinkGhostMove = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pacmanMove
			// 
			this.pacmanMove.Interval = 20;
			this.pacmanMove.Tick += new System.EventHandler(this.PacmanMove_Tick);
			// 
			// start
			// 
			this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.start.Location = new System.Drawing.Point(90, 116);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(90, 97);
			this.start.TabIndex = 2;
			this.start.Text = "start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.Start_Click);
			// 
			// redGhostMove
			// 
			this.redGhostMove.Interval = 20;
			this.redGhostMove.Tick += new System.EventHandler(this.RedGhostMove_Tick);
			// 
			// yellowGhostMove
			// 
			this.yellowGhostMove.Interval = 25;
			this.yellowGhostMove.Tick += new System.EventHandler(this.YellowGhostMove_Tick);
			// 
			// pinkGhostMove
			// 
			this.pinkGhostMove.Interval = 25;
			this.pinkGhostMove.Tick += new System.EventHandler(this.PinkGhostMove_Tick);
			// 
			// Game
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(284, 361);
			this.Controls.Add(this.start);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximumSize = new System.Drawing.Size(1000, 1000);
			this.MinimumSize = new System.Drawing.Size(300, 400);
			this.Name = "Game";
			this.ShowIcon = false;
			this.Text = "Pacman";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pacman_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer pacmanMove;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Timer redGhostMove;
		private System.Windows.Forms.Timer yellowGhostMove;
		private System.Windows.Forms.Timer pinkGhostMove;
	}
}

