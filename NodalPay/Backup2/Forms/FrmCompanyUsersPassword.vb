Public Class FrmCompanyUsersPassword
    Dim Password As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBox1.Text = Password Then
            CType(Me.Owner, FrmAdMsCompany).AllowAddUserMenu = True
            Me.Close()
        Else
            MsgBox("Invalid Password !", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub FrmCompanyUsersPassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ds As New DataSet

        Ds = Global1.Business.GetParameter("System", "CRYPTO")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Password = Par.Value1.Replace("!", "")
        End If
    End Sub
End Class