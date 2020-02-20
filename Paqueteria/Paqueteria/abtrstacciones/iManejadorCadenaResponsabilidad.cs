using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    interface iManejadorCadenaResponsabilidad
    {
        public void setNext(iManejadorCadenaResponsabilidad manejador);
        public void hacer(double costoInicial, double mejorCosto, string mejorPaqueteria, double distancia, IImpresorMensajes impresor, IMedioTransporte trasporte);
    }
}
