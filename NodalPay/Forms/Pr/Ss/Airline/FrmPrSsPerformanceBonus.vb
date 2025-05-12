Public Class FrmPrSsPerformanceBonus

    Dim tprssperformancebonus As New cPrSsPerformanceBonus
    Dim DG1Changing As Boolean = False
    Dim Type1 As String = "V - Value"
    Dim Type2 As String = "P - Percentage"

    Dim Formula1 As String = "P - Percentage on Value"
    Dim Formula2 As String = "S - Percentage on Salary"
    Dim Formula3 As String = "A - Percentage on Annual Salary"




    Private Sub frmprssperformancebonus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        Initialize()
        If Global1.UserRole = Roles.NoRole Then
            Me.TSBSave.Enabled = False
        End If
        FillDG1()
    End Sub
    Private Sub LoadComboType()
        With ComboType
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(Type1)
            .Items.Add(Type2)
            .EndUpdate()
        End With
    End Sub
    Private Sub LoadComboFormula()
        With ComboFormula
            .BeginUpdate()
            .Items.Clear()
            .Items.Add(Formula1)
            .Items.Add(Formula2)
            .Items.Add(Formula3)
            .EndUpdate()
        End With
    End Sub
    Private Function Type_Values(ByVal S As String) As String
        Dim R As String = ""
        If S = type1 Then
            R = "V"
        ElseIf S = type2 Then
            R = "P"
        End If
        Return R
    End Function
    Private Function Formula_Values(ByVal S As String) As String
        Dim R As String = ""
        If S = Formula1 Then
            R = "P"
        ElseIf S = Formula2 Then
            R = "S"
        ElseIf S = Formula3 Then
            R = "A"
        End If
        Return R
    End Function
    Private Function Type_ValuesIndex(ByVal S As String) As Integer
        Dim R As Integer = 0
        If S = "V" Then
            R = 0
        ElseIf S = "P" Then
            R = "1"
        End If
        Return R
    End Function
    Private Function Formula_ValuesIndex(ByVal S As String) As Integer
        Dim R As Integer = 0
        If S = "P" Then
            R = "0"
        ElseIf S = "S" Then
            R = "1"
        ElseIf S = "A" Then
            R = "2"
        End If
        Return R
    End Function

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
        If Me.txtDesc.Text = "" Then
            Flag = False
            Me.ErrDesc.SetError(Me.txtDesc, "Field is Required")
        End If
        If Flag Then
            If Me.txtCode.Text <> "" Then
                If Not Me.txtCode.ReadOnly Then
                    Dim tprssperformancebonus As New cPrSsPerformanceBonus(Trim(Me.txtCode.Text))
                    If tprssperformancebonus.Code <> "" Then
                        MsgBox("Performance Bonus already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtCode.Text = ""
        Me.txtDesc.Text = ""
        Me.txtValue.Text = "0.00"
        Me.txtRate.Text = "0.00"
        Me.ComboType.SelectedIndex = 0
        Me.ComboFormula.SelectedIndex = 0

    End Sub
    '
    Private Sub LoadCombos()
        Me.LoadComboType()
        Me.LoadComboFormula()

    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtValue.KeyPress, AddressOf NumericKeyPress
        AddHandler txtValue.Leave, AddressOf NumericOnLeave
        AddHandler txtRate.KeyPress, AddressOf NumericKeyPress
        AddHandler txtRate.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrCode.SetError(Me.txtCode, "")
        Me.ErrDesc.SetError(Me.txtDesc, "")
        Me.ErrDedValue.SetError(Me.txtValue, "")
        Me.ErrConValue.SetError(Me.txtRate, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tprssperformancebonus = New cPrSsPerformanceBonus
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
                '  If Me.txtCode.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tprssperformancebonus
                    .Code = CStr(Me.txtCode.Text)
                    .Desc = CStr(Me.txtDesc.Text)
                    .MyValue = CDbl(Me.txtValue.Text)
                    .Rate = CDbl(Me.txtRate.Text)
                    .Type = Me.Type_Values(Me.ComboType.SelectedItem.ToString)
                    .Formula = Me.Formula_Values(Me.ComboFormula.SelectedItem.ToString)

                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        ' CS = Me.DG1.SelectedRows(0).Index
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
        ds = Global1.Business.AG_GetAllPrSsPerformanceBonus()
        HeaderStr.Add("Code")
        HeaderStr.Add("Description")
        HeaderStr.Add("Value")
        HeaderStr.Add("Rate")
        HeaderStr.Add("Type")
        HeaderStr.Add("Formula")
        HeaderSize.Add(4)
        HeaderSize.Add(40)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub Loadprssperformancebonus(ByVal tCode As String)
        tprssperformancebonus = New cPrSsPerformanceBonus(tCode)
        If tprssperformancebonus.Code <> "" Then
            With tprssperformancebonus
                Me.txtCode.ReadOnly = True
                Me.txtCode.BackColor = SystemColors.Info
                Me.txtCode.Text = CStr(.Code)
                Me.txtDesc.Text = CStr(.Desc)
                Me.txtValue.Text = Format(.MyValue, "0.00")
                Me.txtRate.Text = Format(.Rate, "0.00")
                Me.ComboType.SelectedIndex = Me.Type_ValuesIndex(.Type)
                Me.ComboFormula.SelectedIndex = Me.formula_ValuesIndex(.Formula)
                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.AG_GetAllPrSsPerformanceBonus()
        If CheckDataSet(ds) Then
            DG1Changing = True
            Me.DG1.DataSource = ds.Tables(0)
            DG1Changing = False
            LoadDataFromDG1(0)
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtCode.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tprssperformancebonus.Delete(Trim(Me.txtCode.Text)) Then
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
        Me.txtDesc.Text = DbNullToString(DG1.Item(1, i).Value)
        Me.txtValue.Text = DbNullToString(DG1.Item(2, i).Value)
        Me.txtRate.Text = DbNullToString(DG1.Item(3, i).Value)
        Me.ComboType.SelectedIndex = Me.Type_ValuesIndex(DG1.Item(4, i).Value)
        Me.ComboFormula.SelectedIndex = Me.Formula_ValuesIndex(DG1.Item(5, i).Value)
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

