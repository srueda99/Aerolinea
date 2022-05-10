using System;
using System.IO;

namespace Aerolinea
{
    internal class Turista : IImpresion
    {
        public void ImprimirTiquete()
        {
            try
            {
                TextWriter writer = new StreamWriter("tiquete.txt");
                writer.WriteLine("============================");
                writer.WriteLine("| TIQUETE DE CLASE TURISTA |");
                writer.WriteLine("============================");
                writer.WriteLine("|        No incluye        |");
                writer.WriteLine("|        beneficios        |");
                writer.WriteLine("|        adicionales       |");
                writer.WriteLine("============================");
                writer.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al escribir el tiquete: {0}", e);
            }
        }
    }
}
