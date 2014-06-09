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
    public partial class BuscarBitacoraVehiculo : System.Web.UI.Page
    {
        //IBR_Carga carga = new BR_Carga();
        //IBR_Estado estado = new BR_Estado();
        IBR_BitacoraVehiculo bitacora = new BR_BitacoraVehiculo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlAutos.DataSource = bitacora.f_ListarVehiculos();
                ddlAutos.DataValueField = "CodigoVehiculo";
                ddlAutos.DataTextField = "PlacaVehiculo";
                ddlAutos.DataBind();

            }
        }

        protected void gridCarga_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           // string estado = ddlEstado.SelectedValue;
           // string fHasta = txtFechaHasta.Text;
            string fDesde = txtFechaInicio.Text;
            int codigoVehiculo = int.Parse(ddlAutos.SelectedValue);
            int codigoConductor = 0;

            gridBitacora.DataSource = bitacora.f_ListarBitacoraVehiculo(codigoVehiculo,codigoConductor, fDesde);
            gridBitacora.DataBind();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/NuevoBitacoraVehiculo.aspx");
        }
    }
}