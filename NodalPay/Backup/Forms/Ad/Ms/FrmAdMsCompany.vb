Public Class FrmAdMsCompany
    Dim DsCompany As DataSet
    Dim CurrentRow As Integer = -1
    Dim LoadingGrid As Boolean = False
    Public AllowAddUserMenu As Boolean = False
    Dim CurrentCompanyCode As String
    Private Sub FrmCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtId.Text = 0
        Me.Top = 0
        Me.Left = 0

        'AddHandler Me.txtCurRate.KeyPress, AddressOf Utils.NumericKeyPress
        'AddHandler Me.txtCurRate.Leave, AddressOf Utils.NumericOnLeave6Decimals

        'loadComboCurrencyMode()
        LoadCombos()
        LoadDG()

        'Security
        If Global1.UserRole = Roles.Admin Then
            ' Me.TSBNew.Enabled = True
            Me.TLSSave.Enabled = True

            'Me.TLSDelete.Enabled = True
            'Me.btnAddressSearch.Enabled = True
        Else
            ' Me.TSBNew.Enabled = False
            Me.TLSSave.Enabled = False
            'Me.TLSDelete.Enabled = False
            'Me.btnAddressSearch.Enabled = False
        End If
    End Sub
    Private Sub LoadCombos()
        LoadComboACCIdentity()
        LoadComboTICCategory()
        LoadComboTICType()
        LoadComboInterfaceAccounts()
        LoadAccountTypes()
    End Sub
    Private Sub LoadComboInterfaceAccounts()
        'Dim DsInterfaceCodes As DataSet
        'Dim i As Integer

        'With Me.ComboTSCredit
        '    .BeginUpdate()
        '    .Items.Clear()
        '    .Items.Add("")
        '    If CheckDataSet(DSInterfaceCodes) Then
        '        For i = 0 To DSInterfaceCodes.Tables(0).Rows.Count - 1
        '            Dim IntCod As New cPrMsInterfaceCodes(DSInterfaceCodes.Tables(0).Rows(i))
        '            .Items.Add(IntCod.Code)
        '        Next
        '    End If
        '    .EndUpdate()
        '    .SelectedIndex = 0
        'End With
        'With Me.ComboTSDebit
        '    .BeginUpdate()
        '    .Items.Clear()
        '    .Items.Add("")
        '    If CheckDataSet(DSInterfaceCodes) Then
        '        For i = 0 To DSInterfaceCodes.Tables(0).Rows.Count - 1
        '            Dim IntCod As New cPrMsInterfaceCodes(DSInterfaceCodes.Tables(0).Rows(i))
        '            .Items.Add(IntCod.Code)
        '        Next
        '    End If
        '    .EndUpdate()
        '    .SelectedIndex = 0
        'End With

    End Sub
    Private Sub LoadAccountTypes()
        With Me.cmbAccountType
            .BeginUpdate()
            .Items.Add(Global1.ACT_GLAccount)
            .Items.Add(Global1.ACT_Customer)
            .Items.Add(Global1.ACT_Vendor)
            .Items.Add(Global1.ACT_Bank)
            .Items.Add(Global1.ACT_FixAsset)
            .Items.Add(Global1.ACT_ICPartner)
            .EndUpdate()
            .SelectedIndex = 0
        End With
        With Me.cmbBalAccountType
            .BeginUpdate()
            .Items.Add(Global1.ACT_GLAccount)
            .Items.Add(Global1.ACT_Customer)
            .Items.Add(Global1.ACT_Vendor)
            .Items.Add(Global1.ACT_Bank)
            .Items.Add(Global1.ACT_FixAsset)
            .Items.Add(Global1.ACT_ICPartner)
            .EndUpdate()
            .selectedindex = 0
        End With

    End Sub
    Private Sub LoadComboACCIdentity()
        With Me.cmbAccIdentity
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("1 - Manager/Director")
            .Items.Add("2 - Secretary")
            .Items.Add("3 - Partner")
            .Items.Add("4 - Authorised Representative")
            .Items.Add("0 - Not Applicable")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadComboTICCategory()
        With Me.cmbTICCategory
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("1 - Company")
            .Items.Add("2 - Partnership")
            .Items.Add("3 - Individual")
            .Items.Add("0 - Not Aplicable")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadComboTICType()
        With Me.cmbTICType
            .BeginUpdate()
            .Items.Clear()
            .Items.Add("1 - The Accounts")
            .Items.Add("2 - The Invoices,Receipts,Books and Records Kept")
            .EndUpdate()
            .SelectedIndex = 0
        End With
    End Sub
    'Private Sub loadComboCurrencyMode()
    '    With Me.ComboCurMode
    '        .BeginUpdate()
    '        .Items.Clear()
    '        .Items.Add("0 - Local Currency")
    '        .Items.Add("1 - Base Currency is 1.Both are showed on Printing.")
    '        .Items.Add("2 - Base Currency is 2.Both are showed On Printing.")
    '        .Items.Add("3 - Base Currency is 2.Only 2 is showed On Printing.")
    '        .EndUpdate()
    '        .SelectedIndex = 0
    '    End With

    'End Sub



    Private Sub LoadDG()

        DsCompany = Global1.Business.GetAllCompaniesFullRow()
        DG1.DataSource = DsCompany.Tables(0)
        'lblCompanyNumRows.Text = NumRecordsDefault & DsCompany.Tables(0).Rows.Count.ToString()
    End Sub

    Private Sub DG1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellChanged
        If DG1.CurrentRow Is Nothing Then
            Exit Sub
        End If

        Me.ClearErrors()

        If DG1.CurrentRow.Index <> CurrentRow Then
            CurrentRow = DG1.CurrentRow.Index
            LoadFromGridToCell()
        End If

    End Sub

    Private Sub LoadFromGridToCell()
        If CheckDataSet(DsCompany) Then
            If DsCompany.Tables(0).Rows.Count - 1 >= CurrentRow Then
                Dim tCode As String
                tCode = DbNullToString(DsCompany.Tables(0).Rows(CurrentRow).Item(1))
                Dim C As New cAdMsCompany(tCode)


                If C.Id > 0 Then
                    With Me
                        .txtId.Text = C.Id
                        .txtCode.Text = C.Code
                        .txtDescL.Text = C.Name
                        .txtDescS.Text = C.NameShort

                        Me.txtTIC.Text = C.TIC
                        Me.txtTaxCard.Text = C.TaxCard
                        Me.txtSIRegNo.Text = C.SIRegNo
                        Me.txtCurSymbol.Text = C.CurSymbol
                        Me.txtAdr1.Text = C.Address1
                        Me.txtAdr2.Text = C.Address2
                        Me.txtAdr3.Text = C.Address3
                        Me.txtAdr4.Text = C.Address4
                        Me.txtTel1.Text = C.Tel1
                        Me.txtTel2.Text = C.Tel2
                        Me.txtFax1.Text = C.Fax1
                        Me.txtFax2.Text = C.Fax2
                        Me.txtAccountantPostCode.Text = C.AccountantPostCode
                        Me.txtAccountantPOBox.Text = C.AccountantPOBox
                        Me.txtAccountantTitle.Text = C.AccountantTitle
                        Me.txtAccTIC.Text = C.AccountantTIC
                        Me.cmbAccIdentity.SelectedIndex = FindAccIdentiryIndex(C.AccIdentity)
                        Me.cmbTICCategory.SelectedIndex = FindTICCategoryIndex(C.TICCategory)
                        Me.cmbTICType.SelectedIndex = FindTICTypeIndex(C.TICType)
                        Me.txtbankcode.Text = C.BankCode

                        Me.txtGLAnal1.Text = C.GLAnal1
                        Me.txtGLAnal2.Text = C.GLAnal2
                        Me.txtGLAnal3.Text = C.GLAnal3
                        Me.txtGLAnal4.Text = C.GLAnal4
                        Me.txtGLAnal5.Text = C.GLAnal5

                        Me.txtTimesheetsDefJob.Text = C.TSDefaultJob()

                        Me.txtSI2.Text = C.SI2
                        Me.txtSI3.Text = C.SI3
                        Me.txtSI4.Text = C.SI4
                        Me.txtSI5.Text = C.SI5
                        Me.txtbankcode2.Text = C.BankCode2
                        Me.txtbankcode3.Text = C.BankCode3
                        Me.txtbankcode4.Text = C.BankCode4


                        Me.txtTSAccount.Text = C.TSAccount
                        Me.txtTSBalAccount.Text = C.TSBalAccount

                        Me.cmbAccountType.SelectedIndex = FindIndex(C.TSAccountType)
                        Me.cmbBalAccountType.SelectedIndex = FindIndex(C.TSBalAccountType)

                        Me.Logo.Image = C.ComLogo
                        Me.Stamp.Image = C.ComStamp

                    End With
                Else
                    ClearMe()
                End If
            End If
        End If
    End Sub
    Private Function FindIndex(ByVal AccountType As String) As Integer
        Select Case AccountType
            Case "0"
                Return 0
            Case "1"
                Return 1
            Case "2"
                Return 2
            Case "3"
                Return 3
            Case "4"
                Return 4
            Case "5"
                Return 5
        End Select
    End Function

    Private Function FindAccIdentiryIndex(ByVal Value As Integer) As Integer
        Select Case Value
            Case 1
                Return 0
            Case 2
                Return 1
            Case 3
                Return 2
            Case 4
                Return 3
            Case 0
                Return 4
        End Select
    End Function
    Private Function FindTICCategoryIndex(ByVal Value As Integer) As Integer
        Select Case Value
            Case 1
                Return 0
            Case 2
                Return 1
            Case 3
                Return 2
            Case 0
                Return 3
        End Select
    End Function
    Private Function FindTICTypeIndex(ByVal Value As Integer) As Integer
        Select Case Value
            Case 1
                Return 0
            Case 2
                Return 1
        End Select
    End Function
                        
    Private Sub ClearMe()
        ClearErrors()
        With Me
            .txtId.Text = 0
            .txtCode.Text = ""
            .txtDescL.Text = ""
            .txtDescS.Text = ""
            Me.txtTIC.Text = ""
            Me.txtTaxCard.Text = ""
            Me.txtSIRegNo.Text = ""
            Me.txtCurSymbol.Text = ""
            Me.txtAccountantPostCode.Text = ""
            Me.txtAccountantPOBox.Text = ""
            Me.txtAccountantTitle.Text = ""
            Me.txtAdr1.Text = ""
            Me.txtAdr2.Text = ""
            Me.txtAdr3.Text = ""
            Me.txtAdr4.Text = ""
            Me.txtTel1.Text = ""
            Me.txtTel2.Text = ""
            Me.txtFax1.Text = ""
            Me.txtFax2.Text = ""
            Me.txtAccTIC.Text = ""
            Me.cmbAccIdentity.SelectedIndex = 0
            Me.cmbTICCategory.SelectedIndex = 0
            Me.cmbTICType.SelectedIndex = 0
            Me.txtbankcode.Text = ""
            Me.txtGLAnal1.Text = ""
            Me.txtGLAnal2.Text = ""
            Me.txtGLAnal3.Text = ""
            Me.txtGLAnal4.Text = ""
            Me.txtGLAnal5.Text = ""

            Me.txtTimesheetsDefJob.Text = ""
            Me.txtTSAccount.Text = ""
            Me.txtTSBalAccount.Text = ""
            Me.cmbAccountType.SelectedIndex = 0
            Me.cmbBalAccountType.SelectedIndex = 0

            Me.txtSI2.Text = ""
            Me.txtSI3.Text = ""
            Me.txtSI4.Text = ""
            Me.txtSI5.Text = ""
            Me.txtbankcode2.Text = ""
            Me.txtbankcode3.Text = ""
            Me.txtbankcode4.Text = ""

            Me.Logo.Image = My.Resources.Company1
            Me.Stamp.Image = My.Resources.Company1

            Me.TabControl1.SelectedTab = Me.TabPage1
            Me.txtCode.Focus()
        End With
    End Sub
    Private Sub ClearErrors()

        Er1.SetError(txtCode, "")

        Er2.SetError(txtDescL, "")


    End Sub

    Private Sub CallNew()
        ClearMe()
    End Sub

    'Private Sub CallDelete()
    '    Dim CurrentRow As Integer
    '    If DG1.RowCount > 0 Then
    '        CurrentRow = DG1.CurrentRow.Index
    '        Dim c As New cAdMsCompany(CInt(Me.txtId.Text))
    '        Dim ans As MsgBoxResult
    '        If c.Code Is Nothing Then
    '            Exit Sub
    '        End If
    '        ans = MsgBox("Are you sure you want to delete company " & c.Name.ToString() & " ?", MsgBoxStyle.YesNo)
    '        If ans = MsgBoxResult.Yes Then
    '            Dim Exx As New System.Exception
    '            'check for reference

    '            If c.Exists() Then
    '                MsgBox("Company " & c.Name.ToString() & " cannot be deleted because it is already in use.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If

    '            If Not c.Delete() Then
    '                Throw Exx
    '            End If

    '            Me.LoadDG()
    '            If DG1.RowCount > 0 Then
    '                CurrentRow = CurrentRow - 1
    '                If CurrentRow < 0 Then
    '                    CurrentRow = 0
    '                End If
    '                DG1.Rows(CurrentRow).Selected = True
    '                DG1.CurrentCell = DG1.Rows(CurrentRow).Cells(1)
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub CallSave()
        TryToSaveCompany()
    End Sub
    Private Sub TryToSaveCompany()
        If ValidateME() Then
            Dim Exx As New System.Exception

            Try

                Dim C As New cAdMsCompany(Me.txtId.Text)
                With C
                    .Id = Me.txtId.Text.Trim()
                    .Code = Me.txtCode.Text.Trim()
                    .Name = Me.txtDescL.Text.Trim()
                    .NameShort = Me.txtDescS.Text.Trim()
                    .TIC = Me.txtTIC.Text.Trim()
                    .TaxCard = Me.txtTaxCard.Text.Trim()
                    .SIRegNo = Me.txtSIRegNo.Text.Trim()
                    .CurSymbol = Me.txtCurSymbol.Text.Trim()
                    .Address1 = Me.txtAdr1.Text.Trim()
                    .Address2 = Me.txtAdr2.Text.Trim()
                    .Address3 = Me.txtAdr3.Text.Trim()
                    .Address4 = Me.txtAdr4.Text.Trim()
                    .Tel1 = Me.txtTel1.Text.Trim()
                    .Tel2 = Me.txtTel2.Text.Trim()
                    .Fax1 = Me.txtFax1.Text.Trim()
                    .Fax2 = Me.txtFax2.Text.Trim()
                    .AccountantPostCode = Me.txtAccountantPostCode.Text.Trim()
                    .AccountantPOBox = Me.txtAccountantPOBox.Text.Trim()
                    .AccountantTitle = Me.txtAccountantTitle.Text.Trim()
                    .AccountantTIC = Me.txtAccTIC.Text

                    Dim S1() As String
                    S1 = Me.cmbAccIdentity.Text.Split("-")
                    .AccIdentity = CInt(Trim(S1(0)))

                    Dim S2() As String
                    S2 = Me.cmbTICCategory.Text.Split("-")
                    .TICCategory = CInt(Trim(S2(0)))

                    Dim S3() As String
                    S3 = Me.cmbTICType.Text.Split("-")
                    .TICType = CInt(Trim(S3(0)))

                    .BankCode = Me.txtbankcode.Text
                    .GLAnal1 = Me.txtGLAnal1.Text
                    .GLAnal2 = Me.txtGLAnal2.Text
                    .GLAnal3 = Me.txtGLAnal3.Text
                    .GLAnal4 = Me.txtGLAnal4.Text
                    .GLAnal5 = Me.txtGLAnal5.Text

                    .TSAccount = Me.txtTSAccount.Text
                    .TSBalAccount = Me.txtTSBalAccount.Text
                    .TSDefaultJob = Me.txtTimesheetsDefJob.Text

                    .SI2 = Me.txtSI2.Text
                    .SI3 = Me.txtSI3.Text
                    .SI4 = Me.txtSI4.Text
                    .SI5 = Me.txtSI5.Text

                    .BankCode2 = Me.txtbankcode2.Text
                    .BankCode3 = Me.txtbankcode3.Text
                    .BankCode4 = Me.txtbankcode4.Text

                    .ComLogo = Me.Logo.Image
                    .ComStamp = Me.Stamp.Image


                    Dim A1 As String()
                    A1 = Me.cmbAccountType.Text.Split("-")
                    .TSAccountType = Trim(A1(0))

                    Dim A2 As String()
                    A2 = Me.cmbBalAccountType.Text.Split("-")
                    .TSBalAccountType = Trim(A2(0))

                    If Not .Save Then
                        Throw Exx
                    End If
                    CurrentCompanyCode = C.Code
                    MsgBox("Changes are Saved", MsgBoxStyle.Information)
                    LoadDG()

                    FindWhereToSelect(CurrentCompanyCode)

                End With
            Catch ex As Exception
                MsgBox("Unable To Save Changes", MsgBoxStyle.Critical)
                Utils.ShowException(ex)

            End Try


        End If

    End Sub
    Private Sub FindWhereToSelect(ByVal Code As String)
        Dim i As Integer
        UnsellectAll()
        For i = 0 To DsCompany.Tables(0).Rows.Count - 1
            If DbNullToString(DsCompany.Tables(0).Rows(i).Item(1)) = Code Then
                DG1.Rows(i).Selected = True
                DG1.CurrentCell = DG1.Rows(i).Cells(1)
                CurrentRow = i
                LoadFromGridToCell()
                Exit Sub
            End If
        Next
    End Sub
    Private Sub UnsellectAll()
        Dim i As Integer
        For i = 0 To DsCompany.Tables(0).Rows.Count - 1
            DG1.Rows(i).Selected = False
        Next
    End Sub
    Private Function ValidateME() As Boolean
        ClearErrors()
        Dim Flag As Boolean = True
        Dim AddressFlag As Boolean = True
        If Me.txtCode.Text = "" Then
            Er1.SetError(txtCode, "Code field is Required")
            Flag = False
        Else
            Dim C As New cAdMsCompany(txtCode.Text)
            If C.Id <> 0 Then
                If C.Id <> Me.txtId.Text Then
                    Er1.SetError(txtCode, "A Company with the Same Code Already Exists")
                    Flag = False
                End If
            End If

        End If
        If Me.txtDescL.Text = "" Then
            Er2.SetError(txtDescL, "Company Long Description Field is Required")
            Flag = False
        End If

        If Flag Then
            If Not AddressFlag Then
                MsgBox("Please Select Valid Company Address in Details Tab", MsgBoxStyle.Critical)
                Flag = False
            End If
        End If
        Return Flag
    End Function

    Private Sub btnAddressSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim F As New FrmSearchForAddress
        'F.Owner = Me
        'F.CalledBy = 1
        'F.ShowDialog()
    End Sub
    'Public Sub LoadAddressDetails(ByVal Address As cAddress)
    '    If Address.Id > 0 Then
    '        With Address
    '            Er3.SetError(Me.txtAddressCode, "")
    '            Me.txtAdrId.Text = .Id
    '            Me.txtAddressCode.Text = .Code
    '            Me.txtAdr1.Text = .A1
    '            Me.txtAdr2.Text = .A2
    '            Me.txtAdr3.Text = .A3
    '            Me.txtAdr4.Text = .A4
    '        End With
    '    End If
    'End Sub

    Private Sub TSBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CallNew()
    End Sub

    Private Sub TLSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TLSSave.Click
        CallSave()
    End Sub

    'Private Sub TLSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CallDelete()
    'End Sub

    Private Sub txtCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyUp
        If e.KeyCode = Keys.Enter Then
            ' Me.FindWhereToSelect(Me.txtCode.Text.Trim.ToString())
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim F As New FrmNewCompany
        F.ShowDialog()
        LoadDG()

    End Sub
   
    Private Sub btnCompanyUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompanyUsers.Click
        Me.AllowAddUserMenu = False
        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
            Me.AllowAddUserMenu = True
        Else
            Me.AllowAddUserMenu = False
            Dim F As New FrmCompanyUsersPassword
            F.Owner = Me
            F.ShowDialog()

        End If
        If Me.AllowAddUserMenu Then
            If Me.txtCode.Text <> "" Then
                Dim F As New FrmCompanyUsers
                F.ComCode = Me.txtCode.Text
                F.ShowDialog()
            End If
        End If
    End Sub

    Private Sub TSDeleteCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSDeleteCompany.Click
        Dim C As New cAdMsCompany(CInt(Me.txtId.Text))
        If C.Id <> 0 Then
            Dim Ans As New MsgBoxResult
            Ans = MsgBox("Do you want to Delete Company " & C.Code & " - " & C.Name, MsgBoxStyle.YesNoCancel)
            If Ans = MsgBoxResult.Yes Then
                If C.CheckForDeletion Then
                    If C.Delete(C.Code) Then
                        MsgBox("Company Deleted Succesfully", MsgBoxStyle.Information)
                        Me.LoadDG()

                    Else
                        MsgBox("Unable to Deleted company", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("There are payroll transactions for this Company, Cannot Delete Company!", MsgBoxStyle.Critical)
                End If
            End If
        Else
            MsgBox("Please select Company for Deletion", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnCreatePermitions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePermitions.Click
        If Global1.UserName = "nodal" Or Global1.UserName = "sa" Then
            If CheckDataSet(DsCompany) Then
                Dim i As Integer
                Dim CompanyCode As String
                For i = 0 To DsCompany.Tables(0).Rows.Count - 1
                    CompanyCode = DbNullToString(DsCompany.Tables(0).Rows(i).Item(0))
                    Dim F As New FrmCompanyUsers
                    F.ComCode = Me.txtCode.Text
                    F.AssignUserPermitions()
                Next
            End If
            MsgBox("Process has Finish", MsgBoxStyle.Information)
        Else
            MsgBox("You do not have permitions to perform this Action", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TSBExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBExcel.Click
        Me.TSBExcel.Enabled = False
        Me.Cursor = Cursors.WaitCursor()
        Call LoadDataSetToExcel()
        Me.TSBExcel.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadDataSetToExcel()

        Dim HeaderStr As New ArrayList
        Dim HeaderSize As New ArrayList
        Dim Loader As New cExcelLoader


        HeaderStr.Add("ID")
        HeaderStr.Add("Code")
        HeaderStr.Add("Name")
        HeaderStr.Add("NameS")
        HeaderStr.Add("TIC")
        HeaderStr.Add("TaxCard")
        HeaderStr.Add("SIRegNo")
        HeaderStr.Add("CurSymbol")
        HeaderStr.Add("Address1")
        HeaderStr.Add("Address2")
        HeaderStr.Add("Address3")
        HeaderStr.Add("Address4")
        HeaderStr.Add("Tel1")
        HeaderStr.Add("Tel2")
        HeaderStr.Add("Fax1")
        HeaderStr.Add("Fax2")
        HeaderStr.Add("AccountantPostCode")
        HeaderStr.Add("AccountantPOBox")
        HeaderStr.Add("AccountantTitle")
        HeaderStr.Add("AccTIC")
        HeaderStr.Add("AccIdentity")
        HeaderStr.Add("TICCategory")
        HeaderStr.Add("TICType ")
        HeaderStr.Add("BankCode ")
        HeaderStr.Add("GLAnal1")
        HeaderStr.Add("GLAnal2")
        HeaderStr.Add("GLAnal3")
        HeaderStr.Add("GLAnal4")
        HeaderStr.Add("GLAnal5")
        HeaderStr.Add("TSAccount ")
        HeaderStr.Add("TSAccountType")
        HeaderStr.Add("TSBalAccount")
        HeaderStr.Add("TSBalAccountType")
        HeaderStr.Add("TSDefaultJob")
        HeaderStr.Add("SI2")
        HeaderStr.Add("SI3")
        HeaderStr.Add("SI4")
        HeaderStr.Add("SI5")
        HeaderStr.Add("BankCode2")
        HeaderStr.Add("BankCode3")
        HeaderStr.Add("BankCode4")

        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)
        HeaderSize.Add(20)

        Loader.LoadIntoExcel(DsCompany, HeaderStr, HeaderSize)
    End Sub

    Private Sub PayslipsPerCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayslipsPerCompanyToolStripMenuItem.Click
        Dim F As New FrmPayslipPerCompany
        F.CompanyCode = "All"
        F.CompanyTotals = True
        F.ShowDialog()
    End Sub

    Private Sub PayslipsOfSelectedCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayslipsOfSelectedCompanyToolStripMenuItem.Click
        Dim C As New cAdMsCompany(CInt(Me.txtId.Text))
        Dim F As New FrmPayslipPerCompany
        F.CompanyCode = c.code
        F.CompanyTotals = False
        F.ShowDialog()
    End Sub

    
    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        Me.AllowAddUserMenu = False
        If UCase(Global1.UserName) = "SA" Or UCase(Global1.UserName) = "NODAL" Or UCase(Global1.UserName) = "INSOFT" Then
            Me.AllowAddUserMenu = True
        Else
            Me.AllowAddUserMenu = False
            Dim F As New FrmCompanyUsersPassword
            F.Owner = Me
            F.ShowDialog()

        End If
        If Me.AllowAddUserMenu Then
            If Me.txtCode.Text <> "" Then
                Dim F As New FrmCopyUser
                F.ComCode = Me.txtCode.Text
                F.ShowDialog()
            End If
        End If
       
    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Logo.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRemove.Click
        Logo.Image = My.Resources.Company1

    End Sub

    Private Sub UsersPerCompanyForSpecificYearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersPerCompanyForSpecificYearToolStripMenuItem.Click
        Dim Ds As DataSet

        Dim Year As String = InputBox("Please enter Year:")
        If Year <> "" Then
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            Ds = Global1.Business.GetUserCompanies(Year)
            If CheckDataSet(Ds) Then
            Else
                MsgBox("No Data found", MsgBoxStyle.Information)
            End If
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        Else
            MsgBox("No Data found", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Browse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse2.Click

        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Stamp.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRemove2.Click
        Stamp.Image = My.Resources.Company1
    End Sub
End Class