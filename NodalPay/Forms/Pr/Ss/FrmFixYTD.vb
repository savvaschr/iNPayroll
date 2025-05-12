Public Class FrmFixYTD

    Private Sub btnReCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReCalc.Click
        Dim EmpCode As String
        Dim PeriodGroup As String
        EmpCode = Me.txtEmpCode.Text
        PeriodGroup = Me.txtPeriodGroup.Text

        Global1.Business.FixEmployeeYTD(EmpCode, periodGroup)
        MsgBox("Finish")
    End Sub
End Class