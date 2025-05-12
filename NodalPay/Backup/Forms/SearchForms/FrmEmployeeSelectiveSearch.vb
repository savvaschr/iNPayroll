Public Class FrmEmployeeSelectiveSearch
    Public CalledBy As Integer
    Public RowIndex As Integer
    Public TempGroup As String
    Public Ds As DataSet
    Dim Counter As Integer = 0
  

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        Counter = 0
        Me.CBSelectGrid.Checked = True
        SearchForCustomer("", 1, "")
        Cursor = Cursors.Default
    End Sub
    Private Sub SearchForCustomer(ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String)
        Dim Code As String
        Dim Description As String
        Dim ActiveOnly As Boolean = False

        Code = Me.txtCode.Text
        Description = Me.txtDescription.Text

        'If CalledBy = 1 Then
        '    CustomerOnly = True
        'ElseIf CalledBy = 2 Then
        '    CustomerOnly = True
        'End If
        Ds = Global1.Business.SearchForEmployeeByUser2(Code, Description, SearchCode, NextOrPrevius, PreviusSearchCode, ActiveOnly, TempGroup, Global1.UserName)
        Me.DG1.DataSource = Ds.Tables(0)


    End Sub

  

    Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnSearch.Focus()
        End If
    End Sub


    Private Sub txtDescription_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnSearch.Focus()
        End If
    End Sub

   


 
  

    Private Sub CBSelectGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSelectGrid.CheckedChanged
        If CheckDataSet(Ds) Then
            If CBSelectGrid.CheckState = CheckState.Checked Then
                Dim i As Integer
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Ds.Tables(0).Rows(i).Item(0) = "1"
                Next
            Else
                Dim i As Integer
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Ds.Tables(0).Rows(i).Item(0) = "0"
                Next
            End If
        End If
    End Sub

    Private Sub btnFinishSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinishSelection.Click
        If CheckDataSet(Ds) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            If i <= Ds.Tables(0).Rows.Count - 1 Then

                Dim code As String
                Dim Desc As String
                code = DbNullToString(DG1.Item(0, i).Value)
                Desc = DbNullToString(DG1.Item(1, i).Value)
                If Me.CalledBy = 1 Then
                    '    Dim Emp As New cPrMsEmployees(code)
                    '   CType(Me.Owner, frmPrMsEmployees).txtCode.Text = code
                    '  CType(Me.Owner, frmPrMsEmployees).LoadEmployee(Emp)
                ElseIf Me.CalledBy = 2 Then
                    ' Dim Emp As New cPrMsEmployees(code)
                    'CType(Me.Owner, frmPrTxCalc1).LoadEmployee(Emp)
                ElseIf Me.CalledBy = 3 Then
                    'CType(Me.Owner, FrmPayroll1).txtFromEmployee.Text = code
                    'CType(Me.Owner, FrmPayroll1).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 4 Then
                    'CType(Me.Owner, FrmPayroll1).txtToEmployee.Text = code
                ElseIf Me.CalledBy = 5 Then
                    CType(Me.Owner, FrmIR63A).SelectedEmployeesDS = Ds
                ElseIf Me.CalledBy = 6 Then
                    'CType(Me.Owner, FrmIR63A).SelectedEmployeesDS = Ds
                ElseIf Me.CalledBy = 7 Then
                    'CType(Me.Owner, FrmPayrollTotals).txtFromEmployee.Text = code
                ElseIf Me.CalledBy = 8 Then
                    'CType(Me.Owner, FrmPayrollTotals).txtToEmployee.Text = code
                End If

                Me.Close()
            End If
        End If
    End Sub

    
End Class