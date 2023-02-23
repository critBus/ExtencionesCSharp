using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ReneUtiles;
namespace LeyenApps.ModificadorDeNombre
{
    [Serializable]
    class AlmacenDePalabras
    {
        public  const string EXTENCION_SIN_PUNTO = "ALM_P", EXTENCION = "." + EXTENCION_SIN_PUNTO;
        PalabraASustituir[] palabras;
        AlmacenDePalabras(PalabraASustituir[] palabras)
        {
            this.palabras = palabras;
        }

        public PalabraASustituir[] Palabras {
            get { return this.palabras; }
            set { this.palabras = value; }
        }

        public static AlmacenDePalabras load(string url)
        {
            return (AlmacenDePalabras)Archivos.readObject(url);
        }
        public  void save(string url) {
            
            Archivos.saveObject_ExtencionForzada(url,EXTENCION,this);
        }
        public void save(string urlParent,string nombre)
        {
            Archivos.saveObject_ExtencionForzada(urlParent,nombre,EXTENCION, this);
        }

        public static void save(PalabraASustituir[] p,string url) {
            AlmacenDePalabras alm = new AlmacenDePalabras(p);
            alm.save(url);
        }
        //public static void load(FileInfo f) { }
        //FileInfo direcionDeGuardado


    }
}
