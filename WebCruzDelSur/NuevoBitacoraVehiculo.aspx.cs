using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BR_CruzDelSur;
using BR_CruzDelSur.Interfaces;

namespace WebCruzDelSur
{
    public partial class NuevoBitacoraVehiculo : System.Web.UI.Page
    {
        IBR_BitacoraVehiculo bitacora = new BR_BitacoraVehiculo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlAutos.DataSource = bitacora.f_ListarVehiculos();
                ddlAutos.DataValueField = "CodigoVehiculo";
                ddlAutos.DataTextField = "PlacaVehiculo";
                ddlAutos.DataBind();

                

                ddlAgenciallegada.DataSource = bitacora.f_ListarAgencias();
                ddlAgenciallegada.DataValueField = "codigoAgencia";
                ddlAgenciallegada.DataTextField = "nombreAgencia";
                ddlAgenciallegada.DataBind();

                ddlAgenciaSalida.DataSource = bitacora.f_ListarAgencias();
                ddlAgenciaSalida.DataValueField = "codigoAgencia";
                ddlAgenciaSalida.DataTextField = "nombreAgencia";
                ddlAgenciaSalida.DataBind();

            }

        }
    }
}