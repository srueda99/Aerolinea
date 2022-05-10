using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ops
{
    public class Haversine
    {
        public static double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            try
            {
                double latOrg = (lat1 / (180 / Math.PI));
                double lonOrg = (lon1 / (180 / Math.PI));
                double latDest = (lat2 / (180 / Math.PI));
                double lonDest = (lon2 / (180 / Math.PI));

                double dist = Math.Sin(latDest) * Math.Sin(latOrg);
                dist += Math.Cos(latDest) * Math.Cos(latOrg) * Math.Cos(lonDest - lonOrg);
                dist = Math.Acos(dist) * 6371;
                return dist;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al calcular la distancia: {0}", e.Message);
                return -1;
            }
        }
    }
}
