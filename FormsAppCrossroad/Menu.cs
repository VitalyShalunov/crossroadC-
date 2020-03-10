using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppCrossroad
{
    public partial class Menu : Form
    {
        public int totalPoint, bestSession;
        public Menu()
        {
            InitializeComponent();
            this.Width = 1540;
            //pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
            NameProgram.Left = this.Width/2 - NameProgram.Width/2;
        }


        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Crossroad game = new Crossroad();
            game.Show();
            this.Hide();
        }

        private void buttonInstruction_Click(object sender, EventArgs e)
        {
            Form instruction = new Instruction();
            instruction.Show(); 
            this.Hide(); 
            //Instruction instruction = new Instruction();
            //instruction.Show();
            //this.Hide();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
           // this.Close();
        }

        private void total_Paint(object sender, PaintEventArgs e)
        {
            total.Text = $"Total : {totalPoint}";
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (bestSession < totalPoint)
            {
                bestSession = totalPoint;
            }
        }

        private void Menu_Shown(object sender, EventArgs e)
        {
            if (bestSession < totalPoint)
            {
                bestSession = totalPoint;
            }
        }

        private void bestses_Paint(object sender, PaintEventArgs e)
        {
            bestses.Text = $"Best session : {bestSession}";
        }
    }
}
