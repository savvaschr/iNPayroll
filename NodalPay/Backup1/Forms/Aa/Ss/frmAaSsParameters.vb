Public Class frmAaSsParameters
    Dim tAaSsParameters As New cAaSsParameters
    Dim DG1Changing As Boolean = False
    Private Sub frmAaSsParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtSection.Text = "" Then
            Flag = False
            Me.ErrSection.SetError(Me.txtSection, "Field is Required")
        End If
        If Me.txtItem.Text = "" Then
            Flag = False
            Me.ErrItem.SetError(Me.txtItem, "Field is Required")
        End If
        If Me.txtValue1.Text = "" Then
            Flag = False
            Me.ErrValue1.SetError(Me.txtValue1, "Field is Required")
        End If
        If Me.txtDescription.Text = "" Then
            Flag = False
            Me.ErrDescription.SetError(Me.txtDescription, "Field is Required")
        End If
        'If Me.txtSystem1.Text = "" Then
        '    Flag = False
        '    Me.ErrSystem1.SetError(Me.txtSystem1, "Field is Required")
        'End If
        If Me.txtType1.Text = "" Then
            Flag = False
            Me.ErrType1.SetError(Me.txtType1, "Field is Required")
        End If
        If Flag Then
            If Me.txtId.Text <> "" Then
                If Not Me.txtId.ReadOnly Then
                    Dim tAaSsParameters As New cAaSsParameters(Trim(Me.txtSection.Text), Trim(Me.txtItem.Text))
                    If tAaSsParameters.Id <> Me.txtId.Text Then
                        MsgBox("Parameter already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.txtSection.Text = ""
        Me.txtItem.Text = ""
        Me.txtValue1.Text = ""
        Me.txtDescription.Text = ""
        Me.CBSystem.CheckState = CheckState.Unchecked
        Me.txtType1.Text = ""
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrId.SetError(Me.txtId, "")
        Me.ErrSection.SetError(Me.txtSection, "")
        Me.ErrItem.SetError(Me.txtItem, "")
        Me.ErrValue1.SetError(Me.txtValue1, "")
        Me.ErrDescription.SetError(Me.txtDescription, "")
        '  Me.ErrSystem1.SetError(Me.txtSystem1, "")
        Me.ErrType1.SetError(Me.txtType1, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tAaSsParameters = New cAaSsParameters
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtId.Focus()
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
                '  If Me.txtId.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tAaSsParameters
                    .Id = NullToInt(Me.txtId.Text)
                    .Section = CStr(Me.txtSection.Text)
                    .Item = CStr(Me.txtItem.Text)
                    .Value1 = CStr(Me.txtValue1.Text)
                    .Description = CStr(Me.txtDescription.Text)
                    If Me.CBSystem.CheckState = CheckState.Checked Then
                        .System1 = "Y"
                    Else
                        .System1 = "N"
                    End If
                    .Type1 = CStr(Me.txtType1.Text)
                    If .Save() Then
                        MsgBox("Changes are successfully Saved", MsgBoxStyle.Information)
                        'If DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        FillDG1()
                        FindWhereToSelect(.Id)
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
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
        ds = Global1.Business.AG_GetAllAaSsParameters()
        HeaderStr.Add("Id")
        HeaderStr.Add("Section")
        HeaderStr.Add("Item")
        HeaderStr.Add("Value")
        HeaderStr.Add("Description")
        HeaderStr.Add("System")
        HeaderStr.Add("Type")
        HeaderSize.Add(15)
        HeaderSize.Add(30)
        HeaderSize.Add(30)
        HeaderSize.Add(100)
        HeaderSize.Add(250)
        HeaderSize.Add(1)
        HeaderSize.Add(1)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadAaSsParameters(ByVal tId As Integer)
        tAaSsParameters = New cAaSsParameters(tId)
        If tAaSsParameters.Id <> 0 Then
            With tAaSsParameters
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.txtSection.Text = CStr(.Section)
                Me.txtItem.Text = CStr(.Item)
                Me.txtValue1.Text = CStr(.Value1)
                Me.txtDescription.Text = CStr(.Description)
                If CStr(.System1) = "Y" Then
                    Me.CBSystem.Checked = True
                Else
                    Me.CBSystem.Checked = False
                End If
                Me.txtType1.Text = CStr(.Type1)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAaSsParameters()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tAaSsParameters.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
                Me.ClearMe()
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
        Me.txtSection.Text = DbNullToString(DG1.Item(1, i).Value)
        Me.txtItem.Text = DbNullToString(DG1.Item(2, i).Value)
        Me.txtValue1.Text = DbNullToString(DG1.Item(3, i).Value)
        Me.txtDescription.Text = DbNullToString(DG1.Item(4, i).Value)
        If DbNullToString(DG1.Item(5, i).Value) = "Y" Then
            Me.CBSystem.Checked = True
        Else
            Me.CBSystem.Checked = False
        End If
        Me.txtType1.Text = DbNullToString(DG1.Item(6, i).Value)
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        '    Me.txtId.ReadOnly = RO
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
