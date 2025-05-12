Public Class FrmEmployeeLoanSearch
    Public EmpCode As String
    Dim Ds As DataSet
   
    Private Sub FrmEmployeeLoanSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SearchForLoan(EmpCode)
    End Sub
    Private Sub SearchForLoan(ByVal SearchCode As String)
        Dim ActiveOnly As Boolean = False

        Ds = Global1.Business.GetEmployeeLoans(SearchCode)
        Me.DG1.DataSource = Ds.Tables(0)
    End Sub

    Private Sub DG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.DoubleClick
        If CheckDataSet(Ds) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            If i <= Ds.Tables(0).Rows.Count - 1 Then
                Dim code As String
                Dim Desc As String
                code = DbNullToString(DG1.Item(0, i).Value)
                CType(Me.Owner, FrmLoanTransaction).loadLoansOfCode(code)
                Me.Close()
            End If
        End If
    End Sub


   
End Class