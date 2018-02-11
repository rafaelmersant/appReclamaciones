<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Reportes.aspx.vb" Inherits="Reportes" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 50%">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" CssClass="LFiltros" Font-Bold="True" Text="Seleccione reporte:"
                    Width="135px"></asp:Label>
                <asp:DropDownList ID="ddlReporte" runat="server" Width="247px" CssClass="LetraFiles">
                    <asp:ListItem Selected="True" Value="0">Elegir...</asp:ListItem>
                    <asp:ListItem>Excedidas</asp:ListItem>
                    <asp:ListItem>General</asp:ListItem>
                    <asp:ListItem Value="AreaMotivos">Areas/Motivos</asp:ListItem>
                    <%--<asp:ListItem Value="Mensual">Mensual RDLRP</asp:ListItem>--%>
                    <asp:ListItem Value="15Dias">&gt; 15 Dias</asp:ListItem>
                    <asp:ListItem Value="RRM">Reclamaciones Mensual</asp:ListItem>
                </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr>
            
        </tr>
        <tr>
            <td colspan="3">
                <div id="RRM">
                    <table style="border-right: dodgerblue thin solid; border-top: dodgerblue thin solid;
                        border-left: dodgerblue thin solid; border-bottom: dodgerblue thin solid" width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label12" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                                    Text="Reporte Mensual Reclamaciones" Width="100%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label15" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaIRM" runat="server" BackColor="SeaShell" CssClass="LAzul" Height="12px"
                                    TabIndex="1" Width="81px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtenderFIRM" runat="server"
                                        CssClass="CalendarExtenderFI" TargetControlID="txtFechaIRM" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label16" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaFRM" runat="server" BackColor="SeaShell" CssClass="LAzul" Height="12px"
                                    TabIndex="1" Width="81px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtenderFFRM" runat="server"
                                        CssClass="CalendarExtenderFF" TargetControlID="txtFechaFRM" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td style="padding-right: 2px; display: block; padding-left: 2px; padding-bottom: 2px; padding-top: 2px"><asp:Button ID="btnRRM" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="De Otros meses cerrada ahora" Width="227px" /><br />
                                <asp:Button ID="btnAbiertasYCerradas" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="Abiertas y Cerradas" Width="227px" /><br />
                                <asp:Button ID="btnAbiertas" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="Abiertas" Width="227px" /></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="general">
                    <table style="border-right: dodgerblue thin solid; border-top: dodgerblue thin solid;
                        border-left: dodgerblue thin solid; border-bottom: dodgerblue thin solid" width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                                    Text="Reporte General" Width="100%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label3" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaI" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px" BackColor="SeaShell"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtenderFI" runat="server"
                                        CssClass="CalendarExtenderFI" TargetControlID="txtFechaI" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label4" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaF" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px" BackColor="SeaShell"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtenderFF" runat="server"
                                        CssClass="CalendarExtenderFF" TargetControlID="txtFechaF" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnVerReporte" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="Generar" Width="126px" /></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            <div id="AreaMotivos">
                    <table style="border-right: dodgerblue thin solid; border-top: dodgerblue thin solid;
                        border-left: dodgerblue thin solid; border-bottom: dodgerblue thin solid" width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label5" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                                    Text="Reporte Area Motivos" Width="100%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5%">
                                <asp:Label ID="Label8" runat="server" CssClass="LFiltros" Text="Por fecha" Width="87px"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlporFecha" runat="server" CssClass="LetraFiles" Width="106px">
                                    <asp:ListItem>Abierta</asp:ListItem>
                                    <asp:ListItem>Cerrada</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label6" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaIni" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px" BackColor="Ivory"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtenderFini" runat="server"
                                        CssClass="CalendarExtenderFI" TargetControlID="txtFechaIni" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label7" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaFin" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px" BackColor="Ivory"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtenderFfin" runat="server"
                                        CssClass="CalendarExtenderFF" TargetControlID="txtFechaFin" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnprintam" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="Generar" Width="126px" /></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
              
              <div id="mas15dias">
            <table style="border-right: dodgerblue thin solid; border-top: dodgerblue thin solid;
                        border-left: dodgerblue thin solid; border-bottom: dodgerblue thin solid" width="100%">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label9" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                            Text="Reporte de Reclamaciones con mas de 15 dias" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label10" runat="server" CssClass="LFiltros" Text='Presione "Generar" para mostrar el reporte.'
                            Width="315px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnImprimir15" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="Generar" Width="126px" /></td>
                </tr>
            </table>
            </div>
                <asp:Image ID="imgUtil" runat="server" Height="1px" ImageUrl="~/Images/LineaG.gif"
                    Width="1px" /></td>
            
        </tr>
        <tr>
            <td colspan="3">
            <div id="Excedidas">
                    <table style="border-right: dodgerblue thin solid; border-top: dodgerblue thin solid;
                        border-left: dodgerblue thin solid; border-bottom: dodgerblue thin solid" width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label11" runat="server" BackColor="SteelBlue" Font-Bold="True" ForeColor="White"
                                    Text="Reporte Reclamaciones Excedidas" Width="100%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5%">
                                </td>
                            <td>
                                </td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label13" runat="server" CssClass="LFiltros" Text="Fecha Inicial" Width="87px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaIEx" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px" BackColor="Ivory"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                        CssClass="CalendarExtenderFI" TargetControlID="txtFechaIEx" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%">
                                <asp:Label ID="Label14" runat="server" CssClass="LFiltros" Text="Fecha Final" Width="78px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFechaFEx" runat="server" CssClass="LAzul" Height="12px" TabIndex="1"
                                    Width="81px" BackColor="Ivory"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                        CssClass="CalendarExtenderFF" TargetControlID="txtFechaFEx" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnReclaExcedidas" runat="server" BackColor="SteelBlue" BorderColor="Gray"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" Font-Names="Arial" ForeColor="White"
                                    Height="20px" Text="Generar" Width="126px" /></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red"
        Width="100%"></asp:Label>
</asp:Content>

