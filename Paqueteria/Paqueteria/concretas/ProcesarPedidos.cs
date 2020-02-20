using Paqueteria.abtrstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class ProcesarPedidos : IProcesadorPedidos
    {
        DateTime dtHoy;
        ILectorArchivo lectorArchivo;
        IImpresorMensajes ImpresorMensajes;

        public ProcesarPedidos(DateTime _dateTime, ILectorArchivo _lectorArchivo, IImpresorMensajes _impresorMensajes)
        {
            dtHoy = _dateTime;
            lectorArchivo = _lectorArchivo;
            ImpresorMensajes = _impresorMensajes;
        }

        public void Procesar()
        {
            string cRespusta = "";

            string[] arrInfo;
            arrInfo = lectorArchivo.LeerArchivo();

            cRespusta = RecorrerPedidos(arrInfo);

            ImpresorMensajes.mostrarMensaje(cRespusta);
        }

        private string RecorrerPedidos(string[] _arrInfo) {
            string cRespuesta = "";
            string[] arrColumnas;
            string origen = "", destino = "", paqueteria = "";
            DateTime fechaEntrega;
            bool lEntregado = false;
            double costo = 0;

            foreach (string l in _arrInfo)
            {
                //1Ticul,Motul,80,Estafeta,Tren,23-01-2020 12:00:00
                arrColumnas = l.Split(',');//TODO: validar que cada linea tenga el formato corecto
                origen = arrColumnas[0];
                destino = arrColumnas[1];
                paqueteria = arrColumnas[3];
                costo = double.Parse(arrColumnas[2]);
                fechaEntrega = Convert.ToDateTime(arrColumnas[5]);
                lEntregado = fechaEntrega < dtHoy;
                cRespuesta += string.Format("\nTu paquete salió de {0} y {1} a {2} el {3} y tuvo un costo de ${4} (cualquier reclamación con {5})",
                    origen, lEntregado ? "entrego" : "entregara", destino, fechaEntrega, costo, paqueteria);
            }
            return cRespuesta;
        }
    }
}
