Imports System
Imports System.Text
Imports Microsoft.Office.Interop.Excel
Imports System.Data

Imports System.Xml
'Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmIR63A
    Dim GLBIRExcelDestination As String = ""
    Dim GetEmailCredentials As Boolean = True
    Dim MyDs5 As DataSet
    Dim dt5 As System.Data.DataTable

    Dim MyDsxl As DataSet
    Dim dtxl As System.Data.DataTable


    Public GLB_Name_OnIR63 As String
    Public GLB_Designation_OnIR63 As String
    Public GLB_Printdate_OnIR63 As String

    Public SelectedEmployeesDS As DataSet
    Dim Loading As Boolean = False
    Public GLB_XMLDestinationFile As String = ""
    Dim GLB_XMLOriginFile As String = ""
    Dim PerGroup As cPrMsPeriodGroups
    Dim TemGrp As cPrMsTemplateGroup
    Dim IR7FileDir As String = ""
    Dim InitFile As Boolean = False
    Public TaxGiven As Double = 0
    Public Original As Integer = 1

    Dim Ir7Filename As String = "IR7textFile.txt"
    'Dim GLBCurrentPeriod As cPrMsPeriodCodes
    Dim DsPeriodGroups As DataSet

    '''IR7 2024 Totals Variables
    Dim MT_TotalGrossEmoluments As Double = 0
    Dim MT_ContributionsPensionableBenefits As Double = 0
    Dim MT_SpecialContributionPublic As Double = 0
    Dim MT_SpecialContributionPrivate As Double = 0
    Dim MT_ReductionOfEmolumentsandPensions As Double = 0
    Dim MT_TaxWithheld As Double = 0
    Dim MT_TaxWithheldPriorYearBonus As Double = 0
    Dim MT_FinancialBenefitDeduction As Double = 0
    Dim MT_TotalPensionableBenefitsContribution As Double = 0
    Dim MT_TotalGhsEmployersContribution = 0
    Dim MT_TotalGhsEmployeesContribution As Double = 0
    Dim MT_GHSWithHeldEmployee As Double = 0
    Dim MT_GHSWithHeldPensioners As Double = 0
    Dim MT_GHSWithHeldOfficers As Double = 0
    Dim MT_GHSEmployersContribution As Double = 0
    Dim GLBExportfilesDir As String = ""

    Private Sub FrmIR63A_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If GLBUserCode = "sa" Then
            Me.btnShowXML.Visible = True
        End If
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton2.Enabled = False
        Me.RadioButton3.Enabled = False
        Me.RadioButton4.Enabled = False

        LoadCombos()
        Dim ds As DataSet
        ds = Global1.Business.GetParameter("IR7", "ExportFileDir")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            IR7FileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing IR7 File Parameter Section 'IR7' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Me.TSBCreateIR7File.Enabled = False
        End If

        Dim Ds2 As DataSet
        Ds2 = Global1.Business.GetParameter("IR7", "Discounts")
        If CheckDataSet(Ds2) Then
            Dim Par As New cPrSsParameters(Ds2.Tables(0).Rows(0))
            Global1.GLB_IR7Discounts = Par.Value1
        End If

        Dim Ds3 As DataSet
        Ds3 = Global1.Business.GetParameter("IR63", "OtherDesc")
        If CheckDataSet(Ds3) Then
            Dim Par As New cPrSsParameters(Ds3.Tables(0).Rows(0))
            Global1.GLB_IR63Description = Par.Value1
        End If

        Dim Ds4 As DataSet
        Ds4 = Global1.Business.GetParameter("IR63", "ShowBonusSep")
        If CheckDataSet(Ds4) Then
            Dim Par As New cPrSsParameters(Ds4.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowBonusSeparatly = True
            Else
                Global1.PARAM_IR63_ShowBonusSeparatly = False
            End If
        End If

        If Global1.PARAM_IR63_ShowBonusSeparatly Then
            Dim Ds5 As DataSet
            Ds5 = Global1.Business.GetParameter("IR63", "BonusErnCode")
            If CheckDataSet(Ds5) Then
                Dim Par As New cPrSsParameters(Ds5.Tables(0).Rows(0))
                Global1.PARAM_IR63_BonusEarningCode = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'BonusErnCode'", MsgBoxStyle.Critical)
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim DsSep As DataSet
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep1")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep1 = True
            Else
                Global1.PARAM_IR63_ShowSep1 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep1 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode1")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep1Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode1'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc1")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep1Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc1'", MsgBoxStyle.Critical)
            End If

        End If
        '''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep2")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep2 = True
            Else
                Global1.PARAM_IR63_ShowSep2 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep2 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode2")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep2Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode2'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc2")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep2Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc2'", MsgBoxStyle.Critical)
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep3")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep3 = True
            Else
                Global1.PARAM_IR63_ShowSep3 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep3 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode3")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep3Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode3'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc3")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep3Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc3'", MsgBoxStyle.Critical)
            End If

        End If

        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep4")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep4 = True
            Else
                Global1.PARAM_IR63_ShowSep4 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep4 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode4")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep4Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode4'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc4")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep4Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc4'", MsgBoxStyle.Critical)
            End If

        End If

        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep5")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep5 = True
            Else
                Global1.PARAM_IR63_ShowSep5 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep5 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode5")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep5Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode5'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc5")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep5Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc5'", MsgBoxStyle.Critical)
            End If

        End If
        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep6")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep6 = True
            Else
                Global1.PARAM_IR63_ShowSep6 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep6 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode6")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep6Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode6'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc6")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep6Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc6'", MsgBoxStyle.Critical)
            End If

        End If

        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep7")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep7 = True
            Else
                Global1.PARAM_IR63_ShowSep7 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep7 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode5")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep5Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode5'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc5")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep5Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc5'", MsgBoxStyle.Critical)
            End If

        End If
        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep8")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep8 = True
            Else
                Global1.PARAM_IR63_ShowSep8 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep8 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode8")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep8Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode8'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc8")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep8Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc8'", MsgBoxStyle.Critical)
            End If

        End If
        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep9")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep9 = True
            Else
                Global1.PARAM_IR63_ShowSep9 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep9 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode9")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep9Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode9'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc9")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep9Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc9'", MsgBoxStyle.Critical)
            End If

        End If
        ''''''''''''''''''''''''''''''
        DsSep = Global1.Business.GetParameter("IR63", "ShowSep10")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_IR63_ShowSep10 = True
            Else
                Global1.PARAM_IR63_ShowSep10 = False
            End If
        End If

        If Global1.PARAM_IR63_ShowSep10 Then
            DsSep = Global1.Business.GetParameter("IR63", "SepErnCode10")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep10Code = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnCode10'", MsgBoxStyle.Critical)
            End If
            DsSep = Global1.Business.GetParameter("IR63", "SepErnDesc10")
            If CheckDataSet(DsSep) Then
                Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
                Global1.PARAM_IR63_Sep10Desc = Par.Value1
            Else
                MsgBox("Please Define Parameter 'IR63', 'SepErnDesc10'", MsgBoxStyle.Critical)
            End If

        End If

        PARAM_AddOtherContributionsOnIR7Gross = False
        Dim DsOC As DataSet
        DsOC = Global1.Business.GetParameter("IR7", "AddOtherCon")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_AddOtherContributionsOnIR7Gross = True
            End If
        End If

        PARAM_HideEmpWithBlanksSIR = True
        Dim DsHB As DataSet
        DsHB = Global1.Business.GetParameter("IR7", "HideBlankSIR")
        If CheckDataSet(DsSep) Then
            Dim Par As New cPrSsParameters(DsSep.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_HideEmpWithBlanksSIR = True
            Else
                Global1.PARAM_HideEmpWithBlanksSIR = False
            End If
        End If

        PARAM_PublicSector = "No"
        Dim DsPS As DataSet
        DsPS = Global1.Business.GetParameter("IR63", "PublicSector")
        If CheckDataSet(DsPS) Then
            Dim Par As New cPrSsParameters(DsPS.Tables(0).Rows(0))
            PARAM_PublicSector = Par.Value1
        End If


        Dim Dsx As DataSet
        Dsx = Global1.Business.GetParameter("SIContributions", "ExportFileDir")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            GLBExportfilesDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing SI COntributions File Parameter Section 'SIContributions' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            GLBExportfilesDir = ""
        End If



        InitDataGrid()
        InitDataGrid_Excel()



    End Sub
    Private Sub InitDataGrid()
        InitDataTable()
        MyDs5 = New DataSet
        MyDs5.Tables.Add(dt5)

        'DG1.DataSource = MyDs1.Tables(0)
    End Sub
    Private Sub InitDataGrid_Excel()
        InitDataTable_Excel()
        MyDsxl = New DataSet
        MyDsxl.Tables.Add(dtxl)

        'DG1.DataSource = MyDs1.Tables(0)
    End Sub
    Private Sub LoadCombos()
        LoadPeriodGroup()
        Dim i As Integer
        Dim Found As Boolean = False
        For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
            If CType(Me.cmbPeriodGroups.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year Then
                Found = True
                Me.cmbPeriodGroups.SelectedIndex = i
                Exit For
            End If
        Next
        If Not Found Then
            For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
                If CType(Me.cmbPeriodGroups.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year - 1 Then

                    Me.cmbPeriodGroups.SelectedIndex = i
                    Exit For
                End If
            Next

        End If
    End Sub
    Private Sub LoadPeriodGroup()
        Loading = True

        Dim i As Integer
        Dim ShowALLYears As Boolean = False
        If CBShowAllYears.CheckState = CheckState.Checked Then
            ShowAllYears = True
        Else
            ShowAllYears = False
        End If

        DsPeriodGroups = Global1.Business.GetAllPrMsPeriodGroupsOfUser(Global1.UserName, ShowALLYears, Global1.GLBCurrentYear)
        With Me.cmbPeriodGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(DsPeriodGroups) Then
                For i = 0 To DsPeriodGroups.Tables(0).Rows.Count - 1
                    Dim PG As New cPrMsPeriodGroups(DsPeriodGroups.Tables(0).Rows(i))
                    .Items.Add(PG)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False
    End Sub
    Private Sub CmbPeriodGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPeriodGroups.SelectedIndexChanged
        Try
            PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            TemGrp = New cPrMsTemplateGroup(PerGroup.TemGrpCode)
            Me.TextBox1.Text = TemGrp.Code & " - " & TemGrp.DescriptionL
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub IR63A(ByVal SendToPrinter As Boolean, ByVal ExportInPDF As Boolean, ByVal Report As String, ByVal ShowSeparateJanAndFeb As Boolean, ByVal Show2020 As Boolean)
        Me.GetEmailCredentials = True
        Global1.PARAM_IR63_Report = Report
        Dim UseEncryption As Boolean = False
        If Me.CheckBox1.CheckState = CheckState.Checked Then
            Dim Ans As MsgBoxResult
            Ans = MsgBox("Send Emails using Employee Password if exist?", MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                UseEncryption = True
            End If

        End If

        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet
        Dim Exportdirectory As String = ""
        Dim OrderByAnalysis2 As Boolean = False

        Dim ds1 As DataSet
        ds1 = Global1.Business.GetParameter("Payslips", "ExportFileDir")
        If CheckDataSet(ds1) Then
            Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
            Exportdirectory = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            Exportdirectory = "C:\"
        End If

        'ds1 = Global1.Business.GetParameter("IR63", "Report")
        'If CheckDataSet(ds1) Then
        '    Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
        '    Global1.PARAM_IR63_Report = Par.Value1
        'Else
        '    Global1.PARAM_IR63_Report = "IR63A2012.rpt"
        'End If



        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)



        Dim F As New frmIr63NameAndDesignation
        F.PrdGrp = PerGrp
        F.Owner = Me
        F.ShowDialog()


        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        D = DateAdd(DateInterval.Year, 1, D)
        Dim dsIR7 As DataSet

        dsIR7 = Global1.Business.REPORT_IR7_2(PerGrp, "", "", D, False)
        If Me.CBActiveWithTermDate.CheckState = CheckState.Checked Then
            SelectedEmployeesDS = Global1.Business.SearchForEmployeesWithTermDateOfThisPeriod(TempGrpCode)
        End If
        If Me.CBOnlyActiveEmployees.CheckState = CheckState.Checked Then
            SelectedEmployeesDS = Global1.Business.SearchForOnlyActiveEmployees(TempGrpCode)
        End If

        If CBOrderByAnalysis2.CheckState = CheckState.Checked Then
            OrderByAnalysis2 = True
        End If


        dsEmp = Global1.Business.GetAllEmployeesOfCodeOfTemplateGroupForYear(FromCode, ToCode, TempGrpCode, D, OrderByAnalysis2)
        Dim TemGroup As New cPrMsTemplateGroup(TempGrpCode)
        Dim Comp As New cAdMsCompany(TemGroup.CompanyCode)
        Dim CompanyDescription As String = Comp.Name
        If CheckDataSet(dsEmp) Then
            Dim Show As Boolean = True
            Dim ShowThisEmployee As Boolean = False
            For i = 0 To dsEmp.Tables(0).Rows.Count - 1
                Show = True
                EmpCode = DbNullToString(dsEmp.Tables(0).Rows(i).Item(0))

                If CheckDataSet(SelectedEmployeesDS) Then
                    ShowThisEmployee = False
                    Dim k As Integer
                    For k = 0 To SelectedEmployeesDS.Tables(0).Rows.Count - 1
                        If EmpCode = DbNullToString(SelectedEmployeesDS.Tables(0).Rows(k).Item(1)) Then
                            If DbNullToString(SelectedEmployeesDS.Tables(0).Rows(k).Item(0)) = "1" Then
                                ShowThisEmployee = True
                                Exit For
                            End If
                        End If
                    Next
                Else
                    If Me.CBActiveWithTermDate.CheckState = CheckState.Checked Then
                        ShowThisEmployee = False
                    Else
                        ShowThisEmployee = True
                    End If

                End If

                Dim FoundThisEmployee As Boolean = False
                If CheckDataSet(dsIR7) Then
                    Dim k As Integer
                    For k = 0 To dsIR7.Tables(0).Rows.Count - 1
                        If dsIR7.Tables(0).Rows(k).Item(27) = EmpCode Then
                            FoundThisEmployee = True
                        End If
                    Next
                End If
                If Not FoundThisEmployee Then
                    ShowThisEmployee = False
                End If

                If ShowThisEmployee Then


                    If ShowSeparateJanAndFeb Then

                        Ds = Global1.Business.REPORT_IR63A_2019(PerGrp, EmpCode, dsIR7, GLB_Name_OnIR63, GLB_Designation_OnIR63, GLB_Printdate_OnIR63)
                    ElseIf Show2020 Then
                        Dim March As Boolean = False
                        Dim Period14 As Boolean = False
                        If Me.CBIr63.Checked Then
                            March = True
                        End If
                        If Me.CB14Period.Checked Then
                            Period14 = True
                        End If

                        Ds = Global1.Business.REPORT_IR63A_2020(PerGrp, EmpCode, dsIR7, GLB_Name_OnIR63, GLB_Designation_OnIR63, March, Period14, GLB_Printdate_OnIR63)
                    Else

                        Ds = Global1.Business.REPORT_IR63A(PerGrp, EmpCode, dsIR7, GLB_Name_OnIR63, GLB_Designation_OnIR63, GLB_Printdate_OnIR63)

                    End If

                    '  Ds = Global1.Business.REPORT_IR63A_2019(PerGrp, EmpCode, dsIR7, GLB_Name_OnIR63, GLB_Designation_OnIR63)
                    ' Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\IR63A")

                    If CheckDataSet(Ds) Then
                        Dim HasPassword As Boolean = False
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        If Trim(Emp.Password) <> "" Then
                            HasPassword = True
                        End If
                        If DbNullToDouble(Ds.Tables(1).Rows(0).Item(0)) = 0 Then

                            If Me.CBOnlyActiveEmployees.CheckState = CheckState.Checked Then
                                If Emp.Status = "I" Then
                                    Show = False
                                End If
                            End If
                        End If

                        Dim TempUseEncryption As Boolean = False
                        If Show Then
                            If ExportInPDF Then
                                Dim Filename As String
                                Dim FileName2 As String
                                If UseEncryption And HasPassword Then
                                    TempUseEncryption = True
                                End If
                                If TempUseEncryption Then
                                    Filename = Exportdirectory & EmpCode & "_IR63_t" & ".pdf"
                                    FileName2 = Exportdirectory & EmpCode & "_IR63" & ".pdf"
                                Else
                                    Filename = Exportdirectory & EmpCode & "_IR63" & ".pdf"
                                End If

                                Utils.ShowReport(Global1.PARAM_IR63_Report, Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 63A", False, "", False, True, Filename, False, 0)
                                If Me.CheckBox1.CheckState = CheckState.Checked Then

                                    'Dim Emp As New cPrMsEmployees(EmpCode)
                                    If TempUseEncryption Then
                                        Utils.EncryptPdf(Filename, FileName2, Emp.Password)
                                        System.IO.File.Delete(Filename)
                                        Filename = FileName2
                                    End If

                                    SendIR63WithEmailToemployee(Emp, Filename, Y, CompanyDescription)
                                End If
                            Else
                                Utils.ShowReport(Global1.PARAM_IR63_Report, Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 63A", SendToPrinter)
                            End If

                        End If
                    Else
                        MsgBox("No records found For Employee Code" & EmpCode, MsgBoxStyle.Information)
                    End If
                End If
            Next
        End If
        MsgBox("IR63 Creation procedure Finish ", MsgBoxStyle.Information)
        Me.Cursor = Cursors.Default
        Me.GetEmailCredentials = True
    End Sub
    Private Sub SendIR63WithEmailToemployee(ByVal Emp As cPrMsEmployees, ByVal FileName As String, ByVal Ir63Year As String, ByVal CompanyDescription As String)




        Dim EmailType As Integer

        If Me.RadioButton1.Checked = True Then
            EmailType = 1
        End If
        If Me.RadioButton2.Checked = True Then
            EmailType = 2
        End If
        If Me.RadioButton3.Checked = True Then
            EmailType = 3
        End If
        If Me.RadioButton4.Checked = True Then
            EmailType = 4
        End If

        Select Case EmailType

            Case 1
                EmailFile(FileName, Emp, Ir63Year, CompanyDescription)
            Case 2
                If GetEmailCredentials Then
                    Dim F As New FrmGmail
                    F.ShowDialog()
                    GetEmailCredentials = False
                End If
                GEmailFile(FileName, Emp, Ir63Year, CompanyDescription)
            Case 3
                Dim F As New FrmGmail
                If GetEmailCredentials Then
                    F.ShowDialog()
                    GetEmailCredentials = False
                End If
                Me.Send365Email(FileName, Emp, Ir63Year, CompanyDescription)

            Case 4
                If GetEmailCredentials Then
                    Dim F As New FrmGmail
                    F.ShowDialog()
                    GetEmailCredentials = False
                End If
                Me.Send_SMTP_EmailFile(FileName, Emp, Global1.PARAM_SMTPEmailHost, Ir63Year, CompanyDescription)
        End Select
        Try

            System.IO.File.Delete(FileName)

        Catch ex As Exception

        End Try


    End Sub
    Private Sub EmailFile(ByVal FileName As String, ByVal Employee As cPrMsEmployees, ByVal ir63year As String, ByVal CompanyDescription As String)
        Dim EmployeeEmail As String
        If CBUseEmail2.CheckState = CheckState.Checked Then
            EmployeeEmail = Employee.Email2
        Else
            EmployeeEmail = Employee.Email
        End If
        Dim EmailSubject As String
        Dim Msg As String
        EmailSubject = CompanyDescription & " IR63 - " & ir63year
        Msg = "Dear " & Employee.FullName & " Find attached IR63 for " & ir63year
        If EmployeeEmail <> "" Then
            Email.SendEmail(EmployeeEmail, EmailSubject, Msg, FileName, "IR63", "", Now, False)
        Else
            MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub GEmailFile(ByVal FileName As String, ByVal Employee As cPrMsEmployees, ByVal Ir63Year As String, ByVal CompanyDescription As String)
        Dim EmployeeEmail As String
        If CBUseEmail2.CheckState = CheckState.Checked Then
            EmployeeEmail = Employee.Email2
        Else
            EmployeeEmail = Employee.Email
        End If
        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = CompanyDescription & " IR63 - " & Ir63Year
            Msg = "Dear " & Employee.FullName & " Find attached IR63  for " & Ir63Year

            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword)
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.EnableSsl = True

            Dim mail As New System.Net.Mail.MailMessage()

            Try
                mail.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "", System.Text.Encoding.UTF8)



                mail.To.Add(EmployeeEmail)
                'If Param_PayslipCC <> "" Then
                ' mail.CC.Add(Global1.Param_PayslipCC)
                ' End If

                mail.Subject = EmailSubject
                mail.Body = Msg
                Dim i As Integer

                mail.Attachments.Add(New System.Net.Mail.Attachment(FileName))


                SmtpServer.Send(mail)
                mail.Dispose()
                GC.Collect()
            Catch ex As Exception
                mail.Dispose()
                GC.Collect()
                MsgBox(ex.ToString())
            End Try

        Else
            MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Public Sub Send365Email(ByVal FileName As String, ByVal Employee As cPrMsEmployees, ByVal Ir63Year As String, ByVal CompanyDescription As String)
        Try

            Dim EmployeeEmail As String
            If CBUseEmail2.CheckState = CheckState.Checked Then
                EmployeeEmail = Employee.Email2
            Else
                EmployeeEmail = Employee.Email
            End If

            If EmployeeEmail <> "" Then
                Dim EmailSubject As String
                Dim Msg As String
                EmailSubject = CompanyDescription & " IR63 - " & Ir63Year
                Msg = "Dear " & Employee.FullName & " Find attached IR63 for " & Ir63Year

                Dim mailClient As New System.Net.Mail.SmtpClient("smtp.office365.com")



                mailClient.Port = Global1.PARAM_SMTPPort
                mailClient.EnableSsl = Global1.PARAM_SMTPSSLEnabled




                'Dim cred As New System.Net.NetworkCredential("payroll@cobalt.aero", "cobalt123.")
                Dim cred As New System.Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword)

                mailClient.Credentials = cred

                Dim message As New System.Net.Mail.MailMessage()


                'This DOES work  
                message.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "IR63")

                message.[To].Add(EmployeeEmail)
                message.Subject = EmailSubject
                message.Body = Msg
                Dim i As Integer

                message.Attachments.Add(New System.Net.Mail.Attachment(FileName))


                mailClient.Send(message)
            Else
                MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            Throw ex
        End Try
        GC.Collect()
    End Sub

    Private Sub Send_SMTP_EmailFile(ByVal FileName As String, ByVal Employee As cPrMsEmployees, ByVal Host As String, ByVal Ir63Year As String, ByVal CompanyDescription As String)
        Dim EmployeeEmail As String
        If CBUseEmail2.CheckState = CheckState.Checked Then
            EmployeeEmail = Employee.Email2
        Else
            EmployeeEmail = Employee.Email
        End If

        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = CompanyDescription & " IR63 - " & Ir63Year
            Msg = "Dear " & Employee.FullName & " Find attached IR63 for " & Ir63Year

            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential(Global1.PARAM_SMTPUser, Global1.GmailPassword)

            SmtpServer.Port = Global1.PARAM_SMTPPort
            SmtpServer.Host = Host
            SmtpServer.EnableSsl = Global1.PARAM_SMTPSSLEnabled

            Dim mail As New System.Net.Mail.MailMessage()

            Try
                mail.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "", System.Text.Encoding.UTF8)



                mail.To.Add(EmployeeEmail)

                mail.Subject = EmailSubject
                mail.Body = Msg


                mail.Attachments.Add(New System.Net.Mail.Attachment(FileName))


                SmtpServer.Send(mail)
                mail.Dispose()
                GC.Collect()
            Catch ex As Exception
                mail.Dispose()
                GC.Collect()
                MsgBox(ex.ToString())
            End Try

        Else
            MsgBox("Please Define Email Address for Employee " & Employee.Code & " - " & Employee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    'Private Sub IR63A_2019(ByVal SendToPrinter As Boolean, ByVal ExportInPDF As Boolean)



    '    Me.Cursor = Cursors.WaitCursor
    '    Dim i As Integer
    '    Dim PerGrp As New cPrMsPeriodGroups
    '    Dim dsEmp As DataSet
    '    Dim FromCode As String
    '    Dim ToCode As String
    '    Dim TempGrpCode As String
    '    Dim EmpCode As String
    '    Dim Ds As DataSet
    '    Dim Exportdirectory As String = ""


    '    Dim ds1 As DataSet
    '    ds1 = Global1.Business.GetParameter("Payslips", "ExportFileDir")
    '    If CheckDataSet(ds1) Then
    '        Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
    '        Exportdirectory = Par.Value1
    '    Else
    '        Exportdirectory = "C:\"
    '    End If

    '    ds1 = Global1.Business.GetParameter("IR63", "Report")
    '    If CheckDataSet(ds1) Then
    '        Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
    '        Global1.PARAM_IR63_Report = Par.Value1
    '    Else
    '        Global1.PARAM_IR63_Report = "IR63A_2019.rpt"
    '    End If



    '    PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)



    '    Dim F As New frmIr63NameAndDesignation
    '    F.PrdGrp = PerGrp
    '    F.Owner = Me
    '    F.ShowDialog()


    '    FromCode = Me.txtFromEmployee.Text
    '    ToCode = Me.txtToEmployee.Text
    '    TempGrpCode = PerGrp.TemGrpCode
    '    Dim Y As String
    '    Y = PerGrp.Year
    '    Dim D As Date = "01/01/" & Y
    '    D = DateAdd(DateInterval.Year, 1, D)
    '    Dim dsIR7 As DataSet

    '    dsIR7 = Global1.Business.REPORT_IR7_2(PerGrp, "", "", D, False)
    '    If Me.CBActiveWithTermDate.CheckState = CheckState.Checked Then
    '        SelectedEmployeesDS = Global1.Business.SearchForEmployeesWithTermDateOfThisPeriod(TempGrpCode)
    '    End If
    '    If Me.CBOnlyActiveEmployees.CheckState = CheckState.Checked Then
    '        SelectedEmployeesDS = Global1.Business.SearchForOnlyActiveEmployees(TempGrpCode)
    '    End If




    '    dsEmp = Global1.Business.GetAllEmployeesOfCodeOfTemplateGroupForYear(FromCode, ToCode, TempGrpCode, D)
    '    If CheckDataSet(dsEmp) Then
    '        Dim Show As Boolean = True
    '        Dim ShowThisEmployee As Boolean = False
    '        For i = 0 To dsEmp.Tables(0).Rows.Count - 1
    '            Show = True
    '            EmpCode = DbNullToString(dsEmp.Tables(0).Rows(i).Item(0))

    '            If CheckDataSet(SelectedEmployeesDS) Then
    '                ShowThisEmployee = False
    '                Dim k As Integer
    '                For k = 0 To SelectedEmployeesDS.Tables(0).Rows.Count - 1
    '                    If EmpCode = DbNullToString(SelectedEmployeesDS.Tables(0).Rows(k).Item(1)) Then
    '                        If DbNullToString(SelectedEmployeesDS.Tables(0).Rows(k).Item(0)) = "1" Then
    '                            ShowThisEmployee = True
    '                            Exit For
    '                        End If
    '                    End If
    '                Next
    '            Else
    '                ShowThisEmployee = True
    '            End If

    '            If ShowThisEmployee Then
    '                ' Ds = Global1.Business.REPORT_IR63A(PerGrp, EmpCode, dsIR7, GLB_Name_OnIR63, GLB_Designation_OnIR63)
    '                Ds = Global1.Business.REPORT_IR63A_2019(PerGrp, EmpCode, dsIR7, GLB_Name_OnIR63, GLB_Designation_OnIR63)
    '                ' Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR63A")

    '                If CheckDataSet(Ds) Then
    '                    If DbNullToDouble(Ds.Tables(1).Rows(0).Item(0)) = 0 Then
    '                        Dim Emp As New cPrMsEmployees(EmpCode)
    '                        If Emp.Status = "I" Then
    '                            Show = False
    '                        End If
    '                    End If
    '                    If Show Then
    '                        If ExportInPDF Then
    '                            Dim Filename As String
    '                            Filename = Exportdirectory & EmpCode & "_IR63" & ".pdf"
    '                            Utils.ShowReport(Global1.PARAM_IR63_Report, Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 63A", False, "", False, True, Filename, False, 0)
    '                        Else
    '                            Utils.ShowReport(Global1.PARAM_IR63_Report, Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 63A", SendToPrinter)
    '                        End If

    '                    End If
    '                Else
    '                    MsgBox("No records found For Employee Code" & EmpCode, MsgBoxStyle.Information)
    '                End If
    '            End If
    '        Next
    '    End If

    '    Me.Cursor = Cursors.Default

    'End Sub
    Private Sub IR7(ByVal SendToPrinter As Boolean, ByVal File As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet


        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        'D = DateAdd(DateInterval.Year, 1, D)

        Ds = Global1.Business.REPORT_IR7_3(PerGrp, FromCode, ToCode, D)
        '----Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                'Utils.ShowReport("IR7.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
                'Utils.ShowReport("IR72012.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
                Utils.ShowReport("IR7_2017.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then
                If CreateIR7File(Ds) Then
                    MsgBox("File is Created - " & IR7FileDir & "\" & "IPA03ETD.DAT", MsgBoxStyle.Information)
                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub
    Private Function CreateIR7File(ByVal Ds As DataSet) As Boolean

        Dim Flag As Boolean = True
        Try


            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26

            Dim C_EmpCode As Integer = 27
            Dim C_STDeduction As Integer = 28
            Dim C_STContribution As Integer = 29
            Dim C_salaryPeriods As Integer = 30
            Dim C_LifeInsurance As Integer = 31

            Dim C_AllowancesBenefits As Integer = 32
            Dim C_TaxableFromOther As Integer = 33
            Dim C_NonTaxableIncome As Integer = 34

            Dim C_SyntaksiodotikaOfelimata As Integer = 35
            Dim C_MeiwsiApolavon As Integer = 36
            Dim C_WidowAndOrphans As Integer = 37
            Dim C_Pensionfund As Integer = 38

            ''#2019
            'Dim C_BIK_withSI As Integer = 39
            'Dim C_BIK_withoutSI As Integer = 40
            ''Include them in Total epr7m3t0r4c1
            ''end of #2019
            'Dim C_GESYtoSI As Integer = 41
            'Dim C_GESYtoBIKDed As Integer = 42
            'Dim C_GESYtoBIKCon As Integer = 43

          

            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0

            'Dim TOTAL_BIKWithSI As Double = 0
            'Dim TOTAL_BIKWithoutSI As Double = 0
            'Dim TOTAL_GESYtoSI As Double = 0
            'Dim TOTAL_GESYDed As Double = 0
            'Dim TOTAL_GESYCon As Double = 0

            'Dim TOTAL_MeiwsiApolavonkaiSyntakswon As Double = 0
            'Dim TOTAL_SyntaksiodotikaOfelimata As Double = 0
            'Dim TOTAL_WidowAndOrphans As Double = 0
            'Dim TOTAL_PensionFund As Double = 0




            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + .Item(C_Local)
                        TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
                        TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
                        TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
                        TOTAL_SI = TOTAL_SI + .Item(C_SI)
                        TOTAL_PF = TOTAL_PF + .Item(C_PF)
                        TOTAL_MF = TOTAL_MF + .Item(C_MF)
                        TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
                        TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
                        TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
                        TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
                        TOTAL_IT = TOTAL_IT + .Item(C_IT)

                        'TOTAL_BIKWithSI = TOTAL_BIKWithSI + .Item(C_BIK_withSI)
                        'TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + .Item(C_BIK_withoutSI)
                        'TOTAL_GESYtoSI = TOTAL_GESYtoSI + .Item(C_GESYtoSI)
                        'TOTAL_GESYDed = TOTAL_GESYDed + .Item(C_GESYtoBIKDed)
                        'TOTAL_GESYCon = TOTAL_GESYCon + .Item(C_GESYtoBIKCon)

                        'TOTAL_SyntaksiodotikaOfelimata = TOTAL_SyntaksiodotikaOfelimata + .Item(C_SyntaksiodotikaOfelimata)
                        'TOTAL_MeiwsiApolavonkaiSyntakswon = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_MeiwsiApolavon)
                        'TOTAL_MeiwsiApolavonkaiSyntakswon = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_MeiwsiApolavon)
                        'TOTAL_WidowAndOrphans = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_WidowAndOrphans)
                        'TOTAL_PensionFund = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_Pensionfund)
                        
                    End With
                Next
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '1
                Str03 = 1
                '2
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0)
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '3
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ")

                '4
                Str03 = Str03 & " "
                '5
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ")
                '6
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ")
                '7
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ")
                '8
                Str03 = Str03 & "".PadRight(25, " ")
                '9
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ")
                '10
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ")
                '11
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ")
                '12
                Str03 = Str03 & FixInteger((i), 5)
                '13
                Str03 = Str03 & FixInteger(TOTAL_Local, 10)
                '14
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9)
                '15
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9)
                '16
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10)
                '17
                Str03 = Str03 & FixInteger(TOTAL_SI, 9)
                '18
                Str03 = Str03 & FixInteger(TOTAL_PF, 9)
                '19
                Str03 = Str03 & FixInteger(TOTAL_MF, 9)
                '20
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9)
                '21
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9)
                '22
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9)
                '23
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10)
                '24
                Str03 = Str03 & FixNumber(TOTAL_IT, 11)
                '25
                Str03 = Str03 & FixNumber(0, 11)
                '26
                Str03 = Str03 & FixNumber(0, 11)
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        "
                '28
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        "
                '29
                Str03 = Str03 & FixNumber(TaxGiven, 11)
                '30
                Str03 = Str03 & FixNumber(0, 11)
                '31
                Str03 = Str03 & FixNumber(0, 11)

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC
                End If
                TIC4 = Company.AccountantTIC
                '32
                Str03 = Str03 & TIC1.PadRight(9, " ")
                '33
                Str03 = Str03 & TIC2.PadRight(9, " ")
                '34
                Str03 = Str03 & TIC3.PadRight(9, " ")
                '35
                Str03 = Str03 & TIC4.PadRight(9, " ")
                '36
                Str03 = Str03 & Company.AccIdentity
                '37
                Str03 = Str03 & Company.TICCategory
                '38
                Str03 = Str03 & Company.TICType
                '39
                Str03 = Str03 & "0".PadLeft(7, "0")
                '40
                Str03 = Str03 & Original





                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0)
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ")
                        Else
                            Str02 = Str02 & "".PadLeft(9, " ")

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType)
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15)
                        Else
                            '4
                            Str02 = Str02 & " "
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ")
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ")


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ")
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Str02 = Str02 & FirstName.PadRight(25, " ")
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ")
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ")
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ")
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5)
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10)
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9)
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9)
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10)
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9)
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9)
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9)
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9)
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9)
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9)
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10)
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11)
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 11)
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 11)

                        '27
                        If .Item(C_StartDate) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        "
                            Else
                                Str02 = Str02 & D
                            End If
                        Else
                            Str02 = Str02 & "        "
                        End If
                        '28
                        If .Item(C_LeaveDate) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        "
                            Else
                                Str02 = Str02 & D
                            End If

                        Else
                            Str02 = Str02 & "        "
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ")
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ")
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ")
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ")
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ")
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ")
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0")
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0")


                    End With
                    Str02 = Replace(Str02, "&", " ")
                    WriteToIR7File(Str02)

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function CreateIR7File_2018(ByVal Ds As DataSet) As Boolean
        Dim index As Integer
        Dim Place As String = ""
        Dim Place2 As String = ""
        Dim Place3 As String = ""
        Dim Place4 As String = ""

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30

            Dim C_LifeInsurance As Integer = 31

            Dim C_AllowanceBenefits As Integer = 32
            Dim C_TaxableFromOther As Integer = 33
            Dim C_NonTaxable As Integer = 34
            Dim C_Syntaksiodotika As Integer = 35
            Dim C_MiwsiApolavon As Integer = 36
            Dim C_WidowOrphans As Integer = 37
            Dim C_PensionFund As Integer = 38
            '#2019
            Dim C_BIK_withSI As Integer = 39
            Dim C_BIK_withoutSI As Integer = 40
            'Include them in Total epr7m3t0r4c1
            'end of #2019
            Dim C_GESYtoSI As Integer = 41
            Dim C_GESYtoBIKDed As Integer = 42
            Dim C_GESYtoBIKCon As Integer = 43
            Dim C_EmpType As Integer = 44
            Dim C_DirectorFees As Integer = 46





            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim TOTAL_LifeInsurance As Double = 0

            Dim TOTAL_AllowanceBenefits As Double = 0
            Dim TOTAL_TaxableFromOther As Double = 0
            Dim TOTAL_NonTaxable As Double = 0
            Dim TOTAL_Syntaksiodotika As Double = 0
            Dim TOTAL_MiwsiApolavon As Double = 0
            Dim TOTAL_WidowOrphans As Double = 0
            Dim TOTAL_PensionFund As Double = 0

            Dim TOTAL_BIKWithSI As Double = 0
            Dim TOTAL_BIKWithoutSI As Double = 0
            Dim TOTAL_GESYtoSI As Double = 0
            Dim TOTAL_GESYDed As Double = 0
            Dim TOTAL_GESYCon As Double = 0
            Dim TOTAL_DirectorFees As Double



            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    place = "Totals"
                    index = i

                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + DbNullToInt(.Item(C_Local))
                        TOTAL_Abroad = TOTAL_Abroad + DbNullToInt(.Item(C_Abroad))
                        TOTAL_Allowances = TOTAL_Allowances + DbNullToInt(.Item(C_Allowances))
                        TOTAL_Total456 = TOTAL_Total456 + DbNullToInt(.Item(C_Total456))
                        TOTAL_SI = TOTAL_SI + DbNullToInt(.Item(C_SI))
                        TOTAL_PF = TOTAL_PF + DbNullToInt(.Item(C_PF))
                        TOTAL_MF = TOTAL_MF + DbNullToInt(.Item(C_MF))
                        TOTAL_UNION = TOTAL_UNION + DbNullToInt(.Item(C_UNION))
                        TOTAL_OtherDisc = TOTAL_OtherDisc + DbNullToInt(.Item(C_OtherDisc))
                        TOTAL_TotalDisc = TOTAL_TotalDisc + DbNullToInt(.Item(C_TotalDisc))
                        TOTAL_Taxable = TOTAL_Taxable + DbNullToInt(.Item(C_Taxable))
                        TOTAL_IT = TOTAL_IT + DbNullToDouble(.Item(C_IT))
                        TOTAL_SpecialTax = TOTAL_SpecialTax + DbNullToInt(.Item(C_EmpSpecialTaxDed)) + DbNullToInt(.Item(C_EmpSpecialTaxCon))
                        TOTAL_SPDeduction = TOTAL_SPDeduction + DbNullToInt(.Item(C_EmpSpecialTaxDed))
                        TOTAL_SPContribution = TOTAL_SPContribution + DbNullToInt(.Item(C_EmpSpecialTaxCon))
                        TOTAL_LifeInsurance = TOTAL_LifeInsurance + DbNullToInt(.Item(C_LifeInsurance))

                        TOTAL_AllowanceBenefits = TOTAL_AllowanceBenefits + DbNullToDouble(.Item(C_AllowanceBenefits))
                        TOTAL_TaxableFromOther = TOTAL_TaxableFromOther + DbNullToDouble(.Item(C_TaxableFromOther))
                        TOTAL_NonTaxable = TOTAL_NonTaxable + DbNullToDouble(.Item(C_NonTaxable))
                        TOTAL_Syntaksiodotika = TOTAL_Syntaksiodotika + DbNullToDouble(.Item(C_Syntaksiodotika))
                        TOTAL_MiwsiApolavon = TOTAL_MiwsiApolavon + DbNullToDouble(.Item(C_MiwsiApolavon))
                        TOTAL_WidowOrphans = TOTAL_WidowOrphans + DbNullToDouble(.Item(C_WidowOrphans))
                        TOTAL_PensionFund = TOTAL_PensionFund + DbNullToDouble(.Item(C_PensionFund))

                        TOTAL_BIKWithSI = TOTAL_BIKWithSI + DbNullToDouble(.Item(C_BIK_withSI))
                        TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + DbNullToDouble(.Item(C_BIK_withoutSI))
                        TOTAL_GESYtoSI = TOTAL_GESYtoSI + DbNullToDouble(.Item(C_GESYtoSI))
                        TOTAL_GESYDed = TOTAL_GESYDed + DbNullToDouble(.Item(C_GESYtoBIKDed))
                        TOTAL_GESYCon = TOTAL_GESYCon + DbNullToDouble(.Item(C_GESYtoBIKCon))
                        TOTAL_DirectorFees = TOTAL_DirectorFees + DbNullToDouble(.Item(C_DirectorFees))

                    End With

                Next
                TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + TOTAL_DirectorFees
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '0
                Str03 = 1 & PP
                '1
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '2
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '3
                Str03 = Str03 & " " & PP
                '4
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '5
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '6
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '7
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '8
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '9
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '10
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '11
                Str03 = Str03 & FixInteger((i), 5) & PP
                '12
                Str03 = Str03 & FixInteger(TOTAL_Local, 10) & PP
                '13
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9) & PP
                '14
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9) & PP
                '15
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10) & PP
                '16
                Str03 = Str03 & FixInteger(TOTAL_SI, 9) & PP
                '17
                Str03 = Str03 & FixInteger(TOTAL_PF, 9) & PP
                '18
                Str03 = Str03 & FixInteger(TOTAL_MF, 9) & PP
                '19
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9) & PP
                '20
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9) & PP
                '21
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9) & PP
                '22
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10) & PP
                '23
                Str03 = Str03 & FixNumber(TOTAL_IT, 11) & PP
                '24
                Str03 = Str03 & FixNumber(0, 11) & PP
                '25
                Str03 = Str03 & FixNumber(0, 11) & PP
                '26
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                Str03 = Str03 & FixNumber(TaxGiven, 11) & PP
                '29
                Str03 = Str03 & FixNumber(0, 11) & PP
                '30
                Str03 = Str03 & FixNumber(0, 11) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC

                End If
                TIC4 = Company.AccountantTIC
                '31
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '32
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & Company.AccIdentity & PP
                '36
                Str03 = Str03 & Company.TICCategory & PP
                '37
                Str03 = Str03 & Company.TICType & PP
                '38
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '39
                Str03 = Str03 & Original & PP
                '40
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 11) & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 11) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 11) & PP
                '43
                Str03 = Str03 & Company.AccountantTitle & PP
                '44
                Str03 = Str03 & Company.AccountantTIC & PP
                '45
                Str03 = Str03 & FixInteger(TOTAL_LifeInsurance, 11) & PP
                '46
                Str03 = Str03 & FixInteger(TOTAL_AllowanceBenefits, 11) & PP
                '47
                Str03 = Str03 & FixInteger(TOTAL_TaxableFromOther, 11) & PP
                '48
                Str03 = Str03 & FixInteger(TOTAL_NonTaxable, 11) & PP
                '49
                Str03 = Str03 & FixNumber(TOTAL_Syntaksiodotika, 11) & PP
                '50
                Str03 = Str03 & FixNumber(TOTAL_MiwsiApolavon, 11) & PP
                '51
                Str03 = Str03 & FixNumber(TOTAL_WidowOrphans, 11) & PP
                '52
                Str03 = Str03 & FixNumber(TOTAL_PensionFund, 11) & PP

                '#2019 GESY
                '53
                Str03 = Str03 & FixNumber(TOTAL_BIKWithSI, 11) & PP
                '54
                Str03 = Str03 & FixNumber(TOTAL_BIKWithoutSI, 11) & PP
                '55
                Str03 = Str03 & FixNumber(TOTAL_GESYtoSI, 11) & PP
                '56
                Str03 = Str03 & FixNumber(TOTAL_GESYDed, 11) & PP
                '57
                Str03 = Str03 & FixNumber(TOTAL_GESYCon, 11)



                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    Place = "lines " & i
                    index = i

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP

                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Place3 = LastName & " " & FirstName
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5) & PP
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10) & PP
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9) & PP
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9) & PP
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9) & PP
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9) & PP
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9) & PP
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9) & PP
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9) & PP
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Place = "Lines Date In " & i
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                            Place = "Lines Date Out " & i
                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 11) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 11) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then

                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        Place2 = 1
                        If .Item(C_EmpIDType) = " " Then
                            Place2 = 2
                            Str02 = Str02 & "0" & PP
                            Place2 = 3
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            'T"
                            Place2 = 4
                            Str02 = Str02 & "1" & PP
                            Place2 = 5
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            'A
                            Place2 = 6
                            Str02 = Str02 & "2" & PP
                            Place2 = 7
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            'F
                            Place2 = 8
                            Str02 = Str02 & "3" & PP
                            Place2 = 9

                        End If

                        Place2 = "x1"



                        '45
                        Str02 = Str02 & FixInteger(.Item(C_LifeInsurance), 11) & PP
                        Place2 = "x2"
                        '46
                        Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_TaxableFromOther)), 11) & PP
                        Place2 = "x3"
                        '47
                        Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_NonTaxable)), 11) & PP
                        Place2 = "x4"
                        '48
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_Syntaksiodotika)), 11) & PP
                        Place2 = "x5"
                        '49
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_MiwsiApolavon)), 11) & PP
                        Place2 = "x6"
                        '50
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_WidowOrphans)), 11) & PP
                        Place2 = "x7"
                        '51
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PensionFund)), 11) & PP
                        Place2 = "x8"

                        '#2019 GESY
                        '52
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withSI)), 11) & PP
                        Place2 = "x9"
                        '53
                        Dim BIK_WithoutSI As Double = 0
                        Dim DirectorFees As Double = 0

                        BIK_WithoutSI = DbNullToDouble(.Item(C_BIK_withoutSI))
                        DirectorFees = DbNullToDouble(.Item(C_DirectorFees))
                        Dim AB As Double = BIK_WithoutSI + DirectorFees
                        'Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withoutSI)), 11) & PP
                        Str02 = Str02 & FixNumber(AB, 11) & PP
                        Place2 = "x10"
                        '54
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoSI)), 11) & PP
                        Place2 = "x11"
                        '55
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKDed)), 11) & PP
                        Place2 = "x12"
                        '56
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKCon)), 11) & PP
                        Place2 = "x13"
                        '57
                        Str02 = Str02 & DbNullToString(.Item(C_EmpType)) & PP
                        Place2 = "x14"
                        Dim EmpCode As String
                        EmpCode = DbNullToString(.Item(C_EmpCode))
                        Str02 = Str02 & EmpCode
                        Place2 = "x15"




                    End With
                    Str02 = Replace(Str02, "&", " ")
                    Place = "lines before write " & i
                    Place2 = "x15"
                    Place4 = Str02
                    WriteToIR7File(Str02)

                    Place2 = "x16"

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox(index)
            MsgBox(Place)
            MsgBox(Place2)
            MsgBox(Place3)
            MsgBox(Place4)
            Flag = False
        End Try
        Return Flag
    End Function

    Private Function CreateIR7File_2024(ByVal Ds As DataSet) As Boolean
        Dim index As Integer
        Dim Place As String = ""
        Dim Place2 As String = ""
        Dim Place3 As String = ""
        Dim Place4 As String = ""

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30

            Dim C_LifeInsurance As Integer = 31

            Dim C_AllowanceBenefits As Integer = 32
            Dim C_TaxableFromOther As Integer = 33
            Dim C_NonTaxable As Integer = 34
            Dim C_Syntaksiodotika As Integer = 35
            Dim C_MiwsiApolavon As Integer = 36
            Dim C_WidowOrphans As Integer = 37
            Dim C_PensionFund As Integer = 38
            '#2019
            Dim C_BIK_withSI As Integer = 39
            Dim C_BIK_withoutSI As Integer = 40
            'Include them in Total epr7m3t0r4c1
            'end of #2019
            Dim C_GESYtoSI As Integer = 41
            Dim C_GESYtoBIKDed As Integer = 42
            Dim C_GESYtoBIKCon As Integer = 43
            Dim C_EmpType As Integer = 44
            Dim C_DirectorFees As Integer = 46
            Dim C_PrivatePensionFund As Integer = 47
            Dim C_PrivateMedicalFund As Integer = 48

            Dim C_PREV_GrossEarnings As Integer = 49
            Dim C_PREV_SIDed As Integer = 50
            Dim C_PREV_PFFund As Integer = 51
            Dim C_PREV_LifeIns As Integer = 52
            Dim C_PREV_Discounts As Integer = 53
            Dim C_PREV_Medical As Integer = 54
            Dim C_PREV_PensionFund As Integer = 55
            Dim C_PREV_UnionDed As Integer = 56
            Dim C_PREV_Gesi As Integer = 57
            Dim C_Email As Integer = 58
            Dim C_LWBPensioner As Integer = 59
            Dim C_NotionalAmount As Integer = 60
            Dim C_NotionalTax As Integer = 61



            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Double = 0
            Dim TOTAL_Abroad As Double = 0
            Dim TOTAL_Allowances As Double = 0
            Dim TOTAL_Total456 As Double = 0
            Dim TOTAL_SI As Double = 0
            Dim TOTAL_PF As Double = 0
            Dim TOTAL_MF As Double = 0
            Dim TOTAL_UNION As Double = 0
            Dim TOTAL_OtherDisc As Double = 0
            Dim TOTAL_TotalDisc As Double = 0
            Dim TOTAL_Taxable As Double = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim TOTAL_LifeInsurance As Double = 0

            Dim TOTAL_AllowanceBenefits As Double = 0
            Dim TOTAL_TaxableFromOther As Double = 0
            Dim TOTAL_NonTaxable As Double = 0
            Dim TOTAL_Syntaksiodotika As Double = 0
            Dim TOTAL_MiwsiApolavon As Double = 0
            Dim TOTAL_WidowOrphans As Double = 0
            Dim TOTAL_PensionFund As Double = 0

            Dim TOTAL_BIKWithSI As Double = 0
            Dim TOTAL_BIKWithoutSI As Double = 0
            Dim TOTAL_GESYtoSI As Double = 0
            Dim TOTAL_GESYDed As Double = 0
            Dim TOTAL_GESYCon As Double = 0
            Dim TOTAL_DirectorFees As Double = 0
            Dim TOTAL_PrivatePensionFund As Double = 0
            Dim TOTAL_PrivateMedical As Double = 0

            Dim TOTAL_NotionalAmount As Double = 0
            Dim TOTAL_NotionalTax As Double = 0




            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Place = "Totals"
                    index = i

                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + DbNullToDouble(.Item(C_Local))
                        TOTAL_Abroad = TOTAL_Abroad + DbNullToDouble(.Item(C_Abroad))
                        TOTAL_Allowances = TOTAL_Allowances + DbNullToDouble(.Item(C_Allowances))
                        TOTAL_Total456 = TOTAL_Total456 + DbNullToDouble(.Item(C_Total456))
                        TOTAL_SI = TOTAL_SI + DbNullToDouble(.Item(C_SI))
                        TOTAL_PF = TOTAL_PF + DbNullToDouble(.Item(C_PF))
                        TOTAL_MF = TOTAL_MF + DbNullToDouble(.Item(C_MF))
                        TOTAL_UNION = TOTAL_UNION + DbNullToDouble(.Item(C_UNION))
                        TOTAL_OtherDisc = TOTAL_OtherDisc + DbNullToDouble(.Item(C_OtherDisc))
                        TOTAL_TotalDisc = TOTAL_TotalDisc + DbNullToDouble(.Item(C_TotalDisc))
                        TOTAL_Taxable = TOTAL_Taxable + DbNullToDouble(.Item(C_Taxable))
                        TOTAL_IT = TOTAL_IT + DbNullToDouble(.Item(C_IT))
                        TOTAL_SpecialTax = TOTAL_SpecialTax + DbNullToDouble(.Item(C_EmpSpecialTaxDed)) + DbNullToDouble(.Item(C_EmpSpecialTaxCon))
                        TOTAL_SPDeduction = TOTAL_SPDeduction + DbNullToDouble(.Item(C_EmpSpecialTaxDed))
                        TOTAL_SPContribution = TOTAL_SPContribution + DbNullToDouble(.Item(C_EmpSpecialTaxCon))
                        TOTAL_LifeInsurance = TOTAL_LifeInsurance + DbNullToDouble(.Item(C_LifeInsurance))

                        TOTAL_AllowanceBenefits = TOTAL_AllowanceBenefits + DbNullToDouble(.Item(C_AllowanceBenefits))
                        TOTAL_TaxableFromOther = TOTAL_TaxableFromOther + DbNullToDouble(.Item(C_TaxableFromOther))
                        TOTAL_NonTaxable = TOTAL_NonTaxable + DbNullToDouble(.Item(C_NonTaxable))
                        TOTAL_Syntaksiodotika = TOTAL_Syntaksiodotika + DbNullToDouble(.Item(C_Syntaksiodotika))
                        TOTAL_MiwsiApolavon = TOTAL_MiwsiApolavon + DbNullToDouble(.Item(C_MiwsiApolavon))
                        TOTAL_WidowOrphans = TOTAL_WidowOrphans + DbNullToDouble(.Item(C_WidowOrphans))
                        TOTAL_PensionFund = TOTAL_PensionFund + DbNullToDouble(.Item(C_PensionFund))

                        TOTAL_BIKWithSI = TOTAL_BIKWithSI + DbNullToDouble(.Item(C_BIK_withSI))
                        TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + DbNullToDouble(.Item(C_BIK_withoutSI))
                        TOTAL_GESYtoSI = TOTAL_GESYtoSI + DbNullToDouble(.Item(C_GESYtoSI))
                        TOTAL_GESYDed = TOTAL_GESYDed + DbNullToDouble(.Item(C_GESYtoBIKDed))
                        TOTAL_GESYCon = TOTAL_GESYCon + DbNullToDouble(.Item(C_GESYtoBIKCon))
                        TOTAL_DirectorFees = TOTAL_DirectorFees + DbNullToDouble(.Item(C_DirectorFees))
                        TOTAL_PrivatePensionFund = TOTAL_PrivatePensionFund + DbNullToDouble(.Item(C_PrivatePensionFund))
                        TOTAL_PrivatePensionFund = TOTAL_PrivateMedical + DbNullToDouble(.Item(C_PrivateMedicalFund))


                        TOTAL_NotionalAmount = TOTAL_NotionalAmount + DbNullToDouble(.Item(C_NotionalAmount))
                        TOTAL_NotionalTax = TOTAL_NotionalTax + DbNullToDouble(.Item(C_NotionalTax))
                    End With

                Next
                TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + TOTAL_DirectorFees
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '0
                Str03 = 1 & PP
                '1
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '2
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '3
                Str03 = Str03 & " " & PP
                '4
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '5
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '6
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '7
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '8
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '9
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '10
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '11
                Str03 = Str03 & FixNumber((i), 15) & PP
                '12
                Str03 = Str03 & FixNumber(TOTAL_Local, 15) & PP
                '13
                Str03 = Str03 & FixNumber(TOTAL_Abroad, 15) & PP
                '14
                Str03 = Str03 & FixNumber(TOTAL_Allowances, 15) & PP
                '15
                Str03 = Str03 & FixNumber(TOTAL_Total456, 15) & PP
                '16
                Str03 = Str03 & FixNumber(TOTAL_SI, 15) & PP
                '17
                Str03 = Str03 & FixNumber(TOTAL_PF, 15) & PP
                '18
                Str03 = Str03 & FixNumber(TOTAL_MF, 15) & PP
                '19
                Str03 = Str03 & FixNumber(TOTAL_UNION, 15) & PP
                '20
                Str03 = Str03 & FixNumber(TOTAL_OtherDisc, 15) & PP
                '21
                Str03 = Str03 & FixNumber(TOTAL_TotalDisc, 15) & PP
                '22
                Str03 = Str03 & FixNumber(TOTAL_Taxable, 15) & PP
                '23
                Str03 = Str03 & FixNumber(TOTAL_IT, 15) & PP
                '24
                Str03 = Str03 & FixNumber(0, 15) & PP
                '25
                Str03 = Str03 & FixNumber(0, 15) & PP
                '26
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                Str03 = Str03 & FixNumber(TaxGiven, 15) & PP
                '29
                Str03 = Str03 & FixNumber(0, 15) & PP
                '30
                Str03 = Str03 & FixNumber(0, 15) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC

                End If
                TIC4 = Company.AccountantTIC
                '31
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '32
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & Company.AccIdentity & PP
                '36
                Str03 = Str03 & Company.TICCategory & PP
                '37
                Str03 = Str03 & Company.TICType & PP
                '38
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '39
                Str03 = Str03 & Original & PP
                '40
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 15) & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 15) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 15) & PP
                '43
                Str03 = Str03 & Company.AccountantTitle & PP
                '44
                Str03 = Str03 & Company.AccountantTIC & PP
                '45
                Str03 = Str03 & FixNumber(TOTAL_LifeInsurance, 15) & PP
                '46
                Str03 = Str03 & FixNumber(TOTAL_AllowanceBenefits, 15) & PP
                '47
                Str03 = Str03 & FixNumber(TOTAL_TaxableFromOther, 15) & PP
                '48
                Str03 = Str03 & FixNumber(TOTAL_NonTaxable, 15) & PP
                '49
                Str03 = Str03 & FixNumber(TOTAL_Syntaksiodotika, 15) & PP
                '50
                Str03 = Str03 & FixNumber(TOTAL_MiwsiApolavon, 15) & PP
                '51
                Str03 = Str03 & FixNumber(TOTAL_WidowOrphans, 15) & PP
                '52
                Str03 = Str03 & FixNumber(TOTAL_PensionFund, 15) & PP

                '#2019 GESY
                '53
                Str03 = Str03 & FixNumber(TOTAL_BIKWithSI, 15) & PP
                '54
                Str03 = Str03 & FixNumber(TOTAL_BIKWithoutSI, 15) & PP
                '55
                Str03 = Str03 & FixNumber(TOTAL_GESYtoSI, 15) & PP
                '56
                Str03 = Str03 & FixNumber(TOTAL_GESYDed, 15) & PP
                '57
                Str03 = Str03 & FixNumber(TOTAL_GESYCon, 15) & PP
                '58
                Str03 = Str03 & FixNumber(TOTAL_DirectorFees, 15) & PP
                '59
                Str03 = Str03 & FixNumber(TOTAL_PrivatePensionFund, 15) & PP
                '60
                Str03 = Str03 & FixNumber(TOTAL_PrivateMedical, 11) & PP

                '61
                Str03 = Str03 & FixNumber(TOTAL_NotionalAmount, 15) & PP
                '62
                Str03 = Str03 & FixNumber(TOTAL_NotionalTax, 15)


                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    Place = "lines " & i
                    index = i

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP

                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Place3 = LastName & " " & FirstName
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixNumber((i + 1), 15) & PP
                        '13
                        Str02 = Str02 & FixNumber(.Item(C_Local), 15) & PP
                        '14
                        Str02 = Str02 & FixNumber(.Item(C_Abroad), 15) & PP
                        '15

                        Str02 = Str02 & FixNumber(.Item(C_Allowances), 15) & PP
                        '16
                        Str02 = Str02 & FixNumber(.Item(C_Total456), 15) & PP
                        '17
                        Str02 = Str02 & FixNumber(.Item(C_SI), 15) & PP
                        '18
                        Str02 = Str02 & FixNumber(.Item(C_PF), 15) & PP
                        '19
                        Str02 = Str02 & FixNumber(.Item(C_MF), 15) & PP
                        '20
                        Str02 = Str02 & FixNumber(.Item(C_UNION), 15) & PP
                        '21
                        Str02 = Str02 & FixNumber(.Item(C_OtherDisc), 15) & PP
                        '22
                        Str02 = Str02 & FixNumber(.Item(C_TotalDisc), 15) & PP
                        '23
                        Str02 = Str02 & FixNumber(.Item(C_Taxable), 15) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 15) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 15) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 15) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Place = "Lines Date In " & i
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                            Place = "Lines Date Out " & i
                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 15) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 15) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then

                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        Place2 = 1
                        If .Item(C_EmpIDType) = " " Then
                            Place2 = 2
                            Str02 = Str02 & "0" & PP
                            Place2 = 3
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            'T"
                            Place2 = 4
                            Str02 = Str02 & "1" & PP
                            Place2 = 5
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            'A
                            Place2 = 6
                            Str02 = Str02 & "2" & PP
                            Place2 = 7
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            'F
                            Place2 = 8
                            Str02 = Str02 & "3" & PP
                            Place2 = 9

                        End If

                        Place2 = "x1"



                        '45
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_LifeInsurance)), 15) & PP
                        Place2 = "x2"
                        '46
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_TaxableFromOther)), 15) & PP
                        Place2 = "x3"
                        '47
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_NonTaxable)), 15) & PP
                        Place2 = "x4"
                        '48
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_Syntaksiodotika)), 15) & PP
                        Place2 = "x5"
                        '49
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_MiwsiApolavon)), 15) & PP
                        Place2 = "x6"
                        '50
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_WidowOrphans)), 15) & PP
                        Place2 = "x7"
                        '51
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PensionFund)), 15) & PP
                        Place2 = "x8"

                        '#2019 GESY
                        '52
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withSI)), 15) & PP
                        Place2 = "x9"
                        '53
                        Dim BIK_WithoutSI As Double = 0
                        Dim DirectorFees As Double = 0

                        BIK_WithoutSI = DbNullToDouble(.Item(C_BIK_withoutSI))
                        DirectorFees = DbNullToDouble(.Item(C_DirectorFees))
                        Dim AB As Double = BIK_WithoutSI '+ DirectorFees
                        'Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withoutSI)), 15) & PP
                        Str02 = Str02 & FixNumber(AB, 15) & PP
                        Place2 = "x10"
                        '54
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoSI)), 15) & PP
                        Place2 = "x11"
                        '55
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKDed)), 15) & PP
                        Place2 = "x12"
                        '56
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKCon)), 15) & PP
                        Place2 = "x13"
                        '57
                        Str02 = Str02 & DbNullToString(.Item(C_EmpType)) & PP
                        Place2 = "x14"
                        '58
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_DirectorFees)), 15) & PP
                        '59
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PrivatePensionFund)), 15) & PP
                        '60
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PrivateMedicalFund)), 15) & PP
                        '61
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_GrossEarnings)), 15) & PP
                        '62
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_SIDed)), 15) & PP
                        '63
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_PFFund)), 15) & PP
                        '64
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_LifeIns)), 15) & PP
                        '65
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Discounts)), 15) & PP
                        '66
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Medical)), 15) & PP
                        '67
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_PensionFund)), 15) & PP
                        '68
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_UnionDed)), 15) & PP
                        '69
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Gesi)), 15) & PP
                        '70
                        Str02 = Str02 & DbNullToString(.Item(C_Email)) & PP
                        '71
                        Str02 = Str02 & DbNullToString(.Item(C_LWBPensioner)) & PP
                        '72
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_NotionalAmount)), 15) & PP
                        '73
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_NotionalTax)), 15)





                    End With
                    Str02 = Replace(Str02, "&", " ")
                    Place = "lines before write " & i
                    Place2 = "x15"
                    Place4 = Str02
                    WriteToIR7File(Str02)

                    Place2 = "x16"

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox(index)
            MsgBox(Place)
            MsgBox(Place2)
            MsgBox(Place3)
            MsgBox(Place4)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function CreateIR7File_2024_Integers(ByVal Ds As DataSet) As Boolean
        Dim index As Integer
        Dim Place As String = ""
        Dim Place2 As String = ""
        Dim Place3 As String = ""
        Dim Place4 As String = ""

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30

            Dim C_LifeInsurance As Integer = 31

            Dim C_AllowanceBenefits As Integer = 32
            Dim C_TaxableFromOther As Integer = 33
            Dim C_NonTaxable As Integer = 34
            Dim C_Syntaksiodotika As Integer = 35
            Dim C_MiwsiApolavon As Integer = 36
            Dim C_WidowOrphans As Integer = 37
            Dim C_PensionFund As Integer = 38
            '#2019
            Dim C_BIK_withSI As Integer = 39
            Dim C_BIK_withoutSI As Integer = 40
            'Include them in Total epr7m3t0r4c1
            'end of #2019
            Dim C_GESYtoSI As Integer = 41
            Dim C_GESYtoBIKDed As Integer = 42
            Dim C_GESYtoBIKCon As Integer = 43
            Dim C_EmpType As Integer = 44
            Dim C_DirectorFees As Integer = 46
            Dim C_PrivatePensionFund As Integer = 47
            Dim C_PrivateMedicalFund As Integer = 48

            Dim C_PREV_GrossEarnings As Integer = 49
            Dim C_PREV_SIDed As Integer = 50
            Dim C_PREV_PFFund As Integer = 51
            Dim C_PREV_LifeIns As Integer = 52
            Dim C_PREV_Discounts As Integer = 53
            Dim C_PREV_Medical As Integer = 54
            Dim C_PREV_PensionFund As Integer = 55
            Dim C_PREV_UnionDed As Integer = 56
            Dim C_PREV_Gesi As Integer = 57



            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim TOTAL_LifeInsurance As Double = 0

            Dim TOTAL_AllowanceBenefits As Double = 0
            Dim TOTAL_TaxableFromOther As Double = 0
            Dim TOTAL_NonTaxable As Double = 0
            Dim TOTAL_Syntaksiodotika As Double = 0
            Dim TOTAL_MiwsiApolavon As Double = 0
            Dim TOTAL_WidowOrphans As Double = 0
            Dim TOTAL_PensionFund As Double = 0

            Dim TOTAL_BIKWithSI As Double = 0
            Dim TOTAL_BIKWithoutSI As Double = 0
            Dim TOTAL_GESYtoSI As Double = 0
            Dim TOTAL_GESYDed As Double = 0
            Dim TOTAL_GESYCon As Double = 0
            Dim TOTAL_DirectorFees As Double = 0
            Dim TOTAL_PrivatePensionFund As Double = 0
            Dim TOTAL_PrivateMedical As Double = 0



            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Place = "Totals"
                    index = i

                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + DbNullToInt(.Item(C_Local))
                        TOTAL_Abroad = TOTAL_Abroad + DbNullToInt(.Item(C_Abroad))
                        TOTAL_Allowances = TOTAL_Allowances + DbNullToInt(.Item(C_Allowances))
                        TOTAL_Total456 = TOTAL_Total456 + DbNullToInt(.Item(C_Total456))
                        TOTAL_SI = TOTAL_SI + DbNullToInt(.Item(C_SI))
                        TOTAL_PF = TOTAL_PF + DbNullToInt(.Item(C_PF))
                        TOTAL_MF = TOTAL_MF + DbNullToInt(.Item(C_MF))
                        TOTAL_UNION = TOTAL_UNION + DbNullToInt(.Item(C_UNION))
                        TOTAL_OtherDisc = TOTAL_OtherDisc + DbNullToInt(.Item(C_OtherDisc))
                        TOTAL_TotalDisc = TOTAL_TotalDisc + DbNullToInt(.Item(C_TotalDisc))
                        TOTAL_Taxable = TOTAL_Taxable + DbNullToInt(.Item(C_Taxable))
                        TOTAL_IT = TOTAL_IT + DbNullToDouble(.Item(C_IT))
                        TOTAL_SpecialTax = TOTAL_SpecialTax + DbNullToInt(.Item(C_EmpSpecialTaxDed)) + DbNullToInt(.Item(C_EmpSpecialTaxCon))
                        TOTAL_SPDeduction = TOTAL_SPDeduction + DbNullToInt(.Item(C_EmpSpecialTaxDed))
                        TOTAL_SPContribution = TOTAL_SPContribution + DbNullToInt(.Item(C_EmpSpecialTaxCon))
                        TOTAL_LifeInsurance = TOTAL_LifeInsurance + DbNullToInt(.Item(C_LifeInsurance))

                        TOTAL_AllowanceBenefits = TOTAL_AllowanceBenefits + DbNullToDouble(.Item(C_AllowanceBenefits))
                        TOTAL_TaxableFromOther = TOTAL_TaxableFromOther + DbNullToDouble(.Item(C_TaxableFromOther))
                        TOTAL_NonTaxable = TOTAL_NonTaxable + DbNullToDouble(.Item(C_NonTaxable))
                        TOTAL_Syntaksiodotika = TOTAL_Syntaksiodotika + DbNullToDouble(.Item(C_Syntaksiodotika))
                        TOTAL_MiwsiApolavon = TOTAL_MiwsiApolavon + DbNullToDouble(.Item(C_MiwsiApolavon))
                        TOTAL_WidowOrphans = TOTAL_WidowOrphans + DbNullToDouble(.Item(C_WidowOrphans))
                        TOTAL_PensionFund = TOTAL_PensionFund + DbNullToDouble(.Item(C_PensionFund))

                        TOTAL_BIKWithSI = TOTAL_BIKWithSI + DbNullToDouble(.Item(C_BIK_withSI))
                        TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + DbNullToDouble(.Item(C_BIK_withoutSI))
                        TOTAL_GESYtoSI = TOTAL_GESYtoSI + DbNullToDouble(.Item(C_GESYtoSI))
                        TOTAL_GESYDed = TOTAL_GESYDed + DbNullToDouble(.Item(C_GESYtoBIKDed))
                        TOTAL_GESYCon = TOTAL_GESYCon + DbNullToDouble(.Item(C_GESYtoBIKCon))
                        TOTAL_DirectorFees = TOTAL_DirectorFees + DbNullToDouble(.Item(C_DirectorFees))
                        TOTAL_PrivatePensionFund = TOTAL_PrivatePensionFund + DbNullToDouble(.Item(C_PrivatePensionFund))
                        TOTAL_PrivatePensionFund = TOTAL_PrivateMedical + DbNullToDouble(.Item(C_PrivateMedicalFund))

                    End With

                Next
                TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + TOTAL_DirectorFees
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '0
                Str03 = 1 & PP
                '1
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '2
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '3
                Str03 = Str03 & " " & PP
                '4
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '5
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '6
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '7
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '8
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '9
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '10
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '11
                Str03 = Str03 & FixInteger((i), 5) & PP
                '12
                Str03 = Str03 & FixInteger(TOTAL_Local, 10) & PP
                '13
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9) & PP
                '14
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9) & PP
                '15
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10) & PP
                '16
                Str03 = Str03 & FixInteger(TOTAL_SI, 9) & PP
                '17
                Str03 = Str03 & FixInteger(TOTAL_PF, 9) & PP
                '18
                Str03 = Str03 & FixInteger(TOTAL_MF, 9) & PP
                '19
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9) & PP
                '20
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9) & PP
                '21
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9) & PP
                '22
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10) & PP
                '23
                Str03 = Str03 & FixNumber(TOTAL_IT, 11) & PP
                '24
                Str03 = Str03 & FixNumber(0, 11) & PP
                '25
                Str03 = Str03 & FixNumber(0, 11) & PP
                '26
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                Str03 = Str03 & FixNumber(TaxGiven, 11) & PP
                '29
                Str03 = Str03 & FixNumber(0, 11) & PP
                '30
                Str03 = Str03 & FixNumber(0, 11) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC

                End If
                TIC4 = Company.AccountantTIC
                '31
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '32
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & Company.AccIdentity & PP
                '36
                Str03 = Str03 & Company.TICCategory & PP
                '37
                Str03 = Str03 & Company.TICType & PP
                '38
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '39
                Str03 = Str03 & Original & PP
                '40
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 11) & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 11) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 11) & PP
                '43
                Str03 = Str03 & Company.AccountantTitle & PP
                '44
                Str03 = Str03 & Company.AccountantTIC & PP
                '45
                Str03 = Str03 & FixInteger(TOTAL_LifeInsurance, 11) & PP
                '46
                Str03 = Str03 & FixInteger(TOTAL_AllowanceBenefits, 11) & PP
                '47
                Str03 = Str03 & FixInteger(TOTAL_TaxableFromOther, 11) & PP
                '48
                Str03 = Str03 & FixInteger(TOTAL_NonTaxable, 11) & PP
                '49
                Str03 = Str03 & FixNumber(TOTAL_Syntaksiodotika, 11) & PP
                '50
                Str03 = Str03 & FixNumber(TOTAL_MiwsiApolavon, 11) & PP
                '51
                Str03 = Str03 & FixNumber(TOTAL_WidowOrphans, 11) & PP
                '52
                Str03 = Str03 & FixNumber(TOTAL_PensionFund, 11) & PP

                '#2019 GESY
                '53
                Str03 = Str03 & FixNumber(TOTAL_BIKWithSI, 11) & PP
                '54
                Str03 = Str03 & FixNumber(TOTAL_BIKWithoutSI, 11) & PP
                '55
                Str03 = Str03 & FixNumber(TOTAL_GESYtoSI, 11) & PP
                '56
                Str03 = Str03 & FixNumber(TOTAL_GESYDed, 11) & PP
                '57
                Str03 = Str03 & FixNumber(TOTAL_GESYCon, 11) & PP
                '58
                Str03 = Str03 & FixNumber(TOTAL_DirectorFees, 11) & PP
                '59
                Str03 = Str03 & FixNumber(TOTAL_PrivatePensionFund, 11) & PP
                '60
                Str03 = Str03 & FixNumber(TOTAL_PrivateMedical, 11)


                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    Place = "lines " & i
                    index = i

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP

                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Place3 = LastName & " " & FirstName
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5) & PP
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10) & PP
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9) & PP
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9) & PP
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9) & PP
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9) & PP
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9) & PP
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9) & PP
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9) & PP
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Place = "Lines Date In " & i
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                            Place = "Lines Date Out " & i
                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 11) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 11) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then

                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        Place2 = 1
                        If .Item(C_EmpIDType) = " " Then
                            Place2 = 2
                            Str02 = Str02 & "0" & PP
                            Place2 = 3
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            'T"
                            Place2 = 4
                            Str02 = Str02 & "1" & PP
                            Place2 = 5
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            'A
                            Place2 = 6
                            Str02 = Str02 & "2" & PP
                            Place2 = 7
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            'F
                            Place2 = 8
                            Str02 = Str02 & "3" & PP
                            Place2 = 9

                        End If

                        Place2 = "x1"



                        '45
                        Str02 = Str02 & FixInteger(.Item(C_LifeInsurance), 11) & PP
                        Place2 = "x2"
                        '46
                        Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_TaxableFromOther)), 11) & PP
                        Place2 = "x3"
                        '47
                        Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_NonTaxable)), 11) & PP
                        Place2 = "x4"
                        '48
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_Syntaksiodotika)), 11) & PP
                        Place2 = "x5"
                        '49
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_MiwsiApolavon)), 11) & PP
                        Place2 = "x6"
                        '50
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_WidowOrphans)), 11) & PP
                        Place2 = "x7"
                        '51
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PensionFund)), 11) & PP
                        Place2 = "x8"

                        '#2019 GESY
                        '52
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withSI)), 11) & PP
                        Place2 = "x9"
                        '53
                        Dim BIK_WithoutSI As Double = 0
                        Dim DirectorFees As Double = 0

                        BIK_WithoutSI = DbNullToDouble(.Item(C_BIK_withoutSI))
                        DirectorFees = DbNullToDouble(.Item(C_DirectorFees))
                        Dim AB As Double = BIK_WithoutSI '+ DirectorFees
                        'Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withoutSI)), 11) & PP
                        Str02 = Str02 & FixNumber(AB, 11) & PP
                        Place2 = "x10"
                        '54
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoSI)), 11) & PP
                        Place2 = "x11"
                        '55
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKDed)), 11) & PP
                        Place2 = "x12"
                        '56
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKCon)), 11) & PP
                        Place2 = "x13"
                        '57
                        Str02 = Str02 & DbNullToString(.Item(C_EmpType)) & PP
                        Place2 = "x14"
                        '58
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_DirectorFees)), 11) & PP
                        '59
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PrivatePensionFund)), 11) & PP
                        '60
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PrivateMedicalFund)), 11) & PP
                        '61
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_GrossEarnings)), 11) & PP
                        '62
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_SIDed)), 11) & PP
                        '63
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_PFFund)), 11) & PP
                        '64
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_LifeIns)), 11) & PP
                        '65
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Discounts)), 11) & PP
                        '66
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Medical)), 11) & PP
                        '67
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_PensionFund)), 11) & PP
                        '68
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_UnionDed)), 11) & PP
                        '69
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Gesi)), 11)





                    End With
                    Str02 = Replace(Str02, "&", " ")
                    Place = "lines before write " & i
                    Place2 = "x15"
                    Place4 = Str02
                    WriteToIR7File(Str02)

                    Place2 = "x16"

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox(index)
            MsgBox(Place)
            MsgBox(Place2)
            MsgBox(Place3)
            MsgBox(Place4)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function CreateIR7File_2025(ByVal Ds As DataSet) As Boolean
        Dim index As Integer
        Dim Place As String = ""
        Dim Place2 As String = ""
        Dim Place3 As String = ""
        Dim Place4 As String = ""

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30

            Dim C_LifeInsurance As Integer = 31

            Dim C_AllowanceBenefits As Integer = 32
            Dim C_TaxableFromOther As Integer = 33
            Dim C_NonTaxable As Integer = 34
            Dim C_Syntaksiodotika As Integer = 35
            Dim C_MiwsiApolavon As Integer = 36
            Dim C_WidowOrphans As Integer = 37
            Dim C_PensionFund As Integer = 38
            '#2019
            Dim C_BIK_withSI As Integer = 39
            Dim C_BIK_withoutSI As Integer = 40
            'Include them in Total epr7m3t0r4c1
            'end of #2019
            Dim C_GESYtoSI As Integer = 41
            Dim C_GESYtoBIKDed As Integer = 42
            Dim C_GESYtoBIKCon As Integer = 43
            Dim C_EmpType As Integer = 44
            Dim C_DirectorFees As Integer = 46
            Dim C_PrivatePensionFund As Integer = 47
            Dim C_PrivateMedicalFund As Integer = 48

            Dim C_PREV_GrossEarnings As Integer = 49
            Dim C_PREV_SIDed As Integer = 50
            Dim C_PREV_PFFund As Integer = 51
            Dim C_PREV_LifeIns As Integer = 52
            Dim C_PREV_Discounts As Integer = 53
            Dim C_PREV_Medical As Integer = 54
            Dim C_PREV_PensionFund As Integer = 55
            Dim C_PREV_UnionDed As Integer = 56
            Dim C_PREV_Gesi As Integer = 57
            Dim C_Email As Integer = 58
            Dim C_LWBPensioner As Integer = 59
            Dim C_NotionalAmount As Integer = 60
            Dim C_NotionalTax As Integer = 61



            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Double = 0
            Dim TOTAL_Abroad As Double = 0
            Dim TOTAL_Allowances As Double = 0
            Dim TOTAL_Total456 As Double = 0
            Dim TOTAL_SI As Double = 0
            Dim TOTAL_PF As Double = 0
            Dim TOTAL_MF As Double = 0
            Dim TOTAL_UNION As Double = 0
            Dim TOTAL_OtherDisc As Double = 0
            Dim TOTAL_TotalDisc As Double = 0
            Dim TOTAL_Taxable As Double = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim TOTAL_LifeInsurance As Double = 0

            Dim TOTAL_AllowanceBenefits As Double = 0
            Dim TOTAL_TaxableFromOther As Double = 0
            Dim TOTAL_NonTaxable As Double = 0
            Dim TOTAL_Syntaksiodotika As Double = 0
            Dim TOTAL_MiwsiApolavon As Double = 0
            Dim TOTAL_WidowOrphans As Double = 0
            Dim TOTAL_PensionFund As Double = 0

            Dim TOTAL_BIKWithSI As Double = 0
            Dim TOTAL_BIKWithoutSI As Double = 0
            Dim TOTAL_GESYtoSI As Double = 0
            Dim TOTAL_GESYDed As Double = 0
            Dim TOTAL_GESYCon As Double = 0
            Dim TOTAL_DirectorFees As Double = 0
            Dim TOTAL_PrivatePensionFund As Double = 0
            Dim TOTAL_PrivateMedical As Double = 0

            Dim TOTAL_NotionalAmount As Double = 0
            Dim TOTAL_NotionalTax As Double = 0




            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Place = "Totals"
                    index = i

                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + DbNullToDouble(.Item(C_Local))
                        TOTAL_Abroad = TOTAL_Abroad + DbNullToDouble(.Item(C_Abroad))
                        TOTAL_Allowances = TOTAL_Allowances + DbNullToDouble(.Item(C_Allowances))
                        TOTAL_Total456 = TOTAL_Total456 + DbNullToDouble(.Item(C_Total456))
                        TOTAL_SI = TOTAL_SI + DbNullToDouble(.Item(C_SI))
                        TOTAL_PF = TOTAL_PF + DbNullToDouble(.Item(C_PF))
                        TOTAL_MF = TOTAL_MF + DbNullToDouble(.Item(C_MF))
                        TOTAL_UNION = TOTAL_UNION + DbNullToDouble(.Item(C_UNION))
                        TOTAL_OtherDisc = TOTAL_OtherDisc + DbNullToDouble(.Item(C_OtherDisc))
                        TOTAL_TotalDisc = TOTAL_TotalDisc + DbNullToDouble(.Item(C_TotalDisc))
                        TOTAL_Taxable = TOTAL_Taxable + DbNullToDouble(.Item(C_Taxable))
                        TOTAL_IT = TOTAL_IT + DbNullToDouble(.Item(C_IT))
                        TOTAL_SpecialTax = TOTAL_SpecialTax + DbNullToDouble(.Item(C_EmpSpecialTaxDed)) + DbNullToDouble(.Item(C_EmpSpecialTaxCon))
                        TOTAL_SPDeduction = TOTAL_SPDeduction + DbNullToDouble(.Item(C_EmpSpecialTaxDed))
                        TOTAL_SPContribution = TOTAL_SPContribution + DbNullToDouble(.Item(C_EmpSpecialTaxCon))
                        TOTAL_LifeInsurance = TOTAL_LifeInsurance + DbNullToDouble(.Item(C_LifeInsurance))

                        TOTAL_AllowanceBenefits = TOTAL_AllowanceBenefits + DbNullToDouble(.Item(C_AllowanceBenefits))
                        TOTAL_TaxableFromOther = TOTAL_TaxableFromOther + DbNullToDouble(.Item(C_TaxableFromOther))
                        TOTAL_NonTaxable = TOTAL_NonTaxable + DbNullToDouble(.Item(C_NonTaxable))
                        TOTAL_Syntaksiodotika = TOTAL_Syntaksiodotika + DbNullToDouble(.Item(C_Syntaksiodotika))
                        TOTAL_MiwsiApolavon = TOTAL_MiwsiApolavon + DbNullToDouble(.Item(C_MiwsiApolavon))
                        TOTAL_WidowOrphans = TOTAL_WidowOrphans + DbNullToDouble(.Item(C_WidowOrphans))
                        TOTAL_PensionFund = TOTAL_PensionFund + DbNullToDouble(.Item(C_PensionFund))

                        TOTAL_BIKWithSI = TOTAL_BIKWithSI + DbNullToDouble(.Item(C_BIK_withSI))
                        TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + DbNullToDouble(.Item(C_BIK_withoutSI))
                        TOTAL_GESYtoSI = TOTAL_GESYtoSI + DbNullToDouble(.Item(C_GESYtoSI))
                        TOTAL_GESYDed = TOTAL_GESYDed + DbNullToDouble(.Item(C_GESYtoBIKDed))
                        TOTAL_GESYCon = TOTAL_GESYCon + DbNullToDouble(.Item(C_GESYtoBIKCon))
                        TOTAL_DirectorFees = TOTAL_DirectorFees + DbNullToDouble(.Item(C_DirectorFees))
                        TOTAL_PrivatePensionFund = TOTAL_PrivatePensionFund + DbNullToDouble(.Item(C_PrivatePensionFund))
                        TOTAL_PrivatePensionFund = TOTAL_PrivateMedical + DbNullToDouble(.Item(C_PrivateMedicalFund))


                        TOTAL_NotionalAmount = TOTAL_NotionalAmount + DbNullToDouble(.Item(C_NotionalAmount))
                        TOTAL_NotionalTax = TOTAL_NotionalTax + DbNullToDouble(.Item(C_NotionalTax))
                    End With

                Next
                TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + TOTAL_DirectorFees
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '0
                Str03 = 1 & PP
                '1
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '2
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '3
                Str03 = Str03 & " " & PP
                '4
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '5
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '6
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '7
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '8
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '9
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '10
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '11
                Str03 = Str03 & FixNumber((i), 15) & PP
                '12
                Str03 = Str03 & FixNumber(TOTAL_Local, 15) & PP
                '13
                Str03 = Str03 & FixNumber(TOTAL_Abroad, 15) & PP
                '14
                Str03 = Str03 & FixNumber(TOTAL_Allowances, 15) & PP
                '15
                Str03 = Str03 & FixNumber(TOTAL_Total456, 15) & PP
                '16
                Str03 = Str03 & FixNumber(TOTAL_SI, 15) & PP
                '17
                Str03 = Str03 & FixNumber(TOTAL_PF, 15) & PP
                '18
                Str03 = Str03 & FixNumber(TOTAL_MF, 15) & PP
                '19
                Str03 = Str03 & FixNumber(TOTAL_UNION, 15) & PP
                '20
                Str03 = Str03 & FixNumber(TOTAL_OtherDisc, 15) & PP
                '21
                Str03 = Str03 & FixNumber(TOTAL_TotalDisc, 15) & PP
                '22
                Str03 = Str03 & FixNumber(TOTAL_Taxable, 15) & PP
                '23
                Str03 = Str03 & FixNumber(TOTAL_IT, 15) & PP
                '24
                Str03 = Str03 & FixNumber(0, 15) & PP
                '25
                Str03 = Str03 & FixNumber(0, 15) & PP
                '26
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                Str03 = Str03 & FixNumber(TaxGiven, 15) & PP
                '29
                Str03 = Str03 & FixNumber(0, 15) & PP
                '30
                Str03 = Str03 & FixNumber(0, 15) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC

                End If
                TIC4 = Company.AccountantTIC
                '31
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '32
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & Company.AccIdentity & PP
                '36
                Str03 = Str03 & Company.TICCategory & PP
                '37
                Str03 = Str03 & Company.TICType & PP
                '38
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '39
                Str03 = Str03 & Original & PP
                '40
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 15) & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 15) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 15) & PP
                '43
                Str03 = Str03 & Company.AccountantTitle & PP
                '44
                Str03 = Str03 & Company.AccountantTIC & PP
                '45
                Str03 = Str03 & FixNumber(TOTAL_LifeInsurance, 15) & PP
                '46
                Str03 = Str03 & FixNumber(TOTAL_AllowanceBenefits, 15) & PP
                '47
                Str03 = Str03 & FixNumber(TOTAL_TaxableFromOther, 15) & PP
                '48
                Str03 = Str03 & FixNumber(TOTAL_NonTaxable, 15) & PP
                '49
                Str03 = Str03 & FixNumber(TOTAL_Syntaksiodotika, 15) & PP
                '50
                Str03 = Str03 & FixNumber(TOTAL_MiwsiApolavon, 15) & PP
                '51
                Str03 = Str03 & FixNumber(TOTAL_WidowOrphans, 15) & PP
                '52
                Str03 = Str03 & FixNumber(TOTAL_PensionFund, 15) & PP

                '#2019 GESY
                '53
                Str03 = Str03 & FixNumber(TOTAL_BIKWithSI, 15) & PP
                '54
                Str03 = Str03 & FixNumber(TOTAL_BIKWithoutSI, 15) & PP
                '55
                Str03 = Str03 & FixNumber(TOTAL_GESYtoSI, 15) & PP
                '56
                Str03 = Str03 & FixNumber(TOTAL_GESYDed, 15) & PP
                '57
                Str03 = Str03 & FixNumber(TOTAL_GESYCon, 15) & PP
                '58
                Str03 = Str03 & FixNumber(TOTAL_DirectorFees, 15) & PP
                '59
                Str03 = Str03 & FixNumber(TOTAL_PrivatePensionFund, 15) & PP
                '60
                Str03 = Str03 & FixNumber(TOTAL_PrivateMedical, 11) & PP

                '61
                Str03 = Str03 & FixNumber(TOTAL_NotionalAmount, 15) & PP
                '62
                Str03 = Str03 & FixNumber(TOTAL_NotionalTax, 15)


                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    Place = "lines " & i
                    index = i

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP

                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Place3 = LastName & " " & FirstName
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixNumber((i + 1), 15) & PP
                        '13
                        Str02 = Str02 & FixNumber(.Item(C_Local), 15) & PP
                        '14
                        Str02 = Str02 & FixNumber(.Item(C_Abroad), 15) & PP
                        '15

                        Str02 = Str02 & FixNumber(.Item(C_Allowances), 15) & PP
                        '16
                        Str02 = Str02 & FixNumber(.Item(C_Total456), 15) & PP
                        '17
                        Str02 = Str02 & FixNumber(.Item(C_SI), 15) & PP
                        '18
                        Str02 = Str02 & FixNumber(.Item(C_PF), 15) & PP
                        '19
                        Str02 = Str02 & FixNumber(.Item(C_MF), 15) & PP
                        '20
                        Str02 = Str02 & FixNumber(.Item(C_UNION), 15) & PP
                        '21
                        Str02 = Str02 & FixNumber(.Item(C_OtherDisc), 15) & PP
                        '22
                        Str02 = Str02 & FixNumber(.Item(C_TotalDisc), 15) & PP
                        '23
                        Str02 = Str02 & FixNumber(.Item(C_Taxable), 15) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 15) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 15) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 15) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Place = "Lines Date In " & i
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                            Place = "Lines Date Out " & i
                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 15) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 15) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then

                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        Place2 = 1
                        If .Item(C_EmpIDType) = " " Then
                            Place2 = 2
                            Str02 = Str02 & "0" & PP
                            Place2 = 3
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            'T"
                            Place2 = 4
                            Str02 = Str02 & "1" & PP
                            Place2 = 5
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            'A
                            Place2 = 6
                            Str02 = Str02 & "2" & PP
                            Place2 = 7
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            'F
                            Place2 = 8
                            Str02 = Str02 & "3" & PP
                            Place2 = 9

                        End If

                        Place2 = "x1"



                        '45
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_LifeInsurance)), 15) & PP
                        Place2 = "x2"
                        '46
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_TaxableFromOther)), 15) & PP
                        Place2 = "x3"
                        '47
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_NonTaxable)), 15) & PP
                        Place2 = "x4"
                        '48
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_Syntaksiodotika)), 15) & PP
                        Place2 = "x5"
                        '49
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_MiwsiApolavon)), 15) & PP
                        Place2 = "x6"
                        '50
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_WidowOrphans)), 15) & PP
                        Place2 = "x7"
                        '51
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PensionFund)), 15) & PP
                        Place2 = "x8"

                        '#2019 GESY
                        '52
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withSI)), 15) & PP
                        Place2 = "x9"
                        '53
                        Dim BIK_WithoutSI As Double = 0
                        Dim DirectorFees As Double = 0

                        BIK_WithoutSI = DbNullToDouble(.Item(C_BIK_withoutSI))
                        DirectorFees = DbNullToDouble(.Item(C_DirectorFees))
                        Dim AB As Double = BIK_WithoutSI '+ DirectorFees
                        'Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withoutSI)), 15) & PP
                        Str02 = Str02 & FixNumber(AB, 15) & PP
                        Place2 = "x10"
                        '54
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoSI)), 15) & PP
                        Place2 = "x11"
                        '55
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKDed)), 15) & PP
                        Place2 = "x12"
                        '56
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKCon)), 15) & PP
                        Place2 = "x13"
                        '57
                        Str02 = Str02 & DbNullToString(.Item(C_EmpType)) & PP
                        Place2 = "x14"
                        '58
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_DirectorFees)), 15) & PP
                        '59
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PrivatePensionFund)), 15) & PP
                        '60
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PrivateMedicalFund)), 15) & PP
                        '61
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_GrossEarnings)), 15) & PP
                        '62
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_SIDed)), 15) & PP
                        '63
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_PFFund)), 15) & PP
                        '64
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_LifeIns)), 15) & PP
                        '65
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Discounts)), 15) & PP
                        '66
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Medical)), 15) & PP
                        '67
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_PensionFund)), 15) & PP
                        '68
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_UnionDed)), 15) & PP
                        '69
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PREV_Gesi)), 15) & PP
                        '70
                        Str02 = Str02 & DbNullToString(.Item(C_Email)) & PP
                        '71
                        Str02 = Str02 & DbNullToString(.Item(C_LWBPensioner)) & PP
                        '72
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_NotionalAmount)), 15) & PP
                        '73
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_NotionalTax)), 15)





                    End With
                    Str02 = Replace(Str02, "&", " ")
                    Place = "lines before write " & i
                    Place2 = "x15"
                    Place4 = Str02
                    WriteToIR7File(Str02)

                    Place2 = "x16"

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox(index)
            MsgBox(Place)
            MsgBox(Place2)
            MsgBox(Place3)
            MsgBox(Place4)
            Flag = False
        End Try
        Return Flag
    End Function




    'Private Function CreateIR7File_2018_SaveToTable(ByVal Ds As DataSet) As Boolean

    '    Dim Flag As Boolean = True
    '    Try


    '        Dim C_EmpLastName As Integer = 0
    '        Dim C_EmpFirstName As Integer = 1
    '        Dim C_EmpName As Integer = 2
    '        Dim C_EmpTaxID As Integer = 3
    '        Dim C_EmpIDType As Integer = 4
    '        Dim C_EmpIDCard As Integer = 5
    '        Dim C_Local As Integer = 6
    '        Dim C_Abroad As Integer = 7
    '        Dim C_Allowances As Integer = 8
    '        Dim C_Total456 As Integer = 9
    '        Dim C_SI As Integer = 10
    '        Dim C_PF As Integer = 11
    '        Dim C_MF As Integer = 12
    '        Dim C_UNION As Integer = 13
    '        Dim C_OtherDisc As Integer = 14
    '        Dim C_TotalDisc As Integer = 15
    '        Dim C_Taxable As Integer = 16
    '        Dim C_IT As Integer = 17
    '        Dim C_StartDate As Integer = 18
    '        Dim C_LeaveDate As Integer = 19
    '        Dim C_Adr1 As Integer = 20
    '        Dim C_Adr2 As Integer = 21
    '        Dim C_Adr3 As Integer = 22
    '        Dim C_PostCode As Integer = 23
    '        Dim C_PensionNo As Integer = 24
    '        Dim C_PensionType As Integer = 25
    '        Dim C_EmpSINo As Integer = 26
    '        Dim C_EmpCode As Integer = 27
    '        Dim C_EmpSpecialTaxDed As Integer = 28
    '        Dim C_EmpSpecialTaxCon As Integer = 29
    '        Dim C_SalaryPeriods As Integer = 30

    '        Dim C_LifeInsurance As Integer = 31

    '        Dim C_AllowanceBenefits As Integer = 32
    '        Dim C_TaxableFromOther As Integer = 33
    '        Dim C_NonTaxable As Integer = 34
    '        Dim C_Syntaksiodotika As Integer = 35
    '        Dim C_MiwsiApolavon As Integer = 36
    '        Dim C_WidowOrphans As Integer = 37
    '        Dim C_PensionFund As Integer = 38
    '        '#2019
    '        Dim C_BIK_withSI As Integer = 39
    '        Dim C_BIK_withoutSI As Integer = 40
    '        'Include them in Total epr7m3t0r4c1
    '        'end of #2019
    '        Dim C_GESYtoSI As Integer = 41
    '        Dim C_GESYtoBIKDed As Integer = 42
    '        Dim C_GESYtoBIKCon As Integer = 43
    '        Dim C_EmpType As Integer = 44





    '        Dim LastName As String
    '        Dim FirstName As String
    '        Dim Adr1 As String
    '        Dim Adr2 As String
    '        Dim PostCode As String
    '        Dim EmpTaxID As String

    '        Dim TOTAL_Local As Integer = 0
    '        Dim TOTAL_Abroad As Integer = 0
    '        Dim TOTAL_Allowances As Integer = 0
    '        Dim TOTAL_Total456 As Integer = 0
    '        Dim TOTAL_SI As Integer = 0
    '        Dim TOTAL_PF As Integer = 0
    '        Dim TOTAL_MF As Integer = 0
    '        Dim TOTAL_UNION As Integer = 0
    '        Dim TOTAL_OtherDisc As Integer = 0
    '        Dim TOTAL_TotalDisc As Integer = 0
    '        Dim TOTAL_Taxable As Integer = 0
    '        Dim TOTAL_IT As Double = 0
    '        Dim TOTAL_SpecialTax As Double = 0
    '        Dim TOTAL_SPDeduction As Double = 0
    '        Dim TOTAL_SPContribution As Double = 0
    '        Dim TOTAL_LifeInsurance As Double = 0

    '        Dim TOTAL_AllowanceBenefits As Double = 0
    '        Dim TOTAL_TaxableFromOther As Double = 0
    '        Dim TOTAL_NonTaxable As Double = 0
    '        Dim TOTAL_Syntaksiodotika As Double = 0
    '        Dim TOTAL_MiwsiApolavon As Double = 0
    '        Dim TOTAL_WidowOrphans As Double = 0
    '        Dim TOTAL_PensionFund As Double = 0

    '        Dim TOTAL_BIKWithSI As Double = 0
    '        Dim TOTAL_BIKWithoutSI As Double = 0
    '        Dim TOTAL_GESYtoSI As Double = 0
    '        Dim TOTAL_GESYDed As Double = 0
    '        Dim TOTAL_GESYCon As Double = 0



    '        Dim Str03 As String = ""

    '        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
    '        Dim CompanyName As String
    '        Dim ComAdr1 As String
    '        Dim ComAdr2 As String
    '        Dim ComPost As String

    '        Dim TIC1 As String = ""
    '        Dim TIC2 As String = ""
    '        Dim TIC3 As String = ""
    '        Dim TIC4 As String = ""


    '        InitFile = True
    '        Dim i As Integer
    '        If CheckDataSet(Ds) Then
    '            'GET TOTALS
    '            For i = 0 To Ds.Tables(0).Rows.Count - 1
    '                With Ds.Tables(0).Rows(i)
    '                    TOTAL_Local = TOTAL_Local + .Item(C_Local)
    '                    TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
    '                    TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
    '                    TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
    '                    TOTAL_SI = TOTAL_SI + .Item(C_SI)
    '                    TOTAL_PF = TOTAL_PF + .Item(C_PF)
    '                    TOTAL_MF = TOTAL_MF + .Item(C_MF)
    '                    TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
    '                    TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
    '                    TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
    '                    TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
    '                    TOTAL_IT = TOTAL_IT + .Item(C_IT)
    '                    TOTAL_SpecialTax = TOTAL_SpecialTax + .Item(C_EmpSpecialTaxDed) + .Item(C_EmpSpecialTaxCon)
    '                    TOTAL_SPDeduction = TOTAL_SPDeduction + .Item(C_EmpSpecialTaxDed)
    '                    TOTAL_SPContribution = TOTAL_SPContribution + .Item(C_EmpSpecialTaxCon)
    '                    TOTAL_LifeInsurance = TOTAL_LifeInsurance + .Item(C_LifeInsurance)

    '                    TOTAL_AllowanceBenefits = TOTAL_AllowanceBenefits + DbNullToDouble(.Item(C_AllowanceBenefits))
    '                    TOTAL_TaxableFromOther = TOTAL_TaxableFromOther + DbNullToDouble(.Item(C_TaxableFromOther))
    '                    TOTAL_NonTaxable = TOTAL_NonTaxable + DbNullToDouble(.Item(C_NonTaxable))
    '                    TOTAL_Syntaksiodotika = TOTAL_Syntaksiodotika + DbNullToDouble(.Item(C_Syntaksiodotika))
    '                    TOTAL_MiwsiApolavon = TOTAL_MiwsiApolavon + DbNullToDouble(.Item(C_MiwsiApolavon))
    '                    TOTAL_WidowOrphans = TOTAL_WidowOrphans + DbNullToDouble(.Item(C_WidowOrphans))
    '                    TOTAL_PensionFund = TOTAL_PensionFund + DbNullToDouble(.Item(C_PensionFund))

    '                    TOTAL_BIKWithSI = TOTAL_BIKWithSI + .Item(C_BIK_withSI)
    '                    TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + .Item(C_BIK_withoutSI)
    '                    TOTAL_GESYtoSI = TOTAL_GESYtoSI + .Item(C_GESYtoSI)
    '                    TOTAL_GESYDed = TOTAL_GESYDed + .Item(C_GESYtoBIKDed)
    '                    TOTAL_GESYCon = TOTAL_GESYCon + .Item(C_GESYtoBIKCon)

    '                End With
    '            Next




    '            Dim Str02 As String
    '            For i = 0 To Ds.Tables(0).Rows.Count - 1
    '                Dim YEAR As String
    '                YEAR = Ds.Tables(2).Rows(0).Item(0)

    '                Dim Ir7 As New cIR7
    '                With Ds.Tables(0).Rows(i)
    '                    '1
    '                    Ir7.myType = 2
    '                    '2
    '                    Ir7.EmpCode = Ds.Tables(2).Rows(0).Item(0)
    '                    '3

    '                    If .Item(C_EmpIDType) = " " Then
    '                        EmpTaxID = .Item(C_EmpTaxID)
    '                        Ir7.TICNumber = EmpTaxID.PadLeft(9, " ")
    '                    Else
    '                        Ir7.TICNumber = "".PadLeft(9, " ")
    '                    End If

    '                    If .Item(C_EmpIDType) <> " " Then
    '                        '4
    '                        Ir7.ArithmosTaftopoiisis = .Item(C_EmpIDType)
    '                        '5
    '                        Ir7.OtherCountryTIC = .Item(C_EmpIDCard).ToString.PadRight(15)
    '                    Else
    '                        '4
    '                        Ir7.ArithmosTaftopoiisis = " "
    '                        '5
    '                        Ir7.OtherCountryTIC = "".PadLeft(15, " ")
    '                    End If
    '                    '6
    '                    Ir7.SINumber = .Item(C_EmpSINo).Padright(15, " ")

    '                    LastName = .Item(C_EmpLastName)
    '                    If LastName.Length > 35 Then
    '                        LastName = LastName.Substring(0, 34)
    '                    End If
    '                    '7
    '                    Ir7.Surname = LastName.PadRight(35, " ")
    '                    '8
    '                    FirstName = .Item(C_EmpFirstName)
    '                    If FirstName.Length > 25 Then
    '                        FirstName = FirstName.Substring(0, 24)
    '                    End If
    '                    Ir7.Name = FirstName.PadRight(25, " ")
    '                    '9
    '                    Adr1 = .Item(C_Adr1)
    '                    If Adr1.Length > 35 Then
    '                        Adr1 = Adr1.Substring(0, 34)
    '                    End If
    '                    Ir7.Street = Adr1.PadRight(35, " ")
    '                    '10
    '                    Adr2 = .Item(C_Adr2)
    '                    If Adr2.Length > 30 Then
    '                        Adr2 = Adr2.Substring(0, 29)
    '                    End If
    '                    Ir7.Village = Adr2.PadRight(30, " ")
    '                    '11
    '                    PostCode = .Item(C_PostCode)
    '                    If PostCode.Length > 10 Then
    '                        PostCode = PostCode.Substring(0, 10)
    '                    End If
    '                    Ir7.PostCode = PostCode.PadRight(10, " ")
    '                    '12
    '                    Ir7.EmployeeType = FixInteger((i + 1), 5)
    '                    '13
    '                    Ir7.Gross = FixInteger(.Item(C_Local), 10)
    '                    '14
    '                    Ir7.GrossOut = FixInteger(.Item(C_Abroad), 9)
    '                    '15
    '                    'Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
    '                    '16
    '                    Ir7.Total1234 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
    '                    '17
    '                    Ir7.SIFund = FixInteger(.Item(C_SI), 9)
    '                    '18
    '                    Ir7.PensionFund = FixInteger(.Item(C_PF), 9)
    '                    '19
    '                    Ir7.MedicalFund = FixInteger(.Item(C_MF), 9)
    '                    '20
    '                    Ir7.Unions = FixInteger(.Item(C_UNION), 9)
    '                    '21
    '                    Ir7.OtherDiscs = FixInteger(.Item(C_OtherDisc), 9)
    '                    '22
    '                    Ir7.TotalDiscs = FixInteger(.Item(C_TotalDisc), 9)
    '                    '23
    '                    Ir7.TaxableIncome = FixInteger(.Item(C_Taxable), 10)
    '                    '24
    '                    Ir7.IncomeTAX = FixNumber(.Item(C_IT), 11)
    '                    '25   2011
    '                    'Str02 = Str02 & FixNumber(0, 11) & PP
    '                    '26   2011
    '                    'Str02 = Str02 & FixNumber(0, 11) & PP

    '                    '27
    '                    If Trim(Trim(.Item(C_StartDate))) <> "" Then
    '                        Dim yyyy As String
    '                        Dim mm As String
    '                        Dim dd As String
    '                        Dim Ar() As String

    '                        Ar = DbNullToString(.Item(C_StartDate)).Split("/")
    '                        Dim D As String
    '                        D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

    '                        If Ar(2) <> YEAR Then
    '                            Ir7.StartDate = "        "
    '                        Else
    '                            Ir7.StartDate = D
    '                        End If
    '                    Else
    '                        Ir7.StartDate = "        "
    '                    End If
    '                    '28
    '                    If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
    '                        Dim yyyy As String
    '                        Dim mm As String
    '                        Dim dd As String
    '                        Dim Ar() As String
    '                        Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
    '                        Dim D As String
    '                        D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
    '                        If Ar(2) <> Year() Then
    '                            Ir7.TermDate = "        "
    '                        Else
    '                            Ir7.TermDate = D
    '                        End If

    '                    Else
    '                        Ir7.TermDate = "        "
    '                    End If

    '                    Dim PensionNo As String
    '                    Dim PensionType As String
    '                    PensionNo = DbNullToString(.Item(C_PensionNo))
    '                    PensionType = DbNullToString(.Item(C_PensionType))
    '                    ''29
    '                    'Str02 = Str02 & "".PadLeft(11, " ") & PP
    '                    ''30
    '                    'Str02 = Str02 & "".PadLeft(11, " ") & PP
    '                    ''31
    '                    'Str02 = Str02 & "".PadLeft(11, " ") & PP
    '                    ''32
    '                    'Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    ''33
    '                    'Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    ''34
    '                    'Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    ''35
    '                    'Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    ''36
    '                    'Str02 = Str02 & "".PadLeft(1, " ") & PP
    '                    ''37
    '                    'Str02 = Str02 & "".PadLeft(1, " ") & PP
    '                    ''38
    '                    'Str02 = Str02 & "".PadLeft(1, " ") & PP
    '                    ''39
    '                    Ir7.PensionNo = PensionNo.PadLeft(7, "0")
    '                    '40
    '                    'Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
    '                    '41
    '                    'Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 11) & PP
    '                    '42
    '                    'Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 11) & PP
    '                    '43
    '                    ' If .Item(C_SalaryPeriods) > 13 Then
    '                    '.Item(C_SalaryPeriods) = 13
    '                    'End If
    '                    'Str02 = Str02 & .Item(C_SalaryPeriods) & PP

    '                    '44
    '                    If .Item(C_EmpIDType) = " " Then
    '                        Ir7.ArithmosTaftopoiisis = "0"
    '                    ElseIf .Item(C_EmpIDType) = "Ô" Then
    '                        ir7.ArithmosTaftopoiisis= "1" & 
    '                    ElseIf .Item(C_EmpIDType) = "Á" Then
    '                        Ir7.ArithmosTaftopoiisis = "2"
    '                    ElseIf .Item(C_EmpIDType) = "Ö" Then
    '                        Ir7.ArithmosTaftopoiisis = "3"
    '                    End If


    '                    '45
    '                    Ir7.LifeInsurance = FixInteger(.Item(C_LifeInsurance), 11)

    '                    '46
    '                    Ir7.taxaStr02 = Str02 & FixInteger(DbNullToInt(.Item(C_TaxableFromOther)), 11) & PP
    '                    '47
    '                    Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_NonTaxable)), 11) & PP
    '                    '48
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_Syntaksiodotika)), 11) & PP
    '                    '49
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_MiwsiApolavon)), 11) & PP
    '                    '50
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_WidowOrphans)), 11) & PP
    '                    '51
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PensionFund)), 11) & PP

    '                    '#2019 GESY
    '                    '52
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withSI)), 11) & PP
    '                    '53
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_BIK_withoutSI)), 11) & PP
    '                    '54
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoSI)), 11) & PP
    '                    '55
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKDed)), 11) & PP
    '                    '56
    '                    Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_GESYtoBIKCon)), 11) & PP
    '                    '57
    '                    Str02 = Str02 & DbNullToString(.Item(C_EmpType))


    '                End With
    '                Str02 = Replace(Str02, "&", " ")
    '                WriteToIR7File(Str02)

    '            Next
    '        End If
    '    Catch ex As Exception
    '        Utils.ShowException(ex)
    '        Flag = False
    '    End Try
    '    Return Flag
    'End Function
    'Private Function CreateIR7File_2018(ByVal Ds As DataSet) As Boolean

    '    Dim Flag As Boolean = True
    '    Try

    '        Dim PP As String = "|"

    '        Dim C_EmpLastName As Integer = 0
    '        Dim C_EmpFirstName As Integer = 1
    '        Dim C_EmpName As Integer = 2
    '        Dim C_EmpTaxID As Integer = 3
    '        Dim C_EmpIDType As Integer = 4
    '        Dim C_EmpIDCard As Integer = 5
    '        Dim C_Local As Integer = 6
    '        Dim C_Abroad As Integer = 7
    '        Dim C_Allowances As Integer = 8
    '        Dim C_Total456 As Integer = 9
    '        Dim C_SI As Integer = 10
    '        Dim C_PF As Integer = 11
    '        Dim C_MF As Integer = 12
    '        Dim C_UNION As Integer = 13
    '        Dim C_OtherDisc As Integer = 14
    '        Dim C_TotalDisc As Integer = 15
    '        Dim C_Taxable As Integer = 16
    '        Dim C_IT As Integer = 17
    '        Dim C_StartDate As Integer = 18
    '        Dim C_LeaveDate As Integer = 19
    '        Dim C_Adr1 As Integer = 20
    '        Dim C_Adr2 As Integer = 21
    '        Dim C_Adr3 As Integer = 22
    '        Dim C_PostCode As Integer = 23
    '        Dim C_PensionNo As Integer = 24
    '        Dim C_PensionType As Integer = 25
    '        Dim C_EmpSINo As Integer = 26

    '        Dim C_EmpCode As Integer = 27
    '        Dim C_STDeduction As Integer = 28
    '        Dim C_STContribution As Integer = 29
    '        Dim C_salaryPeriods As Integer = 30
    '        Dim C_LifeInsurance As Integer = 31

    '        Dim C_AllowancesBenefits As Integer = 32
    '        Dim C_TaxableFromOther As Integer = 33
    '        Dim C_NonTaxableIncome As Integer = 34

    '        Dim C_SyntaksiodotikaOfelimata As Integer = 35
    '        Dim C_MeiwsiApolavon As Integer = 36
    '        Dim C_WidowAndOrphans As Integer = 37
    '        Dim C_Pensionfund As Integer = 38

    '        '#2019
    '        Dim C_BIK_withSI As Integer = 39
    '        Dim C_BIK_withoutSI As Integer = 40
    '        'Include them in Total epr7m3t0r4c1
    '        'end of #2019
    '        Dim C_GESYtoSI As Integer = 41
    '        Dim C_GESYtoBIKDed As Integer = 42
    '        Dim C_GESYtoBIKCon As Integer = 43



    '        Dim LastName As String
    '        Dim FirstName As String
    '        Dim Adr1 As String
    '        Dim Adr2 As String
    '        Dim PostCode As String
    '        Dim EmpTaxID As String

    '        Dim TOTAL_Local As Integer = 0
    '        Dim TOTAL_Abroad As Integer = 0
    '        Dim TOTAL_Allowances As Integer = 0
    '        Dim TOTAL_Total456 As Integer = 0
    '        Dim TOTAL_SI As Integer = 0
    '        Dim TOTAL_PF As Integer = 0
    '        Dim TOTAL_MF As Integer = 0
    '        Dim TOTAL_UNION As Integer = 0
    '        Dim TOTAL_OtherDisc As Integer = 0
    '        Dim TOTAL_TotalDisc As Integer = 0
    '        Dim TOTAL_Taxable As Integer = 0
    '        Dim TOTAL_IT As Double = 0

    '        Dim TOTAL_MeiwsiApolavonkaiSyntakswon As Double = 0
    '        Dim TOTAL_SyntaksiodotikaOfelimata As Double = 0
    '        Dim TOTAL_WidowAndOrphans As Double = 0
    '        Dim TOTAL_PensionFund As Double = 0

    '        Dim TOTAL_BIKWithSI As Double = 0
    '        Dim TOTAL_BIKWithoutSI As Double = 0
    '        Dim TOTAL_GESYtoSI As Double = 0
    '        Dim TOTAL_GESYDed As Double = 0
    '        Dim TOTAL_GESYCon As Double = 0


    '        Dim Str03 As String = ""

    '        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
    '        Dim CompanyName As String
    '        Dim ComAdr1 As String
    '        Dim ComAdr2 As String
    '        Dim ComPost As String

    '        Dim TIC1 As String = ""
    '        Dim TIC2 As String = ""
    '        Dim TIC3 As String = ""
    '        Dim TIC4 As String = ""


    '        InitFile = True
    '        Dim i As Integer
    '        If CheckDataSet(Ds) Then
    '            'GET TOTALS
    '            For i = 0 To Ds.Tables(0).Rows.Count - 1
    '                With Ds.Tables(0).Rows(i)
    '                    TOTAL_Local = TOTAL_Local + .Item(C_Local)
    '                    TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
    '                    TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
    '                    TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
    '                    TOTAL_SI = TOTAL_SI + .Item(C_SI)
    '                    TOTAL_PF = TOTAL_PF + .Item(C_PF)
    '                    TOTAL_MF = TOTAL_MF + .Item(C_MF)
    '                    TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
    '                    TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
    '                    TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
    '                    TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
    '                    TOTAL_IT = TOTAL_IT + .Item(C_IT)

    '                    TOTAL_SyntaksiodotikaOfelimata = TOTAL_SyntaksiodotikaOfelimata + .Item(C_SyntaksiodotikaOfelimata)
    '                    TOTAL_MeiwsiApolavonkaiSyntakswon = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_MeiwsiApolavon)
    '                    TOTAL_WidowAndOrphans = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_WidowAndOrphans)
    '                    TOTAL_PensionFund = TOTAL_MeiwsiApolavonkaiSyntakswon + .Item(C_Pensionfund)


    '                    TOTAL_BIKWithSI = TOTAL_BIKWithSI + .Item(C_BIK_withSI)
    '                    TOTAL_BIKWithoutSI = TOTAL_BIKWithoutSI + .Item(C_BIK_withoutSI)
    '                    TOTAL_GESYtoSI = TOTAL_GESYtoSI + .Item(C_GESYtoSI)
    '                    TOTAL_GESYDed = TOTAL_GESYDed + .Item(C_GESYtoBIKDed)
    '                    TOTAL_GESYCon = TOTAL_GESYCon + .Item(C_GESYtoBIKCon)

    '                End With
    '            Next
    '            '---------------------------------------------
    '            'RECORD 01
    '            '---------------------------------------------
    '            '1
    '            Str03 = 1 & PP
    '            '2
    '            Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
    '            Dim YEAR As String
    '            YEAR = Ds.Tables(2).Rows(0).Item(0)

    '            '3
    '            If Company.TaxCard = "" Then
    '                MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
    '                Exit Function
    '            End If
    '            Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

    '            '4
    '            Str03 = Str03 & " " & PP
    '            '5
    '            'Str03 = Str03 & " ".PadLeft(9, " ")
    '            Str03 = Str03 & " ".PadLeft(15, " ") & PP
    '            '6
    '            Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
    '            '7
    '            CompanyName = Company.Name
    '            If CompanyName.Length > 35 Then
    '                CompanyName = CompanyName.Substring(0, 34)
    '            End If
    '            Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
    '            '8
    '            Str03 = Str03 & "".PadRight(25, " ") & PP
    '            '9
    '            ComAdr1 = Company.Address1
    '            If ComAdr1.Length > 35 Then
    '                ComAdr1 = ComAdr1.Substring(0, 34)
    '            End If
    '            Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
    '            '10
    '            ComAdr2 = Company.Address2
    '            If ComAdr2.Length > 30 Then
    '                ComAdr2 = ComAdr2.Substring(0, 29)
    '            End If
    '            Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
    '            '11
    '            ComPost = Company.Address3
    '            If ComPost.Length > 10 Then
    '                ComPost = ComPost.Substring(0, 10)
    '            End If
    '            Str03 = Str03 & ComPost.PadRight(10, " ") & PP
    '            '12
    '            Str03 = Str03 & FixInteger((i), 5) & PP
    '            '13
    '            Str03 = Str03 & FixInteger(TOTAL_Local, 10) & PP
    '            '14
    '            Str03 = Str03 & FixInteger(TOTAL_Abroad, 9) & PP
    '            '15
    '            Str03 = Str03 & FixInteger(TOTAL_Allowances, 9) & PP
    '            '16
    '            Str03 = Str03 & FixInteger(TOTAL_Total456, 10) & PP
    '            '17
    '            Str03 = Str03 & FixInteger(TOTAL_SI, 9) & PP
    '            '18
    '            Str03 = Str03 & FixInteger(TOTAL_PF, 9) & PP
    '            '19
    '            Str03 = Str03 & FixInteger(TOTAL_MF, 9) & PP
    '            '20
    '            Str03 = Str03 & FixInteger(TOTAL_UNION, 9) & PP
    '            '21
    '            Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9) & PP
    '            '22
    '            Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9) & PP
    '            '23
    '            Str03 = Str03 & FixInteger(TOTAL_Taxable, 10) & PP
    '            '24
    '            Str03 = Str03 & FixNumber(TOTAL_IT, 11) & PP
    '            '25
    '            Str03 = Str03 & FixNumber(0, 11) & PP
    '            '26
    '            Str03 = Str03 & FixNumber(0, 11) & PP
    '            '27
    '            'Str03 = Str03 & "00000000"
    '            Str03 = Str03 & "        " & PP
    '            '28
    '            'Str03 = Str03 & "00000000"
    '            Str03 = Str03 & "        " & PP
    '            '29
    '            Str03 = Str03 & FixNumber(TaxGiven, 11) & PP
    '            '30
    '            Str03 = Str03 & FixNumber(0, 11) & PP
    '            '31
    '            Str03 = Str03 & FixNumber(0, 11) & PP

    '            If Company.AccIdentity = 1 Then
    '                TIC1 = Company.AccountantTIC
    '            ElseIf Company.AccIdentity = 2 Then
    '                TIC2 = Company.AccountantTIC
    '            ElseIf Company.AccIdentity = 3 Then
    '                TIC3 = Company.AccountantTIC
    '            ElseIf Company.AccIdentity = 4 Then
    '                TIC4 = Company.AccountantTIC
    '            End If
    '            TIC4 = Company.AccountantTIC
    '            '32
    '            Str03 = Str03 & TIC1.PadRight(9, " ") & PP
    '            '33
    '            Str03 = Str03 & TIC2.PadRight(9, " ") & PP
    '            '34
    '            Str03 = Str03 & TIC3.PadRight(9, " ") & PP
    '            '35
    '            Str03 = Str03 & TIC4.PadRight(9, " ") & PP
    '            '36
    '            Str03 = Str03 & Company.AccIdentity & PP
    '            '37
    '            Str03 = Str03 & Company.TICCategory & PP
    '            '38
    '            Str03 = Str03 & Company.TICType & PP
    '            '39
    '            Str03 = Str03 & "0".PadLeft(7, "0") & PP
    '            '40
    '            Str03 = Str03 & Original & PP
    '            '41
    '            Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 11) & PP
    '            '42
    '            Str03 = Str03 & FixNumber(TOTAL_SPContribution, 11) & PP
    '            '43
    '            Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 11) & PP

    '            a()
    '            '44
    '            Str03 = Str03 & Company.AccountantTitle & PP
    '            '45
    '            Str03 = Str03 & Company.AccountantTIC & PP
    '            '46
    '            Str03 = Str03 & FixInteger(TOTAL_LifeInsurance, 11) & PP
    '            '47
    '            Str03 = Str03 & FixInteger(TOTAL_AllowanceBenefits, 11) & PP
    '            '48
    '            Str03 = Str03 & FixInteger(TOTAL_TaxableFromOther, 11) & PP
    '            '49
    '            Str03 = Str03 & FixInteger(TOTAL_NonTaxable, 11) & PP
    '            '50
    '            Str03 = Str03 & FixNumber(TOTAL_Syntaksiodotika, 11) & PP
    '            '51
    '            Str03 = Str03 & FixNumber(TOTAL_MiwsiApolavon, 11) & PP
    '            '52
    '            Str03 = Str03 & FixNumber(TOTAL_WidowOrphans, 11) & PP
    '            '53
    '            Str03 = Str03 & FixNumber(TOTAL_PensionFund, 11) & PP
    '            '''

    '            '41
    '            Str03 = Str03 & TOTAL_SyntaksiodotikaOfelimata & PP
    '            '42
    '            Str03 = Str03 & TOTAL_MeiwsiApolavonkaiSyntakswon & PP
    '            '43
    '            Str03 = Str03 & TOTAL_WidowAndOrphans & PP
    '            '44
    '            Str03 = Str03 & TOTAL_PensionFund & PP
    '            '45
    '            Str03 = Str03 & TOTAL_BIKWithSI & PP
    '            '46
    '            Str03 = Str03 & TOTAL_BIKWithoutSI & PP
    '            '47
    '            Str03 = Str03 & TOTAL_GESYtoSI & PP
    '            '48
    '            Str03 = Str03 & TOTAL_GESYDed & PP
    '            '49
    '            Str03 = Str03 & TOTAL_GESYCon & PP


    '            Str03 = Replace(Str03, "&", " ") & PP
    '            WriteToIR7File(Str03)

    '            '---------------------------------------------
    '            'END OF 01
    '            '---------------------------------------------


    '            Dim Str02 As String
    '            For i = 0 To Ds.Tables(0).Rows.Count - 1

    '                With Ds.Tables(0).Rows(i)
    '                    '1
    '                    Str02 = 2 & PP
    '                    '2
    '                    Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
    '                    '3
    '                    ' Dim xx As String
    '                    ' xx = .Item(C_EmpIDType)
    '                    If .Item(C_EmpIDType) = " " Then
    '                        EmpTaxID = .Item(C_EmpTaxID)
    '                        Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP
    '                    Else
    '                        Str02 = Str02 & "".PadLeft(9, " ") & PP

    '                    End If

    '                    If .Item(C_EmpIDType) <> " " Then
    '                        '4
    '                        Str02 = Str02 & .Item(C_EmpIDType) & PP
    '                        '5
    '                        Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP
    '                    Else
    '                        '4
    '                        Str02 = Str02 & " " & PP
    '                        '5
    '                        Str02 = Str02 & "".PadLeft(15, " ") & PP
    '                    End If
    '                    '6
    '                    Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


    '                    LastName = .Item(C_EmpLastName)
    '                    If LastName.Length > 35 Then
    '                        LastName = LastName.Substring(0, 34)
    '                    End If
    '                    '7
    '                    Str02 = Str02 & LastName.PadRight(35, " ") & PP
    '                    '8
    '                    FirstName = .Item(C_EmpFirstName)
    '                    If FirstName.Length > 25 Then
    '                        FirstName = FirstName.Substring(0, 24)
    '                    End If
    '                    Str02 = Str02 & FirstName.PadRight(25, " ") & PP
    '                    '9
    '                    Adr1 = .Item(C_Adr1)
    '                    If Adr1.Length > 35 Then
    '                        Adr1 = Adr1.Substring(0, 34)
    '                    End If
    '                    Str02 = Str02 & Adr1.PadRight(35, " ") & PP
    '                    '10
    '                    Adr2 = .Item(C_Adr2)
    '                    If Adr2.Length > 30 Then
    '                        Adr2 = Adr2.Substring(0, 29)
    '                    End If
    '                    Str02 = Str02 & Adr2.PadRight(30, " ") & PP
    '                    '11
    '                    PostCode = .Item(C_PostCode)
    '                    If PostCode.Length > 10 Then
    '                        PostCode = PostCode.Substring(0, 10)
    '                    End If
    '                    Str02 = Str02 & PostCode.PadRight(10, " ") & PP
    '                    '12
    '                    Str02 = Str02 & FixInteger((i + 1), 5) & PP
    '                    '13
    '                    Str02 = Str02 & FixInteger(.Item(C_Local), 10) & PP
    '                    '14
    '                    Str02 = Str02 & FixInteger(.Item(C_Abroad), 9) & PP
    '                    '15

    '                    Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
    '                    '16
    '                    Str02 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
    '                    '17
    '                    Str02 = Str02 & FixInteger(.Item(C_SI), 9) & PP
    '                    '18
    '                    Str02 = Str02 & FixInteger(.Item(C_PF), 9) & PP
    '                    '19
    '                    Str02 = Str02 & FixInteger(.Item(C_MF), 9) & PP
    '                    '20
    '                    Str02 = Str02 & FixInteger(.Item(C_UNION), 9) & PP
    '                    '21
    '                    Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9) & PP
    '                    '22
    '                    Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9) & PP
    '                    '23
    '                    Str02 = Str02 & FixInteger(.Item(C_Taxable), 10) & PP
    '                    '24
    '                    Str02 = Str02 & FixNumber(.Item(C_IT), 11) & PP
    '                    '25   2011
    '                    Str02 = Str02 & FixNumber(0, 11) & PP
    '                    '26   2011
    '                    Str02 = Str02 & FixNumber(0, 11) & PP

    '                    '27
    '                    If .Item(C_StartDate) <> "" Then
    '                        Dim yyyy As String
    '                        Dim mm As String
    '                        Dim dd As String
    '                        Dim Ar() As String

    '                        Ar = DbNullToString(.Item(C_StartDate)).Split("/")
    '                        Dim D As String
    '                        D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

    '                        If Ar(2) <> YEAR Then
    '                            Str02 = Str02 & "        " & PP
    '                        Else
    '                            Str02 = Str02 & D & PP
    '                        End If
    '                    Else
    '                        Str02 = Str02 & "        " & PP
    '                    End If
    '                    '28
    '                    If .Item(C_LeaveDate) <> "" Then
    '                        Dim yyyy As String
    '                        Dim mm As String
    '                        Dim dd As String
    '                        Dim Ar() As String
    '                        Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
    '                        Dim D As String
    '                        D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
    '                        If Ar(2) <> YEAR Then
    '                            Str02 = Str02 & "        " & PP
    '                        Else
    '                            Str02 = Str02 & D & PP
    '                        End If

    '                    Else
    '                        Str02 = Str02 & "        " & PP
    '                    End If

    '                    Dim PensionNo As String
    '                    Dim PensionType As String
    '                    PensionNo = DbNullToString(.Item(C_PensionNo))
    '                    PensionType = DbNullToString(.Item(C_PensionType))
    '                    '29
    '                    Str02 = Str02 & "".PadLeft(11, " ") & PP
    '                    '30
    '                    Str02 = Str02 & "".PadLeft(11, " ") & PP
    '                    '31
    '                    Str02 = Str02 & "".PadLeft(11, " ") & PP
    '                    '32
    '                    Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    '33
    '                    Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    '34
    '                    Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    '35
    '                    Str02 = Str02 & "".PadLeft(9, " ") & PP
    '                    '36
    '                    Str02 = Str02 & "".PadLeft(1, " ") & PP
    '                    '37
    '                    Str02 = Str02 & "".PadLeft(1, " ") & PP
    '                    '38
    '                    Str02 = Str02 & "".PadLeft(1, " ") & PP
    '                    '39
    '                    Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
    '                    '40
    '                    Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
    '                    '41
    '                    Str02 = Str02 & FixNumber(.Item(C_SyntaksiodotikaOfelimata), 10) & PP
    '                    '42
    '                    Str02 = Str02 & FixNumber(.Item(C_MeiwsiApolavon), 10) & PP
    '                    '43
    '                    Str02 = Str02 & FixNumber(.Item(C_WidowAndOrphans), 10) & PP
    '                    '44
    '                    Str02 = Str02 & FixNumber(.Item(C_Pensionfund), 10) & PP
    '                    '45
    '                    Str02 = Str02 & FixInteger(.Item(C_BIK_withSI), 10) & PP
    '                    '46
    '                    Str02 = Str02 & FixInteger(.Item(C_BIK_withoutSI), 10) & PP
    '                    '47
    '                    Str02 = Str02 & FixNumber(.Item(C_GESYtoSI), 10) & PP
    '                    '48 
    '                    Str02 = Str02 & FixNumber(.Item(C_GESYtoBIKDed), 10) & PP
    '                    '49
    '                    Str02 = Str02 & FixInteger(.Item(C_GESYtoBIKCon), 10) & PP




    '                End With
    '                Str02 = Replace(Str02, "&", " ")
    '                WriteToIR7File(Str02)

    '            Next
    '        End If
    '    Catch ex As Exception
    '        Utils.ShowException(ex)
    '        Flag = False
    '    End Try
    '    Return Flag
    'End Function
    Private Function WriteToIR7File(ByVal Line As String) As Boolean
        Dim Flag As Boolean = True
        Dim Error1 As String
        Try
            ' Dim mFile As System.IO.File
            Error1 = "F1"
            Dim FileName As String = IR7FileDir & "\" & Ir7Filename '"IPA03ETD.DAT"
            'Dim FileName As String = IR7FileDir & "\" & "IPA03ETD.DAT"
            Dim TW As System.IO.TextWriter

            If InitFile Then
                Error1 = "F2"
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
                Error1 = "F3"
            Else
                If IO.File.Exists(FileName) Then
                    Error1 = "F4"
                    TW = System.IO.File.AppendText(FileName)
                    Error1 = "F5"
                Else
                    Error1 = "F6"
                    TW = System.IO.File.CreateText(FileName)
                    Error1 = "F7"
                End If
            End If
            With TW
                Error1 = "F8"
                .Write(Line)
                Error1 = "F9"
                .WriteLine()
                Error1 = "F10"
                .Close()
                Error1 = "F11"
                .Dispose()
                Error1 = "F12"
                GC.Collect()
                Error1 = "F13"
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox(Error1)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function WriteToIR7File_For2017(ByVal Line As String) As Boolean
        Dim Flag As Boolean = True
        Dim Error1 As String
        Try
            ' Dim mFile As System.IO.File
            Error1 = "F1"
            Dim FileName As String = IR7FileDir & "\" & "IPA03ETD.DAT"
            'Dim FileName As String = IR7FileDir & "\" & "IPA03ETD.DAT"
            Dim TW As System.IO.TextWriter

            If InitFile Then
                Error1 = "F2"
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
                Error1 = "F3"
            Else
                If IO.File.Exists(FileName) Then
                    Error1 = "F4"
                    TW = System.IO.File.AppendText(FileName)
                    Error1 = "F5"
                Else
                    Error1 = "F6"
                    TW = System.IO.File.CreateText(FileName)
                    Error1 = "F7"
                End If
            End If
            With TW
                Error1 = "F8"
                .Write(Line)
                Error1 = "F9"
                .WriteLine()
                Error1 = "F10"
                .Close()
                Error1 = "F11"
                .Dispose()
                Error1 = "F12"
                GC.Collect()
                Error1 = "F13"
            End With
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox(Error1)
            Flag = False
        End Try
        Return Flag
    End Function

    Private Function CreateIR7File_2010(ByVal Ds As DataSet) As Boolean

        Dim Flag As Boolean = True
        Try


            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26

            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0
            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + .Item(C_Local)
                        TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
                        TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
                        TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
                        TOTAL_SI = TOTAL_SI + .Item(C_SI)
                        TOTAL_PF = TOTAL_PF + .Item(C_PF)
                        TOTAL_MF = TOTAL_MF + .Item(C_MF)
                        TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
                        TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
                        TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
                        TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
                        TOTAL_IT = TOTAL_IT + .Item(C_IT)
                    End With
                Next
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '1
                Str03 = 1
                '2
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0)
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '3
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ")

                '4
                Str03 = Str03 & " "
                '5
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ")
                '6
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ")
                '7
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ")
                '8
                Str03 = Str03 & "".PadRight(25, " ")
                '9
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ")
                '10
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ")
                '11
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ")
                '12
                Str03 = Str03 & FixInteger((i), 5)
                '13
                Str03 = Str03 & FixInteger(TOTAL_Local, 10)
                '14
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9)
                '15
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9)
                '16
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10)
                '17
                Str03 = Str03 & FixInteger(TOTAL_SI, 9)
                '18
                Str03 = Str03 & FixInteger(TOTAL_PF, 9)
                '19
                Str03 = Str03 & FixInteger(TOTAL_MF, 9)
                '20
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9)
                '21
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9)
                '22
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9)
                '23
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10)
                '24
                Str03 = Str03 & FixNumber(TOTAL_IT, 11)
                '25
                'Str03 = Str03 & FixNumber(0, 11)
                '26
                'Str03 = Str03 & FixNumber(0, 11)
                '27
                Str03 = Str03 & "        "
                '28
                Str03 = Str03 & "        "
                '29
                Str03 = Str03 & FixNumber(TaxGiven, 11)
                '30
                'Str03 = Str03 & FixNumber(0, 11)
                '31
                'Str03 = Str03 & FixNumber(0, 11)

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC
                End If
                TIC4 = Company.AccountantTIC
                '32
                Str03 = Str03 & TIC1.PadRight(9, " ")
                '33
                Str03 = Str03 & TIC2.PadRight(9, " ")
                '34
                Str03 = Str03 & TIC3.PadRight(9, " ")
                '35
                Str03 = Str03 & TIC4.PadRight(9, " ")
                '36
                Str03 = Str03 & Company.AccIdentity
                '37
                Str03 = Str03 & Company.TICCategory
                '38
                Str03 = Str03 & Company.TICType
                '39
                Str03 = Str03 & "0".PadLeft(7, "0")
                '40
                Str03 = Str03 & Original

                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    'Dim k As Integer
                    'For k = -32768 To 65535
                    '    WriteToIR7File(k & "-   " & ChrW(k))
                    'Next




                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0)
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ")
                        Else
                            Str02 = Str02 & "".PadLeft(9, " ")

                        End If
                        '''
                        Dim input As Byte()
                        Dim ss As String = "x"
                        Dim encoding As New System.Text.UTF8Encoding()
                        input = encoding.GetBytes(Chr(212))



                        '''

                        Dim result As Byte() = System.Text.Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.GetEncoding("iso-8859-1"), input)


                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            If .Item(C_EmpIDType) = "Τ" Then
                                ' Dim s As String
                                ' Dim X As String = "Ô"
                                ' s = Test(x)
                                ' Str02 = Str02 & s
                                Str02 = Str02 & ChrW(1325)
                            ElseIf .Item(C_EmpIDType) = "Α" Then
                                'Dim s As String
                                'Dim X As String = "Á"
                                's = Test(X)
                                Str02 = Str02 & "Α"
                            ElseIf .Item(C_EmpIDType) = "Φ" Then
                                ' Dim s As String
                                ' Dim X As String = "Ö"
                                ' s = Test(X)
                                Str02 = Str02 & "Φ"
                            Else

                            End If

                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15)
                        Else
                            '4
                            Str02 = Str02 & " "
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ")
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ")


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ")
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Str02 = Str02 & FirstName.PadRight(25, " ")
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ")
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ")
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ")
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5)
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10)
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9)
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9)
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10)
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9)
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9)
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9)
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9)
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9)
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9)
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10)
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11)
                        '25   2011
                        'Str02 = Str02 & FixNumber(0, 11)
                        '26   2011
                        'Str02 = Str02 & FixNumber(0, 11)

                        '27
                        If .Item(C_StartDate) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        "
                            Else
                                Str02 = Str02 & D
                            End If
                        Else
                            Str02 = Str02 & "        "
                        End If
                        '28
                        If .Item(C_LeaveDate) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        "
                            Else
                                Str02 = Str02 & D
                            End If

                        Else
                            Str02 = Str02 & "        "
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ")
                        '30
                        ' Str02 = Str02 & "".PadLeft(11, " ")
                        '31
                        'Str02 = Str02 & "".PadLeft(11, " ")
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ")
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ")
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ")
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ")
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, " ")
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0")


                    End With
                    Str02 = Replace(Str02, "&", " ")
                    WriteToIR7File(Str02)

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Function Test(ByVal X As String) As String
        Dim s As String
        Dim B As Byte()
        B = Encoding.GetEncoding(1253).GetBytes(X)
        s = Encoding.GetEncoding(1253).GetString(B)
        Return s




    End Function 'Main 


    Private Sub BtnSearchEmp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchEmp1.Click
        Dim f As New FrmEmployeeSearch
        f.CalledBy = 5
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        f.TempGroup = PerGrp.TemGrpCode
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub BtnSearcEmp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearcEmp2.Click
        Dim f As New FrmEmployeeSearch
        f.CalledBy = 6
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        f.TempGroup = PerGrp.TemGrpCode
        f.Owner = Me
        f.ShowDialog()

    End Sub

   

    Private Sub MnuIR7ToScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuIR7ToScreen.Click
        IR7(False, False)
    End Sub

    Private Sub MnuIR7ToPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuIR7ToPrinter.Click
        IR7(True, False)
    End Sub

    Private Sub TSBCreateIR7File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCreateIR7File.Click
        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else
            IR7(False, True)
        End If
    End Sub

    Private Sub mnuIR61_2012_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIR61_2012.Click
        Dim F As New FrmIR61_2012
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        F.PerGroup = PerGrp
        F.TempGroupCode = PerGrp.TemGrpCode
        F.Owner = Me
        F.ShowDialog()
    End Sub

    Private Sub mnuIR61_1997_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIR61_1997.Click
        Dim F As New FrmIR61
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        F.PerGroup = PerGrp
        F.TempGroupCode = PerGrp.TemGrpCode
        F.Owner = Me
        F.ShowDialog()
    End Sub

    Private Sub CreateFile2010ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateFile2010ToolStripMenuItem.Click
        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else
            IR7_2010(False, True)
        End If
    End Sub
    Private Sub IR7_2010(ByVal SendToPrinter As Boolean, ByVal File As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet


        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        D = DateAdd(DateInterval.Year, 1, D)

        Ds = Global1.Business.REPORT_IR7_2(PerGrp, FromCode, ToCode, D)
        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                Utils.ShowReport("IR7.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then
                If CreateIR7File_2010(Ds) Then
                    MsgBox("File is Created - " & IR7FileDir & "\" & "IPA03ETD.DAT", MsgBoxStyle.Information)
                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Mnu_IR7_2012File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnu_IR7_2012File.Click
        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else
            IR7_2012(False, True, False)
        End If
    End Sub
    Private Sub IR7_2012(ByVal SendToPrinter As Boolean, ByVal File As Boolean, ByVal XMLCreation As Boolean)
        GLB_XMLOriginFile = ""
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet


        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        ' D = DateAdd(DateInterval.Year, 1, D)

        Ds = Global1.Business.REPORT_IR7_2(PerGrp, FromCode, ToCode, D)
        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                Utils.ShowReport("IR7.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then
                If CreateIR7File_2012(Ds) Then
                    If Not XMLCreation Then
                        MsgBox("File is Created - " & IR7FileDir & "IPA03ETD.DAT", MsgBoxStyle.Information)
                    End If
                    GLB_XMLOriginFile = IR7FileDir & "IPA03ETD.DAT"
                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub
    Private Function CreateIR7File_2012(ByVal Ds As DataSet) As Boolean

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30


            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + .Item(C_Local)
                        TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
                        TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
                        TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
                        TOTAL_SI = TOTAL_SI + .Item(C_SI)
                        TOTAL_PF = TOTAL_PF + .Item(C_PF)
                        TOTAL_MF = TOTAL_MF + .Item(C_MF)
                        TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
                        TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
                        TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
                        TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
                        TOTAL_IT = TOTAL_IT + .Item(C_IT)
                        TOTAL_SpecialTax = TOTAL_SpecialTax + .Item(C_EmpSpecialTaxDed) + .Item(C_EmpSpecialTaxCon)
                        TOTAL_SPDeduction = TOTAL_SPDeduction + .Item(C_EmpSpecialTaxDed)
                        TOTAL_SPContribution = TOTAL_SPContribution + .Item(C_EmpSpecialTaxCon)
                    End With
                Next
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '1
                Str03 = 1 & PP
                '2
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '3
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '4
                Str03 = Str03 & " " & PP
                '5
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '6
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '7
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '8
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '9
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '10
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '11
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '12
                Str03 = Str03 & FixInteger((i), 5) & PP
                '13
                Str03 = Str03 & FixInteger(TOTAL_Local, 10) & PP
                '14
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9) & PP
                '15
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9) & PP
                '16
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10) & PP
                '17
                Str03 = Str03 & FixInteger(TOTAL_SI, 9) & PP
                '18
                Str03 = Str03 & FixInteger(TOTAL_PF, 9) & PP
                '19
                Str03 = Str03 & FixInteger(TOTAL_MF, 9) & PP
                '20
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9) & PP
                '21
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9) & PP
                '22
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9) & PP
                '23
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10) & PP
                '24
                Str03 = Str03 & FixNumber(TOTAL_IT, 11) & PP
                '25
                Str03 = Str03 & FixNumber(0, 11) & PP
                '26
                Str03 = Str03 & FixNumber(0, 11) & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '29
                Str03 = Str03 & FixNumber(TaxGiven, 11) & PP
                '30
                Str03 = Str03 & FixNumber(0, 11) & PP
                '31
                Str03 = Str03 & FixNumber(0, 11) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC
                End If
                TIC4 = Company.AccountantTIC
                '32
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '36
                Str03 = Str03 & Company.AccIdentity & PP
                '37
                Str03 = Str03 & Company.TICCategory & PP
                '38
                Str03 = Str03 & Company.TICType & PP
                '39
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '40
                Str03 = Str03 & Original & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 11) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 11) & PP
                '43
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 11) & PP

                Str03 = Str03 & Company.AccountantTitle & PP

                Str03 = Str03 & Company.AccountantTIC & PP

                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP
                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5) & PP
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10) & PP
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9) & PP
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9) & PP
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9) & PP
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9) & PP
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9) & PP
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9) & PP
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9) & PP
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If

                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 11) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 11) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then
                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        If .Item(C_EmpIDType) = " " Then
                            Str02 = Str02 & "0" & PP
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            Str02 = Str02 & "1" & PP
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            Str02 = Str02 & "2" & PP
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            Str02 = Str02 & "3" & PP

                        End If


                    End With
                    Str02 = Replace(Str02, "&", " ")
                    WriteToIR7File(Str02)

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function

    Private Sub ShowOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowOnScreenToolStripMenuItem.Click
        SpecialContributionReport(False, False)
    End Sub

    Private Sub SendToPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToPrinterToolStripMenuItem.Click
        SpecialContributionReport(True, False)
    End Sub
    Private Sub ExportInPDFToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportInPDFToolStripMenuItem1.Click
        SpecialContributionReport(True, True)
       
    End Sub
    Private Sub SpecialContributionReport(ByVal SendToPrinter As Boolean, ByVal ExportInPDF As Boolean)



        ''''''''''

        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet
        Dim OrderByanalysis2 As Boolean = False

        Dim ExportDirectory As String = ""
        Dim ds1 As DataSet
        ds1 = Global1.Business.GetParameter("Payslips", "ExportFileDir")
        If CheckDataSet(ds1) Then
            Dim Par As New cPrSsParameters(ds1.Tables(0).Rows(0))
            ExportDirectory = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            Exportdirectory = "C:\"
        End If


        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        D = DateAdd(DateInterval.Year, 1, D)
        Dim dsIR7 As DataSet
        dsIR7 = Global1.Business.REPORT_IR7_2(PerGrp, "", "", D, False)

        If CBOrderByAnalysis2.CheckState = CheckState.Checked Then
            OrderByanalysis2 = True
        End If

        dsEmp = Global1.Business.GetAllEmployeesOfCodeOfTemplateGroupForYear(FromCode, ToCode, TempGrpCode, D, orderbyanalysis2)
        If CheckDataSet(dsEmp) Then
            For i = 0 To dsEmp.Tables(0).Rows.Count - 1
                EmpCode = DbNullToString(dsEmp.Tables(0).Rows(i).Item(0))

                Ds = Global1.Business.REPORT_SpecialContribution(PerGrp, EmpCode, dsIR7)
                'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\SpecialContribution")

                If CheckDataSet(Ds) Then
                    ''
                    If ExportInPDF Then
                        Dim Filename As String
                        Filename = ExportDirectory & EmpCode & "_SpecialCon" & ".pdf"
                        Utils.ShowReport("SpecialContribution.rpt", Ds, FrmReport, "Special Contribution Report", False, "", False, True, Filename, False, 0)
                    Else
                        ''
                        Utils.ShowReport("SpecialContribution.rpt", Ds, FrmReport, "Special Contribution Report", SendToPrinter)
                    End If
                    '    MsgBox("No records found For Employee Code" & EmpCode, MsgBoxStyle.Information)
                End If
            Next
        End If
        MsgBox("End of Process", MsgBoxStyle.Information)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CreateXMLFileForYears2012AndAboveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateXMLFileForYears2012AndAboveToolStripMenuItem.Click
        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else
            IR7_2012(False, True, True)
            If GLB_XMLOriginFile <> "" Then
                CreateXMLFile_2012()
            Else
                MsgBox("Failed to create .xml File")
            End If
        End If
    End Sub
    Private Sub CreateXMLFile_2012()


        Cursor = Cursors.WaitCursor
        Try
            Dim F As New FrmXMLDestination
            F.Owner = Me
            F.ShowDialog()

            'If Me.txtFromFile.Text = "" Then
            '    MsgBox("Please Select Valid Source File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            'If Me.txtToFile.Text = "" Then
            '    MsgBox("Please Select Valid Destination File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile


            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"
                        WriteIR7_2012_Header(Line)
                    Case "2"
                        Lines = Lines + 1
                        WriteIR7_2012_LINE(Line)
                End Select

            Loop
            WL("</mof:grid>")
            WL("</mof:epr7-declaration>")
            WL("</mof:epr7-declarations>")


            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)
        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default


    End Sub
    Public Sub WriteIR7_2012_Header(ByVal Line As String)
        Dim Ar() As String
        Dim Year As String
        Ar = Line.Split("|")
        Year = Ar(1)

        WL("<?xml version=""1.0"" encoding=""UTF-8""?>")
        WL("<mof:epr7-declarations xsi:schemaLocation=""http://www.mof.gov.cy http://taxisnet.mof.gov.cy/schema/cy-epr7-declaration.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:mof=""http://www.mof.gov.cy"">")
        WL("<mof:epr7-declaration version=""" & Year & "-1.0"" taxpayer=""" & Ar(2) & """>")
        'WL("<mof:period to=""2012-12-31"" from=""2012-01-01""/>")
        WL("<mof:period to=""" & Year & "-12-31"" from=""" & Year & "-01-01""/>")
        WL("<mof:field key=""epr7m1t0r2c2"">" & Trim(Ar(39)) & "</mof:field>")
        WL("<mof:field key=""epr7m1t0r2c3"">" & 0 & "</mof:field>")
        WL("<mof:field key=""epr7m1t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        WL("<mof:field key=""epr7m1t0r2c1"">" & Trim(Ar(5)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tar1c1"">" & Trim(Ar(6)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tbr1c1"">" & Trim(Ar(8)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tbr2c1"">" & Trim(Ar(9)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tbr2c2"">" & Trim(Ar(10)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r1c1"">" & CLng(Ar(12)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c1"">" & CLng(Ar(12)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r2c1"">" & CLng(Ar(13)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c2"">" & CLng(Ar(13)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r3c1"">" & CLng(Ar(14)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c3"">" & CLng(Ar(14)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r4c1"">" & CLng(Ar(15)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c4"">" & CLng(Ar(15)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r5c1"">" & CLng(Ar(16)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c5"">" & CLng(Ar(16)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r6c1"">" & CLng(Ar(17)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c6"">" & CLng(Ar(17)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r7c1"">" & CLng(Ar(18)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c7"">" & CLng(Ar(18)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r8c1"">" & CLng(Ar(19)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8"">" & CLng(Ar(19)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r9c1"">" & CLng(Ar(20)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c9"">" & CLng(Ar(20)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r10c1"">" & CLng(Ar(21)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c10"">" & CLng(Ar(21)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r11c1"">" & CLng(Ar(22)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c11"">" & CLng(Ar(22)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r12c1"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c12"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r14c1"">" & StringtoDecimal2(CLng(Ar(25))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c14"">" & StringtoDecimal2(CLng(Ar(25))) & "</mof:field>")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<mof:field key=""epr7m3t0r15c1"">" & StringtoDecimal2(CLng(0)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c15"">" & StringtoDecimal2(CLng(0)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        ''''''''''''''''''''''''''''''''''''''''''''''''






        WL("<mof:field key=""epr7m4t0r1c1"">" & StringtoDecimal2(CLng(Ar(28))) & "</mof:field>")
        WL("<mof:field key=""epr7m4t0r2c1"">" & StringtoDecimal2(CLng(Ar(29))) & "</mof:field>")
        WL("<mof:field key=""epr7m4t0r3c1"">" & StringtoDecimal2(CLng(Ar(30))) & "</mof:field>")
        ''''Extra Tax Total Ded and Contr
        WL("<mof:field key=""epr7m4t0r5c1"">" & StringtoDecimal2(CLng(Ar(42))) & "</mof:field>")
        ''''
        Dim T As String
        T = Trim(Ar(35))
        If T = 1 Then
            If Trim(Ar(31)) <> "" Then
                WL("<mof:field key=""epr7m2tar1c1"">" & Trim(Ar(31)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tar2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 2 Then
            If Trim(Ar(32)) <> "" Then
                WL("<mof:field key=""epr7m2tbr1c1"">" & Trim(Ar(32)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tbr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 3 Then
            If Trim(Ar(33)) <> "" Then
                WL("<mof:field key=""epr7m2tcr1c1"">" & Trim(Ar(33)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tcr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        End If

        WL("<mof:field key=""epr7m5t0r1c1"">" & Trim(Ar(43)) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r1c2"">" & Trim(Ar(44)) & "</mof:field>")


        WL("<mof:field key=""epr7m5t0r2c1"">" & Ar(35) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r3c1"">" & Ar(36) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r4c1"">" & Ar(37) & "</mof:field>")



        WL("<mof:grid id=""epr7m6t0r1"">")


    End Sub
    Private Function StringtoDecimal2(ByVal Str As String) As String

        Dim S As String
        S = Format(CDbl(Str) / 100, "0.00")

        S = S.Replace(".", ",")
        Return S

        'Dim L As Integer
        'Dim i As Integer
        'Dim X As String = ""
        'L = Str.Length
        'For i = 0 To Str.Length - 1
        '    X = X & Str.Substring(i, 1)
        '    If i = L - 3 Then
        '        X = X & "."
        '    End If
        'Next
        'Return X
    End Function
    Private Function StringtoDecimal2ReturnDouble(ByVal Str As String) As Double

        Dim S As String
        S = Format(CDbl(Str) / 100, "0.00")


        Return CDbl(S)

        'Dim L As Integer
        'Dim i As Integer
        'Dim X As String = ""
        'L = Str.Length
        'For i = 0 To Str.Length - 1
        '    X = X & Str.Substring(i, 1)
        '    If i = L - 3 Then
        '        X = X & "."
        '    End If
        'Next
        'Return X
    End Function
    Private Function StringtoDecimal2New(ByVal Str As String) As Double

        Dim S As String
        S = Format(CDbl(Str), "0.00")


        Return CDbl(S)

        'Dim L As Integer
        'Dim i As Integer
        'Dim X As String = ""
        'L = Str.Length
        'For i = 0 To Str.Length - 1
        '    X = X & Str.Substring(i, 1)
        '    If i = L - 3 Then
        '        X = X & "."
        '    End If
        'Next
        'Return X
    End Function
    Private Function StringtoInteger(ByVal Str As String) As String

        Dim S As String
        S = Format(CDbl(Str), "0.00")

        Dim ar() As String
        ar = S.Split(".")

        S = ar(0)

        Return S

        'Dim L As Integer
        'Dim i As Integer
        'Dim X As String = ""
        'L = Str.Length
        'For i = 0 To Str.Length - 1
        '    X = X & Str.Substring(i, 1)
        '    If i = L - 3 Then
        '        X = X & "."
        '    End If
        'Next
        'Return X
    End Function

    Public Sub WriteIR7_2012_LINE(ByVal Line As String)
        Dim Ar() As String
        Ar = Line.Split("|")

        WL("<mof:row number=""" & CLng(Ar(11)) & """>")
        If Trim(Ar(2)) <> "" Then
            WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        Else
            If Ar(43) = 1 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Ô" & "</mof:field>")
            ElseIf Ar(43) = 2 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Á" & "</mof:field>")
            ElseIf Ar(43) = 3 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Ö" & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")

            WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
        End If

        WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")

        WL("<mof:field key=""epr7m6t0r1c8"">" & CLng(Trim(Ar(12))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c9"">" & CLng(Trim(Ar(13))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c10"">" & CLng(Trim(Ar(14))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c11"">" & CLng(Trim(Ar(15))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c12"">" & CLng(Trim(Ar(16))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c13"">" & CLng(Trim(Ar(17))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c14"">" & CLng(Trim(Ar(18))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c15"">" & CLng(Trim(Ar(19))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c16"">" & CLng(Trim(Ar(20))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c17"">" & CLng(Trim(Ar(21))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c18"">" & CLng(Trim(Ar(22))) & "</mof:field>")

        WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(CLng(Ar(25))) & "</mof:field>")

        '''
        'extra Tax
        WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(0) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")


        WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")

        '''

        If Trim(Ar(26)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(26)))
            WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
        End If
        If Trim(Ar(27)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(27)))
            WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")

        End If
        WL("<mof:field key=""epr7m6t0r1c22"">" & Checkforzero(Trim(Ar(38))) & "</mof:field>")

        'WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
        WL("</mof:row>")



    End Sub
    Private Function CheckforZero(ByVal S As String) As String
        Try

        
            Dim X As String
            If IsNumeric(S) Then
                If CLng(S) = 0 Then
                    X = 0
                Else
                    X = CLng(S)
                End If
            Else
                X = S
            End If
            Return X
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Exception in Check for Zero Function")
        End Try
    End Function
    Public Function changeformtatodate(ByVal S As String) As String
        Dim i As Integer
        Dim x As String = ""
        Dim y As String = ""
        Dim m As String = ""
        Dim d As String = ""

        For i = 0 To S.Length - 1
            x = S.Substring(i, 1)
            If i <= 3 Then
                y = y + x
            ElseIf i > 3 And i <= 5 Then
                m = m + x
            Else
                d = d + x
            End If
        Next
        Return CInt(d) & "/" & CInt(m) & "/" & CInt(y)

    End Function
    Public Function changeformtatodate2(ByVal S As String) As String
        Dim i As Integer
        Dim x As String = ""
        Dim y As String = ""
        Dim m As String = ""
        Dim d As String = ""

        For i = 0 To S.Length - 1
            x = S.Substring(i, 1)
            If i <= 3 Then
                y = y + x
            ElseIf i > 3 And i <= 5 Then
                m = m + x
            Else
                d = d + x
            End If
        Next
        Dim SS As String
        SS = y & "-" & m.PadLeft(2, "0") & "-" & d.PadLeft(2, "0")
        Return SS
        'Return CInt(y) & "-" & CInt(m) & "-" & CInt(d)


    End Function
    Private Function WL(ByVal Line As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(GLB_XMLDestinationFile)
                InitFile = False
            Else
                If IO.File.Exists(GLB_XMLDestinationFile) Then
                    TW = System.IO.File.AppendText(GLB_XMLDestinationFile)
                Else
                    TW = System.IO.File.CreateText(GLB_XMLDestinationFile)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
                .Dispose()
                GC.Collect()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function


    'Private Sub ExportInPDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportInPDFToolStripMenuItem.Click
    '    Try
    '        IR63A(True, True)
    '        MsgBox("Export finished ", MsgBoxStyle.Information)
    '    Catch ex As Exception
    '        Utils.ShowException(ex)
    '    End Try


    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim EmpDs As DataSet
        Dim F As New FrmEmployeeSelectiveSearch
        F.CalledBy = 5
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        F.TempGroup = PerGrp.TemGrpCode
        F.Owner = Me
        F.ShowDialog()
    End Sub


    
   
    Private Sub CreateXMLFile2016ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateXMLFile2016ToolStripMenuItem.Click
        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else
            IR7_2016(False, True, True)
            If GLB_XMLOriginFile <> "" Then
                CreateXMLFile_2016()
            Else
                MsgBox("Failed to create .xml File")
            End If
        End If
    End Sub
#Region "2016 XML"



    Private Sub IR7_2016(ByVal SendToPrinter As Boolean, ByVal File As Boolean, ByVal XMLCreation As Boolean)
        GLB_XMLOriginFile = ""
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet


        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        ' D = DateAdd(DateInterval.Year, 1, D)

        Ds = Global1.Business.REPORT_IR7_3(PerGrp, FromCode, ToCode, D)
        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                Utils.ShowReport("IR7.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then
                If CreateIR7File_2016(Ds) Then
                    If Not XMLCreation Then
                        MsgBox("File is Created - " & IR7FileDir & "IPA03ETD.DAT", MsgBoxStyle.Information)
                    End If
                    GLB_XMLOriginFile = IR7FileDir & "IPA03ETD.DAT"
                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub
    Private Function CreateIR7File_2016(ByVal Ds As DataSet) As Boolean

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30
            Dim C_LifeInsurance As Integer = 31


            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim TOTAL_LifeInsurance As Double = 0

            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + .Item(C_Local)
                        TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
                        TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
                        TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
                        TOTAL_SI = TOTAL_SI + .Item(C_SI)
                        TOTAL_PF = TOTAL_PF + .Item(C_PF)
                        TOTAL_MF = TOTAL_MF + .Item(C_MF)
                        TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
                        TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
                        TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
                        TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
                        TOTAL_IT = TOTAL_IT + .Item(C_IT)
                        TOTAL_SpecialTax = TOTAL_SpecialTax + .Item(C_EmpSpecialTaxDed) + .Item(C_EmpSpecialTaxCon)
                        TOTAL_SPDeduction = TOTAL_SPDeduction + .Item(C_EmpSpecialTaxDed)
                        TOTAL_SPContribution = TOTAL_SPContribution + .Item(C_EmpSpecialTaxCon)
                        TOTAL_LifeInsurance = TOTAL_LifeInsurance + .Item(C_LifeInsurance)

                    End With
                Next
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '1
                Str03 = 1 & PP
                '2
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '3
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '4
                Str03 = Str03 & " " & PP
                '5
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '6
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '7
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '8
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '9
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '10
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '11
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '12
                Str03 = Str03 & FixInteger((i), 5) & PP
                '13
                Str03 = Str03 & FixInteger(TOTAL_Local, 10) & PP
                '14
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9) & PP
                '15
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9) & PP
                '16
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10) & PP
                '17
                Str03 = Str03 & FixInteger(TOTAL_SI, 9) & PP
                '18
                Str03 = Str03 & FixInteger(TOTAL_PF, 9) & PP
                '19
                Str03 = Str03 & FixInteger(TOTAL_MF, 9) & PP
                '20
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9) & PP
                '21
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9) & PP
                '22
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9) & PP
                '23
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10) & PP
                '24
                Str03 = Str03 & FixNumber(TOTAL_IT, 11) & PP
                '25
                Str03 = Str03 & FixNumber(0, 11) & PP
                '26
                Str03 = Str03 & FixNumber(0, 11) & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '29
                Str03 = Str03 & FixNumber(TaxGiven, 11) & PP
                '30
                Str03 = Str03 & FixNumber(0, 11) & PP
                '31
                Str03 = Str03 & FixNumber(0, 11) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC
                End If
                TIC4 = Company.AccountantTIC
                '32
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '36
                Str03 = Str03 & Company.AccIdentity & PP
                '37
                Str03 = Str03 & Company.TICCategory & PP
                '38
                Str03 = Str03 & Company.TICType & PP
                '39
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '40
                Str03 = Str03 & Original & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 11) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 11) & PP
                '43
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 11) & PP
                '44
                Str03 = Str03 & Company.AccountantTitle & PP
                '45
                Str03 = Str03 & Company.AccountantTIC & PP
                '46
                Str03 = Str03 & FixInteger(TOTAL_LifeInsurance, 11) & PP


                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP
                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5) & PP
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10) & PP
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9) & PP
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9) & PP
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9) & PP
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9) & PP
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9) & PP
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9) & PP
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9) & PP
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If

                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 11) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 11) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then
                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        If .Item(C_EmpIDType) = " " Then
                            Str02 = Str02 & "0" & PP
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            Str02 = Str02 & "1" & PP
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            Str02 = Str02 & "2" & PP
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            Str02 = Str02 & "3" & PP

                        End If

                        Str02 = Str02 & FixInteger(.Item(C_LifeInsurance), 11) & PP

                    End With
                    Str02 = Replace(Str02, "&", " ")
                    WriteToIR7File(Str02)

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Sub CreateXMLFile_2016()


        Cursor = Cursors.WaitCursor
        Try
            Dim F As New FrmXMLDestination
            F.Owner = Me
            F.ShowDialog()

            'If Me.txtFromFile.Text = "" Then
            '    MsgBox("Please Select Valid Source File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            'If Me.txtToFile.Text = "" Then
            '    MsgBox("Please Select Valid Destination File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile


            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"
                        WriteIR7_2016_Header(Line)
                    Case "2"
                        Lines = Lines + 1
                        WriteIR7_2016_LINE(Line)
                End Select

            Loop
            WL("</mof:grid>")
            WL("</mof:epr7-declaration>")
            WL("</mof:epr7-declarations>")


            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)
        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default


    End Sub
    Public Sub WriteIR7_2016_Header(ByVal Line As String)
        Dim Ar() As String
        Dim Year As String
        Ar = Line.Split("|")
        Year = Ar(1)

        WL("<?xml version=""1.0"" encoding=""UTF-8""?>")
        WL("<mof:epr7-declarations xsi:schemaLocation=""http://www.mof.gov.cy http://taxisnet.mof.gov.cy/schema/cy-epr7-declaration.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:mof=""http://www.mof.gov.cy"">")
        WL("<mof:epr7-declaration version=""" & Year & "-1.0"" taxpayer=""" & Ar(2) & """>")
        'WL("<mof:period to=""2012-12-31"" from=""2012-01-01""/>")
        WL("<mof:period to=""" & Year & "-12-31"" from=""" & Year & "-01-01""/>")
        WL("<mof:field key=""epr7m1t0r2c2"">" & Trim(Ar(39)) & "</mof:field>")
        WL("<mof:field key=""epr7m1t0r2c3"">" & 0 & "</mof:field>")
        WL("<mof:field key=""epr7m1t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        WL("<mof:field key=""epr7m1t0r2c1"">" & Trim(Ar(5)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tar1c1"">" & Trim(Ar(6)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tbr1c1"">" & Trim(Ar(8)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tbr2c1"">" & Trim(Ar(9)) & "</mof:field>")
        WL("<mof:field key=""epr7m1tbr2c2"">" & Trim(Ar(10)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r1c1"">" & CLng(Ar(12)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c1"">" & CLng(Ar(12)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r2c1"">" & CLng(Ar(13)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c2"">" & CLng(Ar(13)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r3c1"">" & CLng(Ar(14)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c3"">" & CLng(Ar(14)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r4c1"">" & CLng(Ar(15)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c4"">" & CLng(Ar(15)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r5c1"">" & CLng(Ar(16)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c5"">" & CLng(Ar(16)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r6c1"">" & CLng(Ar(17)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c6"">" & CLng(Ar(17)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r7c1"">" & CLng(Ar(18)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c7"">" & CLng(Ar(18)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r8c1"">" & CLng(Ar(19)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8"">" & CLng(Ar(19)) & "</mof:field>")

        'Life Insurance
        WL("<mof:field key=""epr7m3t0r8c2"">" & CLng(Ar(45)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8b"">" & CLng(Ar(45)) & "</mof:field>")


        'Other Discounts
        WL("<mof:field key=""epr7m3t0r9c1"">" & CLng(Ar(20)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c9"">" & CLng(Ar(20)) & "</mof:field>")


        WL("<mof:field key=""epr7m3t0r10c1"">" & CLng(Ar(21)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c10"">" & CLng(Ar(21)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r11c1"">" & CLng(Ar(22)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c11"">" & CLng(Ar(22)) & "</mof:field>")
        WL("<mof:field key=""epr7m3t0r12c1"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c12"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r14c1"">" & StringtoDecimal2(CLng(Ar(25))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c14"">" & StringtoDecimal2(CLng(Ar(25))) & "</mof:field>")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<mof:field key=""epr7m3t0r15c1"">" & StringtoDecimal2(CLng(0)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c15"">" & StringtoDecimal2(CLng(0)) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")

        WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        ''''''''''''''''''''''''''''''''''''''''''''''''






        WL("<mof:field key=""epr7m4t0r1c1"">" & StringtoDecimal2(CLng(Ar(28))) & "</mof:field>")
        WL("<mof:field key=""epr7m4t0r2c1"">" & StringtoDecimal2(CLng(Ar(29))) & "</mof:field>")
        WL("<mof:field key=""epr7m4t0r3c1"">" & StringtoDecimal2(CLng(Ar(30))) & "</mof:field>")
        ''''Extra Tax Total Ded and Contr
        WL("<mof:field key=""epr7m4t0r5c1"">" & StringtoDecimal2(CLng(Ar(42))) & "</mof:field>")
        ''''
        Dim T As String
        T = Trim(Ar(35))
        If T = 1 Then
            If Trim(Ar(31)) <> "" Then
                WL("<mof:field key=""epr7m2tar1c1"">" & Trim(Ar(31)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tar2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 2 Then
            If Trim(Ar(32)) <> "" Then
                WL("<mof:field key=""epr7m2tbr1c1"">" & Trim(Ar(32)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tbr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 3 Then
            If Trim(Ar(33)) <> "" Then
                WL("<mof:field key=""epr7m2tcr1c1"">" & Trim(Ar(33)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tcr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        End If

        WL("<mof:field key=""epr7m5t0r1c1"">" & Trim(Ar(43)) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r1c2"">" & Trim(Ar(44)) & "</mof:field>")


        WL("<mof:field key=""epr7m5t0r2c1"">" & Ar(35) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r3c1"">" & Ar(36) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r4c1"">" & Ar(37) & "</mof:field>")



        WL("<mof:grid id=""epr7m6t0r1"">")


    End Sub
  

    Public Sub WriteIR7_2016_LINE(ByVal Line As String)
        Dim Ar() As String
        Ar = Line.Split("|")

        WL("<mof:row number=""" & CLng(Ar(11)) & """>")
        If Trim(Ar(2)) <> "" Then
            WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        Else
            If Ar(43) = 1 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Ô" & "</mof:field>")
            ElseIf Ar(43) = 2 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Á" & "</mof:field>")
            ElseIf Ar(43) = 3 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Ö" & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")

            WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
        End If

        WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")

        WL("<mof:field key=""epr7m6t0r1c8"">" & CLng(Trim(Ar(12))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c9"">" & CLng(Trim(Ar(13))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c10"">" & CLng(Trim(Ar(14))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c11"">" & CLng(Trim(Ar(15))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c12"">" & CLng(Trim(Ar(16))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c13"">" & CLng(Trim(Ar(17))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c14"">" & CLng(Trim(Ar(18))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c15"">" & CLng(Trim(Ar(19))) & "</mof:field>")

        'Life Insurance
        WL("<mof:field key=""epr7m6t0r1c15b"">" & CLng(Trim(Ar(44))) & "</mof:field>")

        'Other Discounts

        WL("<mof:field key=""epr7m6t0r1c16"">" & CLng(Trim(Ar(20))) & "</mof:field>")

        'Total Discounts

        WL("<mof:field key=""epr7m6t0r1c17"">" & CLng(Trim(Ar(21))) & "</mof:field>")

        WL("<mof:field key=""epr7m6t0r1c18"">" & CLng(Trim(Ar(22))) & "</mof:field>")

        WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(CLng(Ar(25))) & "</mof:field>")

        '''
        'extra Tax
        WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(0) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")


        WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")

        '''

        If Trim(Ar(26)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(26)))
            WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
        End If
        If Trim(Ar(27)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(27)))
            WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")

        End If
        WL("<mof:field key=""epr7m6t0r1c22"">" & Checkforzero(Trim(Ar(38))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
        WL("</mof:row>")



    End Sub
#End Region

    Private Sub tsbIR112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbIR112.Click
        Dim F As New FrmIR112
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        F.PerGroup = PerGrp
        F.TempGroupCode = PerGrp.TemGrpCode
        F.Owner = Me
        F.ShowDialog()
    End Sub

#Region "2017 XML"
    Private Sub CreateXMLFile2017ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateXMLFile2017ToolStripMenuItem.Click
        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else

            IR7_2017(False, True, False)

            If GLB_XMLOriginFile <> "" Then

                CreateXMLFile_2017()

            Else
                MsgBox("Failed to create .xml File")
            End If
        End If
    End Sub
    Private Sub IR7_2017(ByVal SendToPrinter As Boolean, ByVal File As Boolean, ByVal XMLCreation As Boolean)
        GLB_XMLOriginFile = ""
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet


        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        ' D = DateAdd(DateInterval.Year, 1, D)

        Ds = Global1.Business.REPORT_IR7_3(PerGrp, FromCode, ToCode, D)
        'Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                Utils.ShowReport("IR7.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then
                If CreateIR7File_2017(Ds) Then
                    If Not XMLCreation Then
                        MsgBox("File is Created - " & IR7FileDir & "IPA03ETD.DAT", MsgBoxStyle.Information)
                    End If
                    GLB_XMLOriginFile = IR7FileDir & "IPA03ETD.DAT"
                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub
    Private Function CreateIR7File_2017(ByVal Ds As DataSet) As Boolean

        Dim Flag As Boolean = True
        Try
            Dim PP As String = "|"

            Dim C_EmpLastName As Integer = 0
            Dim C_EmpFirstName As Integer = 1
            Dim C_EmpName As Integer = 2
            Dim C_EmpTaxID As Integer = 3
            Dim C_EmpIDType As Integer = 4
            Dim C_EmpIDCard As Integer = 5
            Dim C_Local As Integer = 6
            Dim C_Abroad As Integer = 7
            Dim C_Allowances As Integer = 8
            Dim C_Total456 As Integer = 9
            Dim C_SI As Integer = 10
            Dim C_PF As Integer = 11
            Dim C_MF As Integer = 12
            Dim C_UNION As Integer = 13
            Dim C_OtherDisc As Integer = 14
            Dim C_TotalDisc As Integer = 15
            Dim C_Taxable As Integer = 16
            Dim C_IT As Integer = 17
            Dim C_StartDate As Integer = 18
            Dim C_LeaveDate As Integer = 19
            Dim C_Adr1 As Integer = 20
            Dim C_Adr2 As Integer = 21
            Dim C_Adr3 As Integer = 22
            Dim C_PostCode As Integer = 23
            Dim C_PensionNo As Integer = 24
            Dim C_PensionType As Integer = 25
            Dim C_EmpSINo As Integer = 26
            Dim C_EmpCode As Integer = 27
            Dim C_EmpSpecialTaxDed As Integer = 28
            Dim C_EmpSpecialTaxCon As Integer = 29
            Dim C_SalaryPeriods As Integer = 30

            Dim C_LifeInsurance As Integer = 31

            Dim C_AllowanceBenefits As Integer = 32
            Dim C_TaxableFromOther As Integer = 33
            Dim C_NonTaxable As Integer = 34
            Dim C_Syntaksiodotika As Integer = 35
            Dim C_MiwsiApolavon As Integer = 36
            Dim C_WidowOrphans As Integer = 37
            Dim C_PensionFund As Integer = 38



            Dim LastName As String
            Dim FirstName As String
            Dim Adr1 As String
            Dim Adr2 As String
            Dim PostCode As String
            Dim EmpTaxID As String

            Dim TOTAL_Local As Integer = 0
            Dim TOTAL_Abroad As Integer = 0
            Dim TOTAL_Allowances As Integer = 0
            Dim TOTAL_Total456 As Integer = 0
            Dim TOTAL_SI As Integer = 0
            Dim TOTAL_PF As Integer = 0
            Dim TOTAL_MF As Integer = 0
            Dim TOTAL_UNION As Integer = 0
            Dim TOTAL_OtherDisc As Integer = 0
            Dim TOTAL_TotalDisc As Integer = 0
            Dim TOTAL_Taxable As Integer = 0
            Dim TOTAL_IT As Double = 0
            Dim TOTAL_SpecialTax As Double = 0
            Dim TOTAL_SPDeduction As Double = 0
            Dim TOTAL_SPContribution As Double = 0
            Dim TOTAL_LifeInsurance As Double = 0

            Dim TOTAL_AllowanceBenefits As Double = 0
            Dim TOTAL_TaxableFromOther As Double = 0
            Dim TOTAL_NonTaxable As Double = 0
            Dim TOTAL_Syntaksiodotika As Double = 0
            Dim TOTAL_MiwsiApolavon As Double = 0
            Dim TOTAL_WidowOrphans As Double = 0
            Dim TOTAL_PensionFund As Double = 0



            Dim Str03 As String = ""

            Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
            Dim CompanyName As String
            Dim ComAdr1 As String
            Dim ComAdr2 As String
            Dim ComPost As String

            Dim TIC1 As String = ""
            Dim TIC2 As String = ""
            Dim TIC3 As String = ""
            Dim TIC4 As String = ""


            InitFile = True
            Dim i As Integer
            If CheckDataSet(Ds) Then
                'GET TOTALS
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    With Ds.Tables(0).Rows(i)
                        TOTAL_Local = TOTAL_Local + .Item(C_Local)
                        TOTAL_Abroad = TOTAL_Abroad + .Item(C_Abroad)
                        TOTAL_Allowances = TOTAL_Allowances + .Item(C_Allowances)
                        TOTAL_Total456 = TOTAL_Total456 + .Item(C_Total456)
                        TOTAL_SI = TOTAL_SI + .Item(C_SI)
                        TOTAL_PF = TOTAL_PF + .Item(C_PF)
                        TOTAL_MF = TOTAL_MF + .Item(C_MF)
                        TOTAL_UNION = TOTAL_UNION + .Item(C_UNION)
                        TOTAL_OtherDisc = TOTAL_OtherDisc + .Item(C_OtherDisc)
                        TOTAL_TotalDisc = TOTAL_TotalDisc + .Item(C_TotalDisc)
                        TOTAL_Taxable = TOTAL_Taxable + .Item(C_Taxable)
                        TOTAL_IT = TOTAL_IT + .Item(C_IT)
                        TOTAL_SpecialTax = TOTAL_SpecialTax + .Item(C_EmpSpecialTaxDed) + .Item(C_EmpSpecialTaxCon)
                        TOTAL_SPDeduction = TOTAL_SPDeduction + .Item(C_EmpSpecialTaxDed)
                        TOTAL_SPContribution = TOTAL_SPContribution + .Item(C_EmpSpecialTaxCon)
                        TOTAL_LifeInsurance = TOTAL_LifeInsurance + .Item(C_LifeInsurance)

                        TOTAL_AllowanceBenefits = TOTAL_AllowanceBenefits + DbNullToDouble(.Item(C_AllowanceBenefits))
                        TOTAL_TaxableFromOther = TOTAL_TaxableFromOther + DbNullToDouble(.Item(C_TaxableFromOther))
                        TOTAL_NonTaxable = TOTAL_NonTaxable + DbNullToDouble(.Item(C_NonTaxable))
                        TOTAL_Syntaksiodotika = TOTAL_Syntaksiodotika + DbNullToDouble(.Item(C_Syntaksiodotika))
                        TOTAL_MiwsiApolavon = TOTAL_MiwsiApolavon + DbNullToDouble(.Item(C_MiwsiApolavon))
                        TOTAL_WidowOrphans = TOTAL_WidowOrphans + DbNullToDouble(.Item(C_WidowOrphans))
                        TOTAL_PensionFund = TOTAL_PensionFund + DbNullToDouble(.Item(C_PensionFund))

                    End With
                Next
                '---------------------------------------------
                'RECORD 01
                '---------------------------------------------
                '1
                Str03 = 1 & PP
                '2
                Str03 = Str03 & Ds.Tables(2).Rows(0).Item(0) & PP
                Dim YEAR As String
                YEAR = Ds.Tables(2).Rows(0).Item(0)

                '3
                If Company.TaxCard = "" Then
                    MsgBox("Please enter Tax ID", MsgBoxStyle.Critical)
                    Exit Function
                End If
                Str03 = Str03 & Company.TaxCard.PadLeft(9, " ") & PP

                '4
                Str03 = Str03 & " " & PP
                '5
                'Str03 = Str03 & " ".PadLeft(9, " ")
                Str03 = Str03 & " ".PadLeft(15, " ") & PP
                '6
                Str03 = Str03 & Company.SIRegNo.PadRight(15, " ") & PP
                '7
                CompanyName = Company.Name
                If CompanyName.Length > 35 Then
                    CompanyName = CompanyName.Substring(0, 34)
                End If
                Str03 = Str03 & CompanyName.PadRight(35, " ") & PP
                '8
                Str03 = Str03 & "".PadRight(25, " ") & PP
                '9
                ComAdr1 = Company.Address1
                If ComAdr1.Length > 35 Then
                    ComAdr1 = ComAdr1.Substring(0, 34)
                End If
                Str03 = Str03 & ComAdr1.PadRight(35, " ") & PP
                '10
                ComAdr2 = Company.Address2
                If ComAdr2.Length > 30 Then
                    ComAdr2 = ComAdr2.Substring(0, 29)
                End If
                Str03 = Str03 & ComAdr2.PadRight(30, " ") & PP
                '11
                ComPost = Company.Address3
                If ComPost.Length > 10 Then
                    ComPost = ComPost.Substring(0, 10)
                End If
                Str03 = Str03 & ComPost.PadRight(10, " ") & PP
                '12
                Str03 = Str03 & FixInteger((i), 5) & PP
                '13
                Str03 = Str03 & FixInteger(TOTAL_Local, 10) & PP
                '14
                Str03 = Str03 & FixInteger(TOTAL_Abroad, 9) & PP
                '15
                Str03 = Str03 & FixInteger(TOTAL_Allowances, 9) & PP
                '16
                Str03 = Str03 & FixInteger(TOTAL_Total456, 10) & PP
                '17
                Str03 = Str03 & FixInteger(TOTAL_SI, 9) & PP
                '18
                Str03 = Str03 & FixInteger(TOTAL_PF, 9) & PP
                '19
                Str03 = Str03 & FixInteger(TOTAL_MF, 9) & PP
                '20
                Str03 = Str03 & FixInteger(TOTAL_UNION, 9) & PP
                '21
                Str03 = Str03 & FixInteger(TOTAL_OtherDisc, 9) & PP
                '22
                Str03 = Str03 & FixInteger(TOTAL_TotalDisc, 9) & PP
                '23
                Str03 = Str03 & FixInteger(TOTAL_Taxable, 10) & PP
                '24
                Str03 = Str03 & FixNumber(TOTAL_IT, 11) & PP
                '25
                Str03 = Str03 & FixNumber(0, 11) & PP
                '26
                Str03 = Str03 & FixNumber(0, 11) & PP
                '27
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '28
                'Str03 = Str03 & "00000000"
                Str03 = Str03 & "        " & PP
                '29
                Str03 = Str03 & FixNumber(TaxGiven, 11) & PP
                '30
                Str03 = Str03 & FixNumber(0, 11) & PP
                '31
                Str03 = Str03 & FixNumber(0, 11) & PP

                If Company.AccIdentity = 1 Then
                    TIC1 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 2 Then
                    TIC2 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 3 Then
                    TIC3 = Company.AccountantTIC
                ElseIf Company.AccIdentity = 4 Then
                    TIC4 = Company.AccountantTIC
                End If
                TIC4 = Company.AccountantTIC
                '32
                Str03 = Str03 & TIC1.PadRight(9, " ") & PP
                '33
                Str03 = Str03 & TIC2.PadRight(9, " ") & PP
                '34
                Str03 = Str03 & TIC3.PadRight(9, " ") & PP
                '35
                Str03 = Str03 & TIC4.PadRight(9, " ") & PP
                '36
                Str03 = Str03 & Company.AccIdentity & PP
                '37
                Str03 = Str03 & Company.TICCategory & PP
                '38
                Str03 = Str03 & Company.TICType & PP
                '39
                Str03 = Str03 & "0".PadLeft(7, "0") & PP
                '40
                Str03 = Str03 & Original & PP
                '41
                Str03 = Str03 & FixNumber(TOTAL_SPDeduction, 11) & PP
                '42
                Str03 = Str03 & FixNumber(TOTAL_SPContribution, 11) & PP
                '43
                Str03 = Str03 & FixNumber(TOTAL_SpecialTax, 11) & PP

                '44
                Str03 = Str03 & Company.AccountantTitle & PP
                '45
                Str03 = Str03 & Company.AccountantTIC & PP
                '46
                Str03 = Str03 & FixInteger(TOTAL_LifeInsurance, 11) & PP
                '47
                Str03 = Str03 & FixInteger(TOTAL_AllowanceBenefits, 11) & PP
                '48
                Str03 = Str03 & FixInteger(TOTAL_TaxableFromOther, 11) & PP
                '49
                Str03 = Str03 & FixInteger(TOTAL_NonTaxable, 11) & PP
                '50
                Str03 = Str03 & FixNumber(TOTAL_Syntaksiodotika, 11) & PP
                '51
                Str03 = Str03 & FixNumber(TOTAL_MiwsiApolavon, 11) & PP
                '52
                Str03 = Str03 & FixNumber(TOTAL_WidowOrphans, 11) & PP
                '53
                Str03 = Str03 & FixNumber(TOTAL_PensionFund, 11) & PP




                Str03 = Replace(Str03, "&", " ")
                WriteToIR7File_For2017(Str03)

                '---------------------------------------------
                'END OF 01
                '---------------------------------------------


                Dim Str02 As String
                For i = 0 To Ds.Tables(0).Rows.Count - 1

                    With Ds.Tables(0).Rows(i)
                        '1
                        Str02 = 2 & PP
                        '2
                        Str02 = Str02 & Ds.Tables(2).Rows(0).Item(0) & PP
                        '3
                        ' Dim xx As String
                        ' xx = .Item(C_EmpIDType)
                        If .Item(C_EmpIDType) = " " Then
                            EmpTaxID = .Item(C_EmpTaxID)
                            Str02 = Str02 & EmpTaxID.PadLeft(9, " ") & PP

                        Else
                            Str02 = Str02 & "".PadLeft(9, " ") & PP

                        End If

                        If .Item(C_EmpIDType) <> " " Then
                            '4
                            Str02 = Str02 & .Item(C_EmpIDType) & PP
                            '5
                            Str02 = Str02 & .Item(C_EmpIDCard).ToString.PadRight(15) & PP
                        Else
                            '4
                            Str02 = Str02 & " " & PP
                            '5
                            Str02 = Str02 & "".PadLeft(15, " ") & PP
                        End If
                        '6
                        Str02 = Str02 & .Item(C_EmpSINo).Padright(15, " ") & PP


                        LastName = .Item(C_EmpLastName)
                        If LastName.Length > 35 Then
                            LastName = LastName.Substring(0, 34)
                        End If
                        '7
                        Str02 = Str02 & LastName.PadRight(35, " ") & PP
                        '8
                        FirstName = .Item(C_EmpFirstName)
                        If FirstName.Length > 25 Then
                            FirstName = FirstName.Substring(0, 24)
                        End If
                        Str02 = Str02 & FirstName.PadRight(25, " ") & PP
                        '9
                        Adr1 = .Item(C_Adr1)
                        If Adr1.Length > 35 Then
                            Adr1 = Adr1.Substring(0, 34)
                        End If
                        Str02 = Str02 & Adr1.PadRight(35, " ") & PP
                        '10
                        Adr2 = .Item(C_Adr2)
                        If Adr2.Length > 30 Then
                            Adr2 = Adr2.Substring(0, 29)
                        End If
                        Str02 = Str02 & Adr2.PadRight(30, " ") & PP
                        '11
                        PostCode = .Item(C_PostCode)
                        If PostCode.Length > 10 Then
                            PostCode = PostCode.Substring(0, 10)
                        End If
                        Str02 = Str02 & PostCode.PadRight(10, " ") & PP
                        '12
                        Str02 = Str02 & FixInteger((i + 1), 5) & PP
                        '13
                        Str02 = Str02 & FixInteger(.Item(C_Local), 10) & PP
                        '14
                        Str02 = Str02 & FixInteger(.Item(C_Abroad), 9) & PP
                        '15

                        Str02 = Str02 & FixInteger(.Item(C_Allowances), 9) & PP
                        '16
                        Str02 = Str02 & FixInteger(.Item(C_Total456), 10) & PP
                        '17
                        Str02 = Str02 & FixInteger(.Item(C_SI), 9) & PP
                        '18
                        Str02 = Str02 & FixInteger(.Item(C_PF), 9) & PP
                        '19
                        Str02 = Str02 & FixInteger(.Item(C_MF), 9) & PP
                        '20
                        Str02 = Str02 & FixInteger(.Item(C_UNION), 9) & PP
                        '21
                        Str02 = Str02 & FixInteger(.Item(C_OtherDisc), 9) & PP
                        '22
                        Str02 = Str02 & FixInteger(.Item(C_TotalDisc), 9) & PP
                        '23
                        Str02 = Str02 & FixInteger(.Item(C_Taxable), 10) & PP
                        '24
                        Str02 = Str02 & FixNumber(.Item(C_IT), 11) & PP
                        '25   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP
                        '26   2011
                        Str02 = Str02 & FixNumber(0, 11) & PP

                        '27
                        If Trim(Trim(.Item(C_StartDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String

                            Ar = DbNullToString(.Item(C_StartDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")

                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If
                        Else
                            Str02 = Str02 & "        " & PP
                        End If
                        '28
                        If Trim(Trim(.Item(C_LeaveDate))) <> "" Then
                            Dim yyyy As String
                            Dim mm As String
                            Dim dd As String
                            Dim Ar() As String
                            Ar = DbNullToString(.Item(C_LeaveDate)).Split("/")
                            Dim D As String
                            D = Ar(2) & Ar(1).PadLeft(2, "0") & Ar(0).PadLeft(2, "0")
                            If Ar(2) <> YEAR Then
                                Str02 = Str02 & "        " & PP
                            Else
                                Str02 = Str02 & D & PP
                            End If

                        Else
                            Str02 = Str02 & "        " & PP
                        End If

                        Dim PensionNo As String
                        Dim PensionType As String
                        PensionNo = DbNullToString(.Item(C_PensionNo))
                        PensionType = DbNullToString(.Item(C_PensionType))
                        '29
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '30
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '31
                        Str02 = Str02 & "".PadLeft(11, " ") & PP
                        '32
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '33
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '34
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '35
                        Str02 = Str02 & "".PadLeft(9, " ") & PP
                        '36
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '37
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '38
                        Str02 = Str02 & "".PadLeft(1, " ") & PP
                        '39
                        Str02 = Str02 & PensionNo.PadLeft(7, "0") & PP
                        '40
                        Str02 = Str02 & PensionType.PadLeft(1, "0") & PP
                        '41
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxDed), 11) & PP
                        '42
                        Str02 = Str02 & FixNumber(.Item(C_EmpSpecialTaxCon), 11) & PP
                        '43
                        If .Item(C_SalaryPeriods) > 13 Then
                            .Item(C_SalaryPeriods) = 13
                        End If
                        Str02 = Str02 & .Item(C_SalaryPeriods) & PP

                        '44
                        If .Item(C_EmpIDType) = " " Then
                            Str02 = Str02 & "0" & PP
                        ElseIf .Item(C_EmpIDType) = "Τ" Then
                            Str02 = Str02 & "1" & PP
                        ElseIf .Item(C_EmpIDType) = "Α" Then
                            Str02 = Str02 & "2" & PP
                        ElseIf .Item(C_EmpIDType) = "Φ" Then
                            Str02 = Str02 & "3" & PP

                        End If


                        '45
                        Str02 = Str02 & FixInteger(.Item(C_LifeInsurance), 11) & PP

                        '46
                        Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_TaxableFromOther)), 11) & PP
                        '47
                        Str02 = Str02 & FixInteger(DbNullToInt(.Item(C_NonTaxable)), 11) & PP
                        '48
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_Syntaksiodotika)), 11) & PP
                        '49
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_MiwsiApolavon)), 11) & PP
                        '50
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_WidowOrphans)), 11) & PP
                        '51
                        Str02 = Str02 & FixNumber(DbNullToDouble(.Item(C_PensionFund)), 11) & PP


                    End With
                    Str02 = Replace(Str02, "&", " ")
                    WriteToIR7File_For2017(Str02)

                Next
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            Flag = False
        End Try
        Return Flag
    End Function
    Private Sub CreateXMLFile_2017()


        Cursor = Cursors.WaitCursor
        Try
            Dim F As New FrmXMLDestination
            F.Owner = Me
            F.ShowDialog()

            'If Me.txtFromFile.Text = "" Then
            '    MsgBox("Please Select Valid Source File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            'If Me.txtToFile.Text = "" Then
            '    MsgBox("Please Select Valid Destination File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile



            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"

                        WriteIR7_2017_Header(Line)

                    Case "2"
                        Lines = Lines + 1

                        WriteIR7_2017_LINE(Line)

                End Select

            Loop
            WL("</mof:grid>")
            WL("</mof:epr7-declaration>")
            WL("</mof:epr7-declarations>")


            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default


    End Sub
    Public Sub WriteIR7_2017_Header(ByVal Line As String)
        Try

        
            '47 TOTAL_AllowanceBenefits
            '48 OTAL_TaxableFromOther
            '49 TOTAL_NonTaxable
            '50 TOTAL_Syntaksiodotika
            '51 TOTAL_MiwsiApolavon
            '52 TOTAL_WidowOrphans
            '53 TOTAL_PensionFund
            '-------------------------------------

            Dim Ar() As String
            Dim Year As String
            Ar = Line.Split("|")
            Year = Ar(1)

            WL("<?xml version=""1.0"" encoding=""UTF-8""?>")
            WL("<mof:epr7-declarations xsi:schemaLocation=""http://www.mof.gov.cy http://taxisnet.mof.gov.cy/schema/cy-epr7-declaration.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:mof=""http://www.mof.gov.cy"">")
            WL("<mof:epr7-declaration version=""" & Year & "-1.0"" taxpayer=""" & Ar(2) & """>")
            'WL("<mof:period to=""2012-12-31"" from=""2012-01-01""/>")
            WL("<mof:period to=""" & Year & "-12-31"" from=""" & Year & "-01-01""/>")
            'Arxiki Dilosi/Sympliromatiki
            WL("<mof:field key=""epr7m1t0r2c2"">" & Trim(Ar(39)) & "</mof:field>")
            'Eixa Yppalilous 
            WL("<mof:field key=""epr7m1t0r2c3"">" & 0 & "</mof:field>")
            ' Aritmos Forologkis Taytotitas
            WL("<mof:field key=""epr7m1t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
            ' Social Insurance No
            WL("<mof:field key=""epr7m1t0r2c1"">" & Trim(Ar(5)) & "</mof:field>")
            'Company Name
            WL("<mof:field key=""epr7m1tar1c1"">" & Trim(Ar(6)) & "</mof:field>")
            ' Address 1
            WL("<mof:field key=""epr7m1tbr1c1"">" & Trim(Ar(8)) & "</mof:field>")
            'Address 2
            WL("<mof:field key=""epr7m1tbr2c1"">" & Trim(Ar(9)) & "</mof:field>")
            'Address 3 - POST CODE
            WL("<mof:field key=""epr7m1tbr2c2"">" & Trim(Ar(10)) & "</mof:field>")
            'Akatharistes Apolaves ENTOS
            WL("<mof:field key=""epr7m3t0r1c1"">" & CLng(Ar(12)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c1"">" & CLng(Ar(12)) & "</mof:field>")
            'Akatharistes Apolaves EKTOS
            WL("<mof:field key=""epr7m3t0r2c1"">" & CLng(Ar(13)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c2"">" & CLng(Ar(13)) & "</mof:field>")
            'Xorigimata Ofeloi - Promithies
            WL("<mof:field key=""epr7m3t0r3c1"">" & CLng(Ar(14)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c3"">" & CLng(Ar(14)) & "</mof:field>")
            ' Synolo twn triwn pio panw
            WL("<mof:field key=""epr7m3t0r4c1"">" & CLng(Ar(15)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c4"">" & CLng(Ar(15)) & "</mof:field>")



            ' Tameio Koinonikon Asfalisewn
            WL("<mof:field key=""epr7m3t0r5c1"">" & CLng(Ar(16)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c5"">" & CLng(Ar(16)) & "</mof:field>")
            'Tameia Syntaksewn kai Pronoias
            WL("<mof:field key=""epr7m3t0r6c1"">" & CLng(Ar(17)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c6"">" & CLng(Ar(17)) & "</mof:field>")
            'Tameio Ygeias
            WL("<mof:field key=""epr7m3t0r7c1"">" & CLng(Ar(18)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c7"">" & CLng(Ar(18)) & "</mof:field>")
            'Syntexnies
            WL("<mof:field key=""epr7m3t0r8c1"">" & CLng(Ar(19)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c8"">" & CLng(Ar(19)) & "</mof:field>")
            'Life Insurance
            WL("<mof:field key=""epr7m3t0r8c2"">" & CLng(Ar(45)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c8b"">" & CLng(Ar(45)) & "</mof:field>")

            'First Employeement
            WL("<mof:field key=""epr7m3t0r8c3"">" & CLng(0) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c8c"">" & CLng(0) & "</mof:field>")

            'Other Discounts
            WL("<mof:field key=""epr7m3t0r9c1"">" & CLng(Ar(20)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c9"">" & CLng(Ar(20)) & "</mof:field>")
            'Total Discounts
            WL("<mof:field key=""epr7m3t0r10c1"">" & CLng(Ar(21)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c10"">" & CLng(Ar(21)) & "</mof:field>")
            'Total Taxable Income
            WL("<mof:field key=""epr7m3t0r11c1"">" & CLng(Ar(22)) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c11"">" & CLng(Ar(22)) & "</mof:field>")
            'Income Tax Amount
            WL("<mof:field key=""epr7m3t0r12c1"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c12"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")

            'ektakti eisfora Aksiomatouxon Dimosiou Tomea - NOT 2017
            'WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
            'WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

            'Eisfora Syntaksiodotikon Ofelimaton - Pension fund + Widow and Orphans
            WL("<mof:field key=""epr7m3t0r14c1"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c14"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Meiosi Apolavon
            WL("<mof:field key=""epr7m3t0r15c1"">" & StringtoDecimal2(CLng(Ar(51))) & "</mof:field>")
            WL("<mof:field key=""epr7m6t0r2c15"">" & StringtoDecimal2(CLng(Ar(51))) & "</mof:field>")

            'Ektakti Eisfora idiotikou (Ergazomenos) - NOT 2017
            'WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
            'WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
            'Ektakti Eisfora idiotikou (Ergodotis) - NOT 2017
            'WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
            'WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
            ''''''''''''''''''''''''''''''''''''''''''''''''




            ' Synolo Emvasmaton Forou Eisodimatos
            WL("<mof:field key=""epr7m4t0r1c1"">" & StringtoDecimal2(CLng(Ar(28))) & "</mof:field>")

            ' Synolo GESI Not For 2017
            'WL("<mof:field key=""epr7m4t0r2c1"">" & StringtoDecimal2(CLng(Ar(29))) & "</mof:field>")

            ' Synolo Eisforas Syntaksiodotikon Ofelimaton
            WL("<mof:field key=""epr7m4t0r3c1"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")

            ' Synolo Meiosi Apolabon kai Syntakseon
            WL("<mof:field key=""epr7m4t0r4c1"">" & StringtoDecimal2(CLng(Ar(51))) & "</mof:field>")

            ' Synolo Embasmaton GESI - Not 2017
            'WL("<mof:field key=""epr7m4t0r5c1"">" & StringtoDecimal2(CLng(Ar(42))) & "</mof:field>")
            ''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '                              MEROS 5 DILOSI
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim T As String
            T = Trim(Ar(35))
            If T = 1 Then
                If Trim(Ar(31)) <> "" Then
                    WL("<mof:field key=""epr7m2tar1c1"">" & Trim(Ar(31)) & "</mof:field>")
                End If
                'WL("<mof:field key=""epr7m2tar2c1"">" & Trim(Ar(31)) & "</mof:field>")
            ElseIf T = 2 Then
                If Trim(Ar(32)) <> "" Then
                    WL("<mof:field key=""epr7m2tbr1c1"">" & Trim(Ar(32)) & "</mof:field>")
                End If
                'WL("<mof:field key=""epr7m2tbr2c1"">" & Trim(Ar(31)) & "</mof:field>")
            ElseIf T = 3 Then
                If Trim(Ar(33)) <> "" Then
                    WL("<mof:field key=""epr7m2tcr1c1"">" & Trim(Ar(33)) & "</mof:field>")
                End If
                'WL("<mof:field key=""epr7m2tcr2c1"">" & Trim(Ar(31)) & "</mof:field>")
            End If

            WL("<mof:field key=""epr7m5t0r1c1"">" & Trim(Ar(43)) & "</mof:field>")
            WL("<mof:field key=""epr7m5t0r1c2"">" & Trim(Ar(44)) & "</mof:field>")


            WL("<mof:field key=""epr7m5t0r2c1"">" & Ar(35) & "</mof:field>")
            WL("<mof:field key=""epr7m5t0r3c1"">" & Ar(36) & "</mof:field>")
            WL("<mof:field key=""epr7m5t0r4c1"">" & Ar(37) & "</mof:field>")



            WL("<mof:grid id=""epr7m6t0r1"">")
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try

    End Sub


    Public Sub WriteIR7_2017_LINE(ByVal Line As String)

        '47 TOTAL_AllowanceBenefits
        '48 OTAL_TaxableFromOther
        '49 TOTAL_NonTaxable
        '50 TOTAL_Syntaksiodotika
        '51 TOTAL_MiwsiApolavon
        '52 TOTAL_WidowOrphans
        '53 TOTAL_PensionFund
        '-------------------------------------

        Try

        
            Dim Ar() As String
            Ar = Line.Split("|")

            WL("<mof:row number=""" & CLng(Ar(11)) & """>")
            If Trim(Ar(2)) <> "" Then
                'TIC Number
                WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
            Else
                If Ar(43) = 1 Then
                    'ARITHMOS TAYTOPOIISIS
                    WL("<mof:field key=""epr7m6t0r1c2"">" & "Ô" & "</mof:field>")
                ElseIf Ar(43) = 2 Then
                    WL("<mof:field key=""epr7m6t0r1c2"">" & "Á" & "</mof:field>")
                ElseIf Ar(43) = 3 Then
                    WL("<mof:field key=""epr7m6t0r1c2"">" & "Ö" & "</mof:field>")
                End If
                'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")
                'OTHER COUNTRY TIC
                WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
            End If

            'SOCIAL INSURANCE NUMBER
            WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")

            'SURNAME
            WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")

            'NAME
            WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")

            'STREET AND NUMBER
            WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")

            'TOWN VILLAGE
            WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")

            'POST CODE
            WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")
            'EMAIL ADDRESS
            'WL("<mof:field key=""epr7m6t0r1c7d"">" & Trim(Ar(10)) & "</mof:field>")

            'GROSS WITHIN THE REPUBLIC OF CYPRUS
            WL("<mof:field key=""epr7m6t0r1c8"">" & CLng(Trim(Ar(12))) & "</mof:field>")

            'OUTSIDE THE REPUBLIC OF CYPRUS
            WL("<mof:field key=""epr7m6t0r1c9"">" & CLng(Trim(Ar(13))) & "</mof:field>")
            'ALLOWANCES/BENEFITS/COMMITIONS
            WL("<mof:field key=""epr7m6t0r1c10"">" & CLng(Trim(Ar(14))) & "</mof:field>")
            'TOTAL OF COLUMNS
            WL("<mof:field key=""epr7m6t0r1c11"">" & CLng(Trim(Ar(15))) & "</mof:field>")
            'TAXABLE FROM OTHER SOURCES
            'WL("<mof:field key=""epr7m6t0r1c11c"">" & CLng(Trim(Ar(15))) & "</mof:field>")

            'SOCIAL INSURANCE FUND
            WL("<mof:field key=""epr7m6t0r1c12"">" & CLng(Trim(Ar(16))) & "</mof:field>")

            'PROVIDENT FUND AND PENSION FUND
            WL("<mof:field key=""epr7m6t0r1c13"">" & CLng(Trim(Ar(17))) & "</mof:field>")

            'MEDICAL FUND
            WL("<mof:field key=""epr7m6t0r1c14"">" & CLng(Trim(Ar(18))) & "</mof:field>")

            'UNIONS
            WL("<mof:field key=""epr7m6t0r1c15"">" & CLng(Trim(Ar(19))) & "</mof:field>")

            'Life Insurance
            WL("<mof:field key=""epr7m6t0r1c15b"">" & CLng(Trim(Ar(44))) & "</mof:field>")

            'NON TAXABLE INCOME (INCLUDED IN TOTALS)
            WL("<mof:field key=""epr7m6t0r1c15c"">" & CLng(Trim(Ar(46))) & "</mof:field>")

            'Other Discounts
            WL("<mof:field key=""epr7m6t0r1c16"">" & CLng(Trim(Ar(20))) & "</mof:field>")

            'Total Discounts
            WL("<mof:field key=""epr7m6t0r1c17"">" & CLng(Trim(Ar(21))) & "</mof:field>")

            'TAXABLE INCOME
            WL("<mof:field key=""epr7m6t0r1c18"">" & CLng(Trim(Ar(22))) & "</mof:field>")

            'INCOME TAX
            WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")

            'SPECIAL CONTRIBUTION - gesi not FOR 2017
            'WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

            'EISFORA SYNTAKSIODOTIKON OFELIMATON (+xiron orfanon + tameio syntaksis - na elegxw an einai mesa)
            WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(CLng(Ar(47))) & "</mof:field>")

            '''
            'MEIOSI APOLAVON
            WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(CLng(Ar(48))) & "</mof:field>")
            'GESI NOT FOR 2017
            'WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
            'GESI NOT FOR 2017
            'WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")

            'DIAGRAFETE
            'WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")

            '''

            If Trim(Ar(26)) <> "" Then
                Dim S As String
                S = changeformtatodate(Trim(Ar(26)))
                WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
            End If
            If Trim(Ar(27)) <> "" Then
                Dim S As String
                S = changeformtatodate(Trim(Ar(27)))
                WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")

            End If
            WL("<mof:field key=""epr7m6t0r1c22"">" & CheckforZero(Trim(Ar(38))) & "</mof:field>")
            'WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
            WL("</mof:row>")
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try


    End Sub
#End Region

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
        IR7_2018(False, False, False, False, False)
    End Sub
    Private Sub IR7_2018(ByVal SendToPrinter As Boolean, ByVal File As Boolean, ByVal XMLCreation As Boolean, ByVal ShowInExcel As Boolean, ByVal BIKonSI As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet

        Dim Error1 As String
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        'D = DateAdd(DateInterval.Year, 1, D)
        Dim DissaBleRehire As Boolean = False

        If Me.CBDissableRehire.CheckState = CheckState.Checked Then
            dissablerehire = True

        End If
        Ds = Global1.Business.REPORT_IR7_4(PerGrp, FromCode, ToCode, D, True, ShowInExcel, BIKonSI, DissaBleRehire)


        '----Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        ' Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                'correct LOCAL Earnings , substract GESI from Total
                Dim BIKWithSI As Double = 0
                Dim BIKWithoutSI As Double = 0
                Dim Local As Double = 0
                Dim ENTOS As Double = 0
                Dim DirFees As Double = 0
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    BIKWithSI = DbNullToDouble(Ds.Tables(0).Rows(i).Item(39))
                    BIKWithoutSI = DbNullToDouble(Ds.Tables(0).Rows(i).Item(40))
                    Local = DbNullToDouble(Ds.Tables(0).Rows(i).Item(6))
                    DirFees = DbNullToDouble(Ds.Tables(0).Rows(i).Item(46))
                    If Local > 0 Then
                        ENTOS = Local - (BIKWithSI + BIKWithoutSI + DirFees)
                    Else
                        ENTOS = 0
                    End If

                    Ds.Tables(0).Rows(i).Item(6) = ENTOS
                    Ds.Tables(0).Rows(i).Item(8) = (BIKWithSI + BIKWithoutSI + DirFees)
                Next
                'Utils.ShowReport("IR7.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
                'Utils.ShowReport("IR72012.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter)
                Utils.ShowReport("IR7_2017.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter, "", False, False, "", True, 0)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then

                If CreateIR7File_2018(Ds) Then

                    If Not XMLCreation Then
                        MsgBox("File is Created - " & IR7FileDir & Ir7Filename, MsgBoxStyle.Information)
                    End If

                    GLB_XMLOriginFile = IR7FileDir & Ir7Filename

                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TestXML20182019ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestXML20182019ToolStripMenuItem.Click
        XmlFile2018_2019(False, False)
    End Sub
    Private Sub CreateXMLFile20182019SettingBIKNHSOnSocialInsuranceNHSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateXMLFile20182019SettingBIKNHSOnSocialInsuranceNHSToolStripMenuItem.Click
        XmlFile2018_2019(False, True)
    End Sub
    Private Sub TestXML20182019WithExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestXML20182019WithExcelToolStripMenuItem.Click
        XmlFile2018_2019(True, False)
    End Sub
    Private Sub TestXMLWithExcelSettingBIKNHSOnSocialInsuranceNHSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestXMLWithExcelSettingBIKNHSOnSocialInsuranceNHSToolStripMenuItem.Click
        XmlFile2018_2019(True, True)
    End Sub
    Private Sub XmlFile2018_2019(ByVal ShowAsExcel As Boolean, ByVal SetBIKonSI As Boolean)

        dtxl.Rows.Clear()

        Dim F As New FrmIR7File
        F.Owner = Me
        F.ShowDialog()
        If Me.TaxGiven = -1 Or Me.Original = -1 Then
            MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        Else

            IR7_2018(False, True, True, ShowAsExcel, SetBIKonSI)
            'Dim PerGrp As New cPrMsPeriodGroups
            'PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            'Dim TempGroup As New cPrMsTemplateGroup(PerGroup.TemGrpCode)
            'Dim MaxNumberOfPeriods As Integer
            'MaxnumberofPeriods = Global1.Business.FindnumberofPeriodsOnCompanyLevelForThisPeriodGroup(PerGroup, TempGroup)

            If GLB_XMLOriginFile <> "" Then
                'If ShowAsExcel Then
                '    Dim Ans As MsgBoxResult
                '    Ans = MsgBox("Continue with .xml file creation?", MsgBoxStyle.YesNo)
                '    If Ans = MsgBoxResult.No Then
                '        Exit Sub
                '    End If
                'End If


                CreateXMLFile_2018(False)
                If ShowAsExcel Then
                    LoadDataSetToExcel(MyDsxl, "ir7")
                End If
            Else
                MsgBox("Failed to create .xml File")
            End If
        End If
    End Sub
    Private Sub CreateXMLFile_2018(ByVal ShowAsExcel As Boolean)

        Dim Error1 As String = "IN"
        Dim Error2 As String = "IN"
        Cursor = Cursors.WaitCursor
        Try
            GlbCancelIr7 = False
            Dim F As New FrmXMLDestination
            F.Owner = Me
            F.ShowDialog()
            If GlbCancelIr7 = True Then
                MsgBox("The procedure was Canceled", MsgBoxStyle.Information)
                Exit Sub
            End If

            'If Me.txtFromFile.Text = "" Then
            '    MsgBox("Please Select Valid Source File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            'If Me.txtToFile.Text = "" Then
            '    MsgBox("Please Select Valid Destination File", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile


            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Error2 = Line
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"
                        Error1 = "before Header"
                        WriteIR7_2018_Header(Line)
                        Error1 = "After Header"
                    Case "2"
                        Lines = Lines + 1
                        Error1 = "before Lines " & Lines
                        WriteIR7_2018_LINE(Line)
                        Error1 = "After Lines"
                End Select

            Loop
            WL("</mof:grid>")
            WL("</mof:epr7-declaration>")
            WL("</mof:epr7-declarations>")


            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)

            If ShowAsExcel Then
                'LoadFromTextFileToGrid(FileName)
                LoadFromXmlToExcel(GLB_XMLDestinationFile)
            End If

        Catch ex As Exception

            Utils.ShowException(ex)
            MsgBox("Failed to create .xml File")
            MsgBox(Error1)
            MsgBox(Error2)
        End Try
        Cursor = Cursors.Default


    End Sub
  

    Public Sub LoadFromTextFileToGrid(ByVal SelectedFile As String)
        '   xxx()
        'Dim F As New FrmXMLToGrid
        'F.FilePath = IR7FileDir
        'F.FileName = Ir7Filename
        'F.ShowDialog()

        Cursor = Cursors.WaitCursor
        Try
            Dim F As New FrmXMLDestination
            F.Owner = Me
            F.ShowDialog()

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile


            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"
                        WriteIR7_2018_Header_ToDataset(Line)
                    Case "2"
                        Lines = Lines + 1
                        WriteIR7_2018_LINE_ToDataset(Line)
                End Select

            Loop

            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)


        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default

    End Sub

    Public Sub LoadFromXmlToExcel(ByVal SelectedFile As String)
        Dim F As New FrmXmlToExcel
        F.FilePath = SelectedFile
        F.ShowDialog()
    End Sub
    Public Sub InitDataTable()


        dt5 = New System.Data.DataTable("Employee")
        '0
        dt5.Columns.Add(New DataColumn("EmpLastName", System.Type.GetType("System.String")))
        '1
        dt5.Columns.Add(New DataColumn("EmpFirstName", System.Type.GetType("System.String")))
        '2
        dt5.Columns.Add(New DataColumn("EmpName", System.Type.GetType("System.String")))
        '3
        dt5.Columns.Add(New DataColumn("EmpTaxID", System.Type.GetType("System.String")))
        '4
        dt5.Columns.Add(New DataColumn("EmpIDType", System.Type.GetType("System.String")))
        '5
        dt5.Columns.Add(New DataColumn("EmpIDCard", System.Type.GetType("System.String")))
        '6
        dt5.Columns.Add(New DataColumn("Local", System.Type.GetType("System.Int32")))
        '7
        dt5.Columns.Add(New DataColumn("Abroad", System.Type.GetType("System.Int32")))
        '8
        dt5.Columns.Add(New DataColumn("Allowances", System.Type.GetType("System.Int32")))
        '9
        dt5.Columns.Add(New DataColumn("Total456", System.Type.GetType("System.Int32")))
        '10
        dt5.Columns.Add(New DataColumn("SI", System.Type.GetType("System.Int32")))
        '11
        dt5.Columns.Add(New DataColumn("PF", System.Type.GetType("System.Int32")))
        '12
        dt5.Columns.Add(New DataColumn("MF", System.Type.GetType("System.Int32")))
        '13
        dt5.Columns.Add(New DataColumn("UNION", System.Type.GetType("System.Int32")))
        '14
        dt5.Columns.Add(New DataColumn("OtherDisc", System.Type.GetType("System.Int32")))
        '15
        dt5.Columns.Add(New DataColumn("TotalDisc", System.Type.GetType("System.Int32")))
        '16
        dt5.Columns.Add(New DataColumn("Taxable", System.Type.GetType("System.Int32")))
        '17
        dt5.Columns.Add(New DataColumn("IT", System.Type.GetType("System.Double")))
        '18
        dt5.Columns.Add(New DataColumn("StartDate", System.Type.GetType("System.String")))
        '19
        dt5.Columns.Add(New DataColumn("LeaveDate", System.Type.GetType("System.String")))
        '20
        dt5.Columns.Add(New DataColumn("Adr1", System.Type.GetType("System.String")))
        '21
        dt5.Columns.Add(New DataColumn("Adr2", System.Type.GetType("System.String")))
        '22
        dt5.Columns.Add(New DataColumn("Adr3", System.Type.GetType("System.String")))
        '23
        dt5.Columns.Add(New DataColumn("PostCode", System.Type.GetType("System.String")))
        '24
        dt5.Columns.Add(New DataColumn("PensionNo", System.Type.GetType("System.String")))
        '25
        dt5.Columns.Add(New DataColumn("PensionType", System.Type.GetType("System.String")))
        '26
        dt5.Columns.Add(New DataColumn("SINumber", System.Type.GetType("System.String")))
        '27
        dt5.Columns.Add(New DataColumn("EmpCode", System.Type.GetType("System.String")))
        '28
        dt5.Columns.Add(New DataColumn("STDeduction", System.Type.GetType("System.Double")))
        '29
        dt5.Columns.Add(New DataColumn("STContribution", System.Type.GetType("System.Double")))
        '30
        dt5.Columns.Add(New DataColumn("SalaryPeriods", System.Type.GetType("System.Int32")))
        '31
        dt5.Columns.Add(New DataColumn("LifeInsurance", System.Type.GetType("System.Int32")))
        '32
        dt5.Columns.Add(New DataColumn("AllowancesBenefits", System.Type.GetType("System.Int32")))
        '33
        dt5.Columns.Add(New DataColumn("TaxableFromOther", System.Type.GetType("System.Int32")))
        '34
        dt5.Columns.Add(New DataColumn("NonTaxable", System.Type.GetType("System.Int32")))
        '35
        dt5.Columns.Add(New DataColumn("Syntaksiodotika", System.Type.GetType("System.Int32")))
        '36
        dt5.Columns.Add(New DataColumn("MeiwsiApolavon", System.Type.GetType("System.Double")))
        '37
        dt5.Columns.Add(New DataColumn("WidowAndOrphans", System.Type.GetType("System.Double")))
        '38
        dt5.Columns.Add(New DataColumn("PensionFund", System.Type.GetType("System.Int32")))

        '#2019
        '39
        dt5.Columns.Add(New DataColumn("BIKwithGESY", System.Type.GetType("System.Double")))
        '40
        dt5.Columns.Add(New DataColumn("BIKWithoutGESY", System.Type.GetType("System.Double")))
        '41
        dt5.Columns.Add(New DataColumn("GESYToSI", System.Type.GetType("System.Double")))
        '42
        dt5.Columns.Add(New DataColumn("GESYtoBIKDed", System.Type.GetType("System.Double")))
        '43
        dt5.Columns.Add(New DataColumn("GESYtoBIKCon", System.Type.GetType("System.Double")))



    End Sub
    Public Sub InitDataTable_Excel()
      
        dtxl = New System.Data.DataTable("Employee")
        '0
        dtxl.Columns.Add(New DataColumn("1. Inc No", System.Type.GetType("System.String")))
        '1
        dtxl.Columns.Add(New DataColumn("2.1 T.I.C", System.Type.GetType("System.String")))
        '2
        dtxl.Columns.Add(New DataColumn("2.2A Identificaton Type", System.Type.GetType("System.String")))
        '3
        dtxl.Columns.Add(New DataColumn("2.2B Number", System.Type.GetType("System.String")))
        '4
        dtxl.Columns.Add(New DataColumn("2.3 Social Insurance Number", System.Type.GetType("System.String")))
        '5
        dtxl.Columns.Add(New DataColumn("3.1A Name", System.Type.GetType("System.String")))
        '6
        dtxl.Columns.Add(New DataColumn("3.1B Surname", System.Type.GetType("System.String")))
        '7
        dtxl.Columns.Add(New DataColumn("3.2A Street No", System.Type.GetType("System.String")))
        '8
        dtxl.Columns.Add(New DataColumn("3.2B Town", System.Type.GetType("System.String")))
        '9
        dtxl.Columns.Add(New DataColumn("3.2C Post Code", System.Type.GetType("System.String")))
        '10
        dtxl.Columns.Add(New DataColumn("3.4 Category Of Employee", System.Type.GetType("System.String")))
        '11
        dtxl.Columns.Add(New DataColumn("4.1 Gross Emoluments - Within the republic", System.Type.GetType("System.String")))
        '12
        dtxl.Columns.Add(New DataColumn("5 Gross emoluments - Outside the republic", System.Type.GetType("System.String")))
        '13
        dtxl.Columns.Add(New DataColumn("6.1 Allowances,Benefits,Commitions and Benefits In Kind - With contribution to S.I.F.", System.Type.GetType("System.String")))
        '14
        dtxl.Columns.Add(New DataColumn("6.2 Allowances,Benefits,Commitions and Benefits In Kind - Without contribution to S.I.F.", System.Type.GetType("System.String")))
        '15
        dtxl.Columns.Add(New DataColumn("7. Total of Columns 4,5,6", System.Type.GetType("System.String")))
        '16
        dtxl.Columns.Add(New DataColumn("8. Employee Contribution - S.I.F.", System.Type.GetType("System.String")))
        '17
        dtxl.Columns.Add(New DataColumn("9. Employee Contribution - Prov and Pension fund", System.Type.GetType("System.String")))
        '18
        dtxl.Columns.Add(New DataColumn("10. Employee Contribution - Medical Fund", System.Type.GetType("System.String")))
        '19
        dtxl.Columns.Add(New DataColumn("11.Employee Contribution - Trade Unions", System.Type.GetType("System.String")))
        '20
        dtxl.Columns.Add(New DataColumn("11.2 Life Insurance Premiums", System.Type.GetType("System.String")))
        '21
        dtxl.Columns.Add(New DataColumn("11.3 Non Taxable Income", System.Type.GetType("System.String")))
        '22
        dtxl.Columns.Add(New DataColumn("12. Other Deductions as Per form T.D.59A", System.Type.GetType("System.String")))
        '23
        dtxl.Columns.Add(New DataColumn("13. Total Deductions (8 to 12)", System.Type.GetType("System.String")))
        '24
        dtxl.Columns.Add(New DataColumn("14. Chargable Income", System.Type.GetType("System.String")))
        '25
        dtxl.Columns.Add(New DataColumn("15.1 Tax Withheld", System.Type.GetType("System.String")))
        '26
        dtxl.Columns.Add(New DataColumn("15.3 Pension + Orphans Fund", System.Type.GetType("System.String")))
        '27
        dtxl.Columns.Add(New DataColumn("15.4 Reduction of Emoluments Fund", System.Type.GetType("System.String")))
        '28
        dtxl.Columns.Add(New DataColumn("15.2 G.H.S. Contribution of Employees Payable To Other DPNT (NHS fund to S.I.)", System.Type.GetType("System.String")))
        '29
        dtxl.Columns.Add(New DataColumn("15.5 G.H.S. Contribution of Employees Payable To Tax DPNT", System.Type.GetType("System.String")))
        '30
        dtxl.Columns.Add(New DataColumn("15.6 G.H.S. Contribution of Employer Payable To Tax DPNT", System.Type.GetType("System.String")))
        '31
        dtxl.Columns.Add(New DataColumn("16.1 Commencement of Employment Date", System.Type.GetType("System.String")))
        '32
        dtxl.Columns.Add(New DataColumn("16.2 Termination of Employment Date", System.Type.GetType("System.String")))
        '33
        dtxl.Columns.Add(New DataColumn("Employee Code", System.Type.GetType("System.String")))




    End Sub

    Public Sub WriteIR7_2018_Header_ToDataset(ByVal Line As String)
        '---------------------------------------------
        'RECORD 01
        '---------------------------------------------
        '0 1
        '1 Year
        '2 TaxID
        '3
        '4
        '5 SIReg No
        '6  CompanyName
        '7
        '8  ComAdr1 = Company.Address1
        '9  ComAdr2 = Company.Address2
        '10  ComPost = Company.Address3
        '11  Str03 = Str03 & FixInteger((i), 5) & PP
        '12 TOTAL_Local
        '13 TOTAL_Abroad
        '14 TOTAL_Allowances
        '15 TOTAL_Total456
        '16 TOTAL_SI
        '17 TOTAL_PF
        '18 TOTAL_MF, 9) & PP
        '19 TOTAL_UNION, 9) & PP
        '20 TOTAL_OtherDisc, 9) & PP
        '21 TOTAL_TotalDisc, 9) & PP
        '22 TOTAL_Taxable, 10) & PP
        '23 TOTAL_IT, 11) & PP
        '24 0
        '25 0
        '26 
        '27
        '28 TaxGiven, 11) & PP
        '29 0, 11) & PP
        '30 Company.AccountantTIC
        '31 TIC1.PadRight(9, " ") & PP
        '32 TIC2.PadRight(9, " ") & PP
        '33 TIC3.PadRight(9, " ") & PP
        '34 TIC4.PadRight(9, " ") & PP
        '35 Company.AccIdentity & PP
        '36 Company.TICCategory & PP
        '37 Company.TICType & PP
        '38 & "0".PadLeft(7, "0") & PP
        '39 & Original & PP
        '40 TOTAL_SPDeduction, 11) & PP
        '41 TOTAL_SPContribution, 11) & PP
        '42 TOTAL_SpecialTax, 11) & PP
        '43 AccountantTitle & PP
        '44 AccountantTIC & PP
        '45 TOTAL_LifeInsurance, 11) & PP
        '46 TOTAL_AllowanceBenefits, 11) & PP
        '47 TOTAL_TaxableFromOther, 11) & PP
        '48 TOTAL_NonTaxable, 11) & PP
        '49 TOTAL_Syntaksiodotika, 11) & PP
        '50 TOTAL_MiwsiApolavon, 11) & PP
        '51 TOTAL_WidowOrphans, 11) & PP
        '52 TOTAL_PensionFund, 11) & PP

        '#2019 GESY
        '53 TOTAL_BIKWithSI, 11) & PP
        '54 TOTAL_BIKWithoutSI, 11) & PP
        '55 TOTAL_GESYtoSI, 11) & PP
        '56 TOTAL_GESYDed, 11) & PP
        '57 TOTAL_GESYCon, 11)



        Dim Ar() As String
        Dim Year As String
        Ar = Line.Split("|")
        Year = Ar(1)

        WL("<?xml version=""1.0"" encoding=""UTF-8""?>")
        WL("<mof:epr7-declarations xsi:schemaLocation=""http://www.mof.gov.cy http://taxisnet.mof.gov.cy/schema/cy-epr7-declaration.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:mof=""http://www.mof.gov.cy"">")
        WL("<mof:epr7-declaration version=""" & Year & "-1.0"" taxpayer=""" & Ar(2) & """>")
        'WL("<mof:period to=""2012-12-31"" from=""2012-01-01""/>")
        WL("<mof:period to=""" & Year & "-12-31"" from=""" & Year & "-01-01""/>")

        '#2019 Forologiko Etos
        WL("<mof:field key=""m1t0r1c2"">" & Year & "</mof:field>")
        '#2019 Forologikos Minas
        WL("<mof:field key=""m1t0r1c3"">" & "13" & "</mof:field>")

        'Arxiki Dilosi/Sympliromatiki
        WL("<mof:field key=""epr7m1t0r2c2"">" & Trim(Ar(39)) & "</mof:field>")
        'Eixa Yppalilous 
        WL("<mof:field key=""epr7m1t0r2c3"">" & 0 & "</mof:field>")
        ' Aritmos Forologkis Taytotitas
        WL("<mof:field key=""epr7m1t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        ' Social Insurance No
        WL("<mof:field key=""epr7m1t0r2c1"">" & Trim(Ar(5)) & "</mof:field>")
        'Company Name
        WL("<mof:field key=""epr7m1tar1c1"">" & Trim(Ar(6)) & "</mof:field>")
        ' Address 1
        WL("<mof:field key=""epr7m1tbr1c1"">" & Trim(Ar(8)) & "</mof:field>")
        'Address 2
        WL("<mof:field key=""epr7m1tbr2c1"">" & Trim(Ar(9)) & "</mof:field>")
        'Address 3 - POST CODE
        WL("<mof:field key=""epr7m1tbr2c2"">" & Trim(Ar(10)) & "</mof:field>")
        'Akatharistes Apolaves ENTOS
        WL("<mof:field key=""epr7m3t0r1c1"">" & CLng(Ar(12)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c1"">" & CLng(Ar(12)) & "</mof:field>")
        'Akatharistes Apolaves EKTOS
        WL("<mof:field key=""epr7m3t0r2c1"">" & CLng(Ar(13)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c2"">" & CLng(Ar(13)) & "</mof:field>")
        ''Xorigimata Ofeloi - Promithies
        'WL("<mof:field key=""epr7m3t0r3c1"">" & CLng(Ar(14)) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c3"">" & CLng(Ar(14)) & "</mof:field>")

        '#2019
        '54 BIK_withSI
        WL("<mof:field key=""epr7m3t0r3c1"">" & StringtoDecimal2(CLng(Ar(54))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c3"">" & StringtoDecimal2(CLng(Ar(54))) & "</mof:field>")
        '55 BIK_WithoutSI
        WL("<mof:field key=""epr7m3t0r3c2"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c3b"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")

        ' Synolo twn triwn pio panw
        WL("<mof:field key=""epr7m3t0r4c1"">" & CLng(Ar(15)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c4"">" & CLng(Ar(15)) & "</mof:field>")



        ' Tameio Koinonikon Asfalisewn
        WL("<mof:field key=""epr7m3t0r5c1"">" & CLng(Ar(16)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c5"">" & CLng(Ar(16)) & "</mof:field>")
        'Tameia Syntaksewn kai Pronoias
        WL("<mof:field key=""epr7m3t0r6c1"">" & CLng(Ar(17)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c6"">" & CLng(Ar(17)) & "</mof:field>")
        'Tameio Ygeias
        WL("<mof:field key=""epr7m3t0r7c1"">" & CLng(Ar(18)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c7"">" & CLng(Ar(18)) & "</mof:field>")
        'Syntexnies
        WL("<mof:field key=""epr7m3t0r8c1"">" & CLng(Ar(19)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8"">" & CLng(Ar(19)) & "</mof:field>")
        'Life Insurance
        WL("<mof:field key=""epr7m3t0r8c2"">" & CLng(Ar(45)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8b"">" & CLng(Ar(45)) & "</mof:field>")

        'First Employeement
        WL("<mof:field key=""epr7m3t0r8c3"">" & CLng(0) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8c"">" & CLng(0) & "</mof:field>")

        'Other Discounts
        WL("<mof:field key=""epr7m3t0r9c1"">" & CLng(Ar(20)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c9"">" & CLng(Ar(20)) & "</mof:field>")
        'Total Discounts
        WL("<mof:field key=""epr7m3t0r10c1"">" & CLng(Ar(21)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c10"">" & CLng(Ar(21)) & "</mof:field>")
        'Total Taxable Income
        WL("<mof:field key=""epr7m3t0r11c1"">" & CLng(Ar(22)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c11"">" & CLng(Ar(22)) & "</mof:field>")


        ' PARAKRATISEIS FORON KAI EISFORON
        'Income Tax Amount
        WL("<mof:field key=""epr7m3t0r12c1"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c12"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")

        'ektakti eisfora Aksiomatouxon Dimosiou Tomea - NOT 2017
        'WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

        'Eisfora Syntaksiodotikon Ofelimaton - Pension fund + Widow and Orphans
        WL("<mof:field key=""epr7m3t0r14c1"">" & StringtoDecimal2(CLng(Ar(49))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c14"">" & StringtoDecimal2(CLng(Ar(49))) & "</mof:field>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Meiosi Apolavon
        WL("<mof:field key=""epr7m3t0r15c1"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c15"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")

        'Ektakti Eisfora idiotikou (Ergazomenos) - NOT 2017
        'WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        'Ektakti Eisfora idiotikou (Ergodotis) - NOT 2017
        'WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        ''''''''''''''''''''''''''''''''''''''''''''''''
        '57 GESY_toSI
        WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")

        '58 BIKGESY_Deduction
        WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(56))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(56))) & "</mof:field>")

        '59 BIKGESY_Contribution
        WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(57))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(57))) & "</mof:field>")





        ' Synolo Emvasmaton Forou Eisodimatos
        WL("<mof:field key=""epr7m4t0r1c1"">" & StringtoDecimal2(CLng(Ar(28))) & "</mof:field>")

        ' Synolo GESI Not For 2017
        'WL("<mof:field key=""epr7m4t0r2c1"">" & StringtoDecimal2(CLng(Ar(29))) & "</mof:field>")

        ' Synolo Eisforas Syntaksiodotikon Ofelimaton
        WL("<mof:field key=""epr7m4t0r3c1"">" & StringtoDecimal2(CLng(Ar(49))) & "</mof:field>")

        ' Synolo Meiosi Apolabon kai Syntakseon
        WL("<mof:field key=""epr7m4t0r4c1"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")

        ' Synolo Embasmaton GESI - Not 2017
        'WL("<mof:field key=""epr7m4t0r5c1"">" & StringtoDecimal2(CLng(Ar(42))) & "</mof:field>")
        ''''

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                              MEROS 5 DILOSI
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim T As String
        T = Trim(Ar(35))
        If T = 1 Then
            If Trim(Ar(31)) <> "" Then
                WL("<mof:field key=""epr7m2tar1c1"">" & Trim(Ar(31)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tar2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 2 Then
            If Trim(Ar(32)) <> "" Then
                WL("<mof:field key=""epr7m2tbr1c1"">" & Trim(Ar(32)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tbr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 3 Then
            If Trim(Ar(33)) <> "" Then
                WL("<mof:field key=""epr7m2tcr1c1"">" & Trim(Ar(33)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tcr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        End If

        WL("<mof:field key=""epr7m5t0r1c1"">" & Trim(Ar(43)) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r1c2"">" & Trim(Ar(44)) & "</mof:field>")


        WL("<mof:field key=""epr7m5t0r2c1"">" & Ar(35) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r3c1"">" & Ar(36) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r4c1"">" & Ar(37) & "</mof:field>")



        WL("<mof:grid id=""epr7m6t0r1"">")


    End Sub


    Public Sub WriteIR7_2018_LINE_ToDataset(ByVal Line As String)

        '0 2
        '1 Ds.Tables(2).Rows(0).Item(0) & PP
        '2 .Item(C_EmpIDType)
        '3 C_EmpIDType) & PP
        '4 C_EmpIDCard).ToString.PadRight(15) & PP
        '5 C_EmpSINo).Padright(15, " ") & PP
        '6 LastName.PadRight(35, " ") & PP
        '7 FirstName = .Item(C_EmpFirstName)
        '8 Adr1 = .Item(C_Adr1)
        '9 Adr2 = .Item(C_Adr2)
        '10 PostCode = .Item(C_PostCode)
        '11 FixInteger((i + 1), 5) & PP
        '12 (C_Local), 10) & PP
        '13 (C_Abroad), 9) & PP
        '14 (C_Allowances), 9) & PP
        '15 (C_Total456), 10) & PP
        '16 (C_SI), 9) & PP
        '17 (C_PF), 9) & PP
        '18 (C_MF), 9) & PP
        '19 (C_UNION), 9) & PP
        '20 (C_OtherDisc), 9) & PP
        '21 (C_TotalDisc), 9) & PP
        '22 (C_Taxable), 10) & PP
        '23 C_IT), 11) & PP
        '24  FixNumber(0, 11) & PP
        '25  FixNumber(0, 11) & PP
        '26 (C_StartDate))) <> "" Then
        '27 (C_LeaveDate))) <> "" Then
        '28 "".PadLeft(11, " ") & PP
        '29 "".PadLeft(11, " ") & PP
        '30 "".PadLeft(11, " ") & PP
        '31 "".PadLeft(9, " ") & PP
        '32 "".PadLeft(9, " ") & PP
        '33 "".PadLeft(9, " ") & PP
        '34 "".PadLeft(9, " ") & PP
        '35 "".PadLeft(1, " ") & PP
        '36 "".PadLeft(1, " ") & PP
        '37 "".PadLeft(1, " ") & PP
        '38 PensionNo.PadLeft(7, "0") & PP
        '39 PensionType.PadLeft(1, "0") & PP
        '40 (C_EmpSpecialTaxDed), 11) & PP
        '41 (C_EmpSpecialTaxCon), 11) & PP
        '42 (C_SalaryPeriods) > 13 Then
        '43 (C_EmpIDType) = " " Then
        '44 (C_LifeInsurance), 11) & PP
        '45 (C_TaxableFromOther)), 11) & PP
        '46 (C_NonTaxable)), 11) & PP
        '47 (C_Syntaksiodotika)), 11) & PP
        '48 (C_MiwsiApolavon)), 11) & PP
        '49  (C_WidowOrphans)), 11) & PP
        '50 (C_PensionFund)), 11) & PP

        '#2019 GESY
        '51 (C_BIK_withSI)), 11) & PP
        '52 (C_BIK_withoutSI)), 11) & PP
        '53 (C_GESYtoSI)), 11) & PP
        '54 (C_GESYtoBIKDed)), 11) & PP
        '55 (C_GESYtoBIKCon)), 11)
        '-------------------------------------






        Dim Ar() As String
        Ar = Line.Split("|")

        WL("<mof:row number=""" & CLng(Ar(11)) & """>")
        If Trim(Ar(2)) <> "" Then
            'TIC Number
            WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        Else
            If Ar(43) = 1 Then
                'ARITHMOS TAYTOPOIISIS
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Ô" & "</mof:field>")
            ElseIf Ar(43) = 2 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Á" & "</mof:field>")
            ElseIf Ar(43) = 3 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Ö" & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")
            'OTHER COUNTRY TIC
            WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
        End If

        'SOCIAL INSURANCE NUMBER
        WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")

        'SURNAME
        WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")

        'NAME
        WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")

        'STREET AND NUMBER
        WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")

        'TOWN VILLAGE
        WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")

        'POST CODE
        WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")
        'EMAIL ADDRESS
        'WL("<mof:field key=""epr7m6t0r1c7d"">" & Trim(Ar(10)) & "</mof:field>")

        'GROSS WITHIN THE REPUBLIC OF CYPRUS
        WL("<mof:field key=""epr7m6t0r1c8"">" & CLng(Trim(Ar(12))) & "</mof:field>")

        'OUTSIDE THE REPUBLIC OF CYPRUS
        WL("<mof:field key=""epr7m6t0r1c9"">" & CLng(Trim(Ar(13))) & "</mof:field>")

        'ALLOWANCES/BENEFITS/COMMITIONS
        '51 (C_BIK_withSI)), 11) & PP
        '52 (C_BIK_withoutSI)), 11) & PP

        WL("<mof:field key=""epr7m6t0r1c10"">" & CLng(Trim(Ar(51))) & "</mof:field>")

        WL("<mof:field key=""epr7m6t0r1c10b"">" & CLng(Trim(Ar(52))) & "</mof:field>")







        'TOTAL OF COLUMNS
        WL("<mof:field key=""epr7m6t0r1c11"">" & CLng(Trim(Ar(15))) & "</mof:field>")
        'TAXABLE FROM OTHER SOURCES
        'WL("<mof:field key=""epr7m6t0r1c11c"">" & CLng(Trim(Ar(15))) & "</mof:field>")

        'SOCIAL INSURANCE FUND
        WL("<mof:field key=""epr7m6t0r1c12"">" & CLng(Trim(Ar(16))) & "</mof:field>")

        'PROVIDENT FUND AND PENSION FUND
        WL("<mof:field key=""epr7m6t0r1c13"">" & CLng(Trim(Ar(17))) & "</mof:field>")

        'MEDICAL FUND
        WL("<mof:field key=""epr7m6t0r1c14"">" & CLng(Trim(Ar(18))) & "</mof:field>")

        'UNIONS
        WL("<mof:field key=""epr7m6t0r1c15"">" & CLng(Trim(Ar(19))) & "</mof:field>")

        'Life Insurance
        WL("<mof:field key=""epr7m6t0r1c15b"">" & CLng(Trim(Ar(44))) & "</mof:field>")

        'NON TAXABLE INCOME (INCLUDED IN TOTALS)
        WL("<mof:field key=""epr7m6t0r1c15c"">" & CLng(Trim(Ar(46))) & "</mof:field>")

        'Other Discounts
        WL("<mof:field key=""epr7m6t0r1c16"">" & CLng(Trim(Ar(20))) & "</mof:field>")

        'Total Discounts
        WL("<mof:field key=""epr7m6t0r1c17"">" & CLng(Trim(Ar(21))) & "</mof:field>")

        'TAXABLE INCOME
        WL("<mof:field key=""epr7m6t0r1c18"">" & CLng(Trim(Ar(22))) & "</mof:field>")

        'INCOME TAX
        WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")

        'SPECIAL CONTRIBUTION - gesi not FOR 2017
        'WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

        'EISFORA SYNTAKSIODOTIKON OFELIMATON (+xiron orfanon + tameio syntaksis - na elegxw an einai mesa)
        WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(CLng(Ar(47))) & "</mof:field>")

        '''
        'MEIOSI APOLAVON
        WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(CLng(Ar(48))) & "</mof:field>")

        'GESI NOT FOR 2017
        'WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        'GESI NOT FOR 2017
        'WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")

        'DIAGRAFETE
        'WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")


        '53 (C_GESYtoSI)), 11) & PP
        WL("<mof:field key=""epr7m6t0r1c19b"">" & Ar(53) & "</mof:field>")
        '54 (C_GESYtoBIKDed)), 11) & PP
        WL("<mof:field key=""epr7m6t0r1c19e"">" & Ar(54) & "</mof:field>")
        '55 (C_GESYtoBIKCon)), 11)
        WL("<mof:field key=""epr7m6t0r1c19f"">" & Ar(55) & "</mof:field>")

        '''

        If Trim(Ar(26)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(26)))
            WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
        End If
        If Trim(Ar(27)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(27)))
            WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")

        End If
        WL("<mof:field key=""epr7m6t0r1c22"">" & CheckforZero(Trim(Ar(38))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
        WL("</mof:row>")



    End Sub

    Private Sub TestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Dim F As New FrmIR61_2019
        Dim PerGrp As New cPrMsPeriodGroups
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        F.PerGroup = PerGrp
        F.TempGroupCode = PerGrp.TemGrpCode
        F.Owner = Me
        F.ShowDialog()
    End Sub

    Public Sub WriteIR7_2018_Header(ByVal Line As String)
        '---------------------------------------------
        'RECORD 01
        '---------------------------------------------
        '0 1
        '1 Year
        '2 TaxID
        '3
        '4
        '5 SIReg No
        '6  CompanyName
        '7
        '8  ComAdr1 = Company.Address1
        '9  ComAdr2 = Company.Address2
        '10  ComPost = Company.Address3
        '11  Str03 = Str03 & FixInteger((i), 5) & PP
        '12 TOTAL_Local
        '13 TOTAL_Abroad
        '14 TOTAL_Allowances
        '15 TOTAL_Total456
        '16 TOTAL_SI
        '17 TOTAL_PF
        '18 TOTAL_MF, 9) & PP
        '19 TOTAL_UNION, 9) & PP
        '20 TOTAL_OtherDisc, 9) & PP
        '21 TOTAL_TotalDisc, 9) & PP
        '22 TOTAL_Taxable, 10) & PP
        '23 TOTAL_IT, 11) & PP
        '24 0
        '25 0
        '26 
        '27
        '28 TaxGiven, 11) & PP
        '29 0, 11) & PP
        '30 Company.AccountantTIC
        '31 TIC1.PadRight(9, " ") & PP
        '32 TIC2.PadRight(9, " ") & PP
        '33 TIC3.PadRight(9, " ") & PP
        '34 TIC4.PadRight(9, " ") & PP
        '35 Company.AccIdentity & PP
        '36 Company.TICCategory & PP
        '37 Company.TICType & PP
        '38 & "0".PadLeft(7, "0") & PP
        '39 & Original & PP
        '40 TOTAL_SPDeduction, 11) & PP
        '41 TOTAL_SPContribution, 11) & PP
        '42 TOTAL_SpecialTax, 11) & PP
        '43 AccountantTitle & PP
        '44 AccountantTIC & PP
        '45 TOTAL_LifeInsurance, 11) & PP
        '46 TOTAL_AllowanceBenefits, 11) & PP
        '47 TOTAL_TaxableFromOther, 11) & PP
        '48 TOTAL_NonTaxable, 11) & PP
        '49 TOTAL_Syntaksiodotika, 11) & PP
        '50 TOTAL_MiwsiApolavon, 11) & PP
        '51 TOTAL_WidowOrphans, 11) & PP
        '52 TOTAL_PensionFund, 11) & PP

        '#2019 GESY
        '53 TOTAL_BIKWithSI, 11) & PP
        '54 TOTAL_BIKWithoutSI, 11) & PP
        '55 TOTAL_GESYtoSI, 11) & PP
        '56 TOTAL_GESYDed, 11) & PP
        '57 TOTAL_GESYCon, 11)


        Dim OtherDiscounts As Long

        Dim Ar() As String
        Dim Year As String
        Ar = Line.Split("|")
        Year = Ar(1)

        Dim A1 As Double = CLng(Ar(20))
        Dim A2 As Double = StringtoDecimal2ReturnDouble(Ar(50))
        OtherDiscounts = A1 + A2
        OtherDiscounts = StringtoInteger(OtherDiscounts)


        WL("<?xml version=""1.0"" encoding=""UTF-8""?>")
        WL("<mof:epr7-declarations xsi:schemaLocation=""http://www.mof.gov.cy http://taxisnet.mof.gov.cy/schema/cy-epr7-declaration.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:mof=""http://www.mof.gov.cy"">")
        WL("<mof:epr7-declaration version=""" & Year & "-1.0"" taxpayer=""" & Ar(2) & """>")
        'WL("<mof:period to=""2012-12-31"" from=""2012-01-01""/>")
        WL("<mof:period to=""" & Year & "-12-31"" from=""" & Year & "-01-01""/>")

        '#2019 Forologiko Etos
        WL("<mof:field key=""epr7m1t0r1c2"">" & Year & "</mof:field>")
        '#2019 Forologikos Minas
        WL("<mof:field key=""epr7m1t0r1c3"">" & "13" & "</mof:field>")
        '#2019 Imerominia Katavolis misthon
        WL("<mof:field key=""epr7m1t0r1c4"">" & "31/12/" & Year & "</mof:field>")

        'Arxiki Dilosi/Sympliromatiki
        WL("<mof:field key=""epr7m1t0r2c2"">" & Trim(Ar(39)) & "</mof:field>")
        'Eixa Yppalilous 
        WL("<mof:field key=""epr7m1t0r2c3"">" & 0 & "</mof:field>")
        ' Aritmos Forologkis Taytotitas
        WL("<mof:field key=""epr7m1t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        ' Social Insurance No
        WL("<mof:field key=""epr7m1t0r2c1"">" & Trim(Ar(5)) & "</mof:field>")
        'Company Name
        WL("<mof:field key=""epr7m1tar1c1"">" & Trim(Ar(6)) & "</mof:field>")
        ' Address 1
        WL("<mof:field key=""epr7m1tbr1c1"">" & Trim(Ar(8)) & "</mof:field>")
        'Address 2
        If Trim(Ar(9)) <> "" Then
            WL("<mof:field key=""epr7m1tbr2c1"">" & Trim(Ar(9)) & "</mof:field>")
        End If

        'Address 3 - POST CODE
        WL("<mof:field key=""epr7m1tbr2c2"">" & Trim(Ar(10)) & "</mof:field>")
        'Akatharistes Apolaves ENTOS

        Dim BIKWithSI As Long = StringtoInteger(Ar(53)) / 100
        Dim BIKWithoutSI As Long = StringtoInteger(Ar(54)) / 100

        Dim Entos As Long = CLng(Ar(12))
        If Entos > 0 Then
            Entos = Entos - (BIKWithSI + BIKWithoutSI)
        End If


        WL("<mof:field key=""epr7m3t0r1c1"">" & Entos & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c1"">" & Entos & "</mof:field>")
        'Akatharistes Apolaves EKTOS
        WL("<mof:field key=""epr7m3t0r2c1"">" & CLng(Ar(13)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c2"">" & CLng(Ar(13)) & "</mof:field>")
        ''Xorigimata Ofeloi - Promithies
        'WL("<mof:field key=""epr7m3t0r3c1"">" & CLng(Ar(14)) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c3"">" & CLng(Ar(14)) & "</mof:field>")
        'Directors fees for Galatariotis ************************** for 2018
        ' Ar(54) = Ar(14)
        '************************************
        '#2019
        '54 BIK_withSI

        WL("<mof:field key=""epr7m3t0r3c1"">" & BIKWithSI & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c3"">" & BIKWithSI & "</mof:field>")
        '55 BIK_WithoutSI
        WL("<mof:field key=""epr7m3t0r3c2"">" & BIKWithoutSI & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c3b"">" & BIKWithoutSI & "</mof:field>")

        'Dim BIKWithSI As Long = CLng(Ar(53))
        'Dim BIKWithoutSI As Long = CLng(Ar(54))

        'Dim TotalEmolumens As Long = CLng(Ar(15))
        'TotalEmolumens = TotalEmolumens + BIKWithSI + BIKWithoutSI

        ' Synolo twn triwn pio panw
        WL("<mof:field key=""epr7m3t0r4c1"">" & CLng(Ar(15)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c4"">" & CLng(Ar(15)) & "</mof:field>")



        ' Tameio Koinonikon Asfalisewn
        WL("<mof:field key=""epr7m3t0r5c1"">" & CLng(Ar(16)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c5"">" & CLng(Ar(16)) & "</mof:field>")
        'Tameia Syntaksewn kai Pronoias
        WL("<mof:field key=""epr7m3t0r6c1"">" & CLng(Ar(17)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c6"">" & CLng(Ar(17)) & "</mof:field>")
        'Tameio Ygeias
        WL("<mof:field key=""epr7m3t0r7c1"">" & CLng(Ar(18)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c7"">" & CLng(Ar(18)) & "</mof:field>")
        'Syntexnies
        WL("<mof:field key=""epr7m3t0r8c1"">" & CLng(Ar(19)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8"">" & CLng(Ar(19)) & "</mof:field>")
        'Life Insurance
        WL("<mof:field key=""epr7m3t0r8c2"">" & CLng(Ar(45)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8b"">" & CLng(Ar(45)) & "</mof:field>")

        'First Employeement
        WL("<mof:field key=""epr7m3t0r8c3"">" & CLng(0) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c8c"">" & CLng(0) & "</mof:field>")

        'Other Discounts

        WL("<mof:field key=""epr7m3t0r9c1"">" & CLng(OtherDiscounts) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c9"">" & CLng(OtherDiscounts) & "</mof:field>")

        'Total Discounts
        WL("<mof:field key=""epr7m3t0r10c1"">" & CLng(Ar(21)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c10"">" & CLng(Ar(21)) & "</mof:field>")
        'Total Taxable Income
        WL("<mof:field key=""epr7m3t0r11c1"">" & CLng(Ar(22)) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c11"">" & CLng(Ar(22)) & "</mof:field>")


        ' PARAKRATISEIS FORON KAI EISFORON
        'Income Tax Amount
        WL("<mof:field key=""epr7m3t0r12c1"">" & StringtoDecimal2((Ar(23))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c12"">" & StringtoDecimal2((Ar(23))) & "</mof:field>")

        'ektakti eisfora Aksiomatouxon Dimosiou Tomea - NOT 2017
        'WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

        'Eisfora Syntaksiodotikon Ofelimaton - Pension fund + Widow and Orphans
        WL("<mof:field key=""epr7m3t0r14c1"">" & StringtoDecimal2(CLng(Ar(49))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c14"">" & StringtoDecimal2(CLng(Ar(49))) & "</mof:field>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Meiosi Apolavon
        WL("<mof:field key=""epr7m3t0r15c1"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c15"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")

        'Ektakti Eisfora idiotikou (Ergazomenos) - NOT 2017
        'WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        'Ektakti Eisfora idiotikou (Ergodotis) - NOT 2017
        'WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        'WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")
        ''''''''''''''''''''''''''''''''''''''''''''''''
        '57 GESY_toSI
        WL("<mof:field key=""epr7m3t0r13c1"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c13"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")

        '58 BIKGESY_Deduction
        WL("<mof:field key=""epr7m3t0r16c1"">" & StringtoDecimal2(CLng(Ar(57))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c16"">" & StringtoDecimal2(CLng(Ar(57))) & "</mof:field>")

        '59 BIKGESY_Contribution
        WL("<mof:field key=""epr7m3t0r17c1"">" & StringtoDecimal2(CLng(Ar(56))) & "</mof:field>")
        WL("<mof:field key=""epr7m6t0r2c17"">" & StringtoDecimal2(CLng(Ar(56))) & "</mof:field>")





        ' Synolo Emvasmaton Forou Eisodimatos
        'ektos()
        '#2019
        '#2019 WL("<mof:field key=""epr7m4t0r1c1"">" & StringtoDecimal2(CLng(Ar(28))) & "</mof:field>")

        ' Synolo GESI Not For 2017
        'WL("<mof:field key=""epr7m4t0r2c1"">" & StringtoDecimal2(CLng(Ar(29))) & "</mof:field>")

        ' Synolo Eisforas Syntaksiodotikon Ofelimaton
        '#2019 WL("<mof:field key=""epr7m4t0r3c1"">" & StringtoDecimal2(CLng(Ar(49))) & "</mof:field>")

        ' Synolo Meiosi Apolabon kai Syntakseon
        '#2019 WL("<mof:field key=""epr7m4t0r4c1"">" & StringtoDecimal2(CLng(Ar(50))) & "</mof:field>")

        ' Synolo Embasmaton GESI - Not 2017
        'WL("<mof:field key=""epr7m4t0r5c1"">" & StringtoDecimal2(CLng(Ar(42))) & "</mof:field>")
        ''''

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                              MEROS 5 DILOSI
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim T As String
        T = Trim(Ar(35))
        If T = 1 Then
            If Trim(Ar(31)) <> "" Then
                WL("<mof:field key=""epr7m2tar1c1"">" & Trim(Ar(31)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tar2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 2 Then
            If Trim(Ar(32)) <> "" Then
                WL("<mof:field key=""epr7m2tbr1c1"">" & Trim(Ar(32)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tbr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        ElseIf T = 3 Then
            If Trim(Ar(33)) <> "" Then
                WL("<mof:field key=""epr7m2tcr1c1"">" & Trim(Ar(33)) & "</mof:field>")
            End If
            'WL("<mof:field key=""epr7m2tcr2c1"">" & Trim(Ar(31)) & "</mof:field>")
        End If

        WL("<mof:field key=""epr7m5t0r1c1"">" & Trim(Ar(43)) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r1c2"">" & Trim(Ar(44)) & "</mof:field>")


        WL("<mof:field key=""epr7m5t0r2c1"">" & Ar(35) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r3c1"">" & Ar(36) & "</mof:field>")
        WL("<mof:field key=""epr7m5t0r4c1"">" & Ar(37) & "</mof:field>")



        WL("<mof:grid id=""epr7m6t0r1"">")


    End Sub


    Public Sub WriteIR7_2018_LINE(ByVal Line As String)

        '0 2
        '1 Ds.Tables(2).Rows(0).Item(0) & PP
        '2 .Item(C_EmpIDType)
        '3 C_EmpIDType) & PP
        '4 C_EmpIDCard).ToString.PadRight(15) & PP
        '5 C_EmpSINo).Padright(15, " ") & PP
        '6 LastName.PadRight(35, " ") & PP
        '7 FirstName = .Item(C_EmpFirstName)
        '8 Adr1 = .Item(C_Adr1)
        '9 Adr2 = .Item(C_Adr2)
        '10 PostCode = .Item(C_PostCode)
        '11 FixInteger((i + 1), 5) & PP
        '12 (C_Local), 10) & PP
        '13 (C_Abroad), 9) & PP
        '14 (C_Allowances), 9) & PP
        '15 (C_Total456), 10) & PP
        '16 (C_SI), 9) & PP
        '17 (C_PF), 9) & PP
        '18 (C_MF), 9) & PP
        '19 (C_UNION), 9) & PP
        '20 (C_OtherDisc), 9) & PP
        '21 (C_TotalDisc), 9) & PP
        '22 (C_Taxable), 10) & PP
        '23 C_IT), 11) & PP
        '24  FixNumber(0, 11) & PP
        '25  FixNumber(0, 11) & PP
        '26 (C_StartDate))) <> "" Then
        '27 (C_LeaveDate))) <> "" Then
        '28 "".PadLeft(11, " ") & PP
        '29 "".PadLeft(11, " ") & PP
        '30 "".PadLeft(11, " ") & PP
        '31 "".PadLeft(9, " ") & PP
        '32 "".PadLeft(9, " ") & PP
        '33 "".PadLeft(9, " ") & PP
        '34 "".PadLeft(9, " ") & PP
        '35 "".PadLeft(1, " ") & PP
        '36 "".PadLeft(1, " ") & PP
        '37 "".PadLeft(1, " ") & PP
        '38 PensionNo.PadLeft(7, "0") & PP
        '39 PensionType.PadLeft(1, "0") & PP
        '40 (C_EmpSpecialTaxDed), 11) & PP
        '41 (C_EmpSpecialTaxCon), 11) & PP
        '42 (C_SalaryPeriods) > 13 Then
        '43 (C_EmpIDType) = " " Then
        '44 (C_LifeInsurance), 11) & PP
        '45 (C_TaxableFromOther)), 11) & PP
        '46 (C_NonTaxable)), 11) & PP
        '47 (C_Syntaksiodotika)), 11) & PP
        '48 (C_MiwsiApolavon)), 11) & PP
        '49  (C_WidowOrphans)), 11) & PP
        '50 (C_PensionFund)), 11) & PP

        '#2019 GESY
        '51 (C_BIK_withSI)), 11) & PP
        '52 (C_BIK_withoutSI)), 11) & PP
        '53 (C_GESYtoSI)), 11) & PP
        '54 (C_GESYtoBIKDed)), 11) & PP
        '55 (C_GESYtoBIKCon)), 11)
        '56 c_Type
        '-------------------------------------
        Dim employeeType As String
        Dim OtherDiscounts As Long





        Dim Ar() As String
        Ar = Line.Split("|")


        Dim A1 As Double = CLng(Ar(20))
        Dim A2 As Double = StringtoDecimal2ReturnDouble(Ar(48))
        OtherDiscounts = A1 + A2
        OtherDiscounts = StringtoInteger(OtherDiscounts)



        Dim R As DataRow
        R = dtxl.NewRow


        WL("<mof:row number=""" & CLng(Ar(11)) & """>")
        R(0) = CLng(Ar(11))
        R(33) = Ar(57)
        If Trim(Ar(2)) <> "" Then
            'TIC Number
            WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
            R(1) = Trim(Ar(2))
        Else
            If Ar(43) = 1 Then
                'ARITHMOS TAYTOPOIISIS
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Τ" & "</mof:field>")
                R(2) = "Τ"
            ElseIf Ar(43) = 2 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Α" & "</mof:field>")
                R(2) = "Α"
            ElseIf Ar(43) = 3 Then
                WL("<mof:field key=""epr7m6t0r1c2"">" & "Φ" & "</mof:field>")
                R(2) = "Φ"
            End If
            'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")
            'OTHER COUNTRY TIC
            WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
            R(3) = Trim(Ar(4))
        End If

        'SOCIAL INSURANCE NUMBER
        WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")
        R(4) = Trim(Ar(5))

        'SURNAME
        WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")
        R(5) = Trim(Ar(6))
        'NAME
        WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")
        R(6) = Trim(Ar(7))
        'STREET AND NUMBER
        WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")
        R(7) = Trim(Ar(8))
        'TOWN VILLAGE
        WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")
        R(8) = Trim(Ar(9))

        'POST CODE
        WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")
        R(9) = Trim(Ar(10))
        'EMAIL ADDRESS
        'WL("<mof:field key=""epr7m6t0r1c7d"">" & Trim(Ar(10)) & "</mof:field>")


        '#2019 Employee Type
        employeeType = Trim(Ar(56))

        WL("<mof:field key=""epr7m6t0r1c7e"">" & employeeType & "</mof:field>")
        R(10) = employeeType


        Dim BIKWithSI As Long = StringtoInteger(Ar(51)) / 100
        Dim BIKWithoutSI As Long = StringtoInteger(Ar(52)) / 100

        Dim Entos As Long = CLng(Ar(12))
        If Entos > 0 Then
            Entos = Entos - (BIKWithSI + BIKWithoutSI)
        End If

        'GROSS WITHIN THE REPUBLIC OF CYPRUS
        WL("<mof:field key=""epr7m6t0r1c8"">" & Entos & "</mof:field>")
        R(11) = Entos

        'OUTSIDE THE REPUBLIC OF CYPRUS
        WL("<mof:field key=""epr7m6t0r1c9"">" & CLng(Trim(Ar(13))) & "</mof:field>")
        R(12) = CLng(Trim(Ar(13)))

        'ALLOWANCES/BENEFITS/COMMITIONS
        '51 (C_BIK_withSI)), 11) & PP
        '52 (C_BIK_withoutSI)), 11) & PP

        WL("<mof:field key=""epr7m6t0r1c10"">" & BIKWithSI & "</mof:field>")
        R(13) = BIKWithSI
        '**************for 2018 GALATARIOTIS
        'Ar(52) = Ar(14)

        WL("<mof:field key=""epr7m6t0r1c10b"">" & BIKWithoutSI & "</mof:field>")
        R(14) = BIKWithoutSI


        'TOTAL OF COLUMNS
        WL("<mof:field key=""epr7m6t0r1c11"">" & CLng(Ar(15)) & "</mof:field>")
        R(15) = CLng(Ar(15))
        'TAXABLE FROM OTHER SOURCES
        'WL("<mof:field key=""epr7m6t0r1c11c"">" & CLng(Trim(Ar(15))) & "</mof:field>")

        'SOCIAL INSURANCE FUND
        WL("<mof:field key=""epr7m6t0r1c12"">" & CLng(Trim(Ar(16))) & "</mof:field>")
        R(16) = CLng(Ar(16))

        'PROVIDENT FUND AND PENSION FUND
        WL("<mof:field key=""epr7m6t0r1c13"">" & CLng(Trim(Ar(17))) & "</mof:field>")
        R(17) = CLng(Ar(17))
        'MEDICAL FUND
        WL("<mof:field key=""epr7m6t0r1c14"">" & CLng(Trim(Ar(18))) & "</mof:field>")
        R(18) = CLng(Ar(18))
        'UNIONS
        WL("<mof:field key=""epr7m6t0r1c15"">" & CLng(Trim(Ar(19))) & "</mof:field>")
        R(19) = CLng(Ar(19))
        'Life Insurance
        WL("<mof:field key=""epr7m6t0r1c15b"">" & CLng(Trim(Ar(44))) & "</mof:field>")
        R(20) = CLng(Ar(44))
        'NON TAXABLE INCOME (INCLUDED IN TOTALS)
        WL("<mof:field key=""epr7m6t0r1c15c"">" & CLng(Trim(Ar(46))) & "</mof:field>")
        R(21) = CLng(Ar(46))
        'Other Discounts
        WL("<mof:field key=""epr7m6t0r1c16"">" & CLng(OtherDiscounts) & "</mof:field>")
        R(22) = CLng(OtherDiscounts)
        'Total Discounts
        WL("<mof:field key=""epr7m6t0r1c17"">" & CLng(Trim(Ar(21))) & "</mof:field>")
        R(23) = CLng(Ar(21))
        'TAXABLE INCOME
        WL("<mof:field key=""epr7m6t0r1c18"">" & CLng(Trim(Ar(22))) & "</mof:field>")
        R(24) = CLng(Ar(22))

        'INCOME TAX
        WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(CLng(Ar(23))) & "</mof:field>")
        R(25) = StringtoDecimal2(CLng(Ar(23)))
        'SPECIAL CONTRIBUTION - gesi not FOR 2017
        'WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(CLng(Ar(24))) & "</mof:field>")

        'EISFORA SYNTAKSIODOTIKON OFELIMATON (+xiron orfanon + tameio syntaksis - na elegxw an einai mesa)
        WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(CLng(Ar(47))) & "</mof:field>")
        R(26) = StringtoDecimal2(CLng(Ar(47)))
        '''
        'MEIOSI APOLAVON
        WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(CLng(Ar(48))) & "</mof:field>")
        R(27) = StringtoDecimal2(CLng(Ar(48)))
        'GESI NOT FOR 2017
        'WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(CLng(Ar(40))) & "</mof:field>")
        'GESI NOT FOR 2017
        'WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(CLng(Ar(41))) & "</mof:field>")

        'DIAGRAFETE
        'WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")


        '53 (C_GESYtoSI)), 11) & PP
        WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(CLng(Ar(53))) & "</mof:field>")
        R(28) = StringtoDecimal2(CLng(Ar(53)))
        '54 (C_GESYtoBIKDed)), 11) & PP
        WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(CLng(Ar(55))) & "</mof:field>")
        R(29) = StringtoDecimal2(CLng(Ar(55)))
        '55 (C_GESYtoBIKCon)), 11)
        WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(CLng(Ar(54))) & "</mof:field>")
        R(30) = StringtoDecimal2(CLng(Ar(54)))

        '''

        If Trim(Ar(26)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(26)))
            WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
            R(31) = S
        End If
        If Trim(Ar(27)) <> "" Then
            Dim S As String
            S = changeformtatodate(Trim(Ar(27)))
            WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")
            R(32) = S
        End If
        WL("<mof:field key=""epr7m6t0r1c22"">" & CheckforZero(Trim(Ar(38))) & "</mof:field>")
        ' R(33) = CheckforZero(Trim(Ar(38)))
        'WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
        WL("</mof:row>")

        MyDsxl.Tables(0).Rows.Add(R)

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SelectedEmployeesDS = New DataSet
    End Sub

    'Private Sub TestToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    IR63A_2019(False, False)
    'End Sub

    'Private Sub MnuIR63_2019_ToPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    IR63A_2019(True, False)
    'End Sub

    'Private Sub ExportInPDFSplitJanFebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        IR63A_2019(True, True)
    '        MsgBox("Export finished ", MsgBoxStyle.Information)
    '    Catch ex As Exception
    '        Utils.ShowException(ex)
    '    End Try
    'End Sub

    Private Sub GreekToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekToolStripMenuItem1.Click
        '1.
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A2012_Stamp.rpt"
        Else
            Report = "IR63A2012.rpt"
        End If
        IR63A(False, False, Report, False, False)
    End Sub

    Private Sub GreekToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekToolStripMenuItem2.Click
        '2.
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63GR_Stamp.rpt"
        Else
            Report = "IR63GR.rpt"
        End If
        ' Report = "IR63GR.rpt"
        IR63A(False, False, Report, False, False)
    End Sub

    Private Sub EnglishSplitJanFebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishSplitJanFebToolStripMenuItem.Click
        '3.
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A_2019_Stamp.rpt"
        Else
            Report = "IR63A_2019.rpt"
        End If
        IR63A(False, False, Report, True, False)
    End Sub

    Private Sub GreekSplitJanFebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekSplitJanFebToolStripMenuItem.Click
        '4.
        Dim Report As String
        Report = "IR63GR_2019.rpt"
        IR63A(False, False, Report, True, False)
    End Sub

    Private Sub GreekToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekToolStripMenuItem3.Click
        '1.
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A2012_Stamp.rpt"
        Else
            Report = "IR63A2012.rpt"
        End If
        IR63A(True, False, Report, False, False)
    End Sub

    Private Sub EnglishToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem1.Click
        '2.
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63GR_Stamp.rpt"
        Else
            Report = "IR63GR.rpt"
        End If

        IR63A(True, False, Report, False, False)
    End Sub

    Private Sub EnglishSplitJanFebToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishSplitJanFebToolStripMenuItem1.Click
        '3.
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A_2019_Stamp.rpt"
        Else
            Report = "IR63A_2019.rpt"
        End If
        IR63A(True, False, Report, True, False)
    End Sub

    Private Sub GreekSplitJanFebToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekSplitJanFebToolStripMenuItem1.Click
        '4.
        Dim Report As String
        Report = "IR63GR_2019.rpt"
        IR63A(True, False, Report, True, False)
    End Sub

    Private Sub EnglishToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem2.Click
        '1.
        Try
            Dim Report As String
            If Me.CBShowCompanyStampOnIR63.Checked Then
                Report = "IR63A2012_Stamp.rpt"
            Else
                Report = "IR63A2012.rpt"
            End If
            IR63A(False, True, Report, False, False)
            If Me.CheckBox1.CheckState = CheckState.Checked Then
                MsgBox("Exported and Emailed  ", MsgBoxStyle.Information)
            Else
                MsgBox("Export finished ", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub GreekToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekToolStripMenuItem4.Click
        '2.
        Try
            Dim Report As String
            If Me.CBShowCompanyStampOnIR63.Checked Then
                Report = "IR63GR_Stamp.rpt"
            Else
                Report = "IR63GR.rpt"
            End If



            IR63A(False, True, Report, False, False)
            MsgBox("Export finished ", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub EnglishSplitJanFebToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishSplitJanFebToolStripMenuItem2.Click
        '3.
        Try
            Dim Report As String
            If Me.CBShowCompanyStampOnIR63.Checked Then
                Report = "IR63A_2019_Stamp.rpt"
            Else
                Report = "IR63A_2019.rpt"
            End If
            IR63A(False, True, Report, True, False)
            MsgBox("Export finished ", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub GreekSplitJanFebToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekSplitJanFebToolStripMenuItem2.Click
        '4.
        Try
            Dim Report As String
            Report = "IR63GR_2019.rpt"
            IR63A(False, True, Report, True, False)
            MsgBox("Export finished ", MsgBoxStyle.Information)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub txtFromEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromEmployee.TextChanged
        Me.txtToEmployee.Text = Me.txtFromEmployee.Text
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.CheckState = CheckState.Checked Then
            Me.RadioButton1.Enabled = True
            Me.RadioButton2.Enabled = True
            Me.RadioButton3.Enabled = True
            Me.RadioButton4.Enabled = True
        Else
            Me.RadioButton1.Enabled = False
            Me.RadioButton2.Enabled = False
            Me.RadioButton3.Enabled = False
            Me.RadioButton4.Enabled = False
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "TaxisNet")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','TaxisNet' Taxis Net URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "JCC")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','JCC' JCC payment URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "TaxPortal")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','TaxPortal' Tax Portal URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenExportfilesDir()
    End Sub
    Private Sub OpenExportfilesDir()

        Process.Start(GLBExportFilesDir)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "TFA")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','TFA' TFA URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub ShowWeb(ByVal Str As String)
        System.Diagnostics.Process.Start(Str)
    End Sub


    Private Sub English2020ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles English2020ToolStripMenuItem.Click
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A_2019_Stamp.rpt"
        Else
            Report = "IR63A_2019.rpt"
        End If
        IR63A(False, False, Report, False, True)
    End Sub

    Private Sub Greek2020ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Greek2020ToolStripMenuItem.Click
        Dim Report As String
        Report = "IR63GR_2019.rpt"
        IR63A(False, False, Report, False, True)
    End Sub

    ''''''''''''''''''''''''''''

    Private Sub EnglishSplitJanFebAprMayJunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishSplitJanFebAprMayJunToolStripMenuItem.Click
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A_2019_Stamp.rpt"
        Else
            Report = "IR63A_2019.rpt"
        End If
        IR63A(True, False, Report, False, True)
    End Sub

    Private Sub EnglishSplitJanFebAprMayJunToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishSplitJanFebAprMayJunToolStripMenuItem1.Click
        Dim Report As String
        Report = "IR63GR_2019.rpt"
        IR63A(True, False, Report, False, True)
    End Sub

    '''''''''''''''''''''''''''''''
    Private Sub EnglishSplitJanFebAprMayJunToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishSplitJanFebAprMayJunToolStripMenuItem2.Click
        Dim Report As String
        If Me.CBShowCompanyStampOnIR63.Checked Then
            Report = "IR63A_2019_Stamp.rpt"
        Else
            Report = "IR63A_2019.rpt"
        End If
        IR63A(False, True, Report, False, True)
    End Sub

    Private Sub GreekSplitJanFebAprMayJunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreekSplitJanFebAprMayJunToolStripMenuItem.Click
        Dim Report As String
        Report = "IR63GR_2019.rpt"
        IR63A(False, True, Report, False, True)
    End Sub

    Private Sub LoadDataSetToExcel(ByVal DsX As DataSet, ByVal Desc As String)

        Dim HeaderStr As New ArrayList
        HeaderStr.Add(Desc)

        Dim HeaderSize As New ArrayList

        Dim Loader As New cExcelLoader


        Loader.PrintFooter = " Printed At:" & Format(Now, "yyyy-MM-dd hh:mm:ss")
        Loader.LoadIntoExcel(DsX, HeaderStr, HeaderSize)

    End Sub

  
    Private Sub CBShowALLYears_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBShowALLYears.CheckedChanged
        Me.LoadPeriodGroup()
    End Sub

   
    Private Sub btnPeriodGroupSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodGroupSearch.Click
        Dim F As New FrmPeriodGroupSearch
        F.Owner = Me
        F.DsPeriodGroups = DsPeriodGroups
        F.CalledBy = 3
        F.ShowDialog()

    End Sub

    Private Sub mnuCreateXML2024_Click(sender As Object, e As EventArgs) Handles mnuCreateXML2024.Click
        CreateXMLFileProcedure_2024(False)
    End Sub
    Private Sub mnuCreateXML2024_WithExcel_Click(sender As Object, e As EventArgs) Handles mnuCreateXML2024_WithExcel.Click
        CreateXMLFileProcedure_2024(True)
    End Sub
    Private Sub CreateXMLFileProcedure_2024(ShowExcel As Boolean)
        MT_TotalGrossEmoluments = 0
        MT_ContributionsPensionableBenefits = 0
        MT_SpecialContributionPublic = 0
        MT_SpecialContributionPrivate = 0
        MT_ReductionOfEmolumentsandPensions = 0
        MT_TaxWithheld = 0
        MT_GHSWithHeldEmployee = 0
        MT_GHSWithHeldPensioners = 0
        MT_GHSWithHeldOfficers = 0
        MT_GHSEmployersContribution = 0


        XmlFile2024(ShowExcel, False)
    End Sub
    Private Sub XmlFile2024(ByVal ShowAsExcel As Boolean, ByVal SetBIKonSI As Boolean)

        dtxl.Rows.Clear()

        'Dim F As New FrmIR7File
        'F.Owner = Me
        'F.ShowDialog()
        'If Me.TaxGiven = -1 Or Me.Original = -1 Then
        '    MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        'Else

        IR7_2024(False, True, True, ShowAsExcel, SetBIKonSI)

        If GLB_XMLOriginFile <> "" Then
            CreateXMLFile_2024(False)
            Cursor.Current = Cursors.WaitCursor
            '    ShowAsExcel = False
            '   If ShowAsExcel Then
            '  LoadDataSetToExcel(MyDsxl, "ir7")
            'End If
            If ShowAsExcel Then
                Me.ReadIR7_XMLFileAndConvertItToExcel2(GLB_XMLDestinationFile)
                If System.IO.File.Exists(GLBIRExcelDestination) Then
                    Process.Start(GLBIRExcelDestination)
                Else
                    MsgBox(GLBIRExcelDestination & " Not Found", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Failed to create .xml File")
        End If
        Cursor.Current = Cursors.Default
        '  End If
    End Sub
    Private Sub IR7_2024(ByVal SendToPrinter As Boolean, ByVal File As Boolean, ByVal XMLCreation As Boolean, ByVal ShowInExcel As Boolean, ByVal BIKonSI As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet

        Dim Error1 As String
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        'D = DateAdd(DateInterval.Year, 1, D)
        Dim DissaBleRehire As Boolean = False

        If Me.CBDissableRehire.CheckState = CheckState.Checked Then
            DissaBleRehire = True

        End If


        Ds = Global1.Business.REPORT_IR7_2024(PerGrp, FromCode, ToCode, D, True, ShowInExcel, BIKonSI, DissaBleRehire)


        '----Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        ' Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                'correct LOCAL Earnings , substract GESI from Total
                Dim BIKWithSI As Double = 0
                Dim BIKWithoutSI As Double = 0
                Dim Local As Double = 0
                Dim ENTOS As Double = 0
                Dim DirFees As Double = 0
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    BIKWithSI = DbNullToDouble(Ds.Tables(0).Rows(i).Item(39))
                    BIKWithoutSI = DbNullToDouble(Ds.Tables(0).Rows(i).Item(40))
                    Local = DbNullToDouble(Ds.Tables(0).Rows(i).Item(6))
                    DirFees = DbNullToDouble(Ds.Tables(0).Rows(i).Item(46))
                    If Local > 0 Then
                        ENTOS = Local - (BIKWithSI + BIKWithoutSI + DirFees)
                    Else
                        ENTOS = 0
                    End If

                    Ds.Tables(0).Rows(i).Item(6) = ENTOS
                    Ds.Tables(0).Rows(i).Item(8) = (BIKWithSI + BIKWithoutSI + DirFees)
                Next

                Utils.ShowReport("IR7_2017.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter, "", False, False, "", True, 0)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then

                If CreateIR7File_2024(Ds) Then

                    If Not XMLCreation Then
                        MsgBox("File is Created - " & IR7FileDir & Ir7Filename, MsgBoxStyle.Information)
                    End If

                    GLB_XMLOriginFile = IR7FileDir & Ir7Filename

                    If ShowInExcel Then
                        '  LoadDataSetToExcel(Ds, "ir7")
                    End If


                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub CreateXMLFile_2024(ByVal ShowAsExcel As Boolean)

        Dim Error1 As String = "IN"
        Dim Error2 As String = "IN"
        Cursor = Cursors.WaitCursor
        Try

            Dim PrdGrp As New cPrMsPeriodGroups
            PrdGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


            GlbCancelIr7 = False

            Dim F As New FrmXMLDestination
            'F.Owner = Me
            'F.ShowDialog()
            Dim Ds1 As DataSet
            Dim TaxFiledir As String
            Ds1 = Global1.Business.GetParameter("SIContributions", "ExportFileDir")
            If CheckDataSet(Ds1) Then
                Dim Par As New cPrSsParameters(Ds1.Tables(0).Rows(0))
                TaxFiledir = Replace(Par.Value1, "$", Global1.GLBUserCode)

            Else
                TaxFiledir = "C:\"
            End If


            GLB_XMLDestinationFile = TaxFiledir & "IR7_" & PrdGrp.Year & "_" & PrdGrp.DescriptionL & ".xml"




            If GlbCancelIr7 = True Then
                MsgBox("The procedure was Canceled", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile


            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Dim HeaderLine As String = ""
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Error2 = Line
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"
                        HeaderLine = Line
                        Error1 = "before Header A"
                        WriteIR7_2024_Header_A(Line)
                        Error1 = "After Header A"
                    Case "2"
                        Lines = Lines + 1
                        Error1 = "before Lines " & Lines
                        WriteIR7_2024_LINE(Line)
                        Error1 = "After Lines"
                End Select

            Loop
            WriteIR7_2024_Header_B(HeaderLine)



            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)

            If ShowAsExcel Then
                'LoadFromTextFileToGrid(FileName)
                LoadFromXmlToExcel(GLB_XMLDestinationFile)
            End If

        Catch ex As Exception

            Utils.ShowException(ex)
            MsgBox("Failed to create .xml File")
            MsgBox(Error1)
            MsgBox(Error2)
        End Try
        Cursor = Cursors.Default


    End Sub
    Public Sub WriteIR7_2024_Header_A(ByVal Line As String)
        '---------------------------------------------
        'RECORD 01
        '---------------------------------------------
        '0 1
        '1 Year
        '2 TaxID
        '3
        '4
        '5 SIReg No
        '6  CompanyName
        '7
        '8  ComAdr1 = Company.Address1
        '9  ComAdr2 = Company.Address2
        '10  ComPost = Company.Address3
        '11  Str03 = Str03 & FixInteger((i), 5) & PP
        '12 TOTAL_Local
        '13 TOTAL_Abroad
        '14 TOTAL_Allowances
        '15 TOTAL_Total456
        '16 TOTAL_SI
        '17 TOTAL_PF
        '18 TOTAL_MF, 9) & PP
        '19 TOTAL_UNION, 9) & PP
        '20 TOTAL_OtherDisc, 9) & PP
        '21 TOTAL_TotalDisc, 9) & PP
        '22 TOTAL_Taxable, 10) & PP
        '23 TOTAL_IT, 11) & PP
        '24 0
        '25 0
        '26 
        '27
        '28 TaxGiven, 11) & PP
        '29 0, 11) & PP
        '30 Company.AccountantTIC
        '31 TIC1.PadRight(9, " ") & PP
        '32 TIC2.PadRight(9, " ") & PP
        '33 TIC3.PadRight(9, " ") & PP
        '34 TIC4.PadRight(9, " ") & PP
        '35 Company.AccIdentity & PP
        '36 Company.TICCategory & PP
        '37 Company.TICType & PP
        '38 & "0".PadLeft(7, "0") & PP
        '39 & Original & PP
        '40 TOTAL_SPDeduction, 11) & PP
        '41 TOTAL_SPContribution, 11) & PP
        '42 TOTAL_SpecialTax, 11) & PP
        '43 AccountantTitle & PP
        '44 AccountantTIC & PP
        '45 TOTAL_LifeInsurance, 11) & PP
        '46 TOTAL_AllowanceBenefits, 11) & PP
        '47 TOTAL_TaxableFromOther, 11) & PP
        '48 TOTAL_NonTaxable, 11) & PP
        '49 TOTAL_Syntaksiodotika, 11) & PP
        '50 TOTAL_MiwsiApolavon, 11) & PP
        '51 TOTAL_WidowOrphans, 11) & PP
        '52 TOTAL_PensionFund, 11) & PP

        '#2019 GESY
        '53 TOTAL_BIKWithSI, 11) & PP
        '54 TOTAL_BIKWithoutSI, 11) & PP
        '55 TOTAL_GESYtoSI, 11) & PP
        '56 TOTAL_GESYDed, 11) & PP
        '57 TOTAL_GESYCon, 11)


        Dim OtherDiscounts As Double

        Dim Ar() As String
        Dim Year As String
        Ar = Line.Split("|")
        Year = Ar(1)

        Dim A1 As Double = StringtoDecimal2ReturnDouble(Ar(20))
        Dim A2 As Double = StringtoDecimal2ReturnDouble(Ar(50))
        OtherDiscounts = A1 + A2
        'OtherDiscounts = StringtoInteger(OtherDiscounts)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<PayeReturn>")
        WL("<PayeReturnHeader>")
        WL("<TaxpayerNumber>" & Trim(Ar(2)) & "</TaxpayerNumber>")
        WL("<Year>" & Year & "</Year>")
        WL("<Period>Annual</Period>")
        WL("</PayeReturnHeader>")
        WL("<PayeReturnBody>")

        If Global1.PARAM_PublicSector = "No" Then
            WL("<EmployerType>Private Sector</EmployerType>")
        Else
            WL("<EmployerType>Broader Public Sector</EmployerType>")
        End If

        WL("<PayeEmployees>")


    End Sub
    Public Sub WriteIR7_2024_Header_B(ByVal Line As String)

        'Dim MT_TotalGrossEmoluments As Double = 0
        'Dim MT_TaxWithheld As Double = 0
        'Dim MT_ContributionsPensionableBenefits As Double = 0
        'Dim MT_SpecialContributionPublic As Double = 0
        'Dim MT_SpecialContributionPrivate As Double = 0
        'Dim MT_ReductionOfEmolumentsandPensions As Double = 0
        'Dim MT_GHSWithHeldPensioners As Double = 0
        'Dim MT_GHSWithHeldOfficers As Double = 0
        'Dim MT_GHSWithHeldEmployee As Double = 0
        'Dim MT_GHSEmployersContribution As Double = 0

        WL("</PayeEmployees>")
        WL("<TotalGrossEmoluments>" & FWC(MT_TotalGrossEmoluments) & "</TotalGrossEmoluments>")
        WL("<TotalTaxWithheld>" & FWC(MT_TaxWithheld) & "</TotalTaxWithheld>")
        WL("<TotalPensionableBenefitsContribution>" & FWC(MT_ContributionsPensionableBenefits) & "</TotalPensionableBenefitsContribution>")
        WL("<TotalSpecialContributionOfficers>" & FWC(MT_SpecialContributionPublic) & "</TotalSpecialContributionOfficers>")
        WL("<TotalSpecialContributionPrivate>" & FWC(MT_SpecialContributionPrivate) & "</TotalSpecialContributionPrivate>")
        WL("<TotalReductionOfEmolumentsAndPensions>" & FWC(MT_ReductionOfEmolumentsandPensions) & "</TotalReductionOfEmolumentsAndPensions>")
        WL("<TotalGhsWithheldPensioners>" & FWC(MT_GHSWithHeldPensioners) & "</TotalGhsWithheldPensioners>")
        WL("<TotalGhsWithheldOfficers>" & FWC(MT_GHSWithHeldOfficers) & "</TotalGhsWithheldOfficers>")
        WL("<TotalGhsWithheldEmployees>" & FWC(MT_GHSWithHeldEmployee) & "</TotalGhsWithheldEmployees>")
        WL("<TotalGhsEmployersContribution>" & FWC(MT_GHSEmployersContribution) & "</TotalGhsEmployersContribution>")
        WL("</PayeReturnBody>")
        WL("</PayeReturn>")



    End Sub


    Public Sub WriteIR7_2024_LINE(ByVal Line As String)

        '0 2
        '1 Ds.Tables(2).Rows(0).Item(0) & PP
        '2 .Item(C_EmpIDType)
        '3 C_EmpIDType) & PP
        '4 C_EmpIDCard).ToString.PadRight(15) & PP
        '5 C_EmpSINo).Padright(15, " ") & PP
        '6 LastName.PadRight(35, " ") & PP
        '7 FirstName = .Item(C_EmpFirstName)
        '8 Adr1 = .Item(C_Adr1)
        '9 Adr2 = .Item(C_Adr2)
        '10 PostCode = .Item(C_PostCode)
        '11 FixInteger((i + 1), 5) & PP
        '12 (C_Local), 10) & PP
        '13 (C_Abroad), 9) & PP
        '14 (C_Allowances), 9) & PP
        '15 (C_Total456), 10) & PP
        '16 (C_SI), 9) & PP
        '17 (C_PF), 9) & PP
        '18 (C_MF), 9) & PP
        '19 (C_UNION), 9) & PP
        '20 (C_OtherDisc), 9) & PP
        '21 (C_TotalDisc), 9) & PP
        '22 (C_Taxable), 10) & PP
        '23 C_IT), 11) & PP
        '24  FixNumber(0, 11) & PP
        '25  FixNumber(0, 11) & PP
        '26 (C_StartDate))) <> "" Then
        '27 (C_LeaveDate))) <> "" Then
        '28 "".PadLeft(11, " ") & PP
        '29 "".PadLeft(11, " ") & PP
        '30 "".PadLeft(11, " ") & PP
        '31 "".PadLeft(9, " ") & PP
        '32 "".PadLeft(9, " ") & PP
        '33 "".PadLeft(9, " ") & PP
        '34 "".PadLeft(9, " ") & PP
        '35 "".PadLeft(1, " ") & PP
        '36 "".PadLeft(1, " ") & PP
        '37 "".PadLeft(1, " ") & PP
        '38 PensionNo.PadLeft(7, "0") & PP
        '39 PensionType.PadLeft(1, "0") & PP
        '40 (C_EmpSpecialTaxDed), 11) & PP
        '41 (C_EmpSpecialTaxCon), 11) & PP
        '42 (C_SalaryPeriods)> 13 Then
        '43 (C_EmpIDType) = " " Then
        '44 (C_LifeInsurance), 11) & PP
        '45 (C_TaxableFromOther)), 11) & PP
        '46 (C_NonTaxable)), 11) & PP
        '47 (C_Syntaksiodotika)), 11) & PP
        '48 (C_MiwsiApolavon)), 11) & PP
        '49  (C_WidowOrphans)), 11) & PP
        '50 (C_PensionFund)), 11) & PP

        '#2019 GESY
        '51 (C_BIK_withSI)), 11) & PP
        '52 (C_BIK_withoutSI)), 11) & PP
        '53 (C_GESYtoSI)), 11) & PP
        '54 (C_GESYtoBIKDed)), 11) & PP
        '55 (C_GESYtoBIKCon)), 11)
        '56 c_Type
        '57 Director Fees
        '58 Private Pension Fund
        '59 Private Medical Fund

        '60 PREV_GrossEarnings 
        '61 PREV_SIDed 
        '62 PREV_PFFund
        '63 PREV_LifeIns
        '64 PREV_Discounts
        '65 PREV_Medical 
        '66 PREV_PensionFund
        '67 PREV_UnionDed
        '68 PREV_Gesi
        '69 IsLWBPensioner
        '70 NotionalAmount
        '71 NotionalTax
        '-------------------------------------
        Dim employeeType As String
        Dim OtherDiscounts As Double





        Dim Ar() As String
        Ar = Line.Split("|")
        Dim PersonalPF As Double = StringtoDecimal2ReturnDouble(Ar(58))
        Dim PersonalMF As Double = StringtoDecimal2ReturnDouble(Ar(59))

        Dim A1 As Double = StringtoDecimal2ReturnDouble(Ar(20))
        Dim A2 As Double = StringtoDecimal2ReturnDouble(Ar(48))
        OtherDiscounts = A1 + A2
        '    OtherDiscounts = StringtoInteger(OtherDiscounts)



        Dim R As DataRow
        R = dtxl.NewRow

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<PayeEmployee>")
        '<!-- One entry per employee, all Employees must be Unique -->
        If Trim(Ar(2)) <> "" Then 'If <>"" then it has TIC number
            WL("<EmployeeHasTIN>1</EmployeeHasTIN>")
            '<!--  Q1 Does the employee have a TIN? - 1=Yes, 0=No -->
            WL("<TaxpayerNumber>" & Trim(Ar(2)) & "</TaxpayerNumber>")
            Dim FullName As String = Trim(Ar(6)) & " " & Trim(Ar(7))
            WL("<Name>" & FullName & "</Name>")
            '<!--  Q4 Name (XML): Mandatory-Entering an employee without TIN  -->
        Else
            WL("<EmployeeHasTIN>0</EmployeeHasTIN>")
            '<!--  Q1 Does the employee have a TIN? - 1=Yes, 0=No -->
            Dim FullName As String = Trim(Ar(6)) & " " & Trim(Ar(7))
            WL("<Name>" & FullName & "</Name>")
            '<!--  Q4 Name (XML): Mandatory-Entering an employee without TIN  -->
            WL("<Identification>" & Trim(Ar(4)) & "</Identification>")
            '<!--  Q5 Identification (CY Identity Card No Or Alien Registration Card Or (TAX) Identification No of ANOTHER Country): Mandatory If Q1 Is 0 -->
            WL("<SocialInsuranceNumber>" & Trim(Ar(5)) & "</SocialInsuranceNumber>")
            '<!--  Q6 Social Insurance Number on the Republic of Cyprus: Mandatory If Q1 Is 0 -->
            WL("<ResidentialAddress>" & Trim(Ar(8)) & "</ResidentialAddress>")
            '<!--  Q7 Residential Address - Street And Number: Mandatory If Q1 Is 0 -->
            WL("<TownVillage>" & Trim(Ar(9)) & "</TownVillage>")
            '<!--  Q8 Town/Village: Mandatory If Q1 Is 0 -->
            WL("<PostCode>" & Trim(Ar(10)) & "</PostCode>")
            '<!--  Q9 Post Code: Mandatory If Q1 Is 0 -->

            WL("<EmailAddress>" & Trim(Ar(69)) & "</EmailAddress>")
            '<!-- Q10 Email Address: Mandatory If Q1 Is 0, Must be a valid Email -->
        End If
        Dim BIKWithSI As Double = StringtoDecimal2ReturnDouble(Ar(51))
        Dim BIKWithoutSI As Double = StringtoDecimal2ReturnDouble(Ar(52))

        '---------------------------------------------------

        '--------------------------------------------------------------------------






        Dim Entos As Double = StringtoDecimal2ReturnDouble((Ar(12)))
        'If Entos > 0 Then
        'Entos = Entos - (BIKWithSI + BIKWithoutSI)
        'End If
        Dim Q11 As Double = 0
        Dim Q12 As Double = 0
        Dim Q13 As Double = 0
        Dim Q14 As Double = 0
        Dim Q15 As Double = 0
        Dim Q15a As Double = 0
        Dim Q16 As Double = 0
        Dim Q17 As Double = 0
        Dim Q18 As Double = 0
        Dim Q19 As Double = 0
        Dim Q20 As Double = 0
        Dim Q21 As Double = 0
        Dim Q22 As Double = 0
        Dim Q23 As Double = 0
        Dim Q24 As Double = 0
        Dim Q25 As Double = 0
        Dim Q26 As Double = 0
        Dim Q27 As Double = 0
        Dim Q28 As Double = 0
        Dim Q29 As Double = 0
        Dim Q30 As Double = 0
        Dim Q31 As Double = 0
        Dim Q32 As Double = 0
        Dim Q33 As Double = 0
        Dim Q34 As Double = 0
        Dim Q35 As Double = 0
        Dim Q36 As Double = 0
        Dim Q37 As Double = 0
        Dim Q38 As Double = 0
        Dim Q39 As Double = 0
        Dim Q40 As Double = 0
        Dim Q41 As Double = 0
        Dim Q42 As Double = 0
        Dim Q43 As Double = 0
        Dim Q44 As Double = 0
        Dim Q45 As Double = 0
        Dim Q46 As Double = 0
        Dim Q47 As Double = 0
        Dim Q48 As Double = 0
        Dim Q49 As Double = 0
        Dim Q50 As Double = 0
        Dim Q51 As Double = 0
        Dim Q52 As Double = 0
        Dim Q53 As Double = 0
        Dim Q54 As Double = 0
        Dim Q55 As Double = 0
        Dim Q56 As Double = 0

        Dim IncomeFromOthersources As Double = 0
        Dim TaxablefromOther As Double = 0
        Dim Rents As Double = 0
        Dim PreviousEarnings As Double = 0
        Dim PreviousSI As Double = 0
        Dim PreviousPF As Double = 0
        Dim PreviousLifeInsurance As Double = 0
        Dim PreviousDiscount As Double = 0
        Dim PreviousMF As Double = 0
        Dim PreviousPenF As Double = 0
        Dim PreviousUnion As Double = 0
        Dim PreviousGesy As Double = 0


        TaxablefromOther = StringtoDecimal2ReturnDouble((Ar(45)))
        Rents = 0

        PreviousEarnings = StringtoDecimal2ReturnDouble((Ar(60)))
        PreviousSI = StringtoDecimal2ReturnDouble((Ar(61)))
        PreviousPF = StringtoDecimal2ReturnDouble((Ar(62)))
        PreviousLifeInsurance = StringtoDecimal2ReturnDouble((Ar(63)))
        PreviousDiscount = StringtoDecimal2ReturnDouble((Ar(64)))
        PreviousMF = StringtoDecimal2ReturnDouble((Ar(65)))
        PreviousPenF = StringtoDecimal2ReturnDouble((Ar(66)))
        PreviousUnion = StringtoDecimal2ReturnDouble((Ar(67)))
        PreviousGesy = StringtoDecimal2ReturnDouble((Ar(68)))

        IncomeFromOthersources = TaxablefromOther + Rents + PreviousEarnings - PreviousSI - PreviousPF - PreviousLifeInsurance - PreviousDiscount - PreviousMF - PreviousPenF - PreviousUnion - PreviousGesy
        If IncomeFromOthersources < 0 Then
            IncomeFromOthersources = 0
        End If
        '60 PREV_GrossEarnings 
        '61 PREV_SIDed 
        '62 PREV_PFFund
        '63 PREV_LifeIns
        '64 PREV_Discounts
        '65 PREV_Medical 
        '66 PREV_PensionFund
        '67 PREV_UnionDed


        Q11 = StringtoDecimal2ReturnDouble((Ar(15)))
        Q15a = StringtoDecimal2ReturnDouble(Trim(Ar(57)))
        Q16 = BIKWithSI
        Q17 = BIKWithoutSI
        Q18 = Q15a + Q16 + Q17
        'cccccccccccccccc
        WL("<GrossEmoluments>" & FWC(Q11) & "</GrossEmoluments>")
        '<!-- Q11 Gross Emoluments: Must be Sum Of Q12, 13, 14, 15, 15a, 16, 17, 19, 21 - ->
        Q12 = Entos - Q18
        WL("<EmolumentsWithinCyprus>" & FWC(Q12) & "</EmolumentsWithinCyprus>")
        '<!-- Q12 Emoluments within Cyprus -->
        Q13 = 0
        WL("<EmolumentsWithinCyprusSpecialRate >" & FWC(Q13) & "</EmolumentsWithinCyprusSpecialRate>")
        '<!-- Q13 Emoluments within Cyprus (special rate 8%) -->
        Q14 = StringtoDecimal2ReturnDouble(Trim(Ar(13)))
        WL("<EmolumentsOutsideCyprus>" & FWC(Q14) & "</EmolumentsOutsideCyprus>")
        '<!-- Q14 Emoluments Outside Cyprus -->
        Q15 = StringtoDecimal2ReturnDouble(Trim(Ar(71)))
        WL("<BenefitFromRelatedParties>" & FWC(Q15) & "</BenefitFromRelatedParties>")
        '<!-- Q15 Benefit from debit balances of related parties of legal persons -->
        WL("<DirectorFees>" & FWC(Q15a) & "</DirectorFees>")
        '<!-- Q15a Director's fees -->
        WL("<TaxResidenceCountryOfDirector>Cyprus</TaxResidenceCountryOfDirector>")
        '<!-- Q15b Tax residence country of Director -->
        '''''''''''WL("<TaxNumberOfDirector>111111</TaxNumberOfDirector>")
        '<!-- Q15c Tax number of Director (when tax residence country Is Not Cyprus) -->
        WL("<AllowancesWithSocialInsurance >" & FWC(Q16) & "</AllowancesWithSocialInsurance>")
        '<!-- Q16 Allowances, Benefits/Commissions, And Benefits in Kind with Social Insurance Fund Contributions -->
        WL("<AllowancesWithoutSocialInsurance>" & FWC(Q17) & "</AllowancesWithoutSocialInsurance>")
        '<!-- Q17 Allowances, Benefits/Commissions, And Benefits in Kind without Social Insurance Fund Contributions -->

        WL("<SumOfAllowances>" & FWC(Q18) & "</SumOfAllowances>")
        '<!-- Q18 Sum of Allowances: Must be Sum Of Q15a, 16, 17 - ->
        Q19 = 0
        WL("<Pensions>" & FWC(Q19) & "</Pensions>")
        '<!-- Q19 Pensions -->
        WL("<IsWidowPensionTaxed >1</IsWidowPensionTaxed>")
        '<!-- Q20 Is Widow's Pension taxed with normal rates? YES=1, No=0 -->
        Q21 = 0
        WL("<WidowsPension>" & FWC(Q21) & "</WidowsPension>")
        '<!-- Q21 Widow's Pension -->
        Q22 = 0
        WL("<WidowsPensionNonTaxableDeductions>" & FWC(Q22) & "</WidowsPensionNonTaxableDeductions>")
        '<!-- Q22 Widow's Pension Non-taxable deductions -->
        Q23 = Q11
        Q23 = StringtoDecimal2ReturnDouble((Ar(15)))

        MT_TotalGrossEmoluments = MT_TotalGrossEmoluments + Q23
        WL("<TotalTaxableIncome>" & FWC(Q23) & "</TotalTaxableIncome>")
        '<!-- Q23 Total Taxable Income IF Q20 = 1 then equals Q11, if Q20 = 0 then equals Q11 - Q21 -->
        Q24 = 0
        WL("<PriorYearBonus>" & FWC(Q24) & "</PriorYearBonus>")
        '<!-- Q24 Prior year Bonus -->
        Q25 = IncomeFromOthersources
        WL("<TaxableIncomeFromOtherSources>" & FWC(Q25) & "</TaxableIncomeFromOtherSources>")
        '<!-- Q25 Taxable Income from Other Sources (per TD59A) -->
        Q26 = StringtoDecimal2ReturnDouble((Trim(Ar(16))))
        WL("<EmployeeContributionSocialInsuranceFund>" & FWC(Q26) & "</EmployeeContributionSocialInsuranceFund>")
        '<!-- Q26 Employee's Contribution - Social Insurance Fund -->
        Q27 = StringtoDecimal2ReturnDouble((Trim(Ar(17))))
        WL("<EmployeeContributionProvidentAndPensionFund>" & FWC(Q27) & "</EmployeeContributionProvidentAndPensionFund>")
        '<!-- Q27 Employee's Contribution - Provident and Pension Funds -->
        Q28 = StringtoDecimal2ReturnDouble((Trim(Ar(18))))
        WL("<EmployeeContributionMedicalFund>" & FWC(Q28) & "</EmployeeContributionMedicalFund>")
        '<!-- Q28 Employee's Contribution - Medical Fund -->
        Q29 = StringtoDecimal2ReturnDouble(Trim(Ar(19)))
        WL("<EmployeeContributionTradeUnion>" & FWC(Q29) & "</EmployeeContributionTradeUnion>")
        '<!-- Q29 Employee's Contribution - Trade Union -->
        Q30 = StringtoDecimal2ReturnDouble(Trim(Ar(44)))
        WL("<LifeInsurancePremium>" & FWC(Q30) & "</LifeInsurancePremium>")
        '<!-- Q30 Life Insurance Premiums (as restricted by law) -->
        Q31 = StringtoDecimal2ReturnDouble(Trim(Ar(46)))
        WL("<NonTaxableIncome>" & FWC(Q31) & "</NonTaxableIncome>")
        '<!-- Q31 Non-Taxable Income (included in Gross Emoluments) -->

        Dim OtherIR59Deductions As Double = OtherDiscounts


        Q32 = OtherIR59Deductions + PersonalPF + PersonalMF

        WL("<OtherIR59Deductions>" & FWC(Q32) & "</OtherIR59Deductions>")
        '<!-- Q32 Other Deductions as per form IR59 (part B2, 6 & 7) -->
        Q33 = StringtoDecimal2ReturnDouble(Ar(53))
        WL("<GhsEmployeesContributionToOtherDepartments>" & FWC(Q33) & "</GhsEmployeesContributionToOtherDepartments>")
        '<!-- Q33 GHS - Contribution of Employees Payable to Other Departments -->
        Q34 = StringtoDecimal2ReturnDouble(Ar(47))
        WL("<PensionableBenefitsContribution>" & FWC(Q34) & "</PensionableBenefitsContribution>")
        MT_ContributionsPensionableBenefits = MT_ContributionsPensionableBenefits + Q34
        '<!-- Q34 Contribution Towards Pensionable Benefits (3%) Deducted from Emoluments -->
        Q35 = 0
        WL("<SpecialContributionPublic>" & FWC(Q35) & "</SpecialContributionPublic>")
        MT_SpecialContributionPublic = MT_SpecialContributionPublic + Q35
        '<!-- Q35 Special Contribution withheld from Public Sector Officers -->
        Q36 = 0
        WL("<SpecialContributionPrivate>" & FWC(Q36) & "</SpecialContributionPrivate>")
        '<!-- Q36 Special Contribution withheld from Private Sector Employees -->
        Q37 = 0
        WL("<SpecialContributionEmployer>" & FWC(Q37) & "</SpecialContributionEmployer>")
        '<!-- Q37 Special Contribution of Employer for Employees in the Private Sector -->
        MT_SpecialContributionPrivate = MT_SpecialContributionPrivate + Q36 + Q37

        Q38 = StringtoDecimal2ReturnDouble(Ar(48))
        WL("<ReductionOfEmolumentsAndPensions>" & FWC(Q38) & "</ReductionOfEmolumentsAndPensions>")
        MT_ReductionOfEmolumentsandPensions = MT_ReductionOfEmolumentsandPensions + Q38

        '<!-- Q38 Broader Public Sector Reduction of Emoluments And Pensions -->
        Q39 = StringtoDecimal2ReturnDouble(Ar(54))
        employeeType = Ar(56)
        If employeeType = "3" Then
            Q39 = 0
        End If
        If Ar(70) = 1 Then
            Q42 = Q39
            Q39 = 0
        Else
            Q42 = 0
        End If


        WL("<GhsWithheldEmployeesNormalRate>" & FWC(Q39) & "</GhsWithheldEmployeesNormalRate>")
        '<!-- Q39 GHS withheld from employees for income subject to normal rate tax -->
        Q40 = 0
        WL("<GhsWithheldEmployeesSpecialRate>" & FWC(Q40) & "</GhsWithheldEmployeesSpecialRate>")
        '<!-- Q40 GHS withheld from employees for income subject to special rate tax (8%) -->
        Q41 = Q39 + Q40
        WL("<GhsWithheldEmployees>" & FWC(Q41) & "</GhsWithheldEmployees>")
        '<!-- Q41 GHS withheld from employees: Sum of Q39 & Q40 -->
        MT_GHSWithHeldEmployee = MT_GHSWithHeldEmployee + Q41

        WL("<GhsWithheldPensionersNormalRate>" & FWC(Q42) & "</GhsWithheldPensionersNormalRate>")
        '<!-- Q42 GHS withheld from pensioners for income subject to normal rate tax -->
        Q43 = 0
        WL("<GhsWithheldPensionersWidow>" & FWC(Q43) & "</GhsWithheldPensionersWidow>")
        '<!-- Q43 GHS withheld from widows' pension -->
        Q44 = Q42 + Q43
        WL("<GhsWithheldPensioners>" & FWC(Q44) & "</GhsWithheldPensioners>")
        MT_GHSWithHeldPensioners = MT_GHSWithHeldPensioners + Q44
        '<!-- Q44 GHS withheld from Pensioners: Sum of Q42 & Q43 -->

        If employeeType = 3 Then
            WL("<IsEmployeeAnOfficer>" & 1 & "</IsEmployeeAnOfficer>")
            'reverse 54 with 55 if employee is officer
            Q46 = StringtoDecimal2ReturnDouble(Ar(55))
        Else
            WL("<IsEmployeeAnOfficer>" & 0 & "</IsEmployeeAnOfficer>")
            Q46 = 0
        End If
        '<!-- Q45 Is the employee an Officer? Yes=1 , No=0 -->

        WL("<GhsWithheldOfficers>" & FWC(Q46) & "</GhsWithheldOfficers>")
        MT_GHSWithHeldOfficers = MT_GHSWithHeldOfficers + Q46
        '<!-- Q46 GHS withheld from officers -->

        Q47 = Q41 + Q44 + Q46
        WL("<GhsEmployeesContributionToTaxDepartment>" & FWC(Q47) & "</GhsEmployeesContributionToTaxDepartment>")
        '<!-- Q47 GHS Contribution of Employees Payable to Tax Department: Sum of Q41, 44, 46 - ->
        Q48 = Q26 + Q27 + Q28 + Q29 + Q30 + Q31 + Q32 + Q33 + Q34 + Q38 + Q41 + Q44 + Q46
        WL("<TotalDeductions>" & FWC(Q48) & "</TotalDeductions>")
        '<!-- Q48 Total Deductions: Sum of Q26, 27, 28, 29, 30, 31, 32, 33, 34, 38, 41, 44, 46 - ->
        Q49 = Q23 - Q48
        WL("<ChargeableIncome>" & FWC(Q49) & "</ChargeableIncome>")
        '<!-- Q49 Chargeable Income: Q23 minus Q48 -->
        Q50 = StringtoDecimal2ReturnDouble(Ar(23))
        WL("<TaxWithheldEmolumentsNormalRate>" & FWC(Q50) & "</TaxWithheldEmolumentsNormalRate>")
        '<!-- Q50 Tax withheld from emoluments with normal rate -->
        Q51 = 0
        WL("<TaxWithheldEmolumentsSpecialRate>" & FWC(Q51) & "</TaxWithheldEmolumentsSpecialRate>")
        '<!-- Q51 Tax withheld from emoluments with special rate (8%) -->
        Q52 = 0
        WL("<TaxWithheldPensionsNormalRate>" & FWC(Q52) & "</TaxWithheldPensionsNormalRate>")
        '<!-- Q52 Tax withheld from pensions with normal rates -->
        Q53 = 0
        WL("<TaxWithheldPensionsWidow>" & FWC(Q53) & "</TaxWithheldPensionsWidow>")
        '<!-- Q53 Tax withheld from widows' pension -->
        Q54 = Q50 + Q51 + Q52 + Q53
        WL("<TaxWithheld>" & FWC(Q54) & "</TaxWithheld>")
        '<!-- Q54 Tax Withheld: Sum of Q50, Q51, Q52, Q53 - ->
        Q55 = 0
        WL("<TaxWithheldPriorYearBonus>" & FWC(Q55) & "</TaxWithheldPriorYearBonus>")
        MT_TaxWithheld = MT_TaxWithheld + Q55 + Q54
        '<!-- Q55 Tax withheld from prior year bonus -->
        If employeeType = "3" Then
            'Contribution of Officer is on Ar(54)
            Q56 = StringtoDecimal2ReturnDouble(Ar(54))
        Else
            'Contribution of NON Officer is on Ar(55)
            Q56 = StringtoDecimal2ReturnDouble(Ar(55))
        End If

        WL("<GhsEmployersContributionPayable>" & FWC(Q56) & "</GhsEmployersContributionPayable>")
        '<!-- Q56 GHS Employer's Contribution Payable to Tax Department -->
        MT_GHSEmployersContribution = MT_GHSEmployersContribution + Q56


        Dim salaryPeriods As Integer = Ar(42)
        WL("<SalaryPaymentMethod>" & salaryPeriods & "</SalaryPaymentMethod>")
        '<!-- Q57 Method of salary payment  Monthly (12 Or 13) Or Weekly (52 Or 53) -->
        If Trim(Ar(26)) <> "" Then
            Dim S As String

            S = changeformtatodate2(Trim(Ar(26)))
            WL("<EmploymentCommencementDate>" & S & "</EmploymentCommencementDate>")
            '<!-- Q58 Commencement of Employment Date during the current year: Dates must be in format YYYY-MM-DD -->
            'R(31) = S
        End If
        If Trim(Ar(27)) <> "" Then
            Dim S As String
            S = changeformtatodate2(Trim(Ar(27)))
            WL("<EmploymentTerminationDate>" & S & "</EmploymentTerminationDate>")
            '<!-- Q59 Termination of Employment Date during the current year -->
            '  R(32) = S
        End If

        WL("</PayeEmployee>")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'WL("<mof:row number=""" & Ar(11)) & """>")
        'R(0) = Ar(11))
        'If Trim(Ar(2)) <> "" Then
        '    'TIC Number
        '    WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        '    R(1) = Trim(Ar(2))
        'Else
        '    If Ar(43) = 1 Then
        '        'ARITHMOS TAYTOPOIISIS
        '        WL("<mof:field key=""epr7m6t0r1c2"">" & "Τ" & "</mof:field>")
        '        R(2) = "Τ"
        '    ElseIf Ar(43) = 2 Then
        '        WL("<mof:field key=""epr7m6t0r1c2"">" & "Α" & "</mof:field>")
        '        R(2) = "Α"
        '    ElseIf Ar(43) = 3 Then
        '        WL("<mof:field key=""epr7m6t0r1c2"">" & "Φ" & "</mof:field>")
        '        R(2) = "Φ"
        '    End If
        '    'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")
        '    'OTHER COUNTRY TIC
        '    WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
        '    R(3) = Trim(Ar(4))
        'End If

        ''SOCIAL INSURANCE NUMBER
        'WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")
        'R(4) = Trim(Ar(5))

        ''SURNAME
        'WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")
        'R(5) = Trim(Ar(6))
        ''NAME
        'WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")
        'R(6) = Trim(Ar(7))
        ''STREET AND NUMBER
        'WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")
        'R(7) = Trim(Ar(8))
        ''TOWN VILLAGE
        'WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")
        'R(8) = Trim(Ar(9))

        ''POST CODE
        'WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")
        'R(9) = Trim(Ar(10))
        ''EMAIL ADDRESS
        ''WL("<mof:field key=""epr7m6t0r1c7d"">" & Trim(Ar(10)) & "</mof:field>")


        ''#2019 Employee Type
        'employeeType = Trim(Ar(56))

        'WL("<mof:field key=""epr7m6t0r1c7e"">" & employeeType & "</mof:field>")
        'R(10) = employeeType



        'If Entos> 0 Then
        '    Entos = Entos - (BIKWithSI + BIKWithoutSI)
        'End If

        ''GROSS WITHIN THE REPUBLIC OF CYPRUS
        'WL("<mof:field key=""epr7m6t0r1c8"">" & Entos & "</mof:field>")
        'R(11) = Entos

        ''OUTSIDE THE REPUBLIC OF CYPRUS
        'WL("<mof:field key=""epr7m6t0r1c9"">" & Trim(Ar(13))) & "</mof:field>")
        'R(12) = Trim(Ar(13)))

        ''ALLOWANCES/BENEFITS/COMMITIONS
        ''51 (C_BIK_withSI)), 11) & PP
        ''52 (C_BIK_withoutSI)), 11) & PP

        'WL("<mof:field key=""epr7m6t0r1c10"">" & BIKWithSI & "</mof:field>")
        'R(13) = BIKWithSI
        ''**************for 2018 GALATARIOTIS
        ''Ar(52) = Ar(14)

        'WL("<mof:field key=""epr7m6t0r1c10b"">" & BIKWithoutSI & "</mof:field>")
        'R(14) = BIKWithoutSI


        ''TOTAL OF COLUMNS
        'WL("<mof:field key=""epr7m6t0r1c11"">" & Ar(15)) & "</mof:field>")
        'R(15) = Ar(15))
        ''TAXABLE FROM OTHER SOURCES
        ''WL("<mof:field key=""epr7m6t0r1c11c"">" & Trim(Ar(15))) & "</mof:field>")

        ''SOCIAL INSURANCE FUND
        'WL("<mof:field key=""epr7m6t0r1c12"">" & Trim(Ar(16))) & "</mof:field>")
        'R(16) = Ar(16))

        ''PROVIDENT FUND AND PENSION FUND
        'WL("<mof:field key=""epr7m6t0r1c13"">" & Trim(Ar(17))) & "</mof:field>")
        'R(17) = Ar(17))
        ''MEDICAL FUND
        'WL("<mof:field key=""epr7m6t0r1c14"">" & Trim(Ar(18))) & "</mof:field>")
        'R(18) = Ar(18))
        ''UNIONS
        'WL("<mof:field key=""epr7m6t0r1c15"">" & Trim(Ar(19))) & "</mof:field>")
        'R(19) = Ar(19))
        ''Life Insurance
        'WL("<mof:field key=""epr7m6t0r1c15b"">" & Trim(Ar(44))) & "</mof:field>")
        'R(20) = Ar(44))
        ''NON TAXABLE INCOME (INCLUDED IN TOTALS)

        'WL("<mof:field key=""epr7m6t0r1c15c"">" & Trim(Ar(46))) & "</mof:field>")
        'R(21) = Ar(46))

        ''Other Discounts
        'WL("<mof:field key=""epr7m6t0r1c16"">" & OtherDiscounts) & "</mof:field>")
        'R(22) = OtherDiscounts)

        ''Total Discounts
        'WL("<mof:field key=""epr7m6t0r1c17"">" & Trim(Ar(21))) & "</mof:field>")
        'R(23) = Ar(21))
        ''TAXABLE INCOME
        'WL("<mof:field key=""epr7m6t0r1c18"">" & Trim(Ar(22))) & "</mof:field>")
        'R(24) = Ar(22))

        ''INCOME TAX
        'WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(Ar(23))) & "</mof:field>")
        'R(25) = StringtoDecimal2(Ar(23)))
        ''SPECIAL CONTRIBUTION - gesi not FOR 2017
        ''WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(Ar(24))) & "</mof:field>")

        ''EISFORA SYNTAKSIODOTIKON OFELIMATON (+xiron orfanon + tameio syntaksis - na elegxw an einai mesa)
        'WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(Ar(47))) & "</mof:field>")
        'R(26) = StringtoDecimal2(Ar(47)))
        ''''
        ''MEIOSI APOLAVON
        'WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(Ar(48))) & "</mof:field>")
        'R(27) = StringtoDecimal2(Ar(48)))
        ''GESI NOT FOR 2017
        ''WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(Ar(40))) & "</mof:field>")
        ''GESI NOT FOR 2017
        ''WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(Ar(41))) & "</mof:field>")

        ''DIAGRAFETE
        ''WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")



        ''53 (C_GESYtoSI)), 11) & PP
        'WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(Ar(53))) & "</mof:field>")
        'R(28) = StringtoDecimal2(Ar(53)))
        ''54 (C_GESYtoBIKDed)), 11) & PP
        'WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(Ar(55))) & "</mof:field>")
        'R(29) = StringtoDecimal2(Ar(55)))
        ''55 (C_GESYtoBIKCon)), 11)
        'WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(Ar(54))) & "</mof:field>")
        'R(30) = StringtoDecimal2(Ar(54)))

        ''''

        'If Trim(Ar(26)) <> "" Then
        '    Dim S As String
        '    S = changeformtatodate(Trim(Ar(26)))
        '    WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
        '    R(31) = S
        'End If
        'If Trim(Ar(27)) <> "" Then
        '    Dim S As String
        '    S = changeformtatodate(Trim(Ar(27)))
        '    WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")
        '    R(32) = S
        'End If
        'WL("<mof:field key=""epr7m6t0r1c22"">" & CheckforZero(Trim(Ar(38))) & "</mof:field>")
        '' R(33) = CheckforZero(Trim(Ar(38)))
        ''WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
        'WL("</mof:row>")

        MyDsxl.Tables(0).Rows.Add(R)

    End Sub



    Private Sub ReadIR7_XMLFileAndConvertItToExcel(ImportFrom As String)


        ' Load XML into DataSet
        Dim ds As New DataSet()
        Dim Path As String = "C:\nodalwin\Payroll\ExportFiles\"

        GLBIRExcelDestination = ImportFrom.Replace(".xml", ".xlsx")
        ' Load XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ImportFrom) ' Replace with your actual XML path

        ' Create Excel
        Dim xlApp As New Application
        Dim xlWorkbook As Workbook = xlApp.Workbooks.Add()
        Dim xlWorksheet As Worksheet = CType(xlWorkbook.Sheets(1), Worksheet)

        ' Select all PayeEmployee nodes
        Dim employeeNodes = xmlDoc.SelectNodes("//PayeEmployee")

        If employeeNodes.Count = 0 Then
            Console.WriteLine("No PayeEmployee records found.")
            Return
        End If

        ' Get column headers from first employee
        Dim firstEmployee = employeeNodes(0)
        Dim colIndex As Integer = 1
        For Each childNode As XmlNode In firstEmployee.ChildNodes
            xlWorksheet.Cells(1, colIndex) = childNode.Name
            colIndex += 1
        Next

        ' Write employee data
        Dim rowIndex As Integer = 2
        For Each employee As XmlNode In employeeNodes
            colIndex = 1
            For Each childNode As XmlNode In employee.ChildNodes

                'xlWorksheet.Cells(rowIndex, colIndex) = childNode.InnerText
                'colIndex += 1
                Dim valueText = childNode.InnerText.Trim()

                ' Convert comma to period for numeric values
                If valueText.Contains(",") AndAlso IsNumeric(valueText.Replace(",", ".")) Then
                    valueText = valueText.Replace(",", ".")
                End If

                xlWorksheet.Cells(rowIndex, colIndex) = valueText
                colIndex += 1

            Next
            rowIndex += 1
        Next
        ' Auto-fit columns
        Dim i As Integer
        For i = 1 To firstEmployee.ChildNodes.Count
            xlWorksheet.Columns(i).AutoFit()
        Next

        ' Add totals row
        Dim totalRowIndex As Integer = rowIndex
        xlWorksheet.Cells(totalRowIndex, 1) = "TOTALS"
        Dim col As Integer
        Dim r As Integer
        For col = 2 To firstEmployee.ChildNodes.Count
            Dim isNumericColumn As Boolean = True

            ' Check if all values in the column are numeric
            For r = 2 To rowIndex - 1
                Dim cellValue = xlWorksheet.Cells(r, col).Value
                If Not IsNumeric(cellValue) Then
                    isNumericColumn = False
                    Exit For
                End If
            Next

            ' If numeric, calculate sum
            If isNumericColumn Then
                Dim sumFormula = $"=SUM({xlWorksheet.Cells(2, col).Address}:{xlWorksheet.Cells(rowIndex - 1, col).Address})"
                xlWorksheet.Cells(totalRowIndex, col).Formula = sumFormula
            End If
        Next



        ' Save Excel file
        xlWorkbook.SaveAs(GLBIRExcelDestination) ' Replace with desired output path
        xlWorkbook.Close()
        xlApp.Quit()




        MsgBox("Export complete!")

    End Sub
    Private Sub ReadIR7_XMLFileAndConvertItToExcel2(ImportFrom As String)
        ' Load XML into DataSet
        Dim ds As New DataSet()
        Dim Path As String = "C:\nodalwin\Payroll\ExportFiles\"

        GLBIRExcelDestination = ImportFrom.Replace(".xml", ".xlsx")


        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ImportFrom)

        Dim xlApp As New Application
        Dim xlWorkbook As Workbook = xlApp.Workbooks.Add()
        Dim xlWorksheet As Worksheet = CType(xlWorkbook.Sheets(1), Worksheet)

        Dim employeeNodes = xmlDoc.SelectNodes("//PayeEmployee")
        If employeeNodes.Count = 0 Then
            MsgBox("No PayeEmployee records found.")
            Return
        End If

        ' Step 1: Build master list of all element names
        Dim allFields As New List(Of String)
        For Each employee As XmlNode In employeeNodes
            For Each childNode As XmlNode In employee.ChildNodes
                If Not allFields.Contains(childNode.Name) Then
                    allFields.Add(childNode.Name)
                End If
            Next
        Next

        ' Step 2: Write headers
        For i As Integer = 0 To allFields.Count - 1
            xlWorksheet.Cells(1, i + 1) = allFields(i)
        Next

        ' Step 3: Write employee data
        Dim rowIndex As Integer = 2
        For Each employee As XmlNode In employeeNodes
            For colIndex As Integer = 0 To allFields.Count - 1
                Dim fieldName = allFields(colIndex)
                Dim fieldNode = employee.SelectSingleNode(fieldName)
                Dim valueText As String = If(fieldNode IsNot Nothing, fieldNode.InnerText.Trim(), "")

                If valueText.Contains(",") AndAlso IsNumeric(valueText.Replace(",", ".")) Then
                    valueText = valueText.Replace(",", ".")
                End If

                xlWorksheet.Cells(rowIndex, colIndex + 1) = valueText
            Next
            rowIndex += 1
        Next

        ' Step 4: Auto-fit columns
        For i As Integer = 1 To allFields.Count
            xlWorksheet.Columns(i).AutoFit()
        Next

        ' Step 5: Add totals row
        Dim totalRowIndex As Integer = rowIndex
        xlWorksheet.Cells(totalRowIndex, 1) = "TOTALS"
        Dim col As Integer
        Dim r As Integer
        For col = 2 To allFields.Count
            Dim isNumericColumn As Boolean = True
            For r = 2 To rowIndex - 1
                Dim cellValue = xlWorksheet.Cells(r, col).Value
                If Not IsNumeric(cellValue) Then
                    isNumericColumn = False
                    Exit For
                End If
            Next
            If isNumericColumn Then
                Dim sumFormula = $"=SUM({xlWorksheet.Cells(2, col).Address}:{xlWorksheet.Cells(rowIndex - 1, col).Address})"
                xlWorksheet.Cells(totalRowIndex, col).Formula = sumFormula
            End If
        Next

        ' Save and clean up
        GLBIRExcelDestination = ImportFrom.Replace(".xml", ".xlsx")
        xlWorkbook.SaveAs(GLBIRExcelDestination)
        xlWorkbook.Close()
        xlApp.Quit()

        MsgBox("File Exported in Excel!", MsgBoxStyle.Information)
    End Sub

    Private Sub CreateXMLFile2025ForTFAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateXMLFile2025ForTFAToolStripMenuItem.Click
        CreateXMLFileProcedure_2025(False)
    End Sub

    Private Sub CreateXMLFile2025ForTFAWithExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateXMLFile2025ForTFAWithExcelToolStripMenuItem.Click
        CreateXMLFileProcedure_2025(True)
    End Sub
    Private Sub CreateXMLFileProcedure_2025(ShowExcel As Boolean)
        MT_TotalGrossEmoluments = 0
        MT_ContributionsPensionableBenefits = 0
        MT_SpecialContributionPublic = 0
        MT_SpecialContributionPrivate = 0
        MT_ReductionOfEmolumentsandPensions = 0
        MT_TaxWithheld = 0
        MT_TaxWithheldPriorYearBonus = 0
        MT_FinancialBenefitDeduction = 0
        MT_TotalPensionableBenefitsContribution = 0
        MT_TotalGhsEmployersContribution = 0
        MT_TotalGhsEmployeesContribution = 0


        MT_GHSWithHeldEmployee = 0
        MT_GHSWithHeldPensioners = 0
        MT_GHSWithHeldOfficers = 0
        MT_GHSEmployersContribution = 0
        'MT_GHSEmployeesContribution = 0


        XmlFile2025(ShowExcel, False)
    End Sub
    Private Sub XmlFile2025(ByVal ShowAsExcel As Boolean, ByVal SetBIKonSI As Boolean)

        dtxl.Rows.Clear()

        'Dim F As New FrmIR7File
        'F.Owner = Me
        'F.ShowDialog()
        'If Me.TaxGiven = -1 Or Me.Original = -1 Then
        '    MsgBox("Please Fill Tax Given and type of Report", MsgBoxStyle.Information)
        'Else

        IR7_2025(False, True, True, ShowAsExcel, SetBIKonSI)
        '   xxx
        If GLB_XMLOriginFile <> "" Then
            CreateXMLFile_2025(False)
            Cursor.Current = Cursors.WaitCursor
            '    ShowAsExcel = False
            '   If ShowAsExcel Then
            '  LoadDataSetToExcel(MyDsxl, "ir7")
            'End If
            If ShowAsExcel Then
                Me.ReadIR7_XMLFileAndConvertItToExcel2(GLB_XMLDestinationFile)
                If System.IO.File.Exists(GLBIRExcelDestination) Then
                    Process.Start(GLBIRExcelDestination)
                Else
                    MsgBox(GLBIRExcelDestination & " Not Found", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Failed to create .xml File")
        End If
        Cursor.Current = Cursors.Default
        '  End If
    End Sub
    Private Sub IR7_2025(ByVal SendToPrinter As Boolean, ByVal File As Boolean, ByVal XMLCreation As Boolean, ByVal ShowInExcel As Boolean, ByVal BIKonSI As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim PerGrp As New cPrMsPeriodGroups
        Dim dsEmp As DataSet
        Dim FromCode As String
        Dim ToCode As String
        Dim TempGrpCode As String
        Dim EmpCode As String
        Dim Ds As DataSet

        Dim Error1 As String
        PerGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        FromCode = Me.txtFromEmployee.Text
        ToCode = Me.txtToEmployee.Text
        TempGrpCode = PerGrp.TemGrpCode
        Dim Y As String
        Y = PerGrp.Year
        Dim D As Date = "01/01/" & Y
        'D = DateAdd(DateInterval.Year, 1, D)
        Dim DissaBleRehire As Boolean = False

        If Me.CBDissableRehire.CheckState = CheckState.Checked Then
            DissaBleRehire = True

        End If


        Ds = Global1.Business.REPORT_IR7_2025(PerGrp, FromCode, ToCode, D, True, ShowInExcel, BIKonSI, DissaBleRehire)


        '----Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        ' Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\IR7")
        If Not File Then
            If CheckDataSet(Ds) Then
                'correct LOCAL Earnings , substract GESI from Total
                Dim BIKWithSI As Double = 0
                Dim BIKWithoutSI As Double = 0
                Dim Local As Double = 0
                Dim ENTOS As Double = 0
                Dim DirFees As Double = 0
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    BIKWithSI = DbNullToDouble(Ds.Tables(0).Rows(i).Item(39))
                    BIKWithoutSI = DbNullToDouble(Ds.Tables(0).Rows(i).Item(40))
                    Local = DbNullToDouble(Ds.Tables(0).Rows(i).Item(6))
                    DirFees = DbNullToDouble(Ds.Tables(0).Rows(i).Item(46))
                    If Local > 0 Then
                        ENTOS = Local - (BIKWithSI + BIKWithoutSI + DirFees)
                    Else
                        ENTOS = 0
                    End If

                    Ds.Tables(0).Rows(i).Item(6) = ENTOS
                    Ds.Tables(0).Rows(i).Item(8) = (BIKWithSI + BIKWithoutSI + DirFees)
                Next

                Utils.ShowReport("IR7_2017.rpt", Ds, FrmReport, "CYPRUS INCOME TAX - I.R. 7", SendToPrinter, "", False, False, "", True, 0)
            Else
                MsgBox("No records found")
            End If
        Else
            If CheckDataSet(Ds) Then

                If CreateIR7File_2025(Ds) Then

                    If Not XMLCreation Then
                        MsgBox("File is Created - " & IR7FileDir & Ir7Filename, MsgBoxStyle.Information)
                    End If

                    GLB_XMLOriginFile = IR7FileDir & Ir7Filename

                    If ShowInExcel Then
                        '  LoadDataSetToExcel(Ds, "ir7")
                    End If


                Else
                    MsgBox("Fail to Create File", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("No records found")
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub CreateXMLFile_2025(ByVal ShowAsExcel As Boolean)

        Dim Error1 As String = "IN"
        Dim Error2 As String = "IN"
        Cursor = Cursors.WaitCursor
        Try

            Dim PrdGrp As New cPrMsPeriodGroups
            PrdGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


            GlbCancelIr7 = False

            Dim F As New FrmXMLDestination
            'F.Owner = Me
            'F.ShowDialog()
            Dim Ds1 As DataSet
            Dim TaxFiledir As String
            Ds1 = Global1.Business.GetParameter("SIContributions", "ExportFileDir")
            If CheckDataSet(Ds1) Then
                Dim Par As New cPrSsParameters(Ds1.Tables(0).Rows(0))
                TaxFiledir = Replace(Par.Value1, "$", Global1.GLBUserCode)

            Else
                TaxFiledir = "C:\"
            End If


            GLB_XMLDestinationFile = TaxFiledir & "IR7_" & PrdGrp.Year & "_" & PrdGrp.DescriptionL & ".xml"




            If GlbCancelIr7 = True Then
                MsgBox("The procedure was Canceled", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = GLB_XMLOriginFile


            InitFile = True
            Dim Exx As New Exception
            Dim Ar() As String

            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Dim HeaderLine As String = ""
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Error2 = Line
                Ar = Line.Split("|")
                Select Case Ar(0)
                    Case "1"
                        HeaderLine = Line
                        Error1 = "before Header A"
                        WriteIR7_2025_Header_A(Line)
                        Error1 = "After Header A"
                    Case "2"
                        Lines = Lines + 1
                        Error1 = "before Lines " & Lines
                        WriteIR7_2025_LINE(Line)
                        Error1 = "After Lines"
                End Select

            Loop
            WriteIR7_2025_Header_B(HeaderLine)



            ' MsgBox("finish")
            param_file.Close()
            param_file.Dispose()
            GC.Collect()
            MsgBox("Succefull File Creation at " & GLB_XMLDestinationFile)

            If ShowAsExcel Then
                'LoadFromTextFileToGrid(FileName)
                LoadFromXmlToExcel(GLB_XMLDestinationFile)
            End If

        Catch ex As Exception

            Utils.ShowException(ex)
            MsgBox("Failed to create .xml File")
            MsgBox(Error1)
            MsgBox(Error2)
        End Try
        Cursor = Cursors.Default


    End Sub
    Public Sub WriteIR7_2025_Header_A(ByVal Line As String)
        '---------------------------------------------
        'RECORD 01
        '---------------------------------------------
        '0 1
        '1 Year
        '2 TaxID
        '3
        '4
        '5 SIReg No
        '6  CompanyName
        '7
        '8  ComAdr1 = Company.Address1
        '9  ComAdr2 = Company.Address2
        '10  ComPost = Company.Address3
        '11  Str03 = Str03 & FixInteger((i), 5) & PP
        '12 TOTAL_Local
        '13 TOTAL_Abroad
        '14 TOTAL_Allowances
        '15 TOTAL_Total456
        '16 TOTAL_SI
        '17 TOTAL_PF
        '18 TOTAL_MF, 9) & PP
        '19 TOTAL_UNION, 9) & PP
        '20 TOTAL_OtherDisc, 9) & PP
        '21 TOTAL_TotalDisc, 9) & PP
        '22 TOTAL_Taxable, 10) & PP
        '23 TOTAL_IT, 11) & PP
        '24 0
        '25 0
        '26 
        '27
        '28 TaxGiven, 11) & PP
        '29 0, 11) & PP
        '30 Company.AccountantTIC
        '31 TIC1.PadRight(9, " ") & PP
        '32 TIC2.PadRight(9, " ") & PP
        '33 TIC3.PadRight(9, " ") & PP
        '34 TIC4.PadRight(9, " ") & PP
        '35 Company.AccIdentity & PP
        '36 Company.TICCategory & PP
        '37 Company.TICType & PP
        '38 & "0".PadLeft(7, "0") & PP
        '39 & Original & PP
        '40 TOTAL_SPDeduction, 11) & PP
        '41 TOTAL_SPContribution, 11) & PP
        '42 TOTAL_SpecialTax, 11) & PP
        '43 AccountantTitle & PP
        '44 AccountantTIC & PP
        '45 TOTAL_LifeInsurance, 11) & PP
        '46 TOTAL_AllowanceBenefits, 11) & PP
        '47 TOTAL_TaxableFromOther, 11) & PP
        '48 TOTAL_NonTaxable, 11) & PP
        '49 TOTAL_Syntaksiodotika, 11) & PP
        '50 TOTAL_MiwsiApolavon, 11) & PP
        '51 TOTAL_WidowOrphans, 11) & PP
        '52 TOTAL_PensionFund, 11) & PP

        '#2019 GESY
        '53 TOTAL_BIKWithSI, 11) & PP
        '54 TOTAL_BIKWithoutSI, 11) & PP
        '55 TOTAL_GESYtoSI, 11) & PP
        '56 TOTAL_GESYDed, 11) & PP
        '57 TOTAL_GESYCon, 11)


        Dim OtherDiscounts As Double

        Dim Ar() As String
        Dim Year As String
        Ar = Line.Split("|")
        Year = Ar(1)

        Dim A1 As Double = StringtoDecimal2ReturnDouble(Ar(20))
        Dim A2 As Double = StringtoDecimal2ReturnDouble(Ar(50))
        OtherDiscounts = A1 + A2
        'OtherDiscounts = StringtoInteger(OtherDiscounts)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<PayeReturn>")
        WL("<PayeReturnHeader>")
        WL("<TaxpayerNumber>" & Trim(Ar(2)) & "</TaxpayerNumber>")
        WL("<Year>" & Year & "</Year>")
        WL("<Period>Annual</Period>")
        WL("</PayeReturnHeader>")

        WL("<PayeReturnBody>")

        If Global1.PARAM_PublicSector = "No" Then
            WL("<EmployerType>Private Sector</EmployerType>")
        Else
            WL("<EmployerType>Broader Public Sector</EmployerType>")
        End If

        WL("<PayeEmployees>")


    End Sub
    Public Sub WriteIR7_2025_Header_B(ByVal Line As String)

        'Dim MT_TotalGrossEmoluments As Double = 0
        'Dim MT_TaxWithheld As Double = 0
        'Dim MT_ContributionsPensionableBenefits As Double = 0
        'Dim MT_SpecialContributionPublic As Double = 0
        'Dim MT_SpecialContributionPrivate As Double = 0
        'Dim MT_ReductionOfEmolumentsandPensions As Double = 0
        'Dim MT_GHSWithHeldPensioners As Double = 0
        'Dim MT_GHSWithHeldOfficers As Double = 0
        'Dim MT_GHSWithHeldEmployee As Double = 0
        'Dim MT_GHSEmployersContribution As Double = 0
        '<TotalGrossEmoluments>100020,33</TotalGrossEmoluments>
        '<!-- Q1 Gross Emoluments: Must be SUM of all q3 -->
        '<TaxWithheld>28000,00</TaxWithheld>
        '<!-- Q2 Tax Withheld : Must be SUM of all q42 -->
        '<TaxWithheldFromBonus>600,00</TaxWithheldFromBonus>
        '<!-- Q3 Tax Withheld from Prior Year Bonus : Must be SUM of all q43 -->
        '<TotalTaxWithheld>28600,00</TotalTaxWithheld>
        '<!-- Q4 Total Tax Withheld (Q2 + Q3) -->
        '<TotalFinancialBenefitDeductions>1000,00</TotalFinancialBenefitDeductions>
        '<!-- Q4a Tax deducted for financial benefits of directors Or shareholders Or related parties thereof : Must be SUM of all q42a -->
        '<TotalPensionableBenefitsContribution>136,00</TotalPensionableBenefitsContribution>
        '<!-- Q5 Contribution Towards Pensionable Benefits (3%) Deducted from Emoluments : Must be SUM of all q26 -->
        '<TotalGhsEmployeesContribution>699,00</TotalGhsEmployeesContribution>
        '<!-- Q6 GHS Contribution of Employees Payable to Tax Department (including prior year bonuses) : Must be SUM of all q35+q44+q45 -->
        '<TotalGhsEmployersContribution>1622,00</TotalGhsEmployersContribution>
        '<!-- Q7 GHS Employer's Contribution Payable to Tax Department : Must be SUM of all q46+q47 -->


        WL("</PayeEmployees>")
        WL("<TotalGrossEmoluments>" & FWC(MT_TotalGrossEmoluments) & "</TotalGrossEmoluments>")
        'Q43
        WL("<TaxWithheld>" & FWC(MT_TaxWithheld) & "</TaxWithheld>")
        'Q42a
        WL("<TaxWithheldFromBonus>" & FWC(MT_TaxWithheldPriorYearBonus) & "</TaxWithheldFromBonus>")

        Dim TotalTax As Double = MT_TaxWithheld + MT_TaxWithheldPriorYearBonus
        WL("<TotalTaxWithheld>" & FWC(TotalTax) & "</TotalTaxWithheld>")

        WL("<TotalFinancialBenefitDeductions>" & FWC(MT_FinancialBenefitDeduction) & "</TotalFinancialBenefitDeductions>")
        'Q25
        WL("<TotalPensionableBenefitsContribution>" & FWC(MT_ContributionsPensionableBenefits) & "</TotalPensionableBenefitsContribution>")
        'Q35+Q44+Q45
        WL("<TotalGhsEmployeesContribution>" & FWC(MT_TotalGhsEmployeesContribution) & "</TotalGhsEmployeesContribution>")
        'Q47+Q45
        WL("<TotalGhsEmployersContribution>" & FWC(MT_TotalGhsEmployersContribution) & "</TotalGhsEmployersContribution>")


        ' WL("<TotalPensionableBenefitsContribution>" & FWC(MT_ContributionsPensionableBenefits) & "</TotalPensionableBenefitsContribution>")
        ' WL("<TotalSpecialContributionOfficers>" & FWC(MT_SpecialContributionPublic) & "</TotalSpecialContributionOfficers>")
        ' WL("<TotalSpecialContributionPrivate>" & FWC(MT_SpecialContributionPrivate) & "</TotalSpecialContributionPrivate>")
        ' WL("<TotalReductionOfEmolumentsAndPensions>" & FWC(MT_ReductionOfEmolumentsandPensions) & "</TotalReductionOfEmolumentsAndPensions>")
        ' WL("<TotalGhsWithheldPensioners>" & FWC(MT_GHSWithHeldPensioners) & "</TotalGhsWithheldPensioners>")
        ' WL("<TotalGhsWithheldOfficers>" & FWC(MT_GHSWithHeldOfficers) & "</TotalGhsWithheldOfficers>")
        ' WL("<TotalGhsWithheldEmployees>" & FWC(MT_GHSWithHeldEmployee) & "</TotalGhsWithheldEmployees>")
        ' WL("<TotalGhsEmployersContribution>" & FWC(MT_GHSEmployersContribution) & "</TotalGhsEmployersContribution>")


        WL("</PayeReturnBody>")
        WL("</PayeReturn>")



    End Sub


    Public Sub WriteIR7_2025_LINE(ByVal Line As String)

        '0 2
        '1 Ds.Tables(2).Rows(0).Item(0) & PP
        '2 .Item(C_EmpIDType)
        '3 C_EmpIDType) & PP
        '4 C_EmpIDCard).ToString.PadRight(15) & PP
        '5 C_EmpSINo).Padright(15, " ") & PP
        '6 LastName.PadRight(35, " ") & PP
        '7 FirstName = .Item(C_EmpFirstName)
        '8 Adr1 = .Item(C_Adr1)
        '9 Adr2 = .Item(C_Adr2)
        '10 PostCode = .Item(C_PostCode)
        '11 FixInteger((i + 1), 5) & PP
        '12 (C_Local), 10) & PP
        '13 (C_Abroad), 9) & PP
        '14 (C_Allowances), 9) & PP
        '15 (C_Total456), 10) & PP
        '16 (C_SI), 9) & PP
        '17 (C_PF), 9) & PP
        '18 (C_MF), 9) & PP
        '19 (C_UNION), 9) & PP
        '20 (C_OtherDisc), 9) & PP
        '21 (C_TotalDisc), 9) & PP
        '22 (C_Taxable), 10) & PP
        '23 C_IT), 11) & PP
        '24  FixNumber(0, 11) & PP
        '25  FixNumber(0, 11) & PP
        '26 (C_StartDate))) <> "" Then
        '27 (C_LeaveDate))) <> "" Then
        '28 "".PadLeft(11, " ") & PP
        '29 "".PadLeft(11, " ") & PP
        '30 "".PadLeft(11, " ") & PP
        '31 "".PadLeft(9, " ") & PP
        '32 "".PadLeft(9, " ") & PP
        '33 "".PadLeft(9, " ") & PP
        '34 "".PadLeft(9, " ") & PP
        '35 "".PadLeft(1, " ") & PP
        '36 "".PadLeft(1, " ") & PP
        '37 "".PadLeft(1, " ") & PP
        '38 PensionNo.PadLeft(7, "0") & PP
        '39 PensionType.PadLeft(1, "0") & PP
        '40 (C_EmpSpecialTaxDed), 11) & PP
        '41 (C_EmpSpecialTaxCon), 11) & PP
        '42 (C_SalaryPeriods)> 13 Then
        '43 (C_EmpIDType) = " " Then
        '44 (C_LifeInsurance), 11) & PP
        '45 (C_TaxableFromOther)), 11) & PP
        '46 (C_NonTaxable)), 11) & PP
        '47 (C_Syntaksiodotika)), 11) & PP
        '48 (C_MiwsiApolavon)), 11) & PP
        '49  (C_WidowOrphans)), 11) & PP
        '50 (C_PensionFund)), 11) & PP

        '#2019 GESY
        '51 (C_BIK_withSI)), 11) & PP
        '52 (C_BIK_withoutSI)), 11) & PP
        '53 (C_GESYtoSI)), 11) & PP
        '54 (C_GESYtoBIKDed)), 11) & PP
        '55 (C_GESYtoBIKCon)), 11)
        '56 c_Type
        '57 Director Fees
        '58 Private Pension Fund
        '59 Private Medical Fund

        '60 PREV_GrossEarnings 
        '61 PREV_SIDed 
        '62 PREV_PFFund
        '63 PREV_LifeIns
        '64 PREV_Discounts
        '65 PREV_Medical 
        '66 PREV_PensionFund
        '67 PREV_UnionDed
        '68 PREV_Gesi
        '69 IsLWBPensioner
        '70 NotionalAmount
        '71 NotionalTax
        '-------------------------------------
        Dim employeeType As String
        Dim OtherDiscounts As Double





        Dim Ar() As String
        Ar = Line.Split("|")
        Dim PersonalPF As Double = StringtoDecimal2ReturnDouble(Ar(58))
        Dim PersonalMF As Double = StringtoDecimal2ReturnDouble(Ar(59))

        Dim A1 As Double = StringtoDecimal2ReturnDouble(Ar(20))
        Dim A2 As Double = StringtoDecimal2ReturnDouble(Ar(48))
        OtherDiscounts = A1 + A2
        '    OtherDiscounts = StringtoInteger(OtherDiscounts)



        Dim R As DataRow
        R = dtxl.NewRow

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<PayeEmployee>")
        '<!-- One entry per employee, all Employees must be Unique -->
        ' If Trim(Ar(2)) <> "" Then 'If <>"" then it has TIC number
        ' WL("<EmployeeHasTIN>1</EmployeeHasTIN>")
        '<!--  Q1 Does the employee have a TIN? - 1=Yes, 0=No -->
        WL("<TaxpayerNumber>" & Trim(Ar(2)) & "</TaxpayerNumber>")
            Dim FullName As String = Trim(Ar(6)) & " " & Trim(Ar(7))
            WL("<Name>" & FullName & "</Name>")
        '<!--  Q4 Name (XML): Mandatory-Entering an employee without TIN  -->
        'Else
        '    WL("<EmployeeHasTIN>0</EmployeeHasTIN>")
        '    '<!--  Q1 Does the employee have a TIN? - 1=Yes, 0=No -->
        '    Dim FullName As String = Trim(Ar(6)) & " " & Trim(Ar(7))
        '    WL("<Name>" & FullName & "</Name>")
        '    '<!--  Q4 Name (XML): Mandatory-Entering an employee without TIN  -->
        '    WL("<Identification>" & Trim(Ar(4)) & "</Identification>")
        '    '<!--  Q5 Identification (CY Identity Card No Or Alien Registration Card Or (TAX) Identification No of ANOTHER Country): Mandatory If Q1 Is 0 -->
        '    WL("<SocialInsuranceNumber>" & Trim(Ar(5)) & "</SocialInsuranceNumber>")
        '    '<!--  Q6 Social Insurance Number on the Republic of Cyprus: Mandatory If Q1 Is 0 -->
        '    WL("<ResidentialAddress>" & Trim(Ar(8)) & "</ResidentialAddress>")
        '    '<!--  Q7 Residential Address - Street And Number: Mandatory If Q1 Is 0 -->
        '    WL("<TownVillage>" & Trim(Ar(9)) & "</TownVillage>")
        '    '<!--  Q8 Town/Village: Mandatory If Q1 Is 0 -->
        '    WL("<PostCode>" & Trim(Ar(10)) & "</PostCode>")
        '    '<!--  Q9 Post Code: Mandatory If Q1 Is 0 -->

        '    WL("<EmailAddress>" & Trim(Ar(69)) & "</EmailAddress>")
        '    '<!-- Q10 Email Address: Mandatory If Q1 Is 0, Must be a valid Email -->
        'End If
        Dim BIKWithSI As Double = StringtoDecimal2ReturnDouble(Ar(51))
        Dim BIKWithoutSI As Double = StringtoDecimal2ReturnDouble(Ar(52))

        '---------------------------------------------------

        '--------------------------------------------------------------------------






        Dim Entos As Double = StringtoDecimal2ReturnDouble((Ar(12)))
        'If Entos > 0 Then
        'Entos = Entos - (BIKWithSI + BIKWithoutSI)
        'End If
        Dim Q11 As Double = 0
        Dim Q12 As Double = 0
        Dim Q13 As Double = 0
        Dim Q14 As Double = 0
        Dim Q15 As Double = 0
        Dim Q15a As Double = 0
        Dim Q16 As Double = 0
        Dim Q17 As Double = 0
        Dim Q18 As Double = 0
        Dim Q19 As Double = 0
        Dim Q20 As Double = 0
        Dim Q21 As Double = 0
        Dim Q22 As Double = 0
        Dim Q23 As Double = 0
        Dim Q24 As Double = 0
        Dim Q25 As Double = 0
        Dim Q26 As Double = 0
        Dim Q27 As Double = 0
        Dim Q28 As Double = 0
        Dim Q29 As Double = 0
        Dim Q30 As Double = 0
        Dim Q31 As Double = 0
        Dim Q32 As Double = 0
        Dim Q33 As Double = 0
        Dim Q34 As Double = 0
        Dim Q35 As Double = 0
        Dim Q36 As Double = 0
        Dim Q37 As Double = 0
        Dim Q38 As Double = 0
        Dim Q39 As Double = 0
        Dim Q40 As Double = 0
        Dim Q41 As Double = 0
        Dim Q42 As Double = 0
        Dim Q43 As Double = 0
        Dim Q44 As Double = 0
        Dim Q45 As Double = 0
        Dim Q46 As Double = 0
        Dim Q47 As Double = 0
        Dim Q48 As Double = 0
        Dim Q49 As Double = 0
        Dim Q50 As Double = 0
        Dim Q51 As Double = 0
        Dim Q52 As Double = 0
        Dim Q53 As Double = 0
        Dim Q54 As Double = 0
        Dim Q55 As Double = 0
        Dim Q56 As Double = 0

        Dim IncomeFromOthersources As Double = 0
        Dim TaxablefromOther As Double = 0
        Dim Rents As Double = 0
        Dim PreviousEarnings As Double = 0
        Dim PreviousSI As Double = 0
        Dim PreviousPF As Double = 0
        Dim PreviousLifeInsurance As Double = 0
        Dim PreviousDiscount As Double = 0
        Dim PreviousMF As Double = 0
        Dim PreviousPenF As Double = 0
        Dim PreviousUnion As Double = 0
        Dim PreviousGesy As Double = 0


        TaxablefromOther = StringtoDecimal2ReturnDouble((Ar(45)))
        Rents = 0

        PreviousEarnings = StringtoDecimal2ReturnDouble((Ar(60)))
        PreviousSI = StringtoDecimal2ReturnDouble((Ar(61)))
        PreviousPF = StringtoDecimal2ReturnDouble((Ar(62)))
        PreviousLifeInsurance = StringtoDecimal2ReturnDouble((Ar(63)))
        PreviousDiscount = StringtoDecimal2ReturnDouble((Ar(64)))
        PreviousMF = StringtoDecimal2ReturnDouble((Ar(65)))
        PreviousPenF = StringtoDecimal2ReturnDouble((Ar(66)))
        PreviousUnion = StringtoDecimal2ReturnDouble((Ar(67)))
        PreviousGesy = StringtoDecimal2ReturnDouble((Ar(68)))

        IncomeFromOthersources = TaxablefromOther + Rents + PreviousEarnings - PreviousSI - PreviousPF - PreviousLifeInsurance - PreviousDiscount - PreviousMF - PreviousPenF - PreviousUnion - PreviousGesy
        If IncomeFromOthersources < 0 Then
            IncomeFromOthersources = 0
        End If
        '60 PREV_GrossEarnings 
        '61 PREV_SIDed 
        '62 PREV_PFFund
        '63 PREV_LifeIns
        '64 PREV_Discounts
        '65 PREV_Medical 
        '66 PREV_PensionFund
        '67 PREV_UnionDed


        Q11 = StringtoDecimal2ReturnDouble((Ar(15)))
        Q15a = StringtoDecimal2ReturnDouble(Trim(Ar(57)))
        Q16 = BIKWithSI
        Q17 = BIKWithoutSI
        Q18 = Q15a + Q16 + Q17
        'cccccccccccccccc
        WL("<GrossEmoluments>" & FWC(Q11) & "</GrossEmoluments>")
        '<!-- Q11 Gross Emoluments: Must be Sum Of Q12, 13, 14, 15, 15a, 16, 17, 19, 21 - ->
        Q12 = Entos - Q18
        WL("<EmolumentsWithinCyprus>" & FWC(Q12) & "</EmolumentsWithinCyprus>")
        '<!-- Q12 Emoluments within Cyprus -->
        Q13 = 0
        WL("<EmolumentsWithinCyprusSpecialRate>" & FWC(Q13) & "</EmolumentsWithinCyprusSpecialRate>")
        '<!-- Q13 Emoluments within Cyprus (special rate 8%) -->
        Q14 = StringtoDecimal2ReturnDouble(Trim(Ar(13)))
        WL("<EmolumentsOutsideCyprus>" & FWC(Q14) & "</EmolumentsOutsideCyprus>")
        '<!-- Q14 Emoluments Outside Cyprus -->
        Q15 = StringtoDecimal2ReturnDouble(Trim(Ar(71)))
        WL("<BenefitFromRelatedParties>" & FWC(Q15) & "</BenefitFromRelatedParties>")
        '<!-- Q15 Benefit from debit balances of related parties of legal persons -->
        WL("<DirectorFees>" & FWC(Q15a) & "</DirectorFees>")
        '<!-- Q15a Director's fees -->
        WL("<TaxResidenceCountryOfDirector>Cyprus</TaxResidenceCountryOfDirector>")
        '<!-- Q15b Tax residence country of Director -->
        '''''''''''WL("<TaxNumberOfDirector>111111</TaxNumberOfDirector>")
        '<!-- Q15c Tax number of Director (when tax residence country Is Not Cyprus) -->
        WL("<AllowancesWithSocialInsurance>" & FWC(Q16) & "</AllowancesWithSocialInsurance>")
        '<!-- Q16 Allowances, Benefits/Commissions, And Benefits in Kind with Social Insurance Fund Contributions -->
        WL("<AllowancesWithoutSocialInsurance>" & FWC(Q17) & "</AllowancesWithoutSocialInsurance>")
        '<!-- Q17 Allowances, Benefits/Commissions, And Benefits in Kind without Social Insurance Fund Contributions -->

        WL("<SumOfAllowances>" & FWC(Q18) & "</SumOfAllowances>")
        '<!-- Q18 Sum of Allowances: Must be Sum Of Q15a, 16, 17 - ->
        Q19 = 0
        WL("<Pensions>" & FWC(Q19) & "</Pensions>")
        '<!-- Q19 Pensions -->
        WL("<IsWidowPensionTaxed>1</IsWidowPensionTaxed>")
        '<!-- Q20 Is Widow's Pension taxed with normal rates? YES=1, No=0 -->
        Q21 = 0
        WL("<WidowsPension>" & FWC(Q21) & "</WidowsPension>")
        '<!-- Q21 Widow's Pension -->
        Q22 = 0
        WL("<WidowsPensionNonTaxableDeductions>" & FWC(Q22) & "</WidowsPensionNonTaxableDeductions>")
        '<!-- Q22 Widow's Pension Non-taxable deductions -->
        Q23 = Q11
        Q23 = StringtoDecimal2ReturnDouble((Ar(15)))

        MT_TotalGrossEmoluments = MT_TotalGrossEmoluments + Q23
        WL("<TotalTaxableIncome>" & FWC(Q23) & "</TotalTaxableIncome>")
        '<!-- Q23 Total Taxable Income IF Q20 = 1 then equals Q11, if Q20 = 0 then equals Q11 - Q21 -->
        Q24 = 0
        WL("<PriorYearBonus>" & FWC(Q24) & "</PriorYearBonus>")
        '<!-- Q24 Prior year Bonus -->
        Q25 = IncomeFromOthersources
        WL("<TaxableIncomeFromOtherSources>" & FWC(Q25) & "</TaxableIncomeFromOtherSources>")
        '<!-- Q25 Taxable Income from Other Sources (per TD59A) -->
        Q26 = StringtoDecimal2ReturnDouble((Trim(Ar(16))))
        WL("<EmployeeContributionSocialInsuranceFund>" & FWC(Q26) & "</EmployeeContributionSocialInsuranceFund>")
        '<!-- Q26 Employee's Contribution - Social Insurance Fund -->
        Q27 = StringtoDecimal2ReturnDouble((Trim(Ar(17))))
        WL("<EmployeeContributionProvidentAndPensionFund>" & FWC(Q27) & "</EmployeeContributionProvidentAndPensionFund>")
        '<!-- Q27 Employee's Contribution - Provident and Pension Funds -->
        Q28 = StringtoDecimal2ReturnDouble((Trim(Ar(18))))
        WL("<EmployeeContributionMedicalFund>" & FWC(Q28) & "</EmployeeContributionMedicalFund>")
        '<!-- Q28 Employee's Contribution - Medical Fund -->
        Q29 = StringtoDecimal2ReturnDouble(Trim(Ar(19)))
        WL("<EmployeeContributionTradeUnion>" & FWC(Q29) & "</EmployeeContributionTradeUnion>")
        '<!-- Q29 Employee's Contribution - Trade Union -->
        Q30 = StringtoDecimal2ReturnDouble(Trim(Ar(44)))
        WL("<LifeInsurancePremium>" & FWC(Q30) & "</LifeInsurancePremium>")
        '<!-- Q30 Life Insurance Premiums (as restricted by law) -->
        Q31 = StringtoDecimal2ReturnDouble(Trim(Ar(46)))
        WL("<NonTaxableIncome>" & FWC(Q31) & "</NonTaxableIncome>")
        '<!-- Q31 Non-Taxable Income (included in Gross Emoluments) -->

        Dim OtherIR59Deductions As Double = OtherDiscounts


        Q32 = OtherIR59Deductions + PersonalPF + PersonalMF

        WL("<OtherIR59Deductions>" & FWC(Q32) & "</OtherIR59Deductions>")
        '<!-- Q32 Other Deductions as per form IR59 (part B2, 6 & 7) -->
        Q33 = StringtoDecimal2ReturnDouble(Ar(53))
        WL("<GhsEmployeesContributionToOtherDepartments>" & FWC(Q33) & "</GhsEmployeesContributionToOtherDepartments>")
        ' MT_TotalPensionableBenefitsContribution = MT_TotalPensionableBenefitsContribution + Q33


        '<!-- Q33 GHS - Contribution of Employees Payable to Other Departments -->
        Q34 = StringtoDecimal2ReturnDouble(Ar(47))
        WL("<PensionableBenefitsContribution>" & FWC(Q34) & "</PensionableBenefitsContribution>")
        MT_ContributionsPensionableBenefits = MT_ContributionsPensionableBenefits + Q34
        '<!-- Q34 Contribution Towards Pensionable Benefits (3%) Deducted from Emoluments -->
        ' Q35 = 0
        ' WL("<SpecialContributionPublic>" & FWC(Q35) & "</SpecialContributionPublic>")
        'MT_SpecialContributionPublic = MT_SpecialContributionPublic + Q35
        '<!-- Q35 Special Contribution withheld from Public Sector Officers -->
        'Q36 = 0
        'WL("<SpecialContributionPrivate>" & FWC(Q36) & "</SpecialContributionPrivate>")
        '<!-- Q36 Special Contribution withheld from Private Sector Employees -->
        'Q37 = 0
        'WL("<SpecialContributionEmployer>" & FWC(Q37) & "</SpecialContributionEmployer>")
        '<!-- Q37 Special Contribution of Employer for Employees in the Private Sector -->
        'MT_SpecialContributionPrivate = MT_SpecialContributionPrivate + Q36 + Q37

        'Q38 = StringtoDecimal2ReturnDouble(Ar(48))
        'WL("<ReductionOfEmolumentsAndPensions>" & FWC(Q38) & "</ReductionOfEmolumentsAndPensions>")
        'MT_ReductionOfEmolumentsandPensions = MT_ReductionOfEmolumentsandPensions + Q38

        '<!-- Q38 Broader Public Sector Reduction of Emoluments And Pensions -->
        Q39 = StringtoDecimal2ReturnDouble(Ar(54))
        employeeType = Ar(56)
        If employeeType = "3" Then
            Q39 = 0
        End If
        If Ar(70) = 1 Then
            Q42 = Q39
            Q39 = 0
        Else
            Q42 = 0
        End If

        WL("<GhsWithheldPensionersNormalRate>" & FWC(Q42) & "</GhsWithheldPensionersNormalRate>")
        '<!-- Q42 GHS withheld from pensioners for income subject to normal rate tax -->
        Q43 = 0
        WL("<GhsWithheldPensionersSpecialRate>" & FWC(Q43) & "</GhsWithheldPensionersSpecialRate>")
        '<!-- Q43 GHS withheld from widows' pension -->
        Q44 = Q42 + Q43
        WL("<GhsWithheldPensioners>" & FWC(Q44) & "</GhsWithheldPensioners>")
        MT_GHSWithHeldPensioners = MT_GHSWithHeldPensioners + Q44
        '<!-- Q44 GHS withheld from Pensioners: Sum of Q42 & Q43 -->

        '''''''' GESY CORRECTION FOR 2025 xml
        Q39 = Q39 + Q33
        '''''''' END OF GESY CORRECTION FOR 2025 xml

        WL("<GhsWithheldEmployeesNormalRate>" & FWC(Q39) & "</GhsWithheldEmployeesNormalRate>")
        '<!-- Q39 GHS withheld from employees for income subject to normal rate tax -->
        Q40 = 0
        WL("<GhsWithheldEmployeesSpecialRate>" & FWC(Q40) & "</GhsWithheldEmployeesSpecialRate>")
        '<!-- Q40 GHS withheld from employees for income subject to special rate tax (8%) -->
        Q41 = Q39 + Q40

        WL("<GhsWithheldEmployees>" & FWC(Q41) & "</GhsWithheldEmployees>")
        '<!-- Q41 GHS withheld from employees: Sum of Q39 & Q40 -->
        MT_GHSWithHeldEmployee = MT_GHSWithHeldEmployee + Q41



        If employeeType = 3 Then
            WL("<IsEmployeeAnOfficer>" & 1 & "</IsEmployeeAnOfficer>")
            'reverse 54 with 55 if employee is officer
            Q46 = StringtoDecimal2ReturnDouble(Ar(55))
        Else
            WL("<IsEmployeeAnOfficer>" & 0 & "</IsEmployeeAnOfficer>")
            Q46 = 0
        End If
        '<!-- Q45 Is the employee an Officer? Yes=1 , No=0 -->

        WL("<GhsWithheldOfficers>" & FWC(Q46) & "</GhsWithheldOfficers>")
        MT_GHSWithHeldOfficers = MT_GHSWithHeldOfficers + Q46
        '<!-- Q46 GHS withheld from officers -->
        'GESY CORRECTION FOR XML 2025 , AFERESI GESY TO OTHER DEPARTMENTS
        Q47 = Q41 + Q44 + Q46 - Q33
        'END OF GESY CORRECTION FOR XML 2025 , AFERESI GESY TO OTHER DEPARTMENTS
        'WL("<GhsEmployeesContributionToTaxDepartment>" & FWC(Q47) & "</GhsEmployeesContributionToTaxDepartment>")

        WL("<GhsContributionWithheld>" & FWC(Q47) & "</GhsContributionWithheld>")
        MT_TotalGhsEmployeesContribution = MT_TotalGhsEmployeesContribution + Q47


        '<!-- Q47 GHS Contribution of Employees Payable to Tax Department: Sum of Q41, 44, 46 - ->
        Q48 = Q26 + Q27 + Q28 + Q29 + Q30 + Q31 + Q32 + Q33 + Q34 + Q38 + Q41 + Q44 + Q46 - Q33
        WL("<TotalDeductions>" & FWC(Q48) & "</TotalDeductions>")
        '<!-- Q48 Total Deductions: Sum of Q26, 27, 28, 29, 30, 31, 32, 33, 34, 38, 41, 44, 46 - ->
        Q49 = Q23 - Q48
        WL("<ChargeableIncome>" & FWC(Q49) & "</ChargeableIncome>")
        '<!-- Q49 Chargeable Income: Q23 minus Q48 -->
        Q50 = StringtoDecimal2ReturnDouble(Ar(23))
        WL("<TaxWithheldEmolumentsNormalRate>" & FWC(Q50) & "</TaxWithheldEmolumentsNormalRate>")
        '<!-- Q50 Tax withheld from emoluments with normal rate -->
        Q51 = 0
        WL("<TaxWithheldEmolumentsSpecialRate>" & FWC(Q51) & "</TaxWithheldEmolumentsSpecialRate>")
        '<!-- Q51 Tax withheld from emoluments with special rate (8%) -->
        Q52 = 0
        WL("<TaxWithheldPensionsNormalRate>" & FWC(Q52) & "</TaxWithheldPensionsNormalRate>")
        '<!-- Q52 Tax withheld from pensions with normal rates -->
        Q53 = 0
        WL("<TaxWithheldPensionsSpecialRate>" & FWC(Q53) & "</TaxWithheldPensionsSpecialRate>")
        '<!-- Q53 Tax withheld from widows' pension -->
        Q54 = Q50 + Q51 + Q52 + Q53
        WL("<TaxWithheldForYear>" & FWC(Q54) & "</TaxWithheldForYear>")
        '<!-- Q54 Tax Withheld: Sum of Q50, Q51, Q52, Q53 - ->
        Q55 = 0

        'xxxxxxx
        Dim NotionalIncomeTax As Double = StringtoDecimal2ReturnDouble(Trim(Ar(72)))

        WL("<FinancialBenefitDeductions>" & FWC(NotionalIncomeTax) & "</FinancialBenefitDeductions>")

        MT_FinancialBenefitDeduction = MT_FinancialBenefitDeduction + NotionalIncomeTax

        WL("<TaxWithheldFromPriorYearBonus>" & FWC(Q55) & "</TaxWithheldFromPriorYearBonus>")
        MT_TaxWithheldPriorYearBonus = MT_TaxWithheldPriorYearBonus + Q55


        MT_TaxWithheld = MT_TaxWithheld + Q55 + Q54
        '<!-- Q55 Tax withheld from prior year bonus -->
        If employeeType = "3" Then
            'Contribution of Officer is on Ar(54)
            Q56 = StringtoDecimal2ReturnDouble(Ar(54))
        Else
            'Contribution of NON Officer is on Ar(55)
            Q56 = StringtoDecimal2ReturnDouble(Ar(55))
        End If

        WL("<BonusGhsWithheldOfficers>0,00</BonusGhsWithheldOfficers>")
        MT_TotalGhsEmployeesContribution = MT_TotalGhsEmployeesContribution + 0
        '<!-- q44 GHS Withheld from Officers (Prior Year Bonus)  - sum of all monthly employee Q21 - MANDATORY  -->
        WL("<BonusGhsWithheldEmployees>0,00</BonusGhsWithheldEmployees>")
        MT_TotalGhsEmployeesContribution = MT_TotalGhsEmployeesContribution + 0
        MT_TotalGhsEmployersContribution = MT_TotalGhsEmployersContribution + 0


        '<!-- q45 GHS Withheld from employees (Prior Year Bonus)  - sum of all monthly employee Q22 - MANDATORY  -->
        WL("<BonusGhsEmployersContribution>0,00</BonusGhsEmployersContribution>")
        '<!-- q46 GHS Employer's Contribution (Prior Year Bonus)  - sum of all monthly employee Q23 - MANDATORY  -->







        WL("<GhsEmployersContribution>" & FWC(Q56) & "</GhsEmployersContribution>")
        MT_TotalGhsEmployersContribution = MT_TotalGhsEmployersContribution + Q56
        '<!-- Q56 GHS Employer's Contribution Payable to Tax Department -->





        'Dim salaryPeriods As Integer = Ar(42)
        'WL("<SalaryPaymentMethod>" & salaryPeriods & "</SalaryPaymentMethod>")
        ''<!-- Q57 Method of salary payment  Monthly (12 Or 13) Or Weekly (52 Or 53) -->
        'If Trim(Ar(26)) <> "" Then
        '    Dim S As String

        '    S = changeformtatodate2(Trim(Ar(26)))
        '    WL("<EmploymentCommencementDate>" & S & "</EmploymentCommencementDate>")
        '    '<!-- Q58 Commencement of Employment Date during the current year: Dates must be in format YYYY-MM-DD -->
        '    'R(31) = S
        'End If
        'If Trim(Ar(27)) <> "" Then
        '    Dim S As String
        '    S = changeformtatodate2(Trim(Ar(27)))
        '    WL("<EmploymentTerminationDate>" & S & "</EmploymentTerminationDate>")
        '    '<!-- Q59 Termination of Employment Date during the current year -->
        '    '  R(32) = S
        'End If

        WL("</PayeEmployee>")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'WL("<mof:row number=""" & Ar(11)) & """>")
        'R(0) = Ar(11))
        'If Trim(Ar(2)) <> "" Then
        '    'TIC Number
        '    WL("<mof:field key=""epr7m6t0r1c1"">" & Trim(Ar(2)) & "</mof:field>")
        '    R(1) = Trim(Ar(2))
        'Else
        '    If Ar(43) = 1 Then
        '        'ARITHMOS TAYTOPOIISIS
        '        WL("<mof:field key=""epr7m6t0r1c2"">" & "Τ" & "</mof:field>")
        '        R(2) = "Τ"
        '    ElseIf Ar(43) = 2 Then
        '        WL("<mof:field key=""epr7m6t0r1c2"">" & "Α" & "</mof:field>")
        '        R(2) = "Α"
        '    ElseIf Ar(43) = 3 Then
        '        WL("<mof:field key=""epr7m6t0r1c2"">" & "Φ" & "</mof:field>")
        '        R(2) = "Φ"
        '    End If
        '    'WL("<mof:field key=""epr7m6t0r1c2"">" & Trim(Ar(3)) & "</mof:field>")
        '    'OTHER COUNTRY TIC
        '    WL("<mof:field key=""epr7m6t0r1c3"">" & Trim(Ar(4)) & "</mof:field>")
        '    R(3) = Trim(Ar(4))
        'End If

        ''SOCIAL INSURANCE NUMBER
        'WL("<mof:field key=""epr7m6t0r1c4"">" & Trim(Ar(5)) & "</mof:field>")
        'R(4) = Trim(Ar(5))

        ''SURNAME
        'WL("<mof:field key=""epr7m6t0r1c6"">" & Trim(Ar(6)) & "</mof:field>")
        'R(5) = Trim(Ar(6))
        ''NAME
        'WL("<mof:field key=""epr7m6t0r1c5"">" & Trim(Ar(7)) & "</mof:field>")
        'R(6) = Trim(Ar(7))
        ''STREET AND NUMBER
        'WL("<mof:field key=""epr7m6t0r1c7"">" & Trim(Ar(8)) & "</mof:field>")
        'R(7) = Trim(Ar(8))
        ''TOWN VILLAGE
        'WL("<mof:field key=""epr7m6t0r1c7b"">" & Trim(Ar(9)) & "</mof:field>")
        'R(8) = Trim(Ar(9))

        ''POST CODE
        'WL("<mof:field key=""epr7m6t0r1c7c"">" & Trim(Ar(10)) & "</mof:field>")
        'R(9) = Trim(Ar(10))
        ''EMAIL ADDRESS
        ''WL("<mof:field key=""epr7m6t0r1c7d"">" & Trim(Ar(10)) & "</mof:field>")


        ''#2019 Employee Type
        'employeeType = Trim(Ar(56))

        'WL("<mof:field key=""epr7m6t0r1c7e"">" & employeeType & "</mof:field>")
        'R(10) = employeeType



        'If Entos> 0 Then
        '    Entos = Entos - (BIKWithSI + BIKWithoutSI)
        'End If

        ''GROSS WITHIN THE REPUBLIC OF CYPRUS
        'WL("<mof:field key=""epr7m6t0r1c8"">" & Entos & "</mof:field>")
        'R(11) = Entos

        ''OUTSIDE THE REPUBLIC OF CYPRUS
        'WL("<mof:field key=""epr7m6t0r1c9"">" & Trim(Ar(13))) & "</mof:field>")
        'R(12) = Trim(Ar(13)))

        ''ALLOWANCES/BENEFITS/COMMITIONS
        ''51 (C_BIK_withSI)), 11) & PP
        ''52 (C_BIK_withoutSI)), 11) & PP

        'WL("<mof:field key=""epr7m6t0r1c10"">" & BIKWithSI & "</mof:field>")
        'R(13) = BIKWithSI
        ''**************for 2018 GALATARIOTIS
        ''Ar(52) = Ar(14)

        'WL("<mof:field key=""epr7m6t0r1c10b"">" & BIKWithoutSI & "</mof:field>")
        'R(14) = BIKWithoutSI


        ''TOTAL OF COLUMNS
        'WL("<mof:field key=""epr7m6t0r1c11"">" & Ar(15)) & "</mof:field>")
        'R(15) = Ar(15))
        ''TAXABLE FROM OTHER SOURCES
        ''WL("<mof:field key=""epr7m6t0r1c11c"">" & Trim(Ar(15))) & "</mof:field>")

        ''SOCIAL INSURANCE FUND
        'WL("<mof:field key=""epr7m6t0r1c12"">" & Trim(Ar(16))) & "</mof:field>")
        'R(16) = Ar(16))

        ''PROVIDENT FUND AND PENSION FUND
        'WL("<mof:field key=""epr7m6t0r1c13"">" & Trim(Ar(17))) & "</mof:field>")
        'R(17) = Ar(17))
        ''MEDICAL FUND
        'WL("<mof:field key=""epr7m6t0r1c14"">" & Trim(Ar(18))) & "</mof:field>")
        'R(18) = Ar(18))
        ''UNIONS
        'WL("<mof:field key=""epr7m6t0r1c15"">" & Trim(Ar(19))) & "</mof:field>")
        'R(19) = Ar(19))
        ''Life Insurance
        'WL("<mof:field key=""epr7m6t0r1c15b"">" & Trim(Ar(44))) & "</mof:field>")
        'R(20) = Ar(44))
        ''NON TAXABLE INCOME (INCLUDED IN TOTALS)

        'WL("<mof:field key=""epr7m6t0r1c15c"">" & Trim(Ar(46))) & "</mof:field>")
        'R(21) = Ar(46))

        ''Other Discounts
        'WL("<mof:field key=""epr7m6t0r1c16"">" & OtherDiscounts) & "</mof:field>")
        'R(22) = OtherDiscounts)

        ''Total Discounts
        'WL("<mof:field key=""epr7m6t0r1c17"">" & Trim(Ar(21))) & "</mof:field>")
        'R(23) = Ar(21))
        ''TAXABLE INCOME
        'WL("<mof:field key=""epr7m6t0r1c18"">" & Trim(Ar(22))) & "</mof:field>")
        'R(24) = Ar(22))

        ''INCOME TAX
        'WL("<mof:field key=""epr7m6t0r1c19"">" & StringtoDecimal2(Ar(23))) & "</mof:field>")
        'R(25) = StringtoDecimal2(Ar(23)))
        ''SPECIAL CONTRIBUTION - gesi not FOR 2017
        ''WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(Ar(24))) & "</mof:field>")

        ''EISFORA SYNTAKSIODOTIKON OFELIMATON (+xiron orfanon + tameio syntaksis - na elegxw an einai mesa)
        'WL("<mof:field key=""epr7m6t0r1c19c"">" & StringtoDecimal2(Ar(47))) & "</mof:field>")
        'R(26) = StringtoDecimal2(Ar(47)))
        ''''
        ''MEIOSI APOLAVON
        'WL("<mof:field key=""epr7m6t0r1c19d"">" & StringtoDecimal2(Ar(48))) & "</mof:field>")
        'R(27) = StringtoDecimal2(Ar(48)))
        ''GESI NOT FOR 2017
        ''WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(Ar(40))) & "</mof:field>")
        ''GESI NOT FOR 2017
        ''WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(Ar(41))) & "</mof:field>")

        ''DIAGRAFETE
        ''WL("<mof:field key=""epr7m6t0r1c19g"">" & Ar(42) & "</mof:field>")



        ''53 (C_GESYtoSI)), 11) & PP
        'WL("<mof:field key=""epr7m6t0r1c19b"">" & StringtoDecimal2(Ar(53))) & "</mof:field>")
        'R(28) = StringtoDecimal2(Ar(53)))
        ''54 (C_GESYtoBIKDed)), 11) & PP
        'WL("<mof:field key=""epr7m6t0r1c19e"">" & StringtoDecimal2(Ar(55))) & "</mof:field>")
        'R(29) = StringtoDecimal2(Ar(55)))
        ''55 (C_GESYtoBIKCon)), 11)
        'WL("<mof:field key=""epr7m6t0r1c19f"">" & StringtoDecimal2(Ar(54))) & "</mof:field>")
        'R(30) = StringtoDecimal2(Ar(54)))

        ''''

        'If Trim(Ar(26)) <> "" Then
        '    Dim S As String
        '    S = changeformtatodate(Trim(Ar(26)))
        '    WL("<mof:field key=""epr7m6t0r1c20"">" & S & "</mof:field>")
        '    R(31) = S
        'End If
        'If Trim(Ar(27)) <> "" Then
        '    Dim S As String
        '    S = changeformtatodate(Trim(Ar(27)))
        '    WL("<mof:field key=""epr7m6t0r1c21"">" & S & "</mof:field>")
        '    R(32) = S
        'End If
        'WL("<mof:field key=""epr7m6t0r1c22"">" & CheckforZero(Trim(Ar(38))) & "</mof:field>")
        '' R(33) = CheckforZero(Trim(Ar(38)))
        ''WL("<mof:field key=""epr7m6t0r1c23"">" & Trim(Ar(39)) & "</mof:field>")
        'WL("</mof:row>")

        MyDsxl.Tables(0).Rows.Add(R)

    End Sub
End Class
