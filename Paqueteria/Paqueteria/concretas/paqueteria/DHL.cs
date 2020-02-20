using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas.paqueteria
{
    class DHL : IPaqueterias
    {
        public DHL()
        {
            cNombre = "DHL";
            dMargenUtilidad = 40;
            lstMediosTrasporte.Add(new Avion());
            lstMediosTrasporte.Add(new Barco());
        }
    }
}
