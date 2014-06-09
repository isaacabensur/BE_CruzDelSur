<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BuscarBitacoraVehiculo.aspx.cs" Inherits="WebCruzDelSur.BuscarBitacoraVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    


    <script type="text/javascript" src="Scripts/jquery.datetimepicker.js"></script>


<script type="text/javascript">


    $(function () {

      

        $("[id$=txtFechaInicio]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'images/calendar.jpg',
            dateFormat: "dd/mm/yy",
            
        });

       
       
    });
    </script>
        <div class="divTitulo">
            Buscar Bitacora de Vehiculo
        </div>
        <div class="divFiltro">
            <div class="divFila">                            
                <div class="divColumna">&nbsp;</div>
                <div class="divColumna">
                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/Images/new.jpg" OnClick="btnNuevo_Click" Width="15"/> Registrar Nueva Bitacora</div>
            </div>
            <div class="divFila">
                <div class="divColumna">
                    <div class="divTexto">
                        PLACA: 
                    </div>
                    <div class="divControl">
                        <asp:DropDownList ID="ddlAutos" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="divColumna">
                    <div class="divTexto">
                        Fecha de Salida:
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtFechaInicio" runat="server" />
                    </div>
                </div>
            </div>
            
            <div class="divFila">
                <div class="divColumna">                    
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Bitacora" 
                        OnClick="btnBuscar_Click"/>
                </div>
            </div>
        </div>
        <div class="divResultado">
            <asp:Label ID="lblSinResultados" Text="No hay Resultados disponibles" runat="server"/>
            <div class="divEspacio">&nbsp;</div>
            <asp:GridView ID="gridBitacora" runat="server" OnRowCommand="gridCarga_RowCommand" AutoGenerateColumns="False" Width="800px" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="CodigoBitacoraVehiculo" HeaderText="Código Bitacora" />
                    <asp:BoundField DataField="Combustible" HeaderText="Combustible" />
                    <asp:BoundField DataField="FechaHoraSalida" HeaderText="Hora Salida" />
                    <asp:BoundField DataField="FechaHoraLlegada" HeaderText="Hora llegada" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" Text="Opciones" runat="server"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <%-- <asp:HiddenField ID="lblCodigoCarga" runat="server" Value='<%# Bind("CodigoCarga") %>'/>--%>
                            <asp:ImageButton ID="btnEditar" CommandName="Editar" runat="server" ImageUrl="~/Images/edit.jpg" Width="15"/>
                            <asp:ImageButton ID="btnEliminar" CommandName="Eliminar" runat="server" ImageUrl="~/Images/delete.jpg" Width="15"/>
                            <asp:ImageButton ID="btnImprimir" CommandName="Imprimir" runat="server" ImageUrl="~/Images/print.jpg" Width="15"/>
                        
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
