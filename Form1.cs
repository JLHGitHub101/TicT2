using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3
{
    public partial class Form1 : Form
    {
        bool startgame = false;
        bool userFirst = false;
        bool winner = false;
        int movesXLeft = 5;
        int movesOLeft = 4;
  
        public Form1()
        {
            InitializeComponent();
        }

        /*  Create a Timer Class 
        private static void Timer() 
        {
            Timer exitTimer = new Timer();
            exitTimer.Interval = 10000;
            exitTimer.Start();
        }
        */
        private void Start_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int humanuser = rand.Next(1,11);
            int computer = rand.Next(1,11);
            int firstmove;
            startgame = true;

            do
            { 
                firstmove = rand.Next(1,11);
            }
            while (!((firstmove == humanuser) || (firstmove == computer)));

            if (firstmove == humanuser)
            {
                Display.Text = "Users Move";
                userFirst = true;
            }
            else
            {
                Display.Text = "Computers Move";
            }   
        }
        private void SetUserSymbol(object sender, EventArgs e)
        {
            if (startgame == true && userFirst == true)
            {
                TextBox user = (TextBox)sender;
                user.Text = "X";
                Winner();
                // Testing 
                if ( winner == true)
                {
                    Display.Text = "You are a Winner";
                    
                }
                else
                {
                    if (--movesXLeft == 0)
                    {
                       Display.Text = " Cats Game" ;
                        movesXLeft = 5;
                    }
                }

                  
            }
            else
            {
                TextBox user = (TextBox)sender;
                user.Text = "O";
                Winner();
                // Testing Below 
                if (winner == true)
                {
                    Display.Text = "You are a Winner";
                }
                else 
                {
                    if (--movesOLeft == 0)
                    {
                        Display.Text = " Cats Game";
                        movesOLeft = 4;
                    }
                }
            }
        }
        private void End_Button(object sender, EventArgs e)
        {
            Display.Text = "You have Ended the Game";
            // Input a Timer to Display Text above before exiting game. 
            Application.Exit();
          
        }

        private void Winner()
        {
            //
            if ((R1C1.Text == R1C2.Text) && (R1C2.Text == R1C3.Text) && R1C1.Text != "") 
            {
                winner = true;
            }
        }
    }
}
