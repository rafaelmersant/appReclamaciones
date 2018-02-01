<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Areas.aspx.vb" Inherits="Areas" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BorderColor="SteelBlue" BorderWidth="1px" DefaultButton="btnGuardar"
                    Height="118px" Width="321px">
                    <table style="width: 100%">
                        <tr>
                            <td align="left" colspan="2" style="background-color: gray">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Areas::." ForeColor="White"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Area"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtArea" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                                    Font-Bold="True" ForeColor="SteelBlue" Width="147px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArea"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnGuardar" runat="server" BackColor="Gray" BorderColor="Black"
                                    BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Guardar" Width="76px" />
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
                <asp:GridView ID="grdAreas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="40%">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="area" HeaderText="Area">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="gridItems" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitar" runat="server" BackColor="Red" BorderColor="Maroon"
                                    BorderStyle="Solid" CausesValidation="False" CommandArgument='<%# bind("id_area") %>'
                                    Font-Bold="True" ForeColor="White" OnClick="btnQuitar_Click" Text="X" Width="34px" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Center" />
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

