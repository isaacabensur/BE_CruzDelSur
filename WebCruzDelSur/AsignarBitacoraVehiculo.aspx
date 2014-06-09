<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AsignarBitacoraVehiculo.aspx.cs" Inherits="WebCruzDelSur.AsignarBitacoraVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <div class="divTitulo">
            Asignar Bitacora de Vehiculos
        </div>
    <div class="divFiltro">
            <div class="divFila">                            
                <div class="divColumna">&nbsp;</div>
                <div class="divColumna">
                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/Images/new.jpg" OnClick="btnNuevo_Click" Width="15"/> Nueva Asignacion
                </div>
            </div>

            <div class="divFila">
                <div class="divColumna">
                    <div class="divTexto">
                        DNI: 
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtDni" runat="server" /> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/edit.jpg" OnClick="btnDni_Click" Width="15"/> 
                    </div>
                </div>
                <div class="divColumna">
                    <div class="divTexto">
                     
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtCodConductor" runat="server" Visible="False" />
                    </div>
                </div>
            </div>

            <div class="divFila">
                <div class="divColumna">
                    <div class="divTexto">
                        Conductor: 
                    </div>
                    <div class="divControl">
                        <asp:TextBox ID="txtConductor" runat="server" ReadOnly="True" />
                    </div>
                </div>
                <div class="divColumna">
                    <div class="divTexto">
                        Placa:
                    </div>
                    <div class="divControl">
                        <asp:DropDownList ID="ddlPlaca" runat="server" Height="16px" Width="129px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
           
            


            <div class="divFila">
                <div class="divColumna">                    
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Asignaciones" 
                        OnClick="btnBuscar_Click"/>
                </div>
                <div class="divColumna">                    
                     <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Visible="False"  OnClientClick = " return confirm('Desea actualizar la asignacion?');"/>
                      <asp:Button ID="btnAnular" runat="server" OnClick="btnAnular_Click" Text="Anular" Visible="False"  OnClientClick = " return confirm('Desea Anular la asignacion?');"/>
                </div>
               
            </div>
            <div class="divFila">
                <div class="divColumna">                    
                    
                </div>
             
                <div class="divColumna">                    
                  <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
               
            </div>
        <div class="divFila">
                <div class="divColumna">                    
                    <asp:Label ID="lblSinResultados" Text="No hay Resultados disponibles" runat="server"/>
                </div>
             
                <div class="divColumna">                    
                  
                </div>
               
            </div>

        </div>

    <div class="divResultado">
            
            <div class="divEspacio">&nbsp;</div>
            <asp:GridView ID="gridAsignaciones" runat="server" OnRowCommand="gridAsignaciones_RowCommand" AutoGenerateColumns="False" Width="800px" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField HeaderText="Codigo Asignacion" DataField="CodigoBitacoraVehiculo" />
                    <asp:BoundField DataField="FechaHoraSalida" HeaderText="Fecha Salida" />
                    <asp:BoundField HeaderText="Placa" DataField="PlacaVehiculo" />
                    <asp:BoundField HeaderText="Marca" DataField="marcavehiculo" />
                    <asp:BoundField DataField="nombreConductor" HeaderText="Conductor" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" Text="Opciones" runat="server"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <asp:ImageButton ID="btnEditar"  CommandArgument='<%# Eval("CodigoBitacoraVehiculo")+"@"+Eval("CodigoVehiculo")+"@"+Eval("CodigoConductor")+"@"+Eval("dni")+"@"+Eval("nombreConductor") %>' CommandName="Editar" runat="server" ImageUrl="~/Images/edit.jpg" Width="15"/>
                        <asp:ImageButton ID="btnEliminar" CommandName="Eliminar" runat="server" ImageUrl="~/Images/delete.jpg" Width="15"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
