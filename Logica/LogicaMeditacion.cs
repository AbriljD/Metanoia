using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanoia.Logica
{
    public class LogicaMeditacion
    {
        private void btnEstudiar_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://open.spotify.com/playlist/5R6c17IMIdHyWhZSMH8jAE?si=85f3d643a6324e7f");

        }
        //Prueba
        private void btnDormir_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://open.spotify.com/playlist/37i9dQZF1DWZd79rJ6a7lp?si=6487e519336b41cd");
        }

        private void btnMeditar_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://open.spotify.com/playlist/37i9dQZF1DWZqd5JICZI0u?si=682fb7650af846d0");
        }

        private void btnBuenHumor_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://open.spotify.com/playlist/37i9dQZF1DX7KNKjOK0o75?si=becb1cbbeee6446d");
        }
    }
}
