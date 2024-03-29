using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades
{
    public class ChatUsuario
    {
        public int idChatUsuario { get; set; }
        public Sesion sesion { get; set; }
        public string mensajeChatUsuario { get; set; }
        public string fechaHoraChatUsuario { get; set; }
    }
}
