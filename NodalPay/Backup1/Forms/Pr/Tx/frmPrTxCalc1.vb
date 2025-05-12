Public Class frmPrTxCalc1
    Public GLBEmployee As New cPrMsEmployees
    Dim GLBCurrentPeriod As New cPrMsPeriodCodes
    Dim GlbEmpSalary As New cPrTxEmployeeSalary

    ''' '''''''''''''''''''''''''''
    Dim RateForOvertimeCalc As Double '= Rate(hourly) OR Gross/NormalUnits(Periodicly OR Contract)
    Dim GrossFor13AND14Calc As Double
    Dim GrossDIVNormalUnitsForCalc As Double
    Dim ArrearsFor13AND14Calc As Double
    ''' '''''''''''''''''''''''''''
    Dim Ern(14) As E_Pay
    Dim Ded(14) As D_Pay
    Dim Con(14) As C_Pay

    Dim E_Final(14) As E_Final
    Dim D_Final(14) As D_Final
    Dim C_Final(14) As C_Final

    Dim DsP_Ern As DataSet
    Dim DSP_Ded As DataSet
    Dim DSP_Con As DataSet

    Private Sub frmPrTxCalc1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        InitTextBoxes()
        InitArray_Ern()
        InitArray_E_Final()
        InitArray_Ded()
        InitArray_D_Final()
        InitArray_Con()
        InitArray_C_Final()
        ClearMe()
    End Sub
    Private Sub InitTextBoxes()
        AddHandler txtActualUnits.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtActualUnits.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtOvertime1.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtOvertime1.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtOvertime2.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtOvertime2.Leave, AddressOf Utils.NumericOnLeave
        AddHandler txtSILeaveUnits.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler txtSILeaveUnits.Leave, AddressOf Utils.NumericOnLeave
    End Sub
    Private Sub FindCurrentPeriod()

        Dim ds As DataSet
        ds = Global1.Business.FindCurrentPeriod1(Me.GLBEmployee.TemGrp_Code)
        If CheckDataSet(ds) Then
            GLBCurrentPeriod = New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
            With GLBCurrentPeriod
                Me.txtPeriodCode.Text = .Code
                Me.txtPeriodDescription.Text = .DescriptionL
                Me.txtPeriodFrom.Text = Format(.DateFrom, "dd-MM-yyyy")
                Me.txtPeriodTo.Text = Format(.DateTo, "dd-MM-yyyy")
            End With
            If GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
                'Get Units From Period
                Me.txtActualUnits.Text = GLBCurrentPeriod.PeriodUnits
            ElseIf GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
                'Get Units From Employee
                Me.txtActualUnits.Text = GLBEmployee.PeriodUnits
            ElseIf GLBEmployee.PayUni_Code = Global1.GLB_Units_Period_Code Then
                'Get Units From User Input
                Me.txtActualUnits.Text = "0.00"
            End If
            GetPeriodEDC()
        Else
            MsgBox("There is no OPEN Period !Cannot Proceed with Payroll Calculations", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub ClearMe()
        Me.txtActualUnits.Text = 0
        Me.txtOvertime1.Text = 0
        Me.txtOvertime2.Text = 0
        Me.txtSILeaveUnits.Text = 0
        ClearEDC()
    End Sub

    Private Sub BtnEmployeeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmployeeSearch.Click
        Dim F As New FrmEmployeeSearch
        F.CalledBy = 2
        F.Owner = Me
        F.ShowDialog()
    End Sub
    Public Sub LoadEmployee(ByVal Emp As cPrMsEmployees)
        With Emp
            GLBEmployee = Emp
            FindCurrentPeriod()
            ClearEDC()
            Me.txtEmpCode.Text = Emp.Code
            Me.txtEmpFullName.Text = Emp.FullName
            Me.LoadEDCForEmployee(GLBEmployee)
        End With

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
    Private Sub ClearEDC()
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

        If GLBEmployee.Code <> "" Then
            TempCode = GLBEmployee.TemGrp_Code
            counter = 0
            Ds = Global1.Business.GetAllPrMsTemplateEarnings(TempCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim E As New cPrMsTemplateEarnings(Ds.Tables(0).Rows(i))
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
            'Deductions
            counter = 0
            For i = 0 To Me.Ded.Length - 1
                Ded(i).ClearMe()
            Next
            For i = 0 To Me.D_Final.Length - 1
                D_Final(i).ClearMe()
            Next
            Ds = Global1.Business.GetAllPrMsTemplateDeductions(TempCode)
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim D As New cPrMsTemplateDeductions(Ds.Tables(0).Rows(i))
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
            'Contributions
            counter = 0
        For i = 0 To Me.Con.Length - 1
            Con(i).ClearMe()
        Next
        For i = 0 To Me.Con.Length - 1
            C_Final(i).ClearMe()
        Next
        Ds = Global1.Business.GetAllPrMsTemplateContributions(TempCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                    Dim C As New cPrMsTemplateContributions(Ds.Tables(0).Rows(i))
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

    Private Sub LoadEDCForEmployee(ByVal Emp As cPrMsEmployees)
        Dim ds As DataSet
        Dim i As Integer
        Dim k As Integer
        'Load employee Earnings Values if Exists
        ds = Global1.Business.GetAllPrMsEmployeeEarnings(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim EE As New cPrMsEmployeeEarnings(ds.Tables(0).Rows(i))
                For k = 0 To Me.Ern.Length - 1
                    If EE.ErnCode = Ern(k).txtCode.Tag Then
                        Ern(k).txtValue.Text = Format(EE.MyValue, "0.00")
                        Exit For
                    End If
                Next
            Next
        End If
        'Load employee Deduction Values if Exists
        ds = Global1.Business.GetAllPrMsEmployeeDeductions(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim ED As New cPrMsEmployeeDeductions(ds.Tables(0).Rows(i))
                For k = 0 To Me.Ded.Length - 1
                    If ED.DedCode = Ded(k).txtCode.Tag Then
                        Ded(k).txtValue.Text = Format(ED.MyValue, "0.00")
                        Exit For
                    End If
                Next
            Next
        End If
        'Load employee Contribution Values if Exists
        ds = Global1.Business.GetAllPrMsEmployeeContributions(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim EC As New cPrMsEmployeeContributions(ds.Tables(0).Rows(i))
                For k = 0 To Me.Con.Length - 1
                    If EC.ConCode = Con(k).txtCode.Tag Then
                        Con(k).txtValue.Text = Format(EC.MyValue, "0.00")
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub
#Region "Earnings Calculations"

    Private Sub CalculateEarnings(ByVal Emp As cPrMsEmployees)
        Dim ds As DataSet
        Dim i As Integer
        ' Dim Period As New cprmspe
        ds = Global1.Business.GetAllPrMsEmployeeEarnings(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim EE As New cPrMsEmployeeEarnings(ds.Tables(0).Rows(i))
                Dim Earn As New cPrMsEarningCodes(EE.ErnCode)
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
                    Case "OT" 'OVERTIME
                        E_CalculateOverTime(Emp, EE, Earn)
                    Case "SA" 'SALARY
                        E_CalculateSalary(Emp, EE, Earn)
                    Case "SI" 'SOCIAL INSURANCE LEAVE
                End Select
            Next
        End If
    End Sub
    Private Sub E_CalculateSalary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)

        Dim Gross As Double = 0
        Dim Rate As Double = 0
        Dim Salary As Double = 0
        Dim ActualUnits As Double = 0
        Dim NormalUnits As Double = 0

        ActualUnits = Me.txtActualUnits.Text
        GlbEmpSalary = Global1.Business.GetCurrentSalary(Me.GLBEmployee.Code, Me.GLBCurrentPeriod.DateTo)
        Gross = GlbEmpSalary.SalaryValue

        If Emp.PayUni_Code = Global1.GLB_Units_Hourly_Code Then
            'Hourly
            RateForOvertimeCalc = Gross
            Rate = Gross
            Salary = RoundMe3(Rate * ActualUnits, 2)
        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Period_Code Then
            'Period
            NormalUnits = Me.GLBCurrentPeriod.PeriodUnits
            Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
            RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
            GrossFor13AND14Calc = Gross
            GrossDIVNormalUnitsForCalc = RoundMe3(Gross / NormalUnits, 2)
        ElseIf Emp.PayUni_Code = Global1.GLB_Units_Contract_Code Then
            'contract
            NormalUnits = Me.GLBEmployee.PeriodUnits
            Salary = RoundMe3((Gross / NormalUnits) * ActualUnits, 2)
            RateForOvertimeCalc = RoundMe3(Gross / NormalUnits, 2)
            GrossFor13AND14Calc = Gross
            GrossDIVNormalUnitsForCalc = RoundMe3(Gross / NormalUnits, 2)
        End If
        Dim i As Integer
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Salary
                Exit For
            End If
        Next
        'Me.txtSalary.Text = Format(Salary, "0.00")
    End Sub
    Private Sub E_CalculateOverTime(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim OverTime1 As Double = 0
        Dim OverTime2 As Double = 0

        If Me.txtOvertime1.Text = "" Then
            Me.txtOvertime1.Text = 0
        End If
        If Me.txtOvertime2.Text = "" Then
            Me.txtOvertime2.Text = 0
        End If
        OverTime1 = RoundMe3(RateForOvertimeCalc * Parameters.OverTime_Rate1 * Me.txtOvertime1.Text, 2)
        OverTime2 = RoundMe3(RateForOvertimeCalc * Parameters.OverTime_Rate2 * Me.txtOvertime2.Text, 2)

        Dim i As Integer
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = OverTime1 + OverTime2
                Exit For
            End If
        Next
        'Me.txtOver1.Text = Format(OverTime1, "0.00")
        'Me.txtOver2.Text = Format(OverTime2, "0.00")
    End Sub
    Private Sub E_CalculateArrears(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim Arrears As Double = 0
        Dim i As Integer
        If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
            If Me.GlbEmpSalary.EffPayDate >= Me.GLBCurrentPeriod.DateFrom Then
                If Me.GlbEmpSalary.EffPayDate <= Me.GLBCurrentPeriod.DateTo Then
                    Dim NumberOfPeriods As Integer
                    NumberOfPeriods = Global1.Business.GetNumberOfNormalPeriodsBack(GlbEmpSalary, GLBCurrentPeriod)
                    Arrears = NumberOfPeriods * GlbEmpSalary.EmpSal_Dif
                End If
            End If
        End If
        ArrearsFor13AND14Calc = Arrears
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = Arrears
                Exit For
            End If
        Next
        'Me.txtarrears.text = Format(Arrears, "0.00")
    End Sub
    Private Sub E_13Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t13Salary As Double = 0
        Dim ActualUnits As Double = Me.txtActualUnits.Text
        Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
        Dim SumOfAnuallUnitOfNormalPeriods As Double
        Dim AnuallUnitsOfThisPeriod As Double = 0
        Dim i As Integer


        AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

        SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

        t13Salary = GrossDIVNormalUnitsForCalc * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod)

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = t13Salary
                Exit For
            End If
        Next
    End Sub
    Private Sub E_14Salary(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t14Salary As Double = 0
        Dim ActualUnits As Double = Me.txtActualUnits.Text
        Dim SILeaveUnits As Double = Me.txtSILeaveUnits.Text
        Dim SumOfAnuallUnitOfNormalPeriods As Double
        Dim AnuallUnitsOfThisPeriod As Double = 0
        Dim i As Integer

        AnuallUnitsOfThisPeriod = ActualUnits + SILeaveUnits

        SumOfAnuallUnitOfNormalPeriods = Global1.Business.GetSumOfAnuallUnitsFor(Me.GLBCurrentPeriod, Emp.Code)

        t14Salary = GrossDIVNormalUnitsForCalc * (SumOfAnuallUnitOfNormalPeriods + AnuallUnitsOfThisPeriod)
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = t14Salary
                Exit For
            End If
        Next
    End Sub
    Private Sub E_Calculate13Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t13estimate As Double = 0
        Dim AnnualPeriodUnits As Double
        Dim t13thPeriodTotalUnits As Double
        Dim i As Integer

        t13thPeriodTotalUnits = Global1.Business.Find13nthPeriodUnits(Me.GLBCurrentPeriod)
        AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

        If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
            If t13thPeriodTotalUnits <> 0 Then
                t13estimate = Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc * (AnnualPeriodUnits / t13thPeriodTotalUnits)
            End If
        End If

        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = t13estimate
                Exit For
            End If
        Next
    End Sub
    Private Sub E_Calculate14Estimate(ByVal Emp As cPrMsEmployees, ByVal EmpEarn As cPrMsEmployeeEarnings, ByVal Earn As cPrMsEarningCodes)
        Dim t14estimate As Double = 0
        Dim AnnualPeriodUnits As Double
        Dim t14thPeriodTotalUnits As Double
        Dim i As Integer

        t14thPeriodTotalUnits = Global1.Business.Find14nthPeriodUnits(Me.GLBCurrentPeriod)
        AnnualPeriodUnits = CDbl(Me.txtActualUnits.Text) + CDbl(Me.txtSILeaveUnits.Text)

        If Me.GLBCurrentPeriod.PayCat_Code = Global1.GLB_PeriodCategory_Normal Then
            If t14thPeriodTotalUnits <> 0 Then
                t14estimate = Me.GrossFor13AND14Calc + ArrearsFor13AND14Calc * (AnnualPeriodUnits / t14thPeriodTotalUnits)
            End If
        End If
        For i = 0 To E_Final.Length - 1
            If Earn.Code = E_Final(i).Earn.ErnCodCode Then
                E_Final(i).MyValue = t14estimate
                Exit For
            End If
        Next
        ' Me.txt14Estimate.Text = Format(t14estimate, "0.00")
    End Sub
#End Region
#Region "Deductions Calculations"
    Private Sub CalculateDeductions(ByVal Emp As cPrMsEmployees)
        Dim ds As DataSet
        Dim i As Integer
        ' Dim Period As New cprmspe
        ds = Global1.Business.GetAllPrMsEmployeeDeductions(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim ED As New cPrMsEmployeeDeductions(ds.Tables(0).Rows(i))
                Dim Ded As New cPrMsDeductionCodes(ED.DedCode)
                Select Case Ded.DedTypCode
                    Case "AD" 'ADVANCES
                        D_CalculateAdvances(Emp, ED, Ded)
                    Case "CL" 'COMPANY LOAN
                        D_CalculateCompanyLoan(Emp, ED, Ded)
                    Case "IT" 'INCOME TAX

                    Case "MF" 'MEDICAL FUND
                        D_CalculateMedicalFund(Emp, ED, Ded)
                    Case "PF" 'PROVIDENT FUND
                        D_CalculateProvidentFund(Emp, ED, Ded)
                    Case "PL" 'PROVIDENT FUND LOAN
                        D_CalculateProvidentFundLoan(Emp, ED, Ded)
                    Case "SI" 'SOCIAL INSURANCE
                        D_CalculateSocialInsurance(Emp, ED, Ded)
                    Case "U2" 'UNION NEWSPAPER
                        D_CalculateUnion2(Emp, ED, Ded)
                    Case "U3" 'OTHER
                        D_CalculateUnion3(Emp, ED, Ded)
                    Case "US" 'UNINON SUBSCRIPTION
                        D_CalculateUnionSubscription(Emp, ED, Ded)
                End Select
            Next
        End If
    End Sub
    Private Sub D_CalculateAdvances(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim Advances As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                Advances = EmpDed.MyValue / 100 * ValueToCalcFrom
            ElseIf TempDed.TypeMode = "V" Then
                Advances = EmpDed.MyValue
            End If
        End If
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = Advances
                Exit For
            End If
        Next
    End Sub
    Private Sub D_CalculateCompanyLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim CompanyLoan As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                CompanyLoan = EmpDed.MyValue / 100 * ValueToCalcFrom
            ElseIf TempDed.TypeMode = "V" Then
                CompanyLoan = EmpDed.MyValue
            End If
        End If
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = CompanyLoan
                Exit For
            End If
        Next

    End Sub
    Private Sub D_CalculateProvidentFundLoan(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim PFLoan As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                PFLoan = EmpDed.MyValue / 100 * ValueToCalcFrom
            ElseIf TempDed.TypeMode = "V" Then
                PFLoan = EmpDed.MyValue
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
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                If TempDed.FromMode = "E" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.ProFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.DedValue
                    Else
                        MFValue = 0
                    End If
                End If
                MFValue = MFValue / 100 * ValueToCalcFrom

            ElseIf TempDed.TypeMode = "V" Then
                If TempDed.FromMode = "E" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "F" Then
                    MFValue = EmpDed.MyValue
                ElseIf TempDed.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.ProFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.DedValue
                    Else
                        MFValue = 0
                    End If
                End If
            End If
        End If
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = MFValue
                Exit For
            End If
        Next

    End Sub
    Private Sub D_CalculateProvidentFund(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim PFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
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
                PFValue = PFValue / 100 * ValueToCalcFrom
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
        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = PFValue
                Exit For
            End If
        Next


    End Sub
    Private Sub D_CalculateSocialInsurance(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim SIValue As Double
        Dim SIValueFinal As Double
        Dim ValueToCalcFrom As Double
        Dim Ds As DataSet
        Dim Limits As New cPrSsLimits
        Dim AnnualSIincome As Double
        Dim TempAnnualSIincome As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next

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

                ' Check Insurable Limits
                If ValueToCalcFrom > Limits.InsurableMth Then
                    ValueToCalcFrom = Limits.InsurableMth
                Else
                    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                End If
                SIValue = SIValue / 100 * ValueToCalcFrom

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


        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "D", Emp.TemGrp_Code)
        TempAnnualSIincome = AnnualSIincome + SIValueFinal
        If TempAnnualSIincome > Limits.InsurableAnnual Then
            SIValueFinal = Limits.InsurableAnnual - AnnualSIincome
        End If

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = SIValue
                Exit For
            End If
        Next

    End Sub
    Private Sub D_CalculateUnionSubscription(ByVal Emp As cPrMsEmployees, ByVal EmpDed As cPrMsEmployeeDeductions, ByVal Dedu As cPrMsDeductionCodes)
        Dim TempDed As New cPrMsTemplateDeductions
        Dim i As Integer
        Dim UnionValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Dedu.Code = Ded(i).Ded.DedCodCode Then
                TempDed = Ded(i).Ded
                Exit For
            End If
        Next
        Dim Union As New cPrAnUnions(Emp.Uni_Code)
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                UnionValue = EmpDed.MyValue / 100 * ValueToCalcFrom
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
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                Union2Value = EmpDed.MyValue / 100 * ValueToCalcFrom
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

todo:   'Check(LIMIT)

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
                Exit For
            End If
        Next
        If TempDed.DedCodCode <> "" Then
            If TempDed.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempDed.CalcFormula)
                Union3Value = EmpDed.MyValue / 100 * ValueToCalcFrom
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
todo:   'Check(LIMIT)

        For i = 0 To D_Final.Length - 1
            If Dedu.Code = D_Final(i).Ded.DedCodCode Then
                D_Final(i).MyValue = Union3Value
                Exit For
            End If
        Next


    End Sub



#End Region
#Region "Contributions Calculations"
    Private Sub CalculateContributions(ByVal Emp As cPrMsEmployees)
        Dim ds As DataSet
        Dim i As Integer
        ' Dim Period As New cprmspe
        ds = Global1.Business.GetAllPrMsEmployeeContributions(Emp.Code)
        If CheckDataSet(ds) Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim EC As New cPrMsEmployeeContributions(ds.Tables(0).Rows(i))
                Dim Con As New cPrMsContributionCodes(EC.ConCode)
                Select Case Con.ConTypCode
                    Case "IN" 'INDUSTRIAL
                        C_CalculateIndustrial(Emp, EC, Con)
                    Case "MF" 'MEDICAL FUND
                        C_CalculateMedicalFund(Emp, EC, Con)
                    Case "PF" 'PROVIDENT FUND
                        C_CalculateProvidentFund(Emp, EC, Con)
                    Case "SI" 'SOCIAL INSURANCE
                        C_CalculateSocialInsurance(Emp, EC, Con)
                    Case "ST" 'SOCIAL COHESION FUND
                        C_CalculateSocialCohesionFund(Emp, EC, Con)
                    Case "UN" 'UNEMPLOYMENT
                        C_CalculateUnemploymentFund(Emp, EC, Con)
                    Case "WF" 'WELFAIR FUND
                        C_CalculateWelFairFund(Emp, EC, Con)
                End Select
            Next
        End If
    End Sub
    Private Sub C_CalculateIndustrial(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
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
                Exit For
            End If
        Next

        ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
        If CheckDataSet(ds) Then
            Limits = New cPrSsLimits(ds.Tables(0).Rows(0))
        Else
            MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
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
                ' Check Insurable Limits
               
                If ValueToCalcFrom > Limits.InsurableMth Then
                    ValueToCalcFrom = Limits.InsurableMth
                Else
                    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                End If
                ''
                Industrial = Industrial / 100 * ValueToCalcFrom
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

        AnnualINDCon = Global1.Business.FindSumForThisPeriodYearUntilNowOfContributionCodeType(GLBCurrentPeriod, Cont, Emp.Code)
        TempAnnualINDCon = AnnualINDCon + Industrial
        If TempAnnualINDCon > Limits.UnemAnnual Then
            Industrial = Limits.IndAnnual - AnnualINDCon
        End If



        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = Industrial
                Exit For
            End If
        Next
    End Sub
    Private Sub C_CalculateMedicalFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim MFValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                Exit For
            End If
        Next
        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                If TempCon.FromMode = "E" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.ProFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.ConValue
                    Else
                        MFValue = 0
                    End If
                End If
                MFValue = MFValue / 100 * ValueToCalcFrom
            ElseIf TempCon.TypeMode = "V" Then
                If TempCon.FromMode = "E" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "F" Then
                    MFValue = EmpCon.MyValue
                ElseIf TempCon.FromMode = "T" Then
                    Dim MedFund As New cPrSsMedicalFund(Emp.ProFnd_Code)
                    If MedFund.Code <> "" Then
                        MFValue = MedFund.ConValue
                    Else
                        MFValue = 0
                    End If
                End If
            End If
        End If
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = MFValue
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
                Exit For
            End If
        Next
        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
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
                PFValue = PFValue / 100 * ValueToCalcFrom
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
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = PFValue
                Exit For
            End If
        Next


    End Sub
    Private Sub C_CalculateSocialInsurance(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim SIValue As Double
        Dim SIValueFinal As Double
        Dim ValueToCalcFrom As Double
        Dim Ds As DataSet
        Dim Limits As New cPrSsLimits
        Dim AnnualSIincome As Double
        Dim TempAnnualSIincome As Double
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                Exit For
            End If
        Next

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
                'Check Insurable Limits
                If ValueToCalcFrom > Limits.InsurableMth Then
                    ValueToCalcFrom = Limits.InsurableMth
                Else
                    ValueToCalcFrom = Utils.roundmeup(ValueToCalcFrom)
                End If
                SIValue = SIValue / 100 * ValueToCalcFrom

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


       

        AnnualSIincome = Global1.Business.FindSIIncomeForThisPeriodYearUntilNow(GLBCurrentPeriod, Emp.Code, "C", Emp.TemGrp_Code)
        TempAnnualSIincome = AnnualSIincome + SIValueFinal
        If TempAnnualSIincome > Limits.InsurableAnnual Then
            SIValueFinal = Limits.InsurableAnnual - AnnualSIincome
        End If

        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = SIValue
                Exit For
            End If
        Next

    End Sub
    Private Sub C_CalculateSocialCohesionFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim SCValue As Double
        Dim ValueToCalcFrom As Double
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                Exit For
            End If
        Next
        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
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
                SCValue = SCValue / 100 * ValueToCalcFrom
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
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = SCValue
                Exit For
            End If
        Next
    End Sub
    Private Sub C_CalculateUnemploymentFund(ByVal Emp As cPrMsEmployees, ByVal EmpCon As cPrMsEmployeeContributions, ByVal Cont As cPrMsContributionCodes)
        Dim TempCon As New cPrMsTemplateContributions
        Dim i As Integer
        Dim UFValue As Double
        Dim ValueToCalcFrom As Double
        Dim Limits As New cPrSsLimits
        Dim AnnualUNECon As Double = 0
        Dim TempAnnualUNECon As Double = 0

        Dim ds As DataSet
        For i = 0 To Ded.Length - 1
            If Cont.Code = Con(i).Con.ConCodCode Then
                TempCon = Con(i).Con
                Exit For
            End If
        Next
        ds = Global1.Business.GetActivelimitsForPeriod(GLBCurrentPeriod)
        If CheckDataSet(ds) Then
            Limits = New cPrSsLimits(ds.Tables(0).Rows(0))
        Else
            MsgBox("No Social Insurance Limits Defined !!!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
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
                ' Check Insurable Limits
                If ValueToCalcFrom > Limits.InsurableMth Then
                    ValueToCalcFrom = Limits.InsurableMth
                Else
                    ValueToCalcFrom = Utils.RoundMeUp(ValueToCalcFrom)
                End If


                UFValue = UFValue / 100 * ValueToCalcFrom
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

        AnnualUNECon = Global1.Business.FindSumForThisPeriodYearUntilNowOfContributionCodeType(GLBCurrentPeriod, Cont, Emp.Code)
        TempAnnualUNECon = AnnualUNECon + UFValue
        If TempAnnualUNECon > Limits.UnemAnnual Then
            UFValue = Limits.UnemAnnual - AnnualUNECon
        End If


        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = UFValue
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
                Exit For
            End If
        Next
        If TempCon.ConCodCode <> "" Then
            If TempCon.TypeMode = "P" Then
                ValueToCalcFrom = FindValueOfFormula(TempCon.CalcFormula)
                WFValue = EmpCon.MyValue / 100 * ValueToCalcFrom
            ElseIf TempCon.TypeMode = "V" Then
                WFValue = EmpCon.MyValue
            End If
        End If
        For i = 0 To C_Final.Length - 1
            If Cont.Code = C_Final(i).Con.ConCodCode Then
                C_Final(i).MyValue = WFValue
                Exit For
            End If
        Next
    End Sub
#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DoCalculations()
    End Sub
    Private Sub DoCalculations()
        CalculateEarnings(GLBEmployee)
        CalculateDeductions(GLBEmployee)
        CalculateContributions(GLBEmployee)
    End Sub
    Private Function FindValueOfFormula(ByVal CalcFormula As String) As Double
        Dim i As Integer
        Dim k As Integer
        Dim S As String
        Dim Val As Double = 0
        For i = 0 To CalcFormula.Length - 1
            S = CalcFormula.Substring(i, 1)
            For k = 0 To E_Final.Length - 1
                If S = E_Final(k).Earn.Sequence Then
                    Val = Val + E_Final(k).MyValue
                End If
            Next
        Next
        Return Val
    End Function
   
    Private Sub GetPeriodEDC()
        DsP_Ern = Global1.Business.GetAllPrMsPeriodEarnings(Me.GLBCurrentPeriod.Code, True)
        DSP_Ded = Global1.Business.GetAllPrMsPeriodDeductions(Me.GLBCurrentPeriod.Code, True)
        DSP_Con = Global1.Business.GetAllPrMsPeriodContributions(Me.GLBCurrentPeriod.Code, True)
    End Sub

    
End Class
