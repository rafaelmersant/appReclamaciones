Imports System.Net.Mail

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnEntrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntrar.Click

        Try
            Dim dtdata As Data.DataTable = clsReclamaciones.validaUsr(txtUsuario.Text.Trim(), Left(FormsAuthentication.HashPasswordForStoringInConfigFile(txtContrasena.Text.Trim(), "md5").Trim(), 35))

            If dtdata.Rows.Count > 0 Then
                Session.Item("usuario") = txtUsuario.Text.Trim()

                If dtdata.Rows(0).Item("nivel") = 0 Then Session.Item("depto") = 1 Else Session.Item("depto") = dtdata.Rows(0).Item("departamento")

                Session.Item("name") = dtdata.Rows(0).Item("nombre")
                Session.Item("nivel") = dtdata.Rows(0).Item("nivel")

                Response.Redirect("listareclamaciones.aspx")
            Else
                lblMensaje.Visible = True
            End If

        Catch ex As Exception
            lblMensaje.Visible = True
            lblMensaje.Text = ex.Message
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Redirect("RealizandoCambios.aspx")

        If Not Page.IsPostBack Then
            Session.Item("usuario") = String.Empty
            Session.Item("name") = String.Empty
            Session.Item("depto") = String.Empty
            Session.Item("nivel") = String.Empty
        End If

        ClientScript.RegisterStartupScript(Me.GetType(), "theFocus", "<script> document.getElementById('" & txtUsuario.ClientID & "').focus();</script>")

    End Sub

End Class
