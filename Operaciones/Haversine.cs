using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operaciones
{
    public class Haversine
    {
        public static double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            const double r = 6371; // Km
            double dlat = (lat2 - lat1)/2;
            double dlon = (lon2 - lon1)/2;

            double q = Math.Pow(Math.Sin(dlat), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(q), Math.Sqrt(1 - q));

            double dist = r * c;
            return dist;
        }
    }
}
