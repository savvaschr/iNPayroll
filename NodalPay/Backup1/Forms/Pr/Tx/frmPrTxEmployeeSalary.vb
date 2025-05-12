Public Class frmPrTxEmployeeSalary
    Public EmpCode As String
    Public EmpName As String
    Public Employee As cPrMsEmployees

    Dim tPrTxEmployeeSalary As New cPrTxEmployeeSalary
    Dim DG1Changing As Boolean = False
    Dim COLAPercentage As Double = 0
    Dim GLBCode As String = ""
    Dim tEffDate As Date = Now
    Dim OnlyNewIsenable As Boolean = False

    Public GrossFromCalc As Double = 0
    Private Sub frmPrTxEmployeeSalary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe()
        If GrossFromCalc <> 0 Then
            NewClick()
            Me.txtSalaryValue.Text = GrossFromCalc
        End If
    End Sub
    Public Sub LoadMe()
        Me.txtEmployeeCode.Text = EmpCode
        Me.txtEmployeeName.Text = EmpName


        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("System", "Salary_1_2")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            If Par.Value1 = "1" Then
                Global1.PARAM_Salary_1_2 = True
            Else
                Global1.PARAM_Salary_1_2 = False
            End If
        End If

        If Global1.PARAM_Salary_1_2 = True Then
            Me.txtSalaryValue.ReadOnly = True
            Me.lblBasic.Text = "Salary 1"
            Me.lblCola.Text = "Salary 2"
            Me.lblIsCola.Visible = False
            Me.CBIsCOLA.Visible = False
        End If

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        Me.LoadDataFromDG1(0)
        CheckPermitions()
    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Salary")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                TSBSave.Enabled = False
                Me.TSBDelete.Enabled = False
            End If
            If P.FullPermission = 2 Then
                OnlyNewIsenable = True
            End If
            
        End If
        
    End Sub
    Private Sub Initialize()
        LoadCombos()
        ClearMe()
        PutDecimalValidationOnTxts()
        FindCOLAPercentage()
    End Sub
    Private Sub FindCOLAPercentage()
        Dim CurrentPeriod As New cPrMsPeriodCodes()
        Dim Ds As DataSet
        Dim ds2 As DataSet
        Ds = Global1.Business.FindCurrentPeriod1(Employee.TemGrp_Code)
        If CheckDataSet(Ds) Then
            CurrentPeriod = New cPrMsPeriodCodes(Ds.Tables(0).Rows(0))
            tEffDate = CurrentPeriod.DateFrom
            ds2 = Global1.Business.GetActivelimitsForPeriod(CurrentPeriod)
            If CheckDataSet(ds2) Then
                Dim Limit As New cPrSsLimits(ds2.Tables(0).Rows(0))
                Me.COLAPercentage = Limit.Cola
            Else
                MsgBox("There are no Limits for period with Code " & CurrentPeriod.Code, MsgBoxStyle.Critical)
            End If

        Else
            MsgBox("There is no Open Period For Employees Template Group Code", MsgBoxStyle.Critical)

        End If
    End Sub
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        If Me.txtId.Text = "" Then
            Flag = False
            Me.ErrId.SetError(Me.txtId, "Field is Required")
        Else
            If Not IsNumeric(Me.txtId.Text) Then
                Flag = False
                Me.ErrId.SetError(Me.txtId, "Field requires a number")
            Else
                If NullToInt(Me.txtId.Text) < 0 Then
                    Flag = False
                    Me.ErrId.SetError(Me.txtId, "Field requires positive number")
                End If
            End If
        End If
        'If Me.cmbUsr.Text = "" Then
        '    Flag = False
        '    Me.ErrUsr_Id.SetError(Me.cmbUsr, "Field is Required")
        'Else
        '    If Not IsNumeric(Me.cmbUsr.Text) Then
        '        Flag = False
        '        Me.ErrUsr_Id.SetError(Me.cmbUsr, "Field requires a number")
        '    Else
        '        If NullToInt(Me.cmbUsr.Text) < 0 Then
        '            Flag = False
        '            Me.ErrUsr_Id.SetError(Me.cmbUsr, "Field requires positive number")
        '        End If
        '    End If
        'End If
       
        'If Flag Then
        '    If Me.txtId.Text <> "" Then
        '        If Not Me.txtId.ReadOnly Then
        '            Dim tPrTxEmployeeSalary As New cPrTxEmployeeSalary(CInt(Trim(Me.txtId.Text)))
        '            If tPrTxEmployeeSalary.Id <> 0 Then
        '                MsgBox("Item already exists - Can not be inserted", MsgBoxStyle.Critical)
        '                Flag = False
        '            End If
        '        End If
        '    End If
        'End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.DateCreation.Value = Now.Date
        Me.txtSalaryValue.Text = "0.00"
        Me.txtBasic.Text = "0.00"
        Me.DatePay.Value = Now.Date
        Me.txtCola.Text = "0.00"
        Me.txtUnitRate.Text = "0.0000"
        Me.txtSalary2ForRate.Text = "0.00"
        Me.DateArrears.Value = Now.Date
        Try
            Me.cmbUsr.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.CBIsCOLA.Checked = False
    End Sub
    '
    Private Sub LoadCombos()
        LoadAaSsUsers()
    End Sub
    '
    'Private Sub LoadPrMsEmployees()
    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.AG_GetAllPrMsEmployees()
    '    If CheckDataSet(ds) Then
    '        Dim tPrMsEmployees As New cPrMsEmployees
    '        With Me.cmbEmp_Code
    '            .BeginUpdate()
    '            .Items.Clear()
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                tPrMsEmployees = New cPrMsEmployees(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
    '                .Items.Add(tPrMsEmployees)
    '            Next i
    '            .ValueMember = "Emp_Code"
    '            .SelectedIndex = 0
    '            .EndUpdate()
    '        End With
    '    End If
    'End Sub
    Private Sub LoadAaSsUsers()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAaSsUsers()
        If CheckDataSet(ds) Then
            Dim tAaSsUsers As New cAaSsUsers
            With Me.cmbUsr
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
        AddHandler txtSalaryValue.KeyPress, AddressOf NumericKeyPress
        AddHandler txtSalaryValue.Leave, AddressOf NumericOnLeave
        AddHandler txtBasic.KeyPress, AddressOf NumericKeyPress
        AddHandler txtBasic.Leave, AddressOf NumericOnLeave
        AddHandler txtCola.KeyPress, AddressOf NumericKeyPress
        AddHandler txtCola.Leave, AddressOf NumericOnLeave

        AddHandler txtUnitRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtUnitRate.Leave, AddressOf NumericOnLeave4Decimals

        AddHandler txtSalary2ForRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtSalary2ForRate.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrId.SetError(Me.txtId, "")
        Me.ErrDate1.SetError(Me.DateCreation, "")
        Me.ErrSalaryValue.SetError(Me.txtSalaryValue, "")
        Me.ErrBasic.SetError(Me.txtBasic, "")
        Me.ErrEffPayDate.SetError(Me.DatePay, "")
        Me.ErrCola.SetError(Me.txtCola, "")
        Me.ErrEffArrearsDate.SetError(DateArrears, "")
        Me.ErrUsr_Id.SetError(Me.cmbUsr, "")
        Me.ErrIsCola.SetError(Me.CBIsCOLA, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        NewClick()
    End Sub
    Private Sub NewClick()
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrTxEmployeeSalary = New cPrTxEmployeeSalary
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtSalaryValue.Focus()
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
    Private Sub TryToSave(Optional ByVal SupressMsg As Boolean = False)
        If Me.OnlyNewIsenable Then
            If Me.txtId.Text <> 0 Then
                MsgBox("Edit Salary is not Enabled on Current user profile", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        If ValidateMe() Then
            Dim Update As Boolean = False
            'Dim CS As Integer
            Dim DsSal As DataSet
            DsSal = Global1.Business.GetDalaryDiference(EmpCode, DatePay.Value)
            Dim PreviusSalary As Double
            Dim Diff As Double = 0
            If CheckDataSet(DsSal) Then
                PreviusSalary = DbNullToDouble(DsSal.Tables(0).Rows(0).Item(0))
                Diff = RoundMe3(CDbl(Me.txtSalaryValue.Text) - PreviusSalary, 2)
            End If

            Try

                With tPrTxEmployeeSalary
                    .Id = NullToInt(Me.txtId.Text)
                    .Emp_Code = EmpCode
                    .Date1 = Now
                    .SalaryValue = CDbl(Me.txtSalaryValue.Text)
                    .Basic = CDbl(Me.txtBasic.Text)
                    .EffPayDate = DatePay.Value
                    .Cola = CDbl(Me.txtCola.Text)
                    .EffArrearsDate = DateArrears.Value
                    .Usr_Id = CType(Me.cmbUsr.SelectedItem, cAaSsUsers).Id
                    .myRate = Me.txtUnitRate.Text
                    .myRateSalary = Me.txtSalary2ForRate.Text
                    If Me.CBIsCOLA.CheckState = CheckState.Checked Then
                        .IsCola = "Y"
                    Else
                        .IsCola = "N"
                    End If
                    .EmpSal_Dif = Diff

                    If .Save() Then
                        If Not SupressMsg Then
                            Me.lblSSStatus.Text = "Changes are successfully Saved"
                        End If

                        FillDG1()
                        'If DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
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
    '
    Private Sub LoadDataSetToExcel()
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader
        'ds = Global1.Business.AG_GetAllPrTxEmployeeSalary()
        ds = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCode(EmpCode)
        HeaderStr.Add("id")
        HeaderStr.Add("Employee Code")
        HeaderStr.Add("Date")
        HeaderStr.Add("Salary Value")
        HeaderStr.Add("Basic Value")
        HeaderStr.Add("Pay Date")
        HeaderStr.Add("Cola Value")
        HeaderStr.Add("Arrears Date")
        HeaderStr.Add("User Id")
        HeaderStr.Add("Is Cola Enabled")
        HeaderStr.Add("My Rate")
        HeaderStr.Add("Salary 2 for Rate")
        HeaderSize.Add(15)
        HeaderSize.Add(16)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrTxEmployeeSalary(ByVal tId As Integer)
        tPrTxEmployeeSalary = New cPrTxEmployeeSalary(tId)
        If tPrTxEmployeeSalary.Id <> 0 Then
            With tPrTxEmployeeSalary
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.DateCreation.Value = CDate(.Date1)
                Me.txtSalaryValue.Text = Format(.SalaryValue, "0.00")
                Me.txtBasic.Text = Format(.Basic, "0.00")
                Me.DatePay.Value = CDate(.EffPayDate)
                Me.txtCola.Text = Format(.Cola, "0.00")
                Me.DateArrears.Value = CDate(.EffArrearsDate)
                Dim User As New cAaSsUsers(.Usr_Id)
                Me.cmbUsr.SelectedIndex = Me.cmbUsr.FindStringExact(User.ToString)
                Me.txtUnitRate.Text = Format(.myRate, "0.0000")
                Me.txtSalary2ForRate.Text = Format(.myRateSalary, "0.00")

                If CStr(.IsCola) = "Y" Then
                    Me.CBIsCOLA.Checked = True
                Else
                    Me.CBIsCOLA.Checked = False
                End If
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCode(EmpCode)
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
            If tPrTxEmployeeSalary.Delete(CInt(Trim(Me.txtId.Text))) Then
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
        Me.lblSSStatus.Text = ""
        If Me.DG1.RowCount > 0 Then
            Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.DateCreation.Value = DbNullToDate(DG1.Item(2, i).Value)
            Me.txtSalaryValue.Text = DbNullToString(DG1.Item(3, i).Value)
            Me.txtBasic.Text = DbNullToString(DG1.Item(4, i).Value)
            Me.txtCola.Text = DbNullToString(DG1.Item(5, i).Value)
            If DbNullToString(DG1.Item(6, i).Value) = "Y" Then
                Me.CBIsCOLA.Checked = True
            Else
                Me.CBIsCOLA.Checked = False
            End If
            Me.DatePay.Value = DbNullToDate(DG1.Item(7, i).Value)
            Dim Usr As New cAaSsUsers(DbNullToInt(DG1.Item(8, i).Value))
            Me.cmbUsr.SelectedIndex = cmbUsr.FindStringExact(Usr.ToString)
            Me.DateArrears.Value = DbNullToDate(DG1.Item(9, i).Value)
            Me.txtUnitRate.Text = DbNullToDecimal(DG1.Item(10, i).Value)
            Me.txtSalary2ForRate.Text = DbNullToDecimal(DG1.Item(11, i).Value)
        End If
      
        
        
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub

    Private Sub CBIsCOLA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIsCOLA.CheckedChanged
        If CBIsCOLA.CheckState = CheckState.Checked Then
            FixSalary(True)
        Else
            FixSalary(False)
        End If
    End Sub
    Private Sub FixSalary(ByVal ColaIsEnabled As Boolean)
        Dim Gross As Double = 0.0
        Dim Basic As Double = 0.0
        Dim Cola As Double = 0.0
        Basic = Me.txtBasic.Text
        If ColaIsEnabled Then
            Gross = RoundMe3(Basic * (1 + (COLAPercentage / 100)), 2)
            Cola = Gross - Basic
        Else
            Basic = Me.txtBasic.Text
            Gross = Basic
        End If
        Me.txtSalaryValue.Text = Format(Gross, "0.00")
        Me.txtCola.Text = Format(Cola, "0.00")
    End Sub
    Private Sub CalculateBasic()
        Dim Gross As Double = 0.0
        Dim Basic As Double = 0.0
        Dim Cola As Double = 0.0
        Gross = Me.txtSalaryValue.Text
        Basic = RoundMe3(Gross / (1 + COLAPercentage / 100), 2)
        Me.txtBasic.Text = Format(Basic, "0.00")
        '   Me.txtCola.Text = Format(Gross - Basic, "0.00")

    End Sub

    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()

        For i = 0 To Me.DG1.RowCount - 1
            If DbNullToString(DG1.Item(0, i).Value) = MapColumn Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(2)
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

    Private Sub btnCalculateBasic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateBasic.Click
        Me.CalculateBasic()
    End Sub

    Private Sub BtnCalculateSalaryForCOLA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalculateSalaryForCOLA.Click
        Dim Ans As New MsgBoxResult
        Ans = MsgBox("This will Re-Calculate Salaries based on Basic Salary and COLA,Proceed?", MsgBoxStyle.YesNoCancel)
        If Ans = MsgBoxResult.Yes Then


            Dim EmpCode As String
            GLBCode = ""
            GetEmployee(GLBCode, True)
            Do While GLBCode <> ""

                Application.DoEvents()
                If GLBCode <> "" Then
                    FillDG1()
                    Me.LoadDataFromDG1(0)
                    If Me.CBIsCOLA.CheckState = CheckState.Checked Then
                        FixSalary(True)
                        Me.txtId.Text = "0"
                        Me.DateCreation.Value = Now.Date
                        Me.DatePay.Value = tEffDate.Date
                        Me.DateArrears.Value = tEffDate.Date
                        Me.TryToSave(True)
                    End If
                End If
                Application.DoEvents()
                EmpCode = GLBCode
                GetEmployee(GLBCode, True)
                If GLBCode = EmpCode Then
                    Exit Do
                End If
                Application.DoEvents()
            Loop
            MsgBox("Process Finished", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub GetEmployee(ByVal Code As String, ByVal NextEmp As Boolean)
        Dim ds As DataSet
        ds = Global1.Business.FindEmployee(Code, NextEmp)
        If CheckDataSet(ds) Then
            Dim Emp As New cPrMsEmployees(DbNullToString(ds.Tables(0).Rows(0).Item(0)))
            GLBCode = Emp.Code
            EmpCode = GLBCode
            Employee = Emp
        Else
            MsgBox("No Record Found", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim id As Integer
        Dim sal As Double = -1
        Dim sal2 As Double = -1
        Dim dif As Double
        For i = Me.DG1.RowCount - 1 To 0 Step -1
            id = DbNullToInt(DG1.Item(0, i).Value)
            Dim trx As New cPrTxEmployeeSalary(id)

            sal = trx.SalaryValue
            If sal2 <> -1 Then
                dif = sal - sal2
            End If
            sal2 = sal

            trx.EmpSal_Dif = dif
            trx.Save()



        Next
    End Sub

    Private Sub txtBasic_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBasic.TextChanged
        If Global1.PARAM_Salary_1_2 = True Then
            Dim S1 As String
            Dim S2 As String
            Dim D1 As Double = 0
            Dim D2 As Double = 0
            S1 = Me.txtBasic.Text
            S2 = Me.txtCola.Text

            If IsNumeric(S1) Then
                D1 = S1
            End If
            If IsNumeric(S2) Then
                D2 = S2
            End If
            Me.txtSalaryValue.Text = D1 + D2
        End If
    End Sub

    Private Sub txtCola_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCola.TextChanged
        If Global1.PARAM_Salary_1_2 = True Then
            Dim S1 As String
            Dim S2 As String
            Dim D1 As Double = 0
            Dim D2 As Double = 0
            S1 = Me.txtBasic.Text
            S2 = Me.txtCola.Text

            If IsNumeric(S1) Then
                D1 = S1
            End If
            If IsNumeric(S2) Then
                D2 = S2
            End If
            Me.txtSalaryValue.Text = D1 + D2
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Gross As Double = 0.0
        Dim Basic As Double = 0.0
        Dim Cola As Double = 0.0
        Basic = Me.txtBasic.Text
        If Me.CBIsCOLA.Checked Then
            Gross = RoundMe3(Basic * (1 + (COLAPercentage / 100)), 2)
            Cola = Gross - Basic
            Me.txtSalaryValue.Text = Format(Gross, "0.00")
            Me.txtCola.Text = Format(Cola, "0.00")
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
                Ds = Global1.Business.GetAllPrTxEmployeeSalaryByEmpCode(FromCode)
                If CheckDataSet(Ds) Then
                    Dim i As Integer
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        Dim id As Integer
                        id = DbNullToInt(Ds.Tables(0).Rows(i).Item(0))
                        Dim Sal As New cPrTxEmployeeSalary(id)
                        Sal.Id = 0
                        Sal.Emp_Code = EmpCode
                        If Not Sal.Save() Then
                            Throw Exx
                        End If
                    Next
                Else
                    MsgBox("There are no Data to Copy From", MsgBoxStyle.Information)
                End If
                Global1.Business.CommitTransaction()
                MsgBox("Succesfull Copy of data", MsgBoxStyle.Information)
                FillDG1()
            Else
                MsgBox("Employee with Code " & FromCode & " Does not exists ", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            Global1.Business.Rollback()
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.DateArrears.Value = Me.DatePay.Value
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        CType(Me.Owner, frmPrMsEmployees).NextEmployee_OnSalary(Me)
    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        CType(Me.Owner, frmPrMsEmployees).PreviousEmployee_OnSalary(Me)
    End Sub
End Class
