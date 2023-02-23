using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeyenApps.ModificadorDeNombre
{
    [Serializable]
    class PalabraASustituir
    {
        string palabra,sustituto;
        public PalabraASustituir(string palabra,string sustituto) {
            this.palabra = palabra;
            this.sustituto = sustituto;
        }
       public string Palabra{
           get { return this.palabra; }
           set { this.palabra = value; }
        }
       public string Sustituto{
           get { return this.sustituto; }
           set { this.sustituto = value; }
       }
    }
}
