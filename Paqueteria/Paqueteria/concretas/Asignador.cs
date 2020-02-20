using Paqueteria.abtrstacciones;
using Paqueteria.concretas.paqueteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.concretas
{
    class Asignador : IAsignador
    {
        IImpresorMensajes ImpresorMensajes;
        public Asignador(IImpresorMensajes _ImpresorMensajes)
        {
            ImpresorMensajes = _ImpresorMensajes;
        }

        public IFabricamediosTrasporte AsignarTrasporte(string _cClave)
        {
            IFabricamediosTrasporte transporte;
            switch (_cClave)
            {
                case "Tren":
                    transporte = new GeneradorTren();
                    break;
                case "Avión":
                    transporte = new GeneradorAvion();
                    break;
                case "Barco":
                    transporte = new GeneradorBarco();
                    break;
                default:
                    ImpresorMensajes.mostrarMensajeError(string.Format("El medio de trasporte: {0} no se encuentra registrado.", _cClave));
                    transporte = null;
                    break;

            }
            return transporte;
        }

        public IPaqueterias AsignarPaqueria(string _cClave)
        {
            IPaqueterias paqueteria;
            switch (_cClave)
            {
                case "Estafeta":
                    paqueteria = new Estafeta();
                    break;
                case "DHL":
                    paqueteria = new DHL();
                    break;
                case "Fedex":
                    paqueteria = new Fedex();
                    break;
                default:
                    ImpresorMensajes.mostrarMensajeError(string.Format("La Paquetería: {0} no se encuentra registrada en nuestra red de distribución.", _cClave));
                    paqueteria = null;
                    break;

            }
            return paqueteria;
        }
    }
}
