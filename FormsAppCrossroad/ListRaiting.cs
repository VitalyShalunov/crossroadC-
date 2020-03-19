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
    public partial class ListRaiting : Form
    {
        private IQueryable<Customer> customers;
        int k = 0;
        public ListRaiting()
        {
            InitializeComponent();
            this.Width = 1540;
            NameProgram.Left = this.Width / 2 - NameProgram.Width / 2;
            this.statusDB.Text += "Подключение к БД . . .";
            this.ActiveControl = null;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Program.menu.Show();
            this.Hide();
        }

        private void ListRaiting_Shown()
        {
            try
            {
                customers = Program.db.Customers.OrderByDescending(cus => cus.Point);

                int i = 1;
                statusDB.Text = "";
                var textbox = new TextBox();
                textbox.Name = "list";
                textbox.MaximumSize = new Size(500, 300);
                textbox.Size = new Size(500, 300);
                textbox.ScrollBars = ScrollBars.Vertical;
                textbox.Multiline = true;
                textbox.ReadOnly = true;
                textbox.Location = new Point(500, 362);
                textbox.Font = new System.Drawing.Font("Times New Roman", 16);
                this.Controls.Add(textbox);
                foreach (Customer customer in customers)
                {
                    textbox.Text += i++ + "\t - \t" + customer.Name + "\t - \t" + customer.Point + '\r' + '\n';
                }
            }
            catch (Exception)
            {
                if (k == 0)
                {
                    MessageBox.Show("Database wasn't found");
                    k++;
                }
                Program.menu.Show();
                this.Hide();
            }



        }

        private void NameProgram_Paint(object sender, PaintEventArgs e)
        {
            ListRaiting_Shown();
        }

        
    }
}
