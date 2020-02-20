using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.clases
{
    class Tren : IMedioTrasporte
    {
        double dCostoKM = 5;
        double dVelocidadKM = 80;
        string cNombre = "Tren";
    }
}
