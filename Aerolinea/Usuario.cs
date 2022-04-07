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
        private bool tienePasaporte;
        private bool esEjecutivo;
        private Tiquete tiquete;

        public Usuario(string nombre, string cedula, bool tienePasaporte, bool esEjecutivo)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.TienePasaporte = tienePasaporte;
            this.EsEjecutivo = esEjecutivo;
            // Tiquete se agrega en el método VenderTiquete()
        }

        // Propiedades
        public string Nombre { get => nombre; set => nombre = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public bool TienePasaporte { get => tienePasaporte; set => tienePasaporte = value; }
        public bool EsEjecutivo { get => esEjecutivo; set => esEjecutivo = value; }
        public Tiquete Tiquete { get => tiquete; set => tiquete = value; }
    }
}
