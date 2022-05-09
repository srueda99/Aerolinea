using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Ciudad
    {
        // Atributos
        private string nombre;
        private string pais;
        private double latitud;
        private double longitud;
        private static List<Ciudad> ciudades = new List<Ciudad>();

        // Constructor
        public Ciudad(string nombre, string pais, double latitud, double longitud)
        {
            this.Nombre = nombre;
            this.Pais = pais;
            this.Latitud = latitud;
            this.Longitud = longitud;
            Ciudad.ciudades.Add(this);
        }

        // Propiedades
        public string Nombre { get => nombre; private set => nombre = value; }
        public string Pais { get => pais; private set => pais = value; }
        public double Latitud { get => latitud; set => latitud = value; }
        public double Longitud { get => longitud; set => longitud = value; }

        // Métodos
        public static void VerCiudades()
        {
            try
            {
                Console.WriteLine("Las ciudades disponibles para vuelos son:");
                int i = 0;
                while (i < ciudades.Count)
                {
                    Console.WriteLine((i + 1) + ". " + ciudades[i].Nombre + ", " + ciudades[i].Pais);
                    i++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error encontrado al listar las ciudades: {0}", e);
            }
        }

        public static void CargarCiudades()
        {
            try
            {
                var archivo = new StreamReader(File.OpenRead(@"C:\Users\s_rue\Documents\POO\C#\Aerolinea\Aerolinea\ciudades.csv"));
                string linea;
                string nombre;
                string pais;
                double latitud;
                double longitud;
                Ciudad ciudadAux;
                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] fila = linea.Split(',');
                    nombre = fila[0];
                    pais = fila[1];
                    latitud = Convert.ToDouble(fila[2]);
                    longitud = Convert.ToDouble(fila[3]);

                    ciudadAux = new Ciudad(nombre, pais, latitud, longitud);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error encontrado al cargar las ciudades: {0}", e);
            }
        }
    }
}
