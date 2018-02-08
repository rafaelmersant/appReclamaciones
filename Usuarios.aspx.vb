Imports System.Data

Imports System.Net.Mail

Partial Class Usuarios
    Inherits System.Web.UI.Page

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            Dim iExiste As Integer = clsReclamaciones.getUsuario(txtUsuario.Text.Trim())

            clsReclamaciones.guardaUsuario(txtUsuario.Text.Trim(), Left(FormsAuthentication.HashPasswordForStoringInConfigFile(txtContrasena.Text, "MD5"), 35).Trim(), txtidEmpleado.Text, _
            txtNombre.Text.Trim(), ddlDepto.SelectedValue, txtCorreo.Text.Trim(), ddlNiveles.SelectedValue, ddlEstatus.SelectedValue)

            lblMensaje.Text = "Usuario " & txtUsuario.Text & " guardado!"

            grdUsuarios.SelectedIndex = -1

            If iExiste = 0 Then CorreoBienvenida()

            fillUsuarios()
            fillDeptos()
            fillNiveles()
            clean()

            If grdUsuarios.Visible = False Then Response.Redirect("ListaReclamaciones.aspx")

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Sub CorreoBienvenida()
        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smptClient"), _
                       Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail")))

        Dim obj_mail As New MailMessage()

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), "Sistema Reclamaciones de Clientes")
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(ConfigurationManager.AppSettings.Get("usrRECLAM"), _
        ConfigurationManager.AppSettings.Get("pwdRECLAM"))
        senderMail.EnableSsl = True
        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        If txtCorreo.Text.Trim() = String.Empty Then Exit Sub
        obj_mail.To.Add(txtCorreo.Text.Trim())

        obj_mail.Subject = "Bienvenido(a) al sistema RC"
        obj_mail.IsBodyHtml = True

        obj_mail.Body = "<p><b>" & txtNombre.Text.Trim() & "</b>, le damos la Bienvenida al Sistema de Reclamaciones de Clientes. " & _
        "Usted forma parte del mismo a partir de ahora. </p>" & _
        "<p>Para accesar solo tiene que presionar el link: " & ConfigurationManager.AppSettings.Get("Pagina") & "</p>" & _
        "<b> Usuario: </b>" & txtUsuario.Text.Trim() & "<br/> <br/>" & _
        "<p> Para obtener la <b>contraseña</b> favor comunicarse con el administrador del sistema. </p>" & _
        "<p><br><br> Gracias por usar </p>" & _
        "</br> <p> <b>Sistema de Reclamaciones de Cliente</b> </p>"

        senderMail.Send(obj_mail)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("usuario") <> String.Empty Then Response.Redirect("Login.aspx")

        clsReclamaciones.TieButton(Page, txtContrasena, btnGuardar)

        Try
            If Not Page.IsPostBack() Then
                Dim dtusuario As DataTable = clsReclamaciones.getUsuariosGrid(Session.Item("usuario"))

                fillDeptos()
                fillUsuarios()
                fillNiveles()

                txtUsuario.Text = Session.Item("usuario")
                txtidEmpleado.Text = dtusuario.Rows(0).Item("idempleado")
                txtNombre.Text = dtusuario.Rows(0).Item("nombre")
                ddlDepto.SelectedValue = ddlDepto.Items.FindByValue(dtusuario.Rows(0).Item("idDepto")).Value
                txtCorreo.Text = dtusuario.Rows(0).Item("correo")
                ddlNiveles.SelectedValue = dtusuario.Rows(0).Item("nivel")
                ddlEstatus.SelectedValue = dtusuario.Rows(0).Item("status")

                If Not Session.Item("nivel").ToString().Trim() = 2 Then
                    txtUsuario.Enabled = False
                    txtidEmpleado.Enabled = False
                    txtNombre.Enabled = False
                    ddlDepto.Enabled = False
                    txtCorreo.Enabled = False
                    ddlNiveles.Enabled = False
                    ddlEstatus.Enabled = False

                    grdUsuarios.Visible = False
                    btnNuevo.Visible = False
                End If
            End If

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub

    Private Sub fillDeptos()
        Dim dtDatos As DataTable = clsReclamaciones.getDeptos()
        ddlDepto.DataSource = dtDatos
        ddlDepto.DataTextField = "departamento"
        ddlDepto.DataValueField = "id_departamento"
        ddlDepto.DataBind()

    End Sub

    Private Sub fillNiveles()
        Dim dtDatos As DataTable = clsReclamaciones.getNiveles()
        ddlNiveles.DataSource = dtDatos
        ddlNiveles.DataTextField = "descripcion"
        ddlNiveles.DataValueField = "id_nivel"
        ddlNiveles.DataBind()

    End Sub

    Private Sub fillUsuarios()
        Dim dtDatos As DataTable = clsReclamaciones.getUsuariosGrid("")
        grdUsuarios.DataSource = dtDatos
        grdUsuarios.DataBind()

    End Sub

    Private Sub clean()
        txtUsuario.Text = String.Empty
        txtContrasena.Text = String.Empty
        txtidEmpleado.Text = String.Empty
        txtNombre.Text = String.Empty
        ddlDepto.SelectedIndex = -1
        txtCorreo.Text = String.Empty

    End Sub

    Protected Sub grdUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdUsuarios.SelectedIndexChanged
        txtUsuario.Text = grdUsuarios.SelectedRow.Cells(0).Text
        txtNombre.Text = grdUsuarios.SelectedRow.Cells(2).Text
        ddlDepto.SelectedValue = ddlDepto.Items.FindByValue(CType(grdUsuarios.SelectedRow.FindControl("lblidDepto"), Label).Text).Value
        ddlNiveles.SelectedValue = ddlNiveles.Items.FindByValue(CType(grdUsuarios.SelectedRow.FindControl("lblidnivel"), Label).Text).Value
        txtidEmpleado.Text = CType(grdUsuarios.SelectedRow.FindControl("lblidempleado"), Label).Text
        txtContrasena.Text = CType(grdUsuarios.SelectedRow.FindControl("lblcontrasena"), Label).Text
        txtCorreo.Text = CType(grdUsuarios.SelectedRow.FindControl("lblcorreo"), Label).Text
        ddlEstatus.SelectedValue = CType(grdUsuarios.SelectedRow.FindControl("lblstatus"), Label).Text

        lblMensaje.Text = ""
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        clean()
        lblMensaje.Text = ""
    End Sub

    Protected Sub grdUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdUsuarios.PageIndexChanging
        grdUsuarios.PageIndex = e.NewPageIndex
        fillUsuarios()
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim objEliminar As ImageButton = sender

        Try
            clsReclamaciones.delUsuario(objEliminar.CommandArgument)
            fillUsuarios()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub
End Class
