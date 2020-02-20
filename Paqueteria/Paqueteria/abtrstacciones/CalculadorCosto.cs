using Paqueteria.concretas;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    class CalculadorCosto : iManejadorCadenaResponsabilidad
    {
        iManejadorCadenaResponsabilidad siguiente;
        IPaqueterias paqueteria;

        public CalculadorCosto(IPaqueterias _paqueteria)
        {
            paqueteria = _paqueteria;
        }

        public void hacer(double costoInicial, double mejorCosto, string mejorPaqueteria, double distancia, IImpresorMensajes impresor, IMedioTransporte trasporte)
        {
            double costoNuevo = 0;
            ITrasportador trasportador = null;

            if (paqueteria.ValidaContieneTrasporte(trasporte))
            {
                trasportador = new Trasportador(trasporte, paqueteria);
                costoNuevo = trasportador.CalcularCostoTrasporte(distancia);
                if (costoNuevo < mejorCosto)
                {
                    mejorCosto = costoNuevo;
                    mejorPaqueteria = paqueteria.cNombre;
                }
            }

            if (siguiente != null)
            {
                siguiente.hacer(costoInicial, mejorCosto, mejorPaqueteria, distancia, impresor, trasporte);
            }
            else
            {
                if (costoInicial != mejorCosto)
                {
                    impresor.mostrarMensaje(string.Format("Si hubieras pedido en {0} te hubiera costado ${1} más barato.",
                    mejorPaqueteria, costoInicial - mejorCosto));
                }
            }
        }

        public void setNext(iManejadorCadenaResponsabilidad manejador)
        {
            siguiente = manejador;
        }
    }
}
