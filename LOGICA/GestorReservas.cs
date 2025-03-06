using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

namespace LOGICA
{
    public class GestorReservas
    {
        private ManagerReservas managerReservas = new ManagerReservas();
        private ManagerHabitaciones managerHabitaciones = new ManagerHabitaciones();
        private ManagerHuespedes managerHuespedes = new ManagerHuespedes();

        public List<reservas> ObtenerTodasLasReservas()
        {
            return managerReservas.ObtenerReservas();
        }

        public bool CrearReserva(int idReserva, int cedulaHuesped, int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            // Validaciones
            if (fechaEntrada >= fechaSalida)
                throw new ArgumentException("La fecha de entrada debe ser anterior a la fecha de salida");

            if (fechaEntrada < DateTime.Today)
                throw new ArgumentException("La fecha de entrada no puede ser anterior a la fecha actual");

            // Verificar si existe el huésped
            huespedes huesped = managerHuespedes.BuscarHuesped(cedulaHuesped);
            if (huesped == null)
                throw new ArgumentException($"No existe un huésped con la cédula {cedulaHuesped}");

            // Verificar si existe la habitación
            habitaciones habitacion = managerHabitaciones.BuscarHabitacion(idHabitacion);
            if (habitacion == null)
                throw new ArgumentException($"No existe una habitación con el ID {idHabitacion}");

            // Verificar disponibilidad
            bool disponible = managerReservas.VerificarDisponibilidad(idHabitacion, fechaEntrada, fechaSalida);
            if (!disponible)
                return false;

            // Crear y guardar la reserva
            reservas nuevaReserva = new reservas(idReserva, cedulaHuesped, idHabitacion, fechaEntrada, fechaSalida);
            managerReservas.guardarReserva(nuevaReserva);
            return true;
        }

        public decimal CalcularCostoReserva(int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            habitaciones habitacion = managerHabitaciones.BuscarHabitacion(idHabitacion);
            if (habitacion == null)
                throw new ArgumentException($"No existe una habitación con el ID {idHabitacion}");

            int noches = (fechaSalida - fechaEntrada).Days;
            return noches * habitacion.PrecioPorNoche;
        }

        public List<reservas> BuscarReservasPorHuesped(int cedulaHuesped)
        {
            List<reservas> todasLasReservas = ObtenerTodasLasReservas();
            return todasLasReservas.Where(r => r.IdentificacionHuesped == cedulaHuesped).ToList();
        }
    }
}

