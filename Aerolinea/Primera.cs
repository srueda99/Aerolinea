using System;
using System.IO;

namespace Aerolinea
{
    public class Primera : IImpresion
    {
        public void ImprimirTiquete()
        {
            try
            {
                TextWriter writer = new StreamWriter("tiquete.txt");
                writer.WriteLine("============================");
                writer.WriteLine("| TIQUETE DE PRIMERA CLASE |");
                writer.WriteLine("============================");
                writer.WriteLine("| Sin cobros por sobrepeso |");
                writer.WriteLine("|         Incluye:         |");
                writer.WriteLine("|    - Acceso al bar       |");
                writer.WriteLine("|    - Comida ilimitada    |");
                writer.WriteLine("|    - Baños privados      |");
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
