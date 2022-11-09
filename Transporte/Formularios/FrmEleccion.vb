Imports System.Data.SqlClient
Public Class FrmEleccion

    Private Sub FrmEleccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblFecha.Text = Date.Now.ToLongDateString
        Dim sql As String = "Select Distinct BV.Id_Destino, BU.ubigeo " & _
                            "From Base_Viajes BV " & _
                            "Inner Join Base_Ubigeo BU On BV.Id_Destino = BU.Id_Ubigeo " & _
                            "Where BV.Fec_Salida = '" & CDate(Me.lblFecha.Text) & "' and Estado_Viaje=1"
        Call CargaLst(Me.lstDestinos, sql, 0, 1)
    End Sub

    Private Sub lstDestinos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDestinos.DoubleClick

        Dim sql As String = "Select Id_Viaje, Hora_Salida " & _
                            "From Base_Viajes " & _
                            "Where Fec_Salida = '" & CDate(Me.lblFecha.Text) & "' And Id_Destino = '" & Me.lstDestinos.SelectedValue & "' And Estado_Viaje=1"
        Call CargaLst(Me.lstHorarios, sql, 0, 1)

    End Sub

    Private Sub lstHorarios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstHorarios.DoubleClick
        If Me.lstHorarios.SelectedValue = Nothing Then
            Return
        End If
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = 78
        Me.ProgressBar1.Value = 1
        frmVentaPasaje.IdDeViaje = Me.lstHorarios.SelectedValue
        frmVentaPasaje.MdiParent = MDIPrincipal
        frmVentaPasaje.Show()
        MDIPrincipal.tsslTitulos.Text = frmVentaPasaje.Text
        Me.Close()
    End Sub

    
End Class