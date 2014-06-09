using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE_CruzDelSur
{
    public class BE_Carga
    {
        public int CodigoCarga { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String Observacion { get; set; }
        public String CodigoSeguridad { get; set; }
        public double Peso { get; set; }
        public double Largo { get; set; }
        public double Ancho { get; set; }
        public double Profundidad { get; set; }
        public int TipoCarga { get; set; }
        public int TipoPago { get; set; }

        public string DNIClienteOrigen { get; set; }
        public string DNIClienteDestino { get; set; }
        public string EstadoCarga { get; set; }

        public int CodigoProgramacionRuta { get; set; }
        public BE_Cliente ClienteOrigen { get; set; }
        public BE_Cliente ClienteDestino { get; set; }
        public BE_ProgramacionRuta ProgramacionRuta { get; set; }
        public BE_Estado Estado { get; set; }

        public string secuenciaCarga
        {
            get
            {
                return CodigoCarga.ToString().PadLeft(10, '0');
            }
        }
    }
}
