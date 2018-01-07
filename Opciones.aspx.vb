
Partial Class Opciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Item("nivel") = 2 Then Response.Redirect("Login.aspx")


    End Sub
End Class
