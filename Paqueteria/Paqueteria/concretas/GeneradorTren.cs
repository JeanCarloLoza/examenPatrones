using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class GeneradorTren : IFabricamediosTrasporte
    {
        public IMedioTransporte CreaMedioTrasporte()
        {
            return new Tren();
        }
    }
}