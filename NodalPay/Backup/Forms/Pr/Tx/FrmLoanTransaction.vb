Public Class FrmLoanTransaction
    Public PasswordforDeletion As String

    Public EmpCode As String
    Public Employee As cPrMsEmployees
    Dim tPrTxEmployeeLoan As New cPrTxEmployeeLoan
    Dim DG1Changing As Boolean = False

    Dim dsLeaveTypes As DataSet

    Public GlbTmpGrp As New cPrMsTemplateGroup

    Public PeriodCode As String
    Public PeriodGroup As String

    Private Sub FrmLoanTransaction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
            Me.TSBDelete.Enabled = False
        End If
        FillDG1("")
        GlbTmpGrp = New cPrMsTemplateGroup(Employee.TemGrp_Code)
        Me.NewLoan()
        CheckPermitions()
    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Salary")
        If P.id > 0 Then
            If P.ReadonlyPermission = 1 Then
                TSBSave.Enabled = False
            End If
        End If

    End Sub
    Public Sub LoadLoansOfCode(ByVal code As String)
        ClearMe(True)
        NewPayment()
        Me.FillDG1(code)
        'LoadRemainingamount(code)
    End Sub
    Private Sub LoadRemainingAmount(ByVal LoanCode As String)
        Dim RemAmount As Double
        RemAmount = Global1.Business.GetEmployeeLoanTotal(EmpCode, LoanCode)
        Me.txtRemAmount.Text = Format(RoundMe2(RemAmount, 2), "0.00")

    End Sub
    Private Sub Initialize()
        LoadCombos()
        ClearMe(True)
        PutDecimalValidationOnTxts()
    End Sub
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        If Me.txtId.Text = 0 Then
            If Me.ComboStatus.SelectedItem.ToString = Global1.AN_Issue Then
                If Global1.Business.IsThereALoanWithTheSameCode(EmpCode, Me.txtLoanCode.Text) Then
                    MsgBox("There is A loan with the same code Already for this Employee", MsgBoxStyle.Critical)
                    Flag = False
                End If
            End If
        End If
        If Me.txtLoanCode.Text = "" Then
            MsgBox("Pleease select Valid Loan Code", MsgBoxStyle.Critical)
            Flag = False
        End If
        If Me.txtDesc.Text = "" Then
            MsgBox("Pleease Enter a Loan Description", MsgBoxStyle.Critical)
            Flag = False
        End If
        If Me.txtTotalAmount.Text = 0 Then
            If Me.txtTotalAmount.Enabled Then
                MsgBox("Loan Must Have a Total Amount", MsgBoxStyle.Critical)
                Flag = False
            End If
        End If
        If Global1.Business.IsThereAnActiveLoanForThisDeductionCode(EmpCode, Me.txtLoanCode.Text, Me.ComboDedCode.SelectedItem.ToString) Then
            MsgBox("There is already a Loan linked to this Deduction Code for this Employee", MsgBoxStyle.Critical)
            Flag = True
        End If


        Return Flag
    End Function
    Private Sub ClearMe(ByVal TF As Boolean)

        Me.txtId.Text = "0"
        Me.txtHeaderId.Text = "0"
        If TF Then
            Me.txtLoanCode.Text = ""
            Me.txtDesc.Text = ""
        End If
        Me.txtAmount.Text = 0
        Me.txtTotalAmount.Text = 0
        Me.txtInterest.Text = 0
        Me.txtMonthlyAmount.Text = 0
        Me.txtPayment.Text = 0
        Me.DateFrom.Value = Now.Date
        Try
            Me.ComboStatus.SelectedIndex = 0
        Catch ex As Exception

        End Try
        Try
            Me.ComboDedCode.SelectedIndex = 0
        Catch ex As Exception

        End Try
        Try
            Me.ComboAction.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadCombos()
        LoadStatus()
        LoadDeductionCodes()
        LoadComboAction()
    End Sub
    Private Sub LoadComboAction()
        With Me.ComboAction
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(AN_Issue)
            .Items.Add(AN_Payment)
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadStatus()
        With Me.ComboStatus
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(AN_OPEN)
            .Items.Add(AN_CLOSED)
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadDeductionCodes()

        Dim i As Integer
        Dim Ds As DataSet
        Ds = Global1.Business.GetDeductionCodesForLoans
        If CheckDataSet(Ds) Then
            Dim dedcode As New cPrMsDeductionCodes
            With Me.ComboDedCode
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    dedcode = New cPrMsDeductionCodes(DbNullToString(Ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(dedcode)
                Next i
                .EndUpdate()
                .SelectedIndex = 0
            End With
        End If
    End Sub


    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtAmount.KeyPress, AddressOf NumericKeyPress
        AddHandler txtAmount.Leave, AddressOf NumericOnLeave
        AddHandler txtTotalAmount.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTotalAmount.Leave, AddressOf NumericOnLeave
        AddHandler txtInterest.KeyPress, AddressOf NumericKeyPress
        AddHandler txtInterest.Leave, AddressOf NumericOnLeave
        AddHandler txtMonthlyAmount.KeyPress, AddressOf NumericKeyPress
        AddHandler txtMonthlyAmount.Leave, AddressOf NumericOnLeave
        AddHandler txtPayment.KeyPress, AddressOf NumericKeyPress
        AddHandler txtPayment.Leave, AddressOf NumericOnLeave
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

    '
    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
        ' Me.TSBExcel.Enabled = True
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
                With tPrTxEmployeeLoan
                    .Id = NullToInt(Me.txtId.Text)
                    .LoanCode = Me.txtLoanCode.Text
                    .EmpCode = EmpCode
                    .TempGroupCode = GlbTmpGrp.Code
                    .PeriodCode = PeriodCode
                    .PeriodGroup = PeriodGroup
                    .DedCode = CType(Me.ComboDedCode.SelectedItem, cPrMsDeductionCodes).Code
                    .TrxHdr_Id = 0
                    .LoanDate = Me.DateFrom.Value.Date
                    .Amount = Me.txtAmount.Text
                    .Interest = Me.txtInterest.Text
                    .TotalAmount = Me.txtTotalAmount.Text
                    .Description = Me.txtDesc.Text
                    .MonthlyAmount = Me.txtMonthlyAmount.Text
                    .Type = Me.ComboAction.SelectedItem.ToString
                    .Payment = Me.txtPayment.Text
                    .UserId = Global1.GLBUserId
                    .Status = Me.ComboStatus.Text

                    If .Save() Then
                        MsgBox("Changes are successfully Saved")
                        FillDG1(txtLoanCode.Text)
                        FindWhereToSelect(.Id)
                        PKInputReadOnly(True)
                        If Global1.Business.GetEmployeeLoanTotal(EmpCode, .LoanCode) = 0 Then
                            If Global1.Business.ChangeStatusofLoan(EmpCode, .LoanCode) Then
                                MsgBox("Loan Status is now Closed", MsgBoxStyle.Information)
                                Me.FillDG1(.LoanCode)
                            End If
                        End If
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
    'Private Function FindAction() As String
    '    Dim Str As String = ""
    '    Select Case Me.ComboAction.Text
    '        Case AN_Decrease
    '            Str = AN_DecreaseCODE
    '        Case AN_Increase
    '            Str = AN_IncreaseCODE
    '        Case AN_CarryForward
    '            Str = AN_CarryForwardCODE
    '        Case AN_EndOfYear
    '            Str = AN_EndOfYearCODE
    '    End Select
    '    Return Str
    'End Function
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
    Private Sub LoadPrTxEmployeeLoan(ByVal tId As Integer)
        tPrTxEmployeeLoan = New cPrTxEmployeeLoan(tId)
        If tPrTxEmployeeLoan.Id <> 0 Then
            With tPrTxEmployeeLoan
                Me.txtId.Text = .Id
                txtLoanCode.Text = .LoanCode
                EmpCode = .EmpCode
                GlbTmpGrp.Code = .TempGroupCode
                PeriodCode = .PeriodCode
                PeriodGroup = .PeriodGroup
                Dim tDedCode As New cPrMsDeductionCodes(.DedCode)
                FindDeduction(tDedCode)
                'Me.ComboDedCode.SelectedItem = CType(tDedCode, cPrMsDeductionCodes)
                Me.txtHeaderId.Text = .TrxHdr_Id
                DateFrom.Value = .LoanDate
                txtAmount.Text = Format(.Amount, "0.00")
                Me.txtInterest.Text = Format(.Interest, "0.00")
                Me.txtTotalAmount.Text = Format(.TotalAmount, "0.00")
                Me.txtDesc.Text = .Description
                Me.txtMonthlyAmount.Text = Format(.MonthlyAmount, "0.00")
                Me.ComboAction.SelectedItem = .Type
                Me.txtPayment.Text = Format(.Payment, "0.00")
                Me.ComboStatus.SelectedItem = .Status
            End With
        End If
    End Sub
    Private Sub FindDeduction(ByVal ded As cPrMsDeductionCodes)
        Dim i As Integer
        For i = 0 To Me.ComboDedCode.Items.Count - 1
            If CType(Me.ComboDedCode.Items(i), cPrMsDeductionCodes).Code = ded.Code Then
                Me.ComboDedCode.SelectedIndex = i
                Exit For
            End If
        Next
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
    Private Sub FillDG1(ByVal EmpLoanCode As String)
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrTxEmployeeLoansByEmpCode(EmpCode, EmpLoanCode)
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        Me.LoadDataFromDG1(0)
        LoadRemainingAmount(EmpLoanCode)
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
        If Me.txtId.Text = 0 Then
            MsgBox("Please select Valid Loan transaction first", MsgBoxStyle.Critical)
            Me.TSBDelete.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Me.ComboStatus.SelectedItem.ToString = Global1.AN_CLOSED Then
            MsgBox("Loan Status is Closed, cannot delete Transaction", MsgBoxStyle.Critical)
            Me.TSBDelete.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        tPrTxEmployeeLoan = New cPrTxEmployeeLoan(Me.txtId.Text)
        If tPrTxEmployeeLoan.Id > 0 Then
            If tPrTxEmployeeLoan.TrxHdr_Id <> 0 Then
                Dim TrxHdr As New cPrTxTrxnHeader(tPrTxEmployeeLoan.TrxHdr_Id)
                If TrxHdr.Id <> 0 Then
                    MsgBox("There is a Calculated Pyroll for this Loan Payment.Payment cannot be deleted", MsgBoxStyle.Critical)

                    PasswordforDeletion = ""
                    Dim Delete As Boolean = False
                    Dim F As New FrmPasswordForDeletion
                    F.myOwner = 2
                    F.Owner = Me
                    F.ShowDialog()

                    If PasswordForDeletion = Format(Now.Date, "ddMMyyyy") Then
                        Delete = True
                    Else
                        MsgBox("Invalid Password, cannot proceed with Deletion !", MsgBoxStyle.Critical)
                        Delete = False
                    End If

                    Me.TSBDelete.Enabled = True
                    Me.Cursor = Cursors.Default
                    If Not Delete Then
                        Exit Sub
                    End If
                End If
            End If
        End If
        If tPrTxEmployeeLoan.Type = Global1.AN_Issue Then
            If Not Global1.Business.IsThisTheFirstRecordOfLoan(EmpCode, tPrTxEmployeeLoan.LoanCode) Then
                MsgBox("This is the ISSUED record of an active Loan and it cannot be deleted", MsgBoxStyle.Critical)
                Me.TSBDelete.Enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Response = MsgBox("Are you sure you want to delete record " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrTxEmployeeLoan.Delete(CInt(Trim(Me.txtId.Text))) Then
                MsgBox("Succesfull Deletion", MsgBoxStyle.Information)
                FillDG1(Me.txtLoanCode.Text)
                Me.LoadDataFromDG1(0)
            Else
                MsgBox("No deletion took place")
            End If
        End If
        Me.TSBDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDataFromDG1(ByVal i As Integer)
        Me.ClearMe(True)
        Call ClearErrors()
        Dim Action As String

        If Me.DG1.RowCount > 0 Then

            Me.txtId.Text = DbNullToInt(DG1.Item(0, i).Value)
            txtLoanCode.Text = DbNullToString(DG1.Item(1, i).Value)
            EmpCode = DbNullToString(DG1.Item(2, i).Value)
            GlbTmpGrp.Code = DbNullToString(DG1.Item(3, i).Value)
            PeriodCode = DbNullToString(DG1.Item(4, i).Value)
            PeriodGroup = DbNullToString(DG1.Item(5, i).Value)
            Dim tDedCode As New cPrMsDeductionCodes(DbNullToString(DG1.Item(6, i).Value))
            Me.FindDeduction(tDedCode)
            'Me.ComboDedCode.SelectedItem = CType(tDedCode, cPrMsDeductionCodes)
            Me.txtHeaderId.Text = DbNullToInt(DG1.Item(7, i).Value)
            DateFrom.Value = DbNullToDate(DG1.Item(8, i).Value)
            txtAmount.Text = Format(DbNullToDouble(DG1.Item(9, i).Value), "0.00")
            Me.txtInterest.Text = Format(DbNullToDouble(DG1.Item(10, i).Value), "0.00")
            Me.txtTotalAmount.Text = Format(DbNullToDouble(DG1.Item(11, i).Value), "0.00")
            Me.txtDesc.Text = DbNullToString(DG1.Item(12, i).Value)
            Me.txtMonthlyAmount.Text = Format(DbNullToDouble(DG1.Item(13, i).Value), "0.00")
            Me.ComboAction.SelectedItem = DbNullToString(DG1.Item(14, i).Value)
            Me.txtPayment.Text = Format(DbNullToDouble(DG1.Item(15, i).Value), "0.00")
            Me.ComboStatus.SelectedItem = DbNullToString(DG1.Item(17, i).Value)


        End If


        If Me.ComboStatus.SelectedItem = "OPEN" And Me.ComboAction.SelectedItem = "ISSUE" Then
            Me.txtTotalAmount.Enabled = True
            Me.txtAmount.Enabled = True
            Me.txtInterest.Enabled = True
        Else
            Me.txtTotalAmount.Enabled = False
            Me.txtAmount.Enabled = False
            Me.txtInterest.Enabled = False
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







    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As New FrmEmployeeLoanSearch
        f.EmpCode = Me.EmpCode
        f.Owner = Me
        f.ShowDialog()
    End Sub


    Private Sub mnuNewLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewLoan.Click
        NewLoan()
    End Sub
    Private Sub NewLoan()

        Me.Cursor = Cursors.WaitCursor()
        tPrTxEmployeeLoan = New cPrTxEmployeeLoan
        Me.txtPayment.Text = 0

        Me.ClearMe(True)
        ClearErrors()
        PKInputReadOnly(False)
        Me.ComboStatus.Focus()
        Me.Cursor = Cursors.Default
        EnableControls(True)
        Me.FillDG1("")
    End Sub

    Private Sub MnuNewPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNewPayment.Click
        NewPayment()
    End Sub
    Private Sub NewPayment()
        If Me.ComboStatus.SelectedItem.ToString = Global1.AN_CLOSED Then
            MsgBox("Loan Status is Closed, cannot proceed with payment", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Me.txtId.Text = 0
        Me.txtHeaderId.Text = 0
        Me.txtAmount.Text = 0
        Me.txtInterest.Text = 0
        Me.txtTotalAmount.Text = 0
        Me.txtPayment.Text = 0

        Me.Cursor = Cursors.WaitCursor()
        tPrTxEmployeeLoan = New cPrTxEmployeeLoan
        ClearMe(False)
        ClearErrors()
        PKInputReadOnly(False)

        Me.ComboStatus.Focus()
        Me.Cursor = Cursors.Default
        EnableControls(False)
    End Sub
    Private Sub EnableControls(ByVal TF As Boolean)

        txtLoanCode.Enabled = TF
        ComboDedCode.Enabled = TF
        DateFrom.Enabled = TF
        txtAmount.Enabled = TF
        Me.txtInterest.Enabled = TF
        Me.txtTotalAmount.Enabled = TF
        Me.txtDesc.Enabled = TF
        Me.txtMonthlyAmount.Enabled = TF
        Me.ComboAction.Enabled = False
        If Not TF Then
            Me.ComboAction.SelectedIndex = 1
        Else
            Me.ComboAction.SelectedIndex = 0
        End If
        Me.txtPayment.Enabled = Not TF
        Me.ComboStatus.Enabled = TF

        If Me.ComboStatus.SelectedItem = "OPEN" And Me.ComboAction.SelectedItem = "ISSUE" Then
            Me.txtTotalAmount.Enabled = True
            Me.txtAmount.Enabled = True
            Me.txtInterest.Enabled = True
        End If
    End Sub

    Private Sub btnSetAsClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAsClosed.Click
        Dim Proceed As Boolean = True
        If Me.txtRemAmount.Text <> "0.00" Then
            Proceed = False
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Remaining amount is not zero, proceed?", MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                Proceed = True
            End If

        End If
        If Proceed Then
            Global1.Business.ChangeStatusofLoan(EmpCode, Me.txtLoanCode.Text)
            MsgBox("Status is Changed to Closed", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub NewLoanEventToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewLoanEventToolStripMenuItem.Click
        If Me.txtId.Text <> "" And Me.txtId.Text <> "0" Then
            Dim F As New FrmPrTxLoanComments
            F.LoanId = Me.txtId.Text
            F.MyEmp = Me.Employee
            F.ShowDialog()
        Else
            MsgBox("For this action Please select a Valid Loan First !", MsgBoxStyle.Information)
        End If

    End Sub
   
   
End Class
