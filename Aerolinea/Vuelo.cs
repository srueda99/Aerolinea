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
        private int numPasajeros;
        private int cupoMaximo;
        private Ciudad origen;
        private Ciudad destino;
        private bool esInternacional;

        // Constructor
        public Vuelo(Ciudad origen, Ciudad destino)
        {
            this.Origen = origen;
            this.Destino = destino;
            this.NumPasajeros = 0;
            this.VerifInternacional();
            // Corre los métodos
        }

        // Propiedades
        public double CostoViaje { get => costoViaje; private set => costoViaje = value; }
        public int NumPasajeros { get => numPasajeros; set => numPasajeros = value; }
        public int CupoMaximo { get => cupoMaximo; private set => cupoMaximo = value; }
        public Ciudad Origen { get => origen; private set => origen = value; }
        public Ciudad Destino { get => destino; private set => destino = value; }
        public bool EsInternacional { get => esInternacional; set => esInternacional = value; }

        // Métodos
        public void VerifInternacional()
        {
            try
            {
                if (this.Origen.Pais != this.Destino.Pais)
                {
                    this.EsInternacional = true;
                    this.CupoMaximo = 15;
                }
                else
                {
                    this.EsInternacional = false;
                    this.CupoMaximo = 10;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error encontrado al verificar el vuelo: {0}", e);
            }
        }
        public void ObtenerCosto()
        {
            
        }
    }
}
