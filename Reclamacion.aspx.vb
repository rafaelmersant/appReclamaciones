Imports System.Data
Imports System.Net.Mail
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mime

Partial Class Reclamacion
    Inherits System.Web.UI.Page

    Private Shared iFiles As Integer = 0
    Private Shared arrFiles As New ArrayList
    Private intComentario As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("usuario") <> String.Empty Then Response.Redirect("Login.aspx")
        MaintainScrollPositionOnPostBack = True

        clsReclamaciones.TieButton(Page, txtPedido, btnBuscaPedido)
        clsReclamaciones.TieButton(Page, txtTipoPedido, btnBuscaPedido)
        clsReclamaciones.TieButton(Page, txtCodProd, btnBProd)

        If Not Page.IsPostBack Then
            Try

                'Configurar RECLAMACION por defecto
                ddlTipoDoc.SelectedIndex = 1

                'Bloquear TIPO DOCUMENTO si no es administrador
                If Session.Item("nivel") = 2 Then
                    ddlTipoDoc.Enabled = True
                Else
                    ddlTipoDoc.Enabled = False
                End If

                'Poblar Metrica
                ddlMetrica.Items.Clear()
                For Each m As String In ConfigurationManager.AppSettings.Get("Metricas").Split(";")
                    ddlMetrica.Items.Add(New ListItem(m, m))
                Next

                'Poblar Clase Documento
                ddlClaseDoc.Items.Clear()
                For Each m As String In ConfigurationManager.AppSettings.Get("ClaseDoc").Split(";")
                    ddlClaseDoc.Items.Add(New ListItem(m, m))
                Next

                txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

                fillTiposFacturas()
                fillGruposDDL()

                'fillClientes()
                'fillVendedores()
                'fillPlantas()
                'fillChoferes("")
                'fillTransportistas("")

                llenaReclamacion()

                ListaComentarios(dlVentas, ConfigurationManager.AppSettings.Get("deptoVENTAS"))
                ListaComentarios(dlProduccion, ConfigurationManager.AppSettings.Get("deptoPRODUCCION"))
                ListaComentarios(dlLogistica, ConfigurationManager.AppSettings.Get("deptoLOGISTICA"))
                ListaComentarios(dlFinanzas, ConfigurationManager.AppSettings.Get("deptoFINANZAS"))
                ListaComentarios(dlCalidad, ConfigurationManager.AppSettings.Get("deptoCALIDAD"))

                WhoDepto()
                CERRADA()

            Catch ex As Exception
                lblMensaje.Text = "Exception details: " & ex.ToString()
            End Try

        End If

    End Sub

    Public Shared Function ToLongString(time As TimeSpan) As String
        Dim output As String = String.Empty

        If time.Days > 0 Then
            output += time.Days.ToString() + " dias"
        End If

        If (time.Days = 0 Or time.Days = 1) And time.Hours > 0 Then
            output += time.Hours.ToString() + " horas "
        End If

        If (time.Days = 0 And time.Minutes > 0) Then
            output += time.Minutes.ToString() + " minutos "
        End If

        If output.Length = 0 Then
            output += time.Seconds.ToString() + " segundos"
        End If

        Return output
    End Function

    Private Sub fillComentariosCrono(id_reclamacion As Integer)

        Dim dtdatos As DataTable = clsReclamaciones.getComentariosCronologico(id_reclamacion)

        grdComentariosCron.DataSource = dtdatos
        grdComentariosCron.DataBind()

        Dim index = 0

        If grdComentariosCron.Rows.Count > 1 Then

            For Each row As GridViewRow In grdComentariosCron.Rows

                If index >= 1 Then
                    Dim firstFecha As String = CType(grdComentariosCron.Rows(index - 1).Cells(3).FindControl("lblTime"), Label).Text
                    Dim firstTime As DateTime = DateTime.Parse(firstFecha)

                    Dim secondFecha As String = CType(row.Cells(3).FindControl("lblTime"), Label).Text
                    Dim secondTime As DateTime = DateTime.Parse(secondFecha)
                    Dim timeResult = secondTime - firstTime

                    Dim result = ToLongString(timeResult)

                    CType(row.Cells(3).FindControl("lblTimeAgo"), Label).Text = result
                End If

                index += 1
            Next

        End If

    End Sub

    'Private Sub fillChoferes(ByVal chofer As String)
    '    Dim dtDatos As DataTable = clsReclamaciones.getChofer(chofer).Tables(0)
    '    ddlChoferes.DataSource = dtDatos
    '    ddlChoferes.DataTextField = "NOMBRE_CLIENTE"
    '    ddlChoferes.DataValueField = "COD_CLIENTE"
    '    ddlChoferes.DataBind()

    '    ddlChoferes.Items.Insert(0, New ListItem("...", ""))

    'End Sub

    'Private Sub fillTransportistas(ByVal suplidor As String)
    '    Dim dtDatos As DataTable = clsReclamaciones.getTransportista(suplidor).Tables(0)
    '    ddlTransportista.DataSource = dtDatos
    '    ddlTransportista.DataTextField = "NOMBRE_SUPLIDOR"
    '    ddlTransportista.DataValueField = "COD_SUPLIDOR"
    '    ddlTransportista.DataBind()

    '    ddlTransportista.Items.Insert(0, New ListItem("...", ""))
    'End Sub

    Private Sub fillTiposFacturas()

        Dim tipos As String = ConfigurationManager.AppSettings.Get("tiposFacturas")

        ddlTipoFactura.Items.Clear()
        For Each item As String In tipos.Split(";")
            ddlTipoFactura.Items.Add(New ListItem(item, item))
        Next

    End Sub

    Private Sub fillTiposPedidos()

        Dim tipos As String = ConfigurationManager.AppSettings.Get("tiposPedidos")

        ddlTipoFactura.Items.Clear()
        For Each item As String In tipos.Split(";")
            ddlTipoFactura.Items.Add(New ListItem(item, item))
        Next

    End Sub

    Private Sub fillGruposDDL()
        Dim dtDatos As DataTable = clsReclamaciones.getGrupos()
        ddlGruposF.DataSource = dtDatos
        ddlGruposF.DataTextField = "grupo"
        ddlGruposF.DataValueField = "id_grupo"
        ddlGruposF.DataBind()

        ddlGruposF.Items.Insert(0, New ListItem("TODOS", "0"))

    End Sub

    Private Sub WhoDepto()

        Dim usr As String = ConfigurationManager.AppSettings.Get("SuperUsr")

        If usr.Contains(Session.Item("usuario")) Then

            btnAgregarV.Visible = True
            btnAgregarP.Visible = True
            btnAgregarL.Visible = True
            btnAgregarF.Visible = True
            btnAgregarC.Visible = True
            btnAgregarA.Visible = True
        Else

            Select Case Session.Item("depto")
                Case 1
                    btnAgregarV.Visible = True
                Case 2
                    btnAgregarP.Visible = True
                Case 3
                    btnAgregarL.Visible = True
                Case 4
                    btnAgregarF.Visible = True
                Case 5
                    btnAgregarC.Visible = True
                Case 6
                    btnAgregarA.Visible = True
            End Select

        End If

    End Sub

    Private Sub CERRADA()
        If lblStatus.Text.Trim() = "CERRADA" Then
            btnAgregarV.Visible = False
            btnAgregarP.Visible = False
            btnAgregarL.Visible = False
            btnAgregarF.Visible = False
            btnAgregarC.Visible = False
            btnAgregarA.Visible = False

            btnAgregarMotivoFast.Visible = False

            txtCerradaFecha.Visible = True
            lblCerrada.Visible = True

            If Session.Item("nivel").ToString() = 2 Then
                btnReportToClient.Visible = True
                btnEnviarMail.Visible = True
            End If

            btnAgregarProd.Enabled = False
            btnSelProductos.Enabled = False
            grdProdReclam.Enabled = False
        End If

    End Sub

    'GUARDAR RECLAMACION
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim Factura As String
            Dim Pedido As String

            If rbFactura.Checked Then
                Factura = txtPedido.Text
                Pedido = String.Empty
            Else
                Pedido = txtPedido.Text.Trim() '& "-" & txtTipoPedido.Text.Trim()
                Factura = String.Empty
            End If

            If ddlTipoDoc.SelectedIndex = 0 Then
                Throw New Exception("Debe seleccionar el tipo de documento: RECLAMACION o DEVOLUCION.")
            End If

            If txtPedido.Text.Trim() = String.Empty Then lblMensaje.Text = "Debe digitar una factura/pedido." : Exit Try
            If txtDescripcion.Text.Trim() = String.Empty Then lblMensaje.Text = "Debe especificar la descripción de la reclamación" : Exit Try
            If lbUsrInvolucrados.Items.Count < 1 Then lblMensaje.Text = "debe incluir por lo menos un usuario en la reclamación" : Exit Try

            clsReclamaciones.guardaReclamacion(Pedido,
                                                txtDescripcion.Text.Trim(),
                                                ddlCliente.SelectedValue,
                                                txtContacto.Text.Trim(),
                                                Factura,
                                                ddlVentas.SelectedValue,
                                                txtTelefono.Text,
                                                ddlVendedor.SelectedValue,
                                                0,
                                                txtConclusion.Text,
                                                Session.Item("usuario"),
                                                txtSoporteVta.Text, txtCorreo.Text,
                                                ddlTipoDoc.SelectedValue,
                                                ddlChoferes.SelectedValue,
                                                ddlTransportista.SelectedValue,
                                                ddlCliente.SelectedItem.Text,
                                                ddlTipoFactura.SelectedValue)

            updateProductos() 'Aqui dentro se verifica si productos fueron deseleccionados para ser eliminados

            UsuariosReclamacion() 'Aqui dentro se envia el correo

            Response.Redirect("Reclamacion.aspx?id=" & Val(lblNoReclamacion.Text))

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Private Sub updateProductos()
        Dim indexDeleted = 0

        For Each row As GridViewRow In grdProdReclam.Rows
            Dim chkProd = CType(row.Cells(0).FindControl("chkProd"), CheckBox)

            If chkProd.Checked = False Then

                If indexDeleted = grdProdReclam.Rows.Count - 1 Then
                    Throw New Exception("Debe al menos tener un producto en la reclamación.")
                End If

                clsReclamaciones.delProducto(chkProd.CssClass) 'En este caso el id_producto esta contenido en la propiedad CssClass
                indexDeleted += 1
            End If

        Next

    End Sub

    Private Sub UsuariosReclamacion()
        Dim usr As String = ""

        For Each item As ListItem In lbUsrInvolucrados.Items
            usr = clsReclamaciones.getUsuarioByCorreo(item.Value.Trim())
            clsReclamaciones.setUsuarioReclamacion(Val(lblNoReclamacion.Text), usr)
        Next

        EnviaCorreo()
    End Sub


#Region "CORREO ELECTRONICO"

    Private Sub EnviaCorreoCarta(ByVal Correo As String, ByVal Archivo As String)

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim obj_mail As New MailMessage()
        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smtpClient"))
        Dim oCorreos() As String = Correo.Split(";")
        Dim c As String
        Dim sBody As String = String.Empty

        Dim usrName As String = ConfigurationManager.AppSettings.Get("usrRECLAM")
        Dim usrPass As String = ConfigurationManager.AppSettings.Get("pwdRECLAM")

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), ConfigurationManager.AppSettings.Get("EmailName"))
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(usrName, usrPass)

        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        For Each c In oCorreos
            If Not c Is String.Empty Then
                obj_mail.To.Add(c)
            End If
        Next

        obj_mail.Attachments.Add(New Attachment(Archivo))

        obj_mail.Subject = ConfigurationManager.AppSettings.Get("ASUNTOCARTA") + " #" + (Val(lblNoReclamacion.Text)).ToString()

        If obj_mail.To.Count < 1 Then Exit Sub
        obj_mail.IsBodyHtml = True

        sBody = getTemplateForCartaCte()
        sBody = sBody.Replace("@NORECL", Val(lblNoReclamacion.Text))
        sBody = sBody.Replace("#nombreRemitente#", Session.Item("name"))

        Dim avHtml = AlternateView.CreateAlternateViewFromString(sBody, Encoding.UTF8, MediaTypeNames.Text.Html)
        Dim inline As New LinkedResource(MapPath("~\Templates\logoFirmaRC.jpeg"), MediaTypeNames.Image.Jpeg)

        inline.ContentId = "firmaLogo"
        avHtml.LinkedResources.Add(inline)

        'ConfigurationManager.AppSettings.Get("BODYCARTA")

        obj_mail.AlternateViews.Add(avHtml)
        obj_mail.Body = sBody

        Try
            senderMail.Send(obj_mail)

        Catch em As SmtpFailedRecipientException
            Throw New Exception(em.Source & "|" & em.Message & "|" & em.StatusCode)

        Catch ex As Exception
            Throw New Exception(ex.ToString())

        Finally
            obj_mail.Dispose()
        End Try

    End Sub

    Private Sub EnviaCorreo()

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smtpClient"))
        Dim obj_mail As New MailMessage()

        Dim usrName As String = ConfigurationManager.AppSettings.Get("usrRECLAM")
        Dim usrPass As String = ConfigurationManager.AppSettings.Get("pwdRECLAM")

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), ConfigurationManager.AppSettings.Get("EmailName"))
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(usrName, usrPass)
        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        For Each item As ListItem In lbUsrInvolucrados.Items
            obj_mail.To.Add(item.Value.Trim())
        Next

        If obj_mail.To.Count < 1 Then Exit Sub
        obj_mail.IsBodyHtml = True

        obj_mail.Subject = ConfigurationManager.AppSettings.Get("ASUNTO") & " " & lblNoReclamacion.Text

        obj_mail.Body = "Existe una nueva reclamación (la #" & Val(lblNoReclamacion.Text) & ")" &
        "<br/> <br/> <b>Descripción de la Reclamación:</b> <br/>" & txtDescripcion.Text & " <br/><br/><b>CLIENTE: " & ddlCliente.SelectedItem.Text & "</b>" &
        "<br/> <br/>" & "También puede revisarla accediendo a " & ConfigurationManager.AppSettings.Get("Pagina")

        senderMail.Send(obj_mail)
    End Sub

    Private Sub EnviaCorreoNuevoComentario(ByVal sComentario As String, ByVal tipo As String)

        Dim sCliente As String
        Dim dtUsuarios As DataTable

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smtpClient"))
        Dim obj_mail As New MailMessage()

        Dim usrName As String = ConfigurationManager.AppSettings.Get("usrRECLAM")
        Dim usrPass As String = ConfigurationManager.AppSettings.Get("pwdRECLAM")

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), ConfigurationManager.AppSettings.Get("EmailName"))
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(usrName, usrPass)

        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        dtUsuarios = clsReclamaciones.getUsrEstanReclamacion(Val(lblNoReclamacion.Text))

        For Each row As DataRow In dtUsuarios.Rows
            If Integer.Parse(row.Item("nivel")) > 0 Then
                obj_mail.To.Add(row.Item("correo").ToString().Trim())
            End If
        Next

        If obj_mail.To.Count < 1 Then Exit Sub

        'Para tomar el cliente
        If Not txtContacto.Text = String.Empty Then
            sCliente = txtContacto.Text
        Else
            sCliente = ddlCliente.SelectedItem.Text
        End If

        obj_mail.IsBodyHtml = True

        obj_mail.Subject = ConfigurationManager.AppSettings.Get("ASUNTO") & " " & lblNoReclamacion.Text & " NUEVO COMENTARIO - por " & Session.Item("name").ToString().Trim()
        obj_mail.Body = "<b>Descripción de la Reclamación:</b> <br/>" & txtDescripcion.Text & " <br/><b>CLIENTE: " & sCliente & "</b>" _
        & " <br/><br/> <b>Comentario:</b> <br/>" & sComentario & "<br/><br/> " &
        " Por: <b>" & Session.Item("name").ToString().Trim() & "</b> <br/>" & Format(Now, "dd/MM/yyyy hh:mm tt") &
        "<br/> <br/>" & "También puede revisarla accediendo a " & ConfigurationManager.AppSettings.Get("Pagina")
        'obj_mail.Body = "Se ha modificado con un nuevo comentario la reclamación #" & lblNoReclamacion.Text & ". Puede revisarla accediendo a " & ConfigurationManager.AppSettings.Get("Pagina")

        senderMail.Send(obj_mail)
    End Sub

    Private Sub EnviaCorreoNuevoInvolucradosVENDEDORES(ByVal sComentario As String, ByVal tipo As String)

        Dim dtUsuarios As DataTable

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smtpClient"))
        Dim obj_mail As New MailMessage()

        Dim usrName As String = ConfigurationManager.AppSettings.Get("usrRECLAM")
        Dim usrPass As String = ConfigurationManager.AppSettings.Get("pwdRECLAM")

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), ConfigurationManager.AppSettings.Get("EmailName"))
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(usrName, usrPass)

        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        dtUsuarios = clsReclamaciones.getUsrEstanReclamacion(Val(lblNoReclamacion.Text))

        For Each row As DataRow In dtUsuarios.Rows
            If Integer.Parse(row.Item("nivel")) = 0 Then
                obj_mail.To.Add(row.Item("correo").ToString().Trim())
            End If
        Next

        If obj_mail.To.Count < 1 Then Exit Sub
        obj_mail.IsBodyHtml = True

        obj_mail.Subject = ConfigurationManager.AppSettings.Get("ASUNTO") & " " & lblNoReclamacion.Text & tipo & " - INF. PARA VENDEDORES"
        obj_mail.Body = "<b>COMENTARIO</b> <br/>" & sComentario & "<br/>" & " por: <b>" & Session.Item("name").ToString().Trim() & "</b> <br/>" & Format(Now, "dd/MM/yyyy hh:mm tt")

        senderMail.Send(obj_mail)
    End Sub

    Private Sub EnviaCorreoConclusion()

        Dim dtUsuarios As DataTable

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smtpClient"))
        Dim obj_mail As New MailMessage()

        Dim usrName As String = ConfigurationManager.AppSettings.Get("usrRECLAM")
        Dim usrPass As String = ConfigurationManager.AppSettings.Get("pwdRECLAM")

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), ConfigurationManager.AppSettings.Get("EmailName"))
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(usrName, usrPass)

        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        dtUsuarios = clsReclamaciones.getUsrEstanReclamacion(Val(lblNoReclamacion.Text))

        For Each row As DataRow In dtUsuarios.Rows
            If Integer.Parse(row.Item("nivel").ToString()) > 0 Then
                obj_mail.To.Add(row.Item("correo").ToString().Trim())
            End If
        Next

        If obj_mail.To.Count < 1 Then Exit Sub

        obj_mail.IsBodyHtml = True

        obj_mail.Subject = ConfigurationManager.AppSettings.Get("ASUNTO") & " " & lblNoReclamacion.Text & " CERRADA"
        obj_mail.Body = "<b>Conclusión:</b> <br/>" &
        txtConclusion.Text & " <br/> <br/> " &
        "Puede ver mas detalles de la reclamación accediendo a " & ConfigurationManager.AppSettings.Get("Pagina")

        senderMail.Send(obj_mail)
    End Sub
#End Region

#Region "AREAS AGREGAR COMENTARIOS"

    '*************************************************************************************************************
    'VENTAS ******************************************************************************************************
    '*************************************************************************************************************
    Protected Sub btnAgregarV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarV.Click
        txtComentarioV.Visible = True
        btnGuardaV.Visible = True
        btnCancelarV.Visible = True
        btnAgregarV.Enabled = False

        fuFileV.Visible = True
        btnAgregarFileV.Visible = True
        LiteralFileV.Visible = True

    End Sub

    Protected Sub btnGuardaV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaV.Click
        Try
            Dim pComentario As String = txtComentarioV.Text
            Dim iVentasDepto As Integer = ConfigurationManager.AppSettings.Get("deptoVENTAS")

            If txtComentarioV.Text.Trim() <> String.Empty Then
                intComentario = guardaComentario(txtComentarioV.Text.Trim(), iVentasDepto)
            Else : Exit Try
            End If

            txtComentarioV.Visible = False : txtComentarioV.Text = String.Empty
            btnGuardaV.Visible = False
            btnCancelarV.Visible = False
            btnAgregarV.Enabled = True

            fuFileV.Visible = False
            btnAgregarFileV.Visible = False
            LiteralFileV.Visible = False
            btnEliminarAdjV.Visible = False

            'Si existen archivos para adjuntar
            If arrFiles.Count > 0 Then
                AgregarFile(intComentario, iVentasDepto)
                CleanVentas()
            End If

            EnviaCorreoNuevoComentario(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())
            EnviaCorreoNuevoInvolucradosVENDEDORES(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())

            ListaComentarios(dlVentas, iVentasDepto)

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnCancelarV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarV.Click
        Try
            txtComentarioV.Text = String.Empty
            btnGuardaV_Click(Nothing, Nothing)
            btnEliminarAdj_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    '*************************************************************************************************************
    'PRODUCCION **************************************************************************************************
    '*************************************************************************************************************
    Protected Sub btnAgregarP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarP.Click
        txtComentarioP.Visible = True
        btnGuardaP.Visible = True
        btnCancelarP.Visible = True
        btnAgregarP.Enabled = False

        fuFileP.Visible = True
        btnAgregarFileP.Visible = True
        LiteralFileP.Visible = True

    End Sub

    Protected Sub btnGuardaP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaP.Click
        Try
            Dim pComentario As String = txtComentarioP.Text
            Dim iPRODDepto As Integer = ConfigurationManager.AppSettings.Get("deptoPRODUCCION")

            If txtComentarioP.Text.Trim() <> String.Empty Then
                intComentario = guardaComentario(txtComentarioP.Text.Trim(), iPRODDepto)
            Else : Exit Try
            End If

            txtComentarioP.Visible = False : txtComentarioP.Text = String.Empty
            btnGuardaP.Visible = False
            btnCancelarP.Visible = False
            btnAgregarP.Enabled = True

            fuFileP.Visible = False
            btnAgregarFileP.Visible = False
            LiteralFileP.Visible = False
            btnEliminarAdjP.Visible = False

            'Si existen archivos para adjuntar
            If arrFiles.Count > 0 Then
                AgregarFile(intComentario, iPRODDepto)
                CleanProduccion()
            End If

            ListaComentarios(dlProduccion, iPRODDepto)

            EnviaCorreoNuevoComentario(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())
            EnviaCorreoNuevoInvolucradosVENDEDORES(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnCancelarP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarP.Click
        Try
            txtComentarioP.Text = String.Empty
            btnGuardaP_Click(Nothing, Nothing)
            btnEliminarAdjP_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    '*************************************************************************************************************
    'LOGISTICA ***************************************************************************************************
    '*************************************************************************************************************
    Protected Sub btnAgregarL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarL.Click
        txtComentarioL.Visible = True
        btnGuardaL.Visible = True
        btnCancelarL.Visible = True
        btnAgregarL.Enabled = False

        fuFileL.Visible = True
        btnAgregarFileL.Visible = True
        LiteralFileL.Visible = True

    End Sub

    Protected Sub btnGuardaL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaL.Click
        Try
            Dim pComentario As String = txtComentarioL.Text
            Dim iLogisticaDepto As Integer = ConfigurationManager.AppSettings.Get("deptoLOGISTICA")

            If txtComentarioL.Text.Trim() <> String.Empty Then
                intComentario = guardaComentario(txtComentarioL.Text.Trim(), iLogisticaDepto)
            Else : Exit Try
            End If

            txtComentarioL.Visible = False : txtComentarioL.Text = String.Empty
            btnGuardaL.Visible = False
            btnCancelarL.Visible = False
            btnAgregarL.Enabled = True

            fuFileL.Visible = False
            btnAgregarFileL.Visible = False
            LiteralFileL.Visible = False
            btnEliminarAdjL.Visible = False

            'Si existen archivos para adjuntar
            If arrFiles.Count > 0 Then
                AgregarFile(intComentario, iLogisticaDepto)
                CleanLogistica()
            End If

            ListaComentarios(dlLogistica, iLogisticaDepto)

            EnviaCorreoNuevoComentario(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())
            EnviaCorreoNuevoInvolucradosVENDEDORES(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnCancelarL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarL.Click
        Try
            txtComentarioL.Text = String.Empty
            btnGuardaL_Click(Nothing, Nothing)
            btnEliminarAdjL_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    '*************************************************************************************************************
    'FINANZAS ****************************************************************************************************
    '*************************************************************************************************************
    Protected Sub btnAgregarF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarF.Click
        txtComentarioF.Visible = True
        btnGuardaF.Visible = True
        btnCancelarF.Visible = True
        btnAgregarF.Enabled = False

        fuFileF.Visible = True
        btnAgregarFileF.Visible = True
        LiteralFileF.Visible = True

    End Sub

    Protected Sub btnGuardaF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaF.Click
        Try
            Dim pComentario As String = txtComentarioF.Text
            Dim iFinanzasDepto As Integer = ConfigurationManager.AppSettings.Get("deptoFINANZAS")

            If txtComentarioF.Text.Trim() <> String.Empty Then
                intComentario = guardaComentario(txtComentarioF.Text.Trim(), iFinanzasDepto)
            Else : Exit Try
            End If

            txtComentarioF.Visible = False : txtComentarioF.Text = String.Empty
            btnGuardaF.Visible = False
            btnCancelarF.Visible = False
            btnAgregarF.Enabled = True

            fuFileF.Visible = False
            btnAgregarFileF.Visible = False
            LiteralFileF.Visible = False
            btnEliminarAdjF.Visible = False

            'Si existen archivos para adjuntar
            If arrFiles.Count > 0 Then
                AgregarFile(intComentario, iFinanzasDepto)
                CleanFinanzas()
            End If

            ListaComentarios(dlFinanzas, iFinanzasDepto)

            EnviaCorreoNuevoComentario(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())
            EnviaCorreoNuevoInvolucradosVENDEDORES(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnCancelarF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarF.Click
        Try
            txtComentarioF.Text = String.Empty
            btnGuardaF_Click(Nothing, Nothing)
            btnEliminarAdjF_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    '*************************************************************************************************************
    'AUDITORIA ***************************************************************************************************
    '*************************************************************************************************************
    Protected Sub btnAgregarA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarA.Click
        txtComentarioA.Visible = True
        btnGuardaA.Visible = True
        btnCancelarA.Visible = True
        btnAgregarA.Enabled = False

        fuFileA.Visible = True
        btnAgregarFileA.Visible = True
        LiteralFileA.Visible = True

    End Sub

    Protected Sub btnGuardaA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaA.Click
        Try
            Dim pComentario As String = txtComentarioA.Text
            Dim iAUDDepto As Integer = ConfigurationManager.AppSettings.Get("deptoAUDITORIA")

            If txtComentarioA.Text.Trim() <> String.Empty Then
                intComentario = guardaComentario(txtComentarioA.Text.Trim(), iAUDDepto)
            Else : Exit Try
            End If

            txtComentarioA.Visible = False : txtComentarioA.Text = String.Empty
            btnGuardaA.Visible = False
            btnCancelarA.Visible = False
            btnAgregarA.Enabled = True

            fuFileA.Visible = False
            btnAgregarFileA.Visible = False
            LiteralFileA.Visible = False
            btnEliminarAdjA.Visible = False

            'Si existen archivos para adjuntar
            If arrFiles.Count > 0 Then
                AgregarFile(intComentario, iAUDDepto)
                CleanAuditoria()
            End If

            ListaComentarios(dlAuditoria, iAUDDepto)

            EnviaCorreoNuevoComentario(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())
            EnviaCorreoNuevoInvolucradosVENDEDORES(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnCancelarA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarA.Click
        Try
            txtComentarioA.Text = String.Empty
            btnGuardaA_Click(Nothing, Nothing)
            btnEliminarAdjA_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    '*************************************************************************************************************
    'CALIDAD *****************************************************************************************************
    '*************************************************************************************************************
    Protected Sub btnAgregarC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarC.Click
        txtComentarioC.Visible = True
        btnGuardaC.Visible = True
        btnCancelarC.Visible = True
        btnAgregarC.Enabled = False

        fuFileC.Visible = True
        btnAgregarFileC.Visible = True
        LiteralFileC.Visible = True

    End Sub

    Protected Sub btnGuardaC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaC.Click
        Try
            Dim pComentario As String = txtComentarioC.Text
            Dim iCalidadDepto As Integer = ConfigurationManager.AppSettings.Get("deptoCALIDAD")

            If txtComentarioC.Text.Trim() <> String.Empty Then
                intComentario = guardaComentario(txtComentarioC.Text.Trim(), iCalidadDepto)
            Else : Exit Try
            End If

            txtComentarioC.Visible = False : txtComentarioC.Text = String.Empty
            btnGuardaC.Visible = False
            btnCancelarC.Visible = False
            btnAgregarC.Enabled = True

            fuFileC.Visible = False
            btnAgregarFileC.Visible = False
            LiteralFileC.Visible = False
            btnEliminarAdjC.Visible = False

            'Si existen archivos para adjuntar
            If arrFiles.Count > 0 Then
                AgregarFile(intComentario, iCalidadDepto)
                CleanCalidad()
            End If

            ListaComentarios(dlCalidad, iCalidadDepto)

            EnviaCorreoNuevoComentario(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())
            EnviaCorreoNuevoInvolucradosVENDEDORES(pComentario, " NUEVO COMENTARIO - por" & Session.Item("name").ToString().Trim())

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnCancelarC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarC.Click
        Try
            txtComentarioC.Text = String.Empty
            btnGuardaC_Click(Nothing, Nothing)
            btnEliminarAdjC_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "FILL objects"

    Private Function guardaComentario(ByVal sComentario As String, depto As Integer) As Integer
        Return clsReclamaciones.guardaComentario(Val(lblNoReclamacion.Text), sComentario, Session.Item("usuario"), depto)
    End Function

    Private Sub ListaComentarios(ByRef dlist As DataList, ByVal depto As Integer)
        Dim dtComentarios As New DataTable
        dtComentarios = clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), depto)

        dlist.DataSource = dtComentarios
        dlist.DataBind()
    End Sub

    Private Sub fillAreas()

        Dim dtDatos As DataTable = clsReclamaciones.getAreas()
        ddlAreas.DataSource = dtDatos
        ddlAreas.DataTextField = "area"
        ddlAreas.DataValueField = "id_area"
        ddlAreas.DataBind()

        ddlAreas.Items.Insert(0, New ListItem("Seleccionar area...", "0"))

    End Sub

    Private Sub fillMotivos()
        Dim dtDatos As DataTable = clsReclamaciones.getMotivos()
        ddlMotivos.DataSource = dtDatos
        ddlMotivos.DataTextField = "descripcion"
        ddlMotivos.DataValueField = "id_motivo"
        ddlMotivos.DataBind()

        ddlMotivos.Items.Insert(0, New ListItem("Seleccionar motivo...", "0"))

    End Sub

    'Este metodo llena el GridView, solo la columna de codigo de producto.
    Private Sub fillProductos(ByVal irecl As Integer, Optional selectAll As Boolean = True)
        Dim prod As New DataTable

        prod = clsReclamaciones.getProductosRecl(irecl)
        grdProdReclam.DataSource = prod
        grdProdReclam.DataBind()

        If grdProdReclam.Rows.Count > 0 Then

            btnSelProductos.Visible = True
            lblProdMessage.Visible = True
            btnAgregarProd.Visible = True
            imgbtnRefresh.Visible = True

            btnSelProductos.Text = "Seleccionar todos"
            btnSelProductos_Click(Nothing, Nothing)

        Else
            btnSelProductos.Visible = False
            lblProdMessage.Visible = False
            imgbtnRefresh.Visible = False
        End If

    End Sub

    Private Sub fillPlantas()
        'Dim dtDatos As DataTable = clsReclamaciones.getPlantas()
        'ddlPlanta.DataSource = dtDatos
        'ddlPlanta.DataTextField = "descripcion"
        'ddlPlanta.DataValueField = "descripcion"
        'ddlPlanta.DataBind()

    End Sub

    Private Sub getUsuariosInvLB(ByVal grupo As Integer)
        Dim dtDatos As DataTable = clsReclamaciones.getUsuarios(grupo)
        lbUsuarios.DataSource = dtDatos
        lbUsuarios.DataTextField = "Nombre" '"usuario"
        lbUsuarios.DataValueField = "correo"
        lbUsuarios.DataBind()

    End Sub

    Private Sub getUsuariosInv(ByVal reclamacion As Integer)
        Dim dtDatos As DataTable = clsReclamaciones.getUsrNoEstanReclamacion(reclamacion)
        lbUsuarios.DataSource = dtDatos
        lbUsuarios.DataTextField = "Nombre" '"usuario"
        lbUsuarios.DataValueField = "correo"
        lbUsuarios.DataBind()

    End Sub

    Private Sub MostrarUsuariosInv(ByVal reclamacion As Integer)
        Dim dtDatos As DataTable = clsReclamaciones.getUsrEstanReclamacion(reclamacion)
        lbInvolucrados.DataSource = dtDatos
        lbInvolucrados.DataTextField = "Nombre" '"usuario"
        lbInvolucrados.DataValueField = "correo"
        lbInvolucrados.DataBind()

    End Sub

    Private Sub ListaArchivos(ByRef LitFiles As Literal, ByVal depto As String, ByVal idcomentario As Integer)
        Dim dtArchivos As New DataTable
        dtArchivos = clsReclamaciones.getArchivos(depto, Val(lblNoReclamacion.Text))

        LitFiles.Text = "<div>"
        For Each row As DataRow In dtArchivos.Rows
            LitFiles.Text &= " <a href=""Adjuntos/" & row.Item("ruta") & """ target=""_blank"" > " & row.Item("ruta") & "</a> |"
        Next
        LitFiles.Text &= "</div>"

    End Sub
#End Region

    Protected Sub btnBuscaPedido_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscaPedido.Click
        Dim sMens As String = String.Empty
        lblMensaje.Text = sMens

        Try

            If rbFactura.Checked Then
                sMens = "NO EXISTE LA FACTURA"
                BuscarPorFactura()

                If Not clsReclamaciones.getDocumentoExiste(txtPedido.Text, "F") Is Nothing Then
                    lblExiste.Text = "Existe una reclamacion con este documento."
                    lblExiste.Visible = True
                End If
            Else
                sMens = "NO EXISTE EL PEDIDO"
                BuscarPorPedido()

                If Not clsReclamaciones.getDocumentoExiste(txtPedido.Text, "P") Is Nothing Then
                    lblExiste.Text = "Existe una reclamacion con este documento."
                    lblExiste.Visible = True
                End If
            End If

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
            If ex.Message = "Index was outside the bounds of the array." Then lblMensaje.Text = sMens
        End Try
    End Sub

    Private Sub BuscarPorPedido()
        ddlCliente.Items.Clear()
        ddlVendedor.Items.Clear()

        grdProdReclam.DataSource = Nothing
        grdProdReclam.DataBind()

        lblExiste.Text = String.Empty
        txtTipoPedido.Text = String.Empty

        Dim datos As DataTable = clsReclamaciones.getPedidoERP(txtPedido.Text, lblNoReclamacion.Text, ddlTipoFactura.SelectedValue)

        If datos.Rows.Count > 0 Then
            Dim vendedorNombre As String = clsReclamaciones.getVendedorNombreERP(datos.Rows(0).Item("CodigoVendedor"))

            ddlVendedor.Items.Add(New ListItem(Trim(vendedorNombre), Trim(datos.Rows(0).Item("codigoVendedor"))))
            ddlCliente.Items.Add(New ListItem(Trim(datos.Rows(0).Item("nombreCte")), Trim(datos.Rows(0).Item("codigoCte"))))

            'txtTipoPedido.Text = Trim(datos(6))

            'If datos(5) = "VE" Then ddlVentas.Text = "INTERNACIONALES"
            lblMensaje.Text = String.Empty
            fillProductos(lblNoReclamacion.Text)
        Else
            lblExiste.Visible = True
            lblExiste.Text = "NO EXISTE EL PEDIDO"
        End If
    End Sub

    'Este metodo busca la factura para extraer los campos: Vendedor, Cliente, Venta Local/Internacional
    'y extrae el listado de productos de dicha factura
    Private Sub BuscarPorFactura()

        ddlCliente.Items.Clear()
        ddlVendedor.Items.Clear()

        grdProdReclam.DataSource = Nothing
        grdProdReclam.DataBind()

        lblExiste.Text = String.Empty
        txtTipoPedido.Text = String.Empty

        Dim datos As DataTable = clsReclamaciones.getFacturaERP(txtPedido.Text, lblNoReclamacion.Text, ddlTipoFactura.SelectedValue)

        If datos.Rows.Count > 0 Then
            Dim vendedorNombre As String = clsReclamaciones.getVendedorNombreERP(datos.Rows(0).Item("codigoVendedor"))

            ddlVendedor.Items.Add(New ListItem(Trim(vendedorNombre), Trim(datos.Rows(0).Item("codigoVendedor"))))
            ddlCliente.Items.Add(New ListItem(Trim(datos.Rows(0).Item("NombreCte")), Trim(datos.Rows(0).Item("codigoCte"))))

            'If datos(5) = "VE" Then ddlVentas.Text = "INTERNACIONALES"
            lblMensaje.Text = String.Empty
            fillProductos(lblNoReclamacion.Text)
        Else
            lblExiste.Visible = True
            lblExiste.Text = "NO EXISTE LA FACTURA"
        End If
    End Sub

    Private Sub llenaReclamacion()
        Dim iReclamacion As Integer
        Dim dtDatos As New DataTable

        Dim sCliente As String
        Dim sVendedor As String

        Dim nCliente As String
        Dim nVendedor As String

        'RECLAMACION EXISTENTE
        If Request.QueryString.Count > 0 Then
            iReclamacion = Integer.Parse(Request.QueryString("id"))

            fillAreas()
            fillMotivos()
            MostrarUsuariosInv(iReclamacion)
            fillProductos(iReclamacion)

            fillComentariosCrono(iReclamacion)

            'VISIBLES******
            pnDetalles.Enabled = False
            btnGuardar.Visible = False
            lblDeptosInvolucrados.Visible = True
            Accordion1.Visible = True
            btnSaveMail.Visible = True
            btnSaveMail.Enabled = True

            'CONCLUSION
            lblConclusion.Visible = True
            txtConclusion.Visible = True
            lblArea.Visible = True
            ddlAreas.Visible = True
            lblMotivo.Visible = True
            ddlMotivos.Visible = True
            btnAgregarMotivoFast.Visible = True

            lblMonto.Visible = True
            txtMonto.Visible = True
            lblNCND.Visible = True
            txtNCND.Visible = True
            lblMoneda.Visible = True
            ddlMoneda.Visible = True
            lblCantidad.Visible = True
            txtCantidad.Visible = True
            lblMetrica.Visible = True
            ddlMetrica.Visible = True
            lblClaseDoc.Visible = True
            ddlClaseDoc.Visible = True
            '--CONCLUSION

            If Session.Item("nivel").ToString().Trim() <> 2 Then
                panelUsrInvolucrados.Visible = False
                lblInvolucradosUsr.Visible = False

                'productos
                Label2.Visible = False
                txtCodProd.Visible = False
                txtNameProducto.Visible = False
                btnAgregarProd.Visible = False
                imgbtnRefresh.Visible = False
                btnBProd.Visible = False
                grdProdReclam.Columns(2).Visible = False

                For Each row As GridViewRow In grdProdReclam.Rows
                    CType(row.Cells(4).FindControl("txtComentProd"), TextBox).ReadOnly = True
                Next
            End If

            dtDatos = clsReclamaciones.getReclamacionDetalle(iReclamacion)

            If dtDatos.Rows.Count > 0 Then

                imgbtnRefresh.Attributes.Add("onload", "conclusion2Area.style.display='';conclusion3Area.style.display='';")

                lblNoReclamacion.Text = Right("00000000" & dtDatos.Rows(0).Item("id_reclamacion"), 8)
                lblStatus.Text = dtDatos.Rows(0).Item("status").ToString().ToUpper()

                'PARA DESPLEGAR SI ES FACTURA O PEDIDO
                If Not dtDatos.Rows(0).Item("factura").ToString().Trim() = String.Empty Then
                    fillTiposFacturas()

                    txtPedido.Text = dtDatos.Rows(0).Item("factura")
                    ddlTipoFactura.SelectedItem.Text = IIf(dtDatos.Rows(0).Item("tipo_fac_ped") Is DBNull.Value, "...", dtDatos.Rows(0).Item("tipo_fac_ped"))

                    rbFactura.Visible = True
                    rbPedido.Visible = False
                Else
                    fillTiposPedidos()

                    txtPedido.Text = dtDatos.Rows(0).Item("pedido")
                    txtTipoPedido.Text = dtDatos.Rows(0).Item("pedido")
                    ddlTipoFactura.SelectedItem.Text = IIf(dtDatos.Rows(0).Item("tipo_fac_ped") Is DBNull.Value, "...", dtDatos.Rows(0).Item("tipo_fac_ped"))

                    rbPedido.Visible = True
                    rbFactura.Visible = False
                End If

                ddlTipoDoc.SelectedValue = dtDatos.Rows(0).Item("tipodoc").ToString().Trim()

                txtContacto.Text = dtDatos.Rows(0).Item("contacto")
                txtFactura.Text = dtDatos.Rows(0).Item("factura")
                txtFecha.Text = Format(dtDatos.Rows(0).Item("fecha"), "dd/MM/yyyy hh:mm:ss tt")
                txtTelefono.Text = dtDatos.Rows(0).Item("telefono")
                txtDescripcion.Text = dtDatos.Rows(0).Item("descripcion")
                txtConclusion.Text = dtDatos.Rows(0).Item("conclusion")

                sCliente = dtDatos.Rows(0).Item("cliente").ToString().Trim()
                sVendedor = dtDatos.Rows(0).Item("vendedor").ToString().Trim()

                nCliente = dtDatos.Rows(0).Item("nCliente").ToString().Trim()
                nVendedor = dtDatos.Rows(0).Item("nVendedor").ToString().Trim()

                If Not dtDatos.Rows(0).Item("soporte") Is DBNull.Value Then
                    txtSoporteVta.Text = dtDatos.Rows(0).Item("soporte")
                End If

                If Not dtDatos.Rows(0).Item("correo") Is DBNull.Value Then
                    txtCorreo.Text = dtDatos.Rows(0).Item("correo")
                End If

                ddlCliente.Items.Clear()
                ddlCliente.Items.Add(New ListItem(nCliente, sCliente))

                ddlVendedor.Items.Clear()
                ddlVendedor.Items.Add(New ListItem(nVendedor, sVendedor))

                ddlVentas.SelectedValue = dtDatos.Rows(0).Item("ventas").ToString().Trim()

                'ddlPlanta.Items.Clear()
                'ddlPlanta.Items.Add(dtDatos.Rows(0).Item("planta"))

                'txtCodProd.Text = dtDatos.Rows(0).Item("producto").ToString().ToUpper()
                'Dim dtDatoProd As DataTable = clsReclamaciones.getProducto(dtDatos.Rows(0).Item("producto"))
                'If dtDatoProd.Rows.Count > 0 Then txtNameProducto.Text = dtDatoProd.Rows(0).Item(1)

                If dtDatos.Rows(0).Item("fecha_close") Is DBNull.Value Then
                    txtCerradaFecha.Text = ""
                Else
                    txtCerradaFecha.Text = Format(dtDatos.Rows(0).Item("fecha_close"), "dd/MM/yyyy hh:mm:ss tt")
                End If

                If dtDatos.Rows(0).Item("area") Is DBNull.Value Then
                    lblArea.Visible = False
                    ddlAreas.Visible = False
                Else
                    ddlAreas.SelectedValue = dtDatos.Rows(0).Item("area")
                End If

                If dtDatos.Rows(0).Item("motivo") Is DBNull.Value Then
                    lblMotivo.Visible = False
                    ddlMotivos.Visible = False
                    btnAgregarMotivoFast.Visible = False
                Else
                    ddlMotivos.SelectedValue = dtDatos.Rows(0).Item("motivo")
                End If

                'NUEVOS CAMPOS AGOSTO 2014
                If dtDatos.Rows(0).Item("monto") Is DBNull.Value Then
                    txtMonto.Visible = False
                    lblMonto.Visible = False
                Else
                    txtMonto.Text = FormatNumber(dtDatos.Rows(0).Item("monto"), 2)
                End If

                If dtDatos.Rows(0).Item("nc_nd") Is DBNull.Value Then
                    txtNCND.Visible = False
                    lblNCND.Visible = False
                Else
                    txtNCND.Text = dtDatos.Rows(0).Item("nc_nd")
                End If

                If dtDatos.Rows(0).Item("moneda") Is DBNull.Value Then
                    ddlMoneda.Visible = False
                    lblMoneda.Visible = False
                Else
                    ddlMoneda.Text = dtDatos.Rows(0).Item("moneda")
                End If

                If dtDatos.Rows(0).Item("cantidad") Is DBNull.Value Then
                    txtCantidad.Visible = False
                    lblCantidad.Visible = False
                    ddlMetrica.Visible = False
                    lblMetrica.Visible = False
                Else
                    txtCantidad.Text = FormatNumber(dtDatos.Rows(0).Item("cantidad"), 2)
                    ddlMetrica.Text = Trim(dtDatos.Rows(0).Item("metrica"))
                End If

                If dtDatos.Rows(0).Item("clase_doc") Is DBNull.Value Then
                    ddlClaseDoc.Visible = False
                    lblClaseDoc.Visible = False
                Else
                    ddlClaseDoc.Text = Trim(dtDatos.Rows(0).Item("clase_doc"))
                End If
                '***************************

                'NUEVA MODIFICACION **NOVIEMBRE 2011
                If Session.Item("nivel").ToString() = 2 And txtConclusion.Text.Length < 1 Then
                    btnGDescrp.Visible = True
                    txtDescripcion.ReadOnly = False
                End If

                'NUEVA MODIFICACION **MAYO 2016
                ddlChoferes.SelectedValue = dtDatos.Rows(0).Item("chofer").ToString().Trim()
                ddlTransportista.SelectedValue = dtDatos.Rows(0).Item("transportista").ToString().Trim()

            End If

            'CONCLUSION
            If Session.Item("nivel").ToString().Trim() = 2 And
            lblStatus.Text.Trim() <> "CERRADA" Then
                btnCerrar.Visible = True
                txtConclusion.ReadOnly = False

                lblMotivo.Visible = True
                ddlMotivos.Visible = True
                btnAgregarMotivoFast.Visible = True

                lblArea.Visible = True
                ddlAreas.Visible = True

                lblMonto.Visible = True
                txtMonto.Visible = True

                lblNCND.Visible = True
                txtNCND.Visible = True

                lblMoneda.Visible = True
                ddlMoneda.Visible = True

                txtMonto.ReadOnly = False
                txtNCND.ReadOnly = False
                ddlMoneda.Enabled = True

                txtCantidad.ReadOnly = False
                txtCantidad.Visible = True
                lblCantidad.Visible = True

                lblMetrica.Visible = True
                ddlMetrica.Visible = True
                ddlMetrica.Enabled = True

                lblClaseDoc.Visible = True
                ddlClaseDoc.Visible = True
                ddlClaseDoc.Enabled = True

                ddlAreas.Enabled = True
                ddlMotivos.Enabled = True

                'PARA INVOLUCRAR MAS USUARIOS
                lblInvolucradosUsr.Visible = True
                panelUsrInvolucrados.Visible = True
                btnInvolucrar.Visible = True
                getUsuariosInv(iReclamacion)
                '****************************

                ddlTipoDoc.Enabled = True

            Else
                ddlTipoDoc.Enabled = False

                ddlAreas.Enabled = False
                ddlMotivos.Enabled = False
                txtDescripcion.ReadOnly = True
                txtMonto.ReadOnly = True
                txtNCND.ReadOnly = True
                ddlMoneda.Enabled = False

                txtCantidad.ReadOnly = True
                ddlMetrica.Enabled = False
                ddlClaseDoc.Enabled = False
            End If
            '--CONCLUSION

        Else
            'RECLAMACION NUEVA
            imgbtnRefresh.Attributes.Add("onload", "conclusion2Area.style.display='none';conclusion3Area.style.display='none';")

            If Not Session.Item("nivel").ToString().Trim() = 2 Then Response.Redirect("ListaReclamaciones.aspx")

            lblNoReclamacion.Text = Right("00000000" & clsReclamaciones.getUltimaReclamacion(), 8)

            lblDeptosInvolucrados.Visible = False
            Accordion1.Visible = False
            btnVerComentarios.Visible = False
            panelUsrInvolucrados.Visible = True
            lblInvolucradosUsr.Visible = True

            'CONCLUSION
            lblConclusion.Visible = False
            txtConclusion.Visible = False
            lblArea.Visible = False
            ddlAreas.Visible = False
            lblMotivo.Visible = False
            ddlMotivos.Visible = False
            btnAgregarMotivoFast.Visible = False
            panelConclusion.Visible = False

            lblMonto.Visible = False
            txtMonto.Visible = False
            lblNCND.Visible = False
            txtNCND.Visible = False
            lblMoneda.Visible = False
            ddlMoneda.Visible = False

            lblCantidad.Visible = False
            txtCantidad.Visible = False
            lblMetrica.Visible = False
            ddlMetrica.Visible = False

            lblClaseDoc.Visible = False
            ddlClaseDoc.Visible = False
            '--CONCLUSION

            getUsuariosInvLB(ddlGruposF.SelectedValue)
        End If

    End Sub


    Protected Sub btnAgregarUsr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarUsr.Click
        Dim bExiste As Boolean = False

        Try
            For Each pItem As ListItem In lbUsuarios.Items
                bExiste = False
                If pItem.Selected Then
                    For Each xpItem As ListItem In lbUsrInvolucrados.Items
                        If xpItem.Text = pItem.Text Then
                            bExiste = True
                        End If
                    Next

                    If bExiste = False Then
                        lbUsrInvolucrados.Items.Add(pItem)
                    End If
                End If
            Next

            lbUsuarios.ClearSelection()
            For Each pItem As ListItem In lbUsrInvolucrados.Items
                lbUsuarios.Items.Remove(pItem)
            Next
            lbUsrInvolucrados.SelectedIndex = lbUsrInvolucrados.Items.Count

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnQuitarUsr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarUsr.Click
        Try

            For Each pItem As ListItem In lbUsrInvolucrados.Items
                If pItem.Selected Then
                    lbUsuarios.Items.Add(pItem)
                End If
            Next

            lbUsrInvolucrados.ClearSelection()
            For Each pItem As ListItem In lbUsuarios.Items
                lbUsrInvolucrados.Items.Remove(pItem)
            Next
            lbUsuarios.SelectedIndex = lbUsuarios.Items.Count

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Try
            If txtConclusion.Text.Trim() = String.Empty Then Throw New Exception("Debe escribir una conclusión para cerrar la reclamación.")
            If ddlAreas.SelectedIndex = 0 Then Throw New Exception("Debe seleccionar el AREA para cerrar la reclamación.")
            If ddlMotivos.SelectedIndex = 0 Then Throw New Exception("Debe seleccionar un MOTIVO para cerrar la reclamación.")
            'If ddlMetrica.SelectedIndex = 0 Then Throw New Exception("Debe seleccionar la METRICA para cerrar la reclamación.")
            'If ddlClaseDoc.SelectedIndex = 0 Then Throw New Exception("Debe seleccionar la CLASE DE DOCUMENTO para cerrar la reclamación.")

            If txtCantidad.Text.Trim() = String.Empty Or txtMonto.Text.Trim() = String.Empty Then
                txtCantidad.Text = "0"
                txtMonto.Text = "0"
            End If

            clsReclamaciones.closeReclamacion(Val(lblNoReclamacion.Text),
                                                txtConclusion.Text.Trim(),
                                                ddlAreas.SelectedValue,
                                                ddlMotivos.SelectedValue,
                                                txtMonto.Text,
                                                txtNCND.Text,
                                                ddlMoneda.SelectedValue,
                                                txtCantidad.Text,
                                                ddlMetrica.SelectedValue,
                                                ddlClaseDoc.SelectedValue)

            Try
                EnviaCorreoConclusion()
                EnviaCorreoNuevoInvolucradosVENDEDORES(txtConclusion.Text, " CERRADA")
            Catch ex As Exception
                lblMensaje.Text = ex.Message
                clsReclamaciones.EnviaCorreoException("Exception in Close Reclamacion", ex.ToString())
            End Try
            
            Response.Redirect("Reclamacion.aspx?id=" & Val(lblNoReclamacion.Text))

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnBProd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBProd.Click
        lblMensaje.Text = String.Empty

        Try
            Dim dato As DataTable = clsReclamaciones.getProductoERP(txtCodProd.Text)

            If dato.Rows.Count > 0 Then
                txtNameProducto.Text = dato.Rows(0).Item("descripcion")
                lblMensaje.Text = ""
            Else
                lblMensaje.Text = "No se encuentra el producto. Verifique que digito el código correcto."
            End If

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try

    End Sub

    Protected Sub btnInvolucrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvolucrar.Click
        Try
            Dim paramReclamacion As Integer = Val(lblNoReclamacion.Text)
            UsuariosReclamacion()
            getUsuariosInv(paramReclamacion)
            lblInvolucradosMsg.Text = "Ya los usuarios fueron involucrados en esta reclamación!"
            lblInvolucradosMsg.Visible = True

            MostrarUsuariosInv(paramReclamacion)
            lbUsrInvolucrados.Items.Clear()

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub

    'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM VENTAS
    Protected Sub btnAgregarFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFileV.Click
        Try
            If fuFileV.PostedFile.FileName.Trim() <> String.Empty Then GuardaFilePath(fuFileV, "Ventas") Else Exit Try

            arrFiles.Add(fuFileV.PostedFile.FileName)

            LiteralFileV.Text &= "<a Class=""LetraFiles"" href=""Adjuntos/Ventas/" & fuFileV.FileName & """ target=""_blank"" > " & fuFileV.FileName & "</a> |"
            iFiles += 1

            If arrFiles.Count > 0 Then btnEliminarAdjV.Visible = True

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub


    Protected Sub dlVentas_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlVentas.ItemDataBound

        Dim dtArchivos As New DataTable
        Dim deptoVentas As Integer = Integer.Parse(ConfigurationManager.AppSettings.Get("deptoVENTAS"))

        dtArchivos = clsReclamaciones.getArchivos(deptoVentas, Integer.Parse(CType(e.Item.FindControl("idcom"), Label).Text))

        If dtArchivos.Rows.Count > 0 Then
            CType(e.Item.FindControl("lFiles"), Literal).Text = "<div Class=""LetraFiles""><b>Adjuntos:</b>"
            For Each row As DataRow In dtArchivos.Rows
                CType(e.Item.FindControl("lFiles"), Literal).Text &= " <a Class=""LetraFiles"" href=""Adjuntos/Ventas/" & row.Item("filen") & """ target=""_blank"" > " & row.Item("filen") & "</a> |"
            Next
            CType(e.Item.FindControl("lFiles"), Literal).Text &= "</div>"
        End If
    End Sub


    Protected Sub btnEliminarAdj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarAdjV.Click
        CleanVentas()
        DeleteFilesPath(arrFiles, "Ventas")
        btnEliminarAdjV.Visible = False
    End Sub

    'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM PRODUCCION
    Protected Sub btnAgregarFileP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFileP.Click
        Try
            If fuFileP.PostedFile.FileName.Trim() <> String.Empty Then GuardaFilePath(fuFileP, "Produccion") Else Exit Try

            arrFiles.Add(fuFileP.PostedFile.FileName)

            LiteralFileP.Text &= "<a Class=""LetraFiles"" href=""Adjuntos/Produccion/" & fuFileP.FileName & """ target=""_blank"" > " & fuFileP.FileName & "</a> |"
            iFiles += 1

            If arrFiles.Count > 0 Then btnEliminarAdjP.Visible = True

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Protected Sub dlProduccion_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlProduccion.ItemDataBound

        Dim dtArchivos As New DataTable
        Dim deptoProd As Integer = Integer.Parse(ConfigurationManager.AppSettings.Get("deptoPRODUCCION"))

        dtArchivos = clsReclamaciones.getArchivos(deptoProd, Integer.Parse(CType(e.Item.FindControl("idcom"), Label).Text))

        If dtArchivos.Rows.Count > 0 Then
            CType(e.Item.FindControl("lFilesP"), Literal).Text = "<div Class=""LetraFiles""><b>Adjuntos:</b>"
            For Each row As DataRow In dtArchivos.Rows
                CType(e.Item.FindControl("lFilesP"), Literal).Text &= " <a Class=""LetraFiles"" href=""Adjuntos/Produccion/" & row.Item("filen") & """ target=""_blank"" > " & row.Item("filen") & "</a> |"
            Next
            CType(e.Item.FindControl("lFilesP"), Literal).Text &= "</div>"
        End If
    End Sub

    Protected Sub btnEliminarAdjP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarAdjP.Click
        CleanProduccion()
        DeleteFilesPath(arrFiles, "Produccion")
        btnEliminarAdjP.Visible = False
    End Sub

    'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM LOGISTICA
    Protected Sub btnAgregarFileL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFileL.Click
        Try
            If fuFileL.PostedFile.FileName.Trim() <> String.Empty Then GuardaFilePath(fuFileL, "Logistica") Else Exit Try

            arrFiles.Add(fuFileL.PostedFile.FileName)

            LiteralFileL.Text &= "<a Class=""LetraFiles"" href=""Adjuntos/Logistica/" & fuFileL.FileName & """ target=""_blank"" > " & fuFileL.FileName & "</a> |"
            iFiles += 1

            If arrFiles.Count > 0 Then btnEliminarAdjL.Visible = True

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Protected Sub dlLogistica_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlLogistica.ItemDataBound

        Dim dtArchivos As New DataTable
        Dim deptoLogistica As Integer = Integer.Parse(ConfigurationManager.AppSettings.Get("deptoLOGISTICA"))

        dtArchivos = clsReclamaciones.getArchivos(deptoLogistica, Integer.Parse(CType(e.Item.FindControl("idcom"), Label).Text))

        If dtArchivos.Rows.Count > 0 Then
            CType(e.Item.FindControl("lFilesL"), Literal).Text = "<div Class=""LetraFiles""><b>Adjuntos:</b>"
            For Each row As DataRow In dtArchivos.Rows
                CType(e.Item.FindControl("lFilesL"), Literal).Text &= " <a Class=""LetraFiles"" href=""Adjuntos/Logistica/" & row.Item("filen") & """ target=""_blank"" > " & row.Item("filen") & "</a> |"
            Next
            CType(e.Item.FindControl("lFilesL"), Literal).Text &= "</div>"
        End If
    End Sub

    Protected Sub btnEliminarAdjL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarAdjL.Click
        CleanLogistica()
        DeleteFilesPath(arrFiles, "Logistica")
        btnEliminarAdjL.Visible = False
    End Sub

    'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM FINANZAS
    Protected Sub btnAgregarFileF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFileF.Click
        Try
            If fuFileF.PostedFile.FileName.Trim() <> String.Empty Then GuardaFilePath(fuFileF, "Finanzas") Else Exit Try

            arrFiles.Add(fuFileF.PostedFile.FileName)

            LiteralFileF.Text &= "<a Class=""LetraFiles"" href=""Adjuntos/Finanzas/" & fuFileF.FileName & """ target=""_blank"" > " & fuFileF.FileName & "</a> |"
            iFiles += 1

            If arrFiles.Count > 0 Then btnEliminarAdjF.Visible = True

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Protected Sub dlFinanzas_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlFinanzas.ItemDataBound

        Dim dtArchivos As New DataTable
        Dim deptoFinanzas As Integer = Integer.Parse(ConfigurationManager.AppSettings.Get("deptoFINANZAS"))

        dtArchivos = clsReclamaciones.getArchivos(deptoFinanzas, Integer.Parse(CType(e.Item.FindControl("idcom"), Label).Text))

        If dtArchivos.Rows.Count > 0 Then
            CType(e.Item.FindControl("lFilesF"), Literal).Text = "<div Class=""LetraFiles""><b>Adjuntos:</b>"
            For Each row As DataRow In dtArchivos.Rows
                CType(e.Item.FindControl("lFilesF"), Literal).Text &= " <a Class=""LetraFiles"" href=""Adjuntos/Finanzas/" & row.Item("filen") & """ target=""_blank"" > " & row.Item("filen") & "</a> |"
            Next
            CType(e.Item.FindControl("lFilesF"), Literal).Text &= "</div>"
        End If
    End Sub

    Protected Sub btnEliminarAdjF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarAdjF.Click
        CleanFinanzas()
        DeleteFilesPath(arrFiles, "Finanzas")
        btnEliminarAdjF.Visible = False
    End Sub

    'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM FINANZAS
    Protected Sub btnAgregarFileA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFileA.Click
        Try
            If fuFileA.PostedFile.FileName.Trim() <> String.Empty Then GuardaFilePath(fuFileA, "Auditoria") Else Exit Try

            arrFiles.Add(fuFileA.PostedFile.FileName)

            LiteralFileA.Text &= "<a Class=""LetraFiles"" href=""Adjuntos/Auditoria/" & fuFileA.FileName & """ target=""_blank"" > " & fuFileA.FileName & "</a> |"
            iFiles += 1

            If arrFiles.Count > 0 Then btnEliminarAdjA.Visible = True

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Protected Sub dlAuditoria_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlAuditoria.ItemDataBound

        Dim dtArchivos As New DataTable
        Dim deptoAuditoria As Integer = Integer.Parse(ConfigurationManager.AppSettings.Get("deptoAUDITORIA"))

        dtArchivos = clsReclamaciones.getArchivos(deptoAuditoria, Integer.Parse(CType(e.Item.FindControl("idcom"), Label).Text))

        If dtArchivos.Rows.Count > 0 Then
            CType(e.Item.FindControl("lFilesA"), Literal).Text = "<div Class=""LetraFiles""><b>Adjuntos:</b>"
            For Each row As DataRow In dtArchivos.Rows
                CType(e.Item.FindControl("lFilesA"), Literal).Text &= " <a Class=""LetraFiles"" href=""Adjuntos/Auditoria/" & row.Item("filen") & """ target=""_blank"" > " & row.Item("filen") & "</a> |"
            Next
            CType(e.Item.FindControl("lFilesA"), Literal).Text &= "</div>"
        End If
    End Sub

    Protected Sub btnEliminarAdjA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarAdjA.Click
        CleanAuditoria()
        DeleteFilesPath(arrFiles, "Auditoria")
        btnEliminarAdjA.Visible = False
    End Sub

    'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM CALIDAD
    Protected Sub btnAgregarFileC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFileC.Click
        Try
            If fuFileC.PostedFile.FileName.Trim() <> String.Empty Then GuardaFilePath(fuFileC, "Calidad") Else Exit Try

            arrFiles.Add(fuFileC.PostedFile.FileName)

            LiteralFileC.Text &= "<a Class=""LetraFiles"" href=""Adjuntos/Calidad/" & fuFileC.FileName & """ target=""_blank"" > " & fuFileC.FileName & "</a> |"
            iFiles += 1

            If arrFiles.Count > 0 Then btnEliminarAdjC.Visible = True

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Protected Sub dlCalidad_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlCalidad.ItemDataBound

        Dim dtArchivos As New DataTable
        Dim deptoCalidad As Integer = Integer.Parse(ConfigurationManager.AppSettings.Get("deptoCALIDAD"))

        dtArchivos = clsReclamaciones.getArchivos(deptoCalidad, Integer.Parse(CType(e.Item.FindControl("idcom"), Label).Text))

        If dtArchivos.Rows.Count > 0 Then
            CType(e.Item.FindControl("lFilesC"), Literal).Text = "<div Class=""LetraFiles""><b>Adjuntos:</b>"
            For Each row As DataRow In dtArchivos.Rows
                CType(e.Item.FindControl("lFilesC"), Literal).Text &= " <a Class=""LetraFiles"" href=""Adjuntos/Calidad/" & row.Item("filen") & """ target=""_blank"" > " & row.Item("filen") & "</a> |"
            Next
            CType(e.Item.FindControl("lFilesC"), Literal).Text &= "</div>"
        End If
    End Sub

    Protected Sub btnEliminarAdjC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarAdjC.Click
        CleanCalidad()
        DeleteFilesPath(arrFiles, "Calidad")
        btnEliminarAdjC.Visible = False
    End Sub

    'CLEANERS ATTACH FILE
    Private Sub CleanVentas()
        arrFiles = New ArrayList()
        LiteralFileV.Text = ""
    End Sub

    Private Sub CleanProduccion()
        arrFiles = New ArrayList()
        LiteralFileP.Text = ""
    End Sub

    Private Sub CleanLogistica()
        arrFiles = New ArrayList()
        LiteralFileL.Text = ""
    End Sub

    Private Sub CleanFinanzas()
        arrFiles = New ArrayList()
        LiteralFileF.Text = ""
    End Sub

    Private Sub CleanAuditoria()
        arrFiles = New ArrayList()
        LiteralFileA.Text = ""
    End Sub

    Private Sub CleanCalidad()
        arrFiles = New ArrayList()
        LiteralFileC.Text = ""
    End Sub

    Private Sub DeleteFilesPath(ByRef aFiles As ArrayList, ByVal area As String)
        For i As Integer = 0 To arrFiles.Count - 1
            File.Delete(MapPath("~\Adjuntos\" & area & "\" & Path.GetFileName(arrFiles(i))))
        Next
    End Sub

    Private Sub AgregarFile(ByVal icomentario As Integer, depto As Integer)

        For i As Integer = 0 To arrFiles.Count - 1
            clsReclamaciones.setArchivo(arrFiles(i), Path.GetFileName(arrFiles(i)), depto,
            Val(lblNoReclamacion.Text), icomentario)
        Next

    End Sub

    Private Sub GuardaFilePath(ByRef pFile As FileUpload, ByVal area As String)
        pFile.SaveAs(MapPath("~\Adjuntos\" & area & "\" & pFile.FileName))
    End Sub

    Protected Sub imgbtnPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnPrint.Click
        Dim rptReportGRC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        Try
            rptReportGRC.FileName = MapPath("~\Reportes" & "\ReclamacionTotal.rpt")

            Dim strParamName() As String = {"@id_reclamacion"}
            Dim strParamValues() As String = {lblNoReclamacion.Text}
            Response.Redirect(PrintReport(rptReportGRC, strParamName, strParamValues, "\PDFs\Reclamacion" & Val(lblNoReclamacion.Text) & ".pdf"))

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Public Function PrintReport(ByVal ReportName As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal ParamName() As String, ByVal ParamValues() As String, ByVal paramPDF As String) As String

        Dim MyReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = ReportName
        Dim Field As CrystalDecisions.Shared.ParameterValues
        Dim Value As CrystalDecisions.Shared.ParameterDiscreteValue

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionDetalle(Val(lblNoReclamacion.Text)))
        MyReportDocument.Subreports(6).SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 5))
        MyReportDocument.Subreports(4).SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 1))
        MyReportDocument.Subreports(3).SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 2))
        MyReportDocument.Subreports(2).SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 3))
        MyReportDocument.Subreports(1).SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 4))
        MyReportDocument.Subreports(5).SetDataSource(clsReclamaciones.getUsrEstanReclamacion(Val(lblNoReclamacion.Text)))
        MyReportDocument.Subreports(0).SetDataSource(clsReclamaciones.getReclamacionDetalle(Val(lblNoReclamacion.Text)))

        'MyReportDocument.Subreports("Reclamacion.rpt").SetDataSource(clsReclamaciones.getReclamacionDetalle(Val(lblNoReclamacion.Text)))
        'MyReportDocument.Subreports("ComentariosV.rpt").SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 1))
        'MyReportDocument.Subreports("ComentariosP.rpt").SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 2))
        'MyReportDocument.Subreports("ComentariosL.rpt").SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 3))
        'MyReportDocument.Subreports("ComentariosF.rpt").SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 4))
        'MyReportDocument.Subreports("ComentariosC.rpt").SetDataSource(clsReclamaciones.getComentarios(Val(lblNoReclamacion.Text), 5))

        If Not ParamName Is Nothing Then
            For i As Integer = 0 To ParamName.Length - 1
                Field = New CrystalDecisions.Shared.ParameterValues
                Value = New CrystalDecisions.Shared.ParameterDiscreteValue
                Value.Value = ParamValues(i)
                Field.Add(Value)
                MyReportDocument.DataDefinition.ParameterFields(ParamName(i)).ApplyCurrentValues(Field)
            Next
        End If

        CrExportOptions = MyReportDocument.ExportOptions
        CrDiskFileDestinationOptions.DiskFileName = MapPath("~\Reportes" & paramPDF)

        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With

        MyReportDocument.Export()

        Return "~\Reportes" & paramPDF

    End Function

    Public Function PrintReportTC(ByVal ReportName As CrystalDecisions.CrystalReports.Engine.ReportDocument,
    ByVal paramPDF As String, ByVal pContacto As String, ByVal pCliente As String) As String

        Dim MyReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = ReportName

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionToCliente(Right(lblNoReclamacion.Text, 8)))
        MyReportDocument.DataDefinition.FormulaFields("Contacto").Text = """" & pContacto & """"
        MyReportDocument.DataDefinition.FormulaFields("cCliente").Text = """" & pCliente & """"

        CrExportOptions = MyReportDocument.ExportOptions
        CrDiskFileDestinationOptions.DiskFileName = MapPath("~\Reportes" & paramPDF)


        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With

        MyReportDocument.Export()

        Return "~\Reportes" & paramPDF

    End Function

    Private Sub CleanProd()
        txtCodProd.Text = String.Empty
        txtNameProducto.Text = String.Empty
        txtCodProd.Focus()
    End Sub

    Protected Sub btnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub imgbtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnRefresh.Click

        Try
            updateProductos()

            fillProductos(Val(lblNoReclamacion.Text), False)

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try

    End Sub

    Protected Sub btnGDescrp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGDescrp.Click
        Try
            clsReclamaciones.guardaDescrpRecl(lblNoReclamacion.Text, txtDescripcion.Text)
        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub

    Protected Sub ddlGruposF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            getUsuariosInvLB(ddlGruposF.SelectedValue)
        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub

    Protected Sub btnReportToClient_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReportToClient.Click
        Dim rptReportTC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Dim contacto As String
        Dim cliente As String
        Dim archivoPDF As String


        Try
            'If Not txtSoporteVta.Text = String.Empty Then
            'contacto = txtSoporteVta.Text
            'Else
            contacto = ddlVendedor.SelectedItem.Text
            'End If

            If Not txtContacto.Text = String.Empty Then
                cliente = txtContacto.Text
            Else
                cliente = ddlCliente.SelectedItem.Text
            End If

            rptReportTC.FileName = MapPath("~\Reportes" & "\ReporteACliente.rpt")

            archivoPDF = PrintReportTC(rptReportTC, "\PDFs\ReporteACliente.pdf", contacto, cliente)

            Response.Redirect(archivoPDF)

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub


    Protected Sub btnEnviarMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarMail.Click
        Dim rptReportTC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Dim contacto As String
        Dim cliente As String
        Dim archivoPDF As String

        Try
            If Not txtSoporteVta.Text = String.Empty Then
                contacto = txtSoporteVta.Text
            Else
                contacto = ddlVendedor.SelectedItem.Text
            End If

            If Not txtContacto.Text = String.Empty Then
                cliente = txtContacto.Text
            Else
                cliente = ddlCliente.SelectedItem.Text
            End If

            rptReportTC.FileName = MapPath("~\Reportes" & "\ReporteACliente.rpt")

            archivoPDF = PrintReportTC(rptReportTC, "\PDFs\" & lblNoReclamacion.Text & ".pdf", contacto, cliente)

            If txtCorreo.Text.Length = 0 Then Throw New Exception("No existe correo para enviar la carta.")

            EnviaCorreoCarta(txtCorreo.Text, MapPath(archivoPDF))
            lblMensaje.Text = "El correo con la carta fue generado."

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnSaveMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveMail.Click
        Try
            clsReclamaciones.guardaCorreo(lblNoReclamacion.Text, txtCorreo.Text)
        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim obj As ImageButton = sender

        Try
            If grdProdReclam.Rows.Count > 1 Then
                clsReclamaciones.delProducto(Integer.Parse(obj.CommandArgument))
                fillProductos(Val(lblNoReclamacion.Text))

            Else
                Throw New Exception("Debe al menos tener un producto en la reclamación.")
            End If

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Protected Sub imgbtnGuardarComentProd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim obj As ImageButton = sender

        Try
            For Each row As GridViewRow In grdProdReclam.Rows
                Dim idp As ImageButton = row.Cells(3).Controls(0).FindControl("imgbtnQuitarProd")
                Dim strp As String = idp.CommandArgument

                If strp = obj.CommandArgument Then
                    Dim coment As String = CType(row.Cells(2).Controls(0).FindControl("txtComentProd"), TextBox).Text
                    clsReclamaciones.setComentProd(strp, coment)
                End If
            Next

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub
    Protected Sub btnAgregarMotivoFast_Click(sender As Object, e As EventArgs) Handles btnAgregarMotivoFast.Click

        txtMotivoFast.Visible = True
        btnGuardarMotivoFast.Visible = True
        btnAgregarMotivoFast.Visible = False

    End Sub
    Protected Sub btnGuardarMotivoFast_Click(sender As Object, e As EventArgs) Handles btnGuardarMotivoFast.Click
        Try
            clsReclamaciones.insertMotivo(txtMotivoFast.Text.Trim(), "0")

            fillMotivos()

            btnGuardarMotivoFast.Visible = False
            txtMotivoFast.Visible = False

            ddlMotivos.SelectedItem.Text = txtMotivoFast.Text
        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()
        End Try
    End Sub
    Protected Sub btnVerComentarios_Click(sender As Object, e As EventArgs) Handles btnVerComentarios.Click

        If Accordion1.Visible = True Then
            Accordion1.Visible = False
            grdComentariosCron.Visible = True
            btnVerComentarios.Text = "Comentarios en orden cronológico"
        Else
            Accordion1.Visible = True
            grdComentariosCron.Visible = False
            btnVerComentarios.Text = "Comentarios por departamento"
        End If
    End Sub

    Protected Sub btnSelProductos_Click(sender As Object, e As EventArgs) Handles btnSelProductos.Click

        If grdProdReclam.Rows.Count > 0 Then

            For Each row As GridViewRow In grdProdReclam.Rows

                CType(row.Cells(0).FindControl("chkProd"), CheckBox).Checked = IIf(btnSelProductos.Text = "Seleccionar todos", True, False)

            Next

            btnSelProductos.Text = IIf(btnSelProductos.Text = "Seleccionar todos", "Deseleccionar todos", "Seleccionar todos")

        End If

    End Sub

    Protected Sub btnAgregarProd_Click(sender As Object, e As EventArgs) Handles btnAgregarProd.Click
        Try
            btnBProd_Click(Nothing, Nothing)

            If Not txtNameProducto.Text.Trim() = String.Empty Then
                clsReclamaciones.adProductoRecl(Val(lblNoReclamacion.Text), txtCodProd.Text.Trim().ToUpper())
                fillProductos(Val(lblNoReclamacion.Text))
                CleanProd()
                lblMensProd.Visible = False
            Else
                lblMensProd.Visible = True
            End If

        Catch ex As Exception
            lblMensaje.Text = "Exception details: " & ex.ToString()

        End Try
    End Sub

    Public Function getTemplateForCartaCte() As String

        Dim receiptTemplate As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates/")

        Dim htmlTemplate = System.IO.Path.Combine(receiptTemplate, "TemplateEmailCte.html")
        Dim Content = System.IO.File.ReadAllText(htmlTemplate)

        Return Content
    End Function

    Protected Sub rbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbFactura.CheckedChanged
        fillTiposFacturas()
    End Sub

    Protected Sub rbPedido_CheckedChanged(sender As Object, e As EventArgs) Handles rbPedido.CheckedChanged
        fillTiposPedidos()
    End Sub

End Class