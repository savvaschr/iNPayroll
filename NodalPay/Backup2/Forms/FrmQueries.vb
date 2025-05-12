Public Class FrmQueries

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Str As String
        Str = Me.txtQueries.Text
        Dim ds As DataSet
        ds = Global1.Business.ExecuteWithResults(Str)
        DG1.DataSource = ds.Tables(0)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Str As String
        Str = Me.txtQueries.Text
        Dim i As Integer
        i = Global1.Business.ExecuteWithOUTResults(Str)
        MsgBox(i)
    End Sub

    Private Sub FrmQueries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Button1.Enabled = False
        Me.Button2.Enabled = False


    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Me.TextBox1.Text = "36132" Then
                Me.Button1.Enabled = True
                Me.Button2.Enabled = True
            End If
        End If
    End Sub

    
    
    Private Sub FrmQueries_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Me.DG1.Width = Me.Width - 40
        Me.DG1.Height = Me.Height - Me.DG1.Top - 50
    End Sub

   
  
End Class