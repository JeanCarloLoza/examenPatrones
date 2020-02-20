using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    public abstract class IPaqueterias
    {
        public string cNombre;
        public double dMargenUtilidad;
        public List<IMedioTransporte> lstMediosTrasporte = new List<IMedioTransporte>();

        public bool ValidaContieneTrasporte(IMedioTransporte trasporte) {
            return lstMediosTrasporte.Exists(x=> x.cNombre==trasporte.cNombre);
        }
    }
}
