using Paqueteria.abtrstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class ImpresorMensajeConsola : IImpresorMensajes
    {
        public void mostrarMensajeCondicionado(string cRespusta,bool lEntregado)
        {
            if (lEntregado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            mostrarMensaje(cRespusta);
            Console.ResetColor();
        }

        public void mostrarMensajeError(string cMensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            mostrarMensaje(cMensaje);
            Console.ResetColor();
        }
        public void mostrarMensaje(string cMensaje)
        {
            System.Console.WriteLine(cMensaje);
        }
    }
}
