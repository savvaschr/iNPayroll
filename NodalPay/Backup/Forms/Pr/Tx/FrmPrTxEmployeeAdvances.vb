Public Class FrmPrTxEmployeeAdvances
    Public EmpCode As String
    Public Employee As cPrMsEmployees
    Dim tPrTxEmployeeAdvances As New cPrTxEmployeeAdvances
    Dim DG1Changing As Boolean = False
    Dim COLAPercentage As Double = 0
    Private Sub frmPrTxEmployeeAdvances_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
        CheckPermitions()
    End Sub
    Private Sub CheckPermitions()
        Dim P As New cPrSsUserPermitions("", Global1.GLBUserCode, "Advances")
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

        Me.Date1.Value = Now.Date
        Me.txtAmount.Text = "0.00"
        Try
            Me.comboUser.SelectedIndex = 0
        Catch ex As Exception
        End Try

    End Sub
    '
    Private Sub LoadCombos()
        LoadAaSsUsers()
        
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
        AddHandler txtAmount.KeyPress, AddressOf Utils.NumericKeyPressWithNegative
        AddHandler txtAmount.Leave, AddressOf Utils.NumericOnLeaveWithNegative
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
        tPrTxEmployeeAdvances = New cPrTxEmployeeAdvances
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.Date1.Focus()
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
                With tPrTxEmployeeAdvances
                    .Id = NullToInt(Me.txtId.Text)
                    .EmpCode = EmpCode
                    .Amount = Me.txtAmount.Text
                    .MyDate = Me.Date1.Value
                    .User = CType(Me.comboUser.SelectedItem, cAaSsUsers).Id
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
    '
    Private Sub LoadDataSetToExcel()
        Dim ds As DataSet
        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader

        ds = Global1.Business.GetAllPrTxEmployeeAdvancesByEmpCode(EmpCode)
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
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrTxEmployeeSalary(ByVal tId As Integer)
        tPrTxEmployeeadvances = New cPrTxEmployeeAdvances(tId)
        If tPrTxEmployeeAdvances.Id <> 0 Then
            With tPrTxEmployeeAdvances
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.Date1.Value = CDate(.MyDate)
                Me.txtAmount.Text = Format(.Amount, "0.00")
                
                Dim User As New cAaSsUsers(.User)
                Me.comboUser.SelectedIndex = Me.comboUser.FindStringExact(User.ToString)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrTxEmployeeAdvancesByEmpCode(EmpCode)
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        If CheckDataSet(ds) Then
            Dim total As Double = 0
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                total = RoundMe2(total + DbNullToDouble(ds.Tables(0).Rows(i).Item(2)), 2)
                'total = total + DbNullToDouble(ds.Tables(0).Rows(i).Item(2))
            Next
            'Me.txtTotal.Text = RoundMe2(total, 2)
            Me.txtTotal.Text = Format(total, "0.00")
        End If
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
            If tPrTxEmployeeAdvances.Delete(CInt(Trim(Me.txtId.Text))) Then
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
            Me.txtAmount.Text = Format(DbNullToDouble(DG1.Item(2, i).Value), "0.00")
            Dim User As New cAaSsUsers(DbNullToString(DG1.Item(3, i).Value))
            Me.Date1.Value = CDate(DbNullToString(DG1.Item(4, i).Value))
            Me.comboUser.SelectedIndex = Me.comboUser.FindStringExact(User.ToString)
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

  
End Class