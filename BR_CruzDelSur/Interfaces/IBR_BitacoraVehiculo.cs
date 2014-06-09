using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE_CruzDelSur;

namespace BR_CruzDelSur.Interfaces
{
    public interface IBR_BitacoraVehiculo
    {
        List<BE_BitacoraVehiculo> f_ListarBitacoraVehiculo(int intVehiculo, int intConductor, String fechaIni);
        List<BE_BitacoraVehiculo> f_ListarVehiculos();
        List<BE_BitacoraVehiculo> f_ListarAgencias();
        List<BE_Conductor> f_BuscarConductorxDNI(string dni);
        int f_registrarAsignacionBitacora(int vehiculo, int conductor);
        int f_actualizarAsignacionBitacora(int vehiculo, int conductor, int bitacora);
    }
}
