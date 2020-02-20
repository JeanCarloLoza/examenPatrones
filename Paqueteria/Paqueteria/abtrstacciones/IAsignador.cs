using System;
using System.Collections.Generic;
using System.Text;

namespace Paqueteria.abtrstacciones
{
    interface IAsignador
    {
        public IFabricamediosTrasporte AsignarTrasporte(string _cClave);
        public IPaqueterias AsignarPaqueria(string _cClave);

    }
}
