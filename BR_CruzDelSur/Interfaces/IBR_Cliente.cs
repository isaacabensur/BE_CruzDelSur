using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE_CruzDelSur;

namespace BR_CruzDelSur.Interfaces
{
    public interface IBR_Cliente
    {
        BE_Cliente f_BuscaClienteDNI(String dni);
    }
}
