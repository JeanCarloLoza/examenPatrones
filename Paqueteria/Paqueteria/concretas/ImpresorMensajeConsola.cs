using Paqueteria.abtrstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class ImpresorMensajeConsola : IImpresorMensajes
    {
        public void mostrarMensaje(string cRespusta)
        {
            System.Console.WriteLine(cRespusta);
            System.Console.ReadKey();
        }
    }
}
