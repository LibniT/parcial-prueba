using System;
using System.Collections.Generic;
using System.IO;
using ENTIDADES;

namespace DATOS
{
    public class ManagerReservas
    {
        private const string PATH = @"E:\c shar\PARCIAL 1 2024-2\archivos\reservas.txt";

        public List<reservas> ObtenerReservas()
        {
            List<reservas> reservas = new List<reservas>();
            if (!File.Exists(PATH)) return reservas;

            using (StreamReader sr = new StreamReader(PATH))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split(';');
                    reservas reserva = new reservas(
                        int.Parse(datos[0]),
                        int.Parse(datos[1]),
                        int.Parse(datos[2]),
                        DateTime.Parse(datos[3]),
                        DateTime.Parse(datos[4])
                    );
                    reservas.Add(reserva);
                }
            }
            return reservas;
        }

        public void guardarReserva(reservas reserva)
        {
            using (StreamWriter sw = new StreamWriter(PATH, true))
            {
                sw.WriteLine($"{reserva.IdReserva};{reserva.IdentificacionHuesped};{reserva.IdHabitacion};{reserva.FechaEntrada.ToString("yyyy-MM-dd")};{reserva.FechaSalida.ToString("yyyy-MM-dd")}");
            }
        }

        public bool VerificarDisponibilidad(int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            List<reservas> reservas = ObtenerReservas();
            foreach (reservas reserva in reservas)
            {
                if (reserva.IdHabitacion == idHabitacion)
                {
                    if (fechaEntrada >= reserva.FechaEntrada && fechaEntrada <= reserva.FechaSalida)
                    {
                        return false;
                    }
                    if (fechaSalida >= reserva.FechaEntrada && fechaSalida <= reserva.FechaSalida)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

