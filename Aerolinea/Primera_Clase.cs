using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Primera_Clase: Tiquete
    {
        public Primera_Clase(Vuelo vuelo): base(vuelo)
        {
            // Se sobreescriben los métodos que estén en virtual de la clase padre
        }
    }
}
