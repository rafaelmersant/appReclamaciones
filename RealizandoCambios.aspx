<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizandoCambios.aspx.vb" Inherits="RealizandoCambios" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#0000C0"
                    Height="64px" Text="Le informamos que el sistema no está disponible en estos momentos, porque estamos realizando algunos cambios. Intente más tarde."
                    Width="801px"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="500px" ImageUrl="~/Images/DSCF0008.PNG"
                    Width="800px" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="#0000C0"
                    Height="20px" Text="Disculpe los inconvenientes que esto pueda causarle." Width="801px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

