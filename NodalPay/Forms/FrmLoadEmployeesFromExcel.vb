Public Class FrmLoadEmployeesFromExcel
    Dim Loading As Boolean = True
    Private Sub FrmLoadEmployeesFromExcel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadComboTemplate()
        LoadCombo_Bank()
        Me.LoadCombo_SIRate()
    End Sub
    Private Sub LoadComboTemplate()
        Loading = True
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPrMsTemplateGroupOfUser(Global1.UserName)
        With Me.ComboTempGroups
            .BeginUpdate()
            .Items.Clear()
            If CheckDataSet(ds) Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Dim Temp As New cPrMsTemplateGroup(ds.Tables(0).Rows(i))
                    .Items.Add(Temp)
                Next
            End If
            .EndUpdate()
            Loading = False
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub LoadCombo_Bank()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.ComboCompBank
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrAnBanks)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadCombo_SIRate()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrSsSocialInsurance()
        If CheckDataSet(ds) Then
            Dim tPrSsSocialInsurance As New cPrSsSocialInsurance
            With Me.ComboSI
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tPrSsSocialInsurance = New cPrSsSocialInsurance(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
                    .Items.Add(tPrSsSocialInsurance)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadCombo_IBAN(ByVal TempGroupCode As String)
        
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllIBANSOfTemplateGroupCode(TempGroupCode)
        If CheckDataSet(ds) Then
            With Me.comboCompanyIBAN
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    .Items.Add(ds.Tables(0).Rows(i).Item(0))
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub
    Private Sub LoadCombo_Payslips(ByVal TempGroupCode As String)

        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllPayslipsOfTemplateGroupCode(TempGroupCode)
        If CheckDataSet(ds) Then
            With Me.comboPayslip
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    .Items.Add(ds.Tables(0).Rows(i).Item(0))
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFile.FileName <> "" Then
            CType(Me.Owner, FrmMain).GLBLoadingFromExcel_TemGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code
            CType(Me.Owner, FrmMain).GLBLoadingFromExcel_CompanyBankCode = CType(Me.ComboCompBank.SelectedItem, cPrAnBanks).Code

            If Me.comboCompanyIBAN.SelectedIndex >= 0 Then
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_CompanyIBAN = Me.comboCompanyIBAN.SelectedItem.ToString
            Else
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_CompanyIBAN = ""
            End If
            If Me.comboPayslip.SelectedIndex >= 0 Then
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_PayslipReport = Me.comboPayslip.SelectedItem.ToString
            Else
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_PayslipReport = ""
            End If
            If Me.ComboSI.SelectedIndex >= 0 Then
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_SIRateCode = CType(Me.ComboSI.SelectedItem, cPrSsSocialInsurance).Code
            Else
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_SIRateCode = ""
            End If
            If Me.CBLoadAddress.CheckState = CheckState.Checked Then
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_loadaddress = True
            Else
                CType(Me.Owner, FrmMain).GLBLoadingFromExcel_loadaddress = False
            End If

            CType(Me.Owner, FrmMain).GLBProceedWithExcel_Loading = True
            CType(Me.Owner, FrmMain).GLBLoadingFromExcel_ExcelFileToOpen = OpenFile.FileName

            Me.Close()
        Else
            MsgBox("Please select valid File name to upload")
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        openfile.FileName = ""
        openfile.ShowDialog()
        Me.txtToFile.Text = openfile.FileName
    End Sub

    Private Sub ComboTempGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTempGroups.SelectedIndexChanged
        If Loading Then Exit Sub
        Dim TempGroup As String
        TempGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code
        LoadCombo_IBAN(TempGroup)
        LoadCombo_Payslips(TempGroup)

    End Sub
End Class