using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BR_CruzDelSur;
using BR_CruzDelSur.Interfaces;
using BE_CruzDelSur;

namespace WebCruzDelSur
{
    public partial class NuevoAsignarBitacoraVehiculo : System.Web.UI.Page
    {
        IBR_BitacoraVehiculo bitacora = new BR_BitacoraVehiculo();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlPlaca.DataSource = bitacora.f_ListarVehiculos();
                ddlPlaca.DataValueField = "CodigoVehiculo";
                ddlPlaca.DataTextField = "PlacaVehiculo";
                ddlPlaca.DataBind();


            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if(txtdni.Text!="")
            {
                lblMensaje.Text = "";
                List<BE_Conductor> lst = new List<BE_Conductor>();
                string dni = txtdni.Text.Trim();
                lst = bitacora.f_BuscarConductorxDNI(dni);
                txtConductor.Text = lst[0].NombreCompleto;
                txtCodConductor.Text = lst[0].Codigo.ToString();
            }
            else
            {
                lblMensaje.Text = "Ingrese codigo de Conductor";
            }

            
           
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {


            if (txtCodConductor.Text.Trim() != "0" && ddlPlaca.SelectedValue != "0")
             {
            int codigoConductor = int.Parse(txtCodConductor.Text.Trim());
            int codigoVehiculo = int.Parse(ddlPlaca.SelectedValue);
            int resultado= bitacora.f_registrarAsignacionBitacora(codigoVehiculo,codigoConductor);
            if (resultado > 0)
                lblMensaje.Text = "Registro Exitoso";
            else
                lblMensaje.Text = "Ocurrio un inconveniente";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AsignarBitacoraVehiculo.aspx");
        }
    }
}