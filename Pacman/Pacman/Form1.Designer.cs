﻿namespace Pacman
{
	partial class Pacman
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
			this.SuspendLayout();
			// 
			// pacmanMove
			// 
			this.pacmanMove.Interval = 20;
			this.pacmanMove.Tick += new System.EventHandler(this.pacmanMove_Tick);
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(74, 105);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(90, 97);
			this.start.TabIndex = 2;
			this.start.Text = "start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// Pacman
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(264, 361);
			this.Controls.Add(this.start);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximumSize = new System.Drawing.Size(280, 400);
			this.MinimumSize = new System.Drawing.Size(280, 400);
			this.Name = "Pacman";
			this.Text = "Pacman";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pacman_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer pacmanMove;
		private System.Windows.Forms.Button start;
	}
}

