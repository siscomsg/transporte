Imports System.Data.SqlClient
Public Class FrmViajes
    Dim pisos As Integer
    Private Sub FrmViajes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargaCbo(Me.cboPlaca, "Select * From Base_Bus Where Estado_Bus = 1 Order By Placa_Bus ASC;", 0, 1)
        Call CargaCbo(Me.cboPiloto, "Select Id_Conduct, (Apat_Conduct + ' ' + Amat_Conduct + ' '+ Nombres_Conduct) as Nombres From Base_Conduct Where Estado_Conduct = 1 Order By Nombres ", 0, 1)
        Call CargaCbo(Me.cboCopiloto, "Select Id_Conduct, (Apat_Conduct + ' ' + Amat_Conduct + ' '+ Nombres_Conduct) as Nombres From Base_Conduct Where Estado_Conduct = 1 Order By Nombres ", 0, 1)
        Call CargaCbo(Me.cboOrigen, "Select Id_Ubigeo, Ubigeo From Base_Ubigeo Where Id_Ubigeo = '" & codubi_user & "'", 0, 1)
        Call CargaCbo(Me.cboDestino, "Select * From Base_Ubigeo Where Estado_Ubigeo = 1 Order By Ubigeo ASC;", 0, 1)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Me.txtAyud.Text = (Me.txtAyud.Text).ToUpper
        Using cmdgrabar As New SqlCommand("Insert Into Base_Viajes Values(@Placa_Bus, @Piloto, @Copiloto, @Ayud, @Origen, @Destino, @Fecha, @Hora, @Precio1, @precio2, @Estado)", con)
            cmdgrabar.Parameters.Clear()
            cmdgrabar.Parameters.AddWithValue("@Placa_Bus", Me.cboPlaca.SelectedValue)
            cmdgrabar.Parameters.AddWithValue("@Piloto", Me.cboPiloto.SelectedValue)
            cmdgrabar.Parameters.AddWithValue("@Copiloto", Me.cboCopiloto.SelectedValue)
            cmdgrabar.Parameters.AddWithValue("@Ayud", Me.txtAyud.Text)
            cmdgrabar.Parameters.AddWithValue("@Origen", Me.cboOrigen.SelectedValue)
            cmdgrabar.Parameters.AddWithValue("@Destino", Me.cboDestino.SelectedValue)
            cmdgrabar.Parameters.AddWithValue("@Fecha", Me.dtpFecha.Value.Date)
            cmdgrabar.Parameters.AddWithValue("@Hora", Me.txtHora.Text)
            cmdgrabar.Parameters.AddWithValue("@Precio1", Me.txtPrecio1.Text)
            cmdgrabar.Parameters.AddWithValue("@Precio2", Me.txtPrecio2.Text)
            cmdgrabar.Parameters.AddWithValue("@Estado", CBool(True))
            Try
                con.Open()
                cmdgrabar.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Datos Guardados Exitosamente.... ")
                Me.cboPlaca.Text = Nothing
                Me.cboPiloto.Text = Nothing
                Me.cboCopiloto.Text = Nothing
                Me.txtAyud.Text = Nothing
                Me.cboOrigen.Text = Nothing
                Me.cboDestino.Text = Nothing
                Me.txtHora.Text = Nothing
                Me.txtPrecio1.Text = Nothing
                Me.txtPrecio2.Text = Nothing
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboPlaca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPlaca.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.cboPiloto.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub cboPlaca_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPlaca.Leave
        Dim sql As String = "Select Pisos_Bus From Base_Bus " & _
                            "Where Id_Bus = '" & Me.cboPlaca.SelectedValue & "'"
        Try
            con.Open()
            Using cmd As New SqlCommand(sql, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                With reader.Read
                    pisos = reader.GetValue(0)
                End With
            End Using
            ' codigo_user & nombre_user & codubi_user & Ubigeo_user)
            con.Close()
            If pisos = 2 Then
                Me.txtPrecio1.Visible = True
                Me.Label11.Visible = True
                Me.Label10.Text = "2do PISO"
            Else
                Me.txtPrecio1.Visible = False
                Me.Label11.Visible = False
                Me.Label10.Text = "1er PISO"
            End If

        Catch ex As Exception
            con.Close()
            MessageBox.Show("Debe seleccionar alguna Unidad")
        End Try

    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        FrmListaViajes.MdiParent = MDIPrincipal
        FrmListaViajes.Show()
        MDIPrincipal.tsslTitulos.Text = FrmListaViajes.Text
    End Sub

    Private Sub txtAyud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAyud.LostFocus
        Me.txtAyud.Text = (Me.txtAyud.Text).ToUpper
    End Sub

    Private Sub txtHora_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHora.LostFocus
        Me.txtHora.Text = (Me.txtHora.Text).ToLower
    End Sub

    
End Class