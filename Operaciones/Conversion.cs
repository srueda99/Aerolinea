namespace Operaciones
{
    public class Conversion
    {
        public static double ConvertirPesos(double usd)
        {
            double pesos = usd * 4080;
            return pesos;
        }
        public static double ConvertirUSD(double pesos)
        {
            double usd = pesos/4080;
            return usd;
        }
    }
}