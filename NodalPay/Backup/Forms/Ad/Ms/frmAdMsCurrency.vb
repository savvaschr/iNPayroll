Public Class frmAdMsCurrency
    Dim tAdMsCurrency As New cAdMsCurrency
    Dim DG1Changing As Boolean = False
    Private Sub frmAdMsCurrency_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtAlphaCode.Text = "" Then
            Flag = False
            Me.ErrAlphaCode.SetError(Me.txtAlphaCode, "Field is Required")
        End If
        If Me.txtNumericCode.Text = "" Then
            Flag = False
            Me.ErrNumericCode.SetError(Me.txtNumericCode, "Field is Required")
        End If
        If Me.txtDescription.Text = "" Then
            Flag = False
            Me.ErrDescription.SetError(Me.txtDescription, "Field is Required")
        End If
        If Me.txtSymbol.Text = "" Then
            Flag = False
            Me.ErrSymbol.SetError(Me.txtSymbol, "Field is Required")
        End If

        If Flag Then
            If Me.txtAlphaCode.Text <> "" Then
                If Not Me.txtAlphaCode.ReadOnly Then
                    Dim tAdMsCurrency As New cAdMsCurrency(Trim(Me.txtAlphaCode.Text))
                    If tAdMsCurrency.AlphaCode <> "" Then
                        MsgBox("Currency already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtAlphaCode.Text = ""
        Me.txtNumericCode.Text = ""
        Me.txtDescription.Text = ""
        Me.txtSymbol.Text = ""
        Me.CBIsActive.Checked = True
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrAlphaCode.SetError(Me.txtAlphaCode, "")
        Me.ErrNumericCode.SetError(Me.txtNumericCode, "")
        Me.ErrDescription.SetError(Me.txtDescription, "")
        Me.ErrSymbol.SetError(Me.txtSymbol, "")
        'Me.ErrIsActive.SetError(Me.txtIsActive, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tAdMsCurrency = New cAdMsCurrency
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtAlphaCode.Focus()
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
                '  If Me.txtAlphaCode.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tAdMsCurrency
                    .AlphaCode = CStr(Me.txtAlphaCode.Text)
                    .NumericCode = CStr(Me.txtNumericCode.Text)
                    .Description = CStr(Me.txtDescription.Text)
                    .Symbol = CStr(Me.txtSymbol.Text)
                    If Me.CBIsActive.CheckState = CheckState.Checked Then
                        .IsActive = "Y"
                    Else
                        .IsActive = "N"
                    End If
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        'If Me.DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
                        FindWhereToSelect(.AlphaCode)
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
        ds = Global1.Business.AG_GetAllAdMsCurrency()
        HeaderStr.Add("Alpha Code")
        HeaderStr.Add("Numeric Code")
        HeaderStr.Add("Description")
        HeaderStr.Add("Symbol")
        HeaderStr.Add("Is Active")
        HeaderSize.Add(3)
        HeaderSize.Add(3)
        HeaderSize.Add(30)
        HeaderSize.Add(1)
        HeaderSize.Add(1)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadAdMsCurrency(ByVal tAlphaCode As String)
        tAdMsCurrency = New cAdMsCurrency(tAlphaCode)
        If tAdMsCurrency.AlphaCode <> "" Then
            With tAdMsCurrency
                Me.txtAlphaCode.ReadOnly = True
                Me.txtAlphaCode.BackColor = SystemColors.Info
                Me.txtAlphaCode.Text = CStr(.AlphaCode)
                Me.txtNumericCode.Text = CStr(.NumericCode)
                Me.txtDescription.Text = CStr(.Description)
                Me.txtSymbol.Text = CStr(.Symbol)
                If CStr(.IsActive) = "Y" Then
                    Me.CBIsActive.Checked = True
                Else
                    Me.CBIsActive.Checked = False
                End If
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAdMsCurrency()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtAlphaCode.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tAdMsCurrency.Delete(Trim(Me.txtAlphaCode.Text)) Then
                Me.lblSSStatus.Text = Me.txtAlphaCode.Text & " has been deleted"
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
        If Me.DG1.RowCount > 0 Then
            Me.txtAlphaCode.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtNumericCode.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtDescription.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.txtSymbol.Text = DbNullToString(DG1.Item(3, i).Value)
            If DbNullToString(DG1.Item(4, i).Value) = "Y" Then
                Me.CBIsActive.Checked = True
            Else
                Me.CBIsActive.Checked = False
            End If
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtAlphaCode.ReadOnly = RO
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
