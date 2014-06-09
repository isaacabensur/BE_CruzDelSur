<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NuevoBitacoraVehiculo.aspx.cs" Inherits="WebCruzDelSur.NuevoBitacoraVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
  
  

     <script type="text/javascript">


         $(function () { 



             $("[id$=txtFechaSalida]").datepicker({
                 showOn: 'button',
                 buttonImageOnly: true,
                 buttonImage: 'images/calendar.jpg',
                 dateFormat: "dd/mm/yy",

             });



         });

         $(function () {



             $("[id$=txtFechaLlegada]").datepicker({
                 showOn: 'button',
                 buttonImageOnly: true,
                 buttonImage: 'images/calendar.jpg',
                 dateFormat: "dd/mm/yy",

             });



         });
    </script>
    
    
     <div class="divTitulo">
            Registrar Bitacora de Vehiculo
     </div>
      <div class="divContenido">
          
          
          <table class="ui-accordion" style="width:80%">
              <tr>
                  <td style="width:20%">Placa</td>
                  <td style="width:30%">
                      <asp:DropDownList ID="ddlAutos" runat="server">
                      </asp:DropDownList>
                  </td>
                  <td style="width:30%">&nbsp;</td>
                  <td style="width:20%">&nbsp;</td>
              </tr>
              <tr>
                  <td>Fecha Salida</td>
                  <td>
                      <asp:TextBox ID="txtFechaSalida" runat="server" ReadOnly="true"></asp:TextBox>



                

                  </td>
                  <td>Fecha llegada</td>
                  <td>
                      <asp:TextBox ID="txtFechaLlegada" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>Lugar Salida</td>
                  <td>
                      <asp:DropDownList ID="ddlAgenciaSalida" runat="server">
                      </asp:DropDownList>
                  </td>
                  <td>Lugar llegada</td>
                  <td>
                      <asp:DropDownList ID="ddlAgenciallegada" runat="server">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td>KM inicial</td>
                  <td>
                      <asp:TextBox ID="txtKmInicial" runat="server"></asp:TextBox>
                  </td>
                  <td>KM final</td>
                  <td>
                      <asp:TextBox ID="txtKmFinal" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>Condicion Vehiculo</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td colspan="4">
                      <asp:TextBox ID="txtCondicion" runat="server" TextMode="MultiLine" Width="100%" Height="60%"></asp:TextBox>
                  </td>
              </tr>
          </table>
          
          
    </div>
     
        
</asp:Content>
