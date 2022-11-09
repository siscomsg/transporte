Public Class FrmRepGral
    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim Sql As String = "Select BP.Id_Pasaje, (BC.Apat_Cliente + ' ' + BC.Amat_Cliente + ' ' + Nom_Cliente) as Cliente, " & _
                            "BB.Placa_Bus, BU.Ubigeo, BV.Fec_Salida, BV.Hora_Salida, " & _
                            "BP.NumAs_Pasaje, UbicAs_Pasaje, BG.Color_Gestion, BP.Costo_Pasaje, " & _
                            "BP.Desc_Pasaje, BP.Inc_Pasaje, BP.Parcial_Pasaje, Convert(char(8),BP.Hora_Pasaje,108) as HoraPasaje " & _
                            "From Base_Pasaje BP " & _
                            "Inner Join Base_Clientes BC On BP.Id_Cliente = BC.Id_Cliente " & _
                            "Inner Join Base_Viajes BV On BP.Id_Viaje = BV.Id_Viaje " & _
                            "Inner Join Base_Bus BB On BV.Id_Bus = BB.Id_Bus " & _
                            "Inner Join Base_Ubigeo BU On BV.Id_Destino = BU.Id_Ubigeo " & _
                            "Inner Join Base_Gestion BG On BP.Id_EstAs = BG.Id_Gestion " & _
                            "Where BP.Id_EstAs = 1 And (BP.Fecha_Pasaje Between " & _
                            "'" & Me.dtpInicio.Value.Date & "' And '" & Me.dtpFin.Value.Date & "')"
        ' Substring(Convert(char(38),BP.Hora_Pasaje,121),12,8) as HoraPasaje "
        Call Cargar_Grid(Me.gridReporte, Sql)
        Me.gridReporte.RowHeadersWidth = 30
        Me.gridReporte.Columns.Item(0).HeaderText = "Boleto"
        Me.gridReporte.Columns.Item(1).HeaderText = "Cliente"
        Me.gridReporte.Columns.Item(2).HeaderText = "Placa"
        Me.gridReporte.Columns.Item(3).HeaderText = "Destino"
        Me.gridReporte.Columns.Item(4).HeaderText = "Fecha Salida"
        'Me.gridReporte.Columns.Item(4).DefaultCellStyle.Format = "HH:mm"
        Me.gridReporte.Columns.Item(5).HeaderText = "Hora Salida"
        Me.gridReporte.Columns.Item(6).HeaderText = "# Asiento"
        Me.gridReporte.Columns.Item(7).HeaderText = "Ubicación"
        Me.gridReporte.Columns.Item(8).HeaderText = "Estado"
        Me.gridReporte.Columns.Item(9).HeaderText = "Costo Pasaje"
        Me.gridReporte.Columns.Item(10).HeaderText = "S/. Descuentos"
        Me.gridReporte.Columns.Item(11).HeaderText = "S/. Incrementos"
        Me.gridReporte.Columns.Item(12).HeaderText = "Total S/."
        Me.gridReporte.Columns.Item(13).HeaderText = "Hora Venta"
        'Me.gridReporte.Columns.Item(13).DefaultCellStyle.Format = "HH:mm  "
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(Me.gridReporte, "Exportación de Datos Del: " & Me.dtpInicio.Value.Date & " Al: " & Me.dtpFin.Value.Date)
    End Sub

    Private Sub FrmRepGral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class