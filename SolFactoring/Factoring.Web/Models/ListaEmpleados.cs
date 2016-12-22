using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.Web.Models
{
    public class ListaEmpleados
    {
        public int Id { get; set; }
        public DateTime FechaContrato { get; set; }

        public string NombreUsuario { get; set; }

        public string Titulo { get; set; }
    }
}
