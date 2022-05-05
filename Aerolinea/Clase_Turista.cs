using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Clase_Turista: Tiquete
    {
        public Clase_Turista(Vuelo vuelo, Usuario usuario) : base(vuelo, usuario) { }

        // Métodos
        public override void CalcularPrecioTotal()
        {
            this.PrecioTotal = this.PrecioBase + this.CobrarEquipaje();
        }
        public override int CobrarEquipaje()
        {
            int lim = 23;
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
