﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Entidades.Response
{
    public class ResObtenerEmocion : ResBase
    {
        public List<Emocion> listaDeEmociones { get; set; }
    }
}
