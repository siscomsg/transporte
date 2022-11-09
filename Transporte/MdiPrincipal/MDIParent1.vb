Imports System.Windows.Forms

Public Class MDIPrincipal
    Dim y As Integer = 1
    Private Sub MDIPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmLogeo.Close()
        Call coneccion()
        tsslCodUser.Text = codigo_user
        tsslCodUbi.Text = codubi_user
        tsslUsuario.Text = nombre_user
        tsslUbigeo.Text = Ubigeo_user
        tsslTitulos.Text = Me.Text
    End Sub

    Private Sub RutasHorariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasHorariosToolStripMenuItem.Click
        FrmEleccion.MdiParent = Me
        FrmEleccion.Show()
        tsslTitulos.Text = FrmEleccion.Text
    End Sub

    Private Sub ManifiestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManifiestoToolStripMenuItem.Click
        frmManifiesto.MdiParent = Me
        frmManifiesto.Show()
        tsslTitulos.Text = frmManifiesto.Text
    End Sub

    Private Sub ConductoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConductoresToolStripMenuItem.Click
        FrmConductores.MdiParent = Me
        FrmConductores.Show()
        tsslTitulos.Text = FrmConductores.Text
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim Titulo As String = ".:: EMPRESA DE TRANSPORTES POOL S.R.L. - SERVICIO DORADO ::."
        Me.Text = Mid(Titulo, 1, y)
        y = y + 1
        If y = 73 Then
            y = 1
        End If
    End Sub

    Private Sub EdiciónPorBusesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdiciónPorBusesToolStripMenuItem1.Click
        frmCargaAs.MdiParent = Me
        frmCargaAs.Show()
        tsslTitulos.Text = frmCargaAs.Text
    End Sub

    Private Sub AgregarUnidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarUnidadesToolStripMenuItem.Click
        frmBuses.MdiParent = Me
        frmBuses.Show()
        tsslTitulos.Text = frmBuses.Text
    End Sub

    Private Sub EstablecerViajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstablecerViajesToolStripMenuItem.Click
        FrmViajes.MdiParent = Me
        FrmViajes.Show()
        tsslTitulos.Text = FrmViajes.Text
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Dim respuesta As String
        respuesta = MsgBox("Desea Salir del Sistema??", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Exit System")
        If respuesta = vbYes Then
            End
        End If
    End Sub

    Private Sub ResumenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenToolStripMenuItem.Click
        FrmReporte.MdiParent = Me
        FrmReporte.Show()
        tsslTitulos.Text = FrmReporte.Text
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        frmAbout.MdiParent = Me
        frmAbout.Show()
        tsslTitulos.Text = frmAbout.Text
    End Sub

    Private Sub ReporteGralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteGralToolStripMenuItem.Click
        FrmRepGral.MdiParent = Me
        FrmRepGral.Show()
        tsslTitulos.Text = FrmRepGral.Text
    End Sub

End Class
