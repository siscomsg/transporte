Imports System.Data.SqlClient
Public Class frmCargaAs

    Private Sub frmTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargaLst(Me.lstBus, "Select BB.Id_Bus, BB.Placa_Bus From Base_Bus BB " & _
                                 "Left Join Base_AsBus BA On BB.Id_Bus = BA.Id_Bus " & _
                                 "Where BA.Id_Bus is Null And BB.Estado_Bus = 1", 0, 1)
    End Sub


    Private Sub lstBus_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstBus.DoubleClick
        Dim sql As String = "Select Pisos_Bus, Asientos1_Bus, Asientos2_Bus From Base_Bus Where Id_Bus = '" & Me.lstBus.SelectedValue & "' "
        Try
            con.Open()
            Using cmd As New SqlCommand(sql, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                With reader.Read
                    Me.txtPisos.Text = reader.GetValue(0)
                    Me.txtAsiento1.Text = reader.GetValue(1)
                    Me.txtAsiento2.Text = reader.GetValue(2)
                End With
            End Using
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.cmdAsignar.Enabled = True
        If chkDisenio.Checked = True Then
            cmdAsignar.Text = "&Eliminar y Diseñar"
        Else
            cmdAsignar.Text = "&Establecer Diseño"
        End If
    End Sub

    Private Sub cmdAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAsignar.Click
        Dim Resp As String
        If cmdAsignar.Text = "&Eliminar y Diseñar" Then
            Resp = MsgBox("Realmente Eliminara Diseño de Este Bus??", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Rediseñar")
            If Resp = vbYes Then
                Dim sql As String = "Delete From Base_AsBus Where Id_Bus = @IdBus "
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@IdBus", Me.lstBus.SelectedValue)
                    Try
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MessageBox.Show("Bus Fue Eliminado Exitosamentte...")
                        Call Asignar()
                    Catch ex As Exception
                        con.Close()
                        MessageBox.Show(ex.Message)
                    End Try
                End Using
            End If
        Else
            Call Asignar()
        End If
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    
    Private Sub chkDisenio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisenio.CheckedChanged
        If Me.chkDisenio.Checked = True Then
            Call CargaLst(Me.lstBus, "Select Distinct BB.Id_Bus, BB.Placa_Bus From Base_Bus BB " & _
                                 "Left Join Base_AsBus BA On BB.Id_Bus = BA.Id_Bus " & _
                                 "Where BA.Id_Bus is Not Null And BB.Estado_Bus = 1", 0, 1)
        Else
            Call CargaLst(Me.lstBus, "Select BB.Id_Bus, BB.Placa_Bus From Base_Bus BB " & _
                                 "Left Join Base_AsBus BA On BB.Id_Bus = BA.Id_Bus " & _
                                 "Where BA.Id_Bus is Null And BB.Estado_Bus = 1", 0, 1)
        End If
        
    End Sub
    Friend Sub Asignar()
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = 78
        Me.ProgressBar1.Value = 1
        frmAsientos.MdiParent = MDIPrincipal
        frmAsientos.Show()
        MDIPrincipal.tsslTitulos.Text = frmAsientos.Text
        If Me.txtPisos.Text = 1 Then
            frmAsientos.panPiso1.Visible = False
        Else
            frmAsientos.lblPiso2.Text = "Piso 2"
        End If
        frmAsientos.lblIdBus.Text = Me.lstBus.Text
        frmAsientos.lblAsPiso1.Text = Me.txtAsiento1.Text
        frmAsientos.lblAsPiso2.Text = Me.txtAsiento2.Text
        frmAsientos.IdUnidad = Me.lstBus.SelectedValue
        Me.Close()
    End Sub

    

End Class