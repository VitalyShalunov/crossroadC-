using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppCrossroad
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static Menu menu;
        public static MyDbContext db;
        static void Main()
        {
            db = new MyDbContext();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(menu = new Menu());
        }
        
    }
}
