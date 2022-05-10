using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ops
{
    public class Conversion
    {
        public static double ConvertirPesos(double usd)
        {
            try
            {
                double pesos = usd * 4080;
                return pesos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al convertir a Pesos: {0}", e.Message);
                return -1;
            }
        }
        public static double ConvertirUSD(double pesos)
        {
            try
            {
                double usd = pesos / 4080;
                return usd;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error encontrado al convertir a USD: {0}", e.Message);
                return -1;
            }
        }
    }
}
