/*
 * Created by SharpDevelop.
 * User: casper
 * Date: 11.04.2020
 * Time: 11:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// Copyright (C) 2020  NeonWards
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

namespace Game
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	  
	public partial  class MainForm :Form
	{
		 int tra_x = 290;//260
		 int tra_y = 0;
		 int health = 100; 
		 public int gravitySpeed = 1;
		 
		 
 public int Gravity = 1;
 bool falling = false;
 bool left;
 bool right;
 bool up;
 bool down;
 bool lync;
 bool player_seen = false;
   int drawlimit;
   string antialias;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
	
		
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		        [DllImport("user32.dll")]  
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);  
        public static void TurnONCapsLockKey()  
        {  
             const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)1);
        }  
  string title;
		    static string ConvertStringArrayToString(string[] array)
    {
        // Concatenate all the elements into a StringBuilder.
        StringBuilder builder = new StringBuilder();
        foreach (string value in array)
        {
            builder.Append(value);
            builder.Append(' ');
        }
        return builder.ToString();
    }
		    
		 Graphics spritelayer_1;
		 Graphics back_nplayer;
		void MainFormPaint(object sender, PaintEventArgs e)
		{
		pictureBox1.Visible = true;

		spritelayer_1 =  pictureBox1.CreateGraphics();	//Flickery Layer
		
		}
		string[] columnValues;
	
    //string[] confValues;
		void MainFormLoad(object sender, EventArgs e)
		{
		
			
			
			//Load
this.DoubleBuffered = true;			
    Type controlType = pictureBox1.GetType();
        PropertyInfo pi = controlType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        pi.SetValue(pictureBox1, true, null);
			//columnValues = new string[5]{ "Element 1", "Element 2" };
			// Add the event handler for handling UI thread exceptions to the event.


// Set the unhandled exception mode to force all Windows Forms errors to go through
// our handler.
SetStyle(ControlStyles.UserPaint, true);
SetStyle(ControlStyles.AllPaintingInWmPaint, true); 
SetStyle(ControlStyles.DoubleBuffer, true); 
			
   string rootFolder = Path.GetDirectoryName(Application.ExecutablePath);;    
   
  //Default file. MAKE SURE TO CHANGE THIS LOCATION AND FILE PATH TO YOUR FILE   
  string textFile = String.Format("{0}\\game.is",rootFolder);

    StreamReader myReader = new StreamReader(textFile);
String line = "E";
int miktar = columnValues.GetLength(1);;
for (int i =0; i <miktar; i++)
{
 
       line = myReader.ReadLine();
    char[] delimiters = new char[] {' ', '\t'};
  
    columnValues = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    
    MessageBox.Show(line);
                   
}  

  string confFile = String.Format("{0}\\Game.conf",rootFolder);





   }  
		
	
		void settings(PaintEventArgs e)
		{
				
			if(antialias.Contains("anti-alias")){
				e.Graphics.SmoothingMode = 
        System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			}
	if(antialias.Contains("hspeed")){
				e.Graphics.SmoothingMode = 
        System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
			}
	if(antialias.Contains("hquality")){
				e.Graphics.SmoothingMode = 
        System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			}
	if(antialias.Contains("none")){
				e.Graphics.SmoothingMode = 
        System.Drawing.Drawing2D.SmoothingMode.None;
			}
	if(antialias.Contains("default")){
				e.Graphics.SmoothingMode = 
        System.Drawing.Drawing2D.SmoothingMode.Default;
			}
		}
		
		
	   	void ai(PaintEventArgs e)
		{
int x = 0;
int y = 0;	   		
int x_size = 50;

int y_size = 50;

	  		for (int i = 0; i <  drawlimit ; i++)
                {
	   						
	   				
	  
	   			if (columnValues[i].Contains("evilnpc")){
	   					 x = Int32.Parse(columnValues[i+1]);
	   y = Int32.Parse(columnValues[i+2]);
	  
	   					
	   					bool player_killed = false;
	   					bool idle = true;
	   					bool died = false;
	   					bool gun = true;
	   					string weapon = "Pistol";
	   					int ammo = 10;
	   					
	   					e.Graphics.DrawRectangle(new Pen(Brushes.Chocolate),x,y,x_size,y_size);



}
	//Collision Detection Right:
		if( tra_x < x + x_size &&
     tra_x + 20 > x &&
     tra_y < y + y_size &&
     tra_y + 20 > y)
{

player_seen = true;
}else{
		player_seen = false;
}
		
	   	if(player_seen == true){
	   						int near_x = tra_x-10;
	   						e.Graphics.DrawEllipse(new Pen(Brushes.DeepSkyBlue),near_x,y,40,40);
	   					}				
				
				}
	   						
	   					}
	   		
	   	
			
	   	
	   		
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
		//candlescream specials
    Rectangle rectangle2 = new Rectangle(tra_x, tra_y, 20, 20);

back_nplayer =  this.CreateGraphics();	


    e.Graphics.FillRectangle(Brushes.Red, rectangle2);
    
    Brush textBrush = new SolidBrush(Color.Red);
 Font font = new Font("Pixelita", 12.0f);

 e.Graphics.DrawString(String.Format("Health: {0}",health),font,textBrush,200,0);
                	
        this.DoubleBuffered = true;
        settings(e);
           ai(e);
        ParserObject_Layer1(e);
     
		}
		
		
		
		void PictureBox1Click(object sender, EventArgs e)
		{
					
		}
	
		void ParserObject_Layer1(PaintEventArgs e)
		{
			for (int i = 0; i <  drawlimit ; i++)
{
			/*	if (columnValues[i].Contains("keyboard")){
					
				}*/
        	   if (columnValues[i].Contains("map.sprite")){
	// Rectangle mouseNewRect;
	 int x = Int32.Parse(columnValues[i+2]);
	  int y = Int32.Parse(columnValues[i+3]);
int x_size = Int32.Parse(columnValues[i+4]);

int y_size = Int32.Parse(columnValues[i+5]);

	Rectangle inf = new Rectangle(x, y,x_size,y_size);
// SolidBrush blueBrush  = new SolidBrush(Color.Red);
string rootFolder = Path.GetDirectoryName(Application.ExecutablePath);;    
//string image = String.Format("{0}{1}",rootFolder,string.Join("", columnValues[i+1]));
string image =  String.Format("{0}\\assets\\sprites\\sprite{1}.png",rootFolder,string.Join("", columnValues[i+1]));
Bitmap myBitmap = new Bitmap(image);
	e.Graphics.DrawImage(myBitmap,inf );
	
	//Collision Detection Top:
		if( tra_x < x + x_size &&
     tra_x + 20 > x &&
     tra_y < y + y_size/2 &&
     tra_y + 20 > y)
{
falling=false;//int tra_x = 260;
tra_y-=1;
}
		//Collision Detection Bottom:
		if( tra_x < x + x_size &&
     tra_x + 20 > x &&
     tra_y < y+y/2 + y_size/2 &&
     tra_y + 20 > y+y/2)
{

tra_y+=1;
}
				//Collision Detection Left:
		if( tra_x < x + x_size-20 &&
     tra_x + 20 > x &&
     tra_y < y+3 + y_size-10 &&
     tra_y + 20 > y+3)
{

tra_x-=1;
}
	//Collision Detection Right:
		if( tra_x < x+20 + x_size-20 &&
     tra_x + 20 > x+20 &&
     tra_y < y+3 + y_size-10 &&
     tra_y + 20 > y+3)
{

tra_x+=1;
}
	/*	e.Graphics.DrawRectangle(new Pen(Brushes.Chocolate),x,y+y/2,x_size,y_size);
		e.Graphics.DrawRectangle(new Pen(Brushes.Chocolate),x,y+3,x_size-20,y_size-10);
		e.Graphics.DrawRectangle(new Pen(Brushes.Chocolate),x+20,y+3,x_size-20,y_size-10);*/
	}	
  }			
		}
		
void Timer1Tick(object sender, EventArgs e)
		{
			 
	this.Refresh();

	
		}
		
	
		
		void Timer4Tick(object sender, EventArgs e)
		{
			 string rootFolder = Path.GetDirectoryName(Application.ExecutablePath);;    
List<string[]> confValues = File.ReadLines(String.Format("{0}\\game.conf",rootFolder))
	.Select(r => r.TrimEnd('*').Split(':'))
                          .ToList();

  
   
    
                   title = String.Concat(confValues[1]);
                   
                   title.Replace("Title"," ");
 title.Replace("_"," ");
string avariable = String.Concat(confValues[10]);
 antialias = String.Concat(confValues[12]);
 
drawlimit = Int32.Parse(avariable);
this.Text = title;
timer4.Enabled = false;

		}
		
		
		void PhysTick(object sender, EventArgs e)
		{
			
		down=true;
	  
			if(falling == true){
			  gravitySpeed += Gravity;
    //tra_x += 1;
    tra_y += 1 + gravitySpeed;
		//tra_y++;
		}

	
			
	


		
}
	
	
		
		void Timer5Tick(object sender, EventArgs e)
		{
			
		}
		
		void DisablerTick(object sender, EventArgs e)
		{
			falling=true;
			lync =true;
		}
		
		void JumperTick(object sender, EventArgs e)
		{
			
tra_y--;


		}
		
	
		
		void NojumpTick(object sender, EventArgs e)
		{
			if(jumper.Enabled ==true){
	falling=true;
	sta.Enabled=true;
}
			
jumper.Enabled = false;		


		}
		
		void StaTick(object sender, EventArgs e)
		{
falling=false;			
sta.Enabled = false;
		}
		
	
		
		void MainFormResize(object sender, EventArgs e)
		{
			pictureBox1.Width = this.Width;		
pictureBox1.Height = this.Height;
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			            if (e.KeyCode == Keys.W)
            {
                tra_y-=1;
            }
			            if (e.KeyCode == Keys.S)
            {
                tra_y+=1;
            }
			            if (e.KeyCode == Keys.D)
            {
                tra_x+=1;
            }
			            if (e.KeyCode == Keys.A)
            {
                tra_x-=1;
            }
			 if (e.KeyCode == Keys.Space)
            {
					 	jumper.Enabled = true;
	
            }	
			 
			for (int i = 0; i <  drawlimit ; i++)
{
				if (columnValues[i].Contains("key.f")){
					if (e.KeyCode == Keys.F)
            {
					if (columnValues[i+1].Contains("tra_x++")){
							tra_x++;
						}
					if (columnValues[i+1].Contains("tra_x--")){
							tra_x--;
						}	
					if (columnValues[i+1].Contains("itempick")){
							//itempick();
						}			
            }				
				}
		}
		}
		
	// % işleci bölme işleminin kalanını bulur
   }}
			
			
		




