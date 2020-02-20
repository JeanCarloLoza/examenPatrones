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

        public ProcesarPedidos(DateTime _dateTime, ILectorArchivo _lectorArchivo, IImpresorMensajes _impresorMensajes, 
            IFormateadorMensaje _formateadorMensaje)
        {
            dtHoy = _dateTime;
            lectorArchivo = _lectorArchivo;
            ImpresorMensajes = _impresorMensajes;
            formateadorMensaje = _formateadorMensaje;
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

            origen = arrFila[0];
            destino = arrFila[1];
            distancia = double.Parse(arrFila[2]);
            medioTrasporte = AsignarTrasporte(arrFila[4]);
            paqueteria = AsignarPaqueria(arrFila[3]);
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
            ValidarOtrasPaqueterias(costo,distancia,trasportador);
        }

        private IMedioTransporte AsignarTrasporte(string _cClave) {
            IMedioTransporte transporte;
            switch (_cClave) {
                case "Tren":
                    transporte = new Tren();
                    break;
                default:
                    ImpresorMensajes.mostrarMensajeError(string.Format("El medio de trasporte: {0} no se encuentra registrado.", _cClave));
                    transporte = null;
                    break;

            }
            return transporte;
        }
        private IPaqueterias AsignarPaqueria(string _cClave)
        {
            IPaqueterias paqueteria;
            switch (_cClave)
            {
                case "Estafeta":
                    paqueteria = new Estafeta();
                    break;
                default:
                    ImpresorMensajes.mostrarMensajeError(string.Format("La Paquetería: {0} no se encuentra registrada en nuestra red de distribución.",_cClave));
                    paqueteria = null;
                    break;

            }
            return paqueteria;
        }

        public void ValidarOtrasPaqueterias(double costoAnt,double distacia, ITrasportador trasportadorAnt) {
            string crespuesta = "";
            double costoNuevo = 0;
            double menorCosto = costoAnt;
            string mejorPaqueteria = trasportadorAnt.obtenerPaqueteria().cNombre;
            ITrasportador trasportador = null;
            IMedioTransporte trasporte = trasportadorAnt.obtenerTrasporte();
            IPaqueterias paqueteria = new Estafeta();

            if (trasportadorAnt.obtenerPaqueteria() !=paqueteria && paqueteria.ValidaContieneTrasporte(trasporte))
            {
                trasportador = new Trasportador(trasporte,paqueteria);
                costoNuevo = trasportador.CalcularCostoTrasporte(distacia);
                if (costoNuevo < menorCosto)
                {
                    menorCosto = costoNuevo;
                    mejorPaqueteria = paqueteria.cNombre;
                }
            }
            paqueteria = new DHL();

            if (trasportadorAnt.obtenerPaqueteria() != paqueteria && paqueteria.ValidaContieneTrasporte(trasporte))
            {
                trasportador = new Trasportador(trasporte, paqueteria);
                costoNuevo = trasportador.CalcularCostoTrasporte(distacia);
                if (costoNuevo < menorCosto)
                {
                    menorCosto = costoNuevo;
                    mejorPaqueteria = paqueteria.cNombre;
                }
            }
            paqueteria = new Fedex();

            if (trasportadorAnt.obtenerPaqueteria() != paqueteria && paqueteria.ValidaContieneTrasporte(trasporte))
            {
                trasportador = new Trasportador(trasporte, paqueteria);
                costoNuevo = trasportador.CalcularCostoTrasporte(distacia);
                if (costoNuevo < menorCosto)
                {
                    menorCosto = costoNuevo;
                    mejorPaqueteria = paqueteria.cNombre;
                }
            }
            if (trasportadorAnt.obtenerPaqueteria().cNombre != mejorPaqueteria)
            {
                ImpresorMensajes.mostrarMensaje(string.Format("Si hubieras pedido en {0} te hubiera costado ${1} más barato.",
                    mejorPaqueteria, costoAnt-menorCosto));
            }
        }
    }
}
