Imports CrystalDecisions.Shared
Public Class frmManifiesto
    'Asignamos el parametro al reporte
    Dim parametros As New ParameterFields()
    'Indicamos el nombre del parametro que se encuentra en el procedimiento almacenado
    Dim primerparametro As New ParameterField()
    'Tomamos el valor del parametro
    Dim discreteValor As New ParameterDiscreteValue()
    Dim IdViaje As Integer
    Private Sub frmManifiesto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Cargar_Grid(Me.gridViajes, "Select BV.Id_Viaje, BB.Placa_Bus, BB.Pisos_Bus, (BC.Apat_Conduct + ' ' + " & _
                                        "BC.Amat_Conduct + ' ' + BC.Nombres_Conduct) as Conductor, BU.Ubigeo, " & _
                                        "BV.Fec_Salida, BV.Hora_Salida From Base_Viajes BV " & _
                                        "Inner Join Base_Bus BB On BV.Id_Bus = BB.Id_Bus " & _
                                        "Inner Join Base_Conduct BC On BV.Id_Conduct1 = BC.Id_Conduct " & _
                                        "Inner Join Base_Ubigeo BU On BV.Id_Destino = BU.Id_Ubigeo " & _
                                        "Where BV.Id_Origen = '" & codubi_user & "' And BV.Estado_Viaje = 1 And BV.Fec_Salida='" & Now.Date & "' " & _
                                        "Order By BV.Fec_Salida")
        Me.gridViajes.Columns.Item(0).Visible = False
        Me.gridViajes.Columns.Item(1).HeaderText = "Placa"
        Me.gridViajes.Columns.Item(2).HeaderText = "Pisos"
        Me.gridViajes.Columns.Item(3).HeaderText = "Conductor"
        Me.gridViajes.Columns.Item(4).HeaderText = "Destino"
        Me.gridViajes.Columns.Item(5).HeaderText = "Fecha Salida"
        Me.gridViajes.Columns.Item(6).HeaderText = "Hora Salida"
        Me.gridViajes.Columns.Item(1).Width = 70
        Me.gridViajes.Columns.Item(2).Width = 50
        Me.gridViajes.Columns.Item(3).Width = 200
        Me.gridViajes.Columns.Item(4).Width = 80
        Me.gridViajes.Columns.Item(5).Width = 70
        Me.gridViajes.Columns.Item(6).Width = 60

    End Sub

    Private Sub gridViajes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridViajes.Click
        Try
            IdViaje = Me.gridViajes.Item(0, Me.gridViajes.CurrentCell.RowIndex).Value.ToString()
        Catch ex As Exception
            MessageBox.Show("Ningun Dato Valido, Revise por favor...")
        End Try

    End Sub

    Private Sub cmdCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrear.Click
        Dim pvValoresParametros As New ParameterValues
        Dim codigopers As New ParameterDiscreteValue
        Dim CRFicha As New crManifiesto
        codigopers.Value = IdViaje
        pvValoresParametros.Add(codigopers)
        CRFicha.SetDatabaseLogon("sa", "rafael")
        CRFicha.DataDefinition.ParameterFields("@IdViaje").ApplyCurrentValues(pvValoresParametros)
        Me.CrystalReportViewer1.ReportSource = CRFicha
        
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Cargar_Grid(Me.gridViajes, "Select BV.Id_Viaje, BB.Placa_Bus, BB.Pisos_Bus, (BC.Apat_Conduct + ' ' + " & _
                                        "BC.Amat_Conduct + ' ' + BC.Nombres_Conduct) as Conductor, BU.Ubigeo, " & _
                                        "BV.Fec_Salida, BV.Hora_Salida From Base_Viajes BV " & _
                                        "Inner Join Base_Bus BB On BV.Id_Bus = BB.Id_Bus " & _
                                        "Inner Join Base_Conduct BC On BV.Id_Conduct1 = BC.Id_Conduct " & _
                                        "Inner Join Base_Ubigeo BU On BV.Id_Destino = BU.Id_Ubigeo " & _
                                        "Where BV.Id_Origen = '" & codubi_user & "' And BV.Estado_Viaje = 1 " & _
                                        "Order By BV.Fec_Salida")

    End Sub
End Class