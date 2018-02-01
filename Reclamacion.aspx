<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Reclamacion.aspx.vb" Inherits="Reclamacion" Title="Reclamaciones" Culture="ES-do" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                    Text="RECLAMACION #: " Width="133px"></asp:Label>
                <asp:Label ID="lblNoReclamacion" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                    Text="000000001" Width="93px"></asp:Label></td>
            <td align="right" colspan="">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                    Text="ESTATUS: " Width="69px"></asp:Label>&nbsp;
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                    Text="EN PROGRESO"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                    Text="TIPO DOCUMENTO: " Width="133px"></asp:Label>
                <asp:DropDownList ID="ddlTipoDoc" runat="server" Width="160px" TabIndex="5" CssClass="LetraH">
                    <asp:ListItem Value="NODEFINE">---------------</asp:ListItem>
                    <asp:ListItem>RECLAMACION</asp:ListItem>
                    <asp:ListItem>DEVOLUCION</asp:ListItem>
                </asp:DropDownList></td>
            <td align="right" colspan="1">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Text="Contacto" Width="80px" CssClass="LetraH1" Font-Size="12px" Visible="False"></asp:Label>
                                <asp:TextBox ID="txtTipoPedido" runat="server" Height="11px" TabIndex="1" Width="16px" CssClass="LetraH2" ReadOnly="True" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txtContacto" runat="server" Width="16px" TabIndex="3" Height="11px" CssClass="LetraH2" Visible="False"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana"
                                    Text="Motivo" Width="80px" Font-Size="12px" Visible="False"></asp:Label>
                <asp:DropDownList ID="ddlTransportista" runat="server" Width="57px" TabIndex="8" CssClass="LetraH2" Height="16px" Visible="False">
                </asp:DropDownList>
                <asp:Label ID="Label26" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="12px" ForeColor="Black" Text="Transp." Width="53px" Visible="False"></asp:Label><asp:DropDownList ID="ddlChoferes" runat="server" Width="47px" TabIndex="8" CssClass="LetraH2" Height="16px" Visible="False">
                    </asp:DropDownList>
                <asp:Label ID="Label25" runat="server" Font-Bold="True"
                    Font-Names="Verdana" Text="Chofer" Width="53px" CssClass="LetraH1" Font-Size="12px" ForeColor="Black" Visible="False"></asp:Label>
                <asp:DropDownList ID="ddlPlanta" runat="server" Width="42px" TabIndex="9" CssClass="LetraH2" Height="16px" Visible="False">
                </asp:DropDownList>
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Text="Planta" Width="53px" CssClass="LetraH1" Font-Size="12px" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" BackColor="Gray" Font-Bold="True" ForeColor="White"
                    Text="Formulario de Reclamaciones de Clientes (RC)" Width="100%" CssClass="headerPrincipal" Height="19px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnDetalles" runat="server" Width="100%">

                    <table cellpadding="1" cellspacing="0" width="100%" style="border-right: gray thin outset; border-top: gray thin outset; border-left: gray thin outset; border-bottom: gray thin outset">
                        <tr>
                            <td style="height: 22px;" valign="bottom" align="left">
                                <asp:Label ID="Label14" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana"
                                    Text="Buscar Por" Width="80px" Font-Size="12px"></asp:Label></td>
                            <td valign="bottom">
                                <asp:RadioButton ID="rbFactura" runat="server" Checked="True" CssClass="LetraH2"
                                    Text="Factura" GroupName="Find" />
                                <asp:RadioButton ID="rbPedido" runat="server" CssClass="LetraH2" Text="Pedido" GroupName="Find" /></td>
                            <td style="border-left: #ccccff thin outset; width: 10%;" valign="middle">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Text="Fecha" Width="53px" CssClass="LetraH1" Font-Size="12px"></asp:Label></td>
                            <td style="width: 40%">
                                <asp:TextBox ID="txtFecha" runat="server" TabIndex="6" Height="11px" Enabled="False" Width="157px" CssClass="LetraH2"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Text="Numero #" Width="80px" CssClass="LetraH1" Font-Size="12px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPedido" runat="server" TabIndex="1" Height="11px" Width="87px" CssClass="LetraH2"></asp:TextBox>
                                <asp:ImageButton
                                    ID="btnBuscaPedido" runat="server" ImageUrl="~/Images/search.png" />
                                <asp:Label ID="lblExiste" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                    ForeColor="Red" Text="Existe una reclamacion con este documento." Visible="False"></asp:Label></td>
                            <td style="border-left: #ccccff thin outset; width: 10%;" valign="middle">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Text="Teléfono" Width="53px" CssClass="LetraH1" Font-Size="12px"></asp:Label></td>
                            <td style="width: 40%">
                                <asp:TextBox ID="txtTelefono" runat="server" TabIndex="7" Height="11px" Width="101px" CssClass="LetraH2"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label5" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana" Font-Size="12px" Text="Nombre Cliente"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="LetraH2" TabIndex="2" Width="295px">
                                </asp:DropDownList>
                            </td>
                            <td style="border-left: #ccccff thin outset; width: 10%;" valign="middle">
                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Text="Vendedor" Width="53px" CssClass="LetraH1" Font-Size="12px"></asp:Label></td>
                            <td style="width: 40%">
                                <asp:DropDownList ID="ddlVendedor" runat="server" Width="264px" TabIndex="8" CssClass="LetraH2">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label21" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana" Font-Size="12px" Text="Soporte Venta"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSoporteVta" runat="server" CssClass="LetraH2" Height="11px" TabIndex="1" Width="290px"></asp:TextBox>
                            </td>
                            <td style="border-left: #ccccff thin outset; width: 10%;" valign="middle">
                                <asp:Label ID="Label11" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana" Font-Size="12px" Text="Ventas" Width="53px"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:DropDownList ID="ddlVentas" runat="server" CssClass="LetraH2" TabIndex="5" Width="236px">
                                    <asp:ListItem>LOCALES</asp:ListItem>
                                    <asp:ListItem>INTERNACIONALES</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Label ID="Label10" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana" Font-Size="12px" Text="Factura" Visible="False" Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFactura" runat="server" CssClass="LetraH2" Height="11px" TabIndex="4" Visible="False"></asp:TextBox>
                            </td>
                            <td style="border-left: #ccccff thin outset; width: 10%;" valign="middle">
                                <asp:Label ID="lblCerrada" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana" Font-Size="12px" Text="Cerrada" Visible="False" Width="53px"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:TextBox ID="txtCerradaFecha" runat="server" CssClass="LetraH2" Enabled="False" Font-Bold="True" ForeColor="Red" Height="11px" TabIndex="6" Visible="False" Width="157px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="border-left: #ccccff thin outset; width: 10%;" valign="middle">&nbsp;</td>
                            <td style="width: 40%" valign="bottom">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Label ID="Label23" runat="server" BackColor="Gray" CssClass="headerSimples"
                    Font-Bold="True" ForeColor="White" Height="17px" Text="::Correo del Cliente para envio de correo"
                    Width="100%"></asp:Label><br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label22" runat="server" CssClass="LetraH1" Font-Bold="True" Font-Names="Verdana"
                                Text="Correo Cliente" Font-Size="12px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="LetraH2"
                                TabIndex="1" Width="358px"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnSaveMail" runat="server" BackColor="SteelBlue" BorderColor="LightSlateGray"
                                BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_producto") %>'
                                CssClass="gridItems" Font-Bold="True" ForeColor="White"
                                Text="Guardar" Visible="False" /></td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label19" runat="server" BackColor="Gray" CssClass="headerSimples"
                    Font-Bold="True" ForeColor="White" Height="17px" Text="::Productos" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <table style="width: 45%">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana"
                                Text="Cod. Producto" Width="80px" CssClass="LetraH1"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCodProd" runat="server" Height="11px" TabIndex="1" Width="45px" CssClass="LetraH2"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="btnBProd" runat="server" ImageUrl="~/Images/search.png" /></td>
                        <td>
                            <asp:TextBox ID="txtNameProducto" runat="server" Height="11px" ReadOnly="True" TabIndex="3" Width="213px" CssClass="LetraH2"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="imgbtnSaveProd" runat="server" ImageUrl="~/Images/Save.png" ToolTip="Agregar" /></td>
                        <td>
                            <asp:ImageButton ID="imgbtnRefresh" runat="server" ImageUrl="~/Images/refresh.png" ToolTip="Refrescar" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="grdProdReclam" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" Width="100%">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="cod_prod" HeaderText="C&#243;digo">
                                        <HeaderStyle CssClass="LetraH1" Width="7%" />
                                        <ItemStyle CssClass="gridItems" Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNombreProd" runat="server" CssClass="gridItems"></asp:Label>
                                            <asp:Label ID="lblCod_prod" runat="server" Text='<%# bind("cod_prod") %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="LetraH1" Width="20%" />
                                        <ItemStyle CssClass="gridItems" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quitar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnQuitarProd" runat="server" CommandArgument='<%# bind("id_producto") %>'
                                                ImageUrl="~/Images/delete.png" OnClick="ImageButton2_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="LetraH1" HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle CssClass="gridItems" Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Guardar">
                                        <HeaderStyle CssClass="LetraH1" HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle CssClass="gridItems" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnGuardarComentProd" runat="server" ImageUrl="~/Images/save_small.png" CommandArgument='<%# bind("id_producto") %>' OnClick="imgbtnGuardarComentProd_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comentario">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtComentProd" runat="server" BorderColor="Gray" BorderStyle="Solid"
                                                BorderWidth="1px" Width="214px" CssClass="gridItems" Text='<%# bind("comentario") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="LetraH1" Width="20%" />
                                        <ItemStyle CssClass="gridItems" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMensProd" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Verdana"
                    Font-Size="11px" ForeColor="Red" Visible="False" Width="100%">Producto NO existe.</asp:Label></td>
        </tr>

        <tr>
            <td colspan="3">
                <asp:Label ID="lblInvolucradosUsr" runat="server" BackColor="Gray" CssClass="headerSimples"
                    Font-Bold="True" ForeColor="White" Text="::Usuarios Involucrados en Reclamación" Width="100%" Height="17px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">

                <asp:UpdatePanel ID="panelUsrInvolucrados" runat="server">
                    <ContentTemplate>

                        <table style="width: 80%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label ID="Label15" runat="server" CssClass="listItems" Font-Bold="True" Text="Usuarios"></asp:Label></td>
                                <td style="width: 5%"></td>
                                <td style="width: 20%">
                                    <asp:Label ID="Label17" runat="server" CssClass="listItems" Font-Bold="True" Text="Usuarios a Involucrar"></asp:Label></td>
                                <td style="width: 5%"></td>
                                <td style="width: 20%">
                                    <asp:Label ID="Label13" runat="server" CssClass="listItems" Font-Bold="True" Text="Usuarios Involucrados"></asp:Label></td>

                            </tr>
                            <tr>
                                <td style="width: 20%; height: 19px">
                                    <asp:DropDownList ID="ddlGruposF" runat="server" Width="132px" TabIndex="9" Height="28px" CssClass="LetraH2" AutoPostBack="True" OnSelectedIndexChanged="ddlGruposF_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td style="width: 5%; height: 19px"></td>
                                <td style="width: 20%; height: 19px"></td>
                                <td style="width: 5%; height: 19px"></td>
                                <td style="width: 20%; height: 19px"></td>
                            </tr>
                            <tr>
                                <td rowspan="2" valign="top">
                                    <asp:ListBox ID="lbUsuarios" runat="server" CssClass="listItems" Rows="10" Width="100%" SelectionMode="Multiple"></asp:ListBox></td>
                                <td align="center">
                                    <asp:Button ID="btnAgregarUsr" runat="server" Text=">>" BackColor="SteelBlue" BorderColor="Gray" BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Width="62px" /></td>
                                <td rowspan="2" valign="top">
                                    <asp:ListBox ID="lbUsrInvolucrados" runat="server" CssClass="listItems" Rows="10" Width="100%" SelectionMode="Multiple"></asp:ListBox></td>
                                <td rowspan="2"></td>

                                <td rowspan="2" valign="top">
                                    <asp:ListBox ID="lbInvolucrados" runat="server" CssClass="listItems" Rows="10" Width="100%"></asp:ListBox></td>
                            </tr>

                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnQuitarUsr" runat="server" Text="<<" BackColor="SteelBlue" BorderColor="Gray" BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Width="62px" /></td>
                            </tr>
                            <tr>
                                <td style="height: 5px" colspan="5"></td>
                            </tr>

                        </table>
                    </ContentTemplate>

                </asp:UpdatePanel>
                <asp:Button ID="btnInvolucrar" runat="server" Text="Involucrar" BackColor="SteelBlue" BorderColor="Gray" BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Width="96px" Visible="False" />
                <asp:Label ID="lblInvolucradosMsg" runat="server" Font-Bold="True" Font-Italic="True"
                    ForeColor="#0000C0" Visible="False" Font-Names="Verdana" Font-Size="10px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblDescrip" runat="server" BackColor="Gray" Font-Bold="True" ForeColor="White"
                    Text="::Descripción de la reclamación" Width="100%" CssClass="headerSimples" Height="17px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="80px" TextMode="MultiLine" Width="99%" CssClass="headerSimples" ForeColor="Navy"></asp:TextBox>
                <asp:Button ID="btnGDescrp" runat="server" Text="Guardar Descripción" BackColor="SteelBlue" BorderColor="Gray" BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Width="155px" Visible="False" />
        </tr>
        <tr>
            <td colspan="3">

                <asp:Label ID="lblDeptosInvolucrados" runat="server" BackColor="Gray" Font-Bold="True" ForeColor="White"
                    Text="::Departamentos Involucrados" Width="100%" CssClass="headerSimples" Height="17px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <cc1:Accordion EnableViewState="true" ID="Accordion1" runat="server" HeaderCssClass="acHeader" BorderColor="White" ContentCssClass="acContent" FadeTransitions="true">
                    <Panes>

                        <cc1:AccordionPane ID="AccordionPane1" runat="server" EnableViewState="true">
                            <Header> VENTAS </Header>
                            <Content>
                                <asp:Panel ID="panelVentas" runat="server" EnableViewState="true" Width="100%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlVentas" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border-bottom: gray thin ridge">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblComentario" runat="server" Font-Names="Verdana" Font-Size="11px"
                                                                        Text='<%# bind("Comentario") %>'></asp:Label>
                                                                    <asp:Label ID="idcom" runat="server" Font-Names="Verdana" Font-Size="11px" Text='<%# bind("id_Comentario") %>'
                                                                        Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="2">
                                                                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Usuario") %>'></asp:Label>
                                                                    <asp:Label ID="lblFecha" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Fecha")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lFiles" runat="server"></asp:Literal></td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnComentarioV" runat="server" EnableViewState="true" Width="100%">
                                                    <asp:TextBox ID="txtComentarioV" runat="server" EnableViewState="true" Height="46px"
                                                        TextMode="MultiLine" Visible="false" Width="99%"></asp:TextBox>
                                                    <asp:Button ID="btnGuardaV" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        Text="Guardar" Visible="false" Width="86px" />
                                                    <asp:Button ID="btnCancelarV" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        OnClick="btnCancelarV_Click" Text="Cancelar" Visible="false" Width="86px" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAgregarV" runat="server" OnClick="btnAgregarV_Click" Text=" + "
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:FileUpload ID="fuFileV" runat="server" CssClass="LetraFiles" Visible="False"
                                                    Width="522px" />
                                                <asp:Button ID="btnAgregarFileV" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Agregar" Visible="False" Width="72px" /><br />
                                                <asp:Literal ID="LiteralFileV" runat="server" Visible="False"></asp:Literal>
                                                <asp:Button ID="btnEliminarAdjV" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Quitar Adjuntos" Visible="False" Width="104px" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </Content>
                        </cc1:AccordionPane>


                        <cc1:AccordionPane ID="AccordionPane2" runat="server">
                            <Header> PRODUCCION </Header>
                            <Content>
                                <asp:Panel ID="panelProduccion" runat="server" Width="100%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlProduccion" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border-bottom: gray thin ridge">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblComentarioP" runat="server" Font-Names="Verdana" Font-Size="11px"
                                                                        Text='<%# bind("Comentario") %>'></asp:Label>
                                                                    <asp:Label ID="idcom" runat="server" Font-Names="Verdana" Font-Size="11px" Text='<%# bind("id_Comentario") %>'
                                                                        Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="2">
                                                                    <asp:Label ID="lblUsuarioP" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Usuario") %>'></asp:Label>
                                                                    <asp:Label ID="lblFechaP" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Fecha") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <td>
                                                                <asp:Literal ID="lFilesP" runat="server"></asp:Literal></td>
                                                            <tr>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel2" runat="server" Width="100%">
                                                    <asp:TextBox ID="txtComentarioP" runat="server" Height="46px" TextMode="MultiLine"
                                                        Visible="false" Width="99%"></asp:TextBox>
                                                    <asp:Button ID="btnGuardaP" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        Text="Guardar" Visible="false" Width="86px" />
                                                    <asp:Button ID="btnCancelarP" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        OnClick="btnCancelarP_Click" Text="Cancelar" Visible="false" Width="86px" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAgregarP" runat="server" OnClick="btnAgregarP_Click" Text=" + "
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:FileUpload ID="fuFileP" runat="server" CssClass="LetraFiles" Visible="False"
                                                    Width="522px" />
                                                <asp:Button ID="btnAgregarFileP" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Agregar" Visible="False" Width="72px" /><br />
                                                <asp:Literal ID="LiteralFileP" runat="server" Visible="False"></asp:Literal>
                                                <asp:Button ID="btnEliminarAdjP" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Quitar Adjuntos" Visible="False" Width="104px" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </Content>
                        </cc1:AccordionPane>


                        <cc1:AccordionPane ID="AccordionPane3" runat="server">
                            <Header> LOGISTICA </Header>
                            <Content>
                                <asp:Panel ID="panelLogistica" runat="server" Width="100%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlLogistica" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border-bottom: gray thin ridge">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblComentarioL" runat="server" Font-Names="Verdana" Font-Size="11px"
                                                                        Text='<%# bind("Comentario") %>'></asp:Label>
                                                                    <asp:Label ID="idcom" runat="server" Font-Names="Verdana" Font-Size="11px" Text='<%# bind("id_Comentario") %>'
                                                                        Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="2">
                                                                    <asp:Label ID="lblUsuarioL" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Usuario") %>'></asp:Label>
                                                                    <asp:Label ID="lblFechaL" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Fecha") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lFilesL" runat="server"></asp:Literal></td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel3" runat="server" Width="100%">
                                                    <asp:TextBox ID="txtComentarioL" runat="server" Height="46px" TextMode="MultiLine"
                                                        Visible="false" Width="99%"></asp:TextBox>
                                                    <asp:Button ID="btnGuardaL" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        Text="Guardar" Visible="false" Width="86px" />
                                                    <asp:Button ID="btnCancelarL" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        OnClick="btnCancelarL_Click" Text="Cancelar" Visible="false" Width="86px" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAgregarL" runat="server" OnClick="btnAgregarL_Click" Text=" + "
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:FileUpload ID="fuFileL" runat="server" CssClass="LetraFiles" Visible="False"
                                                    Width="522px" />
                                                <asp:Button ID="btnAgregarFileL" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Agregar" Visible="False" Width="72px" /><br />
                                                <asp:Literal ID="LiteralFileL" runat="server" Visible="False"></asp:Literal>
                                                <asp:Button ID="btnEliminarAdjL" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Quitar Adjuntos" Visible="False" Width="104px" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </Content>
                        </cc1:AccordionPane>

                        <cc1:AccordionPane ID="AccordionPane4" runat="server">
                            <Header> FINANZAS </Header>
                            <Content>
                                <asp:Panel ID="panelFinanzas" runat="server" Width="100%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlFinanzas" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border-bottom: gray thin ridge">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblComentarioF" runat="server" Font-Names="Verdana" Font-Size="11px"
                                                                        Text='<%# bind("Comentario") %>'></asp:Label>
                                                                    <asp:Label ID="idcom" runat="server" Font-Names="Verdana" Font-Size="11px" Text='<%# bind("id_Comentario") %>'
                                                                        Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="2">
                                                                    <asp:Label ID="lblUsuarioF" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Usuario") %>'></asp:Label>
                                                                    <asp:Label ID="lblFechaF" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Fecha") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lFilesF" runat="server"></asp:Literal></td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel4" runat="server" Width="100%">
                                                    <asp:TextBox ID="txtComentarioF" runat="server" Height="46px" TextMode="MultiLine"
                                                        Visible="false" Width="99%"></asp:TextBox>
                                                    <asp:Button ID="btnGuardaF" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        Text="Guardar" Visible="false" Width="86px" />
                                                    <asp:Button ID="btnCancelarF" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        OnClick="btnCancelarF_Click" Text="Cancelar" Visible="false" Width="86px" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAgregarF" runat="server" OnClick="btnAgregarF_Click" Text=" + "
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:FileUpload ID="fuFileF" runat="server" CssClass="LetraFiles" Visible="False"
                                                    Width="522px" />
                                                <asp:Button ID="btnAgregarFileF" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Agregar" Visible="False" Width="72px" /><br />
                                                <asp:Literal ID="LiteralFileF" runat="server" Visible="False"></asp:Literal>
                                                <asp:Button ID="btnEliminarAdjF" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Quitar Adjuntos" Visible="False" Width="104px" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                            </Content>
                        </cc1:AccordionPane>

                        <cc1:AccordionPane ID="AccordionPane5" runat="server">
                            <Header> CALIDAD </Header>
                            <Content>
                                <asp:Panel ID="panelCalidad" runat="server" Width="100%">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlCalidad" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border-bottom: gray thin ridge">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblComentarioC" runat="server" Font-Names="Verdana" Font-Size="11px"
                                                                        Text='<%# bind("Comentario") %>'></asp:Label>
                                                                    <asp:Label ID="idcom" runat="server" Font-Names="Verdana" Font-Size="11px" Text='<%# bind("id_Comentario") %>'
                                                                        Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="2">
                                                                    <asp:Label ID="lblUsuarioC" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Usuario") %>'></asp:Label>
                                                                    <asp:Label ID="lblFechaC" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
                                                                        Font-Size="10px" Text='<%# bind("Fecha") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="lFilesC" runat="server"></asp:Literal></td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel5" runat="server" Width="100%">
                                                    <asp:TextBox ID="txtComentarioC" runat="server" Height="46px" TextMode="MultiLine"
                                                        Visible="false" Width="99%"></asp:TextBox>
                                                    <asp:Button ID="btnGuardaC" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        Text="Guardar" Visible="false" Width="86px" />
                                                    <asp:Button ID="btnCancelarC" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                        OnClick="btnCancelarC_Click" Text="Cancelar" Visible="false" Width="86px" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAgregarC" runat="server" OnClick="btnAgregarC_Click" Text=" + "
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:FileUpload ID="fuFileC" runat="server" CssClass="LetraFiles" Visible="False"
                                                    Width="522px" />
                                                <asp:Button ID="btnAgregarFileC" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Agregar" Visible="False" Width="72px" /><br />
                                                <asp:Literal ID="LiteralFileC" runat="server" Visible="False"></asp:Literal>
                                                <asp:Button ID="btnEliminarAdjC" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                                    Height="20px" Text="Quitar Adjuntos" Visible="False" Width="104px" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                            </Content>
                        </cc1:AccordionPane>

                    </Panes>
                </cc1:Accordion>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <asp:Label ID="lblConclusion" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                    Text="::Conclusión" Width="100%" CssClass="headerSimples" Height="17px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:Panel ID="panelConclusion" runat="server" Width="100%">
                    <asp:TextBox ID="txtConclusion" runat="server" Height="60px" TextMode="MultiLine" Width="99%" ReadOnly="True" CssClass="headerSimples" ForeColor="Navy"></asp:TextBox>
                </asp:Panel>

                <table style="width: 40%">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblArea" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="Area"></asp:Label></td>
                        <td valign="top" style="width: 288px">
                            <asp:DropDownList ID="ddlAreas" runat="server" Width="236px" TabIndex="5" Enabled="False">
                            </asp:DropDownList></td>

                        <td valign="top">
                            <asp:Label ID="lblMotivo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="Motivo"></asp:Label></td>
                        <td valign="top" style="width: 254px">
                            <asp:DropDownList ID="ddlMotivos" runat="server" Width="350px" TabIndex="5" Enabled="False">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblMonto" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="Monto"></asp:Label></td>
                        <td style="width: 288px" valign="top">
                            <asp:TextBox ID="txtMonto" runat="server" CssClass="LetraH2 NuevosCampos"
                                TabIndex="1" Width="92px" AutoCompleteType="Disabled"></asp:TextBox></td>
                        <td valign="top">
                            <asp:Label ID="lblNCND" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="NC/ND"></asp:Label></td>
                        <td style="width: 254px" valign="top">
                            <asp:TextBox ID="txtNCND" runat="server" CssClass="LetraH2 NuevosCampos"
                                TabIndex="1" Width="92px" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:Label ID="lblMoneda" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="Moneda"></asp:Label>
                            <asp:DropDownList ID="ddlMoneda" runat="server" Width="86px" TabIndex="9" CssClass="LetraH2 NuevosCampos" Enabled="False">
                                <asp:ListItem Value="0">...</asp:ListItem>
                                <asp:ListItem>DOP</asp:ListItem>
                                <asp:ListItem>USD</asp:ListItem>
                                <asp:ListItem>CRC</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblCantidad" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="Cantidad"></asp:Label></td>
                        <td style="width: 288px" valign="top">
                            <asp:TextBox ID="txtCantidad" runat="server" AutoCompleteType="Disabled" CssClass="LetraH2 NuevosCampos"
                                TabIndex="1" Width="92px"></asp:TextBox></td>
                        <td valign="top">
                            <asp:Label ID="lblMetrica" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                Text="Metrica"></asp:Label></td>
                        <td style="width: 254px" valign="top">
                            <asp:DropDownList ID="ddlMetrica" runat="server" Width="86px" TabIndex="9" CssClass="LetraH2 NuevosCampos" Enabled="False">
                                <asp:ListItem Value="0">...</asp:ListItem>
                                <asp:ListItem>DOP</asp:ListItem>
                                <asp:ListItem>USD</asp:ListItem>
                                <asp:ListItem>CRC</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                </table>

            </td>

        </tr>

        <tr>
            <td align="right" colspan="3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" BackColor="SteelBlue" BorderColor="Gray" BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Width="96px" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Reclamación" BackColor="SteelBlue" BorderColor="Gray" BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White" Visible="False" Width="138px" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red" Width="100%" Font-Names="Verdana" Font-Size="11px"></asp:Label>
            </td>
            <td align="right"></td>
        </tr>
    </table>
    <asp:ImageButton ID="imgbtnPrint" runat="server" ImageUrl="~/Images/print.png" Visible="False" />
    <asp:ImageButton ID="btnReportToClient" runat="server" ImageUrl="~/Images/directory.jpg"
        Visible="False" ToolTip="Generar Carta para Cliente" />
    <asp:Button ID="btnEnviarMail" runat="server" BorderStyle="Solid" Text="Enviar Carta por Email" Visible="False" CssClass="botonEnviar" Width="154px" ToolTip="Enviar carta por correo" />



</asp:Content>

