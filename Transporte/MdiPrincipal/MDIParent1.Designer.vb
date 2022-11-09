<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RutasHorariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargaDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConductoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarUnidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdiciónPorBusesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViajesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstablecerViajesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpresionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManifiestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteGralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsslTitulos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCodUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCodUbi = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUbigeo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackgroundImage = Global.Pasajes.My.Resources.Resources.Fondo13
        Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem, Me.CargaDataToolStripMenuItem, Me.ImpresionesToolStripMenuItem, Me.SalirToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip.Size = New System.Drawing.Size(106, 430)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RutasHorariosToolStripMenuItem})
        Me.ToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.ToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icon_Pasaje
        Me.ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.ToolStripMenuItem.Text = "Venta Pasajes"
        '
        'RutasHorariosToolStripMenuItem
        '
        Me.RutasHorariosToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icono_Bus
        Me.RutasHorariosToolStripMenuItem.Name = "RutasHorariosToolStripMenuItem"
        Me.RutasHorariosToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.RutasHorariosToolStripMenuItem.Text = "&Seleccion de Destino y Horarios"
        '
        'CargaDataToolStripMenuItem
        '
        Me.CargaDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConductoresToolStripMenuItem, Me.BusesToolStripMenuItem, Me.ViajesToolStripMenuItem1})
        Me.CargaDataToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.CargaDataToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.storage
        Me.CargaDataToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CargaDataToolStripMenuItem.Name = "CargaDataToolStripMenuItem"
        Me.CargaDataToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.CargaDataToolStripMenuItem.Text = "Cargar Datos"
        '
        'ConductoresToolStripMenuItem
        '
        Me.ConductoresToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icono_MasUser
        Me.ConductoresToolStripMenuItem.Name = "ConductoresToolStripMenuItem"
        Me.ConductoresToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConductoresToolStripMenuItem.Text = "C&onductores"
        '
        'BusesToolStripMenuItem
        '
        Me.BusesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarUnidadesToolStripMenuItem, Me.EdiciónPorBusesToolStripMenuItem1})
        Me.BusesToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icono_Bus
        Me.BusesToolStripMenuItem.Name = "BusesToolStripMenuItem"
        Me.BusesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BusesToolStripMenuItem.Text = "&Buses"
        '
        'AgregarUnidadesToolStripMenuItem
        '
        Me.AgregarUnidadesToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icono_MasBus
        Me.AgregarUnidadesToolStripMenuItem.Name = "AgregarUnidadesToolStripMenuItem"
        Me.AgregarUnidadesToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.AgregarUnidadesToolStripMenuItem.Text = "&Agregar Unidades"
        '
        'EdiciónPorBusesToolStripMenuItem1
        '
        Me.EdiciónPorBusesToolStripMenuItem1.Image = Global.Pasajes.My.Resources.Resources.bus_maintenace
        Me.EdiciónPorBusesToolStripMenuItem1.Name = "EdiciónPorBusesToolStripMenuItem1"
        Me.EdiciónPorBusesToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
        Me.EdiciónPorBusesToolStripMenuItem1.Text = "&Edición de Asientos"
        '
        'ViajesToolStripMenuItem1
        '
        Me.ViajesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstablecerViajesToolStripMenuItem})
        Me.ViajesToolStripMenuItem1.Image = Global.Pasajes.My.Resources.Resources.Atributos
        Me.ViajesToolStripMenuItem1.Name = "ViajesToolStripMenuItem1"
        Me.ViajesToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ViajesToolStripMenuItem1.Text = "Viajes"
        '
        'EstablecerViajesToolStripMenuItem
        '
        Me.EstablecerViajesToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icono_Copia
        Me.EstablecerViajesToolStripMenuItem.Name = "EstablecerViajesToolStripMenuItem"
        Me.EstablecerViajesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EstablecerViajesToolStripMenuItem.Text = "Establecer Viajes"
        '
        'ImpresionesToolStripMenuItem
        '
        Me.ImpresionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManifiestoToolStripMenuItem, Me.ResumenToolStripMenuItem, Me.ReporteGralToolStripMenuItem})
        Me.ImpresionesToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.ImpresionesToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.icono_imp
        Me.ImpresionesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ImpresionesToolStripMenuItem.Name = "ImpresionesToolStripMenuItem"
        Me.ImpresionesToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.ImpresionesToolStripMenuItem.Text = "Reportes"
        '
        'ManifiestoToolStripMenuItem
        '
        Me.ManifiestoToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Icono_Back
        Me.ManifiestoToolStripMenuItem.Name = "ManifiestoToolStripMenuItem"
        Me.ManifiestoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ManifiestoToolStripMenuItem.Text = "&Manifiesto"
        '
        'ResumenToolStripMenuItem
        '
        Me.ResumenToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.spyware
        Me.ResumenToolStripMenuItem.Name = "ResumenToolStripMenuItem"
        Me.ResumenToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ResumenToolStripMenuItem.Text = "Resume&n"
        '
        'ReporteGralToolStripMenuItem
        '
        Me.ReporteGralToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.Atributos
        Me.ReporteGralToolStripMenuItem.Name = "ReporteGralToolStripMenuItem"
        Me.ReporteGralToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ReporteGralToolStripMenuItem.Text = "Reporte Gral."
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.SalirToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.X
        Me.SalirToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.AcercaDeToolStripMenuItem.Image = Global.Pasajes.My.Resources.Resources.escalera
        Me.AcercaDeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.AcercaDeToolStripMenuItem.Text = "About"
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTitulos, Me.tsslCodUser, Me.ToolStripStatusLabel1, Me.tsslUsuario, Me.ToolStripStatusLabel2, Me.tsslCodUbi, Me.tsslUbigeo})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 430)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(833, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'tsslTitulos
        '
        Me.tsslTitulos.Name = "tsslTitulos"
        Me.tsslTitulos.Size = New System.Drawing.Size(111, 17)
        Me.tsslTitulos.Text = "ToolStripStatusLabel3"
        '
        'tsslCodUser
        '
        Me.tsslCodUser.Name = "tsslCodUser"
        Me.tsslCodUser.Size = New System.Drawing.Size(111, 17)
        Me.tsslCodUser.Text = "ToolStripStatusLabel3"
        Me.tsslCodUser.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(47, 17)
        Me.ToolStripStatusLabel1.Text = "Usuario:"
        '
        'tsslUsuario
        '
        Me.tsslUsuario.Name = "tsslUsuario"
        Me.tsslUsuario.Size = New System.Drawing.Size(111, 17)
        Me.tsslUsuario.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(98, 17)
        Me.ToolStripStatusLabel2.Text = "Terminal Asignado:"
        '
        'tsslCodUbi
        '
        Me.tsslCodUbi.Name = "tsslCodUbi"
        Me.tsslCodUbi.Size = New System.Drawing.Size(111, 17)
        Me.tsslCodUbi.Text = "ToolStripStatusLabel2"
        Me.tsslCodUbi.Visible = False
        '
        'tsslUbigeo
        '
        Me.tsslUbigeo.Name = "tsslUbigeo"
        Me.tsslUbigeo.Size = New System.Drawing.Size(111, 17)
        Me.tsslUbigeo.Text = "ToolStripStatusLabel3"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Pasajes.My.Resources.Resources.Logo1
        Me.ClientSize = New System.Drawing.Size(833, 452)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIPrincipal"
        Me.Text = ".:: EMPRESA DE TRANSPORTES POOL S.R.L. - SERVICIO DORADO ::."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCodUbi As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCodUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUbigeo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RutasHorariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsslTitulos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImpresionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManifiestoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargaDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConductoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BusesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdiciónPorBusesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarUnidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViajesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstablecerViajesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteGralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
