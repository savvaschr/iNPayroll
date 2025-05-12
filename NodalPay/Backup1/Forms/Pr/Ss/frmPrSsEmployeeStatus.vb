Public Class frmPrSsEmployeeStatus
    Dim tPrSsEmployeeStatus As New cPrSsEmployeeStatus
    Dim DG1Changing As Boolean = False
    Private Sub frmPrSsEmployeeStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtEmpSta_Code.Text = "" Then
            Flag = False
            Me.ErrEmpSta_Code.SetError(Me.txtEmpSta_Code, "Field is Required")
        End If
        If Me.txtEmpSta_DescriptionL.Text = "" Then
            Flag = False
            Me.ErrEmpSta_DescriptionL.SetError(Me.txtEmpSta_DescriptionL, "Field is Required")
        End If
        If Me.txtEmpSta_DescriptionS.Text = "" Then
            Flag = False
            Me.ErrEmpSta_DescriptionS.SetError(Me.txtEmpSta_DescriptionS, "Field is Required")
        End If
        If Flag Then
            If Me.txtEmpSta_Code.Text <> "" Then
                If Not Me.txtEmpSta_Code.ReadOnly Then
                    Dim tPrSsEmployeeStatus As New cPrSsEmployeeStatus(Trim(Me.txtEmpSta_Code.Text))
                    If tPrSsEmployeeStatus.EmpSta_Code <> "" Then
                        MsgBox("Employee Status already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtEmpSta_Code.Text = ""
        Me.txtEmpSta_DescriptionL.Text = ""
        Me.txtEmpSta_DescriptionS.Text = ""
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrEmpSta_Code.SetError(Me.txtEmpSta_Code, "")
        Me.ErrEmpSta_DescriptionL.SetError(Me.txtEmpSta_DescriptionL, "")
        Me.ErrEmpSta_DescriptionS.SetError(Me.txtEmpSta_DescriptionS, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrSsEmployeeStatus = New cPrSsEmployeeStatus
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtEmpSta_Code.Focus()
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
                '  If Me.txtEmpSta_Code.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrSsEmployeeStatus
                    .EmpSta_Code = CStr(Me.txtEmpSta_Code.Text)
                    .EmpSta_DescriptionL = CStr(Me.txtEmpSta_DescriptionL.Text)
                    .EmpSta_DescriptionS = CStr(Me.txtEmpSta_DescriptionS.Text)
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
                        FindWhereToSelect(.EmpSta_Code)
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
        ds = Global1.Business.AG_GetAllPrSsEmployeeStatus()
        HeaderStr.Add("Code")
        HeaderStr.Add("DescriptionL")
        HeaderStr.Add("DescriptionS")
        HeaderSize.Add(1)
        HeaderSize.Add(40)
        HeaderSize.Add(15)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrSsEmployeeStatus(ByVal tEmpSta_Code As String)
        tPrSsEmployeeStatus = New cPrSsEmployeeStatus(tEmpSta_Code)
        If tPrSsEmployeeStatus.EmpSta_Code <> "" Then
            With tPrSsEmployeeStatus
                Me.txtEmpSta_Code.ReadOnly = True
                Me.txtEmpSta_Code.BackColor = SystemColors.Info
                Me.txtEmpSta_Code.Text = CStr(.EmpSta_Code)
                Me.txtEmpSta_DescriptionL.Text = CStr(.EmpSta_DescriptionL)
                Me.txtEmpSta_DescriptionS.Text = CStr(.EmpSta_DescriptionS)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrSsEmployeeStatus()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtEmpSta_Code.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrSsEmployeeStatus.Delete(Trim(Me.txtEmpSta_Code.Text)) Then
                Me.lblSSStatus.Text = Me.txtEmpSta_Code.Text & " has been deleted"
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
            Me.txtEmpSta_Code.Text = DbNullToString(DG1.Item(0, i).Value)
            Me.txtEmpSta_DescriptionL.Text = DbNullToString(DG1.Item(1, i).Value)
            Me.txtEmpSta_DescriptionS.Text = DbNullToString(DG1.Item(2, i).Value)
            PKInputReadOnly(True)
        End If
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtEmpSta_Code.ReadOnly = RO
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
