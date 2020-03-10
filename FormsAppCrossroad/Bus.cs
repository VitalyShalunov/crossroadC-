using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{
    
    class Bus : MemberOfTraffic
    {
        private string pathFile = "img/bus";
        public Bus() : base(60, 110, 5)
        {
            //pathFile += random.Next(1, 3).ToString();
            //pathFile += ".png";
            //img = Image.FromFile(pathFile);
            switch (random.Next(1,3))
            {
                case 1:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.bus1);
                    break;
                case 2:
                    img = new Bitmap(FormsAppCrossroad.Properties.Resources.bus2);
                    break;
            }
            
            MemberOfTraffic own = this;
            Rotate(ref own);
        }
    }
}
