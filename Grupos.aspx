<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Grupos.aspx.vb" Inherits="Grupos" title="::Grupos::" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" BackColor="LightSteelBlue" Font-Bold="True"
                    Font-Italic="True" Text=".::Grupos::." Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BorderColor="SteelBlue" BorderWidth="1px" DefaultButton="btnGuardar"
                    Height="118px" Width="321px">
                    <table style="width: 100%">
                        <tr>
                            <td align="left" colspan="2" style="background-color: lightsteelblue">
                                </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Id"></asp:Label></td>
                            <td align="left">
                                <asp:Label ID="lblId" runat="server" CssClass="letraUsual" Font-Bold="True" ForeColor="DimGray"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Grupo"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtgrupo" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                                    Font-Bold="True" ForeColor="SteelBlue" Width="236px" ValidationGroup="g"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtgrupo"
                                    ErrorMessage="RequiredFieldValidator" ValidationGroup="g">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnGuardar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                                    BorderStyle="Solid" CausesValidation="False" Font-Bold="True" ForeColor="White"
                                    Text="Guardar" Width="76px" ValidationGroup="g" />
                                <asp:Button ID="btnNuevo" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                                    BorderStyle="Solid" CausesValidation="False" Font-Bold="True" ForeColor="White"
                                    Text="Nuevo" Width="76px" ValidationGroup="g" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGrupo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" PageSize="20" Width="40%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="grupo" HeaderText="Grupo">
                            <ItemStyle CssClass="gridItems" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnEditar" runat="server" AlternateText='<%# bind("id_grupo") %>'
                                    CausesValidation="False" CommandArgument='<%# bind("grupo") %>' ImageUrl="~/Images/lista.png"
                                    OnClick="ImageButton1_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                                    BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_grupo") %>'
                                    Font-Bold="True" ForeColor="White" OnClick="btnQuitar_Click" Text="X" Width="34px" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" BackColor="LightSteelBlue" Font-Bold="True"
                    Font-Italic="True" Text=".::Relacion de Grupos con Usuarios::." Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <table style="width: 28%">
                    <tr>
                        <td>
                <asp:Label ID="Label5" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Grupo"></asp:Label></td>
                        <td>
                <asp:DropDownList ID="ddlGrupos" runat="server" Width="196px">
                </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="Label6" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Usuario"></asp:Label></td>
                        <td>
                <asp:DropDownList ID="ddlUsuarios" runat="server" Width="196px">
                </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td><asp:Button ID="btnAgregar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                                    BorderStyle="Solid" CausesValidation="False" Font-Bold="True" ForeColor="White"
                                    Text="Agregar" Width="76px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGruposUsrs" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" PageSize="20" Width="40%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="nGrupo" HeaderText="Grupo">
                            <ItemStyle CssClass="gridItems" Width="25%" />
                            <HeaderStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" >
                            <HeaderStyle Width="10%" />
                            <ItemStyle CssClass="gridItems" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                                    BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("usuario") %>'
                                    Font-Bold="True" ForeColor="White" OnClick="btnQuitar_Click" Text="X" Width="32px" Height="20px" ToolTip='<%# bind("grupo_id") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                            <HeaderStyle Width="5%" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
                                <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                                    Font-Size="11px" ForeColor="Red"></asp:Label>
</asp:Content>

