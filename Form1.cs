using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3
{
    public partial class Form1 : Form
    {

        string usersMove = "Users Move";
        string computerMove = "Computers Move";
        Random rand = new Random();
        int compNumGen;
        string computerSymbol = "X";
        bool startgame = false;
        bool userFirst = true;
        bool winner = false;
        int movesLeft = 8;
        bool user = false;
        string userSymbol;

        // Something 

        public Form1()
        {
            InitializeComponent();
        }
        private void StartGame(object sender, EventArgs e)
        {
            CleanBoard();
            startgame = true;
            int human = rand.Next(1, 11);
            int computer = rand.Next(1, 11);
            int firstMove;
            do
            {
                firstMove = rand.Next(1, 11);
            }
            while (!((firstMove == human) || (firstMove == computer)));

            if (firstMove != human)
            {
                userFirst = false;
                Display.Text = computerMove;
                ComputerMove();
            }
            else
            {
                computerSymbol = "O";
                Display.Text = usersMove;
            }
        }
        private void MakeAMove(object sender, EventArgs e)
        {

            if (startgame == false)
            {
                Display.Text = "Press Start for New Game or Stop to End";
            }
            else
            {
               
                if (userFirst == true)
                {
                    string index = $"{sender}" + ".tag";
                    user = true;
                    GameBoard(index, "X");
                }
                else
                {
                    string index = $"{sender}" + ".tag";
                    user = true;
                    GameBoard(index, "O");
                }
                Ch_for_Winner();
                ComputerMove();
            }
        }
        private async void ComputerMove()
        {
            string[] board = new string[] {R1C1.Text, R1C2.Text, R1C3.Text, 
                                            R2C1.Text, R2C2.Text, R2C3.Text, 
                                            R3C1.Text, R3C2.Text, R3C3.Text};
            user = false;
            Display.Text = computerMove;
            await Task.Delay(2000);
            string position;

            do
            {
                compNumGen = rand.Next(0, 8);

            } while (board[compNumGen] != "");

            position = compNumGen.ToString();
            GameBoard(position, computerSymbol);

            Ch_for_Winner();
            await Task.Delay(1000);
            Display.Text = usersMove;
        }
        private async void Ch_for_Winner()
        {
            movesLeft--;

            // Test that a Verical Pattern creates a winning pattern
            if ((R1C1.Text == R1C2.Text) && (R1C2.Text == R1C3.Text) && R1C1.Text != "")
            { winner = true; }
            else if ((R2C1.Text == R2C2.Text) && (R2C2.Text == R2C3.Text) && R2C1.Text != "")
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

            if (winner == true || movesLeft == 0)
            {
                // Determine who won User or Computer
                if (user == true)
                {
                    Display.Text = "You Won";
                    await Task.Delay(10000); ;
                }
                else if (user == false)
                {
                    Display.Text = "Computer Won";
                    await Task.Delay(10000);
                }
                // Check for Cats Game
                else if (movesLeft == 0)
                {
                    Display.Text = "Cats Game";
                    await Task.Delay(10000);
                }
                CleanBoard();
            }
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
            bool startgame = false;
            bool userFirst = true;
            bool winner = false;
            int movesLeft = 8;
            bool user = false;
        }
        private async void End_Button(object sender, EventArgs e)
        {
            Display.Text = "You have Ended the Game";
            await Task.Delay(1000);
            Application.Exit();
        }
        private void GameBoard(string indexee, string symbol)
        {
            string[] board = new string[] {R1C1.Text, R1C2.Text, R1C3.Text,
                                        R2C1.Text, R2C2.Text, R2C3.Text,
                                        R3C1.Text, R3C2.Text, R3C3.Text};
           int index = Int32.Parse(indexee);

            if (user == true)
            {
                board[index] = symbol;
            }
        }
    }
}


// 
//                              R1C1.Text , R1C2.Text, R1C3.Text,
//                            R2C1.Text,R2C2.Text,R2C3.Text,
//                          R3C1.Text,R3C2.Text,R3C3.Text,};
//



