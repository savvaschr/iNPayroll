Public Class frmPrTxEmployeeHiring
    Dim tPrTxEmployeeHiring As New cPrTxEmployeeHiring
    Dim DG1Changing As Boolean = False
    Private Sub frmPrTxEmployeeHiring_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
    End Sub
    Private Sub Initialize()
        LoadCombos()
        ClearMe()
        PutDecimalValidationOnTxts()
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
        If Me.txtCode.Text = "" Then
            Flag = False
            Me.ErrCode.SetError(Me.txtCode, "Field is Required")
        End If
        If Me.cmbUsr_Id.Text = "" Then
            Flag = False
            Me.ErrUsr_Id.SetError(Me.cmbUsr_Id, "Field is Required")
        Else
            If Not IsNumeric(Me.cmbUsr_Id.Text) Then
                Flag = False
                Me.ErrUsr_Id.SetError(Me.cmbUsr_Id, "Field requires a number")
            Else
                If NullToInt(Me.cmbUsr_Id.Text) < 0 Then
                    Flag = False
                    Me.ErrUsr_Id.SetError(Me.cmbUsr_Id, "Field requires positive number")
                End If
            End If
        End If
        If Flag Then
            If Me.txtId.Text <> "" Then
                If Not Me.txtId.ReadOnly Then
                    Dim tPrTxEmployeeHiring As New cPrTxEmployeeHiring(CInt(Trim(Me.txtId.Text)))
                    If tPrTxEmployeeHiring.Id <> 0 Then
                        MsgBox("Item already exists - Can not be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.txtCode.Text = ""
        Me.txtHiringDate.Text = ""
        Me.txtStartDate.Text = ""
        Me.txtStartSalary.Text = "0.00"
        Me.txtPFStartDate.Text = ""
        Try
            Me.cmbUsr_Id.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    '
    Private Sub LoadCombos()
        LoadAaSsUsers()
    End Sub
    '
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
        AddHandler txtStartSalary.KeyPress, AddressOf NumericKeyPress
        AddHandler txtStartSalary.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrId.SetError(Me.txtId, "")
        Me.ErrCode.SetError(Me.txtCode, "")
        Me.ErrHiringDate.SetError(Me.txtHiringDate, "")
        Me.ErrStartDate.SetError(Me.txtStartDate, "")
        Me.ErrStartSalary.SetError(Me.txtStartSalary, "")
        Me.ErrPFStartDate.SetError(Me.txtPFStartDate, "")
        Me.ErrUsr_Id.SetError(Me.cmbUsr_Id, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrTxEmployeeHiring = New cPrTxEmployeeHiring
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
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
            Dim CS As Integer
            Try
                '  If Me.txtId.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrTxEmployeeHiring
                    .Id = NullToInt(Me.txtId.Text)
                    .Code = CStr(Me.txtCode.Text)
                    .HiringDate = CDate(Me.txtHiringDate.Text)
                    .StartDate = CDate(Me.txtStartDate.Text)
                    .StartSalary = CDbl(Me.txtStartSalary.Text)
                    .PFStartDate = CDate(Me.txtPFStartDate.Text)
                    .Usr_Id = CType(Me.cmbUsr_Id.SelectedItem, cAaSsUsers).Id
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        If DG1.Rows.Count - 1 > 0 Then
                            CS = Me.DG1.SelectedRows(0).Index
                        End If
                        FillDG1()
                        If DG1.Rows.Count - 1 > CS Then
                            DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        Else
                            DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        End If
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
        ds = Global1.Business.AG_GetAllPrTxEmployeeHiring()
        HeaderStr.Add("id")
        HeaderStr.Add("Code")
        HeaderStr.Add("Hiring Date")
        HeaderStr.Add("Start Date")
        HeaderStr.Add("Start Salary")
        HeaderStr.Add("PF Start Date")
        HeaderStr.Add("User Id")
        HeaderSize.Add(15)
        HeaderSize.Add(16)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrTxEmployeeHiring(ByVal tId As Integer)
        tPrTxEmployeeHiring = New cPrTxEmployeeHiring(tId)
        If tPrTxEmployeeHiring.Id <> 0 Then
            With tPrTxEmployeeHiring
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.txtCode.Text = CStr(.Code)
                Me.txtHiringDate.Text = CStr(.HiringDate)
                Me.txtStartDate.Text = CStr(.StartDate)
                Me.txtStartSalary.Text = Format(.StartSalary, "0.00")
                Me.txtPFStartDate.Text = CStr(.PFStartDate)
                ' Need to decide what to do with a combo in the load sub Property = Usr_Id
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrTxEmployeeHiring()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrTxEmployeeHiring.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
                FillDG1()
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
        Me.txtCode.Text = DbNullToString(DG1.Item(1, i).Value)
        Me.txtHiringDate.Text = DbNullToString(DG1.Item(2, i).Value)
        Me.txtStartDate.Text = DbNullToString(DG1.Item(3, i).Value)
        Me.txtStartSalary.Text = DbNullToString(DG1.Item(4, i).Value)
        Me.txtPFStartDate.Text = DbNullToString(DG1.Item(5, i).Value)
        Me.cmbUsr_Id.SelectedIndex = cmbUsr_Id.FindStringExact(Trim(CStr(DG1.Item(6, i).Value)))
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
    End Sub
End Class
