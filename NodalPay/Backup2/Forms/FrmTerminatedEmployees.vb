Public Class FrmTerminatedEmployees
    Public DsTerm As DataSet
    Private Sub FrmTerminatedEmployees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DG1.DataSource = DsTerm.Tables(0)
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        CType(Me.Owner, FrmPrTxClosePeriod).MakeEmployeesInactive(DsTerm)
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class