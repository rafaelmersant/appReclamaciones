<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ExpiroSession.aspx.vb" Inherits="ExpiroSession" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Black"
        Height="64px" Text="La sesi�n ha expirado. Debe entrar nuevamente. " Width="801px"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Black"
        Height="31px" Text="Despu�s de media hora sin hacer ninguna acci�n en el sistema la sesi�n iniciada expira. Cuando esto ocurre debe logearse."
        Width="801px"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnNuevaRecl" runat="server" BackColor="#FF2D2D" BorderColor="Black"
        BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" Font-Size="14pt"
        ForeColor="White" Height="34px" PostBackUrl="~/Reclamacion.aspx" Text="Entrar al sistema"
        Visible="False" Width="188px" />
</asp:Content>

