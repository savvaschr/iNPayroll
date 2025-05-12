Public Class FrmChangePassword
    Private Sub FrmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtOldPass.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txtNewPass.Text = "" Then
            MsgBox("'New Password' Field cannot be blank", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Me.txtNewPass.Text = Me.txtReNewPass.Text Then
            Dim User As String
            Dim NewPwd As String
            Dim OldPwd As String
            User = Global1.UserName
            NewPwd = Me.txtNewPass.Text
            OldPwd = Me.txtOldPass.Text
            If Global1.Business.ChangePassword(User, OldPwd, NewPwd) Then
                MsgBox("Password was succefully changed, Its important to Logout and then Login with your new credentials !", MsgBoxStyle.Information)
            Else
                MsgBox("Password was not changed", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("'New Password' and 'Verify New Password' fields must be the same!", MsgBoxStyle.Critical)
        End If
        Me.txtReNewPass.Text = ""
        Me.txtNewPass.Text = ""
        Me.txtOldPass.Text = ""
        Me.txtReNewPass.BackColor = Color.White
        Me.txtOldPass.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.Button2.Text = "View" Then
            Me.Button2.Text = "Hide"
            Me.txtOldPass.PasswordChar = ""
            Me.txtNewPass.PasswordChar = ""
            Me.txtReNewPass.PasswordChar = ""
        Else
            Me.Button2.Text = "View"
            Me.txtOldPass.PasswordChar = "*"
            Me.txtNewPass.PasswordChar = "*"
            Me.txtReNewPass.PasswordChar = "*"

        End If
    End Sub

    Private Sub txtReNewPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReNewPass.TextChanged
        If Me.txtReNewPass.Text = Me.txtNewPass.Text Then
            Me.txtReNewPass.BackColor = Color.LightGreen
        Else
            Me.txtReNewPass.BackColor = Color.Red
        End If
    End Sub

    Private Sub txtNewPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewPass.TextChanged
        Me.txtReNewPass.Text = ""
        Me.txtReNewPass.BackColor = Color.White

    End Sub

    
End Class