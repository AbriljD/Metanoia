﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades.Request
{
    public  class ReqObtenerEmocion
    {

        public Emocion emocion { get; set; }
        List<Emocion> listaDeEmociones { get; set; }
    }
}
