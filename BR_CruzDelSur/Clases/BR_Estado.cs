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
    public class BR_Estado : IBR_Estado
    {
        Conexion conn = new Conexion();

        public List<BE_Estado> f_ListarEstados(String tipo, bool todos)
        {
            List<BE_Estado> lst = new List<BE_Estado>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CHR_TIPO_ESTADO", SqlDbType.Char);
            param[0].Value = tipo;
            param[0].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTAESTADOS", param);

            if (todos)
            {
                lst.Add(new BE_Estado() { Codigo = "", Nombre = "TODOS" });
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                lst.Add(new BE_Estado() { Codigo = item["CHR_ESTADO"].ToString(), Nombre = item["VCH_NOMBRE"].ToString() });                
            }

            return lst;
        }

        public BE_Estado f_BuscaEstadoXCodigo(String codigo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CHR_CODIGO", SqlDbType.Char);
            param[0].Value = codigo;
            param[0].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BUSCAESTADOXCODIGO", param);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                return new BE_Estado() { Codigo = item["CHR_ESTADO"].ToString(), Nombre = item["VCH_NOMBRE"].ToString() };
            }

            return null;
        }

    }
}
