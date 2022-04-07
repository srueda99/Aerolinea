using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Primera_Clase: Tiquete
    {
        public Primera_Clase(Vuelo vuelo, Usuario usuario): base(vuelo, usuario) { }

        // Métodos
        public override void CalcularPrecio()
        {
            this.PrecioTotal = (this.PrecioBase * 1.5) + this.CobrarEquipaje();
        }
        public override int CobrarEquipaje()
        {
            int cobro = 0;
            return cobro;
        }
    }
}
