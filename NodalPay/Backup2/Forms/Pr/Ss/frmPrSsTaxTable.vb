Public Class frmPrSsTaxTable
    Dim tPrSsTaxTable As New cPrSsTaxTable
    Dim DG1Changing As Boolean = False
    Private Sub frmPrSsTaxTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtTaxTbl_id.Text = "" Then
            Flag = False
            Me.ErrTaxTbl_id.SetError(Me.txtTaxTbl_id, "Field is Required")
        Else
            If Not IsNumeric(Me.txtTaxTbl_id.Text) Then
                Flag = False
                Me.ErrTaxTbl_id.SetError(Me.txtTaxTbl_id, "Field requires a number")
            Else
                If NullToInt(Me.txtTaxTbl_id.Text) < 0 Then
                    Flag = False
                    Me.ErrTaxTbl_id.SetError(Me.txtTaxTbl_id, "Field requires positive number")
                End If
            End If
        End If
        If Me.txtTaxTbl_Sequence.Text = "" Then
            Flag = False
            Me.ErrTaxTbl_Sequence.SetError(Me.txtTaxTbl_Sequence, "Field is Required")
        Else
            If Not IsNumeric(Me.txtTaxTbl_Sequence.Text) Then
                Flag = False
                Me.ErrTaxTbl_Sequence.SetError(Me.txtTaxTbl_Sequence, "Field requires a number")
            Else
                If NullToInt(Me.txtTaxTbl_Sequence.Text) < 0 Then
                    Flag = False
                    Me.ErrTaxTbl_Sequence.SetError(Me.txtTaxTbl_Sequence, "Field requires positive number")
                End If
            End If
        End If
        If Me.cmbTaxTbl_CreatedBy.Text = "" Then
            Flag = False
            Me.ErrTaxTbl_CreatedBy.SetError(Me.cmbTaxTbl_CreatedBy, "Field is Required")
        End If
        If Me.cmbTaxTbl_AmendBy.Text = "" Then
            Flag = False
            Me.ErrTaxTbl_AmendBy.SetError(Me.cmbTaxTbl_AmendBy, "Field is Required")
        End If
        'If Flag Then
        '    If Me.txtTaxTbl_id.Text <> "" Then
        '        If Not Me.txtTaxTbl_id.ReadOnly Then
        '            Dim tPrSsTaxTable As New cPrSsTaxTable(CInt(Trim(Me.txtTaxTbl_id.Text)))
        '            If tPrSsTaxTable.TaxTbl_id <> 0 Then
        '                MsgBox("Item already exists - Can not be inserted", MsgBoxStyle.Critical)
        '                Flag = False
        '            End If
        '        End If
        '    End If
        'End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtTaxTbl_id.Text = "0"
        Me.txtTaxTbl_Sequence.Text = "0"
        Me.txtTaxTbl_BracketAmount.Text = "0.00"
        Me.txtTaxTbl_BracketRate.Text = "0.00"
        Me.DateCreated.Value = Now.Date
        Try
            Me.cmbTaxTbl_CreatedBy.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.DateAmend.Value = Now.Date
        Try
            Me.cmbTaxTbl_AmendBy.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    '
    Private Sub LoadCombos()
        LoadAaSsUsers_TaxTbl_CreatedBy()
        LoadAaSsUsers_TaxTbl_AmendBy()
    End Sub
    '
    Private Sub LoadAaSsUsers_TaxTbl_CreatedBy()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAaSsUsers()
        If CheckDataSet(ds) Then
            Dim tAaSsUsers As New cAaSsUsers
            With Me.cmbTaxTbl_CreatedBy
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
    Private Sub LoadAaSsUsers_TaxTbl_AmendBy()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAaSsUsers()
        If CheckDataSet(ds) Then
            Dim tAaSsUsers As New cAaSsUsers
            With Me.cmbTaxTbl_AmendBy
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
        AddHandler txtTaxTbl_BracketAmount.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTaxTbl_BracketAmount.Leave, AddressOf NumericOnLeave
        AddHandler txtTaxTbl_BracketRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtTaxTbl_BracketRate.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrTaxTbl_id.SetError(Me.txtTaxTbl_id, "")
        Me.ErrTaxTbl_Sequence.SetError(Me.txtTaxTbl_Sequence, "")
        Me.ErrTaxTbl_BracketAmount.SetError(Me.txtTaxTbl_BracketAmount, "")
        Me.ErrTaxTbl_BracketRate.SetError(Me.txtTaxTbl_BracketRate, "")
        'Me.ErrTaxTbl_CreationDate.SetError(Me.txtTaxTbl_CreationDate, "")
        Me.ErrTaxTbl_CreatedBy.SetError(Me.cmbTaxTbl_CreatedBy, "")
        'Me.ErrTaxTbl_AmendDate.SetError(Me.txtTaxTbl_AmendDate, "")
        Me.ErrTaxTbl_AmendBy.SetError(Me.cmbTaxTbl_AmendBy, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrSsTaxTable = New cPrSsTaxTable
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtTaxTbl_id.Focus()
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
            'Dim CS As Integer
            Try
                '  If Me.txtTaxTbl_id.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrSsTaxTable
                    .TaxTbl_id = NullToInt(Me.txtTaxTbl_id.Text)
                    .TaxTbl_Sequence = NullToInt(Me.txtTaxTbl_Sequence.Text)
                    .TaxTbl_BracketAmount = CDbl(Me.txtTaxTbl_BracketAmount.Text)
                    .TaxTbl_BracketRate = CDbl(Me.txtTaxTbl_BracketRate.Text)
                    .TaxTbl_CreationDate = Me.DateCreated.Value.Date
                    .TaxTbl_CreatedBy = CType(Me.cmbTaxTbl_CreatedBy.SelectedItem, cAaSsUsers).Id
                    .TaxTbl_AmendDate = Me.DateAmend.Value.Date
                    .TaxTbl_AmendBy = CType(Me.cmbTaxTbl_AmendBy.SelectedItem, cAaSsUsers).Id
                    If .Save() Then
                        MsgBox("Changes are successfully Saved", MsgBoxStyle.Information)
                        'If DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
                        FindWhereToSelect(.TaxTbl_id)
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
        ds = Global1.Business.AG_GetAllPrSsTaxTable()
        HeaderStr.Add("id")
        HeaderStr.Add("Sequence")
        HeaderStr.Add("BracketAmount")
        HeaderStr.Add("BracketRate")
        HeaderStr.Add("CreationDate")
        HeaderStr.Add("CreatedBy")
        HeaderStr.Add("AmendDate")
        HeaderStr.Add("AmendBy")
        HeaderSize.Add(15)
        HeaderSize.Add(15)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrSsTaxTable(ByVal tTaxTbl_id As Integer)
        tPrSsTaxTable = New cPrSsTaxTable(tTaxTbl_id)
        If tPrSsTaxTable.TaxTbl_id <> 0 Then
            With tPrSsTaxTable
                Me.txtTaxTbl_id.ReadOnly = True
                Me.txtTaxTbl_id.BackColor = SystemColors.Info
                Me.txtTaxTbl_id.Text = CStr(.TaxTbl_id)
                Me.txtTaxTbl_Sequence.Text = CStr(.TaxTbl_Sequence)
                Me.txtTaxTbl_BracketAmount.Text = Format(.TaxTbl_BracketAmount, "0.00")
                Me.txtTaxTbl_BracketRate.Text = Format(.TaxTbl_BracketRate, "0.00")
                Me.DateCreated.Value = CDate(.TaxTbl_CreationDate)
                ' Need to decide what to do with a combo in the load sub Property = TaxTbl_CreatedBy
                Me.DateAmend.Value = CDate(.TaxTbl_AmendDate)
                ' Need to decide what to do with a combo in the load sub Property = TaxTbl_AmendBy
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrSsTaxTable()
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        'LoadDataFromDG1(0)
        
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtTaxTbl_id.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrSsTaxTable.Delete(CInt(Trim(Me.txtTaxTbl_id.Text))) Then
                Me.lblSSStatus.Text = Me.txtTaxTbl_id.Text & " has been deleted"
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
            Me.txtTaxTbl_id.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtTaxTbl_Sequence.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtTaxTbl_BracketAmount.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.txtTaxTbl_BracketRate.Text = DbNullToString(DG1.Item(3, i).Value)
            Me.DateCreated.Value = DbNullToDate(DG1.Item(4, i).Value)
            Dim U1 As New cUsers(DbNullToInt(DG1.Item(5, i).Value))
            Me.cmbTaxTbl_CreatedBy.SelectedIndex = cmbTaxTbl_CreatedBy.FindStringExact(U1.ToString)
            Me.DateAmend.Value = DbNullToDate(DG1.Item(6, i).Value)
            Dim U2 As New cUsers(DbNullToInt(DG1.Item(7, i).Value))
            Me.cmbTaxTbl_AmendBy.SelectedIndex = cmbTaxTbl_AmendBy.FindStringExact(U2.ToString)
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        ' Me.txtTaxTbl_id.ReadOnly = RO
    End Sub

    Private Sub FindWhereToSelect(ByVal MapColumn As String)
        Dim i As Integer
        UnsellectAll()

        For i = 0 To Me.DG1.RowCount - 1
            If DbNullToString(DG1.Item(0, i).Value) = MapColumn Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(0)
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
