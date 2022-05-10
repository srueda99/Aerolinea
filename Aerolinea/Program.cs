using System;
using Ops;

namespace Aerolinea
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ----- Carga la base de datos -----
            Ciudad.CargarCiudades();

            // ----- Imprime el menú -----
            int op = 0;
            while (op != 6)
            {
                Console.WriteLine("BIENVENIDO AL GESTOR DE TIQUETES DE PORT AIRWAYS");
                Console.WriteLine("===============================================");
                Console.WriteLine("Seleccione qué desea hacer: ");
                Console.WriteLine("1. Ver ciudades disponibles.");
                Console.WriteLine("2. Cotizar un vuelo.");
                Console.WriteLine("3. Registrarse.");
                Console.WriteLine("4. Hacer Check-In para un vuelo.");
                Console.WriteLine("5. Consulta tu facturación.");
                Console.WriteLine("6. Salir");
                Console.WriteLine("===============================================\n\n");
                bool ok = int.TryParse(Console.ReadLine(), out op);
                while (op < 1 || op > 6 || !ok)
                {
                    Console.WriteLine("Por favor, ingrese un número válido (1, 2, 3, 4, 5 ó 6).");
                    ok = int.TryParse(Console.ReadLine(), out op);
                }
                switch (op)
                {
                    case 1:
                        Ciudad.VerCiudades();
                        Console.WriteLine("*********************\n");
                        break;
                    case 2:
                        CotizarVuelo();
                        Console.WriteLine("*********************\n");
                        break;
                    case 3:
                        RegistrarUsuario();
                        Console.WriteLine("*********************\n");
                        break;
                    case 4:
                        CheckIn();
                        Console.WriteLine("*********************\n");
                        break;
                    case 5:
                        ConsultarFactura();
                        Console.WriteLine("*********************\n");
                        break;
                    default:
                        Console.WriteLine("Saliendo...");
                        break;
                }
            }
        }
        public static void CotizarVuelo()
        {
            try
            {
                // Ingresa ciudades de origen y destino y verifica que sean válidas
                string origen, destino;
                Console.WriteLine("Ingrese el nombre de la ciudad de ORIGEN.\nImportante: hacerlo con las iniciales en mayúscula y sin tildes (Ej. Medellin, Buenos Aires)");
                origen = Console.ReadLine();
                while (Ciudad.EncontrarCiudad(origen) == null)
                {
                    Console.WriteLine("No ofrecemos viajes desde esa ciudad, ingrese otra.");
                    origen = Console.ReadLine();
                }
                Ciudad ciudOrigen = Ciudad.EncontrarCiudad(origen);

                Console.WriteLine("Ingrese el nombre de la ciudad de DESTINO.\nImportante: hacerlo con las iniciales en mayúscula y sin tildes (Ej. Medellin, Buenos Aires)");
                destino = Console.ReadLine();
                while (Ciudad.EncontrarCiudad(destino) == null)
                {
                    Console.WriteLine("No ofrecemos viajes para esa ciudad, ingrese otra.");
                    destino = Console.ReadLine();
                }
                Ciudad ciudDestino = Ciudad.EncontrarCiudad(destino);

                // Verifica si hay un vuelo existente, sino, lo crea
                Vuelo vueloCotizar;
                if (Vuelo.EncontrarVuelo(ciudOrigen, ciudDestino) == null)
                {
                    vueloCotizar = new Vuelo(ciudOrigen, ciudDestino);
                }
                else
                {
                    vueloCotizar = Vuelo.EncontrarVuelo(ciudOrigen, ciudDestino);
                }

                // Elige el tipo de tiquete para hacer la cotización
                int op;
                double precio;
                bool ok;
                Tiquete tiqCotizar = null;
                Console.WriteLine("Elija el tipo de tiquete:");
                Console.WriteLine("1. Primera Clase");
                Console.WriteLine("2. Clase Ejecutiva");
                Console.WriteLine("3. Clase Turista");
                ok = int.TryParse(Console.ReadLine(), out op);
                while (op < 1 || op > 3 || !ok)
                {
                    Console.WriteLine("Ingrese un número válido.");
                    ok = int.TryParse(Console.ReadLine(), out op);
                }
                switch (op)
                {
                    case 1:
                        tiqCotizar = new Primera_Clase(vueloCotizar, null);
                        break;
                    case 2:
                        tiqCotizar = new Clase_Ejecutiva(vueloCotizar, null);
                        break;
                    case 3:
                        tiqCotizar = new Clase_Turista(vueloCotizar, null);
                        break;
                }
                tiqCotizar.CalcularPrecioTotal();

                // Elige el formato en que será mostrado el precio
                Console.WriteLine("Elija la moneda en que se va a mostrar:");
                Console.WriteLine("1. Dólares Estadounidenses");
                Console.WriteLine("2. Pesos Colombianos");
                ok = int.TryParse(Console.ReadLine(), out op);
                while (op < 1 || op > 2 || !ok)
                {
                    Console.WriteLine("Ingrese un número válido.");
                    ok = int.TryParse(Console.ReadLine(), out op);
                }
                switch (op)
                {
                    case 1:
                        precio = Math.Round(tiqCotizar.PrecioTotal, 0);
                        Console.WriteLine("\nEl vuelo desde {0} hasta {1}, costaría: ${2} USD", origen, destino, precio);
                        Console.WriteLine("Sin incluir costos adicionales.");
                        break;
                    case 2:
                        precio = Math.Round(Conversion.ConvertirPesos(tiqCotizar.PrecioTotal));
                        Console.WriteLine("\nEl vuelo desde {0} hasta {1}, costaría: ${2} COP", origen, destino, precio);
                        Console.WriteLine("Sin incluir costos adicionales.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo sucedió al cotizar: {0}", e.Message);
            }
        }
        public static void RegistrarUsuario()
        {
            try
            {
                //Verifica si el usuario existe, sino, lo crea.
                Console.Write("Ingrese su cédula: ");
                string cedula = Console.ReadLine();
                if (Usuario.EncontrarUsuario(cedula) != null)
                {
                    Console.WriteLine("El usuario ya se encuentra registrado.");
                }
                else
                {
                    string nombre;
                    string sn;
                    bool pasaporte;
                    bool ejecutivo;

                    Console.Write("Ingrese su nombre: ");
                    nombre = Console.ReadLine();

                    Console.WriteLine("¿Cuenta con Pasaporte? S/N");
                    sn = Console.ReadLine();
                    while (!string.Equals(sn, "S") && !string.Equals(sn, "N"))
                    {
                        Console.WriteLine("Escriba S o N");
                        sn = Console.ReadLine();
                    }
                    if (string.Equals(sn, "S"))
                    {
                        pasaporte = true;
                    }
                    else
                    {
                        pasaporte = false;
                    }

                    Console.WriteLine("¿Es Ejecutivo? S/N");
                    sn = Console.ReadLine();
                    while (!string.Equals(sn, "S") && !string.Equals(sn, "N"))
                    {
                        Console.WriteLine("Escriba S o N");
                        sn = Console.ReadLine();
                    }
                    if (string.Equals(sn, "S"))
                    {
                        ejecutivo = true;
                    }
                    else
                    {
                        ejecutivo = false;
                    }

                    Usuario nuevoUsuario = new Usuario(nombre, cedula, pasaporte, ejecutivo);
                    Console.WriteLine("Usuario registrado exitosamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo sucedió al registrarse: {0}", e.Message);
            }
        }
        public static void CheckIn()
        {
            try
            {
                Usuario cliente;
                Ciudad orgn;
                Ciudad dest;
                Vuelo viaje;
                Tiquete tiq = null;
                IImpresion impresion = null;
                double precio;

                // Verifica que el usuario exista, sino, lo crea.
                Console.Write("Ingrese su cédula: ");
                string cedula = Console.ReadLine();
                if (Usuario.EncontrarUsuario(cedula) == null)
                {
                    Console.WriteLine("No se encuentra registrado aún, primero haremos el proceso de registro.");
                    RegistrarUsuario();
                }
                cliente = Usuario.EncontrarUsuario(cedula);

                // Ingresa ciudades de origen y destino y verifica que sean válidas
                string origen, destino;
                Console.WriteLine("Ingrese el nombre de la ciudad de ORIGEN.\nImportante: hacerlo con las iniciales en mayúscula y sin tildes (Ej. Medellin, Buenos Aires)");
                origen = Console.ReadLine();
                while (Ciudad.EncontrarCiudad(origen) == null)
                {
                    Console.WriteLine("No ofrecemos viajes desde esa ciudad, ingrese otra.");
                    origen = Console.ReadLine();
                }
                orgn = Ciudad.EncontrarCiudad(origen);

                Console.WriteLine("Ingrese el nombre de la ciudad de DESTINO.\nImportante: hacerlo con las iniciales en mayúscula y sin tildes (Ej. Medellin, Buenos Aires)");
                destino = Console.ReadLine();
                while (Ciudad.EncontrarCiudad(destino) == null)
                {
                    Console.WriteLine("No ofrecemos viajes para esa ciudad, ingrese otra.");
                    destino = Console.ReadLine();
                }
                dest = Ciudad.EncontrarCiudad(destino);

                // Verifica si hay un vuelo existente, sino, lo crea
                if (Vuelo.EncontrarVuelo(orgn, dest) == null)
                {
                    viaje = new Vuelo(orgn, dest);
                }
                else
                {
                    viaje = Vuelo.EncontrarVuelo(orgn, dest);
                }

                // Elige el tipo de tiquete que va a comprar
                int num;
                bool ok;
                Console.WriteLine("Elija el tipo de tiquete que va a comprar:");
                Console.WriteLine("1. Primera Clase");
                Console.WriteLine("2. Clase Ejecutiva");
                Console.WriteLine("3. Clase Turista");
                ok = int.TryParse(Console.ReadLine(), out num);
                while (num < 1 || num > 3 || !ok)
                {
                    Console.WriteLine("Ingrese un número válido.");
                    ok = int.TryParse(Console.ReadLine(), out num);
                }
                switch (num)
                {
                    case 1:
                        tiq = new Primera_Clase(viaje, cliente);
                        impresion = new Primera();
                        break;
                    case 2:
                        tiq = new Clase_Ejecutiva(viaje, cliente);
                        impresion = new Ejecutiva();
                        break;
                    case 3:
                        tiq = new Clase_Turista(viaje, cliente);
                        impresion = new Turista();
                        break;
                }

                // Se registra y cobra el equipaje
                Console.WriteLine("¿Cuántas maletas lleva? Tenga en cuenta que si lleva más de 2 se le cobrará un costo adicional.");
                ok = int.TryParse(Console.ReadLine(), out num);
                while (!ok)
                {
                    Console.WriteLine("Ingrese un número.");
                    ok = int.TryParse(Console.ReadLine(), out num);
                }
                tiq.AggEquipaje(num);
                Console.WriteLine("Equipaje registrado.");
                Console.WriteLine("Se le ha cobrado ${0} USD de recargos por equipaje y ${1} USD por multas.", tiq.CobrarEquipaje(), tiq.Multa);

                // Elige el formato en que será mostrado el precio
                Console.WriteLine("Elija la moneda en la que quiere ver el costo final:");
                Console.WriteLine("1. Dólares Estadounidenses");
                Console.WriteLine("2. Pesos Colombianos");
                ok = int.TryParse(Console.ReadLine(), out num);
                while (num < 1 || num > 2 || !ok)
                {
                    Console.WriteLine("Ingrese un número válido.");
                    ok = int.TryParse(Console.ReadLine(), out num);
                }
                switch (num)
                {
                    case 1:
                        precio = Math.Round(tiq.PrecioTotal, 0);
                        Console.WriteLine("\nEl costo final de su vuelo desde {0} hasta {1}, es de: ${2} USD", origen, destino, precio);
                        break;
                    case 2:
                        precio = Math.Round(Conversion.ConvertirPesos(tiq.PrecioTotal));
                        Console.WriteLine("\nEl costo final de su vuelo desde {0} hasta {1}, es de: ${2} COP", origen, destino, precio);
                        break;
                }

                // Confirmación e impresión del tiquete
                string sn;
                Console.WriteLine("-------------------------");
                Console.WriteLine("¿Desea confirmar el pago? S/N");
                sn = Console.ReadLine();
                while (!string.Equals(sn, "S") && !string.Equals(sn, "N"))
                {
                    Console.WriteLine("Escriba S o N");
                    sn = Console.ReadLine();
                }
                if (string.Equals(sn, "S"))
                {
                    if (tiq.VenderTiquete())
                    {
                        impresion.ImprimirTiquete();
                        Console.WriteLine(tiq.ToString());
                        Console.WriteLine("Su tiquete ha sido generado en un archivo de texto, ¡¡Gracias por confiar en nosotros!!");
                    }
                    else
                    {
                        Console.WriteLine("Debe comenzar el proceso de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Entendible, buen día.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo sucedió al hacer el check-in: {0}", e.Message);
            }
        }
        public static void ConsultarFactura()
        {
            try
            {
                Usuario cliente;

                // Verifica que el usuario exista, sino, lo crea.
                Console.Write("Ingrese su cédula: ");
                string cedula = Console.ReadLine();
                if (Usuario.EncontrarUsuario(cedula) != null)
                {
                    cliente = Usuario.EncontrarUsuario(cedula);
                    if (cliente.Tiquete == null)
                    {
                        Console.WriteLine("No tiene ninguna factura a su nombre.");
                    }
                    else
                    {
                        Console.WriteLine(cliente.Tiquete.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("El usuario no se encuentra registrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo pasó localizando la factura: {0}", e);
            }
        }
    }
}
