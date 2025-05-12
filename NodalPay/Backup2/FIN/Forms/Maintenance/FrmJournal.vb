Public Class FrmJournal

    Dim ds As New DataSet
    Dim dsCode As New DataSet

    Private Sub Frmjournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        LoadTypeCombos()
        LoadDataGridJournalCode()
        LoadDataGrid()
        clearErrors()
        InitFields()
    End Sub

    Private Sub InitFields()
        Me.TxtTypeCode.BackColor = SystemColors.Window
        
        Me.CmbStatusCode.SelectedIndex = 0
    End Sub

    Private Sub PointLastUpdateJournalType(ByVal code As String)
        Dim i As Integer = 0
        Dim GridCode As String
        For i = 0 To DgJournalType.RowCount - 1
            GridCode = Trim(DgJournalType.Item(0, i).Value)
            If String.Compare(Trim(code), GridCode) = 0 Then
                DgJournalType.Rows(0).Selected = False
                DgJournalType.Rows(i).Selected = True
                LoadFromjournalTypeGrid(i)
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub PointLastUpdateJournalCode(ByVal code As String)
        Dim i As Integer = 0
        Dim GridCode As String
        For i = 0 To DgJournalCode.RowCount - 1
            GridCode = Trim(DgJournalCode.Item(0, i).Value)
            If String.Compare(Trim(code), GridCode) = 0 Then
                DgJournalCode.Rows(0).Selected = False
                DgJournalCode.Rows(i).Selected = True
                LoadDataFromGridJournalCode(i)
                Exit Sub
            End If
        Next i

    End Sub

    Private Sub LoadTypeCombos()
        Dim Ds As DataSet
        Dim i As Integer
        Dim JournalType As New cJournalType
        Ds = Global1.Business.GetAllJournalTypes()
        With Me.CmbTypeCode
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    JournalType = New cJournalType(Ds.Tables(0).Rows(i))
                    .Items.Add(JournalType)
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
        If CmbTypeCode.Items.Count > 0 Then
            Me.CmbTypeCode.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadDataGrid()
        ds = Global1.Business.GetAllJournalTypes()
        DgJournalType.DataSource = ds.Tables(0)
    End Sub

    Private Sub LoadDataGridJournalCode()
        Dim code As String = CType(Me.CmbTypeCode.SelectedItem, cJournalType).Code
        dsCode = Global1.Business.GetAllJournalCodeByCode(code)
        DgJournalCode.DataSource = dsCode.Tables(0)
        txtTypCodDesc.Text = DbNullToString(CType(CmbTypeCode.SelectedItem, cJournalType).Desc)
    End Sub

    Private Function ValidateBeforeSaving() As Boolean
        clearErrors()
        Dim flag As Boolean = True
        If Me.TxtTypeCode.Text = "" Then
            flag = False
            Er1.SetError(Me.TxtTypeCode, "Type Code Field is Required")
        End If

        If Me.TxtDescriptionTyp.Text = "" Then
            flag = False
            Er2.SetError(Me.TxtDescriptionTyp, "Description Field is Required")
        End If
        Return flag
    End Function

    Private Sub clearErrors()

        Er1.SetError(Me.TxtTypeCode, "")
        Er2.SetError(Me.TxtDescriptionTyp, "")
        Er3.SetError(Me.TxtCode, "")
        Er4.SetError(Me.TxtLength, "")
        Er5.SetError(Me.TxtStartNo, "")
        Er6.SetError(Me.TxtCodeDesc, "")
        Er7.SetError(Me.TxtCurrentNo, "")

    End Sub

    Private Sub TryToSave()
        clearErrors()
        If ValidateBeforeSaving() Then
            Dim JournalType As New cJournalType(Me.TxtTypeCode.Text)
            With JournalType

                If .Code <> "" And Me.TxtTypeCode.Enabled Then
                    MsgBox("There is allready an entry with same Alphacode. Please give e new one.")
                    Me.TxtTypeCode.Text = ""
                    Exit Sub
                ElseIf .Code <> "" And Not Me.TxtTypeCode.Enabled Then
                    .Code = Me.TxtTypeCode.Text
                    .Desc = Me.TxtDescriptionTyp.Text
                    If Me.CmbStatusType.SelectedIndex = 0 Then
                        .Status = "A"
                    Else
                        .Status = "I"
                    End If
                    If .Save(False) Then
                        LoadDataGrid()
                        MsgBox("This entry has been succesfully updated.")
                        PointLastUpdateJournalType(.Code)
                    Else
                        MsgBox("Failed to update.")
                    End If
                ElseIf .Code = "" Then
                    .Code = Me.TxtTypeCode.Text
                    .Desc = Me.TxtDescriptionTyp.Text

                    If Me.CmbStatusType.SelectedIndex = 0 Then
                        .Status = "A"
                    Else
                        .Status = "I"
                    End If
                    If .Save(True) Then
                        LoadDataGrid()
                        PointLastUpdateJournalType(.Code)
                        LoadTypeCombos()
                        MsgBox("This entry has been succesfully saved.")

                        Me.TxtTypeCode.Enabled = False
                    Else
                        MsgBox("Failed to save.")
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        TryToSave()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        RenewFieldsJournalType()
    End Sub

    Private Sub RenewFieldsJournalType()
        clearErrors()
        TxtTypeCode.BackColor = SystemColors.Window
        TxtTypeCode.Enabled = True
        TxtTypeCode.Text = ""
        TxtDescriptionTyp.Text = ""
        CmbStatusType.SelectedIndex = 0
    End Sub

    Private Sub DgJournalType_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgJournalType.CurrentCellChanged
        Try
            clearErrors()
            RenewFieldsJournalType()
            If CheckDataSet(ds) Then
                Dim i As Integer
                i = DgJournalType.CurrentRow.Index
                LoadFromjournalTypeGrid(i)
                DgJournalType.Rows(i).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFromjournalTypeGrid(ByVal i As Integer)
        clearErrors()
        Me.TxtTypeCode.Enabled = False
        Me.TxtTypeCode.BackColor = SystemColors.Info
        Me.TxtTypeCode.Text = Me.ds.Tables(0).Rows(i).Item(0)
        Me.TxtDescriptionTyp.Text = Me.ds.Tables(0).Rows(i).Item(1)

        If String.Compare(Me.ds.Tables(0).Rows(i).Item(2), "A") = 0 Then
            Me.CmbStatusType.SelectedIndex = 0
        Else
            Me.CmbStatusType.SelectedIndex = 1
        End If
    End Sub

    'Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
    '    Dim ds1 As New DataSet
    '    Dim check As Boolean
    '    If Me.TxtVatCode.Enabled = True Then
    '        Exit Sub
    '    End If
    '    ds1 = Global1.Business.GetAllVatRatesByCode(ds.Tables(0).Rows(DgJournalType.CurrentRow.Index).Item(0))
    '    If Not CheckDataSet(ds1) Then
    '        check = Global1.Business.DeleteVat(ds.Tables(0).Rows(DgJournalType.CurrentRow.Index).Item(0))
    '        If check = True Then
    '            MsgBox("Currency Deleted Succesfully")
    '            LoadDataGrid()
    '        Else
    '            MsgBox("System Encounter a Problem Deleting this Entry")
    '        End If
    '    Else
    '        MsgBox("This currency can be deleted, cause is being used by CurrencyRates")
    '    End If
    'End Sub


    Private Sub BtnNewCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewCode.Click
        RenewJournalCodeFields()
    End Sub

    Private Sub RenewJournalCodeFields()
        clearErrors()
        TxtCode.BackColor = SystemColors.Window
        TxtCode.Enabled = True
        Me.TxtCode.Text = ""
        Me.TxtCodeDesc.Text = ""
        Me.TxtCurrentNo.Text = ""
        Me.TxtStartNo.Text = ""
        Me.TxtCode.Text = ""
        Me.TxtLength.Text = ""
        Me.CmbStatusCode.SelectedIndex = 0
    End Sub

    Private Sub BtnSaveRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveCode.Click
        tryToSaveJournalCode()
    End Sub

    Private Function validateJournalCode()
        clearErrors()
        Dim flag As Boolean = True
        If Me.TxtCode.Text = "" Then
            flag = False
            Er3.SetError(Me.TxtCode, "Code Field is Required")
        End If
        If Me.TxtCurrentNo.Text = "" Then
            flag = False
            Er7.SetError(Me.TxtCurrentNo, "Current No Field can not be Empty")
        ElseIf Not IsNumeric(Me.TxtCurrentNo.Text) Then
            flag = False
            Er7.SetError(Me.TxtCurrentNo, "Current No Field can be only Numeric")
        End If
        If Me.TxtLength.Text = "" Then
            flag = False
            Er4.SetError(Me.TxtLength, "Length Field can not be Empty")
        ElseIf Not IsNumeric(Me.TxtLength.Text) Then
            flag = False
            Er4.SetError(Me.TxtLength, "Length Field can be only Numeric")
        End If
        If Me.TxtStartNo.Text = "" Then
            flag = False
            Er5.SetError(Me.TxtStartNo, "Start No Field can not be Empty")
        ElseIf Not IsNumeric(Me.TxtStartNo.Text) Then
            flag = False
            Er5.SetError(Me.TxtStartNo, "Start No Field can be only Numeric")
        End If
        If Me.TxtCodeDesc.Text = "" Then
            flag = False
            Er6.SetError(Me.TxtCodeDesc, "Description Field is Required")
        End If
        Return flag
    End Function

    Private Sub tryToSaveJournalCode()
        clearErrors()
        Dim code As String = Me.TxtCode.Text

        If Not validateJournalCode() Then
            Exit Sub
        Else
            Dim JournalCode As New cJournalCode(code)
            If Me.TxtCode.Enabled And JournalCode.Code <> "" Then
                MsgBox("There is allready an entry with same Code. Please give e new one.")
                Me.TxtCode.Text = ""
                Exit Sub
            End If
            With JournalCode
                If JournalCode.Code <> "" Then

                    .Code = TxtCode.Text
                    .Desc = Me.TxtCodeDesc.Text
                    .TypeCode = CType(Me.CmbTypeCode.SelectedItem, cJournalType).Code()
                    .JouNoCurrent = Me.TxtCurrentNo.Text
                    .JouNoStart = Me.TxtStartNo.Text
                    .length = Me.TxtLength.Text
                    If Me.CmbStatusCode.SelectedIndex = 0 Then
                        .Status = "A"
                    Else
                        .Status = "I"
                    End If
                    If .Save(False) Then
                        MsgBox("This Entry has been Succesfully Updated.")
                        LoadDataGridJournalCode()
                        PointLastUpdateJournalCode(.Code)
                    Else
                        MsgBox("Unsuccesfull Update.")
                    End If
                Else

                    .Code = TxtCode.Text
                    .Desc = Me.TxtCodeDesc.Text
                    .TypeCode = CType(Me.CmbTypeCode.SelectedItem, cJournalType).Code()
                    .JouNoCurrent = Me.TxtCurrentNo.Text
                    .JouNoStart = Me.TxtStartNo.Text
                    .length = Me.TxtLength.Text
                    If Me.CmbStatusCode.SelectedIndex = 0 Then
                        .Status = "A"
                    Else
                        .Status = "I"
                    End If
                    If .Save(True) Then
                        MsgBox("This Entry has been Succesfully saved.")
                        LoadDataGridJournalCode()
                        PointLastUpdateJournalCode(.Code)
                    Else
                        MsgBox("Unsuccesfull Save.")
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub CmbTypeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTypeCode.SelectedIndexChanged
        If CmbTypeCode.Items.Count > 0 Then
            LoadDataGridJournalCode()
        End If
    End Sub

    Private Sub DgJournalCode_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgJournalCode.CurrentCellChanged
        Try
            RenewJournalCodeFields()
            If CheckDataSet(dsCode) Then
                Dim i As Integer
                i = DgJournalCode.CurrentRow.Index
                LoadDataFromGridJournalCode(i)
                'DgVatRates.Rows(i).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadDataFromGridJournalCode(ByVal i As Integer)
        With dsCode.Tables(0).Rows(i)
            Dim type As New cJournalType(DbNullToString(.Item(2)))
            CmbTypeCode.SelectedIndex = CmbTypeCode.FindStringExact(type.ToString)
            txtTypCodDesc.Text = DbNullToString(type.Desc)
            TxtCode.Enabled = False
            TxtCode.BackColor = SystemColors.Info
            TxtCode.Text = DbNullToString(.Item(0))
            TxtCodeDesc.Text = DbNullToString(.Item(1))
            TxtStartNo.Text = DbNullToString(.Item(3))
            TxtCurrentNo.Text = DbNullToString(.Item(4))
            TxtLength.Text = DbNullToString(.Item(5))
            If String.Compare(DbNullToString(.Item(6)), "A") = 0 Then
                Me.CmbStatusCode.SelectedIndex = 0
            Else
                Me.CmbStatusCode.SelectedIndex = 1
            End If
        End With
    End Sub

    'Private Sub BtnDelRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelCode.Click
    '    Dim check As Boolean
    '    check = Global1.Business.DeleteVat(ds.Tables(0).Rows(DgJournalCode.CurrentRow.Index).Item(0))
    '    If check = True Then
    '        MsgBox("Currency Deleted Succesfully")
    '        RenewFieldsJournalType()
    '        LoadDataGrid()
    '    Else
    '        MsgBox("System Encounter a Problem Deleting this Entry")
    '    End If
    'End Sub
    'Private Sub test()
    '    Dim d As Double

    '    s = Format(d, "0.00")
    '    s = Format(d, "dd/MM/yyyy")
    'End Sub
End Class