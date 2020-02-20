using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    interface IImpresorMensajes
    {
        void mostrarMensajeCondicionado(string cRespusta,bool lEntregado);
        public void mostrarMensajeError(string cMensaje);
        public void mostrarMensaje(string cMensaje);
    }
}
