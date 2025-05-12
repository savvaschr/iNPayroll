Public Class frmAdMsCurrencyRates
    Dim tAdMsCurrencyRates As New cAdMsCurrencyRates
    Dim DG1Changing As Boolean = False
    Private Sub frmAdMsCurrencyRates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Me.txtCreatedBy.ReadOnly = True
        Me.txtAmendBy.ReadOnly = True
    End Sub
    Private Function ValidateMe() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        If Me.txtCurRte_id.Text = "" Then
            Flag = False
            Me.ErrCurRte_id.SetError(Me.txtCurRte_id, "Field is Required")
        Else
            If Not IsNumeric(Me.txtCurRte_id.Text) Then
                Flag = False
                Me.ErrCurRte_id.SetError(Me.txtCurRte_id, "Field requires a number")
            Else
                If NullToInt(Me.txtCurRte_id.Text) < 0 Then
                    Flag = False
                    Me.ErrCurRte_id.SetError(Me.txtCurRte_id, "Field requires positive number")
                End If
            End If
        End If
        If Flag Then
            If Me.txtCurRte_id.Text <> "" Then
                If Not Me.txtCurRte_id.ReadOnly Then
                    Dim tAdMsCurrencyRates As New cAdMsCurrencyRates(CInt(Trim(Me.txtCurRte_id.Text)))
                    If tAdMsCurrencyRates.CurRte_id <> 0 Then
                        If tAdMsCurrencyRates.EffectiveDate = Me.DateEffective.Value.Date Then
                            MsgBox("Currency Rate already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                            Flag = False
                        End If
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtCurRte_id.Text = "0"
        Try
            Me.cmbAlphaCode.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtRate.Text = "0.00"
        Me.DateEffective.Value = Now.Date
        Me.txtCreatedBy.Text = Global1.FullName
        Me.DateCreated.Value = Now.Date
        Me.txtAmendBy.Text = Global1.FullName
        Me.DateAmend.Value = Now.Date
    End Sub
    '
    Private Sub LoadCombos()
        LoadAdMsCurrency()
    End Sub
    '
    Private Sub LoadAdMsCurrency()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllAdMsCurrency()
        If CheckDataSet(ds) Then
            Dim tAdMsCurrency As New cAdMsCurrency
            With Me.cmbAlphaCode
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tAdMsCurrency = New cAdMsCurrency(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tAdMsCurrency)
                Next i
                .ValueMember = "Cur_AlphaCode"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtRate.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCurRte_id.SetError(Me.txtCurRte_id, "")
        Me.ErrAlphaCode.SetError(Me.cmbAlphaCode, "")
        Me.ErrRate.SetError(Me.txtRate, "")
        Me.ErrEffectiveDate.SetError(Me.DateEffective, "")
        Me.ErrCreatedBy.SetError(Me.txtCreatedBy, "")
        'Me.ErrCreationDate.SetError(Me.txtCreationDate, "")
        Me.ErrAmendBy.SetError(Me.txtAmendBy, "")
        'Me.ErrAmendDate.SetError(Me.txtAmendDate, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tAdMsCurrencyRates = New cAdMsCurrencyRates
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtCurRte_id.Focus()
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
                '  If Me.txtCurRte_id.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tAdMsCurrencyRates
                    .CurRte_id = NullToInt(Me.txtCurRte_id.Text)
                    .AlphaCode = CType(Me.cmbAlphaCode.SelectedItem, cAdMsCurrency).AlphaCode
                    .Rate = Me.txtRate.Text
                    If .CurRte_id <> 0 Then
                        If .EffectiveDate <> DateEffective.Value.Date Then
                            .CurRte_id = 0 'Add New Record - Not Update
                        End If
                    End If
                    .EffectiveDate = DateEffective.Value.Date
                    If Not Update Then .CreatedBy = Global1.GLBUserId
                    If Not Update Then .CreationDate = Now.Date
                    .AmendBy = Global1.GLBUserId
                    .AmendDate = Now.Date
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        'If DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
                        FindWhereToSelect(.CurRte_id)
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
        ds = Global1.Business.AG_GetAllAdMsCurrencyRates()
        HeaderStr.Add("Id")
        HeaderStr.Add("Alpha Code")
        HeaderStr.Add("Rate")
        HeaderStr.Add("Effective Date")
        HeaderStr.Add("Created By")
        HeaderStr.Add("Creation Date")
        HeaderStr.Add("Amend By")
        HeaderStr.Add("Amend Date")
        HeaderSize.Add(15)
        HeaderSize.Add(3)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        HeaderSize.Add(15)
        HeaderSize.Add(12)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadAdMsCurrencyRates(ByVal tCurRte_id As Integer)
        tAdMsCurrencyRates = New cAdMsCurrencyRates(tCurRte_id)
        If tAdMsCurrencyRates.CurRte_id <> 0 Then
            With tAdMsCurrencyRates
                Me.txtCurRte_id.ReadOnly = True
                Me.txtCurRte_id.BackColor = SystemColors.Info
                Me.txtCurRte_id.Text = CStr(.CurRte_id)
                ' Need to decide what to do with a combo in the load sub Property = AlphaCode
                Me.txtRate.Text = Format(.Rate, "0.0000000000")
                Me.DateEffective.Value = .EffectiveDate
                Me.txtCreatedBy.Text = .CreatedBy
                'Dim U1 As New cUsers(.CreatedBy)
                'If U1.Id > 0 Then
                '    Me.txtCreatedBy.Text = U1.FullName
                'Else
                '    Me.txtCreatedBy.Text = ""
                'End If
                Me.DateCreated.Value = .CreationDate
                Me.txtAmendBy.Text = CStr(.AmendBy)
                Me.DateAmend.Value = .AmendDate
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAdMsCurrencyRates()
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        ' LoadDataFromDG1(0)

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
        Response = MsgBox("Are you sure you want to delete " & Me.txtCurRte_id.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tAdMsCurrencyRates.Delete(CInt(Trim(Me.txtCurRte_id.Text))) Then
                Me.lblSSStatus.Text = Me.txtCurRte_id.Text & " has been deleted"
                ClearMe()
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
        'Dim U1 As cUsers
        If Me.DG1.RowCount > 0 Then
            Me.txtCurRte_id.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.cmbAlphaCode.SelectedIndex = cmbAlphaCode.FindStringExact(Trim(CStr(DG1.Item(1, i).Value)))
            Me.txtRate.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.DateEffective.Value = DbNullToString(DG1.Item(3, i).Value)

            'U1 = New cUsers()
            'If U1.Id > 0 Then
            '    Me.txtCreatedBy.Text = U1.FullName
            'Else

            'End If

            Me.DateCreated.Value = DbNullToString(DG1.Item(5, i).Value)
            'U1 = New cUsers(DbNullToInt(DG1.Item(6, i).Value))
            'If U1.Id > 0 Then
            '    Me.txtAmendBy.Text = U1.FullName
            'Else
            '    Me.txtAmendBy.Text = ""
            'End If

            Me.DateAmend.Value = DbNullToDate(DG1.Item(7, i).Value)

            Me.txtCreatedBy.Text = DbNullToString(DG1.Item(8, i).Value)
            Me.txtAmendBy.Text = DbNullToString(DG1.Item(9, i).Value)
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        'Me.txtCurRte_id.ReadOnly = RO
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
