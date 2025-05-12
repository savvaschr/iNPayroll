Public Class FrmPrTxClosePeriod
    Dim Loading As Boolean
    Dim GLBTempGroup As cPrMsTemplateGroup
    Dim GLBCurrentPeriod As New cPrMsPeriodCodes()

    Public CalledByTempGroup As New cPrMsTemplateGroup


    Private Sub FrmClosePeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCombos()
        FindCurrentPeriod(True)
        ''''''''''''''' Time Attendance NYS ''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim Ds As DataSet
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
        Ds = Global1.Business.GetParameter("System", "PensionAge")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_PensionAge = Par.Value1
        Else
            Global1.PARAM_PensionAge = 0
        End If

        Ds = Global1.Business.GetParameter("System", "ALAllocation")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_AnnualLeaveAllocation = True
            Else
                Global1.PARAM_AnnualLeaveAllocation = False
            End If
        End If
        If CalledByTempGroup.Code <> "" Then
            Me.ComboTempGroups.SelectedIndex = Me.ComboTempGroups.FindStringExact(CalledByTempGroup.ToString)
        End If

        Ds = Global1.Business.GetParameter("System", "PFReminder")

        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            Global1.PARAM_PFReminder = Par.Value1
        Else
            Global1.PARAM_PFReminder = 0
        End If


    End Sub
    Private Sub LoadCombos()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        With Me.ComboTempGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim Temp As New cPrMsTemplateGroup(ds.Tables(0).Rows(i))
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
            GLBTempGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup)
            FindCurrentPeriod(True)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
    Private Sub FindCurrentPeriod(ByVal Clearing As Boolean)
        If Loading Then Exit Sub
        Try
            Dim ds As DataSet
            ds = Global1.Business.FindCurrentPeriod1(GLBTempGroup.Code)
            If CheckDataSet(ds) Then
                GLBCurrentPeriod = New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
                With GLBCurrentPeriod
                    Me.txtPeriodCode.Text = .Code
                    Me.txtPeriodDescription.Text = .DescriptionL
                    Me.txtPeriodFrom.Text = Format(.DateFrom, "dd-MM-yyyy")
                    Me.txtPeriodTo.Text = Format(.DateTo, "dd-MM-yyyy")
                End With
            Else
                MsgBox("There is no OPEN Period !", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub TSBClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBClose.Click
       
        If Me.GLBCurrentPeriod.Code <> "" Then
            Dim ans As MsgBoxResult
            With GLBCurrentPeriod
                ans = MsgBox("Are you Sure you want to close Period " & .Code & " " & .DescriptionL, MsgBoxStyle.YesNoCancel)
                If ans = MsgBoxResult.Yes Then
                    If CheckForEmployeesNotPosted(GLBCurrentPeriod) Then
                        Try
                            Dim Exx As New Exception
                            Global1.Business.BeginTransaction()
                            GLBCurrentPeriod.Status = "C"
                            If Not GLBCurrentPeriod.Save Then
                                Throw Exx
                            End If
                            If Not Global1.Business.OpenNextPeriodIfExist(GLBCurrentPeriod) Then
                                Throw Exx
                            End If
                            Global1.Business.CommitTransaction()
                            MsgBox("Period Succesfully Closed", MsgBoxStyle.Information)
                            Me.FindCurrentPeriod(True)
                            SetInactiveStatusToTerminatedemployees(False)

                            If Global1.PARAM_TAFileEnable Then
                                Dim FileDir As String
                                Dim Files() As String
                                FileDir = Global1.PARAM_TAFilePath
                                Files = IO.Directory.GetFiles(FileDir)
                                Dim i As Integer
                                For i = 0 To Files.Length - 1
                                    Me.Refresh()
                                    FileName = Files(i)
                                    Try
                                        IO.File.Delete(FileName)
                                    Catch ex As Exception

                                    End Try
                                Next
                            End If
                            If Global1.PARAM_PensionAge <> 0 Then
                                Dim DsEmp As DataSet
                                Dim PrdGrp As New cPrMsPeriodGroups(GLBCurrentPeriod.PrdGrpCode)
                                Dim i As Integer
                                Dim PeriodMonth As Integer
                                Dim DateOfBirth As Date
                                Dim DOBMonth As Integer
                                Dim s As String = ""
                                DsEmp = Global1.Business.FindAllEmployeesForPension(PARAM_PensionAge, PrdGrp.TemGrpCode)
                                If CheckDataSet(DsEmp) Then
                                    For i = 0 To DsEmp.Tables(0).Rows.Count - 1
                                        'DateOfBirth = DbNullToDate(DsEmp.Tables(0).Rows(i).Item(2))
                                        'PeriodMonth = GLBCurrentPeriod.DateFrom.Month
                                        'DOBMonth = DateOfBirth.Month
                                        'If DOBMonth < PeriodMonth Then
                                        Dim EmpCode As String
                                        Dim EmpName As String
                                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(i).Item(0))
                                        EmpName = DbNullToString(DsEmp.Tables(0).Rows(i).Item(1))
                                        s = s & EmpCode & " - " & EmpName & Chr(13)
                                        '    End If
                                    Next
                                End If
                                If s <> "" Then
                                    s = "The following employees are on the Pension Age Limit" & Chr(13) & Chr(13) & s
                                    MsgBox(s)
                                End If

                            End If
                            If Global1.PARAM_PFReminder <> 0 Then
                                Dim DsEmp As DataSet
                                Dim PrdGrp As New cPrMsPeriodGroups(GLBCurrentPeriod.PrdGrpCode)
                                Dim i As Integer
                                Dim PeriodMonth As Integer
                                Dim DOE As Date
                                Dim DOEMonth As Integer
                                Dim s As String = ""
                                DsEmp = Global1.Business.FindAllEmployeesForPF(PARAM_PFReminder, PrdGrp.TemGrpCode)
                                If CheckDataSet(DsEmp) Then
                                    For i = 0 To DsEmp.Tables(0).Rows.Count - 1
                                        'DateOfBirth = DbNullToDate(DsEmp.Tables(0).Rows(i).Item(2))
                                        'PeriodMonth = GLBCurrentPeriod.DateFrom.Month
                                        'DOBMonth = DateOfBirth.Month
                                        'If DOBMonth < PeriodMonth Then
                                        Dim EmpCode As String
                                        Dim EmpName As String
                                        EmpCode = DbNullToString(DsEmp.Tables(0).Rows(i).Item(0))
                                        EmpName = DbNullToString(DsEmp.Tables(0).Rows(i).Item(1))
                                        s = s & EmpCode & " - " & EmpName & Chr(13)
                                        '    End If
                                    Next
                                End If
                                If s <> "" Then
                                    s = "The following employees Employement Period is " & PARAM_PFReminder & " Months, Please check for Provident Fund " & Chr(13) & Chr(13) & s
                                    MsgBox(s)
                                End If

                            End If

                            If Global1.PARAM_AnnualLeaveAllocation Then
                                Dim F As New FrmPrMsEnterMonthNormalDays
                                F.Period = Me.GLBCurrentPeriod
                                F.ShowDialog()
                            End If

                        Catch ex As Exception
                            Utils.ShowException(ex)
                            Global1.Business.Rollback()
                            MsgBox("Unable to Close Period")
                        End Try

                    End If
                End If
            End With
        End If

    End Sub
    Public Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function
    Public Function CheckForEmployeesNotPosted(ByVal GLBCurrentPeriod) As Boolean
        Dim Flag As Boolean = True
        Dim DsEmp As DataSet
        Dim DsHeader As DataSet
        Dim R1 As Double = 0
        Dim R2 As Double = 0
        Dim DoNotCheck As Boolean = False
        Dim Ans As MsgBoxResult

        DsEmp = Global1.Business.GetAllActiveEmployeesForPeriod(GLBCurrentPeriod)
        DsHeader = Global1.Business.GetAllTrxnsForPeriodByStatus(GLBCurrentPeriod, "POST", "POST")
        R1 = -1
        R2 = -2
        If CheckDataSet(DsEmp) Then
            R1 = DsEmp.Tables(0).Rows.Count - 1
        End If
        If CheckDataSet(DsHeader) Then
            R2 = DsHeader.Tables(0).Rows.Count - 1
        End If
        If R1 = -1 Then
            Ans = MsgBox("There are no Active Employees, Do you want to continue and Close the Period?", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                DoNotCheck = True
            End If
        End If
        If Not DoNotCheck Then
            If R1 <> R2 Then
                MsgBox("Cannot Close Period,Please CALCULATE and POST and Interface Payroll for All Employees that belong to this Period", MsgBoxStyle.Information)
                Flag = False
                If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
                    Dim Ans2 As MsgBoxResult
                    Ans2 = MsgBox("Close Anyway ?", MsgBoxStyle.YesNoCancel)
                    If Ans2 = MsgBoxResult.Yes Then
                        Flag = True
                    End If

                End If
            End If
        End If
            Return Flag
    End Function

    Private Sub BtnPeriodNormalDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPeriodNormalDays.Click
        If Global1.PARAM_AnnualLeaveAllocation Then
            Dim F As New FrmPrMsEnterMonthNormalDays
            F.Period = Me.GLBCurrentPeriod
            F.ShowDialog()
        Else
            MsgBox("You have no setup for this feuture", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SetInactiveStatusToTerminatedemployees(True)
    End Sub
    Private Sub SetInactiveStatusToTerminatedemployees(ByVal ShowMsg As Boolean)
        If Me.GLBCurrentPeriod.Code <> "" Then


            Dim Ds As DataSet
            Ds = Global1.Business.GetTerminatedEmployeeswithStatusActive(GLBCurrentPeriod, GLBTempGroup.Code)
            If CheckDataSet(Ds) Then
                Dim F As New FrmTerminatedEmployees
                F.Owner = Me
                F.DsTerm = Ds
                F.ShowDialog()


            Else
                If ShowMsg Then
                    MsgBox("There are no Terminated employees on Previous Periods", MsgBoxStyle.Information)
                End If
                End If
        End If
    End Sub
    Public Sub MakeEmployeesInactive(ByVal Ds As DataSet)
        Try


            Dim i As Integer
            Dim EmpCode As String
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    EmpCode = DbNullToString(Ds.Tables(0).Rows(i).Item(0))
                    Global1.Business.SetEmpStatusToInactive(EmpCode)
                Next
                MsgBox("Process has finish", MsgBoxStyle.Information)
            Else
                MsgBox("No Active Employees with Termination date are found", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub
End Class