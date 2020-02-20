using Paqueteria.abtrstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class FormateadorMensaje : IFormateadorMensaje
    {
        public string FormatearMensajePedido(string origen,bool lEntregado,string destino,DateTime fechaEntrega,double costo,string NombrePaqueteria, DateTime diaHoy) {
            /*
            En el caso de que la Fecha de entrega sea menor al día de hoy deberá de ser: salió, en caso contrario deberá de ser: ha salido
	        En el caso de que la Fecha de entrega sea menor al día de hoy deberá de ser: llegó, en caso contrario deberá de ser: llegará
	        En el caso de que la Fecha de entrega sea menor al día de hoy deberá de ser: tuvó, en caso contrario deberá de ser: tendrá.
            */
            bool lFechaEntregaMenor = false;
            if (fechaEntrega < diaHoy) {
                lFechaEntregaMenor = true;
            }

            return string.Format("\nTu paquete {0} de {1} y {2} a {3} el {4} y {5} un costo de ${6} (cualquier reclamación con {7})",
                lFechaEntregaMenor? "salió" : "ha salido",
                origen, lFechaEntregaMenor ? "llegó" : "llegará", destino, fechaEntrega, lFechaEntregaMenor ? "tuvó" : "tendrá", costo, NombrePaqueteria);
        }
    }
}
