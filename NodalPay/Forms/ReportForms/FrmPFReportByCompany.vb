Public Class FrmPFReportByCompany
    Public dsToShow As DataSet
    Public Period As cPrMsPeriodCodes
    Public TemGrp As cPrMsTemplateGroup
    Dim DSReport As DataSet
    Public PeriodDescription As String
    
    Private Sub FrmPFReportByCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LoadComboSelectAnal()
    End Sub
    Private Sub LoadComboSelectAnal()
        With Me.ComboSelectAnal
            .BeginUpdate()
            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("3")
            .Items.Add("4")
            .Items.Add("5")
            .EndUpdate()
            .SelectedIndex = 0

        End With
        LoadAnalysis()
    End Sub
    Private Sub LoadAnalysis()
        Dim i As Integer
        i = Me.ComboSelectAnal.SelectedIndex
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
    Private Sub ShowReport()
        Dim Analysis As Integer
        Analysis = Me.ComboSelectAnal.SelectedIndex
        Analysis = Analysis + 1
        Dim AnalysisValue As String = ""
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


        DSReport = Global1.Business.GetAllPrTxHeader_PFReportByanalysis(TemGrp, Period, Analysis, AnalysisValue, PeriodDescription)
        Me.DG1.DataSource = DsReport.Tables(0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ShowReport()
    End Sub
    Private Sub ComboSelectAnal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSelectAnal.SelectedIndexChanged
        Me.LoadAnalysis()
    End Sub

    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        HeaderStr.Add("Analysis")
        HeaderStr.Add("Emp Code")
        HeaderStr.Add("Name")
        HeaderStr.Add("Surname")
        HeaderStr.Add("PF A Value")
        HeaderStr.Add("PF B Value")
        HeaderStr.Add("Total")
      
        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(15)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
      


        Loader.LoadIntoExcel(DSReport, HeaderStr, HeaderSize)

    End Sub
End Class