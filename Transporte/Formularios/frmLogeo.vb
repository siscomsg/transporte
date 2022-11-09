Imports System.Data.SqlClient
Public Class frmLogeo
    Dim nombre_solo As String

    Private Sub cmdEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntrar.Click
        If Me.txtUser.Text = Nothing Or Me.txtPass.Text = Nothing Then
            MessageBox.Show("Error en los datos de inicio de sesión")
            Me.txtUser.Focus()
        Else
            Dim sql As String = "Select US.cod_user, US.nombres_user, (US.apat_user + ' ' + US.amat_user + ' ' + US.Nombres_user) as Nombres, " & _
                                "US.codterm_user, UB.ubigeo From Base_Usuarios US " & _
                                "Inner Join Base_Ubigeo UB On US.codterm_user = Id_Ubigeo " & _
                                "Where (Usuario_user = '" & Me.txtUser.Text & "' And pass_user = '" & Me.txtPass.Text & "') and estado_user = 1"
            Try
                con.Open()
                Using cmd As New SqlCommand(sql, con)
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    With reader.Read
                        codigo_user = reader.GetValue(0)
                        nombre_solo = reader.GetValue(1)
                        nombre_user = reader.GetValue(2)
                        codubi_user = reader.GetValue(3)
                        Ubigeo_user = reader.GetValue(4)
                    End With
                End Using
                MessageBox.Show("Login Correcto ... Bienvenido(a) al sistema " & (nombre_solo).ToUpper)
                ' codigo_user & nombre_user & codubi_user & Ubigeo_user)
                con.Close()
                MDIPrincipal.Show()

            Catch ex As Exception
                MessageBox.Show("Usuario sin privilegios de ingreso " & ex.Message)
                con.Close()
                Me.txtUser.Text = Nothing
                Me.txtPass.Text = Nothing
                Me.txtUser.Focus()
            End Try

        End If
    End Sub

    Private Sub frmLogeo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call coneccion()
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPass.Focus()
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.cmdEntrar.Focus()
        End If
    End Sub
End Class