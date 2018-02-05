Imports System.Data

Partial Class Grupos
    Inherits System.Web.UI.Page

    Private Sub clean()
        txtgrupo.Text = String.Empty
        lblId.Text = "0"

    End Sub

    Private Sub fillGrupos()
        Dim dtDatos As DataTable = clsReclamaciones.getGrupos()
        grdGrupo.DataSource = dtDatos
        grdGrupo.DataBind()

    End Sub

    Private Sub fillUsrsGrupos()
        Dim dtDatos As DataTable = clsReclamaciones.getGruposUsrs()
        grdGruposUsrs.DataSource = dtDatos
        grdGruposUsrs.DataBind()

    End Sub

    Private Sub fillGruposDDL()
        Dim dtDatos As DataTable = clsReclamaciones.getGrupos()
        ddlGrupos.DataSource = dtDatos
        ddlGrupos.DataTextField = "grupo"
        ddlGrupos.DataValueField = "id_grupo"
        ddlGrupos.DataBind()

    End Sub

    Private Sub fillUsuariosDDL()
        Dim dtDatos As DataTable = clsReclamaciones.getUsuarios(0)
        ddlUsuarios.DataSource = dtDatos
        ddlUsuarios.DataTextField = "Nombre"
        ddlUsuarios.DataValueField = "usuario"
        ddlUsuarios.DataBind()

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            clean()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            clsReclamaciones.insertGrupo(txtgrupo.Text.Trim(), lblId.Text)

            fillGrupos()
            fillGruposDDL()
            clean()
            lblMensaje.Text = "Grupo guardado!"
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As Button = sender

        Try
            clsReclamaciones.delGrupoUsr(Integer.Parse(obj.ToolTip), obj.CommandArgument)
            fillUsrsGrupos()
            lblMensaje.Text = "Relacion de usuario con grupo eliminada!"
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim obj As ImageButton = sender

        Try
            txtgrupo.Text = obj.CommandArgument
            lblId.Text = obj.AlternateText

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            clsReclamaciones.insertUsrToGrupo(ddlGrupos.SelectedValue, ddlUsuarios.SelectedValue)

            fillUsrsGrupos()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                fillGruposDDL()
                fillUsuariosDDL()

                fillGrupos()
                fillUsrsGrupos()

                clean()
            End If
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub
End Class
