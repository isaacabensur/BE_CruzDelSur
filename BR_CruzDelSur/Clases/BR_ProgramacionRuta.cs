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
    public class BR_ProgramacionRuta : IBR_ProgramacionRuta
    {
        Conexion conn = new Conexion();

        public BE_ProgramacionRuta f_BuscaProgramacionXCodigo(int Codigo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("INT_CODIGO", SqlDbType.Int);
            param[0].Value = Codigo;
            param[0].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BUSCAPROGRAMACIONRUTAXCODIGO", param);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                return new BE_ProgramacionRuta() { FechaOrigen = Convert.ToDateTime(item["DTM_FECHA_ORIGEN"].ToString()), FechaDestino = Convert.ToDateTime(item["DTM_FECHA_DESTINO"].ToString()) };                
            }

            return null;
        }

    }
}
