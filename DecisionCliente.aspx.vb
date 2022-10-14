Imports System.Data

Partial Class Motivos
    Inherits System.Web.UI.Page

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            clsReclamaciones.insertDecision(txtMotivo.Text.Trim(), lblId.Text)

            fillDecisiones()
            clean()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Sub clean()
        txtMotivo.Text = String.Empty
        lblId.Text = "0"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("nivel") = 2 Then Response.Redirect("Login.aspx")

        lblMensaje.Text = String.Empty

        clsReclamaciones.TieButton(Page, txtMotivo, btnGuardar)

        If Not Page.IsPostBack Then
            fillDecisiones()
            clean()
        End If
    End Sub

    Private Sub fillDecisiones()
        Dim dtDatos As DataTable = clsReclamaciones.getDecisiones()
        grdMotivos.DataSource = dtDatos
        grdMotivos.DataBind()

    End Sub

    Protected Sub btnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Button = sender

        Try
            clsReclamaciones.delDecision(Integer.Parse(obj.CommandArgument))
            fillDecisiones()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
        
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim obj As ImageButton = sender

        Try
            txtMotivo.Text = obj.CommandArgument
            lblId.Text = obj.AlternateText

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            clean()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub
End Class
