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
        public class LogicaActualizarNota
        {
            // Método para actualizar una nota existente
            public ResActualizarNotaDiario actualizarNota (ReqActualizarNotaDiario reqActualizarNota)
            {
            // Crear una instancia del objeto de respuesta
                 ResActualizarNotaDiario resActualizarNota = new ResActualizarNotaDiario();

                try
                {
                // Inicializar el resultado como falso y la lista de errores
                    resActualizarNota.resultado = false;
                    resActualizarNota.listaDeErrores = new List<String>();

                    // Verificar si la solicitud es nula de bd
                    if (reqActualizarNota == null)
                    {
                        resActualizarNota.listaDeErrores.Add("Request nulo");
                        return resActualizarNota;
                    }

                    // Verificar si la nota a actualizar existe, pq tiene que existir para poder actualizarla.
                    if (reqActualizarNota.diario == null || reqActualizarNota.diario.idDiario <= 0)
                    {
                    resActualizarNota.listaDeErrores.Add("ID de la nota inválido");
                        return resActualizarNota;
                    }

                    // Verificar si se proporciona título y nota para la actualización
                    if (String.IsNullOrEmpty(reqActualizarNota.diario.tituloDiario) || String.IsNullOrEmpty(reqActualizarNota.diario.notaDiario))
                    {
                    resActualizarNota.listaDeErrores.Add("Título o nota faltantes");
                        return resActualizarNota;
                    }

                    // Llamar a la base de datos para actualizar la nota
                    ConexionLinqDataContext conexion = new ConexionLinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";

                    // Llamar al procedimiento almacenado de actualización
                    conexion.SP_EDITAR_MENSAJE_DIARIO(reqActualizarNota.diario.idDiario, reqActualizarNota.diario.fechaActualizadoDiario, reqActualizarNota.diario.tituloDiario, reqActualizarNota.diario.notaDiario, reqActualizarNota.diario.estadoDiario  ,ref idReturn, ref errorId, ref errorDescripcion);

                    // Verificar si hubo un error en la base de datos
                    if (idReturn == 0)
                    {
                    // Error en base de datos
                       resActualizarNota.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                    // La actualización fue exitosa
                       resActualizarNota.resultado = true;
                    }
                }
                catch (Exception ex)
                {
                // Error no previsto
                    resActualizarNota.listaDeErrores.Add(ex.ToString());
                }
                finally
                {
                    // Bitácora  
                }
                // Devolver el resultado de la actualización
                return resActualizarNota;
            }
        }
    }




