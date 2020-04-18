using System.Drawing;
/*
 * Created by SharpDevelop.
 * User: casper
 * Date: 11.04.2020
 * Time: 11:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Game
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer4 = new System.Windows.Forms.Timer(this.components);
			this.phys = new System.Windows.Forms.Timer(this.components);
			this.disabler = new System.Windows.Forms.Timer(this.components);
			this.jumper = new System.Windows.Forms.Timer(this.components);
			this.nojump = new System.Windows.Forms.Timer(this.components);
			this.sta = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(1, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(828, 541);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
			// 
			// timer4
			// 
			this.timer4.Enabled = true;
			this.timer4.Tick += new System.EventHandler(this.Timer4Tick);
			// 
			// phys
			// 
			this.phys.Enabled = true;
			this.phys.Tick += new System.EventHandler(this.PhysTick);
			// 
			// disabler
			// 
			this.disabler.Tick += new System.EventHandler(this.DisablerTick);
			// 
			// jumper
			// 
			this.jumper.Interval = 1;
			this.jumper.Tick += new System.EventHandler(this.JumperTick);
			// 
			// nojump
			// 
			this.nojump.Enabled = true;
			this.nojump.Interval = 400;
			this.nojump.Tick += new System.EventHandler(this.NojumpTick);
			// 
			// sta
			// 
			this.sta.Interval = 400;
			this.sta.Tick += new System.EventHandler(this.StaTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(773, 540);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "Game";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.Resize += new System.EventHandler(this.MainFormResize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer sta;
		private System.Windows.Forms.Timer nojump;
		private System.Windows.Forms.Timer jumper;
		private System.Windows.Forms.Timer disabler;
		private System.Windows.Forms.Timer phys;
		private System.Windows.Forms.Timer timer4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
	}
}
