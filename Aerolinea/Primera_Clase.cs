using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Primera_Clase : Tiquete
    {
        public Primera_Clase(Vuelo vuelo, Usuario usuario) : base(vuelo, usuario)
        {
            this.Tipo = Tipos.Primera;
        }

        // Métodos
        public override void CalcularPrecioTotal()
        {
            try
            {
                this.PrecioTotal = (this.PrecioBase * 1.6) + this.CobrarEquipaje() + this.Multa;
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
                int cobro = 0;
                if (this.Maletas.Count > 2)
                {
                    cobro = (this.Maletas.Count - 2) * 30;
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
