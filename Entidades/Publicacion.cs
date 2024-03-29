using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class Publicacion
    {
        public int idPublicacion { get; set; }
        public Usuario usuario { get; set; }
        public string fechaPublicacion { get; set; }
        public string tituloPublicacion { get; set; }
        public string notaPublicacion { get; set; }
    }
}
