using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class GeneradorAvion : IFabricamediosTrasporte
    {
        public IMedioTransporte CreaMedioTrasporte()
        {
            return new Avion();
        }
    }
}
