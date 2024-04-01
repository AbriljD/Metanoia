using Metanoia.Entidades.Request;
using Metanoia.Entidades;
using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metanoia.AccesoDatos;

namespace Metanoia.Logica
{
    public class LogicaDiario

    {
        public ResAgregarNotaDiario agregarNota (ReqAgregarPublicacion reqAgregarNota)
        {

            ResAgregarNotaDiario resAgregarNota = new ResAgregarNotaDiario();

            try
            {
                //Conectar

                resAgregarNota.resultado = false;
                resAgregarNota.listaDeErrores = new List<String>();
                if (reqAgregarNota == null)
                {
                    resAgregarNota.resultado = false;
                    resAgregarNota.listaDeErrores.Add("Request nulo");
                }
                else
                {
                    if (reqAgregarNota.   .publicacion .idUsuario == 0)
                    {
                        resAgregarNota.resultado = false;
                        resAgregarNota.listaDeErrores.Add("No se recibio el usuario");
                    }
                    if (String.IsNullOrEmpty(reqAgregarNota.publicacion.titulo))
                    {
                        resAgregarNota.resultado = false;
                        resAgregarNota.listaDeErrores.Add("Titulo faltante");
                    }
                    if (String.IsNullOrEmpty(reqAgregarNota.publicacion.mensaje))
                    {
                        resAgregarNota.resultado = false;
                        resAgregarNota.listaDeErrores.Add("Nota faltante");
                    }
                }





        }
    }
}







