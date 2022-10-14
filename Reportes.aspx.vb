Imports System.Diagnostics
Imports CrystalDecisions.Shared

Partial Class Reportes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("nivel") = 2 Then Response.Redirect("Login.aspx")
        lblMensaje.Text = String.Empty

        'ACCION DE LA IMAGEN imgUtil
        imgUtil.Attributes.Add("onload", "general.style.display='none';AreaMotivos.style.display='none';mas15dias.style.display='none';Excedidas.style.display='none'; RRM.style.display='none';" & _
         "if(" & ddlReporte.UniqueID & ".value == 'General') {general.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'Mensual') {window.location=PatronRptMensual.aspx;}" & _
         "if(" & ddlReporte.UniqueID & ".value == '15Dias') {mas15dias.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'AreaMotivos') {AreaMotivos.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'RRM') {RRM.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'Excedidas') {Excedidas.style.display='';}")

        'CUANDO SE ELIGE
        ddlReporte.Attributes.Add("onchange", "general.style.display='none';AreaMotivos.style.display='none';mas15dias.style.display='none';Excedidas.style.display='none'; RRM.style.display='none';" & _
         "if(" & ddlReporte.UniqueID & ".value == 'General') {general.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'Mensual') {window.location='PatronRptMensual.aspx';}" & _
         "if(" & ddlReporte.UniqueID & ".value == '15Dias') {mas15dias.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'Excedidas') {Excedidas.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'RRM') {RRM.style.display='';}" & _
         "if(" & ddlReporte.UniqueID & ".value == 'AreaMotivos') {AreaMotivos.style.display='';}")

    End Sub

    Public Function PrintReport(ByVal ReportName As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal ParamName() As String, ByVal ParamValues() As String, ByVal paramPDF As String, ByVal cual As Integer) As String

        Dim MyReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = ReportName
        Dim Field As CrystalDecisions.Shared.ParameterValues
        Dim Value As CrystalDecisions.Shared.ParameterDiscreteValue

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        Select Case cual
            Case 1
                MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRpt(txtFechaI.Text, txtFechaF.Text, ddlLocalidadGeneral.SelectedValue).Tables(0))
                MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaI.Text), "MM/dd/yyyy") & """"
                MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaF.Text), "MM/dd/yyyy") & """"
            Case 2
                MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRptAM(txtFechaIni.Text, txtFechaFin.Text, ddlLocalidadAreaMotivo.SelectedValue).Tables(0))
                MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaIni.Text), "MM/dd/yyyy") & """"
                MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaFin.Text), "MM/dd/yyyy") & """"
            Case 3
                MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRptAMC(txtFechaIni.Text, txtFechaFin.Text, ddlLocalidadAreaMotivo.SelectedValue).Tables(0))
                MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaIni.Text), "MM/dd/yyyy") & """"
                MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaFin.Text), "MM/dd/yyyy") & """"
            Case 4
                MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRpt15D().Tables(0))
            Case 5
                MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionesExcedidas(txtFechaIEx.Text, txtFechaFEx.Text, ddlLocalidad.SelectedValue).Tables(0))
                MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaIEx.Text), "MM/dd/yyyy") & """"
                MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaFEx.Text), "MM/dd/yyyy") & """"

        End Select

        ''If InStr(paramPDF, "Motivo") > 0 Then
        ''    If ddlporFecha.SelectedValue = "Abierta" Then
        ''        MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRptAM(txtFechaIni.Text, txtFechaFin.Text).Tables(0))
        ''        MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaIni.Text), "MM/dd/yyyy") & """"
        ''        MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaFin.Text), "MM/dd/yyyy") & """"
        ''    Else
        ''        MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRptAMC(txtFechaIni.Text, txtFechaFin.Text).Tables(0))
        ''        MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaIni.Text), "MM/dd/yyyy") & """"
        ''        MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaFin.Text), "MM/dd/yyyy") & """"
        ''    End If
        ''Else
        ''    MyReportDocument.SetDataSource(clsReclamaciones.getReclamacionRpt(txtFechaI.Text, txtFechaF.Text).Tables(0))
        ''    MyReportDocument.DataDefinition.FormulaFields(0).Text = """" & Format(Convert.ToDateTime(txtFechaI.Text), "MM/dd/yyyy") & """"
        ''    MyReportDocument.DataDefinition.FormulaFields(1).Text = """" & Format(Convert.ToDateTime(txtFechaF.Text), "MM/dd/yyyy") & """"
        ''End If

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

    Protected Sub btnVerReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerReporte.Click
        Dim rptReportGRC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        Try
            rptReportGRC.FileName = MapPath("~\Reportes" & "\rptGeneralRC.rpt")

            Dim strParamName() As String = {"@fechaI", "@fechaF"}
            Dim strParamValues() As String = {txtFechaI.Text, txtFechaF.Text}
            Response.Redirect(PrintReport(rptReportGRC, strParamName, strParamValues, "\PDFs\ReporteGeneralRC.pdf", 1))

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnprintam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprintam.Click
        Dim rptReportGRC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Dim sReport As String

        Try
            If ddlporFecha.SelectedValue = "Abierta" Then
                rptReportGRC.FileName = MapPath("~\Reportes" & "\rptAreaMotivo.rpt")
            Else
                rptReportGRC.FileName = MapPath("~\Reportes" & "\rptAreaMotivoCerradas.rpt")
            End If


            Dim strParamName() As String = {"@FechaI", "@FechaF"}
            Dim strParamValues() As String = {txtFechaIni.Text, txtFechaFin.Text}

            If ddlporFecha.SelectedValue = "Abierta" Then
                sReport = PrintReport(rptReportGRC, strParamName, strParamValues, "\PDFs\AreaMotivosRC.pdf", 2)
            Else
                sReport = PrintReport(rptReportGRC, strParamName, strParamValues, "\PDFs\AreaMotivosRC_Cerradas.pdf", 3)
            End If

            Response.Redirect(sReport)

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnImprimir15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir15.Click
        Dim rptReportGRC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Dim sReport As String

        Try
           
            rptReportGRC.FileName = MapPath("~\Reportes" & "\rptRCMasDe15dias.rpt")
           
            Dim strParamName() As String = {}
            Dim strParamValues() As String = {}

            sReport = PrintReport(rptReportGRC, strParamName, strParamValues, "\PDFs\rptRCMasDe15dias.pdf", 4)
            
            Response.Redirect(sReport)

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnReclaExcedidas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReclaExcedidas.Click
        Dim rptReportGRC As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Dim sReport As String

        Try

            rptReportGRC.FileName = MapPath("~\Reportes" & "\rptReclaExcedidas.rpt")

            Dim strParamName() As String = {}
            Dim strParamValues() As String = {}

            sReport = PrintReport(rptReportGRC, strParamName, strParamValues, "\PDFs\rptReclaExcedidas.pdf", 5)

            Response.Redirect(sReport)

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnRRM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRRM.Click
        Dim OtrosMesesCerradas As GridView
        Dim dtData As Data.DataSet

        Try

            dtData = New Data.DataSet
            dtData = clsReclamaciones.getReclamacionRRM(txtFechaIRM.Text, txtFechaFRM.Text)

            OtrosMesesCerradas = New GridView
            OtrosMesesCerradas.DataSource = dtData.Tables(0)
            OtrosMesesCerradas.DataBind()
            ExportarAExcel(OtrosMesesCerradas, "OtrosMesesCerradasNOW")

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnAbiertasYCerradas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbiertasYCerradas.Click
        Dim AbiertasYCerradas As GridView
        Dim dtData As Data.DataSet

        Try

            dtData = New Data.DataSet
            dtData = clsReclamaciones.getReclamacionRRM(txtFechaIRM.Text, txtFechaFRM.Text)

            AbiertasYCerradas = New GridView
            AbiertasYCerradas.DataSource = dtData.Tables(1)
            AbiertasYCerradas.DataBind()
            ExportarAExcel(AbiertasYCerradas, "AbiertasYCerradas")

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Protected Sub btnAbiertas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbiertas.Click
        Dim Abiertas As GridView
        Dim dtData As Data.DataSet

        Try

            dtData = New Data.DataSet
            dtData = clsReclamaciones.getReclamacionRRM(txtFechaIRM.Text, txtFechaFRM.Text)

            Abiertas = New GridView
            Abiertas.DataSource = dtData.Tables(2)
            Abiertas.DataBind()
            ExportarAExcel(Abiertas, "Abiertas")

        Catch err As Exception
            lblMensaje.Text = err.Message

        End Try
    End Sub

    Private Sub ExportarAExcel(ByVal grilla As GridView, ByVal seccion As String)
        Dim strb As New StringBuilder()
        Dim strW As New IO.StringWriter(strb)
        Dim htnw As New HtmlTextWriter(strW)
        Dim htmPage As New Page()
        Dim form As New HtmlForm()

        grilla.EnableViewState = False
        grilla.AllowPaging = False

        htmPage.EnableEventValidation = False
        htmPage.DesignerInitialize()
        htmPage.Controls.Add(form)

        form.Controls.Add(grilla)
        form.RenderControl(htnw)

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" & seccion & Environment.TickCount.ToString.Substring(3) & ".xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(strb.ToString())
        Response.End()
    End Sub

End Class
