Public Class FrmPayrollTotalsX
    Dim SelDs As DataSet
    Dim YTDReport As Boolean = False
    Dim UseMyDsX As Boolean = False

    'Dim Color_NormalFields As Color = Color.LemonChiffon
    'Dim Color_Earnings As Color = Color.MistyRose
    'Dim Color_Deductions As Color = Color.PaleGoldenrod
    'Dim Color_Contributions As Color = Color.PaleGreen


    Dim Color_NormalFields As Color = Color.White
    Dim Color_Earnings As Color = Color.LightBlue
    Dim Color_Deductions As Color = Color.White
    Dim Color_Contributions As Color = Color.LightBlue



    Dim Loading As Boolean = False
    Dim PerGroup As cPrMsPeriodGroups
    Dim TemGrp As cPrMsTemplateGroup
    Dim DsP_Ern As DataSet
    Dim DsP_Ded As DataSet
    Dim DsP_Con As DataSet

    Dim MyDsX As DataSet
    Public MyDs As DataSet
    Dim Dt1 As DataTable

    Dim MyDsPayslip As DataSet
    Dim DtPayslip As DataTable

    Public MyDs2 As DataSet
    Dim Dt2 As DataTable

    Public MyDsSimple As DataSet
    Dim DtSimple As DataTable



    Dim Dt3 As DataTable

    Dim MyDs5 As DataSet
    Dim dt5 As DataTable

    Dim MyDs6 As DataSet
    Dim dt6 As DataTable

    Dim ShowTimeOff As Boolean = False


    Dim Dt4 As DataTable
    Dim MyDs4 As DataSet

    Dim Dt44 As DataTable
    Dim MyDs44 As DataSet

    Dim MyDsDif As DataSet
    Dim DtDif As DataTable

    Dim MyDsDif2 As DataSet
    Dim DtDif2 As DataTable

    Dim MyDsDif2_Totals As DataSet
    Dim DtDif2_Totals As DataTable

    Dim MyDsSplit As DataSet
    Dim DtSplit As DataTable

    Dim MyDsPensionFund As DataSet
    Dim DtPensionFund As DataTable


    Dim GLBAnalysisDescriptionOnTheReport As String
    Dim GLBBankDescriptionOnTheReport As String

    Dim Column_EmpCode As Integer = 0
    Dim Column_EmpName As Integer = 1
    Dim Column_ActualUnits As Integer = 2


    ''''''''''' Earnings ''''''''''''
    Dim Column_E1 As Integer = 3
    Dim Column_EV1 As Integer = 4
    Dim Column_E2 As Integer = 5
    Dim Column_EV2 As Integer = 6
    Dim Column_E3 As Integer = 7
    Dim Column_EV3 As Integer = 8
    Dim Column_E4 As Integer = 9
    Dim Column_EV4 As Integer = 10
    Dim Column_E5 As Integer = 11
    Dim Column_EV5 As Integer = 12
    Dim Column_E6 As Integer = 13
    Dim Column_EV6 As Integer = 14
    Dim Column_E7 As Integer = 15
    Dim Column_EV7 As Integer = 16
    Dim Column_E8 As Integer = 17
    Dim Column_EV8 As Integer = 18
    Dim Column_E9 As Integer = 19
    Dim Column_EV9 As Integer = 20
    Dim Column_E10 As Integer = 21
    Dim Column_EV10 As Integer = 22
    Dim Column_E11 As Integer = 23
    Dim Column_EV11 As Integer = 24
    Dim Column_E12 As Integer = 25
    Dim Column_EV12 As Integer = 26
    Dim Column_E13 As Integer = 27
    Dim Column_EV13 As Integer = 28
    Dim Column_E14 As Integer = 29
    Dim Column_EV14 As Integer = 30
    Dim Column_E15 As Integer = 31
    Dim Column_EV15 As Integer = 32
    Dim Column_EVTotal As Integer = 33
    ''''''''''' Deductions '''''''''
    Dim Column_D1 As Integer = 34
    Dim Column_DV1 As Integer = 35
    Dim Column_D2 As Integer = 36
    Dim Column_DV2 As Integer = 37
    Dim Column_D3 As Integer = 38
    Dim Column_DV3 As Integer = 39
    Dim Column_D4 As Integer = 40
    Dim Column_DV4 As Integer = 41
    Dim Column_D5 As Integer = 42
    Dim Column_DV5 As Integer = 43
    Dim Column_D6 As Integer = 44
    Dim Column_DV6 As Integer = 45
    Dim Column_D7 As Integer = 46
    Dim Column_DV7 As Integer = 47
    Dim Column_D8 As Integer = 48
    Dim Column_DV8 As Integer = 49
    Dim Column_D9 As Integer = 50
    Dim Column_DV9 As Integer = 51
    Dim Column_D10 As Integer = 52
    Dim Column_DV10 As Integer = 53
    Dim Column_D11 As Integer = 54
    Dim Column_DV11 As Integer = 55
    Dim Column_D12 As Integer = 56
    Dim Column_DV12 As Integer = 57
    Dim Column_D13 As Integer = 58
    Dim Column_DV13 As Integer = 59
    Dim Column_D14 As Integer = 60
    Dim Column_DV14 As Integer = 61
    Dim Column_D15 As Integer = 62
    Dim Column_DV15 As Integer = 63
    Dim Column_DVTotal As Integer = 64
    '''''''' Contributions '''''''''
    Dim Column_C1 As Integer = 65
    Dim Column_CV1 As Integer = 66
    Dim Column_C2 As Integer = 67
    Dim Column_CV2 As Integer = 68
    Dim Column_C3 As Integer = 69
    Dim Column_CV3 As Integer = 70
    Dim Column_C4 As Integer = 71
    Dim Column_CV4 As Integer = 72
    Dim Column_C5 As Integer = 73
    Dim Column_CV5 As Integer = 74
    Dim Column_C6 As Integer = 75
    Dim Column_CV6 As Integer = 76
    Dim Column_C7 As Integer = 77
    Dim Column_CV7 As Integer = 78
    Dim Column_C8 As Integer = 79
    Dim Column_CV8 As Integer = 80
    Dim Column_C9 As Integer = 81
    Dim Column_CV9 As Integer = 82
    Dim Column_C10 As Integer = 83
    Dim Column_CV10 As Integer = 84
    Dim Column_C11 As Integer = 85
    Dim Column_CV11 As Integer = 86
    Dim Column_C12 As Integer = 87
    Dim Column_CV12 As Integer = 88
    Dim Column_C13 As Integer = 89
    Dim Column_CV13 As Integer = 90
    Dim Column_C14 As Integer = 91
    Dim Column_CV14 As Integer = 92
    Dim Column_C15 As Integer = 93
    Dim Column_CV15 As Integer = 94
    Dim Column_CVTotal As Integer = 95
    Dim Column_NetSalary As Integer = 96
    Dim Column_CompanyCost As Integer = 97

    Dim Column_PeriodCode As Integer = 98
    Dim Column_SITotal As Integer = 99
    Dim Column_ChequeNo As Integer = 100
    Dim Column_Overtime1 As Integer = 101
    Dim Column_OverTime2 As Integer = 102
    Dim Column_OverTime3 As Integer = 103

    Dim Column_Salary1 As Integer = 104
    Dim Column_Salary2 As Integer = 105

    Dim Column_sectors As Integer = 106
    Dim Column_dutyhours As Integer = 107
    Dim Column_flighthours As Integer = 108
    Dim Column_commission As Integer = 109
    Dim Column_OverLay As Integer = 110

    Dim Column_AnalysisCode As Integer = 111

    Dim Column_Position As Integer = 112
    Dim Column_DOE As Integer = 113
    Dim Column_TimeOff As Integer = 114

    Dim Column_GenAnal1 As Integer = 115
    Dim Column_EmpCounter As Integer = 116
    Dim Column_Analysis2 As Integer = 117

    Dim Column_AL_Code1 As Integer = 118
    Dim Column_AL_Code2 As Integer = 119
    Dim Column_AL_Code3 As Integer = 120
    Dim Column_AL_Code4 As Integer = 121
    Dim Column_AL_Code5 As Integer = 122
    Dim Column_AL_Desc1 As Integer = 123
    Dim Column_AL_Desc2 As Integer = 124
    Dim Column_AL_Desc3 As Integer = 125
    Dim Column_AL_Desc4 As Integer = 126
    Dim Column_AL_Desc5 As Integer = 127

    Dim Column_Termdate As Integer = 128
    Dim Column_SINumber As Integer = 129

    Dim Column_BankBenName As Integer = 130
    Dim Column_ComBank As Integer = 131
    Dim Column_DOB As Integer = 132
    Dim Column_Identity As Integer = 133
    Dim Column_TIC As Integer = 134
    Dim Column_Address As Integer = 135
    Dim Column_HRCode As Integer = 136
    Dim Column_Maternity As Integer = 137
    Dim Column_FEPercentage As Integer = 138
    Dim Column_FEControlAmount As Integer = 139
    Dim Column_EmpTermReason As Integer = 140
    


    ' EXCEL COLUMNS
    Dim C_EmpCode As Integer = 0
    Dim C_EmpName As Integer = 1
    Dim C_ActualUnits As Integer = 2

    ''''''''''' Earnings ''''''''''''

    Dim C_EV1 As Integer = 3
    Dim C_EV2 As Integer = 4
    Dim C_EV3 As Integer = 5
    Dim C_EV4 As Integer = 6
    Dim C_EV5 As Integer = 7
    Dim C_EV6 As Integer = 8
    Dim C_EV7 As Integer = 9
    Dim C_EV8 As Integer = 10
    Dim C_EV9 As Integer = 11
    Dim C_EV10 As Integer = 12
    Dim C_EV11 As Integer = 13
    Dim C_EV12 As Integer = 14
    Dim C_EV13 As Integer = 15
    Dim C_EV14 As Integer = 16
    Dim C_EV15 As Integer = 17
    Dim C_EVTotal As Integer = 18
    ''''''''''' Deductions '''''''''

    Dim C_DV1 As Integer = 19
    Dim C_DV2 As Integer = 20
    Dim C_DV3 As Integer = 21
    Dim C_DV4 As Integer = 22
    Dim C_DV5 As Integer = 23
    Dim C_DV6 As Integer = 24
    Dim C_DV7 As Integer = 25
    Dim C_DV8 As Integer = 26
    Dim C_DV9 As Integer = 27
    Dim C_DV10 As Integer = 28
    Dim C_DV11 As Integer = 29
    Dim C_DV12 As Integer = 30
    Dim C_DV13 As Integer = 31
    Dim C_DV14 As Integer = 32
    Dim C_DV15 As Integer = 33
    Dim C_DVTotal As Integer = 34

    '''''''' Contributions '''''''''

    Dim C_CV1 As Integer = 35
    Dim C_CV2 As Integer = 36
    Dim C_CV3 As Integer = 37
    Dim C_CV4 As Integer = 38
    Dim C_CV5 As Integer = 39
    Dim C_CV6 As Integer = 40
    Dim C_CV7 As Integer = 41
    Dim C_CV8 As Integer = 42
    Dim C_CV9 As Integer = 43
    Dim C_CV10 As Integer = 44
    Dim C_CV11 As Integer = 45
    Dim C_CV12 As Integer = 46
    Dim C_CV13 As Integer = 47
    Dim C_CV14 As Integer = 48
    Dim C_CV15 As Integer = 49
    Dim C_CVTotal As Integer = 50

    Dim C_NetSalary As Integer = 51
    Dim C_CompanyCost As Integer = 52
    Dim C_SITotal As Integer = 53
    Dim C_ref As Integer = 54
    Dim C_Overtime1 As Integer = 55
    Dim C_OverTime2 As Integer = 56
    Dim C_OverTime3 As Integer = 57
    Dim C_Salary1 As Integer = 58
    Dim C_Salary2 As Integer = 59

    Dim C_Sectors As Integer = 60
    Dim C_DutyHours As Integer = 61
    Dim C_FlightHours As Integer = 62
    Dim C_Commission As Integer = 63
    Dim C_Overlay As Integer = 64

    Dim C_AnalysisCode As Integer = 65

    Dim C_Position As Integer = 66
    Dim C_DOE As Integer = 67
    Dim C_TimeOff As Integer = 68

    Dim C_GenAnal1 As Integer = 69
    Dim C_EmpCounter As Integer = 70
    Dim C_Analysis2 As Integer = 71

    Dim C_AL_Code1 As Integer = 72
    Dim C_AL_Code2 As Integer = 73
    Dim C_AL_Code3 As Integer = 74
    Dim C_AL_Code4 As Integer = 75
    Dim C_AL_Code5 As Integer = 76

    Dim C_AL_Desc1 As Integer = 77
    Dim C_AL_Desc2 As Integer = 78
    Dim C_AL_Desc3 As Integer = 79
    Dim C_AL_Desc4 As Integer = 80
    Dim C_AL_Desc5 As Integer = 81


    Dim C_Termdate As Integer = 82
    Dim C_SINumber As Integer = 83
    Dim C_BankBenName As Integer = 84
    Dim C_ComBank As Integer = 85
    Dim C_DOB As Integer = 86
    Dim C_Identity As Integer = 87
    Dim C_TIC As Integer = 88
    Dim C_Address As Integer = 89
    Dim C_HRCode As Integer = 90
    Dim C_Maternity As Integer = 91
    Dim C_FEPercentage As Integer = 92
    Dim C_FEControlAmount As Integer = 93
    Dim C_EmpTermReason As Integer = 94



    Dim ShowAnalysisDescription As Boolean = True
    Dim ShowAddress As Boolean = True
    Dim ShowHRCode As Boolean = True

    Dim InitExcelFile As Boolean = True

    Public Excel2Reportname As String
    Public R2_BIK As String
    Public R2_OtherDed As String
    Public R2_Advances As String
    Public R2_ReimbOfExp As String
    Public R2_IncomeTax As String
    Public R2_D_SI As String
    Public R2_D_NHS As String
    Public R2_C_SI As String
    Public R2_C_Industrial As String
    Public R2_C_Unemployement As String
    Public R2_C_SocialCohesion As String
    Public R2_C_NHS As String
    Public R2_D_BikNHS As String

    Dim InitFile As Boolean = True
    Dim PFExportFileDir As String

    Dim DsPeriodGroups As DataSet

    Private Sub FrmPayrollTotals_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0

        Me.Width = CType(Me.MdiParent, FrmMain).Width - 30
        Me.Height = CType(Me.MdiParent, FrmMain).Height - 150

        LoadComboSelectAnal()
        LoadCombos()
        InitDataTable()
        InitDatatable_Payslip()

        InitDataTable_2()
        InitDataTable_3()
        InitDatatable_4()
        InitDatatable_44()

        InitDataTable_5()
        InitDataTable_6()



        InitDatatable_Dif()
        InitDatatable_Dif2()
        InitDatatable_Dif2_Totals()

        InitDataTable_split()

        InitDataTable_Simple()
        InitDataTable_PensionFund()




        InitDataGrid()




        ClearGrid()
        FixNormalColumnsColor()
        Me.CBBank.Checked = True
        Me.CBWallet.Checked = True
        Me.CBCash.Checked = True
        Me.CBCheque.Checked = True

        Dim Ds As DataSet

        Ds = Global1.Business.GetParameter("System", "TOonReport")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                ShowTimeOff = True
            End If
        End If
        Ds = Global1.Business.GetParameter("System", "FactorOnUnits")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_RPUnitAmount = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Union", "MedicalDed")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_UnionMedicalDedCode = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Union", "MedicalCon")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_UnionMedicalConCode = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Union", "FishesErn")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_UnionFishes = Par.Value1
        End If

        Ds = Global1.Business.GetParameter("Union", "WelFareDed")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_WelfareDedCode = Par.Value1
        End If




        Ds = Global1.Business.GetParameter("Report", "InTotal1")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_IncludeInTotal1 = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Report", "InTotal2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_IncludeInTotal2 = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Report", "InTotal3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_IncludeInTotal3 = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Report", "InTotal4")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_IncludeInTotal4 = Par.Value1
        End If
        Ds = Global1.Business.GetParameter("Report", "InTotal5")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.Param_IncludeInTotal5 = Par.Value1
        End If

        PARAM_ShowAnalysis3onPayslip = False
        Ds = Global1.Business.GetParameter("Payslip", "Analysis3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_ShowAnalysis3onPayslip = True
            End If
        End If



        Ds = Global1.Business.GetParameter("IR7", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))

            PFExportFileDir = Par.Value1

        End If


        PARAM_Variance25ShowAnl3 = False
        Ds = Global1.Business.GetParameter("System", "Var25useAnl3")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                PARAM_Variance25ShowAnl3 = True
            End If
        End If

        'Report6ToolStripMenuItem.Visible = False

        'If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
        '    Report6ToolStripMenuItem.Visible = True
        'End If


    End Sub
    Private Sub InitDataGrid()
        MyDs = New DataSet
        MyDs.Tables.Add(Dt1)
        DG1.DataSource = MyDs.Tables(0)


      

        MyDsPayslip = New DataSet
        MyDsPayslip.Tables.Add(DtPayslip)



        MyDs2 = New DataSet
        MyDs2.Tables.Add(Dt2)


        MyDs4 = New DataSet
        MyDs4.Tables.Add(Dt4)

        MyDs44 = New DataSet
        MyDs44.Tables.Add(Dt44)

        MyDsDif = New DataSet
        MyDsDif.Tables.Add(DtDif)

        MyDsDif2 = New DataSet
        MyDsDif2.Tables.Add(DtDif2)

        MyDsDif2_Totals = New DataSet
        MyDsDif2_Totals.Tables.Add(DtDif2_Totals)




        MyDsSplit = New DataSet
        MyDsSplit.Tables.Add(DtSplit)

        MyDs5 = New DataSet
        MyDs5.Tables.Add(dt5)

        MyDs6 = New DataSet
        MyDs6.Tables.Add(dt6)


        DG1.Columns(0).Frozen = True
        DG1.Columns(1).Frozen = True
        DG1.Columns(2).Frozen = True

        MyDsSimple = New DataSet
        MyDsSimple.Tables.Add(DtSimple)

        MyDsPensionFund = New DataSet
        MyDsPensionFund.Tables.Add(DtPensionFund)

    End Sub
    Private Sub InitDataTable()
        Dt1 = New DataTable("Table1")
        '2
        Dt1.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '3
        Dt1.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '4
        Dt1.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))

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
        '
        Dt1.Columns.Add("EVTotal", System.Type.GetType("System.Double"))
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
        '
        Dt1.Columns.Add("DVTotal", System.Type.GetType("System.Double"))
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
        '98
        Dt1.Columns.Add("CVTotal", System.Type.GetType("System.Double"))
        '99
        Dt1.Columns.Add("NetSalary", System.Type.GetType("System.Double"))
        '100
        Dt1.Columns.Add("CompanyCost", System.Type.GetType("System.Double"))
        '101
        Dt1.Columns.Add("PeriodCode", System.Type.GetType("System.String"))
        '102
        Dt1.Columns.Add("SITotal", System.Type.GetType("System.Double"))
        '103
        Dt1.Columns.Add("Reference", System.Type.GetType("System.String"))
        '104
        Dt1.Columns.Add("OverTime1", System.Type.GetType("System.String"))
        '105
        Dt1.Columns.Add("OverTime2", System.Type.GetType("System.String"))
        '106
        Dt1.Columns.Add("OverTime3", System.Type.GetType("System.String"))
        '107
        Dt1.Columns.Add("Salary1", System.Type.GetType("System.String"))
        '108
        Dt1.Columns.Add("Salary2", System.Type.GetType("System.String"))
        '109
        Dt1.Columns.Add("Sectors", System.Type.GetType("System.String"))
        '110
        Dt1.Columns.Add("DutyHours", System.Type.GetType("System.String"))
        '111
        Dt1.Columns.Add("FlightHours", System.Type.GetType("System.String"))
        '112
        Dt1.Columns.Add("Commission", System.Type.GetType("System.String"))
        '113
        Dt1.Columns.Add("Overlay", System.Type.GetType("System.String"))
        '114
        Dt1.Columns.Add("AnalysisCode2", System.Type.GetType("System.String"))
        '115
        Dt1.Columns.Add("Position", System.Type.GetType("System.String"))
        '116
        Dt1.Columns.Add("DOE", System.Type.GetType("System.String"))
        '117
        Dt1.Columns.Add("TimeOff", System.Type.GetType("System.String"))
        '118
        Dt1.Columns.Add("GLAnal1", System.Type.GetType("System.String"))
        '119
        Dt1.Columns.Add("EmpCounter", System.Type.GetType("System.String"))
        '120
        Dt1.Columns.Add("Analysis2", System.Type.GetType("System.String"))
        '121
        Dt1.Columns.Add("AL_Code1", System.Type.GetType("System.String"))
        '122
        Dt1.Columns.Add("AL_Code2", System.Type.GetType("System.String"))
        '123
        Dt1.Columns.Add("AL_Code3", System.Type.GetType("System.String"))
        '124
        Dt1.Columns.Add("AL_Code4", System.Type.GetType("System.String"))
        '125
        Dt1.Columns.Add("AL_Code5", System.Type.GetType("System.String"))
        '126
        Dt1.Columns.Add("AL_Desc1", System.Type.GetType("System.String"))
        '127
        Dt1.Columns.Add("AL_Desc2", System.Type.GetType("System.String"))
        '128
        Dt1.Columns.Add("AL_Desc3", System.Type.GetType("System.String"))
        '129
        Dt1.Columns.Add("AL_Desc4", System.Type.GetType("System.String"))
        '130
        Dt1.Columns.Add("AL_Desc5", System.Type.GetType("System.String"))
        '131
        Dt1.Columns.Add("TerminationDate", System.Type.GetType("System.String"))
        '132
        Dt1.Columns.Add("SINumber", System.Type.GetType("System.String"))
        '133
        Dt1.Columns.Add("BenefName", System.Type.GetType("System.String"))
        '134
        Dt1.Columns.Add("CompanyBank", System.Type.GetType("System.String"))
        '135
        Dt1.Columns.Add("DOB", System.Type.GetType("System.String"))
        '136
        Dt1.Columns.Add("Identity", System.Type.GetType("System.String"))
        '137
        Dt1.Columns.Add("TIC", System.Type.GetType("System.String"))
        '138
        Dt1.Columns.Add("Address", System.Type.GetType("System.String"))
        '139
        Dt1.Columns.Add("HRCode", System.Type.GetType("System.String"))
        '140
        Dt1.Columns.Add("Maternity", System.Type.GetType("System.String"))
        '141
        Dt1.Columns.Add("FEPercentage", System.Type.GetType("System.String"))
        '142
        Dt1.Columns.Add("FEControlAmount", System.Type.GetType("System.String"))
        '143
        Dt1.Columns.Add("EmpTermReason", System.Type.GetType("System.String"))





    End Sub

    Private Sub InitDataTable_5()
        dt5 = New DataTable("Table1")
        '0
        dt5.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        dt5.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        dt5.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))
        '3
        dt5.Columns.Add("EDC", System.Type.GetType("System.String"))
        '4
        dt5.Columns.Add("EDCVal", System.Type.GetType("System.Double"))
        '5
        dt5.Columns.Add("Ern2", System.Type.GetType("System.String"))
        '6
        dt5.Columns.Add("AnalysisCode2", System.Type.GetType("System.String"))
        '7
        dt5.Columns.Add("Position", System.Type.GetType("System.String"))

 


    End Sub
    Private Sub InitDataTable_6()
        dt6 = New DataTable("Table1")
        '0
        dt6.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        dt6.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        dt6.Columns.Add("Value1", System.Type.GetType("System.Double"))
        '3
        dt6.Columns.Add("Value2", System.Type.GetType("System.Double"))
        '4
        dt6.Columns.Add("Value3", System.Type.GetType("System.Double"))
        '5
        dt6.Columns.Add("Time1", System.Type.GetType("System.Double"))
        '6
        dt6.Columns.Add("Time2", System.Type.GetType("System.Double"))
        '7
        dt6.Columns.Add("Time3", System.Type.GetType("System.Double"))


    End Sub
    Private Sub InitDatatable_Payslip()
        DtPayslip = New DataTable("Table1")
        '2
        DtPayslip.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '3
        DtPayslip.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '4
        DtPayslip.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))

        '''''''''''''''''''''''Earnings''''''''''''''''''''''
        '8
        DtPayslip.Columns.Add("Ern1", System.Type.GetType("System.String"))
        '9
        DtPayslip.Columns.Add("EVal1", System.Type.GetType("System.Double"))
        '10
        DtPayslip.Columns.Add("Ern2", System.Type.GetType("System.String"))
        '11
        DtPayslip.Columns.Add("EVal2", System.Type.GetType("System.Double"))
        '12
        DtPayslip.Columns.Add("Ern3", System.Type.GetType("System.String"))
        '13
        DtPayslip.Columns.Add("EVal3", System.Type.GetType("System.Double"))
        '14
        DtPayslip.Columns.Add("Ern4", System.Type.GetType("System.String"))
        '15
        DtPayslip.Columns.Add("EVal4", System.Type.GetType("System.Double"))
        '16
        DtPayslip.Columns.Add("Ern5", System.Type.GetType("System.String"))
        '17
        DtPayslip.Columns.Add("EVal5", System.Type.GetType("System.Double"))
        '18
        DtPayslip.Columns.Add("Ern6", System.Type.GetType("System.String"))
        '19
        DtPayslip.Columns.Add("EVal6", System.Type.GetType("System.Double"))
        '20
        DtPayslip.Columns.Add("Ern7", System.Type.GetType("System.String"))
        '21
        DtPayslip.Columns.Add("EVal7", System.Type.GetType("System.Double"))
        '22
        DtPayslip.Columns.Add("Ern8", System.Type.GetType("System.String"))
        '23
        DtPayslip.Columns.Add("EVal8", System.Type.GetType("System.Double"))
        '24
        DtPayslip.Columns.Add("Ern9", System.Type.GetType("System.String"))
        '25
        DtPayslip.Columns.Add("EVal9", System.Type.GetType("System.Double"))
        '26
        DtPayslip.Columns.Add("Ern10", System.Type.GetType("System.String"))
        '27
        DtPayslip.Columns.Add("EVal10", System.Type.GetType("System.Double"))
        '28
        DtPayslip.Columns.Add("Ern11", System.Type.GetType("System.String"))
        '29
        DtPayslip.Columns.Add("EVal11", System.Type.GetType("System.Double"))
        '30
        DtPayslip.Columns.Add("Ern12", System.Type.GetType("System.String"))
        '31
        DtPayslip.Columns.Add("EVal12", System.Type.GetType("System.Double"))
        '32
        DtPayslip.Columns.Add("Ern13", System.Type.GetType("System.String"))
        '33
        DtPayslip.Columns.Add("EVal13", System.Type.GetType("System.Double"))
        '34
        DtPayslip.Columns.Add("Ern14", System.Type.GetType("System.String"))
        '35
        DtPayslip.Columns.Add("EVal14", System.Type.GetType("System.Double"))
        '36
        DtPayslip.Columns.Add("Ern15", System.Type.GetType("System.String"))
        '37
        DtPayslip.Columns.Add("EVal15", System.Type.GetType("System.Double"))
        '
        DtPayslip.Columns.Add("EVTotal", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Deductions''''''''''''''''''''''
        '38
        DtPayslip.Columns.Add("Ded1", System.Type.GetType("System.String"))
        '39
        DtPayslip.Columns.Add("DVal1", System.Type.GetType("System.Double"))
        '40
        DtPayslip.Columns.Add("Ded2", System.Type.GetType("System.String"))
        '41
        DtPayslip.Columns.Add("DVal2", System.Type.GetType("System.Double"))
        '42
        DtPayslip.Columns.Add("Ded3", System.Type.GetType("System.String"))
        '43
        DtPayslip.Columns.Add("DVal3", System.Type.GetType("System.Double"))
        '44
        DtPayslip.Columns.Add("Ded4", System.Type.GetType("System.String"))
        '45
        DtPayslip.Columns.Add("DVal4", System.Type.GetType("System.Double"))
        '46
        DtPayslip.Columns.Add("Ded5", System.Type.GetType("System.String"))
        '47
        DtPayslip.Columns.Add("DVal5", System.Type.GetType("System.Double"))
        '48
        DtPayslip.Columns.Add("Ded6", System.Type.GetType("System.String"))
        '49
        DtPayslip.Columns.Add("DVal6", System.Type.GetType("System.Double"))
        '50
        DtPayslip.Columns.Add("Ded7", System.Type.GetType("System.String"))
        '51
        DtPayslip.Columns.Add("DVal7", System.Type.GetType("System.Double"))
        '52
        DtPayslip.Columns.Add("Ded8", System.Type.GetType("System.String"))
        '53
        DtPayslip.Columns.Add("DVal8", System.Type.GetType("System.Double"))
        '54
        DtPayslip.Columns.Add("Ded9", System.Type.GetType("System.String"))
        '55
        DtPayslip.Columns.Add("DVal9", System.Type.GetType("System.Double"))
        '56
        DtPayslip.Columns.Add("Ded10", System.Type.GetType("System.String"))
        '57
        DtPayslip.Columns.Add("DVal10", System.Type.GetType("System.Double"))
        '58
        DtPayslip.Columns.Add("Ded11", System.Type.GetType("System.String"))
        '59
        DtPayslip.Columns.Add("DVal11", System.Type.GetType("System.Double"))
        '60
        DtPayslip.Columns.Add("Ded12", System.Type.GetType("System.String"))
        '61
        DtPayslip.Columns.Add("DVal12", System.Type.GetType("System.Double"))
        '62
        DtPayslip.Columns.Add("Ded13", System.Type.GetType("System.String"))
        '63
        DtPayslip.Columns.Add("DVal13", System.Type.GetType("System.Double"))
        '64
        DtPayslip.Columns.Add("Ded14", System.Type.GetType("System.String"))
        '65
        DtPayslip.Columns.Add("DVal14", System.Type.GetType("System.Double"))
        '66
        DtPayslip.Columns.Add("Ded15", System.Type.GetType("System.String"))
        '67
        DtPayslip.Columns.Add("DVal15", System.Type.GetType("System.Double"))
        '
        DtPayslip.Columns.Add("DVTotal", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Contributions''''''''''''''''''''''
        '68
        DtPayslip.Columns.Add("Con1", System.Type.GetType("System.String"))
        '69
        DtPayslip.Columns.Add("CVal1", System.Type.GetType("System.Double"))
        '70
        DtPayslip.Columns.Add("Con2", System.Type.GetType("System.String"))
        '71
        DtPayslip.Columns.Add("CVal2", System.Type.GetType("System.Double"))
        '72
        DtPayslip.Columns.Add("Con3", System.Type.GetType("System.String"))
        '73
        DtPayslip.Columns.Add("CVal3", System.Type.GetType("System.Double"))
        '74
        DtPayslip.Columns.Add("Con4", System.Type.GetType("System.String"))
        '75
        DtPayslip.Columns.Add("CVal4", System.Type.GetType("System.Double"))
        '76
        DtPayslip.Columns.Add("Con5", System.Type.GetType("System.String"))
        '77
        DtPayslip.Columns.Add("CVal5", System.Type.GetType("System.Double"))
        '78
        DtPayslip.Columns.Add("Con6", System.Type.GetType("System.String"))
        '79
        DtPayslip.Columns.Add("CVal6", System.Type.GetType("System.Double"))
        '80
        DtPayslip.Columns.Add("Con7", System.Type.GetType("System.String"))
        '81
        DtPayslip.Columns.Add("CVal7", System.Type.GetType("System.Double"))
        '82
        DtPayslip.Columns.Add("Con8", System.Type.GetType("System.String"))
        '83
        DtPayslip.Columns.Add("CVal8", System.Type.GetType("System.Double"))
        '84
        DtPayslip.Columns.Add("Con9", System.Type.GetType("System.String"))
        '85
        DtPayslip.Columns.Add("CVal9", System.Type.GetType("System.Double"))
        '86
        DtPayslip.Columns.Add("Con10", System.Type.GetType("System.String"))
        '87
        DtPayslip.Columns.Add("CVal10", System.Type.GetType("System.Double"))
        '88
        DtPayslip.Columns.Add("Con11", System.Type.GetType("System.String"))
        '89
        DtPayslip.Columns.Add("CVal11", System.Type.GetType("System.Double"))
        '90
        DtPayslip.Columns.Add("Con12", System.Type.GetType("System.String"))
        '91
        DtPayslip.Columns.Add("CVal12", System.Type.GetType("System.Double"))
        '92
        DtPayslip.Columns.Add("Con13", System.Type.GetType("System.String"))
        '93
        DtPayslip.Columns.Add("CVal13", System.Type.GetType("System.Double"))
        '94
        DtPayslip.Columns.Add("Con14", System.Type.GetType("System.String"))
        '95
        DtPayslip.Columns.Add("CVal14", System.Type.GetType("System.Double"))
        '96
        DtPayslip.Columns.Add("Con15", System.Type.GetType("System.String"))
        '97
        DtPayslip.Columns.Add("CVal15", System.Type.GetType("System.Double"))
        '98
        DtPayslip.Columns.Add("CVTotal", System.Type.GetType("System.Double"))
        '99
        DtPayslip.Columns.Add("NetSalary", System.Type.GetType("System.Double"))
        '100
        DtPayslip.Columns.Add("CompanyCost", System.Type.GetType("System.Double"))
        '101
        DtPayslip.Columns.Add("PeriodCode", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("SITotal", System.Type.GetType("System.Double"))

        DtPayslip.Columns.Add("Reference", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("OverTime1", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("OverTime2", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("OverTime3", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Salary1", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Salary2", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Sectors", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("DutyHours", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("FlightHours", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Commission", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Overlay", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AnalysisCode2", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Position", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("DOE", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("TimeOff", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("GLAnal1", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("EmpCounter", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("Analysis2", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Code1", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Code2", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Code3", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Code4", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Code5", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Desc1", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Desc2", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Desc3", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Desc4", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("AL_Desc5", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("TerminationDate", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("SINumber", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("BenefName", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("CompanyBank", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("DOB", System.Type.GetType("System.String"))

        '136
        DtPayslip.Columns.Add("Identity", System.Type.GetType("System.String"))
        '137
        DtPayslip.Columns.Add("TIC", System.Type.GetType("System.String"))
        '138
        DtPayslip.Columns.Add("Address", System.Type.GetType("System.String"))
        '139
        DtPayslip.Columns.Add("HRCode", System.Type.GetType("System.String"))
        '140
        DtPayslip.Columns.Add("Maternity", System.Type.GetType("System.String"))
        '141
        DtPayslip.Columns.Add("FEPercentage", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("FEControlAmount", System.Type.GetType("System.String"))

        DtPayslip.Columns.Add("EmpTermReason", System.Type.GetType("System.String"))





    End Sub
    Private Sub InitDataTable_PensionFund()
        DtPensionFund = New DataTable("Table1")
        '0
        DtPensionFund.Columns.Add("TrxHdr_Id", System.Type.GetType("System.Int32"))

        DtPensionFund.Columns.Add("Emp_Code", System.Type.GetType("System.String"))
        '1
        DtPensionFund.Columns.Add("Emp_FullName", System.Type.GetType("System.String"))
        '2
        DtPensionFund.Columns.Add("TrxHdr_NetSalary", System.Type.GetType("System.Double"))
        '3
        DtPensionFund.Columns.Add("TrxHdr_MonthlySalary", System.Type.GetType("System.Double"))
        '4
        DtPensionFund.Columns.Add("TrxHdr_PeriodUnits", System.Type.GetType("System.Double"))
        '5
        DtPensionFund.Columns.Add("Salary", System.Type.GetType("System.Double"))
        '6
        DtPensionFund.Columns.Add("COLA", System.Type.GetType("System.Double"))
        '7
        DtPensionFund.Columns.Add("Total", System.Type.GetType("System.Double"))

        DtPensionFund.Columns.Add("D18", System.Type.GetType("System.Double"))

        DtPensionFund.Columns.Add("Widow", System.Type.GetType("System.Double"))

        DtPensionFund.Columns.Add("C10", System.Type.GetType("System.Double"))

        DtPensionFund.Columns.Add("emp_identificationcard", System.Type.GetType("System.String"))

        DtPensionFund.Columns.Add("emp_CNP", System.Type.GetType("System.String"))


    End Sub
    Private Sub InitDataTable_2()
        Dt2 = New DataTable("Table2")
        '0
        Dt2.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        Dt2.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        Dt2.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))
        '''''''''''''''''''''''Earnings''''''''''''''''''''''
        '3
        Dt2.Columns.Add("EVal1", System.Type.GetType("System.Double"))
        '4
        Dt2.Columns.Add("EVal2", System.Type.GetType("System.Double"))
        '5
        Dt2.Columns.Add("EVal3", System.Type.GetType("System.Double"))
        '6
        Dt2.Columns.Add("EVal4", System.Type.GetType("System.Double"))
        '7
        Dt2.Columns.Add("EVal5", System.Type.GetType("System.Double"))
        '8
        Dt2.Columns.Add("EVal6", System.Type.GetType("System.Double"))
        '9
        Dt2.Columns.Add("EVal7", System.Type.GetType("System.Double"))
        '10
        Dt2.Columns.Add("EVal8", System.Type.GetType("System.Double"))
        '11
        Dt2.Columns.Add("EVal9", System.Type.GetType("System.Double"))
        '12
        Dt2.Columns.Add("EVal10", System.Type.GetType("System.Double"))
        '13
        Dt2.Columns.Add("EVal11", System.Type.GetType("System.Double"))
        '14
        Dt2.Columns.Add("EVal12", System.Type.GetType("System.Double"))
        '15
        Dt2.Columns.Add("EVal13", System.Type.GetType("System.Double"))
        '16
        Dt2.Columns.Add("EVal14", System.Type.GetType("System.Double"))
        '17
        Dt2.Columns.Add("EVal15", System.Type.GetType("System.Double"))
        '18
        Dt2.Columns.Add("EVTotal", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Deductions''''''''''''''''''''''
        '3
        Dt2.Columns.Add("DVal1", System.Type.GetType("System.Double"))
        '4
        Dt2.Columns.Add("DVal2", System.Type.GetType("System.Double"))
        '5
        Dt2.Columns.Add("DVal3", System.Type.GetType("System.Double"))
        '6
        Dt2.Columns.Add("DVal4", System.Type.GetType("System.Double"))
        '7
        Dt2.Columns.Add("DVal5", System.Type.GetType("System.Double"))
        '8
        Dt2.Columns.Add("DVal6", System.Type.GetType("System.Double"))
        '9
        Dt2.Columns.Add("DVal7", System.Type.GetType("System.Double"))
        '10
        Dt2.Columns.Add("DVal8", System.Type.GetType("System.Double"))
        '11
        Dt2.Columns.Add("DVal9", System.Type.GetType("System.Double"))
        '12
        Dt2.Columns.Add("DVal10", System.Type.GetType("System.Double"))
        '13
        Dt2.Columns.Add("DVal11", System.Type.GetType("System.Double"))
        '14
        Dt2.Columns.Add("DVal12", System.Type.GetType("System.Double"))
        '15
        Dt2.Columns.Add("DVal13", System.Type.GetType("System.Double"))
        '16
        Dt2.Columns.Add("DVal14", System.Type.GetType("System.Double"))
        '17
        Dt2.Columns.Add("DVal15", System.Type.GetType("System.Double"))
        '18
        Dt2.Columns.Add("DVTotal", System.Type.GetType("System.Double"))

        ''''''''''''''''''''''Contributions''''''''''''''''''''''
        '3
        Dt2.Columns.Add("CVal1", System.Type.GetType("System.Double"))
        '4
        Dt2.Columns.Add("CVal2", System.Type.GetType("System.Double"))
        '5
        Dt2.Columns.Add("CVal3", System.Type.GetType("System.Double"))
        '6
        Dt2.Columns.Add("CVal4", System.Type.GetType("System.Double"))
        '7
        Dt2.Columns.Add("CVal5", System.Type.GetType("System.Double"))
        '8
        Dt2.Columns.Add("CVal6", System.Type.GetType("System.Double"))
        '9
        Dt2.Columns.Add("CVal7", System.Type.GetType("System.Double"))
        '10
        Dt2.Columns.Add("CVal8", System.Type.GetType("System.Double"))
        '11
        Dt2.Columns.Add("CVal9", System.Type.GetType("System.Double"))
        '12
        Dt2.Columns.Add("CVal10", System.Type.GetType("System.Double"))
        '13
        Dt2.Columns.Add("CVal11", System.Type.GetType("System.Double"))
        '14
        Dt2.Columns.Add("CVal12", System.Type.GetType("System.Double"))
        '15
        Dt2.Columns.Add("CVal13", System.Type.GetType("System.Double"))
        '16
        Dt2.Columns.Add("CVal14", System.Type.GetType("System.Double"))
        '17
        Dt2.Columns.Add("CVal15", System.Type.GetType("System.Double"))
        '18
        Dt2.Columns.Add("CVTotal", System.Type.GetType("System.Double"))
        '
        Dt2.Columns.Add("NetSalary", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("CompanyCost", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("SITotal", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("Ref.No", System.Type.GetType("System.String"))

        Dt2.Columns.Add("OverTime1", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("OverTime2", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("OverTime3", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("Salary1", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("Salary2", System.Type.GetType("System.Double"))

        Dt2.Columns.Add("Sectors", System.Type.GetType("System.String"))

        Dt2.Columns.Add("DutyHours", System.Type.GetType("System.String"))

        Dt2.Columns.Add("FlightHours", System.Type.GetType("System.String"))

        Dt2.Columns.Add("Commission", System.Type.GetType("System.String"))

        Dt2.Columns.Add("Overlay", System.Type.GetType("System.String"))

        Dt2.Columns.Add("AnalysisCode2", System.Type.GetType("System.String"))

        Dt2.Columns.Add("Position", System.Type.GetType("System.String"))

        Dt2.Columns.Add("DOE", System.Type.GetType("System.String"))

        Dt2.Columns.Add("TimeOff", System.Type.GetType("System.String"))

        Dt2.Columns.Add("GLAnal1", System.Type.GetType("System.String"))

        Dt2.Columns.Add("EmpCounter", System.Type.GetType("System.String"))

        Dt2.Columns.Add("Analysis2", System.Type.GetType("System.String"))


        '''''
        '121
        Dt2.Columns.Add("AL_Code1", System.Type.GetType("System.String"))
        '122
        Dt2.Columns.Add("AL_Code2", System.Type.GetType("System.String"))
        '123
        Dt2.Columns.Add("AL_Code3", System.Type.GetType("System.String"))
        '124
        Dt2.Columns.Add("AL_Code4", System.Type.GetType("System.String"))
        '125
        Dt2.Columns.Add("AL_Code5", System.Type.GetType("System.String"))
        '126
        Dt2.Columns.Add("AL_Desc1", System.Type.GetType("System.String"))
        '127
        Dt2.Columns.Add("AL_Desc2", System.Type.GetType("System.String"))
        '128
        Dt2.Columns.Add("AL_Desc3", System.Type.GetType("System.String"))
        '129
        Dt2.Columns.Add("AL_Desc4", System.Type.GetType("System.String"))
        '130
        Dt2.Columns.Add("AL_Desc5", System.Type.GetType("System.String"))
        '131
        Dt2.Columns.Add("TerminationDate", System.Type.GetType("System.String"))
        '132
        Dt2.Columns.Add("SINumber", System.Type.GetType("System.String"))
        '133
        Dt2.Columns.Add("BenefName", System.Type.GetType("System.String"))
        '134
        Dt2.Columns.Add("CompanyBank", System.Type.GetType("System.String"))
        '134
        Dt2.Columns.Add("DOB", System.Type.GetType("System.String"))
        '136
        Dt2.Columns.Add("Identity", System.Type.GetType("System.String"))
        '137
        Dt2.Columns.Add("TIC", System.Type.GetType("System.String"))
        '138
        Dt2.Columns.Add("Address", System.Type.GetType("System.String"))
        '139
        Dt2.Columns.Add("HRCode", System.Type.GetType("System.String"))
        '140
        Dt2.Columns.Add("Maternity", System.Type.GetType("System.String"))
        '141
        Dt2.Columns.Add("FEPercentage", System.Type.GetType("System.String"))

        Dt2.Columns.Add("FEControlAmount", System.Type.GetType("System.String"))

        Dt2.Columns.Add("EmpTermReason", System.Type.GetType("System.String"))




    End Sub
    Private Sub InitDataTable_Simple()
        DtSimple = New DataTable("TableSimple")
        '0
        DtSimple.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '1
        DtSimple.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '2
        DtSimple.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))
        '''''''''''''''''''''''Earnings''''''''''''''''''''''
        '3
        DtSimple.Columns.Add("EVal1", System.Type.GetType("System.Double"))
        '4
        DtSimple.Columns.Add("EVal2", System.Type.GetType("System.Double"))
        '5
        DtSimple.Columns.Add("EVal3", System.Type.GetType("System.Double"))
        '6
        DtSimple.Columns.Add("EVal4", System.Type.GetType("System.Double"))
        '7
        DtSimple.Columns.Add("EVal5", System.Type.GetType("System.Double"))
        '8
        DtSimple.Columns.Add("EVal6", System.Type.GetType("System.Double"))
        '9
        DtSimple.Columns.Add("EVal7", System.Type.GetType("System.Double"))
        '10
        DtSimple.Columns.Add("EVal8", System.Type.GetType("System.Double"))
        '11
        DtSimple.Columns.Add("EVal9", System.Type.GetType("System.Double"))
        '12
        DtSimple.Columns.Add("EVal10", System.Type.GetType("System.Double"))
        '13
        DtSimple.Columns.Add("EVal11", System.Type.GetType("System.Double"))
        '14
        DtSimple.Columns.Add("EVal12", System.Type.GetType("System.Double"))
        '15
        DtSimple.Columns.Add("EVal13", System.Type.GetType("System.Double"))
        '16
        DtSimple.Columns.Add("EVal14", System.Type.GetType("System.Double"))
        '17
        DtSimple.Columns.Add("EVal15", System.Type.GetType("System.Double"))
        '18
        DtSimple.Columns.Add("EVTotal", System.Type.GetType("System.Double"))
        ''''''''''''''''''''''Deductions''''''''''''''''''''''
        '3
        DtSimple.Columns.Add("DVal1", System.Type.GetType("System.Double"))
        '4
        DtSimple.Columns.Add("DVal2", System.Type.GetType("System.Double"))
        '5
        DtSimple.Columns.Add("DVal3", System.Type.GetType("System.Double"))
        '6
        DtSimple.Columns.Add("DVal4", System.Type.GetType("System.Double"))
        '7
        DtSimple.Columns.Add("DVal5", System.Type.GetType("System.Double"))
        '8
        DtSimple.Columns.Add("DVal6", System.Type.GetType("System.Double"))
        '9
        DtSimple.Columns.Add("DVal7", System.Type.GetType("System.Double"))
        '10
        DtSimple.Columns.Add("DVal8", System.Type.GetType("System.Double"))
        '11
        DtSimple.Columns.Add("DVal9", System.Type.GetType("System.Double"))
        '12
        DtSimple.Columns.Add("DVal10", System.Type.GetType("System.Double"))
        '13
        DtSimple.Columns.Add("DVal11", System.Type.GetType("System.Double"))
        '14
        DtSimple.Columns.Add("DVal12", System.Type.GetType("System.Double"))
        '15
        DtSimple.Columns.Add("DVal13", System.Type.GetType("System.Double"))
        '16
        DtSimple.Columns.Add("DVal14", System.Type.GetType("System.Double"))
        '17
        DtSimple.Columns.Add("DVal15", System.Type.GetType("System.Double"))
        '18
        DtSimple.Columns.Add("DVTotal", System.Type.GetType("System.Double"))

        ''''''''''''''''''''''Contributions''''''''''''''''''''''
        '3
        DtSimple.Columns.Add("CVal1", System.Type.GetType("System.Double"))
        '4
        DtSimple.Columns.Add("CVal2", System.Type.GetType("System.Double"))
        '5
        DtSimple.Columns.Add("CVal3", System.Type.GetType("System.Double"))
        '6
        DtSimple.Columns.Add("CVal4", System.Type.GetType("System.Double"))
        '7
        DtSimple.Columns.Add("CVal5", System.Type.GetType("System.Double"))
        '8
        DtSimple.Columns.Add("CVal6", System.Type.GetType("System.Double"))
        '9
        DtSimple.Columns.Add("CVal7", System.Type.GetType("System.Double"))
        '10
        DtSimple.Columns.Add("CVal8", System.Type.GetType("System.Double"))
        '11
        DtSimple.Columns.Add("CVal9", System.Type.GetType("System.Double"))
        '12
        DtSimple.Columns.Add("CVal10", System.Type.GetType("System.Double"))
        '13
        DtSimple.Columns.Add("CVal11", System.Type.GetType("System.Double"))
        '14
        DtSimple.Columns.Add("CVal12", System.Type.GetType("System.Double"))
        '15
        DtSimple.Columns.Add("CVal13", System.Type.GetType("System.Double"))
        '16
        DtSimple.Columns.Add("CVal14", System.Type.GetType("System.Double"))
        '17
        DtSimple.Columns.Add("CVal15", System.Type.GetType("System.Double"))
        '18
        DtSimple.Columns.Add("CVTotal", System.Type.GetType("System.Double"))
        '
        DtSimple.Columns.Add("NetSalary", System.Type.GetType("System.Double"))
        '
        DtSimple.Columns.Add("AmountOnCheque", System.Type.GetType("System.Double"))

        DtSimple.Columns.Add("CompanyCost", System.Type.GetType("System.Double"))

        DtSimple.Columns.Add("DOB", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("DOE", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Code1", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Desc1", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Code2", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Desc2", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Code3", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Desc3", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Code4", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Desc4", System.Type.GetType("System.String"))

        DtSimple.Columns.Add("AL_Code5", System.Type.GetType("System.String"))
        
        DtSimple.Columns.Add("AL_Desc5", System.Type.GetType("System.String"))
        




    End Sub
    Private Sub InitDataTable_split()
        '  xxxx()
        DtSplit = New DataTable("Table1")
        '1
        DtSplit.Columns.Add("Company", System.Type.GetType("System.String"))
        '2
        DtSplit.Columns.Add("PeriodCode", System.Type.GetType("System.String"))
        '3
        DtSplit.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '4
        DtSplit.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '5
        DtSplit.Columns.Add("ActualUnits", System.Type.GetType("System.Double"))
        '6
        DtSplit.Columns.Add("TotalEarnings", System.Type.GetType("System.String"))
        '7
        DtSplit.Columns.Add("TotalDeductions", System.Type.GetType("System.String"))
        '8
        DtSplit.Columns.Add("Totalcontributions", System.Type.GetType("System.String"))
        '9
        DtSplit.Columns.Add("Net", System.Type.GetType("System.String"))
        '10
        DtSplit.Columns.Add("TaxDeduction", System.Type.GetType("System.String"))
        '11
        DtSplit.Columns.Add("SIDeduction", System.Type.GetType("System.String"))




    End Sub
    Private Sub LoadCombos()
        LoadPeriodGroup()
        LoadPeriods()
        LoadPeriodsTo()
        LoadEmployeeFrom()
        LoadEmployeeTo()
        LoadPrAnBanks()
        Dim Found As Boolean = True
        Dim i As Integer
        For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
            If CType(Me.cmbPeriodGroups.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year Then
                found = True
                Me.cmbPeriodGroups.SelectedIndex = i
                Exit For
            End If
        Next
        If Not Found Then
            For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
                If CType(Me.cmbPeriodGroups.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year - 1 Then
                    Found = True
                    Me.cmbPeriodGroups.SelectedIndex = i
                    Exit For
                End If
            Next
        End If



    End Sub
    Private Sub LoadPrAnBanks()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.ComboBank
                .BeginUpdate()
                .Items.Clear()
                .Items.Add("ALL")

                Me.ComboEmpBank.BeginUpdate()
                Me.ComboEmpBank.Items.Clear()
                Me.ComboEmpBank.Items.Add("ALL")

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnBanks)
                    Me.ComboEmpBank.Items.Add(tPrAnBanks)

                Next i
                '   .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
                Me.ComboEmpBank.SelectedIndex = 0
                Me.ComboEmpBank.EndUpdate()

            End With
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
    Private Sub LoadPeriods()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PerGroup.Code)
        With Me.CmbPeriod
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrMsPeriodCodes(ds.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False
    End Sub
    Private Sub LoadPeriodsTo()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PerGroup.Code)
        With Me.cmbPeriodTo
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrMsPeriodCodes(ds.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        Loading = False
    End Sub
    Private Sub LoadEmployeeFrom()

    End Sub
    Private Sub LoadEmployeeTo()

    End Sub


    Private Sub CmbPeriodGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPeriodGroups.SelectedIndexChanged
        Try
            PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            TemGrp = New cPrMsTemplateGroup(PerGroup.TemGrpCode)
            Me.TextBox1.Text = TemGrp.Code & " - " & TemGrp.DescriptionL
            LoadPeriods()
            LoadPeriodsTo()

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub GetPeriodEDC(ByVal Period As cPrMsPeriodCodes)
        Dim SortByReportingSequence As Boolean = False
        If Me.CBSortByEDCSequence.Checked Then
            SortByReportingSequence = True
        Else
            SortByReportingSequence = False
        End If
        DsP_Ern = Global1.Business.GetAllPrMsPeriodEarnings(Period.Code, Period.PrdGrpCode, False, SortByReportingSequence)
        DsP_Ded = Global1.Business.GetAllPrMsPeriodDeductions(Period.Code, Period.PrdGrpCode, False, SortByReportingSequence)
        DsP_Con = Global1.Business.GetAllPrMsPeriodContributions(Period.Code, Period.PrdGrpCode, False, SortByReportingSequence)
        'DsP_Ern = Global1.Business.GetAllPrMsPeriodEarningsOrderBySeq(Period.Code, Period.PrdGrpCode, False)
        'DsP_Ded = Global1.Business.GetAllPrMsPeriodDeductionsOrderBySeq(Period.Code, Period.PrdGrpCode, False)
        'DsP_Con = Global1.Business.GetAllPrMsPeriodContributionsOrderBySeq(Period.Code, Period.PrdGrpCode, False)
    End Sub
    Private Sub ClearGrid()
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        For k = 0 To 14
            DG1.Columns(Me.Column_E1 + C1).Visible = False
            C1 = C1 + 2
            DG1.Columns(Me.Column_EV1 + C2).Visible = False
            DG1.Columns(Me.Column_EV1 + C2).HeaderText = ""
            C2 = C2 + 2
        Next
        C1 = 0
        C2 = 0
        For k = 0 To 14
            DG1.Columns(Me.Column_D1 + C1).Visible = False
            C1 = C1 + 2
            DG1.Columns(Me.Column_DV1 + C2).Visible = False
            DG1.Columns(Me.Column_DV1 + C2).HeaderText = ""
            C2 = C2 + 2
        Next
        C1 = 0
        C2 = 0
        For k = 0 To 14
            DG1.Columns(Me.Column_C1 + C1).Visible = False
            C1 = C1 + 2
            DG1.Columns(Me.Column_CV1 + C2).Visible = False
            DG1.Columns(Me.Column_CV1 + C2).HeaderText = ""
            C2 = C2 + 2
        Next
    End Sub
    'Private Sub TSBReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'InitDataGrid()
    '    DG1.DataSource = MyDs.Tables(0)

    '    PrepareReport()

    'End Sub
    Private Sub PrepareReport(ByVal SortByEDCReportingSequence As Boolean)

        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDs.Tables(0).Rows.Clear()
        Dim Per As New cPrMsPeriodCodes
        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeader As DataSet
        Dim DsEmp As DataSet
        Dim DsPeriods As DataSet

        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text

        Dim GenAnal1 As String
        GenAnal1 = Me.txtGenAnal1.Text

        Dim SICategory As String
        SICategory = Me.txtSICategory.Text


        DsPeriods = Global1.Business.GetPeriodRange(PerFrom, PerTo)
        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False
        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If

        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim BankCodeEmp As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCodeEmp = "ALL"
        Else
            BankCodeEmp = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If
        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        If CheckDataSet(DsPeriods) Then

            For j = 0 To DsPeriods.Tables(0).Rows.Count - 1

                'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Per = New cPrMsPeriodCodes(DsPeriods.Tables(0).Rows(j))
                GetPeriodEDC(Per)


                DsHeader = Global1.Business.GetAllTrxnHeaderForPeriod(Per, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)


                If CheckDataSet(DsHeader) Then
                    Dim LinErn As DataSet
                    Dim LinDed As DataSet
                    Dim LinCon As DataSet
                    Dim ErnCode As String
                    Dim DedCode As String
                    Dim Concode As String
                    Dim HdrId As Integer
                    Dim EmpCode As String
                    Dim EmpName As String
                    Dim NetSalary As Double
                    Dim PeriodUnit As Double

                    Dim Ei As Integer
                    Dim Di As Integer
                    Dim Ci As Integer
                    Dim ErnValue As Double
                    Dim DedValue As Double
                    Dim ConValue As Double
                    Dim ErnDesc As String
                    Dim DedDesc As String
                    Dim ConDesc As String

                    Dim TotalE As Double = 0
                    Dim TotalD As Double = 0
                    Dim TotalC As Double = 0
                    Dim Overtime1 As Double = 0
                    Dim Overtime2 As Double = 0
                    Dim Overtime3 As Double = 0

                    Dim Salary1 As Double = 0
                    Dim Salary2 As Double = 0

                    Dim Sectors As Double = 0
                    Dim DutyHours As Double = 0
                    Dim FlightHours As Double = 0
                    Dim Commission As Double = 0
                    Dim Overlay As Double = 0
                    Dim PosCode As String = ""
                    Dim GLanal1 As String = ""
                    Dim AnalysisCode3 As String = ""



                    Dim SIDeductionCode As String
                    Dim SIContributionCode As String
                    Dim Reference As String

                    SIDeductionCode = Global1.Business.GetDecuctionCodeForSI
                    SIContributionCode = Global1.Business.GetContributionCodeForSI

                    TotalEmp = 0

                    For i = 0 To DsHeader.Tables(0).Rows.Count - 1

                        TotalEmp = DsHeader.Tables(0).Rows.Count

                        SIDedTotal = 0
                        SIConTotal = 0
                        Dim r As DataRow = Dt1.NewRow()
                        HdrId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                        EmpCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
                        NetSalary = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(3))
                        PeriodUnit = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(5))
                        Reference = DbNullToString(DsHeader.Tables(0).Rows(i).Item(6))

                        Overtime1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(7))
                        Overtime2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(8))

                        Salary1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(9))
                        Salary2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(10))
                        Overtime3 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(11))

                        Sectors = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(12))
                        DutyHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(13))
                        FlightHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(14))
                        Commission = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(15))
                        Overlay = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(19))
                        AnalysisCode2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(18))
                        PosCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(22))
                        DOE = Format(DbNullToDate(DsHeader.Tables(0).Rows(i).Item(21)), "dd/MM/yyyy")
                        GLanal1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(36))
                        AnalysisCode3 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(39))

                        Dim EmpPos As New cPrAnEmployeePositions(PosCode)
                        Position = EmpPos.DescriptionL





                        LinErn = Global1.Business.GetTrxnLinesEarningsForHeaderForPeriod(HdrId, Per)
                        LinDed = Global1.Business.GetTrxnLinesDeductionsForHeaderForPeriod(HdrId, Per)
                        LinCon = Global1.Business.GetTrxnLinesContributionsForHeaderForPeriod(HdrId, Per)
                        r(Me.Column_PeriodCode) = Per.Code
                        r(Me.Column_EmpCode) = EmpCode
                        r(Me.Column_EmpName) = EmpName
                        r(Me.Column_NetSalary) = NetSalary
                        r(Me.Column_ActualUnits) = PeriodUnit
                        r(Me.Column_Overtime1) = Format(Overtime1, "0.00")
                        r(Me.Column_OverTime2) = Format(Overtime2, "0.00")
                        r(Me.Column_OverTime3) = Format(Overtime3, "0.00")
                        r(Me.Column_Salary1) = Format(Salary1, "0.00")
                        r(Me.Column_Salary2) = Format(Salary2, "0.00")

                        r(Me.Column_sectors) = Format(Sectors, "0.00")
                        r(Me.Column_dutyhours) = Format(DutyHours, "0.00")
                        r(Me.Column_flighthours) = Format(FlightHours, "0.00")
                        r(Me.Column_commission) = Format(Commission, "0.00")
                        r(Me.Column_OverLay) = Format(Overlay, "0.00")
                        r(Me.Column_AnalysisCode) = AnalysisCode2
                        r(Me.Column_GenAnal1) = GLanal1
                        r(Me.Column_AL_Code3) = AnalysisCode3


                        r(Column_Position) = Position
                        r(Column_DOE) = DOE




                        Dim Ce As Integer = 0
                        Dim Cd As Integer = 0
                        Dim Cc As Integer = 0

                        '------------------------------------------------------------------
                        'Earnings
                        '------------------------------------------------------------------
                        C1 = 0
                        C2 = 0
                        For k = 0 To 14
                            r(Me.Column_E1 + C1) = ""
                            C1 = C1 + 2
                            r(Me.Column_EV1 + C2) = "0.00"
                            C2 = C2 + 2
                        Next
                        TotalE = 0
                        If CheckDataSet(DsP_Ern) Then
                            For Ei = 0 To DsP_Ern.Tables(0).Rows.Count - 1
                                Dim NotInclude As Boolean = False
                                ErnCode = DbNullToString(DsP_Ern.Tables(0).Rows(Ei).Item(3))
                                ErnValue = 0
                                ErnDesc = ""
                                r(Me.Column_E1 + Ce) = ErnCode
                                Dim TCODE As New cPrMsEarningCodes(ErnCode)
                                For k = 0 To LinErn.Tables(0).Rows.Count - 1
                                    If DbNullToString(LinErn.Tables(0).Rows(k).Item(0)) = ErnCode Then
                                        ErnValue = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(1))
                                        ErnDesc = DbNullToString(LinErn.Tables(0).Rows(k).Item(2))
                                        If TCODE.ErnTypCode = "TO" Then
                                            Dim T As Double = 0
                                            T = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(4))
                                            r(Me.Column_TimeOff) = Format(T, "0.00")
                                        End If
                                        Exit For
                                    End If
                                Next

                                If TCODE.Code <> "" Then
                                    If TCODE.ErnTypCode = "3E" Or TCODE.ErnTypCode = "4E" Or TCODE.ErnTypCode = "UM" Or TCODE.ErnTypCode = "LP" Then
                                        NotInclude = True
                                    End If
                                End If
                                If Not NotInclude Then
                                    TotalE = TotalE + ErnValue
                                End If
                                r(Me.Column_EV1 + Ce) = Format(ErnValue, "0.00")
                                ChangeColumnName(ErnDesc, Column_EV1 + Ce, "E")
                                Ce = Ce + 2
                                ErnValue = 0
                                NotInclude = False


                            Next
                            r(Me.Column_EVTotal) = Format(TotalE, "0.00")
                        End If
                        '------------------------------------------------------------------
                        'Deductions
                        '------------------------------------------------------------------
                        C1 = 0
                        C2 = 0
                        For k = 0 To 14
                            r(Me.Column_D1 + C1) = ""
                            C1 = C1 + 2
                            r(Me.Column_DV1 + C2) = "0.00"
                            C2 = C2 + 2
                        Next
                        TotalD = 0
                        If CheckDataSet(DsP_Ded) Then
                            For Di = 0 To DsP_Ded.Tables(0).Rows.Count - 1
                                DedValue = 0
                                DedCode = DbNullToString(DsP_Ded.Tables(0).Rows(Di).Item(3))
                                DedDesc = ""
                                r(Me.Column_D1 + Cd) = DedCode
                                For k = 0 To LinDed.Tables(0).Rows.Count - 1
                                    If DbNullToString(LinDed.Tables(0).Rows(k).Item(0)) = DedCode Then

                                        DedValue = DbNullToDouble(LinDed.Tables(0).Rows(k).Item(1))
                                        DedDesc = DbNullToString(LinDed.Tables(0).Rows(k).Item(2))
                                        If DedCode = SIDeductionCode Then
                                            SIDedTotal = SIDedTotal + DedValue
                                        End If
                                        Exit For
                                    End If
                                Next
                                TotalD = TotalD + DedValue
                                r(Me.Column_DV1 + Cd) = Format(DedValue, "0.00")
                                ChangeColumnName(DedDesc, Column_DV1 + Cd, "D")
                                Cd = Cd + 2
                            Next
                            r(Column_DVTotal) = Format(TotalD, "0.00")

                        End If
                        '------------------------------------------------------------------
                        'Contributions
                        '------------------------------------------------------------------
                        C1 = 0
                        C2 = 0
                        For k = 0 To 14
                            r(Me.Column_C1 + C1) = ""
                            C1 = C1 + 2
                            r(Me.Column_CV1 + C2) = "0.00"
                            C2 = C2 + 2
                        Next
                        TotalC = 0
                        If CheckDataSet(DsP_Con) Then
                            For Ci = 0 To DsP_Con.Tables(0).Rows.Count - 1
                                Concode = DbNullToString(DsP_Con.Tables(0).Rows(Ci).Item(3))
                                ConValue = 0
                                ConDesc = ""
                                r(Me.Column_C1 + Cc) = Concode
                                For k = 0 To LinCon.Tables(0).Rows.Count - 1
                                    If DbNullToString(LinCon.Tables(0).Rows(k).Item(0)) = Concode Then
                                        ConValue = DbNullToDouble(LinCon.Tables(0).Rows(k).Item(1))
                                        ConDesc = DbNullToString(LinCon.Tables(0).Rows(k).Item(2))
                                        If Concode = SIContributionCode Then
                                            SIConTotal = SIConTotal + ConValue
                                        End If
                                        Exit For
                                    End If
                                Next
                                TotalC = TotalC + ConValue
                                r(Me.Column_CV1 + Cc) = Format(ConValue, "0.00")
                                ChangeColumnName(ConDesc, Column_CV1 + Cc, "C")
                                Cc = Cc + 2
                            Next
                            r(Column_CVTotal) = Format(TotalC, "0.00")
                        End If
                        r(Column_CompanyCost) = Format(TotalE + TotalC, "0.00")
                        r(Column_SITotal) = Format((SIConTotal + SIDedTotal), "0.00")
                        r(Column_ChequeNo) = Reference

                        Dt1.Rows.Add(r)
                    Next
                End If

                Dim Total As Double = 0
                Dim AU As Double = 0
                Dim NetSal As Double = 0
                Dim TE As Double = 0
                Dim TD As Double = 0
                Dim TC As Double = 0
                Dim CCost As Double = 0
                Dim SICost As Double = 0
                Dim TotalOT1 As Double = 0
                Dim TotalOT2 As Double = 0
                Dim TotalOT3 As Double = 0
                Dim TotalSal1 As Double = 0
                Dim TotalSal2 As Double = 0

                Dim TotalSectors As Double = 0
                Dim totaldutyhours As Double = 0
                Dim totalflighthours As Double = 0
                Dim totalcommission As Double = 0
                Dim totalOverlay As Double = 0
                Dim TotalTo As Double = 0

                Dim CNo As String

                If CheckDataSet(MyDs) Then
                    If Not YTDReport Then
                        Dim Rempty As DataRow = Dt1.NewRow()
                        Dt1.Rows.Add(Rempty)

                        Dim r As DataRow = Dt1.NewRow()
                        r(Me.Column_EmpCode) = "TOTALS (" & TotalEmp & ")"
                        r(Me.Column_EmpName) = Per.Code & " - " & Per.DescriptionL

                        C1 = 0
                        For k = 0 To 14
                            Total = 0
                            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                                If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                    Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EV1 + C1))
                                End If
                            Next
                            r(Me.Column_EV1 + C1) = Total
                            C1 = C1 + 2
                        Next
                        C1 = 0
                        For k = 0 To 14
                            Total = 0
                            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                                If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                    Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV1 + C1))
                                End If
                            Next
                            r(Me.Column_DV1 + C1) = Total
                            C1 = C1 + 2
                        Next
                        C1 = 0
                        For k = 0 To 14
                            Total = 0
                            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                                If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                    Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CV1 + C1))
                                End If
                            Next
                            r(Me.Column_CV1 + C1) = Total
                            C1 = C1 + 2
                        Next

                        AU = 0
                        NetSal = 0
                        TE = 0
                        TD = 0
                        TC = 0
                        CCost = 0
                        SICost = 0
                        TotalOT1 = 0
                        TotalOT2 = 0
                        TotalSal1 = 0
                        TotalSal2 = 0

                        TotalSectors = 0
                        totaldutyhours = 0
                        totalflighthours = 0
                        totalcommission = 0
                        totalOverlay = 0
                        TotalTo = 0

                        TotalTo = 0

                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                AU = AU + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
                                NetSal = NetSal + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_NetSalary))
                                TE = TE + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EVTotal))
                                TD = TD + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DVTotal))
                                TC = TC + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CVTotal))
                                CCost = CCost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                                SICost = SICost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SITotal))
                                TotalOT1 = TotalOT1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                                TotalOT2 = TotalOT2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime2))
                                TotalOT3 = TotalOT3 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime3))
                                TotalSal1 = TotalSal1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary1))
                                TotalSal2 = TotalSal2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary2))

                                TotalSectors = TotalSectors + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_sectors))
                                totaldutyhours = totaldutyhours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_dutyhours))
                                totalflighthours = totalflighthours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_flighthours))
                                totalcommission = totalcommission + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_commission))
                                totalOverlay = totalOverlay + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverLay))
                                TotalTo = TotalTo + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                            End If

                        Next

                        r(Me.Column_ActualUnits) = Format(AU, "0.00")
                        r(Me.Column_NetSalary) = Format(NetSal, "0.00")
                        r(Me.Column_EVTotal) = Format(TE, "0.00")
                        r(Me.Column_DVTotal) = Format(TD, "0.00")
                        r(Me.Column_CVTotal) = Format(TC, "0.00")
                        r(Me.Column_CompanyCost) = Format(CCost, "0.00")
                        r(Me.Column_SITotal) = Format(SICost, "0.00")
                        r(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                        r(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                        r(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
                        r(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                        r(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                        r(Me.Column_sectors) = Format(TotalSectors, "0.00")
                        r(Me.Column_dutyhours) = Format(totaldutyhours, "0.00")
                        r(Me.Column_flighthours) = Format(totalflighthours, "0.00")
                        r(Me.Column_commission) = Format(totalcommission, "0.00")
                        r(Me.Column_OverLay) = Format(totalOverlay, "0.00")
                        r(Me.Column_AnalysisCode) = ""
                        r(Me.Column_Position) = ""
                        r(Me.Column_DOE) = ""
                        r(Me.Column_TimeOff) = Format(TotalTo, "0.00")






                        Dt1.Rows.Add(r)
                        Dim rx As DataRow = Dt1.NewRow()
                        Dt1.Rows.Add(rx)
                    End If
                End If
            Next
        End If


        Me.Cursor = Cursors.Default
        Application.DoEvents()

    End Sub
    Private Sub PrepareReport2(ByVal OnlyActiveemployees As Boolean, ByVal OnlyEmpWithTermDate As Boolean)

        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor

        MyDs.Tables(0).Rows.Clear()

        Dim Per As New cPrMsPeriodCodes
        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeader As DataSet
        Dim DsEmp As DataSet
        Dim DsPeriods As DataSet

        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String

        Dim GenAnal1 As String
        Dim SICategory As String


        Dim OrderByAnal As Integer = 0
        If Me.CBOrderByAnal.CheckState = CheckState.Checked Then
            If Me.txtOrderBy.Text = "" Then
                MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If
            OrderByAnal = txtOrderBy.Text
            If OrderByAnal <= 0 Or OrderByAnal >= 7 Then
                MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If
        End If

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text

        GenAnal1 = Me.txtGenAnal1.Text
        SICategory = Me.txtSICategory.Text

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                ageisok = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If

        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        DsPeriods = Global1.Business.GetPeriodRange(PerFrom, PerTo)
        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False

        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If

        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim EmpBankCode As String
        If Me.ComboEmpBank.SelectedIndex = 0 Then
            EmpBankCode = "ALL"
        Else
            EmpBankCode = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        GLBAnalysisDescriptionOnTheReport = Me.ComboAnal.Text
        GLBBankDescriptionOnTheReport = Me.ComboBank.Text

        If CheckDataSet(DsPeriods) Then

            For j = 0 To DsPeriods.Tables(0).Rows.Count - 1



                'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Per = New cPrMsPeriodCodes(DsPeriods.Tables(0).Rows(j))
                GetPeriodEDC(Per)


                DsHeader = Global1.Business.GetAllTrxnHeaderForPeriod(Per, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, OnlyActiveemployees, GenAnal1, OrderByAnal, BankCode, EmpBankCode, OnlyEmpWithTermDate, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)
                LoadHeaderOfReport(DsHeader, Per, True)
            Next
        End If



        Me.Cursor = Cursors.Default
        Application.DoEvents()
        DG1.Cursor = Cursors.Default

    End Sub

    Private Sub LoadHeaderOfReport(ByVal DsHeader As DataSet, ByVal Per As cPrMsPeriodCodes, ByVal IncludeTotals As Boolean)
        Dim TotalEmp As Integer = 0
        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0
        Dim j As Integer
        Dim k As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0

        Dim i As Integer

        If CheckDataSet(DsHeader) Then

            Dim LinErn As DataSet
            Dim LinDed As DataSet
            Dim LinCon As DataSet
            Dim ErnCode As String
            Dim DedCode As String
            Dim Concode As String
            Dim HdrId As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim NetSalary As Double
            Dim PeriodUnit As Double

            Dim Ei As Integer
            Dim Di As Integer
            Dim Ci As Integer
            Dim ErnValue As Double
            Dim DedValue As Double
            Dim ConValue As Double
            Dim ErnDesc As String
            Dim DedDesc As String
            Dim ConDesc As String

            Dim TotalE As Double = 0
            Dim TotalD As Double = 0
            Dim TotalC As Double = 0
            Dim Overtime1 As Double = 0
            Dim Overtime2 As Double = 0
            Dim Overtime3 As Double = 0

            Dim Salary1 As Double = 0
            Dim Salary2 As Double = 0

            Dim Sectors As Double = 0
            Dim DutyHours As Double = 0
            Dim FlightHours As Double = 0
            Dim Commission As Double = 0
            Dim Overlay As Double = 0
            Dim PosCode As String = ""
            Dim GLAnal1 As String = ""

            Dim AL_Code1 As String = ""
            Dim AL_Code2 As String = ""
            Dim AL_Code3 As String = ""
            Dim AL_Code4 As String = ""
            Dim AL_Code5 As String = ""

            Dim AL_Desc1 As String = ""
            Dim AL_Desc2 As String = ""
            Dim AL_Desc3 As String = ""
            Dim AL_Desc4 As String = ""
            Dim AL_Desc5 As String = ""

            Dim TermDate As String = ""
            Dim SINumber As String = ""

            Dim BankBenName As String = ""
            Dim ComBank As String = ""
            Dim DOB As String = ""
            Dim Identity As String = ""
            Dim TIC As String = ""
            Dim StartDate As String = ""
            Dim FullAddress As String = ""
            Dim HRCode As String = ""
            Dim Maternity As String = ""
            Dim FEPercentage As String = ""
            Dim FEControlAmount As String = ""
            Dim EmpTermReason As String = ""





            Dim SIDeductionCode As String
            Dim SIContributionCode As String
            Dim Reference As String

            SIDeductionCode = Global1.Business.GetDecuctionCodeForSI
            SIContributionCode = Global1.Business.GetContributionCodeForSI

            TotalEmp = 0

            For i = 0 To DsHeader.Tables(0).Rows.Count - 1

                Application.DoEvents()
                Me.lblStatus.Text = "Please wait Loading Report Lines " & i

                TotalEmp = DsHeader.Tables(0).Rows.Count

                SIDedTotal = 0
                SIConTotal = 0

                Dim r As DataRow = Dt1.NewRow()
                HdrId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                EmpCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
                NetSalary = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(3))
                PeriodUnit = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(5))
                Reference = DbNullToString(DsHeader.Tables(0).Rows(i).Item(6))

                Overtime1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(7))
                Overtime2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(8))

                Salary1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(9))
                Salary2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(10))
                Overtime3 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(11))

                Sectors = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(12))
                DutyHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(13))
                FlightHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(14))
                Commission = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(15))
                Overlay = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(19))
                AnalysisCode2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(18))
                StartDate = Format((DsHeader.Tables(0).Rows(i).Item(21)), "dd/MM/yyyy")
                PosCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(22))
                DOE = Format((DsHeader.Tables(0).Rows(i).Item(21)), "dd/MM/yyyy")
                GLAnal1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(36))


                AL_Code1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(37))
                AL_Code2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(38))
                AL_Code3 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(39))
                AL_Code4 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(40))
                AL_Code5 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(41))

                AL_Desc1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(42))
                AL_Desc2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(43))
                AL_Desc3 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(44))
                AL_Desc4 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(45))
                AL_Desc5 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(46))

                TermDate = DbNullToString(DsHeader.Tables(0).Rows(i).Item(47))
                SINumber = DbNullToString(DsHeader.Tables(0).Rows(i).Item(48))

                BankBenName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(49))
                ComBank = DbNullToString(DsHeader.Tables(0).Rows(i).Item(50))
                DOB = Format((DsHeader.Tables(0).Rows(i).Item(51)), "dd/MM/yyyy")
                Identity = DbNullToString(DsHeader.Tables(0).Rows(i).Item(52))
                TIC = DbNullToString(DsHeader.Tables(0).Rows(i).Item(53))

                FullAddress = DbNullToString(DsHeader.Tables(0).Rows(i).Item(54))
                FullAddress = FullAddress & " " & DbNullToString(DsHeader.Tables(0).Rows(i).Item(55))
                FullAddress = FullAddress & " " & DbNullToString(DsHeader.Tables(0).Rows(i).Item(56))
                FullAddress = FullAddress & " " & DbNullToString(DsHeader.Tables(0).Rows(i).Item(57))

                HRCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(58))
                Maternity = DbNullToString(DsHeader.Tables(0).Rows(i).Item(59))
                FEPercentage = DbNullToString(DsHeader.Tables(0).Rows(i).Item(60))
                FEControlAmount = DbNullToString(DsHeader.Tables(0).Rows(i).Item(61))
                empTermReason = DbNullToString(DsHeader.Tables(0).Rows(i).Item(62))

                Dim EmpPos As New cPrAnEmployeePositions(PosCode)
                Position = EmpPos.DescriptionL


                LinErn = Global1.Business.GetTrxnLinesEarningsForHeaderForPeriod(HdrId, Per)
                LinDed = Global1.Business.GetTrxnLinesDeductionsForHeaderForPeriod(HdrId, Per)
                LinCon = Global1.Business.GetTrxnLinesContributionsForHeaderForPeriod(HdrId, Per)

                r(Me.Column_PeriodCode) = Per.Code
                r(Me.Column_EmpCode) = EmpCode
                r(Me.Column_EmpName) = EmpName
                r(Me.Column_NetSalary) = NetSalary
                r(Me.Column_ActualUnits) = PeriodUnit
                r(Me.Column_Overtime1) = Format(Overtime1, "0.00")
                r(Me.Column_OverTime2) = Format(Overtime2, "0.00")
                r(Me.Column_OverTime3) = Format(Overtime3, "0.00")
                r(Me.Column_Salary1) = Format(Salary1, "0.00")
                r(Me.Column_Salary2) = Format(Salary2, "0.00")

                r(Me.Column_sectors) = Format(Sectors, "0.00")
                r(Me.Column_dutyhours) = Format(DutyHours, "0.00")
                r(Me.Column_flighthours) = Format(FlightHours, "0.00")
                r(Me.Column_commission) = Format(Commission, "0.00")
                r(Me.Column_OverLay) = Format(Overlay, "0.00")
                r(Me.Column_AnalysisCode) = AnalysisCode2

                r(Column_Position) = Position
                r(Column_DOE) = DOE
                r(Me.Column_GenAnal1) = GLAnal1



                r(Column_Analysis2) = ""

                r(Column_AL_Code1) = AL_Code1
                r(Column_AL_Code2) = AL_Code2
                r(Column_AL_Code3) = AL_Code3
                r(Column_AL_Code4) = AL_Code4
                r(Column_AL_Code5) = AL_Code5

                r(Column_AL_Desc1) = AL_Desc1
                r(Column_AL_Desc2) = AL_Desc2
                r(Column_AL_Desc3) = AL_Desc3
                r(Column_AL_Desc4) = AL_Desc4
                r(Column_AL_Desc5) = AL_Desc5

                r(Column_Analysis2) = AL_Desc2

                r(Column_TermDate) = TermDate
                r(Column_SINumber) = SINumber

                r(Column_BankBenName) = BankBenName
                r(Column_ComBank) = ComBank
                r(Column_DOB) = DOB
                r(Column_Identity) = Identity
                r(Column_TIC) = TIC

                If Me.ShowAddress Then
                    r(column_address) = FullAddress
                End If
                If Me.ShowHRCode Then
                    r(Column_HRCode) = HRCode
                End If
                r(Column_Maternity) = Maternity
                r(Column_FEPercentage) = FEPercentage
                r(Column_FEControlAmount) = FEControlAmount
                r(Column_EmpTermReason) = empTermReason



                'If ShowAnalysisDescription Then


                '    Dim Empanal2 As New cPrAnEmployeeAnalysis2(AnalysisCode2)
                '    r(Column_Analysis2) = Empanal2.DescriptionL
                'Else
                '    r(Column_Analysis2) = ""
                'End If


                Dim Ce As Integer = 0
                Dim Cd As Integer = 0
                Dim Cc As Integer = 0

                '------------------------------------------------------------------
                'Earnings
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    r(Me.Column_E1 + C1) = ""
                    C1 = C1 + 2
                    r(Me.Column_EV1 + C2) = "0.00"
                    C2 = C2 + 2
                Next
                TotalE = 0
                If CheckDataSet(DsP_Ern) Then
                    For Ei = 0 To DsP_Ern.Tables(0).Rows.Count - 1
                        Dim NotInclude As Boolean = False
                        ErnCode = DbNullToString(DsP_Ern.Tables(0).Rows(Ei).Item(3))
                        ErnValue = 0
                        ErnDesc = ""
                        r(Me.Column_E1 + Ce) = ErnCode
                        Dim TCODE As New cPrMsEarningCodes(ErnCode)
                        For k = 0 To LinErn.Tables(0).Rows.Count - 1
                            If DbNullToString(LinErn.Tables(0).Rows(k).Item(0)) = ErnCode Then
                                ErnValue = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(1))
                                ErnDesc = DbNullToString(LinErn.Tables(0).Rows(k).Item(2))
                                If TCODE.ErnTypCode = "TO" Then
                                    Dim T As Double = 0
                                    T = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(4))
                                    r(Me.Column_TimeOff) = Format(T, "0.00")
                                End If
                                Exit For
                            End If
                        Next

                        If TCODE.Code <> "" Then
                            If TCODE.ErnTypCode = "3E" Or TCODE.ErnTypCode = "4E" Or TCODE.ErnTypCode = "UM" Or TCODE.ErnTypCode = "LP" Or TCODE.ErnTypCode = "BK" Or TCODE.ErnTypCode = "BR" Or TCODE.ErnTypCode = "B2" Then
                                NotInclude = True
                            End If
                            If TCODE.ErnTypCode = Global1.Param_IncludeInTotal1 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal2 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal3 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal4 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal5 Then
                                NotInclude = False
                            End If
                        End If
                        If Not NotInclude Then
                            TotalE = TotalE + ErnValue
                        End If
                        r(Me.Column_EV1 + Ce) = Format(ErnValue, "0.00")
                        ChangeColumnName(ErnDesc, Column_EV1 + Ce, "E")
                        Ce = Ce + 2
                        ErnValue = 0
                        NotInclude = False


                    Next
                    r(Me.Column_EVTotal) = Format(TotalE, "0.00")


                    Application.DoEvents()

                End If
                '------------------------------------------------------------------
                'Deductions
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    r(Me.Column_D1 + C1) = ""
                    C1 = C1 + 2
                    r(Me.Column_DV1 + C2) = "0.00"
                    C2 = C2 + 2
                Next
                TotalD = 0
                If CheckDataSet(DsP_Ded) Then
                    For Di = 0 To DsP_Ded.Tables(0).Rows.Count - 1
                        DedValue = 0
                        DedCode = DbNullToString(DsP_Ded.Tables(0).Rows(Di).Item(3))
                        DedDesc = ""
                        r(Me.Column_D1 + Cd) = DedCode
                        For k = 0 To LinDed.Tables(0).Rows.Count - 1
                            If DbNullToString(LinDed.Tables(0).Rows(k).Item(0)) = DedCode Then

                                DedValue = DbNullToDouble(LinDed.Tables(0).Rows(k).Item(1))
                                DedDesc = DbNullToString(LinDed.Tables(0).Rows(k).Item(2))
                                If DedCode = SIDeductionCode Then
                                    SIDedTotal = SIDedTotal + DedValue
                                End If
                                Exit For
                            End If
                        Next
                        TotalD = TotalD + DedValue
                        r(Me.Column_DV1 + Cd) = Format(DedValue, "0.00")
                        ChangeColumnName(DedDesc, Column_DV1 + Cd, "D")
                        Cd = Cd + 2
                    Next
                    r(Column_DVTotal) = Format(TotalD, "0.00")

                End If
                '------------------------------------------------------------------
                'Contributions
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    r(Me.Column_C1 + C1) = ""
                    C1 = C1 + 2
                    r(Me.Column_CV1 + C2) = "0.00"
                    C2 = C2 + 2
                Next
                TotalC = 0
                If CheckDataSet(DsP_Con) Then
                    For Ci = 0 To DsP_Con.Tables(0).Rows.Count - 1
                        Concode = DbNullToString(DsP_Con.Tables(0).Rows(Ci).Item(3))
                        ConValue = 0
                        ConDesc = ""
                        r(Me.Column_C1 + Cc) = Concode
                        For k = 0 To LinCon.Tables(0).Rows.Count - 1
                            If DbNullToString(LinCon.Tables(0).Rows(k).Item(0)) = Concode Then
                                ConValue = DbNullToDouble(LinCon.Tables(0).Rows(k).Item(1))
                                ConDesc = DbNullToString(LinCon.Tables(0).Rows(k).Item(2))
                                If Concode = SIContributionCode Then
                                    SIConTotal = SIConTotal + ConValue
                                End If
                                Exit For
                            End If
                        Next
                        TotalC = TotalC + ConValue
                        r(Me.Column_CV1 + Cc) = Format(ConValue, "0.00")
                        ChangeColumnName(ConDesc, Column_CV1 + Cc, "C")
                        Cc = Cc + 2
                    Next
                    r(Column_CVTotal) = Format(TotalC, "0.00")
                End If
                r(Column_CompanyCost) = Format(TotalE + TotalC, "0.00")
                r(Column_SITotal) = Format((SIConTotal + SIDedTotal), "0.00")
                If Not YTDReport Then
                    r(Column_ChequeNo) = Reference
                Else
                    r(Column_ChequeNo) = StartDate
                End If


                Dt1.Rows.Add(r)
            Next
        End If

        If IncludeTotals Then
            Dim Total As Double = 0
            Dim AU As Double = 0
            Dim NetSal As Double = 0
            Dim TE As Double = 0
            Dim TD As Double = 0
            Dim TC As Double = 0
            Dim CCost As Double = 0
            Dim SICost As Double = 0
            Dim TotalOT1 As Double = 0
            Dim TotalOT2 As Double = 0
            Dim TotalOT3 As Double = 0
            Dim TotalSal1 As Double = 0
            Dim TotalSal2 As Double = 0

            Dim TotalSectors As Double = 0
            Dim totaldutyhours As Double = 0
            Dim totalflighthours As Double = 0
            Dim totalcommission As Double = 0
            Dim totalOverlay As Double = 0
            Dim TotalTo As Double = 0

            Dim CNo As String

            If CheckDataSet(MyDs) Then
                If Not YTDReport Then
                    '********************************************************************
                    Dim Rempty As DataRow = Dt1.NewRow()
                    Dt1.Rows.Add(Rempty)
                    '********************************************************************

                    Dim r As DataRow = Dt1.NewRow()
                    r(Me.Column_EmpCode) = "TOTALS (" & TotalEmp & ")"
                    r(Me.Column_EmpName) = Per.Code & " - " & Per.DescriptionL

                    C1 = 0
                    For k = 0 To 14
                        Total = 0
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EV1 + C1))
                            End If
                        Next
                        '********************************************************************
                        r(Me.Column_E1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_E1 + C1))
                        '********************************************************************
                        r(Me.Column_EV1 + C1) = Total
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        Total = 0
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV1 + C1))
                            End If
                        Next
                        '********************************************************************
                        r(Me.Column_D1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_D1 + C1))
                        '********************************************************************
                        r(Me.Column_DV1 + C1) = Total
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        Total = 0
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CV1 + C1))
                            End If
                        Next
                        '********************************************************************
                        r(Me.Column_C1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_C1 + C1))
                        '********************************************************************
                        r(Me.Column_CV1 + C1) = Total
                        C1 = C1 + 2
                    Next

                    AU = 0
                    NetSal = 0
                    TE = 0
                    TD = 0
                    TC = 0
                    CCost = 0
                    SICost = 0
                    TotalOT1 = 0
                    TotalOT2 = 0
                    TotalSal1 = 0
                    TotalSal2 = 0

                    TotalSectors = 0
                    totaldutyhours = 0
                    totalflighthours = 0
                    totalcommission = 0
                    totalOverlay = 0
                    TotalTo = 0

                    TotalTo = 0

                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
                        If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                            AU = AU + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
                            NetSal = NetSal + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_NetSalary))
                            TE = TE + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EVTotal))
                            TD = TD + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DVTotal))
                            TC = TC + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CVTotal))
                            CCost = CCost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                            SICost = SICost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SITotal))
                            TotalOT1 = TotalOT1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                            TotalOT2 = TotalOT2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime2))
                            TotalOT3 = TotalOT3 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime3))
                            TotalSal1 = TotalSal1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary1))
                            TotalSal2 = TotalSal2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary2))

                            TotalSectors = TotalSectors + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_sectors))
                            totaldutyhours = totaldutyhours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_dutyhours))
                            totalflighthours = totalflighthours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_flighthours))
                            totalcommission = totalcommission + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_commission))
                            totalOverlay = totalOverlay + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverLay))
                            TotalTo = TotalTo + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        End If

                    Next

                    r(Me.Column_ActualUnits) = Format(AU, "0.00")
                    r(Me.Column_NetSalary) = Format(NetSal, "0.00")
                    r(Me.Column_EVTotal) = Format(TE, "0.00")
                    r(Me.Column_DVTotal) = Format(TD, "0.00")
                    r(Me.Column_CVTotal) = Format(TC, "0.00")
                    r(Me.Column_CompanyCost) = Format(CCost, "0.00")
                    r(Me.Column_SITotal) = Format(SICost, "0.00")
                    r(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                    r(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                    r(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
                    r(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                    r(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                    r(Me.Column_sectors) = Format(TotalSectors, "0.00")
                    r(Me.Column_dutyhours) = Format(totaldutyhours, "0.00")
                    r(Me.Column_flighthours) = Format(totalflighthours, "0.00")
                    r(Me.Column_commission) = Format(totalcommission, "0.00")
                    r(Me.Column_OverLay) = Format(totalOverlay, "0.00")
                    r(Me.Column_AnalysisCode) = ""
                    r(Me.Column_Position) = ""
                    r(Me.Column_DOE) = ""
                    r(Me.Column_TimeOff) = Format(TotalTo, "0.00")


                    r(Column_AL_Code1) = ""
                    r(Column_AL_Code2) = ""
                    r(Column_AL_Code3) = ""
                    r(Column_AL_Code4) = ""
                    r(Column_AL_Code5) = ""

                    r(Column_AL_Desc1) = ""
                    r(Column_AL_Desc2) = ""
                    r(Column_AL_Desc3) = ""
                    r(Column_AL_Desc4) = ""
                    r(Column_AL_Desc5) = ""

                    r(Column_TermDate) = ""
                    r(Column_SINumber) = ""

                    r(Column_BankBenName) = ""
                    r(Column_ComBank) = ""
                    r(Column_DOB) = ""
                    r(Column_Identity) = ""
                    r(Column_TIC) = ""
                    r(Column_Address) = ""


                    Dt1.Rows.Add(r)


                    Dim rx As DataRow = Dt1.NewRow()

                    '********************************************************************
                    Dt1.Rows.Add(rx)
                    '********************************************************************
                    Application.DoEvents()
                    Me.lblStatus.Text = "Please wait Calcultating Totals " & i
                End If
            End If
        End If



        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrepareReport_Differences1_OLD(ByVal PreviousYear As Boolean)

        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDsDif.Tables(0).Rows.Clear()


        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeaderFrom As DataSet
        Dim DsHeaderTo As DataSet
        Dim DsEmp As DataSet


        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String





        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)


        Dim PrevPeriodCode As String
        Dim PrevPeriodYear As String
        Dim PrevPeriodGroup As String
        Dim PerGrp As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        PrevPeriodYear = (CInt(PerGrp.Year) - 1).ToString
        PrevPeriodCode = PrevPeriodYear & "12"
        PrevPeriodGroup = Replace(PerGrp.Code, PerGrp.Year, "")
        PrevPeriodGroup = PrevPeriodYear & PrevPeriodGroup

        If PreviousYear Then
            PerFrom = New cPrMsPeriodCodes(PrevPeriodCode, PrevPeriodGroup)
        End If








        Dim SICategory As String
        SICategory = Me.txtSICategory.Text


        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text



        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False
        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If

        Dim GenAnal1 As String
        GenAnal1 = Me.txtGenAnal1.Text

        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If
        Dim BankCodeEmp As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCodeEmp = "ALL"
        Else
            BankCodeEmp = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If
        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If
        DsHeaderFrom = Global1.Business.GetAllTrxnHeaderForPeriod(PerFrom, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)
        DsHeaderTo = Global1.Business.GetAllTrxnHeaderForPeriod(PerTo, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)


        Dim HDRIdFrom As Integer
        Dim HDRIdTo As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Dim EmpCode2 As String


        Dim Units_F As Double
        Dim Units_T As Double
        Dim Units_D As Double
        Dim NetSal_F As Double
        Dim NetSal_T As Double
        Dim NetSal_D As Double
        Dim TotalE_F As Double
        Dim TotalE_T As Double
        Dim TotalE_D As Double
        Dim TotalD_F As Double
        Dim TotalD_T As Double
        Dim TotalD_D As Double
        Dim TotalC_F As Double
        Dim TotalC_T As Double
        Dim TotalC_D As Double
        Dim TotalCCost_F As Double
        Dim TotalCCost_T As Double
        Dim TotalCCost_D As Double
        Dim Bonus_F As Double
        Dim Bonus_T As Double

        Dim RecBonus_F As Double
        Dim RecBonus_T As Double

        Dim Bonus_D As Double

        Dim BonS_F As Double
        Dim BonS_T As Double
        Dim BonS_D As Double

        Dim MS_F As Double
        Dim MS_T As Double
        Dim MS_D As Double

        Dim BIK_F As Double
        Dim BIK_T As Double
        Dim BIK_D As Double


        Dim TUnits_F As Double
        Dim TUnits_T As Double
        Dim TUnits_D As Double
        Dim TNetSal_F As Double
        Dim TNetSal_T As Double
        Dim TNetSal_D As Double
        Dim TTotalE_F As Double
        Dim TTotalE_T As Double
        Dim TTotalE_D As Double
        Dim TTotalD_F As Double
        Dim TTotalD_T As Double
        Dim TTotalD_D As Double
        Dim TTotalC_F As Double
        Dim TTotalC_T As Double
        Dim TTotalC_D As Double
        Dim TTotalCCost_F As Double
        Dim TTotalCCost_T As Double
        Dim TTotalCCost_D As Double
        Dim TBonus_F As Double
        Dim TBonus_T As Double
        Dim TBonus_D As Double

        Dim TBonS_F As Double
        Dim TBonS_T As Double
        Dim TBonS_D As Double

        Dim TMS_F As Double
        Dim TMS_T As Double
        Dim TMS_D As Double

        Dim TBIK_F As Double
        Dim TBIK_T As Double
        Dim TBIK_D As Double


        Dim BonusErnCode1 As String = "E11"
        Dim BonusErnCode2 As String = "E37"
        Dim BonusErnCode3 As String = "E38"

        Dim RecBonusErnCode As String = "E30"

        Dim BIKErnType As String = "BK"
        Dim RecBIKernType As String = "BR"

        Dim Anal2Code As String
        Dim PosCode As String




        If CheckDataSet(DsHeaderFrom) And CheckDataSet(DsHeaderTo) Then
            Dim totalFrom As Integer = DsHeaderFrom.Tables(0).Rows.Count - 1
            Dim totalTo As Integer = DsHeaderTo.Tables(0).Rows.Count - 1
            'If totalFrom >= totalTo Then
            '    For i = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
            '        Units_F = 0
            '        Units_T = 0
            '        Units_D = 0
            '        NetSal_F = 0
            '        NetSal_T = 0
            '        NetSal_D = 0
            '        TotalE_F = 0
            '        TotalE_T = 0
            '        TotalE_D = 0
            '        TotalD_F = 0
            '        TotalD_T = 0
            '        TotalD_D = 0
            '        TotalC_F = 0
            '        TotalC_T = 0
            '        TotalC_D = 0
            '        TotalCCost_F = 0
            '        TotalCCost_T = 0
            '        TotalCCost_D = 0
            '        Bonus_F = 0
            '        Bonus_T = 0
            '        Bonus_D = 0

            '        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(i).Item(0))
            '        EmpCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(1))
            '        EmpName = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(2))
            '        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(5))
            '        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(3))
            '        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(23))
            '        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(24))
            '        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(25))
            '        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)
            '        'Bonus_F = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdFrom)
            '        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode, HDRIdFrom)

            '        Anal2Code = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(18))
            '        PosCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(i).Item(22))
            '        For k = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
            '            EmpCode2 = DbNullToString(DsHeaderTo.Tables(0).Rows(k).Item(1))
            '            If EmpCode2 = EmpCode Then
            '                HDRIdTo = DbNullToInt(DsHeaderTo.Tables(0).Rows(k).Item(0))
            '                Units_T = DbNullToString(DsHeaderTo.Tables(0).Rows(k).Item(5))
            '                NetSal_T = DbNullToString(DsHeaderTo.Tables(0).Rows(k).Item(3))
            '                TotalE_T = DbNullToString(DsHeaderTo.Tables(0).Rows(k).Item(23))
            '                TotalD_T = DbNullToString(DsHeaderTo.Tables(0).Rows(k).Item(24))
            '                TotalC_T = DbNullToString(DsHeaderTo.Tables(0).Rows(k).Item(25))
            '                TotalCCost_T = RoundMe3(TotalE_T + TotalC_T, 2)
            '                'Bonus_T = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdTo)
            '                Bonus_T = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode, HDRIdTo)
            '                Exit For
            '            End If
            '        Next

            '        Units_D = RoundMe3(Units_T - Units_F, 2)
            '        NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
            '        TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
            '        TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
            '        TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
            '        TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
            '        Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

            '        Dim r As DataRow = DtDif.NewRow()
            '        r(0) = PerFrom.Code
            '        r(1) = PerFrom.DescriptionL
            '        r(2) = PerTo.Code
            '        r(3) = PerTo.DescriptionL

            '        r(4) = EmpCode
            '        r(5) = EmpName

            '        r(6) = Units_F
            '        r(7) = Units_T
            '        r(8) = Units_D

            '        r(9) = NetSal_F
            '        r(10) = NetSal_T
            '        r(11) = NetSal_D

            '        r(12) = TotalE_F
            '        r(13) = TotalE_T
            '        r(14) = TotalE_D

            '        r(15) = TotalD_F
            '        r(16) = TotalD_T
            '        r(17) = TotalD_D

            '        r(18) = TotalC_F
            '        r(19) = TotalC_T
            '        r(20) = TotalC_D

            '        r(21) = TotalCCost_F
            '        r(22) = TotalCCost_T
            '        r(23) = TotalCCost_D

            '        r(24) = Bonus_F
            '        r(25) = Bonus_T
            '        r(26) = Bonus_D
            '        Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
            '        Dim Pos As New cPrAnEmployeePositions(PosCode)
            '        r(27) = Anl2.DescriptionS
            '        r(28) = Pos.DescriptionS


            '        DtDif.Rows.Add(r)
            '        '''''''''' for second report
            '        'Dim r2 As DataRow = DtDif2.NewRow()

            '        'r2(0) = EmpCode
            '        'r2(1) = EmpName

            '        'r2(2) = TotalE_F
            '        'r2(3) = TotalE_T
            '        'r2(4) = TotalE_D

            '        'r2(4) = TotalCCost_F
            '        'r2(5) = TotalCCost_T
            '        'r2(6) = TotalCCost_D

            '        'DtDif2.Rows.Add(r2)
            '        ''----------------------------

            '        TUnits_F = TUnits_F + Units_F
            '        TUnits_T = TUnits_T + Units_T
            '        TUnits_D = TUnits_D + Units_D
            '        TNetSal_F = TNetSal_F + NetSal_F
            '        TNetSal_T = TNetSal_T + NetSal_T
            '        TNetSal_D = TNetSal_D + NetSal_D
            '        TTotalE_F = TTotalE_F + TotalE_F
            '        TTotalE_T = TTotalE_T + TotalE_T
            '        TTotalE_D = TTotalE_D + TotalE_D
            '        TTotalD_F = TTotalD_F + TotalD_F
            '        TTotalD_T = TTotalD_T + TotalD_T
            '        TTotalD_D = TTotalD_D + TotalD_D
            '        TTotalC_F = TTotalC_F + TotalC_F
            '        TTotalC_T = TTotalC_T + TotalC_T
            '        TTotalC_D = TTotalC_D + TotalC_D
            '        TTotalCCost_F = TTotalCCost_F + TotalCCost_F
            '        TTotalCCost_T = TTotalCCost_T + TotalCCost_T
            '        TTotalCCost_D = TTotalCCost_D + TotalCCost_D
            '        TBonus_F = TBonus_F + Bonus_F
            '        TBonus_T = TBonus_T + Bonus_T
            '        TBonus_D = TBonus_D + Bonus_D


            '    Next

            '    Dim rt As DataRow = DtDif.NewRow()
            '    rt(0) = PerFrom.Code
            '    rt(1) = PerFrom.DescriptionL
            '    rt(2) = PerTo.Code
            '    rt(3) = PerTo.DescriptionL

            '    rt(4) = ""
            '    rt(5) = "TOTALS"

            '    rt(6) = TUnits_F
            '    rt(7) = TUnits_T
            '    rt(8) = TUnits_D

            '    rt(9) = TNetSal_F
            '    rt(10) = TNetSal_T
            '    rt(11) = TNetSal_D

            '    rt(12) = TTotalE_F
            '    rt(13) = TTotalE_T
            '    rt(14) = TTotalE_D

            '    rt(15) = TTotalD_F
            '    rt(16) = TTotalD_T
            '    rt(17) = TTotalD_D

            '    rt(18) = TTotalC_F
            '    rt(19) = TTotalC_T
            '    rt(20) = TTotalC_D

            '    rt(21) = TTotalCCost_F
            '    rt(22) = TTotalCCost_T
            '    rt(23) = TTotalCCost_D

            '    rt(24) = TBonus_F
            '    rt(25) = TBonus_T
            '    rt(26) = TBonus_D
            '    rt(27) = ""
            '    rt(28) = ""
            '    DtDif.Rows.Add(rt)

            '    '''''''''' for second report
            '    'Dim rt2 As DataRow = DtDif2.NewRow()

            '    'rt2(0) = ""
            '    'rt2(1) = "Totals"

            '    'rt2(2) = TTotalE_F
            '    'rt2(3) = TTotalE_T
            '    'rt2(4) = TTotalE_D

            '    'rt2(4) = TTotalCCost_F
            '    'rt2(5) = TTotalCCost_T
            '    'rt2(6) = TTotalCCost_D

            '    'DtDif2.Rows.Add(rt2)
            '    ''----------------------------


            'Else
            For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                Units_F = 0
                Units_T = 0
                Units_D = 0
                NetSal_F = 0
                NetSal_T = 0
                NetSal_D = 0
                TotalE_F = 0
                TotalE_T = 0
                TotalE_D = 0
                TotalD_F = 0
                TotalD_T = 0
                TotalD_D = 0
                TotalC_F = 0
                TotalC_T = 0
                TotalC_D = 0
                TotalCCost_F = 0
                TotalCCost_T = 0
                TotalCCost_D = 0
                Bonus_F = 0
                Bonus_T = 0
                Bonus_D = 0
                RecBonus_T = 0
                RecBonus_F = 0

                BonS_F = 0
                BonS_T = 0
                BonS_D = 0

                MS_F = 0
                MS_T = 0
                MS_D = 0

                EmpCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(2))
                HDRIdTo = DbNullToInt(DsHeaderTo.Tables(0).Rows(i).Item(0))
                Units_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(5))
                NetSal_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(3))
                TotalE_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(23))
                TotalD_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(24))
                TotalC_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(25))

                BonS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(26))
                MS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(4))

                TotalCCost_T = RoundMe3(TotalE_T + TotalC_T, 2)
                'Bonus_T = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdTo)
                Bonus_T = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdTo)

                RecBonus_T = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdTo)
                Bonus_T = Bonus_T + RecBonus_T



                BIK_T = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdTo)
                BIK_T = BIK_T + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdTo)


                Anal2Code = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(18))
                PosCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(22))

                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode2 = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    If EmpCode2 = EmpCode Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))

                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))

                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))


                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)
                        'Bonus_F = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdFrom)
                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)





                        Exit For
                    End If
                Next

                Units_D = RoundMe3(Units_T - Units_F, 2)
                NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                MS_D = RoundMe3(MS_T - MS_F, 2)
                BIK_D = RoundMe3(BIK_T - BIK_F, 2)


                Dim r As DataRow = DtDif.NewRow()
                r(0) = PerFrom.Code
                r(1) = PerFrom.DescriptionL
                r(2) = PerTo.Code
                r(3) = PerTo.DescriptionL

                r(4) = EmpCode
                r(5) = EmpName

                r(6) = Units_F
                r(7) = Units_T
                r(8) = Units_D

                r(9) = NetSal_F
                r(10) = NetSal_T
                r(11) = NetSal_D

                r(12) = TotalE_F
                r(13) = TotalE_T
                r(14) = TotalE_D

                r(15) = TotalD_F
                r(16) = TotalD_T
                r(17) = TotalD_D

                r(18) = TotalC_F
                r(19) = TotalC_T
                r(20) = TotalC_D

                r(21) = TotalCCost_F
                r(22) = TotalCCost_T
                r(23) = TotalCCost_D

                r(24) = Bonus_F
                r(25) = Bonus_T
                r(26) = Bonus_D

                r(29) = BonS_F
                r(30) = BonS_T
                r(31) = BonS_D

                r(32) = MS_F
                r(33) = MS_T
                r(34) = MS_D

                r(35) = BIK_F
                r(36) = BIK_T
                r(37) = BIK_D

                r(38) = BIK_F + TotalCCost_F
                r(39) = BIK_T + TotalCCost_T
                r(40) = BIK_D + TotalCCost_D



                Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                Dim Pos As New cPrAnEmployeePositions(PosCode)
                r(27) = Anl2.DescriptionS
                r(28) = Pos.DescriptionL

                DtDif.Rows.Add(r)

                '''''''''' for second report
                'Dim r2 As DataRow = DtDif2.NewRow()

                'r2(0) = EmpCode
                'r2(1) = EmpName

                'r2(2) = TotalE_F
                'r2(3) = TotalE_T
                'r2(4) = TotalE_D

                'r2(4) = TotalCCost_F
                'r2(5) = TotalCCost_T
                'r2(6) = TotalCCost_D

                'DtDif2.Rows.Add(r2)
                ''----------------------------


                TUnits_F = TUnits_F + Units_F
                TUnits_T = TUnits_T + Units_T
                TUnits_D = TUnits_D + Units_D
                TNetSal_F = TNetSal_F + NetSal_F
                TNetSal_T = TNetSal_T + NetSal_T
                TNetSal_D = TNetSal_D + NetSal_D
                TTotalE_F = TTotalE_F + TotalE_F
                TTotalE_T = TTotalE_T + TotalE_T
                TTotalE_D = TTotalE_D + TotalE_D
                TTotalD_F = TTotalD_F + TotalD_F
                TTotalD_T = TTotalD_T + TotalD_T
                TTotalD_D = TTotalD_D + TotalD_D
                TTotalC_F = TTotalC_F + TotalC_F
                TTotalC_T = TTotalC_T + TotalC_T
                TTotalC_D = TTotalC_D + TotalC_D

                TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                TBonus_F = TBonus_F + Bonus_F
                TBonus_T = TBonus_T + Bonus_T
                TBonus_D = TBonus_D + Bonus_D


                TBonS_F = TBonS_F + BonS_F
                TBonS_T = TBonS_T + BonS_T
                TBonS_D = TBonS_D + BonS_D

                TMS_F = TMS_F + MS_F
                TMS_T = TMS_T + MS_T
                TMS_D = TMS_D + MS_D

                TBIK_F = TBIK_F + BIK_F
                TBIK_T = TBIK_T + BIK_T
                TBIK_D = TBIK_D + BIK_D

            Next

            Dim rt As DataRow = DtDif.NewRow()
            rt(0) = PerFrom.Code
            rt(1) = PerFrom.DescriptionL
            rt(2) = PerTo.Code
            rt(3) = PerTo.DescriptionL

            rt(4) = ""
            rt(5) = "TOTALS"

            rt(6) = TUnits_F
            rt(7) = TUnits_T
            rt(8) = TUnits_D

            rt(9) = TNetSal_F
            rt(10) = TNetSal_T
            rt(11) = TNetSal_D

            rt(12) = TTotalE_F
            rt(13) = TTotalE_T
            rt(14) = TTotalE_D

            rt(15) = TTotalD_F
            rt(16) = TTotalD_T
            rt(17) = TTotalD_D

            rt(18) = TTotalC_F
            rt(19) = TTotalC_T
            rt(20) = TTotalC_D

            rt(21) = TTotalCCost_F
            rt(22) = TTotalCCost_T
            rt(23) = TTotalCCost_D

            rt(24) = TBonus_F
            rt(25) = TBonus_T
            rt(26) = TBonus_D

            rt(27) = ""
            rt(28) = ""

            rt(29) = TBonS_F
            rt(30) = TBonS_T
            rt(31) = TBonS_D

            rt(32) = TMS_F
            rt(33) = TMS_T
            rt(34) = TMS_D

            rt(35) = TBIK_F
            rt(36) = TBIK_T
            rt(37) = TBIK_D

            rt(38) = TBIK_F + TTotalCCost_F
            rt(39) = TBIK_T + TTotalCCost_T
            rt(40) = TBIK_D + TTotalCCost_D

            DtDif.Rows.Add(rt)

            ''''''''' for second report
            'Dim rt2 As DataRow = DtDif2.NewRow()

            'rt2(0) = ""
            'rt2(1) = "Totals"

            'rt2(2) = TTotalE_F
            'rt2(3) = TTotalE_T
            'rt2(4) = TTotalE_D

            'rt2(4) = TTotalCCost_F
            'rt2(5) = TTotalCCost_T
            'rt2(6) = TTotalCCost_D

            'DtDif2.Rows.Add(rt2)
            ''----------------------------


        End If
        'End If




        Me.Cursor = Cursors.Default
        'Dim F As New FrmDifReport
        'F.Ds = MyDsDif
        'F.Show()

    End Sub
    Private Sub PrepareReport_Differences3(ByVal PreviousYear As Boolean, ByVal AddHRCode As Boolean)

        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDsDif.Tables(0).Rows.Clear()


        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeaderFrom As DataSet
        Dim DsHeaderTo As DataSet
        Dim DsEmp As DataSet


        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String





        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)


        Dim PrevPeriodCode As String
        Dim PrevPeriodYear As String
        Dim PrevPeriodGroup As String
        Dim PerGrp As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        PrevPeriodYear = (CInt(PerGrp.Year) - 1).ToString
        PrevPeriodCode = PrevPeriodYear & "12"
        PrevPeriodGroup = Replace(PerGrp.Code, PerGrp.Year, "")
        PrevPeriodGroup = PrevPeriodYear & PrevPeriodGroup

        If PreviousYear Then
            PerFrom = New cPrMsPeriodCodes(PrevPeriodCode, PrevPeriodGroup)
        End If


        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text



        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim ewallet As Boolean = False
        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBWallet.CheckState = CheckState.Checked Then
            ewallet = True
        End If

        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim BankCodeEmp As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCodeEmp = "ALL"
        Else
            BankCodeEmp = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim GenAnal1 As String
        GenAnal1 = Me.txtGenAnal1.Text

        Dim SICategory As String
        SICategory = Me.txtSICategory.Text

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If
        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        DsHeaderFrom = Global1.Business.GetAllTrxnHeaderForPeriod(PerFrom, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, ewallet)
        DsHeaderTo = Global1.Business.GetAllTrxnHeaderForPeriod(PerTo, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, ewallet)

        Dim HDRIdFrom As Integer
        Dim HDRIdTo As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Dim EmpCode2 As String


        Dim Units_F As Double
        Dim Units_T As Double
        Dim Units_D As Double
        Dim NetSal_F As Double
        Dim NetSal_T As Double
        Dim NetSal_D As Double
        Dim TotalE_F As Double
        Dim TotalE_T As Double
        Dim TotalE_D As Double
        Dim TotalD_F As Double
        Dim TotalD_T As Double
        Dim TotalD_D As Double
        Dim TotalC_F As Double
        Dim TotalC_T As Double
        Dim TotalC_D As Double
        Dim TotalCCost_F As Double
        Dim TotalCCost_T As Double
        Dim TotalCCost_D As Double
        Dim Bonus_F As Double
        Dim Bonus_T As Double

        Dim RecBonus_F As Double
        Dim RecBonus_T As Double

        Dim Bonus_D As Double

        Dim BonS_F As Double
        Dim BonS_T As Double
        Dim BonS_D As Double

        Dim MS_F As Double
        Dim MS_T As Double
        Dim MS_D As Double

        Dim BIK_F As Double
        Dim BIK_T As Double
        Dim BIK_D As Double

        Dim Fine_F As Double
        Dim Fine_T As Double
        Dim Fine_D As Double


        Dim TUnits_F As Double
        Dim TUnits_T As Double
        Dim TUnits_D As Double
        Dim TNetSal_F As Double
        Dim TNetSal_T As Double
        Dim TNetSal_D As Double
        Dim TTotalE_F As Double
        Dim TTotalE_T As Double
        Dim TTotalE_D As Double
        Dim TTotalD_F As Double
        Dim TTotalD_T As Double
        Dim TTotalD_D As Double
        Dim TTotalC_F As Double
        Dim TTotalC_T As Double
        Dim TTotalC_D As Double
        Dim TTotalCCost_F As Double
        Dim TTotalCCost_T As Double
        Dim TTotalCCost_D As Double
        Dim TBonus_F As Double
        Dim TBonus_T As Double
        Dim TBonus_D As Double

        Dim TBonS_F As Double
        Dim TBonS_T As Double
        Dim TBonS_D As Double

        Dim TMS_F As Double
        Dim TMS_T As Double
        Dim TMS_D As Double

        Dim TBIK_F As Double
        Dim TBIK_T As Double
        Dim TBIK_D As Double


        Dim TFine_F As Double
        Dim TFine_T As Double
        Dim TFine_D As Double


        Dim BonusErnCode1 As String = "E11"
        Dim BonusErnCode2 As String = "E37"
        Dim BonusErnCode3 As String = "E38"

        Dim RecBonusErnCode As String = "E30"

        Dim FineErnCode As String

        Dim BIKErnType As String = "BK"
        Dim RecBIKernType As String = "BR"

        Dim Anal2Code As String
        Dim Anal3Code As String

        Dim PosCode As String

        Dim FineType As String = "FN"
        Dim HRCode As String = ""



        If CheckDataSet(DsHeaderFrom) And CheckDataSet(DsHeaderTo) Then
            Dim totalFrom As Integer = DsHeaderFrom.Tables(0).Rows.Count - 1
            Dim totalTo As Integer = DsHeaderTo.Tables(0).Rows.Count - 1

            For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                Units_F = 0
                Units_T = 0
                Units_D = 0
                NetSal_F = 0
                NetSal_T = 0
                NetSal_D = 0
                TotalE_F = 0
                TotalE_T = 0
                TotalE_D = 0
                TotalD_F = 0
                TotalD_T = 0
                TotalD_D = 0
                TotalC_F = 0
                TotalC_T = 0
                TotalC_D = 0
                TotalCCost_F = 0
                TotalCCost_T = 0
                TotalCCost_D = 0
                Bonus_F = 0
                Bonus_T = 0
                Bonus_D = 0
                RecBonus_T = 0
                RecBonus_F = 0

                BonS_F = 0
                BonS_T = 0
                BonS_D = 0

                MS_F = 0
                MS_T = 0
                MS_D = 0

                BIK_F = 0
                BIK_T = 0
                BIK_D = 0

                Fine_F = 0
                Fine_T = 0
                Fine_D = 0

                EmpCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(2))
                HDRIdTo = DbNullToInt(DsHeaderTo.Tables(0).Rows(i).Item(0))
                Units_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(5))
                NetSal_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(3))
                TotalE_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(23))
                TotalD_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(24))
                TotalC_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(25))

                BonS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(26))
                MS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(4))

                TotalCCost_T = RoundMe3(TotalE_T + TotalC_T, 2)
                'Bonus_T = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdTo)
                Bonus_T = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdTo)

                'Fine_T = Fine_T + Global1.Business.GetTrxLineEarningOfCODE(FineErnCode, HDRIdTo)
                Fine_T = Fine_T + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdTo)


                RecBonus_T = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdTo)
                Bonus_T = Bonus_T + RecBonus_T



                BIK_T = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdTo)
                BIK_T = BIK_T + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdTo)


                Anal2Code = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(18))
                Anal3Code = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(39))

                PosCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(22))
                HRCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(58))


                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode2 = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    If EmpCode2 = EmpCode Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))

                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))

                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))


                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)
                        'Bonus_F = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdFrom)
                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        'Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfCODE(FineErnCode, HDRIdFrom)
                        Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)

                        Exit For
                    End If
                Next

                Units_D = RoundMe3(Units_T - Units_F, 2)
                NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                MS_D = RoundMe3(MS_T - MS_F, 2)
                BIK_D = RoundMe3(BIK_T - BIK_F, 2)

                Fine_D = RoundMe3(Fine_T - Fine_F, 2)


                Dim r As DataRow = DtDif.NewRow()
                r(0) = PerFrom.Code
                r(1) = PerFrom.DescriptionL
                r(2) = PerTo.Code
                r(3) = PerTo.DescriptionL

                r(4) = EmpCode
                'If AddHRCode Then
                '    r(4) = EmpCode & " - " & HRCode
                'End If
                r(5) = EmpName

                r(6) = Units_F
                r(7) = Units_T
                r(8) = Units_D

                r(9) = NetSal_F
                r(10) = NetSal_T
                r(11) = NetSal_D

                r(12) = TotalE_F
                r(13) = TotalE_T
                r(14) = TotalE_D

                r(15) = TotalD_F
                r(16) = TotalD_T
                r(17) = TotalD_D

                r(18) = TotalC_F
                r(19) = TotalC_T
                r(20) = TotalC_D

                r(21) = TotalCCost_F
                r(22) = TotalCCost_T
                r(23) = TotalCCost_D

                r(24) = Bonus_F
                r(25) = Bonus_T
                r(26) = Bonus_D

                r(29) = BonS_F
                r(30) = BonS_T
                r(31) = BonS_D

                r(32) = MS_F
                r(33) = MS_T
                r(34) = MS_D

                r(35) = BIK_F
                r(36) = BIK_T
                r(37) = BIK_D

                r(38) = BIK_F + TotalCCost_F
                r(39) = BIK_T + TotalCCost_T
                r(40) = BIK_D + TotalCCost_D

                r(41) = Fine_F
                r(42) = Fine_T
                r(43) = Fine_D
                If AddHRCode Then
                    r(44) = HRCode
                Else
                    r(44) = ""
                End If




                Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                r(27) = Anl2.DescriptionS
                If param_variance25showanl3 Then
                    Dim Anl3 As New cPrAnEmployeeAnalysis3(Anal3Code)
                    r(27) = Anl3.DescriptionS

                End If

                Dim Pos As New cPrAnEmployeePositions(PosCode)
                r(28) = Pos.DescriptionL

                DtDif.Rows.Add(r)


                TUnits_F = TUnits_F + Units_F
                TUnits_T = TUnits_T + Units_T
                TUnits_D = TUnits_D + Units_D
                TNetSal_F = TNetSal_F + NetSal_F
                TNetSal_T = TNetSal_T + NetSal_T
                TNetSal_D = TNetSal_D + NetSal_D
                TTotalE_F = TTotalE_F + TotalE_F
                TTotalE_T = TTotalE_T + TotalE_T
                TTotalE_D = TTotalE_D + TotalE_D
                TTotalD_F = TTotalD_F + TotalD_F
                TTotalD_T = TTotalD_T + TotalD_T
                TTotalD_D = TTotalD_D + TotalD_D
                TTotalC_F = TTotalC_F + TotalC_F
                TTotalC_T = TTotalC_T + TotalC_T
                TTotalC_D = TTotalC_D + TotalC_D

                TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                TBonus_F = TBonus_F + Bonus_F
                TBonus_T = TBonus_T + Bonus_T
                TBonus_D = TBonus_D + Bonus_D


                TBonS_F = TBonS_F + BonS_F
                TBonS_T = TBonS_T + BonS_T
                TBonS_D = TBonS_D + BonS_D

                TMS_F = TMS_F + MS_F
                TMS_T = TMS_T + MS_T
                TMS_D = TMS_D + MS_D

                TBIK_F = TBIK_F + BIK_F
                TBIK_T = TBIK_T + BIK_T
                TBIK_D = TBIK_D + BIK_D

                TFine_F = TFine_F + Fine_F
                TFine_T = TFine_T + Fine_T
                TFine_D = TFine_D + Fine_D

            Next
            '-----------------------------------------------------------------------------
            ''''''''''                Second RUN               '''''''''''''''''''''''''''

            If CheckDataSet(DsHeaderFrom) Then
                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    Dim found As Boolean = False
                    For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                        EmpCode2 = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                        If EmpCode2 = EmpCode Then
                            found = True
                            Exit For
                        End If
                    Next
                    If found = False Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))
                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))
                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))
                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)

                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        'Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfCODE(FineErnCode, HDRIdFrom)
                        Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)


                        EmpName = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(2))

                        Anal2Code = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(18))
                        Anal3Code = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(39))
                        PosCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(22))
                        HRCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(58))

                        Units_T = 0
                        NetSal_T = 0
                        TotalE_T = 0
                        TotalD_T = 0
                        TotalC_T = 0
                        TotalCCost_T = 0
                        Bonus_T = 0
                        BonS_T = 0
                        MS_T = 0
                        BIK_T = 0

                        Fine_T = 0


                        Units_D = RoundMe3(Units_T - Units_F, 2)
                        NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                        TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                        TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                        TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                        TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                        Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                        BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                        MS_D = RoundMe3(MS_T - MS_F, 2)
                        BIK_D = RoundMe3(BIK_T - BIK_F, 2)
                        Fine_D = RoundMe3(Fine_T - Fine_F, 2)


                        Dim r As DataRow = DtDif.NewRow()
                        r(0) = PerFrom.Code
                        r(1) = PerFrom.DescriptionL
                        r(2) = PerTo.Code
                        r(3) = PerTo.DescriptionL

                        r(4) = EmpCode
                        'If AddHRCode Then
                        '    r(4) = EmpCode & " - " & HRCode
                        'End If
                        r(5) = EmpName


                        r(6) = Units_F
                        r(7) = Units_T
                        r(8) = Units_D

                        r(9) = NetSal_F
                        r(10) = NetSal_T
                        r(11) = NetSal_D

                        r(12) = TotalE_F
                        r(13) = TotalE_T
                        r(14) = TotalE_D

                        r(15) = TotalD_F
                        r(16) = TotalD_T
                        r(17) = TotalD_D

                        r(18) = TotalC_F
                        r(19) = TotalC_T
                        r(20) = TotalC_D

                        r(21) = TotalCCost_F
                        r(22) = TotalCCost_T
                        r(23) = TotalCCost_D

                        r(24) = Bonus_F
                        r(25) = Bonus_T
                        r(26) = Bonus_D

                        r(29) = BonS_F
                        r(30) = BonS_T
                        r(31) = BonS_D

                        r(32) = MS_F
                        r(33) = MS_T
                        r(34) = MS_D

                        r(35) = BIK_F
                        r(36) = BIK_T
                        r(37) = BIK_D

                        r(38) = BIK_F + TotalCCost_F
                        r(39) = BIK_T + TotalCCost_T
                        r(40) = BIK_D + TotalCCost_D

                        r(41) = Fine_F
                        r(42) = Fine_T
                        r(43) = Fine_D
                        If AddHRCode Then
                            r(44) = HRCode
                        Else
                            r(44) = ""
                        End If




                        Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                        r(27) = Anl2.DescriptionS
                        If Global1.param_Variance25showanl3 Then
                            Dim Anl3 As New cPrAnEmployeeAnalysis2(Anal3Code)
                            r(27) = Anl2.DescriptionS
                        End If

                        Dim Pos As New cPrAnEmployeePositions(PosCode)
                        r(27) = Anl2.DescriptionS
                        r(28) = Pos.DescriptionL

                        DtDif.Rows.Add(r)


                        TUnits_F = TUnits_F + Units_F
                        TUnits_T = TUnits_T + Units_T
                        TUnits_D = TUnits_D + Units_D
                        TNetSal_F = TNetSal_F + NetSal_F
                        TNetSal_T = TNetSal_T + NetSal_T
                        TNetSal_D = TNetSal_D + NetSal_D
                        TTotalE_F = TTotalE_F + TotalE_F
                        TTotalE_T = TTotalE_T + TotalE_T
                        TTotalE_D = TTotalE_D + TotalE_D
                        TTotalD_F = TTotalD_F + TotalD_F
                        TTotalD_T = TTotalD_T + TotalD_T
                        TTotalD_D = TTotalD_D + TotalD_D
                        TTotalC_F = TTotalC_F + TotalC_F
                        TTotalC_T = TTotalC_T + TotalC_T
                        TTotalC_D = TTotalC_D + TotalC_D

                        TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                        TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                        TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                        TBonus_F = TBonus_F + Bonus_F
                        TBonus_T = TBonus_T + Bonus_T
                        TBonus_D = TBonus_D + Bonus_D


                        TBonS_F = TBonS_F + BonS_F
                        TBonS_T = TBonS_T + BonS_T
                        TBonS_D = TBonS_D + BonS_D

                        TMS_F = TMS_F + MS_F
                        TMS_T = TMS_T + MS_T
                        TMS_D = TMS_D + MS_D

                        TBIK_F = TBIK_F + BIK_F
                        TBIK_T = TBIK_T + BIK_T
                        TBIK_D = TBIK_D + BIK_D


                        TFine_F = TFine_F + Fine_F
                        TFine_T = TFine_T + Fine_T
                        TFine_D = TFine_D + Fine_D

                    End If

                Next
            End If








            Dim rt As DataRow = DtDif.NewRow()
            rt(0) = PerFrom.Code
            rt(1) = PerFrom.DescriptionL
            rt(2) = PerTo.Code
            rt(3) = PerTo.DescriptionL

            rt(4) = ""
            rt(5) = "TOTALS"

            rt(6) = TUnits_F
            rt(7) = TUnits_T
            rt(8) = TUnits_D

            rt(9) = TNetSal_F
            rt(10) = TNetSal_T
            rt(11) = TNetSal_D

            rt(12) = TTotalE_F
            rt(13) = TTotalE_T
            rt(14) = TTotalE_D

            rt(15) = TTotalD_F
            rt(16) = TTotalD_T
            rt(17) = TTotalD_D

            rt(18) = TTotalC_F
            rt(19) = TTotalC_T
            rt(20) = TTotalC_D

            rt(21) = TTotalCCost_F
            rt(22) = TTotalCCost_T
            rt(23) = TTotalCCost_D

            rt(24) = TBonus_F
            rt(25) = TBonus_T
            rt(26) = TBonus_D

            rt(27) = ""
            rt(28) = ""

            rt(29) = TBonS_F
            rt(30) = TBonS_T
            rt(31) = TBonS_D

            rt(32) = TMS_F
            rt(33) = TMS_T
            rt(34) = TMS_D

            rt(35) = TBIK_F
            rt(36) = TBIK_T
            rt(37) = TBIK_D

            rt(38) = TBIK_F + TTotalCCost_F
            rt(39) = TBIK_T + TTotalCCost_T
            rt(40) = TBIK_D + TTotalCCost_D

            rt(41) = TFine_F
            rt(42) = TFine_T
            rt(43) = TFine_D
            rt(44) = ""


            DtDif.Rows.Add(rt)


        End If
        'End If




        Me.Cursor = Cursors.Default
        'Dim F As New FrmDifReport
        'F.Ds = MyDsDif
        'F.Show()

    End Sub
    Private Sub PrepareReport_Differences4(ByVal PreviousYear As Boolean)

        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDsDif.Tables(0).Rows.Clear()


        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeaderFrom As DataSet
        Dim DsHeaderTo As DataSet
        Dim DsEmp As DataSet


        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String





        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)


        Dim PrevPeriodCode As String
        Dim PrevPeriodYear As String
        Dim PrevPeriodGroup As String
        Dim PerGrp As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        PrevPeriodYear = (CInt(PerGrp.Year) - 1).ToString
        PrevPeriodCode = PrevPeriodYear & "12"
        PrevPeriodGroup = Replace(PerGrp.Code, PerGrp.Year, "")
        PrevPeriodGroup = PrevPeriodYear & PrevPeriodGroup

        If PreviousYear Then
            PerFrom = New cPrMsPeriodCodes(PrevPeriodCode, PrevPeriodGroup)
        End If


        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text



        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False

        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If

        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim BankCodeEmp As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCodeEmp = "ALL"
        Else
            BankCodeEmp = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim GenAnal1 As String
        GenAnal1 = Me.txtGenAnal1.Text

        Dim SICategory As String
        SICategory = Me.txtSICategory.Text

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If
        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        DsHeaderFrom = Global1.Business.GetAllTrxnHeaderForPeriod(PerFrom, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)
        DsHeaderTo = Global1.Business.GetAllTrxnHeaderForPeriod(PerTo, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)


        Dim HDRIdFrom As Integer
        Dim HDRIdTo As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Dim EmpCode2 As String


        Dim Units_F As Double
        Dim Units_T As Double
        Dim Units_D As Double
        Dim NetSal_F As Double
        Dim NetSal_T As Double
        Dim NetSal_D As Double
        Dim TotalE_F As Double
        Dim TotalE_T As Double
        Dim TotalE_D As Double
        Dim TotalD_F As Double
        Dim TotalD_T As Double
        Dim TotalD_D As Double
        Dim TotalC_F As Double
        Dim TotalC_T As Double
        Dim TotalC_D As Double
        Dim TotalCCost_F As Double
        Dim TotalCCost_T As Double
        Dim TotalCCost_D As Double
        Dim Bonus_F As Double
        Dim Bonus_T As Double

        Dim RecBonus_F As Double
        Dim RecBonus_T As Double

        Dim Bonus_D As Double

        Dim BonS_F As Double
        Dim BonS_T As Double
        Dim BonS_D As Double

        Dim MS_F As Double
        Dim MS_T As Double
        Dim MS_D As Double

        Dim BIK_F As Double
        Dim BIK_T As Double
        Dim BIK_D As Double

        Dim Fine_F As Double
        Dim Fine_T As Double
        Dim Fine_D As Double


        Dim TUnits_F As Double
        Dim TUnits_T As Double
        Dim TUnits_D As Double
        Dim TNetSal_F As Double
        Dim TNetSal_T As Double
        Dim TNetSal_D As Double
        Dim TTotalE_F As Double
        Dim TTotalE_T As Double
        Dim TTotalE_D As Double
        Dim TTotalD_F As Double
        Dim TTotalD_T As Double
        Dim TTotalD_D As Double
        Dim TTotalC_F As Double
        Dim TTotalC_T As Double
        Dim TTotalC_D As Double
        Dim TTotalCCost_F As Double
        Dim TTotalCCost_T As Double
        Dim TTotalCCost_D As Double
        Dim TBonus_F As Double
        Dim TBonus_T As Double
        Dim TBonus_D As Double

        Dim TBonS_F As Double
        Dim TBonS_T As Double
        Dim TBonS_D As Double

        Dim TMS_F As Double
        Dim TMS_T As Double
        Dim TMS_D As Double

        Dim TBIK_F As Double
        Dim TBIK_T As Double
        Dim TBIK_D As Double


        Dim TFine_F As Double
        Dim TFine_T As Double
        Dim TFine_D As Double


        Dim BonusErnCode1 As String = "E11"
        Dim BonusErnCode2 As String = "E37"
        Dim BonusErnCode3 As String = "E38"

        Dim RecBonusErnCode As String = "E30"

        Dim FineErnCode As String

        Dim BIKErnType As String = "BK"
        Dim RecBIKernType As String = "BR"

        Dim FineType As String = "FN"

        Dim Anal2Code As String
        Dim PosCode As String




        If CheckDataSet(DsHeaderFrom) And CheckDataSet(DsHeaderTo) Then
            Dim totalFrom As Integer = DsHeaderFrom.Tables(0).Rows.Count - 1
            Dim totalTo As Integer = DsHeaderTo.Tables(0).Rows.Count - 1

            For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                Units_F = 0
                Units_T = 0
                Units_D = 0
                NetSal_F = 0
                NetSal_T = 0
                NetSal_D = 0
                TotalE_F = 0
                TotalE_T = 0
                TotalE_D = 0
                TotalD_F = 0
                TotalD_T = 0
                TotalD_D = 0
                TotalC_F = 0
                TotalC_T = 0
                TotalC_D = 0
                TotalCCost_F = 0
                TotalCCost_T = 0
                TotalCCost_D = 0
                Bonus_F = 0
                Bonus_T = 0
                Bonus_D = 0
                RecBonus_T = 0
                RecBonus_F = 0

                BonS_F = 0
                BonS_T = 0
                BonS_D = 0

                MS_F = 0
                MS_T = 0
                MS_D = 0

                BIK_F = 0
                BIK_T = 0
                BIK_D = 0

                Fine_F = 0
                Fine_T = 0
                Fine_D = 0

                EmpCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(2))
                HDRIdTo = DbNullToInt(DsHeaderTo.Tables(0).Rows(i).Item(0))
                Units_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(5))
                NetSal_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(3))
                TotalE_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(23))
                TotalD_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(24))
                TotalC_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(25))

                BonS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(26))
                MS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(4))

                TotalCCost_T = RoundMe3(TotalE_T + TotalC_T, 2)
                'Bonus_T = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdTo)
                Bonus_T = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdTo)

                Fine_T = Fine_T + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdTo)


                RecBonus_T = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdTo)
                Bonus_T = Bonus_T + RecBonus_T



                BIK_T = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdTo)
                BIK_T = BIK_T + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdTo)


                Anal2Code = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(18))
                PosCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(22))

                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode2 = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    If EmpCode2 = EmpCode Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))

                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))

                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))


                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)
                        'Bonus_F = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdFrom)
                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)

                        Exit For
                    End If
                Next

                Units_D = RoundMe3(Units_T - Units_F, 2)
                NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                MS_D = RoundMe3(MS_T - MS_F, 2)
                BIK_D = RoundMe3(BIK_T - BIK_F, 2)

                Fine_D = RoundMe3(Fine_T - Fine_F, 2)


                Dim r As DataRow = DtDif.NewRow()
                r(0) = PerFrom.Code
                r(1) = PerFrom.DescriptionL
                r(2) = PerTo.Code
                r(3) = PerTo.DescriptionL

                r(4) = EmpCode
                r(5) = EmpName

                r(6) = Units_F
                r(7) = Units_T
                r(8) = Units_D

                r(9) = NetSal_F
                r(10) = NetSal_T
                r(11) = NetSal_D

                r(12) = TotalE_F
                r(13) = TotalE_T
                r(14) = TotalE_D

                r(15) = TotalD_F
                r(16) = TotalD_T
                r(17) = TotalD_D

                r(18) = TotalC_F
                r(19) = TotalC_T
                r(20) = TotalC_D

                r(21) = TotalCCost_F
                r(22) = TotalCCost_T
                r(23) = TotalCCost_D

                r(24) = Bonus_F
                r(25) = Bonus_T
                r(26) = Bonus_D

                r(29) = BonS_F
                r(30) = BonS_T
                r(31) = BonS_D

                r(32) = MS_F
                r(33) = MS_T
                r(34) = MS_D

                r(35) = BIK_F
                r(36) = BIK_T
                r(37) = BIK_D

                r(38) = BIK_F + TotalCCost_F
                r(39) = BIK_T + TotalCCost_T
                r(40) = BIK_D + TotalCCost_D


                r(41) = Fine_F
                r(42) = Fine_T
                r(43) = Fine_D





                Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                Dim Pos As New cPrAnEmployeePositions(PosCode)
                r(27) = Anl2.DescriptionS
                r(28) = Pos.DescriptionL

                DtDif.Rows.Add(r)


                TUnits_F = TUnits_F + Units_F
                TUnits_T = TUnits_T + Units_T
                TUnits_D = TUnits_D + Units_D
                TNetSal_F = TNetSal_F + NetSal_F
                TNetSal_T = TNetSal_T + NetSal_T
                TNetSal_D = TNetSal_D + NetSal_D
                TTotalE_F = TTotalE_F + TotalE_F
                TTotalE_T = TTotalE_T + TotalE_T
                TTotalE_D = TTotalE_D + TotalE_D
                TTotalD_F = TTotalD_F + TotalD_F
                TTotalD_T = TTotalD_T + TotalD_T
                TTotalD_D = TTotalD_D + TotalD_D
                TTotalC_F = TTotalC_F + TotalC_F
                TTotalC_T = TTotalC_T + TotalC_T
                TTotalC_D = TTotalC_D + TotalC_D

                TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                TBonus_F = TBonus_F + Bonus_F
                TBonus_T = TBonus_T + Bonus_T
                TBonus_D = TBonus_D + Bonus_D


                TBonS_F = TBonS_F + BonS_F
                TBonS_T = TBonS_T + BonS_T
                TBonS_D = TBonS_D + BonS_D

                TMS_F = TMS_F + MS_F
                TMS_T = TMS_T + MS_T
                TMS_D = TMS_D + MS_D

                TBIK_F = TBIK_F + BIK_F
                TBIK_T = TBIK_T + BIK_T
                TBIK_D = TBIK_D + BIK_D

                TFine_F = TFine_F + Fine_F
                TFine_T = TFine_T + Fine_T
                TFine_D = TFine_D + Fine_D

            Next
            '-----------------------------------------------------------------------------
            ''''''''''                Second RUN               '''''''''''''''''''''''''''

            If CheckDataSet(DsHeaderFrom) Then
                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    Dim found As Boolean = False
                    For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                        EmpCode2 = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                        If EmpCode2 = EmpCode Then
                            found = True
                            Exit For
                        End If
                    Next
                    If found = False Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))
                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))
                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))
                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)

                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)


                        EmpName = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(2))

                        Anal2Code = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(18))
                        PosCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(22))

                        Units_T = 0
                        NetSal_T = 0
                        TotalE_T = 0
                        TotalD_T = 0
                        TotalC_T = 0
                        TotalCCost_T = 0
                        Bonus_T = 0
                        BonS_T = 0
                        MS_T = 0
                        BIK_T = 0

                        Fine_T = 0


                        Units_D = RoundMe3(Units_T - Units_F, 2)
                        NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                        TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                        TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                        TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                        TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                        Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                        BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                        MS_D = RoundMe3(MS_T - MS_F, 2)
                        BIK_D = RoundMe3(BIK_T - BIK_F, 2)
                        Fine_D = RoundMe3(Fine_T - Fine_F, 2)


                        Dim r As DataRow = DtDif.NewRow()
                        r(0) = PerFrom.Code
                        r(1) = PerFrom.DescriptionL
                        r(2) = PerTo.Code
                        r(3) = PerTo.DescriptionL

                        r(4) = EmpCode
                        r(5) = EmpName

                        r(6) = Units_F
                        r(7) = Units_T
                        r(8) = Units_D

                        r(9) = NetSal_F
                        r(10) = NetSal_T
                        r(11) = NetSal_D

                        r(12) = TotalE_F
                        r(13) = TotalE_T
                        r(14) = TotalE_D

                        r(15) = TotalD_F
                        r(16) = TotalD_T
                        r(17) = TotalD_D

                        r(18) = TotalC_F
                        r(19) = TotalC_T
                        r(20) = TotalC_D

                        r(21) = TotalCCost_F
                        r(22) = TotalCCost_T
                        r(23) = TotalCCost_D

                        r(24) = Bonus_F
                        r(25) = Bonus_T
                        r(26) = Bonus_D

                        r(29) = BonS_F
                        r(30) = BonS_T
                        r(31) = BonS_D

                        r(32) = MS_F
                        r(33) = MS_T
                        r(34) = MS_D

                        r(35) = BIK_F
                        r(36) = BIK_T
                        r(37) = BIK_D

                        r(38) = BIK_F + TotalCCost_F
                        r(39) = BIK_T + TotalCCost_T
                        r(40) = BIK_D + TotalCCost_D


                        r(41) = Fine_F
                        r(42) = Fine_T
                        r(43) = Fine_D



                        Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                        Dim Pos As New cPrAnEmployeePositions(PosCode)
                        r(27) = Anl2.DescriptionS
                        r(28) = Pos.DescriptionL

                        DtDif.Rows.Add(r)


                        TUnits_F = TUnits_F + Units_F
                        TUnits_T = TUnits_T + Units_T
                        TUnits_D = TUnits_D + Units_D
                        TNetSal_F = TNetSal_F + NetSal_F
                        TNetSal_T = TNetSal_T + NetSal_T
                        TNetSal_D = TNetSal_D + NetSal_D
                        TTotalE_F = TTotalE_F + TotalE_F
                        TTotalE_T = TTotalE_T + TotalE_T
                        TTotalE_D = TTotalE_D + TotalE_D
                        TTotalD_F = TTotalD_F + TotalD_F
                        TTotalD_T = TTotalD_T + TotalD_T
                        TTotalD_D = TTotalD_D + TotalD_D
                        TTotalC_F = TTotalC_F + TotalC_F
                        TTotalC_T = TTotalC_T + TotalC_T
                        TTotalC_D = TTotalC_D + TotalC_D

                        TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                        TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                        TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                        TBonus_F = TBonus_F + Bonus_F
                        TBonus_T = TBonus_T + Bonus_T
                        TBonus_D = TBonus_D + Bonus_D


                        TBonS_F = TBonS_F + BonS_F
                        TBonS_T = TBonS_T + BonS_T
                        TBonS_D = TBonS_D + BonS_D

                        TMS_F = TMS_F + MS_F
                        TMS_T = TMS_T + MS_T
                        TMS_D = TMS_D + MS_D

                        TBIK_F = TBIK_F + BIK_F
                        TBIK_T = TBIK_T + BIK_T
                        TBIK_D = TBIK_D + BIK_D


                        TFine_F = TFine_F + Fine_F
                        TFine_T = TFine_T + Fine_T
                        TFine_D = TFine_D + Fine_D

                    End If

                Next
            End If








            Dim rt As DataRow = DtDif.NewRow()
            rt(0) = PerFrom.Code
            rt(1) = PerFrom.DescriptionL
            rt(2) = PerTo.Code
            rt(3) = PerTo.DescriptionL

            rt(4) = ""
            rt(5) = "TOTALS"

            rt(6) = TUnits_F
            rt(7) = TUnits_T
            rt(8) = TUnits_D

            rt(9) = TNetSal_F
            rt(10) = TNetSal_T
            rt(11) = TNetSal_D

            rt(12) = TTotalE_F
            rt(13) = TTotalE_T
            rt(14) = TTotalE_D

            rt(15) = TTotalD_F
            rt(16) = TTotalD_T
            rt(17) = TTotalD_D

            rt(18) = TTotalC_F
            rt(19) = TTotalC_T
            rt(20) = TTotalC_D

            rt(21) = TTotalCCost_F
            rt(22) = TTotalCCost_T
            rt(23) = TTotalCCost_D

            rt(24) = TBonus_F
            rt(25) = TBonus_T
            rt(26) = TBonus_D

            rt(27) = ""
            rt(28) = ""

            rt(29) = TBonS_F
            rt(30) = TBonS_T
            rt(31) = TBonS_D

            rt(32) = TMS_F
            rt(33) = TMS_T
            rt(34) = TMS_D

            rt(35) = TBIK_F
            rt(36) = TBIK_T
            rt(37) = TBIK_D

            rt(38) = TBIK_F + TTotalCCost_F
            rt(39) = TBIK_T + TTotalCCost_T
            rt(40) = TBIK_D + TTotalCCost_D


            rt(41) = TFine_F
            rt(42) = TFine_T
            rt(43) = TFine_D

            DtDif.Rows.Add(rt)


        End If
        'End If




        Me.Cursor = Cursors.Default
        'Dim F As New FrmDifReport
        'F.Ds = MyDsDif
        'F.Show()

    End Sub
    Private Sub FixNormalColumnsColor()
        DG1.Columns(Me.Column_EmpCode).HeaderText = "EMP.CODE"
        DG1.Columns(Me.Column_EmpCode).DefaultCellStyle.BackColor = Me.Color_NormalFields
        DG1.Columns(Me.Column_EmpName).HeaderText = "EMP.NAME"
        DG1.Columns(Me.Column_EmpName).DefaultCellStyle.BackColor = Me.Color_NormalFields

        DG1.Columns(Me.Column_ActualUnits).HeaderText = "UNITS WORKED"
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.BackColor = Me.Color_NormalFields
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_ActualUnits).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_NetSalary).HeaderText = "NET SAL."
        DG1.Columns(Me.Column_NetSalary).DefaultCellStyle.BackColor = Me.Color_NormalFields
        DG1.Columns(Me.Column_NetSalary).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_NetSalary).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_CompanyCost).HeaderText = "COMP.COST"
        DG1.Columns(Me.Column_CompanyCost).DefaultCellStyle.BackColor = Me.Color_NormalFields
        DG1.Columns(Me.Column_CompanyCost).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_CompanyCost).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        DG1.Columns(Me.Column_SITotal).HeaderText = "TOTAL SOC.Ins"
        DG1.Columns(Me.Column_SITotal).DefaultCellStyle.BackColor = Me.Color_NormalFields
        DG1.Columns(Me.Column_SITotal).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_SITotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        DG1.Columns(Me.Column_EVTotal).HeaderText = "TOTAL EARN."
        DG1.Columns(Me.Column_EVTotal).DefaultCellStyle.BackColor = Me.Color_Earnings
        DG1.Columns(Me.Column_EVTotal).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_EVTotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_DVTotal).HeaderText = "TOTAL DEDUCT."
        DG1.Columns(Me.Column_DVTotal).DefaultCellStyle.BackColor = Me.Color_Deductions
        DG1.Columns(Me.Column_DVTotal).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_DVTotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_CVTotal).HeaderText = "TOTAL CONTR."
        DG1.Columns(Me.Column_CVTotal).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_CVTotal).DefaultCellStyle.Format = "0.00"
        DG1.Columns(Me.Column_CVTotal).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_ChequeNo).HeaderText = "REF."
        'DG1.Columns(Me.Column_ChequeNo).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_ChequeNo).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_Overtime1).HeaderText = "Overtime 1 Units."
        'DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_Overtime1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_OverTime2).HeaderText = "Overtime 2 Units."
        ' DG1.Columns(Me.Column_OverTime2).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_OverTime2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_OverTime3).HeaderText = "Overtime 3 Units."
        'DG1.Columns(Me.Column_OverTime3).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_OverTime3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_Salary1).HeaderText = "Salary 1"
        'DG1.Columns(Me.Column_Salary1).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_Salary1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_Salary2).HeaderText = "Salary 2"
        'DG1.Columns(Me.Column_Salary2).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_Salary2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_sectors).HeaderText = "Sectors"
        'DG1.Columns(Me.Column_sectors).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_sectors).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_dutyhours).HeaderText = "Duty Hours"
        ' DG1.Columns(Me.Column_dutyhours).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_dutyhours).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_flighthours).HeaderText = "Flight Hours"
        ' DG1.Columns(Me.Column_flighthours).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_flighthours).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_commission).HeaderText = "Commission"
        ' DG1.Columns(Me.Column_commission).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_commission).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_OverLay).HeaderText = "Overlay"
        ' DG1.Columns(Me.Column_OverLay).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_OverLay).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DG1.Columns(Me.Column_TimeOff).HeaderText = "Time Off Hours"
        ' DG1.Columns(Me.Column_TimeOff).DefaultCellStyle.BackColor = Me.Color_Contributions
        DG1.Columns(Me.Column_TimeOff).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        DG1.Columns(Me.Column_PeriodCode).Visible = False

    End Sub
    Private Sub ChangeColumnName(ByVal DisplayName As String, ByVal C As Integer, ByVal Type As String)
        If DisplayName <> "" Then
            DG1.Columns(C).HeaderText = DisplayName
            DG1.Columns(C).Visible = True
        End If
        DG1.Columns(C).DefaultCellStyle.Format = "0.00"
        DG1.Columns(C).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If Type = "E" Then
            DG1.Columns(C).DefaultCellStyle.BackColor = Color_Earnings
        ElseIf Type = "D" Then
            DG1.Columns(C).DefaultCellStyle.BackColor = Color_Deductions
        ElseIf Type = "C" Then
            DG1.Columns(C).DefaultCellStyle.BackColor = Color_Contributions
        End If

    End Sub
    Private Sub LoadDataSetToExcel()

        'Dim HeaderStr As New ArrayList
        'Dim HeaderSize As New ArrayList
        'Dim Loader As New cExcelLoader
        'ds = Global1.Business.AG_GetAllPrAnBanks()
        'HeaderStr.Add("Code")
        'HeaderStr.Add("Long Description")
        'HeaderStr.Add("Short Description")
        'HeaderStr.Add("Is Active")
        'HeaderStr.Add("Transfer Code")
        'HeaderSize.Add(12)
        'HeaderSize.Add(40)
        'HeaderSize.Add(15)
        'HeaderSize.Add(1)
        'HeaderSize.Add(20)
        'Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    Private Sub Transfer_MyDsX_to_MyDs2(ByRef HeaderStr As ArrayList, ByRef HeaderSize As ArrayList)

        


        Dim i As Integer
        For i = 0 To MyDsX.Tables(0).Rows.Count - 1
            Dim r As DataRow = Dt2.NewRow()
            r(C_EmpCode) = MyDsX.Tables(0).Rows(i).Item(Column_EmpCode)
            r(C_EmpName) = MyDsX.Tables(0).Rows(i).Item(Column_EmpName)
            r(C_ActualUnits) = MyDsX.Tables(0).Rows(i).Item(Column_ActualUnits)



            ''''''''''' Earnings ''''''''''''

            r(C_EV1) = MyDsX.Tables(0).Rows(i).Item(Column_EV1)
            r(C_EV2) = MyDsX.Tables(0).Rows(i).Item(Column_EV2)
            r(C_EV3) = MyDsX.Tables(0).Rows(i).Item(Column_EV3)
            r(C_EV4) = MyDsX.Tables(0).Rows(i).Item(Column_EV4)
            r(C_EV5) = MyDsX.Tables(0).Rows(i).Item(Column_EV5)
            r(C_EV6) = MyDsX.Tables(0).Rows(i).Item(Column_EV6)
            r(C_EV7) = MyDsX.Tables(0).Rows(i).Item(Column_EV7)
            r(C_EV8) = MyDsX.Tables(0).Rows(i).Item(Column_EV8)
            r(C_EV9) = MyDsX.Tables(0).Rows(i).Item(Column_EV9)
            r(C_EV10) = MyDsX.Tables(0).Rows(i).Item(Column_EV10)
            r(C_EV11) = MyDsX.Tables(0).Rows(i).Item(Column_EV11)
            r(C_EV12) = MyDsX.Tables(0).Rows(i).Item(Column_EV12)
            r(C_EV13) = MyDsX.Tables(0).Rows(i).Item(Column_EV13)
            r(C_EV14) = MyDsX.Tables(0).Rows(i).Item(Column_EV14)
            r(C_EV15) = MyDsX.Tables(0).Rows(i).Item(Column_EV15)
            r(C_EVTotal) = MyDsX.Tables(0).Rows(i).Item(Column_EVTotal)

            ''''''''''' Deductions '''''''''

            r(C_DV1) = MyDsX.Tables(0).Rows(i).Item(Column_DV1)
            r(C_DV2) = MyDsX.Tables(0).Rows(i).Item(Column_DV2)
            r(C_DV3) = MyDsX.Tables(0).Rows(i).Item(Column_DV3)
            r(C_DV4) = MyDsX.Tables(0).Rows(i).Item(Column_DV4)
            r(C_DV5) = MyDsX.Tables(0).Rows(i).Item(Column_DV5)
            r(C_DV6) = MyDsX.Tables(0).Rows(i).Item(Column_DV6)
            r(C_DV7) = MyDsX.Tables(0).Rows(i).Item(Column_DV7)
            r(C_DV8) = MyDsX.Tables(0).Rows(i).Item(Column_DV8)
            r(C_DV9) = MyDsX.Tables(0).Rows(i).Item(Column_DV9)
            r(C_DV10) = MyDsX.Tables(0).Rows(i).Item(Column_DV10)
            r(C_DV11) = MyDsX.Tables(0).Rows(i).Item(Column_DV11)
            r(C_DV12) = MyDsX.Tables(0).Rows(i).Item(Column_DV12)
            r(C_DV13) = MyDsX.Tables(0).Rows(i).Item(Column_DV13)
            r(C_DV14) = MyDsX.Tables(0).Rows(i).Item(Column_DV14)
            r(C_DV15) = MyDsX.Tables(0).Rows(i).Item(Column_DV15)
            r(C_DVTotal) = MyDsX.Tables(0).Rows(i).Item(Column_DVTotal)

            '''''''' Contributions '''''''''

            r(C_CV1) = MyDsX.Tables(0).Rows(i).Item(Column_CV1)
            r(C_CV2) = MyDsX.Tables(0).Rows(i).Item(Column_CV2)
            r(C_CV3) = MyDsX.Tables(0).Rows(i).Item(Column_CV3)
            r(C_CV4) = MyDsX.Tables(0).Rows(i).Item(Column_CV4)
            r(C_CV5) = MyDsX.Tables(0).Rows(i).Item(Column_CV5)
            r(C_CV6) = MyDsX.Tables(0).Rows(i).Item(Column_CV6)
            r(C_CV7) = MyDsX.Tables(0).Rows(i).Item(Column_CV7)
            r(C_CV8) = MyDsX.Tables(0).Rows(i).Item(Column_CV8)
            r(C_CV9) = MyDsX.Tables(0).Rows(i).Item(Column_CV9)
            r(C_CV10) = MyDsX.Tables(0).Rows(i).Item(Column_CV10)
            r(C_CV11) = MyDsX.Tables(0).Rows(i).Item(Column_CV11)
            r(C_CV12) = MyDsX.Tables(0).Rows(i).Item(Column_CV12)
            r(C_CV13) = MyDsX.Tables(0).Rows(i).Item(Column_CV13)
            r(C_CV14) = MyDsX.Tables(0).Rows(i).Item(Column_CV14)
            r(C_CV15) = MyDsX.Tables(0).Rows(i).Item(Column_CV15)

            r(C_CVTotal) = MyDsX.Tables(0).Rows(i).Item(Column_CVTotal)
            r(C_NetSalary) = MyDsX.Tables(0).Rows(i).Item(Column_NetSalary)
            r(C_CompanyCost) = MyDsX.Tables(0).Rows(i).Item(Column_CompanyCost)
            r(C_SITotal) = MyDsX.Tables(0).Rows(i).Item(Column_SITotal)
            r(C_ref) = MyDsX.Tables(0).Rows(i).Item(Me.Column_ChequeNo)

            r(C_Overtime1) = MyDsX.Tables(0).Rows(i).Item(Column_Overtime1)
            r(C_OverTime2) = MyDsX.Tables(0).Rows(i).Item(Column_OverTime2)
            r(C_OverTime3) = MyDsX.Tables(0).Rows(i).Item(Column_OverTime3)
            r(C_Salary1) = MyDsX.Tables(0).Rows(i).Item(Column_Salary1)
            r(C_Salary2) = MyDsX.Tables(0).Rows(i).Item(Column_Salary2)

            ''
            r(C_Sectors) = MyDsX.Tables(0).Rows(i).Item(Column_sectors)
            r(C_DutyHours) = MyDsX.Tables(0).Rows(i).Item(Column_dutyhours)
            r(C_FlightHours) = MyDsX.Tables(0).Rows(i).Item(Column_flighthours)
            r(C_Commission) = MyDsX.Tables(0).Rows(i).Item(Column_commission)
            r(C_Overlay) = MyDsX.Tables(0).Rows(i).Item(Column_OverLay)

            r(C_AnalysisCode) = MyDsX.Tables(0).Rows(i).Item(Column_AnalysisCode)
            r(C_Position) = MyDsX.Tables(0).Rows(i).Item(Column_Position)
            r(C_DOE) = MyDsX.Tables(0).Rows(i).Item(Column_DOE)
            r(C_TimeOff) = MyDsX.Tables(0).Rows(i).Item(Column_TimeOff)
            r(C_GenAnal1) = MyDsX.Tables(0).Rows(i).Item(Column_GenAnal1)
            r(C_EmpCounter) = MyDsX.Tables(0).Rows(i).Item(Column_EmpCounter)
            r(C_Analysis2) = MyDsX.Tables(0).Rows(i).Item(Column_Analysis2)

            r(C_AL_Code1) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Code1)
            r(C_AL_Code2) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Code2)
            r(C_AL_Code3) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Code3)
            r(C_AL_Code4) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Code4)
            r(C_AL_Code5) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Code5)

            r(C_AL_Desc1) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Desc1)
            r(C_AL_Desc2) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Desc2)
            r(C_AL_Desc3) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Desc3)
            r(C_AL_Desc4) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Desc4)
            r(C_AL_Desc5) = MyDsX.Tables(0).Rows(i).Item(Me.Column_AL_Desc5)


            r(C_Termdate) = MyDsX.Tables(0).Rows(i).Item(Me.Column_Termdate)
            r(C_SINumber) = MyDsX.Tables(0).Rows(i).Item(Me.Column_SINumber)
            r(C_BankBenName) = MyDsX.Tables(0).Rows(i).Item(Me.Column_BankBenName)
            r(C_ComBank) = MyDsX.Tables(0).Rows(i).Item(Me.Column_ComBank)
            r(C_DOB) = MyDsX.Tables(0).Rows(i).Item(Me.Column_DOB)
            r(C_Identity) = MyDsX.Tables(0).Rows(i).Item(Me.Column_identity)
            r(C_tic) = MyDsX.Tables(0).Rows(i).Item(Me.Column_tic)

            ''

            Dt2.Rows.Add(r)
        Next

        HeaderStr.Add(DG1.Columns(Column_EmpCode).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EmpName).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_ActualUnits).HeaderText())



        HeaderStr.Add(DG1.Columns(Column_EV1).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV2).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV3).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV4).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV5).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV6).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV7).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV8).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV9).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV10).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV11).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV12).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV13).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV14).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EV15).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EVTotal).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_DV1).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV2).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV3).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV4).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV5).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV6).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV7).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV8).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV9).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV10).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV11).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV12).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV13).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV14).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DV15).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DVTotal).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_CV1).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV2).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV3).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV4).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV5).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV6).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV7).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV8).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV9).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV10).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV11).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV12).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV13).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV14).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CV15).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_CVTotal).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_NetSalary).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_CompanyCost).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_SITotal).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_ChequeNo).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_Overtime1).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_OverTime2).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_OverTime3).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_Salary1).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_Salary2).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_sectors).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_dutyhours).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_flighthours).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_commission).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_OverLay).HeaderText())






        HeaderStr.Add(DG1.Columns(Column_AnalysisCode).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_Position).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DOE).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_TimeOff).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_GenAnal1).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_EmpCounter).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_Analysis2).HeaderText())


        HeaderStr.Add(DG1.Columns(Me.Column_AL_Code1).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Code2).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Code3).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Code4).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Code5).HeaderText())

        HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc1).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc2).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc3).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc4).HeaderText())
        HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc5).HeaderText())



        HeaderStr.Add(DG1.Columns(Column_Termdate).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_SINumber).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_BankBenName).HeaderText())

        HeaderStr.Add(DG1.Columns(Column_ComBank).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_DOB).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_Identity).HeaderText())
        HeaderStr.Add(DG1.Columns(Column_TIC).HeaderText())



        For i = 0 To HeaderStr.Count - 1
            If HeaderStr(i) = "" Then
                HeaderSize.Add(0)
            Else
                Dim C As Integer = 0
                C = HeaderStr(i).ToString.Length
                C = 8
                HeaderSize.Add(C)
            End If
        Next
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If YTDReport Then

            MyDs2.Tables(0).Rows.Clear()

            If CheckDataSet(MyDs) Then
                Dim Loader As New cExcelLoader
                Dim HeaderStr As New ArrayList
                Dim HeaderSize As New ArrayList

                Transfer_MyDsX_to_MyDs2(HeaderStr, HeaderSize)

                Dim MyDsCopy As DataSet
                MyDsCopy = MyDs2.Copy
                Dim lastI As Integer
                lastI = MyDsCopy.Tables(0).Rows.Count - 1
                MyDsCopy.Tables(0).Rows(lastI).Delete()
                lastI = MyDsCopy.Tables(0).Rows.Count - 1
                MyDsCopy.Tables(0).Rows(lastI - 1).Delete()

                Loader.LoadIntoExcel(MyDsCopy, HeaderStr, HeaderSize)

            End If


        Else

            MyDs2.Tables(0).Rows.Clear()
            If CheckDataSet(MyDs) Then
                Dim HeaderStr As New ArrayList
                Dim HeaderSize As New ArrayList
                Dim Loader As New cExcelLoader

                Dim i As Integer
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Dim r As DataRow = Dt2.NewRow()
                    r(C_EmpCode) = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)
                    r(C_EmpName) = MyDs.Tables(0).Rows(i).Item(Column_EmpName)
                    r(C_ActualUnits) = MyDs.Tables(0).Rows(i).Item(Column_ActualUnits)


                    ''''''''''' Earnings ''''''''''''

                    r(C_EV1) = MyDs.Tables(0).Rows(i).Item(Column_EV1)
                    r(C_EV2) = MyDs.Tables(0).Rows(i).Item(Column_EV2)
                    r(C_EV3) = MyDs.Tables(0).Rows(i).Item(Column_EV3)
                    r(C_EV4) = MyDs.Tables(0).Rows(i).Item(Column_EV4)
                    r(C_EV5) = MyDs.Tables(0).Rows(i).Item(Column_EV5)
                    r(C_EV6) = MyDs.Tables(0).Rows(i).Item(Column_EV6)
                    r(C_EV7) = MyDs.Tables(0).Rows(i).Item(Column_EV7)
                    r(C_EV8) = MyDs.Tables(0).Rows(i).Item(Column_EV8)
                    r(C_EV9) = MyDs.Tables(0).Rows(i).Item(Column_EV9)
                    r(C_EV10) = MyDs.Tables(0).Rows(i).Item(Column_EV10)
                    r(C_EV11) = MyDs.Tables(0).Rows(i).Item(Column_EV11)
                    r(C_EV12) = MyDs.Tables(0).Rows(i).Item(Column_EV12)
                    r(C_EV13) = MyDs.Tables(0).Rows(i).Item(Column_EV13)
                    r(C_EV14) = MyDs.Tables(0).Rows(i).Item(Column_EV14)
                    r(C_EV15) = MyDs.Tables(0).Rows(i).Item(Column_EV15)
                    r(C_EVTotal) = MyDs.Tables(0).Rows(i).Item(Column_EVTotal)

                    ''''''''''' Deductions '''''''''

                    r(C_DV1) = MyDs.Tables(0).Rows(i).Item(Column_DV1)
                    r(C_DV2) = MyDs.Tables(0).Rows(i).Item(Column_DV2)
                    r(C_DV3) = MyDs.Tables(0).Rows(i).Item(Column_DV3)
                    r(C_DV4) = MyDs.Tables(0).Rows(i).Item(Column_DV4)
                    r(C_DV5) = MyDs.Tables(0).Rows(i).Item(Column_DV5)
                    r(C_DV6) = MyDs.Tables(0).Rows(i).Item(Column_DV6)
                    r(C_DV7) = MyDs.Tables(0).Rows(i).Item(Column_DV7)
                    r(C_DV8) = MyDs.Tables(0).Rows(i).Item(Column_DV8)
                    r(C_DV9) = MyDs.Tables(0).Rows(i).Item(Column_DV9)
                    r(C_DV10) = MyDs.Tables(0).Rows(i).Item(Column_DV10)
                    r(C_DV11) = MyDs.Tables(0).Rows(i).Item(Column_DV11)
                    r(C_DV12) = MyDs.Tables(0).Rows(i).Item(Column_DV12)
                    r(C_DV13) = MyDs.Tables(0).Rows(i).Item(Column_DV13)
                    r(C_DV14) = MyDs.Tables(0).Rows(i).Item(Column_DV14)
                    r(C_DV15) = MyDs.Tables(0).Rows(i).Item(Column_DV15)
                    r(C_DVTotal) = MyDs.Tables(0).Rows(i).Item(Column_DVTotal)

                    '''''''' Contributions '''''''''

                    r(C_CV1) = MyDs.Tables(0).Rows(i).Item(Column_CV1)
                    r(C_CV2) = MyDs.Tables(0).Rows(i).Item(Column_CV2)
                    r(C_CV3) = MyDs.Tables(0).Rows(i).Item(Column_CV3)
                    r(C_CV4) = MyDs.Tables(0).Rows(i).Item(Column_CV4)
                    r(C_CV5) = MyDs.Tables(0).Rows(i).Item(Column_CV5)
                    r(C_CV6) = MyDs.Tables(0).Rows(i).Item(Column_CV6)
                    r(C_CV7) = MyDs.Tables(0).Rows(i).Item(Column_CV7)
                    r(C_CV8) = MyDs.Tables(0).Rows(i).Item(Column_CV8)
                    r(C_CV9) = MyDs.Tables(0).Rows(i).Item(Column_CV9)
                    r(C_CV10) = MyDs.Tables(0).Rows(i).Item(Column_CV10)
                    r(C_CV11) = MyDs.Tables(0).Rows(i).Item(Column_CV11)
                    r(C_CV12) = MyDs.Tables(0).Rows(i).Item(Column_CV12)
                    r(C_CV13) = MyDs.Tables(0).Rows(i).Item(Column_CV13)
                    r(C_CV14) = MyDs.Tables(0).Rows(i).Item(Column_CV14)
                    r(C_CV15) = MyDs.Tables(0).Rows(i).Item(Column_CV15)

                    r(C_CVTotal) = MyDs.Tables(0).Rows(i).Item(Column_CVTotal)
                    r(C_NetSalary) = MyDs.Tables(0).Rows(i).Item(Column_NetSalary)
                    r(C_CompanyCost) = MyDs.Tables(0).Rows(i).Item(Column_CompanyCost)
                    r(C_SITotal) = MyDs.Tables(0).Rows(i).Item(Column_SITotal)
                    r(C_ref) = MyDs.Tables(0).Rows(i).Item(Me.Column_ChequeNo)
                    r(C_Overtime1) = MyDs.Tables(0).Rows(i).Item(Column_Overtime1)
                    r(C_OverTime2) = MyDs.Tables(0).Rows(i).Item(Column_OverTime2)
                    r(C_OverTime3) = MyDs.Tables(0).Rows(i).Item(Column_OverTime3)
                    r(C_Salary1) = MyDs.Tables(0).Rows(i).Item(Column_Salary1)
                    r(C_Salary2) = MyDs.Tables(0).Rows(i).Item(Column_Salary2)

                    r(C_Sectors) = MyDs.Tables(0).Rows(i).Item(Column_sectors)
                    r(C_DutyHours) = MyDs.Tables(0).Rows(i).Item(Column_dutyhours)
                    r(C_FlightHours) = MyDs.Tables(0).Rows(i).Item(Column_flighthours)
                    r(C_Commission) = MyDs.Tables(0).Rows(i).Item(Column_commission)
                    r(C_Overlay) = MyDs.Tables(0).Rows(i).Item(Column_OverLay)

                    r(C_AnalysisCode) = MyDs.Tables(0).Rows(i).Item(Column_AnalysisCode)
                    r(C_Position) = MyDs.Tables(0).Rows(i).Item(Column_Position)
                    r(C_DOE) = MyDs.Tables(0).Rows(i).Item(Column_DOE)
                    r(C_TimeOff) = MyDs.Tables(0).Rows(i).Item(Column_TimeOff)
                    r(C_GenAnal1) = MyDs.Tables(0).Rows(i).Item(Column_GenAnal1)
                    r(C_EmpCounter) = MyDs.Tables(0).Rows(i).Item(Column_EmpCounter)
                    r(C_Analysis2) = MyDs.Tables(0).Rows(i).Item(Column_Analysis2)

                    If Global1.PARAM_ShowAnalysis3onPayslip Then
                        r(C_AnalysisCode) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code3)
                        r(C_Analysis2) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc3)

                    End If
                    r(C_AL_Code1) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code1)
                    r(C_AL_Code2) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code2)
                    r(C_AL_Code3) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code3)
                    r(C_AL_Code4) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code4)
                    r(C_AL_Code5) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code5)
                    r(C_AL_Desc1) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc1)
                    r(C_AL_Desc2) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc2)
                    r(C_AL_Desc3) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc3)
                    r(C_AL_Desc4) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc4)
                    r(C_AL_Desc5) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc5)

                    r(C_Termdate) = MyDs.Tables(0).Rows(i).Item(Column_Termdate)
                    r(C_SINumber) = MyDs.Tables(0).Rows(i).Item(Column_SINumber)
                    r(C_BankBenName) = MyDs.Tables(0).Rows(i).Item(Column_BankBenName)
                    r(C_ComBank) = MyDs.Tables(0).Rows(i).Item(Column_ComBank)
                    r(C_DOB) = MyDs.Tables(0).Rows(i).Item(Column_DOB)
                    r(C_Identity) = MyDs.Tables(0).Rows(i).Item(Column_Identity)
                    r(C_TIC) = MyDs.Tables(0).Rows(i).Item(Column_TIC)
                    r(C_address) = MyDs.Tables(0).Rows(i).Item(Column_Address)
                    r(C_HRCode) = MyDs.Tables(0).Rows(i).Item(Column_HRCode)
                    r(C_Maternity) = MyDs.Tables(0).Rows(i).Item(Column_Maternity)
                    r(C_FEPercentage) = MyDs.Tables(0).Rows(i).Item(Column_FEPercentage)
                    r(C_FEControlAmount) = MyDs.Tables(0).Rows(i).Item(Column_FEControlAmount)
                    r(C_EmpTermReason) = MyDs.Tables(0).Rows(i).Item(Column_EmpTermReason)

                    Dt2.Rows.Add(r)
                Next

                HeaderStr.Add(DG1.Columns(Column_EmpCode).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EmpName).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_ActualUnits).HeaderText())


                HeaderStr.Add(DG1.Columns(Column_EV1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV4).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV5).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV6).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV7).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV8).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV9).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV10).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV11).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV12).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV13).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV14).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV15).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EVTotal).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_DV1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV4).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV5).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV6).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV7).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV8).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV9).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV10).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV11).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV12).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV13).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV14).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV15).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DVTotal).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_CV1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV4).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV5).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV6).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV7).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV8).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV9).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV10).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV11).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV12).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV13).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV14).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV15).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CVTotal).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_NetSalary).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CompanyCost).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_SITotal).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_ChequeNo).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_Overtime1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_OverTime2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_OverTime3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_Salary1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_Salary2).HeaderText())

               
                HeaderStr.Add(DG1.Columns(Column_sectors).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_dutyhours).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_flighthours).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_commission).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_OverLay).HeaderText())

                If Global1.PARAM_ShowAnalysis3onPayslip Then
                    HeaderStr.Add("Analysis3_Code")
                Else
                    HeaderStr.Add(DG1.Columns(Column_AnalysisCode).HeaderText())
                End If

                HeaderStr.Add(DG1.Columns(Column_Position).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DOE).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_TimeOff).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_GenAnal1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EmpCounter).HeaderText())
                If Global1.PARAM_ShowAnalysis3onPayslip Then
                    HeaderStr.Add("Analysis3")
                Else

                    HeaderStr.Add(DG1.Columns(Column_Analysis2).HeaderText())
                End If

                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code1).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code2).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code3).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code4).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code5).HeaderText())

                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc1).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc2).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc3).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc4).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc5).HeaderText())



                HeaderStr.Add(DG1.Columns(Column_Termdate).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_SINumber).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_BankBenName).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_ComBank).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DOB).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_Identity).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_TIC).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_Address).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_HRCode).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_Maternity).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_FEPercentage).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_FEControlAmount).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EmpTermReason).HeaderText())






                For i = 0 To HeaderStr.Count - 1
                    If HeaderStr(i) = "" Then
                        HeaderSize.Add(0)
                    Else
                        Dim C As Integer = 0
                        C = HeaderStr(i).ToString.Length
                        C = 8
                        HeaderSize.Add(C)
                    End If
                Next
                Dim MyDsCopy As DataSet
                MyDsCopy = MyDs2.Copy
                Dim lastI As Integer
                lastI = MyDsCopy.Tables(0).Rows.Count - 1
                MyDsCopy.Tables(0).Rows(lastI).Delete()
                lastI = MyDsCopy.Tables(0).Rows.Count - 1
                MyDsCopy.Tables(0).Rows(lastI - 1).Delete()

                Loader.LoadIntoExcel(MyDsCopy, HeaderStr, HeaderSize)
            End If
        End If
    End Sub

    Private Sub BtnSearchEmp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchEmp1.Click
        Dim f As New FrmEmployeeSearch
        f.TempGroup = TemGrp.Code
        f.CalledBy = 7
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub BtnSearcEmp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearcEmp2.Click
        Dim f As New FrmEmployeeSearch
        f.TempGroup = TemGrp.Code
        f.CalledBy = 8
        f.Owner = Me
        f.ShowDialog()
    End Sub

    Private Sub TSBPFReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPFReport.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PFA As Double
        Dim PFB As Double
        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPFReport(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PFA = Global1.Business.GetDeductionForHeader(HeaderId, "PF")
                PFB = Global1.Business.GetContributionForHeader(HeaderId, "PF")
                DsHeader.Tables(0).Rows(i).Item(6) = PFA
                DsHeader.Tables(0).Rows(i).Item(7) = PFB
                TotalAB = TotalAB + PFA + PFB
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        DsCompany.Tables(0).Rows(0).Item(11) = Me.ComboAnal.Text

        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"

        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PFReport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PFReport.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If

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





    Private Sub YearToDateReport(Optional ByVal OnlyActiveEmployees As Boolean = False, Optional ByVal OnlyEmpWithTerm As Boolean = False)

        YTDReport = True

        PrepareReport2(OnlyActiveEmployees, OnlyEmpWithTerm)

        MyDsX = New DataSet
        Dim EstimateFound As Boolean = False
        Dim DTx As New DataTable
        If CheckDataSet(MyDs) Then
            DTx = MyDs.Tables(0).Copy
            MyDsX.Tables.Add(DTx)
            MyDsX.Tables(0).Rows.Clear()
            Dim i As Integer
            Dim j As Integer
            Dim CurEmpCode As String = "-1"


            Dim EmpCode As String
            '3
            Dim EmpName As String
            '4
            Dim ActualUnits As Double
            '''''''''''''''''''''''Earnings''''''''''''''''''''''
            '8
            Dim EErn1 As String
            '9
            Dim EVal1 As Double
            '10
            Dim EErn2 As String
            '11
            Dim EVal2 As Double
            '12
            Dim EErn3 As String
            '13
            Dim EVal3 As Double
            '14
            Dim EErn4 As String
            '15
            Dim EVal4 As Double
            '16
            Dim EErn5 As String
            '17
            Dim EVal5 As Double
            '18
            Dim EErn6 As String
            '19
            Dim EVal6 As Double
            '20
            Dim EErn7 As String
            '21
            Dim EVal7 As Double
            '22
            Dim EErn8 As String
            '23
            Dim EVal8 As Double
            '24
            Dim EErn9 As String
            '25
            Dim EVal9 As Double
            '26
            Dim EErn10 As String
            '27
            Dim EVal10 As Double
            '28
            Dim EErn11 As String
            '29
            Dim EVal11 As Double
            '30
            Dim EErn12 As String
            '31
            Dim EVal12 As Double
            '32
            Dim EErn13 As String
            '33
            Dim EVal13 As Double
            '34
            Dim EErn14 As String
            '35
            Dim EVal14 As Double
            '36
            Dim EErn15 As String
            '37
            Dim EVal15 As Double
            '
            Dim EVTotal As Double
            ''''''''''''''''''''''DDeductions''''''''''''''''''''''
            '38
            Dim DDed1 As String
            '39
            Dim DVal1 As Double
            '40
            Dim DDed2 As String
            '41
            Dim DVal2 As Double
            '42
            Dim DDed3 As String
            '43
            Dim DVal3 As Double
            '44
            Dim DDed4 As String
            '45
            Dim DVal4 As Double
            '46
            Dim DDed5 As String
            '47
            Dim DVal5 As Double
            '48
            Dim DDed6 As String
            '49
            Dim DVal6 As Double
            '50
            Dim DDed7 As String
            '51
            Dim DVal7 As Double
            '52
            Dim DDed8 As String
            '53
            Dim DVal8 As Double
            '54
            Dim DDed9 As String
            '55
            Dim DVal9 As Double
            '56
            Dim DDed10 As String
            '57
            Dim DVal10 As Double
            '58
            Dim DDed11 As String
            '59
            Dim DVal11 As Double
            '60
            Dim DDed12 As String
            '61
            Dim DVal12 As Double
            '62
            Dim DDed13 As String
            '63
            Dim DVal13 As Double
            '64
            Dim DDed14 As String
            '65
            Dim DVal14 As Double
            '66
            Dim DDed15 As String
            '67
            Dim DVal15 As Double
            '
            Dim DVTotal As Double
            ''''''''''''''''''''''CContributions''''''''''''''''''''''
            '68
            Dim CCon1 As String
            '69
            Dim CVal1 As Double
            '70
            Dim CCon2 As String
            '71
            Dim CVal2 As Double
            '72
            Dim CCon3 As String
            '73
            Dim CVal3 As Double
            '74
            Dim CCon4 As String
            '75
            Dim CVal4 As Double
            '76
            Dim CCon5 As String
            '77
            Dim CVal5 As Double
            '78
            Dim CCon6 As String
            '79
            Dim CVal6 As Double
            '80
            Dim CCon7 As String
            '81
            Dim CVal7 As Double
            '82
            Dim CCon8 As String
            '83
            Dim CVal8 As Double
            '84
            Dim CCon9 As String
            '85
            Dim CVal9 As Double
            '86
            Dim CCon10 As String
            '87
            Dim CVal10 As Double
            '88
            Dim CCon11 As String
            '89
            Dim CVal11 As Double
            '90
            Dim CCon12 As String
            '91
            Dim CVal12 As Double
            '92
            Dim CCon13 As String
            '93
            Dim CVal13 As Double
            '94
            Dim CCon14 As String
            '95
            Dim CVal14 As Double
            '96
            Dim CCon15 As String
            '97
            Dim CVal15 As Double
            '98
            Dim CVTotal As Double
            '99
            Dim NetSalary As Double
            '100
            Dim CompanyCost As Double
            '101
            Dim PeriodCode As String

            Dim SITotal As Double

            Dim Reference As String

            Dim TotalOT1 As Double

            Dim TotalOT2 As Double

            Dim TotalOT3 As Double

            Dim TotalSal1 As Double

            Dim TotalSal2 As Double

            Dim TotalSectors As Double

            Dim TotalDutyHours As Double

            Dim TotalFlightHours As Double

            Dim TotalCommission As Double

            Dim TotalOverLay As Double

            Dim TotalTimeOff As Double

            Dim GenAnal1 As String

            Dim AL_Code1 As String = ""
            Dim AL_Code2 As String = ""
            Dim AL_Code3 As String = ""
            Dim AL_Code4 As String = ""
            Dim AL_Code5 As String = ""

            Dim AL_Desc1 As String = ""
            Dim AL_Desc2 As String = ""
            Dim AL_Desc3 As String = ""
            Dim AL_Desc4 As String = ""
            Dim AL_Desc5 As String = ""
            Dim Position As String = ""

            Dim TermDate As String = ""
            Dim SINumber As String = ""

            Dim BankBenName As String = ""
            Dim ComBank As String = ""
            Dim DOB As String = ""
            Dim Identity As String = ""
            Dim TIC As String = ""



            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                Application.DoEvents()

                EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                EmpName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpName))
                '''''''''''''''''''''''Earnings''''''''''''''''''''''
                EErn1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E1))
                EErn2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E2))
                EErn3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E3))
                EErn4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E4))
                EErn5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E5))
                EErn6 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E6))
                EErn7 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E7))
                EErn8 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E8))
                EErn9 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E9))
                EErn10 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E10))
                EErn11 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E11))
                EErn12 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E12))
                EErn13 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E13))
                EErn14 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E14))
                EErn15 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E15))
                ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                DDed1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D1))
                DDed2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D2))
                DDed3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D3))
                DDed4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D4))
                DDed5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D5))
                DDed6 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D6))
                DDed7 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D7))
                DDed8 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D8))
                DDed9 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D9))
                DDed10 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D10))
                DDed11 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D11))
                DDed12 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D12))
                DDed13 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D13))
                DDed14 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D14))
                DDed15 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D15))
                ''''''''''''''''''''''DContributions''''''''''''''''''''''
                CCon1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C1))
                CCon2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C2))
                CCon3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C3))
                CCon4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C4))
                CCon5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C5))
                CCon6 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C6))
                CCon7 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C7))
                CCon8 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C8))
                CCon9 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C9))
                CCon10 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C10))
                CCon11 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C11))
                CCon12 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C12))
                CCon13 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C13))
                CCon14 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C14))
                CCon15 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C15))

                AL_Code1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code1))
                AL_Code2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code2))
                AL_Code3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code3))
                AL_Code4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code4))
                AL_Code5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code5))

                AL_Desc1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc1))
                AL_Desc2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc2))
                AL_Desc3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc3))
                AL_Desc4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc4))
                AL_Desc5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc5))

                TermDate = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Termdate))
                SINumber = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_SINumber))

                BankBenName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_BankBenName))
                ComBank = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_ComBank))
                'DOB = DbNullToDate(MyDs.Tables(0).Rows(i).Item(Me.Column_DOB))

                DOB = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_DOB))

                Identity = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_Identity))
                TIC = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_TIC))
                Reference = MyDs.Tables(0).Rows(i).Item(Me.Column_ChequeNo)

                EVal1 = 0
                EVal2 = 0
                EVal3 = 0
                EVal4 = 0
                EVal5 = 0
                EVal6 = 0
                EVal7 = 0
                EVal8 = 0
                EVal9 = 0
                EVal10 = 0
                EVal11 = 0
                EVal12 = 0
                EVal13 = 0
                EVal14 = 0
                EVal15 = 0
                EVTotal = 0

                DVal1 = 0
                DVal2 = 0
                DVal3 = 0
                DVal4 = 0
                DVal5 = 0
                DVal6 = 0
                DVal7 = 0
                DVal8 = 0
                DVal9 = 0
                DVal10 = 0
                DVal11 = 0
                DVal12 = 0
                DVal13 = 0
                DVal14 = 0
                DVal15 = 0
                DVTotal = 0

                CVal1 = 0
                CVal2 = 0
                CVal3 = 0
                CVal4 = 0
                CVal5 = 0
                CVal6 = 0
                CVal7 = 0
                CVal8 = 0
                CVal9 = 0
                CVal10 = 0
                CVal11 = 0
                CVal12 = 0
                CVal13 = 0
                CVal14 = 0
                CVal15 = 0
                CVTotal = 0

                ActualUnits = 0
                NetSalary = 0
                CompanyCost = 0
                SITotal = 0
                TotalOT1 = 0
                TotalOT2 = 0
                TotalOT3 = 0
                TotalSal1 = 0
                TotalSal2 = 0
                TotalSectors = 0
                TotalDutyHours = 0
                TotalFlightHours = 0
                TotalCommission = 0
                TotalOverLay = 0
                TotalTimeOff = 0

                If EmpCode = "" Or EmpCode = "TOTALS " Then
                    'Exit For
                Else
                    Dim DoNotLoad As Boolean = False
                    Dim k As Integer
                    If Not DTx Is Nothing Then
                        For k = 0 To DTx.Rows.Count - 1
                            If EmpCode = DTx.Rows(k).Item(Me.Column_EmpCode) Then
                                DoNotLoad = True
                            End If
                        Next
                    End If
                    If Not DoNotLoad Then
                        For j = 0 To MyDs.Tables(0).Rows.Count - 1
                            'Dim tEmp As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_EmpCode))
                            ' Dim tA1 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code1))
                            ' Dim tA2 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code2))
                            ' Dim tA3 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code3))
                            ' Dim tA4 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code4))
                            ' Dim tA5 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code5))
                            If EmpCode = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_EmpCode)) Then
                                Dim tA1 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code1))
                                Dim tA2 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code2))
                                Dim tA3 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code3))
                                Dim tA4 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code4))
                                Dim tA5 As String = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code5))
                                Dim NoDifferenceInAnalysis As Boolean = False
                                If tA1 = AL_Code1 And tA2 = AL_Code2 And tA3 = AL_Code3 And tA4 = AL_Code4 And tA5 = AL_Code5 Then
                                    NoDifferenceInAnalysis = True
                                Else
                                    NoDifferenceInAnalysis = False
                                End If
                                If Me.CBConsolidateDepartmentOnYTD.CheckState = CheckState.Checked Then
                                    NoDifferenceInAnalysis = True
                                End If
                                If NoDifferenceInAnalysis Then

                                    ActualUnits = ActualUnits + MyDs.Tables(0).Rows(j).Item(Me.Column_ActualUnits)
                                    '''''''''''''''''''''''Earnings''''''''''''''''''''''
                                    EVal1 = EVal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV1)
                                    EVal2 = EVal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV2)
                                    EVal3 = EVal3 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV3)
                                    EVal4 = EVal4 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV4)
                                    EVal5 = EVal5 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV5)
                                    EVal6 = EVal6 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV6)
                                    EVal7 = EVal7 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV7)
                                    EVal8 = EVal8 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV8)
                                    EVal9 = EVal9 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV9)
                                    EVal10 = EVal10 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV10)
                                    EVal11 = EVal11 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV11)
                                    EVal12 = EVal12 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV12)
                                    EVal13 = EVal13 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV13)
                                    EVal14 = EVal14 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV14)
                                    EVal15 = EVal15 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV15)
                                    EVTotal = EVTotal + MyDs.Tables(0).Rows(j).Item(Me.Column_EVTotal)
                                    ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                                    DVal1 = DVal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV1)
                                    DVal2 = DVal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV2)
                                    DVal3 = DVal3 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV3)
                                    DVal4 = DVal4 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV4)
                                    DVal5 = DVal5 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV5)
                                    DVal6 = DVal6 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV6)
                                    DVal7 = DVal7 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV7)
                                    DVal8 = DVal8 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV8)
                                    DVal9 = DVal9 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV9)
                                    DVal10 = DVal10 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV10)
                                    DVal11 = DVal11 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV11)
                                    DVal12 = DVal12 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV12)
                                    DVal13 = DVal13 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV13)
                                    DVal14 = DVal14 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV14)
                                    DVal15 = DVal15 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV15)
                                    DVTotal = DVTotal + MyDs.Tables(0).Rows(j).Item(Me.Column_DVTotal)
                                    ''''''''''''''''''''''CContributions''''''''''''''''''''''
                                    CCon1 = DbNullToString((MyDs.Tables(0).Rows(j).Item(Me.Column_C1)))
                                    '69
                                    CVal1 = CVal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV1)
                                    CVal2 = CVal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV2)
                                    CVal3 = CVal3 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV3)
                                    CVal4 = CVal4 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV4)
                                    CVal5 = CVal5 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV5)
                                    CVal6 = CVal6 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV6)
                                    CVal7 = CVal7 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV7)
                                    CVal8 = CVal8 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV8)
                                    CVal9 = CVal9 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV9)
                                    CVal10 = CVal10 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV10)
                                    CVal11 = CVal11 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV11)
                                    CVal12 = CVal12 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV12)
                                    CVal13 = CVal13 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV13)
                                    CVal14 = CVal14 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV14)
                                    CVal15 = CVal15 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV15)
                                    CVTotal = CVTotal + MyDs.Tables(0).Rows(j).Item(Me.Column_CVTotal)

                                    NetSalary = NetSalary + MyDs.Tables(0).Rows(j).Item(Me.Column_NetSalary)
                                    CompanyCost = CompanyCost + MyDs.Tables(0).Rows(j).Item(Me.Column_CompanyCost)
                                    PeriodCode = ""
                                    SITotal = SITotal + MyDs.Tables(0).Rows(j).Item(Me.Column_SITotal)
                                    Reference = MyDs.Tables(0).Rows(j).Item(Me.Column_ChequeNo)
                                    TotalOT1 = TotalOT1 + MyDs.Tables(0).Rows(j).Item(Me.Column_Overtime1)
                                    TotalOT2 = TotalOT2 + MyDs.Tables(0).Rows(j).Item(Me.Column_OverTime2)
                                    TotalOT3 = TotalOT3 + MyDs.Tables(0).Rows(j).Item(Me.Column_OverTime3)

                                    TotalSal1 = TotalSal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_Salary1)
                                    TotalSal2 = TotalSal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_Salary2)

                                    TotalSectors = TotalSectors + MyDs.Tables(0).Rows(j).Item(Me.Column_sectors)
                                    TotalDutyHours = TotalDutyHours + MyDs.Tables(0).Rows(j).Item(Me.Column_dutyhours)
                                    TotalFlightHours = TotalFlightHours + MyDs.Tables(0).Rows(j).Item(Me.Column_flighthours)
                                    TotalCommission = TotalCommission + MyDs.Tables(0).Rows(j).Item(Me.Column_commission)
                                    TotalOverLay = TotalOverLay + MyDs.Tables(0).Rows(j).Item(Me.Column_OverLay)
                                    TotalTimeOff = TotalTimeOff + DbNullToDouble(MyDs.Tables(0).Rows(j).Item(Me.Column_TimeOff))

                                    GenAnal1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_GenAnal1))
                                    AL_Code1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code1))
                                    AL_Code2 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code2))
                                    AL_Code3 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code3))
                                    AL_Code4 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code4))
                                    AL_Code5 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code5))
                                    AL_Desc1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc1))
                                    AL_Desc2 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc2))
                                    AL_Desc3 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc3))
                                    AL_Desc4 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc4))
                                    AL_Desc5 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc5))

                                    TermDate = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_Termdate))
                                    SINumber = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_SINumber))

                                    BankBenName = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_BankBenName))
                                    ComBank = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_ComBank))
                                    'DOB = DbNullToDate(MyDs.Tables(0).Rows(j).Item(Me.Column_DOB))

                                    DOB = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_DOB))

                                    Identity = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_Identity))
                                    TIC = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_TIC))

                                    Position = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_Position))
                                Else
                                    ''''''Change 14/12/2020
                                    Dim r2 As DataRow = DTx.NewRow()
                                    r2(Me.Column_EmpCode) = EmpCode
                                    r2(Me.Column_EmpName) = EmpName
                                    r2(Me.Column_ActualUnits) = Format(ActualUnits, "0.00")
                                    r2(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                                    r2(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                                    r2(Me.Column_OverTime3) = Format(TotalOT3, "0.00")

                                    r2(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                                    r2(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                                    r2(Me.Column_sectors) = Format(TotalSectors, "0.00")
                                    r2(Me.Column_dutyhours) = Format(TotalDutyHours, "0.00")
                                    r2(Me.Column_flighthours) = Format(TotalFlightHours, "0.00")
                                    r2(Me.Column_commission) = Format(TotalCommission, "0.00")
                                    r2(Me.Column_OverLay) = Format(TotalOverLay, "0.00")
                                    r2(Me.Column_TimeOff) = Format(TotalTimeOff, "0.00")

                                    r2(Me.Column_GenAnal1) = GenAnal1
                                    r2(Me.Column_Position) = Position
                                    r2(Me.Column_AL_Code1) = AL_Code1
                                    r2(Me.Column_AL_Code2) = AL_Code2
                                    r2(Me.Column_AL_Code3) = AL_Code3
                                    r2(Me.Column_AL_Code4) = AL_Code4
                                    r2(Me.Column_AL_Code5) = AL_Code5

                                    r2(Me.Column_AL_Desc1) = AL_Desc1
                                    r2(Me.Column_AL_Desc2) = AL_Desc2
                                    r2(Me.Column_AL_Desc3) = AL_Desc3
                                    r2(Me.Column_AL_Desc4) = AL_Desc4
                                    r2(Me.Column_AL_Desc5) = AL_Desc5

                                    r2(Me.Column_Termdate) = TermDate
                                    r2(Me.Column_SINumber) = SINumber

                                    r2(Me.Column_BankBenName) = BankBenName
                                    r2(Me.Column_ComBank) = ComBank
                                    r2(Me.Column_DOB) = DOB
                                    r2(Me.Column_identity) = Identity
                                    r2(Me.Column_tic) = TIC



                                    '''''''''''''''''''''''Earnings''''''''''''''''''''''
                                    r2(Me.Column_E1) = EErn1                '
                                    r2(Me.Column_EV1) = EVal1                '
                                    r2(Me.Column_E2) = EErn2                '
                                    r2(Me.Column_EV2) = EVal2                '
                                    r2(Me.Column_E3) = EErn3                '
                                    r2(Me.Column_EV3) = EVal3                '
                                    r2(Me.Column_E4) = EErn4                '
                                    r2(Me.Column_EV4) = EVal4                '
                                    r2(Me.Column_E5) = EErn5                '
                                    r2(Me.Column_EV5) = EVal5                '
                                    r2(Me.Column_E6) = EErn6                '
                                    r2(Me.Column_EV6) = EVal6                '
                                    r2(Me.Column_E7) = EErn7                '
                                    r2(Me.Column_EV7) = EVal7                '
                                    r2(Me.Column_E8) = EErn8                '
                                    r2(Me.Column_EV8) = EVal8                '
                                    r2(Me.Column_E9) = EErn9                '
                                    r2(Me.Column_EV9) = EVal9                '
                                    r2(Me.Column_E10) = EErn10               '
                                    r2(Me.Column_EV10) = EVal10               '
                                    r2(Me.Column_E11) = EErn11               '
                                    r2(Me.Column_EV11) = EVal11               '
                                    r2(Me.Column_E12) = EErn12               '
                                    r2(Me.Column_EV12) = EVal12               '
                                    r2(Me.Column_E13) = EErn13               '
                                    r2(Me.Column_EV13) = EVal13               '
                                    r2(Me.Column_E14) = EErn14               '
                                    r2(Me.Column_EV14) = EVal14               '
                                    r2(Me.Column_E15) = EErn15               '
                                    r2(Me.Column_EV15) = EVal15               '
                                    r2(Me.Column_EVTotal) = EVTotal
                                    ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                                    r2(Me.Column_D1) = DDed1                '
                                    r2(Me.Column_DV1) = DVal1                '
                                    r2(Me.Column_D2) = DDed2                '
                                    r2(Me.Column_DV2) = DVal2                '
                                    r2(Me.Column_D3) = DDed3                '
                                    r2(Me.Column_DV3) = DVal3                '
                                    r2(Me.Column_D4) = DDed4                '
                                    r2(Me.Column_DV4) = DVal4                '
                                    r2(Me.Column_D5) = DDed5                '
                                    r2(Me.Column_DV5) = DVal5                '
                                    r2(Me.Column_D6) = DDed6                '
                                    r2(Me.Column_DV6) = DVal6                '
                                    r2(Me.Column_D7) = DDed7                '
                                    r2(Me.Column_DV7) = DVal7                '
                                    r2(Me.Column_D8) = DDed8                '
                                    r2(Me.Column_DV8) = DVal8                '
                                    r2(Me.Column_D9) = DDed9                '
                                    r2(Me.Column_DV9) = DVal9                '
                                    r2(Me.Column_D10) = DDed10               '
                                    r2(Me.Column_DV10) = DVal10               '
                                    r2(Me.Column_D11) = DDed11               '
                                    r2(Me.Column_DV11) = DVal11               '
                                    r2(Me.Column_D12) = DDed12               '
                                    r2(Me.Column_DV12) = DVal12               '
                                    r2(Me.Column_D13) = DDed13               '
                                    r2(Me.Column_DV13) = DVal13               '
                                    r2(Me.Column_D14) = DDed14               '
                                    r2(Me.Column_DV14) = DVal14               '
                                    r2(Me.Column_D15) = DDed15               '
                                    r2(Me.Column_DV15) = DVal15               '
                                    r2(Me.Column_DVTotal) = DVTotal
                                    ''''''''''''''''''''''CContributions''''''''''''''''''''''
                                    r2(Me.Column_C1) = CCon1                '
                                    r2(Me.Column_CV1) = CVal1                '
                                    r2(Me.Column_C2) = CCon2                '
                                    r2(Me.Column_CV2) = CVal2                '
                                    r2(Me.Column_C3) = CCon3                '
                                    r2(Me.Column_CV3) = CVal3                '
                                    r2(Me.Column_C4) = CCon4                '
                                    r2(Me.Column_CV4) = CVal4                '
                                    r2(Me.Column_C5) = CCon5                '
                                    r2(Me.Column_CV5) = CVal5                '
                                    r2(Me.Column_C6) = CCon6                '
                                    r2(Me.Column_CV6) = CVal6                '
                                    r2(Me.Column_C7) = CCon7                '
                                    r2(Me.Column_CV7) = CVal7                '
                                    r2(Me.Column_C8) = CCon8                '
                                    r2(Me.Column_CV8) = CVal8                '
                                    r2(Me.Column_C9) = CCon9                '
                                    r2(Me.Column_CV9) = CVal9                '
                                    r2(Me.Column_C10) = CCon10               '
                                    r2(Me.Column_CV10) = CVal10               '
                                    r2(Me.Column_C11) = CCon11               '
                                    r2(Me.Column_CV11) = CVal11               '
                                    r2(Me.Column_C12) = CCon12               '
                                    r2(Me.Column_CV12) = CVal12               '
                                    r2(Me.Column_C13) = CCon13               '
                                    r2(Me.Column_CV13) = CVal13               '
                                    r2(Me.Column_C14) = CCon14               '
                                    r2(Me.Column_CV14) = CVal14               '
                                    r2(Me.Column_C15) = CCon15               '
                                    r2(Me.Column_CV15) = CVal15               '
                                    r2(Me.Column_CVTotal) = CVTotal
                                    r2(Me.Column_NetSalary) = Format(NetSalary, "0.00")
                                    '100
                                    r2(Me.Column_CompanyCost) = Format(CompanyCost, "0.00")
                                    '101
                                    r2(Me.Column_PeriodCode) = ""
                                    r2(Me.Column_SITotal) = Format(SITotal, "0.00")
                                    r2(Me.Column_ChequeNo) = Reference
                                    DTx.Rows.Add(r2)



                                    ActualUnits = MyDs.Tables(0).Rows(j).Item(Me.Column_ActualUnits)
                                    '''''''''''''''''''''''Earnings''''''''''''''''''''''
                                    EVal1 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV1)
                                    EVal2 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV2)
                                    EVal3 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV3)
                                    EVal4 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV4)
                                    EVal5 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV5)
                                    EVal6 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV6)
                                    EVal7 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV7)
                                    EVal8 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV8)
                                    EVal9 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV9)
                                    EVal10 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV10)
                                    EVal11 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV11)
                                    EVal12 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV12)
                                    EVal13 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV13)
                                    EVal14 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV14)
                                    EVal15 = MyDs.Tables(0).Rows(j).Item(Me.Column_EV15)
                                    EVTotal = MyDs.Tables(0).Rows(j).Item(Me.Column_EVTotal)
                                    ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                                    DVal1 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV1)
                                    DVal2 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV2)
                                    DVal3 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV3)
                                    DVal4 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV4)
                                    DVal5 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV5)
                                    DVal6 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV6)
                                    DVal7 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV7)
                                    DVal8 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV8)
                                    DVal9 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV9)
                                    DVal10 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV10)
                                    DVal11 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV11)
                                    DVal12 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV12)
                                    DVal13 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV13)
                                    DVal14 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV14)
                                    DVal15 = MyDs.Tables(0).Rows(j).Item(Me.Column_DV15)
                                    DVTotal = MyDs.Tables(0).Rows(j).Item(Me.Column_DVTotal)
                                    ''''''''''''''''''''''CContributions''''''''''''''''''''''
                                    CCon1 = DbNullToString((MyDs.Tables(0).Rows(j).Item(Me.Column_C1)))
                                    CVal1 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV1)
                                    CVal2 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV2)
                                    CVal3 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV3)
                                    CVal4 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV4)
                                    CVal5 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV5)
                                    CVal6 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV6)
                                    CVal7 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV7)
                                    CVal8 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV8)
                                    CVal9 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV9)
                                    CVal10 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV10)
                                    CVal11 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV11)
                                    CVal12 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV12)
                                    CVal13 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV13)
                                    CVal14 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV14)
                                    CVal15 = MyDs.Tables(0).Rows(j).Item(Me.Column_CV15)
                                    CVTotal = MyDs.Tables(0).Rows(j).Item(Me.Column_CVTotal)

                                    NetSalary = MyDs.Tables(0).Rows(j).Item(Me.Column_NetSalary)
                                    CompanyCost = MyDs.Tables(0).Rows(j).Item(Me.Column_CompanyCost)
                                    PeriodCode = ""
                                    SITotal = MyDs.Tables(0).Rows(j).Item(Me.Column_SITotal)
                                    Reference = MyDs.Tables(0).Rows(j).Item(Me.Column_ChequeNo)
                                    TotalOT1 = MyDs.Tables(0).Rows(j).Item(Me.Column_Overtime1)
                                    TotalOT2 = MyDs.Tables(0).Rows(j).Item(Me.Column_OverTime2)
                                    TotalOT3 = MyDs.Tables(0).Rows(j).Item(Me.Column_OverTime3)

                                    TotalSal1 = MyDs.Tables(0).Rows(j).Item(Me.Column_Salary1)
                                    TotalSal2 = MyDs.Tables(0).Rows(j).Item(Me.Column_Salary2)

                                    TotalSectors = MyDs.Tables(0).Rows(j).Item(Me.Column_sectors)
                                    TotalDutyHours = MyDs.Tables(0).Rows(j).Item(Me.Column_dutyhours)
                                    TotalFlightHours = MyDs.Tables(0).Rows(j).Item(Me.Column_flighthours)
                                    TotalCommission = MyDs.Tables(0).Rows(j).Item(Me.Column_commission)
                                    TotalOverLay = MyDs.Tables(0).Rows(j).Item(Me.Column_OverLay)
                                    TotalTimeOff = DbNullToDouble(MyDs.Tables(0).Rows(j).Item(Me.Column_TimeOff))

                                    GenAnal1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_GenAnal1))
                                    AL_Code1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code1))
                                    AL_Code2 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code2))
                                    AL_Code3 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code3))
                                    AL_Code4 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code4))
                                    AL_Code5 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code5))
                                    AL_Desc1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc1))
                                    AL_Desc2 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc2))
                                    AL_Desc3 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc3))
                                    AL_Desc4 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc4))
                                    AL_Desc5 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Desc5))

                                    TermDate = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_Termdate))
                                    SINumber = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_SINumber))

                                    BankBenName = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_BankBenName))
                                    ComBank = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_ComBank))

                                    'DOB = DbNullToDate(MyDs.Tables(0).Rows(j).Item(Me.Column_DOB))
                                    DOB = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_DOB))

                                    Identity = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_Identity))
                                    TIC = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_TIC))

                                    Position = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_Position))

                                    Application.DoEvents()
                                    '''''''''''''''''''''''

                                End If
                            End If

                        Next


                        Dim r As DataRow = DTx.NewRow()
                        r(Me.Column_EmpCode) = EmpCode
                        r(Me.Column_EmpName) = EmpName
                        r(Me.Column_ActualUnits) = Format(ActualUnits, "0.00")
                        r(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                        r(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                        r(Me.Column_OverTime3) = Format(TotalOT3, "0.00")

                        r(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                        r(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                        r(Me.Column_sectors) = Format(TotalSectors, "0.00")
                        r(Me.Column_dutyhours) = Format(TotalDutyHours, "0.00")
                        r(Me.Column_flighthours) = Format(TotalFlightHours, "0.00")
                        r(Me.Column_commission) = Format(TotalCommission, "0.00")
                        r(Me.Column_OverLay) = Format(TotalOverLay, "0.00")
                        r(Me.Column_TimeOff) = Format(TotalTimeOff, "0.00")

                        r(Me.Column_GenAnal1) = GenAnal1
                        r(Me.Column_Position) = Position
                        r(Me.Column_AL_Code1) = AL_Code1
                        r(Me.Column_AL_Code2) = AL_Code2
                        r(Me.Column_AL_Code3) = AL_Code3
                        r(Me.Column_AL_Code4) = AL_Code4
                        r(Me.Column_AL_Code5) = AL_Code5

                        r(Me.Column_AL_Desc1) = AL_Desc1
                        r(Me.Column_AL_Desc2) = AL_Desc2
                        r(Me.Column_AL_Desc3) = AL_Desc3
                        r(Me.Column_AL_Desc4) = AL_Desc4
                        r(Me.Column_AL_Desc5) = AL_Desc5

                        r(Me.Column_Termdate) = TermDate
                        r(Me.Column_SINumber) = SINumber

                        r(Me.Column_BankBenName) = BankBenName
                        r(Me.Column_ComBank) = ComBank
                        r(Me.Column_DOB) = DOB
                        r(Me.Column_Identity) = Identity
                        r(Me.Column_TIC) = TIC


                        '''''''''''''''''''''''Earnings''''''''''''''''''''''
                        r(Me.Column_E1) = EErn1                '
                        r(Me.Column_EV1) = EVal1                '
                        r(Me.Column_E2) = EErn2                '
                        r(Me.Column_EV2) = EVal2                '
                        r(Me.Column_E3) = EErn3                '
                        r(Me.Column_EV3) = EVal3                '
                        r(Me.Column_E4) = EErn4                '
                        r(Me.Column_EV4) = EVal4                '
                        r(Me.Column_E5) = EErn5                '
                        r(Me.Column_EV5) = EVal5                '
                        r(Me.Column_E6) = EErn6                '
                        r(Me.Column_EV6) = EVal6                '
                        r(Me.Column_E7) = EErn7                '
                        r(Me.Column_EV7) = EVal7                '
                        r(Me.Column_E8) = EErn8                '
                        r(Me.Column_EV8) = EVal8                '
                        r(Me.Column_E9) = EErn9                '
                        r(Me.Column_EV9) = EVal9                '
                        r(Me.Column_E10) = EErn10               '
                        r(Me.Column_EV10) = EVal10               '
                        r(Me.Column_E11) = EErn11               '
                        r(Me.Column_EV11) = EVal11               '
                        r(Me.Column_E12) = EErn12               '
                        r(Me.Column_EV12) = EVal12               '
                        r(Me.Column_E13) = EErn13               '
                        r(Me.Column_EV13) = EVal13               '
                        r(Me.Column_E14) = EErn14               '
                        r(Me.Column_EV14) = EVal14               '
                        r(Me.Column_E15) = EErn15               '
                        r(Me.Column_EV15) = EVal15               '
                        r(Me.Column_EVTotal) = EVTotal
                        ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                        r(Me.Column_D1) = DDed1                '
                        r(Me.Column_DV1) = DVal1                '
                        r(Me.Column_D2) = DDed2                '
                        r(Me.Column_DV2) = DVal2                '
                        r(Me.Column_D3) = DDed3                '
                        r(Me.Column_DV3) = DVal3                '
                        r(Me.Column_D4) = DDed4                '
                        r(Me.Column_DV4) = DVal4                '
                        r(Me.Column_D5) = DDed5                '
                        r(Me.Column_DV5) = DVal5                '
                        r(Me.Column_D6) = DDed6                '
                        r(Me.Column_DV6) = DVal6                '
                        r(Me.Column_D7) = DDed7                '
                        r(Me.Column_DV7) = DVal7                '
                        r(Me.Column_D8) = DDed8                '
                        r(Me.Column_DV8) = DVal8                '
                        r(Me.Column_D9) = DDed9                '
                        r(Me.Column_DV9) = DVal9                '
                        r(Me.Column_D10) = DDed10               '
                        r(Me.Column_DV10) = DVal10               '
                        r(Me.Column_D11) = DDed11               '
                        r(Me.Column_DV11) = DVal11               '
                        r(Me.Column_D12) = DDed12               '
                        r(Me.Column_DV12) = DVal12               '
                        r(Me.Column_D13) = DDed13               '
                        r(Me.Column_DV13) = DVal13               '
                        r(Me.Column_D14) = DDed14               '
                        r(Me.Column_DV14) = DVal14               '
                        r(Me.Column_D15) = DDed15               '
                        r(Me.Column_DV15) = DVal15               '
                        r(Me.Column_DVTotal) = DVTotal
                        ''''''''''''''''''''''CContributions''''''''''''''''''''''
                        r(Me.Column_C1) = CCon1                '
                        r(Me.Column_CV1) = CVal1                '
                        r(Me.Column_C2) = CCon2                '
                        r(Me.Column_CV2) = CVal2                '
                        r(Me.Column_C3) = CCon3                '
                        r(Me.Column_CV3) = CVal3                '
                        r(Me.Column_C4) = CCon4                '
                        r(Me.Column_CV4) = CVal4                '
                        r(Me.Column_C5) = CCon5                '
                        r(Me.Column_CV5) = CVal5                '
                        r(Me.Column_C6) = CCon6                '
                        r(Me.Column_CV6) = CVal6                '
                        r(Me.Column_C7) = CCon7                '
                        r(Me.Column_CV7) = CVal7                '
                        r(Me.Column_C8) = CCon8                '
                        r(Me.Column_CV8) = CVal8                '
                        r(Me.Column_C9) = CCon9                '
                        r(Me.Column_CV9) = CVal9                '
                        r(Me.Column_C10) = CCon10               '
                        r(Me.Column_CV10) = CVal10               '
                        r(Me.Column_C11) = CCon11               '
                        r(Me.Column_CV11) = CVal11               '
                        r(Me.Column_C12) = CCon12               '
                        r(Me.Column_CV12) = CVal12               '
                        r(Me.Column_C13) = CCon13               '
                        r(Me.Column_CV13) = CVal13               '
                        r(Me.Column_C14) = CCon14               '
                        r(Me.Column_CV14) = CVal14               '
                        r(Me.Column_C15) = CCon15               '
                        r(Me.Column_CV15) = CVal15               '
                        r(Me.Column_CVTotal) = CVTotal
                        r(Me.Column_NetSalary) = Format(NetSalary, "0.00")
                        '100
                        r(Me.Column_CompanyCost) = Format(CompanyCost, "0.00")
                        '101
                        r(Me.Column_PeriodCode) = ""
                        r(Me.Column_SITotal) = Format(SITotal, "0.00")
                        r(Me.Column_ChequeNo) = Reference
                        DTx.Rows.Add(r)

                        Application.DoEvents()
                    End If
                End If
            Next
            Dim EstimateCOL As Integer
            DG1.DataSource = MyDsX.Tables(0)
            Dim Ern13Estimate As String
            Ern13Estimate = Global1.Business.GetEarningCodeFor13Estimate()
            EstimateFound = False
            For i = Column_E1 To Column_E15
                If Ern13Estimate = DbNullToString(MyDsX.Tables(0).Rows(0).Item(i)) Then
                    EstimateCOL = i
                    EstimateFound = True
                    Exit For
                End If
            Next
            Dim DsEmp As DataSet
            Dim PrdGrp As New cPrMsPeriodGroups
            PrdGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            DsEmp = Global1.Business.GetAllemployeesWithTerminationDate(PrdGrp.TemGrpCode)
            If CheckDataSet(DsEmp) Then
                For i = 0 To DsEmp.Tables(0).Rows.Count - 1
                    EmpCode = DsEmp.Tables(0).Rows(i).Item(0)
                    For j = 0 To MyDsX.Tables(0).Rows.Count - 1
                        If EmpCode = MyDsX.Tables(0).Rows(j).Item(Me.Column_EmpCode) Then
                            If EstimateFound Then
                                Dim Est13 As Double
                                Est13 = DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(EstimateCOL + 1))
                                MyDsX.Tables(0).Rows(j).Item(EstimateCOL + 1) = 0
                                MyDsX.Tables(0).Rows(j).Item(Me.Column_EVTotal) = MyDsX.Tables(0).Rows(j).Item(Me.Column_EVTotal) '- Est13
                                MyDsX.Tables(0).Rows(j).Item(Me.Column_CompanyCost) = MyDsX.Tables(0).Rows(j).Item(Me.Column_CompanyCost) '- Est13
                                Exit For
                            End If
                        End If
                    Next
                Next
            End If



            ' Totals Calculation ----------------
            ActualUnits = 0
            TotalOT1 = 0
            TotalOT2 = 0
            TotalOT3 = 0
            TotalSal1 = 0
            TotalSal2 = 0
            EVal1 = 0
            EVal2 = 0
            EVal3 = 0
            EVal4 = 0
            EVal5 = 0
            EVal6 = 0
            EVal7 = 0
            EVal8 = 0
            EVal9 = 0
            EVal10 = 0
            EVal11 = 0
            EVal12 = 0
            EVal13 = 0
            EVal14 = 0
            EVal15 = 0
            EVTotal = 0
            ''''''''''''''''''''''DDeductions''''''''''''''''''''''
            DVal1 = 0
            DVal2 = 0
            DVal3 = 0
            DVal4 = 0
            DVal5 = 0
            DVal6 = 0
            DVal7 = 0
            DVal8 = 0
            DVal9 = 0
            DVal10 = 0
            DVal11 = 0
            DVal12 = 0
            DVal13 = 0
            DVal14 = 0
            DVal15 = 0
            DVTotal = 0
            ''''''''''''''''''''''CContributions''''''''''''''''''''''
            CVal1 = 0
            CVal2 = 0
            CVal3 = 0
            CVal4 = 0
            CVal5 = 0
            CVal6 = 0
            CVal7 = 0
            CVal8 = 0
            CVal9 = 0
            CVal10 = 0
            CVal11 = 0
            CVal12 = 0
            CVal13 = 0
            CVal14 = 0
            CVal15 = 0
            CVTotal = 0


            NetSalary = 0
            CompanyCost = 0
            PeriodCode = ""
            SITotal = 0
            Reference = ""

            TotalSectors = 0
            TotalDutyHours = 0
            TotalFlightHours = 0
            TotalCommission = 0
            TotalOverLay = 0
            TotalTimeOff = 0

            For j = 0 To MyDsX.Tables(0).Rows.Count - 1

                Application.DoEvents()
                ActualUnits = ActualUnits + MyDsX.Tables(0).Rows(j).Item(Me.Column_ActualUnits)
                TotalOT1 = TotalOT1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_Overtime1)
                TotalOT2 = TotalOT2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_OverTime2)
                TotalOT3 = TotalOT3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_OverTime3)

                TotalSal1 = TotalSal1 + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_Salary1))
                TotalSal2 = TotalSal2 + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_Salary2))

                TotalSectors = TotalSectors + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_sectors))
                TotalDutyHours = TotalDutyHours + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_dutyhours))
                TotalFlightHours = TotalFlightHours + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_flighthours))
                TotalCommission = TotalCommission + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_commission))
                TotalOverLay = TotalOverLay + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_OverLay))
                TotalTimeOff = TotalTimeOff + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_TimeOff))


                EVal1 = EVal1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV1)
                EVal2 = EVal2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV2)
                EVal3 = EVal3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV3)
                EVal4 = EVal4 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV4)
                EVal5 = EVal5 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV5)
                EVal6 = EVal6 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV6)
                EVal7 = EVal7 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV7)
                EVal8 = EVal8 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV8)
                EVal9 = EVal9 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV9)
                EVal10 = EVal10 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV10)
                EVal11 = EVal11 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV11)
                EVal12 = EVal12 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV12)
                EVal13 = EVal13 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV13)
                EVal14 = EVal14 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV14)
                EVal15 = EVal15 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV15)
                EVTotal = EVTotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_EVTotal)
                ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                DVal1 = DVal1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV1)
                DVal2 = DVal2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV2)
                DVal3 = DVal3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV3)
                DVal4 = DVal4 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV4)
                DVal5 = DVal5 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV5)
                DVal6 = DVal6 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV6)
                DVal7 = DVal7 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV7)
                DVal8 = DVal8 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV8)
                DVal9 = DVal9 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV9)
                DVal10 = DVal10 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV10)
                DVal11 = DVal11 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV11)
                DVal12 = DVal12 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV12)
                DVal13 = DVal13 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV13)
                DVal14 = DVal14 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV14)
                DVal15 = DVal15 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV15)
                DVTotal = DVTotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_DVTotal)
                ''''''''''''''''''''''CContributions''''''''''''''''''''''
                CVal1 = CVal1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV1)
                CVal2 = CVal2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV2)
                CVal3 = CVal3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV3)
                CVal4 = CVal4 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV4)
                CVal5 = CVal5 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV5)
                CVal6 = CVal6 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV6)
                CVal7 = CVal7 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV7)
                CVal8 = CVal8 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV8)
                CVal9 = CVal9 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV9)
                CVal10 = CVal10 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV10)
                CVal11 = CVal11 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV11)
                CVal12 = CVal12 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV12)
                CVal13 = CVal13 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV13)
                CVal14 = CVal14 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV14)
                CVal15 = CVal15 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV15)
                CVTotal = CVTotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_CVTotal)

                NetSalary = NetSalary + MyDsX.Tables(0).Rows(j).Item(Me.Column_NetSalary)
                CompanyCost = CompanyCost + MyDsX.Tables(0).Rows(j).Item(Me.Column_CompanyCost)
                PeriodCode = ""
                SITotal = SITotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_SITotal)
                Reference = ""
                Application.DoEvents()
            Next

            Dim rE As DataRow = DTx.NewRow()
            DTx.Rows.Add(rE)

            Dim rX As DataRow = DTx.NewRow()
            rX(Me.Column_EmpCode) = "TOTAL"
            rX(Me.Column_EmpName) = "ALL Employees"
            rX(Me.Column_ActualUnits) = Format(ActualUnits, "0.00")
            rX(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
            rX(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
            rX(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
            rX(Me.Column_Salary1) = Format(TotalSal1, "0.00")
            rX(Me.Column_Salary2) = Format(TotalSal2, "0.00")


            rX(Me.Column_sectors) = Format(TotalSectors, "0.00")
            rX(Me.Column_dutyhours) = Format(TotalDutyHours, "0.00")
            rX(Me.Column_flighthours) = Format(TotalFlightHours, "0.00")
            rX(Me.Column_commission) = Format(TotalCommission, "0.00")
            rX(Me.Column_OverLay) = Format(TotalOverLay, "0.00")
            rX(Me.Column_TimeOff) = Format(TotalTimeOff, "0.00")

            '''''''''''''''''''''''Earnings''''''''''''''''''''''
            rX(Me.Column_E1) = EErn1                '
            rX(Me.Column_EV1) = EVal1                '
            rX(Me.Column_E2) = EErn2                '
            rX(Me.Column_EV2) = EVal2                '
            rX(Me.Column_E3) = EErn3                '
            rX(Me.Column_EV3) = EVal3                '
            rX(Me.Column_E4) = EErn4                '
            rX(Me.Column_EV4) = EVal4                '
            rX(Me.Column_E5) = EErn5                '
            rX(Me.Column_EV5) = EVal5                '
            rX(Me.Column_E6) = EErn6                '
            rX(Me.Column_EV6) = EVal6                '
            rX(Me.Column_E7) = EErn7                '
            rX(Me.Column_EV7) = EVal7                '
            rX(Me.Column_E8) = EErn8                '
            rX(Me.Column_EV8) = EVal8                '
            rX(Me.Column_E9) = EErn9                '
            rX(Me.Column_EV9) = EVal9                '
            rX(Me.Column_E10) = EErn10               '
            rX(Me.Column_EV10) = EVal10               '
            rX(Me.Column_E11) = EErn11               '
            rX(Me.Column_EV11) = EVal11               '
            rX(Me.Column_E12) = EErn12               '
            rX(Me.Column_EV12) = EVal12               '
            rX(Me.Column_E13) = EErn13               '
            rX(Me.Column_EV13) = EVal13               '
            rX(Me.Column_E14) = EErn14               '
            rX(Me.Column_EV14) = EVal14               '
            rX(Me.Column_E15) = EErn15               '
            rX(Me.Column_EV15) = EVal15               '
            rX(Me.Column_EVTotal) = EVTotal
            ''''''''''''''''''''''DDeductions''''''''''''''''''''''
            rX(Me.Column_D1) = DDed1                '
            rX(Me.Column_DV1) = DVal1                '
            rX(Me.Column_D2) = DDed2                '
            rX(Me.Column_DV2) = DVal2                '
            rX(Me.Column_D3) = DDed3                '
            rX(Me.Column_DV3) = DVal3                '
            rX(Me.Column_D4) = DDed4                '
            rX(Me.Column_DV4) = DVal4                '
            rX(Me.Column_D5) = DDed5                '
            rX(Me.Column_DV5) = DVal5                '
            rX(Me.Column_D6) = DDed6                '
            rX(Me.Column_DV6) = DVal6                '
            rX(Me.Column_D7) = DDed7                '
            rX(Me.Column_DV7) = DVal7                '
            rX(Me.Column_D8) = DDed8                '
            rX(Me.Column_DV8) = DVal8                '
            rX(Me.Column_D9) = DDed9                '
            rX(Me.Column_DV9) = DVal9                '
            rX(Me.Column_D10) = DDed10               '
            rX(Me.Column_DV10) = DVal10               '
            rX(Me.Column_D11) = DDed11               '
            rX(Me.Column_DV11) = DVal11               '
            rX(Me.Column_D12) = DDed12               '
            rX(Me.Column_DV12) = DVal12               '
            rX(Me.Column_D13) = DDed13               '
            rX(Me.Column_DV13) = DVal13               '
            rX(Me.Column_D14) = DDed14               '
            rX(Me.Column_DV14) = DVal14               '
            rX(Me.Column_D15) = DDed15               '
            rX(Me.Column_DV15) = DVal15               '
            rX(Me.Column_DVTotal) = DVTotal
            ''''''''''''''''''''''CContributions''''''''''''''''''''''
            rX(Me.Column_C1) = CCon1                '
            rX(Me.Column_CV1) = CVal1                '
            rX(Me.Column_C2) = CCon2                '
            rX(Me.Column_CV2) = CVal2                '
            rX(Me.Column_C3) = CCon3                '
            rX(Me.Column_CV3) = CVal3                '
            rX(Me.Column_C4) = CCon4                '
            rX(Me.Column_CV4) = CVal4                '
            rX(Me.Column_C5) = CCon5                '
            rX(Me.Column_CV5) = CVal5                '
            rX(Me.Column_C6) = CCon6                '
            rX(Me.Column_CV6) = CVal6                '
            rX(Me.Column_C7) = CCon7                '
            rX(Me.Column_CV7) = CVal7                '
            rX(Me.Column_C8) = CCon8                '
            rX(Me.Column_CV8) = CVal8                '
            rX(Me.Column_C9) = CCon9                '
            rX(Me.Column_CV9) = CVal9                '
            rX(Me.Column_C10) = CCon10               '
            rX(Me.Column_CV10) = CVal10               '
            rX(Me.Column_C11) = CCon11               '
            rX(Me.Column_CV11) = CVal11               '
            rX(Me.Column_C12) = CCon12               '
            rX(Me.Column_CV12) = CVal12               '
            rX(Me.Column_C13) = CCon13               '
            rX(Me.Column_CV13) = CVal13               '
            rX(Me.Column_C14) = CCon14               '
            rX(Me.Column_CV14) = CVal14               '
            rX(Me.Column_C15) = CCon15               '
            rX(Me.Column_CV15) = CVal15               '
            rX(Me.Column_CVTotal) = CVTotal
            rX(Me.Column_NetSalary) = Format(NetSalary, "0.00")
            '100
            rX(Me.Column_CompanyCost) = Format(CompanyCost, "0.00")
            '101
            rX(Me.Column_PeriodCode) = ""
            rX(Me.Column_SITotal) = Format(SITotal, "0.00")
            rX(Me.Column_ChequeNo) = ""
            DTx.Rows.Add(rX)

            Dim rE2 As DataRow = DTx.NewRow()
            DTx.Rows.Add(rE2)

            Application.DoEvents()
        End If

    End Sub
    Private Sub AnalysisReport(ByVal GroupByGenAnal1 As Boolean, ByVal GroupBy2 As Boolean, ByVal SortByEDCReportingSequence As Boolean, ByVal GroupByAnalysis3 As Boolean, ByVal GroupByanal2AndAnal3 As Boolean)
        YTDReport = True
        PrepareReport(SortByEDCReportingSequence)

        MyDsX = New DataSet
        Dim EstimateFound As Boolean = False
        Dim DTx As New DataTable
        If CheckDataSet(MyDs) Then
            DTx = MyDs.Tables(0).Copy
            MyDsX.Tables.Add(DTx)
            MyDsX.Tables(0).Rows.Clear()
            Dim i As Integer
            Dim j As Integer
            Dim CurEmpCode As String = "-1"


            Dim EmpCode As String
            '3
            Dim EmpName As String
            '4
            Dim ActualUnits As Double
            '''''''''''''''''''''''Earnings''''''''''''''''''''''
            '8
            Dim EErn1 As String
            '9
            Dim EVal1 As Double
            '10
            Dim EErn2 As String
            '11
            Dim EVal2 As Double
            '12
            Dim EErn3 As String
            '13
            Dim EVal3 As Double
            '14
            Dim EErn4 As String
            '15
            Dim EVal4 As Double
            '16
            Dim EErn5 As String
            '17
            Dim EVal5 As Double
            '18
            Dim EErn6 As String
            '19
            Dim EVal6 As Double
            '20
            Dim EErn7 As String
            '21
            Dim EVal7 As Double
            '22
            Dim EErn8 As String
            '23
            Dim EVal8 As Double
            '24
            Dim EErn9 As String
            '25
            Dim EVal9 As Double
            '26
            Dim EErn10 As String
            '27
            Dim EVal10 As Double
            '28
            Dim EErn11 As String
            '29
            Dim EVal11 As Double
            '30
            Dim EErn12 As String
            '31
            Dim EVal12 As Double
            '32
            Dim EErn13 As String
            '33
            Dim EVal13 As Double
            '34
            Dim EErn14 As String
            '35
            Dim EVal14 As Double
            '36
            Dim EErn15 As String
            '37
            Dim EVal15 As Double
            '
            Dim EVTotal As Double
            ''''''''''''''''''''''DDeductions''''''''''''''''''''''
            '38
            Dim DDed1 As String
            '39
            Dim DVal1 As Double
            '40
            Dim DDed2 As String
            '41
            Dim DVal2 As Double
            '42
            Dim DDed3 As String
            '43
            Dim DVal3 As Double
            '44
            Dim DDed4 As String
            '45
            Dim DVal4 As Double
            '46
            Dim DDed5 As String
            '47
            Dim DVal5 As Double
            '48
            Dim DDed6 As String
            '49
            Dim DVal6 As Double
            '50
            Dim DDed7 As String
            '51
            Dim DVal7 As Double
            '52
            Dim DDed8 As String
            '53
            Dim DVal8 As Double
            '54
            Dim DDed9 As String
            '55
            Dim DVal9 As Double
            '56
            Dim DDed10 As String
            '57
            Dim DVal10 As Double
            '58
            Dim DDed11 As String
            '59
            Dim DVal11 As Double
            '60
            Dim DDed12 As String
            '61
            Dim DVal12 As Double
            '62
            Dim DDed13 As String
            '63
            Dim DVal13 As Double
            '64
            Dim DDed14 As String
            '65
            Dim DVal14 As Double
            '66
            Dim DDed15 As String
            '67
            Dim DVal15 As Double
            '
            Dim DVTotal As Double
            ''''''''''''''''''''''CContributions''''''''''''''''''''''
            '68
            Dim CCon1 As String
            '69
            Dim CVal1 As Double
            '70
            Dim CCon2 As String
            '71
            Dim CVal2 As Double
            '72
            Dim CCon3 As String
            '73
            Dim CVal3 As Double
            '74
            Dim CCon4 As String
            '75
            Dim CVal4 As Double
            '76
            Dim CCon5 As String
            '77
            Dim CVal5 As Double
            '78
            Dim CCon6 As String
            '79
            Dim CVal6 As Double
            '80
            Dim CCon7 As String
            '81
            Dim CVal7 As Double
            '82
            Dim CCon8 As String
            '83
            Dim CVal8 As Double
            '84
            Dim CCon9 As String
            '85
            Dim CVal9 As Double
            '86
            Dim CCon10 As String
            '87
            Dim CVal10 As Double
            '88
            Dim CCon11 As String
            '89
            Dim CVal11 As Double
            '90
            Dim CCon12 As String
            '91
            Dim CVal12 As Double
            '92
            Dim CCon13 As String
            '93
            Dim CVal13 As Double
            '94
            Dim CCon14 As String
            '95
            Dim CVal14 As Double
            '96
            Dim CCon15 As String
            '97
            Dim CVal15 As Double
            '98
            Dim CVTotal As Double
            '99
            Dim NetSalary As Double
            '100
            Dim CompanyCost As Double
            '101
            Dim PeriodCode As String

            Dim SITotal As Double

            Dim Reference As String

            Dim TotalOT1 As Double

            Dim TotalOT2 As Double

            Dim TotalOT3 As Double

            Dim TotalSal1 As Double

            Dim TotalSal2 As Double

            Dim TotalSectors As Double

            Dim TotalDutyHours As Double

            Dim TotalFlightHours As Double

            Dim TotalCommission As Double

            Dim TotalOverlay As Double

            Dim TotalTimeoff As Double

            Dim GLAnal1 As String

            Dim TotalEmpCounter As Integer







            For i = 0 To MyDs.Tables(0).Rows.Count - 1
                If GroupByGenAnal1 Then
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_GenAnal1))
                    EmpName = EmpCode
                ElseIf GroupByAnalysis3 Then
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code3))
                    Dim An3 As New cPrAnEmployeeAnalysis3(EmpCode)
                    EmpName = An3.DescriptionL
                Else
                    EmpCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AnalysisCode))
                    Dim An2 As New cPrAnEmployeeAnalysis2(EmpCode)
                    EmpName = An2.DescriptionL
                End If

                If GroupBy2 Then
                    Dim GenAnal1 As String
                    Dim An2C As String
                    GenAnal1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_GenAnal1))
                    An2C = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AnalysisCode))
                    Dim An2 As New cPrAnEmployeeAnalysis2(An2C)

                    EmpCode = An2C & " / " & GenAnal1
                    EmpName = An2.DescriptionL & " / " & GenAnal1

                End If
                If GroupByanal2AndAnal3 Then

                    Dim An2C As String
                    Dim An3C As String

                    An2C = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AnalysisCode))
                    Dim An2 As New cPrAnEmployeeAnalysis2(An2C)
                    An3C = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code3))
                    Dim An3 As New cPrAnEmployeeAnalysis3(An3C)

                    EmpCode = An2C & " / " & An3C
                    EmpName = An2.DescriptionL & " / " & An3.DescriptionL

                End If
                '''''''''''''''''''''''Earnings''''''''''''''''''''''
                EErn1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E1))
                EErn2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E2))
                EErn3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E3))
                EErn4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E4))
                EErn5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E5))
                EErn6 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E6))
                EErn7 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E7))
                EErn8 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E8))
                EErn9 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E9))
                EErn10 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E10))
                EErn11 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E11))
                EErn12 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E12))
                EErn13 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E13))
                EErn14 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E14))
                EErn15 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_E15))
                ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                DDed1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D1))
                DDed2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D2))
                DDed3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D3))
                DDed4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D4))
                DDed5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D5))
                DDed6 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D6))
                DDed7 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D7))
                DDed8 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D8))
                DDed9 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D9))
                DDed10 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D10))
                DDed11 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D11))
                DDed12 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D12))
                DDed13 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D13))
                DDed14 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D14))
                DDed15 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_D15))
                ''''''''''''''''''''''DContributions''''''''''''''''''''''
                CCon1 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C1))
                CCon2 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C2))
                CCon3 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C3))
                CCon4 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C4))
                CCon5 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C5))
                CCon6 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C6))
                CCon7 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C7))
                CCon8 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C8))
                CCon9 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C9))
                CCon10 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C10))
                CCon11 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C11))
                CCon12 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C12))
                CCon13 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C13))
                CCon14 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C14))
                CCon15 = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_C15))

                EVal1 = 0
                EVal2 = 0
                EVal3 = 0
                EVal4 = 0
                EVal5 = 0
                EVal6 = 0
                EVal7 = 0
                EVal8 = 0
                EVal9 = 0
                EVal10 = 0
                EVal11 = 0
                EVal12 = 0
                EVal13 = 0
                EVal14 = 0
                EVal15 = 0
                EVTotal = 0

                DVal1 = 0
                DVal2 = 0
                DVal3 = 0
                DVal4 = 0
                DVal5 = 0
                DVal6 = 0
                DVal7 = 0
                DVal8 = 0
                DVal9 = 0
                DVal10 = 0
                DVal11 = 0
                DVal12 = 0
                DVal13 = 0
                DVal14 = 0
                DVal15 = 0
                DVTotal = 0

                CVal1 = 0
                CVal2 = 0
                CVal3 = 0
                CVal4 = 0
                CVal5 = 0
                CVal6 = 0
                CVal7 = 0
                CVal8 = 0
                CVal9 = 0
                CVal10 = 0
                CVal11 = 0
                CVal12 = 0
                CVal13 = 0
                CVal14 = 0
                CVal15 = 0
                CVTotal = 0

                ActualUnits = 0
                NetSalary = 0
                CompanyCost = 0
                SITotal = 0
                TotalOT1 = 0
                TotalOT2 = 0
                TotalOT3 = 0
                TotalSal1 = 0
                TotalSal2 = 0
                TotalSectors = 0
                TotalDutyHours = 0
                TotalFlightHours = 0
                TotalCommission = 0
                TotalOverlay = 0
                TotalTimeoff = 0
                TotalEmpCounter = 0



                If EmpCode = "" Or EmpCode = "TOTALS " Then
                    'Exit For
                Else
                    Dim DoNotLoad As Boolean = False
                    Dim k As Integer
                    If Not DTx Is Nothing Then
                        For k = 0 To DTx.Rows.Count - 1
                            If EmpCode = DTx.Rows(k).Item(Me.Column_EmpCode) Then
                                DoNotLoad = True
                            End If
                        Next
                    End If
                    If Not DoNotLoad Then
                        For j = 0 To MyDs.Tables(0).Rows.Count - 1
                            Dim Criteria As String
                            If GroupByGenAnal1 Then
                                Criteria = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_GenAnal1))
                            ElseIf GroupByGenAnal1 Then
                                Criteria = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code3))
                            Else
                                Criteria = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AnalysisCode))
                            End If
                            If GroupBy2 Then
                                Dim GenAnal1 As String
                                Dim An2C As String
                                GenAnal1 = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_GenAnal1))
                                An2C = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AnalysisCode))
                                Criteria = An2C & " / " & GenAnal1
                            End If
                            If GroupByanal2AndAnal3 Then
                                Dim An3C As String
                                Dim An2C As String
                                An3C = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AL_Code3))
                                An2C = DbNullToString(MyDs.Tables(0).Rows(j).Item(Me.Column_AnalysisCode))
                                Criteria = An2C & " / " & An3C
                            End If
                            If EmpCode = Criteria Then

                                ActualUnits = ActualUnits + MyDs.Tables(0).Rows(j).Item(Me.Column_ActualUnits)
                                '''''''''''''''''''''''Earnings''''''''''''''''''''''
                                EVal1 = EVal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV1)
                                EVal2 = EVal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV2)
                                EVal3 = EVal3 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV3)
                                EVal4 = EVal4 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV4)
                                EVal5 = EVal5 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV5)
                                EVal6 = EVal6 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV6)
                                EVal7 = EVal7 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV7)
                                EVal8 = EVal8 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV8)
                                EVal9 = EVal9 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV9)
                                EVal10 = EVal10 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV10)
                                EVal11 = EVal11 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV11)
                                EVal12 = EVal12 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV12)
                                EVal13 = EVal13 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV13)
                                EVal14 = EVal14 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV14)
                                EVal15 = EVal15 + MyDs.Tables(0).Rows(j).Item(Me.Column_EV15)
                                EVTotal = EVTotal + MyDs.Tables(0).Rows(j).Item(Me.Column_EVTotal)
                                ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                                DVal1 = DVal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV1)
                                DVal2 = DVal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV2)
                                DVal3 = DVal3 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV3)
                                DVal4 = DVal4 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV4)
                                DVal5 = DVal5 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV5)
                                DVal6 = DVal6 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV6)
                                DVal7 = DVal7 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV7)
                                DVal8 = DVal8 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV8)
                                DVal9 = DVal9 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV9)
                                DVal10 = DVal10 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV10)
                                DVal11 = DVal11 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV11)
                                DVal12 = DVal12 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV12)
                                DVal13 = DVal13 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV13)
                                DVal14 = DVal14 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV14)
                                DVal15 = DVal15 + MyDs.Tables(0).Rows(j).Item(Me.Column_DV15)
                                DVTotal = DVTotal + MyDs.Tables(0).Rows(j).Item(Me.Column_DVTotal)
                                ''''''''''''''''''''''CContributions''''''''''''''''''''''
                                CCon1 = DbNullToString((MyDs.Tables(0).Rows(j).Item(Me.Column_C1)))
                                '69
                                CVal1 = CVal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV1)
                                CVal2 = CVal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV2)
                                CVal3 = CVal3 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV3)
                                CVal4 = CVal4 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV4)
                                CVal5 = CVal5 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV5)
                                CVal6 = CVal6 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV6)
                                CVal7 = CVal7 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV7)
                                CVal8 = CVal8 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV8)
                                CVal9 = CVal9 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV9)
                                CVal10 = CVal10 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV10)
                                CVal11 = CVal11 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV11)
                                CVal12 = CVal12 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV12)
                                CVal13 = CVal13 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV13)
                                CVal14 = CVal14 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV14)
                                CVal15 = CVal15 + MyDs.Tables(0).Rows(j).Item(Me.Column_CV15)
                                CVTotal = CVTotal + MyDs.Tables(0).Rows(j).Item(Me.Column_CVTotal)

                                NetSalary = NetSalary + MyDs.Tables(0).Rows(j).Item(Me.Column_NetSalary)
                                CompanyCost = CompanyCost + MyDs.Tables(0).Rows(j).Item(Me.Column_CompanyCost)
                                PeriodCode = ""
                                SITotal = SITotal + MyDs.Tables(0).Rows(j).Item(Me.Column_SITotal)
                                Reference = ""
                                TotalOT1 = TotalOT1 + MyDs.Tables(0).Rows(j).Item(Me.Column_Overtime1)
                                TotalOT2 = TotalOT2 + MyDs.Tables(0).Rows(j).Item(Me.Column_OverTime2)
                                TotalOT3 = TotalOT3 + MyDs.Tables(0).Rows(j).Item(Me.Column_OverTime3)

                                TotalSal1 = TotalSal1 + MyDs.Tables(0).Rows(j).Item(Me.Column_Salary1)
                                TotalSal2 = TotalSal2 + MyDs.Tables(0).Rows(j).Item(Me.Column_Salary2)

                                TotalSectors = TotalSectors + MyDs.Tables(0).Rows(j).Item(Me.Column_sectors)
                                TotalDutyHours = TotalDutyHours + MyDs.Tables(0).Rows(j).Item(Me.Column_dutyhours)
                                TotalFlightHours = TotalFlightHours + MyDs.Tables(0).Rows(j).Item(Me.Column_flighthours)
                                TotalCommission = TotalCommission + MyDs.Tables(0).Rows(j).Item(Me.Column_commission)
                                TotalOverlay = TotalOverlay + MyDs.Tables(0).Rows(j).Item(Me.Column_OverLay)
                                TotalTimeoff = TotalTimeoff + DbNullToDouble(MyDs.Tables(0).Rows(j).Item(Me.Column_TimeOff))
                                TotalEmpCounter = TotalEmpCounter + 1

                            End If
                        Next
                        Dim r As DataRow = DTx.NewRow()
                        r(Me.Column_EmpCode) = EmpCode
                        r(Me.Column_EmpName) = EmpName
                        r(Me.Column_ActualUnits) = Format(ActualUnits, "0.00")
                        r(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                        r(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                        r(Me.Column_OverTime3) = Format(TotalOT3, "0.00")

                        r(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                        r(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                        r(Me.Column_sectors) = Format(TotalSectors, "0.00")
                        r(Me.Column_dutyhours) = Format(TotalDutyHours, "0.00")
                        r(Me.Column_flighthours) = Format(TotalFlightHours, "0.00")
                        r(Me.Column_commission) = Format(TotalCommission, "0.00")
                        r(Me.Column_OverLay) = Format(TotalOverlay, "0.00")
                        r(Me.Column_TimeOff) = Format(TotalTimeoff, "0.00")




                        '''''''''''''''''''''''Earnings''''''''''''''''''''''
                        r(Me.Column_E1) = EErn1                '
                        r(Me.Column_EV1) = EVal1                '
                        r(Me.Column_E2) = EErn2                '
                        r(Me.Column_EV2) = EVal2                '
                        r(Me.Column_E3) = EErn3                '
                        r(Me.Column_EV3) = EVal3                '
                        r(Me.Column_E4) = EErn4                '
                        r(Me.Column_EV4) = EVal4                '
                        r(Me.Column_E5) = EErn5                '
                        r(Me.Column_EV5) = EVal5                '
                        r(Me.Column_E6) = EErn6                '
                        r(Me.Column_EV6) = EVal6                '
                        r(Me.Column_E7) = EErn7                '
                        r(Me.Column_EV7) = EVal7                '
                        r(Me.Column_E8) = EErn8                '
                        r(Me.Column_EV8) = EVal8                '
                        r(Me.Column_E9) = EErn9                '
                        r(Me.Column_EV9) = EVal9                '
                        r(Me.Column_E10) = EErn10               '
                        r(Me.Column_EV10) = EVal10               '
                        r(Me.Column_E11) = EErn11               '
                        r(Me.Column_EV11) = EVal11               '
                        r(Me.Column_E12) = EErn12               '
                        r(Me.Column_EV12) = EVal12               '
                        r(Me.Column_E13) = EErn13               '
                        r(Me.Column_EV13) = EVal13               '
                        r(Me.Column_E14) = EErn14               '
                        r(Me.Column_EV14) = EVal14               '
                        r(Me.Column_E15) = EErn15               '
                        r(Me.Column_EV15) = EVal15               '
                        r(Me.Column_EVTotal) = EVTotal
                        ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                        r(Me.Column_D1) = DDed1                '
                        r(Me.Column_DV1) = DVal1                '
                        r(Me.Column_D2) = DDed2                '
                        r(Me.Column_DV2) = DVal2                '
                        r(Me.Column_D3) = DDed3                '
                        r(Me.Column_DV3) = DVal3                '
                        r(Me.Column_D4) = DDed4                '
                        r(Me.Column_DV4) = DVal4                '
                        r(Me.Column_D5) = DDed5                '
                        r(Me.Column_DV5) = DVal5                '
                        r(Me.Column_D6) = DDed6                '
                        r(Me.Column_DV6) = DVal6                '
                        r(Me.Column_D7) = DDed7                '
                        r(Me.Column_DV7) = DVal7                '
                        r(Me.Column_D8) = DDed8                '
                        r(Me.Column_DV8) = DVal8                '
                        r(Me.Column_D9) = DDed9                '
                        r(Me.Column_DV9) = DVal9                '
                        r(Me.Column_D10) = DDed10               '
                        r(Me.Column_DV10) = DVal10               '
                        r(Me.Column_D11) = DDed11               '
                        r(Me.Column_DV11) = DVal11               '
                        r(Me.Column_D12) = DDed12               '
                        r(Me.Column_DV12) = DVal12               '
                        r(Me.Column_D13) = DDed13               '
                        r(Me.Column_DV13) = DVal13               '
                        r(Me.Column_D14) = DDed14               '
                        r(Me.Column_DV14) = DVal14               '
                        r(Me.Column_D15) = DDed15               '
                        r(Me.Column_DV15) = DVal15               '
                        r(Me.Column_DVTotal) = DVTotal
                        ''''''''''''''''''''''CContributions''''''''''''''''''''''
                        r(Me.Column_C1) = CCon1                '
                        r(Me.Column_CV1) = CVal1                '
                        r(Me.Column_C2) = CCon2                '
                        r(Me.Column_CV2) = CVal2                '
                        r(Me.Column_C3) = CCon3                '
                        r(Me.Column_CV3) = CVal3                '
                        r(Me.Column_C4) = CCon4                '
                        r(Me.Column_CV4) = CVal4                '
                        r(Me.Column_C5) = CCon5                '
                        r(Me.Column_CV5) = CVal5                '
                        r(Me.Column_C6) = CCon6                '
                        r(Me.Column_CV6) = CVal6                '
                        r(Me.Column_C7) = CCon7                '
                        r(Me.Column_CV7) = CVal7                '
                        r(Me.Column_C8) = CCon8                '
                        r(Me.Column_CV8) = CVal8                '
                        r(Me.Column_C9) = CCon9                '
                        r(Me.Column_CV9) = CVal9                '
                        r(Me.Column_C10) = CCon10               '
                        r(Me.Column_CV10) = CVal10               '
                        r(Me.Column_C11) = CCon11               '
                        r(Me.Column_CV11) = CVal11               '
                        r(Me.Column_C12) = CCon12               '
                        r(Me.Column_CV12) = CVal12               '
                        r(Me.Column_C13) = CCon13               '
                        r(Me.Column_CV13) = CVal13               '
                        r(Me.Column_C14) = CCon14               '
                        r(Me.Column_CV14) = CVal14               '
                        r(Me.Column_C15) = CCon15               '
                        r(Me.Column_CV15) = CVal15               '
                        r(Me.Column_CVTotal) = CVTotal
                        r(Me.Column_NetSalary) = Format(NetSalary, "0.00")
                        '100
                        r(Me.Column_CompanyCost) = Format(CompanyCost, "0.00")
                        '101
                        r(Me.Column_PeriodCode) = ""
                        r(Me.Column_SITotal) = Format(SITotal, "0.00")
                        r(Me.Column_ChequeNo) = ""
                        r(Me.Column_EmpCounter) = TotalEmpCounter
                        r(Me.Column_Analysis2) = EmpName
                        DTx.Rows.Add(r)
                    End If
                End If
            Next
            Dim EstimateCOL As Integer
            DG1.DataSource = MyDsX.Tables(0)
            Dim Ern13Estimate As String
            Ern13Estimate = Global1.Business.GetEarningCodeFor13Estimate()
            EstimateFound = False
            If CheckDataSet(MyDsX) Then
                For i = Column_E1 To Column_E15
                    If Ern13Estimate = DbNullToString(MyDsX.Tables(0).Rows(0).Item(i)) Then
                        EstimateCOL = i
                        EstimateFound = True
                        Exit For
                    End If
                Next
            End If
            'Dim DsEmp As DataSet
            'Dim PrdGrp As New cPrMsPeriodGroups
            'PrdGrp = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            'DsEmp = Global1.Business.GetAllemployeesWithTerminationDate(PrdGrp.TemGrpCode)
            'If CheckDataSet(DsEmp) Then
            '    For i = 0 To DsEmp.Tables(0).Rows.Count - 1
            '        EmpCode = DsEmp.Tables(0).Rows(i).Item(0)
            '        For j = 0 To MyDsX.Tables(0).Rows.Count - 1
            '            If EmpCode = MyDsX.Tables(0).Rows(j).Item(Me.Column_AnalysisCode) Then
            '                If EstimateFound Then
            '                    Dim Est13 As Double
            '                    Est13 = DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(EstimateCOL + 1))
            '                    MyDsX.Tables(0).Rows(j).Item(EstimateCOL + 1) = 0
            '                    MyDsX.Tables(0).Rows(j).Item(Me.Column_EVTotal) = MyDsX.Tables(0).Rows(j).Item(Me.Column_EVTotal) '- Est13
            '                    MyDsX.Tables(0).Rows(j).Item(Me.Column_CompanyCost) = MyDsX.Tables(0).Rows(j).Item(Me.Column_CompanyCost) '- Est13
            '                    Exit For
            '                End If
            '            End If
            '        Next
            '    Next
            'End If



            ' Totals Calculation ----------------
            ActualUnits = 0
            TotalOT1 = 0
            TotalOT2 = 0
            TotalOT3 = 0
            TotalSal1 = 0
            TotalSal2 = 0
            EVal1 = 0
            EVal2 = 0
            EVal3 = 0
            EVal4 = 0
            EVal5 = 0
            EVal6 = 0
            EVal7 = 0
            EVal8 = 0
            EVal9 = 0
            EVal10 = 0
            EVal11 = 0
            EVal12 = 0
            EVal13 = 0
            EVal14 = 0
            EVal15 = 0
            EVTotal = 0
            ''''''''''''''''''''''DDeductions''''''''''''''''''''''
            DVal1 = 0
            DVal2 = 0
            DVal3 = 0
            DVal4 = 0
            DVal5 = 0
            DVal6 = 0
            DVal7 = 0
            DVal8 = 0
            DVal9 = 0
            DVal10 = 0
            DVal11 = 0
            DVal12 = 0
            DVal13 = 0
            DVal14 = 0
            DVal15 = 0
            DVTotal = 0
            ''''''''''''''''''''''CContributions''''''''''''''''''''''
            CVal1 = 0
            CVal2 = 0
            CVal3 = 0
            CVal4 = 0
            CVal5 = 0
            CVal6 = 0
            CVal7 = 0
            CVal8 = 0
            CVal9 = 0
            CVal10 = 0
            CVal11 = 0
            CVal12 = 0
            CVal13 = 0
            CVal14 = 0
            CVal15 = 0
            CVTotal = 0

            NetSalary = 0
            CompanyCost = 0
            PeriodCode = ""
            SITotal = 0
            Reference = ""

            TotalSectors = 0
            TotalDutyHours = 0
            TotalFlightHours = 0
            TotalCommission = 0
            TotalOverlay = 0
            TotalTimeoff = 0
            TotalEmpCounter = 0

            For j = 0 To MyDsX.Tables(0).Rows.Count - 1
                ActualUnits = ActualUnits + MyDsX.Tables(0).Rows(j).Item(Me.Column_ActualUnits)
                TotalOT1 = TotalOT1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_Overtime1)
                TotalOT2 = TotalOT2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_OverTime2)
                TotalOT3 = TotalOT3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_OverTime3)

                TotalSal1 = TotalSal1 + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_Salary1))
                TotalSal2 = TotalSal2 + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_Salary2))

                TotalSectors = TotalSectors + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_sectors))
                TotalDutyHours = TotalDutyHours + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_dutyhours))
                TotalFlightHours = TotalFlightHours + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_flighthours))
                TotalCommission = TotalCommission + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_commission))
                TotalOverlay = TotalOverlay + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_OverLay))
                TotalTimeoff = TotalTimeoff + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_TimeOff))
                TotalEmpCounter = TotalEmpCounter + DbNullToDouble(MyDsX.Tables(0).Rows(j).Item(Me.Column_EmpCounter))


                EVal1 = EVal1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV1)
                EVal2 = EVal2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV2)
                EVal3 = EVal3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV3)
                EVal4 = EVal4 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV4)
                EVal5 = EVal5 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV5)
                EVal6 = EVal6 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV6)
                EVal7 = EVal7 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV7)
                EVal8 = EVal8 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV8)
                EVal9 = EVal9 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV9)
                EVal10 = EVal10 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV10)
                EVal11 = EVal11 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV11)
                EVal12 = EVal12 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV12)
                EVal13 = EVal13 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV13)
                EVal14 = EVal14 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV14)
                EVal15 = EVal15 + MyDsX.Tables(0).Rows(j).Item(Me.Column_EV15)
                EVTotal = EVTotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_EVTotal)
                ''''''''''''''''''''''DDeductions''''''''''''''''''''''
                DVal1 = DVal1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV1)
                DVal2 = DVal2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV2)
                DVal3 = DVal3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV3)
                DVal4 = DVal4 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV4)
                DVal5 = DVal5 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV5)
                DVal6 = DVal6 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV6)
                DVal7 = DVal7 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV7)
                DVal8 = DVal8 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV8)
                DVal9 = DVal9 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV9)
                DVal10 = DVal10 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV10)
                DVal11 = DVal11 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV11)
                DVal12 = DVal12 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV12)
                DVal13 = DVal13 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV13)
                DVal14 = DVal14 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV14)
                DVal15 = DVal15 + MyDsX.Tables(0).Rows(j).Item(Me.Column_DV15)
                DVTotal = DVTotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_DVTotal)
                ''''''''''''''''''''''CContributions''''''''''''''''''''''
                CVal1 = CVal1 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV1)
                CVal2 = CVal2 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV2)
                CVal3 = CVal3 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV3)
                CVal4 = CVal4 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV4)
                CVal5 = CVal5 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV5)
                CVal6 = CVal6 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV6)
                CVal7 = CVal7 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV7)
                CVal8 = CVal8 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV8)
                CVal9 = CVal9 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV9)
                CVal10 = CVal10 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV10)
                CVal11 = CVal11 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV11)
                CVal12 = CVal12 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV12)
                CVal13 = CVal13 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV13)
                CVal14 = CVal14 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV14)
                CVal15 = CVal15 + MyDsX.Tables(0).Rows(j).Item(Me.Column_CV15)
                CVTotal = CVTotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_CVTotal)

                NetSalary = NetSalary + MyDsX.Tables(0).Rows(j).Item(Me.Column_NetSalary)
                CompanyCost = CompanyCost + MyDsX.Tables(0).Rows(j).Item(Me.Column_CompanyCost)
                PeriodCode = ""
                SITotal = SITotal + MyDsX.Tables(0).Rows(j).Item(Me.Column_SITotal)
                Reference = ""

            Next
            Dim rempty As DataRow = DTx.NewRow()
            DTx.Rows.Add(rempty)

            Dim rX As DataRow = DTx.NewRow()

            rX(Me.Column_EmpCode) = "TOTAL"
            rX(Me.Column_EmpName) = "ALL Employees"
            rX(Me.Column_ActualUnits) = Format(ActualUnits, "0.00")
            rX(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
            rX(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
            rX(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
            rX(Me.Column_Salary1) = Format(TotalSal1, "0.00")
            rX(Me.Column_Salary2) = Format(TotalSal2, "0.00")


            rX(Me.Column_sectors) = Format(TotalSectors, "0.00")
            rX(Me.Column_dutyhours) = Format(TotalDutyHours, "0.00")
            rX(Me.Column_flighthours) = Format(TotalFlightHours, "0.00")
            rX(Me.Column_commission) = Format(TotalCommission, "0.00")
            rX(Me.Column_OverLay) = Format(TotalOverlay, "0.00")
            rX(Me.Column_TimeOff) = Format(TotalTimeoff, "0.00")
            rX(Me.Column_EmpCounter) = TotalEmpCounter
            rX(Me.Column_Analysis2) = ""

            '''''''''''''''''''''''Earnings''''''''''''''''''''''
            rX(Me.Column_E1) = EErn1                '
            rX(Me.Column_EV1) = EVal1                '
            rX(Me.Column_E2) = EErn2                '
            rX(Me.Column_EV2) = EVal2                '
            rX(Me.Column_E3) = EErn3                '
            rX(Me.Column_EV3) = EVal3                '
            rX(Me.Column_E4) = EErn4                '
            rX(Me.Column_EV4) = EVal4                '
            rX(Me.Column_E5) = EErn5                '
            rX(Me.Column_EV5) = EVal5                '
            rX(Me.Column_E6) = EErn6                '
            rX(Me.Column_EV6) = EVal6                '
            rX(Me.Column_E7) = EErn7                '
            rX(Me.Column_EV7) = EVal7                '
            rX(Me.Column_E8) = EErn8                '
            rX(Me.Column_EV8) = EVal8                '
            rX(Me.Column_E9) = EErn9                '
            rX(Me.Column_EV9) = EVal9                '
            rX(Me.Column_E10) = EErn10               '
            rX(Me.Column_EV10) = EVal10               '
            rX(Me.Column_E11) = EErn11               '
            rX(Me.Column_EV11) = EVal11               '
            rX(Me.Column_E12) = EErn12               '
            rX(Me.Column_EV12) = EVal12               '
            rX(Me.Column_E13) = EErn13               '
            rX(Me.Column_EV13) = EVal13               '
            rX(Me.Column_E14) = EErn14               '
            rX(Me.Column_EV14) = EVal14               '
            rX(Me.Column_E15) = EErn15               '
            rX(Me.Column_EV15) = EVal15               '
            rX(Me.Column_EVTotal) = EVTotal
            ''''''''''''''''''''''DDeductions''''''''''''''''''''''
            rX(Me.Column_D1) = DDed1                '
            rX(Me.Column_DV1) = DVal1                '
            rX(Me.Column_D2) = DDed2                '
            rX(Me.Column_DV2) = DVal2                '
            rX(Me.Column_D3) = DDed3                '
            rX(Me.Column_DV3) = DVal3                '
            rX(Me.Column_D4) = DDed4                '
            rX(Me.Column_DV4) = DVal4                '
            rX(Me.Column_D5) = DDed5                '
            rX(Me.Column_DV5) = DVal5                '
            rX(Me.Column_D6) = DDed6                '
            rX(Me.Column_DV6) = DVal6                '
            rX(Me.Column_D7) = DDed7                '
            rX(Me.Column_DV7) = DVal7                '
            rX(Me.Column_D8) = DDed8                '
            rX(Me.Column_DV8) = DVal8                '
            rX(Me.Column_D9) = DDed9                '
            rX(Me.Column_DV9) = DVal9                '
            rX(Me.Column_D10) = DDed10               '
            rX(Me.Column_DV10) = DVal10               '
            rX(Me.Column_D11) = DDed11               '
            rX(Me.Column_DV11) = DVal11               '
            rX(Me.Column_D12) = DDed12               '
            rX(Me.Column_DV12) = DVal12               '
            rX(Me.Column_D13) = DDed13               '
            rX(Me.Column_DV13) = DVal13               '
            rX(Me.Column_D14) = DDed14               '
            rX(Me.Column_DV14) = DVal14               '
            rX(Me.Column_D15) = DDed15               '
            rX(Me.Column_DV15) = DVal15               '
            rX(Me.Column_DVTotal) = DVTotal
            ''''''''''''''''''''''CContributions''''''''''''''''''''''
            rX(Me.Column_C1) = CCon1                '
            rX(Me.Column_CV1) = CVal1                '
            rX(Me.Column_C2) = CCon2                '
            rX(Me.Column_CV2) = CVal2                '
            rX(Me.Column_C3) = CCon3                '
            rX(Me.Column_CV3) = CVal3                '
            rX(Me.Column_C4) = CCon4                '
            rX(Me.Column_CV4) = CVal4                '
            rX(Me.Column_C5) = CCon5                '
            rX(Me.Column_CV5) = CVal5                '
            rX(Me.Column_C6) = CCon6                '
            rX(Me.Column_CV6) = CVal6                '
            rX(Me.Column_C7) = CCon7                '
            rX(Me.Column_CV7) = CVal7                '
            rX(Me.Column_C8) = CCon8                '
            rX(Me.Column_CV8) = CVal8                '
            rX(Me.Column_C9) = CCon9                '
            rX(Me.Column_CV9) = CVal9                '
            rX(Me.Column_C10) = CCon10               '
            rX(Me.Column_CV10) = CVal10               '
            rX(Me.Column_C11) = CCon11               '
            rX(Me.Column_CV11) = CVal11               '
            rX(Me.Column_C12) = CCon12               '
            rX(Me.Column_CV12) = CVal12               '
            rX(Me.Column_C13) = CCon13               '
            rX(Me.Column_CV13) = CVal13               '
            rX(Me.Column_C14) = CCon14               '
            rX(Me.Column_CV14) = CVal14               '
            rX(Me.Column_C15) = CCon15               '
            rX(Me.Column_CV15) = CVal15               '
            rX(Me.Column_CVTotal) = CVTotal
            rX(Me.Column_NetSalary) = Format(NetSalary, "0.00")
            '100
            rX(Me.Column_CompanyCost) = Format(CompanyCost, "0.00")
            '101
            rX(Me.Column_PeriodCode) = ""
            rX(Me.Column_SITotal) = Format(SITotal, "0.00")
            rX(Me.Column_ChequeNo) = ""
            DTx.Rows.Add(rX)

            Dim rempty2 As DataRow = DTx.NewRow()
            DTx.Rows.Add(rempty2)
        End If




    End Sub
    Private Sub ShowOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SentToPrinter(False, False, False)

    End Sub
    Private Sub SendToPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SentToPrinter(True, False, False)
    End Sub
    Private Sub SentToPrinter(ByVal TF As Boolean, ByVal Totals1 As Boolean, ByVal Totals2 As Boolean)
        InitDataTable_3()
        Dim CompanyTotalCost As Double = 0
        If CheckDataSet(MyDs) Then
            Dim MyDs2 As New DataSet
            MyDs2.Tables.Add(MyDs.Tables(0).Copy)
            If MyDs2.Tables.Count > 0 Then
                Dim i As Integer
                Dim j As Integer
                Dim Counter As Integer
                Counter = MyDs2.Tables(0).Rows.Count - 1
                j = Counter
                'For i = Counter To 0 Step -1
                '    If DbNullToString(MyDs2.Tables(0).Rows(j).Item(0)) = "" Then
                '        Debug.WriteLine("1" & DbNullToString(MyDs2.Tables(0).Rows(j).Item(0)))
                '        Debug.WriteLine("2" & DbNullToString(MyDs2.Tables(0).Rows(j).Item(1)))
                '        Debug.WriteLine("3" & DbNullToString(MyDs2.Tables(0).Rows(j).Item(2)))
                '        MyDs2.Tables(0).Rows(j).Delete()
                '        j = j - 1
                '        Counter = MyDs2.Tables(0).Rows.Count - 1
                '    End If
                '    j = j - 1
                '    If j = -1 Then Exit For
                'Next


                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = GLBAnalysisDescriptionOnTheReport
                r(7) = GLBBankDescriptionOnTheReport
                If ShowTimeOff Then
                    r(5) = "TOf"
                Else
                    r(5) = "OT3"
                End If



                Dt3.Rows.Add(r)
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    Dim k As Integer
                    Dim C1 As Integer = 0
                    Dim D As String
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                        End If

                        MyDs2.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                        C1 = C1 + 2

                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                        C1 = C1 + 2
                    Next
                Next

                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "" And DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)).StartsWith("TOTALS") = False Then
                        CompanyTotalCost = CompanyTotalCost + DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                    End If
                    If ShowTimeOff Then
                        Dim Tof As Double
                        Tof = DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_OverTime3) = Format(Tof, "0.00")
                    End If


                Next

                r(4) = CompanyTotalCost
                MyDs2.Tables.Add(Dt3)


                Dim ReportDS As New DataSet
                ReportDS = MyDs2.Copy
                Dim c As Integer
                If Per.Code = Per2.Code Then

                    c = ReportDS.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        ReportDS.Tables(0).Rows(c).Delete()
                    End If
                    c = ReportDS.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        ReportDS.Tables(0).Rows(c - 1).Delete()
                    End If
                End If


                Dim ReportToUse As String = "PayrollAnalysis2.rpt"
                Dim Ds As DataSet
                Ds = Global1.Business.GetParameter("System", "PAReport")
                If CheckDataSet(Ds) Then
                    Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
                    ReportToUse = Par.Value1
                End If
                If Totals1 Then
                    ReportToUse = "EDCTotals1.rpt"
                End If
                If Totals2 Then
                    ReportToUse = "EDCTotals2.rpt"
                End If
                'Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                ' Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                Utils.ShowReport(ReportToUse, ReportDS, FrmReport, "", TF, "", False, False, "", True)
            End If
        End If
    End Sub
    Private Sub InitDataTable_3()
        Dt3 = New DataTable("Table3")
        '0
        Dt3.Columns.Add("Company", System.Type.GetType("System.String"))
        '1
        Dt3.Columns.Add("Template", System.Type.GetType("System.String"))
        '2
        Dt3.Columns.Add("Period", System.Type.GetType("System.String"))
        '3
        Dt3.Columns.Add("Department", System.Type.GetType("System.String"))
        '4
        Dt3.Columns.Add("CompCost", System.Type.GetType("System.Double"))
        '5
        Dt3.Columns.Add("OT3", System.Type.GetType("System.String"))
        '6
        Dt3.Columns.Add("TotalEmployees", System.Type.GetType("System.String"))
        '7
        Dt3.Columns.Add("CompanyBank", System.Type.GetType("System.String"))


    End Sub
    Private Sub InitDatatable_4()

        Dt4 = New DataTable("Table1")
        '0
        Dt4.Columns.Add("Period", System.Type.GetType("System.String"))
        '1
        Dt4.Columns.Add("Monthly", System.Type.GetType("System.String"))
        '2
        Dt4.Columns.Add("Hourly", System.Type.GetType("System.String"))
        '3
        Dt4.Columns.Add("Total", System.Type.GetType("System.String"))
    End Sub
    Private Sub InitDatatable_44()

        Dt44 = New DataTable("Table1")
        '0
        Dt44.Columns.Add("Period", System.Type.GetType("System.String"))
        '1
        Dt44.Columns.Add("Type", System.Type.GetType("System.String"))
        '2
        Dt44.Columns.Add("Total", System.Type.GetType("System.String"))
        '3
        Dt44.Columns.Add("AnalysisCode", System.Type.GetType("System.String"))
        '5
        Dt44.Columns.Add("AnalysisDesc", System.Type.GetType("System.String"))
    End Sub
    Private Sub InitDatatable_Dif()

        DtDif = New DataTable("Table1")
        '0
        DtDif.Columns.Add("PeriodFromCode", System.Type.GetType("System.String"))
        '1
        DtDif.Columns.Add("PeriodFromDesc", System.Type.GetType("System.String"))
        '2
        DtDif.Columns.Add("PeriodToCode", System.Type.GetType("System.String"))
        '3
        DtDif.Columns.Add("PeriodToDesc", System.Type.GetType("System.String"))
        '4
        DtDif.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '5
        DtDif.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '6
        DtDif.Columns.Add("Units_F", System.Type.GetType("System.Double"))
        '7
        DtDif.Columns.Add("Units_T", System.Type.GetType("System.Double"))
        '8
        DtDif.Columns.Add("Units_D", System.Type.GetType("System.Double"))
        '9
        DtDif.Columns.Add("NetSal_F", System.Type.GetType("System.Double"))
        '10
        DtDif.Columns.Add("NetSal_T", System.Type.GetType("System.Double"))
        '11
        DtDif.Columns.Add("NetSal_D", System.Type.GetType("System.Double"))
        '12
        DtDif.Columns.Add("TotalE_F", System.Type.GetType("System.Double"))
        '13
        DtDif.Columns.Add("TotalE_T", System.Type.GetType("System.Double"))
        '14
        DtDif.Columns.Add("TotalE_D", System.Type.GetType("System.Double"))
        '15
        DtDif.Columns.Add("TotalD_F", System.Type.GetType("System.Double"))
        '16
        DtDif.Columns.Add("TotalD_T", System.Type.GetType("System.Double"))
        '17
        DtDif.Columns.Add("TotalD_D", System.Type.GetType("System.Double"))
        '18
        DtDif.Columns.Add("TotalC_F", System.Type.GetType("System.Double"))
        '19
        DtDif.Columns.Add("TotalC_T", System.Type.GetType("System.Double"))
        '20
        DtDif.Columns.Add("TotalC_D", System.Type.GetType("System.Double"))
        '21
        DtDif.Columns.Add("TotalCCost_F", System.Type.GetType("System.Double"))
        '22
        DtDif.Columns.Add("TotalCCost_T", System.Type.GetType("System.Double"))
        '23
        DtDif.Columns.Add("TotalCCost_D", System.Type.GetType("System.Double"))

        '24
        DtDif.Columns.Add("Bonus_F", System.Type.GetType("System.Double"))
        '25
        DtDif.Columns.Add("Bonus_T", System.Type.GetType("System.Double"))
        '26
        DtDif.Columns.Add("Bonus_D", System.Type.GetType("System.Double"))
        '27
        DtDif.Columns.Add("Analysis2", System.Type.GetType("System.String"))
        '28
        DtDif.Columns.Add("Position", System.Type.GetType("System.String"))

        '29
        DtDif.Columns.Add("BonS_F", System.Type.GetType("System.Double"))
        '30
        DtDif.Columns.Add("BonS_T", System.Type.GetType("System.Double"))
        '31
        DtDif.Columns.Add("BonS_D", System.Type.GetType("System.Double"))


        '32
        DtDif.Columns.Add("MS_F", System.Type.GetType("System.Double"))
        '33
        DtDif.Columns.Add("MS_T", System.Type.GetType("System.Double"))
        '34
        DtDif.Columns.Add("MS_D", System.Type.GetType("System.Double"))

        '35
        DtDif.Columns.Add("BIK_F", System.Type.GetType("System.Double"))
        '36
        DtDif.Columns.Add("BIK_T", System.Type.GetType("System.Double"))
        '37
        DtDif.Columns.Add("BIK_D", System.Type.GetType("System.Double"))

        '38
        DtDif.Columns.Add("CostWithBIK_F", System.Type.GetType("System.Double"))
        '39
        DtDif.Columns.Add("CostWithBIK_T", System.Type.GetType("System.Double"))
        '40
        DtDif.Columns.Add("CostWithBIK_D", System.Type.GetType("System.Double"))


        '41
        DtDif.Columns.Add("Fine_F", System.Type.GetType("System.Double"))
        '42
        DtDif.Columns.Add("Fine_T", System.Type.GetType("System.Double"))
        '43
        DtDif.Columns.Add("Fine_D", System.Type.GetType("System.Double"))
        '44
        DtDif.Columns.Add("HR_Code", System.Type.GetType("System.String"))



    End Sub
    Private Sub InitDatatable_Dif2()
        DtDif2 = New DataTable("Table1")

        '0
        DtDif2.Columns.Add("PeriodFromCode", System.Type.GetType("System.String"))
        '1
        DtDif2.Columns.Add("PeriodFromDesc", System.Type.GetType("System.String"))
        '2
        DtDif2.Columns.Add("PeriodToCode", System.Type.GetType("System.String"))
        '3
        DtDif2.Columns.Add("PeriodToDesc", System.Type.GetType("System.String"))
        '4
        DtDif2.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '5
        DtDif2.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '6
        DtDif2.Columns.Add("Type1", System.Type.GetType("System.String"))
        '7
        DtDif2.Columns.Add("Code", System.Type.GetType("System.String"))
        '8
        DtDif2.Columns.Add("Desc", System.Type.GetType("System.String"))
        '9
        DtDif2.Columns.Add("Val1", System.Type.GetType("System.Double"))
        '10
        DtDif2.Columns.Add("Val2", System.Type.GetType("System.Double"))
        '11
        DtDif2.Columns.Add("Dif", System.Type.GetType("System.Double"))


    End Sub
    Private Sub InitDatatable_Dif2_Totals()
        DtDif2_Totals = New DataTable("Table2")

        '0
        DtDif2_Totals.Columns.Add("PeriodFromCode", System.Type.GetType("System.String"))
        '1
        DtDif2_Totals.Columns.Add("PeriodFromDesc", System.Type.GetType("System.String"))
        '2
        DtDif2_Totals.Columns.Add("PeriodToCode", System.Type.GetType("System.String"))
        '3
        DtDif2_Totals.Columns.Add("PeriodToDesc", System.Type.GetType("System.String"))
        '4
        DtDif2_Totals.Columns.Add("EmpCode", System.Type.GetType("System.String"))
        '5
        DtDif2_Totals.Columns.Add("EmpName", System.Type.GetType("System.String"))
        '6
        DtDif2_Totals.Columns.Add("Type1", System.Type.GetType("System.String"))
        '7
        DtDif2_Totals.Columns.Add("Code", System.Type.GetType("System.String"))
        '8
        DtDif2_Totals.Columns.Add("Desc", System.Type.GetType("System.String"))
        '9
        DtDif2_Totals.Columns.Add("Val1", System.Type.GetType("System.Double"))
        '10
        DtDif2_Totals.Columns.Add("Val2", System.Type.GetType("System.Double"))
        '11
        DtDif2_Totals.Columns.Add("Dif", System.Type.GetType("System.Double"))


    End Sub

    Private Sub mnuPFReportByCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New FrmPFReportByCompany
        f.Show()
    End Sub

    Private Sub MnuOpenLoans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpenLoans.Click
        ShowLoans("OPEN")
    End Sub
    Private Sub mnuClosedLoans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClosedLoans.Click
        ShowLoans("CLOSED")
    End Sub
    Private Sub ShowLoans(ByVal Status As String)
        Me.Cursor = Cursors.WaitCursor
        Dim DsLoans As DataSet
        Dim F As New FrmLoansReport


        Dim EmpToCode As String
        Dim EmpFromCode As String


        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text

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


        DsLoans = Global1.Business.GetAllLoansReport(Me.TemGrp.Code, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Status)


        F.Ds = DsLoans
        Me.Cursor = Cursors.Default
        F.ShowDialog()

    End Sub
    Private Sub ShowPFLoans(ByVal Status As String)
        Dim Per As New cPrMsPeriodCodes
        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes

        Me.Cursor = Cursors.WaitCursor
        Dim DsLoans As DataSet
        Dim F As New FrmLoansReport


        Dim EmpToCode As String
        Dim EmpFromCode As String


        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text
        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

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


        DsLoans = Global1.Business.GetAllLoansReport2(Me.TemGrp.Code, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Status, PerFrom.Code, PerTo.Code)

        F.Ds = DsLoans
        Me.Cursor = Cursors.Default
        F.ShowDialog()



    End Sub


    Private Sub menuOpenPFLoans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuOpenPFLoans.Click
        ShowPFLoans("OPEN")
    End Sub

    Private Sub menuClosedPFLoans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuClosedPFLoans.Click
        ShowPFLoans("CLOSED")
    End Sub
    Private Sub YTDReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YTDReportToolStripMenuItem.Click
        Me.lblstatus.visible = True
        YearToDateReport()
        Me.lblStatus.Visible = False
        YTDReport = True
        UseMyDsX = True
    End Sub
    Private Sub PrepareYTDONLYActiveEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareYTDONLYActiveEmployeesToolStripMenuItem.Click
        Me.lblStatus.Visible = True
        YearToDateReport(True, False)
        Me.lblStatus.Visible = False
        YTDReport = True
        UseMyDsX = True
    End Sub
    Private Sub PrepareYTDONLYEmployeesWithTermintationDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareYTDONLYEmployeesWithTermintationDateToolStripMenuItem.Click
        Me.lblStatus.Visible = True
        YearToDateReport(False, True)
        Me.lblStatus.Visible = False
        YTDReport = True
        UseMyDsX = True
    End Sub
    Private Sub YTDReportShowOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YTDReportShowOnScreenToolStripMenuItem.Click
        SentToPrinterYTD(False)
    End Sub
    Private Sub YTDReportSendToPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YTDReportSendToPrinterToolStripMenuItem.Click
        SentToPrinterYTD(True)
    End Sub
    Private Sub SentToPrinterYTD(ByVal TF As Boolean)
        InitDataTable_3()

        If CheckDataSet(MyDsX) Then
            Dim MyDs2 As New DataSet
            MyDs2.Tables.Add(MyDsX.Tables(0).Copy)


            If MyDs2.Tables.Count > 0 Then
                Dim i As Integer
                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim PerGrp As New cPrMsPeriodGroups(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).Code)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = PerGrp.Year & " " & Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = PerGrp.Year & " " & Per.Code & " - " & Per.DescriptionL
                End If
                If ShowTimeOff Then
                    r(5) = "TOf"
                Else
                    r(5) = "OT3"
                End If

                Dt3.Rows.Add(r)
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    Dim k As Integer
                    Dim C1 As Integer = 0
                    Dim D As String
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                        C1 = C1 + 2
                    Next
                Next

                Dim CompanyTotalCost As Double = 0
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "" And DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "TOTAL" Then
                        CompanyTotalCost = CompanyTotalCost + DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                    End If
                    If ShowTimeOff Then
                        Dim Tof As Double = DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_OverTime3) = Format(Tof, "0.00")
                    End If
                Next

                r(4) = CompanyTotalCost

                MyDs2.Tables.Add(Dt3)
                Dim c As Integer
                If Per.Code = Per2.Code Then
                    c = MyDs2.Tables(0).Rows.Count - 1
                    MyDs2.Tables(0).Rows(c).Delete()
                    c = MyDs2.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        MyDs2.Tables(0).Rows(c - 1).Delete()
                    End If
                End If
                Dim ReportToUse As String = "PayrollAnalysis2.rpt"
                Dim Ds As DataSet
                Ds = Global1.Business.GetParameter("System", "PAReport")
                If CheckDataSet(Ds) Then
                    Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
                    ReportToUse = Par.Value1
                End If

                Dim ReportDS As New DataSet
                ReportDS = MyDs2.Copy
                c = ReportDS.Tables(0).Rows.Count - 1
                ReportDS.Tables(0).Rows(c).Delete()
                c = ReportDS.Tables(0).Rows.Count - 1
                ReportDS.Tables(0).Rows(c - 1).Delete()

                ' Utils.WriteSchemaWithXmlTextWriter(Myds2, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                Utils.ShowReport(ReportToUse, ReportDS, FrmReport, "", TF, "", False, False, "", True)
            End If
        End If
    End Sub



    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        YTDReport = False
        usemydsx = False
        PrepareTHEReport()

    End Sub
   
    Private Sub PrepareTHEReport()
        'InitDataGrid()
        Me.ShowAnalysisDescription = False
        Me.ShowAddress = False
        If Me.CBIncludeanalysisDesc.CheckState = CheckState.Checked Then
            Me.ShowAnalysisDescription = True
        End If
        If Me.CBShowAddress.CheckState = CheckState.Checked Then
            Me.ShowAddress = True
        End If
        Me.lblStatus.Visible = True
        DG1.DataSource = MyDs.Tables(0)
        YTDReport = False
        usemydsx = False
        'PrepareReport()

        PrepareReport2(False, False)
        Me.lblStatus.Visible = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SentToScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SentToScreenToolStripMenuItem.Click
        SentToPrinter(False, False, False)
    End Sub

    Private Sub SentToPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SentToPrinterToolStripMenuItem.Click
        SentToPrinter(True, False, False)
    End Sub

    Private Sub btnCompanySummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompanySummary.Click
        Dim F As New FrmCompanySummaryReport
        F.ShowDialog()
    End Sub

    Private Sub btnMonthlyHourly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonthlyHourly.Click
        Dim Ds As DataSet
        Dim PerFrom As cPrMsPeriodCodes
        Dim PerTo As cPrMsPeriodCodes
        Dim i As Integer
        Dim k As Integer
        Dim NumberOfMonthly As Integer
        Dim NumberOfHourly As Integer

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)
        Dim DsPeriods As DataSet
        DsPeriods = Global1.Business.GetPeriodRange(PerFrom, PerTo)
        Dim Period As New cPrMsPeriodCodes
        Dim PerCode As String
        Dim PerGroup As String
        Dim Monthly As String = 1
        Dim Hourly As String = 2
        Dim totalperiods As String

        Dim DsofMonthly As DataSet
        Dim DsOfHourly As DataSet

        totalperiods = DsPeriods.Tables(0).Rows.Count
        Dim total As Integer
        MyDs4.Tables(0).Rows.Clear()
        MyDs44.Tables(0).Rows.Clear()

        For i = 0 To DsPeriods.Tables(0).Rows.Count - 1
            PerCode = DbNullToString(DsPeriods.Tables(0).Rows(i).Item(0))
            PerGroup = DbNullToString(DsPeriods.Tables(0).Rows(i).Item(1))
            Period = New cPrMsPeriodCodes(PerCode, PerGroup)
            NumberOfMonthly = Global1.Business.GetNumberOfEmployeesMonthlyHourlyPeriod(Period.PrdGrpCode, Period.Code, Monthly)
            NumberOfHourly = Global1.Business.GetNumberOfEmployeesMonthlyHourlyPeriod(Period.PrdGrpCode, Period.Code, Hourly)
            total = NumberOfMonthly + NumberOfHourly
            Dim r As DataRow = Dt4.NewRow()
            r.Item(0) = Period.Code & " - " & Period.DescriptionL
            r.Item(1) = NumberOfMonthly
            r.Item(2) = NumberOfHourly
            r.Item(3) = total
            Dt4.Rows.Add(r)
        Next




        For i = 0 To DsPeriods.Tables(0).Rows.Count - 1
            PerCode = DbNullToString(DsPeriods.Tables(0).Rows(i).Item(0))
            PerGroup = DbNullToString(DsPeriods.Tables(0).Rows(i).Item(1))
            Period = New cPrMsPeriodCodes(PerCode, PerGroup)
            DsofMonthly = Global1.Business.GetDSOfEmployeesMonthlyHourlyPeriod(Period.PrdGrpCode, Period.Code, Monthly)
            DsOfHourly = Global1.Business.GetDSOfEmployeesMonthlyHourlyPeriod(Period.PrdGrpCode, Period.Code, Hourly)

            If CheckDataSet(DsofMonthly) Then
                For k = 0 To DsofMonthly.Tables(0).Rows.Count - 1
                    Dim r As DataRow = Dt44.NewRow()
                    r.Item(0) = Period.Code & " - " & Period.DescriptionL
                    r.Item(1) = DsofMonthly.Tables(0).Rows(k).Item(0)
                    r.Item(2) = DsofMonthly.Tables(0).Rows(k).Item(1)
                    r.Item(3) = DsofMonthly.Tables(0).Rows(k).Item(2)
                    r.Item(4) = DsofMonthly.Tables(0).Rows(k).Item(3)
                    Dt44.Rows.Add(r)
                Next
            End If
            If CheckDataSet(DsOfHourly) Then
                For k = 0 To DsOfHourly.Tables(0).Rows.Count - 1
                    Dim r As DataRow = Dt44.NewRow()
                    r.Item(0) = Period.Code & " - " & Period.DescriptionL
                    r.Item(1) = DsOfHourly.Tables(0).Rows(k).Item(0)
                    r.Item(2) = DsOfHourly.Tables(0).Rows(k).Item(1)
                    r.Item(3) = DsOfHourly.Tables(0).Rows(k).Item(2)
                    r.Item(4) = DsOfHourly.Tables(0).Rows(k).Item(3)
                    Dt44.Rows.Add(r)
                Next
            End If


        Next



        Dim F As New FrmMonthlyHourlyReport
        F.Ds = MyDs4
        F.Ds44 = MyDs44
        F.ShowDialog()

    End Sub

    Private Sub AnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalysisToolStripMenuItem.Click
        Me.AnalysisReport(False, False, False, False, False)
    End Sub
    Private Sub GeneralAnalysisSummarizedTotalsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralAnalysisSummarizedTotalsToolStripMenuItem.Click
        Me.AnalysisReport(True, False, False, False, False)
    End Sub
    Private Sub EmployeeAnalysisGeneralAnalysisSuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAnalysisGeneralAnalysisSuToolStripMenuItem.Click
        Me.AnalysisReport(False, True, False, False, False)
    End Sub
    Private Sub EmployeeAnalysis3SummarizedTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAnalysis3SummarizedTotals.Click
        Me.AnalysisReport(False, False, False, True, False)

    End Sub
    Private Sub EmployeeAbalysis2AndEmployeeAnalysis3SummarizedTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAbalysis2AndEmployeeAnalysis3SummarizedTotals.Click
        Me.AnalysisReport(False, False, False, False, True)
    End Sub


    Private Sub ToScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToScreenToolStripMenuItem.Click
        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        PrepareReport_Differences3(PY, False)


        ' Utils.WriteSchemaWithXmlTextWriter(MyDsDif, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Variance1")
        Utils.ShowReport("Variance1.rpt", MyDsDif, FrmReport, "", False, "", False, False, "", False)
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        ' PrepareReport_Differences1(PY)
        PrepareReport_Differences3(PY, False)

        'Utils.WriteSchemaWithXmlTextWriter(MyDsDif, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Variance1")
        Utils.ShowReport("Variance2.rpt", MyDsDif, FrmReport, "", False, "", False, False, "", True)
    End Sub
    Private Sub Report4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Report4ToolStripMenuItem.Click
        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        PrepareReport_Differences3(PY, False)
        'Utils.WriteSchemaWithXmlTextWriter(MyDsDif, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Variance1")
        Utils.ShowReport("Variance4.rpt", MyDsDif, FrmReport, "", False, "", False, False, "", True)
    End Sub

    Private Sub Report3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Report3ToolStripMenuItem.Click
        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        PrepareReport_Differences2(PY)
        ' PrepareReport_Dif_Totals()
        'Utils.WriteSchemaWithXmlTextWriter(MyDsDif2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Variance3")
        ' Utils.WriteSchemaWithXmlTextWriter(MyDsDif2_Totals, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Variance33_totals")
        Utils.ShowReport("Variance33.rpt", MyDsDif2, FrmReport, "", False, "", False, False, "", False)
        Utils.ShowReport("Variance33_Totals.rpt", MyDsDif2_Totals, FrmReport, "", False, "", False, False, "", False)
    End Sub
    Private Sub PrepareReport_Differences2(ByVal PrevYear As Boolean)

        ' DtDif2 = New DataTable("Table1")


        Dim cd_PeriodFromCode As Integer = 0
        Dim cd_PeriodFromDesc As Integer = 1
        Dim cd_PeriodToCode As Integer = 2
        Dim cd_PeriodToDesc As Integer = 3
        Dim cd_EmpCode As Integer = 4
        Dim cd_EmpName As Integer = 5
        Dim cd_Type1 As Integer = 6
        Dim cd_Code As Integer = 7
        Dim cd_Desc As Integer = 8
        Dim cd_Val1 As Integer = 9
        Dim cd_Val2 As Integer = 10
        Dim cd_Dif As Integer = 11



        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor

        MyDsDif2.Tables(0).Rows.Clear()

        MyDsDif2_Totals.Tables(0).Rows.Clear()
        'If MyDsDif2.Tables.Count = 2 Then
        '    MyDsDif2.Tables.Remove("Table2")
        'End If





        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0

        Dim ds As DataSet
        Dim DsHeader As DataSet
        Dim DsEmp As DataSet


        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)


        Dim TotalsCreated As Boolean = False



        Dim PrevPeriodCode As String
        Dim PrevPeriodYear As String
        Dim PrevPeriodGroup As String
        Dim PerGrp As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        PrevPeriodYear = (CInt(PerGrp.Year) - 1).ToString
        PrevPeriodCode = PrevPeriodYear & "12"
        PrevPeriodGroup = Replace(PerGrp.Code, PerGrp.Year, "")
        PrevPeriodGroup = PrevPeriodYear & PrevPeriodGroup

        If PrevYear Then
            PerFrom = New cPrMsPeriodCodes(PrevPeriodCode, PrevPeriodGroup)
        End If

        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text



        ClearGrid()
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False
        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If





        DsEmp = Global1.Business.GetAllEmployeesWithPayrollForPeriods(PerFrom, PerTo, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, Ewallet)
        Dim DsL1 As DataSet
        Dim DsL2 As DataSet

        If CheckDataSet(DsEmp) Then

            For i = 0 To DsEmp.Tables(0).Rows.Count - 1
                Dim EmpCode As String
                Dim EmpName As String
                Dim EmpCode2 As String
                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(i).Item(0))
                EmpName = DbNullToString(DsEmp.Tables(0).Rows(i).Item(1))

                DsL1 = Global1.Business.GetAllEDCLinesForPeriodsForEmployee(PerFrom, EmpCode)
                DsL2 = Global1.Business.GetAllEDCLinesForPeriodsForEmployee(PerTo, EmpCode)
                Dim k As Integer
                Dim j As Integer
                Dim linType1 As String
                Dim code1 As String
                Dim Desc1 As String
                Dim Val1 As Double
                Dim Net1 As Double

                Dim FoundX As Boolean

                Dim linType2 As String
                Dim code2 As String
                Dim Desc2 As String
                Dim Val2 As Double
                Dim Net2 As Double

                Dim L1counter As Integer = 0
                Dim L2counter As Integer = 0

                Dim Found As Boolean = False
                Dim Diff As Double = 0

                If CheckDataSet(DsL1) Then
                    L1counter = DsL1.Tables(0).Rows.Count - 1
                End If
                If CheckDataSet(DsL2) Then
                    L2counter = DsL2.Tables(0).Rows.Count - 1
                End If
                If L1counter >= L2counter Then
                    If CheckDataSet(DsL1) Then
                        For k = 0 To DsL1.Tables(0).Rows.Count - 1
                            Found = False
                            linType1 = DbNullToString(DsL1.Tables(0).Rows(k).Item(2))
                            If linType1 = "E" Then
                                code1 = DbNullToString(DsL1.Tables(0).Rows(k).Item(3))
                            ElseIf linType1 = "D" Then
                                code1 = DbNullToString(DsL1.Tables(0).Rows(k).Item(4))
                            ElseIf linType1 = "C" Then
                                code1 = DbNullToString(DsL1.Tables(0).Rows(k).Item(5))
                            End If
                            Val1 = DbNullToDouble(DsL1.Tables(0).Rows(k).Item(6))
                            Desc1 = DbNullToString(DsL1.Tables(0).Rows(k).Item(9))
                            Val2 = 0
                            Net1 = DbNullToDouble(DsL1.Tables(0).Rows(k).Item(11))

                            For j = 0 To DsL2.Tables(0).Rows.Count - 1
                                linType2 = DbNullToString(DsL2.Tables(0).Rows(j).Item(2))
                                If linType2 = "E" Then
                                    code2 = DbNullToString(DsL2.Tables(0).Rows(j).Item(3))
                                ElseIf linType2 = "D" Then
                                    code2 = DbNullToString(DsL2.Tables(0).Rows(j).Item(4))
                                ElseIf linType2 = "C" Then
                                    code2 = DbNullToString(DsL2.Tables(0).Rows(j).Item(5))
                                End If
                                Desc2 = DbNullToString(DsL2.Tables(0).Rows(j).Item(9))
                                Net2 = DbNullToDouble(DsL2.Tables(0).Rows(j).Item(11))

                                If code1 = code2 And linType1 = linType2 Then
                                    Val2 = DbNullToDouble(DsL2.Tables(0).Rows(j).Item(6))
                                    Found = True
                                    Exit For
                                End If
                            Next
                            'If Found Then
                            Dim r As DataRow = DtDif2.NewRow()
                            r(cd_PeriodFromCode) = PerFrom.Code
                            r(cd_PeriodFromDesc) = PerFrom.DescriptionL
                            r(cd_PeriodToCode) = PerTo.Code
                            r(cd_PeriodToDesc) = PerTo.DescriptionL
                            r(cd_EmpCode) = EmpCode
                            r(cd_EmpName) = EmpName
                            r(cd_Type1) = linType1
                            r(cd_Code) = code1
                            r(cd_Desc) = Desc1
                            r(cd_Val1) = Val1
                            r(cd_Val2) = Val2
                            Diff = RoundMe2(Val2 - Val1, 2)
                            r(cd_Dif) = Diff
                            If Diff <> 0 Then
                                DtDif2.Rows.Add(r)
                            End If


                        Next

                        Dim r2 As DataRow = DtDif2.NewRow()
                        r2(cd_PeriodFromCode) = PerFrom.Code
                        r2(cd_PeriodFromDesc) = PerFrom.DescriptionL
                        r2(cd_PeriodToCode) = PerTo.Code
                        r2(cd_PeriodToDesc) = PerTo.DescriptionL
                        r2(cd_EmpCode) = EmpCode
                        r2(cd_EmpName) = EmpName
                        r2(cd_Type1) = ""
                        r2(cd_Code) = ""
                        r2(cd_Desc) = "Net Amount"
                        r2(cd_Val1) = Net1
                        r2(cd_Val2) = Net2
                        r2(cd_Dif) = RoundMe2(Net2 - Net1, 2)
                        DtDif2.Rows.Add(r2)


                    Else
                        If CheckDataSet(DsL2) Then
                            For k = 0 To DsL2.Tables(0).Rows.Count - 1
                                Found = False
                                linType2 = DbNullToString(DsL2.Tables(0).Rows(k).Item(2))
                                If linType2 = "E" Then
                                    code2 = DbNullToString(DsL2.Tables(0).Rows(k).Item(3))
                                ElseIf linType2 = "D" Then
                                    code2 = DbNullToString(DsL2.Tables(0).Rows(k).Item(4))
                                ElseIf linType2 = "C" Then
                                    code2 = DbNullToString(DsL2.Tables(0).Rows(k).Item(5))
                                End If
                                Val2 = DbNullToDouble(DsL2.Tables(0).Rows(k).Item(6))
                                Desc2 = DbNullToString(DsL2.Tables(0).Rows(k).Item(9))
                                Net2 = DbNullToDouble(DsL2.Tables(0).Rows(k).Item(11))

                                Val1 = 0
                                For j = 0 To DsL1.Tables(0).Rows.Count - 1
                                    linType1 = DbNullToString(DsL1.Tables(0).Rows(j).Item(2))
                                    If linType1 = "E" Then
                                        code1 = DbNullToString(DsL1.Tables(0).Rows(j).Item(3))
                                    ElseIf linType2 = "D" Then
                                        code1 = DbNullToString(DsL1.Tables(0).Rows(j).Item(4))
                                    ElseIf linType1 = "C" Then
                                        code1 = DbNullToString(DsL1.Tables(0).Rows(j).Item(5))
                                    End If

                                    Desc1 = DbNullToString(DsL1.Tables(0).Rows(j).Item(9))
                                    Net2 = DbNullToDouble(DsL1.Tables(0).Rows(j).Item(11))

                                    If code1 = code2 And linType1 = linType2 Then
                                        Val1 = DbNullToDouble(DsL1.Tables(0).Rows(j).Item(6))
                                        Found = True
                                        Exit For
                                    End If
                                Next
                                'If Found Then
                                Dim r As DataRow = DtDif2.NewRow()
                                r(cd_PeriodFromCode) = PerFrom.Code
                                r(cd_PeriodFromDesc) = PerFrom.DescriptionL
                                r(cd_PeriodToCode) = PerTo.Code
                                r(cd_PeriodToDesc) = PerTo.DescriptionL
                                r(cd_EmpCode) = EmpCode
                                r(cd_EmpName) = EmpName
                                r(cd_Type1) = linType1
                                r(cd_Code) = code1
                                r(cd_Desc) = Desc1
                                r(cd_Val1) = Val1
                                r(cd_Val2) = Val2
                                Diff = RoundMe2(Net2 - Net1, 2)
                                r(cd_Dif) = Diff
                                If Diff <> 0 Then
                                    DtDif2.Rows.Add(r)
                                End If
                                'End If

                            Next
                            Dim r2 As DataRow = DtDif2.NewRow()
                            r2(cd_PeriodFromCode) = PerFrom.Code
                            r2(cd_PeriodFromDesc) = PerFrom.DescriptionL
                            r2(cd_PeriodToCode) = PerTo.Code
                            r2(cd_PeriodToDesc) = PerTo.DescriptionL
                            r2(cd_EmpCode) = EmpCode
                            r2(cd_EmpName) = EmpName
                            r2(cd_Type1) = ""
                            r2(cd_Code) = ""
                            r2(cd_Desc) = "Net Amount"
                            r2(cd_Val1) = Net1
                            r2(cd_Val2) = Net2
                            r2(cd_Dif) = RoundMe2(Val2 - Val1, 2)
                            DtDif2.Rows.Add(r2)
                        End If
                    End If
                End If
            Next
        End If


        '----------------------------------------------------------------------------------------------
        '                                            TOTALS EARNINGS
        '----------------------------------------------------------------------------------------------
        If CheckDataSet(MyDsDif2) Then
            Dim mType As String
            Dim mCode As String
            Dim mDesc As String
            Dim mVal1 As String
            Dim mVal2 As String
            Dim mDif As String

            Dim mType2 As String
            Dim mCode2 As String
            Dim k As Integer

            Dim Found As Boolean = False

            For i = 0 To MyDsDif2.Tables(0).Rows.Count - 1
                mType = MyDsDif2.Tables(0).Rows(i).Item(cd_Type1)
                If mType = "E" Then
                    mCode = MyDsDif2.Tables(0).Rows(i).Item(cd_Code)
                    mDesc = MyDsDif2.Tables(0).Rows(i).Item(cd_Desc)
                    mVal1 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val1)
                    mVal2 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val2)
                    mDif = MyDsDif2.Tables(0).Rows(i).Item(cd_Dif)
                    Found = False
                    If CheckDataSet(MyDsDif2_Totals) Then
                        For k = 0 To MyDsDif2_Totals.Tables(0).Rows.Count - 1
                            mType2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Type1)
                            mCode2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Code)
                            If mType2 = mType And mCode = mCode2 Then
                                Found = True
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) + mVal1
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) + mVal2
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) + mDif
                                Exit For
                            End If

                        Next
                        If Not Found Then
                            Dim rx As DataRow = DtDif2_Totals.NewRow()
                            rx(cd_PeriodFromCode) = PerFrom.Code
                            rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                            rx(cd_PeriodToCode) = PerTo.Code
                            rx(cd_PeriodToDesc) = PerTo.DescriptionL
                            rx(cd_EmpCode) = ""
                            rx(cd_EmpName) = ""
                            rx(cd_Type1) = mType
                            rx(cd_Code) = mCode
                            rx(cd_Desc) = mDesc
                            rx(cd_Val1) = mVal1
                            rx(cd_Val2) = mVal2
                            rx(cd_Dif) = mDif
                            DtDif2_Totals.Rows.Add(rx)
                        End If
                    Else
                        Dim rx As DataRow = DtDif2_Totals.NewRow()
                        rx(cd_PeriodFromCode) = PerFrom.Code
                        rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                        rx(cd_PeriodToCode) = PerTo.Code
                        rx(cd_PeriodToDesc) = PerTo.DescriptionL
                        rx(cd_EmpCode) = ""
                        rx(cd_EmpName) = ""
                        rx(cd_Type1) = mType
                        rx(cd_Code) = mCode
                        rx(cd_Desc) = mDesc
                        rx(cd_Val1) = mVal1
                        rx(cd_Val2) = mVal2
                        rx(cd_Dif) = mDif
                        DtDif2_Totals.Rows.Add(rx)
                    End If
                End If
            Next
        End If
        '----------------------------------------------------------------------------------------------
        '                                            TOTALS DEDUCTIONS
        '----------------------------------------------------------------------------------------------
        If CheckDataSet(MyDsDif2) Then
            Dim mType As String
            Dim mCode As String
            Dim mDesc As String
            Dim mVal1 As String
            Dim mVal2 As String
            Dim mDif As String

            Dim mType2 As String
            Dim mCode2 As String
            Dim k As Integer

            Dim Found As Boolean = False

            For i = 0 To MyDsDif2.Tables(0).Rows.Count - 1
                mType = MyDsDif2.Tables(0).Rows(i).Item(cd_Type1)
                If mType = "D" Then


                    mCode = MyDsDif2.Tables(0).Rows(i).Item(cd_Code)
                    mDesc = MyDsDif2.Tables(0).Rows(i).Item(cd_Desc)
                    mVal1 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val1)
                    mVal2 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val2)
                    mDif = MyDsDif2.Tables(0).Rows(i).Item(cd_Dif)
                    Found = False
                    If CheckDataSet(MyDsDif2_Totals) Then
                        For k = 0 To MyDsDif2_Totals.Tables(0).Rows.Count - 1
                            mType2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Type1)
                            mCode2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Code)
                            If mType2 = mType And mCode = mCode2 Then
                                Found = True
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) + mVal1
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) + mVal2
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) + mDif
                                Exit For
                            End If

                        Next
                        If Not Found Then
                            Dim rx As DataRow = DtDif2_Totals.NewRow()
                            rx(cd_PeriodFromCode) = PerFrom.Code
                            rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                            rx(cd_PeriodToCode) = PerTo.Code
                            rx(cd_PeriodToDesc) = PerTo.DescriptionL
                            rx(cd_EmpCode) = ""
                            rx(cd_EmpName) = ""
                            rx(cd_Type1) = mType
                            rx(cd_Code) = mCode
                            rx(cd_Desc) = mDesc
                            rx(cd_Val1) = mVal1
                            rx(cd_Val2) = mVal2
                            rx(cd_Dif) = mDif
                            DtDif2_Totals.Rows.Add(rx)
                        End If
                    Else
                        Dim rx As DataRow = DtDif2_Totals.NewRow()
                        rx(cd_PeriodFromCode) = PerFrom.Code
                        rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                        rx(cd_PeriodToCode) = PerTo.Code
                        rx(cd_PeriodToDesc) = PerTo.DescriptionL
                        rx(cd_EmpCode) = ""
                        rx(cd_EmpName) = ""
                        rx(cd_Type1) = mType
                        rx(cd_Code) = mCode
                        rx(cd_Desc) = mDesc
                        rx(cd_Val1) = mVal1
                        rx(cd_Val2) = mVal2
                        rx(cd_Dif) = mDif
                        DtDif2_Totals.Rows.Add(rx)
                    End If
                End If
            Next

        End If

        '----------------------------------------------------------------------------------------------
        '                                            TOTALS CONTRIBUTIONS
        '----------------------------------------------------------------------------------------------
        If CheckDataSet(MyDsDif2) Then
            Dim mType As String
            Dim mCode As String
            Dim mDesc As String
            Dim mVal1 As String
            Dim mVal2 As String
            Dim mDif As String

            Dim mType2 As String
            Dim mCode2 As String
            Dim k As Integer

            Dim Found As Boolean = False

            For i = 0 To MyDsDif2.Tables(0).Rows.Count - 1
                mType = MyDsDif2.Tables(0).Rows(i).Item(cd_Type1)
                If mType = "C" Then


                    mCode = MyDsDif2.Tables(0).Rows(i).Item(cd_Code)
                    mDesc = MyDsDif2.Tables(0).Rows(i).Item(cd_Desc)
                    mVal1 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val1)
                    mVal2 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val2)
                    mDif = MyDsDif2.Tables(0).Rows(i).Item(cd_Dif)
                    Found = False
                    If CheckDataSet(MyDsDif2_Totals) Then
                        For k = 0 To MyDsDif2_Totals.Tables(0).Rows.Count - 1
                            mType2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Type1)
                            mCode2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Code)
                            If mType2 = mType And mCode = mCode2 Then
                                Found = True
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) + mVal1
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) + mVal2
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) + mDif
                                Exit For
                            End If

                        Next
                        If Not Found Then
                            Dim rx As DataRow = DtDif2_Totals.NewRow()
                            rx(cd_PeriodFromCode) = PerFrom.Code
                            rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                            rx(cd_PeriodToCode) = PerTo.Code
                            rx(cd_PeriodToDesc) = PerTo.DescriptionL
                            rx(cd_EmpCode) = ""
                            rx(cd_EmpName) = ""
                            rx(cd_Type1) = mType
                            rx(cd_Code) = mCode
                            rx(cd_Desc) = mDesc
                            rx(cd_Val1) = mVal1
                            rx(cd_Val2) = mVal2
                            rx(cd_Dif) = mDif
                            DtDif2_Totals.Rows.Add(rx)
                        End If
                    Else
                        Dim rx As DataRow = DtDif2_Totals.NewRow()
                        rx(cd_PeriodFromCode) = PerFrom.Code
                        rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                        rx(cd_PeriodToCode) = PerTo.Code
                        rx(cd_PeriodToDesc) = PerTo.DescriptionL
                        rx(cd_EmpCode) = ""
                        rx(cd_EmpName) = ""
                        rx(cd_Type1) = mType
                        rx(cd_Code) = mCode
                        rx(cd_Desc) = mDesc
                        rx(cd_Val1) = mVal1
                        rx(cd_Val2) = mVal2
                        rx(cd_Dif) = mDif
                        DtDif2_Totals.Rows.Add(rx)
                    End If
                End If
            Next
        End If
        '----------------------------------------------------------------------------------------------
        '                                            TOTALS NET
        '----------------------------------------------------------------------------------------------
        If CheckDataSet(MyDsDif2) Then
            Dim mType As String
            Dim mCode As String
            Dim mDesc As String
            Dim mVal1 As String
            Dim mVal2 As String
            Dim mDif As String

            Dim mType2 As String
            Dim mCode2 As String
            Dim k As Integer

            Dim Found As Boolean = False

            For i = 0 To MyDsDif2.Tables(0).Rows.Count - 1
                mType = MyDsDif2.Tables(0).Rows(i).Item(cd_Type1)
                If Trim(mType) = "" Then


                    mCode = MyDsDif2.Tables(0).Rows(i).Item(cd_Code)
                    mDesc = MyDsDif2.Tables(0).Rows(i).Item(cd_Desc)
                    mVal1 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val1)
                    mVal2 = MyDsDif2.Tables(0).Rows(i).Item(cd_Val2)
                    mDif = MyDsDif2.Tables(0).Rows(i).Item(cd_Dif)
                    Found = False
                    If CheckDataSet(MyDsDif2_Totals) Then
                        For k = 0 To MyDsDif2_Totals.Tables(0).Rows.Count - 1
                            mType2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Type1)
                            mCode2 = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Code)
                            If mType2 = mType And mCode = mCode2 Then
                                Found = True
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val1) + mVal1
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Val2) + mVal2
                                MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) = MyDsDif2_Totals.Tables(0).Rows(k).Item(cd_Dif) + mDif
                                Exit For
                            End If

                        Next
                        If Not Found Then
                            Dim rx As DataRow = DtDif2_Totals.NewRow()
                            rx(cd_PeriodFromCode) = PerFrom.Code
                            rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                            rx(cd_PeriodToCode) = PerTo.Code
                            rx(cd_PeriodToDesc) = PerTo.DescriptionL
                            rx(cd_EmpCode) = ""
                            rx(cd_EmpName) = ""
                            rx(cd_Type1) = mType
                            rx(cd_Code) = mCode
                            rx(cd_Desc) = mDesc
                            rx(cd_Val1) = mVal1
                            rx(cd_Val2) = mVal2
                            rx(cd_Dif) = mDif
                            DtDif2_Totals.Rows.Add(rx)
                        End If
                    Else
                        Dim rx As DataRow = DtDif2_Totals.NewRow()
                        rx(cd_PeriodFromCode) = PerFrom.Code
                        rx(cd_PeriodFromDesc) = PerFrom.DescriptionL
                        rx(cd_PeriodToCode) = PerTo.Code
                        rx(cd_PeriodToDesc) = PerTo.DescriptionL
                        rx(cd_EmpCode) = ""
                        rx(cd_EmpName) = ""
                        rx(cd_Type1) = mType
                        rx(cd_Code) = mCode
                        rx(cd_Desc) = mDesc
                        rx(cd_Val1) = mVal1
                        rx(cd_Val2) = mVal2
                        rx(cd_Dif) = mDif
                        DtDif2_Totals.Rows.Add(rx)
                    End If
                End If
            Next
        End If



        Me.Cursor = Cursors.Default

        ' F.Show()

    End Sub

    Private Sub mnuSplitAcrossCompaniesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSplitAcrossCompaniesToolStripMenuItem.Click

        'YTDReport = False
        'DG1.DataSource = MyDs.Tables(0)
        'ClearGrid()


        Dim col_Company As Integer = 0
        Dim col_PeriodCode As Integer = 1
        Dim col_EmpCode As Integer = 2
        Dim col_EmpName As Integer = 3
        Dim col_ActualUnits As Integer = 4
        Dim col_TotalEarnings As Integer = 5
        Dim col_TotalDeductions As Integer = 6
        Dim col_Totalcontributions As Integer = 7
        Dim col_Net As Integer = 8
        Dim col_TaxDeduction As Integer = 9
        Dim col_SIDeduction As Integer = 10

        MyDsSplit.Tables(0).Rows.Clear()


        Dim i As Integer
        Dim k As Integer
        Dim SelectedPeriodGroup As cPrMsPeriodGroups
        SelectedPeriodGroup = CType(cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        Dim SelectedPeriod As cPrMsPeriodCodes
        SelectedPeriod = CType(CmbPeriod.SelectedItem, cPrMsPeriodCodes)

        Dim PerG As cPrMsPeriodGroups
        Dim Per As cPrMsPeriodCodes
        Dim DsEmp As DataSet
        Dim TemGroup As String

        Dim empCode As String
        For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
            PerG = CType(cmbPeriodGroups.Items(i), cPrMsPeriodGroups)
            TemGroup = PerG.TemGrpCode
            Dim TmpGrp As New cPrMsTemplateGroup(TemGroup)
            Dim C As New cAdMsCompany(TmpGrp.CompanyCode)

            If SelectedPeriodGroup.Year = PerG.Year Then
                Per = New cPrMsPeriodCodes(SelectedPeriod.Code, PerG.Code)
                DsEmp = Global1.Business.GetAllRmployessWithSplit(TemGroup)
                If CheckDataSet(DsEmp) Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        empCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(empCode)
                        Dim H As New cPrTxTrxnHeader(empCode, Per.Code)
                        Dim r As DataRow = DtSplit.NewRow()

                        r(col_Company) = C.Name
                        r(col_PeriodCode) = Per.Code
                        r(col_EmpCode) = Emp.Code
                        r(col_EmpName) = Emp.FullName
                        r(col_ActualUnits) = H.PeriodUnits
                        r(col_TotalEarnings) = H.TotalErnPeriod
                        r(col_TotalDeductions) = H.TotalDedPeriod
                        r(col_Totalcontributions) = H.TotalConPeriod
                        r(col_Net) = H.NetSalary
                        r(col_TaxDeduction) = Global1.Business.GetPeriodValueOf_IT_ForHeader(H.Id)
                        r(col_SIDeduction) = Global1.Business.GetPeriodValueOf_SI_ForHeader(H.Id)
                        DtSplit.Rows.Add(r)
                    Next
                End If
            End If
        Next
        Dim F As New FrmDifReport
        F.Ds = MyDsSplit
        F.ShowDialog()

    End Sub

    Private Sub mnuTemplatePayslip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTemplatePayslip.Click
        MyDsPayslip.Tables(0).Rows.Clear()
        Dim TotalEmployees As String = ""

        InitDataTable_3()
        Dim CompanyTotalCost As Double = 0
        If CheckDataSet(MyDs) Then

            Dim MyDs2 As New DataSet
            Dim i As Integer
            Dim k As Integer
            Dim totalsRow As Integer
            totalsRow = MyDs.Tables(0).Rows.Count - 2
            Dim rP As DataRow = DtPayslip.NewRow()

            For i = 0 To MyDs.Tables(0).Columns.Count - 1
                rP(i) = MyDs.Tables(0).Rows(totalsRow).Item(i)
                Debug.WriteLine(rP(i))
            Next
            Dim C2 As Integer = 0
            For k = 0 To 14
                rP(Me.Column_E1 + C2) = MyDs.Tables(0).Rows(0).Item(Me.Column_E1 + C2)
                rP(Me.Column_D1 + C2) = MyDs.Tables(0).Rows(0).Item(Me.Column_D1 + C2)
                rP(Me.Column_C1 + C2) = MyDs.Tables(0).Rows(0).Item(Me.Column_C1 + C2)
                C2 = C2 + 2
            Next
            For i = 0 To MyDs.Tables(0).Columns.Count - 1
                Debug.WriteLine(rP(i))
            Next

            Dim S As String
            S = DbNullToString(MyDs.Tables(0).Rows(totalsRow).Item(Me.Column_EmpCode))
            S = S.Replace("TOTALS (", "")
            S = S.Replace(")", "")
            TotalEmployees = S




            DtPayslip.Rows.Add(rP)
            MyDs2.Tables.Add(MyDsPayslip.Tables(0).Copy)

            If MyDs2.Tables.Count > 0 Then
                ' Dim i As Integer
                Dim j As Integer
                Dim Counter As Integer
                Counter = MyDs2.Tables(0).Rows.Count - 1
                j = Counter



                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = Me.ComboAnal.Text
                If ShowTimeOff Then
                    r(5) = "TOf"
                Else
                    r(5) = "OT3"
                End If
                r(6) = TotalEmployees



                Dt3.Rows.Add(r)
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1

                    Dim C1 As Integer = 0
                    Dim D As String
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                            D = ""
                        Else
                            D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                        End If

                        MyDs2.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                        C1 = C1 + 2

                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                            D = ""
                        Else
                            D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                            D = ""
                        Else
                            D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                        C1 = C1 + 2
                    Next
                Next

                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "" And DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)).StartsWith("TOTALS") = False Then
                        CompanyTotalCost = CompanyTotalCost + DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                    End If
                    If ShowTimeOff Then
                        Dim Tof As Double
                        Tof = DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_OverTime3) = Format(Tof, "0.00")
                    End If


                Next

                r(4) = CompanyTotalCost
                MyDs2.Tables.Add(Dt3)
                Dim c As Integer


                Dim DsComp As New DataSet
                DsComp = Global1.Business.GetCompanyDetailsForShowTotalsAsPayslipReport(Company.Code)
                MyDs2.Tables.Add(DsComp.Tables(0).Copy)
                MyDs2.Tables(2).TableName = "Company"
                'If Per.Code = Per2.Code Then
                '    c = MyDs2.Tables(0).Rows.Count - 1
                '    MyDs2.Tables(0).Rows(c).Delete()
                '    c = MyDs2.Tables(0).Rows.Count - 1
                '    MyDs2.Tables(0).Rows(c - 1).Delete()
                'End If


                Dim ReportToUse As String = "PayslipTotals.rpt"

                'Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\Paysliptotals")
                Utils.ShowReport(ReportToUse, MyDs2, FrmReport, "", False, "", False, False, "", False)
            End If
        End If
    End Sub

    Private Sub mnuSelectEDCToPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectEDCToPrint.Click

        If CheckDataSet(MyDs) Then
            SelDs = New DataSet
            SelDs.Tables.Add(MyDs.Tables(0).Copy)
            Dim i As Integer
            Dim k As Integer
            For i = 0 To SelDs.Tables(0).Rows.Count - 1

                Dim C1 As Integer = 0
                Dim D As String
                For k = 0 To 14
                    If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                        D = ""
                    Else
                        D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                    End If

                    SelDs.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                    C1 = C1 + 2

                Next
                C1 = 0
                For k = 0 To 14
                    If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                        D = ""
                    Else
                        D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                    End If
                    SelDs.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                    C1 = C1 + 2
                Next
                C1 = 0
                For k = 0 To 14
                    If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                        D = ""
                    Else
                        D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                    End If
                    SelDs.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                    C1 = C1 + 2
                Next
            Next
            Dim F As New FrmSelectEDCToPrint
            F.Owner = Me
            F.DS = SelDs.Copy
            F.Column_EV1 = Column_EV1
            F.Column_E1 = Column_E1
            F.Column_DV1 = Column_DV1
            F.Column_D1 = Column_D1
            F.Column_CV1 = Column_CV1
            F.Column_C1 = Column_C1
            F.ShowDialog()
            Try
                F.Dispose()
            Catch ex As Exception

            End Try






            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            InitDataTable_3()
            Dim CompanyTotalCost As Double = 0

            If CheckDataSet(MyDs5) Then

                Dim j As Integer
                Dim Counter As Integer
                Counter = MyDs2.Tables(0).Rows.Count - 1
                j = Counter

                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = Me.ComboAnal.Text
                Dt3.Rows.Add(r)

                r(4) = CompanyTotalCost
                MyDs5.Tables.Add(Dt3)


                Dim ReportToUse As String = "EDCReport1.rpt"


                ' Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                'Utils.WriteSchemaWithXmlTextWriter(MyDs5, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\EDCReport")
                Utils.ShowReport(ReportToUse, MyDs5, FrmReport, "", False, "", False, False, "", False)
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



    End Sub
    Public Function ReturnFromselectionEDC(ByVal DSx As DataSet, ByVal ArE() As Integer, ByVal ArD() As Integer, ByVal ArC() As Integer)
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer


        If CheckDataSet(DSx) Then
            MyDs5.Tables.Clear()
            MyDs5.Tables.Add(dt5)
            dt5.Rows.Clear()
            For i = 0 To DSx.Tables(0).Rows.Count - 1

                Dim r As DataRow = dt5.NewRow()
                Dim Desc As String
                Dim Val As Double
                r(Me.Column_EmpCode) = DSx.Tables(0).Rows(i).Item(Me.Column_EmpCode)
                r(Me.Column_EmpName) = DSx.Tables(0).Rows(i).Item(Me.Column_EmpName)
                r(Me.Column_ActualUnits) = DSx.Tables(0).Rows(i).Item(Me.Column_ActualUnits)



                For k = 0 To 15
                    If ArE(k) <> 0 Then
                        Desc = DbNullToString(DSx.Tables(0).Rows(i).Item(ArE(k)))
                        Val = DbNullToDouble(DSx.Tables(0).Rows(i).Item(ArE(k) + 1))
                    End If
                Next
                '------------------------------------------------------------------
                'Deductions
                '------------------------------------------------------------------

                For k = 0 To 15
                    If ArD(k) <> 0 Then
                        Desc = DbNullToString(DSx.Tables(0).Rows(i).Item(ArD(k)))
                        Val = DbNullToDouble(DSx.Tables(0).Rows(i).Item(ArD(k) + 1))
                    End If
                Next
                '------------------------------------------------------------------
                'Contributions
                '------------------------------------------------------------------
                For k = 0 To 15
                    If ArC(k) <> 0 Then
                        Desc = DbNullToString(DSx.Tables(0).Rows(i).Item(ArC(k)))
                        Val = DbNullToDouble(DSx.Tables(0).Rows(i).Item(ArC(k) + 1))
                    End If
                Next

                r(3) = Desc
                r(4) = Val
                If Trim(Desc) <> "" Then
                    dt5.Rows.Add(r)
                End If

                '''''''''''''''''
                '------------------------------------------------------------------
                'Earnings
                '------------------------------------------------------------------
                'C1 = 0
                'C2 = 0
                'For k = 0 To 14
                '    SelDs.Tables(0).Rows(i).Item(Column_E1 + C1) = ""
                '    SelDs.Tables(0).Rows(i).Item(Column_EV1 + C1) = "0.00"
                '    C1 = C1 + 2
                'Next
                'C1 = 0
                'For k = 0 To 14
                '    If Me.Column_E1 + C1 = ArE(k) Then
                '        Debug.WriteLine(SelDs.Tables(0).Rows(i).Item(Column_E1 + C2))
                '        Debug.WriteLine(DSx.Tables(0).Rows(i).Item(Column_E1 + C1))
                '        SelDs.Tables(0).Rows(i).Item(Column_E1 + C2) = DSx.Tables(0).Rows(i).Item(Column_E1 + C1)
                '        SelDs.Tables(0).Rows(i).Item(Column_EV1 + C2) = DSx.Tables(0).Rows(i).Item(Column_EV1 + C1)
                '        C2 = C2 + 2
                '    End If
                '    C1 = C1 + 2
                'Next


                ''------------------------------------------------------------------
                ''Deductions
                ''------------------------------------------------------------------
                'C1 = 0
                'C2 = 0
                'For k = 0 To 14
                '    SelDs.Tables(0).Rows(i).Item(Column_D1 + C1) = ""
                '    SelDs.Tables(0).Rows(i).Item(Column_DV1 + C1) = "0.00"
                '    C1 = C1 + 2
                'Next
                'C1 = 0
                'For k = 0 To 14
                '    If Me.Column_D1 + C1 = ArD(k) Then
                '        SelDs.Tables(0).Rows(i).Item(Column_D1 + C2) = DSx.Tables(0).Rows(i).Item(Column_D1 + C1)
                '        SelDs.Tables(0).Rows(i).Item(Column_DV1 + C2) = DSx.Tables(0).Rows(i).Item(Column_DV1 + C1)
                '        C2 = C2 + 2
                '    End If
                '    C1 = C1 + 2
                'Next
                ''------------------------------------------------------------------
                ''Contributions
                ''------------------------------------------------------------------
                'C1 = 0
                'C2 = 0
                'For k = 0 To 14
                '    SelDs.Tables(0).Rows(i).Item(Column_C1 + C1) = ""
                '    SelDs.Tables(0).Rows(i).Item(Column_CV1 + C1) = "0.00"
                '    C1 = C1 + 2
                'Next
                'C1 = 0
                'For k = 0 To 14
                '    If Me.Column_C1 + C1 = ArC(k) Then
                '        SelDs.Tables(0).Rows(i).Item(Column_C1 + C2) = DSx.Tables(0).Rows(i).Item(Column_C1 + C1)
                '        SelDs.Tables(0).Rows(i).Item(Column_CV1 + C2) = DSx.Tables(0).Rows(i).Item(Column_CV1 + C1)
                '        C2 = C2 + 2
                '    End If
                '    C1 = C1 + 2
                'Next

                ''''''''''''''''''

            Next
        End If



        'SelDs = New DataSet
        'Dim dt5 As New DataTable

        'SelDs.Tables.Add(dt5)
        'dt5 = Dt1.Copy
        'dt5.Rows.Clear()
        'Dim i As Integer
        'If CheckDataSet(DS) Then
        '    For i = 0 To DS.Tables(0).Rows.Count - 1

        '        dt5 = Dt1.Copy
        '        dt5.Rows.Clear()
        '        Dim r As DataRow = dt5.NewRow()
        '        '''
        '        With DS.Tables(0).Rows(i)
        '            r(Me.Column_PeriodCode) = .Item(Me.Column_PeriodCode)
        '            r(Me.Column_EmpCode) = .Item(Me.Column_EmpCode)
        '            r(Me.Column_EmpName) = .Item(Me.Column_EmpName)
        '            r(Me.Column_NetSalary) = .Item(Me.Column_NetSalary)
        '            r(Me.Column_ActualUnits) = .Item(Me.Column_ActualUnits)
        '            r(Me.Column_Overtime1) = .Item(Me.Column_Overtime1)
        '            r(Me.Column_OverTime2) = .Item(Me.Column_OverTime2)
        '            r(Me.Column_OverTime3) = .Item(Me.Column_OverTime3)
        '            r(Me.Column_Salary1) = .Item(Me.Column_Salary1)
        '            r(Me.Column_Salary2) = .Item(Me.Column_Salary2)
        '            r(Me.Column_sectors) = .Item(Me.Column_sectors)
        '            r(Me.Column_dutyhours) = .Item(Me.Column_dutyhours)
        '            r(Me.Column_flighthours) = .Item(Me.Column_flighthours)
        '            r(Me.Column_commission) = .Item(Me.Column_commission)
        '            r(Me.Column_OverLay) = .Item(Me.Column_OverLay)
        '            r(Me.Column_AnalysisCode) = .Item(Me.Column_AnalysisCode)
        '            r(Column_Position) = .Item(Me.Column_Position)
        '            r(Column_DOE) = .Item(Me.Column_DOE)

        '            Dim C1 As Integer = 0
        '            Dim C2 As Integer = 0
        '            Dim k As Integer

        '            '------------------------------------------------------------------
        '            'Earnings
        '            '------------------------------------------------------------------

        '            For k = 0 To 14
        '                r(Column_E1 + C1) = ""
        '                r(Column_EV1 + C1) = "0.00"
        '            Next
        '            For k = 0 To 14
        '                If Me.Column_E1 + C1 = ArE(k) Then
        '                    r(Column_E1 + C2) = .Item(Column_E1 + C1)
        '                    r(Column_EV1 + C2) = .Item(Column_EV1 + C1)
        '                    C2 = C2 + 2
        '                End If
        '                C1 = C1 + 2
        '            Next


        '            '------------------------------------------------------------------
        '            'Deductions
        '            '------------------------------------------------------------------
        '            C1 = 0
        '            C2 = 0
        '            For k = 0 To 14
        '                r(Column_E1 + C1) = ""
        '                r(Column_EV1 + C1) = "0.00"
        '            Next
        '            For k = 0 To 14
        '                If Me.Column_D1 + C1 = ArD(k) Then
        '                    r(Column_D1 + C2) = .Item(Column_D1 + C1)
        '                    r(Column_DV1 + C2) = .Item(Column_DV1 + C1)
        '                    C2 = C2 + 2
        '                End If
        '                C1 = C1 + 2
        '            Next
        '            '------------------------------------------------------------------
        '            'Contributions
        '            '------------------------------------------------------------------
        '            C1 = 0
        '            C2 = 0
        '            For k = 0 To 14
        '                r(Column_C1 + C1) = ""
        '                r(Column_CV1 + C1) = "0.00"
        '            Next
        '            For k = 0 To 14
        '                If Me.Column_C1 + C1 = ArC(k) Then
        '                    r(Column_C1 + C2) = .Item(Column_C1 + C1)
        '                    r(Column_CV1 + C2) = .Item(Column_CV1 + C1)
        '                    C2 = C2 + 2
        '                End If
        '                C1 = C1 + 2
        '            Next

        '            r(Column_CompanyCost) = .Item(Me.Column_CompanyCost)
        '            r(Column_SITotal) = .Item(Me.Column_SITotal)
        '            r(Column_ChequeNo) = .Item(Me.Column_ChequeNo)

        '            dt5.Rows.Add(r)
        '        End With
        '    Next
        'End If

        'Dim f As New FrmTest
        'f.Ds = MyDs5
        'f.ShowDialog()

        Me.Cursor = Cursors.Default






        '''





    End Function

    Private Sub OvertimeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeReportToolStripMenuItem.Click
        MyDs6.Tables.Clear()
        dt6.Rows.Clear()
        Dt3.Rows.Clear()



        Dim i As Integer
        Dim k As Integer
        Dim C As Integer = 0

        Dim empCode As String
        Dim EmpName As String
        Dim Ot1Val As Double
        Dim Ot2Val As Double
        Dim Ot3Val As Double
        Dim Ot1Hour As Double
        Dim Ot2Hour As Double
        Dim Ot3Hour As Double

        Dim Code As String
        Dim OT1 As Integer = -1
        Dim OT2 As Integer = -1
        Dim OT3 As Integer = -1


        If CheckDataSet(MyDs) Then
            For i = 0 To 1 'MyDs.Tables(0).Rows.Count - 1
                For k = 0 To 14
                    Code = DbNullToString((MyDs.Tables(0).Rows(i).Item(Column_E1 + C)))
                    Dim Ern As New cPrMsEarningCodes(Code)
                    If Ern.Code <> "" Then
                        If Ern.ErnTypCode = "O1" Then
                            OT1 = Column_E1 + C
                        End If
                        If Ern.ErnTypCode = "O2" Then
                            OT2 = Column_E1 + C
                        End If
                        If Ern.ErnTypCode = "O3" Then
                            OT3 = Column_E1 + C
                        End If
                    End If
                    C = C + 2
                Next
            Next
            For i = 0 To MyDs.Tables(0).Rows.Count - 2
                Dim r As DataRow = dt6.NewRow()
                empCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                EmpName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpName))
                If OT1 <> -1 Then
                    Ot1Val = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(OT1 + 1))
                Else
                    Ot1Val = 0
                End If
                If OT2 <> -1 Then
                    Ot2Val = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(OT2 + 1))
                Else
                    Ot2Val = 0
                End If
                If OT3 <> -1 Then
                    Ot3Val = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(OT3 + 1))
                Else
                    Ot3Val = 0
                End If

                Ot1Hour = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                Ot2Hour = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime2))
                Ot3Hour = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime3))

                r(0) = empCode
                r(1) = EmpName
                r(2) = Ot1Val
                r(3) = Ot2Val
                r(4) = Ot3Val
                r(5) = Ot1Hour
                r(6) = Ot2Hour
                r(7) = Ot3Hour

                dt6.Rows.Add(r)

            Next
            Dim ReportToUse As String = "OvertimeReport.rpt"

            MyDs6.Tables.Add(dt6)


            InitDataTable_3()
            Dim CompanyTotalCost As Double = 0

            If CheckDataSet(MyDs6) Then

                Dim j As Integer
                Dim Counter As Integer

                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = Me.ComboAnal.Text
                r(4) = 0

                Dt3.Rows.Add(r)


                MyDs6.Tables.Add(Dt3)
            End If



            '  Utils.WriteSchemaWithXmlTextWriter(MyDs6, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Overtime")
            Utils.ShowReport(ReportToUse, MyDs6, FrmReport, "", False, "", False, False, "", False)

        End If


    End Sub

    Private Sub ProvidentFundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvidentFundToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PFA As Double
        Dim PFB As Double
        Dim C12 As Double
        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPFReport_C12(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PFA = Global1.Business.GetDeductionForHeader(HeaderId, "PF")
                PFB = Global1.Business.GetContributionForHeader(HeaderId, "PF")
                C12 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C12")

                DsHeader.Tables(0).Rows(i).Item(6) = PFA
                DsHeader.Tables(0).Rows(i).Item(7) = PFB
                DsHeader.Tables(0).Rows(i).Item(8) = C12
                TotalAB = TotalAB + PFA + PFB + C12
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        DsCompany.Tables(0).Rows(0).Item(11) = Me.ComboAnal.Text

        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        '  Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PFReportc12")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PFReportC12.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If


    End Sub
    Private Sub ProvidentFuncReport2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvidentFuncReport2ToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PFA As Double
        Dim PFB As Double
        Dim LOAN As Double
        Dim i As Integer
        Dim TotalAB As Double = 0
        Dim GrandTotal As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPFReport_Loan(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PFA = Global1.Business.GetDeductionForHeader(HeaderId, "PF")
                PFB = Global1.Business.GetContributionForHeader(HeaderId, "PF")
                LOAN = Global1.Business.GetDeductionForHeader(HeaderId, "PL")

                DsHeader.Tables(0).Rows(i).Item(6) = PFA
                DsHeader.Tables(0).Rows(i).Item(7) = PFB
                DsHeader.Tables(0).Rows(i).Item(8) = LOAN
                TotalAB = PFA + PFB + LOAN
                DsHeader.Tables(0).Rows(i).Item(10) = TotalAB
                GrandTotal = GrandTotal + TotalAB
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = GrandTotal
        DsCompany.Tables(0).Rows(0).Item(11) = Me.ComboAnal.Text

        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PFReportc12")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PFReportWithLoan.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If


    End Sub
    Private Sub ProvidentFundReport2TotalsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvidentFundReport2TotalsToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PFA As Double
        Dim PFB As Double
        Dim LOAN As Double
        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPFReport_Loan(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PFA = Global1.Business.GetDeductionForHeader(HeaderId, "PF")
                PFB = Global1.Business.GetContributionForHeader(HeaderId, "PF")
                LOAN = Global1.Business.GetDeductionForHeader(HeaderId, "PL")

                DsHeader.Tables(0).Rows(i).Item(6) = PFA
                DsHeader.Tables(0).Rows(i).Item(7) = PFB
                DsHeader.Tables(0).Rows(i).Item(8) = LOAN
                TotalAB = TotalAB + PFA + PFB + LOAN
                DsHeader.Tables(0).Rows(i).Item(10) = TotalAB
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        DsCompany.Tables(0).Rows(0).Item(11) = Me.ComboAnal.Text

        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PFReportc12")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PFReportWithLoanTotals.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If


    End Sub


    Private Sub PensionFundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionFundToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PenFund As Double
        Dim WidowFund As Double
        Dim C10 As Double
        Dim C11 As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPensionFundReport(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PenFund = Global1.Business.GetDeductionForHeader(HeaderId, "PN")
                WidowFund = Global1.Business.GetDeductionForHeader(HeaderId, "WO")
                C10 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C10")
                C11 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C11")

                DsHeader.Tables(0).Rows(i).Item(6) = PenFund
                DsHeader.Tables(0).Rows(i).Item(7) = WidowFund
                DsHeader.Tables(0).Rows(i).Item(8) = C10
                DsHeader.Tables(0).Rows(i).Item(9) = C11
                TotalAB = TotalAB + PenFund + WidowFund + C10 + C11
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        'Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PenFundReport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PensionFund.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If



    End Sub
    Private Sub PensionFund4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionFund4ToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim GrossSal As Double
        Dim Total As Double
        Dim COLA As Double
        Dim PenFund As Double
        Dim WidowFund As Double
        Dim C10 As Double

        Dim Total_GrossSal As Double = 0
        Dim Total_Total As Double = 0
        Dim Total_COLA As Double = 0
        Dim Total_PenFund As Double = 0
        Dim Total_WidowFund As Double = 0
        Dim Total_C10 As Double = 0


        DtPensionFund.Rows.Clear()
        





        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPensionFundReport4(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        Dim AddRecord As Boolean
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                GrossSal = Global1.Business.GetEarningCodeForHeader(HeaderId, "E01")
                COLA = Global1.Business.GetEarningCodeForHeader(HeaderId, "E28")
                PenFund = Global1.Business.GetDeductionCodeForHeader(HeaderId, "D18")
                WidowFund = Global1.Business.GetDeductionForHeader(HeaderId, "WO")
                C10 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C10")

                Total = GrossSal + COLA
                addrecord = True
                If PenFund = 0 And WidowFund = 0 And C10 = 0 Then
                    AddRecord = False
                End If
                If AddRecord Then
                    DsHeader.Tables(0).Rows(i).Item(6) = GrossSal
                    DsHeader.Tables(0).Rows(i).Item(7) = COLA
                    DsHeader.Tables(0).Rows(i).Item(8) = Total
                    DsHeader.Tables(0).Rows(i).Item(9) = PenFund
                    DsHeader.Tables(0).Rows(i).Item(10) = WidowFund
                    DsHeader.Tables(0).Rows(i).Item(11) = C10



                    Total_GrossSal = Total_GrossSal + GrossSal
                    Total_Total = Total_Total + Total
                    Total_COLA = Total_COLA + COLA
                    Total_PenFund = Total_PenFund + PenFund
                    Total_WidowFund = Total_WidowFund + WidowFund
                    Total_C10 = Total_C10 + C10

                    Dim r1 As DataRow = DtPensionFund.NewRow
                    r1(0) = DsHeader.Tables(0).Rows(i).Item(0)
                    r1(1) = DsHeader.Tables(0).Rows(i).Item(1)
                    r1(2) = DsHeader.Tables(0).Rows(i).Item(2)
                    r1(3) = DsHeader.Tables(0).Rows(i).Item(3)
                    r1(4) = DsHeader.Tables(0).Rows(i).Item(4)
                    r1(5) = DsHeader.Tables(0).Rows(i).Item(5)
                    r1(6) = DsHeader.Tables(0).Rows(i).Item(6)
                    r1(7) = DsHeader.Tables(0).Rows(i).Item(7)
                    r1(8) = DsHeader.Tables(0).Rows(i).Item(8)
                    r1(9) = DsHeader.Tables(0).Rows(i).Item(9)
                    r1(10) = DsHeader.Tables(0).Rows(i).Item(10)
                    r1(11) = DsHeader.Tables(0).Rows(i).Item(11)
                    r1(12) = DsHeader.Tables(0).Rows(i).Item(12)
                    DtPensionFund.Rows.Add(r1)
                End If

            Next
            Dim r As DataRow = DtPensionFund.NewRow
            r(0) = 0
            r(1) = "Totals"
            r(2) = ""
            r(3) = 0
            r(4) = 0
            r(5) = 0
            r(6) = Total_GrossSal
            r(7) = Total_COLA
            r(8) = Total_Total
            r(9) = Total_PenFund
            r(10) = Total_WidowFund
            r(11) = Total_C10
            r(12) = ""
            r(13) = ""

            DtPensionFund.Rows.Add(r)


        End If


        Dim DsR As New DataSet
        DsR.Tables.Add(DtPensionFund.Copy)

        Dim DsCompany As DataSet
        Dim GrandTotal As Double
        GrandTotal = Total_PenFund + Total_WidowFund + Total_C10
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)

        DsCompany.Tables(0).Rows(0).Item(10) = GrandTotal
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsR.Tables(0).TableName = "Employee"

        DsR.Tables.Add(DsCompany.Tables(0).Copy)
        DsR.Tables(1).TableName = "Company"

        DsR.Tables.Add(DsPeriod.Tables(0).Copy)
        DsR.Tables(2).TableName = "Period"


        '  Utils.WriteSchemaWithXmlTextWriter(DsR, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PenFundReport4")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PensionFund4.rpt", DsR, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub PensionFund5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionFund5ToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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


        DtPensionFund.Rows.Clear()

        Dim HeaderId As Integer
        Dim GrossSal As Double
        Dim Total As Double
        Dim COLA As Double
        Dim PenFund As Double
        Dim WidowFund As Double
        Dim C18 As Double

        Dim Total_GrossSal As Double = 0
        Dim Total_Total As Double = 0
        Dim Total_COLA As Double = 0
        Dim Total_PenFund As Double = 0
        Dim Total_WidowFund As Double = 0
        Dim Total_C18 As Double = 0



        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPensionFundReport4(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        Dim AddRecord As Boolean = True
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                GrossSal = Global1.Business.GetEarningCodeForHeader(HeaderId, "E01")
                COLA = Global1.Business.GetEarningCodeForHeader(HeaderId, "E28")
                PenFund = Global1.Business.GetDeductionCodeForHeader(HeaderId, "D24")
                WidowFund = Global1.Business.GetDeductionForHeader(HeaderId, "WO")
                C18 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C18")

                Total = GrossSal + COLA
                AddRecord = True

                If PenFund = 0 And C18 = 0 Then
                    AddRecord = False
                End If
                If AddRecord Then
                    DsHeader.Tables(0).Rows(i).Item(6) = GrossSal
                    DsHeader.Tables(0).Rows(i).Item(7) = COLA
                    DsHeader.Tables(0).Rows(i).Item(8) = Total
                    DsHeader.Tables(0).Rows(i).Item(9) = PenFund
                    DsHeader.Tables(0).Rows(i).Item(10) = WidowFund
                    DsHeader.Tables(0).Rows(i).Item(11) = C18

                    Total_GrossSal = Total_GrossSal + GrossSal
                    Total_Total = Total_Total + Total
                    Total_COLA = Total_COLA + COLA
                    Total_PenFund = Total_PenFund + PenFund
                    Total_WidowFund = Total_WidowFund + WidowFund
                    Total_C18 = Total_C18 + C18

                    Dim r1 As DataRow = DtPensionFund.NewRow
                    r1(0) = DsHeader.Tables(0).Rows(i).Item(0)
                    r1(1) = DsHeader.Tables(0).Rows(i).Item(1)
                    r1(2) = DsHeader.Tables(0).Rows(i).Item(2)
                    r1(3) = DsHeader.Tables(0).Rows(i).Item(3)
                    r1(4) = DsHeader.Tables(0).Rows(i).Item(4)
                    r1(5) = DsHeader.Tables(0).Rows(i).Item(5)
                    r1(6) = DsHeader.Tables(0).Rows(i).Item(6)
                    r1(7) = DsHeader.Tables(0).Rows(i).Item(7)
                    r1(8) = DsHeader.Tables(0).Rows(i).Item(8)
                    r1(9) = DsHeader.Tables(0).Rows(i).Item(9)
                    r1(10) = DsHeader.Tables(0).Rows(i).Item(10)
                    r1(11) = DsHeader.Tables(0).Rows(i).Item(11)
                    r1(12) = DsHeader.Tables(0).Rows(i).Item(12)
                    DtPensionFund.Rows.Add(r1)

                End If


            Next
            Dim r As DataRow = DtPensionFund.NewRow
            r(0) = 0
            r(1) = "Totals"
            r(2) = ""
            r(3) = 0
            r(4) = 0
            r(5) = 0
            r(6) = Total_GrossSal
            r(7) = Total_COLA
            r(8) = Total_Total
            r(9) = Total_PenFund
            r(10) = Total_WidowFund
            r(11) = Total_C18
            r(12) = ""
            r(13) = ""

            DtPensionFund.Rows.Add(r)
        End If

        Dim DsR As New DataSet

        DsR.Tables.Add(DtPensionFund.Copy)

        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)

        Dim GrandTotal As Double
        GrandTotal = Total_PenFund + Total_C18

        DsCompany.Tables(0).Rows(0).Item(10) = GrandTotal
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsR.Tables(0).TableName = "Employee"

        DsR.Tables.Add(DsCompany.Tables(0).Copy)
        DsR.Tables(1).TableName = "Company"

        DsR.Tables.Add(DsPeriod.Tables(0).Copy)
        DsR.Tables(2).TableName = "Period"


        'Utils.WriteSchemaWithXmlTextWriter(DsR, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PenFundReport5")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PensionFund5.rpt", DsR, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub CustomPensionFund6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomPensionFund6ToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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


        DtPensionFund.Rows.Clear()

        Dim HeaderId As Integer
        Dim GrossSal As Double
        Dim Total As Double
        Dim COLA As Double
        Dim PenFund As Double
        Dim WidowFund As Double
        Dim C19 As Double

        Dim Total_GrossSal As Double = 0
        Dim Total_Total As Double = 0
        Dim Total_COLA As Double = 0
        Dim Total_PenFund As Double = 0
        Dim Total_WidowFund As Double = 0
        Dim Total_C19 As Double = 0



        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPensionFundReport4(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        Dim AddRecord As Boolean = True
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                GrossSal = Global1.Business.GetEarningCodeForHeader(HeaderId, "E01")
                COLA = Global1.Business.GetEarningCodeForHeader(HeaderId, "E28")
                PenFund = Global1.Business.GetDeductionCodeForHeader(HeaderId, "D25")
                WidowFund = Global1.Business.GetDeductionForHeader(HeaderId, "WO")
                C19 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C19")

                Total = GrossSal + COLA
                AddRecord = True

                If PenFund = 0 And C19 = 0 Then
                    AddRecord = False
                End If
                If AddRecord Then
                    DsHeader.Tables(0).Rows(i).Item(6) = GrossSal
                    DsHeader.Tables(0).Rows(i).Item(7) = COLA
                    DsHeader.Tables(0).Rows(i).Item(8) = Total
                    DsHeader.Tables(0).Rows(i).Item(9) = PenFund
                    DsHeader.Tables(0).Rows(i).Item(10) = WidowFund
                    DsHeader.Tables(0).Rows(i).Item(11) = C19

                    Total_GrossSal = Total_GrossSal + GrossSal
                    Total_Total = Total_Total + Total
                    Total_COLA = Total_COLA + COLA
                    Total_PenFund = Total_PenFund + PenFund
                    Total_WidowFund = Total_WidowFund + WidowFund
                    Total_C19 = Total_C19 + C19

                    Dim r1 As DataRow = DtPensionFund.NewRow
                    r1(0) = DsHeader.Tables(0).Rows(i).Item(0)
                    r1(1) = DsHeader.Tables(0).Rows(i).Item(1)
                    r1(2) = DsHeader.Tables(0).Rows(i).Item(2)
                    r1(3) = DsHeader.Tables(0).Rows(i).Item(3)
                    r1(4) = DsHeader.Tables(0).Rows(i).Item(4)
                    r1(5) = DsHeader.Tables(0).Rows(i).Item(5)
                    r1(6) = DsHeader.Tables(0).Rows(i).Item(6)
                    r1(7) = DsHeader.Tables(0).Rows(i).Item(7)
                    r1(8) = DsHeader.Tables(0).Rows(i).Item(8)
                    r1(9) = DsHeader.Tables(0).Rows(i).Item(9)
                    r1(10) = DsHeader.Tables(0).Rows(i).Item(10)
                    r1(11) = DsHeader.Tables(0).Rows(i).Item(11)
                    r1(12) = DsHeader.Tables(0).Rows(i).Item(12)
                    DtPensionFund.Rows.Add(r1)

                End If


            Next
            Dim r As DataRow = DtPensionFund.NewRow
            r(0) = 0
            r(1) = "Totals"
            r(2) = ""
            r(3) = 0
            r(4) = 0
            r(5) = 0
            r(6) = Total_GrossSal
            r(7) = Total_COLA
            r(8) = Total_Total
            r(9) = Total_PenFund
            r(10) = Total_WidowFund
            r(11) = Total_C19
            r(12) = ""
            r(13) = ""

            DtPensionFund.Rows.Add(r)
        End If

        Dim DsR As New DataSet

        DsR.Tables.Add(DtPensionFund.Copy)

        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)

        Dim GrandTotal As Double
        GrandTotal = Total_PenFund + Total_C19

        DsCompany.Tables(0).Rows(0).Item(10) = GrandTotal
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsR.Tables(0).TableName = "Employee"

        DsR.Tables.Add(DsCompany.Tables(0).Copy)
        DsR.Tables(1).TableName = "Company"

        DsR.Tables.Add(DsPeriod.Tables(0).Copy)
        DsR.Tables(2).TableName = "Period"


        'Utils.WriteSchemaWithXmlTextWriter(DsR, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PenFundReport5")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PensionFund6.rpt", DsR, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ShowAsPayslipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAsPayslipToolStripMenuItem.Click
        MyDsPayslip.Tables(0).Rows.Clear()
        Dim TotalEmployees As String = ""

        InitDataTable_3()
        Dim CompanyTotalCost As Double = 0
        If CheckDataSet(MyDsX) Then

            Dim MyDs3 As New DataSet
            Dim i As Integer
            Dim k As Integer
            Dim totalsRow As Integer
            totalsRow = MyDsX.Tables(0).Rows.Count - 2
            Dim rP As DataRow = DtPayslip.NewRow()

            For i = 0 To MyDsX.Tables(0).Columns.Count - 1
                rP(i) = MyDsX.Tables(0).Rows(totalsRow).Item(i)
                Debug.WriteLine(rP(i))
            Next
            Dim C2 As Integer = 0
            For k = 0 To 14
                rP(Me.Column_E1 + C2) = MyDsX.Tables(0).Rows(0).Item(Me.Column_E1 + C2)
                rP(Me.Column_D1 + C2) = MyDsX.Tables(0).Rows(0).Item(Me.Column_D1 + C2)
                rP(Me.Column_C1 + C2) = MyDsX.Tables(0).Rows(0).Item(Me.Column_C1 + C2)
                C2 = C2 + 2
            Next
            For i = 0 To MyDsX.Tables(0).Columns.Count - 1
                Debug.WriteLine(rP(i))
            Next

            Dim S As String
            S = DbNullToString(MyDsX.Tables(0).Rows(totalsRow).Item(Me.Column_EmpCode))
            S = S.Replace("TOTALS (", "")
            S = S.Replace(")", "")
            TotalEmployees = S




            DtPayslip.Rows.Add(rP)
            MyDs3.Tables.Add(MyDsPayslip.Tables(0).Copy)

            If MyDs3.Tables.Count > 0 Then
                ' Dim i As Integer
                Dim j As Integer
                Dim Counter As Integer
                Counter = MyDs3.Tables(0).Rows.Count - 1
                j = Counter



                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = Me.ComboAnal.Text
                If ShowTimeOff Then
                    r(5) = "TOf"
                Else
                    r(5) = "OT3"
                End If
                r(6) = TotalEmployees



                Dt3.Rows.Add(r)
                For i = 0 To MyDs3.Tables(0).Rows.Count - 1

                    Dim C1 As Integer = 0
                    Dim D As String
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                            D = ""
                        Else
                            D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                        End If

                        MyDs3.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                        C1 = C1 + 2

                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                            D = ""
                        Else
                            D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                        End If
                        MyDs3.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                            D = ""
                        Else
                            D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                        End If
                        MyDs3.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                        C1 = C1 + 2
                    Next
                Next

                For i = 0 To MyDs3.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs3.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "" And DbNullToString(MyDs3.Tables(0).Rows(i).Item(Me.Column_EmpCode)).StartsWith("TOTALS") = False Then
                        CompanyTotalCost = CompanyTotalCost + DbNullToDouble(MyDs3.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                    End If
                    If ShowTimeOff Then
                        Dim Tof As Double
                        Tof = DbNullToDouble(MyDs3.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        MyDs3.Tables(0).Rows(i).Item(Me.Column_OverTime3) = Format(Tof, "0.00")
                    End If
                Next

                r(4) = CompanyTotalCost
                MyDs3.Tables.Add(Dt3)
                Dim c As Integer
                'If Per.Code = Per2.Code Then
                '    c = MyDs3.Tables(0).Rows.Count - 1
                '    MyDs3.Tables(0).Rows(c).Delete()
                '    c = MyDs3.Tables(0).Rows.Count - 1
                '    MyDs3.Tables(0).Rows(c - 1).Delete()
                'End If


                Dim ReportToUse As String = "PayslipTotals.rpt"



                ' Utils.WriteSchemaWithXmlTextWriter(MyDs3, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Paysliptotals")
                Utils.ShowReport(ReportToUse, MyDs3, FrmReport, "", False, "", False, False, "", False)
            End If
        End If
    End Sub

    Private Sub OvertimeReport2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeReport2ToolStripMenuItem.Click
        MyDs6.Tables.Clear()
        dt6.Rows.Clear()
        Dt3.Rows.Clear()



        Dim i As Integer
        Dim k As Integer
        Dim C As Integer = 0

        Dim empCode As String
        Dim EmpName As String
        Dim OtVal As Double

        Dim Ot1Hour As Double
        Dim Ot2Hour As Double
        Dim Ot3Hour As Double

        Dim Code As String
        Dim OT As Integer = -1


        If CheckDataSet(MyDs) Then
            For i = 0 To 1 'MyDs.Tables(0).Rows.Count - 1
                For k = 0 To 14
                    Code = DbNullToString((MyDs.Tables(0).Rows(i).Item(Column_E1 + C)))
                    Dim Ern As New cPrMsEarningCodes(Code)
                    If Ern.Code <> "" Then
                        If Ern.ErnTypCode = "OT" Then
                            OT = Column_E1 + C
                        End If
                        C = C + 2
                    End If
                Next
            Next
            For i = 0 To MyDs.Tables(0).Rows.Count - 2
                Dim r As DataRow = dt6.NewRow()
                empCode = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpCode))
                EmpName = DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_EmpName))
                OtVal = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(OT + 1))




                Ot1Hour = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                Ot2Hour = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime2))
                Ot3Hour = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime3))

                r(0) = empCode
                r(1) = EmpName
                r(2) = OtVal
                r(3) = 0
                r(4) = 0
                r(5) = Ot1Hour
                r(6) = Ot2Hour
                r(7) = Ot3Hour

                dt6.Rows.Add(r)

            Next
            Dim ReportToUse As String = "OvertimeReport2.rpt"

            MyDs6.Tables.Add(dt6)


            InitDataTable_3()
            Dim CompanyTotalCost As Double = 0

            If CheckDataSet(MyDs6) Then

                Dim j As Integer
                Dim Counter As Integer

                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = Me.ComboAnal.Text
                r(4) = 0

                Dt3.Rows.Add(r)


                MyDs6.Tables.Add(Dt3)
            End If



            '  Utils.WriteSchemaWithXmlTextWriter(MyDs6, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Overtime")
            Utils.ShowReport(ReportToUse, MyDs6, FrmReport, "", False, "", False, False, "", False)

        End If
    End Sub

    Private Sub mnuAnnualLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAnnualLeave.Click
        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor


        Dim PerFrom As New cPrMsPeriodCodes

        Dim i As Integer
        Dim DsEmp As DataSet

        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String

        Dim Per As New cPrMsPeriodCodes
        Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)

        Dim PerGrp As New cPrMsPeriodGroups(Per.PrdGrpCode)
        Dim TempGrp As New cPrMsTemplateGroup(PerGrp.TemGrpCode)



        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text


        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim EWallet As Boolean = False

        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If

        Dim dsAL As DataSet
        DsEmp = Global1.Business.GetAllEmployeesForAL(Per, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, EWallet)
        dsAL = Global1.Business.GetParameter("Leave Type", "Annual Leave ID")



        Dim F As New FrmAnnualLeave2
        F.DsEmp = DsEmp
        F.DsAL = dsAL
        F.TempGrp = TempGrp
        F.Per = Per

        F.ShowDialog()

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub UnitsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitsReportToolStripMenuItem.Click
        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDs.Tables(0).Rows.Clear()

        Dim Per As New cPrMsPeriodCodes
        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeader As DataSet
        Dim DsEmp As DataSet
        Dim DsPeriods As DataSet


        Dim EmpToCode As String
        Dim EmpFromCode As String

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text


        DsPeriods = Global1.Business.GetPeriodRange(PerFrom, PerTo)

        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False
        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If

        If CheckDataSet(DsPeriods) Then

            For j = 0 To DsPeriods.Tables(0).Rows.Count - 1



                'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Per = New cPrMsPeriodCodes(DsPeriods.Tables(0).Rows(j))
                GetPeriodEDC(Per)


                DsHeader = Global1.Business.GetUnitsReportForPeriod(Per, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, Ewallet)
                Dim DaysInMonth As Integer

                DaysInMonth = Per.DateFrom.DaysInMonth(Per.DateFrom.Year, Per.DateFrom.Month)

                If CheckDataSet(DsHeader) Then
                    Dim PayType As String = ""
                    Dim units As String = ""
                    Dim dUnits As Integer = 0
                    Dim DaysWorked As Double = 0
                    Dim Unitamount As Double = 0
                    Dim TotalService As Double = 0
                    For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                        PayType = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
                        If PayType = "1" Then
                            DsHeader.Tables(0).Rows(i).Item(2) = "FT"
                        Else
                            DsHeader.Tables(0).Rows(i).Item(2) = "PT"
                        End If
                        units = DbNullToString(DsHeader.Tables(0).Rows(i).Item(4))
                        If units <> "" Then
                            dUnits = CDbl(units)
                        End If

                        DaysWorked = DaysInMonth
                        DsHeader.Tables(0).Rows(i).Item(5) = DaysWorked

                        Unitamount = Global1.PARAM_RPUnitAmount
                        DsHeader.Tables(0).Rows(i).Item(6) = Unitamount

                        TotalService = RoundMe2(Unitamount * dUnits, 2)
                        DsHeader.Tables(0).Rows(i).Item(7) = TotalService

                        DsHeader.Tables(0).Rows(i).Item(10) = Per.DescriptionL & " " & Per.DateFrom.Year

                    Next
                End If
            Next
        End If

        Dim ReportToUse As String
        ReportToUse = "units.rpt"

        'Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Units")
        Utils.ShowReport(ReportToUse, DsHeader, FrmReport, "", False, "", False, False, "", False)


        Me.Cursor = Cursors.Default


    End Sub


    Private Sub TSBUnionReport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBUnionReport1.Click
        prepareUnionReport1()
    End Sub

    Private Sub TSBUnionReport2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBUnionReport2.Click
        prepareUnionReport2()
    End Sub
    Private Sub prepareUnionReport1()
        Dim Anal As Integer
        Anal = Me.ComboSelectAnal.SelectedIndex
        If Anal <> 6 Then
            MsgBox("Please select Union First", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String
        Dim UnionCode As String
        UnionCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text

        Dim HeaderId As Integer
        Dim MFD As Double
        Dim MFC As Double
        Dim MFTOTAL As Double
        Dim LINETOTAL As Double = 0
        Dim UNI As Double
        Dim UNC As Double
        Dim UND As Double
        Dim UNTotal As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForUNIONReport(PerFrom, EmpFrom, Empto, UnionCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                MFD = Global1.Business.GetDeductionForHeader(HeaderId, "MF")
                UNI = Global1.Business.GetDeductionForHeader(HeaderId, "US")
                UND = UNI
                UNC = Global1.Business.GetContributionForHeader(HeaderId, "WF")

                MFC = Global1.Business.GetContributionForHeader(HeaderId, "MF")
                MFTOTAL = MFD + MFC
                LINETOTAL = MFD + MFC + UNI
                UNTotal = UND + UNC

                DsHeader.Tables(0).Rows(i).Item(7) = MFD
                DsHeader.Tables(0).Rows(i).Item(8) = MFC
                DsHeader.Tables(0).Rows(i).Item(9) = MFTOTAL
                DsHeader.Tables(0).Rows(i).Item(10) = UNI
                DsHeader.Tables(0).Rows(i).Item(11) = LINETOTAL
                DsHeader.Tables(0).Rows(i).Item(14) = UNI
                DsHeader.Tables(0).Rows(i).Item(15) = UNC
                DsHeader.Tables(0).Rows(i).Item(16) = UNTotal


            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"

        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\UnionReport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("UnionReport.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub prepareUnionReport2()
        Dim Anal As Integer
        Anal = Me.ComboSelectAnal.SelectedIndex
        If Anal <> 6 Then
            MsgBox("Please select Union First", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String
        Dim UnionCode As String
        UnionCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text

        Dim HeaderId As Integer
        Dim MFD As Double
        Dim MFC As Double
        Dim MFTOTAL As Double
        Dim LINETOTAL As Double = 0
        Dim UNI As Double
        Dim UNC As Double
        Dim UND As Double
        Dim UNTotal As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForUNIONReport(PerFrom, EmpFrom, Empto, UnionCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                MFD = Global1.Business.GetDeductionForHeader(HeaderId, "MF")
                UNI = Global1.Business.GetDeductionForHeader(HeaderId, "US")
                UND = UNI
                UNC = Global1.Business.GetContributionForHeader(HeaderId, "WF")

                MFC = Global1.Business.GetContributionForHeader(HeaderId, "MF")
                MFTOTAL = MFD + MFC
                LINETOTAL = MFD + MFC + UNI
                UNTotal = UND + UNC

                DsHeader.Tables(0).Rows(i).Item(7) = MFD
                DsHeader.Tables(0).Rows(i).Item(8) = MFC
                DsHeader.Tables(0).Rows(i).Item(9) = MFTOTAL
                DsHeader.Tables(0).Rows(i).Item(10) = UNI
                DsHeader.Tables(0).Rows(i).Item(11) = LINETOTAL
                DsHeader.Tables(0).Rows(i).Item(14) = UNI
                DsHeader.Tables(0).Rows(i).Item(15) = UNC
                DsHeader.Tables(0).Rows(i).Item(16) = UNTotal


            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\restored\NodalPay - RND\NodalPay\XML\Unionreport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("UnionReport2.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If

    End Sub


    Private Sub UnionReport3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnionReport3ToolStripMenuItem.Click
        Dim MFUnionDedCode As String
        Dim MFUnionConCode As String
        MFUnionDedCode = PARAM_UnionMedicalDedCode
        MFUnionConCode = PARAM_UnionMedicalConCode

        Dim Anal As Integer
        Anal = Me.ComboSelectAnal.SelectedIndex
        If Anal <> 6 Then
            MsgBox("Please select Union First", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String
        Dim UnionCode As String
        UnionCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text

        Dim HeaderId As Integer
        Dim MFD As Double
        Dim MFC As Double
        Dim MFTOTAL As Double
        Dim LINETOTAL As Double = 0
        Dim UNI As Double
        Dim UNC As Double
        Dim UND As Double
        Dim UNTotal As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForUNIONReport(PerFrom, EmpFrom, Empto, UnionCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))

                MFD = Global1.Business.GetDeductionCodeForHeaderforperiod(HeaderId, MFUnionDedCode, PerFrom.PrdGrpCode, PerFrom.Code)

                UNI = Global1.Business.GetDeductionForHeader(HeaderId, "US")
                UND = UNI
                UNC = Global1.Business.GetContributionForHeader(HeaderId, "WF")

                MFC = Global1.Business.GetContributionCodeForHeaderForPeriod(HeaderId, MFUnionConCode, PerFrom.PrdGrpCode, PerFrom.Code)

                MFTOTAL = MFD + MFC
                'LINETOTAL = MFD + MFC 
                UNTotal = UND + UNC + MFD + MFC

                DsHeader.Tables(0).Rows(i).Item(7) = MFTOTAL
                DsHeader.Tables(0).Rows(i).Item(8) = 0
                DsHeader.Tables(0).Rows(i).Item(9) = 0
                DsHeader.Tables(0).Rows(i).Item(10) = UNI
                DsHeader.Tables(0).Rows(i).Item(11) = LINETOTAL
                DsHeader.Tables(0).Rows(i).Item(14) = UNI
                DsHeader.Tables(0).Rows(i).Item(15) = UNC
                DsHeader.Tables(0).Rows(i).Item(16) = UNTotal


            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\restored\NodalPay - RND\NodalPay\XML\Unionreport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("UnionReport3.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub UnionReport4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnionReport4ToolStripMenuItem.Click
        Dim MFUnionDedCode As String
        Dim MFUnionConCode As String
        Dim FishesErnCode As String
        MFUnionDedCode = PARAM_UnionMedicalDedCode
        MFUnionConCode = PARAM_UnionMedicalConCode
        FishesErnCode = PARAM_UnionFishes

        Dim Anal As Integer
        Anal = Me.ComboSelectAnal.SelectedIndex
        If Anal <> 6 Then
            MsgBox("Please select Union First", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String
        Dim UnionCode As String
        UnionCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text

        Dim HeaderId As Integer
        Dim MFD As Double
        Dim MFC As Double
        Dim MFTOTAL As Double
        Dim LINETOTAL As Double = 0
        Dim UNI As Double
        Dim UNC As Double
        Dim UND As Double
        Dim UNTotal As Double
        Dim Fishes As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForUNIONReport(PerFrom, EmpFrom, Empto, UnionCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))

                MFD = Global1.Business.GetDeductionCodeForHeaderForPeriod(HeaderId, MFUnionDedCode, PerFrom.PrdGrpCode, PerFrom.Code)

                UNI = Global1.Business.GetDeductionForHeader(HeaderId, "US")
                MFC = Global1.Business.GetContributionCodeForHeaderForPeriod(HeaderId, MFUnionConCode, PerFrom.PrdGrpCode, PerFrom.Code)
                Fishes = Global1.Business.GetEarningCodeForHeaderForPeriod(HeaderId, FishesErnCode, PerFrom.PrdGrpCode, PerFrom.Code)


                'LINETOTAL = MFD + MFC 
                UNTotal = MFD + MFC + UNI + Fishes

                DsHeader.Tables(0).Rows(i).Item(7) = MFD
                DsHeader.Tables(0).Rows(i).Item(8) = MFC
                DsHeader.Tables(0).Rows(i).Item(9) = fishes
                DsHeader.Tables(0).Rows(i).Item(10) = UNI
                DsHeader.Tables(0).Rows(i).Item(11) = 0
                DsHeader.Tables(0).Rows(i).Item(14) = 0
                DsHeader.Tables(0).Rows(i).Item(15) = 0
                DsHeader.Tables(0).Rows(i).Item(16) = UNTotal


            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\restored\NodalPay - RND\NodalPay\XML\Unionreport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("UnionReport4.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Report5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Report5ToolStripMenuItem.Click

        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        PrepareReport_Differences4(PY)
        '  Utils.WriteSchemaWithXmlTextWriter(MyDsDif, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Variance1")
        Utils.ShowReport("Variance5.rpt", MyDsDif, FrmReport, "", False, "", False, False, "", True)

    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
        YTDReport = False
        usemydsx = False
        Me.ShowAnalysisDescription = False
        If Me.CBIncludeanalysisDesc.CheckState = CheckState.Checked Then
            Me.ShowAnalysisDescription = True
        End If

        If Me.CBOrderByAnal.CheckState = CheckState.Unchecked Then
            MsgBox("For this report , please check 'Sort By Analysis' check box and specify Analysis number in the text box beside", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes).Code <> CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes).Code Then
            MsgBox("This report applies only for the same From - To Period.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'InitDataGrid()
        Me.lblStatus.Visible = True
        DG1.DataSource = MyDs.Tables(0)

        'PrepareReport()
        PrepareReport3(False)
        Me.lblStatus.Visible = False
    End Sub
    Private Sub PrepareReport3(ByVal OnlyActiveemployees As Boolean)
        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDs.Tables(0).Rows.Clear()

        Dim Per As New cPrMsPeriodCodes
        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeader As DataSet
        Dim DsEmp As DataSet
        Dim DsPeriods As DataSet

        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String

        Dim GenAnal1 As String
        Dim SICategory As String

        Dim OrderByAnal As Integer = 0

        If Me.CBOrderByAnal.CheckState = CheckState.Checked Then
            If Me.txtOrderBy.Text = "" Then
                MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If
            OrderByAnal = txtOrderBy.Text

            If OrderByAnal <= 0 Or OrderByAnal >= 8 Then
                MsgBox("Please select a Valid Department Number Or GlAnalysis1 for Sorting, Valid Values are 1 to 6 and 7 for General Analysis 1 ", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If
        End If

        GenAnal1 = Me.txtGenAnal1.Text
        SICategory = Me.txtSICategory.Text

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If
        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        DsPeriods = Global1.Business.GetPeriodRange(PerFrom, PerTo)
        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False


        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If


        If CheckDataSet(DsPeriods) Then

            For j = 0 To DsPeriods.Tables(0).Rows.Count - 1



                'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Per = New cPrMsPeriodCodes(DsPeriods.Tables(0).Rows(j))
                GetPeriodEDC(Per)


                DsHeader = Global1.Business.GetAllTrxnHeaderForPeriod_GroupByAnalysis(Per, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, OnlyActiveemployees, GenAnal1, OrderByAnal, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, Ewallet)
                LoadHeaderOfReport_GroupByAnalysis(DsHeader, Per, True, OrderByAnal)
            Next
        End If



        Me.Cursor = Cursors.Default


    End Sub
    Private Sub LoadHeaderOfReport_GroupByAnalysis(ByVal DsHeader As DataSet, ByVal Per As cPrMsPeriodCodes, ByVal IncludeTotals As Boolean, ByVal OrderByAnal As Integer)
        Dim TotalEmp As Integer = 0
        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0
        Dim j As Integer
        Dim k As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0

        Dim i As Integer

        Dim tempAnal As String = ""
        Dim From_i As Integer
        Dim To_i As Integer


        Dim LinErn As DataSet
        Dim LinDed As DataSet
        Dim LinCon As DataSet
        Dim ErnCode As String
        Dim DedCode As String
        Dim Concode As String
        Dim HdrId As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Dim NetSalary As Double
        Dim PeriodUnit As Double

        Dim Ei As Integer
        Dim Di As Integer
        Dim Ci As Integer
        Dim ErnValue As Double
        Dim DedValue As Double
        Dim ConValue As Double
        Dim ErnDesc As String
        Dim DedDesc As String
        Dim ConDesc As String

        Dim TotalE As Double = 0
        Dim TotalD As Double = 0
        Dim TotalC As Double = 0
        Dim Overtime1 As Double = 0
        Dim Overtime2 As Double = 0
        Dim Overtime3 As Double = 0

        Dim Salary1 As Double = 0
        Dim Salary2 As Double = 0

        Dim Sectors As Double = 0
        Dim DutyHours As Double = 0
        Dim FlightHours As Double = 0
        Dim Commission As Double = 0
        Dim Overlay As Double = 0
        Dim PosCode As String = ""


        Dim SIDeductionCode As String
        Dim SIContributionCode As String
        Dim Reference As String



        Dim AnalDesc As String
        Dim AnalCode As String


        Dim Total As Double = 0
        Dim AU As Double = 0
        Dim NetSal As Double = 0
        Dim TE As Double = 0
        Dim TD As Double = 0
        Dim TC As Double = 0
        Dim CCost As Double = 0
        Dim SICost As Double = 0
        Dim TotalOT1 As Double = 0
        Dim TotalOT2 As Double = 0
        Dim TotalOT3 As Double = 0
        Dim TotalSal1 As Double = 0
        Dim TotalSal2 As Double = 0

        Dim TotalSectors As Double = 0
        Dim totaldutyhours As Double = 0
        Dim totalflighthours As Double = 0
        Dim totalcommission As Double = 0
        Dim totalOverlay As Double = 0
        Dim TotalTo As Double = 0

        Dim CNo As String
        Dim Counter As Integer = 0
        Dim GLAnal1 As String = ""

        Dim AL_Code1 As String = ""
        Dim AL_Code2 As String = ""
        Dim AL_Code3 As String = ""
        Dim AL_Code4 As String = ""
        Dim AL_Code5 As String = ""

        Dim AL_Desc1 As String = ""
        Dim AL_Desc2 As String = ""
        Dim AL_Desc3 As String = ""
        Dim AL_Desc4 As String = ""
        Dim AL_Desc5 As String = ""

        Dim TermDate As String = ""
        Dim SINumber As String = ""

        Dim BankBenName As String = ""
        Dim ComBank As String = ""
        Dim DOB As String = ""
        Dim Identity As String = ""
        Dim TIC As String = ""
        Dim FullAddress As String = ""


        If CheckDataSet(DsHeader) Then


            SIDeductionCode = Global1.Business.GetDecuctionCodeForSI
            SIContributionCode = Global1.Business.GetContributionCodeForSI

            TotalEmp = 0

            For i = 0 To DsHeader.Tables(0).Rows.Count - 1

                Application.DoEvents()
                Me.lblStatus.Text = "Please wait Loading Report Lines " & i

                TotalEmp = DsHeader.Tables(0).Rows.Count

                SIDedTotal = 0
                SIConTotal = 0

                Dim r As DataRow = Dt1.NewRow()

                HdrId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                EmpCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
                NetSalary = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(3))
                PeriodUnit = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(5))
                Reference = DbNullToString(DsHeader.Tables(0).Rows(i).Item(6))

                Overtime1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(7))
                Overtime2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(8))

                Salary1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(9))
                Salary2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(10))
                Overtime3 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(11))

                Sectors = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(12))
                DutyHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(13))
                FlightHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(14))
                Commission = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(15))
                Overlay = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(19))
                AnalysisCode2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(18))
                PosCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(22))
                DOE = Format(DbNullToDate(DsHeader.Tables(0).Rows(i).Item(21)), "dd/MM/yyyy")

                GLAnal1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(36))

                TermDate = DbNullToString(DsHeader.Tables(0).Rows(i).Item(47))
                SINumber = DbNullToString(DsHeader.Tables(0).Rows(i).Item(48))

                BankBenName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(49))
                ComBank = DbNullToString(DsHeader.Tables(0).Rows(i).Item(50))
                DOB = DbNullToDate(DsHeader.Tables(0).Rows(i).Item(51))
                Identity = DbNullToString(DsHeader.Tables(0).Rows(i).Item(52))
                TIC = DbNullToString(DsHeader.Tables(0).Rows(i).Item(53))
                FullAddress = DbNullToString(DsHeader.Tables(0).Rows(i).Item(54))
                FullAddress = FullAddress & " " & DbNullToString(DsHeader.Tables(0).Rows(i).Item(55))
                FullAddress = FullAddress & " " & DbNullToString(DsHeader.Tables(0).Rows(i).Item(56))
                FullAddress = FullAddress & " " & DbNullToString(DsHeader.Tables(0).Rows(i).Item(57))


                AL_Code1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(37))
                AL_Code2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(38))
                AL_Code3 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(39))
                AL_Code4 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(40))
                AL_Code5 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(41))

                AL_Desc1 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(42))
                AL_Desc2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(43))
                AL_Desc3 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(44))
                AL_Desc4 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(45))
                AL_Desc5 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(46))


                Dim EmpPos As New cPrAnEmployeePositions(PosCode)
                Position = EmpPos.DescriptionL
                If tempAnal = "" Then
                    tempAnal = AnalysisCode2
                    From_i = 0
                    To_i = 0
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If AnalysisCode2 <> tempAnal Then

                    To_i = Counter - 1



                    AnalCode = tempAnal
                    tempAnal = AnalysisCode2

                    Total = 0
                    AU = 0
                    NetSal = 0
                    TE = 0
                    TD = 0
                    TC = 0
                    CCost = 0
                    SICost = 0
                    TotalOT1 = 0
                    TotalOT2 = 0
                    TotalOT3 = 0
                    TotalSal1 = 0
                    TotalSal2 = 0

                    TotalSectors = 0
                    totaldutyhours = 0
                    totalflighthours = 0
                    totalcommission = 0
                    totalOverlay = 0
                    TotalTo = 0

                    CNo = ""

                    If CheckDataSet(MyDs) Then
                        If Not YTDReport Then
                            Dim x As Integer
                            ' Dim Rempty As DataRow = Dt1.NewRow()
                            ' Dt1.Rows.Add(Rempty)
                            Select Case OrderByAnal
                                Case 1
                                    Dim Anal1 As New cPrAnEmployeeAnalysis1(AnalCode)
                                    AnalDesc = Anal1.DescriptionL
                                Case 2
                                    Dim Anal2 As New cPrAnEmployeeAnalysis2(AnalCode)
                                    AnalDesc = Anal2.DescriptionL
                                Case 3
                                    Dim Anal3 As New cPrAnEmployeeAnalysis3(AnalCode)
                                    AnalDesc = Anal3.DescriptionL
                                Case 4
                                    Dim Anal4 As New cPrAnEmployeeAnalysis4(AnalCode)
                                    AnalDesc = Anal4.DescriptionL
                                Case 5
                                    Dim Anal5 As New cPrAnEmployeeAnalysis5(AnalCode)
                                    AnalDesc = Anal5.EmpAn5_DescriptionL
                                Case 6
                                    Dim Union As New cPrAnUnions(AnalCode)
                                    AnalDesc = Union.DescriptionL
                                Case 7
                                    AnalDesc = AnalCode
                            End Select

                            Dim rA As DataRow = Dt1.NewRow()

                            rA(Me.Column_EmpCode) = "SUB Total (" & To_i - From_i + 1 & ")"
                            rA(Me.Column_EmpName) = "ANALYSIS - " & AnalDesc

                            C1 = 0
                            For k = 0 To 14
                                Total = 0
                                'For x = 0 To MyDs.Tables(0).Rows.Count - 1
                                For x = From_i To To_i
                                    If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                                        Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_EV1 + C1))
                                        '********************************************************************
                                        rA(Me.Column_E1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_E1 + C1))
                                        '********************************************************************
                                    End If
                                Next
                                rA(Me.Column_EV1 + C1) = Total
                                C1 = C1 + 2
                            Next
                            C1 = 0
                            For k = 0 To 14
                                Total = 0
                                'For x = 0 To MyDs.Tables(0).Rows.Count - 1
                                For x = From_i To To_i
                                    If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                                        Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_DV1 + C1))
                                        '********************************************************************
                                        rA(Me.Column_D1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_D1 + C1))
                                        '********************************************************************
                                    End If
                                Next
                                rA(Me.Column_DV1 + C1) = Total
                                C1 = C1 + 2
                            Next
                            C1 = 0
                            For k = 0 To 14
                                Total = 0
                                'For x = 0 To MyDs.Tables(0).Rows.Count - 1
                                For x = From_i To To_i
                                    If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                                        Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_CV1 + C1))
                                        '********************************************************************
                                        rA(Me.Column_C1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_C1 + C1))
                                        '********************************************************************
                                    End If
                                Next
                                rA(Me.Column_CV1 + C1) = Total
                                C1 = C1 + 2
                            Next

                            AU = 0
                            NetSal = 0
                            TE = 0
                            TD = 0
                            TC = 0
                            CCost = 0
                            SICost = 0
                            TotalOT1 = 0
                            TotalOT2 = 0
                            TotalSal1 = 0
                            TotalSal2 = 0

                            TotalSectors = 0
                            totaldutyhours = 0
                            totalflighthours = 0
                            totalcommission = 0
                            totalOverlay = 0
                            TotalTo = 0

                            TotalTo = 0

                            For x = From_i To To_i
                                If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                                    AU = AU + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_ActualUnits))
                                    NetSal = NetSal + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_NetSalary))
                                    TE = TE + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_EVTotal))
                                    TD = TD + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_DVTotal))
                                    TC = TC + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_CVTotal))
                                    CCost = CCost + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_CompanyCost))
                                    SICost = SICost + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_SITotal))
                                    TotalOT1 = TotalOT1 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_Overtime1))
                                    TotalOT2 = TotalOT2 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_OverTime2))
                                    TotalOT3 = TotalOT3 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_OverTime3))
                                    TotalSal1 = TotalSal1 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_Salary1))
                                    TotalSal2 = TotalSal2 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_Salary2))

                                    TotalSectors = TotalSectors + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_sectors))
                                    totaldutyhours = totaldutyhours + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_dutyhours))
                                    totalflighthours = totalflighthours + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_flighthours))
                                    totalcommission = totalcommission + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_commission))
                                    totalOverlay = totalOverlay + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_OverLay))
                                    TotalTo = TotalTo + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_TimeOff))
                                End If

                            Next

                            rA(Me.Column_ActualUnits) = Format(AU, "0.00")
                            rA(Me.Column_NetSalary) = Format(NetSal, "0.00")
                            rA(Me.Column_EVTotal) = Format(TE, "0.00")
                            rA(Me.Column_DVTotal) = Format(TD, "0.00")
                            rA(Me.Column_CVTotal) = Format(TC, "0.00")
                            rA(Me.Column_CompanyCost) = Format(CCost, "0.00")
                            rA(Me.Column_SITotal) = Format(SICost, "0.00")
                            rA(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                            rA(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                            rA(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
                            rA(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                            rA(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                            rA(Me.Column_sectors) = Format(TotalSectors, "0.00")
                            rA(Me.Column_dutyhours) = Format(totaldutyhours, "0.00")
                            rA(Me.Column_flighthours) = Format(totalflighthours, "0.00")
                            rA(Me.Column_commission) = Format(totalcommission, "0.00")
                            rA(Me.Column_OverLay) = Format(totalOverlay, "0.00")
                            rA(Me.Column_AnalysisCode) = ""
                            rA(Me.Column_Position) = ""
                            rA(Me.Column_DOE) = ""
                            rA(Me.Column_TimeOff) = Format(TotalTo, "0.00")


                            rA(Me.Column_GenAnal1) = GLAnal1

                            rA(Column_AL_Code1) = ""
                            rA(Column_AL_Code2) = ""
                            rA(Column_AL_Code3) = ""
                            rA(Column_AL_Code4) = ""
                            rA(Column_AL_Code5) = ""
                            rA(Column_AL_Desc1) = ""
                            rA(Column_AL_Desc2) = ""
                            rA(Column_AL_Desc3) = ""
                            rA(Column_AL_Desc4) = ""
                            rA(Column_AL_Desc5) = ""

                          


                            Dt1.Rows.Add(rA)
                            Counter = Counter + 1

                            'Rempty = Dt1.NewRow()
                            ' Dt1.Rows.Add(Rempty)

                            'Dim rx As DataRow = Dt1.NewRow()
                            'Dt1.Rows.Add(rx)
                            'Application.DoEvents()
                            'Me.lblStatus.Text = "Please wait Calcultating Totals " & i
                            From_i = Counter
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                End If


                LinErn = Global1.Business.GetTrxnLinesEarningsForHeaderForPeriod(HdrId, Per)
                LinDed = Global1.Business.GetTrxnLinesDeductionsForHeaderForPeriod(HdrId, Per)
                LinCon = Global1.Business.GetTrxnLinesContributionsForHeaderForPeriod(HdrId, Per)

                r(Me.Column_PeriodCode) = Per.Code
                r(Me.Column_EmpCode) = EmpCode
                r(Me.Column_EmpName) = EmpName
                r(Me.Column_NetSalary) = NetSalary
                r(Me.Column_ActualUnits) = PeriodUnit
                r(Me.Column_Overtime1) = Format(Overtime1, "0.00")
                r(Me.Column_OverTime2) = Format(Overtime2, "0.00")
                r(Me.Column_OverTime3) = Format(Overtime3, "0.00")
                r(Me.Column_Salary1) = Format(Salary1, "0.00")
                r(Me.Column_Salary2) = Format(Salary2, "0.00")

                r(Me.Column_sectors) = Format(Sectors, "0.00")
                r(Me.Column_dutyhours) = Format(DutyHours, "0.00")
                r(Me.Column_flighthours) = Format(FlightHours, "0.00")
                r(Me.Column_commission) = Format(Commission, "0.00")
                r(Me.Column_OverLay) = Format(Overlay, "0.00")
                r(Me.Column_AnalysisCode) = AnalysisCode2
                r(Me.Column_GenAnal1) = GLAnal1

                r(Column_AL_Code1) = AL_Code1
                r(Column_AL_Code2) = AL_Code2
                r(Column_AL_Code3) = AL_Code3
                r(Column_AL_Code4) = AL_Code4
                r(Column_AL_Code5) = AL_Code5

                r(Column_AL_Desc1) = AL_Desc1
                r(Column_AL_Desc2) = AL_Desc2
                r(Column_AL_Desc3) = AL_Desc3
                r(Column_AL_Desc4) = AL_Desc4
                r(Column_AL_Desc5) = AL_Desc5

                r(Me.Column_Analysis2) = AL_Desc2

                r(Column_Position) = Position
                r(Column_DOE) = DOE

                r(Column_Termdate) = TermDate
                r(Column_SINumber) = SINumber

                r(Column_BankBenName) = BankBenName
                r(Column_ComBank) = ComBank
                r(Column_DOB) = DOB
                r(Column_identity) = Identity
                r(Column_TIC) = TIC
                r(Column_Address) = FullAddress





                Dim Ce As Integer = 0
                Dim Cd As Integer = 0
                Dim Cc As Integer = 0

                '------------------------------------------------------------------
                'Earnings
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    r(Me.Column_E1 + C1) = ""
                    C1 = C1 + 2
                    r(Me.Column_EV1 + C2) = "0.00"
                    C2 = C2 + 2
                Next
                TotalE = 0
                If CheckDataSet(DsP_Ern) Then
                    For Ei = 0 To DsP_Ern.Tables(0).Rows.Count - 1
                        Dim NotInclude As Boolean = False
                        ErnCode = DbNullToString(DsP_Ern.Tables(0).Rows(Ei).Item(3))
                        ErnValue = 0
                        ErnDesc = ""
                        r(Me.Column_E1 + Ce) = ErnCode
                        Dim TCODE As New cPrMsEarningCodes(ErnCode)
                        For k = 0 To LinErn.Tables(0).Rows.Count - 1
                            If DbNullToString(LinErn.Tables(0).Rows(k).Item(0)) = ErnCode Then
                                ErnValue = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(1))
                                ErnDesc = DbNullToString(LinErn.Tables(0).Rows(k).Item(2))
                                If TCODE.ErnTypCode = "TO" Then
                                    Dim T As Double = 0
                                    T = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(4))
                                    r(Me.Column_TimeOff) = Format(T, "0.00")
                                End If
                                Exit For
                            End If
                        Next

                        If TCODE.Code <> "" Then
                            If TCODE.ErnTypCode = "3E" Or TCODE.ErnTypCode = "4E" Or TCODE.ErnTypCode = "UM" Or TCODE.ErnTypCode = "LP" Or TCODE.ErnTypCode = "BK" Or TCODE.ErnTypCode = "BR" Or TCODE.ErnTypCode = "B2" Then
                                NotInclude = True
                            End If
                            If TCODE.ErnTypCode = Global1.Param_IncludeInTotal1 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal2 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal3 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal4 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal5 Then
                                NotInclude = False
                            End If
                        End If
                        If Not NotInclude Then
                            TotalE = TotalE + ErnValue
                        End If
                        r(Me.Column_EV1 + Ce) = Format(ErnValue, "0.00")
                        ChangeColumnName(ErnDesc, Column_EV1 + Ce, "E")
                        Ce = Ce + 2
                        ErnValue = 0
                        NotInclude = False


                    Next
                    r(Me.Column_EVTotal) = Format(TotalE, "0.00")


                    Application.DoEvents()

                End If
                '------------------------------------------------------------------
                'Deductions
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    r(Me.Column_D1 + C1) = ""
                    C1 = C1 + 2
                    r(Me.Column_DV1 + C2) = "0.00"
                    C2 = C2 + 2
                Next
                TotalD = 0
                If CheckDataSet(DsP_Ded) Then
                    For Di = 0 To DsP_Ded.Tables(0).Rows.Count - 1
                        DedValue = 0
                        DedCode = DbNullToString(DsP_Ded.Tables(0).Rows(Di).Item(3))
                        DedDesc = ""
                        r(Me.Column_D1 + Cd) = DedCode
                        For k = 0 To LinDed.Tables(0).Rows.Count - 1
                            If DbNullToString(LinDed.Tables(0).Rows(k).Item(0)) = DedCode Then

                                DedValue = DbNullToDouble(LinDed.Tables(0).Rows(k).Item(1))
                                DedDesc = DbNullToString(LinDed.Tables(0).Rows(k).Item(2))
                                If DedCode = SIDeductionCode Then
                                    SIDedTotal = SIDedTotal + DedValue
                                End If
                                Exit For
                            End If
                        Next
                        TotalD = TotalD + DedValue
                        r(Me.Column_DV1 + Cd) = Format(DedValue, "0.00")
                        ChangeColumnName(DedDesc, Column_DV1 + Cd, "D")
                        Cd = Cd + 2
                    Next
                    r(Column_DVTotal) = Format(TotalD, "0.00")

                End If
                '------------------------------------------------------------------
                'Contributions
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    r(Me.Column_C1 + C1) = ""
                    C1 = C1 + 2
                    r(Me.Column_CV1 + C2) = "0.00"
                    C2 = C2 + 2
                Next
                TotalC = 0
                If CheckDataSet(DsP_Con) Then
                    For Ci = 0 To DsP_Con.Tables(0).Rows.Count - 1
                        Concode = DbNullToString(DsP_Con.Tables(0).Rows(Ci).Item(3))
                        ConValue = 0
                        ConDesc = ""
                        r(Me.Column_C1 + Cc) = Concode
                        For k = 0 To LinCon.Tables(0).Rows.Count - 1
                            If DbNullToString(LinCon.Tables(0).Rows(k).Item(0)) = Concode Then
                                ConValue = DbNullToDouble(LinCon.Tables(0).Rows(k).Item(1))
                                ConDesc = DbNullToString(LinCon.Tables(0).Rows(k).Item(2))
                                If Concode = SIContributionCode Then
                                    SIConTotal = SIConTotal + ConValue
                                End If
                                Exit For
                            End If
                        Next
                        TotalC = TotalC + ConValue
                        r(Me.Column_CV1 + Cc) = Format(ConValue, "0.00")
                        ChangeColumnName(ConDesc, Column_CV1 + Cc, "C")
                        Cc = Cc + 2
                    Next
                    r(Column_CVTotal) = Format(TotalC, "0.00")
                End If
                r(Column_CompanyCost) = Format(TotalE + TotalC, "0.00")
                r(Column_SITotal) = Format((SIConTotal + SIDedTotal), "0.00")
                r(Column_ChequeNo) = Reference

                Dt1.Rows.Add(r)
                Counter = Counter + 1
            Next
        End If


        '-This is For the Last Line of Analysis
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If CheckDataSet(MyDs) Then
            To_i = Counter - 1


            AnalCode = tempAnal
            tempAnal = AnalysisCode2

            Total = 0
            AU = 0
            NetSal = 0
            TE = 0
            TD = 0
            TC = 0
            CCost = 0
            SICost = 0
            TotalOT1 = 0
            TotalOT2 = 0
            TotalOT3 = 0
            TotalSal1 = 0
            TotalSal2 = 0

            TotalSectors = 0
            totaldutyhours = 0
            totalflighthours = 0
            totalcommission = 0
            totalOverlay = 0
            TotalTo = 0


            CNo = ""

            If Not YTDReport Then
                Dim x As Integer
                '  Dim Rempty As DataRow = Dt1.NewRow()
                ' Dt1.Rows.Add(Rempty)
                Select Case OrderByAnal
                    Case 1
                        Dim Anal1 As New cPrAnEmployeeAnalysis1(AnalCode)
                        AnalDesc = Anal1.DescriptionL
                    Case 2
                        Dim Anal2 As New cPrAnEmployeeAnalysis2(AnalCode)
                        AnalDesc = Anal2.DescriptionL
                    Case 3
                        Dim Anal3 As New cPrAnEmployeeAnalysis3(AnalCode)
                        AnalDesc = Anal3.DescriptionL
                    Case 4
                        Dim Anal4 As New cPrAnEmployeeAnalysis4(AnalCode)
                        AnalDesc = Anal4.DescriptionL
                    Case 5
                        Dim Anal5 As New cPrAnEmployeeAnalysis5(AnalCode)
                        AnalDesc = Anal5.EmpAn5_DescriptionL
                    Case 6
                        Dim Union As New cPrAnUnions(AnalCode)
                        AnalDesc = Union.DescriptionL
                    Case 7

                        AnalDesc = AnalCode
                End Select

                Dim rA As DataRow = Dt1.NewRow()

                rA(Me.Column_EmpCode) = "SUB Totals (" & To_i - From_i + 1 & ")"
                rA(Me.Column_EmpName) = "ANALYSIS - " & AnalDesc

                C1 = 0
                For k = 0 To 14
                    Total = 0
                    'For x = 0 To MyDs.Tables(0).Rows.Count - 1
                    For x = From_i To To_i
                        If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                            Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_EV1 + C1))
                            '********************************************************************
                            rA(Me.Column_E1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_E1 + C1))
                            '********************************************************************
                        End If
                    Next
                    rA(Me.Column_EV1 + C1) = Total
                    C1 = C1 + 2
                Next
                C1 = 0
                For k = 0 To 14
                    Total = 0
                    'For x = 0 To MyDs.Tables(0).Rows.Count - 1
                    For x = From_i To To_i
                        If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                            Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_DV1 + C1))
                            '********************************************************************
                            rA(Me.Column_D1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_D1 + C1))
                            '********************************************************************
                        End If
                    Next
                    rA(Me.Column_DV1 + C1) = Total
                    C1 = C1 + 2
                Next
                C1 = 0
                For k = 0 To 14
                    Total = 0
                    'For x = 0 To MyDs.Tables(0).Rows.Count - 1
                    For x = From_i To To_i
                        If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                            Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_CV1 + C1))
                            '********************************************************************
                            rA(Me.Column_C1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_C1 + C1))
                            '********************************************************************
                        End If
                    Next
                    rA(Me.Column_CV1 + C1) = Total
                    C1 = C1 + 2
                Next

                AU = 0
                NetSal = 0
                TE = 0
                TD = 0
                TC = 0
                CCost = 0
                SICost = 0
                TotalOT1 = 0
                TotalOT2 = 0
                TotalSal1 = 0
                TotalSal2 = 0

                TotalSectors = 0
                totaldutyhours = 0
                totalflighthours = 0
                totalcommission = 0
                totalOverlay = 0
                TotalTo = 0

                TotalTo = 0

                For x = From_i To To_i
                    If DbNullToString(MyDs.Tables(0).Rows(x).Item(Me.Column_PeriodCode)) = Per.Code Then
                        AU = AU + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_ActualUnits))
                        NetSal = NetSal + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_NetSalary))
                        TE = TE + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_EVTotal))
                        TD = TD + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_DVTotal))
                        TC = TC + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_CVTotal))
                        CCost = CCost + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_CompanyCost))
                        SICost = SICost + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_SITotal))
                        TotalOT1 = TotalOT1 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_Overtime1))
                        TotalOT2 = TotalOT2 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_OverTime2))
                        TotalOT3 = TotalOT3 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_OverTime3))
                        TotalSal1 = TotalSal1 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_Salary1))
                        TotalSal2 = TotalSal2 + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_Salary2))

                        TotalSectors = TotalSectors + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_sectors))
                        totaldutyhours = totaldutyhours + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_dutyhours))
                        totalflighthours = totalflighthours + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_flighthours))
                        totalcommission = totalcommission + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_commission))
                        totalOverlay = totalOverlay + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_OverLay))
                        TotalTo = TotalTo + DbNullToDouble(MyDs.Tables(0).Rows(x).Item(Me.Column_TimeOff))
                    End If

                Next

                rA(Me.Column_ActualUnits) = Format(AU, "0.00")
                rA(Me.Column_NetSalary) = Format(NetSal, "0.00")
                rA(Me.Column_EVTotal) = Format(TE, "0.00")
                rA(Me.Column_DVTotal) = Format(TD, "0.00")
                rA(Me.Column_CVTotal) = Format(TC, "0.00")
                rA(Me.Column_CompanyCost) = Format(CCost, "0.00")
                rA(Me.Column_SITotal) = Format(SICost, "0.00")
                rA(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                rA(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                rA(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
                rA(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                rA(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                rA(Me.Column_sectors) = Format(TotalSectors, "0.00")
                rA(Me.Column_dutyhours) = Format(totaldutyhours, "0.00")
                rA(Me.Column_flighthours) = Format(totalflighthours, "0.00")
                rA(Me.Column_commission) = Format(totalcommission, "0.00")
                rA(Me.Column_OverLay) = Format(totalOverlay, "0.00")
                rA(Me.Column_AnalysisCode) = ""
                rA(Me.Column_Position) = ""
                rA(Me.Column_DOE) = ""
                rA(Me.Column_TimeOff) = Format(TotalTo, "0.00")
                rA(Me.Column_GenAnal1) = GLAnal1


                Dt1.Rows.Add(rA)
                Counter = Counter + 1

                'Rempty = Dt1.NewRow()
                ' Dt1.Rows.Add(Rempty)

                'Dim rx As DataRow = Dt1.NewRow()
                'Dt1.Rows.Add(rx)
                'Application.DoEvents()
                'Me.lblStatus.Text = "Please wait Calcultating Totals " & i
                From_i = Counter

            End If
        End If


        '--       End of Last Line Analysis ---------------------------------------------------------------------------


        If IncludeTotals Then
            Total = 0
            AU = 0
            NetSal = 0
            TE = 0
            TD = 0
            TC = 0
            CCost = 0
            SICost = 0
            TotalOT1 = 0
            TotalOT2 = 0
            TotalOT3 = 0
            TotalSal1 = 0
            TotalSal2 = 0
            TotalSectors = 0
            totaldutyhours = 0
            totalflighthours = 0
            totalcommission = 0
            totalOverlay = 0
            TotalTo = 0
            CNo = ""

            If CheckDataSet(MyDs) Then
                If Not YTDReport Then
                    Dim Rempty As DataRow = Dt1.NewRow()
                    Dt1.Rows.Add(Rempty)

                    Dim r As DataRow = Dt1.NewRow()

                    r(Me.Column_EmpCode) = "TOTALS (" & TotalEmp & ")"
                    r(Me.Column_EmpName) = Per.Code & " - " & Per.DescriptionL

                    C1 = 0
                    For k = 0 To 14
                        Total = 0
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EV1 + C1))
                                '********************************************************************
                                r(Me.Column_E1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_E1 + C1))
                                '********************************************************************
                            End If
                        Next
                        r(Me.Column_EV1 + C1) = Total
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        Total = 0
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV1 + C1))
                                '********************************************************************
                                r(Me.Column_D1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_D1 + C1))
                                '********************************************************************
                            End If
                        Next
                        r(Me.Column_DV1 + C1) = Total
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        Total = 0
                        For i = 0 To MyDs.Tables(0).Rows.Count - 1
                            If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                                Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CV1 + C1))
                                '********************************************************************
                                r(Me.Column_C1 + C1) = DbNullToString(MyDs.Tables(0).Rows(0).Item(Me.Column_C1 + C1))
                                '********************************************************************
                            End If
                        Next
                        r(Me.Column_CV1 + C1) = Total
                        C1 = C1 + 2
                    Next

                    AU = 0
                    NetSal = 0
                    TE = 0
                    TD = 0
                    TC = 0
                    CCost = 0
                    SICost = 0
                    TotalOT1 = 0
                    TotalOT2 = 0
                    TotalSal1 = 0
                    TotalSal2 = 0

                    TotalSectors = 0
                    totaldutyhours = 0
                    totalflighthours = 0
                    totalcommission = 0
                    totalOverlay = 0
                    TotalTo = 0

                    TotalTo = 0

                    For i = 0 To Counter - 1
                        If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
                            AU = AU + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
                            NetSal = NetSal + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_NetSalary))
                            TE = TE + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EVTotal))
                            TD = TD + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DVTotal))
                            TC = TC + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CVTotal))
                            CCost = CCost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                            SICost = SICost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SITotal))
                            TotalOT1 = TotalOT1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
                            TotalOT2 = TotalOT2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime2))
                            TotalOT3 = TotalOT3 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime3))
                            TotalSal1 = TotalSal1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary1))
                            TotalSal2 = TotalSal2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary2))

                            TotalSectors = TotalSectors + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_sectors))
                            totaldutyhours = totaldutyhours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_dutyhours))
                            totalflighthours = totalflighthours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_flighthours))
                            totalcommission = totalcommission + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_commission))
                            totalOverlay = totalOverlay + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverLay))
                            TotalTo = TotalTo + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        End If

                    Next

                    r(Me.Column_ActualUnits) = Format(AU, "0.00")
                    r(Me.Column_NetSalary) = Format(NetSal, "0.00")
                    r(Me.Column_EVTotal) = Format(TE, "0.00")
                    r(Me.Column_DVTotal) = Format(TD, "0.00")
                    r(Me.Column_CVTotal) = Format(TC, "0.00")
                    r(Me.Column_CompanyCost) = Format(CCost, "0.00")
                    r(Me.Column_SITotal) = Format(SICost, "0.00")
                    r(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
                    r(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
                    r(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
                    r(Me.Column_Salary1) = Format(TotalSal1, "0.00")
                    r(Me.Column_Salary2) = Format(TotalSal2, "0.00")

                    r(Me.Column_sectors) = Format(TotalSectors, "0.00")
                    r(Me.Column_dutyhours) = Format(totaldutyhours, "0.00")
                    r(Me.Column_flighthours) = Format(totalflighthours, "0.00")
                    r(Me.Column_commission) = Format(totalcommission, "0.00")
                    r(Me.Column_OverLay) = Format(totalOverlay, "0.00")
                    r(Me.Column_AnalysisCode) = ""
                    r(Me.Column_Position) = ""
                    r(Me.Column_DOE) = ""
                    r(Me.Column_TimeOff) = Format(TotalTo, "0.00")






                    Dt1.Rows.Add(r)


                    Dim rx As DataRow = Dt1.NewRow()
                    Dt1.Rows.Add(rx)
                    Application.DoEvents()
                    Me.lblStatus.Text = "Please wait Calcultating Totals " & i
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EDCTotalsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDCTotalsToolStripMenuItem.Click
        SentToPrinter(False, True, False)
    End Sub
    Private Sub EDCTotalsAndCostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDCTotalsAndCostToolStripMenuItem.Click
        SentToPrinter(False, False, True)
    End Sub
    Private Sub txtFromEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromEmployee.TextChanged
        Me.txtToEmployee.Text = Me.txtFromEmployee.Text
    End Sub

    
    
    'Private Sub PrepareEDCTotalsReport_Test()
    '    Dim TotalEmp As Integer = 0
    '    Dim RepDs As DataSet

    '    Me.Cursor = Cursors.WaitCursor

    '    Dim Per As New cPrMsPeriodCodes
    '    Dim PerFrom As New cPrMsPeriodCodes
    '    Dim PerTo As New cPrMsPeriodCodes
    '    Dim i As Integer
    '    Dim C1 As Integer = 0
    '    Dim C2 As Integer = 0
    '    Dim k As Integer

    '    Dim DsHeader As DataSet
    '    Dim DsEmp As DataSet
    '    Dim DsPeriods As DataSet

    '    Dim SIDedTotal As Double = 0
    '    Dim SIConTotal As Double = 0

    '    Dim EmpToCode As String
    '    Dim EmpFromCode As String

    '    Dim GenAnal1 As String

    '    Dim OrderByAnal As Integer = 0
    '    If Me.CBOrderByAnal.CheckState = CheckState.Checked Then
    '        If Me.txtOrderBy.Text = "" Then
    '            MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
    '            Me.Cursor = Cursors.Default
    '            Application.DoEvents()
    '            Exit Sub
    '        End If
    '        OrderByAnal = txtOrderBy.Text
    '        If OrderByAnal <= 0 Or OrderByAnal >= 7 Then
    '            MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
    '            Me.Cursor = Cursors.Default
    '            Application.DoEvents()
    '            Exit Sub
    '        End If
    '    End If

    '    PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)

    '    EmpFromCode = Me.txtFromEmployee.Text
    '    EmpToCode = Me.txtToEmployee.Text

    '    GenAnal1 = Me.txtGenAnal1.Text



    '    ClearGrid()
    '    Dim j As Integer
    '    Dim Analysis As Integer
    '    Dim AnalysisCode As String
    '    Dim AnalysisCode2 As String
    '    Dim Position As String = ""
    '    Dim DOE As String = ""
    '    Analysis = Me.ComboSelectAnal.SelectedIndex
    '    Select Case Analysis
    '        Case 0
    '            AnalysisCode = "0"
    '        Case 1
    '            AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis1).Code
    '        Case 2
    '            AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis2).Code
    '        Case 3
    '            AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis3).Code
    '        Case 4
    '            AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis4).Code
    '        Case 5
    '            AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnEmployeeAnalysis5).EmpAn5_Code
    '        Case 6
    '            AnalysisCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
    '    End Select

    '    Dim Cash As Boolean = False
    '    Dim Cheque As Boolean = False
    '    Dim Bank As Boolean = False
    '    If Me.CBCheque.CheckState = CheckState.Checked Then
    '        Cheque = True
    '    End If
    '    If Me.CBCash.CheckState = CheckState.Checked Then
    '        Cash = True
    '    End If
    '    If Me.CBBank.CheckState = CheckState.Checked Then
    '        Bank = True
    '    End If



    '    Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)

    '    Dim Ds As DataSet
    '    Dim Ern1 As String = ""
    '    Dim Ern2 As String = ""
    '    Ds = Global1.Business.GetParameter("Report", "ECode1")
    '    If CheckDataSet(Ds) Then
    '        Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
    '        Ern1 = Par.Value1
    '    Else
    '        MsgBox("Please Define Earning1 Code 'Report', 'ECode1' parameter", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If
    '    Ds = Global1.Business.GetParameter("Report", "ECode2")
    '    If CheckDataSet(Ds) Then
    '        Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
    '        Ern2 = Par.Value1
    '    Else
    '        MsgBox("Please Define Earning1 Code 'Report', 'ECode2' parameter", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If

    '    RepDs = Global1.Business.GetAllTrxnHeaderForPeriodEDCTotals1(Per, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, GenAnal1, OrderByAnal, Ern1, Ern2)




    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    InitDataTable_3()
    '    Dim CompanyTotalCost As Double = 0

    '    If CheckDataSet(RepDs) Then

    '        Dim Counter As Integer
    '        Counter = MyDs2.Tables(0).Rows.Count - 1
    '        j = Counter

    '        Dim Per2 As New cPrMsPeriodCodes
    '        Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

    '        Dim r As DataRow = Dt3.NewRow()

    '        Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
    '        Dim Company As New cAdMsCompany(TemCode.CompanyCode)
    '        r(0) = Company.Name
    '        r(1) = TemCode.Code & " - " & TemCode.DescriptionL
    '        If Per.Code <> Per2.Code Then
    '            r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
    '        Else
    '            r(2) = Per.Code & " - " & Per.DescriptionL
    '        End If
    '        r(3) = Me.ComboAnal.Text
    '        Dt3.Rows.Add(r)

    '        r(4) = CompanyTotalCost
    '        RepDs.Tables.Add(Dt3)


    '        Dim ReportToUse As String = "TotalsEDC1.rpt"


    '        ' Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
    '        Utils.WriteSchemaWithXmlTextWriter(RepDs, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\TotalsEDC1")
    '        Utils.ShowReport(ReportToUse, RepDs, FrmReport, "", False, "", False, False, "", False)
    '    End If

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




    'End Sub
    'Private Sub LoadHeaderOfReportEDCTotals1(ByVal DsHeader As DataSet, ByVal Per As cPrMsPeriodCodes, ByVal IncludeTotals As Boolean)
    '    Dim TotalEmp As Integer = 0
    '    Dim SIDedTotal As Double = 0
    '    Dim SIConTotal As Double = 0
    '    Dim j As Integer
    '    Dim k As Integer
    '    Dim Analysis As Integer
    '    Dim AnalysisCode As String
    '    Dim AnalysisCode2 As String
    '    Dim Position As String = ""
    '    Dim DOE As String = ""
    '    Dim C1 As Integer = 0
    '    Dim C2 As Integer = 0

    '    Dim i As Integer

    '    If CheckDataSet(DsHeader) Then

    '        Dim LinErn As DataSet
    '        Dim LinDed As DataSet
    '        Dim LinCon As DataSet
    '        Dim ErnCode As String
    '        Dim DedCode As String
    '        Dim Concode As String
    '        Dim HdrId As Integer
    '        Dim EmpCode As String
    '        Dim EmpName As String
    '        Dim NetSalary As Double
    '        Dim PeriodUnit As Double

    '        Dim Ei As Integer
    '        Dim Di As Integer
    '        Dim Ci As Integer
    '        Dim ErnValue As Double
    '        Dim DedValue As Double
    '        Dim ConValue As Double
    '        Dim ErnDesc As String
    '        Dim DedDesc As String
    '        Dim ConDesc As String

    '        Dim TotalE As Double = 0
    '        Dim TotalD As Double = 0
    '        Dim TotalC As Double = 0
    '        Dim Overtime1 As Double = 0
    '        Dim Overtime2 As Double = 0
    '        Dim Overtime3 As Double = 0

    '        Dim Salary1 As Double = 0
    '        Dim Salary2 As Double = 0

    '        Dim Sectors As Double = 0
    '        Dim DutyHours As Double = 0
    '        Dim FlightHours As Double = 0
    '        Dim Commission As Double = 0
    '        Dim Overlay As Double = 0
    '        Dim PosCode As String = ""



    '        Dim SIDeductionCode As String
    '        Dim SIContributionCode As String
    '        Dim Reference As String

    '        SIDeductionCode = Global1.Business.GetDecuctionCodeForSI
    '        SIContributionCode = Global1.Business.GetContributionCodeForSI

    '        TotalEmp = 0

    '        For i = 0 To DsHeader.Tables(0).Rows.Count - 1

    '            Application.DoEvents()
    '            Me.lblStatus.Text = "Please wait Loading Report Lines " & i

    '            TotalEmp = DsHeader.Tables(0).Rows.Count

    '            SIDedTotal = 0
    '            SIConTotal = 0
    '            Dim r As DataRow = Dt1.NewRow()
    '            HdrId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
    '            EmpCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(1))
    '            EmpName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
    '            NetSalary = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(3))
    '            PeriodUnit = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(5))
    '            Reference = DbNullToString(DsHeader.Tables(0).Rows(i).Item(6))

    '            Overtime1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(7))
    '            Overtime2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(8))

    '            Salary1 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(9))
    '            Salary2 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(10))
    '            Overtime3 = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(11))

    '            Sectors = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(12))
    '            DutyHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(13))
    '            FlightHours = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(14))
    '            Commission = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(15))
    '            Overlay = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(19))
    '            AnalysisCode2 = DbNullToString(DsHeader.Tables(0).Rows(i).Item(18))
    '            PosCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(22))
    '            DOE = DbNullToDate(DsHeader.Tables(0).Rows(i).Item(21))

    '            Dim EmpPos As New cPrAnEmployeePositions(PosCode)
    '            Position = EmpPos.DescriptionL


    '            LinErn = Global1.Business.GetTrxnLinesEarningsForHeaderForPeriod(HdrId, Per)
    '            LinDed = Global1.Business.GetTrxnLinesDeductionsForHeaderForPeriod(HdrId, Per)
    '            LinCon = Global1.Business.GetTrxnLinesContributionsForHeaderForPeriod(HdrId, Per)

    '            r(Me.Column_PeriodCode) = Per.Code
    '            r(Me.Column_EmpCode) = EmpCode
    '            r(Me.Column_EmpName) = EmpName
    '            r(Me.Column_NetSalary) = NetSalary
    '            r(Me.Column_ActualUnits) = PeriodUnit
    '            r(Me.Column_Overtime1) = Format(Overtime1, "0.00")
    '            r(Me.Column_OverTime2) = Format(Overtime2, "0.00")
    '            r(Me.Column_OverTime3) = Format(Overtime3, "0.00")
    '            r(Me.Column_Salary1) = Format(Salary1, "0.00")
    '            r(Me.Column_Salary2) = Format(Salary2, "0.00")

    '            r(Me.Column_sectors) = Format(Sectors, "0.00")
    '            r(Me.Column_dutyhours) = Format(DutyHours, "0.00")
    '            r(Me.Column_flighthours) = Format(FlightHours, "0.00")
    '            r(Me.Column_commission) = Format(Commission, "0.00")
    '            r(Me.Column_OverLay) = Format(Overlay, "0.00")
    '            r(Me.Column_AnalysisCode) = AnalysisCode2

    '            r(Column_Position) = Position
    '            r(Column_DOE) = DOE




    '            Dim Ce As Integer = 0
    '            Dim Cd As Integer = 0
    '            Dim Cc As Integer = 0

    '            '------------------------------------------------------------------
    '            'Earnings
    '            '------------------------------------------------------------------
    '            C1 = 0
    '            C2 = 0
    '            For k = 0 To 14
    '                r(Me.Column_E1 + C1) = ""
    '                C1 = C1 + 2
    '                r(Me.Column_EV1 + C2) = "0.00"
    '                C2 = C2 + 2
    '            Next
    '            TotalE = 0
    '            If CheckDataSet(DsP_Ern) Then
    '                For Ei = 0 To DsP_Ern.Tables(0).Rows.Count - 1
    '                    Dim NotInclude As Boolean = False
    '                    ErnCode = DbNullToString(DsP_Ern.Tables(0).Rows(Ei).Item(3))
    '                    ErnValue = 0
    '                    ErnDesc = ""
    '                    r(Me.Column_E1 + Ce) = ErnCode
    '                    Dim TCODE As New cPrMsEarningCodes(ErnCode)
    '                    For k = 0 To LinErn.Tables(0).Rows.Count - 1
    '                        If DbNullToString(LinErn.Tables(0).Rows(k).Item(0)) = ErnCode Then
    '                            ErnValue = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(1))
    '                            ErnDesc = DbNullToString(LinErn.Tables(0).Rows(k).Item(2))
    '                            If TCODE.ErnTypCode = "TO" Then
    '                                Dim T As Double = 0
    '                                T = DbNullToDouble(LinErn.Tables(0).Rows(k).Item(4))
    '                                r(Me.Column_TimeOff) = Format(T, "0.00")
    '                            End If
    '                            Exit For
    '                        End If
    '                    Next

    '                    If TCODE.Code <> "" Then
    '                        If TCODE.ErnTypCode = "3E" Or TCODE.ErnTypCode = "4E" Or TCODE.ErnTypCode = "UM" Or TCODE.ErnTypCode = "LP" Or TCODE.ErnTypCode = "BK" Or TCODE.ErnTypCode = "BR" Then
    '                            NotInclude = True
    '                        End If
    '                        If TCODE.ErnTypCode = Global1.Param_IncludeInTotal1 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal2 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal3 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal4 Or TCODE.ErnTypCode = Global1.Param_IncludeInTotal5 Then
    '                            NotInclude = False
    '                        End If
    '                    End If
    '                    If Not NotInclude Then
    '                        TotalE = TotalE + ErnValue
    '                    End If
    '                    r(Me.Column_EV1 + Ce) = Format(ErnValue, "0.00")
    '                    ChangeColumnName(ErnDesc, Column_EV1 + Ce, "E")
    '                    Ce = Ce + 2
    '                    ErnValue = 0
    '                    NotInclude = False


    '                Next
    '                r(Me.Column_EVTotal) = Format(TotalE, "0.00")


    '                Application.DoEvents()

    '            End If
    '            '------------------------------------------------------------------
    '            'Deductions
    '            '------------------------------------------------------------------
    '            C1 = 0
    '            C2 = 0
    '            For k = 0 To 14
    '                r(Me.Column_D1 + C1) = ""
    '                C1 = C1 + 2
    '                r(Me.Column_DV1 + C2) = "0.00"
    '                C2 = C2 + 2
    '            Next
    '            TotalD = 0
    '            If CheckDataSet(DsP_Ded) Then
    '                For Di = 0 To DsP_Ded.Tables(0).Rows.Count - 1
    '                    DedValue = 0
    '                    DedCode = DbNullToString(DsP_Ded.Tables(0).Rows(Di).Item(3))
    '                    DedDesc = ""
    '                    r(Me.Column_D1 + Cd) = DedCode
    '                    For k = 0 To LinDed.Tables(0).Rows.Count - 1
    '                        If DbNullToString(LinDed.Tables(0).Rows(k).Item(0)) = DedCode Then

    '                            DedValue = DbNullToDouble(LinDed.Tables(0).Rows(k).Item(1))
    '                            DedDesc = DbNullToString(LinDed.Tables(0).Rows(k).Item(2))
    '                            If DedCode = SIDeductionCode Then
    '                                SIDedTotal = SIDedTotal + DedValue
    '                            End If
    '                            Exit For
    '                        End If
    '                    Next
    '                    TotalD = TotalD + DedValue
    '                    r(Me.Column_DV1 + Cd) = Format(DedValue, "0.00")
    '                    ChangeColumnName(DedDesc, Column_DV1 + Cd, "D")
    '                    Cd = Cd + 2
    '                Next
    '                r(Column_DVTotal) = Format(TotalD, "0.00")

    '            End If
    '            '------------------------------------------------------------------
    '            'Contributions
    '            '------------------------------------------------------------------
    '            C1 = 0
    '            C2 = 0
    '            For k = 0 To 14
    '                r(Me.Column_C1 + C1) = ""
    '                C1 = C1 + 2
    '                r(Me.Column_CV1 + C2) = "0.00"
    '                C2 = C2 + 2
    '            Next
    '            TotalC = 0
    '            If CheckDataSet(DsP_Con) Then
    '                For Ci = 0 To DsP_Con.Tables(0).Rows.Count - 1
    '                    Concode = DbNullToString(DsP_Con.Tables(0).Rows(Ci).Item(3))
    '                    ConValue = 0
    '                    ConDesc = ""
    '                    r(Me.Column_C1 + Cc) = Concode
    '                    For k = 0 To LinCon.Tables(0).Rows.Count - 1
    '                        If DbNullToString(LinCon.Tables(0).Rows(k).Item(0)) = Concode Then
    '                            ConValue = DbNullToDouble(LinCon.Tables(0).Rows(k).Item(1))
    '                            ConDesc = DbNullToString(LinCon.Tables(0).Rows(k).Item(2))
    '                            If Concode = SIContributionCode Then
    '                                SIConTotal = SIConTotal + ConValue
    '                            End If
    '                            Exit For
    '                        End If
    '                    Next
    '                    TotalC = TotalC + ConValue
    '                    r(Me.Column_CV1 + Cc) = Format(ConValue, "0.00")
    '                    ChangeColumnName(ConDesc, Column_CV1 + Cc, "C")
    '                    Cc = Cc + 2
    '                Next
    '                r(Column_CVTotal) = Format(TotalC, "0.00")
    '            End If
    '            r(Column_CompanyCost) = Format(TotalE + TotalC, "0.00")
    '            r(Column_SITotal) = Format((SIConTotal + SIDedTotal), "0.00")
    '            r(Column_ChequeNo) = Reference

    '            Dt1.Rows.Add(r)
    '        Next
    '    End If

    '    If IncludeTotals Then
    '        Dim Total As Double = 0
    '        Dim AU As Double = 0
    '        Dim NetSal As Double = 0
    '        Dim TE As Double = 0
    '        Dim TD As Double = 0
    '        Dim TC As Double = 0
    '        Dim CCost As Double = 0
    '        Dim SICost As Double = 0
    '        Dim TotalOT1 As Double = 0
    '        Dim TotalOT2 As Double = 0
    '        Dim TotalOT3 As Double = 0
    '        Dim TotalSal1 As Double = 0
    '        Dim TotalSal2 As Double = 0

    '        Dim TotalSectors As Double = 0
    '        Dim totaldutyhours As Double = 0
    '        Dim totalflighthours As Double = 0
    '        Dim totalcommission As Double = 0
    '        Dim totalOverlay As Double = 0
    '        Dim TotalTo As Double = 0

    '        Dim CNo As String

    '        If CheckDataSet(MyDs) Then
    '            If Not YTDReport Then
    '                Dim Rempty As DataRow = Dt1.NewRow()
    '                Dt1.Rows.Add(Rempty)

    '                Dim r As DataRow = Dt1.NewRow()
    '                r(Me.Column_EmpCode) = "TOTALS (" & TotalEmp & ")"
    '                r(Me.Column_EmpName) = Per.Code & " - " & Per.DescriptionL

    '                C1 = 0
    '                For k = 0 To 14
    '                    Total = 0
    '                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
    '                        If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
    '                            Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EV1 + C1))
    '                        End If
    '                    Next
    '                    r(Me.Column_EV1 + C1) = Total
    '                    C1 = C1 + 2
    '                Next
    '                C1 = 0
    '                For k = 0 To 14
    '                    Total = 0
    '                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
    '                        If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
    '                            Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV1 + C1))
    '                        End If
    '                    Next
    '                    r(Me.Column_DV1 + C1) = Total
    '                    C1 = C1 + 2
    '                Next
    '                C1 = 0
    '                For k = 0 To 14
    '                    Total = 0
    '                    For i = 0 To MyDs.Tables(0).Rows.Count - 1
    '                        If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
    '                            Total = Total + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CV1 + C1))
    '                        End If
    '                    Next
    '                    r(Me.Column_CV1 + C1) = Total
    '                    C1 = C1 + 2
    '                Next

    '                AU = 0
    '                NetSal = 0
    '                TE = 0
    '                TD = 0
    '                TC = 0
    '                CCost = 0
    '                SICost = 0
    '                TotalOT1 = 0
    '                TotalOT2 = 0
    '                TotalSal1 = 0
    '                TotalSal2 = 0

    '                TotalSectors = 0
    '                totaldutyhours = 0
    '                totalflighthours = 0
    '                totalcommission = 0
    '                totalOverlay = 0
    '                TotalTo = 0

    '                TotalTo = 0

    '                For i = 0 To MyDs.Tables(0).Rows.Count - 1
    '                    If DbNullToString(MyDs.Tables(0).Rows(i).Item(Me.Column_PeriodCode)) = Per.Code Then
    '                        AU = AU + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_ActualUnits))
    '                        NetSal = NetSal + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_NetSalary))
    '                        TE = TE + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_EVTotal))
    '                        TD = TD + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DVTotal))
    '                        TC = TC + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CVTotal))
    '                        CCost = CCost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
    '                        SICost = SICost + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_SITotal))
    '                        TotalOT1 = TotalOT1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Overtime1))
    '                        TotalOT2 = TotalOT2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime2))
    '                        TotalOT3 = TotalOT3 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverTime3))
    '                        TotalSal1 = TotalSal1 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary1))
    '                        TotalSal2 = TotalSal2 + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_Salary2))

    '                        TotalSectors = TotalSectors + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_sectors))
    '                        totaldutyhours = totaldutyhours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_dutyhours))
    '                        totalflighthours = totalflighthours + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_flighthours))
    '                        totalcommission = totalcommission + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_commission))
    '                        totalOverlay = totalOverlay + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_OverLay))
    '                        TotalTo = TotalTo + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_TimeOff))
    '                    End If

    '                Next

    '                r(Me.Column_ActualUnits) = Format(AU, "0.00")
    '                r(Me.Column_NetSalary) = Format(NetSal, "0.00")
    '                r(Me.Column_EVTotal) = Format(TE, "0.00")
    '                r(Me.Column_DVTotal) = Format(TD, "0.00")
    '                r(Me.Column_CVTotal) = Format(TC, "0.00")
    '                r(Me.Column_CompanyCost) = Format(CCost, "0.00")
    '                r(Me.Column_SITotal) = Format(SICost, "0.00")
    '                r(Me.Column_Overtime1) = Format(TotalOT1, "0.00")
    '                r(Me.Column_OverTime2) = Format(TotalOT2, "0.00")
    '                r(Me.Column_OverTime3) = Format(TotalOT3, "0.00")
    '                r(Me.Column_Salary1) = Format(TotalSal1, "0.00")
    '                r(Me.Column_Salary2) = Format(TotalSal2, "0.00")

    '                r(Me.Column_sectors) = Format(TotalSectors, "0.00")
    '                r(Me.Column_dutyhours) = Format(totaldutyhours, "0.00")
    '                r(Me.Column_flighthours) = Format(totalflighthours, "0.00")
    '                r(Me.Column_commission) = Format(totalcommission, "0.00")
    '                r(Me.Column_OverLay) = Format(totalOverlay, "0.00")
    '                r(Me.Column_AnalysisCode) = ""
    '                r(Me.Column_Position) = ""
    '                r(Me.Column_DOE) = ""
    '                r(Me.Column_TimeOff) = Format(TotalTo, "0.00")






    '                Dt1.Rows.Add(r)


    '                Dim rx As DataRow = Dt1.NewRow()
    '                Dt1.Rows.Add(rx)
    '                Application.DoEvents()
    '                Me.lblStatus.Text = "Please wait Calcultating Totals " & i
    '            End If
    '        End If
    '    End If



    '    Me.Cursor = Cursors.Default

    'End Sub

   
    
   
   
    Private Sub UnionReport5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnionReport5ToolStripMenuItem.Click
        Dim WelFareDedCode As String

        WelFareDedCode = PARAM_WelFareDedCode


        Dim Anal As Integer
        Anal = Me.ComboSelectAnal.SelectedIndex
        If Anal <> 6 Then
            MsgBox("Please select Union First", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String
        Dim UnionCode As String
        UnionCode = CType(Me.ComboAnal.SelectedItem, cPrAnUnions).Code
        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text

        Dim HeaderId As Integer
        Dim WelFareD As Double

        Dim WelFareTOTAL As Double
        Dim LINETOTAL As Double = 0
        Dim UNI As Double
        Dim UNC As Double
        Dim UND As Double
        Dim UNTotal As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForUNIONReport(PerFrom, EmpFrom, Empto, UnionCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))

                WelFareD = Global1.Business.GetDeductionCodeForHeaderForPeriod(HeaderId, WelFareDedCode, PerFrom.PrdGrpCode, PerFrom.Code)

                UNI = Global1.Business.GetDeductionForHeader(HeaderId, "US")
                UNI = UNI - WelFareD

                UND = UNI
                UNC = Global1.Business.GetContributionForHeader(HeaderId, "WF")

                'MFC = Global1.Business.GetContributionCodeForHeaderForPeriod(HeaderId, MFUnionConCode, PerFrom.PrdGrpCode, PerFrom.Code)

                WelFareTOTAL = WelFareD
                'LINETOTAL = MFD + MFC 
                UNTotal = UND + UNC + WelFareD

                DsHeader.Tables(0).Rows(i).Item(7) = WelFareTOTAL
                DsHeader.Tables(0).Rows(i).Item(8) = 0
                DsHeader.Tables(0).Rows(i).Item(9) = 0
                DsHeader.Tables(0).Rows(i).Item(10) = UNI
                DsHeader.Tables(0).Rows(i).Item(11) = LINETOTAL
                DsHeader.Tables(0).Rows(i).Item(14) = UNI
                DsHeader.Tables(0).Rows(i).Item(15) = UNC
                DsHeader.Tables(0).Rows(i).Item(16) = UNTotal


            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ' Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\restored\NodalPay - RND\NodalPay\XML\Unionreport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("UnionReport5.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub Report6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Report6ToolStripMenuItem.Click

        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        Me.PrepareReport_Differences3(PY, False)
        PrepareReport_Variance_2_5(False)


    End Sub
    Private Sub ExcelCombinationOfReport25WithHRCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelCombinationOfReport25WithHRCodeToolStripMenuItem.Click
        Dim PY As Boolean = False
        If Me.CBPreviousYear.CheckState = CheckState.Checked Then
            PY = True
        End If
        Me.PrepareReport_Differences3(PY, True)
        PrepareReport_Variance_2_5(True)
    End Sub
    Private Sub PrepareReport_Differences_6(ByVal PreviousYear As Boolean)





        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        MyDsDif.Tables(0).Rows.Clear()


        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeaderFrom As DataSet
        Dim DsHeaderTo As DataSet
        Dim DsEmp As DataSet


        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String





        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)


        Dim PrevPeriodCode As String
        Dim PrevPeriodYear As String
        Dim PrevPeriodGroup As String
        Dim PerGrp As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        PrevPeriodYear = (CInt(PerGrp.Year) - 1).ToString
        PrevPeriodCode = PrevPeriodYear & "12"
        PrevPeriodGroup = Replace(PerGrp.Code, PerGrp.Year, "")
        PrevPeriodGroup = PrevPeriodYear & PrevPeriodGroup

        If PreviousYear Then
            PerFrom = New cPrMsPeriodCodes(PrevPeriodCode, PrevPeriodGroup)
        End If


        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text



        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim EWallet As Boolean = False

        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBWallet.CheckState = CheckState.Checked Then
            EWallet = True
        End If

        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim BankCodeEmp As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCodeEmp = "ALL"
        Else
            BankCodeEmp = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim GenAnal1 As String
        GenAnal1 = Me.txtGenAnal1.Text

        Dim SICategory As String
        SICategory = Me.txtSICategory.Text


        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If
        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        DsHeaderFrom = Global1.Business.GetAllTrxnHeaderForPeriod(PerFrom, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, EWallet)
        DsHeaderTo = Global1.Business.GetAllTrxnHeaderForPeriod(PerTo, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, False, GenAnal1, 0, BankCode, BankCodeEmp, False, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, EWallet)

        Dim HDRIdFrom As Integer
        Dim HDRIdTo As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Dim EmpCode2 As String


        Dim Units_F As Double
        Dim Units_T As Double
        Dim Units_D As Double
        Dim NetSal_F As Double
        Dim NetSal_T As Double
        Dim NetSal_D As Double
        Dim TotalE_F As Double
        Dim TotalE_T As Double
        Dim TotalE_D As Double
        Dim TotalD_F As Double
        Dim TotalD_T As Double
        Dim TotalD_D As Double
        Dim TotalC_F As Double
        Dim TotalC_T As Double
        Dim TotalC_D As Double
        Dim TotalCCost_F As Double
        Dim TotalCCost_T As Double
        Dim TotalCCost_D As Double
        Dim Bonus_F As Double
        Dim Bonus_T As Double

        Dim RecBonus_F As Double
        Dim RecBonus_T As Double

        Dim Bonus_D As Double

        Dim BonS_F As Double
        Dim BonS_T As Double
        Dim BonS_D As Double

        Dim MS_F As Double
        Dim MS_T As Double
        Dim MS_D As Double

        Dim BIK_F As Double
        Dim BIK_T As Double
        Dim BIK_D As Double

        Dim Fine_F As Double
        Dim Fine_T As Double
        Dim Fine_D As Double


        Dim TUnits_F As Double
        Dim TUnits_T As Double
        Dim TUnits_D As Double
        Dim TNetSal_F As Double
        Dim TNetSal_T As Double
        Dim TNetSal_D As Double
        Dim TTotalE_F As Double
        Dim TTotalE_T As Double
        Dim TTotalE_D As Double
        Dim TTotalD_F As Double
        Dim TTotalD_T As Double
        Dim TTotalD_D As Double
        Dim TTotalC_F As Double
        Dim TTotalC_T As Double
        Dim TTotalC_D As Double
        Dim TTotalCCost_F As Double
        Dim TTotalCCost_T As Double
        Dim TTotalCCost_D As Double
        Dim TBonus_F As Double
        Dim TBonus_T As Double
        Dim TBonus_D As Double

        Dim TBonS_F As Double
        Dim TBonS_T As Double
        Dim TBonS_D As Double

        Dim TMS_F As Double
        Dim TMS_T As Double
        Dim TMS_D As Double

        Dim TBIK_F As Double
        Dim TBIK_T As Double
        Dim TBIK_D As Double


        Dim TFine_F As Double
        Dim TFine_T As Double
        Dim TFine_D As Double


        Dim BonusErnCode1 As String = "E11"
        Dim BonusErnCode2 As String = "E37"
        Dim BonusErnCode3 As String = "E38"

        Dim RecBonusErnCode As String = "E30"

        Dim FineErnCode As String

        Dim BIKErnType As String = "BK"
        Dim RecBIKernType As String = "BR"

        Dim FineType As String = "FN"

        Dim Anal2Code As String
        Dim PosCode As String





        If CheckDataSet(DsHeaderFrom) And CheckDataSet(DsHeaderTo) Then
            Dim totalFrom As Integer = DsHeaderFrom.Tables(0).Rows.Count - 1
            Dim totalTo As Integer = DsHeaderTo.Tables(0).Rows.Count - 1

            For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                Units_F = 0
                Units_T = 0
                Units_D = 0
                NetSal_F = 0
                NetSal_T = 0
                NetSal_D = 0
                TotalE_F = 0
                TotalE_T = 0
                TotalE_D = 0
                TotalD_F = 0
                TotalD_T = 0
                TotalD_D = 0
                TotalC_F = 0
                TotalC_T = 0
                TotalC_D = 0
                TotalCCost_F = 0
                TotalCCost_T = 0
                TotalCCost_D = 0
                Bonus_F = 0
                Bonus_T = 0
                Bonus_D = 0
                RecBonus_T = 0
                RecBonus_F = 0

                BonS_F = 0
                BonS_T = 0
                BonS_D = 0

                MS_F = 0
                MS_T = 0
                MS_D = 0

                BIK_F = 0
                BIK_T = 0
                BIK_D = 0

                Fine_F = 0
                Fine_T = 0
                Fine_D = 0

                EmpCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(2))
                HDRIdTo = DbNullToInt(DsHeaderTo.Tables(0).Rows(i).Item(0))
                Units_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(5))
                NetSal_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(3))
                TotalE_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(23))
                TotalD_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(24))
                TotalC_T = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(25))

                BonS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(26))
                MS_T = DbNullToDouble(DsHeaderTo.Tables(0).Rows(i).Item(4))

                TotalCCost_T = RoundMe3(TotalE_T + TotalC_T, 2)
                'Bonus_T = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdTo)
                Bonus_T = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdTo)
                Bonus_T = Bonus_T + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdTo)

                Fine_T = Fine_T + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdTo)


                RecBonus_T = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdTo)
                Bonus_T = Bonus_T + RecBonus_T



                BIK_T = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdTo)
                BIK_T = BIK_T + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdTo)


                Anal2Code = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(18))
                PosCode = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(22))


                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode2 = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    If EmpCode2 = EmpCode Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))

                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))

                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))


                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)
                        'Bonus_F = Global1.Business.GetTrxLineEarningOfTYPE("BO", HDRIdFrom)
                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)

                        Exit For
                    End If
                Next

                Units_D = RoundMe3(Units_T - Units_F, 2)
                NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                MS_D = RoundMe3(MS_T - MS_F, 2)
                BIK_D = RoundMe3(BIK_T - BIK_F, 2)

                Fine_D = RoundMe3(Fine_T - Fine_F, 2)


                Dim r As DataRow = DtDif.NewRow()
                r(0) = PerFrom.Code
                r(1) = PerFrom.DescriptionL
                r(2) = PerTo.Code
                r(3) = PerTo.DescriptionL

                r(4) = EmpCode
                r(5) = EmpName

                r(6) = Units_F
                r(7) = Units_T
                r(8) = Units_D

                r(9) = NetSal_F
                r(10) = NetSal_T
                r(11) = NetSal_D

                r(12) = TotalE_F
                r(13) = TotalE_T
                r(14) = TotalE_D

                r(15) = TotalD_F
                r(16) = TotalD_T
                r(17) = TotalD_D

                r(18) = TotalC_F
                r(19) = TotalC_T
                r(20) = TotalC_D

                r(21) = TotalCCost_F
                r(22) = TotalCCost_T
                r(23) = TotalCCost_D

                r(24) = Bonus_F
                r(25) = Bonus_T
                r(26) = Bonus_D

                r(29) = BonS_F
                r(30) = BonS_T
                r(31) = BonS_D

                r(32) = MS_F
                r(33) = MS_T
                r(34) = MS_D

                r(35) = BIK_F
                r(36) = BIK_T
                r(37) = BIK_D

                r(38) = BIK_F + TotalCCost_F
                r(39) = BIK_T + TotalCCost_T
                r(40) = BIK_D + TotalCCost_D


                r(41) = Fine_F
                r(42) = Fine_T
                r(43) = Fine_D





                Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                Dim Pos As New cPrAnEmployeePositions(PosCode)
                r(27) = Anl2.DescriptionS
                r(28) = Pos.DescriptionL

                DtDif.Rows.Add(r)


                TUnits_F = TUnits_F + Units_F
                TUnits_T = TUnits_T + Units_T
                TUnits_D = TUnits_D + Units_D
                TNetSal_F = TNetSal_F + NetSal_F
                TNetSal_T = TNetSal_T + NetSal_T
                TNetSal_D = TNetSal_D + NetSal_D
                TTotalE_F = TTotalE_F + TotalE_F
                TTotalE_T = TTotalE_T + TotalE_T
                TTotalE_D = TTotalE_D + TotalE_D
                TTotalD_F = TTotalD_F + TotalD_F
                TTotalD_T = TTotalD_T + TotalD_T
                TTotalD_D = TTotalD_D + TotalD_D
                TTotalC_F = TTotalC_F + TotalC_F
                TTotalC_T = TTotalC_T + TotalC_T
                TTotalC_D = TTotalC_D + TotalC_D

                TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                TBonus_F = TBonus_F + Bonus_F
                TBonus_T = TBonus_T + Bonus_T
                TBonus_D = TBonus_D + Bonus_D


                TBonS_F = TBonS_F + BonS_F
                TBonS_T = TBonS_T + BonS_T
                TBonS_D = TBonS_D + BonS_D

                TMS_F = TMS_F + MS_F
                TMS_T = TMS_T + MS_T
                TMS_D = TMS_D + MS_D

                TBIK_F = TBIK_F + BIK_F
                TBIK_T = TBIK_T + BIK_T
                TBIK_D = TBIK_D + BIK_D

                TFine_F = TFine_F + Fine_F
                TFine_T = TFine_T + Fine_T
                TFine_D = TFine_D + Fine_D

            Next
            '-----------------------------------------------------------------------------
            ''''''''''                Second RUN               '''''''''''''''''''''''''''

            If CheckDataSet(DsHeaderFrom) Then
                For k = 0 To DsHeaderFrom.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(1))
                    Dim found As Boolean = False
                    For i = 0 To DsHeaderTo.Tables(0).Rows.Count - 1
                        EmpCode2 = DbNullToString(DsHeaderTo.Tables(0).Rows(i).Item(1))
                        If EmpCode2 = EmpCode Then
                            found = True
                            Exit For
                        End If
                    Next
                    If found = False Then
                        HDRIdFrom = DbNullToInt(DsHeaderFrom.Tables(0).Rows(k).Item(0))
                        Units_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(5))
                        NetSal_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(3))
                        TotalE_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(23))
                        TotalD_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(24))
                        TotalC_F = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(25))
                        BonS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(26))
                        MS_F = DbNullToDouble(DsHeaderFrom.Tables(0).Rows(k).Item(4))
                        TotalCCost_F = RoundMe3(TotalE_F + TotalC_F, 2)

                        Bonus_F = Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode1, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode2, HDRIdFrom)
                        Bonus_F = Bonus_F + Global1.Business.GetTrxLineEarningOfCODE(BonusErnCode3, HDRIdFrom)

                        Fine_F = Fine_F + Global1.Business.GetTrxLineEarningOfTYPE(FineType, HDRIdFrom)

                        RecBonus_F = Global1.Business.GetTrxLineEarningOfCODE(RecBonusErnCode, HDRIdFrom)
                        Bonus_F = Bonus_F + RecBonus_F

                        BIK_F = Global1.Business.GetTrxLineEarningOfTYPE(BIKErnType, HDRIdFrom)
                        BIK_F = BIK_F + Global1.Business.GetTrxLineEarningOfTYPE(RecBIKernType, HDRIdFrom)


                        EmpName = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(2))

                        Anal2Code = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(18))
                        PosCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(22))
                        PosCode = DbNullToString(DsHeaderFrom.Tables(0).Rows(k).Item(58))

                        Units_T = 0
                        NetSal_T = 0
                        TotalE_T = 0
                        TotalD_T = 0
                        TotalC_T = 0
                        TotalCCost_T = 0
                        Bonus_T = 0
                        BonS_T = 0
                        MS_T = 0
                        BIK_T = 0

                        Fine_T = 0


                        Units_D = RoundMe3(Units_T - Units_F, 2)
                        NetSal_D = RoundMe3(NetSal_T - NetSal_F, 2)
                        TotalE_D = RoundMe3(TotalE_T - TotalE_F, 2)
                        TotalD_D = RoundMe3(TotalD_T - TotalD_F, 2)
                        TotalC_D = RoundMe3(TotalC_T - TotalC_F, 2)
                        TotalCCost_D = RoundMe3(TotalCCost_T - TotalCCost_F, 2)
                        Bonus_D = RoundMe3(Bonus_T - Bonus_F, 2)

                        BonS_D = RoundMe3(BonS_T - BonS_F, 2)
                        MS_D = RoundMe3(MS_T - MS_F, 2)
                        BIK_D = RoundMe3(BIK_T - BIK_F, 2)
                        Fine_D = RoundMe3(Fine_T - Fine_F, 2)


                        Dim r As DataRow = DtDif.NewRow()
                        r(0) = PerFrom.Code
                        r(1) = PerFrom.DescriptionL
                        r(2) = PerTo.Code
                        r(3) = PerTo.DescriptionL

                        r(4) = EmpCode
                      
                        r(5) = EmpName

                        r(6) = Units_F
                        r(7) = Units_T
                        r(8) = Units_D

                        r(9) = NetSal_F
                        r(10) = NetSal_T
                        r(11) = NetSal_D

                        r(12) = TotalE_F
                        r(13) = TotalE_T
                        r(14) = TotalE_D

                        r(15) = TotalD_F
                        r(16) = TotalD_T
                        r(17) = TotalD_D

                        r(18) = TotalC_F
                        r(19) = TotalC_T
                        r(20) = TotalC_D

                        r(21) = TotalCCost_F
                        r(22) = TotalCCost_T
                        r(23) = TotalCCost_D

                        r(24) = Bonus_F
                        r(25) = Bonus_T
                        r(26) = Bonus_D

                        r(29) = BonS_F
                        r(30) = BonS_T
                        r(31) = BonS_D

                        r(32) = MS_F
                        r(33) = MS_T
                        r(34) = MS_D

                        r(35) = BIK_F
                        r(36) = BIK_T
                        r(37) = BIK_D

                        r(38) = BIK_F + TotalCCost_F
                        r(39) = BIK_T + TotalCCost_T
                        r(40) = BIK_D + TotalCCost_D


                        r(41) = Fine_F
                        r(42) = Fine_T
                        r(43) = Fine_D



                        Dim Anl2 As New cPrAnEmployeeAnalysis2(Anal2Code)
                        Dim Pos As New cPrAnEmployeePositions(PosCode)
                        r(27) = Anl2.DescriptionS
                        r(28) = Pos.DescriptionL

                        DtDif.Rows.Add(r)


                        TUnits_F = TUnits_F + Units_F
                        TUnits_T = TUnits_T + Units_T
                        TUnits_D = TUnits_D + Units_D
                        TNetSal_F = TNetSal_F + NetSal_F
                        TNetSal_T = TNetSal_T + NetSal_T
                        TNetSal_D = TNetSal_D + NetSal_D
                        TTotalE_F = TTotalE_F + TotalE_F
                        TTotalE_T = TTotalE_T + TotalE_T
                        TTotalE_D = TTotalE_D + TotalE_D
                        TTotalD_F = TTotalD_F + TotalD_F
                        TTotalD_T = TTotalD_T + TotalD_T
                        TTotalD_D = TTotalD_D + TotalD_D
                        TTotalC_F = TTotalC_F + TotalC_F
                        TTotalC_T = TTotalC_T + TotalC_T
                        TTotalC_D = TTotalC_D + TotalC_D

                        TTotalCCost_F = TTotalCCost_F + TotalCCost_F
                        TTotalCCost_T = TTotalCCost_T + TotalCCost_T
                        TTotalCCost_D = TTotalCCost_D + TotalCCost_D

                        TBonus_F = TBonus_F + Bonus_F
                        TBonus_T = TBonus_T + Bonus_T
                        TBonus_D = TBonus_D + Bonus_D


                        TBonS_F = TBonS_F + BonS_F
                        TBonS_T = TBonS_T + BonS_T
                        TBonS_D = TBonS_D + BonS_D

                        TMS_F = TMS_F + MS_F
                        TMS_T = TMS_T + MS_T
                        TMS_D = TMS_D + MS_D

                        TBIK_F = TBIK_F + BIK_F
                        TBIK_T = TBIK_T + BIK_T
                        TBIK_D = TBIK_D + BIK_D


                        TFine_F = TFine_F + Fine_F
                        TFine_T = TFine_T + Fine_T
                        TFine_D = TFine_D + Fine_D

                    End If

                Next
            End If








            Dim rt As DataRow = DtDif.NewRow()
            rt(0) = PerFrom.Code
            rt(1) = PerFrom.DescriptionL
            rt(2) = PerTo.Code
            rt(3) = PerTo.DescriptionL

            rt(4) = ""
            rt(5) = "TOTALS"

            rt(6) = TUnits_F
            rt(7) = TUnits_T
            rt(8) = TUnits_D

            rt(9) = TNetSal_F
            rt(10) = TNetSal_T
            rt(11) = TNetSal_D

            rt(12) = TTotalE_F
            rt(13) = TTotalE_T
            rt(14) = TTotalE_D

            rt(15) = TTotalD_F
            rt(16) = TTotalD_T
            rt(17) = TTotalD_D

            rt(18) = TTotalC_F
            rt(19) = TTotalC_T
            rt(20) = TTotalC_D

            rt(21) = TTotalCCost_F
            rt(22) = TTotalCCost_T
            rt(23) = TTotalCCost_D

            rt(24) = TBonus_F
            rt(25) = TBonus_T
            rt(26) = TBonus_D

            rt(27) = ""
            rt(28) = ""

            rt(29) = TBonS_F
            rt(30) = TBonS_T
            rt(31) = TBonS_D

            rt(32) = TMS_F
            rt(33) = TMS_T
            rt(34) = TMS_D

            rt(35) = TBIK_F
            rt(36) = TBIK_T
            rt(37) = TBIK_D

            rt(38) = TBIK_F + TTotalCCost_F
            rt(39) = TBIK_T + TTotalCCost_T
            rt(40) = TBIK_D + TTotalCCost_D


            rt(41) = TFine_F
            rt(42) = TFine_T
            rt(43) = TFine_D

            DtDif.Rows.Add(rt)


        End If
        'End If




        Me.Cursor = Cursors.Default

        Dim F As New FrmDifReport
        F.FromPeriod = PerFrom.DescriptionL
        F.ToPeriod = PerTo.DescriptionL

        F.Ds = MyDsDif
        F.Show()

    End Sub
    Private Sub PrepareReport_Variance_2_5(ByVal IncludeHRCode As Boolean)

        Dim Ds As DataSet
        Dim ExportFileDir As String
        Ds = Global1.Business.GetParameter("Reports", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            ExportFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Please define parameter 'Reports','ExportFileDir'", MsgBoxStyle.Information)
            Exit Sub
        End If

        If CheckDataSet(MyDsDif) Then
            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            Dim S As String
            Dim PipeLine As String = "|"
            Dim IncludeHeaders As Boolean = True
            Dim Rowcount As Integer = 1
            Dim i As Integer
            Dim FromPeriod As String
            Dim ToPeriod As String
            Dim Diff As String
            For i = 0 To MyDsDif.Tables(0).Rows.Count - 1

                Dim R As DataRow = MyDsDif.Tables(0).Rows(i)

                If IncludeHeaders Then

                    IncludeHeaders = False

                    FromPeriod = R.Item(1)
                    ToPeriod = R.Item(3)
                    Diff = "Difference"
                    'Name
                    xlsWorkSheet.Cells(Rowcount, 1) = ""
                    xlsWorkSheet.Cells(Rowcount, 2) = ""
                    'Position
                    xlsWorkSheet.Cells(Rowcount, 3) = ""
                    xlsWorkSheet.Cells(Rowcount, 4) = ""

                    'Cost    
                    xlsWorkSheet.Cells(Rowcount, 5) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 6) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 7) = ""
                    'Gross
                    xlsWorkSheet.Cells(Rowcount, 8) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 9) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 10) = ""
                    'Net
                    xlsWorkSheet.Cells(Rowcount, 11) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 12) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 13) = ""
                    'Bonus
                    xlsWorkSheet.Cells(Rowcount, 14) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 15) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 16) = ""
                    'Basic Salary
                    xlsWorkSheet.Cells(Rowcount, 17) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 18) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 19) = ""
                    'BIK
                    xlsWorkSheet.Cells(Rowcount, 20) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 21) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 22) = ""
                    'Fines
                    xlsWorkSheet.Cells(Rowcount, 23) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 24) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 25) = ""
                    'Cost + BIK
                    xlsWorkSheet.Cells(Rowcount, 26) = FromPeriod
                    xlsWorkSheet.Cells(Rowcount, 27) = ToPeriod
                    xlsWorkSheet.Cells(Rowcount, 28) = ""
                    If includehrcode Then
                        xlsWorkSheet.Cells(Rowcount, 29) = ""
                    End If


                    Rowcount = Rowcount + 1

                    'Name
                    xlsWorkSheet.Cells(Rowcount, 1) = "Code"
                    xlsWorkSheet.Cells(Rowcount, 2) = "Name"
                    'Position
                    If Not Global1.PARAM_Variance25ShowAnl3 Then
                        xlsWorkSheet.Cells(Rowcount, 3) = "Department"
                    Else
                        xlsWorkSheet.Cells(Rowcount, 3) = "Project Code"
                    End If
                    xlsWorkSheet.Cells(Rowcount, 4) = "Position"

                    'Cost    
                    xlsWorkSheet.Cells(Rowcount, 5) = "Cost"
                    xlsWorkSheet.Cells(Rowcount, 6) = "Cost"
                    xlsWorkSheet.Cells(Rowcount, 7) = Diff
                    'Gross
                    xlsWorkSheet.Cells(Rowcount, 8) = "Gross"
                    xlsWorkSheet.Cells(Rowcount, 9) = "Gross"
                    xlsWorkSheet.Cells(Rowcount, 10) = Diff
                    'Net
                    xlsWorkSheet.Cells(Rowcount, 11) = "Net"
                    xlsWorkSheet.Cells(Rowcount, 12) = "Net"
                    xlsWorkSheet.Cells(Rowcount, 13) = Diff
                    'Bonus
                    xlsWorkSheet.Cells(Rowcount, 14) = "Bonus"
                    xlsWorkSheet.Cells(Rowcount, 15) = "Bonus"
                    xlsWorkSheet.Cells(Rowcount, 16) = Diff
                    'Basic Salary
                    xlsWorkSheet.Cells(Rowcount, 17) = "Base Sal."
                    xlsWorkSheet.Cells(Rowcount, 18) = "Base Sal."
                    xlsWorkSheet.Cells(Rowcount, 19) = Diff
                    'BIK
                    xlsWorkSheet.Cells(Rowcount, 20) = "B.I.K."
                    xlsWorkSheet.Cells(Rowcount, 21) = "B.I.K."
                    xlsWorkSheet.Cells(Rowcount, 22) = Diff
                    'Fines
                    xlsWorkSheet.Cells(Rowcount, 23) = "Fines"
                    xlsWorkSheet.Cells(Rowcount, 24) = "Fines"
                    xlsWorkSheet.Cells(Rowcount, 25) = Diff
                    'Cost + BIK
                    xlsWorkSheet.Cells(Rowcount, 26) = "Cost + B.I.K."
                    xlsWorkSheet.Cells(Rowcount, 27) = "Cost + B.I.K."
                    xlsWorkSheet.Cells(Rowcount, 28) = Diff
                    If IncludeHRCode Then
                        xlsWorkSheet.Cells(Rowcount, 29) = "HR Code"
                    End If

                    Rowcount = Rowcount + 1

                End If


                    'Employee
                xlsWorkSheet.Cells(Rowcount, 1) = R.Item(4)
                xlsWorkSheet.Cells(Rowcount, 2) = R.Item(5)
                xlsWorkSheet.Cells(Rowcount, 3) = R.Item(27)
                xlsWorkSheet.Cells(Rowcount, 4) = R.Item(28)

                'Cost    
                xlsWorkSheet.Cells(Rowcount, 5) = R.Item(21)
                xlsWorkSheet.Cells(Rowcount, 6) = R.Item(22)
                xlsWorkSheet.Cells(Rowcount, 7) = R.Item(23)
                'Gross
                xlsWorkSheet.Cells(Rowcount, 8) = R.Item(12)
                xlsWorkSheet.Cells(Rowcount, 9) = R.Item(13)
                xlsWorkSheet.Cells(Rowcount, 10) = R.Item(14)
                'Net
                xlsWorkSheet.Cells(Rowcount, 11) = R.Item(9)
                xlsWorkSheet.Cells(Rowcount, 12) = R.Item(10)
                xlsWorkSheet.Cells(Rowcount, 13) = R.Item(11)
                'Bonus
                xlsWorkSheet.Cells(Rowcount, 14) = R.Item(24)
                xlsWorkSheet.Cells(Rowcount, 15) = R.Item(25)
                xlsWorkSheet.Cells(Rowcount, 16) = R.Item(26)
                'Basic Salary
                xlsWorkSheet.Cells(Rowcount, 17) = R.Item(32)
                xlsWorkSheet.Cells(Rowcount, 18) = R.Item(33)
                xlsWorkSheet.Cells(Rowcount, 19) = R.Item(34)
                'BIK
                xlsWorkSheet.Cells(Rowcount, 20) = R.Item(35)
                xlsWorkSheet.Cells(Rowcount, 21) = R.Item(36)
                xlsWorkSheet.Cells(Rowcount, 22) = R.Item(37)
                'Fines
                xlsWorkSheet.Cells(Rowcount, 23) = R.Item(41)
                xlsWorkSheet.Cells(Rowcount, 24) = R.Item(42)
                xlsWorkSheet.Cells(Rowcount, 25) = R.Item(43)
                'Cost + BIK
                xlsWorkSheet.Cells(Rowcount, 26) = R.Item(38)
                xlsWorkSheet.Cells(Rowcount, 27) = R.Item(39)
                xlsWorkSheet.Cells(Rowcount, 28) = R.Item(40)
                If IncludeHRCode Then
                    xlsWorkSheet.Cells(Rowcount, 29) = R.Item(44)
                End If



                Rowcount = Rowcount + 1




            Next

            Dim S1 As String
            Dim S2 As String
            Dim PG As String
            PG = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).DescriptionL
            S1 = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes).Code
            S2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes).Code

            Dim Fname As String
            Fname = "Diff" & "_" & PG & "_" & S1 & "_" & S2 & ".xlsx"
            Fname = ExportFileDir & Fname


            xlsWorkBook.SaveAs(Fname)


            xlsWorkBook.Close()
            xls.Quit()
            MsgBox("File exported at " & Fname, MsgBoxStyle.Information)
        Else
            MsgBox("No Matching Criteria", MsgBoxStyle.Information)
        End If

    End Sub


  
    Private Sub PrepareReportForSelectedAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareReportForSelectedAnalysisToolStripMenuItem.Click
        Dim AnalysisType As String = ""
        Dim AnalysisCode As String = ""

        AnalysisType = Me.ComboSelectAnal.SelectedIndex

        ComboAnal.SelectedIndex = 0
        Select Case AnalysisType
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
        If AnalysisCode = "0" Then
            MsgBox("Please select Valid Analysis First ", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim Ds As DataSet
        Dim ExportFileDir As String = ""
        Ds = Global1.Business.GetParameter("Reports", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            ExportFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Please define parameter 'Report','ExportFileDir'", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim FoundOne As Boolean = False
        Dim i As Integer
        For i = 0 To ComboAnal.Items.Count - 1
            ComboAnal.SelectedIndex = i
            Application.DoEvents()
            PrepareTHEReport()
            Select Case AnalysisType
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
            If CheckDataSet(MyDs) Then
                foundone = True
                WriteToExcel(AnalysisCode, ExportFileDir, False, "")
            End If
        Next
        If foundone Then
            MsgBox("Reports are exported in Excel", MsgBoxStyle.Information)
        Else
            MsgBox("No Matching criteria", MsgBoxStyle.Information)
        End If
    End Sub
    
    
    Private Sub WriteToExcel(ByVal Analysis As String, ByVal ExportFileDir As String, ByVal UseFileName As Boolean, ByVal FileName2 As String)



        InitExcelFile = True
        Dim i As Integer

        If CheckDataSet(MyDs) Then

            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            Dim S As String
            Dim PipeLine As String = "|"
            Dim IncludeHeaders As Boolean = True
            Dim Rowcount As Integer = 1
            For i = 0 To MyDs.Tables(0).Rows.Count - 1

                Dim Ce As Integer = 0
                Dim Cd As Integer = 0
                Dim Cc As Integer = 0


                Dim C1 As Integer
                Dim C2 As Integer
                Dim k As Integer



                Dim R As DataRow = MyDs.Tables(0).Rows(i)
                If IncludeHeaders Then
                    IncludeHeaders = False
                    S = S & DG1.Columns(Me.Column_PeriodCode).HeaderText & PipeLine

                    S = S & DG1.Columns(Me.Column_EmpCode).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_EmpName).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_NetSalary).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_ActualUnits).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_Overtime1).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_OverTime2).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_OverTime3).HeaderText & PipeLine
                    ' S = S & DG1.Columns(Me.Column_Salary1).HeaderText & PipeLine
                    ' S = S & DG1.Columns(Me.Column_Salary2).HeaderText & PipeLine

                    ' S = S & DG1.Columns(Me.Column_sectors).HeaderText & PipeLine
                    ' S = S & DG1.Columns(Me.Column_dutyhours).HeaderText & PipeLine
                    ' S = S & DG1.Columns(Me.Column_flighthours).HeaderText & PipeLine
                    ' S = S & DG1.Columns(Me.Column_commission).HeaderText & PipeLine
                    ' S = S & DG1.Columns(Me.Column_OverLay).HeaderText & PipeLine



                    '------------------------------------------------------------------
                    'Earnings
                    '------------------------------------------------------------------

                    C1 = 0
                    C2 = 0
                    For k = 0 To 14

                        If DbNullToString(DG1.Columns(Me.Column_EV1 + C1).HeaderText) <> "" Then
                            S = S & DG1.Columns(Me.Column_EV1 + C1).HeaderText & PipeLine
                        End If
                        C1 = C1 + 2
                    Next

                    S = S & DG1.Columns(Me.Column_EVTotal).HeaderText & PipeLine
                    S = S & " " & PipeLine

                    '------------------------------------------------------------------
                    'Deductions
                    '------------------------------------------------------------------
                    C1 = 0
                    C2 = 0
                    For k = 0 To 14
                        If DbNullToString(DG1.Columns(Me.Column_DV1 + C1).HeaderText) <> "" Then
                            S = S & DG1.Columns(Me.Column_DV1 + C1).HeaderText & PipeLine
                        End If
                        C1 = C1 + 2

                    Next

                    S = S & DG1.Columns(Column_DVTotal).HeaderText & PipeLine
                    S = S & " " & PipeLine
                    '------------------------------------------------------------------
                    'Contributions
                    '------------------------------------------------------------------
                    C1 = 0
                    C2 = 0
                    For k = 0 To 14
                        If DbNullToString(DG1.Columns(Me.Column_CV1 + C1).HeaderText) <> "" Then
                            S = S & DG1.Columns(Me.Column_CV1 + C1).HeaderText & PipeLine
                        End If
                        C1 = C1 + 2

                    Next

                    S = S & DG1.Columns(Column_CVTotal).HeaderText & PipeLine
                    S = S & " " & PipeLine

                    S = S & DG1.Columns(Column_CompanyCost).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_SITotal).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_ChequeNo).HeaderText & PipeLine


                    S = S & DG1.Columns(Column_Position).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_DOE).HeaderText & PipeLine
                    S = S & DG1.Columns(Me.Column_GenAnal1).HeaderText & PipeLine

                    S = S & DG1.Columns(Column_AL_Code1).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code2).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code3).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code4).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code5).HeaderText & PipeLine

                    S = S & DG1.Columns(Column_AL_Desc1).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code2).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code3).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code4).HeaderText & PipeLine
                    S = S & DG1.Columns(Column_AL_Code5).HeaderText & PipeLine

                    Dim Ar1() As String
                    Ar1 = S.Split("|")
                    Dim t1 As Integer
                    For t1 = 0 To Ar1.Length - 1
                        xlsWorkSheet.Cells(Rowcount, t1 + 1) = Ar1(t1)
                    Next
                    Rowcount = Rowcount + 1

                End If

                S = ""
                If Rowcount = MyDs.Tables(0).Rows.Count Then
                    S = "Totals"
                End If

                S = S & R.Item(Me.Column_PeriodCode) & PipeLine
                S = S & R.Item(Me.Column_EmpCode) & PipeLine
                S = S & R.Item(Me.Column_EmpName) & PipeLine
                S = S & R.Item(Me.Column_NetSalary) & PipeLine
                S = S & R.Item(Me.Column_ActualUnits) & PipeLine
                S = S & R.Item(Me.Column_Overtime1) & PipeLine
                S = S & R.Item(Me.Column_OverTime2) & PipeLine
                S = S & R.Item(Me.Column_OverTime3) & PipeLine
                'S = S & R.Item(Me.Column_Salary1) & PipeLine
                'S = S & R.Item(Me.Column_Salary2) & PipeLine

                ' S = S & R.Item(Me.Column_sectors) & PipeLine
                ' S = S & R.Item(Me.Column_dutyhours) & PipeLine
                ' S = S & R.Item(Me.Column_flighthours) & PipeLine
                ' S = S & R.Item(Me.Column_commission) & PipeLine
                ' S = S & R.Item(Me.Column_OverLay) & PipeLine





                '------------------------------------------------------------------
                'Earnings
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14

                    If DbNullToString(DG1.Columns(Me.Column_EV1 + C1).HeaderText) <> "" Then
                        S = S & Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00") & PipeLine
                    End If
                    C1 = C1 + 2

                Next

                S = S & Format(DbNullToDouble(R.Item(Me.Column_EVTotal)), "0.00") & PipeLine
                S = S & " " & PipeLine

                '------------------------------------------------------------------
                'Deductions
                '-----------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    If DbNullToString(DG1.Columns(Me.Column_DV1 + C1).HeaderText) <> "" Then
                        S = S & Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00") & PipeLine
                    End If
                    C1 = C1 + 2

                Next

                S = S & Format(DbNullToDouble(R.Item(Column_DVTotal)), "0.00") & PipeLine
                S = S & " " & PipeLine
                '------------------------------------------------------------------
                'Contributions
                '------------------------------------------------------------------
                C1 = 0
                C2 = 0
                For k = 0 To 14
                    If DbNullToString(DG1.Columns(Me.Column_CV1 + C1).HeaderText) <> "" Then
                        S = S & Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00") & PipeLine
                    End If
                    C1 = C1 + 2

                Next

                S = S & Format(DbNullToDouble(R.Item(Column_CVTotal)), "0.00") & PipeLine
                S = S & " " & PipeLine

                S = S & Format(DbNullToDouble(R.Item(Column_CompanyCost)), "0.00") & PipeLine
                S = S & Format(DbNullToDouble(R.Item(Column_SITotal)), "0.00") & PipeLine
                S = S & R.Item(Column_ChequeNo) & PipeLine

                S = S & R.Item(Column_Position) & PipeLine
                S = S & R.Item(Column_DOE) & PipeLine
                S = S & R.Item(Me.Column_GenAnal1) & PipeLine


                S = S & R.Item(Column_AL_Code1) & PipeLine
                S = S & R.Item(Column_AL_Code2) & PipeLine
                S = S & R.Item(Column_AL_Code3) & PipeLine
                S = S & R.Item(Column_AL_Code4) & PipeLine
                S = S & R.Item(Column_AL_Code5) & PipeLine

                S = S & R.Item(Column_AL_Desc1) & PipeLine
                S = S & R.Item(Column_AL_Desc2) & PipeLine
                S = S & R.Item(Column_AL_Desc3) & PipeLine
                S = S & R.Item(Column_AL_Desc4) & PipeLine
                S = S & R.Item(Column_AL_Desc5) & PipeLine



                Dim Ar2() As String
                Ar2 = S.Split("|")
                Dim t2 As Integer = 0
                For t2 = 0 To Ar2.Length - 1
                    xlsWorkSheet.Cells(Rowcount, t2 + 1) = Ar2(t2)
                Next
                Rowcount = Rowcount + 1

            Next
            If Not UseFileName Then
                Dim FileName As String
                Dim S1 As String
                Dim S2 As String
                Dim PG As String
                PG = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).DescriptionL
                S1 = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes).Code
                S2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes).Code

                FileName = PG & "_" & S1 & "_" & Analysis & ".xlsx"

                xlsWorkBook.SaveAs(ExportFileDir & FileName)


                xlsWorkBook.Close()
                xls.Quit()
            Else

                xlsWorkBook.SaveAs(FileName2)
                xls.Visible = True
                'xlsWorkBook.Close()
                'xls.Quit()
            End If
        End If





    End Sub
    Private Function WriteTo_EXCEL_File(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = "C:\" & fName
            Dim TW As System.IO.TextWriter

            If InitExcelFile Then
                TW = System.IO.File.CreateText(FileName)
                InitExcelFile = False
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
   
    Private Sub EmployeeIBANSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeIBANSToolStripMenuItem.Click
      
        Me.Cursor = Cursors.WaitCursor



        Dim PerFrom As New cPrMsPeriodCodes


        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim PerGroup As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        Dim TempGroup As String = PerGroup.TemGrpCode

        Dim Ds As DataSet
        Dim OnlyActive As Boolean = False
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("Only Employees with Status Active ?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            OnlyActive = True
        End If

        Ds = Global1.Business.GetEmployeeIBANS(TempGroup, OnlyActive)

        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        HeaderStr.Add("Code")
        HeaderStr.Add("Name")
        HeaderStr.Add("Status")
        HeaderStr.Add("Employee Bank")
        HeaderStr.Add("Employee Bank Code")
        HeaderStr.Add("Employee IBAN")
        HeaderStr.Add("Company Bank")
        HeaderStr.Add("Company Bank Code/IBAN")
        
        HeaderSize.Add(16)
        HeaderSize.Add(10)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(30)

        Me.Cursor = Cursors.Default
        Application.DoEvents()

        Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)


    End Sub

  
    
    Private Sub ExcelFormat1()
        Excel2Reportname = ""
        Dim F As New FrmReportName
        Dim Proceed As Boolean = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.YTDReport Then
            If CheckDataSet(MyDs2) Then
                Proceed = True
            End If
        Else
            If CheckDataSet(MyDs) Then
                Proceed = True
            End If
        End If
        If Me.UseMyDsX Then
            If CheckDataSet(MyDsX) Then
                Proceed = True
            End If
        End If

        If Proceed Then
            F.Owner = Me
            F.ShowDialog()



            If Excel2Reportname <> "" Then
                'SaveFile.FileName = ""
                'SaveFile.ShowDialog()
                'Me.txtToFile.Text = SaveFile.FileName
                Dim Filename As String
                Dim Ds As DataSet
                Ds = Global1.Business.GetParameter("Reports", "ExportFileDir")
                If CheckDataSet(Ds) Then
                    Dim P As New cPrSsParameters
                    P = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    Dim PValue As String
                    PValue = Replace(P.Value1, "$", Global1.GLBUserCode)
                    Filename = PValue & Excel2Reportname & ".xlsx"
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()
                    WriteToExcel_2("", "", True, Filename)
                Else
                    MsgBox("Please define parameter 'Reports','ExportFileDir'", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Please select Valid Report Name", MsgBoxStyle.Information)
            End If

        End If
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub
    Private Sub WriteToExcel_2(ByVal Analysis As String, ByVal ExportFileDir As String, ByVal UseFileName As Boolean, ByVal FileName2 As String)

        Dim ReportDS As DataSet
        If Me.YTDReport Then
            ReportDS = MyDs2.Copy
        Else
            ReportDS = MyDs.Copy
        End If
        If Me.UseMyDsX Then
            ReportDS = MyDsX.Copy
        End If

        InitExcelFile = True
        Dim i As Integer

        If CheckDataSet(ReportDS) Then

            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            Dim S As String
            Dim S_BIK As String
            Dim S_ReimbOfExp As String
            Dim S_OtherDed As String
            Dim S_Advances As String



            Dim PipeLine As String = "|"
            Dim IncludeHeaders As Boolean = True
            Dim Rowcount As Integer = 1
            Dim TotalRows As Integer
            TotalRows = ReportDS.Tables(0).Rows.Count - 1
            For i = 0 To ReportDS.Tables(0).Rows.Count - 1
                If i <> TotalRows Then
                    If i <> TotalRows - 2 Then



                        Dim Ce As Integer = 0
                        Dim Cd As Integer = 0
                        Dim Cc As Integer = 0


                        Dim C1 As Integer
                        Dim C2 As Integer
                        Dim k As Integer



                        Dim R As DataRow = ReportDS.Tables(0).Rows(i)
                        If IncludeHeaders Then
                            IncludeHeaders = False






                            S = S & DG1.Columns(Me.Column_PeriodCode).HeaderText & PipeLine

                            S = S & DG1.Columns(Me.Column_EmpCode).HeaderText & PipeLine
                            S = S & DG1.Columns(Me.Column_EmpName).HeaderText & PipeLine


                            ' S = S & DG1.Columns(Me.Column_Salary1).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_Salary2).HeaderText & PipeLine

                            ' S = S & DG1.Columns(Me.Column_sectors).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_dutyhours).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_flighthours).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_commission).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_OverLay).HeaderText & PipeLine



                            '------------------------------------------------------------------
                            'Earnings
                            '------------------------------------------------------------------

                            C1 = 0
                            C2 = 0
                            Dim Sequence As Integer = 0
                            Dim PrevSequence As Integer = 0
                            For k = 0 To 14

                                If DbNullToString(DG1.Columns(Me.Column_EV1 + C1).HeaderText) <> "" Then
                                    Sequence = FindEDCSequence("E", DbNullToString(R.Item(Me.Column_E1 + C1)))
                                    If DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_BIK Then
                                        S_BIK = "Rec Benefits in Kind"
                                    ElseIf DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_ReimbOfExp Then
                                        S_ReimbOfExp = "Reimbersment Of Expenses"
                                    Else
                                        If Sequence <> 0 Then
                                            Dim Z As Integer
                                            For Z = PrevSequence + 1 To Sequence - 1
                                                S = S & " " & PipeLine
                                            Next
                                        End If
                                        S = S & DG1.Columns(Me.Column_EV1 + C1).HeaderText & PipeLine
                                    End If
                                    PrevSequence = Sequence
                                End If
                                C1 = C1 + 2
                            Next

                            ' S = S & " " & PipeLine
                            S = S & "Total Salaries" & PipeLine
                            S = S & S_BIK & PipeLine
                            S = S & DG1.Columns(Me.Column_EVTotal).HeaderText & PipeLine
                            S = S & " " & PipeLine

                            '------------------------------------------------------------------
                            'Deductions
                            '------------------------------------------------------------------
                            C1 = 0
                            C2 = 0
                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_DV1 + C1).HeaderText) <> "" Then
                                    If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_OtherDed Then
                                        S_OtherDed = "Other Deductions"
                                    ElseIf DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_Advances Then
                                        S_Advances = "Advances"
                                    Else
                                        S = S & DG1.Columns(Me.Column_DV1 + C1).HeaderText & PipeLine

                                    End If
                                End If
                                C1 = C1 + 2

                            Next
                            ' S = S & " " & PipeLine
                            S = S & DG1.Columns(Column_DVTotal).HeaderText & PipeLine
                            S = S & " " & PipeLine
                            '------------------------------------------------------------------
                            'Contributions
                            '------------------------------------------------------------------
                            C1 = 0
                            C2 = 0
                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_CV1 + C1).HeaderText) <> "" Then
                                    S = S & DG1.Columns(Me.Column_CV1 + C1).HeaderText & PipeLine
                                End If
                                C1 = C1 + 2

                            Next

                            S = S & DG1.Columns(Column_CVTotal).HeaderText & PipeLine
                            S = S & " " & PipeLine

                            S = S & S_Advances & PipeLine
                            S = S & S_OtherDed & PipeLine
                            S = S & "Total Other Deductions" & PipeLine
                            S = S & " " & PipeLine


                            ''''''''
                            S = S & "Net Before Other Deductions" & PipeLine
                            S = S & S_ReimbOfExp & PipeLine
                            S = S & "Net Salaries Paid" & PipeLine
                            S = S & "Social Ins. Contr. Paid" & PipeLine
                            S = S & "Income Tax Paid" & PipeLine
                            S = S & "Payroll Cost" & PipeLine
                            S = S & S_BIK & PipeLine
                            S = S & "Total Payroll Cost" & PipeLine


                            S = S & DG1.Columns(Me.Column_ActualUnits).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_DOE).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Position).HeaderText & PipeLine
                            S = S & DG1.Columns(Me.Column_GenAnal1).HeaderText & PipeLine

                            S = S & DG1.Columns(Column_AL_Code1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code2).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc2).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code3).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc3).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code4).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc4).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code5).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc5).HeaderText & PipeLine


                            S = S & DG1.Columns(Column_TimeOff).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Overtime1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_OverTime2).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_OverTime3).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Termdate).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_SINumber).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_BankBenName).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_ComBank).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_DOB).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_identity).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_tic).HeaderText & PipeLine

                            Dim Ar1() As String
                            Ar1 = S.Split("|")
                            Dim t1 As Integer
                            For t1 = 0 To Ar1.Length - 1
                                xlsWorkSheet.Cells(Rowcount, t1 + 1) = Ar1(t1)
                            Next
                            Rowcount = Rowcount + 1

                        End If

                        S = ""
                        If Rowcount = ReportDS.Tables(0).Rows.Count Then
                            S = "Totals"
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' LINES
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim Name As String
                        Name = DbNullToString(R.Item(Me.Column_EmpName))
                        If Name <> "" Then
                            S = S & R.Item(Me.Column_PeriodCode) & PipeLine
                            S = S & R.Item(Me.Column_EmpCode) & PipeLine
                            S = S & R.Item(Me.Column_EmpName) & PipeLine

                            'S = S & R.Item(Me.Column_Salary1) & PipeLine
                            'S = S & R.Item(Me.Column_Salary2) & PipeLine

                            ' S = S & R.Item(Me.Column_sectors) & PipeLine
                            ' S = S & R.Item(Me.Column_dutyhours) & PipeLine
                            ' S = S & R.Item(Me.Column_flighthours) & PipeLine
                            ' S = S & R.Item(Me.Column_commission) & PipeLine
                            ' S = S & R.Item(Me.Column_OverLay) & PipeLine





                            '------------------------------------------------------------------
                            'Earnings
                            '------------------------------------------------------------------
                            C1 = 0
                            C2 = 0
                            Dim V_BIK As Double = 0
                            Dim V_Total As Double = 0
                            Dim V_TotalSalaries As Double = 0
                            Dim V_ReimbOfExp As Double = 0

                            Dim Sequence As Integer
                            Dim PrevSequence As Integer

                            For k = 0 To 14

                                If DbNullToString(DG1.Columns(Me.Column_EV1 + C1).HeaderText) <> "" Then
                                    Sequence = FindEDCSequence("E", DbNullToString(R.Item(Me.Column_E1 + C1)))
                                    If DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_BIK Then
                                        V_BIK = Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00")
                                    ElseIf DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_ReimbOfExp Then
                                        V_ReimbOfExp = Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00")
                                    Else
                                        If Sequence <> 0 Then
                                            Dim Z As Integer
                                            For Z = PrevSequence + 1 To Sequence - 1
                                                S = S & " " & PipeLine
                                            Next
                                        End If
                                        S = S & Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00") & PipeLine
                                    End If
                                    PrevSequence = Sequence
                                End If
                                C1 = C1 + 2

                            Next
                            ''
                            'S = S & " " & PipeLine

                            V_Total = Format(DbNullToDouble(R.Item(Me.Column_EVTotal)), "0.00")
                            S = S & Format(V_Total - V_BIK - V_ReimbOfExp, "0.00") & PipeLine
                            S = S & Format(V_BIK, "0.00") & PipeLine
                            S = S & Format(V_Total, "0.00") & PipeLine

                            S = S & " " & PipeLine


                            '------------------------------------------------------------------
                            'Deductions
                            '-----------------------------------------------------------------
                            C1 = 0
                            C2 = 0

                            Dim V_OtherDed As Double = 0
                            Dim V_Advances As Double = 0
                            Dim V_TotalDed As Double = 0
                            Dim V_TotalDedWithOther As Double = 0
                            Dim V_IncomeTax As Double = 0
                            Dim V_D_SI As Double
                            Dim V_D_NHS As Double


                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_DV1 + C1).HeaderText) <> "" Then
                                    If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_OtherDed Then
                                        V_OtherDed = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                    ElseIf DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_Advances Then
                                        V_Advances = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                    Else
                                        S = S & Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00") & PipeLine
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_IncomeTax Then
                                            V_IncomeTax = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_D_SI Then
                                            V_D_SI = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_D_NHS Then
                                            V_D_NHS = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If


                                    End If
                                End If
                                C1 = C1 + 2

                            Next
                            V_TotalDedWithOther = DbNullToDouble(R.Item(Column_DVTotal))
                            V_TotalDed = V_TotalDedWithOther - V_OtherDed - V_Advances
                            'S = S & " " & PipeLine
                            S = S & Format(V_TotalDed, "0.00") & PipeLine
                            S = S & " " & PipeLine

                            '------------------------------------------------------------------
                            'Contributions
                            '------------------------------------------------------------------
                            Dim V_C_SI As Double = 0
                            Dim V_C_NHS As Double = 0
                            Dim V_C_Ind As Double = 0
                            Dim V_C_Unemp As Double = 0
                            Dim V_C_SCoh As Double = 0

                            C1 = 0
                            C2 = 0
                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_CV1 + C1).HeaderText) <> "" Then
                                    S = S & Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00") & PipeLine
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_SI Then
                                        V_C_SI = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_Industrial Then
                                        V_C_Ind = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_Unemployement Then
                                        V_C_Unemp = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_SocialCohesion Then
                                        V_C_SCoh = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_NHS Then
                                        V_C_NHS = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                End If
                                C1 = C1 + 2

                            Next

                            S = S & Format(DbNullToDouble(R.Item(Column_CVTotal)), "0.00") & PipeLine
                            S = S & " " & PipeLine

                            S = S & Format(V_Advances, "0.00") & PipeLine
                            S = S & Format(V_OtherDed, "0.00") & PipeLine
                            S = S & Format(V_OtherDed + V_Advances, "0.00") & PipeLine
                            S = S & " " & PipeLine

                            Dim Net As Double = 0
                            Dim NetBeforeOther As Double = 0
                            Dim TotalSI As Double = 0
                            Dim TotalCost1 As Double = 0
                            Dim TotalCost2 As Double = 0

                            Net = DbNullToDouble(R.Item(Me.Column_NetSalary))
                            NetBeforeOther = Format(Net - (V_OtherDed + V_Advances), "0.00")

                            TotalSI = V_D_SI + V_D_NHS + V_C_SI + +V_C_Unemp + +V_C_Ind + +V_C_SCoh + V_C_NHS

                            S = S & Format(NetBeforeOther, "0.00") & PipeLine
                            S = S & Format(V_ReimbOfExp, "0.00") & PipeLine
                            S = S & Format(Net, "0.00") & PipeLine
                            S = S & Format(TotalSI, "0.00") & PipeLine
                            S = S & Format(V_IncomeTax, "0.00") & PipeLine

                            TotalCost1 = DbNullToDouble(R.Item(Column_CompanyCost))
                            TotalCost2 = DbNullToDouble(R.Item(Column_CompanyCost))
                            TotalCost1 = TotalCost1 - V_BIK - V_ReimbOfExp
                            TotalCost2 = TotalCost2 - V_ReimbOfExp

                            S = S & Format(TotalCost1, "0.00") & PipeLine
                            S = S & Format(V_BIK, "0.00") & PipeLine
                            S = S & Format(TotalCost2, "0.00") & PipeLine


                            S = S & R.Item(Me.Column_ActualUnits) & PipeLine
                            S = S & R.Item(Column_DOE) & PipeLine
                            S = S & R.Item(Column_Position) & PipeLine
                            S = S & R.Item(Me.Column_GenAnal1) & PipeLine
                            S = S & R.Item(Column_AL_Code1) & PipeLine
                            S = S & R.Item(Column_AL_Desc1) & PipeLine
                            S = S & R.Item(Column_AL_Code2) & PipeLine
                            S = S & R.Item(Column_AL_Desc2) & PipeLine
                            S = S & R.Item(Column_AL_Code3) & PipeLine
                            S = S & R.Item(Column_AL_Desc3) & PipeLine
                            S = S & R.Item(Column_AL_Code4) & PipeLine
                            S = S & R.Item(Column_AL_Desc4) & PipeLine
                            S = S & R.Item(Column_AL_Code5) & PipeLine
                            S = S & R.Item(Column_AL_Desc5) & PipeLine

                            S = S & R.Item(Column_TimeOff) & PipeLine
                            S = S & R.Item(Column_Overtime1) & PipeLine
                            S = S & R.Item(Column_OverTime2) & PipeLine
                            S = S & R.Item(Column_OverTime3) & PipeLine
                            S = S & R.Item(Column_Termdate) & PipeLine
                            S = S & R.Item(Column_SINumber) & PipeLine
                            S = S & R.Item(Column_BankBenName) & PipeLine
                            S = S & R.Item(Column_ComBank) & PipeLine
                            S = S & R.Item(Column_DOB) & PipeLine
                            S = S & R.Item(Column_identity) & PipeLine
                            S = S & R.Item(Column_tic) & PipeLine



                            Dim Ar2() As String
                            Ar2 = S.Split("|")
                            Dim t2 As Integer = 0
                            For t2 = 0 To Ar2.Length - 1
                                xlsWorkSheet.Cells(Rowcount, t2 + 1) = Ar2(t2)
                            Next
                        End If
                        Rowcount = Rowcount + 1


                    End If
                End If
            Next
            If Not UseFileName Then
                Dim FileName As String
                Dim S1 As String
                Dim S2 As String
                Dim PG As String
                PG = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).DescriptionL
                S1 = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes).Code
                S2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes).Code

                FileName = PG & "_" & S1 & "_" & Analysis & ".xlsx"

                xlsWorkBook.SaveAs(ExportFileDir & FileName)


                xlsWorkBook.Close()
                xls.Quit()
            Else

                xlsWorkBook.SaveAs(FileName2)
                xls.Visible = True
                'xlsWorkBook.Close()
                'xls.Quit()
            End If
        End If





    End Sub
    Private Sub ExcelFormat2()
        Excel2Reportname = ""
        Dim F As New FrmReportName
        Dim Proceed As Boolean = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.YTDReport Then
            If CheckDataSet(MyDs2) Then
                Proceed = True
            End If
        Else
            If CheckDataSet(MyDs) Then
                Proceed = True
            End If
        End If
        If Me.UseMyDsX Then
            If CheckDataSet(MyDsX) Then
                Proceed = True
            End If
        End If

        If Proceed Then
            F.Owner = Me
            F.ShowDialog()



            If Excel2Reportname <> "" Then
                'SaveFile.FileName = ""
                'SaveFile.ShowDialog()
                'Me.txtToFile.Text = SaveFile.FileName
                Dim Filename As String
                Dim Ds As DataSet
                Ds = Global1.Business.GetParameter("Reports", "ExportFileDir")
                If CheckDataSet(Ds) Then
                    Dim P As New cPrSsParameters
                    P = New cPrSsParameters(Ds.Tables(0).Rows(0))
                    Dim PValue As String
                    PValue = Replace(P.Value1, "$", Global1.GLBUserCode)
                    Filename = PValue & Excel2Reportname & ".xlsx"
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()
                    WriteToExcel_NEW_3("", "", True, Filename)
                Else
                    MsgBox("Please define parameter 'Reports','ExportFileDir'", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Please select Valid Report Name", MsgBoxStyle.Information)
            End If

        End If
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub
    Private Sub WriteToExcel_NEW_3(ByVal Analysis As String, ByVal ExportFileDir As String, ByVal UseFileName As Boolean, ByVal FileName2 As String)

        Dim ReportDS As DataSet
        If Me.YTDReport Then
            ReportDS = MyDs2.Copy
        Else
            ReportDS = MyDs.Copy
        End If
        If Me.UseMyDsX Then
            ReportDS = MyDsX.Copy
        End If

        InitExcelFile = True
        Dim i As Integer

        If CheckDataSet(ReportDS) Then

            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            Dim S As String
            Dim S_BIK As String
            Dim S_ReimbOfExp As String
            Dim S_OtherDed As String
            Dim S_Advances As String



            Dim PipeLine As String = "|"
            Dim IncludeHeaders As Boolean = True
            Dim Rowcount As Integer = 1
            Dim TotalRows As Integer
            TotalRows = ReportDS.Tables(0).Rows.Count - 1
            For i = 0 To ReportDS.Tables(0).Rows.Count - 1
                If i <> TotalRows Then
                    If i <> TotalRows - 2 Then



                        Dim Ce As Integer = 0
                        Dim Cd As Integer = 0
                        Dim Cc As Integer = 0


                        Dim C1 As Integer
                        Dim C2 As Integer
                        Dim k As Integer



                        Dim R As DataRow = ReportDS.Tables(0).Rows(i)
                        If IncludeHeaders Then
                            IncludeHeaders = False


                            S = S & DG1.Columns(Column_AL_Code4).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc4).HeaderText & PipeLine
                            S = S & DG1.Columns(Me.Column_GenAnal1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code2).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc2).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code3).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc3).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Code5).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_AL_Desc5).HeaderText & PipeLine

                            S = S & DG1.Columns(Column_Position).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_DOE).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Termdate).HeaderText & PipeLine


                            S = S & DG1.Columns(Me.Column_PeriodCode).HeaderText & PipeLine

                            S = S & DG1.Columns(Me.Column_EmpCode).HeaderText & PipeLine
                            S = S & DG1.Columns(Me.Column_EmpName).HeaderText & PipeLine


                            ' S = S & DG1.Columns(Me.Column_Salary1).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_Salary2).HeaderText & PipeLine

                            ' S = S & DG1.Columns(Me.Column_sectors).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_dutyhours).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_flighthours).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_commission).HeaderText & PipeLine
                            ' S = S & DG1.Columns(Me.Column_OverLay).HeaderText & PipeLine



                            '------------------------------------------------------------------
                            'Earnings
                            '------------------------------------------------------------------

                            C1 = 0
                            C2 = 0
                            Dim Sequence As Integer = 0
                            Dim PrevSequence As Integer = 0
                            For k = 0 To 14

                                If DbNullToString(DG1.Columns(Me.Column_EV1 + C1).HeaderText) <> "" Then
                                    Sequence = FindEDCSequence("E", DbNullToString(R.Item(Me.Column_E1 + C1)))
                                    If DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_BIK Then
                                        S_BIK = "Rec Benefits in Kind"
                                    ElseIf DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_ReimbOfExp Then
                                        S_ReimbOfExp = "Reimbersment Of Expenses"
                                    Else
                                        If Sequence <> 0 Then
                                            Dim Z As Integer
                                            For Z = PrevSequence + 1 To Sequence - 1
                                                S = S & " " & PipeLine
                                            Next
                                        End If
                                        S = S & DG1.Columns(Me.Column_EV1 + C1).HeaderText & PipeLine
                                    End If
                                    PrevSequence = Sequence
                                End If
                                C1 = C1 + 2
                            Next

                            ' S = S & " " & PipeLine
                            S = S & "Total Salaries" & PipeLine
                            S = S & S_BIK & PipeLine
                            S = S & DG1.Columns(Me.Column_EVTotal).HeaderText & PipeLine
                            S = S & " " & PipeLine

                            '------------------------------------------------------------------
                            'Deductions
                            '------------------------------------------------------------------
                            C1 = 0
                            C2 = 0
                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_DV1 + C1).HeaderText) <> "" Then
                                    If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_OtherDed Then
                                        S_OtherDed = "Other Deductions"
                                    ElseIf DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_Advances Then
                                        S_Advances = "Advances"
                                    Else
                                        S = S & DG1.Columns(Me.Column_DV1 + C1).HeaderText & PipeLine

                                    End If
                                End If
                                C1 = C1 + 2

                            Next
                            ' S = S & " " & PipeLine
                            S = S & DG1.Columns(Column_DVTotal).HeaderText & PipeLine
                            S = S & " " & PipeLine
                            '------------------------------------------------------------------
                            'Contributions
                            '------------------------------------------------------------------
                            C1 = 0
                            C2 = 0
                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_CV1 + C1).HeaderText) <> "" Then
                                    S = S & DG1.Columns(Me.Column_CV1 + C1).HeaderText & PipeLine
                                End If
                                C1 = C1 + 2

                            Next

                            S = S & DG1.Columns(Column_CVTotal).HeaderText & PipeLine
                            S = S & " " & PipeLine

                            S = S & S_Advances & PipeLine
                            S = S & S_OtherDed & PipeLine
                            S = S & "Total Other Deductions" & PipeLine
                            S = S & " " & PipeLine


                            ''''''''
                            S = S & "Net Before Other Deductions" & PipeLine
                            S = S & S_ReimbOfExp & PipeLine
                            S = S & "Net Salaries Paid" & PipeLine
                            S = S & "Social Ins. Contr. Paid" & PipeLine
                            S = S & "Income Tax Paid" & PipeLine
                            S = S & "Payroll Cost" & PipeLine
                            S = S & S_BIK & PipeLine
                            S = S & "Total Payroll Cost" & PipeLine


                            S = S & DG1.Columns(Me.Column_ActualUnits).HeaderText & PipeLine
                            

                            'S = S & DG1.Columns(Column_AL_Code1).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Desc1).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Code2).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Desc2).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Code3).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Desc3).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Code4).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Desc4).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Code5).HeaderText & PipeLine
                            'S = S & DG1.Columns(Column_AL_Desc5).HeaderText & PipeLine


                            S = S & DG1.Columns(Column_TimeOff).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Overtime1).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_OverTime2).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_OverTime3).HeaderText & PipeLine

                            S = S & DG1.Columns(Column_SINumber).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_BankBenName).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_ComBank).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_DOB).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Identity).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_TIC).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_Maternity).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_FEPercentage).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_FEControlAmount).HeaderText & PipeLine
                            S = S & DG1.Columns(Column_EmpTermReason).HeaderText & PipeLine

                            Dim Ar1() As String
                            Ar1 = S.Split("|")
                            Dim t1 As Integer
                            For t1 = 0 To Ar1.Length - 1
                                xlsWorkSheet.Cells(Rowcount, t1 + 1) = Ar1(t1)
                            Next
                            Rowcount = Rowcount + 1

                        End If

                        S = ""
                        If Rowcount = ReportDS.Tables(0).Rows.Count Then
                            S = "Totals"
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' LINES
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim Name As String
                        Name = DbNullToString(R.Item(Me.Column_EmpName))
                        If Name <> "" Then

                            S = S & R.Item(Column_AL_Code4) & PipeLine
                            S = S & R.Item(Column_AL_Desc4) & PipeLine
                            S = S & R.Item(Me.Column_GenAnal1) & PipeLine
                            S = S & R.Item(Column_AL_Code1) & PipeLine
                            S = S & R.Item(Column_AL_Desc1) & PipeLine
                            S = S & R.Item(Column_AL_Code2) & PipeLine
                            S = S & R.Item(Column_AL_Desc2) & PipeLine
                            S = S & R.Item(Column_AL_Code3) & PipeLine
                            S = S & R.Item(Column_AL_Desc3) & PipeLine
                            S = S & R.Item(Column_AL_Code5) & PipeLine
                            S = S & R.Item(Column_AL_Desc5) & PipeLine

                            S = S & R.Item(Column_Position) & PipeLine

                            Dim Xx As String
                            Xx = R.Item(Column_DOE).ToString
                            Xx = Replace(Xx, "/", ".")

                            'S = S & R.Item(Column_DOE).ToString & PipeLine
                            S = S & Xx & PipeLine

                            'If R.Item(Column_DOE) <> "" Then
                            '    Dim DOE As String
                            '    DOE = Format(DbNullToDate(R.Item(Column_DOE)), "dd/MM/yyyy")
                            '    S = S & DOE & PipeLine
                            'Else
                            '    S = S & R.Item(Column_DOE) & PipeLine
                            'End If

                            S = S & R.Item(Column_Termdate) & PipeLine


                            S = S & R.Item(Me.Column_PeriodCode) & PipeLine

                            S = S & R.Item(Me.Column_EmpCode) & PipeLine
                            S = S & R.Item(Me.Column_EmpName) & PipeLine

                            'S = S & R.Item(Me.Column_Salary1) & PipeLine
                            'S = S & R.Item(Me.Column_Salary2) & PipeLine

                            ' S = S & R.Item(Me.Column_sectors) & PipeLine
                            ' S = S & R.Item(Me.Column_dutyhours) & PipeLine
                            ' S = S & R.Item(Me.Column_flighthours) & PipeLine
                            ' S = S & R.Item(Me.Column_commission) & PipeLine
                            ' S = S & R.Item(Me.Column_OverLay) & PipeLine





                            '------------------------------------------------------------------
                            'Earnings
                            '------------------------------------------------------------------
                            C1 = 0
                            C2 = 0
                            Dim V_BIK As Double = 0
                            Dim V_Total As Double = 0
                            Dim V_TotalSalaries As Double = 0
                            Dim V_ReimbOfExp As Double = 0

                            Dim Sequence As Integer
                            Dim PrevSequence As Integer

                            For k = 0 To 14

                                If DbNullToString(DG1.Columns(Me.Column_EV1 + C1).HeaderText) <> "" Then
                                    Sequence = FindEDCSequence("E", DbNullToString(R.Item(Me.Column_E1 + C1)))
                                    If DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_BIK Then
                                        V_BIK = Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00")
                                    ElseIf DbNullToString(R.Item(Me.Column_E1 + C1)) = Me.R2_ReimbOfExp Then
                                        V_ReimbOfExp = Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00")
                                    Else
                                        If Sequence <> 0 Then
                                            Dim Z As Integer
                                            For Z = PrevSequence + 1 To Sequence - 1
                                                S = S & " " & PipeLine
                                            Next
                                        End If
                                        S = S & Format(DbNullToDouble(R.Item(Me.Column_EV1 + C1)), "0.00") & PipeLine
                                    End If
                                    PrevSequence = Sequence
                                End If
                                C1 = C1 + 2

                            Next
                            ''
                            'S = S & " " & PipeLine

                            V_Total = Format(DbNullToDouble(R.Item(Me.Column_EVTotal)), "0.00")

                            S = S & Format(V_Total - V_BIK - V_ReimbOfExp, "0.00") & PipeLine
                            Dim Total_Salaries As Double = 0
                            Total_Salaries = V_Total - V_BIK - V_ReimbOfExp
                            S = S & Format(V_BIK, "0.00") & PipeLine
                            S = S & Format(V_Total, "0.00") & PipeLine

                            S = S & " " & PipeLine


                            '------------------------------------------------------------------
                            'Deductions
                            '-----------------------------------------------------------------
                            C1 = 0
                            C2 = 0

                            Dim V_OtherDed As Double = 0
                            Dim V_Advances As Double = 0
                            Dim V_TotalDed As Double = 0
                            Dim V_TotalDedWithOther As Double = 0
                            Dim V_IncomeTax As Double = 0
                            Dim V_D_SI As Double
                            Dim V_D_NHS As Double
                            Dim V_D_bikNHS As Double


                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_DV1 + C1).HeaderText) <> "" Then
                                    If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_OtherDed Then
                                        V_OtherDed = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                    ElseIf DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_Advances Then
                                        V_Advances = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                    Else
                                        S = S & Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00") & PipeLine
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_IncomeTax Then
                                            V_IncomeTax = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_D_SI Then
                                            V_D_SI = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_D_NHS Then
                                            V_D_NHS = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If
                                        If DbNullToString(R.Item(Me.Column_D1 + C1)) = Me.R2_D_BikNHS Then
                                            V_D_bikNHS = Format(DbNullToDouble(R.Item(Me.Column_DV1 + C1)), "0.00")
                                        End If


                                    End If
                                End If
                                C1 = C1 + 2

                            Next
                            V_TotalDedWithOther = DbNullToDouble(R.Item(Column_DVTotal))
                            V_TotalDed = V_TotalDedWithOther - V_OtherDed - V_Advances
                            'S = S & " " & PipeLine
                            S = S & Format(V_TotalDed, "0.00") & PipeLine
                            S = S & " " & PipeLine

                            '------------------------------------------------------------------
                            'Contributions
                            '------------------------------------------------------------------
                            Dim V_C_SI As Double = 0
                            Dim V_C_NHS As Double = 0
                            Dim V_C_Ind As Double = 0
                            Dim V_C_Unemp As Double = 0
                            Dim V_C_SCoh As Double = 0

                            C1 = 0
                            C2 = 0
                            For k = 0 To 14
                                If DbNullToString(DG1.Columns(Me.Column_CV1 + C1).HeaderText) <> "" Then
                                    S = S & Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00") & PipeLine
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_SI Then
                                        V_C_SI = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_Industrial Then
                                        V_C_Ind = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_Unemployement Then
                                        V_C_Unemp = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_SocialCohesion Then
                                        V_C_SCoh = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                    If DbNullToString(R.Item(Me.Column_C1 + C1)) = Me.R2_C_NHS Then
                                        V_C_NHS = Format(DbNullToDouble(R.Item(Me.Column_CV1 + C1)), "0.00")
                                    End If
                                End If
                                C1 = C1 + 2

                            Next

                            S = S & Format(DbNullToDouble(R.Item(Column_CVTotal)), "0.00") & PipeLine
                            S = S & " " & PipeLine

                            S = S & Format(V_Advances, "0.00") & PipeLine
                            S = S & Format(V_OtherDed, "0.00") & PipeLine
                            S = S & Format(V_OtherDed + V_Advances, "0.00") & PipeLine
                            S = S & " " & PipeLine

                            Dim Net As Double = 0
                            Dim NetBeforeOther As Double = 0
                            Dim TotalSI As Double = 0
                            Dim TotalCost1 As Double = 0
                            Dim TotalCost2 As Double = 0

                            Net = DbNullToDouble(R.Item(Me.Column_NetSalary))

                            'NetBeforeOther = Format(Net - (V_OtherDed + V_Advances), "0.00")
                            NetBeforeOther = Format(Total_Salaries - V_TotalDed, "0.00")


                            TotalSI = V_D_SI + V_D_NHS + V_C_SI + +V_C_Unemp + +V_C_Ind + +V_C_SCoh + V_C_NHS

                            S = S & Format(NetBeforeOther, "0.00") & PipeLine
                            S = S & Format(V_ReimbOfExp, "0.00") & PipeLine
                            S = S & Format(Net, "0.00") & PipeLine
                            S = S & Format(TotalSI, "0.00") & PipeLine
                            V_IncomeTax = V_IncomeTax + V_D_bikNHS
                            S = S & Format(V_IncomeTax, "0.00") & PipeLine

                            TotalCost1 = DbNullToDouble(R.Item(Column_CompanyCost))
                            TotalCost2 = DbNullToDouble(R.Item(Column_CompanyCost))
                            TotalCost1 = TotalCost1 - V_BIK - V_ReimbOfExp
                            TotalCost2 = TotalCost2 - V_ReimbOfExp

                            S = S & Format(TotalCost1, "0.00") & PipeLine
                            S = S & Format(V_BIK, "0.00") & PipeLine
                            S = S & Format(TotalCost2, "0.00") & PipeLine


                            S = S & R.Item(Me.Column_ActualUnits) & PipeLine

                            'S = S & R.Item(Column_AL_Code1) & PipeLine
                            'S = S & R.Item(Column_AL_Desc1) & PipeLine
                            'S = S & R.Item(Column_AL_Code2) & PipeLine
                            'S = S & R.Item(Column_AL_Desc2) & PipeLine
                            'S = S & R.Item(Column_AL_Code3) & PipeLine
                            'S = S & R.Item(Column_AL_Desc3) & PipeLine
                            'S = S & R.Item(Column_AL_Code4) & PipeLine
                            'S = S & R.Item(Column_AL_Desc4) & PipeLine
                            'S = S & R.Item(Column_AL_Code5) & PipeLine
                            'S = S & R.Item(Column_AL_Desc5) & PipeLine

                            S = S & R.Item(Column_TimeOff) & PipeLine
                            S = S & R.Item(Column_Overtime1) & PipeLine
                            S = S & R.Item(Column_OverTime2) & PipeLine
                            S = S & R.Item(Column_OverTime3) & PipeLine

                            S = S & R.Item(Column_SINumber) & PipeLine
                            S = S & R.Item(Column_BankBenName) & PipeLine
                            S = S & R.Item(Column_ComBank) & PipeLine
                            'If R.Item(Column_DOB) <> "" Then
                            '    Dim DOB As String
                            '    DOB = Format(DbNullToDate(R.Item(Column_DOB)), "dd/MM/yyyy")
                            '    S = S & DOB & PipeLine
                            'Else
                            '    S = S & R.Item(Column_DOB) & PipeLine
                            'End If
                            Dim xDOBx As String
                            xDOBx = R.Item(Column_DOB)
                            xDOBx = Replace(xDOBx, "/", ".")
                            S = S & xDOBx & PipeLine

                            'S = S & R.Item(Column_DOB) & PipeLine

                            S = S & R.Item(Column_Identity) & PipeLine
                            S = S & R.Item(Column_TIC) & PipeLine
                            S = S & R.Item(Column_Maternity) & PipeLine
                            S = S & R.Item(Column_FEPercentage) & PipeLine
                            S = S & R.Item(Column_FEControlAmount) & PipeLine
                            S = S & R.Item(Column_EmpTermReason) & PipeLine



                            Dim Ar2() As String
                            Ar2 = S.Split("|")
                            Dim t2 As Integer = 0
                            For t2 = 0 To Ar2.Length - 1
                                xlsWorkSheet.Cells(Rowcount, t2 + 1) = Ar2(t2)
                            Next
                        End If
                            Rowcount = Rowcount + 1


                        End If
                    End If
            Next
            If Not UseFileName Then
                Dim FileName As String
                Dim S1 As String
                Dim S2 As String
                Dim PG As String
                PG = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).DescriptionL
                S1 = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes).Code
                S2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes).Code

                FileName = PG & "_" & S1 & "_" & Analysis & ".xlsx"

                xlsWorkBook.SaveAs(ExportFileDir & FileName)


                xlsWorkBook.Close()
                xls.Quit()
            Else

                xlsWorkBook.SaveAs(FileName2)
                xls.Visible = True
                'xlsWorkBook.Close()
                'xls.Quit()
            End If
        End If





    End Sub
    Private Function FindEDCSequence(ByVal MyType As String, ByVal EDCCode As String) As Integer
        Dim i As Integer
        Dim Sequence As Integer = 0

        If MyType = "E" Then
            For i = 0 To Me.DsP_Ern.Tables(0).Rows.Count - 1
                If DbNullToString(DsP_Ern.Tables(0).Rows(i).Item(3)) = EDCCode Then
                    Sequence = DbNullToInt(DsP_Ern.Tables(0).Rows(i).Item(4))
                    Exit For
                End If
            Next
        End If
        Return Sequence

    End Function


    Private Sub MonthlyEarnings(ByVal TF As Boolean, ByVal Totals1 As Boolean, ByVal Totals2 As Boolean)
        InitDataTable_3()
        Dim CompanyTotalCost As Double = 0
        If CheckDataSet(MyDs) Then
            Dim MyDs2 As New DataSet
            MyDs2.Tables.Add(MyDs.Tables(0).Copy)
            If MyDs2.Tables.Count > 0 Then
                Dim i As Integer
                Dim j As Integer
                Dim Counter As Integer
                Counter = MyDs2.Tables(0).Rows.Count - 1
                j = Counter

                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = GLBAnalysisDescriptionOnTheReport
                r(7) = GLBBankDescriptionOnTheReport
                If ShowTimeOff Then
                    r(5) = "TOf"
                Else
                    r(5) = "OT3"
                End If

                Dt3.Rows.Add(r)
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    Dim k As Integer
                    Dim C1 As Integer = 0
                    Dim D As String
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                        End If

                        MyDs2.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                        C1 = C1 + 2

                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                        C1 = C1 + 2
                    Next
                Next

                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "" And DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)).StartsWith("TOTALS") = False Then
                        CompanyTotalCost = CompanyTotalCost + DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                    End If
                    If ShowTimeOff Then
                        Dim Tof As Double
                        Tof = DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_OverTime3) = Format(Tof, "0.00")
                    End If
                Next

                r(4) = CompanyTotalCost
                MyDs2.Tables.Add(Dt3)


                Dim ReportDS As New DataSet
                ReportDS = MyDs2.Copy
                Dim c As Integer
                If Per.Code = Per2.Code Then

                    c = ReportDS.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        ReportDS.Tables(0).Rows(c).Delete()
                    End If
                    c = ReportDS.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        ReportDS.Tables(0).Rows(c - 1).Delete()
                    End If
                End If


                Dim ReportToUse As String = "MonthlyEarnings.rpt"
                
                ' Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                '   Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                Utils.ShowReport(ReportToUse, ReportDS, FrmReport, "", TF, "", False, False, "", True)
            End If
        End If
    End Sub

    Private Sub MonthlyEarningsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyEarningsToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "Earnings", False)
    End Sub
    Private Sub ShowCustomReportEDC(ByVal TF As Boolean, ByVal Totals1 As Boolean, ByVal Totals2 As Boolean, ByVal ReportType As String, ByVal ShowInExcel As Boolean)

        InitDataTable_3()
        Dim CompanyTotalCost As Double = 0
        If CheckDataSet(MyDs) Then
            Dim MyDs2 As New DataSet
            MyDs2.Tables.Add(MyDs.Tables(0).Copy)
            If MyDs2.Tables.Count > 0 Then
                Dim i As Integer
                Dim j As Integer
                Dim Counter As Integer
                Counter = MyDs2.Tables(0).Rows.Count - 1
                j = Counter
                'For i = Counter To 0 Step -1
                '    If DbNullToString(MyDs2.Tables(0).Rows(j).Item(0)) = "" Then
                '        Debug.WriteLine("1" & DbNullToString(MyDs2.Tables(0).Rows(j).Item(0)))
                '        Debug.WriteLine("2" & DbNullToString(MyDs2.Tables(0).Rows(j).Item(1)))
                '        Debug.WriteLine("3" & DbNullToString(MyDs2.Tables(0).Rows(j).Item(2)))
                '        MyDs2.Tables(0).Rows(j).Delete()
                '        j = j - 1
                '        Counter = MyDs2.Tables(0).Rows.Count - 1
                '    End If
                '    j = j - 1
                '    If j = -1 Then Exit For
                'Next


                Dim Per As New cPrMsPeriodCodes
                Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
                Dim Per2 As New cPrMsPeriodCodes
                Per2 = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

                Dim r As DataRow = Dt3.NewRow()

                Dim TemCode As New cPrMsTemplateGroup(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode)
                Dim Company As New cAdMsCompany(TemCode.CompanyCode)
                r(0) = Company.Name
                r(1) = TemCode.Code & " - " & TemCode.DescriptionL
                If Per.Code <> Per2.Code Then
                    r(2) = Per.DescriptionL & " - " & Per2.DescriptionL
                Else
                    r(2) = Per.Code & " - " & Per.DescriptionL
                End If
                r(3) = GLBAnalysisDescriptionOnTheReport
                r(7) = GLBBankDescriptionOnTheReport
                If ShowTimeOff Then
                    r(5) = "TOf"
                Else
                    r(5) = "OT3"
                End If



                Dt3.Rows.Add(r)
                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    Dim k As Integer
                    Dim C1 As Integer = 0
                    Dim D As String
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_EV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_EV1 + C1).HeaderText
                        End If

                        MyDs2.Tables(0).Rows(i).Item(Me.Column_E1 + C1) = D
                        C1 = C1 + 2

                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_DV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_DV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_D1 + C1) = D
                        C1 = C1 + 2
                    Next
                    C1 = 0
                    For k = 0 To 14
                        If DG1.Columns(Me.Column_CV1 + C1).HeaderText = "" Then
                            D = "N/A"
                        Else
                            D = DG1.Columns(Me.Column_CV1 + C1).HeaderText
                        End If
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_C1 + C1) = D
                        C1 = C1 + 2
                    Next
                Next

                For i = 0 To MyDs2.Tables(0).Rows.Count - 1
                    If DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)) <> "" And DbNullToString(MyDs2.Tables(0).Rows(i).Item(Me.Column_EmpCode)).StartsWith("TOTALS") = False Then
                        CompanyTotalCost = CompanyTotalCost + DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_CompanyCost))
                    End If
                    If ShowTimeOff Then
                        Dim Tof As Double
                        Tof = DbNullToDouble(MyDs2.Tables(0).Rows(i).Item(Me.Column_TimeOff))
                        MyDs2.Tables(0).Rows(i).Item(Me.Column_OverTime3) = Format(Tof, "0.00")
                    End If


                Next

                r(4) = CompanyTotalCost
                MyDs2.Tables.Add(Dt3)


                Dim ReportDS As New DataSet
                ReportDS = MyDs2.Copy
                Dim c As Integer
                If Per.Code = Per2.Code Then

                    c = ReportDS.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        ReportDS.Tables(0).Rows(c).Delete()
                    End If
                    c = ReportDS.Tables(0).Rows.Count - 1
                    If c <> 0 Then
                        ReportDS.Tables(0).Rows(c - 1).Delete()
                    End If
                End If



                Dim ReportToUse As String
                Dim LandScape As Boolean = True
                If ReportType = "Earnings" Then
                    ReportToUse = "MonthlyEarnings.rpt"
                End If
                If ReportType = "Deductions" Then
                    ReportToUse = "MonthlyDeductions.rpt"
                    For i = 0 To ReportDS.Tables(0).Rows.Count - 1
                        Dim D As Double = 0
                        D = ReportDS.Tables(0).Rows(i).Item(Me.Column_DV1)
                        D = D + ReportDS.Tables(0).Rows(i).Item(Me.Column_DV2)
                        D = D + ReportDS.Tables(0).Rows(i).Item(Me.Column_DV4)
                        D = D + ReportDS.Tables(0).Rows(i).Item(Me.Column_DV5)
                        ReportDS.Tables(0).Rows(i).Item(Me.Column_NetSalary) = ReportDS.Tables(0).Rows(i).Item(Me.Column_NetSalary) + D
                    Next
                End If

                'If ReportType = "CustomReport1" Then
                '    ReportToUse = "CustomReport1.rpt"
                '    For i = 0 To ReportDS.Tables(0).Rows.Count - 1
                '        Dim D As Double = 0
                '        D = ReportDS.Tables(0).Rows(i).Item(Me.Column_DV1)
                '        D = D + ReportDS.Tables(0).Rows(i).Item(Me.Column_DV2)
                '        D = D + ReportDS.Tables(0).Rows(i).Item(Me.Column_DV4)
                '        D = D + ReportDS.Tables(0).Rows(i).Item(Me.Column_DV5)
                '        ReportDS.Tables(0).Rows(i).Item(Me.Column_NetSalary) = ReportDS.Tables(0).Rows(i).Item(Me.Column_NetSalary) + D
                '    Next
                'End If




                If ReportType = "Contributions" Then
                    ReportToUse = "MonthlyContributions.rpt"
                End If

                If ReportType = "EmpNames1" Then
                    ReportToUse = "EmpNames1.rpt"
                    LandScape = False
                End If
                If ReportType = "MonthlyIT" Then
                    ReportToUse = "MonthlyIT.rpt"
                    For i = 0 To ReportDS.Tables(0).Rows.Count - 1
                        Dim NonTaxable As Double = 0
                        Dim TotalEarnings As Double
                        Dim EmpCode As String = ""
                        EmpCode = ReportDS.Tables(0).Rows(i).Item(Me.Column_EmpCode)
                        NonTaxable = Global1.Business.FindNonTaxableTotalForTemplateGroupForEmployee_ForSpecificPeriod(TemCode.Code, Per.PrdGrpCode, EmpCode, Per.Code)
                        TotalEarnings = DbNullToDouble(ReportDS.Tables(0).Rows(i).Item(Me.Column_EVTotal))
                        TotalEarnings = CDbl(TotalEarnings - NonTaxable)
                        ReportDS.Tables(0).Rows(i).Item(Me.Column_EVTotal) = TotalEarnings

                    Next
                End If
                If ReportType = "Deductions" Then

                    For i = 0 To ReportDS.Tables(0).Rows.Count - 1
                        Dim NonTaxable As Double = 0
                        Dim TotalEarnings As Double
                        Dim EmpCode As String = ""
                        EmpCode = ReportDS.Tables(0).Rows(i).Item(Me.Column_EmpCode)
                        NonTaxable = Global1.Business.FindNonTaxableTotalForTemplateGroupForEmployee_ForSpecificPeriod(TemCode.Code, Per.PrdGrpCode, EmpCode, Per.Code)
                        TotalEarnings = DbNullToDouble(ReportDS.Tables(0).Rows(i).Item(Me.Column_EVTotal))
                        TotalEarnings = CDbl(TotalEarnings - NonTaxable)
                        ReportDS.Tables(0).Rows(i).Item(Me.Column_EVTotal) = TotalEarnings
                        ReportDS.Tables(0).Rows(i).Item(Me.Column_CompanyCost) = NonTaxable
                    Next
                End If

                If ReportType = "MonthlySI" Then
                    ReportToUse = "MonthlySI1.rpt"
                End If

                'NO                Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                'NO                Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PayrollAnal")
                '   Utils.WriteSchemaWithXmlTextWriter(MyDs2, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\PayrollAnal")
                If Not ShowInExcel Then
                    Utils.ShowReport(ReportToUse, ReportDS, FrmReport, "", TF, "", False, False, "", LandScape)
                Else
                    Me.ExcelFormat1(ReportDS)
                End If
            End If
            End If
    End Sub
   

    Private Sub MonthlyDeductionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyDeductionsToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "Deductions", False)
    End Sub
    Private Sub CustomReport1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowCustomReportEDC(False, False, False, "Custom Report 1", False)
    End Sub

    Private Sub MonthlyContributionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyContributionsToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "Contributions", False)
    End Sub

    Private Sub Names1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Names1ToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "EmpNames1", False)
    End Sub

    Private Sub PensionFund2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionFund2ToolStripMenuItem.Click
        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PenFund As Double
        Dim WidowFund As Double
        Dim C10 As Double
        Dim C11 As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPensionFundReport(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PenFund = Global1.Business.GetDeductionCodeForHeader(HeaderId, "D14")
                C10 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C10")

                DsHeader.Tables(0).Rows(i).Item(6) = PenFund
                DsHeader.Tables(0).Rows(i).Item(7) = 0
                DsHeader.Tables(0).Rows(i).Item(8) = C10
                DsHeader.Tables(0).Rows(i).Item(9) = PenFund + C10
                TotalAB = TotalAB + PenFund + WidowFund + C10 + C11
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        'Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PenFundReport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PensionFund2.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If




    End Sub
    Private Sub PensionFund3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionFund3ToolStripMenuItem.Click

        Dim PerFrom As cPrMsPeriodCodes

        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PenFund As Double
        Dim WidowFund As Double
        Dim C10 As Double
        Dim C11 As Double

        Dim i As Integer
        Dim TotalAB As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPensionFundReport(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PenFund = Global1.Business.GetDeductionCodeForHeader(HeaderId, "D14")
                C10 = Global1.Business.GetContributionCodeForHeader(HeaderId, "C10")

                DsHeader.Tables(0).Rows(i).Item(6) = PenFund
                DsHeader.Tables(0).Rows(i).Item(7) = 0
                DsHeader.Tables(0).Rows(i).Item(8) = C10
                DsHeader.Tables(0).Rows(i).Item(9) = PenFund + C10
                TotalAB = TotalAB + PenFund + WidowFund + C10 + C11
            Next
        End If
        Dim DsCompany As DataSet
        DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
        DsCompany.Tables(0).Rows(0).Item(10) = TotalAB
        Dim DsPeriod As DataSet
        DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

        DsHeader.Tables(0).TableName = "Employee"

        DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
        DsHeader.Tables(1).TableName = "Company"

        DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
        DsHeader.Tables(2).TableName = "Period"


        ''Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\PenFundReport")
        'Utils.WriteSchemaWithXmlTextWriter(DsHeader, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\PenFunReport")

        If CheckDataSet(DsHeader) Then
            Utils.ShowReport("PensionFund3.rpt", DsHeader, FrmReport, "", False)
        Else
            MsgBox("No records found to print.", MsgBoxStyle.Information)
        End If



    End Sub

    Private Sub CovidTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CovidTestToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        Dim PerFrom As New cPrMsPeriodCodes


        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim PerGroup As New cPrMsPeriodGroups(PerFrom.PrdGrpCode)
        Dim TempGroup As String = PerGroup.TemGrpCode

        Dim Ds As DataSet
        Dim OnlyActive As Boolean = False
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("Only Employees with Status Active ?", MsgBoxStyle.YesNo)
        If Ans = MsgBoxResult.Yes Then
            OnlyActive = True
        End If

        Ds = Global1.Business.GetEmployeeCovidTestResult(TempGroup, PerFrom.DateFrom, PerFrom.DateTo, OnlyActive)
        If CheckDataSet(Ds) Then
            
        
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader


            HeaderStr.Add("Test Date")
            HeaderStr.Add("Emp Code")
            HeaderStr.Add("Emp Name")
            HeaderStr.Add("Is Negative")
            HeaderStr.Add("Template Group")
            HeaderStr.Add("Company Code")
            HeaderStr.Add("Week of Year")
            HeaderStr.Add("Month")
            HeaderStr.Add("Analysis 1 Code")
            HeaderStr.Add("Anaysisl 1")
            HeaderStr.Add("Analysis 2 Code")
            HeaderStr.Add("Anaysisl 2")
            HeaderStr.Add("Analysis 3 Code")
            HeaderStr.Add("Anaysisl 3")
            HeaderStr.Add("Analysis 4 Code")
            HeaderStr.Add("Anaysisl 4")
            HeaderStr.Add("Analysis 5 Code")
            HeaderStr.Add("Anaysisl 5")
            HeaderStr.Add("General Analysis 1")


            HeaderSize.Add(16)
            HeaderSize.Add(10)
            HeaderSize.Add(30)
            HeaderSize.Add(20)
            HeaderSize.Add(20)
            HeaderSize.Add(30)
            HeaderSize.Add(20)
            HeaderSize.Add(30)

            Me.Cursor = Cursors.Default
            Application.DoEvents()

            Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)
        Else
            MsgBox("No Results fund for current filters (Period/IsActive", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub MonthlySIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlySIToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "MonthlySI", False)
    End Sub

    Private Sub MonthlyTaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyTaxToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "MonthlyIT", False)
    End Sub

    Private Sub Names2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Names2ToolStripMenuItem.Click
        PrepareTHEUnitsReport()
    End Sub
    Private Sub PrepareTHEUnitsReport()
        'InitDataGrid()

        
        Me.lblStatus.Visible = True
        YTDReport = False
        'PrepareReport()

        PrepareReportUnits(False, False)
        Me.lblStatus.Visible = False
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub PrepareReportUnits(ByVal OnlyActiveemployees As Boolean, ByVal OnlyEmpWithTermDate As Boolean)

        Dim TotalEmp As Integer = 0

        Me.Cursor = Cursors.WaitCursor



        Dim Per As New cPrMsPeriodCodes
        Dim PerFrom As New cPrMsPeriodCodes
        Dim PerTo As New cPrMsPeriodCodes
        Dim i As Integer
        Dim C1 As Integer = 0
        Dim C2 As Integer = 0
        Dim k As Integer
        Dim ds As DataSet
        Dim DsHeader As DataSet
        Dim DsEmp As DataSet
        Dim DsPeriods As DataSet

        Dim SIDedTotal As Double = 0
        Dim SIConTotal As Double = 0

        Dim EmpToCode As String
        Dim EmpFromCode As String

        Dim GenAnal1 As String
        Dim SICategory As String


        Dim OrderByAnal As Integer = 0
        If Me.CBOrderByAnal.CheckState = CheckState.Checked Then
            If Me.txtOrderBy.Text = "" Then
                MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If
            OrderByAnal = txtOrderBy.Text
            If OrderByAnal <= 0 Or OrderByAnal >= 7 Then
                MsgBox("Please select a Valid Department Number for Sorting, Valid Values are 1 to 6 ", MsgBoxStyle.Critical)
                Me.Cursor = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If
        End If

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        PerTo = CType(Me.cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

        EmpFromCode = Me.txtFromEmployee.Text
        EmpToCode = Me.txtToEmployee.Text

        GenAnal1 = Me.txtGenAnal1.Text
        SICategory = Me.txtSICategory.Text

        Dim AgeFilter As String
        AgeFilter = Me.txtAgeFilter.Text
        If AgeFilter <> "" Then
            Dim AgeisOk As Boolean = False
            If AgeFilter.Contains(">") Or AgeFilter.Contains("<") Or AgeFilter.Contains("=") Then
                AgeisOk = True
            End If
            If Not AgeisOk Then
                MsgBox("Please select Valid filter in Age field", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Dim OnlyLeavers As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyLeavers = True
        End If

        Dim OnlyHiredThisYear As Boolean = False
        If Me.CBOnlyLeavers.CheckState = CheckState.Checked Then
            OnlyHiredThisYear = True
        End If

        DsPeriods = Global1.Business.GetPeriodRange(PerFrom, PerTo)
        ClearGrid()
        Dim j As Integer
        Dim Analysis As Integer
        Dim AnalysisCode As String
        Dim AnalysisCode2 As String
        Dim Position As String = ""
        Dim DOE As String = ""
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

        Dim Cash As Boolean = False
        Dim Cheque As Boolean = False
        Dim Bank As Boolean = False
        Dim Ewallet As Boolean = False

        If Me.CBCheque.CheckState = CheckState.Checked Then
            Cheque = True
        End If
        If Me.CBCash.CheckState = CheckState.Checked Then
            Cash = True
        End If
        If Me.CBBank.CheckState = CheckState.Checked Then
            Bank = True
        End If
        If Me.CBwallet.CheckState = CheckState.Checked Then
            eWallet = True
        End If


        Dim BankCode As String
        If Me.ComboBank.SelectedIndex = 0 Then
            BankCode = "ALL"
        Else
            BankCode = CType(Me.ComboBank.SelectedItem, cPrAnBanks).Code
        End If

        Dim EmpBankCode As String
        If Me.ComboEmpBank.SelectedIndex = 0 Then
            EmpBankCode = "ALL"
        Else
            EmpBankCode = CType(Me.ComboEmpBank.SelectedItem, cPrAnBanks).Code
        End If

        GLBAnalysisDescriptionOnTheReport = Me.ComboAnal.Text
        GLBBankDescriptionOnTheReport = Me.ComboBank.Text
        

        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForUnitsReport(PerFrom, EmpFromCode, EmpToCode, Analysis, AnalysisCode, Cash, Cheque, Bank, False, OnlyActiveemployees, GenAnal1, OrderByAnal, BankCode, EmpBankCode, OnlyEmpWithTermDate, SICategory, AgeFilter, OnlyLeavers, OnlyHiredThisYear, PerTo, Ewallet)
        '''''''''''''''''''''''''''''''
        If CheckDataSet(DsHeader) Then
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader

            

            HeaderStr.Add("Employee Code")
            HeaderStr.Add("Employee Name")
            HeaderStr.Add("Date of Birth")
            HeaderStr.Add("Start Date")
            HeaderStr.Add("Termination Date")
            HeaderStr.Add("Social Insurance Number")
            HeaderStr.Add("Termination Number")
            HeaderStr.Add("Tax Id")
            HeaderStr.Add("Total Period Units")
            HeaderStr.Add("Total Annual Units")
            HeaderStr.Add("Analysis Code 1")
            HeaderStr.Add("Analysis Code 2")
            HeaderStr.Add("Analysis Code 3")
            HeaderStr.Add("Analysis Code 4")
            HeaderStr.Add("Analysis Code 5")
            HeaderStr.Add("Analysis 1")
            HeaderStr.Add("Analysis 2")
            HeaderStr.Add("Analysis 3")
            HeaderStr.Add("Analysis 4")
            HeaderStr.Add("Analysis 5")


            HeaderSize.Add(10)
            HeaderSize.Add(50)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(10)

            Loader.LoadIntoExcel(DsHeader, HeaderStr, HeaderSize)

        Else
            MsgBox("No Matching Criteria found", MsgBoxStyle.Information)
        End If


        Me.Cursor = Cursors.Default
        Application.DoEvents()
        DG1.Cursor = Cursors.Default

    End Sub

    Private Sub Names3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Names3ToolStripMenuItem.Click

        Dim tempcol_AmountOnCheque As Integer = C_NetSalary + 1
        Dim tempcol_CompanyCost As Integer = C_NetSalary + 2
        Dim tempcol_DOB As Integer = C_NetSalary + 3
        Dim tempcol_DOE As Integer = C_NetSalary + 4
        Dim tempcol_AL_Code1 As Integer = C_NetSalary + 5
        Dim tempcol_AL_Desc1 As Integer = C_NetSalary + 6
        Dim tempcol_AL_Code2 As Integer = C_NetSalary + 7
        Dim tempcol_AL_Desc2 As Integer = C_NetSalary + 8
        Dim tempcol_AL_Code3 As Integer = C_NetSalary + 9
        Dim tempcol_AL_Desc3 As Integer = C_NetSalary + 10
        Dim tempcol_AL_Code4 As Integer = C_NetSalary + 11
        Dim tempcol_AL_Desc4 As Integer = C_NetSalary + 12
        Dim tempcol_AL_Code5 As Integer = C_NetSalary + 13
        Dim tempcol_AL_Desc5 As Integer = C_NetSalary + 14

        If YTDReport Then


            'MyDsSimple.Tables(0).Rows.Clear()

            'If CheckDataSet(MyDs) Then
            '    Dim Loader As New cExcelLoader
            '    Dim HeaderStr As New ArrayList
            '    Dim HeaderSize As New ArrayList

            '    Transfer_MyDsX_to_MyDs2(HeaderStr, HeaderSize)

            '    Dim MyDsCopy As DataSet
            '    MyDsCopy = MyDs2.Copy
            '    Dim lastI As Integer
            '    lastI = MyDsCopy.Tables(0).Rows.Count - 1
            '    MyDsCopy.Tables(0).Rows(lastI).Delete()
            '    lastI = MyDsCopy.Tables(0).Rows.Count - 1
            '    MyDsCopy.Tables(0).Rows(lastI - 1).Delete()

            '    Loader.LoadIntoExcel(MyDsCopy, HeaderStr, HeaderSize)

            'End If


        Else

            MyDsSimple.Tables(0).Rows.Clear()
            If CheckDataSet(MyDs) Then
                Dim HeaderStr As New ArrayList
                Dim HeaderSize As New ArrayList
                Dim Loader As New cExcelLoader

                Dim i As Integer
                For i = 0 To MyDs.Tables(0).Rows.Count - 1
                    Dim r As DataRow = DtSimple.NewRow()
                    r(C_EmpCode) = MyDs.Tables(0).Rows(i).Item(Column_EmpCode)
                    r(C_EmpName) = MyDs.Tables(0).Rows(i).Item(Column_EmpName)
                    r(C_ActualUnits) = MyDs.Tables(0).Rows(i).Item(Column_ActualUnits)


                    ''''''''''' Earnings ''''''''''''

                    r(C_EV1) = MyDs.Tables(0).Rows(i).Item(Column_EV1)
                    r(C_EV2) = MyDs.Tables(0).Rows(i).Item(Column_EV2)
                    r(C_EV3) = MyDs.Tables(0).Rows(i).Item(Column_EV3)
                    r(C_EV4) = MyDs.Tables(0).Rows(i).Item(Column_EV4)
                    r(C_EV5) = MyDs.Tables(0).Rows(i).Item(Column_EV5)
                    r(C_EV6) = MyDs.Tables(0).Rows(i).Item(Column_EV6)
                    r(C_EV7) = MyDs.Tables(0).Rows(i).Item(Column_EV7)
                    r(C_EV8) = MyDs.Tables(0).Rows(i).Item(Column_EV8)
                    r(C_EV9) = MyDs.Tables(0).Rows(i).Item(Column_EV9)
                    r(C_EV10) = MyDs.Tables(0).Rows(i).Item(Column_EV10)
                    r(C_EV11) = MyDs.Tables(0).Rows(i).Item(Column_EV11)
                    r(C_EV12) = MyDs.Tables(0).Rows(i).Item(Column_EV12)
                    r(C_EV13) = MyDs.Tables(0).Rows(i).Item(Column_EV13)
                    r(C_EV14) = MyDs.Tables(0).Rows(i).Item(Column_EV14)
                    r(C_EV15) = MyDs.Tables(0).Rows(i).Item(Column_EV15)
                    r(C_EVTotal) = MyDs.Tables(0).Rows(i).Item(Column_EVTotal)

                    ''''''''''' Deductions '''''''''

                    r(C_DV1) = MyDs.Tables(0).Rows(i).Item(Column_DV1)
                    r(C_DV2) = MyDs.Tables(0).Rows(i).Item(Column_DV2)
                    r(C_DV3) = MyDs.Tables(0).Rows(i).Item(Column_DV3)
                    r(C_DV4) = MyDs.Tables(0).Rows(i).Item(Column_DV4)
                    r(C_DV5) = MyDs.Tables(0).Rows(i).Item(Column_DV5)
                    r(C_DV6) = MyDs.Tables(0).Rows(i).Item(Column_DV6)
                    r(C_DV7) = MyDs.Tables(0).Rows(i).Item(Column_DV7)
                    r(C_DV8) = MyDs.Tables(0).Rows(i).Item(Column_DV8)
                    r(C_DV9) = MyDs.Tables(0).Rows(i).Item(Column_DV9)
                    r(C_DV10) = MyDs.Tables(0).Rows(i).Item(Column_DV10)
                    r(C_DV11) = MyDs.Tables(0).Rows(i).Item(Column_DV11)
                    r(C_DV12) = MyDs.Tables(0).Rows(i).Item(Column_DV12)
                    r(C_DV13) = MyDs.Tables(0).Rows(i).Item(Column_DV13)
                    r(C_DV14) = MyDs.Tables(0).Rows(i).Item(Column_DV14)
                    r(C_DV15) = MyDs.Tables(0).Rows(i).Item(Column_DV15)
                    r(C_DVTotal) = MyDs.Tables(0).Rows(i).Item(Column_DVTotal)

                    '''''''' Contributions '''''''''

                    r(C_CV1) = MyDs.Tables(0).Rows(i).Item(Column_CV1)
                    r(C_CV2) = MyDs.Tables(0).Rows(i).Item(Column_CV2)
                    r(C_CV3) = MyDs.Tables(0).Rows(i).Item(Column_CV3)
                    r(C_CV4) = MyDs.Tables(0).Rows(i).Item(Column_CV4)
                    r(C_CV5) = MyDs.Tables(0).Rows(i).Item(Column_CV5)
                    r(C_CV6) = MyDs.Tables(0).Rows(i).Item(Column_CV6)
                    r(C_CV7) = MyDs.Tables(0).Rows(i).Item(Column_CV7)
                    r(C_CV8) = MyDs.Tables(0).Rows(i).Item(Column_CV8)
                    r(C_CV9) = MyDs.Tables(0).Rows(i).Item(Column_CV9)
                    r(C_CV10) = MyDs.Tables(0).Rows(i).Item(Column_CV10)
                    r(C_CV11) = MyDs.Tables(0).Rows(i).Item(Column_CV11)
                    r(C_CV12) = MyDs.Tables(0).Rows(i).Item(Column_CV12)
                    r(C_CV13) = MyDs.Tables(0).Rows(i).Item(Column_CV13)
                    r(C_CV14) = MyDs.Tables(0).Rows(i).Item(Column_CV14)
                    r(C_CV15) = MyDs.Tables(0).Rows(i).Item(Column_CV15)

                    r(C_CVTotal) = MyDs.Tables(0).Rows(i).Item(Column_CVTotal)


                    Dim D As Double = 0
                    D = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV1))
                    D = D + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV2))
                    D = D + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV4))
                    D = D + DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Me.Column_DV5))

                    r(C_NetSalary) = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Column_NetSalary)) + D
                    'Dim S As Double
                    'S = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Column_NetSalary))

                    r(tempcol_AmountOnCheque) = DbNullToDouble(MyDs.Tables(0).Rows(i).Item(Column_NetSalary))
                    r(tempcol_CompanyCost) = MyDs.Tables(0).Rows(i).Item(Column_CompanyCost)
                    r(tempcol_DOB) = MyDs.Tables(0).Rows(i).Item(Column_DOB)
                    r(tempcol_DOE) = MyDs.Tables(0).Rows(i).Item(Column_DOE)
                    r(tempcol_AL_Code1) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code1)
                    r(tempcol_AL_Desc1) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc1)
                    r(tempcol_AL_Code2) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code2)
                    r(tempcol_AL_Desc2) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc2)
                    r(tempcol_AL_Code3) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code3)
                    r(tempcol_AL_Desc3) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc3)
                    r(tempcol_AL_Code4) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code4)
                    r(tempcol_AL_Desc4) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc4)
                    r(tempcol_AL_Code5) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Code5)
                    r(tempcol_AL_Desc5) = MyDs.Tables(0).Rows(i).Item(Me.Column_AL_Desc5)


                    DtSimple.Rows.Add(r)
                Next

                HeaderStr.Add(DG1.Columns(Column_EmpCode).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EmpName).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_ActualUnits).HeaderText())


                HeaderStr.Add(DG1.Columns(Column_EV1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV4).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV5).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV6).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV7).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV8).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV9).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV10).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV11).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV12).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV13).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV14).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EV15).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_EVTotal).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_DV1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV4).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV5).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV6).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV7).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV8).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV9).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV10).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV11).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV12).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV13).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV14).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DV15).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_DVTotal).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_CV1).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV2).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV3).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV4).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV5).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV6).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV7).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV8).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV9).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV10).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV11).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV12).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV13).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV14).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CV15).HeaderText())
                HeaderStr.Add(DG1.Columns(Column_CVTotal).HeaderText())

                HeaderStr.Add(DG1.Columns(Column_NetSalary).HeaderText())
                HeaderStr.Add("Amount on Cheque")
                HeaderStr.Add(DG1.Columns(Column_CompanyCost).HeaderText())
                HeaderStr.Add("Date of Birth")
                HeaderStr.Add("Date of employment")

                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code1).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc1).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code2).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc2).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code3).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc3).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code4).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc4).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Code5).HeaderText())
                HeaderStr.Add(DG1.Columns(Me.Column_AL_Desc5).HeaderText())


                For i = 0 To HeaderStr.Count - 1
                    If HeaderStr(i) = "" Then
                        HeaderSize.Add(0)
                    Else
                        Dim C As Integer = 0
                        C = HeaderStr(i).ToString.Length
                        C = 8
                        HeaderSize.Add(C)
                    End If
                Next
                Dim MyDsCopy As DataSet
                MyDsCopy = MyDsSimple.Copy
                Dim lastI As Integer
                lastI = MyDsCopy.Tables(0).Rows.Count - 1
                MyDsCopy.Tables(0).Rows(lastI).Delete()
                lastI = MyDsCopy.Tables(0).Rows.Count - 1
                MyDsCopy.Tables(0).Rows(lastI - 1).Delete()

                Loader.LoadIntoExcel(MyDsCopy, HeaderStr, HeaderSize)
            End If
        End If
    End Sub

   
  
    Private Sub CBShowAllYears_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBShowAllYears.CheckedChanged
        Me.LoadPeriodGroup()
    End Sub

   
    
    Private Sub TSMExcelFormat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMExcelFormat1.Click
        ExcelFormat1()
    End Sub

    Private Sub TSMExcelFormat2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMExcelFormat2.Click
        ExcelFormat2()
    End Sub
    Private Sub AncoriaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AncoriaToolStripMenuItem.Click
        ExportPFToAncoria()
    End Sub

    Private Sub ExportPFToAncoria()


        Dim Fname As String = "AncoriaPFFile.xlsx"


        Dim Separator As String = ","

        Dim PerFrom As cPrMsPeriodCodes
        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PFA As Double
        Dim PFB As Double
        Dim LOAN As Double
        Dim i As Integer
        Dim TotalAB As Double = 0
        Dim GrandTotal As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPFReport_Loan(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)

        If CheckDataSet(DsHeader) Then
            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PFA = Global1.Business.GetDeductionForHeader(HeaderId, "PF")
                PFB = Global1.Business.GetContributionForHeader(HeaderId, "PF")
                LOAN = Global1.Business.GetDeductionForHeader(HeaderId, "PL")

                DsHeader.Tables(0).Rows(i).Item(6) = PFA
                DsHeader.Tables(0).Rows(i).Item(7) = PFB
                DsHeader.Tables(0).Rows(i).Item(8) = LOAN
                TotalAB = PFA + PFB + LOAN
                DsHeader.Tables(0).Rows(i).Item(10) = TotalAB
                GrandTotal = GrandTotal + TotalAB
            Next

            Dim DsCompany As DataSet
            DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
            DsCompany.Tables(0).Rows(0).Item(10) = GrandTotal
            DsCompany.Tables(0).Rows(0).Item(11) = Me.ComboAnal.Text
            Dim FundCode As String
            FundCode = DbNullToString(DsCompany.Tables(0).Rows(0).Item(12))

            Dim DsPeriod As DataSet
            DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

            DsHeader.Tables(0).TableName = "Employee"

            DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
            DsHeader.Tables(1).TableName = "Company"

            DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
            DsHeader.Tables(2).TableName = "Period"

            Dim RowCount As Integer = 1
            Dim Header As String


            xlsWorkSheet.Cells(RowCount, 1) = "Pension Plan Holder"
            xlsWorkSheet.Cells(RowCount, 2) = DbNullToString(DsHeader.Tables(1).Rows(0).Item(1))

            RowCount = RowCount + 1
            xlsWorkSheet.Cells(RowCount, 1) = "Ancoria Pension Plan Number"
            xlsWorkSheet.Cells(RowCount, 2) = FundCode

            RowCount = RowCount + 1

            Dim tDate As Date = DbNullToDate(DsHeader.Tables(2).Rows(0).Item(3))
            Dim PeriodCode As String = PeriodCode = Format(tDate, "MM/yyyy")


            xlsWorkSheet.Cells(RowCount, 1) = "Contribution Payment Period"
            xlsWorkSheet.Cells(RowCount, 2) = PeriodCode 'DbNullToString(DsHeader.Tables(2).Rows(0).Item(0))


            RowCount = RowCount + 1
            xlsWorkSheet.Cells(RowCount, 1) = ""

            RowCount = RowCount + 1
            xlsWorkSheet.Cells(RowCount, 1) = ""

            RowCount = RowCount + 1
            Dim sTotal As String
            sTotal = Format(DbNullToDouble(DsHeader.Tables(1).Rows(0).Item(10)), "0.00")
            xlsWorkSheet.Cells(RowCount, 1) = "Total Payment Amount"
            xlsWorkSheet.Cells(RowCount, 2) = sTotal


            RowCount = RowCount + 1
            xlsWorkSheet.Cells(RowCount, 1) = ""


            Dim EmpName As String
            Dim EmpIdNumber As String

            Dim ValueA As Double
            Dim ValueB As Double
            Dim Line As String

            Dim sValueA As String
            Dim sValueB As String
            Dim sLoan As String

            RowCount = RowCount + 1
            xlsWorkSheet.Cells(RowCount, 1) = "Member"
            xlsWorkSheet.Cells(RowCount, 2) = "Identification Number"
            xlsWorkSheet.Cells(RowCount, 3) = "Member Contribution"
            xlsWorkSheet.Cells(RowCount, 4) = "Employer Contribution"
            xlsWorkSheet.Cells(RowCount, 5) = "Instalment Repayment"



            For i = 0 To DsHeader.Tables(0).Rows.Count - 1

                EmpName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
                EmpIdNumber = DbNullToString(DsHeader.Tables(0).Rows(i).Item(9))
                ValueA = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(6))
                ValueB = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(7))
                LOAN = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(8))

                sValueA = Format(ValueA, "0.00")
                sValueB = Format(ValueB, "0.00")
                sloan = Format(LOAN, "0.00")
                RowCount = RowCount + 1

                xlsWorkSheet.Cells(RowCount, 1) = EmpName
                xlsWorkSheet.Cells(RowCount, 2) = EmpIdNumber
                xlsWorkSheet.Cells(RowCount, 3) = sValueA
                xlsWorkSheet.Cells(RowCount, 4) = sValueB
                xlsWorkSheet.Cells(RowCount, 5) = sloan

            Next
            FileName = PFExportFileDir & Fname

            xlsWorkBook.SaveAs(FileName)
            xlsWorkBook.Close()
            xls.Quit()

            MsgBox("File is created", MsgBoxStyle.Information)

        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If













    End Sub
    Private Function WriteToCSVFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = PFExportFileDir & fName

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
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    
    Private Sub LifeGoalsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LifeGoalsToolStripMenuItem.Click
        ExportPFToLifeGoals()
    End Sub
    Private Sub ExportPFToLifeGoals()
        Dim Fname As String = "LifeGoalsPFFile.xlsx"
        InitFile = True
        Dim Separator As String = ","

        Dim PerFrom As cPrMsPeriodCodes
        Dim EmpFrom As String
        Dim Empto As String

        Dim DsHeader As DataSet

        PerFrom = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)


        EmpFrom = Me.txtFromEmployee.Text
        Empto = Me.txtToEmployee.Text



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




        Dim HeaderId As Integer
        Dim PFA As Double
        Dim PFB As Double
        Dim LOAN As Double
        Dim i As Integer
        Dim TotalAB As Double = 0
        Dim GrandTotal As Double = 0
        'Per = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        GetPeriodEDC(PerFrom)
        DsHeader = Global1.Business.GetAllTrxnHeaderForPeriodForPFReport_Loan(PerFrom, EmpFrom, Empto, Analysis, AnalysisCode)
        If CheckDataSet(DsHeader) Then
            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                HeaderId = DbNullToInt(DsHeader.Tables(0).Rows(i).Item(0))
                PFA = Global1.Business.GetDeductionForHeader(HeaderId, "PF")
                PFB = Global1.Business.GetContributionForHeader(HeaderId, "PF")
                LOAN = Global1.Business.GetDeductionForHeader(HeaderId, "PL")

                DsHeader.Tables(0).Rows(i).Item(6) = PFA
                DsHeader.Tables(0).Rows(i).Item(7) = PFB
                DsHeader.Tables(0).Rows(i).Item(8) = LOAN
                TotalAB = PFA + PFB + LOAN
                DsHeader.Tables(0).Rows(i).Item(10) = TotalAB
                GrandTotal = GrandTotal + TotalAB
            Next

            Dim DsCompany As DataSet
            DsCompany = Global1.Business.GetCompanyDetailsForPFReport(TemGrp.CompanyCode)
            DsCompany.Tables(0).Rows(0).Item(10) = GrandTotal
            DsCompany.Tables(0).Rows(0).Item(11) = Me.ComboAnal.Text
            Dim FundCode As String
            FundCode = DbNullToString(DsCompany.Tables(0).Rows(0).Item(13))

            Dim DsPeriod As DataSet
            DsPeriod = Global1.Business.GetPeriodDetailsForPFreport(PerFrom)

            DsHeader.Tables(0).TableName = "Employee"

            DsHeader.Tables.Add(DsCompany.Tables(0).Copy)
            DsHeader.Tables(1).TableName = "Company"

            DsHeader.Tables.Add(DsPeriod.Tables(0).Copy)
            DsHeader.Tables(2).TableName = "Period"

            Dim Header As String
            Dim RowCount As Integer = 1
            'xlsWorkSheet.Cells(RowCount, 1) = "Pension Plan Holder"
            'xlsWorkSheet.Cells(RowCount, 2) = "FundCode"
            'xlsWorkSheet.Cells(RowCount, 1) = "EmployerCode"




            xlsWorkSheet.Cells(RowCount, 1) = "ReferencePeriod"
            xlsWorkSheet.Cells(RowCount, 2) = "MemberName"
            xlsWorkSheet.Cells(RowCount, 3) = "MemberIdentityNumber"
            xlsWorkSheet.Cells(RowCount, 4) = "MemberContribution"
            xlsWorkSheet.Cells(RowCount, 5) = "EmployerContribution"
            xlsWorkSheet.Cells(RowCount, 6) = "LoanInstalment"



            Dim EmpCode As String
            Dim EmpName As String
            Dim PeriodCode As String
            Dim EmpIdNumber As String
            Dim ValueA As Double
            Dim ValueB As Double
            Dim LoanValue As Double
            Dim Line As String

            Dim sValueA As String
            Dim sValueB As String
            Dim sLoanValue As String

            Dim tDate As Date = DbNullToDate(DsHeader.Tables(2).Rows(0).Item(3))
            PeriodCode = Format(tDate, "MM/yyyy")
            For i = 0 To DsHeader.Tables(0).Rows.Count - 1
                RowCount = RowCount + 1
                EmpCode = DbNullToString(DsHeader.Tables(0).Rows(i).Item(1))
                EmpName = DbNullToString(DsHeader.Tables(0).Rows(i).Item(2))
                EmpIdNumber = DbNullToString(DsHeader.Tables(0).Rows(i).Item(11))
                ValueA = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(6))
                ValueB = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(7))
                LoanValue = DbNullToDouble(DsHeader.Tables(0).Rows(i).Item(8))

                sValueA = Format(ValueA, "0.00")
                sValueB = Format(ValueB, "0.00")
                sLoanValue = Format(LoanValue, "0.00")



                ' xlsWorkSheet.Cells(RowCount, 1) = ""
                ' xlsWorkSheet.Cells(RowCount, 2) = FundCode
                'xlsWorkSheet.Cells(RowCount, 1) = EmpCode
                xlsWorkSheet.Cells(RowCount, 1) = PeriodCode.ToString
                xlsWorkSheet.Cells(RowCount, 2) = EmpName
                xlsWorkSheet.Cells(RowCount, 3) = EmpIdNumber
                xlsWorkSheet.Cells(RowCount, 4) = sValueA
                xlsWorkSheet.Cells(RowCount, 5) = sValueB
                xlsWorkSheet.Cells(RowCount, 6) = sLoanValue



            Next
            FileName = PFExportFileDir & Fname

            xlsWorkBook.SaveAs(FileName)
            xlsWorkBook.Close()
            xls.Quit()
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    
    
    Private Sub NetGrossExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NetGrossExcelToolStripMenuItem.Click
        ShowCustomReportEDC(False, False, False, "Deductions", True)
    End Sub
    Private Sub TaxCalculationExcelTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxCalculationExcelTS.Click
        ShowCustomReport_TaxCalculation()

    End Sub
    Private Sub ShowCustomReport_TaxCalculation()
        Dim Ds As DataSet
        Dim FromEmp As String
        Dim ToEmp As String
        Dim PeriodCode As String
        Dim PeriodGroup As String
        Dim TempGroup As String
        TempGroup = CType(cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).TemGrpCode
        PeriodGroup = CType(cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).Code
        PeriodCode = CType(CmbPeriod.SelectedItem, cPrMsPeriodCodes).Code
        FromEmp = Me.txtFromEmployee.Text
        ToEmp = Me.txtToEmployee.Text


        Ds = Global1.Business.GetTaxCalculationReport(FromEmp, ToEmp, PeriodCode, PeriodGroup, TempGroup)
        If CheckDataSet(Ds) Then

            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader

            'HeaderStr.Add("Code")
            'HeaderSize.Add(6)


            Loader.LoadIntoExcel(Ds, HeaderStr, HeaderSize)
        Else
            MsgBox("No Data found Machine the criteria", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub ExcelFormat1(ByVal DsToExport As DataSet)
        Dim Fname As String = "TempExcelFile1.xlsx"


        Dim Separator As String = ","
        Dim i As Integer
      
        If CheckDataSet(DsToExport) Then
            Dim xls As Microsoft.Office.Interop.Excel.Application
            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xls = New Microsoft.Office.Interop.Excel.Application
            'xlsWorkBook = xlsWorkBook.("c:\bookl.xlsx")
            xlsWorkBook = xls.Workbooks.Add(misValue)
            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")

            Dim RowCount As Integer = 1
            Dim Header As String


            xlsWorkSheet.Cells(RowCount, 1) = "Code"
            xlsWorkSheet.Cells(RowCount, 2) = "Name"
            xlsWorkSheet.Cells(RowCount, 3) = "Analisys 2 Code"
            xlsWorkSheet.Cells(RowCount, 4) = "Analysis 2"
            xlsWorkSheet.Cells(RowCount, 5) = "Total Earnings"
            xlsWorkSheet.Cells(RowCount, 6) = "Total Epidomata"
            xlsWorkSheet.Cells(RowCount, 7) = "Net"
            xlsWorkSheet.Cells(RowCount, 8) = "Date Of Employment"
            xlsWorkSheet.Cells(RowCount, 9) = "Date Of Birth"
            RowCount = RowCount + 1


            Dim code As String
            Dim Name As String
            Dim anl2Code As String
            Dim Anl2Name As String
            Dim Gross As Double
            Dim TotalEpidomata As Double
            Dim Net As Double
            Dim tempAnl2 As String
            Dim DOE As Date
            Dim DOB As Date
            Dim sDOE As String
            Dim sDOB As String
            For i = 0 To DsToExport.Tables(0).Rows.Count - 1
                code = DbNullToString(DsToExport.Tables(0).Rows(i).Item(0))
                Name = DbNullToString(DsToExport.Tables(0).Rows(i).Item(1))
                anl2Code = DbNullToString(DsToExport.Tables(0).Rows(i).Item(111))
                Anl2Name = DbNullToString(DsToExport.Tables(0).Rows(i).Item(124))
                Gross = DbNullToDouble(DsToExport.Tables(0).Rows(i).Item(33))

                TotalEpidomata = DbNullToDouble(DsToExport.Tables(0).Rows(i).Item(97))
                Net = DbNullToDouble(DsToExport.Tables(0).Rows(i).Item(96))
                sDOE = DbNullToString(DsToExport.Tables(0).Rows(i).Item(113))
                sDOB = DbNullToString(DsToExport.Tables(0).Rows(i).Item(132))

                If i = 0 Then
                    tempAnl2 = anl2Code
                End If
                If tempAnl2 <> anl2Code Then
                    tempAnl2 = anl2Code
                    RowCount = RowCount + 2

                End If

                xlsWorkSheet.Cells(RowCount, 1) = code
                xlsWorkSheet.Cells(RowCount, 2) = Name
                xlsWorkSheet.Cells(RowCount, 3) = anl2Code
                xlsWorkSheet.Cells(RowCount, 4) = Anl2Name
                xlsWorkSheet.Cells(RowCount, 5) = Gross
                xlsWorkSheet.Cells(RowCount, 6) = TotalEpidomata
                xlsWorkSheet.Cells(RowCount, 7) = Net
                'xlsWorkSheet.Cells(RowCount, 7) = Format(DOE, "dd/MMM/yyyy")
                'xlsWorkSheet.Cells(RowCount, 8) = Format(DOB, "dd/MMM/yyyy")
                xlsWorkSheet.Cells(RowCount, 8) = sDOE
                xlsWorkSheet.Cells(RowCount, 9) = sDOB
                RowCount = RowCount + 1

            Next
            FileName = PFExportFileDir & Fname

            xlsWorkBook.SaveAs(FileName)
            xlsWorkBook.Close()
            xls.Quit()

            MsgBox("File is created", MsgBoxStyle.Information)

        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If



    End Sub

   
    Private Sub SplitAcrossCompaniesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitAcrossCompaniesToolStripMenuItem.Click
        'YTDReport = False
        'DG1.DataSource = MyDs.Tables(0)
        'ClearGrid()
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()

        Dim col_Company As Integer = 0
        Dim col_PeriodCode As Integer = 1
        Dim col_EmpCode As Integer = 2
        Dim col_EmpName As Integer = 3
        Dim col_ActualUnits As Integer = 4
        Dim col_TotalEarnings As Integer = 5
        Dim col_TotalDeductions As Integer = 6
        Dim col_Totalcontributions As Integer = 7
        Dim col_Net As Integer = 8
        Dim col_TaxDeduction As Integer = 9
        Dim col_SIDeduction As Integer = 10

        MyDsSplit.Tables(0).Rows.Clear()


        Dim i As Integer
        Dim k As Integer
        Dim SelectedPeriodGroup As cPrMsPeriodGroups
        SelectedPeriodGroup = CType(cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
        Dim FromPeriod As cPrMsPeriodCodes
        Dim ToPeriod As cPrMsPeriodCodes
        FromPeriod = CType(CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        ToPeriod = CType(cmbPeriodTo.SelectedItem, cPrMsPeriodCodes)

        Dim PerG As cPrMsPeriodGroups
        Dim PerF As cPrMsPeriodCodes
        Dim PerT As cPrMsPeriodCodes
        Dim DsEmp As DataSet
        Dim TemGroup As String

        Dim empCode As String
        For i = 0 To Me.cmbPeriodGroups.Items.Count - 1
            PerG = CType(cmbPeriodGroups.Items(i), cPrMsPeriodGroups)
            TemGroup = PerG.TemGrpCode
            Dim TmpGrp As New cPrMsTemplateGroup(TemGroup)
            Dim C As New cAdMsCompany(TmpGrp.CompanyCode)
            If SelectedPeriodGroup.Year = PerG.Year Then



                PerF = New cPrMsPeriodCodes(FromPeriod.Code, PerG.Code)
                PerT = New cPrMsPeriodCodes(ToPeriod.Code, PerG.Code)
                If PerT.Code = "" Or IsNothing(PerT.Code) Then
                    Dim Temp As String = ToPeriod.Code.Substring(0, 4)
                    Temp = Temp & "12"
                    PerT = New cPrMsPeriodCodes(Temp, PerG.Code)
                End If
                Dim DsPeriods As DataSet
                DsPeriods = Global1.Business.GetPeriodRange(PerF, PerT)

                DsEmp = Global1.Business.GetAllRmployessWithSplit(TemGroup)
                If CheckDataSet(DsEmp) Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        empCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(empCode)
                        'Dim j As Integer = 0
                        'For j = 0 To DsPeriods.Tables(0).Rows.Count - 1
                        'Dim Per As New cPrMsPeriodCodes(DsPeriods.Tables(0).Rows(j))

                        Dim DsVal As New DataSet
                        DsVal = Global1.Business.GetSplitAcrossCompaniesForPeriods(empCode, PerF, PerT)
                        If CheckDataSet(DsVal) Then
                            Dim r As DataRow = DtSplit.NewRow()

                            r(col_Company) = C.Name
                            r(col_PeriodCode) = PerF.DescriptionL & "-" & PerT.DescriptionL
                            r(col_EmpCode) = Emp.Code
                            r(col_EmpName) = Emp.FullName
                            r(col_ActualUnits) = Format(DbNullToDouble(DsVal.Tables(0).Rows(0).Item(0)), "0.00")
                            r(col_TotalEarnings) = Format(DbNullToDouble(DsVal.Tables(0).Rows(0).Item(1)), "0.00")
                            r(col_TotalDeductions) = Format(DbNullToDouble(DsVal.Tables(0).Rows(0).Item(2)), "0.00")
                            r(col_Totalcontributions) = Format(DbNullToDouble(DsVal.Tables(0).Rows(0).Item(3)), "0.00")
                            r(col_Net) = Format(DbNullToDouble(DsVal.Tables(0).Rows(0).Item(4)), "0.00")

                            r(col_TaxDeduction) = Format(Global1.Business.GetPeriodValueOf_IT_ForEmployeeForPeriods(Emp.Code, PerF, PerT), "0.00")
                            r(col_SIDeduction) = Format(Global1.Business.GetPeriodValueOf_SI_ForEmployeeForPeriods(Emp.Code, PerF, PerT), "0.00")

                            DtSplit.Rows.Add(r)
                        End If
                        'Next
                    Next
                End If
            End If
        Next

        Cursor.Current = Cursors.Default
        Application.DoEvents()


        Dim F As New FrmDifReport
        F.Ds = MyDsSplit
        F.ShowDialog()

    End Sub


   
   
    
    Private Sub btnPeriodGroupSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodGroupSearch.Click
        Dim F As New FrmPeriodGroupSearch
        F.Owner = Me
        F.DsPeriodGroups = DsPeriodGroups
        F.CalledBy = 1
        F.ShowDialog()

    End Sub

   
End Class