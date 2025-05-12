Public Class frmPrTxEmployeeDiscounts
    Public EmpCode As String
    Public EmpName As String
    Public TempGrpCode As String
    Dim tPrTxEmployeeDiscounts As New cPrTxEmployeeDiscounts
    Dim DG1Changing As Boolean = False
    Private Sub frmPrTxEmployeeDiscounts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe()
    End Sub
    Public Sub LoadMe()
        Me.txtEmployeeCode.Text = EmpCode
        Me.txtEmployeeName.Text = EmpName

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        CheckPermitions()
        SetDiscountLabels()
    End Sub
    Private Sub SetDiscountLabels()
        Me.lblDiscount1.Text = Global1.Param_DiscountLabel1
        Me.lblDiscount2.Text = Global1.Param_DiscountLabel2
        Me.lblDiscount3.Text = Global1.Param_DiscountLabel3
        Me.lblDiscount4.Text = Global1.Param_DiscountLabel4
        Me.lblDiscount5.Text = Global1.Param_DiscountLabel5
        Me.lblDiscount6.Text = Global1.Param_DiscountLabel6
        Me.lblDiscount7.Text = Global1.Param_DiscountLabel7
        Me.lblDiscount8.Text = Global1.Param_DiscountLabel8
        Me.lblDiscount9.Text = Global1.Param_DiscountLabel9
        Me.lblDiscount10.Text = Global1.Param_DiscountLabel10

    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Discounts")
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

       
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"

        Me.txtDiscount1.Text = "0.00"
        Me.txtDiscount2.Text = "0.00"
        Me.txtDiscount3.Text = "0.00"
        Me.txtDiscount4.Text = "0.00"
        Me.txtDiscount5.Text = "0.00"
        Me.txtDiscount6.Text = "0.00"
        Me.txtDiscount7.Text = "0.00"
        Me.txtDiscount8.Text = "0.00"
        Me.txtDiscount9.Text = "0.00"
        Me.txtDiscount10.Text = "0.00"
        Me.txtLifeInsurance.Text = "0.00"
        Me.txtMedical.Text = "0.00"
        Me.txtPensionfund.Text = "0.00"
        Try
            Me.cmbUsr_Id.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtCreationDate.Text = ""
        Me.txtAmendDate.Text = ""
    End Sub
    '
    Private Sub LoadCombos()
        LoadPrMsPeriodGroups()
        LoadAaSsUsers()
    End Sub
    '
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
                    If tPrMsPeriodGroups.TemGrpCode = TempGrpCode Then
                        .Items.Add(tPrMsPeriodGroups)
                    End If
                Next i
                .ValueMember = "PrdGrp_Code"
                .SelectedIndex = 0
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
            With Me.cmbUsr_Id
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
        AddHandler txtDiscount1.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount1.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount2.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount2.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount3.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount3.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount4.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount4.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount5.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount5.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount6.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount6.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount7.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount7.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount8.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount8.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount9.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount9.Leave, AddressOf NumericOnLeave
        AddHandler txtDiscount10.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDiscount10.Leave, AddressOf NumericOnLeave
        AddHandler txtLifeInsurance.KeyPress, AddressOf NumericKeyPress
        AddHandler txtLifeInsurance.Leave, AddressOf NumericOnLeave
        AddHandler txtMedical.KeyPress, AddressOf NumericKeyPress
        AddHandler txtMedical.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrId.SetError(Me.txtId, "")
        Me.ErrPrdGrp_Code.SetError(Me.cmbPrdGrp_Code, "")
        Me.ErrDiscount1.SetError(Me.txtDiscount1, "")
        Me.ErrDiscount2.SetError(Me.txtDiscount2, "")
        Me.ErrDiscount3.SetError(Me.txtDiscount3, "")
        Me.ErrDiscount4.SetError(Me.txtDiscount4, "")
        Me.ErrDiscount5.SetError(Me.txtDiscount5, "")
        Me.ErrDiscount6.SetError(Me.txtDiscount6, "")
        Me.ErrDiscount7.SetError(Me.txtDiscount7, "")
        Me.ErrDiscount8.SetError(Me.txtDiscount8, "")
        Me.ErrDiscount9.SetError(Me.txtDiscount9, "")
        Me.ErrDiscount10.SetError(Me.txtDiscount10, "")
        Me.ErrLifeInsurance.SetError(Me.txtLifeInsurance, "")
        Me.ErrUsr_Id.SetError(Me.cmbUsr_Id, "")
        Me.ErrCreationDate.SetError(Me.txtCreationDate, "")
        Me.ErrAmendDate.SetError(Me.txtAmendDate, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrTxEmployeeDiscounts = New cPrTxEmployeeDiscounts
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.cmbPrdGrp_Code.Focus()
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
            ' Dim CS As Integer
            Try
                Dim PeriodGroupCode As String
                PeriodGroupCode = CType(Me.cmbPrdGrp_Code.SelectedItem, cPrMsPeriodGroups).Code
                tPrTxEmployeeDiscounts = New cPrTxEmployeeDiscounts(EmpCode, PeriodGroupCode)
                With tprtxemployeediscounts
                    .Emp_Code = EmpCode
                    .PrdGrp_Code = CType(Me.cmbPrdGrp_Code.SelectedItem, cPrMsPeriodGroups).Code
                    .Discount1 = CDbl(Me.txtDiscount1.Text)
                    .Discount2 = CDbl(Me.txtDiscount2.Text)
                    .Discount3 = CDbl(Me.txtDiscount3.Text)
                    .Discount4 = CDbl(Me.txtDiscount4.Text)
                    .Discount5 = CDbl(Me.txtDiscount5.Text)
                    .Discount6 = CDbl(Me.txtDiscount6.Text)
                    .Discount7 = CDbl(Me.txtDiscount7.Text)
                    .Discount8 = CDbl(Me.txtDiscount8.Text)
                    .Discount9 = CDbl(Me.txtDiscount9.Text)
                    .Discount10 = CDbl(Me.txtDiscount10.Text)
                    .LifeInsurance = CDbl(Me.txtLifeInsurance.Text)
                    .Medical = CDbl(Me.txtMedical.Text)
                    .PensionFund = CDbl(Me.txtpensionfund.Text)
                    .Usr_Id = CType(Me.cmbUsr_Id.SelectedItem, cAaSsUsers).Id
                    If .Id = 0 Then
                        .CreationDate = Now.Date
                    End If
                    .AmendDate = Now.Date
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        FillDG1()
                        'If DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
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
        'ds = Global1.Business.AG_GetAllPrTxEmployeeDiscounts()
        Dim PrdGrpCode As String
        PrdGrpCode = CType(Me.cmbPrdGrp_Code.SelectedItem, cPrMsPeriodGroups).Code
        ds = Global1.Business.GetAllPrTxEmployeeDiscounts(PrdGrpCode, EmpCode)
        HeaderStr.Add("id")
        HeaderStr.Add("Employee Code")
        HeaderStr.Add("Period Group Code")
        HeaderStr.Add("Discount 1")
        HeaderStr.Add("Discount 2")
        HeaderStr.Add("Discount 3")
        HeaderStr.Add("Discount 4")
        HeaderStr.Add("Discount 5")
        HeaderStr.Add("Discount 6")
        HeaderStr.Add("Discount 7")
        HeaderStr.Add("Discount 8")
        HeaderStr.Add("Discount 9")
        HeaderStr.Add("Discount 10")
        HeaderStr.Add("Life Insurance")
        HeaderStr.Add("Medical")
        HeaderStr.Add("User Id")
        HeaderStr.Add("Creation Date")
        HeaderStr.Add("Amend Date")
        HeaderSize.Add(15)
        HeaderSize.Add(16)
        HeaderSize.Add(4)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrTxEmployeeDiscounts(ByVal tId As Integer)
        tPrTxEmployeeDiscounts = New cPrTxEmployeeDiscounts(tId)
        If tPrTxEmployeeDiscounts.Id <> 0 Then
            With tPrTxEmployeeDiscounts
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                ' Need to decide what to do with a combo in the load sub Property = Emp_Code
                ' Need to decide what to do with a combo in the load sub Property = PrdGrp_Code
                Me.txtDiscount1.Text = Format(.Discount1, "0.00")
                Me.txtDiscount2.Text = Format(.Discount2, "0.00")
                Me.txtDiscount3.Text = Format(.Discount3, "0.00")
                Me.txtDiscount4.Text = Format(.Discount4, "0.00")
                Me.txtDiscount5.Text = Format(.Discount5, "0.00")
                Me.txtDiscount6.Text = Format(.Discount6, "0.00")
                Me.txtDiscount7.Text = Format(.Discount7, "0.00")
                Me.txtDiscount8.Text = Format(.Discount8, "0.00")
                Me.txtDiscount9.Text = Format(.Discount9, "0.00")
                Me.txtDiscount10.Text = Format(.Discount10, "0.00")
                Me.txtLifeInsurance.Text = Format(.LifeInsurance, "0.00")
                Me.txtMedical.Text = Format(.Medical, "0.00")
                Me.txtpensionfund.Text = Format(.PensionFund, "0.00")
                ' Need to decide what to do with a combo in the load sub Property = Usr_Id
                Me.txtCreationDate.Text = CStr(.CreationDate)
                Me.txtAmendDate.Text = CStr(.AmendDate)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        Dim PrdGrpCode As String
        PrdGrpCode = CType(Me.cmbPrdGrp_Code.SelectedItem, cPrMsPeriodGroups).Code
        ds = Global1.Business.GetAllPrTxEmployeeDiscounts(PrdGrpCode, EmpCode)
        DG1Changing = True
        Me.ClearErrors()
        Me.ClearMe()
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
    End Sub
    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged

        Try
            Dim i As Integer
            i = DG1.CurrentRow.Index
            LoadDataFromDG1(i)
        Catch ex As Exception
        End Try

    End Sub
    Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
        Me.TSBDelete.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Dim Response As Integer
        Response = MsgBox("Are you sure you want to delete " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrTxEmployeeDiscounts.Delete(CInt(Trim(Me.txtId.Text))) Then
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
        Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
        Me.txtDiscount1.Text = DbNullToString(DG1.Item(3, i).Value)
        Me.txtDiscount2.Text = DbNullToString(DG1.Item(4, i).Value)
        Me.txtDiscount3.Text = DbNullToString(DG1.Item(5, i).Value)
        Me.txtDiscount4.Text = DbNullToString(DG1.Item(6, i).Value)
        Me.txtDiscount5.Text = DbNullToString(DG1.Item(7, i).Value)
        Me.txtDiscount6.Text = DbNullToString(DG1.Item(8, i).Value)
        Me.txtDiscount7.Text = DbNullToString(DG1.Item(9, i).Value)
        Me.txtDiscount8.Text = DbNullToString(DG1.Item(10, i).Value)
        Me.txtDiscount9.Text = DbNullToString(DG1.Item(11, i).Value)
        Me.txtDiscount10.Text = DbNullToString(DG1.Item(12, i).Value)
        Me.txtLifeInsurance.Text = DbNullToString(DG1.Item(13, i).Value)
        Dim Usr As New cAaSsUsers(DbNullToInt(DG1.Item(14, i).Value))
        Me.cmbUsr_Id.SelectedIndex = cmbUsr_Id.FindStringExact(Usr.ToString)
        Me.txtCreationDate.Text = DbNullToString(DG1.Item(15, i).Value)
        Me.txtAmendDate.Text = DbNullToString(DG1.Item(16, i).Value)
        Me.txtMedical.Text = DbNullToString(DG1.Item(17, i).Value)
        Me.txtpensionfund.Text = DbNullToString(DG1.Item(18, i).Value)
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub

    Private Sub cmbPrdGrp_Code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrdGrp_Code.SelectedIndexChanged
        Me.FillDG1()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        Dim Emp As New cPrMsEmployees(EmpCode)
        Dim GLBCurrentPeriod As New cPrMsPeriodCodes
        ds = Global1.Business.FindCurrentPeriod1(Emp.TemGrp_Code)

        If CheckDataSet(ds) Then
            Dim Salary As New cPrTxEmployeeSalary
            GLBCurrentPeriod = New cPrMsPeriodCodes(ds.Tables(0).Rows(0))
            Salary = Global1.Business.GetCurrentSalary(EmpCode, GLBCurrentPeriod.DateTo)
            Dim FE As Double = 0
            '''
            Dim ds2 As DataSet
            ds2 = Global1.Business.GetFirstTransactionPeriod(Emp.Code, GLBCurrentPeriod.PrdGrpCode)
            Dim Sequence As Integer = (GLBCurrentPeriod.Sequence - 1)
            If CheckDataSet(ds2) Then
                Dim PerCode As String
                PerCode = DbNullToString(ds2.Tables(0).Rows(0).Item(0))
                Dim Per As New cPrMsPeriodCodes(PerCode, GLBCurrentPeriod.PrdGrpCode)
                Sequence = Per.Sequence - 1
            End If

            Dim RemPeriods As Integer = GLBCurrentPeriod.NumberOfTotalPeriods - Sequence
            '''
            FE = Salary.SalaryValue * RemPeriods
            If FE >= Global1.PARAM_FiftyPercAplicableAmount Then
                FE = FE / 2
            Else
                FE = FE * 20 / 100
                If FE >= 8550 Then
                    FE = 8550
                End If
            End If
            Dim FD As Double
          
            FD = RoundMe3(FE / RemPeriods, 2)
            FD = RoundMe3(FD * GLBCurrentPeriod.NumberOfTotalPeriods, 2)
            Me.txtDiscount10.Text = FD
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Exx As New System.Exception
        Try

            Dim FromCode As String
            Dim FromPeriodGroup As String
            FromCode = Me.txtCopyFrom.Text
            FromPeriodGroup = Me.txtCopyPeriodGroup.Text

            Dim PeriodGroupCode As String
            PeriodGroupCode = CType(Me.cmbPrdGrp_Code.SelectedItem, cPrMsPeriodGroups).Code

            Dim Ds As DataSet
            Dim tEmp As New cPrMsEmployees(FromCode)
            If tEmp.Code <> "" Then
                Global1.Business.BeginTransaction()
                Ds = Global1.Business.GetAllPrTxEmployeeDiscounts(FromPeriodGroup, FromCode)
                If CheckDataSet(Ds) Then
                    Dim i As Integer
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        Dim Dis As New cPrTxEmployeeDiscounts(Ds.Tables(0).Rows(i))
                        Dis.Id = 0
                        Dis.Emp_Code = EmpCode
                        Dis.PrdGrp_Code = PeriodGroupCode
                        If Not Dis.Save() Then
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

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        CType(Me.Owner, frmPrMsEmployees).NextEmployee_OnDiscounts(Me)

    End Sub

    Private Sub BtnPrevius_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevius.Click
        CType(Me.Owner, frmPrMsEmployees).PreviousEmployee_OnDiscounts(Me)
    End Sub
End Class
