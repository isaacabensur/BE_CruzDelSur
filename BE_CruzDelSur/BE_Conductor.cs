using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE_CruzDelSur
{
    public class BE_Conductor
    {
        public int Codigo { get; set; }
        public string Licencia { get; set; }
        public string DniC { get; set; }
        public string Nombres{ get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
       
        public string NombreCompleto
        {
            get
            {
                return Nombres + " " + apellidos;
            }
        }

    }
}
