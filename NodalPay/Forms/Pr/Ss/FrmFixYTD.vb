Public Class FrmFixYTD

    Private Sub btnReCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReCalc.Click
        Dim EmpCode As String
        Dim PeriodGroup As String
        EmpCode = Me.txtEmpCode.Text
        PeriodGroup = Me.txtPeriodGroup.Text

        Global1.Business.FixEmployeeYTD(EmpCode, periodGroup)
        MsgBox("Finish")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PeriodGroup As String
        PeriodGroup = Me.txtPeriodgroup2.Text

        Global1.Business.FixPeriodGroupContributionsYTD(PeriodGroup)
        MsgBox("Finish")
    End Sub
End Class