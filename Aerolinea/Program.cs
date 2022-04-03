using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Equipaje maleta1 = new Equipaje();
            Equipaje maleta2 = new Equipaje();
            Equipaje maleta3 = new Equipaje();

            maleta3.Pesar();
            maleta3.RevisarContenido();

            Console.WriteLine(maleta1.Peso + " " + maleta1.Contenido + " " + maleta1.EsLegal);
            Console.WriteLine(maleta2.Peso + " " + maleta2.Contenido + " " + maleta2.EsLegal);
            Console.WriteLine(maleta3.Peso + " " + maleta3.Contenido + " " + maleta3.EsLegal);
        }
    }
}
