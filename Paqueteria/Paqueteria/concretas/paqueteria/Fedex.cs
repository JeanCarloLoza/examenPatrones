using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas.paqueteria
{
    class Fedex : IPaqueterias
    {
        string cNombre = "Fedex";
        double dMargenUtilidad = 50;
        List<IMedioTrasporte> lstMediosTrasporte = new List<IMedioTrasporte>();

        Fedex()
        {
            lstMediosTrasporte.Add(new Barco());
        }
    }
}
