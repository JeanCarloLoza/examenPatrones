using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.clases
{
    class Barco : IMedioTransporte
    {
        public Barco()
        {
            base.dCostoKM = 1;
            base.dVelocidadKM = 46;
            base.cNombre = "Barco";
        }

    }
}
