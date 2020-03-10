using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAppCrossroad
{
    class Truck : MemberOfTraffic
    {
        private string pathFile = "img/truck";
        public Truck() : base(70, 100, 6)
        {
            img = new Bitmap(FormsAppCrossroad.Properties.Resources.truck1);
            MemberOfTraffic own = this;
            Rotate(ref own);
        }
    }
}
