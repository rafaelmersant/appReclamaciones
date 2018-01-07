Imports System.Data

Partial Class PatronRptMensual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("nivel") = 2 Then Response.Redirect("Login.aspx")

        If Not Page.IsPostBack() Then
            fillMeses()
            fillAgno()
        End If

    End Sub

    Private Sub fillMeses()
        For i As Integer = 1 To 12
            ddlMeses.Items.Add(New ListItem(MonthName(i), i))
        Next
    End Sub

    Private Sub fillAgno()
        Dim piyear As Integer = Now.Year

        While (piyear > 2006)
            ddlagnos.Items.Add(New ListItem(piyear, piyear))
            piyear = piyear - 1
        End While

    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        Try
            DataList1.DataSource = clsReclamaciones.getReclamacionPatron(ddlMeses.SelectedValue, ddlagnos.SelectedValue)
            DataList1.DataBind()

            lblReclamaciones.Text = "RECLAMACIONES " & ddlMeses.SelectedItem.Text.ToUpper() & "-" & ddlagnos.SelectedValue

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        
    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        Dim noRe As Integer = CType(e.Item.FindControl("lblNoRecla"), Label).Text
        ListaComentarios(noRe, 1, e)
        ListaComentarios(noRe, 2, e)
        ListaComentarios(noRe, 3, e)
        ListaComentarios(noRe, 4, e)
        ListaComentarios(noRe, 5, e)

        If CType(e.Item.FindControl("label11"), Label).Text.Trim() = "" Then CType(e.Item.FindControl("label10"), Label).Visible = False
        If CType(e.Item.FindControl("label16"), Label).Text.Trim() = "" Then CType(e.Item.FindControl("label15"), Label).Visible = False

    End Sub

    Private Sub ListaComentarios(ByVal NoRec As Integer, ByVal depto As Integer, ByRef e As System.Web.UI.WebControls.DataListItemEventArgs)
        Dim dtComentarios As New DataTable
        dtComentarios = clsReclamaciones.getComentarios(NoRec, depto)

        CType(e.Item.FindControl("ltcomentarios" & depto), Literal).Text = ""

        For Each row As DataRow In dtComentarios.Rows
            CType(e.Item.FindControl("ltcomentarios" & depto), Literal).Text &= _
            "<br/> <div Class=""LetraFiles"">" & row.Item(1) & "(" & row.Item(3) & ")" & "</div>"
        Next

    End Sub
End Class
