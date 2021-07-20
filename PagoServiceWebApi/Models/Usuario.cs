using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long DNI { get; set; }
        public string UsuarioNombre { get; set; }
        public string Rol { get; set; }
        public string Contraseña { get; set; }
        public string Sal { get; set; }
    }
}
