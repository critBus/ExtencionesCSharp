using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeyenApps.ModificarExtencion;
using ReneUtiles;
using System.IO;
using ReneUtiles.Clases.Archivo;

using ReneUtiles.VisualBasico.Clases.Dialogos;
using ReneUtiles.VisualBasico;

using LeyenApps.ModificadorDeNombre;
namespace Extenciones
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
            init();
            Text = "Extenciones";
            CommonDialog cmm;

            

           // appendTextoPalabra("uno","un");
            //md=ModificadorDeExtencion.ModificarDeExtencionesIMG()

            //System.Messaging.Design.QueuePathDialog
            //System.Windows.Forms.Design.FolderNameEditor.FolderBrowser.ShowDialog()
            //System.Windows.Forms.FileDialogCustomPlace
            //System.Windows.Forms.FolderBrowserDialog
           // FolderBrowserDialog fbr = new FolderBrowserDialog();
           // fbr.ShowDialog();
            //textBox1.Text = @"C:\1\Experimento\Nueva carpeta";
            //richTextBox1.Text = "One on";
            //seguridad();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }





       
        //Accesos Al Visual
        private bool estaSeleccionadoImagenes()
        {
            return radioButton1.Checked;
        }
        private bool estaSeleccionadoCarpetasInternas()
        {
            return checkBox1.Checked;
        }
        private bool estaSeleccionadoPW()
        {
            return radioButton2.Checked;
        }
        private bool estaSeleccionadoVideos()
        {
            return radioButton3.Checked;
        }
        private bool estaSeleccionadoPalabras()
        {
            return radioButton4.Checked;
        }
        private string getTextoPalabras() {
            return richTextBox1.Text;
        }
        private void clearTextoPalabra() {
            richTextBox1.Clear();
        }
        private void appendTextoPalabra(string palabra,string sustituto) {
            richTextBox1.AppendText(palabra + " " + sustituto + "\n");
        }

        //acceso a direcciones
        private DirectoryInfo getCarpeta()
        {
            return UtilesVisualBasico.getDirectoryInfo(textBox1);
        }
        //private FileInfo getArchivoPalabras()
        //{
        //    return VisualBasico.getFileInfo(textBox2);
        //}
        private bool hayUnaRutaValida()
        {
            return UtilesVisualBasico.tieneRutaValidaCarpeta(textBox1);
        }
        //private bool hayUnaRutaValidaCarpetaPalabras()
        //{
        //    return VisualBasico.tieneRutaValidaCarpeta(textBox2);
        //}
        //private bool hayUnaRutaValidaArchivoPalabras()
        //{
        //    return VisualBasico.tieneRutaValidaArchivo(textBox2);
        //}



        ModificadorDeExtencion md;
        ModificadorDeNombre mdN;
        DatosParaRecorridoDeCarpeta di;

        private void actualizarLogica() {
            if (hayUnaRutaValida())
            {
                if(di==null){
                    di = new DatosParaRecorridoDeCarpeta();
                }
                di.actualizar(getCarpeta(),estaSeleccionadoCarpetasInternas());
                if (estaSeleccionadoPalabras())
                {
                    if (mdN == null)
                    {
                        mdN = new ModificadorDeNombre(di);
                    }
                    mdN.Palabras = getPalabrasDeTexto();
                }
                else {
                    if (md == null)
                    {
                        md = new ModificadorDeExtencion(di);
                    }

                    if (estaSeleccionadoImagenes())
                    {
                        md.paraImagenes();
                    }
                    else
                    {
                        if (estaSeleccionadoPW())
                        {
                            md.paraPW();
                        }
                        else
                        {
                            if (estaSeleccionadoVideos())
                            {
                                md.paraVideos();
                            }
                        }

                    }
                }

                
                
            }
        }

        //private void actualizarMD()
        //{
        //    if (hayUnaRutaValida())
        //    {
        //        if (md == null)
        //        {
        //            if (estaSeleccionadoImagenes())
        //            {
        //                md = ModificadorDeExtencion.ModificarDeExtencionesIMG(getCarpeta());
        //            }
        //            else
        //            {
        //                md = ModificadorDeExtencion.ModificarDeExtencionesPW(getCarpeta());
        //            }
        //        }
        //        else
        //        {
        //            if (estaSeleccionadoImagenes())
        //            {
        //                md.paraImagenes();
        //            }
        //            else
        //            {
        //                md.paraPW();
        //            }
        //            md.Carpeta = getCarpeta();

        //        }
        //        md.RecorrerCarpetasInternas = estaSeleccionadoCarpetasInternas();
        //    }

        //}
        //private void actualizarMDN() { 
        //if(estaSeleccionadoPalabras()){
        //if(mdN==null){
        
        //}
        //}
        //}

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = hayUnaRutaValida() ? Color.Green : Color.Red;
            seguridad();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            procesoValidarPalabras();
            //richTextBox1.ForeColor = palbrasEnFormatoCorrepto() ? Color.Green : Color.Red;
           // seguridad();
        }
        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    textBox2.ForeColor = hayUnaRutaValidaCarpetaPalabras() ? Color.Green : Color.Red;
        //    seguridad();
        //}

        private void seguridad()
        {


            UtilesVisualBasico.setEnable(estaSeleccionadoPalabras() ? palbrasEnFormatoCorrepto() : hayUnaRutaValida(), button1, button2);
         //   VisualBasico.setEnable(hayUnaRutaValidaArchivoPalabras(), button3, button4);
        }

        private void procesoValidarPalabras()
        {
            richTextBox1.ForeColor = palbrasEnFormatoCorrepto() ? Color.Green : Color.Red;
            seguridad();
        }
        private void init()
        {
            seguridad();
        }

        private void activar() {
            
               
                
              
        }

        private metodoRealizar getMetodoActivar() {
            if (estaSeleccionadoPalabras())
            {
               return mdN.sustituirActivar;
           }
            else
            {
                return md.activar;
            }
        }

        private void showDlgSeActivo() {
            UtilesVisualBasico.showDlgAceptarInf("Activo");
        }

        //activar
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarLogica();
                UtilesVisualBasico.showProgresDlg(this, "Activando...", getMetodoActivar(),showDlgSeActivo);
                
            }
            catch (Exception ex)
            {
                UtilesVisualBasico.reponderException(ex, "Error");
            }
            
        }

        private metodoRealizar getMetodoDesactivar() {
            if (estaSeleccionadoPalabras())
            {
               return mdN.sustituirDesactivar;
                
            }
            else
            {
               return md.desactivar;
            }
        }
        private void showDlgSeDesactivo()
        {
            UtilesVisualBasico.showDlgAceptarInf("Se desactivo");
        }
        //desactivar
        private void button2_Click(object sender, EventArgs e)
        {
            try{
            actualizarLogica();
            //if (estaSeleccionadoPalabras())
            //{
            //    //Console.WriteLine("va a desactivar");
            //    mdN.sustituirDesactivar();
            //    //Console.WriteLine("desactivo");
            //}
            //else
            //{
            //    md.desactivar();
            //}
           // UtilesVisualBasico.showDlgAceptarInf("Desactivo");
            UtilesVisualBasico.showProgresDlg(this, "Desactivando...", getMetodoDesactivar(), showDlgSeDesactivo);
            }
            catch (Exception ex)
            {
                UtilesVisualBasico.reponderException(ex, "Error");
            }
            //actualizarMD();
           // md.desactivar();
        }


        private void loadPalabras(FileInfo f) {
            try
            {
                AlmacenDePalabras alm = (AlmacenDePalabras)Archivos.readObject(f.ToString());
                for (int i = 0; i < alm.Palabras.Length; i++)
                {
                    appendTextoPalabra(alm.Palabras[i].Palabra, alm.Palabras[i].Sustituto);
                }
                
            }
            catch (Exception ex)
            {
                UtilesVisualBasico.reponderException(ex, "Error al cargar el archivo");
            }
            procesoValidarPalabras();
        }

        
       
        //Load
        private void button3_Click(object sender, EventArgs e)
        {

            UtilesVisualBasico.showOpenFileDlgInit(loadPalabras, "Cargar Palabras", "Palabras", AlmacenDePalabras.EXTENCION);

            //Form1 f = new Form1();
            //Console.WriteLine("a");
            //    f.ShowDialog(this);
            //    Console.WriteLine("b");

                //f.Hide();
          //  DialogoInformacion dlg = new DialogoInformacion("titulo", "mensaje");
           // dlg.ShowDialog();
           
        }

       

        private class auxiliar_button4_Click {
            PalabraASustituir[] palabras;
            public auxiliar_button4_Click(PalabraASustituir[] palabras) {
                this.palabras = palabras;
            }
            
            public void crearSavePalabras(FileInfo f)
            {
                try
                {
                    AlmacenDePalabras.save(palabras, f.ToString());
                    UtilesVisualBasico.showDlgAceptarInf("Archivo creado");
                }
                catch (Exception ex)
                {
                    UtilesVisualBasico.reponderException(ex, "Error al crear el archivo");

                }
            }
        }

        //Save
        private void button4_Click(object sender, EventArgs e)
        {
           

            PalabraASustituir[] palabras = getPalabrasDeTexto();
            if (palabras == null)
            {
                UtilesVisualBasico.showDlgAceptarAdvertencia("Palabras mal formadas");
                return;
            }

            UtilesVisualBasico.showSaveFileDlgInit(new auxiliar_button4_Click(palabras).crearSavePalabras, "Guardar Palabras", "Palabras", AlmacenDePalabras.EXTENCION);

            
        }
        

        private PalabraASustituir[] getPalabrasDeTexto() {
            string texto = getTextoPalabras();
            //string[] palabras = texto.Split(' ', '\n');
            string[] palabras = Utiles.split(texto,' ', '\n');
            //Console.WriteLine(palabras.ToString());
            //UtilesConsola.cwl(palabras);
            int leng = palabras.Length;
           // Archivos.appenLogLn("leng=" + leng);
            if (leng==0||leng%2!=0)
            {
                return null;
            }
            PalabraASustituir[] res = new PalabraASustituir[leng / 2];
            
            for (int i = 0; i < leng; i+=2)
            {
                res[i / 2] = new PalabraASustituir(palabras[i],palabras[i+1]);
            }
            return res;
        }


        private bool palbrasEnFormatoCorrepto() {
            return getPalabrasDeTexto() != null;
        }

        private void cargarCarpetaPrincipal(DirectoryInfo f) {
            textBox1.Text = f.ToString();
            //seguridad();
        }

        //buscar Carpeta
        private void button5_Click(object sender, EventArgs e)
        {
            UtilesVisualBasico.showFolderBrowserDlg(cargarCarpetaPrincipal);
        }


        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            seguridad();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            seguridad();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            seguridad();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            seguridad();
        }

        
       

    }
}
