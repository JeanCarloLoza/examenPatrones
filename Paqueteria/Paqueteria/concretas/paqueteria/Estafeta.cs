using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas.paqueteria
{
    class Estafeta : IPaqueterias
    {
        string cNombre = "Estafeta";
        double dMargenUtilidad = 20;
        List<IMedioTrasporte> lstMediosTrasporte = new List<IMedioTrasporte>();

        Estafeta() {
            lstMediosTrasporte.Add(new Barco());
            lstMediosTrasporte.Add(new Tren());
        }
    }
}
