Public Class FrmBudgetSearch
    Public CalledBy As Integer
    Dim Ds As DataSet
    Dim LastCode As String
    Dim Counter As Integer = 0
    Dim ArBegin(5000) As String
    Dim ArEnd(5000) As String

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        Counter = 0
        ReDim ArBegin(5000)
        ReDim ArEnd(5000)
        SearchForBudget("", 1, "")
        Me.EnablePreviusNext(True)
        Cursor = Cursors.Default
    End Sub
    Private Sub SearchForBudget(ByVal SearchCode As String, ByVal NextOrPrevius As Integer, ByVal PreviusSearchCode As String)
        Dim Code As String
        Dim Description As String

        Code = Me.txtCode.Text
        Description = Me.txtDescription.Text

        'If CalledBy = 1 Then
        '    CustomerOnly = True
        'ElseIf CalledBy = 2 Then
        '    CustomerOnly = True
        'End If
        Ds = Global1.Business.SearchForBudget(Code, Description, SearchCode, NextOrPrevius, PreviusSearchCode, True)
        Me.DG1.DataSource = Ds.Tables(0)


    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        If CheckDataSet(Ds) Then
            Dim Row As Integer
            Dim Code As String
            Row = Ds.Tables(0).Rows.Count - 1
            Code = DbNullToString(Ds.Tables(0).Rows(Row).Item(0))
            ArBegin(Counter) = DbNullToString(Ds.Tables(0).Rows(0).Item(0))
            ArEnd(Counter) = DbNullToString(Ds.Tables(0).Rows(Row).Item(0))
            SearchForBudget(Code, 1, "")
            Counter = Counter + 1
        End If
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        If CheckDataSet(Ds) Or Counter > 0 Then
            If Counter = 0 Then Exit Sub
            Counter = Counter - 1
            SearchForBudget(ArBegin(Counter), -1, ArEnd(Counter))
        End If
    End Sub

    Private Sub txtCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtDescription.Focus()
        End If
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        EnablePreviusNext(False)
    End Sub

    Private Sub txtDescription_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnSearch.Focus()
        End If
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        EnablePreviusNext(False)
    End Sub


    Private Sub EnablePreviusNext(ByVal TF As Boolean)
        Me.BtnNext.Enabled = TF
        Me.BtnPrevius.Enabled = TF
    End Sub
    Private Sub DG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.DoubleClick
        If CheckDataSet(Ds) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            If i <= Ds.Tables(0).Rows.Count - 1 Then

                Dim code As String
                Dim Desc As String
                code = DbNullToString(DG1.Item(0, i).Value)
                Desc = DbNullToString(DG1.Item(1, i).Value)
                If Me.CalledBy = 1 Then
                    CType(Me.Owner, FrmBudget).LoadBudget(code, Desc)
                    Me.Close()
                End If
            End If
        End If
    End Sub
End Class