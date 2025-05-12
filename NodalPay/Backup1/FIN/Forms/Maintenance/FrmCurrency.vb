Public Class FrmCurrency
    Dim Ds As New DataSet
    Dim DsRates As New DataSet

    Private Sub FrmCurrency_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrencyCombos()
        LoadDataGridRates()
        LoadDataGrid()
        clearErrors()
        LoadDataGrid()
        InitFields()
        CreateHandlders()
    End Sub

    Private Sub CreateHandlders()
        AddHandler TxtRate.KeyPress, AddressOf Utils.NumericKeyPress
        AddHandler TxtRate.Leave, AddressOf NumericOnLeave6Decimals
        AddHandler TxtNumericCode.KeyPress, AddressOf IntegerKeyPress
        AddHandler TxtNumericCode.Leave, AddressOf IntegerOnLeave
    End Sub

    Private Sub InitFields()
        Dim User1 As New cUsers(Global1.GLBUserId)
        Me.TxtAmendBy.Text = User1.FullName
        Me.TxtCreatedBy.Text = User1.FullName
        Me.DtpAmendDate.Value = Now.Date
        Me.DtpCreatedDate.Value = Now.Date
    End Sub

    Private Sub LoadCurrencyCombos()
        Dim Ds1 As New DataSet
        Dim i As Integer
        Dim currency As New cAdMsCurrency
        Ds1 = Global1.Business.GetAllCurrencies()
        With Me.CmbAlphaCode
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(Ds1) Then
                For i = 0 To Ds1.Tables(0).Rows.Count - 1
                    currency = New cAdMsCurrency(Ds1.Tables(0).Rows(i))
                    .Items.Add(currency)
                Next
                .SelectedIndex = 0
            End If
            .EndUpdate()
        End With
        If Me.CmbAlphaCode.Items.Count > 0 Then
            Me.CmbAlphaCode.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadDataGrid()
        ds = Global1.Business.GetAllCurrencies()
        Me.DgCurrencies.DataSource = ds.Tables(0)
    End Sub

    Private Sub LoadDataGridRates()
        DsRates = Global1.Business.GetAllCurrenciesRatesByCode(CType(Me.CmbAlphaCode.SelectedItem, cAdMsCurrency).AlphaCode)
        DgCurRates.DataSource = dsRates.Tables(0)
    End Sub

    Private Function ValidateBeforeSaving() As Boolean
        clearErrors()
        Dim flag As Boolean = True
        If Me.TxtAlphaCode.Text = "" Then
            flag = False
            Er1.SetError(Me.TxtAlphaCode, "AlphaCode Field is Required")
        End If

        If Me.TxtDescription.Text = "" Then
            flag = False
            Er3.SetError(Me.TxtDescription, "Description Field is Required")
        End If

        'If Me.TxtNumericCode.Text = "" Then
        '    flag = False
        '    Er2.SetError(Me.TxtNumericCode, "NumericCode Field is Required")
        If Not IsNumeric(TxtNumericCode.Text) And Not TxtNumericCode.Text = "" Then
            flag = False
            Er2.SetError(Me.TxtNumericCode, "NumericCode Field can be only Numeric")
        End If

        Return flag
    End Function

    Private Sub clearErrors()
        Er1.SetError(Me.TxtAlphaCode, "")
        Er2.SetError(Me.TxtNumericCode, "")
        Er3.SetError(Me.TxtDescription, "")
    End Sub

    Private Sub PointLastUpdateCurrency(ByVal code As String)
        Dim i As Integer = 0
        Dim GridCode As String
        For i = 0 To DgCurrencies.RowCount - 1
            GridCode = Trim(DgCurrencies.Item(0, i).Value)
            If String.Compare(Trim(code), GridCode) = 0 Then
                DgCurrencies.Rows(0).Selected = False
                DgCurrencies.Rows(i).Selected = True
                LoadFromCurGrid(i)
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub TryToSave()

        If ValidateBeforeSaving() Then
            'na kanw allagi gia to pote mporei na fylaei ena ccurency
            Dim currency As New cAdMsCurrency(Me.TxtAlphaCode.Text)

            With currency

                If .AlphaCode <> "" And Me.TxtAlphaCode.Enabled Then
                    MsgBox("There is allready an entry with same Alphacode. Please give e new one.")
                    TxtAlphaCode.Text = ""
                    Exit Sub
                ElseIf .AlphaCode <> "" And Not Me.TxtAlphaCode.Enabled Then
                    .AlphaCode = Me.TxtAlphaCode.Text
                    .NumericCode = Me.TxtNumericCode.Text
                    .Description = Me.TxtDescription.Text
                    .Symbol = Me.TxtSymbol.Text
                    If Me.CmbIsActiveCur.SelectedIndex = 0 Then
                        .IsActive = "A"
                    Else
                        .IsActive = "I"
                    End If
                    'If .Save(False) Then
                    If .Save() Then
                        MsgBox("This entry has been succesfully updated.")
                        LoadDataGrid()
                        PointLastUpdateCurrency(.AlphaCode)
                        LoadCurrencyCombos()
                    Else
                        MsgBox("Failed to update.")
                    End If
                ElseIf .AlphaCode = "" Then
                    .AlphaCode = Me.TxtAlphaCode.Text
                    .NumericCode = Me.TxtNumericCode.Text
                    .Description = Me.TxtDescription.Text
                    .Symbol = Me.TxtSymbol.Text
                    If Me.CmbIsActiveCur.SelectedIndex = 0 Then
                        .IsActive = "A"
                    Else
                        .IsActive = "I"
                    End If
                    'If .Save(True) Then
                    If .Save() Then
                        MsgBox("This entry has been succesfully saved.")
                        LoadDataGrid()
                        PointLastUpdateCurrency(.AlphaCode)
                        LoadCurrencyCombos()
                        Me.TxtAlphaCode.Enabled = False
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
        ClearCurrenciesFields()
    End Sub

    Private Sub ClearCurrenciesFields()
        clearErrors()
        Me.TxtAlphaCode.BackColor = SystemColors.Window
        Me.TxtAlphaCode.Enabled = True
        Me.TxtAlphaCode.Text = ""
        Me.TxtNumericCode.Text = ""
        Me.TxtDescription.Text = ""
        Me.TxtSymbol.Text = ""
        Me.CmbIsActiveCur.SelectedIndex = 0
    End Sub

    Private Sub DgCurrencies_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgCurrencies.CurrentCellChanged
        Try
            clearErrors()
            ClearCurrenciesFields()
            If CheckDataSet(ds) Then
                Dim i As Integer
                i = Me.DgCurrencies.CurrentRow.Index
                LoadFromCurGrid(i)
                Me.DgCurrencies.Rows(i).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFromCurGrid(ByVal i As Integer)
        clearErrors()
        Me.TxtAlphaCode.Enabled = False
        Me.TxtAlphaCode.BackColor = SystemColors.Info

        With ds.Tables(0).Rows(i)
            Me.TxtAlphaCode.Text = DbNullToString(.Item(0))
            Me.TxtNumericCode.Text = DbNullToString(.Item(1))
            Me.TxtDescription.Text = DbNullToString(.Item(2))
            Me.TxtSymbol.Text = DbNullToString(.Item(3))
            If String.Compare(.Item(4), "A") = 0 Then
                Me.CmbIsActiveCur.SelectedIndex = 0
            Else
                Me.CmbIsActiveCur.SelectedIndex = 1
            End If
        End With
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim ds1 As New DataSet
        Dim check As Boolean
        If Me.TxtAlphaCode.Enabled = True Then
            Exit Sub
        End If
        ds1 = Global1.Business.GetAllCurrenciesRatesByCode(ds.Tables(0).Rows(DgCurrencies.CurrentRow.Index).Item(0))
        If Not CheckDataSet(ds1) Then
            check = Global1.Business.DeleteCurrency(ds.Tables(0).Rows(DgCurrencies.CurrentRow.Index).Item(0))
            If check = True Then
                MsgBox("Currency Deleted Succesfully")
                loaddatagrid()
            Else
                MsgBox("System Encounter a Problem Deleting this Entry")
            End If
        Else
            MsgBox("This currency can be deleted, cause is uesd by CurrencyRates")
        End If
    End Sub


    Private Sub ButtonNewRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewRate.Click
        RenewCurrencyRates()
    End Sub

    Private Sub RenewCurrencyRates()
        ClearCurrencyRatesFields()
    End Sub

    Private Sub ClearCurrencyRatesFields()
        clearErrorsRate()
        Me.TxtRate.Text = ""
        Me.DtpEffectiveDate.Value = Now.Date
        Dim User1 As New cUsers(Global1.GLBUserId)
        Me.DtpAmendDate.Value = Now.Date
        Me.DtpCreatedDate.Value = Now.Date
        Me.TxtAmendBy.Text = User1.FullName
        Me.TxtCreatedBy.Text = User1.FullName
        Me.DtpAmendDate.Value = Now.Date
        Me.DtpCreatedDate.Value = Now.Date
    End Sub

    Private Sub ButtonSaveRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveRate.Click
        tryToSaveCurRates()
    End Sub

    Private Function validateCurRates() As Boolean
        clearErrorsRate()
        Dim flag As Boolean = True
        flag = CheckRate()
        'If Me.TxtRate.Text = "" Then
        '    ErrRate.SetError(TxtRate, "Rate Field can be Empty")
        '    flag = False
        'ElseIf Not IsNumeric(Me.TxtRate.Text) Then
        '    ErrRate.SetError(TxtRate, "Rate Field can be only Numeric")
        '    flag = False
        'End If
        Return flag
    End Function

    Private Function CheckRate() As Boolean
        Dim Rate As String = TxtRate.Text
        If Me.TxtRate.Text = "" Then
            ErrRate.SetError(TxtRate, "Rate Field is Required")
            Return False
        ElseIf Not IsNumeric(Me.TxtRate.Text) Then
            ErrRate.SetError(TxtRate, "Rate Field can be only Numeric")
            Return False
        Else
            If TxtRate.TextLength > 3 Then
                Rate = Rate.Split(".").GetValue(0)
                If Rate.Length > 3 Then
                    ErrRate.SetError(TxtRate, "Rate Field can not be bigger than 999")
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub clearErrorsRate()
        ErrRate.SetError(Me.TxtRate, "")
    End Sub

    Private Sub PointLastUpdateCurRate(ByVal code As String, ByVal EffectiveDate As Date)
        Dim i As Integer = 0
        Dim GridCode As String
        Dim TempDate As Date
        For i = 0 To DgCurRates.RowCount - 1
            GridCode = dsRates.Tables(0).Rows(i).Item(1)
            TempDate = dsRates.Tables(0).Rows(i).Item(3)
            If String.Compare(Trim(code), GridCode) = 0 And EffectiveDate = TempDate Then
                DgCurRates.Rows(0).Selected = False
                DgCurRates.Rows(i).Selected = True
                LoadDataFromGridRates(i)
                Exit Sub
            End If
        Next i
    End Sub

    Private Sub tryToSaveCurRates()
        Dim code As String = CType(Me.CmbAlphaCode.SelectedItem, cAdMsCurrency).AlphaCode

        If Not validateCurRates() Then
            Exit Sub
        Else
            If Me.DtpEffectiveDate.Value.Date < Now.Date Then
                MsgBox("You can save or update an entry with same or bigger date than today, only.")
                Exit Sub
            End If
            'Elseif vatRates.id > 0 Then
            Dim curRates As New cAdMsCurrencyRates(code, Me.DtpEffectiveDate.Value.Date)
            With curRates
                .AlphaCode = CType(Me.CmbAlphaCode.SelectedItem, cAdMsCurrency).AlphaCode
                .Rate = Me.TxtRate.Text
                .EffectiveDate = Format(Me.DtpEffectiveDate.Value.Date, "yyyy-MM-dd")
                Dim user As New cUsers(TxtCreatedBy.Text)
                .CreatedBy = user.Id
                .AmendBy = Global1.GLBUserId
                .AmendDate = Format(Now.Date, "yyyy-MM-dd")
                If curRates.CurRte_id > 0 Then
                    .CreationDate = Format(Me.DtpCreatedDate.Value.Date, "yyyy-MM-dd")
                    If .Save Then
                        MsgBox("This Entry has been Succesfully Updated.")
                        LoadDataGridRates()
                        PointLastUpdateCurRate(.AlphaCode, .EffectiveDate)
                    Else
                        MsgBox("Unsuccesfull Update.")
                    End If
                Else
                    .CreationDate = Format(Now.Date, "yyyy-MM-dd")
                    .CreatedBy = Global1.GLBUserId
                    .AmendBy = Global1.GLBUserId
                    If .Save Then
                        MsgBox("This Entry has been Succesfully saved.")
                        LoadDataGridRates()
                        PointLastUpdateCurRate(.AlphaCode, .EffectiveDate)
                    Else
                        MsgBox("Unsuccesfull Save.")
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub CmbAlphaCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAlphaCode.SelectedIndexChanged
        loadDataGridRates()
    End Sub

    Private Sub DgCurRates_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgCurRates.CurrentCellChanged
        Try
            clearErrors()
            ClearCurrencyRatesFields()
            If CheckDataSet(dsRates) Then
                Dim i As Integer
                i = Me.DgCurRates.CurrentRow.Index
                LoadDataFromGridRates(i)
                DgCurRates.Rows(i).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadDataFromGridRates(ByVal i As Integer)
        clearErrorsRate()

        With dsRates.Tables(0).Rows(i)
            Dim User As cUsers
            Dim UserId As Integer
            Dim Cur As New cAdMsCurrency(DbNullToString(.Item(1)))

            Me.CmbAlphaCode.SelectedIndex = Me.CmbAlphaCode.FindStringExact(Cur.ToString)

            Me.TxtRate.Text = Format(DbNullToDouble(.Item(2)), "0.000000")
            Me.DtpEffectiveDate.Value = DbNullToDate(.Item(3))
            'UserId = DbNullToInt(.Item(4))
            'User = New cUsers(UserId)

            Me.TxtCreatedBy.Text = DbNullToString(.Item(8))
            Me.DtpCreatedDate.Value = DbNullToDate(.Item(5))

            'UserId = DbNullToInt(.Item(6))
            'User = New cUsers(UserId)

            Me.TxtAmendBy.Text = DbNullToString(.Item(9))
            Me.DtpAmendDate.Value = DbNullToDate(.Item(7))

        End With
    End Sub

    'Private Sub BtnDelRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRates.Click
    '    Dim check As Boolean
    '    check = Global1.Business.DeleteCurrencyRates(ds.Tables(0).Rows(DgCurrencies.CurrentRow.Index).Item(0))
    '    If check = True Then
    '        MsgBox("Currency Deleted Succesfully")
    '        renewCurrencyRates()
    '        loaddatagrid()
    '    Else
    '        MsgBox("System Encounter a Problem Deleting this Entry")
    '    End If
    'End Sub

   
    
    
End Class