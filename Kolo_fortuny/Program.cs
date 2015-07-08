using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Kolo_fortuny
{
    static class Program
    {
  
       

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //haselko.pole = pole;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 okienko = new Form1();
            Application.Run(okienko);

           // new Literka();
        }
    }
}
