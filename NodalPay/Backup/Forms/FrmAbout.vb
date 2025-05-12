Public Class FrmAbout
    Private Sub FrmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblVersion.Text = "Version " & Global1.Version
        Me.Top = 0
        Me.Left = 0
    End Sub
End Class