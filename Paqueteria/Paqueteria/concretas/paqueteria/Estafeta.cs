using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas.paqueteria
{
    class Estafeta : IPaqueterias
    {
        public Estafeta()
        {
            cNombre = "Estafeta";
            dMargenUtilidad = 20;
            lstMediosTrasporte.Add(new Barco());
            lstMediosTrasporte.Add(new Tren());
        }
    }
}
