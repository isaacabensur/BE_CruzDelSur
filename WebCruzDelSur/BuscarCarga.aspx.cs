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
    public partial class BuscarCarga : System.Web.UI.Page
    {
        IBR_Carga carga = new BR_Carga();
        IBR_Estado estado =  new BR_Estado();
            
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                ddlEstado.DataSource = estado.f_ListarEstados("C", true);
                ddlEstado.DataValueField = "Codigo";
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataBind();

            }
        }

        protected void gridCarga_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string estado = ddlEstado.SelectedValue;
            string fHasta = txtFechaHasta.Text;
            string fDesde = txtFechaEnvio.Text;
            string cliente = txtCliente.Text;

            gridCarga.DataSource = carga.f_ListarCargas(cliente, fDesde, fHasta, estado);
            gridCarga.DataBind();
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}