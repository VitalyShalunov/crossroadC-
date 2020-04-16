using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{
    class TrafficLight
    {
        private Rectangle rectangle;
        int Number;
        public int color { get; set; }
        Circle circle;
        public TrafficLight(int num)
        {
            Number = num;
            color = 1;
            int lenx, leny;
            if (num == 1 || num == 4)
            {
                Crossroad.ChangeTrafficLight14 += new Crossroad.ActionTrafficLight(Crossroad_ChangeColor);
            }
            else
            {
                Crossroad.ChangeTrafficLight23 += new Crossroad.ActionTrafficLight(Crossroad_ChangeColor);
            }
            using (var form = new Crossroad())
            {
                switch (num)//формируем координаты светофоров
                {
                    case 1:
                        lenx = -200;
                        leny = -250;
                        rectangle = new Rectangle((form.Size.Width / 2) - 37 + lenx, (form.Size.Height / 2) + leny - 82, 74, 164);
                        circle = new Circle(Number, (rectangle.Left + rectangle.Right) / 2, rectangle.Bottom - 7 - 23);
                        break;
                    case 2:
                        lenx = 250;
                        leny = -200;
                        rectangle = new Rectangle(form.Size.Width / 2 - 82 + lenx, form.Size.Height / 2 + leny - 37, 164, 74);
                        circle = new Circle(Number, rectangle.Left + 7 + 23, (rectangle.Top + rectangle.Bottom) / 2);
                        break;
                    case 3:
                        lenx = -250;
                        leny = 200;
                        rectangle = new Rectangle(form.Size.Width / 2 - 82 + lenx, form.Size.Height / 2 + leny - 37, 164, 74);
                        circle = new Circle(Number, rectangle.Right - 7 - 23, (rectangle.Top + rectangle.Bottom) / 2);
                        break;
                    case 4:
                        lenx = 200;
                        leny = 250;
                        rectangle = new Rectangle(form.Size.Width / 2 - 37 + lenx, form.Size.Height / 2 + leny - 82, 74, 164);
                        circle = new Circle(Number, (rectangle.Left + rectangle.Right) / 2, rectangle.Top + 7 + 23);
                        break;
                }
            }
            //drawOwn();
        }
        public void drawOwn()
        {
            Color color = Color.FromArgb(255, 0, 0, 0);
            SolidBrush brush = new SolidBrush(color);
            Crossroad.graphTL.FillRectangle(brush, rectangle);
            brush.Dispose();

            rectangle = new Rectangle(rectangle.Left + 5, rectangle.Top + 5, rectangle.Width - 10, rectangle.Height - 10);
            color = Color.FromArgb(255, 60,50,60);
            brush = new SolidBrush(color);
            Crossroad.graphTL.FillRectangle(brush, rectangle);
            brush.Dispose(); 
            circle.drawCircle();
        }

        void Crossroad_ChangeColor()
        {
            if (color == 1)
            {
                for (int i = 2; i <= 3; i++)
                {
                    circle.color = i;
                    circle.clearCircle();
                    circle.setPos(1);
                    circle.drawCircle();
                }
                this.color = 3;
            }
            else
            {
                for (int i = 2; i >= 1; i--)
                {
                    circle.color = i;
                    circle.clearCircle();
                    circle.setPos(0);
                    circle.drawCircle();
                }
                this.color = 1;
            }
        }
        public void changeColor()
        {
            if (color == 1)
            {
                for (int i = 2; i <= 3; i++)
                {
                    circle.color = i;
                    circle.clearCircle();
                    circle.setPos(1);
                    circle.drawCircle();
                }
                this.color = 3;
            }
            else
            {
                for (int i = 2; i >= 1; i--)
                {
                    circle.color = i;
                    circle.clearCircle();
                    circle.setPos(0);
                    circle.drawCircle();
                }
                this.color = 1;
            }
        }

        internal Cross Cross
        {
            get => default;
            set
            {
            }
        }
    }
}
