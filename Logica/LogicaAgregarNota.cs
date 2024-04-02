using Metanoia.Entidades.Request;
using Metanoia.Entidades;
using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metanoia.AccesoDatos;
using System.Collections;


namespace Metanoia.Logica
{
    public class LogicaAgregarNota

    {
        public ResAgregarNotaDiario agregarNota(ReqAgregarNotaDiario reqAgregarNota)
        {

            ResAgregarNotaDiario resAgregarNota = new ResAgregarNotaDiario();

            try
            {
                //Conectar

                resAgregarNota.resultado = false;
                resAgregarNota.listaDeErrores = new List<String>();
                if (reqAgregarNota == null)
                {         //Aqui verifica si existe la nota /
                    resAgregarNota.resultado = false;
                    resAgregarNota.listaDeErrores.Add("Request nulo");
                }
                else      // Aqui verifica la informacion si falta el titulo y la nota/
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
                    int? idReturn = 0; //? tipo de dato nulleable, 0 o null /
                    int? errorId = 0;// Es porque el usuario existe 0, si devuelve null hay un error /
                    string errorDescripcion = "";
                    //string? fechaCreado = "";
                    //string? fechaActualizado = "";

                    conexion.SP_INSERTAR_MENSAJES_DIARIO(reqAgregarNota.diario.usuario.idUsuario, reqAgregarNota.diario.fechaCreadoDiario, reqAgregarNota.diario.fechaActualizadoDiario,reqAgregarNota.diario.tituloDiario,reqAgregarNota.diario.notaDiario,reqAgregarNota.diario.estadoDiario );
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
                resAgregarNota.listaDeErrores.Add(ex.ToString()); //se agrega a la lista de errores/
            }
            finally
            {
                //Bitacora  
            }
            return resAgregarNota; // Aqui devuelve el resultado de la funcion/
        }
    }
}



               





