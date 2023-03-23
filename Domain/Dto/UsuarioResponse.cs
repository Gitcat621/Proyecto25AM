using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain.Dto
{
    public class UsuarioResponse
    {
        public string User { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IDEmpleado { get; set; }
        public int? IDRol { get; set; }


    }
}
