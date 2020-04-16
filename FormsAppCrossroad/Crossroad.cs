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
    partial class Crossroad : Form
    {
        protected static int check { get; set; }
        static int count = 0;
       
       // protected int click { get; set; }
        protected static int total { get; set; }
        protected int c = 1;
        protected static int reason;

        public delegate void ActionTrafficLight();
        public static event ActionTrafficLight ChangeTrafficLight14;
        public static event ActionTrafficLight ChangeTrafficLight23;

        public delegate void ChangeLine();
        public static event ChangeLine changeLine;

        protected static Graphics g;
        private static Graphics graphCross;
        public static Graphics graph
        {
            get
            {
                return graphCross;
            }
            private set
            {
                graphCross = value;
            }
        }

        private static Graphics graphforTL;
        public static Graphics graphTL
        {
            get
            {
                return graphforTL;
            }
            private set
            {
                graphforTL = value;
            }
        }
        public static Cross cross;
        protected static MemberOfTraffic carStop1, carStop2, carStop3, carStop4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cross != null)
                cross.TimerTrafficJam(1, carStop1);
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cross != null)
                cross.TimerTrafficJam(2, carStop2);
            timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (cross != null)
                cross.TimerTrafficJam(3, carStop3);
            timer3.Stop();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if(cross!=null)
                cross.TimerTrafficJam(4, carStop4);
            timer4.Stop();
        }

        private void timerGame_Tick_1(object sender, EventArgs e)
        {
            if (count == 0)
            {
                cross = new Cross();
                //cross.PaintTraffic();
                count++;
            }
            if (check == 1)
                cross.PerformMove();
            else
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timerGame.Stop();
            cross = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Program.menu.totalPoint = total;
            switch (reason)
            {
                case 1:
                    Program.menu.reason.Text = "Пробка сверху";
                    break;
                case 2:
                    Program.menu.reason.Text = "Пробка справа";
                    break;
                case 3:
                    Program.menu.reason.Text = "Пробка слева";
                    break;
                case 4:
                    Program.menu.reason.Text = "Пробка снизу";
                    break;
                case 5:
                    Program.menu.reason.Text = "Авария";
                    break;
            }
            if (Program.menu.bestSession < total)
            {
                Program.menu.bestSession = total;
            }
            Thread myThread = new Thread(new ThreadStart(UpdatePointOfCustomer));
            myThread.Start();
            Program.menu.Show();
            this.Hide();
        }

        private void UpdatePointOfCustomer()
        {
            try
            {
                Customer Customer = Program.db.Customers.FirstOrDefault(customer => customer.Name == Program.menu.userName.Text);
                if (Customer != null)
                {
                    if (Customer.Point < total)
                    {
                        Customer.Point = total;
                        Program.menu.bestcustomer.Text = "Your best : " + Customer.Point;
                        Program.db.SaveChanges();
                    }
                }
                else
                {
                    var newCustomer = new Customer()
                    {
                        Name = Program.menu.userName.Text,
                        Point = total
                    };
                    Program.db.Customers.Add(newCustomer);
                    Program.db.SaveChanges();
                }

            }
            catch (Exception)
            {

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            graphTL = Graphics.FromHwnd(pictureBox1.Handle);
            graph = Graphics.FromHwnd(pictureBox1.Handle);
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            
           
            timerGame.Start();
        }

        public Crossroad()
        {
            InitializeComponent();
            this.Width = 1540;
        }
        private async Task ChangeColor14()
        {
            //await Task.Run(() => cross.trafficLight1.changeColor());
            //await Task.Run(() => cross.trafficLight4.changeColor());
            await Task.Run(() => ChangeTrafficLight14());
        }
        private async Task ChangeColor23()
        {
            //await Task.Run(() => cross.trafficLight2.changeColor());
            //await Task.Run(() => cross.trafficLight3.changeColor());
            await Task.Run(() => ChangeTrafficLight23());
        }
        private void Crossroad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ChangeColor14();
            }
            if (e.KeyCode == Keys.Left)
            {
                ChangeColor23();
            }
            if (e.KeyCode == Keys.Space)
            {
                try
                {
                    changeLine();
                }
                catch (Exception)
                {
                }
               
                //cross.ChangePropertyAtTheSpecCar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timerGame.Stop();
                Program.menu.totalPoint = total;
                if (Program.menu.bestSession < total)
                {
                    Program.menu.bestSession = total;
                }
                Program.menu.Show();
                this.Hide();
            }
        }

        private void Crossroad_Load(object sender, EventArgs e)
        {
            check = 1;
            //click = 0;
            total = 0;
            count = 0;
        }
    }
}
