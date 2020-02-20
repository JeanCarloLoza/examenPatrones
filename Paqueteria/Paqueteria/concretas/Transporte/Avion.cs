using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.clases
{
    class Avion : IMedioTransporte
    {
        public Avion()
        {
            base.dCostoKM = 10;
            base.dVelocidadKM = 600;
            base.cNombre = "Avion";
        }
    }
}
