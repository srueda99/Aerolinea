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
        protected double multa;
        protected Tipos tipo;
        protected Vuelo vuelo;
        protected Usuario usuario;
        protected List<Equipaje> maletas = new List<Equipaje>();

        // Constructor
        protected Tiquete(Vuelo vuelo, Usuario usuario)
        {
            this.Vuelo = vuelo;
            this.Usuario = usuario;
            this.precioBase = this.Vuelo.CostoViaje;
            this.Multa = 0;
        }

        // Propiedades
        public double PrecioTotal { get => precioTotal; protected set => precioTotal = value; }
        public double PrecioBase { get => precioBase; protected set => precioBase = value; }
        public double Multa { get => multa; protected set => multa = value; }
        public Tipos Tipo { get => tipo; protected set => tipo = value; }
        public Vuelo Vuelo { get => vuelo; protected set => vuelo = value; }
        public Usuario Usuario { get => usuario; protected set => usuario = value; }
        public List<Equipaje> Maletas { get => maletas; protected set => maletas = value; }

        // Métodos
        public abstract void CalcularPrecioTotal();
        public abstract int CobrarEquipaje();
        public void AggEquipaje(int numMaletas)
        {
            int i = 0;
            Equipaje eq;
            while (i < numMaletas)
            {
                eq = new Equipaje();
                if(!eq.EsLegal)
                {
                    this.Multa += 1000;
                    // Print no se pudo registrar una maleta porque...
                }
                else
                {
                    this.maletas.Add(eq);
                }
                this.CalcularPrecioTotal();
                i++;
            }
        }
        public virtual void VenderTiquete()
        {
            if (this.Vuelo.EsInternacional)
            {
                if (this.Usuario.TienePasaporte)
                {
                    if(this.Vuelo.NumPasajeros < this.Vuelo.CupoMaximo)
                    {
                        // Tiquete vendido
                        // correr el método de precio total
                        this.Vuelo.NumPasajeros++;
                    }
                    else
                    {
                        // No hay más cupos
                    }
                }
                else
                {
                    // No puede viajar internacionalmente
                }
            }
            else
            {
                if (this.Vuelo.NumPasajeros < this.Vuelo.CupoMaximo)
                {
                    // Tiquete vendido
                    // correr el método de precio total
                    this.Vuelo.NumPasajeros++;
                }
                else
                {
                    // No hay más cupos
                }
            }
        }
    }
}
