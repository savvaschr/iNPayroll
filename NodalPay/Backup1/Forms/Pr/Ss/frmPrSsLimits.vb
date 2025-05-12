Public Class frmPrSsLimits
    Dim tPrSsLimits As New cPrSsLimits
    Dim DG1Changing As Boolean = False
    Private Sub frmPrSsLimits_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Me.txtId.Text = "" Then
            Flag = False
            Me.ErrId.SetError(Me.txtId, "Field is Required")
        Else
            If Not IsNumeric(Me.txtId.Text) Then
                Flag = False
                Me.ErrId.SetError(Me.txtId, "Field requires a number")
            Else
                If NullToInt(Me.txtId.Text) < 0 Then
                    Flag = False
                    Me.ErrId.SetError(Me.txtId, "Field requires positive number")
                End If
            End If
        End If
        If Flag Then
            If Me.txtId.Text <> "" Then
                If Not Me.txtId.ReadOnly Then
                    Dim tPrSsLimits As New cPrSsLimits(CInt(Trim(Me.txtId.Text)))
                    If tPrSsLimits.Id <> 0 Then
                        MsgBox("Limit already exists - Record cannot be inserted", MsgBoxStyle.Critical)
                        Flag = False
                    End If
                End If
            End If
        End If
        Return Flag
    End Function
    Private Sub ClearMe()
        Me.txtId.Text = "0"
        Me.txtCola.Text = "0.00"
        Me.txtInsurableWk.Text = "0.00"
        Me.txtInsurableMth.Text = "0.00"
        Me.txtInsurableAnnual.Text = "0.00"
        Me.txtDedContrAnnual.Text = "0.00"
        Me.txtIndAnnual.Text = "0.00"
        Me.DateEffective.Value = Now
        Me.txtUnemAnnual.Text = "0.00"
        Me.txtGesiD.Text = "0.00"
        Me.txtGesiC.Text = "0.00"
    End Sub
    '
    Private Sub LoadCombos()
    End Sub
    '
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtCola.KeyPress, AddressOf NumericKeyPress
        AddHandler txtCola.Leave, AddressOf NumericOnLeave
        AddHandler txtInsurableWk.KeyPress, AddressOf NumericKeyPress
        AddHandler txtInsurableWk.Leave, AddressOf NumericOnLeave
        AddHandler txtInsurableMth.KeyPress, AddressOf NumericKeyPress
        AddHandler txtInsurableMth.Leave, AddressOf NumericOnLeave
        AddHandler txtInsurableAnnual.KeyPress, AddressOf NumericKeyPress
        AddHandler txtInsurableAnnual.Leave, AddressOf NumericOnLeave
        AddHandler txtDedContrAnnual.KeyPress, AddressOf NumericKeyPress
        AddHandler txtDedContrAnnual.Leave, AddressOf NumericOnLeave
        AddHandler txtIndAnnual.KeyPress, AddressOf NumericKeyPress
        AddHandler txtIndAnnual.Leave, AddressOf NumericOnLeave
        AddHandler txtUnemAnnual.KeyPress, AddressOf NumericKeyPress
        AddHandler txtUnemAnnual.Leave, AddressOf NumericOnLeave
        AddHandler txtGesiD.KeyPress, AddressOf NumericKeyPress
        AddHandler txtGesiD.Leave, AddressOf NumericOnLeave
        AddHandler txtGesiC.KeyPress, AddressOf NumericKeyPress
        AddHandler txtGesiC.Leave, AddressOf NumericOnLeave
    End Sub
    '
    Private Sub ClearErrors()
        Me.ErrId.SetError(Me.txtId, "")
        Me.ErrCola.SetError(Me.txtCola, "")
        Me.ErrInsurableWk.SetError(Me.txtInsurableWk, "")
        Me.ErrInsurableMth.SetError(Me.txtInsurableMth, "")
        Me.ErrInsurableAnnual.SetError(Me.txtInsurableAnnual, "")
        Me.ErrDedContrAnnual.SetError(Me.txtDedContrAnnual, "")
        Me.ErrIndAnnual.SetError(Me.txtIndAnnual, "")
        Me.ErrEffectiveDate.SetError(DateEffective, "")
        Me.ErrUnemAnnual.SetError(Me.txtUnemAnnual, "")
    End Sub
    '
    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNew.Click
        Me.TSBNew.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        tPrSsLimits = New cPrSsLimits
        ClearMe()
        ClearErrors()
        PKInputReadOnly(False)
        Me.TSBNew.Enabled = True
        Me.txtId.Focus()
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
                '  If Me.txtId.ReadOnly Then
                '       Update = True
                '  Else
                '       Update = False
                '  End If
                With tPrSsLimits
                    .Id = NullToInt(Me.txtId.Text)
                    If .Id <> 0 Then
                        If CDate(Me.DateEffective.Value.Date) <> CDate(DateEffective.Value) Then
                            .Id = 0
                        Else
                            Update = True
                        End If
                    End If
                    .Cola = CDbl(Me.txtCola.Text)
                    .InsurableWk = CDbl(Me.txtInsurableWk.Text)
                    .InsurableMth = CDbl(Me.txtInsurableMth.Text)
                    .InsurableAnnual = CDbl(Me.txtInsurableAnnual.Text)
                    .DedContrAnnual = CDbl(Me.txtDedContrAnnual.Text)
                    .IndAnnual = CDbl(Me.txtIndAnnual.Text)
                    .EffectiveDate = CDate(Me.DateEffective.Value.Date)
                    .UnemAnnual = CDbl(Me.txtUnemAnnual.Text)
                    .GesiD = CDbl(Me.txtGesiD.Text)
                    .GesiC = CDbl(Me.txtGesiC.Text)
                    If .Save() Then
                        Me.lblSSStatus.Text = "Changes are successfully Saved"
                        ' CS = Me.DG1.SelectedRows(0).Index
                        FillDG1()
                        'If DG1.Rows.Count - 1 > CS Then
                        '    DG1.CurrentCell = DG1.Rows(CS + 1).Cells(1)
                        'Else
                        '    DG1.CurrentCell = DG1.Rows(CS).Cells(1)
                        'End If
                        FindWhereToSelect(.Id)
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
        ds = Global1.Business.GetAllPrSsLimits()
        HeaderStr.Add("Id")
        HeaderStr.Add("Cola")
        HeaderStr.Add("InsurableWk")
        HeaderStr.Add("InsurableMth")
        HeaderStr.Add("InsurableAnnual")
        HeaderStr.Add("DedContrAnnual")
        HeaderStr.Add("Indastrial Annual Limit")
        HeaderStr.Add("Effective Date")
        HeaderStr.Add("Unemployment Annual Limit")
        HeaderSize.Add(15)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(18)
        HeaderSize.Add(12)
        HeaderSize.Add(18)
        Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)
    End Sub
    '
    Private Sub LoadPrSsLimits(ByVal tId As Integer)
        tPrSsLimits = New cPrSsLimits(tId)
        If tPrSsLimits.Id <> 0 Then
            With tPrSsLimits
                Me.txtId.ReadOnly = True
                Me.txtId.BackColor = SystemColors.Info
                Me.txtId.Text = CStr(.Id)
                Me.txtCola.Text = Format(.Cola, "0.00")
                Me.txtInsurableWk.Text = Format(.InsurableWk, "0.00")
                Me.txtInsurableMth.Text = Format(.InsurableMth, "0.00")
                Me.txtInsurableAnnual.Text = Format(.InsurableAnnual, "0.00")
                Me.txtDedContrAnnual.Text = Format(.DedContrAnnual, "0.00")
                Me.txtIndAnnual.Text = Format(.IndAnnual, "0.00")
                DateEffective.Value = CDate(.EffectiveDate)
                Me.txtUnemAnnual.Text = Format(.UnemAnnual, "0.00")
                Me.txtGesiD.Text = Format(.GesiD, "0.00")
                Me.txtGesiC.Text = Format(.GesiC, "0.00")

                ' Me.MakeButtonsEnabled(True)
            End With
        End If
    End Sub
    Private Sub FillDG1()
        Dim ds As DataSet
        ds = Global1.Business.GetAllPrSsLimits()
        If CheckDataSet(ds) Then
            DG1Changing = True
            Me.DG1.DataSource = ds.Tables(0)
            DG1Changing = False
            LoadDataFromDG1(0)
        Else
            MsgBox("No Data Found")
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
        Response = MsgBox("Are you sure you want to delete " & Me.txtId.Text & " ?", MsgBoxStyle.OkCancel)
        If Response = 1 Then
            If tPrSsLimits.Delete(CInt(Trim(Me.txtId.Text))) Then
                Me.lblSSStatus.Text = Me.txtId.Text & " has been deleted"
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
        Me.txtId.Text = DbNullToString(DG1.Item(0, i).Value)
        Me.txtCola.Text = DbNullToString(DG1.Item(1, i).Value)
        Me.txtInsurableWk.Text = DbNullToString(DG1.Item(2, i).Value)
        Me.txtInsurableMth.Text = DbNullToString(DG1.Item(3, i).Value)
        Me.txtInsurableAnnual.Text = DbNullToString(DG1.Item(4, i).Value)
        Me.txtDedContrAnnual.Text = DbNullToString(DG1.Item(5, i).Value)
        Me.txtIndAnnual.Text = DbNullToString(DG1.Item(6, i).Value)
        Me.txtUnemAnnual.Text = DbNullToString(DG1.Item(7, i).Value)
        Me.DateEffective.Value = DbNullToDate(DG1.Item(8, i).Value)
        Me.txtGesiD.Text = DbNullToString(DG1.Item(9, i).Value)
        Me.txtGesiC.Text = DbNullToString(DG1.Item(10, i).Value)
        PKInputReadOnly(True)
    End Sub
    Private Sub PKInputReadOnly(ByVal RO As Boolean)
        Me.txtId.ReadOnly = RO
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
