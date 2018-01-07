<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Usuarios.aspx.vb" Inherits="Usuarios" title="Reclamaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: left">
        <br />
    
    <table width="100%">
    <tr>
    <td>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnGuardar" Height="270px" Width="321px" BorderColor="SteelBlue" BorderWidth="1px">
            <table style="width: 100%">
                <tr>
                    <td align="left" colspan="2" style="background-color: lightsteelblue">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Usuario::."></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Usuario:"></asp:Label></td>
                    <td align="left">
                        <asp:TextBox ID="txtUsuario" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                            Font-Bold="True" ForeColor="SteelBlue" Width="147px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUsuario">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Contraseña:"></asp:Label></td>
                    <td align="left">
                        <asp:TextBox ID="txtContrasena" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                            Font-Bold="True" ForeColor="SteelBlue" TextMode="Password" Width="147px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtContrasena">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lbl_idempleado" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Id Empleado:" Width="91px"></asp:Label></td>
                    <td align="left">
                        <asp:TextBox ID="txtidEmpleado" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                            Font-Bold="True" ForeColor="SteelBlue" Width="147px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblNombre" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Nombre:"></asp:Label></td>
                    <td align="left">
                        <asp:TextBox ID="txtNombre" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                            Font-Bold="True" ForeColor="SteelBlue" Width="147px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombre"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblArea" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Area:"></asp:Label></td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDepto" runat="server" Width="154px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Nivel:"></asp:Label></td>
                    <td align="left"><asp:DropDownList ID="ddlNiveles" runat="server" Width="154px">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblCorreo" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Correo:"></asp:Label></td>
                    <td align="left">
                        <asp:TextBox ID="txtCorreo" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                            Font-Bold="True" ForeColor="SteelBlue" Width="147px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCorreo">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstatus" runat="server" CssClass="letraUsual" Font-Bold="True"
                            Text="Estatus:"></asp:Label></td>
                    <td align="left">
                        <asp:DropDownList ID="ddlEstatus" runat="server" Width="154px">
                            <asp:ListItem>ACTIVO</asp:ListItem>
                            <asp:ListItem>INACTIVO</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnGuardar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                            BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Guardar" Width="76px" />
                        <asp:Button ID="btnNuevo" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                            BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Nuevo" Width="76px" CausesValidation="False" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                            Font-Size="11px" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
    </td>
    </tr>
        <tr>
            <td>
                <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="60%" AllowPaging="True" PageSize="30">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle CssClass="gridItems" Width="15%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="niveld" HeaderText="Nivel">
                            <ItemStyle CssClass="gridItems" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" HtmlEncode="False">
                            <ItemStyle CssClass="gridItems" Width="35%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:BoundField DataField="area" HeaderText="Area">
                            <ItemStyle CssClass="gridItems" Width="20%" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Correo">
                            <ItemTemplate>
                                <asp:Label ID="lblCorreo" runat="server" CssClass="gridItems" Text='<%# bind("Correo") %>'></asp:Label>
                                <asp:Label ID="lblContrasena" runat="server" Text='<%# bind("contrasena") %>' Visible="False"></asp:Label>
                                <asp:Label ID="lblidDepto" runat="server" Text='<%# bind("idDepto") %>' Visible="False"></asp:Label>
                                <asp:Label ID="lblidEmpleado" runat="server" Visible="False" Text='<%# bind("idempleado") %>'></asp:Label>
                                <asp:Label ID="lblidNivel" runat="server" Text='<%# bind("nivel") %>' Visible="False"></asp:Label>
                                <asp:Label ID="lblstatus" runat="server" Text='<%# bind("status") %>' Visible="False"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="gridItems" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:TemplateField>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" HeaderText="Editar">
                            <ItemStyle Width="5%" CssClass="griditems" />
                            <HeaderStyle CssClass="gridHeaders" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEliminar" runat="server" CausesValidation="False" CommandArgument='<%# bind("idempleado") %>'
                                    ImageUrl="~/Images/delete.png" OnClick="btnEliminar_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="LetraUsual" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
    
        &nbsp; &nbsp;&nbsp;</div>
</asp:Content>

