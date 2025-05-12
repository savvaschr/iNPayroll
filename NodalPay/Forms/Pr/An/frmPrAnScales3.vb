Public Class frmPrAnScales3

    Dim tPrAnScales3 As New cPrAnScales3
    Dim DG1Changing As Boolean = False
    Private Sub frmPrAnScales3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtSc3_Code.Text = "" Then
            Flag = False
            Me.ErrSc3_Code.SetError(Me.txtSc3_Code, "Field is Required")
        End If
        If Me.txtSc3_Description.Text = "" Then
            Flag = False
            Me.ErrSc3_Description.SetError(Me.txtSc3_Description, "Field is Required")
        End If
        If Flag Then
            If Me.txtSc3_Code.Text <> "" Then
                If Not Me.txtSc3_Code.ReadOnly Then
                    Dim tPrAnScales3 As New cPrAnScales3(Trim(Me.txtSc3_Code.Text))
                    If tPrAnScales3.Sc3_Code <> "" Then
                        MsgBox("Item already exists - Can not be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtSc3_Code.Text = ""
        Me.txtSc3_Description.Text = ""
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrSc3_Code.SetError(Me.txtSc3_Code, "")
        Me.ErrSc3_Description.SetError(Me.txtSc3_Description, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrAnScales3 = New cPrAnScales3
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
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
            Dim CS As Integer
            Try
                '  If Me.txtSc1_Code.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrAnScales3
                    .Sc3_Code = CStr(Me.txtSc3_Code.Text)
                    .Sc3_Description = CStr(Me.txtSc3_Description.Text)
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        ' CS = Me.DG1.SelectedRows(0).Index
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        'DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '   DG1.CurrentCell = DG1.Rows(CS).Cells(1)
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
        ds = Global1.Business.GetAllPrAnScales1()
        HeaderStr.Add("Code")
        HeaderStr.Add("Description")
        HeaderSize.Add(20)
        HeaderSize.Add(100)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrAnScales1(ByVal tSc3_Code As String)
        tPrAnScales3 = New cPrAnScales3(tSc3_Code)
        If tPrAnScales3.Sc3_Code <> "" Then
            With tPrAnScales3
                Me.txtSc3_Code.ReadOnly = True
                Me.txtSc3_Code.BackColor = SystemColors.Info
                Me.txtSc3_Code.Text = CStr(.Sc3_Code)
                Me.txtSc3_Description.Text = CStr(.Sc3_Description)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrAnScales3()
        If CheckDataSet(ds) Then
            DG1Changing = True
            Me.DG1.DataSource = ds.Tables(0)
            DG1Changing = False
            LoadDataFromDG1(0)
        Else
            'MsgBox("No Data Found")
        End If
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtSc3_Code.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrAnScales3.Delete(Trim(Me.txtSc3_Code.Text)) Then
                Me.lblSSStatus.Text = Me.txtSc3_Code.Text & " has been deleted"
                FillDG1()
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
        Me.txtSc3_Code.Text = DbNullToString(DG1.Item(0, i).Value)
        Me.txtSc3_Description.Text = DbNullToString(DG1.Item(1, i).Value)
        PKInputReadOnly(True)
        End Sub
        Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtSc3_Code.ReadOnly = RO
    End Sub


End Class