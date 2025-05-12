Public Class FrmNavEmployeeCostInterface
    Public Period As cPrMsPeriodCodes
    Public TemGrp As cPrMsTemplateGroup

    Private Sub FrmNavEmployeeCostInterface_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadPeriods()
        GetNavisionParameters()
    End Sub
    Private Sub GetNavisionParameters()

        Dim P2 As New cAaSsParameters("NAV", "ServerName")
        If P2.Id <> 0 Then
            Global1.NAV_ServerName = P2.Value1
        Else
            MsgBox("Parameter NAV , DBServerName is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P3 As New cAaSsParameters("NAV", "DBName")
        If P3.Id <> 0 Then
            Global1.NAV_DBName = P3.Value1
        Else
            MsgBox("Parameter NAV , DBName is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P4 As New cAaSsParameters("NAV", "NavUser")
        If P4.Id <> 0 Then
            Global1.NAV_User = P4.Value1
        Else
            MsgBox("Parameter NAV , NavUser is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P5 As New cAaSsParameters("NAV", "NavPass")
        If P5.Id <> 0 Then
            Global1.NAV_Pass = P5.Value1
        Else
            MsgBox("Parameter NAV , DBPass is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        '---------------------------------'
        ''''''''' NEW PARAMETERS ''''''''''
        '---------------------------------'
        'Dim P6 As New cAaSsParameters("NAV", "TemplateName")
        'If P6.Id <> 0 Then
        '    Global1.NAV_JournalTemplateName = P6.Value1
        'Else
        '    MsgBox("Parameter NAV , Template Name is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        'End If
        'Dim P7 As New cAaSsParameters("NAV", "BachName")
        'If P7.Id <> 0 Then
        '    Global1.NAV_JournalBachName = P7.Value1
        'Else
        '    MsgBox("Parameter NAV , BachName is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        'End If
        'Dim P8 As New cAaSsParameters("NAV", "AccountNo")
        'If P8.Id <> 0 Then
        '    Global1.NAV_AccountNo = P8.Value1
        'Else
        '    MsgBox("Parameter NAV , AccountNo is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        'End If
        'Dim P9 As New cAaSsParameters("NAV", "BalanceAcc")
        'If P9.Id <> 0 Then
        '    Global1.NAV_BalancingAcc = P9.Value1
        'Else
        '    MsgBox("Parameter NAV , BalanceAcc is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        'End If
        'Dim P10 As New cAaSsParameters("NAV", "SourceCode")
        'If P10.Id <> 0 Then
        '    Global1.NAV_SourceCode = P10.Value1
        'Else
        '    MsgBox("Parametet NAV , SourceCode is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        'End If
        'Dim P11 As New cAaSsParameters("NAV", "PostNoSeries")
        'If P11.Id <> 0 Then
        '    Global1.NAV_PostingNoSeries = P11.Value1
        'Else
        '    MsgBox("Parameter NAV , PostNoSeries is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        'End If

    End Sub
    Private Sub LoadPeriods()
        Dim ds As DataSet
        Dim i As Integer = 0
        Dim Index As Integer = 0
        ds = Global1.Business.GetAllPrMsPeriodsByPeriodGroup(Period.PrdGrpCode)
        With Me.CmbPeriod
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P As New cPrMsPeriodCodes(ds.Tables(0).Rows(i))
                    .Items.Add(P)
                    If P.Code = Period.Code Then
                        Index = i
                    End If
                Next
            End If
            .EndUpdate()
            .SelectedIndex = Index
        End With

    End Sub

    Private Sub TSBSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSend.Click
        Dim P As New cPrMsPeriodCodes
        Dim Linecount As Integer
        P = CType(Me.CmbPeriod.SelectedItem, cPrMsPeriodCodes)
        Dim PerGrouP As New cPrMsPeriodGroups(P.PrdGrpCode)
        Dim CompanyCode As String '= TemGrp.CompanyCode
        Dim C As New cAdMsCompany(TemGrp.CompanyCode)
        Dim DefaultJob As String = C.TSDefaultJob
        CompanyCode = C.GLAnal1
        Global1.NAV_GLBCompPrefix = C.GLAnal2
        Dim ds As DataSet
        Dim DsPayroll As DataSet
        Dim i As Integer
        Dim j As Integer
        Dim Empcode As String
        Dim EmpName As String = ""
        Dim ResourceCode As String
        Dim CompanyCost As Double
        Dim HoursWorked As Double
        Dim HourlyRate As Double
        Dim Postingdate As Date
        Postingdate = Me.DatePosting.Value.Date

        Dim DateFrom As String = Format(P.DateFrom, "yyyy-MM-dd")
        Dim DateTo As String = Format(P.DateTo, "yyyy-MM-dd")

        Dim Count As Integer = 0
        Dim DsLeave As DataSet

        Dim Ans As MsgBoxResult = MsgBoxResult.Yes
        Dim dsLeaveTypes As DataSet
        dsLeaveTypes = Global1.Business.AG_GetAllPrSsLeaveTypes
        DsPayroll = Global1.Business.GetCompanyCostPerEmployee(PerGrouP.Code, P.Code)
        DsLeave = Global1.Business.GetALReportForAllemployees(PerGrouP, P)

        Dim FromDate As Date
        Dim ToDate As Date


        Dim balAL As Double = 0
        Dim balASIL As Double = 0
        Dim balSICK As Double = 0
        Dim balARMY As Double = 0
        Dim balMATERNITY As Double = 0
        Dim balUNEX As Double = 0
        Dim balOTHER As Double = 0
        Dim FullName As String = ""

        FromDate = CDate(P.DateFrom.Year & "/" & "01/01")
        ToDate = CDate(P.DateFrom.Year & "/" & "12/31")
        Dim n As Integer
        Dim cLT As New cPrSsLeaveTypes
        'Dim ArEmp(DsPayroll.Tables(0).Rows.Count - 1)(6) As String

        Dim ArEmp(0, 0) As String
        ReDim ArEmp(DsPayroll.Tables(0).Rows.Count - 1, 7)


        If CheckDataSet(dsLeaveTypes) Then
            For i = 0 To DsPayroll.Tables(0).Rows.Count - 1

                Application.DoEvents()
                Empcode = DbNullToString(DsPayroll.Tables(0).Rows(i).Item(0))
                Dim Emp As New cPrMsEmployees(Empcode)

                balAL = 0
                balASIL = 0
                balSICK = 0
                balARMY = 0
                balMATERNITY = 0
                balUNEX = 0
                Dim Tot As Double = 0
                For n = 0 To dsLeaveTypes.Tables(0).Rows.Count - 1
                    Tot = 0
                    cLT = New cPrSsLeaveTypes(dsLeaveTypes.Tables(0).Rows(n))
                    Tot = Global1.Business.GetEmployeeTotalPerTypePerAction(Empcode, cLT.Code, AN_IncreaseCODE, FromDate, ToDate, AN_Approved)
                    Tot = Tot + Global1.Business.GetEmployeeTotalPerTypePerAction(Empcode, cLT.Code, AN_CarryForwardCODE, FromDate, ToDate, AN_Approved)
                    Tot = Tot - Global1.Business.GetEmployeeTotalPerTypePerAction(Empcode, cLT.Code, AN_DecreaseCODE, FromDate, ToDate, AN_Approved)
                    Tot = Tot - Global1.Business.GetEmployeeTotalPerTypePerAction(Empcode, cLT.Code, AN_EndOfYearCODE, FromDate, ToDate, AN_Approved)
                    Select Case cLT.Code
                        Case 1
                            balAL = Tot
                        Case 2
                            balASIL = Tot
                        Case 3
                            balSICK = Tot
                        Case 4
                            balARMY = Tot
                        Case 5
                            balMATERNITY = Tot
                        Case 6
                            balUNEX = Tot
                    End Select
                Next
                ArEmp(i, 0) = Empcode
                ArEmp(i, 1) = balAL
                ArEmp(i, 2) = balASIL
                ArEmp(i, 3) = balSICK
                ArEmp(i, 4) = balARMY
                ArEmp(i, 5) = balMATERNITY
                ArEmp(i, 6) = balUNEX
                ArEmp(i, 7) = Emp.FullName

            Next
        End If

        If CheckDataSet(DsPayroll) Then
            '------------------------------------------------------------------------------------
            'Try To Connect To Navision
            Dim StrConnect As String
            Dim L As New cLogin
            StrConnect = "Server=" & NAV_ServerName & ";Database=" & NAV_DBName & ";User ID=" + NAV_User + ";Password=" + NAV_Pass + ";"
            Debug.WriteLine(StrConnect)
            If L.TryToConnect(StrConnect, True) Then
                Global1.Business = New cBusiness
            Else
                MsgBox("Unable To connect To Navision.Please check Parameters", MsgBoxStyle.Critical)
                Exit Sub
            End If
            'End Of connection
            '-------------------------------------------------------------------------------------

            '''NEW CODE FROM HERE

            Ans = MsgBoxResult.Yes
            ds = Global1.Business.NAV_FindIfCOSTItWasInterfacedAgain(PerGrouP.Code, P.Code)
            If CheckDataSet(ds) Then
                Ans = MsgBox("The Specific Period For Company code " & CompanyCode & " Was Interfaced Again." & Chr(13) & _
                " Do you want to Delete Navision Values and Re-Interface?", MsgBoxStyle.YesNoCancel)
                If Ans = MsgBoxResult.Yes Then
                    Me.LblStatus.Text = "Please Wait Initializing ..."
                    Global1.Business.NAV_DeleteInterfacedDashboardValues(PerGrouP.Code, P.Code)
                End If
            End If
            Me.LblStatus.Text = ""
            If Ans = MsgBoxResult.Yes Then
                Me.LblStatus.Text = "Please Wait Processing ..."
                Cursor.Current = Cursors.WaitCursor
                Dim k As Integer
                For i = 0 To DsPayroll.Tables(0).Rows.Count - 1
                    Application.DoEvents()
                    HourlyRate = 0
                    Empcode = DbNullToString(DsPayroll.Tables(0).Rows(i).Item(0))
                    CompanyCost = DbNullToDouble(DsPayroll.Tables(0).Rows(i).Item(1))

                    Dim AL As Double = 0
                    Dim ASIL As Double = 0
                    Dim SICK As Double = 0
                    Dim ARMY As Double = 0
                    Dim MATERNITY As Double = 0
                    Dim UNEX As Double = 0
                    Dim OTHER As Double = 0

                  

                    Dim LeaveType As String
                    Dim Leave As Double = 0

                    If CheckDataSet(DsLeave) Then
                        For k = 0 To DsLeave.Tables(0).Rows.Count - 1
                            If DbNullToString(DsLeave.Tables(0).Rows(k).Item(0)) = Empcode Then
                                LeaveType = DbNullToString(DsLeave.Tables(0).Rows(k).Item(1))
                                Leave = DbNullToDouble(DsLeave.Tables(0).Rows(k).Item(2))
                                Select Case LeaveType
                                    Case 1
                                        AL = Leave
                                    Case 2
                                        ASIL = Leave
                                    Case 3
                                        SICK = Leave
                                    Case 4
                                        ARMY = Leave
                                    Case 5
                                        MATERNITY = Leave
                                    Case 6
                                        UNEX = Leave
                                End Select
                            End If
                        Next
                    End If

                    balAL = 0
                    balASIL = 0
                    balSICK = 0
                    balARMY = 0
                    balMATERNITY = 0
                    balUNEX = 0
                    FullName = ""

                    For k = 0 To DsPayroll.Tables(0).Rows.Count - 1
                        If ArEmp(k, 0) = Empcode Then
                            balAL = ArEmp(k, 1)
                            balASIL = ArEmp(k, 2)
                            balSICK = ArEmp(k, 3)
                            balARMY = ArEmp(k, 4)
                            balMATERNITY = ArEmp(k, 5)
                            balUNEX = ArEmp(k, 6)
                            FullName = ArEmp(k, 7)
                            Exit For
                        End If
                    Next
                    
                    Global1.Business.NAV_InsertValuesInDashboardCost(Empcode, FullName, Me.DatePosting.Value, CompanyCost, AL, ASIL, SICK, ARMY, MATERNITY, UNEX, OTHER, balAL, balASIL, balSICK, balARMY, balMATERNITY, balUNEX, balOTHER, P.Code, PerGrouP.Code)

                    Me.LblStatus.Text = "Please Wait Processing Reasource" & i & "..."

                Next
                'Dim DsPayrollCost As DataSet
                'DsPayrollCost = Global1.Business.NAV_GetPayrollCostForcompanyYearPeriod(CompanyCode, PerGrouP.Year, P.Code)
                'If CheckDataSet(DsPayrollCost) Then
                '    Dim C_CompanyCode As String
                '    Dim C_EmployeeCode As String
                '    Dim C_ResourceCode As String
                '    Dim C_Year As String
                '    Dim C_Period As String
                '    Dim C_Cost As Double
                '    Dim C_WorkHours As Double
                '    Dim C_HourRate As Double
                '    Dim JobNo As String
                '    Dim JobQty As Double
                '    Dim PerJobCost As Double
                '    Dim DsPerJobCost As DataSet
                '    For i = 0 To DsPayrollCost.Tables(0).Rows.Count - 1
                '        Application.DoEvents()
                '        C_CompanyCode = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(0))
                '        C_EmployeeCode = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(1))
                '        C_ResourceCode = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(2))
                '        C_Year = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(3))
                '        C_Period = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(4))
                '        C_Cost = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(5))
                '        C_WorkHours = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(6))
                '        C_HourRate = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(7))

                '        DsPerJobCost = Global1.Business.NAV_GetTotalHoursPerMonthPerResoursePerJob(DateFrom, DateTo, C_ResourceCode)

                '        If CheckDataSet(DsPerJobCost) Then
                '            For j = 0 To DsPerJobCost.Tables(0).Rows.Count - 1
                '                Application.DoEvents()
                '                JobQty = DbNullToDouble(DsPerJobCost.Tables(0).Rows(j).Item(0))
                '                JobNo = DbNullToString(DsPerJobCost.Tables(0).Rows(j).Item(1))
                '                PerJobCost = Math.Abs(JobQty) * C_HourRate
                '                Global1.Business.NAV_InsertValuesInNavisionPerJob(C_CompanyCode, C_EmployeeCode, C_ResourceCode, PerGrouP.Year, P.Code, JobNo, JobQty, C_HourRate, PerJobCost)
                '            Next
                '        Else
                '            JobQty = 1
                '            JobNo = DefaultJob
                '            PerJobCost = Math.Abs(JobQty) * C_Cost
                '            Global1.Business.NAV_InsertValuesInNavisionPerJob(C_CompanyCode, C_EmployeeCode, C_ResourceCode, PerGrouP.Year, P.Code, JobNo, JobQty, C_HourRate, PerJobCost)
                '        End If
                '        Me.LblStatus.Text = "Please Wait Processing Jobs" & i & "..."
                '    Next
                '    Dim DsPayrollCostPerJob As DataSet
                '    DsPayrollCostPerJob = Global1.Business.NAV_SelectFromPayrollCostPerJob(CompanyCode, PerGrouP.Year, P.Code)

                '    If CheckDataSet(DsPayrollCostPerJob) Then
                '        '-----------------------------------
                '        'Journal Fields
                '        '-----------------------------------
                '        'Dim JournalTemplateName As String = "PRLL"
                '        'Dim JournalBachName As String = "PRTM"
                '        'Dim AccountNo As String = "601090"
                '        'Dim BalancingAcc As String = "711090"
                '        'Dim SourceCode As String = "PAYROLL"
                '        'Dim PostingNoSeries As String = "PRLL"

                '        Dim LineNo As Integer
                '        Dim AccDescription As String
                '        Dim DocumentNo As String
                '        Dim ShortcutDimension1 As String
                '        Dim ShortCutDimension2 As String
                '        Dim ExternalDocument As String = TemGrp.Code & "-" & P.Code

                '        '-----------------------------------
                '        'Line fields
                '        '-----------------------------------
                '        Dim E_CompanyCode As String
                '        Dim E_EmployeeCode As String
                '        Dim E_ResourceCode As String
                '        Dim E_Year As String
                '        Dim E_Period As String
                '        Dim E_Job As String
                '        Dim E_Qty As Double
                '        Dim E_HourlyRate As Double
                '        Dim E_Total As Double

                '        '-----------------------------------
                '        For i = 0 To DsPayrollCostPerJob.Tables(0).Rows.Count - 1
                '            Application.DoEvents()
                '            With DsPayrollCostPerJob.Tables(0).Rows(i)
                '                E_CompanyCode = DbNullToString(.Item(0))
                '                E_EmployeeCode = DbNullToString(.Item(1))
                '                E_ResourceCode = DbNullToString(.Item(2))
                '                E_Year = DbNullToString(.Item(3))
                '                E_Period = DbNullToString(.Item(4))
                '                E_Job = DbNullToString(.Item(5))
                '                E_Qty = DbNullToDouble(.Item(6))
                '                E_HourlyRate = DbNullToDouble(.Item(7))
                '                E_Total = DbNullToDouble(.Item(8))
                '            End With
                '            Dim T As Boolean
                '            LineNo = (i + 1) * 1000
                '            ShortCutDimension2 = E_Job
                '            ShortcutDimension1 = FindShortcutDimension1(DsPayroll, E_EmployeeCode)

                '            AccDescription = "PAYROLL ALLOCATION " & P.Code
                '            T = Global1.Business.NAV_InsertInto_GenJournalLines(NAV_JournalTemplateName, NAV_JournalBachName, LineNo, NAV_AccountNo, AccDescription, DocumentNo, NAV_BalancingAcc, ShortCutDimension2, NAV_SourceCode, E_Total, Postingdate, ExternalDocument, NAV_PostingNoSeries, ShortcutDimension1)
                '            Me.LblStatus.Text = "Please Wait Sending To Navision " & Linecount & " ..."
                '            Linecount = Linecount + 1
                '        Next
                '    End If
                'End If
                Me.LblStatus.Text = ""
                MsgBox("Succefully Interfaced " & i & " Employees", MsgBoxStyle.Information)
            End If
            '----------------------------------------------------------------------------------------------
            'Connect Back To Payroll
            StrConnect = "Server=" & Global1.DbaseServerName & ";Database=" & Global1.DbaseName & ";User ID=" + Global1.GLBUserCode + ";Password=" + Global1.GLBUserPassword + ";"
            If L.TryToConnect(StrConnect, True) Then
                Global1.Business = New cBusiness
            End If
            'End Of Connection
            '----------------------------------------------------------------------------------------------
        Else
            MsgBox("There are No POSTED Entries for this Period", MsgBoxStyle.Information)
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Function FindShortcutDimension1(ByVal DsPayroll As DataSet, ByVal EmployeeCode As String) As String
        Dim i As Integer
        Dim ReturnValue As String = ""
        For i = 0 To DsPayroll.Tables(0).Rows.Count - 1
            If EmployeeCode = DsPayroll.Tables(0).Rows(i).Item(0) Then
                ReturnValue = DsPayroll.Tables(0).Rows(i).Item(3)
                Exit For
            End If
        Next
        Return ReturnValue
    End Function

    
End Class