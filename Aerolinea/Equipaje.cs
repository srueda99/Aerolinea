using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea
{
    internal class Equipaje
    {
        // Atributos
        private bool esLegal;
        private int peso;
        private string contenido;
        Random random = new Random(Guid.NewGuid().GetHashCode());

        // Constructor
        public Equipaje()
        {
            this.Pesar();
            this.RevisarContenido();
        }

        // Propiedades
        public bool EsLegal { get => esLegal; private set => esLegal = value; }
        public int Peso { get => peso; private set => peso = value; }
        public string Contenido { get => contenido; private set => contenido = value; }

        // Métodos
        public void RevisarContenido()
        {
            try
            {
                int num = random.Next(1, 11);
                switch (num)
                {
                    case 1:
                        this.contenido = "Zapatos";
                        this.EsLegal = true;
                        break;
                    case 2:
                        this.contenido = "Buzos";
                        this.EsLegal = true;
                        break;
                    case 3:
                        this.contenido = "Marihuana";
                        this.EsLegal = false;
                        break;
                    case 4:
                        this.contenido = "Relojes";
                        this.EsLegal = true;
                        break;
                    case 5:
                        this.contenido = "Camisas";
                        this.EsLegal = true;
                        break;
                    case 6:
                        this.contenido = "Un niño muerto";
                        this.EsLegal = false;
                        break;
                    case 7:
                        this.contenido = "Comida";
                        this.EsLegal = true;
                        break;
                    case 8:
                        this.contenido = "Celulares";
                        this.EsLegal = true;
                        break;
                    case 9:
                        this.contenido = "Pantalones";
                        this.EsLegal = true;
                        break;
                    case 10:
                        this.contenido = "Computadores";
                        this.EsLegal = true;
                        break;
                    case 11:
                        this.contenido = "Armas";
                        this.EsLegal = false;
                        break;
                    default:
                        this.contenido = "otros";
                        this.EsLegal = true;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encontrado al revisar el contenido del equipaje: {0}", e);
            }
        }
        public void Pesar()
        {
            try
            {
                this.Peso = random.Next(15, 40);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error encontrado al pesar el equipaje: {0}", e);
            }
        }
    }
}
