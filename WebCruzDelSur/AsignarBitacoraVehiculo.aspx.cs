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
    public partial class AsignarBitacoraVehiculo : System.Web.UI.Page
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
                btnActualizar.Visible = false;

            }
        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/NuevoAsignarBitacoraVehiculo.aspx");
        }

        protected void gridAsignaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
               
                String[] variables = Convert.ToString(e.CommandArgument).Split('@');
                ViewState["VW_CodigoBitacora"] = variables[0].Trim();
                string codigoVehiculo = variables[1].Trim();
                string codigoConductor = variables[2].Trim();
                string dni = variables[3].Trim();
                string conductor = variables[4].Trim();
                txtCodConductor.Text = codigoConductor;
                txtDni.Text = dni;
                txtConductor.Text = conductor;
                ddlPlaca.SelectedIndex = -1;
                ddlPlaca.Items.FindByValue(codigoVehiculo).Selected = true;
                btnActualizar.Visible = true;
             
            }
        }

        protected void btnDni_Click(object sender, ImageClickEventArgs e)
        {
            if (txtDni.Text != "")
            {
                //lblMensaje.Text = "";
                List<BE_Conductor> lst = new List<BE_Conductor>();
                string dni = txtDni.Text.Trim();
                lst = bitacora.f_BuscarConductorxDNI(dni);
                txtConductor.Text = lst[0].NombreCompleto;
                txtCodConductor.Text = lst[0].Codigo.ToString();
            }
            else
            {
                //lblMensaje.Text = "Ingrese codigo de Conductor";
                txtConductor.Text = "";
                txtCodConductor.Text = "";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodConductor.Text = "";
            txtConductor.Text = "";
            txtDni.Text = "";
            ddlPlaca.SelectedIndex = -1;
            lblMensaje.Text = "";
            int codigoConductor = 0;
            int codigoVehiculo = 0;
            //int codigoVehiculo = int.Parse(ddlPlaca.SelectedValue);

            if(txtCodConductor.Text!="")
                codigoConductor = int.Parse(txtCodConductor.Text);
            if(ddlPlaca.SelectedValue!="0")
               codigoVehiculo = int.Parse(ddlPlaca.SelectedValue);
             
            gridAsignaciones.DataSource = bitacora.f_ListarBitacoraVehiculo(codigoVehiculo, codigoConductor, "");
            gridAsignaciones.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCodConductor.Text.Trim() != "0" && ddlPlaca.SelectedValue != "0")
            {
                int codigoConductor = int.Parse(txtCodConductor.Text.Trim());
                int codigoVehiculo = int.Parse(ddlPlaca.SelectedValue);
                int resultado = bitacora.f_actualizarAsignacionBitacora(codigoVehiculo, codigoConductor,int.Parse(ViewState["VW_CodigoBitacora"].ToString())) ;
                if (resultado > 0)
                    lblMensaje.Text = "Actualizacion Exitosa";
                     
                else
                    lblMensaje.Text = "Ocurrio un inconveniente";
                btnActualizar.Visible = false;
                txtDni.Text = "";
                txtConductor.Text = "";
                txtCodConductor.Text = "";
                ddlPlaca.SelectedIndex = -1;
                codigoConductor = 0;
                codigoVehiculo=0;
                gridAsignaciones.DataSource = bitacora.f_ListarBitacoraVehiculo(codigoVehiculo, codigoConductor, "");
                gridAsignaciones.DataBind();

            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {

        }

      

     

       

       
    }
}