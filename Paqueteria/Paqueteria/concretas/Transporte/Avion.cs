using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.clases
{
    class Avion : IMedioTrasporte
    {
        double dCostoKM = 10;
        double dVelocidadKM = 600;
        string cNombre = "Avion";
    }
}
