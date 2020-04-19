using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{
    abstract class MemberOfTraffic
    {
        public delegate int AutoEvent(int index, ref MemberOfTraffic car);
        public static event AutoEvent MoveEvent;
        public Crossroad form = new Crossroad();
        protected Random random = new Random();
        private Random rnd = new Random();
        public MemberOfTraffic(int width, int lenght, int maxSpeed)
        {

            Width = width;
            this.length = lenght;
            int k = random.Next(-1, 2);

            int value = random.Next(1, 3);
            if (this is SpecCar)
            {
                value = rnd.Next(1, 15);
            }
            if (value == 1)
            {
                if (Crossroad.cross[0] + k > Crossroad.cross[3])
                {
                    Destination = 4;
                    Crossroad.cross[3]++;
                }
                else
                {
                    Destination = 1;
                    Crossroad.cross[0]++;
                }
            }
            else
            {

                if (Crossroad.cross[1] + k > Crossroad.cross[2])
                {
                    Destination = 3;
                    Crossroad.cross[2]++;
                }
                else
                {
                    Destination = 2;
                    Crossroad.cross[1]++;
                }
            }
            int color1 = random.Next(0, 256);
            int color2 = random.Next(0, 256);
            int color3 = random.Next(0, 256);
            color = Color.FromArgb(255, color1, color2, color3);
            speedMax = maxSpeed;
            speedNow = maxSpeed;

            Next = null;
            switch (Destination) //начальные кординаты в зависимости от направления движения
            {
                case 1:
                    x = form.Size.Width / 2 - 115;
                    y = 0;
                    break;
                case 2:
                    x = form.Size.Width;
                    y = form.Size.Height / 2 - 105;
                    break;
                case 3:
                    x = 0;
                    y = form.Size.Height / 2 + 115;
                    break;
                case 4:
                    x = form.Size.Width / 2 + 105;
                    y = form.Size.Height;
                    break;
            }
            speedDown = 1;
        }

        protected int Type;

        protected int x;
        protected int y;

        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        public int Width { get; private set; }
        protected int length;
        public int Length
        {
            get
            {
                return length;
            }
        } 

        protected int speedMax;
        public int MaxSpeed
        {
            get
            {
                return speedMax;
            }
        }
        protected int speedNow;
        public int SpeedNow
        {
            get
            {
                return speedNow;
            }
        }
        public int Destination { get; private set; } //направление 1..4
        protected Color color;
        private MemberOfTraffic next;
        protected Image img;
        protected Bitmap bmp;
        protected Graphics graphImg;
        private int speedDown;
        public MemberOfTraffic Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        public int DistanceToNext
        {
            get
            {
                if (this.Next != null)
                {
                    switch (Next.Destination)
                    {
                        case 1:
                            if (Next.y - Next.Length < 0)
                                return 0;
                            else return Next.y - Next.Length - this.y;
                        case 2:
                            if (Next.x + Next.Length > form.Width)
                                return 0;
                            else
                                return Math.Abs(Next.x + Next.Length - this.x);
                        case 3:
                            if (Next.x - Next.Length < 0)
                                return 0;
                            return Next.x - Next.Length - this.x;
                        case 4:
                            if (Next.y + Next.Length > form.Height)
                                return 0;
                            return Math.Abs(Next.y + Next.Length - this.y);
                        default:
                            return 40;
                    }
                }
                else return 40;
            }
        }
        protected int SpeedNext
        {
            get
            {
                return Next.SpeedNow;
            }
        }

        private void ChangeCoord()
        {
            switch (this.Destination)
            {
                case 1:
                    y += SpeedNow;
                    break;
                case 2:
                    x -= SpeedNow;
                    break;
                case 3:
                    x += SpeedNow;
                    break;
                case 4:
                    y -= SpeedNow;
                    break;
            }
        }
        public virtual void Ride()
        {
            int response;
            MemberOfTraffic member = this;
            //response = Crossroad.cross.SkipOrNot(this.Destination - 1, ref member);

            response = MoveEvent(this.Destination - 1, ref member);
            SpecCar existSpecCar = null;

            if (!(this is SpecCar) && Cross.cross.CountSpecCarAtTheLine1 > 0)
            {
                existSpecCar = Crossroad.cross.CheckExistSpecCar(this);
            }

            if (this is SpecCar || !(this is SpecCar) && (existSpecCar == null || existSpecCar.ChangeLine == 0))
            {
                switch (response)
                {
                    case 0:
                        this.speedNow = 0;
                        break;
                    case 1:
                    case 2:
                        if (this.SpeedNow == 0)
                        {
                            this.speedNow = this.MaxSpeed;
                        }
                        if (this.DistanceToNext <= 30 && this.SpeedNext <= this.SpeedNow)
                            this.speedNow = this.Next.SpeedNow;
                        if (this.SpeedNow != 0)
                            this.RemoveOwn(); //стереть 
                        int speed = this.SpeedNow;
                        if (this.DistanceToNext <= 30 && this.SpeedNext <= this.SpeedNow)
                        {
                            if (this.DistanceToNext <= 20 && this.SpeedNow > 5)
                            {
                                this.speedNow = this.Next.SpeedNow - 2;
                            }
                            if (this.DistanceToNext >= 20)
                            {
                                this.speedNow = this.Next.SpeedNow;
                            }

                        }
                        if (DistanceToNext >= 30)
                        {
                            this.speedNow = this.MaxSpeed;
                        }

                        ChangeCoord();

                        if ((this.SpeedNow == 0 && speed != 0) || this.SpeedNow != 0)
                            this.DrawOwn(); 
                        break;
                }
            }
            else
            {
                if (!(this is SpecCar) && existSpecCar != null && existSpecCar.ChangeLine == 1)
                {
                    this.speedNow = 0;
                }
            }
        }

        protected void Rotate(ref MemberOfTraffic car)
        {
            switch (this.Destination)
            {
                case 1:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 2:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 3:
                    break;
                case 4:
                    img.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
            }
        }
        public void DrawOwn()
        {
            //Rectangle r;
            SolidBrush brush = new SolidBrush(color);
            switch (this.Destination)
            {
                case 1:
                    Crossroad.graph.DrawImage(img, x, y - this.Length, img.Width, img.Height);
                    break;
                case 2:
                    Crossroad.graph.DrawImage(img, x, y, img.Width, img.Height);
                    break;
                case 3:
                    Crossroad.graph.DrawImage(img, x - this.Length, y - this.Width, img.Width, img.Height);
                    break;
                case 4:
                    Crossroad.graph.DrawImage(img, x - this.Width, this.y, img.Width, img.Height);
                    break;
                    //default:
                    //    r = new Rectangle();
                    //    break;
            }
            //r = new Rectangle(x, y - Length, car.Width, car.Length);
            brush.Dispose();
        }

        public void RemoveOwn()
        {
            Rectangle r;
            Brush brush = new SolidBrush(Color.DimGray);
            switch (this.Destination)
            {
                case 1:
                    r = new Rectangle(x, y - Length - 5, this.Width, this.Length + 5);
                    break;
                case 2:
                    r = new Rectangle(x, y, this.Length + 10, this.Width);
                    break;
                case 3:
                    r = new Rectangle(x - this.Length - 10, y - this.Width, this.Length + 10, this.Width);
                    break;
                case 4:
                    r = new Rectangle(x - Width, y - 5, this.Width, this.Length + 5);
                    break;
                default:
                    r = new Rectangle();
                    break;
            }

            Crossroad.graph.FillRectangle(brush, r);
            brush.Dispose();
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

