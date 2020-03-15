using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            NameProgram.Left = this.Width/2 - NameProgram.Width/2;
        }


        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            UnFocus();
            if (this.userName.Text == "Ваше имя" || this.userName.Text == "")
            {
                MessageBox.Show("Введите Ваше имя!");
            }
            else
            {
                Crossroad game = new Crossroad();
                game.Show();
                this.Hide();
            }
            
        }

        private void buttonInstruction_Click(object sender, EventArgs e)
        {
            UnFocus();
            Form instruction = new Instruction();
            instruction.Show(); 
            this.Hide(); 
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void buttonRaiting_Click(object sender, EventArgs e)
        {
            Form raiting = new ListRaiting();
            raiting.Show();
            this.Hide();
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            if (this.userName.Text != "Ваше имя")
            {
                this.userName.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.userName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void userName_Click(object sender, EventArgs e)
        {
            if (this.userName.Text == "Ваше имя")
            {
                this.userName.Text = "";
            }
           
        }

        private void UnFocus()
        {
            if (this.userName.Text == "")
            {
                this.userName.Text = "Ваше имя";
            }
            this.ActiveControl = null;
            Thread myThread = new Thread(new ThreadStart(BestOfCustomer));
            myThread.Start();
        }

        private void BestOfCustomer()
        {
            // using (var db = new MyDbContext())
            {
                Customer Customer = Program.db.Customers.FirstOrDefault(customer => customer.Name == Program.menu.userName.Text);
                if (Customer != null)
                {
                    this.bestcustomer.Text = "Your best : " + Customer.Point;
                }
                else
                {
                    this.bestcustomer.Text = "";
                }

            }
        }
        private void Menu_Click(object sender, EventArgs e)
        {
            UnFocus();
        }

        private void bestses_Paint(object sender, PaintEventArgs e)
        {
            bestses.Text = $"Best session : {bestSession}";
        }
    }
}
