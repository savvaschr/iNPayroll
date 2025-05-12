
Public Class FrmTest
    Public Ds As DataSet


    Private Sub FrmTest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DG1.DataSource = Ds.Tables(0)
    End Sub
End Class