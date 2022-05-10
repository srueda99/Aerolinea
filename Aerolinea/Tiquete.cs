using System;
using System.Collections.Generic;

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
            this.PrecioBase = this.Vuelo.CostoViaje;
            this.Multa = 0;
            this.CalcularPrecioTotal();
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
            try
            {
                int i = 0;
                Equipaje eq;
                while (i < numMaletas)
                {
                    eq = new Equipaje();
                    if (!eq.EsLegal)
                    {
                        this.Multa += 1000;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Una de sus maletas no se pudo registrar ya que contiene {0}, se le cobrará una multa de $1000 USD", eq.Contenido);
                    }
                    else
                    {
                        this.maletas.Add(eq);
                    }
                    this.CalcularPrecioTotal();
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado registrar el equipaje: {0}", e.Message);
            }
        }
        public virtual bool VenderTiquete()
        {
            try
            {
                if (this.Vuelo.EsInternacional)
                {
                    if (this.Usuario.TienePasaporte)
                    {
                        if (this.Vuelo.NumPasajeros < this.Vuelo.CupoMaximo)
                        {
                            this.CalcularPrecioTotal();
                            this.Usuario.Tiquete = this;
                            this.Vuelo.NumPasajeros++;
                            return true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("No puede comprar el tiquete porque ya no hay asientos disponibles en el avión.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("No puede comprar tiquetes para vuelos internacionales sin pasaporte.");
                        return false;
                    }
                }
                else
                {
                    if (this.Vuelo.NumPasajeros < this.Vuelo.CupoMaximo)
                    {
                        this.CalcularPrecioTotal();
                        this.Usuario.Tiquete = this;
                        this.Vuelo.NumPasajeros++;
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("No puede comprar el tiquete porque ya no hay asientos disponibles en el avión.");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al vender el tiquete: {0}", e.Message);
                return false;
            }
        }
        public override string ToString()
        {
            return "Tiquete de tipo " + this.Tipo + "\n" +
                    "Usuario: " + this.Usuario.Nombre + "\n" +
                    "Ciudad partida: " + this.Vuelo.Origen.Nombre + "\n" +
                    "Ciudad llegada: " + this.Vuelo.Destino.Nombre + "\n" +
                    "Costo base: " + Math.Round(this.PrecioBase, 0) + "\n" +
                    "Costo equipaje: " + this.CobrarEquipaje() + "\n" +
                    "Multas: " + this.Multa + "\n" +
                    "---------------------------------" + "\n" +
                    "Total: " + Math.Round(this.PrecioTotal, 0);
                
        }
    }
}
