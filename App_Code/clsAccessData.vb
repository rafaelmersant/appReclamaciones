Imports Microsoft.VisualBasic

Public Class clsAccessData
    'Private Shared sConnJDE As String = ConfigurationManager.ConnectionStrings("sConnJDE").ConnectionString
    Private Shared sConnSQL As String = ConfigurationManager.ConnectionStrings("sConnSQL").ConnectionString

    Enum eConn
        SQL = 1
        JDE = 2
    End Enum

    Public Shared Function getConnection(ByVal iConn As Integer) As String
        Dim sResult As String = String.Empty

        Select Case iConn
            Case 1 : sResult = sConnSQL
                'Case 2 : sResult = sConnJDE
        End Select

        Return sResult

    End Function
End Class
