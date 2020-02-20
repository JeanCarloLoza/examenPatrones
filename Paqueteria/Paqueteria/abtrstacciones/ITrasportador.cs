using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    interface ITrasportador
    {
        //IMedioTrasporte trasporte;
        public double CalcularCostoTrasporte(double distancia);
        public DateTime CalcularFechaEntrega(double distancia,DateTime fechaEntrega);

        public IMedioTransporte obtenerTrasporte();
        public IPaqueterias obtenerPaqueteria();
    }
}
