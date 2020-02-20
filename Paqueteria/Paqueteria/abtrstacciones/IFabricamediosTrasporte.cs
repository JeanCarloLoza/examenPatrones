using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    interface IFabricamediosTrasporte
    {
        public IMedioTransporte CreaMedioTrasporte();
    }
}
