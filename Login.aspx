<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" title="Reclamaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>

    <br />
    <br />
    
    <div style="margin: 0 auto; width: 324px">
    
    <asp:Panel ID="Panel1" runat="server" Height="128px" Width="321px" DefaultButton="btnEntrar">

        <table style="width: 100%">
            <tr>
                <td colspan="2" style="background-color: #FF2D2D; width: 100%">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text=".::Login::." ForeColor="White"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Usuario:" CssClass="letraUsual"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtUsuario" runat="server" BorderColor="#333333" BorderStyle="Solid"
                        Font-Bold="True" ForeColor="Black" Width="147px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Contraseña:" CssClass="letraUsual"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtContrasena" runat="server" BorderColor="#333333" BorderStyle="Solid"
                        Font-Bold="True" ForeColor="Black" TextMode="Password" Width="147px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnEntrar" runat="server" BackColor="#FF2D2D" BorderColor="Black"
                        BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Entrar" Width="76px" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="False" Font-Italic="False" ForeColor="Red"
                        Text="Usuario/Contraseña incorrecto." Visible="False" Font-Names="Verdana" Font-Size="11px"></asp:Label></td>
            </tr>
        </table>
        </asp:Panel>
        &nbsp;
        <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BorderColor="#FF2D2D"
            Color="#FF2D2D" Radius="6" TargetControlID="Panel1">
        </cc1:RoundedCornersExtender>
        &nbsp;<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="464px"></asp:TextBox>
                    <asp:Button ID="btnEntrar0" runat="server" BackColor="steelblue" BorderColor="LightSlateGray"
                        BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Probar OLEDB" Width="114px" />
        <asp:Button ID="Button1" runat="server" Text="Probar ODBC" Width="83px" />
        <br />
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Reclamaciones: @total" CssClass="letraUsual"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="464px"></asp:TextBox>
        </div>
</asp:Content>

