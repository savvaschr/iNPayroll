Public Class frmPrAnUnions
    Dim tPrAnUnions As New cPrAnUnions
    Dim DG1Changing As Boolean = False
    Private Sub frmPrAnUnions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
       
        If Me.txtUni_SubscriptionType.Text = "" Then
            Flag = False
            Me.ErrUni_SubscriptionType.SetError(Me.txtUni_SubscriptionType, "Field is Required")
        End If
        If Me.txtGLAnal1.Text = "" Then
            Flag = False
            Me.ErrGLAnal1.SetError(Me.txtGLAnal1, "Field is Required")
        End If
        If Me.txtGLAnal2.Text = "" Then
            Flag = False
            Me.ErrGLAnal2.SetError(Me.txtGLAnal2, "Field is Required")
        End If
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tPrAnUnions As New cPrAnUnions(Trim(Me.txtCode.Text))
                    If tPrAnUnions.Code <> "" Then
                        MsgBox("Union already exists - Record cannot be inserted", MsgBoxStyle.Critical)
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
        Me.txtUni_SubscriptionType.Text = "S"
        Me.txtGLAnal1.Text = ""
        Me.txtGLAnal2.Text = ""
        Me.txtUni_SubscriptionValue.Text = "0.00"
        Me.txtCreationDate.Text = ""
        Me.txtUni_Deduction1.Text = "0.00"
        Me.txtUni_Deduction2.Text = "0.00"
        Me.txtAmendDate.Text = ""
        Me.txtWelfareRate.Text = "0.00"
        Me.txtWeeklyMF.Text = "0.00"
        Me.txtMonthlyMF.Text = "0.00"
        Me.txtWeeklySubLimit.Text = "0.00"
        Me.txtMonthlySubLimit.Text = "0.00"
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtUni_SubscriptionValue.KeyPress, AddressOf NumericKeyPress
        AddHandler txtUni_SubscriptionValue.Leave, AddressOf NumericOnLeave
        AddHandler txtUni_Deduction1.KeyPress, AddressOf NumericKeyPress
        AddHandler txtUni_Deduction1.Leave, AddressOf NumericOnLeave
        AddHandler txtUni_Deduction2.KeyPress, AddressOf NumericKeyPress
        AddHandler txtUni_Deduction2.Leave, AddressOf NumericOnLeave
        AddHandler txtWelfareRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtWelfareRate.Leave, AddressOf NumericOnLeave
        AddHandler txtWeeklyMF.KeyPress, AddressOf NumericKeyPress
        AddHandler txtWeeklyMF.Leave, AddressOf NumericOnLeave
        AddHandler txtMonthlyMF.KeyPress, AddressOf NumericKeyPress
        AddHandler txtMonthlyMF.Leave, AddressOf NumericOnLeave
        AddHandler txtWeeklySubLimit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtWeeklySubLimit.Leave, AddressOf NumericOnLeave
        AddHandler txtMonthlySubLimit.KeyPress, AddressOf NumericKeyPress
        AddHandler txtMonthlySubLimit.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCode.SetError(Me.txtCode, "")
        Me.ErrDescriptionL.SetError(Me.txtDescriptionL, "")
        Me.ErrDescriptionS.SetError(Me.txtDescriptionS, "")
        'Me.ErrIsActive.SetError(Me.txtIsActive, "")
        Me.ErrUni_SubscriptionType.SetError(Me.txtUni_SubscriptionType, "")
        Me.ErrGLAnal1.SetError(Me.txtGLAnal1, "")
        Me.ErrGLAnal2.SetError(Me.txtGLAnal2, "")
        Me.ErrUni_SubscriptionValue.SetError(Me.txtUni_SubscriptionValue, "")
        Me.ErrCreationDate.SetError(Me.txtCreationDate, "")
        Me.ErrUni_Deduction1.SetError(Me.txtUni_Deduction1, "")
        Me.ErrUni_Deduction2.SetError(Me.txtUni_Deduction2, "")
        Me.ErrAmendDate.SetError(Me.txtAmendDate, "")
        Me.ErrWelfareRate.SetError(Me.txtWelfareRate, "")
        Me.ErrWeeklyMF.SetError(Me.txtWeeklyMF, "")
        Me.ErrMonthlyMF.SetError(Me.txtMonthlyMF, "")
        Me.ErrWeeklySubLimit.SetError(Me.txtWeeklySubLimit, "")
        Me.ErrMonthlySubLimit.SetError(Me.txtMonthlySubLimit, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrAnUnions = New cPrAnUnions
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
                With tPrAnUnions
                    .Code = CStr(Me.txtCode.Text)
                    .DescriptionL = CStr(Me.txtDescriptionL.Text)
                    .DescriptionS = CStr(Me.txtDescriptionS.Text)
                    If Me.CBIsActive.CheckState = CheckState.Checked Then
                        .IsActive = "Y"
                    Else
                        .IsActive = "N"
                    End If
                    .Uni_SubscriptionType = CStr(Me.txtUni_SubscriptionType.Text)
                    .GLAnal1 = CStr(Me.txtGLAnal1.Text)
                    .GLAnal2 = CStr(Me.txtGLAnal2.Text)
                    .Uni_SubscriptionValue = CDbl(Me.txtUni_SubscriptionValue.Text)
                    If Not Update Then
                        .CreationDate = Now.Date
                    Else
                        .CreationDate = CDate(Me.txtCreationDate.Text)
                    End If
                    .Uni_Deduction1 = CDbl(Me.txtUni_Deduction1.Text)
                    .Uni_Deduction2 = CDbl(Me.txtUni_Deduction2.Text)
                    .AmendDate = Now.Date
                    .WelfareRate = CDbl(Me.txtWelfareRate.Text)
                    .WeeklyMF = CDbl(Me.txtWeeklyMF.Text)
                    .MonthlyMF = CDbl(Me.txtMonthlyMF.Text)
                    .WeeklySubLimit = CDbl(Me.txtWeeklySubLimit.Text)
                    .MonthlySubLimit = CDbl(Me.txtMonthlySubLimit.Text)
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
        ds = Global1.Business.AG_GetAllPrAnUnions()
        HeaderStr.Add("Code")
        HeaderStr.Add("Long Description")
        HeaderStr.Add("Short Description")
        HeaderStr.Add("Is Active")
        HeaderStr.Add("SubscriptionType")
        HeaderStr.Add("GLAnal1")
        HeaderStr.Add("GLAnal2")
        HeaderStr.Add("SubscriptionValue")
        HeaderStr.Add("Creation Date")
        HeaderStr.Add("Deduction1")
        HeaderStr.Add("Deduction2")
        HeaderStr.Add("Amend Date")
        HeaderStr.Add("Welfare Rate")
        HeaderStr.Add("Weekly MF")
        HeaderStr.Add("Monthly MF")
        HeaderStr.Add("Weekly Sub. Limit")
        HeaderStr.Add("Monthly Sub. Limit")
        HeaderSize.Add(12)
        HeaderSize.Add(40)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(1)
        HeaderSize.Add(12)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrAnUnions(ByVal tCode As String)
        tPrAnUnions = New cPrAnUnions(tCode)
        If tPrAnUnions.Code <> "" Then
            With tPrAnUnions
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
                Me.txtUni_SubscriptionType.Text = CStr(.Uni_SubscriptionType)
                Me.txtGLAnal1.Text = CStr(.GLAnal1)
                Me.txtGLAnal2.Text = CStr(.GLAnal2)
                Me.txtUni_SubscriptionValue.Text = Format(.Uni_SubscriptionValue, "0.00")
                Me.txtCreationDate.Text = CStr(.CreationDate)
                Me.txtUni_Deduction1.Text = Format(.Uni_Deduction1, "0.00")
                Me.txtUni_Deduction2.Text = Format(.Uni_Deduction2, "0.00")
                Me.txtAmendDate.Text = CStr(.AmendDate)
                Me.txtWelfareRate.Text = Format(.WelfareRate, "0.00")
                Me.txtWeeklyMF.Text = Format(.WeeklyMF, "0.00")
                Me.txtMonthlyMF.Text = Format(.MonthlyMF, "0.00")
                Me.txtWeeklySubLimit.Text = Format(.WeeklySubLimit, "0.00")
                Me.txtMonthlySubLimit.Text = Format(.MonthlySubLimit, "0.00")
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrAnUnions()
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
            If tPrAnUnions.Delete(Trim(Me.txtCode.Text)) Then
                Me.lblSSStatus.Text = Me.txtCode.Text & " has been deleted"
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
        Me.txtCode.Text = DbNullToString(DG1.Item(0, i).Value)
        Me.txtDescriptionL.Text = DbNullToString(DG1.Item(1, i).Value)
        Me.txtDescriptionS.Text = DbNullToString(DG1.Item(2, i).Value)

        If DbNullToString(DG1.Item(3, i).Value) = "Y" Then
            Me.CBIsActive.Checked = True
        Else
            Me.CBIsActive.Checked = False
        End If
        Me.txtUni_SubscriptionType.Text = DbNullToString(DG1.Item(4, i).Value)
        Me.txtGLAnal1.Text = DbNullToString(DG1.Item(5, i).Value)
        Me.txtGLAnal2.Text = DbNullToString(DG1.Item(6, i).Value)
        Me.txtUni_SubscriptionValue.Text = DbNullToString(DG1.Item(7, i).Value)
        Me.txtCreationDate.Text = DbNullToString(DG1.Item(8, i).Value)
        Me.txtUni_Deduction1.Text = DbNullToString(DG1.Item(9, i).Value)
        Me.txtUni_Deduction2.Text = DbNullToString(DG1.Item(10, i).Value)
        Me.txtAmendDate.Text = DbNullToString(DG1.Item(11, i).Value)
        Me.txtWelfareRate.Text = DbNullToString(DG1.Item(12, i).Value)
        Me.txtWeeklyMF.Text = DbNullToString(DG1.Item(13, i).Value)
        Me.txtMonthlyMF.Text = DbNullToString(DG1.Item(14, i).Value)
        Me.txtWeeklySubLimit.Text = DbNullToString(DG1.Item(15, i).Value)
        Me.txtMonthlySubLimit.Text = DbNullToString(DG1.Item(16, i).Value)
        PKInputReadOnly(True)
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
