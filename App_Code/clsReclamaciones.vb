Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Odbc
Imports Microsoft.ApplicationBlocks.Data
Imports wsClientes
Imports wsFacturas
Imports wsProductos
Imports wsPedidos
Imports wsVendedores


Public Class clsReclamaciones


    Private Shared Function ExecuteNonQueryODBC(sConn As String, type As Data.CommandType, procedure As String, parameters() As Odbc.OdbcParameter) As Integer
        Dim oconn = New System.Data.Odbc.OdbcConnection(sConn)
        Dim ocmd = New System.Data.Odbc.OdbcCommand(procedure, oconn)


        ocmd.CommandType = type

        For Each param As OdbcParameter In parameters
            ocmd.Parameters.Add(param)
        Next

        ocmd.Connection.Open()
        Dim value = ocmd.ExecuteNonQuery()
        ocmd.Connection.Close()

        Return value
    End Function

    Private Shared Function ExecuteScalarODBC(sConn As String, type As Data.CommandType, procedure As String, Optional parameters() As Odbc.OdbcParameter = Nothing) As Integer
        Dim oconn = New System.Data.Odbc.OdbcConnection(sConn)
        Dim ocmd = New System.Data.Odbc.OdbcCommand(procedure, oconn)
        Dim pa = New System.Data.Odbc.OdbcParameter

        ocmd.CommandType = type

        For Each param As OdbcParameter In parameters
            ocmd.Parameters.Add(param)
        Next

        ocmd.Connection.Open()
        Dim value = ocmd.ExecuteScalar()
        ocmd.Connection.Close()

        Return value
    End Function

    Private Shared Function ExecuteDataSetODBC(sConn As String, type As Data.CommandType, procedure As String, Optional parameters() As Odbc.OdbcParameter = Nothing) As DataSet
        Dim oconn = New System.Data.Odbc.OdbcConnection(sConn)
        Dim ocmd = New System.Data.Odbc.OdbcCommand(procedure, oconn)
        Dim adapter As OdbcDataAdapter
        Dim dtData = New DataSet

        ocmd.CommandType = type
        adapter = New OdbcDataAdapter(ocmd)

        adapter.Fill(dtData)

        Return dtData
    End Function


#Region "INSERT's"

    Public Shared Function guardaReclamacion(ByVal pedido As String, ByVal descripcion As String, ByVal cliente As String, _
ByVal contacto As String, ByVal factura As String, ByVal ventas As String, ByVal telefono As String, ByVal vendedor As String, ByVal planta As Integer, _
ByVal conclusion As String, ByVal creadapor As String, ByVal soporteVta As String, ByVal correo As String, ByVal tipoDoc As String, ByVal chofer As String, _
    ByVal transportista As String) As Integer
        Dim param1 As New OdbcParameter("@pedido", pedido)
        Dim param2 As New OdbcParameter("@descripcion", descripcion)
        Dim param3 As New OdbcParameter("@cliente", cliente)
        Dim param4 As New OdbcParameter("@contacto", contacto)
        Dim param5 As New OdbcParameter("@factura", factura)
        Dim param6 As New OdbcParameter("@ventas", ventas)
        Dim param7 As New OdbcParameter("@telefono", telefono)
        Dim param8 As New OdbcParameter("@vendedor", vendedor)
        Dim param9 As New OdbcParameter("@planta", planta)
        Dim param10 As New OdbcParameter("@conclusion", conclusion)
        Dim param11 As New OdbcParameter("@creadapor", creadapor)
        Dim param12 As New OdbcParameter("@soporte", soporteVta)
        Dim param13 As New OdbcParameter("@correo", correo)
        Dim param14 As New OdbcParameter("@tipoDoc", tipoDoc)
        Dim param15 As New OdbcParameter("@chofer", chofer)
        Dim param16 As New OdbcParameter("@transportista", transportista)


        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), _
        CommandType.StoredProcedure, "sp_guardaReclamacion", New OdbcParameter() {param1, param2, _
                                                                    param3, param4, param5, param6, _
                                                                    param7, param8, param9, param10, _
                                                                    param11, param12, param13, param14, param15, param16})

    End Function

    Public Shared Function guardaComentario(ByVal id_recla As Integer, ByVal comentario As String, ByVal id_usuario As String, ByVal depto As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@comentario", comentario)
        Dim param3 As New OdbcParameter("@id_usuario", id_usuario)
        Dim param4 As New OdbcParameter("@depto", depto)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_guardaComentario", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function guardaDescrpRecl(ByVal id_recla As Integer, ByVal descrp As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@descripcion", descrp)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_guardaReclDescrp", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function guardaCorreo(ByVal id_recla As Integer, ByVal correo As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@correo", correo)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_guardaCorreo", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function setUsuarioReclamacion(ByVal id_recla As Integer, ByVal usuario As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@id_usuario", usuario)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_setUsrReclamacion", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function guardaUsuario(ByVal usuario As String, ByVal contrasena As String, ByVal idempleado As Decimal, _
ByVal nombre As String, ByVal depto As Integer, ByVal correo As String, ByVal nivel As Integer, ByVal status As String) As Integer
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Dim param2 As New OdbcParameter("@contrasena", contrasena)
        Dim param3 As New OdbcParameter("@idempleado", idempleado)
        Dim param4 As New OdbcParameter("@nombre", nombre)
        Dim param5 As New OdbcParameter("@depto", depto)
        Dim param6 As New OdbcParameter("@correo", correo)
        Dim param7 As New OdbcParameter("@nivel", nivel)
        Dim param8 As New OdbcParameter("@status", status)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_newUsr", New OdbcParameter() {param1, param2, param3, param4, param5, param6, param7, param8})

    End Function

    Public Shared Function insertMotivo(ByVal motivo As String, ByVal id_motivo As Integer) As Integer
        Dim param1 As New OdbcParameter("@descripcion", motivo)
        Dim param2 As New OdbcParameter("@id_motivo", id_motivo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertMotivo", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function insertGrupo(ByVal grupo As String, ByVal id_grupo As Integer) As Integer
        Dim param1 As New OdbcParameter("@grupo", grupo)
        Dim param2 As New OdbcParameter("@id_grupo", id_grupo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertGrupo", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function insertUsrToGrupo(ByVal grupo_id As Integer, ByVal usuario As String) As Integer
        Dim param1 As New OdbcParameter("@id_grupo", grupo_id)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertUsrToGrupo", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function insertArea(ByVal area As String) As Integer
        Dim param1 As New OdbcParameter("@area", area)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertArea", New OdbcParameter() {param1})

    End Function

    Public Shared Function insertProducto(ByVal producto As String) As Integer
        Dim param1 As New OdbcParameter("@descripcion", producto)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertProducto", New OdbcParameter() {param1})

    End Function

    Public Shared Function adProductoRecl(ByVal id_reclamacion As Integer, ByVal cod_prod As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New OdbcParameter("@cod_prod", cod_prod)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_addProductosRecl", New OdbcParameter() {param1, param2})

    End Function
#End Region

#Region "UPDATE's"

    Public Shared Function closeReclamacion(ByVal id_recla As Integer, ByVal conclusion As String, ByVal area As Integer, _
    ByVal motivo As Integer, ByVal monto As Decimal, ByVal ncnd As String, ByVal moneda As String, ByVal cantidad As Decimal, _
    ByVal metrica As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@conclusion", conclusion)
        Dim param3 As New OdbcParameter("@area", area)
        Dim param4 As New OdbcParameter("@motivo", motivo)
        Dim param5 As New OdbcParameter("@monto", monto)
        Dim param6 As New OdbcParameter("@ncnd", ncnd)
        Dim param7 As New OdbcParameter("@moneda", moneda)
        Dim param8 As New OdbcParameter("@cantidad", cantidad)
        Dim param9 As New OdbcParameter("@metrica", metrica)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), _
        CommandType.StoredProcedure, "sp_closeReclamacion", New OdbcParameter() {param1, param2, param3, param4, param5, _
                                                                                param6, param7, param8, param9})

    End Function

#End Region

#Region "DELETE's"

    Public Shared Function delGrupoUsr(ByVal grupo As Integer, ByVal usr As String) As Integer
        Dim param1 As New OdbcParameter("@grupo_id", grupo)
        Dim param2 As New OdbcParameter("@usuario", usr)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delGrupoUsr", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function delUsuario(ByVal codigo As Decimal) As Integer
        Dim param1 As New OdbcParameter("@idempleado", codigo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delUsuario", New OdbcParameter() {param1})

    End Function

    Public Shared Function delGrupo(ByVal grupo As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_grupo", grupo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delGrupo", New OdbcParameter() {param1})

    End Function

    Public Shared Function delMotivo(ByVal motivo As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_motivo", motivo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delMotivo", New OdbcParameter() {param1})

    End Function

    Public Shared Function delArea(ByVal area As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_area", area)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delArea", New OdbcParameter() {param1})

    End Function

    Public Shared Function delProducto(ByVal producto As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_producto", producto)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delProductosRecl", New OdbcParameter() {param1})

    End Function

    Public Shared Function delReclamacion(ByVal id_reclamacion As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delReclamacion", New OdbcParameter() {param1})

    End Function

    Public Shared Function delComentario(ByVal id_comentario As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_comentario", id_comentario)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delComentario", New OdbcParameter() {param1})

    End Function

#End Region

#Region "GET's"

    Public Shared Function getReclamacionToCliente(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_ReporteToCliente", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function validaUsr(ByVal usuario As String, ByVal contrasena As String) As DataTable
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Dim param2 As New OdbcParameter("@contrasena", contrasena)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_validaUsr", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getClientes() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getClientes").Tables(0)

    End Function

    Public Shared Function getVendedores() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getVendedores").Tables(0)

    End Function

    Public Shared Function getPlantas() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getPlantas").Tables(0)

    End Function

    Public Shared Function getPedido(ByVal pedido As Decimal, ByVal tipo As String) As DataTable
        Dim param1 As New OdbcParameter("@pedido", pedido)
        Dim param2 As New OdbcParameter("@tipo", tipo)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getPedido", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getReclamaciones(ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamaciones", New OdbcParameter() {param1})

    End Function

    Public Shared Function getReclamacionesForExcel(ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionesForExcel", New OdbcParameter() {param1})

    End Function

    Public Shared Function getReclamacion(ByVal id_reclamacion As Integer, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacion", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByFecha(ByVal fechaI As String, ByVal fechaF As String, ByVal estatus As String, ByVal ventas As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Dim param3 As New OdbcParameter("@estatus", estatus)
        Dim param4 As New OdbcParameter("@ventas", ventas)
        Dim param5 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByFecha", New OdbcParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getReclamacionByClienteToExcel(ByVal cliente As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@cliente", cliente)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByClienteToExcel", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByFechaToExcel(ByVal fechaI As String, ByVal fechaF As String, ByVal estatus As String, ByVal ventas As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Dim param3 As New OdbcParameter("@estatus", estatus)
        Dim param4 As New OdbcParameter("@ventas", ventas)
        Dim param5 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByFechaToExcel", New OdbcParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getReclamacionByDescrp(ByVal Descrp As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@descrp", Descrp)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByDescrp", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByCliente(ByVal Cliente As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@cliente", Cliente)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByCliente", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByMotivo(ByVal Motivo As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@motivo", Motivo)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByMotivo", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByMotivoToExcel(ByVal Motivo As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@motivo", Motivo)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByMotivoToExcel", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByArea(ByVal area As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@area", area)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByArea", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByAreaToExcel(ByVal area As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@area", area)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByAreaToExcel", New OdbcParameter() {param1, param2, param3, param4})

    End Function


    Public Shared Function getReclamacionByFactura(ByVal factura As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@factura", factura)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByFactura", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByChofer(ByVal chofer As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@chofer", chofer)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByChofer", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByTransportista(ByVal transportista As Integer, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@transportista", transportista)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByTransportista", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionDetalle(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionDetalle", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getReclamacionPatron(ByVal mes As Integer, ByVal pyear As Integer) As DataTable
        Dim param1 As New OdbcParameter("@mes", mes)
        Dim param2 As New OdbcParameter("@pyear", pyear)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionPatron", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getComentarios(ByVal id_reclamacion As Integer, ByVal depto As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New OdbcParameter("@depto", depto)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getComentarios", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getUltimaReclamacion() As Integer
        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUltReclamacion")

    End Function

    Public Shared Function getUsuarios(ByVal pGrupo As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_grupo", pGrupo)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuarios", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsuarioByCorreo(ByVal correo As String) As String
        Dim param1 As New OdbcParameter("@correo", correo)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuarioByCorreo", New OdbcParameter() {param1})

    End Function

    Public Shared Function getDeptos() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDeptos").Tables(0)

    End Function

    Public Shared Function getAreas() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getAreas").Tables(0)

    End Function

    Public Shared Function getUsuariosGrid(ByVal usuario As String) As DataTable
        Dim param1 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuariosGrid", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getNiveles() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getNiveles").Tables(0)

    End Function

    Public Shared Function getMotivos() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getMotivos").Tables(0)

    End Function

    Public Shared Function getGrupos() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getGrupos").Tables(0)

    End Function

    Public Shared Function getGruposUsrs() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsrsGrupos").Tables(0)

    End Function

    Public Shared Function getProductos() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductos").Tables(0)

    End Function

    Public Shared Function getProducto(ByVal producto As String) As DataTable
        Dim param1 As New OdbcParameter("@producto", producto)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProducto", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsrNoEstanReclamacion(ByVal reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", reclamacion)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsrNoEstanReclamacion", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsrEstanReclamacion(ByVal reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", reclamacion)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsrEstanReclamacion", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function setArchivo(ByVal ruta As String, ByVal extension As String, ByVal area As String, ByVal id_reclamacion As Integer, ByVal id_comentario As Integer) As String
        Dim param1 As New OdbcParameter("@ruta", ruta)
        Dim param2 As New OdbcParameter("@archivo", extension)
        Dim param3 As New OdbcParameter("@area", area)
        Dim param4 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param5 As New OdbcParameter("@id_comentario", id_comentario)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_setArchivo", New OdbcParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getArchivos(ByVal area As String, ByVal id_comentario As Integer) As DataTable
        Dim param1 As New OdbcParameter("@area", area)
        Dim param2 As New OdbcParameter("@id_comentario", id_comentario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getArchivos", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getUsuario(ByVal usuario As String) As Integer
        Dim param1 As New OdbcParameter("@usuario", usuario)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuario", New OdbcParameter() {param1})

    End Function

    Public Shared Function getReclamacionRpt(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionesRpt", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRptAM(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCByAreaMotivo", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRptAMC(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCByAreaMotivo_Cerrada", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionesExcedidas(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@pFechaI", fechaI)
        Dim param2 As New OdbcParameter("@pFechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamExcedidas", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRpt15D() As DataSet
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCMasDe15Dias")

    End Function

    Public Shared Function getProductosRecl(ByVal id_reclamacion As String) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductosRecl", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getDocumentoExiste(ByVal documento As String, ByVal tipoDocumento As String) As String
        Dim param1 As OdbcParameter

        If tipoDocumento = "F" Then
            param1 = New OdbcParameter("@factura", documento)
            Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDocumentoExiste", New OdbcParameter() {param1})
        Else
            param1 = New OdbcParameter("@pedido", documento)
            Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDocumentoExiste", New OdbcParameter() {param1})
        End If


    End Function

    Public Shared Function getReclamacionRRM(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_ReporteMensualReclamaciones", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getChofer(ByVal chofer As String) As DataSet
        Dim param1 As New OdbcParameter("@chofer", chofer)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getChoferes", New OdbcParameter() {param1})

    End Function

    Public Shared Function getTransportista(ByVal suplidor As String) As DataSet
        Dim param1 As New OdbcParameter("@transportista", suplidor)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getTransportistas", New OdbcParameter() {param1})

    End Function

    Public Shared Function setComentProd(ByVal idProd As Integer, ByVal comentario As String) As String
        Dim param1 As New OdbcParameter("@id_producto", idProd)
        Dim param2 As New OdbcParameter("@comentario", comentario)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_setProductoComentario", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getProductoERP(ByVal producto As String) As Data.DataTable
        Dim param1 As New OdbcParameter("@producto", producto)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductoAX", New OdbcParameter() {param1}).Tables(0)

    End Function
#End Region


#Region "UTIL"
    Public Shared Function ExportPDF(ByRef Srv As HttpServerUtility, ByRef rpt As Object, ByVal pdf As String) As String
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        Dim sRutaPDF As String = Srv.MapPath("~\Reportes" & pdf)

        CrDiskFileDestinationOptions.DiskFileName = sRutaPDF

        'CrFormatTypeOptions.FirstPageNumber = 1 ' Start Page in the Report
        'CrFormatTypeOptions.LastPageNumber = 3 ' End Page in the Report
        CrFormatTypeOptions.UsePageRange = False

        CrExportOptions = rpt.ExportOptions

        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With

        rpt.Export()

        Return sRutaPDF
    End Function

    Public Shared Sub TieButton(ByVal pPage As Page, ByVal TextBoxToTie As Control, ByVal ButtonToTie As Control)
        Dim jsString As String = ""

        jsString = "if((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)){" + pPage.ClientScript.GetPostBackEventReference(ButtonToTie, "").Replace(":", "$") + ";return false;} else return true;"
        CType(TextBoxToTie, WebControl).Attributes.Add("onkeydown", jsString)

    End Sub

    Public Shared Function getFactura(ByVal pFact As String, ByVal idReclamacion As Integer) As Data.DataTable
        Dim param1 As New OdbcParameter("@factura", pFact)
        Dim DataFactura As New Data.DataTable
        Dim DataProductos As New Data.DataTable

        DataFactura = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDatosFacturaAX", New OdbcParameter() {param1}).Tables(0)
        DataProductos = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductosByFacturaAX", New OdbcParameter() {param1}).Tables(0)

        For Each product As DataRow In DataProductos.Rows
            adProductoRecl(idReclamacion, product.Item("codProducto"))
        Next

        'Parameters:
        '0-Codigo de Vendedor
        '1-Nombre de Vendedor
        '2-Codigo de Cliente
        '3-Nombre de Cliente
        '4-
        '5-Venta Local / Internacional

        Return DataFactura

    End Function

    Public Shared Function getPedidoERP(ByVal pPed As String, ByVal idReclamacion As Integer) As Data.DataTable
        Dim param1 As New OdbcParameter("@pedido", pPed)
        Dim DataPedido As New Data.DataTable
        Dim DataProductos As New Data.DataTable

        DataPedido = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDatosPedidoAX", New OdbcParameter() {param1}).Tables(0)
        DataProductos = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductosByPedidoAX", New OdbcParameter() {param1}).Tables(0)

        For Each product As DataRow In DataProductos.Rows
            adProductoRecl(idReclamacion, product.Item("codProducto"))
        Next

        'Parameters:
        '0-Codigo de Vendedor
        '1-Nombre de Vendedor
        '2-Codigo de Cliente
        '3-Nombre de Cliente
        '4-
        '5-Venta Loca / Internacional
        '6-Motivo (eliminar este parametro)

        Return DataPedido

    End Function
#End Region

End Class
