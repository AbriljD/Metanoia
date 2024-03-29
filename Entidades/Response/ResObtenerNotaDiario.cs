using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades.Response
{
    public class ResObtenerNotaDiario : ResBase
    {
      public List<Diario> notasDiario {  get; set; }  
    }
}
