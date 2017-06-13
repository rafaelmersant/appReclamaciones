
Partial Class AdministrarReclam
    Inherits System.Web.UI.Page

    Public Sub fillRecl()
        Try
            Dim dtRecl As Data.DataTable

            dtRecl = clsReclamaciones.getReclamacion(txtid.Text, Session.Item("usuario")).Tables(0)
            If dtRecl.Rows.Count = 0 Then Throw New Exception("No existe la reclamación.")
            grdReclamacion.DataSource = dtRecl
            grdReclamacion.DataBind()

        Catch ex As Exception
            grdReclamacion.DataBind()
            lblMensaje.Text = ex.Message
        End Try

    End Sub

    Public Sub fillComentario()
        Try
            Dim dtComent As Data.DataTable

            dtComent = clsReclamaciones.getComentarios(txtid.Text, Session.Item("depto"))
            grdComentarios.DataSource = dtComent
            grdComentarios.DataBind()

        Catch ex As Exception
            grdComentarios.DataBind()
            lblMensaje.Text = ex.Message

        End Try

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            lblMensaje.Text = String.Empty

            fillRecl()
            fillComentario()

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub btnQuitarRecl_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Button = sender

        Try
            clsReclamaciones.delReclamacion(Integer.Parse(obj.CommandArgument))
            btnBuscar_Click(Nothing, Nothing)
            lblMensaje.Text = "La reclamación fue eliminada con exito!"

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnQuitarComent_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Button = sender

        Try
            clsReclamaciones.delComentario(Integer.Parse(obj.CommandArgument))
            fillComentario()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub
End Class
