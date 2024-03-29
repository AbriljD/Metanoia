using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades.Request
{
    public class ReqEliminarEmocion : ResBase
    {
        public Emocion emocion { get; set; }
    }
}
