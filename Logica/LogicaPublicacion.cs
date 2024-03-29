using Metanoia.Entidades.Request;
using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Logica
{
    public class LogicaPublicacion
    {
        public ResAgregarPublicacion agregarPublicacion (ReqAgregarPublicacion reqAgregarPublicacion)
        {
            ResAgregarPublicacion resAgregarPublicacion = new ResAgregarPublicacion();
            try
            {
                //Conectar
                resAgregarPublicacion.resultado = false;
                resAgregarPublicacion.listaDeErrores = new List<String>();
                if (req == null)
                {
                    resAgregarPublicacion.resultado = false;
                    resAgregarPublicacion.listaDeErrores.Add("Request nulo");
                }
                else
                {
                    if (req.publicacion.idUsuario == 0)
                    {
                        resAgregarPublicacion.resultado = false;
                        resAgregarPublicacion.listaDeErrores.Add("No se recibio el usuario");
                    }
                    if (String.IsNullOrEmpty(req.publicacion.titulo))
                    {
                        resAgregarPublicacion.resultado = false;
                        resAgregarPublicacion.listaDeErrores.Add("Titulo faltante");
                    }
                    if (String.IsNullOrEmpty(req.publicacion.mensaje))
                    {
                        resAgregarPublicacion.resultado = false;
                        resAgregarPublicacion.listaDeErrores.Add("Mensaje faltante");
                    }
                }
                //BD
                if (resAgregarPublicacion.listaDeErrores.Any())
                {
                    //Hubo al menos 1 error
                    resAgregarPublicacion.resultado = false;
                }
                else
                {
                    //Llamar base de datos
                    ConexionLinqDataContext conexion = new ConexionLinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";

                    conexion.SP_INGRESAR_PUBLICACION(req.publicacion.idTema, req.publicacion.idUsuario, req.publicacion.titulo, req.publicacion.mensaje, ref idReturn, ref errorId, ref errorDescripcion);
                    if (idReturn == 0)
                    {
                        //Error en base de datos
                        //No se hizo la publicacion
                        resAgregarPublicacion.resultado = false;
                        resAgregarPublicacion.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        resAgregarPublicacion.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Si falla
                resAgregarPublicacion.resultado = false;
                resAgregarPublicacion.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora
            }
            return resAgregarPublicacion;
        }
    }
}
