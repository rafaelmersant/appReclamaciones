<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListaReclamaciones.aspx.vb" Inherits="ListaReclamaciones" title="Reclamaciones" Culture="es-DO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                    Text="Lista de Reclamaciones" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Buscar por:" Width="79px" CssClass="LFiltros"></asp:Label>
                <asp:DropDownList ID="ddlBuscaPor" runat="server" Width="120px" CssClass="LetraFiles">
                    <asp:ListItem Selected="True" Value="0">Elegir...</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem Value="Numero">N&#250;mero</asp:ListItem>
                    <asp:ListItem Value="Descripcion">Descripci&#243;n</asp:ListItem>
                    <asp:ListItem>Cliente</asp:ListItem>
                    <asp:ListItem>Motivo</asp:ListItem>
                    <asp:ListItem>Area</asp:ListItem>
                    <asp:ListItem>Factura</asp:ListItem>
                    <asp:ListItem>Chofer</asp:ListItem>
                    <asp:ListItem>Transportista</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label10" runat="server" CssClass="LFiltros" Font-Italic="True" Font-Size="10px"
                    ForeColor="Gray" Text="Si desea ver todas las reclamaciones presione ->" Width="272px"></asp:Label>
                <asp:Button ID="btnVerTodas" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Text="VER TODAS" Width="126px" Height="20px" /></td>
        </tr>
        <tr>
            <td>
                <table width="50%">
                    <tr>
                        <td colspan="2" rowspan="3">
                <div id="porfecha" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;">
                    <table>
                        <tr>
                            <td valign="top" style="padding-bottom:2px">
                                <asp:Label ID="Label3" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label></td>
                            <td valign="top">
                                <asp:TextBox ID="txtFechaI" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px"></asp:TextBox><asp:Label ID="Label8" runat="server" CssClass="LFiltros"
                                        Font-Italic="True" Font-Size="10px" ForeColor="Gray" Text="(mm/dd/aaaa)" Width="87px"></asp:Label><cc1:CalendarExtender ID="CalendarExtenderFI" runat="server" Format="MM/dd/yyyy" TargetControlID="txtFechaI" CssClass="CalendarExtenderFI" FirstDayOfWeek="Monday">
                                </cc1:CalendarExtender>
                            </td>
                            <td align="right" valign="top">
                                <asp:Label ID="Label5" runat="server" CssClass="LFiltros" Text="Estatus" Width="52px"></asp:Label></td>
                            <td valign="top"><asp:DropDownList ID="ddlEstatus" runat="server" Width="120px" CssClass="LetraFiles">
                                <asp:ListItem>TODOS</asp:ListItem>
                                <asp:ListItem>EN PROCESO</asp:ListItem>
                                <asp:ListItem>CERRADA</asp:ListItem>
                            </asp:DropDownList></td>                            
                            <td rowspan="2" style="width: 92px" valign="middle">
                                <asp:ImageButton ID="imgbtnBFecha" runat="server" ImageUrl="~/Images/SearchB.png"/></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label4" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label></td>
                            <td valign="top">
                                <asp:TextBox ID="txtFechaF" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px"></asp:TextBox><asp:Label ID="Label9" runat="server" CssClass="LFiltros"
                                        Font-Italic="True" Font-Size="10px" ForeColor="Gray" Text="(mm/dd/aaaa)" Width="87px"></asp:Label><cc1:CalendarExtender ID="CalendarExtenderFF" runat="server" Format="MM/dd/yyyy"
                                    TargetControlID="txtFechaF" CssClass="CalendarExtenderFF" FirstDayOfWeek="Monday">
                                </cc1:CalendarExtender>
                            </td>
                            <td align="right" valign="top">
                                <asp:Label ID="Label6" runat="server" CssClass="LFiltros" Text="Ventas" Width="51px"></asp:Label></td>
                            <td valign="top"><asp:DropDownList ID="ddlVentas" runat="server" Width="120px" CssClass="LetraFiles">
                                <asp:ListItem>TODAS</asp:ListItem>
                                <asp:ListItem>LOCALES</asp:ListItem>
                                <asp:ListItem>INTERNACIONALES</asp:ListItem>
                            </asp:DropDownList></td>
                            
                        </tr>
                    </table>
                </div>
                
                <div id="pornumero" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;" >
                <asp:Label ID="Label14" runat="server" Font-Bold="True"
                    Text="Número" Width="93px" CssClass="LFiltros"></asp:Label><asp:TextBox ID="txtNoReclamacion" runat="server"
                        Height="12px" TabIndex="1" Width="81px" CssClass="LAzul"></asp:TextBox>
                <asp:ImageButton ID="btnBuscaReclam" runat="server" ImageUrl="~/Images/search.png"/></div>
                
                <div id="pordescrp" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;">
                <asp:Label ID="Label7" runat="server" Font-Bold="True"
                    Text="Descripción" Width="93px" CssClass="LFiltros"></asp:Label><asp:TextBox ID="txtDescrp" runat="server"
                        Height="12px" TabIndex="1" Width="407px" CssClass="LAzul"></asp:TextBox>
                <asp:ImageButton ID="imgbtnBDescrp" runat="server" ImageUrl="~/Images/search.png"/></div>
                
                <div id="porcliente" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;">
                <asp:Label ID="Label11" runat="server" Font-Bold="True"
                    Text="Cliente" Width="93px" CssClass="LFiltros"></asp:Label><asp:TextBox ID="txtCliente" runat="server"
                        Height="12px" TabIndex="1" Width="407px" CssClass="LAzul"></asp:TextBox>
                <asp:ImageButton ID="imgbtnBCliente" runat="server" ImageUrl="~/Images/search.png"/></div>
                
                <div id="pormotivo" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;">
                    <asp:Label ID="Label13" runat="server" CssClass="LFiltros" Font-Bold="True" Text="Motivos"
                        Width="93px"></asp:Label><asp:DropDownList ID="ddlMotivos" runat="server" TabIndex="5"
                        Width="350px">
                    </asp:DropDownList><asp:ImageButton ID="imgBtnBMotivo" runat="server" ImageUrl="~/Images/search.png"/><br />
                    
                    <table>
                        <tr>
                            <td>
                    <asp:Label ID="Label16" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="txtFechaIM" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                        Width="81px"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                    <asp:Label ID="Label17" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label></td>
                            <td>
                    <asp:TextBox ID="txtFechaFM" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                        Width="81px"></asp:TextBox></td>
                            
                        </tr>
                    
                    </table>
                    </div>
                    
                    <div id="porarea" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;">
                    <asp:Label ID="Label12" runat="server" CssClass="LFiltros" Font-Bold="True" Text="Areas"
                        Width="93px"></asp:Label><asp:DropDownList ID="ddlAreas" runat="server" TabIndex="5"
                        Width="350px">
                    </asp:DropDownList><asp:ImageButton ID="imgbtnBArea" runat="server" ImageUrl="~/Images/search.png"/><br />
                        
                        <table>
                        <tr>
                            <td>
                    
                        <asp:Label ID="Label18" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label>
                            </td>
                            <td>
                        <asp:TextBox ID="txtFechaIA" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                            Width="81px"></asp:TextBox>
                       
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                        <asp:Label ID="Label19" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label><td>
                        <asp:TextBox ID="txtFechaFA" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                            Width="81px"></asp:TextBox></td>
                            
                        </tr>
                    
                    </table>
                    
                        </div>
                    
                    <div id="porfactura" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;" >
                        <asp:Label ID="Label15" runat="server" Font-Bold="True"
                            Text="Factura" Width="93px" CssClass="LFiltros"></asp:Label>
                        <asp:TextBox ID="txtFactura" runat="server"
                            Height="12px" TabIndex="1" Width="81px" CssClass="LAzul"></asp:TextBox>
                        <asp:ImageButton ID="imgbtnFactura" runat="server" ImageUrl="~/Images/search.png"/>
                    </div>
                    
                    
                    <div id="porchofer" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;" >
                        <asp:Label ID="Label20" runat="server" Font-Bold="True"
                            Text="Chofer" Width="93px" CssClass="LFiltros"></asp:Label>&nbsp;<asp:DropDownList ID="ddlChofer" runat="server" TabIndex="5"
                        Width="350px">
                            </asp:DropDownList>
                        <asp:ImageButton ID="imgbtnChofer" runat="server" ImageUrl="~/Images/search.png"/>
                    </div>
                    
                    
                    <div id="portransportista" style="border: 1px dotted blue; padding: 2px 2px 2px 2px;" >
                        <asp:Label ID="Label21" runat="server" Font-Bold="True"
                            Text="Transportista" Width="93px" CssClass="LFiltros"></asp:Label>&nbsp;<asp:DropDownList ID="ddlTransportista" runat="server" TabIndex="5"
                        Width="350px">
                            </asp:DropDownList>
                        <asp:ImageButton ID="imgbtnTransportista" runat="server" ImageUrl="~/Images/search.png"/>
                    </div>
                    
                
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    
                </table>
                <cc1:CalendarExtender ID="CalendarExtenderFIM" runat="server" CssClass="CalendarExtenderFI"
                    FirstDayOfWeek="Monday" Format="MM/dd/yyyy" TargetControlID="txtFechaIM">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtenderFFM" runat="server" CssClass="CalendarExtenderFF"
                    FirstDayOfWeek="Monday" Format="MM/dd/yyyy" TargetControlID="txtFechaFM">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtenderFIA" runat="server" CssClass="CalendarExtenderFI"
                    FirstDayOfWeek="Monday" Format="MM/dd/yyyy" TargetControlID="txtFechaIA">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtenderFFA" runat="server" CssClass="CalendarExtenderFF"
                    FirstDayOfWeek="Monday" Format="MM/dd/yyyy" TargetControlID="txtFechaFA">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdReclamaciones" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="15">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="WhiteSmoke" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="11px" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id_reclamacion" HeaderText="Reclamaci&#243;n" DataFormatString="{0:00000000}" HtmlEncode="False">
                            <ItemStyle CssClass="gridItems" Width="5%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="status" HeaderText="Estatus">
                            <ItemStyle CssClass="gridItems" Width="10%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre_Cte" runat="server" CssClass="gridItems" Text='<%# bind("ncliente") %>'></asp:Label>
                                <asp:Label ID="lblCod_Cte" runat="server" Text='<%# bind("cliente") %>' Visible="False"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridHeaders" />
                            <ItemStyle CssClass="gridItems" Width="18%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="pedido" HeaderText="Pedido">
                            <ItemStyle CssClass="gridItems" Width="8%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="factura" HeaderText="Factura">
                            <ItemStyle CssClass="gridItems" Width="8%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripci&#243;n de Reclamaci&#243;n">
                            <ItemStyle CssClass="gridItems" Width="20%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" HtmlEncode="False">
                            <ItemStyle CssClass="gridItems" Width="10%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha_close" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Cerrada"
                            HtmlEncode="False">
                            <HeaderStyle CssClass="gridHeaders" />
                            <ItemStyle CssClass="gridItems" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Monto" HeaderText="Monto" Visible="False">
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="gridItems" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NCND" HeaderText="NC_ND" Visible="False">
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="gridItems" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" Visible="False">
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="gridItems" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MotivoDescripcion" HeaderText="Motivo Descripcion" Visible="False">
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="gridItems" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AreaDescripcion" HeaderText="Area Descripcion" Visible="False">
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="gridItems" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Ver">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnVerRec" runat="server" CommandArgument='<%# bind("id_reclamacion") %>'
                                    ImageUrl="~/Images/search.gif" OnClick="btnVerRec_Click" OnClientClick="aspnetForm.target='_blank';" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNoExiste" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="DimGray"
                    Visible="False" Width="100%">No existen reclamaciones con los parámetros especificados.</asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnNuevaRecl" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                    PostBackUrl="~/Reclamacion.aspx" Text="Nueva Reclamación" Width="146px" Visible="False" />
                <asp:Image ID="imgUtil" runat="server" Height="1px" ImageUrl="~/Images/LineaG.gif"
                    Width="1px" /></td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnToExcel" runat="server" ImageUrl="~/Images/xlslogo.jpg" Visible="False" /></td>
        </tr>
    </table>
    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red" Width="100%"></asp:Label>
</asp:Content>

