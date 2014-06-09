using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE_CruzDelSur;
using System.Data.SqlClient;
using System.Data;
using BR_CruzDelSur.Interfaces;

namespace BR_CruzDelSur
{
    public class BR_Cliente : IBR_Cliente
    {
        Conexion conn = new Conexion();

        public BE_Cliente f_BuscaClienteDNI(String dni)
        {
            List<BE_Estado> lst = new List<BE_Estado>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("VCH_DOCUMENTO", SqlDbType.VarChar);
            param[0].Value = dni;
            param[0].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BUSCACLIENTEXDNI", param);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                return new BE_Cliente() { Nombres = item["VCH_NOMBRES"].ToString(), Apellidos = item["VCH_APELLIDOS"].ToString() };                
            }

            return null;
        }

    }
}
