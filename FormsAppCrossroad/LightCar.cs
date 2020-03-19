using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppCrossroad
{
    class LightCar : MemberOfTraffic
    {
        private string pathFile = "img/light_car";
        public LightCar() : base(55, 80, 7)
        {
            //PictureBox pictureBox = new PictureBox();

            //pathFile += random.Next(1, 7).ToString();
            //pathFile += ".png";
            //img = Image.FromFile(pathFile);

            switch (random.Next(1, 7))
            {
                case 1:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.light_car1);
                    break;
                case 2:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.light_car2);
                    break;
                case 3:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.light_car3);
                    break;
                case 4:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.light_car4);
                    break;
                case 5:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.light_car5);
                    break;
                case 6:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.light_car6);
                    break;
            }
            MemberOfTraffic own = this;
            Rotate(ref own);

        }
    }
}
