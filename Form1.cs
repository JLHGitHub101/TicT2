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
        
        public Form1()
        {
            InitializeComponent();

           
 
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int humanuser = rand.Next(1,11);
            int computer = rand.Next(1,11);
            int firstmove;

            do
            { 
                firstmove= rand.Next(1,11);
            }
            while (!((firstmove == humanuser) || (firstmove == computer)));

            if (firstmove == humanuser)
            {
                Users_Scores.Text = "Human 1st";
            }
            else
            {
                Users_Scores.Text = "Computer 1st";
            }
     

        }
        private void BoxSelection(object sender, EventArgs e)
        {
           TextBox user =  (TextBox)sender;
            user.Text = "X";
        }

   
    }
}
