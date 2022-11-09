Imports System.Data.SqlClient
Public Class FrmListaViajes
    Dim idViaje As Integer
    Private Sub FrmListaViajes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LlenaGrid()
    End Sub

    Private Sub gridViajes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridViajes.Click
        idViaje = Me.gridViajes.Item(0, Me.gridViajes.CurrentCell.RowIndex).Value.ToString()
    End Sub

    Private Sub cmdQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuitar.Click
        Dim Resp As String
        Resp = MsgBox("Realmente Eliminara Este Viaje??", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Eliminar Viajes")
        If Resp = vbYes Then
            Dim sql As String = "Delete From Base_Viajes Where Id_Viaje = @IdViaje "
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@IdViaje", idViaje)
                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("Eliminado Exitosamentte...")
                    Call LlenaGrid()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End If
    End Sub
    Friend Sub LlenaGrid()
        Call Cargar_Grid(Me.gridViajes, "Select BV.Id_Viaje, BV.Fec_Salida, BV.Hora_Salida, BU.Ubigeo, " & _
                                        "BB.Placa_Bus, BB.Pisos_Bus, (BC.Apat_Conduct + ' ' + " & _
                                        "BC.Amat_Conduct + ' ' + BC.Nombres_Conduct) as Conductor " & _
                                        "From Base_Viajes BV " & _
                                        "Inner Join Base_Bus BB On BV.Id_Bus = BB.Id_Bus " & _
                                        "Inner Join Base_Conduct BC On BV.Id_Conduct1 = BC.Id_Conduct " & _
                                        "Inner Join Base_Ubigeo BU On BV.Id_Destino = BU.Id_Ubigeo " & _
                                        "Where BV.Id_Origen = '" & codubi_user & "' And BV.Estado_Viaje = 1 Order By BV.Fec_Salida, BV.Hora_Salida Asc;")
        Me.gridViajes.BackgroundColor = Color.AliceBlue
        Me.gridViajes.Columns.Item(0).Visible = False
        Me.gridViajes.Columns.Item(1).HeaderText = "Fecha"
        Me.gridViajes.Columns.Item(2).HeaderText = "Hora"
        Me.gridViajes.Columns.Item(3).HeaderText = "Destino"
        Me.gridViajes.Columns.Item(4).HeaderText = "Placa"
        Me.gridViajes.Columns.Item(5).HeaderText = "Pisos"
        Me.gridViajes.Columns.Item(6).HeaderText = "Conductor"
        Me.gridViajes.Columns.Item(1).Width = 70
        Me.gridViajes.Columns.Item(2).Width = 60
        Me.gridViajes.Columns.Item(3).Width = 100
        Me.gridViajes.Columns.Item(4).Width = 60
        Me.gridViajes.Columns.Item(5).Width = 50
        Me.gridViajes.Columns.Item(6).Width = 200
    End Sub
End Class