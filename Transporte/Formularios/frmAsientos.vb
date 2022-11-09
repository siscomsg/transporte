Imports System.Data.SqlClient
Public Class frmAsientos
    Dim NumAs As String, NumPan As String
    Dim Asiento As Button, PanelPiso As Panel
    Public IdUnidad As Integer
    Friend Sub Eventos(ByVal boton As Button, ByVal pan As Panel)
        NumAs = Mid(boton.Name, 4, boton.Name.Length)
        NumPan = Mid(pan.Name, 8, 1)
        boton.Image = My.Resources.Seleccionado
        'boton.BackColor = Color.Yellow
    End Sub
#Region "Asientos"
    Private Sub cmd1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd1.Click
        Eventos(cmd1, panPiso2)
    End Sub
    Private Sub cmd2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd2.Click
        Eventos(cmd2, panPiso2)
    End Sub
    Private Sub cmd3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd3.Click
        Eventos(cmd3, panPiso2)
    End Sub
    Private Sub cmd4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd4.Click
        Eventos(cmd4, panPiso2)
    End Sub
    Private Sub cmd5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd5.Click
        Eventos(cmd5, panPiso2)
    End Sub
    Private Sub cmd6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd6.Click
        Eventos(cmd6, panPiso2)
    End Sub
    Private Sub cmd7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd7.Click
        Eventos(cmd7, panPiso2)
    End Sub
    Private Sub cmd8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd8.Click
        Eventos(cmd8, panPiso2)
    End Sub
    Private Sub cmd9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd9.Click
        Eventos(cmd9, panPiso2)
    End Sub
    Private Sub cmd10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd10.Click
        Eventos(cmd10, panPiso2)
    End Sub
    Private Sub cmd11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd11.Click
        Eventos(cmd11, panPiso2)
    End Sub
    Private Sub cmd12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd12.Click
        Eventos(cmd12, panPiso2)
    End Sub
    Private Sub cmd13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd13.Click
        Eventos(cmd13, panPiso2)
    End Sub
    Private Sub cmd14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd14.Click
        Eventos(cmd14, panPiso2)
    End Sub
    Private Sub cmd15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd15.Click
        Eventos(cmd15, panPiso2)
    End Sub
    Private Sub cmd16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd16.Click
        Eventos(cmd16, panPiso2)
    End Sub
    Private Sub cmd17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd17.Click
        Eventos(cmd17, panPiso2)
    End Sub
    Private Sub cmd18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd18.Click
        Eventos(cmd18, panPiso2)
    End Sub
    Private Sub cmd19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd19.Click
        Eventos(cmd19, panPiso2)
    End Sub
    Private Sub cmd20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd20.Click
        Eventos(cmd20, panPiso2)
    End Sub
    Private Sub cmd21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd21.Click
        Eventos(cmd21, panPiso2)
    End Sub
    Private Sub cmd22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd22.Click
        Eventos(cmd22, panPiso2)
    End Sub
    Private Sub cmd23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd23.Click
        Eventos(cmd23, panPiso2)
    End Sub
    Private Sub cmd24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd24.Click
        Eventos(cmd24, panPiso2)
    End Sub
    Private Sub cmd25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd25.Click
        Eventos(cmd25, panPiso2)
    End Sub
    Private Sub cmd26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd26.Click
        Eventos(cmd26, panPiso2)
    End Sub
    Private Sub cmd27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd27.Click
        Eventos(cmd27, panPiso2)
    End Sub
    Private Sub cmd28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd28.Click
        Eventos(cmd28, panPiso2)
    End Sub
    Private Sub cmd29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd29.Click
        Eventos(cmd29, panPiso2)
    End Sub
    Private Sub cmd30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd30.Click
        Eventos(cmd30, panPiso2)
    End Sub
    Private Sub cmd31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd31.Click
        Eventos(cmd31, panPiso2)
    End Sub
    Private Sub cmd32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd32.Click
        Eventos(cmd32, panPiso2)
    End Sub
    Private Sub cmd33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd33.Click
        Eventos(cmd33, panPiso2)
    End Sub
    Private Sub cmd34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd34.Click
        Eventos(cmd34, panPiso2)
    End Sub
    Private Sub cmd35_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd35.Click
        Eventos(cmd35, panPiso2)
    End Sub
    Private Sub cmd36_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd36.Click
        Eventos(cmd36, panPiso2)
    End Sub
    Private Sub cmd37_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd37.Click
        Eventos(cmd37, panPiso2)
    End Sub
    Private Sub cmd38_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd38.Click
        Eventos(cmd38, panPiso2)
    End Sub
    Private Sub cmd39_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd39.Click
        Eventos(cmd39, panPiso2)
    End Sub
    Private Sub cmd40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd40.Click
        Eventos(cmd40, panPiso2)
    End Sub
    Private Sub cmd41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd41.Click
        Eventos(cmd41, panPiso2)
    End Sub
    Private Sub cmd42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd42.Click
        Eventos(cmd42, panPiso2)
    End Sub
    Private Sub cmd43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd43.Click
        Eventos(cmd43, panPiso2)
    End Sub
    Private Sub cmd44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd44.Click
        Eventos(cmd44, panPiso2)
    End Sub
    Private Sub cmd45_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd45.Click
        Eventos(cmd45, panPiso2)
    End Sub
    Private Sub cmd46_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd46.Click
        Eventos(cmd46, panPiso2)
    End Sub
    Private Sub cmd47_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd47.Click
        Eventos(cmd47, panPiso2)
    End Sub
    Private Sub cmd48_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd48.Click
        Eventos(cmd48, panPiso2)
    End Sub
    Private Sub cmd49_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd49.Click
        Eventos(cmd49, panPiso2)
    End Sub
    Private Sub cmd50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd50.Click
        Eventos(cmd50, panPiso2)
    End Sub
    Private Sub cmd51_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd51.Click
        Eventos(cmd51, panPiso2)
    End Sub
    Private Sub cmd52_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd52.Click
        Eventos(cmd52, panPiso2)
    End Sub
    Private Sub cmd53_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd53.Click
        Eventos(cmd53, panPiso2)
    End Sub
    Private Sub cmd54_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd54.Click
        Eventos(cmd54, panPiso2)
    End Sub
    Private Sub cmd55_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd55.Click
        Eventos(cmd55, panPiso2)
    End Sub
    Private Sub cmd56_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd56.Click
        Eventos(cmd56, panPiso2)
    End Sub
    Private Sub cmd57_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd57.Click
        Eventos(cmd57, panPiso2)
    End Sub
    Private Sub cmd58_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd58.Click
        Eventos(cmd58, panPiso2)
    End Sub
    Private Sub cmd59_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd59.Click
        Eventos(cmd59, panPiso2)
    End Sub
    Private Sub cmd60_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd60.Click
        Eventos(cmd60, panPiso2)
    End Sub
    Private Sub cmd61_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd61.Click
        Eventos(cmd61, panPiso2)
    End Sub
    Private Sub cmd62_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd62.Click
        Eventos(cmd62, panPiso2)
    End Sub
    Private Sub cmd63_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd63.Click
        Eventos(cmd63, panPiso1)
    End Sub
    Private Sub cmd64_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd64.Click
        Eventos(cmd64, panPiso1)
    End Sub
    Private Sub cmd65_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd65.Click
        Eventos(cmd65, panPiso1)
    End Sub
    Private Sub cmd66_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd66.Click
        Eventos(cmd66, panPiso1)
    End Sub
    Private Sub cmd67_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd67.Click
        Eventos(cmd67, panPiso1)
    End Sub
    Private Sub cmd68_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd68.Click
        Eventos(cmd68, panPiso1)
    End Sub
    Private Sub cmd69_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd69.Click
        Eventos(cmd69, panPiso1)
    End Sub
    Private Sub cmd70_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd70.Click
        Eventos(cmd70, panPiso1)
    End Sub
    Private Sub cmd71_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd71.Click
        Eventos(cmd71, panPiso1)
    End Sub
    Private Sub cmd72_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd72.Click
        Eventos(cmd72, panPiso1)
    End Sub
    Private Sub cmd73_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd73.Click
        Eventos(cmd73, panPiso1)
    End Sub
    Private Sub cmd74_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd74.Click
        Eventos(cmd74, panPiso1)
    End Sub
    Private Sub cmd75_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd75.Click
        Eventos(cmd75, panPiso1)
    End Sub
    Private Sub cmd76_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd76.Click
        Eventos(cmd76, panPiso1)
    End Sub
    Private Sub cmd77_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd77.Click
        Eventos(cmd77, panPiso1)
    End Sub
    Private Sub cmd78_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd78.Click
        Eventos(cmd78, panPiso1)
    End Sub
#End Region
#Region "Generales"
    Private Sub frmAsientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For x = 1 To 78
            frmCargaAs.ProgressBar1.Value = x
        Next
    End Sub
    Private Sub frmAsientos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        IdUnidad = Nothing
    End Sub

    Private Sub cmdCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCambiar.Click
        PanelPiso = DirectCast(Controls("PanPiso" & NumPan), Panel)
        Asiento = DirectCast(PanelPiso.Controls("cmd" & NumAs), Button)
        Dim numero As String = InputBox("Ingrese Numero", "Cambio de Numeración de Asiento")
        Asiento.Text = numero
        Asiento.Image = My.Resources.libre
        Asiento.Refresh()
    End Sub

    Private Sub cmdOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOcultar.Click
        PanelPiso = DirectCast(Controls("PanPiso" & NumPan), Panel)
        Asiento = DirectCast(PanelPiso.Controls("cmd" & NumAs), Button)
        Asiento.Visible = False
    End Sub

    Private Sub cmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMostrar.Click
        Dim a As Integer
        Me.ProgressBar1.Visible = True
        If Me.panPiso1.Visible = False Then
            a = 62
        Else
            a = 78
        End If
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = a
        Me.ProgressBar1.Value = 1
        For x = 1 To a
            Me.ProgressBar1.Value = x
            If x <= 62 Then
                Asiento = DirectCast(panPiso2.Controls("cmd" & x), Button)
            Else
                Asiento = DirectCast(panPiso1.Controls("cmd" & x), Button)
            End If
            If Asiento.Visible = False Then
                Asiento.Visible = True
                Asiento.Image = My.Resources.libre
            End If
        Next
        Me.ProgressBar1.Visible = False
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Dim a As Integer, b As Integer, c As String
        If panPiso1.Visible = False Then
            a = 62
        Else
            a = 78
        End If
        Try
            For x = 1 To a
                If x <= 62 Then
                    Asiento = DirectCast(panPiso2.Controls("cmd" & x), Button)
                Else
                    Asiento = DirectCast(panPiso1.Controls("cmd" & x), Button)
                End If
                'Aqui se busca si localizacion de cada asiento
                b = Mid(Asiento.Name, 4, Asiento.Name.Length)
                If b Mod 2 = 0 Then
                    c = "Pasillo"
                Else
                    c = "Ventana"
                End If
                'comenzamos a guardar los datos
                Using cmdgrabar As New SqlCommand("Insert Into Base_AsBus Values(@Id_Bus, @Asiento_Bus, @NumAs_Bus, @PosAs_Bus, @EstAs_Bus)", con)
                    cmdgrabar.Parameters.Clear()
                    cmdgrabar.Parameters.AddWithValue("@Id_Bus", IdUnidad)
                    cmdgrabar.Parameters.AddWithValue("@Asiento_Bus", Asiento.Name)
                    cmdgrabar.Parameters.AddWithValue("@NumAs_Bus", Asiento.Text)
                    cmdgrabar.Parameters.AddWithValue("@PosAs_Bus", c)
                    cmdgrabar.Parameters.AddWithValue("@EstAs_Bus", Asiento.Visible)
                    con.Open()
                    cmdgrabar.ExecuteNonQuery()
                    con.Close()
                End Using
            Next
            MessageBox.Show("Datos Guardados Exitosamente.... ")
            Me.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
#End Region

    
End Class