<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEleccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEleccion))
        Me.lstDestinos = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lstHorarios = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstDestinos
        '
        Me.lstDestinos.BackColor = System.Drawing.Color.SteelBlue
        Me.lstDestinos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstDestinos.ForeColor = System.Drawing.Color.White
        Me.lstDestinos.FormattingEnabled = True
        Me.lstDestinos.ItemHeight = 19
        Me.lstDestinos.Location = New System.Drawing.Point(6, 25)
        Me.lstDestinos.Name = "lstDestinos"
        Me.lstDestinos.Size = New System.Drawing.Size(203, 211)
        Me.lstDestinos.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.lstDestinos, "Seleccione Destino .:: Haga doble clic para continuar ::.")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.lstHorarios)
        Me.GroupBox1.Controls.Add(Me.lstDestinos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 272)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DESTINOS"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.Blue
        Me.lblFecha.Location = New System.Drawing.Point(227, 8)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(41, 14)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Label2"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Green
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 244)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(430, 18)
        Me.ProgressBar1.TabIndex = 8
        Me.ProgressBar1.Visible = False
        '
        'lstHorarios
        '
        Me.lstHorarios.BackColor = System.Drawing.Color.SteelBlue
        Me.lstHorarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstHorarios.ForeColor = System.Drawing.Color.White
        Me.lstHorarios.FormattingEnabled = True
        Me.lstHorarios.ItemHeight = 19
        Me.lstHorarios.Location = New System.Drawing.Point(221, 25)
        Me.lstHorarios.Name = "lstHorarios"
        Me.lstHorarios.Size = New System.Drawing.Size(203, 211)
        Me.lstHorarios.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.lstHorarios, "Seleccione Horario .:: Haga doble clic para continuar ::.")
        '
        'FrmEleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(455, 296)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FrmEleccion"
        Me.Text = ".:: Eleccion de Destinos y Horarios ::."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstDestinos As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstHorarios As System.Windows.Forms.ListBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
