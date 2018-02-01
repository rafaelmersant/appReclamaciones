<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Opciones.aspx.vb" Inherits="Opciones" title="Reclamaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />

    <table width="40%" cellspacing="3" style="border-right: #ccccff thin ridge; border-top: #ccccff thin ridge; border-left: #ccccff thin ridge; border-bottom: #ccccff thin ridge">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" BackColor="Gray" CssClass="headerPrincipal"
                    Font-Bold="True" ForeColor="White" Text="Opciones Administrativas" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height:13px">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LetraUsual" NavigateUrl="~/AdministrarReclam.aspx">Administrar Reclamación</asp:HyperLink></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:HyperLink ID="hlUsuarios" runat="server" CssClass="LetraUsual" NavigateUrl="~/Usuarios.aspx">Administrar Usuarios</asp:HyperLink></td>
            <td >
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="hlMotivos" runat="server" CssClass="LetraUsual" NavigateUrl="~/Motivos.aspx">Mantenimiento MOTIVOS</asp:HyperLink></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LetraUsual" NavigateUrl="~/Areas.aspx">Mantenimiento AREAS</asp:HyperLink></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LetraUsual" NavigateUrl="~/Grupos.aspx">Mantenimiento GRUPOS</asp:HyperLink></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LetraUsual" NavigateUrl="~/Reportes.aspx">REPORTES</asp:HyperLink></td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height:13px">
                <asp:HyperLink ID="hlProductos" runat="server" CssClass="LetraUsual" NavigateUrl="~/Productos.aspx" Visible="False">Mantenimiento PRODUCTOS</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>

