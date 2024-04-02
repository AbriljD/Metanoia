using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class Diario
    {
        public int idDiario { get; set; }
        public Usuario usuario { get; set; }

        public string fechaCreadoDiario { get; set; }
        public string fechaActualizadoDiario { get; set; }
        public string tituloDiario { get; set; }
        public string notaDiario { get; set; }
        public string estadoDiario { get; set; }
    }
}
