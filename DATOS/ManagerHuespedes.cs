using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ENTIDADES;

namespace DATOS
{
    public class ManagerHuespedes
    {

        private const string PATH = @"E:\\c shar\\PARCIAL 1 2024-2\\archivos\\huespedes.txt";

        public void GuararHuesped(huespedes huesped)
        {
            StreamWriter sw = new StreamWriter(PATH, true);
            sw.WriteLine(huesped.ToString());
            sw.Close();
        }

        public List<huespedes> ObtenerHuespedes()
        {
            List<huespedes> huespedes = new List<huespedes>();
            if (!File.Exists(PATH)) return huespedes;

            StreamReader sr = new StreamReader(PATH);
            string linea;
            while ((linea = sr.ReadLine()) != null)
            {
                string[] datos = linea.Split(';');
                huespedes huesped = new huespedes(int.Parse(datos[0]), datos[1], datos[2], datos[3]);
                huespedes.Add(huesped);
            }
            sr.Close();
            return huespedes;
        }

        public huespedes BuscarHuesped(int cedula)
        {
            List<huespedes> huespedes = ObtenerHuespedes();
            foreach (huespedes huesped in huespedes)
            {
                if (huesped.cedula == cedula)
                {
                    return huesped;
                }
            }
            return null;
        }










    }
}
