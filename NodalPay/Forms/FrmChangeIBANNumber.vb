Public Class FrmChangeIBANNumber

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Continue1 As Boolean = False
        Dim OldIBAN As String = ""
        Dim NewIBAN As String = ""

        If Me.txtOldIBAN.Text = "" Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Old IBAN/Account Code is blank , continue", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                Continue1 = True
            End If
        Else
            Continue1 = True
        End If

        If Continue1 Then
            oldiban = Me.txtOldIBAN.Text
            If Me.txtNewIBAN.Text = "" Then
                MsgBox("New IBAN/Account Code cannot be blank")
                Exit Sub
            Else
                NewIBAN = Me.txtNewIBAN.Text
                If Global1.Business.ReplaceIBANno(OldIBAN, NewIBAN) Then
                    MsgBox("IBAN/Account code is replaced succesfully", MsgBoxStyle.Information)
                Else
                    MsgBox("Unable to replace IBAN/Account Code ", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub
End Class