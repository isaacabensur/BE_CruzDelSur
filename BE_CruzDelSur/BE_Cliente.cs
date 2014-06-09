using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE_CruzDelSur
{
    public class BE_Cliente
    {
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }
        public string Telefono { get; set; }
        public string NombreCompleto { 
            get
            {
                return Nombres + " " + Apellidos;
            } 
        }
    }
}
