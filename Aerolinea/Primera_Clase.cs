using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Primera_Clase: Tiquete
    {
        public Primera_Clase(Vuelo vuelo, Usuario usuario): base(vuelo, usuario)
        {
            this.Tipo = Tipos.Primera;
        }

        // Métodos
        public override void CalcularPrecioTotal()
        {
            this.PrecioTotal = (this.PrecioBase * 1.6) + this.CobrarEquipaje() + this.Multa;
        }
        public override int CobrarEquipaje()
        {
            int cobro = 0;
            if (this.Maletas.Count > 2)
            {
                cobro = (this.Maletas.Count - 2)*30;
            }
            return cobro;
        }
    }
}
