using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

namespace LOGICA
{
    public class GestorHabitaciones
    {
        private ManagerHabitaciones managerHabitaciones = new ManagerHabitaciones();

        public List<habitaciones> ObtenerTodasLasHabitaciones()
        {
            return managerHabitaciones.ObtenerHabitaciones();
        }

        public habitaciones BuscarHabitacionPorId(int idHabitacion)
        {
            return managerHabitaciones.BuscarHabitacion(idHabitacion);
        }

        public void RegistrarHabitacion(int idHabitacion, string categoria, decimal precioPorNoche)
        {
            // Validaciones
            if (string.IsNullOrEmpty(categoria))
                throw new ArgumentException("La categoría no puede estar vacía");

            if (precioPorNoche <= 0)
                throw new ArgumentException("El precio por noche debe ser mayor a cero");

            // Verificar si ya existe una habitación con ese ID
            habitaciones habitacionExistente = BuscarHabitacionPorId(idHabitacion);
            if (habitacionExistente != null)
                throw new ArgumentException($"Ya existe una habitación con el ID {idHabitacion}");

            // Crear y guardar la habitación
            habitaciones nuevaHabitacion = new habitaciones(idHabitacion, categoria, precioPorNoche);
            managerHabitaciones.GuardarHabitacion(nuevaHabitacion);
        }

        public List<habitaciones> FiltrarHabitacionesPorCategoria(string categoria)
        {
            List<habitaciones> todasLasHabitaciones = ObtenerTodasLasHabitaciones();
            return todasLasHabitaciones.Where(h => h.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

