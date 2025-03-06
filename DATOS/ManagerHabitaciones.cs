using System;
using System.Collections.Generic;
using System.IO;
using ENTIDADES;

namespace DATOS
{
    public class ManagerHabitaciones
    {
        private const string PATH = @"E:\c shar\PARCIAL 1 2024-2\archivos\habitaciones.txt";

        public List<habitaciones> ObtenerHabitaciones()
        {
            List<habitaciones> habitaciones = new List<habitaciones>();

            if (!File.Exists(PATH)) return habitaciones;

            using (StreamReader sr = new StreamReader(PATH))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split(';');
                    habitaciones habitacion = new habitaciones(int.Parse(datos[0]), datos[1], decimal.Parse(datos[2]));
                    habitaciones.Add(habitacion);
                }
            }

            return habitaciones;
        }

        public void GuardarHabitacion(habitaciones habitacion)
        {
            using (StreamWriter sw = new StreamWriter(PATH, true))
            {
                sw.WriteLine($"{habitacion.IdHabitacion};{habitacion.Categoria};{habitacion.PrecioPorNoche}");
            }
        }

        public habitaciones BuscarHabitacion(int idHabitacion)
        {
            List<habitaciones> habitaciones = ObtenerHabitaciones();
            foreach (habitaciones habitacion in habitaciones)
            {
                if (habitacion.IdHabitacion == idHabitacion)
                {
                    return habitacion;
                }
            }
            return null;
        }
    }
}

