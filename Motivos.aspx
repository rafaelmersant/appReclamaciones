<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Motivos.aspx.vb" Inherits="Motivos" title="Reclamaciones" %>
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
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Motivos::." ForeColor="White"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Id"></asp:Label></td>
                            <td align="left">
                                <asp:Label ID="lblId" runat="server" CssClass="letraUsual" Font-Bold="True" ForeColor="DimGray"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="letraUsual" Font-Bold="True" Text="Motivo"></asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtMotivo" runat="server" BorderColor="Black" BorderStyle="Solid"
                                    Font-Bold="True" ForeColor="Black" Width="236px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMotivo"
                                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnGuardar" runat="server" BackColor="Gray" BorderColor="Black"
                                    BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Guardar" Width="76px" CausesValidation="False" />
                                <asp:Button ID="Button1" runat="server" BackColor="Gray" BorderColor="Black"
                                    BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Nuevo" Width="76px" CausesValidation="False" /></td>
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
                <asp:GridView ID="grdMotivos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="40%" PageSize="20">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField HeaderText="Motivo" DataField="descripcion">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="gridItems" Width="25%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText='<%# bind("id_motivo") %>'
                                    CausesValidation="False" CommandArgument='<%# bind("descripcion") %>' ImageUrl="~/Images/lista.png"
                                    OnClick="ImageButton1_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitar" runat="server" BackColor="Red" BorderColor="Maroon"
                                    BorderStyle="Solid" CausesValidation="False" Font-Bold="True" ForeColor="White"
                                    Text="X" Width="34px" CommandArgument='<%# bind("id_motivo") %>' OnClick="btnQuitar_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
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

