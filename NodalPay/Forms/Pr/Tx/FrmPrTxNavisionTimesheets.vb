Public Class FrmPrTxNavisionTimesheets
    Public Period As cPrMsPeriodCodes
    Public TemGrp As cPrMsTemplateGroup

    Private Sub FrmPrTxNavisionTimesheets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Dim P6 As New cAaSsParameters("NAV", "TemplateName")
        If P6.Id <> 0 Then
            Global1.NAV_JournalTemplateName = P6.Value1
        Else
            MsgBox("Parameter NAV , Template Name is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P7 As New cAaSsParameters("NAV", "BachName")
        If P7.Id <> 0 Then
            Global1.NAV_JournalBachName = P7.Value1
        Else
            MsgBox("Parameter NAV , BachName is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P8 As New cAaSsParameters("NAV", "AccountNo")
        If P8.Id <> 0 Then
            Global1.NAV_AccountNo = P8.Value1
        Else
            MsgBox("Parameter NAV , AccountNo is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P9 As New cAaSsParameters("NAV", "BalanceAcc")
        If P9.Id <> 0 Then
            Global1.NAV_BalancingAcc = P9.Value1
        Else
            MsgBox("Parameter NAV , BalanceAcc is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P10 As New cAaSsParameters("NAV", "SourceCode")
        If P10.Id <> 0 Then
            Global1.NAV_SourceCode = P10.Value1
        Else
            MsgBox("Parametet NAV , SourceCode is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        Dim P11 As New cAaSsParameters("NAV", "PostNoSeries")
        If P11.Id <> 0 Then
            Global1.NAV_PostingNoSeries = P11.Value1
        Else
            MsgBox("Parameter NAV , PostNoSeries is Missing.Cannot Proceed", MsgBoxStyle.Critical)
        End If
        
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
        Dim ResourceCode As String
        Dim CompanyCost As Double
        Dim HoursWorked As Double
        Dim HourlyRate As Double
        Dim Postingdate As Date
        Postingdate = Me.DatePosting.Value.Date

        Dim DateFrom As String = Format(P.DateFrom, "yyyy-MM-dd")
        Dim DateTo As String = Format(P.DateTo, "yyyy-MM-dd")

        Dim Count As Integer = 0

        
        Dim Ans As MsgBoxResult = MsgBoxResult.Yes
        DsPayroll = Global1.Business.GetCompanyCostPerEmployee(PerGrouP.Code, P.Code)

        If CheckDataSet(DsPayroll) Then
            '----------------------------------------------------------------------------------------------
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
            '----------------------------------------------------------------------------------------------


            Ans = MsgBoxResult.Yes
            ds = Global1.Business.NAV_FindIfItWasInterfacedAgain(CompanyCode, PerGrouP.Year, P.Code)
            If CheckDataSet(ds) Then
                Ans = MsgBox("The Specific Period For Company code " & CompanyCode & "Was Interfaced Again." & Chr(13) & _
                " Do you want to Delete Navision Values and Re-Interface?", MsgBoxStyle.YesNoCancel)
                If Ans = MsgBoxResult.Yes Then
                    Me.LblStatus.Text = "Please Wait Initializing ..."
                    Global1.Business.NAV_DeleteInterfacedTimesheetTransactions(CompanyCode, PerGrouP.Year, P.Code)
                    Global1.Business.NAV_DeleteInterfacedTimesheetTransactionsFromPerJob(CompanyCode, PerGrouP.Year, P.Code)
                End If
            End If
            Me.LblStatus.Text = ""
            If Ans = MsgBoxResult.Yes Then
                Me.LblStatus.Text = "Please Wait Processing ..."
                Cursor.Current = Cursors.WaitCursor

                For i = 0 To DsPayroll.Tables(0).Rows.Count - 1
                    Application.DoEvents()
                    HourlyRate = 0
                    Empcode = DbNullToString(DsPayroll.Tables(0).Rows(i).Item(0))
                    CompanyCost = DbNullToDouble(DsPayroll.Tables(0).Rows(i).Item(1))
                    ResourceCode = DbNullToString(DsPayroll.Tables(0).Rows(i).Item(2))
                    If Trim(ResourceCode) <> "" Then
                        Count = Count + 1
                        HoursWorked = Global1.Business.NAV_GetTotalHoursPerMonthPerResourse(DateFrom, DateTo, ResourceCode)
                        HoursWorked = Math.Abs(HoursWorked)
                        If HoursWorked <> 0 Then
                            HourlyRate = RoundMe3(CompanyCost / HoursWorked, 2)
                        Else
                            HoursWorked = 1
                            HourlyRate = CompanyCost
                        End If
                        Global1.Business.NAV_InsertValuesInNavisionTimesheets(CompanyCode, Empcode, ResourceCode, PerGrouP.Year, P.Code, CompanyCost, HoursWorked, HourlyRate)
                        Me.LblStatus.Text = "Please Wait Processing Reasource" & i & "..."
                    End If
                Next
                Dim DsPayrollCost As DataSet
                DsPayrollCost = Global1.Business.NAV_GetPayrollCostForcompanyYearPeriod(CompanyCode, PerGrouP.Year, P.Code)
                If CheckDataSet(DsPayrollCost) Then
                    Dim C_CompanyCode As String
                    Dim C_EmployeeCode As String
                    Dim C_ResourceCode As String
                    Dim C_Year As String
                    Dim C_Period As String
                    Dim C_Cost As Double
                    Dim C_WorkHours As Double
                    Dim C_HourRate As Double
                    Dim JobNo As String
                    Dim JobQty As Double
                    Dim PerJobCost As Double
                    Dim DsPerJobCost As DataSet
                    For i = 0 To DsPayrollCost.Tables(0).Rows.Count - 1
                        Application.DoEvents()
                        C_CompanyCode = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(0))
                        C_EmployeeCode = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(1))
                        C_ResourceCode = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(2))
                        C_Year = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(3))
                        C_Period = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(4))
                        C_Cost = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(5))
                        C_WorkHours = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(6))
                        C_HourRate = DbNullToString(DsPayrollCost.Tables(0).Rows(i).Item(7))

                        DsPerJobCost = Global1.Business.NAV_GetTotalHoursPerMonthPerResoursePerJob(DateFrom, DateTo, C_ResourceCode)

                        If CheckDataSet(DsPerJobCost) Then
                            For j = 0 To DsPerJobCost.Tables(0).Rows.Count - 1
                                Application.DoEvents()
                                JobQty = DbNullToDouble(DsPerJobCost.Tables(0).Rows(j).Item(0))
                                JobNo = DbNullToString(DsPerJobCost.Tables(0).Rows(j).Item(1))
                                PerJobCost = Math.Abs(JobQty) * C_HourRate
                                Global1.Business.NAV_InsertValuesInNavisionPerJob(C_CompanyCode, C_EmployeeCode, C_ResourceCode, PerGrouP.Year, P.Code, JobNo, JobQty, C_HourRate, PerJobCost)
                            Next
                        Else
                            JobQty = 1
                            JobNo = DefaultJob
                            PerJobCost = Math.Abs(JobQty) * C_Cost
                            Global1.Business.NAV_InsertValuesInNavisionPerJob(C_CompanyCode, C_EmployeeCode, C_ResourceCode, PerGrouP.Year, P.Code, JobNo, JobQty, C_HourRate, PerJobCost)
                        End If
                        Me.LblStatus.Text = "Please Wait Processing Jobs" & i & "..."
                    Next
                    Dim DsPayrollCostPerJob As DataSet
                    DsPayrollCostPerJob = Global1.Business.NAV_SelectFromPayrollCostPerJob(CompanyCode, PerGrouP.Year, P.Code)

                    If CheckDataSet(DsPayrollCostPerJob) Then
                        '-----------------------------------
                        'Journal Fields
                        '-----------------------------------
                        'Dim JournalTemplateName As String = "PRLL"
                        'Dim JournalBachName As String = "PRTM"
                        'Dim AccountNo As String = "601090"
                        'Dim BalancingAcc As String = "711090"
                        'Dim SourceCode As String = "PAYROLL"
                        'Dim PostingNoSeries As String = "PRLL"

                        Dim LineNo As Integer
                        Dim AccDescription As String
                        Dim DocumentNo As String
                        Dim ShortcutDimension1 As String
                        Dim ShortCutDimension2 As String
                        Dim ExternalDocument As String = TemGrp.Code & "-" & P.Code

                        '-----------------------------------
                        'Line fields
                        '-----------------------------------
                        Dim E_CompanyCode As String
                        Dim E_EmployeeCode As String
                        Dim E_ResourceCode As String
                        Dim E_Year As String
                        Dim E_Period As String
                        Dim E_Job As String
                        Dim E_Qty As Double
                        Dim E_HourlyRate As Double
                        Dim E_Total As Double

                        '-----------------------------------
                        For i = 0 To DsPayrollCostPerJob.Tables(0).Rows.Count - 1
                            Application.DoEvents()
                            With DsPayrollCostPerJob.Tables(0).Rows(i)
                                E_CompanyCode = DbNullToString(.Item(0))
                                E_EmployeeCode = DbNullToString(.Item(1))
                                E_ResourceCode = DbNullToString(.Item(2))
                                E_Year = DbNullToString(.Item(3))
                                E_Period = DbNullToString(.Item(4))
                                E_Job = DbNullToString(.Item(5))
                                E_Qty = DbNullToDouble(.Item(6))
                                E_HourlyRate = DbNullToDouble(.Item(7))
                                E_Total = DbNullToDouble(.Item(8))
                            End With
                            Dim T As Boolean
                            LineNo = (i + 1) * 1000
                            ShortCutDimension2 = E_Job
                            ShortcutDimension1 = FindShortcutDimension1(DsPayroll, E_EmployeeCode)

                            AccDescription = "PAYROLL ALLOCATION " & P.Code
                            T = Global1.Business.NAV_InsertInto_GenJournalLines(NAV_JournalTemplateName, NAV_JournalBachName, LineNo, NAV_AccountNo, AccDescription, DocumentNo, NAV_BalancingAcc, ShortCutDimension2, NAV_SourceCode, E_Total, Postingdate, ExternalDocument, NAV_PostingNoSeries, ShortcutDimension1)
                            Me.LblStatus.Text = "Please Wait Sending To Navision " & Linecount & " ..."
                            Linecount = Linecount + 1
                        Next
                    End If
                End If
                Me.LblStatus.Text = ""
                MsgBox("Succefully Interfaced " & Count & " Entries & " & Linecount & " Job Lines", MsgBoxStyle.Information)
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
    'This is the change for Department code
    '


End Class