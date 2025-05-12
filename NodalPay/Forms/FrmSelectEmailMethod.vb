Public Class FrmSelectEmailMethod
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub FrmSelectEmailMethod_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim emailMethod As Integer = 0
        If Me.RadioButton1.Checked Then
            emailMethod = 1
        End If
        If Me.RadioButton2.Checked Then
            emailMethod = 2
        End If
        If Me.RadioButton3.Checked Then
            emailMethod = 3
        End If

        CType(Me.Owner, FrmPayroll1).YTDEmailmethod = emailMethod
        If Me.CBSchedule.CheckState <> CheckState.Checked Then
            CType(Me.Owner, FrmPayroll1).YTDScheduled = False
            CType(Me.Owner, FrmPayroll1).YTDscheduledDatetime = Now
        Else
            CType(Me.Owner, FrmPayroll1).YTDScheduled = True
            Dim SCDate As Date
            SCDate = Me.Date1.Value.Date & " " & Me.Time1.Value.Hour & ":" & Me.Time1.Value.Minute & ":" & Me.Time1.Value.Second
            CType(Me.Owner, FrmPayroll1).YTDscheduledDatetime = SCDate
        End If
    End Sub

    Private Sub CBSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles CBSchedule.CheckedChanged
        If CBSchedule.CheckState = CheckState.Checked Then
            Me.Date1.Enabled = True
            Me.Time1.Enabled = True
        Else
            Me.Date1.Enabled = False
            Me.Time1.Enabled = False
        End If
    End Sub

    Private Sub FrmSelectEmailMethod_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CBSchedule.Checked = False
        Me.Date1.Value = Now.Date
        Me.Date1.MinDate = Now.Date
        Me.Time1.Value = Now

    End Sub
End Class