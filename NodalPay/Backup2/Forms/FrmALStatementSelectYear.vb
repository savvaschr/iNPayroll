Public Class FrmALStatementSelectYear

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(Me.Owner, FrmPrTxEmployeeLeave).PrintYear = Me.TextBox1.Text

        Me.Close()
    End Sub
End Class