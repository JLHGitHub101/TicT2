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
        Random rand = new Random();
        bool startgame = false;
        bool userFirst = false;
        bool winner = false;     
        int movesLeft = 9;
        bool user = false;
        string computerSymbol = "X";


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
            startgame = true;
            int human = rand.Next(1, 11);
            int computer = rand.Next(1, 11);
            int firstMove;
            do
            {
                firstMove = rand.Next(1, 11);
            }
            while (!((firstMove == human) || (firstMove == computer)));

            if (firstMove == human)
            {
                Display.Text = "Users Moves";
                userFirst = true;
            }
            else
            {
                Display.Text = "Computers Move";
                ComputerMove();
            }
        }
        private void UsersMove(object sender, EventArgs e)
        {
            if (startgame == true && userFirst == true)
            {
                TextBox userSymbol = (TextBox)sender;
                userSymbol.Text = "X";
                user = true;
                Ch_for_Winner();
                ComputerMove();
            }
            else
            {
                TextBox userSymbol = (TextBox)sender;
                userSymbol.Text = "O";
                user = true;
                Ch_for_Winner();
                ComputerMove();
            }
        }
        private void ComputerMove()
        {
            if (userFirst == true)
            {
                computerSymbol = "O";
            }
            int computermove = rand.Next(1, 10);
            switch (computermove)
            {

                case 1:
                    {
                        if (R1C1.Text == "")
                        {
                            R1C1.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 2:
                    {
                        if (R1C2.Text == "")
                        {
                            R1C2.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 3:
                    {
                        if (R1C3.Text == "")
                        {
                            R1C3.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 4:
                    {
                        if (R2C1.Text == "")
                        {
                            R2C1.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 5:
                    {
                        if (R2C2.Text == "")
                        {
                            R2C2.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 6:
                    {
                        if (R2C3.Text == "")
                        {
                            R2C3.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 7:
                    {
                        if (R3C1.Text == "")
                        {
                            R3C1.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 8:
                    {
                        if (R3C2.Text == "")
                        {
                            R3C2.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                case 9:
                    {
                        if (R3C3.Text == "")
                        {
                            R3C3.Text = computerSymbol;
                        }
                        else { ComputerMove(); }
                    }
                    break;
                default:
                    {
                        Display.Text = "I should not be Here.";
                    }
                    break;
            }
            Ch_for_Winner();
        }
        private void End_Button(object sender, EventArgs e)
        {
            Display.Text = "You have Ended the Game";
            // Input a Timer to Display Text above before exiting game. 
            Application.Exit();

        }
        private void Ch_for_Winner()
        {
            --movesLeft;
            if (movesLeft == 4)
            {

                // Test that a Verical Pattern creates a winning pattern
                if ((R1C1.Text == R1C2.Text) && (R1C2.Text == R1C3.Text) && R1C1.Text != "")
                { winner = true; }
                else if ((R2C1.Text == R2C2.Text) && (R2C2.Text == R2C3.Text) && R1C1.Text != "")
                { winner = true; }
                else if ((R3C1.Text == R3C2.Text) && (R3C2.Text == R3C3.Text) && R3C1.Text != "")
                { winner = true; }

                // Test that a Horizontal Pattern creates a winning pattern
                else if ((R1C1.Text == R2C1.Text) && (R2C1.Text == R3C1.Text) && R1C1.Text != "")
                { winner = true; }
                else if ((R1C2.Text == R2C2.Text) && (R2C2.Text == R3C2.Text) && R1C2.Text != "")
                { winner = true; }
                else if ((R1C3.Text == R2C3.Text) && (R2C3.Text == R3C3.Text) && R1C3.Text != "")
                { winner = true; }

                // Test that a Diagonal Pattern creates a winning pattern
                else if ((R1C1.Text == R2C2.Text) && (R2C2.Text == R3C3.Text) && R1C1.Text != "")
                { winner = true; }
                else if ((R3C1.Text == R2C2.Text) && (R2C2.Text == R1C3.Text) && R3C1.Text != "")
                { winner = true; }

                // Determine who won User or Computer
                if (winner == true && user == true)
                {
                    Display.Text = "You Won";
                    CleanBoard();

                    // Create a Delay then restart Game 
                }
                else if (winner == true && user == false)
                {
                    Display.Text = "Computer Won";
                    CleanBoard();

                    // Create a Delay then restart Game
                }
            }
            else if (movesLeft == 0)
            {
                Display.Text = "Cats Game";
                CleanBoard();
            }
            user = false;

        }
        private void CleanBoard()
        {
            R1C1.Text = "";
            R1C2.Text = "";
            R1C3.Text = "";
            R2C1.Text = "";
            R2C2.Text = "";
            R2C3.Text = "";
            R3C1.Text = "";
            R3C2.Text = "";
            R3C3.Text = "";
            winner = false;
            user = false;
            startgame = false;
            userFirst= false;
            movesLeft = 9;
            
        }
    }
}
