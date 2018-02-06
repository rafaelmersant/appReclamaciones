Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports wsClientes
Imports wsFacturas
Imports wsProductos
Imports wsPedidos
Imports wsVendedores


Public Class clsReclamaciones

#Region "INSERT's"

    Public Shared Function guardaReclamacion(ByVal pedido As String, ByVal descripcion As String, ByVal cliente As String, _
ByVal contacto As String, ByVal factura As String, ByVal ventas As String, ByVal telefono As String, ByVal vendedor As Decimal, ByVal planta As Integer, _
ByVal conclusion As String, ByVal creadapor As String, ByVal soporteVta As String, ByVal correo As String, ByVal tipoDoc As String, ByVal chofer As String, _
    ByVal transportista As String) As Integer
        Dim param1 As New SqlParameter("@pedido", pedido)
        Dim param2 As New SqlParameter("@descripcion", descripcion)
        Dim param3 As New SqlParameter("@cliente", cliente)
        Dim param4 As New SqlParameter("@contacto", contacto)
        Dim param5 As New SqlParameter("@factura", factura)
        Dim param6 As New SqlParameter("@ventas", ventas)
        Dim param7 As New SqlParameter("@telefono", telefono)
        Dim param8 As New SqlParameter("@vendedor", vendedor)
        Dim param9 As New SqlParameter("@planta", planta)
        Dim param10 As New SqlParameter("@conclusion", conclusion)
        Dim param11 As New SqlParameter("@creadapor", creadapor)
        Dim param12 As New SqlParameter("@soporte", soporteVta)
        Dim param13 As New SqlParameter("@correo", correo)
        Dim param14 As New SqlParameter("@tipoDoc", tipoDoc)
        Dim param15 As New SqlParameter("@chofer", chofer)
        Dim param16 As New SqlParameter("@transportista", transportista)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), _
        CommandType.StoredProcedure, "sp_guardaReclamacion", New SqlParameter() {param1, param2, _
                                                                    param3, param4, param5, param6, _
                                                                    param7, param8, param9, param10, _
                                                                    param11, param12, param13, param14, param15, param16})

    End Function

    Public Shared Function guardaComentario(ByVal id_recla As Integer, ByVal comentario As String, ByVal id_usuario As String, ByVal depto As Integer) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_recla)
        Dim param2 As New SqlParameter("@comentario", comentario)
        Dim param3 As New SqlParameter("@id_usuario", id_usuario)
        Dim param4 As New SqlParameter("@depto", depto)

        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_guardaComentario", New SqlParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function guardaDescrpRecl(ByVal id_recla As Integer, ByVal descrp As String) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_recla)
        Dim param2 As New SqlParameter("@descripcion", descrp)
    
        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_guardaReclDescrp", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function guardaCorreo(ByVal id_recla As Integer, ByVal correo As String) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_recla)
        Dim param2 As New SqlParameter("@correo", correo)

        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_guardaCorreo", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function setUsuarioReclamacion(ByVal id_recla As Integer, ByVal usuario As String) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_recla)
        Dim param2 As New SqlParameter("@id_usuario", usuario)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_setUsrReclamacion", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function guardaUsuario(ByVal usuario As String, ByVal contrasena As String, ByVal idempleado As Decimal, _
ByVal nombre As String, ByVal depto As Integer, ByVal correo As String, ByVal nivel As Integer, ByVal status As String) As Integer
        Dim param1 As New SqlParameter("@usuario", usuario)
        Dim param2 As New SqlParameter("@contrasena", contrasena)
        Dim param3 As New SqlParameter("@idempleado", idempleado)
        Dim param4 As New SqlParameter("@nombre", nombre)
        Dim param5 As New SqlParameter("@depto", depto)
        Dim param6 As New SqlParameter("@correo", correo)
        Dim param7 As New SqlParameter("@nivel", nivel)
        Dim param8 As New SqlParameter("@status", status)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_newUsr", New SqlParameter() {param1, param2, param3, param4, param5, param6, param7, param8})

    End Function

    Public Shared Function insertMotivo(ByVal motivo As String, ByVal id_motivo As Integer) As Integer
        Dim param1 As New SqlParameter("@descripcion", motivo)
        Dim param2 As New SqlParameter("@id_motivo", id_motivo)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertMotivo", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function insertGrupo(ByVal grupo As String, ByVal id_grupo As Integer) As Integer
        Dim param1 As New SqlParameter("@grupo", grupo)
        Dim param2 As New SqlParameter("@id_grupo", id_grupo)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertGrupo", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function insertUsrToGrupo(ByVal grupo_id As Integer, ByVal usuario As String) As Integer
        Dim param1 As New SqlParameter("@id_grupo", grupo_id)
        Dim param2 As New SqlParameter("@usuario", usuario)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertUsrToGrupo", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function insertArea(ByVal area As String) As Integer
        Dim param1 As New SqlParameter("@area", area)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertArea", New SqlParameter() {param1})

    End Function

    Public Shared Function insertProducto(ByVal producto As String) As Integer
        Dim param1 As New SqlParameter("@descripcion", producto)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_insertProducto", New SqlParameter() {param1})

    End Function

    Public Shared Function adProductoRecl(ByVal id_reclamacion As Integer, ByVal cod_prod As String) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New SqlParameter("@cod_prod", cod_prod)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_addProductosRecl", New SqlParameter() {param1, param2})

    End Function
#End Region

#Region "UPDATE's"

    Public Shared Function closeReclamacion(ByVal id_recla As Integer, ByVal conclusion As String, ByVal area As Integer, _
    ByVal motivo As Integer, ByVal monto As Decimal, ByVal ncnd As String, ByVal moneda As String, ByVal cantidad As Decimal, _
    ByVal metrica As String) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_recla)
        Dim param2 As New SqlParameter("@conclusion", conclusion)
        Dim param3 As New SqlParameter("@area", area)
        Dim param4 As New SqlParameter("@motivo", motivo)
        Dim param5 As New SqlParameter("@monto", monto)
        Dim param6 As New SqlParameter("@ncnd", ncnd)
        Dim param7 As New SqlParameter("@moneda", moneda)
        Dim param8 As New SqlParameter("@cantidad", cantidad)
        Dim param9 As New SqlParameter("@metrica", metrica)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), _
        CommandType.StoredProcedure, "sp_closeReclamacion", New SqlParameter() {param1, param2, param3, param4, param5, _
                                                                                param6, param7, param8, param9})

    End Function

#End Region

#Region "DELETE's"

    Public Shared Function delGrupoUsr(ByVal grupo As Integer, ByVal usr As String) As Integer
        Dim param1 As New SqlParameter("@grupo_id", grupo)
        Dim param2 As New SqlParameter("@usuario", usr)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delGrupoUsr", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function delUsuario(ByVal codigo As Decimal) As Integer
        Dim param1 As New SqlParameter("@idempleado", codigo)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delUsuario", New SqlParameter() {param1})

    End Function

    Public Shared Function delGrupo(ByVal grupo As Integer) As Integer
        Dim param1 As New SqlParameter("@id_grupo", grupo)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delGrupo", New SqlParameter() {param1})

    End Function

    Public Shared Function delMotivo(ByVal motivo As Integer) As Integer
        Dim param1 As New SqlParameter("@id_motivo", motivo)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delMotivo", New SqlParameter() {param1})

    End Function

    Public Shared Function delArea(ByVal area As Integer) As Integer
        Dim param1 As New SqlParameter("@id_area", area)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delArea", New SqlParameter() {param1})

    End Function

    Public Shared Function delProducto(ByVal producto As Integer) As Integer
        Dim param1 As New SqlParameter("@id_producto", producto)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delProductosRecl", New SqlParameter() {param1})

    End Function

    Public Shared Function delReclamacion(ByVal id_reclamacion As Integer) As Integer
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delReclamacion", New SqlParameter() {param1})

    End Function

    Public Shared Function delComentario(ByVal id_comentario As Integer) As Integer
        Dim param1 As New SqlParameter("@id_comentario", id_comentario)

        Return SqlHelper.ExecuteNonQuery(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_delComentario", New SqlParameter() {param1})

    End Function

#End Region

#Region "GET's"

    Public Shared Function getReclamacionToCliente(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_ReporteToCliente", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function validaUsr(ByVal usuario As String, ByVal contrasena As String) As DataTable
        Dim param1 As New SqlParameter("@usuario", usuario)
        Dim param2 As New SqlParameter("@contrasena", contrasena)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_validaUsr", New SqlParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getClientes() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getClientes").Tables(0)

    End Function

    Public Shared Function getVendedores() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getVendedores").Tables(0)

    End Function

    Public Shared Function getPlantas() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getPlantas").Tables(0)

    End Function

    Public Shared Function getPedido(ByVal pedido As Decimal, ByVal tipo As String) As DataTable
        Dim param1 As New SqlParameter("@pedido", pedido)
        Dim param2 As New SqlParameter("@tipo", tipo)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getPedido", New SqlParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getReclamaciones(ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamaciones", New SqlParameter() {param1})

    End Function

    Public Shared Function getReclamacionesForExcel(ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionesForExcel", New SqlParameter() {param1})

    End Function

    Public Shared Function getReclamacion(ByVal id_reclamacion As Integer, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacion", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByFecha(ByVal fechaI As String, ByVal fechaF As String, ByVal estatus As String, ByVal ventas As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@fechaI", fechaI)
        Dim param2 As New SqlParameter("@fechaF", fechaF)
        Dim param3 As New SqlParameter("@estatus", estatus)
        Dim param4 As New SqlParameter("@ventas", ventas)
        Dim param5 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByFecha", New SqlParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getReclamacionByClienteToExcel(ByVal cliente As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@cliente", cliente)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByClienteToExcel", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByFechaToExcel(ByVal fechaI As String, ByVal fechaF As String, ByVal estatus As String, ByVal ventas As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@fechaI", fechaI)
        Dim param2 As New SqlParameter("@fechaF", fechaF)
        Dim param3 As New SqlParameter("@estatus", estatus)
        Dim param4 As New SqlParameter("@ventas", ventas)
        Dim param5 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByFechaToExcel", New SqlParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getReclamacionByDescrp(ByVal Descrp As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@descrp", Descrp)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByDescrp", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByCliente(ByVal Cliente As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@cliente", Cliente)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByCliente", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByMotivo(ByVal Motivo As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@motivo", Motivo)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Dim param3 As New SqlParameter("@fechaI", fechaI)
        Dim param4 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByMotivo", New SqlParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByMotivoToExcel(ByVal Motivo As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@motivo", Motivo)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Dim param3 As New SqlParameter("@fechaI", fechaI)
        Dim param4 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByMotivoToExcel", New SqlParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByArea(ByVal area As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@area", area)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Dim param3 As New SqlParameter("@fechaI", fechaI)
        Dim param4 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByArea", New SqlParameter() {param1, param2, param3, param4})

    End Function

    Public Shared Function getReclamacionByAreaToExcel(ByVal area As Integer, ByVal usuario As String, ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@area", area)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Dim param3 As New SqlParameter("@fechaI", fechaI)
        Dim param4 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByAreaToExcel", New SqlParameter() {param1, param2, param3, param4})

    End Function


    Public Shared Function getReclamacionByFactura(ByVal factura As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@factura", factura)
        Dim param2 As New SqlParameter("@usuario", usuario)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByFactura", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByChofer(ByVal chofer As String, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@chofer", chofer)
        Dim param2 As New SqlParameter("@usuario", usuario)
        
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByChofer", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionByTransportista(ByVal transportista As Integer, ByVal usuario As String) As DataSet
        Dim param1 As New SqlParameter("@transportista", transportista)
        Dim param2 As New SqlParameter("@usuario", usuario)
        
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionByTransportista", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionDetalle(ByVal id_reclamacion As Integer) As DataTable
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionDetalle", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getReclamacionPatron(ByVal mes As Integer, ByVal pyear As Integer) As DataTable
        Dim param1 As New SqlParameter("@mes", mes)
        Dim param2 As New SqlParameter("@pyear", pyear)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionPatron", New SqlParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getComentarios(ByVal id_reclamacion As Integer, ByVal depto As Integer) As DataTable
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)
        Dim param2 As New SqlParameter("@depto", depto)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getComentarios", New SqlParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getUltimaReclamacion() As Integer
        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUltReclamacion")

    End Function

    Public Shared Function getUsuarios(ByVal pGrupo As Integer) As DataTable
        Dim param1 As New SqlParameter("@id_grupo", pGrupo)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuarios", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getDeptos() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDeptos").Tables(0)

    End Function

    Public Shared Function getAreas() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getAreas").Tables(0)

    End Function

    Public Shared Function getUsuariosGrid(ByVal usuario As String) As DataTable
        Dim param1 As New SqlParameter("@usuario", usuario)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuariosGrid", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getNiveles() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getNiveles").Tables(0)

    End Function

    Public Shared Function getMotivos() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getMotivos").Tables(0)

    End Function

    Public Shared Function getGrupos() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getGrupos").Tables(0)

    End Function

    Public Shared Function getGruposUsrs() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsrsGrupos").Tables(0)

    End Function

    Public Shared Function getProductos() As DataTable
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductos").Tables(0)

    End Function

    Public Shared Function getProducto(ByVal producto As String) As DataTable
        Dim param1 As New SqlParameter("@producto", producto)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProducto", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsrNoEstanReclamacion(ByVal reclamacion As Integer) As DataTable
        Dim param1 As New SqlParameter("@id_reclamacion", reclamacion)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsrNoEstanReclamacion", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getUsrEstanReclamacion(ByVal reclamacion As Integer) As DataTable
        Dim param1 As New SqlParameter("@id_reclamacion", reclamacion)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsrEstanReclamacion", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function setArchivo(ByVal ruta As String, ByVal extension As String, ByVal area As String, ByVal id_reclamacion As Integer, ByVal id_comentario As Integer) As String
        Dim param1 As New SqlParameter("@ruta", ruta)
        Dim param2 As New SqlParameter("@archivo", extension)
        Dim param3 As New SqlParameter("@area", area)
        Dim param4 As New SqlParameter("@id_reclamacion", id_reclamacion)
        Dim param5 As New SqlParameter("@id_comentario", id_comentario)

        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_setArchivo", New SqlParameter() {param1, param2, param3, param4, param5})

    End Function

    Public Shared Function getArchivos(ByVal area As String, ByVal id_comentario As Integer) As DataTable
        Dim param1 As New SqlParameter("@area", area)
        Dim param2 As New SqlParameter("@id_comentario", id_comentario)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getArchivos", New SqlParameter() {param1, param2}).Tables(0)

    End Function

    Public Shared Function getUsuario(ByVal usuario As String) As Integer
        Dim param1 As New SqlParameter("@usuario", usuario)

        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getUsuario", New SqlParameter() {param1})

    End Function

    Public Shared Function getReclamacionRpt(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@fechaI", fechaI)
        Dim param2 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamacionesRpt", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRptAM(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@fechaI", fechaI)
        Dim param2 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCByAreaMotivo", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRptAMC(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@fechaI", fechaI)
        Dim param2 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCByAreaMotivo_Cerrada", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionesExcedidas(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@pFechaI", fechaI)
        Dim param2 As New SqlParameter("@pFechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getReclamExcedidas", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getReclamacionRpt15D() As DataSet
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getRCMasDe15Dias")

    End Function

    Public Shared Function getProductosRecl(ByVal id_reclamacion As String) As DataTable
        Dim param1 As New SqlParameter("@id_reclamacion", id_reclamacion)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductosRecl", New SqlParameter() {param1}).Tables(0)

    End Function

    Public Shared Function getDocumentoExiste(ByVal documento As String, ByVal tipoDocumento As String) As String
        Dim param1 As SqlParameter

        If tipoDocumento = "F" Then
            param1 = New SqlParameter("@factura", documento)
            Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDocumentoExiste", New SqlParameter() {param1})
        Else
            param1 = New SqlParameter("@pedido", documento)
            Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDocumentoExiste", New SqlParameter() {param1})
        End If


    End Function

    Public Shared Function getReclamacionRRM(ByVal fechaI As String, ByVal fechaF As String) As DataSet
        Dim param1 As New SqlParameter("@fechaI", fechaI)
        Dim param2 As New SqlParameter("@fechaF", fechaF)
        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_ReporteMensualReclamaciones", New SqlParameter() {param1, param2})

    End Function

    Public Shared Function getChofer(ByVal chofer As String) As DataSet
        Dim param1 As New SqlParameter("@chofer", chofer)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getChoferes", New SqlParameter() {param1})

    End Function

    Public Shared Function getTransportista(ByVal suplidor As String) As DataSet
        Dim param1 As New SqlParameter("@transportista", suplidor)

        Return SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getTransportistas", New SqlParameter() {param1})

    End Function

    Public Shared Function setComentProd(ByVal idProd As Integer, ByVal comentario As String) As String
        Dim param1 As New SqlParameter("@id_producto", idProd)
        Dim param2 As New SqlParameter("@comentario", comentario)

        Return SqlHelper.ExecuteScalar(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_setProductoComentario", New SqlParameter() {param1, param2})

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

    Public Shared Function getProductoSAP(ByVal cod As String) As String
        'Dim service As New wsProductos.service
        'Dim prod As New ZsdGetProductos()
        'Dim resp As New wsProductos.ZsdGetProductosResponse
        'Dim arr_prod() As wsProductos.ZsdProductos

        'arr_prod = New wsProductos.ZsdProductos(1) {}
        'arr_prod(0) = New wsProductos.ZsdProductos()
        'arr_prod(0).Matnr = cod

        'prod.Codigo = ""
        'prod.CodigoProductos = arr_prod

        'resp = service.ZsdGetProductos(prod)

        Return "Producto Ejemplo" 'resp.Productos(0).Maktx

    End Function

    Public Shared Function getProductosSAP(ByVal cod() As String) As String()
        'Dim service As New wsProductos.service
        'Dim prod As New ZsdGetProductos()
        'Dim resp As New wsProductos.ZsdGetProductosResponse
        'Dim arr_prod() As wsProductos.ZsdProductos

        'arr_prod = New wsProductos.ZsdProductos(cod.Length) {}

        'For i As Integer = 0 To cod.Length - 1
        'arr_prod(i) = New wsProductos.ZsdProductos()
        'arr_prod(i).Matnr = cod(i)
        'Next

        'prod.Codigo = ""
        'prod.CodigoProductos = arr_prod

        'resp = service.ZsdGetProductos(prod)

        Return {""} 'resp.Productos

    End Function


    Public Shared Function getClienteName(ByVal cod As String) As String
        'Dim service As New wsClientes.service
        'Dim cte As New ZsdGetClientes
        'Dim resp As New ZsdGetClientesResponse
        'Dim arr_cte() As ZsdCliente

        'If IsNumeric(Left(cod, 1)) And Not Left(cod, 1) = "0" Then
        'cod = Right("00000" & cod, 10)
        'End If

        'arr_cte = New ZsdCliente(1) {}
        'arr_cte(0) = New ZsdCliente()
        'arr_cte(0).Kunnr = cod

        'cte.Codigo = ""
        'cte.CodigoClientes = arr_cte

        'resp = service.ZsdGetClientes(cte)

        Return "Cliente Name" 'resp.Clientes(0).Name1

    End Function

    Public Shared Function getClientesSAP(ByVal cod() As String) As String()
        'Dim service As New wsClientes.service
        'Dim prod As New ZsdGetClientes()
        'Dim resp As New wsClientes.ZsdGetClientesResponse
        'Dim arr_prod() As wsClientes.ZsdCliente

        'arr_prod = New wsClientes.ZsdCliente(cod.Length) {}

        'For i As Integer = 0 To cod.Length - 1

        'If Integer.Parse(cod(i)) < 5000 Then
        'cod(i) = "ES0" & cod(i)
        'Else
        'cod(i) = Right("0000000000" & cod(i), 10)
        'End If

        'arr_prod(i) = New wsClientes.ZsdCliente()
        'arr_prod(i).Kunnr = cod(i)
        'Next

        'prod.Codigo = ""
        'prod.CodigoClientes = arr_prod

        'resp = service.ZsdGetClientes(prod)

        Return {""} 'resp.Clientes

    End Function

    Public Shared Function getVendedorName(ByVal cod As String) As String
        'Dim service As New wsVendedores.service
        'Dim vend As New ZsdGetVendedores
        'Dim resp As New ZsdGetVendedoresResponse
        'Dim arr_vend() As ZsdVendedor

        'cod = Right("000" & cod, 3)

        'arr_vend = New ZsdVendedor(1) {}
        'arr_vend(0) = New ZsdVendedor()
        'arr_vend(0).Vkgrp = cod

        'vend.Codigo = ""
        'vend.CodigoVendedores = arr_vend

        'resp = service.ZsdGetVendedores(vend)

        Return "Nombre Vendedor" 'resp.Vendedores(0).Bezei

    End Function

    Public Shared Function getFactura(ByVal pFact As String, ByVal idReclamacion As Integer) As Data.DataTable
        'Dim service As New wsFacturas.service
        'Dim fact As New ZsdGetFacturas
        'Dim resp As New ZsdGetFacturasResponse
        Dim cte As String
        Dim datos() As String
        'Dim productos() As wsFacturas.ZsdProductos

        'fact.Codigo = pFact
        'resp = service.ZsdGetFacturas(fact)

        Dim param1 As New SqlParameter("@factura", pFact)
        Dim DataFactura As New Data.DataTable
        Dim DataProductos As New Data.DataTable

        DataFactura = SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getDatosFacturaAX", New SqlParameter() {param1}).Tables(0)
        DataProductos = SqlHelper.ExecuteDataset(clsAccessData.getConnection(clsAccessData.eConn.SQL), CommandType.StoredProcedure, "sp_getProductosByFacturaAX", New SqlParameter() {param1}).Tables(0)

        For Each product As DataRow In DataProductos.Rows
            adProductoRecl(idReclamacion, product.Item("codProducto"))
        Next

        cte = "Nombre del Cliente" 'getClienteSAP(resp.Facturas(0).Kunrg)

        'Parameters:
        '0-Codigo de Vendedor
        '1-Nombre de Vendedor
        '2-Codigo de Cliente
        '3-Nombre de Cliente
        '4-
        '5-Venta Local / Internacional
        datos = New String() {"001", "Rafa Vendedor", _
        "001", "Rafa Cliente", "", "VE"}

        Return DataFactura

    End Function

    Public Shared Function getPedidoERP(ByVal pPed As String, ByVal idReclamacion As Integer) As String()
        'Dim service As New wsPedidos.service
        'Dim ped As New ZsdGetPedidos
        'Dim resp As New ZsdGetPedidosResponse
        Dim cte As String
        Dim datos() As String
        'Dim productos() As wsPedidos.ZsdProductos

        'ped.Codigo = pPed
        'resp = service.ZsdGetPedidos(ped)

        'productos = resp.Pedidos(0).Productos()
        Dim productos() As String = {"PROD45", "PROD65", "PROD78"}

        For Each product As String In productos
            adProductoRecl(idReclamacion, product)
        Next

        cte = "Nombre del Cliente" 'getClienteName(resp.Pedidos(0).Kunnr)

        'Parameters:
        '0-Codigo de Vendedor
        '1-Nombre de Vendedor
        '2-Codigo de Cliente
        '3-Nombre de Cliente
        '4-
        '5-Venta Loca / Internacional
        '6-Motivo (eliminar este parametro)
        datos = New String() {"005", "Test Vendedor", _
        "009", cte, "", "VE", ""}

        Return datos

    End Function
#End Region

End Class
