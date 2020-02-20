using System;

namespace Paqueteria
{
    class Program
    {
        static void Main(string[] args)
        {
            string cRutaArchivo = @"C:\Trabajo\Cursos\Patrones\examen\Paqueteria\Pedidos.txt";
            DateTime dtHoy = DateTime.Now;
            string cRespusta="";

            //leer
            string[] arrInfo;
            arrInfo=System.IO.File.ReadAllLines(cRutaArchivo);
            //

            //procesar
            string[] arrColumnas;
            string origen = "",destino="",paqueteria="";
            DateTime fechaEntrega;
            bool lEntregado = false;
            double costo = 0;
            foreach (string l in arrInfo)
            {
                //1Ticul,Motul,80,Estafeta,Tren,23-01-2020 12:00:00
                arrColumnas = l.Split(',');//TODO: validar que cada linea tenga el formato corecto
                origen = arrColumnas[0];
                destino = arrColumnas[1];
                paqueteria = arrColumnas[3];
                costo = double.Parse(arrColumnas[2]);
                fechaEntrega = Convert.ToDateTime(arrColumnas[5]);
                lEntregado = fechaEntrega < dtHoy;
                cRespusta += string.Format("\nTu paquete salió de {0} y {1} a {2} el {3} y tuvo un costo de ${4} (cualquier reclamación con {5})",
                    origen, lEntregado ? "entrego" : "entregara", destino, fechaEntrega, costo, paqueteria);
            }
            //

            //formatear
            //cRespusta = string.Format("Tu paquete salió de {0} y {1} a {2} el {3} y tuvo un costo de ${4} (cualquier reclamación con {5})",
            //    origen, lEntregado?"entrego":"entregara", destino, fechaEntrega, costo,paqueteria);
            //Tu paquete salió de Ticul y llegó a Motul el 11/11/2020 y tuvo un costo de $480 (cualquier reclamación con Estafeta).
            //

            //imprimir
            System.Console.WriteLine(cRespusta);
            System.Console.ReadKey();
            //
        }
    }
}
