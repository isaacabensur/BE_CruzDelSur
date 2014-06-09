using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BE_CruzDelSur
{
    public class Conexion
    {
        public string CadenaConexion { 
            get { 
                return ConfigurationManager.AppSettings["ConexionDB"].ToString();        
            } 
        }
    }
}
