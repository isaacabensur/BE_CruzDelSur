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
    public class BR_Carga : IBR_Carga
    {
        Conexion conn = new Conexion();
        IBR_Cliente ECliente = new BR_Cliente();
        IBR_ProgramacionRuta EProgramacionRuta = new BR_ProgramacionRuta();
        IBR_Estado EEstado = new BR_Estado();

        public List<BE_Carga> f_ListarCargas(string documento, int departamento)
        { 
            List<BE_Carga> lst = new List<BE_Carga>();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("VCH_DOC_CLIENTE", SqlDbType.VarChar);
            param[0].Value = documento;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("INT_DEPARTAMENTO", SqlDbType.Int);
            param[1].Value = departamento;
            param[1].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTACARGAENTREGADA", param);
            
            return lst;
        }

        public List<BE_Carga> f_ListarCargas(String cliente, String fDesde, String fHasta, string estado)
        {
            DateTime dtmDesde;

            if(!DateTime.TryParse(fDesde, out dtmDesde))
            {
                dtmDesde = new DateTime(1900, 1, 1);
            }

            DateTime dtmHasta;

            if (!DateTime.TryParse(fHasta, out dtmHasta))
            {
                dtmHasta = new DateTime(1900, 1, 1);
            }

            List<BE_Carga> lst = new List<BE_Carga>();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("VCH_NOM_CLIENTE", SqlDbType.VarChar);
            param[0].Value = cliente;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("DTM_FECHA_DESDE", SqlDbType.DateTime);
            param[1].Value = dtmDesde;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("DTM_FECHA_HASTA", SqlDbType.DateTime);
            param[2].Value = dtmHasta;
            param[2].Direction = ParameterDirection.Input;
            param[3] = new SqlParameter("CHR_ESTADO", SqlDbType.Char);
            param[3].Value = estado;
            param[3].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTACARGASXFILTROS", param);
            BE_Carga carga = null;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                carga = new BE_Carga() { CodigoCarga = Convert.ToInt32(item["INT_CODIGO_CARGA"].ToString()), DNIClienteOrigen = item["VCH_CLIENTE_ORIGEN"].ToString(), DNIClienteDestino = item["VCH_CLIENTE_DESTINO"].ToString(), CodigoProgramacionRuta = Convert.ToInt32(item["INT_CODIGO_PROGRAMACION_RUTA"].ToString()), EstadoCarga = item["CHR_ESTADO"].ToString() };
                carga.ClienteOrigen = ECliente.f_BuscaClienteDNI(carga.DNIClienteOrigen);
                carga.ClienteDestino = ECliente.f_BuscaClienteDNI(carga.DNIClienteDestino);
                carga.ProgramacionRuta = EProgramacionRuta.f_BuscaProgramacionXCodigo(carga.CodigoProgramacionRuta);
                carga.Estado = EEstado.f_BuscaEstadoXCodigo(carga.EstadoCarga);
                lst.Add(carga);                
            }

            return lst;
        }

        public BE_Carga f_InsertarCarga(string documentoClienteOrigen, 
            string documentoClienteDestino, 
            int TipoCarga, 
            int TipoPago, 
            string Observaciones, 
            double peso, 
            double largo, 
            double ancho, 
            double profundidad, 
            int programacionRuta, 
            int almacen)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("VCH_DOC_CLIENTE_ORIGEN", SqlDbType.VarChar);
            param[0].Value = documentoClienteOrigen;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("VCH_DOC_CLIENTE_DESTINO", SqlDbType.VarChar);
            param[1].Value = documentoClienteDestino;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("INT_TIPO_CARGA", SqlDbType.Int);
            param[2].Value = TipoCarga;
            param[2].Direction = ParameterDirection.Input;
            param[3] = new SqlParameter("INT_TIPO_PAGO", SqlDbType.Int);
            param[3].Value = TipoPago;
            param[3].Direction = ParameterDirection.Input;
            param[4] = new SqlParameter("VCH_OBSERVACIONES", SqlDbType.VarChar);
            param[4].Value = Observaciones;
            param[4].Direction = ParameterDirection.Input;
            param[5] = new SqlParameter("DBL_PESO", SqlDbType.Decimal);
            param[5].Value = peso;
            param[5].Direction = ParameterDirection.Input;
            param[6] = new SqlParameter("DBL_LARGO", SqlDbType.Decimal);
            param[6].Value = largo;
            param[6].Direction = ParameterDirection.Input;
            param[7] = new SqlParameter("DBL_ANCHO", SqlDbType.Decimal);
            param[7].Value = ancho;
            param[7].Direction = ParameterDirection.Input;
            param[8] = new SqlParameter("DBL_PROFUNDIDAD", SqlDbType.Decimal);
            param[8].Value = profundidad;
            param[8].Direction = ParameterDirection.Input;
            param[9] = new SqlParameter("INT_PROGRAMACION_RUTA", SqlDbType.Int);
            param[9].Value = programacionRuta;
            param[9].Direction = ParameterDirection.Input;
            param[10] = new SqlParameter("INT_ALMACEN", SqlDbType.Int);
            param[10].Value = almacen;
            param[10].Direction = ParameterDirection.Input;

            param[11] = new SqlParameter("VCH_CODIGO_SEGURIDAD", SqlDbType.VarChar);            
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("VCH_CODIGO_CARGA", SqlDbType.VarChar);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("INT_CODIGO_CARGA", SqlDbType.Int);
            param[13].Direction = ParameterDirection.Input;

            SqlHelper.ExecuteNonQuery(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_INSERTARCARGA", param);

            return new BE_Carga();
        }
    }
}
