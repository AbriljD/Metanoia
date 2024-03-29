using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class Tarea
    {
        public Usuario usuario {  get; set; }
        public int idTarea { get; set; }
        public string fechaCreadoTarea { get; set; }
        public string fechaVencimientoTarea { get; set; }
        public string tituloTarea { get; set; }
        public string notaTarea { get; set; }
        public string colorTarea { get; set; }
    }
}
