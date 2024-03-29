using Metanoia.Entidades.Request;
using Metanoia.Entidades;
using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Logica
{
    public class LogicaDiario
                                     /*AGREGAR NOTAS DIARIO*/
    {                                                                 /*Este es el nombre*/
        public ResAgregarNotaDiario agregarNotaDiario (ReqAgregarNotaDiario reqAgregarNota)
        {                         /*Nombre*/
            ResAgregarNotaDiario resAgregarNota = new ResAgregarNotaDiario();

            try
            {
                //Conectar

                resAgregarNota.resultado = false;
                resAgregarNota.listaDeErrores = new List<String>();
                if (reqAgregarNota == null)
                {         /*Aqui verifica si existe la nota*/
                    resAgregarNota.resultado = false;
                    resAgregarNota.listaDeErrores.Add("Request nulo");
                }
                else      /*Aqui verifica la informacion si falta el titulo y la nota*/
                {
                    if (String.IsNullOrEmpty(reqAgregarNota.diario.tituloDiario))
                    {
                        resAgregarNota.resultado = false;
                        resAgregarNota.listaDeErrores.Add("Titulo faltante");
                    }
                    if (String.IsNullOrEmpty(reqAgregarNota.diario.notaDiario))
                    {
                        resAgregarNota.resultado = false;
                        resAgregarNota.listaDeErrores.Add("Nota faltante");
                    }
                }
                //BD
                if (resAgregarNota.listaDeErrores.Any())
                {
                    //Hubo al menos 1 error, devueleve el false de la BD
                    resAgregarNota.resultado = false;

                }
                else
                {
                    //Llamar base de datos
                    ConexionLinqDataContext conexion = new ConexionLinqDataContext();
                    int? idReturn = 0; /*? tipo de dato nulleable, 0 o null*/
                    int? errorId = 0;  /*Es porque el usuario existe 0, si devuelve null hay un error*/
                    string errorDescripcion = "";

                    conexion.SP_INGRESAR_PUBLICACION(reqAgregarNota.diario.idDiario, reqAgregarNota.diario.usuario.idUsuario, reqAgregarNota.diario.notaDiario, reqAgregarNota.diario.tituloDiario, ref idReturn, ref errorId, ref errorDescripcion);
                    if (idReturn == 0)
                    {
                        //Error en base de datos
                        //No se hizo la publicacion
                        resAgregarNota.resultado = false;
                        resAgregarNota.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        resAgregarNota.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Si falla, es un error no previsto
                resAgregarNota.resultado = false;
                resAgregarNota.listaDeErrores.Add(ex.ToString()); /*se agrega a la lista de errores*/
            }
            finally
            {
                //Bitacora  
            }
            return resAgregarNota; /*Aqui devuelve el resultado de la funcion*/
        }
          




                                    /*OBTENER NOTAS DIARIO*/
        public ResObtenerNotaDiario obtenerNotaDiario (ReqObtenerNotaDiario reqObtenerNota)
        {
            ResObtenerNotaDiario resObtenerNota = new ResObtenerNotaDiario();
            resObtenerNota.listaDeErrores = new List<string>();
            resObtenerNota.notasDiario = new List<Diario>();  /*lista que definimos en Res*/
            try
            {
                ConexionLinqDataContext conexion = new ConexionLinqDataContext();

                List<SP_OBTENER_PUBLICACIONESResult> publicacionesDeBD = conexion.SP_OBTENER_PUBLICACIONES().ToList();

                foreach (SP_OBTENER_PUBLICACIONESResult cadaTC in publicacionesDeBD)
                    resObtenerNota.publicaciones.Add(this.crearPublicacion(cadaTC));

                resObtenerNota.resultado = true;

            }
            catch (Exception ex)
            {
                resObtenerNota.resultado = false;
                resObtenerNota.listaDeErrores.Add(ex.ToString());

            }
            finally
            {
                //Bitacorear
            }

            return resObtenerNota;
        }

        #region

        //Factoria
        private Publicacion crearPublicacion(SP_OBTENER_PUBLICACIONESResult publicacionDeBD)
        {
            Publicacion publicacionRetornar = new Publicacion();

            publicacionRetornar.id = publicacionDeBD.ID_PUBLICACION;
            publicacionRetornar.idUsuario = (int)publicacionDeBD.ID_USUARIO;
            publicacionRetornar.idTema = (int)publicacionDeBD.ID_TEMA;
            publicacionRetornar.titulo = publicacionDeBD.TITULO;
            publicacionRetornar.mensaje = publicacionDeBD.MENSAJE;

            return publicacionRetornar;

        }
        #endregion

    }






}


