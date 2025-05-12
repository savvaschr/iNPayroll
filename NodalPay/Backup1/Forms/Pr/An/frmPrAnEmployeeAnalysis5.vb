Public Class frmPrAnEmployeeAnalysis5
    Dim tPrAnEmployeeAnalysis5 As New cPrAnEmployeeAnalysis5
    Dim DG1Changing As Boolean = False
    Private Sub frmPrAnEmployeeAnalysis5_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtEmpAn5_Code.Text = "" Then
            Flag = False
            Me.ErrEmpAn5_Code.SetError(Me.txtEmpAn5_Code, "Field is Required")
        End If
        If Me.txtEmpAn5_DescriptionL.Text = "" Then
            Flag = False
            Me.ErrEmpAn5_DescriptionL.SetError(Me.txtEmpAn5_DescriptionL, "Field is Required")
        End If
        If Me.txtEmpAn5_DescriptionS.Text = "" Then
            Flag = False
            Me.ErrEmpAn5_DescriptionS.SetError(Me.txtEmpAn5_DescriptionS, "Field is Required")
        End If
        'If Me.txtEmpAn5_GLAnal1.Text = "" Then
        '    Flag = False
        '    Me.ErrEmpAn5_GLAnal1.SetError(Me.txtEmpAn5_GLAnal1, "Field is Required")
        'End If
        'If Me.txtEmpAn5_GLAnal2.Text = "" Then
        '    Flag = False
        '    Me.ErrEmpAn5_GLAnal2.SetError(Me.txtEmpAn5_GLAnal2, "Field is Required")
        'End If
        If Flag Then
            If Me.txtEmpAn5_Code.Text <> "" Then
                If Not Me.txtEmpAn5_Code.ReadOnly Then
                    Dim tPrAnEmployeeAnalysis5 As New cPrAnEmployeeAnalysis5(Trim(Me.txtEmpAn5_Code.Text))
                    If tPrAnEmployeeAnalysis5.EmpAn5_Code <> "" Then
                        MsgBox("Analysis5 already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtEmpAn5_Code.Text = ""
        Me.txtEmpAn5_DescriptionL.Text = ""
        Me.txtEmpAn5_DescriptionS.Text = ""
        Me.CBIsActive.Checked = True
        Me.txtEmpAn5_GLAnal1.Text = ""
        Me.txtEmpAn5_GLAnal2.Text = ""
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
        Me.ErrEmpAn5_Code.SetError(Me.txtEmpAn5_Code, "")
        Me.ErrEmpAn5_DescriptionL.SetError(Me.txtEmpAn5_DescriptionL, "")
        Me.ErrEmpAn5_DescriptionS.SetError(Me.txtEmpAn5_DescriptionS, "")
        'Me.ErrEmpAn5_IsActive.SetError(Me.txtEmpAn5_IsActive, "")
        Me.ErrEmpAn5_GLAnal1.SetError(Me.txtEmpAn5_GLAnal1, "")
        Me.ErrEmpAn5_GLAnal2.SetError(Me.txtEmpAn5_GLAnal2, "")
        'Me.ErrEmpAn5_CreationDate.SetError(Me.txtEmpAn5_CreationDate, "")
        'Me.ErrEmpAn5_AmendDate.SetError(Me.txtEmpAn5_AmendDate, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrAnEmployeeAnalysis5 = New cPrAnEmployeeAnalysis5
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtEmpAn5_Code.Focus()
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
                If Me.txtEmpAn5_Code.ReadOnly Then
                    Update = True
                Else
                    Update = False
                End If
                With tPrAnEmployeeAnalysis5
                    .EmpAn5_Code = CStr(Me.txtEmpAn5_Code.Text)
                    .EmpAn5_DescriptionL = CStr(Me.txtEmpAn5_DescriptionL.Text)
                    .EmpAn5_DescriptionS = CStr(Me.txtEmpAn5_DescriptionS.Text)
                    If CBIsActive.CheckState = CheckState.Checked Then
                        .EmpAn5_IsActive = "Y"
                    Else
                        .EmpAn5_IsActive = "N"
                    End If
                    .GLAnal1 = CStr(Me.txtEmpAn5_GLAnal1.Text)
                    .GLAnal2 = CStr(Me.txtEmpAn5_GLAnal2.Text)
                    If Not Update Then
                        .EmpAn5_CreationDate = Now.Date
                    Else
                        .EmpAn5_CreationDate = DateCreated.Value.Date
                    End If
                    .EmpAn5_AmendDate = Now.Date
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
                        FindWhereToSelect(.EmpAn5_Code)
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
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        HeaderStr.Add("Code")
        HeaderStr.Add("DescriptionL")
        HeaderStr.Add("DescriptionS")
        HeaderStr.Add("IsActive")
        HeaderStr.Add("GLAnal1")
        HeaderStr.Add("GLAnal2")
        HeaderStr.Add("CreationDate")
        HeaderStr.Add("AmendDate")
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
    Private Sub LoadPrAnEmployeeAnalysis5(ByVal tEmpAn5_Code As String)
        tPrAnEmployeeAnalysis5 = New cPrAnEmployeeAnalysis5(tEmpAn5_Code)
        If tPrAnEmployeeAnalysis5.EmpAn5_Code <> "" Then
            With tPrAnEmployeeAnalysis5
                Me.txtEmpAn5_Code.ReadOnly = True
                Me.txtEmpAn5_Code.BackColor = SystemColors.Info
                Me.txtEmpAn5_Code.Text = CStr(.EmpAn5_Code)
                Me.txtEmpAn5_DescriptionL.Text = CStr(.EmpAn5_DescriptionL)
                Me.txtEmpAn5_DescriptionS.Text = CStr(.EmpAn5_DescriptionS)
                If CStr(.EmpAn5_IsActive) = "Y" Then
                    Me.CBIsActive.Checked = True
                Else
                    Me.CBIsActive.Checked = False
                End If
                Me.txtEmpAn5_GLAnal1.Text = CStr(.GLAnal1)
                Me.txtEmpAn5_GLAnal2.Text = CStr(.GLAnal2)
                Me.DateCreated.Value = .EmpAn5_CreationDate
                Me.DateAmend.Value = .EmpAn5_AmendDate
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        DG1Changing = True
        Me.DG1.DataSource = ds.Tables(0)
        DG1Changing = False
        '     LoadDataFromDG1(0)

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
        Response = MsgBox("Are you sure you want to delete " & Me.txtEmpAn5_Code.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrAnEmployeeAnalysis5.Delete(Trim(Me.txtEmpAn5_Code.Text)) Then
                Me.lblSSStatus.Text = Me.txtEmpAn5_Code.Text & " has been deleted"
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
            Me.txtEmpAn5_Code.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtEmpAn5_DescriptionL.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtEmpAn5_DescriptionS.Text = DbNullToString(DG1.Item(2, i).Value)
            If Me.txtEmpAn5_DescriptionS.Text = "" Then
                Me.txtEmpAn5_DescriptionS.Text = Me.txtEmpAn5_DescriptionL.Text
            End If
            If DbNullToString(DG1.Item(3, i).Value) = "Y" Then
                Me.CBIsActive.Checked = True
            Else
                Me.CBIsActive.Checked = False
            End If
            Me.txtEmpAn5_GLAnal1.Text = DbNullToString(DG1.Item(4, i).Value)
            Me.txtEmpAn5_GLAnal2.Text = DbNullToString(DG1.Item(5, i).Value)
            Me.DateCreated.Value = DbNullToDate(DG1.Item(6, i).Value)
            Me.DateAmend.Value = DbNullToDate(DG1.Item(7, i).Value)
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtEmpAn5_Code.ReadOnly = RO
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
