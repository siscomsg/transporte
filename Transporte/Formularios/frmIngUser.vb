Imports System.Data.SqlClient
Public Class frmIngUser

    Private Sub frmIngUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargaCbo(Me.cboTerminal, "Select * From Ubigeo Where Estado_Ubigeo = 1 Order By Ubigeo Asc;", 0, 1)
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPass.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub txtUser_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUser.Leave
        If Me.txtUser.Text = Nothing Then
            MessageBox.Show("Usuario no valido")
            Me.txtUser.Focus()
        Else
            con.Open()
            Dim sql As String = "Select Count(usuario_user) as usuario From Usuarios Where usuario_user = '" & Me.txtUser.Text & "' "
            Dim cmd As New SqlCommand(sql, con)
            Dim numero As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            con.Close()
            If numero > 0 Then
                MsgBox("Usuario existente")
                Me.txtUser.Focus()
            Else
                Me.txtPass.Focus()
            End If
        End If
       
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtRePass.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub txtPass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPass.Leave
        If Me.txtPass.Text = Nothing Then
            MessageBox.Show("El pass no puede estar vacio")
            Me.txtPass.Focus()
        Else
            Me.txtRePass.Focus()
        End If
    End Sub

    Private Sub txtRePass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRePass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtDni.Select()
            e.Handled = True
        End If
    End Sub


    Private Sub txtRePass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRePass.Leave
        If Me.txtPass.Text <> Me.txtRePass.Text Then
            MessageBox.Show("El pass y la confirmación deben ser iguales")
            Me.txtPass.Text = Nothing
            Me.txtRePass.Text = Nothing
            Me.txtPass.Focus()
        Else
            Me.txtDni.Focus()
        End If
    End Sub

    Private Sub txtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDni.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtAPat.Select()
            e.Handled = True
        End If
    End Sub


    Private Sub txtDni_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDni.Leave
        If Me.txtDni.Text = Nothing Then
            MessageBox.Show("Los datos no corresponden")
            Me.txtDni.Focus()
        Else
            Me.txtAPat.Focus()
        End If
    End Sub

    
    Private Sub txtAPat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPat.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtAPat.Text = (Me.txtAPat.Text).ToUpper
            Me.txtAMat.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub txtAPat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAPat.Leave
        If Me.txtAPat.Text = Nothing Then
            MessageBox.Show("Los datos no corresponden")
            Me.txtAPat.Focus()
        End If
    End Sub

    Private Sub txtAMat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAMat.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtAMat.Text = (Me.txtAMat.Text).ToUpper
            Me.txtNombre.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub txtAMat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAMat.Leave
        If Me.txtAMat.Text = Nothing Then
            MessageBox.Show("Los datos no corresponden")
            Me.txtAMat.Focus()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtNombre.Text = (Me.txtNombre.Text).ToUpper
            Me.cboTerminal.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombre_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.Leave
        If Me.txtNombre.Text = Nothing Then
            MessageBox.Show("Los datos no corresponden")
            Me.txtNombre.Focus()
        End If
    End Sub

    Private Sub cboTerminal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTerminal.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.cmdGrabar.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub cboTerminal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTerminal.Leave
        If Me.cboTerminal.Text = Nothing Then
            MessageBox.Show("Los datos no corresponden")
            Me.cboTerminal.Focus()
        End If
    End Sub

   
    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Using cmdgrabar As New SqlCommand("Insert Into Usuarios Values(@usuario_user, @pass_user, @dni_user, @apat_user, @amat_user, @nombres_user, @codterm_user, @Estado_user)", con)
            cmdgrabar.Parameters.Clear()
            cmdgrabar.Parameters.AddWithValue("@usuario_user", Me.txtUser.Text)
            cmdgrabar.Parameters.AddWithValue("@pass_user", Me.txtPass.Text)
            cmdgrabar.Parameters.AddWithValue("@dni_user", Me.txtDni.Text)
            cmdgrabar.Parameters.AddWithValue("@apat_user", Me.txtAPat.Text)
            cmdgrabar.Parameters.AddWithValue("@amat_user", Me.txtAMat.Text)
            cmdgrabar.Parameters.AddWithValue("@nombres_user", Me.txtNombre.Text)
            cmdgrabar.Parameters.AddWithValue("@codterm_user", Me.cboTerminal.SelectedValue)
            cmdgrabar.Parameters.AddWithValue("@estado_user", CBool(True))
            Try
                con.Open()
                cmdgrabar.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Datos Guardados Exitosamente.... ")
                Me.txtUser.Text = Nothing
                Me.txtPass.Text = Nothing
                Me.txtRePass.Text = Nothing
                Me.txtDni.Text = Nothing
                Me.txtAPat.Text = Nothing
                Me.txtAMat.Text = Nothing
                Me.txtNombre.Text = Nothing
                Me.cboTerminal.Text = Nothing

            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
End Class