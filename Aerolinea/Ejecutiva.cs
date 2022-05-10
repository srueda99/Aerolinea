using System;
using System.IO;

namespace Aerolinea
{
    internal class Ejecutiva : IImpresion
    {
        public void ImprimirTiquete()
        {
            try
            {
                TextWriter writer = new StreamWriter("tiquete.txt");
                writer.WriteLine("==============================");
                writer.WriteLine("| TIQUETE DE CLASE EJECUTIVA |");
                writer.WriteLine("==============================");
                writer.WriteLine("|          Incluye:          |");
                writer.WriteLine("|     - Comida ilimitada     |");
                writer.WriteLine("|     - Baños privados       |");
                writer.WriteLine("==============================");
                writer.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al escribir el tiquete: {0}", e);
            }
        }
    }
}
