using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class huespedes
    {
        public int cedula { get; set; }
        public string Nombre { get; set; } 
        public string Telefono { get; set; } 
        public string apellido { get; set; }


        public huespedes(int cedula, string nombre, string telefono, string apellido)
        {
            this.cedula = cedula;
            Nombre = nombre;
            Telefono = telefono;
            this.apellido = apellido;
        }

        public huespedes()
        {
        }
        public override string ToString()
        {
            return $"{cedula};{Nombre};{Telefono};{apellido}";
        }

    }
}
