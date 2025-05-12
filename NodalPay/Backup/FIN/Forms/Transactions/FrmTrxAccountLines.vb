Public Class FrmTrxAccountLines
    'Dim GLBJournalType As String = "STD"
    Dim GLBJournalCodesDS As DataSet
    Dim GLBPeriodsDs As DataSet
    Dim GLBCurenciesDs As DataSet
    Dim GLBReversePeriod As cFiscalPeriods
    Dim GlbReversalEntry As Boolean

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


    Dim MyDs As DataSet
    Dim Dt1 As DataTable

    Dim Col_JouLineNo As Integer = 0
    Dim Col_AccCode As Integer = 1
    Dim Col_AccDesc As Integer = 2
    Dim Col_Debit As Integer = 3
    Dim Col_Credit As Integer = 4
    Dim Col_DocDate As Integer = 5
    Dim Col_DocRef As Integer = 6
    Dim Col_AltRef As Integer = 7
    Dim Col_Comment As Integer = 8
    Dim Col_PostDate As Integer = 9
    Dim Col_DueDate As Integer = 10
    Dim Col_PrdCode As Integer = 11
    Dim Col_BusPrtCode As Integer = 12
    Dim Col_DrCr As Integer = 13
    Dim Col_AmountLocCur As Integer = 14
    Dim Col_CurAlphaCode As Integer = 15
    Dim Col_AmountTrxCur As Integer = 16
    Dim Col_CurRate As Integer = 17
    Dim Col_TrxCurDecimal As Integer = 18

    Dim Col_AcLAn1Code As Integer = 19
    Dim Col_AcLAn2Code As Integer = 20
    Dim Col_AcLAn3Code As Integer = 21
    Dim Col_AcLAn4Code As Integer = 22
    Dim Col_AcLAn5Code As Integer = 23
    Dim Col_AcLAn6Code As Integer = 24
    Dim Col_AcLAn7Code As Integer = 25
    Dim Col_AcLAn8Code As Integer = 26
    Dim Col_AcLAn9Code As Integer = 27
    Dim Col_AcLAn10Code As Integer = 28
    Dim Col_AllocStatus As Integer = 29
    Dim Col_AllocRef As Integer = 30
    Dim Col_AllocBalanceLC As Integer = 31
    Dim Col_AllocBalanceTC As Integer = 32
    Dim Col_AllocDate As Integer = 33
    Dim Col_AllocPeriod As Integer = 34

    Dim Col_ExternalRef As Integer = 35
    Dim Col_Module As Integer = 36
    Dim Col_ModRef As Integer = 37
    Dim CurrentRow As Integer = 0

    Dim DoNotVisitNow As Boolean = False



    Private Sub FrmTrxAccountLines_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0

        LoadComboJournalCodes()
        LoadPeriods()
        LoadAnalysis()
        LoadCurencies()
        InitDataTable()
        InitDataGrid()
        FixDecimalOnlyFields()
        ClearHeaderFields()
        ClearLineFields()
        CalculateTotals()
        Dim Acc As New cAccount
        FixAnalysis(Acc)

    End Sub
    Private Sub LockScreen(ByVal TF As Boolean)
        Me.Dg1.ReadOnly = TF
        Me.GroupBox2.Enabled = Not TF
        Me.btnSave.Enabled = Not TF


    End Sub
    Private Sub ClearHeaderFields()

        Dim S As String
        S = Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0")
        If CheckDataSet(Me.GLBPeriodsDs) Then
            Me.ComboPeriods.SelectedIndex = Me.ComboPeriods.FindStringExact(S)
        End If
        Me.MSKTxtPostDate.Text = Format(Now.Date, ("dd/MM/yyyy"))
        Me.ComboJournalCode.SelectedIndex = 0
        Me.txtJournalNo.Text = ""

    End Sub
    Private Sub ClearLineFields()

        Me.txtTotalDebit.Text = "0.00"
        Me.txtTotalCredit.Text = "0.00"
        Me.MSKtxtDocDate.Text = Me.MSKTxtPostDate.Text
        Me.txtDocRef.Text = ""
        Me.txtAltRef.Text = ""
        Me.txtComment.Text = ""
        Me.txtBalanceDebit.Text = "0.00"
        Me.txtBalanceCredit.Text = "0.00"
        Me.txtDebit.Text = ""
        Me.txtCredit.Text = ""

    End Sub
    Private Sub FixDecimalOnlyFields()
        AddHandler txtDebit.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtDebit.Leave, AddressOf Utils.NumericOnLeaveWithEmpty

        AddHandler txtCredit.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtCredit.Leave, AddressOf Utils.NumericOnLeaveWithEmpty

        AddHandler txtCurRate.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtCurRate.Leave, AddressOf Utils.NumericOnLeave
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
        With Me.ComboAnl1
            .BeginUpdate()
            .Items.Clear()
            GLBAnl1 = Global1.Business.GetAllAccountLineAnalysisLevel1(1, True)
            If CheckDataSet(GLBAnl1) Then
                For i = 0 To GLBAnl1.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal1(GLBAnl1.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis2()
        Dim i As Integer
        With Me.ComboAnl2
            .BeginUpdate()
            .Items.Clear()
            GLBAnl2 = Global1.Business.GetAllAccountLineAnalysisLevel1(2, True)
            If CheckDataSet(GLBAnl2) Then
                For i = 0 To GLBAnl2.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal2(GLBAnl2.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis3()
        Dim i As Integer
        With Me.ComboAnl3
            .BeginUpdate()
            .Items.Clear()
            GLBAnl3 = Global1.Business.GetAllAccountLineAnalysisLevel1(3, True)
            If CheckDataSet(GLBAnl3) Then
                For i = 0 To GLBAnl3.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal3(GLBAnl3.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis4()
        Dim i As Integer
        With Me.ComboAnl4
            .BeginUpdate()
            .Items.Clear()
            GLBAnl4 = Global1.Business.GetAllAccountLineAnalysisLevel1(4, True)
            If CheckDataSet(GLBAnl4) Then
                For i = 0 To GLBAnl4.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal4(GLBAnl4.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis5()
        Dim i As Integer
        With Me.ComboAnl5
            .BeginUpdate()
            .Items.Clear()
            GLBAnl5 = Global1.Business.GetAllAccountLineAnalysisLevel1(5, True)
            If CheckDataSet(GLBAnl5) Then
                For i = 0 To GLBAnl5.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal5(GLBAnl5.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis6()
        Dim i As Integer
        With Me.ComboAnl6
            .BeginUpdate()
            .Items.Clear()
            GLBAnl6 = Global1.Business.GetAllAccountLineAnalysisLevel1(6, True)
            If CheckDataSet(GLBAnl6) Then
                For i = 0 To GLBAnl6.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal6(GLBAnl6.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis7()
        Dim i As Integer
        With Me.ComboAnl7
            .BeginUpdate()
            .Items.Clear()
            GLBAnl7 = Global1.Business.GetAllAccountLineAnalysisLevel1(7, True)
            If CheckDataSet(GLBAnl7) Then
                For i = 0 To GLBAnl7.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal7(GLBAnl7.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis8()
        Dim i As Integer
        With Me.ComboAnl8
            .BeginUpdate()
            .Items.Clear()
            GLBAnl8 = Global1.Business.GetAllAccountLineAnalysisLevel1(8, True)
            If CheckDataSet(GLBAnl8) Then
                For i = 0 To GLBAnl8.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal8(GLBAnl8.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis9()
        Dim i As Integer
        With Me.ComboAnl9
            .BeginUpdate()
            .Items.Clear()
            GLBAnl9 = Global1.Business.GetAllAccountLineAnalysisLevel1(9, True)
            If CheckDataSet(GLBAnl9) Then
                For i = 0 To GLBAnl9.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal9(GLBAnl9.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadAnalysis10()
        Dim i As Integer
        With Me.ComboAnl10
            .BeginUpdate()
            .Items.Clear()
            GLBAnl10 = Global1.Business.GetAllAccountLineAnalysisLevel1(10, True)
            If CheckDataSet(GLBAnl10) Then
                For i = 0 To GLBAnl10.Tables(0).Rows.Count - 1
                    Dim Anl As New cAccountLineAnal10(GLBAnl10.Tables(0).Rows(i))
                    If Anl.Code <> "" Then
                        .Items.Add(Anl)
                    End If
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub

    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        Dg1.DataSource = MyDs.Tables(0)

    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("JouLineNo", System.Type.GetType("System.Int32"))
        '1
        Dt1.Columns.Add("AccCode", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("AccDesc", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("Debit", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("Credit", System.Type.GetType("System.String"))
        '5
        Dt1.Columns.Add("DocDate", System.Type.GetType("System.DateTime"))
        '6
        Dt1.Columns.Add("DocRef", System.Type.GetType("System.String"))
        '7
        Dt1.Columns.Add("AltRef", System.Type.GetType("System.String"))
        '8
        Dt1.Columns.Add("Comment", System.Type.GetType("System.String"))
        '9
        Dt1.Columns.Add("PostDate", System.Type.GetType("System.DateTime"))
        '10
        Dt1.Columns.Add("DueDate", System.Type.GetType("System.DateTime"))
        '11
        Dt1.Columns.Add("PrdCode", System.Type.GetType("System.String"))
        '12
        Dt1.Columns.Add("BusPrtCode", System.Type.GetType("System.String"))
        '13
        Dt1.Columns.Add("DrCr", System.Type.GetType("System.String"))
        '14
        Dt1.Columns.Add("AmountLocCur", System.Type.GetType("System.Double"))
        '15
        Dt1.Columns.Add("CurAlphaCode", System.Type.GetType("System.String"))
        '16
        Dt1.Columns.Add("AmountTrxCur", System.Type.GetType("System.Double"))
        '17
        Dt1.Columns.Add("CurRate", System.Type.GetType("System.Double"))
        '18
        Dt1.Columns.Add("TrxCurDecimal", System.Type.GetType("System.Int32"))
        '19
        Dt1.Columns.Add("AcLAn1Code", System.Type.GetType("System.String"))
        '20
        Dt1.Columns.Add("AcLAn2Code", System.Type.GetType("System.String"))
        '21
        Dt1.Columns.Add("AcLAn3Code", System.Type.GetType("System.String"))
        '22
        Dt1.Columns.Add("AcLAn4Code", System.Type.GetType("System.String"))
        '23
        Dt1.Columns.Add("AcLAn5Code", System.Type.GetType("System.String"))
        '24
        Dt1.Columns.Add("AcLAn6Code", System.Type.GetType("System.String"))
        '25
        Dt1.Columns.Add("AcLAn7Code", System.Type.GetType("System.String"))
        '26
        Dt1.Columns.Add("AcLAn8Code", System.Type.GetType("System.String"))
        '27
        Dt1.Columns.Add("AcLAn9Code", System.Type.GetType("System.String"))
        '28
        Dt1.Columns.Add("AcLAn10Code", System.Type.GetType("System.String"))
        '29
        Dt1.Columns.Add("AllocStatus", System.Type.GetType("System.String"))
        '30
        Dt1.Columns.Add("AllocRef", System.Type.GetType("System.String"))
        '31
        Dt1.Columns.Add("AllocBalanceLC", System.Type.GetType("System.String"))
        '32
        Dt1.Columns.Add("AllocBalanceTC", System.Type.GetType("System.String"))
        '33
        Dt1.Columns.Add("AllocDate", System.Type.GetType("System.DateTime"))
        '34
        Dt1.Columns.Add("AllocPeriod", System.Type.GetType("System.String"))
        '35
        Dt1.Columns.Add("ExternalRef", System.Type.GetType("System.String"))
        '36
        Dt1.Columns.Add("Module", System.Type.GetType("System.String"))
        '37
        Dt1.Columns.Add("ModRef", System.Type.GetType("System.String"))


    End Sub
    Private Sub LoadPeriods()
        Dim P As New cFiscalPeriods
        Dim i As Integer

        GLBPeriodsDs = Global1.Business.GetFiscalPeriodsOfYear(Now.Year, True, True)
        If CheckDataSet(GLBPeriodsDs) Then
            With ComboPeriods
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To GLBPeriodsDs.Tables(0).Rows.Count - 1
                    P = New cFiscalPeriods(GLBPeriodsDs.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
                .EndUpdate()

            End With

        End If
    End Sub
    Private Sub LoadCurencies()
        Dim C As New cAdMsCurrency
        Dim i As Integer

        GLBCurenciesDs = Global1.Business.GetAllCurrencies()
        If CheckDataSet(GLBCurenciesDs) Then
            With Me.ComboCurency
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To GLBCurenciesDs.Tables(0).Rows.Count - 1
                    C = New cAdMsCurrency(GLBCurenciesDs.Tables(0).Rows(i))
                    .Items.Add(C)
                Next
                .EndUpdate()

            End With

        End If
    End Sub

    Private Sub LoadComboJournalCodes()
        Dim i As Integer
        With Me.ComboJournalCode
            .BeginUpdate()
            .Items.Clear()
            GLBJournalCodesDS = Global1.Business.GetAllJournalCodesForJournalEntry(True)
            If CheckDataSet(GLBJournalCodesDS) Then
                For i = 0 To GLBJournalCodesDS.Tables(0).Rows.Count - 1
                    Dim J As New cJournalCode(GLBJournalCodesDS.Tables(0).Rows(i))
                    .Items.Add(J)
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
    End Sub
    Private Sub ComboJournalCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboJournalCode.SelectedIndexChanged
        Try
            Me.txtJournalCodeDesc.Text = CType(Me.ComboJournalCode.SelectedItem, cJournalCode).Desc
        Catch ex As Exception
            Me.txtJournalCodeDesc.Text = ""
        End Try
    End Sub


    Private Sub btnAccountSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountSearch.Click
        Dim F As New FrmAccountFINSearch
        F.Owner = Me
        F.CalledBy = 1
        F.ShowDialog()
        Me.txtDebit.Focus()
        Me.txtDebit.SelectAll()
    End Sub

    Private Sub txtAccountCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            FindAccount()
            Me.txtDebit.Focus()
            Me.txtDebit.SelectAll()
        End If
    End Sub
    Private Sub txtAccountCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountCode.Validated
        FindAccount()
    End Sub
    Public Sub FindAccount()

        Me.Cursor = Cursors.WaitCursor
        Dim Acc As New cAccount
        If Me.txtAccountCode.Text <> "" Then
            Acc = New cAccount(Trim(Me.txtAccountCode.Text))
            If Acc.Code <> "" Then
                Me.txtAccountDesc.Text = Acc.DescriptionL
                Er1.SetError(Me.txtAccountCode, "")
                'if acc.CurCode <>LocalCurCode then
                Dim C As New cAdMsCurrency(Acc.CurCode)

                If C.AlphaCode <> "" Then
                    Me.ComboCurency.SelectedIndex = Me.ComboCurency.FindStringExact(C.ToString)
                    Dim Rate As Double
                    Rate = Global1.Business.GetCurruncyRate(C.AlphaCode, Now.Date)
                    Me.txtCurRate.Text = Format(Rate, "0.00")
                End If
                'endif
                If Acc.CurCode <> Global1.LocalCurencyCode Then
                    Me.ComboCurency.Focus()
                Else
                    Me.txtDebit.Focus()
                    Me.txtCurRate.Text = "1.00"
                End If

            Else
                Me.txtAccountDesc.Text = ""
                Er1.SetError(Me.txtAccountCode, "Invalid Account Code")
            End If
        Else
            Me.btnAccountSearch.Focus()
        End If
        FixAnalysis(Acc)
        Me.txtCredit.Text = ""
        Me.txtDebit.Text = ""
        Me.MSKtxtDocDate.Text = Me.MSKTxtPostDate.Text
        Me.txtDocRef.Text = ""
        Me.txtAltRef.Text = ""
        Me.txtComment.Text = ""
        SetCombosToFirstIndex()

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub SetCombosToFirstIndex()
        Me.ComboAnl1.SelectedIndex = 0
        Me.ComboAnl2.SelectedIndex = 0
        Me.ComboAnl3.SelectedIndex = 0
        Me.ComboAnl4.SelectedIndex = 0
        Me.ComboAnl5.SelectedIndex = 0
        Me.ComboAnl6.SelectedIndex = 0
        Me.ComboAnl7.SelectedIndex = 0
        Me.ComboAnl8.SelectedIndex = 0
        Me.ComboAnl9.SelectedIndex = 0
        Me.ComboAnl10.SelectedIndex = 0
    End Sub
    Private Sub FixAnalysis(ByVal Acc As cAccount)
        If Acc.Code = "" Then
            Me.LblAn1.Enabled = False
            Me.LblAn2.Enabled = False
            Me.LblAn3.Enabled = False
            Me.LblAn4.Enabled = False
            Me.LblAn5.Enabled = False
            Me.LblAn6.Enabled = False
            Me.LblAn7.Enabled = False
            Me.LblAn8.Enabled = False
            Me.LblAn9.Enabled = False
            Me.LblAn10.Enabled = False

            Me.ComboAnl1.Enabled = False
            Me.ComboAnl2.Enabled = False
            Me.ComboAnl3.Enabled = False
            Me.ComboAnl4.Enabled = False
            Me.ComboAnl5.Enabled = False
            Me.ComboAnl6.Enabled = False
            Me.ComboAnl7.Enabled = False
            Me.ComboAnl8.Enabled = False
            Me.ComboAnl9.Enabled = False
            Me.ComboAnl10.Enabled = False
        Else
            Dim Ds As DataSet
            Ds = Global1.Business.GetWhatAnalysisToUse(Acc.TAnGrpCode)
            If CheckDataSet(Ds) Then
                Me.LblAn1.Enabled = CheckDataRowForanalysis(Ds, 1)
                Me.ComboAnl1.Enabled = CheckDataRowForanalysis(Ds, 1)

                Me.LblAn2.Enabled = CheckDataRowForanalysis(Ds, 2)
                Me.ComboAnl2.Enabled = CheckDataRowForanalysis(Ds, 2)

                Me.LblAn3.Enabled = CheckDataRowForanalysis(Ds, 3)
                Me.ComboAnl3.Enabled = CheckDataRowForanalysis(Ds, 3)

                Me.LblAn4.Enabled = CheckDataRowForanalysis(Ds, 4)
                Me.ComboAnl4.Enabled = CheckDataRowForanalysis(Ds, 4)

                Me.LblAn5.Enabled = CheckDataRowForanalysis(Ds, 5)
                Me.ComboAnl5.Enabled = CheckDataRowForanalysis(Ds, 5)

                Me.LblAn6.Enabled = CheckDataRowForanalysis(Ds, 6)
                Me.ComboAnl6.Enabled = CheckDataRowForanalysis(Ds, 6)

                Me.LblAn7.Enabled = CheckDataRowForanalysis(Ds, 7)
                Me.ComboAnl7.Enabled = CheckDataRowForanalysis(Ds, 7)

                Me.LblAn8.Enabled = CheckDataRowForanalysis(Ds, 8)
                Me.ComboAnl8.Enabled = CheckDataRowForanalysis(Ds, 8)

                Me.LblAn9.Enabled = CheckDataRowForanalysis(Ds, 9)
                Me.ComboAnl9.Enabled = CheckDataRowForanalysis(Ds, 9)

                Me.LblAn10.Enabled = CheckDataRowForanalysis(Ds, 10)
                Me.ComboAnl10.Enabled = CheckDataRowForanalysis(Ds, 10)
            Else
                Me.LblAn1.Enabled = False
                Me.LblAn2.Enabled = False
                Me.LblAn3.Enabled = False
                Me.LblAn4.Enabled = False
                Me.LblAn5.Enabled = False
                Me.LblAn6.Enabled = False
                Me.LblAn7.Enabled = False
                Me.LblAn8.Enabled = False
                Me.LblAn9.Enabled = False
                Me.LblAn10.Enabled = False

                Me.ComboAnl1.Enabled = False
                Me.ComboAnl2.Enabled = False
                Me.ComboAnl3.Enabled = False
                Me.ComboAnl4.Enabled = False
                Me.ComboAnl5.Enabled = False
                Me.ComboAnl6.Enabled = False
                Me.ComboAnl7.Enabled = False
                Me.ComboAnl8.Enabled = False
                Me.ComboAnl9.Enabled = False
                Me.ComboAnl10.Enabled = False
            End If
        End If
    End Sub
    Private Function CheckDataRowForanalysis(ByVal Ds As DataSet, ByVal X As Integer)
        If DbNullToString(Ds.Tables(0).Rows(0).Item(X)) = "A" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        DoNotVisitNow = True
        AddRow()
        DoNotVisitNow = False

    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteRow()
    End Sub
    Private Sub DeleteRow()
        If CheckDataSet(MyDs) Then
            Me.DoNotVisitNow = True
            Dim i As Integer
            i = Dg1.CurrentRow.Index
            If i <= MyDs.Tables(0).Rows.Count - 1 Then
                MyDs.Tables(0).Rows(i).Delete()
            End If
            Me.DoNotVisitNow = False
            CurrentRow = 0
            Me.LoadFromGridCellsToLineDetails()
            ReArrangeLineCounter()
            Me.CalculateTotals()
        End If
    End Sub
    Private Sub ReArrangeLineCounter()
        If CheckDataSet(MyDs) Then
            Me.DoNotVisitNow = True
            Dim i As Integer
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                Dg1.Item(Me.Col_JouLineNo, i).Value = i + 1
            Next
            Me.DoNotVisitNow = False
        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        DoNotVisitNow = True
        EditRow()
        DoNotVisitNow = False
    End Sub
    Private Sub EditRow()
        Dim i As Integer
        If CheckDataSet(MyDs) Then
            Dim Rate As Double
            If MyDs.Tables(0).Rows.Count - 1 >= CurrentRow Then
                i = CurrentRow
                Dg1.Item(Col_AccCode, i).Value = Me.txtAccountCode.Text
                Dg1.Item(Col_BusPrtCode, i).Value = "$"
                Dg1.Item(Col_AccDesc, i).Value = Me.txtAccountDesc.Text
                If Me.txtDebit.Text = "" Then
                    Dg1.Item(Col_Debit, i).Value = ""
                Else
                    Dg1.Item(Col_Debit, i).Value = Format(CDbl(Me.txtDebit.Text), "0.00")
                End If

                If Me.txtCredit.Text = "" Then
                    Dg1.Item(Col_Credit, i).Value = ""
                Else
                    Dg1.Item(Col_Credit, i).Value = Format(CDbl(Me.txtCredit.Text), "0.00")
                End If
                Dg1.Item(Col_DocRef, i).Value = Me.txtDocRef.Text
                Dg1.Item(Col_AltRef, i).Value = Me.txtAltRef.Text
                Dg1.Item(Col_Comment, i).Value = Me.txtComment.Text
                Dg1.Item(Col_DocDate, i).Value = Utils.ChangeMaskedFields(Me.MSKtxtDocDate)
                Dg1.Item(Col_PostDate, i).Value = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
                Dg1.Item(Col_DueDate, i).Value = Now.Date 'System.DBNull.Value
                Dg1.Item(Col_PrdCode, i).Value = CType(Me.ComboPeriods.SelectedItem, cFiscalPeriods).Code
                Rate = Format(CDbl(Me.txtCurRate.Text), "0.00")
                Dg1.Item(Col_CurRate, i).Value = Format(CDbl(Me.txtCurRate.Text), "0.00")

                If Me.txtCredit.Text = "0.00" Or Me.txtCredit.Text = "" Then
                    Dg1.Item(Col_DrCr, i).Value = "D"
                    Dg1.Item(Col_AmountTrxCur, i).Value = Me.txtDebit.Text
                    Dg1.Item(Col_AllocBalanceTC, i).Value = Me.txtDebit.Text
                    Dg1.Item(Col_AmountLocCur, i).Value = Utils.RoundMe2(CDbl(Me.txtDebit.Text) * Rate, 2)
                    Dg1.Item(Col_AllocBalanceLC, i).Value = Utils.RoundMe2(CDbl(Me.txtDebit.Text * Rate), 2)

                Else
                    Dg1.Item(Col_DrCr, i).Value = "C"
                    Dg1.Item(Col_AmountTrxCur, i).Value = Me.txtCredit.Text
                    Dg1.Item(Col_AllocBalanceTC, i).Value = Me.txtCredit.Text
                    Dg1.Item(Col_AmountLocCur, i).Value = Utils.RoundMe2(CDbl(Me.txtCredit.Text) * Rate, 2)
                    Dg1.Item(Col_AllocBalanceLC, i).Value = Utils.RoundMe2(CDbl(Me.txtCredit.Text * Rate), 2)
                End If

                Dg1.Item(Col_CurAlphaCode, i).Value = Me.ComboCurency.Text ' CType(Me.ComboCurency.SelectedItem, cCurrency).AlphaCode
                Dg1.Item(Col_TrxCurDecimal, i).Value = 0 'Not Used

                'Analysis

                '1
                If ComboAnl1.Enabled Then
                    Dg1.Item(Col_AcLAn1Code, i).Value = ComboAnl1.Text
                Else
                    Dg1.Item(Col_AcLAn1Code, i).Value = "$"
                End If
                '2
                If ComboAnl2.Enabled Then
                    Dg1.Item(Col_AcLAn2Code, i).Value = ComboAnl2.Text
                Else
                    Dg1.Item(Col_AcLAn2Code, i).Value = "$"
                End If
                '3
                If ComboAnl3.Enabled Then
                    Dg1.Item(Col_AcLAn3Code, i).Value = ComboAnl3.Text
                Else
                    Dg1.Item(Col_AcLAn3Code, i).Value = "$"
                End If
                '4
                If ComboAnl4.Enabled Then
                    Dg1.Item(Col_AcLAn4Code, i).Value = ComboAnl4.Text
                Else
                    Dg1.Item(Col_AcLAn4Code, i).Value = "$"
                End If
                '5
                If ComboAnl5.Enabled Then
                    Dg1.Item(Col_AcLAn5Code, i).Value = ComboAnl5.Text
                Else
                    Dg1.Item(Col_AcLAn5Code, i).Value = "$"
                End If
                '6
                If ComboAnl6.Enabled Then
                    Dg1.Item(Col_AcLAn6Code, i).Value = ComboAnl6.Text
                Else
                    Dg1.Item(Col_AcLAn6Code, i).Value = "$"
                End If
                '7
                If ComboAnl7.Enabled Then
                    Dg1.Item(Col_AcLAn7Code, i).Value = ComboAnl7.Text
                Else
                    Dg1.Item(Col_AcLAn7Code, i).Value = "$"
                End If
                '8
                If ComboAnl8.Enabled Then
                    Dg1.Item(Col_AcLAn8Code, i).Value = ComboAnl8.Text
                Else
                    Dg1.Item(Col_AcLAn8Code, i).Value = "$"
                End If
                '9
                If ComboAnl9.Enabled Then
                    Dg1.Item(Col_AcLAn9Code, i).Value = ComboAnl9.Text
                Else
                    Dg1.Item(Col_AcLAn9Code, i).Value = "$"
                End If
                '10
                If ComboAnl10.Enabled Then
                    Dg1.Item(Col_AcLAn10Code, i).Value = ComboAnl10.Text
                Else
                    Dg1.Item(Col_AcLAn10Code, i).Value = "$"
                End If


                Dg1.Item(Col_AllocStatus, i).Value = "O"
                Dg1.Item(Col_AllocRef, i).Value = 0


                Dg1.Item(Col_AllocDate, i).Value = Now.Date 'Temp
                Dg1.Item(Col_AllocPeriod, i).Value = CType(Me.ComboPeriods.SelectedItem, cFiscalPeriods).Code

                'Dim Col_ExternalRef As Integer = 35
                Dg1.Item(Col_Module, i).Value = 1
                Dg1.Item(Col_ModRef, i).Value = ""

                CalculateTotals()
            End If
        End If
    End Sub
    Private Sub AddRow()
        If ValidateMe() Then
            Dim r As DataRow = Dt1.NewRow()
            Dim Rate As Double
            Dim Counter As Integer
            If CheckDataSet(MyDs) Then
                Counter = MyDs.Tables(0).Rows.Count + 1
            Else
                Dim Flag As Boolean = True
                If Me.MSKTxtPostDate.MaskCompleted Then
                    Try
                        Dim D As Date
                        D = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
                        Dim FP As cFiscalPeriods
                        FP = CType(ComboPeriods.SelectedItem, cFiscalPeriods)
                        If D >= FP.FromDate And D <= FP.ToDate Then
                            'ok
                        Else
                            Flag = False
                            MsgBox("Posting Date is Outside Period From - To Date bounds", MsgBoxStyle.Critical)
                        End If
                    Catch ex As Exception
                        MsgBox("Please Enter a Valid Posting Date", MsgBoxStyle.Critical)
                        Flag = False
                    End Try
                    If CType(Me.ComboJournalCode.SelectedItem, cJournalCode).TypeCode = "REV" Then
                        GLBReversePeriod = ValidateReverseEntry()
                        If GLBReversePeriod.Code = 0 Then
                            Flag = False
                        Else
                            GlbReversalEntry = True
                        End If
                    Else
                        GlbReversalEntry = False
                    End If
                Else
                    Flag = False
                    MsgBox("Please Enter a Posting Date", MsgBoxStyle.Critical)
                End If
                If Not Flag Then Exit Sub
                Counter = 1
                Me.GBDetails.Enabled = False
                Me.GBMain.Enabled = False
            End If

            r(Col_JouLineNo) = Counter
            r(Col_AccCode) = Me.txtAccountCode.Text
            r(Col_BusPrtCode) = "$"
            r(Col_AccDesc) = Me.txtAccountDesc.Text
            If Me.txtDebit.Text = "" Then
                r(Col_Debit) = ""
            Else
                r(Col_Debit) = Format(CDbl(Me.txtDebit.Text), "0.00")
            End If

            If Me.txtCredit.Text = "" Then
                r(Col_Credit) = ""
            Else
                r(Col_Credit) = Format(CDbl(Me.txtCredit.Text), "0.00")
            End If
            r(Col_DocRef) = Me.txtDocRef.Text
            r(Col_AltRef) = Me.txtAltRef.Text
            r(Col_Comment) = Me.txtComment.Text
            r(Col_DocDate) = Utils.ChangeMaskedFields(Me.MSKtxtDocDate)
            r(Col_PostDate) = Utils.ChangeMaskedFields(Me.MSKTxtPostDate)
            r(Col_DueDate) = Now.Date 'System.DBNull.Value
            r(Col_PrdCode) = CType(Me.ComboPeriods.SelectedItem, cFiscalPeriods).Code
            Rate = Format(CDbl(Me.txtCurRate.Text), "0.000000")
            r(Col_CurRate) = Format(CDbl(Me.txtCurRate.Text), "0.000000")

            If Me.txtCredit.Text = "0.00" Or Me.txtCredit.Text = "" Then
                r(Col_DrCr) = "D"
                r(Col_AmountTrxCur) = Me.txtDebit.Text
                r(Col_AllocBalanceTC) = Me.txtDebit.Text
                r(Col_AmountLocCur) = Utils.RoundMe2(CDbl(Me.txtDebit.Text) * Rate, 2)
                r(Col_AllocBalanceLC) = Utils.RoundMe2(CDbl(Me.txtDebit.Text * Rate), 2)

            Else
                r(Col_DrCr) = "C"
                r(Col_AmountTrxCur) = Me.txtCredit.Text
                r(Col_AllocBalanceTC) = Me.txtCredit.Text
                r(Col_AmountLocCur) = Utils.RoundMe2(CDbl(Me.txtCredit.Text) * Rate, 2)
                r(Col_AllocBalanceLC) = Utils.RoundMe2(CDbl(Me.txtCredit.Text * Rate), 2)
            End If

            r(Col_CurAlphaCode) = Me.ComboCurency.Text ' CType(Me.ComboCurency.SelectedItem, cCurrency).AlphaCode
            r(Col_TrxCurDecimal) = 0 'Not Used

            'Analysis


            '1
            If ComboAnl1.Enabled Then
                r(Col_AcLAn1Code) = ComboAnl1.Text
            Else
                r(Col_AcLAn1Code) = "$"
            End If
            '2
            If ComboAnl2.Enabled Then
                r(Col_AcLAn2Code) = ComboAnl2.Text
            Else
                r(Col_AcLAn2Code) = "$"
            End If
            '3
            If ComboAnl3.Enabled Then
                r(Col_AcLAn3Code) = ComboAnl3.Text
            Else
                r(Col_AcLAn3Code) = "$"
            End If
            '4
            If ComboAnl4.Enabled Then
                r(Col_AcLAn4Code) = ComboAnl4.Text
            Else
                r(Col_AcLAn4Code) = "$"
            End If
            '5
            If ComboAnl5.Enabled Then
                r(Col_AcLAn5Code) = ComboAnl5.Text
            Else
                r(Col_AcLAn5Code) = "$"
            End If
            '6
            If ComboAnl6.Enabled Then
                r(Col_AcLAn6Code) = ComboAnl6.Text
            Else
                r(Col_AcLAn6Code) = "$"
            End If
            '7
            If ComboAnl7.Enabled Then
                r(Col_AcLAn7Code) = ComboAnl7.Text
            Else
                r(Col_AcLAn7Code) = "$"
            End If
            '8
            If ComboAnl8.Enabled Then
                r(Col_AcLAn8Code) = ComboAnl8.Text
            Else
                r(Col_AcLAn8Code) = "$"
            End If
            '9
            If ComboAnl9.Enabled Then
                r(Col_AcLAn9Code) = ComboAnl9.Text
            Else
                r(Col_AcLAn9Code) = "$"
            End If
            '10
            If ComboAnl10.Enabled Then
                r(Col_AcLAn10Code) = ComboAnl10.Text
            Else
                r(Col_AcLAn10Code) = "$"
            End If


            r(Col_AllocStatus) = "O"
            r(Col_AllocRef) = 0


            r(Col_AllocDate) = Now.Date 'Temp
            r(Col_AllocPeriod) = CType(Me.ComboPeriods.SelectedItem, cFiscalPeriods).Code

            'Dim Col_ExternalRef As Integer = 35
            r(Col_Module) = 1 'FI
            r(Col_ModRef) = ""

            Dt1.Rows.Add(r)
            Dg1.Rows(CurrentRow).Selected = False
            Dg1.Rows(Counter - 1).Selected = True

            ' Me.Dg1.CurrentCell = Me.Dg1(0, Counte - 1)

            'Me.txtLineId.Text = Counter
            If Counter > 1 Then
                CurrentRow = CurrentRow + 1
            End If
            CalculateTotals()
            Me.txtAccountCode.Focus()
            Me.txtAccountCode.SelectAll()
        End If
    End Sub
    Private Function ValidateReverseEntry() As cFiscalPeriods
        Dim P As New cFiscalPeriods
        Dim CurMonth As String
        Dim NextPCode As String
        Dim ReturnPeriod As New cFiscalPeriods

        P = CType(Me.ComboPeriods.SelectedItem, cFiscalPeriods)
        CurMonth = P.Code
        CurMonth = CurMonth.Substring(4, 2)
        NextPCode = P.Year & (CurMonth + 1).ToString.PadLeft(2, "0")
        Dim NextP As New cFiscalPeriods(NextPCode)
        If NextP.Code <> 0 Then
            If NextP.StatusMain = "C" Then
                MsgBox("Next Fiscal Period Is Close, Please Open it in Order to Enter a Reversal Journal Entry", MsgBoxStyle.Critical)
            Else
                ReturnPeriod = New cFiscalPeriods(NextPCode)
            End If
        Else
            NextPCode = P.Year + 1 & "01"
            NextP = New cFiscalPeriods(NextPCode)
            If NextP.Code <> 0 Then
                If NextP.StatusMain = "C" Then
                    MsgBox("Next Fiscal Period Is Close, Please Open it in Order to Enter a Reversal Journal Entry", MsgBoxStyle.Critical)
                Else
                    ReturnPeriod = New cFiscalPeriods(NextPCode)
                End If
            Else
                MsgBox("There is no Next Fiscal Period, Please Create one in Order to Enter a Reversal Journal Entry", MsgBoxStyle.Critical)
            End If
        End If
        Return ReturnPeriod

    End Function
    Private Sub CalculateTotals()
        Dim i As Integer
        Dim Credit As Double = 0
        Dim Debit As Double = 0
        Dim Balance As Double = 0
        If CheckDataSet(MyDs) Then
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                If MyDs.Tables(0).Rows(i).Item(Me.Col_DrCr) = "D" Then
                    Debit = Debit + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_Debit))
                Else
                    Credit = Credit + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_Credit))
                End If
            Next
            Me.txtTotalCredit.Text = Format(Credit, "0.00")
            Me.txtTotalDebit.Text = Format(Debit, "0.00")
            If Debit > Credit Then
                Balance = Debit - Credit
                Me.txtBalanceCredit.Text = Format(Balance, "0.00")
                Me.txtBalanceDebit.Text = "0.00"
            ElseIf Debit < Credit Then
                Balance = Credit - Debit
                Me.txtBalanceDebit.Text = Format(Balance, "0.00")
                Me.txtBalanceCredit.Text = "0.00"
            ElseIf Debit = Credit Then
                Me.txtBalanceDebit.Text = "0.00"
                Me.txtBalanceCredit.Text = "0.00"
            End If
        Else
            Me.txtBalanceDebit.Text = "0.00"
            Me.txtBalanceCredit.Text = "0.00"
        End If
    End Sub
    Private Function ValidateMe() As Boolean
        Dim Flag As Boolean = True

        If Me.MSKtxtDocDate.MaskCompleted Then
            Try
                Dim D As Date
                D = Utils.ChangeMaskedFields(Me.MSKtxtDocDate)
            Catch ex As Exception
                MsgBox("Please Enter a Valid Document Date", MsgBoxStyle.Critical)
                Flag = False
            End Try
        Else
            MsgBox("Please Enter a Valid Document Date", MsgBoxStyle.Critical)
            Flag = False
        End If

        If Me.txtAccountDesc.Text = "" Then
            MsgBox("Please enter a Valid Account Code", MsgBoxStyle.Critical)
            Flag = False
        End If
        If Me.ComboPeriods.Text = "" Then
            MsgBox("Please Select/Open a Valid Period", MsgBoxStyle.Critical)
            Flag = False
        End If
        If Me.txtDebit.Text = "" Or Me.txtDebit.Text = "0.00" Then
            If Me.txtCredit.Text = "" Or Me.txtCredit.Text = "0.00" Then
                MsgBox("Please Enter Debit Or Credit Amount", MsgBoxStyle.Critical)
                Flag = False
            End If
        End If
        Return Flag
    End Function
#Region "Key Ups And UI Flow"


    Private Sub txtCredit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCredit.KeyUp
        If txtCredit.Text <> "" Then
            Me.txtDebit.Text = ""
        End If
        If e.KeyCode = Keys.Enter Then
            Me.MSKtxtDocDate.Focus()
            Me.MSKtxtDocDate.SelectAll()
        End If
    End Sub
    Private Sub txtDebit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDebit.KeyUp
        If txtDebit.Text <> "" Then
            Me.txtCredit.Text = ""
        End If
        If e.KeyCode = Keys.Enter Then
            If Me.txtDebit.Text = "" Then
                Me.txtCredit.Focus()
                Me.txtCredit.SelectAll()
            ElseIf Me.txtDebit.Text = "0.00" Then
                Me.txtCredit.Focus()
                Me.txtCredit.SelectAll()
            Else
                Me.MSKtxtDocDate.Focus()
                Me.MSKtxtDocDate.SelectAll()
            End If
        End If
    End Sub

    Private Sub MSKtxtDocDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MSKtxtDocDate.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtDocRef.Focus()
            Me.txtDocRef.SelectAll()
        End If
    End Sub
    Private Sub txtDocRef_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocRef.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtAltRef.Focus()
            Me.txtAltRef.SelectAll()
        End If
    End Sub
    Private Sub txtAltRef_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAltRef.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtComment.Focus()
            Me.txtComment.SelectAll()
        End If
    End Sub
    Private Sub ComboCurency_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboCurency.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtCurRate.Focus()
            Me.txtCurRate.SelectAll()
        End If
    End Sub

    Private Sub txtCurRate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCurRate.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtDebit.Focus()
            Me.txtDebit.SelectAll()
        End If
    End Sub
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComment.KeyUp
        If e.KeyCode = Keys.Enter Then
            ComboFocus(1)
        End If
    End Sub
    Private Sub ComboAnl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(2)
        End If
    End Sub
    Private Sub ComboAnl2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl2.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(3)
        End If
    End Sub
    Private Sub ComboAnl3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl3.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(4)
        End If
    End Sub
    Private Sub ComboAnl4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl4.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(5)
        End If
    End Sub
    Private Sub ComboAnl5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl5.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(6)
        End If
    End Sub
    Private Sub ComboAnl6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl6.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(7)
        End If
    End Sub
    Private Sub ComboAnl7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl7.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(8)
        End If
    End Sub
    Private Sub ComboAnl8_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl8.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(9)
        End If
    End Sub
    Private Sub ComboAnl9_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl9.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ComboFocus(10)
        End If
    End Sub
    Private Sub ComboAnl10_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAnl10.KeyUp
        If e.KeyCode = Keys.Enter Then
            BtnAdd.Focus()
        End If
    End Sub
    Private Sub ComboFocus(ByVal Ind As Integer)
        Select Case Ind
            Case 1
                If Me.ComboAnl1.Enabled Then
                    Me.ComboAnl1.Focus()
                Else
                    ComboFocus(2)
                End If
            Case 2
                If Me.ComboAnl2.Enabled Then
                    Me.ComboAnl2.Focus()
                Else
                    ComboFocus(3)
                End If
            Case 3
                If Me.ComboAnl3.Enabled Then
                    Me.ComboAnl3.Focus()
                Else
                    ComboFocus(4)
                End If
            Case 4
                If Me.ComboAnl4.Enabled Then
                    Me.ComboAnl4.Focus()
                Else
                    ComboFocus(5)
                End If
            Case 5
                If Me.ComboAnl5.Enabled Then
                    Me.ComboAnl5.Focus()
                Else
                    ComboFocus(6)
                End If
            Case 6
                If Me.ComboAnl6.Enabled Then
                    Me.ComboAnl6.Focus()
                Else
                    ComboFocus(7)
                End If
            Case 7
                If Me.ComboAnl7.Enabled Then
                    Me.ComboAnl7.Focus()
                Else
                    ComboFocus(8)
                End If
            Case 8
                If Me.ComboAnl8.Enabled Then
                    Me.ComboAnl8.Focus()
                Else
                    ComboFocus(9)
                End If
            Case 9
                If Me.ComboAnl9.Enabled Then
                    Me.ComboAnl9.Focus()
                Else
                    ComboFocus(10)
                End If
            Case 10
                If Me.ComboAnl10.Enabled Then
                    Me.ComboAnl10.Focus()
                Else
                    BtnAdd.Focus()
                End If

        End Select

    End Sub

#End Region
#Region "Header Buttons Clicks"
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearAll()
    End Sub
    Private Sub ClearAll()
        Me.GBDetails.Enabled = True
        Me.GBMain.Enabled = True
        ClearHeaderFields()
        ClearLineFields()
        ClearGrid()
        Me.txtAccountCode.Text = ""
        Me.txtAccountDesc.Text = ""
        Me.Er1.SetError(Me.txtAccountCode, "")
        Dim Acc As New cAccount
        FixAnalysis(Acc)
        Me.SetCombosToFirstIndex()
        LockScreen(False)
        Me.txtCreatedBy.Text = Global1.UserName
    End Sub
    Private Sub ClearGrid()
        CurrentRow = 0
        If CheckDataSet(MyDs) Then
            MyDs.Tables(0).Rows.Clear()
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        TryToSaveME()
    End Sub
    Private Sub TryToSaveME()
        If CheckDataSet(MyDs) Then
            Dim Exx As New Exception
            Dim i As Integer

            If Me.txtTotalDebit.Text <> Me.txtTotalCredit.Text Then
                MsgBox("Unbalanced Debit/Credit Amounts, Cannot Save Journal Entries", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Try
                Dim Jc As New cJournalCode
                Jc = CType(Me.ComboJournalCode.SelectedItem, cJournalCode)

                Global1.Business.BeginTransaction()

                Dim ReferenceNumber As String
                ReferenceNumber = Global1.Business.GetJournalCodeNextReferenceNo(Jc)
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Dim AcLines As New cAccountLines
                    FillAccountLinesWithData(AcLines, i, ReferenceNumber, False)
                    If Not AcLines.Save() Then
                        Throw Exx
                    End If
                Next
                If Me.GlbReversalEntry Then
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        Dim AcLines As New cAccountLines
                        FillAccountLinesWithData(AcLines, i, ReferenceNumber, True)
                        If Not AcLines.Save() Then
                            Throw Exx
                        End If
                    Next
                End If

                Global1.Business.CommitTransaction()
                MsgBox("Journal Entry is Succesfully Saved", MsgBoxStyle.Information)
                Me.txtJournalNo.Text = ReferenceNumber
                LockScreen(True)
            Catch ex As Exception
                MsgBox("Unable To save Journal Entry (Error at Line " & i + 1 & ")", MsgBoxStyle.Critical)
                Utils.ShowException(Exx)
                Global1.Business.Rollback()
            End Try
        End If

    End Sub
    Private Sub FillAccountLinesWithData(ByRef AccLine As cAccountLines, ByVal i As Integer, ByVal ReferenceNumber As Integer, ByVal Reversal As Boolean)
        With AccLine
            .Id = 0
            .JournalCode = CType(Me.ComboJournalCode.SelectedItem, cJournalCode).Code
            .JournalNumber = ReferenceNumber
            If Reversal Then
                .JournalLineNo = (MyDs.Tables(0).Rows.Count) + i + 1
            Else
                .JournalLineNo = i + 1
            End If

            .DocRef = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_DocRef))
            .AltRef = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AltRef))
            .AccountCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AccCode))
            .BusPrtCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_BusPrtCode))
            If Reversal Then
                .PeriodCode = Me.GLBReversePeriod.Code
                .AllocPeriod = Me.GLBReversePeriod.Code
                .DocDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_DocDate))
                .PostDate = Me.GLBReversePeriod.FromDate
                .DueDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_DueDate))
                .DrCr = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_DrCr))
                If .DrCr = "D" Then
                    .DrCr = "C"
                ElseIf .DrCr = "C" Then
                    .DrCr = "D"
                End If
            Else
                .PeriodCode = CType(Me.ComboPeriods.SelectedItem, cFiscalPeriods).Code
                .AllocPeriod = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AllocPeriod))
                .DocDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_DocDate))
                .PostDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_PostDate))
                .DueDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_DueDate))
                .DrCr = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_DrCr))
            End If
            .AmountLocCur = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_AmountLocCur))
            Dim Ar() As String
            Ar = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_CurAlphaCode)).Split("-")

            .CurAlphaCode = Trim(Ar(0))
            .AmountTrxCur = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_AmountTrxCur))
            .CurRate = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_CurRate))
            .TrxCurDecimal = 0 'not used

            'Loading Of Analysis

            .AcLAn1Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn1Code)))
            .AcLAn2Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn2Code)))
            .AcLAn3Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn3Code)))
            .AcLAn4Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn4Code)))
            .AcLAn5Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn5Code)))
            .AcLAn6Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn6Code)))
            .AcLAn7Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn7Code)))
            .AcLAn8Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn8Code)))
            .AcLAn9Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn9Code)))
            .AcLAn10Code = FindAnalysisCode(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AcLAn10Code)))


            '"O" Outstanding
            .AllocStatus = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_AllocStatus))
            'Empty
            .AllocRef = 0
            'local amount
            .UnAllocBalanceLC = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_AllocBalanceLC))
            'transaction Amount
            .UnAllocBalanceTC = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Col_AllocBalanceTC))
            ' doc date or Empty
            .AllocDate = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Col_AllocDate))
            ' Empty/delete


            .Comment = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_Comment))
            'Field
            .ExternalRef = DbNullToInt(MyDs.Tables(0).Rows(i).Item(Me.Col_ExternalRef))
            '1 Temp
            .MyModule = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Col_Module))
            'Empty
            .ModRef = 0 'DbNullToInt(MyDs.Tables(0).Rows(i).Item(Me.Col_ModRef))

            .CreationDate = Now.Date
            .CreatedBy = Global1.GLBUserId
            .AmendDate = Now.Date
            .AmendBy = Global1.GLBUserId
        End With

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

#End Region


    Private Sub DG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg1.Click
        If DoNotVisitNow Then Exit Sub
        Dim i As Integer
        Dg1.Rows(CurrentRow).Selected = False
        i = Dg1.CurrentRow.Index
        CurrentRow = i
        Dg1.Rows(CurrentRow).Selected = True
        LoadFromGridCellsToLineDetails()
    End Sub
    Private Sub Dg1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg1.SelectionChanged
        DG1SelectionChange()
    End Sub
    Private Sub DG1SelectionChange()
        Try
            If DoNotVisitNow Then Exit Sub
            If CheckDataSet(MyDs) Then
                Dim i As Integer
                i = Dg1.CurrentRow.Index
                If i <> CurrentRow Then
                    CurrentRow = i
                    LoadFromGridCellsToLineDetails()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadFromGridCellsToLineDetails()
        If CheckDataSet(MyDs) Then
            If CurrentRow <= MyDs.Tables(0).Rows.Count - 1 Then
                With MyDs.Tables(0).Rows(CurrentRow)
                    Me.txtAccountCode.Text = DbNullToString(.Item(Col_AccCode))
                    Me.txtAccountDesc.Text = DbNullToString(.Item(Col_AccDesc))

                    If DbNullToString(.Item(Col_Debit)) = "" Then
                        Me.txtDebit.Text = ""
                    Else
                        Me.txtDebit.Text = Format(DbNullToDouble(.Item(Col_Debit)), "0.00")
                    End If

                    If DbNullToString(.Item(Col_Credit)) = "" Then
                        Me.txtCredit.Text = ""
                    Else
                        Me.txtCredit.Text = Format(DbNullToDouble(.Item(Col_Credit)), "0.00")
                    End If



                    Me.txtDocRef.Text = DbNullToString(.Item(Col_DocRef))
                    Me.txtAltRef.Text = DbNullToString(.Item(Col_AltRef))
                    Me.txtComment.Text = DbNullToString(.Item(Col_Comment))


                    Me.txtCurRate.Text = Format(DbNullToDouble(.Item(Col_CurRate)), "0.00")
                    Me.ComboCurency.SelectedIndex = Me.ComboCurency.FindStringExact(DbNullToString(.Item(Me.Col_CurAlphaCode)))
                    Dim S As String

                    S = DbNullToString(.Item(Me.Col_AcLAn1Code))
                    If S = "$" Then
                        Me.ComboAnl1.SelectedIndex = 0
                        Me.ComboAnl1.Enabled = False
                    Else
                        Me.ComboAnl1.SelectedIndex = Me.ComboAnl1.FindStringExact(S)
                        Me.ComboAnl1.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn2Code))
                    If S = "$" Then
                        Me.ComboAnl2.SelectedIndex = 0
                        Me.ComboAnl2.Enabled = False
                    Else
                        Me.ComboAnl2.SelectedIndex = Me.ComboAnl2.FindStringExact(S)
                        Me.ComboAnl2.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn3Code))
                    If S = "$" Then
                        Me.ComboAnl3.SelectedIndex = 0
                        Me.ComboAnl3.Enabled = False
                    Else
                        Me.ComboAnl3.SelectedIndex = Me.ComboAnl3.FindStringExact(S)
                        Me.ComboAnl3.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn4Code))
                    If S = "$" Then
                        Me.ComboAnl4.SelectedIndex = 0
                        Me.ComboAnl4.Enabled = False
                    Else
                        Me.ComboAnl4.SelectedIndex = Me.ComboAnl4.FindStringExact(S)
                        Me.ComboAnl4.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn5Code))
                    If S = "$" Then
                        Me.ComboAnl5.SelectedIndex = 0
                        Me.ComboAnl5.Enabled = False
                    Else
                        Me.ComboAnl5.SelectedIndex = Me.ComboAnl5.FindStringExact(S)
                        Me.ComboAnl5.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn6Code))
                    If S = "$" Then
                        Me.ComboAnl6.SelectedIndex = 0
                        Me.ComboAnl6.Enabled = False
                    Else
                        Me.ComboAnl6.SelectedIndex = Me.ComboAnl6.FindStringExact(S)
                        Me.ComboAnl6.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn7Code))
                    If S = "$" Then
                        Me.ComboAnl7.SelectedIndex = 0
                        Me.ComboAnl7.Enabled = False
                    Else
                        Me.ComboAnl7.SelectedIndex = Me.ComboAnl7.FindStringExact(S)
                        Me.ComboAnl7.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn8Code))
                    If S = "$" Then
                        Me.ComboAnl8.SelectedIndex = 0
                        Me.ComboAnl8.Enabled = False
                    Else
                        Me.ComboAnl8.SelectedIndex = Me.ComboAnl8.FindStringExact(S)
                        Me.ComboAnl8.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn9Code))
                    If S = "$" Then
                        Me.ComboAnl9.SelectedIndex = 0
                        Me.ComboAnl9.Enabled = False
                    Else
                        Me.ComboAnl9.SelectedIndex = Me.ComboAnl9.FindStringExact(S)
                        Me.ComboAnl9.Enabled = True
                    End If

                    S = DbNullToString(.Item(Me.Col_AcLAn10Code))
                    If S = "$" Then
                        Me.ComboAnl10.SelectedIndex = 0
                        Me.ComboAnl10.Enabled = False
                    Else
                        Me.ComboAnl10.SelectedIndex = Me.ComboAnl10.FindStringExact(S)
                        Me.ComboAnl10.Enabled = True
                    End If

                End With
            End If
        Else
            Me.ClearLineFields()
        End If

    End Sub

    Private Sub ComboCurency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCurency.SelectedIndexChanged
        Me.FindCurrencyRate()
    End Sub
    Private Sub FindCurrencyRate()
        If Me.ComboCurency.Text <> "" Then
            Dim C As New cAdMsCurrency
            C = CType(Me.ComboCurency.SelectedItem, cAdMsCurrency)
            Dim Rate As Double
            Rate = Global1.Business.GetCurruncyRate(C.AlphaCode, Now.Date)
            Me.txtCurRate.Text = Format(Rate, "0.000000")
        End If
    End Sub

   
End Class