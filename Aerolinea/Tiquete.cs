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
        protected double precioTotal;
        protected double precioBase;
        protected Vuelo vuelo;
        protected Usuario usuario;
        protected List<Equipaje> maletas = new List<Equipaje>();

        // Constructor
        protected Tiquete(Vuelo vuelo, Usuario usuario)
        {
            this.Vuelo = vuelo;
            this.precioBase = this.Vuelo.CostoViaje;
            this.CalcularPrecio();
            // this.CobrarEquipaje();
        }

        // Propiedades
        public double PrecioTotal { get => precioTotal; protected set => precioTotal = value; }
        public double PrecioBase { get => precioBase; protected set => precioBase = value; }
        public Vuelo Vuelo { get => vuelo; protected set => vuelo = value; }
        protected Usuario Usuario { get => usuario; set => usuario = value; }
        protected List<Equipaje> Maletas { get => maletas; set => maletas = value; }

        // Métodos
        public abstract void CalcularPrecio();
        public abstract int CobrarEquipaje();
        public void AggEquipaje()
        {
            maletas.Add(new Equipaje());
            this.CobrarEquipaje();
        }
        public void VenderTiquete()
        {

        }
    }
}
