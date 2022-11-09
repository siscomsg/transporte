Imports System.Data.SqlClient
Public Class FrmReporte

    Private Sub FrmReporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim Sql As String = "Select BB.Placa_Bus, Count(Distinct BV.Id_Bus) as Viajes , " & _
                            "Count (Id_Pasaje) as Vendidos, " & _
                            "((BB.Asientos1_Bus + BB.Asientos2_Bus) - Count (Id_Pasaje)) as Libres, " & _
                            "Sum(BP.Desc_Pasaje) as Descuentos, " & _
                            "Sum(BP.Inc_Pasaje) as Incrementos, " & _
                            "Sum(BP.Parcial_Pasaje) as Parcial " & _
                            "From Base_Viajes BV " & _
                            "Inner Join Base_Bus BB On BV.Id_Bus = BB.Id_Bus " & _
                            "Inner Join Base_Pasaje BP On BV.Id_Viaje = BP.Id_Viaje " & _
                            "Where BP.Id_EstAs = 1 And BV.Estado_Viaje = 1 " & _
                            "And (BV.Fec_Salida Between '" & Me.dtpInicio.Value.Date & "' And '" & Me.dtpFin.Value.Date & "')" & _
                            "Group By BB.Placa_Bus, BV.Id_Bus, BB.Asientos1_Bus, BB.Asientos2_Bus"
        Call Cargar_Grid(Me.gridReporte, Sql)
        Me.gridReporte.RowHeadersWidth = 30
        Me.gridReporte.Columns.Item(0).HeaderText = "Placa"
        Me.gridReporte.Columns.Item(1).HeaderText = "Viajes"
        Me.gridReporte.Columns.Item(2).HeaderText = "Vendidos"
        Me.gridReporte.Columns.Item(3).HeaderText = "Libres"
        Me.gridReporte.Columns.Item(4).HeaderText = "S/. Descuentos"
        Me.gridReporte.Columns.Item(5).HeaderText = "S/. Incrementos"
        Me.gridReporte.Columns.Item(6).HeaderText = "Total S/."
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(Me.gridReporte, "Exportación de Datos Del: " & Me.dtpInicio.Value.Date & " Al: " & Me.dtpFin.Value.Date)
    End Sub
End Class