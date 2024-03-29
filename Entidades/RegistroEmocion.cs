using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class RegistroEmocion
    {
        public int idRegistro { get; set; }
        public Emocion emocion { get; set; }
        public Usuario usuario { get; set; }
        public string fechaRegistro { get; set; }
    }
}
