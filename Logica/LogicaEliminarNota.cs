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
        public class LogicaDiario
        {
            // Método para eliminar una nota existente
            public ResEliminarNotaDiario eliminarNota(ReqEliminarNotaDiario reqEliminarNota)
            {
                // Crear una instancia del objeto de respuesta
                ResEliminarNotaDiario resEliminarNota = new ResEliminarNotaDiario();

                try
                {
                    // Inicializar el resultado como falso y la lista de errores
                    resEliminarNota.resultado = false;
                    resEliminarNota.listaDeErrores = new List<string>();

                    // Verificar si la solicitud es nula
                    if (reqEliminarNota == null)
                    {
                        resEliminarNota.listaDeErrores.Add("La solicitud de eliminación es nula.");
                        return resEliminarNota;
                    }

                    // Verificar si el ID de la nota es válido, si existe la nota
                    //OLA
                    if (reqEliminarNota.diario.idDiario <= 0)
                    {
                        resEliminarNota.listaDeErrores.Add("ID de nota inválido.");
                        return resEliminarNota;
                    }

                // Llamar al procedimiento almacenado para eliminar la nota
                     ConexionLinqDataContext conexion = new ConexionLinqDataContext();
                    {
                    //AQUI SIRVE PORQUE LO BORRA TODO DE LA BD
                        conexion.SP_ELIMINAR_MENSAJE_DIARIO(reqEliminarNota.diario.idDiario);
                        // Si la ejecución del procedimiento es exitosa, establecer el resultado en verdadero
                        resEliminarNota.resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    // Capturar cualquier excepción y agregarla a la lista de errores
                    resEliminarNota.listaDeErrores.Add("Se produjo un error al intentar eliminar la nota: " + ex.Message);
                }

                // Devolver la respuesta
                return resEliminarNota;
            }
        }
    }


        



