Public Class frmPrAnBanks
    Dim tPrAnBanks As New cPrAnBanks
    Dim DG1Changing As Boolean = False
    Private Sub frmPrAnBanks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
    End Sub
    Public Sub FindBanks(ByVal Code As String)
        Dim i As Integer
        For i = 0 To DG1.RowCount - 1
            If DG1.Item(0, i).Value = Code Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(0)
                Me.LoadDataFromDG1(i)
                Exit For
            End If
        Next
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
        
        If Me.txtTransferCode.Text = "" Then
            ' Flag = False
            ' Me.ErrTransferCode.SetError(Me.txtTransferCode, "Field is Required")
        End If
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tPrAnBanks As New cPrAnBanks(Trim(Me.txtCode.Text))
                    If tPrAnBanks.Code <> "" Then
                        MsgBox("Bank already exists - Record cannot be inserted", MsgBoxStyle.Critical)
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
        Me.txtTransferCode.Text = ""
        Me.txtSwiftCode.Text = ""
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
        ' Me.ErrIsActive.SetError(Me.txtIsActive, "")
        Me.ErrTransferCode.SetError(Me.txtTransferCode, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrAnBanks = New cPrAnBanks
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
                If Me.txtCode.ReadOnly Then
                    Update = True
                Else
                    Update = False
                End If
                With tPrAnBanks
                    .Code = CStr(Me.txtCode.Text)
                    .DescriptionL = CStr(Me.txtDescriptionL.Text)
                    .DescriptionS = CStr(Me.txtDescriptionS.Text)
                    If Me.CBIsActive.CheckState = CheckState.Checked Then
                        .IsActive = "Y"
                    Else
                        .IsActive = "N"
                    End If
                    .TransferCode = CStr(Me.txtTransferCode.Text)
                    .SwiftCode = CStr(Me.txtSwiftCode.Text)
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
        ds = Global1.Business.AG_GetAllPrAnBanks()
        HeaderStr.Add("Code")
        HeaderStr.Add("Long Description")
        HeaderStr.Add("Short Description")
        HeaderStr.Add("Is Active")
        HeaderStr.Add("Transfer Code")
        HeaderSize.Add(12)
        HeaderSize.Add(40)
        HeaderSize.Add(15)
        HeaderSize.Add(1)
        HeaderSize.Add(20)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrAnBanks(ByVal tCode As String)
        tPrAnBanks = New cPrAnBanks(tCode)
        If tPrAnBanks.Code <> "" Then
            With tPrAnBanks
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
                Me.txtTransferCode.Text = CStr(.TransferCode)
                Me.txtSwiftCode.Text = CStr(.SwiftCode)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrAnBanks()
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
            If tPrAnBanks.Delete(Trim(Me.txtCode.Text)) Then
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
            Me.txtCode.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtDescriptionL.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtDescriptionS.Text = DbNullToString(DG1.Item(2, i).Value)
            If DbNullToString(DG1.Item(3, i).Value) = "Y" Then
                Me.CBIsActive.Checked = True
            Else
                Me.CBIsActive.Checked = False
            End If
            Me.txtTransferCode.Text = DbNullToString(DG1.Item(4, i).Value)
            Me.txtSwiftCode.Text = DbNullToString(DG1.Item(5, i).Value)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim F As New frmBankSearch
        F.owner = Me
        F.showdialog()
    End Sub
End Class
