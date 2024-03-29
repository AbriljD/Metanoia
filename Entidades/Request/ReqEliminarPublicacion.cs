using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades.Request
{
    public class ReqEliminarPublicacion : ResBase
    {
        public Publicacion publicacion { get; set; }
    }
}
