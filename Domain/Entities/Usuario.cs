using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("Empleado")]
        public int? IDEmpleado { get; set; }

        [ForeignKey("Rol")]
        public int? IDRol { get; set; }

        public Empleado Empleado { get; set; }
        public Rol Rol { get; set; }
        
    }
}
