using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operaciones;

namespace Aerolinea
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ciudad.CargarCiudades();
            Ciudad.VerCiudades();

            Operaciones.Haversine.CalcularDistancia(6.25184, -75.56359, 4.60971, -74.08175);
        }
    }
}
