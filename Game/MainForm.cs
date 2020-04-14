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

namespace Game
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	  
	public partial  class MainForm :Form
	{
		int tra_x = 260;
		int tra_y = 0;
		 public int gravitySpeed = 1;
 public int Gravity = 1;
 bool falling = false;
 bool left;
 bool right;
 bool up;
 bool down;
 bool lync;
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

		spritelayer_1 =  pictureBox1.CreateGraphics();	
		
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
  string textFile = String.Format("{0}\\map.imap",rootFolder);

    StreamReader myReader = new StreamReader(textFile);
String line = "E";
for (int i =0; i <15; i++)
{
    line = myReader.ReadLine();
    
    char[] delimiters = new char[] {' ', '\t'};
  
    columnValues = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    
}  

  string confFile = String.Format("{0}\\Game.conf",rootFolder);





   }  
		
	
	   
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			

    Rectangle rectangle2 = new Rectangle(tra_x, tra_y, 20, 20);

back_nplayer =  this.CreateGraphics();	
    e.Graphics.FillRectangle(Brushes.Red, rectangle2);
        this.DoubleBuffered = true;
for (int i = 0; i <  10 ; i+=3)
{
        	   if (columnValues[i].Contains("map.sprite")){
	// Rectangle mouseNewRect;
	 /*int x = Int32.Parse(columnValues[1]);
	  int Y = Int32.Parse(columnValues[2]);*/

	
// SolidBrush blueBrush  = new SolidBrush(Color.Red);
string rootFolder = Path.GetDirectoryName(Application.ExecutablePath);;    
//string image = String.Format("{0}{1}",rootFolder,string.Join("", columnValues[i+1]));
string image =  String.Format("{0}\\assets\\sprites\\sprite{1}.png",rootFolder,string.Join("", columnValues[i+1]));
Bitmap myBitmap = new Bitmap(image);
	e.Graphics.DrawImage(myBitmap, 10, 10);
	}	
  }	      
			
		}
		
		
		
		void PictureBox1Click(object sender, EventArgs e)
		{
					
		}
	
		void ParserObject()
		{
			 	
for (int i = 0; i <  10 ; i+=3)
{
	
			if (columnValues[i].Contains("map.redRect")){
			 Rectangle mouseNewRect;
	 /*int x = Int32.Parse(columnValues[1]);
	  int Y = Int32.Parse(columnValues[2]);*/

	 mouseNewRect = new Rectangle(new Point(Int32.Parse(columnValues[i+1]), Int32.Parse(columnValues[i+2])), new Size(100, 100));

	spritelayer_1.DrawRectangle(new Pen(Brushes.Red), mouseNewRect);
	}
		
	
   if (columnValues[i].Contains("map.newRect")){
	 Rectangle mouseNewRect;
	 int x = Int32.Parse(columnValues[i+1]);
	  int y = Int32.Parse(columnValues[i+2]);
	  

	 mouseNewRect = new Rectangle(new Point(Int32.Parse(columnValues[i+1]), Int32.Parse(columnValues[i+2])), new Size(100, 100));

	 //FIXME: Fix gravity+collision detection


   Rectangle mooseNewRect;
	 /* mooseNewRect = new Rectangle(x,y,5,10);
spritelayer_1.DrawRectangle(new Pen(Brushes.Chocolate), mooseNewRect);*/
	
	 //altay left the game 20:17 13.04.2020 seni özleyeceğim kanka: altay i will remember you forever thanks for my best buddy but you are leaving now :=( (he quitted) i can't reach him . 
	spritelayer_1.DrawRectangle(new Pen(Brushes.Chocolate), mouseNewRect);
	
	if( tra_x < x + 100 &&
     tra_x + 20 > x &&
     tra_y < y + 100 &&
     tra_y + 20 > y)
{
		if(falling==true){
			falling =true;
		tra_y-=20;
		
		}
		if(down =true ){
		//falling =true;
		tra_y-=30;
		down=false;
        }
		if(left==true){
				if(falling ==false){
				tra_x+=10;
			}else{
				tra_x-=10;
			}
			left=false;
		}
		if(right==true){
			if(falling ==false){
				tra_x-=10;
			}else{
				tra_x+=10;
			}
			
			right=false;
		}
				if(up=true){
			tra_y+=30;
			up=false;
		}
}

}
	
  
		   if (columnValues[i].Contains("map.fillRect")){
	 Rectangle mouseNewRect;
	 /*int x = Int32.Parse(columnValues[1]);
	  int Y = Int32.Parse(columnValues[2]);*/

	
 SolidBrush blueBrush  = new SolidBrush(Color.Red);

	
	}
	 /*  if (columnValues[i].Contains("map.sprite")){
	// Rectangle mouseNewRect;
	 /*int x = Int32.Parse(columnValues[1]);
	  int Y = Int32.Parse(columnValues[2]);*/
/*
	
// SolidBrush blueBrush  = new SolidBrush(Color.Red);
string rootFolder = Path.GetDirectoryName(Application.ExecutablePath);;    
//string image = String.Format("{0}{1}",rootFolder,string.Join("", columnValues[i+1]));
string image =  String.Format("{0}\\assets\\sprites\\sprite{1}.png",rootFolder,string.Join("", columnValues[i+1]));
Bitmap myBitmap = new Bitmap(image);
	spritelayer_1.DrawImage(myBitmap, 10, 10);
	}	*/
		
		   if (columnValues[i].Contains("map.newElips")){
	// Rectangle mouseNewRecta;
	 /*int x = Int32.Parse(columnValues[1]);
	  int Y = Int32.Parse(columnValues[2]);*/
	 Rectangle myRectangle = new Rectangle(new Point(Int32.Parse(columnValues[i+1]),Int32.Parse(columnValues[i+2])),new Size(80, 40));
	//spritelayer_1.DrawEllipse(new Point(Int32.Parse(columnValues[i-1]), Int32.Parse(columnValues[i-2])), new Size(100, 100));
spritelayer_1.DrawEllipse(new Pen(Brushes.Chocolate), myRectangle);
// mouseNewRecta = new Elipse(new Point(Int32.Parse(columnValues[i-1]), Int32.Parse(columnValues[i-2])), new Size(100, 100));
	//spritelayer_1.DrawEllipse(new Pen(Brushes.Chocolate), mouseNewRecta);
	}
		   if (columnValues[i+4].Contains("rect.blue")){
	 Rectangle mouseNewRecte;
	 
	 /*int x = Int32.Parse(columnValues[1]);
	  int Y = Int32.Parse(columnValues[2]);*/

	 mouseNewRecte = new Rectangle(new Point(Int32.Parse(columnValues[i-1]), Int32.Parse(columnValues[i-2])), new Size(100, 100));

	spritelayer_1.DrawRectangle(new Pen(Brushes.Chocolate), mouseNewRecte);
}

    // Create rectangle.
 /*   Rectangle rect; 
 rect = new Rectangle(new Point(Int32.Parse(columnValues[i+1]), Int32.Parse(columnValues[i+2])), new Size(100, 100));
    // Fill rectangle to screen.
    	
 SolidBrush blueBrushe  = new SolidBrush(Color.Red);
    spritelayer_1.FillRectangle(blueBrushe, rect);*/


}
					
		}	
		
void Timer1Tick(object sender, EventArgs e)
		{
			 
	this.Refresh();
	ParserObject();
	
		}
		
		void Timer2Tick(object sender, EventArgs e)
		{
this.Refresh();			
if(timer2.Interval == 1){
timer2.Interval = 500;
}
		}
	

		void MainFormKeyPress(object sender, KeyPressEventArgs e)
		{
		
							 if (e.KeyChar == 87)
            {
				 	tra_y--;
				 	timer2.Interval = 1;
				 	up = true;
				 	 //MessageBox.Show(title);
				 	
			    
            }
							 if (e.KeyChar == (char)Keys.S)
            {
				 	tra_y++;
				 	timer2.Interval = 1;
				 	down = true;
				 	
			   
            }
							 if (e.KeyChar == (char)Keys.A)
            {
				 	tra_x--;
				 	timer2.Interval = 1;
				 	left = true;
				 	
			
            }
							 if (e.KeyChar == (char)Keys.D)
            {
				 	tra_x++;
				 	timer2.Interval = 1;
				 	right = true;
				 	
            }
					 if (e.KeyChar == (char)Keys.Space)
            {
					 	jumper.Enabled = true;
	
            }							 
							 							 if (e.KeyChar == (char)Keys.G)
            {
				 	tra_y+=30;
				 	timer2.Interval = 1;
				 	right = true;
				 	
            }
		}
		
		void Timer3Tick(object sender, EventArgs e)
		{
    /*  if (Control.IsKeyLocked(Keys.CapsLock) {
           	MessageBox.Show("Warning: CAPSLOCK CAN BREAK MOVEMENT SYSTEM OF THIS GAME .IEDX Game engine input system currently doesn't capable of while capslock on and movement so please turn off/on i don't know what status of capslock but press again. YOU MAY ASK WHY BEACUSE I DON'T KNOW WHERES PROBLEM THIS ENGINE  IS OPEN SOURCE SO IF YOU WANT FIX IT LET ME KNOW I WILL ADD YOUR CODE ALSO I CREDIT YOU ");
           	
        }*/
						
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

this.Text = title;
timer4.Enabled = false;

		}
		
		
		void PhysTick(object sender, EventArgs e)
		{
			
		down=true;
	  
			if(falling == true){
			  gravitySpeed += Gravity;
    tra_x += 1;
    tra_y += 1 + gravitySpeed;}

	
			
	


		
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
   }}
			
			
		




