Public Class FrmPasswordForDeletion
    Public myOwner As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If myOwner = 1 Then
            CType(Me.Owner, FrmPayroll1).PasswordForDeletion = Me.TextBox1.Text
            Me.Close()
        ElseIf myOwner = 2 Then
            CType(Me.Owner, FrmLoanTransaction).PasswordForDeletion = Me.TextBox1.Text
            Me.Close()
        End If
    End Sub
End Class