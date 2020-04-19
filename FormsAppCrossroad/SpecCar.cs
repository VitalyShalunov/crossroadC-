using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{
	class SpecCar : MemberOfTraffic
	{
		private int trigger = 0;
		private Random rnd = new Random();
		private string pathFile = "img/spec_car";
		public delegate int SpecEvent(ref MemberOfTraffic car);
		public static event SpecEvent MoveSpecEvent;
		public SpecCar() : base(55, 80, 8)
		{
			switch (random.Next(1, 4))
			{
				case 1:
					img = new Bitmap(FormsAppCrossroad.Properties.Resources.spec_car1);
					break;
				case 2:
					img = new Bitmap(FormsAppCrossroad.Properties.Resources.spec_car2);
					break;
				case 3:
					img = new Bitmap(FormsAppCrossroad.Properties.Resources.spec_car3);
					break;
			}
			MemberOfTraffic own = this;
			Rotate(ref own);
			int color1, color2, color3;
			switch (random.Next(0, 3))
			{
				case 0:
					color1 = 189;
					color2 = 21;
					color3 = 21;
					break;
				case 1:
					color1 = 247;
					color2 = 240;
					color3 = 240;
					break;
				case 2:
					color1 = 35;
					color2 = 62;
					color3 = 196;
					break;
				default:
					color1 = 189;
					color2 = 21;
					color3 = 21;
					break;
			}
			color = Color.FromArgb(255, color1, color2, color3);
			
			switch (Destination) //начальные кординаты в зависимости от направления движения
			{
				case 1:
					x = form.Size.Width / 2 - Width / 2;
					y = 15;
					speedMax = 5;
					speedNow = MaxSpeed;
					break;
				case 2:
					x = form.Size.Width - 15;
					y = form.Size.Height / 2 - Width / 2;
					speedMax = 8;
					speedNow = MaxSpeed;
					break;
				case 3:
					x = 15;
					y = form.Size.Height / 2 + Width / 2;
					speedMax = 8;
					speedNow = MaxSpeed;
					break;
				case 4:
					x = form.Size.Width / 2 + Width / 2;
					y = form.Size.Height - 15;
					speedMax = 4;
					speedNow = MaxSpeed;
					break;
			}
			//MaxSpeed += 4;
			ChangeLine = 0;
			CheckSetLink = 1;

			Crossroad.changeLine += new Crossroad.ChangeLine(ChangePropertyAtTheSpecCar);
		}
		public int ChangeLine { get; private set; }
		public int CheckSetLink { get; private set; }
		void SetSpeed()
		{
			if (this.Next != null && this.Next.SpeedNow <= SpeedNow && this.DistanceToNext < 30)
			{
				if (DistanceToNext < 10)
				{
					this.speedNow = 0;
				}
				else
				{
					if (DistanceToNext < 20 && Next.SpeedNow != 0 && SpeedNow != 0)
					{
						if (this.DistanceToNext <= 20 && this.SpeedNow >= 5)
						{
							this.speedNow = this.Next.SpeedNow - 2;
						}
						if (this.DistanceToNext >= 20 )
						{
							this.speedNow = this.Next.SpeedNow;
						}
						if (DistanceToNext >= 30)
						{
							this.speedNow = this.MaxSpeed;
						}
					}
					else
					{
						speedNow = Next.SpeedNow;
					}
				}
			}
			else speedNow = MaxSpeed;
		}
		public override void Ride()
		{
			int checkCoord;

			SetSpeed();

			switch (ChangeLine)
			{
				case 0:
					//if (DistanceToNext > 30)
					//{
					//	speedNow = MaxSpeed;
					//}
					checkCoord = CheckCoord();
					if (AtTheLine == 2 && checkCoord == 1)
					{
						//ChangeLine = 1;
						ChangePropertyAtTheSpecCar();
					}
					base.Ride();
					break;
				case 1:
					if (AtTheLine != 1)
					{
						int answer = 0;
						answer = Crossroad.cross.CanChangeLine(this);
						checkCoord = CheckCoord();
						if (answer == 1)
						{
							if (CheckSetLink == 1)
							{
								SpecCar car = this;

								int res = Crossroad.cross.SetLinkIfSpecCarChangeLines(ref car, 1);
								CheckSetLink = 0;
								if (res == 0)
								{
									this.Next = Crossroad.cross.CheckLast(ref car);
								}
								
							}
							SetSpeed();
						
							RideOwn(1);
						}
						else
						{
							base.Ride();
						}

					}
					if (AtTheLine == 1)
					{
						if (trigger == 1)
						{
							trigger = 0;
							Cross.cross.CountSpecCarAtTheLine1--;
						}

						speedNow = MaxSpeed;
						var answer = Crossroad.cross.DistanceToSpecCar(this);
						checkCoord = CheckCoord();
						if (answer == 2000 && checkCoord != 1)
						{
							ChangeLine = 2;
						}
						else
						{
							ChangeLine = 0;
						}
					}
					break;
				case 2:
					if (AtTheLine != 2)
					{
						var answer = Crossroad.cross.DistanceToSpecCar(this);
						checkCoord = CheckCoord();
						if (answer > 600 && answer < 2000 || checkCoord == 1)
						{
							ChangeLine = 1;
						}
						//if (DistanceToNext < 30)
						//{
						//	speedNow = Next.SpeedNow;
						//	if (DistanceToNext < 15)
						//	{
						//		speedNow = Next.SpeedNow;
						//	}
						//}
						SetSpeed();

						RideOwn(0);
					}
					else
					{

						base.Ride();
					}
					checkCoord = CheckCoord();
					if (AtTheLine == 2)
					{
						SpecCar car = this;
						Crossroad.cross.SetLinkIfSpecCarChangeLines(ref car, 0);
						CheckSetLink = 1;
						speedNow = MaxSpeed;
						ChangeLine = 0;
					}
					break;
			}
		}

		private void ChangePropertyAtTheSpecCar()
		{
			this.ChangeLine = 1;
			this.CheckSetLink = 1;
			Cross.cross.CountSpecCarAtTheLine1++;
			trigger = 1;

		}

		void RideOwn(int inout)
		{
			int response = 0;
			MemberOfTraffic member = this;
			int middle = Crossroad.cross.AboutMiddle(ref member);
			if (middle == 0)
			{
				response = MoveSpecEvent(ref member);
			}
			else response = 1;
			//response = Crossroad.cross.SkipOrNot(this.Destination - 1, ref member);
			//response = MemberOfTraffic.MoveEvent(this.Destination - 1, ref member);
			if (response != 0)
			{
				RemoveOwn();
				if (inout == 1)
					ChangeCoordInLine();
				else
					ChangeCoordOutLine();
				DrawOwn();
			}
		}
		int CheckCoord()
		{
			switch (Destination)
			{
				case 1:
					if (y >= form.Height / 2 + 50)
						return 1;
					break;
				case 2:
					if (x <= form.Width / 2 - 100)
						return 1;
					break;
				case 3:
					if (x >= form.Width / 2 + 100)
						return 1;
					break;
				case 4:
					if (y <= form.Height / 2 - 50)
						return 1;
					break;
				default:
					break;
			}
			return 0;
		}
		void ChangeCoordOutLine()
		{
			if (DistanceToNext < 30)
			{
				speedNow = Next.SpeedNow;
			}
			switch (Destination)
			{

				case 1:
					x += 2;
					y += SpeedNow;
					break;
				case 2:
					y += 2;
					x -= SpeedNow;
					break;
				case 3:
					y -= 2;
					x += SpeedNow;
					break;
				case 4:
					x -= 2;
					y -= SpeedNow;
					break;
				default:
					break;
			}
		}
		void ChangeCoordInLine()
		{
			var distance = Crossroad.cross.DistanceToSpecCar(this);
			int speed = 2;
			if (distance < 1000)
			{
				speed += 2;
				if (distance < 500)
				{
					speed += 4;
				}
			}

			switch (Destination)
			{
				case 1:
					x -= speed;
					y += SpeedNow;
					break;
				case 2:
					y -= speed;
					x -= SpeedNow;
					break;
				case 3:
					y += speed;
					x += SpeedNow;
					break;
				case 4:
					x += speed;
					y -= SpeedNow;
					break;
				default:
					break;
			}
		}
		public int AtTheLine
		{
			get
			{
				switch (this.Destination)
				{
					case 1:
						if (x <= form.Width / 2 - 115)
							return 1;
						else
							if (x == form.Width / 2 - Width / 2)
							return 2;
						else
							return 0;
					case 2:
						if (y <= form.Height / 2 - 105)
							return 1;
						else
							if (y == form.Height / 2 - Width / 2)
							return 2;
						else
							return 0;
					case 3:
						if (y >= form.Height / 2 + 115)
							return 1;
						else
							if (y == form.Height / 2 + Width / 2)
							return 2;
						else
							return 0;
					case 4:
						if (x >= form.Width / 2 + 105)
							return 1;
						else
							if (x == form.Width / 2 + Width / 2)
							return 2;
						else
							return 0;
				}
				return 0;
			}
			set
			{
				AtTheLine = value;
			}
		}

	}
}
