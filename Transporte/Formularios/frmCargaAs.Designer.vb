<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaAs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaAs))
        Me.cmdAsignar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPisos = New System.Windows.Forms.TextBox()
        Me.txtAsiento1 = New System.Windows.Forms.TextBox()
        Me.txtAsiento2 = New System.Windows.Forms.TextBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDisenio = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstBus = New System.Windows.Forms.ListBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAsignar
        '
        Me.cmdAsignar.Enabled = False
        Me.cmdAsignar.Image = Global.Pasajes.My.Resources.Resources.accept
        Me.cmdAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAsignar.Location = New System.Drawing.Point(244, 165)
        Me.cmdAsignar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAsignar.Name = "cmdAsignar"
        Me.cmdAsignar.Size = New System.Drawing.Size(176, 35)
        Me.cmdAsignar.TabIndex = 0
        Me.cmdAsignar.Text = "&Establecer Diseño"
        Me.cmdAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdAsignar, "Establecer Diseño de Unidad")
        Me.cmdAsignar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(241, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Pisos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 99)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Asientos 1er Piso:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 129)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Asientos 2do Piso:"
        '
        'txtPisos
        '
        Me.txtPisos.Location = New System.Drawing.Point(294, 54)
        Me.txtPisos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPisos.Name = "txtPisos"
        Me.txtPisos.ReadOnly = True
        Me.txtPisos.Size = New System.Drawing.Size(51, 22)
        Me.txtPisos.TabIndex = 6
        '
        'txtAsiento1
        '
        Me.txtAsiento1.Location = New System.Drawing.Point(369, 93)
        Me.txtAsiento1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAsiento1.Name = "txtAsiento1"
        Me.txtAsiento1.ReadOnly = True
        Me.txtAsiento1.Size = New System.Drawing.Size(51, 22)
        Me.txtAsiento1.TabIndex = 7
        '
        'txtAsiento2
        '
        Me.txtAsiento2.Location = New System.Drawing.Point(369, 123)
        Me.txtAsiento2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAsiento2.Name = "txtAsiento2"
        Me.txtAsiento2.ReadOnly = True
        Me.txtAsiento2.Size = New System.Drawing.Size(51, 22)
        Me.txtAsiento2.TabIndex = 8
        '
        'cmdSalir
        '
        Me.cmdSalir.Image = Global.Pasajes.My.Resources.Resources.X
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(244, 201)
        Me.cmdSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(176, 35)
        Me.cmdSalir.TabIndex = 9
        Me.cmdSalir.Text = "&Salir"
        Me.ToolTip1.SetToolTip(Me.cmdSalir, "Salir")
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Controls.Add(Me.chkDisenio)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdAsignar)
        Me.GroupBox1.Controls.Add(Me.txtAsiento2)
        Me.GroupBox1.Controls.Add(Me.txtAsiento1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPisos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 288)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Diseñar:"
        '
        'chkDisenio
        '
        Me.chkDisenio.AutoSize = True
        Me.chkDisenio.Location = New System.Drawing.Point(15, 268)
        Me.chkDisenio.Name = "chkDisenio"
        Me.chkDisenio.Size = New System.Drawing.Size(128, 17)
        Me.chkDisenio.TabIndex = 13
        Me.chkDisenio.Text = ".:: Listar Diseñados ::."
        Me.chkDisenio.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstBus)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(15, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(205, 227)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = ".:: Elija Un Bus ::."
        '
        'lstBus
        '
        Me.lstBus.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lstBus.FormattingEnabled = True
        Me.lstBus.ItemHeight = 16
        Me.lstBus.Location = New System.Drawing.Point(6, 21)
        Me.lstBus.Name = "lstBus"
        Me.lstBus.Size = New System.Drawing.Size(193, 196)
        Me.lstBus.TabIndex = 11
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(236, 243)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(184, 23)
        Me.ProgressBar1.TabIndex = 10
        Me.ProgressBar1.Visible = False
        '
        'frmCargaAs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.ClientSize = New System.Drawing.Size(457, 305)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCargaAs"
        Me.Text = ".:: Selección de Vehiculo a Editar ::."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAsignar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPisos As System.Windows.Forms.TextBox
    Friend WithEvents txtAsiento1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAsiento2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstBus As System.Windows.Forms.ListBox
    Friend WithEvents chkDisenio As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
