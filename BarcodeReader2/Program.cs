using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeReader2
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //int w = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width.ToString())*2/3;
            //int h = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height.ToString())*2/3;
            

            //Form1 f = new Form1();

            //f.Size = new Size(w, h);


            Application.Run(new Form1());
        }
    }
}
