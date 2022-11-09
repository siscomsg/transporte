Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.IO
Module Module1
    Public con As New SqlConnection
    Public codigo_user, nombre_user, codubi_user, Ubigeo_user As String 'Variables para carga de datos del usuario
    Public Piso1, Piso2 As Integer

    Public Sub coneccion()
        Dim host, db, id, pwd, resultado As String
        host = "localhost" '"190.40.60.70,1433" '"192.168.1.30\sqlexpress" '"25.127.140.95" '"192.168.1.38" '190.40.60.70,1433"
        db = "transporte"
        id = "sa"
        pwd = "rafael"
        con.ConnectionString = ("Data Source=" & host & "; Initial Catalog=" & db & ";Persist Security Info=True;User ID=" & id & ";Pwd=" & pwd & ";")
        Try
            con.Open()
            'MsgBox("Conección Exitosa", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Conexión")
            con.Close()

        Catch ex As Exception
            resultado = MsgBox("Error de conección desea reintentar???", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conección")
            If resultado = vbYes Then
                MsgBox("Error al conectar a db", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Conexión")
            Else
                End
            End If
        End Try
    End Sub

    Public Sub CargaLst(ByVal list As ListBox, ByVal sentencia As String, ByVal col1 As Integer, ByVal col2 As Integer)
        Dim sql As String = sentencia
        Try
            con.Open()
            Using sda As New SqlDataAdapter(sql, con)
                Dim Dtt As New DataTable
                sda.Fill(Dtt)
                With (list)
                    .DataSource = Dtt
                    .ValueMember = Dtt.Columns(col1).ToString
                    .DisplayMember = Dtt.Columns(col2).ToString
                End With
            End Using
            con.Close()
            list.Text = Nothing
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub

    Public Sub CargaCbo(ByVal Combo As ComboBox, ByVal Ssql As String, ByVal Columna1 As Integer, ByVal Columna2 As Integer)
        Dim sql As String = Ssql
        Try
            con.Open()
            Dim Sda As New SqlDataAdapter(sql, con)
            Dim Dtt As New DataTable
            Sda.Fill(Dtt)
            With (Combo)
                .DataSource = Dtt
                .ValueMember = Dtt.Columns(Columna1).ToString
                .DisplayMember = Dtt.Columns(Columna2).ToString
            End With
            con.Close()
            Combo.Text = Nothing
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub Cargar_Grid(ByVal Grid As DataGridView, ByVal Sentencia As String)
        Try
            con.Open()
            Dim sql As String = Sentencia
            Dim Sda As New SqlDataAdapter(sql, con)
            Dim Dtt As New DataTable
            Sda.Fill(Dtt)
            Grid.DataSource = Dtt
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Carga_Ckeck(ByVal Clb As CheckedListBox, ByVal Ssql As String, ByVal Columna1 As Integer, ByVal Columna2 As Integer)
        Dim sql As String = Ssql
        Try
            con.Open()
            Dim Sda As New SqlDataAdapter(sql, con)
            Dim Dtt As New DataTable
            Sda.Fill(Dtt)
            With (Clb)
                .DataSource = Dtt
                .ValueMember = Dtt.Columns(Columna1).ToString
                .DisplayMember = Dtt.Columns(Columna2).ToString
            End With
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub abririmagen(ByVal abre As OpenFileDialog, ByVal picture As PictureBox)
        'Si en el diseño no hemos añadido el Openfiledialog pondremos esto sin el apostrofe al principio:
        'Dim abre As OpenFileDialog 
        abre.Title = "Seleccione su Imagen" 'Título de la ventana que se abrirá para seleccionar el archivo.
        abre.Filter = "Jpg|*.jpg|Png|*.png|Gif|*.gif|Todos los archivos|*.*" 'Tipo de extensiones soportadas, fijaros como en la primera parte se pone el nombre, el que se quiera, después ponemos una barra vertical a modo de separación y ponemos *."extensión", el asterisco significa que nos permitirá cualquier nombre de archivo, la extensión hay que ponerla IGUAL que las que queramos abrir, lo de todos los archivos es opcional..
        abre.FilterIndex = 0 'Elegimos que se quede por defecto la primera extensión a la vista.
        abre.InitialDirectory = "C:\Documents and Settings\" & My.User.Name & "\Escritorio" 'Con esto haremos que el directorio inicial sea nuestro escritorio, podemos modificarlo a nuestro antojo si quisieramos abrirlo en mis documentos o en algún otro lugar lo ponemos y ya está.
        abre.RestoreDirectory = True 'De esta forma, mientras no cerremos la aplicación se "guardará" el último directorio seleccionado para no tener que elegirlo cada vez.
        abre.FileName = "" 'Con esto hacemos que al abrir la ventana no haya un nombre escrito, de la manera contraria en la ventana ya pondria "abre", además que esto nos viene bien para otra cosa que explicaré luego.

        If abre.ShowDialog() = Windows.Forms.DialogResult.OK Then 'Si pulsamos aceptar en la ventanita.
            picture.ImageLocation = abre.FileName 'La ruta de la imagen que contiene el picturebox es el nombre de archivo del OpenFileDialog.

        ElseIf abre.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            MsgBox("No se seleccionó ninguna imagen")

        End If

    End Sub
    Public Sub guardarimagenpc(ByVal guarda As SaveFileDialog, ByVal picture As PictureBox, ByVal abre As OpenFileDialog)
        'Si en el diseño no hemos añadido el SaveFileDialog pondremos esto sin el apostrofe:
        'Dim guarda As SaveFileDialog
        Dim foto As New Bitmap(picture.Image) 'esta linea es para asignar el tamaño del picture a la imagen -->(New Bitmap(picture.Image), picture.Width, picture.Height)
        'Creamos una variable llamada foto que será un Bitmap con la imagen del picturebox, su anchura y su altura.
        guarda.Title = "Seleccione donde quiere guardar su Imagen"
        guarda.Filter = "Jpg|*.jpg|Png|*.png|Gif|*.gif|Todos los archivos|*.*"
        guarda.FilterIndex = 0
        guarda.InitialDirectory = "C:\Documents and Settings\" & My.User.Name & "\Escritorio"
        guarda.RestoreDirectory = True
        guarda.FileName = ""
        'Lo mismo que antes pero esta vez para el SaveFileDialog
        If guarda.ShowDialog() = Windows.Forms.DialogResult.OK Then 'Si el pulsamos aceptar en la ventanita
            If abre.FileName <> "" Then
                'Si la ruta del archivo del OpenFileDialog es diferente a nada, es decir, si tiene un nombre será que hemos cargado una foto, de lo contrario nos dejaría guardar una foto que realmente no tenemos.
                If guarda.FilterIndex = 0 Then 'Si elegimos la extensión jpg
                    foto.Save(guarda.FileName.ToString, System.Drawing.Imaging.ImageFormat.Jpeg) 'Formateamos el Bitmap a Jpeg y lo guardamos
                ElseIf guarda.FilterIndex = 1 Then
                    foto.Save(guarda.FileName.ToString, System.Drawing.Imaging.ImageFormat.Png)
                ElseIf guarda.FilterIndex = 2 Then
                    foto.Save(guarda.FileName.ToString, System.Drawing.Imaging.ImageFormat.Gif)
                    'Con los demás es exactamente igual, pero cambiando el formato.
                End If
            End If
        End If

    End Sub
    Function ExtraerImagen(ByVal Sentencia As String) As Byte()
        con.Open()
        Dim Command As New SqlCommand(Sentencia, con)
        Dim MyPhoto() As Byte = CType(Command.ExecuteScalar(), Byte())
        con.Close()
        Return MyPhoto
    End Function
    Function CodigoBoleto() As String
        Dim Sql As String = "Select Max(SubString(Id_Pasaje,5,5)) From Base_Pasaje Where Substring(Id_Pasaje,1,3) = 'BOL' "
        con.Open()
        Using cmd As New SqlCommand(Sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            With reader.Read
                CodigoBoleto = "BOL-" & Format(Val(reader.GetValue(0).ToString) + 1, "00000") & "-" & Year(Now)
            End With
        End Using
        con.Close()
    End Function

    Function CodigoReserva() As String
        Dim Sql As String = "Select Max(SubString(Id_Pasaje,5,5)) From Base_Pasaje Where Substring(Id_Pasaje,1,3) = 'RES' "
        con.Open()
        Using cmd As New SqlCommand(Sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            With reader.Read
                CodigoReserva = "RES-" & Format(Val(reader.GetValue(0).ToString) + 1, "00000") & "-" & Year(Now)
            End With
        End Using
        con.Close()
    End Function
    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String) ', ByVal bar As ProgressBar)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        'bar.Maximum = DataGridView1.Rows.Count
        With (objHojaExcel)
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            : .Range("A1:L1").Merge()
            : .Range("A1:L1").Value = "POOL Servicio Dorado"
            : .Range("A1:L1").Font.Name = "Arial"
            : .Range("A1:L1").Font.Bold = True
            : .Range("A1:L1").Font.Size = 15
            'Copete  
            : .Range("A2:L2").Merge()
            : .Range("A2:L2").Value = titulo
            : .Range("A2:L2").Font.Name = "Arial"
            : .Range("A2:L2").Font.Bold = True
            : .Range("A2:L2").Font.Size = 12

            : Const primeraLetra As Char = "A"
            : Const primerNumero As Short = 3
            : Dim Letra As Char, UltimaLetra As Char
            : Dim Numero As Integer, UltimoNumero As Integer
            : Dim cod_letra As Byte = Asc(primeraLetra) - 1
            : Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            : Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hoja de cálculo  
            : Dim strColumna As String = ""
            : Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            : Numero = primerNumero
            : Dim objCelda As Excel.Range
            : For Each c As DataGridViewColumn In DataGridView1.Columns
                : If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                        : Else
                        : cod_letra += 1
                        : Letra = Chr(cod_letra)
                        : End If
                    : strColumna = LetraIzq + Letra + Numero.ToString
                    : objCelda = .Range(strColumna, Type.Missing)
                    : objCelda.Value = c.HeaderText
                    : objCelda.EntireColumn.Font.Size = 8
                    objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format
                    : If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        : objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                        : End If
                    : End If
                : Next

            : Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            : objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            'Cmabiamos el tipo y tamaño de letra del encabezado
            ': objRangoEncab.Font.Bold = True
            ': objRangoEncab.Font.Size = 12
            : UltimaLetra = Letra
            : Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            : Dim i As Integer = Numero + 1

            : For Each reg As DataGridViewRow In DataGridView1.Rows
                : LetraIzq = ""
                : cod_LetraIzq = Asc(primeraLetra) - 1
                : Letra = primeraLetra
                : cod_letra = Asc(primeraLetra) - 1
                : For Each c As DataGridViewColumn In DataGridView1.Columns
                    : If c.Visible Then
                        : If Letra = "Z" Then
                            : Letra = primeraLetra
                            : cod_letra = Asc(primeraLetra)
                            : cod_LetraIzq += 1
                            : LetraIzq = Chr(cod_LetraIzq)
                            : Else
                            : cod_letra += 1
                            : Letra = Chr(cod_letra)
                            : End If
                        : strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()

                        : End If
                    : Next
                : Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                : objRangoReg.Rows.BorderAround()
                : objRangoReg.Select()
                : i += 1
                : Next
            : UltimoNumero = i

            'Dibujar las líneas de las columnas  
            : LetraIzq = ""
            : cod_LetraIzq = Asc("A")
            : cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    : objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    : objCelda.BorderAround()
                    'Cambamos el tamaño de letra de toda la seleccion
                    : objCelda.Font.Name = "Arial"
                    : objCelda.Font.Size = 10
                    : objCelda.Font.Bold = True
                    : If Letra = "Z" Then
                        : Letra = primeraLetra
                        : cod_letra = Asc(primeraLetra)
                        : LetraIzq = Chr(cod_LetraIzq)
                        : cod_LetraIzq += 1
                        : Else
                        : cod_letra += 1
                        Letra = Chr(cod_letra)
                        : End If
                    : End If
                : Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            : objRango.Columns.AutoFit()
            : objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
    Public Function ConvVal(ByVal iValor As Integer, ByVal iNMil As Integer) As String
        Dim sValor As String = ""
        Dim iCent As Integer, iDece As Integer, iUnid As Integer
        iCent = iValor \ 100 : iValor = iValor - (iCent * 100)
        iDece = iValor \ 10 : iValor = iValor - (iDece * 10)
        iUnid = iValor
        If iCent > 0 Then
            Select Case iCent
                Case 1 : If iDece > 0 Or iUnid > 0 Then sValor = "Ciento" Else sValor = "Cien"
                Case 2 : sValor = "Doscientos "
                Case 3 : sValor = "Trescientos "
                Case 4 : sValor = "Cuatrocientos "
                Case 5 : sValor = "Quinientos "
                Case 6 : sValor = "Seiscientos "
                Case 7 : sValor = "Setecientos "
                Case 8 : sValor = "Ochocientos "
                Case 9 : sValor = "Novecientos "
            End Select
        End If
        If iDece > 0 Then
            Select Case iDece
                Case 1
                    Select Case iUnid
                        Case 0 : sValor = sValor & "Diez "
                        Case 1 : sValor = sValor & "Once "
                        Case 2 : sValor = sValor & "Doce "
                        Case 3 : sValor = sValor & "Trece "
                        Case 4 : sValor = sValor & "Catorce "
                        Case 5 : sValor = sValor & "Quince "
                        Case 6 : sValor = sValor & "Dieciseis "
                        Case 7 : sValor = sValor & "Diecisiete "
                        Case 8 : sValor = sValor & "Dieciocho "
                        Case 9 : sValor = sValor & "Diecinueve "
                    End Select
                Case 2 : If iUnid = 0 Then sValor = sValor & "Veinte " Else sValor = sValor & "Venti"
                Case 3 : sValor = sValor & "Treinta "
                Case 4 : sValor = sValor & "Cuarenta "
                Case 5 : sValor = sValor & "Cincuenta "
                Case 6 : sValor = sValor & "Sesenta "
                Case 7 : sValor = sValor & "Setenta "
                Case 8 : sValor = sValor & "Ochenta "
                Case 9 : sValor = sValor & "Noventa "
            End Select
        End If
        If iUnid > 0 And iDece <> 1 Then
            If iDece > 2 Then sValor = sValor & " y "
            Select Case iUnid
                Case 1 : sValor = sValor & "Un"
                    If iNMil = 0 Then sValor = sValor & "o"
                    '         If (iCent = 0 And iDece = 0) Or iNMil > 0 Then sValor = sValor & "Un" Else sValor = sValor & "Uno"
                Case 2 : sValor = sValor & "Dos"
                Case 3 : sValor = sValor & "Tres"
                Case 4 : sValor = sValor & "Cuatro"
                Case 5 : sValor = sValor & "Cinco"
                Case 6 : sValor = sValor & "Seis"
                Case 7 : sValor = sValor & "Siete"
                Case 8 : sValor = sValor & "Ocho"
                Case 9 : sValor = sValor & "Nueve"
            End Select
        End If
        If iNMil > 0 Then
            If iNMil Mod 2 <> 0 Then
                If iUnid > 0 Or iDece > 0 Or iCent > 0 Then sValor = sValor & " Mil "
            Else
                If iUnid > 0 Or iDece > 0 Or iCent > 0 Then
                    Select Case iNMil
                        Case 2 : sValor = sValor & " Mill"
                        Case 4 : sValor = sValor & " Bill"
                        Case 6 : sValor = sValor & " Trill"
                        Case 8 : sValor = sValor & " Cuatrill"
                        Case 10 : sValor = sValor & " Quintill"
                        Case 12 : sValor = sValor & " Sextill"
                    End Select
                    If iUnid = 0 Or iUnid > 1 Then sValor = sValor & "ones " Else sValor = sValor & "ón "
                End If
            End If
        End If
        'ConvVal = LCase(Trim(sValor))
        ConvVal = Trim(sValor)
    End Function
    Public Function ValEnLetr(ByVal sValor As String) As String
        Dim iNMil As Integer, iVal As Integer, iCMil As Integer
        Dim sLetras As String = "", iLLetras As Integer, iPMil As Integer
        iLLetras = 1
        iNMil = Len(sValor) \ 3
        If Len(sValor) Mod 3 <> 0 Then
            iVal = Val(Left(sValor, Len(sValor) Mod 3))
            iLLetras = (Len(sValor) Mod 3) + 1
            sLetras = ConvVal(iVal, iNMil)
        End If
        For iCMil = iNMil To 1 Step -1
            iVal = Val(Mid(sValor, iLLetras, 3))
            If sLetras <> vbNullString Then sLetras = sLetras & " "
            iPMil = iCMil - 1
            sLetras = sLetras & ConvVal(iVal, iPMil)
            iLLetras = iLLetras + 3
        Next iCMil

        ValEnLetr = sLetras & " y 00/100 Nuevos Soles"
    End Function
End Module
