Public Class FrmTAReportDates
    Friend FromDate As Date
    Friend ToDate As Date
    Public MyOwner As FrmTATrxnLines
    Private Sub RadioMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMonth.CheckedChanged
        If RadioMonth.Checked = True Then
            Dim Fdate As Date
            Dim tDate As Date
            Dim D As String
            D = Format(FromDate.Month, "00") & "/" & "01" & "/" & Format(FromDate.Year, "0000")
            Fdate = CDate(D)
            DateFrom.Value = Fdate
            Fdate = DateAdd(DateInterval.Month, 1, Fdate)
            DateTo.Value = DateAdd(DateInterval.Day, -1, Fdate)
            Me.DateFrom.Enabled = False
            Me.DateTo.Enabled = False
        End If
    End Sub

    Private Sub RadioWeek_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioWeek.CheckedChanged
        If RadioWeek.Checked = True Then
            Me.DateFrom.Value = FromDate
            Me.DateTo.Value = ToDate
            Me.DateFrom.Enabled = False
            Me.DateTo.Enabled = False
        End If

    End Sub

    Private Sub RadioDays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDays.CheckedChanged
        If RadioDays.Checked = True Then
            Me.DateFrom.Enabled = True
            Me.DateTo.Enabled = True
            Me.DateFrom.Value = FromDate
            Me.DateTo.Value = FromDate
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        CType(MyOwner, FrmTATrxnLines).CallMonthlyReport(DateFrom.Value, DateTo.Value)
        Me.Close()
    End Sub

    Private Sub FrmTAReportDates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DateFrom.Value = Now
        Me.DateTo.Value = Now
        FromDate = Now
        ToDate = Now
        RadioMonth.Checked = True
    End Sub
End Class