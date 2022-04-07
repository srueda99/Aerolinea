using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Clase_Ejecutiva: Tiquete
    {
        public Clase_Ejecutiva(Vuelo vuelo, Usuario usuario) : base(vuelo, usuario) { }

        // Métodos
        public override void CalcularPrecio()
        {
            this.PrecioTotal = (this.PrecioBase * 1.2) + this.CobrarEquipaje();
        }
        public override int CobrarEquipaje()
        {
            int lim = 32;
            int cobro = 0;
            foreach (Equipaje maleta in this.Maletas)
            {
                if (maleta.Peso > lim)
                {
                    cobro += (maleta.Peso - lim) * 5;
                }
            }
            return cobro;
        }
    }
}
