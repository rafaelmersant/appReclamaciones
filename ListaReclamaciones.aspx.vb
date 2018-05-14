Imports System.Data

Partial Class ListaReclamaciones
    Inherits System.Web.UI.Page

    
    Private Sub fillMotivos()
        Dim dtDatos As DataTable = clsReclamaciones.getMotivos()
        ddlMotivos.DataSource = dtDatos
        ddlMotivos.DataTextField = "descripcion"
        ddlMotivos.DataValueField = "id_motivo"
        ddlMotivos.DataBind()

    End Sub

    Private Sub fillAreas()
        Dim dtDatos As DataTable = clsReclamaciones.getAreas()
        ddlAreas.DataSource = dtDatos
        ddlAreas.DataTextField = "area"
        ddlAreas.DataValueField = "id_area"
        ddlAreas.DataBind()

    End Sub

    Private Sub fillChoferes(ByVal chofer As String)
        Dim dtDatos As DataTable = clsReclamaciones.getChofer(chofer).Tables(0)

        ddlChofer.DataSource = dtDatos
        ddlChofer.DataTextField = "NOMBRE_CLIENTE"
        ddlChofer.DataValueField = "COD_CLIENTE"
        ddlChofer.DataBind()

        ddlChofer.Items.Insert(0, New ListItem("...", ""))

    End Sub

    Private Sub fillTransportistas(ByVal suplidor As String)
        Dim dtDatos As DataTable = clsReclamaciones.getTransportista(suplidor).Tables(0)

        ddlTransportista.DataSource = dtDatos
        ddlTransportista.DataTextField = "NOMBRE_SUPLIDOR"
        ddlTransportista.DataValueField = "COD_SUPLIDOR"
        ddlTransportista.DataBind()

        ddlTransportista.Items.Insert(0, New ListItem("...", ""))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("usuario") <> String.Empty Then Response.Redirect("Login.aspx")

        clsReclamaciones.TieButton(Page, txtNoReclamacion, btnBuscaReclam)
        clsReclamaciones.TieButton(Page, txtDescrp, imgbtnBDescrp)
        clsReclamaciones.TieButton(Page, txtCliente, imgbtnBCliente)

        imgUtil.Attributes.Add("onload", "porfecha.style.display='none';pordescrp.style.display='none'; pornumero.style.display='none';porcliente.style.display='none';" & _
        " pormotivo.style.display='none';porarea.style.display='none'; porfactura.style.display='none'; porchofer.style.display='none'; portransportista.style.display='none';" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Fecha') {porfecha.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Numero') {pornumero.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Cliente') {porcliente.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Motivo') {pormotivo.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Area') {porarea.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Factura') {porfactura.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Descripcion') {pordescrp.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Chofer') {porchofer.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Transportista') {portransportista.style.display='';}")

        ddlBuscaPor.Attributes.Add("onchange", "porfecha.style.display='none';pordescrp.style.display='none'; pornumero.style.display='none';porcliente.style.display='none';" & _
        " pormotivo.style.display='none';porarea.style.display='none'; porfactura.style.display='none'; porchofer.style.display='none'; portransportista.style.display='none';" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Fecha') {porfecha.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Numero') {pornumero.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Cliente') {porcliente.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Motivo') {pormotivo.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Area') {porarea.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Factura') {porfactura.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Descripcion') {pordescrp.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Chofer') {porchofer.style.display='';}" & _
          "if(" & ddlBuscaPor.UniqueID & ".value == 'Transportista') {portransportista.style.display='';}")

        If Not Page.IsPostBack() Then
            Dim usuarios As String = ConfigurationManager.AppSettings.Get("UsrsToExcel")

            Try
                txtFechaI.Text = Format(Now.Date.AddMonths(-1), "MM/dd/yyyy")
                txtFechaF.Text = Format(Now.Date, "MM/dd/yyyy")
                listaReclamaciones()

                fillMotivos()
                fillAreas()

                fillChoferes("")
                fillTransportistas("")

                If Session.Item("nivel") = 2 Then
                    btnNuevaRecl.Visible = True
                End If

                ''If usuarios.Contains(User.Identity.Name.Substring(5)) = True Then
                btnToExcel.Visible = True
                ''End If

            Catch exq As SqlClient.SqlException
                lblMensaje.Text = exq.Message

            Catch ex As Exception
                lblMensaje.Text = ex.Message
            End Try

        End If
    End Sub

    Private Sub listaReclamaciones()
        
        Dim dtDatos As DataTable = clsReclamaciones.getReclamaciones(Session.Item("usuario")).Tables(0)

        grdReclamaciones.DataSource = dtDatos
        grdReclamaciones.DataBind()

        'setNameClientesSAP()

        If dtDatos.Rows.Count > 0 Then lblNoExiste.Visible = False Else lblNoExiste.Visible = True
        Colorea()
    End Sub

    Private Sub listaReclamacionesForExcel()
        Dim dtDatos As DataTable = clsReclamaciones.getReclamacionesForExcel(Session.Item("usuario")).Tables(0)

        grdReclamaciones.DataSource = dtDatos
        grdReclamaciones.DataBind()

        'setNameClientesSAP()

        If dtDatos.Rows.Count > 0 Then lblNoExiste.Visible = False Else lblNoExiste.Visible = True
        Colorea()
    End Sub

    'Private Sub setNameClientesSAP()
    'Dim cte() As String
    'Dim i As Integer = 0

    '    cte = New String(grdReclamaciones.Rows.Count - 1) {}

    '    For Each row As GridViewRow In grdReclamaciones.Rows
    '        cte(i) = CType(row.FindControl("lblCod_Cte"), Label).Text.Trim()
    '        i += 1
    '    Next

    '    findNameFromSAP_Cte(cte)
    'End Sub

    'CHANGE THIS WITH NEW STATEMENTS FOR TERMOPAC
    'Private Sub findNameFromSAP_Cte(ByVal pCte() As String)
    'Dim clientes() As wsClientes.ZsdCliente = clsReclamaciones.getClientesSAP(pCte)

    '    For Each row As GridViewRow In grdReclamaciones.Rows
    '        For x As Integer = 0 To clientes.Length - 1
    '            If Right("0000000000" & clientes(x).Kunnr, 10) = Right("0000000000" & CType(row.FindControl("lblCod_Cte"), Label).Text.Trim(), 10) _
    '            Or (Not IsNumeric(Left(clientes(x).Kunnr, 1)) And clientes(x).Kunnr = "ES0" & CType(row.FindControl("lblCod_Cte"), Label).Text.Trim()) Then
    '                CType(row.FindControl("lblNombre_Cte"), Label).Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(clientes(x).Name1.ToLower())
    '            End If
    '        Next
    '    Next
    'End Sub

    Private Sub Colorea()
        For Each row As GridViewRow In grdReclamaciones.Rows
            Dim dias As String = row.Cells(1).Text.Substring(row.Cells(1).Text.IndexOf("+") + 1)
            If Val(dias) >= 15 Then
                grdReclamaciones.Rows(row.RowIndex).BackColor = Drawing.Color.Firebrick
                grdReclamaciones.Rows(row.RowIndex).Cells(0).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(0).Font.Bold = True
                grdReclamaciones.Rows(row.RowIndex).Cells(1).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(1).Font.Bold = True
                grdReclamaciones.Rows(row.RowIndex).Cells(2).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(2).Font.Bold = True
                grdReclamaciones.Rows(row.RowIndex).Cells(3).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(3).Font.Bold = True
                grdReclamaciones.Rows(row.RowIndex).Cells(4).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(4).Font.Bold = True
                grdReclamaciones.Rows(row.RowIndex).Cells(5).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(5).Font.Bold = True
                grdReclamaciones.Rows(row.RowIndex).Cells(6).ForeColor = Drawing.Color.White
                grdReclamaciones.Rows(row.RowIndex).Cells(6).Font.Bold = True

                CType(row.FindControl("lblNombre_Cte"), Label).ForeColor = Drawing.Color.White
                CType(row.FindControl("lblNombre_Cte"), Label).Font.Bold = True
            End If
        Next
    End Sub

    Private Sub getReclamacionFechaForExcel()
        Dim dtDatos As New DataSet

        lblMensaje.Text = ""

        Dim fechi() As String = txtFechaI.Text.Split("/")
        Dim fechf() As String = txtFechaF.Text.Split("/")

        Dim FI As DateTime = New DateTime(fechi(2), fechi(0), fechi(1))
        Dim FF As DateTime = New DateTime(fechf(2), fechf(0), fechf(1))

        grdReclamaciones.DataSource = clsReclamaciones.getReclamacionByFechaToExcel(Format(FI, "MM/dd/yyyy"), Format(FF, "MM/dd/yyyy"), ddlEstatus.SelectedValue, ddlVentas.SelectedValue, Session.Item("usuario")).Tables(0)
        grdReclamaciones.DataBind()

    End Sub

    Private Sub getReclamacionClienteForExcel()
        Dim dtDatos As New DataSet

        lblMensaje.Text = ""

        grdReclamaciones.DataSource = clsReclamaciones.getReclamacionByClienteToExcel(txtCliente.Text, Session.Item("usuario")).Tables(0)
        grdReclamaciones.DataBind()

    End Sub

    Private Sub getReclamacionMotivoForExcel()
        Dim dtDatos As New DataSet

        lblMensaje.Text = ""

        Dim fechi() As String = txtFechaIM.Text.Split("/")
        Dim fechf() As String = txtFechaFM.Text.Split("/")

        Dim FI As DateTime = New DateTime(fechi(2), fechi(0), fechi(1))
        Dim FF As DateTime = New DateTime(fechf(2), fechf(0), fechf(1))

        grdReclamaciones.DataSource = clsReclamaciones.getReclamacionByMotivoToExcel(ddlMotivos.SelectedValue, Session.Item("usuario"), Format(FI, "MM/dd/yyyy"), Format(FF, "MM/dd/yyyy")).Tables(0)
        grdReclamaciones.DataBind()

    End Sub

    Private Sub getReclamacionAreaForExcel()
        Dim dtDatos As New DataSet

        lblMensaje.Text = ""

        Dim fechi() As String = txtFechaIA.Text.Split("/")
        Dim fechf() As String = txtFechaFA.Text.Split("/")

        Dim FI As DateTime = New DateTime(fechi(2), fechi(0), fechi(1))
        Dim FF As DateTime = New DateTime(fechf(2), fechf(0), fechf(1))

        grdReclamaciones.DataSource = clsReclamaciones.getReclamacionByAreaToExcel(ddlAreas.SelectedValue, Session.Item("usuario"), Format(FI, "MM/dd/yyyy"), Format(FF, "MM/dd/yyyy")).Tables(0)
        grdReclamaciones.DataBind()

    End Sub

    Private Sub getReclamacion(ByVal por As Integer)
        Dim dtDatos As New DataTable

        lblMensaje.Text = ""

        Select Case por
            Case 1
                Dim fechi() As String = txtFechaI.Text.Split("/")
                Dim fechf() As String = txtFechaF.Text.Split("/")

                Dim FI As DateTime = New DateTime(fechi(2), fechi(0), fechi(1))
                Dim FF As DateTime = New DateTime(fechf(2), fechf(0), fechf(1))

                dtDatos = clsReclamaciones.getReclamacionByFecha(Format(FI, "MM/dd/yyyy"), Format(FF, "MM/dd/yyyy"), ddlEstatus.SelectedValue, ddlVentas.SelectedValue, Session.Item("usuario")).Tables(0)

                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 2
                dtDatos = clsReclamaciones.getReclamacion(Integer.Parse(txtNoReclamacion.Text), Session.Item("usuario")).Tables(0)

                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 3
                dtDatos = clsReclamaciones.getReclamacionByDescrp(txtDescrp.Text, Session.Item("usuario")).Tables(0)

                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 4 'CLIENTE
                dtDatos = clsReclamaciones.getReclamacionByCliente(txtCliente.Text, Session.Item("usuario")).Tables(0)

                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 5 'MOTIVO
                Dim fechi() As String = txtFechaIM.Text.Split("/")
                Dim fechf() As String = txtFechaFM.Text.Split("/")

                Dim FI As DateTime = New DateTime(fechi(2), fechi(0), fechi(1))
                Dim FF As DateTime = New DateTime(fechf(2), fechf(0), fechf(1))

                dtDatos = clsReclamaciones.getReclamacionByMotivo(ddlMotivos.SelectedValue, Session.Item("usuario"), Format(FI, "MM/dd/yyyy"), Format(FF, "MM/dd/yyyy")).Tables(0)
                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 6 'AREA
                Dim fechi() As String = txtFechaIA.Text.Split("/")
                Dim fechf() As String = txtFechaFA.Text.Split("/")

                Dim FI As DateTime = New DateTime(fechi(2), fechi(0), fechi(1))
                Dim FF As DateTime = New DateTime(fechf(2), fechf(0), fechf(1))

                dtDatos = clsReclamaciones.getReclamacionByArea(ddlAreas.SelectedValue, Session.Item("usuario"), Format(FI, "MM/dd/yyyy"), Format(FF, "MM/dd/yyyy")).Tables(0)

                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 7 'FACTURA

                dtDatos = clsReclamaciones.getReclamacionByFactura(txtFactura.Text, Session.Item("usuario")).Tables(0)
                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 8 'CHOFER

                dtDatos = clsReclamaciones.getReclamacionByChofer(ddlChofer.SelectedValue, Session.Item("usuario")).Tables(0)
                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If

            Case 9 'TRANSPORTISTA

                dtDatos = clsReclamaciones.getReclamacionByTransportista(ddlTransportista.SelectedValue, Session.Item("usuario")).Tables(0)
                If dtDatos.Rows.Count > 0 Then
                    grdReclamaciones.DataSource = dtDatos
                End If
        End Select

        grdReclamaciones.DataBind()
        Colorea()

        If dtDatos.Rows.Count < 1 Then
            lblNoExiste.Visible = True
        Else
            If dtDatos.Rows.Count > 0 Then lblNoExiste.Visible = False Else lblNoExiste.Visible = True
        End If

    End Sub

    Protected Sub btnVerRec_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim img As ImageButton = sender
            Response.Redirect("Reclamacion.aspx?id=" & img.CommandArgument)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub grdReclamaciones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdReclamaciones.PageIndexChanging
        grdReclamaciones.PageIndex = e.NewPageIndex

        If ddlBuscaPor.SelectedItem.Text = "Fecha" Then
            getReclamacion(1)
        Else
            listaReclamaciones()
        End If

    End Sub

    Protected Sub btnBuscaReclam_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscaReclam.Click

        Try
            getReclamacion(2)
            lblMensaje.Text = String.Empty

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgbtnBFecha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBFecha.Click

        Try
            getReclamacion(1)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgbtnBDescrp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBDescrp.Click
        Try
            getReclamacion(3)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub btnVerTodas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerTodas.Click
        listaReclamaciones()
    End Sub

    Protected Sub btnToExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnToExcel.Click
        Try
            lblMensaje.Text = String.Empty

            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 1).Visible = False

            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 2).Visible = True
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 3).Visible = True
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 4).Visible = True
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 5).Visible = True
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 6).Visible = True

            exportarxls(grdReclamaciones)

            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 1).Visible = True

            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 2).Visible = False
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 3).Visible = False
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 4).Visible = False
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 5).Visible = False
            grdReclamaciones.Columns(grdReclamaciones.Columns.Count - 6).Visible = False

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Public Sub exportarxls(ByRef grill As Object)
        'exporta a excel el grid view que se señalize al llamar el metodo mediante la variable grilla

        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form As New HtmlForm

        Dim grilla As GridView = grill

        grilla.EnableViewState = False
        grilla.AllowPaging() = False

        Select Case ddlBuscaPor.SelectedItem.Text
            Case "Fecha"
                getReclamacionFechaForExcel()
            Case "Cliente"
                getReclamacionClienteForExcel()
            Case "Motivo"
                getReclamacionMotivoForExcel()
            Case "Area"
                getReclamacionAreaForExcel()

            Case Else
                listaReclamacionesForExcel()
        End Select

        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)

        form.Controls.Add(grilla)

        pagina.RenderControl(htw)

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" & "reclamaciones" & ddlBuscaPor.SelectedValue & Environment.TickCount.ToString().Substring(1, 2) & ".xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()

        grilla.AllowPaging() = True

    End Sub

    Protected Sub imgbtnBCliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBCliente.Click
        Try
            getReclamacion(4)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgBtnBMotivo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnBMotivo.Click
        Try
            getReclamacion(5)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgbtnBArea_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnBArea.Click
        Try
            getReclamacion(6)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgbtnFactura_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnFactura.Click
        Try
            getReclamacion(7)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgbtnChofer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnChofer.Click
        Try
            getReclamacion(8)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub

    Protected Sub imgbtnTransportista_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnTransportista.Click
        Try
            getReclamacion(9)

        Catch ex As Exception
            lblMensaje.Text = ex.Message

        End Try
    End Sub
End Class
