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
        private double costoViaje;
        private int numPasajeros = 0;
        private int cupoMaximo;
        private Ciudad origen;
        private Ciudad destino;
        private bool esInternacional;
        private List<Usuario> pasajeros = new List<Usuario>();

        // Constructor
        public Vuelo(int cupoMaximo, Ciudad origen, Ciudad destino)
        {
            this.CupoMaximo = cupoMaximo;
            this.Origen = origen;
            this.Destino = destino;
            this.VerifInternacional();
            // Corre los métodos
        }

        // Propiedades
        public double CostoViaje { get => costoViaje; private set => costoViaje = value; }
        public int NumPasajeros { get => numPasajeros; private set => numPasajeros = value; }
        public int CupoMaximo { get => cupoMaximo; private set => cupoMaximo = value; }
        public Ciudad Origen { get => origen; private set => origen = value; }
        public Ciudad Destino { get => destino; private set => destino = value; }
        public bool EsInternacional { get => esInternacional; set => esInternacional = value; }
        public List<Usuario> Pasajeros { get => pasajeros; }

        // Métodos
        public void VerifInternacional()
        {
            if(this.Origen.Pais != this.Destino.Pais)
            {
                this.EsInternacional = true;
            }
            else
            {
                this.EsInternacional = false;
            }
        }
        // ObtenerCosto(){}
    }
}
