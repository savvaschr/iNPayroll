Public Class frmPrMsTemplateGroup
    Dim tPrMsTemplateGroup As New cPrMsTemplateGroup
    Dim DG1Changing As Boolean = False
    Private Sub frmPrMsTemplateGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tPrMsTemplateGroup As New cPrMsTemplateGroup(Trim(Me.txtCode.Text))
                    If tPrMsTemplateGroup.Code <> "" Then
                        MsgBox("Template Group already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtCode.Text = ""
        Try
            Me.cmbPayTypCode.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtDescriptionL.Text = ""
        Me.txtDescriptionS.Text = ""
        Me.CBIsActive.Checked = True
        Me.txtDayUnits.Text = "0.00"
    End Sub
    '
    Private Sub LoadCombos()
        LoadAdMsCompany()
        LoadPrSsPayrollTypes()
    End Sub
    Private Sub LoadAdMsCompany()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllAdMsCompany()
        If CheckDataSet(ds) Then
            Dim tCom As New cAdMsCompany
            With Me.CmbCompany
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tCom = New cAdMsCompany(DbNullToInt(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tCom)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    '
    Private Sub LoadPrSsPayrollTypes()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsPayrollTypes()
        If CheckDataSet(ds) Then
            Dim tPrSsPayrollTypes As New cPrSsPayrollTypes
            With Me.cmbPayTypCode
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsPayrollTypes = New cPrSsPayrollTypes(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsPayrollTypes)
                Next i
                .ValueMember = "PayTyp_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtDayUnits.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDayUnits.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCode.SetError(Me.txtCode, "")
        Me.ErrPayTypCode.SetError(Me.cmbPayTypCode, "")
        Me.ErrDescriptionL.SetError(Me.txtDescriptionL, "")
        Me.ErrDescriptionS.SetError(Me.txtDescriptionS, "")
        '  Me.ErrIsActive.SetError(Me.txtIsActive, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrMsTemplateGroup = New cPrMsTemplateGroup
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
            ' Dim CS As Integer
            Try
                '  If Me.txtCode.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrMsTemplateGroup
                    .Code = CStr(Me.txtCode.Text)
                    .PayTypCode = CType(Me.cmbPayTypCode.SelectedItem, cPrSsPayrollTypes).Code
                    .DescriptionL = CStr(Me.txtDescriptionL.Text)
                    .DescriptionS = CStr(Me.txtDescriptionS.Text)
                    If Me.CBIsActive.CheckState = CheckState.Checked Then
                        .IsActive = "Y"
                    Else
                        .IsActive = "N"
                    End If
                    .DayUnits = Me.txtDayUnits.Text
                    .GLAnl1 = Me.txtGLAnl1.Text
                    .GLAnl2 = Me.txtGlAnl2.Text
                    .CompanyCode = CType(Me.CmbCompany.SelectedItem, cAdMsCompany).Code
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
        ds = Global1.Business.AG_GetAllPrMsTemplateGroup()
        HeaderStr.Add("Code")
        HeaderStr.Add("Payroll Type Code")
        HeaderStr.Add("Long Description")
        HeaderStr.Add("Short Description")
        HeaderStr.Add("Is Active")
        HeaderStr.Add("Day Units")
        HeaderSize.Add(6)
        HeaderSize.Add(4)
        HeaderSize.Add(40)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(8)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrMsTemplateGroup(ByVal tCode As String)
        tPrMsTemplateGroup = New cPrMsTemplateGroup(tCode)
        If tPrMsTemplateGroup.Code <> "" Then
            With tPrMsTemplateGroup
                Me.txtCode.ReadOnly = True
                Me.txtCode.BackColor = SystemColors.Info
                Me.txtCode.Text = CStr(.Code)
                ' Need to decide what to do with a combo in the load sub Property = PayTypCode
                Me.txtDescriptionL.Text = CStr(.DescriptionL)
                Me.txtDescriptionS.Text = CStr(.DescriptionS)
                Me.txtGLAnl1.Text = .GLAnl1
                Me.txtGlAnl2.Text = .GLAnl2
                If CStr(.IsActive) = "Y" Then
                    Me.CBIsActive.Checked = True
                Else
                    Me.CBIsActive.Checked = False
                End If
                Me.txtDayUnits.Text = Format(.DayUnits, "0.00")

                Dim Com As New cAdMsCompany(.CompanyCode)
                Me.CmbCompany.SelectedIndex = Me.CmbCompany.FindStringExact(Com.Tostring)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrMsTemplateGroup()
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
            If tPrMsTemplateGroup.Delete(Trim(Me.txtCode.Text)) Then
                Me.lblSSStatus.Text = Me.txtCode.Text & " has been deleted"
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
            Debug.WriteLine(DbNullToString(DG1.Item(0, i).Value))
            Me.txtCode.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.cmbPayTypCode.SelectedIndex = cmbPayTypCode.FindStringExact(Trim(CStr(DG1.Item(1, i).Value)))
            Me.txtDescriptionL.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.txtDescriptionS.Text = DbNullToString(DG1.Item(3, i).Value)

            If DbNullToString(DG1.Item(4, i).Value) = "Y" Then
                Me.CBIsActive.Checked = True
            Else
                Me.CBIsActive.Checked = False
            End If
            Me.txtDayUnits.Text = Format(DbNullToDouble(DG1.Item(5, i).Value), "0.00")
            Me.txtGLAnl1.Text = DbNullToString(DG1.Item(6, i).Value)
            Me.txtGlAnl2.Text = DbNullToString(DG1.Item(7, i).Value)
            Dim Com As New cAdMsCompany(DbNullToString(DG1.Item(8, i).Value))
            Me.CmbCompany.SelectedIndex = Me.CmbCompany.FindStringExact(Com.Tostring)
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
