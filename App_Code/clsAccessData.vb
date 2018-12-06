Imports Microsoft.VisualBasic

Public Class clsAccessData
    'Private Shared sConnJDE As String = ConfigurationManager.ConnectionStrings("sConnJDE").ConnectionString
    'Private Shared sConnSQL As String = ConfigurationManager.ConnectionStrings("sConnSQL").ConnectionString
    Private Shared sConnSQL As String = ConfigurationManager.AppSettings.Get("sConnSQLODBC")
    Private Shared sConnAS400 As String = ConfigurationManager.AppSettings.Get("sConnAS400ODBC")

    Enum eConn
        SQL = 1
        AS400 = 2
    End Enum

    Public Shared Function getConnection(ByVal iConn As Integer) As String
        Dim sResult As String = String.Empty

        Select Case iConn
            Case 1 : sResult = sConnSQL
            Case 2 : sResult = sConnAS400
        End Select

        Return sResult

    End Function
End Class
