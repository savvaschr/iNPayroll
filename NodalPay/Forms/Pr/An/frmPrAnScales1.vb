Public Class frmPrAnScales1
    Dim tPrAnScales1 As New cPrAnScales1
    Dim DG1Changing As Boolean = False
    Private Sub frmPrAnScales1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtSc1_Code.Text = "" Then
            Flag = False
            Me.ErrSc1_Code.SetError(Me.txtSc1_Code, "Field is Required")
        End If
        If Me.txtSc1_Description.Text = "" Then
            Flag = False
            Me.ErrSc1_Description.SetError(Me.txtSc1_Description, "Field is Required")
        End If
        If Flag Then
            If Me.txtSc1_Code.Text <> "" Then
                If Not Me.txtSc1_Code.ReadOnly Then
                    Dim tPrAnScales1 As New cPrAnScales1(Trim(Me.txtSc1_Code.Text))
                    If tPrAnScales1.Sc1_Code <> "" Then
                        MsgBox("Item already exists - Can not be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtSc1_Code.Text = ""
        Me.txtSc1_Description.Text = ""
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrSc1_Code.SetError(Me.txtSc1_Code, "")
        Me.ErrSc1_Description.SetError(Me.txtSc1_Description, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrAnScales1 = New cPrAnScales1
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
                With tPrAnScales1
                    .Sc1_Code = CStr(Me.txtSc1_Code.Text)
                    .Sc1_Description = CStr(Me.txtSc1_Description.Text)
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
    Private Sub LoadPrAnScales1(ByVal tSc1_Code As String)
        tPrAnScales1 = New cPrAnScales1(tSc1_Code)
        If tPrAnScales1.Sc1_Code <> "" Then
            With tPrAnScales1
                Me.txtSc1_Code.ReadOnly = True
                Me.txtSc1_Code.BackColor = SystemColors.Info
                Me.txtSc1_Code.Text = CStr(.Sc1_Code)
                Me.txtSc1_Description.Text = CStr(.Sc1_Description)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrAnScales1()
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtSc1_Code.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrAnScales1.Delete(Trim(Me.txtSc1_Code.Text)) Then
                Me.lblSSStatus.Text = Me.txtSc1_Code.Text & " has been deleted"
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
        Me.txtSc1_Code.Text = DbNullToString(DG1.Item(0, i).Value)
        Me.txtSc1_Description.Text = DbNullToString(DG1.Item(1, i).Value)
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtSc1_Code.ReadOnly = RO
    End Sub
End Class
