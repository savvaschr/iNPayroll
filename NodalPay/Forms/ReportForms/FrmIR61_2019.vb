Public Class FrmIR61_2019
    Public PerGroup As New cPrMsPeriodGroups
    Public TempGroupCode As String
    Dim Loading As Boolean = True
    Dim TAXFileDir As String
    Dim InitFile As Boolean = True
    Dim GLBDisplayFilename As String = ""


    Dim COLx_TaxpayerNumber As Integer = 0
    '<!-- q1 TIN: Empoyee -MANDATORY - ->
    Dim COLx_Name As Integer = 1
    '<!-- q2a Name(XML)- MANDATORY  -->
    Dim COLx_EmployeeStartDate As Integer = 2
    '<!-- q3 New Employee Start Date (YYYY-MM-DD) -->
    Dim COLx_EmploymentEndDate As Integer = 3
    '<!-- q4 Employment End Date (YYYY-MM-DD) -->
    Dim COLx_Emoluments As Integer = 4
    '<!-- q5 Emoluments  -->
    Dim COLx_Pensions As Integer = 5
    '<!-- q6 Pensions  -->
    Dim COLx_SocialInsurancePensions As Integer = 6
    '<!-- q7 Social Insurance Pensions taken into account  -->
    Dim COLx_GrossEmoluments As Integer = 7
    '<!-- q8 Gross Emoluments  -->
    Dim COLx_BenefitFromRelatedParties As Integer = 8
    '<!-- q9 Financial benefits of directors Or shareholders Or related parties thereof -->
    Dim COLx_TaxWithheldGrossEmoluments As Integer = 9
    '<!-- q10 Tax Withheld from gross emoluments - MANDATORY (>=35%*(q7+q8)) -->
    Dim COLx_TaxDeductedFinancialBenefitsRelatedParties As Integer = 10
    '<!-- q10b Tax deducted for financial benefits of directors Or shareholders Or related parties thereof  -->
    Dim COLx_GhsWithheldPensioners As Integer = 11
    '<!-- q11 GHS Withheld from pensioners  -->
    Dim COLx_GhsWithheldEmployee As Integer = 12
    '<!-- q12 GHS Withheld from employees  -->
    Dim COLx_IsEmployeeOfficer As Integer = 13
    '<!-- q13 Is the employee an Officer? (0/1)- MANDATORY  -->
    Dim COLx_GhsWithheldOfficer As Integer = 14
    '<!-- q14 GHS Withheld from officers - MANDATORY if q13 = 1  -->
    Dim COLx_GhsEmployersContribution As Integer = 15
    '<!-- q15 GHS Employer's Contribution - MANDATORY if q13 = 1  -->
    Dim COLx_IsBonusReceivedThisMonthForPreviousYear As Integer = 16
    '<!-- q16 Has the employee received a bonus this month for the previous year? (0/1)- MANDATORY  -->
    Dim COLx_PriorYearBonusPaid As Integer = 17
    '<!-- q17 Prior Year Bonus Paid  -->
    Dim COLx_PriorBonusYear As Integer = 18
    '<!-- q18 Year for which bonus was paid  -->
    Dim COLx_WasEmployeeAnOfficerAtEndOfBonusYear As Integer = 19
    '<!-- q19 Was the employee an officer at the end of the year of the bonus? (0/1) -->
    Dim COLx_TaxWithheldFrBonus As Integer = 20
    '<!-- q20 Tax Withheld from Prior Year Bonus  -->
    Dim COLx_BonusGhsWithheldOfficers As Integer = 21
    '<!-- q21 GHS Withheld from Officers (Bonus)  -->
    Dim COLx_GhsWithheldFromEmployeeBonus As Integer = 22
    '<!-- q22 GHS Withheld from Employee (Bonus)  -->
    Dim COLx_BonusGhsEmployersContribution As Integer = 23
    '<!-- q23 GHS Employer's Contribution (Bonus of officers)  -->
    Dim COLx_PensionableBenefitsContribution As Integer = 24
    '<!-- q24 Contribution towards pensionable benefits (3%) - MANDATORY  -->
    Dim COLx_EmpCode As Integer = 25

    Dim COLx_LWBPen As Integer = 26

    Private Sub FrmIR61_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadSIPeriods()
        IR61()
        Dim TemGrp As New cPrMsTemplateGroup(TempGroupCode)

        Dim C As New cAdMsCompany(TemGrp.CompanyCode)
        Me.txtTAXId.Text = C.TIC
        Me.txtCompName.Text = C.Name
        Me.txtAdr1.Text = C.Address1 & " " & C.Address2
        Me.txtAdr2.Text = C.Address3 & " " & C.Address4
        Me.txtTaxYear.Text = PerGroup.Year




    End Sub
    Private Sub LoadSIPeriods()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsSocialInsPeriods()
        With Me.CmbSIPeriod
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrSsSocialInsPeriods(ds.Tables(0).Rows(i))
                    .Items.Add(P)
                Next
            End If
            .EndUpdate()
            .SelectedIndex = 0
        End With
        loading = False
    End Sub
    Private Sub IR61()
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim dsEmp As DataSet
        Dim Ds As DataSet
        Dim DsDED As DataSet
        Dim DsCON As DataSet
        Dim DsCONPen As DataSet
        Dim DED As Double = 0
        Dim CON As Double = 0
        Dim dTax As Double = 0

        Dim DsDEDDirector As DataSet
        Dim DsCONDirector As DataSet



        Dim SIPeriod As cPrSsSocialInsPeriods
        SIPeriod = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Me.txtTaxMonth.Text = SIPeriod.DescriptionL

        Ds = Global1.Business.REPORT_IR61(PerGroup, SIPeriod)
        If CheckDataSet(Ds) Then
            Me.txtITAmount.Text = Format(DbNullToDouble(Ds.Tables(0).Rows(0).Item(0)), "0.00")
            dTax = DbNullToDouble(Ds.Tables(0).Rows(0).Item(0))
        Else
            Me.txtITAmount.Text = "0.00"
            dTax = 0

        End If

        Dim DsTaxable As DataSet
        DsTaxable = Global1.Business.REPORT_IR61_GetTaxableIncome(PerGroup, SIPeriod)
        If CheckDataSet(DsTaxable) Then
            Me.txtTaxableIncome.Text = Format(DbNullToDouble(DsTaxable.Tables(0).Rows(0).Item(0)), "0.00")
            'dTax = DbNullToDouble(Ds.Tables(0).Rows(0).Item(0))
        Else
            Me.txtTaxableIncome.Text = "0.00"
            'dTax = 0

        End If


        DsDED = Global1.Business.REPORT_IR61_Gesy_DEDUCTION(PerGroup, SIPeriod)
        If CheckDataSet(DsDED) Then
            Me.txtGesyDed.Text = Format(DbNullToDouble(DsDED.Tables(0).Rows(0).Item(0)), "0.00")
            DED = DbNullToDouble(DsDED.Tables(0).Rows(0).Item(0))
        Else
            Me.txtGesyDed.Text = "0.00"
            DED = 0
        End If

        DsCON = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION(PerGroup, SIPeriod)
        If CheckDataSet(DsCON) Then
            Me.txtGesyCon.Text = Format(DbNullToDouble(DsCON.Tables(0).Rows(0).Item(0)), "0.00")
            CON = DbNullToDouble(DsCON.Tables(0).Rows(0).Item(0))
        Else
            Me.txtGesyCon.Text = "0.00"
            CON = 0
        End If

        DsCONPen = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_LWBPen(PerGroup, SIPeriod)
        If CheckDataSet(DsCONPen) Then
            CON = CON + DbNullToDouble(DsCONPen.Tables(0).Rows(0).Item(0))
            Me.txtGesyCon.Text = Format(CON, "0.00")

        End If

        DsCONDirector = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_Directors(PerGroup, SIPeriod)
        If CheckDataSet(DsCONDirector) Then
            DED = DED + DbNullToDouble(DsCONDirector.Tables(0).Rows(0).Item(0))
            Me.txtGesyDed.Text = Format(DED, "0.00")

        End If

        DsDEDDirector = Global1.Business.REPORT_IR61_Gesy_DEDUCTION_Directors(PerGroup, SIPeriod)
        If CheckDataSet(DsDEDDirector) Then
            CON = CON + DbNullToDouble(DsDEDDirector.Tables(0).Rows(0).Item(0))
            Me.txtGesyCon.Text = Format(CON, "0.00")

        End If

        Dim TotalSpecialTax As Double = RoundMe3(DED + CON, 2)
        Me.txtTotal.Text = Format(dTax + TotalSpecialTax, "0.00")

        Dim Ar() As String
        Dim Ar1() As String
        Dim TAX As String

        TAX = txtTotal.Text

        Ar = TAX.Split(".")
        Dim Amount1 As String
        Amount1 = Global1.Business.NumToWords(CInt(Ar(0)))
        Amount1 = UCase(Amount1) & " EURO "

        Dim Amount2 As String
        Amount2 = Global1.Business.NumToWords(CInt(Ar(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2
        Dim k As Integer
        Dim Final1 As String = ""
        Dim Final2 As String = ""
        Dim TempFinal As String = ""
        If Amount1.Length > 40 Then
            Ar1 = Amount1.Split(" ")
            For i = 0 To Ar1.Length - 1
                TempFinal = TempFinal & Ar1(i) & " "
                If TempFinal.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1 = TempFinal
                End If
            Next
            For i = k To Ar1.Length - 1
                Final2 = Final2 & Ar1(i) & " "
            Next
        Else
            Final1 = Amount1
        End If

        Me.txtAIW1.Text = Final1
        Me.txtAIW2.Text = Final2

        Me.Cursor = Cursors.Default


    End Sub


    Private Sub TSBReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBReport.Click
        ShowTheReport(False)
    End Sub
    Private Sub ShowTheReport(ByVal ToPrinter As Boolean)

        '  MsgBox("Please Put a formal Monthly Income Tax Document in Printer Tray and Click OK", MsgBoxStyle.Information)

        Dim Ds As New DataSet
        Dim Col_TAXId As Integer = 0
        Dim Col_CompanyName As Integer = 1
        Dim Col_Adr1 As Integer = 2
        Dim Col_Adr2 As Integer = 3
        Dim Col_Amount As Integer = 4
        Dim Col_ChequeNo As Integer = 5
        Dim Col_Year As Integer = 6
        Dim Col_Month As Integer = 7
        Dim Col_AW1 As Integer = 8
        Dim Col_AW2 As Integer = 9
        Dim Col_GesyDed As Integer = 10
        Dim Col_AWsp1 As Integer = 11
        Dim Col_AWsp2 As Integer = 12
        Dim Col_GrandTotal As Integer = 13
        Dim Col_AWG1 As Integer = 14
        Dim Col_AWG2 As Integer = 15

        Dim Col_GesyCon As Integer = 16
        Dim Col_AWsp11 As Integer = 17
        Dim Col_AWsp22 As Integer = 18


        Dim dt As New DataTable

        dt = New DataTable("TAX")
        '0
        dt.Columns.Add(New DataColumn("TAXId", System.Type.GetType("System.String")))
        '1
        dt.Columns.Add(New DataColumn("CompanyName", System.Type.GetType("System.String")))
        '2
        dt.Columns.Add(New DataColumn("Adr1", System.Type.GetType("System.String")))
        '3
        dt.Columns.Add(New DataColumn("Adr2", System.Type.GetType("System.String")))
        '4
        dt.Columns.Add(New DataColumn("TaxAmount", System.Type.GetType("System.Double")))
        '5
        dt.Columns.Add(New DataColumn("ChequeNo", System.Type.GetType("System.String")))
        '6
        dt.Columns.Add(New DataColumn("YEAR", System.Type.GetType("System.String")))
        '7
        dt.Columns.Add(New DataColumn("Month", System.Type.GetType("System.String")))
        '8
        dt.Columns.Add(New DataColumn("AW", System.Type.GetType("System.String")))
        '9
        dt.Columns.Add(New DataColumn("AW2", System.Type.GetType("System.String")))
        '10
        dt.Columns.Add(New DataColumn("GesyDed", System.Type.GetType("System.Double")))
        '11
        dt.Columns.Add(New DataColumn("AWSP1", System.Type.GetType("System.String")))
        '12
        dt.Columns.Add(New DataColumn("AWSP2", System.Type.GetType("System.String")))
        '13
        dt.Columns.Add(New DataColumn("FinalTotal", System.Type.GetType("System.Double")))
        '14
        dt.Columns.Add(New DataColumn("AWFinal1", System.Type.GetType("System.String")))
        '15
        dt.Columns.Add(New DataColumn("AWFinal2", System.Type.GetType("System.String")))
        '16
        dt.Columns.Add(New DataColumn("GesyCon", System.Type.GetType("System.Double")))
        '17
        dt.Columns.Add(New DataColumn("AWSP11", System.Type.GetType("System.String")))
        '18
        dt.Columns.Add(New DataColumn("AWSP22", System.Type.GetType("System.String")))




        Dim FinalTotal As String = Me.txtTotal.Text
        Dim IT As String = Me.txtITAmount.Text

        Dim AWSP1 As String
        Dim AWSP2 As String

        Dim AWFinal1 As String
        Dim AWFinal2 As String

        Dim AWSP11 As String
        Dim AWSP22 As String



        ''Calculate Words for Gesy Deductions Total
        Dim Ar() As String
        Dim Ar1() As String
        Dim i As Integer
        Ar = Me.txtGesyDed.Text.Split(".")
        Dim Amount1 As String
        Amount1 = Global1.Business.NumToWords(CInt(Ar(0)))
        Amount1 = UCase(Amount1) & " EURO "

        Dim Amount2 As String
        Amount2 = Global1.Business.NumToWords(CInt(Ar(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2
        Dim k As Integer
        Dim Final1 As String = ""
        Dim Final2 As String = ""
        Dim TempFinal As String = ""
        If Amount1.Length > 40 Then
            Ar1 = Amount1.Split(" ")
            For i = 0 To Ar1.Length - 1
                TempFinal = TempFinal & Ar1(i) & " "
                If TempFinal.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1 = TempFinal
                End If
            Next
            For i = k To Ar1.Length - 1
                Final2 = Final2 & Ar1(i) & " "
            Next
        Else
            Final1 = Amount1
        End If

        AWSP1 = Final1
        AWSP2 = Final2
        ''
        ''Calculate Words for IT

        Dim ArX() As String
        Dim Ar1X() As String
        k = 0
        Dim Final1x As String = ""
        Dim Final2x As String = ""
        Dim TempFinalx As String = ""

        ArX = Me.txtITAmount.Text.Split(".")

        Amount1 = Global1.Business.NumToWords(CInt(ArX(0)))
        Amount1 = UCase(Amount1) & " EURO "


        Amount2 = Global1.Business.NumToWords(CInt(ArX(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2

        If Amount1.Length > 40 Then
            Ar1X = Amount1.Split(" ")
            For i = 0 To Ar1X.Length - 1
                TempFinalx = TempFinalx & Ar1X(i) & " "
                If TempFinalx.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1x = TempFinalx
                End If
            Next
            For i = k To Ar1X.Length - 1
                Final2x = Final2x & Ar1X(i) & " "
            Next
        Else
            Final1x = Amount1
        End If

        AWFinal1 = Final1x
        AWFinal2 = Final2x
        ''

        ''Calculate Words for Gesy Contributions Total
        Dim ArY() As String
        Dim Ar1Y() As String
        k = 0
        Dim Final1Y As String = ""
        Dim Final2Y As String = ""
        Dim TempFinalY As String = ""

        ArY = Me.txtGesyCon.Text.Split(".")

        Amount1 = Global1.Business.NumToWords(CInt(ArY(0)))
        Amount1 = UCase(Amount1) & " EURO "


        Amount2 = Global1.Business.NumToWords(CInt(ArY(1)))
        Amount2 = " AND " & UCase(Amount2) & " CENTS"

        Amount1 = Amount1 & Amount2

        If Amount1.Length > 40 Then
            Ar1Y = Amount1.Split(" ")
            For i = 0 To Ar1Y.Length - 1
                TempFinalY = TempFinalY & Ar1Y(i) & " "
                If TempFinalY.Length > 40 Then
                    k = i
                    Exit For
                Else
                    Final1Y = TempFinalY
                End If
            Next
            For i = k To Ar1Y.Length - 1
                Final2Y = Final2Y & Ar1Y(i) & " "
            Next
        Else
            Final1Y = Amount1
        End If

        AWSP11 = Final1Y
        AWSP22 = Final2Y






        Ds.Tables.Add(dt)
        Dim R As DataRow

        R = dt.NewRow
        R(Col_TAXId) = Me.txtTAXId.Text
        R(Col_CompanyName) = Me.txtCompName.Text
        R(Col_Adr1) = Me.txtAdr1.Text
        R(Col_Adr2) = Me.txtAdr2.Text
        R(Col_Amount) = Me.txtITAmount.Text
        R(Col_ChequeNo) = Me.txtChequeNo.Text
        R(Col_Year) = Me.txtTaxYear.Text
        R(Col_Month) = Me.txtTaxMonth.Text
        R(Col_AW1) = Me.txtAIW1.Text
        R(Col_AW2) = Me.txtAIW2.Text
        R(Col_GesyDed) = Me.txtGesyDed.Text
        R(Col_AWsp1) = AWSP1
        R(Col_AWsp2) = AWSP2
        R(Col_GrandTotal) = Me.txtTotal.Text
        R(Col_AWG1) = AWFinal1
        R(Col_AWG2) = AWFinal2
        R(Col_GesyCon) = Me.txtGesyCon.Text
        R(Col_AWsp11) = AWSP11
        R(Col_AWsp22) = AWSP22




        dt.Rows.Add(R)

        '  Utils.WriteSchemaWithXmlTextWriter(Ds, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\IR61")
        If CheckDataSet(Ds) Then
            Utils.ShowReport("IR61_2019.rpt", Ds, FrmReport, "CYPRUS MONTHLY INCOME TAX (Rpt 61)", ToPrinter)
        Else
            MsgBox("No records found")
        End If

    End Sub

    Private Sub CmbSIPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSIPeriod.SelectedIndexChanged
        If Loading Then Exit Sub

        Me.PanelLoading.Visible = True
        Application.DoEvents()
        IR61()
        Me.PanelLoading.Visible = False
        Application.DoEvents()
    End Sub

    Private Sub TSBSendToPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSendToPrinter.Click
        ShowTheReport(True)
    End Sub

    Private Sub CreateMonthlyFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateMonthlyFileToolStripMenuItem.Click
        CreateMonthlyFileToTAX(False)
    End Sub

    Private Sub CreateMonthlyFileWithExcelReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateMonthlyFileWithExcelReportToolStripMenuItem.Click
        CreateMonthlyFileToTAX(True)
    End Sub
    Private Sub CreateMonthlyFileToTAX(WithExcel As Boolean)
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("SIContributions", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            TAXFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing TAX File Directory - Parameter Section 'SIContributions' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            TAXFileDir = ""
            Exit Sub
        End If

        MonthlyReportTofile(WithExcel)
    End Sub
    Private Sub MonthlyReportTofile(ShowExcel As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim Ds As New DataSet
        Dim DsTax As DataSet
        Dim DsTaxable As DataSet
        Dim DsDED As DataSet
        Dim DsCON As DataSet
        Dim DsCONPen As DataSet
        Dim DED As Double = 0
        Dim CON As Double = 0
        Dim dTax As Double = 0

        Dim DsDEDDirector As DataSet
        Dim DsCONDirector As DataSet




        Dim dt As New DataTable

        dt = New DataTable("TAX")
        '0
        dt.Columns.Add(New DataColumn("TaxpayerNumber", System.Type.GetType("System.String")))
        '1
        dt.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))
        '2
        dt.Columns.Add(New DataColumn("EmployeeStartDate", System.Type.GetType("System.String")))
        '3
        dt.Columns.Add(New DataColumn("EmploymentEndDate", System.Type.GetType("System.String")))
        '4
        dt.Columns.Add(New DataColumn("Emoluments", System.Type.GetType("System.String")))
        '5
        dt.Columns.Add(New DataColumn("Pensions", System.Type.GetType("System.String")))
        '6
        dt.Columns.Add(New DataColumn("SocialInsurancePensions", System.Type.GetType("System.String")))
        '7
        dt.Columns.Add(New DataColumn("GrossEmoluments", System.Type.GetType("System.String")))
        '8
        dt.Columns.Add(New DataColumn("BenefitFromRelatedParties", System.Type.GetType("System.String")))
        '9
        dt.Columns.Add(New DataColumn("TaxWithheldGrossEmoluments", System.Type.GetType("System.String")))
        '10
        dt.Columns.Add(New DataColumn("TaxDeductedFinancialBenefitsRelatedParties", System.Type.GetType("System.String")))
        '11
        dt.Columns.Add(New DataColumn("GhsWithheldPensioners", System.Type.GetType("System.String")))
        '12
        dt.Columns.Add(New DataColumn("GhsWithheldEmployee", System.Type.GetType("System.String")))
        '13
        dt.Columns.Add(New DataColumn("IsEmployeeOfficer", System.Type.GetType("System.String")))
        '14
        dt.Columns.Add(New DataColumn("GhsWithheldOfficer", System.Type.GetType("System.String")))
        '15
        dt.Columns.Add(New DataColumn("GhsEmployersContribution", System.Type.GetType("System.String")))
        '16
        dt.Columns.Add(New DataColumn("IsBonusReceivedThisMonthForPreviousYear", System.Type.GetType("System.String")))
        '17
        dt.Columns.Add(New DataColumn("PriorYearBonusPaid", System.Type.GetType("System.String")))
        '18
        dt.Columns.Add(New DataColumn("PriorBonusYear", System.Type.GetType("System.String")))
        '19
        dt.Columns.Add(New DataColumn("WasEmployeeAnOfficerAtEndOfBonusYear", System.Type.GetType("System.String")))
        '20
        dt.Columns.Add(New DataColumn("TaxWithheldFrBonus", System.Type.GetType("System.String")))
        '21
        dt.Columns.Add(New DataColumn("BonusGhsWithheldOfficers", System.Type.GetType("System.String")))
        '22
        dt.Columns.Add(New DataColumn("GhsWithheldFromEmployeeBonus", System.Type.GetType("System.String")))
        '23
        dt.Columns.Add(New DataColumn("BonusGhsEmployersContribution", System.Type.GetType("System.String")))
        '24
        dt.Columns.Add(New DataColumn("PensionableBenefitsContribution", System.Type.GetType("System.String")))
        '25
        dt.Columns.Add(New DataColumn("EmpCode", System.Type.GetType("System.String")))
        '26
        dt.Columns.Add(New DataColumn("LWBPen", System.Type.GetType("System.String")))


        Dim SIPeriod As cPrSsSocialInsPeriods
        SIPeriod = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Me.txtTaxMonth.Text = SIPeriod.DescriptionL

        DsTax = Global1.Business.REPORT_IR61_PerEmployee(PerGroup, SIPeriod)
        DsTaxable = Global1.Business.REPORT_IR61_GetTaxableIncome_PerEmployee(PerGroup, SIPeriod)
        DsDED = Global1.Business.REPORT_IR61_Gesy_DEDUCTION_PerEmployee(PerGroup, SIPeriod)
        DsCON = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_PerEmployee(PerGroup, SIPeriod)
        DsCONPen = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_LWBPen_PerEmployee(PerGroup, SIPeriod)
        DsCONDirector = Global1.Business.REPORT_IR61_Gesy_CONTRIBUTION_Directors_PerEmployee(PerGroup, SIPeriod)
        DsDEDDirector = Global1.Business.REPORT_IR61_Gesy_DEDUCTION_Directors_PerEmployee(PerGroup, SIPeriod)


        Dim Total_Emoluments As Double = 0
        Dim Total_TaxWithheldGrossEmoluments As Double = 0
        Dim Total_Pensions As Double = 0
        Dim Total_SocialInsurancePensions As Double = 0
        Dim Total_GrossEmoluments As Double = 0
        Dim Total_BenefitFromRelatedParties As Double = 0
        Dim Total_TaxDeductedFinancialBenefitsRelatedParties As Double = 0
        Dim Total_GhsWithheldPensioners As Double = 0
        Dim Total_GhsWithheldEmployee As Double = 0
        Dim Total_GhsWithheldOfficer As Double = 0
        Dim Total_GhsEmployersContribution As Double = 0
        Dim Total_PriorYearBonusPaid As Double = 0
        Dim Total_TaxWithheldFrBonus As Double = 0
        Dim Total_BonusGhsWithheldOfficers As Double = 0
        Dim Total_GhsWithheldFromEmployeeBonus As Double = 0
        Dim Total_BonusGhsEmployersContribution As Double = 0
        Dim Total_PensionableBenefitsContribution As Double = 0

        Dim R As DataRow

        If CheckDataSet(DsTax) Then
            Dim Code As String = ""
            Dim Fname As String = ""
            Dim LName As String = ""
            Dim TIC As String = ""
            Dim StartDate As String = ""
            Dim EndDate As String = ""
            Dim IsDirector As String = ""
            Dim IsLWBPen As Double = 0
            Dim TaxValue As Double = 0
            Dim SIPension As Double = 0


            Ds.Tables.Add(dt)

            For i = 0 To DsTax.Tables(0).Rows.Count - 1

                R = dt.NewRow
                Code = DbNullToString(DsTax.Tables(0).Rows(i).Item(0))
                Fname = DbNullToString(DsTax.Tables(0).Rows(i).Item(1))
                LName = DbNullToString(DsTax.Tables(0).Rows(i).Item(2))
                TIC = DbNullToString(DsTax.Tables(0).Rows(i).Item(3))
                StartDate = DbNullToString(DsTax.Tables(0).Rows(i).Item(4))
                EndDate = DbNullToString(DsTax.Tables(0).Rows(i).Item(5))
                IsDirector = DbNullToString(DsTax.Tables(0).Rows(i).Item(6))
                IsLWBPen = DbNullToString(DsTax.Tables(0).Rows(i).Item(7))
                TaxValue = DbNullToDouble(DsTax.Tables(0).Rows(i).Item(8))
                SIPension = DbNullToDouble(DsTax.Tables(0).Rows(i).Item(9))

                R(COLx_EmpCode) = Code
                R(COLx_TaxpayerNumber) = TIC
                R(COLx_Name) = LName & " " & Fname
                R(COLx_EmployeeStartDate) = StartDate
                R(COLx_EmploymentEndDate) = EndDate
                R(COLx_IsEmployeeOfficer) = IsDirector
                R(COLx_LWBPen) = IsLWBPen

                R(COLx_TaxWithheldGrossEmoluments) = TaxValue



                R(COLx_Pensions) = "0,00"
                R(COLx_SocialInsurancePensions) = SIPension
                R(COLx_GrossEmoluments) = "0,00"
                R(COLx_BenefitFromRelatedParties) = "0,00"

                R(COLx_TaxDeductedFinancialBenefitsRelatedParties) = "0,00"
                R(COLx_GhsWithheldPensioners) = "0,00"
                R(COLx_GhsWithheldEmployee) = "0,00"
                R(COLx_GhsWithheldOfficer) = "0,00"
                R(COLx_GhsEmployersContribution) = "0,00"

                R(COLx_IsBonusReceivedThisMonthForPreviousYear) = "0"
                R(COLx_PriorYearBonusPaid) = "0,00"
                R(COLx_PriorBonusYear) = "0"
                R(COLx_WasEmployeeAnOfficerAtEndOfBonusYear) = "0"
                R(COLx_TaxWithheldFrBonus) = "0,00"
                R(COLx_BonusGhsWithheldOfficers) = "0,00"
                R(COLx_GhsWithheldFromEmployeeBonus) = "0,00"
                R(COLx_BonusGhsEmployersContribution) = "0,00"
                R(COLx_PensionableBenefitsContribution) = "0,00"

                dt.Rows.Add(R)

            Next
            Dim TotalRows As Integer = 0
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                TotalRows = TotalRows + 1
                Code = DbNullToString(Ds.Tables(0).Rows(i).Item(COLx_EmpCode))
                Dim k As Integer
                For k = 0 To DsTaxable.Tables(0).Rows.Count - 1
                    Dim tCode As String
                    tCode = DbNullToString(DsTaxable.Tables(0).Rows(k).Item(0))
                    If Code = tCode Then
                        Ds.Tables(0).Rows(i).Item(COLx_Emoluments) = DbNullToDouble(DbNullToString(DsTaxable.Tables(0).Rows(k).Item(1)))
                        Exit For
                    End If
                Next
                For k = 0 To DsDED.Tables(0).Rows.Count - 1
                    Dim tCode As String
                    tCode = DbNullToString(DsDED.Tables(0).Rows(k).Item(0))
                    If Code = tCode Then
                        Ds.Tables(0).Rows(i).Item(COLx_GhsWithheldEmployee) = DbNullToDouble(DbNullToString(DsDED.Tables(0).Rows(k).Item(1)))
                        Exit For
                    End If
                Next
                For k = 0 To DsCON.Tables(0).Rows.Count - 1
                    Dim tCode As String
                    tCode = DbNullToString(DsCON.Tables(0).Rows(k).Item(0))
                    If Code = tCode Then
                        Ds.Tables(0).Rows(i).Item(COLx_GhsEmployersContribution) = DbNullToDouble(DbNullToString(DsCON.Tables(0).Rows(k).Item(1)))
                        Exit For
                    End If
                Next
                For k = 0 To DsCONPen.Tables(0).Rows.Count - 1
                    Dim tCode As String
                    tCode = DbNullToString(DsCONPen.Tables(0).Rows(k).Item(0))
                    If Code = tCode Then
                        Ds.Tables(0).Rows(i).Item(COLx_GhsWithheldPensioners) = DbNullToDouble(DbNullToString(DsCONPen.Tables(0).Rows(k).Item(1)))
                        Exit For
                    End If
                Next
                For k = 0 To DsDEDDirector.Tables(0).Rows.Count - 1
                    Dim tCode As String
                    tCode = DbNullToString(DsDEDDirector.Tables(0).Rows(k).Item(0))
                    If Code = tCode Then
                        Ds.Tables(0).Rows(i).Item(COLx_GhsWithheldOfficer) = DbNullToDouble(DbNullToString(DsDEDDirector.Tables(0).Rows(k).Item(1)))
                        Exit For
                    End If
                Next
                For k = 0 To DsCONDirector.Tables(0).Rows.Count - 1
                    Dim tCode As String
                    tCode = DbNullToString(DsCONDirector.Tables(0).Rows(k).Item(0))
                    If Code = tCode Then
                        Ds.Tables(0).Rows(i).Item(COLx_GhsEmployersContribution) = DbNullToDouble(DbNullToString(DsCONDirector.Tables(0).Rows(k).Item(1)))
                        Exit For
                    End If
                Next
                Ds.Tables(0).Rows(i).Item(COLx_GrossEmoluments) = DbNullToDouble(Ds.Tables(0).Rows(i).Item(COLx_Emoluments)) + DbNullToDouble(Ds.Tables(0).Rows(i).Item(COLx_Pensions))

            Next

            ''''''' Calculate Totals '''''''''''
            '--------------------------------------------------------------------------------------------------------------------------------
            Dim j As Integer

            For j = 0 To Ds.Tables(0).Rows.Count - 1
                Total_Emoluments = Total_Emoluments + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_Emoluments))
                Total_TaxWithheldGrossEmoluments = Total_TaxWithheldGrossEmoluments + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_TaxWithheldGrossEmoluments))
                Total_Pensions = Total_Pensions + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_Pensions))
                Total_SocialInsurancePensions = Total_SocialInsurancePensions + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_SocialInsurancePensions))
                Total_GrossEmoluments = Total_GrossEmoluments + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_GrossEmoluments))
                Total_BenefitFromRelatedParties = Total_BenefitFromRelatedParties + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_BenefitFromRelatedParties))
                Total_TaxDeductedFinancialBenefitsRelatedParties = Total_TaxDeductedFinancialBenefitsRelatedParties + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_TaxDeductedFinancialBenefitsRelatedParties))
                Total_GhsWithheldPensioners = Total_GhsWithheldPensioners + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_GhsWithheldPensioners))
                Total_GhsWithheldEmployee = Total_GhsWithheldEmployee + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_GhsWithheldEmployee))
                Total_GhsWithheldOfficer = Total_GhsWithheldOfficer + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_GhsWithheldOfficer))
                Total_GhsEmployersContribution = Total_GhsEmployersContribution + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_GhsEmployersContribution))
                Total_PriorYearBonusPaid = Total_PriorYearBonusPaid + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_PriorYearBonusPaid))
                Total_TaxWithheldFrBonus = Total_TaxWithheldFrBonus + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_TaxWithheldFrBonus))
                Total_BonusGhsWithheldOfficers = Total_BonusGhsWithheldOfficers + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_BonusGhsWithheldOfficers))
                Total_GhsWithheldFromEmployeeBonus = Total_GhsWithheldFromEmployeeBonus + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_GhsWithheldFromEmployeeBonus))
                Total_BonusGhsEmployersContribution = Total_BonusGhsEmployersContribution + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_BonusGhsEmployersContribution))
                Total_PensionableBenefitsContribution = Total_PensionableBenefitsContribution + DbNullToDouble(Ds.Tables(0).Rows(j).Item(COLx_PensionableBenefitsContribution))
            Next


            '--------------------------------------------------------------------------------------------------------------------------------
            'AddTotals
            '-------------------------------------------------------------------------------------

            R = dt.NewRow
            Code = ""
            Fname = "Total"
            LName = TotalRows
            TIC = ""
            StartDate = ""
            EndDate = ""
            IsDirector = ""
            IsLWBPen = 0
            TaxValue = 0
            R(COLx_EmpCode) = Code
            R(COLx_TaxpayerNumber) = TIC
            R(COLx_Name) = LName & " " & Fname
            R(COLx_EmployeeStartDate) = StartDate
            R(COLx_EmploymentEndDate) = EndDate
            R(COLx_IsEmployeeOfficer) = IsDirector
            R(COLx_LWBPen) = IsLWBPen

            R(COLx_Emoluments) = Total_Emoluments
            R(COLx_TaxWithheldGrossEmoluments) = Total_TaxWithheldGrossEmoluments
            R(COLx_Pensions) = Total_Pensions
            R(COLx_SocialInsurancePensions) = Total_SocialInsurancePensions
            R(COLx_GrossEmoluments) = Total_GrossEmoluments
            R(COLx_BenefitFromRelatedParties) = Total_BenefitFromRelatedParties
            R(COLx_TaxDeductedFinancialBenefitsRelatedParties) = Total_TaxDeductedFinancialBenefitsRelatedParties
            R(COLx_GhsWithheldPensioners) = Total_GhsWithheldPensioners
            R(COLx_GhsWithheldEmployee) = Total_GhsWithheldEmployee
            R(COLx_GhsWithheldOfficer) = Total_GhsWithheldOfficer
            R(COLx_GhsEmployersContribution) = Total_GhsEmployersContribution
            R(COLx_PriorYearBonusPaid) = Total_PriorYearBonusPaid
            R(COLx_TaxWithheldFrBonus) = Total_TaxWithheldFrBonus
            R(COLx_BonusGhsWithheldOfficers) = Total_BonusGhsWithheldOfficers
            R(COLx_GhsWithheldFromEmployeeBonus) = Total_GhsWithheldFromEmployeeBonus
            R(COLx_BonusGhsEmployersContribution) = Total_BonusGhsEmployersContribution
            R(COLx_PensionableBenefitsContribution) = Total_PensionableBenefitsContribution
            dt.Rows.Add(R)



            '-------------------------------------------------------------------------------------
            If ShowExcel Then
                LoadDataSetToExcel(Ds)
            End If
            PrepareXMLFiletoTAX(Ds)
            Me.Cursor = Cursors.Default
            MsgBox("File is Created " & GLBDisplayFilename, MsgBoxStyle.Information)
        Else
            MsgBox("No Results found", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub PrepareXMLFiletoTAX(ds As DataSet)
        Dim TemGrp As New cPrMsTemplateGroup(TempGroupCode)
        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)
        Dim Month As String
        glbDisplayFilename = ""

        Dim TotalGrossEmoluments As Double = 0
        Dim Total_TaxWithheld As Double = 0
        Dim Total_TaxWithheldFromBonus As Double = 0
        Dim Total_TotalTaxWithheld As Double = 0
        Dim Total_TotalTaxdeducted As Double = 0
        Dim Total_GHSWithheldPensioners As Double = 0
        Dim Total_GHSWithheldOfficers As Double = 0
        Dim Total_GHSWithheldEmployees As Double = 0
        Dim Total_GHSEmployerContribution As Double = 0
        Dim Total_ContributionPensionableBenefits As Double = 0

        Dim Per As New cPrSsSocialInsPeriods
        Per = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)

        Select Case Per.Code
            Case "01"
                Month = "Jan"
            Case "02"
                Month = "Feb"
            Case "03"
                Month = "Mar"
            Case "04"
                Month = "Apr"
            Case "05"
                Month = "May"
            Case "06"
                Month = "Jun"
            Case "07"
                Month = "Jul"
            Case "08"
                Month = "Aug"
            Case "09"
                Month = "Sep"
            Case "10"
                Month = "Oct"
            Case "11"
                Month = "Nov"
            Case "12"
                Month = "Dec"
        End Select

        InitFile = True
        Dim S As String
        S = "<PayeReturn>"
        WriteToTAXFile(S, Company)

        S = "<PayeReturnHeader>"
        WriteToTAXFile(S, Company)

        S = "<TaxpayerNumber>" & Company.TIC & "</TaxpayerNumber>"
        WriteToTAXFile(S, Company)

        S = "<Year>" & PerGroup.Year & "</Year>"
        WriteToTAXFile(S, Company)

        S = "<Period>" & Month & "</Period>"
        WriteToTAXFile(S, Company)

        S = "</PayeReturnHeader>"
        WriteToTAXFile(S, Company)

        S = "<PayeReturnBody>"
        WriteToTAXFile(S, Company)
        If PARAM_PublicSector = "No" Then
            S = "<PayeEmployerType>" & "Private Sector" & "</PayeEmployerType>"
        Else
            S = "<PayeEmployerType>" & "Broader Public Service" & "</PayeEmployerType>"
        End If
        'S = "<PayeEmployerType>" & "Public Sector" & "</PayeEmployerType>"
        WriteToTAXFile(S, Company)

        S = "<PayeEmployees>"
        WriteToTAXFile(S, Company)
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 2

            S = "<PayeEmployee>"
            WriteToTAXFile(S, Company)

            S = "<TaxpayerNumber>" & DbNullToString(ds.Tables(0).Rows(i).Item(COLx_TaxpayerNumber)) & "</TaxpayerNumber>"
            WriteToTAXFile(S, Company)

            S = "<Name>" & DbNullToString(ds.Tables(0).Rows(i).Item(COLx_Name)) & "</Name>"
            WriteToTAXFile(S, Company)

            Dim Dstart As Date
            Dstart = CDate(DbNullToString(ds.Tables(0).Rows(i).Item(COLx_EmployeeStartDate)))

            If Dstart.Month = Per.Code And Dstart.Year = PerGroup.Year Then
                S = "<EmployeeStartDate>" & Format(Dstart, "yyyy-MM-dd") & "</EmployeeStartDate>"
                WriteToTAXFile(S, Company)
            End If

            If DbNullToString(ds.Tables(0).Rows(i).Item(COLx_EmploymentEndDate)) <> "" Then
                Dim DEnd As Date
                DEnd = CDate(DbNullToString(ds.Tables(0).Rows(i).Item(COLx_EmploymentEndDate)))
                If DEnd.Month = Per.Code And DEnd.Year = PerGroup.Year Then
                    S = "<EmploymentEndDate>" & Format(DEnd, "yyyy-MM-dd") & "</EmploymentEndDate>"
                    WriteToTAXFile(S, Company)
                End If
            End If


            Dim N As Double
            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_Emoluments))
            S = "<Emoluments>" & MyFormat(N) & "</Emoluments>"

            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_Pensions))
            S = "<Pensions>" & MyFormat(N) & "</Pensions>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_SocialInsurancePensions))
            S = "<SocialInsurancePensions>" & MyFormat(N) & "</SocialInsurancePensions>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_GrossEmoluments))
            S = "<GrossEmoluments>" & MyFormat(N) & "</GrossEmoluments>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_BenefitFromRelatedParties))
            S = "<BenefitFromRelatedParties>" & MyFormat(N) & "</BenefitFromRelatedParties>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_TaxWithheldGrossEmoluments))
            S = "<TaxWithheldGrossEmoluments>" & MyFormat(N) & "</TaxWithheldGrossEmoluments>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_TaxDeductedFinancialBenefitsRelatedParties))
            S = "<TaxDeductedFinancialBenefitsRelatedParties>" & MyFormat(N) & "</TaxDeductedFinancialBenefitsRelatedParties>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_GhsWithheldPensioners))
            S = "<GhsWithheldPensioners>" & MyFormat(N) & "</GhsWithheldPensioners>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_GhsWithheldEmployee))
            S = "<GhsWithheldEmployee>" & MyFormat(N) & "</GhsWithheldEmployee>"
            WriteToTAXFile(S, Company)

            S = "<IsEmployeeOfficer>" & DbNullToString(ds.Tables(0).Rows(i).Item(COLx_IsEmployeeOfficer)) & "</IsEmployeeOfficer>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_GhsWithheldOfficer))
            S = "<GhsWithheldOfficer>" & MyFormat(N) & "</GhsWithheldOfficer>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_GhsEmployersContribution))
            S = "<GhsEmployersContribution>" & MyFormat(N) & "</GhsEmployersContribution>"
            WriteToTAXFile(S, Company)

            S = "<IsBonusReceivedThisMonthForPreviousYear>" & DbNullToString(ds.Tables(0).Rows(i).Item(COLx_IsBonusReceivedThisMonthForPreviousYear)) & "</IsBonusReceivedThisMonthForPreviousYear>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_PriorYearBonusPaid))
            S = "<PriorYearBonusPaid>" & MyFormat(N) & "</PriorYearBonusPaid>"
            WriteToTAXFile(S, Company)

            S = "<PriorBonusYear>" & DbNullToString(ds.Tables(0).Rows(i).Item(COLx_PriorBonusYear)) & "</PriorBonusYear>"
            WriteToTAXFile(S, Company)

            S = "<WasEmployeeAnOfficerAtEndOfBonusYear>" & DbNullToString(ds.Tables(0).Rows(i).Item(COLx_WasEmployeeAnOfficerAtEndOfBonusYear)) & "</WasEmployeeAnOfficerAtEndOfBonusYear>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_TaxWithheldFrBonus))
            S = "<TaxWithheldFrBonus>" & MyFormat(N) & "</TaxWithheldFrBonus>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_BonusGhsWithheldOfficers))
            S = "<BonusGhsWithheldOfficers>" & MyFormat(N) & "</BonusGhsWithheldOfficers>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_GhsWithheldFromEmployeeBonus))
            S = "<GhsWithheldFromEmployeeBonus>" & MyFormat(N) & "</GhsWithheldFromEmployeeBonus>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_BonusGhsEmployersContribution))
            S = "<BonusGhsEmployersContribution>" & MyFormat(N) & "</BonusGhsEmployersContribution>"
            WriteToTAXFile(S, Company)

            N = DbNullToDouble(ds.Tables(0).Rows(i).Item(COLx_PensionableBenefitsContribution))
            S = "<PensionableBenefitsContribution>" & MyFormat(N) & "</PensionableBenefitsContribution>"
            WriteToTAXFile(S, Company)

            S = "</PayeEmployee>"
            WriteToTAXFile(S, Company)


        Next
        S = "</PayeEmployees>"
        WriteToTAXFile(S, Company)
        Dim LR As Integer = ds.Tables(0).Rows.Count - 1
        Dim T As Double = 0
        Dim T2 As Double = 0
        Dim T3 As Double = 0
        Dim T14 As Double = 0
        Dim T21 As Double = 0
        Dim T12 As Double = 0
        Dim T22 As Double = 0
        Dim T15 As Double = 0
        Dim T23 As Double = 0

        '<!-- Q1 Total Gross Emoluments (Sum of all q8) -->
        T = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_GrossEmoluments))
        S = "<TotalGrossEmoluments>" & MyFormat(T) & "</TotalGrossEmoluments>"
        WriteToTAXFile(S, Company)

        '<!-- Q2 Tax Withheld (Sum of all q10) -->
        T2 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_TaxWithheldGrossEmoluments))
        S = "<TaxWithheld>" & MyFormat(T2) & "</TaxWithheld>"
        WriteToTAXFile(S, Company)


        '<!-- Q3 Tax Withheld from Prior Year Bonus (Sum of all q20) -->
        T3 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_TaxWithheldFrBonus))
        S = "<TaxWithheldFromBonus>" & MyFormat(T3) & "</TaxWithheldFromBonus>"
        WriteToTAXFile(S, Company)

        '<TotalTaxWithheld>300,00</TotalTaxWithheld>
        '<!-- Q4 Total Tax Withheld (Q2 + Q3) -->
        T = T2 + T3
        S = "<TotalTaxWithheld>" & MyFormat(T) & "</TotalTaxWithheld>"
        WriteToTAXFile(S, Company)

        '<TotalTaxdeducted>200,00</TotalTaxdeducted>
        '<!-- Q4a Tax deducted for financial benefits of directors Or shareholders Or related parties thereof (Sum of all q10b) -->
        T = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_TaxDeductedFinancialBenefitsRelatedParties))
        S = "<TotalTaxdeducted>" & MyFormat(T) & "</TotalTaxdeducted>"
        WriteToTAXFile(S, Company)

        '<GHSWithheldPensioners>200,00</GHSWithheldPensioners>
        '<!-- Q5 GHS Withheld from pensioners (Sum of all q11) -->
        T = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_GhsWithheldPensioners))
        S = "<GHSWithheldPensioners>" & MyFormat(T) & "</GHSWithheldPensioners>"
        WriteToTAXFile(S, Company)

        '<GHSWithheldOfficers>200,00</GHSWithheldOfficers>
        '<!-- Q6 GHS Withheld from officers (Sum of all q14 + q21) -->
        T14 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_GhsWithheldOfficer))
        T21 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_BonusGhsWithheldOfficers))
        T = T14 + T21
        S = "<GHSWithheldOfficers>" & MyFormat(T) & "</GHSWithheldOfficers>"
        WriteToTAXFile(S, Company)

        '<GHSWithheldEmployees>300,00</GHSWithheldEmployees>
        '<!-- Q7 GHS Withheld from Employee (Sum of all q12 + q22) -->
        T12 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_GhsWithheldEmployee))
        T22 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_GhsWithheldFromEmployeeBonus))
        T = T12 + T22
        S = "<GHSWithheldEmployees>" & MyFormat(T) & "</GHSWithheldEmployees>"
        WriteToTAXFile(S, Company)

        '<GHSEmployerContribution>200,00</GHSEmployerContribution>
        '<!-- Q8 GHS Employer's Contribution (Sum of all q15 + q23) -->
        T15 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_GhsEmployersContribution))
        T23 = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_BonusGhsEmployersContribution))
        T = T15 + T23
        S = "<GHSEmployerContribution>" & MyFormat(T) & "</GHSEmployerContribution>"
        WriteToTAXFile(S, Company)

        '<ContributionPensionableBenefits>100,00</ContributionPensionableBenefits>
        '<!-- Q9 Contribution towards pensionable benefits (3%) (Sum of all q24) -->
        T = DbNullToDouble(ds.Tables(0).Rows(LR).Item(COLx_PensionableBenefitsContribution))
        S = "<ContributionPensionableBenefits>" & MyFormat(T) & "</ContributionPensionableBenefits>"
        WriteToTAXFile(S, Company)

        S = "</PayeReturnBody>"
        WriteToTAXFile(S, Company)
        S = "</PayeReturn>"
        WriteToTAXFile(S, Company)

    End Sub
    Private Function MyFormat(N As Double) As String
        Dim S As String
        S = Format(N, "0.00")
        S = Replace(S, ".", ",")
        Return S
    End Function

    Private Sub LoadDataSetToExcel(ds As DataSet)

        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader


        HeaderStr.Add("TaxpayerNumber") ' 0
        HeaderStr.Add("Name") ' 1
        HeaderStr.Add("EmployeeStartDate") ' 2
        HeaderStr.Add("EmploymentEndDate") ' 3
        HeaderStr.Add("Emoluments") ' 4
        HeaderStr.Add("Pensions") ' 5
        HeaderStr.Add("SocialInsurancePensions") ' 6
        HeaderStr.Add("GrossEmoluments") ' 7
        HeaderStr.Add("BenefitFromRelatedParties") ' 8
        HeaderStr.Add("TaxWithheldGrossEmoluments") ' 9
        HeaderStr.Add("TaxDeductedFinancialBenefitsRelatedParties") ' 10
        HeaderStr.Add("GhsWithheldPensioners") ' 11
        HeaderStr.Add("GhsWithheldEmployee") ' 12
        HeaderStr.Add("IsEmployeeOfficer") ' 13
        HeaderStr.Add("GhsWithheldOfficer") ' 14
        HeaderStr.Add("GhsEmployersContribution") ' 15
        HeaderStr.Add("IsBonusReceivedThisMonthForPreviousYear") ' 16
        HeaderStr.Add("PriorYearBonusPaid") ' 17
        HeaderStr.Add("PriorBonusYear") ' 18
        HeaderStr.Add("WasEmployeeAnOfficerAtEndOfBonusYear") ' 19
        HeaderStr.Add("TaxWithheldFrBonus") ' 20
        HeaderStr.Add("BonusGhsWithheldOfficers") ' 21
        HeaderStr.Add("GhsWithheldFromEmployeeBonus") ' 22
        HeaderStr.Add("BonusGhsEmployersContribution") ' 23
        HeaderStr.Add("PensionableBenefitsContribution") ' 24
        HeaderStr.Add("EmpCode") ' 25
        HeaderStr.Add("LWBPen") ' 26

        HeaderSize.Add(16)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(6)
        HeaderSize.Add(1)
        HeaderSize.Add(4)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(60)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(1)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(50)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(10)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(2)
        HeaderSize.Add(12)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(3)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(30)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(4)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub

    Private Function WriteToTAXFile(ByVal Line As String, ByVal Company As cAdMsCompany) As Boolean
        Dim Flag As Boolean = True

        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = TAXFileDir & "\" & Company.NameShort & "_Tax.xml"
            glbDisplayFilename = FileName
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


End Class