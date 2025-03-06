using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class habitaciones
    {
        public int IdHabitacion { get; set; }   // Número o ID de la habitación
        public string Categoria { get; set; }   // Económica, Estándar o Suite
        public decimal PrecioPorNoche { get; set; }  // Precio según la categoría

        public habitaciones(int idHabitacion, string categoria, decimal precioPorNoche)
        {
            IdHabitacion = idHabitacion;
            Categoria = categoria;
            PrecioPorNoche = precioPorNoche;
        }

        public habitaciones()
        {
        }


        public override string ToString()
        {
            return $"{IdHabitacion};{Categoria};{PrecioPorNoche}";
        }

    }
}
