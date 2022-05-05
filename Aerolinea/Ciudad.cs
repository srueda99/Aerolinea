using System;
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
        private double latitud;
        private double longitud;
        private string pais;
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
        public string Pais { get => pais; private set => pais = value; }
        public string Nombre { get => nombre; private set => nombre = value; }
        public double Latitud { get => latitud; set => latitud = value; }
        public double Longitud { get => longitud; set => longitud = value; }

        // Métodos
        public void VerCiudades(){
            Console.WriteLine("Las ciudades disponibles para vuelos son:");
            int i = 0;
            while(i < ciudades.Count)
            {
                Console.WriteLine(i +". "+ ciudades[i].Nombre);
            }
        }
    }
}
