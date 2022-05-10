using System;
using Ops;
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
        private static List<Vuelo> vuelos = new List<Vuelo>();

        // Constructor
        public Vuelo(Ciudad origen, Ciudad destino)
        {
            this.Origen = origen;
            this.Destino = destino;
            this.NumPasajeros = 0;
            this.VerifInternacional();
            this.ObtenerCosto();
            vuelos.Add(this);
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
                if(string.Equals(Origen.Pais, Destino.Pais))
                {
                    this.EsInternacional = false;
                    this.CupoMaximo = 5;
                }
                else
                {
                    this.EsInternacional = true;
                    this.CupoMaximo = 10;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error encontrado al verificar el vuelo: {0}", e.Message);
            }
        }
        public void ObtenerCosto()
        {
            try
            {
                double tarifa = 0.065;
                double lat1 = this.Origen.Latitud;
                double lon1 = this.Origen.Longitud;
                double lat2 = this.Destino.Latitud;
                double lon2 = this.Destino.Longitud;
                double dist = Haversine.CalcularDistancia(lat1, lon1, lat2, lon2);
                this.CostoViaje = dist * tarifa;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al calcular el costo: {0}", e.Message);
            }
        }
        public static Vuelo EncontrarVuelo(Ciudad origen, Ciudad destino)
        {
            try
            {
                Vuelo hallado = null;
                foreach (Vuelo vuelo in vuelos)
                {
                    if (vuelo.Origen == origen && vuelo.Destino == destino)
                    {
                        hallado = vuelo;
                        break;
                    }
                }
                return hallado;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al buscar el vuelo: {0}", e.Message);
                return null;
            }
        }
    }
}
