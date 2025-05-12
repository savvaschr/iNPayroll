
Imports System.Security.Authentication
Imports System.Net
Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop.Excel
Public Class FrmPrTxCalculatePayroll

    Dim GLB_PeriodTaxable As Double
    Dim GlbNightShiftamount As Double = 0
    Dim GLBFirstGross As Double = 0
    Dim GLBTaxOnBIK As Double = 0
    Dim GLBTaxWithoutBIK As Double = 0
    Dim GLBRemainingReccuringBIK As Double = 0
    Dim S_LITodate As Double
    Dim S_LIPeriod As Double
    Dim S_LIPrevious As Double
    Dim S_DisTodate As Double
    Dim S_DisPeriod As Double
    Dim S_DisPrevious As Double
    Dim S_SIPFMFTodate As Double
    Dim S_SIPFMFPeriod As Double
    Dim S_SIPFMFPrevious As Double
    Dim S_TaxEarnTodate As Double
    Dim S_TaxEarnPeriod As Double
    Dim S_STPrevious As Double
    Dim S_TaxEarnPrevious As Double
    Dim S_GESID_Previous As Double
    Dim S_Union_Previous As Double
    Dim S_13SEstimation As Double

    Dim OvertimeRateofCOLA As Double = 0
    Public DsEDCType As DataSet
    Public GLBChequeNo As String = ""
    Public GLBChequeDate As Date = Now.Date
    Dim InitFile As Boolean = False
    Public GLBDsErn As DataSet
    Public GLBDsDed As DataSet
    Public GLBDsCon As DataSet

    Public GLBTemplateGroup As cPrMsTemplateGroup



    Public GLBEmployee As New cPrMsEmployees
    Public Calculated As Boolean = False
    Public GLBCurrentPeriod As New cPrMsPeriodCodes
    Public PayslipFoldeDirectory As String
    Public TaxableAdditionFor13 As Double = 0
    Public GlbSILeavePerc As Double = 0
    Public GLBWording As String = ""


    Public GLBYTDScheduled As Boolean
    Public GLBYTDScheduledDateTime As Date

    Public GLBRateFromSalary2 As Double
    Public OvertimeRateFromRateOnSalary As Double

    Public GLBLimits As New cPrSsLimits

    Public GLBTotalYearSplitForGESI As Double


    Public GLBAnnualAllocationForthisTemplate As Boolean = False

    Dim GlbEmpSalary As New cPrTxEmployeeSalary

    ''' '''''''''''''''''''''''''''
    Dim RateForOvertimeCalc As Double '= Rate(hourly) OR Gross/NormalUnits(Periodicly OR Contract)




    Dim GrossFor13AND14Calc As Double
    Dim GrossDIVNormalUnitsForCalc13 As Decimal
    Dim GrossDIVNormalUnitsForCalc14 As Decimal
    Dim ArrearsFor13AND14Calc As Double
    Dim GrossDIVNormalUnits As Double

    ''' '''''''''''''''''''''''''''
    Public Ern(14) As E_Pay
    Public Ded(14) As D_Pay
    Public Con(14) As C_Pay

    Public E_Final(14) As E_Final
    Public D_Final(14) As D_Final
    Public C_Final(14) As C_Final

    Dim DsP_Ern As DataSet
    Dim DSP_Ded As DataSet
    Dim DSP_Con As DataSet

    Dim Period_SIIncome As Double
    Dim GLBRemainingPeriodsWithSI As Integer
    Dim RemainingPeriodsWithGESI As Integer

    Dim Period_ONLY_Recuring_SI As Double
    Dim Period_TaxableIncome As Double
    Dim Period_Discounts As Double
    Dim Period_FE As Double

    Dim Period_LifeInsurance As Double
    Dim Period_InsurableIncome As Double
    Dim Period_SpecialTaxValue As Double

    Dim Period_Decrease As Double
    Dim Period_PensionFund As Double
    Dim Period_WidowFund As Double

    Public CurrentOwnerColumn As Integer
    Public LoadedFromArchive As Boolean = False
    Public XSalary As Double
    Dim GLBReverseCalc As Boolean = False
    Public CurRate As Double
    Public GLBCompany As cAdMsCompany
    Dim GLBAnnualLeaveUnits As Double = 0

    Dim GlbSalary1 = 0
    Dim GlbSalary2 = 0

    Dim GLBPeriodSIonSplit As Double = 0

    Public TotalWorkDaysOfMonth As Double = 0
    Public CaclulateMyRateInDays As Boolean = False

    Dim GLBMyRate As Double = 0
    Dim GLBCOLAValue As Double = 0
    Dim GLBRecurringEarning As Double = 0
    Dim GLBBenefitsRecurringEarning As Double = 0
    Dim GLBBenefitsRecurringEarning2 As Double = 0
    Dim GLBPensionDeduction As Double = 0

    Dim GLBRecurringEarning14 As Double = 0
    Dim GLBBenefitsRecurringEarning14 As Double = 0

    

    Dim GLBSalaryForRate As Double = 0
    Public PreviousPeriod As cPrMsPeriodCodes
    Dim GLBSIPercentage As Double = 0
    Dim GLBMFPercentage As Double = 0
    Dim GLBMFAmount As Double = 0
    Dim GLBPFPercentage As Double = 0
    Dim GLBPFAmount As Double = 0



    Dim GLBITValueWithRecuring As Double
    Dim GLBITValueWithNORecuring As Double
    Public GLBTemplatePFDs As DataSet

    Dim GLB_PF_ByTheEndOfTheYear As Double = 0
    Dim GLB_MF_ByTheEndOfTheYear As Double = 0
    Dim GLB_UNION_ByTheEndOfTheYear As Double = 0
    Dim GLB_DN_ByTheEndOfTheYear As Double = 0
    Dim GLB_PenF_ByTheEndOfTheYear As Double = 0
    Dim GLB_WidF_ByTheEndOfTheYear As Double = 0
    Dim GLB_GESI_ByTheEndOfTheYear As Double = 0
    Dim GLB_BIK_GESI_ByTheEndOfTheYear As Double = 0


    Dim GLBDNValueOfRecuring As Double = 0
    Dim SIValueForRemainingPeriods As Double = 0

    Dim HASSeparateCOLA As Boolean = False
    Dim tempEE_13 As New cPrMsEmployeeEarnings
    Dim tempEarn_13 As New cPrMsEarningCodes
    Dim tempEE_14 As New cPrMsEmployeeEarnings
    Dim tempEarn_14 As New cPrMsEarningCodes

    Dim GLBArrearsForCOLA As Double = 0
    Dim GLB13SalaryForCOLA As Double = 0
    Dim GLB14SalaryForCOLA As Double = 0
    Dim GLBAdditionTo13 As Double = 0
    Dim GLBAdditionTo14 As Double = 0

    Dim GLBAgreedSalary As Double = 0


    Dim GLB_SPlit_PeriodSplit As Double = 0
    Dim GLB_SPlit_PeriodSIonSplit As Double = 0
    Dim GLB_Split_TotalToTheEndOfYear As Double = 0
    Dim GLB_Split_SIUntilNow As Double = 0
    Dim GLBSILeave As Double = 0

    Dim PeriodGesiDValue As Double = 0
    Dim PeriodGesiCValue As Double = 0

    Dim PeriodExtraMedicalValue As Double = 0
    Dim PeriodExtraPensionFundValue As Double = 0

    Dim GLBRemainingPeriodsWithSILeave As Integer = 0
    Dim GLBGesiAmount As Double = 0
    Dim BIK_GLBGesiAmount As Double = 0
    Dim Period_BIK_GesiDValue As Double = 0
    Dim Period_BIK_GesiCValue As Double = 0

    Dim TryingToFindNetToGross As Boolean = False
    Public GLBCOLAValueNotZero As Boolean = False

    Dim GLBRecuringValueOfSILeave As Double = 0
    Dim GLB_TodateGesi_DED As Double = 0
    Dim GLB_TodateGesi_CON As Double = 0

    Dim LimitOfGESYasInsurableAmount As Double = 180000
    Dim GLBRoundUpAmount As Double = 0
    Dim GlbRunroundUp As Boolean = False
    Dim GLBPercentageOfFE As String = 0
    Dim GLBGrossSalaryForHourlyRateForTaxCalculation As Double = 0


    Public GLBMySIDeductionRate As Double = 0
    Public GLBMySIcontributionRate As Double = 0

    Const _Tls12 As SslProtocols = DirectCast(&HC00, SslProtocols)
    Const Tls12 As SecurityProtocolType = DirectCast(_Tls12, SecurityProtocolType)

    Private Sub FrmPrTxCalculatePayroll_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not LoadedFromArchive Then
            If Me.txtPeriodCode.Text = CType(Me.Owner, FrmPayroll1).txtPeriodCode.Text Then
                Dim Status As String
                Status = Me.ComboStatus.Text
                Select Case Status
                    Case "<  >"
                        Status = "<  >"
                    Case "PREPARED"
                        Status = "PREP"
                    Case "CALCULATED"
                        Status = "CALC"
                    Case "POSTED"
                        Status = "POST"
                End Select
                'CType(Me.Owner, FrmPayroll1).DG1.Item(Me.CurrentOwnerColumn, 0).Value = Status
                Try
                    CType(Me.Owner, FrmPayroll1).MyDs.Tables(0).Rows(Me.CurrentOwnerColumn).Item(0) = Status
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub


    Private Sub FrmPrTxCalculatePayroll_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = Tls12
        If Global1.UserRole = Roles.Admin Or Global1.UserRole = Roles.Manager Then
            'If UCase(Global1.UserName) = "SA" Or UCase(Globadl1.UserName) = "NODAL" Then
            Me.TSBAdminTool.Visible = True
            Me.TsbSystem.Visible = True
            Me.BtnPrintIR59.Visible = True
        Else
            Me.TSBAdminTool.Visible = False
            Me.TsbSystem.Visible = False
            Me.BtnPrintIR59.Visible = False
        End If

        Me.CBAllowNegativeTax.Checked = Global1.PARAM_Allow_NegativeTAX
        If Global1.PARAM_TaxRule = "16.67" Then
            Me.Label80.Text = "One Sixth Rule (SI+PF+MF+LI+GeSY)"
        Else
            Me.Label80.Text = "One Fifth Rule (SI+PF+MF+LI+GeSY)"
        End If
        Me.LblPFLimit.Text = "PF Limit " & PARAM_PFLimit & " % "
        Me.lblMFLimit.Text = "MF Limit " & PARAM_MFLimit & " % "

        Me.lblOverTime1.Text = "Overtime 1 (x" & Format(Parameters.OverTime_Rate1, "0.00") & ")"
        Me.lblOverTime2.Text = "Overtime 2 (x" & Format(Parameters.OverTime_Rate2, "0.00") & ")"
        Me.lblOverTime3.Text = "Overtime 3 (x" & Format(Parameters.OverTime_Rate3, "0.00") & ")"



    End Sub
    Public Sub Initializeme(ByVal mystatus As String)
        Me.Top = 0
        Me.Left = 0
        LoadComboStatus()
        LoadComboInterfaceStatus()
        InitTextBoxes()
        InitArray_Ern()
        InitArray_E_Final()
        InitArray_Ded()
        InitArray_D_Final()
        InitArray_Con()
        InitArray_C_Final()
        ClearMe()
        FixStatus(mystatus)

    End Sub

    Public Sub CalculateSalaryPerUnits()
        Try
            Me.txtSalaryPerUnit.Text = "0.00"

            If GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
                Dim Units As Double
                Units = Me.txtActualUnits.Text

                Me.txtSalaryPerUnit.Text = Format(RoundMe3((Me.XSalary / Units), 2), "0.00")



                ' If GLBEmployee.PeriodUnits = 0 Then
                ' If Me.GLBCurrentPeriod.PeriodUnits <> 0 Then
                ' Me.txtSalaryPerUnit.Text = Format(RoundMe3(Me.XSalary / Me.GLBCurrentPeriod.PeriodUnits, 2), "0.00")
                'End If
                'Else
                'Me.txtSalaryPerUnit.Text = Format(RoundMe3(Me.XSalary / Me.GLBEmployee.PeriodUnits, 2), "0.00")
                'End If
            Else
                Me.txtSalaryPerUnit.Text = Format(RoundMe3(Me.XSalary, "0.00"))
            End If


        Catch ex As Exception
            Me.txtSalaryPerUnit.Text = "0.00"
        End Try

    End Sub
    Private Sub LoadComboStatus()
        With Me.ComboStatus
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("<  >")
            .Items.Add("PREPARED")
            .Items.Add("CALCULATED")
            .Items.Add("POSTED")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadComboInterfaceStatus()
        With Me.ComboInterfaceStatus
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("OUTSTANDING")
            .Items.Add("POSTED")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub InitTextBoxes()
        AddHandler txtActualUnits.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtActualUnits.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtOvertime1.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtOvertime1.Leave, AddressOf Utils.NumericOnLeaveWithNegative

        AddHandler txtOvertime2.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtOvertime2.Leave, AddressOf Utils.NumericOnLeaveWithNegative

        AddHandler txtOvertime3.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtOvertime3.Leave, AddressOf Utils.NumericOnLeaveWithNegative

        AddHandler txtSILeaveUnits.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtSILeaveUnits.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtSectors.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtSectors.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtDutyHours.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtDutyHours.Leave, AddressOf Utils.NumericOnLeave

        AddHandler TxtFlightHours.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler TxtFlightHours.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtCommission.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtCommission.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtOverLay.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtOverLay.Leave, AddressOf Utils.NumericOnLeave


        AddHandler txtAnnualUnits.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtAnnualUnits.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtTotalEarnings.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtTotalEarnings.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtTotalDeductions.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtTotalDeductions.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtTotalContributions.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtTotalContributions.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtNetSalary.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtNetSalary.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtSalaryPerUnit.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtSalaryPerUnit.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtUnitsToCalc.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtUnitsToCalc.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtNetToBe.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtNetToBe.Leave, AddressOf Utils.NumericOnLeave

        AddHandler txtFixedGesyD.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtFixedGesyD.Leave, AddressOf Utils.NumericOnLeaveWithNegative

        AddHandler txtFixedGesyC.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtFixedGesyC.Leave, AddressOf Utils.NumericOnLeaveWithNegative

        AddHandler txtUpdateGesiableforSI.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtUpdateGesiableforSI.Leave, AddressOf Utils.NumericOnLeaveWithNegative

    End Sub
    Private Sub ClearMe()
        Me.txtActualUnits.Text = 0
        Me.txtOvertime1.Text = 0
        Me.txtOvertime2.Text = 0
        Me.txtOvertime3.Text = 0
        Me.txtSILeaveUnits.Text = 0
        Me.txtTotalEarnings.Text = 0
        Me.txtTotalDeductions.Text = 0
        Me.txtTotalContributions.Text = 0
        Me.txtNetSalary.Text = 0
        Me.txtGrossToBe.Text = 0.0
        Me.txtNetToBe.Text = 0.0


        Me.txtSectors.Text = 0.0
        Me.txtDutyHours.Text = 0.0
        Me.TxtFlightHours.Text = 0.0
        Me.txtCommission.Text = 0.0
        Me.txtPBAmount.Text = 0.0
        Me.txtPBRate.Text = 0.0

        Me.txtFixedGesyD.Text = 0.0
        Me.txtFixedGesyC.Text = 0.0
        Me.txtUpdateGesiableforSI.Text = 0.0

        Me.txtTempstatus.Text = ""
        ClearEDC()
        CLEARIR59()
    End Sub
    Private Sub ClearIR59()
        txtROTotalTaxable.Text = "0.00"
        txtCPTotalTaxable.Text = "0.00"
        txtRODI.Text = "0.00"
        txtCPDI.Text = "0.00"
        txtROFE.Text = "0.00"
        txtCPFE.Text = "0.00"
        txtRODec.Text = "0.00"
        txtCPDec.Text = "0.00"
        txtROPenF.Text = "0.00"
        txtCPPenF.Text = "0.00"
        txtROXO.Text = "0.00"
        txtCPXO.Text = "0.00"
        txtROUnion.Text = "0.00"
        txtCPUnion.Text = "0.00"
        txtROLI.Text = "0.00"
        txtCPLI.Text = "0.00"
        txtROPF.Text = "0.00"
        txtCPPF.Text = "0.00"
        txtRPFLimit.Text = "0.00"
        txtCPFLimit.Text = "0.00"
        txtROSI.Text = "0.00"
        txtCPSI.Text = "0.00"
        txtROMF.Text = "0.00"
        txtCPMF.Text = "0.00"
        txtRmedLimit.Text = "0.00"
        txtCMedLimit.Text = "0.00"
        txtRtotalSIPFMFLI.Text = "0.00"
        txtCTotalSIPFMFLI.Text = "0.00"
        txtROonesixt.Text = "0.00"
        txtCPOnesixt.Text = "0.00"
        txtORtaxableearnings.Text = "0.00"
        txtCPtaxableearnings.Text = "0.00"
        txtORTotalTax.Text = "0.00"
        txtCPTotalTax.Text = "0.00"
        txtORPaidTax.Text = "0.00"
        txtCPPaidTax.Text = "0.00"
        txtORRemainingTax.Text = "0.00"
        txtCPRemainingTax.Text = "0.00"
        txtORPeriodTax.Text = "0.00"
        txtCPPeriodTax.Text = "0.00"
        txtORRemTaxPeriods.Text = "0.00"
        txtORPeriodUnitsRatio.Text = "0.00"
        txtORDifference.Text = "0.00"
        txtFinalPeriodTax.Text = "0.00"

        Me.txtRO_BIK_GESI.Text = "0.00"
        Me.txtROGesi.Text = "0.00"

        Me.txtCP_BIK_GESI.Text = "0.00"
        Me.txtCPGesi.Text = "0.00"

        Me.txtRGesyLimit.Text = "0.00"
        Me.txtCGesyLimit.Text = "0.00"



    End Sub
    Public Sub LoadMe()
        Me.txtEmpCode.Text = GLBEmployee.Code
        Me.txtEmpFullName.Text = GLBEmployee.FullName
    End Sub
    Private Sub InitArray_Ern()
        Ern(0) = Me.E_Pay1
        Ern(1) = Me.E_Pay2
        Ern(2) = Me.E_Pay3
        Ern(3) = Me.E_Pay4
        Ern(4) = Me.E_Pay5
        Ern(5) = Me.E_Pay6
        Ern(6) = Me.E_Pay7
        Ern(7) = Me.E_Pay8
        Ern(8) = Me.E_Pay9
        Ern(9) = Me.E_Pay10
        Ern(10) = Me.E_Pay11
        Ern(11) = Me.E_Pay12
        Ern(12) = Me.E_Pay13
        Ern(13) = Me.E_Pay14
        Ern(14) = Me.E_Pay15
    End Sub
    Private Sub InitArray_E_Final()
        E_Final(0) = Me.E_Final1
        E_Final(1) = Me.E_Final2
        E_Final(2) = Me.E_Final3
        E_Final(3) = Me.E_Final4
        E_Final(4) = Me.E_Final5
        E_Final(5) = Me.E_Final6
        E_Final(6) = Me.E_Final7
        E_Final(7) = Me.E_Final8
        E_Final(8) = Me.E_Final9
        E_Final(9) = Me.E_Final10
        E_Final(10) = Me.E_Final11
        E_Final(11) = Me.E_Final12
        E_Final(12) = Me.E_Final13
        E_Final(13) = Me.E_Final14
        E_Final(14) = Me.E_Final15
    End Sub

    Private Sub InitArray_Ded()
        Ded(0) = Me.D_Pay1
        Ded(1) = Me.D_Pay2
        Ded(2) = Me.D_Pay3
        Ded(3) = Me.D_Pay4
        Ded(4) = Me.D_Pay5
        Ded(5) = Me.D_Pay6
        Ded(6) = Me.D_Pay7
        Ded(7) = Me.D_Pay8
        Ded(8) = Me.D_Pay9
        Ded(9) = Me.D_Pay10
        Ded(10) = Me.D_Pay11
        Ded(11) = Me.D_Pay12
        Ded(12) = Me.D_Pay13
        Ded(13) = Me.D_Pay14
        Ded(14) = Me.D_Pay15
    End Sub
    Private Sub InitArray_D_Final()
        D_Final(0) = Me.D_Final1
        D_Final(1) = Me.D_Final2
        D_Final(2) = Me.D_Final3
        D_Final(3) = Me.D_Final4
        D_Final(4) = Me.D_Final5
        D_Final(5) = Me.D_Final6
        D_Final(6) = Me.D_Final7
        D_Final(7) = Me.D_Final8
        D_Final(8) = Me.D_Final9
        D_Final(9) = Me.D_Final10
        D_Final(10) = Me.D_Final11
        D_Final(11) = Me.D_Final12
        D_Final(12) = Me.D_Final13
        D_Final(13) = Me.D_Final14
        D_Final(14) = Me.D_Final15
    End Sub
    Private Sub InitArray_Con()
        Con(0) = Me.C_Pay1
        Con(1) = Me.C_Pay2
        Con(2) = Me.C_Pay3
        Con(3) = Me.C_Pay4
        Con(4) = Me.C_Pay5
        Con(5) = Me.C_Pay6
        Con(6) = Me.C_Pay7
        Con(7) = Me.C_Pay8
        Con(8) = Me.C_Pay9
        Con(9) = Me.C_Pay10
        Con(10) = Me.C_Pay11
        Con(11) = Me.C_Pay12
        Con(12) = Me.C_Pay13
        Con(13) = Me.C_Pay14
        Con(14) = Me.C_Pay15
    End Sub
    Private Sub InitArray_C_Final()
        C_Final(0) = Me.C_Final1
        C_Final(1) = Me.C_Final2
        C_Final(2) = Me.C_Final3
        C_Final(3) = Me.C_Final4
        C_Final(4) = Me.C_Final5
        C_Final(5) = Me.C_Final6
        C_Final(6) = Me.C_Final7
        C_Final(7) = Me.C_Final8
        C_Final(8) = Me.C_Final9
        C_Final(9) = Me.C_Final10
        C_Final(10) = Me.C_Final11
        C_Final(11) = Me.C_Final12
        C_Final(12) = Me.C_Final13
        C_Final(13) = Me.C_Final14
        C_Final(14) = Me.C_Final15
    End Sub
    Public Sub ClearEDC()
        Dim i As Integer
        Dim k As Integer
        Dim Ds As DataSet
        Dim TempCode As String = ""
        Dim Found As Boolean = False
        Dim counter As Integer = 0
        'Earnings
        For i = 0 To Me.Ern.Length - 1
            Ern(i).ClearMe()
        Next
        For i = 0 To Me.E_Final.Length - 1
            E_Final(i).ClearMe()
        Next
        'Deductions
        counter = 0
        For i = 0 To Me.Ded.Length - 1
            Ded(i).ClearMe()
        Next
        For i = 0 To Me.D_Final.Length - 1
            D_Final(i).ClearMe()
        Next
        'Contributions
        counter = 0
        For i = 0 To Me.Con.Length - 1
            Con(i).ClearMe()
        Next
        For i = 0 To Me.C_Final.Length - 1
            C_Final(i).ClearMe()
        Next

        If GLBEmployee.Code <> "" Then
            TempCode = GLBEmployee.TemGrp_Code
            counter = 0
            'Ds = Global1.Business.GetAllPrMsTemplateEarnings(TempCode)
            If CheckDataSet(GLBDsErn) Then
                For i = 0 To GLBDsErn.Tables(0).Rows.Count - 1
                    Dim E As New cPrMsTemplateEarnings(GLBDsErn.Tables(0).Rows(i))
                    Found = False
                    If CheckDataSet(DsP_Ern) Then
                        For k = 0 To Me.DsP_Ern.Tables(0).Rows.Count - 1
                            If E.ErnCodCode = DbNullToString(DsP_Ern.Tables(0).Rows(k).Item(2)) Then
                                Found = True
                                Exit For
                            End If
                        Next
                    End If
                    If Found Then
                        Ern(counter).Ern = E
                        Ern(counter).LoadME()
                        E_Final(counter).Earn = E
                        E_Final(counter).LoadMe()
                        counter = counter + 1
                    End If
                Next
            End If

            'Ds = Global1.Business.GetAllPrMsTemplateDeductions(TempCode)
            If CheckDataSet(GLBDsDed) Then
                For i = 0 To GLBDsDed.Tables(0).Rows.Count - 1
                    Dim D As New cPrMsTemplateDeductions(GLBDsDed.Tables(0).Rows(i))
                    Found = False
                    If CheckDataSet(DSP_Ded) Then
                        For k = 0 To Me.DSP_Ded.Tables(0).Rows.Count - 1
                            If D.DedCodCode = DbNullToString(DSP_Ded.Tables(0).Rows(k).Item(2)) Then
                                Found = True
                                Exit For
                            End If
                        Next
                    End If
                    If Found Then
                        Ded(counter).Ded = D
                        Ded(counter).LoadMe()
                        D_Final(counter).Ded = D
                        D_Final(counter).LoadMe()
                        counter = counter + 1
                    End If

                Next
            End If

            'Ds = Global1.Business.GetAllPrMsTemplateContributions(TempCode)
            If CheckDataSet(GLBDsCon) Then
                For i = 0 To GLBDsCon.Tables(0).Rows.Count - 1
                    Dim C As New cPrMsTemplateContributions(GLBDsCon.Tables(0).Rows(i))
                    Found = False
                    If CheckDataSet(DSP_Con) Then
                        For k = 0 To Me.DSP_Con.Tables(0).Rows.Count - 1
                            If C.ConCodCode = DbNullToString(DSP_Con.Tables(0).Rows(k).Item(2)) Then
                                Found = True
                                Exit For
                            End If
                        Next
                    End If
                    If Found Then
                        Con(counter).Con = C
                        Con(counter).LoadMe()
                        C_Final(counter).Con = C
                        C_Final(counter).LoadMe()
                        counter = counter + 1
                    End If
                Next
            End If
        End If
    End Sub

#Region "Earnings Calculations"
    Private Function FindSalary() As Double
        Dim Salary As Double = 0
        Dim Emp As cPrMsEmployees
        Emp = Me.GLBEmployee

        Dim i As Integer
        For i = 0 To Me.Ern.Length - 1
            If Not Ern(i).Ern Is Nothing Then
                Dim EE As New cPrMsEmployeeEarnings(Emp.Code, Ern(i).Ern.ErnCodCode)
                Dim Earn As New cPrMsEarningCodes(Ern(i).Ern.ErnCodCode)
                Select Case Earn.ErnTypCode
                    Case "SA" 'SALARY - F
                        Salary = CDbl(Me.E_Final(i).txtValue.Text)
                End Select
            End If
        Next
        Return Salary
    End Function
    Private Sub CalculateEarnings(ByVal Emp As cPrMsEmployees, ByVal OnlyRecuringEarnings As Boolean)
        Dim i As Integer
        If Not OnlyRecuringEarnings Then
            For i = 0 To Me.Ern.Length - 1
                If Not Ern(i).Ern Is Nothing Then
                    Dim EE As New cPrMsEmployeeEarnings(Emp.Code, Ern(i).Ern.ErnCodCode)
                    Dim Earn As New cPrMsEarningCodes(Ern(i).Ern.ErnCodCode)
                    Select Case Earn.ErnTypCode
                        Case "3A" '13 SALARY
                            E_13Salary(Emp, EE, Earn)
                        Case "3E" '13 SALARY ESTIMATE
                            E_Calculate13Estimate(Emp, EE, Earn)
                        Case "4A" '14 SALARY
                            E_14Salary(Emp, EE, Earn)
                        Case "4E" '14 SALARY ESTIMATE
                            E_Calculate14Estimate(Emp, EE, Earn)
                        Case "AR" 'ARREARS
                            E_CalculateArrears(Emp, EE, Earn)
                        Case "OT" 'OVERTIME - F
                            E_CalculateOverTime(Emp, EE, Earn)
                        Case "SA" 'SALARY - F
                            E_CalculateSalary(Emp, EE, Earn, OnlyRecuringEarnings)
                        Case "SI" 'SOCIAL INSURANCE LEAVE
                            E_CalculateSILeave(Emp, EE, Earn, False)
                        Case "OE" 'F
                            E_CalculateOtherEarnings(Emp, EE, Earn)
                        Case "AL" 'ANNUAL LEAVE WHEN EMP IS LEAVING
                            E_CalculateAnnualLeave(Emp, EE, Earn)
                        Case "UM" 'Unit Measure
                            E_CalculateMesuareUnits(Emp, EE, Earn)
                        Case "LP" 'Annual Leave Earning
                            E_CalculateAnnualLeaveProvision(Emp, EE, Earn)
                        Case "SE" 'SECTORS
                            E_CalculateSectors(Emp, EE, Earn)
                        Case "DH" 'Duty Hours
                            E_CalculateDutyHours(Emp, EE, Earn)
                        Case "FH" 'Flight Hours
                            E_CalculateFlightHours(Emp, EE, Earn)
                        Case "PB" 'PerformanceBonus
                            E_CalculatePerformanceBonus(Emp, EE, Earn)
                        Case "CO" 'Sales Commission
                            E_CalculateSalesCommission(Emp, EE, Earn)
                        Case "OV" 'Sales Commission
                            E_CalculateOverLay(Emp, EE, Earn)
                        Case "TO" 'TimeOff
                            E_CalculateTimeOff(Emp, EE, Earn)
                        Case "LL" 'Anual Leave LL
                            E_CalculateAnualLeaveLL(Emp, EE, Earn)
                        Case "O1" 'OverTime1
                            E_CalculateOverTime1(Emp, EE, Earn)
                        Case "O2" 'OverTime2
                            E_CalculateOverTime2(Emp, EE, Earn)
                        Case "O3" 'OverTime3
                            E_CalculateOverTime3(Emp, EE, Earn)
                        Case "CL" 'COLA
                            tempEE_13 = EE
                            tempEarn_13 = Earn
                            tempEE_14 = EE
                            tempEarn_14 = Earn
                            E_CalculateCOLA(Emp, EE, Earn, 0, False, False)
                        Case "BK" 'BENEFITS IN KIND
                            E_CalculateBenefitsInKind(Emp, EE, Earn)
                        Case "BR" 'RECURRING BENEFITS IN KIND
                            E_CalculateBenefitsInKindRecurring(Emp, EE, Earn)
                        Case "B2" 'RECURRING BENEFITS IN KIND 14
                            E_CalculateBenefitsInKindRecurring_14(Emp, EE, Earn)
                        Case "RE" 'RECURRING EARNING
                            E_CalculateRecurringEarning(Emp, EE, Earn)
                        Case "R2" 'RECURRING EARNING
                            E_CalculateRecurringEarning14(Emp, EE, Earn)

                        Case "PD" 'Pension Deduction
                            E_CalculatePensionDeduction(Emp, EE, Earn)
                        Case "RN" 'Recuring Negative
                            E_CalculateRecuringNegative(Emp, EE, Earn)
                        Case "FI" 'Recuring Negative
                            E_CalculateFishes(Emp, EE, Earn)
                        Case "FN"
                            E_CalculateFines(Emp, EE, Earn)
                        Case "DF" 'Director Fees
                            E_CalculateDirectorFees(Emp, EE, Earn)
                        Case "TP" 'TimeOff
                            E_CalculateTimeOffPositive(Emp, EE, Earn)
                    End Select
                   
                End If
            Next
            If HASSeparateCOLA Then
                GLBCOLAValue = 0
                'E_CalculateCOLA(Emp, tempEE_13, tempEarn_13, RoundMe3(13SalaryForCOLA + GLBArrearsForCOLA, 2))
                E_CalculateCOLA(Emp, tempEE_13, tempEarn_13, RoundMe3(GLBArrearsForCOLA, 2), False, False)
            End If
            Dim TotalE As Double
            TotalE = CalculateTotalEarnings()
            Me.txtTotalEarnings.Text = Format(RoundMe2(TotalE, 2), "0.00")
        Else
            For i = 0 To Me.Ern.Length - 1
                If Not Ern(i).Ern Is Nothing Then
                    Dim EE As New cPrMsEmployeeEarnings(Emp.Code, Ern(i).Ern.ErnCodCode)
                    Dim Earn As New cPrMsEarningCodes(Ern(i).Ern.ErnCodCode)
                    Select Case Earn.ErnTypCode
                        Case "SA" 'SALARY - F
                            E_CalculateSalary(Emp, EE, Earn, OnlyRecuringEarnings)
                        Case "SI" 'SOCIAL INSURANCE LEAVE
                            E_CalculateSILeave(Emp, EE, Earn, OnlyRecuringEarnings)
                        Case "CL" 'COLA
                            tempEE_13 = EE
                            tempEarn_13 = Earn
                            E_CalculateCOLA(Emp, EE, Earn, 0, False, False)
                        Case "BR" 'RECURRING BENEFITS IN KIND
                            E_CalculateBenefitsInKindRecurring(Emp, EE, Earn)
                        Case "B2" 'RECURRING BENEFITS IN KIND 14
                            E_CalculateBenefitsInKindRecurring_14(Emp, EE, Earn)
                       
                        Case "RE" 'RECURRING EARNING
                            E_CalculateRecurringEarning(Emp, EE, Earn)
                        Case "R2" 'RECURRING EARNING 14
                            E_CalculateRecurringEarning14(Emp, EE, Earn)
                        Case "PD" 'PENSION Deduction
                            E_CalculatePensionDeduction(Emp, EE, Earn)

                    End Select
                End If
            Next
            If HASSeparateCOLA Then
                GLBCOLAValue = 0
                'E_CalculateCOLA(Emp, tempEE_13, tempEarn_13, RoundMe3(GLB13SalaryForCOLA + GLBArrearsForCOLA, 2))
                E_CalculateCOLA(Emp, tempEE_13, tempEarn_13, RoundMe3(GLBArrearsForCOLA, 2), False, False)
            End If
            Dim TotalE As Double
            TotalE = CalculateTotalEarnings()
            Me.txtTotalEarnings.Text = Format(RoundMe2(TotalE, 2), "0.00")
            End If

    End Sub
    Private Sub E_CalculateSalary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal OnlyRecuring As Boolean)

        Dim Gross As Double = 0
        Dim Rate As Double = 0
        Dim Salary As Double = 0
        Dim ActualUnits As Double = 0
        Dim NormalUnits As Double = 0
        Dim OtherErnfor1314 As Double = 0
        GLBGrossSalaryForHourlyRateForTaxCalculation = 0



        Dim t13thPeriodTotalUnits As Double = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
        Dim t14thPeriodTotalUnits As Double = Global1.Business.Find14nthPeriodUnits(Me.GLBCurrentPeriod)

        ActualUnits = Me.txtActualUnits.Text
        Dim i As Integer
        '------------------------------------------------------------------------------------------------------
        'Dim k As Integer = 0
        'Dim Sal As Double = 0
        'If Me.GLBCurrentPeriod.PayCat_Code = "3" Then
        '    Dim DS3 As DataSet

        '    DS3 = Global1.Business.CalculateSalaryFor13(GLBEmployee, Me.GLBCurrentPeriod)
        '    If CheckDataSet(DS3) Then
        '        For i = 0 To DS3.Tables(0).Rows.Count - 1
        '            Sal = Sal + DbNullToDouble(DS3.Tables(0).Rows(i).Item(0))
        '            k = k + 1
        '        Next
        '        Sal = RoundMe2(Sal / k, 2)
        '    End If

        'End If
        'If Me.GLBCurrentPeriod.PayCat_Code = "4" Then
        '    Dim DS4 As DataSet
        '    DS4 = Global1.Business.CalculateSalaryFor14(GLBEmployee, Me.GLBCurrentPeriod)
        '    If CheckDataSet(DS4) Then
        '        For i = 0 To DS4.Tables(0).Rows.Count - 1
        '            Sal = Sal + DbNullToDouble(DS4.Tables(0).Rows(i).Item(0))
        '        Next
        '        Sal = RoundMe2(Sal / k, 2)
        '    End If
        'End If
        '----------------------------------------------------------------------------------------------------

        GlbEmpSalary = Global1.Business.GetCurrentSalary(Me.GLBEmployee.Code, Me.GLBCurrentPeriod.DateTo)
        GlbSalary1 = 0
        GlbSalary2 = 0
        If Global1.PARAM_Salary_1_2 Then
            GlbSalary1 = GlbEmpSalary.Basic
            GlbSalary2 = GlbEmpSalary.Cola
        End If

        Gross = GlbEmpSalary.SalaryValue
        If TryingToFindNetToGross Then
            Gross = Me.txtGrossToBe.Text
            GlbEmpSalary.SalaryValue = Gross
        End If

        If Emp.Cur_Code <> GLBCompany.CurSymbol Then
            Gross = RoundMe2(Gross * CurRate, 2)
        End If
        If GLBReverseCalc Then
            Gross = Me.txtGrossToBe.Text
        End If

        'End If

        If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
            'Hourly
            RateForOvertimeCalc = Gross
            Rate = Gross
            Salary = RoundMe3(Rate * ActualUnits, 2)
            If PARAM_HourlyAsSalaryForTax Then
                GLBGrossSalaryForHourlyRateForTaxCalculation = Salary
            End If
            OvertimeRateofCOLA = GLBLimits.Cola / 100 * Gross

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
                GLBAgreedSalary = RoundMe3((Emp.AgreedSalary / NormalUnits) * ActualUnits, 2)
                If CaclulateMyRateInDays Then
                    Dim TotalUnitsInMonth As Double
                    TotalUnitsInMonth = TotalWorkDaysOfMonth * 8
                    Salary = RoundMe3((Gross / TotalUnitsInMonth) * ActualUnits, 2)

                End If
                'RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
                RateForOvertimeCalc = Gross / NormalUnits
                OvertimeRateofCOLA = GLBLimits.Cola / 100 * Gross
                GrossFor13AND14Calc = Gross

                If Global1.PARAM_OvertimeRate_BasedOndays Then
                    RateForOvertimeCalc = (Gross / Global1.PARAM_OvertimeRate_monthdays) / Me.GLBTemplateGroup.DayUnits
                End If

                '*********    SALARY EXTRA BONUS

                'If Not OnlyRecuring Then
                Salary = Salary + Emp.BonusOnsalary
                'End If
                '*********    SALARY EXTRA BONUS

                '-----------------------------------------------------------------------------------------------------
                'Average Salary Calculation for 13 and 14
                '-----------------------------------------------------------------------------------------------------
                If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                    If t13thPeriodTotalUnits <> 0 Or t14thPeriodTotalUnits <> 0 Then
                        If Global1.PARAM_Average_13_14 Then
                            Dim j As Integer
                            Dim k As Integer = 0
                            Dim Sal As Double = 0
                            If t13thPeriodTotalUnits <> 0 Then
                                Dim DS3 As DataSet
                                DS3 = Global1.Business.CalculateSalaryFor13(Emp, Me.GLBCurrentPeriod)
                                If CheckDataSet(DS3) Then
                                    For j = 0 To DS3.Tables(0).Rows.Count - 1
                                        Sal = Sal + DbNullToDouble(DS3.Tables(0).Rows(j).Item(0))
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
                                        Next
                                    End If
                                    '----------------------------------------------
                                    'End of Other Earnings 
                                    '----------------------------------------------

                                    Sal = RoundMe2((Sal + OtherErnfor1314) / k, 2)
                                    'Sal = Sal + OtherErnfor1314
                                    If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                                        Gross = Sal
                                        Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
                                    End If
                                End If
                            End If
                            If t14thPeriodTotalUnits <> 0 Then
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
                                            OtherErnfor1314 = RoundMe2(OtherErnfor1314 + Ernx / c, 2)
                                            c = 0
                                            Ernx = 0
                                        Next
                                    End If
                                    '----------------------------------------------
                                    'End of Other Earnings 
                                    '----------------------------------------------


                                    Sal = RoundMe2(Sal / k, 2)
                                    Sal = Sal + OtherErnfor1314
                                    If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                                        Gross = Sal
                                        Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If Global1.PARAM_Average_13_14 Then
                            Dim j As Integer
                            Dim k As Integer = 0
                            Dim Sal As Double = 0
                            Dim DS3 As DataSet
                            DS3 = Global1.Business.CalculateSalaryFor13(Emp, Me.GLBCurrentPeriod)
                            If CheckDataSet(DS3) Then
                                For j = 0 To DS3.Tables(0).Rows.Count - 1
                                    Sal = Sal + DbNullToDouble(DS3.Tables(0).Rows(j).Item(0))
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
                                    Next
                                End If
                                '----------------------------------------------
                                'End of Other Earnings 
                                '----------------------------------------------

                                Sal = RoundMe2((Sal + OtherErnfor1314) / k, 2)

                                'Sal = Sal + OtherErnfor1314
                                If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                                    Gross = Sal
                                    GrossFor13AND14Calc = Gross
                                End If
                            End If

                        End If
                    End If
                    '-----------------------------------------------------------------------------------------------------
                    'END OF Average Salary Calculation for 13 and 14
                    '-----------------------------------------------------------------------------------------------------
                End If

                If t13thPeriodTotalUnits <> 0 Then
                    GrossDIVNormalUnitsForCalc13 = Gross / t13thPeriodTotalUnits
                End If
                If t14thPeriodTotalUnits <> 0 Then
                    GrossDIVNormalUnitsForCalc14 = Gross / t14thPeriodTotalUnits
                End If
            Else
                Salary = 0
                RateForOvertimeCalc = 0
                GrossFor13AND14Calc = Gross
                GrossDIVNormalUnitsForCalc13 = 0
                GrossDIVNormalUnitsForCalc14 = 0

            End If
        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Contract_Code Then
            'contract
            NormalUnits = Me.GLBEmployee.PeriodUnits
            If NormalUnits = 0 Then
                Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
                RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
                GrossFor13AND14Calc = Gross

                '-----------------------------------------------------------------------------------------------------
                'Average Salary Calculation for 13 and 14
                '-----------------------------------------------------------------------------------------------------
                If GLBCurrentPeriod.PayCat_Code = "3" Or GLBCurrentPeriod.PayCat_Code = "4" Then
                    If t13thPeriodTotalUnits <> 0 Or t14thPeriodTotalUnits <> 0 Then
                        If Global1.PARAM_Average_13_14 Then
                            Dim j As Integer
                            Dim k As Integer = 0
                            Dim Sal As Double = 0
                            If t13thPeriodTotalUnits <> 0 Then
                                Dim DS3 As DataSet
                                DS3 = Global1.Business.CalculateSalaryFor13(Emp, Me.GLBCurrentPeriod)
                                If CheckDataSet(DS3) Then
                                    For j = 0 To DS3.Tables(0).Rows.Count - 1
                                        Sal = Sal + DbNullToDouble(DS3.Tables(0).Rows(j).Item(0))
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
                            If t14thPeriodTotalUnits <> 0 Then
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
                        End If
                    Else
                        If Global1.PARAM_Average_13_14 Then
                            Dim j As Integer
                            Dim k As Integer = 0
                            Dim Sal As Double = 0
                            Dim DS3 As DataSet
                            DS3 = Global1.Business.CalculateSalaryFor13(Emp, Me.GLBCurrentPeriod)
                            If CheckDataSet(DS3) Then
                                For j = 0 To DS3.Tables(0).Rows.Count - 1
                                    Sal = Sal + DbNullToDouble(DS3.Tables(0).Rows(j).Item(0))
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
                                    Next
                                End If
                                '----------------------------------------------
                                'End of Other Earnings 
                                '----------------------------------------------

                                Sal = RoundMe2((Sal + OtherErnfor1314) / k, 2)
                                'Sal = Sal + OtherErnfor1314
                                If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                                    Gross = Sal
                                    GrossFor13AND14Calc = Gross
                                End If
                            End If
                        End If
                    End If
                End If
                '-----------------------------------------------------------------------------------------------------
                'END OF Average Salary Calculation for 13 and 14
                '-----------------------------------------------------------------------------------------------------


                If t13thPeriodTotalUnits <> 0 Then
                    GrossDIVNormalUnitsForCalc13 = Gross / t13thPeriodTotalUnits
                End If
                If t14thPeriodTotalUnits <> 0 Then
                    GrossDIVNormalUnitsForCalc14 = Gross / t14thPeriodTotalUnits
                End If
            Else
                Salary = 0
                RateForOvertimeCalc = 0
                GrossFor13AND14Calc = Gross
                GrossDIVNormalUnitsForCalc13 = 0
                GrossDIVNormalUnitsForCalc14 = 0
            End If
        End If

        i = 0
        GLBFirstGross = Salary


        GLBSalaryForRate = GLBSalaryForRate + Salary
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Salary
                Exit For
            End If
        Next

        'Me.txtSalary.Text = Format(Salary, "0.00")
    End Sub


    Private Sub E_CalculateTimeOff(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim TimeOff As Double = 0
        Dim hours As Double = 0


        Dim UseThisRate As Double = 0
        If Global1.PARAM_OvertimeRate_BasedOnSalary2 Then
            UseThisRate = Me.GLBRateFromSalary2
            If UseThisRate = 0 Then
                UseThisRate = Me.RateForOvertimeCalc
            End If
        Else
            UseThisRate = Me.RateForOvertimeCalc
        End If


        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        hours = Ern(i).txtValue.Text
                        TimeOff = RoundMe3(UseThisRate * hours, 2) * -1
                        Value = TimeOff
                    ElseIf TempErn.TypeMode = "V" Then
                        hours = Ern(i).txtValue.Text
                        TimeOff = RoundMe3(UseThisRate * hours, 2) * -1
                        Value = TimeOff
                    End If
                    Exit For
                End If
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next



    End Sub
    Private Sub E_CalculateTimeOffPositive(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim TimeOff As Double = 0
        Dim hours As Double = 0


        Dim UseThisRate As Double = 0
        If Global1.PARAM_OvertimeRate_BasedOnSalary2 Then
            UseThisRate = Me.GLBRateFromSalary2
            If UseThisRate = 0 Then
                UseThisRate = Me.RateForOvertimeCalc
            End If
        Else
            UseThisRate = Me.RateForOvertimeCalc
        End If


        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        hours = Ern(i).txtValue.Text
                        TimeOff = RoundMe3(UseThisRate * hours, 2)
                        Value = TimeOff
                    ElseIf TempErn.TypeMode = "V" Then
                        hours = Ern(i).txtValue.Text
                        TimeOff = RoundMe3(UseThisRate * hours, 2)
                        Value = TimeOff
                    End If
                    Exit For
                End If
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next



    End Sub
    Private Sub E_CalculateAnualLeaveLL(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim AL As Double = 0
        Dim hours As Double = 0

        Dim UseThisRate As Double = 0
        If Global1.PARAM_OvertimeRate_BasedOnSalary2 Then
            UseThisRate = Me.GLBRateFromSalary2
            If UseThisRate = 0 Then
                UseThisRate = Me.RateForOvertimeCalc
            End If
        Else
            UseThisRate = Me.RateForOvertimeCalc
        End If


        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then

                    hours = Ern(i).txtValue.Text
                    AL = RoundMe3(UseThisRate * hours, 2)
                    Value = AL

                    Exit For
                End If
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next



    End Sub
    Private Sub E_CalculateArrears(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Arrears As Double = 0

        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
                            If Me.GlbEmpSalary.EffPayDate >= Me.GLBCurrentPeriod.DateFrom Then
                                If Me.GlbEmpSalary.EffPayDate <= Me.GLBCurrentPeriod.DateTo Then
                                    Dim NumberOfPeriods As Integer
                                    NumberOfPeriods = Global1.Business.GetNumberOfNormalPeriodsBack(GlbEmpSalary, GLBCurrentPeriod)
                                    Arrears = NumberOfPeriods * GlbEmpSalary.EmpSal_Dif
                                    If Ern(i).txtValue.Text <> 0 Then
                                        Arrears = Ern(i).txtValue.Text
                                    End If
                                End If
                            End If
                        End If

                    ElseIf TempErn.TypeMode = "V" Then
                        Arrears = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next

        ArrearsFor13AND14Calc = Arrears
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Arrears
                Exit For
            End If
        Next
        If Me.HASSeparateCOLA Then
            GLBArrearsForCOLA = Arrears
        End If
        If Global1.PARAM_NoCOLAOnArrears Then
            GLBArrearsForCOLA = 0
        End If
        'Me.txtarrears.text = Format(Arrears, "0.00")
    End Sub
    Private Sub E_13Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t13Salary As Double = 0
        Dim ActualUnits As Double = Me.txtActualUnits.Text
        Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
        Dim PeriodAnnualUnits As Double = Me.txtAnnualUnits.Text

        Dim SumOfAnuallUnitOfNormalPeriods As Double
        Dim AnuallUnitsOfThisPeriod As Double = 0
        Dim ALTaken As Double = 0
        Dim ALForYear As Double = 0
        Dim i As Integer
        Dim NormalPeriods As Integer = 0
        Dim Dif As Double = 0
        Dim ALAllowed As Double = 0
        Dim NormalPeriodsUntilNow As Integer = 0
        Dim CF As Double
        Dim Tempern As New cPrMsTemplateEarnings
        Dim Manually As Boolean = False

        If Emp.TerminateDate <> "" Then
            If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                For i = 0 To Ern.Length - 1
                    If Earn.Code = Ern(i).Ern.ErnCodCode Then
                        Tempern = Ern(i).Ern
                        If Tempern.ErnCodCode <> "" Then
                            If Ern(i).txtValue.Text <> 0 Then
                                If Ern(i).txtValue.Text = -1 Then
                                    t13Salary = 0
                                    Manually = True
                                Else
                                    t13Salary = Ern(i).txtValue.Text
                                    manually = True
                                End If
                            End If
                        End If
                        Exit For
                    End If
                Next
                If not manually then

                    'AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits
                    AnuallUnitsOfThisPeriod = PeriodAnnualUnits

                    NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow

                    SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsForX(Me.GLBCurrentPeriod, Emp.Code)

                    ALForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
                    ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
                    CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
                    NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods

                    ALAllowed = ALForYear * ((NormalPeriodsUntilNow + 1) / NormalPeriods)
                    Dif = ALAllowed - ALTaken
                    Dim AnnualLeave As Double
                    't13Salary = GrossDIVNormalUnitsForCalc13 * ((SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod + Dif + CF))
                    If Not Global1.Business.Is13nthcalculated(Me.GLBCurrentPeriod, Me.GLBEmployee.Code) Then
                        t13Salary = GrossDIVNormalUnitsForCalc13 * ((SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod))
                    End If

                    AnnualLeave = (Dif + CF) * RateForOvertimeCalc
                    't13Salary = t13Salary + AnnualLeave 'SAVVAS WHEN ANNUAL LEAVE WAS CREATED
                    t13Salary = t13Salary
                End If
            End If
        End If
        If Not Manually Then
            If HASSeparateCOLA Then
                'GLBCOLAValue = 0
                GLBAdditionTo13 = 0
                E_CalculateCOLA(Emp, tempEE_13, tempEarn_13, RoundMe3(t13Salary, 2), True, False)
                t13Salary = t13Salary + GLBAdditionTo13
            End If
        End If

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = RoundMe3(t13Salary, 2)
                Exit For
            End If
        Next
        'If HASSeparateCOLA Then
        '    'GLBCOLAValue = 0
        '    'E_CalculateCOLA(Emp, tempEE_13, tempEarn_13, RoundMe3(t13Salary, 2))
        '    GLB13SalaryForCOLA = t13Salary
        'End If
    End Sub
    Private Sub E_14Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        'Dim t14Salary As Double = 0
        'Dim ActualUnits As Double = Me.txtActualUnits.Text
        'Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
        'Dim SumOfAnuallUnitOfNormalPeriods As Double
        'Dim AnuallUnitsOfThisPeriod As Double = 0
        'Dim i As Integer
        'Dim ALTaken As Double = 0
        'Dim ALForYear As Double = 0
        'Dim NormalPeriods As Integer = 0
        'Dim Dif As Double = 0
        'Dim ALAllowed As Double = 0
        'Dim NormalPeriodsUntilNow As Integer = 0
        'Dim CF As Double = 0

        'If Emp.TerminateDate <> "" Then
        '    If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
        '        AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

        '        NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow

        '        SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

        '        ALForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
        '        ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
        '        CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
        '        NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods

        '        ALAllowed = ALForYear * ((NormalPeriodsUntilNow + 1) / NormalPeriods)
        '        Dif = ALAllowed - ALTaken

        '        t14Salary = GrossDIVNormalUnitsForCalc14 * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod + Dif + CF)
        '    End If
        'End If
        'For i = 0 To E_Final.Length - 1
        '    If Earn.Code = E_Final(i).Earn.ErnCodCode Then
        '        E_Final(i).MyValue = RoundMe3(t14Salary, 2)
        '        Exit For
        '    End If
        'Next


        Dim t14Salary As Double = 0
        Dim ActualUnits As Double = Me.txtActualUnits.Text
        Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
        Dim SumOfAnuallUnitOfNormalPeriods As Double
        Dim AnuallUnitsOfThisPeriod As Double = 0
        Dim ALTaken As Double = 0
        Dim ALForYear As Double = 0
        Dim i As Integer
        Dim NormalPeriods As Integer = 0
        Dim Dif As Double = 0
        Dim ALAllowed As Double = 0
        Dim NormalPeriodsUntilNow As Integer = 0
        Dim CF As Double
        Dim Manually As Boolean = False
        Dim Tempern As New cPrMsTemplateEarnings

        If Emp.TerminateDate <> "" Then
            If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                For i = 0 To Ern.Length - 1
                    If Earn.Code = Ern(i).Ern.ErnCodCode Then
                        Tempern = Ern(i).Ern
                        If Tempern.ErnCodCode <> "" Then
                            If Ern(i).txtValue.Text <> 0 Then
                                If Ern(i).txtValue.Text = -1 Then
                                    t14Salary = 0
                                    Manually = True
                                Else
                                    t14Salary = Ern(i).txtValue.Text
                                    Manually = True
                                End If
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        End If

        If Not Manually Then

            If Emp.TerminateDate <> "" Then

                If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                    Dim Period14nthSequence = Global1.Business.Get14nthPeriodSequence(GLBCurrentPeriod)
                    If Period14nthSequence >= GLBCurrentPeriod.Sequence Then
                        AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

                        NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow

                        SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsForX(Me.GLBCurrentPeriod, Emp.Code)

                        ALForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
                        ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
                        CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
                        NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods

                        ALAllowed = ALForYear * ((NormalPeriodsUntilNow + 1) / NormalPeriods)
                        Dif = ALAllowed - ALTaken
                        Dim AnnualLeave As Double
                        't13Salary = GrossDIVNormalUnitsForCalc13 * ((SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod + Dif + CF))
                        t14Salary = GrossDIVNormalUnitsForCalc14 * ((SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod))

                        AnnualLeave = (Dif + CF) * RateForOvertimeCalc
                        't13Salary = t13Salary + AnnualLeave 'SAVVAS WHEN ANNUAL LEAVE WAS CREATED
                        t14Salary = t14Salary
                    Else

                        Dim TotalAnnualUnitsOf14 As Double = 0
                        TotalAnnualUnitsOf14 = Global1.Business.Get14nthTotalAnnualUnits(GLBCurrentPeriod)
                        AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits
                        NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow
                        SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsForX(Me.GLBCurrentPeriod, Emp.Code)
                        ALForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
                        ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
                        CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
                        NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods
                        ALAllowed = ALForYear * ((NormalPeriodsUntilNow + 1) / NormalPeriods)
                        Dif = ALAllowed - ALTaken
                        Dim AnnualLeave As Double
                        't13Salary = GrossDIVNormalUnitsForCalc13 * ((SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod + Dif + CF))
                        't14Salary = GrossDIVNormalUnitsForCalc14 * ((SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod))
                        Dim CalcUnits As Double

                        CalcUnits = (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod) - TotalAnnualUnitsOf14
                        t14Salary = GrossDIVNormalUnitsForCalc14 * CalcUnits
                        AnnualLeave = (Dif + CF) * RateForOvertimeCalc
                        't13Salary = t13Salary + AnnualLeave 'SAVVAS WHEN ANNUAL LEAVE WAS CREATED
                        t14Salary = t14Salary

                    End If
                End If
            End If
        End If

        If Not Manually Then
            If HASSeparateCOLA Then
                'GLBCOLAValue = 0
                GLBAdditionTo14 = 0
                E_CalculateCOLA(Emp, tempEE_14, tempEarn_14, RoundMe3(t14Salary, 2), False, True)
                t14Salary = t14Salary + GLBAdditionTo14
            End If
        End If

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = RoundMe3(t14Salary, 2)
                Exit For
            End If
        Next
    End Sub
    Private Sub E_Calculate13Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t13estimate As Double = 0
        Dim AnnualPeriodUnits As Double
        Dim t13thPeriodTotalUnits As Double
        Dim i As Integer
        If Emp.TerminateDate <> "" Then
            If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                t13estimate = 0
            End If
        Else
            t13thPeriodTotalUnits = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
            'AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)
            AnnualPeriodUnits = CDbl(Me.txtAnnualUnits.Text) ' + CDbl(Me.txtSILeaveUnits.Text)

            If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
                If t13thPeriodTotalUnits <> 0 Then
                    t13estimate = (Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc) * (AnnualPeriodUnits / t13thPeriodTotalUnits)
                End If
            End If
        End If

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = RoundMe3(t13estimate, 2)
                Exit For
            End If
        Next
    End Sub
    Private Function Find13nthEstimate(ByVal Emp As cPrMsEmployees) As Double
        Dim t13estimate As Double = 0
        Dim AnnualPeriodUnits As Double
        Dim t13thPeriodTotalUnits As Double

        t13thPeriodTotalUnits = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
        AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

        If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
            If t13thPeriodTotalUnits <> 0 Then
                t13estimate = (Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc) * (AnnualPeriodUnits / t13thPeriodTotalUnits)
            End If
        End If
        Return t13estimate
    End Function
    Private Sub E_Calculate14Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t14estimate As Double = 0
        Dim AnnualPeriodUnits As Double
        Dim t14thPeriodTotalUnits As Double
        Dim i As Integer

        t14thPeriodTotalUnits = Global1.Business.Find14nthPeriodUnits(Me.GLBCurrentPeriod)
        AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

        If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
            If t14thPeriodTotalUnits <> 0 Then
                t14estimate = (Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc) * (AnnualPeriodUnits / t14thPeriodTotalUnits)
            End If
        End If
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = RoundMe3(t14estimate, 2)
                Exit For
            End If
        Next
        ' Me.txt14Estimate.Text = Format(t14estimate, "0.00")
    End Sub
    Private Sub E_CalculateOtherEarnings(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim OtherIncome As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        OtherIncome = Ern(i).txtValue.Text
                        OtherIncome = OtherIncome / 100 * ValueToCalcFrom
                    ElseIf TempEarn.TypeMode = "V" Then
                        OtherIncome = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            Advances = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Advances = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Advances = 0
        '        End If
        '        Advances = Advances / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        Advances = EmpDed.MyValue
        '    End If
        'End If
        If Global1.PARAM_OverTime3ToOtherEarnings Then
            If Earn.Code = Global1.PARAM_NightShiftErnCode Then
                GlbNightShiftamount = RoundMe3(Global1.PARAM_NightShiftRate * Me.txtOvertime3.Text, 2)
                OtherIncome = OtherIncome + GlbNightShiftamount
            End If
        End If
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = OtherIncome
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateDirectorFees(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim DirectorFees As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        DirectorFees = Ern(i).txtValue.Text
                        DirectorFees = DirectorFees / 100 * ValueToCalcFrom
                    ElseIf TempEarn.TypeMode = "V" Then
                        DirectorFees = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = DirectorFees
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateFines(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Fines As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Fines = Ern(i).txtValue.Text
                        Fines = Fines / 100 * ValueToCalcFrom
                    ElseIf TempEarn.TypeMode = "V" Then
                        Fines = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Fines
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateFishes(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Fishes As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Fishes = Ern(i).txtValue.Text
                        Fishes = Fishes / 100 * ValueToCalcFrom
                    ElseIf TempEarn.TypeMode = "V" Then
                        Fishes = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Fishes
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateSILeave(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal OnlyRecuring As Boolean)
        GLBSILeave = 0
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim SILeave As Double
        Dim ValueToCalcFrom As Double



        GLBRemainingPeriodsWithSILeave = Global1.Business.GetPeriodsRemainingForThisEarningCode(Earn.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            GLBRemainingPeriodsWithSILeave = 0
        End If
        'Dim Limits As New cPrSsLimits
        'Dim Ds As DataSet

        'Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
        'If CheckDataSet(Ds) Then
        '    Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
        'Else
        '    MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        Dim Limits As New cPrSsLimits
                        Dim Ds As DataSet
                        Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                        If CheckDataSet(Ds) Then
                            Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                        Else
                            MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        '                        ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)

                        ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)



                        GlbSILeavePerc = Ern(i).txtValue.Text

                        SILeave = GlbSILeavePerc / 100 * ValueToCalcFrom

                        If SILeave > GlbSILeavePerc / 100 * Limits.InsurableMth Then
                            SILeave = GlbSILeavePerc / 100 * Limits.InsurableMth
                        End If
                    ElseIf TempEarn.TypeMode = "V" Then
                        SILeave = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            Advances = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Advances = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Advances = 0
        '        End If
        '        Advances = Advances / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        Advances = EmpDed.MyValue
        '    End If
        'End If
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = SILeave
                Exit For
            End If
        Next
        GLBSILeave = SILeave
        If OnlyRecuring Then
            GLBRecuringValueOfSILeave = SILeave
        End If
    End Sub
    Private Sub E_CalculateAnnualLeave(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
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


        Dim UseThisRate As Double = 0
        If Global1.PARAM_OvertimeRate_BasedOnSalary2 Then
            UseThisRate = Me.GLBRateFromSalary2
            If UseThisRate = 0 Then
                UseThisRate = Me.RateForOvertimeCalc
            End If
        Else
            UseThisRate = Me.RateForOvertimeCalc
        End If



        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        If Emp.TerminateDate <> "" Then
                            If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                                AlForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
                                ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
                                CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
                                NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods
                                NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow
                                Dim WorkedPeriodsUntilNow As Integer
                                WorkedPeriodsUntilNow = Global1.Business.GetNumberOfNormalWorkedPeriods(Me.GLBEmployee.Code, Me.GLBCurrentPeriod)
                                Dim NormalPeriodsForThisEmloyee As Integer = 0
                                NormalPeriodsForThisEmloyee = NormalPeriods - (NormalPeriodsUntilNow - WorkedPeriodsUntilNow)


                                'ALAllowed = AlForYear * ((NormalPeriodsUntilNow + 1) / NormalPeriods)
                                ALAllowed = AlForYear * ((WorkedPeriodsUntilNow + 1) / NormalPeriodsForThisEmloyee)

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ' Change for WorkDays
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim TermDate As Date
                                TermDate = CDate(Emp.TerminateDate)
                                Dim StartDate As Date
                                StartDate = CDate(Emp.StartDate)
                                Dim WorkDays As Integer = 0
                                If StartDate.Year <> GLBCurrentPeriod.DateFrom.Year Then
                                    Dim DateYearStart As Date
                                    DateYearStart = CDate("01/01/" & GLBCurrentPeriod.DateFrom.Year)
                                    WorkDays = Math.Abs(DateDiff(DateInterval.Day, TermDate, DateYearStart)) + 1
                                Else
                                    WorkDays = Math.Abs(DateDiff(DateInterval.Day, TermDate, StartDate))
                                End If
                                ALAllowed = AlForYear * (WorkDays / 365)
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ' End of Change
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                                'ALAllowed = RoundMe3(AlForYear * (((WorkedPeriodsUntilNow * 173.33 + (1 * 173.33)) / (NormalPeriodsForThisEmloyee * 173.33))), 2)
                                'Dim UnitsOfThisPeriod As Double
                                'Dim SumOfAnuallUnitOfNormalPeriods As Double
                                'UnitsOfThisPeriod = Me.txtActualUnits.Text
                                'SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)



                                Dif = ALAllowed - ALTaken

                                Me.txtALforYear.Text = AlForYear
                                Me.txtALCarryForward.Text = CF
                                Me.txtALTaken.Text = ALTaken
                                Me.txtALAllowed.Text = ALAllowed
                                Me.txtALDiff.Text = Dif
                                Me.txtALtoPay.Text = (Dif + CF)


                                ANLeave = (Dif + CF) * UseThisRate
                            End If
                        End If
                    ElseIf TempEarn.TypeMode = "V" Then
                        ANLeave = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = ANLeave
                Exit For
            End If
        Next
    End Sub

    Private Sub E_CalculateAnnualLeaveProvision(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

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

        For i = 0 To Ded.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    '''

                    ' If TempEarn.TypeMode = "P" Then
                    ' ANLeave = Ern(i).txtValue.Text()
                    ' Dim ActualUnits As String = Me.txtActualUnits.Text
                    ' ANLeave = ActualUnits / GLBCurrentPeriod.PeriodUnits * ANLeave
                    'Else

                    If Emp.TerminateDate <> "" Then
                        If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                            ANLeave = 0
                        End If
                    Else
                        '''
                        ' If TempEarn.TypeMode = "P" Then
                        ' If Emp.TerminateDate <> "" Then
                        'If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                        If GLBEmployee.PayUni_Code = "1" Then
                            AlForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
                            ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
                            CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
                            NormalPeriods = Me.GLBCurrentPeriod.NumberOfNormalPeriods
                            NormalPeriodsUntilNow = Me.GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow
                            Dim WorkedPeriodsUntilNow As Integer
                            WorkedPeriodsUntilNow = Global1.Business.GetNumberOfNormalWorkedPeriods(Me.GLBEmployee.Code, Me.GLBCurrentPeriod)
                            Dim NormalPeriodsForThisEmloyee As Integer = 0
                            NormalPeriodsForThisEmloyee = NormalPeriods - (NormalPeriodsUntilNow - WorkedPeriodsUntilNow)


                            'ALAllowed = AlForYear * ((NormalPeriodsUntilNow + 1) / NormalPeriods)
                            ALAllowed = AlForYear * ((WorkedPeriodsUntilNow + 1) / NormalPeriodsForThisEmloyee)


                            Dif = ALAllowed - ALTaken
                            Dim T As Double = (AlForYear - ALTaken + CF)

                            ANLeave = (Dif + CF) * RateForOvertimeCalc
                        ElseIf GLBEmployee.PayUni_Code = "2" Then
                            AlForYear = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("T")
                            ALTaken = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("B")
                            CF = Me.GetAnnualLeaveFor_13_14_SalaryCalculation("C")
                            Dim T As Double = (AlForYear - ALTaken + CF + Me.GLBAnnualLeaveUnits)
                            ANLeave = (AlForYear - ALTaken + CF + Me.GLBAnnualLeaveUnits) * RateForOvertimeCalc
                        End If

                        'End If
                        'End If
                        '  ElseIf TempEarn.TypeMode = "V" Then
                        '      ANLeave = Ern(i).txtValue.Text
                        '  End If
                    End If
                End If
                ' End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = ANLeave
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateMesuareUnits(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim MU As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        MU = Ern(i).txtValue.Text
                        MU = MU / 100 * ValueToCalcFrom
                    ElseIf TempEarn.TypeMode = "V" Then
                        MU = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = MU
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateOverTime(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim OverTime1 As Double = 0
        Dim OverTime2 As Double = 0
        Dim OverTime3 As Double = 0

        Dim UseThisRate As Double = 0
        If Global1.PARAM_OvertimeRate_BasedOnSalary2 Then
            UseThisRate = Me.GLBRateFromSalary2
            If UseThisRate = 0 Then
                UseThisRate = Me.RateForOvertimeCalc
            End If
        Else
            UseThisRate = Me.RateForOvertimeCalc
        End If
        If PARAM_GetOvertimeRate_FromRateOnSalary Then
            UseThisRate = Me.OvertimeRateFromRateOnSalary
        End If



        If Me.txtOvertime1.Text = "" Then
            Me.txtOvertime1.Text = 0
        End If
        If Me.txtOvertime2.Text = "" Then
            Me.txtOvertime2.Text = 0
        End If
        If Me.txtOvertime3.Text = "" Then
            Me.txtOvertime3.Text = 0
        End If


        If Global1.PARAM_AddColaOnRate Then
            If GLBCOLAValueNotZero Then
                Dim NormalUnits As Double
                If Emp.PeriodUnits = 0 Then
                    NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
                Else
                    NormalUnits = Emp.PeriodUnits
                End If
                If NormalUnits <> 0 Then
                    'UseThisRate = UseThisRate + RoundMe3((Me.OvertimeRateofCOLA / NormalUnits), 2)
                    Dim ActualUnits As Double = 0
                    ActualUnits = Me.txtActualUnits.Text
                    UseThisRate = UseThisRate + RoundMe3((Me.OvertimeRateofCOLA / ActualUnits), 2)
                End If
            End If
        End If

        If Global1.PARAM_OvertimeRateOfPreviousPeriod Then
            UseThisRate = GetPreviousPeriodRate()
        End If


        OverTime1 = RoundMe3(UseThisRate * Parameters.OverTime_Rate1 * Me.txtOvertime1.Text, 2)
        OverTime2 = RoundMe3(UseThisRate * Parameters.OverTime_Rate2 * Me.txtOvertime2.Text, 2)

        If Not Global1.PARAM_OverTime3ToOtherEarnings Then
            OverTime3 = RoundMe3(UseThisRate * Parameters.OverTime_Rate3 * Me.txtOvertime3.Text, 2)
        Else
            OverTime3 = 0
        End If

        Dim i As Integer
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = OverTime1 + OverTime2 + OverTime3
                Exit For
            End If
        Next

        'Me.txtOver1.Text = Format(OverTime1, "0.00")
        'Me.txtOver2.Text = Format(OverTime2, "0.00")
    End Sub
    Private Sub E_CalculateOverTime1(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim OverTime1 As Double = 0
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer

        Dim EmpRate As Decimal = 0
      
        Dim UseThisRate As Double = RateForOvertimeCalc


        If Global1.PARAM_AddColaOnRate Then
            If GLBCOLAValueNotZero Then
                Dim NormalUnits As Double
                If Emp.PeriodUnits = 0 Then
                    NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
                Else
                    NormalUnits = Emp.PeriodUnits
                End If
                If NormalUnits <> 0 Then

                    Dim ActualUnits As Double = 0
                    ActualUnits = Me.txtActualUnits.Text
                    UseThisRate = UseThisRate + RoundMe3((Me.OvertimeRateofCOLA / ActualUnits), 2)

                End If
            End If
        End If



        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        If Global1.PARAM_OvertimeRateOfPreviousPeriod Then
                            EmpRate = GetPreviousPeriodRate()
                        Else
                            EmpRate = UseThisRate
                        End If
                        If Me.txtOvertime1.Text = "" Then
                            Me.txtOvertime1.Text = 0
                        End If
                        OverTime1 = RoundMe3(EmpRate * Parameters.OverTime_Rate1 * Me.txtOvertime1.Text, 2)
                    ElseIf TempEarn.TypeMode = "V" Then
                        OverTime1 = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = OverTime1
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateOverTime2(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim OverTime2 As Double = 0
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer

        Dim EmpRate As Decimal = 0
       
        Dim UseThisRate As Double = RateForOvertimeCalc


        If Global1.PARAM_AddColaOnRate Then
            If GLBCOLAValueNotZero Then
                Dim NormalUnits As Double
                If Emp.PeriodUnits = 0 Then
                    NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
                Else
                    NormalUnits = Emp.PeriodUnits
                End If
                If NormalUnits <> 0 Then

                    Dim ActualUnits As Double = 0
                    ActualUnits = Me.txtActualUnits.Text
                    UseThisRate = UseThisRate + RoundMe3((Me.OvertimeRateofCOLA / ActualUnits), 2)

                End If
            End If
        End If

        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        If Global1.PARAM_OvertimeRateOfPreviousPeriod Then
                            EmpRate = GetPreviousPeriodRate()
                        Else
                            EmpRate = UseThisRate
                        End If
                        If Me.txtOvertime2.Text = "" Then
                            Me.txtOvertime2.Text = 0
                        End If
                        OverTime2 = RoundMe3(EmpRate * Parameters.OverTime_Rate2 * Me.txtOvertime2.Text, 2)
                    ElseIf TempEarn.TypeMode = "V" Then
                        OverTime2 = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = OverTime2
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateOverTime3(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim OverTime3 As Double = 0
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer

        Dim EmpRate As Decimal = 0

        Dim UseThisRate As Double = RateForOvertimeCalc


        If Global1.PARAM_AddColaOnRate Then
            If GLBCOLAValueNotZero Then
                Dim NormalUnits As Double
                If Emp.PeriodUnits = 0 Then
                    NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
                Else
                    NormalUnits = Emp.PeriodUnits
                End If
                If NormalUnits <> 0 Then

                    Dim ActualUnits As Double = 0
                    ActualUnits = Me.txtActualUnits.Text
                    UseThisRate = UseThisRate + RoundMe3((Me.OvertimeRateofCOLA / ActualUnits), 2)

                End If
            End If
        End If



       
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        If Global1.PARAM_OvertimeRateOfPreviousPeriod Then
                            EmpRate = GetPreviousPeriodRate()
                        Else
                            EmpRate = UseThisRate
                        End If
                        If Me.txtOvertime3.Text = "" Then
                            Me.txtOvertime3.Text = 0
                        End If
                        OverTime3 = RoundMe3(EmpRate * Parameters.OverTime_Rate3 * Me.txtOvertime3.Text, 2)
                    ElseIf TempEarn.TypeMode = "V" Then
                        OverTime3 = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = OverTime3
                Exit For
            End If
        Next
      
    End Sub
    Private Function GetPreviousPeriodRate() As Decimal
        Dim Rate As Decimal = 0
        Dim PeriodToGetRateFrom As New cPrMsPeriodCodes
        Dim PeriodCode As String = ""
        If PreviousPeriod.PayCat_Code = "3" Or PreviousPeriod.PayCat_Code = "4" Then
            PeriodToGetRateFrom = PreviousPeriod.GetPreviousPeriod
            periodcode = PeriodToGetRateFrom.Code
        Else
            PeriodCode = PreviousPeriod.Code
        End If
        Dim PrevHeader As New cPrTxTrxnHeader(GLBEmployee.Code, PeriodCode)
        If PrevHeader.Id > 0 Then
            Rate = PrevHeader.MyRate
        Else
            MsgBox("There is no Overtime Rate based on Previous Period for employee " & GLBEmployee.Code & " " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
        End If
        Return Rate

    End Function
    Private Sub E_CalculateCOLA(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes, ByVal ValueOf13Salary As Double, ByVal Calledfrom13 As Boolean, ByVal CalledFrom14 As Boolean)

        HASSeparateCOLA = True
        OvertimeRateofCOLA = 0

        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim COLAPercentage As Double
        Dim COLAValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        If TempEarn.FromMode = "T" Then
                            If Not Calledfrom13 And Not CalledFrom14 Then
                                'ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula) + ValueOf13Salary
                                ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula) + ValueOf13Salary
                            Else
                                ValueToCalcFrom = +ValueOf13Salary
                            End If
                            Dim Ds As DataSet
                            Dim Limits As New cPrSsLimits
                            Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                            If CheckDataSet(Ds) Then
                                Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                            End If
                            COLAPercentage = Limits.Cola
                            COLAValue = COLAPercentage / 100 * ValueToCalcFrom
                        Else
                            If Not Calledfrom13 And Not CalledFrom14 Then
                                'ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula) + ValueOf13Salary
                                ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula) + ValueOf13Salary
                            Else
                                ValueToCalcFrom = +ValueOf13Salary
                            End If

                            COLAPercentage = Ern(i).txtValue.Text
                            COLAValue = COLAPercentage / 100 * ValueToCalcFrom
                        End If

                        If Not Calledfrom13 And Not CalledFrom14 Then
                            If COLAValue < Global1.PARAM_COLAMinimum Then
                                '''
                                If Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
                                    'Period
                                    Dim ActualUnits As Double
                                    Dim NormalUnits As Double
                                    ActualUnits = Me.txtActualUnits.Text
                                    If Emp.PeriodUnits = 0 Then
                                        NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
                                    Else
                                        NormalUnits = Emp.PeriodUnits
                                    End If

                                    If NormalUnits <> 0 Then
                                        If GLBCurrentPeriod.PayCat_Code <> "3" And GLBCurrentPeriod.PayCat_Code <> "4" Then
                                            COLAValue = RoundMe3((Global1.PARAM_COLAMinimum / NormalUnits) * ActualUnits, 2)
                                            'COLAValue = Global1.PARAM_COLAMinimum
                                        End If
                                    End If
                                End If
                                '''
                            End If
                        End If

                    ElseIf TempEarn.TypeMode = "V" Then
                        COLAValue = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        If Not Calledfrom13 And Not calledFrom14 Then
            GLBCOLAValue = GLBCOLAValue + COLAValue
            For i = 0 To E_Final.Length - 1
                If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                    E_Final(i).MyValue = COLAValue
                    Exit For
                End If
            Next
        Else
            If Calledfrom13 Then
                GLBAdditionTo13 = COLAValue
            End If
            If calledFrom14 Then
                GLBAdditionTo14 = COLAValue
            End If
        End If
        OvertimeRateofCOLA = COLAValue
        If COLAValue <> 0 Then
            GLBCOLAValueNotZero = True
        Else
            GLBCOLAValueNotZero = False
        End If

    End Sub
    Private Sub E_CalculateBenefitsInKind(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateBenefitsInKindRecurring(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next
        GLBBenefitsRecurringEarning = GLBBenefitsRecurringEarning + Value
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub


    Private Sub E_CalculateBenefitsInKindRecurring_14(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next

        GLBBenefitsRecurringEarning14 = GLBBenefitsRecurringEarning14 + Value

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateRecurringEarning(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next

        GLBRecurringEarning = GLBRecurringEarning + Value

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub
    
    Private Sub E_CalculateRecurringEarning14(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next

        GLBRecurringEarning14 = GLBRecurringEarning14 + Value

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculateRecuringNegative(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
            Value = Value * -1
        Next


        GLBRecurringEarning = GLBRecurringEarning + Value

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub
    Private Sub E_CalculatePensionDeduction(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim TempEarn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Percentage As Double
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempEarn = Ern(i).Ern
                If TempEarn.ErnCodCode <> "" Then
                    If TempEarn.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempEarn.CalcFormula)
                        Percentage = Ern(i).txtValue.Text
                        Value = Percentage / 100 * ValueToCalcFrom

                    ElseIf TempEarn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                    Exit For
                End If
            End If
        Next

        GLBPensiondeduction = GLBPensiondeduction + Value

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next
    End Sub
    '---------------------------------------------------------------------------------------------
    ''''''''''''''''''''''''''         AIRLINES       ''''''''''''''''''''''''''''''''''''''''''''
    '---------------------------------------------------------------------------------------------
    Private Sub E_CalculateSectors(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim Sectors As Double

        ''
        If Me.txtSectors.Text = "" Then
            Me.txtSectors.Text = 0
        End If

        Sectors = Me.txtSectors.Text

        ''
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        'ValueToCalcFrom = FindValueOfFormula(TempErn.CalcFormula)
                        Value = Ern(i).txtValue.Text
                        Value = RoundMe3(Value * Sectors, 2)
                    ElseIf TempErn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next

    End Sub
    Private Sub E_CalculateDutyHours(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim dutyHours As Double

        ''
        If Me.txtDutyHours.Text = "" Then
            Me.txtDutyHours.Text = 0
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''
        '         Minutes to Decimal
        '''''''''''''''''''''''''''''''''''''''''
        dutyHours = Me.txtDutyHours.Text
        Dim S As String
        Dim DecimalMinutes As Integer = 0
        S = Format(dutyHours, "0.00")
        Dim Ar() As String
        Ar = S.ToString.Split(".")
        Try
            Dim N As Integer
            N = Ar(1)
            If N <> 0 Then
                DecimalMinutes = N / 60 * 100
                If DecimalMinutes >= 100 Then
                    MsgBox("Please revise Duty hours of employee " & Emp.Code & " minutes cannot be greater than 60", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception

        End Try

        dutyHours = Ar(0) & "." & DecimalMinutes

        '''''''''''''''''''''''''''''''''''''''''

        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        'ValueToCalcFrom = FindValueOfFormula(TempErn.CalcFormula)
                        Value = Ern(i).txtValue.Text
                        Value = RoundMe3(Value * dutyHours, 2)
                    ElseIf TempErn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next

    End Sub
    Private Sub E_CalculateOverLay(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim overlay As Double

        ''
        If Me.txtOverLay.Text = "" Then
            Me.txtOverLay.Text = 0
        End If

        overlay = Me.txtOverLay.Text

        ''
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        'ValueToCalcFrom = FindValueOfFormula(TempErn.CalcFormula)
                        Value = Ern(i).txtValue.Text
                        Value = RoundMe3(Value * overlay, 2)
                    ElseIf TempErn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next

    End Sub
    Private Sub E_CalculateFlightHours(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim FlightHours As Double

        ''
        If Me.TxtFlightHours.Text = "" Then
            Me.TxtFlightHours.Text = 0
        End If

        FlightHours = Me.TxtFlightHours.Text
        ''''''''''''''''''''''''''''''''''''''''''''''''
        '         Minutes to Decimal
        '''''''''''''''''''''''''''''''''''''''''
        Dim S As String
        Dim DecimalMinutes As Integer = 0
        S = Format(FlightHours, "0.00")
        Dim Ar() As String
        Ar = S.ToString.Split(".")
        Try
            Dim N As Integer
            N = Ar(1)
            If N <> 0 Then
                DecimalMinutes = N / 60 * 100
                If DecimalMinutes >= 100 Then
                    MsgBox("Please revise Flight hours of employee " & Emp.Code & " minutes cannot be greater than 60", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception

        End Try

        FlightHours = Ar(0) & "." & DecimalMinutes

        '''''''''''''''''''''''''''''''''''''''''

        ''
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        Dim FliHou As New cPrSsFlightHours(Emp.FlightHours)
                        If FlightHours <= FliHou.Limit Then
                            'ValueToCalcFrom = FindValueOfFormula(TempErn.CalcFormula)
                            Value = Ern(i).txtValue.Text
                            Value = RoundMe3(Value * FlightHours, 2)
                        Else
                            Dim F1 As Double = 0
                            Dim F2 As Double = 0
                            Value = Ern(i).txtValue.Text
                            F1 = RoundMe3(Value * FliHou.Limit, 2)
                            Dim FliHouLimit As New cPrSsFlightHours(FliHou.LimitCode)
                            If FliHouLimit.Code <> "" Then
                                F2 = RoundMe3(FliHouLimit.HourRate * (FlightHours - FliHou.Limit), 2)
                            End If
                            Value = F1 + F2

                        End If
                    ElseIf TempErn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next

    End Sub
    Private Sub E_CalculatePerformanceBonus(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim Rate As Double
        Dim Amount As Double

        Dim ActualUnits As Double = Me.txtActualUnits.Text
        Dim NormalUnits As Double = Me.GLBCurrentPeriod.PeriodUnits


        ''
        If Me.txtPBAmount.Text = "" Then
            Me.txtPBAmount.Text = 0
        End If
        If Me.txtPBRate.Text = "" Then
            Me.txtPBRate.Text = 0
        End If
        Rate = Me.txtPBRate.Text
        Amount = Me.txtPBAmount.Text



        ''
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        'ValueToCalcFrom = FindValueOfFormula(TempErn.CalcFormula)
                        Value = Ern(i).txtValue.Text
                        Value = RoundMe3(Rate / 100 * Amount, 2)
                        Value = RoundMe3(ActualUnits / NormalUnits * Value, 2)
                    ElseIf TempErn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next

    End Sub
    Private Sub E_CalculateSalesCommission(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim TempErn As New cPrMsTemplateEarnings
        Dim i As Integer
        Dim Value As Double
        Dim ValueToCalcFrom As Double
        Dim Commission As Double

        ''
        If Me.txtCommission.Text = "" Then
            Me.txtCommission.Text = 0
        End If

        Commission = Me.txtCommission.Text

        ''
        For i = 0 To Ern.Length - 1
            If Earn.Code = Ern(i).Ern.ErnCodCode Then
                TempErn = Ern(i).Ern
                If TempErn.ErnCodCode <> "" Then
                    If TempErn.TypeMode = "P" Then
                        'ValueToCalcFrom = FindValueOfFormula(TempErn.CalcFormula)
                        Value = Ern(i).txtValue.Text
                        Value = RoundMe3(Value / 100 * Commission, 2)
                    ElseIf TempErn.TypeMode = "V" Then
                        Value = Ern(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Value
                Exit For
            End If
        Next

    End Sub

#End Region
#Region "Deductions Calculations"
    Private Sub CalculateDeductions(ByVal Emp As cPrMsEmployees, ByVal OnlyRecuring As Boolean)
        Dim i As Integer
        Dim CalculateIncomeTax As Boolean = False
        Dim IncomeTax_ED As New cPrMsEmployeeDeductions
        Dim IncomeTax_Dedu As New cPrMsDeductionCodes

        For i = 0 To Me.Ded.Length - 1
            If Not Ded(i).Ded Is Nothing Then
                Dim ED As New cPrMsEmployeeDeductions(Emp.Code, Ded(i).Ded.DedCodCode)
                Dim Dedu As New cPrMsDeductionCodes(Ded(i).Ded.DedCodCode)

                Select Case Dedu.DedTypCode
                    Case "AD" 'ADVANCES 'F
                        D_CalculateAdvances(Emp, ED, Dedu)
                    Case "CL" 'COMPANY LOAN 'F
                        D_CalculateCompanyLoan(Emp, ED, Dedu, OnlyRecuring)
                    Case "IT" 'INCOME TAX
                        IncomeTax_ED = ED
                        IncomeTax_Dedu = Dedu
                        CalculateIncomeTax = True
                    Case "MF" 'MEDICAL FUND 'F
                        D_CalculateMedicalFund(Emp, ED, Dedu)
                    Case "PF" 'PROVIDENT FUND 'F
                        D_CalculateProvidentFund(Emp, ED, Dedu)
                    Case "PL" 'PROVIDENT FUND LOAN 'F
                        D_CalculateProvidentFundLoan(Emp, ED, Dedu, OnlyRecuring)
                    Case "SI" 'SOCIAL INSURANCE 'F
                        If Global1.GLB_MethodOfSI = 1 Then
                            D_CalculateSocialInsurance_1(Emp, ED, Dedu)
                        ElseIf Global1.GLB_MethodOfSI = 2 Then
                            D_CalculateSocialInsurance_3(Emp, ED, Dedu, OnlyRecuring)
                        End If
                    Case "U2" 'UNION NEWSPAPER 'F
                        D_CalculateUnion2(Emp, ED, Dedu)
                    Case "U3" 'OTHER 'F
                        D_CalculateUnion3(Emp, ED, Dedu)
                    Case "US" 'UNION SUBSCRIPTION 'F
                        D_CalculateUnionSubscription(Emp, ED, Dedu)
                    Case "UM" 'UNION MEDICAL FUND 'F
                        D_CalculateUnionMedicalFund(Emp, ED, Dedu)
                    Case "OT" 'OTHER DEDUCTIONS
                        D_CalculateOtherDeductions(Emp, ED, Dedu)
                    Case "EX" 'special Tax
                        D_CalculateSpecialTax(Emp, ED, Dedu)
                    Case "DN" 'Decrease Normal
                        D_CalculateDecrease(Emp, ED, Dedu) ', OnlyRecuring) ', "01")
                    Case "PN" 'Decrease Normal
                        D_CalculatePensionFund(Emp, ED, Dedu) ', "01")
                        'Case "DP" 'Decrease Pensioners
                        '   D_CalculateDecrease(Emp, ED, Dedu, "02")
                    Case "WO" 'Decrease Normal
                        D_CalculateWidowFund(Emp, ED, Dedu) ', "01")
                    Case "GD" 'Decrease Normal
                        D_CalculateGESI(Emp, ED, Dedu) ', "01")
                        'D_CalculateGESI_2(Emp, ED, Dedu) ', "01")
                    Case "GT" 'Decrease Normal
                        D_Calculate_BIK_GESI(Emp, ED, Dedu) ', "01")
                    Case "RU"
                        GlbRunroundUp = True
                        Me.D_CalculateRoundNETUp(Emp, ED, Dedu) ', "01")

                End Select

            End If
        Next
        If CalculateIncomeTax Then
            If Global1.PARAM_PAYE Then
                D_CalculateIncomeTax(Emp, IncomeTax_ED, IncomeTax_Dedu)
            Else
                D_CalculateIncomeTax_Method2(Emp, IncomeTax_ED, IncomeTax_Dedu, OnlyRecuring)
            End If
            ' D_CalculateIncomeTax_EXTRABOLATION(Emp, IncomeTax_ED, IncomeTax_Dedu)
        Else
            D_TaxableIncomeANDSIIncomeForCasesOf13NotTaxable(Emp, IncomeTax_ED, IncomeTax_Dedu)
        End If

        Dim TotalD As Double
        TotalD = CalculateTotalDeductions()
        Me.txtTotalDeductions.Text = Format(RoundMe2(TotalD, 2), "0.00")


    End Sub
    Private Sub D_CalculateAdvances(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim Advances As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        Advances = Ded(i).txtValue.Text
                        Advances = Advances / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        Advances = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            Advances = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Advances = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Advances = 0
        '        End If
        '        Advances = Advances / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        Advances = EmpDed.MyValue
        '    End If
        'End If
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = Advances
                Exit For
            End If
        Next
    End Sub
    Private Sub D_CalculateRoundNETUp(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim RoundUpAmount As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    RoundUpAmount = GLBRoundUpAmount
                    Exit For
                End If
            End If
        Next
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = RoundUpAmount
                Exit For
            End If
        Next
    End Sub
    Private Sub D_CalculateCompanyLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal OnlyRecuring As Boolean)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim CompanyLoan As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        CompanyLoan = Ded(i).txtValue.Text
                        CompanyLoan = CompanyLoan / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        CompanyLoan = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            CompanyLoan = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            CompanyLoan = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            CompanyLoan = 0
        '        End If
        '        CompanyLoan = CompanyLoan / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        CompanyLoan = EmpDed.MyValue
        '    End If
        'End If
        If CompanyLoan <> 0 Then
            If Not OnlyRecuring Then
                Dim ds As DataSet
                ds = Global1.Business.CheckLoanValue(GLBEmployee.Code, TempDed.DedCodCode)
                If Not CheckDataSet(ds) Then
                    Dim Ans As MsgBoxResult
                    Ans = MsgBox("There are no Loans with Status 'OPEN' for Employee " & GLBEmployee.Code & " " & GLBEmployee.FullName & " for Deduction code " & TempDed.DedCodCode & " Proceed with Load Deduction of Value " & CompanyLoan & " ?", MsgBoxStyle.YesNo)
                    If Ans = MsgBoxResult.No Then
                        CompanyLoan = 0
                    End If
                End If
            End If
        End If


        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = CompanyLoan
                Exit For
            End If
        Next

    End Sub
    Private Sub D_CalculateProvidentFundLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal OnlyRecuring As Boolean)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim PFLoan As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        PFLoan = Ded(i).txtValue.Text
                        PFLoan = PFLoan / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        PFLoan = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            PFLoan = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            PFLoan = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            PFLoan = 0
        '        End If
        '        PFLoan = PFLoan / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        PFLoan = EmpDed.MyValue
        '    End If
        'End If
        If PFLoan <> 0 Then
            If Not OnlyRecuring Then
                Dim ds As DataSet
                ds = Global1.Business.CheckLoanValue(GLBEmployee.Code, TempDed.DedCodCode)
                If Not CheckDataSet(ds) Then
                    Dim Ans As MsgBoxResult
                    Ans = MsgBox("There are no Loans with Status 'OPEN' for Employee " & GLBEmployee.Code & " for Deduction code " & TempDed.DedCodCode & " Proceed with Load Deduction ?", MsgBoxStyle.YesNo)
                    If Ans = MsgBoxResult.No Then
                        PFLoan = 0
                    End If
                End If
            End If
        End If


        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = PFLoan
                Exit For
            End If
        Next

    End Sub
    Private Sub D_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim MFValue As Double
        Dim xMFValue As Double
        Dim xValueToCalcFrom As Double
        Dim ValueToCalcFrom As Double

        Dim RemainingPeriodsWithMF As Integer
        RemainingPeriodsWithMF = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithMF = 0
        End If


        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)


                        MFValue = Ded(i).txtValue.Text
                        MFValue = MFValue / 100 * ValueToCalcFrom

                        If Global1.PARAM_PAYE = False Then
                            Dim Perc As Double
                            Perc = Ded(i).txtValue.Text
                            xValueToCalcFrom = Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(TempDed.CalcFormula)
                            xMFValue = Perc / 100 * xValueToCalcFrom
                            Me.GLB_MF_ByTheEndOfTheYear = Me.GLB_MF_ByTheEndOfTheYear + xMFValue * RemainingPeriodsWithMF

                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        MFValue = Ded(i).txtValue.Text
                        If Global1.PARAM_PAYE = False Then
                            Me.GLB_MF_ByTheEndOfTheYear = Me.GLB_MF_ByTheEndOfTheYear + MFValue * RemainingPeriodsWithMF
                        End If
                    End If
                End If
                Exit For
            End If
        Next


        'If Not ForEstimation Then
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = MFValue
                Exit For
            End If
        Next
        ' End If

    End Sub
    Private Sub D_CalculateGESI(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)

        Dim LimitTotalGesiable As Double = 0

        Dim CheckLimitOfGesy = False
        Dim ForLimitCheck As Double = 0
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim GESIRate As Double
        Dim GESIValue As Double
        Dim xGESIValue As Double
        Dim xValueToCalcFrom As Double
        Dim ValueToCalcFrom As Double

        Dim RemainingPeriodsWithGESI As Integer
        RemainingPeriodsWithGESI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithGESI = 0
        End If

        Dim PreviousGesi As Double = 0
        '***********************************************************
        '**************** Gesy Limit is Per Employee ***************
        ' If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
        'PreviousGesi = Me.GLBEmployee.PreviousGesiD
        'End If
        '***********************************************************
        '***********************************************************

        Dim TodateGESI As Double
        TodateGESI = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "GD")
        GLB_TodateGesi_DED = TodateGESI
        Dim TempPeriodInsurable As Double = 0


        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)

                        GESIValue = Ded(i).txtValue.Text
                        GESIRate = Ded(i).txtValue.Text
                        '***************************************************************************************************************************
                        '2021 Change
                        If ValueToCalcFrom < 0 Then
                            ValueToCalcFrom = 0
                        End If
                        'END OF 2021 change
                        '***************************************************************************************************************************
                        ForLimitCheck = ValueToCalcFrom
                        GESIValue = GESIValue / 100 * Utils.RoundMeUp(ValueToCalcFrom)

                        If Global1.PARAM_PAYE = False Then
                            '*********************   Checking Limits until 28/04/2020
                            Dim Perc As Double
                            Dim ActualTotalYear As Double = 0
                            Dim TotalYear As Double = 0

                            ActualTotalYear = GESIValue + TodateGESI + PreviousGesi
                            If ActualTotalYear > Me.GLBLimits.GesiD Then
                                '******************* LAST CHANGE REVERSE it in 2020 until end of
                                'Dim YTD_Gesiable As Double
                                'Dim PER_Gesiable As Double

                                'Dim PREV_GESIABLE As Double = 0
                                'If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                                '    PREV_GESIABLE = GLBEmployee.PreviousEarnings
                                'End If


                                'YTD_Gesiable = Global1.Business.GetSUM_Of_GESIABLE_FromTrxnHeaderFor(Me.GLBCurrentPeriod, GLBEmployee.Code)


                                'Dim GesiableforPeriod As Double = 0

                                'LimitTotalGesiable = YTD_Gesiable + PREV_GESIABLE + Utils.RoundMeUp(ValueToCalcFrom)

                                'If LimitTotalGesiable >= LimitOfGESYasInsurableAmount Then
                                '    GesiableforPeriod = LimitOfGESYasInsurableAmount - (YTD_Gesiable + PREV_GESIABLE)
                                '    GESIValue = GESIRate / 100 * Utils.RoundMeUp(GesiableforPeriod)
                                'End If
                                '*********    END OF last change
                                '*********************************************************************************

                                'GET THIS OUT OF COMMENTS IN 2021
                                '-----------------------------------------------------------
                                Dim Diff As Double
                                Diff = Me.GLBLimits.GesiD - (TodateGESI + PreviousGesi)
                                If Diff < 0 Then Diff = 0
                                GESIValue = Diff
                                '-----------------------------------------------------------

                                CheckLimitOfGesy = True
                            End If


                            Perc = Ded(i).txtValue.Text
                            xValueToCalcFrom = Utils.RoundMeUp(Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY_GESINormal(TempDed.CalcFormula))
                            '**************************************************************************************
                            '''''''''''''' GESI ADD SILEAVE FOR FUTURE PERIODS ''''''''''''''''''''''''''''''''''''
                            Dim SILeave As Double
                            SILeave = GlbSILeavePerc / 100 * GrossFor13AND14Calc

                            If SILeave > GlbSILeavePerc / 100 * GLBLimits.InsurableMth Then
                                SILeave = GlbSILeavePerc / 100 * GLBLimits.InsurableMth
                            End If
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            '**************************************************************************************

                            xValueToCalcFrom = xValueToCalcFrom + SILeave

                            Dim xGESIOnSILeave As Double = 0
                            xGESIValue = RoundMe2(Perc / 100 * xValueToCalcFrom, 2)


                            Me.GLB_GESI_ByTheEndOfTheYear = Me.GLB_GESI_ByTheEndOfTheYear + xGESIValue * RemainingPeriodsWithGESI
                            '---------------   Checking Limits
                            TotalYear = Me.GLB_GESI_ByTheEndOfTheYear + PreviousGesi + GESIValue + TodateGESI
                            If TotalYear > Me.GLBLimits.GesiD Then
                                Dim diff As Double
                                diff = Me.GLBLimits.GesiD - (PreviousGesi + GESIValue + TodateGESI)
                                If diff < 0 Then diff = 0
                                Me.GLB_GESI_ByTheEndOfTheYear = diff
                                CheckLimitOfGesy = True
                            End If
                            ' ---------------- End of Checking Limits

                        End If

                    ElseIf TempDed.TypeMode = "V" Then
                        GESIValue = Ded(i).txtValue.Text
                        'Checking Limits
                        Dim Perc As Double
                        Dim ActualTotalYear As Double = 0
                        Dim TotalYear As Double = 0

                        ActualTotalYear = GESIValue + TodateGESI + PreviousGesi
                        If ActualTotalYear > Me.GLBLimits.GesiD Then
                            Dim Diff As Double
                            Diff = Me.GLBLimits.GesiD - (TodateGESI + PreviousGesi)
                            If Diff < 0 Then Diff = 0
                            GESIValue = Diff
                            CheckLimitOfGesy = True
                        End If
                        'Checking Limits
                        If Global1.PARAM_PAYE = False Then

                            Me.GLB_GESI_ByTheEndOfTheYear = Me.GLB_GESI_ByTheEndOfTheYear + GESIValue * RemainingPeriodsWithGESI
                            'Checking Limits
                            TotalYear = Me.GLB_GESI_ByTheEndOfTheYear + PreviousGesi + GESIValue + TodateGESI
                            If TotalYear > Me.GLBLimits.GesiD Then
                                Dim diff As Double
                                diff = Me.GLBLimits.GesiD - (PreviousGesi + GESIValue + TodateGESI)
                                If diff < 0 Then diff = 0
                                Me.GLB_GESI_ByTheEndOfTheYear = diff
                                'CheckLimitOfGesy = True
                            End If
                            'Checking Limits

                        End If
                    End If
                End If
                Exit For
            End If
        Next


        'If Not ForEstimation Then
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = GESIValue
                PeriodGesiDValue = GESIValue
                Exit For
            End If
        Next
        If GESIRate <> 0 Then
            GLBGesiAmount = RoundMe2(GESIValue * 100 / GESIRate, 2)
        End If
        ' End If
        If CheckLimitOfGesy Then
            'Dim InsurableUntilNow As Double
            'InsurableUntilNow = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriodGroup(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)
            ''change
            'InsurableUntilNow = InsurableUntilNow + ForLimitCheck
            'If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
            '    InsurableUntilNow = InsurableUntilNow + Emp.PreviousEarnings
            'End If
            'If InsurableUntilNow < 180000 Then
            ' MsgBox("Employee - " & Emp.Code & " " & Emp.FullName & " has reached GESY amount Limit. Please check if this is correct.", MsgBoxStyle.Information)
        End If

        Dim FixedGesy As Double = 0
        FixedGesy = CDbl(Me.txtFixedGesyD.Text)
        If FixedGesy <> 0 Then
            If FixedGesy = -1 Then
                FixedGesy = 0
            End If
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Continue with Calculating Gesy as " & FixedGesy, MsgBoxStyle.YesNo)
            If Ans = MsgBoxResult.Yes Then
                GESIValue = FixedGesy
                Me.GLB_GESI_ByTheEndOfTheYear = 0 'PreviousGesi + TodateGESI
                For i = 0 To D_Final.Length - 1
                    If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                        D_Final(i).MyValue = GESIValue
                        PeriodGesiDValue = GESIValue
                        Exit For
                    End If
                Next
            End If

        End If
        'End If

    End Sub
    'Private Sub D_CalculateGESI_2(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
    '    Dim TempDed As New cPrMsTemplateDeductions
    '    Dim i As Integer
    '    Dim GESIRate As Double
    '    Dim GESIValue As Double
    '    Dim xGESIValue As Double
    '    Dim xValueToCalcFrom As Double
    '    Dim ValueToCalcFrom As Double

    '    Dim RemainingPeriodsWithGESI As Integer
    '    RemainingPeriodsWithGESI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
    '    If GLBEmployee.TerminateDate <> "" Then
    '        RemainingPeriodsWithGESI = 0
    '    End If

    '    Dim PreviousGesi As Double = 0
    '    If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
    '        PreviousGesi = Me.GLBEmployee.PreviousGesiD
    '    End If
    '    Dim TodateGESI As Double
    '    TodateGESI = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "GD")

    '    Dim TempPeriodInsurable As Double = 0


    '    For i = 0 To Ded.Length - 1
    '        If Dedu.Code = Ded(i).Ded.DedCodCode Then
    '            TempDed = Ded(i).Ded
    '            If TempDed.DedCodCode <> "" Then
    '                If TempDed.TypeMode = "P" Then
    '                    ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)


    '                    GESIValue = Ded(i).txtValue.Text
    '                    GESIRate = Ded(i).txtValue.Text

    '                    GESIValue = GESIValue / 100 * Utils.RoundMeUp(ValueToCalcFrom)

    '                    If Global1.PARAM_PAYE = False Then

    '                        'Checking Limits
    '                        Dim Perc As Double
    '                        Dim ActualTotalYear As Double = 0
    '                        Dim TotalYear As Double = 0

    '                        'Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
    '                        Dim TodateGESIInsurable As Double = 0
    '                        Dim AnnualInsurableToDate As Double = 0
    '                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)

    '                        TodateGESIInsurable = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
    '                        ActualTotalYear = Period_InsurableIncome + AnnualInsurableToDate + Emp.PreviousInsurableForGESY

    '                        TempPeriodInsurable = Period_InsurableIncome
    '                        'Me.GLBLimits.GesiD
    '                        If ActualTotalYear > 180000 Then
    '                            Dim Diff As Double
    '                            Diff = 180000 - (TodateGESIInsurable + Emp.PreviousInsurableForGESY)
    '                            If Diff < 0 Then Diff = 0
    '                            TempPeriodInsurable = Diff
    '                            GESIValue = RoundMe2(GESIRate * Diff / 100, 2)
    '                        End If
    '                        ' ***************    Checking Limits

    '                        Perc = Ded(i).txtValue.Text
    '                        xValueToCalcFrom = Utils.RoundMeUp(Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY_GESINormal(TempDed.CalcFormula))
    '                        '**************************************************************************************
    '                        '''''''''''''' GESI ADD SILEAVE FOR FUTURE PERIODS ''''''''''''''''''''''''''''''''''''
    '                        Dim SILeave As Double
    '                        SILeave = GlbSILeavePerc / 100 * GrossFor13AND14Calc

    '                        If SILeave > GlbSILeavePerc / 100 * GLBLimits.InsurableMth Then
    '                            SILeave = GlbSILeavePerc / 100 * GLBLimits.InsurableMth
    '                        End If
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        '**************************************************************************************

    '                        xValueToCalcFrom = xValueToCalcFrom + SILeave

    '                        Dim xGESIOnSILeave As Double = 0
    '                        xGESIValue = RoundMe2(Perc / 100 * xValueToCalcFrom, 2)


    '                        ' Me.GLB_GESI_ByTheEndOfTheYear = Me.GLB_GESI_ByTheEndOfTheYear + xGESIValue * RemainingPeriodsWithGESI
    '                        ''---------------   Checking Limits
    '                        'TotalYear = Me.GLB_GESI_ByTheEndOfTheYear + PreviousGesi + GESIValue + TodateGESI
    '                        'If TotalYear > Me.GLBLimits.GesiD Then
    '                        '    Dim diff As Double
    '                        '    diff = Me.GLBLimits.GesiD - (PreviousGesi + GESIValue + TodateGESI)
    '                        '    If diff < 0 Then diff = 0
    '                        '    Me.GLB_GESI_ByTheEndOfTheYear = diff
    '                        'End If
    '                        '---------------- End of Checking Limits
    '                        '---------------   Checking Limits

    '                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
    '                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
    '                            AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
    '                        End If

    '                        TotalYear = Period_ONLY_Recuring_SI + TempPeriodInsurable + AnnualInsurableToDate + Emp.PreviousInsurableForGESY
    '                        If TotalYear > Me.GLBLimits.GesiD Then
    '                            Dim diff As Double
    '                            diff = Me.GLBLimits.GesiD - (PreviousGesi + GESIValue + TodateGESI)
    '                            If diff < 0 Then diff = 0
    '                            Me.GLB_GESI_ByTheEndOfTheYear = diff
    '                        End If
    '                        '---------------- End of Checking Limits

    '                        'If Global1.PARAM_SplitIsEnabled Then
    '                        '    Me.CalculateSplitForGESY(Emp)
    '                        '    glbSplitForGesy = RoundMe2(GLBTotalYearSplitForGESI * Perc / 100, 2)
    '                        'End If
    '                        'End of Checking Limits
    '                    End If

    '                ElseIf TempDed.TypeMode = "V" Then
    '                    GESIValue = Ded(i).txtValue.Text
    '                    'Checking Limits
    '                    Dim Perc As Double
    '                    Dim ActualTotalYear As Double = 0
    '                    Dim TotalYear As Double = 0

    '                    ActualTotalYear = GESIValue + TodateGESI + PreviousGesi
    '                    If ActualTotalYear > Me.GLBLimits.GesiD Then
    '                        Dim Diff As Double
    '                        Diff = Me.GLBLimits.GesiD - (TodateGESI + PreviousGesi)
    '                        If Diff < 0 Then Diff = 0
    '                        GESIValue = Diff
    '                    End If
    '                    'Checking Limits
    '                    If Global1.PARAM_PAYE = False Then

    '                        Me.GLB_GESI_ByTheEndOfTheYear = Me.GLB_GESI_ByTheEndOfTheYear + GESIValue * RemainingPeriodsWithGESI
    '                        'Checking Limits
    '                        TotalYear = Me.GLB_GESI_ByTheEndOfTheYear + PreviousGesi + GESIValue + TodateGESI
    '                        If TotalYear > Me.GLBLimits.GesiD Then
    '                            Dim diff As Double
    '                            diff = Me.GLBLimits.GesiD - (PreviousGesi + GESIValue + TodateGESI)
    '                            If diff < 0 Then diff = 0
    '                            Me.GLB_GESI_ByTheEndOfTheYear = diff
    '                        End If
    '                        'Checking Limits

    '                    End If
    '                End If
    '            End If
    '            Exit For
    '        End If
    '    Next


    '    'If Not ForEstimation Then
    '    For i = 0 To D_Final.Length - 1
    '        If Dedu.Code = D_Final(i).Ded.DedCodCode Then
    '            D_Final(i).MyValue = GESIValue
    '            PeriodGesiDValue = GESIValue
    '            Exit For
    '        End If
    '    Next
    '    If GESIRate <> 0 Then
    '        GLBGesiAmount = RoundMe2(GESIValue * 100 / GESIRate, 2)
    '    End If
    '    ' End If

    'End Sub
    'Private Sub D_Calculate_BIK_GESI(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
    '    Dim TempDed As New cPrMsTemplateDeductions
    '    Dim i As Integer
    '    Dim BIK_GESIRate As Double
    '    Dim BIK_GESIValue As Double
    '    Dim xBIK_GESIValue As Double
    '    Dim xBIK_ValueToCalcFrom As Double
    '    Dim BIK_ValueToCalcFrom As Double

    '    Dim RemainingPeriodsWithGESI As Integer
    '    RemainingPeriodsWithGESI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
    '    If GLBEmployee.TerminateDate <> "" Then
    '        RemainingPeriodsWithGESI = 0
    '    End If

    '    For i = 0 To Ded.Length - 1
    '        If Dedu.Code = Ded(i).Ded.DedCodCode Then
    '            TempDed = Ded(i).Ded
    '            If TempDed.DedCodCode <> "" Then
    '                If TempDed.TypeMode = "P" Then
    '                    BIK_ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)


    '                    BIK_GESIValue = Ded(i).txtValue.Text
    '                    BIK_GESIRate = Ded(i).txtValue.Text

    '                    BIK_GESIValue = BIK_GESIValue / 100 * BIK_ValueToCalcFrom



    '                End If
    '                Exit For
    '            End If
    '        End If
    '    Next


    '    'If Not ForEstimation Then
    '    For i = 0 To D_Final.Length - 1
    '        If Dedu.Code = D_Final(i).Ded.DedCodCode Then
    '            D_Final(i).MyValue = BIK_GESIValue
    '            Period_BIK_GesiDValue = BIK_GESIValue
    '            Exit For
    '        End If
    '    Next
    '    If BIK_GESIRate <> 0 Then
    '        BIK_GLBGesiAmount = RoundMe2(BIK_GESIValue * 100 / BIK_GESIRate, 2)
    '    End If
    '    ' End If

    'End Sub
    Private Sub D_Calculate_BIK_GESI(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)

        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim BIK_GESIRate As Double
        Dim BIK_GESIValue As Double
        Dim BIK_xGESIValue As Double
        Dim BIK_xValueToCalcFrom As Double
        Dim BIK_ValueToCalcFrom As Double

        Dim BIK_RemainingPeriodsWithGESI As Integer
        BIK_RemainingPeriodsWithGESI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            BIK_RemainingPeriodsWithGESI = 0
        End If

        
        'Dim TodateGESI As Double
        'TodateGESI = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "GD")



        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        BIK_ValueToCalcFrom = Utils.RoundMeUp(FindValueOfFormula(TempDed.CalcFormula))


                        BIK_GESIValue = Ded(i).txtValue.Text
                        BIK_GESIRate = Ded(i).txtValue.Text

                        BIK_GESIValue = BIK_GESIValue / 100 * BIK_ValueToCalcFrom

                        Dim Perc As Double = 0

                        Perc = Ded(i).txtValue.Text
                        BIK_xValueToCalcFrom = Utils.RoundMeUp(Me.FindValueOfFormulaONLYRecuring_ForFuture_BIK_forGESI(TempDed.CalcFormula))
                        Dim RecuringBIK_GESI_Value As Double = 0
                        RecuringBIK_GESI_Value = BIK_xValueToCalcFrom * BIK_GESIRate / 100


                        '**************************************************************************************
                        '''''''''''''' GESI ADD SILEAVE FOR FUTURE PERIODS ''''''''''''''''''''''''''''''''''''

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        '**************************************************************************************
                        'GLB_BIK_GESI_ByTheEndOfTheYear = GLB_BIK_GESI_ByTheEndOfTheYear + BIK_GESIValue * BIK_RemainingPeriodsWithGESI
                        GLB_BIK_GESI_ByTheEndOfTheYear = GLB_BIK_GESI_ByTheEndOfTheYear + RecuringBIK_GESI_Value * BIK_RemainingPeriodsWithGESI



                        '**************************************************************************************
                        'Checking Limits
                        '**************************************************************************************

                        Dim Todate_BIK_GESI As Double
                        Todate_BIK_GESI = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "GT")
                        Dim ActualTotalPaidGesyFromThisemployeer As Double = 0
                        ActualTotalPaidGesyFromThisemployeer = Me.PeriodGesiDValue + Me.GLB_TodateGesi_DED + Todate_BIK_GESI + BIK_GESIValue
                        If ActualTotalPaidGesyFromThisemployeer > GLBLimits.GesiD Then
                            Dim Diff As Double = 0
                            Diff = RoundMe2(ActualTotalPaidGesyFromThisemployeer - GLBLimits.GesiD, 2)
                            BIK_GESIValue = RoundMe2(BIK_GESIValue - Diff, 2)
                            If BIK_GESIValue < 0 Then
                                BIK_GESIValue = 0
                            End If
                        End If

                    Else
                        BIK_ValueToCalcFrom = Utils.RoundMeUp(FindValueOfFormula(TempDed.CalcFormula))


                        BIK_GESIValue = Ded(i).txtValue.Text
                        BIK_GESIRate = 2.65

                        'BIK_GESIValue = BIK_GESIValue / 100 * BIK_ValueToCalcFrom

                        'Dim Perc As Double = 0
                        'Perc = Ded(i).txtValue.Text
                        'BIK_xValueToCalcFrom = Utils.RoundMeUp(Me.FindValueOfFormulaONLYRecuring_ForFuture_BIK_forGESI(TempDed.CalcFormula))

                        '**************************************************************************************
                        '''''''''''''' GESI ADD SILEAVE FOR FUTURE PERIODS ''''''''''''''''''''''''''''''''''''

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        '**************************************************************************************



                        ' GLB_BIK_GESI_ByTheEndOfTheYear = GLB_BIK_GESI_ByTheEndOfTheYear + BIK_GESIValue * BIK_RemainingPeriodsWithGESI
                    End If
                End If
                Exit For
            End If
        Next


        'If Not ForEstimation Then
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = BIK_GESIValue
                Period_BIK_GesiDValue = BIK_GESIValue
                Exit For
            End If
        Next
        If BIK_GESIRate <> 0 Then
            BIK_GLBGesiAmount = RoundMe2(BIK_GESIValue * 100 / BIK_GESIRate, 2)
        End If
        ' End If

    End Sub
   
    Private Sub D_TaxableIncomeANDSIIncomeForCasesOf13NotTaxable(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim ITValue As Double
        Dim ValueToCalcFrom As Double
        Dim Code As String

        Code = Global1.Business.GetDecuctionCodeForIT

        TempDed = New cPrMsTemplateDeductions(GLBEmployee.TemGrp_Code, Code)

        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                ITValue = ValueToCalcFrom
            ElseIf TempDed.TypeMode = "V" Then
                '-----------------------------------------------
                'This is When IncomeTax is a Value From Employee
                'No Calculations are Done 
                '-----------------------------------------------
                ITValue = Ded(i).txtValue.Text
                D_Final(i).MyValue = ITValue
                Exit Sub
            End If
        End If

        Period_TaxableIncome = ITValue

        'For i = 0 To D_Final.Length - 1
        '    Dim DedCod As New cPrMsDeductionCodes(Ded(i).Ded.DedCodCode)
        '    If DedCod.DedTypCode = "SI" Then
        '        If DedCod.DedTypCode = "SI" Then
        '            Period_SIIncome = D_Final(i).MyValue
        '        End If
        '    End If
        'Next
    End Sub
    Private Sub D_CalculateIncomeTax(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)

        ''''''''''''''''''''''''''''''''''''''''''
        S_LITodate = 0
        S_LIPeriod = 0
        S_LIPrevious = 0
        S_DisTodate = 0
        S_DisPeriod = 0
        S_DisPrevious = 0
        S_SIPFMFTodate = 0
        S_SIPFMFPeriod = 0
        S_SIPFMFPrevious = 0
        S_TaxEarnTodate = 0
        S_TaxEarnPeriod = 0
        S_STPrevious = 0
        S_TaxEarnPrevious = 0



        S_13SEstimation = 0
        Dim Total_SPlitSI As Double = 0
        Dim ToDateSplitSI As Double = 0
        ''''''''''''''''''''''''''''''''''''''''''
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim ITValue As Double
        Dim ValueToCalcFrom As Double
        Dim NumberOfTaxablePeriodsTodate As Integer
        Dim CurrentPeriodEarnings As Double
        Dim SalaryEstimation_13_14 As Double = 0

        'Dim RateLimit As Double = 16.67
        Dim RateLimit As Double = Global1.PARAM_TaxRule


        Dim NumberOfWorkedPeriods As Integer
        Dim EarningsToDate As Double = 0
        Dim FirstEmploymentDiscount As Double = 0
        Dim TaxToUse As Double = 0
        Dim UseTax As Boolean = False

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        If TempDed.FromMode = "X" And Ded(i).txtValue.Text <> 0 Then
                            If Ded(i).txtValue.Text = -1 Then
                                ITValue = 0
                            Else
                                ITValue = Ded(i).txtValue.Text
                            End If

                            D_Final(i).MyValue = ITValue
                            TaxTouse = ITValue
                            useTax = True
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula, True)
                            Period_TaxableIncome = ValueToCalcFrom + Emp.OtherIncome3
                            '''' 26/7 for Action
                            Dim EmpDisX = New cPrTxEmployeeDiscounts(Emp.Code, Me.GLBCurrentPeriod.PrdGrpCode)
                            Dim Lifeinsx As Double = 0
                            Dim DiscountsX As Double = 0
                            If EmpDisX.Id > 0 Then
                                Lifeinsx = RoundMe2(EmpDisX.LifeInsurance / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
                                DiscountsX = RoundMe2(EmpDisX.TotalDiscounts / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
                            End If

                            

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            'Dim dsETD As DataSet
                            'dsETD = Global1.Business.GetLifeInsurance_AND_Discounts_ToDate(Emp, GLBCurrentPeriod)
                            'If CheckDataSet(dsETD) Then
                            '    EarningsToDate = DbNullToDouble(dsETD.Tables(0).Rows(0).Item(0))

                            'End If

                            'If Emp.FirstEmployment = "1" Then
                            '    Dim FE As Double = 0
                            '    Dim RecEarnings As Double = 0
                            '    Dim RecBenefits As Double = 0
                            '    Dim Sequence As Integer = 0
                            '    Dim RemPeriods As Integer = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.Sequence + 1
                            '    Dim NormalRemPeriods = GLBCurrentPeriod.NumberOfNormalPeriods - (GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow + 1)

                            '    RecEarnings = GLBRecurringEarning * (NormalRemPeriods)
                            '    RecBenefits = GLBBenefitsRecurringEarning * (NormalRemPeriods)

                            '    If Emp.TerminateDate <> "" Then
                            '        FE = CurrentPeriodEarnings + EarningsToDate
                            '    Else
                            '        FE = (Me.GlbEmpSalary.SalaryValue * (RemPeriods - 1)) + CurrentPeriodEarnings + EarningsToDate + RecEarnings + RecBenefits
                            '    End If


                            '    If FE >= 100000 Then
                            '        FE = FE / 2
                            '    Else
                            '        FE = FE * 20 / 100
                            '        If FE >= 8550 Then
                            '            FE = 8550
                            '        End If
                            '    End If
                            '    'Dim FD As Double
                            '    FirstEmploymentDiscount = RoundMe3(FE / (RemPeriods + NumberOfWorkedPeriods), 2)

                            'End If
                            'Period_FE = FirstEmploymentDiscount
                            'Period_LifeInsurance = Lifeinsx
                            'Period_Discounts = DiscountsX + FirstEmploymentDiscount
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                            'Exit Sub
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula, True)
                            ITValue = ValueToCalcFrom
                            CurrentPeriodEarnings = ITValue
                        Else
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula, True)
                            ITValue = ValueToCalcFrom
                            CurrentPeriodEarnings = ITValue
                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        '-----------------------------------------------
                        'This is When IncomeTax is a Value From Employee
                        'No Calculations are Done 
                        '-----------------------------------------------
                        ITValue = Ded(i).txtValue.Text
                        D_Final(i).MyValue = ITValue
                        Exit Sub
                    End If
                End If
                Exit For
            End If
        Next
        'NumberOfTaxablePeriodsTodate = Me.GLBCurrentPeriod.Sequence
        NumberOfTaxablePeriodsTodate = Global1.Business.GetNumberOfTaxablePeriodsToDate(GLBCurrentPeriod)

        NumberOfWorkedPeriods = Global1.Business.GetWorkedPeriodsUntilNow(Emp.Code, GLBCurrentPeriod.PrdGrpCode)



        Dim Period_SI_PF_MF As Double = 0
        Dim ToDate_SI_PF_MF As Double = 0
        Dim Total_SI_PF_MF As Double = 0

        Dim Period_SI_new As Double = 0
        Dim Previous_SI_new As Double = 0
        Dim ToDate_SI_new As Double = 0
        Dim Total_SI_new As Double = 0
        Dim Portion_SI_new As Double = 0

        Dim Period_MF_new As Double = 0
        Dim ToDate_MF_new As Double = 0
        Dim Total_MF_new As Double = 0
        Dim Portion_MF_new As Double = 0

        Dim Period_PF_new As Double = 0
        Dim ToDate_PF_new As Double = 0
        Dim Total_PF_new As Double = 0
        Dim Previous_PF_new As Double = 0





        Dim ToDate_Union As Double = 0
        Dim LifeIns_Todate As Double = 0
        Dim Period_Union As Double = 0
        Dim LifeIns As Double = 0
        Dim Discounts_Todate As Double = 0
        Dim Discounts As Double = 0
        Dim Total_LifeIns As Double = 0
        Dim Total_Discounts As Double = 0
        'Dim NonTaxable_SI As Double = 0

        Dim ToDate_SI_MF As Double = 0
        Dim Total_SI_MF As Double = 0


        Dim InsurableToDate As Double = 0

        Dim S_Period_SI_PF_MF_LI As Double = 0
        Dim S_Discounts As Double = 0
        Dim S_TaxableEarningToDate As Double = 0

        Dim Previous_SI_PF_MF As Double = 0
        Dim Previous_ST As Double = 0
        Dim Previous_LifeInsurance As Double = 0
        Dim Previous_Discounts As Double = 0
        Dim Previous_Earnings As Double = 0
        Dim Previous_ITValue As Double = 0
        Dim Previous_SI As Double = 0




        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            Previous_SI_PF_MF = Emp.Emp_PrevSIDeduct + Emp.Emp_PrevPFDeduct
            Previous_SI_new = Emp.Emp_PrevSIDeduct
            Previous_PF_new = Emp.Emp_PrevPFDeduct

            Previous_Earnings = Emp.PreviousEarnings
            Previous_ITValue = Emp.Emp_PrevITDeduct
            Previous_LifeInsurance = Emp.PreviousLifeIns
            Previous_Discounts = Emp.PreviousDis
            Previous_ST = Emp.PreviousST
            Previous_SI = Emp.Emp_PrevSIDeduct

        End If


        'Calculate Previous


        For i = 0 To D_Final.Length - 1
            Dim DedCod As New cPrMsDeductionCodes(Ded(i).Ded.DedCodCode)
            'if SI round decimal 0
            If DedCod.DedTypCode = "SI" Or DedCod.DedTypCode = "PF" Or DedCod.DedTypCode = "MF" Then
                Period_SI_PF_MF = Period_SI_PF_MF + D_Final(i).MyValue
                If DedCod.DedTypCode = "SI" Then
                    Period_SIIncome = D_Final(i).MyValue
                    Period_SI_new = D_Final(i).MyValue
                End If
                If DedCod.DedTypCode = "PF" Then
                    Period_PF_new = Period_PF_new + D_Final(i).MyValue
                End If
                If DedCod.DedTypCode = "MF" Then
                    Period_MF_new = Period_MF_new + D_Final(i).MyValue
                End If

                ' ToDate_SI_PF_MF = ToDate_SI_PF_MF + Global1.Business.GetToDate_SI_PF_MF(Emp, DedCod, GLBCurrentPeriod)
            End If
            If DedCod.DedTypCode = "US" Then
                Period_Union = Period_Union + D_Final(i).MyValue
            End If
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'HSDATA
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '  NonTaxable_SI = Period_SIIncome * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim SX As Double = 0
        SX = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "MF")
        ToDate_SI_PF_MF = ToDate_SI_PF_MF + SX
        ToDate_SI_MF = SX
        ToDate_MF_new = SX


        SX = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "PF")
        ToDate_SI_PF_MF = ToDate_SI_PF_MF + SX
        ToDate_PF_new = SX

        SX = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "SI")
        ToDate_SI_PF_MF = ToDate_SI_PF_MF + SX
        ToDate_SI_MF = ToDate_SI_MF + SX
        ToDate_SI_new = SX

        ToDate_Union = Period_Union + Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "US")

        Total_SI_PF_MF = Period_SI_PF_MF + ToDate_SI_PF_MF + Previous_SI_PF_MF
        Total_SI_MF = Period_SIIncome + ToDate_SI_MF + Previous_SI

        Total_SI_new = Period_SI_new + ToDate_SI_new
        Total_MF_new = Period_MF_new + ToDate_MF_new
        Total_PF_new = Period_PF_new + ToDate_PF_new


        'SPLIT DRAKOS
        ToDateSplitSI = Global1.Business.GetToDate_SplitSI(Emp, GLBCurrentPeriod)
        Total_SPlitSI = GLBPeriodSIonSplit + ToDateSplitSI
        Total_SI_PF_MF = Total_SI_PF_MF + Total_SPlitSI

        Total_SI_new = Total_SI_new + Total_SPlitSI
        'END SPLIT DRAKOS

        txtSumPeriodSIPFMF.Text = Period_SI_PF_MF

        Dim ds As DataSet
        ds = Global1.Business.GetLifeInsurance_AND_Discounts_ToDate(Emp, GLBCurrentPeriod)
        If CheckDataSet(ds) Then
            EarningsToDate = DbNullToDouble(ds.Tables(0).Rows(0).Item(0))
            LifeIns_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(1))
            Discounts_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(2))
            InsurableToDate = DbNullToDouble(ds.Tables(0).Rows(0).Item(3))
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''COBALT FIRST EMPLOYMENT ''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''


        If Emp.FirstEmployment = "1" Then
            Dim FE As Double = 0
            Dim RecEarnings As Double = 0
            Dim RecBenefits As Double = 0
            Dim Sequence As Integer = 0
            'Dim RemPeriods As Integer = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.Sequence + 1
            Dim RemPeriods As Integer = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.NumberOfNonTaxablePeriods - GLBCurrentPeriod.Sequence + 1

            Dim NormalRemPeriods = GLBCurrentPeriod.NumberOfNormalPeriods - (GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow + 1)

            'CHANGE 12/03/2019 RECURING Earnings and Ben in Kind means for ALL Remaining Periods
            RecEarnings = GLBRecurringEarning * (NormalRemPeriods)
            RecBenefits = GLBBenefitsRecurringEarning * (NormalRemPeriods)





            If Emp.TerminateDate <> "" Then
                FE = CurrentPeriodEarnings + EarningsToDate
            Else
                FE = (Me.GlbEmpSalary.SalaryValue * (RemPeriods - 1)) + CurrentPeriodEarnings + EarningsToDate + RecEarnings + RecBenefits + (GLBCurrentPeriod.NumberOfNotNormalPeriodsToCome * Me.GlbEmpSalary.SalaryValue)
            End If


            If FE >= Global1.PARAM_FiftyPercAplicableAmount Then
                FE = FE / 2
            Else
                FE = FE * 20 / 100
                If FE >= 8550 Then
                    FE = 8550
                End If
            End If
            'Dim FD As Double
            FirstEmploymentDiscount = RoundMe3(FE / (RemPeriods + NumberOfWorkedPeriods), 2)

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim EmpDis As New cPrTxEmployeeDiscounts(Emp.Code, Me.GLBCurrentPeriod.PrdGrpCode)
        If EmpDis.Id > 0 Then
            LifeIns = RoundMe2(EmpDis.LifeInsurance / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
            Discounts = RoundMe2(EmpDis.TotalDiscounts / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
        End If
        Discounts = Discounts + FirstEmploymentDiscount

        Period_LifeInsurance = LifeIns
        Period_Discounts = Discounts
        Me.txtSumPeriodLF.Text = LifeIns
        Me.txtsumPerioddis.Text = Discounts



        Total_LifeIns = LifeIns + LifeIns_Todate + Previous_LifeInsurance
        'Total_discounts = Discounts + Discounts_Todate + Previous_Discounts
        'S_TaxableEarningToDate = EarningsToDate + CurrentPeriodEarnings + Previous_Earnings + (Emp.OtherIncome3) + (Emp.OtherIncome1 / GLBCurrentPeriod.NumberOfTaxablePeriods) + (Emp.OtherIncome2 / GLBCurrentPeriod.NumberOfTaxablePeriods) + Emp.OtherIncome4  ' * NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)
        S_TaxableEarningToDate = EarningsToDate + CurrentPeriodEarnings + Previous_Earnings + (Emp.OtherIncome3) + (Emp.OtherIncome1 * (NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)) + (Emp.OtherIncome2 * (NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)) + Emp.OtherIncome4 + Me.GetPeriodSplitForTAX  ' * NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)
        ' If Not Global1.GLB_NoAnnualUnits Then

        SalaryEstimation_13_14 = FindSalary()

        'Else
        'Dim SAL1 As Double = FindSalary()
        'Dim AnUnitsUntilNow As Double = Global1.Business.CalculateUnitsFor13(Emp, GLBCurrentPeriod)
        'Dim Total13nthSalaryUnits As Double = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
        'SalaryEstimation_13_14 = SAL1 * (AnUnitsUntilNow / Total13nthSalaryUnits)
        'End If

        ''''''''SalaryEstimation_13_14 = GLBCurrentPeriod.NumberOfNonTaxablePeriods * (SalaryEstimation_13_14 * NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)
        'SalaryEstimation_13_14 = NumberOfTaxablePeriodsTodate * (SalaryEstimation_13_14 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        ''''''''SalaryEstimation_13_14 = NumberOfTaxablePeriodsTodate * (SalaryEstimation_13_14 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / 13)

        SalaryEstimation_13_14 = (NumberOfWorkedPeriods + 1) * (SalaryEstimation_13_14 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Portion Of 13nth Period TaxDeductable amounts
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''
        'Income From Other Sources taxable
        '''''''''''''''''''''''''''''''''''
        Dim DsTaxableFromOther_ToDate As DataSet
        Dim OtherIncome4_13_14_Estimation As Double = 0
        Dim OtherIncome4_13_14_ToDate As Double = 0
        DsTaxableFromOther_ToDate = Global1.Business.GetTaxableFromOther_ToDate(Emp, GLBCurrentPeriod)
        If CheckDataSet(DsTaxableFromOther_ToDate) Then
            OtherIncome4_13_14_ToDate = DbNullToDouble(DsTaxableFromOther_ToDate.Tables(0).Rows(0).Item(0))
        End If
        '''''''OUT 19/11/2014 '''''''''''''''''''''''
        'OtherIncome4_13_14_Estimation = (Emp.OtherIncome4 + OtherIncome4_13_14_ToDate) * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        '''''''''''''''''''''''''''''''''''''''''''''
        OtherIncome4_13_14_Estimation = (NumberOfWorkedPeriods + 1) * (Emp.OtherIncome4 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)

        ' OtherIncome4_13_14_Estimation = OtherIncome4_13_14_Estimation + ((NumberOfWorkedPeriods + 1) * (Me.GetPeriodSplitForTAX * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods))

        'get out 2018 split issues
        OtherIncome4_13_14_Estimation = OtherIncome4_13_14_Estimation + ((NumberOfWorkedPeriods + 1) * (Me.GetPeriodSplitForTAX1314 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods))

        '''''''''''''''''''''''''''''''''''
        'Social Incurance
        '''''''''''''''''''''''''''''''''''
        Dim Portion_SI_MF_LIns As Double = 0
        '2015 Portion_SI_MF_LIns = (Total_SI_MF + Total_LifeIns) * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        Portion_SI_MF_LIns = (Total_SI_MF) * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        Portion_SI_new = (Total_SI_new) * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        Portion_MF_new = (Total_MF_new - Period_MF_new) * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)


        '''''''''''''''''''''''''''''''''''
        'Special TAX
        '''''''''''''''''''''''''''''''''''
        Dim ToDateSpecialTax_13_14 As Double = 0

        ToDateSpecialTax_13_14 = Global1.Business.GetToDate_SpecialTax(Emp, GLBCurrentPeriod, "EX")
        ToDateSpecialTax_13_14 = ToDateSpecialTax_13_14 + Period_SpecialTaxValue
        ToDateSpecialTax_13_14 = ToDateSpecialTax_13_14 * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)

        '''''''''''''''''''''''''''''''''''
        'Medical Fund
        '''''''''''''''''''''''''''''''''''


        If Emp.TerminateDate <> "" Then
            If CDate(Emp.TerminateDate) <= GLBCurrentPeriod.DateTo Then
                SalaryEstimation_13_14 = 0
                OtherIncome4_13_14_ToDate = 0
                Portion_SI_MF_LIns = 0
                Portion_SI_new = 0
                Portion_MF_new = 0
                ToDateSpecialTax_13_14 = 0
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' END OF Portion Of 13nth Period TaxDeductable amounts
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        '2015-S_TaxableEarningToDate = S_TaxableEarningToDate + SalaryEstimation_13_14 + OtherIncome4_13_14_Estimation - Portion_SI_MF_LIns - ToDateSpecialTax_13_14

        S_TaxableEarningToDate = S_TaxableEarningToDate + SalaryEstimation_13_14 + OtherIncome4_13_14_Estimation - ToDateSpecialTax_13_14
        'S_TaxableEarningToDate = S_TaxableEarningToDate + SalaryEstimation_13_14 + OtherIncome4_13_14_Estimation


        ' S_TaxableEarningToDate = S_TaxableEarningToDate + SalaryEstimation_13_14 + OtherIncome4_13_14_Estimation

        Me.txtsumEarningstodate.Text = EarningsToDate
        Me.txtsumPeriodearnings.Text = CurrentPeriodEarnings
        Me.txtsumEstimate1314.Text = SalaryEstimation_13_14
        Me.txtSumTaxableEarningsToDate.Text = S_TaxableEarningToDate



        Period_TaxableIncome = ITValue + Emp.OtherIncome3
        'savvas 28/09/2010
        If Period_TaxableIncome = 0 Then
            ITValue = 0
        Else
            'end savvas
            Dim OneSixth As Double
            Dim Total_SI_PF_MF_LI As Double = 0
            Dim ToDateSpecialTax As Double
            ToDateSpecialTax = Global1.Business.GetToDate_SpecialTax(Emp, GLBCurrentPeriod, "EX")
            ToDateSpecialTax = ToDateSpecialTax + Period_SpecialTaxValue

            S_Discounts = Discounts_Todate + Discounts + Previous_Discounts

            S_TaxableEarningToDate = S_TaxableEarningToDate - S_Discounts - ToDate_Union - (ToDateSpecialTax + Previous_ST)


            'S_TaxableEarningToDate = S_TaxableEarningToDate - S_Discounts - ToDate_Union - (ToDateSpecialTax + Previous_ST + ToDateSpecialTax_13_14)
            OneSixth = S_TaxableEarningToDate * RateLimit / 100
            '-2015 Total_SI_PF_MF_LI = Total_SI_PF_MF + Total_LifeIns
            Total_SI_PF_MF_LI = Total_SI_PF_MF + Total_LifeIns + Portion_SI_MF_LIns


            '-------------------------------------------------------------------------------
            'This is the change for 1.5% medical AND PF 10%
            '-------------------------------------------------------------------------------
            Dim X_Total_SI_PF_MF_LI As Double
            Dim MF_Limit As Double
            Dim PF_Limit As Double
            Dim Total_AND_Portion_MF As Double

            Total_AND_Portion_MF = Total_MF_new + Portion_MF_new
            MF_Limit = 1.5 / 100 * S_TaxableEarningToDate
            If Total_AND_Portion_MF > MF_Limit Then
                Total_AND_Portion_MF = MF_Limit
            End If

            PF_Limit = 10 / 100 * S_TaxableEarningToDate
            If Total_PF_new > PF_Limit Then
                Total_PF_new = PF_Limit
            End If

            X_Total_SI_PF_MF_LI = Total_SI_new + Total_PF_new + Total_AND_Portion_MF + Total_LifeIns + Portion_SI_new


            'If RoundMe2(X_Total_SI_PF_MF_LI, 2) <> RoundMe2(Total_SI_PF_MF_LI, 2) Then
            '    MsgBox(Emp.Code & " " & X_Total_SI_PF_MF_LI & " " & Total_SI_PF_MF_LI)

            'End If
            '-------------------------------------------------------------------------------

            Dim XOneSix As String = ""
            'If Total_SI_PF_MF_LI > OneSixth Then
            '    S_Period_SI_PF_MF_LI = OneSixth
            '    XOneSix = 1
            'Else
            '    '-2015 S_Period_SI_PF_MF_LI = Total_SI_PF_MF + Total_LifeIns
            '    S_Period_SI_PF_MF_LI = Total_SI_PF_MF + Total_LifeIns + Portion_SI_MF_LIns
            '    XOneSix = 0
            'End If

            If X_Total_SI_PF_MF_LI > OneSixth Then
                S_Period_SI_PF_MF_LI = OneSixth
                XOneSix = 1
            Else
                '-2015 S_Period_SI_PF_MF_LI = Total_SI_PF_MF + Total_LifeIns
                S_Period_SI_PF_MF_LI = X_Total_SI_PF_MF_LI
                XOneSix = 0
            End If


            Me.txtsumToDateLF.Text = Total_LifeIns
            Me.txtSumToDateDisc.Text = S_Discounts
            Me.txtSumTotalSIPFMF.Text = Total_SI_PF_MF
            Me.txtSumTotalSIPFMFLI.Text = X_Total_SI_PF_MF_LI
            Me.txtToDateSpecialTax.Text = ToDateSpecialTax

            Me.txtOneSixthRule.Text = XOneSix



            Dim AmountToCheck = S_TaxableEarningToDate - S_Period_SI_PF_MF_LI '- S_Discounts - ToDate_Union - ToDateSpecialTax
            Me.txtSumAmountToCheck.Text = AmountToCheck
            Dim DsTax As DataSet
            DsTax = Global1.Business.GetAllPrSsTaxTable
            Dim TaxBracket As Double
            Dim TAX As Double = 0
            Dim RemAmount As Double = AmountToCheck
            Dim PrevRemAmount As Double
            Dim TaxPercentage As Double

            If CheckDataSet(DsTax) Then
                For i = 0 To DsTax.Tables(0).Rows.Count - 1
                    TaxBracket = DbNullToInt(DsTax.Tables(0).Rows(i).Item(2))
                    'If Not Global1.GLB_NoAnnualUnits Then
                    TaxBracket = TaxBracket * (NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)
                    'Else
                    'TaxBracket = TaxBracket * (NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTotalPeriods)
                    'End If
                    TaxPercentage = DbNullToDouble(DsTax.Tables(0).Rows(i).Item(3))
                    PrevRemAmount = RemAmount
                    RemAmount = RemAmount - TaxBracket
                    If RemAmount <= 0 Then
                        Dim XX As Double
                        XX = (PrevRemAmount * TaxPercentage / 100)
                        TAX = TAX + (PrevRemAmount * TaxPercentage / 100)
                        Exit For
                    End If
                    Dim XY As Double
                    XY = TAX + (TaxBracket * TaxPercentage / 100)
                    TAX = TAX + (TaxBracket * TaxPercentage / 100)
                Next
            Else
                MsgBox("Cannot Calculate Income Tax, tax Table is missing, Please contact Insoft Limited", MsgBoxStyle.Critical)
            End If

            ITValue = RoundMe2(TAX, 2)
            Dim S_ITValueToDate As Double
            S_ITValueToDate = Global1.Business.GetITValueToDate(Emp, Dedu, GLBCurrentPeriod)
            S_ITValueToDate = S_ITValueToDate + Previous_ITValue
            Me.txtsumTaxMustPayUntilNow.Text = ITValue
            Me.txtSumTaxPaid.Text = S_ITValueToDate

            ITValue = ITValue - (S_ITValueToDate)
            Me.txtSumPeriodTax.Text = ITValue

            'emp.Emp_PrevITDeduct
            End If
            If ITValue < 0 Then
            'If Not Global1.PARAM_Allow_NegativeTAX Then
            If Not Me.CBAllowNegativeTax.Checked Then
                ITValue = 0
            Else
                MsgBox("Tax for Employee " & Emp.Code & " - " & Emp.FullName & " is negative", MsgBoxStyle.Information)
            End If
        End If


        If UseTax Then
            ITValue = TaxToUse
        End If
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = ITValue
                Exit For
            End If
        Next

    End Sub
    Private Function NEW_EXTRAPOLATION_CalculationOfIncomeTax(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByRef UseFixedITValue As Boolean, ByVal OnlyRecuring As Boolean) As Double

        ''''''''''''''''''''''''''''''''''''''''''
        Dim SI_Display As Double = 0
        Dim PF_display As Double = 0
        Dim LI_display As Double = 0
        Dim Dis_display As Double = 0
        Dim PenF_display As Double = 0
        Dim Decr_display As Double = 0
        Dim WidF_display As Double = 0
        Dim FE_display As Double = 0
        Dim MF_display As Double = 0
        Dim MF_LimitedDisplay As Double = 0
        Dim PF_LimitedDisplay As Double = 0
        Dim GESI_Display As Double = 0
        Dim GESI_BIK_Display As Double = 0
        Dim GESI_Limit_Display As Double = 0

        Dim Union_display As Double = 0
        Dim Onesix_display As Double = 0
        '''''''''''''''''''''''''''''''''
        Dim Period_MF As Double = 0
        Dim Period_PF As Double = 0
        Dim Period_GESI As Double = 0
        Dim Period_BIK_GESI As Double = 0

        ''''''''''''''''''''''''''''''''''''''''''
        GLBTaxWithoutBIK = 0
        S_LITodate = 0
        S_LIPeriod = 0
        S_LIPrevious = 0
        S_DisTodate = 0
        S_DisPeriod = 0
        S_DisPrevious = 0
        S_SIPFMFTodate = 0
        S_SIPFMFPeriod = 0
        S_SIPFMFPrevious = 0
        S_TaxEarnTodate = 0
        S_TaxEarnPeriod = 0
        S_STPrevious = 0
        S_TaxEarnPrevious = 0
        S_GESID_Previous = 0
        S_Union_Previous = 0


        Dim FixedItValue As Double = 0
        'Dim UseFixedItValue As Boolean = False

        S_13SEstimation = 0
        Dim Total_SPlitSI As Double = 0
        Dim ToDate_SI_Split As Double = 0
        ''''''''''''''''''''''''''''''''''''''''''
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim ITValue As Double
        Dim ValueToCalcFrom As Double
        Dim NumberOfTaxablePeriodsTodate As Integer
        Dim CurrentPeriodEarnings As Double = 0
        Dim SalaryEstimation_13_14 As Double = 0
        'Dim RateLimit As Double = 16.67
        Dim RateLimit As Double = Global1.PARAM_TaxRule
        Dim NumberOfWorkedPeriods1 As Integer
        Dim NumberOfTaxableWorkedPeriods As Integer

        Dim AnnualPrivateMedical As Double = 0
        Dim AnnualPrivatePensionfund As Double = 0

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        If TempDed.FromMode = "X" And Ded(i).txtValue.Text <> 0 Then
                            If Ded(i).txtValue.Text = -1 Then
                                ITValue = 0
                            Else
                                ITValue = Ded(i).txtValue.Text
                            End If

                            D_Final(i).MyValue = ITValue
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula, True)
                            Period_TaxableIncome = ValueToCalcFrom + Emp.OtherIncome3
                            '''' 26/7 for Action
                            Dim EmpDisX As New cPrTxEmployeeDiscounts(Emp.Code, Me.GLBCurrentPeriod.PrdGrpCode)
                            Dim Lifeinsx As Double = 0
                            Dim DiscountsX As Double = 0

                            If EmpDisX.Id > 0 Then
                                Lifeinsx = RoundMe2(EmpDisX.LifeInsurance / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
                                DiscountsX = RoundMe2(EmpDisX.TotalDiscounts / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
                            End If

                            AnnualPrivateMedical = EmpDisX.Medical
                            PeriodExtraMedicalValue = AnnualPrivateMedical

                            AnnualPrivatePensionfund = EmpDisX.PensionFund
                            PeriodExtraPensionFundValue = AnnualPrivatePensionfund

                            Period_LifeInsurance = Lifeinsx
                            Period_Discounts = DiscountsX
                            '''''
                            UseFixedITValue = True
                            FixedItValue = ITValue

                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula, True)
                            ITValue = ValueToCalcFrom
                            CurrentPeriodEarnings = ITValue

                        Else
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula, True)
                            ITValue = ValueToCalcFrom
                            CurrentPeriodEarnings = ITValue
                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        '-----------------------------------------------
                        'This is When IncomeTax is a Value From Employee
                        'No Calculations are Done 
                        '-----------------------------------------------
                        ITValue = Ded(i).txtValue.Text
                        D_Final(i).MyValue = ITValue
                        Exit Function
                    End If
                End If
                Exit For
            End If
        Next
        'NumberOfTaxablePeriodsTodate = Me.GLBCurrentPeriod.Sequence
        NumberOfTaxablePeriodsTodate = Global1.Business.GetNumberOfTaxablePeriodsToDate(GLBCurrentPeriod)

        'NumberOfWorkedPeriods1 = Global1.Business.GetWorkedPeriodsUntilNowTaxOrNoTax(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
        NumberOfWorkedPeriods1 = Global1.Business.GetWorkedPeriodsUntilNow(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
        NumberOfTaxableWorkedPeriods = Global1.Business.GetWorkedTaxablePeriodsUntilNow(Emp.Code, GLBCurrentPeriod.PrdGrpCode)



        ' Dim Period_SI_PF_MF As Double = 0
        ' Dim ToDate_SI_PF_MF As Double = 0

        Dim Period_SI As Double = 0
        Dim ToDate_SI As Double = 0
        Dim ToDate_PF As Double = 0
        Dim ToDate_MF As Double = 0
        Dim ToDate_GESI As Double = 0
        Dim ToDate_BIK_GESI As Double = 0

        Dim ToDate_DN As Double = 0
        Dim Total_DN As Double = 0


        Dim ToDate_PenF As Double = 0
        Dim ToDate_WidF As Double = 0


        Dim Total_PenF As Double = 0
        Dim Total_WidF As Double = 0


        'Dim Total_SI_PF_MF As Double = 0
        Dim Total_SI As Double = 0
        Dim Total_PF As Double = 0
        Dim Total_MF As Double = 0
        Dim Total_GESI As Double = 0
        Dim Total_BIK_GESI As Double = 0

        Dim ToDate_Union As Double = 0
        Dim LifeIns_Todate As Double = 0
        Dim Period_Union As Double = 0
        Dim LifeIns As Double = 0
        Dim Discounts_Todate As Double = 0
        Dim FE_Todate As Double = 0



       

        Dim Discounts As Double = 0
        Dim Total_LifeIns As Double = 0
        Dim Total_Discounts As Double = 0
        'Dim NonTaxable_SI As Double = 0

        Dim ToDate_SI_MF As Double = 0
        Dim Total_SI_MF As Double = 0

        Dim EarningsToDate As Double = 0
        Dim insurableToDate As Double = 0

        Dim S_Period_SI_PF_MF_LI As Double = 0
        Dim S_Discounts As Double = 0
        Dim S_Decrease As Double = 0
        Dim S_PensionFund As Double = 0
        Dim S_WidowFund As Double = 0
        Dim S_TaxableEarningToDate As Double = 0
        Dim S_InsurableEarningToDate As Double = 0



        'Dim Previous_SI_PF_MF As Double = 0
        Dim Previous_SI As Double = 0
        Dim Previous_PF As Double = 0
        Dim Previous_MF As Double = 0
        Dim Previous_GESI As Double = 0
        Dim Previous_ST As Double = 0
        Dim Previous_PenF As Double = 0
        Dim Previous_Union As Double = 0

        Dim Previous_LifeInsurance As Double = 0
        Dim Previous_Discounts As Double = 0
        Dim Previous_Earnings As Double = 0
        Dim Previous_ITValue As Double = 0


        ' Dim ToDate_SI As Double = 0




        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            'Previous_SI_PF_MF = Emp.Emp_PrevSIDeduct + Emp.Emp_PrevPFDeduct
            Previous_SI = Emp.Emp_PrevSIDeduct
            Previous_PF = Emp.Emp_PrevPFDeduct
            Previous_MF = Emp.PrevMedFund
            Previous_PenF = Emp.PrevPensionFund


            Previous_Earnings = Emp.PreviousEarnings
            Previous_ITValue = Emp.Emp_PrevITDeduct
            Previous_LifeInsurance = Emp.PreviousLifeIns
            Previous_Discounts = Emp.PreviousDis
            Previous_ST = Emp.PreviousST
            Previous_SI = Emp.Emp_PrevSIDeduct
            Previous_GESI = Emp.PreviousGesiD
            Previous_Union = Emp.PreviousUnion


        End If


        'Calculate Previous


        For i = 0 To D_Final.Length - 1
            Dim DedCod As New cPrMsDeductionCodes(Ded(i).Ded.DedCodCode)
            If DedCod.DedTypCode = "SI" Or DedCod.DedTypCode = "PF" Or DedCod.DedTypCode = "MF" Or DedCod.DedTypCode = "GD" Or DedCod.DedTypCode = "GT" Then
                '  Period_SI_PF_MF = Period_SI_PF_MF + D_Final(i).MyValue
                If DedCod.DedTypCode = "SI" Then
                    Period_SIIncome = D_Final(i).MyValue
                    Period_SI = D_Final(i).MyValue
                End If
                If DedCod.DedTypCode = "PF" Then
                    Period_PF = Period_PF + D_Final(i).MyValue

                End If
                If DedCod.DedTypCode = "MF" Then
                    Period_MF = Period_MF + D_Final(i).MyValue
                End If
                If DedCod.DedTypCode = "GD" Then
                    Period_GESI = Period_GESI + D_Final(i).MyValue
                End If
                If DedCod.DedTypCode = "GT" Then
                    Period_BIK_GESI = Period_BIK_GESI + D_Final(i).MyValue
                End If
            End If

            If DedCod.DedTypCode = "US" Then
                Period_Union = Period_Union + D_Final(i).MyValue
            End If
        Next

        Dim SX As Double = 0
        Dim SX2 As Double = 0
        Dim SX3 As Double = 0
        Dim SX4 As Double = 0
        Dim SX5 As Double = 0
        Dim SX6 As Double = 0

        SX = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "MF")
        'ToDate_SI_PF_MF = ToDate_SI_PF_MF + SX
        ToDate_MF = ToDate_MF + SX
        ToDate_SI_MF = +SX
        MF_display = SX


        SX = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "PF")
        'ToDate_SI_PF_MF = ToDate_SI_PF_MF + SX
        ToDate_PF = ToDate_PF + SX
        PF_display = SX

        SX2 = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "DN")
        ToDate_DN = ToDate_DN + SX2
        Decr_display = SX

        SX3 = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "PN")
        ToDate_PenF = ToDate_PenF + SX3
        PenF_display = SX3


        SX4 = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "WO")
        ToDate_WidF = ToDate_WidF + SX4
        WidF_display = SX4

        SX5 = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "GD")
        ToDate_GESI = ToDate_GESI + SX5
        GESI_Display = SX5

        'Addition BIK_Gesy  Semptember 2019
        ' xxxxx()
        SX6 = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "GT")
        ToDate_BIK_GESI = ToDate_BIK_GESI + SX6
        GESI_BIK_Display = SX6
        'End of Addition



        SX = Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "SI")

        SI_Display = SX

        'ToDate_SI_PF_MF = ToDate_SI_PF_MF + SX
        ToDate_SI = ToDate_SI + SX
        ToDate_SI_MF = ToDate_SI_MF + SX

        ToDate_Union = Period_Union + Global1.Business.GetToDate_SI_PF_MF(Emp, GLBCurrentPeriod, "US") + Previous_Union
        Union_display = ToDate_Union

        'Total_SI_PF_MF = Period_SI_PF_MF + ToDate_SI_PF_MF + Previous_SI_PF_MF
        Total_SI = Period_SI + ToDate_SI + Previous_SI
        Total_PF = Period_PF + ToDate_PF + Previous_PF
        Total_MF = Period_MF + ToDate_MF + Previous_MF
        Total_GESI = Period_GESI + ToDate_GESI + Previous_GESI '+ Emp.GesyFromSplit
        Total_BIK_GESI = Period_BIK_GESI + ToDate_BIK_GESI



        Total_SI_MF = Period_SIIncome + ToDate_SI_MF + Previous_SI

        Total_DN = Me.Period_Decrease + ToDate_DN
        Total_PenF = Me.Period_PensionFund + ToDate_PenF + Previous_PenF
        Total_WidF = Me.Period_WidowFund + ToDate_WidF

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'SPLIT DRAKOS **************************************************************
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Global1.PARAM_SplitIsEnabled Then
            CalculateSplitForNewTax(Emp)
            '  CalculateSplitForGESY(Emp)
        End If

        ' Dim Period_Split As Double
        ' Dim ToDate_Split As Double
        ' Dim Period_SI_Split As Double
        ' Dim Period_Split13 As Double

        'Period_Split = Me.GetPeriodSplitForTAX
        'Period_Split13 = Me.GetPeriodSplitForTAX1314

        'ToDate_Split = Global1.Business.GetToDate_PeriodSplit(Emp, GLBCurrentPeriod)
        'Period_SI_Split = GLBPeriodSIonSplit
        'ToDate_SI_Split = Global1.Business.GetToDate_SplitSI(Emp, GLBCurrentPeriod)

        'Total_SPlitSI = Period_SI_Split + ToDate_SI_Split
        ' Total_SI = Total_SI + Total_SPlitSI
        'END SPLIT DRAKOS
        '****************************************************************************
        '**************************************************************************

        txtSumPeriodSIPFMF.Text = Period_SI + Period_PF + Period_MF
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Display Period and Todate
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        SI_Display = SI_Display + Period_SIIncome
        PF_display = PF_display + Period_PF + Previous_PF
        PenF_display = PenF_display + Period_PensionFund
        Decr_display = Decr_display + Period_Decrease
        MF_display = MF_display + Period_MF
        GESI_Display = GESI_Display + Period_GESI + Emp.GesyFromSplit
        GESI_BIK_Display = GESI_BIK_Display + Period_BIK_GESI

        'Union_display is added above

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Dim ds As DataSet
        ds = Global1.Business.GetLifeInsurance_AND_Discounts_ToDate(Emp, GLBCurrentPeriod)
        If CheckDataSet(ds) Then
            EarningsToDate = DbNullToDouble(ds.Tables(0).Rows(0).Item(0))
            LifeIns_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(1))
            Discounts_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(2))
            insurableToDate = DbNullToDouble(ds.Tables(0).Rows(0).Item(3))
            FE_Todate = DbNullToDouble(ds.Tables(0).Rows(0).Item(4))

            Dis_display = Discounts_Todate

            Discounts_Todate = Discounts_Todate + FE_Todate
        End If



        ''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''COBALT FIRST EMPLOYMENT ''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim FirstEmploymentDiscount As Double = 0

        Dim FE As Double = 0
        Dim RecEarnings As Double = 0
        Dim RecEarnings14 As Double = 0

        Dim RecPensionDeduction As Double = 0
        Dim RecBenefits As Double = 0
        Dim RecBenefits14 As Double = 0
        Dim Sequence As Integer = 0

        '*******************************************************************************************************************************
        'Dim RemPeriods As Integer = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.Sequence + 1
        '********************************************************************************************************************************

        Dim RemPeriods As Integer = GLBCurrentPeriod.TOTALPeriods - GLBCurrentPeriod.Sequence + 1
        '*******************************************************************************************************

        Dim RemTaxablePeriods As Integer = GLBCurrentPeriod.NumberOfTaxablePeriods - (GLBCurrentPeriod.NumberOfTaxablePeriodsUntilNow) '- NumberOfTaxableWorkedPeriods)

        Dim NormalRemPeriods = GLBCurrentPeriod.NumberOfNormalPeriods - (GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow + 1)
        Dim RemNotNormalPeriods As Integer

        RemNotNormalPeriods = RemPeriods - (NormalRemPeriods + 1)
        ' RemNotNormalPeriods = GLBCurrentPeriod.NumberOf_NOT_NormalPeriods - GLBCurrentPeriod.NumberOf_NOT_NormalPeriodsUntilNow
        If RemNotNormalPeriods < 0 Then
            RemNotNormalPeriods = 0
        End If

        'CHANGE 12/03/2019 RECURING Earnings and Ben in Kind means for ALL Remaining Periods
        
        RecEarnings = GLBRecurringEarning * (NormalRemPeriods)
        RecBenefits = GLBBenefitsRecurringEarning * (NormalRemPeriods)
        GLBRemainingReccuringBIK = RecBenefits
        If Global1.param_Andrikian13PeriodLast Then
            If NormalRemPeriods = -1 Then
                RecEarnings = 0
                RecBenefits = 0
            End If
        End If

        RecEarnings14 = GLBRecurringEarning14 * (NormalRemPeriods + RemNotNormalPeriods)
        RecBenefits14 = GLBBenefitsRecurringEarning14 * (NormalRemPeriods + RemNotNormalPeriods)


        ' END OF CHANGE



        RecPensionDeduction = GLBPensionDeduction * (NormalRemPeriods + RemNotNormalPeriods)


        Dim SalAndColaNormal As Double = 0
        Dim SalAndColaNOTNormal As Double = 0
        Dim Ratio1314 As Double = 1
        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            Ratio1314 = GLBCurrentPeriod.RatioTotalPeriodsToWorkPeriods(Emp)
        End If

        Dim EstimatedEarningsByTheEndOfYear As Double
        Dim EstimatedInsurableEarningsByTheEndOfYear As Double
        Dim PensionByTheendOftheYear As Double

        PensionByTheendOftheYear = Emp.OtherIncome3
        If Emp.TerminateDate <> "" Then
            FE = CurrentPeriodEarnings + EarningsToDate + Emp.OtherIncome3
        Else
            If RemPeriods = 0 Then
                FE = CurrentPeriodEarnings + PensionByTheendOftheYear + EarningsToDate + RecEarnings + RecBenefits + RecPensionDeduction + RecEarnings14 + RecBenefits14
            Else
                'SalAndColaNormal = (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue) * (NormalRemPeriods)
                'SalAndColaNOTNormal = (RemNotNormalPeriods) * Ratio1314 * (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue)


                'SalAndColaNormal = (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue + GLBEmployee.BonusOnsalary + xxxxxGLBSILeave) * (NormalRemPeriods)
                'SalAndColaNOTNormal = (RemNotNormalPeriods) * Ratio1314 * (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue + GLBEmployee.BonusOnsalary + xxxxxGLBSILeave)
                If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
                    'Tax Calculation for Hourly **************************************************************************************************************
                    SalAndColaNormal = (Me.GLBGrossSalaryForHourlyRateForTaxCalculation + GLBCOLAValue + GLBEmployee.BonusOnsalary + Me.GLBRecuringValueOfSILeave) * (NormalRemPeriods)
                    SalAndColaNOTNormal = (RemNotNormalPeriods) * Ratio1314 * (Me.GLBGrossSalaryForHourlyRateForTaxCalculation + GLBCOLAValue + GLBEmployee.BonusOnsalary + Me.GLBRecuringValueOfSILeave)
                Else
                    SalAndColaNormal = (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue + GLBEmployee.BonusOnsalary + Me.GLBRecuringValueOfSILeave) * (NormalRemPeriods)
                    SalAndColaNOTNormal = (RemNotNormalPeriods) * Ratio1314 * (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue + GLBEmployee.BonusOnsalary + Me.GLBRecuringValueOfSILeave)
                End If

                PensionByTheendOftheYear = PensionByTheendOftheYear * (RemTaxablePeriods - 1)
                FE = (PensionByTheendOftheYear + SalAndColaNormal + SalAndColaNOTNormal) + CurrentPeriodEarnings + EarningsToDate + RecEarnings + RecBenefits + Emp.OtherIncome3 + RecPensionDeduction + RecEarnings14 + RecBenefits14

            End If
        End If

        EstimatedEarningsByTheEndOfYear = FE - (CurrentPeriodEarnings + EarningsToDate + Emp.OtherIncome3)

        Dim PeriodRecInsEarnings As Double
        Dim PeriodRecInsEarnings1314 As Double

        If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
            'Tax Calculation for Hourly **************************************************************************************************************
            PeriodRecInsEarnings = Me.GLBGrossSalaryForHourlyRateForTaxCalculation + GLBCOLAValue + GLBRecurringEarning + GLBBenefitsRecurringEarning + GLBEmployee.BonusOnsalary + GLBSILeave + GLBRecurringEarning14 + GLBBenefitsRecurringEarning14
            PeriodRecInsEarnings1314 = (Me.GLBGrossSalaryForHourlyRateForTaxCalculation + GLBCOLAValue + GLBEmployee.BonusOnsalary + GLBSILeave) * Ratio1314
            '**********************************************************************************************
        Else
            PeriodRecInsEarnings = Me.GlbEmpSalary.SalaryValue + GLBCOLAValue + GLBRecurringEarning + GLBBenefitsRecurringEarning + GLBEmployee.BonusOnsalary + GLBSILeave + GLBRecurringEarning14 + GLBBenefitsRecurringEarning14
            PeriodRecInsEarnings1314 = (Me.GlbEmpSalary.SalaryValue + GLBCOLAValue + GLBEmployee.BonusOnsalary + GLBSILeave) * Ratio1314
        End If

        Dim SILimit As Double
        SILimit = RoundMe2(Global1.GlbLimits.InsurableMth + (GlbSILeavePerc / 100 * Global1.GlbLimits.InsurableMth), 2)
        If PeriodRecInsEarnings > SILimit Then
            PeriodRecInsEarnings = SILimit
        End If
        If PeriodRecInsEarnings1314 > SILimit Then
            PeriodRecInsEarnings1314 = SILimit
        End If

        EstimatedInsurableEarningsByTheEndOfYear = (PeriodRecInsEarnings * NormalRemPeriods) + (PeriodRecInsEarnings1314 * GLBCurrentPeriod.NumberOfNotNormalPeriodsToCome)

        'If EstimatedInsurableEarningsByTheEndOfYear > GLBLimits.InsurableAnnual Then
        '    EstimatedInsurableEarningsByTheEndOfYear = GLBLimits.InsurableAnnual
        'End If

        GLBPercentageOfFE = 0
        If Emp.FirstEmployment = "1" Then

            'If (FE >= Global1.PARAM_FiftyPercAplicableAmount Or Emp.Force50Percent = "1") And Emp.f50PercOff = "0" Then
            ' Dim FEforCalc As Double
            ' FEforCalc = FE - Emp.OtherIncome2
            If (FE >= Emp.FEControlAmount Or Emp.Force50Percent = "1") And Emp.f50PercOff = "0" Then
                FE = FE / 2
                GLBPercentageOfFE = 50
            Else
                GLBPercentageOfFE = 20
                FE = FE * 20 / 100
                If FE >= 8550 Then
                    FE = 8550
                    If Global1.PARAM_Warningon20PercLimit Then
                        If Not OnlyRecuring Then
                            MsgBox("Employee with Code " & Emp.Code & " Has reached the 20% Discount Limit", MsgBoxStyle.Information)
                        End If
                    End If
                End If
            End If
            'Dim FD As Double
            'If RemPeriods = 0 Then
            ' FirstEmploymentDiscount = RoundMe3(FE / (1 + NumberOfWorkedPeriods1), 2)
            'Else
            FE_display = FE

            FE = FE - FE_Todate
            FirstEmploymentDiscount = RoundMe3(FE / (RemTaxablePeriods), 2) '+ NumberOfWorkedPeriods1), 2)
            '  FirstEmploymentDiscount = RoundMe3(FE / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)

            'End If



            'FirstEmploymentDiscount = RoundMe3(FE / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim EmpDis As New cPrTxEmployeeDiscounts(Emp.Code, Me.GLBCurrentPeriod.PrdGrpCode)
        If EmpDis.Id > 0 Then
            LifeIns = RoundMe2(EmpDis.LifeInsurance / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
            Discounts = RoundMe2(EmpDis.TotalDiscounts / GLBCurrentPeriod.NumberOfTaxablePeriods, 2)
            Dis_display = Discounts

            AnnualPrivateMedical = EmpDis.Medical
            PeriodExtraMedicalValue = AnnualPrivateMedical

            AnnualPrivatePensionfund = EmpDis.PensionFund
            PeriodExtraPensionFundValue = AnnualPrivatePensionfund

        End If
        Discounts = Discounts + FirstEmploymentDiscount

        Period_LifeInsurance = LifeIns
        Period_Discounts = Discounts
        Period_FE = FirstEmploymentDiscount


        Me.txtSumPeriodLF.Text = LifeIns
        Me.txtsumPerioddis.Text = Discounts
        ' Me.txtsumPerioddis.Text = FirstEmploymentDiscount



        Total_LifeIns = LifeIns + LifeIns_Todate + Previous_LifeInsurance
        LI_display = Total_LifeIns

        S_TaxableEarningToDate = EarningsToDate + CurrentPeriodEarnings + Previous_Earnings + (Emp.OtherIncome3) + Emp.OtherIncome1 + Emp.OtherIncome2 + Emp.OtherIncome4 '+ Me.GetPeriodSplitForTAX  ' * NumberOfTaxablePeriodsTodate / GLBCurrentPeriod.NumberOfTaxablePeriods)
        S_InsurableEarningToDate = insurableToDate

        SalaryEstimation_13_14 = FindSalary() + GLBSILeave
        SalaryEstimation_13_14 = (NumberOfWorkedPeriods1 + 1) * (SalaryEstimation_13_14 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)
        Dim DsTaxableFromOther_ToDate As DataSet
        Dim OtherIncome4_13_14_Estimation As Double = 0
        Dim OtherIncome4_13_14_ToDate As Double = 0
        DsTaxableFromOther_ToDate = Global1.Business.GetTaxableFromOther_ToDate(Emp, GLBCurrentPeriod)
        If CheckDataSet(DsTaxableFromOther_ToDate) Then
            OtherIncome4_13_14_ToDate = DbNullToDouble(DsTaxableFromOther_ToDate.Tables(0).Rows(0).Item(0))
        End If

        OtherIncome4_13_14_Estimation = (NumberOfWorkedPeriods1 + 1) * (Emp.OtherIncome4 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)


        'Get OUT 2018 when split was done
        '*************************************************
        'OtherIncome4_13_14_Estimation = OtherIncome4_13_14_Estimation + ((NumberOfWorkedPeriods1 + 1) * (Me.GetPeriodSplitForTAX1314 * GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods))
        ' ************************************************

        '''''''''''''''''''''''''''''''''''
        'Social Incurance
        '''''''''''''''''''''''''''''''''''
        Dim Portion_SI_MF_LIns As Double = 0
        'Portion_SI_MF_LIns = (Total_SI_MF) * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)

        '''''''''''''''''''''''''''''''''''
        'Special TAX
        '''''''''''''''''''''''''''''''''''
        Dim ToDateSpecialTax_13_14 As Double = 0

        ToDateSpecialTax_13_14 = Global1.Business.GetToDate_SpecialTax(Emp, GLBCurrentPeriod, "EX")
        ToDateSpecialTax_13_14 = ToDateSpecialTax_13_14 + Period_SpecialTaxValue
        ToDateSpecialTax_13_14 = ToDateSpecialTax_13_14 * (GLBCurrentPeriod.NumberOfNonTaxablePeriods / GLBCurrentPeriod.NumberOfTaxablePeriods)

        '''''''''''''''''''''''''''''''''''
        'Medical Fund
        '''''''''''''''''''''''''''''''''''



        SalaryEstimation_13_14 = 0
        OtherIncome4_13_14_ToDate = 0
        Portion_SI_MF_LIns = 0
        ToDateSpecialTax_13_14 = 0

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' END OF Portion Of 13nth Period TaxDeductable amounts
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        S_TaxableEarningToDate = S_TaxableEarningToDate + OtherIncome4_13_14_Estimation - ToDateSpecialTax_13_14



        Me.txtsumEarningstodate.Text = EarningsToDate
        Me.txtsumPeriodearnings.Text = CurrentPeriodEarnings
        Me.txtsumEstimate1314.Text = SalaryEstimation_13_14
        Me.txtSumTaxableEarningsToDate.Text = S_TaxableEarningToDate

        'If OnlyRecuring Then
        '    Me.txtROEarningstodate.Text = EarningsToDate
        '    Me.txtROPeriodearnings.Text = CurrentPeriodEarnings
        '    Me.txtROTaxableEarningsToDate.Text = S_TaxableEarningToDate
        'Else

        '    Me.txtCPEarningstodate.Text = EarningsToDate
        '    Me.txtCPPeriodearnings.Text = CurrentPeriodEarnings
        '    Me.txtCPTaxableEarningsToDate.Text = S_TaxableEarningToDate
        'End If



        Period_TaxableIncome = ITValue + Emp.OtherIncome3

        'savvas 28/09/2010
        ' If Period_TaxableIncome = 0 Then
        GLB_PeriodTaxable = Period_TaxableIncome
        '  ITValue = 0
        ' Else
        'end savvas
        Dim OneSixth As Double
        Dim Total_SI_PF_MF_LI As Double = 0



        Dim ToDateSpecialTax As Double

        Dim SI_ByTheEndOfYear As Double
        Dim PF_ByTheEndOfYear As Double
        Dim PenF_ByTheEndOfYear As Double
        Dim WidF_ByTheEndOfYear As Double

        Dim MF_ByTheEndOfYear As Double
        Dim UNION_ByTheEndOfYear As Double
        Dim LI_ByTheEndOfYear As Double
        Dim DI_ByTheEndOfYear As Double
        Dim FE_ByTheEndOfYear As Double
        Dim DN_ByTheEndOfYear As Double

        Dim SI_Split_ByTheEndOfYear As Double
        'Dim GESI_ByTheEndOfYear As Double

        ToDateSpecialTax = Global1.Business.GetToDate_SpecialTax(Emp, GLBCurrentPeriod, "EX")
        ToDateSpecialTax = ToDateSpecialTax + Period_SpecialTaxValue
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '                   'Estimation Exprabolation
        '---------------------------------------------------------------------




        S_TaxableEarningToDate = S_TaxableEarningToDate + EstimatedEarningsByTheEndOfYear


        Dim MissedPeriods As Boolean = False
        If GLBCurrentPeriod.NumberOfTaxablePeriodsUntilNow - NumberOfTaxableWorkedPeriods <> 0 Then
            MissedPeriods = True
        End If


        ' If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year And MissedPeriods Then
        ' SI_ByTheEndOfYear = Calculate_SI_byTheEndOfYear(EstimatedInsurableEarningsByTheEndOfYear, ToDate_SI + Period_SIIncome, S_InsurableEarningToDate)
        'Else
        'SI_ByTheEndOfYear = Calculate_SI_byTheEndOfYearFull(EstimatedEarningsByTheEndOfYear, ToDate_SI + Period_SIIncome)
        SI_ByTheEndOfYear = Calculate_SI_ByTheEndOfYearFull2(EstimatedInsurableEarningsByTheEndOfYear, ToDate_SI + Period_SIIncome)
        SI_Split_ByTheEndOfYear = 0
        If Global1.PARAM_SplitIsEnabled Then

            SI_Split_ByTheEndOfYear = Calculate_SI_Split_ByTheEndOfYearFull(EstimatedInsurableEarningsByTheEndOfYear, ToDate_SI + Period_SIIncome, SI_ByTheEndOfYear)
            If SI_Split_ByTheEndOfYear < 0 Then
                SI_Split_ByTheEndOfYear = 0
            End If

        End If
        SI_ByTheEndOfYear = SI_ByTheEndOfYear + SI_Split_ByTheEndOfYear

        If Me.txt_Split_Total.Text = "" Then
            Me.txt_Split_Total.Text = 0
        End If

        S_TaxableEarningToDate = S_TaxableEarningToDate + Me.txt_Split_Total.Text '- Me.txt_Split_ToDate.Text

        If OnlyRecuring Then
            Me.txtROTotalTaxable.Text = Format(S_TaxableEarningToDate, "0.00")
        Else
            Me.txtCPTotalTaxable.Text = Format(S_TaxableEarningToDate, "0.00")
        End If

        'End If




        PF_ByTheEndOfYear = GLB_PF_ByTheEndOfTheYear + AnnualPrivatePensionfund
        MF_ByTheEndOfYear = GLB_MF_ByTheEndOfTheYear + AnnualPrivateMedical
        UNION_ByTheEndOfYear = GLB_UNION_ByTheEndOfTheYear
        DN_ByTheEndOfYear = GLB_DN_ByTheEndOfTheYear
        PenF_ByTheEndOfYear = GLB_PenF_ByTheEndOfTheYear
        WidF_ByTheEndOfYear = GLB_WidF_ByTheEndOfTheYear



        LI_ByTheEndOfYear = Calculate_LI_byTheEndOfYear(EstimatedEarningsByTheEndOfYear, EmpDis, NumberOfTaxablePeriodsTodate)
        DI_ByTheEndOfYear = Calculate_DI_byTheEndOfYear(EstimatedEarningsByTheEndOfYear, EmpDis, NumberOfTaxablePeriodsTodate)
        FE_ByTheEndOfYear = Calculate_FE_byTheEndOfYear(EstimatedEarningsByTheEndOfYear, FirstEmploymentDiscount, NumberOfTaxablePeriodsTodate)


        DI_ByTheEndOfYear = DI_ByTheEndOfYear + FE_ByTheEndOfYear

        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------
        '---------------------------------------------------------------------


        S_Discounts = Discounts_Todate + Discounts + Previous_Discounts

        S_Decrease = GLB_DN_ByTheEndOfTheYear + Total_DN
        S_PensionFund = GLB_PenF_ByTheEndOfTheYear + Total_PenF
        S_WidowFund = GLB_WidF_ByTheEndOfTheYear + Total_WidF


        '-------------------------------------------------------------------------
        'Correction SAVVAS 24/10/2017 Pension Fund and WidowFund in 1/6 Rule
        '-------------------------------------------------------------------------

        Dim S_Gross As Double = S_TaxableEarningToDate

        'S_TaxableEarningToDate = S_TaxableEarningToDate - S_Discounts - DI_ByTheEndOfYear - ToDate_Union - UNION_ByTheEndOfYear - (ToDateSpecialTax + Previous_ST)
        S_TaxableEarningToDate = S_TaxableEarningToDate - S_Discounts - DI_ByTheEndOfYear - (ToDateSpecialTax + Previous_ST)
        S_TaxableEarningToDate = S_TaxableEarningToDate - S_Decrease



        '-------------------------------------------------------------------------
        'Correction SAVVAS 24/10/2017 Pension Fund and WidowFund in 1/6 Rule
        '-------------------------------------------------------------------------
        'S_TaxableEarningToDate = S_TaxableEarningToDate - S_PensionFund
        'S_TaxableEarningToDate = S_TaxableEarningToDate - S_widowFund
        '-------------------------------------------------------------------------



        OneSixth = S_TaxableEarningToDate * RateLimit / 100


        '------------------------------------------------------------------------
        'CHECK NE LIMIS : MEDICAL 1.5% ON GROSS, PRF 10% ON GROSS
        '------------------------------------------------------------------------
        Dim MF_Total_PLUS_ByTheEndOfYear As Double
        Dim MFLimit As Double
        MF_Total_PLUS_ByTheEndOfYear = Total_MF + MF_ByTheEndOfYear
        MFLimit = RoundMe2(PARAM_MFLimit / 100 * S_Gross, 2)
        If MF_Total_PLUS_ByTheEndOfYear > MFLimit Then
            MF_Total_PLUS_ByTheEndOfYear = MFLimit
        End If

        Dim PF_Total_PLUS_ByTheEndOfYear As Double
        Dim PFLimit As Double
        PF_Total_PLUS_ByTheEndOfYear = Total_PF + PF_ByTheEndOfYear
        PFLimit = RoundMe2(PARAM_PFLimit / 100 * S_Gross, 2)
        If PF_Total_PLUS_ByTheEndOfYear > PFLimit Then
            PF_Total_PLUS_ByTheEndOfYear = PFLimit
        End If

        '------------------------------------------------------------------------

        '------------------------------------------------------------------------


        'Total_SI_PF_MF_LI = Total_SI + Total_PF + Total_LifeIns + Portion_SI_MF_LIns + SI_ByTheEndOfYear + LI_ByTheEndOfYear + PF_ByTheEndOfYear + MF_Total_PLUS_ByTheEndOfYear

        'Dim xTotal_SI_PF_MF_LI As Double

        Total_SI_PF_MF_LI = Total_SI + Total_LifeIns + Portion_SI_MF_LIns + SI_ByTheEndOfYear + LI_ByTheEndOfYear + PF_Total_PLUS_ByTheEndOfYear + MF_Total_PLUS_ByTheEndOfYear + S_PensionFund + S_WidowFund + ToDate_Union + UNION_ByTheEndOfYear
        '****************************************************************************
        '*# Change for GESY Limit.
        ' If GESY Deduction and BIK Gesy Deduction > Limit then TaxDeductable is the Limit
        Dim PreviusGesyDeduction As Double = 0
        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            PreviusGesyDeduction = Emp.PreviousGesiD
            GESI_Display = GESI_Display + GLB_GESI_ByTheEndOfTheYear + Emp.PreviousGesiD
            GESI_BIK_Display = GESI_BIK_Display + GLB_BIK_GESI_ByTheEndOfTheYear
        Else
            PreviusGesyDeduction = 0
            GESI_Display = GESI_Display + GLB_GESI_ByTheEndOfTheYear
            GESI_BIK_Display = GESI_BIK_Display + GLB_BIK_GESI_ByTheEndOfTheYear
        End If
        Dim CheckGesy As Double = 0
        CheckGesy = Period_GESI + ToDate_GESI + GLB_GESI_ByTheEndOfTheYear + Period_BIK_GESI + ToDate_BIK_GESI + GLB_BIK_GESI_ByTheEndOfTheYear + Emp.GesyFromSplit + PreviusGesyDeduction
        If CheckGesy >= GLBLimits.GesiD Then
            CheckGesy = GLBLimits.GesiD
            GESI_Limit_Display = CheckGesy
        End If
        Total_SI_PF_MF_LI = Total_SI_PF_MF_LI + CheckGesy
        '* the following 2 lines were commented out
        'Total_SI_PF_MF_LI = Total_SI_PF_MF_LI + ToDate_GESI + GLB_GESI_ByTheEndOfTheYear
        'Total_SI_PF_MF_LI = Total_SI_PF_MF_LI + ToDate_BIK_GESI + GLB_BIK_GESI_ByTheEndOfTheYear + Emp.GesyFromSplit
        '******************************************************************************



        PenF_display = S_PensionFund
        WidF_display = S_WidowFund
        Decr_display = S_Decrease
        Dis_display = S_Discounts + DI_ByTheEndOfYear
        Union_display = ToDate_Union + UNION_ByTheEndOfYear
        LI_display = Total_LifeIns + LI_ByTheEndOfYear
        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            SI_Display = SI_Display + SI_ByTheEndOfYear + Emp.Emp_PrevSIDeduct
            'GESI_Display = GESI_Display + GLB_GESI_ByTheEndOfTheYear + Emp.PreviousGesiD
            'GESI_BIK_Display = GESI_BIK_Display + GLB_BIK_GESI_ByTheEndOfTheYear
        Else
            SI_Display = SI_Display + SI_ByTheEndOfYear
            'GESI_Display = GESI_Display + GLB_GESI_ByTheEndOfTheYear
            'GESI_BIK_Display = GESI_BIK_Display + GLB_BIK_GESI_ByTheEndOfTheYear
        End If

        PF_display = PF_display + PF_ByTheEndOfYear
        MF_display = MF_display + MF_ByTheEndOfYear
        MF_LimitedDisplay = MF_Total_PLUS_ByTheEndOfYear
        PF_LimitedDisplay = PF_Total_PLUS_ByTheEndOfYear



        Dim XOneSix As String = ""
        If Total_SI_PF_MF_LI > OneSixth Then
            S_Period_SI_PF_MF_LI = OneSixth
            XOneSix = 1
            Onesix_display = OneSixth
        Else
            'S_Period_SI_PF_MF_LI = Total_SI_PF_MF + Total_LifeIns + Portion_SI_MF_LIns + SI_ByTheEndOfYear + LI_ByTheEndOfYear + PF_ByTheEndOfYear + MF_ByTheEndOfYear
            'S_Period_SI_PF_MF_LI = Total_SI + Total_PF + Total_MF + Total_LifeIns + Portion_SI_MF_LIns + SI_ByTheEndOfYear + LI_ByTheEndOfYear + PF_ByTheEndOfYear + MF_ByTheEndOfYear + S_PensionFund + S_WidowFund + ToDate_Union + UNION_ByTheEndOfYear
            S_Period_SI_PF_MF_LI = Total_SI + Total_LifeIns + Portion_SI_MF_LIns + SI_ByTheEndOfYear + LI_ByTheEndOfYear + PF_Total_PLUS_ByTheEndOfYear + MF_Total_PLUS_ByTheEndOfYear + S_PensionFund + S_WidowFund + ToDate_Union + UNION_ByTheEndOfYear
            ' *****************************************
            '*CHANGE HERE $$$
            'The following 2 lines were commented out
            S_Period_SI_PF_MF_LI = S_Period_SI_PF_MF_LI + CheckGesy
            'S_Period_SI_PF_MF_LI = S_Period_SI_PF_MF_LI + Total_GESI + GLB_GESI_ByTheEndOfTheYear
            'S_Period_SI_PF_MF_LI = S_Period_SI_PF_MF_LI + Total_BIK_GESI + GLB_BIK_GESI_ByTheEndOfTheYear + Emp.GesyFromSplit

            '******************************************
            XOneSix = 0
            Onesix_display = 0
        End If


        Me.txtsumToDateLF.Text = Total_LifeIns
        Me.txtSumToDateDisc.Text = S_Discounts
        Me.txtSumTotalSIPFMF.Text = Total_SI + Total_PF + Total_MF + S_PensionFund + S_WidowFund + ToDate_Union + UNION_ByTheEndOfYear
        Me.txtSumTotalSIPFMFLI.Text = Total_SI_PF_MF_LI
        Me.txtToDateSpecialTax.Text = ToDateSpecialTax

        Me.txtOneSixthRule.Text = XOneSix

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' CALCULATION OF TAX
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim AmountToCheck = S_TaxableEarningToDate - S_Period_SI_PF_MF_LI
        Me.txtSumAmountToCheck.Text = AmountToCheck
        Dim DsTax As DataSet
        DsTax = Global1.Business.GetAllPrSsTaxTable
        Dim TaxBracket As Double
        Dim TAX As Double = 0
        Dim RemAmount As Double = AmountToCheck
        Dim PrevRemAmount As Double
        Dim TaxPercentage As Double

        If CheckDataSet(DsTax) Then
            For i = 0 To DsTax.Tables(0).Rows.Count - 1
                TaxBracket = DbNullToInt(DsTax.Tables(0).Rows(i).Item(2))
                TaxPercentage = DbNullToDouble(DsTax.Tables(0).Rows(i).Item(3))
                PrevRemAmount = RemAmount
                RemAmount = RemAmount - TaxBracket
                If RemAmount <= 0 Then
                    Dim XX As Double
                    XX = (PrevRemAmount * TaxPercentage / 100)
                    TAX = TAX + (PrevRemAmount * TaxPercentage / 100)
                    Exit For
                End If
                Dim XY As Double
                XY = TAX + (TaxBracket * TaxPercentage / 100)
                TAX = TAX + (TaxBracket * TaxPercentage / 100)
            Next
        Else
            MsgBox("Cannot Calculate Income Tax, tax Table is missing, Please contact Insoft Limited", MsgBoxStyle.Critical)
        End If
        Dim RemainingTaxablePeriods As Integer

        RemainingTaxablePeriods = GLBCurrentPeriod.NumberOfTaxablePeriods - NumberOfTaxablePeriodsTodate
        ITValue = RoundMe2(TAX, 2)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' END OF CALCULATION OF TAX
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Calculation of TAX Without BIK
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim AmountToCheck_WOutBIK = S_TaxableEarningToDate - S_Period_SI_PF_MF_LI - BIK_GLBGesiAmount + Period_BIK_GesiDValue
        'Dim TaxBracket_WOutBIK As Double
        'Dim TAX_WOutBIK As Double = 0
        'Dim RemAmount_WOutBIK As Double = AmountToCheck_WOutBIK
        'Dim PrevRemAmount_WOutBIK As Double
        'Dim TaxPercentage_WOutBIK As Double
        'Dim ITValue_WOutBIK As Double = 0
        'If CheckDataSet(DsTax) Then
        '    For i = 0 To DsTax.Tables(0).Rows.Count - 1
        '        TaxBracket_WOutBIK = DbNullToInt(DsTax.Tables(0).Rows(i).Item(2))
        '        TaxPercentage_WOutBIK = DbNullToDouble(DsTax.Tables(0).Rows(i).Item(3))
        '        PrevRemAmount_WOutBIK = RemAmount_WOutBIK
        '        RemAmount_WOutBIK = RemAmount_WOutBIK - TaxBracket_WOutBIK
        '        If RemAmount_WOutBIK <= 0 Then
        '            Dim XX As Double
        '            XX = (PrevRemAmount_WOutBIK * TaxPercentage_WOutBIK / 100)
        '            TAX_WOutBIK = TAX_WOutBIK + (PrevRemAmount_WOutBIK * TaxPercentage_WOutBIK / 100)
        '            Exit For
        '        End If
        '        Dim XY As Double
        '        XY = TAX_WOutBIK + (TaxBracket_WOutBIK * TaxPercentage_WOutBIK / 100)
        '        TAX_WOutBIK = TAX_WOutBIK + (TaxBracket_WOutBIK * TaxPercentage_WOutBIK / 100)
        '    Next
        'Else
        '    MsgBox("Cannot Calculate Income Tax, tax Table is missing, Please contact Insoft Limited", MsgBoxStyle.Critical)
        'End If
        'Dim RemainingTaxablePeriods_WOutBIK As Integer

        'RemainingTaxablePeriods_WOutBIK = GLBCurrentPeriod.NumberOfTaxablePeriods - NumberOfTaxablePeriodsTodate
        'ITValue_WOutBIK = RoundMe2(TAX_WOutBIK, 2)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'END OF Calculation of TAX Without BIK
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim S_ITValueToDate As Double
        S_ITValueToDate = Global1.Business.GetITValueToDate(Emp, Dedu, GLBCurrentPeriod)
        S_ITValueToDate = S_ITValueToDate + Previous_ITValue
        Me.txtsumTaxMustPayUntilNow.Text = ITValue

        Me.txtInterCompanyTax.Text = "0.00"


        Me.txtSumTaxPaid.Text = S_ITValueToDate
        If OnlyRecuring Then
            Me.txtORtaxableearnings.Text = RoundMe2(AmountToCheck, 2)
            Me.txtORTotalTax.Text = ITValue
            Me.txtORPaidTax.Text = S_ITValueToDate
        Else
            Me.txtCPtaxableearnings.Text = RoundMe2(AmountToCheck, 2)
            Me.txtCPTotalTax.Text = ITValue
            Me.txtCPPaidTax.Text = S_ITValueToDate

        End If
        If Global1.PARAM_SplitIsEnabled Then
            S_ITValueToDate = S_ITValueToDate + GLBEmployee.TaxForSplit
            Me.txtInterCompanyTax.Text = GLBEmployee.TaxForSplit
        End If

        ITValue = ITValue - (S_ITValueToDate)
        '  ITValue_WOutBIK = ITValue_WOutBIK - (S_ITValueToDate)
        ' GLBTaxWithoutBIK = ITValue_WOutBIK

        If OnlyRecuring Then
            Me.txtORRemainingTax.Text = Format(ITValue, "0.00")
        Else
            Me.txtCPRemainingTax.Text = Format(ITValue, "0.00")
        End If

        If UseFixedITValue Then
            ITValue = FixedItValue
        End If

        If OnlyRecuring Then
            Me.txtROSI.Text = Format(SI_Display, "0.00")
            Me.txtROPF.Text = Format(PF_display, "0.00")
            Me.txtROLI.Text = Format(LI_display, "0.00")
            Me.txtRODI.Text = Format(Dis_display, "0.00")
            Me.txtROPenF.Text = Format(PenF_display, "0.00")
            Me.txtRODec.Text = Format(Decr_display, "0.00")
            Me.txtROXO.Text = Format(WidF_display, "0.00")
            Me.txtROFE.Text = Format(FE_display, "0.00")
            Me.txtROMF.Text = Format(MF_display, "0.00")
            Me.txtROUnion.Text = Format(Union_display, "0.00")
            Me.txtROonesixt.Text = Format(Onesix_display, "0.00")
            'Me.txtRtotalSIPFMFLI.Text = Format(SI_Display + PF_LimitedDisplay + LI_display + MF_LimitedDisplay + GESI_Display + GESI_BIK_Display, "0.00")
            Me.txtRtotalSIPFMFLI.Text = Format(SI_Display + PF_LimitedDisplay + LI_display + MF_LimitedDisplay + CheckGesy, "0.00")
            Me.txtRmedLimit.Text = Format(MF_LimitedDisplay, "0.00")
            Me.txtRPFLimit.Text = Format(PF_LimitedDisplay, "0.00")
            Me.txtROGesi.Text = Format(GESI_Display, "0.00")
            Me.txtRO_BIK_GESI.Text = Format(GESI_BIK_Display, "0.00")
            Me.txtRGesyLimit.Text = Format(GESI_Limit_Display, "0.00")

            Me.txtRmedLimit.BackColor = Color.Yellow
            Me.txtRPFLimit.BackColor = Color.Yellow
            Me.txtRGesyLimit.BackColor = Color.Yellow
            Me.txtROonesixt.BackColor = Color.Yellow

            If Me.txtRmedLimit.Text <> "0.00" Then
                '  Me.txtRmedLimit.BackColor = Color.Tomato
            End If
            If Me.txtRPFLimit.Text <> "0.00" Then
                '  Me.txtRPFLimit.BackColor = Color.Tomato
            End If
            If Me.txtRGesyLimit.Text <> "0.00" Then
                Me.txtRGesyLimit.BackColor = Color.Tomato
            End If
            If Me.txtROonesixt.Text <> "0.00" Then
                Me.txtROonesixt.BackColor = Color.Tomato
            End If
        Else
            Me.txtCPSI.Text = Format(SI_Display, "0.00")
            Me.txtCPPF.Text = Format(PF_display, "0.00")
            Me.txtCPLI.Text = Format(LI_display, "0.00")
            Me.txtCPDI.Text = Format(Dis_display, "0.00")
            Me.txtCPPenF.Text = Format(PenF_display, "0.00")
            Me.txtCPDec.Text = Format(Decr_display, "0.00")
            Me.txtCPXO.Text = Format(WidF_display, "0.00")
            Me.txtCPFE.Text = Format(FE_display, "0.00")
            Me.txtCPMF.Text = Format(MF_display, "0.00")
            Me.txtCPUnion.Text = Format(Union_display, "0.00")
            Me.txtCPOnesixt.Text = Format(Onesix_display, "0.00")
            'Me.txtCTotalSIPFMFLI.Text = Format(SI_Display + PF_LimitedDisplay + LI_display + MF_LimitedDisplay + GESI_Display + GESI_BIK_Display, "0.00")
            Me.txtCTotalSIPFMFLI.Text = Format(SI_Display + PF_LimitedDisplay + LI_display + MF_LimitedDisplay + CheckGesy, "0.00")
            Me.txtCMedLimit.Text = Format(MF_LimitedDisplay, "0.00")
            Me.txtCPFLimit.Text = Format(PF_LimitedDisplay, "0.00")
            Me.txtCPGesi.Text = Format(GESI_Display, "0.00")
            Me.txtCP_BIK_GESI.Text = Format(GESI_BIK_Display, "0.00")
            Me.txtCGesyLimit.Text = Format(GESI_Limit_Display, "0.00")


            Me.txtCMedLimit.BackColor = Color.Yellow
            Me.txtCPFLimit.BackColor = Color.Yellow
            Me.txtCGesyLimit.BackColor = Color.Yellow
            Me.txtCPOnesixt.BackColor = Color.Yellow



            If Me.txtCMedLimit.Text <> "0.00" Then
                '  Me.txtCMedLimit.BackColor = Color.Tomato
            End If
            If Me.txtCPFLimit.Text <> "0.00" Then
                '   Me.txtCPFLimit.BackColor = Color.Tomato
            End If
            If Me.txtCGesyLimit.Text <> "0.00" Then
                Me.txtCGesyLimit.BackColor = Color.Tomato
            End If
            If Me.txtCPOnesixt.Text <> "0.00" Then
                Me.txtCPOnesixt.BackColor = Color.Tomato
            End If



        End If


        Return ITValue

        Debug.WriteLine(OnlyRecuring & " " & S_TaxableEarningToDate)



        '  End If
    End Function
    Private Sub D_CalculateIncomeTax_Method2(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal OnlyRecuring As Boolean)
        Dim ITValue As Double
        Dim i As Integer
        Dim MonthDiff As Double
        Dim UseFixedITValue As Boolean = False
        Dim RemainingTaxablePeriods As Integer
        Dim NumberOfTaxablePeriodsTodate As Integer = 0
        Dim TAX_WithoutBIK As Double = 0
        Dim BIK_TAX As Double = 0

        NumberOfTaxablePeriodsTodate = Global1.Business.GetNumberOfTaxablePeriodsToDate(GLBCurrentPeriod)
        RemainingTaxablePeriods = GLBCurrentPeriod.NumberOfTaxablePeriods - NumberOfTaxablePeriodsTodate

        Me.txtORRemTaxPeriods.Text = (RemainingTaxablePeriods + 1)



        ITValue = NEW_EXTRAPOLATION_CalculationOfIncomeTax(Emp, EmpDed, Dedu, UseFixedITValue, OnlyRecuring)
       
        If OnlyRecuring Then
            GLBITValueWithRecuring = ITValue
            Me.txtORPeriodTax.Text = Format(ITValue / (RemainingTaxablePeriods + 1), "0.00")
        Else
            GLBITValueWithNORecuring = ITValue
            Me.txtCPPeriodTax.Text = Format(ITValue / (RemainingTaxablePeriods + 1), "0.00")
            Dim tPeriodTaxWOUTBIK As Double = 0
            'tPeriodTaxWOUTBIK = Format((ITValue - Me.GLBTaxWithoutBIK) / (RemainingTaxablePeriods + 1), "0.00")
            ' tPeriodTaxWOUTBIK = Format((ITValue - Me.GLBTaxWithoutBIK), "0.00")
            'MsgBox(tPeriodTaxWOUTBIK)
            If Not UseFixedITValue Then
                If GLBITValueWithNORecuring = GLBITValueWithRecuring Then
                    MonthDiff = 0
                Else
                    MonthDiff = GLBITValueWithNORecuring - Math.Abs(GLBITValueWithRecuring)
                End If
                If GLBITValueWithNORecuring < 0 And GLBITValueWithRecuring < 0 Then
                    'Negative and Negative - Correct
                    'ITValue = (GLBITValueWithNORecuring / (RemainingTaxablePeriods + 1))
                    ITValue = GLBITValueWithNORecuring
                ElseIf GLBITValueWithNORecuring < 0 And GLBITValueWithRecuring > 0 Then
                    'Negative and no Negative - Correct
                    ITValue = GLBITValueWithNORecuring
                    'ITValue = (GLBITValueWithNORecuring / (RemainingTaxablePeriods + 1))

                    'MonthDiff = Math.Abs(GLBITValueWithNORecuring) - GLBITValueWithRecuring
                    'ITValue = (GLBITValueWithRecuring / (RemainingTaxablePeriods + 1)) + MonthDiff

                ElseIf GLBITValueWithNORecuring > 0 And GLBITValueWithRecuring < 0 Then
                    'Correct
                    'ITValue = GLBITValueWithNORecuring
                    'Change Christos Rodeler 04/02/2024

                    ITValue = Format(GLBITValueWithNORecuring / (RemainingTaxablePeriods + 1), "0.00")

                    'ITValue = (GLBITValueWithNORecuring / (RemainingTaxablePeriods + 1))
                    'GLBITValueWithRecuring = 0
                    'MonthDiff = GLBITValueWithNORecuring
                    'ITValue = MonthDiff

                    'ITValue = (GLBITValueWithRecuring / (RemainingTaxablePeriods + 1)) + MonthDiff

                Else
                    If MonthDiff < 0 Then
                        If Me.GLB_PeriodTaxable = 0 Then
                            ITValue = 0
                        Else
                            ITValue = (GLBITValueWithNORecuring / (RemainingTaxablePeriods + 1))
                        End If
                    Else
                        If Me.GLB_PeriodTaxable = 0 Then
                            ITValue = 0
                        Else
                            ITValue = (GLBITValueWithRecuring / (RemainingTaxablePeriods + 1)) + MonthDiff
                        End If
                    End If


                End If
                Me.txtORDifference.Text = Format(MonthDiff, "0.00")


                If Emp.TerminateDate <> "" Then
                    ITValue = GLBITValueWithNORecuring
                End If
                ' xxx()
                'ITValue = ITValue / (RemainingTaxablePeriods + 1)
            End If

            Me.txtORPeriodUnitsRatio.Text = 1

            If Not UseFixedITValue Then

                If Global1.PARAM_PAYEProRata Then
                    If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                        If Emp.StartDate.Month = GLBCurrentPeriod.DateFrom.Month Then
                            If GLBCurrentPeriod.DateFrom <> Emp.StartDate Then
                                Dim ActualUnits As Double = Me.txtActualUnits.Text
                                Dim PeriodNormalUnits As Double = GLBCurrentPeriod.PeriodUnits
                                If ActualUnits < PeriodNormalUnits Then
                                    'If CStr(GLBCurrentPeriod.PrdCod_Number) <> CStr("12") Then
                                    ITValue = RoundMe2(ITValue * ActualUnits / PeriodNormalUnits, 2)
                                    Me.txtORPeriodUnitsRatio.Text = RoundMe2(ActualUnits / PeriodNormalUnits, 2)
                                    'Else

                                    'End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If


            If ITValue < 0 Then
                'If Not Global1.PARAM_Allow_NegativeTAX Then
                If Not Me.CBAllowNegativeTax.Checked Then
                    ITValue = 0
                Else
                    MsgBox("Tax for Employee " & Emp.Code & " - " & Emp.FullName & " is negative", MsgBoxStyle.Information)
                End If
            End If
            Me.txtSumPeriodTax.Text = ITValue
            Me.txtFinalPeriodTax.Text = Format(ITValue, "0.00")

            For i = 0 To D_Final.Length - 1
                If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                    D_Final(i).MyValue = ITValue
                    Exit For
                End If
            Next
        End If


    End Sub
    Private Function Calculate_SI_byTheEndOfYear(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal SIAmountUntilToday As Double, ByVal InsurableToDate As Double) As Double
        Dim previous_SIDeduction As Double = 0
        Dim SIByTheendOfTheYear As Double = 0

        Dim EstimatedYearSI As Double = 0
        Dim AnnoualSILimit As Double



        SIByTheendOfTheYear = (EstimatedEarningsByTheEndOfYear + InsurableToDate + Me.Period_InsurableIncome) * GLBSIPercentage / 100


        AnnoualSILimit = Global1.GlbLimits.InsurableAnnual * GLBSIPercentage / 100

        If GLBEmployee.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            previous_SIDeduction = GLBEmployee.Emp_PrevSIDeduct
        End If
        Dim Yeartotal As Double
        Yeartotal = SIByTheendOfTheYear + previous_SIDeduction



        If Yeartotal > AnnoualSILimit Then
            Dim dif As Double
            dif = Yeartotal - AnnoualSILimit
            Yeartotal = Yeartotal - dif

        End If
        EstimatedYearSI = Yeartotal - previous_SIDeduction - SIAmountUntilToday

        'If EstimatedYearSI > AnnoualSILimit Then
        '    'SIByTheendOfTheYear = SIByTheendOfTheYear - (EstimatedYearSI - annoualSILimit)
        '    SIByTheendOfTheYear = AnnoualSILimit - (previous_SIDeduction + SIAmountUntilToday)
        'Else
        '    SIByTheendOfTheYear = SIByTheendOfTheYear - (previous_SIDeduction + SIAmountUntilToday)
        'End If

        Return EstimatedYearSI



    End Function
    Private Function Calculate_SI_byTheEndOfYearFull(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal SIAmountUntilToday As Double) As Double
        Dim previous_SIDeduction As Double = 0
        Dim SIByTheendOfTheYear As Double = 0

        Dim EstimatedYearSI As Double = 0
        Dim AnnoualSILimit As Double



        SIByTheendOfTheYear = (EstimatedEarningsByTheEndOfYear) * GLBSIPercentage / 100


        AnnoualSILimit = Global1.GlbLimits.InsurableAnnual * GLBSIPercentage / 100
        If GLBEmployee.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            previous_SIDeduction = GLBEmployee.Emp_PrevSIDeduct
        End If
        EstimatedYearSI = SIByTheendOfTheYear + previous_SIDeduction + SIAmountUntilToday

        If EstimatedYearSI > AnnoualSILimit Then
            'SIByTheendOfTheYear = SIByTheendOfTheYear - (EstimatedYearSI - annoualSILimit)
            SIByTheendOfTheYear = AnnoualSILimit - (previous_SIDeduction + SIAmountUntilToday)
        End If

        Return SIByTheendOfTheYear



    End Function
    Private Function Calculate_SI_ByTheEndOfYearFull2(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal SIAmountUntilToday As Double) As Double
        Dim previous_SIDeduction As Double = 0
        Dim SIByTheendOfTheYear As Double = 0

        Dim EstimatedYearSI As Double = 0
        Dim AnnoualSILimit As Double


        'SIByTheendOfTheYear = GLBRemainingPeriodsWithSI * Me.Period_ONLY_Recuring_SI
        If GLBEmployee.TerminateDate = "" Then
            SIByTheendOfTheYear = GLBRemainingPeriodsWithSI * SIValueForRemainingPeriods
        End If

        Dim InsurableAnnual As Double = 0
        InsurableAnnual = RoundMe2(Global1.GlbLimits.InsurableAnnual + (Global1.GlbLimits.InsurableAnnual * GlbSILeavePerc / 100), 2)
        AnnoualSILimit = RoundMe2(InsurableAnnual * GLBSIPercentage / 100, 2)

        If GLBEmployee.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            previous_SIDeduction = GLBEmployee.Emp_PrevSIDeduct
        End If
        EstimatedYearSI = SIByTheendOfTheYear + previous_SIDeduction + SIAmountUntilToday
        If GlbSILeavePerc <> 0 Then
            If EstimatedYearSI > AnnoualSILimit Then
                'SIByTheendOfTheYear = SIByTheendOfTheYear - (EstimatedYearSI - annoualSILimit)
                SIByTheendOfTheYear = AnnoualSILimit - (previous_SIDeduction + SIAmountUntilToday)
            Else
                ' SIByTheendOfTheYear = EstimatedYearSI
            End If
        Else
            If EstimatedYearSI > AnnoualSILimit Then
                'SIByTheendOfTheYear = SIByTheendOfTheYear - (EstimatedYearSI - annoualSILimit)
                SIByTheendOfTheYear = AnnoualSILimit - (previous_SIDeduction + SIAmountUntilToday)
            End If

        End If

        Return SIByTheendOfTheYear



    End Function
  
    Private Function Calculate_PF_byTheEndOfYear(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal NoOfTaxablePeriodsUntilNow As Integer) As Double
        If CheckDataSet(GLBTemplatePFDs) Then
            Dim i As Integer
            Dim k As Integer
            Dim D As String
            Dim RemainPeriodswithPF As Integer
            For i = 0 To GLBTemplatePFDs.Tables(0).Rows.Count - 1
                D = DbNullToString(GLBTemplatePFDs.Tables(0).Rows(i).Item(0))
                RemainPeriodswithPF = Global1.Business.GetPeriodsRemainingForThisDeductionCode(D, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
                For k = 0 To RemainPeriodswithPF
                    '      GLBRecurringEarning()
                    '   GLBBenefitsRecurringEarning()
                    '  GlbEmpSalary.SalaryValue()

                Next
            Next
        End If

    End Function
    Private Function Calculate_MF_byTheEndOfYear(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal NoOfTaxablePeriodsUntilNow As Integer) As Double
        'xxxxx()
    End Function
    Private Function Calculate_LI_byTheEndOfYear(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal EmpDis As cPrTxEmployeeDiscounts, ByVal NoOfTaxablePeriodsUntilNow As Integer) As Double
        Dim MonthlyLI As Double = 0
        Dim EstimatedLI As Double = 0
        Dim RemainingTaxablePeriods As Integer
        Dim Previous_LI As Double = 0

        MonthlyLI = EmpDis.LifeInsurance / GLBCurrentPeriod.NumberOfTaxablePeriods
        RemainingTaxablePeriods = GLBCurrentPeriod.NumberOfTaxablePeriods - NoOfTaxablePeriodsUntilNow
        EstimatedLI = MonthlyLI * RemainingTaxablePeriods

        'If GLBEmployee.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
        'Previous_LI = GLBEmployee.PreviousLifeIns
        ' End If

        EstimatedLI = EstimatedLI + Previous_LI

        Return EstimatedLI
    End Function
    Private Function Calculate_DI_byTheEndOfYear(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal EmpDis As cPrTxEmployeeDiscounts, ByVal NoOfTaxablePeriodsUntilNow As Integer) As Double
        Dim MonthlyDI As Double = 0
        Dim EstimatedDI As Double = 0
        Dim RemainingTaxablePeriods As Integer
        Dim Previous_DI As Double = 0

        MonthlyDI = EmpDis.TotalDiscounts / GLBCurrentPeriod.NumberOfTaxablePeriods
        RemainingTaxablePeriods = GLBCurrentPeriod.NumberOfTaxablePeriods - NoOfTaxablePeriodsUntilNow
        EstimatedDI = MonthlyDI * RemainingTaxablePeriods

        ' If GLBEmployee.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
        'Previous_DI = GLBEmployee.PreviousDis
        ' End If

        EstimatedDI = EstimatedDI + Previous_DI

        Return EstimatedDI

    End Function
    Private Function Calculate_FE_byTheEndOfYear(ByVal EstimatedEarningsByTheEndOfYear As Double, ByVal MonthlyFE As Double, ByVal NoOfTaxablePeriodsUntilNow As Integer) As Double

        Dim EstimatedFE As Double = 0
        Dim RemainingTaxablePeriods As Integer


        RemainingTaxablePeriods = GLBCurrentPeriod.NumberOfTaxablePeriods - NoOfTaxablePeriodsUntilNow
        EstimatedFE = MonthlyFE * RemainingTaxablePeriods


        Return EstimatedFE

    End Function


    Private Sub D_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) ', ByVal ForEstimation As Boolean)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim PFValue As Double
        Dim ValueToCalcFrom As Double

        Dim RemainingPeriodsWithPf As Integer
        RemainingPeriodsWithPf = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)

        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithPf = 0
        End If

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Dim PF As New cPrSsProvidentFund(Emp.ProFnd_Code)
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        '---------------------------------
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        'change for Markos Drakos
                        '-----------------------------------------------------
                        ' ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome4 + GetPeriodSplitForPF()
                        '-----------------------------------------------------
                        If Global1.PARAM_GetPFAmountFromAgreedSalary Then
                            If GLBAgreedSalary <> 0 Then
                                ValueToCalcFrom = GLBAgreedSalary
                            End If
                        End If

                        PFValue = Ded(i).txtValue.Text
                        If ValueToCalcFrom > PF.Limit And PF.Limit <> 0 Then
                            Dim Val2 As Double
                            PFValue = PFValue / 100 * PF.Limit

                            Dim PF2 As New cPrSsProvidentFund(PF.NextCode)
                            If PF2.Code <> "" Then
                                Val2 = ValueToCalcFrom - PF.Limit
                                PFValue = PFValue + (PF2.DedValue / 100 * Val2)
                            Else
                                MsgBox("Please enter a Valid Next Code in Prov.Fund Table for Code" & PF.Code & " For employee " & Emp.Code & " - " & Emp.FullName, MsgBoxStyle.Critical)
                                PFValue = 0
                            End If
                        Else
                            PFValue = PFValue / 100 * ValueToCalcFrom
                        End If
                        If Global1.PARAM_PAYE = False Then
                            Dim xPfValue As Double
                            ValueToCalcFrom = Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(TempDed.CalcFormula)
                            'change for Markos Drakos
                            '-----------------------------------------------------
                            'ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome4 + GetPeriodSplitForPF()
                            '-----------------------------------------------------
                            If Global1.PARAM_GetPFAmountFromAgreedSalary Then
                                If GLBAgreedSalary <> 0 Then
                                    ValueToCalcFrom = GLBAgreedSalary
                                End If
                            End If
                            xPfValue = Ded(i).txtValue.Text
                            If ValueToCalcFrom > PF.Limit And PF.Limit <> 0 Then
                                Dim Val2 As Double
                                xPfValue = xPfValue / 100 * PF.Limit

                                Dim PF2 As New cPrSsProvidentFund(PF.NextCode)
                                If PF2.Code <> "" Then
                                    Val2 = ValueToCalcFrom - PF.Limit
                                    xPfValue = xPfValue + (PF2.DedValue / 100 * Val2)
                                Else
                                    MsgBox("Please enter a Valid Next Code in Prov.Fund Table for Code" & PF.Code & " For employee " & Emp.Code & " - " & Emp.FullName, MsgBoxStyle.Critical)
                                    xPfValue = 0
                                End If
                            Else
                                xPfValue = xPfValue / 100 * ValueToCalcFrom
                            End If
                            GLB_PF_ByTheEndOfTheYear = GLB_PF_ByTheEndOfTheYear + (xPfValue * RemainingPeriodsWithPf)
                        End If

                    ElseIf TempDed.TypeMode = "V" Then
                        PFValue = Ded(i).txtValue.Text
                        If Global1.PARAM_PAYE = False Then
                            GLB_PF_ByTheEndOfTheYear = GLB_PF_ByTheEndOfTheYear + (PFValue * RemainingPeriodsWithPf)
                        End If
                    End If
                End If
                Exit For
            End If

        Next

        'If Not ForEstimation Then
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = PFValue
                Exit For
            End If
        Next
        'End If


    End Sub
    Private Sub D_CalculateSocialInsurance_1(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim SIValue As Double
        Dim SIValueFinal As Double
        Dim ValueToCalcFrom As Double
        Dim Ds As DataSet
        Dim Limits As New cPrSsLimits
        Dim AnnualSIincome As Double
        Dim TempAnnualSIincome As Double
        Dim Previous_SIDeduction As Double

        Dim SIValuePercentage As Double
        Dim SIValueLimit As Double
        Dim SIPeriodInsurableIncome As Double

        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            Previous_SIDeduction = Emp.Emp_PrevSIDeduct
        End If
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                If CheckDataSet(Ds) Then
                    Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                Else
                    MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        SIValue = Ded(i).txtValue.Text

                        SIValuePercentage = Ded(i).txtValue.Text
                        GLBSIPercentage = SIValuePercentage
                        ' Check Insurable Limits
                        If ValueToCalcFrom > Limits.InsurableMth Then
                            ValueToCalcFrom = Limits.InsurableMth
                        Else
                            ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                        End If
                        SIValue = SIValue / 100 * ValueToCalcFrom

                    ElseIf TempDed.TypeMode = "V" Then
                        SIValue = Ded(i).txtValue.Text
                        '-----------------------------------------------
                        'This is When Social Insuranceis a Value From Employee
                        'No Calculations are Done 
                        '-----------------------------------------------
                        D_Final(i).MyValue = SIValue
                        Exit Sub
                    End If
                End If
                SIValueFinal = SIValue
                SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100

                Dim SIPeriodSIValue As String
                SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                If SIValueFinal + SIPeriodSIValue > SIValueLimit Then
                    SIValueFinal = RoundMe3(SIValueLimit - SIPeriodSIValue, 2)
                End If
                If ValueToCalcFrom + SIPeriodInsurableIncome > Limits.InsurableMth Then
                    Period_InsurableIncome = Limits.InsurableMth - SIPeriodInsurableIncome

                Else
                    Period_InsurableIncome = ValueToCalcFrom
                End If



                AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                    AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
                End If
                TempAnnualSIincome = AnnualSIincome + SIValueFinal

                'If TempAnnualSIincome > (Limits.InsurableAnnual) Then
                ' SIValueFinal = Limits.InsurableAnnual - AnnualSIincome
                'End If
                Debug.WriteLine(Limits.DedContrAnnual / 2)
                If (TempAnnualSIincome) > (Limits.DedContrAnnual / 2) Then
                    SIValueFinal = (Limits.DedContrAnnual / 2) - AnnualSIincome
                    If SIValueFinal < 0 Then
                        SIValueFinal = 0
                        Period_InsurableIncome = 0
                    End If
                End If

                Exit For
            End If
        Next



        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = SIValueFinal
                Exit For
            End If
        Next
        Me.Period_SIIncome = SIValueFinal

    End Sub
    Private Sub D_CalculateSocialInsurance_x(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal OnlyRecuring As Boolean)
        'If Me.GlbSILeavePerc = 0 Then


        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim SIValue As Double
        Dim SIValueFinal As Double
        Dim ValueToCalcFrom As Double
        Dim Ds As DataSet
        Dim Limits As New cPrSsLimits
        Dim AnnualSIincome As Double
        Dim TempAnnualSIincome As Double
        Dim Previous_SIDeduction As Double

        Dim SIValuePercentage As Double
        Dim SIValueLimit As Double
        Dim SIPeriodInsurableIncome As Double
        Dim LastPeriod As Boolean
        LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)
        If GLBCurrentPeriod.NumberOfTotalPeriodsFORDisplayONLY = 12 Then
            LastPeriod = False
        End If

        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            Previous_SIDeduction = Emp.Emp_PrevSIDeduct
        End If
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                If CheckDataSet(Ds) Then
                    Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                Else
                    MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        SIValue = Ded(i).txtValue.Text
                        SIValuePercentage = Ded(i).txtValue.Text
                        GLBSIPercentage = SIValuePercentage
                        ' Check Insurable Limits
                        Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
                        '''''''''''''''''''''''''''''''''change
                        Period_InsurableIncome = Period_InsurableIncome - Me.GLBSILeave
                        ValueToCalcFrom = ValueToCalcFrom - Me.GLBSILeave
                        '''''''''''''''''''''''''''''''''''''''''''''''''''
                        If ValueToCalcFrom > Limits.InsurableMth Then
                            If Not LastPeriod Then
                                ValueToCalcFrom = Limits.InsurableMth
                                Period_InsurableIncome = Limits.InsurableMth
                            End If

                        Else
                            ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                            Period_InsurableIncome = ValueToCalcFrom

                        End If
                        SIValue = SIValue / 100 * ValueToCalcFrom

                    ElseIf TempDed.TypeMode = "V" Then
                        SIValue = Ded(i).txtValue.Text
                        D_Final(i).MyValue = SIValue
                        Exit Sub
                    End If
                End If
                SIValueFinal = SIValue
                SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100


                Dim SIPeriodSIValue As String
                Dim AnnualInsurableToDate As Double
                Dim PeriodInsurable As Double
                SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                '-----------------------------------------------
                'LOPOCA CHANGE
                '-----------------------------------------------
                If SIPeriodSIValue + SIValue > SIValueLimit Then
                    If Not LastPeriod Then
                        SIValue = RoundMe2(SIValueLimit - SIPeriodSIValue, 2)
                        Period_InsurableIncome = RoundMe2(Limits.InsurableMth - SIPeriodInsurableIncome, 2)
                        If SIValue < 0 Then
                            SIValue = 0
                        End If
                        If Period_InsurableIncome < 0 Then
                            Period_InsurableIncome = 0
                        End If
                        SIValueFinal = SIValue
                    End If
                End If
                'END Of LOPOCA -----------------------------------------------

                If LastPeriod Then
                    AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    'change
                    If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                        AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
                    End If
                    'change
                    AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                    If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                        AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                    End If

                    If Period_InsurableIncome + AnnualInsurableToDate > Limits.InsurableAnnual Then
                        Period_InsurableIncome = Limits.InsurableAnnual - AnnualInsurableToDate
                        If Period_InsurableIncome < 0 Then
                            MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                            Period_InsurableIncome = 0
                        End If
                        SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                        Period_InsurableIncome = Period_InsurableIncome
                    Else
                        SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                        Period_InsurableIncome = Period_InsurableIncome
                    End If
                End If

                TempAnnualSIincome = AnnualSIincome + SIValueFinal

                If (TempAnnualSIincome) > (Limits.DedContrAnnual / 2) Then
                    SIValueFinal = (Limits.DedContrAnnual / 2) - AnnualSIincome
                    If SIValueFinal < 0 Then
                        SIValueFinal = 0
                        Period_InsurableIncome = 0
                    End If
                End If

                Exit For
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''

        Next
        Dim SIonSILEave As Double = 0
        SIonSILEave = RoundMe3(SIValuePercentage / 100 * Me.GLBSILeave, 2)
        SIValueFinal = SIValueFinal + SIonSILEave
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = SIValueFinal
                Exit For
            End If
        Next
        Me.Period_SIIncome = SIValueFinal

        If OnlyRecuring Then
            GLBRemainingPeriodsWithSI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
            Period_ONLY_Recuring_SI = SIValueFinal
        End If

        CalculateSIforSplit(SIValueFinal, SIValuePercentage, Limits.InsurableMth)
        'Else
        '    '''''''''''''''''''''''''''''
        '    'SILeave Percentage Not ZERO
        '    '''''''''''''''''''''''''''''
        '    Dim TempDed As New cPrMsTemplateDeductions
        '    Dim i As Integer
        '    Dim SIValue As Double
        '    Dim SIValueFinal As Double
        '    Dim ValueToCalcFrom As Double
        '    Dim Ds As DataSet
        '    Dim Limits As New cPrSsLimits
        '    Dim AnnualSIincome As Double
        '    Dim TempAnnualSIincome As Double
        '    Dim Previous_SIDeduction As Double

        '    Dim SIValuePercentage As Double
        '    Dim SIValueLimit As Double
        '    Dim SIPeriodInsurableIncome As Double
        '    Dim LastPeriod As Boolean
        '    LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)

        '    If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
        '        Previous_SIDeduction = Emp.Emp_PrevSIDeduct
        '    End If
        '    For i = 0 To Ded.Length - 1
        '        If Dedu.Code = Ded(i).Ded.DedCodCode Then
        '            TempDed = Ded(i).Ded
        '            Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
        '            If CheckDataSet(Ds) Then
        '                Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
        '            Else
        '                MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
        '                Exit Sub
        '            End If
        '            '************ FOR SI LEAVE*******************
        '            Dim InsurableMth As Double
        '            InsurableMth = RoundMe2(Limits.InsurableMth + (GlbSILeavePerc / 100 * Limits.InsurableMth), 2)
        '            '********************************************

        '            If TempDed.DedCodCode <> "" Then
        '                If TempDed.TypeMode = "P" Then
        '                    ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '                    SIValue = Ded(i).txtValue.Text
        '                    SIValuePercentage = Ded(i).txtValue.Text
        '                    ' Check Insurable Limits
        '                    Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
        '                    If ValueToCalcFrom > InsurableMth Then
        '                        If Not LastPeriod Then
        '                            ValueToCalcFrom = InsurableMth
        '                            Period_InsurableIncome = InsurableMth
        '                        End If

        '                    Else
        '                        ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
        '                        Period_InsurableIncome = ValueToCalcFrom
        '                    End If
        '                    SIValue = SIValue / 100 * ValueToCalcFrom

        '                ElseIf TempDed.TypeMode = "V" Then
        '                    SIValue = Ded(i).txtValue.Text
        '                    D_Final(i).MyValue = SIValue
        '                    Exit Sub
        '                End If
        '            End If
        '            SIValueFinal = SIValue
        '            SIValueLimit = InsurableMth * SIValuePercentage / 100

        '            Dim SIPeriodSIValue As String
        '            Dim AnnualInsurableToDate As Double
        '            Dim PeriodInsurable As Double
        '            SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
        '            SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

        '            '************ FOR SI LEAVE*******************
        '            Dim InsurableAnnual As Double
        '            InsurableAnnual = RoundMe2(Limits.InsurableAnnual + (Limits.InsurableAnnual * Me.GlbSILeavePerc / 100), 2)
        '            '*******************************************

        '            If LastPeriod Then
        '                AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
        '                'change
        '                If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
        '                    AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
        '                End If
        '                'change
        '                AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
        '                If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
        '                    AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
        '                End If

        '                If Period_InsurableIncome + AnnualInsurableToDate > InsurableAnnual Then
        '                    Period_InsurableIncome = InsurableAnnual - AnnualInsurableToDate
        '                    If Period_InsurableIncome < 0 Then
        '                        MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
        '                        Period_InsurableIncome = 0
        '                    End If
        '                    SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
        '                    Period_InsurableIncome = Period_InsurableIncome
        '                Else
        '                    SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
        '                    Period_InsurableIncome = Period_InsurableIncome
        '                End If
        '            End If

        '            TempAnnualSIincome = AnnualSIincome + SIValueFinal

        '            If (TempAnnualSIincome) > (Limits.DedContrAnnual + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) Then
        '                SIValueFinal = (Limits.DedContrAnnual / 2 + (Limits.DedContrAnnual * GlbSILeavePerc / 100)) - AnnualSIincome
        '                If SIValueFinal < 0 Then
        '                    SIValueFinal = 0
        '                    Period_InsurableIncome = 0
        '                End If
        '            End If

        '            Exit For
        '        End If


        '        '''''''''''''''''''''''''''''''''''''''''''''''

        '        '''''''''''''''''''''''''''''''''''''''''''''''

        '    Next
        '    For i = 0 To D_Final.Length - 1
        '        If Dedu.Code = D_Final(i).Ded.DedCodCode Then
        '            D_Final(i).MyValue = SIValueFinal
        '            Exit For
        '        End If
        '    Next
        '    Me.Period_SIIncome = SIValueFinal
        '    If OnlyRecuring Then
        '        GLBRemainingPeriodsWithSI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        '        Period_ONLY_Recuring_SI = SIValueFinal
        '    End If


        '    CalculateSIforSplit(SIValueFinal, SIValuePercentage, Limits.InsurableMth)
        'End If


        D_CalculateSocialInsurance_ForRemainingPeriods(Emp, EmpDed, Dedu) ', OnlyRecuring)


    End Sub
    Private Sub D_CalculateSocialInsurance_2(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal OnlyRecuring As Boolean)

        If Me.GlbSILeavePerc = 0 Then
            Dim TempDed As New cPrMsTemplateDeductions
            Dim i As Integer
            Dim SIValue As Double
            Dim SIValueFinal As Double
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIDeduction As Double

            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double
            Dim SIPeriodInsurableIncome As Double
            Dim LastPeriod As Boolean
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)
            If GLBCurrentPeriod.NumberOfTotalPeriodsFORDisplayONLY = 12 Then
                LastPeriod = False
            End If

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIDeduction = Emp.Emp_PrevSIDeduct
            End If

            For i = 0 To Ded.Length - 1
                If Dedu.Code = Ded(i).Ded.DedCodCode Then
                    TempDed = Ded(i).Ded
                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TempDed.DedCodCode <> "" Then
                        If TempDed.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                            SIValue = Ded(i).txtValue.Text
                            SIValuePercentage = Ded(i).txtValue.Text
                            GLBSIPercentage = SIValuePercentage
                            ' Check Insurable Limits

                            Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
                            If ValueToCalcFrom > Limits.InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = Limits.InsurableMth
                                    Period_InsurableIncome = Limits.InsurableMth
                                End If

                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            '***************************************************************************************************************************
                            '2021 Change
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            If ValueToCalcFrom < 0 Then
                                ValueToCalcFrom = 0
                            End If
                            'END OF 2021 change
                            '***************************************************************************************************************************
                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempDed.TypeMode = "V" Then
                            SIValue = Ded(i).txtValue.Text
                            D_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100


                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    Dim PeriodInsurable As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '-----------------------------------------------
                    'LOPOCA CHANGE
                    '-----------------------------------------------
                    If SIPeriodSIValue + SIValue > SIValueLimit Then
                        If Not LastPeriod Then
                            SIValue = RoundMe2(SIValueLimit - SIPeriodSIValue, 2)
                            Period_InsurableIncome = RoundMe2(Limits.InsurableMth - SIPeriodInsurableIncome, 2)
                            If SIValue < 0 Then
                                SIValue = 0
                            End If
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = SIValue
                        End If
                    End If
                    'END Of LOPOCA -----------------------------------------------

                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        'change
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            ' AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
                            'change 31/12/2023
                        End If
                        'change
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            'AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                            'change 31/12/2023
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > Limits.InsurableAnnual Then
                            Period_InsurableIncome = Limits.InsurableAnnual - AnnualInsurableToDate
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If
                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    If (TempAnnualSIincome) > (Limits.DedContrAnnual / 2) Then
                        SIValueFinal = (Limits.DedContrAnnual / 2) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If

                    Exit For
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''

            Next
            For i = 0 To D_Final.Length - 1
                If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                    D_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal

            If OnlyRecuring Then
                GLBRemainingPeriodsWithSI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
                Period_ONLY_Recuring_SI = SIValueFinal
            End If

            CalculateSIforSplit(SIValueFinal, SIValuePercentage, Limits.InsurableMth)
        Else
            '''''''''''''''''''''''''''''
            'SILeave Percentage Not ZERO
            '''''''''''''''''''''''''''''
            Dim TempDed As New cPrMsTemplateDeductions
            Dim i As Integer
            Dim SIValue As Double
            Dim SIValueFinal As Double
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIDeduction As Double

            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double
            Dim SIPeriodInsurableIncome As Double
            Dim LastPeriod As Boolean
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIDeduction = Emp.Emp_PrevSIDeduct
            End If
            For i = 0 To Ded.Length - 1
                If Dedu.Code = Ded(i).Ded.DedCodCode Then
                    TempDed = Ded(i).Ded
                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    '************ FOR SI LEAVE*******************
                    Dim InsurableMth As Double
                    InsurableMth = RoundMe2(Limits.InsurableMth, 2) '+ (GlbSILeavePerc / 100 * Limits.InsurableMth), 2)
                    InsurableMth = RoundMe2(Limits.InsurableMth + (GlbSILeavePerc / 100 * Limits.InsurableMth), 2)
                    '********************************************

                    If TempDed.DedCodCode <> "" Then
                        If TempDed.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                            SIValue = Ded(i).txtValue.Text
                            SIValuePercentage = Ded(i).txtValue.Text
                            ' Check Insurable Limits
                            Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
                            If ValueToCalcFrom > InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                Else
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                End If

                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempDed.TypeMode = "V" Then
                            SIValue = Ded(i).txtValue.Text
                            D_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = InsurableMth * SIValuePercentage / 100

                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    Dim PeriodInsurable As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '************ FOR SI LEAVE*******************
                    Dim InsurableAnnual As Double
                    InsurableAnnual = RoundMe2(Limits.InsurableAnnual + (Limits.InsurableAnnual * Me.GlbSILeavePerc / 100), 2)
                    '*******************************************

                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        'change
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
                        End If
                        'change
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > InsurableAnnual Then
                            Period_InsurableIncome = InsurableAnnual - AnnualInsurableToDate
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If



                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    If (TempAnnualSIincome) > (Limits.DedContrAnnual + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) Then
                        SIValueFinal = (Limits.DedContrAnnual / 2 + (Limits.DedContrAnnual * GlbSILeavePerc / 100)) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If

                    Exit For
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''

            Next
            For i = 0 To D_Final.Length - 1
                If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                    D_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal
            If OnlyRecuring Then
                GLBRemainingPeriodsWithSI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
                Period_ONLY_Recuring_SI = SIValueFinal
            End If


            CalculateSIforSplit(SIValueFinal, SIValuePercentage, Limits.InsurableMth)

        End If


        D_CalculateSocialInsurance_ForRemainingPeriods(Emp, EmpDed, Dedu) ', OnlyRecuring)


    End Sub
    Private Sub D_CalculateSocialInsurance_3(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes, ByVal OnlyRecuring As Boolean)

        If Me.GlbSILeavePerc = 0 Then
            Dim TempDed As New cPrMsTemplateDeductions
            Dim i As Integer
            Dim SIValue As Double
            Dim SIValueFinal As Double
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIDeduction As Double

            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double
            Dim SIPeriodInsurableIncome As Double
            Dim LastPeriod As Boolean
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)
            If GLBCurrentPeriod.NumberOfTotalPeriodsFORDisplayONLY = 12 Then
                LastPeriod = False
            End If

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIDeduction = Emp.Emp_PrevSIDeduct
            End If

            For i = 0 To Ded.Length - 1
                If Dedu.Code = Ded(i).Ded.DedCodCode Then
                    TempDed = Ded(i).Ded
                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TempDed.DedCodCode <> "" Then
                        If TempDed.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                            SIValue = Ded(i).txtValue.Text
                            SIValuePercentage = Ded(i).txtValue.Text
                            GLBSIPercentage = SIValuePercentage
                            ' Check Insurable Limits

                            Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
                            If ValueToCalcFrom > Limits.InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = Limits.InsurableMth
                                    Period_InsurableIncome = Limits.InsurableMth
                                End If

                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            '***************************************************************************************************************************
                            '2021 Change
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            If ValueToCalcFrom < 0 Then
                                ValueToCalcFrom = 0
                            End If
                            'END OF 2021 change
                            '***************************************************************************************************************************
                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempDed.TypeMode = "V" Then
                            SIValue = Ded(i).txtValue.Text
                            D_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100


                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    Dim PeriodInsurable As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '-----------------------------------------------
                    'LOPOCA CHANGE
                    '-----------------------------------------------
                    If SIPeriodSIValue + SIValue > SIValueLimit Then
                        If Not LastPeriod Then
                            SIValue = RoundMe2(SIValueLimit - SIPeriodSIValue, 2)
                            Period_InsurableIncome = RoundMe2(Limits.InsurableMth - SIPeriodInsurableIncome, 2)
                            If SIValue < 0 Then
                                SIValue = 0
                            End If
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = SIValue
                        End If
                    End If
                    'END Of LOPOCA -----------------------------------------------
                    Dim TempLimitsInsurableAnnual As Double
                    TempLimitsInsurableAnnual = Limits.InsurableAnnual
                    Dim TempLimitsDedContrAnnual As Double
                    TempLimitsDedContrAnnual = Limits.DedContrAnnual

                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        'change
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            ' AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
                            'change 31/12/2023

                            Dim NumberOfNormalPeriodsRunUntilNow As Integer
                            NumberOfNormalPeriodsRunUntilNow = Global1.Business.FindNumberOfNormalPeriodsForThisEmployeeForThisPeriodGroup(GLBCurrentPeriod, Emp.Code)
                            TempLimitsInsurableAnnual = Limits.InsurableAnnual * NumberOfNormalPeriodsRunUntilNow / 12
                            TempLimitsDedContrAnnual = Limits.DedContrAnnual * NumberOfNormalPeriodsRunUntilNow / 12

                        End If
                        'change
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            'AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                            'change 31/12/2023
                        End If


                        If Period_InsurableIncome + AnnualInsurableToDate > TempLimitsInsurableAnnual Then
                            Period_InsurableIncome = TempLimitsInsurableAnnual - AnnualInsurableToDate
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If
                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    Dim PercentageOfAnnualAmount As Double
                    PercentageOfAnnualAmount = (GLBMySIDeductionRate / (GLBMySIDeductionRate + GLBMySIcontributionRate)) * TempLimitsDedContrAnnual
                    'NEW'
                    If (TempAnnualSIincome) > (PercentageOfAnnualAmount) Then
                        SIValueFinal = (PercentageOfAnnualAmount) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If
                    'OLD
                    'If (TempAnnualSIincome) > (TempLimitsDedContrAnnual / 2) Then
                    '    SIValueFinal = (TempLimitsDedContrAnnual / 2) - AnnualSIincome
                    '    If SIValueFinal < 0 Then
                    '        SIValueFinal = 0
                    '        Period_InsurableIncome = 0
                    '    End If
                    'End If

                    Exit For
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''

            Next
            For i = 0 To D_Final.Length - 1
                If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                    D_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal

            If OnlyRecuring Then
                GLBRemainingPeriodsWithSI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
                Period_ONLY_Recuring_SI = SIValueFinal
            End If

            CalculateSIforSplit(SIValueFinal, SIValuePercentage, Limits.InsurableMth)
        Else
            '''''''''''''''''''''''''''''
            'SILeave Percentage Not ZERO
            '''''''''''''''''''''''''''''
            Dim TempDed As New cPrMsTemplateDeductions
            Dim i As Integer
            Dim SIValue As Double
            Dim SIValueFinal As Double
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIDeduction As Double

            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double
            Dim SIPeriodInsurableIncome As Double
            Dim LastPeriod As Boolean
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIDeduction = Emp.Emp_PrevSIDeduct
            End If
            For i = 0 To Ded.Length - 1
                If Dedu.Code = Ded(i).Ded.DedCodCode Then
                    TempDed = Ded(i).Ded
                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    '************ FOR SI LEAVE*******************
                    Dim InsurableMth As Double
                    InsurableMth = RoundMe2(Limits.InsurableMth, 2) '+ (GlbSILeavePerc / 100 * Limits.InsurableMth), 2)
                    InsurableMth = RoundMe2(Limits.InsurableMth + (GlbSILeavePerc / 100 * Limits.InsurableMth), 2)
                    '********************************************

                    If TempDed.DedCodCode <> "" Then
                        If TempDed.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                            SIValue = Ded(i).txtValue.Text
                            SIValuePercentage = Ded(i).txtValue.Text
                            ' Check Insurable Limits
                            Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
                            If ValueToCalcFrom > InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                Else
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                End If

                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempDed.TypeMode = "V" Then
                            SIValue = Ded(i).txtValue.Text
                            D_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = InsurableMth * SIValuePercentage / 100

                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    Dim PeriodInsurable As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '************ FOR SI LEAVE*******************
                    Dim InsurableAnnual As Double
                    InsurableAnnual = RoundMe2(Limits.InsurableAnnual + (Limits.InsurableAnnual * Me.GlbSILeavePerc / 100), 2)
                    '*******************************************

                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        'change
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
                        End If
                        'change
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > InsurableAnnual Then
                            Period_InsurableIncome = InsurableAnnual - AnnualInsurableToDate
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If



                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    If (TempAnnualSIincome) > (Limits.DedContrAnnual + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) Then
                        SIValueFinal = (Limits.DedContrAnnual / 2 + (Limits.DedContrAnnual * GlbSILeavePerc / 100)) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If

                    Exit For
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''

            Next
            For i = 0 To D_Final.Length - 1
                If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                    D_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal
            If OnlyRecuring Then
                GLBRemainingPeriodsWithSI = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
                Period_ONLY_Recuring_SI = SIValueFinal
            End If


            CalculateSIforSplit(SIValueFinal, SIValuePercentage, Limits.InsurableMth)

        End If


        D_CalculateSocialInsurance_ForRemainingPeriods(Emp, EmpDed, Dedu) ', OnlyRecuring)


    End Sub
    Private Sub D_CalculateSocialInsurance_ForRemainingPeriods(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim SIValue As Double
        Dim SIValueFinal As Double
        Dim ValueToCalcFrom As Double
        Dim Ds As DataSet
        Dim Limits As New cPrSsLimits
        Dim AnnualSIincome As Double
        Dim TempAnnualSIincome As Double
        Dim Previous_SIDeduction As Double

        Dim SIValuePercentage As Double
        Dim SIValueLimit As Double
        Dim SIPeriodInsurableIncome As Double
        Dim SILimit As Double

        
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                If CheckDataSet(Ds) Then
                    Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                Else
                    MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        'ValueToCalcFrom = Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(TempDed.CalcFormula) + GLBEmployee.BonusOnsalary + GLBSILeave
                        ValueToCalcFrom = Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(TempDed.CalcFormula) + GLBEmployee.BonusOnsalary + GLBRecuringValueOfSILeave
                        SIValue = Ded(i).txtValue.Text

                        SIValuePercentage = Ded(i).txtValue.Text
                        GLBSIPercentage = SIValuePercentage
                        ' Check Insurable Limits

                        SILimit = RoundMe2(Limits.InsurableMth + (GlbSILeavePerc / 100 * Limits.InsurableMth), 2)
                        If ValueToCalcFrom > SILimit Then 'Limits.InsurableMth Then
                            ValueToCalcFrom = SILimit 'Limits.InsurableMth
                        Else
                            ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                        End If
                        SIValue = SIValue / 100 * ValueToCalcFrom

                    ElseIf TempDed.TypeMode = "V" Then
                        SIValue = Ded(i).txtValue.Text
                        '-----------------------------------------------
                        'This is When Social Insuranceis a Value From Employee
                        'No Calculations are Done 
                        '-----------------------------------------------
                        D_Final(i).MyValue = SIValue
                        Exit Sub
                    End If
                End If
                SIValueForRemainingPeriods = SIValue
                SIValueLimit = RoundMe2((SILimit * SIValuePercentage / 100), 2)

                ' Dim SIPeriodSIValue As String
                ' SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                ' SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                If SIValueForRemainingPeriods > SIValueLimit Then
                    SIValueForRemainingPeriods = SIValueLimit
                End If
              

                Exit For
            End If
        Next




    End Sub
    Private Sub CalculateSIforSplit(ByVal MonthSIValue As Double, ByVal SIPercentage As Double, ByVal SIMonthlyLimit As Double)
        If Global1.param_splitisEnabled Then
            Dim SplitAmount As Double
            Dim SIOnSplit As Double
            Dim SILimit As Double

            SplitAmount = GetPeriodSplitForTAX()

            SplitAmount = RoundMe3(SplitAmount * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)

            SIOnSplit = SplitAmount * SIPercentage / 100
            SILimit = SIMonthlyLimit * SIPercentage / 100
            'If Me.GlbSILeavePerc <> 0 Then
            '    SILimit = RoundMe2((SIMonthlyLimit * SIPercentage / 100) + (GlbSILeavePerc / 100 * SIMonthlyLimit), 2)
            'End If


            If (MonthSIValue + SIOnSplit) > SILimit Then
                SIOnSplit = RoundMe2(SILimit - MonthSIValue, 2)
            End If

            Me.GLBPeriodSIonSplit = SIOnSplit
        End If
    End Sub
    'Private Sub D_CalculateSocialInsurance_3(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
    '    Dim TempDed As New cPrMsTemplateDeductions
    '    Dim i As Integer
    '    Dim SIValue As Double
    '    Dim SIValueFinal As Double
    '    Dim ValueToCalcFrom As Double
    '    Dim Ds As DataSet
    '    Dim Limits As New cPrSsLimits
    '    Dim AnnualSIincome As Double
    '    Dim TempAnnualSIincome As Double
    '    Dim Previous_SIDeduction As Double

    '    Dim SIValuePercentage As Double
    '    Dim SIValueLimit As Double
    '    Dim SIPeriodInsurableIncome As Double
    '    Dim LastPeriod As Boolean
    '    LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)

    '    If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
    '        Previous_SIDeduction = Emp.Emp_PrevSIDeduct
    '    End If
    '    For i = 0 To Ded.Length - 1
    '        If Dedu.Code = Ded(i).Ded.DedCodCode Then
    '            TempDed = Ded(i).Ded
    '            Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
    '            If CheckDataSet(Ds) Then
    '                Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
    '            Else
    '                MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If
    '            If TempDed.DedCodCode <> "" Then
    '                If TempDed.TypeMode = "P" Then
    '                    ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
    '                    SIValue = Ded(i).txtValue.Text
    '                    SIValuePercentage = Ded(i).txtValue.Text
    '                    ' Check Insurable Limits
    '                    Period_InsurableIncome = Utils.RoundMeUp(ValueToCalcFrom)
    '                    If ValueToCalcFrom > Limits.InsurableMth Then
    '                        If Not LastPeriod Then
    '                            ValueToCalcFrom = Limits.InsurableMth
    '                            Period_InsurableIncome = Limits.InsurableMth
    '                        End If

    '                    Else
    '                        ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
    '                        Period_InsurableIncome = ValueToCalcFrom
    '                    End If
    '                    SIValue = SIValue / 100 * ValueToCalcFrom

    '                ElseIf TempDed.TypeMode = "V" Then
    '                    SIValue = Ded(i).txtValue.Text
    '                    D_Final(i).MyValue = SIValue
    '                    Exit Sub
    '                End If
    '            End If
    '            SIValueFinal = SIValue
    '            SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100

    '            Dim SIPeriodSIValue As String
    '            Dim AnnualInsurableToDate As Double
    '            Dim PeriodInsurable As Double
    '            SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
    '            SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

    '            ' If LastPeriod Then
    '            AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
    '            'change
    '            If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
    '                AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIDeduct
    '            End If
    '            'change
    '            AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
    '            If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
    '                AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
    '            End If

    '            If Period_InsurableIncome + AnnualInsurableToDate > (Limits.InsurableAnnual * GLBCurrentPeriod.currentisurableperiodNo / totalnormalperiods) Then
    '                Period_InsurableIncome = Limits.InsurableAnnual - AnnualInsurableToDate
    '                SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
    '                Period_InsurableIncome = Period_InsurableIncome
    '            Else
    '                SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
    '                Period_InsurableIncome = Period_InsurableIncome
    '            End If
    '            'End If

    '            TempAnnualSIincome = AnnualSIincome + SIValueFinal

    '            If (TempAnnualSIincome) > (Limits.DedContrAnnual / 2) Then
    '                SIValueFinal = (Limits.DedContrAnnual / 2) - AnnualSIincome
    '                If SIValueFinal < 0 Then
    '                    SIValueFinal = 0
    '                    Period_InsurableIncome = 0
    '                End If
    '            End If

    '            Exit For
    '        End If


    '        '''''''''''''''''''''''''''''''''''''''''''''''

    '        '''''''''''''''''''''''''''''''''''''''''''''''

    '    Next



    '    For i = 0 To D_Final.Length - 1
    '        If Dedu.Code = D_Final(i).Ded.DedCodCode Then
    '            D_Final(i).MyValue = SIValueFinal
    '            Exit For
    '        End If
    '    Next
    '    Me.Period_SIIncome = SIValueFinal

    'End Sub
    Private Sub D_CalculateSpecialTax(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim STValue As Double
        Dim ValueToCalcFrom As Double
        Dim DsSTax As DataSet
        Dim k As Integer
        Dim Donotchecklimit As Boolean = False

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        If TempDed.FromMode = "X" And Ded(i).txtValue.Text <> 0 Then
                            If Ded(i).txtValue.Text = -1 Then
                                STValue = 0
                                D_Final(i).MyValue = STValue
                            Else
                                STValue = Ded(i).txtValue.Text
                                D_Final(i).MyValue = STValue
                            End If
                        Else

                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)

                            'MARKOS DRAKOS
                            ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome4 '+ GetPeriodSplitForST()
                            If Global1.PARAM_SpecialDedonPension Then
                                ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome3
                            End If
                            If Global1.PARAM_SpecialDedonOTI1 Then
                                ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome3
                            End If

                            ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)


                            DsSTax = Global1.Business.GetAllPrSsExtraTaxTable

                            Dim TaxBracket As Double
                            Dim TAX As Double = 0
                            Dim RemAmount As Double = ValueToCalcFrom
                            Dim PrevRemAmount As Double
                            Dim TaxPercentage As Double

                            If CheckDataSet(DsSTax) Then
                                For k = 0 To DsSTax.Tables(0).Rows.Count - 1
                                    TaxBracket = DbNullToInt(DsSTax.Tables(0).Rows(k).Item(2))
                                    TaxPercentage = DbNullToDouble(DsSTax.Tables(0).Rows(k).Item(3))
                                    PrevRemAmount = RemAmount
                                    RemAmount = RemAmount - TaxBracket
                                    If RemAmount <= 0 Then
                                        If k = 0 Then
                                            Donotchecklimit = True
                                        End If
                                        Dim XX As Double
                                        XX = (PrevRemAmount * TaxPercentage / 100)
                                        TAX = TAX + (PrevRemAmount * TaxPercentage / 100)
                                        Exit For
                                    End If
                                    Dim XY As Double
                                    XY = TAX + (TaxBracket * TaxPercentage / 100)
                                    TAX = TAX + (TaxBracket * TaxPercentage / 100)
                                Next
                                STValue = TAX
                                If Not Donotchecklimit Then
                                    If STValue < Global1.GLB_SpecialTaxDeductionLimit Then
                                        STValue = Global1.GLB_SpecialTaxDeductionLimit
                                    End If
                                End If
                                D_Final(i).MyValue = STValue

                            End If
                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        STValue = Ded(i).txtValue.Text
                        D_Final(i).MyValue = STValue
                        Exit Sub
                    End If
                End If
            End If
        Next

        Me.Period_SpecialTaxValue = STValue

    End Sub
    Private Sub D_CalculateDecrease(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) ', ByVal OnlyRecuring As Boolean) ', ByVal DecreaseCode As String)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim DeValue As Double
        Dim xDeValue As Double
        Dim ValueToCalcFrom As Double
        Dim ValueToCalcFromOnlyRecuring As Double
        Dim DsDeTable As DataSet
        Dim k As Integer
        Dim Pension As Double = 0

        Dim RemainingPeriodsWithDN As Integer
        RemainingPeriodsWithDN = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithDN = 0
        End If

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        If TempDed.FromMode = "X" And Ded(i).txtValue.Text <> 0 Then
                            If Ded(i).txtValue.Text = -1 Then
                                DeValue = 0
                                D_Final(i).MyValue = DeValue
                            Else
                                DeValue = Ded(i).txtValue.Text
                                D_Final(i).MyValue = DeValue
                            End If
                        Else


                            If Emp.OtherIncome3 <> 0 Then
                                Pension = RoundMe2(Emp.OtherIncome3 * 12 / 13, 2)
                            End If

                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                            ValueToCalcFromOnlyRecuring = FindValueOfFormulaONLYRecuring(TempDed.CalcFormula)

                            ValueToCalcFrom = ValueToCalcFrom + Pension
                            ValueToCalcFromOnlyRecuring = ValueToCalcFromOnlyRecuring + Pension



                            DsDeTable = Global1.Business.GetAllPrSsDecreaseTable


                            '===========================================================================================
                            'ONLY RECURING
                            '===========================================================================================
                            Dim xTaxBracket As Double
                            Dim xTAX As Double = 0
                            Dim xRemAmount As Double = ValueToCalcFromOnlyRecuring
                            Dim xPrevRemAmount As Double
                            Dim xTaxPercentage As Double

                            If CheckDataSet(DsDeTable) Then
                                For k = 0 To DsDeTable.Tables(0).Rows.Count - 1
                                    xTaxBracket = DbNullToInt(DsDeTable.Tables(0).Rows(k).Item(3))
                                    xTaxPercentage = DbNullToDouble(DsDeTable.Tables(0).Rows(k).Item(4))
                                    xPrevRemAmount = xRemAmount
                                    xRemAmount = xRemAmount - xTaxBracket
                                    If xRemAmount <= 0 Then
                                        'If k = 0 Then
                                        '    Donotchecklimit = True
                                        'End If
                                        Dim XX As Double
                                        XX = (xPrevRemAmount * xTaxPercentage / 100)
                                        xTAX = xTAX + (xPrevRemAmount * xTaxPercentage / 100)
                                        Exit For
                                    End If
                                    Dim XY As Double
                                    XY = xTAX + (xTaxBracket * xTaxPercentage / 100)
                                    xTAX = xTAX + (xTaxBracket * xTaxPercentage / 100)
                                Next
                                xDeValue = xTAX
                            End If
                            '===========================================================================================
                            'END ONLY RECURNG
                            '===========================================================================================

                            Dim TaxBracket As Double
                            Dim TAX As Double = 0
                            Dim RemAmount As Double = ValueToCalcFrom
                            Dim PrevRemAmount As Double
                            Dim TaxPercentage As Double

                            If CheckDataSet(DsDeTable) Then
                                For k = 0 To DsDeTable.Tables(0).Rows.Count - 1
                                    TaxBracket = DbNullToInt(DsDeTable.Tables(0).Rows(k).Item(3))
                                    TaxPercentage = DbNullToDouble(DsDeTable.Tables(0).Rows(k).Item(4))
                                    PrevRemAmount = RemAmount
                                    RemAmount = RemAmount - TaxBracket
                                    If RemAmount <= 0 Then
                                        'If k = 0 Then
                                        '    Donotchecklimit = True
                                        'End If
                                        Dim XX As Double
                                        XX = (PrevRemAmount * TaxPercentage / 100)
                                        TAX = TAX + (PrevRemAmount * TaxPercentage / 100)
                                        Exit For
                                    End If
                                    Dim XY As Double
                                    XY = TAX + (TaxBracket * TaxPercentage / 100)
                                    TAX = TAX + (TaxBracket * TaxPercentage / 100)
                                Next
                                DeValue = TAX
                                'If Not Donotchecklimit Then
                                '    If STValue < Global1.GLB_SpecialTaxDeductionLimit Then
                                '        STValue = Global1.GLB_SpecialTaxDeductionLimit
                                '    End If
                                'End If
                                D_Final(i).MyValue = DeValue

                            End If
                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        DeValue = Ded(i).txtValue.Text
                        xDeValue = Ded(i).txtValue.Text
                        D_Final(i).MyValue = DeValue
                        Exit Sub
                    End If
                End If
            End If
        Next
        ' If OnlyRecuring Then
        ' GLBDNValueOfRecuring = DeValue
        ' End If

        GLB_DN_ByTheEndOfTheYear = GLB_DN_ByTheEndOfTheYear + (xDeValue * RemainingPeriodsWithDN)

        Me.Period_Decrease = DeValue

    End Sub
    Private Sub D_CalculatePensionFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) ', ByVal ForEstimation As Boolean)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim PenFValue As Double
        Dim ValueToCalcFrom As Double
        Dim ValueToCalcFromOnlyRec As Double

        Dim RemainingPeriodsWithPenf As Integer
        RemainingPeriodsWithPenf = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithPenf = 0
        End If

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        '---------------------------------
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        Dim Value As Double
                        Value = Ded(i).txtValue.Text


                        PenFValue = Value * ValueToCalcFrom / 100


                        If Global1.PARAM_PAYE = False Then
                            Dim xPenfValue As Double

                            ValueToCalcFromOnlyRec = Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(TempDed.CalcFormula)
                            Value = Ded(i).txtValue.Text
                            xPenfValue = ValueToCalcFromOnlyRec * Value / 100
                            GLB_PenF_ByTheEndOfTheYear = GLB_PenF_ByTheEndOfTheYear + (xPenfValue * RemainingPeriodsWithPenf)
                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        PenFValue = Ded(i).txtValue.Text
                        If Global1.PARAM_PAYE = False Then
                            GLB_PenF_ByTheEndOfTheYear = GLB_PenF_ByTheEndOfTheYear + (PenFValue * RemainingPeriodsWithPenf)
                        End If
                    End If
                End If
            End If
        Next

        Me.Period_PensionFund = PenFValue
        'If Not ForEstimation Then
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = PenFValue
                Exit For
            End If
        Next
        'End If


    End Sub
    Private Sub D_CalculateWidowFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes) ', ByVal ForEstimation As Boolean)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim WidFValue As Double
        Dim ValueToCalcFrom As Double
        Dim ValueToCalcFromOnlyRec As Double

        Dim RemainingPeriodsWithWidf As Integer
        RemainingPeriodsWithWidf = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithWidf = 0
        End If

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        '---------------------------------
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        Dim Value As Double
                        Value = Ded(i).txtValue.Text


                        WidFValue = Value * ValueToCalcFrom / 100


                        If Global1.PARAM_PAYE = False Then
                            Dim xWidValue As Double

                            ValueToCalcFromOnlyRec = Me.FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(TempDed.CalcFormula)
                            Value = Ded(i).txtValue.Text
                            xWidValue = ValueToCalcFromOnlyRec * Value / 100
                            GLB_WidF_ByTheEndOfTheYear = GLB_WidF_ByTheEndOfTheYear + (xWidValue * RemainingPeriodsWithWidf)
                        End If

                    End If

                ElseIf TempDed.TypeMode = "V" Then
                    WidFValue = Ded(i).txtValue.Text
                    If Global1.PARAM_PAYE = False Then
                        GLB_WidF_ByTheEndOfTheYear = GLB_WidF_ByTheEndOfTheYear + (WidFValue * RemainingPeriodsWithWidf)
                    End If
                End If
            End If
        Next

        Me.Period_WidowFund = WidFValue
        'If Not ForEstimation Then
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = WidFValue
                Exit For
            End If
        Next
        'End If


    End Sub
    Private Sub D_CalculateUnionSubscription(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim UnionValue As Double
        Dim ValueToCalcFrom As Double
        Dim xUnionValue As Double
        Dim xValueToCalcFrom As Double


        Dim RemainingPeriodsWithUnion As Integer
        RemainingPeriodsWithUnion = Global1.Business.GetPeriodsRemainingForThisDeductionCode(Dedu.Code, GLBCurrentPeriod.Sequence, GLBCurrentPeriod.PrdGrpCode)
        If GLBEmployee.TerminateDate <> "" Then
            RemainingPeriodsWithUnion = 0
        End If

        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded

                Dim Union As New cPrAnUnions(Emp.Uni_Code)
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        UnionValue = Ded(i).txtValue.Text
                        xUnionValue = Ded(i).txtValue.Text
                        UnionValue = UnionValue / 100 * ValueToCalcFrom
                        If Global1.PARAM_PAYE = False Then
                            Dim Perc As Double
                            Perc = Ded(i).txtValue.Text
                            xValueToCalcFrom = FindValueOfFormulaONLYRecuring(TempDed.CalcFormula)
                            xUnionValue = Perc / 100 * xValueToCalcFrom
                            If xUnionValue > Union.MonthlySubLimit Then
                                xUnionValue = Union.MonthlySubLimit
                            End If
                            Me.GLB_UNION_ByTheEndOfTheYear = Me.GLB_UNION_ByTheEndOfTheYear + xUnionValue * RemainingPeriodsWithUnion
                        End If
                    ElseIf TempDed.TypeMode = "V" Then
                        UnionValue = Ded(i).txtValue.Text
                        xUnionValue = Ded(i).txtValue.Text
                        If Global1.PARAM_PAYE = False Then
                            If xUnionValue > Union.MonthlySubLimit Then
                                xUnionValue = Union.MonthlySubLimit
                            End If
                            Me.GLB_UNION_ByTheEndOfTheYear = Me.GLB_UNION_ByTheEndOfTheYear + xUnionValue * RemainingPeriodsWithUnion
                        End If
                    End If
                End If
                'Checking Or Union Sub. Limit 
                If UnionValue > Union.MonthlySubLimit Then
                    UnionValue = Union.MonthlySubLimit
                End If
                Exit For
            End If
        Next
        'Dim Union As New cPrAnUnions(Emp.Uni_Code)
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            UnionValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            UnionValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                UnionValue = Union.Uni_SubscriptionValue
        '            Else
        '                UnionValue = 0
        '            End If
        '        End If
        '        UnionValue = UnionValue / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        If TempDed.FromMode = "E" Then
        '            UnionValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            UnionValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then

        '            If Union.Code <> "" Then
        '                UnionValue = Union.Uni_SubscriptionValue
        '            Else
        '                UnionValue = 0
        '            End If
        '        End If

        '    End If
        'End If

        ''Checking Or Union Sub. Limit 
        'If UnionValue > Union.MonthlySubLimit Then
        '    UnionValue = Union.MonthlySubLimit
        'End If

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = UnionValue
                Exit For
            End If
        Next


    End Sub
    Private Sub D_CalculateUnion2(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim Union2Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        Union2Value = Ded(i).txtValue.Text
                        Union2Value = Union2Value / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        Union2Value = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            Union2Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Union2Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Dim Union As New cPrAnUnions(Emp.Uni_Code)
        '            If Union.Code <> "" Then
        '                Union2Value = Union.Uni_Deduction1
        '            Else
        '                Union2Value = 0
        '            End If
        '        End If
        '        Union2Value = Union2Value / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        If TempDed.FromMode = "E" Then
        '            Union2Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Union2Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Dim Union As New cPrAnUnions(Emp.Uni_Code)
        '            If Union.Code <> "" Then
        '                Union2Value = Union.Uni_Deduction1
        '            Else
        '                Union2Value = 0
        '            End If
        '        End If

        '    End If
        'End If

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = Union2Value
                Exit For
            End If
        Next
    End Sub
    Private Sub D_CalculateUnion3(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim Union3Value As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        Union3Value = Ded(i).txtValue.Text
                        Union3Value = Union3Value / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        Union3Value = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            Union3Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Union3Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Dim Union As New cPrAnUnions(Emp.Uni_Code)
        '            If Union.Code <> "" Then
        '                Union3Value = Union.Uni_Deduction2
        '            Else
        '                Union3Value = 0
        '            End If
        '        End If
        '        Union3Value = Union3Value / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        If TempDed.FromMode = "E" Then
        '            Union3Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            Union3Value = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            Dim Union As New cPrAnUnions(Emp.Uni_Code)
        '            If Union.Code <> "" Then
        '                Union3Value = Union.Uni_Deduction2
        '            Else
        '                Union3Value = 0
        '            End If
        '        End If

        '    End If
        'End If

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = Union3Value
                Exit For
            End If
        Next
    End Sub
    Private Sub D_CalculateUnionMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim UnionMFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded

                Dim Union As New cPrAnUnions(Emp.Uni_Code)
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        UnionMFValue = Ded(i).txtValue.Text
                        UnionMFValue = UnionMFValue / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        UnionMFValue = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'Dim Union As New cPrAnUnions(Emp.Uni_Code)
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                UnionMFValue = Union.MonthlyMF
        '            Else
        '                UnionMFValue = 0
        '            End If
        '        End If
        '        UnionMFValue = UnionMFValue / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        If TempDed.FromMode = "E" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then

        '            If Union.Code <> "" Then
        '                UnionMFValue = Union.MonthlyMF
        '            Else
        '                UnionMFValue = 0
        '            End If
        '        End If

        '    End If
        'End If

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = UnionMFValue
                Exit For
            End If
        Next


    End Sub

    Private Sub D_CalculateOtherDeductions(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim OTHERValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded

                Dim Union As New cPrAnUnions(Emp.Uni_Code)
                If TempDed.DedCodCode <> "" Then
                    If TempDed.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                        OTHERValue = Ded(i).txtValue.Text
                        OTHERValue = OTHERValue / 100 * ValueToCalcFrom
                    ElseIf TempDed.TypeMode = "V" Then
                        OTHERValue = Ded(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'Dim Union As New cPrAnUnions(Emp.Uni_Code)
        'If TempDed.DedCodCode <> "" Then
        '    If TempDed.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
        '        If TempDed.FromMode = "E" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                UnionMFValue = Union.MonthlyMF
        '            Else
        '                UnionMFValue = 0
        '            End If
        '        End If
        '        UnionMFValue = UnionMFValue / 100 * ValueToCalcFrom
        '    ElseIf TempDed.TypeMode = "V" Then
        '        If TempDed.FromMode = "E" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "F" Then
        '            UnionMFValue = EmpDed.MyValue
        '        ElseIf TempDed.FromMode = "T" Then

        '            If Union.Code <> "" Then
        '                UnionMFValue = Union.MonthlyMF
        '            Else
        '                UnionMFValue = 0
        '            End If
        '        End If

        '    End If
        'End If

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = OTHERValue
                Exit For
            End If
        Next
    End Sub
#End Region
#Region "Contributions Calculations"
    Private Sub CalculateContributions(ByVal Emp As cPrMsEmployees)
        Dim i As Integer

        For i = 0 To Me.Con.Length - 1
            If Not Con(i).Con Is Nothing Then
                Dim EC As New cPrMsEmployeeContributions(Emp.Code, Con(i).Con.ConCodCode)
                Dim Cont As New cPrMsContributionCodes(Con(i).Con.ConCodCode)

                Select Case Cont.ConTypCode
                    Case "IN" 'INDUSTRIAL
                        C_CalculateIndustrial(Emp, EC, Cont)
                    Case "MF" 'MEDICAL FUND 'F
                        C_CalculateMedicalFund(Emp, EC, Cont)
                    Case "PF" 'PROVIDENT FUND 'F
                        C_CalculateProvidentFund(Emp, EC, Cont)
                    Case "SI" 'SOCIAL INSURANCE 'F
                        If Global1.GLB_MethodOfSI = 1 Then
                            C_CalculateSocialInsurance_1(Emp, EC, Cont)
                        ElseIf Global1.GLB_MethodOfSI = 2 Then
                            C_CalculateSocialInsurance_3(Emp, EC, Cont)
                        End If
                    Case "ST" 'SOCIAL COHESION FUND 'F
                        C_CalculateSocialCohesionFund(Emp, EC, Cont)
                    Case "UN" 'UNEMPLOYMENT 'F
                        C_CalculateUnemploymentFund(Emp, EC, Cont)
                    Case "WF" 'WELFAIR FUND 
                        C_CalculateWelFairFund(Emp, EC, Cont)
                    Case "UM" 'UNION MEDICAL FUND
                        C_CalculateUnionMedicalFund(Emp, EC, Cont)
                    Case "UF" 'UNION MEDICAL FUND
                        C_CalculateUnionMedicalFund(Emp, EC, Cont)
                    Case "EX" 'CALCULATE EXTRA TAX
                        C_CalculateSpecialTax(Emp, EC, Cont)
                    Case "OC" 'CALCULATE OTHER CON
                        C_CalculateOtherContributions(Emp, EC, Cont)
                    Case "GC" 'CALCULATE GESI
                        C_CalculateGESI(Emp, EC, Cont)
                    Case "BC" 'CALCULATE BIK GESI
                        C_Calculate_BIK_GESI(Emp, EC, Cont)


                End Select
            End If
        Next
        Dim TotalC As Double
        TotalC = CalculateTotalContributions()
        Me.txtTotalContributions.Text = Format(RoundMe2(TotalC, 2), "0.00")


    End Sub
    Private Sub C_CalculateIndustrial(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        If GlbSILeavePerc = 0 Then
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim Industrial As Double
            Dim ValueToCalcFrom As Double
            Dim Limits As New cPrSsLimits
            Dim ds As DataSet
            Dim AnnualINDCon As Double = 0
            Dim TempAnnualINDCon As Double = 0

            For i = 0 To Ded.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(ds) Then
                        Limits = New cPrSsLimits(ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            'ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            ValueToCalcFrom = Period_InsurableIncome  'FindValueOfFormula(TempCon.CalcFormula)
                            Industrial = Con(i).txtValue.Text
                            ' Check Insurable Limits
                            'If ValueToCalcFrom > Limits.InsurableMth Then
                            '    ValueToCalcFrom = Limits.InsurableMth
                            'Else
                            '    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                            'End If
                            ''
                            Industrial = Industrial / 100 * ValueToCalcFrom
                        ElseIf TempCon.TypeMode = "V" Then

                            Industrial = Con(i).txtValue.Text
                            C_Final(i).MyValue = Industrial
                            Exit Sub
                        End If
                    End If
                    AnnualINDCon = Global1.Business.FindSumForThisPeriodYearUntilNowOfContributionCodeType(GLBCurrentPeriod, Cont, Emp.Code)
                    TempAnnualINDCon = AnnualINDCon + Industrial
                    If TempAnnualINDCon > Limits.IndAnnual Then
                        Industrial = Limits.IndAnnual - AnnualINDCon
                    End If

                    Exit For
                End If
            Next

            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = Industrial
                    Exit For
                End If
            Next
        Else
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim Industrial As Double
            Dim ValueToCalcFrom As Double
            Dim Limits As New cPrSsLimits
            Dim ds As DataSet
            Dim AnnualINDCon As Double = 0
            Dim TempAnnualINDCon As Double = 0

            For i = 0 To Ded.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(ds) Then
                        Limits = New cPrSsLimits(ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            'ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            ValueToCalcFrom = Period_InsurableIncome  'FindValueOfFormula(TempCon.CalcFormula)
                            Industrial = Con(i).txtValue.Text
                            ' Check Insurable Limits
                            'If ValueToCalcFrom > Limits.InsurableMth Then
                            '    ValueToCalcFrom = Limits.InsurableMth
                            'Else
                            '    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                            'End If
                            ''
                            Industrial = Industrial / 100 * ValueToCalcFrom
                        ElseIf TempCon.TypeMode = "V" Then
                            Industrial = Con(i).txtValue.Text
                        End If
                    End If

                    AnnualINDCon = Global1.Business.FindSumForThisPeriodYearUntilNowOfContributionCodeType(GLBCurrentPeriod, Cont, Emp.Code)
                    TempAnnualINDCon = AnnualINDCon + Industrial
                    Dim IndAnnual As Double
                    IndAnnual = RoundMe2(Limits.IndAnnual + (Limits.IndAnnual * GlbSILeavePerc / 100), 2)
                    If TempAnnualINDCon > IndAnnual Then
                        Industrial = IndAnnual - AnnualINDCon
                    End If

                    Exit For
                End If
            Next

            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = Industrial
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub C_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim MFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                        MFValue = Con(i).txtValue.Text
                        MFValue = MFValue / 100 * ValueToCalcFrom
                    ElseIf TempCon.TypeMode = "V" Then
                        MFValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempCon.ConCodCode <> "" Then
        '    If TempCon.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
        '        If TempCon.FromMode = "E" Then
        '            MFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            MFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
        '            If MedFund.Code <> "" Then
        '                MFValue = MedFund.DedValue
        '            Else
        '                MFValue = 0
        '            End If
        '        End If
        '        MFValue = MFValue / 100 * ValueToCalcFrom
        '    ElseIf TempCon.TypeMode = "V" Then
        '        If TempCon.FromMode = "E" Then
        '            MFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            MFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            Dim MedFund As New cPrSsMedicalFund(Emp.MedFnd_Code)
        '            If MedFund.Code <> "" Then
        '                MFValue = MedFund.DedValue
        '            Else
        '                MFValue = 0
        '            End If
        '        End If
        '    End If
        'End If

        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = MFValue

                Exit For
            End If
        Next
    End Sub
    Private Sub C_CalculateGESI(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim GESIValue As Double
        Dim GESIRate As Double
        Dim ValueToCalcFrom As Double

        Dim PreviousGesi As Double = 0
        'If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
        'PreviousGesi = Me.GLBEmployee.PreviousGesiC
        'End If
        Dim TodateGESI As Double
        TodateGESI = Global1.Business.GetToDate_Contributions(Emp, GLBCurrentPeriod, "GC")
        GLB_TodateGesi_CON = TodateGESI

        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = Utils.RoundMeUp(FindValueOfFormula(TempCon.CalcFormula))
                        '***************************************************************************************************************************
                        '2021 Change
                        If ValueToCalcFrom < 0 Then
                            ValueToCalcFrom = 0
                        End If
                        'END OF 2021 change
                        '***************************************************************************************************************************
                        GESIValue = Con(i).txtValue.Text
                        GESIRate = Con(i).txtValue.Text
                        GESIValue = GESIValue / 100 * ValueToCalcFrom
                    ElseIf TempCon.TypeMode = "V" Then
                        GESIValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next

        'Checking Limits
        Dim ActualTotalYear As Double = 0
        Dim TotalYear As Double = 0

        ActualTotalYear = GESIValue + TodateGESI + PreviousGesi
        If ActualTotalYear > Me.GLBLimits.GesiC Then
            '******************* LAST CHANGE REVERSE it in 2020 until end of
            'Dim LimitTotalGesiable As Double
            'Dim YTD_Gesiable As Double
            'Dim PER_Gesiable As Double

            'Dim PREV_GESIABLE As Double = 0
            'If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            '    PREV_GESIABLE = GLBEmployee.PreviousEarnings
            'End If


            'YTD_Gesiable = Global1.Business.GetSUM_Of_GESIABLE_FromTrxnHeaderFor(Me.GLBCurrentPeriod, GLBEmployee.Code)


            'Dim GesiableforPeriod As Double = 0

            'LimitTotalGesiable = YTD_Gesiable + PREV_GESIABLE + Utils.RoundMeUp(ValueToCalcFrom)

            'If LimitTotalGesiable >= LimitOfGESYasInsurableAmount Then
            '    GesiableforPeriod = LimitOfGESYasInsurableAmount - (YTD_Gesiable + PREV_GESIABLE)
            '    GESIValue = GESIRate / 100 * Utils.RoundMeUp(GesiableforPeriod)
            'End If
            '*********    END OF last change



            Dim Diff As Double
            Diff = Me.GLBLimits.GesiC - (TodateGESI + PreviousGesi)
            If Diff < 0 Then Diff = 0
            GESIValue = Diff
        End If
        'Checking Limits


        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = GESIValue
                Me.PeriodGesiCValue = GESIValue
                Exit For
            End If
        Next

        Dim FixedGesy As Double = 0
        FixedGesy = CDbl(Me.txtFixedGesyC.Text)
        If FixedGesy <> 0 Then
            If FixedGesy = -1 Then
                FixedGesy = 0
            End If
            'Dim Ans As New MsgBoxResult
            'Ans = MsgBox("Continue with Calculating Gesy as " & FixedGesy, MsgBoxStyle.YesNo)
            'If Ans = MsgBoxResult.Yes Then
            GESIValue = FixedGesy
            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = GESIValue
                    PeriodGesiCValue = GESIValue
                    Exit For
                End If
            Next
            ' End If

        End If


    End Sub
    Private Sub C_Calculate_BIK_GESI(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim BIK_GESIValue As Double
        Dim BIK_ValueToCalcFrom As Double

        


        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        BIK_ValueToCalcFrom = Utils.RoundMeUp(FindValueOfFormula(TempCon.CalcFormula))
                        BIK_GESIValue = Con(i).txtValue.Text
                        BIK_GESIValue = BIK_GESIValue / 100 * BIK_ValueToCalcFrom

                        '**************************************************************************************
                        'Checking Limits
                        '**************************************************************************************

                        Dim Todate_BIK_GESI As Double
                        Todate_BIK_GESI = Global1.Business.GetToDate_Contributions(Emp, GLBCurrentPeriod, "BC")
                        Dim ActualTotalPaidGesyFromThisemployeer As Double = 0
                        ActualTotalPaidGesyFromThisemployeer = Me.PeriodGesiCValue + Me.GLB_TodateGesi_CON + Todate_BIK_GESI + BIK_GESIValue
                        If ActualTotalPaidGesyFromThisemployeer > GLBLimits.GesiC Then
                            Dim Diff As Double = 0
                            Diff = RoundMe2(ActualTotalPaidGesyFromThisemployeer - GLBLimits.GesiC, 2)
                            BIK_GESIValue = RoundMe2(BIK_GESIValue - Diff, 2)
                            If BIK_GESIValue < 0 Then
                                BIK_GESIValue = 0
                            End If
                        End If




                    Else
                        'BIK_ValueToCalcFrom = Utils.RoundMeUp(FindValueOfFormula(TempCon.CalcFormula))
                        BIK_GESIValue = Con(i).txtValue.Text
                        'BIK_GESIValue = BIK_GESIValue / 100 * BIK_ValueToCalcFrom

                    End If
                End If
                Exit For
            End If
        Next

        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = BIK_GESIValue
                Exit For
            End If
        Next
    End Sub
    Private Sub C_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim PFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                Dim PF As New cPrSsProvidentFund(Emp.ProFnd_Code)
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)

                        PFValue = Con(i).txtValue.Text
                        If TempCon.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            'change for Markos Drakos
                            '-----------------------------------------------------
                            'ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome4 + GetPeriodSplitForPF()
                            '-----------------------------------------------------
                            If Global1.PARAM_GetPFAmountFromAgreedSalary Then
                                If GLBAgreedSalary <> 0 Then
                                    ValueToCalcFrom = GLBAgreedSalary
                                End If
                            End If

                            PFValue = Con(i).txtValue.Text
                            If ValueToCalcFrom > PF.Limit And PF.Limit > 0 Then
                                Dim Val2 As Double
                                PFValue = PFValue / 100 * PF.Limit

                                Dim PF2 As New cPrSsProvidentFund(PF.NextCode)
                                If PF2.Code <> "" Then
                                    Val2 = ValueToCalcFrom - PF.Limit
                                    PFValue = PFValue + (PF2.ConValue / 100 * Val2)
                                Else
                                    MsgBox("Please enter a Valid Next Code in Prov.Fund Table for Code" & PF.Code & " For employee " & Emp.Code & " - " & Emp.FullName, MsgBoxStyle.Critical)
                                    PFValue = 0
                                End If
                            Else
                                PFValue = PFValue / 100 * ValueToCalcFrom
                            End If
                        End If
                    ElseIf TempCon.TypeMode = "V" Then
                        PFValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempCon.ConCodCode <> "" Then
        '    If TempCon.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
        '        If TempCon.FromMode = "E" Then
        '            PFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            PFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
        '            If ProFund.Code <> "" Then
        '                PFValue = ProFund.ConValue
        '            Else
        '                PFValue = 0
        '            End If
        '        End If
        '        PFValue = PFValue / 100 * ValueToCalcFrom
        '    ElseIf TempCon.TypeMode = "V" Then
        '        If TempCon.FromMode = "E" Then
        '            PFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            PFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            Dim ProFund As New cPrSsProvidentFund(Emp.ProFnd_Code)
        '            If ProFund.Code <> "" Then
        '                PFValue = ProFund.ConValue
        '            Else
        '                PFValue = 0
        '            End If
        '        End If

        '    End If
        'End If
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = PFValue
                Exit For
            End If
        Next


    End Sub
    Private Sub C_CalculateSocialInsurance_1(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim SIValue As Double = 0
        Dim SIValueFinal As Double = 0
        Dim ValueToCalcFrom As Double
        Dim Ds As DataSet
        Dim Limits As New cPrSsLimits
        Dim AnnualSIincome As Double
        Dim TempAnnualSIincome As Double
        Dim Previous_SIContribution As Double

        If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
            Previous_SIContribution = Emp.Emp_PrevSIContribute
        End If

        Dim SIValuePercentage As Double
        Dim SIValueLimit As Double

        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con

                Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                If CheckDataSet(Ds) Then
                    Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                Else
                    MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                        SIValue = Con(i).txtValue.Text
                        SIValuePercentage = Con(i).txtValue.Text
                        'Check Insurable Limits
                        If ValueToCalcFrom > Limits.InsurableMth Then
                            ValueToCalcFrom = Limits.InsurableMth
                        Else
                            ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                        End If
                        SIValue = SIValue / 100 * ValueToCalcFrom

                    ElseIf TempCon.TypeMode = "V" Then
                        SIValue = Con(i).txtValue.Text
                        '-----------------------------------------------
                        'This is When Social Insuranceis a Value From Employee
                        'No Calculations are Done 
                        '-----------------------------------------------
                        C_Final(i).MyValue = SIValue
                        Exit Sub
                    End If
                End If
                SIValueFinal = SIValue

                SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100

                Dim SIPeriodSIValue As String
                SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "C", Emp.TemGrp_Code)
                If SIValueFinal + SIPeriodSIValue > SIValueLimit Then
                    SIValueFinal = SIValueLimit - SIPeriodSIValue
                End If

                AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "C", Emp.TemGrp_Code)
                If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                    AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIContribute
                End If
                TempAnnualSIincome = AnnualSIincome + SIValueFinal


                If (TempAnnualSIincome) > (Limits.DedContrAnnual / 2) Then
                    SIValueFinal = (Limits.DedContrAnnual / 2) - (AnnualSIincome)
                    If SIValueFinal < 0 Then
                        SIValueFinal = 0
                        Period_InsurableIncome = 0
                    End If
                End If

                Exit For
            End If
        Next


        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = SIValueFinal
                Exit For
            End If
        Next

    End Sub
    Private Sub C_CalculateSocialInsurance_3(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        If GlbSILeavePerc = 0 Then
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim SIValue As Double = 0
            Dim SIValueFinal As Double = 0
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIContribution As Double

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIContribution = Emp.Emp_PrevSIContribute
            End If
            Dim LastPeriod As Boolean
            Dim SIPeriodInsurableIncome As Double
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)

            If GLBCurrentPeriod.NumberOfTotalPeriodsFORDisplayONLY = 12 Then
                LastPeriod = False
            End If



            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double

            For i = 0 To Ded.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            SIValue = Con(i).txtValue.Text
                            SIValuePercentage = Con(i).txtValue.Text
                            Period_InsurableIncome = RoundMeUp(ValueToCalcFrom)

                            If ValueToCalcFrom > Limits.InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = Limits.InsurableMth
                                    Period_InsurableIncome = Limits.InsurableMth
                                End If
                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            '***************************************************************************************************************************
                            '2021 Change
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            If ValueToCalcFrom < 0 Then
                                ValueToCalcFrom = 0
                            End If
                            'END OF 2021 change
                            '***************************************************************************************************************************


                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempCon.TypeMode = "V" Then
                            SIValue = Con(i).txtValue.Text
                            '-----------------------------------------------
                            'This is When Social Insuranceis a Value From Employee
                            'No Calculations are Done 
                            '-----------------------------------------------
                            C_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100



                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '-----------------------------------------------
                    'LOPOCA CHANGE
                    '-----------------------------------------------
                    If SIPeriodSIValue + SIValue > SIValueLimit Then
                        If Not LastPeriod Then
                            SIValue = RoundMe2(SIValueLimit - SIPeriodSIValue, 2)
                            Period_InsurableIncome = RoundMe2(Limits.InsurableMth - SIPeriodInsurableIncome, 2)
                            If SIValue < 0 Then
                                SIValue = 0
                            End If
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = SIValue
                        End If
                    End If
                    'END Of LOPOCA -----------------------------------------------




                    'For LAST PERIOD after 13
                    Dim TempLimitsInsurableAnnual As Double
                    TempLimitsInsurableAnnual = Limits.InsurableAnnual
                    Dim TempLimitsDedContrAnnual As Double
                    TempLimitsDedContrAnnual = Limits.DedContrAnnual

                    If LastPeriod Then

                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            Dim NumberOfNormalPeriodsRunUntilNow As Integer
                            NumberOfNormalPeriodsRunUntilNow = Global1.Business.FindNumberOfNormalPeriodsForThisEmployeeForThisPeriodGroup(GLBCurrentPeriod, Emp.Code)
                            TempLimitsInsurableAnnual = Limits.InsurableAnnual * NumberOfNormalPeriodsRunUntilNow / 12
                            TempLimitsDedContrAnnual = Limits.DedContrAnnual * NumberOfNormalPeriodsRunUntilNow / 12
                        End If
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            ' AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > TempLimitsInsurableAnnual Then
                            Period_InsurableIncome = RoundMeUp(TempLimitsInsurableAnnual - AnnualInsurableToDate)
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If
                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    'TOCHECK
                    Dim PercentageOfAnnualAmount As Double
                    PercentageOfAnnualAmount = (GLBMySIcontributionRate / (GLBMySIDeductionRate + GLBMySIcontributionRate)) * TempLimitsDedContrAnnual

                    'NEW
                    If (TempAnnualSIincome) > (PercentageOfAnnualAmount) Then
                        SIValueFinal = (PercentageOfAnnualAmount) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If
                    'OLD
                    'If (TempAnnualSIincome) > (TempLimitsDedContrAnnual / 2) Then
                    '    SIValueFinal = (TempLimitsDedContrAnnual / 2) - AnnualSIincome
                    '    If SIValueFinal < 0 Then
                    '        SIValueFinal = 0
                    '        Period_InsurableIncome = 0
                    '    End If
                    'End If

                    Exit For
                End If
            Next



            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal
        Else

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim SIValue As Double = 0
            Dim SIValueFinal As Double = 0
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIContribution As Double

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIContribution = Emp.Emp_PrevSIContribute
            End If
            Dim LastPeriod As Boolean
            Dim SIPeriodInsurableIncome As Double
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)
            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double

            For i = 0 To Ded.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    '************ FOR SI LEAVE*******************
                    Dim InsurableMth As Double
                    InsurableMth = RoundMe2(Limits.InsurableMth + (Limits.InsurableMth * GlbSILeavePerc / 100), 2)
                    '********************************************

                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            SIValue = Con(i).txtValue.Text
                            SIValuePercentage = Con(i).txtValue.Text
                            Period_InsurableIncome = RoundMeUp(ValueToCalcFrom)
                            If ValueToCalcFrom > InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                Else
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                End If

                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempCon.TypeMode = "V" Then
                            SIValue = Con(i).txtValue.Text
                            '-----------------------------------------------
                            'This is When Social Insuranceis a Value From Employee
                            'No Calculations are Done 
                            '-----------------------------------------------
                            C_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = InsurableMth * SIValuePercentage / 100

                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '************ FOR SI LEAVE*******************
                    Dim InsurableAnnual As Double
                    InsurableAnnual = RoundMe2(Limits.InsurableAnnual + (Limits.InsurableAnnual * GlbSILeavePerc / 100), 2)
                    '**********************************************

                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIContribute
                        End If
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > InsurableAnnual Then
                            Period_InsurableIncome = RoundMeUp(InsurableAnnual - AnnualInsurableToDate)
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If
                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    If (TempAnnualSIincome) > ((Limits.DedContrAnnual / 2) + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) Then
                        SIValueFinal = ((Limits.DedContrAnnual / 2) + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If

                    Exit For
                End If
            Next



            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal
        End If





    End Sub
    Private Sub C_CalculateSocialInsurance_2(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        If GlbSILeavePerc = 0 Then
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim SIValue As Double = 0
            Dim SIValueFinal As Double = 0
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIContribution As Double

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIContribution = Emp.Emp_PrevSIContribute
            End If
            Dim LastPeriod As Boolean
            Dim SIPeriodInsurableIncome As Double
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)

            If GLBCurrentPeriod.NumberOfTotalPeriodsFORDisplayONLY = 12 Then
                LastPeriod = False
            End If



            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double

            For i = 0 To Ded.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            SIValue = Con(i).txtValue.Text
                            SIValuePercentage = Con(i).txtValue.Text
                            Period_InsurableIncome = RoundMeUp(ValueToCalcFrom)

                            If ValueToCalcFrom > Limits.InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = Limits.InsurableMth
                                    Period_InsurableIncome = Limits.InsurableMth
                                End If
                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            '***************************************************************************************************************************
                            '2021 Change
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            If ValueToCalcFrom < 0 Then
                                ValueToCalcFrom = 0
                            End If
                            'END OF 2021 change
                            '***************************************************************************************************************************


                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempCon.TypeMode = "V" Then
                            SIValue = Con(i).txtValue.Text
                            '-----------------------------------------------
                            'This is When Social Insuranceis a Value From Employee
                            'No Calculations are Done 
                            '-----------------------------------------------
                            C_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = Limits.InsurableMth * SIValuePercentage / 100

                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '-----------------------------------------------
                    'LOPOCA CHANGE
                    '-----------------------------------------------
                    If SIPeriodSIValue + SIValue > SIValueLimit Then
                        If Not LastPeriod Then
                            SIValue = RoundMe2(SIValueLimit - SIPeriodSIValue, 2)
                            Period_InsurableIncome = RoundMe2(Limits.InsurableMth - SIPeriodInsurableIncome, 2)
                            If SIValue < 0 Then
                                SIValue = 0
                            End If
                            If Period_InsurableIncome < 0 Then
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = SIValue
                        End If
                    End If
                    'END Of LOPOCA -----------------------------------------------







                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            'AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIContribute
                        End If
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            ' AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > Limits.InsurableAnnual Then
                            Period_InsurableIncome = RoundMeUp(Limits.InsurableAnnual - AnnualInsurableToDate)
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If
                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    If (TempAnnualSIincome) > (Limits.DedContrAnnual / 2) Then
                        SIValueFinal = (Limits.DedContrAnnual / 2) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If

                    Exit For
                End If
            Next



            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal
        Else

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim SIValue As Double = 0
            Dim SIValueFinal As Double = 0
            Dim ValueToCalcFrom As Double
            Dim Ds As DataSet
            Dim Limits As New cPrSsLimits
            Dim AnnualSIincome As Double
            Dim TempAnnualSIincome As Double
            Dim Previous_SIContribution As Double

            If Emp.StartDate.Year = Me.GLBCurrentPeriod.DateFrom.Year Then
                Previous_SIContribution = Emp.Emp_PrevSIContribute
            End If
            Dim LastPeriod As Boolean
            Dim SIPeriodInsurableIncome As Double
            LastPeriod = Global1.Business.IsThisLastPeriod(Me.GLBCurrentPeriod)
            Dim SIValuePercentage As Double
            Dim SIValueLimit As Double

            For i = 0 To Ded.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    Ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(Ds) Then
                        Limits = New cPrSsLimits(Ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    '************ FOR SI LEAVE*******************
                    Dim InsurableMth As Double
                    InsurableMth = RoundMe2(Limits.InsurableMth + (Limits.InsurableMth * GlbSILeavePerc / 100), 2)
                    '********************************************

                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            SIValue = Con(i).txtValue.Text
                            SIValuePercentage = Con(i).txtValue.Text
                            Period_InsurableIncome = RoundMeUp(ValueToCalcFrom)
                            If ValueToCalcFrom > InsurableMth Then
                                If Not LastPeriod Then
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                Else
                                    ValueToCalcFrom = InsurableMth
                                    Period_InsurableIncome = InsurableMth
                                End If

                            Else
                                ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                                Period_InsurableIncome = ValueToCalcFrom
                            End If
                            SIValue = SIValue / 100 * ValueToCalcFrom

                        ElseIf TempCon.TypeMode = "V" Then
                            SIValue = Con(i).txtValue.Text
                            '-----------------------------------------------
                            'This is When Social Insuranceis a Value From Employee
                            'No Calculations are Done 
                            '-----------------------------------------------
                            C_Final(i).MyValue = SIValue
                            Exit Sub
                        End If
                    End If
                    SIValueFinal = SIValue
                    SIValueLimit = InsurableMth * SIValuePercentage / 100

                    Dim SIPeriodSIValue As String
                    Dim AnnualInsurableToDate As Double
                    SIPeriodSIValue = Global1.Business.FindSIValueForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                    SIPeriodInsurableIncome = Global1.Business.FindSIPeriodInsurableIncomeForEmployeeForPeriod(GLBCurrentPeriod, Emp.Code, Emp.TemGrp_Code)

                    '************ FOR SI LEAVE*******************
                    Dim InsurableAnnual As Double
                    InsurableAnnual = RoundMe2(Limits.InsurableAnnual + (Limits.InsurableAnnual * GlbSILeavePerc / 100), 2)
                    '**********************************************

                    If LastPeriod Then
                        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualSIincome = AnnualSIincome + Emp.Emp_PrevSIContribute
                        End If
                        AnnualInsurableToDate = Global1.Business.GetAnnualInsurableToDateForEmployee(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
                        If Emp.StartDate.Year = GLBCurrentPeriod.DateFrom.Year Then
                            AnnualInsurableToDate = AnnualInsurableToDate + Emp.PreviousEarnings
                        End If

                        If Period_InsurableIncome + AnnualInsurableToDate > InsurableAnnual Then
                            Period_InsurableIncome = RoundMeUp(InsurableAnnual - AnnualInsurableToDate)
                            If Period_InsurableIncome < 0 Then
                                MsgBox("Period Insurable issue for Employee " & Emp.Code & ", please contact iNsoft")
                                Period_InsurableIncome = 0
                            End If
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        Else
                            SIValueFinal = Period_InsurableIncome * SIValuePercentage / 100
                            Period_InsurableIncome = Period_InsurableIncome
                        End If
                    End If

                    TempAnnualSIincome = AnnualSIincome + SIValueFinal

                    If (TempAnnualSIincome) > ((Limits.DedContrAnnual / 2) + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) Then
                        SIValueFinal = ((Limits.DedContrAnnual / 2) + (Limits.DedContrAnnual * GlbSILeavePerc / 100) / 2) - AnnualSIincome
                        If SIValueFinal < 0 Then
                            SIValueFinal = 0
                            Period_InsurableIncome = 0
                        End If
                    End If

                    Exit For
                End If
            Next



            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = SIValueFinal
                    Exit For
                End If
            Next
            Me.Period_SIIncome = SIValueFinal
        End If





    End Sub
    Private Sub C_CalculateSocialCohesionFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim SCValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Con.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                        ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                        SCValue = Con(i).txtValue.Text
                        SCValue = SCValue / 100 * ValueToCalcFrom
                    ElseIf TempCon.TypeMode = "V" Then
                        SCValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'If TempCon.ConCodCode <> "" Then
        '    If TempCon.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
        '        If TempCon.FromMode = "E" Then
        '            SCValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            SCValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            Dim SocCoh As New cPrSsSocialCohesion(Emp.SocCoh_Code)
        '            If SocCoh.Code <> "" Then
        '                SCValue = SocCoh.ConValue
        '            Else
        '                SCValue = 0
        '            End If
        '        End If
        '        SCValue = SCValue / 100 * ValueToCalcFrom
        '    ElseIf TempCon.TypeMode = "V" Then
        '        If TempCon.FromMode = "E" Then
        '            SCValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            SCValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            Dim SocCoh As New cPrSsSocialCohesion(Emp.SocCoh_Code)
        '            If SocCoh.Code <> "" Then
        '                SCValue = SocCoh.ConValue
        '            Else
        '                SCValue = 0
        '            End If
        '        End If
        '    End If
        'End If
        If SCValue < 0 Then
            MsgBox("Warning - Negative Social Cohesion Fund on Employee " & GLBEmployee.Code & " " & GLBEmployee.FullName, MsgBoxStyle.Information)
            SCValue = 0
        End If
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = SCValue
                Exit For
            End If
        Next
    End Sub
    Private Sub C_CalculateUnemploymentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        If GlbSILeavePerc = 0 Then
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim UFValue As Double
            Dim ValueToCalcFrom As Double
            Dim Limits As New cPrSsLimits
            Dim AnnualUNECon As Double = 0
            Dim TempAnnualUNECon As Double = 0

            Dim ds As DataSet
            For i = 0 To Con.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(ds) Then
                        Limits = New cPrSsLimits(ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            'ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            ValueToCalcFrom = Period_InsurableIncome
                            UFValue = Con(i).txtValue.Text
                            ' Check Insurable Limits
                            'If ValueToCalcFrom > Limits.InsurableMth Then
                            '    ValueToCalcFrom = Limits.InsurableMth
                            'Else
                            '    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                            'End If

                            UFValue = UFValue / 100 * ValueToCalcFrom
                        ElseIf TempCon.TypeMode = "V" Then
                            UFValue = Con(i).txtValue.Text
                            C_Final(i).MyValue = UFValue
                            Exit Sub
                        End If
                    End If

                    AnnualUNECon = Global1.Business.FindSumForThisPeriodYearUntilNowOfContributionCodeType(GLBCurrentPeriod, Cont, Emp.Code)
                    TempAnnualUNECon = AnnualUNECon + UFValue
                    If TempAnnualUNECon > Limits.UnemAnnual Then
                        UFValue = Limits.UnemAnnual - AnnualUNECon
                    End If



                    Exit For
                End If
            Next

            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = UFValue
                    Exit For
                End If
            Next
        Else
            Dim TempCon As New cPrMsTemplateContributions
            Dim i As Integer
            Dim UFValue As Double
            Dim ValueToCalcFrom As Double
            Dim Limits As New cPrSsLimits
            Dim AnnualUNECon As Double = 0
            Dim TempAnnualUNECon As Double = 0

            Dim ds As DataSet
            For i = 0 To Con.Length - 1
                If Cont.Code = Con(i).Con.ConCodCode Then
                    TempCon = Con(i).Con

                    ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
                    If CheckDataSet(ds) Then
                        Limits = New cPrSsLimits(ds.Tables(0).Rows(0))
                    Else
                        MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TempCon.ConCodCode <> "" Then
                        If TempCon.TypeMode = "P" Then
                            'ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                            ValueToCalcFrom = Period_InsurableIncome
                            UFValue = Con(i).txtValue.Text
                            ' Check Insurable Limits
                            'If ValueToCalcFrom > Limits.InsurableMth Then
                            '    ValueToCalcFrom = Limits.InsurableMth
                            'Else
                            '    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                            'End If

                            UFValue = UFValue / 100 * ValueToCalcFrom
                        ElseIf TempCon.TypeMode = "V" Then
                            UFValue = Con(i).txtValue.Text
                        End If
                    End If
                    Dim UnemAnnual As Double
                    UnemAnnual = RoundMe2(Limits.UnemAnnual + (Limits.UnemAnnual * GlbSILeavePerc / 100), 2)

                    AnnualUNECon = Global1.Business.FindSumForThisPeriodYearUntilNowOfContributionCodeType(GLBCurrentPeriod, Cont, Emp.Code)
                    TempAnnualUNECon = AnnualUNECon + UFValue
                    If TempAnnualUNECon > UnemAnnual Then
                        UFValue = UnemAnnual - AnnualUNECon
                    End If

                    Exit For
                End If
            Next

            For i = 0 To C_Final.Length - 1
                If Cont.Code = C_Final(i).Con.ConCodCode Then
                    C_Final(i).MyValue = UFValue
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub C_CalculateSpecialTax(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim STValue As Double
        Dim ValueToCalcFrom As Double
        Dim DsSTax As DataSet
        Dim k As Integer
        Dim Donotchecklimit As Boolean = False


        For i = 0 To Con.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        If TempCon.FromMode = "X" And Con(i).txtValue.Text <> 0 Then
                            If Con(i).txtValue.Text = -1 Then
                                STValue = 0
                                C_Final(i).MyValue = STValue
                            Else
                                STValue = Con(i).txtValue.Text
                                C_Final(i).MyValue = STValue
                            End If
                        Else
                            ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)

                            'MARKOS DRAKOS
                            ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome4 '+ GetPeriodSplitForST()
                            If Global1.PARAM_SpecialDedonOTI1 Then
                                ValueToCalcFrom = ValueToCalcFrom + Emp.OtherIncome3
                            End If

                            ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)

                            DsSTax = Global1.Business.GetAllPrSsExtraTaxTable

                            Dim TaxBracket As Double
                            Dim TAX As Double = 0
                            Dim RemAmount As Double = ValueToCalcFrom
                            Dim PrevRemAmount As Double
                            Dim TaxPercentage As Double

                            If CheckDataSet(DsSTax) Then
                                For k = 0 To DsSTax.Tables(0).Rows.Count - 1
                                    TaxBracket = DbNullToInt(DsSTax.Tables(0).Rows(k).Item(2))
                                    TaxPercentage = DbNullToDouble(DsSTax.Tables(0).Rows(k).Item(4))
                                    PrevRemAmount = RemAmount
                                    RemAmount = RemAmount - TaxBracket
                                    If RemAmount <= 0 Then
                                        If k = 0 Then
                                            Donotchecklimit = True
                                        End If
                                        Dim XX As Double
                                        XX = (PrevRemAmount * TaxPercentage / 100)
                                        TAX = TAX + (PrevRemAmount * TaxPercentage / 100)
                                        Exit For
                                    End If
                                    Dim XY As Double
                                    XY = TAX + (TaxBracket * TaxPercentage / 100)
                                    TAX = TAX + (TaxBracket * TaxPercentage / 100)
                                Next
                                STValue = TAX
                                If Not Donotchecklimit Then
                                    If STValue < Global1.GLB_SpecialTaxContributionLimit Then
                                        STValue = Global1.GLB_SpecialTaxContributionLimit
                                    End If
                                End If
                                C_Final(i).MyValue = STValue
                            End If
                        End If
                    ElseIf TempCon.TypeMode = "V" Then
                        STValue = Con(i).txtValue.Text
                        C_Final(i).MyValue = STValue
                        Exit Sub
                    End If
                End If
            End If
        Next

    End Sub
    Private Sub C_CalculateOtherContributions(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim OTHERValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Con.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con

                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                        OTHERValue = Con(i).txtValue.Text
                        OTHERValue = OTHERValue / 100 * ValueToCalcFrom
                    ElseIf TempCon.TypeMode = "V" Then
                        OTHERValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next


        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = OTHERValue
                Exit For
            End If
        Next

    End Sub
    ''''''''''''''''''''''''
    Private Sub C_CalculateUnionMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim UnionMFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Con.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con

                Dim Union As New cPrAnUnions(Emp.Uni_Code)
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                        UnionMFValue = Con(i).txtValue.Text
                        UnionMFValue = UnionMFValue / 100 * ValueToCalcFrom
                    ElseIf TempCon.TypeMode = "V" Then
                        UnionMFValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'Dim Union As New cPrAnUnions(Emp.Uni_Code)
        'If TempCon.ConCodCode <> "" Then
        '    If TempCon.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
        '        If TempCon.FromMode = "E" Then
        '            UnionMFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            UnionMFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                UnionMFValue = Union.MonthlyMF
        '            Else
        '                UnionMFValue = 0
        '            End If
        '        End If
        '        UnionMFValue = UnionMFValue / 100 * ValueToCalcFrom
        '    ElseIf TempCon.TypeMode = "V" Then
        '        If TempCon.FromMode = "E" Then
        '            UnionMFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            UnionMFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                UnionMFValue = Union.MonthlyMF
        '            Else
        '                UnionMFValue = 0
        '            End If
        '        End If

        '    End If
        'End If

        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = UnionMFValue
                Exit For
            End If
        Next

    End Sub
    Private Sub C_CalculateWelFairFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim WFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                Dim Union As New cPrAnUnions(Emp.Uni_Code)
                If TempCon.ConCodCode <> "" Then
                    If TempCon.TypeMode = "P" Then
                        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                        WFValue = Con(i).txtValue.Text
                        WFValue = WFValue / 100 * ValueToCalcFrom
                    ElseIf TempCon.TypeMode = "V" Then
                        WFValue = Con(i).txtValue.Text
                    End If
                End If
                Exit For
            End If
        Next
        'Dim Union As New cPrAnUnions(Emp.Uni_Code)
        'If TempCon.ConCodCode <> "" Then
        '    If TempCon.TypeMode = "P" Then
        '        ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
        '        If TempCon.FromMode = "E" Then
        '            WFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            WFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                WFValue = Union.WelfareRate
        '            Else
        '                WFValue = 0
        '            End If
        '        End If
        '        WFValue = WFValue / 100 * ValueToCalcFrom
        '    ElseIf TempCon.TypeMode = "V" Then
        '        If TempCon.FromMode = "E" Then
        '            WFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "F" Then
        '            WFValue = EmpCon.MyValue
        '        ElseIf TempCon.FromMode = "T" Then
        '            If Union.Code <> "" Then
        '                WFValue = Union.WelfareRate
        '            Else
        '                WFValue = 0
        '            End If
        '        End If

        '    End If
        'End If
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = WFValue
                Exit For
            End If
        Next
    End Sub

#End Region

    Public Function DoCalculations() As Boolean
        Dim F As Boolean = False
        If Global1.PARAM_PAYE Then
            F = RunCalculations(False)
        Else
            GLBITValueWithRecuring = 0
            GLBITValueWithNORecuring = 0
            GLBDNValueOfRecuring = 0
            '  If GLBEmployee.TerminateDate <> "" Then
            'F = RunCalculations(False)
            'Else
            F = RunCalculations(True)
            F = RunCalculations(False)
            ' End If
            If GlbRunroundUp Then
                Dim RoundedNet As Double = 0
                Dim Net As Double = 0
                Me.GLBRoundUpAmount = 0
                Net = Me.txtNetSalary.Text
                RoundedNet = Utils.RoundMeUp(Net)
                Me.GLBRoundUpAmount = RoundMe2(Net - RoundedNet, 2)
                GLBITValueWithRecuring = 0
                GLBITValueWithNORecuring = 0
                GLBDNValueOfRecuring = 0
                '  If GLBEmployee.TerminateDate <> "" Then
                'F = RunCalculations(False)
                'Else
                F = RunCalculations(True)
                F = RunCalculations(False)

                Me.GLBRoundUpAmount = 0
                GlbRunroundUp = False

            End If
        End If
        Return F

    End Function
    Private Function RunCalculations(ByVal OnlyRecuringEarnings As Boolean) As Boolean

        Calculated = False
        GLBRecurringEarning = 0
        GLBRecurringEarning14 = 0
        GLBPensionDeduction = 0
        GLBBenefitsRecurringEarning = 0
        GLBBenefitsRecurringEarning14 = 0
        GLBCOLAValue = 0
        GLBSalaryForRate = 0
        GLB_MF_ByTheEndOfTheYear = 0
        GLB_PF_ByTheEndOfTheYear = 0
        GLB_PenF_ByTheEndOfTheYear = 0
        GLB_WidF_ByTheEndOfTheYear = 0
        GLB_UNION_ByTheEndOfTheYear = 0
        GLB_DN_ByTheEndOfTheYear = 0
        GLB_GESI_ByTheEndOfTheYear = 0
        GLB_BIK_GESI_ByTheEndOfTheYear = 0

        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status <> "POST" And Hdr.Status <> "CALC" Then
                If CheckForLoan(GLBEmployee.Code) Then
                    CalculateAnnualLeaveForThisMonth()
                    CalculateEarnings(GLBEmployee, OnlyRecuringEarnings)
                    CalculateDeductions(GLBEmployee, OnlyRecuringEarnings)
                    CalculateContributions(GLBEmployee)
                    Calculated = True
                End If
            Else
                If Hdr.Status = "POST" Then
                    MsgBox("This Entry is POSTED cannot Calculate", MsgBoxStyle.Information)
                End If
                If Hdr.Status = "CALC" Then
                    MsgBox("This Entry is CALCULATED cannot Calculate", MsgBoxStyle.Information)
                End If
            End If
        Else
            If CheckForLoan(GLBEmployee.Code) Then
                CalculateAnnualLeaveForThisMonth()
                CalculateEarnings(GLBEmployee, OnlyRecuringEarnings)
                CalculateDeductions(GLBEmployee, OnlyRecuringEarnings)
                CalculateContributions(GLBEmployee)
                Calculated = True
            End If
        End If
        Me.txtNetSalary.Text = Format(RoundMe3(CDbl(Me.txtTotalEarnings.Text) - CDbl(Me.txtTotalDeductions.Text), 2), "0.00")
        Dim Net As Double
        Try
            Net = CDbl(Me.txtNetSalary.Text)
            If Net < 0 Then
                If Not OnlyRecuringEarnings Then
                    MsgBox("Negative NET on Employee " & GLBEmployee.Code & " " & GLBEmployee.FullName, MsgBoxStyle.Critical)
                    If Global1.PARAM_ShowNegativeNet Then
                        AddNegativeNet(GLBEmployee.Code, GLBEmployee.FullName, Net)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        Return Calculated
    End Function
    Private Sub AddNegativeNet(ByVal EmpCode As String, ByVal EmpName As String, ByVal Net As Double)
        CType(Me.Owner, FrmPayroll1).addnegativenet(EmpCode, EmpName, Net)
    End Sub
    Private Function CheckForLoan(ByVal EmpCode As String) As Boolean
        Dim F As Boolean = True

        Dim Ds As DataSet
        Dim Exx As New Exception
        Dim j As Integer
        Ds = Global1.Business.GetEmployeeLoans1(EmpCode, "OPEN")
        If CheckDataSet(Ds) Then
            For j = 0 To Ds.Tables(0).Rows.Count - 1

                Dim i As Integer
                Dim DedCode As String
                Dim LoanCode As String
                Dim RemAmount As Double
                Dim DedAmount As Double
                Dim LoanId As Integer
                LoanCode = DbNullToString(Ds.Tables(0).Rows(j).Item(0))
                Dim ds2 As DataSet
                ds2 = Global1.Business.GetEmployeeLoans2(EmpCode, "OPEN", LoanCode)

                DedCode = DbNullToString(ds2.Tables(0).Rows(0).Item(0))
                Dim ds3 As DataSet
                LoanId = Global1.Business.GetEmployeeLoans3(EmpCode, "OPEN", LoanCode)
                RemAmount = Global1.Business.GetEmployeeLoanTotal(EmpCode, LoanCode)

                For i = 0 To Me.Ded.Length - 1
                    If Not Ded(i).Ded Is Nothing Then
                        Dim ED As New cPrMsEmployeeDeductions(EmpCode, Ded(i).Ded.DedCodCode)
                        Dim Dedu As New cPrMsDeductionCodes(Ded(i).Ded.DedCodCode)

                        If Dedu.Code = DedCode Then

                            Dim TempDed As New cPrMsTemplateDeductions
                            Dim k As Integer
                            Dim ValueToCalcFrom As Double
                            For k = 0 To Ded.Length - 1
                                If Dedu.Code = Ded(k).Ded.DedCodCode Then
                                    TempDed = Ded(k).Ded
                                    If TempDed.DedCodCode <> "" Then
                                        If TempDed.TypeMode = "P" Then
                                            ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                                            DedAmount = Ded(k).txtValue.Text
                                            DedAmount = DedAmount / 100 * ValueToCalcFrom
                                        ElseIf TempDed.TypeMode = "V" Then
                                            DedAmount = Ded(k).txtValue.Text
                                        End If
                                    End If
                                    Exit For
                                End If
                            Next


                            If DedAmount > RemAmount Then
                                MsgBox("Deducted amount for Loan " & LoanCode & " of Employee " & EmpCode & " is greater than Loan Balance.Cannot Continue with Calculation.Remaining amount is:" & Format(RemAmount, "0.00"), MsgBoxStyle.Critical)
                                F = False
                                Exit For
                            End If
                        End If
                    End If
                Next
            Next
        Else

            'Dim Ans As MsgBoxResult
            'Ans = MsgBox("There are no Loans with Status OPEN for Employee  " & EmpCode & " continue with Loan Deduction ?", MsgBoxStyle.YesNo)
            'If Ans = MsgBoxResult.No Then
            '    F = False
            'End If
        End If

        Return F


    End Function
    Private Sub ReCalculate()
        Me.txtTotalEarnings.Text = Format(CalculateTotalEarnings, "0.00")
        Me.txtTotalDeductions.Text = Format(CalculateTotalDeductions, "0.00")
        Me.txtTotalContributions.Text = Format(CalculateTotalContributions, "0.00")
        Me.txtNetSalary.Text = Format(RoundMe3(CDbl(Me.txtTotalEarnings.Text) - CDbl(Me.txtTotalDeductions.Text), 2), "0.00")
    End Sub
    Private Function FindValueOfFormula(ByVal CalcFormula As String, Optional ByVal FromTax As Boolean = False) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        Dim SeqOf13 As String = ""
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                If FromTax Then
                    Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                    If Ern.ErnTypCode = "3A" Then
                        If S <> E_Final(k).Earn.Sequence Then
                            TaxableAdditionFor13 = E_Final(k).MyValue
                        End If
                    End If
                End If
                'Debug.WriteLine(E_Final(k).Earn.Sequence.ToString)
                If S = E_Final(k).Earn.Sequence Then
                    Val = Val + E_Final(k).MyValue
                    Exit For
                End If
            Next
        Next
        If FromTax Then
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If Ern.ErnTypCode = "3A" Then
                    SeqOf13 = E_Final(k).Earn.Sequence
                    Exit For
                End If
            Next
            For i = 0 To CalcFormula.Length - 1
                S = CalcFormula.Substring(i, 1)
                If SeqOf13 = S Then
                    TaxableAdditionFor13 = 0
                    Exit For
                End If
            Next
        End If
        Return Val
    End Function
    Private Function FindValueOfFormulaONLYRecuring(ByVal CalcFormula As String) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        Dim SeqOf13 As String = ""
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If S = E_Final(k).Earn.Sequence Then
                    'SA=SALARY
                    'BK=Bonus Recuring
                    'CL=Cola
                    'RE=Recouring Earning
                    'PD=Pension Decrease
                    If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BR" Or Ern.ErnTypCode = "PD" Or Ern.ErnTypCode = "R2" Or Ern.ErnTypCode = "B2" Then
                        Val = Val + E_Final(k).MyValue
                        Exit For
                    End If
                End If
            Next
        Next

        Return Val
    End Function
    Private Function FindValueOfFormula_ForFutureSI(ByVal CalcFormula As String, Optional ByVal FromTax As Boolean = False) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        Dim SeqOf13 As String = ""
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If FromTax Then
                    If Ern.ErnTypCode = "3A" Then
                        If S <> E_Final(k).Earn.Sequence Then
                            TaxableAdditionFor13 = E_Final(k).MyValue
                        End If
                    End If
                End If
                Debug.WriteLine(E_Final(k).Earn.Sequence.ToString)

                If S = E_Final(k).Earn.Sequence Then
                    If Ern.ErnTypCode = "SA" Then
                        Val = Val + Me.GrossFor13AND14Calc
                        Exit For
                    Else
                        Val = Val + E_Final(k).MyValue
                        Exit For
                    End If
                End If
            Next
        Next
        If FromTax Then
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If Ern.ErnTypCode = "3A" Then
                    SeqOf13 = E_Final(k).Earn.Sequence
                    Exit For
                End If
            Next
            For i = 0 To CalcFormula.Length - 1
                S = CalcFormula.Substring(i, 1)
                If SeqOf13 = S Then
                    TaxableAdditionFor13 = 0
                    Exit For
                End If
            Next
        End If
        Return Val
    End Function
    Private Function FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY(ByVal CalcFormula As String) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        Dim SeqOf13 As String = ""
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If S = E_Final(k).Earn.Sequence Then
                    'SA=SALARY
                    'BK=Bonus Recuring
                    'CL=Cola
                    'RE=Recouring Earnin
                    'PD pension

                    'If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "CL" Then
                    'If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BR" Or Ern.ErnTypCode = "PD" Or Ern.ErnTypCode = "R2" Or Ern.ErnTypCode = "B2" Then
                    If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Or Ern.ErnTypCode = "PD" Or Ern.ErnTypCode = "R2" Or Ern.ErnTypCode = "B2" Then
                        If Ern.ErnTypCode = "SA" Then
                            Val = Val + Me.GrossFor13AND14Calc
                            Exit For
                        Else
                            Val = Val + E_Final(k).MyValue
                            Exit For
                        End If

                    End If
                End If
            Next
        Next

        Return Val
    End Function
    Private Function FindValueOfFormulaONLYRecuring_ForFuture_NORMAL_SALARY_GESINormal(ByVal CalcFormula As String) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        Dim SeqOf13 As String = ""
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If S = E_Final(k).Earn.Sequence Then
                    'SA=SALARY
                    'BK=Bonus Recuring
                    'CL=Cola
                    'RE=Recouring Earnin
                    'If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "CL" Then
                    'If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BR" Or Ern.ErnTypCode = "PD" Or Ern.ErnTypCode = "R2" Or Ern.ErnTypCode = "B2" Then
                    If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "PD" Or Ern.ErnTypCode = "R2" Then
                        If Ern.ErnTypCode = "SA" Then
                            Val = Val + Me.GrossFor13AND14Calc
                            Exit For
                        Else
                            Val = Val + E_Final(k).MyValue
                            Exit For
                        End If

                    End If
                End If
            Next
        Next

        Return Val
    End Function
    Private Function FindValueOfFormulaONLYRecuring_ForFuture_BIK_forGESI(ByVal CalcFormula As String) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        Dim SeqOf13 As String = ""
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                If S = E_Final(k).Earn.Sequence Then
                    'SA=SALARY
                    'BK=Bonus Recuring
                    'CL=Cola
                    'RE=Recouring Earnin
                    'If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "CL" Then
                    'If Ern.ErnTypCode = "SA" Or Ern.ErnTypCode = "CL" Or Ern.ErnTypCode = "RE" Or Ern.ErnTypCode = "BR" Or Ern.ErnTypCode = "PD" Or Ern.ErnTypCode = "R2" Or Ern.ErnTypCode = "B2" Then
                    If Ern.ErnTypCode = "BR" Or Ern.ErnTypCode = "B2" Then
                        Val = Val + E_Final(k).MyValue
                        Exit For
                    End If
                End If
            Next
        Next

        Return Val
    End Function
    Private Function FindValueOfFormula_Extrabolation(ByVal CalcFormula As String, ByVal ExcludeSalary As Boolean) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0

        If ExcludeSalary Then
            For i = 0 To CalcFormula.Length - 1
                S = CalcFormula.Substring(i, 1)
                For k = 0 To E_Final.Length - 1
                    If S = E_Final(k).Earn.Sequence Then
                        Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                        If Ern.ErnTypCode <> "SA" Then
                            Val = Val + E_Final(k).MyValue
                        End If
                    End If
                Next
            Next
        Else
            For i = 0 To CalcFormula.Length - 1
                S = CalcFormula.Substring(i, 1)
                For k = 0 To E_Final.Length - 1
                    If S = E_Final(k).Earn.Sequence Then
                        Dim Ern As New cPrMsEarningCodes(E_Final(k).Earn.ErnCodCode)
                        If Ern.ErnTypCode = "SA" Then
                            Val = Val + E_Final(k).MyValue
                        End If
                    End If
                Next
            Next
        End If

        Return Val
    End Function

    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        TryToSavePayroll(False)
    End Sub
    Public Sub TryToSavePayroll(ByVal SuppressMsg As Boolean)

        Dim Exx As New Exception
        Dim i As Integer
        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status = "POST" Then

                MsgBox("There is a POSTED Calculated Payroll for this Employee for this Period", MsgBoxStyle.Information)
                Exit Sub
            End If
            If Hdr.Status = "CALC" Then
                MsgBox("There is a CALCULATED Payroll for this Employee for this Period", MsgBoxStyle.Information)
                Exit Sub
            End If
            If Hdr.Status = "PREP" Then
                If Not Calculated Then
                    If Not SuppressMsg Then
                        MsgBox("Please Calculate Payroll First and then Save", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            End If
            If Hdr.Status = "<  >" Then
                If Not SuppressMsg Then
                    MsgBox("Please Calculate Payroll First and then Save", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        End If
        If Calculated Then
            Try
                Global1.Business.BeginTransaction()
                With Hdr
                    .Emp_Code = GLBEmployee.Code
                    .PrdGrp_Code = GLBCurrentPeriod.PrdGrpCode
                    .PrdCod_Code = GLBCurrentPeriod.Code
                    .PayCat_Code = GLBCurrentPeriod.PayCat_Code
                    .MyDate = Now.Date
                    .Status = "CALC"
                    .TotalErnPeriod = CalculateTotalEarnings()
                    .TotalErnYTD = GetErnYTD(GLBEmployee, GLBCurrentPeriod) + .TotalErnPeriod
                    .TotalDedPeriod = CalculateTotalDeductions()
                    .TotalDedYTD = GetDedYTD(GLBEmployee, GLBCurrentPeriod) + .TotalDedPeriod
                    .TotalConPeriod = CalculateTotalContributions()
                    .TotalConYTD = GetConYTD(GLBEmployee, GLBCurrentPeriod) + .TotalConPeriod
                    .SIIncome = RoundMe2(Period_SIIncome, 0)
                    .TaxableIncome = RoundMe2(Period_TaxableIncome + TaxableAdditionFor13, 2)
                    .PaymentMethod = Findpaymethod()
                    .PaymentRef = "PAY REF"
                    If Global1.PARAM_EmpCodeinChequeRef Then
                        .PaymentRef = GLBEmployee.Code
                    End If
                    .PeriodUnits = Me.txtActualUnits.Text
                    '.AnnualUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)
                    .AnnualUnits = CDbl(Me.txtAnnualUnits.Text)
                    .AnnualLeave = 0
                    .LifeInsurance = Period_LifeInsurance
                    If Global1.PARAM_PAYE = "1" Then
                        .Discounts = Period_Discounts
                        .MyFE = 0
                    Else
                        .Discounts = Period_Discounts - Period_FE
                        .MyFE = Period_FE
                    End If
                    .InterfaceStatus = "OUTS"
                    .Overtime1 = Me.txtOvertime1.Text
                    .Overtime2 = Me.txtOvertime2.Text
                    .Overtime3 = Me.txtOvertime3.Text
                    '''
                    .Sectors = Me.txtSectors.Text
                    .DutyHours = Me.txtDutyHours.Text
                    .FlightHours = Me.TxtFlightHours.Text
                    .Commission = Me.txtCommission.Text
                    .OverLay = Me.txtOverLay.Text
                    .PBAmount = Me.txtPBAmount.Text
                    .PBRate = Me.txtPBRate.Text

                    .PeriodSplit = Me.GLB_SPlit_PeriodSplit  'Me.txtPeriodSplit
                    .PeriodSplitSI = Me.GLB_SPlit_PeriodSIonSplit   'Me.txtPeriodSplit

                    '''


                    .SIUnits = Me.txtSILeaveUnits.Text
                    .NetSalary = Me.txtNetSalary.Text

                    Dim NetYTD As Double
                    NetYTD = GetNetYTD(GLBEmployee, GLBCurrentPeriod) + .NetSalary

                    .NetYTD = NetYTD
                    .PfOnAgreedSalary = GLBEmployee.AgreedSalary
                    .BasisOnSalary = GLBEmployee.BonusOnsalary

                    .MonthlySalary = Me.GlbEmpSalary.SalaryValue
                    .PeriodInsurable = Me.Period_InsurableIncome
                    .TemGrpCode = GLBEmployee.TemGrp_Code
                    .ChequeNo = ""
                    If Global1.PARAM_SplitIsEnabled And Not Global1.PARAM_PAYE Then
                        .TaxableFromOther = GLBEmployee.OtherIncome4
                    Else
                        .TaxableFromOther = GLBEmployee.OtherIncome4 + Me.GetPeriodSplitForTAX
                    End If

                    .Currency = GLBEmployee.Cur_Code
                    .CurRate = Me.CurRate
                    .NormalDays = Global1.GLBMonthNormalDays
                    .Salary1 = GlbSalary1
                    .Salary2 = GlbSalary2
                    If CType(Me.Owner, FrmPayroll1).CBReloadsalary.CheckState = CheckState.Checked Then
                        Dim TempEmp As New cPrMsEmployees(GLBEmployee.Code)
                        .A1 = TempEmp.EmpAn1_Code
                        .A2 = TempEmp.EmpAn2_Code
                        .A3 = TempEmp.EmpAn3_Code
                        .A4 = TempEmp.EmpAn4_Code
                        .A5 = TempEmp.EmpAn5_Code
                        .Union = TempEmp.Uni_Code
                        .Position = TempEmp.EmpPos_Code
                        .AnalGen1 = TempEmp.AnalGen1
                        .Maternity = TempEmp.Maternity
                        .FEControlAmount = TempEmp.FEControlAmount
                    Else
                        .A1 = GLBEmployee.EmpAn1_Code
                        .A2 = GLBEmployee.EmpAn2_Code
                        .A3 = GLBEmployee.EmpAn3_Code
                        .A4 = GLBEmployee.EmpAn4_Code
                        .A5 = GLBEmployee.EmpAn5_Code
                        .Union = GLBEmployee.Uni_Code
                        .Position = GLBEmployee.EmpPos_Code
                        .AnalGen1 = GLBEmployee.AnalGen1
                        .Maternity = GLBEmployee.Maternity
                        .FEControlAmount = GLBEmployee.FEControlAmount
                    End If
                    .FEPercent = GLBPercentageOfFE
                    .TaxOnBIK = GLBTaxOnBIK
                    .SIPension = GLBEmployee.OtherIncome3
                    .GOVPension = 0

                    If CDbl(Me.txtActualUnits.Text) = 0 Then
                        .MyRate = 0
                    Else
                        .MyRate = RoundMe3((GLBCOLAValue + GLBSalaryForRate) / Me.txtActualUnits.Text, 4)
                    End If


                    .COLA = GLBCOLAValue

                    .GesiD = PeriodGesiDValue
                    .GesiC = PeriodGesiCValue
                    .Medical = PeriodExtraMedicalValue

                    .Company = Me.GLBCompany.Code
                    .Year = Me.GLBCurrentPeriod.DateFrom.Year
                    .GESIAbleAmount = GLBGesiAmount

                    .BIK_GESID = Period_BIK_GesiDValue
                    .BIK_GESIC = Period_BIK_GesiCValue
                    .BIK_GESIAble = BIK_GLBGesiAmount
                    Debug.WriteLine(Me.GLBBenefitsRecurringEarning) 'current Month



                    If Not .Save Then

                        Throw Exx
                    End If




                End With
                Dim Count As Integer = 0

                If Not Global1.Business.DeleteAllEDCFromTrxnLines(Hdr.Id) Then

                    Throw Exx
                End If

        'Saving Earnings
        Dim YearToDate As Double
        Dim Ern As cPrMsTemplateEarnings
        For i = 0 To E_Final.Length - 1
            If Not E_Final(i).Earn.ErnCodCode Is Nothing Then
                Count = Count + 1
                Ern = E_Final(i).Earn
                Dim E As New cPrTxTrxnLines(Hdr.Id, Ern)
                YearToDate = Global1.Business.FindYTD_EDC(GLBEmployee, GLBCurrentPeriod, Ern.ErnCodCode, "E")
                '  If YearToDate = 0 Then
                'YearToDate = E_Final(i).txtValue.Text
                'End If
                With E
                    .TrxLin_Id = Count
                    .TrxHdr_Id = Hdr.Id
                    .TrxLin_Type = "E"
                    .ErnCod_Code = Ern.ErnCodCode
                    .TrxLin_PeriodValue = E_Final(i).txtValue.Text
                    .TrxLin_YTDValue = .TrxLin_PeriodValue + YearToDate
                    .TrxLin_EDC = Me.Ern(i).txtValue.Text
                    .TrxLin_EDCDescription = Ern.DisplayName
                    .TrxLin_ConsolDesc = Ern.ConsolDesc

                    If Not .Save Then

                        Throw Exx
                    End If
                End With
            End If
        Next


        'Saving Deductions()
        Dim Ded As cPrMsTemplateDeductions
        For i = 0 To D_Final.Length - 1
            If Not D_Final(i).Ded.DedCodCode Is Nothing Then
                Count = Count + 1
                Ded = D_Final(i).Ded
                Dim D As New cPrTxTrxnLines(Hdr.Id, Ded)
                YearToDate = Global1.Business.FindYTD_EDC(GLBEmployee, GLBCurrentPeriod, Ded.DedCodCode, "D")
                'If YearToDate = 0 Then
                '    YearToDate = D_Final(i).txtValue.Text
                'End If
                With D
                    .TrxLin_Id = Count
                    .TrxHdr_Id = Hdr.Id
                    .TrxLin_Type = "D"
                    .DedCod_Code = Ded.DedCodCode
                    .TrxLin_PeriodValue = D_Final(i).txtValue.Text
                    .TrxLin_YTDValue = .TrxLin_PeriodValue + YearToDate
                    .TrxLin_EDC = Me.Ded(i).txtValue.Text
                    .TrxLin_EDCDescription = Ded.DisplayName
                    .TrxLin_ConsolDesc = Ded.ConsolDesc
                    If Not .Save Then

                        Throw Exx
                    End If
                End With
            End If
        Next


        'Saving Contributions
        Dim Con As cPrMsTemplateContributions
        For i = 0 To C_Final.Length - 1
            If Not C_Final(i).Con.ConCodCode Is Nothing Then
                Count = Count + 1
                Con = C_Final(i).Con
                Dim C As New cPrTxTrxnLines(Hdr.Id, Con)
                YearToDate = Global1.Business.FindYTD_EDC(GLBEmployee, GLBCurrentPeriod, Con.ConCodCode, "C")
                'If YearToDate = 0 Then
                '    YearToDate = C_Final(i).txtValue.Text
                'End If
                With C
                    .TrxLin_Id = Count
                    .TrxHdr_Id = Hdr.Id
                    .TrxLin_Type = "C"
                    .ConCod_Code = Con.ConCodCode
                    .TrxLin_PeriodValue = C_Final(i).txtValue.Text
                    .TrxLin_YTDValue = .TrxLin_PeriodValue + YearToDate
                    .TrxLin_EDC = Me.Con(i).txtValue.Text
                    .TrxLin_EDCDescription = Con.DisplayName
                    .TrxLin_ConsolDesc = Con.ConsolDesc
                    If Not .Save Then

                        Throw Exx
                    End If
                End With
            End If
        Next


        If Global1.PARAM_AnnualLeaveAllocation Then
            If Me.GLBAnnualAllocationForthisTemplate Then
                'If Me.GLBEmployee.PayUni_Code = "2" Then
                'Global1.Business.updateAnnualLeaveHeaderId(Hdr.Emp_Code, Hdr.Id)
                Dim AL As New cPrTxEmployeeLeave
                With AL
                    .Id = 0
                    .EmpCode = Me.GLBEmployee.Code
                    .Status = "Approved"
                    .Type = "1"
                    .ReqDate = Now.Date
                    .ProcDate = Now.Date
                    .FromDate = Now.Date
                    .ToDate = Now.Date
                    .ProcBy = Global1.GLBUserId
                    .Units = GLBAnnualLeaveUnits
                    .Action = AN_IncreaseCODE
                    .HdrId = Hdr.Id
                    If Not .Save() Then
                        Throw Exx
                    End If
                End With
                'End If
            End If
        End If


        SaveIR59(Me.GLBEmployee.Code, Me.GLBCurrentPeriod.Code)



        Global1.Business.CommitTransaction()
        If Not SuppressMsg Then
            MsgBox("Payroll Succefully Saved ", MsgBoxStyle.Information)
        End If
        FixStatus("CALC")
            Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(Exx)
        End Try
        Else
        MsgBox("Please Calculate Payroll first and then Save", MsgBoxStyle.Information)
        End If

    End Sub
    Private Function Findpaymethod() As String
        Dim S As String = "CASH"
        If Me.GLBEmployee.PmtMth_Code = "1" Then
            S = "CASH"
        ElseIf Me.GLBEmployee.PmtMth_Code = "2" Then
            S = "CHEQUE"
        ElseIf Me.GLBEmployee.PmtMth_Code = "3" Then
            S = "BANK"
        End If
        Return S
    End Function
    Private Sub FixStatus(ByVal Status As String)
        Select Case Status
            Case "<  >"
                Me.ComboStatus.SelectedIndex = 0
            Case "PREP"
                Me.ComboStatus.SelectedIndex = 1
            Case "CALC"
                Me.ComboStatus.SelectedIndex = 2
            Case "POST"
                Me.ComboStatus.SelectedIndex = 3
        End Select
    End Sub
    Private Function CalculateTotalEarnings() As Double
        Dim i As Integer
        Dim Value As Double = 0
        For i = 0 To E_Final.Length - 1
            If Not Ern(i).Ern Is Nothing Then
                Dim Earn As New cPrMsEarningCodes(Ern(i).Ern.ErnCodCode)
                'If Earn.ErnTypCode <> "SI" And Earn.ErnTypCode <> "3E" And Earn.ErnTypCode <> "4E" Then
                If Earn.ErnTypCode <> "3E" And Earn.ErnTypCode <> "4E" And Earn.ErnTypCode <> "UM" And Earn.ErnTypCode <> "LP" And Earn.ErnTypCode <> "BK" And Earn.ErnTypCode <> "BR" And Earn.ErnTypCode <> "B2" Then
                    Value = Value + E_Final(i).txtValue.Text
                End If
                If Earn.ErnTypCode = "SI" Then
                    Value = Value - E_Final(i).txtValue.Text
                End If
                If Earn.ErnTypCode = "FI" Then
                    Value = Value - E_Final(i).txtValue.Text
                End If


            End If
        Next
        Return Value
    End Function
    Private Function CalculateTotalDeductions() As Double
        Dim i As Integer
        Dim Value As Double = 0
        For i = 0 To D_Final.Length - 1
            Value = Value + D_Final(i).txtValue.Text
        Next
        Return Value
    End Function
    Private Function CalculateTotalContributions() As Double
        Dim i As Integer
        Dim Value As Double = 0
        For i = 0 To C_Final.Length - 1
            Value = Value + C_Final(i).txtValue.Text
        Next
        Return Value
    End Function
    Private Function GetErnYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Dim Value As Double
        Value = Global1.Business.GetErnYTD(GLBEmployee, GLBCurrentPeriod)
        Return Value
    End Function
    Private Function GetNetYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Dim Value As Double
        Value = Global1.Business.GetNetYTD(GLBEmployee, GLBCurrentPeriod)
        Return Value
    End Function
    Private Function GetDedYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Dim Value As Double
        Value = Global1.Business.GetDedYTD(GLBEmployee, GLBCurrentPeriod)
        Return Value
    End Function
    Private Function GetConYTD(ByVal GLBEmployee As cPrMsEmployees, ByVal GLBCurrentPeriod As cPrMsPeriodCodes) As Double
        Dim Value As Double
        Value = Global1.Business.GetConYTD(GLBEmployee, GLBCurrentPeriod)
        Return Value

    End Function

    Private Sub TSBCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCalculate.Click
        Dim i As Integer
        For i = 0 To E_Final.Length - 1
            E_Final(i).MyValue = 0
        Next

        DoCalculations()
        txtTempstatus.Text = "CALC"

    End Sub

    Private Sub TSBPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPost.Click
        Post(False)
    End Sub
    Public Function MarkAsInterfaced(ByVal SupressMsg As Boolean) As Boolean
        Dim F As Boolean = False
        Dim RetVal As Boolean = True
        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status = "POST" Then
                Hdr.InterfaceStatus = "POST"
                If Not Hdr.Save() Then
                    MsgBox("Unable to POST for Employee" & GLBEmployee.Code, MsgBoxStyle.Critical)
                Else
                    F = True
                End If
            End If
        End If
        Return F

    End Function

    Public Function Post(ByVal SupressMsg As Boolean) As Boolean
        Dim F As Boolean = False
        Dim RetVal As Boolean = True
        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status = "CALC" Then
                If Not PostLoanPayment(Hdr, GLBEmployee) Then
                    MsgBox("Post Loan Issue - Unable to POST for Employee" & GLBEmployee.Code, MsgBoxStyle.Critical)
                    RetVal = False
                End If
                If Not PostAdvancesPayment(Hdr, GLBEmployee) Then
                    MsgBox("Post Advances Issue - Unable to POST for Employee" & GLBEmployee.Code, MsgBoxStyle.Critical)
                    RetVal = False
                End If
                If RetVal Then
                    Hdr.Status = "POST"
                    If Not Hdr.Save() Then
                        MsgBox("Unable to POST for Employee" & GLBEmployee.Code, MsgBoxStyle.Critical)
                    Else
                        F = True
                        If Not SupressMsg Then
                            MsgBox("Payroll is POSTED", MsgBoxStyle.Information)
                            Me.FixStatus("POST")
                            F = True
                        End If
                    End If
                End If
            ElseIf Hdr.Status = "POST" Then
                MsgBox("Entry is already Posted", MsgBoxStyle.Information)
            ElseIf Hdr.Status = "PREP" Then
                MsgBox("You must Calculate, Save and the be able to POST an Entry", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("You must Calculate, Save and the be able to POST an Entry", MsgBoxStyle.Information)
        End If

        Return F

    End Function
    Private Function PostLoanPayment(ByVal Hdr As cPrTxTrxnHeader, ByVal Emp As cPrMsEmployees) As Boolean
        Dim Ds As DataSet
        Dim Exx As New Exception
        Dim F As Boolean = True
        Ds = Global1.Business.GetEmployeeLoans1(Emp.Code, "OPEN")
        Dim Ds2 As DataSet
        If CheckDataSet(Ds) Then
            Dim k As Integer
            For k = 0 To Ds.Tables(0).Rows.Count - 1
                Dim LoanCode As String
                LoanCode = DbNullToString(Ds.Tables(0).Rows(k).Item(0))
                Ds2 = Global1.Business.GetEmployeeLoans2(Emp.Code, "OPEN", LoanCode)
                If CheckDataSet(Ds2) Then
                    Dim j As Integer
                    For j = 0 To Ds2.Tables(0).Rows.Count - 1
                        Dim i As Integer
                        Dim DedCode As String

                        Dim RemAmount As Double
                        Dim DedAmount As Double
                        Dim LoanId As Integer

                        DedCode = DbNullToString(Ds2.Tables(0).Rows(j).Item(0))
                        RemAmount = Global1.Business.GetEmployeeLoanTotal(Emp.Code, LoanCode)
                        LoanId = Global1.Business.GetEmployeeLoans3(Emp.Code, "OPEN", LoanCode)

                        Dim dsLines As DataSet
                        dsLines = Global1.Business.GetPrTxTrxnLinesOfHeaderID(Hdr.Id)
                        If CheckDataSet(dsLines) Then
                            For i = 0 To dsLines.Tables(0).Rows.Count - 1
                                If DbNullToString(dsLines.Tables(0).Rows(i).Item(2)) = "D" Then

                                    If DbNullToString(dsLines.Tables(0).Rows(i).Item(4)) = DedCode Then
                                        DedAmount = DbNullToDouble(dsLines.Tables(0).Rows(i).Item(6))
                                        Dim LoanDate As Date = Now
                                        If DedAmount < RemAmount Then
                                            Dim tPrTxEmployeeLoan As New cPrTxEmployeeLoan(LoanId)
                                            With tPrTxEmployeeLoan
                                                If LoanId = 0 Then
                                                    LoanDate = Now
                                                Else
                                                    LoanDate = .LoanDate
                                                End If
                                                .Id = 0
                                                .TempGroupCode = Hdr.TemGrpCode
                                                .PeriodCode = Hdr.PrdCod_Code
                                                .PeriodGroup = Hdr.PrdGrp_Code
                                                .DedCode = DedCode
                                                .TrxHdr_Id = Hdr.Id
                                                .LoanDate = LoanDate
                                                .Amount = 0
                                                .Interest = 0
                                                .TotalAmount = 0
                                                .MonthlyAmount = 0
                                                .Type = Global1.AN_Payment
                                                .Payment = DedAmount
                                                .UserId = Global1.GLBUserId
                                                .Status = .Status
                                                If Not .Save() Then
                                                    F = False
                                                    Exit For
                                                End If
                                                ' Exit For
                                            End With
                                        ElseIf DedAmount = RemAmount Then
                                            'post normal with Message
                                            Dim tPrTxEmployeeLoan As New cPrTxEmployeeLoan(LoanId)
                                            With tPrTxEmployeeLoan
                                                If LoanId = 0 Then
                                                    LoanDate = Now
                                                Else
                                                    LoanDate = .LoanDate
                                                End If
                                                .Id = 0
                                                .TempGroupCode = Hdr.TemGrpCode
                                                .PeriodCode = Hdr.PrdCod_Code
                                                .PeriodGroup = Hdr.PrdGrp_Code
                                                .DedCode = DedCode
                                                .TrxHdr_Id = Hdr.Id
                                                .LoanDate = LoanDate
                                                .Amount = 0
                                                .Interest = 0
                                                .TotalAmount = 0
                                                .MonthlyAmount = 0
                                                .Type = Global1.AN_Payment
                                                .Payment = DedAmount
                                                .UserId = Global1.GLBUserId
                                                .Status = Global1.AN_CLOSED
                                                If Not .Save() Then
                                                    F = False
                                                    Exit For
                                                End If
                                                If Not Global1.Business.ChangeStatusofLoan(Emp.Code, LoanCode) Then
                                                    F = False
                                                    Exit For
                                                End If
                                                MsgBox("Loan with Code" & LoanCode & " of Employee " & Emp.Code & " is now Closed, Remaining amount is Zero", MsgBoxStyle.Information)
                                            End With
                                        ElseIf DedAmount > RemAmount Then
                                            MsgBox("Deducted amount for Loan " & LoanCode & " of Employee " & Emp.Code & " is greater than Loan Balance.Cannot Post Payroll Transaction", MsgBoxStyle.Critical)
                                            F = False
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
        Return F
    End Function
    Public Sub LoadCalculatedOrPosted(ByVal Hdr As cPrTxTrxnHeader, ByVal PeriodCode As cPrMsPeriodCodes)
        Try

        
            Dim ds As DataSet
            ds = Global1.Business.GetAllTrxnLines(Hdr.Id)
            If CheckDataSet(ds) Then
                Dim i As Integer
                For i = 0 To Me.Ern.Length - 1
                    ' Ern(i).ClearMe()
                Next
                For i = 0 To Me.E_Final.Length - 1
                    '    E_Final(i).ClearMe()
                Next
                'Deductions
                For i = 0 To Me.Ded.Length - 1
                    ' Ded(i).ClearMe()
                Next
                For i = 0 To Me.D_Final.Length - 1
                    '   D_Final(i).ClearMe()
                Next
                'Contributions
                For i = 0 To Me.Con.Length - 1
                    ' Con(i).ClearMe()
                Next
                For i = 0 To Me.C_Final.Length - 1
                    '  C_Final(i).ClearMe()
                Next


                Dim k As Integer
                Dim Type As String = ""
                Dim Code As String = ""
                Dim Value As Double = 0
                Dim EDC As Double = 0
                Dim Lin As New cPrTxTrxnLines

                Dim Ec As Integer = 0
                Dim Dc As Integer = 0
                Dim Cc As Integer = 0

                Me.txtPeriodCode.Text = PeriodCode.Code
                Me.txtPeriodDescription.Text = PeriodCode.DescriptionL
                Me.txtPeriodFrom.Text = Format(PeriodCode.DateFrom, "dd-MM-yyyy")
                Me.txtPeriodTo.Text = Format(PeriodCode.DateTo, "dd-MM-yyyy")


                Me.txtSILeaveUnits.Text = Format(Hdr.SIUnits, "0.00")
                Me.txtOvertime1.Text = Format(Hdr.Overtime1, "0.00")
                Me.txtOvertime2.Text = Format(Hdr.Overtime2, "0.00")
                Me.txtOvertime3.Text = Format(Hdr.Overtime3, "0.00")

                Me.txtSectors.Text = Format(Hdr.Sectors, "0.00")
                Me.txtDutyHours.Text = Format(Hdr.DutyHours, "0.00")
                Me.TxtFlightHours.Text = Format(Hdr.FlightHours, "0.00")
                Me.txtCommission.Text = Format(Hdr.Commission, "0.00")
                Me.txtPBAmount.Text = Format(Hdr.PBAmount, "0.00")
                Me.txtPBRate.Text = Format(Hdr.PBRate, "0.00")


                Me.txtActualUnits.Text = Format(Hdr.PeriodUnits, "0.00")
                Me.txtAnnualUnits.Text = Format(Hdr.AnnualUnits, "0.00")

                FixStatus(Hdr.Status)



                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Lin = New cPrTxTrxnLines(ds.Tables(0).Rows(i))
                    If Lin.TrxLin_Type = "E" Then
                        Ern(Ec).Enabled = True
                        Ern(Ec).txtCode.Text = Lin.ErnCod_Code & " - " & Lin.TrxLin_EDCDescription
                        Ern(Ec).txtValue.Text = Format(CDbl(Lin.TrxLin_EDC), "0.00")
                        Ern(Ec).MakeMeReadOnly()

                        E_Final(Ec).txtDesc.Text = Lin.ErnCod_Code & " - " & Lin.TrxLin_EDCDescription
                        E_Final(Ec).txtValue.Text = Format(Lin.TrxLin_PeriodValue, "0.00")
                        'Dim te As New cPrMsTemplateEarnings(Hdr.TemGrpCode, Lin.ErnCod_Code)
                        'E_Final(Ec).Earn = te
                        Ec = Ec + 1
                    ElseIf Lin.TrxLin_Type = "D" Then
                        Ded(Dc).Enabled = True
                        Ded(Dc).txtCode.Text = Lin.DedCod_Code & " - " & Lin.TrxLin_EDCDescription
                        Ded(Dc).txtValue.Text = Format(CDbl(Lin.TrxLin_EDC), "0.00")
                        Ded(Dc).MakeMeReadOnly()

                        D_Final(Dc).txtDesc.Text = Lin.DedCod_Code & " - " & Lin.TrxLin_EDCDescription
                        D_Final(Dc).txtValue.Text = Format(Lin.TrxLin_PeriodValue, "0.00")
                        Dc = Dc + 1
                    ElseIf Lin.TrxLin_Type = "C" Then
                        Con(Cc).Enabled = True
                        Con(Cc).txtCode.Text = Lin.ConCod_Code & " - " & Lin.TrxLin_EDCDescription
                        Con(Cc).txtValue.Text = Format(CDbl(Lin.TrxLin_EDC), "0.00")
                        Con(Cc).MakeMeReadOnly()

                        C_Final(Cc).txtDesc.Text = Lin.ConCod_Code & " - " & Lin.TrxLin_EDCDescription
                        C_Final(Cc).txtValue.Text = Format(Lin.TrxLin_PeriodValue, "0.00")
                        Cc = Cc + 1
                    End If
                Next

                Me.txtTotalEarnings.Text = Format(Hdr.TotalErnPeriod, "0.00")
                Me.txtTotalDeductions.Text = Format(Hdr.TotalDedPeriod, "0.00")
                Me.txtTotalContributions.Text = Format(Hdr.TotalConPeriod, "0.00")

                Me.txtNetSalary.Text = Format(Hdr.NetSalary, "0.00")
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Function PostAdvancesPayment(ByVal Hdr As cPrTxTrxnHeader, ByVal Emp As cPrMsEmployees) As Boolean
        Dim Ds As DataSet
        Dim Exx As New Exception
        Dim F As Boolean = True
        Dim i As Integer
        Dim DedCode As String
        Dim Amount As Double = 0
        Dim TotalAmount As Double = 0

        Dim dsLines As DataSet
        dsLines = Global1.Business.GetPrTrxnLinesOfHeaderIdOfAdvances(Hdr.Id)
        If CheckDataSet(dsLines) Then
            For i = 0 To dsLines.Tables(0).Rows.Count - 1
                DedCode = DbNullToString(dsLines.Tables(0).Rows(i).Item(1))
                Amount = DbNullToDouble(dsLines.Tables(0).Rows(i).Item(0))
                Dim TempDed As New cPrMsTemplateDeductions(Hdr.TemGrpCode, DedCode)
                If TempDed.FromMode = "T" Then
                    TotalAmount = TotalAmount + Amount
                End If
            Next
            If TotalAmount <> 0 Then
                TotalAmount = TotalAmount * -1
                Dim EmpAdv As New cPrTxEmployeeAdvances()
                With EmpAdv
                    .Amount = TotalAmount
                    .EmpCode = Emp.Code
                    .Id = 0
                    .MyDate = Now
                    .User = Global1.GLBUserId
                    If Not .Save Then
                        F = False
                    End If
                End With
            End If
        End If

        Return F
    End Function

    Private Sub TSBArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBArchive.Click

        Dim F As New FrmShowArchivePayroll
        F.CalledBy = Me
        F.Emp = Me.GLBEmployee
        F.CurrPeriod = Me.GLBCurrentPeriod
        F.Show()

    End Sub
    Public Sub MakeAllControlsReadOnly()

        Me.TSBCalculate.Enabled = False
        ' Me.TSBDelete.Enabled = False
        Me.TSBPost.Enabled = False
        Me.TSBSave.Enabled = False
        'Me.TSBExcel.Enabled = False
        'Me.TSBNew.Enabled = False
        Me.TSBArchive.Enabled = False

        Me.txtActualUnits.ReadOnly = True
        Me.txtOvertime1.ReadOnly = True
        Me.txtOvertime2.ReadOnly = True
        Me.txtOvertime3.ReadOnly = True
        Me.txtSILeaveUnits.ReadOnly = True


        Me.txtSectors.ReadOnly = True
        Me.txtDutyHours.ReadOnly = True
        Me.TxtFlightHours.ReadOnly = True
        Me.txtCommission.ReadOnly = True


        Me.DateTimePicker1.Enabled = False

    End Sub

    Private Sub TSBPrintPayslip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPrintPayslip.Click
        PrintPayslip(False, False, False)
    End Sub
    Private Sub TSBPrintPayslipWithCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPrintPayslipWithCheques.Click
        If GLBEmployee.PmtMth_Code = "" Then
            Dim f As New FrmChequeDetails
            f.CalledBY = 2
            f.ShowDialog()
            Me.GLBChequeNo = Global1.GLBTempChequeNo
            Me.GLBChequeDate = Global1.GLBTempChequeDate

            PrintPayslip(False, False, True)
        End If

    End Sub
    Public Sub PrintPayslip(ByVal SendToPrinter As Boolean, ByVal SendToTextFile As Boolean, ByVal PrintCheques As Boolean, Optional ByVal Gmail As Boolean = False, Optional ByVal ExportInPDF As Boolean = False, Optional ByVal Office365 As Boolean = False, Optional ByVal StrYear As String = "", Optional ByVal SMTP As Boolean = False, Optional ByVal Useemail2 As Boolean = False, Optional ExportInEXCEL As Boolean = False, Optional UseEncryptionOnYTDExportInPDF As Boolean = False, Optional YTDTotalPeriods As Integer = 12, Optional UploadToExelsys As Boolean = False)

        If ExportInEXCEL Then
            Global1.PARAM_GLBAllMonthsPayslip = True
        Else
            Global1.PARAM_GLBAllMonthsPayslip = False
        End If
        Dim CompanyDescription As String
        Dim ContinueWithPrinting = True

        Dim PrintTimeSheets As Boolean

        PrintTimeSheets = Global1.PARAM_PrintTimeSheetsReport

        Dim Timesheets = "Timesheets1.rpt"


        If PrintCheques Then
            If GLBEmployee.PmtMth_Code <> 2 Then
                ContinueWithPrinting = False
            End If
        End If

        Dim PayslipFileName As String
        PayslipFileName = GLBEmployee.Code
        If Global1.PARAM_PayslipNameOn Then
            PayslipFileName = GLBEmployee.Code & "_" & GLBEmployee.FullName
        End If

        If ContinueWithPrinting Then


            Dim ReportToUse As String = GLB_PAYSLIPReport
            If GLBEmployee.MyPayslipReport <> "" Then
                ReportToUse = GLBEmployee.MyPayslipReport
            End If

            Cursor.Current = Cursors.WaitCursor
            Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
            If Hdr.Id > 0 Then
                If Hdr.Status = "POST" Or Hdr.Status = "CALC" Then
                    If PrintCheques Then
                        If Hdr.InterfaceStatus = "OUTS" Or GLBOnlyUpdateChequeNumbers Then
                            Hdr.PaymentRef = GLBChequeNo
                            Hdr.Save()
                        End If
                    End If

                    Dim Ds As DataSet


                    Dim PrintInCurrency As Boolean = False
                    If Hdr.Currency = "" Then
                        Hdr.Currency = GLBCompany.CurSymbol
                    End If
                    If Hdr.Currency <> GLBCompany.CurSymbol Then
                        Dim Ans As New MsgBoxResult
                        Ans = MsgBox("Do you want to Print Payslip in currency " & Hdr.Currency, MsgBoxStyle.YesNo)
                        If Ans = MsgBoxResult.Yes Then
                            PrintInCurrency = True
                        End If
                    End If
                    If Not Global1.GLBOnlyUpdateChequeNumbers Then
                        If Not Global1.PARAM_GLBAllMonthsPayslip Then
                            Ds = Global1.Business.REPORT_PreparePayslipFor(GLBEmployee, GLBCurrentPeriod, Hdr, GLBChequeDate, PrintInCurrency)
                        Else
                            If Not PARAM_GLBAllMonthsPayslipTOTALS Then
                                Ds = Global1.Business.REPORT_PreparePayslipForAllMonths(GLBEmployee, GLBCurrentPeriod, Hdr, GLBChequeDate, PrintInCurrency)
                                DsEDCType = Global1.Business.GetTypeOfEDCIfPercentage(GLBEmployee.TemGrp_Code)
                            Else
                                Ds = Global1.Business.REPORT_PreparePayslipForAllMonthsTOTALS(GLBEmployee, GLBCurrentPeriod, Hdr, GLBChequeDate, PrintInCurrency)
                                DsEDCType = Global1.Business.GetTypeOfEDCIfPercentage(GLBEmployee.TemGrp_Code)
                            End If

                        End If
                    End If

                    '  Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\Payslip")
                    Me.Cursor = Cursors.Default
                    If Not Global1.PARAM_GLBAllMonthsPayslip Then
                        If CheckDataSet(Ds) Then
                            If ExportInPDF Then
                                Dim ExportFile As String
                                Dim ExportTSFile As String

                                ExportFile = PayslipFoldeDirectory & PayslipFileName & ".pdf"
                                ExportTSFile = PayslipFoldeDirectory & "TS_" & PayslipFileName & ".pdf"

                                Utils.ShowReport(ReportToUse, Ds, FrmReport, "Payslip Report", SendToPrinter, "", False, True, ExportFile)
                                If PrintTimeSheets Then
                                    Utils.ShowReport(Timesheets, Ds, FrmReport, "Timesheet Report", SendToPrinter, "", False, True, ExportTSFile)
                                End If
                                GC.Collect()
                                If UploadToExelsys Then
                                    'Write Code to upload to Exelsys
                                    UpLoadPayslipToExelsys(ExportFile, Hdr)
                                End If
                            Else
                                If Not SendToTextFile Then
                                    If Not Global1.GLBOnlyUpdateChequeNumbers Then
                                        Utils.ShowReport(ReportToUse, Ds, FrmReport, "Payslip Report", SendToPrinter)
                                    End If
                                    If PrintTimeSheets Then
                                        Utils.ShowReport(Timesheets, Ds, FrmReport, "Timesheets Report", SendToPrinter)
                                    End If
                                Else
                                    Dim ExportFile As String
                                    Dim TempExportFile As String

                                    TempExportFile = PayslipFoldeDirectory & PayslipFileName & "_TEMP" & ".pdf"
                                    ExportFile = PayslipFoldeDirectory & PayslipFileName & ".pdf"


                                    Dim ExportFileTS As String
                                    Dim TempExportFileTS As String

                                    TempExportFileTS = PayslipFoldeDirectory & PayslipFileName & "TS_TEMP" & ".pdf"
                                    ExportFileTS = PayslipFoldeDirectory & "TS_" & PayslipFileName & ".pdf"


                                    If Trim(GLBEmployee.Password) <> "" Then
                                        Utils.ShowReport(ReportToUse, Ds, FrmReport, "Payslip Report", SendToPrinter, "", False, True, TempExportFile)
                                        Utils.EncryptPdf(TempExportFile, ExportFile, Trim(GLBEmployee.Password))
                                        If PrintTimeSheets Then
                                            Utils.ShowReport(Timesheets, Ds, FrmReport, "Timesheets Report", SendToPrinter, "", False, True, TempExportFileTS)
                                            Utils.EncryptPdf(TempExportFileTS, ExportFileTS, Trim(GLBEmployee.Password))
                                        End If
                                        Try
                                            System.IO.File.Delete(TempExportFile)
                                            If PrintTimeSheets Then
                                                System.IO.File.Delete(TempExportFileTS)
                                            End If
                                        Catch ex As Exception

                                        End Try
                                    Else
                                        Utils.ShowReport(ReportToUse, Ds, FrmReport, "Payslip Report", SendToPrinter, "", False, True, ExportFile)
                                        If PrintTimeSheets Then
                                            Utils.ShowReport(Timesheets, Ds, FrmReport, "Timesheets Report", SendToPrinter, "", False, True, ExportFileTS)
                                        End If

                                    End If

                                    CompanyDescription = DbNullToString(Ds.Tables(1).Rows(0).Item(0))
                                    If Not PrintTimeSheets Then
                                        ExportFileTS = ""
                                    End If



                                    If Gmail Then
                                        GEmailFile(ExportFile, GLBEmployee, CompanyDescription, StrYear, ExportFileTS, GLBWording, Useemail2)
                                    ElseIf Office365 Then
                                        Me.Send365Email(ExportFile, GLBEmployee, CompanyDescription, ExportFileTS, GLBWording, Useemail2)

                                    ElseIf SMTP Then
                                        Me.Send_SMTP_EmailFile(ExportFile, GLBEmployee, CompanyDescription, StrYear, ExportFileTS, Global1.PARAM_SMTPEmailHost, GLBWording, Useemail2)
                                        '  Me.Send_SMTP_EmailFile_NoAthentication(ExportFile, GLBEmployee, CompanyDescription, StrYear, ExportFileTS, Global1.PARAM_SMTPEmailHost, GLBWording)
                                    Else

                                        EmailFile(ExportFile, GLBEmployee, CompanyDescription, ExportFileTS, GLBWording, Useemail2, Now, False, False)
                                    End If
                                    Try
                                        System.IO.File.Delete(ExportFile)
                                    Catch ex As Exception

                                    End Try


                                End If
                            End If
                        Else
                            If Not Global1.GLBOnlyUpdateChequeNumbers Then
                                MsgBox("No records found to print.", MsgBoxStyle.Information)
                            End If
                        End If
                    Else
                        If CheckDataSet(Ds) Then

                            '''''''''''''''''''''''''''''''''''
                            Dim xls As Microsoft.Office.Interop.Excel.Application
                            Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
                            Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                            Dim misValue As Object = System.Reflection.Missing.Value

                            xls = New Microsoft.Office.Interop.Excel.Application
                            xlsWorkBook = xls.Workbooks.Add(misValue)
                            xlsWorkSheet = xlsWorkBook.Sheets("sheet1")



                            Dim TempRepName As String
                            If Not Global1.PARAM_GLBAllMonthsPayslipTOTALS Then
                                TempRepName = GLBCompany.Name & "_" & GLBCurrentPeriod.DescriptionL & "_" & GLBEmployee.FullName
                            Else
                                TempRepName = GLBCompany.Name & "_" & GLBCurrentPeriod.DescriptionL & "_Totals"
                            End If

                            Dim ReportName As String = PayslipFoldeDirectory & TempRepName & ".xlsx"
                                Dim ReportNamePDF As String = PayslipFoldeDirectory & TempRepName & ".pdf"
                                Dim ReportNamePDF_Encrypted As String = PayslipFoldeDirectory & TempRepName & "_Encrypted.pdf"

                                Try


                                    '  Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Users\Admin\Documents\Visual Studio 2015\Projects\NodalPay - 2019\NodalPay\XML\PayslipALL")

                                    ' Dim ReportNamePDF As String = GLBEmployee.Code & ".pdf"

                                    Dim RowCount As Integer = 1
                                    Dim Col As Integer = 1
                                    Dim MyFontSize As Integer = 9

                                    'Dim style As Excel.Style = xlWorkSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
                                    'style.Font.Bold = True
                                    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray)

                                    '  xlWorkSheet.Cells(rownumber, 1).Style = "NewStyle"

                                    'Dim xls As Microsoft.Office.Interop.Excel.Application
                                    'Dim xlsWorkBook As Microsoft.Office.Interop.Excel.Workbook
                                    'Dim xlsWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                                    'Dim misValue As Object = System.Reflection.Missing.Value

                                    ' xls = New Microsoft.Office.Interop.Excel.Application


                                    Dim style As Microsoft.Office.Interop.Excel.Style = xlsWorkBook.Styles.Add("NewStyle")

                                    style.Font.Bold = True
                                    style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
                                    style.Font.Size = MyFontSize
                                    style.NumberFormat = "@"




                                    xlsWorkSheet.Cells.NumberFormat = "@"
                                    xlsWorkSheet.Cells.Font.Size = MyFontSize




                                    Dim Address As String
                                    Address = DbNullToString(Ds.Tables(0).Rows(0).Item(2))
                                    Address = Address & " " & DbNullToString(Ds.Tables(0).Rows(0).Item(3))
                                    Address = Address & " " & DbNullToString(Ds.Tables(0).Rows(0).Item(4))
                                    Address = Address & " " & DbNullToString(Ds.Tables(0).Rows(0).Item(5))


                                    Dim tname As String = DbNullToString(Ds.Tables(0).Rows(0).Item(1))
                                    Dim tPosition As String = DbNullToString(Ds.Tables(0).Rows(0).Item(13))
                                    Dim tEmail As String = GLBEmployee.Email
                                    Dim tIdNumber As String = DbNullToString(Ds.Tables(0).Rows(0).Item(8))
                                    Dim tSocialSecNo As String = DbNullToString(Ds.Tables(0).Rows(0).Item(7))
                                    Dim tDateOfBirth As String = Format(GLBEmployee.BirthDate, "dd/MM/yyyy")
                                    Dim tBankDetails As String = GLBEmployee.IBAN
                                    Dim tTaxNo As String = GLBEmployee.TaxID
                                    Dim tStartDate As String = Format(GLBEmployee.StartDate, "dd/MM/yyyy")
                                    Dim tAddress As String = Address
                                    Dim tTel As String = DbNullToString(Ds.Tables(0).Rows(0).Item(6))



                                    Dim rowERN As Integer = 0
                                    Dim rowTotalERN As Integer = 0
                                    Dim rowDED As Integer = 0
                                    Dim rowTotalDED As Integer = 0
                                    Dim rowNET As Integer = 0
                                    Dim rowCON As Integer = 0
                                    Dim rowTotalCON As Integer = 0
                                    Dim rowCostToComp As Integer = 0
                                    Dim rowCostToSI As Integer = 0
                                    Dim rowCostToIR As Integer = 0
                                    CompanyDescription = DbNullToString(Ds.Tables(1).Rows(0).Item(0))

                                If Not Global1.PARAM_GLBAllMonthsPayslipTOTALS Then
                                    xlsWorkSheet.Cells(1, 2) = "PAYMENT SLIP  -  " & CompanyDescription
                                    xlsWorkSheet.Cells(1, 2).style = "NewStyle"
                                    xlsWorkSheet.Range("B1:P1").Style = "NewStyle"


                                    xlsWorkSheet.Cells(2, 2) = "Name: " & tname
                                    xlsWorkSheet.Cells(3, 2) = "Position: " & tPosition
                                    xlsWorkSheet.Cells(4, 2) = "Email address: " & tEmail
                                    xlsWorkSheet.Cells(5, 2) = "ID Number: " & tIdNumber
                                    xlsWorkSheet.Cells(6, 2) = "Social Security number: " & tSocialSecNo
                                    xlsWorkSheet.Cells(7, 2) = "Date Of Birth: " & tDateOfBirth
                                    xlsWorkSheet.Cells(8, 2) = "Bank details: " & tBankDetails
                                    xlsWorkSheet.Cells(9, 2) = "Tax no: " & tTaxNo
                                    xlsWorkSheet.Cells(10, 2) = "Employment Date: " & tStartDate
                                    xlsWorkSheet.Cells(11, 2) = "Address: " & tAddress
                                    xlsWorkSheet.Cells(12, 2) = "Tel: " & tTel
                                Else
                                    xlsWorkSheet.Cells(1, 2) = "COMPANY TOTALS  -  " & CompanyDescription
                                    xlsWorkSheet.Cells(1, 2).style = "NewStyle"
                                    xlsWorkSheet.Range("B1:P1").Style = "NewStyle"

                                    xlsWorkSheet.Cells(2, 2) = "Address: " & GLBCompany.Address1 & GLBCompany.Address2 & GLBCompany.Address3
                                    xlsWorkSheet.Cells(3, 2) = "Phone: " & GLBCompany.Tel1
                                    xlsWorkSheet.Cells(4, 2) = "Tax no: " & GLBCompany.TIC
                                    xlsWorkSheet.Cells(5, 2) = " "
                                    xlsWorkSheet.Cells(6, 2) = " "
                                    xlsWorkSheet.Cells(7, 2) = " "
                                    xlsWorkSheet.Cells(8, 2) = " "
                                    xlsWorkSheet.Cells(9, 2) = " "
                                    xlsWorkSheet.Cells(10, 2) = " "
                                    xlsWorkSheet.Cells(11, 2) = " "
                                    xlsWorkSheet.Cells(12, 2) = " "
                                End If



                                Dim i As Integer
                                    xlsWorkSheet.Cells(13, 2) = "EARNINGS"
                                    rowERN = 13
                                    xlsWorkSheet.Cells(13, 4) = "JAN-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 5) = "FEB-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 6) = "MAR-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 7) = "APR-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 8) = "MAY-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 9) = "JUN-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 10) = "JUL-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 11) = "AUG-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 12) = "SEP-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 13) = "OCT-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 14) = "NOV-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 15) = "DEC-" & GLBCurrentYear
                                    xlsWorkSheet.Cells(13, 16) = "Total"

                                    xlsWorkSheet.Cells(13, 2).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 4).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 5).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 6).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 7).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 8).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 9).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 10).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 11).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 12).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 13).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 14).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 15).style = "NewStyle"
                                    xlsWorkSheet.Cells(13, 16).style = "NewStyle"


                                    Dim ErnC As Integer = 14
                                    Dim DedC As Integer
                                    Dim ConC As Integer
                                    Dim tt As Integer = 2
                                    Dim k As Integer
                                    Dim col1 As Integer = 1
                                    Dim col2 As Integer = 2
                                    Dim col3 As Integer = 3
                                    Dim col4 As Integer = 4
                                    Dim Col4Plus12 As Integer = col4 + 12
                                    Dim add As Integer = 4
                                    Dim LastEarningsColumn As Integer
                                    Dim LastDeductionsColumn As Integer
                                    Dim LastContributionsColumn As Integer
                                    Dim LastRow As Integer
                                    Dim totalErnC As Integer
                                    Dim totaldedC As Integer
                                    Dim totalConC As Integer
                                    Dim hh As Integer = 14
                                    Dim TotalCol4 As Integer = 0
                                    Dim WriteEDC As Boolean = True
                                    Dim WriteE As Boolean = True
                                    Dim WriteD As Boolean = True
                                    Dim WriteC As Boolean = True
                                    Dim TotalNet As Double = 0

                                    Dim PeriodCostToSI As Double = 0
                                    Dim YTDCostToSI As Double = 0

                                    Dim PeriodCostToTAX As Double = 0
                                    Dim YTDCostToTAX As Double = 0

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    'Write EDC Headers
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    For k = 0 To 11
                                        tt = tt + 1
                                        hh = hh + 1
                                        ErnC = 14
                                        add = 4 * k
                                        col1 = 1
                                        col2 = 2
                                        col3 = 3
                                        col4 = 4

                                        If Ds.Tables(tt).Rows.Count > 0 Then
                                            For i = 0 To Ds.Tables(tt).Rows.Count - 1
                                                Dim Type As String
                                                Type = DbNullToString(Ds.Tables(tt).Rows(i).Item(1))
                                                Dim ECode As String
                                                Dim EDesc As String
                                                Dim EPerc As String
                                                If Type = "E" Then
                                                    ECode = DbNullToString(Ds.Tables(tt).Rows(i).Item(2))
                                                    EDesc = DbNullToString(Ds.Tables(tt).Rows(i).Item(3))
                                                    EPerc = DbNullToString(Ds.Tables(tt).Rows(i).Item(4))
                                                    ' xlsWorkSheet.Cells(ErnC, col1) = ECode
                                                    xlsWorkSheet.Cells(ErnC, col2) = EDesc
                                                    xlsWorkSheet.Cells(ErnC, col3) = CheckIfEDCisPercentage(ECode, EPerc)
                                                    ErnC = ErnC + 1
                                                End If
                                                LastEarningsColumn = ErnC
                                            Next
                                            xlsWorkSheet.Cells(LastEarningsColumn, col2) = "TOTAL Earnings"
                                            rowTotalERN = LastEarningsColumn
                                            LastEarningsColumn = LastEarningsColumn + 1

                                            xlsWorkSheet.Cells(LastEarningsColumn, col2) = "DEDUCTIONS"
                                            rowDED = LastEarningsColumn

                                            LastEarningsColumn = LastEarningsColumn + 1
                                            DedC = LastEarningsColumn
                                            For i = 0 To Ds.Tables(tt).Rows.Count - 1
                                                Dim Type As String
                                                Type = DbNullToString(Ds.Tables(tt).Rows(i).Item(1))
                                                Dim DCode As String
                                                Dim DDesc As String
                                                Dim DPerc As String
                                                If Type = "D" Then
                                                    DCode = DbNullToString(Ds.Tables(tt).Rows(i).Item(2))
                                                    DDesc = DbNullToString(Ds.Tables(tt).Rows(i).Item(3))
                                                    DPerc = DbNullToString(Ds.Tables(tt).Rows(i).Item(4))
                                                    'xlsWorkSheet.Cells(DedC, col1) = DCode
                                                    xlsWorkSheet.Cells(DedC, col2) = DDesc
                                                    xlsWorkSheet.Cells(DedC, col3) = CheckIfEDCisPercentage(DCode, DPerc)
                                                    DedC = DedC + 1
                                                End If
                                                LastDeductionsColumn = DedC
                                            Next
                                            xlsWorkSheet.Cells(LastDeductionsColumn, col2) = "TOTAL Deductions"
                                            rowTotalDED = LastDeductionsColumn
                                            LastDeductionsColumn = LastDeductionsColumn + 1

                                            xlsWorkSheet.Cells(LastDeductionsColumn, col2) = "NET INCOME"
                                            rowNET = LastDeductionsColumn
                                            LastDeductionsColumn = LastDeductionsColumn + 1

                                            xlsWorkSheet.Cells(LastDeductionsColumn, col2) = "CONTRIBUTIONS"
                                            rowCON = LastDeductionsColumn
                                            LastDeductionsColumn = LastDeductionsColumn + 1

                                            ConC = LastDeductionsColumn
                                            For i = 0 To Ds.Tables(tt).Rows.Count - 1
                                                Dim Type As String
                                                Type = DbNullToString(Ds.Tables(tt).Rows(i).Item(1))
                                                Dim CCode As String
                                                Dim CDesc As String
                                                Dim CPerc As String
                                                If Type = "C" Then
                                                    CCode = DbNullToString(Ds.Tables(tt).Rows(i).Item(2))
                                                    CDesc = DbNullToString(Ds.Tables(tt).Rows(i).Item(3))
                                                    CPerc = DbNullToString(Ds.Tables(tt).Rows(i).Item(4))
                                                    'xlsWorkSheet.Cells(ConC, 1) = CCode
                                                    xlsWorkSheet.Cells(ConC, 2) = CDesc
                                                    xlsWorkSheet.Cells(ConC, 3) = CheckIfEDCisPercentage(CCode, CPerc)
                                                    ConC = ConC + 1
                                                End If
                                                LastContributionsColumn = ConC
                                            Next


                                            xlsWorkSheet.Cells(LastContributionsColumn, col2) = "TOTAL Contributions"
                                            rowTotalCON = LastContributionsColumn
                                            LastContributionsColumn = LastContributionsColumn + 1

                                            xlsWorkSheet.Cells(LastContributionsColumn, col2) = "Cost To Company"
                                            rowCostToComp = LastContributionsColumn
                                            LastContributionsColumn = LastContributionsColumn + 1

                                            xlsWorkSheet.Cells(LastContributionsColumn, col2) = "Payment to Social Insurance"
                                            rowCostToSI = LastContributionsColumn
                                            LastContributionsColumn = LastContributionsColumn + 1

                                            xlsWorkSheet.Cells(LastContributionsColumn, col2) = "Payment to IR"
                                            rowCostToIR = LastContributionsColumn
                                            Exit For
                                        End If
                                    Next
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    'END OF Write EDC Headers
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    tt = 2
                                    If YTDTotalPeriods = 12 Then
                                        hh = 14
                                    Else
                                        hh = 15
                                    End If
                                    Dim EYTDVal As Double = 0
                                    Dim DYTDVal As Double = 0
                                    Dim CYTDVal As Double = 0
                                    For k = 0 To 11
                                        tt = tt + 1
                                        hh = hh + 1
                                        ErnC = 14
                                        add = 4 * k
                                        col1 = 1 + add
                                        col2 = 2 + add
                                        col3 = 3 + add
                                        col4 = 4 + k

                                        If Ds.Tables(tt).Rows.Count > 0 Then

                                            For i = 0 To Ds.Tables(tt).Rows.Count - 1
                                                Dim Type As String
                                                Type = DbNullToString(Ds.Tables(tt).Rows(i).Item(1))
                                                Dim ECode As String
                                                Dim EDesc As String
                                                Dim EPerc As String
                                                Dim EVal As Double
                                                If Type = "E" Then
                                                    ECode = DbNullToString(Ds.Tables(tt).Rows(i).Item(2))
                                                    EDesc = DbNullToString(Ds.Tables(tt).Rows(i).Item(3))
                                                    EPerc = DbNullToString(Ds.Tables(tt).Rows(i).Item(4))
                                                    EVal = DbNullToDouble(Ds.Tables(tt).Rows(i).Item(5))
                                                    EYTDVal = DbNullToDouble(Ds.Tables(tt).Rows(i).Item(6))

                                                    xlsWorkSheet.Cells(ErnC, col4) = Format(EVal, "0.00")
                                                    xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                    '  If ECode = "E01" Then
                                                    ' MsgBox(1)
                                                    'End If
                                                    xlsWorkSheet.Cells(ErnC, Col4Plus12) = Format(EYTDVal, "0.00")
                                                    xlsWorkSheet.Columns(Col4Plus12).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                    ErnC = ErnC + 1
                                                End If
                                            Next
                                            totalErnC = ErnC

                                        Else
                                            Dim tempi As Integer = ErnC
                                            For i = ErnC To totalErnC - 1
                                                xlsWorkSheet.Cells(ErnC, col4) = Format(0, "0.00")
                                                xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                ErnC = ErnC + 1
                                            Next

                                        End If


                                        If Ds.Tables(hh).Rows.Count > 0 Then
                                            xlsWorkSheet.Cells(ErnC, col4) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(1)), "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight


                                            xlsWorkSheet.Cells(ErnC, Col4Plus12) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(9)), "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                        Else
                                            xlsWorkSheet.Cells(ErnC, col4) = Format(0, "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                        End If
                                        ErnC = ErnC + 1
                                        LastEarningsColumn = ErnC
                                        TotalCol4 = col4
                                    Next




                                    tt = 2
                                    If YTDTotalPeriods = 12 Then
                                        hh = 14
                                    Else
                                        hh = 15
                                    End If
                                    For k = 0 To 11
                                        tt = tt + 1
                                        hh = hh + 1

                                        add = 4 * k
                                        col1 = 1 + add
                                        col2 = 2 + add
                                        col3 = 3 + add
                                        col4 = 4 + k
                                        DedC = LastEarningsColumn + 1


                                        If Ds.Tables(tt).Rows.Count > 0 Then

                                            For i = 0 To Ds.Tables(tt).Rows.Count - 1
                                                Dim Type As String
                                                Type = DbNullToString(Ds.Tables(tt).Rows(i).Item(1))
                                                Dim dCode As String
                                                Dim dDesc As String
                                                Dim dPerc As String
                                                Dim dVal As Double
                                                If Type = "D" Then
                                                    dCode = DbNullToString(Ds.Tables(tt).Rows(i).Item(2))
                                                    dDesc = DbNullToString(Ds.Tables(tt).Rows(i).Item(3))
                                                    dPerc = DbNullToString(Ds.Tables(tt).Rows(i).Item(4))
                                                    dVal = DbNullToDouble(Ds.Tables(tt).Rows(i).Item(5))
                                                    DYTDVal = DbNullToDouble(Ds.Tables(tt).Rows(i).Item(6))
                                                    xlsWorkSheet.Cells(DedC, col4) = Format(dVal, "0.00")
                                                    xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                                    xlsWorkSheet.Cells(DedC, Col4Plus12) = Format(DYTDVal, "0.00")
                                                    xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                    DedC = DedC + 1
                                                    If CheckIfEDCisPaidToSI(dCode) Then
                                                        PeriodCostToSI = PeriodCostToSI + dVal
                                                        YTDCostToSI = YTDCostToSI + dVal
                                                    End If
                                                    If CheckIfEDCisPaidToTAX(dCode) Then
                                                        PeriodCostToTAX = PeriodCostToTAX + dVal
                                                        YTDCostToTAX = YTDCostToTAX + dVal
                                                    End If

                                                End If
                                            Next
                                            Ds.Tables(hh).Rows(0).Item(12) = PeriodCostToSI
                                            Ds.Tables(hh).Rows(0).Item(13) = PeriodCostToTAX
                                            PeriodCostToSI = 0
                                            PeriodCostToTAX = 0
                                            totaldedC = DedC
                                        Else
                                            Dim tempi As Integer = DedC
                                            For i = DedC To totaldedC - 1
                                                xlsWorkSheet.Cells(DedC, col4) = Format(0, "0.00")
                                                xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                DedC = DedC + 1
                                            Next

                                        End If


                                        If Ds.Tables(hh).Rows.Count > 0 Then

                                            xlsWorkSheet.Cells(DedC, col4) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(2)), "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                            xlsWorkSheet.Cells(DedC, Col4Plus12) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(10)), "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                        Else
                                            xlsWorkSheet.Cells(DedC, col4) = Format(0, "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                        End If
                                        DedC = DedC + 1

                                        If Ds.Tables(hh).Rows.Count > 0 Then
                                            TotalNet = TotalNet + DbNullToDouble(Ds.Tables(hh).Rows(0).Item(4))
                                            xlsWorkSheet.Cells(DedC, col4) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(4)), "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                            xlsWorkSheet.Cells(DedC, Col4Plus12) = Format(TotalNet, "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                        Else
                                            xlsWorkSheet.Cells(DedC, col4) = Format(0, "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                        End If
                                        DedC = DedC + 1
                                        LastDeductionsColumn = DedC

                                    Next

                                    'contributions
                                    tt = 2
                                    If YTDTotalPeriods = 12 Then
                                        hh = 14
                                    Else
                                        hh = 15
                                    End If
                                    For k = 0 To 11
                                        tt = tt + 1
                                        hh = hh + 1

                                        add = 4 * k
                                        col1 = 1 + add
                                        col2 = 2 + add
                                        col3 = 3 + add
                                        col4 = 4 + k
                                        ConC = LastDeductionsColumn + 1
                                        If Ds.Tables(tt).Rows.Count > 0 Then
                                            For i = 0 To Ds.Tables(tt).Rows.Count - 1
                                                Dim Type As String
                                                Type = DbNullToString(Ds.Tables(tt).Rows(i).Item(1))
                                                Dim cCode As String
                                                Dim cDesc As String
                                                Dim cPerc As String
                                                Dim cVal As Double
                                                If Type = "C" Then
                                                    cCode = DbNullToString(Ds.Tables(tt).Rows(i).Item(2))
                                                    cDesc = DbNullToString(Ds.Tables(tt).Rows(i).Item(3))
                                                    cPerc = DbNullToString(Ds.Tables(tt).Rows(i).Item(4))
                                                    cVal = DbNullToDouble(Ds.Tables(tt).Rows(i).Item(5))
                                                    CYTDVal = DbNullToDouble(Ds.Tables(tt).Rows(i).Item(6))

                                                    xlsWorkSheet.Cells(ConC, col4) = Format(cVal, "0.00")
                                                    xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                                    xlsWorkSheet.Cells(ConC, Col4Plus12) = Format(CYTDVal, "0.00")
                                                    xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                    If CheckIfEDCisPaidToSI(cCode) Then
                                                        PeriodCostToSI = PeriodCostToSI + cVal
                                                        YTDCostToSI = YTDCostToSI + cVal
                                                    End If
                                                    If CheckIfEDCisPaidToTAX(cCode) Then
                                                        PeriodCostToTAX = PeriodCostToTAX + cVal
                                                        YTDCostToTAX = YTDCostToTAX + cVal
                                                    End If

                                                    ConC = ConC + 1
                                                End If
                                            Next
                                            totalConC = ConC

                                            Ds.Tables(hh).Rows(0).Item(12) = PeriodCostToSI + DbNullToDouble(Ds.Tables(hh).Rows(0).Item(12))
                                            Ds.Tables(hh).Rows(0).Item(13) = PeriodCostToTAX + DbNullToDouble(Ds.Tables(hh).Rows(0).Item(13))

                                            PeriodCostToSI = 0
                                            PeriodCostToTAX = 0
                                        Else
                                            Dim tempi As Integer = ConC
                                            For i = ConC To totalConC - 1
                                                xlsWorkSheet.Cells(ConC, col4) = Format(0, "0.00")
                                                xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                                ConC = ConC + 1
                                            Next

                                        End If

                                        If Ds.Tables(hh).Rows.Count > 0 Then
                                            xlsWorkSheet.Cells(ConC, col4) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(3)), "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                            xlsWorkSheet.Cells(ConC, Col4Plus12) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(11)), "0.00")
                                            xlsWorkSheet.Columns(Col4Plus12).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight

                                            Dim CostToComp As Double
                                            CostToComp = DbNullToDouble(Ds.Tables(hh).Rows(0).Item(1)) + DbNullToDouble(Ds.Tables(hh).Rows(0).Item(3))

                                            Dim YTDCostToComp As Double
                                            YTDCostToComp = DbNullToDouble(Ds.Tables(hh).Rows(0).Item(9)) + DbNullToDouble(Ds.Tables(hh).Rows(0).Item(11))

                                            xlsWorkSheet.Cells(rowCostToComp, col4) = Format(CostToComp, "0.00")
                                            xlsWorkSheet.Cells(rowCostToComp, Col4Plus12) = Format(YTDCostToComp, "0.00")


                                            xlsWorkSheet.Cells(rowCostToSI, col4) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(12)), "0.00")
                                            xlsWorkSheet.Cells(rowCostToIR, col4) = Format(DbNullToDouble(Ds.Tables(hh).Rows(0).Item(13)), "0.00")

                                            xlsWorkSheet.Cells(rowCostToSI, Col4Plus12) = Format(YTDCostToSI, "0.00")
                                            xlsWorkSheet.Cells(rowCostToIR, Col4Plus12) = Format(YTDCostToTAX, "0.00")


                                        Else
                                            xlsWorkSheet.Cells(ConC, col4) = Format(0, "0.00")
                                            xlsWorkSheet.Columns(col4).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
                                            xlsWorkSheet.Cells(rowCostToComp, col4) = Format(0, "0.00")

                                            xlsWorkSheet.Cells(rowCostToSI, col4) = Format(0, "0.00")
                                            xlsWorkSheet.Cells(rowCostToIR, col4) = Format(0, "0.00")

                                        End If
                                        ConC = ConC + 1

                                        PeriodCostToSI = 0
                                        PeriodCostToTAX = 0
                                        LastContributionsColumn = ConC

                                    Next

                                    For i = 1 To rowCostToIR
                                        For k = 2 To 16

                                            If i = rowERN Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowTotalERN Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowDED Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowTotalDED Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowNET Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowCON Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowTotalCON Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowCostToComp Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowCostToSI Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If
                                            If i = rowCostToIR Then
                                                xlsWorkSheet.Cells(i, k).style = "NewStyle"
                                            End If

                                            If i >= 13 And k >= 2 Then
                                                Dim cell As Excel.Range = xlsWorkSheet.Cells(i, k)
                                                With cell.Borders
                                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                                    .Weight = Excel.XlBorderWeight.xlThin
                                                    .Color = RGB(0, 0, 0) ' Black color
                                                End With
                                            End If

                                        Next
                                    Next
                                    Dim cell2 As Excel.Range = xlsWorkSheet.Range("B1:P1")
                                    With cell2.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With
                                    With cell2.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With
                                    With cell2.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With
                                    With cell2.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With

                                    Dim cell3 As Excel.Range = xlsWorkSheet.Range("B2:P12")
                                    With cell3.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With
                                    With cell3.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With
                                    With cell3.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With
                                    With cell3.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .Color = RGB(0, 0, 0) ' Black color
                                    End With

                                    ''' ADDITION
                                    With xlsWorkSheet.Range("B23:P24,B32:P34,B42:P45,B13:P13,B1:P1")
                                        With .Interior
                                            .Pattern = Excel.XlPattern.xlPatternSolid
                                            .PatternColorIndex = Excel.XlPattern.xlPatternAutomatic
                                            ' .ThemeColor = Excel.XlPattern.xlPatternGray16
                                            .TintAndShade = -0.0999786370433668
                                            .PatternTintAndShade = 0
                                        End With
                                    End With
                                    xlsWorkSheet.Range("D23:P24,D32:P34,D42:P45").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    xlsWorkSheet.Range("D13:P13").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    xlsWorkSheet.Range("C25:C41").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    ''' END OF ADDITION



                                    xlsWorkSheet.PageSetup.FitToPagesWide = 1
                                    xlsWorkSheet.PageSetup.FitToPagesTall = 1

                                    xlsWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape

                                    xls.DisplayAlerts = False
                                    xlsWorkBook.SaveAs(ReportName)
                                    xls.DisplayAlerts = True
                                    ' xls.ActiveSheet.ExportAsFixedFormat(0, "C:\sample.pdf")
                                    ' xls.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, "C:\VBForumsPdf", Excel.XlFixedFormatQuality.xlQualityStandard, True, True, 1, 10, False)                                'xlsWorkBook.ExportAsFixedFormat(Type:=Excel.XlFixedFormatType.xlTypePDF, Filename:=ReportNamePDF, Quality:=Excel.xlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, From:=1, To:=1, OpenAfterPublish:=True)
                                    'xlsWorkBook.ExportAsFixedFormat(Type:=Excel.XlFixedFormatType.xlTypePDF, Filename:=ReportNamePDF, Quality:=Excel.XlFixedFormatQuality.xlQualityStandard, IncludeDocProperties:=True, IgnorePrintAreas:=False, From:=1, To:=1, OpenAfterPublish:=True)

                                    'MsgBox("File Is created", MsgBoxStyle.Information)

                                    '''''

                                    '''''

                                    '''''''''''''''''''''''''''''''''''''''''''
                                Catch ex As Exception
                                    Utils.ShowException(ex)
                                Finally
                                    xlsWorkBook.Close()

                                    xls.Quit()
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkSheet)
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkBook)
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xls)

                                    ReleaseObject(xlsWorkSheet)
                                    ReleaseObject(xlsWorkBook)
                                    ReleaseObject(xls)

                                    GC.Collect()
                                    Cursor.Current = Cursors.Default
                                    Application.DoEvents()

                                End Try

                                ''''''''' Create PDF from EXCEL
                                If ExportInPDF Then
                                    Try
                                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        'Convert Excel File to PDF
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        Dim Excel2 As Excel.Application = New Excel.Application()
                                        Dim WorkBook As Excel.Workbook = Excel2.Workbooks.Open(ReportName)
                                        Dim WorkSheets As Excel.Sheets = WorkBook.Sheets
                                        Dim WorkSheet As Excel.Worksheet = CType(WorkSheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                                        Excel2.DisplayAlerts = False
                                        Excel2.Visible = False

                                        ' Set the page setup to fit everything on one page
                                        WorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape ' Optional: Set to Landscape
                                        WorkSheet.Columns.AutoFit()
                                        ' Use scaling to ensure content fits within the width of the page
                                        WorkSheet.PageSetup.Zoom = False
                                        WorkSheet.PageSetup.FitToPagesWide = 1
                                        WorkSheet.PageSetup.FitToPagesTall = 1
                                        '''' Addition






                                        ' Set margins (optional, adjust if needed)
                                        WorkSheet.PageSetup.TopMargin = Excel2.CentimetersToPoints(1)
                                        WorkSheet.PageSetup.BottomMargin = Excel2.CentimetersToPoints(1)
                                        WorkSheet.PageSetup.LeftMargin = Excel2.CentimetersToPoints(0.5)
                                        WorkSheet.PageSetup.RightMargin = Excel2.CentimetersToPoints(0.5)

                                        ' Export as PDF
                                        WorkSheet.ExportAsFixedFormat(
                                    Type:=Excel.XlFixedFormatType.xlTypePDF,
                                    Filename:=ReportNamePDF,
                                    Quality:=Excel.XlFixedFormatQuality.xlQualityStandard,
                                    IncludeDocProperties:=True,
                                    IgnorePrintAreas:=False,
                                    From:=1,
                                    To:=1,
                                    OpenAfterPublish:=False
                                )

                                        ' Clean up
                                        WorkBook.Close(SaveChanges:=False)
                                        Excel2.Quit()
                                        System.Runtime.InteropServices.Marshal.ReleaseComObject(WorkSheet)
                                        System.Runtime.InteropServices.Marshal.ReleaseComObject(WorkSheets)
                                        System.Runtime.InteropServices.Marshal.ReleaseComObject(WorkBook)
                                        System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel2)
                                        GC.Collect()
                                        GC.WaitForPendingFinalizers()

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        'END of Convertion of Excel File to PD
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        'ENCRYPT PDF File
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        Dim FiletoBeEmailed As String = ReportNamePDF
                                        If UseEncryptionOnYTDExportInPDF Then
                                            If Trim(GLBEmployee.Password) <> "" Then
                                                Utils.EncryptPdf(ReportNamePDF, ReportNamePDF_Encrypted, Trim(GLBEmployee.Password))
                                                FiletoBeEmailed = ReportNamePDF_Encrypted
                                                Try
                                                    System.IO.File.Delete(ReportNamePDF)

                                                Catch ex As Exception

                                                End Try
                                            End If
                                        End If

                                        'END OF PDF File Encryption
                                        '''''''''''''''''''''''''''''''''''''''
                                        CompanyDescription = DbNullToString(Ds.Tables(1).Rows(0).Item(0))
                                        If Gmail Then
                                            GEmailFile(FiletoBeEmailed, GLBEmployee, CompanyDescription, StrYear, "", GLBWording, Useemail2)
                                        ElseIf Office365 Then
                                            Me.Send365Email(FiletoBeEmailed, GLBEmployee, CompanyDescription, "", GLBWording, Useemail2)

                                        ElseIf SMTP Then
                                            Me.Send_SMTP_EmailFile(FiletoBeEmailed, GLBEmployee, CompanyDescription, StrYear, "", Global1.PARAM_SMTPEmailHost, GLBWording, Useemail2)
                                            '  Me.Send_SMTP_EmailFile_NoAthentication(ExportFile, GLBEmployee, CompanyDescription, StrYear, ExportFileTS, Global1.PARAM_SMTPEmailHost, GLBWording)
                                        ElseIf SendToTextFile Then

                                            EmailFile(FiletoBeEmailed, GLBEmployee, CompanyDescription, "", GLBWording, Useemail2, GLBYTDScheduledDateTime, GLBYTDScheduled, True)
                                        End If
                                    Catch ex As Exception
                                        Utils.ShowException(ex)
                                    End Try
                                End If
                                'exportinPDF

                            End If
                        End If
                End If

            End If

        End If
        GC.Collect()
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub
    Private Sub UploadPayslipToExelsys(ExportFile As String, tempHdr As cPrTxTrxnHeader)
        Dim Exx As New SystemException

        Try

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim WebServ As wsExcelsysLive.ExelsysWSI
            Dim pDocument As wsExcelsysLive.DocumentWSI
            Dim Pages As Boolean
            WebServ = New wsExcelsysLive.ExelsysWSI
            Dim PeriodStartDate As Date
            Dim Description As String
            pDocument = New wsExcelsysLive.DocumentWSI
            ' Dim TrxHdr As New cPrTxTrxnHeader(HeaderId)

            Description = "Payslip of " & GLBCurrentPeriod.DescriptionL & " " & GLBCurrentYear
            If GLBCurrentPeriod.PayCat_Code = "K" Then
                PeriodStartDate = GLBCurrentPeriod.DateFrom
            Else
                PeriodStartDate = GLBCurrentPeriod.DateTo
            End If

            PeriodStartDate = CDate("1900-01-01")

            Dim filePath As String = ExportFile
                Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(filePath)

            pDocument.Description = Description
            pDocument.DocumentType = ".pdf"
            pDocument.OwnerGUID = tempHdr.Id
            pDocument.OwnerCode = "SalaryEntry"
            pDocument.CreatedBy = Global1.GLBExelsys_WSLogin
            pDocument.UpdatedBy = Global1.GLBExelsys_WSPassword
            pDocument.CreatedDate = Now.Date
            pDocument.UpdatedBy = Now.Date
            pDocument.Document = fileBytes

            Pages = WebServ.PostSalaryEntry(Global1.GLBExelsys_WSLogin, Global1.GLBExelsys_WSPassword, Global1.GLBExelsys_WSBusinessEntity, GLBEmployee.Code, PeriodStartDate, "", "EUR", 0, 0, "MonthlyGross", Description, 0, 0, 0, 0, 0, 0, tempHdr.Id, "", GLBEmployee.Code)
            Pages = WebServ.UploadDocument(Global1.GLBExelsys_WSLogin, Global1.GLBExelsys_WSPassword, Global1.GLBExelsys_WSBusinessEntity, pDocument)
        Catch ex As Exception
            Utils.ShowException(ex)
            MsgBox("Unable to upload file for Employee: " & GLBEmployee.Code & " " & GLBEmployee.FullName)
        End Try
    End Sub
    Private Function CheckIfEDCisPercentage(EDCCode As String, EDCValue As Double) As String
        Dim i As Integer
        Dim RetValue As String = ""
        For i = 0 To DsEDCType.Tables(0).Rows.Count - 1
            If DbNullToString(DsEDCType.Tables(0).Rows(i).Item(0)) = EDCCode Then
                RetValue = Format(EDCValue, "0.00") & "%"
                If EDCCode = Global1.PARAM_TAX_Code_ForReporting Then
                    RetValue = ""
                End If
                Exit For
            End If
        Next
        Return RetValue
    End Function
    Private Function CheckIfEDCisPaidToSI(EDCCode As String) As Boolean
        Dim F As Boolean = False
        EDCCode = "|" & EDCCode & "|"
        If PARAM_SI_EDCCodes_ForReporting.Contains(EDCCode) Then
            F = True
        End If
        Return F
    End Function
    Private Function CheckIfEDCisPaidToTAX(EDCCode As String) As Boolean
        Dim F As Boolean = False
        EDCCode = "|" & EDCCode & "|"
        If PARAM_TAX_EDCCodes_ForReporting.Contains(EDCCode) Then
            F = True
        End If
        Return F
    End Function
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    'Public Sub PrintTimeSheetsReport(ByVal SendToPrinter As Boolean, ByVal SendToTextFile As Boolean, ByVal PrintCheques As Boolean, Optional ByVal Gmail As Boolean = False, Optional ByVal ExportInPDF As Boolean = False, Optional ByVal Office365 As Boolean = False, Optional ByVal StrYear As String = "")
    '    Dim CompanyDescription As String
    '    Dim ContinueWithPrinting = True



    '    If PrintCheques Then
    '        If GLBEmployee.PmtMth_Code <> 2 Then
    '            ContinueWithPrinting = False
    '        End If
    '    End If

    '    If ContinueWithPrinting Then


    '        Dim ReportToUse As String = "Timesheets.rpt"

    '        Cursor.Current = Cursors.WaitCursor
    '        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
    '        If Hdr.Id > 0 Then
    '            Dim ds As DataSet
    '            If Hdr.Status = "POST" Or Hdr.Status = "CALC" Then
    '                ds = Global1.Business.REPORT_PrepareTimeSheetsReport(GLBEmployee, GLBCurrentPeriod, Hdr)
    '                ' Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\User\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Payslip")
    '                'Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\Payslip")
    '                Me.Cursor = Cursors.Default

    '                If CheckDataSet(ds) Then
    '                    If ExportInPDF Then
    '                        Dim ExportFile As String

    '                        ExportFile = PayslipFoldeDirectory & GLBEmployee.Code & ".pdf"

    '                        Utils.ShowReport(ReportToUse, ds, FrmReport, "Payslip Report", SendToPrinter, "", False, True, ExportFile)
    '                        GC.Collect()
    '                    Else
    '                        If Not SendToTextFile Then
    '                            Utils.ShowReport(ReportToUse, ds, FrmReport, "Payslip Report", SendToPrinter)
    '                        Else
    '                            Dim ExportFile As String
    '                            Dim TempExportFile As String

    '                            TempExportFile = PayslipFoldeDirectory & GLBEmployee.Code & "_TS_TEMP" & ".pdf"
    '                            ExportFile = PayslipFoldeDirectory & GLBEmployee.Code & "_TS.pdf"

    '                            If Trim(GLBEmployee.Password) <> "" Then
    '                                Utils.ShowReport(ReportToUse, ds, FrmReport, "Timesheets Report", SendToPrinter, "", False, True, TempExportFile)
    '                                Utils.EncryptPdf(TempExportFile, ExportFile, Trim(GLBEmployee.Password))
    '                                Try
    '                                    System.IO.File.Delete(TempExportFile)
    '                                Catch ex As Exception

    '                                End Try
    '                            Else
    '                                Utils.ShowReport(ReportToUse, ds, FrmReport, "Payslip Report", SendToPrinter, "", False, True, ExportFile)
    '                            End If

    '                            CompanyDescription = DbNullToString(ds.Tables(1).Rows(0).Item(0))
    '                            If Gmail Then
    '                                GEmailFile(ExportFile, GLBEmployee, CompanyDescription, StrYear)
    '                            ElseIf Office365 Then
    '                                Me.Send365Email(ExportFile, GLBEmployee, CompanyDescription)
    '                            Else
    '                                EmailFile(ExportFile, GLBEmployee, CompanyDescription)
    '                            End If
    '                            Try
    '                                System.IO.File.Delete(ExportFile)
    '                            Catch ex As Exception

    '                            End Try


    '                        End If
    '                    End If
    '                Else
    '                    MsgBox("No records found to print.", MsgBoxStyle.Information)
    '                End If

    '            End If
    '        End If
    '    End If
    '    GC.Collect()
    '    Cursor.Current = Cursors.Default
    'End Sub



    Private Sub TSBAdminTool_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBAdminTool.Click
        Dim i As Integer
        Me.btnRecalculate.Visible = True
        'Me.txtNetSalary.ReadOnly = False
        'Me.txtNetSalary.BackColor = Color.Yellow
        For i = 0 To Me.E_Final.Length - 1
            E_Final(i).txtValue.ReadOnly = False
            E_Final(i).txtValue.BackColor = Color.Yellow

        Next
        For i = 0 To Me.D_Final.Length - 1
            D_Final(i).txtValue.ReadOnly = False
            D_Final(i).txtValue.BackColor = Color.Yellow
        Next
        For i = 0 To Me.C_Final.Length - 1
            C_Final(i).txtValue.ReadOnly = False
            C_Final(i).txtValue.BackColor = Color.Yellow
        Next
    End Sub

    Private Sub btnRecalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalculate.Click
        ReCalculate()
    End Sub

    Private Sub EmailFile(ByVal ExportFile As String, ByVal GLBEmployee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal Exportfile2 As String, ByVal Wording As String, ByVal UseEmail2 As Boolean, SendDateAndTime As Date, ScheduleSend As Boolean, FixedSubjectAndWording As Boolean)
        Dim EmployeeEmail As String = ""
        If UseEmail2 Then
            EmployeeEmail = GLBEmployee.Email2
        Else
            EmployeeEmail = GLBEmployee.Email
        End If

        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = CompanyDescription & " - Payslip For " & GLBCurrentPeriod.DescriptionL
            Msg = "Dear " & GLBEmployee.FullName & " Find attached the Payslip For " & GLBCurrentPeriod.DescriptionL
            If GLBWording <> "" Then
                Msg = Msg & Chr(10) & Chr(10) & GLBWording
            End If
            If FixedSubjectAndWording Then
                EmailSubject = CompanyDescription & " Payroll - Private & Confidential "
                Msg = " Dear " & GLBEmployee.FullName & "," & Chr(10) &
                     Chr(10) &
                    "Please find attached your pay slip." & Chr(10) &
                     Chr(10) &
                     "Best Regards" & Chr(10) &
                     CompanyDescription
            End If
            Email.SendEmail(EmployeeEmail, EmailSubject, Msg, ExportFile, "Payslip", Exportfile2, SendDateAndTime, ScheduleSend)
        Else
            MsgBox("Please Define Email Address For Employee " & GLBEmployee.Code & " - " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub GEmailFile2(ByVal ExportFile As String, ByVal GLBEmployee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal Wording As String)
        If GLBEmployee.Email <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = CompanyDescription & " - Payslip For " & GLBCurrentPeriod.DescriptionL
            Msg = "Dear " & GLBEmployee.FullName & " Find attached the Payslip For " & GLBCurrentPeriod.DescriptionL
            If GLBWording <> "" Then
                Msg = Msg & Chr(10) & Chr(10) & GLBWording
            End If
            ' Email.SendEmail(GLBEmployee.Email, EmailSubject, Msg, ExportFile, "Payslip")
            'Test Email
            Dim Mail As New System.Net.Mail.MailMessage()
            Dim SMTP As New System.Net.Mail.SmtpClient("smtp.gmail.com")

            Mail.Subject = "Security Update"
            Mail.From = New System.Net.Mail.MailAddress(Global1.GmailAccount)

            SMTP.Credentials = New System.Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword) '<-- Password Here

            Mail.To.Add(GLBEmployee.Email) 'I used ByVal here for address
            Dim Att As New System.Net.Mail.Attachment(ExportFile)

            Mail.Attachments.Add(Att)

            Mail.Body = EmailSubject

            SMTP.EnableSsl = True
            SMTP.Port = "587"
            SMTP.Send(Mail)
        Else
            MsgBox("Please Define Email Address For Employee " & GLBEmployee.Code & " - " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub GEmailFile(ByVal ExportFile As String, ByVal GLBEmployee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal stryear As String, ByVal ExportFile2 As String, ByVal Wording As String, ByVal UseEmail2 As Boolean)
        Dim EmployeeEmail As String = ""
        If UseEmail2 Then
            EmployeeEmail = GLBEmployee.Email2
        Else
            EmployeeEmail = GLBEmployee.Email
        End If
        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = CompanyDescription & " - Payslip For " & GLBCurrentPeriod.DescriptionL
            Msg = "Dear " & GLBEmployee.FullName & " ,Please find attached your Payslip For " & GLBCurrentPeriod.DescriptionL & " " & stryear & " Payroll."
            If GLBWording <> "" Then
                Msg = Msg & Chr(10) & Chr(10) & GLBWording
            End If
            Dim SmtpServer As New System.Net.Mail.SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword)
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.EnableSsl = True


            Dim mail As New System.Net.Mail.MailMessage()

            Try
                mail.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "", System.Text.Encoding.UTF8)
                mail.To.Add(EmployeeEmail)

                If Param_PayslipCC <> "" Then
                    mail.CC.Add(Global1.Param_PayslipCC)
                End If

                mail.Subject = EmailSubject
                mail.Body = Msg

                mail.Attachments.Add(New System.Net.Mail.Attachment(ExportFile))
                If ExportFile2 <> "" Then
                    mail.Attachments.Add(New System.Net.Mail.Attachment(ExportFile2))
                End If

                ' ServicePointManager.SecurityProtocol = Tls12

                SmtpServer.Send(mail)
                mail.Dispose()
                GC.Collect()
            Catch ex As Exception
                mail.Dispose()
                GC.Collect()
                MsgBox(ex.ToString())
            End Try

        Else
            MsgBox("Please Define Email Address For Employee " & GLBEmployee.Code & " - " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    Public Sub Send365Email(ByVal ExportFile As String, ByVal GLBEmployee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal ExportFile2 As String, ByVal wording As String, ByVal UseEmail2 As Boolean)
        Try

            Dim EmployeeEmail As String = ""
            If UseEmail2 Then
                EmployeeEmail = GLBEmployee.Email2
            Else
                EmployeeEmail = GLBEmployee.Email
            End If


            If EmployeeEmail <> "" Then
                Dim EmailSubject As String
                Dim Msg As String
                EmailSubject = CompanyDescription & " - Payslip For " & GLBCurrentPeriod.DescriptionL
                Msg = "Dear " & GLBEmployee.FullName & " ,Please find attached the Payslip For " & GLBCurrentPeriod.DescriptionL & Chr(13) & Chr(13)
                If GLBWording <> "" Then
                    Msg = Msg & Chr(10) & Chr(10) & GLBWording
                End If
                Dim mailClient As New System.Net.Mail.SmtpClient("smtp.office365.com")




                mailClient.Port = 587
                mailClient.EnableSsl = True
                mailClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                mailClient.UseDefaultCredentials = False

                





                System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
                'mailClient.Port = Global1.PARAM_SMTPPort
                'mailClient.EnableSsl = Global1.PARAM_SMTPSSLEnabled




                'Dim cred As New System.Net.NetworkCredential("payroll@cobalt.aero", "cobalt123.")
                Dim cred As New System.Net.NetworkCredential(Global1.GmailAccount, Global1.GmailPassword, "fasouriwaterpark.com")

                mailClient.Credentials = cred

                Dim message As New System.Net.Mail.MailMessage()


                'This DOES work  
                message.From = New System.Net.Mail.MailAddress(Global1.GmailAccount, "Payroll")

                message.[To].Add(EmployeeEmail)
                message.Subject = EmailSubject
                message.Body = Msg
                message.Attachments.Add(New System.Net.Mail.Attachment(ExportFile))
                If ExportFile2 <> "" Then
                    message.Attachments.Add(New System.Net.Mail.Attachment(ExportFile2))
                End If

                ' System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls  ' Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12


                mailClient.Send(message)
            Else
                MsgBox("Please Define Email Address For Employee " & GLBEmployee.Code & " - " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
        GC.Collect()
    End Sub

    Private Sub Send_SMTP_EmailFile(ByVal ExportFile As String, ByVal GLBEmployee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal stryear As String, ByVal ExportFile2 As String, ByVal Host As String, ByVal wording As String, ByVal UseEmail2 As Boolean)
        Dim EmployeeEmail As String = ""
        If UseEmail2 Then
            EmployeeEmail = GLBEmployee.Email2
        Else
            EmployeeEmail = GLBEmployee.Email
        End If

        If EmployeeEmail <> "" Then
            Dim EmailSubject As String
            Dim Msg As String
            EmailSubject = CompanyDescription & " - Payslip For " & GLBCurrentPeriod.DescriptionL
            Msg = "Dear " & GLBEmployee.FullName & " ,Please find attached your Payslip For " & GLBCurrentPeriod.DescriptionL & " " & stryear & " Payroll."
            If GLBWording <> "" Then
                Msg = Msg & Chr(10) & Chr(10) & GLBWording
            End If
            Dim SmtpServer As New Mail.SmtpClient()
            SmtpServer.Credentials = New NetworkCredential(Global1.PARAM_SMTPUser, Global1.GmailPassword)

            SmtpServer.Port = Global1.PARAM_SMTPPort
            SmtpServer.Host = Host

            SmtpServer.EnableSsl = Global1.PARAM_SMTPSSLEnabled


            Dim mail As New Mail.MailMessage()

            Try
                mail.From = New Mail.MailAddress(Global1.GmailAccount, "", System.Text.Encoding.UTF8)
                mail.To.Add(EmployeeEmail)

                mail.Subject = EmailSubject
                mail.Body = Msg

                mail.Attachments.Add(New Mail.Attachment(ExportFile))
                If ExportFile2 <> "" Then
                    mail.Attachments.Add(New Mail.Attachment(ExportFile2))
                End If

                ServicePointManager.SecurityProtocol = Tls12

                SmtpServer.Send(mail)
                mail.Dispose()
                GC.Collect()
            Catch ex As Exception
                mail.Dispose()
                GC.Collect()
                MsgBox(ex.ToString())
            End Try

        Else
            MsgBox("Please Define Email Address For Employee " & GLBEmployee.Code & " - " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
        End If

    End Sub
    'Private Sub Send_SMTP_EmailFile_NoAthentication(ByVal ExportFile As String, ByVal GLBEmployee As cPrMsEmployees, ByVal CompanyDescription As String, ByVal stryear As String, ByVal ExportFile2 As String, ByVal Host As String, ByVal wording As String)

    '    If GLBEmployee.Email <> "" Then
    '        Dim EmailSubject As String
    '        Dim Msg As String
    '        EmailSubject = CompanyDescription & " - Payslip For " & GLBCurrentPeriod.DescriptionL
    '        Msg = "Dear " & GLBEmployee.FullName & " ,Please find attached your Payslip For " & GLBCurrentPeriod.DescriptionL & " " & stryear & " Payroll."
    '        If GLBWording <> "" Then
    '            Msg = Msg & Chr(10) & Chr(10) & GLBWording
    '        End If



    '        Dim SmtpServer As New System.Net.Mail.SmtpClient()

    '        SmtpServer.Credentials = New Net.NetworkCredential(Global1.PARAM_SMTPUser, Global1.GmailPassword)


    '        SmtpServer.Port = 25
    '        SmtpServer.Host = "tradesocio-com.mail.protection.outlook.com"
    '        SmtpServer.UseDefaultCredentials = False


    '        Dim mail As New System.Net.Mail.MailMessage()

    '        Try
    '            mail.From = New System.Net.Mail.MailAddress("balaksara@tradesocio.com", "", System.Text.Encoding.UTF8)
    '            mail.To.Add("balaksara@tradesocio.com")
    '            mail.Subject = EmailSubject
    '            mail.Body = Msg

    '            mail.Attachments.Add(New System.Net.Mail.Attachment(ExportFile))


    '            SmtpServer.Send(mail)
    '            mail.Dispose()
    '            GC.Collect()
    '        Catch ex As Exception
    '            mail.Dispose()
    '            GC.Collect()
    '            MsgBox(ex.ToString())
    '        End Try

    '    Else
    '        MsgBox("Please Define Email Address For Employee " & GLBEmployee.Code & " - " & GLBEmployee.FullName, MsgBoxStyle.Exclamation)
    '    End If

    'End Sub



    Private Sub TSBEmailPayslip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEmailPayslip.Click
        PrintPayslip(False, True, False)
    End Sub
    Private Function GetAnnualLeaveFor_13_14_SalaryCalculation(ByVal TypeOfLeave As String) As Double
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
            TotalLeave = Global1.Business.GetEmployeeTotalPerTypePerAction(Me.GLBEmployee.Code, LeaveTypes.Code, AN_IncreaseCODE, FromDate, ToDate, AN_Approved)
            TotalCarryForward = Global1.Business.GetEmployeeTotalPerTypePerAction(Me.GLBEmployee.Code, LeaveTypes.Code, AN_CarryForwardCODE, FromDate, ToDate, AN_Approved)
            TotalTaken = Global1.Business.GetEmployeeTotalPerTypePerAction(Me.GLBEmployee.Code, LeaveTypes.Code, AN_DecreaseCODE, FromDate, ToDate, AN_Approved)
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


    Private Sub txtActualUnits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActualUnits.TextChanged
        RecalculateAnnualUnits()
    End Sub

    Private Sub txtSILeaveUnits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSILeaveUnits.TextChanged
        RecalculateAnnualUnits()
    End Sub
    Private Sub RecalculateAnnualUnits()
        If Global1.PARAM_NoAnnualUnitsDeduction Then
            Exit Sub
        End If
        If Not Global1.GLB_NoAnnualUnits Then
            Dim AU As Double = 0
            Dim SIL As Double = 0
            If Me.txtActualUnits.Text <> "" Then
                If IsNumeric(Me.txtActualUnits.Text) Then
                    AU = CDbl(Me.txtActualUnits.Text)
                End If
            End If
            If Me.txtSILeaveUnits.Text <> "" Then
                If IsNumeric(Me.txtSILeaveUnits.Text) Then
                    SIL = CDbl(Me.txtSILeaveUnits.Text)
                End If
            End If
            Me.txtAnnualUnits.Text = AU + SIL
        Else
            Me.txtAnnualUnits.Text = 0
        End If

    End Sub


    Private Sub btnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculator.Click
        Try
            Dim V As Double
            Dim S As Double = Me.txtSalaryPerUnit.Text
            Dim U As Double = Me.txtUnitsToCalc.Text
            V = RoundMe3(S * U, 2)
            Me.txtResult.Text = Format(V, "0.00")
        Catch ex As Exception
            Me.txtResult.Text = "0.00"
        End Try
    End Sub

    Private Sub TsbSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSystem.Click
        If Me.Panel2.Visible = True Then
            Me.Panel2.Visible = False
        Else
            Me.Panel2.Visible = True
        End If
    End Sub

    Private Sub BtnCalculateGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalculateGross.Click


        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status = "POST" Or Hdr.Status = "CALC" Then
                MsgBox("This Entry Is CALCULATED Or POSTED , Please delete first", MsgBoxStyle.Information)
            End If
            Exit Sub
        End If






        Dim F As Boolean = True


        Dim j As Integer
        For j = 0 To E_Final.Length - 1
            E_Final(j).MyValue = 0
        Next
        DoCalculations()


        TryingToFindNetToGross = True

        Me.txtGrossToBe.Text = GLBFirstGross

        Me.GLBReverseCalc = True
        Do While F = True
            Dim i As Integer
            Dim Diff As Double = 0
            Dim AbsDiff As Double = 0
            Dim k As Integer
            Application.DoEvents()
            If Me.txtNetSalary.Text <> Me.txtNetToBe.Text Then
                Diff = Me.txtNetSalary.Text - Me.txtNetToBe.Text
                If Diff = 0 Then
                    F = False
                    Exit Do
                End If
                If Diff > 0 Then
                    k = -1
                Else
                    k = 1
                End If
                AbsDiff = Math.Abs(Diff)
                If AbsDiff - 100 > 0 Then
                    Me.txtGrossToBe.Text = Me.txtGrossToBe.Text + (100 * k)
                Else
                    If AbsDiff - 10 > 0 Then
                        Me.txtGrossToBe.Text = Me.txtGrossToBe.Text + (10 * k)
                    Else
                        If AbsDiff - 1 > 0 Then
                            Me.txtGrossToBe.Text = Me.txtGrossToBe.Text + (1 * k)
                        Else
                            If AbsDiff - 0.1 > 0 Then
                                Me.txtGrossToBe.Text = Me.txtGrossToBe.Text + (0.1 * k)
                            Else
                                Me.txtGrossToBe.Text = Me.txtGrossToBe.Text + (0.01 * k)
                            End If
                        End If
                    End If
                End If

            Else
                F = False
            End If


            For j = 0 To E_Final.Length - 1
                E_Final(j).MyValue = 0
            Next
            DoCalculations()

        Loop
        Me.GLBReverseCalc = False
        MsgBox("Change Employee Salary To " & Format(CDbl(Me.txtGrossToBe.Text), "0.00") & " And Recalculate Payroll", MsgBoxStyle.Information)

        TryingToFindNetToGross = True

    End Sub
    Private Sub CalculateAnnualLeaveForThisMonth()
        If Me.GLBCurrentPeriod.PayCat_Code <> "3" And Me.GLBCurrentPeriod.PayCat_Code <> "4" Then

            If Global1.PARAM_AnnualLeaveAllocation Then
                If GLBAnnualAllocationForthisTemplate Then

                    Dim Exx As New Exception
                    Dim ActualUnits As Double = Me.txtActualUnits.Text
                    Dim AnnualLeave As Double = 0
                    If Me.GLBEmployee.PayUni_Code = "2" Then


                        If Global1.GLBMonthNormalDays = 0 Then
                            AnnualLeave = 0
                            GLBAnnualLeaveUnits = 0
                        Else
                            AnnualLeave = RoundMe2(ActualUnits * 2 / (Global1.GLBMonthNormalDays * 8), 2)
                            GLBAnnualLeaveUnits = RoundMe2(AnnualLeave * 8, 2)
                        End If

                    End If
                    If Global1.RateForAnnualLeaveForAll <> 0 Then
                        AnnualLeave = RoundMe2((ActualUnits / GLBCurrentPeriod.PeriodUnits) * Global1.RateForAnnualLeaveForAll, 2)
                        GLBAnnualLeaveUnits = RoundMe2(AnnualLeave * 8, 2)
                    End If
                    'Dim AL As New cPrTxEmployeeLeave
                    'With AL
                    '    .Id = 0
                    '    .EmpCode = Me.GLBEmployee.Code
                    '    .Status = "Approved"
                    '    .Type = "1"
                    '    .ReqDate = Now.Date
                    '    .ProcDate = Now.Date
                    '    .FromDate = Now.Date
                    '    .ToDate = Now.Date
                    '    .ProcBy = Global1.GLBUserId
                    '    .Units = AnnualLeaveUnits
                    '    .Action = AN_IncreaseCODE
                    '    .HdrId = -1
                    '    If Not .Save() Then
                    '        Throw Exx
                    '    End If
                    'End With
                    'End If
                End If
            End If
        End If
    End Sub
    Private Function GetPeriodSplitForTAX_PerSplitPeriods() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForTAX_TimesPeriods(GLBEmployee.Code, GLBCurrentPeriod.PayCat_Code)
        Return MyValue

    End Function
    Private Function GetPeriodSplitForTAX() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForTAX(GLBEmployee.Code, GLBCurrentPeriod.PayCat_Code)
        Return MyValue

    End Function
    Private Function GetPeriodSplitForTAX_TimesPeriods() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForTAX_TimesPeriods(GLBEmployee.Code, GLBCurrentPeriod.PayCat_Code)
        Return MyValue

    End Function
    Private Function GetPeriodSplitForTAX12() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForTAX(GLBEmployee.Code, GLBCurrentPeriod.PayCat_Code)
        Return MyValue

    End Function
    Private Function GetPeriodSplitForTAX1314() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForTAX(GLBEmployee.Code, "3")
        Return MyValue

    End Function
    Private Function GetPeriodSplitForTAX1314_TimesPeriods() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForTAX_TimesPeriods(GLBEmployee.Code, "3")
        Return MyValue

    End Function
    Private Function GetPeriodSplitForPF() As Double
        Dim MyValue As Double = 0

        MyValue = Global1.Business.GetSplitByEmpCodeForProvidentFund(GLBEmployee.Code, GLBCurrentPeriod.PayCat_Code)
        Return MyValue

    End Function
    'Private Function GetPeriodSplitForST() As Double
    '    Dim MyValue As Double = 0

    '    MyValue = Global1.Business.GetSplitByEmpCodeForSpecialTax(GLBEmployee.Code, GLBCurrentPeriod.PayCat_Code)
    '    Return MyValue

    'End Function




    
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim F As New FrmDisLFFE
        F.EmpCode = GLBEmployee.Code
        F.Period = GLBCurrentPeriod
        F.show()

    End Sub


    Private Sub SaveIR59(ByVal EmpCode As String, ByVal PeriodCode As String)
        Dim Exx As System.Exception
        If EmpCode = "" And PeriodCode = "" Then
            EmpCode = GLBEmployee.Code
            PeriodCode = GLBCurrentPeriod.Code
        End If
        Dim Hdr As New cPrTxTrxnHeader(EmpCode, PeriodCode)
        If Hdr.Id > 0 Then
            If Hdr.Status <> "PREP" Then

                Dim S As New cPrTxIr59
                With S
                    .Trxhdr_id = Hdr.Id
                    .TemGrp_Code = Hdr.TemGrpCode
                    .PrdGrp_Code = Hdr.PrdGrp_Code
                    .PrdCod_Code = Hdr.PrdCod_Code
                    .Emp_Code = Hdr.Emp_Code
                    .Rec_GrossIncome = txtROTotalTaxable.Text
                    .Act_GrossIncome = txtCPTotalTaxable.Text
                    .Rec_Discounts = txtRODI.Text
                    .Act_Discounts = txtCPDI.Text
                    .Rec_FirstEmployeement = txtROFE.Text
                    .Act_FirstEmployeement = txtCPFE.Text
                    .Rec_SalDecrease = txtRODec.Text
                    .Act_Saldecrease = txtCPDec.Text
                    .Rec_PenFund = txtROPenF.Text
                    .Act_PenFund = txtCPPenF.Text
                    .Rec_WOFund = txtROXO.Text
                    .Act_WOFund = txtCPXO.Text
                    .Rec_Union = txtROUnion.Text
                    .Act_Union = txtCPUnion.Text
                    .Rec_LifeIns = txtROLI.Text
                    .Act_LifeIns = txtCPLI.Text
                    .Rec_PF = txtROPF.Text
                    .Act_PF = txtCPPF.Text
                    .Rec_PFLimit = txtRPFLimit.Text
                    .Act_PFLimit = txtCPFLimit.Text
                    .Rec_SI = txtROSI.Text
                    .Act_SI = txtCPSI.Text
                    .Rec_MF = txtROMF.Text
                    .Act_MF = txtCPMF.Text
                    .Rec_MFLimit = txtRmedLimit.Text
                    .Act_MFLimit = txtCMedLimit.Text
                    .Rec_Total = txtRtotalSIPFMFLI.Text
                    .Act_Total = txtCTotalSIPFMFLI.Text
                    .Rec_OneSixth = txtROonesixt.Text
                    .Act_OneSixth = txtCPOnesixt.Text
                    .Rec_Taxable = txtORtaxableearnings.Text
                    .Act_Taxable = txtCPtaxableearnings.Text
                    .Rec_TotalTax = txtORTotalTax.Text
                    .Act_TotalTax = txtCPTotalTax.Text
                    .Rec_PaidTax = txtORPaidTax.Text
                    .Act_PaidTax = txtCPPaidTax.Text
                    .Rec_RemTax = txtORRemainingTax.Text
                    .Act_RemTax = txtCPRemainingTax.Text
                    .Rec_RemDivTaxableP = txtORPeriodTax.Text
                    .Act_RemDivTaxableP = txtCPPeriodTax.Text
                    .Pay_RemTaxablePeriods = txtORRemTaxPeriods.Text
                    .Pay_ActualDivNormal = txtORPeriodUnitsRatio.Text
                    .Pay_Dif = txtORDifference.Text
                    .Pay_PeriodTax = txtFinalPeriodTax.Text
                    .Rec_Gesi = txtROGesi.Text
                    .Act_Gesi = txtCPGesi.Text
                    .Rec_Gesi_BIK = txtRO_BIK_GESI.Text
                    .Act_Gesi_BIK = txtCP_BIK_GESI.Text

                    .Rec_Gesi_Limit = Me.txtRGesyLimit.Text
                    .Act_Gesi_Limit = Me.txtCGesyLimit.Text

                    If Not .Save Then
                        Throw Exx
                    End If
                End With

            End If
        End If
    End Sub

    Private Sub btnLoadValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadValues.Click
        LoadIR59()
    End Sub
    Private Sub LoadIR59()
        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status <> "PREP" Then
                Dim S As New cPrTxIr59(Hdr.Id)
                If S.Pay_Id <> 0 Then
                    With S
                        txtROTotalTaxable.Text = Format(.Rec_GrossIncome, "0.00")
                        txtCPTotalTaxable.Text = Format(.Act_GrossIncome, "0.00")
                        txtRODI.Text = Format(.Rec_Discounts, "0.00")
                        txtCPDI.Text = Format(.Act_Discounts, "0.00")
                        txtROFE.Text = Format(.Rec_FirstEmployeement, "0.00")
                        txtCPFE.Text = Format(.Act_FirstEmployeement, "0.00")
                        txtRODec.Text = Format(.Rec_SalDecrease, "0.00")
                        txtCPDec.Text = Format(.Act_Saldecrease, "0.00")
                        txtROPenF.Text = Format(.Rec_PenFund, "0.00")
                        txtCPPenF.Text = Format(.Act_PenFund, "0.00")
                        txtROXO.Text = Format(.Rec_WOFund, "0.00")
                        txtCPXO.Text = Format(.Act_WOFund, "0.00")
                        txtROUnion.Text = Format(.Rec_Union, "0.00")
                        txtCPUnion.Text = Format(.Act_Union, "0.00")
                        txtROLI.Text = Format(.Rec_LifeIns, "0.00")
                        txtCPLI.Text = Format(.Act_LifeIns, "0.00")
                        txtROPF.Text = Format(.Rec_PF, "0.00")
                        txtCPPF.Text = Format(.Act_PF, "0.00")
                        txtRPFLimit.Text = Format(.Rec_PFLimit, "0.00")
                        txtCPFLimit.Text = Format(.Act_PFLimit, "0.00")
                        txtROSI.Text = Format(.Rec_SI, "0.00")
                        txtCPSI.Text = Format(.Act_SI, "0.00")
                        txtROMF.Text = format(.Rec_MF, "0.00")
                        txtCPMF.Text = Format(.Act_MF, "0.00")
                        txtRmedLimit.Text = Format(.Rec_MFLimit, "0.00")
                        txtCMedLimit.Text = Format(.Act_MFLimit, "0.00")
                        txtRtotalSIPFMFLI.Text = Format(.Rec_Total, "0.00")
                        txtCTotalSIPFMFLI.Text = Format(.Act_Total, "0.00")
                        txtROonesixt.Text = Format(.Rec_OneSixth, "0.00")
                        txtCPOnesixt.Text = Format(.Act_OneSixth, "0.00")
                        txtORtaxableearnings.Text = Format(.Rec_Taxable, "0.00")
                        txtCPtaxableearnings.Text = Format(.Act_Taxable, "0.00")
                        txtORTotalTax.Text = Format(.Rec_TotalTax, "0.00")
                        txtCPTotalTax.Text = Format(.Act_TotalTax, "0.00")
                        txtORPaidTax.Text = Format(.Rec_PaidTax, "0.00")
                        txtCPPaidTax.Text = Format(.Act_PaidTax, "0.00")
                        txtORRemainingTax.Text = Format(.Rec_RemTax, "0.00")
                        txtCPRemainingTax.Text = Format(.Act_RemTax, "0.00")
                        txtORPeriodTax.Text = Format(.Rec_RemDivTaxableP, "0.00")
                        txtCPPeriodTax.Text = Format(.Act_RemDivTaxableP, "0.00")
                        txtORRemTaxPeriods.Text = Format(.Pay_RemTaxablePeriods, "0.00")
                        txtORPeriodUnitsRatio.Text = Format(.Pay_ActualDivNormal, "0.00")
                        txtORDifference.Text = Format(.Pay_Dif, "0.00")
                        txtFinalPeriodTax.Text = Format(.Pay_PeriodTax, "0.00")
                        txtROGesi.Text = Format(.Rec_Gesi, "0.00")
                        txtCPGesi.Text = Format(.Act_Gesi, "0.00")
                        txtRO_BIK_GESI.Text = Format(.Rec_Gesi_BIK, "0.00")
                        txtCP_BIK_GESI.Text = Format(.Act_Gesi_BIK, "0.00")

                        Me.txtRGesyLimit.Text = Format(.Rec_Gesi_Limit, "0.00")
                        Me.txtCGesyLimit.Text = Format(.Act_Gesi_Limit, "0.00")

                        'Change Color

                        Me.txtRmedLimit.BackColor = Color.Yellow
                        Me.txtRPFLimit.BackColor = Color.Yellow
                        Me.txtRGesyLimit.BackColor = Color.Yellow
                        Me.txtROonesixt.BackColor = Color.Yellow

                        If Me.txtRmedLimit.Text <> "0.00" Then
                            Me.txtRmedLimit.BackColor = Color.Tomato
                        End If
                        If Me.txtRPFLimit.Text <> "0.00" Then
                            Me.txtRPFLimit.BackColor = Color.Tomato
                        End If
                        If Me.txtRGesyLimit.Text <> "0.00" Then
                            Me.txtRGesyLimit.BackColor = Color.Tomato
                        End If
                        If Me.txtROonesixt.Text <> "0.00" Then
                            Me.txtROonesixt.BackColor = Color.Tomato
                        End If

                        'Change Color
                        Me.txtCMedLimit.BackColor = Color.Yellow
                        Me.txtCPFLimit.BackColor = Color.Yellow
                        Me.txtCGesyLimit.BackColor = Color.Yellow
                        Me.txtCPOnesixt.BackColor = Color.Yellow



                        If Me.txtCMedLimit.Text <> "0.00" Then
                            Me.txtCMedLimit.BackColor = Color.Tomato
                        End If
                        If Me.txtCPFLimit.Text <> "0.00" Then
                            Me.txtCPFLimit.BackColor = Color.Tomato
                        End If
                        If Me.txtCGesyLimit.Text <> "0.00" Then
                            Me.txtCGesyLimit.BackColor = Color.Tomato
                        End If
                        If Me.txtCPOnesixt.Text <> "0.00" Then
                            Me.txtCPOnesixt.BackColor = Color.Tomato
                        End If








                    End With
                Else
                    MsgBox("No Values Found", MsgBoxStyle.Information)
                End If


            End If
        End If
    End Sub



    Private Sub PostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("With this Action the current transaction will be marked As Interfaced.Proceed ?", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then
            Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
            If Hdr.Id > 0 Then
                If Hdr.Status = "POST" Then
                    Hdr.InterfaceStatus = "POST"
                    If Hdr.Save() Then
                        MsgBox("Transaction Is marked As Interfaced", MsgBoxStyle.Information)
                    Else
                        MsgBox("Unable To Mark transaction As Interfaced", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Transaction Status must be POSTED before setting Transaction As Interfaced", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub
    'Private Sub CalculateSplitForNewTax(ByVal Emp As cPrMsEmployees)

    '    '  xxxxx()

    '    Dim Period_Split As Double
    '    Dim ToDate_Split As Double
    '    Dim Period_Split13 As Double

    '    Dim Period_SI_Split As Double
    '    Dim Todate_SI_Split As Double

    '    Dim TotalPeriods As Integer = 0
    '    Dim Total_Normal_Periods As Integer = 0
    '    Dim Remaining_Normal As Integer = 0
    '    Dim Remaining_13 As Integer = 0

    '    Dim SplitAmount As Double = 0
    '    Dim SplitAmount_13 As Double = 0

    '    'Dim TotalSplit As Double = 0
    '    'Dim TotalSplit_13 As Double = 0

    '    Dim Remaining_TotalSplit As Double = 0
    '    Dim ToDate_TotalSplit As Double = 0

    '    Dim CurrentPeriod_Split As Double = 0
    '    Dim ActualSplit As Double
    '    Dim ActualSplit13 As Double



    '    TotalPeriods = GLBCurrentPeriod.NumberOfTotalPeriods
    '    Total_Normal_Periods = GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow
    '    Remaining_13 = GLBCurrentPeriod.NumberOfNotNormalPeriodsToCome
    '    Remaining_Normal = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow - Remaining_13



    '    Period_Split = Me.GetPeriodSplitForTAX
    '    Dim Total_Split As Double = 0
    '    Total_Split = Me.GetPeriodSplitForTAX_PerSplitPeriods

    '    '''''''NEW
    '    ' TotalSplit = (Period_Split - Period_Split13) * 12 + Period_Split13 * 13
    '    '''''''
    '    'ActualSplit = Period_Split * (Remaining_Normal + Remaining_13)
    '    ' ActualSplit13 = Period_Split13 * Remaining_13

    '    'If GLBCurrentPeriod.PayCat_Code = "K" Then
    '    ' TotalSplit = Period_Split * (Remaining_Normal - 1)
    '    ' Else
    '    ' TotalSplit = Period_Split * Remaining_Normal
    '    ' End If

    '    ' TotalSplit_13 = Period_Split13 * 13

    '    'If GLBCurrentPeriod.PayCat_Code = "K" Then
    '    CurrentPeriod_Split = RoundMe3(Period_Split * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)
    '    'Else
    '    'CurrentPeriod_Split = RoundMe3(Period_Split13 * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)
    '    'End If
    '    'ThisPeriodSplit = GLBTh

    '    'Remaining_TotalSplit = TotalSplit + TotalSplit_13 + CurrentPeriod_Split

    '    ToDate_TotalSplit = Global1.Business.GetToDate_PeriodSplit(Emp, GLBCurrentPeriod)

    '    '---new
    '    ' Remaining_TotalSplit = TotalSplit - (ToDate_TotalSplit) '+ CurrentPeriod_Split)

    '    Remaining_TotalSplit = Total_Split - ToDate_TotalSplit '+ ActualSplit13
    '    '----end new

    '    Me.txt_Split_CurrentPeriod.Text = CurrentPeriod_Split
    '    Me.txt_Split_Remaining12.Text = 0 'TotalSplit
    '    Me.txt_Split_Remaining13.Text = 0 'TotalSplit_13
    '    Me.txt_Split_ToDate.Text = ToDate_TotalSplit
    '    Me.txt_Split_Total.Text = Remaining_TotalSplit + ToDate_TotalSplit


    '    Period_SI_Split = GLBPeriodSIonSplit
    '    Todate_SI_Split = Global1.Business.GetToDate_SplitSI(Emp, GLBCurrentPeriod)

    '    Me.txt_Split_PeriodSI.Text = Period_SI_Split
    '    Me.txt_Split_TodateSI.Text = Todate_SI_Split

    '    GLB_SPlit_PeriodSplit = CurrentPeriod_Split
    '    GLB_SPlit_PeriodSIonSplit = Period_SI_Split
    '    GLB_Split_TotalToTheEndOfYear = Remaining_TotalSplit + ToDate_TotalSplit
    '    GLB_Split_SIUntilNow = Period_SI_Split + Todate_SI_Split



    '    ' Total_SPlitSI = Period_SI_Split + ToDate_SI_Split
    'End Sub
    'Private Sub CalculateSplitForNewTax_OLD1(ByVal Emp As cPrMsEmployees)

    '    '  xxxxx()

    '    Dim Period_Split As Double
    '    Dim ToDate_Split As Double
    '    Dim Period_Split13 As Double

    '    Dim Period_SI_Split As Double
    '    Dim Todate_SI_Split As Double

    '    Dim TotalPeriods As Integer = 0
    '    Dim Total_Normal_Periods As Integer = 0
    '    Dim Remaining_Normal As Integer = 0
    '    Dim Remaining_13 As Integer = 0

    '    Dim SplitAmount As Double = 0
    '    Dim SplitAmount_13 As Double = 0

    '    'Dim TotalSplit As Double = 0
    '    'Dim TotalSplit_13 As Double = 0

    '    Dim Remaining_TotalSplit As Double = 0
    '    Dim ToDate_TotalSplit As Double = 0

    '    Dim CurrentPeriod_Split As Double = 0
    '    Dim ActualSplit As Double
    '    Dim ActualSplit13 As Double



    '    TotalPeriods = GLBCurrentPeriod.NumberOfTotalPeriods
    '    Total_Normal_Periods = GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow
    '    Remaining_13 = GLBCurrentPeriod.NumberOfNotNormalPeriodsToCome
    '    Remaining_Normal = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow - Remaining_13



    '    Period_Split = Me.GetPeriodSplitForTAX
    '    Period_Split13 = Me.GetPeriodSplitForTAX1314

    '    '''''''NEW
    '    TotalSplit = (Period_Split - Period_Split13) * 12 + Period_Split13 * 13
    '    '''''''
    '    ActualSplit = Period_Split * Remaining_Normal
    '    ActualSplit13 = Period_Split13 * Remaining_13

    '    'If GLBCurrentPeriod.PayCat_Code = "K" Then
    '    ' TotalSplit = Period_Split * (Remaining_Normal - 1)
    '    ' Else
    '    ' TotalSplit = Period_Split * Remaining_Normal
    '    ' End If

    '    ' TotalSplit_13 = Period_Split13 * 13

    '    If GLBCurrentPeriod.PayCat_Code = "K" Then
    '        CurrentPeriod_Split = RoundMe3(Period_Split * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)
    '    Else
    '        CurrentPeriod_Split = RoundMe3(Period_Split13 * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)
    '    End If
    '    'ThisPeriodSplit = GLBTh

    '    'Remaining_TotalSplit = TotalSplit + TotalSplit_13 + CurrentPeriod_Split

    '    ToDate_TotalSplit = Global1.Business.GetToDate_PeriodSplit(Emp, GLBCurrentPeriod)

    '    '---new
    '    ' Remaining_TotalSplit = TotalSplit - (ToDate_TotalSplit) '+ CurrentPeriod_Split)

    '    Remaining_TotalSplit = ActualSplit + ActualSplit13
    '    '----end new

    '    Me.txt_Split_CurrentPeriod.Text = CurrentPeriod_Split
    '    Me.txt_Split_Remaining12.Text = 0 'TotalSplit
    '    Me.txt_Split_Remaining13.Text = 0 'TotalSplit_13
    '    Me.txt_Split_ToDate.Text = ToDate_TotalSplit
    '    Me.txt_Split_Total.Text = Remaining_TotalSplit + ToDate_TotalSplit


    '    Period_SI_Split = GLBPeriodSIonSplit
    '    Todate_SI_Split = Global1.Business.GetToDate_SplitSI(Emp, GLBCurrentPeriod)

    '    Me.txt_Split_PeriodSI.Text = Period_SI_Split
    '    Me.txt_Split_TodateSI.Text = Todate_SI_Split

    '    GLB_SPlit_PeriodSplit = CurrentPeriod_Split
    '    GLB_SPlit_PeriodSIonSplit = Period_SI_Split
    '    GLB_Split_TotalToTheEndOfYear = Remaining_TotalSplit + ToDate_TotalSplit
    '    GLB_Split_SIUntilNow = Period_SI_Split + Todate_SI_Split



    '    ' Total_SPlitSI = Period_SI_Split + ToDate_SI_Split
    'End Sub
    Private Sub CalculateSplitForNewTax(ByVal Emp As cPrMsEmployees)

        '  xxxxx()

        Dim Period_Split As Double
        Dim ToDate_Split As Double
        Dim Period_Split13 As Double

        Dim Period_SI_Split As Double
        Dim Todate_SI_Split As Double

        'Dim TotalPeriods As Integer = 0
        Dim Total_Normal_Periods As Integer = 0
        Dim Remaining_Normal As Integer = 0
        Dim Remaining_13 As Integer = 0

        Dim SplitAmount As Double = 0
        Dim SplitAmount_13 As Double = 0

        Dim TotalSplit As Double = 0
        Dim TotalSplit_13 As Double = 0

        Dim Remaining_TotalSplit As Double = 0
        Dim ToDate_TotalSplit As Double = 0

        Dim CurrentPeriod_Split As Double = 0



        'TotalPeriods = GLBCurrentPeriod.NumberOfTotalPeriods

        Total_Normal_Periods = GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow

        Remaining_13 = GLBCurrentPeriod.NumberOfNotNormalPeriodsToCome

        Remaining_Normal = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow - Remaining_13



        Period_Split = Me.GetPeriodSplitForTAX
        Period_Split13 = Me.GetPeriodSplitForTAX1314

        '''''''NEW
        'TotalSplit = (Period_Split - Period_Split13) * 12 + Period_Split13 * 13

        TotalSplit = ((Period_Split - Period_Split13) * Remaining_Normal) + (Period_Split13 * (Remaining_Normal + Remaining_13))

        '*********NEW Calculate GESY on split
        ' GLBTotalYearSplitForGESI = ((Period_Split - Period_Split13) * GLBCurrentPeriod.NumberOfNormalPeriods) + (Period_Split13 * (GLBCurrentPeriod.NumberOfNormalPeriods + GLBCurrentPeriod.NumberOf_NOT_NormalPeriods))
        '****************************************************

        'TotalSplit = Me.GetPeriodSplitForTAX_TimesPeriods '+ Me.GetPeriodSplitForTAX1314_TimesPeriods


        'If GLBCurrentPeriod.PayCat_Code = "K" Then
        ' TotalSplit = Period_Split * (Remaining_Normal - 1)
        ' Else
        ' TotalSplit = Period_Split * Remaining_Normal
        ' End If

        'TotalSplit_13 = Me.GetPeriodSplitForTAX1314_TimesPeriods 'Period_Split13 * 13
        TotalSplit_13 = Me.GetPeriodSplitForTAX1314 * (Remaining_Normal + Remaining_13)

        If GLBCurrentPeriod.PayCat_Code = "K" Then
            CurrentPeriod_Split = RoundMe3(Period_Split * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)
        Else
            CurrentPeriod_Split = RoundMe3(Period_Split13 * Me.txtActualUnits.Text / Me.GLBCurrentPeriod.PeriodUnits, 2)
        End If
        'ThisPeriodSplit = GLBTh

        'Remaining_TotalSplit = TotalSplit + TotalSplit_13 + CurrentPeriod_Split
        TotalSplit = TotalSplit - Period_Split + CurrentPeriod_Split

        ToDate_TotalSplit = Global1.Business.GetToDate_PeriodSplit(Emp, GLBCurrentPeriod)

        '---new
        Remaining_TotalSplit = TotalSplit + (ToDate_TotalSplit) '+ CurrentPeriod_Split)


        '----end new

        Me.txt_Split_CurrentPeriod.Text = CurrentPeriod_Split
        Me.txt_Split_Remaining12.Text = 0 'TotalSplit
        Me.txt_Split_Remaining13.Text = 0 'TotalSplit_13
        Me.txt_Split_ToDate.Text = ToDate_TotalSplit
        Me.txt_Split_Total.Text = Remaining_TotalSplit


        Period_SI_Split = GLBPeriodSIonSplit
        Todate_SI_Split = Global1.Business.GetToDate_SplitSI(Emp, GLBCurrentPeriod)

        Me.txt_Split_PeriodSI.Text = Period_SI_Split
        Me.txt_Split_TodateSI.Text = Todate_SI_Split

        GLB_SPlit_PeriodSplit = CurrentPeriod_Split
        GLB_SPlit_PeriodSIonSplit = Period_SI_Split
        GLB_Split_TotalToTheEndOfYear = Remaining_TotalSplit
        GLB_Split_SIUntilNow = Period_SI_Split + Todate_SI_Split



        ' Total_SPlitSI = Period_SI_Split + ToDate_SI_Split
    End Sub
    Private Sub CalculateSplitForGESY(ByVal Emp As cPrMsEmployees)

        '  xxxxx()

        Dim Period_Split As Double
        Dim Period_Split13 As Double
        Dim TotalSplit As Double
        Dim Todate_SI_Split As Double
        Dim Remaining_Normal As Integer = 0
        Dim Remaining_13 As Integer = 0

        Remaining_13 = GLBCurrentPeriod.NumberOfNotNormalPeriodsToCome
        Remaining_Normal = GLBCurrentPeriod.NumberOfTotalPeriods - GLBCurrentPeriod.NumberOfNormalPeriodsUntilNow - Remaining_13

        Period_Split = Me.GetPeriodSplitForTAX
        Period_Split13 = Me.GetPeriodSplitForTAX1314


        ' Todate_SI_Split = Global1.Business.GetToDate_SplitSI(Emp, GLBCurrentPeriod)

        '*********NEW Calculate GESY on split
        GLBTotalYearSplitForGESI = ((Period_Split - Period_Split13) * GLBCurrentPeriod.NumberOfNormalPeriods) + (Period_Split13 * (GLBCurrentPeriod.NumberOfNormalPeriods + GLBCurrentPeriod.NumberOf_NOT_NormalPeriods))
        ' TotalSplit = ((Period_Split - Period_Split13) * Remaining_Normal) + (Period_Split13 * (Remaining_Normal + Remaining_13))
        '****************************************************

    End Sub
    Private Function Calculate_SI_Split_ByTheEndOfYearFull(ByVal EstimatedInsurableEarningsByTheEndOfYear, ByVal SI_UntilNow, ByVal SI_ByTheEndOfYear) As Double

        Dim RemainingSplit_12 As Double = 0
        Dim RemainingSplit_13 As Double = 0

        Dim Todate_SI_onSplit As Double = 0
        Dim Period_SI_onSPlit As Double = 0

        Dim SI_Split_ByTheEndOfTheYear As Double = 0
        Dim AnnoualSILimit As Double = 0

        RemainingSplit_12 = Me.txt_Split_Remaining12.Text
        RemainingSplit_13 = Me.txt_Split_Remaining13.Text

        Period_SI_onSPlit = Me.txt_Split_PeriodSI.Text
        Todate_SI_onSplit = Me.txt_Split_TodateSI.Text

        'Dim TotalRemainingSplit = RemainingSplit_12 + RemainingSplit_13
        Dim TotalRemainingSplit = Me.txt_Split_Total.Text - Me.txt_Split_ToDate.Text

        If GLBEmployee.TerminateDate = "" Then


            SI_Split_ByTheEndOfTheYear = (TotalRemainingSplit) * (GLBSIPercentage / 100)
            SI_Split_ByTheEndOfTheYear = SI_Split_ByTheEndOfTheYear - Period_SI_onSPlit
        Else
            SI_Split_ByTheEndOfTheYear = 0
        End If


        AnnoualSILimit = Global1.GlbLimits.InsurableAnnual * GLBSIPercentage / 100



        If (SI_UntilNow + SI_ByTheEndOfYear + SI_Split_ByTheEndOfTheYear + Period_SI_onSPlit + Todate_SI_onSplit) > AnnoualSILimit Then

            SI_Split_ByTheEndOfTheYear = AnnoualSILimit - (SI_UntilNow + SI_ByTheEndOfYear + Period_SI_onSPlit + Todate_SI_onSplit)
            If SI_Split_ByTheEndOfTheYear < 0 Then
                '   SI_Split_ByTheEndOfTheYear = 0
            End If

        End If

        Me.txt_Split_SIonRemaining.Text = SI_Split_ByTheEndOfTheYear
        Me.txt_Split_TotalSIonSplit.Text = SI_Split_ByTheEndOfTheYear + Todate_SI_onSplit + Period_SI_onSPlit



        Return RoundMe3((SI_Split_ByTheEndOfTheYear + Todate_SI_onSplit + Period_SI_onSPlit), 2)



    End Function

    Private Sub BtnMoveToEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoveToEmployee.Click
        MoveTransactionToNewEmpCode()
    End Sub
    Private Sub MoveTransactionToNewEmpCode()
        Dim Emp As New cPrMsEmployees(txt_Move_ToEmpCode.Text)
        If Emp.Code <> "" Then '1
            Dim Ds As DataSet
            Dim T As New cPrMsPeriodGroups
            Ds = Global1.Business.GetPeriodGroupOfTemplateGroup(Emp.TemGrp_Code)
            If CheckDataSet(Ds) Then '2
                Dim PGCode As String
                PGCode = DbNullToString(Ds.Tables(0).Rows(0).Item(0))
                T = New cPrMsPeriodGroups(PGCode)
                Dim ds2 As DataSet
                ds2 = Global1.Business.FindCurrentPeriod1(Emp.TemGrp_Code)
                If CheckDataSet(ds2) Then '3
                    Dim PCode As String

                    PCode = DbNullToString(ds2.Tables(0).Rows(0).Item(0))
                    Dim P As New cPrMsPeriodCodes(PCode, T.Code)

                    Dim str As String
                    str = "Do you want To Transfer Current Transaction To " & Chr(13)
                    str = str & "Template Group " & Emp.TemGrp_Code & Chr(13)
                    str = str & "Period Group " & T.Code & Chr(13)
                    str = str & "Period Code: " & PCode & Chr(13)
                    Dim Ans As MsgBoxResult
                    Ans = MsgBox(str, MsgBoxStyle.YesNo)

                    Dim Exx As New System.Exception
                    If Ans = MsgBoxResult.Yes Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Try
                            Global1.Business.BeginTransaction()
                            Dim Hdr As New cPrTxTrxnHeader(Me.GLBEmployee.Code, Me.GLBCurrentPeriod.Code)
                            Me.LoadIR59()
                            If Hdr.Id > 0 And (Hdr.Status = "CALC" Or Hdr.Status = "POST") Then
                                With Hdr
                                    .Id = 0
                                    .Status = "CALC"
                                    .InterfaceStatus = "OUTS"
                                    .Emp_Code = Emp.Code
                                    .PrdGrp_Code = P.PrdGrpCode
                                    .PrdCod_Code = P.Code
                                    .PayCat_Code = P.PayCat_Code
                                    .MyDate = Now.Date
                                    .TotalErnYTD = GetErnYTD(Emp, P) + .TotalErnPeriod
                                    .TotalDedYTD = GetDedYTD(Emp, P) + .TotalDedPeriod
                                    .TotalConYTD = GetConYTD(Emp, P) + .TotalConPeriod


                                    .PaymentMethod = Findpaymethod()
                                    
                                    .PaymentRef = "PAY REF"
                                    If Global1.PARAM_EmpCodeinChequeRef Then
                                        .PaymentRef = Emp.Code
                                    End If

                                    .Overtime1 = Me.txtOvertime1.Text
                                    .Overtime2 = Me.txtOvertime2.Text
                                    .Overtime3 = Me.txtOvertime3.Text

                                    .Sectors = Me.txtSectors.Text
                                    .DutyHours = Me.txtDutyHours.Text
                                    .FlightHours = Me.TxtFlightHours.Text
                                    .Commission = Me.txtCommission.Text
                                    .OverLay = Me.txtOverLay.Text
                                    .PBAmount = Me.txtPBAmount.Text
                                    .PBRate = Me.txtPBRate.Text


                                    Dim NetYTD As Double
                                    NetYTD = GetNetYTD(Emp, P) + .NetSalary

                                    .NetYTD = NetYTD

                                    .A1 = Emp.EmpAn1_Code
                                    .A2 = Emp.EmpAn2_Code
                                    .A3 = Emp.EmpAn3_Code
                                    .A4 = Emp.EmpAn4_Code
                                    .A5 = Emp.EmpAn5_Code
                                    .Union = Emp.Uni_Code
                                    .Position = Emp.EmpPos_Code

                                    If Not .Save Then
                                        Throw Exx
                                    End If
                                End With

                                Dim Count As Integer = 0

                                If Not Global1.Business.DeleteAllEDCFromTrxnLines(Hdr.Id) Then
                                    Throw Exx
                                End If

                                'Saving Earnings
                                Dim YearToDate As Double
                                Dim Ern As cPrMsTemplateEarnings
                                Dim i As Integer
                                For i = 0 To E_Final.Length - 1
                                    If Not E_Final(i).Earn.ErnCodCode Is Nothing Then
                                        Count = Count + 1
                                        Ern = E_Final(i).Earn
                                        Dim E1 As New cPrTxTrxnLines(Hdr.Id, Ern)
                                        YearToDate = Global1.Business.FindYTD_EDC(Emp, P, Ern.ErnCodCode, "E")
                                        '  If YearToDate = 0 Then
                                        'YearToDate = E_Final(i).txtValue.Text
                                        'End If
                                        With E1
                                            .TrxLin_Id = Count
                                            .TrxHdr_Id = Hdr.Id
                                            .TrxLin_Type = "E"
                                            .ErnCod_Code = Ern.ErnCodCode
                                            .TrxLin_PeriodValue = E_Final(i).txtValue.Text
                                            .TrxLin_YTDValue = .TrxLin_PeriodValue + YearToDate
                                            .TrxLin_EDC = Me.Ern(i).txtValue.Text
                                            .TrxLin_EDCDescription = Ern.DisplayName
                                            .TrxLin_ConsolDesc = Ern.ConsolDesc

                                            If Not .Save Then
                                                Throw Exx
                                            End If
                                        End With
                                    End If
                                Next

                                'Saving Deductions()
                                Dim Ded As cPrMsTemplateDeductions
                                For i = 0 To D_Final.Length - 1
                                    If Not D_Final(i).Ded.DedCodCode Is Nothing Then
                                        Count = Count + 1
                                        Ded = D_Final(i).Ded
                                        Dim D As New cPrTxTrxnLines(Hdr.Id, Ded)
                                        YearToDate = Global1.Business.FindYTD_EDC(Emp, P, Ded.DedCodCode, "D")
                                        'If YearToDate = 0 Then
                                        '    YearToDate = D_Final(i).txtValue.Text
                                        'End If
                                        With D
                                            .TrxLin_Id = Count
                                            .TrxHdr_Id = Hdr.Id
                                            .TrxLin_Type = "D"
                                            .DedCod_Code = Ded.DedCodCode
                                            .TrxLin_PeriodValue = D_Final(i).txtValue.Text
                                            .TrxLin_YTDValue = .TrxLin_PeriodValue + YearToDate
                                            .TrxLin_EDC = Me.Ded(i).txtValue.Text
                                            .TrxLin_EDCDescription = Ded.DisplayName
                                            .TrxLin_ConsolDesc = Ded.ConsolDesc
                                            If Not .Save Then
                                                Throw Exx
                                            End If
                                        End With
                                    End If
                                Next

                                'Saving Contributions
                                Dim Con As cPrMsTemplateContributions
                                For i = 0 To C_Final.Length - 1
                                    If Not C_Final(i).Con.ConCodCode Is Nothing Then
                                        Count = Count + 1
                                        Con = C_Final(i).Con
                                        Dim C As New cPrTxTrxnLines(Hdr.Id, Con)
                                        YearToDate = Global1.Business.FindYTD_EDC(Emp, P, Con.ConCodCode, "C")
                                        'If YearToDate = 0 Then
                                        '    YearToDate = C_Final(i).txtValue.Text
                                        'End If
                                        With C
                                            .TrxLin_Id = Count
                                            .TrxHdr_Id = Hdr.Id
                                            .TrxLin_Type = "C"
                                            .ConCod_Code = Con.ConCodCode
                                            .TrxLin_PeriodValue = C_Final(i).txtValue.Text
                                            .TrxLin_YTDValue = .TrxLin_PeriodValue + YearToDate
                                            .TrxLin_EDC = Me.Con(i).txtValue.Text
                                            .TrxLin_EDCDescription = Con.DisplayName
                                            .TrxLin_ConsolDesc = Con.ConsolDesc
                                            If Not .Save Then
                                                Throw Exx
                                            End If
                                        End With
                                    End If
                                Next

                                If Global1.PARAM_AnnualLeaveAllocation Then
                                    If Me.GLBAnnualAllocationForthisTemplate Then
                                        'If Me.Emp.PayUni_Code = "2" Then
                                        'Global1.Business.updateAnnualLeaveHeaderId(Hdr.Emp_Code, Hdr.Id)
                                        Dim AL As New cPrTxEmployeeLeave
                                        With AL
                                            .Id = 0
                                            .EmpCode = Emp.Code
                                            .Status = "Approved"
                                            .Type = "1"
                                            .ReqDate = Now.Date
                                            .ProcDate = Now.Date
                                            .FromDate = Now.Date
                                            .ToDate = Now.Date
                                            .ProcBy = Global1.GLBUserId
                                            .Units = GLBAnnualLeaveUnits
                                            .Action = AN_IncreaseCODE
                                            .HdrId = Hdr.Id
                                            If Not .Save() Then
                                                Throw Exx
                                            End If
                                        End With
                                        'End If
                                    End If
                                End If


                                SaveIR59(Emp.Code, P.Code)


                                Global1.Business.CommitTransaction()
                                MsgBox("Copy Is finished", MsgBoxStyle.Information)
                            End If '5
                        Catch ex As Exception
                            Global1.Business.Rollback()
                            Utils.ShowException(Exx)
                        End Try
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Else
                        MsgBox("Current Transaction Status Is Not 'POST' or 'CALC', cannot proceed", MsgBoxStyle.Information)
                        Exit Sub
                    End If '3
                Else
                    MsgBox("Cannot Find Open Period for Period Group " & T.Code, MsgBoxStyle.Information)
                    Exit Sub
                End If '3
            Else

                MsgBox("Cannot Find PeriodGroup fpr Template Group " & Emp.TemGrp_Code, MsgBoxStyle.Information)
                Exit Sub

            End If '2


        Else
            MsgBox("Employee with Code " & txt_Move_ToEmpCode.Text & " Does not exist", MsgBoxStyle.Information)
        End If '1


    End Sub
    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        'CType(Me.Owner, FrmPayroll1).LoadNextEmployee(True, False, CurrentOwnerColumn, Me)
        CType(Me.Owner, FrmPayroll1).glbrunnext = True
        CType(Me.Owner, FrmPayroll1).glbGridIndex = CurrentOwnerColumn
        Me.Close()

    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        'CType(Me.Owner, FrmPayroll1).LoadNextEmployee(False, True, CurrentOwnerColumn, Me)
        CType(Me.Owner, FrmPayroll1).GLBRunPrevious = True
        CType(Me.Owner, FrmPayroll1).glbGridIndex = CurrentOwnerColumn
        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Gross As Double = 0
        Gross = Me.txtGrossToBe.Text
        CType(Me.Owner, FrmPayroll1).OpenCurrentEmployeeSalaryCard(Gross)
    End Sub

    Private Sub btnUpdateGESIableForSI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGESIableForSI.Click
        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            Dim GV As Double
            GV = Me.txtUpdateGesiableforSI.Text
            If Hdr.Status <> "PREP" Then
                Dim Ans As New MsgBoxResult
                Ans = MsgBox("With This Action the Actual Earnings for GESI on SI Reports for Period " & GLBCurrentPeriod.DescriptionL & " will be set to " & GV & " Continue ?", MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then
                    If Global1.Business.FixGesiable(GV, GLBEmployee.Code, GLBCurrentPeriod) Then
                        MsgBox("Updated !", MsgBoxStyle.Information)
                    Else
                        MsgBox("Fail to Update !", MsgBoxStyle.Critical)
                    End If
                End If
            Else
                MsgBox("For this Action status must be 'CALC' or 'POST'", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("For this Action status must be 'CALC' or 'POST'", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintIR59.Click
        Dim Ds As DataSet
        Dim Hdr As New cPrTxTrxnHeader(GLBEmployee.Code, GLBCurrentPeriod.Code)
        If Hdr.Id > 0 Then
            If Hdr.Status <> "PREP" Then

                Ds = Global1.Business.GetIr59ForPrinting(Hdr.Id) '
                If CheckDataSet(Ds) Then

                    Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\ir59")
                    Me.Cursor = Cursors.Default
                    Dim ReportToUse As String
                    ReportToUse = "Ir59.rpt"
                    Utils.ShowReport(ReportToUse, Ds, FrmReport, "Income Tax Analysis", False, "", False, False, "")

                    GC.Collect()
                Else

                End If
            Else
                MsgBox("Payslip Status is 'PREP', cannot print Income Tax Analysis", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please 'Calculate' first !", MsgBoxStyle.Critical)
        End If
    End Sub
  

End Class