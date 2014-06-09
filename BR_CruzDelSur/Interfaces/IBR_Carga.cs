using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE_CruzDelSur;

namespace BR_CruzDelSur.Interfaces
{
    public interface IBR_Carga
    {
        //List<BE_Carga> f_ListarCargas(String documento, int departamento);
        List<BE_Carga> f_ListarCargas(String cliente, String fDesde, String fHasta, string estado);
        BE_Carga f_InsertarCarga(string documentoClienteOrigen, string documentoClienteDestino, int TipoCarga, int TipoPago, string Observaciones, double peso, double largo, double ancho, double profundidad, int programacionRuta, int almacen);
    }
}
