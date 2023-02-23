using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using ReneUtiles;
using ReneUtiles.Clases;
namespace Extenciones
{
    static class Program 
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //FileInfo f = new FileInfo(@"D:\Rene\Programacion\Proyectos\C#\Extenciones\Extenciones\bin\Debug\ReneUtiles.dll");
           // Console.WriteLine(Archivos.getNombre(f));
            //Console.WriteLine("abc"!="cbc");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());

           
           
        }

       
    }
}
