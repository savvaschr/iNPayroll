Public Class FrmTxInterfaceDate

    Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
        Dim F As Boolean = False
        CType(Me.Owner, FrmPayroll1).NavisionPostingdate = Me.DateNavPost.Value.Date
        If Me.CBIncludeEmployees.CheckState = CheckState.Checked Then
            F = True
        End If
        CType(Me.Owner, FrmPayroll1).IncludeEmployees = F
        Me.Close()
    End Sub

    Private Sub FrmTxInterfaceDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DateNavPost.Value = Now.Date
        CType(Me.Owner, FrmPayroll1).NavisionPostingdate = Me.DateNavPost.Value.Date
    End Sub

End Class