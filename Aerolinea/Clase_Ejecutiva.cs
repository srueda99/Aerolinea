using System;

namespace Aerolinea
{
    internal class Clase_Ejecutiva : Tiquete
    {
        public Clase_Ejecutiva(Vuelo vuelo, Usuario usuario) : base(vuelo, usuario)
        {
            this.Tipo = Tipos.Ejecutiva;
        }

        // Métodos
        public override void CalcularPrecioTotal()
        {
            try
            {
                this.PrecioTotal = (this.PrecioBase * 1.2) + this.CobrarEquipaje() + this.Multa;
            }
            catch (Exception e)
            { 
                Console.WriteLine("Error encontrado al calcular el precio total: {0}", e.Message);
            }
        }
        public override int CobrarEquipaje()
        {
            try
            {
                int lim = 30;
                int cobro = 0;
                if (this.Maletas.Count > 2)
                {
                    cobro = (this.Maletas.Count - 2) * 25;
                }
                foreach (Equipaje maleta in this.Maletas)
                {
                    if (maleta.Peso > lim)
                    {
                        cobro += (maleta.Peso - lim) * 5;
                    }
                }
                return cobro;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al cobrar el equipaje: {0}", e.Message);
                return -1;
            }
        }
        public override bool VenderTiquete()
        {
            try
            {
                if (this.Vuelo.EsInternacional)
                {
                    if (this.Usuario.TienePasaporte)
                    {
                        if (this.Vuelo.NumPasajeros < this.Vuelo.CupoMaximo)
                        {
                            if (this.Usuario.EsEjecutivo)
                            {
                                this.CalcularPrecioTotal();
                                this.Usuario.Tiquete = this;
                                this.Vuelo.NumPasajeros++;
                                return true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("No puede comprar el tiquete porque no es un usuario de tipo Ejecutivo.");
                                return false;
                            }
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
                        if (this.Usuario.EsEjecutivo)
                        {
                            this.CalcularPrecioTotal();
                            this.Usuario.Tiquete = this;
                            this.Vuelo.NumPasajeros++;
                            return true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("No puede comprar el tiquete porque no es un usuario de tipo Ejecutivo.");
                            return false;
                        }
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
    }
}
