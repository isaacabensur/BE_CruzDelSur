using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE_CruzDelSur
{
    public class BE_BitacoraVehiculo
    {

        public int CodigoBitacoraVehiculo { get; set; }
        public double Combustible { get; set; }
        public Nullable<DateTime> FechaHoraSalida { get; set; }
        public Nullable<DateTime> FechaHoraLlegada { get; set; }
        public int CodigoAgenciaPartida { get; set; }
        public int CodigoAgenciaLlegada { get; set; }
        public double KM_inicial { get; set; }
        public double KM_fin { get; set; }
        public string condicionVehiculo { get; set; }
        public string estado { get; set; }

        public int CodigoVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public int codigoAgencia { get; set; }
        public string nombreAgencia { get; set; }
        public int CodigoConductor { get; set; }
        public string marcavehiculo { get; set; }
        public string nombreConductor { get; set; }
        public string dni { get; set; }

        public string secuenciaBitacora
        {
            get
            {
                return CodigoBitacoraVehiculo.ToString().PadLeft(10, '0');
            }
        }
    }
}
