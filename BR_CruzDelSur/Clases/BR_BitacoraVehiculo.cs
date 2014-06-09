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
    public class BR_BitacoraVehiculo : IBR_BitacoraVehiculo
    {
        Conexion conn = new Conexion();





        List<BE_BitacoraVehiculo> IBR_BitacoraVehiculo.f_ListarBitacoraVehiculo(int intVehiculo, int intConductor, String fechaIni)
        {
            DateTime dtmini;

            if (!DateTime.TryParse(fechaIni, out dtmini))
            {
                dtmini = new DateTime(1900, 1, 1);
             
            }
            List<BE_BitacoraVehiculo> lst = new List<BE_BitacoraVehiculo>();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("INT_VEHICULO", SqlDbType.Int);
            param[0].Value = intVehiculo;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("INT_CONDUCTOR", SqlDbType.Int);
            param[1].Value = intConductor;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("DTM_FECHA_INICIO", SqlDbType.DateTime);
            param[2].Value = dtmini;
            param[2].Direction = ParameterDirection.Input;

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTABITACORAVEHICULO", param);
            BE_BitacoraVehiculo vehiculo;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                vehiculo = new BE_BitacoraVehiculo();
                vehiculo.CodigoBitacoraVehiculo = int.Parse(item[0].ToString());
               
                if (item[1].ToString() == "")
                {
                    vehiculo.FechaHoraSalida = null;
                }
                else
                {
                    vehiculo.FechaHoraSalida = DateTime.Parse(item[1].ToString());
                }
                vehiculo.PlacaVehiculo = item[2].ToString();
                vehiculo.marcavehiculo = item[3].ToString();
                vehiculo.nombreConductor = item[4].ToString();
                vehiculo.CodigoVehiculo = int.Parse(item[5].ToString());
                vehiculo.CodigoConductor = int.Parse(item[6].ToString());
                vehiculo.dni = item[7].ToString();
                lst.Add(vehiculo);
                
            }
            return lst;
        }


        public List<BE_BitacoraVehiculo> f_ListarVehiculos()
        {
            List<BE_BitacoraVehiculo> lst = new List<BE_BitacoraVehiculo>();
          

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARVEHICULOS");
            BE_BitacoraVehiculo vehiculo;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                vehiculo = new BE_BitacoraVehiculo();
                vehiculo.CodigoVehiculo = int.Parse(item[0].ToString());
                vehiculo.PlacaVehiculo = item[1].ToString();

                lst.Add(vehiculo);
            }
            vehiculo = new BE_BitacoraVehiculo();
            vehiculo.CodigoVehiculo = 0;
            vehiculo.PlacaVehiculo = "--Seleccione--";
            lst.Insert(0, vehiculo);
            return lst;
        }


        public List<BE_BitacoraVehiculo> f_ListarAgencias()
        {
            List<BE_BitacoraVehiculo> lst = new List<BE_BitacoraVehiculo>();


            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_LISTARAGENCIA");
            BE_BitacoraVehiculo vehiculo;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                vehiculo = new BE_BitacoraVehiculo();
                vehiculo.codigoAgencia = int.Parse(item[0].ToString());
                vehiculo.nombreAgencia = item[1].ToString();

                lst.Add(vehiculo);
            }
            return lst;
        }


        public List<BE_Conductor> f_BuscarConductorxDNI(string dni)
        {

            List<BE_Conductor> lst = new List<BE_Conductor>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("VCH_DNI", SqlDbType.VarChar);
            param[0].Value = dni;
            param[0].Direction = ParameterDirection.Input;
      

            DataSet ds = SqlHelper.ExecuteDataSet(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_BUSCARCONDUCTORXDNI", param);
            BE_Conductor conductor;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                conductor = new BE_Conductor();
                conductor.Codigo = int.Parse(item[0].ToString());
                conductor.Nombres = item[1].ToString();
                conductor.apellidos = item[2].ToString();

                lst.Add(conductor);

            }
            return lst;
        }


        public int f_registrarAsignacionBitacora(int vehiculo, int conductor)
        {
            int resultado = 0;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("INT_VEHICULO", SqlDbType.Int);
            param[0].Value = vehiculo;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("INT_CONDUCTOR", SqlDbType.Int);
            param[1].Value = conductor;
            param[1].Direction = ParameterDirection.Input;

            resultado = SqlHelper.ExecuteNonQuery(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_INSERTARBITACORAVEHICULO", param);
           return resultado;

        }


        public int f_actualizarAsignacionBitacora(int vehiculo, int conductor, int bitacora)
        {
            int resultado = 0;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("INT_CODIGO_BITACORA", SqlDbType.Int);
            param[0].Value = bitacora;
            param[0].Direction = ParameterDirection.Input;
            param[1] = new SqlParameter("INT_VEHICULO", SqlDbType.Int);
            param[1].Value = vehiculo;
            param[1].Direction = ParameterDirection.Input;
            param[2] = new SqlParameter("INT_CONDUCTOR", SqlDbType.Int);
            param[2].Value = conductor;
            param[2].Direction = ParameterDirection.Input;

            resultado = SqlHelper.ExecuteNonQuery(conn.CadenaConexion, System.Data.CommandType.StoredProcedure, "SP_ACTUALIZARBITACORAVEHICULO", param);
            return resultado;
        }
    }
}
