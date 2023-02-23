using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles.Clases;

using System.IO;
using System.Xml;
using System.Xml.Schema;
namespace Pruebas
{
    class Program: ConsolaBasica
    {
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo(@"C:\Users\Rene\Desktop\Nueva carpeta\contra.txt");
            cwl(f.Name);
            Console.ReadLine();

            XmlReader xml;
            XmlSchema xmls;
            XmlNode xmln;
            XmlDocument xmld;
            XmlAttribute xmla;
            //TreeNode tre
           // while (true) ;
        }


    }
}
