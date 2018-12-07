<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AdministrarReclam.aspx.vb" Inherits="AdministrarReclam" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BorderColor="SteelBlue" BorderWidth="1px" DefaultButton="btnBuscar" Width="321px">
                    <table style="width: 100%">
                        <tr>
                            <td align="left" colspan="2" style="background-color: gray">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Eliminar Reclamación::." ForeColor="White"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Reclamación #"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtid" runat="server" BorderColor="Black" BorderStyle="Solid"
                                    Font-Bold="True" ForeColor="Black" Width="68px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtid"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBuscar" runat="server" BackColor="Gray" BorderColor="Black"
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
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
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
                            <asp:TemplateField HeaderText="Estatus">
                                <ItemTemplate>
                                    <asp:Button ID="btnAbrirRecl" runat="server" BackColor="#009933" BorderColor="#006600" BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_reclamacion") %>' Font-Bold="True" ForeColor="MistyRose" OnClick="btnAbrirRecl_Click" Text='<%# bind("shortStatus") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdComentarios" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" PageSize="20" Width="95%">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="comentario" HeaderText="Comentarios">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="gridItems" Width="93%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitarComent" runat="server" BackColor="OrangeRed" BorderColor="Maroon"
                                    BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_comentario") %>'
                                    Font-Bold="True" ForeColor="SeaShell" OnClick="btnQuitarComent_Click" Text="X" Width="34px" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

