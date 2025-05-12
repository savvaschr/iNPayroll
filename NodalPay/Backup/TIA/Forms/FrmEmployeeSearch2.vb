Public Class FrmEmployeeSearch2
    Public CalledBy As Integer
    Public RowIndex As Integer
    Public TempGroupCode As String
    Public CurrentPeriod As cPrMsPeriodCodes
    Public Mystatus As String

    Public GLBFromDate As Date
    Public GLBToDate As Date

    Public GLBAutoLoad As Boolean = False

    Dim Ds As DataSet



    Private Sub LoadComboSelectAnal()
        With Me.ComboSelectAnalysis
            .BeginUpdate()
            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("3")
            .Items.Add("4")
            .Items.Add("5")
            .EndUpdate()
            .SelectedIndex = 4

        End With
        LoadAnalysis()
    End Sub
    Private Sub LoadCheckBoxValues()
        Dim Ds As DataSet
        Dim i As Integer
        Ds = Global1.Business.AG_GetAllPrSsPayrollUnits()
        If CheckDataSet(Ds) Then
            Dim tPrSsPayrollUnits As New cPrSsPayrollUnits
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                tPrSsPayrollUnits = New cPrSsPayrollUnits(DbNullToString(Ds.Tables(0).Rows(i).Item(0)))
                If i = 0 Then
                    Me.CB1.Text = tPrSsPayrollUnits.DescriptionL
                    Me.CB1.Tag = tPrSsPayrollUnits.Code
                ElseIf i = 1 Then
                    Me.CB2.Text = tPrSsPayrollUnits.DescriptionL
                    Me.CB2.Tag = tPrSsPayrollUnits.Code
                ElseIf i = 2 Then
                    Me.CB3.Text = tPrSsPayrollUnits.DescriptionL
                    Me.CB3.Tag = tPrSsPayrollUnits.Code
                End If
            Next i
        End If
    End Sub
    Private Sub ComboSelectAnalysis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSelectAnalysis.SelectedIndexChanged
        LoadAnalysis()
    End Sub
    Private Sub LoadAnalysis()
        Dim i As Integer
        i = Me.ComboSelectAnalysis.SelectedIndex
        Select Case i
            Case 0
                LoadPrAnEmployeeAnalysis1()
            Case 1
                LoadPrAnEmployeeAnalysis2()
            Case 2
                LoadPrAnEmployeeAnalysis3()
            Case 3
                LoadPrAnEmployeeAnalysis4()
            Case 4
                LoadPrAnEmployeeAnalysis5()

        End Select


    End Sub

    Private Sub LoadPrAnEmployeeAnalysis1()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis1 As New cPrAnEmployeeAnalysis1
            With Me.ComboAnal
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis1 = New cPrAnEmployeeAnalysis1(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis1)
                Next i
                ' .ValueMember = "EmpAn1_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis2()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis2 As New cPrAnEmployeeAnalysis2
            With Me.ComboAnal
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis2 = New cPrAnEmployeeAnalysis2(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis2)
                Next i
                ' .ValueMember = "EmpAn2_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis3()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis3 As New cPrAnEmployeeAnalysis3
            With Me.ComboAnal
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis3 = New cPrAnEmployeeAnalysis3(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis3)
                Next i
                '.ValueMember = "EmpAn3_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis4()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis4 As New cPrAnEmployeeAnalysis4
            With Me.ComboAnal
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis4 = New cPrAnEmployeeAnalysis4(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis4)
                Next i
                '.ValueMember = "EmpAn4_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadPrAnEmployeeAnalysis5()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        If CheckDataSet(ds) Then
            Dim tPrAnEmployeeAnalysis5 As New cPrAnEmployeeAnalysis5
            With Me.ComboAnal
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnEmployeeAnalysis5 = New cPrAnEmployeeAnalysis5(ds.Tables(0).Rows(i))
                    .Items.Add(tPrAnEmployeeAnalysis5)
                Next i
                ' .ValueMember = "EmpAn5_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub

    Public Sub SetEmployeeAnalysisTo(ByVal analysis5Code As String)
        Dim Anal As New cPrAnEmployeeAnalysis5(analysis5Code)
        Me.ComboAnal.SelectedIndex = Me.ComboAnal.FindStringExact(Anal.tostring)

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchForEmployees()
    End Sub

    Public Sub SearchForEmployees()
        Dim EmployeeFrom As String = ""
        Dim EmployeeTo As String = ""
        EmployeeFrom = Me.txtFromEmployee.Text
        EmployeeTo = Me.txtToEmployee.Text


        Dim SortOrder As Integer = 0
        If Me.RadioAnalysis.Checked Then
            SortOrder = 1
        End If


        Dim Analysis As Integer
        Analysis = Me.ComboSelectAnalysis.SelectedIndex
        Analysis = Analysis + 1
        Dim AnalysisValue As String = "ALL"
        If Me.ComboAnal.SelectedItem.ToString <> "ALL" Then
            Select Case Analysis
                Case 1
                    AnalysisValue = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis1).Code
                Case 2
                    AnalysisValue = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis2).Code
                Case 3
                    AnalysisValue = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis3).Code
                Case 4
                    AnalysisValue = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis4).Code
                Case 5
                    AnalysisValue = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
            End Select
        End If

        Dim PayrollUnit1 As String = ""
        Dim PayrollUnit2 As String = ""
        Dim PayrollUnit3 As String = ""

        If Me.CB1.CheckState = CheckState.Checked Then
            PayrollUnit1 = CB1.Tag
        End If
        If Me.CB2.CheckState = CheckState.Checked Then
            PayrollUnit2 = CB2.Tag
        End If
        If Me.CB3.CheckState = CheckState.Checked Then
            PayrollUnit3 = CB3.Tag
        End If

        Ds = Global1.Business.GetAllPrMsEmployeesByTemplateGroupFORSearch(TempGroupCode, EmployeeFrom, EmployeeTo, CurrentPeriod, AnalysisValue, SortOrder, Analysis, PayrollUnit1, PayrollUnit2, PayrollUnit3)
        Me.DG1.DataSource = Ds.Tables(0)
    End Sub


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        LoadEmployees()
    End Sub
    Public Sub LoadEmployees()
        If CheckDataSet(Ds) Then
            Dim Analysis As String
            Dim AnalysisIndex As Integer = 0
            Dim AnalysisCode As String = ""

            Dim i As Integer
            Dim EmpCode As String
            Dim EmpfullName As String
            Dim TypeOfPay As String

            Analysis = Me.ComboAnal.SelectedItem.ToString
            If Me.ComboSelectAnalysis.Text = 5 Then
                AnalysisIndex = Me.ComboAnal.SelectedIndex
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
            End If

            Dim Ds2 As DataSet
            Ds2 = Global1.Business.GetEmployeesForTAforAnalysis(AnalysisCode, Mystatus)
            Dim DsLines As DataSet

            If CheckDataSet(Ds2) Then
                For i = 0 To Ds2.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(Ds2.Tables(0).Rows(i).Item(1))
                    EmpfullName = DbNullToString(Ds2.Tables(0).Rows(i).Item(2))
                    typeofpay = "1"

                    If Mystatus = TaStatus.ACTUAL Then
                        DsLines = Global1.Business.GetTaTrxnLines2(EmpCode, GLBFromDate, GLBToDate)
                    Else
                        DsLines = Global1.Business.GetTaTrxnLines(EmpCode, GLBFromDate, GLBToDate)
                    End If
                    If CheckDataSet(DsLines) Then
                        Dim R As DataRow
                        R = Ds.Tables(0).NewRow
                        R(0) = 1
                        R(1) = EmpCode
                        R(2) = EmpfullName ' & "/" & typeofpay
                        Ds.Tables(0).Rows.Add(R)
                    End If
                Next
            End If
            CType(Me.Owner, FrmTATrxnLines).LoadEmployees(False, Ds, Analysis, AnalysisIndex, AnalysisCode, TempGroupCode)
            'If Not glbautoload Then
            Me.Close()
            'End If
        End If

    End Sub

    Private Sub FrmEmployeeSearch2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If GLBAutoLoad Then
            Me.Width = 10
            Me.Height = 10
        End If
        LoadComboSelectAnal()
        LoadCheckBoxValues()
        Me.CB1.Checked = True
        Me.CB2.Checked = True
        Me.CB3.Checked = True
    End Sub
    'Private Sub LoadComboAnalysis()
    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
    '    If CheckDataSet(ds) Then
    '        Dim tPrAnEmployeeAnalysis1 As New cPrAnEmployeeAnalysis1
    '        With Me.ComboAnal
    '            .BeginUpdate()
    '            .Items.Clear()
    '            .Items.Add("ALL")
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                tPrAnEmployeeAnalysis1 = New cPrAnEmployeeAnalysis1(ds.Tables(0).Rows(i))
    '                .Items.Add(tPrAnEmployeeAnalysis1)
    '            Next i
    '            ' .ValueMember = "EmpAn1_Code"
    '            .SelectedIndex = 0
    '            .EndUpdate()
    '        End With
    '    End If

    'End Sub




End Class