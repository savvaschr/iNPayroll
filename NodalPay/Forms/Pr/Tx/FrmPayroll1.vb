Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmPayroll1
    '    Dim GeneralPath As String = Application.StartupPath & "\"
    Dim FnameToLoadforSAPOneFile As String
    Dim GLBSetSalaryToZero As Boolean = False
    Dim GlbAveragecommision As Double = 0
    Dim DsNet As DataSet
    Public DtNet As DataTable
    Dim StopSearch As Boolean = False

    Dim Sels_Counter As Integer = 0
    Dim Sels_ArBegin(5000) As String
    Dim Sels_ArEnd(5000) As String


    Dim GLBDsEmp As DataSet

    Dim NAVOUTFileDir As String
    Dim NotNow As Boolean
    Dim InitFile As Boolean = True
    Dim InitFileSAP As Boolean = True

    Dim GLB_PreviousPeriod As New cPrMsPeriodCodes

    Public PasswordForDeletion As String = ""
    Public NavisionPostingdate As Date

    Public GLBChequeNo As String
    Public GLBChequeDate As Date

    Public GLBSelectedEDCforImport As String

    Public GLB_Import_Prefix As String
    Public GLB_Import_CodeLen As String
    Public GLB_Import_PadingChar As String

    Dim GLBColaValueNotZero As Boolean = False


    Public LFE_EDCType As String
    Public LFE_FirstLine As Integer
    Public LFE_EDCCode As String
    Public LFE_EmployeeColumnNo As Integer
    Public LFE_EDCValueColumnNo As Integer
    Public LFE_File As String
    Public LFE_Proceed As Boolean = False
    Public LFE_LoadUnits As Boolean = False
    Public LFE_SetDiffinSi As Boolean = False

    Public LFE_OV1_EDCType As String
    Public LFE_OV1_EDCCode As String
    Public LFE_OV1_FirstLine As Integer
    Public LFE_OV1_EmployeeColumnNo As Integer
    Public LFE_OV1_EmployeeTotalLen As Integer
    Public LFE_OV1_EmployeePrefix As String
    Public LFE_OV1_File As String
    Public LFE_OV1_Proceed As Boolean = False

    Public LFE_OV2_FirstLine As Integer
    Public LFE_OV2_EmployeeColumnNo As Integer
    Public LFE_OV2_EmployeeTotalLen As Integer
    Public LFE_OV2_EmployeePrefix As String

    Public LFE_OV2_colOver1 As String
    Public LFE_OV2_colOver2 As String
    Public LFE_OV2_colOver3 As String

    Public LFE_OV2_icolOver1 As Integer
    Public LFE_OV2_icolOver2 As Integer
    Public LFE_OV2_icolOver3 As Integer

    Public LFE_OV2_File As String
    Public LFE_OV2_Proceed As Boolean = False

    Dim ArCalculations() As FrmPrTxCalculatePayroll
    Dim TempAr() As FrmPrTxCalculatePayroll

    Public MyDs As DataSet
    Dim Dt1 As DataTable

    Public DsLbl As DataSet
    Dim DtLbl As DataTable

    Public MyDsReport As DataSet
    Dim DtR As DataTable

    Dim GLBTempGroup As New cPrMsTemplateGroup
    Dim GLBCurrentPeriod As New cPrMsPeriodCodes
    Dim DsP_Ern As DataSet
    Dim DsP_Ded As DataSet
    Dim DsP_Con As DataSet
    Dim Column_Status As Integer = 0
    Dim Column_Enabled As Integer = 1
    Dim Column_EmpCode As Integer = 2
    Dim Column_EmpName As Integer = 3
    Dim Column_ActualUnits As Integer = 4
    Dim Column_Overtime1 As Integer = 5
    Dim Column_Overtime2 As Integer = 6
    Dim Column_Overtime3 As Integer = 7
    Dim Column_SIUnits As Integer = 8

    '''''''''''''''''''''''''''''''''
    Dim Column_Sectors As Integer = 9
    Dim Column_DutyHours As Integer = 10
    Dim Column_FlightHours As Integer = 11
    Dim Column_Commission As Integer = 12
    Dim Column_OverLay As Integer = 13
    Dim Column_PBAmount As Integer = 14
    Dim Column_PBRate As Integer = 15

    ''''''''''' Earnings ''''''''''''
    Dim Column_E1 As Integer = 16
    Dim Column_EV1 As Integer = 17
    Dim Column_E2 As Integer = 18
    Dim Column_EV2 As Integer = 19
    Dim Column_E3 As Integer = 20
    Dim Column_EV3 As Integer = 21
    Dim Column_E4 As Integer = 22
    Dim Column_EV4 As Integer = 23
    Dim Column_E5 As Integer = 24
    Dim Column_EV5 As Integer = 25
    Dim Column_E6 As Integer = 26
    Dim Column_EV6 As Integer = 27
    Dim Column_E7 As Integer = 28
    Dim Column_EV7 As Integer = 29
    Dim Column_E8 As Integer = 30
    Dim Column_EV8 As Integer = 31
    Dim Column_E9 As Integer = 32
    Dim Column_EV9 As Integer = 33
    Dim Column_E10 As Integer = 34
    Dim Column_EV10 As Integer = 35
    Dim Column_E11 As Integer = 36
    Dim Column_EV11 As Integer = 37
    Dim Column_E12 As Integer = 38
    Dim Column_EV12 As Integer = 39
    Dim Column_E13 As Integer = 40
    Dim Column_EV13 As Integer = 41
    Dim Column_E14 As Integer = 42
    Dim Column_EV14 As Integer = 43
    Dim Column_E15 As Integer = 44
    Dim Column_EV15 As Integer = 45
    ''''''''''' Deductions '''''''''
    Dim Column_D1 As Integer = 46
    Dim Column_DV1 As Integer = 47
    Dim Column_D2 As Integer = 48
    Dim Column_DV2 As Integer = 49
    Dim Column_D3 As Integer = 50
    Dim Column_DV3 As Integer = 51
    Dim Column_D4 As Integer = 52
    Dim Column_DV4 As Integer = 53
    Dim Column_D5 As Integer = 54
    Dim Column_DV5 As Integer = 55
    Dim Column_D6 As Integer = 56
    Dim Column_DV6 As Integer = 57
    Dim Column_D7 As Integer = 58
    Dim Column_DV7 As Integer = 59
    Dim Column_D8 As Integer = 60
    Dim Column_DV8 As Integer = 61
    Dim Column_D9 As Integer = 62
    Dim Column_DV9 As Integer = 63
    Dim Column_D10 As Integer = 64
    Dim Column_DV10 As Integer = 65
    Dim Column_D11 As Integer = 66
    Dim Column_DV11 As Integer = 67
    Dim Column_D12 As Integer = 68
    Dim Column_DV12 As Integer = 69
    Dim Column_D13 As Integer = 70
    Dim Column_DV13 As Integer = 71
    Dim Column_D14 As Integer = 72
    Dim Column_DV14 As Integer = 73
    Dim Column_D15 As Integer = 74
    Dim Column_DV15 As Integer = 75
    '''''''' Contributions '''''''''
    Dim Column_C1 As Integer = 76
    Dim Column_CV1 As Integer = 77
    Dim Column_C2 As Integer = 78
    Dim Column_CV2 As Integer = 79
    Dim Column_C3 As Integer = 80
    Dim Column_CV3 As Integer = 81
    Dim Column_C4 As Integer = 82
    Dim Column_CV4 As Integer = 83
    Dim Column_C5 As Integer = 84
    Dim Column_CV5 As Integer = 85
    Dim Column_C6 As Integer = 86
    Dim Column_CV6 As Integer = 87
    Dim Column_C7 As Integer = 88
    Dim Column_CV7 As Integer = 89
    Dim Column_C8 As Integer = 90
    Dim Column_CV8 As Integer = 91
    Dim Column_C9 As Integer = 92
    Dim Column_CV9 As Integer = 93
    Dim Column_C10 As Integer = 94
    Dim Column_CV10 As Integer = 95
    Dim Column_C11 As Integer = 96
    Dim Column_CV11 As Integer = 97
    Dim Column_C12 As Integer = 98
    Dim Column_CV12 As Integer = 99
    Dim Column_C13 As Integer = 100
    Dim Column_CV13 As Integer = 101
    Dim Column_C14 As Integer = 102
    Dim Column_CV14 As Integer = 103
    Dim Column_C15 As Integer = 104
    Dim Column_CV15 As Integer = 105

    Dim Color_Edit As Color = Color.DarkBlue

    'Dim Color_NormalFields As Color = Color.LemonChiffon
    'Dim Color_NotEdit As Color = Color.Black
    'Dim Color_Earnings As Color = Color.MistyRose
    'Dim Color_Deductions As Color = Color.PaleGoldenrod
    'Dim Color_Contributions As Color = Color.PaleGreen


    Dim Color_NormalFields As Color = Color.White
    Dim Color_NotEdit As Color = Color.Black
    Dim Color_Earnings As Color = Color.LightBlue
    Dim Color_Deductions As Color = Color.White
    Dim Color_Contributions As Color = Color.LightBlue

    Dim Loading As Boolean = False
    Public IncludeEmployees As Boolean = False

    Dim OldName As String
    Dim OldPFName As String
    Dim GLFilecounter As Integer
    Dim PFFilecounter As Integer
    Dim GLBCompany As cAdMsCompany
    Dim GLBDoubleClick As Boolean = True

    Dim InterfaceFileisOK As Boolean = False
    Dim GLBTemplateAnnualAllocation As Boolean = False

    Dim GLB_PBAmount As Double = 0
    Dim GLB_PBRate As Double = 0
    Dim glb_PBSalary As Double = 0

    Dim GLBTotalWorkDaysInMonth As Integer = 0
    Dim GLBCalculateRateOnDays As Boolean = False
    Dim GLBLimits As New cPrSsLimits

    Public CalledByEmployee As Boolean = False
    Public CalledByEmployee_TemplateGroup As String = ""
    Public CalledByEmployee_TemplateGroupToString As String = ""
    Public CalledByEmployee_EmployeeCode As String = ""

    Dim DedtorsFile As String
    Dim InitFileDedtors As Boolean
    Dim CreditorsFile As String
    Dim InitFileCreditors As Boolean


    Public KELIO_Prefix As String
    Public KELIO_FirstLine As Integer
    Public KELIO_ErnCode As String
    Public KELIO_ErnColumnNo As Integer
    Public KELIO_EmployeeColumnNo As Integer
    Public KELIO_Over1 As Integer
    Public KELIO_Over2 As Integer
    Public KELIO_PM As Integer
    Public KELIO_File As String
    Public KELIO_Proceed As Boolean = False

    Public GLBRunNext As Boolean
    Public GLBRunPrevious As Boolean
    Public GLBGridIndex As Integer
    Dim GLBSalary2OvertimeRate As Double = 0
    Dim GLBOvertimeRateFromRateOnSalary As Double = 0
    Dim GLBMaximumYear As String
    Dim dsTemplateGroups As DataSet

    Public YTDEmailmethod As Integer = 0
    Public YTDScheduled As Boolean = False
    Public YTDscheduledDatetime As Date = Now

    Dim glbCurrentEmployeeSIRate_contribution As Double = 0
    Dim glbCurrentEmployeeSIRate_deduction As Double = 0


    Private Sub FrmPayroll1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim P As New cPrSsParameters("System", "AllocationStatus")
        If P.Value1 = "" Then
            MsgBox("Please define Allocation Status Variable")
            GLBMaximumYear = "2000"
        Else
            GLBMaximumYear = P.Value1
            'GLBMaximumYear = Encryption.MakePassword(P.Value1, 653)
            GLBMaximumYear = Utils.Encrypt("2025")
            GLBMaximumYear = Utils.Decrypt(P.Value1)

        End If

        If UCase(Global1.UserName) = UCase("nodal") Then
            Me.btnShowTotals.Visible = True
        End If

        Me.ComboNoOfRows.SelectedIndex = Global1.PARAM_DefRowCount

        Me.mnuIOCFile.Visible = False
        ' Me.mnuROBFile.Visible = False
        Me.Width = CType(Me.MdiParent, FrmMain).Width - 30
        Me.Height = CType(Me.MdiParent, FrmMain).Height - 150
        LoadForm()
        CheckPermition()
        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Or Global1.PARAM_AllowMarkAsInterface Then
            Me.btnSCP.Visible = True
            MarkAsInterfacedToolStripMenuItem.Visible = True
        Else
            Me.btnSCP.Visible = False
            MarkAsInterfacedToolStripMenuItem.Visible = False
        End If
        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
            Me.AdminMenu.Visible = True
        Else
            Me.AdminMenu.Visible = False
        End If

        Me.CBReloadsalary.Checked = True

        Dim Ds As DataSet
        Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
        If CheckDataSet(Ds) Then
            GLBLimits = New cPrSsLimits(Ds.Tables(0).Rows(0))
        End If
        If CalledByEmployee Then
            Me.ComboTempGroups.SelectedIndex = Me.ComboTempGroups.FindStringExact(Me.CalledByEmployee_TemplateGroupToString)
            Me.txtFromEmployee.Text = Me.CalledByEmployee_EmployeeCode
            Me.txtToEmployee.Text = Me.CalledByEmployee_EmployeeCode
            SearchGlobal("", 1, "")
            Me.LabelStatus.Text = ""

        End If
        CountReminders()
        If Global1.PARAM_SI_EDCCodes_ForReporting = "" Then

            Me.mnuYTDInExcel.Visible = False
            Me.mnuYTDInPDF.Visible = False
            Me.mnuYTDInPDFandEMAIL.Visible = False
            ToolStripSeparatorYTD.Visible = False
            Me.mnuExportYearlyPayslipInExcelTotals.Visible = False
        End If





    End Sub

    Private Sub DissableAll_SALARY()

        Me.TSBCalculateALL.Enabled = False
        Me.TSBPostAll.Enabled = False
        ToolStripDropDownButton1.Enabled = False
        ToolStripDropDownButton3.Enabled = False
        TSBAnnualLeave.Enabled = False
        TSInterface.Enabled = False
        mnuPrintPayslips.Enabled = False
        btncalcSelectedLine.Enabled = False
        Button1.Enabled = False
        GLBSetSalaryToZero = True

    End Sub
    Private Sub CheckPermition()

        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Payroll")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                GLBDoubleClick = False
                ToolStripDropDownButton2.Enabled = False
                ToolStripDropDownButton3.Enabled = False
                btnUndoCalculation.Visible = False
                ToolStripDropDownButton1.Enabled = False
                TSInterface.Enabled = False
                mnuPrintPayslips.Enabled = False
                GLBSetSalaryToZero = True
            End If
            Dim PA As New cPrSsUserPermitions("", Global1.GLBUserCode, "Payroll AnnualLeave")
            If PA.id > 0 Then
                If PA.ReadonlyPermission = 1 Then
                    TSBAnnualLeave.Enabled = False
                End If
            Else
                MsgBox("Please Define User Permissions, Payroll AnnualLeave", MsgBoxStyle.Critical)
                Me.Close()
            End If
        Else
            MsgBox("Please Define User Permissions, Payroll", MsgBoxStyle.Critical)
            Me.Close()
        End If

        Dim P1 As New cPrSsUserPermitions("", Global1.GLBUserCode, "Salary")
        If P1.id > 0 Then
            If P1.NoPermission = 1 Then
                GLBDoubleClick = False
                DissableAll_SALARY()
            End If
        End If

        Me.mnuPayrollAnalysis.Enabled = False
        Me.mnuSIReports.Enabled = False
        Me.mnuIRReports.Enabled = False

        If Not CType(Me.MdiParent, FrmMain).MnuReports.Enabled Then
            Me.mnuPayrollAnalysis.Enabled = False
            Me.mnuSIReports.Enabled = False
            Me.mnuIRReports.Enabled = False
        Else
            Me.mnuPayrollAnalysis.Enabled = CType(Me.MdiParent, FrmMain).MnuPayrollAnalysis.Enabled
            Me.mnuSIReports.Enabled = CType(Me.MdiParent, FrmMain).MnuRptSIContributions.Enabled
            Me.mnuIRReports.Enabled = CType(Me.MdiParent, FrmMain).MnuRptIR63A.Enabled
        End If

    End Sub
    Public Sub LoadForm()

        Me.Top = 0
        Me.Left = 0
        LoadComboSelectAnal()
        LoadStatusCombo()
        NotNow = True
        LoadCombos()
        NotNow = False

        InitDataTable()
        InitDataGrid()

        InitDataTableLabels()
        InitDataGridLabels()

        Me.InitDataTable_NET()
        Me.InitDataGrid_NET()

        Me.ClearGridColumns()
        FixColumns_Normal_Color()

        Dim Ds As DataSet

        Ds = Global1.Business.GetParameter("System", "ALAllocation")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_AnnualLeaveAllocation = True
            Else
                Global1.PARAM_AnnualLeaveAllocation = False
            End If
        Else
            Global1.PARAM_AnnualLeaveAllocation = False
        End If




        Ds = Global1.Business.GetParameter("System", "ALMonthRate")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.RateForAnnualLeaveForAll = Par.Value1

        Else
            Global1.RateForAnnualLeaveForAll = 0
        End If


        Ds = Global1.Business.GetParameter("System", "UseWorkingdays")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_USE_Workingdays = True
            Else
                Global1.PARAM_USE_Workingdays = False
            End If

        Else
            Global1.PARAM_USE_Workingdays = False
        End If

        FindCurrentPeriod(True, "", 1, "")

        Ds = Global1.Business.GetParameter("Reports", "Payslip")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            GLB_PAYSLIPReport = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Overtime", "Overtime1")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Parameters.OverTime_Rate1 = Par.Value1
        Else
            Parameters.OverTime_Rate1 = 1.5
        End If
        Ds = Global1.Business.GetParameter("Overtime", "Overtime2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Parameters.OverTime_Rate2 = Par.Value1
        Else
            Parameters.OverTime_Rate2 = 2.0
        End If

        Ds = Global1.Business.GetParameter("Overtime", "Overtime3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Parameters.OverTime_Rate3 = Par.Value1
        Else
            Parameters.OverTime_Rate3 = 2.0
        End If


        Ds = Global1.Business.GetParameter("IT", "AllowNegative")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_Allow_NegativeTAX = False
            Else
                Global1.PARAM_Allow_NegativeTAX = True
            End If
        End If

        Ds = Global1.Business.GetParameter("System", "Onefile")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.GLB_OneInterfaceFile = True
            Else
                Global1.GLB_OneInterfaceFile = False
            End If
        Else
            Global1.GLB_OneInterfaceFile = False
        End If

        Ds = Global1.Business.GetParameter("System", "NoAnnualUnits")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 0 Then
                Global1.GLB_NoAnnualUnits = False
            Else
                Global1.GLB_NoAnnualUnits = True
            End If
        End If


        Ds = Global1.Business.GetParameter("System", "Average13")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 0 Then
                Global1.PARAM_Average_13_14 = False
            Else
                Global1.PARAM_Average_13_14 = True
            End If
        End If

        Ds = Global1.Business.GetParameter("System", "AvgEarn13")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_EarningsFor_13_14 = Par.Value1
        Else
            Global1.PARAM_EarningsFor_13_14 = ""
        End If

        Ds = Global1.Business.GetParameter("System", "AvgCom")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 0 Then
                Global1.PARAM_ShowIncommision = False
            Else
                Global1.PARAM_ShowIncommision = True
            End If
        Else
            Global1.PARAM_ShowIncommision = False
        End If

        ''''''''''''''' Time Attendance NYS ''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Ds = Global1.Business.GetParameter("TA", "EnableTA")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "0" Then
                Global1.PARAM_TAFileEnable = False
            Else
                Global1.PARAM_TAFileEnable = True
            End If
        Else
            Global1.PARAM_TAFileEnable = False
        End If


        Ds = Global1.Business.GetParameter("TA", "FilePath")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_TAFilePath = Par.Value1
        Else
            Global1.PARAM_TAFilePath = ""
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' SPECIAL DEDUCTION ON PENSION ''''''''''''''''''''''''''
        Ds = Global1.Business.GetParameter("System", "SDonPension")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_SpecialDedonPension = True
            Else
                Global1.PARAM_SpecialDedonPension = False
            End If
        End If


        Ds = Global1.Business.GetParameter("System", "Salary_1_2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_Salary_1_2 = True
            Else
                Global1.PARAM_Salary_1_2 = False
            End If
        End If

        Ds = Global1.Business.GetParameter("System", "ALAllocationTG")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_AnnualLeaveAllocationTemplateGroups = Par.Value1
        Else
            Global1.PARAM_AnnualLeaveAllocationTemplateGroups = ""
        End If

        Ds = Global1.Business.GetParameter("System", "SPTaxOnOtIncome1")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                PARAM_SpecialDedonOTI1 = True

            Else
                PARAM_SpecialDedonOTI1 = False

            End If
        Else
            PARAM_SpecialDedonOTI1 = False

        End If

        Ds = Global1.Business.GetParameter("System", "Airlines")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.GLBAirlines = True
            Else
                Global1.GLBAirlines = False
            End If
        Else
            Global1.GLBAirlines = False
        End If

        Ds = Global1.Business.GetParameter("System", "HideOver")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))

            If Par.Value1 = "1" Then
                Global1.GLBHideOver = True
            Else
                Global1.GLBHideOver = False
            End If
        Else
            Global1.GLBHideOver = False
        End If

        Ds = Global1.Business.GetParameter("Payslip", "ApprovedBy")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_Payslip_ApprovedBy = Par.Value1
        Else
            Global1.PARAM_Payslip_ApprovedBy = ""
        End If

        Ds = Global1.Business.GetParameter("Payslip", "PreparedBy")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_Payslip_PreparedBy = Par.Value1
        Else
            Global1.PARAM_Payslip_PreparedBy = ""
        End If


        Ds = Global1.Business.GetParameter("Payslip", "OnlyValues")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                GLBPayslipShowOnlyWithValue = True
            Else
                GLBPayslipShowOnlyWithValue = False
            End If
        Else
            GLBPayslipShowOnlyWithValue = False
        End If

        Ds = Global1.Business.GetParameter("System", "P3toP7")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_P3toP7 = True
            Else
                Global1.PARAM_P3toP7 = False
            End If
        Else
            Global1.PARAM_P3toP7 = False
        End If

        Ds = Global1.Business.GetParameter("System", "OTRateFromPrevious")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_OvertimeRateOfPreviousPeriod = True
            Else
                Global1.PARAM_OvertimeRateOfPreviousPeriod = False
            End If
        Else
            PARAM_OvertimeRateOfPreviousPeriod = False
        End If

        Ds = Global1.Business.GetParameter("System", "PAYE")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_PAYE = True
            Else
                Global1.PARAM_PAYE = False
            End If
        Else
            PARAM_PAYE = True
        End If

        Ds = Global1.Business.GetParameter("System", "PAYEProRata")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_PAYEProRata = True
            Else
                Global1.PARAM_PAYEProRata = False
            End If
        Else
            PARAM_PAYEProRata = False
        End If

        Ds = Global1.Business.GetParameter("System", "SplitIsEnabled")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_SplitIsEnabled = True
            Else
                Global1.PARAM_SplitIsEnabled = False
            End If
        Else
            Global1.PARAM_SplitIsEnabled = False
        End If

        Ds = Global1.Business.GetParameter("Payslip", "CCAddress")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_PayslipCC = Par.Value1
        Else
            Global1.Param_PayslipCC = ""
        End If


        Ds = Global1.Business.GetParameter("System", "EmpCodeOnPayRef")
        Global1.PARAM_EmpCodeinChequeRef = False
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_EmpCodeinChequeRef = True
            Else
                Global1.PARAM_EmpCodeinChequeRef = False
            End If

        End If

        Ds = Global1.Business.GetParameter("System", "ShowEmpNameOnInt")
        Global1.PARAM_ShowEmpNameOnInterface = False
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_ShowEmpNameOnInterface = True
            Else
                Global1.PARAM_ShowEmpNameOnInterface = False
            End If

        End If

        Ds = Global1.Business.GetParameter("System", "NoCOLAonArrears")
        Global1.PARAM_NoCOLAOnArrears = False
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_NoCOLAOnArrears = True
            Else
                Global1.PARAM_NoCOLAOnArrears = False
            End If
        End If



        If Global1.PARAM_TAFileEnable Then
            Me.TSUploadTAFile.Visible = True
        Else
            Me.TSUploadTAFile.Visible = False
        End If


        Me.CBBank.Checked = True
        Me.CBEwallet.Checked = True
        Me.CBCash.Checked = True
        Me.CBCheque.Checked = True
        Me.RadioCode.Checked = True
        GetSpecialTaxLimits()
        If Global1.GLBAirlines Then
            Me.mnuIOCFile.Visible = True
            ' Me.mnuROBFile.Visible = True
        End If

        Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
        If CheckDataSet(Ds) Then
            Global1.GlbLimits = New cPrSsLimits(Ds.Tables(0).Rows(0))
        Else
            MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        ''''''''''''''' Time Attendance HOSH ''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Ds = Global1.Business.GetParameter("ET", "EnableET")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "0" Then
                Global1.PARAM_ETFileEnable = False
            Else
                Global1.PARAM_ETFileEnable = True
            End If
        Else
            Global1.PARAM_ETFileEnable = False
        End If


        Ds = Global1.Business.GetParameter("ET", "FilePath")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_ETFilePath = Par.Value1
        Else
            Global1.PARAM_ETFilePath = ""
        End If

        If Global1.PARAM_ETFileEnable Then
            Me.TSLoadExcelTemplate.Visible = True
        Else
            Me.TSLoadExcelTemplate.Visible = False
        End If


        Global1.PARAM_AllowMarkAsInterface = False
        Ds = Global1.Business.GetParameter("System", "NoInterface")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_AllowMarkAsInterface = True
            Else
                Global1.PARAM_AllowMarkAsInterface = False
            End If
        End If

        Global1.PARAM_GetPFAmountFromAgreedSalary = False
        Ds = Global1.Business.GetParameter("System", "PFonAgreedSalary")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Global1.PARAM_GetPFAmountFromAgreedSalary = True
            Else
                Global1.PARAM_GetPFAmountFromAgreedSalary = False
            End If
        End If


        PARAM_PrintTimeSheetsReport = False
        Ds = Global1.Business.GetParameter("Payslip", "TSReport")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                PARAM_PrintTimeSheetsReport = True
            End If
        End If

        PARAM_AddColaOnRate = False
        Ds = Global1.Business.GetParameter("System", "COLAonOver")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                PARAM_AddColaOnRate = True
            End If
        End If

        Ds = Global1.Business.GetParameter("Nodal", "FTP")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_FTPToNodal = True
            Else
                Global1.PARAM_FTPToNodal = False
            End If
        Else
            Global1.PARAM_FTPToNodal = False
        End If

        Ds = Global1.Business.GetParameter("IT", "TaxRule")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_TaxRule = Par.Value1
        End If


        Me.TSImportEDCValuesFromExcel.Visible = False
        Ds = Global1.Business.GetParameter("System", "LoadEDC")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                Me.TSImportEDCValuesFromExcel.Visible = True
            End If
        End If


        PARAM_OvertimeRate_BasedOndays = False
        Ds = Global1.Business.GetParameter("Overtime", "BasedOnDays")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = 1 Then
                PARAM_OvertimeRate_BasedOndays = True
            End If
        End If
        PARAM_OvertimeRate_monthdays = 0
        Ds = Global1.Business.GetParameter("Overtime", "MonthDays")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_OvertimeRate_monthdays = Par.Value1
        End If


        PARAM_COLAMinimum = 0
        Ds = Global1.Business.GetParameter("Cola", "Minimum")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_COLAMinimum = Par.Value1
        End If


        Ds = Global1.Business.GetParameter("System", "RemoveE37")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            PARAM_RemoveE37 = Par.Value1
        End If

        PARAM_ShowAnalysis3onPayslip = False
        Ds = Global1.Business.GetParameter("Payslip", "Analysis3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_ShowAnalysis3onPayslip = True
            End If
        End If
        '''''''''''''''''''''''''''''' Overtime 3 to Other Earnings '''''''''''''''''''''''''
        PARAM_OverTime3ToOtherEarnings = False
        Ds = Global1.Business.GetParameter("NS", "Enabled")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_OverTime3ToOtherEarnings = True
            End If
        End If


        Ds = Global1.Business.GetParameter("NS", "Rate")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_NightShiftRate = Par.Value1
        End If


        Ds = Global1.Business.GetParameter("NS", "ErnCode")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_NightShiftErnCode = Par.Value1
        End If

        PARAM_Warningon20PercLimit = False
        Ds = Global1.Business.GetParameter("System", "20PercWarn")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_Warningon20PercLimit = True
            End If
        End If

        PARAM_Andrikian13PeriodLast = False
        Ds = Global1.Business.GetParameter("System", "13isLast")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_Andrikian13PeriodLast = True
            End If
        End If


        PARAM_ShowPaymentDescOnBankFile = False
        Ds = Global1.Business.GetParameter("Bankfile", "showDesc")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_ShowPaymentDescOnBankFile = True
            End If
        End If


        PARAM_NoAnnualUnitsDeduction = False
        Ds = Global1.Business.GetParameter("System", "NoAnUnitsDed")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_NoAnnualUnitsDeduction = True
            End If
        End If

        PARAM_OvertimeRate_BasedOnSalary2 = False
        Ds = Global1.Business.GetParameter("System", "OTRateOnSalary2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_OvertimeRate_BasedOnSalary2 = True
            End If
        End If
        Global1.PARAM_PayslipNameOn = False
        Ds = Global1.Business.GetParameter("Payslip", "NameOnfile")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_PayslipNameOn = True
            End If
        End If

        Ds = Global1.Business.GetParameter("System", "50PercAmount")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_FiftyPercAplicableAmount = Par.Value1
        End If

        PARAM_GetOvertimeRate_FromRateOnSalary = False
        Ds = Global1.Business.GetParameter("System", "OTRateFromROnSal")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_GetOvertimeRate_FromRateOnSalary = True
            End If
        End If

        PARAM_HourlyAsSalaryForTax = False
        Ds = Global1.Business.GetParameter("System", "HourlyAsSalaryForTax")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_HourlyAsSalaryForTax = True
            End If
        End If

        Global1.PARAM_AddBIKOnEarnings = False
        Ds = Global1.Business.GetParameter("Payslip", "AddBIK")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_AddBIKOnEarnings = True
            End If
        End If
        PARAM_SortByChequeNo = False
        Ds = Global1.Business.GetParameter("Interface", "Sortby")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_SortByChequeNo = True
            End If
        End If

        PARAM_MFLimit = 2
        Ds = Global1.Business.GetParameter("System", "MFLimit")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_MFLimit = Par.Value1
        Else
            MsgBox("Please Define Parameter 'System', 'MFLimit'")
        End If

        PARAM_PFLimit = 10
        Ds = Global1.Business.GetParameter("System", "PFLimit")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_PFLimit = Par.Value1
        Else
            MsgBox("Please Define Parameter 'System', 'PFLimit'")
        End If
        If Param_Exelsys Then
            mnuUploadToExelsys.Visible = True
            LoadExelsysParameters
        Else
            mnuUploadToExelsys.Visible = False
        End If
    End Sub
    Private Sub LoadExelsysParameters()
        Dim P1 As New cPrSsParameters("EXLSys", "WebsLogin")
        If P1.Value1 <> "" Then
            Global1.GLBExelsys_WSLogin = P1.Value1
        End If

        Dim P2 As New cPrSsParameters("EXLSys", "WebsPassword")
        If P2.Value1 <> "" Then
            Global1.GLBExelsys_WSPassword = P2.Value1
        End If

        Dim P3 As New cPrSsParameters("EXLSys", "WebsCompany")
        If P3.Value1 <> "" Then
            Global1.GLBExelsys_WSBusinessEntity = P3.Value1
        End If
    End Sub


    Private Sub GetSpecialTaxLimits()
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("SpecialTax", "DedLimit")
        If CheckDataSet(Ds) Then
            Dim Par1 As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.GLB_SpecialTaxDeductionLimit = Par1.Value1
        End If
        Ds = Global1.Business.GetParameter("SpecialTax", "ConLimit")
        If CheckDataSet(Ds) Then
            Dim Par2 As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.GLB_SpecialTaxContributionLimit = Par2.Value1
        End If
        Ds = Global1.Business.GetParameter("System", "SIMethod")
        If CheckDataSet(Ds) Then
            Dim Par2 As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.GLB_MethodOfSI = Par2.Value1
        End If

    End Sub


    Private Sub LoadStatusCombo()
        With Me.ComboStatus
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("ALL")
            .Items.Add("<  >")
            .Items.Add("PREPARED")
            .Items.Add("CALCULATED")
            .Items.Add("POSTED")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub InitDataGridLabels()
        DsLbl = New DataSet
        DsLbl.Tables.Add(DtLbl)

    End Sub
    Private Sub InitDataTableLabels()
        DtLbl = New DataTable("Table1")
        '0
        DtLbl.Columns.Add("EmpCode1", System.Type.GetType("System.String"))
        '1
        DtLbl.Columns.Add("EmpName1", System.Type.GetType("System.String"))
        '2
        DtLbl.Columns.Add("DepCode1", System.Type.GetType("System.String"))
        '3
        DtLbl.Columns.Add("Department1", System.Type.GetType("System.String"))
        '4
        DtLbl.Columns.Add("EmpCode2", System.Type.GetType("System.String"))
        '5
        DtLbl.Columns.Add("EmpName2", System.Type.GetType("System.String"))
        '6
        DtLbl.Columns.Add("DepCode2", System.Type.GetType("System.String"))
        '7
        DtLbl.Columns.Add("Department2", System.Type.GetType("System.String"))



    End Sub



    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        DG1.DataSource = MyDs.Tables(0)
    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '0
        Dt1.Columns.Add("Status", System.Type.GetType("System.String"))
        '1
        Dt1.Columns.Add("Enabled", System.Type.GetType("System.String"))
        '2
        Dt1.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))
        '5
        Dt1.Columns.Add("OverTime1", System.Type.GetType("System.Double"))
        '6
        Dt1.Columns.Add("OverTime2", System.Type.GetType("System.Double"))
        '7
        Dt1.Columns.Add("OverTime3", System.Type.GetType("System.Double"))
        '8
        Dt1.Columns.Add("SIUnits", System.Type.GetType("System.Double"))

        '9
        Dt1.Columns.Add("Sectors", System.Type.GetType("System.Double"))
        '10
        Dt1.Columns.Add("DutyHours", System.Type.GetType("System.Double"))
        '11
        Dt1.Columns.Add("FlightHours", System.Type.GetType("System.Double"))
        '12
        Dt1.Columns.Add("Commission", System.Type.GetType("System.Double"))
        '12
        Dt1.Columns.Add("OverLay", System.Type.GetType("System.Double"))
        '13
        Dt1.Columns.Add("PBamount", System.Type.GetType("System.Double"))
        '14
        Dt1.Columns.Add("PBRate", System.Type.GetType("System.Double"))

        '''''''''''''''''''''''Earnings''''''''''''''''''''''
        '8
        Dt1.Columns.Add("Ern1", System.Type.GetType("System.String"))
        '9
        Dt1.Columns.Add("EVal1", System.Type.GetType("System.Double"))
        '10
        Dt1.Columns.Add("Ern2", System.Type.GetType("System.String"))
        '11
        Dt1.Columns.Add("EVal2", System.Type.GetType("System.Double"))
        '12
        Dt1.Columns.Add("Ern3", System.Type.GetType("System.String"))
        '13
        Dt1.Columns.Add("EVal3", System.Type.GetType("System.Double"))
        '14
        Dt1.Columns.Add("Ern4", System.Type.GetType("System.String"))
        '15
        Dt1.Columns.Add("EVal4", System.Type.GetType("System.Double"))
        '16
        Dt1.Columns.Add("Ern5", System.Type.GetType("System.String"))
        '17
        Dt1.Columns.Add("EVal5", System.Type.GetType("System.Double"))
        '18
        Dt1.Columns.Add("Ern6", System.Type.GetType("System.String"))
        '19
        Dt1.Columns.Add("EVal6", System.Type.GetType("System.Double"))
        '20
        Dt1.Columns.Add("Ern7", System.Type.GetType("System.String"))
        '21
        Dt1.Columns.Add("EVal7", System.Type.GetType("System.Double"))
        '22
        Dt1.Columns.Add("Ern8", System.Type.GetType("System.String"))
        '23
        Dt1.Columns.Add("EVal8", System.Type.GetType("System.Double"))
        '24
        Dt1.Columns.Add("Ern9", System.Type.GetType("System.String"))
        '25
        Dt1.Columns.Add("EVal9", System.Type.GetType("System.Double"))
        '26
        Dt1.Columns.Add("Ern10", System.Type.GetType("System.String"))
        '27
        Dt1.Columns.Add("EVal10", System.Type.GetType("System.Double"))
        '28
        Dt1.Columns.Add("Ern11", System.Type.GetType("System.String"))
        '29
        Dt1.Columns.Add("EVal11", System.Type.GetType("System.Double"))
        '30
        Dt1.Columns.Add("Ern12", System.Type.GetType("System.String"))
        '31
        Dt1.Columns.Add("EVal12", System.Type.GetType("System.Double"))
        '32
        Dt1.Columns.Add("Ern13", System.Type.GetType("System.String"))
        '33
        Dt1.Columns.Add("EVal13", System.Type.GetType("System.Double"))
        '34
        Dt1.Columns.Add("Ern14", System.Type.GetType("System.String"))
        '35
        Dt1.Columns.Add("EVal14", System.Type.GetType("System.Double"))
        '36
        Dt1.Columns.Add("Ern15", System.Type.GetType("System.String"))
        '37
        Dt1.Columns.Add("EVal15", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Deductions''''''''''''''''''''''
        '38
        Dt1.Columns.Add("Ded1", System.Type.GetType("System.String"))
        '39
        Dt1.Columns.Add("DVal1", System.Type.GetType("System.Double"))
        '40
        Dt1.Columns.Add("Ded2", System.Type.GetType("System.String"))
        '41
        Dt1.Columns.Add("DVal2", System.Type.GetType("System.Double"))
        '42
        Dt1.Columns.Add("Ded3", System.Type.GetType("System.String"))
        '43
        Dt1.Columns.Add("DVal3", System.Type.GetType("System.Double"))
        '44
        Dt1.Columns.Add("Ded4", System.Type.GetType("System.String"))
        '45
        Dt1.Columns.Add("DVal4", System.Type.GetType("System.Double"))
        '46
        Dt1.Columns.Add("Ded5", System.Type.GetType("System.String"))
        '47
        Dt1.Columns.Add("DVal5", System.Type.GetType("System.Double"))
        '48
        Dt1.Columns.Add("Ded6", System.Type.GetType("System.String"))
        '49
        Dt1.Columns.Add("DVal6", System.Type.GetType("System.Double"))
        '50
        Dt1.Columns.Add("Ded7", System.Type.GetType("System.String"))
        '51
        Dt1.Columns.Add("DVal7", System.Type.GetType("System.Double"))
        '52
        Dt1.Columns.Add("Ded8", System.Type.GetType("System.String"))
        '53
        Dt1.Columns.Add("DVal8", System.Type.GetType("System.Double"))
        '54
        Dt1.Columns.Add("Ded9", System.Type.GetType("System.String"))
        '55
        Dt1.Columns.Add("DVal9", System.Type.GetType("System.Double"))
        '56
        Dt1.Columns.Add("Ded10", System.Type.GetType("System.String"))
        '57
        Dt1.Columns.Add("DVal10", System.Type.GetType("System.Double"))
        '58
        Dt1.Columns.Add("Ded11", System.Type.GetType("System.String"))
        '59
        Dt1.Columns.Add("DVal11", System.Type.GetType("System.Double"))
        '60
        Dt1.Columns.Add("Ded12", System.Type.GetType("System.String"))
        '61
        Dt1.Columns.Add("DVal12", System.Type.GetType("System.Double"))
        '62
        Dt1.Columns.Add("Ded13", System.Type.GetType("System.String"))
        '63
        Dt1.Columns.Add("DVal13", System.Type.GetType("System.Double"))
        '64
        Dt1.Columns.Add("Ded14", System.Type.GetType("System.String"))
        '65
        Dt1.Columns.Add("DVal14", System.Type.GetType("System.Double"))
        '66
        Dt1.Columns.Add("Ded15", System.Type.GetType("System.String"))
        '67
        Dt1.Columns.Add("DVal15", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Contributions''''''''''''''''''''''
        '68
        Dt1.Columns.Add("Con1", System.Type.GetType("System.String"))
        '69
        Dt1.Columns.Add("CVal1", System.Type.GetType("System.Double"))
        '70
        Dt1.Columns.Add("Con2", System.Type.GetType("System.String"))
        '71
        Dt1.Columns.Add("CVal2", System.Type.GetType("System.Double"))
        '72
        Dt1.Columns.Add("Con3", System.Type.GetType("System.String"))
        '73
        Dt1.Columns.Add("CVal3", System.Type.GetType("System.Double"))
        '74
        Dt1.Columns.Add("Con4", System.Type.GetType("System.String"))
        '75
        Dt1.Columns.Add("CVal4", System.Type.GetType("System.Double"))
        '76
        Dt1.Columns.Add("Con5", System.Type.GetType("System.String"))
        '77
        Dt1.Columns.Add("CVal5", System.Type.GetType("System.Double"))
        '78
        Dt1.Columns.Add("Con6", System.Type.GetType("System.String"))
        '79
        Dt1.Columns.Add("CVal6", System.Type.GetType("System.Double"))
        '80
        Dt1.Columns.Add("Con7", System.Type.GetType("System.String"))
        '81
        Dt1.Columns.Add("CVal7", System.Type.GetType("System.Double"))
        '82
        Dt1.Columns.Add("Con8", System.Type.GetType("System.String"))
        '83
        Dt1.Columns.Add("CVal8", System.Type.GetType("System.Double"))
        '84
        Dt1.Columns.Add("Con9", System.Type.GetType("System.String"))
        '85
        Dt1.Columns.Add("CVal9", System.Type.GetType("System.Double"))
        '86
        Dt1.Columns.Add("Con10", System.Type.GetType("System.String"))
        '87
        Dt1.Columns.Add("CVal10", System.Type.GetType("System.Double"))
        '88
        Dt1.Columns.Add("Con11", System.Type.GetType("System.String"))
        '89
        Dt1.Columns.Add("CVal11", System.Type.GetType("System.Double"))
        '90
        Dt1.Columns.Add("Con12", System.Type.GetType("System.String"))
        '91
        Dt1.Columns.Add("CVal12", System.Type.GetType("System.Double"))
        '92
        Dt1.Columns.Add("Con13", System.Type.GetType("System.String"))
        '93
        Dt1.Columns.Add("CVal13", System.Type.GetType("System.Double"))
        '94
        Dt1.Columns.Add("Con14", System.Type.GetType("System.String"))
        '95
        Dt1.Columns.Add("CVal14", System.Type.GetType("System.Double"))
        '96
        Dt1.Columns.Add("Con15", System.Type.GetType("System.String"))
        '97
        Dt1.Columns.Add("CVal15", System.Type.GetType("System.Double"))
    End Sub
    Private Sub InitDataGrid_Reports()
        MyDsReport = New DataSet
        MyDsReport.Tables.Add(DtR)
    End Sub
    Private Sub InitDataTable_Reports()
        DtR = New DataTable("TableR")
        '0
        DtR.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        DtR.Columns.Add("EmpName", System.Type.GetType("System.String"))

        '''''''''''''''''''''''Earnings''''''''''''''''''''''
        '2
        DtR.Columns.Add("Ern1", System.Type.GetType("System.String"))
        '3
        DtR.Columns.Add("EVal1", System.Type.GetType("System.Double"))
        '4
        DtR.Columns.Add("Ern2", System.Type.GetType("System.String"))
        '5
        DtR.Columns.Add("EVal2", System.Type.GetType("System.Double"))
        '6
        DtR.Columns.Add("Ern3", System.Type.GetType("System.String"))
        '7
        DtR.Columns.Add("EVal3", System.Type.GetType("System.Double"))
        '8
        DtR.Columns.Add("Ern4", System.Type.GetType("System.String"))
        '9
        DtR.Columns.Add("EVal4", System.Type.GetType("System.Double"))
        '10
        DtR.Columns.Add("Ern5", System.Type.GetType("System.String"))
        '11
        DtR.Columns.Add("EVal5", System.Type.GetType("System.Double"))
        '12
        DtR.Columns.Add("Ern6", System.Type.GetType("System.String"))
        '13
        DtR.Columns.Add("EVal6", System.Type.GetType("System.Double"))
        '14
        DtR.Columns.Add("Ern7", System.Type.GetType("System.String"))
        '15
        DtR.Columns.Add("EVal7", System.Type.GetType("System.Double"))
        '16
        DtR.Columns.Add("Ern8", System.Type.GetType("System.String"))
        '17
        DtR.Columns.Add("EVal8", System.Type.GetType("System.Double"))
        '18
        DtR.Columns.Add("Ern9", System.Type.GetType("System.String"))
        '19
        DtR.Columns.Add("EVal9", System.Type.GetType("System.Double"))
        '20
        DtR.Columns.Add("Ern10", System.Type.GetType("System.String"))
        '21
        DtR.Columns.Add("EVal10", System.Type.GetType("System.Double"))
        '22
        DtR.Columns.Add("Ern11", System.Type.GetType("System.String"))
        '23
        DtR.Columns.Add("EVal11", System.Type.GetType("System.Double"))
        '24
        DtR.Columns.Add("Ern12", System.Type.GetType("System.String"))
        '25
        DtR.Columns.Add("EVal12", System.Type.GetType("System.Double"))
        '26
        DtR.Columns.Add("Ern13", System.Type.GetType("System.String"))
        '27
        DtR.Columns.Add("EVal13", System.Type.GetType("System.Double"))
        '28
        DtR.Columns.Add("Ern14", System.Type.GetType("System.String"))
        '29
        DtR.Columns.Add("EVal14", System.Type.GetType("System.Double"))
        '30
        DtR.Columns.Add("Ern15", System.Type.GetType("System.String"))
        '31
        DtR.Columns.Add("EVal15", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Deductions''''''''''''''''''''''
        '32
        DtR.Columns.Add("Ded1", System.Type.GetType("System.String"))
        '33
        DtR.Columns.Add("DVal1", System.Type.GetType("System.Double"))
        '34
        DtR.Columns.Add("Ded2", System.Type.GetType("System.String"))
        '35
        DtR.Columns.Add("DVal2", System.Type.GetType("System.Double"))
        '36
        DtR.Columns.Add("Ded3", System.Type.GetType("System.String"))
        '37
        DtR.Columns.Add("DVal3", System.Type.GetType("System.Double"))
        '38
        DtR.Columns.Add("Ded4", System.Type.GetType("System.String"))
        '39
        DtR.Columns.Add("DVal4", System.Type.GetType("System.Double"))
        '40
        DtR.Columns.Add("Ded5", System.Type.GetType("System.String"))
        '41
        DtR.Columns.Add("DVal5", System.Type.GetType("System.Double"))
        '42
        DtR.Columns.Add("Ded6", System.Type.GetType("System.String"))
        '43
        DtR.Columns.Add("DVal6", System.Type.GetType("System.Double"))
        '44
        DtR.Columns.Add("Ded7", System.Type.GetType("System.String"))
        '45
        DtR.Columns.Add("DVal7", System.Type.GetType("System.Double"))
        '46
        DtR.Columns.Add("Ded8", System.Type.GetType("System.String"))
        '47
        DtR.Columns.Add("DVal8", System.Type.GetType("System.Double"))
        '48
        DtR.Columns.Add("Ded9", System.Type.GetType("System.String"))
        '49
        DtR.Columns.Add("DVal9", System.Type.GetType("System.Double"))
        '50
        DtR.Columns.Add("Ded10", System.Type.GetType("System.String"))
        '51
        DtR.Columns.Add("DVal10", System.Type.GetType("System.Double"))
        '52
        DtR.Columns.Add("Ded11", System.Type.GetType("System.String"))
        '53
        DtR.Columns.Add("DVal11", System.Type.GetType("System.Double"))
        '54
        DtR.Columns.Add("Ded12", System.Type.GetType("System.String"))
        '55
        DtR.Columns.Add("DVal12", System.Type.GetType("System.Double"))
        '56
        DtR.Columns.Add("Ded13", System.Type.GetType("System.String"))
        '57
        DtR.Columns.Add("DVal13", System.Type.GetType("System.Double"))
        '58
        DtR.Columns.Add("Ded14", System.Type.GetType("System.String"))
        '59
        DtR.Columns.Add("DVal14", System.Type.GetType("System.Double"))
        '60
        DtR.Columns.Add("Ded15", System.Type.GetType("System.String"))
        '61
        DtR.Columns.Add("DVal15", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Contributions''''''''''''''''''''''
        '62
        DtR.Columns.Add("Con1", System.Type.GetType("System.String"))
        '63
        DtR.Columns.Add("CVal1", System.Type.GetType("System.Double"))
        '64
        DtR.Columns.Add("Con2", System.Type.GetType("System.String"))
        '65
        DtR.Columns.Add("CVal2", System.Type.GetType("System.Double"))
        '66
        DtR.Columns.Add("Con3", System.Type.GetType("System.String"))
        '67
        DtR.Columns.Add("CVal3", System.Type.GetType("System.Double"))
        '68
        DtR.Columns.Add("Con4", System.Type.GetType("System.String"))
        '69
        DtR.Columns.Add("CVal4", System.Type.GetType("System.Double"))
        '70
        DtR.Columns.Add("Con5", System.Type.GetType("System.String"))
        '71
        DtR.Columns.Add("CVal5", System.Type.GetType("System.Double"))
        '72
        DtR.Columns.Add("Con6", System.Type.GetType("System.String"))
        '73
        DtR.Columns.Add("CVal6", System.Type.GetType("System.Double"))
        '74
        DtR.Columns.Add("Con7", System.Type.GetType("System.String"))
        '75
        DtR.Columns.Add("CVal7", System.Type.GetType("System.Double"))
        '76
        DtR.Columns.Add("Con8", System.Type.GetType("System.String"))
        '77
        DtR.Columns.Add("CVal8", System.Type.GetType("System.Double"))
        '78
        DtR.Columns.Add("Con9", System.Type.GetType("System.String"))
        '79
        DtR.Columns.Add("CVal9", System.Type.GetType("System.Double"))
        '80
        DtR.Columns.Add("Con10", System.Type.GetType("System.String"))
        '81
        DtR.Columns.Add("CVal10", System.Type.GetType("System.Double"))
        '82
        DtR.Columns.Add("Con11", System.Type.GetType("System.String"))
        '83
        DtR.Columns.Add("CVal11", System.Type.GetType("System.Double"))
        '84
        DtR.Columns.Add("Con12", System.Type.GetType("System.String"))
        '85
        DtR.Columns.Add("CVal12", System.Type.GetType("System.Double"))
        '86
        DtR.Columns.Add("Con13", System.Type.GetType("System.String"))
        '87
        DtR.Columns.Add("CVal13", System.Type.GetType("System.Double"))
        '88
        DtR.Columns.Add("Con14", System.Type.GetType("System.String"))
        '89
        DtR.Columns.Add("CVal14", System.Type.GetType("System.Double"))
        '90
        DtR.Columns.Add("Con15", System.Type.GetType("System.String"))
        '91
        DtR.Columns.Add("CVal15", System.Type.GetType("System.Double"))

    End Sub
    Private Sub InitDataGrid_NET()
        DsNet = New DataSet
        DsNet.Tables.Add(DtNet)

    End Sub
    Private Sub InitDataTable_NET()
        DtNet = New DataTable("Table1")
        '0
        DtNet.Columns.Add("Code", System.Type.GetType("System.String"))
        '1
        DtNet.Columns.Add("Name", System.Type.GetType("System.String"))
        '2
        DtNet.Columns.Add("Net", System.Type.GetType("System.Double"))

    End Sub
    Private Sub ClearGrid()
        If CheckDataSet(MyDs) Then
            MyDs.Tables(0).Rows.Clear()
        End If
        ClearGridColumns()
    End Sub

    Private Sub LoadCombos()
        Loading = True

        Dim i As Integer

        dsTemplateGroups = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        With Me.ComboTempGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(dsTemplateGroups) Then
                For i = 0 To dsTemplateGroups.Tables(0).Rows.Count - 1
                    Dim Temp As New cPrMsTemplateGroup(dsTemplateGroups.Tables(0).Rows(i))
                    .Items.Add(Temp)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False

    End Sub

    Private Sub ComboTempGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboTempGroups.SelectedIndexChanged
        Try
            Me.ClearGrid()
            GLBTempGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup)
            FindCurrentPeriod(True, "", 1, "")
            UpdatePeriodlabels()
            GLBCompany = New cAdMsCompany(GLBTempGroup.CompanyCode)
            CheckForAnnualLeaveAllocationTemplateParameter()
            If Not NotNow Then
                Dim ds As DataSet
                ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                If CheckDataSet(ds) Then
                    Global1.GlbLimits = New cPrSsLimits(ds.Tables(0).Rows(0))
                Else
                    MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
            CountReminders()
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub CheckForAnnualLeaveAllocationTemplateParameter()
        Dim F As Boolean = False
        If Global1.PARAM_AnnualLeaveAllocationTemplateGroups <> "" Then
            Dim Ar() As String
            Ar = Global1.PARAM_AnnualLeaveAllocationTemplateGroups.Split("|")
            Dim i As Integer
            For i = 0 To Ar.Length - 1
                If Ar(i) = Me.GLBTempGroup.Code Then
                    F = True
                    Exit For
                End If
            Next
        End If
        Me.GLBTemplateAnnualAllocation = F

    End Sub
    Private Sub UnLockCalculate(ByVal TF As Boolean)
        Me.TSBCalculateALL.Enabled = TF
        Me.TSBSavePrepare.Enabled = TF
        Me.btnPrepareSelected.Enabled = TF
        Me.btncalcSelectedLine.Enabled = TF



    End Sub
    Private Sub FindCurrentPeriod(ByVal Clearing As Boolean, ByVal StartCode As String, ByVal NorP As Integer, ByVal EndCode As String)
        If Loading Then Exit Sub
        Try
            Dim ds As DataSet
            ds = Global1.Business.FindCurrentPeriod1(GLBTempGroup.Code)

            If CheckDataSet(ds) Then
                GLBCurrentPeriod = New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
                If GLBCurrentPeriod.DateFrom.Year <= GLBMaximumYear Then
                    UnLockCalculate(True)
                Else
                    UnLockCalculate(False)
                End If
                If Global1.PARAM_AnnualLeaveAllocation Then
                    Global1.GLBMonthNormalDays = Global1.Business.FindCurrentPeriodMonthNormalDays(GLBCurrentPeriod)
                    If Global1.GLBMonthNormalDays = 0 Then
                        MsgBox("Please Define Month work Days for Annual Leave Allocation", MsgBoxStyle.Information)
                    End If
                End If
                With GLBCurrentPeriod
                    Me.txtPeriodCode.Text = .Code
                    Me.txtPeriodDescription.Text = .DescriptionL
                    Me.txtPeriodFrom.Text = Format(.DateFrom, "dd-MM-yyyy")
                    Me.txtPeriodTo.Text = Format(.DateTo, "dd-MM-yyyy")
                End With
                Me.GetPeriodEDC()



                Me.LoadEmployees(Clearing, StartCode, NorP, EndCode)
                Me.UpdatePeriodlabels()
                FindPreviousPeriod()


            Else
                MsgBox("There is no OPEN Period !Cannot Proceed with Payroll Calculations", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Function FindPreviousPeriod()
        GLB_PreviousPeriod = GLBCurrentPeriod.GetPreviousPeriod()
    End Function

    Public Sub FindCurentPeriodForTA(ByVal Clearing As Boolean, ByVal TempGroup As cPrMsTemplateGroup, ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date)
        If Loading Then Exit Sub
        Try
            Dim ds As DataSet
            Me.GLBTempGroup = TempGroup
            ds = Global1.Business.FindCurrentPeriod1(TempGroup.Code)
            If CheckDataSet(ds) Then
                GLBCurrentPeriod = New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
                With GLBCurrentPeriod
                    Me.txtPeriodCode.Text = .Code
                    Me.txtPeriodDescription.Text = .DescriptionL
                    Me.txtPeriodFrom.Text = Format(.DateFrom, "dd-MM-yyyy")
                    Me.txtPeriodTo.Text = Format(.DateTo, "dd-MM-yyyy")
                End With
                Me.GetPeriodEDC()
                Me.txtFromEmployee.Text = EmpCode
                Me.txtToEmployee.Text = EmpCode
                Me.LoadEmployees(Clearing, "", 1, "")

                Me.UpdatePeriodlabels()

                Dt1.AcceptChanges()
                MyDs.GetChanges()
                MyDs.AcceptChanges()






            Else
                MsgBox("There is no OPEN Period !Cannot Proceed with Payroll Calculations", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Public Sub FixEmployeeTA(ByVal EmpCode As String, ByVal FromDate As Date, ByVal ToDate As Date)
        Dim Ex As New System.Exception
        Dim TotalNormal As Double
        Dim TotalN As Double
        Dim TotalOver As Double
        Dim TotalSplit As Double
        Dim TotalLeave As Double
        Dim TotalErn As Double
        Dim TotalDed As Double

        Dim OverTimeCode As String
        Dim EarningCode As String
        Dim DeductionCode As String
        Dim SplitCode As String
        Dim SplitRate As Double = 0

        TotalNormal = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "01", "01", True, "")
        TotalN = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "10", "10", True, "")
        TotalOver = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "02", "02", True, "")
        TotalSplit = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "03", "03", True, "")
        TotalLeave = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "04", "07", True, "")
        TotalErn = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "08", "08", True, "")
        TotalDed = Global1.Business.GetEmployeeTotalPerDayPerWorkCode(EmpCode, FromDate, ToDate, "09", "09", True, "")

        Dim TaCode As New cTaMsWorkCodes


        TaCode = New cTaMsWorkCodes("08", "01")
        EarningCode = TaCode.IntCode

        TaCode = New cTaMsWorkCodes("09", "01")
        DeductionCode = TaCode.IntCode

        TaCode = New cTaMsWorkCodes("03", "01")
        SplitCode = TaCode.IntCode

        Dim DsP As DataSet
        DsP = Global1.Business.GetParameter("Split", "Split")
        If CheckDataSet(DsP) Then
            SplitRate = DbNullToDouble(DsP.Tables(0).Rows(0).Item(3))
        Else
            MsgBox("Please Define Split Rate", MsgBoxStyle.Critical)
            Throw Ex
        End If
        TotalSplit = RoundMe2(TotalSplit * SplitRate, 2)


        Application.DoEvents()
        Dim i As Integer = 0
        If CheckDataSet(MyDs) Then
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                ' Debug.WriteLine(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode)))
                'Debug.WriteLine(DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)))
                Dim Rounded_ActualUnits As Double = 0
                Dim Rounded_TotalOvertime As Double = 0

                Rounded_ActualUnits = Utils.RoundMeMinutes(TotalNormal + TotalN)
                Rounded_TotalOvertime = Utils.RoundMeMinutes(TotalOver)




                If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode)) = EmpCode Then
                    If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) = "PREP" Or DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) = "<  >" Then
                        Dim k As Integer
                        Dim Empl As New cPrMsEmployees(EmpCode)
                        If Empl.PayUni_Code = 2 Then
                            MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits) = Rounded_ActualUnits 'TotalNormal + TotalN
                            MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1) = Rounded_TotalOvertime 'TotalOver
                        End If
                        For k = Column_E1 To Column_DV15 Step 2
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(k)) = SplitCode Then
                                MyDs.Tables(0).Rows(i).Item(k + 1) = TotalSplit
                            End If
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(k)) = EarningCode Then
                                MyDs.Tables(0).Rows(i).Item(k + 1) = TotalErn
                            End If
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(k)) = DeductionCode Then
                                MyDs.Tables(0).Rows(i).Item(k + 1) = TotalDed
                            End If
                            MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1) = Rounded_TotalOvertime 'TotalOver
                        Next



                        Exit For
                    Else
                        MsgBox("Employee " & EmpCode & " Status is " & DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) & " Cannot Proceed with Interface Time Attendance for this Employee")
                        Dim Ans As New MsgBoxResult
                        Ans = MsgBox("Click 'Yes' if you want to SKIP only Employee " & EmpCode & " and continue with all other employees, or 'No' if you want to Cancel the whole Procedure", MsgBoxStyle.YesNo)
                        If Ans = MsgBoxResult.No Then
                            Throw Ex
                        End If

                    End If
                End If

            Next
        End If


    End Sub
    Private Sub UpdatePeriodlabels()
        Me.txtTotalPeriods.Text = Me.GLBCurrentPeriod.NumberOfTotalPeriodsFORDisplayONLY
        Me.txtTaxablePeriods.Text = Me.GLBCurrentPeriod.NumberOfTaxablePeriodsFORDisplayONLY
        Me.txtNonTaxable.Text = Me.GLBCurrentPeriod.NumberOfNonTaxablePeriodsFORDisplayONLY
    End Sub
    ''''Employee
    ' If GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
    ''Get Units From Period
    '            Me.txtActualUnits.Text = GLBCurrentPeriod.PeriodUnits
    '        ElseIf GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
    ''Get Units From Employee
    '            Me.txtActualUnits.Text = GLBEmployee.PeriodUnits
    '        ElseIf GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
    ''Get Units From User Input
    '            Me.txtActualUnits.Text = "0.00"
    '        End If
    '        GetPeriodEDC()
    Private Sub LoadEmployees(ByVal Clearing As Boolean, ByVal StartCode As String, ByVal NorP As Integer, ByVal EndCode As String)
        '  Dim t As Date = Now
        Dim ReLoadSalaries As Boolean = False

        If CBReloadsalary.CheckState = CheckState.Checked Then
            ReLoadSalaries = True
        End If
        Dim CCounter As Integer = 0
        GLBCalculateRateOnDays = False
        Me.GLBTotalWorkDaysInMonth = 0


        Dim EmpCounter As Integer
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim m As Integer

        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim found As Boolean = False

        Dim ErnCounter As Integer = 0
        Dim DedCounter As Integer = 0
        Dim ConCounter As Integer = 0

        Dim Ern(15) As String
        Dim ErnValue(15) As Double
        ' Dim Counter As Integer = 0
        Dim DescCounter As Integer = 0
        Dim ActualUnits As Double
        Dim OverTime1Value As Double
        Dim OverTime2Value As Double
        Dim OverTime3Value As Double
        Dim SIUnitsValue As Double


        Dim Sectors As Double
        Dim DutyHours As Double
        Dim FlightHours As Double
        Dim Commission As Double
        Dim OverLay As Double
        Dim PBAmount As Double
        Dim PBRate As Double

        Dim EmployeeFrom As String = "'"
        Dim EmployeeTo As String = ""
        Dim TopValue As String



        ' Dim NextOrPrevious As Integer
        Dim NoOfTop As Integer
        'Dim SearchCode As String

        MakeColumnsVisible()

        If Not Clearing Then
            EmployeeFrom = Me.txtFromEmployee.Text
            EmployeeTo = Me.txtToEmployee.Text
            If EmployeeFrom <> "" Or EmployeeTo <> "" Then
                StartCode = ""
                EndCode = ""
                NorP = 1
                TopValue = 0
            End If
            If EmployeeFrom = "" And EmployeeTo = "" Then
                TopValue = Me.ComboNoOfRows.Text
                If TopValue = "All" Then
                    TopValue = 0
                End If
            End If
        Else
            EmployeeFrom = "-1"
            EmployeeTo = "-1"
            StartCode = ""
            EndCode = ""
            NorP = 1
            TopValue = 0
        End If

        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim GenAnal1 As String

        Analysis = Me.ComboSelectAnal.SelectedIndex
        Select Case Analysis
            Case 0
                AnalysisCode = "0"
            Case 1
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis1).Code
            Case 2
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis2).Code
            Case 3
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis3).Code
            Case 4
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis4).Code
            Case 5
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
            Case 6
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code

        End Select

        GenAnal1 = Me.txtGenanal1.Text

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False
        Dim OnlyLeavers As Boolean = False

        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBEwallet.CheckState = CheckState.Checked Then
            Ewallet = True
        End If


        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If

        Dim SortOrder As Integer = 0
        If RadioCode.Checked Then
            SortOrder = 1
        End If
        If RadioAnalysis.Checked Then
            SortOrder = 2
        End If
        If RadioTA.Checked Then
            SortOrder = 3
        End If

        ' Dim CurrentTamplatePF As DataSet
        ' CurrentTamplatePF = Global1.Business.GetDeductionofType_PF_PerPeriodGroupANDTemplate(GLBTempGroup.Code, GLBCurrentPeriod)
        Dim DsErn As New DataSet
        DsErn = Global1.Business.GetAllPrMsTemplateEarnings(Me.GLBTempGroup.Code)
        Dim DsDed As New DataSet
        DsDed = Global1.Business.GetAllPrMsTemplateDeductions(Me.GLBTempGroup.Code)
        Dim DsCon As New DataSet
        DsCon = Global1.Business.GetAllPrMsTemplateContributions(Me.GLBTempGroup.Code)



        GLBDsEmp = Global1.Business.GetAllPrMsEmployeesByTemplateGroup(Me.GLBTempGroup.Code, EmployeeFrom, EmployeeTo, Me.GLBCurrentPeriod, Analysis, AnalysisCode, Cash, Cheque, Bank, SortOrder, OnlyLeavers, GenAnal1, StartCode, NorP, EndCode, TopValue, Ewallet)

        If CheckDataSet(GLBDsEmp) Then


            ReDim ArCalculations(GLBDsEmp.Tables(0).Rows.Count - 1)

            For i = 0 To GLBDsEmp.Tables(0).Rows.Count - 1
                Application.DoEvents()
                GLBCalculateRateOnDays = False
                OverTime1Value = 0
                OverTime2Value = 0
                OverTime3Value = 0
                SIUnitsValue = 0

                Sectors = 0
                DutyHours = 0
                FlightHours = 0
                Commission = 0
                OverLay = 0
                PBAmount = 0
                PBRate = 0


                ' Debug.WriteLine(Ds.Tables(0).Rows.Count - 1)
                Dim F As New FrmPrTxCalculatePayroll
                Dim Emp As New cPrMsEmployees(GLBDsEmp.Tables(0).Rows(i))
                Dim MyRate As Double
                MyRate = 1
                F.GLBCompany = GLBCompany
                F.GLBLimits = GLBLimits
                If Emp.Cur_Code <> GLBCompany.CurSymbol Then
                    MyRate = Global1.Business.GetCurruncyRate(Emp.Cur_Code, Now)

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim OriginalActualUnits As Double = 0
                Dim StartedThisMonth As Boolean = False
                If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                    'Get Units From Period'
                    If Emp.PeriodUnits = 0 Then
                        ActualUnits = GLBCurrentPeriod.PeriodUnits
                    Else
                        ActualUnits = Emp.PeriodUnits
                    End If
                    If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                        If Emp.StartDate.Month = GLBCurrentPeriod.DateFrom.Month Then
                            If Global1.PARAM_USE_Workingdays Then
                                If GLBCurrentPeriod.DateFrom <> Emp.StartDate Then
                                    OriginalActualUnits = ActualUnits
                                    GLBCalculateRateOnDays = True
                                    Dim WorkDaysInMonth As Integer
                                    Dim DaysWork As Integer
                                    Dim Units As Double
                                    GLBTotalWorkDaysInMonth = Utils.FindWorkingdays_FromDateToTheEndOfMonth(GLBCurrentPeriod.DateFrom)
                                    WorkDaysInMonth = Utils.FindWorkingdays_FromDateToTheEndOfMonth(Emp.StartDate)
                                    Units = RoundMe3(WorkDaysInMonth * 8, 2)
                                    If Units > ActualUnits Then
                                        Units = ActualUnits

                                    End If
                                    ActualUnits = Units
                                    StartedThisMonth = True
                                End If
                            Else
                                Dim DaysInMonth As Integer
                                Dim DaysWork As Integer
                                Dim Units As Double
                                OriginalActualUnits = ActualUnits
                                DaysInMonth = GLBCurrentPeriod.DateFrom.DaysInMonth(GLBCurrentPeriod.DateFrom.Year, GLBCurrentPeriod.DateFrom.Month)
                                Units = RoundMe2((DaysInMonth - Emp.StartDate.Date.Day + 1) * ActualUnits / DaysInMonth, 2)
                                ActualUnits = Units
                                StartedThisMonth = True
                            End If
                        End If

                    End If

                    If Emp.TerminateDate <> "" Then
                        Dim DaysInMonth As Integer
                        Dim DaysWork As Integer
                        Dim Units As Double
                        Dim TermDate As Date
                        Try
                            TermDate = CDate(Emp.TerminateDate)
                            If GLBCurrentPeriod.DateFrom.Year = TermDate.Date.Year Then
                                If GLBCurrentPeriod.DateFrom.Month = TermDate.Date.Month Then
                                    If Global1.PARAM_USE_Workingdays Then
                                        GLBCalculateRateOnDays = True
                                        Dim WorkDaysinmonth As Integer
                                        GLBTotalWorkDaysInMonth = Utils.FindWorkingdays_FromDateToTheEndOfMonth(GLBCurrentPeriod.DateFrom)
                                        WorkDaysinmonth = Utils.FindWorkingdays_FromDateToDate(GLBCurrentPeriod.DateFrom, TermDate.Date)
                                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                                            If Emp.StartDate.Month = GLBCurrentPeriod.DateFrom.Month Then
                                                WorkDaysinmonth = Utils.FindWorkingdays_FromDateToDate(Emp.StartDate, TermDate.Date)
                                            End If
                                        End If
                                        Units = RoundMe3(WorkDaysinmonth * 8, 2)
                                        If Units > ActualUnits Then
                                            Units = ActualUnits
                                        End If
                                        ActualUnits = Units
                                    Else
                                        DaysInMonth = GLBCurrentPeriod.DateFrom.DaysInMonth(GLBCurrentPeriod.DateFrom.Year, GLBCurrentPeriod.DateFrom.Month)
                                        Units = RoundMe2((TermDate.Date.Day) * ActualUnits / DaysInMonth, 2)
                                        ActualUnits = Units
                                        If StartedThisMonth Then
                                            Dim WorkDays As Integer = 0
                                            DaysInMonth = GLBCurrentPeriod.DateFrom.DaysInMonth(GLBCurrentPeriod.DateFrom.Year, GLBCurrentPeriod.DateFrom.Month)
                                            WorkDays = TermDate.Date.Day - Emp.StartDate.Day + 1
                                            Units = RoundMe2((WorkDays) * OriginalActualUnits / DaysInMonth, 2)
                                            ActualUnits = Units
                                        End If

                                    End If
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    End If

                    If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                        ActualUnits = FindActualUnitsFor_13_14(Emp, GLBCurrentPeriod)
                    End If
                ElseIf Emp.PayUni_Code = Global1.GLB_Units_Contract_Code Then
                    'Get Units From Employee
                    ActualUnits = Emp.PeriodUnits
                ElseIf Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
                    'Get Units From User Input
                    ActualUnits = Emp.PeriodUnits
                    If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                        If Emp.StartDate.Month = GLBCurrentPeriod.DateFrom.Month Then
                            Dim DaysInMonth As Integer
                            Dim DaysWork As Integer
                            Dim Units As Double
                            DaysInMonth = GLBCurrentPeriod.DateFrom.DaysInMonth(GLBCurrentPeriod.DateFrom.Year, GLBCurrentPeriod.DateFrom.Month)
                            Units = RoundMe2((DaysInMonth - Emp.StartDate.Date.Day + 1) * ActualUnits / DaysInMonth, 2)
                            ActualUnits = Units
                        End If
                    End If
                    If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                        'AEOLOSxxx
                        ActualUnits = Emp.AnnualUnits
                        'ActualUnits = FindActualUnitsFor_13_14(Emp, GLBCurrentPeriod)
                    End If

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                ErnCounter = 0
                DedCounter = 0
                ConCounter = 0


                Dim EmpTrxHeader As New cPrTxTrxnHeader(Emp.Code, Me.GLBCurrentPeriod.Code)
                Dim EmpTrxLines As DataSet
                Dim Include As Boolean = False
                Dim Status As String = Me.ComboStatus.Text
                Dim GridStatus = "<  >"
                If EmpTrxHeader.Id > 0 Then
                    MyRate = 1
                    OverTime1Value = EmpTrxHeader.Overtime1
                    OverTime2Value = EmpTrxHeader.Overtime2
                    OverTime3Value = EmpTrxHeader.Overtime3
                    SIUnitsValue = EmpTrxHeader.SIUnits
                    ActualUnits = EmpTrxHeader.PeriodUnits

                    Sectors = EmpTrxHeader.Sectors
                    DutyHours = EmpTrxHeader.DutyHours
                    FlightHours = EmpTrxHeader.FlightHours
                    Commission = EmpTrxHeader.Commission
                    OverLay = EmpTrxHeader.OverLay

                    PBAmount = EmpTrxHeader.PBAmount
                    PBRate = EmpTrxHeader.PBRate

                    If EmpTrxHeader.Status = "CALC" Then
                        GridStatus = "CALC"
                        Select Case Status
                            Case "ALL"
                                Include = True
                            Case "<  >"
                                Include = False
                            Case "PREPARED"
                                Include = False
                            Case "CALCULATED"
                                Include = True
                            Case "POSTED"
                                Include = False
                        End Select
                    ElseIf EmpTrxHeader.Status = "PREP" Then
                        GridStatus = "PREP"
                        Select Case Status
                            Case "ALL"
                                Include = True
                            Case "<  >"
                                Include = False
                            Case "PREPARED"
                                Include = True
                            Case "CALCULATED"
                                Include = False
                            Case "POSTED"
                                Include = False
                        End Select
                    ElseIf EmpTrxHeader.Status = "POST" Then
                        GridStatus = "POST"
                        Select Case Status
                            Case "ALL"
                                Include = True
                            Case "<  >"
                                Include = False
                            Case "PREPARED"
                                Include = False
                            Case "CALCULATED"
                                Include = False
                            Case "POSTED"
                                Include = True
                        End Select
                    End If
                    If Include Then
                        EmpTrxLines = Global1.Business.GetAllTrxnLines(EmpTrxHeader.Id)
                    End If
                Else

                    GridStatus = "<  >"
                    Select Case Status
                        Case "ALL"
                            Include = True
                        Case "<  >"
                            Include = True
                        Case "PREPARED"
                            Include = False
                        Case "CALCULATED"
                            Include = False
                        Case "POSTED"
                            Include = False
                    End Select
                    If Include Then
                        EmpTrxLines = Global1.Business.GetAllTrxnLines(EmpTrxHeader.Id)
                    End If
                End If
                If Include Then
                    Application.DoEvents()

                    F.GLBDsCon = DsCon
                    F.GLBDsDed = DsDed
                    F.GLBDsErn = DsErn
                    F.GLBTemplateGroup = Me.GLBTempGroup
                    F.Initializeme(GridStatus)
                    F.GLBEmployee = Emp
                    CCounter = CCounter + 1
                    Me.LabelStatus.Text = "Loading Employee :(" & CCounter & ") " & Emp.Code & " - " & Emp.FullName
                    Application.DoEvents()
                    F.GLBCurrentPeriod = Me.GLBCurrentPeriod
                    F.CurRate = MyRate
                    'F.GLBTemplatePFDs = CurrentTamplatePF

                    F.TotalWorkDaysOfMonth = Me.GLBTotalWorkDaysInMonth
                    F.CaclulateMyRateInDays = GLBCalculateRateOnDays
                    F.PreviousPeriod = GLB_PreviousPeriod

                    Dim r As DataRow = Dt1.NewRow()
                    r(Me.Column_Status) = GridStatus
                    r(Me.Column_Enabled) = "1"
                    r(Me.Column_EmpCode) = Emp.Code
                    r(Me.Column_EmpName) = Emp.FullName
                    r(Me.Column_ActualUnits) = ActualUnits
                    r(Me.Column_Overtime1) = Format(OverTime1Value, "0.00")
                    r(Me.Column_Overtime2) = Format(OverTime2Value, "0.00")
                    r(Me.Column_Overtime3) = Format(OverTime3Value, "0.00")
                    r(Me.Column_SIUnits) = Format(SIUnitsValue, "0.00")

                    r(Me.Column_Sectors) = Format(Sectors, "0.00")
                    r(Me.Column_DutyHours) = Format(DutyHours, "0.00")
                    r(Me.Column_FlightHours) = Format(FlightHours, "0.00")
                    r(Me.Column_Commission) = Format(Commission, "0.00")
                    r(Me.Column_OverLay) = Format(OverLay, "0.00")
                    r(Me.Column_PBAmount) = Format(PBAmount, "0.00")
                    r(Me.Column_PBRate) = Format(PBRate, "0.00")




                    GLB_PBRate = 0
                    GLB_PBAmount = 0
                    glb_PBSalary = 0
                    '''''''''''''''''''''''''''''''''''''''''
                    ''''''''''Employee Earnings '''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''
                    For k = 0 To 14
                        r(Me.Column_E1 + C1) = ""
                        C1 = C1 + 2
                        r(Me.Column_EV1 + C2) = "0.00"
                        C2 = C2 + 2
                    Next

                    Dim DsEmpErn As DataSet
                    DsEmpErn = Global1.Business.GetAllPrMsEmployeeEarnings(Emp.Code)


                    C1 = 0
                    C2 = 0
                    DescCounter = 0

                    'Dim DsErn As New DataSet
                    'DsErn = Global1.Business.GetAllPrMsTemplateEarnings(Me.GLBTempGroup.Code)
                    If CheckDataSet(DsErn) Then
                        For k = 0 To DsErn.Tables(0).Rows.Count - 1
                            Dim E As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
                            found = False
                            If CheckDataSet(DsP_Ern) Then
                                For j = 0 To Me.DsP_Ern.Tables(0).Rows.Count - 1
                                    If E.ErnCodCode = DbNullToString(DsP_Ern.Tables(0).Rows(j).Item(3)) Then
                                        found = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If found Then
                                r(Me.Column_E1 + C1) = E.ErnCodCode
                                C1 = C1 + 2
                                ChangeEarningsColumnName(E.DisplayName, DescCounter, E.FromMode)
                                DescCounter = DescCounter + 1
                                '''''''''''''''''''''''''''''''''''''''''''''''
                                'Loading Eqarning In FrmPrTxCoulculatePayroll
                                '''''''''''''''''''''''''''''''''''''''''''''''
                                F.Ern(ErnCounter).Ern = E
                                F.Ern(ErnCounter).LoadME()
                                F.E_Final(ErnCounter).Earn = E
                                F.E_Final(ErnCounter).LoadMe()


                                '''''''''''''''''''''''''''''''''''''''''''''''
                                If CheckDataSet(DsEmpErn) Then
                                    For m = 0 To DsEmpErn.Tables(0).Rows.Count - 1
                                        Dim EE As New cPrMsEmployeeEarnings(DsEmpErn.Tables(0).Rows(m))
                                        If E.ErnCodCode = EE.ErnCode Then

                                            FindEarningValue(EmpTrxLines, EE, ActualUnits, Emp, E, ReLoadSalaries, EmpTrxHeader.Status)
                                            '-------------------------------------------------------
                                            'Addition For CUR
                                            If GridStatus = "<  >" Then
                                                If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                                                    If Global1.PARAM_EarningsFor_13_14 <> "" Then
                                                        If E.ErnCodCode = Global1.PARAM_EarningsFor_13_14 Then
                                                            If Me.GlbAveragecommision <> 0 Then
                                                                EE.MyValue = GlbAveragecommision
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If


                                            If F.Ern(ErnCounter).MyType = "V" Then
                                                EE.MyValue = RoundMe2(EE.MyValue * MyRate, 2)
                                            Else
                                                EE.MyValue = EE.MyValue
                                            End If
                                            '-------------------------------------------------------
                                            r(Me.Column_EV1 + C2) = Format(EE.MyValue, "0.00")
                                            C2 = C2 + 2
                                            F.Ern(ErnCounter).txtValue.Text = Format(EE.MyValue, "0.00")

                                            r(Me.Column_PBAmount) = GLB_PBAmount
                                            r(Me.Column_PBRate) = GLB_PBRate



                                            Exit For
                                        End If

                                    Next
                                End If

                                ErnCounter = ErnCounter + 1
                            End If

                        Next
                    End If

                    F.GLBCOLAValueNotZero = GLBColaValueNotZero
                    F.GLBRateFromSalary2 = Me.GLBSalary2OvertimeRate
                    F.OvertimeRateFromRateOnSalary = GLBOvertimeRateFromRateOnSalary
                    '''''''''''''''''''''''''''''''''''''''''
                    ''''''''''Employee Deductions''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''
                    Dim DsEmpDed As DataSet
                    DsEmpDed = Global1.Business.GetAllPrMsEmployeeDeductions(Emp.Code)

                    C1 = 0
                    C2 = 0
                    DescCounter = 0
                    'Dim DsDed As New DataSet
                    'DsDed = Global1.Business.GetAllPrMsTemplateDeductions(Me.GLBTempGroup.Code)
                    glbCurrentEmployeeSIRate_deduction = 0
                    If CheckDataSet(DsDed) Then
                        For k = 0 To DsDed.Tables(0).Rows.Count - 1
                            Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
                            found = False
                            If CheckDataSet(DsP_Ded) Then
                                For j = 0 To Me.DsP_Ded.Tables(0).Rows.Count - 1
                                    If D.DedCodCode = DbNullToString(DsP_Ded.Tables(0).Rows(j).Item(3)) Then
                                        found = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If found Then
                                r(Me.Column_D1 + C1) = D.DedCodCode
                                C1 = C1 + 2
                                ChangeDeductionsColumnName(D.DisplayName, DescCounter, D.FromMode)
                                DescCounter = DescCounter + 1
                                '''''''''''''''''''''''''''''''''''''''''''''''
                                'Loading Deductions In FrmPrTxCoulculatePayroll
                                '''''''''''''''''''''''''''''''''''''''''''''''
                                F.Ded(DedCounter).Ded = D
                                F.Ded(DedCounter).LoadMe()
                                F.D_Final(DedCounter).Ded = D
                                F.D_Final(DedCounter).LoadMe()
                                '''''''''''''''''''''''''''''''''''''''''''''''
                                If CheckDataSet(DsEmpDed) Then
                                    For m = 0 To DsEmpDed.Tables(0).Rows.Count - 1
                                        Dim DD As New cPrMsEmployeeDeductions(DsEmpDed.Tables(0).Rows(m))
                                        If D.DedCodCode = DD.DedCode Then
                                            ' xxxxx()
                                            FindDeductionValue(EmpTrxLines, DD, Emp, D)
                                            '-------------------------------------------------------
                                            'Addition for CUR
                                            '-------------------------------------------------------
                                            If F.Ded(DedCounter).MyType = "V" Then
                                                DD.MyValue = RoundMe2(DD.MyValue * MyRate, 2)
                                            Else
                                                DD.MyValue = DD.MyValue
                                            End If
                                            '-------------------------------------------------------
                                            r(Me.Column_DV1 + C2) = Format(DD.MyValue, "0.00")
                                            C2 = C2 + 2
                                            F.Ded(DedCounter).txtValue.Text = Format(DD.MyValue, "0.00")
                                            Exit For
                                        End If
                                    Next
                                End If
                                DedCounter = DedCounter + 1
                            End If
                        Next
                    End If
                    F.GLBMySIDeductionRate = glbCurrentEmployeeSIRate_deduction

                    '''''''''''''''''''''''''''''''''''''''''
                    '''''''' Employee Contributions  ''''''''
                    '''''''''''''''''''''''''''''''''''''''''
                    Dim DsEmpCon As DataSet
                    DsEmpCon = Global1.Business.GetAllPrMsEmployeeContributions(Emp.Code)


                    C1 = 0
                    C2 = 0
                    DescCounter = 0

                    'Dim DsCon As New DataSet
                    'DsCon = Global1.Business.GetAllPrMsTemplateContributions(Me.GLBTempGroup.Code)
                    glbCurrentEmployeeSIRate_contribution = 0
                    If CheckDataSet(DsCon) Then
                        For k = 0 To DsCon.Tables(0).Rows.Count - 1
                            Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
                            found = False
                            If CheckDataSet(DsP_Con) Then
                                For j = 0 To Me.DsP_Con.Tables(0).Rows.Count - 1
                                    If C.ConCodCode = DbNullToString(DsP_Con.Tables(0).Rows(j).Item(3)) Then
                                        found = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If found Then
                                r(Me.Column_C1 + C1) = C.ConCodCode
                                C1 = C1 + 2
                                Me.ChangeContributionsColumnName(C.DisplayName, DescCounter, C.FromMode)
                                DescCounter = DescCounter + 1
                                '''''''''''''''''''''''''''''''''''''''''''''''''''
                                'Loading Contributions In FrmPrTxCalculatePayroll
                                '''''''''''''''''''''''''''''''''''''''''''''''''''
                                F.Con(ConCounter).Con = C
                                F.Con(ConCounter).LoadMe()
                                F.C_Final(ConCounter).Con = C
                                F.C_Final(ConCounter).LoadMe()
                                ''''''''''''''''''''''''''''''''''''''''''''''

                                If CheckDataSet(DsEmpCon) Then
                                    For m = 0 To DsEmpCon.Tables(0).Rows.Count - 1
                                        Dim CC As New cPrMsEmployeeContributions(DsEmpCon.Tables(0).Rows(m))
                                        If C.ConCodCode = CC.ConCode Then
                                            'ErnValue(counter) = Format(EE.MyValue, "0.00")
                                            FindContributionValue(EmpTrxLines, CC, Emp, C)
                                            'addition for CUR
                                            If F.Con(ConCounter).MyType = "V" Then
                                                CC.MyValue = RoundMe2(CC.MyValue * MyRate, 2)
                                            Else
                                                CC.MyValue = CC.MyValue
                                            End If
                                            '''
                                            r(Me.Column_CV1 + C2) = Format(CC.MyValue, "0.00")
                                            C2 = C2 + 2
                                            F.Con(ConCounter).txtValue.Text = Format(CC.MyValue, "0.00")
                                            Exit For
                                        End If
                                    Next
                                End If
                                ConCounter = ConCounter + 1
                            End If
                        Next
                    End If
                    F.GLBMySIContributionRate = glbCurrentEmployeeSIRate_contribution

                    Dt1.Rows.Add(r)
                    If GLBDoubleClick = False Then
                        DG1.Columns(Me.Column_EV1).Width = 0
                        DG1.AllowUserToResizeColumns = False
                    End If
                    Me.ArCalculations(EmpCounter) = F
                    EmpCounter = EmpCounter + 1
                End If



                If StopSearch Then
                    StopSearch = False
                    Exit For
                End If


            Next
        Else

        End If
        FixReadOnlyStatus()
        '     MsgBox(DateDiff(DateInterval.Second, t, Now))
    End Sub
    Private Function FindActualUnitsFor_13_14(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Dim UnitsWorked As Double
        Dim NormalUnitsOfPeriodsAfter As Double
        If CurrentPeriod.PayCat_Code = "3" Then
            UnitsWorked = Global1.Business.CalculateUnitsFor13(Emp, CurrentPeriod)
            If Emp.PeriodUnits = 0 Then
                If Not Global1.GLB_NoAnnualUnits Then
                    NormalUnitsOfPeriodsAfter = Global1.Business.CalculateNormalUnitsForPeriodsAfter(CurrentPeriod)
                Else
                    NormalUnitsOfPeriodsAfter = 0
                End If
            Else
                NormalUnitsOfPeriodsAfter = Emp.PeriodUnits
            End If
            UnitsWorked = UnitsWorked + NormalUnitsOfPeriodsAfter
        ElseIf CurrentPeriod.PayCat_Code = "4" Then
            UnitsWorked = Global1.Business.CalculateUnitsFor14(Emp, CurrentPeriod)
            'NormalUnitsOfPeriodsAfter = Global1.Business.CalculateNormalUnitsForPeriodsAfterByDate(CurrentPeriod)
            NormalUnitsOfPeriodsAfter = Global1.Business.CalculateNormalUnitsForPeriodsAfter(CurrentPeriod)
            UnitsWorked = UnitsWorked + NormalUnitsOfPeriodsAfter


        End If
        Return UnitsWorked
    End Function
    Private Function FindAverageSalaryFor_13_14(ByVal Emp As cPrMsEmployees, ByVal CurrentPeriod As cPrMsPeriodCodes) As Double
        Dim UnitsWorked As Double
        Dim NormalUnitsOfPeriodsAfter As Double
        If CurrentPeriod.PayCat_Code = "3" Then
            UnitsWorked = Global1.Business.CalculateUnitsFor13(Emp, CurrentPeriod)
            If Not Global1.GLB_NoAnnualUnits Then
                NormalUnitsOfPeriodsAfter = Global1.Business.CalculateNormalUnitsForPeriodsAfter(CurrentPeriod)
            Else
                NormalUnitsOfPeriodsAfter = 0
            End If
            UnitsWorked = UnitsWorked + NormalUnitsOfPeriodsAfter
        ElseIf CurrentPeriod.PayCat_Code = "4" Then
            UnitsWorked = Global1.Business.CalculateUnitsFor14(Emp, CurrentPeriod)
            'NormalUnitsOfPeriodsAfter = Global1.Business.CalculateNormalUnitsForPeriodsAfterByDate(CurrentPeriod)
            NormalUnitsOfPeriodsAfter = Global1.Business.CalculateNormalUnitsForPeriodsAfter(CurrentPeriod)
            UnitsWorked = UnitsWorked + NormalUnitsOfPeriodsAfter


        End If
        Return UnitsWorked
    End Function
    Private Sub FixReadOnlyStatus()

        If CheckDataSet(MyDs) Then
            Dim i As Integer
            Dim k As Integer
            Dim status As String
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                If status = "POST" Or status = "CALC" Then
                    For k = 2 To 104
                        DG1.Rows(i).Cells(k).ReadOnly = True
                    Next
                End If
            Next
        End If

    End Sub
    Private Sub GetPeriodEDC()
        DsP_Ern = Global1.Business.GetAllPrMsPeriodEarnings(Me.GLBCurrentPeriod.Code, Me.GLBCurrentPeriod.PrdGrpCode, True)
        DsP_Ded = Global1.Business.GetAllPrMsPeriodDeductions(Me.GLBCurrentPeriod.Code, Me.GLBCurrentPeriod.PrdGrpCode, True)
        DsP_Con = Global1.Business.GetAllPrMsPeriodContributions(Me.GLBCurrentPeriod.Code, Me.GLBCurrentPeriod.PrdGrpCode, True)
    End Sub

#Region "Change Columns Properties"
    Private Sub FixColumns_Normal_Color()
        DG1.Columns(Me.Column_Status).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_Enabled).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_EmpCode).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_EmpName).DefaultCellStyle.BackColor = Color_NormalFields
    End Sub
    Private Sub MakeColumnsVisible()
        DG1.Columns(Me.Column_ActualUnits).Visible = True
        If Global1.GLBHideOver Then
            DG1.Columns(Me.Column_Overtime1).Visible = False
            DG1.Columns(Me.Column_Overtime2).Visible = False
            DG1.Columns(Me.Column_Overtime3).Visible = False
            DG1.Columns(Me.Column_SIUnits).Visible = False
        Else

            DG1.Columns(Me.Column_Overtime1).Visible = True
            DG1.Columns(Me.Column_Overtime2).Visible = True
            DG1.Columns(Me.Column_Overtime3).Visible = True
            DG1.Columns(Me.Column_SIUnits).Visible = True
        End If
        If Global1.GLBAirlines Then
            DG1.Columns(Me.Column_Sectors).Visible = True
            DG1.Columns(Me.Column_DutyHours).Visible = True
            DG1.Columns(Me.Column_FlightHours).Visible = True
            DG1.Columns(Me.Column_Commission).Visible = True
            DG1.Columns(Me.Column_OverLay).Visible = True
            DG1.Columns(Me.Column_PBAmount).Visible = True
            DG1.Columns(Me.Column_PBRate).Visible = True
        Else
            DG1.Columns(Me.Column_Sectors).Visible = False
            DG1.Columns(Me.Column_DutyHours).Visible = False
            DG1.Columns(Me.Column_FlightHours).Visible = False
            DG1.Columns(Me.Column_Commission).Visible = False
            DG1.Columns(Me.Column_OverLay).Visible = False
            DG1.Columns(Me.Column_PBAmount).Visible = False
            DG1.Columns(Me.Column_PBRate).Visible = False

        End If
    End Sub
    Private Sub ClearGridColumns()

        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_ActualUnits).Visible = False
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '''
        DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_Overtime1).Visible = False
        DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '''
        DG1.Columns(Me.Column_Overtime2).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_Overtime2).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_Overtime2).Visible = False
        DG1.Columns(Me.Column_Overtime2).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_Overtime2).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_Overtime2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '''
        DG1.Columns(Me.Column_Overtime3).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_Overtime3).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_Overtime3).Visible = False
        DG1.Columns(Me.Column_Overtime3).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_Overtime3).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_Overtime3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ''' 
        '''
        DG1.Columns(Me.Column_SIUnits).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_SIUnits).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_SIUnits).Visible = False
        DG1.Columns(Me.Column_SIUnits).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_SIUnits).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_SIUnits).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_Sectors).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_Sectors).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_Sectors).Visible = False
        DG1.Columns(Me.Column_Sectors).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_Sectors).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_Sectors).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_DutyHours).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_DutyHours).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_DutyHours).Visible = False
        DG1.Columns(Me.Column_DutyHours).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_DutyHours).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_DutyHours).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_FlightHours).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_FlightHours).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_FlightHours).Visible = False
        DG1.Columns(Me.Column_FlightHours).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_FlightHours).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_FlightHours).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_Commission).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_Commission).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_Commission).Visible = False
        DG1.Columns(Me.Column_Commission).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_Commission).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_Commission).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_OverLay).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_OverLay).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_OverLay).Visible = False
        DG1.Columns(Me.Column_OverLay).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_OverLay).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_OverLay).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



        DG1.Columns(Me.Column_PBAmount).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_PBAmount).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_PBAmount).Visible = False
        DG1.Columns(Me.Column_PBAmount).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_PBAmount).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_PBAmount).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_PBRate).DefaultCellStyle.BackColor = Color_NormalFields
        DG1.Columns(Me.Column_PBRate).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(Me.Column_PBRate).Visible = False
        DG1.Columns(Me.Column_PBRate).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_PBRate).DefaultCellStyle.NullValue = "0.00"
        DG1.Columns(Me.Column_PBRate).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ''

        Dim i As Integer = 0
        For i = Me.Column_EV1 To Me.Column_EV14 Step 2
            DG1.Columns(i).HeaderText = ""
            DG1.Columns(i).Visible = False
            DG1.Columns(i).ReadOnly = False
            DG1.Columns(i).DefaultCellStyle.Format = "0.00"
            DG1.Columns(i).DefaultCellStyle.NullValue = "0.00"
            DG1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        For i = Me.Column_DV1 To Me.Column_DV14 Step 2
            DG1.Columns(i).HeaderText = ""
            DG1.Columns(i).Visible = False
            DG1.Columns(i).ReadOnly = False
            DG1.Columns(i).DefaultCellStyle.Format = "0.00"
            DG1.Columns(i).DefaultCellStyle.NullValue = "0.00"
            DG1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
        For i = Me.Column_CV1 To Me.Column_CV14 Step 2
            DG1.Columns(i).HeaderText = ""
            DG1.Columns(i).Visible = False
            DG1.Columns(i).ReadOnly = False
            DG1.Columns(i).DefaultCellStyle.Format = "0.00"
            DG1.Columns(i).DefaultCellStyle.NullValue = "0.00"
            DG1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
    End Sub
    Private Sub ChangeEarningsColumnName(ByVal DisplayName As String, ByVal Counter As Integer, ByVal FromMode As String)
        Dim C As Integer
        Select Case Counter
            Case 0
                C = Me.Column_EV1
            Case 1
                C = Me.Column_EV2
            Case 2
                C = Me.Column_EV3
            Case 3
                C = Me.Column_EV4
            Case 4
                C = Me.Column_EV5
            Case 5
                C = Me.Column_EV6
            Case 6
                C = Me.Column_EV7
            Case 7
                C = Me.Column_EV8
            Case 8
                C = Me.Column_EV9
            Case 9
                C = Me.Column_EV10
            Case 10
                C = Me.Column_EV11
            Case 11
                C = Me.Column_EV12
            Case 12
                C = Me.Column_EV13
            Case 13
                C = Me.Column_EV14
            Case 14
                C = Me.Column_EV15
        End Select

        DG1.Columns(C).HeaderText = DisplayName
        DG1.Columns(C).Visible = True
        DG1.Columns(C).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(C).DefaultCellStyle.BackColor = Color_Earnings

        If FromMode = "F" Or FromMode = "T" Then
            DG1.Columns(C).ReadOnly = True
            DG1.Columns(C).DefaultCellStyle.ForeColor = Color_NotEdit
        End If

    End Sub
    Private Sub ChangeDeductionsColumnName(ByVal DisplayName As String, ByVal Counter As Integer, ByVal FromMode As String)

        Dim C As Integer
        Select Case Counter
            Case 0
                C = Me.Column_DV1
            Case 1
                C = Me.Column_DV2
            Case 2
                C = Me.Column_DV3
            Case 3
                C = Me.Column_DV4
            Case 4
                C = Me.Column_DV5
            Case 5
                C = Me.Column_DV6
            Case 6
                C = Me.Column_DV7
            Case 7
                C = Me.Column_DV8
            Case 8
                C = Me.Column_DV9
            Case 9
                C = Me.Column_DV10
            Case 10
                C = Me.Column_DV11
            Case 11
                C = Me.Column_DV12
            Case 12
                C = Me.Column_DV13
            Case 13
                C = Me.Column_DV14
            Case 14
                C = Me.Column_DV15
        End Select

        DG1.Columns(C).HeaderText = DisplayName
        DG1.Columns(C).Visible = True
        DG1.Columns(C).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(C).DefaultCellStyle.BackColor = Color_Deductions
        'If FromMode = "F" Or FromMode = "T" Or FromMode = "X" Then
        If FromMode = "F" Or FromMode = "T" Then 'Or FromMode = "X" Then
            DG1.Columns(C).ReadOnly = True
            DG1.Columns(C).DefaultCellStyle.ForeColor = Color_NotEdit
        End If


    End Sub
    Private Sub ChangeContributionsColumnName(ByVal DisplayName As String, ByVal Counter As Integer, ByVal FromMode As String)

        Dim C As Integer

        Select Case Counter
            Case 0
                C = Me.Column_CV1
            Case 1
                C = Me.Column_CV2
            Case 2
                C = Me.Column_CV3
            Case 3
                C = Me.Column_CV4
            Case 4
                C = Me.Column_CV5
            Case 5
                C = Me.Column_CV6
            Case 6
                C = Me.Column_CV7
            Case 7
                C = Me.Column_CV8
            Case 8
                C = Me.Column_CV9
            Case 9
                C = Me.Column_CV10
            Case 10
                C = Me.Column_CV11
            Case 11
                C = Me.Column_CV12
            Case 12
                C = Me.Column_CV13
            Case 13
                C = Me.Column_CV14
            Case 14
                C = Me.Column_CV15
        End Select

        DG1.Columns(C).HeaderText = DisplayName
        DG1.Columns(C).Visible = True
        DG1.Columns(C).DefaultCellStyle.ForeColor = Color_Edit
        DG1.Columns(C).DefaultCellStyle.BackColor = Color_Contributions
        If FromMode = "F" Or FromMode = "T" Then
            DG1.Columns(C).ReadOnly = True
            DG1.Columns(C).DefaultCellStyle.ForeColor = Color_NotEdit
        End If


    End Sub
#End Region
    Private Sub DG1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG1.DataError
        Dim str As String
        Dim Column As Integer
        Dim Row As Integer
        Column = e.ColumnIndex
        Row = e.RowIndex
        str = e.Exception.Message.ToString
        Dim RowEmployee As String = ""
        Dim ColumnHeader As String = ""
        If CheckDataSet(MyDs) Then
            RowEmployee = UCase(DbNullToString(MyDs.Tables(0).Rows(Row).Item(Me.Column_EmpName)))
            ColumnHeader = UCase(DG1.Columns(Column).HeaderText)
        End If

        If e.Exception.Message.ToString = "Input string was not in a correct format." Then
            MsgBox("Please enter a numeric Value in Column '" & ColumnHeader & "' (Column No." & Column & ") Of Employee '" & RowEmployee & "' (Row No." & Row + 1 & ")", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub DG1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellDoubleClick
        If CheckDataSet(MyDs) Then
            If GLBDoubleClick Then
                LoadValuesFromGridToFormCalculations(e.RowIndex, 0)
            End If
        End If
    End Sub
    Private Function LoadValuesFromGridToFormCalculations(ByVal Row As Integer, ByVal Action As Integer) As Boolean
        Try


            Dim Flag As Boolean = True

            If DG1.Item(0, Row).Value = "PREP" Then


            End If


            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If
            If Not CheckDataSet(MyDs) Or Row = -1 Then
                Exit Function
            End If
            Dim EmpCode As String
            Dim ss As Integer
            EmpCode = DG1.Item(2, Row).Value
            For ss = 0 To MyDs.Tables(0).Rows.Count - 1
                If MyDs.Tables(0).Rows(ss).Item(2) = EmpCode Then
                    Row = ss
                End If
            Next




            Dim tEmpCode As String
            With Me.MyDs.Tables(0).Rows(Row)

                If DbNullToString(MyDs.Tables(0).Rows(Row).Item(Me.Column_Enabled)) = "0" Then
                    Exit Function
                End If
                Dim F As New FrmPrTxCalculatePayroll
                Dim i As Integer
                Dim k As Integer
                F = CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll)

                If F.txtTempstatus.Text = "CALC" And Action = 1 Then
                    LoadValuesFromGridToFormCalculations(Row, 0)
                    Exit Function
                End If

                F.CurrentOwnerColumn = Row
                F.Owner = Me
                tEmpCode = .Item(Me.Column_EmpCode)
                F.txtEmpCode.Text = .Item(Me.Column_EmpCode)

                F.txtEmpFullName.Text = .Item(Me.Column_EmpName)
                F.txtActualUnits.Text = Format(.Item(Me.Column_ActualUnits), "0.00")
                F.txtOvertime1.Text = Format(.Item(Me.Column_Overtime1), "0.00")
                F.txtOvertime2.Text = Format(.Item(Me.Column_Overtime2), "0.00")
                F.txtOvertime3.Text = Format(.Item(Me.Column_Overtime3), "0.00")

                F.txtSectors.Text = Format(.Item(Me.Column_Sectors), "0.00")
                F.txtDutyHours.Text = Format(.Item(Me.Column_DutyHours), "0.00")
                F.TxtFlightHours.Text = Format(.Item(Me.Column_FlightHours), "0.00")
                F.txtCommission.Text = Format(.Item(Me.Column_Commission), "0.00")
                F.txtOverLay.Text = Format(.Item(Me.Column_OverLay), "0.00")
                F.txtPBAmount.Text = Format(.Item(Me.Column_PBAmount), "0.00")
                F.txtPBRate.Text = Format(.Item(Me.Column_PBRate), "0.00")

                F.txtSILeaveUnits.Text = Format(.Item(Me.Column_SIUnits), "0.00")
                F.GLBAnnualAllocationForthisTemplate = Me.GLBTemplateAnnualAllocation

                F.TSBCalculate.Enabled = Me.TSBCalculateALL.Enabled
                F.TSBSave.Enabled = Me.TSBCalculateALL.Enabled
                F.BtnCalculateGross.Enabled = Me.TSBCalculateALL.Enabled

                With F.GLBCurrentPeriod
                    F.txtPeriodCode.Text = .Code
                    F.txtPeriodDescription.Text = .DescriptionL
                    F.txtPeriodFrom.Text = Format(.DateFrom, "dd-MM-yyyy")
                    F.txtPeriodTo.Text = Format(.DateTo, "dd-MM-yyyy")
                End With

                Dim SSx As Integer
                Dim ThisIsTheValue As Boolean = False
                Dim DoNotEnterAgain As Boolean = False


                For i = 0 To DsP_Ern.Tables(0).Rows.Count - 1

                    If i = 0 Then
                        k = Me.Column_EV1
                        SSx = Me.Column_E1
                    Else
                        k = k + 2
                        SSx = SSx + 2
                    End If
                    If Not DoNotEnterAgain Then

                        Dim tECode As String = .Item(SSx).ToString
                        Dim CC As New cPrMsEarningCodes(tECode)

                        If CC.ErnTypCode = "SA" Then
                            ThisIsTheValue = True
                        End If
                    End If
                    If .Item(k).ToString = "" Then
                        MsgBox("Please Define Earnings For Employee " & tEmpCode)
                        Return False
                        Exit Function
                    Else
                        If ThisIsTheValue Then
                            ThisIsTheValue = False
                            DoNotEnterAgain = True
                            F.XSalary = .Item(k)
                        End If
                        F.Ern(i).txtValue.Text = Format(.Item(k), "0.00")
                    End If
                Next

                For i = 0 To DsP_Ded.Tables(0).Rows.Count - 1
                    If i = 0 Then
                        k = Me.Column_DV1
                    Else
                        k = k + 2
                    End If
                    If .Item(k).ToString = "" Then
                        MsgBox("Please Define Deductions For Employee " & tEmpCode)
                        Return False
                        Exit Function
                    Else
                        F.Ded(i).txtValue.Text = Format(.Item(k), "0.00")
                    End If
                Next

                For i = 0 To DsP_Con.Tables(0).Rows.Count - 1
                    If i = 0 Then
                        k = Me.Column_CV1
                    Else
                        k = k + 2
                    End If
                    If .Item(k).ToString = "" Then
                        MsgBox("Please Define Contributions For Employee " & tEmpCode)
                        Return False
                        Exit Function
                    Else
                        F.Con(i).txtValue.Text = Format(.Item(k), "0.00")
                    End If
                Next

            End With

            If Action = 0 Then
                Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
                If Hdr.Id Then
                    If Hdr.Status <> "PREP" Then
                        CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll).LoadCalculatedOrPosted(Hdr, Me.GLBCurrentPeriod)
                    End If
                End If

                CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll).CalculateSalaryPerUnits()
                CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll).ShowDialog()
                If GLBRunNext Or GLBRunPrevious Then

                    Me.LoadNextEmployee(GLBRunNext, GLBRunPrevious, GLBGridIndex)


                End If
            ElseIf Action = 1 Then
                If CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll).DoCalculations() Then
                    CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll).TryToSavePayroll(True)
                    MyDs.Tables(0).Rows(Row).Item(Column_Status) = "CALC"
                Else
                    Flag = False
                End If
            ElseIf Action = 2 Then
                Flag = CType(Me.ArCalculations(Row), FrmPrTxCalculatePayroll).DoCalculations()

            End If

            Return Flag
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Function
#Region "Find Values For Employee earnings"
    Private Sub FindEarningValue(ByVal TrxnLinesDS As DataSet, ByRef EE As cPrMsEmployeeEarnings, ByVal ActualUnits As Double, ByVal Emp As cPrMsEmployees, ByVal TempErn As cPrMsTemplateEarnings, ByVal Reloadsalaries As Boolean, ByVal Status As String)
        'Dim Emp As New cPrMsEmployees(EE.EmpCode)
        Dim Earn As New cPrMsEarningCodes(EE.ErnCode)
        Dim GoHere As Boolean = True

        If CheckDataSet(TrxnLinesDS) Then
            GoHere = False
            Dim i As Integer
            For i = 0 To TrxnLinesDS.Tables(0).Rows.Count - 1
                Dim Lin As New cPrTxTrxnLines(TrxnLinesDS.Tables(0).Rows(i))
                If Lin.TrxLin_Type = "E" Then
                    If EE.ErnCode = Lin.ErnCod_Code Then
                        EE.MyValue = Lin.TrxLin_EDC
                        If Earn.ErnTypCode = "SA" Then
                            If Me.GLBSetSalaryToZero Then
                                EE.MyValue = 0
                            End If
                        End If
                    End If

                End If
            Next
        End If
        'Addition to Reload Salaries for Rodeler
        If Earn.ErnTypCode = "SA" And Reloadsalaries = True Then
            If Status = "PREP" Then
                GoHere = True
            End If
        End If
        'End of Addition


        If GoHere Then
            Select Case Earn.ErnTypCode
                Case "3A" '13 SALARY
                    'E_13Salary(Emp, EE, Earn)
                Case "3E" '13 SALARY ESTIMATE
                    ' E_Calculate13Estimate(Emp, EE, Earn)
                Case "4A" '14 SALARY
                    'E_14Salary(Emp, EE, Earn)
                Case "4E" '14 SALARY ESTIMATE
                    'E_Calculate14Estimate(Emp, EE, Earn)
                Case "AR" 'ARREARS
                    'E_CalculateArrears(Emp, EE, Earn)
                Case "OT" 'OVERTIME
                    'E_CalculateOverTime(Emp, EE, Earn)
                Case "SA" 'SALARY
                    EE.MyValue = E_CalculateSalary(Emp, EE, Earn, ActualUnits, TempErn)
                Case "SI" 'SOCIAL INSURANCE LEAVE
                    EE.MyValue = E_CalculateSocialInsuranceLeave(Emp, EE, Earn, TempErn)
                Case "OE" 'OTHER INCOME
                    EE.MyValue = E_CalculateOtherIncome(Emp, EE, Earn, TempErn)
                Case "FI" 'OTHER INCOME
                    EE.MyValue = E_CalculateFishes(Emp, EE, Earn, TempErn)
                Case "SE" 'SECTOR
                    EE.MyValue = E_CalculateSector(Emp, EE, Earn, TempErn)
                Case "DH" 'Duty hours
                    EE.MyValue = E_CalculateDutyHour(Emp, EE, Earn, TempErn)
                Case "FH" 'Flight hours
                    EE.MyValue = E_CalculateFlightHour(Emp, EE, Earn, TempErn)
                Case "PB" 'Performance Bonus
                    EE.MyValue = E_CalculatePerformanceBonus(Emp, EE, Earn, TempErn)
                Case "CO" 'sales Commission
                    EE.MyValue = E_CalculateSalesCommission(Emp, EE, Earn, TempErn)
                Case "OV" 'OverLay
                    EE.MyValue = E_CalculateOverLay(Emp, EE, Earn, TempErn)
                Case "TO"
                    EE.MyValue = E_CalculateTimeOff(Emp, EE, Earn, TempErn)
                Case "RN"
                    EE.MyValue = E_CalculateRecuringNegative(Emp, EE, Earn, TempErn)
                Case "LL"
                    EE.MyValue = E_CalculateAnualLeaveLL(Emp, EE, Earn, ActualUnits, TempErn)
                Case "RE"
                    EE.MyValue = E_CalculateRecuringEarnings(Emp, EE, Earn, TempErn)
                Case "R2"
                    EE.MyValue = E_CalculateRecuringEarnings14(Emp, EE, Earn, TempErn)
                Case "BR"
                    EE.MyValue = E_CalculateBenefitsInKind(Emp, EE, Earn, TempErn)
                Case "B2"
                    EE.MyValue = E_CalculateBenefitsInKind14(Emp, EE, Earn, TempErn)
                Case "CL"
                    EE.MyValue = E_CalculateCOLA(Emp, EE, Earn, TempErn)
                Case "FN" 'Fine
                    EE.MyValue = E_CalculateFine(Emp, EE, Earn, TempErn)
                Case "DR"
                    'Director Fees
                    EE.MyValue = E_CalculateDirectorFees(Emp, EE, Earn, TempErn)
                Case "TP" 'TIME OFF POSITIVE
                    EE.MyValue = E_CalculateTimeOffPossitive(Emp, EE, Earn, TempErn)

            End Select
        End If
    End Sub
    Private Function E_CalculateSalary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal ActualUnits As Double, ByVal TempErn As cPrMsTemplateEarnings) As Double

        Dim Gross As Double = 0
        Dim Rate As Double = 0
        Dim Salary As Double = 0
        Dim NormalUnits As Double = 0
        Dim OtherErnfor1314 As Double

        Dim cSalary As New cPrTxEmployeeSalary()

        cSalary = Global1.Business.GetCurrentSalary(Emp.Code, Me.GLBCurrentPeriod.DateTo)
        Gross = cSalary.SalaryValue
        glb_PBSalary = Gross

        GLBSalary2OvertimeRate = 0
        GLBOvertimeRateFromRateOnSalary = cSalary.myRate

        If Global1.PARAM_OvertimeRate_BasedOnSalary2 Then
            If Emp.PeriodUnits = 0 Then
                NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
            Else
                NormalUnits = Emp.PeriodUnits
            End If
            If NormalUnits <> 0 Then
                GLBSalary2OvertimeRate = RoundMe3((cSalary.myRateSalary / NormalUnits), 2)
            End If
        End If


        If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
            ActualUnits = FindActualUnitsFor_13_14(Emp, GLBCurrentPeriod)
        End If
        If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
            If Global1.PARAM_Average_13_14 Then
                '--------------------------------------------------------------------------------------------
                Dim i As Integer
                Dim k As Integer = 0
                Dim Sal As Double = 0
                If Me.GLBCurrentPeriod.PayCat_Code = "3" Then
                    Dim DS3 As DataSet

                    DS3 = Global1.Business.CalculateSalaryFor13(Emp, Me.GLBCurrentPeriod)
                    If CheckDataSet(DS3) Then
                        For i = 0 To DS3.Tables(0).Rows.Count - 1
                            Sal = Sal + DbNullToDouble(DS3.Tables(0).Rows(i).Item(0))
                            k = k + 1
                        Next
                        Sal = Sal + Gross
                        k = k + 1
                        '----------------------------------------------
                        'Other Earnings in 13/14 Average Calculation
                        '----------------------------------------------
                        If Global1.PARAM_EarningsFor_13_14 <> "" Then
                            Dim DsErnX As DataSet
                            Dim Ar() As String
                            Dim m As Integer
                            Dim s As Integer
                            Ar = Global1.PARAM_EarningsFor_13_14.Split("|")

                            Dim Ernx As Double = 0
                            Dim c As Integer

                            For m = 0 To Ar.Length - 1
                                DsErnX = Global1.Business.CalculateEarningsFor13SalaryAverage(Emp, GLBCurrentPeriod, Ar(m))
                                If CheckDataSet(DsErnX) Then
                                    For s = 0 To DsErnX.Tables(0).Rows.Count - 1
                                        Ernx = Ernx + DbNullToDouble(DsErnX.Tables(0).Rows(s).Item(0))
                                        c = c + 1
                                    Next
                                End If
                                'OtherErnfor1314 = RoundMe2(OtherErnfor1314 + Ernx / c, 2)
                                'c = 0
                                'Ernx = 0
                                OtherErnfor1314 = Ernx
                                If Global1.PARAM_ShowIncommision Then
                                    OtherErnfor1314 = 0
                                    GlbAveragecommision = RoundMe2(Ernx / k, 2)
                                End If
                            Next
                        End If
                        '----------------------------------------------
                        'End of Other Earnings 
                        '----------------------------------------------

                        Sal = RoundMe2((Sal + OtherErnfor1314) / k, 2)
                        'Sal = Sal + OtherErnfor1314

                        If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                            Gross = Sal
                        End If
                    End If

                End If
                If Me.GLBCurrentPeriod.PayCat_Code = "4" Then
                    Dim DS4 As DataSet
                    DS4 = Global1.Business.CalculateSalaryFor14(Emp, Me.GLBCurrentPeriod)
                    If CheckDataSet(DS4) Then
                        For i = 0 To DS4.Tables(0).Rows.Count - 1
                            Sal = Sal + DbNullToDouble(DS4.Tables(0).Rows(i).Item(0))
                        Next
                        '----------------------------------------------
                        'Other Earnings in 13/14 Average Calculation
                        '----------------------------------------------
                        If Global1.PARAM_EarningsFor_13_14 <> "" Then
                            Dim DsErnX As DataSet
                            Dim Ar() As String
                            Dim m As Integer
                            Dim s As Integer
                            Ar = Global1.PARAM_EarningsFor_13_14.Split("|")

                            Dim Ernx As Double = 0
                            Dim c As Integer

                            For m = 0 To Ar.Length - 1
                                DsErnX = Global1.Business.CalculateEarningsFor13SalaryAverage(Emp, GLBCurrentPeriod, Ar(m))
                                If CheckDataSet(DsErnX) Then
                                    For s = 0 To DsErnX.Tables(0).Rows.Count - 1
                                        Ernx = Ernx + DbNullToDouble(DsErnX.Tables(0).Rows(s).Item(0))
                                        c = c + 1
                                    Next
                                End If
                                'OtherErnfor1314 = RoundMe2(OtherErnfor1314 + Ernx / c, 2)
                                'c = 0
                                'Ernx = 0
                                OtherErnfor1314 = Ernx
                                If Global1.PARAM_ShowIncommision Then
                                    OtherErnfor1314 = 0
                                    GlbAveragecommision = RoundMe2(Ernx / k, 2)
                                End If
                            Next
                        End If
                        '----------------------------------------------
                        'End of Other Earnings 
                        '----------------------------------------------
                        Sal = RoundMe2((Sal + OtherErnfor1314) / k, 2)
                        'Sal = Sal + OtherErnfor1314

                        If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                            Gross = Sal
                        End If
                    End If
                End If
                '---------------------------------------------------------------------------------------------
            Else
                'NOT AVERAGE 13/14 , Calcalate Average Commision for Andrikian
                If Global1.PARAM_EarningsFor_13_14 <> "" Then
                    '--------------------------------------------------------------------------------------------
                    Dim i As Integer
                    Dim k As Integer = 0
                    Dim Sal As Double = 0
                    If Me.GLBCurrentPeriod.PayCat_Code = "3" Then
                        Dim DS3 As DataSet

                        DS3 = Global1.Business.CalculateSalaryFor13(Emp, Me.GLBCurrentPeriod)
                        If CheckDataSet(DS3) Then
                            'Dim ss As Integer = DS3.Tables(0).Rows.Count
                            'For i = 0 To DS3.Tables(0).Rows.Count - 1
                            ' k = k + 1
                            ' Next
                            k = 12 ' FOR ANDRIKIAN
                            'Sal = Sal + Gross
                            '  k = k + 1
                            '----------------------------------------------
                            'Other Earnings in 13/14 Average Calculation
                            '----------------------------------------------
                            If Global1.PARAM_EarningsFor_13_14 <> "" Then
                                Dim DsErnX As DataSet
                                Dim Ar() As String
                                Dim m As Integer
                                Dim s As Integer
                                Ar = Global1.PARAM_EarningsFor_13_14.Split("|")

                                Dim Ernx As Double = 0
                                Dim c As Integer

                                For m = 0 To Ar.Length - 1
                                    DsErnX = Global1.Business.CalculateEarningsFor13SalaryAverage(Emp, GLBCurrentPeriod, Ar(m))
                                    If CheckDataSet(DsErnX) Then
                                        For s = 0 To DsErnX.Tables(0).Rows.Count - 1
                                            Ernx = Ernx + DbNullToDouble(DsErnX.Tables(0).Rows(s).Item(0))
                                            c = c + 1
                                        Next
                                    End If
                                    'OtherErnfor1314 = RoundMe2(OtherErnfor1314 + Ernx / c, 2)
                                    'c = 0
                                    'Ernx = 0
                                    OtherErnfor1314 = Ernx
                                    If Global1.PARAM_ShowIncommision Then
                                        OtherErnfor1314 = 0
                                        GlbAveragecommision = RoundMe2(Ernx / k, 2)
                                    End If
                                Next
                            End If
                            '----------------------------------------------
                            'End of Other Earnings 
                            '----------------------------------------------
                        End If
                    End If
                End If
            End If
        End If

        If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
            'Hourly
            'RateForOvertimeCalc = Gross
            If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                ActualUnits = 0
                'ActualUnits = (ActualUnits + Me.GLBCurrentPeriod.PeriodUnits) / Me.GLBCurrentPeriod.NumberOfNormalPeriods
            End If
            Rate = Gross
            Salary = RoundMe3(Rate * ActualUnits, 2)
        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
            'Period
            If Emp.PeriodUnits = 0 Then
                NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
            Else
                NormalUnits = Emp.PeriodUnits
                If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                    NormalUnits = Emp.AnnualUnits
                    If Emp.AnnualUnits = 0 Then
                        NormalUnits = ActualUnits
                        MsgBox("Please define Annual Units for employee " & Emp.Code & " - " & Emp.FullName, MsgBoxStyle.Information)
                    End If
                End If
            End If
            If NormalUnits <> 0 Then
                Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
            Else
                Salary = 0
            End If
            If Me.GLBCalculateRateOnDays Then
                Dim TotalHoursInMonth As Double
                TotalHoursInMonth = Me.GLBTotalWorkDaysInMonth * 8
                Salary = RoundMe3((Gross / TotalHoursInMonth) * ActualUnits, 2)
            End If
            'RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
            'GrossFor13AND14Calc = Gross
            'GrossDIVNormalUnitsForCalc = RoundMe3(Gross / NormalUnits, 2)
        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Contract_Code Then
            'contract
            NormalUnits = Emp.PeriodUnits
            If NormalUnits <> 0 Then
                Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
            Else
                Salary = 0
            End If
            'RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
            'GrossFor13AND14Calc = Gross
            'GrossDIVNormalUnitsForCalc = RoundMe3(Gross / NormalUnits, 2)
        End If
        If GLBSetSalaryToZero Then
            Salary = 0
        End If
        Return Salary

        'Me.txtSalary.Text = Format(Salary, "0.00")
    End Function
    'Private Sub E_CalculateOverTime(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    Dim OverTime1 As Double = 0
    '    Dim OverTime2 As Double = 0

    '    If Me.txtOvertime1.Text = "" Then
    '        Me.txtOvertime1.Text = 0
    '    End If
    '    If Me.txtOvertime2.Text = "" Then
    '        Me.txtOvertime2.Text = 0
    '    End If
    '    OverTime1 = RoundMe3(RateForOvertimeCalc * Parameters.OverTime_Rate1 * Me.txtOvertime1.Text, 2)
    '    OverTime2 = RoundMe3(RateForOvertimeCalc * Parameters.OverTime_Rate2 * Me.txtOvertime2.Text, 2)

    '    Dim i As Integer
    '    For i = 0 To E_Final.Length - 1
    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '            E_Final(i).MyValue = OverTime1 + OverTime2
    '            Exit For
    '        End If
    '    Next
    'Me.txtOver1.Text = Format(OverTime1, "0.00")
    'Me.txtOver2.Text = Format(OverTime2, "0.00")
    'End Sub
    'Private Sub E_CalculateArrears(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    Dim Arrears As Double = 0
    '    Dim i As Integer
    '    If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
    '        If Me.GlbEmpSalary.EffPayDate >= Me.GLBCurrentPeriod.DateFrom Then
    '            If Me.GlbEmpSalary.EffPayDate <= Me.GLBCurrentPeriod.DateTo Then
    '                Dim NumberOfPeriods As Integer
    '                NumberOfPeriods = Global1.Business.GetNumberOfNormalPeriodsBack(GlbEmpSalary, GLBCurrentPeriod)
    '                Arrears = NumberOfPeriods * GlbEmpSalary.EmpSal_Dif
    '            End If
    '        End If
    '    End If
    '    ArrearsFor13AND14Calc = Arrears
    '    For i = 0 To E_Final.Length - 1
    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '            E_Final(i).MyValue = Arrears
    '            Exit For
    '        End If
    '    Next
    '    'Me.txtarrears.text = Format(Arrears, "0.00")
    'End Sub
    'Private Sub E_13Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    Dim t13Salary As Double = 0
    '    Dim ActualUnits As Double = Me.txtActualUnits.Text
    '    Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
    '    Dim SumOfAnuallUnitOfNormalPeriods As Double
    '    Dim AnuallUnitsOfThisPeriod As Double = 0
    '    Dim i As Integer


    '    AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

    '    SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

    '    t13Salary = GrossDIVNormalUnitsForCalc * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod)

    '    For i = 0 To E_Final.Length - 1
    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '            E_Final(i).MyValue = t13Salary
    '            Exit For
    '        End If
    '    Next
    'End Sub
    'Private Sub E_14Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    Dim t14Salary As Double = 0
    '    Dim ActualUnits As Double = Me.txtActualUnits.Text
    '    Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
    '    Dim SumOfAnuallUnitOfNormalPeriods As Double
    '    Dim AnuallUnitsOfThisPeriod As Double = 0
    '    Dim i As Integer

    '    AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

    '    SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

    '    t14Salary = GrossDIVNormalUnitsForCalc * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod)
    '    For i = 0 To E_Final.Length - 1
    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '            E_Final(i).MyValue = t14Salary
    '            Exit For
    '        End If
    '    Next
    'End Sub
    'Private Sub E_Calculate13Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    Dim t13estimate As Double = 0
    '    Dim AnnualPeriodUnits As Double
    '    Dim t13thPeriodTotalUnits As Double
    '    Dim i As Integer

    '    t13thPeriodTotalUnits = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
    '    AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

    '    If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
    '        If t13thPeriodTotalUnits <> 0 Then
    '            t13estimate = Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc * (AnnualPeriodUnits / t13thPeriodTotalUnits)
    '        End If
    '    End If

    '    For i = 0 To E_Final.Length - 1
    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '            E_Final(i).MyValue = t13estimate
    '            Exit For
    '        End If
    '    Next
    'End Sub
    'Private Sub E_Calculate14Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
    '    Dim t14estimate As Double = 0
    '    Dim AnnualPeriodUnits As Double
    '    Dim t14thPeriodTotalUnits As Double
    '    Dim i As Integer

    '    t14thPeriodTotalUnits = Global1.Business.Find14nthPeriodUnits(Me.GLBCurrentPeriod)
    '    AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

    '    If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
    '        If t14thPeriodTotalUnits <> 0 Then
    '            t14estimate = Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc * (AnnualPeriodUnits / t14thPeriodTotalUnits)
    '        End If
    '    End If
    '    For i = 0 To E_Final.Length - 1
    '        If Earn.Code = E_Final(i).Earn.ErnCodCode Then
    '            E_Final(i).MyValue = t14estimate
    '            Exit For
    '        End If
    '    Next
    '    ' Me.txt14Estimate.Text = Format(t14estimate, "0.00")
    'End Sub
    Private Function E_CalculateOtherIncome(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '    Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim OtherIncome As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                OtherIncome = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                OtherIncome = EmpErn.MyValue
            End If
        End If

        Return OtherIncome

    End Function
    Private Function E_CalculateFine(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '    Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Fine As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Fine = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                Fine = EmpErn.MyValue
            End If
        End If

        Return Fine

    End Function
    Private Function E_CalculateFishes(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '    Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Fishes As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Fishes = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                Fishes = EmpErn.MyValue
            End If
        End If

        Return Fishes

    End Function
    Private Function E_CalculateRecuringNegative(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim RecNegative As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                RecNegative = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                RecNegative = EmpErn.MyValue
            End If
        End If

        Return RecNegative

    End Function
    Private Function E_CalculateRecuringEarnings(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim RecErn As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                RecErn = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                RecErn = EmpErn.MyValue
            End If
        End If

        Return RecErn

    End Function
    Private Function E_CalculateRecuringEarnings14(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        ' Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim RecErn As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                RecErn = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                RecErn = EmpErn.MyValue
            End If
        End If

        Return RecErn

    End Function
    Private Function E_CalculateBenefitsInKind(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim BIK As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                BIK = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                BIK = EmpErn.MyValue
            End If
        End If

        Return BIK

    End Function

    Private Function E_CalculateBenefitsInKind14(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim BIK14 As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                BIK14 = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                BIK14 = EmpErn.MyValue
            End If
        End If

        Return BIK14

    End Function
    Private Function E_CalculateDirectorFees(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim DirectorFees As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                DirectorFees = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                DirectorFees = EmpErn.MyValue
            End If
        End If

        Return DirectorFees

    End Function
    Private Function E_CalculateCOLA(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '    Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim COLA As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                COLA = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                COLA = EmpErn.MyValue
            End If
        End If

        Return COLA

    End Function
    Private Function E_CalculateSocialInsuranceLeave(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim SILeave As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                SILeave = EmpErn.MyValue
            ElseIf TempErn.TypeMode = "V" Then
                SILeave = EmpErn.MyValue
            End If
        End If

        Return SILeave
    End Function
    Private Function E_CalculateSector(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '        Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim Sec As New cPrSsSectorPay(Emp.SectorPay)
                    If Sec.Code <> "" Then
                        Value = Sec.HourRate
                    Else
                        Value = 0
                    End If
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim Sector As New cPrSsSectorPay(Emp.SectorPay)
                    If Sector.Code <> "" Then
                        Value = Sector.HourRate
                    Else
                        Value = 0
                    End If
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculateDutyHour(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '    Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim DutyHour As New cPrSsDutyHours(Emp.DutyHours)
                    If DutyHour.Code <> "" Then
                        Value = DutyHour.HourRate
                    Else
                        Value = 0
                    End If
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim DutyHour As New cPrSsDutyHours(Emp.DutyHours)
                    If DutyHour.Code <> "" Then
                        Value = DutyHour.HourRate
                    Else
                        Value = 0
                    End If
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculateOverLay(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim OverLay As New cPrSsOverLay(Emp.OverLay)
                    If OverLay.Code <> "" Then
                        Value = OverLay.HourRate
                    Else
                        Value = 0
                    End If
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim OverLay As New cPrSsOverLay(Emp.OverLay)
                    If OverLay.Code <> "" Then
                        Value = OverLay.HourRate
                    Else
                        Value = 0
                    End If
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculateTimeOff(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Value = EmpErn.MyValue
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Value = EmpErn.MyValue
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculateTimeOffPossitive(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Value = EmpErn.MyValue
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Value = EmpErn.MyValue
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculateAnualLeaveLL(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal EmpActualUnits As Double, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then

            Dim TempEarn As New cPrMsTemplateEarnings
            Dim i As Integer
            Dim ANLeave As Double
            Dim ValueToCalcFrom As Double
            Dim AlForYear As Double
            Dim ALTaken As Double
            Dim CF As Double
            Dim NormalPeriods As Integer
            Dim ALAllowed As Double
            Dim NormalPeriodsUntilNow As Integer
            Dim Dif As Double
            Dim AnnualLeave As Double = 0

            If Emp.TerminateDate <> "" Then
                If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                    AlForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation(Emp, "T")
                    ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation(Emp, "B")
                    CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation(Emp, "C")
                    NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods
                    NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow
                    Dim WorkedPeriodsUntilNow As Integer
                    WorkedPeriodsUntilNow = Global1.Business.GetNumberOfNormalWorkedPeriods(Emp.Code, Me.GLBCurrentPeriod)
                    Dim NormalPeriodsForThisEmloyee As Integer = 0
                    NormalPeriodsForThisEmloyee = NormalPeriods - (NormalPeriodsUntilNow - WorkedPeriodsUntilNow)





                    Dim UnitsOfThisPeriod As Double
                    Dim SumOfAnuallUnitOfNormalPeriods As Double
                    UnitsOfThisPeriod = EmpActualUnits
                    SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsForX(Me.GLBCurrentPeriod, Emp.Code)

                    ALAllowed = AlForYear * ((SumOfAnuallUnitOfNormalPeriods + UnitsOfThisPeriod) / (NormalPeriodsForThisEmloyee * GLBCurrentPeriod.PeriodUnits))

                    Dif = ALAllowed - ALTaken

                    Value = Dif

                End If
            End If
        End If
        Return Value

    End Function
    Private Function GetAnnualLeaveFor_13_14_SalaryCalculation(ByVal Emp As cPrMsEmployees, ByVal TypeOfLeave As String) As Double
        Dim ReturnValue As Double = 0
        Dim LeaveTypes As New cPrSsLeaveTypes()
        Dim LeaveCode As String
        Dim dsAL As DataSet
        Dim TotalLeave As Double = 0
        Dim TotalTaken As Double = 0
        Dim TotalCarryForward As Double = 0

        dsAL = Global1.Business.GetParameter("Leave Type", "Annual Leave ID")
        If CheckDataSet(dsAL) Then
            Dim Par As New cPrSsParameters(dsAL.Tables(0).Rows(0))
            LeaveCode = Par.Value1
            LeaveTypes = New cPrSsLeaveTypes(LeaveCode)
            Dim FromDate As Date = CDate(Me.GLBCurrentPeriod.DateFrom.Year & "/" & "01/01")
            Dim ToDate As Date = CDate(Me.GLBCurrentPeriod.DateFrom.Year & "/" & "12/31")

            Dim EOY As Double = 0
            TotalLeave = Global1.Business.GetEmployeeTotalPerTypePerAction(Emp.Code, LeaveTypes.Code, AN_IncreaseCODE, FromDate, ToDate, AN_Approved)
            TotalCarryForward = Global1.Business.GetEmployeeTotalPerTypePerAction(Emp.Code, LeaveTypes.Code, AN_CarryForwardCODE, FromDate, ToDate, AN_Approved)
            TotalTaken = Global1.Business.GetEmployeeTotalPerTypePerAction(Emp.Code, LeaveTypes.Code, AN_DecreaseCODE, FromDate, ToDate, AN_Approved)
            If TypeOfLeave = "T" Then
                ReturnValue = TotalLeave
            ElseIf TypeOfLeave = "C" Then
                ReturnValue = TotalCarryForward
            ElseIf TypeOfLeave = "B" Then
                ReturnValue = TotalTaken

            End If

        End If
        Return ReturnValue
    End Function
    Private Function E_CalculateFlightHour(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '        Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim FlightHour As New cPrSsFlightHours(Emp.FlightHours)
                    If FlightHour.Code <> "" Then
                        Value = FlightHour.HourRate
                    Else
                        Value = 0
                    End If
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim FlightHour As New cPrSsFlightHours(Emp.FlightHours)
                    If FlightHour.Code <> "" Then
                        Value = FlightHour.HourRate
                    Else
                        Value = 0
                    End If
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculatePerformanceBonus(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        '  Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        GLB_PBAmount = 0
        GLB_PBRate = 0

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim PB As New cPrSsPerformanceBonus(Emp.PerformanceBonus)
                    If PB.Type = "V" Then
                        Value = PB.MyValue
                        GLB_PBAmount = PB.MyValue
                        GLB_PBRate = 100
                    ElseIf PB.Type = "P" Then
                        Value = PB.Rate
                        GLB_PBRate = PB.Rate

                        If PB.Formula = "P" Then
                            GLB_PBAmount = PB.MyValue
                        End If
                        If PB.Formula = "S" Then
                            GLB_PBAmount = glb_PBSalary
                        End If
                        If PB.Formula = "A" Then
                            GLB_PBAmount = glb_PBSalary * GLBCurrentPeriod.NumberOfTotalPeriods
                        End If
                    End If
                End If
            ElseIf TempErn.TypeMode = "V" Then
                GLB_PBRate = 0
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                    GLB_PBAmount = Value
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                    GLB_PBAmount = Value
                ElseIf TempErn.FromMode = "T" Then
                    Dim PB As New cPrSsPerformanceBonus(Emp.PerformanceBonus)
                    If PB.Code <> "" Then
                        Value = PB.MyValue
                        GLB_PBAmount = PB.MyValue
                    Else
                        Value = 0

                    End If
                End If
            End If
        End If
        Return Value

    End Function
    Private Function E_CalculateSalesCommission(ByVal Emp As cPrMsEmployees, ByVal EmpErn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal TempErn As cPrMsTemplateEarnings) As Double
        'Dim TempErn As New cPrMsTemplateEarnings(Me.GLBTempGroup.Code, Earn.Code)
        Dim Value As Double

        If TempErn.ErnCodCode <> "" Then
            If TempErn.TypeMode = "P" Then
                Value = EmpErn.MyValue
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim SC As New cPrSsCommissionRates(Emp.CommissionRate)
                    If SC.Code <> "" Then
                        Value = SC.MyValue
                    Else
                        Value = 0
                    End If
                End If
            ElseIf TempErn.TypeMode = "V" Then
                If TempErn.FromMode = "E" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "F" Then
                    Value = EmpErn.MyValue
                ElseIf TempErn.FromMode = "T" Then
                    Dim SC As New cPrSsCommissionRates(Emp.CommissionRate)
                    If SC.Code <> "" Then
                        Value = SC.MyValue
                    Else
                        Value = 0
                    End If
                End If
            End If
        End If
        Return Value

    End Function

#End Region
#Region "Find Values For Employee Deductions"
    Private Sub FindDeductionValue(ByVal TrxnLinesDS As DataSet, ByRef ED As cPrMsEmployeeDeductions, ByVal Emp As cPrMsEmployees, ByVal TempDed As cPrMsTemplateDeductions)
        'Dim Emp As New cPrMsEmployees(ED.EmpCode)
        Dim Ded As New cPrMsDeductionCodes(ED.DedCode)

        Dim GoHere As Boolean = True

        If CheckDataSet(TrxnLinesDS) Then
            GoHere = False
            Dim i As Integer
            For i = 0 To TrxnLinesDS.Tables(0).Rows.Count - 1
                Dim Lin As New cPrTxTrxnLines(TrxnLinesDS.Tables(0).Rows(i))
                If Lin.TrxLin_Type = "D" Then
                    If ED.DedCode = Lin.DedCod_Code Then
                        ED.MyValue = Lin.TrxLin_EDC
                    End If
                End If
            Next
        End If
        If GoHere Then

            Select Case Ded.DedTypCode
                Case "AD" 'ADVANCES
                    ED.MyValue = D_CalculateAdvances(Emp, ED, Ded, TempDed)
                Case "CL" 'COMPANY LOAN
                    ED.MyValue = D_CalculateCompanyLoan(Emp, ED, Ded, TempDed)
                Case "IT" 'INCOME TAX
                    'MsgBox("1")
                Case "MF" 'MEDICAL FUND
                    ED.MyValue = D_CalculateMedicalFund(Emp, ED, Ded, TempDed)
                Case "PF" 'PROVIDENT FUND
                    ED.MyValue = D_CalculateProvidentFund(Emp, ED, Ded, TempDed)
                Case "PL" 'PROVIDENT FUND LOAN
                    ED.MyValue = D_CalculateProvidentFundLoan(Emp, ED, Ded, TempDed)
                Case "SI" 'SOCIAL INSURANCE
                    ED.MyValue = D_CalculateSocialInsurance(Emp, ED, Ded, TempDed)
                    glbCurrentEmployeeSIRate_deduction = ED.MyValue
                Case "U2" 'UNION NEWSPAPER
                    ED.MyValue = D_CalculateUnion2(Emp, ED, Ded, TempDed)
                Case "U3" 'OTHER
                    ED.MyValue = D_CalculateUnion3(Emp, ED, Ded, TempDed)
                Case "US" 'UNINON SUBSCRIPTION
                    ED.MyValue = D_CalculateUnionSubscription(Emp, ED, Ded, TempDed)
                Case "UM" 'UNINON SUBSCRIPTION
                    ED.MyValue = D_CalculateUnionMedicalFund(Emp, ED, Ded, TempDed)
                Case "DN" 'UNINON SUBSCRIPTION
                    ED.MyValue = D_CalculateDecrease(Emp, ED, Ded, TempDed) ', "01")
                    'Case "DP" 'UNINON SUBSCRIPTION
                    'ED.MyValue = D_CalculateDecrease(Emp, ED, Ded, "02")
                Case "GD" 'GESY
                    ED.MyValue = D_CalculateGESI(Emp, ED, Ded, TempDed)
                Case "GT" 'GESY BIK
                    ED.MyValue = D_CalculateGESI_BIK(Emp, ED, Ded, TempDed)
                Case "GP" 'GESY Pensioners
                    ED.MyValue = D_CalculateGESI_Pensioners(Emp, ED, Ded, TempDed)

            End Select
        End If
    End Sub
    Private Function D_CalculateAdvances(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Advances As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                Advances = EmpDed.MyValue
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    Advances = EmpDed.MyValue
                Else
                    Advances = Global1.Business.CalculateEmployeeAdvancesFromTable(Emp.Code)
                End If

            End If
        End If

        Return Advances

    End Function
    Private Function D_CalculateCompanyLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim CompanyLoan As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                CompanyLoan = EmpDed.MyValue
            ElseIf TempDed.TypeMode = "V" Then
                CompanyLoan = EmpDed.MyValue
            End If
        End If

        Return CompanyLoan


    End Function
    Private Function D_CalculateProvidentFundLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim PFLoan As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                PFLoan = EmpDed.MyValue
            ElseIf TempDed.TypeMode = "V" Then
                PFLoan = EmpDed.MyValue
            End If
        End If

        Return PFLoan


    End Function
    Private Function D_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim MFValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                MFValue = EmpDed.MyValue
                If TempDed.FromMode = "E" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.DedValue
                    Else
                        MFValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.DedValue
                    Else
                        MFValue = 0
                    End If
                End If
            End If
        End If

        Return MFValue

    End Function
    Private Function D_CalculateGESI(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim GESIValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                GESIValue = EmpDed.MyValue
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If
            End If
        End If

        Return GESIValue

    End Function
    Private Function D_CalculateGESI_BIK(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        'Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim GESIValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                GESIValue = EmpDed.MyValue
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.DedValue
                    Else
                        GESIValue = 0
                    End If
                End If
            End If
        End If

        Return GESIValue

    End Function
    Private Function D_CalculateGESI_Pensioners(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim GESIPen As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                GESIPen = EmpDed.MyValue
                If TempDed.FromMode = "E" Then
                    GESIPen = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIPen = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIPen = GES.DedValue
                    Else
                        GESIPen = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    GESIPen = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    GESIPen = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIPen = GES.DedValue
                    Else
                        GESIPen = 0
                    End If
                End If
            End If
        End If

        Return GESIPen

    End Function
    Private Function D_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim PFValue As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.DedValue
                    Else
                        PFValue = 0
                    End If

                End If
                PFValue = PFValue
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    PFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.DedValue
                    Else
                        PFValue = 0
                    End If
                End If

            End If
        End If

        Return PFValue


    End Function
    Private Function D_CalculateSocialInsurance(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim SIValue As Double
        Dim Limits As New cPrSsLimits

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.DedValue
                    Else
                        SIValue = 0
                    End If
                End If

            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    SIValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.DedValue
                    Else
                        SIValue = 0
                    End If
                End If

            End If
        End If
        Return SIValue

    End Function
    Private Function D_CalculateUnionSubscription(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim UnionValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionValue = Union.Uni_SubscriptionValue
                    Else
                        UnionValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionValue = Union.Uni_SubscriptionValue
                    Else
                        UnionValue = 0
                    End If
                End If

            End If
        End If

        'Checking Or Union Sub. Limit 
        If UnionValue > Union.MonthlySubLimit Then
            UnionValue = Union.MonthlySubLimit
        End If


        Return UnionValue



    End Function
    Private Function D_CalculateUnion2(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Union2Value As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union2Value = Union.Uni_Deduction1
                    Else
                        Union2Value = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union2Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union2Value = Union.Uni_Deduction1
                    Else
                        Union2Value = 0
                    End If
                End If

            End If
        End If

        Return Union2Value


    End Function
    Private Function D_CalculateUnion3(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Union3Value As Double

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union3Value = Union.Uni_Deduction2
                    Else
                        Union3Value = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Union3Value = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim Union As New cPrAnUnions(Emp.Uni_Code)
                    If Union.Code <> "" Then
                        Union3Value = Union.Uni_Deduction2
                    Else
                        Union3Value = 0
                    End If
                End If

            End If
        End If

        Return Union3Value

    End Function
    Private Function D_CalculateUnionMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '    Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim UnionMFValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    UnionMFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If

            End If
        End If

        Return UnionMFValue

    End Function
    Private Function D_CalculateDecrease(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal TempDed As cPrMsTemplateDeductions) As Double
        '        Dim TempDed As New cPrMsTemplateDeductions(Me.GLBTempGroup.Code, Dedu.Code)
        Dim Decrease As Double


        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                If TempDed.FromMode = "E" Then
                    Decrease = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Decrease = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Decrease = EmpDed.MyValue
                ElseIf TempDed.FromMode = "X" Then
                    Decrease = EmpDed.MyValue
                End If
            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    Decrease = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    Decrease = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Decrease = EmpDed.MyValue
                ElseIf TempDed.FromMode = "X" Then
                    Decrease = EmpDed.MyValue
                End If

            End If
        End If

        Return Decrease

    End Function
#End Region
#Region "Find Values For Employee Contributions"
    Private Sub FindContributionValue(ByVal TrxnLinesDS As DataSet, ByRef EC As cPrMsEmployeeContributions, ByVal Emp As cPrMsEmployees, ByVal TempCon As cPrMsTemplateContributions)
        Dim Con As New cPrMsContributionCodes(EC.ConCode)
        'Dim Emp As New cPrMsEmployees(EC.EmpCode)

        Dim GoHere As Boolean = True

        If CheckDataSet(TrxnLinesDS) Then
            GoHere = False
            Dim i As Integer
            For i = 0 To TrxnLinesDS.Tables(0).Rows.Count - 1
                Dim Lin As New cPrTxTrxnLines(TrxnLinesDS.Tables(0).Rows(i))
                If Lin.TrxLin_Type = "C" Then
                    If EC.ConCode = Lin.ConCod_Code Then
                        EC.MyValue = Lin.TrxLin_EDC
                    End If
                End If
            Next
        End If
        If GoHere Then
            Select Case Con.ConTypCode
                Case "IN" 'INDUSTRIAL
                    EC.MyValue = C_CalculateIndustrial(Emp, EC, Con, TempCon)
                Case "MF" 'MEDICAL FUND
                    EC.MyValue = C_CalculateMedicalFund(Emp, EC, Con, TempCon)
                Case "PF" 'PROVIDENT FUND
                    EC.MyValue = C_CalculateProvidentFund(Emp, EC, Con, TempCon)
                Case "SI" 'SOCIAL INSURANCE
                    EC.MyValue = C_CalculateSocialInsurance(Emp, EC, Con, TempCon)
                    glbCurrentEmployeeSIRate_Contribution = EC.MyValue
                Case "ST" 'SOCIAL COHESION FUND
                    EC.MyValue = C_CalculateSocialCohesionFund(Emp, EC, Con, TempCon)
                Case "UN" 'UNEMPLOYMENT
                    EC.MyValue = C_CalculateUnemploymentFund(Emp, EC, Con, TempCon)
                Case "WF" 'WELFAIR FUND
                    EC.MyValue = C_CalculateWelFairFund(Emp, EC, Con, TempCon)
                Case "UM" 'UNION MEDICAL FUND
                    EC.MyValue = C_CalculateUnionMedicalFund(Emp, EC, Con, TempCon)
                Case "GC" 'GESI
                    EC.MyValue = C_CalculateGESI(Emp, EC, Con, TempCon)
                Case "BC" 'GESI BIK
                    EC.MyValue = C_CalculateGESI_BIK(Emp, EC, Con, TempCon)


            End Select
        End If
    End Sub
    Private Function C_CalculateIndustrial(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim Industrial As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Ind As New cPrSsIndustrial(Emp.Ind_Code)
                    If Ind.Code <> "" Then
                        Industrial = Ind.ConValue
                    Else
                        Industrial = 0
                    End If
                End If

                Industrial = Industrial
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    Industrial = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Ind As New cPrSsIndustrial(Emp.Ind_Code)
                    If Ind.Code <> "" Then
                        Industrial = Ind.ConValue
                    Else
                        Industrial = 0
                    End If
                End If
            End If
        End If


        Return Industrial

    End Function
    Private Function C_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '  Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim MFValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.ConValue
                    Else
                        MFValue = 0
                    End If
                End If
                MFValue = MFValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.ConValue
                    Else
                        MFValue = 0
                    End If
                End If

            End If
        End If
        Return MFValue

    End Function
    Private Function C_CalculateGESI(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim GESIValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.ConValue
                    Else
                        GESIValue = 0
                    End If
                End If
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.ConValue
                    Else
                        GESIValue = 0
                    End If
                End If
            End If
        End If
        Return GESIValue

    End Function
    Private Function C_CalculateGESI_BIK(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim GESIValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.ConValue
                    Else
                        GESIValue = 0
                    End If
                End If
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    GESIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim GES As New cPrSsGesi(Emp.GESICode)
                    If GES.Code <> "" Then
                        GESIValue = GES.ConValue
                    Else
                        GESIValue = 0
                    End If
                End If
            End If
        End If
        Return GESIValue

    End Function
    Private Function C_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim PFValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.ConValue
                    Else
                        PFValue = 0
                    End If
                End If
                PFValue = PFValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    PFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
                    If ProFund.Code <> "" Then
                        PFValue = ProFund.ConValue
                    Else
                        PFValue = 0
                    End If
                End If

            End If
        End If

        Return PFValue

    End Function
    Private Function C_CalculateSocialInsurance(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim SIValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.SocInc_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.ConValue
                    Else
                        SIValue = 0
                    End If
                End If

                SIValue = SIValue

            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SIValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocIns As New cPrSsSocialInsurance(Emp.ProFnd_Code)
                    If SocIns.Code <> "" Then
                        SIValue = SocIns.ConValue
                    Else
                        SIValue = 0
                    End If
                End If

            End If
        End If

        Return SIValue


    End Function
    Private Function C_CalculateSocialCohesionFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim SCValue As Double


        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocCoh As New cPrSsSocialCohesion(Emp.SocCoh_Code)
                    If SocCoh.Code <> "" Then
                        SCValue = SocCoh.ConValue
                    Else
                        SCValue = 0
                    End If
                End If
                SCValue = SCValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    SCValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim SocCoh As New cPrSsSocialCohesion(Emp.SocCoh_Code)
                    If SocCoh.Code <> "" Then
                        SCValue = SocCoh.ConValue
                    Else
                        SCValue = 0
                    End If
                End If
            End If
        End If

        Return SCValue

    End Function
    Private Function C_CalculateUnemploymentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim UFValue As Double

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Une As New cPrSsUnemployment(Emp.Une_Code)
                    If Une.Code <> "" Then
                        UFValue = Une.ConValue
                    Else
                        UFValue = 0
                    End If
                End If

                UFValue = UFValue
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim Une As New cPrSsUnemployment(Emp.Une_Code)
                    If Une.Code <> "" Then
                        UFValue = Une.ConValue
                    Else
                        UFValue = 0
                    End If
                End If
            End If
        End If


        Return UFValue

    End Function
    Private Function C_CalculateWelFairFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        '    Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim UnionWFValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionWFValue = Union.WelfareRate
                    Else
                        UnionWFValue = 0
                    End If
                End If
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionWFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionWFValue = Union.WelfareRate
                    Else
                        UnionWFValue = 0
                    End If
                End If

            End If
        End If

        Return UnionWFValue

    End Function
    Private Function C_CalculateUnionMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes, ByVal TempCon As cPrMsTemplateContributions) As Double
        'Dim TempCon As New cPrMsTemplateContributions(Me.GLBTempGroup.Code, Cont.Code)
        Dim UnionMFValue As Double
        Dim Union As New cPrAnUnions(Emp.Uni_Code)

        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                If TempCon.FromMode = "E" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    UnionMFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then

                    If Union.Code <> "" Then
                        UnionMFValue = Union.MonthlyMF
                    Else
                        UnionMFValue = 0
                    End If
                End If

            End If
        End If

        Return UnionMFValue

    End Function
#End Region




    Private Sub BtnSearchEmp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchEmp1.Click
        Dim f As New FrmEmployeeSearch
        f.TempGroup = Me.GLBTempGroup.Code
        f.CalledBy = 3
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub BtnSearcEmp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearcEmp2.Click
        Dim f As New FrmEmployeeSearch
        f.TempGroup = Me.GLBTempGroup.Code
        f.CalledBy = 4
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub TSBSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSearch.Click

        Sels_Counter = 0
        ReDim Sels_ArBegin(5000)
        ReDim Sels_ArEnd(5000)

        Me.TSBSearch.Enabled = False


        SearchGlobal("", 1, "")
        Me.LabelStatus.Text = ""
        Me.TSBSearch.Enabled = True

    End Sub
    Private Sub SearchGlobal(ByVal StartCode As String, ByVal NorP As Integer, ByVal EndCode As String)
        Cursor = Cursors.WaitCursor
        CheckForAnnualLeaveAllocationTemplateParameter()
        Search(StartCode, NorP, EndCode)
        RefreshCount()
        Cursor = Cursors.Default
        Application.DoEvents()
    End Sub
    Private Sub RefreshCount()
        If CheckDataSet(MyDs) Then
            Me.LblCount.Text = MyDs.Tables(0).Rows.Count
        Else
            Me.LblCount.Text = 0
        End If
    End Sub


    Private Sub Search(ByVal StartCode As String, ByVal NorP As Integer, ByVal EndCode As String)
        MyDs.Tables(0).Rows.Clear()
        Me.CBSelectGrid.CheckState = CheckState.Checked
        FindCurrentPeriod(False, StartCode, NorP, EndCode)
    End Sub
    'Private Sub SavePreparedOfLine(ByVal i As Integer)
    '    Dim Exx As New Exception
    '    Dim SaveOne As Boolean = False
    '    Dim EmpCode As String
    '    Dim Saved As Integer

    '    SaveOne = True
    '    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
    '    Dim Hdr As New cPrTxTrxnHeader(EmpCode, GLBCurrentPeriod.Code)
    '    With Hdr
    '        .Emp_Code = EmpCode
    '        .PrdGrp_Code = GLBCurrentPeriod.PrdGrpCode
    '        .PrdCod_Code = GLBCurrentPeriod.Code
    '        .PayCat_Code = GLBCurrentPeriod.PayCat_Code
    '        .MyDate = Now.Date
    '        .Status = "PREP"
    '        .TotalErnPeriod = 0
    '        .TotalErnYTD = 0
    '        .TotalDedPeriod = 0
    '        .TotalDedYTD = 0
    '        .TotalConPeriod = 0
    '        .TotalConYTD = 0
    '        .SIIncome = 0
    '        .TaxableIncome = 0
    '        .PaymentMethod = ""
    '        .PaymentRef = ""
    '        .PeriodUnits = DbNullToInt(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
    '        .AnnualUnits = 0
    '        .AnnualLeave = 0
    '        .LifeInsurance = 0
    '        .Discounts = 0
    '        .InterfaceStatus = "OUTS"
    '        .Overtime1 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
    '        .Overtime2 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime2))
    '        .SIUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SIUnits))
    '        .MonthlySalary = 0
    '        .NetSalary = 0
    '        .ChequeNo = ""
    '        .TemGrpCode = Me.GLBTempGroup.Code
    '        If Not .Save Then
    '            Throw Exx
    '        End If
    '    End With
    '    Dim Count As Integer = 0

    '    If Not Global1.Business.DeleteAllEDCFromTrxnLines(Hdr.Id) Then
    '        Throw Exx
    '    End If

    '    'Saving Earnings
    '    Dim counter As Integer = 1
    '    Dim k As Integer
    '    Dim c1 As Integer

    '    c1 = Me.Column_E1
    '    For k = 0 To 14
    '        If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
    '            Dim Lin As New cPrTxTrxnLines
    '            With Lin
    '                .TrxLin_Id = counter
    '                .TrxHdr_Id = Hdr.Id
    '                .TrxLin_Type = "E"
    '                .ErnCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
    '                .TrxLin_PeriodValue = 0
    '                .TrxLin_YTDValue = 0
    '                Try
    '                    .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
    '                Catch
    '                    MsgBox("Please Define Earnings for Employee :" & EmpCode)
    '                    Throw Exx
    '                End Try
    '                .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
    '                If Not Lin.Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '            counter = counter + 1
    '        End If
    '        c1 = c1 + 2
    '    Next
    '    'Saving Deductions
    '    c1 = Me.Column_D1
    '    For k = 0 To 14
    '        If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
    '            Dim Lin As New cPrTxTrxnLines
    '            With Lin
    '                .TrxLin_Id = counter
    '                .TrxHdr_Id = Hdr.Id
    '                .TrxLin_Type = "D"
    '                .DedCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
    '                .TrxLin_PeriodValue = 0
    '                .TrxLin_YTDValue = 0
    '                Try
    '                    .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
    '                Catch
    '                    MsgBox("Please Define Deductions for Employee :" & EmpCode)
    '                    Throw Exx
    '                End Try
    '                .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
    '                If Not Lin.Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '            counter = counter + 1
    '        End If
    '        c1 = c1 + 2
    '    Next

    '    'Saving Contributions
    '    c1 = Me.Column_C1
    '    For k = 0 To 14
    '        If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
    '            Dim Lin As New cPrTxTrxnLines
    '            With Lin
    '                .TrxLin_Id = counter
    '                .TrxHdr_Id = Hdr.Id
    '                .TrxLin_Type = "C"
    '                .ConCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
    '                .TrxLin_PeriodValue = 0
    '                .TrxLin_YTDValue = 0
    '                Try
    '                    .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
    '                Catch
    '                    MsgBox("Please Define Contributions for Employee :" & EmpCode)
    '                    Throw Exx
    '                End Try
    '                .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
    '                If Not Lin.Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '            counter = counter + 1
    '        End If
    '        c1 = c1 + 2
    '    Next

    '    MyDs.Tables(0).Rows(i).Item(Me.Column_Status) = "PREP"

    'End Sub
    Public Sub TryToSavePrepare(Optional ByVal RunFromTA As Boolean = False)
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        Dim Exx As New Exception
        Dim SaveOne As Boolean = False
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            Dim EmpCode As String
            Dim Saved As Integer
            Try
                If Not RunFromTA Then
                    Global1.Business.BeginTransaction()
                End If
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) = "<  >" Or DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) = "PREP" Then
                        If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled)) = "1" Then

                            SaveOne = True
                            '   SavePreparedOfLine(i)
                            EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                            Dim Hdr As New cPrTxTrxnHeader(EmpCode, GLBCurrentPeriod.Code)
                            With Hdr
                                .Emp_Code = EmpCode
                                .PrdGrp_Code = GLBCurrentPeriod.PrdGrpCode
                                .PrdCod_Code = GLBCurrentPeriod.Code
                                .PayCat_Code = GLBCurrentPeriod.PayCat_Code
                                .MyDate = Now.Date
                                .Status = "PREP"
                                .TotalErnPeriod = 0
                                .TotalErnYTD = 0
                                .TotalDedPeriod = 0
                                .TotalDedYTD = 0
                                .TotalConPeriod = 0
                                .TotalConYTD = 0
                                .SIIncome = 0
                                .TaxableIncome = 0
                                .PaymentMethod = ""
                                .PaymentRef = ""
                                .PeriodUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
                                .AnnualUnits = 0
                                .AnnualLeave = 0
                                .LifeInsurance = 0
                                .Discounts = 0
                                .InterfaceStatus = "OUTS"
                                .Overtime1 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                                .Overtime2 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime2))
                                .Overtime3 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime3))
                                .SIUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SIUnits))
                                .MonthlySalary = 0
                                .NetSalary = 0
                                .ChequeNo = ""
                                .TemGrpCode = Me.GLBTempGroup.Code


                                .Sectors = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Sectors))
                                .DutyHours = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DutyHours))
                                .FlightHours = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_FlightHours))
                                .Commission = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Commission))
                                .OverLay = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverLay))
                                .PBAmount = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_PBAmount))
                                .PBRate = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_PBRate))

                                .SIUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SIUnits))

                                If Not .Save Then
                                    Throw Exx
                                End If
                            End With
                            Dim Count As Integer = 0

                            If Not Global1.Business.DeleteAllEDCFromTrxnLines(Hdr.Id) Then
                                Throw Exx
                            End If

                            'Saving Earnings
                            Dim counter As Integer = 1
                            Dim k As Integer
                            Dim c1 As Integer

                            c1 = Me.Column_E1
                            For k = 0 To 14
                                If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
                                    Dim Lin As New cPrTxTrxnLines
                                    With Lin
                                        .TrxLin_Id = counter
                                        .TrxHdr_Id = Hdr.Id
                                        .TrxLin_Type = "E"
                                        .ErnCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
                                        .TrxLin_PeriodValue = 0
                                        .TrxLin_YTDValue = 0
                                        Try
                                            .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
                                        Catch
                                            MsgBox("Please Define Earnings for Employee :" & EmpCode)
                                            Throw Exx
                                        End Try
                                        .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
                                        If Not Lin.Save Then
                                            Throw Exx
                                        End If
                                    End With
                                    counter = counter + 1
                                End If
                                c1 = c1 + 2
                            Next
                            'Saving Deductions
                            c1 = Me.Column_D1
                            For k = 0 To 14
                                If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
                                    Dim Lin As New cPrTxTrxnLines
                                    With Lin
                                        .TrxLin_Id = counter
                                        .TrxHdr_Id = Hdr.Id
                                        .TrxLin_Type = "D"
                                        .DedCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
                                        .TrxLin_PeriodValue = 0
                                        .TrxLin_YTDValue = 0
                                        Try
                                            .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
                                        Catch
                                            MsgBox("Please Define Deductions for Employee :" & EmpCode)
                                            Throw Exx
                                        End Try
                                        .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
                                        If Not Lin.Save Then
                                            Throw Exx
                                        End If
                                    End With
                                    counter = counter + 1
                                End If
                                c1 = c1 + 2
                            Next

                            'Saving Contributions
                            c1 = Me.Column_C1
                            For k = 0 To 14
                                If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
                                    Dim Lin As New cPrTxTrxnLines
                                    With Lin
                                        .TrxLin_Id = counter
                                        .TrxHdr_Id = Hdr.Id
                                        .TrxLin_Type = "C"
                                        .ConCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
                                        .TrxLin_PeriodValue = 0
                                        .TrxLin_YTDValue = 0
                                        Try
                                            .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
                                        Catch
                                            MsgBox("Please Define Contributions for Employee :" & EmpCode)
                                            Throw Exx
                                        End Try
                                        .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
                                        If Not Lin.Save Then
                                            Throw Exx
                                        End If
                                    End With
                                    counter = counter + 1
                                End If
                                c1 = c1 + 2
                            Next

                            MyDs.Tables(0).Rows(i).Item(Me.Column_Status) = "PREP"
                            Saved = Saved + 1
                        End If
                    End If

                Next
                If Not RunFromTA Then
                    Global1.Business.CommitTransaction()
                End If
                If SaveOne Then
                    MsgBox("Payroll Values Are Saved with status Prepared for " & Saved & " Employees! ", MsgBoxStyle.Information)
                Else
                    MsgBox("System can only Save Lines with Status 'PREP' or '<  >'! ", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                If Not RunFromTA Then
                    Global1.Business.Rollback()
                End If
                Utils.ShowException(Exx)
            End Try

        End If
    End Sub
#Region "Actions"
    Private Sub TSBDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBDeleteSelected.Click
        DeleteSelectedLine()
    End Sub
    Private Sub DeleteSelectedLine()
        PasswordForDeletion = ""
        Cursor = Cursors.WaitCursor
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If
        If CheckDataSet(MyDs) Then
            Dim Delete As Boolean = False
            Dim i As Integer
            i = DG1.CurrentRow.Index
            Dim EmpCode As String
            Dim ss As Integer
            EmpCode = DG1.Item(2, i).Value
            For ss = 0 To MyDs.Tables(0).Rows.Count - 1
                If MyDs.Tables(0).Rows(ss).Item(2) = EmpCode Then
                    i = ss
                End If
            Next

            If MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled) = "1" Then

                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                If H.Id > 0 Then
                    If H.Status = "POST" Then
                        If H.InterfaceStatus = "OUTS" Then
                            Dim Ans As New MsgBoxResult
                            Ans = MsgBox("This Line status is POSTED, do you want to Proceed with Deletion", MsgBoxStyle.YesNoCancel)
                            If Ans = MsgBoxResult.Yes Then
                                Delete = True
                            End If
                        Else
                            Dim Ans As New MsgBoxResult
                            Ans = MsgBox("This Line status is POSTED, AND Interfaced !Please make all necessary corrections to ERP after deletion", MsgBoxStyle.YesNoCancel)
                            If Ans = MsgBoxResult.Yes Then
                                If PasswordForDeletion = "" Then
                                    Dim F As New FrmPasswordForDeletion
                                    F.Owner = Me
                                    F.myOwner = 1
                                    F.ShowDialog()
                                End If
                                If PasswordForDeletion = Format(Now.Date, "ddMMyyyy") Then
                                    Delete = True
                                Else
                                    MsgBox("Invalid Password, cannot proceed with Deletion !", MsgBoxStyle.Critical)
                                    Delete = False
                                End If
                            End If
                        End If
                    ElseIf H.Status = "CALC" Then
                        Dim Ans As MsgBoxResult
                        Ans = MsgBox("This Line status is CALCULATED, do you want to Proceed with Deletion", MsgBoxStyle.YesNoCancel)
                        If Ans = MsgBoxResult.Yes Then
                            Delete = True
                        End If
                    ElseIf H.Status = "PREP" Then
                        Dim Ans As MsgBoxResult
                        Ans = MsgBox("This Line status is PREPARED, do you want to Proceed with Deletion", MsgBoxStyle.YesNoCancel)
                        If Ans = MsgBoxResult.Yes Then
                            Delete = True
                        End If
                    End If
                    If Delete Then
                        Dim Exx As New Exception
                        Try
                            Global1.Business.BeginTransaction()
                            If Not Global1.Business.DeleteAllEDCFromTrxnLines(H.Id) Then
                                Throw Exx
                            End If
                            If Not Global1.Business.DeleteAllAnnualLeaveOfHeaderID(H.Id) Then
                                Throw Exx
                            End If
                            If Not Global1.Business.DeleteAllLoanLinesOfHeaderID(H.Id) Then
                                Throw Exx
                            End If
                            If Not Global1.Business.DeleteTrxnHeader(H.Id) Then
                                Throw Exx
                            End If
                            If Not Global1.Business.DeleteIR59(H.Id) Then
                                Throw Exx
                            End If



                            MsgBox("Line was succesfully Deleted")
                            Global1.Business.CommitTransaction()
                            MyDs.Tables(0).Rows(i).Delete()

                            Me.ArCalculations(i) = Nothing
                            Dim k As Integer
                            Dim CounterX As Integer = 0
                            ReDim TempAr(MyDs.Tables(0).Rows.Count - 1)
                            For k = 0 To ArCalculations.Length - 1
                                If Not ArCalculations(k) Is Nothing Then
                                    TempAr(CounterX) = ArCalculations(k)
                                    CounterX = CounterX + 1
                                End If
                            Next
                            ArCalculations = TempAr



                        Catch ex As Exception
                            Global1.Business.Rollback()
                        End Try
                    End If
                Else
                    MsgBox("Line is not checked as Selected")
                End If

            Else
                MsgBox("Line status is '<  >', Line is not Saved")
            End If
        End If
        RefreshCount()
        Cursor = Cursors.Default
    End Sub

    Private Sub TSBDeleteALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBDeleteALL.Click
        Cursor = Cursors.WaitCursor
        DeleteAll(False)
        RefreshCount()
        Cursor = Cursors.Default
    End Sub
    Private Sub DeleteALLLinesNOWarningsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteALLLinesNOWarningsToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        DeleteAll(True)
        RefreshCount()
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteAll(ByVal NoWarnings As Boolean)
        PasswordForDeletion = ""
        Dim counter As Integer = 0
        If CheckDataSet(MyDs) Then
            Dim j As Integer

            Dim Ar(MyDs.Tables(0).Rows.Count) As Integer
            For j = 0 To Ar.Length - 1
                Ar(j) = -1
            Next
            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If
            Dim ans1 As New MsgBoxResult
            ans1 = MsgBox("Do you Want to Delete All Selected Lines", MsgBoxStyle.YesNoCancel)
            If ans1 = MsgBoxResult.Yes Then
                Try
                    Global1.Business.BeginTransaction()

                    Dim Delete As Boolean = False
                    Dim i As Integer
                    Dim EmpCode As String
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        If MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled) = "1" Then
                            EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                            Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                            If H.Id > 0 Then
                                If H.Status = "POST" Then
                                    If H.InterfaceStatus = "OUTS" Then
                                        Dim Ans As New MsgBoxResult
                                        Ans = MsgBox("Line " & i + 1 & " Of Employee Code " & EmpCode & " status is POSTED, do you want to Proceed with Deletion", MsgBoxStyle.YesNoCancel)
                                        If Ans = MsgBoxResult.Yes Then
                                            Delete = True
                                        End If
                                    Else
                                        Dim DsHasFutureRecords As Boolean
                                        DsHasFutureRecords = Global1.Business.HasFutureRecords(EmpCode, H.Id)
                                        If DsHasFutureRecords Then
                                            MsgBox("Employee " & EmpCode & " Line cannot be deleted, Line has CALCULATED or POSTED Transactions in Future Periods", MsgBoxStyle.Information)
                                            Delete = False
                                        Else
                                            Dim Ans As New MsgBoxResult
                                            Ans = MsgBox("This Line status is POSTED, AND Interfaced !Please make all necessary corrections to ERP after deletion", MsgBoxStyle.YesNoCancel)
                                            If Ans = MsgBoxResult.Yes Then
                                                If PasswordForDeletion = "" Then
                                                    Dim F As New FrmPasswordForDeletion
                                                    F.Owner = Me
                                                    F.ShowDialog()
                                                End If
                                                If PasswordForDeletion = Format(Now.Date, "ddMMyyyy") Then
                                                    Delete = True
                                                Else
                                                    MsgBox("Invalid Password, cannot proceed with Deletion !", MsgBoxStyle.Critical)
                                                    Delete = False
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf H.Status = "CALC" Or H.Status = "PREP" Then
                                    If Not NoWarnings Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("Line " & i + 1 & " Of Employee Code " & EmpCode & " status is CALCULATED, do you want to Proceed with Deletion", MsgBoxStyle.YesNoCancel)
                                        If Ans = MsgBoxResult.Yes Then
                                            Delete = True
                                        End If
                                    Else
                                        Delete = True
                                    End If
                                End If
                                If Delete Then
                                    counter = counter + 1
                                    Dim Exx As New Exception

                                    If Not Global1.Business.DeleteAllEDCFromTrxnLines(H.Id) Then
                                        Throw Exx
                                    End If
                                    If Not Global1.Business.DeleteAllAnnualLeaveOfHeaderID(H.Id) Then
                                        Throw Exx
                                    End If
                                    If Not Global1.Business.DeleteAllLoanLinesOfHeaderID(H.Id) Then
                                        Throw Exx
                                    End If
                                    If Not Global1.Business.DeleteTrxnHeader(H.Id) Then
                                        Throw Exx
                                    End If
                                    If Not Global1.Business.DeleteIR59(H.Id) Then
                                        Throw Exx
                                    End If

                                    Ar(i) = i

                                End If

                            End If
                        End If
                    Next
                    Global1.Business.CommitTransaction()
                    Dim k As Integer
                    i = Ar.Length - 1
                    For k = 0 To Ar.Length - 1
                        If Ar(i - k) <> -1 Then
                            MyDs.Tables(0).Rows(Ar(i - k)).Delete()
                            Me.ArCalculations(Ar(i - k)) = Nothing
                        End If
                    Next

                    k = 0
                    Dim CounterX As Integer = 0
                    ReDim TempAr(MyDs.Tables(0).Rows.Count - 1)
                    For k = 0 To ArCalculations.Length - 1
                        If Not ArCalculations(k) Is Nothing Then
                            TempAr(CounterX) = ArCalculations(k)
                            CounterX = CounterX + 1
                        End If
                    Next
                    ArCalculations = TempAr

                    MsgBox(counter & " Lines was succesfully Deleted")
                Catch ex As Exception
                    Global1.Business.Rollback()
                End Try
            End If
        End If
    End Sub

    Private Sub TSBCalculateALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCalculateALL.Click
        DsNet.Tables(0).Rows.Clear()
        Cursor = Cursors.WaitCursor
        CalculateAll()

        Cursor = Cursors.Default
        If CheckDataSet(DsNet) Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("There are Employees with negative Net Amount, Do you want to see  a list of them ?", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                ShowExcelWithNegativeNets()
            End If
        End If
    End Sub
    Private Sub ShowExcelWithNegativeNets()
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader


        HeaderStr.Add("Code")
        HeaderStr.Add("Name")
        HeaderStr.Add("Net")

        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(10)


        Loader.LoadIntoExcel(DsNet, HeaderStr, HeaderSize)
    End Sub
    Private Sub CalculateAll()

        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim ans As New MsgBoxResult
            ans = MsgBox("Do you want to Calculate Payroll for All Selected Employees?", MsgBoxStyle.YesNoCancel)
            If ans = MsgBoxResult.Yes Then
                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                Dim EmpName As String = ""
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                    EmpName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpName))
                    If Status <> "POST" And Status <> "CALC" Then
                        If Selected = "1" Then
                            'Application.DoEvents()
                            Proceed = True
                            'Proceed = False
                            'If Status = "CALC" Then
                            '    ans = MsgBox("Recalculate Line " & i + 1 & " - Employee Code: " & EmpCode & " ?", MsgBoxStyle.YesNo)
                            '    If ans = MsgBoxResult.Yes Then
                            '        Proceed = True
                            '    End If
                            'Else
                            '    Proceed = True
                            'End If
                            If Proceed Then
                                LabelStatus.Text = "Calculating Payroll for Employee (" & (Saved + 1) & ") " & EmpCode & " - " & EmpName
                                Application.DoEvents()
                                Saved = Saved + 1
                                If Not LoadValuesFromGridToFormCalculations(i, 1) Then
                                    Saved = Saved - 1
                                End If
                            End If
                        End If
                    End If
                Next
                MsgBox(Saved & " Employees Payroll was Calculated")
            End If
        Else
            MsgBox("Please Select Employees First")
        End If
        LabelStatus.Text = ""
    End Sub
    Private Sub TSBSavePrepare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSavePrepare.Click
        Cursor = Cursors.WaitCursor
        Me.TryToSavePrepare()
        Cursor = Cursors.Default
    End Sub

    Private Sub TSBPostAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPostAll.Click
        PostAll()
    End Sub
    Private Sub PostAll()
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim ans As New MsgBoxResult
            ans = MsgBox("Do you want to POST all Calculated entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
            If ans = MsgBoxResult.Yes Then
                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                    If Status <> "POST" Then
                        If Selected = "1" Then
                            If Status = "CALC" Then
                                Proceed = True
                            Else
                                Proceed = False
                            End If
                            If Proceed Then
                                If CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).Post(True) Then
                                    MyDs.Tables(0).Rows(i).Item(Me.Column_Status) = "POST"
                                    Saved = Saved + 1
                                End If
                            End If
                        End If
                    End If
                Next
                If Saved > 0 Then
                    MsgBox(Saved & " Employees Payroll was POSTED")
                End If
            End If
        Else
            MsgBox("Please Select Employees First")
        End If
    End Sub
#End Region




#Region "Interface To Navision"

#End Region
    Private Sub MnuSendTransactionsToNavisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSendTransactionsToNavisionToolStripMenuItem.Click
        RunInterface(False)
    End Sub
    Public Sub RunInterface(ByVal Reverse As Boolean)
        If Global1.GLB_OneInterfaceFile Then
            Dim Str As String
            Dim i As Integer
            Dim ans As MsgBoxResult
            Str = "This Action will Create ONE Interface File for ALL Templates." & Chr(10) &
            " Please make sure that All Templates Entries are POSTED. Proceed?"
            ans = MsgBox(Str, MsgBoxStyle.YesNoCancel)
            If ans = MsgBoxResult.Yes Then

                Dim LastFile As Boolean = False
                Dim FirstFile As Boolean = False

                Dim F As New FrmTxInterfaceDate
                F.Owner = Me
                F.ShowDialog()

                Dim CompaniesTempGroups As DataSet
                CompaniesTempGroups = Global1.Business.GetcompanyTemplateGroup(GLBTempGroup.CompanyCode)
                Dim TemporaryGrp As New cPrMsTemplateGroup
                TemporaryGrp = GLBTempGroup
                GLFilecounter = 0
                PFFilecounter = 0
                For i = 0 To CompaniesTempGroups.Tables(0).Rows.Count - 1
                    If i = 0 Then
                        FirstFile = True
                    Else
                        FirstFile = False
                    End If
                    If i = CompaniesTempGroups.Tables(0).Rows.Count - 1 Then
                        LastFile = True
                    End If
                    Dim Batch As New cPrSsNavBatch
                    Dim TGrp As New cPrMsTemplateGroup
                    TGrp = New cPrMsTemplateGroup(DbNullToString(CompaniesTempGroups.Tables(0).Rows(i).Item(0)))
                    GLBTempGroup = TGrp
                    SendPaymentToNavisionAsOneFile(0, 0, False, Batch, LastFile, FirstFile, Reverse)

                Next
                If Me.InterfaceFileisOK Then

                    If Global1.GLBShowSAP Then
                        LoadInterfaceFileSAP(FnameToLoadforSAPOneFile, True, FnameToLoadforSAPOneFile)
                        MsgBox("SAP File is created", MsgBoxStyle.Information)
                    End If

                End If

                GLBTempGroup = TemporaryGrp


            End If
        Else
            Dim Batch As New cPrSsNavBatch
            SendPaymentToNavision(0, 0, False, Batch, True, False, False)
        End If
    End Sub
    Private Sub GetFTPParametersForTransfer(ByRef RemHost As String, ByRef RemPath As String, ByRef FileName As String, ByRef user As String, ByRef pwd As String, ByVal TemGrpCode As String)

        Dim i As Integer
        Dim Ds As DataSet
        Ds = Global1.Business.GetFTPParameters("O", "T", TemGrpCode)
        If CheckDataSet(Ds) Then
            With Ds.Tables(0).Rows(i)
                RemHost = DbNullToString(.Item(1))
                RemPath = DbNullToString(.Item(2))
                FileName = DbNullToString(.Item(3))
                user = DbNullToString(.Item(4))
                pwd = DbNullToString(.Item(5))
            End With
        End If
    End Sub
    Public Sub SendPaymentToNavisionAsOneFile(ByVal MinId As Integer, ByVal MaxId As Integer, ByVal FromHistory As Boolean, ByVal Batch As cPrSsNavBatch, ByVal LastFile As Boolean, ByVal FirstFile As Boolean, ByVal Reverse As Boolean)


        Dim RemHost As String = ""
        Dim RemPath As String = ""
        Dim FileName As String = ""
        Dim user As String = ""
        Dim pwd As String = ""
        Dim InterfaceType As String

        Dim FileWasCreated As Boolean = False
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("NAVOut", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            NAVOUTFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing Navision File Parameter Section 'NAVOut' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim FileDone As Boolean = False

        Dim FName As String
        ' Me.GetFTPParametersForTransfer(RemHost, RemPath, FileName, user, pwd, GLBTempGroup.Code)
        Ds = Global1.Business.GetParameter("System", "SAP")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowSAP = True
            Else
                Global1.GLBShowSAP = False
            End If
        Else
            Global1.GLBShowSAP = False
        End If

        If FirstFile Then
            Global1.Business.BeginTransaction()
        End If
        Me.Label7.Text = "Creating File in Progress . . ."
        Me.Label6.Text = "Start At: " & Format(Now, "dd-MM-yyyy hh:mm:ss")
        Me.PanelLoading.Visible = True
        Me.PanelLoading.Refresh()
        Me.Refresh()

        ' If Not CheckIfFileExistsOnNav(RemHost, RemPath, FName, user, pwd) Then
        Me.PanelLoading.Visible = True
        Me.PanelLoading.Refresh()
        Me.Refresh()

        Dim Ex As New System.Exception
        Dim DsMinMax As DataSet
        Dim Header As DataSet

        Dim PeriodCode As String
        PeriodCode = Me.txtPeriodCode.Text
        If Not FromHistory Then
            '            If MinId = 0 And MaxId = 0 Then
            DsMinMax = Global1.Business.GetMinAndMaxIDOfUnsendTrxns(GLBTempGroup)
            If CheckDataSet(DsMinMax) Then
                MinId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(0))
                MaxId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(1))
            End If
            'End If
        End If




        Dim NewInterface As Boolean = False
        Header = Global1.Business.GetPrTxTrxnHeader(MinId, MaxId, GLBTempGroup)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' If not Interface Setup
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If CheckDataSet(Header) Then
            Dim InterfaceCode As String
            Dim DsErnInt As DataSet
            Dim DsdedInt As DataSet
            Dim DsconInt As DataSet
            Dim Hdr As New cPrTxTrxnHeader
            Dim emp As New cPrMsEmployees
            Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(0))
            emp = New cPrMsEmployees(Hdr.Emp_Code)

            InterfaceCode = emp.InterfaceTemCode
            DsErnInt = Global1.Business.GetAllPrmsEarningsInterface(InterfaceCode)
            DsdedInt = Global1.Business.GetAllPrmsDeductionsInterface(InterfaceCode)
            DsconInt = Global1.Business.GetAllPrmsContributionsInterface(InterfaceCode)
            If Not CheckDataSet(DsErnInt) And Not CheckDataSet(DsErnInt) And Not CheckDataSet(DsErnInt) Then
                Dim Ans As New MsgBoxResult
                Ans = MsgBox("There is no Interface setup, Proceed with Posting of interface?", MsgBoxStyle.YesNoCancel)
                If Ans = MsgBoxResult.Yes Then
                    If Not Global1.Business.UpdateTrxnHeaderAsPosted(MinId, MaxId, GLBTempGroup, "POST") Then
                        Throw Ex
                    End If
                    ''
                    With Batch
                        .Id = 0
                        .IdFrom = MinId
                        .IdTo = MaxId
                        .TemGrpCode = GLBTempGroup.Code
                        .User = Global1.UserName
                        .FirstCreation = Now
                        .LastCreation = Now
                        .Times = 1
                    End With
                    If Not Batch.Save Then
                        Throw Ex
                    End If
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    Me.Refresh()
                    MsgBox("Posted as Interfaced Succesfully", MsgBoxStyle.Information)
                    Global1.Business.CommitTransaction()
                    Exit Sub
                Else
                    MsgBox("Please setup interface Template first", MsgBoxStyle.Critical)
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    Me.Refresh()
                    Exit Sub
                End If
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If Not interfacesetup Then
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''






        Dim DsPar As DataSet
        DsPar = Global1.Business.GetParameter("NAVOut", "NewInterface")
        If CheckDataSet(DsPar) Then
            Dim Par As New cPrSsParameters(DsPar.Tables(0).Rows(0))
            NewInterface = CBool(Par.Value1)
        End If
        Dim FNameToLoad As String
        If NewInterface Then
            Dim Times As Integer = 0
            If FromHistory Then
                Times = Batch.Times + 1
            End If
            Global1.IntefaceFileDone = False

            InterfaceType = "CL"
            If FirstFile Then
                FName = Me.GLBTempGroup.Code & "_" & InterfaceType & ".txt"
                OldName = FName
            Else
                FName = OldName
            End If
            FnameToLoadforSAPOneFile = FName
            PrepareInterface_NEW_OneFile(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, False, Times, False, FirstFile, False, Reverse)


            InterfaceType = "PF"
            If FirstFile Then
                FName = Me.GLBTempGroup.Code & "_" & InterfaceType & "_" & PeriodCode & ".txt"
                OldPFName = FName
            Else
                FName = OldPFName
            End If

            PrepareInterface_NEW_OneFile(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, LastFile, Times, IncludeEmployees, FirstFile, True, Reverse)

            'Else
            '    InterfaceType = "CHEQUES"
            '    FName = Me.GLBTempGroup.Code & "_" & InterfaceType & ".txt"
            '    PrepareChequesInterface(Header, FName, GLBTempGroup)

            '    InterfaceType = "CL"
            '    FName = Me.GLBTempGroup.Code & "_" & InterfaceType & ".txt"
            '    PrepareInterface(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, True)

        End If

    End Sub

    Public Sub SendPaymentToNavision(ByVal MinId As Integer, ByVal MaxId As Integer, ByVal FromHistory As Boolean, ByVal Batch As cPrSsNavBatch, ByVal firstFile As Boolean, ByVal NoFTP As Boolean, ByVal Reverse As Boolean)

        PanelLoading.Visible = True
        PanelLoading.BringToFront()
        Label7.Text = "Creating File in progress ..."
        Application.DoEvents()

        Me.InterfaceFileisOK = False
        Dim F As New FrmTxInterfaceDate
        Dim FnameToLoad As String
        F.Owner = Me
        F.ShowDialog()
        GLFilecounter = 0
        PFFilecounter = 0

        Dim RemHost As String = ""
        Dim RemPath As String = ""
        Dim FileName As String = ""
        Dim user As String = ""
        Dim pwd As String = ""
        Dim InterfaceType As String

        Dim FileWasCreated As Boolean = False
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("NAVOut", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            NAVOUTFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing Navision File Parameter Section 'NAVOut' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Ds = Global1.Business.GetParameter("NAVOut", "ShowIntReport")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowInterfaceReport = True
            Else
                Global1.GLBShowInterfaceReport = False
            End If
        Else
            Global1.GLBShowInterfaceReport = False
        End If
        Ds = Global1.Business.GetParameter("NAVOut", "ShowIntReportPF")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowInterfaceReportPF = True
            Else
                Global1.GLBShowInterfaceReportPF = False
            End If
        Else
            Global1.GLBShowInterfaceReportPF = False
        End If
        Ds = Global1.Business.GetParameter("System", "NetSuite")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowNetSuite = True
            Else
                Global1.GLBShowNetSuite = False
            End If
        Else
            Global1.GLBShowNetSuite = False
        End If


        Ds = Global1.Business.GetParameter("System", "SAP")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowSAP = True
            Else
                Global1.GLBShowSAP = False
            End If
        Else
            Global1.GLBShowSAP = False
        End If

        Ds = Global1.Business.GetParameter("System", "Esoft")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowEsoft = True
            Else
                Global1.GLBShowEsoft = False
            End If
        Else
            Global1.GLBShowEsoft = False
        End If
        Ds = Global1.Business.GetParameter("System", "SoftOne")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowSoftOne = True
            Else
                Global1.GLBShowSoftOne = False
            End If
        Else
            Global1.GLBShowSoftOne = False
        End If



        Ds = Global1.Business.GetParameter("NAVOut", "TAInterface")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.PARAM_TimeAttendanceInterface = True
            Else
                Global1.PARAM_TimeAttendanceInterface = False
            End If
        Else
            Global1.PARAM_TimeAttendanceInterface = False
        End If


        Dim FileDone As Boolean = False

        Dim FName As String
        ' Me.GetFTPParametersForTransfer(RemHost, RemPath, FileName, user, pwd, GLBTempGroup.Code)


        Global1.Business.BeginTransaction()
        Me.Label7.Text = "Creating File in Progress . . ."
        Me.Label6.Text = "Start At: " & Format(Now, "dd-MM-yyyy hh:mm:ss")
        Me.PanelLoading.Visible = True
        Me.PanelLoading.BringToFront()
        Me.PanelLoading.Refresh()
        Application.DoEvents()
        Me.Refresh()

        ' If Not CheckIfFileExistsOnNav(RemHost, RemPath, FName, user, pwd) Then
        Me.PanelLoading.Visible = True
        Me.PanelLoading.Refresh()
        Me.Refresh()

        Dim Ex As New System.Exception
        Dim DsMinMax As DataSet
        Dim Header As DataSet

        Dim PeriodCode As String
        PeriodCode = Me.txtPeriodCode.Text
        If MinId = 0 And MaxId = 0 Then
            DsMinMax = Global1.Business.GetMinAndMaxIDOfUnsendTrxns(GLBTempGroup)
            If CheckDataSet(DsMinMax) Then
                MinId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(0))
                MaxId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(1))
                Label12.Text = "MinID " & MinId & "MaxID " & MaxId
            End If
        End If

        Dim NewInterface As Boolean = False
        Header = Global1.Business.GetPrTxTrxnHeader(MinId, MaxId, GLBTempGroup)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' If not Interface Setup
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If CheckDataSet(Header) Then
            Dim InterfaceCode As String
            Dim DsErnInt As DataSet
            Dim DsdedInt As DataSet
            Dim DsconInt As DataSet
            Dim Hdr As New cPrTxTrxnHeader
            Dim emp As New cPrMsEmployees
            Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(0))
            emp = New cPrMsEmployees(Hdr.Emp_Code)

            InterfaceCode = emp.InterfaceTemCode
            DsErnInt = Global1.Business.GetAllPrmsEarningsInterface(InterfaceCode)
            DsdedInt = Global1.Business.GetAllPrmsDeductionsInterface(InterfaceCode)
            DsconInt = Global1.Business.GetAllPrmsContributionsInterface(InterfaceCode)
            If Not CheckDataSet(DsErnInt) And Not CheckDataSet(DsErnInt) And Not CheckDataSet(DsErnInt) Then
                Dim Ans As New MsgBoxResult
                Ans = MsgBox("There is no Interface setup, Proceed with Posting of interface?", MsgBoxStyle.YesNoCancel)
                If Ans = MsgBoxResult.Yes Then
                    If Not Global1.Business.UpdateTrxnHeaderAsPosted(MinId, MaxId, GLBTempGroup, "POST") Then
                        Throw Ex
                    End If
                    ''
                    With Batch
                        .Id = 0
                        .IdFrom = MinId
                        .IdTo = MaxId
                        .TemGrpCode = GLBTempGroup.Code
                        .User = Global1.UserName
                        .FirstCreation = Now
                        .LastCreation = Now
                        .Times = 1
                    End With
                    If Not Batch.Save Then
                        Throw Ex
                    End If
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    Me.Refresh()
                    MsgBox("Posted as Interfaced Succesfully", MsgBoxStyle.Information)
                    Global1.Business.CommitTransaction()
                    Exit Sub
                Else
                    MsgBox("Please setup interface Template first", MsgBoxStyle.Critical)
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    Me.Refresh()
                    Exit Sub
                End If


            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If Not interfacesetup Then
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim DsPar As DataSet
        DsPar = Global1.Business.GetParameter("NAVOut", "NewInterface")
        If CheckDataSet(DsPar) Then
            Dim Par As New cPrSsParameters(DsPar.Tables(0).Rows(0))
            NewInterface = CBool(Par.Value1)
        End If

        If NewInterface Then
            Dim Times As Integer = 0
            If FromHistory Then
                Times = Batch.Times + 1
            End If
            Global1.IntefaceFileDone = False

            InterfaceType = "CL"
            FName = Me.GLBTempGroup.Code & "_" & InterfaceType & ".txt"
            FnameToLoad = FName
            If Not Global1.PARAM_TimeAttendanceInterface Then
                PrepareInterface_NEW(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, False, Times, False, firstFile, Reverse)
                Label12.Text = "NEW "
            Else
                PrepareInterface_NEW_TA(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, False, Times, False, firstFile, Reverse)
                Label12.Text = "NEW TA"
            End If

            If Global1.GlbNoTransactions Then
                GC.Collect()
                PanelLoading.Visible = False
                Label7.Text = "Loading File in Progress ..."
                Application.DoEvents()
                Global1.Business.CommitTransaction()
                Exit Sub

            End If

            InterfaceType = "PF"
            FName = Me.GLBTempGroup.Code & "_" & InterfaceType & "_" & PeriodCode & ".txt"
            Dim LastFile As Boolean
            LastFile = True
            If Global1.GLBGenerateFromMKT_To_IMK Then
                If GLBGenerateFromMKT_To_IMK_TemplateCode = GLBTempGroup.Code Then
                    LastFile = False
                End If
            End If
            PrepareInterface_NEW(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, LastFile, Times, IncludeEmployees, firstFile, Reverse)

            If Global1.GLBDedtorsInterface Then
                If Global1.GLBTemplateforDCInterface = GLBTempGroup.Code Then
                    Me.PrepareInterface_Dedtors(Header, MinId, MaxId, FromHistory, DedtorsFile, Batch, NavisionPostingdate)
                    MsgBox("Debtors Files , " & DedtorsFile & " is Created", MsgBoxStyle.Information)
                    LoadInterfaceFileDC(DedtorsFile, False)
                End If
            End If
            If Global1.GLBCreditorsInterface Then
                If Global1.GLBTemplateforDCInterface = GLBTempGroup.Code Then
                    Me.PrepareInterface_Creditors(Header, MinId, MaxId, FromHistory, CreditorsFile, Batch, NavisionPostingdate)
                    MsgBox("Creditors Files , " & CreditorsFile & " is Created", MsgBoxStyle.Information)
                    LoadInterfaceFileDC(CreditorsFile, False)
                End If
            End If
            'DebtorsFileForMKT

            If Global1.GLBDedtorsInterface Then
                If Global1.GLBTemplateforDCInterface2 = GLBTempGroup.Code Then
                    Me.PrepareInterface_Dedtors(Header, MinId, MaxId, FromHistory, DedtorsFile, Batch, NavisionPostingdate)
                    MsgBox("Debtors Files , " & DedtorsFile & " is Created", MsgBoxStyle.Information)
                    LoadInterfaceFileDC(DedtorsFile, False)
                End If
            End If
            If Global1.GLBCreditorsInterface Then
                If Global1.GLBTemplateforDCInterface2 = GLBTempGroup.Code Then
                    Me.PrepareInterface_Creditors(Header, MinId, MaxId, FromHistory, CreditorsFile, Batch, NavisionPostingdate)
                    MsgBox("Creditors Files , " & CreditorsFile & " is Created", MsgBoxStyle.Information)
                    LoadInterfaceFileDC(CreditorsFile, False)
                End If
            End If

            'End of Debtors/Creditors File For MKT

            Dim FNameToLoad3 As String = "mkttoimk.txt"
            If Global1.GLBGenerateFromMKT_To_IMK Then
                If GLBGenerateFromMKT_To_IMK_TemplateCode = GLBTempGroup.Code Then
                    InterfaceType = "MD"
                    PrepareInterface_NEW(Header, MinId, MaxId, FromHistory, FNameToLoad3, Batch, InterfaceType, True, Times, IncludeEmployees, firstFile, Reverse)
                End If
            End If


            Dim FNAmeToLoad2 = FName

            If Me.InterfaceFileisOK Then
                If Global1.GLBShowInterfaceReport Then
                    LoadInterfaceFile(FnameToLoad, True)
                End If
                If Global1.GLBShowInterfaceReportPF Then
                    LoadInterfaceFile(FNAmeToLoad2, True)
                End If
                If Global1.GLBShowNetSuite Then
                    LoadInterfaceFileNetSuite(FnameToLoad, True)
                    MsgBox("NetSuite File is created", MsgBoxStyle.Information)
                End If
                If Global1.GLBShowSAP Then
                    LoadInterfaceFileSAP(FnameToLoad, True, FnameToLoad)
                    MsgBox("SAP File is created", MsgBoxStyle.Information)
                End If
                If Global1.GLBShowEsoft Then
                    LoadInterfaceFileEsoft(FnameToLoad, True, FnameToLoad, PeriodCode)
                    MsgBox("ESOFT File is created", MsgBoxStyle.Information)
                End If
                If Global1.GLBShowSoftOne Then
                    LoadInterfaceFileSoftOne(FnameToLoad, True)
                    MsgBox("SoftOne File is created", MsgBoxStyle.Information)
                End If
            End If


            If Global1.PARAM_FTPToNodal Then
                If Not NoFTP Then
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()
                    SendFileToNodal(NAVOUTFileDir, FnameToLoad)
                    Application.DoEvents()
                    SendFileToNodal(NAVOUTFileDir, FNAmeToLoad2)
                    'If Global1.GLBDedtorsInterface Then
                    '    ' SendFileToNodal(NAVOUTFileDir, DedtorsFile)
                    'End If
                    'If Global1.GLBCreditorsInterface Then
                    '    ' SendFileToNodal(NAVOUTFileDir, CreditorsFile)
                    'End If
                    If Global1.GLBGenerateFromMKT_To_IMK Then
                        If GLBGenerateFromMKT_To_IMK_TemplateCode = GLBTempGroup.Code Then
                            SendFileToNodal(NAVOUTFileDir, FNameToLoad3)
                        End If
                    End If
                End If


                Cursor.Current = Cursors.Default

            End If


        Else
            InterfaceType = "CHEQUES"
            FName = Me.GLBTempGroup.Code & "_" & InterfaceType & ".txt"
            PrepareChequesInterface(Header, FName, GLBTempGroup)

            InterfaceType = "CL"
            FName = Me.GLBTempGroup.Code & "_" & InterfaceType & ".txt"
            PrepareInterface(Header, MinId, MaxId, FromHistory, FName, Batch, InterfaceType, True)
            If Me.InterfaceFileisOK Then
                If Global1.GLBShowInterfaceReport Then
                    LoadInterfaceFile(FName, False)
                End If
                If Global1.GLBShowNetSuite Then
                    LoadInterfaceFileNetSuite(FName, False)
                End If


            End If

        End If
        GC.Collect()
        PanelLoading.Visible = False
        Label7.Text = "Loading File in Progress ..."
        Application.DoEvents()
    End Sub
    Private Sub SendFileToNodal(ByVal FullPath As String, ByVal FileName As String)
        Application.DoEvents()
        Dim NodalRemHost As String = ""
        Dim NodalRemPath As String = ""

        Dim Nodaluser As String = ""
        Dim Nodalpwd As String = ""

        Dim ds As DataSet
        ds = Global1.Business.GetParameter("Nodal", "RemHost")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            NodalRemHost = Par.Value1
        Else
            MsgBox("Please Define 'Nodal','RemHost' parameter", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ds = Global1.Business.GetParameter("Nodal", "RemPath")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            NodalRemPath = Par.Value1
        Else
            MsgBox("Please Define 'Nodal','RemPath' parameter", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ds = Global1.Business.GetParameter("Nodal", "user")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            Nodaluser = Par.Value1
        Else
            MsgBox("Please Define 'Nodal','user' parameter", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ds = Global1.Business.GetParameter("Nodal", "pwd")
        If CheckDataSet(ds) Then
            Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
            Nodalpwd = Par.Value1
        Else
            MsgBox("Please Define 'Nodal','pwd' parameter", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Application.DoEvents()
        Dim FileWasCreated As Boolean = False
        Dim p As Integer

        Try
            Application.DoEvents()

            Me.Label7.Text = "Sending File " & FileName & " to Nodal . . ."
            Me.PanelLoading.Visible = True
            Application.DoEvents()
            Me.PanelLoading.BringToFront()
            Application.DoEvents()
            Me.PanelLoading.Refresh()
            Me.Refresh()


            If Not CheckIfFileExistsOnNodal(NodalRemHost, NodalRemPath, FileName, Nodaluser, Nodalpwd) Then
                Application.DoEvents()
                If FTP.Transfer(NodalRemHost, NodalRemPath, Nodaluser, Nodalpwd, 21, FullPath & FileName) Then
                    If Global1.ShowMessages Then
                        MsgBox(FileName & " - File FTP successfuly", MsgBoxStyle.Information)
                    Else
                        MsgBox(FileName & " - File FTP successfuly", MsgBoxStyle.Information)
                    End If
                End If
            End If
            Application.DoEvents()
            Me.PanelLoading.Visible = False
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
        Me.Label7.Text = "Loading File in Progress ..."
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Function CheckIfFileExistsOnNodal(ByVal nodalRemHost, ByVal nodalRemPath, ByVal FileName1, ByVal nodaluser, ByVal nodalpwd)
        Dim Flag As Boolean = False
        Dim Msg As String = "File  '" & FileName1 & "'  Already Exists on Nodal ( " & nodalRemPath & " )! Cannot Proceed with Creation Of File!"
        Flag = FTP.CheckIfFileExists(nodalRemHost, nodalRemPath, nodaluser, nodalpwd, 21, FileName1)
        If Flag Then
            Me.PanelLoading.Visible = False
            Me.PanelLoading.Refresh()
            Me.Refresh()
            If Global1.ShowMessages Then
                MsgBox(Msg, MsgBoxStyle.Information)
            Else
                MsgBox(Msg, "Creating File")
            End If
        End If
        Return Flag
    End Function
    Private Sub LoadInterfaceFileNetSuite(ByVal Filename As String, ByVal newTemp As Boolean)
        Filename = NAVOUTFileDir & Filename
        Dim F As New FrmShowInterfaceFormNetSuite
        F.NewInterface = newTemp
        F.FileName = Filename
        F.ShowDialog()
    End Sub
    Private Sub LoadInterfaceFileSoftOne(ByVal Filename As String, ByVal newTemp As Boolean)
        Filename = NAVOUTFileDir & Filename
        Dim F As New FrmShowInterfaceFormSoftOne
        F.NewInterface = newTemp
        F.FileName = Filename
        F.ShowDialog()
    End Sub
    Private Sub LoadInterfaceFileSAP(ByVal Filename As String, ByVal newTemp As Boolean, ByVal ReadFrom As String)

        InitFileSAP = True

        Dim Company As New cAdMsCompany(Me.GLBTempGroup.CompanyCode.ToString)
        Filename = "SAP_" & Company.NameShort
        Dim Line As String


        Dim c1 As String = "PAYMENT DATE"
        Dim c2 As String = "Accounting System Code"
        Dim c3 As String = "Accounting System Name"
        Dim c4 As String = "Check Number "
        Dim c5 As String = "Credit"
        Dim c6 As String = "Debit"
        Dim c7 As String = "Project Code"
        Dim c8 As String = "Costing Code"
        Dim c9 As String = "Details Costing Code 2"
        Dim c10 As String = "Costing Name 2"
        Dim c11 As String = "Employee Name"
        Dim c12 As String = "Customer Name"
        Dim c13 As String = "Hours"
        Dim Header As String
        Dim Del1 As String = Chr(9)
        Header = c1 & Del1
        Header = Header & c2 & Del1
        Header = Header & c3 & Del1
        Header = Header & c4 & Del1
        Header = Header & c5 & Del1
        Header = Header & c6 & Del1
        Header = Header & c7 & Del1
        Header = Header & c8 & Del1
        Header = Header & c9 & Del1
        Header = Header & c10 & Del1
        Header = Header & c11 & Del1
        Header = Header & c12 & Del1
        Header = Header & c13 & Del1

        WriteTo_SAP_File(Header, Filename)

        Dim Exx As New Exception
        Dim HeaderLine As String
        Dim param_file As IO.StreamReader
        ReadFrom = NAVOUTFileDir & ReadFrom
        param_file = IO.File.OpenText(ReadFrom)

        Dim Ar() As String
        Dim Amount As Double
        Dim Accountcode As String
        Dim Description As String
        Dim analysis As String
        Dim Counter As Integer
        Dim MyDate As String
        Dim Total As Double = 0
        Dim Debit As Double = 0
        Dim Credit As Double = 0
        Dim comment As String = ""
        Dim analysis3 As String = ""

        Dim c1_PayDate As String
        Dim c2_AccountCode As String
        Dim c3_AccountSystem As String
        Dim c4_ChechNo As String
        Dim c5_Debit As String
        Dim c6_Credit As String
        Dim c7_ProjectCode As String
        Dim c8_CostingDetails As String
        Dim c9_CostingCode2 As String
        Dim c10_CostingName2 As String
        Dim c11_EmployeeName As String
        Dim c12_CustomerName As String
        Dim c13_Hours As String

        Dim L As String

        Do While param_file.Peek <> -1
            Counter = Counter + 1
            System.Windows.Forms.Application.DoEvents()
            Line = param_file.ReadLine()
            Ar = Line.Split("|||")

            Accountcode = Ar(27)
            Amount = Ar(51)
            Description = Ar(60)
            analysis = Ar(72)
            MyDate = Ar(9)
            comment = (Ar(36))
            analysis3 = Ar(75)
            Dim Arr() As String
            Arr = MyDate.Split("-")

            c1_PayDate = Arr(2) & Arr(1) & Arr(0)
            c2_AccountCode = Accountcode
            c3_AccountSystem = ""
            c4_ChechNo = ""
            If Amount < 0 Then
                c5_Debit = "0.00"
                c6_Credit = Format(Math.Abs(Amount), "0.00")
            ElseIf Amount > 0 Then
                c5_Debit = Format(Amount, "0.00")
                c6_Credit = "0.00"
            Else
                c5_Debit = "0.00"
                c6_Credit = "0.00"
            End If

            c7_ProjectCode = ""
            c8_CostingDetails = ""
            c9_CostingCode2 = Description
            c10_CostingName2 = ""
            c11_EmployeeName = ""
            c12_CustomerName = ""
            c13_Hours = ""

            L = ""
            L = L + c1_PayDate & Del1
            L = L + c2_AccountCode & Del1
            L = L + c3_AccountSystem & Del1
            L = L + c4_ChechNo & Del1
            L = L + c5_Debit & Del1
            L = L + c6_Credit & Del1
            L = L + c7_ProjectCode & Del1
            L = L + c8_CostingDetails & Del1
            L = L + c9_CostingCode2 & Del1
            L = L + c10_CostingName2 & Del1
            L = L + c11_EmployeeName & Del1
            L = L + c12_CustomerName & Del1
            L = L + c13_Hours & Del1

            WriteTo_SAP_File(L, Filename)

        Loop


    End Sub
    Private Function WriteTo_SAP_File(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = NAVOUTFileDir & fName
            Dim TW As System.IO.TextWriter

            If InitFileSAP Then
                TW = System.IO.File.CreateText(FileName)
                InitFileSAP = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
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

    Private Sub LoadInterfaceFile(ByVal Filename As String, ByVal newTemp As Boolean)
        Filename = NAVOUTFileDir & Filename
        Dim F As New FrmShowInterfaceForm
        F.NewInterface = newTemp
        F.FileName = Filename
        F.DC = False
        F.ShowDialog()
    End Sub
    Private Sub LoadInterfaceFileDC(ByVal Filename As String, ByVal newTemp As Boolean)
        Filename = NAVOUTFileDir & Filename
        Dim F As New FrmShowInterfaceForm
        F.NewInterface = newTemp
        F.FileName = Filename
        F.DC = True
        F.ShowDialog()
    End Sub
    Private Sub PrepareChequesInterface(ByVal Header As DataSet, ByVal FName As String, ByVal TempGroup As cPrMsTemplateGroup)

        Dim i As Integer
        Dim Str As String

        Dim PrdGrpCode_2 As String
        Dim PrdCodCode_3 As String
        Dim NetSalary_27 As Double
        Dim ChequeNo_16 As String
        Dim III As String = "|||"
        Dim AccNo As String
        Dim AccNoType As String
        Dim BalAccNo As String
        Dim BalAccNoType As String
        Dim Per As New cPrMsPeriodCodes
        Dim PostingNoSeries As String

        Dim Company As New cAdMsCompany(TempGroup.CompanyCode)

        AccNo = Company.TSAccount
        AccNoType = Company.TSAccountType
        BalAccNo = Company.TSBalAccount
        BalAccNoType = Company.TSBalAccountType
        'PostingNoSeries = Company.GLAnal3


        If CheckDataSet(Header) Then
            For i = 0 To Header.Tables(0).Rows.Count - 1
                PrdGrpCode_2 = DbNullToString(Header.Tables(0).Rows(i).Item(2))
                PrdCodCode_3 = DbNullToString(Header.Tables(0).Rows(i).Item(3))
                If i = 0 Then
                    Per = New cPrMsPeriodCodes(PrdCodCode_3, PrdGrpCode_2)
                End If

                NetSalary_27 = DbNullToDouble(Header.Tables(0).Rows(i).Item(27))
                ChequeNo_16 = DbNullToString(Header.Tables(0).Rows(i).Item(16))
                'Jornal Template
                Str = ClearChars((TempGroup.GLAnl1))
                'Bach
                Str = Str & III & ClearChars(Company.GLAnal3)
                'Line No
                Str = Str & III & i + 1
                'Posting Date
                Str = Str & III & Format(NavisionPostingdate.Date, "dd/MM/yyyy")
                'Doc/Ref Date
                Str = Str & III & Format(NavisionPostingdate.Date, "dd/MM/yyyy")
                'Document Type
                Str = Str & III & "0"
                'Reason Code
                Str = Str & III & ""
                'Posting No Series
                Str = Str & III & ""
                'Account Type
                Str = Str & III & AccNoType
                'Account No
                Str = Str & III & AccNo
                'Sell to /Buy From
                Str = Str & III & ""
                'Due Date
                Str = Str & III & Format(NavisionPostingdate.Date, "dd/MM/yyyy")
                'Document No
                Str = Str & III & ChequeNo_16
                'External Doc No
                Str = Str & III & "PAY-" & Per.Code
                'Salespers/Purc Code
                Str = Str & III & ""
                'Currency
                Str = Str & III & ""
                'VAT Prod. Posting Group
                Str = Str & III & ""
                'Amount LCY
                Str = Str & III & Format(NetSalary_27, "0.00")
                'AMount
                Str = Str & III & Format(NetSalary_27, "0.00")
                'VAT Amount
                Str = Str & III & "0"
                'Description
                Str = Str & III & "PAY-" & Per.Code
                'Balancing Acc Type
                Str = Str & III & BalAccNoType
                'Balancing Account
                Str = Str & III & BalAccNo
                'PaymentType
                Str = Str & III & "2"

                WriteToNavisionFile(Str, FName)
                System.Windows.Forms.Application.DoEvents()
            Next
        End If



    End Sub
    Private Sub PrepareInterface(ByVal Header As DataSet, ByVal MinId As Integer, ByVal MaxID As Integer, ByVal FromHistory As Boolean, ByVal FName As String, ByVal Batch As cPrSsNavBatch, ByVal InterfaceType As String, ByVal LastFile As Boolean)
        Dim Exx As New Exception
        Dim FileDone As Boolean
        Dim FileWasCreated As Boolean
        Dim Lines As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim Hdr As New cPrTxTrxnHeader
        'Dim DsDetails2 As DataSet
        Dim Lin As New cPrTxTrxnLines
        Dim Period As New cPrMsPeriodCodes
        Dim LineCounter As Integer = 1
        Dim Emp As cPrMsEmployees
        Dim DsErnInt As DataSet
        Dim DsDedInt As DataSet
        Dim DsConInt As DataSet
        Dim InterfaceCode As String = ""

        Dim ErnInt As New cPrMsEarningsInterface
        Dim DedInt As New cPrMsDeductionsInterface
        Dim ConInt As New cPrMsContributionsInterface

        Dim j As Integer
        Try
            If Not Global1.Business.DeleteAllFromTempInterface(GLBTempGroup.Code) Then
                Throw Exx
            End If

            If CheckDataSet(Header) Then
                For i = 0 To Header.Tables(0).Rows.Count - 1
                    Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                    Emp = New cPrMsEmployees(Hdr.Emp_Code)
                    Select Case InterfaceType
                        Case "CL" 'Control Account
                            InterfaceCode = Emp.InterfaceTemCode
                        Case "PF" 'Provident Fund
                            InterfaceCode = Emp.InterfacePFCode
                        Case "MF" 'Medical Fund
                            InterfaceCode = Emp.InterfaceMFCode

                    End Select

                    DsErnInt = Global1.Business.GetAllPrmsEarningsInterface(InterfaceCode)
                    DsDedInt = Global1.Business.GetAllPrmsDeductionsInterface(InterfaceCode)
                    DsConInt = Global1.Business.GetAllPrmsContributionsInterface(InterfaceCode)

                    'DsDetails = Global1.Business.GetDetailsForNavInterface(Hdr)

                    Lines = Global1.Business.GetPrTxTrxnLinesOfHeaderID(Hdr.Id)
                    Period = New cPrMsPeriodCodes(Hdr.PrdCod_Code, Hdr.PrdGrp_Code)
                    If CheckDataSet(Lines) Then
                        For k = 0 To Lines.Tables(0).Rows.Count - 1
                            Lin = New cPrTxTrxnLines(Lines.Tables(0).Rows(k))
                            If Lin.TrxLin_Type = "E" Then
                                For j = 0 To DsErnInt.Tables(0).Rows.Count - 1
                                    ErnInt = New cPrMsEarningsInterface(DsErnInt.Tables(0).Rows(j))
                                    If ErnInt.ErnCode = Lin.ErnCod_Code Then
                                        UpdateTempEARNINGS(Emp, Lin, ErnInt, Hdr, False, "")
                                    End If
                                Next
                            ElseIf Lin.TrxLin_Type = "D" Then
                                For j = 0 To DsDedInt.Tables(0).Rows.Count - 1
                                    DedInt = New cPrMsDeductionsInterface(DsDedInt.Tables(0).Rows(j))
                                    If DedInt.DedCode = Lin.DedCod_Code Then
                                        UpdateTempDEDUCTIONS(Emp, Lin, DedInt, Hdr, "")
                                    End If
                                Next
                            ElseIf Lin.TrxLin_Type = "C" Then
                                For j = 0 To DsConInt.Tables(0).Rows.Count - 1
                                    ConInt = New cPrMsContributionsInterface(DsConInt.Tables(0).Rows(j))
                                    If ConInt.ConCode = Lin.ConCod_Code Then
                                        UpdateTempCONTRIBUTIONS(Emp, Lin, ConInt, Hdr, "")
                                    End If
                                Next
                            End If

                            'Send_WriteToNavFile(Hdr, Lin, DsDetails, GLBTempGroup, LineCounter, Period, FName)

                            FileWasCreated = True
                        Next
                    End If
                Next
                If FileWasCreated Then
                    If Send_WriteToNavFile(GLBTempGroup, Period, FName, InterfaceType) Then
                        FileDone = True
                    End If
                End If
            Else
                MsgBox("There are no Payroll Transactions To Send,Please Check Interface History", MsgBoxStyle.Information)
                Global1.Business.CommitTransaction()
            End If
            'End If
            If FileDone Then
                If Not Global1.Business.UpdateTrxnHeaderAsPosted(MinId, MaxID, GLBTempGroup, "POST") Then
                    Throw Exx
                End If
            End If


            If FileDone Then
                If LastFile Then

                    Me.Label7.Text = " "
                    Me.Label6.Text = " "
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    If FromHistory Then
                        With Batch
                            .User = Global1.UserName
                            .LastCreation = Now
                            .Times = .Times + 1
                        End With
                    Else
                        With Batch
                            .Id = 0
                            .IdFrom = MinId
                            .IdTo = MaxID
                            .TemGrpCode = GLBTempGroup.Code
                            .User = Global1.UserName
                            .FirstCreation = Now
                            .LastCreation = Now
                            .Times = 1
                        End With
                    End If
                    If Not Batch.Save Then
                        Throw Exx
                    End If

                    MsgBox("Succesfull File Creation", MsgBoxStyle.Information)
                    InterfaceFileisOK = True
                End If
                Global1.Business.CommitTransaction()
            Else
                MsgBox("No File Creation.Please Check EDC Interface", MsgBoxStyle.Critical)
            End If


            If FileWasCreated Then
                'Me.Label7.Text = "FTP File to Navision ..."
                'Me.PanelLoading.Visible = True
                'System.Windows.Forms.Application.DoEvents()
                'If FTP.Transfer(RemHost, RemPath, user, pwd, 21, Path & FName) Then
                '    MsgBox("File FTP successfuly", MsgBoxStyle.Information)
                'End If
            End If

        Catch ex As Exception
            MsgBox("Unable to Create File", MsgBoxStyle.Critical)
            Global1.Business.Rollback()
            FileWasCreated = False
            Utils.ShowException(ex)
        End Try
        Me.PanelLoading.Visible = False
        InitFile = True
    End Sub
    Private Sub PrepareInterface_NEW_OneFile(ByVal Header As DataSet, ByVal MinId As Integer, ByVal MaxID As Integer, ByVal FromHistory As Boolean, ByVal FName As String, ByVal Batch As cPrSsNavBatch, ByVal InterfaceType As String, ByVal LastFile As Boolean, ByVal Times As Integer, ByVal IncludeEmployeesInFile As Boolean, ByVal FirstFile As Boolean, ByVal LastOfTemp As Boolean, ByVal Reverse As Boolean)
        Me.InterfaceFileisOK = False
        Dim Exx As New Exception
        Dim FileDone As Boolean
        Dim FileWasCreated As Boolean
        Dim Lines As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim Hdr As New cPrTxTrxnHeader
        Dim DsDetails As DataSet
        Dim Lin As New cPrTxTrxnLines
        Dim Period As New cPrMsPeriodCodes
        Dim LineCounter As Integer = 1
        Dim Emp As cPrMsEmployees
        Dim DsErnInt As DataSet
        Dim DsDedInt As DataSet
        Dim DsConInt As DataSet
        Dim InterfaceCode As String = ""

        Dim ErnInt As New cPrMsEarningsInterface
        Dim DedInt As New cPrMsDeductionsInterface
        Dim ConInt As New cPrMsContributionsInterface
        Dim PReasonGL As New cPrSsParameters
        Dim PReasonLN As New cPrSsParameters
        Dim PRExtraPrefix As New cPrSsParameters
        Dim ExtraPrefix As String = ""

        Dim DsPar As DataSet
        DsPar = Global1.Business.GetParameter("PF", "GLReason")
        If CheckDataSet(DsPar) Then
            PReasonGL = New cPrSsParameters(DsPar.Tables(0).Rows(0))
        Else
            MsgBox("Please Define Parameter Section 'PF' Item 'GLReason'", MsgBoxStyle.Critical)
            Throw Exx
        End If
        DsPar = Global1.Business.GetParameter("PF", "LoanReason")
        If CheckDataSet(DsPar) Then
            PReasonLN = New cPrSsParameters(DsPar.Tables(0).Rows(0))
        Else
            MsgBox("Please Define Parameter Section 'PF' Item 'LoanReason'", MsgBoxStyle.Critical)
            Throw Exx
        End If

        DsPar = Global1.Business.GetParameter("Interface", "ExtraPrefix")
        If CheckDataSet(DsPar) Then
            PRExtraPrefix = New cPrSsParameters(DsPar.Tables(0).Rows(0))
            ExtraPrefix = PRExtraPrefix.Value1
        Else
            If Global1.PARAM_TempOnInt Then
                ExtraPrefix = GLBTempGroup.Code
            End If
        End If
        DsPar = Global1.Business.GetParameter("System", "SAP")
        If CheckDataSet(DsPar) Then
            Dim Par As New cPrSsParameters(DsPar.Tables(0).Rows(0))
            If Par.Value1 Then
                Global1.GLBShowSAP = True
            Else
                Global1.GLBShowSAP = False
            End If
        Else
            Global1.GLBShowSAP = False
        End If


        Dim j As Integer
        Try
            If Not Global1.Business.DeleteAllFromTempInterface(GLBTempGroup.Code) Then
                Throw Exx
            End If

            If CheckDataSet(Header) Then
                For i = 0 To Header.Tables(0).Rows.Count - 1
                    Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                    Emp = New cPrMsEmployees(Hdr.Emp_Code)
                    Select Case InterfaceType
                        Case "CL" 'Control Account
                            InterfaceCode = Emp.InterfaceTemCode
                        Case "PF" 'Provident Fund
                            InterfaceCode = Emp.InterfacePFCode
                        Case "MF" 'Medical Fund
                            InterfaceCode = Emp.InterfaceMFCode
                    End Select

                    DsErnInt = Global1.Business.GetAllPrmsEarningsInterface(InterfaceCode)
                    DsDedInt = Global1.Business.GetAllPrmsDeductionsInterface(InterfaceCode)
                    DsConInt = Global1.Business.GetAllPrmsContributionsInterface(InterfaceCode)





                    DsDetails = Global1.Business.GetDetailsForNavInterface(Hdr)

                    Lines = Global1.Business.GetPrTxTrxnLinesOfHeaderID(Hdr.Id)
                    Period = New cPrMsPeriodCodes(Hdr.PrdCod_Code, Hdr.PrdGrp_Code)
                    If CheckDataSet(Lines) Then
                        For k = 0 To Lines.Tables(0).Rows.Count - 1
                            Lin = New cPrTxTrxnLines(Lines.Tables(0).Rows(k))
                            If Lin.TrxLin_Type = "E" Then
                                For j = 0 To DsErnInt.Tables(0).Rows.Count - 1
                                    ErnInt = New cPrMsEarningsInterface(DsErnInt.Tables(0).Rows(j))
                                    If ErnInt.ErnCode = Lin.ErnCod_Code Then
                                        UpdateTempEARNINGS(Emp, Lin, ErnInt, Hdr, True, "")
                                    End If
                                Next
                            ElseIf Lin.TrxLin_Type = "D" Then
                                For j = 0 To DsDedInt.Tables(0).Rows.Count - 1
                                    DedInt = New cPrMsDeductionsInterface(DsDedInt.Tables(0).Rows(j))
                                    If DedInt.DedCode = Lin.DedCod_Code Then
                                        Dim ReasonCode As String = ""
                                        If InterfaceType = "PF" Then
                                            Dim D As New cPrMsDeductionCodes(DedInt.DedCode)
                                            If D.DedTypCode = "PL" Then
                                                ReasonCode = PReasonLN.Value1
                                            Else
                                                ReasonCode = PReasonGL.Value1
                                            End If
                                        End If
                                        UpdateTempDEDUCTIONS(Emp, Lin, DedInt, Hdr, ReasonCode)
                                    End If
                                Next
                            ElseIf Lin.TrxLin_Type = "C" Then
                                For j = 0 To DsConInt.Tables(0).Rows.Count - 1
                                    ConInt = New cPrMsContributionsInterface(DsConInt.Tables(0).Rows(j))
                                    If ConInt.ConCode = Lin.ConCod_Code Then
                                        Dim ReasonCode As String = ""
                                        If InterfaceType = "PF" Then
                                            Dim C As New cPrMsContributionCodes(ConInt.ConCode)
                                            If C.ConTypCode = "PL" Then
                                                ReasonCode = PReasonLN.Value1
                                            Else
                                                ReasonCode = PReasonGL.Value1
                                            End If
                                        End If
                                        UpdateTempCONTRIBUTIONS(Emp, Lin, ConInt, Hdr, ReasonCode)
                                    End If
                                Next
                            End If

                            'Send_WriteToNavFile(Hdr, Lin, DsDetails, GLBTempGroup, LineCounter, Period, FName)

                            FileWasCreated = True
                        Next
                    End If
                Next
                If FileWasCreated Then
                    If Send_WriteToNavFile_NEW(GLBTempGroup, Period, FName, InterfaceType, Times, FirstFile, ExtraPrefix, Reverse) Then
                        FileDone = True
                        '                        If LastFile Then
                        Global1.IntefaceFileDone = True
                        'End If
                    End If
                End If
            Else
                If LastFile Then
                    If Not Global1.IntefaceFileDone Then
                        MsgBox("There are no Payroll Transactions To Send,Please Check Interface History", MsgBoxStyle.Information)
                        Global1.Business.CommitTransaction()
                    End If
                End If
            End If
            'End If
            If FileDone Then
                If Not Global1.Business.UpdateTrxnHeaderAsPosted(MinId, MaxID, GLBTempGroup, "POST") Then
                    Throw Exx
                End If
            End If
            If FileDone Then
                If IncludeEmployeesInFile Then
                    Send_WriteToNavFile_Employees(GLBTempGroup, FName)
                End If
            End If

            If Global1.IntefaceFileDone Then
                Me.InterfaceFileisOK = True
                If LastFile Then
                    Me.Label7.Text = " "
                    Me.Label6.Text = " "
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                End If
                If LastOfTemp Then
                    If FromHistory Then
                        With Batch
                            .User = Global1.UserName
                            .LastCreation = Now
                            .Times = .Times + 1
                        End With
                    Else
                        With Batch
                            .Id = 0
                            .IdFrom = MinId
                            .IdTo = MaxID
                            .TemGrpCode = GLBTempGroup.Code
                            .User = Global1.UserName
                            .FirstCreation = Now
                            .LastCreation = Now
                            .Times = 1
                        End With
                    End If
                    If Not Batch.Save Then
                        Throw Exx
                    End If
                End If
                If LastFile Then
                    MsgBox("Succesfull File Creation", MsgBoxStyle.Information)
                    Global1.Business.CommitTransaction()
                End If
            Else
                If LastFile Then
                    MsgBox("No File Creation.Please Check EDC Interface", MsgBoxStyle.Critical)
                End If
            End If


            If FileWasCreated Then
                'Me.Label7.Text = "FTP File to Navision ..."
                'Me.PanelLoading.Visible = True
                'System.Windows.Forms.Application.DoEvents()
                'If FTP.Transfer(RemHost, RemPath, user, pwd, 21, Path & FName) Then
                '    MsgBox("File FTP successfuly", MsgBoxStyle.Information)
                'End If
            End If

        Catch ex As Exception
            MsgBox("Unable to Create File", MsgBoxStyle.Critical)
            Global1.Business.Rollback()
            FileWasCreated = False
            Utils.ShowException(ex)
        End Try
        If LastFile Then
            Me.PanelLoading.Visible = False
            InitFile = True
        End If
    End Sub
    Private Sub PrepareInterface_NEW(ByVal Header As DataSet, ByVal MinId As Integer, ByVal MaxID As Integer, ByVal FromHistory As Boolean, ByVal FName As String, ByVal Batch As cPrSsNavBatch, ByVal InterfaceType As String, ByVal LastFile As Boolean, ByVal Times As Integer, ByVal IncludeEmployeesInFile As Boolean, ByVal FirstFile As Boolean, ByVal Reverse As Boolean)
        Dim Exx As New Exception
        Dim FileDone As Boolean
        Dim FileWasCreated As Boolean
        Dim Lines As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim Hdr As New cPrTxTrxnHeader
        Dim DsDetails As DataSet
        Dim Lin As New cPrTxTrxnLines
        Dim Period As New cPrMsPeriodCodes
        Dim LineCounter As Integer = 1
        Dim Emp As cPrMsEmployees
        Dim DsErnInt As DataSet
        Dim DsDedInt As DataSet
        Dim DsConInt As DataSet
        Dim InterfaceCode As String = ""

        Dim ErnInt As New cPrMsEarningsInterface
        Dim DedInt As New cPrMsDeductionsInterface
        Dim ConInt As New cPrMsContributionsInterface
        Dim PReasonGL As New cPrSsParameters
        Dim PReasonLN As New cPrSsParameters
        Dim PRExtraPrefix As New cPrSsParameters
        Dim ExtraPrefix As String = ""
        GlbNoTransactions = False

        Dim DsPar As DataSet
        DsPar = Global1.Business.GetParameter("PF", "GLReason")
        If CheckDataSet(DsPar) Then
            PReasonGL = New cPrSsParameters(DsPar.Tables(0).Rows(0))
        Else
            MsgBox("Please Define Parameter Section 'PF' Item 'GLReason'", MsgBoxStyle.Critical)
            Throw Exx
        End If
        DsPar = Global1.Business.GetParameter("PF", "LoanReason")
        If CheckDataSet(DsPar) Then
            PReasonLN = New cPrSsParameters(DsPar.Tables(0).Rows(0))
        Else
            MsgBox("Please Define Parameter Section 'PF' Item 'LoanReason'", MsgBoxStyle.Critical)
            Throw Exx
        End If

        DsPar = Global1.Business.GetParameter("Interface", "ExtraPrefix")
        If CheckDataSet(DsPar) Then
            PRExtraPrefix = New cPrSsParameters(DsPar.Tables(0).Rows(0))
            ExtraPrefix = PRExtraPrefix.Value1
        End If

        Dim j As Integer
        Try
            If Not Global1.Business.DeleteAllFromTempInterface(GLBTempGroup.Code) Then
                Throw Exx
            End If

            If CheckDataSet(Header) Then
                For i = 0 To Header.Tables(0).Rows.Count - 1

                    Label7.Text = "Creating File in Progress . . . " & i

                    Application.DoEvents()

                    Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                    Emp = New cPrMsEmployees(Hdr.Emp_Code)
                    Select Case InterfaceType
                        Case "CL" 'Control Account
                            InterfaceCode = Emp.InterfaceTemCode
                        Case "PF" 'Provident Fund
                            InterfaceCode = Emp.InterfacePFCode
                        Case "MF" 'Medical Fund
                            InterfaceCode = Emp.InterfaceMFCode
                        Case "MD" 'Medical Fund
                            InterfaceCode = Global1.GLBMKTToMKTInterfaceCode
                    End Select

                    DsErnInt = Global1.Business.GetAllPrmsEarningsInterface(InterfaceCode)
                    DsDedInt = Global1.Business.GetAllPrmsDeductionsInterface(InterfaceCode)
                    DsConInt = Global1.Business.GetAllPrmsContributionsInterface(InterfaceCode)

                    DsDetails = Global1.Business.GetDetailsForNavInterface(Hdr)

                    Lines = Global1.Business.GetPrTxTrxnLinesOfHeaderID(Hdr.Id)
                    Period = New cPrMsPeriodCodes(Hdr.PrdCod_Code, Hdr.PrdGrp_Code)
                    If CheckDataSet(Lines) Then
                        For k = 0 To Lines.Tables(0).Rows.Count - 1
                            Lin = New cPrTxTrxnLines(Lines.Tables(0).Rows(k))
                            If Lin.TrxLin_Type = "E" Then
                                For j = 0 To DsErnInt.Tables(0).Rows.Count - 1
                                    ErnInt = New cPrMsEarningsInterface(DsErnInt.Tables(0).Rows(j))
                                    If ErnInt.ErnCode = Lin.ErnCod_Code Then
                                        UpdateTempEARNINGS(Emp, Lin, ErnInt, Hdr, True, "")
                                    End If
                                Next
                            ElseIf Lin.TrxLin_Type = "D" Then
                                For j = 0 To DsDedInt.Tables(0).Rows.Count - 1
                                    DedInt = New cPrMsDeductionsInterface(DsDedInt.Tables(0).Rows(j))
                                    If DedInt.DedCode = Lin.DedCod_Code Then
                                        Dim ReasonCode As String = ""
                                        If InterfaceType = "PF" Then
                                            Dim D As New cPrMsDeductionCodes(DedInt.DedCode)
                                            If D.DedTypCode = "PL" Then
                                                ReasonCode = PReasonLN.Value1
                                            Else
                                                ReasonCode = PReasonGL.Value1
                                            End If
                                        End If
                                        UpdateTempDEDUCTIONS(Emp, Lin, DedInt, Hdr, ReasonCode)
                                    End If
                                Next
                            ElseIf Lin.TrxLin_Type = "C" Then
                                For j = 0 To DsConInt.Tables(0).Rows.Count - 1
                                    ConInt = New cPrMsContributionsInterface(DsConInt.Tables(0).Rows(j))
                                    If ConInt.ConCode = Lin.ConCod_Code Then
                                        Dim ReasonCode As String = ""
                                        If InterfaceType = "PF" Then
                                            Dim C As New cPrMsContributionCodes(ConInt.ConCode)
                                            If C.ConTypCode = "PL" Then
                                                ReasonCode = PReasonLN.Value1
                                            Else
                                                ReasonCode = PReasonGL.Value1
                                            End If
                                        End If
                                        UpdateTempCONTRIBUTIONS(Emp, Lin, ConInt, Hdr, ReasonCode)
                                    End If
                                Next
                            End If

                            'Send_WriteToNavFile(Hdr, Lin, DsDetails, GLBTempGroup, LineCounter, Period, FName)

                            FileWasCreated = True
                        Next
                    End If
                Next
                If FileWasCreated Then
                    If Send_WriteToNavFile_NEW(GLBTempGroup, Period, FName, InterfaceType, Times, FirstFile, ExtraPrefix, Reverse) Then
                        FileDone = True
                        Global1.IntefaceFileDone = True
                    End If
                End If
            Else
                MsgBox("There are no Payroll Transactions To Send,Please Check Interface History", MsgBoxStyle.Information)
                GlbNoTransactions = True
            End If
            'End If
            If FileDone Then
                If Not Global1.Business.UpdateTrxnHeaderAsPosted(MinId, MaxID, GLBTempGroup, "POST") Then
                    Throw Exx
                End If
            End If
            If FileDone Then
                If IncludeEmployeesInFile Then
                    Send_WriteToNavFile_Employees(GLBTempGroup, FName)
                End If
            End If

            If Global1.IntefaceFileDone Then
                If LastFile Then
                    Me.Label7.Text = " "
                    Me.Label6.Text = " "
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    If FromHistory Then
                        With Batch
                            .User = Global1.UserName
                            .LastCreation = Now
                            .Times = .Times + 1
                        End With
                    Else
                        With Batch
                            .Id = 0
                            .IdFrom = MinId
                            .IdTo = MaxID
                            .TemGrpCode = GLBTempGroup.Code
                            .User = Global1.UserName
                            .FirstCreation = Now
                            .LastCreation = Now
                            .Times = 1
                        End With
                    End If
                    If Not Batch.Save Then
                        Throw Exx
                    End If
                    MsgBox("Succesfull File Creation", MsgBoxStyle.Information)
                    Me.InterfaceFileisOK = True
                End If
            Else
                MsgBox("No File Creation.Please Check EDC Interface", MsgBoxStyle.Critical)
            End If
            If LastFile Then
                Global1.Business.CommitTransaction()
            End If

            If FileWasCreated Then
                'Me.Label7.Text = "FTP File to Navision ..."
                'Me.PanelLoading.Visible = True
                'System.Windows.Forms.Application.DoEvents()
                'If FTP.Transfer(RemHost, RemPath, user, pwd, 21, Path & FName) Then
                '    MsgBox("File FTP successfuly", MsgBoxStyle.Information)
                'End If
            End If

        Catch ex As Exception
            MsgBox("Unable to Create File", MsgBoxStyle.Critical)
            Global1.Business.Rollback()
            FileWasCreated = False
            Utils.ShowException(ex)
        End Try
        If LastFile Then
            Me.PanelLoading.Visible = False
            InitFile = True
        End If
    End Sub
    Private Sub PrepareInterface_NEW_TA(ByVal Header As DataSet, ByVal MinId As Integer, ByVal MaxID As Integer, ByVal FromHistory As Boolean, ByVal FName As String, ByVal Batch As cPrSsNavBatch, ByVal InterfaceType As String, ByVal LastFile As Boolean, ByVal Times As Integer, ByVal IncludeEmployeesInFile As Boolean, ByVal Firstfile As Boolean, ByVal Reverse As Boolean)


        Dim Exx As New Exception
        Dim FileDone As Boolean
        Dim FileWasCreated As Boolean
        Dim Lines As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim Hdr As New cPrTxTrxnHeader
        Dim DsDetails As DataSet
        Dim Lin As New cPrTxTrxnLines
        Dim Period As New cPrMsPeriodCodes
        Dim LineCounter As Integer = 1
        Dim Emp As cPrMsEmployees
        Dim DsErnInt As DataSet
        Dim DsDedInt As DataSet
        Dim DsConInt As DataSet
        Dim InterfaceCode As String = ""

        Dim ErnInt As New cPrMsEarningsInterface
        Dim DedInt As New cPrMsDeductionsInterface
        Dim ConInt As New cPrMsContributionsInterface
        Dim PReasonGL As New cPrSsParameters
        Dim PReasonLN As New cPrSsParameters
        Dim PRExtraPrefix As New cPrSsParameters
        Dim ExtraPrefix As String = ""
        Dim DsTA As DataSet
        Dim TotalHours As Double = 0

        Dim DsPar As DataSet
        DsPar = Global1.Business.GetParameter("PF", "GLReason")
        If CheckDataSet(DsPar) Then
            PReasonGL = New cPrSsParameters(DsPar.Tables(0).Rows(0))
        Else
            MsgBox("Please Define Parameter Section 'PF' Item 'GLReason'", MsgBoxStyle.Critical)
            Throw Exx
        End If
        DsPar = Global1.Business.GetParameter("PF", "LoanReason")
        If CheckDataSet(DsPar) Then
            PReasonLN = New cPrSsParameters(DsPar.Tables(0).Rows(0))
        Else
            MsgBox("Please Define Parameter Section 'PF' Item 'LoanReason'", MsgBoxStyle.Critical)
            Throw Exx
        End If

        DsPar = Global1.Business.GetParameter("Interface", "ExtraPrefix")
        If CheckDataSet(DsPar) Then
            PRExtraPrefix = New cPrSsParameters(DsPar.Tables(0).Rows(0))
            ExtraPrefix = PRExtraPrefix.Value1
        End If

        Dim j As Integer
        Try
            If Not Global1.Business.DeleteAllFromTempInterface(GLBTempGroup.Code) Then
                Throw Exx
            End If

            If CheckDataSet(Header) Then
                For i = 0 To Header.Tables(0).Rows.Count - 1
                    Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                    Emp = New cPrMsEmployees(Hdr.Emp_Code)
                    Select Case InterfaceType
                        Case "CL" 'Control Account
                            InterfaceCode = Emp.InterfaceTemCode
                        Case "PF" 'Provident Fund
                            InterfaceCode = Emp.InterfacePFCode
                        Case "MF" 'Medical Fund
                            InterfaceCode = Emp.InterfaceMFCode

                    End Select

                    DsErnInt = Global1.Business.GetAllPrmsEarningsInterface(InterfaceCode)
                    DsDedInt = Global1.Business.GetAllPrmsDeductionsInterface(InterfaceCode)
                    DsConInt = Global1.Business.GetAllPrmsContributionsInterface(InterfaceCode)

                    DsDetails = Global1.Business.GetDetailsForNavInterface(Hdr)

                    Lines = Global1.Business.GetPrTxTrxnLinesOfHeaderID(Hdr.Id)
                    Period = New cPrMsPeriodCodes(Hdr.PrdCod_Code, Hdr.PrdGrp_Code)
                    Application.DoEvents()
                    'Debug.WriteLine("counter=" & i & "?" & Header.Tables(0).Rows.Count - 1)

                    DsTA = Global1.Business.GetTaTrxnLines2_SumPerAnalysis(Emp.Code, Period.DateFrom, Period.DateTo)

                    'xxx()
                    Dim AnalysisCode As String = ""
                    Dim AnalysisHours As Double = 0
                    Dim TotalRows As Integer = 0
                    Dim LineTotalUntilNow1 As Double = 0
                    Dim PeriodTotalUntilNow1 As Double = 0
                    Dim LineTotalUntilNow2 As Double = 0
                    Dim PeriodTotalUntilNow2 As Double = 0
                    If CheckDataSet(DsTA) Then
                        Dim a As Integer

                        'For a = 0 To DsTA.Tables(0).Rows.Count - 1
                        'Application.DoEvents()

                        'Dim SkipThis As Boolean = False
                        'AnalysisHours = DbNullToDouble(DsTA.Tables(0).Rows(a).Item(0))
                        'AnalysisCode = DbNullToString(DsTA.Tables(0).Rows(a).Item(1))

                        'If TotalHours = 0 Then
                        ' TotalHours = 1
                        ' AnalysisHours = 1
                        'End If
                        'If AnalysisHours = 0 Then
                        ' SkipThis = True
                        'End If

                        '   If Not SkipThis Then
                        If CheckDataSet(Lines) Then
                            For k = 0 To Lines.Tables(0).Rows.Count - 1
                                Lin = New cPrTxTrxnLines(Lines.Tables(0).Rows(k))

                                If Lin.TrxLin_Type = "E" Then
                                    For j = 0 To DsErnInt.Tables(0).Rows.Count - 1
                                        ErnInt = New cPrMsEarningsInterface(DsErnInt.Tables(0).Rows(j))
                                        If ErnInt.ErnCode = Lin.ErnCod_Code Then
                                            TotalHours = Global1.Business.GetTaTrxnLines2_Sum(Emp.Code, Period.DateFrom, Period.DateTo)
                                            Dim DebitDone As Boolean = False
                                            Dim CreditDone As Boolean = False
                                            For a = 0 To DsTA.Tables(0).Rows.Count - 1
                                                TotalRows = DsTA.Tables(0).Rows.Count - 1
                                                Application.DoEvents()
                                                Dim SkipThis As Boolean = False
                                                AnalysisHours = DbNullToDouble(DsTA.Tables(0).Rows(a).Item(0))
                                                AnalysisCode = DbNullToString(DsTA.Tables(0).Rows(a).Item(1))
                                                If TotalHours = 0 Then
                                                    TotalHours = 1
                                                    AnalysisHours = 1
                                                End If
                                                If AnalysisHours = 0 Then
                                                    SkipThis = True
                                                End If
                                                If Not SkipThis Then
                                                    If a = 0 Then
                                                        LineTotalUntilNow1 = 0
                                                        PeriodTotalUntilNow1 = 0
                                                        LineTotalUntilNow2 = 0
                                                        PeriodTotalUntilNow2 = 0
                                                    End If
                                                    UpdateTempEARNINGS_TA_R1(Emp, Lin, ErnInt, Hdr, True, "", TotalHours, AnalysisHours, AnalysisCode, TotalRows, a, LineTotalUntilNow1, PeriodTotalUntilNow1, LineTotalUntilNow2, PeriodTotalUntilNow2, CreditDone, DebitDone, False)
                                                End If
                                            Next
                                        End If
                                    Next
                                ElseIf Lin.TrxLin_Type = "D" Then
                                    For j = 0 To DsDedInt.Tables(0).Rows.Count - 1
                                        DedInt = New cPrMsDeductionsInterface(DsDedInt.Tables(0).Rows(j))
                                        If DedInt.DedCode = Lin.DedCod_Code Then
                                            Dim DebitDone As Boolean = False
                                            Dim CreditDone As Boolean = False
                                            Dim ReasonCode As String = ""
                                            If InterfaceType = "PF" Then
                                                Dim D As New cPrMsDeductionCodes(DedInt.DedCode)
                                                If D.DedTypCode = "PL" Then
                                                    ReasonCode = PReasonLN.Value1
                                                Else
                                                    ReasonCode = PReasonGL.Value1
                                                End If
                                            End If
                                            TotalHours = Global1.Business.GetTaTrxnLines2_Sum(Emp.Code, Period.DateFrom, Period.DateTo)
                                            For a = 0 To DsTA.Tables(0).Rows.Count - 1
                                                TotalRows = DsTA.Tables(0).Rows.Count - 1
                                                Application.DoEvents()
                                                Dim SkipThis As Boolean = False
                                                AnalysisHours = DbNullToDouble(DsTA.Tables(0).Rows(a).Item(0))
                                                AnalysisCode = DbNullToString(DsTA.Tables(0).Rows(a).Item(1))
                                                If TotalHours = 0 Then
                                                    TotalHours = 1
                                                    AnalysisHours = 1
                                                End If
                                                If AnalysisHours = 0 Then
                                                    SkipThis = True
                                                End If
                                                If Not SkipThis Then
                                                    If a = 0 Then
                                                        LineTotalUntilNow1 = 0
                                                        LineTotalUntilNow2 = 0
                                                    End If
                                                    UpdateTempDEDUCTIONS_TA_R1(Emp, Lin, DedInt, Hdr, ReasonCode, TotalHours, AnalysisHours, AnalysisCode, TotalRows, a, LineTotalUntilNow1, LineTotalUntilNow2, CreditDone, DebitDone, False)
                                                End If
                                            Next
                                        End If
                                    Next
                                ElseIf Lin.TrxLin_Type = "C" Then
                                    For j = 0 To DsConInt.Tables(0).Rows.Count - 1
                                        ConInt = New cPrMsContributionsInterface(DsConInt.Tables(0).Rows(j))
                                        If ConInt.ConCode = Lin.ConCod_Code Then
                                            Dim DebitDone As Boolean = False
                                            Dim CreditDone As Boolean = False
                                            Dim ReasonCode As String = ""
                                            If InterfaceType = "PF" Then
                                                Dim C As New cPrMsContributionCodes(ConInt.ConCode)
                                                If C.ConTypCode = "PL" Then
                                                    ReasonCode = PReasonLN.Value1
                                                Else
                                                    ReasonCode = PReasonGL.Value1
                                                End If
                                            End If
                                            TotalHours = Global1.Business.GetTaTrxnLines2_Sum(Emp.Code, Period.DateFrom, Period.DateTo)
                                            For a = 0 To DsTA.Tables(0).Rows.Count - 1
                                                TotalRows = DsTA.Tables(0).Rows.Count - 1
                                                Application.DoEvents()
                                                Dim SkipThis As Boolean = False
                                                AnalysisHours = DbNullToDouble(DsTA.Tables(0).Rows(a).Item(0))
                                                AnalysisCode = DbNullToString(DsTA.Tables(0).Rows(a).Item(1))
                                                If TotalHours = 0 Then
                                                    TotalHours = 1
                                                    AnalysisHours = 1
                                                End If
                                                If AnalysisHours = 0 Then
                                                    SkipThis = True
                                                End If
                                                If Not SkipThis Then
                                                    If a = 0 Then
                                                        LineTotalUntilNow1 = 0
                                                        LineTotalUntilNow2 = 0

                                                    End If
                                                    UpdateTempCONTRIBUTIONS_TA_R1(Emp, Lin, ConInt, Hdr, ReasonCode, TotalHours, AnalysisHours, AnalysisCode, TotalRows, a, LineTotalUntilNow1, LineTotalUntilNow2, CreditDone, DebitDone, False)
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                                'Send_WriteToNavFile(Hdr, Lin, DsDetails, GLBTempGroup, LineCounter, Period, FName)
                                FileWasCreated = True
                            Next
                        End If
                        'End If
                        'Next
                    Else
                        TotalHours = 1
                        AnalysisHours = 1

                        AnalysisCode = ""


                        If CheckDataSet(Lines) Then

                            For k = 0 To Lines.Tables(0).Rows.Count - 1
                                Lin = New cPrTxTrxnLines(Lines.Tables(0).Rows(k))
                                If Lin.TrxLin_Type = "E" Then
                                    For j = 0 To DsErnInt.Tables(0).Rows.Count - 1
                                        ErnInt = New cPrMsEarningsInterface(DsErnInt.Tables(0).Rows(j))
                                        If ErnInt.ErnCode = Lin.ErnCod_Code Then
                                            Dim DebitDone As Boolean
                                            Dim CreditDone As Boolean
                                            DebitDone = False
                                            CreditDone = False
                                            UpdateTempEARNINGS_TA_R1(Emp, Lin, ErnInt, Hdr, True, "", TotalHours, AnalysisHours, AnalysisCode, 0, 0, 0, 0, 0, 0, CreditDone, DebitDone, True)
                                        End If
                                    Next
                                ElseIf Lin.TrxLin_Type = "D" Then
                                    For j = 0 To DsDedInt.Tables(0).Rows.Count - 1
                                        DedInt = New cPrMsDeductionsInterface(DsDedInt.Tables(0).Rows(j))
                                        If DedInt.DedCode = Lin.DedCod_Code Then
                                            Dim DebitDone As Boolean = False
                                            Dim CreditDone As Boolean = False
                                            Dim ReasonCode As String = ""

                                            If InterfaceType = "PF" Then
                                                Dim D As New cPrMsDeductionCodes(DedInt.DedCode)
                                                If D.DedTypCode = "PL" Then
                                                    ReasonCode = PReasonLN.Value1
                                                Else
                                                    ReasonCode = PReasonGL.Value1
                                                End If
                                            End If
                                            UpdateTempDEDUCTIONS_TA_R1(Emp, Lin, DedInt, Hdr, ReasonCode, TotalHours, AnalysisHours, AnalysisCode, 0, 0, 0, 0, CreditDone, DebitDone, True)
                                        End If
                                    Next
                                ElseIf Lin.TrxLin_Type = "C" Then
                                    For j = 0 To DsConInt.Tables(0).Rows.Count - 1
                                        ConInt = New cPrMsContributionsInterface(DsConInt.Tables(0).Rows(j))
                                        If ConInt.ConCode = Lin.ConCod_Code Then
                                            Dim DebitDone As Boolean = False
                                            Dim CreditDone As Boolean = False
                                            Dim ReasonCode As String = ""
                                            If InterfaceType = "PF" Then
                                                Dim C As New cPrMsContributionCodes(ConInt.ConCode)
                                                If C.ConTypCode = "PL" Then
                                                    ReasonCode = PReasonLN.Value1
                                                Else
                                                    ReasonCode = PReasonGL.Value1
                                                End If
                                            End If
                                            UpdateTempCONTRIBUTIONS_TA_R1(Emp, Lin, ConInt, Hdr, ReasonCode, TotalHours, AnalysisHours, AnalysisCode, 0, 0, 0, 0, CreditDone, DebitDone, True)
                                        End If
                                    Next
                                End If

                                'Send_WriteToNavFile(Hdr, Lin, DsDetails, GLBTempGroup, LineCounter, Period, FName)

                                FileWasCreated = True
                            Next
                        End If
                        ' No TA Found
                    End If

                Next
                If FileWasCreated Then
                    If Send_WriteToNavFile_NEW(GLBTempGroup, Period, FName, InterfaceType, Times, Firstfile, ExtraPrefix, Reverse) Then
                        FileDone = True
                        Global1.IntefaceFileDone = True
                    End If
                End If
            Else
                MsgBox("There are no Payroll Transactions To Send,Please Check Interface History", MsgBoxStyle.Information)
            End If
            'End If
            If FileDone Then
                If Not Global1.Business.UpdateTrxnHeaderAsPosted(MinId, MaxID, GLBTempGroup, "POST") Then
                    Throw Exx
                End If
            End If
            If FileDone Then
                If IncludeEmployeesInFile Then
                    Send_WriteToNavFile_Employees(GLBTempGroup, FName)
                End If
            End If

            If Global1.IntefaceFileDone Then
                If LastFile Then
                    Me.Label7.Text = " "
                    Me.Label6.Text = " "
                    Me.PanelLoading.Visible = False
                    Me.PanelLoading.Refresh()
                    If FromHistory Then
                        With Batch
                            .User = Global1.UserName
                            .LastCreation = Now
                            .Times = .Times + 1
                        End With
                    Else
                        With Batch
                            .Id = 0
                            .IdFrom = MinId
                            .IdTo = MaxID
                            .TemGrpCode = GLBTempGroup.Code
                            .User = Global1.UserName
                            .FirstCreation = Now
                            .LastCreation = Now
                            .Times = 1
                        End With
                    End If
                    If Not Batch.Save Then
                        Throw Exx
                    End If
                    MsgBox("Succesfull File Creation", MsgBoxStyle.Information)
                    Me.InterfaceFileisOK = True
                End If
            Else
                MsgBox("No File Creation.Please Check EDC Interface", MsgBoxStyle.Critical)
            End If
            If LastFile Then
                Global1.Business.CommitTransaction()
            End If

            If FileWasCreated Then
                'Me.Label7.Text = "FTP File to Navision ..."
                'Me.PanelLoading.Visible = True
                'System.Windows.Forms.Application.DoEvents()
                'If FTP.Transfer(RemHost, RemPath, user, pwd, 21, Path & FName) Then
                '    MsgBox("File FTP successfuly", MsgBoxStyle.Information)
                'End If
            End If

        Catch ex As Exception
            MsgBox("Unable to Create File", MsgBoxStyle.Critical)
            Global1.Business.Rollback()
            FileWasCreated = False
            Utils.ShowException(ex)
        End Try
        If LastFile Then
            Me.PanelLoading.Visible = False
            InitFile = True
        End If
    End Sub
    Private Sub FixRoundingIssue(ByVal TempCode As String, ByVal DsRound As DataSet)
        Exit Sub
        Dim i As Integer
        Dim AccountCode As Integer
        Dim Amount As Double
        Dim Total As Double
        Dim Ds As DataSet
        Dim k As Integer
        Dim Dif As Double = 0
        If CheckDataSet(DsRound) Then
            For i = 0 To DsRound.Tables(0).Rows.Count - 1
                Amount = DbNullToDouble(DsRound.Tables(0).Rows(i).Item(0))
                AccountCode = DbNullToString(DsRound.Tables(0).Rows(i).Item(1))
                Ds = Global1.Business.GetPrTmInterfacePerAccount(TempCode, AccountCode)
                Total = Global1.Business.GetPrTmInterfaceSumPerAccount(TempCode, AccountCode)
                If CheckDataSet(Ds) Then
                    Dim tm As New cPrTmInterface()
                    tm = New cPrTmInterface(Ds.Tables(0).Rows(0))
                    If Total <> Amount Then
                        Dif = RoundMe2(Total - Amount, 2)
                        If Amount < 0 Then
                            Dim am As Double
                            am = Math.Abs(tm.Amount)
                            tm.Amount = (am + Dif) * -1
                        Else
                            tm.Amount = tm.Amount - Dif
                        End If
                        Dif = 0
                        tm.Save()
                    End If
                End If
            Next
        End If
    End Sub
    Private Function BuiltAccount(ByVal MskCode As String, ByVal Emp As cPrMsEmployees) As String
        Dim AccountCode As String
        Dim IntCod As New cPrMsInterfaceCodes(MskCode)
        Dim Index As Integer
        Dim VEmp As Integer = 0
        Dim VEmpGL1 As Integer = 16
        Dim VEmpGL2 As Integer = 28
        Dim VEmpGL3 As Integer = 40
        Dim VEmpGL4 As Integer = 52
        Dim VAn1 As Integer = 64
        Dim VAn1GL1 As Integer = 76
        Dim VAn1GL2 As Integer = 88
        Dim VAn2 As Integer = 100
        Dim VAn2GL1 As Integer = 112
        Dim VAn2GL2 As Integer = 124
        Dim VAn3 As Integer = 136
        Dim VAn3GL1 As Integer = 148
        Dim VAn3GL2 As Integer = 160
        Dim VAn4 As Integer = 172
        Dim VAn4GL1 As Integer = 184
        Dim VAn4GL2 As Integer = 196
        Dim VAn5 As Integer = 208
        Dim VAn5GL1 As Integer = 220
        Dim VAn5GL2 As Integer = 232
        Dim VAn6 As Integer = 244
        Dim VAn6GL1 As Integer = 256
        Dim VAn6GL2 As Integer = 268
        Dim S As String = ""



        If IntCod.Code <> "" Or Not IntCod.Code Is Nothing Then

            Dim ds As DataSet
            ds = Global1.Business.GetAllPrMsCodeMasking(IntCod.Code)
            If CheckDataSet(ds) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim MskCod As New cPrMsCodeMasking(ds.Tables(0).Rows(i))
                    Try


                        If MskCod.Value <> "" Then
                            If MskCod.Type = "0" Then 'FIXED
                                S = S & MskCod.Value
                            ElseIf MskCod.Type = "1" Then 'VARIABLE

                                If MskCod.Value >= 1 And MskCod.Value <= 16 Then
                                    'Employee Code 
                                    '-----------------
                                    Index = MskCod.Value - 1
                                    S = S & Emp.Code.Substring(Index, 1)
                                ElseIf MskCod.Value >= 17 And MskCod.Value <= 28 Then
                                    'Employee GLAnal 1
                                    '-----------------
                                    Index = MskCod.Value - VEmpGL1 - 1
                                    S = S & Emp.Emp_GLAnal1.Substring(Index, 1)
                                ElseIf MskCod.Value >= 29 And MskCod.Value <= 40 Then
                                    'Employee GLAnal 2
                                    '-----------------
                                    Index = MskCod.Value - VEmpGL2 - 1
                                    S = S & Emp.Emp_GLAnal2.Substring(Index, 1)
                                ElseIf MskCod.Value >= 41 And MskCod.Value <= 52 Then
                                    'Employee GLAnal 3
                                    '-----------------
                                    Index = MskCod.Value - VEmpGL3 - 1
                                    S = S & Emp.Emp_GLAnal3.Substring(Index, 1)

                                ElseIf MskCod.Value >= 53 And MskCod.Value <= 64 Then
                                    'Employee GLAnal 4
                                    '-----------------
                                    Index = MskCod.Value - VEmpGL4 - 1
                                    S = S & Emp.Emp_GLAnal4.Substring(Index, 1)

                                ElseIf MskCod.Value >= 65 And MskCod.Value <= 76 Then
                                    'Analysis 1 Code 
                                    '-----------------
                                    Index = MskCod.Value - VAn1 - 1
                                    S = S & Emp.EmpAn1_Code.Substring(Index, 1)

                                ElseIf MskCod.Value >= 77 And MskCod.Value <= 88 Then
                                    'Analysis 1 GLAnal
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis1(Emp.EmpAn1_Code)
                                    Index = MskCod.Value - VAn1GL1 - 1
                                    S = S & An.GLAnal1.Substring(Index, 1)
                                ElseIf MskCod.Value >= 89 And MskCod.Value <= 100 Then
                                    'Analysis 1 GLAnal 2
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis1(Emp.EmpAn1_Code)
                                    Index = MskCod.Value - VAn1GL2 - 1
                                    S = S & An.GLAnal2.Substring(Index, 1)
                                ElseIf MskCod.Value >= 101 And MskCod.Value <= 112 Then
                                    'Analysis 2 Code
                                    '-----------------
                                    Index = MskCod.Value - VAn2 - 1
                                    S = S & Emp.EmpAn2_Code.Substring(Index, 1)
                                ElseIf MskCod.Value >= 113 And MskCod.Value <= 124 Then
                                    'Analysis 2 GLAnal 1
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis2(Emp.EmpAn2_Code)
                                    Index = MskCod.Value - VAn2GL1 - 1
                                    S = S & An.GLAnal1.Substring(Index, 1)
                                ElseIf MskCod.Value >= 125 And MskCod.Value <= 136 Then
                                    'Analysis 2 GLAnal 2
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis2(Emp.EmpAn2_Code)
                                    Index = MskCod.Value - VAn2GL2 - 1
                                    S = S & An.GLAnal2.Substring(Index, 1)
                                ElseIf MskCod.Value >= 137 And MskCod.Value <= 148 Then
                                    'Analysis 3 Code
                                    '-----------------
                                    Index = MskCod.Value - VAn3 - 1
                                    S = S & Emp.EmpAn3_Code.Substring(Index, 1)
                                ElseIf MskCod.Value >= 149 And MskCod.Value <= 160 Then
                                    'Analysis 3 GLAnal 1
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis3(Emp.EmpAn3_Code)
                                    Index = MskCod.Value - VAn3GL1 - 1
                                    S = S & An.GLAnal1.Substring(Index, 1)
                                ElseIf MskCod.Value >= 161 And MskCod.Value <= 172 Then
                                    'Analysis 3 GLAnal 2
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis3(Emp.EmpAn3_Code)
                                    Index = MskCod.Value - VAn3GL2 - 1
                                    S = S & An.GLAnal2.Substring(Index, 1)
                                ElseIf MskCod.Value >= 172 And MskCod.Value <= 184 Then
                                    'Analysis 4 Code
                                    '-----------------
                                    Index = MskCod.Value - VAn4 - 1
                                    S = S & Emp.EmpAn4_Code.Substring(Index, 1)
                                ElseIf MskCod.Value >= 185 And MskCod.Value <= 196 Then
                                    'Analysis 4 GLAnal 1
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis4(Emp.EmpAn4_Code)
                                    Index = MskCod.Value - VAn4GL1 - 1
                                    S = S & An.GLAnal1.Substring(Index, 1)
                                ElseIf MskCod.Value >= 197 And MskCod.Value <= 208 Then
                                    'Analysis 4 GLAnal 2
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis4(Emp.EmpAn4_Code)
                                    Index = MskCod.Value - VAn4GL2 - 1
                                    S = S & An.GLAnal2.Substring(Index, 1)
                                ElseIf MskCod.Value >= 209 And MskCod.Value <= 220 Then
                                    'Analysis 5 Code
                                    '-----------------
                                    Index = MskCod.Value - VAn5 - 1
                                    S = S & Emp.EmpAn5_Code.Substring(Index, 1)

                                ElseIf MskCod.Value >= 221 And MskCod.Value <= 232 Then
                                    'Analysis 5 GLAnal 1
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis5(Emp.EmpAn5_Code)
                                    Index = MskCod.Value - VAn5GL1 - 1
                                    S = S & An.GLAnal1.Substring(Index, 1)

                                ElseIf MskCod.Value >= 233 And MskCod.Value <= 244 Then
                                    'Analysis 5 GLAnal 2
                                    '-----------------
                                    Dim An As New cPrAnEmployeeAnalysis5(Emp.EmpAn5_Code)
                                    Index = MskCod.Value - VAn5GL2 - 1
                                    S = S & An.GLAnal2.Substring(Index, 1)

                                ElseIf MskCod.Value >= 245 And MskCod.Value <= 256 Then
                                    'Analysis Union
                                    '-----------------
                                    Index = MskCod.Value - VAn6 - 1
                                    S = S & Emp.Uni_Code.Substring(Index, 1)

                                ElseIf MskCod.Value >= 257 And MskCod.Value <= 268 Then
                                    'Analysis Union GLAnal 1
                                    '-----------------
                                    Dim An As New cPrAnUnions(Emp.Uni_Code)
                                    Index = MskCod.Value - VAn6GL1 - 1
                                    S = S & An.GLAnal1.Substring(Index, 1)

                                ElseIf MskCod.Value >= 269 And MskCod.Value <= 280 Then
                                    'Analysis Union GLAnal 1
                                    '-----------------
                                    Dim An As New cPrAnUnions(Emp.Uni_Code)
                                    Index = MskCod.Value - VAn6GL2 - 1
                                    S = S & An.GLAnal2.Substring(Index, 1)

                                End If
                            End If
                        End If
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Invalid Masking for Masking Code " & MskCode & " For Position " & MskCod.Position)
                        S = ""
                    End Try
                Next
            End If
        End If

        AccountCode = S
        Return AccountCode

    End Function


    Private Sub UpdateTempEARNINGS(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal ErnInt As cPrMsEarningsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal NewInterface As Boolean, ByVal ReasonCode As String)
        Dim Ds As DataSet
        Dim Ds3E As DataSet
        Dim DsLP As DataSet

        Dim Exx As Exception
        Dim Int As New cPrTmInterface
        Dim Int3 As New cPrTmInterface
        Dim IntLP As New cPrTmInterface

        Dim A0 As String = ""
        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim AU As String = ""
        Dim A0Pos As Integer = 0
        Dim A1Pos As Integer = 0
        Dim A2Pos As Integer = 0
        Dim A3Pos As Integer = 0
        Dim A4Pos As Integer = 0
        Dim A5Pos As Integer = 0
        Dim AUnionPos As Integer = 0
        Dim i As Integer
        Dim S As String




        ''''''''''''''''''''''''''''''
        '           Credit
        ''''''''''''''''''''''''''''''
        Dim Ern As New cPrMsEarningCodes(ErnInt.ErnCode)
        Dim Is13nt As Boolean = False
        Dim IsLP As Boolean = False

        If NewInterface Then
            If Ern.ErnTypCode = "3E" Then
                Is13nt = True
            End If
            If Ern.ErnTypCode = "LP" Then
                IsLP = True
            Else
                IsLP = False
            End If
        End If
        'If Emp.Code = "E0031" Then
        '    MsgBox("1")
        'End If

        For i = 0 To ErnInt.CreditAnal.Length - 1
            S = ErnInt.CreditAnal.Substring(i, 1)
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1
                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    A5 = HDR.A5
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1

            End Select
        Next
        Dim CreditAccount As String
        If ErnInt.CreditAccount = "" Then
            'Not Used
            Exit Sub
        End If
        CreditAccount = BuiltAccount(ErnInt.CreditAccount, Emp)


        Dim IntCod As New cPrMsInterfaceCodes(ErnInt.CreditAccount)
        If ErnInt.CreditConsol = 1 Then 'EDC Level
            Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = Lin.ErnCod_Code
                .Con_Level = 1
                If Is13nt Then
                    If NewInterface Then
                        .Amount = .Amount - Lin.TrxLin_YTDValue
                    Else
                        .Amount = .Amount - Lin.TrxLin_PeriodValue
                    End If
                Else
                    .Amount = .Amount - Lin.TrxLin_PeriodValue
                End If
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode

                If Not .Save Then
                    Throw Exx
                End If
            End With
            If Is13nt Then
                Ds3E = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(Ds3E) Then
                    Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                End If
                With Int3
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ErnCod_Code
                    .Con_Level = 1
                    .Amount = (.Amount - Lin.TrxLin_YTDValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Leave Provision
            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ErnCod_Code
                    .Con_Level = 1
                    .Amount = (.Amount - Lin.TrxLin_PeriodValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''




        ElseIf ErnInt.CreditConsol = 2 Then 'Employee Level
            Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = ""
                .Con_Level = 2
                If Is13nt Then
                    If NewInterface Then
                        .Amount = .Amount - Lin.TrxLin_YTDValue
                    Else
                        .Amount = .Amount - Lin.TrxLin_PeriodValue
                    End If
                Else
                    .Amount = .Amount - Lin.TrxLin_PeriodValue
                End If
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                        If HDR.PaymentRef = "" And PARAM_EmpCodeinChequeRef Then
                            .ExternalDoc = Emp.Code
                        End If
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
            If Is13nt Then
                Ds3E = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(Ds3E) Then
                    Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                End If
                With Int3
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = (.Amount - Lin.TrxLin_YTDValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                            If HDR.PaymentRef = "" And PARAM_EmpCodeinChequeRef Then
                                .ExternalDoc = Emp.Code
                            End If
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''Leave Provision '''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = (.Amount - Lin.TrxLin_PeriodValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"

                        Else
                            .ExternalDoc = Emp.Code
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




        ElseIf ErnInt.CreditConsol = 3 Then 'Template Level
            Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = ""
                .EDC_Code = ""
                .Con_Level = 3
                If Is13nt Then
                    If NewInterface Then
                        .Amount = .Amount - Lin.TrxLin_YTDValue
                    Else
                        .Amount = .Amount - Lin.TrxLin_PeriodValue
                    End If
                Else
                    .Amount = .Amount - Lin.TrxLin_PeriodValue
                End If
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                .ExternalDoc = ""
                .IsCheque = ""
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
            If Is13nt Then
                Ds3E = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(Ds3E) Then
                    Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                End If
                With Int3
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = (.Amount - Lin.TrxLin_YTDValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Leave Provision
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = (.Amount - Lin.TrxLin_PeriodValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
        End If
        '***********************************************************************************************************


        '***********************************************************************************************************




        ''''''''''''''''''''''''''''''
        '           DEBIT
        ''''''''''''''''''''''''''''''
        A0 = ""
        A1 = ""
        A2 = ""
        A3 = ""
        A4 = ""
        A5 = ""
        AU = ""
        A0Pos = 0
        A1Pos = 0
        A2Pos = 0
        A3Pos = 0
        A4Pos = 0
        A5Pos = 0
        AUnionPos = 0

        For i = 0 To ErnInt.DebitAnal.Length - 1
            S = ErnInt.DebitAnal.Substring(i, 1)
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1
                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    A5 = HDR.A5
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        Int = New cPrTmInterface
        Int3 = New cPrTmInterface

        Dim DebitAccount As String
        DebitAccount = BuiltAccount(ErnInt.DebitAccount, Emp)

        IntCod = New cPrMsInterfaceCodes(ErnInt.DebitAccount)


        If ErnInt.DebitConsol = 1 Then 'EDC Level
            Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = Lin.ErnCod_Code
                .Con_Level = 1
                If Is13nt Then
                    If NewInterface Then
                        .Amount = .Amount + Lin.TrxLin_YTDValue
                    Else
                        .Amount = .Amount + Lin.TrxLin_PeriodValue
                    End If
                Else
                    .Amount = .Amount + Lin.TrxLin_PeriodValue
                End If
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode

                If Not .Save Then
                    Throw Exx
                End If
            End With
            If Is13nt Then
                Ds3E = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(Ds3E) Then
                    Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                End If
                With Int3
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ErnCod_Code
                    .Con_Level = 1
                    .Amount = (.Amount + Lin.TrxLin_YTDValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '                      Leave Provision
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ErnCod_Code
                    .Con_Level = 1
                    .Amount = (.Amount + Lin.TrxLin_PeriodValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ElseIf ErnInt.DebitConsol = 2 Then 'Employee Level
            Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = ""
                .Con_Level = 2
                If Is13nt Then
                    If NewInterface Then
                        .Amount = .Amount + Lin.TrxLin_YTDValue
                    Else
                        .Amount = .Amount + Lin.TrxLin_PeriodValue
                    End If
                Else
                    .Amount = .Amount + Lin.TrxLin_PeriodValue
                End If
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                        If HDR.PaymentRef = "" And PARAM_EmpCodeinChequeRef Then
                            .ExternalDoc = Emp.Code
                        End If
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
            If Is13nt Then
                Ds3E = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(Ds3E) Then
                    Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                End If
                With Int3
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = (.Amount + Lin.TrxLin_YTDValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                        If HDR.PaymentRef = "" And PARAM_EmpCodeinChequeRef Then
                            .ExternalDoc = Emp.Code
                        End If
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '                      Leave Provision
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = (.Amount + Lin.TrxLin_PeriodValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ElseIf ErnInt.DebitConsol = 3 Then 'Template Level
            Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = ""
                .EDC_Code = ""
                .Con_Level = 3
                If Is13nt Then
                    If NewInterface Then
                        .Amount = .Amount + Lin.TrxLin_YTDValue
                    Else
                        .Amount = .Amount + Lin.TrxLin_PeriodValue
                    End If
                Else
                    .Amount = .Amount + Lin.TrxLin_PeriodValue
                End If
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                .ExternalDoc = ""
                .IsCheque = ""
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
            If Is13nt Then
                Ds3E = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(Ds3E) Then
                    Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                End If
                With Int3
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = (.Amount + Lin.TrxLin_YTDValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '                      Leave Provision
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", 0)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = (.Amount + Lin.TrxLin_PeriodValue)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If
    End Sub
    Private Sub UpdateTempDEDUCTIONS(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal DedInt As cPrMsDeductionsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal ReasonCode As String)
        Dim Ds As DataSet
        Dim Exx As Exception
        Dim Int As New cPrTmInterface
        Dim A0 As String = ""
        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim AU As String = ""

        Dim A0Pos As Integer = 0
        Dim A1Pos As Integer = 0
        Dim A2Pos As Integer = 0
        Dim A3Pos As Integer = 0
        Dim A4Pos As Integer = 0
        Dim A5Pos As Integer = 0
        Dim AUnionPos As Integer = 0

        Dim i As Integer
        Dim S As String

        ''''''''''''''''''''''''''''''
        '           Credit
        ''''''''''''''''''''''''''''''
        For i = 0 To DedInt.CreditAnal.Length - 1
            S = DedInt.CreditAnal.Substring(i, 1)
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1
                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    A5 = HDR.A5
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        Dim CreditAccount As String
        If DedInt.CreditAccount = "" Then
            'Not Used
            Exit Sub
        End If
        CreditAccount = BuiltAccount(DedInt.CreditAccount, Emp)

        Dim IntCod As New cPrMsInterfaceCodes(DedInt.CreditAccount)

        If DedInt.CreditConsol = 1 Then 'EDC Level
            Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, DedInt.DedCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = Lin.DedCod_Code
                .Con_Level = 1
                .Amount = .Amount - Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf DedInt.CreditConsol = 2 Then 'Employee Level
            Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = ""
                .Con_Level = 2
                .Amount = .Amount - Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf DedInt.CreditConsol = 3 Then 'Template Level
            Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = ""
                .EDC_Code = ""
                .Con_Level = 3
                .Amount = .Amount - Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                .ExternalDoc = ""
                .IsCheque = ""
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        End If
        ''''''''''''''''''''''''''''''
        '           DEBIT
        ''''''''''''''''''''''''''''''
        A0 = ""
        A1 = ""
        A2 = ""
        A3 = ""
        A4 = ""
        A5 = ""
        AU = ""

        A0Pos = 0
        A1Pos = 0
        A2Pos = 0
        A3Pos = 0
        A4Pos = 0
        A5Pos = 0
        AUnionPos = 0

        For i = 0 To DedInt.DebitAnal.Length - 1
            S = DedInt.DebitAnal.Substring(i, 1)
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1
                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    A5 = HDR.A5
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        Dim DebitAccount As String
        DebitAccount = BuiltAccount(DedInt.DebitAccount, Emp)

        IntCod = New cPrMsInterfaceCodes(DedInt.DebitAccount)

        Int = New cPrTmInterface
        If DedInt.DebitConsol = 1 Then 'EDC Level
            Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, DedInt.DedCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = Lin.ConCod_Code
                .Con_Level = 1
                .Amount = .Amount + Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf DedInt.DebitConsol = 2 Then 'Employee Level
            Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = ""
                .Con_Level = 2
                .Amount = .Amount + Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf DedInt.DebitConsol = 3 Then 'Template Level
            Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = ""
                .EDC_Code = ""
                .Con_Level = 3
                .Amount = .Amount + Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                .ExternalDoc = ""
                .IsCheque = ""
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        End If
    End Sub
    Private Sub UpdateTempCONTRIBUTIONS(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal ConInt As cPrMsContributionsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal ReasonCode As String)
        Dim Ds As DataSet
        Dim Exx As Exception
        Dim Int As New cPrTmInterface

        Dim A0 As String = ""
        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim AU As String = ""

        Dim A0Pos As Integer = 0
        Dim A1Pos As Integer = 0
        Dim A2Pos As Integer = 0
        Dim A3Pos As Integer = 0
        Dim A4Pos As Integer = 0
        Dim A5Pos As Integer = 0
        Dim AUnionPos As Integer = 0

        Dim i As Integer
        Dim S As String

        ''''''''''''''''''''''''''''''
        '           Credit
        ''''''''''''''''''''''''''''''
        For i = 0 To ConInt.CreditAnal.Length - 1
            S = ConInt.CreditAnal.Substring(i, 1)
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1
                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    A5 = HDR.A5
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        Dim CreditAccount As String
        If ConInt.CreditAccount = "" Then
            'not used
            Exit Sub
        End If
        CreditAccount = BuiltAccount(ConInt.CreditAccount, Emp)

        Dim IntCod As New cPrMsInterfaceCodes(ConInt.CreditAccount)

        If ConInt.CreditConsol = 1 Then 'EDC Level
            Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ConInt.ConCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = Lin.ConCod_Code
                .Con_Level = 1
                .Amount = .Amount - Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf ConInt.CreditConsol = 2 Then 'Employee Level
            Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = ""
                .Con_Level = 2
                .Amount = .Amount - Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf ConInt.CreditConsol = 3 Then 'Template Level
            Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = CreditAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = ""
                .EDC_Code = ""
                .Con_Level = 3
                .Amount = .Amount - Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                .ExternalDoc = ""
                .IsCheque = ""
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        End If
        ''''''''''''''''''''''''''''''
        '           DEBIT
        ''''''''''''''''''''''''''''''
        A0 = ""
        A1 = ""
        A2 = ""
        A3 = ""
        A4 = ""
        A5 = ""
        AU = ""

        A0Pos = 0
        A1Pos = 0
        A2Pos = 0
        A3Pos = 0
        A4Pos = 0
        A5Pos = 0
        AUnionPos = 0

        For i = 0 To ConInt.DebitAnal.Length - 1
            S = ConInt.DebitAnal.Substring(i, 1)
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1
                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    A5 = HDR.A5
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        Dim DebitAccount As String
        DebitAccount = BuiltAccount(ConInt.DebitAccount, Emp)
        IntCod = New cPrMsInterfaceCodes(ConInt.DebitAccount)

        Int = New cPrTmInterface
        If ConInt.DebitConsol = 1 Then 'EDC Level
            Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ConInt.ConCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = Lin.ConCod_Code
                .Con_Level = 1
                .Amount = .Amount + Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf ConInt.DebitConsol = 2 Then 'Employee Level
            Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = Emp.Code
                .EDC_Code = ""
                .Con_Level = 2
                .Amount = .Amount + Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    .ExternalDoc = ""
                    .IsCheque = ""
                Else
                    If IntCod.AccountType = "3" Then
                        .ExternalDoc = HDR.PaymentRef
                        .IsCheque = "1"
                    Else
                        .ExternalDoc = ""
                        .IsCheque = ""
                    End If
                End If
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        ElseIf ConInt.DebitConsol = 3 Then 'Template Level
            Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", 0)
            If CheckDataSet(Ds) Then
                Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
            End If
            With Int
                .Acc_Code = DebitAccount
                .TemGrp_Code = Emp.TemGrp_Code
                .Emp_Code = ""
                .EDC_Code = ""
                .Con_Level = 3
                .Amount = .Amount + Lin.TrxLin_PeriodValue
                .Anal0 = A0
                .Anal1 = A1
                .Anal2 = A2
                .Anal3 = A3
                .Anal4 = A4
                .Anal5 = A5
                .AnalUnion = AU
                .ExternalDoc = ""
                .IsCheque = ""
                .AccType = IntCod.AccountType
                .Anal0Pos = A0Pos
                .Anal1Pos = A1Pos
                .Anal2Pos = A2Pos
                .Anal3Pos = A3Pos
                .Anal4Pos = A4Pos
                .Anal5Pos = A5Pos
                .AnalUnionPos = AUnionPos
                .BalAccount = "0"
                .ReasonCode = ReasonCode
                If Not .Save Then
                    Throw Exx
                End If
            End With
        End If
    End Sub
    Public Function CheckIfFileExistsOnNav(ByVal RemHost, ByVal RemPath, ByVal FileName, ByVal user, ByVal pwd)
        Dim Flag As Boolean = False
        Dim Msg As String = "File  '" & FileName & "'  Already Exists on Navision ( " & RemPath & " )! Cannot Proceed with Creation Of File!"
        Flag = FTP.CheckIfFileExists(RemHost, RemPath, user, pwd, 21, FileName)
        If Flag Then
            Me.PanelLoading.Visible = False
            Me.PanelLoading.Refresh()
            Me.Refresh()
            If Global1.ShowMessages Then
                MsgBox(Msg, MsgBoxStyle.Information)
            Else
                'Me.ShowError(Msg, "Creating File")
            End If
        End If
        Return Flag
    End Function

    ''=========================================================================================
    'Private Sub UpdateTempEARNINGS_TA(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal ErnInt As cPrMsEarningsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal NewInterface As Boolean, ByVal ReasonCode As String, ByVal TotalHours As Double, ByVal AnalysisHours As Double, ByVal AnalysisCode As String)
    '    Dim Ds As DataSet
    '    Dim Ds3E As DataSet

    '    Dim Exx As Exception
    '    Dim Int As New cPrTmInterface
    '    Dim Int3 As New cPrTmInterface
    '    Dim A0 As String = ""
    '    Dim A1 As String = ""
    '    Dim A2 As String = ""
    '    Dim A3 As String = ""
    '    Dim A4 As String = ""
    '    Dim A5 As String = ""
    '    Dim AU As String = ""
    '    Dim A0Pos As Integer = 0
    '    Dim A1Pos As Integer = 0
    '    Dim A2Pos As Integer = 0
    '    Dim A3Pos As Integer = 0
    '    Dim A4Pos As Integer = 0
    '    Dim A5Pos As Integer = 0
    '    Dim AUnionPos As Integer = 0
    '    Dim i As Integer
    '    Dim S As String

    '    ''''''''''''''''''''''''''''''
    '    '           Credit
    '    ''''''''''''''''''''''''''''''
    '    Dim Ern As New cPrMsEarningCodes(ErnInt.ErnCode)
    '    Dim Is13nt As Boolean = False

    '    If NewInterface Then
    '        If Ern.ErnTypCode = "3E" Then
    '            Is13nt = True
    '        End If
    '    End If

    '    For i = 0 To ErnInt.CreditAnal.Length - 1
    '        S = ErnInt.CreditAnal.Substring(i, 1)
    '        Select Case S
    '            Case 0
    '                A0 = Utils.ClearCharacters(Emp.Code)
    '                A0Pos = i + 1
    '            Case 1
    '                If AnalysisCode = "" Then
    '                    A1 = Emp.EmpAn1_Code
    '                Else
    '                    A1 = AnalysisCode
    '                End If
    '                A1Pos = i + 1
    '            Case 2
    '                If AnalysisCode = "" Then
    '                    A2 = Emp.EmpAn2_Code
    '                Else
    '                    A2 = AnalysisCode
    '                End If
    '                A2Pos = i + 1
    '            Case 3
    '                If AnalysisCode = "" Then
    '                    A3 = Emp.EmpAn3_Code
    '                Else
    '                    A3 = AnalysisCode
    '                End If
    '                A3Pos = i + 1
    '            Case 4
    '                If AnalysisCode = "" Then
    '                    A4 = Emp.EmpAn4_Code
    '                Else
    '                    A4 = AnalysisCode
    '                End If
    '                A4Pos = i + 1
    '            Case 5
    '                If AnalysisCode = "" Then
    '                    A5 = Emp.EmpAn5_Code
    '                Else
    '                    A5 = AnalysisCode
    '                End If
    '                A5Pos = i + 1
    '            Case 6
    '                If AnalysisCode = "" Then
    '                    AU = Emp.Uni_Code
    '                Else
    '                    AU = AnalysisCode
    '                End If
    '                AUnionPos = i + 1

    '        End Select
    '    Next

    '    Dim CreditAccount As String
    '    If ErnInt.CreditAccount = "" Then
    '        'Not Used
    '        Exit Sub
    '    End If

    '    CreditAccount = BuiltAccount(ErnInt.CreditAccount, Emp)

    '    Dim IntCod As New cPrMsInterfaceCodes(ErnInt.CreditAccount)

    '    If ErnInt.CreditConsol = 1 Then 'EDC Level
    '        Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = Lin.ErnCod_Code
    '            .Con_Level = 1
    '            If Is13nt Then
    '                If NewInterface Then
    '                    .Amount = .Amount - RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                Else
    '                    .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                End If
    '            Else
    '                .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            End If
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode

    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '        If Is13nt Then
    '            Ds3E = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1")
    '            If CheckDataSet(Ds3E) Then
    '                Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
    '            End If
    '            With Int3
    '                .Acc_Code = CreditAccount
    '                .TemGrp_Code = Emp.TemGrp_Code
    '                .Emp_Code = Emp.Code
    '                .EDC_Code = Lin.ErnCod_Code
    '                .Con_Level = 1
    '                .Amount = (.Amount - RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                .Anal0 = A0
    '                .Anal1 = A1
    '                .Anal2 = A2
    '                .Anal3 = A3
    '                .Anal4 = A4
    '                .Anal5 = A5
    '                .AnalUnion = AU
    '                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                    .ExternalDoc = ""
    '                    .IsCheque = ""
    '                Else
    '                    .ExternalDoc = HDR.PaymentRef
    '                    .IsCheque = "1"
    '                End If
    '                .AccType = IntCod.AccountType
    '                .Anal0Pos = A0Pos
    '                .Anal1Pos = A1Pos
    '                .Anal2Pos = A2Pos
    '                .Anal3Pos = A3Pos
    '                .Anal4Pos = A4Pos
    '                .Anal5Pos = A5Pos
    '                .AnalUnionPos = AUnionPos
    '                .BalAccount = "1"
    '                .ReasonCode = ReasonCode
    '                If Not .Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '        End If


    '    ElseIf ErnInt.CreditConsol = 2 Then 'Employee Level
    '        Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = ""
    '            .Con_Level = 2
    '            If Is13nt Then
    '                If NewInterface Then
    '                    .Amount = .Amount - RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                Else
    '                    .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                End If
    '            Else
    '                .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            End If
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '        If Is13nt Then
    '            Ds3E = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1")
    '            If CheckDataSet(Ds3E) Then
    '                Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
    '            End If
    '            With Int3
    '                .Acc_Code = CreditAccount
    '                .TemGrp_Code = Emp.TemGrp_Code
    '                .Emp_Code = Emp.Code
    '                .EDC_Code = ""
    '                .Con_Level = 2
    '                .Amount = (.Amount - RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                .Anal0 = A0
    '                .Anal1 = A1
    '                .Anal2 = A2
    '                .Anal3 = A3
    '                .Anal4 = A4
    '                .Anal5 = A5
    '                .AnalUnion = AU
    '                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                    .ExternalDoc = ""
    '                    .IsCheque = ""
    '                Else
    '                    .ExternalDoc = HDR.PaymentRef
    '                    .IsCheque = "1"
    '                End If
    '                .AccType = IntCod.AccountType
    '                .Anal0Pos = A0Pos
    '                .Anal1Pos = A1Pos
    '                .Anal2Pos = A2Pos
    '                .Anal3Pos = A3Pos
    '                .Anal4Pos = A4Pos
    '                .Anal5Pos = A5Pos
    '                .AnalUnionPos = AUnionPos
    '                .BalAccount = "1"
    '                .ReasonCode = ReasonCode
    '                If Not .Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '        End If
    '    ElseIf ErnInt.CreditConsol = 3 Then 'Template Level
    '        Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = ""
    '            .EDC_Code = ""
    '            .Con_Level = 3
    '            If Is13nt Then
    '                If NewInterface Then
    '                    .Amount = .Amount - RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                Else
    '                    .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                End If
    '            Else
    '                Debug.WriteLine(RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                Debug.WriteLine(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2))
    '                Debug.WriteLine(RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours / TotalHours), 2))
    '                Debug.WriteLine(Lin.TrxLin_PeriodValue * AnalysisHours / TotalHours)
    '                .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            End If
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            .ExternalDoc = ""
    '            .IsCheque = ""
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '        If Is13nt Then
    '            Ds3E = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1")
    '            If CheckDataSet(Ds3E) Then
    '                Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
    '            End If
    '            With Int3
    '                .Acc_Code = CreditAccount
    '                .TemGrp_Code = Emp.TemGrp_Code
    '                .Emp_Code = ""
    '                .EDC_Code = ""
    '                .Con_Level = 3
    '                .Amount = (.Amount - RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                .Anal0 = A0
    '                .Anal1 = A1
    '                .Anal2 = A2
    '                .Anal3 = A3
    '                .Anal4 = A4
    '                .Anal5 = A5
    '                .AnalUnion = AU
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '                .AccType = IntCod.AccountType
    '                .Anal0Pos = A0Pos
    '                .Anal1Pos = A1Pos
    '                .Anal2Pos = A2Pos
    '                .Anal3Pos = A3Pos
    '                .Anal4Pos = A4Pos
    '                .Anal5Pos = A5Pos
    '                .AnalUnionPos = AUnionPos
    '                .BalAccount = "1"
    '                .ReasonCode = ReasonCode
    '                If Not .Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '        End If
    '    End If



    '    ''''''''''''''''''''''''''''''
    '    '           DEBIT
    '    ''''''''''''''''''''''''''''''
    '    A0 = ""
    '    A1 = ""
    '    A2 = ""
    '    A3 = ""
    '    A4 = ""
    '    A5 = ""
    '    AU = ""
    '    A0Pos = 0
    '    A1Pos = 0
    '    A2Pos = 0
    '    A3Pos = 0
    '    A4Pos = 0
    '    A5Pos = 0
    '    AUnionPos = 0

    '    For i = 0 To ErnInt.DebitAnal.Length - 1
    '        S = ErnInt.DebitAnal.Substring(i, 1)
    '        Select Case S
    '            Case 0
    '                A0 = Utils.ClearCharacters(Emp.Code)
    '                A0Pos = i + 1
    '            Case 1
    '                If AnalysisCode = "" Then
    '                    A1 = Emp.EmpAn1_Code
    '                Else
    '                    A1 = AnalysisCode
    '                End If
    '                A1Pos = i + 1
    '            Case 2
    '                If AnalysisCode = "" Then
    '                    A2 = Emp.EmpAn2_Code
    '                Else
    '                    A2 = AnalysisCode
    '                End If
    '                A2Pos = i + 1
    '            Case 3
    '                If AnalysisCode = "" Then
    '                    A3 = Emp.EmpAn3_Code
    '                Else
    '                    A3 = AnalysisCode
    '                End If
    '                A3Pos = i + 1
    '            Case 4
    '                If AnalysisCode = "" Then
    '                    A4 = Emp.EmpAn4_Code
    '                Else
    '                    A4 = AnalysisCode
    '                End If
    '                A4Pos = i + 1
    '            Case 5
    '                If AnalysisCode = "" Then
    '                    A5 = Emp.EmpAn5_Code
    '                Else
    '                    A5 = AnalysisCode
    '                End If
    '                A5Pos = i + 1
    '            Case 6
    '                If AnalysisCode = "" Then
    '                    AU = Emp.Uni_Code
    '                Else
    '                    AU = AnalysisCode
    '                End If


    '                AUnionPos = i + 1
    '        End Select
    '    Next
    '    Int = New cPrTmInterface
    '    Int3 = New cPrTmInterface

    '    Dim DebitAccount As String
    '    DebitAccount = BuiltAccount(ErnInt.DebitAccount, Emp)

    '    IntCod = New cPrMsInterfaceCodes(ErnInt.DebitAccount)


    '    If ErnInt.DebitConsol = 1 Then 'EDC Level
    '        Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = Lin.ErnCod_Code
    '            .Con_Level = 1
    '            If Is13nt Then
    '                If NewInterface Then
    '                    .Amount = .Amount + RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                Else
    '                    .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                End If
    '            Else
    '                .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            End If
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode

    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '        If Is13nt Then
    '            Ds3E = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1")
    '            If CheckDataSet(Ds3E) Then
    '                Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
    '            End If
    '            With Int3
    '                .Acc_Code = DebitAccount
    '                .TemGrp_Code = Emp.TemGrp_Code
    '                .Emp_Code = Emp.Code
    '                .EDC_Code = Lin.ErnCod_Code
    '                .Con_Level = 1
    '                .Amount = (.Amount + RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                .Anal0 = A0
    '                .Anal1 = A1
    '                .Anal2 = A2
    '                .Anal3 = A3
    '                .Anal4 = A4
    '                .Anal5 = A5
    '                .AnalUnion = AU
    '                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                    .ExternalDoc = ""
    '                    .IsCheque = ""
    '                Else
    '                    .ExternalDoc = HDR.PaymentRef
    '                    .IsCheque = "1"
    '                End If
    '                .AccType = IntCod.AccountType
    '                .Anal0Pos = A0Pos
    '                .Anal1Pos = A1Pos
    '                .Anal2Pos = A2Pos
    '                .Anal3Pos = A3Pos
    '                .Anal4Pos = A4Pos
    '                .Anal5Pos = A5Pos
    '                .AnalUnionPos = AUnionPos
    '                .BalAccount = "1"
    '                .ReasonCode = ReasonCode
    '                If Not .Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '        End If

    '    ElseIf ErnInt.DebitConsol = 2 Then 'Employee Level
    '        Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = ""
    '            .Con_Level = 2
    '            If Is13nt Then
    '                If NewInterface Then
    '                    .Amount = .Amount + RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                Else
    '                    .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                End If
    '            Else
    '                .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            End If
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '        If Is13nt Then
    '            Ds3E = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1")
    '            If CheckDataSet(Ds3E) Then
    '                Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
    '            End If
    '            With Int3
    '                .Acc_Code = DebitAccount
    '                .TemGrp_Code = Emp.TemGrp_Code
    '                .Emp_Code = Emp.Code
    '                .EDC_Code = ""
    '                .Con_Level = 2
    '                .Amount = (.Amount + RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                .Anal0 = A0
    '                .Anal1 = A1
    '                .Anal2 = A2
    '                .Anal3 = A3
    '                .Anal4 = A4
    '                .Anal5 = A5
    '                .AnalUnion = AU
    '                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                    .ExternalDoc = ""
    '                    .IsCheque = ""
    '                Else
    '                    .ExternalDoc = HDR.PaymentRef
    '                    .IsCheque = "1"
    '                End If
    '                .AccType = IntCod.AccountType
    '                .Anal0Pos = A0Pos
    '                .Anal1Pos = A1Pos
    '                .Anal2Pos = A2Pos
    '                .Anal3Pos = A3Pos
    '                .Anal4Pos = A4Pos
    '                .Anal5Pos = A5Pos
    '                .AnalUnionPos = AUnionPos
    '                .BalAccount = "1"
    '                .ReasonCode = ReasonCode
    '                If Not .Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '        End If
    '    ElseIf ErnInt.DebitConsol = 3 Then 'Template Level
    '        Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = ""
    '            .EDC_Code = ""
    '            .Con_Level = 3
    '            If Is13nt Then
    '                If NewInterface Then
    '                    .Amount = .Amount + RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                Else
    '                    .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '                End If
    '            Else
    '                .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            End If
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            .ExternalDoc = ""
    '            .IsCheque = ""
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '        If Is13nt Then
    '            Ds3E = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1")
    '            If CheckDataSet(Ds3E) Then
    '                Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
    '            End If
    '            With Int3
    '                .Acc_Code = DebitAccount
    '                .TemGrp_Code = Emp.TemGrp_Code
    '                .Emp_Code = ""
    '                .EDC_Code = ""
    '                .Con_Level = 3
    '                .Amount = (.Amount + RoundMe2(Lin.TrxLin_YTDValue * RoundMe2(AnalysisHours / TotalHours, 2), 2))
    '                .Anal0 = A0
    '                .Anal1 = A1
    '                .Anal2 = A2
    '                .Anal3 = A3
    '                .Anal4 = A4
    '                .Anal5 = A5
    '                .AnalUnion = AU
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '                .AccType = IntCod.AccountType
    '                .Anal0Pos = A0Pos
    '                .Anal1Pos = A1Pos
    '                .Anal2Pos = A2Pos
    '                .Anal3Pos = A3Pos
    '                .Anal4Pos = A4Pos
    '                .Anal5Pos = A5Pos
    '                .AnalUnionPos = AUnionPos
    '                .BalAccount = "1"
    '                .ReasonCode = ReasonCode
    '                If Not .Save Then
    '                    Throw Exx
    '                End If
    '            End With
    '        End If
    '    End If
    'End Sub
    'Private Sub UpdateTempDEDUCTIONS_TA(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal DedInt As cPrMsDeductionsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal ReasonCode As String, ByVal TotalHours As Double, ByVal AnalysisHours As Double, ByVal AnalysisCode As String)
    '    Dim Ds As DataSet
    '    Dim Exx As Exception
    '    Dim Int As New cPrTmInterface
    '    Dim A0 As String = ""
    '    Dim A1 As String = ""
    '    Dim A2 As String = ""
    '    Dim A3 As String = ""
    '    Dim A4 As String = ""
    '    Dim A5 As String = ""
    '    Dim AU As String = ""

    '    Dim A0Pos As Integer = 0
    '    Dim A1Pos As Integer = 0
    '    Dim A2Pos As Integer = 0
    '    Dim A3Pos As Integer = 0
    '    Dim A4Pos As Integer = 0
    '    Dim A5Pos As Integer = 0
    '    Dim AUnionPos As Integer = 0

    '    Dim i As Integer
    '    Dim S As String

    '    ''''''''''''''''''''''''''''''
    '    '           Credit
    '    ''''''''''''''''''''''''''''''
    '    For i = 0 To DedInt.CreditAnal.Length - 1
    '        S = DedInt.CreditAnal.Substring(i, 1)
    '        Select Case S
    '            Case 0
    '                A0 = Utils.ClearCharacters(Emp.Code)
    '                A0Pos = i + 1
    '            Case 1
    '                A1 = Emp.EmpAn1_Code
    '                A1Pos = i + 1
    '            Case 2
    '                A2 = Emp.EmpAn2_Code
    '                A2Pos = i + 1
    '            Case 3
    '                A3 = Emp.EmpAn3_Code
    '                A3Pos = i + 1
    '            Case 4
    '                A4 = Emp.EmpAn4_Code
    '                A4Pos = i + 1
    '            Case 5
    '                A5 = Emp.EmpAn5_Code
    '                A5Pos = i + 1
    '            Case 6
    '                AU = Emp.Uni_Code
    '                AUnionPos = i + 1
    '        End Select
    '    Next
    '    Dim CreditAccount As String
    '    If DedInt.CreditAccount = "" Then
    '        'Not Used
    '        Exit Sub
    '    End If
    '    CreditAccount = BuiltAccount(DedInt.CreditAccount, Emp)

    '    Dim IntCod As New cPrMsInterfaceCodes(DedInt.CreditAccount)

    '    If DedInt.CreditConsol = 1 Then 'EDC Level
    '        Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, DedInt.DedCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = Lin.DedCod_Code
    '            .Con_Level = 1
    '            .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf DedInt.CreditConsol = 2 Then 'Employee Level
    '        Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = ""
    '            .Con_Level = 2
    '            .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf DedInt.CreditConsol = 3 Then 'Template Level
    '        Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = ""
    '            .EDC_Code = ""
    '            .Con_Level = 3
    '            .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            .ExternalDoc = ""
    '            .IsCheque = ""
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    End If
    '    ''''''''''''''''''''''''''''''
    '    '           DEBIT
    '    ''''''''''''''''''''''''''''''
    '    A0 = ""
    '    A1 = ""
    '    A2 = ""
    '    A3 = ""
    '    A4 = ""
    '    A5 = ""
    '    AU = ""

    '    A0Pos = 0
    '    A1Pos = 0
    '    A2Pos = 0
    '    A3Pos = 0
    '    A4Pos = 0
    '    A5Pos = 0
    '    AUnionPos = 0

    '    For i = 0 To DedInt.DebitAnal.Length - 1
    '        S = DedInt.DebitAnal.Substring(i, 1)
    '        Select Case S
    '            Case 0
    '                A0 = Utils.ClearCharacters(Emp.Code)
    '                A0Pos = i + 1
    '            Case 1
    '                A1 = Emp.EmpAn1_Code
    '                A1Pos = i + 1
    '            Case 2
    '                A2 = Emp.EmpAn2_Code
    '                A2Pos = i + 1
    '            Case 3
    '                A3 = Emp.EmpAn3_Code
    '                A3Pos = i + 1
    '            Case 4
    '                A4 = Emp.EmpAn4_Code
    '                A4Pos = i + 1
    '            Case 5
    '                A5 = Emp.EmpAn5_Code
    '                A5Pos = i + 1
    '            Case 6
    '                AU = Emp.Uni_Code
    '                AUnionPos = i + 1
    '        End Select
    '    Next
    '    Dim DebitAccount As String
    '    DebitAccount = BuiltAccount(DedInt.DebitAccount, Emp)

    '    IntCod = New cPrMsInterfaceCodes(DedInt.DebitAccount)

    '    Int = New cPrTmInterface
    '    If DedInt.DebitConsol = 1 Then 'EDC Level
    '        Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, DedInt.DedCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = Lin.ConCod_Code
    '            .Con_Level = 1
    '            .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf DedInt.DebitConsol = 2 Then 'Employee Level
    '        Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = ""
    '            .Con_Level = 2
    '            .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf DedInt.DebitConsol = 3 Then 'Template Level
    '        Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = ""
    '            .EDC_Code = ""
    '            .Con_Level = 3
    '            .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            .ExternalDoc = ""
    '            .IsCheque = ""
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    End If
    'End Sub
    'Private Sub UpdateTempCONTRIBUTIONS_TA(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal ConInt As cPrMsContributionsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal ReasonCode As String, ByVal TotalHours As Double, ByVal AnalysisHours As Double, ByVal AnalysisCode As String)
    '    Dim Ds As DataSet
    '    Dim Exx As Exception
    '    Dim Int As New cPrTmInterface

    '    Dim A0 As String = ""
    '    Dim A1 As String = ""
    '    Dim A2 As String = ""
    '    Dim A3 As String = ""
    '    Dim A4 As String = ""
    '    Dim A5 As String = ""
    '    Dim AU As String = ""

    '    Dim A0Pos As Integer = 0
    '    Dim A1Pos As Integer = 0
    '    Dim A2Pos As Integer = 0
    '    Dim A3Pos As Integer = 0
    '    Dim A4Pos As Integer = 0
    '    Dim A5Pos As Integer = 0
    '    Dim AUnionPos As Integer = 0

    '    Dim i As Integer
    '    Dim S As String

    '    ''''''''''''''''''''''''''''''
    '    '           Credit
    '    ''''''''''''''''''''''''''''''
    '    For i = 0 To ConInt.CreditAnal.Length - 1
    '        S = ConInt.CreditAnal.Substring(i, 1)
    '        Select Case S
    '            Case 0
    '                A0 = Utils.ClearCharacters(Emp.Code)
    '                A0Pos = i + 1
    '            Case 1
    '                If AnalysisCode = "" Then
    '                    A1 = Emp.EmpAn1_Code
    '                Else
    '                    A1 = AnalysisCode
    '                End If
    '                A1Pos = i + 1
    '            Case 2
    '                If AnalysisCode = "" Then
    '                    A2 = Emp.EmpAn2_Code
    '                Else
    '                    A2 = AnalysisCode
    '                End If
    '                A2Pos = i + 1
    '            Case 3
    '                If AnalysisCode = "" Then
    '                    A3 = Emp.EmpAn3_Code
    '                Else
    '                    A3 = AnalysisCode
    '                End If
    '                A3Pos = i + 1
    '            Case 4
    '                If AnalysisCode = "" Then
    '                    A4 = Emp.EmpAn4_Code
    '                Else
    '                    A4 = AnalysisCode
    '                End If
    '                A4Pos = i + 1
    '            Case 5
    '                If AnalysisCode = "" Then
    '                    A5 = Emp.EmpAn5_Code
    '                Else
    '                    A5 = AnalysisCode
    '                End If

    '                A5Pos = i + 1
    '            Case 6
    '                If AnalysisCode = "" Then
    '                    AU = Emp.Uni_Code
    '                Else
    '                    AU = AnalysisCode
    '                End If
    '                AUnionPos = i + 1
    '        End Select
    '    Next
    '    Dim CreditAccount As String
    '    If ConInt.CreditAccount = "" Then
    '        'not used
    '        Exit Sub
    '    End If
    '    CreditAccount = BuiltAccount(ConInt.CreditAccount, Emp)

    '    Dim IntCod As New cPrMsInterfaceCodes(ConInt.CreditAccount)

    '    If ConInt.CreditConsol = 1 Then 'EDC Level
    '        Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ConInt.ConCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = Lin.ConCod_Code
    '            .Con_Level = 1
    '            .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf ConInt.CreditConsol = 2 Then 'Employee Level
    '        Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = ""
    '            .Con_Level = 2
    '            .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf ConInt.CreditConsol = 3 Then 'Template Level
    '        Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = CreditAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = ""
    '            .EDC_Code = ""
    '            .Con_Level = 3
    '            .Amount = .Amount - RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            .ExternalDoc = ""
    '            .IsCheque = ""
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    End If
    '    ''''''''''''''''''''''''''''''
    '    '           DEBIT
    '    ''''''''''''''''''''''''''''''
    '    A0 = ""
    '    A1 = ""
    '    A2 = ""
    '    A3 = ""
    '    A4 = ""
    '    A5 = ""
    '    AU = ""

    '    A0Pos = 0
    '    A1Pos = 0
    '    A2Pos = 0
    '    A3Pos = 0
    '    A4Pos = 0
    '    A5Pos = 0
    '    AUnionPos = 0

    '    For i = 0 To ConInt.DebitAnal.Length - 1
    '        S = ConInt.DebitAnal.Substring(i, 1)
    '        Select Case S
    '            Case 0
    '                A0 = Utils.ClearCharacters(Emp.Code)
    '                A0Pos = i + 1
    '            Case 1
    '                If AnalysisCode = "" Then
    '                    A1 = Emp.EmpAn1_Code
    '                Else
    '                    A1 = AnalysisCode
    '                End If
    '                A1Pos = i + 1
    '            Case 2
    '                If AnalysisCode = "" Then
    '                    A2 = Emp.EmpAn2_Code
    '                Else
    '                    A2 = AnalysisCode
    '                End If
    '                A2Pos = i + 1
    '            Case 3
    '                If AnalysisCode = "" Then
    '                    A3 = Emp.EmpAn3_Code
    '                Else
    '                    A3 = AnalysisCode
    '                End If
    '                A3Pos = i + 1
    '            Case 4
    '                If AnalysisCode = "" Then
    '                    A4 = Emp.EmpAn4_Code
    '                Else
    '                    A4 = AnalysisCode
    '                End If
    '                A4Pos = i + 1
    '            Case 5
    '                If AnalysisCode = "" Then
    '                    A5 = Emp.EmpAn5_Code
    '                Else
    '                    A5 = AnalysisCode
    '                End If
    '                A5Pos = i + 1
    '            Case 6
    '                If AnalysisCode = "" Then
    '                    AU = Emp.Uni_Code
    '                Else
    '                    AU = AnalysisCode
    '                End If
    '                AUnionPos = i + 1
    '        End Select
    '    Next
    '    Dim DebitAccount As String
    '    DebitAccount = BuiltAccount(ConInt.DebitAccount, Emp)
    '    IntCod = New cPrMsInterfaceCodes(ConInt.DebitAccount)

    '    Int = New cPrTmInterface
    '    If ConInt.DebitConsol = 1 Then 'EDC Level
    '        Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ConInt.ConCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = Lin.ConCod_Code
    '            .Con_Level = 1
    '            .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf ConInt.DebitConsol = 2 Then 'Employee Level
    '        Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = Emp.Code
    '            .EDC_Code = ""
    '            .Con_Level = 2
    '            .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
    '                .ExternalDoc = ""
    '                .IsCheque = ""
    '            Else
    '                .ExternalDoc = HDR.PaymentRef
    '                .IsCheque = "1"
    '            End If
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    ElseIf ConInt.DebitConsol = 3 Then 'Template Level
    '        Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0")
    '        If CheckDataSet(Ds) Then
    '            Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
    '        End If
    '        With Int
    '            .Acc_Code = DebitAccount
    '            .TemGrp_Code = Emp.TemGrp_Code
    '            .Emp_Code = ""
    '            .EDC_Code = ""
    '            .Con_Level = 3
    '            .Amount = .Amount + RoundMe2(Lin.TrxLin_PeriodValue * RoundMe2(AnalysisHours / TotalHours, 2), 2)
    '            .Anal0 = A0
    '            .Anal1 = A1
    '            .Anal2 = A2
    '            .Anal3 = A3
    '            .Anal4 = A4
    '            .Anal5 = A5
    '            .AnalUnion = AU
    '            .ExternalDoc = ""
    '            .IsCheque = ""
    '            .AccType = IntCod.AccountType
    '            .Anal0Pos = A0Pos
    '            .Anal1Pos = A1Pos
    '            .Anal2Pos = A2Pos
    '            .Anal3Pos = A3Pos
    '            .Anal4Pos = A4Pos
    '            .Anal5Pos = A5Pos
    '            .AnalUnionPos = AUnionPos
    '            .BalAccount = "0"
    '            .ReasonCode = ReasonCode
    '            If Not .Save Then
    '                Throw Exx
    '            End If
    '        End With
    '    End If
    'End Sub
    ''=========================================================================================
    '=========================================================================================
    Private Sub UpdateTempEARNINGS_TA_R1(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal ErnInt As cPrMsEarningsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal NewInterface As Boolean, ByVal ReasonCode As String, ByVal TotalHours As Double, ByVal AnalysisHours As Double, ByVal AnalysisCode As String, ByVal TotalRows As Integer, ByVal currentRow As Integer, ByRef YTDLineTotalUntilNow1 As Double, ByRef PeriodLineTotalUntilNow1 As Double, ByRef YTDLineTotalUntilNow2 As Double, ByRef PeriodLineTotalUntilNow2 As Double, ByRef CreditDone As Boolean, ByRef DebitDone As Boolean, ByVal NoTimeAttendance As Boolean)

        Dim CreditAccount As String
        If ErnInt.CreditAccount = "" Then
            'Not Used
            Exit Sub
        End If

        CreditAccount = BuiltAccount(ErnInt.CreditAccount, Emp)
        Dim IntCod As New cPrMsInterfaceCodes(ErnInt.CreditAccount)
        Dim ThisIsCheque As Integer = 0

        If Not NoTimeAttendance Then
            If IntCod.AccountType <> "0" Then
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = 0
                Else
                    ThisIsCheque = 1
                End If
            End If
        End If


        Dim Ds As DataSet
        Dim Ds3E As DataSet
        Dim DsLP As DataSet

        Dim Exx As Exception
        Dim Int As New cPrTmInterface
        Dim Int3 As New cPrTmInterface
        Dim IntLP As New cPrTmInterface

        Dim A0 As String = ""
        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim AU As String = ""
        Dim A0Pos As Integer = 0
        Dim A1Pos As Integer = 0
        Dim A2Pos As Integer = 0
        Dim A3Pos As Integer = 0
        Dim A4Pos As Integer = 0
        Dim A5Pos As Integer = 0
        Dim AUnionPos As Integer = 0
        Dim i As Integer
        Dim S As String


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''' BEFORE CHANGE '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim YTDValue As Double
        'Dim PeriodValue As Double
        'YTDValue = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours / TotalHours), 2)
        'PeriodValue = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours / TotalHours), 2)

        'YTDLineTotalUntilNow = RoundMe2(YTDLineTotalUntilNow + YTDValue, 2)
        'PeriodLineTotalUntilNow = RoundMe2(PeriodLineTotalUntilNow + PeriodValue, 2)

        'If currentRow = TotalRows Then
        '    If currentRow > 0 Then
        '        Dim Dif As Double
        '        Dif = RoundMe2(Lin.TrxLin_YTDValue - YTDLineTotalUntilNow, 2)
        '        If Dif <> 0 Then
        '            YTDValue = RoundMe2(YTDValue + Dif, 2)
        '        End If
        '        '--------------------------------------------------------
        '        Dif = RoundMe2(Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow, 2)
        '        If Dif <> 0 Then
        '            PeriodValue = RoundMe2(PeriodValue + Dif, 2)
        '        End If
        '    End If
        'End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''' BEFORE CHANGE '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        ''''''''''''''''''''''''''''''
        '           Credit
        ''''''''''''''''''''''''''''''
        Dim Ern As New cPrMsEarningCodes(ErnInt.ErnCode)
        Dim Is13nt As Boolean = False
        Dim IsLP As Boolean = False

        If NewInterface Then
            If Ern.ErnTypCode = "3E" Then
                Is13nt = True
            End If

            If Ern.ErnTypCode = "LP" Then
                IsLP = True
            End If
        End If

        For i = 0 To ErnInt.CreditAnal.Length - 1
            S = ErnInt.CreditAnal.Substring(i, 1)
            'Select Case S
            '    Case 0
            '        A0 = Utils.ClearCharacters(Emp.Code)
            '        A0Pos = i + 1
            '    Case 1
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A1 = HDR.A1
            '        Else
            '            A1 = AnalysisCode
            '        End If
            '        A1Pos = i + 1
            '    Case 2
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A2 = HDR.A2
            '        Else
            '            A2 = AnalysisCode
            '        End If
            '        A2Pos = i + 1
            '    Case 3
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A3 = HDR.A3
            '        Else
            '            A3 = AnalysisCode
            '        End If
            '        A3Pos = i + 1
            '    Case 4
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A4 = HDR.A4
            '        Else
            '            A4 = AnalysisCode
            '        End If
            '        A4Pos = i + 1
            '    Case 5
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A5 = HDR.A5
            '        Else
            '            A5 = AnalysisCode
            '        End If
            '        A5Pos = i + 1
            '    Case 6
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            AU = HDR.Union
            '        Else
            '            AU = AnalysisCode
            '        End If
            '        AUnionPos = i + 1

            'End Select
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1

                    A1 = HDR.A1
                    A1Pos = i + 1
                Case 2
                    A2 = HDR.A2
                    A2Pos = i + 1
                Case 3
                    A3 = HDR.A3
                    A3Pos = i + 1
                Case 4
                    A4 = HDR.A4
                    A4Pos = i + 1
                Case 5
                    If AnalysisCode = "" Or ThisIsCheque = "1" Then
                        A5 = HDR.A5
                    Else
                        A5 = AnalysisCode
                    End If
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1

            End Select
        Next



        'If Emp.Code = "E1639" Then
        '    Debug.WriteLine(1)
        'End If
        '    If A2 = "452" Then

        '    End If
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''' NEW  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim YTDValue1 As Double
        Dim PeriodValue1 As Double
        Dim AnalysisHours1 As Double
        Dim TotalHours1 As Double
        If IntCod.AccountType <> "0" Then
            AnalysisHours1 = 1
            TotalHours1 = 1
        Else
            AnalysisHours1 = AnalysisHours
            TotalHours1 = TotalHours
        End If

        YTDValue1 = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours1 / TotalHours1), 2)
        PeriodValue1 = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours1 / TotalHours1), 2)
        ' If AnalysisHours1 <> TotalHours1 Then
        'Debug.WriteLine("ERN -" & CreditAccount & " - " & Emp.Code & " - " & Lin.TrxLin_PeriodValue & " - " & PeriodValue1)
        'End If
        YTDLineTotalUntilNow1 = RoundMe2(YTDLineTotalUntilNow1 + YTDValue1, 2)
        PeriodLineTotalUntilNow1 = RoundMe2(PeriodLineTotalUntilNow1 + PeriodValue1, 2)

        If currentRow = TotalRows Then
            If currentRow > 0 Then
                Dim Dif As Double
                Dif = Lin.TrxLin_YTDValue - YTDLineTotalUntilNow1
                If Dif <> 0 Then
                    YTDValue1 = RoundMe2(YTDValue1 + Dif, 2)
                End If
                '--------------------------------------------------------
                Dif = Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow1
                If Dif <> 0 Then
                    PeriodValue1 = RoundMe2(PeriodValue1 + Dif, 2)
                End If
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        If Not CreditDone Then



            If ErnInt.CreditConsol = 1 Then 'EDC Level
                Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ErnCod_Code
                    .Con_Level = 1
                    If Is13nt Then
                        If NewInterface Then
                            .Amount = .Amount - YTDValue1
                        Else
                            .Amount = .Amount - PeriodValue1
                        End If
                    Else
                        .Amount = .Amount - PeriodValue1
                    End If
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode

                    If Not .Save Then
                        Throw Exx
                    End If
                End With
                If Is13nt Then
                    Ds3E = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(Ds3E) Then
                        Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                    End If
                    With Int3
                        .Acc_Code = CreditAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = Lin.ErnCod_Code
                        .Con_Level = 1
                        .Amount = (.Amount - YTDValue1)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Leave Provision

                If IsLP Then
                    DsLP = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(DsLP) Then
                        IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                    Else
                        IntLP = New cPrTmInterface()
                    End If
                    With IntLP
                        .Acc_Code = CreditAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = Lin.ErnCod_Code
                        .Con_Level = 1
                        .Amount = (.Amount - PeriodValue1)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ElseIf ErnInt.CreditConsol = 2 Then 'Employee Level
                Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    If Is13nt Then
                        If NewInterface Then
                            .Amount = .Amount - YTDValue1
                        Else
                            .Amount = .Amount - PeriodValue1
                        End If
                    Else
                        .Amount = .Amount - PeriodValue1
                    End If
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
                If Is13nt Then
                    Ds3E = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(Ds3E) Then
                        Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                    End If
                    With Int3
                        .Acc_Code = CreditAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = ""
                        .Con_Level = 2
                        .Amount = (.Amount - YTDValue1)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''Leave Provision '''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If IsLP Then
                    DsLP = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(DsLP) Then
                        IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                    Else
                        IntLP = New cPrTmInterface()
                    End If
                    With IntLP
                        .Acc_Code = CreditAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = ""
                        .Con_Level = 2
                        .Amount = (.Amount - PeriodValue1)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf ErnInt.CreditConsol = 3 Then 'Template Level
                Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    If Is13nt Then
                        If NewInterface Then
                            .Amount = .Amount - YTDValue1
                        Else
                            .Amount = .Amount - PeriodValue1
                        End If
                    Else
                        .Amount = .Amount - PeriodValue1
                    End If
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
                If Is13nt Then
                    Ds3E = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(Ds3E) Then
                        Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                    End If
                    With Int3
                        .Acc_Code = CreditAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = ""
                        .EDC_Code = ""
                        .Con_Level = 3
                        .Amount = (.Amount - YTDValue1)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        .ExternalDoc = ""
                        .IsCheque = ""
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Leave Provision
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If IsLP Then
                DsLP = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                If CheckDataSet(DsLP) Then
                    IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                Else
                    IntLP = New cPrTmInterface()
                End If
                With IntLP
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = (.Amount - PeriodValue1)
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "1"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If IntCod.AccountType <> "0" Then
            CreditDone = True
        End If




        ''''''''''''''''''''''''''''''
        '           DEBIT
        ''''''''''''''''''''''''''''''

        Dim DebitAccount As String
        DebitAccount = BuiltAccount(ErnInt.DebitAccount, Emp)

        IntCod = New cPrMsInterfaceCodes(ErnInt.DebitAccount)
        If Not NoTimeAttendance Then
            If IntCod.AccountType <> "0" Then
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = 0
                Else
                    ThisIsCheque = 1
                End If
            End If
        End If




        A0 = ""
        A1 = ""
        A2 = ""
        A3 = ""
        A4 = ""
        A5 = ""
        AU = ""
        A0Pos = 0
        A1Pos = 0
        A2Pos = 0
        A3Pos = 0
        A4Pos = 0
        A5Pos = 0
        AUnionPos = 0

        For i = 0 To ErnInt.DebitAnal.Length - 1
            S = ErnInt.DebitAnal.Substring(i, 1)
            'Select Case S
            '    Case 0
            '        A0 = Utils.ClearCharacters(Emp.Code)
            '        A0Pos = i + 1
            '    Case 1
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A1 = HDR.A1
            '        Else
            '            A1 = AnalysisCode
            '        End If
            '        A1Pos = i + 1
            '    Case 2
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A2 = HDR.A2
            '        Else
            '            A2 = AnalysisCode
            '        End If
            '        A2Pos = i + 1
            '    Case 3
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A3 = HDR.A3
            '        Else
            '            A3 = AnalysisCode
            '        End If
            '        A3Pos = i + 1
            '    Case 4
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A4 = HDR.A4
            '        Else
            '            A4 = AnalysisCode
            '        End If
            '        A4Pos = i + 1
            '    Case 5
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A5 = HDR.A5
            '        Else
            '            A5 = AnalysisCode
            '        End If
            '        A5Pos = i + 1
            '    Case 6
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            AU = HDR.Union
            '        Else
            '            AU = AnalysisCode
            '        End If


            '        AUnionPos = i + 1
            'End Select
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1

                    A1 = HDR.A1

                    A1Pos = i + 1
                Case 2

                    A2 = HDR.A2

                    A2Pos = i + 1
                Case 3

                    A3 = HDR.A3

                    A3Pos = i + 1
                Case 4

                    A4 = HDR.A4

                    A4Pos = i + 1
                Case 5

                    If AnalysisCode = "" Or ThisIsCheque = "1" Then
                        A5 = HDR.A5
                    Else
                        A5 = AnalysisCode
                    End If
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        Int = New cPrTmInterface
        Int3 = New cPrTmInterface
        IntLP = New cPrTmInterface

        'If DebitAccount = "226001" Then
        '    If A2 = "452" Then
        '        Debug.WriteLine("452")
        '    End If
        '    If A2 = "456" Then
        '        Debug.WriteLine("456")
        '    End If
        'End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''' NEW  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim YTDValue2 As Double
        Dim PeriodValue2 As Double
        Dim AnalysisHours2 As Double
        Dim TotalHours2 As Double

        If IntCod.AccountType <> "0" Then
            AnalysisHours2 = 1
            TotalHours2 = 1
        Else
            AnalysisHours2 = AnalysisHours
            TotalHours2 = TotalHours
        End If

        YTDValue2 = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours2 / TotalHours2), 2)
        PeriodValue2 = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours2 / TotalHours2), 2)

        'If AnalysisHours2 <> TotalHours2 Then
        'Debug.WriteLine("ERN DEB-" & DebitAccount & " - " & Emp.Code & " - " & Lin.TrxLin_PeriodValue & " - " & PeriodValue2)
        '   End If

        YTDLineTotalUntilNow2 = RoundMe2(YTDLineTotalUntilNow2 + YTDValue2, 2)
        PeriodLineTotalUntilNow2 = RoundMe2(PeriodLineTotalUntilNow2 + PeriodValue2, 2)

        If currentRow = TotalRows Then
            If currentRow > 0 Then
                Dim Dif As Double
                Dif = Lin.TrxLin_YTDValue - YTDLineTotalUntilNow2
                If Dif <> 0 Then
                    YTDValue2 = RoundMe2(YTDValue2 + Dif, 2)
                End If
                '--------------------------------------------------------
                Dif = Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow2
                If Dif <> 0 Then
                    PeriodValue2 = RoundMe2(PeriodValue2 + Dif, 2)
                End If
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not DebitDone Then

            If ErnInt.DebitConsol = 1 Then 'EDC Level
                Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ErnCod_Code
                    .Con_Level = 1
                    If Is13nt Then
                        If NewInterface Then
                            .Amount = .Amount + YTDValue2
                        Else
                            .Amount = .Amount + PeriodValue2
                        End If
                    Else
                        .Amount = .Amount + PeriodValue2
                    End If
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode

                    If Not .Save Then
                        Throw Exx
                    End If
                End With
                If Is13nt Then
                    Ds3E = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(Ds3E) Then
                        Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                    End If
                    With Int3
                        .Acc_Code = DebitAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = Lin.ErnCod_Code
                        .Con_Level = 1
                        .Amount = (.Amount + YTDValue2)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '                      Leave Provision
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsLP Then
                    DsLP = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ErnInt.ErnCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(DsLP) Then
                        IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                    Else
                        IntLP = New cPrTmInterface()
                    End If
                    With IntLP
                        .Acc_Code = DebitAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = Lin.ErnCod_Code
                        .Con_Level = 1
                        .Amount = (.Amount + PeriodValue2)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf ErnInt.DebitConsol = 2 Then 'Employee Level
                Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    If Is13nt Then
                        If NewInterface Then
                            .Amount = .Amount + YTDValue2
                        Else
                            .Amount = .Amount + PeriodValue2
                        End If
                    Else
                        .Amount = .Amount + PeriodValue2
                    End If
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
                If Is13nt Then
                    Ds3E = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(Ds3E) Then
                        Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                    End If
                    With Int3
                        .Acc_Code = DebitAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = ""
                        .Con_Level = 2
                        .Amount = (.Amount + YTDValue2)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '                      Leave Provision
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsLP Then
                    DsLP = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(DsLP) Then
                        IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                    Else
                        IntLP = New cPrTmInterface()
                    End If
                    With IntLP
                        .Acc_Code = DebitAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = Emp.Code
                        .EDC_Code = ""
                        .Con_Level = 2
                        .Amount = (.Amount + PeriodValue2)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                            .ExternalDoc = ""
                            .IsCheque = ""
                        Else
                            If IntCod.AccountType = "3" Then
                                .ExternalDoc = HDR.PaymentRef
                                .IsCheque = "1"
                            Else
                                .ExternalDoc = ""
                                .IsCheque = ""
                            End If
                        End If
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf ErnInt.DebitConsol = 3 Then 'Template Level
                Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    If Is13nt Then
                        If NewInterface Then
                            .Amount = .Amount + YTDValue2
                        Else
                            .Amount = .Amount + PeriodValue2
                        End If
                    Else
                        .Amount = .Amount + PeriodValue2
                    End If
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
                If Is13nt Then
                    Ds3E = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(Ds3E) Then
                        Int3 = New cPrTmInterface(Ds3E.Tables(0).Rows(0))
                    End If
                    With Int3
                        .Acc_Code = DebitAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = ""
                        .EDC_Code = ""
                        .Con_Level = 3
                        .Amount = (.Amount + YTDValue2)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        .ExternalDoc = ""
                        .IsCheque = ""
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '                      Leave Provision
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If IsLP Then
                    DsLP = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "1", ThisIsCheque)
                    If CheckDataSet(DsLP) Then
                        IntLP = New cPrTmInterface(DsLP.Tables(0).Rows(0))
                    Else
                        IntLP = New cPrTmInterface()
                    End If
                    With IntLP
                        .Acc_Code = DebitAccount
                        .TemGrp_Code = Emp.TemGrp_Code
                        .Emp_Code = ""
                        .EDC_Code = ""
                        .Con_Level = 3
                        .Amount = (.Amount + PeriodValue2)
                        .Anal0 = A0
                        .Anal1 = A1
                        .Anal2 = A2
                        .Anal3 = A3
                        .Anal4 = A4
                        .Anal5 = A5
                        .AnalUnion = AU
                        .ExternalDoc = ""
                        .IsCheque = ""
                        .AccType = IntCod.AccountType
                        .Anal0Pos = A0Pos
                        .Anal1Pos = A1Pos
                        .Anal2Pos = A2Pos
                        .Anal3Pos = A3Pos
                        .Anal4Pos = A4Pos
                        .Anal5Pos = A5Pos
                        .AnalUnionPos = AUnionPos
                        .BalAccount = "1"
                        .ReasonCode = ReasonCode
                        If Not .Save Then
                            Throw Exx
                        End If
                    End With
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            If IntCod.AccountType <> "0" Then
                DebitDone = True
            End If
        End If
    End Sub
    Private Sub UpdateTempDEDUCTIONS_TA_R1(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal DedInt As cPrMsDeductionsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal ReasonCode As String, ByVal TotalHours As Double, ByVal AnalysisHours As Double, ByVal AnalysisCode As String, ByVal TotalRows As Integer, ByVal currentRow As Integer, ByRef PeriodLineTotalUntilNow1 As Double, ByRef PeriodLineTotalUntilNow2 As Double, ByRef CreditDone As Boolean, ByVal DebitDone As Boolean, ByVal NoTimeAttendance As Boolean)
        Dim Ds As DataSet
        Dim Exx As Exception
        Dim Int As New cPrTmInterface
        Dim A0 As String = ""
        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim AU As String = ""

        Dim A0Pos As Integer = 0
        Dim A1Pos As Integer = 0
        Dim A2Pos As Integer = 0
        Dim A3Pos As Integer = 0
        Dim A4Pos As Integer = 0
        Dim A5Pos As Integer = 0
        Dim AUnionPos As Integer = 0

        Dim i As Integer
        Dim S As String
        'If Emp.Code = "E1639" Then
        '    Debug.WriteLine(1)
        'End If
        Dim ThisIsCheque As Integer = 0

        Dim CreditAccount As String
        CreditAccount = BuiltAccount(DedInt.CreditAccount, Emp)
        Dim IntCod As New cPrMsInterfaceCodes(DedInt.CreditAccount)

        If Not NoTimeAttendance Then
            If IntCod.AccountType <> "0" Then
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = 0
                Else
                    ThisIsCheque = 1
                End If
            End If
        End If



        ''''''''''''''''''''''''''''''
        '           Credit
        ''''''''''''''''''''''''''''''
        For i = 0 To DedInt.CreditAnal.Length - 1
            S = DedInt.CreditAnal.Substring(i, 1)
            'Select Case S
            '    Case 0
            '        A0 = Utils.ClearCharacters(Emp.Code)
            '        A0Pos = i + 1
            '    Case 1
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A1 = HDR.A1
            '        Else
            '            A1 = AnalysisCode
            '        End If
            '        A1Pos = i + 1
            '    Case 2
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A2 = HDR.A2
            '        Else
            '            A2 = AnalysisCode
            '        End If
            '        A2Pos = i + 1
            '    Case 3
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A3 = HDR.A3
            '        Else
            '            A3 = AnalysisCode
            '        End If
            '        A3Pos = i + 1
            '    Case 4
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A4 = HDR.A4
            '        Else
            '            A4 = AnalysisCode
            '        End If
            '        A4Pos = i + 1
            '    Case 5
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A5 = HDR.A5
            '        Else
            '            A5 = AnalysisCode
            '        End If

            '        A5Pos = i + 1
            '    Case 6
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            AU = HDR.Union
            '        Else
            '            AU = AnalysisCode
            '        End If
            '        AUnionPos = i + 1
            'End Select
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1

                    A1 = HDR.A1

                    A1Pos = i + 1
                Case 2

                    A2 = HDR.A2

                    A2Pos = i + 1
                Case 3

                    A3 = HDR.A3

                    A3Pos = i + 1
                Case 4

                    A4 = HDR.A4

                    A4Pos = i + 1
                Case 5

                    If AnalysisCode = "" Or ThisIsCheque = "1" Then
                        A5 = HDR.A5
                    Else
                        A5 = AnalysisCode
                    End If
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        'Dim CreditAccount As String
        If DedInt.CreditAccount = "" Then
            'Not Used
            Exit Sub
        End If

        ' CreditAccount = BuiltAccount(DedInt.CreditAccount, Emp)
        ' Dim IntCod As New cPrMsInterfaceCodes(DedInt.CreditAccount)

        'If CreditAccount = "226001" Then
        '    If A2 = "452" Then
        '        Debug.WriteLine("452")
        '    End If
        '    If A2 = "456" Then
        '        Debug.WriteLine("456")
        '    End If
        'End If
        '---------------------------------------------------------------------------------------------------------------
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''' NEW  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim YTDValue1 As Double
        Dim PeriodValue1 As Double
        Dim AnalysisHours1 As Double
        Dim TotalHours1 As Double

        If IntCod.AccountType <> "0" Then
            AnalysisHours1 = 1
            TotalHours1 = 1
        Else
            AnalysisHours1 = AnalysisHours
            TotalHours1 = TotalHours
        End If

        ' YTDValue = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours / TotalHours), 2)
        PeriodValue1 = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours1 / TotalHours1), 2)

        If AnalysisHours1 <> TotalHours1 Then
            Debug.WriteLine(Emp.Code & "-" & CreditAccount & " - " & Lin.TrxLin_PeriodValue & " - " & PeriodValue1)
        End If

        PeriodLineTotalUntilNow1 = RoundMe2(PeriodLineTotalUntilNow1 + PeriodValue1, 2)

        If currentRow = TotalRows Then
            If currentRow > 0 Then
                Dim Dif As Double
                Dif = Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow1
                If Dif <> 0 Then
                    PeriodValue1 = RoundMe2(PeriodValue1 + Dif, 2)
                End If
            End If
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        '------------------------------------------------------------------------------------------------------


        If Not CreditDone Then
            If DedInt.CreditConsol = 1 Then 'EDC Level
                Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, DedInt.DedCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.DedCod_Code
                    .Con_Level = 1
                    .Amount = .Amount - PeriodValue1
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf DedInt.CreditConsol = 2 Then 'Employee Level
                Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)


                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = False
                Else
                    ThisIsCheque = True
                End If
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = .Amount - PeriodValue1
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf DedInt.CreditConsol = 3 Then 'Template Level
                Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = .Amount - PeriodValue1
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If

            If IntCod.AccountType <> "0" Then
                CreditDone = True
            End If
        End If
        ''''''''''''''''''''''''''''''
        '           DEBIT
        ''''''''''''''''''''''''''''''
        Dim DebitAccount As String
        DebitAccount = BuiltAccount(DedInt.DebitAccount, Emp)

        IntCod = New cPrMsInterfaceCodes(DedInt.DebitAccount)
        If Not NoTimeAttendance Then
            If IntCod.AccountType <> "0" Then
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = 0
                Else
                    ThisIsCheque = 1
                End If
            End If
        End If


        A0 = ""
        A1 = ""
        A2 = ""
        A3 = ""
        A4 = ""
        A5 = ""
        AU = ""

        A0Pos = 0
        A1Pos = 0
        A2Pos = 0
        A3Pos = 0
        A4Pos = 0
        A5Pos = 0
        AUnionPos = 0

        For i = 0 To DedInt.DebitAnal.Length - 1
            S = DedInt.DebitAnal.Substring(i, 1)

            'Select Case S
            '    Case 0
            '        A0 = Utils.ClearCharacters(Emp.Code)
            '        A0Pos = i + 1
            '    Case 1
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A1 = HDR.A1
            '        Else
            '            A1 = AnalysisCode
            '        End If
            '        A1Pos = i + 1
            '    Case 2
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A2 = HDR.A2
            '        Else
            '            A2 = AnalysisCode
            '        End If
            '        A2Pos = i + 1
            '    Case 3
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A3 = HDR.A3
            '        Else
            '            A3 = AnalysisCode
            '        End If
            '        A3Pos = i + 1
            '    Case 4
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A4 = HDR.A4
            '        Else
            '            A4 = AnalysisCode
            '        End If
            '        A4Pos = i + 1
            '    Case 5
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A5 = HDR.A5
            '        Else
            '            A5 = AnalysisCode
            '        End If

            '        A5Pos = i + 1
            '    Case 6
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            AU = HDR.Union
            '        Else
            '            AU = AnalysisCode
            '        End If
            '        AUnionPos = i + 1
            'End Select
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1

                    A1 = HDR.A1

                    A1Pos = i + 1
                Case 2

                    A2 = HDR.A2

                    A2Pos = i + 1
                Case 3

                    A3 = HDR.A3

                    A3Pos = i + 1
                Case 4

                    A4 = HDR.A4

                    A4Pos = i + 1
                Case 5

                    If AnalysisCode = "" Or ThisIsCheque = "1" Then
                        A5 = HDR.A5
                    Else
                        A5 = AnalysisCode
                    End If
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        'savvas
        'Dim DebitAccount As String
        'DebitAccount = BuiltAccount(DedInt.DebitAccount, Emp)

        'IntCod = New cPrMsInterfaceCodes(DedInt.DebitAccount)
        'end

        'If DebitAccount = "226001" Then
        '    If A2 = "452" Then
        '        Debug.WriteLine("452")
        '    End If
        '    If A2 = "456" Then
        '        Debug.WriteLine("456")
        '    End If
        'End If
        '-----------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------
        Dim YTDValue2 As Double
        Dim PeriodValue2 As Double
        Dim AnalysisHours2 As Double
        Dim TotalHours2 As Double

        If IntCod.AccountType <> "0" Then
            AnalysisHours2 = 1
            TotalHours2 = 1
        Else
            AnalysisHours2 = AnalysisHours
            TotalHours2 = TotalHours
        End If

        ' YTDValue = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours / TotalHours), 2)
        PeriodValue2 = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours2 / TotalHours2), 2)

        PeriodLineTotalUntilNow2 = RoundMe2(PeriodLineTotalUntilNow2 + PeriodValue2, 2)

        If currentRow = TotalRows Then
            If currentRow > 0 Then
                Dim Dif As Double
                Dif = Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow2
                If Dif <> 0 Then
                    PeriodValue2 = RoundMe2(PeriodValue2 + Dif, 2)
                End If
            End If
        End If
        '---------------------------
        '-----------------------------------------------------------------------------------------------
        If Not DebitDone Then

            Int = New cPrTmInterface
            If DedInt.DebitConsol = 1 Then 'EDC Level
                Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, DedInt.DedCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ConCod_Code
                    .Con_Level = 1
                    .Amount = .Amount + PeriodValue2
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf DedInt.DebitConsol = 2 Then 'Employee Level
                Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = .Amount + PeriodValue2
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf DedInt.DebitConsol = 3 Then 'Template Level
                Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = .Amount + PeriodValue2
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            If IntCod.AccountType <> "0" Then
                DebitDone = True

            End If
        End If
    End Sub
    Private Sub UpdateTempCONTRIBUTIONS_TA_R1(ByVal Emp As cPrMsEmployees, ByVal Lin As cPrTxTrxnLines, ByVal ConInt As cPrMsContributionsInterface, ByVal HDR As cPrTxTrxnHeader, ByVal ReasonCode As String, ByVal TotalHours As Double, ByVal AnalysisHours As Double, ByVal AnalysisCode As String, ByVal TotalRows As Integer, ByVal currentRow As Integer, ByRef PeriodLineTotalUntilNow1 As Double, ByRef PeriodLineTotalUntilNow2 As Double, ByRef CreditDone As Boolean, ByRef DebitDone As Boolean, ByVal NoTimeAttendance As Boolean)
        Dim Ds As DataSet
        Dim Exx As Exception
        Dim Int As New cPrTmInterface

        Dim A0 As String = ""
        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim AU As String = ""

        Dim A0Pos As Integer = 0
        Dim A1Pos As Integer = 0
        Dim A2Pos As Integer = 0
        Dim A3Pos As Integer = 0
        Dim A4Pos As Integer = 0
        Dim A5Pos As Integer = 0
        Dim AUnionPos As Integer = 0

        Dim i As Integer
        Dim S As String

        Dim ThisIsCheque As Integer = 0

        Dim CreditAccount As String
        CreditAccount = BuiltAccount(ConInt.CreditAccount, Emp)
        Dim IntCod As New cPrMsInterfaceCodes(ConInt.CreditAccount)

        If Not NoTimeAttendance Then
            If IntCod.AccountType <> "0" Then
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = 0
                Else
                    ThisIsCheque = 1
                End If
            End If
        End If
        ''''''''''''''''''''''''''''''
        '           Credit
        ''''''''''''''''''''''''''''''
        'If Emp.Code = "E1478" Then
        '    MsgBox(1)
        'End If
        For i = 0 To ConInt.CreditAnal.Length - 1
            S = ConInt.CreditAnal.Substring(i, 1)
            'Select Case S
            '    Case 0
            '        A0 = Utils.ClearCharacters(Emp.Code)
            '        A0Pos = i + 1
            '    Case 1
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A1 = HDR.A1
            '        Else
            '            A1 = AnalysisCode
            '        End If
            '        A1Pos = i + 1
            '    Case 2
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A2 = HDR.A2
            '        Else
            '            A2 = AnalysisCode
            '        End If
            '        A2Pos = i + 1
            '    Case 3
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A3 = HDR.A3
            '        Else
            '            A3 = AnalysisCode
            '        End If
            '        A3Pos = i + 1
            '    Case 4
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A4 = HDR.A4
            '        Else
            '            A4 = AnalysisCode
            '        End If
            '        A4Pos = i + 1
            '    Case 5
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A5 = HDR.A5
            '        Else
            '            A5 = AnalysisCode
            '        End If

            '        A5Pos = i + 1
            '    Case 6
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            AU = HDR.Union
            '        Else
            '            AU = AnalysisCode
            '        End If
            '        AUnionPos = i + 1
            'End Select
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1

                    A1 = HDR.A1

                    A1Pos = i + 1
                Case 2

                    A2 = HDR.A2

                    A2Pos = i + 1
                Case 3

                    A3 = HDR.A3

                    A3Pos = i + 1
                Case 4

                    A4 = HDR.A4

                    A4Pos = i + 1
                Case 5

                    If AnalysisCode = "" Or ThisIsCheque = "1" Then
                        A5 = HDR.A5
                    Else
                        A5 = AnalysisCode
                    End If
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next

        'Dim CreditAccount As String
        'If ConInt.CreditAccount = "" Then
        '    'not used
        '    Exit Sub
        'End If
        'CreditAccount = BuiltAccount(ConInt.CreditAccount, Emp)

        'Dim IntCod As New cPrMsInterfaceCodes(ConInt.CreditAccount)

        '-------------------------------------------------------------------------------------------
        Dim YTDValue1 As Double
        Dim PeriodValue1 As Double
        Dim AnalysisHours1 As Double
        Dim TotalHours1 As Double

        If IntCod.AccountType <> "0" Then
            AnalysisHours1 = 1
            TotalHours1 = 1
        Else
            AnalysisHours1 = AnalysisHours
            TotalHours1 = TotalHours
        End If

        ' YTDValue = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours / TotalHours), 2)
        PeriodValue1 = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours1 / TotalHours1), 2)
        If AnalysisHours1 <> TotalHours1 Then
            Debug.WriteLine("CON" & "-" & CreditAccount & " - " & Emp.Code & " - " & Lin.TrxLin_PeriodValue & " - " & PeriodValue1)
        End If
        PeriodLineTotalUntilNow1 = RoundMe2(PeriodLineTotalUntilNow1 + PeriodValue1, 2)

        If currentRow = TotalRows Then
            If currentRow > 0 Then
                Dim Dif As Double
                Dif = Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow1
                If Dif <> 0 Then
                    PeriodValue1 = RoundMe2(PeriodValue1 + Dif, 2)
                End If
            End If
        End If
        '----------------------------------------------------------------------------------------------

        If Not CreditDone Then


            If ConInt.CreditConsol = 1 Then 'EDC Level
                Ds = Global1.Business.FindTempInterfaceLevel1(CreditAccount, ConInt.ConCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ConCod_Code
                    .Con_Level = 1
                    .Amount = .Amount - PeriodValue1

                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf ConInt.CreditConsol = 2 Then 'Employee Level
                Ds = Global1.Business.FindTempInterfaceLevel2(CreditAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = .Amount - PeriodValue1
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf ConInt.CreditConsol = 3 Then 'Template Level
                Ds = Global1.Business.FindTempInterfaceLevel3(CreditAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = CreditAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = .Amount - PeriodValue1
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            If IntCod.AccountType <> "0" Then
                CreditDone = True
            End If
        End If
        ''''''''''''''''''''''''''''''
        '           DEBIT
        ''''''''''''''''''''''''''''''
        Dim DebitAccount As String
        DebitAccount = BuiltAccount(ConInt.DebitAccount, Emp)

        IntCod = New cPrMsInterfaceCodes(ConInt.DebitAccount)
        If Not NoTimeAttendance Then
            If IntCod.AccountType <> "0" Then
                If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                    ThisIsCheque = 0
                Else
                    ThisIsCheque = 1
                End If
            End If
        End If
        A0 = ""
        A1 = ""
        A2 = ""
        A3 = ""
        A4 = ""
        A5 = ""
        AU = ""

        A0Pos = 0
        A1Pos = 0
        A2Pos = 0
        A3Pos = 0
        A4Pos = 0
        A5Pos = 0
        AUnionPos = 0

        For i = 0 To ConInt.DebitAnal.Length - 1
            S = ConInt.DebitAnal.Substring(i, 1)
            'Select Case S
            '    Case 0
            '        A0 = Utils.ClearCharacters(Emp.Code)
            '        A0Pos = i + 1
            '    Case 1
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A1 = HDR.A1
            '        Else
            '            A1 = AnalysisCode
            '        End If
            '        A1Pos = i + 1
            '    Case 2
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A2 = HDR.A2
            '        Else
            '            A2 = AnalysisCode
            '        End If
            '        A2Pos = i + 1
            '    Case 3
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A3 = HDR.A3
            '        Else
            '            A3 = AnalysisCode
            '        End If
            '        A3Pos = i + 1
            '    Case 4
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A4 = HDR.A4
            '        Else
            '            A4 = AnalysisCode
            '        End If
            '        A4Pos = i + 1
            '    Case 5
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            A5 = HDR.A5
            '        Else
            '            A5 = AnalysisCode
            '        End If
            '        A5Pos = i + 1
            '    Case 6
            '        If AnalysisCode = "" Or ThisIsCheque = "1" Then
            '            AU = HDR.Union
            '        Else
            '            AU = AnalysisCode
            '        End If
            '        AUnionPos = i + 1
            'End Select
            Select Case S
                Case 0
                    A0 = Utils.ClearCharacters(Emp.Code)
                    A0Pos = i + 1
                Case 1

                    A1 = HDR.A1

                    A1Pos = i + 1
                Case 2

                    A2 = HDR.A2

                    A2Pos = i + 1
                Case 3

                    A3 = HDR.A3

                    A3Pos = i + 1
                Case 4

                    A4 = HDR.A4

                    A4Pos = i + 1
                Case 5

                    If AnalysisCode = "" Or ThisIsCheque = "1" Then
                        A5 = HDR.A5
                    Else
                        A5 = AnalysisCode
                    End If
                    A5Pos = i + 1
                Case 6
                    AU = HDR.Union
                    AUnionPos = i + 1
            End Select
        Next
        'Dim DebitAccount As String
        'DebitAccount = BuiltAccount(ConInt.DebitAccount, Emp)
        'IntCod = New cPrMsInterfaceCodes(ConInt.DebitAccount)


        '-------------------------------------------------------------------------------------------
        Dim YTDValue2 As Double
        Dim PeriodValue2 As Double
        Dim AnalysisHours2 As Double
        Dim TotalHours2 As Double

        If IntCod.AccountType <> "0" Then
            AnalysisHours2 = 1
            TotalHours2 = 1
        Else
            AnalysisHours2 = AnalysisHours
            TotalHours2 = TotalHours
        End If

        ' YTDValue = RoundMe2(Lin.TrxLin_YTDValue * (AnalysisHours / TotalHours), 2)
        PeriodValue2 = RoundMe2(Lin.TrxLin_PeriodValue * (AnalysisHours2 / TotalHours2), 2)

        PeriodLineTotalUntilNow2 = RoundMe2(PeriodLineTotalUntilNow2 + PeriodValue2, 2)

        If currentRow = TotalRows Then
            If currentRow > 0 Then
                Dim Dif As Double
                Dif = Lin.TrxLin_PeriodValue - PeriodLineTotalUntilNow2
                If Dif <> 0 Then
                    PeriodValue2 = RoundMe2(PeriodValue2 + Dif, 2)
                End If
            End If
        End If
        'If PeriodValue2 <> PeriodValue1 Then
        '    Debug.WriteLine("x")
        'End If
        '----------------------------------------------------------------------------------------------
        'If DebitAccount = "226003" Or DebitAccount = "226004" Then
        '    If PeriodValue2 = 2.22 Or PeriodValue2 = 8.88 Then
        '        Debug.WriteLine("x")
        '    End If
        'End If
        If Not DebitDone Then

            Int = New cPrTmInterface
            If ConInt.DebitConsol = 1 Then 'EDC Level
                Ds = Global1.Business.FindTempInterfaceLevel1(DebitAccount, ConInt.ConCode, Emp.Code, Emp.TemGrp_Code, "1", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)
                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = Lin.ConCod_Code
                    .Con_Level = 1
                    .Amount = .Amount + PeriodValue2
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf ConInt.DebitConsol = 2 Then 'Employee Level
                Ds = Global1.Business.FindTempInterfaceLevel2(DebitAccount, Emp.Code, Emp.TemGrp_Code, "2", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = Emp.Code
                    .EDC_Code = ""
                    .Con_Level = 2
                    .Amount = .Amount + PeriodValue2
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    If Trim(HDR.PaymentRef) = "PAY REF" Or HDR.PaymentRef = "" Then
                        .ExternalDoc = ""
                        .IsCheque = ""
                    Else
                        If IntCod.AccountType = "3" Then
                            .ExternalDoc = HDR.PaymentRef
                            .IsCheque = "1"
                        Else
                            .ExternalDoc = ""
                            .IsCheque = ""
                        End If
                    End If
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            ElseIf ConInt.DebitConsol = 3 Then 'Template Level
                Ds = Global1.Business.FindTempInterfaceLevel3(DebitAccount, Emp.TemGrp_Code, "3", A0, A1, A2, A3, A4, A5, AU, "0", ThisIsCheque)

                If CheckDataSet(Ds) Then
                    Int = New cPrTmInterface(Ds.Tables(0).Rows(0))
                End If
                With Int
                    .Acc_Code = DebitAccount
                    .TemGrp_Code = Emp.TemGrp_Code
                    .Emp_Code = ""
                    .EDC_Code = ""
                    .Con_Level = 3
                    .Amount = .Amount + PeriodValue2
                    .Anal0 = A0
                    .Anal1 = A1
                    .Anal2 = A2
                    .Anal3 = A3
                    .Anal4 = A4
                    .Anal5 = A5
                    .AnalUnion = AU
                    .ExternalDoc = ""
                    .IsCheque = ""
                    .AccType = IntCod.AccountType
                    .Anal0Pos = A0Pos
                    .Anal1Pos = A1Pos
                    .Anal2Pos = A2Pos
                    .Anal3Pos = A3Pos
                    .Anal4Pos = A4Pos
                    .Anal5Pos = A5Pos
                    .AnalUnionPos = AUnionPos
                    .BalAccount = "0"
                    .ReasonCode = ReasonCode
                    If Not .Save Then
                        Throw Exx
                    End If
                End With
            End If
            If IntCod.AccountType <> "0" Then
                DebitDone = True
            End If
        End If
    End Sub
    '=========================================================================================

    'Public Sub Send_WriteToNavFile(ByVal Hdr As cPrTxTrxnHeader, ByVal Line As cPrTxTrxnLines, ByVal DsDetails As DataSet, ByVal TmpGrp As cPrMsTemplateGroup, ByRef LineCounter As Integer, ByVal Prd As cPrMsPeriodCodes, ByVal Fname As String)


    '    Dim Str As String
    '    Dim DebitAcc As String = ""
    '    Dim CreditAcc As String = ""
    '    Dim PerGrp As New cPrMsPeriodGroups(Hdr.PrdGrp_Code)
    '    If Line.TrxLin_Type = "E" Then
    '        Dim TemErn As New cPrMsTemplateEarnings(PerGrp.TemGrpCode, Line.ErnCod_Code)
    '        DebitAcc = TemErn.NavDebitAccount
    '        CreditAcc = TemErn.NavCreditAccount
    '    ElseIf Line.TrxLin_Type = "D" Then
    '        Dim TemDed As New cPrMsTemplateDeductions(PerGrp.TemGrpCode, Line.DedCod_Code)
    '        DebitAcc = TemDed.NavDebitAccount
    '        CreditAcc = TemDed.NavCreditAccount
    '    ElseIf Line.TrxLin_Type = "C" Then
    '        Dim TemCon As New cPrMsTemplateContributions(PerGrp.TemGrpCode, Line.ConCod_Code)
    '        DebitAcc = TemCon.NavDebitAccount
    '        CreditAcc = TemCon.NavCreditAccount
    '    End If

    '    Str = ClearChars((TmpGrp.GLAnl1))
    '    Str = Str & "|" & ClearChars(TmpGrp.GLAnl2)
    '    Str = Str & "|" & LineCounter
    '    Str = Str & "|" & Format(Hdr.MyDate, "yyyy-MM-dd")
    '    Str = Str & "|" & "0"
    '    Str = Str & "|" & ClearChars(DebitAcc)
    '    Str = Str & "|" & ClearChars(Hdr.PrdCod_Code & Hdr.Emp_Code)
    '    Str = Str & "|" & ClearChars(Line.TrxLin_EDCDescription)
    '    Str = Str & "|" & Format(Line.TrxLin_PeriodValue, "0.00")
    '    Str = Str & "|" & "0.00"
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(0)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(1)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(2)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(3)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(4)))
    '    Str = Str & "|" & "0"
    '    Str = Str & "|" & "0"

    '    WriteToNavisionFile(Str, Fname)
    '    LineCounter = LineCounter + 1

    '    Str = ClearChars((TmpGrp.GLAnl1))
    '    Str = Str & "|" & ClearChars(TmpGrp.GLAnl2)
    '    Str = Str & "|" & LineCounter
    '    Str = Str & "|" & Format(Hdr.MyDate, "yyyy-MM-dd")
    '    Str = Str & "|" & "0"
    '    Str = Str & "|" & ClearChars(CreditAcc)
    '    Str = Str & "|" & ClearChars(Hdr.PrdCod_Code & Hdr.Emp_Code)
    '    Str = Str & "|" & ClearChars(Line.TrxLin_EDCDescription)
    '    Str = Str & "|" & "0.00"
    '    Str = Str & "|" & Format(Line.TrxLin_PeriodValue, "0.00")
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(0)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(1)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(2)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(3)))
    '    Str = Str & "|" & ClearChars(DbNullToString(DsDetails.Tables(0).Rows(0).Item(4)))
    '    Str = Str & "|" & "0"
    '    Str = Str & "|" & "0"


    '    WriteToNavisionFile(Str, Fname)
    '    LineCounter = LineCounter + 1

    '    System.Windows.Forms.Application.DoEvents()
    'End Sub
    Public Function Send_WriteToNavFile(ByVal TmpGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Fname As String, ByVal InterfaceType As String) As Boolean
        Dim ds As DataSet
        Dim i As Integer
        Dim Str As String
        Dim Flag As Boolean = False
        InitFile = True
        ds = Global1.Business.GetAllPrTmInterface(TmpGrp.Code)
        If CheckDataSet(ds) Then
            'WriteToNavisionFile(InterfaceType, Fname)
            For i = 0 To ds.Tables(0).Rows.Count - 1

                Flag = True
                Dim TempInt As New cPrTmInterface(ds.Tables(0).Rows(i))

                Str = ClearChars((TmpGrp.GLAnl1))
                Str = Str & "|" & ClearChars(TmpGrp.GLAnl2)
                Str = Str & "|" & i + 1
                Str = Str & "|" & Format(NavisionPostingdate.Date, "yyyy-MM-dd")
                Str = Str & "|" & ClearChars(TempInt.Acc_Code)
                Str = Str & "|"
                Str = Str & "|" & ClearChars(Period.Code & "-" & TempInt.Emp_Code) & "-" & TempInt.EDC_Code
                'Str = Str & "|" & ClearChars()
                Str = Str & "|" & Format(TempInt.Amount, "0.00")
                Dim An1 As New cPrAnEmployeeAnalysis1(TempInt.Anal1)
                Dim An2 As New cPrAnEmployeeAnalysis2(TempInt.Anal2)
                Dim An3 As New cPrAnEmployeeAnalysis3(TempInt.Anal3)
                Dim An4 As New cPrAnEmployeeAnalysis4(TempInt.Anal4)
                Dim An5 As New cPrAnEmployeeAnalysis5(TempInt.Anal5)
                Dim Union As New cPrAnUnions(TempInt.AnalUnion)
                Dim P1 As String = ""
                Dim P2 As String = ""
                Dim P3 As String = ""
                Dim P4 As String = ""
                Dim P5 As String = ""
                Dim P6 As String = ""
                ''
                If An1.Code <> "" Then
                    Select Case TempInt.Anal1Pos
                        Case 1
                            P1 = ClearChars(An1.GLAnal1)
                        Case 2
                            P2 = ClearChars(An1.GLAnal1)
                        Case 3
                            P3 = ClearChars(An1.GLAnal1)
                        Case 4
                            P4 = ClearChars(An1.GLAnal1)
                        Case 5
                            P5 = ClearChars(An1.GLAnal1)
                        Case 6
                            P6 = ClearChars(An1.GLAnal1)
                    End Select
                Else
                    Select Case TempInt.Anal1Pos
                        Case 1
                            P1 = ""
                        Case 2
                            P2 = ""
                        Case 3
                            P3 = ""
                        Case 4
                            P4 = ""
                        Case 5
                            P5 = ""
                        Case 6
                            P6 = ""
                    End Select
                End If

                If An2.Code <> "" Then
                    Select Case TempInt.Anal2Pos
                        Case 1
                            P1 = ClearChars(An2.GLAnal1)
                        Case 2
                            P2 = ClearChars(An2.GLAnal1)
                        Case 3
                            P3 = ClearChars(An2.GLAnal1)
                        Case 4
                            P4 = ClearChars(An2.GLAnal1)
                        Case 5
                            P5 = ClearChars(An2.GLAnal1)
                        Case 6
                            P6 = ClearChars(An2.GLAnal1)
                    End Select
                Else
                    Select Case TempInt.Anal2Pos
                        Case 1
                            P1 = ""
                        Case 2
                            P2 = ""
                        Case 3
                            P3 = ""
                        Case 4
                            P4 = ""
                        Case 5
                            P5 = ""
                        Case 6
                            P6 = ""
                    End Select
                End If

                If An3.Code <> "" Then
                    Select Case TempInt.Anal3Pos
                        Case 1
                            P1 = ClearChars(An3.GLAnal1)
                        Case 2
                            P2 = ClearChars(An3.GLAnal1)
                        Case 3
                            P3 = ClearChars(An3.GLAnal1)
                        Case 4
                            P4 = ClearChars(An3.GLAnal1)
                        Case 5
                            P5 = ClearChars(An3.GLAnal1)
                        Case 6
                            P6 = ClearChars(An3.GLAnal1)
                    End Select
                Else
                    Select Case TempInt.Anal3Pos
                        Case 1
                            P1 = ""
                        Case 2
                            P2 = ""
                        Case 3
                            P3 = ""
                        Case 4
                            P4 = ""
                        Case 5
                            P5 = ""
                        Case 6
                            P6 = ""
                    End Select
                End If
                If An4.Code <> "" Then
                    Select Case TempInt.Anal4Pos
                        Case 1
                            P1 = ClearChars(An4.GLAnal1)
                        Case 2
                            P2 = ClearChars(An4.GLAnal1)
                        Case 3
                            P3 = ClearChars(An4.GLAnal1)
                        Case 4
                            P4 = ClearChars(An4.GLAnal1)
                        Case 5
                            P5 = ClearChars(An4.GLAnal1)
                        Case 6
                            P6 = ClearChars(An4.GLAnal1)
                    End Select
                Else
                    Select Case TempInt.Anal4Pos
                        Case 1
                            P1 = ""
                        Case 2
                            P2 = ""
                        Case 3
                            P3 = ""
                        Case 4
                            P4 = ""
                        Case 5
                            P5 = ""
                        Case 6
                            P6 = ""
                    End Select
                End If
                If An5.EmpAn5_Code <> "" Then
                    Select Case TempInt.Anal5Pos
                        Case 1
                            P1 = ClearChars(An5.GLAnal1)
                        Case 2
                            P2 = ClearChars(An5.GLAnal1)
                        Case 3
                            P3 = ClearChars(An5.GLAnal1)
                        Case 4
                            P4 = ClearChars(An5.GLAnal1)
                        Case 5
                            P5 = ClearChars(An5.GLAnal1)
                        Case 6
                            P6 = ClearChars(An5.GLAnal1)
                    End Select
                Else
                    Select Case TempInt.Anal5Pos
                        Case 1
                            P1 = ""
                        Case 2
                            P2 = ""
                        Case 3
                            P3 = ""
                        Case 4
                            P4 = ""
                        Case 5
                            P5 = ""
                        Case 6
                            P6 = ""
                    End Select
                End If
                If Union.Code <> "" Then
                    Select Case TempInt.AnalUnionPos
                        Case 1
                            P1 = ClearChars(Union.GLAnal1)
                        Case 2
                            P2 = ClearChars(Union.GLAnal1)
                        Case 3
                            P3 = ClearChars(Union.GLAnal1)
                        Case 4
                            P4 = ClearChars(Union.GLAnal1)
                        Case 5
                            P5 = ClearChars(Union.GLAnal1)
                        Case 6
                            P6 = ClearChars(Union.GLAnal1)
                    End Select
                Else
                    Select Case TempInt.AnalUnionPos
                        Case 1
                            P1 = ""
                        Case 2
                            P2 = ""
                        Case 3
                            P3 = ""
                        Case 4
                            P4 = ""
                        Case 5
                            P5 = ""
                        Case 6
                            P6 = ""
                    End Select
                End If

                Str = Str & "|" & P1
                Str = Str & "|" & P2
                Str = Str & "|" & P3
                Str = Str & "|" & P4
                Str = Str & "|" & P5
                Str = Str & "|" & P6

                ''

                'If An1.Code <> "" Then
                '    Str = Str & "|" & ClearChars(An1.GLAnal1)
                'Else
                '    Str = Str & "|" & ""
                'End If
                'If An2.Code <> "" Then
                '    Str = Str & "|" & ClearChars(An2.GLAnal1)
                'Else
                '    Str = Str & "|" & ""
                'End If

                'If An3.Code <> "" Then
                '    Str = Str & "|" & ClearChars(An3.GLAnal1)

                'Else
                '    Str = Str & "|" & ""
                'End If
                'If An4.Code <> "" Then
                '    Str = Str & "|" & ClearChars(An4.GLAnal1)
                'Else
                '    Str = Str & "|" & ""
                'End If
                'If An5.EmpAn5_Code <> "" Then
                '    Str = Str & "|" & ClearChars(An5.GLAnal1)
                'Else
                '    Str = Str & "|" & ""
                'End If
                'If Union.Code <> "" Then
                '    Str = Str & "|" & ClearChars(Union.GLAnal1)
                'Else
                '    Str = Str & "|" & ""
                'End If

                Str = Str & "|" & TempInt.ExternalDoc
                Str = Str & "|" '& TempInt.IsCheque
                Str = Str & "|" & TempInt.AccType

                WriteToNavisionFile(Str, Fname)

                System.Windows.Forms.Application.DoEvents()
            Next
        End If
        Return Flag

    End Function
    Public Function Send_WriteToNavFile_Employees(ByVal TmpGroup As cPrMsTemplateGroup, ByVal FName As String) As Boolean
        InitFile = False
        Dim Pipes As String = "|||"
        Dim Str As String = ""
        Dim Ds As DataSet
        Dim i As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Ds = Global1.Business.GetAllEmployeesOfCodeOfTemplateGroup(TmpGroup.Code)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                EmpCode = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                EmpName = DbNullToString(Ds.Tables(0).Rows(i).Item(1))
                Str = "990EMPREC"
                Str = Str & Pipes & EmpCode
                Str = Str & Pipes & EmpName
                Str = Str & Pipes & "EOL"
                Me.WriteToNavisionFile(Str, FName)
            Next
        End If
    End Function

    Public Function Send_WriteToNavFile_NEW(ByVal TmpGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Fname As String, ByVal InterfaceType As String, ByVal Times As Integer, ByVal FirstFile As Boolean, ByVal ExtraPrefix As String, ByVal Reverse As Boolean) As Boolean
        Dim ds As DataSet
        Dim i As Integer
        Dim Str As String
        Dim Flag As Boolean = False
        If Global1.GLB_OneInterfaceFile Then
            If FirstFile Then
                InitFile = True
            Else
                InitFile = False
            End If
        Else
            InitFile = True
        End If



        Dim Pipes As String = "|||"
        Dim BankPaymentType As String
        Dim PostingDate As Date

        Dim Company As New cAdMsCompany(TmpGrp.CompanyCode)
        Dim Prefix As String
        'Global1.Business.CommitTransaction()
        ds = Global1.Business.GetAllPrTmInterface(TmpGrp.Code)
        If CheckDataSet(ds) Then
            'WriteToNavisionFile(InterfaceType, Fname)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim MyAmount As Double = 0
                Flag = True
                Dim TempInt As New cPrTmInterface(ds.Tables(0).Rows(i))
                If TempInt.Amount <> 0 Then
                    If TempInt.BalAccount = "1" Then
                        Prefix = "R-"
                        Dim S As String
                        Dim D As Date
                        D = DateAdd(DateInterval.Month, 1, NavisionPostingdate.Date)
                        Dim Ar() As String
                        S = Format(D.Date, "dd-MM-yyyy")
                        Ar = S.Split("-")
                        S = Ar(1) & "-01-" & Ar(2)
                        PostingDate = CDate(S)

                        MyAmount = TempInt.Amount * (-1)
                        If Reverse Then
                            MyAmount = MyAmount * (-1)
                        End If
                        '  MsgBox(TempInt.Amount & " " & MyAmount & " " & TempInt.Acc_Code)
                    Else
                        Prefix = ""
                        PostingDate = NavisionPostingdate.Date
                        MyAmount = TempInt.Amount
                        If Reverse Then
                            MyAmount = MyAmount * (-1)
                        End If
                    End If
                    Str = ClearChars((TmpGrp.GLAnl1))                                          '0
                    'Str = Str & Pipes & ClearChars(TmpGrp.GLAnl2)                             '1
                    If Times <> 0 Then
                        Str = Str & Pipes & Period.Code & "-" & Times & ExtraPrefix                     '1
                    Else
                        Str = Str & Pipes & Period.Code & "-" & ExtraPrefix                                       '1
                    End If

                    If Global1.GLB_OneInterfaceFile Then
                        If InterfaceType = "PF" Then
                            Str = Str & Pipes & PFFilecounter + 1
                            PFFilecounter = PFFilecounter + 1
                        Else
                            Str = Str & Pipes & GLFilecounter + 1
                            GLFilecounter = GLFilecounter + 1

                        End If

                        '2
                    Else
                        Str = Str & Pipes & i + 1
                    End If


                    Str = Str & Pipes & Format(PostingDate.Date, "dd-MM-yyyy")                 '3
                    Str = Str & Pipes & Format(PostingDate.Date, "dd-MM-yyyy")                 '4
                    Str = Str & Pipes & "0"                                                    '5
                    Str = Str & Pipes & TempInt.ReasonCode                                     '6
                    Str = Str & Pipes & ""                                                     '7
                    Str = Str & Pipes & TempInt.AccType                                        '8
                    Str = Str & Pipes & ClearChars(TempInt.Acc_Code)                           '9
                    Str = Str & Pipes & ""                                                     '10
                    Str = Str & Pipes & Format(PostingDate.Date, "dd-MM-yyyy")         '11


                    If TempInt.ExternalDoc <> "" Then
                        If Not Reverse Then
                            If Global1.PARAM_FTPToNodal Then
                                Str = Str & Pipes & Prefix & TempInt.ExternalDoc & "-" & TempInt.Emp_Code         '12
                                Str = Str & Pipes & Prefix & TempInt.ExternalDoc & "-" & TempInt.Emp_Code         '13
                                BankPaymentType = 2
                            Else
                                Str = Str & Pipes & Prefix & TempInt.ExternalDoc                                  '12
                                Str = Str & Pipes & Prefix & TempInt.ExternalDoc                                  '13
                                BankPaymentType = 2
                            End If
                        Else
                            If Global1.PARAM_FTPToNodal Then
                                Str = Str & Pipes & Prefix         '12
                                Str = Str & Pipes & Prefix         '13
                                BankPaymentType = 2
                            Else
                                Str = Str & Pipes & Prefix         '12
                                Str = Str & Pipes & Prefix         '13
                                BankPaymentType = 2
                            End If

                        End If

                    Else
                        Str = Str & Pipes & Prefix & "PAY" & Format(NavisionPostingdate.Date, "yyyy-MM")  '12
                        Str = Str & Pipes & Prefix & "PAY" & Format(NavisionPostingdate.Date, "yyyy-MM")  '13
                        BankPaymentType = 0
                    End If

                    Str = Str & Pipes & ""                                                     '14
                    Str = Str & Pipes & ""                                                     '15
                    Str = Str & Pipes & ""                                                     '16
                    Str = Str & Pipes & Format(MyAmount, "0.00")                         '17
                    Str = Str & Pipes & Format(MyAmount, "0.00")                         '18
                    Str = Str & Pipes & "0.00"                    '19
                    If Global1.PARAM_ShowEmpNameOnInterface Then
                        Dim EmpName As String = ""
                        If TempInt.Emp_Code <> "" Then
                            Dim Emp As New cPrMsEmployees(TempInt.Emp_Code)
                            EmpName = Emp.FullName
                        End If
                        If EmpName <> "" Then
                            Str = Str & Pipes & ClearChars(Period.Code & "-" & TempInt.Emp_Code & "-" & EmpName) & "-" & TempInt.EDC_Code   '20
                        Else
                            Str = Str & Pipes & ClearChars(Period.Code & "-" & TempInt.Emp_Code) & "-" & TempInt.EDC_Code   '20
                        End If
                    Else
                        Str = Str & Pipes & ClearChars(Period.Code & "-" & TempInt.Emp_Code) & "-" & TempInt.EDC_Code   '20
                    End If
                    Str = Str & Pipes & ""                                                                          '21

                    Str = Str & Pipes & Company.GLAnal5                                                             '22

                    Dim An1 As New cPrAnEmployeeAnalysis1(TempInt.Anal1)
                    Dim An2 As New cPrAnEmployeeAnalysis2(TempInt.Anal2)
                    Dim An3 As New cPrAnEmployeeAnalysis3(TempInt.Anal3)
                    Dim An4 As New cPrAnEmployeeAnalysis4(TempInt.Anal4)
                    Dim An5 As New cPrAnEmployeeAnalysis5(TempInt.Anal5)
                    Dim Union As New cPrAnUnions(TempInt.AnalUnion)
                    Dim P1 As String = ""
                    Dim P2 As String = ""
                    Dim P3 As String = ""
                    Dim P4 As String = ""
                    Dim P5 As String = ""
                    Dim P6 As String = ""
                    Dim P7 As String = ""
                    Dim P8 As String = ""
                    ''
                    If TempInt.Anal0 <> "" Then
                        P1 = TempInt.Anal0
                    Else
                        If An1.Code <> "" Then
                            Select Case TempInt.Anal1Pos
                                Case 1
                                    P1 = ClearChars(An1.GLAnal1)
                                Case 2
                                    P2 = ClearChars(An1.GLAnal1)
                                Case 3
                                    P3 = ClearChars(An1.GLAnal1)
                                Case 4
                                    P4 = ClearChars(An1.GLAnal1)
                                Case 5
                                    P5 = ClearChars(An1.GLAnal1)
                                Case 6
                                    P6 = ClearChars(An1.GLAnal1)
                                Case 7
                                    P7 = ClearChars(An1.GLAnal1)
                                Case 8
                                    P8 = ClearChars(An1.GLAnal1)
                            End Select
                        Else
                            Select Case TempInt.Anal1Pos
                                Case 1
                                    P1 = ""
                                Case 2
                                    P2 = ""
                                Case 3
                                    P3 = ""
                                Case 4
                                    P4 = ""
                                Case 5
                                    P5 = ""
                                Case 6
                                    P6 = ""
                                Case 7
                                    P7 = ""
                                Case 8
                                    P8 = ""
                            End Select
                        End If
                    End If
                    If An2.Code <> "" Then
                        Select Case TempInt.Anal2Pos
                            Case 1
                                P1 = ClearChars(An2.GLAnal1)
                            Case 2
                                P2 = ClearChars(An2.GLAnal1)
                            Case 3
                                P3 = ClearChars(An2.GLAnal1)
                            Case 4
                                P4 = ClearChars(An2.GLAnal1)
                            Case 5
                                P5 = ClearChars(An2.GLAnal1)
                            Case 6
                                P6 = ClearChars(An2.GLAnal1)
                            Case 7
                                P7 = ClearChars(An2.GLAnal1)
                            Case 8
                                P8 = ClearChars(An2.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal2Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                            Case 7
                                P7 = ""
                            Case 8
                                P8 = ""
                        End Select
                    End If

                    If An3.Code <> "" Then
                        Select Case TempInt.Anal3Pos
                            Case 1
                                P1 = ClearChars(An3.GLAnal1)
                            Case 2
                                P2 = ClearChars(An3.GLAnal1)
                            Case 3
                                P3 = ClearChars(An3.GLAnal1)
                            Case 4
                                P4 = ClearChars(An3.GLAnal1)
                            Case 5
                                P5 = ClearChars(An3.GLAnal1)
                            Case 6
                                P6 = ClearChars(An3.GLAnal1)
                            Case 7
                                P7 = ClearChars(An3.GLAnal1)
                            Case 8
                                P8 = ClearChars(An3.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal3Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                            Case 7
                                P7 = ""
                            Case 8
                                P8 = ""
                        End Select
                    End If
                    If An4.Code <> "" Then
                        Select Case TempInt.Anal4Pos
                            Case 1
                                P1 = ClearChars(An4.GLAnal1)
                            Case 2
                                P2 = ClearChars(An4.GLAnal1)
                            Case 3
                                P3 = ClearChars(An4.GLAnal1)
                            Case 4
                                P4 = ClearChars(An4.GLAnal1)
                            Case 5
                                P5 = ClearChars(An4.GLAnal1)
                            Case 6
                                P6 = ClearChars(An4.GLAnal1)
                            Case 7
                                P7 = ClearChars(An4.GLAnal1)
                            Case 8
                                P8 = ClearChars(An4.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal4Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                            Case 7
                                P7 = ""
                            Case 8
                                P8 = ""
                        End Select
                    End If
                    If An5.EmpAn5_Code <> "" Then
                        Select Case TempInt.Anal5Pos
                            Case 1
                                P1 = ClearChars(An5.GLAnal1)
                            Case 2
                                P2 = ClearChars(An5.GLAnal1)
                            Case 3
                                P3 = ClearChars(An5.GLAnal1)
                            Case 4
                                P4 = ClearChars(An5.GLAnal1)
                            Case 5
                                P5 = ClearChars(An5.GLAnal1)
                            Case 6
                                P6 = ClearChars(An5.GLAnal1)
                            Case 7
                                P7 = ClearChars(An5.GLAnal1)
                            Case 8
                                P8 = ClearChars(An5.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal5Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                            Case 7
                                P7 = ""
                            Case 8
                                P8 = ""
                        End Select
                    End If
                    If Union.Code <> "" Then
                        Select Case TempInt.AnalUnionPos
                            Case 1
                                P1 = ClearChars(Union.GLAnal1)
                            Case 2
                                P2 = ClearChars(Union.GLAnal1)
                            Case 3
                                P3 = ClearChars(Union.GLAnal1)
                            Case 4
                                P4 = ClearChars(Union.GLAnal1)
                            Case 5
                                P5 = ClearChars(Union.GLAnal1)
                            Case 6
                                P6 = ClearChars(Union.GLAnal1)
                            Case 7
                                P7 = ClearChars(Union.GLAnal1)
                            Case 8
                                P8 = ClearChars(Union.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.AnalUnionPos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                            Case 7
                                P7 = ""
                            Case 8
                                P8 = ""
                        End Select
                    End If

                    If Global1.PARAM_P3toP7 Then
                        P7 = P3
                        P3 = ""
                    End If
                    Str = Str & Pipes & ""                                          '23
                    Str = Str & Pipes & P1                                          '24
                    Str = Str & Pipes & P2                                          '25
                    Str = Str & Pipes & P3                                          '26
                    Str = Str & Pipes & P4                                          '27
                    Str = Str & Pipes & P5                                          '28
                    Str = Str & Pipes & P6                                          '29
                    Str = Str & Pipes & P7                                          '30
                    Str = Str & Pipes & P8                                          '31

                    Str = Str & Pipes & ""                                          '32
                    Str = Str & Pipes & ""                                          '33
                    Str = Str & Pipes & BankPaymentType                             '34
                    Str = Str & Pipes & "EOL"                                       '35


                    WriteToNavisionFile(Str, Fname)
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        Else
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("There is no Interface setup, Proceed with Posting of interface?", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                Flag = True
            End If
        End If
        Return Flag

    End Function
    Public Function Send_WriteToNavFile_NEW_TA(ByVal TmpGrp As cPrMsTemplateGroup, ByVal Period As cPrMsPeriodCodes, ByVal Fname As String, ByVal InterfaceType As String, ByVal Times As Integer, ByVal FirstFile As Boolean, ByVal ExtraPrefix As String) As Boolean
        Dim ds As DataSet
        Dim i As Integer
        Dim Str As String
        Dim Flag As Boolean = False
        If Global1.GLB_OneInterfaceFile Then
            If FirstFile Then
                InitFile = True
            Else
                InitFile = False
            End If
        Else
            InitFile = True
        End If



        Dim Pipes As String = "|||"
        Dim BankPaymentType As String
        Dim PostingDate As Date

        Dim Company As New cAdMsCompany(TmpGrp.CompanyCode)
        Dim Prefix As String
        'Global1.Business.CommitTransaction()
        ds = Global1.Business.GetAllPrTmInterface(TmpGrp.Code)
        If CheckDataSet(ds) Then
            'WriteToNavisionFile(InterfaceType, Fname)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim MyAmount As Double = 0
                Flag = True
                Dim TempInt As New cPrTmInterface(ds.Tables(0).Rows(i))
                If TempInt.Amount <> 0 Then
                    If TempInt.BalAccount = "1" Then
                        Prefix = "R-"
                        Dim S As String
                        Dim D As Date
                        D = DateAdd(DateInterval.Month, 1, NavisionPostingdate.Date)
                        Dim Ar() As String
                        S = Format(D.Date, "dd-MM-yyyy")
                        Ar = S.Split("-")
                        S = Ar(1) & "-01-" & Ar(2)
                        PostingDate = CDate(S)
                        MyAmount = TempInt.Amount * (-1)
                    Else
                        Prefix = ""
                        PostingDate = NavisionPostingdate.Date
                        MyAmount = TempInt.Amount
                    End If
                    Str = ClearChars((TmpGrp.GLAnl1))                                          '0
                    'Str = Str & Pipes & ClearChars(TmpGrp.GLAnl2)                             '1
                    If Times <> 0 Then
                        Str = Str & Pipes & Period.Code & "-" & Times & ExtraPrefix                     '1
                    Else
                        Str = Str & Pipes & Period.Code & "-" & ExtraPrefix                                       '1
                    End If
                    If Global1.GLB_OneInterfaceFile Then
                        If InterfaceType = "PF" Then
                            Str = Str & Pipes & PFFilecounter + 1
                            PFFilecounter = PFFilecounter + 1
                        Else
                            Str = Str & Pipes & GLFilecounter + 1
                            GLFilecounter = GLFilecounter + 1

                        End If

                        '2
                    Else
                        Str = Str & Pipes & i + 1
                    End If


                    Str = Str & Pipes & Format(PostingDate.Date, "dd-MM-yyyy")                 '3
                    Str = Str & Pipes & Format(PostingDate.Date, "dd-MM-yyyy")                 '4
                    Str = Str & Pipes & "0"                                                    '5
                    Str = Str & Pipes & TempInt.ReasonCode                                     '6
                    Str = Str & Pipes & ""                                                     '7
                    Str = Str & Pipes & TempInt.AccType                                        '8
                    Str = Str & Pipes & ClearChars(TempInt.Acc_Code)                           '9
                    Str = Str & Pipes & ""                                                     '10
                    Str = Str & Pipes & Format(PostingDate.Date, "dd-MM-yyyy")         '11


                    If TempInt.ExternalDoc <> "" Then
                        Str = Str & Pipes & Prefix & TempInt.ExternalDoc                                  '12
                        Str = Str & Pipes & Prefix & TempInt.ExternalDoc                                  '13
                        BankPaymentType = 2
                    Else
                        Str = Str & Pipes & Prefix & "PAY" & Format(NavisionPostingdate.Date, "yyyy-MM")  '12
                        Str = Str & Pipes & Prefix & "PAY" & Format(NavisionPostingdate.Date, "yyyy-MM")  '13
                        BankPaymentType = 0
                    End If

                    Str = Str & Pipes & ""                                                     '14
                    Str = Str & Pipes & ""                                                     '15
                    Str = Str & Pipes & ""                                                     '16
                    Str = Str & Pipes & Format(MyAmount, "0.00")                         '17
                    Str = Str & Pipes & Format(MyAmount, "0.00")                         '18
                    Str = Str & Pipes & "0.00"                                                 '19
                    Str = Str & Pipes & ClearChars(Period.Code & "-" & TempInt.Emp_Code) & "-" & TempInt.EDC_Code   '20
                    Str = Str & Pipes & ""                                                                          '21

                    Str = Str & Pipes & Company.GLAnal5                                                             '22

                    Dim An1 As New cPrAnEmployeeAnalysis1(TempInt.Anal1)
                    Dim An2 As New cPrAnEmployeeAnalysis2(TempInt.Anal2)
                    Dim An3 As New cPrAnEmployeeAnalysis3(TempInt.Anal3)
                    Dim An4 As New cPrAnEmployeeAnalysis4(TempInt.Anal4)
                    Dim An5 As New cPrAnEmployeeAnalysis5(TempInt.Anal5)
                    Dim Union As New cPrAnUnions(TempInt.AnalUnion)
                    Dim P1 As String = ""
                    Dim P2 As String = ""
                    Dim P3 As String = ""
                    Dim P4 As String = ""
                    Dim P5 As String = ""
                    Dim P6 As String = ""
                    ''
                    If TempInt.Anal0 <> "" Then
                        P1 = TempInt.Anal0
                    Else
                        If An1.Code <> "" Then
                            Select Case TempInt.Anal1Pos
                                Case 1
                                    P1 = ClearChars(An1.GLAnal1)
                                Case 2
                                    P2 = ClearChars(An1.GLAnal1)
                                Case 3
                                    P3 = ClearChars(An1.GLAnal1)
                                Case 4
                                    P4 = ClearChars(An1.GLAnal1)
                                Case 5
                                    P5 = ClearChars(An1.GLAnal1)
                                Case 6
                                    P6 = ClearChars(An1.GLAnal1)
                            End Select
                        Else
                            Select Case TempInt.Anal1Pos
                                Case 1
                                    P1 = ""
                                Case 2
                                    P2 = ""
                                Case 3
                                    P3 = ""
                                Case 4
                                    P4 = ""
                                Case 5
                                    P5 = ""
                                Case 6
                                    P6 = ""
                            End Select
                        End If
                    End If
                    If An2.Code <> "" Then
                        Select Case TempInt.Anal2Pos
                            Case 1
                                P1 = ClearChars(An2.GLAnal1)
                            Case 2
                                P2 = ClearChars(An2.GLAnal1)
                            Case 3
                                P3 = ClearChars(An2.GLAnal1)
                            Case 4
                                P4 = ClearChars(An2.GLAnal1)
                            Case 5
                                P5 = ClearChars(An2.GLAnal1)
                            Case 6
                                P6 = ClearChars(An2.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal2Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                        End Select
                    End If

                    If An3.Code <> "" Then
                        Select Case TempInt.Anal3Pos
                            Case 1
                                P1 = ClearChars(An3.GLAnal1)
                            Case 2
                                P2 = ClearChars(An3.GLAnal1)
                            Case 3
                                P3 = ClearChars(An3.GLAnal1)
                            Case 4
                                P4 = ClearChars(An3.GLAnal1)
                            Case 5
                                P5 = ClearChars(An3.GLAnal1)
                            Case 6
                                P6 = ClearChars(An3.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal3Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                        End Select
                    End If
                    If An4.Code <> "" Then
                        Select Case TempInt.Anal4Pos
                            Case 1
                                P1 = ClearChars(An4.GLAnal1)
                            Case 2
                                P2 = ClearChars(An4.GLAnal1)
                            Case 3
                                P3 = ClearChars(An4.GLAnal1)
                            Case 4
                                P4 = ClearChars(An4.GLAnal1)
                            Case 5
                                P5 = ClearChars(An4.GLAnal1)
                            Case 6
                                P6 = ClearChars(An4.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal4Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                        End Select
                    End If
                    If An5.EmpAn5_Code <> "" Then
                        Select Case TempInt.Anal5Pos
                            Case 1
                                P1 = ClearChars(An5.GLAnal1)
                            Case 2
                                P2 = ClearChars(An5.GLAnal1)
                            Case 3
                                P3 = ClearChars(An5.GLAnal1)
                            Case 4
                                P4 = ClearChars(An5.GLAnal1)
                            Case 5
                                P5 = ClearChars(An5.GLAnal1)
                            Case 6
                                P6 = ClearChars(An5.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.Anal5Pos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                        End Select
                    End If
                    If Union.Code <> "" Then
                        Select Case TempInt.AnalUnionPos
                            Case 1
                                P1 = ClearChars(Union.GLAnal1)
                            Case 2
                                P2 = ClearChars(Union.GLAnal1)
                            Case 3
                                P3 = ClearChars(Union.GLAnal1)
                            Case 4
                                P4 = ClearChars(Union.GLAnal1)
                            Case 5
                                P5 = ClearChars(Union.GLAnal1)
                            Case 6
                                P6 = ClearChars(Union.GLAnal1)
                        End Select
                    Else
                        Select Case TempInt.AnalUnionPos
                            Case 1
                                P1 = ""
                            Case 2
                                P2 = ""
                            Case 3
                                P3 = ""
                            Case 4
                                P4 = ""
                            Case 5
                                P5 = ""
                            Case 6
                                P6 = ""
                        End Select
                    End If
                    Str = Str & Pipes & ""                                          '23
                    Str = Str & Pipes & P1                                          '24
                    Str = Str & Pipes & P2                                          '25
                    Str = Str & Pipes & P3                                          '26
                    Str = Str & Pipes & P4                                          '27
                    Str = Str & Pipes & P5                                          '28
                    Str = Str & Pipes & P6                                          '29
                    Str = Str & Pipes & ""                                          '30
                    Str = Str & Pipes & ""                                          '31

                    Str = Str & Pipes & ""                                          '32
                    Str = Str & Pipes & ""                                          '33
                    Str = Str & Pipes & BankPaymentType                             '34
                    Str = Str & Pipes & "EOL"                                       '35


                    WriteToNavisionFile(Str, Fname)
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        End If
        Return Flag

    End Function
    Private Function ClearChars(ByVal Str As String) As String
        Dim S As String
        S = CStr(34)

        Str = Replace(Str, ";", " ")

        'Str = Replace(Str, S, " ")

        Str = Replace(Str, "|", " ")

        Return Str
    End Function


    Private Function WriteToNavisionFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = NAVOUTFileDir & "\" & fName
            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
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


    Private Sub MnuHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuHistoryToolStripMenuItem.Click
        Dim F As New FrmNavInterfaceHistory
        F.Owner = Me
        F.TemGrp = Me.GLBTempGroup
        '   F.Top = Me.PanelLoading.Bottom + 10
        F.ShowDialog()
    End Sub

    Private Sub MnuCreateBankFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCreateBankFile.Click
        Dim F As New FrmBankTransferFile
        F.Period = Me.GLBCurrentPeriod
        F.TemGrp = Me.GLBTempGroup
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Analysis = Me.ComboSelectAnal.SelectedIndex


        Select Case Analysis
            Case 0
                AnalysisCode = "0"
            Case 1
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis1).Code
            Case 2
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis2).Code
            Case 3
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis3).Code
            Case 4
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis4).Code
            Case 5
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
            Case 6
                AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
        End Select
        F.GLBAnalysis = Analysis
        F.GLBAnalysisCode = AnalysisCode
        F.ShowDialog()
    End Sub

    Private Sub MnuPayslipOnScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPayslipOnScreen.Click
        PrintPayslips(False, False, False)
    End Sub

    Private Sub MnuPayslipToPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPayslipToPrinter.Click
        PrintPayslips(True, False, False)
    End Sub
    Private Sub TsbPrintWithCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbPrintWithCheques.Click
        PrintCheques()
    End Sub
    Private Sub UpdateChequeNumbersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateChequeNumbersToolStripMenuItem.Click
        Global1.GLBOnlyUpdateChequeNumbers = True
        PrintCheques()
        GLBOnlyUpdateChequeNumbers = False
    End Sub
    Private Sub PrintCheques()
        Dim f As New FrmChequeDetails
        f.CalledBY = 1
        f.Owner = Me
        f.ShowDialog()
        PrintPayslips(True, False, True)
    End Sub

    Private Sub PrintPayslips(ByVal SendToPrinter As Boolean, ByVal SendToEmail As Boolean, ByVal PrintCheques As Boolean, Optional ByVal Gmail As Boolean = False, Optional ByVal Office365 As Boolean = False, Optional ByVal SMTP As Boolean = False, Optional UploadToExelsys As Boolean = False)

        Dim TimesheetsReport As Boolean = False
        Dim Wording As String

        Dim PayslipDir As String = "C:\"
        Dim IncreaseChequeNo As Boolean = False
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim ans As New MsgBoxResult
            If Not SendToEmail Then
                ans = MsgBox("Do you want to PRINT Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
            Else
                ans = MsgBox("Do you want to EMAIL Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
            End If
            If ans = MsgBoxResult.Yes Then



                If SendToEmail Then
                    If Gmail Or Office365 Or SMTP Then
                        Dim F As New FrmGmail
                        F.ShowDialog()

                    End If
                    Dim ds As DataSet
                    ds = Global1.Business.GetParameter("Payslips", "ExportFileDir")
                    If CheckDataSet(ds) Then
                        Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
                        PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
                    Else
                        PayslipDir = "C:\"
                    End If

                    Wording = ""

                    ds = Global1.Business.GetParameter("Email", "WordingMsg")
                    If CheckDataSet(ds) Then
                        Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
                        If Par.Value1 = 1 Then
                            Wording = BuiltWording()
                        End If
                    End If

                End If


                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                Dim DoNotPrint As Boolean = False
                Dim strYear As String
                Dim PrdGroup As New cPrMsPeriodGroups(GLBCurrentPeriod.PrdGrpCode)
                strYear = PrdGroup.Year
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))

                    DoNotPrint = False
                    Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                    If H.NetSalary = 0 Then
                        If PrintCheques Then
                            DoNotPrint = True
                        End If
                    End If
                    If Not DoNotPrint Then
                        If Status = "POST" Or Status = "CALC" Then
                            If Selected = "1" Then
                                Proceed = True
                                If PrintCheques Then
                                    If IsNumeric(GLBChequeNo) Then
                                        If IncreaseChequeNo Then
                                            GLBChequeNo = GLBChequeNo + 1
                                        Else
                                            IncreaseChequeNo = True
                                        End If
                                    End If
                                End If
                                Dim UseEmail2 As Boolean = False
                                If CBUseEmail2.CheckState = CheckState.Checked Then
                                    UseEmail2 = True
                                End If

                                CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeNo = GLBChequeNo
                                CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeDate = GLBChequeDate
                                CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PayslipFoldeDirectory = PayslipDir
                                CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBWording = Wording
                                CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PrintPayslip(SendToPrinter, SendToEmail, PrintCheques, Gmail, Office365:=Office365, StrYear:=strYear, SMTP:=SMTP, Useemail2:=UseEmail2, UploadToExelsys:=UploadToExelsys)

                                'If TimesheetsReport Then
                                ' CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PrintTimeSheetsReport(SendToPrinter, SendToEmail, PrintCheques, Gmail, Office365:=Office365, strYear:=strYear)
                                'End If


                            End If
                        End If
                    End If
                Next
                If SendToEmail Then
                    MsgBox("Payslips Email sending Process has Finish", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Please Select Employees First")
        End If
    End Sub
    Private Function BuiltWording() As String
        Dim Ds As DataSet
        Dim Msg As String
        Ds = Global1.Business.GetParameter("Email", "Payslip1")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip4")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip5")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip6")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip7")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip8")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip9")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Ds = Global1.Business.GetParameter("Email", "Payslip10")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Msg = "" Then
                Msg = Par.Value1 & Chr(10)
            Else
                Msg = Msg & Par.Value1 & Chr(10)
            End If
        End If
        Return Msg



    End Function

    Private Sub TSBEmailPayslipToEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEmailPayslipToEmployee.Click
        PrintPayslips(False, True, False)
    End Sub

    Private Sub GemailToEmployeepdfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GemailToEmployeepdfToolStripMenuItem.Click
        PrintPayslips(False, True, False, True, False, False)
        GC.Collect()
    End Sub
    Private Sub ToEmployee365_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToEmployee365.Click
        PrintPayslips(False, True, False, False, True, False)
        GC.Collect()
    End Sub
    Private Sub EmailToEmployeepdfUsingSMTPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailToEmployeepdfUsingSMTPToolStripMenuItem.Click
        PrintPayslips(False, True, False, False, False, True)
        GC.Collect()
    End Sub



    Private Sub TSBEndOfYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEndOfYear.Click
        If CheckDataSet(MyDs) Then
            Dim F As New FrmTxEmployeeAnnualLeave
            F.MyDs = MyDs
            F.Per = Me.GLBCurrentPeriod
            F.ShowDialog()
        End If
    End Sub
    Private Sub LeaveTransacToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveTransacToolStripMenuItem.Click
        If CheckDataSet(MyDs) Then
            Dim F As New FrmLeaveTransactions
            F.MyDs = MyDs
            F.Per = Me.GLBCurrentPeriod
            F.ShowDialog()
        End If
    End Sub

    Private Sub TSBCurrentBalanceReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCurrentBalanceReport.Click
        If CheckDataSet(MyDs) Then
            Dim F As New FrmAnnualLeave
            F.MyDs = MyDs
            F.Per = Me.GLBCurrentPeriod
            F.TempGrp = Me.GLBTempGroup
            F.ShowDialog()
        End If
    End Sub


    Private Sub MnuNavisionTimesheets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNavisionTimesheets.Click
        Dim F As New FrmPrTxNavisionTimesheets
        F.Period = Me.GLBCurrentPeriod
        F.TemGrp = Me.GLBTempGroup
        F.ShowDialog()
    End Sub

    Private Sub MnuNavisionEmployeeCostInterface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNavisionEmployeeCostInterface.Click
        Dim F As New FrmNavEmployeeCostInterface
        F.Period = Me.GLBCurrentPeriod
        F.TemGrp = Me.GLBTempGroup
        F.ShowDialog()
    End Sub

    Private Sub LoadComboSelectAnal()
        With Me.ComboSelectAnal
            .BeginUpdate()
            .Items.Add("ALL")
            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("3")
            .Items.Add("4")
            .Items.Add("5")
            .Items.Add("UNION")
            .EndUpdate()
            .SelectedIndex = 0

        End With
    End Sub
    Private Sub LoadAnalysis()
        Dim i As Integer
        i = Me.ComboSelectAnal.SelectedIndex
        Select Case i
            Case 0
                LoadALL()
            Case 1
                LoadPrAnEmployeeAnalysis1()
            Case 2
                LoadPrAnEmployeeAnalysis2()
            Case 3
                LoadPrAnEmployeeAnalysis3()
            Case 4
                LoadPrAnEmployeeAnalysis4()
            Case 5
                LoadPrAnEmployeeAnalysis5()
            Case 6
                LoadPrAnUnions()
        End Select


    End Sub
    Private Sub LoadALL()
        Dim ds As DataSet
        Dim i As Integer

        With Me.ComboAnal
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("ALL")
            ' .ValueMember = "EmpAn1_Code"
            .SelectedIndex = 0
            .EndUpdate()
        End With

    End Sub

    Private Sub LoadPrAnEmployeeAnalysis1()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1(True)
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
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2(True)
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
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3(True)
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
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4(True)
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
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5(True)
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
    Private Sub LoadPrAnUnions()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnUnions()
        If CheckDataSet(ds) Then
            Dim tPrAnUnions As New cPrAnUnions
            With Me.ComboAnal
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnUnions = New cPrAnUnions(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnUnions)
                Next i
                '  .ValueMember = "Uni_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub

    Private Sub ComboSelectAnal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSelectAnal.SelectedIndexChanged
        Me.LoadAnalysis()
    End Sub




    Private Sub TSUploadTAFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUploadTAFile.Click
        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If Global1.PARAM_TAFilePath <> "" Then
                ''''''''''''''''''''''''''''''''''''''''''
                Dim Files() As String
                Dim i As Integer
                Dim Line As String = String.Empty
                Dim counter As Integer = 0
                Dim LoadedOK As Boolean = False
                Dim param_file As IO.StreamReader
                Dim FileDir As String
                Me.Refresh()
                counter = 0
                '''
                FileDir = Global1.PARAM_TAFilePath
                Files = IO.Directory.GetFiles(FileDir)
                Me.Refresh()
                Dim EmpMapCode As String
                Dim EmpName As String
                Dim EmpCode As String
                Dim Actual As Double = 0
                Dim OV1 As Double = 0
                Dim OV2 As Double = 0
                Dim StrActual As String = ""
                Dim StrOV1 As String = ""
                Dim StrOV2 As String = ""
                Dim AtLeast1 As Boolean = False

                If Files.Length = 0 Then
                    MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                    Cursor.Current = Cursors.Default
                    Exit Sub

                End If

                For i = 0 To Files.Length - 1
                    Me.Refresh()
                    FileName = Files(i)
                    Try
                        Dim Exx As New Exception
                        param_file = IO.File.OpenText(FileName)
                        LoadedOK = False
                        Do While param_file.Peek <> -1
                            Me.Refresh()
                            Dim Ar() As String
                            counter = counter + 1
                            Line = param_file.ReadLine()
                            Ar = Line.Split("	")
                            EmpMapCode = Ar(0).Replace("""", "")
                            EmpName = Ar(1).Replace("""", "")

                            StrActual = Ar(6).Replace("""", "")
                            StrOV1 = Ar(10).Replace("""", "")
                            StrOV2 = Ar(11).Replace("""", "")
                            Actual = CDbl(StrActual)
                            OV1 = CDbl(StrOV1)
                            OV2 = CDbl(StrOV2)

                            EmpCode = Global1.Business.FindEmployeeCode(EmpMapCode, 4)

                            'EmpCode = Trim(EmpMapCode)


                            If EmpCode = "" Then
                                Dim Ans As New MsgBoxResult
                                'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                Ans = MsgBox("No Employee was found with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then

                                    param_file.Close()
                                    param_file.Dispose()
                                    If AtLeast1 Then
                                        MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                    End If
                                    Cursor.Current = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                AtLeast1 = True
                                Dim k As Integer
                                For k = 0 To MyDs.Tables(0).Rows.Count - 1
                                    If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                        If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                            MyDs.Tables(0).Rows(k).Item(4) = Actual
                                            MyDs.Tables(0).Rows(k).Item(5) = OV1
                                            MyDs.Tables(0).Rows(k).Item(6) = OV2
                                        End If
                                        Exit For
                                    End If
                                Next
                            End If
                        Loop
                        param_file.Close()
                        param_file.Dispose()
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Unable to Load Timeattendance File", MsgBoxStyle.Critical)
                        param_file.Close()
                        param_file.Dispose()

                    End Try
                Next
                DG1.Refresh()
                MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)

            Else
                MsgBox("Time Attendance file Path is missing, please contact iNSoft!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please Search for employees before Uploading File", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub ExportInpdfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportInpdfToolStripMenuItem.Click
        ExportPayslipsInPDF()
    End Sub
    Public Sub ExportPayslipsInPDF()
        Dim PayslipDir As String = "C:\"
        Dim IncreaseChequeNo As Boolean = False
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim ans As New MsgBoxResult

            ans = MsgBox("Do you want to Export Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)

            If ans = MsgBoxResult.Yes Then
                Dim ds As DataSet
                ds = Global1.Business.GetParameter("Payslips", "ExportFileDir")
                If CheckDataSet(ds) Then
                    Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
                    PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
                Else
                    PayslipDir = "C:\"
                End If

                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                Dim DoNotPrint As Boolean = False
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))

                    DoNotPrint = False
                    Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)

                    If Status = "POST" Or Status = "CALC" Then
                        If Selected = "1" Then
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeNo = GLBChequeNo
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeDate = GLBChequeDate
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PayslipFoldeDirectory = PayslipDir
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PrintPayslip(False, False, False, False, True)
                        End If
                    End If
                Next

                MsgBox("Payslips are Exported (" & PayslipDir & ")", MsgBoxStyle.Information)
            End If
        Else

            MsgBox("Please Select Employees First")
        End If

    End Sub
    Private Sub mnuUploadToExelsys_Click(sender As Object, e As EventArgs) Handles mnuUploadToExelsys.Click
        UploadPayslipsToExelsys()
    End Sub
    Public Sub UploadPayslipsToExelsys()
        Dim PayslipDir As String = "C:\"
        Dim IncreaseChequeNo As Boolean = False
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim ans As New MsgBoxResult

            ans = MsgBox("Do you want to Upload to Exelsys Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)

            If ans = MsgBoxResult.Yes Then
                Dim ds As DataSet
                ds = Global1.Business.GetParameter("Payslips", "ExportFileDir")
                If CheckDataSet(ds) Then
                    Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
                    PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
                Else
                    PayslipDir = "C:\"
                End If

                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                Dim DoNotPrint As Boolean = False
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))

                    DoNotPrint = False
                    Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)

                    If Status = "POST" Or Status = "CALC" Then
                        If Selected = "1" Then
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeNo = GLBChequeNo
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeDate = GLBChequeDate
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PayslipFoldeDirectory = PayslipDir
                            CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PrintPayslip(False, False, False, False, True, UploadToExelsys:=True)
                        End If
                    End If
                Next

                MsgBox("Payslips are Uploaded to Exelsys", MsgBoxStyle.Information)
            End If
        Else

            MsgBox("Please Select Employees First")
        End If


    End Sub

    Private Sub mnuYTDInExcel_Click(sender As Object, e As EventArgs) Handles mnuYTDInExcel.Click
        Dim ans As New MsgBoxResult
        ans = MsgBox("Do you want to Export YTD Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
        If ans = MsgBoxResult.Yes Then
            ExportPayslipsInEXCEL(False, 0, False)
        End If

    End Sub
    Private Sub mnuExportYearlyPayslipInExcelTotals_Click(sender As Object, e As EventArgs) Handles mnuExportYearlyPayslipInExcelTotals.Click
        Global1.PARAM_GLBAllMonthsPayslipTOTALS = True
        ExportPayslipsInEXCEL(False, 0, False)
        Global1.PARAM_GLBAllMonthsPayslipTOTALS = False

    End Sub

    Private Sub mnuYTDInPDF_Click(sender As Object, e As EventArgs) Handles mnuYTDInPDF.Click
        Dim ans1 As New MsgBoxResult
        ans1 = MsgBox("Do you want to Export YTD Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
        If ans1 = MsgBoxResult.Yes Then
            Dim Ans As MsgBoxResult
            Dim UseEncryption As Boolean = False
            Ans = MsgBox("Encrypt .pdf document If there is a password on employees Maintenance form ?", MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                UseEncryption = True
            End If
            ExportPayslipsInEXCEL(True, 0, UseEncryption)
        End If
    End Sub

    Private Sub mnuYTDInPDFandEMAIL_Click(sender As Object, e As EventArgs) Handles mnuYTDInPDFandEMAIL.Click
        Dim ans1 As New MsgBoxResult
        ans1 = MsgBox("Do you want to Export and Email YTD Payslips of Posted Or Calculated Entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
        If ans1 = MsgBoxResult.Yes Then
            Dim Ans As MsgBoxResult
            Dim UseEncryption As Boolean = False
            Ans = MsgBox("Encrypt .pdf document If there is a password on employees Maintenance form ?", MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                UseEncryption = True
            End If

            Dim F As New FrmSelectEmailMethod
            F.Owner = Me
            F.ShowDialog()
            ExportPayslipsInEXCEL(True, YTDEmailmethod, UseEncryption)
        End If
    End Sub


    Public Sub ExportPayslipsInEXCEL(SaveAlsoInPDF As Boolean, EmailMethod As Integer, UseEncryption As Boolean)
        Dim PayslipDir As String = "C:\"
        Dim IncreaseChequeNo As Boolean = False
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then


            Dim AsEmail As Boolean = False
            Dim AsGmail As Boolean = False
            Dim As365 As Boolean = False
            Dim AsSMTP As Boolean = False
            Select Case EmailMethod
                Case 1
                    AsEmail = True
                Case 2
                    AsGmail = True
                Case 3
                    AsSMTP = True
            End Select



            Dim ds As DataSet
            ds = Global1.Business.GetParameter("Payslips", "ExportFileDir")
            If CheckDataSet(ds) Then
                Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
                PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
            Else
                PayslipDir = "C:\"
            End If

            Dim i As Integer
            Dim Saved As Integer = 0
            Dim Status As String
            Dim Selected As String
            Dim Proceed As Boolean = False
            Dim EmpCode As String = ""
            Dim DoNotPrint As Boolean = False
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))

                DoNotPrint = False
                Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                Dim YTDTotalPeriods As Integer = CInt(Me.txtTotalPeriods.Text)

                If Status = "POST" Or Status = "CALC" Then
                    If Selected = "1" Then
                        CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeNo = GLBChequeNo
                        CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBChequeDate = GLBChequeDate
                        CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PayslipFoldeDirectory = PayslipDir
                        CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBYTDScheduled = YTDScheduled
                        CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).GLBYTDScheduledDateTime = YTDscheduledDatetime
                        CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).PrintPayslip(False, AsEmail, False, AsGmail, SaveAlsoInPDF, As365, "", AsSMTP, False, True, UseEncryption, YTDTotalPeriods)
                    End If
                End If
                If Global1.PARAM_GLBAllMonthsPayslipTOTALS Then
                    Exit For
                End If
            Next

            MsgBox("Payslips are Exported (" & PayslipDir & ")", MsgBoxStyle.Information)

        Else

            MsgBox("Please Select Employees First")
        End If

    End Sub
    Public Function ExportPayslipsInPDFForExelsys(ByVal MinId As Integer, ByVal MaxId As Integer) As Boolean
        Dim Flag As Boolean = False
        Try


            Me.InterfaceFileisOK = False

            Dim Exx As New System.Exception
            Dim DsMinMax As DataSet
            Dim Header As DataSet


            Dim PeriodCode As String
            PeriodCode = Me.txtPeriodCode.Text
            If MinId = 0 And MaxId = 0 Then
                DsMinMax = Global1.Business.GetMinAndMaxIDOfUnsendTrxns(GLBTempGroup)
                If CheckDataSet(DsMinMax) Then
                    MinId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(0))
                    MaxId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(1))
                End If
            End If

            Dim NewInterface As Boolean = False
            Header = Global1.Business.GetPrTxTrxnHeader(MinId, MaxId, GLBTempGroup)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' If not Interface Setup
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CheckDataSet(Header) Then

                Dim PayslipDir As String = "C:\"
                Dim IncreaseChequeNo As Boolean = False

                Dim ds As DataSet
                ds = Global1.Business.GetParameter("Payslips", "ExportFileDir")
                If CheckDataSet(ds) Then
                    Dim Par As New cPrSsParameters(ds.Tables(0).Rows(0))
                    PayslipDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
                    Flag = True
                Else
                    MsgBox("Please define Export Directory for Payslips", MsgBoxStyle.Critical)
                    Flag = False
                End If
                If Flag Then

                    Dim i As Integer
                    Dim Saved As Integer = 0
                    Dim Status As String
                    Dim Selected As String
                    Dim Proceed As Boolean = False
                    Dim EmpCode As String = ""
                    Dim DoNotPrint As Boolean = False
                    For i = 0 To Header.Tables(0).Rows.Count - 1
                        Dim H As New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                        Dim Emp As New cPrMsEmployees(H.Emp_Code)

                        Dim ReportToUse As String = GLB_PAYSLIPReport
                        If Emp.MyPayslipReport <> "" Then
                            ReportToUse = Emp.MyPayslipReport
                        End If

                        Cursor.Current = Cursors.WaitCursor

                        If H.Id > 0 Then
                            ds = Global1.Business.REPORT_PreparePayslipFor(Emp, GLBCurrentPeriod, H, GLBChequeDate, False)
                            Me.Cursor = Cursors.Default

                            Dim ExportFile As String
                            ExportFile = PayslipDir & Emp.Code & ".pdf"

                            Utils.ShowReport(ReportToUse, ds, FrmReport, "Payslip Report", False, "", False, True, ExportFile)
                            GC.Collect()

                        End If
                        GC.Collect()
                        Cursor.Current = Cursors.Default

                        '''
                    Next

                End If
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
            flag = False
        End Try
        Return Flag

    End Function


    'Private Sub TryToSend365Email1()



    '    Dim oMail As New SmtpMail("TryIt")
    '    Dim oSmtp As New System.Net.Mail.SmtpClient()

    '    ' Your office 365 email address
    '    oMail.From = "myid@mydomain"

    '    ' Set recipient email address, please change it to yours
    '    oMail.To = "support@emailarchitect.net"

    '    ' Set email subject
    '    oMail.Subject = "test email from office 365 account"

    '    ' Set email body
    '    oMail.TextBody = "this is a test email sent from VB.NET project with hotmail"

    '    ' Your Office 365 SMTP server address, 
    '    ' You should get it from outlook web access.
    '    Dim oServer As New SmtpServer("smtp.office365.com")

    '    ' user authentication should use your 
    '    ' email address as the user name. 
    '    oServer.User = "myid@mydomain"
    '    oServer.Password = "yourpassword"

    '    ' Set 587 port
    '    oServer.Port = 587

    '    ' detect SSL/TLS connection automatically
    '    oServer.ConnectType = System.Net.Mail.SmtpConnectType.ConnectSSLAuto

    '    Try

    '        Console.WriteLine("start to send email over SSL ...")
    '        oSmtp.s()
    '        oSmtp.SendMail(oServer, oMail)
    '        Console.WriteLine("email was sent successfully!")

    '    Catch ep As Exception

    '        Console.WriteLine("failed to send email with the following error:")
    '        Console.WriteLine(ep.Message)
    '    End Try

    'End Sub

    Private Sub mnuIOCFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIOCFile.Click
        Cursor.Current = Cursors.WaitCursor
        Dim fileName As String = ""
        Dim param_file As IO.StreamReader
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                fileName = openFileDialog1.FileName
                If (fileName IsNot Nothing) Then
                    ''''''''''''''''''''''''''''''''''''
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()
                    Dim Exx As New Exception
                    param_file = IO.File.OpenText(fileName)
                    Dim LoadedOK As Boolean = False
                    Dim Counter As Integer = 0
                    Dim Line As String
                    Dim EmpCode As String = ""
                    Dim DutyHours As Double = 0
                    Dim FlightHours As Double = 0
                    Dim Sectors As Double = 0
                    Do While param_file.Peek <> -1
                        Application.DoEvents()
                        Me.Refresh()
                        Dim Ar() As String
                        Counter = Counter + 1
                        Line = param_file.ReadLine()
                        Ar = Line.Split("	")
                        EmpCode = Ar(2).Replace("""", "")
                        DutyHours = Ar(6).Replace(":", ".")
                        FlightHours = Ar(7).Replace(":", ".")
                        Sectors = Ar(8)
                        Dim i As Integer
                        Dim emp As New cPrMsEmployees(EmpCode)
                        If emp.Code = "" Or emp.Code Is Nothing Then
                            Dim Ans As New MsgBoxResult
                            Ans = MsgBox("Employee with Code " & EmpCode & " Does not exist in Payroll! Continue ?", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                param_file.Close()
                                param_file.Dispose()
                                Cursor.Current = Cursors.Default
                                Exit Sub
                            End If
                        End If
                        For i = 0 To DG1.RowCount - 1
                            If DbNullToString(DG1.Item(Me.Column_EmpCode, i).Value) = EmpCode Then
                                Debug.WriteLine(DbNullToString(DG1.Item(Me.Column_Status, i).Value))
                                If DbNullToString(DG1.Item(Me.Column_Status, i).Value) = "<  >" Then
                                    Dim Dut As New cPrSsDutyHours(emp.DutyHours)
                                    If Dut.HourRate <> 0 Then
                                        DG1.Item(Me.Column_DutyHours, i).Value = DutyHours
                                    Else
                                        DG1.Item(Me.Column_DutyHours, i).Value = "0.00"
                                    End If

                                    Dim Fli As New cPrSsFlightHours(emp.FlightHours)
                                    If Fli.HourRate <> 0 Then
                                        DG1.Item(Me.Column_FlightHours, i).Value = FlightHours
                                    Else
                                        DG1.Item(Me.Column_FlightHours, i).Value = "0.00"
                                    End If

                                    Dim Sec As New cPrSsSectorPay(emp.SectorPay)
                                    If Sec.HourRate <> 0 Then
                                        DG1.Item(Me.Column_Sectors, i).Value = Sectors
                                    Else
                                        DG1.Item(Me.Column_Sectors, i).Value = "0"
                                    End If
                                End If
                            End If
                        Next


                    Loop
                    param_file.Close()
                    param_file.Dispose()
                    ''''''''''''''''''''''''''''''''''''
                    MsgBox("Finish Importing IOC File", MsgBoxStyle.Information)
                End If
            Catch Ex As Exception
                param_file.Close()
                param_file.Dispose()
                Utils.ShowException(Ex)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.

            End Try
        End If
        Cursor.Current = Cursors.Default
    End Sub

   

    Private Sub btnGoToEmployeeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToEmployeeCard.Click
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            Dim EmpCode As String
            Dim ss As Integer
            EmpCode = DG1.Item(2, i).Value
            For ss = 0 To MyDs.Tables(0).Rows.Count - 1
                If MyDs.Tables(0).Rows(ss).Item(2) = EmpCode Then
                    i = ss
                End If
            Next
            EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim F As New frmPrMsEmployees
            F.MdiParent = Me.MdiParent
            F.EmpCodeFromPayrollForm = EmpCode
            F.Show()

        End If
    End Sub
    Private Sub BtnGoToemployeeSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToemployeeSalary.Click
        OpenCurrentEmployeeSalaryCard()
    End Sub
    Public Sub OpenCurrentEmployeeSalaryCard(Optional ByVal GrossSal As Double = 0)
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            i = DG1.CurrentRow.Index
            Dim EmpCode As String
            Dim ss As Integer
            EmpCode = DG1.Item(2, i).Value
            For ss = 0 To MyDs.Tables(0).Rows.Count - 1
                If MyDs.Tables(0).Rows(ss).Item(2) = EmpCode Then
                    i = ss
                End If
            Next
            EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim F As New frmPrMsEmployees
            F.MdiParent = Me.MdiParent
            F.EmpCodeFromPayrollForm = EmpCode
            F.Show()
            F.ShowSalary(GrossSal)

        End If
    End Sub
   


    Public Sub SendRecordsAndPayslipsToExelsys(ByVal MinId As Integer, ByVal MaxId As Integer, ByVal FromHistory As Boolean, ByVal Batch As cPrSsNavBatch, ByVal firstFile As Boolean)
        Me.InterfaceFileisOK = False

        Me.Label7.Text = "Updating Exelsys in Progress . . ."
        Me.Label6.Text = "Start At: " & Format(Now, "dd-MM-yyyy hh:mm:ss")
        Me.PanelLoading.Visible = True
        Me.PanelLoading.Refresh()
        Me.Refresh()

        ' If Not CheckIfFileExistsOnNav(RemHost, RemPath, FName, user, pwd) Then
        Me.PanelLoading.Visible = True
        Me.PanelLoading.Refresh()
        Me.Refresh()

        Dim Exx As New System.Exception
        Dim DsMinMax As DataSet
        Dim Header As DataSet

        Dim PeriodCode As String
        PeriodCode = Me.txtPeriodCode.Text
        If MinId = 0 And MaxId = 0 Then
            DsMinMax = Global1.Business.GetMinAndMaxIDOfUnsendTrxns(GLBTempGroup)
            If CheckDataSet(DsMinMax) Then
                MinId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(0))
                MaxId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(1))
            End If
        End If

        Dim NewInterface As Boolean = False
        Header = Global1.Business.GetPrTxTrxnHeader(MinId, MaxId, GLBTempGroup)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' If not Interface Setup
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If CheckDataSet(Header) Then

            Dim pCn As OleDb.OleDbConnection
            Dim AccessDBFile As String


            If Global1.PARAM_HCMdatabasePath = "" Then
                MsgBox("Please define HCM system Database path", MsgBoxStyle.Critical)
                Exit Sub
            End If
            AccessDBFile = Global1.PARAM_HCMdatabasePath
            'AccessDBFile = "C:\Program Files (x86)\Exelsys Ltd\Exelsys HCM Sync\DB\ExelsysHCMGSync.accdb"
            Try


                'on form load instantiate the connection object
                pCn = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & AccessDBFile & ";Persist Security Info=False;")
                Try
                    'try to open the connection
                    Call pCn.Open()
                Catch ex As Exception
                    MessageBox.Show("Could not connect for some reason.... is the file on the right location? --> check connectionstring")
                End Try

                If pCn.State = ConnectionState.Open Then
                    Dim i As Integer
                    Dim Period As New cPrMsPeriodCodes()
                    Dim PeriodGroup As New cPrMsPeriodGroups()
                    Dim Template As New cPrMsTemplateGroup
                    For i = 0 To Header.Tables(0).Rows.Count - 1

                        Application.DoEvents()

                        Dim Hdr As New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                        Dim Str As String
                        If i = 0 Then
                            Period = New cPrMsPeriodCodes(Hdr.PrdCod_Code, Hdr.PrdGrp_Code)
                            PeriodGroup = New cPrMsPeriodGroups(Hdr.PrdGrp_Code)
                            Template = New cPrMsTemplateGroup(Hdr.TemGrpCode)
                        End If
                        Dim PeriodDescription As String = PeriodGroup.Year & "-" & Period.DescriptionL

                        Str = "Insert Into SalaryEntry " & _
                        " (EmployeeCode," & _
                        " StartDate, " & _
                        " PositionCode," & _
                        " CurrencyCode," & _
                        " PreviousSalary," & _
                        " Salary," & _
                        " SalaryType," & _
                        " Comments," & _
                        " OtherSalary," & _
                        " Deductions," & _
                        " EmployerContributions," & _
                        " OtherCosts," & _
                        " TotalEmployeeCost," & _
                        " WorkedPoints," & _
                        " Status," & _
                        " DocumentFilename," & _
                        " PayrollNo," & _
                        " PayrollCompanyNo )" & _
                        " Values ( " & _
                        enQuoteString(Hdr.Emp_Code) & "," & _
                        enQuoteString(Hdr.MyDate) & "," & _
                        enQuoteString("") & "," & _
                        enQuoteString("EUR") & "," & _
                        0 & "," & _
                        Hdr.TotalErnPeriod & "," & _
                        enQuoteString("MonthlyGross") & "," & _
                        enQuoteString(PeriodDescription) & "," & _
                        0 & "," & _
                        Hdr.TotalDedPeriod & "," & _
                        Hdr.TotalConPeriod & "," & _
                        0 & "," & _
                        Hdr.TotalErnPeriod + Hdr.TotalConPeriod & "," & _
                        0 & "," & _
                        enQuoteString("Entered") & "," & _
                        enQuoteString(Hdr.Emp_Code & ".pdf") & "," & _
                        enQuoteString(Hdr.Emp_Code) & "," & _
                        enQuoteString("01") & _
                        " )"
                        '(Template.CompanyCode) & _
                        Dim k As Integer
                        Dim SQL As New OleDb.OleDbCommand(Str, pCn)
                        Try
                            SQL.CommandText = Str
                            SQL.CommandType = CommandType.Text
                            k = SQL.ExecuteNonQuery()
                            If k = -1 Then k = 0
                        Catch e As Exception
                            ShowException(e)
                            k = -1
                        End Try
                    Next
                    MsgBox("Salary and Payslips uploaded in Exelsys successfully!", MsgBoxStyle.Information)
                End If

            Catch ex As Exception

            End Try


        Else
            MsgBox("There are no Transactions for this Selection", MsgBoxStyle.Information)
        End If


        Me.Label7.Text = ""
        Me.Label6.Text = ""
        Me.PanelLoading.Visible = False
        Me.Refresh()

        GC.Collect()
    End Sub

    Private Sub btncalcSelectedLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalcSelectedLine.Click
        CalculateSelectedLine()
    End Sub
    Private Sub CalculateSelectedLine()

        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then

            Dim ans As New MsgBoxResult
            ans = MsgBox("Do you want to Calculate Payroll for Selected Employee", MsgBoxStyle.YesNoCancel)
            If ans = MsgBoxResult.Yes Then
                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                i = Me.DG1.CurrentRow.Index

                Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                If Status <> "POST" And Status <> "CALC" Then
                    If Selected = "1" Then
                        'Application.DoEvents()
                        Proceed = True
                        'Proceed = False
                        'If Status = "CALC" Then
                        '    ans = MsgBox("Recalculate Line " & i + 1 & " - Employee Code: " & EmpCode & " ?", MsgBoxStyle.YesNo)
                        '    If ans = MsgBoxResult.Yes Then
                        '        Proceed = True
                        '    End If
                        'Else
                        '    Proceed = True
                        'End If
                        If Proceed Then
                            Saved = Saved + 1
                            If Not LoadValuesFromGridToFormCalculations(i, 1) Then
                                Saved = Saved - 1
                            End If
                        End If
                    End If
                End If
                MsgBox(Saved & " Employee Payroll was Calculated")
            End If
        Else
            MsgBox("Please Select Employees First")
        End If
    End Sub

    Private Sub btnPrepareSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrepareSelected.Click
        SaveLineAsPrepared()
    End Sub
    Private Sub SaveLineAsPrepared()

        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        Dim Exx As New Exception
        Dim SaveOne As Boolean = False
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            Dim EmpCode As String
            Dim Saved As Integer
            Try
               
                i = Me.DG1.CurrentRow.Index
                If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) = "<  >" Or DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status)) = "PREP" Then
                    If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled)) = "1" Then

                        SaveOne = True
                        '   SavePreparedOfLine(i)
                        EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                        Dim Hdr As New cPrTxTrxnHeader(EmpCode, GLBCurrentPeriod.Code)
                        With Hdr
                            .Emp_Code = EmpCode
                            .PrdGrp_Code = GLBCurrentPeriod.PrdGrpCode
                            .PrdCod_Code = GLBCurrentPeriod.Code
                            .PayCat_Code = GLBCurrentPeriod.PayCat_Code
                            .MyDate = Now.Date
                            .Status = "PREP"
                            .TotalErnPeriod = 0
                            .TotalErnYTD = 0
                            .TotalDedPeriod = 0
                            .TotalDedYTD = 0
                            .TotalConPeriod = 0
                            .TotalConYTD = 0
                            .SIIncome = 0
                            .TaxableIncome = 0
                            .PaymentMethod = ""
                            .PaymentRef = ""
                            .PeriodUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
                            .AnnualUnits = 0
                            .AnnualLeave = 0
                            .LifeInsurance = 0
                            .Discounts = 0
                            .InterfaceStatus = "OUTS"
                            .Overtime1 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                            .Overtime2 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime2))
                            .Overtime3 = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime3))
                            .SIUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SIUnits))
                            .MonthlySalary = 0
                            .NetSalary = 0
                            .ChequeNo = ""
                            .TemGrpCode = Me.GLBTempGroup.Code


                            .Sectors = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Sectors))
                            .DutyHours = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DutyHours))
                            .FlightHours = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_FlightHours))
                            .Commission = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Commission))
                            .OverLay = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverLay))
                            .PBAmount = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_PBAmount))
                            .PBRate = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_PBRate))

                            .SIUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SIUnits))

                            If Not .Save Then
                                Throw Exx
                            End If
                        End With
                        Dim Count As Integer = 0

                        If Not Global1.Business.DeleteAllEDCFromTrxnLines(Hdr.Id) Then
                            Throw Exx
                        End If

                        'Saving Earnings
                        Dim counter As Integer = 1
                        Dim k As Integer
                        Dim c1 As Integer

                        c1 = Me.Column_E1
                        For k = 0 To 14
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
                                Dim Lin As New cPrTxTrxnLines
                                With Lin
                                    .TrxLin_Id = counter
                                    .TrxHdr_Id = Hdr.Id
                                    .TrxLin_Type = "E"
                                    .ErnCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
                                    .TrxLin_PeriodValue = 0
                                    .TrxLin_YTDValue = 0
                                    Try
                                        .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
                                    Catch
                                        MsgBox("Please Define Earnings for Employee :" & EmpCode)
                                        Throw Exx
                                    End Try
                                    .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
                                    If Not Lin.Save Then
                                        Throw Exx
                                    End If
                                End With
                                counter = counter + 1
                            End If
                            c1 = c1 + 2
                        Next
                        'Saving Deductions
                        c1 = Me.Column_D1
                        For k = 0 To 14
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
                                Dim Lin As New cPrTxTrxnLines
                                With Lin
                                    .TrxLin_Id = counter
                                    .TrxHdr_Id = Hdr.Id
                                    .TrxLin_Type = "D"
                                    .DedCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
                                    .TrxLin_PeriodValue = 0
                                    .TrxLin_YTDValue = 0
                                    Try
                                        .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
                                    Catch
                                        MsgBox("Please Define Deductions for Employee :" & EmpCode)
                                        Throw Exx
                                    End Try
                                    .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
                                    If Not Lin.Save Then
                                        Throw Exx
                                    End If
                                End With
                                counter = counter + 1
                            End If
                            c1 = c1 + 2
                        Next

                        'Saving Contributions
                        c1 = Me.Column_C1
                        For k = 0 To 14
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(c1)) <> "" Then
                                Dim Lin As New cPrTxTrxnLines
                                With Lin
                                    .TrxLin_Id = counter
                                    .TrxHdr_Id = Hdr.Id
                                    .TrxLin_Type = "C"
                                    .ConCod_Code = MyDs.Tables(0).Rows(i).Item(c1)
                                    .TrxLin_PeriodValue = 0
                                    .TrxLin_YTDValue = 0
                                    Try
                                        .TrxLin_EDC = MyDs.Tables(0).Rows(i).Item(c1 + 1)
                                    Catch
                                        MsgBox("Please Define Contributions for Employee :" & EmpCode)
                                        Throw Exx
                                    End Try
                                    .TrxLin_EDCDescription = DG1.Columns(c1 + 1).HeaderText
                                    If Not Lin.Save Then
                                        Throw Exx
                                    End If
                                End With
                                counter = counter + 1
                            End If
                            c1 = c1 + 2
                        Next

                        MyDs.Tables(0).Rows(i).Item(Me.Column_Status) = "PREP"
                        Saved = Saved + 1
                    End If
                End If

              
                If SaveOne Then
                    MsgBox("Payroll Values Are Saved with status Prepared for " & Saved & " Employees! ", MsgBoxStyle.Information)
                Else
                    MsgBox("System can only Save Lines with Status 'PREP' or '<  >'! ", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
             
                Utils.ShowException(Exx)
            End Try

        End If
    End Sub

    Private Sub btnDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteLine.Click
        DeleteSelectedLine()
    End Sub

    Private Sub CBSelectGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSelectGrid.CheckedChanged
        If CheckDataSet(MyDs) Then
            If CBSelectGrid.CheckState = CheckState.Checked Then
                Dim i As Integer
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled) = "1"
                Next
            Else
                Dim i As Integer
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled) = "0"
                Next
            End If
        End If
    End Sub

    
    Private Sub btnUndoCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndoCalculation.Click

        UndoCalculationOnSelectedLine()
    End Sub
    Private Sub UndoCalculationOnSelectedLine()
        Try
            Dim Ex As New Exception
        
            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If

            If CheckDataSet(MyDs) Then

                Dim ans As New MsgBoxResult
                ans = MsgBox("Do you want to Calculate Payroll for Selected Employee", MsgBoxStyle.YesNoCancel)
                If ans = MsgBoxResult.Yes Then
                    Dim i As Integer
                    Dim Saved As Integer = 0
                    Dim Status As String
                    Dim Selected As String
                    Dim Proceed As Boolean = False
                    Dim EmpCode As String = ""
                    i = Me.DG1.CurrentRow.Index

                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                    If Status = "CALC" Then
                        If Selected = "1" Then

                            Proceed = True
                            Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                            H.Status = "PREP"
                            If H.Save() Then
                                If Not Global1.Business.SetTrxnLinesValuestoZero(H.Id) Then
                                    Throw Ex
                                End If
                                If Not Global1.Business.DeleteAllAnnualLeaveOfHeaderID(H.Id) Then
                                    Throw Ex
                                End If
                                If Not Global1.Business.DeleteAllLoanLinesOfHeaderID(H.Id) Then
                                    Throw Ex
                                End If
                                If Not Global1.Business.DeleteIR59(H.Id) Then
                                    Throw Ex
                                End If

                            Else
                                Throw Ex
                            End If
                            MyDs.Tables(0).Rows(i).Delete()
                        End If
                    End If
                    MsgBox("Employee Status is Set to Prepared!")
                End If
            Else
                MsgBox("Please Select Employees First")
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub btnSCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCP.Click
        Cursor = Cursors.WaitCursor
        CheckForAnnualLeaveAllocationTemplateParameter()
        Search("", 1, "")
        RefreshCount()
        CalculateAll()
        PostAll()
        Cursor = Cursors.Default
    End Sub

   
    Private Sub btnAIMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PrepareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareToolStripMenuItem.Click
        Dim f As New FrmAIMS
        f.ShowDialog()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        LoadFromAIMSTable()
    End Sub
    Private Sub LoadFromAIMSTable()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim Ds As DataSet
            Ds = Global1.Business.GetDataFromAIMS
            If CheckDataSet(MyDs) Then
                If CheckDataSet(Ds) Then
                    ''''''''''''''''''''''''''''''''''''
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()
                    Dim k As Integer
                    Dim i As Integer
                    Dim Exx As New Exception
                    Dim LoadedOK As Boolean = False
                    Dim Counter As Integer = 0
                    Dim Line As String
                    Dim No As String = ""
                    Dim EmpCode As String = ""
                    Dim sDutyHours As String = ""
                    Dim sFlightHours As String = ""
                    Dim DutyHours As Double = 0
                    Dim FlightHours As Double = 0
                    Dim Sectors As Double = 0
                    For k = 0 To Ds.Tables(0).Rows.Count - 1
                        Application.DoEvents()
                        Cursor.Current = Cursors.WaitCursor
                        Me.Refresh()
                        Dim Ar() As String
                        Counter = Counter + 1
                        No = DbNullToString(Ds.Tables(0).Rows(k).Item(0))
                        Sectors = DbNullToString(Ds.Tables(0).Rows(k).Item(2))
                        sDutyHours = DbNullToString(Ds.Tables(0).Rows(k).Item(3))
                        sFlightHours = DbNullToString(Ds.Tables(0).Rows(k).Item(4))


                        DutyHours = GetTimeStampToDouble(sDutyHours)
                        FlightHours = GetTimeStampToDouble(sFlightHours)



                        EmpCode = Global1.Business.GetEmployeeFromAIMSCode(No)

                        Dim emp As New cPrMsEmployees(EmpCode)
                     


                        If emp.Code = "" Or emp.Code Is Nothing Then
                            Dim Ans As New MsgBoxResult
                            Ans = MsgBox("Employee with Code " & No & " Does not exist in Payroll! Continue ?", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Cursor.Current = Cursors.Default
                                Exit Sub
                            End If
                        End If
                        For i = 0 To DG1.RowCount - 1
                            If DbNullToString(DG1.Item(Me.Column_EmpCode, i).Value) = EmpCode Then
                                Debug.WriteLine(DbNullToString(DG1.Item(Me.Column_Status, i).Value))
                                If DbNullToString(DG1.Item(Me.Column_Status, i).Value) = "<  >" Then
                                    Dim Dut As New cPrSsDutyHours(emp.DutyHours)
                                    If Dut.HourRate <> 0 Then
                                        DG1.Item(Me.Column_DutyHours, i).Value = DutyHours
                                    Else
                                        DG1.Item(Me.Column_DutyHours, i).Value = "0.00"
                                    End If

                                    Dim Fli As New cPrSsFlightHours(emp.FlightHours)
                                    If Fli.HourRate <> 0 Then
                                        DG1.Item(Me.Column_FlightHours, i).Value = FlightHours
                                    Else
                                        DG1.Item(Me.Column_FlightHours, i).Value = "0.00"
                                    End If

                                    Dim Sec As New cPrSsSectorPay(emp.SectorPay)
                                    If Sec.HourRate <> 0 Then
                                        DG1.Item(Me.Column_Sectors, i).Value = Sectors
                                    Else
                                        DG1.Item(Me.Column_Sectors, i).Value = "0"
                                    End If
                                End If
                            End If
                        Next
                    Next

                    MsgBox("Finish Importing From AIMS Table", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Please select Employees First", MsgBoxStyle.Information)
            End If

        Catch Ex As Exception
            Utils.ShowException(Ex)
            MsgBox("Unable to Import from AIMS table", MsgBoxStyle.Information)
        Finally
            ' Check this again, since we need to make sure we didn't throw an exception on open.
        End Try

        Cursor.Current = Cursors.Default
    End Sub


   
    Private Function GetTimeStampToDouble(ByVal T As String) As Double
        Dim ar() As String
        Dim D As Double
        ar = T.Split(":")
        If ar.Length = 3 Then
            D = ar(0) & "." & ar(1)
        ElseIf ar.Length = 2 Then
            D = 0 & "." & ar(1)
        ElseIf ar.Length = 1 Then
            D = 0
        End If
        Return D
    End Function

    
    
    Private Sub CALCToPREPToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CALCToPREPToolStripMenuItem1.Click
        CALCtoPREP()
    End Sub

    Private Sub POSTToCALCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSTToCALCToolStripMenuItem1.Click
        POSTtoCALC()
    End Sub
    Private Sub CALCtoPREP()
        Dim Exx As New System.Exception
        Cursor.Current = Cursors.WaitCursor
        Try
            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If

            If CheckDataSet(MyDs) Then
                Dim ans As New MsgBoxResult
                ans = MsgBox("Do you want to SET all Calculated entries for Selected Employees to Status 'PREP' ? Any Unsaved data of Status '<>' will be lost !", MsgBoxStyle.YesNoCancel)
                If ans = MsgBoxResult.Yes Then
                    Dim i As Integer
                    Dim Saved As Integer = 0
                    Dim Status As String
                    Dim Selected As String
                    Dim Proceed As Boolean = False
                    Dim EmpCode As String = ""
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        Application.DoEvents()
                        Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                        Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                        EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))

                        If Status = "CALC" Then
                            If Selected = "1" Then
                                Saved = Saved + 1
                                Proceed = True
                                Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                                H.Status = "PREP"
                                If H.Save() Then
                                    If Not Global1.Business.SetTrxnLinesValuestoZero(H.Id) Then
                                        Throw Exx
                                    End If
                                    If Not Global1.Business.DeleteIR59(H.Id) Then
                                        Throw Exx
                                    End If

                                Else
                                    Throw Exx
                                End If
                                ' MyDs.Tables(0).Rows(i).Delete()
                            End If
                        End If
                    Next
                    If Saved > 0 Then
                        MsgBox(Saved & " Employees set to 'PREP'")
                        SearchGlobal("", 1, "")
                    End If
                End If
            Else
                MsgBox("Please Select Employees First")
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try

    End Sub

    
    Private Sub POSTtoCALC()
        Dim Exx As New System.Exception
        Cursor.Current = Cursors.WaitCursor
        Try
            If DG1.IsCurrentCellInEditMode Then
                DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DG1.EndEdit()
            End If

            If CheckDataSet(MyDs) Then
                Dim ans As New MsgBoxResult
                ans = MsgBox("Do you want to SET all Calculated entries for Selected Employees to Status 'CALC' ? Any Unsaved data of Status '<>' will be lost !", MsgBoxStyle.YesNoCancel)
                If ans = MsgBoxResult.Yes Then
                    Dim i As Integer
                    Dim Saved As Integer = 0
                    Dim Status As String
                    Dim Selected As String
                    Dim Proceed As Boolean = False
                    Dim EmpCode As String = ""
                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        Application.DoEvents()
                        Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                        Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                        EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))

                        If Status = "POST" Then
                            If Selected = "1" Then
                                Saved = Saved + 1
                                Proceed = True
                                Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                                If H.InterfaceStatus <> "POST" Then
                                    H.Status = "CALC"
                                    If Not H.Save() Then
                                        Throw Exx
                                    End If
                                Else
                                    MsgBox("Employee " & EmpCode & " Interface Status is 'POST' cannot proceed with Status Change", MsgBoxStyle.Information)
                                End If
                                ' MyDs.Tables(0).Rows(i).Delete()
                            End If
                        End If
                    Next
                    If Saved > 0 Then
                        MsgBox(Saved & " Employees set to 'CALC'")
                        SearchGlobal("", 1, "")
                    End If
                End If
            Else
                MsgBox("Please Select Employees First")
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub MarkAsInterfacedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkAsInterfacedToolStripMenuItem.Click
        MarkAsInterfaced()
    End Sub
    Private Sub MarkAsInterfaced()
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim ans As New MsgBoxResult
            ans = MsgBox("Do you want to POST all Calculated entries for Selected Employees?", MsgBoxStyle.YesNoCancel)
            If ans = MsgBoxResult.Yes Then
                Dim i As Integer
                Dim Saved As Integer = 0
                Dim Status As String
                Dim Selected As String
                Dim Proceed As Boolean = False
                Dim EmpCode As String = ""
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                    If Status = "POST" Then
                        If Selected = "1" Then
                            Proceed = True
                        Else
                            Proceed = False
                        End If
                        If Proceed Then
                            If CType(Me.ArCalculations(i), FrmPrTxCalculatePayroll).MarkAsInterfaced(True) Then
                                ' MyDs.Tables(0).Rows(i).Item(Me.Column_Status) = "POST"
                                Saved = Saved + 1
                            End If
                        End If
                    End If
                Next
                If Saved > 0 Then
                    MsgBox(Saved & " Marked as Interfaced.")
                End If
            End If
        Else
            MsgBox("Please Select Employees First")
        End If
    End Sub

    Private Sub ImportFullToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportFullToolStripMenuItem.Click
        ImportFULL()
    End Sub

    Private Sub ImportOnlyBonusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportOnlyBonusToolStripMenuItem.Click
        ImportOnlyBonus()
    End Sub
    Private Sub ImportFull2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFull2ToolStripMenuItem.Click
        importfull2
    End Sub

    Private Sub ImportFULL()

        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If Global1.PARAM_ETFilePath <> "" Then
                ''''''''''''''''''''''''''''''''''''''''''
                Dim Files() As String
                Dim i As Integer
                Dim Line As String = String.Empty
                Dim counter As Integer = 0
                Dim LoadedOK As Boolean = False
                Dim param_file As IO.StreamReader
                Dim FileDir As String
                Me.Refresh()
                counter = 0
                '''
                FileDir = Global1.PARAM_ETFilePath
                Files = IO.Directory.GetFiles(FileDir)
                Me.Refresh()
                Dim EmpCode As String

                Dim sALEarning As String
                Dim sTraveling As String
                Dim sBonus As String
                Dim sAnnualLeave As String
                Dim sOtherEarnings As String
                Dim sOverTime2 As String
                Dim sReimbersOfExpenses As String
                Dim sRecBonus As String
                Dim sBenInKind1 As String
                Dim sBenInKind2 As String
                Dim sBenInKind3 As String
                Dim sBenInKind4 As String
                Dim sRecOther As String
                Dim sFine As String

                Dim sAdvances As String
                Dim sOtherDeductions As String


                Dim DBL_ALEarning As Double
                Dim DBL_traveling As Double
                Dim DBL_Bonus As Double
                Dim DBL_AnnualLeave As Double
                Dim DBL_OtherEarnings As Double
                Dim DBL_OverTime2 As Double
                Dim DBL_ReimbersOfExpenses As Double
                Dim DBL_RecBonus As Double
                Dim DBL_BenInKind1 As Double
                Dim DBL_BenInKind2 As Double
                Dim DBL_BenInKind3 As Double
                Dim DBL_BenInKind4 As Double
                Dim DBL_RecOther As Double
                Dim DBL_Fine As Double

                Dim DBL_Advances As Double
                Dim DBL_OtherDeductions As Double


                Dim AtLeast1 As Boolean = False

                If Files.Length = 0 Then
                    MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                    Cursor.Current = Cursors.Default
                    Exit Sub

                End If

                For i = 0 To Files.Length - 1
                    Me.Refresh()
                    FileName = Files(i)
                    Try
                        Dim Exx As New Exception
                        param_file = IO.File.OpenText(FileName)
                        LoadedOK = False
                        Do While param_file.Peek <> -1
                            Me.Refresh()
                            Dim Ar() As String
                            counter = counter + 1
                            Line = param_file.ReadLine()
                            Ar = Line.Split("	")
                            EmpCode = Ar(0).Replace("""", "")
                            sALEarning = Ar(1).Replace("""", "")
                            sTraveling = Ar(2).Replace("""", "")
                            sBonus = Ar(3).Replace("""", "")
                            sAnnualLeave = Ar(4).Replace("""", "")
                            sOtherEarnings = Ar(5).Replace("""", "")
                            sOverTime2 = Ar(6).Replace("""", "")
                            sReimbersOfExpenses = Ar(7).Replace("""", "")
                            sRecBonus = Ar(8).Replace("""", "")
                            sBenInKind1 = Ar(9).Replace("""", "")
                            sBenInKind2 = Ar(10).Replace("""", "")
                            sBenInKind3 = Ar(11).Replace("""", "")
                            sBenInKind4 = Ar(12).Replace("""", "")
                            sRecOther = Ar(13).Replace("""", "")
                            sFine = Ar(14).Replace("""", "")



                            sAdvances = Ar(15).Replace("""", "")
                            sOtherDeductions = Ar(16).Replace("""", "")



                            If sALEarning = "" Then
                                DBL_ALEarning = 0
                            Else
                                DBL_ALEarning = CDbl(sALEarning)
                            End If

                            If sTraveling = "" Then
                                DBL_traveling = 0
                            Else
                                DBL_traveling = CDbl(sTraveling)
                            End If
                            If sBonus = "" Then
                                DBL_Bonus = 0
                            Else
                                DBL_Bonus = CDbl(sBonus)
                            End If
                            If sAnnualLeave = "" Then
                                DBL_AnnualLeave = 0
                            Else
                                DBL_AnnualLeave = CDbl(sAnnualLeave)
                            End If
                            If sOtherEarnings = "" Then
                                DBL_OtherEarnings = 0
                            Else
                                DBL_OtherEarnings = CDbl(sOtherEarnings)
                            End If
                            If sOverTime2 = "" Then
                                DBL_OverTime2 = 0
                            Else
                                DBL_OverTime2 = CDbl(sOverTime2)
                            End If
                            If sReimbersOfExpenses = "" Then
                                DBL_ReimbersOfExpenses = 0
                            Else
                                DBL_ReimbersOfExpenses = CDbl(sReimbersOfExpenses)
                            End If
                            If sRecBonus = "" Then
                                DBL_RecBonus = 0
                            Else
                                DBL_RecBonus = CDbl(sRecBonus)
                            End If
                            If sBenInKind1 = "" Then
                                DBL_BenInKind1 = 0
                            Else
                                DBL_BenInKind1 = CDbl(sBenInKind1)
                            End If
                            If sBenInKind2 = "" Then
                                DBL_BenInKind2 = 0
                            Else
                                DBL_BenInKind2 = CDbl(sBenInKind2)
                            End If
                            If sBenInKind3 = "" Then
                                DBL_BenInKind3 = 0
                            Else
                                DBL_BenInKind3 = CDbl(sBenInKind3)
                            End If
                            If sBenInKind4 = "" Then
                                DBL_BenInKind4 = 0
                            Else
                                DBL_BenInKind4 = CDbl(sBenInKind4)
                            End If

                            If sRecOther = "" Then
                                DBL_RecOther = 0
                            Else
                                DBL_RecOther = CDbl(sRecOther)
                            End If

                            If sFine = "" Then
                                DBL_Fine = 0
                            Else
                                DBL_Fine = CDbl(sFine)
                            End If



                            If sAdvances = "" Then
                                DBL_Advances = 0
                            Else
                                DBL_Advances = CDbl(sAdvances)
                            End If
                            If sOtherDeductions = "" Then
                                DBL_OtherDeductions = 0
                            Else
                                DBL_OtherDeductions = CDbl(sOtherDeductions)
                            End If


                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.Code = "" Then
                                Dim Ans As New MsgBoxResult
                                'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                Ans = MsgBox("No Employee was found with code :" & EmpCode & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then

                                    param_file.Close()
                                    param_file.Dispose()
                                    If AtLeast1 Then
                                        MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                    End If
                                    Cursor.Current = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                AtLeast1 = True
                                Dim k As Integer
                                For k = 0 To MyDs.Tables(0).Rows.Count - 1
                                    If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                        If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                            Dim j As Integer = 0
                                            Dim C1 As Integer = 0
                                            Dim C2 As Integer = 0

                                            For j = 0 To 14
                                                If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                    Exit For
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E39" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_ALEarning
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E10" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_traveling
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E11" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_Bonus
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E13" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_AnnualLeave
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E14" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_OtherEarnings
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E24" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_OverTime2
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E25" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_ReimbersOfExpenses
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E30" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_RecBonus
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E32" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind1
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E33" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind2
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E34" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind3
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E35" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind4
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E36" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_RecOther
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E40" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_Fine
                                                End If

                                                C1 = C1 + 2
                                            Next

                                            j = 0
                                            C1 = 0


                                            For j = 0 To 14
                                                If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1)) = "" Then
                                                    Exit For
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1) = "D1" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_DV1 + C1) = DBL_Advances
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1) = "D12" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_DV1 + C1) = DBL_OtherDeductions
                                                End If
                                                C1 = C1 + 2

                                            Next


                                        End If

                                        Exit For
                                    End If
                                Next
                            End If
                        Loop
                        param_file.Close()
                        param_file.Dispose()
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                        param_file.Close()
                        param_file.Dispose()
                    End Try
                Next
                DG1.Refresh()
                MsgBox("File(s) from Excel Template succesfully loaded", MsgBoxStyle.Information)

            Else
                MsgBox("Excel Template file Path is missing, please contact iNSoft!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please Search for employees before Uploading File", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub ImportOnlyBONUS()

        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If Global1.PARAM_ETFilePath <> "" Then
                ''''''''''''''''''''''''''''''''''''''''''
                Dim Files() As String
                Dim i As Integer
                Dim Line As String = String.Empty
                Dim counter As Integer = 0
                Dim LoadedOK As Boolean = False
                Dim param_file As IO.StreamReader
                Dim FileDir As String
                Me.Refresh()
                counter = 0
                '''
                FileDir = Global1.PARAM_ETFilePath
                Files = IO.Directory.GetFiles(FileDir)
                Me.Refresh()
                Dim EmpCode As String



                Dim sBonus As String


                Dim DBL_Bonus As Double

                Dim AtLeast1 As Boolean = False

                If Files.Length = 0 Then
                    MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                    Cursor.Current = Cursors.Default
                    Exit Sub

                End If

                For i = 0 To Files.Length - 1
                    Me.Refresh()
                    FileName = Files(i)
                    Try
                        Dim Exx As New Exception
                        param_file = IO.File.OpenText(FileName)
                        LoadedOK = False
                        Do While param_file.Peek <> -1
                            Me.Refresh()
                            Dim Ar() As String
                            counter = counter + 1
                            Line = param_file.ReadLine()
                            Ar = Line.Split("	")
                            EmpCode = Ar(0).Replace("""", "")
                            sBonus = Ar(1).Replace("""", "")

                            If sBonus = "" Then
                                DBL_Bonus = 0
                            Else
                                DBL_Bonus = CDbl(sBonus)
                            End If



                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.Code = "" Then
                                Dim Ans As New MsgBoxResult
                                'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                Ans = MsgBox("No Employee was found with code :" & EmpCode & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then

                                    param_file.Close()
                                    param_file.Dispose()
                                    If AtLeast1 Then
                                        MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                    End If
                                    Cursor.Current = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                AtLeast1 = True
                                Dim k As Integer
                                For k = 0 To MyDs.Tables(0).Rows.Count - 1
                                    If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                        If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                            Dim j As Integer = 0
                                            Dim C1 As Integer = 0
                                            Dim C2 As Integer = 0

                                            For j = 0 To 14
                                                If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                    Exit For
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E30" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_Bonus
                                                End If

                                                C1 = C1 + 2
                                            Next

                                            j = 0
                                            C1 = 0


                                        End If

                                        Exit For
                                    End If
                                Next
                            End If
                        Loop
                        param_file.Close()
                        param_file.Dispose()
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                        param_file.Close()
                        param_file.Dispose()

                    End Try
                Next
                DG1.Refresh()
                MsgBox("File(s) from Excel Template succesfully loaded", MsgBoxStyle.Information)

            Else
                MsgBox("Excel Template file Path is missing, please contact iNSoft!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please Search for employees before Uploading File", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub ImportFULL2()

        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If Global1.PARAM_ETFilePath <> "" Then
                ''''''''''''''''''''''''''''''''''''''''''
                Dim Files() As String
                Dim i As Integer
                Dim Line As String = String.Empty
                Dim counter As Integer = 0
                Dim LoadedOK As Boolean = False
                Dim param_file As IO.StreamReader
                Dim FileDir As String
                Me.Refresh()
                counter = 0
                '''
                FileDir = Global1.PARAM_ETFilePath
                Files = IO.Directory.GetFiles(FileDir)
                Me.Refresh()
                Dim EmpCode As String

                Dim sALEarning As String
                Dim sTraveling As String
                Dim sBonus As String
                Dim sAnnualLeave As String
                Dim sOtherEarnings As String
                Dim sOverTime2 As String
                Dim sReimbersOfExpenses As String
                Dim sRecBonus As String
                Dim sBenInKind1 As String
                Dim sBenInKind2 As String
                Dim sBenInKind3 As String
                Dim sBenInKind4 As String
                Dim sRecOther As String
                Dim sFine As String

                Dim sAdvances As String
                Dim sOtherDeductions As String


                Dim DBL_ALEarning As Double
                Dim DBL_traveling As Double
                Dim DBL_Bonus As Double
                Dim DBL_AnnualLeave As Double
                Dim DBL_OtherEarnings As Double
                Dim DBL_OverTime2 As Double
                Dim DBL_ReimbersOfExpenses As Double
                Dim DBL_RecBonus As Double
                Dim DBL_BenInKind1 As Double
                Dim DBL_BenInKind2 As Double
                Dim DBL_BenInKind3 As Double
                Dim DBL_BenInKind4 As Double
                Dim DBL_RecOther As Double
                Dim DBL_Fine As Double

                Dim DBL_Advances As Double
                Dim DBL_OtherDeductions As Double


                Dim AtLeast1 As Boolean = False

                If Files.Length = 0 Then
                    MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                    Cursor.Current = Cursors.Default
                    Exit Sub

                End If

                For i = 0 To Files.Length - 1
                    Me.Refresh()
                    FileName = Files(i)
                    Try
                        Dim Exx As New Exception
                        param_file = IO.File.OpenText(FileName)
                        LoadedOK = False
                        Do While param_file.Peek <> -1
                            Me.Refresh()
                            Dim Ar() As String
                            counter = counter + 1
                            Line = param_file.ReadLine()
                            Ar = Line.Split("	")
                            EmpCode = Ar(0).Replace("""", "")
                            sALEarning = Ar(1).Replace("""", "")
                            sTraveling = Ar(2).Replace("""", "")
                            sBonus = Ar(3).Replace("""", "")
                            sAnnualLeave = Ar(4).Replace("""", "")
                            sOtherEarnings = Ar(5).Replace("""", "")
                            sOverTime2 = Ar(6).Replace("""", "")
                            sReimbersOfExpenses = Ar(7).Replace("""", "")
                            sRecBonus = Ar(8).Replace("""", "")
                            sBenInKind1 = Ar(9).Replace("""", "")
                            sBenInKind2 = Ar(10).Replace("""", "")
                            sBenInKind3 = Ar(11).Replace("""", "")
                            sBenInKind4 = Ar(12).Replace("""", "")
                            sRecOther = Ar(13).Replace("""", "")
                            sFine = Ar(14).Replace("""", "")



                            sAdvances = Ar(15).Replace("""", "")
                            sOtherDeductions = Ar(16).Replace("""", "")



                            If sALEarning = "" Then
                                DBL_ALEarning = 0
                            Else
                                DBL_ALEarning = CDbl(sALEarning)
                            End If

                            If sTraveling = "" Then
                                DBL_traveling = 0
                            Else
                                DBL_traveling = CDbl(sTraveling)
                            End If
                            If sBonus = "" Then
                                DBL_Bonus = 0
                            Else
                                DBL_Bonus = CDbl(sBonus)
                            End If
                            If sAnnualLeave = "" Then
                                DBL_AnnualLeave = 0
                            Else
                                DBL_AnnualLeave = CDbl(sAnnualLeave)
                            End If
                            If sOtherEarnings = "" Then
                                DBL_OtherEarnings = 0
                            Else
                                DBL_OtherEarnings = CDbl(sOtherEarnings)
                            End If
                            If sOverTime2 = "" Then
                                DBL_OverTime2 = 0
                            Else
                                DBL_OverTime2 = CDbl(sOverTime2)
                            End If
                            If sReimbersOfExpenses = "" Then
                                DBL_ReimbersOfExpenses = 0
                            Else
                                DBL_ReimbersOfExpenses = CDbl(sReimbersOfExpenses)
                            End If
                            If sRecBonus = "" Then
                                DBL_RecBonus = 0
                            Else
                                DBL_RecBonus = CDbl(sRecBonus)
                            End If
                            If sBenInKind1 = "" Then
                                DBL_BenInKind1 = 0
                            Else
                                DBL_BenInKind1 = CDbl(sBenInKind1)
                            End If
                            If sBenInKind2 = "" Then
                                DBL_BenInKind2 = 0
                            Else
                                DBL_BenInKind2 = CDbl(sBenInKind2)
                            End If
                            If sBenInKind3 = "" Then
                                DBL_BenInKind3 = 0
                            Else
                                DBL_BenInKind3 = CDbl(sBenInKind3)
                            End If
                            'If sBenInKind4 = "" Then
                            '    DBL_BenInKind4 = 0
                            'Else
                            '    DBL_BenInKind4 = CDbl(sBenInKind4)
                            'End If

                            'If sRecOther = "" Then
                            '    DBL_RecOther = 0
                            'Else
                            '    DBL_RecOther = CDbl(sRecOther)
                            'End If

                            'If sFine = "" Then
                            '    DBL_Fine = 0
                            'Else
                            '    DBL_Fine = CDbl(sFine)
                            'End If



                            If sAdvances = "" Then
                                DBL_Advances = 0
                            Else
                                DBL_Advances = CDbl(sAdvances)
                            End If
                            If sOtherDeductions = "" Then
                                DBL_OtherDeductions = 0
                            Else
                                DBL_OtherDeductions = CDbl(sOtherDeductions)
                            End If


                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.Code = "" Then
                                Dim Ans As New MsgBoxResult
                                'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                Ans = MsgBox("No Employee was found with code :" & EmpCode & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then

                                    param_file.Close()
                                    param_file.Dispose()
                                    If AtLeast1 Then
                                        MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                    End If
                                    Cursor.Current = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                AtLeast1 = True
                                Dim k As Integer
                                For k = 0 To MyDs.Tables(0).Rows.Count - 1
                                    If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                        If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                            Dim j As Integer = 0
                                            Dim C1 As Integer = 0
                                            Dim C2 As Integer = 0

                                            For j = 0 To 14
                                                If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                    Exit For
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E39" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_ALEarning
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E10" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_traveling
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E11" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_Bonus
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E13" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_AnnualLeave
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E14" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_OtherEarnings
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E24" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_OverTime2
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E33" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_ReimbersOfExpenses
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E29" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_RecBonus
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E49" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind1
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E41" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind2
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E42" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind3
                                                End If
                                                'If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E35" Then
                                                '    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_BenInKind4
                                                'End If

                                                'If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E36" Then
                                                '    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_RecOther
                                                'End If

                                                'If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = "E40" Then
                                                '    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_Fine
                                                'End If

                                                C1 = C1 + 2
                                            Next

                                            j = 0
                                            C1 = 0


                                            For j = 0 To 14
                                                If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1)) = "" Then
                                                    Exit For
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1) = "D1" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_DV1 + C1) = DBL_Advances
                                                End If
                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1) = "D12" Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_DV1 + C1) = DBL_OtherDeductions
                                                End If
                                                C1 = C1 + 2

                                            Next


                                        End If

                                        Exit For
                                    End If
                                Next
                            End If
                        Loop
                        param_file.Close()
                        param_file.Dispose()
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                        param_file.Close()
                        param_file.Dispose()
                    End Try
                Next
                DG1.Refresh()
                MsgBox("File(s) from Excel Template succesfully loaded", MsgBoxStyle.Information)

            Else
                MsgBox("Excel Template file Path is missing, please contact iNSoft!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please Search for employees before Uploading File", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub



    Private Sub FixAnalysis3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixAnalysis3ToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderAnalysis(Emp.EmpAn3_Code, Hdr.Id, 3)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub
    Private Sub FixAnalysis1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixAnalysis1ToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderAnalysis(Emp.EmpAn1_Code, Hdr.Id, 1)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub



    Private Sub FixAnalysis2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixAnalysis2ToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderAnalysis(Emp.EmpAn2_Code, Hdr.Id, 2)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub

    Private Sub FixAnalysis4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixAnalysis4ToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderAnalysis(Emp.EmpAn4_Code, Hdr.Id, 4)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub

    Private Sub FixAnalysis5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixAnalysis5ToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderAnalysis(Emp.EmpAn5_Code, Hdr.Id, 5)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub
    Private Sub FixUnionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixUnionToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderAnalysis(Emp.Uni_Code, Hdr.Id, 6)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub

    Private Sub FixYTDNetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixYTDNetToolStripMenuItem.Click
        Dim i As Integer
        Dim tEmpCode As String
        For i = 0 To MyDs.Tables(0).Rows.Count - 1
            tEmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Status = "CALC" Or Hdr.Status = "POST" Then
                Dim Emp As New cPrMsEmployees(tEmpCode)
                If Emp.Code <> "" Then
                    Global1.Business.UpdateTrxnHeaderYTDNet(Hdr.Id)
                End If
            End If
        Next
        MsgBox("Finish")
    End Sub

    Private Sub mnuSelectEDCtoImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectEDCtoImport.Click
        SelectEDCToImport()
    End Sub
    Private Sub SelectEDCToImport()
        Dim F As New FrmSelectEDCToImport
        F.Owner = Me
        F.ShowDialog()



        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If Global1.PARAM_ETFilePath <> "" Then
                ''''''''''''''''''''''''''''''''''''''''''
                Dim Files() As String
                Dim i As Integer
                Dim Line As String = String.Empty
                Dim counter As Integer = 0
                Dim LoadedOK As Boolean = False
                Dim param_file As IO.StreamReader
                Dim FileDir As String
                Me.Refresh()
                counter = 0
                '''
                FileDir = Global1.PARAM_ETFilePath
                Files = IO.Directory.GetFiles(FileDir)
                Me.Refresh()
                Dim EmpCode As String



                Dim sBonus As String


                Dim DBL_Bonus As Double

                Dim AtLeast1 As Boolean = False

                If Files.Length = 0 Then
                    MsgBox("There are no Files to Upload in Derectory " & FileDir, MsgBoxStyle.Information)
                    Cursor.Current = Cursors.Default
                    Exit Sub

                End If

                For i = 0 To Files.Length - 1
                    Me.Refresh()
                    FileName = Files(i)
                    Try
                        Dim Exx As New Exception
                        param_file = IO.File.OpenText(FileName)
                        LoadedOK = False
                        Do While param_file.Peek <> -1
                            Me.Refresh()
                            Dim Ar() As String
                            counter = counter + 1
                            Line = param_file.ReadLine()
                            Ar = Line.Split("	")
                            EmpCode = Ar(0).Replace("""", "")
                            sBonus = Ar(1).Replace("""", "")
                            sBonus = Replace(sBonus, "$", "")
                            sBonus = Replace(sBonus, "€", "")
                            sBonus = Trim(sBonus)

                            If GLB_Import_CodeLen = "" Then
                                GLB_Import_CodeLen = 0
                            End If
                            EmpCode = GLB_Import_Prefix & EmpCode.PadLeft(GLB_Import_CodeLen, GLB_Import_PadingChar)


                            If sBonus = "" Then
                                DBL_Bonus = 0
                            Else
                                DBL_Bonus = CDbl(sBonus)
                            End If



                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.Code = "" Then
                                Dim Ans As New MsgBoxResult
                                'Ans = MsgBox("No Mapping was found for employee with code :" & EmpMapCode & " and Description: " & EmpName & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                Ans = MsgBox("No Employee was found with code :" & EmpCode & " ! Continue with the Remaining employees ?", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then

                                    param_file.Close()
                                    param_file.Dispose()
                                    If AtLeast1 Then
                                        MsgBox("File(s) from Time Attendance succesfully loaded", MsgBoxStyle.Information)
                                    End If
                                    Cursor.Current = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                AtLeast1 = True
                                Dim k As Integer
                                For k = 0 To MyDs.Tables(0).Rows.Count - 1
                                    If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                        If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                            Dim j As Integer = 0
                                            Dim C1 As Integer = 0
                                            Dim C2 As Integer = 0

                                            For j = 0 To 14
                                                If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                    Exit For
                                                End If

                                                If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = Me.GLBSelectedEDCforImport Then
                                                    MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = DBL_Bonus
                                                End If

                                                C1 = C1 + 2
                                            Next

                                            j = 0
                                            C1 = 0


                                        End If

                                        Exit For
                                    End If
                                Next
                            End If
                        Loop
                        param_file.Close()
                        param_file.Dispose()
                    Catch ex As Exception
                        Utils.ShowException(ex)
                        MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                        param_file.Close()
                        param_file.Dispose()

                    End Try
                Next
                DG1.Refresh()
                MsgBox("File(s) from Excel Template succesfully loaded", MsgBoxStyle.Information)

            Else
                MsgBox("Excel Template file Path is missing, please contact iNSoft!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please Search for employees before Uploading File", MsgBoxStyle.Critical)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ShowHeaderIdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHeaderIdToolStripMenuItem.Click
        If CheckDataSet(MyDs) Then
            Dim tEmpCode As String
            Dim i As Integer
            i = DG1.CurrentRow.Index
            tEmpCode = MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode)
            Dim Hdr As New cPrTxTrxnHeader(tEmpCode, Me.GLBCurrentPeriod.Code)
            If Hdr.Id > 0 Then
                MsgBox("Header Id: " & Hdr.Id & "  for Employee Code: " & tEmpCode, MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub ShowMaxMinHeaderIdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMaxMinHeaderIdToolStripMenuItem.Click
        Dim DsMinMax As DataSet
        Dim MinID As Long
        Dim MaxID As Long
        DsMinMax = Global1.Business.GetMinAndMaxIDOfUnsendTrxns(GLBTempGroup)
        If CheckDataSet(DsMinMax) Then
            MinId = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(0))
            MaxID = DbNullToInt(DsMinMax.Tables(0).Rows(0).Item(1))
            MsgBox("MinId: " & MinID & " MaxId: " & MaxID, MsgBoxStyle.Information)
        Else
            MsgBox("Not Found")
        End If
    End Sub

    Private Sub ImportTimeSheetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportTimeSheetsToolStripMenuItem.Click
        Dim F As New FrmImportTimeSheetsFromExcel
        F.GLB_TempGroup = Me.GLBTempGroup.Code
        F.GLB_PeriodGroup = Me.GLBCurrentPeriod.PrdGrpCode
        F.GLB_PeriodCode = Me.GLBCurrentPeriod.Code
        F.ShowDialog()
    End Sub

    Private Sub SelectEDCToImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectEDCToImportToolStripMenuItem.Click
        SelectEDCToImport()
    End Sub

    
    Private Sub ChangeEDCCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeEDCCodeToolStripMenuItem.Click
        Dim f As New FrmChangeEDCCodeFromLines
        f.TempGroup = GLBTempGroup
        f.Period = GLBCurrentPeriod
        f.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim F As New FrmPrTxClosePeriod
        F.MdiParent = Me.MdiParent
        F.CalledByTempGroup = Me.GLBTempGroup

        F.Show()
    End Sub

   

    Private Sub TSBSelectEDCtoImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSelectEDCtoImportExcel.Click

        If CheckDataSet(MyDs) Then
            Dim F As New FrmLoadEDCFromExcel
            F.Owner = Me
            F.dsErn = Me.DsP_Ern
            F.dsDed = Me.DsP_Ded
            F.dsCon = Me.DsP_Con

            Me.LFE_Proceed = False

            F.ShowDialog()
            If LFE_Proceed Then
                SelectEDCToImportFromExcel()
            End If
        Else
            MsgBox("Please select Employees first for this action", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub SelectEDCToImportFromExcel()
        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If LFE_File <> "" Then
                '''''''''''''
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet

                xlApp = New Excel.ApplicationClass

                Try


                    'on form load instantiate the connection object
                    Dim FileDir As String
                    Dim Exx As New Exception
                    'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
                    'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")

                    xlWorkBook = xlApp.Workbooks.Open(LFE_File)
                    xlWorkSheet = xlWorkBook.Worksheets(1)

                    Dim Line As String
                    Dim Ar() As String
                    'Do While param_file.Peek <> -1
                    Dim Counter As Integer
                    Counter = 0
                    Dim StopInput As Boolean = False
                    Counter = Me.LFE_FirstLine
                    Dim ErrorM As String = ""
                    Dim EmpCode As String
                    Dim sLoadValue As String
                    Dim LoadValue As Double

                    Do While StopInput = False

                        Application.DoEvents()

                        EmpCode = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_EmployeeColumnNo).value))
                        If EmpCode = "" Then
                            Exit Do
                        End If
                        sLoadValue = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_EDCValueColumnNo).value)
                        If IsNumeric(sLoadValue) Then
                            LoadValue = CDbl(sLoadValue)
                        Else
                            LoadValue = 0
                        End If


                        Dim k As Integer
                        Dim j As Integer = 0
                        Dim C1 As Integer = 0
                        Dim C2 As Integer = 0
                        For k = 0 To MyDs.Tables(0).Rows.Count - 1
                            If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                    If Me.LFE_LoadUnits Then
                                        MyDs.Tables(0).Rows(k).Item(Me.Column_ActualUnits) = LoadValue
                                    ElseIf Me.LFE_EDCType = "E" Then
                                        For j = 0 To 14
                                            If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                Exit For
                                            End If

                                            If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = Me.LFE_EDCCode Then
                                                MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = LoadValue
                                                Exit For
                                            End If

                                            C1 = C1 + 2
                                        Next
                                    ElseIf Me.LFE_EDCType = "D" Then
                                        For j = 0 To 14
                                            If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1)) = "" Then
                                                Exit For
                                            End If

                                            If MyDs.Tables(0).Rows(k).Item(Me.Column_D1 + C1) = Me.LFE_EDCCode Then
                                                MyDs.Tables(0).Rows(k).Item(Me.Column_DV1 + C1) = LoadValue
                                                Exit For
                                            End If

                                            C1 = C1 + 2
                                        Next

                                    ElseIf Me.LFE_EDCType = "C" Then
                                        For j = 0 To 14
                                            If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_C1 + C1)) = "" Then
                                                Exit For
                                            End If

                                            If MyDs.Tables(0).Rows(k).Item(Me.Column_C1 + C1) = Me.LFE_EDCCode Then
                                                MyDs.Tables(0).Rows(k).Item(Me.Column_CV1 + C1) = LoadValue
                                                Exit For
                                            End If

                                            C1 = C1 + 2
                                        Next

                                    End If

                                    j = 0
                                    C1 = 0
                                Else
                                    Exit For

                                End If


                                End If
                        Next
                        Counter = Counter + 1


                    Loop

                    MsgBox("File is uploaded", MsgBoxStyle.Information)

                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)


                Catch ex As Exception
                    Utils.ShowException(ex)
                    MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                End Try
            End If
        End If

        Cursor.Current = Cursors.Default

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub ImportValuesFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportValuesFromToolStripMenuItem.Click
        If CheckDataSet(MyDs) Then
            Dim F As New FrmLoadKELIO1
            F.Owner = Me

            Me.KELIO_Proceed = False

            F.ShowDialog()
            If KELIO_Proceed Then
                SelectKELIOToImportFromExcel()
            End If
        Else
            MsgBox("Please select Employees first for this action", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub SelectKELIOToImportFromExcel()
        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If KELIO_File <> "" Then
                '''''''''''''
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet

                xlApp = New Excel.ApplicationClass

                Try


                    'on form load instantiate the connection object
                    Dim FileDir As String
                    Dim Exx As New Exception
                    'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
                    'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")

                    xlWorkBook = xlApp.Workbooks.Open(KELIO_File)
                    xlWorkSheet = xlWorkBook.Worksheets(1)

                    Dim Line As String
                    Dim Ar() As String
                    'Do While param_file.Peek <> -1
                    Dim Counter As Integer
                    Counter = 0
                    Dim StopInput As Boolean = False
                    Counter = Me.LFE_FirstLine
                    Dim ErrorM As String = ""





                    Dim EmpCode As String
                    Dim ErnValue As Double
                    Dim Over1Value As Double
                    Dim Over2Value As Double
                    Dim PMValue As Double

                    Dim sErnValue As String
                    Dim sOver1Value As String
                    Dim sOver2Value As String
                    Dim sPMValue As String

                    Counter = Me.KELIO_FirstLine

                    Dim ErnCodeIndex As Integer = -1

                    Do While StopInput = False

                        Application.DoEvents()

                        EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.KELIO_EmployeeColumnNo).value)
                        If EmpCode = "" Then
                            Exit Do
                        End If
                        If Trim(KELIO_Prefix) <> "" Then
                            EmpCode = EmpCode.Replace(Me.KELIO_Prefix, "")
                        End If

                        sErnValue = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.KELIO_ErnColumnNo).value)
                        If IsNumeric(sErnValue) Then
                            ErnValue = CDbl(sErnValue)
                        Else
                            ErnValue = 0
                        End If

                        sOver1Value = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.KELIO_Over1).value)

                        If IsNumeric(sOver1Value) Then
                            Over1Value = CDbl(sOver1Value)
                        Else
                            Over1Value = 0
                        End If

                        sOver2Value = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.KELIO_Over2).value)
                        If IsNumeric(sOver2Value) Then
                            Over2Value = CDbl(sOver2Value)
                        Else
                            Over2Value = 0
                        End If

                        sPMValue = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.KELIO_PM).value)
                        If IsNumeric(sPMValue) Then
                            PMValue = CDbl(sPMValue)
                        Else
                            PMValue = 0
                        End If


                        Dim k As Integer
                        Dim j As Integer = 0
                        Dim C1 As Integer = 0
                        Dim C2 As Integer = 0

                        For k = 0 To MyDs.Tables(0).Rows.Count - 1
                            If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                    If ErnCodeIndex = -1 Then
                                        'If Me.LFE_EDCType = "E" Then
                                        For j = 0 To 14
                                            If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                Exit For
                                            End If

                                            If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = Me.KELIO_ErnCode Then
                                                ErnCodeIndex = Me.Column_EV1 + C1
                                                Exit For
                                            End If
                                            C1 = C1 + 2
                                        Next
                                        'End If
                                    End If

                                    MyDs.Tables(0).Rows(k).Item(ErnCodeIndex) = ErnValue
                                    MyDs.Tables(0).Rows(k).Item(Column_Overtime1) = Over1Value + PMValue
                                    MyDs.Tables(0).Rows(k).Item(Column_Overtime2) = Over2Value


                                End If
                            End If

                        Next
                        Counter = Counter + 1


                    Loop

                    MsgBox("File is uploaded", MsgBoxStyle.Information)

                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)


                Catch ex As Exception
                    Utils.ShowException(ex)
                    MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                End Try
            End If
        End If

        Cursor.Current = Cursors.Default

    End Sub
    Private Sub BtnNext1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext1.Click
        If CheckDataSet(GLBDsEmp) Then
            Dim Row As Integer
            Dim Code As String
            Row = GLBDsEmp.Tables(0).Rows.Count - 1
            Code = DbNullToString(GLBDsEmp.Tables(0).Rows(Row).Item(0))
            Sels_ArBegin(Sels_Counter) = DbNullToString(GLBDsEmp.Tables(0).Rows(0).Item(0))
            Sels_ArEnd(Sels_Counter) = DbNullToString(GLBDsEmp.Tables(0).Rows(Row).Item(0))
            SearchGlobal(Code, 1, "")
            Sels_Counter = Sels_Counter + 1
        End If
    End Sub

    Private Sub BtnPrevius1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius1.Click
        If CheckDataSet(GLBDsEmp) Or Sels_Counter > 0 Then
            If Sels_Counter = 0 Then Exit Sub
            Sels_Counter = Sels_Counter - 1
            SearchGlobal(Sels_ArBegin(Sels_Counter), -1, Sels_ArEnd(Sels_Counter))
        End If
    End Sub
    Private Sub TSBImportOvertimeFileExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBImportOvertimeFileExcel.Click
        If CheckDataSet(MyDs) Then
            Dim F As New FrmLoadOvertimesFromExcel1
            F.Owner = Me
            '  F.dsErn = Me.DsP_Ern
            '  F.dsDed = Me.DsP_Ded
            '  F.dsCon = Me.DsP_Con

            Me.LFE_OV1_Proceed = False

            F.ShowDialog()
            If LFE_OV1_Proceed Then
                SelectOverTimeToImportFromExcel()
            End If
        Else
            MsgBox("Please select Employees first for this action", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub SelectOverTimeToImportFromExcel()

        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If LFE_OV1_File <> "" Then
                '''''''''''''
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet

                xlApp = New Excel.ApplicationClass

                Try


                    'on form load instantiate the connection object
                    Dim FileDir As String
                    Dim Exx As New Exception
                    'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
                    'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")

                    xlWorkBook = xlApp.Workbooks.Open(LFE_OV1_File)
                    xlWorkSheet = xlWorkBook.Worksheets(1)

                    Dim Line As String
                    Dim Ar() As String
                    'Do While param_file.Peek <> -1
                    Dim Counter As Integer
                    Counter = 0
                    Dim StopInput As Boolean = False
                    Counter = Me.LFE_OV1_FirstLine
                    Dim ErrorM As String = ""
                    Dim EmpCode As String
                    Dim sLoadValue As String
                    Dim LoadValue As Double

                    Dim sTimeOff As String
                    Dim TimeOff As Double

                    Dim sOv1 As String
                    Dim sOv2 As String
                    Dim Ov1 As Double
                    Dim Ov2 As Double

                    Dim colTimeOff As Integer = 3
                    Dim colOV1 As Integer = 6
                    Dim colOV2 As Integer = 7

                    Do While StopInput = False
                        Application.DoEvents()
                        EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_OV1_EmployeeColumnNo).value)
                        If EmpCode = "" Then
                            Exit Do
                        End If
                        EmpCode = EmpCode.PadLeft(Me.LFE_OV1_EmployeeTotalLen, Me.LFE_OV1_EmployeePrefix)

                        sTimeOff = NothingToEmpty(xlWorkSheet.Cells(Counter, colTimeOff).value)
                        If IsNumeric(sTimeOff) Then
                            TimeOff = CDbl(sTimeOff)
                        Else
                            TimeOff = 0
                        End If

                        sOv1 = NothingToEmpty(xlWorkSheet.Cells(Counter, colOV1).value)
                        If IsNumeric(sOv1) Then
                            Ov1 = CDbl(sOv1)
                        Else
                            Ov1 = 0
                        End If

                        sOv2 = NothingToEmpty(xlWorkSheet.Cells(Counter, colOV2).value)
                        If IsNumeric(sOv2) Then
                            Ov2 = CDbl(sOv2)
                        Else
                            Ov2 = 0
                        End If



                        Dim k As Integer
                        Dim j As Integer = 0
                        Dim C1 As Integer = 0
                        Dim C2 As Integer = 0
                        For k = 0 To MyDs.Tables(0).Rows.Count - 1
                            If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                    If Me.LFE_OV1_EDCType = "E" Then
                                        For j = 0 To 14
                                            If DbNullToString(MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1)) = "" Then
                                                Exit For
                                            End If

                                            If MyDs.Tables(0).Rows(k).Item(Me.Column_E1 + C1) = Me.LFE_OV1_EDCCode Then
                                                MyDs.Tables(0).Rows(k).Item(Me.Column_EV1 + C1) = TimeOff
                                                MyDs.Tables(0).Rows(k).Item(Me.Column_Overtime1) = Ov1
                                                MyDs.Tables(0).Rows(k).Item(Me.Column_Overtime2) = Ov2
                                                Exit For
                                            End If
                                            C1 = C1 + 2
                                        Next
                                    End If
                                    j = 0
                                    C1 = 0
                                  
                                Else
                                    Exit For

                                End If
                            End If
                        Next

                        

                        Counter = Counter + 1

                    Loop


                    MsgBox("File is uploaded", MsgBoxStyle.Information)

                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)



                Catch ex As Exception
                    Utils.ShowException(ex)
                    MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                End Try
            End If
        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub ImportOvertimeFile2ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportOvertimeFile2ExcelToolStripMenuItem.Click

        If CheckDataSet(MyDs) Then
            Dim F As New FrmLoadOvertimesFromExcel2
            F.Owner = Me
            '  F.dsErn = Me.DsP_Ern
            '  F.dsDed = Me.DsP_Ded
            '  F.dsCon = Me.DsP_Con

            Me.LFE_OV2_Proceed = False

            F.ShowDialog()
            If LFE_OV2_Proceed Then
                SelectOverTime2ToImportFromExcel()
            End If
        Else
            MsgBox("Please select Employees first for this action", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub SelectOverTime2ToImportFromExcel()

        Cursor.Current = Cursors.WaitCursor
        If CheckDataSet(MyDs) Then
            If LFE_OV2_File <> "" Then
                '''''''''''''
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet

                xlApp = New Excel.ApplicationClass

                Try


                    'on form load instantiate the connection object
                    Dim FileDir As String
                    Dim Exx As New Exception
                    'param_file = IO.File.OpenText("Data\Excel\Employees.txt")
                    'xlWorkBook = xlApp.Workbooks.Open("c:\NodalWin\Payroll\Data\Excel\Excel1.xlsx")

                    xlWorkBook = xlApp.Workbooks.Open(LFE_OV2_File)
                    xlWorkSheet = xlWorkBook.Worksheets(1)

                    Dim Line As String
                    Dim Ar() As String
                    'Do While param_file.Peek <> -1
                    Dim Counter As Integer
                    Counter = 0
                    Dim StopInput As Boolean = False
                    Counter = Me.LFE_OV2_FirstLine
                    Dim ErrorM As String = ""
                    Dim EmpCode As String
                    Dim sLoadValue As String
                    Dim LoadValue As Double

                    
                    Dim sOv1 As String
                    Dim sOv2 As String
                    Dim sOv3 As String
                    Dim Ov1 As Double
                    Dim Ov2 As Double
                    Dim Ov3 As Double

                 

                    Do While StopInput = False
                        Application.DoEvents()
                        EmpCode = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_OV2_EmployeeColumnNo).value)
                        If EmpCode = "" Then
                            Exit Do
                        End If
                        EmpCode = EmpCode.PadLeft(Me.LFE_OV2_EmployeeTotalLen, Me.LFE_OV2_EmployeePrefix)

                        If Me.LFE_OV2_colOver1 <> "" Then
                            If IsNumeric(Me.LFE_OV2_colOver1) Then
                                LFE_OV2_icolOver1 = LFE_OV2_colOver1
                                sOv1 = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_OV2_icolOver1).value)
                                If IsNumeric(sOv1) Then
                                    Ov1 = CDbl(sOv1)
                                Else
                                    Ov1 = 0
                                End If
                            End If
                        End If
                        If Me.LFE_OV2_colOver2 <> "" Then
                            If IsNumeric(Me.LFE_OV2_colOver2) Then
                                LFE_OV2_icolOver2 = LFE_OV2_colOver2
                                sOv2 = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_OV2_icolOver2).value)
                                If IsNumeric(sOv2) Then
                                    Ov2 = CDbl(sOv2)
                                Else
                                    Ov2 = 0
                                End If
                            End If
                        End If
                        If Me.LFE_OV2_colOver3 <> "" Then
                            If IsNumeric(Me.LFE_OV2_colOver3) Then
                                LFE_OV2_icolOver3 = LFE_OV2_colOver3
                                sOv3 = NothingToEmpty(xlWorkSheet.Cells(Counter, Me.LFE_OV2_icolOver3).value)
                                If IsNumeric(sOv3) Then
                                    Ov3 = CDbl(sOv3)
                                Else
                                    Ov3 = 0
                                End If
                            End If
                        End If



                        Dim k As Integer

                        For k = 0 To MyDs.Tables(0).Rows.Count - 1
                            If MyDs.Tables(0).Rows(k).Item(2) = EmpCode Then
                                If MyDs.Tables(0).Rows(k).Item(0) <> "CALC" And MyDs.Tables(0).Rows(k).Item(0) <> "POST" Then
                                    MyDs.Tables(0).Rows(k).Item(Me.Column_Overtime1) = Ov1
                                    MyDs.Tables(0).Rows(k).Item(Me.Column_Overtime2) = Ov2
                                    MyDs.Tables(0).Rows(k).Item(Me.Column_Overtime3) = Ov3
                                    Exit For
                                Else
                                    Exit For

                                End If
                            End If
                        Next



                        Counter = Counter + 1

                    Loop


                    MsgBox("File is uploaded", MsgBoxStyle.Information)

                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)



                Catch ex As Exception
                    Utils.ShowException(ex)
                    MsgBox("Unable to Load Template File", MsgBoxStyle.Critical)
                    xlWorkBook.Close()
                    xlApp.Quit()
                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                End Try
            End If
        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub ShowEmployeesWithManualTaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowEmployeesWithManualTaxToolStripMenuItem.Click
        Dim ds As DataSet
        ds = Global1.Business.getEmployeesWithManualTax(Me.GLBTempGroup.Code)
        If CheckDataSet(ds) Then
            Dim F As New frmManualTaxEmployees
            F.ds = ds
            F.ShowDialog()
        Else
            MsgBox("There are not employees with Manual Tax", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub LabelsPrintingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelsPrintingToolStripMenuItem.Click
        LabelPrinting()
    End Sub
    Private Sub LabelPrinting()
        If CheckDataSet(MyDs) Then
            DsLbl.Tables(0).Rows.Clear()
            Dim i As Integer
            Dim Ds As DataSet
            Dim k As Integer = 0
            Dim X As Integer = 0
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                If i = 0 Then
                    k = 1
                End If
                Dim EmpCode As String
                EmpCode = MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode)
                Ds = Global1.Business.GetEployeeInfoForLabels(EmpCode)
                If CheckDataSet(Ds) Then
                    Dim r As DataRow = DtLbl.NewRow()
                    If k = 1 Then
                        r(0) = DbNullToString(Ds.Tables(0).Rows(0).Item(0))
                        r(1) = DbNullToString(Ds.Tables(0).Rows(0).Item(1))
                        r(2) = DbNullToString(Ds.Tables(0).Rows(0).Item(2))
                        r(3) = DbNullToString(Ds.Tables(0).Rows(0).Item(3))
                        r(4) = ""
                        r(5) = ""
                        r(6) = ""
                        r(7) = ""
                        k = 2
                        DtLbl.Rows.Add(r)
                        X = X + 1
                    Else
                        DtLbl.Rows(X - 1).Item(4) = DbNullToString(Ds.Tables(0).Rows(0).Item(0))
                        DtLbl.Rows(X - 1).Item(5) = DbNullToString(Ds.Tables(0).Rows(0).Item(1))
                        DtLbl.Rows(X - 1).Item(6) = DbNullToString(Ds.Tables(0).Rows(0).Item(2))
                        DtLbl.Rows(X - 1).Item(7) = DbNullToString(Ds.Tables(0).Rows(0).Item(3))
                        k = 1
                    End If

                End If
            Next
            'Utils.WriteSchemaWithXmlTextWriter(DsLbl, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\Labels")
            Utils.ShowReport("Labels1.rpt", DsLbl, FrmReport, "", False, "", False, False, "", False)
        Else
            MsgBox("Please select Employees first", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub EmployeesEDCReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesEDCReportToolStripMenuItem.Click
        If DG1.IsCurrentCellInEditMode Then
            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DG1.EndEdit()
        End If

        If CheckDataSet(MyDs) Then
            Dim i As Integer
            'Dim Saved As Integer = 0
            'Dim Status As String
            'Dim Selected As String
            'Dim Proceed As Boolean = False
            'Dim EmpCode As String = ""
            'Dim EmpName As String = ""
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                '    Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                '    Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                '    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                '    EmpName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpName))
                '    If Status <> "POST" And Status <> "CALC" Then
                '        If Selected = "1" Then
                '            'Application.DoEvents()
                '            Proceed = True
                '            'Proceed = False
                '            'If Status = "CALC" Then
                '            '    ans = MsgBox("Recalculate Line " & i + 1 & " - Employee Code: " & EmpCode & " ?", MsgBoxStyle.YesNo)
                '            '    If ans = MsgBoxResult.Yes Then
                '            '        Proceed = True
                '            '    End If
                '            'Else
                '            '    Proceed = True
                '            'End If
                '            If Proceed Then
                '                LabelStatus.Text = "Calculating Payroll for Employee (" & (Saved + 1) & ") " & EmpCode & " - " & EmpName
                '                Application.DoEvents()
                '                Saved = Saved + 1
                '                If Not LoadValuesFromGridToFormCalculations(i, 1) Then
                '                    Saved = Saved - 1
                '                End If
                '            End If
                '        End If
                '    End If
            Next

        Else
            MsgBox("Please Select Employees First")
        End If
        LabelStatus.Text = ""

    End Sub
    'Private Sub temp()

    '    DtR = New DataTable("TableR")
    '    '0
    '    Dim colREmpCodeas As Integer  =
    '    '1
    '    Dim colREmpNameas As Integer = 1

    '    '''''''''''''''''''''''Earnings''''''''''''''''''''''
    '    '2
    '    Dim colRErn1as As Integer = 2
    '    '3
    '    Dim colREVal1as As Integer = 3
    '    '4
    '    Dim colRErn2as As Integer = 4
    '    '5
    '    Dim colREVal2as As Integer = 5
    '    '6
    '    Dim colRErn3as As Integer = 6
    '    '7
    '    Dim colREVal3as As Integer = 7
    '    '8
    '    Dim colRErn4as As Integer = 8
    '    '9
    '    Dim colREVal4as As Integer = 9
    '    '10
    '    Dim colRErn5as As Integer = 10
    '    '11
    '    Dim colREVal5as As Integer = 11
    '    '12
    '    Dim colRErn6as As Integer = 12
    '    '13
    '    Dim colREVal6as As Integer = 13
    '    '14
    '    Dim colRErn7as As Integer = 14
    '    '15
    '    Dim colREVal7as As Integer = 15
    '    '16
    '    Dim colRErn8as As Integer = 16
    '    '17
    '    Dim colREVal8as As Integer = 17
    '    '18
    '    Dim colRErn9as As Integer = 18
    '    '19
    '    Dim colREVal9as As Integer = 19
    '    '20
    '    Dim colRErn10as As Integer = 20
    '    '21
    '    Dim colREVal10as As Integer = 21
    '    '22
    '    Dim colRErn11as As Integer = 22
    '    '23
    '    Dim colREVal11as As Integer = 23
    '    '24
    '    Dim colRErn12as As Integer = 24
    '    '25
    '    Dim colREVal12as As Integer = 25
    '    '26
    '    Dim colRErn13as As Integer = 26
    '    '27
    '    Dim colREVal13as As Integer = 27
    '    '28
    '    Dim colRErn14as As Integer = 28
    '    '29
    '    Dim colREVal14as As Integer = 29
    '    '30
    '    Dim colRErn15as As Integer = 30
    '    '31
    '    Dim colREVal15as As Integer = 31
    '    ''''''''''''''''''''''Deductions''''''''''''''''''''''
    '    '32
    '    Dim colRDed1as As Integer = 32
    '    '33
    '    Dim colRDVal1as As Integer = 33
    '    '34
    '    Dim colRDed2as As Integer = 34
    '    '35
    '    Dim colRDVal2as As Integer = 35
    '    '36
    '    Dim colRDed3as As Integer = 36
    '    '37
    '    Dim colRDVal3as As Integer = 37
    '    '38
    '    Dim colRDed4as As Integer = 38
    '    '39
    '    Dim colRDVal4as As Integer = 39
    '    '40
    '    Dim colRDed5as As Integer = 40
    '    '41
    '    Dim colRDVal5as As Integer = 1
    '    '42
    '    Dim colRDed6as As Integer = 2
    '    '43
    '    Dim colRDVal6as As Integer = 3
    '    '44
    '    Dim colRDed7as As Integer = 4
    '    '45
    '    Dim colRDVal7as As Integer = 5
    '    '46
    '    Dim colRDed8as As Integer = 6
    '    '47
    '    Dim colRDVal8as As Integer = 7
    '    '48
    '    Dim colRDed9as As Integer = 8
    '    '49
    '    Dim colRDVal9as As Integer = 9
    '    '50
    '    Dim colRDed10as As Integer = 0
    '    '51
    '    Dim colRDVal10as As Integer  =
    '    '52
    '    Dim colRDed11as As Integer  =
    '    '53
    '    Dim colRDVal11as As Integer  =
    '    '54
    '    Dim colRDed12as As Integer  =
    '    '55
    '    Dim colRDVal12as As Integer  =
    '    '56
    '    Dim colRDed13as As Integer  =
    '    '57
    '    Dim colRDVal13as As Integer  =
    '    '58
    '    Dim colRDed14as As Integer  =
    '    '59
    '    Dim colRDVal14as As Integer  =
    '    '60
    '    Dim colRDed15as As Integer  =
    '    '61
    '    Dim colRDVal15as As Integer  =
    '    ''''''''''''''''''''''Contributions''''''''''''''''''''''
    '    '62
    '    Dim colRCon1as As Integer  =
    '    '63
    '    Dim colRCVal1as As Integer  =
    '    '64
    '    Dim colRCon2as As Integer  =
    '    '65
    '    Dim colRCVal2as As Integer  =
    '    '66
    '    Dim colRCon3as As Integer  =
    '    '67
    '    Dim colRCVal3as As Integer  =
    '    '68
    '    Dim colRCon4as As Integer  =
    '    '69
    '    Dim colRCVal4as As Integer  =
    '    '70
    '    Dim colRCon5as As Integer  =
    '    '71
    '    Dim colRCVal5as As Integer  =
    '    '72
    '    Dim colRCon6as As Integer  =
    '    '73
    '    Dim colRCVal6as As Integer  =
    '    '74
    '    Dim colRCon7as As Integer  =
    '    '75
    '    Dim colRCVal7as As Integer  =
    '    '76
    '    Dim colRCon8as As Integer  =
    '    '77
    '    Dim colRCVal8as As Integer  =
    '    '78
    '    Dim colRCon9as As Integer  =
    '    '79
    '    Dim colRCVal9as As Integer  =
    '    '80
    '    Dim colRCon10as As Integer  =
    '    '81
    '    Dim colRCVal10as As Integer  =
    '    '82
    '    Dim colRCon11as As Integer  =
    '    '83
    '    Dim colRCVal11as As Integer  =
    '    '84
    '    Dim colRCon12as As Integer  =
    '    '85
    '    Dim colRCVal12as As Integer  =
    '    '86
    '    Dim colRCon13as As Integer  =
    '    '87
    '    Dim colRCVal13as As Integer  =
    '    '88
    '    Dim colRCon14as As Integer  =
    '    '89
    '    Dim colRCVal14as As Integer  =
    '    '90
    '    Dim colRCon15as As Integer  =
    '    '91
    '    Dim colRCVal15as As Integer  =
    'End Sub

    Private Sub PrepareInterface_Dedtors(ByVal Header As DataSet, ByVal MinId As Integer, ByVal MaxID As Integer, ByVal FromHistory As Boolean, ByVal FName As String, ByVal Batch As cPrSsNavBatch, ByVal PostingDate As Date)
        
        If CheckDataSet(Header) Then
            Dim i As Integer
            Dim Hdr As New cPrTxTrxnHeader
            Dim Emp As New cPrMsEmployees
            Dim DedtorsControlAccount As String = GLBDedtorsControl
            Dim LoanDeductionCode As String = GLBLoanDedCode
            Dim RentDeductionCode As String = GLBRentDedCode
            Dim DsLine As DataSet
            Dim Counter As Integer = 0
            Dim SEP As String = "|||"

            InitFileDedtors = True

            DedtorsFile = Me.GLBTempGroup.Code & "_" & "Ded" & ".txt"

            For i = 0 To Header.Tables(0).Rows.Count - 1
                Application.DoEvents()
                Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                Emp = New cPrMsEmployees(Hdr.Emp_Code)
                Dim LoanAccount As String = 0
                Dim LoanAmount As String = 0
                Dim RentAccount As String = ""
                Dim RentAmount As String = ""
                LoanAccount = Emp.Emp_GLAnal1
                RentAccount = Emp.Emp_GLAnal2
                Dim Line As String
                LoanAmount = Global1.Business.GetTrxLineDeductionOfCODE(LoanDeductionCode, Hdr.Id)
                If LoanAmount <> 0 Then
                    Counter = Counter + 1
                    Line = Counter & SEP
                    Line = Line & Emp.Code & SEP
                    Line = Line & LoanAmount & SEP
                    Line = Line & LoanAccount & SEP
                    Line = Line & DedtorsControlAccount & SEP
                    Line = Line & Format(PostingDate, "dd-MM-yyyy")
                    WriteTo_DedtorsFile(Line, DedtorsFile)
                End If

                RentAmount = Global1.Business.GetTrxLineDeductionOfCODE(RentDeductionCode, Hdr.Id)
                If RentAmount <> 0 Then
                    Counter = Counter + 1
                    Line = Counter & SEP
                    Line = Line & Emp.Code & SEP
                    Line = Line & RentAmount & SEP
                    Line = Line & RentAccount & SEP
                    Line = Line & DedtorsControlAccount & SEP
                    Line = Line & Format(PostingDate, "dd-MM-yyyy")
                    WriteTo_DedtorsFile(Line, DedtorsFile)
                End If

            Next
        End If
    End Sub
    Private Function WriteTo_DedtorsFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = NAVOUTFileDir & "\" & fName
            Dim TW As System.IO.TextWriter

            If InitFileDedtors Then
                TW = System.IO.File.CreateText(FileName)
                InitFileDedtors = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
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
    Private Sub PrepareInterface_Creditors(ByVal Header As DataSet, ByVal MinId As Integer, ByVal MaxID As Integer, ByVal FromHistory As Boolean, ByVal FName As String, ByVal Batch As cPrSsNavBatch, ByVal PostingDate As Date)

       
        If CheckDataSet(Header) Then
            Dim i As Integer
            Dim Hdr As New cPrTxTrxnHeader
            Dim Emp As New cPrMsEmployees
            Dim CreditorsControlAccount As String = GLBCreditorsControl
            Dim SavingsDeductionCode As String = GLBSavingsDedCode
            Dim DsLine As DataSet
            Dim Counter As Integer = 0
            Dim SEP As String = "|||"

            InitFileCreditors = True

            CreditorsFile = Me.GLBTempGroup.Code & "_" & "Cre" & ".txt"

            For i = 0 To Header.Tables(0).Rows.Count - 1
                Hdr = New cPrTxTrxnHeader(Header.Tables(0).Rows(i))
                Emp = New cPrMsEmployees(Hdr.Emp_Code)
                Dim SavingsAccount As String = 0
                Dim SavingsAmount As String = 0
                
                SavingsAccount = Emp.Emp_GLAnal3

                Dim Line As String
                SavingsAmount = Global1.Business.GetTrxLineDeductionOfCODE(SavingsDeductionCode, Hdr.Id)
                If SavingsAmount <> 0 Then
                    Counter = Counter + 1
                    Line = Counter & SEP
                    Line = Line & Emp.Code & SEP
                    Line = Line & SavingsAmount & SEP
                    Line = Line & SavingsAccount & SEP
                    Line = Line & CreditorsControlAccount & SEP
                    Line = Line & Format(PostingDate, "dd-MM-yyyy")
                    WriteTo_creditorsFile(Line, CreditorsFile)
                End If
            Next
        End If
    End Sub
    Private Function WriteTo_CreditorsFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = NAVOUTFileDir & "\" & fName
            Dim TW As System.IO.TextWriter

            If InitFileCreditors Then
                TW = System.IO.File.CreateText(FileName)
                InitFileCreditors = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
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

    Private Sub btnMyReminders_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyReminders.ButtonClick
        ShowMyReminders()
    End Sub
    Private Sub ShowMyReminders()
        Dim F As New frmMyReminders
        F.TemGroup = Me.GLBTempGroup
        F.Period = GLBCurrentPeriod
        F.Owner = Me
        F.ShowDialog()
        CountReminders()
    End Sub
    Private Sub CountReminders()
        Dim C As Integer
        C = Global1.Business.CountRemindersForPeriodForTemGroup(GLBTempGroup.Code, GLBCurrentPeriod.DateFrom, GLBCurrentPeriod.DateTo)
        Me.btnMyReminders.Text = "My Reminders (" & C & ")"
        If C <> 0 Then
            MsgBox("You have an Active reminder for this Month, Please click on 'My Reminders' to see it", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtFromEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromEmployee.TextChanged
        Me.txtToEmployee.Text = Me.txtFromEmployee.Text
    End Sub
    Public Sub LoadNextEmployee(ByVal NextEmployee As Boolean, ByVal PreviousEmployee As Boolean, ByVal GridIndex As Integer)
        GLBRunNext = False
        GLBRunPrevious = False
        If CheckDataSet(MyDs) Then

            If NextEmployee Then
                GridIndex = GridIndex + 1
            End If
            If PreviousEmployee Then
                GridIndex = GridIndex - 1
            End If
            If GridIndex >= 0 Then
                If GridIndex <= MyDs.Tables(0).Rows.Count - 1 Then

                    DG1.ClearSelection()
                    DG1.CurrentCell = DG1.Rows(GridIndex).Cells(0)
                    'DG1.Rows(GridIndex).Selected = True


                    DG1.Rows(GridIndex).Selected = True


                    LoadValuesFromGridToFormCalculations(GridIndex, 0)
                End If
            End If


        End If
    End Sub

    Private Sub CalculateTotals()
        If CheckDataSet(MyDs) Then

            Dim DtC As New DataTable
            DtC = Dt1.Copy
            DtC.Rows.Clear()


            Dim i As Integer
            Dim k As Integer
            Dim Ar(MyDs.Tables(0).Columns.Count - 1) As String
            Dim r As DataRow = DtC.NewRow()
            For k = 0 To MyDs.Tables(0).Columns.Count - 1
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    If Not IsNothing(MyDs.Tables(0).Rows(i).Item(k)) Then
                        If IsNumeric(MyDs.Tables(0).Rows(i).Item(k)) Then
                            Ar(k) = Ar(k) + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(k))
                        Else
                            Ar(k) = 0 'DbNullToString(MyDs.Tables(0).Rows(i).Item(k))
                        End If
                    End If
                Next

                r(k) = Ar(k)

            Next
            DtC.Rows.Add(r)
            Dim Dss As New DataSet
            Dss.Tables.Add(DtC.Copy)
            Dim F As New FrmTotalsOfDG
            '   F.Width = Me.Width
            '   F.Left = Me.Left
            F.DG1.DataSource = Dss.Tables(0)
            For i = 0 To DG1.Columns.Count - 1
                F.DG1.Columns(i).HeaderText = DG1.Columns(i).HeaderText
                F.DG1.Columns(i).ReadOnly = DG1.Columns(i).ReadOnly
                F.DG1.Columns(i).Visible = DG1.Columns(i).Visible
                F.DG1.Columns(i).Width = DG1.Columns(i).Width
            Next
            F.ShowDialog()
        End If
    End Sub
   
   
    
   
    Private Sub btnShowTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowTotals.Click
        CalculateTotals()
    End Sub

    
    Private Sub CurrentMonthLeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentMonthLeaveToolStripMenuItem.Click
        If CheckDataSet(MyDs) Then
            Dim i As Integer
            Dim Saved As Integer = 0
            Dim Status As String
            Dim Selected As String
            Dim Proceed As Boolean = False
            Dim EmpCode As String = ""
            Dim EmpName As String = ""
            Dim ActualUnits As Double = 0
            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                Status = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Status))
                Selected = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Enabled))
                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                EmpName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpName))
                ActualUnits = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))

                Proceed = False
                If Status = "POST" Then
                    If Selected = "1" Then
                        Dim H As New cPrTxTrxnHeader(EmpCode, Me.GLBCurrentPeriod.Code)
                        If H.Id > 0 Then
                            If H.Status = "POST" Then
                                If H.InterfaceStatus = "POST" Then
                                    Proceed = True
                                Else
                                    MsgBox("Please Interface to Accounting before proceeding to this action", MsgBoxStyle.Information)
                                    Exit Sub
                                End If
                                If Proceed Then
                                    If ActualUnits <> GLBCurrentPeriod.PeriodUnits Then
                                        Dim F As New FrmSILeaveFrom
                                        F.GLBEmpName = EmpName
                                        F.GLBEmpCode = EmpCode
                                        F.Header = H
                                        F.DefFdate = Me.GLBCurrentPeriod.DateFrom.Date
                                        F.DefTdate = Me.GLBCurrentPeriod.DateTo.Date
                                        F.DefUnits = GLBCurrentPeriod.PeriodUnits
                                        F.ActualUnits = ActualUnits
                                        F.ShowDialog()
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("Please Calculate/Post and Interface to Accounting before proceeding to this action", MsgBoxStyle.Information)
                    Exit For
                End If
            Next
        Else
            MsgBox("Please select Employees first", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub mnuPayrollAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPayrollAnalysis.Click
        Dim F As New FrmPayrollTotalsX
        F.MdiParent = Me.MdiParent
        F.Show()
        Dim PerGroup As New cPrMsPeriodGroups(GLBCurrentPeriod.PrdGrpCode)
        F.cmbPeriodGroups.SelectedIndex = F.cmbPeriodGroups.FindStringExact(PerGroup.ToString)
        F.CmbPeriod.SelectedIndex = F.CmbPeriod.FindStringExact(GLBCurrentPeriod.ToString)
        F.cmbPeriodTo.SelectedIndex = F.cmbPeriodTo.FindStringExact(GLBCurrentPeriod.ToString)
    End Sub
    Private Sub mnuSIReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSIReports.Click
        Dim F As New FrmRptSIContributions
        F.MdiParent = Me.MdiParent
        F.Show()
        Dim PerGroup As New cPrMsPeriodGroups(GLBCurrentPeriod.PrdGrpCode)
        F.cmbPeriodGroups.SelectedIndex = F.cmbPeriodGroups.FindStringExact(PerGroup.ToString)

    End Sub

    Private Sub mnuIRReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIRReports.Click
        Dim F As New FrmIR63A
        F.MdiParent = Me.MdiParent
        F.Show()
        Dim PerGroup As New cPrMsPeriodGroups(GLBCurrentPeriod.PrdGrpCode)
        F.cmbPeriodGroups.SelectedIndex = F.cmbPeriodGroups.FindStringExact(PerGroup.ToString)
    End Sub

    Private Sub LblCount_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCount.DoubleClick
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("Stop Search ?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            StopSearch = True
        End If
    End Sub

    Private Sub BtnOpenExportFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenExportFiles.Click
        Dim ExportFiledir As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("NAVOut", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            ExportFiledir = Replace(Par.Value1, "$", Global1.GLBUserCode)
            Process.Start(ExportFiledir)
        Else
            MsgBox("Missing Parameter Section 'NAVOut' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Exit Sub
        End If

    End Sub
    Public Sub AddNegativeNet(ByVal EmpCode As String, ByVal EmpName As String, ByVal Net As Double)
        Dim r As DataRow = DtNet.NewRow()
        r(0) = EmpCode
        r(1) = EmpName
        r(2) = Net
        DtNet.Rows.Add(r)
    End Sub

    Private Sub TransferEDCCodeValuesFromEDCToEDCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferEDCCodeValuesFromEDCToEDCToolStripMenuItem.Click
        Dim f As New FrmTransferEDCCodeValueFromLines
        f.Tempgroup = GLBTempGroup
        f.Period = GLBCurrentPeriod
        f.ShowDialog()
    End Sub

    
    Private Sub LoadInterfaceFileEsoft(ByVal Filename As String, ByVal newTemp As Boolean, ByVal ReadFrom As String, ByVal PeriodCode As String)

        InitFileSAP = True
        Dim Period As New cPrMsPeriodCodes(PeriodCode, GLBTempGroup.Code)

        Dim Company As New cAdMsCompany(Me.GLBTempGroup.CompanyCode.ToString)
        Filename = "Esoft_" & Company.NameShort & ".txt"
        Dim Line As String
        Dim Postingdate As Date
        Postingdate = NavisionPostingdate.Date
        Dim PostArr() As String
        PostArr = Format(Postingdate, "dd/MM/yyyy").ToString.Split("/")





        Dim Exx As New Exception
        Dim HeaderLine As String
        Dim param_file1 As IO.StreamReader
        Dim param_file2 As IO.StreamReader
        ReadFrom = NAVOUTFileDir & ReadFrom
        param_file1 = IO.File.OpenText(ReadFrom)


        Dim Ar() As String
        Dim Amount As Double
        Dim Accountcode As String
        Dim Description As String
        Dim analysis As String
        Dim Counter As Integer
        Dim MyDate As String
        Dim Total As Double = 0
        Dim Debit As Double = 0
        Dim Credit As Double = 0
        Dim comment As String = ""
        Dim analysis3 As String = ""

        Dim c1_PayDate As String
        Dim c2_AccountCode As String
        Dim c3_AccountSystem As String
        Dim c4_ChechNo As String
        Dim c5_Debit As String
        Dim c6_Credit As String
        Dim c7_ProjectCode As String
        Dim c8_CostingDetails As String
        Dim c9_CostingCode2 As String
        Dim c10_CostingName2 As String
        Dim c11_EmployeeName As String
        Dim c12_CustomerName As String
        Dim c13_Hours As String
        Dim NoOfLines As Integer
        Dim DebitAmount As Double
        Dim CreditAmount As Double

        Dim L As String

        Do While param_file1.Peek <> -1
            NoOfLines = NoOfLines + 1
            Line = param_file1.ReadLine()
            Ar = Line.Split("|||")
            Amount = Ar(51)
            If Amount < 0 Then
                DebitAmount = DebitAmount + Math.Abs(Amount)
            Else
                CreditAmount = CreditAmount + Math.Abs(Amount)
            End If
        Loop

        Dim h1 As String = "H"
        Dim h2 As String = Company.GLAnal5
        Dim h3 As String = "PRL"
        Dim h4 As String = PostArr(2)
        Dim h5 As String = PostArr(1)
        Dim h6 As String = Format(Postingdate, "dd/MM/yyyy").ToString
        Dim h7 As String = ""
        Dim h8 As String = NoOfLines
        Dim h9 As String = "0"
        Dim h10 As String = ""
        Dim h11 As String = CreditAmount
        Dim h12 As String = DebitAmount
        Dim h13 As String = ""
        Dim h14 As String = ""

        Dim Header As String
        Dim Del1 As String = "|"
        Header = h1 & Del1
        Header = Header & h2 & Del1
        Header = Header & h3 & Del1
        Header = Header & h4 & Del1
        Header = Header & h5 & Del1
        Header = Header & h6 & Del1
        Header = Header & h7 & Del1
        Header = Header & h8 & Del1
        Header = Header & h9 & Del1
        Header = Header & h10 & Del1
        Header = Header & h11 & Del1
        Header = Header & h12 & Del1
        Header = Header & h13 & Del1
        Header = Header & h14

        WriteTo_ESOFT_File(Header, Filename)

        param_file2 = IO.File.OpenText(ReadFrom)



        Dim l1 As String = ""
        Dim l2 As String = ""
        Dim l3 As String = ""
        Dim l4 As String = ""
        Dim l5 As String = ""
        Dim l6 As String = ""
        Dim l7 As String = ""
        Dim l8 As String = ""
        Dim l9 As String = ""
        Dim l10 As String = ""
        Dim l11 As String = ""
        Dim l12 As String = ""
        Dim l13 As String = ""
        Dim l14 As String = ""
        Dim l15 As String = ""
        Dim l16 As String = ""
        Dim l17 As String = ""
        Dim l18 As String = ""
        Dim l19 As String = ""
        Dim l20 As String = ""
        Dim l21 As String = ""
        Dim l22 As String = ""
        Dim l23 As String = ""
        Dim l24 As String = ""
        Dim l25 As String = ""
        Dim l26 As String = ""
        Dim l27 As String = ""
        Dim l28 As String = ""
        Dim l29 As String = ""
        Dim l30 As String = ""
        Dim l31 As String = ""
        Dim l32 As String = ""
        Dim l33 As String = ""
        Dim l34 As String = ""
        Dim l35 As String = ""
        Dim l36 As String = ""
        Dim l37 As String = ""
        Dim l38 As String = ""
        Dim l39 As String = ""
        Dim l40 As String = ""
        Dim l41 As String = ""
        Dim l42 As String = ""

        Do While param_file2.Peek <> -1

            Counter = Counter + 1
            System.Windows.Forms.Application.DoEvents()
            Line = param_file2.ReadLine()
            Ar = Line.Split("|||")

            Accountcode = Ar(27)
            Amount = Ar(51)
            Description = Ar(60)
            analysis = Ar(72)
            MyDate = Ar(9)
            comment = (Ar(36))
            analysis3 = Ar(75)
            Dim Arr() As String
            Arr = MyDate.Split("-")

            l1 = "L"
            l2 = Company.GLAnal5
            l3 = Accountcode
            l4 = ""
            l5 = h6
            l6 = "Payroll " & Period.DescriptionL
            l7 = "EUR"
            l8 = "1"
            l9 = Math.Abs(Amount)
            l10 = Math.Abs(Amount)
            If Amount > 0 Then
                l11 = "D"
            Else
                l11 = "C"
            End If
            l12 = ""
            l13 = ""
            l14 = ""
            l15 = "Payroll " & Period.DescriptionL
            l16 = ""
            l17 = h6
            l18 = ""
            l19 = Ar(72) ' analysis1
            l20 = Ar(73) ' analysis2
            l21 = Ar(74) ' analysis3
            l22 = Ar(75) ' analysis4
            l23 = Ar(76) ' analysis5
            l24 = Ar(74) ' analysis6
            l25 = Ar(75) ' analysis7
            l26 = Ar(76) ' analysis8
            l27 = Ar(76) ' analysis9
            l28 = "" ' text1
            l29 = "" ' text2
            l30 = "" ' text3
            l31 = "" ' text4
            l32 = "" ' text5
            l33 = "" ' Date1
            l34 = "" ' Date2
            l35 = "" ' Date3
            l36 = "" ' Int1
            l37 = "" ' Int2
            l38 = "" ' Int3
            l39 = "" ' Money1
            l40 = "" ' Money2
            l41 = "" ' Money3
            l42 = "" ' Cheque
            L = ""
            L = L + l1 & Del1
            L = L + l2 & Del1
            L = L + l3 & Del1
            L = L + l4 & Del1
            L = L + l5 & Del1
            L = L + l6 & Del1
            L = L + l7 & Del1
            L = L + l8 & Del1
            L = L + l9 & Del1
            L = L + l10 & Del1
            L = L + l11 & Del1
            L = L + l12 & Del1
            L = L + l13 & Del1
            L = L + l14 & Del1
            L = L + l15 & Del1
            L = L + l16 & Del1
            L = L + l17 & Del1
            L = L + l18 & Del1
            L = L + l19 & Del1
            L = L + l20 & Del1
            L = L + l21 & Del1
            L = L + l22 & Del1
            L = L + l23 & Del1
            L = L + l24 & Del1
            L = L + l25 & Del1
            L = L + l26 & Del1
            L = L + l27 & Del1
            L = L + l28 & Del1
            L = L + l29 & Del1
            L = L + l30 & Del1
            L = L + l31 & Del1
            L = L + l32 & Del1
            L = L + l33 & Del1
            L = L + l34 & Del1
            L = L + l35 & Del1
            L = L + l36 & Del1
            L = L + l37 & Del1
            L = L + l38 & Del1
            L = L + l39 & Del1
            L = L + l40 & Del1
            L = L + l41 & Del1
            L = L + l42


            WriteTo_ESOFT_File(L, Filename)

        Loop


    End Sub
    Private Function WriteTo_ESOFT_File(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = NAVOUTFileDir & fName
            Dim TW As System.IO.TextWriter

            If InitFileSAP Then
                TW = System.IO.File.CreateText(FileName)
                InitFileSAP = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
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



    Private Sub btnTemplateSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplateSearch.Click
        Dim F As New FrmTemplateSearch
        F.Owner = Me
        F.DsTemp = dsTemplateGroups
        F.CalledBy = 1
        F.ShowDialog()


    End Sub


End Class