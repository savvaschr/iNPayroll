Public Class FrmBankSearch
    Dim Ds As DataSet
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim Code As String = Me.txtCode.Text
        Dim Desc As String = Me.txtDescription.Text
        Dim Swift As String = Me.txtSwift.Text

        Ds = Global1.Business.SearchForBanks(Code, Desc, Swift)
        Me.DG1.DataSource = Ds.Tables(0)

    End Sub
   

    Private Sub DG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.DoubleClick
        Dim i As Integer
        i = DG1.CurrentRow.Index
        If i <= Ds.Tables(0).Rows.Count - 1 Then
            Dim code As String
            Dim Desc As String
            code = DbNullToString(DG1.Item(0, i).Value)
            Desc = DbNullToString(DG1.Item(1, i).Value)

            CType(Me.Owner, frmPrAnBanks).FindBanks(code)
            Me.Close()
        End If
    End Sub

  
End Class