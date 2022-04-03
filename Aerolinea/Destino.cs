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
        private double distancia;
        private long precio;
        private bool esInternacional;
        private List<Destino> destinos = new List<Destino>();

        // Constructor
        public Destino(double distancia, long precio, bool esInternacional)
        {
            this.Distancia = distancia;
            this.Precio = precio;
            this.EsInternacional = esInternacional;
            this.destinos.Add(this);
        }

        // Propiedades
        public double Distancia { get => distancia; set => distancia = value; }
        public long Precio { get => precio; set => precio = value; }
        public bool EsInternacional { get => esInternacional; set => esInternacional = value; }

        // Métodos
        // verDestinos(){}
    }
}
