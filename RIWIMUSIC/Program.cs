using RIWIMUSIC.Models;

namespace RIWIMUSIC;

public class Program
{
    static List<Concierto> conciertos = new List<Concierto>();
    static List<Cliente> clientes = new List<Cliente>();
    static List<Compra> compras = new List<Compra>();

    //Contadores

    static int ProximoConciertoId = 1;
    static int ProximoClienteId = 1;
    static int ProximaCompraId = 1;


    static void Main(string[] args)
    {
        MostrarMenuPrincipal();
    }

    static void MostrarMenuPrincipal()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE GESTIÓN RIWIMUSIC   ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.WriteLine("1. Gestión de Conciertos");
            Console.WriteLine("2. Gestión de Clientes");
            Console.WriteLine("3. Gestión de Tiquetes");
            Console.WriteLine("4. Historial de Compras");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GestionConciertos();
                    break;
                case "2":
                    GestionClientes();
                    break;
                case "3":
                    GestionTiquetes();
                    break;
                case "4":
                    HistorialCompras();
                    break;
                case "5":
                    continuar = false;
                    Console.WriteLine("Saliendo del sistema. ¡BYE BYE!");
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }

        }
    }

    static void GestionConciertos()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("---Gestion Conciertos ---");
            Console.WriteLine("1. Registrar Concierto");
            Console.WriteLine("2. Listar Conciertos");
            Console.WriteLine("3. Editar Concierto");
            Console.WriteLine("4. Eliminar Concierto");
            Console.WriteLine("5. Volver al menu principal");
            Console.WriteLine("\nSeleccione una opcion: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarConcierto();
                    break;
                case "2":
                    ListarConciertos();
                    break;
                case "3":
                    EditarConcierto();
                    break;
                case "4":
                    EliminarConcierto();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida.  Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RegistrarConcierto()
    {
        Console.Clear();
        Console.WriteLine("---Registrar Nuevo Concierto ---");
        var concierto = new Concierto();
        concierto.Id = ProximoConciertoId++;

        Console.WriteLine("Nombre del concierto: ");
        concierto.Nombre = Console.ReadLine();

        Console.WriteLine("Artista del concierto: ");
        concierto.Artista = Console.ReadLine();

        Console.WriteLine("fecha del concierto (YYYY/MM/DD): ");
        DateTime fecha;
        while (!DateTime.TryParse(Console.ReadLine(), out fecha))
        {
            Console.WriteLine("Formato incorrecto!!!. Intente de nuevo (YYYY/MM/DD).");
        }
        concierto.Fecha = fecha;

        Console.WriteLine("lugar concierto: ");
        concierto.Lugar = Console.ReadLine();

        //implementacion simple para el precio, sin validacion
        Console.WriteLine("precio: ");
        decimal precio;
        while (!decimal.TryParse(Console.ReadLine(), out precio))
        {
            Console.WriteLine("Formato de precio incorrecto!!!. Intente de nuevo.");
        }
        concierto.Precio = precio;

        conciertos.Add(concierto);
        Console.WriteLine("\nConcierto registrado exitosamente.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarConciertos()
    {
        Console.Clear();
        Console.WriteLine("---Listado Conciertos ---");
        if (conciertos.Count == 0)
        {
            Console.WriteLine("No conciertos registrados");
        }
        else
        {
            foreach (var c in conciertos)
            {
                Console.WriteLine(
                    $"ID: {c.Id}, Nombre: {c.Nombre}, Artista: {c.Artista},  Fecha: {c.Fecha.ToShortDateString()}, Lugar: {c.Lugar}, Precio: {c.Precio:C}");
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();


    }

    static void EditarConcierto()
    {
        Console.Clear();
        Console.WriteLine("---Editar Concierto ---");
        Console.WriteLine("Ingrese el ID del concierto a editar: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            var concierto = conciertos.FirstOrDefault(c => c.Id == id);
            if (concierto != null)
            {
                Console.WriteLine($"Concierto encontrado: {concierto.Nombre}");
                Console.WriteLine("Nuevo nombre del concierto: ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    concierto.Nombre = nuevoNombre;
                }

                Console.WriteLine("Concierto editado exitosamente.");
            }
            else
            {
                Console.WriteLine("Concierto no existe");
            }
        }
        else
        {
            Console.WriteLine("ID no valido Ingresa un ID valido");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void EliminarConcierto()
    {
        Console.WriteLine("---Eliminar Concierto ---");
        Console.WriteLine("Ingrese el ID del concierto eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            var concierto = conciertos.FirstOrDefault(c => c.Id == id);
            if (concierto != null)
            {
                conciertos.Remove(concierto);
                Console.WriteLine("Concierto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Concierto no encontrado");
            }
        }
        else
        {
            Console.WriteLine("ID no valido Ingresa un ID valido");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void GestionClientes()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("---Gestion Clientes ---");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Editar cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("5. Volver al menu principal");
            Console.WriteLine("\nSeleccione una Opcion: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    EditarCliente();
                    break;
                case "4":
                    EliminarCliente();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RegistrarCliente()
    {
        Console.Clear();
        Console.WriteLine("---Registrar nuevo cliente ---");
        var cliente = new Cliente();
        cliente.Id = ProximoClienteId++;
        Console.WriteLine("Ingrese el nombre del cliente: ");
        cliente.Nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el Email del cliente: ");
        cliente.Email = Console.ReadLine();
        Console.WriteLine("Ingrese el Telefono del cliente: ");
        cliente.Telefono = Console.ReadLine();
        clientes.Add(cliente);
        Console.WriteLine("\nCliente registrado exitosamente ");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("---Listar clientes ---");
        if (clientes.Count == 0)
        {
            Console.WriteLine("No clientes registrados");
        }
        else
        {
            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Email: {c.Email}, Telefono: {c.Telefono}");
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void EditarCliente()
    {
        Console.Clear();
        Console.WriteLine("---Editar cliente ---");
        Console.WriteLine("Ingrese el ID del cliente a editar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente.Nombre}");
                Console.WriteLine("Nuevo nombre del cliente:      ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    cliente.Nombre = nuevoNombre;
                }
                Console.WriteLine("Nuevo Email:          ");
                string nuevoEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace((nuevoEmail)))
                {
                    cliente.Email = nuevoEmail;
                }

                Console.WriteLine("Cliente editado exitosamente");

            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }
        else
        {
            Console.WriteLine("ID no valido Ingresa un ID valido");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void EliminarCliente()
    {
        Console.Clear();
        Console.WriteLine("---Eliminar cliente ---");
        Console.WriteLine("Ingrese el ID del cliente a eliminar:  ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente eliminado exitosamente");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }
        else
        {
            Console.WriteLine("ID no valido Ingresa un ID valido");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void GestionTiquetes()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("---Gestion Tiquetes ---");
            Console.WriteLine("1. Registrar compra de tiquete");
            Console.WriteLine("2. Listar tiquetes vendidos");
            Console.WriteLine("3. Editar compra de tiquete");
            Console.WriteLine("4. Eliminar compra de tiquete");
            Console.WriteLine("5. Volver al menu principal");
            Console.WriteLine("\nSeleccione una opcion");

            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    RegistrarCompraTiquete();
                    break;
                case "2":
                    ListarTiquetesVendidos();
                    break;
                case "3":
                    EditarCompra();
                    break;
                case "4":
                    EliminarCompra();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void RegistrarCompraTiquete()
    {
        Console.Clear();
        Console.WriteLine("--- Registrar Compra de Tiquete ---");


        int clienteId = 0;
        int conciertoId = 0;
        int cantidad = 0;

        Console.Write("Ingrese el ID del cliente: ");
        if (!int.TryParse(Console.ReadLine(), out clienteId))
        {
            Console.WriteLine("ID de cliente no válido.");
            return;
        }


        var cliente = clientes.FirstOrDefault(c => c.Id == clienteId);
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        Console.Write("Ingrese el ID del concierto: ");
        if (!int.TryParse(Console.ReadLine(), out conciertoId))
        {
            Console.WriteLine("ID de concierto no válido.");
            return;
        }


        var concierto = conciertos.FirstOrDefault(c => c.Id == conciertoId);
        if (concierto == null)
        {
            Console.WriteLine("Concierto no encontrado.");
            return;
        }

        Console.Write("Cantidad de tiquetes a comprar: ");
        if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Cantidad no válida.");
            return;
        }

        var compra = new Compra
        {
            Id = ProximaCompraId++,
            ClienteId = cliente.Id,
            ConciertoId = concierto.Id,
            Cantidad = cantidad,
            FechaCompra = DateTime.Now
        };

        compras.Add(compra);


        Console.WriteLine($"\nCompra registrada exitosamente para el cliente {cliente.Nombre} para el concierto {concierto.Nombre}.");
        Console.WriteLine($"Total a pagar: {concierto.Precio * cantidad:C}");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarTiquetesVendidos()
    {
        Console.Clear();
        Console.WriteLine("--- Listar Tiquetes Vendidos ---");
        if (compras.Count == 0)
        {
            Console.WriteLine("No se han realizado compras aun.");
        }
        else
        {
            foreach (var compra in compras)
            {
                var cliente = clientes.FirstOrDefault(c => c.Id == compra.ClienteId);
                var concierto = conciertos.FirstOrDefault(c => c.Id == compra.ConciertoId);
                if (cliente != null && concierto != null)
                {
                    Console.WriteLine($"ID compra: {compra.Id}, Cliente: {cliente.Nombre}, Concierto: {concierto.Nombre}, Cantidad: {compra.Cantidad}, Fecha:  {compra.FechaCompra.ToShortDateString()}");
                }
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar... ");
        Console.ReadKey();
    }

    static void EditarCompra()
    {
        Console.Clear();
        Console.WriteLine("--- Editar Compra ---");
        Console.Write("Ingrese el ID del compra: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            var compra = compras.FirstOrDefault(c => c.Id == id);
            if (compra != null)
            {
                Console.WriteLine($"Compra encontrado: Cliente ID {compra.ClienteId}, Concierto ID {compra.ConciertoId}");
                Console.WriteLine("Nueva cantidad de tiquetes               ");
                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad) && nuevaCantidad > 0)
                {
                    compra.Cantidad = nuevaCantidad;
                }

                Console.WriteLine("Compra editada exitosamente");
            }
            else
            {
                Console.WriteLine("Compra no encontrada");
            }
        }
        else
        {
            Console.WriteLine("ID no valido");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void EliminarCompra()
    {
        Console.Clear();
        Console.WriteLine("---Eliminar Compra---");
        Console.WriteLine("Ingrese el ID de la compra que quieres eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var compra = compras.FirstOrDefault(c => c.Id == id);
            if (compra != null)
            {
                compras.Remove(compra);
                Console.WriteLine("Compra eliminada exitosamente");
            }
            else
            {
                Console.WriteLine("Compra no encontrada");
            }
        }
        else
        {
            Console.WriteLine("ID no valido");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();

    }

    static void HistorialCompras()
    {
        Console.Clear();
        Console.WriteLine("---Historial de compras de un cliente---");
        Console.WriteLine("Ingrese el ID del cliente: ");
        if (int.TryParse(Console.ReadLine(), out int clienteId))
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == clienteId);
            if (cliente != null)
            {
                Console.WriteLine($"\nHistorial de compras para: {cliente.Nombre}");
                var comprasCliente = compras.Where(c => c.ClienteId == clienteId).ToList();
                if (comprasCliente.Count == 0)
                {
                    Console.WriteLine("Este cliente no ah realizado compras.");
                }
                else
                {
                    foreach (var compra in comprasCliente)
                    {
                        var concierto = conciertos.FirstOrDefault(c => c.Id == compra.ConciertoId);
                        if (concierto != null)
                        {
                            Console.WriteLine($"Compra ID: {compra.Id}, Concierto: {concierto.Nombre}, Cantidad: {compra.Cantidad}, Fecha: {compra.FechaCompra.ToShortDateString()}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }
        else
        {
            Console.WriteLine("ID no valido");
        }
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
   
}