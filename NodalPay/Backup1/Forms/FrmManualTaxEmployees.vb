Public Class FrmManualTaxEmployees
    Public Ds As DataSet

    Private Sub FrmManualTaxEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG1.DataSource = Ds.Tables(0)
    End Sub

End Class