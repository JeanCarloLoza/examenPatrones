using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas.paqueteria
{
    class Fedex : IPaqueterias
    {
        public Fedex()
        {
            cNombre = "Fedex";
            dMargenUtilidad = 50;
            lstMediosTrasporte.Add(new Barco());
        }
    }
}
