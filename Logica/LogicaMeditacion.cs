using Metanoia.AccesoDatos;
using Metanoia.Entidades;
using Metanoia.Entidades.Request;
using Metanoia.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Logica
{
    public class LogicaMeditacion
    {
        public ResObtenerMeditacion obtenerMeditacion(ReqObtenerMeditacion req) 
        {
            ResObtenerMeditacion res = new ResObtenerMeditacion();
            res.listaDeErrores = new List<string>();
            res.playlistMeditacion = new List<Meditacion>();
            try
            {
                ConexionLinqDataContext conexion = new ConexionLinqDataContext();
                List<SP_OBTENER_PLAYLISTResult> playlistDeBD = conexion.SP_OBTENER_PLAYLIST(req.meditacion.idMeditacion).ToList();

                foreach (SP_OBTENER_PLAYLISTResult cadaTC in playlistDeBD)
                    res.playlistMeditacion.Add(this.crearMeditacion(cadaTC));
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
   
            return res;
        }

        private Meditacion crearMeditacion(SP_OBTENER_PLAYLISTResult meditacionDeBD)
        {
            Meditacion meditacionRetornar = new Meditacion();

            meditacionRetornar.playlistURL = meditacionDeBD.Meditacion_Playlist_URL;

            return meditacionRetornar;
        }

        
    }
}
