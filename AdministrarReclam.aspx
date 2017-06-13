<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AdministrarReclam.aspx.vb" Inherits="AdministrarReclam" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BorderColor="SteelBlue" BorderWidth="1px" DefaultButton="btnBuscar" Width="321px">
                    <table style="width: 100%">
                        <tr>
                            <td align="left" colspan="2" style="background-color: lightsteelblue">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Eliminar Reclamación::."></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Reclamación #"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtid" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                                    Font-Bold="True" ForeColor="SteelBlue" Width="68px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtid"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBuscar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                                    BorderStyle="Solid" CausesValidation="False" Font-Bold="True" ForeColor="White"
                                    Text="Buscar" Width="76px" /></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                                    Font-Size="11px" ForeColor="Red"></asp:Label></td>
                        </tr>
                    </table>
                    <asp:GridView ID="grdReclamacion" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" PageSize="20" Width="40%">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="id_reclamacion" HeaderText="Reclamaci&#243;n">
                                <ItemStyle CssClass="gridItems" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Quitar">
                                <ItemTemplate>
                                    <asp:Button ID="btnQuitarRecl" runat="server" BackColor="Tomato" BorderColor="Maroon"
                                        BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_reclamacion") %>'
                                        Font-Bold="True" ForeColor="MistyRose" OnClick="btnQuitarRecl_Click" Text="X" Width="34px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdComentarios" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" PageSize="20" Width="95%">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="comentario" HeaderText="Comentarios">
                            <ItemStyle CssClass="gridItems" Width="93%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitarComent" runat="server" BackColor="OrangeRed" BorderColor="Maroon"
                                    BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_comentario") %>'
                                    Font-Bold="True" ForeColor="SeaShell" OnClick="btnQuitarComent_Click" Text="X" Width="34px" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
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
</asp:Content>

