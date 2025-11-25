Public Class FrmClosePeriodEmployees
    Public DsEmployees As DataSet

    Private Sub FrmClosePeriodEmployees_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DG1.DataSource = DsEmployees.Tables(0)
    End Sub
End Class