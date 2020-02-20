using Paqueteria.abtrstacciones;
using Paqueteria.clases;
using Paqueteria.concretas.paqueteria;
using Paqueteria.Interfaces;
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
        IFormateadorMensaje formateadorMensaje;
        IAsignador asignador;

        public ProcesarPedidos(DateTime _dateTime, ILectorArchivo _lectorArchivo, IImpresorMensajes _impresorMensajes, 
            IFormateadorMensaje _formateadorMensaje, IAsignador _asignador)
        {
            dtHoy = _dateTime;
            lectorArchivo = _lectorArchivo;
            ImpresorMensajes = _impresorMensajes;
            formateadorMensaje = _formateadorMensaje;
            asignador = _asignador;
        }

        public void Procesar()
        {
            string[] arrInfo;
            arrInfo = lectorArchivo.LeerArchivo();

            RecorrerPedidos(arrInfo);

        }

        private void RecorrerPedidos(string[] _arrInfo) {

            string[] arrColumnas;

            foreach (string l in _arrInfo)
            {
                //1Ticul,Motul,80,Estafeta,Tren,23-01-2020 12:00:00
                arrColumnas = l.Split(',');//TODO: validar que cada linea tenga el formato corecto
                ProcesarFila(arrColumnas);
            }
        }

        private void ProcesarFila(string[] arrFila)
        {
            string cRespuesta = "";
            string origen = "", destino = "";
            DateTime fechaEntrega;
            bool lEntregado = false;
            double costo = 0;
            double distancia = 0;
            ITrasportador trasportador;
            IMedioTransporte medioTrasporte;
            IPaqueterias paqueteria;
            IFabricamediosTrasporte fabrica;

            origen = arrFila[0];
            destino = arrFila[1];
            distancia = double.Parse(arrFila[2]);
            //medioTrasporte = AsignarTrasporte(arrFila[4]);
            fabrica = asignador.AsignarTrasporte(arrFila[4]);
            medioTrasporte = fabrica.CreaMedioTrasporte();
            paqueteria = asignador.AsignarPaqueria(arrFila[3]);
            if (medioTrasporte == null || null == paqueteria) { 
                return; 
            }
            if (!paqueteria.ValidaContieneTrasporte(medioTrasporte)) {
                ImpresorMensajes.mostrarMensajeError(string.Format(
                    "{0} no ofrece el servicio de transporte {1}, te recomendamos cotizar en otra empresa", paqueteria.cNombre,medioTrasporte.cNombre));
                return; 
            }
            trasportador = new Trasportador(medioTrasporte, paqueteria);
            costo = trasportador.CalcularCostoTrasporte(distancia);
            fechaEntrega = trasportador.CalcularFechaEntrega(distancia, Convert.ToDateTime(arrFila[5]));
            lEntregado = fechaEntrega < dtHoy;

            cRespuesta = formateadorMensaje.FormatearMensajePedido(origen, lEntregado, destino, fechaEntrega, costo, paqueteria.cNombre, dtHoy);
            ImpresorMensajes.mostrarMensajeCondicionado(cRespuesta, lEntregado);
            ValidarOtrasPaqueterias(costo, paqueteria.cNombre, distancia, ImpresorMensajes, medioTrasporte);
        }


        public void ValidarOtrasPaqueterias(double costoInicial, string mejorPaqueteria, double distancia, IImpresorMensajes impresor, IMedioTransporte trasporte) {
            iManejadorCadenaResponsabilidad manejador1 = new CalculadorCosto(new Fedex());
            iManejadorCadenaResponsabilidad manejador2 = new CalculadorCosto(new Estafeta());
            iManejadorCadenaResponsabilidad manejador3 = new CalculadorCosto(new DHL());

            manejador1.setNext(manejador2);
            manejador2.setNext(manejador3);

            manejador1.hacer(costoInicial, costoInicial, mejorPaqueteria, distancia, impresor, trasporte);
        }
    }
}
