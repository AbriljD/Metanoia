using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class Sesion
    {
        public int idSesion { get; set; }
        public Usuario usuario { get; set; }
        public string guidSesion { get; set; }
        public string fechaInicioSesion { get; set; }
        public string finalSesion { get; set; }
        public string estadoSesion { get; set; }
    }
}
