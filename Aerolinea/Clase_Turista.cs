using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Clase_Turista : Tiquete
    {
        public Clase_Turista(Vuelo vuelo, Usuario usuario) : base(vuelo, usuario)
        {
            this.Tipo = Tipos.Turista;
        }

        // Métodos
        public override void CalcularPrecioTotal()
        {
            try
            {
                this.PrecioTotal = this.PrecioBase + this.CobrarEquipaje() + this.Multa;
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
                int lim = 23;
                int cobro = 0;
                if (this.Maletas.Count > 2)
                {
                    cobro = (this.Maletas.Count - 2) * 20;
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
    }
}
