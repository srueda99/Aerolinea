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
        private string pais;

        private static List<Ciudad> ciudades = new List<Ciudad>();

        // Constructor
        public Ciudad(string nombre, string pais)
        {
            this.nombre = nombre;
            this.Pais = pais;
            Ciudad.ciudades.Add(this);
        }

        // Propiedades
        public string Pais { get => pais; private set => pais = value; }
        public string Nombre { get => nombre; private set => nombre = value; }

        // Métodos
        public void VerCiudades(){
            Console.WriteLine("Los ciudades disponibles apara vuelos son:");
            int i = 0;
            while(i < ciudades.Count)
            {
                Console.WriteLine(i +". "+ ciudades[i].Nombre +" con precio de $"+ ciudades[i].Precio);
            }
        }
    }
}
