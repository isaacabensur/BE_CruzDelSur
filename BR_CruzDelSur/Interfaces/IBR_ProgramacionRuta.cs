using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE_CruzDelSur;

namespace BR_CruzDelSur.Interfaces
{
    public interface IBR_ProgramacionRuta
    {
        BE_ProgramacionRuta f_BuscaProgramacionXCodigo(int Codigo);
    }
}
