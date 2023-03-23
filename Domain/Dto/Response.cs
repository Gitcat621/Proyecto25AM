using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class Response <T>
    {
        public Response()
        {

        }

        public Response(T data, string mensaje = null)
        {
            Succeded = true;
            Mensaje = mensaje;
            Result = data;

        }

        public Response (string mensaje)
        {
            Succeded = true;
            Mensaje= mensaje;
        }

        public bool Succeded { get; set; }
        public string Mensaje { get; set; }
        public T Result { get; set; }

    }
}
