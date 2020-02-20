using Paqueteria.abtrstacciones;
using Paqueteria.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class Trasportador : ITrasportador
    {
        IMedioTransporte trasporte;
        IPaqueterias paqueteria;

        public Trasportador(IMedioTransporte _trasporte, IPaqueterias _paqueteria)
        {
            trasporte = _trasporte;
            paqueteria = _paqueteria;
        }

        public double CalcularCostoTrasporte(double distancia)
        {
            //Costo de envío = (Costo por km del [Medio de Transporte] * [Distancia]) * (1 + Margen de utilidad de la [Paquetería]/100)
            return (trasporte.dCostoKM * distancia) * (1 + paqueteria.dMargenUtilidad/100);
        }

        public DateTime CalcularFechaEntrega(double distancia, DateTime fechaEntrega)
        {
            //Tiempo de traslado = [Distancia] / la velocidad del [Medio de Transporte]
            double tiempoTraslado = distancia / trasporte.dVelocidadKM;
            //[Fecha de entrega] = [Fecha y hora de pedido] + Tiempo de traslado
            return fechaEntrega.AddHours(tiempoTraslado);
        }

        public IMedioTransporte obtenerTrasporte()
        {
            return trasporte;
        }
        public IPaqueterias obtenerPaqueteria()
        {
            return paqueteria;
        }
    }
}
