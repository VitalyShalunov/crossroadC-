using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{
    class Circle
    {
        private int radius { get; }
		private int xPos, yPos;
        private int number;//порядковый номер
		public int color { get; set; }
		Color colorDraw;
		public Circle(int num, int x, int y)
		{
			radius = 23;
			number = num;
			color = 1;
			switch (number)
			{
				case 1:
					xPos = x;
					yPos = y;
					break;
				case 2:
					yPos = y;
					xPos = x;
					break;
				case 3:
					yPos = y;
					xPos = x;
					break;
				case 4:
					xPos = x;
					yPos = y;
					break;
			}
		}
		
		public void setPos(int next)
		{
			int kUmn;
			if (next>0) // -> зеленый
			{
				kUmn = 1;
			}
			else
			{
				kUmn = -1;
			}
			switch (number)
			{
				case 1:
					yPos = yPos - kUmn * 52;
					break;
				case 2:
					xPos = xPos + kUmn * 52;
					break;
				case 3:
					xPos = xPos - kUmn * 52;
					break;
				case 4:
					yPos = yPos + kUmn * 52;
					break;
				default:
					break;
			}
		}
		public void drawCircle()
		{
			switch (this.color)
			{
				case 1:
					colorDraw = Color.FromArgb(255, 0, 0); //красный 
					break;
				case 2:
					colorDraw = Color.FromArgb(232, 228, 19); //желтый
					break;
				case 3:
					colorDraw = Color.FromArgb(92, 196, 27); //зеленый
					break;
			}
			SolidBrush brush = new SolidBrush(colorDraw);
			Crossroad.graphTL.FillEllipse(brush, xPos - radius, yPos - radius, 2 * radius, 2 * radius);
			brush.Dispose();
		}
		public void clearCircle()
		{
			colorDraw = Color.FromArgb(255, 60, 50, 60);
			SolidBrush brush = new SolidBrush(colorDraw);
			Crossroad.graphTL.FillEllipse(brush, xPos - radius, yPos - radius, 2 * radius, 2 * radius);
			brush.Dispose();
		}
	}
}
