using Paqueteria.abtrstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class LectorTxt : ILectorArchivo
    {
        string cRuta;

        public LectorTxt(string _cRuta)
        {
            this.cRuta = _cRuta;
        }

        public string[] LeerArchivo()
        {
            return System.IO.File.ReadAllLines(cRuta);
        }
    }
}
