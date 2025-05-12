Public Class frmAaSsUsers
    Dim tAaSsUsers As New cAaSsUsers
    Dim DG1Changing As Boolean = False
    Private Sub frmAaSsUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtUserName.Text = "" Then
            Flag = False
            Me.ErrUserName.SetError(Me.txtUserName, "Field is Required")
        End If
        If Me.txtFullName.Text = "" Then
            Flag = False
            Me.ErrFullName.SetError(Me.txtFullName, "Field is Required")
        End If
        
        If Me.txtMyRole.Text = "" Then
            Flag = False
            Me.ErrMyRole.SetError(Me.txtMyRole, "Field is Required")
        Else
            If Not IsNumeric(Me.txtMyRole.Text) Then
                Flag = False
                Me.ErrMyRole.SetError(Me.txtMyRole, "Field requires a number")
            Else
                If NullToInt(Me.txtMyRole.Text) < 0 Then
                    Flag = False
                    Me.ErrMyRole.SetError(Me.txtMyRole, "Field requires positive number")
                End If
            End If
        End If
        If Flag Then
            If Me.txtId.Text <> "" Then
                If Not Me.txtId.ReadOnly Then
                    Dim tAaSsUsers As New cAaSsUsers(CInt(Trim(Me.txtId.Text)))
                    If tAaSsUsers.Id <> 0 Then
                        MsgBox("User already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.txtUserName.Text = ""
        Me.txtFullName.Text = ""
        Me.DateCreated.Value = Now
        Me.CBIsEnabled.Checked = True
        Me.CBIsSA.Checked = False
        Me.txtMyRole.Text = "0"
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
        Me.ErrUserName.SetError(Me.txtUserName, "")
        Me.ErrFullName.SetError(Me.txtFullName, "")
        ' Me.ErrCreatedOn.SetError(Me.txtCreatedOn, "")
        'Me.ErrIsEnabled.SetError(Me.txtIsEnabled, "")
        'Me.ErrIsSA.SetError(Me.txtIsSA, "")
        Me.ErrMyRole.SetError(Me.txtMyRole, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tAaSsUsers = New cAaSsUsers
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
                If Me.txtId.ReadOnly Then
                    Update = True
                Else
                    Update = False
                End If
                With tAaSsUsers
                    .Id = NullToInt(Me.txtId.Text)
                    .UserName = CStr(Me.txtUserName.Text)
                    .FullName = CStr(Me.txtFullName.Text)
                    If Not Update Then
                        .CreatedOn = Me.DateCreated.Value.Date
                    End If
                    If Me.CBIsEnabled.CheckState = CheckState.Checked Then
                        .IsEnabled = "Y"
                    Else
                        .IsEnabled = "N"
                    End If
                    If Me.CBIsSA.CheckState = CheckState.Checked Then
                        .IsSA = "Y"
                    Else
                        .IsSA = "N"
                    End If
                    .MyRole = NullToInt(Me.txtMyRole.Text)
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        'If DG1.Rows.Count - 1 > 0 Then
                        '    CS = Me.DG1.SelectedRows(0).Index
                        'End If
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.Rows(CS + 1).Selected = True
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.Rows(CS).Selected = True
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
        ds = Global1.Business.AG_GetAllAaSsUsers()
        HeaderStr.Add("Id")
        HeaderStr.Add("User Name")
        HeaderStr.Add("Full Name")
        HeaderStr.Add("Created On")
        HeaderStr.Add("Is Enabled")
        HeaderStr.Add("Is SA")
        HeaderStr.Add("MyRole")
        HeaderSize.Add(15)
        HeaderSize.Add(10)
        HeaderSize.Add(50)
        HeaderSize.Add(12)
        HeaderSize.Add(1)
        HeaderSize.Add(1)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadAaSsUsers(ByVal tId As Integer)
        tAaSsUsers = New cAaSsUsers(tId)
        If tAaSsUsers.Id <> 0 Then
            With tAaSsUsers
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.txtUserName.Text = CStr(.UserName)
                Me.txtFullName.Text = CStr(.FullName)
                Me.DateCreated.Value = CDate(.CreatedOn)
                If CStr(.IsEnabled) = "Y" Then
                    Me.CBIsEnabled.Checked = True
                Else
                    Me.CBIsEnabled.Checked = False
                End If

                If CStr(.IsSA) = "Y" Then
                    Me.CBIsSA.Checked = True
                Else
                    Me.CBIsSA.Checked = False
                End If

                Me.txtMyRole.Text = CStr(.MyRole)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllAaSsUsers()
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        '        LoadDataFromDG1(0)

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
            If tAaSsUsers.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
                Me.ClearMe()
                FillDG1()
                LoadDataFromDG1(0)
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
            Me.txtUserName.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtFullName.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.DateCreated.Value = DbNullToDate(DG1.Item(3, i).Value)
            If DbNullToString(DG1.Item(4, i).Value) = "Y" Then
                Me.CBIsEnabled.Checked = True
            Else
                Me.CBIsEnabled.Checked = False
            End If
            If DbNullToString(DG1.Item(5, i).Value) = "Y" Then
                Me.CBIsSA.Checked = True
            Else
                Me.CBIsSA.Checked = False
            End If
            Me.txtMyRole.Text = DbNullToString(DG1.Item(6, i).Value)
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        '  Me.txtId.ReadOnly = RO
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
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim User As String
        Dim Pass As String
        Dim Pass2 As String
        User = Me.txtDBUser.Text
        Pass = Me.txtDBPass.Text
        Pass2 = Me.txtDBPass2.Text

        If Pass = Pass2 Then
            Global1.Business.TrytoCreateDataBaseUser(User, Pass)
        Else
            MsgBox("Password missmatch", MsgBoxStyle.Critical)
        End If





    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim User As String
        User = Me.txtDBUser.Text
        Global1.Business.TrytoAddDataBaseUser(User)


    End Sub
End Class
