<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PatronRptMensual.aspx.vb" Inherits="PatronRptMensual" title="Untitled Page" Culture="ES-do" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                    Text="Prepara Reporte Mensual" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" CssClass="LFiltros" Text="Año" Width="27px"></asp:Label><asp:DropDownList ID="ddlagnos" runat="server" CssClass="LetraFiles" Width="70px" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" CssClass="LFiltros" Text="Mes" Width="27px"></asp:Label><asp:DropDownList ID="ddlMeses" runat="server" CssClass="LetraFiles" Width="120px" AutoPostBack="True">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="lblReclamaciones" runat="server" CssClass="LFiltros"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <ItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label6" runat="server" CssClass="LFiltros" Text='Cliente: '></asp:Label>
                                    <asp:Label ID="Label3" runat="server" CssClass="LFiltros" Text='<%# bind("Cliente") %>'></asp:Label>
                                    <asp:Label ID="Label5" runat="server" CssClass="LFiltros" Text="-"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" CssClass="LFiltros" Text='<%# bind("nCliente") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label8" runat="server" CssClass="LFiltros" Text="Fecha de reclamación:"></asp:Label>
                                    <asp:Label ID="Label9" runat="server" CssClass="LFiltros" Font-Bold="False" Text='<%# bind("Fecha") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label15" runat="server" CssClass="LFiltros" Text="Cerrada:"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" CssClass="LFiltros" Font-Bold="False" Text='<%# bind("Fecha_close") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label13" runat="server" CssClass="LFiltros" Text="Estatus:"></asp:Label>
                                    <asp:Label ID="Label14" runat="server" CssClass="LFiltros" Font-Bold="False" Text='<%# bind("Status") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label7" runat="server" CssClass="LFiltros" Text="Descripción de la reclamación:"></asp:Label>
                                    <asp:Label ID="lblNoRecla" runat="server" CssClass="LFiltros" Font-Bold="False" Text='<%# bind("id_reclamacion") %>'
                                        Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label4" runat="server" CssClass="LFiltros" Font-Bold="False" Text='<%# bind("Descripcion") %>'
                                        Width="100%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label12" runat="server" CssClass="LFiltros" Text="Procedimiento: "></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Literal ID="ltComentarios1" runat="server"></asp:Literal><asp:Literal ID="ltComentarios2" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltComentarios3" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltComentarios4" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltComentarios5" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label10" runat="server" CssClass="LFiltros" Text="Departamento responsable:"></asp:Label>
                                    <asp:Label ID="Label11" runat="server" CssClass="LetraFiles" Text='<%# bind("nArea") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="background-color:gray">-
                                </td>
                            </tr>
                        </table>
                        
                    </ItemTemplate>
                </asp:DataList></td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
    </table>
</asp:Content>

