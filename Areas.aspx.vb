Imports System.Data

Partial Class Areas
    Inherits System.Web.UI.Page

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            clsReclamaciones.insertArea(txtArea.Text.Trim())

            fillAreas()
            clean()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Sub fillAreas()
        Dim dtDatos As DataTable = clsReclamaciones.getAreas()
        grdAreas.DataSource = dtDatos
        grdAreas.DataBind()

    End Sub

    Private Sub clean()
        txtArea.Text = String.Empty

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("nivel") = 2 Then Response.Redirect("Login.aspx")

        lblMensaje.Text = String.Empty

        If Not Page.IsPostBack Then
            fillAreas()
        End If
    End Sub

    Protected Sub btnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Button = sender

        Try
            clsReclamaciones.delArea(Integer.Parse(obj.CommandArgument))
            fillAreas()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub
End Class
