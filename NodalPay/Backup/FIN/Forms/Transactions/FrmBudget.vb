Public Class FrmBudget
    Dim GLBAnl1 As DataSet
    Dim GLBAnl2 As DataSet
    Dim GLBAnl3 As DataSet
    Dim GLBAnl4 As DataSet
    Dim GLBAnl5 As DataSet
    Dim GLBAnl6 As DataSet
    Dim GLBAnl7 As DataSet
    Dim GLBAnl8 As DataSet
    Dim GLBAnl9 As DataSet
    Dim GLBAnl10 As DataSet

    Dim Col_Id As Integer = 0
    Dim Col_BudCode As Integer = 1
    Dim Col_PrdCode As Integer = 2
    Dim Col_AccSearch As Integer = 3
    Dim Col_AccCode As Integer = 4
    Dim Col_AccDesc As Integer = 5
    Dim Col_Amount As Integer = 6
    Dim Col_Anl1 As Integer = 7
    Dim Col_Anl2 As Integer = 8
    Dim Col_Anl3 As Integer = 9
    Dim Col_Anl4 As Integer = 10
    Dim Col_Anl5 As Integer = 11
    Dim Col_Anl6 As Integer = 12
    Dim Col_Anl7 As Integer = 13
    Dim Col_Anl8 As Integer = 14
    Dim Col_Anl9 As Integer = 15
    Dim Col_Anl10 As Integer = 16

    Dim Col_CreationDate As Integer = 17
    Dim Col_AmendDate As Integer = 18
    Dim Col_CreatedBy As Integer = 19
    Dim Col_AmendBy As Integer = 20

    Dim SpBudCode As New ArrayList
    Dim SpAccCode As New ArrayList


    Private Sub FrmBudget_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtTotalAmount.Text = "0.00"
        LoadAnalysis()
        LoadComboYear()
    End Sub
    Private Sub LoadComboYear()
        Dim i As Integer
        With ComboYears
            .BeginUpdate()
            .Items.Clear()
            For i = 2000 To 2100
                .Items.Add(i.ToString)
            Next
            .EndUpdate()
            .SelectedIndex = ComboYears.FindStringExact(Now.Year.ToString)
        End With
        LoadPeriods()
    End Sub
    Private Sub LoadPeriods()
        Dim Year As String
        Dim Ds As DataSet
        Dim i As Integer
        Year = Me.ComboYears.Text
        Ds = Global1.Business.GetFiscalPeriodsOfYear(Year, False, False)
        With Me.Prd_Code
            .Items.Clear()
            If CheckDataSet(Ds) Then
                Dim Period As New cFiscalPeriods
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Period = New cFiscalPeriods(Ds.Tables(0).Rows(i))
                    .Items.Add(Period)
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis()
        LoadAnalysis1()
        LoadAnalysis2()
        LoadAnalysis3()
        LoadAnalysis4()
        LoadAnalysis5()
        LoadAnalysis6()
        LoadAnalysis7()
        LoadAnalysis8()
        LoadAnalysis9()
        LoadAnalysis10()

    End Sub
    Private Sub LoadAnalysis1()
        Dim i As Integer
        With Me.AcLAn1_Code
            .Items.Clear()
            GLBAnl1 = Global1.Business.GetAllAccountLineAnalysisLevel1(1, True)
            If CheckDataSet(GLBAnl1) Then
                For i = 0 To GLBAnl1.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal1(GLBAnl1.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If

        End With
    End Sub
    Private Sub LoadAnalysis2()
        Dim i As Integer
        With Me.AcLAn2_Code
            .Items.Clear()
            GLBAnl2 = Global1.Business.GetAllAccountLineAnalysisLevel1(2, True)
            If CheckDataSet(GLBAnl2) Then
                For i = 0 To GLBAnl2.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal2(GLBAnl2.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis3()
        Dim i As Integer
        With Me.AcLAn3_Code

            .Items.Clear()
            GLBAnl3 = Global1.Business.GetAllAccountLineAnalysisLevel1(3, True)
            If CheckDataSet(GLBAnl3) Then
                For i = 0 To GLBAnl3.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal3(GLBAnl3.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis4()
        Dim i As Integer
        With Me.AcLAn4_Code
            .Items.Clear()
            GLBAnl4 = Global1.Business.GetAllAccountLineAnalysisLevel1(4, True)
            If CheckDataSet(GLBAnl4) Then
                For i = 0 To GLBAnl4.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal4(GLBAnl4.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis5()
        Dim i As Integer
        With Me.AcLAn5_Code
            .Items.Clear()
            GLBAnl5 = Global1.Business.GetAllAccountLineAnalysisLevel1(5, True)
            If CheckDataSet(GLBAnl5) Then
                For i = 0 To GLBAnl5.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal5(GLBAnl5.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis6()
        Dim i As Integer
        With Me.AcLAn6_Code
            .Items.Clear()
            GLBAnl6 = Global1.Business.GetAllAccountLineAnalysisLevel1(6, True)
            If CheckDataSet(GLBAnl6) Then
                For i = 0 To GLBAnl6.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal6(GLBAnl6.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis7()
        Dim i As Integer
        With Me.AcLAn7_Code
            .Items.Clear()
            GLBAnl7 = Global1.Business.GetAllAccountLineAnalysisLevel1(7, True)
            If CheckDataSet(GLBAnl7) Then
                For i = 0 To GLBAnl7.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal7(GLBAnl7.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis8()
        Dim i As Integer
        With Me.AcLAn8_Code
            .Items.Clear()
            GLBAnl8 = Global1.Business.GetAllAccountLineAnalysisLevel1(8, True)
            If CheckDataSet(GLBAnl8) Then
                For i = 0 To GLBAnl8.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal8(GLBAnl8.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis9()
        Dim i As Integer
        With Me.AcLAn9_Code
            .Items.Clear()
            GLBAnl9 = Global1.Business.GetAllAccountLineAnalysisLevel1(9, True)
            If CheckDataSet(GLBAnl9) Then
                For i = 0 To GLBAnl9.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal9(GLBAnl9.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub LoadAnalysis10()
        Dim i As Integer
        With Me.AcLAn10_Code
            .Items.Clear()
            GLBAnl10 = Global1.Business.GetAllAccountLineAnalysisLevel1(10, True)
            If CheckDataSet(GLBAnl10) Then
                For i = 0 To GLBAnl10.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal10(GLBAnl10.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl.ToString)
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub DG1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DG1.CellBeginEdit
        'Edit AccountCode
        If e.ColumnIndex = Col_AccCode Then
            If SpAccCode.Count > 0 Then
                If SpAccCode.Count <> e.RowIndex Then
                    SpAccCode.Item(e.RowIndex) = 1
                End If
            End If
        End If
    End Sub

    Private Sub DG1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellClick
        If e.ColumnIndex = Me.Col_AccSearch Then
            Dim F As New FrmAccountFINSearch
            F.CalledBy = 3
            F.RowIndex = e.RowIndex
            F.Owner = Me
            F.ShowDialog()
        End If
    End Sub

    Private Sub DG1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEndEdit
        If e.ColumnIndex = Me.Col_Amount Then
            Dim s As String
            s = DG1.Item(Col_Amount, e.RowIndex).Value

            If IsNumeric(s) Then
                DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = Format(CDbl(s), "0.00")
            Else
                DG1.Item(Col_Amount, DG1.CurrentRow.Index).Value = "0.00"
            End If
        End If
        CalculateAmount()

    End Sub
    Private Sub DG1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellValidated
        Try

            ' Search For Account Code
            If e.ColumnIndex = Col_AccCode Then
                Dim SearchForAccCode As Boolean = False
                If SpAccCode.Count = 0 Then
                    SpAccCode.Add(0)
                    SearchForAccCode = True
                Else
                    If SpAccCode.Count = e.RowIndex Then
                        SpAccCode.Add(0)
                        SearchForAccCode = True
                    Else
                        If SpAccCode.Item(e.RowIndex) = 1 Then
                            SearchForAccCode = True
                        End If
                    End If
                End If
                If SearchForAccCode Then
                    Dim AccCode As String = ""
                    If Me.DG1.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                        AccCode = ""
                    Else
                        AccCode = DbNullToString(Me.DG1.Item(e.ColumnIndex, e.RowIndex).Value)
                    End If
                    Dim A As New cAccount(AccCode)
                    If A.Code <> "" Then
                        Me.DG1.Item(Col_AccDesc, e.RowIndex).Value = A.DescriptionS
                        SetDefaultAnalysis(e.RowIndex)
                        Me.DG1.Item(Me.Col_Amount, e.RowIndex).Value = "0.00"
                    Else
                        Me.DG1.Item(Col_AccDesc, e.RowIndex).Value = ""
                        SetDefaultAnalysis(e.RowIndex)
                        Me.DG1.Item(Me.Col_Amount, e.RowIndex).Value = "0.00"
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub DG1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG1.DataError
       
    End Sub

    Private Sub DG1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyUp
        If e.KeyCode = Keys.Down Then
            If DG1.CurrentCell.ColumnIndex = Me.Col_Anl1 Then

            End If
        End If
    End Sub
    Private Sub txtBudgetCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBudgetCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            FindBudget()
        End If
    End Sub
    Private Sub txtBudgetCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetCode.Validated
        FindBudget()
    End Sub
    Public Sub FindBudget()
        Dim Bud As New cFiMsBudget
        If Me.txtBudgetCode.Text <> "" Then
            Bud = New cFiMsBudget(Trim(Me.txtBudgetCode.Text))
            If Bud.Bud_Code <> "" Then
                Me.txtBudgetDesc.Text = Bud.Bud_DescriptionL
                Err1.SetError(Me.txtBudgetCode, "")
            Else
                Me.txtBudgetDesc.Text = ""
                Err1.SetError(Me.txtBudgetCode, "Invalid Account Code")
            End If
        Else
            Me.BtnBudgetSearch.Focus()
        End If
    End Sub
    Public Sub LoadBudget(ByVal Code As String, ByVal Desc As String)
        Me.Err1.SetError(Me.txtBudgetCode, "")
        Me.txtBudgetCode.Text = Code
        Me.txtBudgetDesc.Text = Desc
    End Sub
    Public Sub LoadAccount(ByVal Code As String, ByVal Desc As String, ByVal RowIndex As Integer)
        DG1.Item(Me.Col_AccCode, RowIndex).Value = Code
        DG1.Item(Me.Col_AccDesc, RowIndex).Value = Desc
        Me.DG1.Item(Me.Col_Amount, RowIndex).Value = "0.00"
        SetDefaultAnalysis(RowIndex)
    End Sub

    Private Sub BtnBudgetSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBudgetSearch.Click
        Dim F As New FrmBudgetSearch
        F.CalledBy = 1
        F.Owner = Me
        F.Show()
    End Sub
    
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If ValidateHeader Then
            If ValidateLines() Then
                Dim Exx As New Exception
                Dim i As Integer
                Try

                
                    Global1.Business.BeginTransaction()
                    For i = 0 To DG1.RowCount - 2
                        Dim B As New cFiTxBudgetLines
                        With B
                            .BudLin_Id = 0
                            .Bud_Code = Me.txtBudgetCode.Text
                            .Prd_Code = DG1.Item(Me.Col_PrdCode, i).Value
                            .Acc_Code = DG1.Item(Me.Col_AccCode, i).Value
                            .AcLAn1_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl1, i).Value)
                            .AcLAn2_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl2, i).Value)
                            .AcLAn3_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl3, i).Value)
                            .AcLAn4_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl4, i).Value)
                            .AcLAn5_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl5, i).Value)
                            .AcLAn6_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl6, i).Value)
                            .AcLAn7_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl7, i).Value)
                            .AcLAn8_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl8, i).Value)
                            .AcLAn9_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl9, i).Value)
                            .AcLAn10_Code = FindAnalysisCode(DG1.Item(Me.Col_Anl10, i).Value)
                            .BudLin_Amount = DG1.Item(Me.Col_Amount, i).Value
                            .BudLin_CreatedBy = Global1.GLBUserId
                            .BudLin_AmendBy = Global1.GLBUserId
                            .BudLin_AmendDate = Now.Date
                            .BudLin_CreationDate = Now.Date
                            If Not .Save Then
                                Throw Exx
                            End If
                        End With
                    Next
                    Global1.Business.CommitTransaction()
                    MsgBox("Budget is succesfully saved", MsgBoxStyle.Information)
                    Me.BtnSave.Enabled = False
                    Me.DG1.ReadOnly = True
                Catch ex As Exception
                    Utils.ShowException(ex)
                    Global1.Business.Rollback()

                End Try
            End If
        End If
    End Sub
    Private Function FindAnalysisCode(ByVal S As String) As String
        Dim RetValue As String = ""
        Dim Ar() As String
        If Trim(S) = "$" Then
            RetValue = "$"
        Else
            Ar = Split(Trim(S), "-")
            RetValue = Ar(0)
        End If
        Return RetValue
    End Function
    Private Function ValidateHeader() As Boolean
        Dim Flag As Boolean = True
        Dim str As String
        If Me.txtBudgetDesc.Text = "" Then
            Flag = False
            str = "Please Select Budget First!" & Chr(13) & _
            "Unable to Save Budgets"
            MsgBox(str, MsgBoxStyle.Critical)
        End If
        Return Flag
    End Function
    Private Function ValidateLines() As Boolean
        Dim i As Integer
        Dim Flag As Boolean = True
        Dim Str As String = ""
        If DG1.RowCount = 1 Then
            Flag = False
            MsgBox("There Are no Lines on the Grid", MsgBoxStyle.Critical)
        Else

            For i = 0 To DG1.RowCount - 2
                If DG1.Item(Me.Col_PrdCode, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Period for Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_AccDesc, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Account for Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Amount, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Amount for Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl1, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 1 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl2, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 2 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl3, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 3 For Line" & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl4, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 4 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl5, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 5 Forr Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl6, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 6 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl7, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 7 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl8, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 8 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl9, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 9 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
                If DG1.Item(Me.Col_Anl10, i).Value = "" Then
                    Flag = False
                    Str = "Please Select Analysis 10 For Line " & i + 1 & "!" & Chr(13) & _
                    "Unable to Save Budgets"
                    Exit For
                End If
            Next
            If Not Flag Then
                MsgBox(Str, MsgBoxStyle.Critical)
            End If
        End If
        Return Flag
    End Function
    Private Sub SetDefaultAnalysis(ByVal RowIndex As Integer)
        DG1.Item(Me.Col_Anl1, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl2, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl3, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl4, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl5, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl6, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl7, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl8, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl9, RowIndex).Value = "$ - NA"
        DG1.Item(Me.Col_Anl10, RowIndex).Value = "$ - NA"
    End Sub
    Private Sub CalculateAmount()
        Dim TotalAmount As Double = 0

        Dim i As Integer
        Dim s As String
        For i = 0 To DG1.RowCount - 1
            Try
                s = DG1.Item(Me.Col_Amount, i).Value
                TotalAmount = TotalAmount + CDbl(s)
            Catch ex As Exception

            End Try
        Next

        txtTotalAmount.Text = Format(TotalAmount, "0.00")
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        DG1.Rows.Clear()
        SpBudCode = New ArrayList
        SpAccCode = New ArrayList
        Me.txtBudgetCode.Text = ""
        Me.txtBudgetDesc.Text = ""
        Me.BtnSave.Enabled = True
        Me.txtTotalAmount.Text = "0.00"
        Me.DG1.ReadOnly = False
    End Sub
End Class