<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BuscarCarga.aspx.cs" Inherits="WebCruzDelSur.BuscarCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("[id$=txtFechaEnvio]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'images/calendar.jpg'
            });

            $("[id$=txtFechaHasta]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'images/calendar.jpg'
            });
        });
    </script>
        <div class="divTitulo">
            Buscar Gestión de Carga de Clientes
        </div>
        <div class="divFiltro">
            <div class="divFila">                            
                <div class="divColumna">&nbsp;</div>
                <div class="divColumna">
                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/Images/new.jpg" OnClick="btnNuevo_Click" Width="15"/> Registrar Nueva Carga
                </div>
            </div>
            <div class="divFila">
                <div class="divColumna">
                    <div class="divTexto">
                        Nombres de Cliente: 
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtCliente" runat="server" />
                    </div>
                </div>
                <div class="divColumna">
                    <div class="divTexto">
                        Fecha de Envío Desde:
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtFechaEnvio" runat="server" />
                    </div>
                </div>
            </div>
            <div class="divFila">
                <div class="divColumna">
                    <div class="divTexto">
                        Fecha de Envío Hasta:
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtFechaHasta" runat="server" />
                    </div>
                </div>
                <div class="divColumna">
                    <div class="divTexto">
                         Estado:
                    </div>
                    <div class="divControl">
                        <asp:DropDownList ID="ddlEstado" runat="server"/> 
                    </div>
                </div>
            </div>
            <div class="divFila">
                <div class="divColumna">                    
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Carga" OnClick="btnBuscar_Click"/>
                </div>
            </div>
        </div>
        <div class="divResultado">
            <asp:Label ID="lblSinResultados" Text="No hay Resultados disponibles" runat="server"/>
            <div class="divEspacio">&nbsp;</div>
            <asp:GridView ID="gridCarga" runat="server" OnRowCommand="gridCarga_RowCommand" AutoGenerateColumns="false" Width="800px">
                <Columns>
                    <asp:BoundField DataField="secuenciaCarga" HeaderText="Código Carga" SortExpression="secuenciaCarga" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblCliente" Text="Cliente" runat="server"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblClienteData" runat="server" Text='<%# Bind("ClienteOrigen.NombreCompleto") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblFechaOrigen" Text="Fecha Origen" runat="server"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFechaOrigenData" runat="server" Text='<%# Bind("ProgramacionRuta.FechaOrigen") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblEstado" Text="Estado" runat="server"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEstadoData" runat="server" Text='<%# Bind("Estado.Nombre") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                                        
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label Text="Opciones" runat="server"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="lblCodigoCarga" runat="server" Value='<%# Bind("CodigoCarga") %>'/>
                            <asp:ImageButton ID="btnEditar" CommandName="Editar" runat="server" ImageUrl="~/Images/edit.jpg" Width="15"/>
                            <asp:ImageButton ID="btnEliminar" CommandName="Eliminar" runat="server" ImageUrl="~/Images/delete.jpg" Width="15"/>
                            <asp:ImageButton ID="btnImprimir" CommandName="Imprimir" runat="server" ImageUrl="~/Images/print.jpg" Width="15"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
