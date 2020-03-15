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
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
            this.Width = 1540;
            NameProgram.Left = this.Width / 2 - NameProgram.Width / 2;
            description.Left = this.Width / 2 - description.Width / 2;
            wish.Left = this.Width / 2 - wish.Width / 2;
            arrowLeft.Left = description.Right - 170;
            arrowTop.Left = arrowLeft.Right + 5;
            space.Left = description.Right - 50;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Program.menu.Show();
            this.Hide();
        }
    }
}
