using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.clases
{
    class Tren : IMedioTransporte
    {
        public Tren()
        {
            base.dCostoKM = 5;
            base.dVelocidadKM = 80;
            base.cNombre = "Tren";
        }
    }
}
