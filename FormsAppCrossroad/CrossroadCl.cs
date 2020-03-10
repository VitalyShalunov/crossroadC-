using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{

    class CrossroadCl
    {
        private List<MemberOfTraffic> memberOfTraffics = new List<MemberOfTraffic>();
        CrossroadCl()
        {
            int sovp = 0; //если автомобили наседают друг на друга
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
            suda:
                if (sovp==1)
                {
                    memberOfTraffics.RemoveAt(1);
                    sovp = 0;
                    i--;
                }
                switch (random.Next(1,5))
                {
                    case 1:
                        memberOfTraffics.Insert(i, new LightCar());
                        break;
                    case 2:
                        memberOfTraffics.Insert(i, new Bus());
                        break;
                    case 3:
                        memberOfTraffics.Insert(i, new Truck());
                        break;
                    case 4:
                        memberOfTraffics.Insert(i, new SpecialCar());
                        if (i == 1)
                        {
                            if (memberOfTraffics[1].Type == memberOfTraffics[0].Type)
                            {
                                switch (memberOfTraffics[1].Destination)
                                {
                                    case 1:
                                        if (memberOfTraffics[0].Destination != 1)
                                            sovp = 1;
                                        break;
                                    case 2:
                                        if (memberOfTraffics[0].Destination != 2)
                                            sovp = 1;
                                        break;
                                    case 3:
                                        if (memberOfTraffics[0].Destination != 3)
                                            sovp = 1;
                                        break;
                                    case 4:
                                        if (memberOfTraffics[0].Destination != 4)
                                            sovp = 1;
                                        break;
                                }
                                if (sovp == 1)
                                    goto suda;
                            }
                        }
                        break;
                }
            }
            if (memberOfTraffics[1].Type == 4 && memberOfTraffics[0].Type == 4)
            {
                if (memberOfTraffics[1].Destination == memberOfTraffics[0].Destination)
                {
                    obj[1]->setnext(obj[0]);
                    if (obj[1]->getdistance_to_next() < 30)
                        sovp = 1;
                }
            }
            else
                if (obj[1]->gettype() != 4 && obj[0]->gettype() != 4)
                if (obj[1]->getdestination() == obj[0]->getdestination())
                {
                    obj[1]->setnext(obj[0]);
                    if (obj[1]->getdistance_to_next() < 30)
                        sovp = 1;
                }
            if (sovp == 1)
                goto suda;
        }


        private int kolavto = 2, kontspec = 1, kontavto = 1;//проверка, встретятся ли на одном пути спец.транспорты
        public int kolstop1, kolstop2, kolstop3, kolstop4; //количество машин, остановившиеся на перекрёстке в определнном направлении

    }
    public abstract class MemberOfTraffic
    {
        public MemberOfTraffic(int Width, int Length)
        {
            this.Width = Width;
            this.Length = Length;
            this.next = null;
            if (random.Next(1, 7) == 1)
            {
                this.Destination = 1;
            }
            else
           if (random.Next(1, 8) == 1)
                this.Destination = 4;
            else
                this.Destination = random.Next(1, 3);

            this.color1 = random.Next(0, 256);
            this.color2 = random.Next(0, 256);
            this.color3 = random.Next(0, 256);

            switch (this.Destination) //начальные кординаты в зависимости от направления движения
            {
                case 1:
                    this.X = form.Width / 2 - 105 + this.Width;
                    this.Y = 15;
                    break;
                case 2:
                    this.X = form.Width - 15;
                    this.Y = form.Height / 2 - 105;
                    break;
                case 3:
                    this.X = 15;
                    this.Y = form.Height / 2 + 105;
                    break;
                case 4:
                    this.X = form.Width / 2 + 105 - this.Width;
                    this.Y = form.Height - 15;
                    break;
            }
        }
        protected MemberOfTraffic getNext()
        {
            return this.next;
        }

        protected void setnext(MemberOfTraffic next)
        {
            this.next = next;
        }

        public void ride()
        {
            switch (this.Destination)
            { //в зависимости от направления
                case 1:
                    crossroadCl.skip_or_not(light1, this);
                    break;
                case 2:
                    crossroadCl.skip_or_not(light2, this);
                    break;
                case 3:
                    crossroadCl.skip_or_not(light3, this);
                    break;
                case 4:
                    crossroadCl.skip_or_not(light4, this);
                    break;
            }
        }

        protected int getDistanceToNext
        {
            get
            {

                if (this.next != null)
                {
                    switch (next.Destination)
                    {
                        case 1:
                            if (next.Y - next.Length < 0)
                                return 0;
                            else return next.Y - next.Length - this.Y;
                        case 2:
                            if (next.X + next.Length > form.Width)
                                return 0;
                            else
                                return Math.Abs(next.X + next.Length - this.X);
                        case 3:
                            if (next.X - next.Length < 0)
                                return 0;
                            return next.X - next.Length - this.X;
                        case 4:
                            if (next.Y + next.Length > form.Height)
                                return 0;
                            return Math.Abs(next.Y + next.Length - this.Y);
                        default:
                            return 40;
                    }
                }
                else return 40;
            }
        }

        protected int getspeednext(MemberOfTraffic next)
        {
            return next.SpeedNow;
        }

        public int Type { get; set; }
        protected int color1, color2, color3; //увет участника движения
        protected int X { get; set; }
        protected int Y { get; set; } //координаты 
        protected int Width { get; set; }
        protected int Length { get; set; }//ширина и длина
        protected int MaxSpeed { get; set; } //макимальная скорость
        protected int SpeedNow { get; set; } //скорость в данный момент
        public int Destination { get; set; } //направление 1..4

        protected Random random = new Random();

        public ref MemberOfTraffic Next(ref);

        protected Crossroad form = new Crossroad();
       
        public abstract void DrawOwn();
        public abstract void RemoveOwn();
    }


    public class LightCar : MemberOfTraffic
    {
        public LightCar() : base(55, 80)
        {
            this.Type = 1;
            this.SpeedNow = 7;
            this.MaxSpeed = 7;
        }
        public override void DrawOwn()
        {

        }
        public override void RemoveOwn()
        {

        }
    }

    class Bus : MemberOfTraffic
    {

        public Bus() : base(60, 110)
        {
            this.Type = 2;
            this.SpeedNow = 5;
            this.MaxSpeed = 5;
        }

        public override void DrawOwn()
        {

        }
        public override void RemoveOwn()
        {

        }
    }

    class Truck : MemberOfTraffic
    {
        public Truck() : base(70, 100)
        {
            this.Type = 3;
            this.SpeedNow = 6;
            this.MaxSpeed = 6;
        }
        public override void DrawOwn()
        {

        }
        public override void RemoveOwn()
        {

        }
    }

    class SpecialCar : MemberOfTraffic
    {
        public SpecialCar() : base(55, 80)
        {
            this.Type = 4;
            this.SpeedNow = 6;
            this.MaxSpeed = 6;
            switch (random.Next(0, 5))
            {
                case 0:
                    this.color1 = 189;
                    this.color2 = 21;
                    this.color3 = 21;
                    break;
                case 1:
                    this.color1 = 247;
                    this.color2 = 240;
                    this.color3 = 240;
                    break;
                case 2:
                    this.color1 = 35;
                    this.color2 = 62;
                    this.color3 = 196;
                    break;
            }
            switch (this.Destination) //начальные кординаты в зависимости от направления движения
            {
                case 1:
                    this.SpeedNow = 5;
                    break;
                case 2:
                case 3:
                    this.SpeedNow = 8;
                    break;
                case 4:
                    this.SpeedNow = 4;
                    break;
            }
        }
        public override void DrawOwn()
        {

        }
        public override void RemoveOwn()
        {

        }
    }
}

