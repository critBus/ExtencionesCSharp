using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ReneUtiles.Clases.Archivo;
using ReneUtiles;

namespace LeyenApps.ModificadorDeNombre
{
    class ModificadorDeNombre
    {
        DatosParaRecorridoDeCarpeta di;
        PalabraASustituir[] palabras;

        public ModificadorDeNombre(DatosParaRecorridoDeCarpeta di)
        {
            this.di = di;
            
        }
        public ModificadorDeNombre(DatosParaRecorridoDeCarpeta di, PalabraASustituir[] palabras) {
            this.di = di;
            this.palabras = palabras;
        }

        public  PalabraASustituir[] Palabras{
            get { return this.palabras; }
            set { this.palabras = value; }
        }

        private void sustituir(FileInfo f,bool activar) {
            string nombreOriginal = Archivos.getNombre(f);
            string nombreResultante = nombreOriginal;
            int leng = palabras.Length;
            for (int i = 0; i < leng; i++)
            {
                string original=!activar?palabras[i].Palabra:palabras[i].Sustituto;
                string sustituto=!activar?palabras[i].Sustituto:palabras[i].Palabra;
                //Console.WriteLine("original="+original);
               // Console.WriteLine("sustituto=" + sustituto);
               // Console.WriteLine("nombreResultante0=" + nombreResultante);
                nombreResultante=nombreResultante.Replace(original, sustituto);
               // Console.WriteLine("nombreResultante1=" + nombreResultante);
            }
            if(nombreResultante!=nombreOriginal){
                Archivos.renombrar_SinExtencion(f, nombreResultante);
            }
        }

        private void sustituirActivar(FileInfo f)
        {
            sustituir(f, true);
        }
        private void sustituirDesactivar(FileInfo f)
        {
            sustituir(f, false);
        }

        public void sustituirActivar() {
            Archivos.recorrerCarpeta(di.Carpeta, di.RecorrerCarpetasInternas, sustituirActivar);
        }
        public void sustituirDesactivar()
        {
            Archivos.recorrerCarpeta(di.Carpeta, di.RecorrerCarpetasInternas, sustituirDesactivar);
        }

    }
}
