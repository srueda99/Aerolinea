using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    abstract class Tiquete
    {
        // Atributos
        private long precioTotal;
        private long precioBase;
        private Vuelo vuelo;

        // Constructor
        protected Tiquete(Vuelo vuelo)
        {
            this.Vuelo = vuelo;
            // Precio base = precio Destino
            // Correr métodos
        }

        // Propiedades
        public long PrecioTotal { get => precioTotal; protected set => precioTotal = value; }
        public long PrecioBase { get => precioBase; protected set => precioBase = value; }
        public Vuelo Vuelo { get => vuelo; protected set => vuelo = value; }

        // Métodos
        // CalcularPrecio(){}
        // VenderTiquete(Usuario){}
    }
}
