Public Class frmPrAnEmployeeAnalysis2
    Dim tPrAnEmployeeAnalysis2 As New cPrAnEmployeeAnalysis2
    Dim DG1Changing As Boolean = False
    Private Sub frmPrAnEmployeeAnalysis2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtCode.Text = "" Then
            Flag = False
            Me.ErrCode.SetError(Me.txtCode, "Field is Required")
        End If
        If Me.txtDescriptionL.Text = "" Then
            Flag = False
            Me.ErrDescriptionL.SetError(Me.txtDescriptionL, "Field is Required")
        End If
        If Me.txtDescriptionS.Text = "" Then
            Flag = False
            Me.ErrDescriptionS.SetError(Me.txtDescriptionS, "Field is Required")
        End If
        
        'If Me.txtGLAnal1.Text = "" Then
        '    Flag = False
        '    Me.ErrGLAnal1.SetError(Me.txtGLAnal1, "Field is Required")
        'End If
        'If Me.txtGLAnal2.Text = "" Then
        '    Flag = False
        '    Me.ErrGLAnal2.SetError(Me.txtGLAnal2, "Field is Required")
        'End If
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tPrAnEmployeeAnalysis2 As New cPrAnEmployeeAnalysis2(Trim(Me.txtCode.Text))
                    If tPrAnEmployeeAnalysis2.Code <> "" Then
                        MsgBox("Analysis2 already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtCode.Text = ""
        Me.txtDescriptionL.Text = ""
        Me.txtDescriptionS.Text = ""
        Me.CBIsActive.Checked = True
        Me.txtGLAnal1.Text = ""
        Me.txtGLAnal2.Text = ""
        Me.DateCreated.Value = Now.Date
        Me.DateAmend.Value = Now.Date
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCode.SetError(Me.txtCode, "")
        Me.ErrDescriptionL.SetError(Me.txtDescriptionL, "")
        Me.ErrDescriptionS.SetError(Me.txtDescriptionS, "")
        'Me.ErrIsActive.SetError(Me.txtIsActive, "")
        Me.ErrGLAnal1.SetError(Me.txtGLAnal1, "")
        Me.ErrGLAnal2.SetError(Me.txtGLAnal2, "")
        'Me.ErrCreationDate.SetError(Me.txtCreationDate, "")
        'Me.ErrAmendDate.SetError(Me.txtAmendDate, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrAnEmployeeAnalysis2 = New cPrAnEmployeeAnalysis2
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtCode.Focus()
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
                If Me.txtCode.ReadOnly Then
                    Update = True
                Else
                    Update = False
                End If
                'If CBIsActive.CheckState = CheckState.Unchecked Then
                '    Dim DsEmp As New DataSet
                '    DsEmp = Global1.Business.CheckIfThisAnalysisIsUsed(CStr(Me.txtCode.Text), 2)
                '    If CheckDataSet(DsEmp) Then
                '        Dim MainError As String = "There are employees with this Analysis assign to them, Please remove and then set as inactive  " & Chr(10)
                '        Dim i As Integer
                '        For i = 0 To DsEmp.Tables(0).Rows.Count - 1
                '            Dim A As String
                '            Dim B As String
                '            Dim C As String
                '            A = DbNullToString(DsEmp.Tables(0).Rows(i).Item(0))
                '            B = DbNullToString(DsEmp.Tables(0).Rows(i).Item(1))
                '            C = DbNullToString(DsEmp.Tables(0).Rows(i).Item(2))
                '            MainError = MainError & "Employee:" & A & " " & B & " Template Group:" & C & Chr(10)
                '        Next
                '        My.Computer.Clipboard.SetText(MainError)
                '        MsgBox(MainError, MsgBoxStyle.Critical)
                '        MsgBox("Errors are copied to clipboard", MsgBoxStyle.Critical)
                '        Exit Sub
                '    End If
                'End If
                With tPrAnEmployeeAnalysis2
                    .Code = CStr(Me.txtCode.Text)
                    .DescriptionL = CStr(Me.txtDescriptionL.Text)
                    .DescriptionS = CStr(Me.txtDescriptionS.Text)
                    If Me.CBIsActive.CheckState = CheckState.Checked Then
                        .IsActive = "Y"
                    Else
                        .IsActive = "N"
                    End If
                    .GLAnal1 = CStr(Me.txtGLAnal1.Text)
                    .GLAnal2 = CStr(Me.txtGLAnal2.Text)
                    If Not Update Then
                        .CreationDate = Now.Date
                    Else
                        .CreationDate = DateCreated.Value.Date
                    End If
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
                        FindWhereToSelect(.Code)
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
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        HeaderStr.Add("Code")
        HeaderStr.Add("Long Description")
        HeaderStr.Add("Short Description")
        HeaderStr.Add("Is Active")
        HeaderStr.Add("GLAnal1")
        HeaderStr.Add("GLAnal2")
        HeaderStr.Add("Creation Date")
        HeaderStr.Add("Amend Date")
        HeaderSize.Add(12)
        HeaderSize.Add(40)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrAnEmployeeAnalysis2(ByVal tCode As String)
        tPrAnEmployeeAnalysis2 = New cPrAnEmployeeAnalysis2(tCode)
        If tPrAnEmployeeAnalysis2.Code <> "" Then
            With tPrAnEmployeeAnalysis2
                Me.txtCode.ReadOnly = True
                Me.txtCode.BackColor = SystemColors.Info
                Me.txtCode.Text = CStr(.Code)
                Me.txtDescriptionL.Text = CStr(.DescriptionL)
                Me.txtDescriptionS.Text = CStr(.DescriptionS)
                If CStr(.IsActive) = "Y" Then
                    Me.CBIsActive.Checked = True
                Else
                    Me.CBIsActive.Checked = False
                End If
                Me.txtGLAnal1.Text = CStr(.GLAnal1)
                Me.txtGLAnal2.Text = CStr(.GLAnal2)
                Me.DateCreated.Value = .CreationDate
                Me.DateAmend.Value = .AmendDate
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtCode.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrAnEmployeeAnalysis2.Delete(Trim(Me.txtCode.Text)) Then
                Me.lblSSStatus.Text = Me.txtCode.Text & " has been deleted"
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
        If DG1.RowCount > 0 Then
            Me.txtCode.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtDescriptionL.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtDescriptionS.Text = DbNullToString(DG1.Item(2, i).Value)

            If Me.txtDescriptionS.Text = "" Then
                Me.txtDescriptionS.Text = Me.txtDescriptionL.Text
            End If

            If DbNullToString(DG1.Item(3, i).Value) = "Y" Then
                Me.CBIsActive.Checked = True
            Else
                Me.CBIsActive.Checked = False
            End If
            Me.txtGLAnal1.Text = DbNullToString(DG1.Item(4, i).Value)
            Me.txtGLAnal2.Text = DbNullToString(DG1.Item(5, i).Value)
            Me.DateCreated.Value = DbNullToDate(DG1.Item(6, i).Value)
            Me.DateAmend.Value = DbNullToDate(DG1.Item(7, i).Value)
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtCode.ReadOnly = RO
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
