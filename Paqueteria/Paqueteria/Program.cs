﻿using Paqueteria.abtrstacciones;
using Paqueteria.concretas;
using System;

namespace Paqueteria
{
    class Program
    {
        static void Main(string[] args)
        {
            string cRutaArchivo = @"C:\Trabajo\Cursos\Patrones\examen\Paqueteria\Pedidos.txt";
            DateTime dtHoy = DateTime.Now;

            ILectorArchivo lector = new LectorTxt(cRutaArchivo);
            IImpresorMensajes mensajes = new ImpresorMensajeConsola();
            IProcesadorPedidos procesador = new ProcesarPedidos(dtHoy, lector, mensajes);

            procesador.Procesar();
            
        }
    }
}
