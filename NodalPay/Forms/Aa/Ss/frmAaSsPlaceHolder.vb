Public Class frmAaSsPlaceHolder
    Dim tAaSsPlaceHolder As New cAaSsPlaceHolder
    Dim DG1Changing As Boolean = False
    Private Sub frmAaSsPlaceHolder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtdim_Key.Text = "" Then
            Flag = False
            Me.Errdim_Key.SetError(Me.txtdim_Key, "Field is Required")
        Else
            If Not IsNumeric(Me.txtdim_Key.Text) Then
                Flag = False
                Me.Errdim_Key.SetError(Me.txtdim_Key, "Field requires a number")
            Else
                If NullToInt(Me.txtdim_Key.Text) < 0 Then
                    Flag = False
                    Me.Errdim_Key.SetError(Me.txtdim_Key, "Field requires positive number")
                End If
            End If
        End If
        If Me.txtdim_Value.Text = "" Then
            Flag = False
            Me.Errdim_Value.SetError(Me.txtdim_Value, "Field is Required")
        End If
        If Flag Then
            If Me.txtdim_Key.Text <> "" Then
                If Not Me.txtdim_Key.ReadOnly Then
                    Dim tAaSsPlaceHolder As New cAaSsPlaceHolder(CInt(Trim(Me.txtdim_Key.Text)))
                    If tAaSsPlaceHolder.dim_Key <> 0 Then
                        MsgBox("Place Holder already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtdim_Key.Text = "0"
        Me.txtdim_Value.Text = ""
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.Errdim_Key.SetError(Me.txtdim_Key, "")
        Me.Errdim_Value.SetError(Me.txtdim_Value, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tAaSsPlaceHolder = New cAaSsPlaceHolder
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtdim_Key.Focus()
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
                '  If Me.txtdim_Key.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tAaSsPlaceHolder
                    .dim_Key = NullToInt(Me.txtdim_Key.Text)
                    .dim_Value = CStr(Me.txtdim_Value.Text)
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        'If Not DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
                        FindWhereToSelect(.dim_Key)
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
        'Dim Loader As New cExcelLoader
        ds = Global1.Business.AG_GetAllAaSsPlaceHolder()
        HeaderStr.Add("dim_Key")
        HeaderStr.Add("dim_Value")
        HeaderSize.Add(15)
        HeaderSize.Add(10)
        '  Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadAaSsPlaceHolder(ByVal tdim_Key As Integer)
        tAaSsPlaceHolder = New cAaSsPlaceHolder(tdim_Key)
        If tAaSsPlaceHolder.dim_Key <> 0 Then
            With tAaSsPlaceHolder
                Me.txtdim_Key.ReadOnly = True
                Me.txtdim_Key.BackColor = SystemColors.Info
                Me.txtdim_Key.Text = CStr(.dim_Key)
                Me.txtdim_Value.Text = CStr(.dim_Value)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAaSsPlaceHolder()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtdim_Key.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tAaSsPlaceHolder.Delete(CInt(Trim(Me.txtdim_Key.Text))) Then
                Me.lblSSStatus.Text = Me.txtdim_Key.Text & " has been deleted"
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
        Me.txtdim_Key.Text = DbNullToString(DG1.Item(0, i).Value)
        Me.txtdim_Value.Text = DbNullToString(DG1.Item(1, i).Value)
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtdim_Key.ReadOnly = RO
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
