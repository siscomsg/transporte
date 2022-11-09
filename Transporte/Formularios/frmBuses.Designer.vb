<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuses
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuses))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picBus = New System.Windows.Forms.PictureBox()
        Me.btnGarga = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPiso2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPiso1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gridBuses = New System.Windows.Forms.DataGridView()
        Me.ofdAbre = New System.Windows.Forms.OpenFileDialog()
        Me.sfdGraba = New System.Windows.Forms.SaveFileDialog()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdDesactivar = New System.Windows.Forms.Button()
        Me.CmdSalir = New System.Windows.Forms.Button()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridBuses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Placa:"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(66, 32)
        Me.txtPlaca.MaxLength = 8
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(100, 20)
        Me.txtPlaca.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.picBus)
        Me.GroupBox1.Controls.Add(Me.btnGarga)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPiso2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPiso1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPlaca)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 258)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = ".:: Buses ::."
        '
        'picBus
        '
        Me.picBus.Image = Global.Pasajes.My.Resources.Resources.no_disponible
        Me.picBus.Location = New System.Drawing.Point(197, 16)
        Me.picBus.Name = "picBus"
        Me.picBus.Size = New System.Drawing.Size(337, 236)
        Me.picBus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBus.TabIndex = 10
        Me.picBus.TabStop = False
        '
        'btnGarga
        '
        Me.btnGarga.Image = Global.Pasajes.My.Resources.Resources.spyware
        Me.btnGarga.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGarga.Location = New System.Drawing.Point(20, 200)
        Me.btnGarga.Name = "btnGarga"
        Me.btnGarga.Size = New System.Drawing.Size(158, 52)
        Me.btnGarga.TabIndex = 9
        Me.btnGarga.Text = "Cargar Imagen Unidad"
        Me.btnGarga.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGarga, "Cargar imagen para asignarlo a unidad")
        Me.btnGarga.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(66, 58)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(37, 20)
        Me.NumericUpDown1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Asientos 2do Piso:"
        '
        'txtPiso2
        '
        Me.txtPiso2.Location = New System.Drawing.Point(131, 107)
        Me.txtPiso2.MaxLength = 2
        Me.txtPiso2.Name = "txtPiso2"
        Me.txtPiso2.Size = New System.Drawing.Size(45, 20)
        Me.txtPiso2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Asientos 1er Piso:"
        '
        'txtPiso1
        '
        Me.txtPiso1.Location = New System.Drawing.Point(131, 81)
        Me.txtPiso1.MaxLength = 2
        Me.txtPiso1.Name = "txtPiso1"
        Me.txtPiso1.Size = New System.Drawing.Size(45, 20)
        Me.txtPiso1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Pisos:"
        '
        'gridBuses
        '
        Me.gridBuses.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.gridBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBuses.Location = New System.Drawing.Point(12, 276)
        Me.gridBuses.Name = "gridBuses"
        Me.gridBuses.Size = New System.Drawing.Size(444, 159)
        Me.gridBuses.TabIndex = 3
        '
        'ofdAbre
        '
        Me.ofdAbre.FileName = "OpenFileDialog1"
        '
        'cmdEditar
        '
        Me.cmdEditar.Image = Global.Pasajes.My.Resources.Resources.Editar
        Me.cmdEditar.Location = New System.Drawing.Point(462, 399)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(37, 36)
        Me.cmdEditar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cmdEditar, "Editar Datos de Unidad")
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdDesactivar
        '
        Me.cmdDesactivar.Image = Global.Pasajes.My.Resources.Resources.Borrar
        Me.cmdDesactivar.Location = New System.Drawing.Point(514, 399)
        Me.cmdDesactivar.Name = "cmdDesactivar"
        Me.cmdDesactivar.Size = New System.Drawing.Size(37, 36)
        Me.cmdDesactivar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.cmdDesactivar, "Eliminar Item Seleccionado")
        Me.cmdDesactivar.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.Pasajes.My.Resources.Resources.X
        Me.CmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdSalir.Location = New System.Drawing.Point(464, 357)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(87, 36)
        Me.CmdSalir.TabIndex = 8
        Me.CmdSalir.Text = "&Salir"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Enabled = False
        Me.CmdGrabar.Image = Global.Pasajes.My.Resources.Resources.Ok
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGrabar.Location = New System.Drawing.Point(464, 276)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(88, 36)
        Me.CmdGrabar.TabIndex = 7
        Me.CmdGrabar.Text = "&Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CmdGrabar, "Guardar Datos")
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Pasajes.My.Resources.Resources.Atributos
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportar.Location = New System.Drawing.Point(464, 315)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(88, 36)
        Me.btnExportar.TabIndex = 11
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnExportar, "Exportar Datos a Excel")
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Serie Bus:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(131, 133)
        Me.txtSerie.MaxLength = 2
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(45, 20)
        Me.txtSerie.TabIndex = 12
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(43, 176)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(130, 18)
        Me.chkActivo.TabIndex = 13
        Me.chkActivo.Text = "Activar / Desactivar"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'frmBuses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(564, 447)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdDesactivar)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.gridBuses)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuses"
        Me.Text = ".:: Registro de Unidades ::."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picBus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridBuses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPiso2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPiso1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gridBuses As System.Windows.Forms.DataGridView
    Friend WithEvents cmdDesactivar As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents btnGarga As System.Windows.Forms.Button
    Friend WithEvents picBus As System.Windows.Forms.PictureBox
    Friend WithEvents ofdAbre As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdGraba As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmdEditar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
End Class
