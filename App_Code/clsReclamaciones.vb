Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Odbc
Imports Microsoft.ApplicationBlocks.Data
Imports System.Net
Imports System.Net.Mail

'Imports wsClientes
'Imports wsFacturas
'Imports wsProductos
'Imports wsPedidos
'Imports wsVendedores


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

        ocmd.Dispose()

        Return value
    End Function

    Private Shared Function ExecuteScalarODBC(sConn As String, type As Data.CommandType, procedure As String, Optional parameters() As Odbc.OdbcParameter = Nothing) As Object
        Dim oconn = New System.Data.Odbc.OdbcConnection(sConn)
        Dim ocmd = New System.Data.Odbc.OdbcCommand(procedure, oconn)
        Dim pa = New System.Data.Odbc.OdbcParameter

        ocmd.CommandType = type

        If Not parameters Is Nothing Then
            For Each param As OdbcParameter In parameters
                ocmd.Parameters.Add(param)
            Next

        End If

        ocmd.Connection.Open()
        Dim value = ocmd.ExecuteScalar()
        ocmd.Connection.Close()

        ocmd.Dispose()

        Return value
    End Function

    Private Shared Function ExecuteDataSetODBC(sConn As String, type As Data.CommandType, procedure As String, Optional parameters() As Odbc.OdbcParameter = Nothing) As DataSet
        Dim oconn = New System.Data.Odbc.OdbcConnection(sConn)
        Dim ocmd = New System.Data.Odbc.OdbcCommand(procedure, oconn)
        Dim adapter As OdbcDataAdapter
        Dim dsData = New DataSet()

        ocmd.CommandType = type

        If Not parameters Is Nothing Then
            ocmd.Parameters.Clear()

            For Each param As OdbcParameter In parameters
                ocmd.Parameters.Add(param)
            Next
        End If

        adapter = New OdbcDataAdapter(ocmd)

        adapter.Fill(dsData)

        Return dsData
    End Function


#Region "INSERT's"

    Public Shared Function guardaReclamacion(ByVal pedido As String, ByVal descripcion As String, ByVal cliente As String,
ByVal contacto As String, ByVal factura As String, ByVal ventas As String, ByVal telefono As String, ByVal vendedor As String, ByVal planta As Integer,
ByVal conclusion As String, ByVal creadapor As String, ByVal soporteVta As String, ByVal correo As String, ByVal tipoDoc As String, ByVal chofer As String,
    ByVal transportista As String, nombreCte As String, tipo_fact_ped As String, categoria As String) As Integer
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
        Dim param17 As New OdbcParameter("@nombreCte", nombreCte)
        Dim param18 As New OdbcParameter("@tipo_fac_ped", tipo_fact_ped)
        Dim param19 As New OdbcParameter("@categoria", categoria)


        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL),
        CommandType.StoredProcedure, "{call sp_guardaReclamacion (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}", New OdbcParameter() {param1, param2,
                                                                    param3, param4, param5, param6,
                                                                    param7, param8, param9, param10,
                                                                    param11, param12, param13, param14,
                                                                    param15, param16, param17, param18, param19})

    End Function

    Public Shared Function guardaComentario(ByVal id_recla As Integer, ByVal comentario As String, ByVal id_usuario As String, ByVal depto As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@comentario", comentario)
        Dim param3 As New OdbcParameter("@id_usuario", id_usuario)
        Dim param4 As New OdbcParameter("@depto", depto)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_guardaComentario (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function guardaDescrpRecl(ByVal id_recla As Integer, ByVal descrp As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@descripcion", descrp)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_guardaReclDescrp (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function guardaCorreo(ByVal id_recla As Integer, ByVal correo As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@correo", correo)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_guardaCorreo (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function setUsuarioReclamacion(ByVal id_recla As Integer, ByVal usuario As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@id_usuario", usuario)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_setUsrReclamacion (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function guardaUsuario(ByVal usuario As String, ByVal contrasena As String, ByVal idempleado As Decimal,
ByVal nombre As String, ByVal depto As Integer, ByVal correo As String, ByVal nivel As Integer, ByVal status As String) As Integer
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Dim param2 As New OdbcParameter("@contrasena", contrasena)
        Dim param3 As New OdbcParameter("@idempleado", idempleado)
        Dim param4 As New OdbcParameter("@nombre", nombre)
        Dim param5 As New OdbcParameter("@depto", depto)
        Dim param6 As New OdbcParameter("@correo", correo)
        Dim param7 As New OdbcParameter("@nivel", nivel)
        Dim param8 As New OdbcParameter("@status", status)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_newUsr (?,?,?,?,?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4, param5, param6, param7, param8})

    End Function

    Public Shared Function insertMotivo(ByVal motivo As String, ByVal id_motivo As Integer) As Integer
        Dim param1 As New OdbcParameter("@descripcion", motivo)
        Dim param2 As New OdbcParameter("@id_motivo", id_motivo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertMotivo (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function insertGrupo(ByVal grupo As String, ByVal id_grupo As Integer) As Integer
        Dim param1 As New OdbcParameter("@grupo", grupo)
        Dim param2 As New OdbcParameter("@id_grupo", id_grupo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertGrupo (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function insertUsrToGrupo(ByVal grupo_id As Integer, ByVal usuario As String) As Integer
        Dim param1 As New OdbcParameter("@id_grupo", grupo_id)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertUsrToGrupo (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function insertArea(ByVal area As String) As Integer
        Dim param1 As New OdbcParameter("@area", area)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertArea (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function insertProductoFromAS400(ByVal codProducto As String, descripcion As String, modelo As String, codParte As String) As Integer
        Dim param1 As New OdbcParameter("@codProducto", codProducto)
        Dim param2 As New OdbcParameter("@descripcion", descripcion)
        Dim param3 As New OdbcParameter("@modelo", modelo)
        Dim param4 As New OdbcParameter("@codParte", codParte)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertProductoFromAS400 (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function insertClienteFromAS400(ByVal codigo As String, nombre As String, telefono As String, email As String) As Integer
        Dim param1 As New OdbcParameter("@codigo", codigo)
        Dim param2 As New OdbcParameter("@nombre", nombre)
        Dim param3 As New OdbcParameter("@telefono", telefono)
        Dim param4 As New OdbcParameter("@email", email)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertClienteFromAS400 (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function insertVendedorFromAS400(ByVal codigo As Integer, nombre As String) As Integer
        Dim param1 As New OdbcParameter("@codigo", codigo)
        Dim param2 As New OdbcParameter("@nombre", nombre)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_insertVendedorFromAS400 (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function adProductoRecl(ByVal id_reclamacion As Integer, ByVal cod_prod As String) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New OdbcParameter("@cod_prod", cod_prod)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_addProductosRecl (?,?)}", New OdbcParameter() {param1, param2})

    End Function
#End Region

#Region "UPDATE's"

    Public Shared Function closeReclamacion(ByVal id_recla As Integer, ByVal conclusion As String, ByVal area As Integer,
    ByVal motivo As Integer, ByVal monto As Decimal, ByVal ncnd As String, ByVal moneda As String, ByVal cantidad As Decimal,
    ByVal metrica As String, clase_doc As String) As Integer

        Dim param1 As New OdbcParameter("@id_reclamacion", id_recla)
        Dim param2 As New OdbcParameter("@conclusion", conclusion)
        Dim param3 As New OdbcParameter("@area", area)
        Dim param4 As New OdbcParameter("@motivo", motivo)
        Dim param5 As New OdbcParameter("@monto", monto)
        Dim param6 As New OdbcParameter("@ncnd", ncnd)
        Dim param7 As New OdbcParameter("@moneda", moneda)
        Dim param8 As New OdbcParameter("@cantidad", cantidad)
        Dim param9 As New OdbcParameter("@metrica", metrica)
        Dim param10 As New OdbcParameter("@clase_doc", clase_doc)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL),
        CommandType.StoredProcedure, "{call sp_closeReclamacion (?,?,?,?,?,?,?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4, param5,
                                                                                param6, param7, param8, param9, param10})

    End Function

#End Region

#Region "DELETE's"

    Public Shared Function delGrupoUsr(ByVal grupo As Integer, ByVal usr As String) As Integer
        Dim param1 As New OdbcParameter("@grupo_id", grupo)
        Dim param2 As New OdbcParameter("@usuario", usr)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delGrupoUsr (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function delUsuario(ByVal codigo As Decimal) As Integer
        Dim param1 As New OdbcParameter("@idempleado", codigo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delUsuario (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function delGrupo(ByVal grupo As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_grupo", grupo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delGrupo (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function delMotivo(ByVal motivo As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_motivo", motivo)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delMotivo (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function delArea(ByVal area As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_area", area)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delArea (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function delProducto(ByVal producto As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_producto", producto)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delProductosRecl (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function delReclamacion(ByVal id_reclamacion As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delReclamacion (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function delComentario(ByVal id_comentario As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_comentario", id_comentario)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_delComentario (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function abrirReclamacion(ByVal id_reclamacion As Integer) As Integer
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteNonQueryODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                   "{call sp_AbrirReclamacion (?)}", New OdbcParameter() {param1})

    End Function

#End Region

#Region "GET's"

    Public Shared Function getReclamacionToCliente(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_ReporteToCliente (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function validaUsr(ByVal usuario As String, ByVal contrasena As String) As DataTable
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Dim param2 As New OdbcParameter("@contrasena", contrasena)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_validaUsr (?,?)}", New OdbcParameter() {param1, param2}).Tables(0)

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

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getPedido (?,?)}", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getReclamaciones(ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamaciones (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function getReclamacionesForExcel(ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@usuario", usuario)
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionesForExcel (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function getReclamacion(ByVal id_reclamacion As Integer, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacion (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByFecha(ByVal fechaI As String, ByVal fechaF As String, ByVal estatus As String, ByVal ventas As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Dim param3 As New OdbcParameter("@estatus", estatus)
        Dim param4 As New OdbcParameter("@ventas", ventas)
        Dim param5 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByFecha (?,?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getReclamacionByClienteToExcel(ByVal cliente As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@cliente", cliente)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByClienteToExcel (?,?)", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByFechaToExcel(ByVal fechaI As String, ByVal fechaF As String, ByVal estatus As String, ByVal ventas As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)
        Dim param3 As New OdbcParameter("@estatus", estatus)
        Dim param4 As New OdbcParameter("@ventas", ventas)
        Dim param5 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByFechaToExcel (?,?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getReclamacionByDescrp(ByVal Descrp As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@descrp", Descrp)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByDescrp (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByCliente(ByVal Cliente As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@cliente", Cliente)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByCliente (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByMotivo(ByVal Motivo As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@motivo", Motivo)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByMotivo (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByMotivoToExcel(ByVal Motivo As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@motivo", Motivo)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByMotivoToExcel (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByArea(ByVal area As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@area", area)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByArea (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByAreaToExcel(ByVal area As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@area", area)
        Dim param2 As New OdbcParameter("@usuario", usuario)
        Dim param3 As New OdbcParameter("@fechaI", fechaI)
        Dim param4 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByAreaToExcel (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})

    End Function


    Public Shared Function getReclamacionByFactura(ByVal factura As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@factura", factura)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByFactura (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByOrden(ByVal orden As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@orden", orden)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByOrden (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByChofer(ByVal chofer As String, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@chofer", chofer)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByChofer (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByTransportista(ByVal transportista As Integer, ByVal usuario As String) As DataSet
        Dim param1 As New OdbcParameter("@transportista", transportista)
        Dim param2 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionByTransportista (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionDetalle(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionDetalle (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getReclamacionPatron(ByVal mes As Integer, ByVal pyear As Integer) As DataTable
        Dim param1 As New OdbcParameter("@mes", mes)
        Dim param2 As New OdbcParameter("@pyear", pyear)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionPatron (?,?)}", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getComentarios(ByVal id_reclamacion As Integer, ByVal depto As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New OdbcParameter("@depto", depto)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getComentarios (?,?)}", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getUltimaReclamacion() As Integer
        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUltReclamacion")

    End Function

    Public Shared Function getUsuarios(ByVal pGrupo As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_grupo", pGrupo)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getUsuarios (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsuarioByCorreo(ByVal correo As String) As String
        Dim param1 As New OdbcParameter("@correo", correo)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_getUsuarioByCorreo (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function getDeptos() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDeptos").Tables(0)

    End Function

    Public Shared Function getAreas() As DataTable
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getAreas").Tables(0)

    End Function

    Public Shared Function getUsuariosGrid(ByVal usuario As String) As DataTable
        Dim param1 As New OdbcParameter("@usuario", usuario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getUsuariosGrid (?)}", New OdbcParameter() {param1}).Tables(0)

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

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getProducto (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsrNoEstanReclamacion(ByVal reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getUsrNoEstanReclamacion (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsrEstanReclamacion(ByVal reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getUsrEstanReclamacion (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function setArchivo(ByVal ruta As String, ByVal extension As String, ByVal area As String, ByVal id_reclamacion As Integer, ByVal id_comentario As Integer) As String
        Dim param1 As New OdbcParameter("@ruta", ruta)
        Dim param2 As New OdbcParameter("@archivo", extension)
        Dim param3 As New OdbcParameter("@area", area)
        Dim param4 As New OdbcParameter("@id_reclamacion", id_reclamacion)
        Dim param5 As New OdbcParameter("@id_comentario", id_comentario)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_setArchivo (?,?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getArchivos(ByVal area As String, ByVal id_comentario As Integer) As DataTable
        Dim param1 As New OdbcParameter("@area", area)
        Dim param2 As New OdbcParameter("@id_comentario", id_comentario)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getArchivos (?,?)}", New OdbcParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getUsuario(ByVal usuario As String) As Integer
        Dim param1 As New OdbcParameter("@usuario", usuario)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_getUsuario (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function getReclamacionRpt(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamacionesRpt (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRptAM(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getRCByAreaMotivo (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRptAMC(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getRCByAreaMotivo_Cerrada (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionesExcedidas(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@pFechaI", fechaI)
        Dim param2 As New OdbcParameter("@pFechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getReclamExcedidas (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRpt15D() As DataSet
        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCMasDe15Dias")

    End Function

    Public Shared Function getProductosRecl(ByVal id_reclamacion As String) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getProductosRecl (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getDocumentoExiste(ByVal documento As String, ByVal tipoDocumento As String) As String
        Dim param1 As OdbcParameter

        If tipoDocumento = "F" Then
            param1 = New OdbcParameter("@factura", documento)
            Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                     "{call sp_getDocumentoExiste (?)}", New OdbcParameter() {param1})
        Else
            param1 = New OdbcParameter("@pedido", documento)
            Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                     "{call sp_getDocumentoExiste (?)}", New OdbcParameter() {param1})
        End If


    End Function

    Public Shared Function getReclamacionRRM(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New OdbcParameter("@fechaI", fechaI)
        Dim param2 As New OdbcParameter("@fechaF", fechaF)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_ReporteMensualReclamaciones (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getChofer(ByVal chofer As String) As DataSet
        Dim param1 As New OdbcParameter("@chofer", chofer)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getChoferes (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function getTransportista(ByVal suplidor As String) As DataSet
        Dim param1 As New OdbcParameter("@transportista", suplidor)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getTransportistas (?)}", New OdbcParameter() {param1})

    End Function

    Public Shared Function setComentProd(ByVal idProd As Integer, ByVal comentario As String) As String
        Dim param1 As New OdbcParameter("@id_producto", idProd)
        Dim param2 As New OdbcParameter("@comentario", comentario)

        Return ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                 "{call sp_setProductoComentario (?,?)}", New OdbcParameter() {param1, param2})

    End Function

    Public Shared Function getProductoERP(ByVal cod_producto As String) As Data.DataTable

        Dim codigo As New OdbcParameter("@producto", cod_producto)
        Dim tablaProductoAS400 = ConfigurationManager.AppSettings.Get("tablaProductoAS400")

        Dim data = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getProducto (?)}", New OdbcParameter() {codigo}).Tables(0)

        If data.Rows.Count = 0 And ConfigurationManager.AppSettings.Get("Environment") <> "DEV" Then

            Dim dataAS400 = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text,
                                 "SELECT MPNARTICUL, MPDESCRIPC, MPMODELO, MPCODPARTE FROM @TABLA_PRODUCTO WHERE MPNARTICUL = ".Replace("@TABLA_PRODUCTO", tablaProductoAS400) & cod_producto).Tables(0)

            If dataAS400.Rows.Count > 0 Then
                Dim param1 As New OdbcParameter("@producto", cod_producto)
                Dim param2 As New OdbcParameter("@descripcion", dataAS400.Rows(0).Item(1))
                Dim param3 As New OdbcParameter("@modelo", dataAS400.Rows(0).Item(2))
                Dim param4 As New OdbcParameter("@codparte", dataAS400.Rows(0).Item(3))

                ExecuteScalarODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                     "{call sp_insertProductoFromAS400 (?,?,?,?)}", New OdbcParameter() {param1, param2, param3, param4})
            End If

            Return getProducto(cod_producto)
        Else

            Return data
        End If

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

    Public Shared Function getVendedorNombreERP(ByVal codVendedor As String) As String

        Dim tablaVendedoresAS400 = ConfigurationManager.AppSettings.Get("tablaVendedoresAS400")

        Dim VendedorNombre = ""
        Dim sQueryVendedor As String = "SELECT VENOMB FROM @VENDEDORES WHERE VECOEM = " & codVendedor

        'Testing or Production Environment
        If ConfigurationManager.AppSettings.Get("Environment") = "DEV" Then
            sQueryVendedor = sQueryVendedor.Replace("@VENDEDORES", "Z_RCFAVD00_VENDEDORES")
            VendedorNombre = "Testing Vendedor " & codVendedor
        Else
            sQueryVendedor = sQueryVendedor.Replace("@VENDEDORES", tablaVendedoresAS400)

            Dim Vendedor As DataTable = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, sQueryVendedor).Tables(0)

            If Vendedor.Rows.Count > 0 Then
                VendedorNombre = Vendedor.Rows(0).Item("VENOMB")

                'Insertar Vendedor desde AS400 si no existe
                insertVendedorFromAS400(Integer.Parse(codVendedor), VendedorNombre)
            Else
                VendedorNombre = "N/A"
            End If

        End If

        Return VendedorNombre

    End Function

    Public Shared Function getFacturaERP(ByVal pFact As String, ByVal idReclamacion As Integer, tipoFactura As String) As Data.DataTable
        Dim DataFactura As New Data.DataTable
        Dim DataProductos As New Data.DataTable

        Dim tablaFacturaCabeceraAS400 = ConfigurationManager.AppSettings.Get("tablaFacturaCabeceraAS400")
        Dim tablaFacturaDetalleAS400 = ConfigurationManager.AppSettings.Get("tablaFacturaDetalleAS400")
        'Dim tiposFacturas = ConfigurationManager.AppSettings.Get("tiposFacturas")

        Dim sQueryFactura As String = "SELECT MFNUMCLIEN as codigoCte, MFNOMBRECL as nombreCte, MFTELEFONO as TelefonoCte, " &
                                        " MFVENFACTU as codigoVendedor FROM @FACTURA_CABECERA WHERE MFTIPOFACT IN ('" & tipoFactura & "') AND MFNUMFACT = " & pFact
        Dim sQueryProductos As String = "SELECT MMNUMPRODU as CodProducto, MMNUMFACTU FROM @FACTURA_DETALLE WHERE MMNUMFACTU =" & pFact

        'Testing or Production Environment
        If ConfigurationManager.AppSettings.Get("Environment") = "DEV" Then
            sQueryFactura = sQueryFactura.Replace("@FACTURA_CABECERA", "Z_RCFAMF00_FACH")
            sQueryProductos = sQueryProductos.Replace("@FACTURA_DETALLE", "Z_RCFAMM00_FACD")
        Else
            sQueryFactura = sQueryFactura.Replace("@FACTURA_CABECERA", tablaFacturaCabeceraAS400)
            sQueryProductos = sQueryProductos.Replace("@FACTURA_DETALLE", tablaFacturaDetalleAS400)
        End If

        DataFactura = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, sQueryFactura).Tables(0)
        DataProductos = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, sQueryProductos).Tables(0)

        'Insertar Cliente desde AS400 si no existe
        If DataFactura.Rows.Count > 0 Then
            insertClienteFromAS400(DataFactura.Rows(0).Item("codigoCte"), DataFactura.Rows(0).Item("nombreCte"), DataFactura.Rows(0).Item("TelefonoCte"), "")
        End If

        'Limpiar la tabla de productos con Reclamacion temporal
        Dim productos = getProductosRecl(idReclamacion)
        For Each p As DataRow In productos.Rows
            delProducto(p.Item("id_producto"))
        Next

        'Agregar productos de nuevos resultados encontrados
        For Each product As DataRow In DataProductos.Rows
            adProductoRecl(idReclamacion, product.Item("CodProducto"))

            'Insertar producto desde AS400 si no existe
            getProductoERP(product.Item("CodProducto"))

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


    Public Shared Function getOrdenServicioERP(ByVal pOrdenServicio As String, ByVal idReclamacion As Integer, tipoOrdenServicio As String) As Data.DataTable
        Dim DataOrdenServicio As New Data.DataTable

        Dim tablaOrdenServicioAS400 = ConfigurationManager.AppSettings.Get("tablaOrdenServicioAS400")

        Dim sQueryOrdenServicio As String = "SELECT OSNOMC as nombreCte, OSTIFT as TipoFactura, OSFACO as NoFactura,  " &
                                        " OSLINA as productoDescrp, OSFI03 as serie FROM @ORDEN_SERVICIO WHERE OSTIDO IN ('" & tipoOrdenServicio & "') AND OSNUOS = " & pOrdenServicio

        'Testing or Production Environment
        If ConfigurationManager.AppSettings.Get("Environment") = "DEV" Then
            sQueryOrdenServicio = sQueryOrdenServicio.Replace("@ORDEN_SERVICIO", "Z_RCOSMF00_OS")
        Else
            sQueryOrdenServicio = sQueryOrdenServicio.Replace("@ORDEN_SERVICIO", tablaOrdenServicioAS400)
        End If

        DataOrdenServicio = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, sQueryOrdenServicio).Tables(0)

        Return DataOrdenServicio

    End Function

    Public Shared Function getPedidoERP(ByVal pPed As String, ByVal idReclamacion As Integer, tipoPedido As String) As Data.DataTable
        Dim DataPedido As New Data.DataTable
        Dim DataProductos As New Data.DataTable

        Dim tablaPedidoCabeceraAS400 = ConfigurationManager.AppSettings.Get("tablaPedidoCabeceraAS400")
        Dim tablaPedidoDetalleAS400 = ConfigurationManager.AppSettings.Get("tablaPedidoDetalleAS400")
        'Dim tiposPedidos = ConfigurationManager.AppSettings.Get("tiposPedidos")

        Dim sQueryPedido As String = "SELECT PDNUMCLIEN as codigoCte, PDNOMBRECL as nombreCte, PDTELEFONO as TelefonoCte, PDVENFACTU as " &
                                     "codigoVendedor FROM @PEDIDO_CABECERA WHERE PDTIPOPEDI IN ('" & tipoPedido & "') AND PDNUMPEDI = " & pPed
        Dim sQueryProductos As String = "SELECT MMNUMPEDI NoPedido, MMNUMARTIC as CodProducto FROM @PEDIDO_DETALLE WHERE MMNUMPEDI =" & pPed

        'Testing or Production Environment
        If ConfigurationManager.AppSettings.Get("Environment") = "DEV" Then
            sQueryPedido = sQueryPedido.Replace("@PEDIDO_CABECERA", "Z_RCPDMP00_PEDH")
            sQueryProductos = sQueryProductos.Replace("@PEDIDO_DETALLE", "Z_RCPDMM00_PEDD")
        Else
            sQueryPedido = sQueryPedido.Replace("@PEDIDO_CABECERA", tablaPedidoCabeceraAS400)
            sQueryProductos = sQueryProductos.Replace("@PEDIDO_DETALLE", tablaPedidoDetalleAS400)
        End If

        DataPedido = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, sQueryPedido).Tables(0)
        DataProductos = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, sQueryProductos).Tables(0)

        'Insertar Cliente desde AS400 si no existe
        If DataPedido.Rows.Count > 0 Then
            insertClienteFromAS400(DataPedido.Rows(0).Item("codigoCte"), DataPedido.Rows(0).Item("nombreCte"), DataPedido.Rows(0).Item("TelefonoCte"), "")
        End If

        For Each product As DataRow In DataProductos.Rows
            adProductoRecl(idReclamacion, product.Item("CodProducto"))

            'Insertar producto desde AS400 si no existe
            getProductoERP(product.Item("CodProducto"))

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

    Public Shared Function getComentariosCronologico(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New OdbcParameter("@id_reclamacion", id_reclamacion)

        Return ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure,
                                  "{call sp_getComentariosCronologico (?)}", New OdbcParameter() {param1}).Tables(0)

    End Function

    Public Shared Sub EnviaCorreoException(subject As String, body As String)

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

        Dim senderMail As New SmtpClient(ConfigurationManager.AppSettings.Get("smtpClient"))
        Dim obj_mail As New MailMessage()

        Dim usrName As String = ConfigurationManager.AppSettings.Get("usrRECLAM")
        Dim usrPass As String = ConfigurationManager.AppSettings.Get("pwdRECLAM")

        obj_mail.From = New MailAddress(ConfigurationManager.AppSettings.Get("Email"), ConfigurationManager.AppSettings.Get("EmailName"))
        senderMail.Port = Integer.Parse(ConfigurationManager.AppSettings.Get("PortMail"))
        senderMail.Credentials = New Net.NetworkCredential(usrName, usrPass)
        senderMail.DeliveryMethod = SmtpDeliveryMethod.Network

        Dim SendTo As String = ConfigurationManager.AppSettings.Get("developerEmail")
        obj_mail.To.Add(SendTo)

        obj_mail.IsBodyHtml = True
        obj_mail.Subject = subject
        obj_mail.Body = body

        senderMail.Send(obj_mail)
    End Sub

    Public Shared Function TestingERP(ByVal query As String) As Data.DataTable
        Dim DataTest As New Data.DataTable

        DataTest = ExecuteDataSetODBC(clsAccessData.getConnection(clsAccessData.eConn.AS400), CommandType.Text, query).Tables(0)

        Return DataTest

    End Function



#End Region

End Class
