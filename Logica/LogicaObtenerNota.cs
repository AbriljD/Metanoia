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
    public class LogicaObtenerNota
    {
                                    //OBTENER NOTAS DIARIO/
        public ResObtenerNotaDiario obtenerNotaDiario(ReqObtenerNotaDiario reqObtenerNota)
        {
            ResObtenerNotaDiario resObtenerNota = new ResObtenerNotaDiario();
            resObtenerNota.listaDeErrores = new List<string>();
            resObtenerNota.notasDiario = new List<Diario>();  // lista que definimos en Res/
            try
            {
                 ConexionLinqDataContext conexion = new ConexionLinqDataContext();

                 List<SP_OBTENER_NOTAS_DIARIOResult> publicacionesDeBD = conexion.SP_OBTENER_NOTAS_DIARIO().ToList();

                foreach (SP_OBTENER_NOTAS_DIARIOResult cadaTC in publicacionesDeBD)
                resObtenerNota.notasDiario.Add(this.crearPublicacion(cadaTC));

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
        #endregion
    }
}
