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
        string cNombre = "DHL";
        double dMargenUtilidad = 40;
        List<IMedioTrasporte> lstMediosTrasporte = new List<IMedioTrasporte>();

        DHL()
        {
            lstMediosTrasporte.Add(new Avion());
            lstMediosTrasporte.Add(new Barco());
        }
    }
}
