Imports System.Data.SqlClient
Imports System.IO
Public Class frmBuses
    Dim idBus As Integer
    Private Sub frmBuses_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NumericUpDown1.Minimum = 1
        Me.NumericUpDown1.Maximum = 2
        Me.NumericUpDown1.Increment = 1
        Me.txtPiso2.Text = 0
        Me.txtPiso2.ReadOnly = True
        Call LlenaGrid()
    End Sub

    Private Sub NumericUpDown1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.Click
        If NumericUpDown1.Value = 1 Then
            Me.txtPiso2.Text = 0
            Me.txtPiso2.ReadOnly = True
            Me.txtPiso1.Focus()
        Else
            Me.txtPiso1.Focus()
            Me.txtPiso2.Text = Nothing
            Me.txtPiso2.ReadOnly = False
        End If
    End Sub
    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim sql As String
        If Me.CmdGrabar.Text = "&Grabar" Then
            sql = "Insert Into Base_Bus Values(@Placa, @Pisos, @Piso1, @Piso2, @Serie, @Imagen, @Estado)"
        Else
            sql = "Update Base_Bus Set Placa_Bus = @Placa, Pisos_Bus = @Pisos, Asientos1_Bus = @Piso1, Asientos2_Bus = @Piso2, Serie_Bus = @Serie, Imagen_Bus = @Imagen, Estado_Bus = @Estado " & _
                  "Where Id_Bus = '" & Me.idBus & "'"
            Me.CmdGrabar.Text = "&Grabar"
        End If
        Dim ms As New MemoryStream
        Me.picBus.Image.Save(ms, Me.picBus.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer

        Me.txtPlaca.Text = (Me.txtPlaca.Text).ToUpper
        Using cmdgrabar As New SqlCommand(sql, con)
            cmdgrabar.Parameters.Clear()
            cmdgrabar.Parameters.AddWithValue("@Placa", Me.txtPlaca.Text)
            cmdgrabar.Parameters.AddWithValue("@Pisos", Me.NumericUpDown1.Value)
            cmdgrabar.Parameters.AddWithValue("@Piso1", Me.txtPiso1.Text)
            cmdgrabar.Parameters.AddWithValue("@Piso2", Me.txtPiso2.Text)
            cmdgrabar.Parameters.AddWithValue("@Serie", Me.txtSerie.Text)
            cmdgrabar.Parameters.AddWithValue("@Imagen", arrImage)
            cmdgrabar.Parameters.AddWithValue("@Estado", Me.chkActivo.CheckState)
            Try
                con.Open()
                cmdgrabar.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Datos Guardados Exitosamente.... ")
                Me.txtPlaca.Text = Nothing
                Me.NumericUpDown1.Value = 1
                Me.txtPiso1.Text = Nothing
                Me.txtPiso2.Text = 0
                Me.txtSerie.Text = Nothing
                Me.txtPiso2.ReadOnly = True
                Me.txtPlaca.Focus()
                Call LlenaGrid()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub


    Private Sub txtPlaca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaca.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.NumericUpDown1.Focus()
        End If
    End Sub

    Private Sub txtPlaca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaca.LostFocus
        Me.txtPlaca.Text = (Me.txtPlaca.Text).ToUpper
    End Sub

    Private Sub txtPiso1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPiso1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPiso2.Focus()
        End If
    End Sub

    Private Sub txtPiso2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPiso2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtSerie.Focus()
        End If
    End Sub

    Private Sub txtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.CmdGrabar.Focus()
        End If
    End Sub

    Friend Sub LlenaGrid()
        Call Cargar_Grid(Me.gridBuses, "Select * From Base_Bus Order By Placa_Bus ASC;")
        Me.gridbuses.Columns.Item(0).Visible = False
        Me.gridBuses.Columns.Item(1).HeaderText = "Placa"
        Me.gridBuses.Columns.Item(2).HeaderText = "Pisos"
        Me.gridBuses.Columns.Item(3).HeaderText = "As. 1er Piso"
        Me.gridBuses.Columns.Item(4).HeaderText = "As. 2do Piso"
        Me.gridBuses.Columns.Item(5).HeaderText = "Serie"
        Me.gridBuses.Columns.Item(6).Visible = False
        Me.gridBuses.Columns.Item(1).Width = 80
        Me.gridBuses.Columns.Item(2).Width = 80
        Me.gridBuses.Columns.Item(3).Width = 80
        Me.gridBuses.Columns.Item(4).Width = 80
    End Sub

    Private Sub gridBuses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridBuses.Click
        idBus = Me.gridBuses.Item(0, Me.gridBuses.CurrentCell.RowIndex).Value.ToString()
    End Sub

    Private Sub cmdDesactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesactivar.Click
        Dim Respuesta As String = MsgBox("Bus sera Eliminado??", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Quitar Conductor")
        If Respuesta = vbYes Then
            Dim cmd As New SqlCommand("Delete From Base_Bus Where Id_Bus = '" & idBus & "'", con)
            Try
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Bus Fue Eliminado")
                Call LlenaGrid()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGarga.Click
        Call abririmagen(ofdAbre, picBus)
        Me.CmdGrabar.Enabled = True
    End Sub

    Private Sub cmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditar.Click
        Dim sql As String = "Select BB.Id_Bus, BB.Placa_Bus, BB.Pisos_Bus, BB.Asientos1_Bus, BB.Asientos2_Bus, " & _
                            "BB.Serie_Bus, BB.Estado_Bus From Base_Bus BB " & _
                            "Where BB.Id_Bus = '" & idBus & "'"
        Try
            con.Open()
            Using cmd As New SqlCommand(sql, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                With reader.Read
                    idBus = reader.GetValue(0)
                    Me.txtPlaca.Text = reader.GetString(1)
                    Me.NumericUpDown1.Value = reader.GetValue(2)
                    Me.txtPiso1.Text = reader.GetValue(3)
                    Me.txtPiso2.Text = reader.GetValue(4)
                    Me.txtSerie.Text = reader.GetValue(5)
                    Me.chkActivo.Checked = reader.GetValue(6)
                End With
            End Using
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error en la carga de datos de la unidad..." & ex.Message)
            con.Close()
            Return
        End Try
        'Aqui cargamos la imagen
        Dim ms As New MemoryStream(ExtraerImagen("Select Imagen_Bus From Base_Bus Where Id_Bus = '" & idBus & "'"))
        Me.picBus.Image = Image.FromStream(ms)
        'Cambiamos de text al button
        Me.CmdGrabar.Text = "&Actualizar"
        Me.CmdGrabar.Enabled = True
    End Sub

    
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(Me.gridBuses, "Relación General de Buses")
    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup

    End Sub

End Class