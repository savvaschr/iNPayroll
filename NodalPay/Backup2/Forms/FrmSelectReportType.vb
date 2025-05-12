Public Class FrmSelectReportType

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim Continue1 As Boolean = False
        Dim ReportType As String = 1
        If Me.RadioPDF.Checked Then
            ReportType = 1

        End If
        If Me.RadioPrinter.Checked Then
            ReportType = 2
        End If
        If Me.RadioSendToScreen.Checked Then
            ReportType = 3
        End If
        If Me.RadioExcel.Checked Then
            ReportType = 4
        End If

        If ReportType = 3 Then
            Dim ans As New MsgBoxResult
            ans = MsgBox("This option will show one by one all report results on screen, Do you want to Continue ?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then
                Continue1 = True
            End If
        Else
            Continue1 = True
        End If
        If Continue1 Then
            CType(Me.Owner, frmPrMsEmployees).GLBExportReportType = ReportType
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CType(Me.Owner, frmPrMsEmployees).GLBExportReportType = 0
        Dim ans As New MsgBoxResult
        ans = MsgBox("Cancel Report ?", MsgBoxStyle.YesNo)
        If ans = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

  
End Class