Public Class FrmPrTxEmployeeLeave
    Public EmpCode As String
    Public Employee As cPrMsEmployees
    Dim tPrTxEmployeeLeave As New cPrTxEmployeeLeave
    Dim DG1Changing As Boolean = False
    Dim COLAPercentage As Double = 0
    
    Dim dsLeaveTypes As DataSet
    Dim GlbTmpGrp As New cPrMsTemplateGroup
    Public PrintYear As String = ""


    Private Sub frmPrTxEmployeeLeave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        LoadMe()
    End Sub



    Private Sub LoadPrMsPeriodGroups()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrMsPeriodGroups()
        If CheckDataSet(ds) Then
            Dim tPrMsPeriodGroups As New cPrMsPeriodGroups
            With Me.cmbPrdGrp_Code
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrMsPeriodGroups = New cPrMsPeriodGroups(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    If tPrMsPeriodGroups.TemGrpCode = Employee.TemGrp_Code Then
                        .Items.Add(tPrMsPeriodGroups)
                    End If
                Next i
                .ValueMember = "PrdGrp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Public Sub LoadMe()
        Me.txtEmployeeCode.Text = Employee.Code
        Me.txtEmployeeName.Text = Employee.FullName

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        GlbTmpGrp = New cPrMsTemplateGroup(Employee.TemGrp_Code)
        CheckPermitions()
    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "AnnualLeave")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                TSBSave.Enabled = False
                Me.TSBDelete.Enabled = False
            End If
        End If

    End Sub
    Private Sub Initialize()
        LoadCombos()
        ClearMe()
        PutDecimalValidationOnTxts()
        Dim i As Integer
        For i = 0 To Me.cmbPrdGrp_Code.Items.Count - 1
            If CType(Me.cmbPrdGrp_Code.Items(i), cPrMsPeriodGroups).Year = Now.Date.Year Then
                Me.cmbPrdGrp_Code.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        'If Me.txtId.Text = "" Then
        '    Flag = False
        '    Me.ErrId.SetError(Me.txtId, "Field is Required")
        'Else
        '    If Not IsNumeric(Me.txtId.Text) Then
        '        Flag = False
        '        Me.ErrId.SetError(Me.txtId, "Field requires a number")
        '    Else
        '        If NullToInt(Me.txtId.Text) < 0 Then
        '            Flag = False
        '            Me.ErrId.SetError(Me.txtId, "Field requires positive number")
        '        End If
        '    End If
        'End If

        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.ComboStatus.SelectedIndex = 1
        Me.ComboType.SelectedIndex = 0
        Me.DateFrom.Value = Now.Date
        Me.DateTo.Value = Now.Date
        Me.DateProc.Value = Now.Date
        Me.DateReq.Value = Now.Date
        Me.txtUnits.Text = "0.00"
        Me.txtComment.Text = ""
        Me.txtApprovedBy.Text = ""
        Try
            Me.comboUser.SelectedIndex = 0
        Catch ex As Exception
        End Try

    End Sub
    '
    Private Sub LoadCombos()
        LoadAaSsUsers()
        LoadStatus()
        LoadLeaveTypes()
        LoadComboAction()
        LoadPrMsPeriodGroups()
        
    End Sub
    Private Sub LoadComboAction()
        With Me.ComboAction
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(AN_Decrease)
            .Items.Add(AN_Increase)
            .Items.Add(AN_CarryForward)
            .Items.Add(AN_EndOfYear)
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadStatus()
        With Me.ComboStatus
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(AN_Requested)
            .Items.Add(AN_Approved)
            .Items.Add(AN_Rejected)
            .EndUpdate()
            .SelectedIndex = 1
        End With
    End Sub
    Private Sub LoadLeaveTypes()

        Dim i As Integer
        dsLeaveTypes = Global1.Business.AG_GetAllPrSsLeaveTypes
        If CheckDataSet(dsLeaveTypes) Then
            Dim LeaveType As New cPrSsLeaveTypes
            With Me.ComboType
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To dsLeaveTypes.Tables(0).Rows.Count - 1
                    LeaveType = New cPrSsLeaveTypes(DbNullToString(dsLeaveTypes.Tables(0).Rows(i).Item(0)))
                    .Items.Add(LeaveType)
                Next i
                .EndUpdate()
            End With
        End If
    End Sub

    Private Sub LoadAaSsUsers()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAaSsUsers()
        If CheckDataSet(ds) Then
            Dim tAaSsUsers As New cAaSsUsers
            With Me.comboUser
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tAaSsUsers = New cAaSsUsers(DbNullToInt(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tAaSsUsers)
                Next i
                .ValueMember = "Usr_Id"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtUnits.KeyPress, AddressOf NumericKeyPressWithNegative
        AddHandler txtUnits.Leave, AddressOf NumericOnLeaveWithNegative
    End Sub
    '
    Private Sub ClearErrors()
        'Me.ErrId.SetError(Me.txtId, "")
        'Me.ErrDate1.SetError(Me.DateCreation, "")
        'Me.ErrSalaryValue.SetError(Me.txtSalaryValue, "")
        'Me.ErrBasic.SetError(Me.txtBasic, "")
        'Me.ErrEffPayDate.SetError(Me.DatePay, "")
        'Me.ErrCola.SetError(Me.txtCola, "")
        'Me.ErrEffArrearsDate.SetError(DateArrears, "")
        'Me.ErrUsr_Id.SetError(Me.cmbUsr, "")
        'Me.ErrIsCola.SetError(Me.CBIsCOLA, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrTxEmployeeLeave = New cPrTxEmployeeLeave
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.ComboStatus.Focus()
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    '
    Private Sub TSBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSave.Click
        Me.TSBSave.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        TryToSave()
        Me.TSBSave.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TryToSave()
        If ValidateMe() Then
            Dim Update As Boolean = False
            Try
                With tPrTxEmployeeLeave
                    .Id = NullToInt(Me.txtId.Text)
                    .EmpCode = EmpCode
                    .Status = Me.ComboStatus.Text
                    .Type = CType(Me.ComboType.SelectedItem, cPrSsLeaveTypes).Code
                    .ReqDate = Me.DateReq.Value.Date
                    .ProcDate = Me.DateProc.Value.Date
                    .FromDate = Me.DateFrom.Value.Date
                    .ToDate = Me.DateTo.Value.Date
                    .ProcBy = CType(Me.comboUser.SelectedItem, cAaSsUsers).Id
                    .Units = Me.txtUnits.Text

                    .Comment = Me.txtComment.Text
                    .ApprovedBy = Me.txtApprovedBy.Text

                    .Action = FindAction()
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        FillDG1()
                        FindWhereToSelect(.Id)
                        PKInputReadOnly(True)
                    Else
                        MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
                    End If
                End With
            Catch ex As Exception
                Utils.ShowException(ex)
                MsgBox("Unable to save Changes", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Function FindAction() As String
        Dim Str As String = ""
        Select Case Me.ComboAction.Text
            Case AN_Decrease
                Str = AN_DecreaseCODE
            Case AN_Increase
                Str = AN_IncreaseCODE
            Case AN_CarryForward
                Str = AN_CarryForwardCODE
            Case AN_EndOfYear
                Str = AN_EndOfYearCODE
        End Select
        Return Str
    End Function
    '
    Private Sub LoadDataSetToExcel()
        'Dim ds As DataSet
        'Dim HeaderStr As New ArrayList
        'Dim HeaderSize As New ArrayList
        'Dim Loader As New cExcelLoader

        'ds = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCode(EmpCode)
        'HeaderStr.Add("id")
        'HeaderStr.Add("Employee Code")
        'HeaderStr.Add("Date")
        'HeaderStr.Add("Salary Value")
        'HeaderStr.Add("Basic Value")
        'HeaderStr.Add("Pay Date")
        'HeaderStr.Add("Cola Value")
        'HeaderStr.Add("Arrears Date")
        'HeaderStr.Add("User Id")
        'HeaderStr.Add("Is Cola Enabled")
        'HeaderSize.Add(15)
        'HeaderSize.Add(16)
        'HeaderSize.Add(12)
        'HeaderSize.Add(18)
        'HeaderSize.Add(18)
        'HeaderSize.Add(12)
        'HeaderSize.Add(18)
        'HeaderSize.Add(12)
        'HeaderSize.Add(15)
        'HeaderSize.Add(1)
        'Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrTxEmployeeLeave(ByVal tId As Integer)
        tPrTxEmployeeLeave = New cPrTxEmployeeLeave(tId)
        If tPrTxEmployeeLeave.Id <> 0 Then
            With tPrTxEmployeeLeave
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.DateFrom.Value = CDate(.FromDate)
                Me.DateTo.Value = CDate(.ToDate)
                Me.DateReq.Value = CDate(.ReqDate)
                Me.DateProc.Value = CDate(.ProcDate)
                Me.txtUnits.Text = Format(.Units, "0.00")
                Dim User As New cAaSsUsers(.ProcBy)
                Me.comboUser.SelectedIndex = Me.comboUser.FindStringExact(User.ToString)

                Me.ComboStatus.SelectedIndex = Me.ComboStatus.FindStringExact(.Status)
                Dim Leave As New cPrSsLeaveTypes(.Type)
                Me.ComboType.SelectedIndex = Me.ComboType.FindStringExact(Leave.ToString)
                Me.ComboAction.SelectedIndex = Me.ComboAction.FindStringExact(ComboActionValue(.Action))
                Me.txtComment.Text = .Comment
                Me.txtApprovedBy.Text = .ApprovedBy
            End With
        End If
    End Sub
    Private Function ComboActionValue(ByVal Code As String) As String
        Dim Str As String = ""
        Select Case Code
            Case AN_DecreaseCODE
                Str = AN_Decrease
            Case AN_IncreaseCODE
                Str = AN_Increase
            Case AN_CarryForwardCODE
                Str = AN_CarryForward
            Case AN_EndOfYearCODE
                Str = AN_EndOfYear
        End Select
        Return Str
    End Function
    Private Sub FillDG1()

        Dim tPrmsperiodgroups As New cPrMsPeriodGroups
        tPrmsperiodgroups = CType(Me.cmbPrdGrp_Code.SelectedItem, cPrMsPeriodGroups)



        Dim ds As DataSet
        ds = Global1.Business.GetAllPrTxEmployeeLeaveByEmpCodeAndYear(EmpCode, tPrmsperiodgroups.Year)
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
    End Sub
    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        If DG1Changing = False Then
            Try
                Dim i As Integer
                i = DG1.CurrentRow.Index
                LoadDataFromDG1(i)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Me.TSBDelete.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Dim Response As Integer
        Response = MsgBox("Are you sure you want to delete record " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrTxEmployeeLeave.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
                FillDG1()
                Me.LoadDataFromDG1(0)
            Else
                MsgBox("No deletion took place")
            End If
        End If
        Me.TSBDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDataFromDG1(ByVal i As Integer)
        Me.ClearMe()
        Call ClearErrors()
        Dim Action As String
        Me.lblSSStatus.Text = ""
        If Me.DG1.RowCount > 0 Then

            Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.ComboStatus.SelectedIndex = Me.ComboStatus.FindStringExact(DbNullToString(DG1.Item(1, i).Value))
            Dim Leave As New cPrSsLeaveTypes(DbNullToString(DG1.Item(3, i).Value))
            Me.ComboType.SelectedIndex = Me.ComboType.FindStringExact(Leave.ToString)
            Me.DateReq.Value = CDate(DbNullToString(DG1.Item(4, i).Value))
            Me.DateProc.Value = CDate(DbNullToString(DG1.Item(5, i).Value))
            Dim User As New cAaSsUsers(DbNullToString(DG1.Item(6, i).Value))
            Me.DateFrom.Value = CDate(DbNullToString(DG1.Item(7, i).Value))
            Me.DateTo.Value = CDate(DbNullToString(DG1.Item(8, i).Value))
            Me.txtUnits.Text = Format(DbNullToDouble(DG1.Item(9, i).Value), "0.00")
            Me.comboUser.SelectedIndex = Me.comboUser.FindStringExact(User.ToString)

            Action = DG1.Item(10, i).Value
            Me.ComboAction.SelectedIndex = Me.ComboAction.FindStringExact(ComboActionValue(Action))

            Me.txtComment.Text = DbNullToString(DG1.Item(12, i).Value)
            Me.txtApprovedBy.Text = DbNullToString(DG1.Item(13, i).Value)

        End If



        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub

    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()

        For i = 0 To Me.DG1.RowCount - 1
            If DbNullToString(DG1.Item(0, i).Value) = MapColumn Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(3)
                LoadDataFromDG1(i)
                Exit Sub
            End If
        Next

    End Sub
    Private Sub UnsellectAll()
        Dim i As Integer
        For i = 0 To Me.DG1.RowCount - 1
            DG1.Rows(i).Selected = False
        Next
    End Sub

    Private Sub TSBShowTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBShowTotals.Click
        Dim Ds As DataSet
        Dim Per As cPrMsPeriodCodes
        Dim FromDate As Date
        Dim ToDate As Date
        Dim LeaveType As cPrSsLeaveTypes

        Dim Str As String = ""
        Ds = Global1.Business.FindCurrentPeriod1(Employee.TemGrp_Code)
        If CheckDataSet(Ds) Then
            Dim i As Integer
            Per = New cPrMsPeriodCodes(Ds.Tables(0).Rows(0))
            FromDate = CDate(Per.DateFrom.Year & "/" & "01/01")
            ToDate = CDate(Per.DateFrom.Year & "/" & "12/31")
            If CheckDataSet(dsLeaveTypes) Then
                Dim Tot As Double = 0
                For i = 0 To dsLeaveTypes.Tables(0).Rows.Count - 1
                    Tot = 0
                    LeaveType = New cPrSsLeaveTypes(dsLeaveTypes.Tables(0).Rows(i))
                    Tot = Global1.Business.GetEmployeeTotalPerTypePerAction(Employee.Code, LeaveType.Code, AN_IncreaseCODE, FromDate, ToDate, AN_Approved)
                    Tot = Tot + Global1.Business.GetEmployeeTotalPerTypePerAction(Employee.Code, LeaveType.Code, AN_CarryForwardCODE, FromDate, ToDate, AN_Approved)
                    Tot = Tot - Global1.Business.GetEmployeeTotalPerTypePerAction(Employee.Code, LeaveType.Code, AN_DecreaseCODE, FromDate, ToDate, AN_Approved)
                    Tot = Tot - Global1.Business.GetEmployeeTotalPerTypePerAction(Employee.Code, LeaveType.Code, AN_EndOfYearCODE, FromDate, ToDate, AN_Approved)
                    Str = Str & LeaveType.Code & " " & LeaveType.DescriptionL & " Balance: " & RoundMe3(Tot, 2) & " Units.   " & RoundMe3(Tot / GlbTmpGrp.DayUnits, 2) & " Days." & Chr(13)
                Next
            End If
            MsgBox(Str)
        End If
    End Sub

    Private Sub ComboAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboAction.SelectedIndexChanged
        If Me.ComboAction.Text = AN_EndOfYear Then
            Me.TSBSave.Enabled = False
            Me.TSBDelete.Enabled = False
        Else
            Me.TSBSave.Enabled = True
            Me.TSBDelete.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Exx As New System.Exception
        Try

            Dim FromCode As String
            FromCode = Me.txtCopyFrom.Text
            Dim Ds As DataSet
            Dim tEmp As New cPrMsEmployees(FromCode)
            If tEmp.Code <> "" Then
                Global1.Business.BeginTransaction()
                Ds = Global1.Business.GetAllPrTxEmployeeLeaveByEmpCode(FromCode)
                If CheckDataSet(Ds) Then
                    Dim i As Integer
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        Dim Al As New cPrTxEmployeeLeave(Ds.Tables(0).Rows(i))
                        Al.Id = 0
                        Al.EmpCode = EmpCode
                        If Not Al.Save() Then
                            Throw Exx
                        End If
                    Next
                Else
                    MsgBox("There are no Data to Copy From", MsgBoxStyle.Information)
                End If
                Global1.Business.CommitTransaction()
                FillDG1()
                MsgBox("Succesfull Copy of data", MsgBoxStyle.Information)
            Else
                MsgBox("Employee with Code " & FromCode & " Does not exists ", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub TsbPrintStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbPrintStatement.Click
        Dim F As New FrmALStatementSelectYear
        F.Owner = Me
        F.ShowDialog()

        Dim DsP As New DataSet
        Dim ALType As String
        ALType = CType(Me.ComboType.SelectedItem, cPrSsLeaveTypes).Code
        DsP = Global1.Business.GetAllPrTxEmployeeLeaveByEmpCodeOfYear(Employee.Code, PrintYear, ALType)
        Dim TemGrp As New cPrMsTemplateGroup(Employee.TemGrp_Code)
        Dim Units As Double = TemGrp.DayUnits
        If CheckDataSet(DsP) Then
            Dim i As Integer
            Dim Action As String = ""
            Dim AL As Double = 0
            Dim ALDays As Double = 0
            Dim TotalAL As Double = 0
            Dim TotalALDays As Double = 0
            Dim FD As String
            Dim TD As String
            For i = 0 To DsP.Tables(0).Rows.Count - 1
                Action = DbNullToString(DsP.Tables(0).Rows(i).Item(13))
                AL = DbNullToString(DsP.Tables(0).Rows(i).Item(12))
                ALDays = RoundMe2(AL / Units, 2)
                DsP.Tables(0).Rows(i).Item(15) = ALDays
                If Action = "CF" Or Action = "IN" Then
                    TotalAL = TotalAL + AL
                    TotalALDays = TotalALDays + ALDays
                ElseIf Action = "DE" Then
                    TotalAL = TotalAL - AL
                    TotalALDays = TotalALDays - ALDays
                End If
                FD = Format(DbNullToDate(DsP.Tables(0).Rows(i).Item(10)), "dd-MM-yyyy")
                TD = Format(DbNullToDate(DsP.Tables(0).Rows(i).Item(11)), "dd-MM-yyyy")

                DsP.Tables(0).Rows(i).Item(19) = FD
                DsP.Tables(0).Rows(i).Item(20) = TD

            Next
            For i = 0 To DsP.Tables(0).Rows.Count - 1
                DsP.Tables(0).Rows(i).Item(16) = TotalAL
                DsP.Tables(0).Rows(i).Item(17) = TotalALDays
            Next
        End If


        ' Utils.WriteSchemaWithXmlTextWriter(DsP, "C:\Users\Administrator\Documents\Visual Studio 2005\Projects\NodalPay - 2019\NodalPay\XML\AlReport")

        Dim ReportToUse As String = "ALReport.rpt"

        Utils.ShowReport(ReportToUse, DsP, FrmReport, "Annual Leave Report", False, "", False, False, "", False)


    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        CType(Me.Owner, frmPrMsEmployees).NextEmployee_OnLeave(Me)
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        CType(Me.Owner, frmPrMsEmployees).PreviousEmployee_OnLeave(Me)
    End Sub

    Private Sub cmbPrdGrp_Code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrdGrp_Code.SelectedIndexChanged
        FillDG1()

    End Sub
End Class