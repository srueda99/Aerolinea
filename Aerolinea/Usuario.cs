using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Usuario
    {
        // Atributos
        private string nombre;
        private string cedula;
        private string pasaporte;
        private bool esEjecutivo;
        private List<Equipaje> equipaje = new List<Equipaje>();
        private Tiquete tiquete;

        public Usuario(string nombre, string cedula, string pasaporte, bool esEjecutivo)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Pasaporte = pasaporte;
            this.EsEjecutivo = esEjecutivo;
            // Tiquete se agrega en el método VenderTiquete()
        }

        // Propiedades
        public string Nombre { get => nombre; set => nombre = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Pasaporte { get => pasaporte; set => pasaporte = value; }
        public bool EsEjecutivo { get => esEjecutivo; set => esEjecutivo = value; }
        public List<Equipaje> Equipaje { get => equipaje; }
        public Tiquete Tiquete { get => tiquete; set => tiquete = value; }

        // Métodos
        public void AggEquipaje(Equipaje equipaje)
        {
            this.Equipaje.Add(equipaje);
        }
        public int CobroEquipaje()
        {
            int lim;
            int cobro = 0;
            if (this.EsEjecutivo)
            {
                lim = 32;
            }
            else
            {
                lim = 23;
            }
            foreach(Equipaje maleta in equipaje)
            {
                if(maleta.Peso > lim)
                {
                    cobro += (maleta.Peso - lim) * 5;
                }
            }
            return cobro;
        }
    }
}
