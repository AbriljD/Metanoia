using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class Meditacion
    {
        public Usuario usuario {  get; set; }
        public int idMeditacion { get; set; }
        public string nombrePlaylist { get; set; }
        public string playlistURL { get; set; }
    }
}
