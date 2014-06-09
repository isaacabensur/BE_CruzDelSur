<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NuevoAsignarBitacoraVehiculo.aspx.cs" Inherits="WebCruzDelSur.NuevoAsignarBitacoraVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="divTitulo">
            Nueva Asignacion de Bitacora Vehiculo
     </div>


    <div class="divContenido">
          
          
          <table class="ui-accordion" style="width:80%">
              <tr>
                  <td style="width:20%">DNI</td>
                  <td style="width:30%">
                      <asp:TextBox ID="txtdni" runat="server" style="width: 128px"></asp:TextBox>
                    <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Images/edit.jpg" OnClick="btnBuscar_Click" Width="15"/> 
                  </td>
                  <td style="width:30%">&nbsp;</td>
                  <td style="width:20%">&nbsp;</td>
              </tr>
              <tr>
                  <td>Conductor</td>
                  <td>
                      <asp:TextBox ID="txtConductor" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>



                

                  </td>
                  <td>
                      <asp:TextBox ID="txtCodConductor" runat="server" Visible="False"></asp:TextBox>
                  </td>
                  <td>
                     
                  </td>
              </tr>
              <tr>
                  <td>Placa Vehiculo</td>
                  <td>
                      <asp:DropDownList ID="ddlPlaca" runat="server" Height="16px" Width="159px">
                      </asp:DropDownList>
                  </td>
                  <td></td>
                  <td>
                     
                  </td>
              </tr>
              
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>
                     
                      &nbsp;</td>
              </tr>
              
              <tr>
                  <td>
                      <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrar Asignacion" Width="150px" OnClientClick = " return confirm('Desea realizar la asignacion?');" />
                  </td>
                  <td>
                      <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" Width="120px" />
                  </td>
                  <td>&nbsp;</td>
                  <td>
                     
                      &nbsp;</td>
              </tr>
              
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>
                     
                      &nbsp;</td>
              </tr>
              
              <tr>
                  <td>
                      <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>
                     
                      &nbsp;</td>
              </tr>
              
          </table>
          
          
    </div>

</asp:Content>
