Public Class FrmMyReminders
    Public TemGroup As cPrMsTemplateGroup
    Public Period As cPrMsPeriodCodes
    Dim MyDs As DataSet

    Private Sub FrmMyReminders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FromDate.Value = Period.DateFrom
        Me.ToDate.Value = Period.DateTo
        Me.cbIsActive.Checked = True
        Search()
    End Sub
    Private Sub Search()
        Dim FromDate As Date = Me.FromDate.Value
        Dim ToDate As Date = Me.ToDate.Value
        Dim OnlyActive As Boolean = False
        If Me.cbIsActive.CheckState = CheckState.Checked Then
            OnlyActive = True
        End If
        MyDs = Global1.Business.GetRemindersForPeriodForTemGroup(TemGroup.Code, FromDate, ToDate, OnlyActive)
        DG1.DataSource = MyDs.Tables(0)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Search()
    End Sub

    Private Sub btnShowReminder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReminder.Click
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            Dim id As Integer
            id = DbNullToInt(MyDs.Tables(0).Rows(i).Item(0))
            Dim Rem1 As New cPrMsReminders(id)
            Dim F As New FrmPrMsReminder
            F.Owner = Me
            Dim Emp As New cPrMsEmployees(Rem1.EmpCode)
            F.Employee = Emp
            F.EmpCode = Emp.Code
            F.BtnNext.Enabled = False
            F.BtnPrevius.Enabled = False
            F.ShowDialog()

        End If
    End Sub

    Private Sub btnDeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeactivate.Click
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            Dim id As Integer
            id = DbNullToInt(MyDs.Tables(0).Rows(i).Item(0))
            Dim Rem1 As New cPrMsReminders(id)
            Rem1.DeactivatedBy = Global1.UserName
            Rem1.DeactivatedAt = Now.Date
            Rem1.IsActive = "N"
            If Not Rem1.Save() Then
                MsgBox("Unable to Deactivate Reminder", MsgBoxStyle.Critical)
            Else
                MsgBox("Reminder is De-activated", MsgBoxStyle.Information)
                Search()
            End If
        End If
    End Sub
End Class