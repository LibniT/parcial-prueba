using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

namespace LOGICA
{
    public class GestorHuespedes
    {
        private ManagerHuespedes managerHuespedes = new ManagerHuespedes();

        public List<huespedes> ObtenerTodosLosHuespedes()
        {
            return managerHuespedes.ObtenerHuespedes();
        }

        public huespedes BuscarHuespedPorCedula(int cedula)
        {
            return managerHuespedes.BuscarHuesped(cedula);
        }

        public void RegistrarHuesped(int cedula, string nombre, string apellido, string telefono)
        {
            // Validaciones
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
                throw new ArgumentException("El nombre y apellido no pueden estar vacíos");

            if (string.IsNullOrEmpty(telefono))
                throw new ArgumentException("El teléfono no puede estar vacío");

            // Verificar si ya existe un huésped con esa cédula
            huespedes huespedExistente = BuscarHuespedPorCedula(cedula);
            if (huespedExistente != null)
                throw new ArgumentException($"Ya existe un huésped con la cédula {cedula}");

            // Crear y guardar el huésped
            huespedes nuevoHuesped = new huespedes(cedula, nombre, telefono, apellido);
            managerHuespedes.GuararHuesped(nuevoHuesped);
        }

        public List<huespedes> BuscarHuespedesPorApellido(string apellido)
        {
            List<huespedes> todosLosHuespedes = ObtenerTodosLosHuespedes();
            return todosLosHuespedes.Where(h => h.apellido.Contains(apellido)).ToList();
        }
    }
}

