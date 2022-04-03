using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Vuelo
    {
        // Atributos
        private int numPasajeros = 0;
        private int cupoMaximo;
        private Destino destino;
        private List<Usuario> pasajeros = new List<Usuario>();

        // Constructor
        public Vuelo(int cupoMaximo, Destino destino)
        {
            this.CupoMaximo = cupoMaximo;
            this.Destino = destino;
            // Corre los métodos
        }

        // Propiedades
        public int NumPasajeros { get => numPasajeros; private set => numPasajeros = value; }
        public int CupoMaximo { get => cupoMaximo; set => cupoMaximo = value; }
        public Destino Destino { get => destino; set => destino = value; }
        public List<Usuario> Pasajeros { get => pasajeros; }

        // Métodos
        // CheckIn(Usuario){}
    }
}
