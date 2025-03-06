using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGICA;
using ENTIDADES;

namespace PRESENTACION
{
    class Program
    {
        private static GestorHuespedes gestorHuespedes = new GestorHuespedes();
        private static GestorHabitaciones gestorHabitaciones = new GestorHabitaciones();
        private static GestorReservas gestorReservas = new GestorReservas();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE HOTEL ===");
                Console.WriteLine("1. Gestión de Huéspedes");
                Console.WriteLine("2. Gestión de Habitaciones");
                Console.WriteLine("3. Gestión de Reservas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuHuespedes();
                        break;
                    case "2":
                        MenuHabitaciones();
                        break;
                    case "3":
                        MenuReservas();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuHuespedes()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE HUÉSPEDES ===");
                Console.WriteLine("1. Registrar nuevo huésped");
                Console.WriteLine("2. Buscar huésped por cédula");
                Console.WriteLine("3. Listar todos los huéspedes");
                Console.WriteLine("4. Buscar huéspedes por apellido");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarHuesped();
                        break;
                    case "2":
                        BuscarHuespedPorCedula();
                        break;
                    case "3":
                        ListarHuespedes();
                        break;
                    case "4":
                        BuscarHuespedesPorApellido();
                        break;
                    case "5":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RegistrarHuesped()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO HUÉSPED ===");

            try
            {
                Console.Write("Cédula: ");
                int cedula = int.Parse(Console.ReadLine());

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();

                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine();

                gestorHuespedes.RegistrarHuesped(cedula, nombre, apellido, telefono);
                Console.WriteLine("Huésped registrado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarHuespedPorCedula()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR HUÉSPED POR CÉDULA ===");

            try
            {
                Console.Write("Ingrese la cédula: ");
                int cedula = int.Parse(Console.ReadLine());

                huespedes huesped = gestorHuespedes.BuscarHuespedPorCedula(cedula);

                if (huesped != null)
                {
                    Console.WriteLine($"Cédula: {huesped.cedula}");
                    Console.WriteLine($"Nombre: {huesped.Nombre}");
                    Console.WriteLine($"Apellido: {huesped.apellido}");
                    Console.WriteLine($"Teléfono: {huesped.Telefono}");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún huésped con esa cédula.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ListarHuespedes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE HUÉSPEDES ===");

            List<huespedes> listaHuespedes = gestorHuespedes.ObtenerTodosLosHuespedes();

            if (listaHuespedes.Count > 0)
            {
                Console.WriteLine("CÉDULA\tNOMBRE\tAPELLIDO\tTELÉFONO");
                Console.WriteLine("------------------------------------------------------");

                foreach (huespedes huesped in listaHuespedes)
                {
                    Console.WriteLine($"{huesped.cedula}\t{huesped.Nombre}\t{huesped.apellido}\t{huesped.Telefono}");
                }
            }
            else
            {
                Console.WriteLine("No hay huéspedes registrados.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarHuespedesPorApellido()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR HUÉSPEDES POR APELLIDO ===");

            Console.Write("Ingrese el apellido (o parte de él): ");
            string apellido = Console.ReadLine();

            List<huespedes> huespedes = gestorHuespedes.BuscarHuespedesPorApellido(apellido);

            if (huespedes.Count > 0)
            {
                Console.WriteLine("CÉDULA\tNOMBRE\tAPELLIDO\tTELÉFONO");
                Console.WriteLine("------------------------------------------------------");

                foreach (huespedes huesped in huespedes)
                {
                    Console.WriteLine($"{huesped.cedula}\t{huesped.Nombre}\t{huesped.apellido}\t{huesped.Telefono}");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron huéspedes con el apellido '{apellido}'.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MenuHabitaciones()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE HABITACIONES ===");
                Console.WriteLine("1. Registrar nueva habitación");
                Console.WriteLine("2. Buscar habitación por ID");
                Console.WriteLine("3. Listar todas las habitaciones");
                Console.WriteLine("4. Filtrar habitaciones por categoría");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarHabitacion();
                        break;
                    case "2":
                        BuscarHabitacionPorId();
                        break;
                    case "3":
                        ListarHabitaciones();
                        break;
                    case "4":
                        FiltrarHabitacionesPorCategoria();
                        break;
                    case "5":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RegistrarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVA HABITACIÓN ===");

            try
            {
                Console.Write("ID de la habitación: ");
                int idHabitacion = int.Parse(Console.ReadLine());

                Console.Write("Categoría (Económica, Estándar o Suite): ");
                string categoria = Console.ReadLine();

                Console.Write("Precio por noche: ");
                decimal precioPorNoche = decimal.Parse(Console.ReadLine());

                gestorHabitaciones.RegistrarHabitacion(idHabitacion, categoria, precioPorNoche);
                Console.WriteLine("Habitación registrada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarHabitacionPorId()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR HABITACIÓN POR ID ===");

            try
            {
                Console.Write("Ingrese el ID de la habitación: ");
                int idHabitacion = int.Parse(Console.ReadLine());

                habitaciones habitacion = gestorHabitaciones.BuscarHabitacionPorId(idHabitacion);

                if (habitacion != null)
                {
                    Console.WriteLine($"ID: {habitacion.IdHabitacion}");
                    Console.WriteLine($"Categoría: {habitacion.Categoria}");
                    Console.WriteLine($"Precio por noche: ${habitacion.PrecioPorNoche}");
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna habitación con ese ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ListarHabitaciones()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE HABITACIONES ===");

            List<habitaciones> listaHabitaciones = gestorHabitaciones.ObtenerTodasLasHabitaciones();

            if (listaHabitaciones.Count > 0)
            {
                Console.WriteLine("ID\tCATEGORÍA\tPRECIO POR NOCHE");
                Console.WriteLine("------------------------------------------------------");

                foreach (habitaciones habitacion in listaHabitaciones)
                {
                    Console.WriteLine($"{habitacion.IdHabitacion}\t{habitacion.Categoria}\t${habitacion.PrecioPorNoche}");
                }
            }
            else
            {
                Console.WriteLine("No hay habitaciones registradas.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void FiltrarHabitacionesPorCategoria()
        {
            Console.Clear();
            Console.WriteLine("=== FILTRAR HABITACIONES POR CATEGORÍA ===");

            Console.Write("Ingrese la categoría (Económica, Estándar o Suite): ");
            string categoria = Console.ReadLine();

            List<habitaciones> habitaciones = gestorHabitaciones.FiltrarHabitacionesPorCategoria(categoria);

            if (habitaciones.Count > 0)
            {
                Console.WriteLine("ID\tCATEGORÍA\tPRECIO POR NOCHE");
                Console.WriteLine("------------------------------------------------------");

                foreach (habitaciones habitacion in habitaciones)
                {
                    Console.WriteLine($"{habitacion.IdHabitacion}\t{habitacion.Categoria}\t${habitacion.PrecioPorNoche}");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron habitaciones de la categoría '{categoria}'.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MenuReservas()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE RESERVAS ===");
                Console.WriteLine("1. Crear nueva reserva");
                Console.WriteLine("2. Listar todas las reservas");
                Console.WriteLine("3. Buscar reservas por huésped");
                Console.WriteLine("4. Calcular costo de reserva");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearReserva();
                        break;
                    case "2":
                        ListarReservas();
                        break;
                    case "3":
                        BuscarReservasPorHuesped();
                        break;
                    case "4":
                        CalcularCostoReserva();
                        break;
                    case "5":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CrearReserva()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR NUEVA RESERVA ===");

            try
            {
                Console.Write("ID de la reserva: ");
                int idReserva = int.Parse(Console.ReadLine());

                Console.Write("Cédula del huésped: ");
                int cedulaHuesped = int.Parse(Console.ReadLine());

                // Verificar si existe el huésped
                huespedes huesped = gestorHuespedes.BuscarHuespedPorCedula(cedulaHuesped);
                if (huesped == null)
                {
                    Console.WriteLine($"No existe un huésped con la cédula {cedulaHuesped}. ¿Desea registrarlo? (S/N)");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine();

                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();

                        gestorHuespedes.RegistrarHuesped(cedulaHuesped, nombre, apellido, telefono);
                        Console.WriteLine("Huésped registrado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                }

                Console.Write("ID de la habitación: ");
                int idHabitacion = int.Parse(Console.ReadLine());

                // Verificar si existe la habitación
                habitaciones habitacion = gestorHabitaciones.BuscarHabitacionPorId(idHabitacion);
                if (habitacion == null)
                {
                    Console.WriteLine($"No existe una habitación con el ID {idHabitacion}.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Fecha de entrada (DD/MM/AAAA): ");
                DateTime fechaEntrada = DateTime.Parse(Console.ReadLine());

                Console.Write("Fecha de salida (DD/MM/AAAA): ");
                DateTime fechaSalida = DateTime.Parse(Console.ReadLine());

                bool reservaCreada = gestorReservas.CrearReserva(idReserva, cedulaHuesped, idHabitacion, fechaEntrada, fechaSalida);

                if (reservaCreada)
                {
                    Console.WriteLine("Reserva creada exitosamente.");
                    decimal costoTotal = gestorReservas.CalcularCostoReserva(idHabitacion, fechaEntrada, fechaSalida);
                    Console.WriteLine($"Costo total de la reserva: ${costoTotal}");
                }
                else
                {
                    Console.WriteLine("No se pudo crear la reserva. La habitación no está disponible en las fechas seleccionadas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ListarReservas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE RESERVAS ===");

            List<reservas> listaReservas = gestorReservas.ObtenerTodasLasReservas();

            if (listaReservas.Count > 0)
            {
                Console.WriteLine("ID\tCÉDULA\tHABITACIÓN\tENTRADA\t\tSALIDA");
                Console.WriteLine("------------------------------------------------------");

                foreach (reservas reserva in listaReservas)
                {
                    Console.WriteLine($"{reserva.IdReserva}\t{reserva.IdentificacionHuesped}\t{reserva.IdHabitacion}\t\t{reserva.FechaEntrada.ToShortDateString()}\t{reserva.FechaSalida.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No hay reservas registradas.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarReservasPorHuesped()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR RESERVAS POR HUÉSPED ===");

            try
            {
                Console.Write("Ingrese la cédula del huésped: ");
                int cedulaHuesped = int.Parse(Console.ReadLine());

                List<reservas> reservasHuesped = gestorReservas.BuscarReservasPorHuesped(cedulaHuesped);

                if (reservasHuesped.Count > 0)
                {
                    huespedes huesped = gestorHuespedes.BuscarHuespedPorCedula(cedulaHuesped);
                    if (huesped != null)
                    {
                        Console.WriteLine($"Reservas del huésped: {huesped.Nombre} {huesped.apellido}");
                    }

                    Console.WriteLine("ID\tCÉDULA\tHABITACIÓN\tENTRADA\t\tSALIDA");
                    Console.WriteLine("------------------------------------------------------");

                    foreach (reservas reserva in reservasHuesped)
                    {
                        Console.WriteLine($"{reserva.IdReserva}\t{reserva.IdentificacionHuesped}\t{reserva.IdHabitacion}\t\t{reserva.FechaEntrada.ToShortDateString()}\t{reserva.FechaSalida.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontraron reservas para el huésped con cédula {cedulaHuesped}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void CalcularCostoReserva()
        {
            Console.Clear();
            Console.WriteLine("=== CALCULAR COSTO DE RESERVA ===");

            try
            {
                Console.Write("ID de la habitación: ");
                int idHabitacion = int.Parse(Console.ReadLine());

                Console.Write("Fecha de entrada (DD/MM/AAAA): ");
                DateTime fechaEntrada = DateTime.Parse(Console.ReadLine());

                Console.Write("Fecha de salida (DD/MM/AAAA): ");
                DateTime fechaSalida = DateTime.Parse(Console.ReadLine());

                decimal costoTotal = gestorReservas.CalcularCostoReserva(idHabitacion, fechaEntrada, fechaSalida);
                Console.WriteLine($"Costo total de la reserva: ${costoTotal}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}

