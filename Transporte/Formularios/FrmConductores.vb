Imports System.Data.SqlClient
Public Class FrmConductores
    Dim idConductor As Integer
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmConductores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LlenaGrid()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Me.txtPaterno.Text = (Me.txtPaterno.Text).ToUpper
        Me.txtMaterno.Text = (Me.txtMaterno.Text).ToUpper
        Me.txtNombres.Text = (Me.txtNombres.Text).ToUpper
        Me.txtLicencia.Text = (Me.txtLicencia.Text).ToUpper
        Using cmdgrabar As New SqlCommand("Insert Into Base_Conduct Values(@Dni, @Paterno, @Materno, @Nombres, @Licencia, @Estado)", con)
            cmdgrabar.Parameters.Clear()
            cmdgrabar.Parameters.AddWithValue("@Dni", Me.txtDni.Text)
            cmdgrabar.Parameters.AddWithValue("@Paterno", Me.txtPaterno.Text)
            cmdgrabar.Parameters.AddWithValue("@Materno", Me.txtMaterno.Text)
            cmdgrabar.Parameters.AddWithValue("@Nombres", Me.txtNombres.Text)
            cmdgrabar.Parameters.AddWithValue("@Licencia", Me.txtLicencia.Text)
            cmdgrabar.Parameters.AddWithValue("@Estado", CBool(True))
            Try
                con.Open()
                cmdgrabar.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Datos Guardados Exitosamente.... ")
                Me.txtDni.Text = Nothing
                Me.txtPaterno.Text = Nothing
                Me.txtMaterno.Text = Nothing
                Me.txtNombres.Text = Nothing
                Me.txtLicencia.Text = Nothing
                Me.txtDni.Focus()
                Call LlenaGrid()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub

    Private Sub txtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDni.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPaterno.Focus()
            Me.txtLicencia.Text = Me.txtDni.Text
        End If
    End Sub

    Private Sub txtPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaterno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtMaterno.Focus()
        End If
    End Sub

    Private Sub txtMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaterno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtNombres.Focus()
        End If
    End Sub

    Private Sub txtNombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombres.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtLicencia.Focus()
        End If
    End Sub

    Private Sub txtLicencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLicencia.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.CmdGrabar.Focus()
        End If
    End Sub
    Friend Sub LlenaGrid()
        Call Cargar_Grid(Me.gridConductores, "Select * From Base_Conduct Where Estado_Conduct = 1 Order By Apat_Conduct ASC;")
        Me.gridConductores.Columns.Item(0).Visible = False
        Me.gridConductores.Columns.Item(1).HeaderText = "Dni"
        Me.gridConductores.Columns.Item(2).HeaderText = "Ap. Paterno"
        Me.gridConductores.Columns.Item(3).HeaderText = "Ap. Materno"
        Me.gridConductores.Columns.Item(4).HeaderText = "Nombres"
        Me.gridConductores.Columns.Item(5).HeaderText = "Lic. Conducir"
        Me.gridConductores.Columns.Item(6).Visible = False
        Me.gridConductores.Columns.Item(1).Width = 70
        Me.gridConductores.Columns.Item(3).Width = 100
        Me.gridConductores.Columns.Item(4).Width = 100
        Me.gridConductores.Columns.Item(5).Width = 100
        Me.gridConductores.Columns.Item(6).Width = 50
    End Sub

    Private Sub gridConductores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridConductores.Click
        idConductor = Me.gridConductores.Item(0, Me.gridConductores.CurrentCell.RowIndex).Value.ToString()
    End Sub

    Private Sub cmdDesactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesactivar.Click
        Dim Respuesta As String = MsgBox("Datos Seran Eliminados??", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Quitar Registro")
        If Respuesta = vbYes Then
            Dim cmd As New SqlCommand("Update Base_Conduct Set Estado_Conduct = @Estado Where Id_Conduct = '" & Me.idConductor & "'", con)
            With cmd
                .Parameters.Add(New SqlParameter("@Estado", SqlDbType.Bit)).Value = False
            End With
            Try
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Datos Eliminados Correctamente")
                Call LlenaGrid()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try



        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(Me.gridConductores, "Relacion General de Conductores")
    End Sub
End Class