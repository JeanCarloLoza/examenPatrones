using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    interface IFormateadorMensaje
    {
        public string FormatearMensajePedido(string origen, bool lEntregado, string destino, DateTime fechaEntrega, double costo, string NombrePaqueteria, DateTime diaHoy);
    }
}
