
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Reclamaciones de Clientes - Versión 2.0"
        lblUserLog.Text = Session.Item("name")

        If Not Session.Item("nivel") = Nothing Then
            If Session.Item("nivel").ToString() = 2 Then
                hlOpciones.Visible = True
            End If
        End If

        If Strings.InStr(Request.AppRelativeCurrentExecutionFilePath, "Login.aspx") > 0 Or _
        Strings.InStr(Request.AppRelativeCurrentExecutionFilePath, "RealizandoCambios.aspx") > 0 Then
            lbCC.Visible = False
        Else
            lbCC.Visible = True
        End If

    End Sub
End Class

