Public Class FrmTestEncryption

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim s As String
        s = Me.TextBox1.Text
        s = Utils.SimpleCrypt(s)
        Me.TextBox2.Text = s


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As String
        s = Me.TextBox2.Text
        s = Utils.SimpleCrypt(s)
        Me.TextBox1.Text = s
    End Sub


End Class