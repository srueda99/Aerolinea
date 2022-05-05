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
        public enum Tipos { Primera, Ejecutiva, Turista };
        protected double precioTotal;
        protected double precioBase;
        protected Tipos tipo;
        protected Vuelo vuelo;
        protected Usuario usuario;
        protected List<Equipaje> maletas = new List<Equipaje>();

        // Constructor
        protected Tiquete(Vuelo vuelo, Usuario usuario)
        {
            this.Vuelo = vuelo;
            this.precioBase = this.Vuelo.CostoViaje;
            this.CalcularPrecioTotal();
            // this.CobrarEquipaje();
        }

        // Propiedades
        public double PrecioTotal { get => precioTotal; protected set => precioTotal = value; }
        public double PrecioBase { get => precioBase; protected set => precioBase = value; }
        public Tipos Tipo { get => tipo; protected set => tipo = value; }
        public Vuelo Vuelo { get => vuelo; protected set => vuelo = value; }
        public Usuario Usuario { get => usuario; protected set => usuario = value; }
        public List<Equipaje> Maletas { get => maletas; protected set => maletas = value; }

        // Métodos
        public abstract void CalcularPrecioTotal();
        // Borrar el siguiente
        public abstract int CobrarEquipaje();
        public void AggEquipaje()
        {
            // Verificación
            maletas.Add(new Equipaje());
            this.CobrarEquipaje();
        }
        public void VenderTiquete()
        {

        }
    }
}
