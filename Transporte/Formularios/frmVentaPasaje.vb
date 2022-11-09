Imports System.Data.SqlClient
Imports System.IO
Public Class frmVentaPasaje
    Dim PanelPiso As Panel, Asiento As Button, NumPan As String, NumAs As String
    Dim a As Integer, Bus As Integer, Pisos As Integer, Psje1 As Single, Psje2 As Single, IdCli As Integer
    Public IdDeViaje As Integer
    Dim Localizacion(78) As String, NombreAs(78) As String, Gestion(78) As Integer, NumBoleto() As String ', Psje1(75) As Decimal, Psje2(75) As Decimal
    Dim Letras As String, NumeroBoleto As String, NombreBoleto As String, DniBoleto As String, OrigenBoleto As String, DestinoBoleto As String
    Dim AsientoBoleto As Integer, FechaBoleto As Date, HoraBoleto As Date, CostoBoleto As Single
    Dim sentencia As String
#Region "Generales"
    Private Sub frmVentaPasaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        IdDeViaje = Nothing
    End Sub


    Private Sub frmVentaPasaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblFecha.Text = Now.Date
        Me.lblHora.Text = DateTime.Now().ToShortTimeString() '// "09:50:00 am"
        'Buscamos el Ultimo Numero de boleto
        Me.lblCodBol.Text = CodigoBoleto()
        'aqui cargamos los datos generales
        Dim sql As String = "Select BV.Id_Bus, BB.Placa_Bus, BB.Pisos_Bus, BV.Id_Origen, BO.Ubigeo, " & _
                            "BV.Id_Destino, BU.Ubigeo, BV.Fec_Salida, BV.Hora_Salida, BV.Costo_Pasaje1, BV.Costo_Pasaje2 " & _
                            "From Base_Viajes BV " & _
                            "Inner Join Base_Bus BB On BV.Id_Bus = BB.Id_Bus " & _
                            "Inner Join Base_Ubigeo BO On BV.Id_Origen = BO.Id_Ubigeo " & _
                            "Inner Join Base_Ubigeo BU On BV.Id_destino = BU.Id_Ubigeo " & _
                            "Where BV.Id_Viaje = '" & IdDeViaje & "'"
        Try
            con.Open()
            Using cmd As New SqlCommand(sql, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                With reader.Read
                    Bus = reader.GetValue(0)
                    Me.Text = ".:: FORMULARIO DE VENTA BUS DE PLACA " & reader.GetString(1) & " ::."
                    Pisos = reader.GetValue(2)
                    Me.txtOrigen.Text = reader.GetString(4)
                    Me.txtDestino.Text = reader.GetString(6)
                    Me.txtFecSalida.Text = reader.GetDateTime(7)
                    Me.txtHorSalida.Text = reader.GetString(8)
                    Psje1 = reader.GetDecimal(9) & ""
                    Psje2 = reader.GetDecimal(10) & ""
                End With
            End Using
            con.Close()
        Catch
            MessageBox.Show("Vuelva a realizar la operacion correctamente")
            con.Close()
            Me.Close()
        End Try
        'Aqui cargamos la imagen
        Dim ms As New MemoryStream(ExtraerImagen("Select Imagen_Bus From Base_Bus Where Id_Bus = '" & Bus & "'"))
        Me.picUnidad.Image = Image.FromStream(ms)
        frmFotoUnidad.picBus.Image = Image.FromStream(ms)
        'verificamos si el bus es simple o dos pisos
        If Pisos = 1 Then
            panPiso1.Visible = False
        Else
            Me.lblPiso2.Text = "Piso 2"
        End If
        'Cargamos la distribucion de asientos por bus de acuerdo al Id
        CargaAsiento()
        'Verificamos que asientos ya estan vendidos
        VerificaUsos()
        'Cargamos lista de gestiones
        RemoveHandler Me.CboGestion.SelectedValueChanged, AddressOf Me.CboGestion_SelectedValueChanged
        Call CargaCbo(Me.CboGestion, "Select top 2 * From Base_Gestion Where Est_Gestion = 1", 0, 1)
        AddHandler Me.CboGestion.SelectedValueChanged, AddressOf Me.CboGestion_SelectedValueChanged
        Me.CboGestion.Text = Nothing

    End Sub
    Function CodigoSerie() As String
        Dim Sql As String = "Select serie_bus From Base_Bus Where Id_Bus='" & Bus & "' "
        con.Open()
        Using cmd As New SqlCommand(Sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            With reader.Read
                CodigoSerie = Format(Val(reader.GetValue(0).ToString), "000")
            End With
        End Using
        con.Close()
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.lblHora.Text = DateTime.Now().ToShortTimeString()
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim respuesta As String
        respuesta = MsgBox("Desea Cerrar la Venta Realmente?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Salir del Sistema")
        If respuesta = vbYes Then
            Me.Close()
        Else
            Return
        End If

    End Sub

    Private Sub CboGestion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboGestion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.cmdGuardar.Focus()
        End If
    End Sub

    Private Sub CboGestion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboGestion.SelectedValueChanged
        If Me.CboGestion.Text = Nothing Or Me.CboGestion.SelectedValue <> 1 Then
            Me.GroupBox3.Visible = False
        Else
            Me.GroupBox3.Visible = True
        End If
        Me.cmdGuardar.Enabled = True
    End Sub

    Private Sub picUnidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picUnidad.DoubleClick
        frmFotoUnidad.MdiParent = MDIPrincipal
        frmFotoUnidad.Show()
        MDIPrincipal.tsslTitulos.Text = frmFotoUnidad.Text
    End Sub

#End Region
#Region "Friends"
    Friend Sub CargaAsiento()
        If panPiso1.Visible = False Then
            a = 62
        Else
            a = 78
        End If

        For x = 1 To a
            FrmEleccion.ProgressBar1.Value = x
            If x <= 62 Then
                Asiento = DirectCast(panPiso2.Controls("cmd" & x), Button)
            Else
                Asiento = DirectCast(panPiso1.Controls("cmd" & x), Button)
            End If
            Dim sql As String = "Select Asiento_Bus, NumAs_Bus, PosAs_Bus, EstAs_Bus From Base_AsBus Where Id_Bus = '" & Bus & "' And Asiento_Bus = '" & Asiento.Name & "'"
            Try
                con.Open()
                Using cmd As New SqlCommand(sql, con)
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    With reader.Read
                        NombreAs(x - 1) = reader.GetString(0)
                        Asiento.Text = reader.GetValue(1)
                        Localizacion(x - 1) = reader.GetValue(2)
                        Asiento.Visible = reader.GetValue(3)
                        FrmEleccion.ProgressBar1.Value = x
                    End With
                End Using
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                con.Close()
            End Try
        Next
    End Sub
    Friend Sub VerificaUsos()
        If Me.panPiso1.Visible = True Then
            a = 78
        Else
            a = 62
        End If
        ReDim NumBoleto(a)
        ReDim Gestion(a)
        Dim sql As String = "Select BP.Id_Pasaje, BP.Id_Viaje, BP.Asiento_Pasaje, BG.Id_Gestion From Base_Pasaje BP " & _
                            "Inner Join Base_Gestion BG On BP.Id_EstAs = BG.Id_Gestion " & _
                            "Where Id_Viaje = '" & IdDeViaje & "' And BP.Estado_Pasaje = 1 "
        con.Open()
        Using cmd As New SqlCommand(sql, con)
            Dim dt As New DataTable
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For x = 1 To dt.Rows.Count
                    For y = 1 To a
                        If y <= 62 Then
                            Asiento = DirectCast(panPiso2.Controls("cmd" & y), Button)
                        Else
                            Asiento = DirectCast(panPiso1.Controls("cmd" & y), Button)
                        End If
                        If Asiento.Name = dt.Rows(x - 1)("Asiento_Pasaje") Then
                            Dim Imagen As String = dt.Rows(x - 1)("Id_Gestion")
                            Select Case Imagen
                                Case 1
                                    Asiento.Image = My.Resources.Vendido
                                Case 2
                                    Asiento.Image = My.Resources.reservado
                            End Select
                            Gestion(y) = dt.Rows(x - 1)("Id_Gestion")
                            NumBoleto(y) = dt.Rows(x - 1)("Id_Pasaje")
                        End If
                    Next
                Next
            End Using
        End Using
        con.Close()
    End Sub
    Friend Sub Eventos(ByVal boton As Button, ByVal pan As Panel)
        'Desactivamos el boton de impresion
        Me.btnImprimir.Enabled = False
        'Declaramos variables
        NumAs = Mid(boton.Name, 4, boton.Name.Length)
        NumPan = Mid(pan.Name, 8, 1)
        'Cargamos el Numero de asiento, Ubicación, y asignamos la imagen de selección
        Me.txtAsiento.Text = boton.Text
        Me.txtUbicacion.Text = Localizacion(NumAs - 1)
        'Enviamos el foco al txtdni
        Me.txtDni.ReadOnly = False
        Me.txtDni.Focus()
        'Cargamos el precio del pasaje segun el piso ubicado
        If NumPan = 1 Then
            Me.txtPrecio.Text = Psje1
            Me.txtTotal.Text = Psje1
        ElseIf NumPan = 2 Then
            Me.txtPrecio.Text = Psje2
            Me.txtTotal.Text = Psje2
        End If
        'Cargamos la variable asiento con el nombre del boton precionado
        If Me.txtAsiento.Text <= 62 Then
            Asiento = DirectCast(panPiso2.Controls("cmd" & NumAs), Button)
        Else
            Asiento = DirectCast(panPiso1.Controls("cmd" & NumAs), Button)
        End If
        'cargamos los datos en caso sea vedido o reservado
        If Gestion(NumAs) = 1 Or Gestion(NumAs) = 2 Then
            Dim sql As String = "Select BP.Id_Pasaje, BP.Id_Cliente, BC.Dni_Cliente, (BC.Apat_Cliente + ' ' + BC.Amat_Cliente) as Apellidos, " & _
                                "BC.Nom_Cliente From Base_Pasaje BP " & _
                                "Inner Join Base_Clientes BC On BP.ID_Cliente = BC.Id_Cliente " & _
                                "Where BP.Estado_Pasaje=1 And Id_Pasaje = '" & NumBoleto(NumAs) & "' "
            Try
                con.Open()
                Using cmd As New SqlCommand(sql, con)
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    With reader.Read
                        Me.lblCodBol.Text = reader.GetValue(0)
                        IdCli = reader.GetInt32(1)
                        Me.txtDni.Text = reader.GetValue(2)
                        Me.txtAp.Text = reader.GetValue(3)
                        Me.txtNomb.Text = reader.GetValue(4)
                    End With
                End Using
                con.Close()

            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            Dim Asci As New KeyPressEventArgs(Convert.ToChar(13))
            Call Me.txtDni_KeyPress(Nothing, Asci)
        End If
        'Verificamos si el asiento esta reservado o vendido
        Select Case Gestion(NumAs)
            Case 1
                Call CargaCbo(Me.CboGestion, "Select * from base_gestion where id_gestion=3", 0, 1)
            Case 2
                Call CargaCbo(Me.CboGestion, "Select * from base_gestion where id_gestion=1 or id_gestion=3", 0, 1)
                sentencia = "Update Base_Pasaje Set Id_Pasaje = @IdPasaje, Id_Cliente = @Cliente, Id_Viaje = @Viaje, " & _
                            "Asiento_Pasaje = @Asiento, NumAs_Pasaje = @Numero, UbicAs_Pasaje = @Ubicacion, " & _
                            "Id_EstAs = @IdEst, Costo_Pasaje = @Costo, Desc_Pasaje = @Desc, Inc_Pasaje = @Inc, " & _
                            "Parcial_Pasaje = @Parcial, Fecha_Pasaje = @Fecha, Hora_Pasaje = @Hora, Estado_Pasaje = @Estado " & _
                            "Where Id_Pasaje = '" & Me.lblCodBol.Text & "'"
            Case Else
                Call CargaCbo(Me.CboGestion, "Select top 2 * from base_gestion", 0, 1)
                sentencia = "Insert Into Base_Pasaje Values(@IdPasaje, @Cliente, @Viaje, @Asiento, @Numero, @Ubicacion, " & _
                            "@IdEst, @Costo, @Desc, @Inc, @Parcial, @Fecha, @Hora, @Estado)"
        End Select
        
    End Sub
    Friend Sub EjecutarAccion()
        Try
            'comenzamos a guardar los datos
            Using cmdgrabar As New SqlCommand(sentencia, con)
                cmdgrabar.Parameters.Clear()
                'If Me.CboGestion.SelectedValue = 2 Then
                cmdgrabar.Parameters.Add("@IdPasaje", SqlDbType.VarChar).Value = Me.lblCodBol.Text
                'Else
                'cmdgrabar.Parameters.Add("@IdPasaje", SqlDbType.VarChar).Value = CodigoBoleto()
                'End If
                cmdgrabar.Parameters.Add("@Cliente", SqlDbType.Int).Value = IdCli
                cmdgrabar.Parameters.Add("@Viaje", SqlDbType.Int).Value = IdDeViaje
                cmdgrabar.Parameters.Add("@Asiento", SqlDbType.VarChar).Value = NombreAs(NumAs - 1)
                cmdgrabar.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Me.txtAsiento.Text
                cmdgrabar.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = Me.txtUbicacion.Text
                cmdgrabar.Parameters.Add("@IdEst", SqlDbType.Int).Value = Me.CboGestion.SelectedValue
                cmdgrabar.Parameters.Add("@Costo", SqlDbType.Money).Value = CDec(Me.txtPrecio.Text)
                If Me.radDesc.Checked = True Then
                    cmdgrabar.Parameters.Add("@Desc", SqlDbType.Money).Value = CDec(Me.cboCant.Text)
                    cmdgrabar.Parameters.Add("@Inc", SqlDbType.Money).Value = 0
                ElseIf Me.radInc.Checked = True Then
                    cmdgrabar.Parameters.Add("@Desc", SqlDbType.Money).Value = 0
                    cmdgrabar.Parameters.Add("@Inc", SqlDbType.Money).Value = CDec(Me.cboCant.Text)
                Else
                    cmdgrabar.Parameters.Add("@Desc", SqlDbType.Money).Value = 0
                    cmdgrabar.Parameters.Add("@Inc", SqlDbType.Money).Value = 0
                End If
                cmdgrabar.Parameters.Add("@Parcial", SqlDbType.Money).Value = CDec(Me.txtTotal.Text)
                cmdgrabar.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Me.lblFecha.Text
                cmdgrabar.Parameters.Add("@Hora", SqlDbType.DateTime).Value = Me.lblHora.Text
                cmdgrabar.Parameters.Add("@Estado", SqlDbType.Bit).Value = 1
                con.Open()
                'cmdgrabar.ExecuteScalar
                cmdgrabar.ExecuteNonQuery()
                'IdPasaje = Convert.ToInt32(cmdgrabar.ExecuteNonQuery())
                con.Close()
                'Aqui borramos los text y recargamos el form
            End Using
            MessageBox.Show("Proceso Exitoso.... ")
            CargarVariables()
            VerificaUsos()
            LimpiaText()
            Me.lblCodBol.Text = CodigoBoleto()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Friend Sub AnulaVenta()
        Dim Mensaje As String = MsgBox("Desea Anular Este Proceso??", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Aviso")
        If Mensaje = vbYes Then
            Asiento.Image = My.Resources.libre
            Dim sql As String = "Update Base_Pasaje Set Id_EstAs = @EstAs, Estado_Pasaje = @Estado Where Id_Pasaje = '" & Me.lblCodBol.Text & "' "
            Dim command As New SqlCommand(sql, con)
            command.Parameters.AddWithValue("@EstAs", Me.CboGestion.SelectedValue)
            command.Parameters.AddWithValue("@Estado", CBool(False))
            Try
                con.Open()
                command.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Proceso Exitoso.... ")
                VerificaUsos()
                LimpiaText()
                Me.lblCodBol.Text = CodigoBoleto()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Select Case Me.CboGestion.SelectedValue
            Case 1
                Dim Boleto As String = InputBox("Ingrese el numero de Boleto", "Codigo Boleto")
                Me.lblCodBol.Text = CodigoSerie() & " - " & Format(Val(Boleto), "000000")
                Call EjecutarAccion()
                Me.btnImprimir.Enabled = True
                Me.btnImprimir.Focus()

            Case 2
                Me.lblCodBol.Text = CodigoReserva()
                Call EjecutarAccion()
            Case 3
                Call AnulaVenta()
        End Select
        Me.cmdGuardar.Enabled = False
        Me.GroupBox3.Visible = False

    End Sub

    Friend Sub LimpiaText()
        Me.txtAsiento.Text = Nothing
        Me.txtUbicacion.Text = Nothing
        Me.txtDni.Text = Nothing
        Me.txtAp.Text = Nothing
        Me.txtNomb.Text = Nothing
        Me.txtPrecio.Text = Nothing
        Me.CboGestion.Text = Nothing
        Me.radDesc.Checked = False
        Me.radInc.Checked = False
        Me.cboCant.Text = Nothing
        Me.txtTotal.Text = Nothing
        Me.txtDni.ReadOnly = True
    End Sub

#End Region
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
#Region "Panel Cliente"

    Private Sub cmdCancelaCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelaCli.Click
        limpiarCliente()
    End Sub

    Private Sub cmdGuardaCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardaCli.Click
        If Val(Me.txtEdad.Text) <= 5 Then
            MessageBox.Show("Ingrese la edad del cliente por favor")
            Return
        End If
        Using cmdgrabar As New SqlCommand("Insert Into Base_Clientes Values(@Dni, @Apat, @Amat, @Nombre, @Edad) SELECT SCOPE_IDENTITY()", con)
            cmdgrabar.Parameters.Clear()
            cmdgrabar.Parameters.AddWithValue("@Dni", Me.txtDniC.Text)
            cmdgrabar.Parameters.AddWithValue("@Apat", Me.txtPaterno.Text)
            cmdgrabar.Parameters.AddWithValue("@Amat", Me.txtMaterno.Text)
            cmdgrabar.Parameters.AddWithValue("@Nombre", Me.txtNombre.Text)
            cmdgrabar.Parameters.AddWithValue("@Edad", Me.txtEdad.Text)
            Try
                con.Open()
                'cmdgrabar.ExecuteNonQuery()
                IdCli = Convert.ToInt32(cmdgrabar.ExecuteScalar())
                'MessageBox.Show(IdCli)
                con.Close()
                limpiarCliente()
            Catch ex As Exception
                con.Close()
                MessageBox.Show("Ocurrio un problema al guardar Cliente")
            End Try

        End Using
        'MessageBox.Show("Datos Guardados Exitosamente.... ")
    End Sub

    Private Sub txtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDni.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
        If Asc(e.KeyChar) = 13 Then
            Me.txtAp.Focus()
        End If
    End Sub

    Private Sub txtDni_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDni.LostFocus
        If Me.txtDni.Text = Nothing Then
            Exit Sub
        End If
        Dim sql As String = "Select Id_Cliente, (Apat_Cliente + ' ' + Amat_Cliente) as Apellidos, " & _
                                "Nom_Cliente From Base_Clientes " & _
                                "Where Dni_Cliente = '" & Me.txtDni.Text & "'"
        Try
            con.Open()
            Using cmd As New SqlCommand(sql, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                With reader.Read
                    IdCli = reader.GetValue(0)
                    Me.txtAp.Text = reader.GetValue(1) & ""
                    Me.txtNomb.Text = reader.GetValue(2) & ""
                End With
            End Using
            con.Close()
            Me.CboGestion.Focus()
        Catch ex As Exception
            'MessageBox.Show("Cliente No Existe")
            con.Close()
            Me.Panel1.Visible = True
            Me.txtDniC.Text = Me.txtDni.Text
            Me.txtPaterno.Focus()
        End Try
    End Sub

    Private Sub txtPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaterno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtMaterno.Focus()
        End If
    End Sub
    Private Sub txtPaterno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaterno.LostFocus
        Me.txtPaterno.Text = Me.txtPaterno.Text.ToUpper
    End Sub
    Private Sub txtMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaterno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtNombre.Focus()
        End If
    End Sub
    Private Sub txtMaterno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaterno.LostFocus
        Me.txtMaterno.Text = Me.txtMaterno.Text.ToUpper
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtEdad.Focus()
        End If
    End Sub

    Private Sub txtNombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.LostFocus
        Me.txtNombre.Text = Me.txtNombre.Text.ToUpper
    End Sub

    Private Sub txtEdad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdad.KeyPress
        If InStr(1, "0123456789,-" & Chr(8) & Chr(13), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
        If Asc(e.KeyChar) = 13 Then
            Me.cmdGuardaCli.Focus()
        End If
    End Sub


    Friend Sub limpiarCliente()
        Me.txtAp.Text = Me.txtPaterno.Text & " " & Me.txtMaterno.Text
        Me.txtNomb.Text = Me.txtNombre.Text
        Me.Label22.Text = Nothing
        Me.txtPaterno.Text = Nothing
        Me.txtMaterno.Text = Nothing
        Me.txtNombre.Text = Nothing
        Me.txtEdad.Text = Nothing
        Me.Panel1.Visible = False
        Me.CboGestion.Focus()
    End Sub
#End Region
#Region "Descuentos"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.radInc.Checked = False
        Me.radDesc.Checked = False
        Me.txtTotal.Text = Me.txtPrecio.Text
        Me.cboCant.Text = Nothing
    End Sub

    Private Sub radInc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radInc.CheckedChanged
        'Cargamos la lista de montos a descontar o incrementar
        If Me.cboCant.Items.Count <= 0 Then
            Call CargaCbo(Me.cboCant, "Select * From Base_Rebaja Where Est_Rebaja = 1", 0, 1)
        End If
    End Sub

    Private Sub radDesc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDesc.CheckedChanged
        'Cargamos la lista de montos a descontar o incrementar
        If Me.cboCant.Items.Count <= 0 Then
            Call CargaCbo(Me.cboCant, "Select * From Base_Rebaja Where Est_Rebaja = 1", 0, 1)
        End If
    End Sub

    Private Sub cboCant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCant.SelectedIndexChanged
        If Me.radInc.Checked = True Then
            Me.txtTotal.Text = Val(Me.txtPrecio.Text) + Val(Me.cboCant.Text)
        ElseIf Me.radDesc.Checked = True Then
            Me.txtTotal.Text = Val(Me.txtPrecio.Text) - Val(Me.cboCant.Text)
        End If
    End Sub
#End Region
#Region "Impresion"

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim Respuesta As String = MsgBox("Desea Imprimir Este Boleto??", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Impresión Boleto")
        If Respuesta = vbYes Then
            Me.PrintPreviewDialog1.Document = PrintDocument1
            Me.PrintPreviewDialog1.ShowDialog()
            Me.btnImprimir.Enabled = True
        Else
            Me.btnImprimir.Enabled = True
            Return
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'lado Izquierdo del Boleto
        e.Graphics.DrawString(Me.NombreBoleto, Me.txtNomb.Font, Brushes.Black, 108, 105) '50
        e.Graphics.DrawString(Me.DniBoleto, Me.txtDni.Font, Brushes.Black, 356, 105) '50
        e.Graphics.DrawString(Me.OrigenBoleto, Me.txtOrigen.Font, Brushes.Black, 80, 125) '65
        e.Graphics.DrawString(Me.DestinoBoleto, Me.txtDestino.Font, Brushes.Black, 230, 125) '65
        e.Graphics.DrawString(Me.AsientoBoleto, Me.txtAsiento.Font, Brushes.Black, 385, 125) '65
        e.Graphics.DrawString(Me.lblFecha.Text, Me.lblFecha.Font, Brushes.Black, 80, 145) '80
        e.Graphics.DrawString(Me.FechaBoleto, Me.txtFecSalida.Font, Brushes.Black, 230, 145) '80
        e.Graphics.DrawString(Me.HoraBoleto, Me.txtHorSalida.Font, Brushes.Black, 350, 145) '80
        e.Graphics.DrawString(Me.CostoBoleto, Me.txtTotal.Font, Brushes.Black, 370, 195) '125
        e.Graphics.DrawString(Me.Letras, Me.txtPrecio.Font, Brushes.Black, 80, 170)
        'Lado Derecho del Boleto
        e.Graphics.DrawString(Me.lblFecha.Text, Me.lblFecha.Font, Brushes.Black, 540, 68) '45
        e.Graphics.DrawString(Me.AsientoBoleto, Me.txtAsiento.Font, Brushes.Black, 480, 110)
        e.Graphics.DrawString(Me.HoraBoleto, Me.txtHorSalida.Font, Brushes.Black, 525, 110)
        e.Graphics.DrawString(Me.OrigenBoleto, Me.txtOrigen.Font, Brushes.Black, 505, 155)
        e.Graphics.DrawString(Me.DestinoBoleto, Me.txtDestino.Font, Brushes.Black, 505, 185)
        e.Graphics.DrawString(Me.CostoBoleto, Me.txtTotal.Font, Brushes.Black, 490, 205)
    End Sub
    Friend Sub CargarVariables()
        NumeroBoleto = Me.lblCodBol.Text
        NombreBoleto = Me.txtAp.Text & " " & Me.txtNomb.Text
        DniBoleto = Me.txtDni.Text
        OrigenBoleto = Me.txtOrigen.Text
        DestinoBoleto = Me.txtDestino.Text
        AsientoBoleto = Me.txtAsiento.Text
        FechaBoleto = CDate(Me.txtFecSalida.Text)
        HoraBoleto = Me.txtHorSalida.Text
        CostoBoleto = Me.txtTotal.Text
        Letras = ValEnLetr(CostoBoleto)
    End Sub
    Friend Sub LimpiaVariables()
        NumeroBoleto = Nothing
        NombreBoleto = Nothing
        DniBoleto = Nothing
        OrigenBoleto = Nothing
        DestinoBoleto = Nothing
        AsientoBoleto = Nothing
        FechaBoleto = Nothing
        HoraBoleto = Nothing
        CostoBoleto = Nothing
    End Sub
#End Region

End Class