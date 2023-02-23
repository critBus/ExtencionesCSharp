using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ReneUtiles.Clases.Tipos;
using ReneUtiles;
using ReneUtiles.Clases.IMG;
using ReneUtiles.Clases.PW;
using ReneUtiles.Clases.Archivo;
using ReneUtiles.Clases.Videos;

namespace LeyenApps.ModificarExtencion
{
    
     class ModificadorDeExtencion
    {
        //DirectoryInfo di;
        TipoDeExtencion[] tiposDeExtenciones;
        //bool recorrerCarpetasInternas;
        DatosParaRecorridoDeCarpeta dr;
        public ModificadorDeExtencion( DatosParaRecorridoDeCarpeta dr)
        {
            
            this.dr = dr;
        }
        public ModificadorDeExtencion(TipoDeExtencion[] tiposDeExtenciones, DatosParaRecorridoDeCarpeta dr)
        {
            this.tiposDeExtenciones = tiposDeExtenciones;
            this.dr = dr;
        }
        //public ModificadorDeExtencion(DirectoryInfo di, TipoDeExtencion[] tiposDeExtenciones,bool recorrerCarpetasInternas) {
        //    actualizar(di, tiposDeExtenciones, recorrerCarpetasInternas);
        //}

        //public bool RecorrerCarpetasInternas {
        //    get { return recorrerCarpetasInternas; }
        //    set { recorrerCarpetasInternas = value; }
        //}
        //public DirectoryInfo Carpeta {
        //    get { return di; }
        //    set { di = value; }
        //}

        public ModificadorDeExtencion paraImagenes()
        {
            tiposDeExtenciones = TipoDeImg.VALUES;
            return this;
        }
        public ModificadorDeExtencion paraPW()
        {
            tiposDeExtenciones = TipoDePW.VALUES;
            return this;
        }
        public ModificadorDeExtencion paraVideos()
        {
            tiposDeExtenciones = TipoDeVideo.VALUES;
            return this;
        }
        //public void actualizar(DirectoryInfo di, TipoDeExtencion[] tiposDeExtenciones, bool recorrerCarpetasInternas)
        //{
        //    this.di = di;
        //    this.tiposDeExtenciones = tiposDeExtenciones;
        //    this.recorrerCarpetasInternas = recorrerCarpetasInternas;
        //}
        public void actualizar(TipoDeExtencion[] tiposDeExtenciones, DatosParaRecorridoDeCarpeta dr)
        {
            this.tiposDeExtenciones = tiposDeExtenciones;
            this.dr = dr;
        }
        //protected virtual
        private  void desactivar(FileInfo f){
            int total=tiposDeExtenciones.Length;
            for (int i = 0; i < total; i++)
			{
                string extencion=Archivos.getExtencion(f);
               // string ex = tiposDeExtenciones[i].Extencion;
              //  string exd = tiposDeExtenciones[i].ExtencionDesactivada;
			     if (Utiles.iguales(extencion,tiposDeExtenciones[i].Extencion,true))
	                {
                        
                        Archivos.setExtencion(f, tiposDeExtenciones[i].ExtencionDesactivada);
                        return;
                 }
			}
            
       
        }
        private void activar(FileInfo f)
        {
            int total = tiposDeExtenciones.Length;
            for (int i = 0; i < total; i++)
            {
                string extencion = Archivos.getExtencion(f);

                if (Utiles.iguales(extencion, tiposDeExtenciones[i].ExtencionDesactivada, true))
                {
                    Archivos.setExtencion(f, tiposDeExtenciones[i].Extencion);
                    return;
                }
            }


        }
        //public void desactivar()
        //{
        //    Archivos.recorrerCarpeta(di, recorrerCarpetasInternas, desactivar);
        //}
        //public void activar()
        //{
        //    Archivos.recorrerCarpeta(di, recorrerCarpetasInternas, activar);
        //}

        //public static ModificadorDeExtencion ModificarDeExtencionesIMG(DirectoryInfo di)
        //{
        //    return new ModificadorDeExtencion(di, TipoDeImg.VALUES, false);
        //}
        //public static ModificadorDeExtencion ModificarDeExtencionesIMG(DirectoryInfo di, bool recorrerCarpetasInternas)
        //{
        //    return new ModificadorDeExtencion(di, TipoDeImg.VALUES, recorrerCarpetasInternas);
        //}
        //public static ModificadorDeExtencion ModificarDeExtencionesPW(DirectoryInfo di)
        //{
        //    return new ModificadorDeExtencion(di, TipoDePW.VALUES, false);
        //}
        //public static ModificadorDeExtencion ModificarDeExtencionesPW(DirectoryInfo di, bool recorrerCarpetasInternas)
        //{
        //    return new ModificadorDeExtencion(di, TipoDePW.VALUES, recorrerCarpetasInternas);
        //}


        public void desactivar(){
            Archivos.recorrerCarpeta(dr.Carpeta, dr.RecorrerCarpetasInternas, desactivar);
        }
        public void activar()
        {
            Archivos.recorrerCarpeta(dr.Carpeta, dr.RecorrerCarpetasInternas, activar);
        }

        public static ModificadorDeExtencion ModificarDeExtencionesIMG(DatosParaRecorridoDeCarpeta di)
        {
            return new ModificadorDeExtencion( TipoDeImg.VALUES,di);
         }

        public static ModificadorDeExtencion ModificarDeExtencionesPW(DatosParaRecorridoDeCarpeta di)
        {
            return new ModificadorDeExtencion( TipoDePW.VALUES, di);
        }
        public static ModificadorDeExtencion ModificarDeExtencionesVideos(DatosParaRecorridoDeCarpeta di)
        {
            return new ModificadorDeExtencion(TipoDeVideo.VALUES, di);
        }
        
    }
}
