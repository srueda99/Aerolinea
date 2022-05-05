using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Clase_Ejecutiva: Tiquete
    {
        public Clase_Ejecutiva(Vuelo vuelo, Usuario usuario) : base(vuelo, usuario)
        {
            this.Tipo = Tipos.Ejecutiva;
        }

        // Métodos
        public override void CalcularPrecioTotal()
        {
            this.PrecioTotal = (this.PrecioBase * 1.2) + this.CobrarEquipaje() + this.Multa;
        }
        public override int CobrarEquipaje()
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
        public override void VenderTiquete()
        {
            if (this.Vuelo.EsInternacional)
            {
                if (this.Usuario.TienePasaporte)
                {
                    if (this.Vuelo.NumPasajeros < this.Vuelo.CupoMaximo)
                    {
                        if (this.Usuario.EsEjecutivo)
                        {
                            // Tiquete vendido
                            this.Vuelo.NumPasajeros++;
                        }
                        else
                        {
                            // No es un usuario ejecutivo
                        }
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
                    if (this.Usuario.EsEjecutivo)
                    {
                        // Tiquete vendido
                        this.Vuelo.NumPasajeros++;
                    }
                    else
                    {
                        // No es un usuario ejecutivo
                    }
                }
                else
                {
                    // No hay más cupos
                }
            }
        }
    }
}
