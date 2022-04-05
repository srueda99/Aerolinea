using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Destino
    {
        // Atributos
        private string nombre;
        private double distancia;
        private long precio;
        private bool esInternacional;
        private static List<Destino> destinos = new List<Destino>();

        // Constructor
        public Destino(string nombre, double distancia, long precio, bool esInternacional)
        {
            this.nombre = nombre;
            this.Distancia = distancia;
            this.Precio = precio;
            this.EsInternacional = esInternacional;
            Destino.destinos.Add(this);
        }

        // Propiedades
        public double Distancia { get => distancia; private set => distancia = value; }
        public long Precio { get => precio; private set => precio = value; }
        public bool EsInternacional { get => esInternacional; private set => esInternacional = value; }
        public string Nombre { get => nombre; private set => nombre = value; }

        // Métodos
        public void verDestinos(){
            Console.WriteLine("Los destinos disponibles son:");
            int i = 0;
            while(i < destinos.Count)
            {
                Console.WriteLine(i +". "+ destinos[i].Nombre +" con precio de $"+ destinos[i].Precio);
            }
        }
    }
}
