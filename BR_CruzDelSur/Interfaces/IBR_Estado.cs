using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE_CruzDelSur;

namespace BR_CruzDelSur.Interfaces
{
    public interface IBR_Estado
    {
        List<BE_Estado> f_ListarEstados(String tipo, bool todos);
        BE_Estado f_BuscaEstadoXCodigo(String codigo);
    }
}
