using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class reservas
    {
        public int IdReserva { get; set; }          // Identificador único de la reserva
        public int IdentificacionHuesped { get; set; } // Identificación del huésped que hizo la reserva
        public int IdHabitacion { get; set; }       // ID de la habitación reservada
        public DateTime FechaEntrada { get; set; }  // Fecha de ingreso al hotel
        public DateTime FechaSalida { get; set; }   // Fecha de salida del hotel

        // Método para calcular el costo total de la estancia
        public decimal CalcularCostoTotal(decimal precioPorNoche)
        {
            int noches = (FechaSalida - FechaEntrada).Days;
            return noches * precioPorNoche;
        }

        public override string ToString()
        {
            return $"IdReserva: {IdReserva}, IdentificacionHuesped: {IdentificacionHuesped}, IdHabitacion: {IdHabitacion}, FechaEntrada: {FechaEntrada}, FechaSalida: {FechaSalida}";
        }

        public reservas(int idReserva, int identificacionHuesped, int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            IdReserva = idReserva;
            IdentificacionHuesped = identificacionHuesped;
            IdHabitacion = idHabitacion;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
        }

        public reservas()
        {
        }





    }
}
