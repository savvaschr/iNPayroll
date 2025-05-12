Public Class FrmRptSIContributions
    Dim Loading As Boolean = False
    Public File As Boolean = True
    Dim PerGroup As cPrMsPeriodGroups
    Dim TemGrp As cPrMsTemplateGroup
    Dim InitFile As Boolean
    Dim InitFile2 As Boolean
    Dim SIFileDir As String = ""
    Public GlbAbsentReason As String = ""
    Dim DsPeriodGroups As DataSet
    'Dim GLBCurrentPeriod As cPrMsPeriodCodes
    Private Sub FrmRptSIContributions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CmbSIPeriod.Enabled = True
        Me.ComboPeriod.Enabled = False
        LoadCombos()

        UpdateMenus()

        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("SIContributions", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            SIFileDir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing SI COntributions File Parameter Section 'SIContributions' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Me.TSBFile.Enabled = False
        End If


        Ds = Global1.Business.GetParameter("SIContributions", "ShowPosition")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Id > 0 Then
                If Par.Value1 = 1 Then
                    PARAM_UsePosition = True
                Else
                    PARAM_UsePosition = False
                End If
            End If
        End If
        Ds = Global1.Business.GetParameter("SIContributions", "CobaltALCode")
        PARAM_CobaltALCode = ""
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Id > 0 Then
                PARAM_CobaltALCode = Par.Value1
            End If
        End If

        Ds = Global1.Business.GetParameter("SIContributions", "BIKWithSCCode")
        PARAM_BIKWithSCCode = ""
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Id > 0 Then
                PARAM_BikWithSCCode = Par.Value1
            End If
        End If




    End Sub
    Private Sub LoadCombos()
        LoadPeriodGroup()
        LoadSIPeriods()
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

        Dim ShowAllYears As Boolean
        If CBShowAllYears.CheckState = CheckState.Checked Then
            ShowAllYears = True
        Else
            ShowAllYears = False
        End If


        DsPeriodGroups = Global1.Business.GetAllPrMsPeriodGroupsOfUser(Global1.UserName, ShowAllYears, Global1.GLBCurrentYear)
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
            Me.LoadPeriods(CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups).Code)

        End With
        Loading = False
    End Sub
    'Private Sub LoadPeriods()
    '    Loading = True
    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PerGroup.code)
    '    With Me.CmbPeriod
    '        .BeginUpdate()
    '        .Items.Clear()
    '        If CheckDataSet(ds) Then
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                Dim P As New cPrMsPeriodCodes(ds.Tables(0).Rows(i))
    '                .Items.Add(P)
    '            Next
    '        End If
    '        .EndUpdate()
    '        .SelectedIndex = 0
    '    End With
    '    Loading = False
    'End Sub
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
        Loading = False
    End Sub
    Private Sub LoadPeriods(ByVal PeriodGroupCode As String)
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(PeriodGroupCode)
        With Me.ComboPeriod
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


    Private Sub CmbPeriodGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPeriodGroups.SelectedIndexChanged
        Try
            PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            TemGrp = New cPrMsTemplateGroup(PerGroup.TemGrpCode)
            Me.TextBox1.Text = TemGrp.Code & " - " & TemGrp.DescriptionL
            Me.LoadPeriods(PerGroup.Code)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub TSBReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowThereport(False, False, False)
    End Sub
    Private Sub ShowThereport(ByVal ToPrinter As Boolean, ByVal NewEmployeesStatement As Boolean, ByVal OnlywithTotals As Boolean)
        If Me.CBSwitchToPeriod.CheckState = CheckState.Checked Then
            Me.PeriodReport(ToPrinter, NewEmployeesStatement, OnlywithTotals)
        Else
            SIPeriodReport(ToPrinter, NewEmployeesStatement, OnlywithTotals)
        End If
    End Sub

    Private Sub SIPeriodReport(ByVal ToPrinter As Boolean, ByVal NewEmployeesStatement As Boolean, ByVal OnlyWithTotals As Boolean)
        Dim DsPar As DataSet
        Dim ReportName As String
        If NewEmployeesStatement Then
            ReportName = "SINewEmpReport.rpt"
        Else
            ReportName = "SIContributions.rpt"
            DsPar = Global1.Business.GetParameter("SI", "Report")
            If CheckDataSet(DsPar) Then
                Dim Par As New cPrSsParameters(DsPar.Tables(0).Rows(0))
                ReportName = Par.Value1
            End If
            If OnlyWithTotals Then
                ReportName = "SIContributionsTotals.rpt"
            End If
        End If



        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim SIPer As New cPrSsSocialInsPeriods
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPer As DataSet

        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)

        DSPer = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)

        If CheckDataSet(DSPer) Then
            Dim Per As New cPrMsPeriodCodes
            Dim ds As DataSet
            Per = New cPrMsPeriodCodes(DSPer.Tables(0).Rows(0))
            Dim k As Integer
            Dim Flag As Boolean = False
            '*************************************************************************
            'Code to Be Revisited for other Social Insurance Categories in the Future
            '*************************************************************************
            Dim J As Integer
            Dim Com As New cAdMsCompany(TemGrp.CompanyCode)
            Dim Ar(4) As String
            Dim CompanySINo As String = ""
            Ar(0) = Com.SIRegNo
            Ar(1) = Com.SI2
            Ar(2) = Com.SI3
            Ar(3) = Com.SI4
            Ar(4) = Com.SI5
            For J = 0 To Ar.Length - 1
                CompanySINo = ""
                CompanySINo = Ar(J)
                If CompanySINo <> "" Then
                    For k = 1 To 3
                        Dim Sicat As String
                        If k = 1 Then
                            Sicat = "M1"
                        End If
                        If k = 2 Then
                            Sicat = "M2"
                        End If
                        If k = 3 Then
                            Sicat = "KL"
                        End If
                        Dim SocInsCat As New cPrAnSocialInsCategories(Sicat)

                        ds = Global1.Business.REPORT_PrepareSIContributions(Per, TemGrp, SocInsCat, SIPer, PerGroup, CompanySINo)
                        '.WriteSchemaWithXmlTextWriter(ds, "C:\Users\Administrator\Documents\Visual Studio 2005\XML\SIContribution")
                        '---------------------------------------C:\Users\Administrator\Documents\Visual Studio 2005\XML\SIContribution.xsd
                        Me.Cursor = Cursors.Default

                        If CheckDataSet(ds) Then
                            Flag = True

                            Utils.ShowReport(ReportName, ds, FrmReport, "", ToPrinter)
                            If Not NewEmployeesStatement Then
                                If Me.CBShowNewEmployeesReport.Checked Then
                                    Utils.ShowReport("SINewEmp.rpt", ds, FrmReport, "", ToPrinter)
                                End If
                            End If
                                '     Utils.ShowReport("FormalSI.rpt", ds, FrmReport, "", False)
                            Else
                            If Not Flag Then
                                MsgBox("No records found to print.", MsgBoxStyle.Information)
                            End If
                        End If

                    Next
                End If
            Next
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PeriodReport(ByVal ToPrinter As Boolean, ByVal NewEmployeesStatement As Boolean, ByVal OnlyWithTotals As Boolean)
        Dim DsPar As DataSet
        Dim ReportName As String



        If NewEmployeesStatement Then
            ReportName = "SINewEmpReport.rpt"
        Else
            ReportName = "SIContributions.rpt"
            DsPar = Global1.Business.GetParameter("SI", "Report")
            If CheckDataSet(DsPar) Then
                Dim Par As New cPrSsParameters(DsPar.Tables(0).Rows(0))
                ReportName = Par.Value1
            End If
            If OnlyWithTotals Then
                ReportName = "SIContributionsTotals.rpt"
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim SIPer As New cPrSsSocialInsPeriods
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPer As DataSet

        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)




        Dim Per As New cPrMsPeriodCodes
        Dim ds As DataSet
        Per = CType(Me.ComboPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim k As Integer
        Dim Flag As Boolean = False
        '*************************************************************************
        'Code to Be Revisited for other Social Insurance Categories in the Future
        '*************************************************************************
        Dim J As Integer
        Dim Com As New cAdMsCompany(TemGrp.CompanyCode)
        Dim Ar(4) As String
        Dim CompanySINo As String = ""
        Ar(0) = Com.SIRegNo
        Ar(1) = Com.SI2
        Ar(2) = Com.SI3
        Ar(3) = Com.SI4
        Ar(4) = Com.SI5
        For J = 0 To Ar.Length - 1
            CompanySINo = ""
            CompanySINo = Ar(J)
            If CompanySINo <> "" Then
                For k = 1 To 3
                    Dim Sicat As String
                    If k = 1 Then
                        Sicat = "M1"
                    End If
                    If k = 2 Then
                        Sicat = "M2"
                    End If
                    If k = 3 Then
                        Sicat = "KL"
                    End If

                    Dim SocInsCat As New cPrAnSocialInsCategories(Sicat)
                    ds = Global1.Business.REPORT_PrepareSIContributionsPERPeriod(Per, TemGrp, SocInsCat, PerGroup, CompanySINo)
                    'Utils.WriteSchemaWithXmlTextWriter(ds, "C:\Documents and Settings\user\My Documents\Visual Studio 2005\Projects\NodalPay\NodalPay\XML\SIContribution")
                    Me.Cursor = Cursors.Default
                    If CheckDataSet(ds) Then
                        Flag = True
                        Utils.ShowReport(ReportName, ds, FrmReport, "", ToPrinter)
                        If Not NewEmployeesStatement Then
                            If Me.CBShowNewEmployeesReport.Checked Then
                                Utils.ShowReport("SINewEmp.rpt", ds, FrmReport, "", ToPrinter)
                            End If
                        End If
                            '     Utils.ShowReport("FormalSI.rpt", ds, FrmReport, "", False)
                        Else
                        If Not Flag Then
                            MsgBox("No records found to print.", MsgBoxStyle.Information)
                        End If
                    End If

                Next
            End If
        Next

    End Sub



    Private Sub TSBFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrepareSIFile()
    End Sub
    Private Sub PrepareSIFile()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Replace(Format(Now.Date, "dd/MM/yyyy"), "-", "/")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGESYable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGESYable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0
        Dim total02 As Integer


        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes


                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))


                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGESYable = 0
                SemiTotalEmployees = 0
                StatusPrep = True
                Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
                DsEmp = Global1.Business.SI_File_GetEmployees(TemGrp, Per, SocCat.Code, StatusPrep)
                If Not StatusPrep Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckDataSet(DsEmp) Then
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------
                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & Per.PayCat_Code

                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Else
                        Dim MM As Integer
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------

                    '--------------------------------------------------
                    '03 NEW EMPLOYEES
                    '--------------------------------------------------
                    If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            If Per.PayCat_Code = "K" Then
                                Dim EmpCode As String
                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                    NumberOfNew = NumberOfNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                        If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Replace(Format(Emp.BirthDate, "dd/MM/yyyy"), "-", "/")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Replace(Format(Emp.StartDate, "dd/MM/yyyy"), "-", "/")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                                End If
                        Next
                    End If
                    '--------------------------------------------------
                    'END OF 03
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        SemiTotalEmployees = SemiTotalEmployees + 1
                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String


                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)


                        DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TempTempGroup, Per, EmpCode)
                        If CheckDataSet(DsGrossInsurable) Then
                            GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                            InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                            GESYableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                        End If
                        ''''' NEW FIX FOR AVRAAMIDES '''''
                        Dim DsSLeave As DataSet
                        Dim SIvalue As Double = 0
                        DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        If CheckDataSet(DsSLeave) Then
                            For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                    SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''''''''''''''


                        GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)

                        If GrossEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        GE = Math.Abs(GrossEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                        SemitotalGE = SemitotalGE + GrossEarnings



                        If GrossEarnings = 0 Then
                            MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                            Dim F As New FrmSelectLeaveReason
                            F.Owner = Me
                            F.ShowDialog()
                            AbsentReason = Me.GlbAbsentReason
                        Else
                            AbsentReason = " "
                        End If


                        GESYableEarnings = RoundMe3(GESYableEarnings - SIvalue, 2)
                        GESYableEarnings = Utils.RoundMe3(GESYableEarnings, 0)
                        If Math.Abs(GESYableEarnings - GrossEarnings) = 1 Then
                            GESYableEarnings = GrossEarnings
                        End If
                        SemitotalGESYable = SemitotalGESYable + GESYableEarnings

                        Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                        If GESYableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                        InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)
                        InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)

                        If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                            InsurableEarnings = GrossEarnings
                        End If

                        SemiTotalIE = SemiTotalIE + InsurableEarnings


                        IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                        If InsurableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                        'SI ***********************************
                        'Dim DsSLeave As DataSet
                        'Dim SIvalue As Double = 0
                        'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSLeave) Then
                        '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                        '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If
                        'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSi) Then
                        '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                        '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If

                        SI = Format(SIvalue, "0.00").ToString.Split(".")
                        Dim S As String
                        S = SI(0) & SI(1)
                        SemitotalSI = SemitotalSI + CInt(S)

                        S = "+" & S.PadLeft(12, "0")



                        Str04 = Str04 & S
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Replace(Format(CDate(Emp.TerminateDate), "dd/MM/yyyy"), "-", "/")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                        Str04 = Str04 & TermDate
                        Str04 = Str04 & 1
                        Me.WriteToSIFile(Str04, Company)
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGESYable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                End If
            Next
        Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")



        If GRAND_SemiTotalGESYable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGESYable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub PrepareSIFile_WITH_N()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Replace(Format(Now.Date, "dd/MM/yyyy"), "-", "/")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGESYable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGESYable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0

        Dim total02 As Integer
        Dim total_N_02 As Integer
        Dim total_X_02 As Integer

        Dim AlValueIsBK As Boolean = False

        If PARAM_CobaltALCode <> "" Then
            Dim Ern As New cPrMsEarningCodes(PARAM_CobaltALCode)
            If Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Then
                AlValueIsBK = True
            End If
        End If

        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            Dim Create_N_Record As Boolean = False
            Dim Create_X_Record As Boolean = False

            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes


                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))


                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGESYable = 0
                SemiTotalEmployees = 0
                StatusPrep = True
                Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
                DsEmp = Global1.Business.SI_File_GetEmployees(TemGrp, Per, SocCat.Code, StatusPrep)
                If Not StatusPrep Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckDataSet(DsEmp) Then
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------
                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & Per.PayCat_Code

                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Else
                        Dim MM As Integer
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------

                    '--------------------------------------------------
                    '03 NEW EMPLOYEES
                    '--------------------------------------------------
                    If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            If Per.PayCat_Code = "K" Then
                                Dim EmpCode As String
                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                    NumberOfNew = NumberOfNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                    If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Replace(Format(Emp.BirthDate, "dd/MM/yyyy"), "-", "/")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Replace(Format(Emp.StartDate, "dd/MM/yyyy"), "-", "/")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                                End If
                        Next
                    End If
                    '--------------------------------------------------
                    'END OF 03
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        SemiTotalEmployees = SemiTotalEmployees + 1
                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String



                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                        Dim ALValue As Double = 0



                        If PARAM_CobaltALCode <> "" Then
                            ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, Per, EmpCode)
                            If ALValue <> 0 Then
                                Create_N_Record = True
                                total_N_02 = total_N_02 + 1
                            End If
                        End If
                        Dim BIKWithSCValue As Double = 0
                        If PARAM_BIKWithSCCode <> "" Then
                            BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, Per, EmpCode)
                            If BIKWithSCValue <> 0 Then
                                Create_X_Record = True
                                total_X_02 = total_X_02 + 1
                            End If
                        End If

                        DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TempTempGroup, Per, EmpCode)

                        If CheckDataSet(DsGrossInsurable) Then
                            'If AlValueIsBK Then
                            'GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                            'Else
                            GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0)) - ALValue
                            'End If
                            InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                            GESYableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                        End If
                        ''''' NEW FIX FOR AVRAAMIDES '''''
                        Dim DsSLeave As DataSet
                        Dim SIvalue As Double = 0
                        DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        If CheckDataSet(DsSLeave) Then
                            For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                    SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''''''''''''''


                        GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)

                        If GrossEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        GE = Math.Abs(GrossEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                        SemitotalGE = SemitotalGE + GrossEarnings



                        If GrossEarnings = 0 Then
                            MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                            Dim F As New FrmSelectLeaveReason
                            F.Owner = Me
                            F.ShowDialog()
                            AbsentReason = Me.GlbAbsentReason
                        Else
                            AbsentReason = " "
                        End If


                        GESYableEarnings = RoundMe3(GESYableEarnings - SIvalue, 2)
                        GESYableEarnings = Utils.RoundMe3(GESYableEarnings, 0)
                        If Math.Abs(GESYableEarnings - GrossEarnings) = 1 Then
                            GESYableEarnings = GrossEarnings
                        End If
                        SemitotalGESYable = SemitotalGESYable + GESYableEarnings

                        Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                        If GESYableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                        InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)
                        InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)

                        If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                            InsurableEarnings = GrossEarnings
                        End If

                        SemiTotalIE = SemiTotalIE + InsurableEarnings


                        IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                        If InsurableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                        'SI ***********************************
                        'Dim DsSLeave As DataSet
                        'Dim SIvalue As Double = 0
                        'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSLeave) Then
                        '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                        '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If
                        'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSi) Then
                        '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                        '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If

                        SI = Format(SIvalue, "0.00").ToString.Split(".")
                        Dim S As String
                        S = SI(0) & SI(1)
                        SemitotalSI = SemitotalSI + CInt(S)

                        S = "+" & S.PadLeft(12, "0")



                        Str04 = Str04 & S
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Replace(Format(CDate(Emp.TerminateDate), "dd/MM/yyyy"), "-", "/")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                        Str04 = Str04 & TermDate
                        Str04 = Str04 & 1
                        Me.WriteToSIFile(Str04, Company)
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGESYable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                End If

                If Create_N_Record Then
                    NumberOfTerm = 0
                    NumberOfNew = 0
                    SemiTotalIE = 0
                    SemitotalGE = 0
                    SemitotalSI = 0
                    SemitotalGESYable = 0
                    SemiTotalEmployees = 0
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------

                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & "N"


                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------


                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String



                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                        Dim ALValue As Double = 0
                        If PARAM_CobaltALCode <> "" Then
                            ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, Per, EmpCode)
                            If ALValue <> 0 Then
                                SemiTotalEmployees = SemiTotalEmployees + 1
                                GrossEarnings = Utils.RoundMe3(ALValue, 0)
                                If GrossEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                GE = Math.Abs(GrossEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                                SemitotalGE = SemitotalGE + GrossEarnings
                                GESYableEarnings = RoundMe3(0, 2)
                                SemitotalGESYable = SemitotalGESYable + GESYableEarnings
                                Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                                If GESYableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                                InsurableEarnings = RoundMe3(0, 2)
                                SemiTotalIE = SemiTotalIE + InsurableEarnings
                                IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                                If InsurableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                                SI = Format(0, "0.00").ToString.Split(".")
                                Dim S As String
                                S = SI(0) & SI(1)
                                SemitotalSI = SemitotalSI + CInt(S)

                                S = "+" & S.PadLeft(12, "0")
                                Str04 = Str04 & S
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                TermDate = "          "
                                Str04 = Str04 & TermDate
                                Str04 = Str04 & 1
                                Me.WriteToSIFile(Str04, Company)
                            End If
                        End If
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGESYable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



                End If ' END OF Create_N_record



                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                'x Record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                If Create_X_Record Then
                    NumberOfTerm = 0
                    NumberOfNew = 0
                    SemiTotalIE = 0
                    SemitotalGE = 0
                    SemitotalSI = 0
                    SemitotalGESYable = 0
                    SemiTotalEmployees = 0
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------

                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & "X"


                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------


                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String



                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                        Dim BIKWithSCValue As Double = 0
                        If PARAM_BIKWithSCCode <> "" Then
                            BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, Per, EmpCode)
                            If BIKWithSCValue <> 0 Then
                                SemiTotalEmployees = SemiTotalEmployees + 1
                                GrossEarnings = Utils.RoundMe3(BIKWithSCValue, 0)
                                If GrossEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                GE = Math.Abs(GrossEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                                SemitotalGE = SemitotalGE + GrossEarnings
                                GESYableEarnings = RoundMe3(0, 2)
                                SemitotalGESYable = SemitotalGESYable + GESYableEarnings
                                Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                                If GESYableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                                InsurableEarnings = RoundMe3(0, 2)
                                SemiTotalIE = SemiTotalIE + InsurableEarnings
                                IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                                If InsurableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                                SI = Format(0, "0.00").ToString.Split(".")
                                Dim S As String
                                S = SI(0) & SI(1)
                                SemitotalSI = SemitotalSI + CInt(S)

                                S = "+" & S.PadLeft(12, "0")
                                Str04 = Str04 & S
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                TermDate = "          "
                                Str04 = Str04 & TermDate
                                Str04 = Str04 & 1
                                Me.WriteToSIFile(Str04, Company)
                            End If
                        End If
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGESYable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



                End If ' END OF Create_N_record


                'END of X record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            Next
        Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")



        If GRAND_SemiTotalGESYable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGESYable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub PrepareSIFile_Reverse13_12_Sequence()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGESYable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGESYable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0
        Dim total02 As Integer

        Dim Per13DateFrom As Date
        Dim Per13DateTo As Date
        Dim Per12DateFrom As Date
        Dim Per12DateTo As Date


        Dim AlValueIsBK As Boolean = False
        If PARAM_CobaltALCode <> "" Then
            Dim Ern As New cPrMsEarningCodes(PARAM_CobaltALCode)
            If Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Then
                AlValueIsBK = True
            End If
        End If



        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            Dim z As Integer
            Dim Has13 As Boolean = False
            Dim Reverse13_12 As Boolean = False
           
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            For z = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes
                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(z))
                If Per.PayCat_Code = "3" Then
                    Has13 = True
                    Per13DateFrom = Per.DateFrom
                    Per13Dateto = Per.DateTo
                Else
                    Per12DateFrom = Per.DateFrom
                    Per12DateTo = Per.DateTo
                End If
            Next
            If Has13 And z = 2 Then
                Reverse13_12 = True
            End If
            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes



                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))
                Dim PeriodCategory As String = Per.PayCat_Code
                If Reverse13_12 Then
                    If PeriodCategory = "3" Then
                        PeriodCategory = "K"
                    Else
                        PeriodCategory = "3"
                    End If
                End If

                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemiTotalEmployees = 0
                SemitotalGESYable = 0

                StatusPrep = True
                Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
                DsEmp = Global1.Business.SI_File_GetEmployees(TemGrp, Per, SocCat.Code, StatusPrep)
                If Not StatusPrep Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckDataSet(DsEmp) Then
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------
                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & PeriodCategory

                    If PeriodCategory = "K" Then
                        Str02 = Str02 & Format(Per12DateFrom, "MM/yyyy")
                    Else
                        Dim MM As Integer
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per13DateFrom, "yyyy")
                        Str02 = Str02 & Format(Per13DateFrom, "MM/yyyy")
                        Str02 = Str02 & Format(Per13DateTo, "MM/yyyy")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------

                    '--------------------------------------------------
                    '03 NEW EMPLOYEES
                    '--------------------------------------------------
                    If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            If PeriodCategory = "K" Then
                                Dim EmpCode As String
                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per12DateFrom And Emp.StartDate <= Per12DateTo Then
                                    NumberOfNew = NumberOfNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                    If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                                End If
                        Next
                    End If
                    '--------------------------------------------------
                    'END OF 03
                    '--------------------------------------------------



             
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0

                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        SemiTotalEmployees = SemiTotalEmployees + 1
                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim GESYable() As String

                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)


                        DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TempTempGroup, Per, EmpCode)
                        If CheckDataSet(DsGrossInsurable) Then
                            GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                            InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                            GESYableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                        End If
                        ''''' NEW FIX FOR AVRAAMIDES '''''
                        Dim DsSLeave As DataSet
                        Dim SIvalue As Double = 0
                        DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        If CheckDataSet(DsSLeave) Then
                            For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                    SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''''''''''''''
                        If GrossEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If

                        GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                        SemitotalGE = SemitotalGE + GrossEarnings
                        GE = Math.Abs(GrossEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")

                        GESYableEarnings = RoundMe3(GESYableEarnings - SIvalue, 2)
                        If GESYableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        GESYableEarnings = Utils.RoundMe3(GESYableEarnings, 0)
                        If Math.Abs(GESYableEarnings - GrossEarnings) = 1 Then
                            GESYableEarnings = GrossEarnings
                        End If
                        SemitotalGESYable = SemitotalGESYable + GESYableEarnings
                        GESYable = Math.Abs(GESYableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GESYable(0).PadLeft(10, "0")




                        If GrossEarnings = 0 Then
                            MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                            Dim F As New FrmSelectLeaveReason
                            F.Owner = Me
                            F.ShowDialog()
                            AbsentReason = Me.GlbAbsentReason
                        Else
                            AbsentReason = " "
                        End If

                        InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                        If InsurableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If

                        InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                        If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                            InsurableEarnings = GrossEarnings
                        End If
                        SemiTotalIE = SemiTotalIE + InsurableEarnings
                        IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                        'SI ***********************************
                        'Dim DsSLeave As DataSet
                        'Dim SIvalue As Double = 0
                        'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSLeave) Then
                        '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                        '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If
                        'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSi) Then
                        '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                        '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If

                        SI = Format(SIvalue, "0.00").ToString.Split(".")
                        Dim S As String
                        S = SI(0) & SI(1)
                        SemitotalSI = SemitotalSI + CInt(S)

                        S = "+" & S.PadLeft(12, "0")



                        Str04 = Str04 & S
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If PeriodCategory = "K" Then
                                    If CDate(Emp.TerminateDate) < Per12DateFrom Or CDate(Emp.TerminateDate) > Per12DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                        Str04 = Str04 & TermDate
                        Str04 = Str04 & 1
                        Me.WriteToSIFile(Str04, Company)
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGESYable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")



                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                End If
            Next
        Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGESYable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGESYable.ToString.PadLeft(12, "0")



        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")

        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrepareSIFile_NewFor14()
    End Sub
    Private Sub PrepareSIFile_NewFor14()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0
        Dim total02 As Integer


        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)


            Dim PerToUse As New cPrMsPeriodCodes
            Dim Found As Boolean = False
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim P As New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))

                If P.PayCat_Code = "4" Then
                    Found = True
                Else
                    PerToUse = P
                End If
            Next
            If Not found Then
                MsgBox("Please use this Function only with months with 14 Period. No File is created !", MsgBoxStyle.Information)
                Cursor.Current = Cursors.Default
                Application.DoEvents()
                Exit Sub
            End If

            Dim Per As New cPrMsPeriodCodes
            Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(0))
            NumberOfTerm = 0
            NumberOfNew = 0
            SemiTotalIE = 0
            SemitotalGE = 0
            SemitotalSI = 0
            SemitotalGesyable = 0
            SemiTotalEmployees = 0
            StatusPrep = True
            Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))

            DsEmp = Global1.Business.SI_File_GetEmployees_New14(TemGrp, Per, SocCat.Code, StatusPrep, SIPer.Code)
            If Not StatusPrep Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If CheckDataSet(DsEmp) Then
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------
                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 
                Str02 = Str02 & PerToUse.PayCat_Code

                ' If Per.PayCat_Code = "K" Then
                Str02 = Str02 & Format(PerToUse.DateFrom, "MM/yyyy")
                'Else
                '   Dim MM As Integer
                '  MM = Per.DateFrom.Month + 12
                ' MM = CInt(SIPer.Code) + 12
                'Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                'Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                'Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                'End If
                Me.WriteToSIFile(Str02, Company)
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------

                '--------------------------------------------------
                '03 NEW EMPLOYEES
                '--------------------------------------------------
                If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        If Per.PayCat_Code = "K" Then
                            Dim EmpCode As String
                            EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                            Dim PutZeroToAlienNo As Boolean = False
                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                NumberOfNew = NumberOfNew + 1
                                Str03 = "03"
                                If Emp.SocialInsNumber.Length > 8 Then
                                    MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                If Emp.IdentificationCard.Length > 8 Then
                                    MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                    If Emp.AlienNumber.Length > 8 Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                        If Ans = MsgBoxResult.No Then
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                Else
                                    If Emp.AlienNumber.Length > 8 Then
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                                If PutZeroToAlienNo Then
                                        Str03 = Str03 & "".PadLeft(8, "0")
                                        PutZeroToAlienNo = False
                                    Else
                                        Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                    End If

                                    If Emp.PassportNumber.Length > 10 Then
                                        MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                    Str03 = Str03 & "".PadRight(10, " ")

                                    Dim EmpFull As String
                                    EmpFull = Emp.FirstName & " " & Emp.LastName
                                    If EmpFull.Length > 30 Then
                                        EmpFull = EmpFull.Substring(0, 29)
                                    End If
                                    Str03 = Str03 & EmpFull.PadRight(30, " ")
                                    Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                    Str03 = Str03 & Emp.Sex
                                    Str03 = Str03 & Emp.EmpCmm_Code
                                    Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                    Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                    'If SIleave Then
                                    If Emp.IsSI = 0 Then
                                        Str03 = Str03 & "1"
                                    Else
                                        Str03 = Str03 & "0"
                                    End If
                                    Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                    Dim Position As String
                                    Position = EmpPos.DescriptionL
                                    If Position.Length > 25 Then
                                        Position = Position.Substring(0, 24)
                                    End If
                                    Str03 = Str03 & Position.PadRight(25, " ")
                                    Me.WriteToSIFile(Str03, Company)
                                End If
                            End If
                    Next
                End If
                '--------------------------------------------------
                'END OF 03
                '--------------------------------------------------
                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                    SemiTotalEmployees = SemiTotalEmployees + 1
                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GesyableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String

                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable_New14(TemGrp, Per, EmpCode, SIPer.Code)
                    If CheckDataSet(DsGrossInsurable) Then
                        GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                        InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                        GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                    End If
                    ''''' NEW FIX FOR AVRAAMIDES '''''
                    Dim DsSLeave As DataSet
                    Dim SIvalue As Double = 0
                    DsSLeave = Global1.Business.GetERNFromTrxnLinesFor_New14(Per, "SI", SIPer.Code)
                    If CheckDataSet(DsSLeave) Then
                        For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                            If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                            End If
                        Next
                    End If
                    ''''''''''''''''''''''''''''''''''
                    If GrossEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If

                    GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                    SemitotalGE = SemitotalGE + GrossEarnings
                    GE = Math.Abs(GrossEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")



                    GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)
                    If GesyableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                    If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                        GesyableEarnings = GrossEarnings
                    End If
                    SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                    Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                    If GrossEarnings = 0 Then
                        MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                        Dim F As New FrmSelectLeaveReason
                        F.Owner = Me
                        F.ShowDialog()
                        AbsentReason = Me.GlbAbsentReason
                    Else
                        AbsentReason = " "
                    End If


                    InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                    If InsurableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                    If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                        InsurableEarnings = GrossEarnings
                    End If
                    SemiTotalIE = SemiTotalIE + InsurableEarnings
                    IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                    'SI ***********************************
                    'Dim DsSLeave As DataSet
                    'Dim SIvalue As Double = 0
                    'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSLeave) Then
                    '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                    '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If
                    'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSi) Then
                    '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                    '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If

                    SI = Format(SIvalue, "0.00").ToString.Split(".")
                    Dim S As String
                    S = SI(0) & SI(1)
                    SemitotalSI = SemitotalSI + CInt(S)

                    S = "+" & S.PadLeft(12, "0")



                    Str04 = Str04 & S
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    TermDate = "          "
                    If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                        If Trim(Emp.TerminateDate) <> "" Then
                            If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                TermDate = "          "
                            Else
                                TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                NumberOfTerm = NumberOfTerm + 1
                            End If
                        Else
                            TermDate = "          "
                        End If
                    End If
                    Str04 = Str04 & TermDate
                    Str04 = Str04 & 1
                    Me.WriteToSIFile(Str04, Company)
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

            End If
        Next


        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")

        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        PrepareSIFile_Company()
    End Sub
    Private Sub PrepareSIFile_Company()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0


        Dim GRAND_SemiTotalEmployees As Integer = 0
        Dim total02 As Integer


        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod_Company(SIPer.Code, TemGrp.CompanyCode, PerGroup)
            'For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
            Dim Per As New cPrMsPeriodCodes
            'Dim TemGrp2 As New cPrMsTemplateGroup
            Dim PerCode As String = DbNullToString(DSPeriods.Tables(0).Rows(0).Item(0))
            Dim PerGrp As String = DbNullToString(DSPeriods.Tables(0).Rows(0).Item(1))
            'Dim TemGrpCode As String = DbNullToString(DSPeriods.Tables(0).Rows(j).Item(12))


            Per = New cPrMsPeriodCodes(PerCode, PerGrp)
            'TemGrp2 = New cPrMsTemplateGroup(TemGrpCode)

            NumberOfTerm = 0
            NumberOfNew = 0
            SemiTotalIE = 0
            SemitotalGE = 0
            SemitotalSI = 0
            SemitotalGesyable = 0

            SemiTotalEmployees = 0
            StatusPrep = True
            Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
            DsEmp = Global1.Business.SI_File_GetEmployees_Company(DSPeriods, SocCat.Code, StatusPrep)
            If Not StatusPrep Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If CheckDataSet(DsEmp) Then
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------
                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 
                Str02 = Str02 & Per.PayCat_Code

                If Per.PayCat_Code = "K" Then
                    Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    Str02 = Str02 & MM & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                    Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                End If
                Me.WriteToSIFile(Str02, Company)
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------

                '--------------------------------------------------
                '03 NEW EMPLOYEES
                '--------------------------------------------------
                If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        Dim EmpCode As String
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim Emp As New cPrMsEmployees(EmpCode)
                        If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                            NumberOfNew = NumberOfNew + 1
                            Str03 = "03"
                            If Emp.SocialInsNumber.Length > 8 Then
                                MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                            Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                            If Emp.IdentificationCard.Length > 8 Then
                                MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                            Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                            If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                If Emp.AlienNumber.Length > 8 Then
                                    Dim Ans As MsgBoxResult
                                    Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                    If Ans = MsgBoxResult.No Then
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    Else
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                            Else
                                If Emp.AlienNumber.Length > 8 Then
                                    PutZeroToAlienNo = True
                                End If
                            End If
                            If PutZeroToAlienNo Then
                                    Str03 = Str03 & "".PadLeft(8, "0")
                                    PutZeroToAlienNo = False
                                Else
                                    Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                End If

                                If Emp.PassportNumber.Length > 10 Then
                                    MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                Str03 = Str03 & "".PadRight(10, " ")

                                Dim EmpFull As String
                                EmpFull = Emp.FirstName & " " & Emp.LastName
                                If EmpFull.Length > 30 Then
                                    EmpFull = EmpFull.Substring(0, 29)
                                End If
                                Str03 = Str03 & EmpFull.PadRight(30, " ")
                                Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                Str03 = Str03 & Emp.Sex
                                Str03 = Str03 & Emp.EmpCmm_Code
                                Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                'If SIleave Then
                                If Emp.IsSI = 0 Then
                                    Str03 = Str03 & "1"
                                Else
                                    Str03 = Str03 & "0"
                                End If
                                Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                Dim Position As String
                                Position = EmpPos.DescriptionL
                                If Position.Length > 25 Then
                                    Position = Position.Substring(0, 24)
                                End If
                                Str03 = Str03 & Position.PadRight(25, " ")
                                Me.WriteToSIFile(Str03, Company)
                            End If
                    Next
                End If
                '--------------------------------------------------
                'END OF 03
                '--------------------------------------------------
                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                    SemiTotalEmployees = SemiTotalEmployees + 1
                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GesyableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String

                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    'DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)
                    DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable_Company1(DSPeriods, EmpCode)
                    If CheckDataSet(DsGrossInsurable) Then
                        GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                        InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                        GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                    End If


                    If GrossEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                    SemitotalGE = SemitotalGE + GrossEarnings
                    GE = Math.Abs(GrossEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                    If InsurableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If

                    If GrossEarnings = 0 Then
                        MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                        Dim F As New FrmSelectLeaveReason
                        F.Owner = Me
                        F.ShowDialog()
                        AbsentReason = Me.GlbAbsentReason
                    Else
                        AbsentReason = " "
                    End If

                    GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                    SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                    Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                    InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                    SemiTotalIE = SemiTotalIE + InsurableEarnings
                    IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                    'SI ***********************************
                    Dim DsSLeave As DataSet
                    Dim SIvalue As Double = 0
                    DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    If CheckDataSet(DsSLeave) Then
                        For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                            If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                            End If
                        Next
                    End If
                    'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSi) Then
                    '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                    '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If

                    SI = Format(SIvalue, "0.00").ToString.Split(".")
                    Dim S As String
                    S = SI(0) & SI(1)
                    SemitotalSI = SemitotalSI + CInt(S)

                    S = "+" & S.PadLeft(12, "0")



                    Str04 = Str04 & S
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    TermDate = "          "
                    If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                        If Trim(Emp.TerminateDate) <> "" Then
                            TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                            NumberOfTerm = NumberOfTerm + 1
                        Else
                            TermDate = "          "
                        End If
                    End If
                    Str04 = Str04 & TermDate
                    Str04 = Str04 & 1
                    Me.WriteToSIFile(Str04, Company)
                Next
                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

            End If
        Next
        'Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")

        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")



        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------





        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Function WriteToSIFile(ByVal Line As String, ByVal Company As cAdMsCompany) As Boolean
        Dim Flag As Boolean = True

        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String = SIFileDir & "\" & Company.NameShort & "_SI.rep"
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


        ''''''''''''''''''''''''''''''''

        Try
            ' Dim mFile As System.IO.File
            Dim FileName2 As String = SIFileDir & "\" & Company.NameShort & "_SIFile.txt"
            Dim TW2 As System.IO.TextWriter

            If InitFile2 Then
                TW2 = System.IO.File.CreateText(FileName2)
                InitFile2 = False
            Else
                If IO.File.Exists(FileName2) Then
                    TW2 = System.IO.File.AppendText(FileName2)
                Else
                    TW2 = System.IO.File.CreateText(FileName2)
                End If
            End If
            With TW2
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception

        End Try
        ''''''''''''''''''''''''''''''''


        Return Flag
    End Function

    Private Sub BSwitchToPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSwitchToPeriod.CheckedChanged
        UpdateMenus()
    End Sub
    Private Sub UpdateMenus()
        If Me.CBSwitchToPeriod.CheckState = CheckState.Checked Then
            Me.CmbSIPeriod.Enabled = False
            Me.ComboPeriod.Enabled = True

            Me.TSBFile.Enabled = False
            Me.TSBFile_ConsolPerComp.Enabled = False
            Me.TSBFile_MultibleSI.Enabled = False

            Me.TSBFile_BasedOnActual.Enabled = True
            Me.TSBFile_ConsolPerComp_BasedOnActual.Enabled = True
            Me.TSBFile_MultibleSI_BasedOnActual.Enabled = True
        Else
            Me.CmbSIPeriod.Enabled = True
            Me.ComboPeriod.Enabled = False

            Me.TSBFile.Enabled = True
            Me.TSBFile_ConsolPerComp.Enabled = True
            Me.TSBFile_MultibleSI.Enabled = True

            Me.TSBFile_BasedOnActual.Enabled = False
            Me.TSBFile_ConsolPerComp_BasedOnActual.Enabled = False
            Me.TSBFile_MultibleSI_BasedOnActual.Enabled = False
        End If
    End Sub

    Private Sub TSSendToPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowThereport(True, False, False)
    End Sub

    Private Sub BtnNewEmployeesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewEmployeesReport.Click
        ShowThereport(False, True, False)
    End Sub


    Private Sub Test_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Test.Click

    End Sub
    Private Sub PrepareSIFile_2()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfSemiTerm As Integer = 0
        Dim NumberOfSemiNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_SemiNumberOfTerm As Integer = 0
        Dim GRAND_SemiNumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0


        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_TotalIE As Integer = 0
        Dim GRAND_totalGE As Integer = 0
        Dim GRAND_TotalSI As Integer = 0
        Dim GRAND_TotalGesyable As Integer = 0
        Dim GRAND_TotalEmployees As Integer = 0


        Dim total02 As Integer
        Dim Sign As String
        Dim y As Integer = 0

        For y = 0 To 4
            Dim SIReg1to5 As String

            Select Case y
                Case 0
                    SIReg1to5 = Company.SIRegNo
                Case 1
                    SIReg1to5 = Company.SI2
                Case 2
                    SIReg1to5 = Company.SI3
                Case 3
                    SIReg1to5 = Company.SI4
                Case 4
                    SIReg1to5 = Company.SI5
            End Select
            If SIReg1to5 <> "" Then
                Dim StatusPrep As Boolean
                DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
                For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
                    DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
                    For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                        Dim Per As New cPrMsPeriodCodes
                        Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))
                        NumberOfSemiTerm = 0
                        NumberOfSemiNew = 0
                        SemiTotalIE = 0
                        SemitotalGE = 0
                        SemitotalSI = 0
                        SemitotalGesyable = 0
                        SemiTotalEmployees = 0
                        StatusPrep = True
                        Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
                        DsEmp = Global1.Business.SI_File_GetEmployees_2(TemGrp, Per, SocCat.Code, StatusPrep, SIReg1to5)
                        If Not StatusPrep Then
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        If CheckDataSet(DsEmp) Then
                            '-------------------------------------------------
                            'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                            '--------------------------------------------------
                            total02 = total02 + 1
                            Str02 = "02"
                            'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                            Str02 = Str02 & SIReg1to5.PadLeft(15, "0")
                            Str02 = Str02 & SocCat.Code
                            'Change 2016/03/02
                            'OLD Str02 = Str02 & Per.SinPrdCode
                            'NEW 
                            Str02 = Str02 & Per.PayCat_Code

                            If Per.PayCat_Code = "K" Then
                                Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                            Else
                                Dim MM As Integer
                                MM = Per.DateFrom.Month + 12
                                Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                                Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                                Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                            End If
                            Me.WriteToSIFile(Str02, Company)
                            '--------------------------------------------------
                            'END OF 02
                            '--------------------------------------------------

                            '--------------------------------------------------
                            '03 NEW EMPLOYEES
                            '--------------------------------------------------
                            If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                                    Dim EmpCode As String
                                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                    Dim PutZeroToAlienNo As Boolean = False
                                    Dim Emp As New cPrMsEmployees(EmpCode)
                                    If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                        NumberOfSemiNew = NumberOfSemiNew + 1
                                        Str03 = "03"
                                        If Emp.SocialInsNumber.Length > 8 Then
                                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                        If Emp.IdentificationCard.Length > 8 Then
                                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                            If Emp.AlienNumber.Length > 8 Then
                                                Dim Ans As MsgBoxResult
                                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                                If Ans = MsgBoxResult.No Then
                                                    Me.Cursor = Cursors.Default
                                                    Exit Sub
                                                Else
                                                    PutZeroToAlienNo = True
                                                End If
                                            End If
                                        Else
                                            If Emp.AlienNumber.Length > 8 Then
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                        If PutZeroToAlienNo Then
                                                Str03 = Str03 & "".PadLeft(8, "0")
                                                PutZeroToAlienNo = False
                                            Else
                                                Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                            End If

                                            If Emp.PassportNumber.Length > 10 Then
                                                MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            End If
                                            'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                            Str03 = Str03 & "".PadRight(10, " ")

                                            Dim EmpFull As String
                                            EmpFull = Emp.FirstName & " " & Emp.LastName
                                            If EmpFull.Length > 30 Then
                                                EmpFull = EmpFull.Substring(0, 29)
                                            End If
                                            Str03 = Str03 & EmpFull.PadRight(30, " ")
                                            Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                            Str03 = Str03 & Emp.Sex
                                            Str03 = Str03 & Emp.EmpCmm_Code
                                            Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                            Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                            'If SIleave Then
                                            If Emp.IsSI = 0 Then
                                                Str03 = Str03 & "1"
                                            Else
                                                Str03 = Str03 & "0"
                                            End If
                                            Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                            Dim Position As String
                                            Position = EmpPos.DescriptionL
                                            If Position.Length > 25 Then
                                                Position = Position.Substring(0, 24)
                                            End If
                                            Str03 = Str03 & Position.PadRight(25, " ")
                                            Me.WriteToSIFile(Str03, Company)
                                        End If
                                Next
                            End If
                            '--------------------------------------------------
                            'END OF 03
                            '--------------------------------------------------
                            '--------------------------------------------------
                            '04 EMPLOYEES EARNINGS
                            '--------------------------------------------------
                            SemiTotalEmployees = 0
                            For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                                SemiTotalEmployees = SemiTotalEmployees + 1
                                Dim EmpCode As String
                                Dim GrossEarnings As Double = 0
                                Dim InsurableEarnings As Double = 0
                                Dim GesyableEarnings As Double = 0
                                Dim PutZeroToAlienNo As Boolean = False
                                Dim x As Integer
                                Dim GE() As String
                                Dim IE() As String
                                Dim SI() As String
                                Dim Gesyable() As String

                                Dim TermDate As String
                                Dim AbsentReason As String = " "
                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                Str04 = "04"
                                If Emp.SocialInsNumber.Length > 8 Then
                                    MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                If Emp.IdentificationCard.Length > 8 Then
                                    MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                    If Emp.AlienNumber.Length > 8 Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                        If Ans = MsgBoxResult.No Then
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                Else
                                    If Emp.AlienNumber.Length > 8 Then
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                                If PutZeroToAlienNo Then
                                    Str04 = Str04 & "".PadLeft(8, "0")
                                Else
                                    Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                                End If
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim DsGrossInsurable As DataSet
                                DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)
                                If CheckDataSet(DsGrossInsurable) Then
                                    GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                                    InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                                    GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                                End If
                                If GrossEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Dim DsSLeave As DataSet
                                Dim SIvalue As Double = 0
                                DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                                If CheckDataSet(DsSLeave) Then
                                    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                        End If
                                    Next
                                End If

                                GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                                SemitotalGE = SemitotalGE + GrossEarnings
                                GE = Math.Abs(GrossEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")


                                GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)
                                If GesyableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                                If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                                    GesyableEarnings = GrossEarnings
                                End If

                                SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                                Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")



                                InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)
                                If InsurableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If

                                If GrossEarnings = 0 Then
                                    MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                                    Dim F As New FrmSelectLeaveReason
                                    F.Owner = Me
                                    F.ShowDialog()
                                    AbsentReason = Me.GlbAbsentReason
                                Else
                                    AbsentReason = " "
                                End If

                                InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                                If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                                    InsurableEarnings = GrossEarnings
                                    'MsgBox(EmpCode, InsurableEarnings, GrossEarnings)
                                End If



                                SemiTotalIE = SemiTotalIE + InsurableEarnings
                                IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                                'SI ***********************************
                                'Dim DsSLeave As DataSet
                                'Dim SIvalue As Double = 0
                                'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                                'If CheckDataSet(DsSLeave) Then
                                '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                '        End If
                                '    Next
                                'End If
                                'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                                'If CheckDataSet(DsSi) Then
                                '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                                '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                                '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                                '        End If
                                '    Next
                                'End If

                                SI = Format(SIvalue, "0.00").ToString.Split(".")
                                Dim S As String
                                S = SI(0) & SI(1)
                                SemitotalSI = SemitotalSI + CInt(S)

                                S = "+" & S.PadLeft(12, "0")



                                Str04 = Str04 & S
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                TermDate = "          "
                                If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                                    If Trim(Emp.TerminateDate) <> "" Then
                                        If Per.PayCat_Code = "K" Then
                                            If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                                TermDate = "          "
                                            Else

                                                TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                                NumberOfSemiTerm = NumberOfSemiTerm + 1
                                            End If
                                        Else
                                            TermDate = "          "
                                        End If
                                    Else
                                        TermDate = "          "
                                    End If
                                End If
                                Str04 = Str04 & TermDate
                                Str04 = Str04 & 1
                                Me.WriteToSIFile(Str04, Company)
                            Next

                            '--------------------------------------------------
                            'END OF 04
                            '--------------------------------------------------
                            '--------------------------------------------------
                            '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                            '--------------------------------------------------
                            Str05 = "05"
                            If SemitotalGE >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                            If SemitotalGesyable >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")



                            If SemiTotalIE >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                            'SI ************************

                            Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                            Str05 = Str05 & NumberOfSemiNew.ToString.PadLeft(5, "0")
                            Str05 = Str05 & NumberOfSemiTerm.ToString.PadLeft(5, "0")
                            Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                            Me.WriteToSIFile(Str05, Company)
                            '--------------------------------------------------
                            'END OF 05
                            '--------------------------------------------------

                            GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfSemiNew
                            GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfSemiTerm
                            GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                            GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                            GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                            GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                            GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                        End If
                    Next
                Next
            End If
        Next



        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")

        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------





        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrepareSIFile_2_OLDSpecs()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfSemiTerm As Integer = 0
        Dim NumberOfSemiNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_SemiNumberOfTerm As Integer = 0
        Dim GRAND_SemiNumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0


        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_TotalIE As Integer = 0
        Dim GRAND_totalGE As Integer = 0
        Dim GRAND_TotalSI As Integer = 0
        Dim GRAND_TotalGesyable As Integer = 0
        Dim GRAND_TotalEmployees As Integer = 0


        Dim total02 As Integer
        Dim Sign As String
        Dim y As Integer = 0

        For y = 0 To 4
            Dim SIReg1to5 As String

            Select Case y
                Case 0
                    SIReg1to5 = Company.SIRegNo
                Case 1
                    SIReg1to5 = Company.SI2
                Case 2
                    SIReg1to5 = Company.SI3
                Case 3
                    SIReg1to5 = Company.SI4
                Case 4
                    SIReg1to5 = Company.SI5
            End Select
            If SIReg1to5 <> "" Then
                Dim StatusPrep As Boolean
                DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
                For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
                    DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
                    For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                        Dim Per As New cPrMsPeriodCodes
                        Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))
                        NumberOfSemiTerm = 0
                        NumberOfSemiNew = 0
                        SemiTotalIE = 0
                        SemitotalGE = 0
                        SemitotalSI = 0
                        SemitotalGesyable = 0
                        SemiTotalEmployees = 0
                        StatusPrep = True
                        Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
                        DsEmp = Global1.Business.SI_File_GetEmployees_2(TemGrp, Per, SocCat.Code, StatusPrep, SIReg1to5)
                        If Not StatusPrep Then
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        If CheckDataSet(DsEmp) Then
                            '-------------------------------------------------
                            'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                            '--------------------------------------------------
                            total02 = total02 + 1
                            Str02 = "02"
                            'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                            Str02 = Str02 & SIReg1to5.PadLeft(15, "0")
                            Str02 = Str02 & SocCat.Code
                            'Change 2016/03/02
                            'OLD Str02 = Str02 & Per.SinPrdCode
                            'NEW 
                            Str02 = Str02 & Per.PayCat_Code

                            If Per.PayCat_Code = "K" Then
                                Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                            Else
                                Dim MM As Integer
                                MM = Per.DateFrom.Month + 12
                                Str02 = Str02 & MM & Format(Per.DateFrom, "yyyy")
                                Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                                Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                            End If
                            Me.WriteToSIFile(Str02, Company)
                            '--------------------------------------------------
                            'END OF 02
                            '--------------------------------------------------

                            '--------------------------------------------------
                            '03 NEW EMPLOYEES
                            '--------------------------------------------------
                            If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                                    Dim EmpCode As String
                                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                    Dim PutZeroToAlienNo As Boolean = False
                                    Dim Emp As New cPrMsEmployees(EmpCode)
                                    If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                        NumberOfSemiNew = NumberOfSemiNew + 1
                                        Str03 = "03"
                                        If Emp.SocialInsNumber.Length > 8 Then
                                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                        If Emp.IdentificationCard.Length > 8 Then
                                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                            If Emp.AlienNumber.Length > 8 Then
                                                Dim Ans As MsgBoxResult
                                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                                If Ans = MsgBoxResult.No Then
                                                    Me.Cursor = Cursors.Default
                                                    Exit Sub
                                                Else
                                                    PutZeroToAlienNo = True
                                                End If
                                            End If
                                        Else
                                            If Emp.AlienNumber.Length > 8 Then
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                        If PutZeroToAlienNo Then
                                                Str03 = Str03 & "".PadLeft(8, "0")
                                                PutZeroToAlienNo = False
                                            Else
                                                Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                            End If

                                            If Emp.PassportNumber.Length > 10 Then
                                                MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            End If
                                            'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                            Str03 = Str03 & "".PadRight(10, " ")

                                            Dim EmpFull As String
                                            EmpFull = Emp.FirstName & " " & Emp.LastName
                                            If EmpFull.Length > 30 Then
                                                EmpFull = EmpFull.Substring(0, 29)
                                            End If
                                            Str03 = Str03 & EmpFull.PadRight(30, " ")
                                            Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                            Str03 = Str03 & Emp.Sex
                                            Str03 = Str03 & Emp.EmpCmm_Code
                                            Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                            Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                            'If SIleave Then
                                            If Emp.IsSI = 0 Then
                                                Str03 = Str03 & "1"
                                            Else
                                                Str03 = Str03 & "0"
                                            End If
                                            Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                            Dim Position As String
                                            Position = EmpPos.DescriptionL
                                            If Position.Length > 25 Then
                                                Position = Position.Substring(0, 24)
                                            End If
                                            Str03 = Str03 & Position.PadRight(25, " ")
                                            Me.WriteToSIFile(Str03, Company)
                                        End If
                                Next
                            End If
                            '--------------------------------------------------
                            'END OF 03
                            '--------------------------------------------------
                            '--------------------------------------------------
                            '04 EMPLOYEES EARNINGS
                            '--------------------------------------------------
                            SemiTotalEmployees = 0
                            For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                                SemiTotalEmployees = SemiTotalEmployees + 1
                                Dim EmpCode As String
                                Dim GrossEarnings As Double = 0
                                Dim InsurableEarnings As Double = 0
                                Dim GesyableEarnings As Double = 0
                                Dim PutZeroToAlienNo As Boolean = False
                                Dim x As Integer
                                Dim GE() As String
                                Dim IE() As String
                                Dim SI() As String
                                Dim Gesyable() As String

                                Dim TermDate As String
                                Dim AbsentReason As String = " "
                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                Str04 = "04"
                                If Emp.SocialInsNumber.Length > 8 Then
                                    MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                If Emp.IdentificationCard.Length > 8 Then
                                    MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                    If Emp.AlienNumber.Length > 8 Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                        If Ans = MsgBoxResult.No Then
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                Else
                                    If Emp.AlienNumber.Length > 8 Then
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                                If PutZeroToAlienNo Then
                                    Str04 = Str04 & "".PadLeft(8, "0")
                                Else
                                    Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                                End If
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim DsGrossInsurable As DataSet
                                DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)
                                If CheckDataSet(DsGrossInsurable) Then
                                    GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                                    InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                                    GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                                End If
                                If GrossEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Dim DsSLeave As DataSet
                                Dim SIvalue As Double = 0
                                DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                                If CheckDataSet(DsSLeave) Then
                                    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                        End If
                                    Next
                                End If

                                GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                                SemitotalGE = SemitotalGE + GrossEarnings
                                GE = Math.Abs(GrossEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & GE(0).PadLeft(6, "0")


                                GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)
                                If GesyableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                                If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                                    GesyableEarnings = GrossEarnings
                                End If

                                SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                                Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                                ' Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")



                                InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)
                                If InsurableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If

                                If GrossEarnings = 0 Then
                                    MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                                    Dim F As New FrmSelectLeaveReason
                                    F.Owner = Me
                                    F.ShowDialog()
                                    AbsentReason = Me.GlbAbsentReason
                                Else
                                    AbsentReason = " "
                                End If

                                InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                                If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                                    InsurableEarnings = GrossEarnings
                                    'MsgBox(EmpCode, InsurableEarnings, GrossEarnings)
                                End If



                                SemiTotalIE = SemiTotalIE + InsurableEarnings
                                IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & IE(0).PadLeft(6, "0")
                                'SI ***********************************
                                'Dim DsSLeave As DataSet
                                'Dim SIvalue As Double = 0
                                'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                                'If CheckDataSet(DsSLeave) Then
                                '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                '        End If
                                '    Next
                                'End If
                                'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                                'If CheckDataSet(DsSi) Then
                                '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                                '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                                '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                                '        End If
                                '    Next
                                'End If

                                SI = Format(SIvalue, "0.00").ToString.Split(".")
                                Dim S As String
                                S = SI(0) & SI(1)
                                SemitotalSI = SemitotalSI + CInt(S)

                                S = "+" & S.PadLeft(8, "0")



                                Str04 = Str04 & S
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                TermDate = "          "
                                If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                                    If Trim(Emp.TerminateDate) <> "" Then
                                        If Per.PayCat_Code = "K" Then
                                            If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                                TermDate = "          "
                                            Else

                                                TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                                NumberOfSemiTerm = NumberOfSemiTerm + 1
                                            End If
                                        Else
                                            TermDate = "          "
                                        End If
                                    Else
                                        TermDate = "          "
                                    End If
                                End If
                                Str04 = Str04 & TermDate
                                Str04 = Str04 & 1
                                Me.WriteToSIFile(Str04, Company)
                            Next

                            '--------------------------------------------------
                            'END OF 04
                            '--------------------------------------------------
                            '--------------------------------------------------
                            '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                            '--------------------------------------------------
                            Str05 = "05"
                            If SemitotalGE >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(8, "0")


                            If SemitotalGesyable >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            ' Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")



                            If SemiTotalIE >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(8, "0")

                            'SI ************************

                            Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(9, "0")
                            Str05 = Str05 & NumberOfSemiNew.ToString.PadLeft(5, "0")
                            Str05 = Str05 & NumberOfSemiTerm.ToString.PadLeft(5, "0")
                            Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                            Me.WriteToSIFile(Str05, Company)
                            '--------------------------------------------------
                            'END OF 05
                            '--------------------------------------------------

                            GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfSemiNew
                            GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfSemiTerm
                            GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                            GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                            GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                            GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                            GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                        End If
                    Next
                Next
            End If
        Next



        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(8, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        ' Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(8, "0")

        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(8, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(9, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------





        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrepareSIFile_SelectionOfPeriodGroups()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0
        Dim total02 As Integer


        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)

            Debug.WriteLine(i & " " & SIPer.Code)

            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes


                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))
                Debug.WriteLine(i & " " & Per.PrdGrpCode & " " & Per.Code)

                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                StatusPrep = True
                Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))

                DsEmp = Global1.Business.SI_File_GetEmployees_MultibleTemplates(TemGrp, Per, SocCat.Code, StatusPrep)

                If Not StatusPrep Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckDataSet(DsEmp) Then
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------
                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & Per.PayCat_Code

                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                    Else
                        Dim MM As Integer
                        'MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                        Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------

                    '--------------------------------------------------
                    '03 NEW EMPLOYEES
                    '--------------------------------------------------
                    If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            If Per.PayCat_Code = "K" Then
                                Dim EmpCode As String
                                Dim TempPeriodGroup As String
                                Dim TempTemplateGroup As String

                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                                TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                    NumberOfNew = NumberOfNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                        If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                                End If
                        Next
                    End If
                    '--------------------------------------------------
                    'END OF 03
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        SemiTotalEmployees = SemiTotalEmployees + 1
                        Dim EmpCode As String
                        Dim TempPeriodGroup As String
                        Dim TempTemplateGroup As String

                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GesyableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String


                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                        TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim Ttemgrp As New cPrMsTemplateGroup(TempTemplateGroup)
                        Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                        'DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)

                        DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(Ttemgrp, TPeriod, EmpCode)
                        If CheckDataSet(DsGrossInsurable) Then
                            GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                            InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                            GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))

                        End If
                        ''''' NEW FIX FOR AVRAAMIDES '''''
                        Dim DsSLeave As DataSet
                        Dim SIvalue As Double = 0
                        DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        If CheckDataSet(DsSLeave) Then
                            For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                    SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''''''''''''''
                        If GrossEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If

                        GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                        SemitotalGE = SemitotalGE + GrossEarnings
                        GE = Math.Abs(GrossEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")

                        GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)

                        If GesyableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                        If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                            GesyableEarnings = GrossEarnings
                        End If
                        SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                        Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                        If GrossEarnings = 0 Then
                            MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                            Dim F As New FrmSelectLeaveReason
                            F.Owner = Me
                            F.ShowDialog()
                            AbsentReason = Me.GlbAbsentReason
                        Else
                            AbsentReason = " "
                        End If

                        InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                        If InsurableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                        If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                            InsurableEarnings = GrossEarnings
                        End If
                        SemiTotalIE = SemiTotalIE + InsurableEarnings
                        IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                        'SI ***********************************
                        'Dim DsSLeave As DataSet
                        'Dim SIvalue As Double = 0
                        'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSLeave) Then
                        '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                        '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If
                        'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSi) Then
                        '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                        '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If

                        SI = Format(SIvalue, "0.00").ToString.Split(".")
                        Dim S As String
                        S = SI(0) & SI(1)
                        SemitotalSI = SemitotalSI + CInt(S)

                        S = "+" & S.PadLeft(12, "0")



                        Str04 = Str04 & S
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                        Str04 = Str04 & TermDate
                        Str04 = Str04 & 1
                        Me.WriteToSIFile(Str04, Company)
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGesyable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                End If
            Next
        Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub PrepareSIFile_SelectionOfPeriodGroups_2()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0

        Dim total02 As Integer
        Dim total_N_02 As Integer
        Dim total_X_02 As Integer

        Dim AlValueIsBK As Boolean = False

        If PARAM_CobaltALCode <> "" Then
            Dim Ern As New cPrMsEarningCodes(PARAM_CobaltALCode)
            If Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Then
                AlValueIsBK = True
            End If
        End If


        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            Dim Create_N_Record As Boolean = False
            Dim Create_X_Record As Boolean = False
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)

            Debug.WriteLine(i & " " & SIPer.Code)

            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes


                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))
                Debug.WriteLine(i & " " & Per.PrdGrpCode & " " & Per.Code)

                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                StatusPrep = True
                Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))

                DsEmp = Global1.Business.SI_File_GetEmployees_MultibleTemplates(TemGrp, Per, SocCat.Code, StatusPrep)

                If Not StatusPrep Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckDataSet(DsEmp) Then
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------
                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & Per.PayCat_Code

                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                    Else
                        Dim MM As Integer
                        'MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                        Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------

                    '--------------------------------------------------
                    '03 NEW EMPLOYEES
                    '--------------------------------------------------
                    If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            If Per.PayCat_Code = "K" Then
                                Dim EmpCode As String
                                Dim TempPeriodGroup As String
                                Dim TempTemplateGroup As String


                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                                TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                    NumberOfNew = NumberOfNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                        If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                                End If
                        Next
                    End If
                    '--------------------------------------------------
                    'END OF 03
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        SemiTotalEmployees = SemiTotalEmployees + 1
                        Dim EmpCode As String
                        Dim TempPeriodGroup As String
                        Dim TempTemplateGroup As String


                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GesyableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String


                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                        TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim Ttemgrp As New cPrMsTemplateGroup(TempTemplateGroup)
                        Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)
                        Dim ALValue As Double = 0

                        'xxxxxxxxxxxxxxx()
                        If PARAM_CobaltALCode <> "" Then
                            ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(Ttemgrp, TPeriod, EmpCode)
                            If ALValue <> 0 Then
                                Create_N_Record = True
                                total_N_02 = total_N_02 + 1
                            End If
                        End If
                        Dim BIKWithSCValue As Double = 0
                        If PARAM_BIKWithSCCode <> "" Then
                            BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(Ttemgrp, TPeriod, EmpCode)
                            If BIKWithSCValue <> 0 Then
                                Create_X_Record = True
                                total_X_02 = total_X_02 + 1
                            End If
                        End If
                        'DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)

                        DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(Ttemgrp, TPeriod, EmpCode)
                        If CheckDataSet(DsGrossInsurable) Then
                            GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0)) - ALValue
                            InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                            GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))

                        End If
                        ''''' NEW FIX FOR AVRAAMIDES '''''
                        Dim DsSLeave As DataSet
                        Dim SIvalue As Double = 0
                        DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(TPeriod, "SI")
                        If CheckDataSet(DsSLeave) Then
                            For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                    SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''''''''''''''
                        If GrossEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If

                        GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                        SemitotalGE = SemitotalGE + GrossEarnings
                        GE = Math.Abs(GrossEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")

                        GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)

                        If GesyableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                        If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                            GesyableEarnings = GrossEarnings
                        End If
                        SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                        Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                        If GrossEarnings = 0 Then
                            MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                            Dim F As New FrmSelectLeaveReason
                            F.Owner = Me
                            F.ShowDialog()
                            AbsentReason = Me.GlbAbsentReason
                        Else
                            AbsentReason = " "
                        End If

                        InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                        If InsurableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                        If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                            InsurableEarnings = GrossEarnings
                        End If
                        SemiTotalIE = SemiTotalIE + InsurableEarnings
                        IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                        'SI ***********************************
                        'Dim DsSLeave As DataSet
                        'Dim SIvalue As Double = 0
                        'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSLeave) Then
                        '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                        '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If
                        'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSi) Then
                        '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                        '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If

                        SI = Format(SIvalue, "0.00").ToString.Split(".")
                        Dim S As String
                        S = SI(0) & SI(1)
                        SemitotalSI = SemitotalSI + CInt(S)

                        S = "+" & S.PadLeft(12, "0")



                        Str04 = Str04 & S
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                        Str04 = Str04 & TermDate
                        Str04 = Str04 & 1
                        Me.WriteToSIFile(Str04, Company)
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGesyable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                End If

                If Create_N_Record Then
                    NumberOfTerm = 0
                    NumberOfNew = 0
                    SemiTotalIE = 0
                    SemitotalGE = 0
                    SemitotalSI = 0
                    SemitotalGesyable = 0
                    SemiTotalEmployees = 0
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------

                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & "N"


                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------


                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String





                        Dim TermDate As String
                        Dim AbsentReason As String = " "

                        Dim TempPeriodGroup As String
                        Dim TempTemplateGroup As String
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                        TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                        Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                        Dim ALValue As Double = 0
                        If PARAM_CobaltALCode <> "" Then
                            ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, TPeriod, EmpCode)
                            If ALValue <> 0 Then
                                SemiTotalEmployees = SemiTotalEmployees + 1
                                GrossEarnings = Utils.RoundMe3(ALValue, 0)
                                If GrossEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                GE = Math.Abs(GrossEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                                SemitotalGE = SemitotalGE + GrossEarnings
                                GESYableEarnings = RoundMe3(0, 2)
                                SemitotalGesyable = SemitotalGesyable + GESYableEarnings
                                Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                                If GESYableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                                InsurableEarnings = RoundMe3(0, 2)
                                SemiTotalIE = SemiTotalIE + InsurableEarnings
                                IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                                If InsurableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                                SI = Format(0, "0.00").ToString.Split(".")
                                Dim S As String
                                S = SI(0) & SI(1)
                                SemitotalSI = SemitotalSI + CInt(S)

                                S = "+" & S.PadLeft(12, "0")
                                Str04 = Str04 & S
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                TermDate = "          "
                                Str04 = Str04 & TermDate
                                Str04 = Str04 & 1
                                Me.WriteToSIFile(Str04, Company)
                            End If
                        End If
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGesyable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")


                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



                End If ' END OF Create_N_record



                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                'x Record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                If Create_X_Record Then
                    NumberOfTerm = 0
                    NumberOfNew = 0
                    SemiTotalIE = 0
                    SemitotalGE = 0
                    SemitotalSI = 0
                    SemitotalGesyable = 0
                    SemiTotalEmployees = 0
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------

                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 
                    Str02 = Str02 & "X"


                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------


                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                        Dim EmpCode As String
                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GESYableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String



                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        Dim TempPeriodGroup As String
                        Dim TempTemplateGroup As String
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                        TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))


                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                        Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                        Dim BIKWithSCValue As Double = 0
                        If PARAM_BIKWithSCCode <> "" Then
                            BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, TPeriod, EmpCode)
                            If BIKWithSCValue <> 0 Then
                                SemiTotalEmployees = SemiTotalEmployees + 1
                                GrossEarnings = Utils.RoundMe3(BIKWithSCValue, 0)
                                If GrossEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                GE = Math.Abs(GrossEarnings).ToString.Split(".")
                                Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                                SemitotalGE = SemitotalGE + GrossEarnings
                                GESYableEarnings = RoundMe3(0, 2)
                                SemitotalGesyable = SemitotalGesyable + GESYableEarnings
                                Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                                If GESYableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                                InsurableEarnings = RoundMe3(0, 2)
                                SemiTotalIE = SemiTotalIE + InsurableEarnings
                                IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                                If InsurableEarnings >= 0 Then
                                    Sign = "+"
                                Else
                                    Sign = "-"
                                End If
                                Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                                SI = Format(0, "0.00").ToString.Split(".")
                                Dim S As String
                                S = SI(0) & SI(1)
                                SemitotalSI = SemitotalSI + CInt(S)

                                S = "+" & S.PadLeft(12, "0")
                                Str04 = Str04 & S
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                Str04 = Str04 & AbsentReason
                                TermDate = "          "
                                Str04 = Str04 & TermDate
                                Str04 = Str04 & 1
                                Me.WriteToSIFile(Str04, Company)
                            End If
                        End If
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGesyable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")


                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



                End If ' END OF Create_N_record


                'END of X record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






            Next
        Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PrepareSIFile_SelectionOfPeriodGroups_Reverse13_12_Sequence()


        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0
        Dim total02 As Integer


        Dim Per13DateFrom As Date
        Dim Per13DateTo As Date
        Dim Per12DateFrom As Date
        Dim Per12DateTo As Date

        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1

            Dim z As Integer
            Dim Has13 As Boolean = False
            Dim Reverse13_12 As Boolean = False

            DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            For z = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes
                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(z))
                If Per.PayCat_Code = "3" Then
                    Has13 = True
                    Per13DateFrom = Per.DateFrom
                    Per13DateTo = Per.DateTo
                Else
                    Per12DateFrom = Per.DateFrom
                    Per12DateTo = Per.DateTo
                End If
            Next
            If Has13 And z = 2 Then
                Reverse13_12 = True
            End If

            For j = 0 To DSPeriods.Tables(0).Rows.Count - 1
                Dim Per As New cPrMsPeriodCodes


                Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))
                Dim PeriodCategory As String = Per.PayCat_Code
                If Reverse13_12 Then
                    If PeriodCategory = "3" Then
                        PeriodCategory = "K"
                    Else
                        PeriodCategory = "3"
                    End If
                End If

                Debug.WriteLine(i & " " & Per.PrdGrpCode & " " & Per.Code)

                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                StatusPrep = True
                Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))

                DsEmp = Global1.Business.SI_File_GetEmployees_MultibleTemplates(TemGrp, Per, SocCat.Code, StatusPrep)

                If Not StatusPrep Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If CheckDataSet(DsEmp) Then
                    '-------------------------------------------------
                    'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                    '--------------------------------------------------
                    total02 = total02 + 1
                    Str02 = "02"
                    'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                    Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                    Str02 = Str02 & SocCat.Code
                    'Change 2016/03/02
                    'OLD Str02 = Str02 & Per.SinPrdCode
                    'NEW 

                    Str02 = Str02 & PeriodCategory

                    If PeriodCategory = "K" Then
                        Str02 = Str02 & Format(Per12DateFrom, "MM/yyyy")
                    Else
                        Dim MM As Integer
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per13DateFrom, "yyyy")
                        Str02 = Str02 & Format(Per13DateFrom, "MM/yyyy")
                        Str02 = Str02 & Format(Per13DateTo, "MM/yyyy")
                    End If

                    Me.WriteToSIFile(Str02, Company)
                    '--------------------------------------------------
                    'END OF 02
                    '--------------------------------------------------

                    '--------------------------------------------------
                    '03 NEW EMPLOYEES
                    '--------------------------------------------------
                    If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            If PeriodCategory = "K" Then
                                Dim EmpCode As String
                                Dim TempPeriodGroup As String
                                Dim TempTemplateGroup As String

                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                                TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                    NumberOfNew = NumberOfNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                    If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                                End If
                        Next
                    End If
                    '--------------------------------------------------
                    'END OF 03
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '04 EMPLOYEES EARNINGS
                    '--------------------------------------------------
                    SemiTotalEmployees = 0
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        SemiTotalEmployees = SemiTotalEmployees + 1
                        Dim EmpCode As String
                        Dim TempPeriodGroup As String
                        Dim TempTemplateGroup As String

                        Dim GrossEarnings As Double = 0
                        Dim InsurableEarnings As Double = 0
                        Dim GesyableEarnings As Double = 0
                        Dim PutZeroToAlienNo As Boolean = False
                        Dim x As Integer
                        Dim GE() As String
                        Dim IE() As String
                        Dim SI() As String
                        Dim Gesyable() As String

                        Dim TermDate As String
                        Dim AbsentReason As String = " "
                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                        TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                        TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                        Dim Emp As New cPrMsEmployees(EmpCode)
                        Str04 = "04"
                        If Emp.SocialInsNumber.Length > 8 Then
                            MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Emp.IdentificationCard.Length > 8 Then
                            MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                            If Emp.AlienNumber.Length > 8 Then
                                Dim Ans As MsgBoxResult
                                Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                If Ans = MsgBoxResult.No Then
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    PutZeroToAlienNo = True
                                End If
                            End If
                        Else
                            If Emp.AlienNumber.Length > 8 Then
                                PutZeroToAlienNo = True
                            End If
                        End If
                        If PutZeroToAlienNo Then
                            Str04 = Str04 & "".PadLeft(8, "0")
                        Else
                            Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                        End If
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim DsGrossInsurable As DataSet
                        Dim Ttemgrp As New cPrMsTemplateGroup(TempTemplateGroup)
                        Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                        'DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)

                        DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(Ttemgrp, TPeriod, EmpCode)
                        If CheckDataSet(DsGrossInsurable) Then
                            GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                            InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                            GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                        End If
                        ''''' NEW FIX FOR AVRAAMIDES '''''
                        Dim DsSLeave As DataSet
                        Dim SIvalue As Double = 0
                        DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        If CheckDataSet(DsSLeave) Then
                            For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                    SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                End If
                            Next
                        End If
                        ''''''''''''''''''''''''''''''''''
                        If GrossEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If

                        GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                        SemitotalGE = SemitotalGE + GrossEarnings
                        GE = Math.Abs(GrossEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")

                        GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)
                        If GesyableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                        If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                            GesyableEarnings = GrossEarnings
                        End If
                        SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                        Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                        If GrossEarnings = 0 Then
                            MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                            Dim F As New FrmSelectLeaveReason
                            F.Owner = Me
                            F.ShowDialog()
                            AbsentReason = Me.GlbAbsentReason
                        Else
                            AbsentReason = " "
                        End If


                        InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                        If InsurableEarnings >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                        If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                            InsurableEarnings = GrossEarnings
                        End If
                        SemiTotalIE = SemiTotalIE + InsurableEarnings
                        IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                        Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                        'SI ***********************************
                        'Dim DsSLeave As DataSet
                        'Dim SIvalue As Double = 0
                        'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSLeave) Then
                        '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                        '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If
                        'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                        'If CheckDataSet(DsSi) Then
                        '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                        '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                        '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                        '        End If
                        '    Next
                        'End If

                        SI = Format(SIvalue, "0.00").ToString.Split(".")
                        Dim S As String
                        S = SI(0) & SI(1)
                        SemitotalSI = SemitotalSI + CInt(S)

                        S = "+" & S.PadLeft(12, "0")



                        Str04 = Str04 & S
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        Str04 = Str04 & AbsentReason
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If PeriodCategory = "K" Then
                                    If CDate(Emp.TerminateDate) < Per12DateFrom Or CDate(Emp.TerminateDate) > Per12DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If

                        Str04 = Str04 & TermDate
                        Str04 = Str04 & 1
                        Me.WriteToSIFile(Str04, Company)
                    Next

                    '--------------------------------------------------
                    'END OF 04
                    '--------------------------------------------------
                    '--------------------------------------------------
                    '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                    '--------------------------------------------------
                    Str05 = "05"
                    If SemitotalGE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                    If SemitotalGesyable >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                    If SemiTotalIE >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                    'SI ************************

                    Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                    Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                    Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                    Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                    Me.WriteToSIFile(Str05, Company)
                    '--------------------------------------------------
                    'END OF 05
                    '--------------------------------------------------

                    GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                    GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                    GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                    GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                    GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                    GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                    GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                End If
            Next
        Next

        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")

        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub



    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim F As New FrmSelectPeriodGroupsForSI

        F.TemGrp = TemGrp
        F.PeriodGroup = PerGroup

        F.ShowDialog()

        Cursor.Current = Cursors.WaitCursor
        PrepareSIFile_SelectionOfPeriodGroups()
        Cursor.Current = Cursors.Default

    End Sub


    Private Sub ShowOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowOnScreenToolStripMenuItem.Click
        ShowThereport(False, False, False)
    End Sub

    Private Sub SendToPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToPrinterToolStripMenuItem.Click
        ShowThereport(True, False, False)
    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBFile.Click
        'PrepareSIFile()
        Me.PrepareSIFile_WITH_N()
    End Sub

    Private Sub CreateMonthlyFileConsolidatePerCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBFile_ConsolPerComp.Click
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim F As New FrmSelectPeriodGroupsForSI

        F.TemGrp = TemGrp
        F.PeriodGroup = PerGroup

        F.ShowDialog()

        Cursor.Current = Cursors.WaitCursor

        PrepareSIFile_SelectionOfPeriodGroups_2()
        Cursor.Current = Cursors.Default

    End Sub
    Private Sub CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateMonthlyFileConsolidatePerCompanyReverse13With12ForSILimitsToolStripMenuItem.Click
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim F As New FrmSelectPeriodGroupsForSI

        F.TemGrp = TemGrp
        F.PeriodGroup = PerGroup

        F.ShowDialog()

        Cursor.Current = Cursors.WaitCursor
        PrepareSIFile_SelectionOfPeriodGroups_Reverse13_12_Sequence()

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CretaMonthlyFileForPeriodWith14SalaryToolStripMenuItem.Click
        PrepareSIFile_NewFor14()
    End Sub

    Private Sub ReportOnlyWithTotalsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportOnlyWithTotalsToolStripMenuItem.Click
        ShowThereport(False, False, True)
    End Sub

    Private Sub SIReportOnlyWithTotalsToPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SIReportOnlyWithTotalsToPrinterToolStripMenuItem.Click
        ShowThereport(True, False, True)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String
        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("URL", "SI")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            str = Par.Value1
        Else
            MsgBox("Missing Parameter , 'URL','SI' Social Insurance Payment URL is missing'", MsgBoxStyle.Critical)
        End If
        If str <> "" Then
            ShowWeb(str)
        End If
    End Sub
    Private Sub ShowWeb(ByVal Str As String)
        System.Diagnostics.Process.Start(Str)


    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
        Me.PrepareSIFile_Reverse13_12_Sequence()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Process.Start(SIFileDir)
    End Sub

    Private Sub TestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem1.Click
        Me.PrepareSIFile_WITH_N()
    End Sub

    Private Sub MultibleSINumbersFileWithOldSpecsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultibleSINumbersFileWithOldSpecsToolStripMenuItem.Click
        PrepareSIFile_2_OLDSpecs()
    End Sub

    Private Sub CBShowALLYears_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBShowALLYears.CheckedChanged
        Me.LoadPeriodGroup()
    End Sub

    Private Sub CreateMonthlyFileBasedOnYearPeriodsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBFile_BasedOnActual.Click
        If Me.CBSwitchToPeriod.Checked Then
            Me.PrepareSIFile_WITH_N_BasedOnActualPeriods()
        Else
            MsgBox("For this option you must check the Checkbox 'Click here for the option to create separate report for 12 and 13 Salary'", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub PrepareSIFile_WITH_N_BasedOnActualPeriods()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet

        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Replace(Format(Now.Date, "dd/MM/yyyy"), "-", "/")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGESYable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGESYable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0

        Dim total02 As Integer
        Dim total_N_02 As Integer
        Dim total_X_02 As Integer

        Dim AlValueIsBK As Boolean = False

        If PARAM_CobaltALCode <> "" Then
            Dim Ern As New cPrMsEarningCodes(PARAM_CobaltALCode)
            If Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Then
                AlValueIsBK = True
            End If
        End If

        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories

        Dim Per As New cPrMsPeriodCodes
        Per = CType(Me.ComboPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim Reverse1213 As Boolean = False
        SIPer = New cPrSsSocialInsPeriods(Per.SinPrdCode)


        If Per.SinPrdCode = "12" Then
            Dim TotalPeriods As Integer
            TotalPeriods = Per.NumberOfTotalPeriodsFORDisplayONLY
            If TotalPeriods > 12 Then
                Dim Ans As MsgBoxResult
                Ans = MsgBox("Declare 12 as 13 Period and vice versa for SISNET system purpose?", MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then
                    Reverse1213 = True
                End If
            End If
        End If


        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            Dim Create_N_Record As Boolean = False
            Dim Create_X_Record As Boolean = False

            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            ' DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)
            'For j = 0 To DSPeriods.Tables(0).Rows.Count - 1



            'Per = New cPrMsPeriodCodes(DSPeriods.Tables(0).Rows(j))



            NumberOfTerm = 0
            NumberOfNew = 0
            SemiTotalIE = 0
            SemitotalGE = 0
            SemitotalSI = 0
            SemitotalGESYable = 0
            SemiTotalEmployees = 0
            StatusPrep = True
            Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
            DsEmp = Global1.Business.SI_File_GetEmployees(TemGrp, Per, SocCat.Code, StatusPrep)
            If Not StatusPrep Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If CheckDataSet(DsEmp) Then
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------
                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 

                If Not Reverse1213 Then
                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Per.PayCat_Code
                        Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Else
                        Str02 = Str02 & Per.PayCat_Code
                        Dim MM As Integer
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    End If
                Else
                    If Per.PayCat_Code <> "K" Then
                        Str02 = Str02 & "K"
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Else
                        Dim MM As Integer
                        Str02 = Str02 & "3"
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & "01" & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    End If

                End If

                Me.WriteToSIFile(Str02, Company)
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------

                '--------------------------------------------------
                '03 NEW EMPLOYEES
                '--------------------------------------------------
                If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        If Per.PayCat_Code = "K" Then
                            Dim EmpCode As String
                            EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                            Dim PutZeroToAlienNo As Boolean = False
                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                NumberOfNew = NumberOfNew + 1
                                Str03 = "03"
                                If Emp.SocialInsNumber.Length > 8 Then
                                    MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                If Emp.IdentificationCard.Length > 8 Then
                                    MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                    If Emp.AlienNumber.Length > 8 Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                        If Ans = MsgBoxResult.No Then
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                Else
                                    If Emp.AlienNumber.Length > 8 Then
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                                If PutZeroToAlienNo Then
                                        Str03 = Str03 & "".PadLeft(8, "0")
                                        PutZeroToAlienNo = False
                                    Else
                                        Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                    End If

                                    If Emp.PassportNumber.Length > 10 Then
                                        MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                    Str03 = Str03 & "".PadRight(10, " ")

                                    Dim EmpFull As String
                                    EmpFull = Emp.FirstName & " " & Emp.LastName
                                    If EmpFull.Length > 30 Then
                                        EmpFull = EmpFull.Substring(0, 29)
                                    End If
                                    Str03 = Str03 & EmpFull.PadRight(30, " ")
                                    Str03 = Str03 & Replace(Format(Emp.BirthDate, "dd/MM/yyyy"), "-", "/")
                                    Str03 = Str03 & Emp.Sex
                                    Str03 = Str03 & Emp.EmpCmm_Code
                                    Str03 = Str03 & Replace(Format(Emp.StartDate, "dd/MM/yyyy"), "-", "/")
                                    Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                    'If SIleave Then
                                    If Emp.IsSI = 0 Then
                                        Str03 = Str03 & "1"
                                    Else
                                        Str03 = Str03 & "0"
                                    End If
                                    Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                    Dim Position As String
                                    Position = EmpPos.DescriptionL
                                    If Position.Length > 25 Then
                                        Position = Position.Substring(0, 24)
                                    End If
                                    Str03 = Str03 & Position.PadRight(25, " ")
                                    Me.WriteToSIFile(Str03, Company)
                                End If
                            End If
                    Next
                End If
                '--------------------------------------------------
                'END OF 03
                '--------------------------------------------------
                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                    SemiTotalEmployees = SemiTotalEmployees + 1
                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String



                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim ALValue As Double = 0



                    If PARAM_CobaltALCode <> "" Then
                        ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, Per, EmpCode)
                        If ALValue <> 0 Then
                            Create_N_Record = True
                            total_N_02 = total_N_02 + 1
                        End If
                    End If
                    Dim BIKWithSCValue As Double = 0
                    If PARAM_BIKWithSCCode <> "" Then
                        BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, Per, EmpCode)
                        If BIKWithSCValue <> 0 Then
                            Create_X_Record = True
                            total_X_02 = total_X_02 + 1
                        End If
                    End If

                    DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TempTempGroup, Per, EmpCode)

                    If CheckDataSet(DsGrossInsurable) Then
                        'If AlValueIsBK Then
                        'GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                        'Else
                        GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0)) - ALValue
                        'End If
                        InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                        GESYableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                    End If
                    ''''' NEW FIX FOR AVRAAMIDES '''''
                    Dim DsSLeave As DataSet
                    Dim SIvalue As Double = 0
                    DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    If CheckDataSet(DsSLeave) Then
                        For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                            If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                            End If
                        Next
                    End If
                    ''''''''''''''''''''''''''''''''''


                    GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)

                    If GrossEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    GE = Math.Abs(GrossEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                    SemitotalGE = SemitotalGE + GrossEarnings



                    If GrossEarnings = 0 Then
                        MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                        Dim F As New FrmSelectLeaveReason
                        F.Owner = Me
                        F.ShowDialog()
                        AbsentReason = Me.GlbAbsentReason
                    Else
                        AbsentReason = " "
                    End If


                    GESYableEarnings = RoundMe3(GESYableEarnings - SIvalue, 2)
                    GESYableEarnings = Utils.RoundMe3(GESYableEarnings, 0)
                    If Math.Abs(GESYableEarnings - GrossEarnings) = 1 Then
                        GESYableEarnings = GrossEarnings
                    End If
                    SemitotalGESYable = SemitotalGESYable + GESYableEarnings

                    Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                    If GESYableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                    InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)
                    InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)

                    If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                        InsurableEarnings = GrossEarnings
                    End If

                    SemiTotalIE = SemiTotalIE + InsurableEarnings


                    IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                    If InsurableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                    'SI ***********************************
                    'Dim DsSLeave As DataSet
                    'Dim SIvalue As Double = 0
                    'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSLeave) Then
                    '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                    '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If
                    'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSi) Then
                    '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                    '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If

                    SI = Format(SIvalue, "0.00").ToString.Split(".")
                    Dim S As String
                    S = SI(0) & SI(1)
                    SemitotalSI = SemitotalSI + CInt(S)

                    S = "+" & S.PadLeft(12, "0")



                    Str04 = Str04 & S
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    If Not Reverse1213 Then
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Replace(Format(CDate(Emp.TerminateDate), "dd/MM/yyyy"), "-", "/")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                    Else
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code <> "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Replace(Format(CDate(Emp.TerminateDate), "dd/MM/yyyy"), "-", "/")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                    End If
                        Str04 = Str04 & TermDate
                    Str04 = Str04 & 1
                    Me.WriteToSIFile(Str04, Company)
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGESYable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

            End If

            If Create_N_Record Then
                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGESYable = 0
                SemiTotalEmployees = 0
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------

                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 
                Str02 = Str02 & "N"

                If Not Reverse1213 Then
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)

                End If
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------


                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String



                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim ALValue As Double = 0
                    If PARAM_CobaltALCode <> "" Then
                        ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, Per, EmpCode)
                        If ALValue <> 0 Then
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            GrossEarnings = Utils.RoundMe3(ALValue, 0)
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                            SemitotalGE = SemitotalGE + GrossEarnings
                            GESYableEarnings = RoundMe3(0, 2)
                            SemitotalGESYable = SemitotalGESYable + GESYableEarnings
                            Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                            If GESYableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                            InsurableEarnings = RoundMe3(0, 2)
                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            SI = Format(0, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")
                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            TermDate = "          "
                            Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        End If
                    End If
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGESYable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



            End If ' END OF Create_N_record



            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            'x Record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            If Create_X_Record Then
                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGESYable = 0
                SemiTotalEmployees = 0
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------

                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 
                Str02 = Str02 & "X"

                If Not Reverse1213 Then
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)

                End If
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------


                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String



                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim BIKWithSCValue As Double = 0
                    If PARAM_BIKWithSCCode <> "" Then
                        BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, Per, EmpCode)
                        If BIKWithSCValue <> 0 Then
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            GrossEarnings = Utils.RoundMe3(BIKWithSCValue, 0)
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                            SemitotalGE = SemitotalGE + GrossEarnings
                            GESYableEarnings = RoundMe3(0, 2)
                            SemitotalGESYable = SemitotalGESYable + GESYableEarnings
                            Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                            If GESYableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                            InsurableEarnings = RoundMe3(0, 2)
                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            SI = Format(0, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")
                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            TermDate = "          "
                            Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        End If
                    End If
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGESYable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGESYable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGESYable = GRAND_SemiTotalGESYable + SemitotalGESYable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



            End If ' END OF Create_N_record


            'END of X record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        Next


        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")



        If GRAND_SemiTotalGESYable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGESYable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub
    Private Sub CreateMonthlyFileMultibleSINumbersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBFile_MultibleSI.Click
        PrepareSIFile_2()
    End Sub

    Private Sub CreateMonthlyFileMultibleSINumbersBasedOnActualYearPeriodsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBFile_MultibleSI_BasedOnActual.Click
        If Me.CBSwitchToPeriod.Checked Then
            Me.PrepareSIFile_MultibleSINos_BasedOnActualPeriods()
        Else
            MsgBox("For this option you must check the Checkbox 'Click here for the option to create separate report for 12 and 13 Salary'", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub PrepareSIFile_MultibleSINos_BasedOnActualPeriods()
        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet

        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfSemiTerm As Integer = 0
        Dim NumberOfSemiNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_SemiNumberOfTerm As Integer = 0
        Dim GRAND_SemiNumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0


        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_TotalIE As Integer = 0
        Dim GRAND_totalGE As Integer = 0
        Dim GRAND_TotalSI As Integer = 0
        Dim GRAND_TotalGesyable As Integer = 0
        Dim GRAND_TotalEmployees As Integer = 0


        Dim total02 As Integer
        Dim Sign As String
        Dim y As Integer = 0



        Dim Per As New cPrMsPeriodCodes
        Per = CType(Me.ComboPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim Reverse1213 As Boolean = False
        SIPer = New cPrSsSocialInsPeriods(Per.SinPrdCode)


        If Per.SinPrdCode = "12" Then
            Dim TotalPeriods As Integer
            TotalPeriods = Per.NumberOfTotalPeriodsFORDisplayONLY
            If TotalPeriods > 12 Then
                Dim Ans As MsgBoxResult
                Ans = MsgBox("Declare 12 as 13 Period and vice versa for SISNET system purpose?", MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then
                    Reverse1213 = True
                End If
            End If
        End If


        For y = 0 To 4
            Dim SIReg1to5 As String

            Select Case y
                Case 0
                    SIReg1to5 = Company.SIRegNo
                Case 1
                    SIReg1to5 = Company.SI2
                Case 2
                    SIReg1to5 = Company.SI3
                Case 3
                    SIReg1to5 = Company.SI4
                Case 4
                    SIReg1to5 = Company.SI5
            End Select
            If SIReg1to5 <> "" Then
                Dim StatusPrep As Boolean
                DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
                For i = 0 To DSSocCat.Tables(0).Rows.Count - 1



                    NumberOfSemiTerm = 0
                    NumberOfSemiNew = 0
                    SemiTotalIE = 0
                    SemitotalGE = 0
                    SemitotalSI = 0
                    SemitotalGesyable = 0
                    SemiTotalEmployees = 0
                    StatusPrep = True
                    Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))
                    DsEmp = Global1.Business.SI_File_GetEmployees_2(TemGrp, Per, SocCat.Code, StatusPrep, SIReg1to5)
                    If Not StatusPrep Then
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    If CheckDataSet(DsEmp) Then
                        '-------------------------------------------------
                        'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                        '--------------------------------------------------
                        total02 = total02 + 1
                        Str02 = "02"
                        'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                        Str02 = Str02 & SIReg1to5.PadLeft(15, "0")
                        Str02 = Str02 & SocCat.Code
                        'Change 2016/03/02
                        'OLD Str02 = Str02 & Per.SinPrdCode
                        'NEW 

                        If Not Reverse1213 Then
                            If Per.PayCat_Code = "K" Then
                                Str02 = Str02 & Per.PayCat_Code
                                Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                            Else
                                Str02 = Str02 & Per.PayCat_Code
                                Dim MM As Integer
                                MM = Per.DateFrom.Month + 12
                                Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                                Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                                Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                            End If
                        Else
                            If Per.PayCat_Code <> "K" Then
                                Str02 = Str02 & "K"
                                Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                            Else
                                Dim MM As Integer
                                Str02 = Str02 & "3"
                                MM = Per.DateFrom.Month + 12
                                MM = CInt(SIPer.Code) + 12
                                Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                                Str02 = Str02 & "01" & "/" & Format(Per.DateFrom, "yyyy")
                                Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                            End If
                        End If
                        Me.WriteToSIFile(Str02, Company)
                        '--------------------------------------------------
                        'END OF 02
                        '--------------------------------------------------

                        '--------------------------------------------------
                        '03 NEW EMPLOYEES
                        '--------------------------------------------------
                        If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                            For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                                Dim EmpCode As String
                                EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                                Dim PutZeroToAlienNo As Boolean = False
                                Dim Emp As New cPrMsEmployees(EmpCode)
                                If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                    NumberOfSemiNew = NumberOfSemiNew + 1
                                    Str03 = "03"
                                    If Emp.SocialInsNumber.Length > 8 Then
                                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                    If Emp.IdentificationCard.Length > 8 Then
                                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                        If Emp.AlienNumber.Length > 8 Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                            If Ans = MsgBoxResult.No Then
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            Else
                                                PutZeroToAlienNo = True
                                            End If
                                        End If
                                    Else
                                        If Emp.AlienNumber.Length > 8 Then
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                    If PutZeroToAlienNo Then
                                            Str03 = Str03 & "".PadLeft(8, "0")
                                            PutZeroToAlienNo = False
                                        Else
                                            Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                        End If

                                        If Emp.PassportNumber.Length > 10 Then
                                            MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        End If
                                        'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                        Str03 = Str03 & "".PadRight(10, " ")

                                        Dim EmpFull As String
                                        EmpFull = Emp.FirstName & " " & Emp.LastName
                                        If EmpFull.Length > 30 Then
                                            EmpFull = EmpFull.Substring(0, 29)
                                        End If
                                        Str03 = Str03 & EmpFull.PadRight(30, " ")
                                        Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.Sex
                                        Str03 = Str03 & Emp.EmpCmm_Code
                                        Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                        Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                        'If SIleave Then
                                        If Emp.IsSI = 0 Then
                                            Str03 = Str03 & "1"
                                        Else
                                            Str03 = Str03 & "0"
                                        End If
                                        Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                        Dim Position As String
                                        Position = EmpPos.DescriptionL
                                        If Position.Length > 25 Then
                                            Position = Position.Substring(0, 24)
                                        End If
                                        Str03 = Str03 & Position.PadRight(25, " ")
                                        Me.WriteToSIFile(Str03, Company)
                                    End If
                            Next
                        End If
                        '--------------------------------------------------
                        'END OF 03
                        '--------------------------------------------------
                        '--------------------------------------------------
                        '04 EMPLOYEES EARNINGS
                        '--------------------------------------------------
                        SemiTotalEmployees = 0
                        For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            Dim EmpCode As String
                            Dim GrossEarnings As Double = 0
                            Dim InsurableEarnings As Double = 0
                            Dim GesyableEarnings As Double = 0
                            Dim PutZeroToAlienNo As Boolean = False
                            Dim x As Integer
                            Dim GE() As String
                            Dim IE() As String
                            Dim SI() As String
                            Dim Gesyable() As String

                            Dim TermDate As String
                            Dim AbsentReason As String = " "
                            EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                            Dim Emp As New cPrMsEmployees(EmpCode)
                            Str04 = "04"
                            If Emp.SocialInsNumber.Length > 8 Then
                                MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                            Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If Emp.IdentificationCard.Length > 8 Then
                                MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                            Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                If Emp.AlienNumber.Length > 8 Then
                                    Dim Ans As MsgBoxResult
                                    Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                    If Ans = MsgBoxResult.No Then
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    Else
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                            Else
                                If Emp.AlienNumber.Length > 8 Then
                                    PutZeroToAlienNo = True
                                End If
                            End If
                            If PutZeroToAlienNo Then
                                Str04 = Str04 & "".PadLeft(8, "0")
                            Else
                                Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                            End If
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim DsGrossInsurable As DataSet
                            DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)
                            If CheckDataSet(DsGrossInsurable) Then
                                GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0))
                                InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                                GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))
                            End If
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Dim DsSLeave As DataSet
                            Dim SIvalue As Double = 0
                            DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                            If CheckDataSet(DsSLeave) Then
                                For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                                    If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                        SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                                    End If
                                Next
                            End If

                            GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                            SemitotalGE = SemitotalGE + GrossEarnings
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")


                            GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)
                            If GesyableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                            If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                                GesyableEarnings = GrossEarnings
                            End If

                            SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                            Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")



                            InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If

                            If GrossEarnings = 0 Then
                                MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                                Dim F As New FrmSelectLeaveReason
                                F.Owner = Me
                                F.ShowDialog()
                                AbsentReason = Me.GlbAbsentReason
                            Else
                                AbsentReason = " "
                            End If

                            InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                            If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                                InsurableEarnings = GrossEarnings
                                'MsgBox(EmpCode, InsurableEarnings, GrossEarnings)
                            End If



                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            'SI ***********************************
                            'Dim DsSLeave As DataSet
                            'Dim SIvalue As Double = 0
                            'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                            'If CheckDataSet(DsSLeave) Then
                            '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                            '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                            '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                            '        End If
                            '    Next
                            'End If
                            'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                            'If CheckDataSet(DsSi) Then
                            '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                            '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                            '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                            '        End If
                            '    Next
                            'End If

                            SI = Format(SIvalue, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")



                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            If Not Reverse1213 Then
                                TermDate = "          "
                                If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                                    If Trim(Emp.TerminateDate) <> "" Then
                                        If Per.PayCat_Code = "K" Then
                                            If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                                TermDate = "          "
                                            Else
                                                TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                                NumberOfSemiTerm = NumberOfSemiTerm + 1
                                            End If
                                        Else
                                            TermDate = "          "
                                        End If
                                    Else
                                        TermDate = "          "
                                    End If
                                End If
                            Else
                                TermDate = "          "
                                If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                                    If Trim(Emp.TerminateDate) <> "" Then
                                        If Per.PayCat_Code <> "K" Then
                                            If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                                TermDate = "          "
                                            Else
                                                TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                                NumberOfSemiTerm = NumberOfSemiTerm + 1
                                            End If
                                        Else
                                            TermDate = "          "
                                        End If
                                    Else
                                        TermDate = "          "
                                    End If
                                End If
                            End If
                                Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        Next

                        '--------------------------------------------------
                        'END OF 04
                        '--------------------------------------------------
                        '--------------------------------------------------
                        '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                        '--------------------------------------------------
                        Str05 = "05"
                        If SemitotalGE >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                        If SemitotalGesyable >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")



                        If SemiTotalIE >= 0 Then
                            Sign = "+"
                        Else
                            Sign = "-"
                        End If
                        Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                        'SI ************************

                        Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                        Str05 = Str05 & NumberOfSemiNew.ToString.PadLeft(5, "0")
                        Str05 = Str05 & NumberOfSemiTerm.ToString.PadLeft(5, "0")
                        Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                        Me.WriteToSIFile(Str05, Company)
                        '--------------------------------------------------
                        'END OF 05
                        '--------------------------------------------------

                        GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfSemiNew
                        GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfSemiTerm
                        GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                        GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                        GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                        GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                        GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

                    End If
                Next

            End If
        Next



        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")

        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------





        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default

    End Sub


    Private Sub CreateMontlhyFileConsolidatePerCompanyBasedOnActualYearPeriodsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBFile_ConsolPerComp_BasedOnActual.Click
        If Me.CBSwitchToPeriod.Checked Then
            Dim DSPeriods As DataSet
            Dim PerGroup As cPrMsPeriodGroups
            PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            Dim F As New FrmSelectPeriodGroupsForSI
            F.TemGrp = TemGrp
            F.PeriodGroup = PerGroup
            F.ShowDialog()
            Cursor.Current = Cursors.WaitCursor

            PrepareSIFile_SelectionOfPeriodGroups_2_BasedOnActualPeriods()
            Cursor.Current = Cursors.Default
        Else
            MsgBox("For this option you must check the Checkbox 'Click here for the option to create separate report for 12 and 13 Salary'", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub PrepareSIFile_SelectionOfPeriodGroups_2_BasedOnActualPeriods()

        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0

        Dim total02 As Integer
        Dim total_N_02 As Integer
        Dim total_X_02 As Integer

        Dim AlValueIsBK As Boolean = False

        If PARAM_CobaltALCode <> "" Then
            Dim Ern As New cPrMsEarningCodes(PARAM_CobaltALCode)
            If Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Then
                AlValueIsBK = True
            End If
        End If

        Dim Per As New cPrMsPeriodCodes
        Per = CType(Me.ComboPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim Reverse1213 As Boolean = False
        SIPer = New cPrSsSocialInsPeriods(Per.SinPrdCode)


        If Per.SinPrdCode = "12" Then
            Dim TotalPeriods As Integer
            TotalPeriods = Per.NumberOfTotalPeriodsFORDisplayONLY
            If TotalPeriods > 12 Then
                Dim Ans As MsgBoxResult
                Ans = MsgBox("Declare 12 as 13 Period and vice versa for SISNET system purpose?", MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then
                    Reverse1213 = True
                End If
            End If
        End If




        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            Dim Create_N_Record As Boolean = False
            Dim Create_X_Record As Boolean = False
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)


            Debug.WriteLine(i & " " & Per.PrdGrpCode & " " & Per.Code)

            NumberOfTerm = 0
            NumberOfNew = 0
            SemiTotalIE = 0
            SemitotalGE = 0
            SemitotalSI = 0
            SemitotalGesyable = 0
            SemiTotalEmployees = 0
            StatusPrep = True
            Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))

            DsEmp = Global1.Business.SI_File_GetEmployees_MultibleTemplates(TemGrp, Per, SocCat.Code, StatusPrep)

            If Not StatusPrep Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If CheckDataSet(DsEmp) Then
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------
                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 

                If Not Reverse1213 Then
                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Per.PayCat_Code
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                    Else
                        Str02 = Str02 & Per.PayCat_Code
                        Dim MM As Integer
                        'MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                        Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                Else
                    If Per.PayCat_Code <> "K" Then
                        Str02 = Str02 & "K"
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Else
                        Dim MM As Integer
                        Str02 = Str02 & "3"
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & "01" & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                End If
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------

                '--------------------------------------------------
                '03 NEW EMPLOYEES
                '--------------------------------------------------
                If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        If Per.PayCat_Code = "K" Then
                            Dim EmpCode As String
                            Dim TempPeriodGroup As String
                            Dim TempTemplateGroup As String


                            EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                            TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                            TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                            Dim PutZeroToAlienNo As Boolean = False
                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                NumberOfNew = NumberOfNew + 1
                                Str03 = "03"
                                If Emp.SocialInsNumber.Length > 8 Then
                                    MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                If Emp.IdentificationCard.Length > 8 Then
                                    MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                    If Emp.AlienNumber.Length > 8 Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                        If Ans = MsgBoxResult.No Then
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                Else
                                    If Emp.AlienNumber.Length > 8 Then
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                                If PutZeroToAlienNo Then
                                        Str03 = Str03 & "".PadLeft(8, "0")
                                        PutZeroToAlienNo = False
                                    Else
                                        Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                    End If

                                    If Emp.PassportNumber.Length > 10 Then
                                        MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                    Str03 = Str03 & "".PadRight(10, " ")

                                    Dim EmpFull As String
                                    EmpFull = Emp.FirstName & " " & Emp.LastName
                                    If EmpFull.Length > 30 Then
                                        EmpFull = EmpFull.Substring(0, 29)
                                    End If
                                    Str03 = Str03 & EmpFull.PadRight(30, " ")
                                    Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                    Str03 = Str03 & Emp.Sex
                                    Str03 = Str03 & Emp.EmpCmm_Code
                                    Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                    Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                    'If SIleave Then
                                    If Emp.IsSI = 0 Then
                                        Str03 = Str03 & "1"
                                    Else
                                        Str03 = Str03 & "0"
                                    End If
                                    Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                    Dim Position As String
                                    Position = EmpPos.DescriptionL
                                    If Position.Length > 25 Then
                                        Position = Position.Substring(0, 24)
                                    End If
                                    Str03 = Str03 & Position.PadRight(25, " ")
                                    Me.WriteToSIFile(Str03, Company)
                                End If
                            End If
                    Next
                End If
                '--------------------------------------------------
                'END OF 03
                '--------------------------------------------------
                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                    SemiTotalEmployees = SemiTotalEmployees + 1
                    Dim EmpCode As String
                    Dim TempPeriodGroup As String
                    Dim TempTemplateGroup As String


                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GesyableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String


                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                    TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim Ttemgrp As New cPrMsTemplateGroup(TempTemplateGroup)
                    Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)
                    Dim ALValue As Double = 0

                    'xxxxxxxxxxxxxxx()
                    If PARAM_CobaltALCode <> "" Then
                        ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(Ttemgrp, TPeriod, EmpCode)
                        If ALValue <> 0 Then
                            Create_N_Record = True
                            total_N_02 = total_N_02 + 1
                        End If
                    End If
                    Dim BIKWithSCValue As Double = 0
                    If PARAM_BIKWithSCCode <> "" Then
                        BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(Ttemgrp, TPeriod, EmpCode)
                        If BIKWithSCValue <> 0 Then
                            Create_X_Record = True
                            total_X_02 = total_X_02 + 1
                        End If
                    End If
                    'DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)

                    DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(Ttemgrp, TPeriod, EmpCode)
                    If CheckDataSet(DsGrossInsurable) Then
                        GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0)) - ALValue
                        InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                        GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))

                    End If
                    ''''' NEW FIX FOR AVRAAMIDES '''''
                    Dim DsSLeave As DataSet
                    Dim SIvalue As Double = 0
                    DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(TPeriod, "SI")
                    If CheckDataSet(DsSLeave) Then
                        For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                            If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                            End If
                        Next
                    End If
                    ''''''''''''''''''''''''''''''''''
                    If GrossEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If

                    GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                    SemitotalGE = SemitotalGE + GrossEarnings
                    GE = Math.Abs(GrossEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")

                    GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)

                    If GesyableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                    If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                        GesyableEarnings = GrossEarnings
                    End If
                    SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                    Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                    If GrossEarnings = 0 Then
                        MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                        Dim F As New FrmSelectLeaveReason
                        F.Owner = Me
                        F.ShowDialog()
                        AbsentReason = Me.GlbAbsentReason
                    Else
                        AbsentReason = " "
                    End If

                    InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                    If InsurableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                    If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                        InsurableEarnings = GrossEarnings
                    End If
                    SemiTotalIE = SemiTotalIE + InsurableEarnings
                    IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                    'SI ***********************************
                    'Dim DsSLeave As DataSet
                    'Dim SIvalue As Double = 0
                    'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSLeave) Then
                    '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                    '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If
                    'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSi) Then
                    '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                    '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If

                    SI = Format(SIvalue, "0.00").ToString.Split(".")
                    Dim S As String
                    S = SI(0) & SI(1)
                    SemitotalSI = SemitotalSI + CInt(S)

                    S = "+" & S.PadLeft(12, "0")



                    Str04 = Str04 & S
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    If Not Reverse1213 Then
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                    Else
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code <> "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                    End If
                        Str04 = Str04 & TermDate
                    Str04 = Str04 & 1
                    Me.WriteToSIFile(Str04, Company)
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

            End If

            If Create_N_Record Then
                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------

                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 

                Str02 = Str02 & "N"
                If Not Reverse1213 Then
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)

                End If
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------


                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String





                    Dim TermDate As String
                    Dim AbsentReason As String = " "

                    Dim TempPeriodGroup As String
                    Dim TempTemplateGroup As String
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                    TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                    Dim ALValue As Double = 0
                    If PARAM_CobaltALCode <> "" Then
                        ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, TPeriod, EmpCode)
                        If ALValue <> 0 Then
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            GrossEarnings = Utils.RoundMe3(ALValue, 0)
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                            SemitotalGE = SemitotalGE + GrossEarnings
                            GESYableEarnings = RoundMe3(0, 2)
                            SemitotalGesyable = SemitotalGesyable + GESYableEarnings
                            Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                            If GESYableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                            InsurableEarnings = RoundMe3(0, 2)
                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            SI = Format(0, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")
                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            TermDate = "          "
                            Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        End If
                    End If
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



            End If ' END OF Create_N_record



            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            'x Record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            If Create_X_Record Then
                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------

                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 
                Str02 = Str02 & "X"

                If Not Reverse1213 Then
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                End If

                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------


                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String



                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    Dim TempPeriodGroup As String
                    Dim TempTemplateGroup As String
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                    TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))


                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                    Dim BIKWithSCValue As Double = 0
                    If PARAM_BIKWithSCCode <> "" Then
                        BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, TPeriod, EmpCode)
                        If BIKWithSCValue <> 0 Then
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            GrossEarnings = Utils.RoundMe3(BIKWithSCValue, 0)
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                            SemitotalGE = SemitotalGE + GrossEarnings
                            GESYableEarnings = RoundMe3(0, 2)
                            SemitotalGesyable = SemitotalGesyable + GESYableEarnings
                            Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                            If GESYableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                            InsurableEarnings = RoundMe3(0, 2)
                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            SI = Format(0, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")
                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            TermDate = "          "
                            Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        End If
                    End If
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



            End If ' END OF Create_N_record


            'END of X record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






        Next


        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default


    End Sub

    Private Sub TestToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem2.Click

        If Me.CBSwitchToPeriod.Checked Then
            Dim DSPeriods As DataSet
            Dim PerGroup As cPrMsPeriodGroups
            PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)
            Dim F As New FrmSelectPeriodGroupsForSI
            F.TemGrp = TemGrp
            F.PeriodGroup = PerGroup
            F.ShowDialog()
            Cursor.Current = Cursors.WaitCursor

            PrepareSIFile_SelectionOfPeriodGroups_2_BasedOnActualPeriods_Test()
            Cursor.Current = Cursors.Default
        Else
            MsgBox("For this option you must check the Checkbox 'Click here for the option to create separate report for 12 and 13 Salary'", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub PrepareSIFile_SelectionOfPeriodGroups_2_BasedOnActualPeriods_Test()

        Me.Cursor = Cursors.WaitCursor
        Dim SIPer As New cPrSsSocialInsPeriods
        Dim ds As DataSet
        SIPer = CType(Me.CmbSIPeriod.SelectedItem, cPrSsSocialInsPeriods)
        Dim DSPeriods As DataSet
        Dim PerGroup As cPrMsPeriodGroups
        PerGroup = CType(Me.cmbPeriodGroups.SelectedItem, cPrMsPeriodGroups)


        Dim Company As New cAdMsCompany(TemGrp.CompanyCode)

        InitFile = True
        InitFile2 = True

        Dim Str01 As String
        'Kodikas eidodou 01
        Str01 = "01"
        Str01 = Str01 & "S.I.S. SCHEDULE".PadRight(25, " ")
        Str01 = Str01 & "01"
        Str01 = Str01 & Format(Now.Date, "dd/MM/yyyy")
        Str01 = Str01 & Company.AccountantTitle.PadRight(30, " ")
        Str01 = Str01 & Company.Tel1.PadRight(20, " ")
        WriteToSIFile(Str01, Company)

        Dim DsEmp As DataSet
        Dim DSSocCat As DataSet
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim Str02 As String
        Dim Str03 As String
        Dim Str04 As String
        Dim Str05 As String
        Dim Str06 As String

        Dim NumberOfTerm As Integer = 0
        Dim NumberOfNew As Integer = 0
        Dim SemiTotalIE As Integer = 0
        Dim SemitotalGE As Integer = 0
        Dim SemitotalSI As Integer = 0
        Dim SemitotalGesyable As Integer = 0

        Dim SemiTotalEmployees As Integer = 0

        Dim GRAND_NumberOfTerm As Integer = 0
        Dim GRAND_NumberOfNew As Integer = 0
        Dim GRAND_SemiTotalIE As Integer = 0
        Dim GRAND_SemitotalGE As Integer = 0
        Dim GRAND_SemiTotalSI As Integer = 0
        Dim GRAND_SemiTotalGesyable As Integer = 0

        Dim GRAND_SemiTotalEmployees As Integer = 0

        Dim total02 As Integer
        Dim total_N_02 As Integer
        Dim total_X_02 As Integer

        Dim AlValueIsBK As Boolean = False

        If PARAM_CobaltALCode <> "" Then
            Dim Ern As New cPrMsEarningCodes(PARAM_CobaltALCode)
            If Ern.ErnTypCode = "BK" Or Ern.ErnTypCode = "BR" Then
                AlValueIsBK = True
            End If
        End If

        Dim Per As New cPrMsPeriodCodes
        Per = CType(Me.ComboPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim Reverse1213 As Boolean = False
        SIPer = New cPrSsSocialInsPeriods(Per.SinPrdCode)


        If Per.SinPrdCode = "12" Then
            Dim TotalPeriods As Integer
            TotalPeriods = Per.NumberOfTotalPeriodsFORDisplayONLY
            If TotalPeriods > 12 Then
                Dim Ans As MsgBoxResult
                Ans = MsgBox("Declare 12 as 13 Period and vice versa for SISNET system purpose?", MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then
                    Reverse1213 = True
                End If
            End If
        End If




        Dim Sign As String
        Dim StatusPrep As Boolean
        DSSocCat = Global1.Business.AG_GetAllPrAnSocialInsCategories
        For i = 0 To DSSocCat.Tables(0).Rows.Count - 1
            Dim Create_N_Record As Boolean = False
            Dim Create_X_Record As Boolean = False
            'DSPeriods = Global1.Business.GetAllPeriodsOF_SIPeriod(SIPer.Code, TemGrp.Code, PerGroup.Code)


            Debug.WriteLine(i & " " & Per.PrdGrpCode & " " & Per.Code)

            NumberOfTerm = 0
            NumberOfNew = 0
            SemiTotalIE = 0
            SemitotalGE = 0
            SemitotalSI = 0
            SemitotalGesyable = 0
            SemiTotalEmployees = 0
            StatusPrep = True
            Dim SocCat As New cPrAnSocialInsCategories(DSSocCat.Tables(0).Rows(i))

            DsEmp = Global1.Business.SI_File_GetEmployees_MultibleTemplates(TemGrp, Per, SocCat.Code, StatusPrep)

            If Not StatusPrep Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If CheckDataSet(DsEmp) Then
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------
                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 

                If Not Reverse1213 Then
                    If Per.PayCat_Code = "K" Then
                        Str02 = Str02 & Per.PayCat_Code
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                    Else
                        Str02 = Str02 & Per.PayCat_Code
                        Dim MM As Integer
                        'MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Format(Per.DateFrom, "MM/yyyy")
                        Str02 = Str02 & Format(Per.DateTo, "MM/yyyy")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                Else
                    If Per.PayCat_Code <> "K" Then
                        Str02 = Str02 & "K"
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Else
                        Dim MM As Integer
                        Str02 = Str02 & "3"
                        MM = Per.DateFrom.Month + 12
                        MM = CInt(SIPer.Code) + 12
                        Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & "01" & "/" & Format(Per.DateFrom, "yyyy")
                        Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    End If
                    Me.WriteToSIFile(Str02, Company)
                End If
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------

                '--------------------------------------------------
                '03 NEW EMPLOYEES
                '--------------------------------------------------
                If Me.CBExcludeNewEmployees.CheckState = CheckState.Unchecked Then
                    For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                        If Per.PayCat_Code = "K" Then
                            Dim EmpCode As String
                            Dim TempPeriodGroup As String
                            Dim TempTemplateGroup As String


                            EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                            TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                            TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                            Dim PutZeroToAlienNo As Boolean = False
                            Dim Emp As New cPrMsEmployees(EmpCode)
                            If Emp.StartDate >= Per.DateFrom And Emp.StartDate <= Per.DateTo Then
                                NumberOfNew = NumberOfNew + 1
                                Str03 = "03"
                                If Emp.SocialInsNumber.Length > 8 Then
                                    MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.SocialInsNumber.PadLeft(8, "0")
                                If Emp.IdentificationCard.Length > 8 Then
                                    MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                                Str03 = Str03 & Emp.IdentificationCard.PadLeft(8, "0")
                                If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                                    If Emp.AlienNumber.Length > 8 Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                                        If Ans = MsgBoxResult.No Then
                                            Me.Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            PutZeroToAlienNo = True
                                        End If
                                    End If
                                Else
                                    If Emp.AlienNumber.Length > 8 Then
                                        PutZeroToAlienNo = True
                                    End If
                                End If
                                If PutZeroToAlienNo Then
                                        Str03 = Str03 & "".PadLeft(8, "0")
                                        PutZeroToAlienNo = False
                                    Else
                                        Str03 = Str03 & Emp.AlienNumber.PadLeft(8, "0")
                                    End If

                                    If Emp.PassportNumber.Length > 10 Then
                                        MsgBox("Passport MAX Lenght is 10 digits,Wrong Passport No Length for Employee " & Emp.Code & " " & Emp.FullName)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    'Str03 = Str03 & Emp.PassportNumber.PadRight(10, " ")
                                    Str03 = Str03 & "".PadRight(10, " ")

                                    Dim EmpFull As String
                                    EmpFull = Emp.FirstName & " " & Emp.LastName
                                    If EmpFull.Length > 30 Then
                                        EmpFull = EmpFull.Substring(0, 29)
                                    End If
                                    Str03 = Str03 & EmpFull.PadRight(30, " ")
                                    Str03 = Str03 & Format(Emp.BirthDate, "dd/MM/yyyy")
                                    Str03 = Str03 & Emp.Sex
                                    Str03 = Str03 & Emp.EmpCmm_Code
                                    Str03 = Str03 & Format(Emp.StartDate, "dd/MM/yyyy")
                                    Str03 = Str03 & Emp.PayTyp_Code.Substring(0, 1)

                                    'If SIleave Then
                                    If Emp.IsSI = 0 Then
                                        Str03 = Str03 & "1"
                                    Else
                                        Str03 = Str03 & "0"
                                    End If
                                    Dim EmpPos As New cPrAnEmployeePositions(Emp.EmpPos_Code)
                                    Dim Position As String
                                    Position = EmpPos.DescriptionL
                                    If Position.Length > 25 Then
                                        Position = Position.Substring(0, 24)
                                    End If
                                    Str03 = Str03 & Position.PadRight(25, " ")
                                    Me.WriteToSIFile(Str03, Company)
                                End If
                            End If
                    Next
                End If
                '--------------------------------------------------
                'END OF 03
                '--------------------------------------------------
                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1
                    SemiTotalEmployees = SemiTotalEmployees + 1
                    Dim EmpCode As String
                    Dim TempPeriodGroup As String
                    Dim TempTemplateGroup As String


                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GesyableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String


                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                    TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim Ttemgrp As New cPrMsTemplateGroup(TempTemplateGroup)
                    Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)
                    Dim ALValue As Double = 0

                    'xxxxxxxxxxxxxxx()
                    If PARAM_CobaltALCode <> "" Then
                        ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(Ttemgrp, TPeriod, EmpCode)
                        If ALValue <> 0 Then
                            Create_N_Record = True
                            total_N_02 = total_N_02 + 1
                        End If
                    End If
                    Dim BIKWithSCValue As Double = 0
                    If PARAM_BIKWithSCCode <> "" Then
                        BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(Ttemgrp, TPeriod, EmpCode)
                        If BIKWithSCValue <> 0 Then
                            Create_X_Record = True
                            total_X_02 = total_X_02 + 1
                        End If
                    End If
                    'DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(TemGrp, Per, EmpCode)

                    DsGrossInsurable = Global1.Business.SI_File_GetEmployees_Gross_Insurable(Ttemgrp, TPeriod, EmpCode)
                    If CheckDataSet(DsGrossInsurable) Then
                        GrossEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(0)) - ALValue
                        InsurableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(1))
                        GesyableEarnings = DbNullToDouble(DsGrossInsurable.Tables(0).Rows(0).Item(2))

                    End If
                    ''''' NEW FIX FOR AVRAAMIDES '''''
                    Dim DsSLeave As DataSet
                    Dim SIvalue As Double = 0
                    DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    If CheckDataSet(DsSLeave) Then
                        For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                            If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                                SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                            End If
                        Next
                    End If
                    ''''''''''''''''''''''''''''''''''
                    If GrossEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If

                    GrossEarnings = Utils.RoundMe3(GrossEarnings, 0)


                    SemitotalGE = SemitotalGE + GrossEarnings
                    GE = Math.Abs(GrossEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")

                    GesyableEarnings = RoundMe3(GesyableEarnings - SIvalue, 2)

                    If GesyableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    GesyableEarnings = Utils.RoundMe3(GesyableEarnings, 0)
                    If Math.Abs(GesyableEarnings - GrossEarnings) = 1 Then
                        GesyableEarnings = GrossEarnings
                    End If
                    SemitotalGesyable = SemitotalGesyable + GesyableEarnings
                    Gesyable = Math.Abs(GesyableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")


                    If GrossEarnings = 0 Then
                        MsgBox("Employee  " & Emp.Code & " " & Emp.FullName & " Total Earning are Zero, Please enter Leave Code", MsgBoxStyle.Information)
                        Dim F As New FrmSelectLeaveReason
                        F.Owner = Me
                        F.ShowDialog()
                        AbsentReason = Me.GlbAbsentReason
                    Else
                        AbsentReason = " "
                    End If

                    InsurableEarnings = RoundMe3(InsurableEarnings - SIvalue, 2)

                    If InsurableEarnings >= 0 Then
                        Sign = "+"
                    Else
                        Sign = "-"
                    End If
                    InsurableEarnings = Utils.RoundMe3(InsurableEarnings, 0)
                    If Math.Abs(InsurableEarnings - GrossEarnings) = 1 Then
                        InsurableEarnings = GrossEarnings
                    End If
                    SemiTotalIE = SemiTotalIE + InsurableEarnings
                    IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                    Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")

                    'SI ***********************************
                    'Dim DsSLeave As DataSet
                    'Dim SIvalue As Double = 0
                    'DsSLeave = Global1.Business.GetERNFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSLeave) Then
                    '    For x = 0 To DsSLeave.Tables(0).Rows.Count - 1
                    '        If DsSLeave.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSLeave.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If
                    'DsSi = Global1.Business.GetCONFromTrxnLinesFor(Per, "SI")
                    'If CheckDataSet(DsSi) Then
                    '    For x = 0 To DsSi.Tables(0).Rows.Count - 1
                    '        If DsSi.Tables(0).Rows(x).Item(0) = EmpCode Then
                    '            SIvalue = SIvalue + DsSi.Tables(0).Rows(x).Item(2)
                    '        End If
                    '    Next
                    'End If

                    SI = Format(SIvalue, "0.00").ToString.Split(".")
                    Dim S As String
                    S = SI(0) & SI(1)
                    SemitotalSI = SemitotalSI + CInt(S)

                    S = "+" & S.PadLeft(12, "0")



                    Str04 = Str04 & S
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    Str04 = Str04 & AbsentReason
                    If Not Reverse1213 Then
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code = "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                    Else
                        TermDate = "          "
                        If CBExcludeTerminations.CheckState = CheckState.Unchecked Then
                            If Trim(Emp.TerminateDate) <> "" Then
                                If Per.PayCat_Code <> "K" Then
                                    If CDate(Emp.TerminateDate) < Per.DateFrom Or CDate(Emp.TerminateDate) > Per.DateTo Then
                                        TermDate = "          "
                                    Else
                                        TermDate = Format(CDate(Emp.TerminateDate), "dd/MM/yyyy")
                                        NumberOfTerm = NumberOfTerm + 1
                                    End If
                                Else
                                    TermDate = "          "
                                End If
                            Else
                                TermDate = "          "
                            End If
                        End If
                    End If
                        Str04 = Str04 & TermDate
                    Str04 = Str04 & 1
                    Me.WriteToSIFile(Str04, Company)
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")

                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees

            End If

            If Create_N_Record Then
                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------

                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 

                Str02 = Str02 & "N"
                If Not Reverse1213 Then
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)

                End If
                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------


                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String





                    Dim TermDate As String
                    Dim AbsentReason As String = " "

                    Dim TempPeriodGroup As String
                    Dim TempTemplateGroup As String
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                    TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))

                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                    Dim ALValue As Double = 0
                    If PARAM_CobaltALCode <> "" Then
                        ALValue = Global1.Business.GetAnnualLeaveValueFromLineFor(TempTempGroup, TPeriod, EmpCode)
                        If ALValue <> 0 Then
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            GrossEarnings = Utils.RoundMe3(ALValue, 0)
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                            SemitotalGE = SemitotalGE + GrossEarnings
                            GESYableEarnings = RoundMe3(0, 2)
                            SemitotalGesyable = SemitotalGesyable + GESYableEarnings
                            Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                            If GESYableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                            InsurableEarnings = RoundMe3(0, 2)
                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            SI = Format(0, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")
                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            TermDate = "          "
                            Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        End If
                    End If
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



            End If ' END OF Create_N_record



            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            'x Record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            If Create_X_Record Then
                NumberOfTerm = 0
                NumberOfNew = 0
                SemiTotalIE = 0
                SemitotalGE = 0
                SemitotalSI = 0
                SemitotalGesyable = 0
                SemiTotalEmployees = 0
                '-------------------------------------------------
                'O2 GENERAL DETAILS PER SOCIAL INSURANCE TYPE CODE
                '--------------------------------------------------

                total02 = total02 + 1
                Str02 = "02"
                'Str02 = Str02 & Company.SIRegNo.PadLeft(15)
                Str02 = Str02 & Company.SIRegNo.PadLeft(15, "0")
                Str02 = Str02 & SocCat.Code
                'Change 2016/03/02
                'OLD Str02 = Str02 & Per.SinPrdCode
                'NEW 
                Str02 = Str02 & "X"

                If Not Reverse1213 Then
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateFrom, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                Else
                    Dim MM As Integer
                    MM = Per.DateFrom.Month + 12
                    MM = CInt(SIPer.Code) + 12
                    Str02 = Str02 & MM & "/" & Format(Per.DateFrom, "yyyy")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Str02 = Str02 & Replace(Format(Per.DateTo, "MM/yyyy"), "-", "/")
                    Me.WriteToSIFile(Str02, Company)
                End If

                '--------------------------------------------------
                'END OF 02
                '--------------------------------------------------


                '--------------------------------------------------
                '04 EMPLOYEES EARNINGS
                '--------------------------------------------------
                SemiTotalEmployees = 0
                For k = 0 To DsEmp.Tables(0).Rows.Count - 1

                    Dim EmpCode As String
                    Dim GrossEarnings As Double = 0
                    Dim InsurableEarnings As Double = 0
                    Dim GESYableEarnings As Double = 0
                    Dim PutZeroToAlienNo As Boolean = False
                    Dim x As Integer
                    Dim GE() As String
                    Dim IE() As String
                    Dim SI() As String
                    Dim Gesyable() As String



                    Dim TermDate As String
                    Dim AbsentReason As String = " "
                    Dim TempPeriodGroup As String
                    Dim TempTemplateGroup As String
                    EmpCode = DbNullToString(DsEmp.Tables(0).Rows(k).Item(0))
                    TempPeriodGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(1))
                    TempTemplateGroup = DbNullToString(DsEmp.Tables(0).Rows(k).Item(2))


                    Dim Emp As New cPrMsEmployees(EmpCode)
                    Str04 = "04"
                    If Emp.SocialInsNumber.Length > 8 Then
                        MsgBox("SI MAX Lenght is 8 digits,Wrong SI Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.SocialInsNumber.PadLeft(8, "0")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Emp.IdentificationCard.Length > 8 Then
                        MsgBox("ID Card MAX Lenght is 8 digits,Wrong ID Card Length for Employee " & Emp.Code & " " & Emp.FullName)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Str04 = Str04 & Emp.IdentificationCard.PadLeft(8, "0")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBNoWarningsForAlienLenght.CheckState = CheckState.Unchecked Then
                        If Emp.AlienNumber.Length > 8 Then
                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("AlienNumber MAX Lenght is 8 digits,Wrong Alien No Length for Employee " & Emp.Code & " " & Emp.FullName & " Continue without Alien Number for this Employee ? ", MsgBoxStyle.YesNo)
                            If Ans = MsgBoxResult.No Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                PutZeroToAlienNo = True
                            End If
                        End If
                    Else
                        If Emp.AlienNumber.Length > 8 Then
                            PutZeroToAlienNo = True
                        End If
                    End If
                    If PutZeroToAlienNo Then
                        Str04 = Str04 & "".PadLeft(8, "0")
                    Else
                        Str04 = Str04 & Emp.AlienNumber.PadLeft(8, "0")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DsGrossInsurable As DataSet
                    Dim TempTempGroup As New cPrMsTemplateGroup(Emp.TemGrp_Code)
                    Dim TPeriod As New cPrMsPeriodCodes(Per.Code, TempPeriodGroup)

                    Dim BIKWithSCValue As Double = 0
                    If PARAM_BIKWithSCCode <> "" Then
                        BIKWithSCValue = Global1.Business.GetBIKWithSCValueFromLineFor(TempTempGroup, TPeriod, EmpCode)
                        If BIKWithSCValue <> 0 Then
                            SemiTotalEmployees = SemiTotalEmployees + 1
                            GrossEarnings = Utils.RoundMe3(BIKWithSCValue, 0)
                            If GrossEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            GE = Math.Abs(GrossEarnings).ToString.Split(".")
                            Str04 = Str04 & Sign & GE(0).PadLeft(10, "0")
                            SemitotalGE = SemitotalGE + GrossEarnings
                            GESYableEarnings = RoundMe3(0, 2)
                            SemitotalGesyable = SemitotalGesyable + GESYableEarnings
                            Gesyable = Math.Abs(GESYableEarnings).ToString.Split(".")
                            If GESYableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & Gesyable(0).PadLeft(10, "0")

                            InsurableEarnings = RoundMe3(0, 2)
                            SemiTotalIE = SemiTotalIE + InsurableEarnings
                            IE = Math.Abs(InsurableEarnings).ToString.Split(".")
                            If InsurableEarnings >= 0 Then
                                Sign = "+"
                            Else
                                Sign = "-"
                            End If
                            Str04 = Str04 & Sign & IE(0).PadLeft(10, "0")
                            SI = Format(0, "0.00").ToString.Split(".")
                            Dim S As String
                            S = SI(0) & SI(1)
                            SemitotalSI = SemitotalSI + CInt(S)

                            S = "+" & S.PadLeft(12, "0")
                            Str04 = Str04 & S
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            Str04 = Str04 & AbsentReason
                            TermDate = "          "
                            Str04 = Str04 & TermDate
                            Str04 = Str04 & 1
                            Me.WriteToSIFile(Str04, Company)
                        End If
                    End If
                Next

                '--------------------------------------------------
                'END OF 04
                '--------------------------------------------------
                '--------------------------------------------------
                '05 TOTALS PER SOCIAL INSURANCE CATEGORY
                '--------------------------------------------------
                Str05 = "05"
                If SemitotalGE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGE.ToString.PadLeft(12, "0")


                If SemitotalGesyable >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemitotalGesyable.ToString.PadLeft(12, "0")


                If SemiTotalIE >= 0 Then
                    Sign = "+"
                Else
                    Sign = "-"
                End If
                Str05 = Str05 & Sign & SemiTotalIE.ToString.PadLeft(12, "0")

                'SI ************************

                Str05 = Str05 & "+" & SemitotalSI.ToString.PadLeft(14, "0")
                Str05 = Str05 & NumberOfNew.ToString.PadLeft(5, "0")
                Str05 = Str05 & NumberOfTerm.ToString.PadLeft(5, "0")
                Str05 = Str05 & SemiTotalEmployees.ToString.PadLeft(6, "0")

                Me.WriteToSIFile(Str05, Company)
                '--------------------------------------------------
                'END OF 05
                '--------------------------------------------------

                GRAND_NumberOfNew = GRAND_NumberOfNew + NumberOfNew
                GRAND_NumberOfTerm = GRAND_NumberOfTerm + NumberOfTerm
                GRAND_SemiTotalIE = GRAND_SemiTotalIE + SemiTotalIE
                GRAND_SemitotalGE = GRAND_SemitotalGE + SemitotalGE
                GRAND_SemiTotalSI = GRAND_SemiTotalSI + SemitotalSI
                GRAND_SemiTotalGesyable = GRAND_SemiTotalGesyable + SemitotalGesyable
                GRAND_SemiTotalEmployees = GRAND_SemiTotalEmployees + SemiTotalEmployees



            End If ' END OF Create_N_record


            'END of X record xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






        Next


        '--------------------------------------------------
        '06 TOTALS PER SOCIAL INSURANCE CATEGORY
        '--------------------------------------------------
        Str06 = "06"
        If GRAND_SemitotalGE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemitotalGE.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalGesyable >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalGesyable.ToString.PadLeft(12, "0")


        If GRAND_SemiTotalIE >= 0 Then
            Sign = "+"
        Else
            Sign = "-"
        End If
        Str06 = Str06 & Sign & GRAND_SemiTotalIE.ToString.PadLeft(12, "0")

        'SI ************************

        Str06 = Str06 & "+" & GRAND_SemiTotalSI.ToString.PadLeft(14, "0")
        Str06 = Str06 & GRAND_NumberOfNew.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_NumberOfTerm.ToString.PadLeft(5, "0")
        Str06 = Str06 & GRAND_SemiTotalEmployees.ToString.PadLeft(6, "0")
        Str06 = Str06 & total02.ToString.PadLeft(2, "0")

        Me.WriteToSIFile(Str06, Company)
        '--------------------------------------------------
        'END OF 06
        '--------------------------------------------------



        MsgBox("File is Created", MsgBoxStyle.Information)


        Me.Cursor = Cursors.Default


    End Sub

    Private Sub btnPeriodGroupSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodGroupSearch.Click
        Dim F As New FrmPeriodGroupSearch
        F.Owner = Me
        F.DsPeriodGroups = DsPeriodGroups
        F.CalledBy = 2
        F.ShowDialog()

    End Sub
End Class