<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" title="Reclamaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <br />
    <br />
    
    <div style="text-align: center">
    
    <asp:Panel ID="Panel1" runat="server" Height="128px" Width="321px" DefaultButton="btnEntrar">
        <table style="width: 100%">
            <tr>
                <td align="right" colspan="2" style="background-color: lightsteelblue">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Login::."></asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Usuario:" CssClass="letraUsual"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtUsuario" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                        Font-Bold="True" ForeColor="SteelBlue" Width="147px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Contraseņa:" CssClass="letraUsual"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtContrasena" runat="server" BorderColor="SteelBlue" BorderStyle="Solid"
                        Font-Bold="True" ForeColor="SteelBlue" TextMode="Password" Width="147px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnEntrar" runat="server" BackColor="LightSteelBlue" BorderColor="LightSlateGray"
                        BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Entrar" Width="76px" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Italic="False" ForeColor="Red"
                        Text="Usuario/Contraseņa incorrecto." Visible="False" Font-Names="Verdana" Font-Size="11px"></asp:Label></td>
            </tr>
        </table>
        </asp:Panel>
        &nbsp;
        <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="LightSlateGray"
            Color="LightSteelBlue" Radius="6" TargetControlID="Panel1">
        </cc1:RoundedCornersExtender>
        &nbsp;<br />
        <br />
        <br />
        <br />
        </div>
</asp:Content>

