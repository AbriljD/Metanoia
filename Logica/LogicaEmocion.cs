using Metanoia.AccesoDatos;
using Metanoia.Entidades.Request;
using Metanoia.Entidades.Response;
using Metanoia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Logica
{
    internal class LogicaEmocion
    {
        public ResObtenerEmocion obtenerEmocion(ReqObtenerEmocion req)
        {
            ResObtenerEmocion res = new ResObtenerEmocion();
            res.listaDeErrores = new List<string>();
            res.listaDeEmociones = new List<Emocion>();
            try
            {
                ConexionLinqDataContext conexion = new ConexionLinqDataContext();
                List<SP_OBTENER_EMOCIONESResult> emocionesDeBD = conexion.SP_OBTENER_EMOCIONES(req.emocion.idEmocion).ToList();

                foreach (SP_OBTENER_EMOCIONESResult cadaTC in emocionesDeBD)
                    res.listaDeEmociones.Add(this.crearEmocion(cadaTC));
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }

            return res;
        }

        private Emocion crearEmocion(SP_OBTENER_EMOCIONESResult emocionesDeBD)
        {
            Emocion emocionesRetornar = new Emocion();

            emocionesRetornar.emojiEmocion = emocionesDeBD.Emocion_Emoji;

            return emocionesRetornar;
        }
    }
}
