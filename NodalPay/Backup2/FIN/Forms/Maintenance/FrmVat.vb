Public Class FrmVat

    Dim ds As New DataSet
    Dim dsRates As New DataSet

    Private Sub FrmCurrency_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        LoadVATCombos()
        LoadDataGridRates()
        LoadDataGrid()
        ClearErrors()
        InitFields()
    End Sub

    Private Sub InitFields()
        'Me.TxtVatCode.BackColor = SystemColors.Info
        Me.TxtVatCode.BackColor = SystemColors.Window
        Dim User1 As New cUsers(Global1.GLBUserId)
        Me.TxtAmendBy.Text = User1.FullName
        Me.TxtCreatedBy.Text = User1.FullName
        Me.DtpAmendDate.Value = Now.Date
        Me.DtpCreatedDate.Value = Now.Date
        Me.CmbIsActiveVAT.SelectedIndex = 0
        Me.CmbISActiveVATRates.SelectedIndex = 0
    End Sub

    Private Sub PointLastUpdateVAT(ByVal code As String)
        Dim i As Integer = 0
        Dim GridCode As String
        For i = 0 To DgVat.RowCount - 1
            GridCode = Trim(DgVat.Item(0, i).Value)
            If String.Compare(Trim(code), GridCode) = 0 Then
                DgVat.Rows(0).Selected = False
                DgVat.Rows(i).Selected = True
                LoadFromVatsGrid(i)
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub PointLastUpdateVATRates(ByVal code As String, ByVal EffectiveDate As Date)
        Dim i As Integer = 0
        Dim GridCode As String
        Dim TempDate As Date
        For i = 0 To DgVatRates.RowCount - 1
            GridCode = dsRates.Tables(0).Rows(i).Item(1)
            TempDate = dsRates.Tables(0).Rows(i).Item(3)
            If String.Compare(Trim(code), Trim(GridCode)) = 0 And EffectiveDate = TempDate Then
                DgVatRates.Rows(0).Selected = False
                DgVatRates.Rows(i).Selected = True
                LoadDataFromGridRates(i)
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub LoadVATCombos()
        Dim Ds As DataSet
        Dim i As Integer
        Dim vat As New cVat
        Ds = Global1.Business.GetAllVats(False)
        With Me.CmbVatCode
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(Ds) Then
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    vat = New cVat(Ds.Tables(0).Rows(i))
                    .Items.Add(vat)
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
        If CmbVatCode.Items.Count > 0 Then
            Me.CmbVatCode.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadDataGrid()
        ds = Global1.Business.GetAllVats(False)
        DgVat.DataSource = ds.Tables(0)
    End Sub

    Private Sub LoadDataGridRates()
        dsRates = Global1.Business.GetAllVatRatesByCode(CType(Me.CmbVatCode.SelectedItem, cVat).Code)
        DgVatRates.DataSource = dsRates.Tables(0)
    End Sub

    Private Function ValidateBeforeSaving() As Boolean
        clearErrors()
        Dim flag As Boolean = True
        If Me.TxtVatCode.Text = "" Then
            flag = False
            Er1.SetError(Me.TxtVatCode, "AlphaCode Field is Required")
        End If

        If Me.TxtDescription.Text = "" Then
            flag = False
            Er2.SetError(Me.TxtDescription, "Description Field is Required")
        End If
        Return flag
    End Function

    Private Sub ClearErrors()

        Er1.SetError(Me.TxtVatCode, "")
        Er2.SetError(Me.TxtDescription, "")
        Er3.SetError(Me.TxtVatRate, "")
        ErrRate.SetError(Me.TxtVatRate, "")
    End Sub

    Private Sub TryToSave()

        clearErrors()
        If ValidateBeforeSaving() Then

            Dim vat As New cVat(Me.TxtVatCode.Text)
            With vat

                If .Code <> "" And Me.TxtVatCode.Enabled Then
                    MsgBox("There is allready an entry with same Code. Please give e new one.")
                    Me.TxtVatCode.Text = ""
                    Exit Sub
                ElseIf .Code <> "" And Not Me.TxtVatCode.Enabled Then
                    .Code = Me.TxtVatCode.Text
                    .Description = Me.TxtDescription.Text
                    If Me.CmbIsActiveVAT.SelectedIndex = 0 Then
                        .IsActive = "A"
                    Else
                        .IsActive = "I"
                    End If
                    If .Save(False) Then
                        LoadDataGrid()
                        MsgBox("This entry has been succesfully updated.")
                        PointLastUpdateVAT(.Code)
                    Else
                        MsgBox("Failed to update.")
                    End If
                ElseIf .Code = "" Then
                    .Code = Me.TxtVatCode.Text
                    .Description = Me.TxtDescription.Text

                    If Me.CmbIsActiveVAT.SelectedIndex = 0 Then
                        .IsActive = "A"
                    Else
                        .IsActive = "I"
                    End If
                    If .Save(True) Then
                        LoadDataGrid()
                        PointLastUpdateVAT(.Code)
                        LoadVATCombos()
                        MsgBox("This entry has been succesfully saved.")

                        Me.TxtVatCode.Enabled = False
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
        RenewFieldsVat()
    End Sub

    Private Sub RenewFieldsVat()
        clearErrors()
        Me.TxtVatCode.BackColor = SystemColors.Window
        Me.TxtVatCode.Enabled = True
        Me.TxtVatCode.Text = ""
        Me.TxtDescription.Text = ""
        Me.CmbIsActiveVAT.SelectedIndex = 0
    End Sub

    Private Sub DgVat_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgVat.CurrentCellChanged
        Try
            ClearErrors()
            RenewFieldsVat()
            If CheckDataSet(ds) Then
                Dim i As Integer
                i = DgVat.CurrentRow.Index
                LoadFromVatsGrid(i)
                DgVat.Rows(i).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFromVatsGrid(ByVal i As Integer)
        ClearErrors()
        With ds.Tables(0).Rows(i)
            Me.TxtVatCode.Enabled = False
            Me.TxtVatCode.BackColor = SystemColors.Info
            Me.TxtVatCode.Text = DbNullToString(.Item(0))
            Me.TxtDescription.Text = DbNullToString(.Item(1))
            If String.Compare(.Item(2), "A") = 0 Then
                Me.CmbIsActiveVAT.SelectedIndex = 0
            Else
                Me.CmbIsActiveVAT.SelectedIndex = 1
            End If
        End With
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim ds1 As New DataSet
        Dim check As Boolean
        If Me.TxtVatCode.Enabled = True Then
            Exit Sub
        End If
        ds1 = Global1.Business.GetAllVatRatesByCode(ds.Tables(0).Rows(DgVat.CurrentRow.Index).Item(0))
        If Not CheckDataSet(ds1) Then
            check = Global1.Business.DeleteVat(ds.Tables(0).Rows(DgVat.CurrentRow.Index).Item(0))
            If check = True Then
                MsgBox("Currency Deleted Succesfully")
                loaddatagrid()
            Else
                MsgBox("System Encounter a Problem Deleting this Entry")
            End If
        Else
            MsgBox("This currency can be deleted, cause is being used by CurrencyRates")
        End If
    End Sub


    Private Sub BtnNewRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewRate.Click
       RenewFieldsVatRate()
    End Sub

    Public Sub RenewFieldsVatRate()
        ClearErrors()
        Me.TxtVatRate.Text = ""
        Me.DtpEffectiveDate.Value = Now.Date
        Dim User1 As New cUsers(Global1.GLBUserId)
        Me.TxtAmendBy.Text = User1.FullName
        Me.TxtCreatedBy.Text = User1.FullName
        Me.DtpAmendDate.Value = Now.Date
        Me.DtpCreatedDate.Value = Now.Date
        Me.CmbISActiveVATRates.SelectedIndex = 0
    End Sub

    Private Sub BtnSaveRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveRate.Click
        tryToSaveVATRates()
    End Sub

    Private Function ValidateVATRates()
        ClearErrors()
        Dim flag As Boolean = True
        flag = CheckRate()
        'If Me.TxtVatRate.Text = "" Then
        '    flag = False
        '    Er3.SetError(Me.TxtVatRate, "Rate Field is Required")
        'ElseIf Not IsNumeric(Me.TxtVatRate.Text) Then
        '    flag = False
        '    Er3.SetError(Me.TxtVatRate, "Rate Field can be only Numeric")
        'End If

        Return flag
    End Function

    Private Function CheckRate() As Boolean
        Dim Rate As String = TxtVatRate.Text
        If Me.TxtVatRate.Text = "" Then
            ErrRate.SetError(TxtVatRate, "Rate Field is Required")
            Return False
        ElseIf Not IsNumeric(Me.TxtVatRate.Text) Then
            Return False
            Er3.SetError(Me.TxtVatRate, "Rate Field can be only Numeric")
        ElseIf TxtVatRate.Text > 100 Then
            ErrRate.SetError(TxtVatRate, "Rate Field can not be bigger than 100")
            Return False
            'ElseIf TxtVatRate.TextLength > 3 Then
            '    Rate = Rate.Split(".").GetValue(0)
            '    If Rate.Length > 3 Then
            '        ErrRate.SetError(TxtVatRate, "Rate Field can not be bigger than 100")
            '        Return False
            '    End If
        End If
        Return True
    End Function

    Private Sub TryToSaveVATRates()
        ClearErrors()
        Dim code As String = CType(Me.CmbVatCode.SelectedItem, cVat).Code

        If Not ValidateVATRates() Then
            Exit Sub
        Else
            If Me.DtpEffectiveDate.Value.Date < Now.Date Then
                MsgBox("You can save or update an entry with same or bigger date than today, only.")
                Exit Sub
            End If
            'Elseif vatRates.id > 0 Then
            Dim vatRates As New cVatRates(code, DtpEffectiveDate.Value.Date)
            With vatRates
                .Code = CType(Me.CmbVatCode.SelectedItem, cVat).Code
                .Rate = Me.TxtVatRate.Text
                .EffectiveDate = Format(Me.DtpEffectiveDate.Value.Date, "yyyy-MM-dd")
                Dim user As New cUsers(TxtCreatedBy.Text)
                .CreatedBy = user.Id
                .Amendby = Global1.GLBUserId
                .AmendDate = Format(Now.Date, "yyyy-MM-dd")

                If Me.CmbISActiveVATRates.SelectedIndex = 0 Then
                    .IsActive = "A"
                Else
                    .IsActive = "I"
                End If
                If vatRates.id > 0 Then
                    .CreationDate = Format(Me.DtpCreatedDate.Value.Date, "yyyy-MM-dd")
                    If .Save Then
                        MsgBox("This Entry has been Succesfully Updated.")
                        LoadDataGridRates()
                        PointLastUpdateVATRates(.Code, .EffectiveDate)
                    Else
                        MsgBox("Unsuccesfull Update.")
                    End If
                Else
                    .CreationDate = Format(Now.Date, "yyyy-MM-dd")
                    .CreatedBy = Global1.GLBUserId
                    .Amendby = Global1.GLBUserId
                    If .Save Then
                        MsgBox("This Entry has been Succesfully saved.")
                        LoadDataGridRates()
                        PointLastUpdateVATRates(.Code, .EffectiveDate)
                    Else
                        MsgBox("Unsuccesfull Save.")
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub CmbAlphaCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbVatCode.SelectedIndexChanged
        LoadDataGridRates()
    End Sub

    'Private Sub DgVatRates_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgVatRates.CurrentCellChanged
    '    Try
    '        clearErrors()
    '        If CheckDataSet(dsRates) Then
    '            Dim i As Integer
    '            i = DgVatRates.CurrentRow.Index
    '            LoadDataFromGridRates()
    '            DgVatRates.Rows(i).Selected = True
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub DgVatRates_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgVatRates.SelectionChanged
        Try
            ClearErrors()
            RenewFieldsVatRate()
            If CheckDataSet(dsRates) Then
                Dim i As Integer
                i = DgVatRates.CurrentRow.Index
                LoadDataFromGridRates(i)
                'DgVatRates.Rows(i).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadDataFromGridRates(ByVal i As Integer)

        With dsRates.Tables(0).Rows(i)
            Dim vat As New cVat(DbNullToString(.Item(1)))
            Me.CmbVatCode.SelectedIndex = Me.CmbVatCode.FindStringExact(vat.ToString)
            Me.TxtVatRate.Text = Format(DbNullToDouble(.Item(2)), "0.00")
            'Me.TxtVatRate.Text = DbNullToString(.Item(2))
            Me.DtpEffectiveDate.Value = DbNullToDate(.Item(3))
            Dim y As Integer = DbNullToInt(.Item(4))
            '  Dim User3 As New cUsers(y)
            Me.TxtCreatedBy.Text = DbNullToString(.Item(10)) 'User3.FullName
            Me.DtpCreatedDate.Value = DbNullToDate(.Item(5))
            y = DbNullToInt(.Item(6))
            'Dim User4 As New cUsers(y)
            Me.TxtAmendBy.Text = DbNullToString(.Item(9)) 'User4.FullName
            Me.DtpAmendDate.Value = DbNullToDate(.Item(7))
            If String.Compare(DbNullToString(.Item(8)), "A") = 0 Then
                Me.CmbISActiveVATRates.SelectedIndex = 0
            Else
                Me.CmbISActiveVATRates.SelectedIndex = 1
            End If
        End With
    End Sub

    Private Sub BtnDelRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRates.Click
        Dim check As Boolean
        check = Global1.Business.DeleteVat(ds.Tables(0).Rows(DgVatRates.CurrentRow.Index).Item(0))
        If check = True Then
            MsgBox("Currency Deleted Succesfully")
            RenewFieldsVat()
            LoadDataGrid()
        Else
            MsgBox("System Encounter a Problem Deleting this Entry")
        End If
    End Sub

    
End Class