Public Class FrmPrMsInterfaceCode
    Dim tPrMsInterfaceCode As New cPrMsInterfaceCodes
    Dim DG1Changing As Boolean = False
    Dim Loading As Boolean = False
    Dim dsTempGroups As DataSet
    Dim dsInterfaceCodes As DataSet


    

    Private Sub frmPrMsInterfaceCode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()

    End Sub
    Public Sub LoadSpecificCode(ByVal GlbTempGrpCode As String, ByVal InterfaceCode As String)
        Me.cmbTemGrp.SelectedIndex = Me.cmbTemGrp.FindString(GlbTempGrpCode)

        Dim F As New FrmPrMsCodeMasking
        ' If Me.txtCode.ReadOnly Then
        F.InterfaceCode = InterfaceCode
        F.Owner = Me
        F.ShowDialog()
        
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
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tPrMsInterfaceTemplate As New cPrMsInterfaceTemplate(Trim(Me.txtCode.Text))
                    If tPrMsInterfaceTemplate.IntTemCode <> "" Then
                        MsgBox("Interface Template already exists - Record cannot be inserted", MsgBoxStyle.Critical)
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
            ' Me.cmbTemGrp.SelectedIndex = 0
        Catch ex As Exception
        End Try
        Me.txtDescriptionL.Text = ""

    End Sub
    '
    Private Sub LoadCombos()
        LoadPrMsTemplateGroups()
        LoadAccountTypes()

    End Sub
    '
    Private Sub LoadPrMsTemplateGroups()
        loading = True

        Dim i As Integer
        dsTempGroups = Global1.Business.AG_GetAllPrMsTemplateGroup()
        If CheckDataSet(dsTempGroups) Then
            Dim tPrMsTemplateGroup As New cPrMsTemplateGroup
            With Me.cmbTemGrp
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To dsTempGroups.Tables(0).Rows.Count - 1
                    tPrMsTemplateGroup = New cPrMsTemplateGroup(DbNullToString(dsTempGroups.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrMsTemplateGroup)
                Next i
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
        loading = False
    End Sub
    Private Sub LoadAccountTypes()
        With Me.cmbAccountType
            .BeginUpdate()
            .Items.Add(Global1.ACT_GLAccount)
            .Items.Add(Global1.ACT_Customer)
            .Items.Add(Global1.ACT_Vendor)
            .Items.Add(Global1.ACT_Bank)
            .Items.Add(Global1.ACT_FixAsset)
            .Items.Add(Global1.ACT_ICPartner)
            .EndUpdate()
        End With

    End Sub
    Private Sub PutDecimalValidationOnTxts()

    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCode.SetError(Me.txtCode, "")
        Me.ErrPayTypCode.SetError(Me.cmbTemGrp, "")
        Me.ErrDescriptionL.SetError(Me.txtDescriptionL, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrMsInterfaceCode = New cPrMsInterfaceCodes
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
                With tPrMsInterfaceCode
                    .Code = CStr(Me.txtCode.Text)
                    .TemGrpCode = CType(Me.cmbTemGrp.SelectedItem, cPrMsTemplateGroup).Code
                    .Description = CStr(Me.txtDescriptionL.Text)
                    Dim S As String()
                    S = Me.cmbAccountType.Text.Split("-")
                    .AccountType = Trim(S(0))

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
                        FindWhereToSelect(.Code)
                        PKInputReadOnly(True)
                        ' Dim ans As New MsgBoxResult
                        ' ans = MsgBox("Create the Masking?", MsgBoxStyle.YesNoCancel)
                        ' If ans = MsgBoxResult.Yes Then

                        'End If
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
        'Dim ds As DataSet
        'Dim HeaderStr As New ArrayList
        'Dim HeaderSize As New ArrayList
        'Dim Loader As New cExcelLoader
        'ds = Global1.Business.AG_GetAllPrMsTemplateGroup()
        'HeaderStr.Add("Code")
        'HeaderStr.Add("Payroll Type Code")
        'HeaderStr.Add("Long Description")
        'HeaderStr.Add("Short Description")
        'HeaderStr.Add("Is Active")
        'HeaderStr.Add("Day Units")
        'HeaderSize.Add(6)
        'HeaderSize.Add(4)
        'HeaderSize.Add(40)
        'HeaderSize.Add(15)
        'HeaderSize.Add(1)
        'HeaderSize.Add(8)
        'Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrMsInterfaceTemplate(ByVal tCode As String)
        tPrMsInterfaceCode = New cPrMsInterfaceCodes(tCode)
        If tPrMsInterfaceCode.Code <> "" Then
            With tPrMsInterfaceCode
                Me.txtCode.ReadOnly = True
                Me.txtCode.BackColor = SystemColors.Info
                Me.txtCode.Text = CStr(.Code)
                ' Need to decide what to do with a combo in the load sub Property = PayTypCode
                Me.txtDescriptionL.Text = CStr(.Description)
                Dim TemGrp As New cPrMsTemplateGroup(.Code)
                Me.cmbTemGrp.SelectedIndex = Me.cmbTemGrp.FindStringExact(TemGrp.ToString)
                Me.cmbAccountType.SelectedIndex = findIndex(.AccountType)

            End With
        End If
    End Sub
    Private Function FindIndex(ByVal AccountType As String) As Integer
        Select Case AccountType
            Case "0"
                Return 0
            Case "1"
                Return 1
            Case "2"
                Return 2
            Case "3"
                Return 3
            Case "4"
                Return 4
            Case "5"
                Return 5
        End Select
    End Function
    Private Sub FillDG1()
        Dim TmpGrp As New cPrMsTemplateGroup
        TmpGrp = CType(Me.cmbTemGrp.SelectedItem, cPrMsTemplateGroup)

        dsInterfaceCodes = Global1.Business.GetAllPrMsInterfaceCodes(TmpGrp.Code)
        DG1Changing = True
        Me.DG1.DataSource = dsInterfaceCodes.Tables(0)
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
    'Private Sub TSBDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSBDelete.Click
    '    Me.TSBDelete.Enabled = False
    '    Me.Cursor = Cursors.WaitCursor()
    '    Dim Response As Integer
    '    Response = MsgBox("Are you sure you want to delete " & Me.txtCode.Text & " ?", MsgBoxStyle.OkCancel)
    '    If Response = 1 Then
    '        If tPrMsTemplateGroup.Delete(Trim(Me.txtCode.Text)) Then
    '            Me.lblSSStatus.Text = Me.txtCode.Text & " has been deleted"
    '            ClearMe()
    '            FillDG1()
    '            Me.LoadDataFromDG1(0)
    '        Else
    '            MsgBox("No deletion took place")
    '        End If
    '    End If
    '    Me.TSBDelete.Enabled = True
    '    Me.Cursor = Cursors.Default
    'End Sub
    Private Sub LoadDataFromDG1(ByVal i As Integer)
        Me.ClearMe()
        Call ClearErrors()
        If Me.DG1.RowCount > 0 Then
            Debug.WriteLine(DbNullToString(DG1.Item(0, i).Value))
            Me.txtCode.Text = DbNullToString(DG1.Item(0, i).Value)
            ' Dim TemGrp As New cPrMsTemplateGroup(Trim(DG1.Item(1, i).Value))

            'Me.cmbTemGrp.SelectedIndex = cmbTemGrp.FindStringExact(TemGrp.ToString)
            Me.txtDescriptionL.Text = DbNullToString(DG1.Item(2, i).Value)
            Me.cmbAccountType.SelectedIndex = Me.FindIndex(DbNullToString(DG1.Item(3, i).Value))

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

    Private Sub TSBMask_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBMask.ButtonClick
        Dim F As New FrmPrMsCodeMasking
        If Me.txtCode.ReadOnly Then
            F.InterfaceCode = Me.txtCode.Text
            F.Owner = Me
            F.ShowDialog()
        Else
            MsgBox("Please select Valid Code First", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cmbTemGrp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTemGrp.SelectedIndexChanged
        If Loading Then Exit Sub
        FillDG1()
    End Sub

    Private Sub DG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.DoubleClick
        Try
            Dim F As New FrmPrMsCodeMasking
            If Me.txtCode.ReadOnly Then
                F.InterfaceCode = Me.txtCode.Text
                F.Owner = Me
                F.ShowDialog()
            Else
                MsgBox("Please select Valid Code First", MsgBoxStyle.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copy.Click
        Dim F As New FrmCopyInterfaceCodesFunction
        F.DsTempGroups = dsTempGroups
        F.DsInterfaceCodes = dsInterfaceCodes
        F.ShowDialog()

    End Sub
End Class