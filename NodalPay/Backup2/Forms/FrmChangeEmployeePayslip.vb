Public Class FrmChangeEmployeePayslip

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Continue1 As Boolean = False
        Dim OldPayslip As String = ""
        Dim NewPayslip As String = ""

        If Me.txtOldPayslip.Text = "" Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Old Payslip/Account Code is blank , continue", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                Continue1 = True
            End If
        Else
            Continue1 = True
        End If

        If Continue1 Then
            OldPayslip = Me.txtOldPayslip.Text
            If Me.txtNewPayslip.Text = "" Then
                MsgBox("New Payslip/Account Code cannot be blank")
                Exit Sub
            Else
                NewPayslip = Me.txtNewPayslip.Text
                If Global1.Business.ReplacePayslipReport(OldPayslip, NewPayslip) Then
                    MsgBox("Payslip/Account code is replaced succesfully", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to replace Payslip/Account Code ", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

End Class