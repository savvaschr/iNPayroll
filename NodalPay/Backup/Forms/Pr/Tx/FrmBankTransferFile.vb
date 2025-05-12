Public Class FrmBankTransferFile
    Public Period As cPrMsPeriodCodes
    Public TemGrp As cPrMsTemplateGroup

    Public GLBAnalysis As String
    Public GLBAnalysisCode As String

    Dim InitFile As Boolean = True
    Dim BankFiledir As String
    Dim Loading As Boolean = True
    Dim XMLGlobalFileName As String = ""
    Public DsSelection As DataSet
    Public RunSelection = False
    Public HellenicToOther As Boolean = False


    Private Sub FrmBankTransferFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loading = True
        LoadAdMsCompany()
        LoadPrAnBanks()
        Me.LoadComboOnlyBank()

        Dim Ds As DataSet
        Ds = Global1.Business.GetParameter("Bank", "ExportFileDir")
        If CheckDataSet(Ds) Then
            Dim Par As New cPrSsParameters(Ds.Tables(0).Rows(0))
            BankFiledir = Replace(Par.Value1, "$", Global1.GLBUserCode)
        Else
            MsgBox("Missing Bank File Parameter Section 'Bank' Item 'ExportFileDir'", MsgBoxStyle.Critical)
            Me.Button1.Enabled = False
        End If

        Try
            Dim tComp As New cAdMsCompany(TemGrp.CompanyCode)
            Me.CmbCompany.SelectedIndex = Me.CmbCompany.FindStringExact(tComp.Tostring)

            LoadBankFileCodes()

        Catch ex As Exception

        End Try

        Try
            LoadBankAccounts()
        Catch ex As Exception

        End Try



        'Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        'If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        '    Dim FileName As String = OpenFileDialog.FileName
        '    ' TODO: Add code here to open the file.
        'End If
        Loading = False
        PutDecimalValidationOnTxts()
    End Sub
    Private Sub PutDecimalValidationOnTxts()
        AddHandler txtLimitPerEmployee.KeyPress, AddressOf NumericKeyPress
        AddHandler txtLimitPerEmployee.Leave, AddressOf NumericOnLeave
    End Sub
    Private Sub LoadAdMsCompany()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.GetAllAdMsCompanyOfUser(Global1.UserName)
        If CheckDataSet(ds) Then
            Dim tComp As New cAdMsCompany
            With Me.CmbCompany
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tComp = New cAdMsCompany(ds.Tables(0).Rows(i))
                    .Items.Add(tComp)
                Next i
                ' .ValueMember = "Bnk_Code"
                .SelectedIndex = 0
                .EndUpdate()
            End With
        End If
        Try
            LoadBankFileCodes()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadPrAnBanks()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.cmbBnk_CodeCo
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

    Private Sub LoadComboOnlyBank()
        Dim ds As DataSet
        Dim i As Integer
        ds = Global1.Business.AG_GetAllPrAnBanks()
        If CheckDataSet(ds) Then
            Dim tPrAnBanks As New cPrAnBanks
            With Me.ComboOnlyBank
                .BeginUpdate()
                .Items.Clear()
                .Items.Add("ALL BANKS")
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Bank As cPrAnBanks
        Dim FileBankCode As String

        Bank = Me.cmbBnk_CodeCo.SelectedItem

        If Me.ComboBankFileCode.Items.Count = 0 Then
            MsgBox("Bank file Code is missing,Please add it on Company Record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        FileBankCode = Me.ComboBankFileCode.SelectedItem

        Dim EmployeeBankCode As String = ""
        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If

        If Bank.Code = "BOC" Then
            If Me.CBConsolidate.CheckState = CheckState.Checked Then
                Dim DaysBack As Integer
                If Me.txtDaysDiff.Text = "0" Or Me.txtDaysDiff.Text = "" Then
                    DaysBack = 0
                    'CreateBankFile_BOCConsolidate(Bank, "", 0, False, False)
                    CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
                    CorvertBankFileToXML(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
                Else
                    DaysBack = Me.txtDaysDiff.Text
                    'CreateBankFile_BOCConsolidate(Bank, "", 0, True, True)
                    'CreateBankFile_BOCConsolidate(Bank, "TRANSASCI2.TXT", DaysBack, True, False)
                    CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, True, True, FileBankCode, False, EmployeeBankCode)
                    CorvertBankFileToXML(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
                    CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6_D1001.txt", DaysBack, True, False, FileBankCode, False, EmployeeBankCode)
                    CorvertBankFileToXML(BankFiledir & "DPS002DCI6_D1001.txt", BankFiledir, True, False)

                End If
            Else
                'CreateBankFile_BOC(Bank)
                CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
                CorvertBankFileToXML(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
            End If

        ElseIf Bank.Code = "MARFIN" Then
            If Me.CBAutopay.CheckState = CheckState.Unchecked Then
                CreateBankFile_MARFIN(Bank, FileBankCode, EmployeeBankCode)
                CorvertBankFileToXML(BankFiledir & "TRANASCI.TXT", BankFiledir, False, False)
            ElseIf CBAutopay.CheckState = CheckState.Checked Then
                Me.CreateBankFile_MARFINAutopay(Bank, FileBankCode, EmployeeBankCode)
                CorvertBankFileToXML(BankFiledir & "TRANASCI.TXT", BankFiledir, False, False)
            End If
            'CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False)
        ElseIf Bank.Code = "HELLENIC" Then
            HellenicToOther = True

            Me.CreateBankFile_HELLENICToOtherBanks(Bank, FileBankCode, EmployeeBankCode)
            CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
            CorvertBankFileToXML(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)

            HellenicToOther = False

        ElseIf Bank.Code = "EUROBANK" Or Bank.Code = "EURO" Then
            CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, True, EmployeeBankCode)
            CorvertBankFileToXML(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, True)
        ElseIf Bank.Code = "RCB" Then
            CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
            CorvertBankFileToXML_RCB(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
        ElseIf Bank.Code = "ASTRO" Then
            CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
            CorvertBankFileToXML_ASTRO(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
        Else
            CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
            CorvertBankFileToXML(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
        End If



        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' UNIVERSAL BANK FILE ------- START
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'If Me.CBConsolidate.CheckState = CheckState.Checked Then
        '    Dim DaysBack As Integer
        '    If Me.txtDaysDiff.Text = "0" Or Me.txtDaysDiff.Text = "" Then
        '        DaysBack = 0
        '        CreateUniversalBankFile_Consolidate(Bank, "", 0, False, False)
        '    Else
        '        DaysBack = Me.txtDaysDiff.Text
        '        CreateUniversalBankFile_Consolidate(Bank, "", 0, True, True)
        '        CreateUniversalBankFile_Consolidate(Bank, "TRANSASCI2.TXT", DaysBack, True, False)

        '    End If
        'Else
        '    CreateUniversalBankFile(Bank)
        'End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' UNIVERSAL BANK FILE ------- END
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



    End Sub
    'Private Sub CreateUniversalBankFile1(ByVal Bank As cPrAnBanks, ByVal FileBankCode As String, ByVal EmployeeBankCode As String)
    '    InitFile = True
    '    Dim Ds As DataSet

    '    Dim CompanyBankAcc As String

    '    CompanyBankAcc = Me.ComboBankAcc.Text
    '    Dim i As Integer
    '    Dim TotalDebitAmount As Double = 0


    '    Dim Includeinactive As Boolean = False
    '    If Me.CBInactive.CheckState = CheckState.Checked Then
    '        Includeinactive = True
    '    End If
    '    Dim Count As Integer
    '    Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayed(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
    '    If CheckDataSet(Ds) Then
    '        For i = 0 To Ds.Tables(0).Rows.Count - 1
    '            With Ds.Tables(0).Rows(i)
    '                TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))

    '            End With
    '        Next
    '        Dim AmountS As String
    '        Dim Comp As New cAdMsCompany
    '        Dim CompDesc As String
    '        Comp = Me.CmbCompany.SelectedItem
    '        CompDesc = Comp.Name
    '        If CompDesc.Length > 70 Then
    '            CompDesc = CompDesc.Substring(0, 69)
    '        End If
    '        Dim Header As String = ""
    '        Dim Trailer As String = ""
    '        Dim SHT As String = ""
    '        Dim CompIBAN As String
    '        CompIBAN = Me.ComboBankAcc.Text

    '        'Define Header/Trailer
    '        If FileBankCode = "" Then
    '            MsgBox("company Bank Code is Missing cannot Proceed")
    '            Exit Sub
    '        End If
    '        SHT = "01"
    '        SHT = SHT & FileBankCode.PadLeft(5, "0")
    '        SHT = SHT & CompDesc.PadLeft(70, " ")
    '        SHT = SHT & CompIBAN.PadLeft(34, " ")
    '        SHT = SHT & Format(DatePay.Value.Date, "ddMMyyyy")
    '        SHT = SHT & "".PadLeft(381)
    '        WriteToBankFile(SHT, "")


    '        'Define Lines
    '        Dim Line As String = ""
    '        Dim Bnk As New cPrAnBanks
    '        Dim BankAcc As String
    '        Dim BankAccNoDash As String
    '        Dim Salary As Double
    '        Dim EmpName As String
    '        Dim EmpCode As String
    '        Dim BankSwift As String = ""
    '        Dim EmpId As String
    '        'Dim Count As Integer
    '        Dim DetailsOfTransfer As String
    '        DetailsOfTransfer = "SALARY FOR " & Period.DescriptionL & " " & Period.DateFrom.Year
    '        Dim IBAN As String = ""

    '        Count = 0
    '        For i = 0 To Ds.Tables(0).Rows.Count - 1
    '            With Ds.Tables(0).Rows(i)
    '                EmpCode = DbNullToString(.Item(0))
    '                Salary = DbNullToDouble(.Item(1))
    '                EmpName = DbNullToString(.Item(2))
    '                Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
    '                BankAcc = DbNullToString(.Item(4))
    '                BankAccNoDash = BankAcc.Replace("-", "")
    '                BankAccNoDash = BankAccNoDash.Replace(" ", "")
    '                IBAN = DbNullToString(.Item(8))

    '                Dim SwiftCode As String

    '                SwiftCode = FindSwiftCode(Bnk)


    '                If BankAccNoDash.Length > 13 Then
    '                    MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
    '                    Exit Sub
    '                End If
    '                If EmpName.Length > 35 Then
    '                    EmpName = EmpName.Substring(1, 35)
    '                End If

    '                ' BankSwift = FindEmployeeBankSwift(Bnk)

    '                Line = "02"
    '                Line = Line & "EUR"
    '                AmountS = Format(Salary, "0.00")
    '                Line = Line & AmountS.Replace(".", "").ToString.PadLeft(15, "0")
    '                Line = Line & SwiftCode.PadLeft(11, "0")
    '                Line = Line & IBAN.PadLeft(34, " ")
    '                Line = Line & EmpName.PadRight(70, " ")
    '                Line = Line & "SALA"
    '                Line = Line & "CY"
    '                Line = Line & DetailsOfTransfer.PadLeft(140, " ")
    '                Line = Line & "".PadLeft(35, " ")
    '                Line = Line & "".PadLeft(184, " ")

    '                WriteToBankFile(Line, "")
    '                Count = Count + 1


    '            End With
    '        Next



    '        SHT = "03"
    '        SHT = SHT & FileBankCode.PadLeft(5, "0")
    '        SHT = SHT & CompDesc.PadLeft(70, " ")
    '        SHT = SHT & CompIBAN.PadLeft(34, " ")
    '        SHT = SHT & Format(DatePay.Value.Date, "ddMMyyyy")
    '        SHT = SHT & Count.ToString.PadLeft(6, "0")
    '        AmountS = Format(TotalDebitAmount, "0.00")
    '        SHT = SHT & AmountS.Replace(".", "").ToString.PadLeft(15, "0")
    '        SHT = SHT & "".PadLeft(360)
    '        WriteToBankFile(SHT, "")

    '        MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
    '    Else
    '        MsgBox("No data to Send", MsgBoxStyle.Information)
    '    End If

    'End Sub
    Private Function CreateUniversalBankFile_Consolidate(ByVal Bank As cPrAnBanks, ByVal BankFilename As String, ByVal DaysBack As Integer, ByVal Create2Files As Boolean, ByVal ThisIsCompanyBankFile As Boolean, ByVal FileBankCode As String, ByVal IsEurobank As Boolean, ByVal EmployeeBankCode As String) As String
        InitFile = True
        Dim Ds As DataSet

        Dim CompanyBankAcc As String

        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim i As Integer
        Dim TotalDebitAmount As Double = 0


        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim Count As Integer
        If Create2Files Then
            Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, Create2Files, ThisIsCompanyBankFile, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        Else
            Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, Create2Files, ThisIsCompanyBankFile, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        End If

        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = Ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To Ds.Tables(0).Rows.Count - 1
                        Ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To Ds.Tables(0).Rows.Count - 1
                        Ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If

        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    If DbNullToString(.Item(11)) = "1" Then
                        TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))
                        Count = Count + 1
                    End If
                End With
            Next
            Dim AmountS As String
            Dim Comp As New cAdMsCompany
            Dim CompDesc As String
            Comp = Me.CmbCompany.SelectedItem
            CompDesc = Comp.Name
            If CompDesc.Length > 30 Then
                CompDesc = CompDesc.Substring(0, 29)
            End If
            Dim Header As String = ""
            Dim Trailer As String = ""
            Dim SHT As String = ""
            Dim CompIBAN As String
            CompIBAN = Me.ComboBankAcc.Text

            'Define Header/Trailer
            If FileBankCode = "" Then
                MsgBox("company Bank Code is Missing cannot Proceed")
                Exit Function
            End If
            SHT = "01"
            If IsEurobank Then
                SHT = SHT & ("00" & FileBankCode).PadLeft(5, "0")
            Else
                SHT = SHT & ("D1" & FileBankCode).PadLeft(5, "0")
            End If
            SHT = SHT & CompDesc.PadRight(70, " ")
            SHT = SHT & CompIBAN.PadRight(34, " ")
            Dim D As Date = DatePay.Value
            If Create2Files Then
                If Not ThisIsCompanyBankFile Then
                    D = DateAdd(DateInterval.Day, -DaysBack, D)
                End If
            End If
            SHT = SHT & Format(D, "ddMMyyyy")
            SHT = SHT & "".PadLeft(381)


            'Addition for Eurobank (G4shift) 22/10/2019
            'If IsEurobank Then
            '    Dim Bank1 As New cPrAnBanks
            '    Bank1 = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks)
            '    Dim SwiftCode As String
            '    SwiftCode = FindSwiftCode(Bank1, IsEurobank)
            '    SHT = SHT & SwiftCode
            'End If
            ' End of Addition
            WriteToBankFile(SHT, BankFilename)


            'Define Lines
            Dim Line As String = ""
            Dim Bnk As New cPrAnBanks
            Dim BankAcc As String
            Dim BankAccNoDash As String
            Dim Salary As Double
            Dim EmpName As String
            Dim EmpCode As String
            Dim BankSwift As String = ""
            Dim EmpId As String
            Dim BankBenName As String = ""
            'Dim Count As Integer
            Dim DetailsOfTransfer As String
            DetailsOfTransfer = "PAYROLL " & Period.DescriptionL & " " & Period.DateFrom.Year


            Dim IBAN As String = ""
            Count = 0
            Dim ii As Integer
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                
                With Ds.Tables(0).Rows(i)
                    If DbNullToString(.Item(11)) = "1" Then
                       

                        EmpCode = DbNullToString(.Item(0))
                        Salary = DbNullToDouble(.Item(1))
                        EmpName = DbNullToString(.Item(2))
                        Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
                        BankAcc = DbNullToString(.Item(4))
                        BankAccNoDash = BankAcc.Replace("-", "")
                        BankAccNoDash = BankAccNoDash.Replace(" ", "")
                        IBAN = DbNullToString(.Item(8))
                        BankBenName = DbNullToString(.Item(10))


                        Dim SwiftCode As String

                        SwiftCode = FindSwiftCode(Bnk, IsEurobank)

                        If BankAccNoDash.Length > 13 Then
                            MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
                            Exit Function
                        End If
                        If EmpName.Length > 35 Then
                            EmpName = EmpName.Substring(1, 35)
                        End If
                        'BankSwift = FindEmployeeBankSwift(Bnk)
                        Dim ContinueWithNormal As Boolean = True

                        Dim MyLimit As Double = 0
                        If IsEurobank Then
                            MyLimit = Me.txtLimitPerEmployee.Text
                            If MyLimit <> 0 Then
                                Salary = DbNullToDouble(.Item(1))
                                If Salary > Me.txtLimitPerEmployee.Text Then
                                    ContinueWithNormal = False
                                End If
                            End If
                        End If

                        If Not ContinueWithNormal Then
                            Dim XSalary As Double
                            XSalary = Salary
                            Do While XSalary > 0
                                If XSalary > MyLimit Then
                                    Salary = MyLimit
                                    XSalary = XSalary - MyLimit
                                    If XSalary < 0 Then
                                        XSalary = 0
                                    End If
                                Else
                                    Salary = XSalary
                                    XSalary = 0
                                End If
                                Line = "02"
                                Line = Line & "EUR"
                                AmountS = Format(Salary, "0.00")
                                Line = Line & AmountS.Replace(".", "").ToString.PadLeft(15, "0")
                                Line = Line & SwiftCode.PadLeft(11, "0")
                                Line = Line & IBAN.PadRight(34, " ")
                                If BankBenName <> "" Then
                                    EmpName = BankBenName
                                End If
                                Line = Line & EmpName.PadRight(70, " ")
                                Line = Line & "SALA"
                                Line = Line & "CY"
                                Line = Line & DetailsOfTransfer.PadRight(140, " ")
                                Line = Line & "".PadLeft(35, " ")
                                Line = Line & "".PadLeft(184, " ")
                                WriteToBankFile(Line, BankFilename)
                                Count = Count + 1
                            Loop
                        Else
                            Line = "02"
                            Line = Line & "EUR"
                            AmountS = Format(Salary, "0.00")
                            Line = Line & AmountS.Replace(".", "").ToString.PadLeft(15, "0")
                            Line = Line & SwiftCode.PadLeft(11, "0")
                            Line = Line & IBAN.PadRight(34, " ")
                            If BankBenName <> "" Then
                                EmpName = BankBenName
                            End If
                            Line = Line & EmpName.PadRight(70, " ")
                            Line = Line & "SALA"
                            Line = Line & "CY"
                            Line = Line & DetailsOfTransfer.PadRight(140, " ")
                            Line = Line & "".PadLeft(35, " ")
                            Line = Line & "".PadLeft(184, " ")
                            WriteToBankFile(Line, BankFilename)

                            Count = Count + 1
                        End If

                    End If
                End With
            Next



            SHT = "03"
            If IsEurobank Then
                SHT = SHT & ("00" & FileBankCode).PadLeft(5, "0")
            Else
                SHT = SHT & ("D1" & FileBankCode).PadLeft(5, "0")
            End If
            SHT = SHT & CompDesc.PadRight(70, " ")
            SHT = SHT & CompIBAN.PadRight(34, " ")
            Dim D2 As Date = DatePay.Value
            If Create2Files Then
                If Not ThisIsCompanyBankFile Then
                    D = DateAdd(DateInterval.Day, -DaysBack, D)
                End If
            End If
            SHT = SHT & Format(D, "ddMMyyyy")
            'SHT = SHT & Format(DatePay.Value.Date, "ddMMyyyy")
            SHT = SHT & Count.ToString.PadLeft(6, "0")
            AmountS = Format(TotalDebitAmount, "0.00")
            SHT = SHT & AmountS.Replace(".", "").ToString.PadLeft(15, "0")
            SHT = SHT & "".PadLeft(360)
            WriteToBankFile(SHT, BankFilename)

            If BankFilename = "" Then
                MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
            Else
                MsgBox("File " & BankFiledir & BankFilename & " Is Created ", MsgBoxStyle.Information)
            End If

        Else
            MsgBox("No data to Send", MsgBoxStyle.Information)
        End If

    End Function
    Private Function FindSwiftCode(ByVal Bank As cPrAnBanks, Optional ByVal IsEurobank As Boolean = False) As String


        Dim S As String = ""
        If Trim(Bank.SwiftCode) <> "" Then
            S = Trim(Bank.SwiftCode)
        Else
            Select Case Bank.TransferCode
                Case "01"
                    S = "CBCYCY2NXXX"
                Case "02"
                    S = "BCYPCY2NXXX"
                Case "03"
                    S = "LIKICY2NXXX"
                Case "05"
                    S = "HEBACY2NXXX"
                Case "06"
                    S = "ETHNCY2NXXX"
                Case "07"
                    S = "CCBKCY2NXXX"
                Case "08"
                    S = "PIRBCY2NXXX"
                Case "09"
                    S = "ABKLCY2NXXX"
                Case "10"
                    S = "EMPOCY2NXXX"
                Case "11"
                    S = "UNVKCY2NXXX"
                Case "12"
                    S = "SOGECY2NXXX"
                Case "14"
                    S = "CYDBCY2NXXX"
                Case "18"
                    S = "EFGBCY2NXXX"
                Case "20"
                    S = "CECBCY2NXXX"
                Case "21"
                    S = "CCBKCY2NXXX"
                Case "23"
                    S = "RCBLCY2IXXX"
                Case 24
                    S = "ERBKCY2NXXX"
                Case "99"
                    S = "INGBNL2AXXX"
                Case "98"
                    S = "ERBKGRAASEC"
                Case "90"
                    S = "WIREDEMMXXX"
                Case "97"
                    S = "ANCOCY2NXXX"
                Case "96"
                    S = "POALILITXXX"
                Case "95"
                    S = "RNCBROBUXXX"
                Case "94"
                    S = "AIZKLV22XXX"
                Case "93"
                    S = "LOYDGB2LXXX"
                Case "92"
                    S = "DNBANOKKXXX"
                Case "91"
                    S = "AGRIPLPRXXX"
                Case "89"
                    S = "BELADEBEXXX"
                Case "88"
                    S = "DEKTDE7GXXX"
                Case "87"
                    S = "PBNKDEFFXXX"
                Case "86"
                    S = "COBADEFFXXX"
                Case "85"
                    S = "INGDDEFFXXX"
                Case "84"
                    S = "HYVEDEMMXXX"
                Case "83"
                    S = "DEUTDEFFXXX"
                Case "82"
                    S = "RABONL2UXXX"
                Case "81"
                    S = "GENODEF1NDT"
                Case "80"
                    S = "SDUEDE33XXX"
                Case "79"
                    S = "GENODED1SPK"
                Case "78"
                    S = "COLSDE33XXX"
                Case "77"
                    S = "REVOGB21XXX"
                Case "76"
                    S = "HABALT22XXX"
                Case "75"
                    S = "LUMIILITXXX"
                Case "74"
                    S = "GKCCBEBBXXX"
                Case "73"
                    S = "FEBIITM1XXX"

            End Select
        End If

        If IsEurobank Then
            S = S.Replace("XXX", "   ")
        End If
        Return S

    End Function
    Private Sub CreateBankFile_MARFIN(ByVal Bank As cPrAnBanks, ByVal FileBankCode As String, ByVal EmployeeBankCode As String)
        InitFile = True
        Dim Ds As DataSet

        Dim CompanyBankAcc As String

        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim i As Integer
        Dim TotalDebitAmount As Double = 0


        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If

        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayed(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))
                End With
            Next
            Dim AmountS As String
            Dim Comp As New cAdMsCompany
            Dim CompDesc As String
            Comp = Me.CmbCompany.SelectedItem
            CompDesc = Comp.Name
            If CompDesc.Length > 30 Then
                CompDesc = CompDesc.Substring(0, 29)
            End If
            Dim Header As String = ""
            Dim Trailer As String = ""
            Dim SHT As String = ""

            'Define Header/Trailer
            If FileBankCode = "" Then
                MsgBox("company Bank Code is Missing cannot Proceed")
                Exit Sub
            End If
            SHT = SHT & FileBankCode.PadLeft(5, "0")
            SHT = SHT & CompDesc.PadRight(40, " ")
            SHT = SHT & Me.ComboBankAcc.Text.PadLeft(16, "0")
            SHT = SHT & Format(Now.Date, "ddMMyyyy")

            Trailer = "03" & SHT

            SHT = SHT & Format(DatePay.Value, "ddMMyyyy")

            SHT = SHT & "001"
            SHT = SHT & "".PadLeft(143, " ")


            Header = "01" & SHT



            WriteToBankFile(Header, "")


            'Define Lines
            Dim Line As String = ""
            Dim Bnk As New cPrAnBanks
            Dim BankAcc As String
            Dim BankAccNoDash As String
            Dim Salary As Double
            Dim EmpName As String
            Dim EmpCode As String
            Dim BankSwift As String = ""
            Dim EmpId As String
            Dim Count As Integer
            Dim DetailsOfTransfer As String
            DetailsOfTransfer = "SALARY FOR " & Period.DescriptionL & " " & Period.DateFrom.Year
            Dim IBAN As String = ""
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    EmpCode = DbNullToString(.Item(0))
                    Salary = DbNullToDouble(.Item(1))
                    EmpName = DbNullToString(.Item(2))
                    Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
                    BankAcc = DbNullToString(.Item(4))
                    BankAccNoDash = BankAcc.Replace("-", "")
                    BankAccNoDash = BankAccNoDash.Replace(" ", "")
                    IBAN = DbNullToString(.Item(8))

                    If BankAccNoDash.Length > 13 Then
                        MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If EmpName.Length > 35 Then
                        EmpName = EmpName.Substring(1, 35)
                    End If
                    BankSwift = FindEmployeeBankSwift(Bnk)
                    Line = "02"
                    Line = Line & "EUR"
                    AmountS = Format(Salary, "0.00")
                    Line = Line & AmountS.Replace(".", "").ToString.PadLeft(12, "0")
                    Line = Line & BankSwift.PadRight(11, " ")
                    If IBAN = "" Then
                        Line = Line & BankAccNoDash.PadLeft(34, "0")
                    Else
                        Line = Line & IBAN.PadRight(34, " ")
                    End If
                    Line = Line & EmpName.PadRight(35, " ")
                    Line = Line & EmpCode.PadRight(15, " ")
                    If DetailsOfTransfer.Length > 70 Then
                        DetailsOfTransfer = DetailsOfTransfer.Substring(1, 70)
                    End If
                    Line = Line & DetailsOfTransfer.PadRight(70, " ")
                    Line = Line & "".PadRight(15, " ")
                    Line = Line & "".PadRight(15, " ")
                    Line = Line & "".PadRight(2, " ")
                    Line = Line & "".PadRight(11, " ")
                    WriteToBankFile(Line, "")
                    Count = Count + 1


                End With
            Next
            AmountS = Format(TotalDebitAmount, "0.00")
            Trailer = Trailer & Count.ToString.PadLeft(4, "0")
            Trailer = Trailer & AmountS.Replace(".", "").PadLeft(15, "0")
            Trailer = Trailer & "".PadLeft(135, " ")

            WriteToBankFile(Trailer, "")
            MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
        Else
            MsgBox("No data to Send", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub CreateBankFile_MARFINAutopay(ByVal Bank As cPrAnBanks, ByVal FileBankCode As String, ByVal EmployeeBankCode As String)
        InitFile = True
        Dim Ds As DataSet

        Dim CompanyBankAcc As String

        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim i As Integer
        Dim TotalDebitAmount As Double = 0


        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim Count As Integer
        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayed(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))
                    Count = Count + 1
                End With
            Next
            Dim AmountS As String
            Dim Comp As New cAdMsCompany
            Dim CompDesc As String
            Comp = Me.CmbCompany.SelectedItem
            CompDesc = Comp.Name
            If CompDesc.Length > 30 Then
                CompDesc = CompDesc.Substring(0, 29)
            End If
            Dim Header As String = ""
            Dim Trailer As String = ""
            Dim SHT As String = ""

            'Define Header/Trailer
            If FileBankCode = "" Then
                MsgBox("company Bank Code is Missing cannot Proceed")
                Exit Sub
            End If
            SHT = SHT & FileBankCode.PadLeft(3, "0")
            SHT = SHT & CompDesc.PadRight(30, " ")
            SHT = SHT & "     "
            SHT = SHT & "03"
            SHT = SHT & Me.ComboBankAcc.Text.PadLeft(13, "0")
            SHT = SHT & Count.ToString.PadLeft(6, "0")
            Dim Dtotal As String = Format(TotalDebitAmount, "0.00")
            Dtotal = Dtotal.Replace(".", "")
            SHT = SHT & Dtotal.PadLeft(9, "0")
            'Trailer = Trailer & AmountS.Replace(".", "").PadLeft(15, "0")

            SHT = SHT & Format(Now.Date, "ddMMyyyy")
            SHT = SHT & "  "

            Trailer = "03" & SHT

            Header = "01" & SHT
            WriteToBankFile(Header, "")


            'Define Lines
            Dim Line As String = ""
            Dim Bnk As New cPrAnBanks
            Dim BankAcc As String
            Dim BankAccNoDash As String
            Dim Salary As Double
            Dim EmpName As String
            Dim EmpCode As String
            Dim BankSwift As String = ""
            Dim EmpId As String
            'Dim Count As Integer
            Dim DetailsOfTransfer As String
            DetailsOfTransfer = "SALARY FOR " & Period.DescriptionL & " " & Period.DateFrom.Year
            Dim IBAN As String = ""
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    EmpCode = DbNullToString(.Item(0))
                    Salary = DbNullToDouble(.Item(1))
                    EmpName = DbNullToString(.Item(2))
                    Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
                    BankAcc = DbNullToString(.Item(4))
                    BankAccNoDash = BankAcc.Replace("-", "")
                    BankAccNoDash = BankAccNoDash.Replace(" ", "")
                    IBAN = DbNullToString(.Item(8))

                    If BankAccNoDash.Length > 13 Then
                        MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If EmpName.Length > 35 Then
                        EmpName = EmpName.Substring(1, 35)
                    End If
                    BankSwift = FindEmployeeBankSwift(Bnk)
                    Line = "02"
                    Line = Line & "03"
                    Line = Line & BankAccNoDash.PadLeft(13, "0")
                    AmountS = Format(Salary, "0.00")
                    Line = Line & AmountS.Replace(".", "").ToString.PadLeft(8, "0")
                    Line = Line & EmpName.PadRight(40, " ")
                    Dim tEmp As String

                    tEmp = Utils.ClearCharacters(EmpCode)

                    Line = Line & tEmp.PadLeft(7, "0")
                    Line = Line & tEmp.PadLeft(7, "0")
                    Line = Line & " "
                    WriteToBankFile(Line, "")
                    Count = Count + 1


                End With
            Next

            WriteToBankFile(Trailer, "")
            MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
        Else
            MsgBox("No data to Send", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub CreateBankFile_HELLENICToOtherBanks(ByVal Bank As cPrAnBanks, ByVal FileBankCode As String, ByVal EmployeeBankCode As String)
        InitFile = True
        Dim Ds As DataSet

        Dim CompanyBankAcc As String

        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim i As Integer
        Dim TotalDebitAmount As Double = 0


        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim Count As Integer


        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayed(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        If CheckDataSet(Ds) Then
            RunSelection = False
            If CBSelectEmployees.CheckState = CheckState.Checked Then
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = True
                F.Ds = Ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To Ds.Tables(0).Rows.Count - 1
                        Ds.Tables(0).Rows(k).Item(10) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If


            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    If DbNullToString(.Item(10)) = "1" Then
                        TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))
                        Count = Count + 1
                    End If
                End With
            Next
            Dim AmountS As String
            Dim Comp As New cAdMsCompany
            Dim CompDesc As String
            Comp = Me.CmbCompany.SelectedItem
            CompDesc = Comp.Name
            If CompDesc.Length > 30 Then
                CompDesc = CompDesc.Substring(0, 29)
            End If
            Dim Header As String = ""
            Dim Trailer As String = ""

            'Define Header/Trailer
            Dim SHT As String = ""


            SHT = "P"
            SHT = SHT & Count.ToString.PadLeft(5, " ")
            Dim Dtotal As String = FormatCurrency(TotalDebitAmount, 2)
            Dtotal = Dtotal.Replace("$", "")
            Dtotal = Dtotal.Replace(",", "|")
            Dtotal = Dtotal.Replace(".", ",")
            Dtotal = Dtotal.Replace("|", ".")


            SHT = SHT & Dtotal.PadLeft(18, " ")
            SHT = SHT & Format(Me.DatePay.Value, "yyyyMMdd")
            SHT = SHT & Me.ComboBankAcc.Text.PadLeft(16, " ")

            Header = SHT
            WriteToBankFile(Header, "")


            'Define Lines
            Dim Line As String = ""
            Dim Bnk As New cPrAnBanks
            Dim BankAcc As String
            Dim BankAccNoDash As String
            Dim Salary As Double
            Dim EmpName As String
            Dim EmpCode As String
            Dim BankSwift As String = ""
            Dim EmpId As String
            Dim Empty As String = ""
            'Dim Count As Integer
            Dim DetailsOfTransfer As String
            DetailsOfTransfer = "SALARY FOR " & Period.DescriptionL & " " & Period.DateFrom.Year
            Dim IBAN As String = ""
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    If DbNullToString(.Item(10)) = "1" Then
                        EmpCode = DbNullToString(.Item(0))
                        Salary = DbNullToDouble(.Item(1))
                        EmpName = DbNullToString(.Item(2))
                        Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
                        BankAcc = DbNullToString(.Item(4))
                        BankAccNoDash = BankAcc.Replace("-", "")
                        BankAccNoDash = BankAccNoDash.Replace(" ", "")
                        IBAN = DbNullToString(.Item(8))

                        If BankAccNoDash.Length > 13 Then
                            MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        If EmpName.Length > 35 Then
                            EmpName = EmpName.Substring(1, 35)
                        End If
                        BankSwift = FindEmployeeBankSwift_HELLENIC(Bnk)
                        If Bnk.Code = "HELLENIC" Then
                            Line = "B"
                            Line = Line & Me.ComboBankAcc.Text.PadLeft(16, " ")
                            Line = Line & BankAccNoDash.PadLeft(16, " ")
                            AmountS = FormatCurrency(Salary, 2)
                            AmountS = AmountS.Replace("$", "")
                            AmountS = AmountS.Replace(",", "|")
                            AmountS = AmountS.Replace(".", ",")
                            AmountS = AmountS.Replace("|", ".")

                            Line = Line & AmountS.PadLeft(18, " ")
                            Line = Line & "EUR"
                            Line = Line & Format(Me.DatePay.Value.Date, "yyyyMMdd")
                            Line = Line & Format(Me.DatePay.Value.Date, "yyyyMMdd")
                            Line = Line & EmpName.PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                            Line = Line & "Payroll".PadLeft(20, " ")
                        Else
                            Line = "S"


                            Line = Line & Me.ComboBankAcc.Text.PadLeft(16, " ")
                            Line = Line & IBAN.PadLeft(35, " ")
                            AmountS = FormatCurrency(Salary, 2)
                            AmountS = AmountS.Replace("$", "")
                            AmountS = AmountS.Replace(",", "|")
                            AmountS = AmountS.Replace(".", ",")
                            AmountS = AmountS.Replace("|", ".")

                            Line = Line & AmountS.PadLeft(18, " ")
                            Line = Line & "EUR"
                            Line = Line & Format(Me.DatePay.Value.Date, "yyyyMMdd")
                            Line = Line & Format(Me.DatePay.Value.Date, "yyyyMMdd")
                            Line = Line & EmpName.PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                            Line = Line & BankSwift
                            'Line = Line & "XXX"
                            Line = Line & "N"
                            Line = Line & Empty.PadLeft(20, " ")
                            Line = Line & "Payroll".PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                            Line = Line & Empty.PadLeft(35, " ")
                        End If
                        WriteToBankFile(Line, "")
                        Count = Count + 1
                    End If
                End With

            Next
            MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
        Else
            MsgBox("No data to Send", MsgBoxStyle.Information)
        End If

    End Sub
    Private Function FindEmployeeBankSwift(ByVal Bank As cPrAnBanks) As String
        Dim S As String

        If Trim(Bank.SwiftCode) <> "" Then
            S = Bank.SwiftCode
        Else
            If Bank.Code = "MARFIN" Then
                S = "LIKICY2N"
            ElseIf Bank.Code = "BOC" Then
                S = "BCYPCY2N"
            ElseIf Bank.Code = "HELLENIC" Then
                S = "HEBACY2N"
            ElseIf Bank.Code = "NATIONAL" Then
                S = "ETHNCY2N"
            ElseIf Bank.Code = "COOP" Then
                S = "CCBKCY2N"
            ElseIf Bank.Code = "PIRAEUS" Then
                S = "PIRBCY2N"
            ElseIf Bank.Code = "ALPHA" Then
                S = "ABKLCY2N"
            ElseIf Bank.Code = "COMERCIAL" Then
                S = "EMPOCY2N"
            ElseIf Bank.Code = "USB" Then
                S = "UNVKCY2N"
            ElseIf Bank.Code = "SOCIETE" Then
                S = "SOGECY2N"
            ElseIf Bank.Code = "EUROBANK" Then
                S = "ERBKCY2N"
            ElseIf Bank.Code = "ING" Then
                S = "INGBNL2A"
            ElseIf Bank.Code = "ERG" Then
                S = "EFGBGRAA"
            ElseIf Bank.Code = "ANCORIA" Then
                S = "ANCOCY2N"

            End If
        End If
        Return S
    End Function
    Private Function FindEmployeeBankSwift_HELLENIC(ByVal Bank As cPrAnBanks) As String
        Dim S As String
        If Trim(Bank.SwiftCode) <> "" Then
            S = Trim(Bank.SwiftCode)
        Else
            If Bank.Code = "MARFIN" Then
                S = "LIKICY2NXXX"
            ElseIf Bank.Code = "BOC" Then
                S = "BCYPCY2NXXX"
            ElseIf Bank.Code = "HELLENIC" Then
                S = "HEBACY2NXXX"
            ElseIf Bank.Code = "NATIONAL" Then
                S = "ETHNCY2NXXX"
            ElseIf Bank.Code = "COOP" Then
                S = "CCBKCY2NXXX"
            ElseIf Bank.Code = "PIRAEUS" Then
                S = "PIRBCY2NXXX"
            ElseIf Bank.Code = "ALPHA" Then
                S = "ABKLCY2NXXX"
            ElseIf Bank.Code = "COMERCIAL" Then
                S = "EMPOCY2NXXX"
            ElseIf Bank.Code = "USB" Then
                S = "UNVKCY2NXXX"
            ElseIf Bank.Code = "SOCIETE" Then
                S = "SOGECY2NXXX"
            ElseIf Bank.Code = "EUROBANK" Then
                S = "ERBKCY2NXXX"
            ElseIf Bank.Code = "ING" Then
                S = "INGBNL2AXXX"
            ElseIf Bank.Code = "ERG" Then
                'S = "EFGBGRAASEC"
                S = "ERBKGRAASEC"
            ElseIf Bank.Code = "ER2" Then
                S = "ERBKGRAAXXX"

            End If
        End If

        Return S
    End Function


    Private Sub CreateBankFile_BOC(ByVal Bank As cPrAnBanks, ByVal FileBankCode As String, ByVal EmployeeBankCode As String)
        InitFile = True
        Dim Ds As DataSet

        Dim CompanyBankAcc As String

        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim i As Integer
        Dim TotalDebitAmount As Double = 0


        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If

        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayed(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))
                End With
            Next
            Dim AmountS As String
            Dim Comp As New cAdMsCompany
            Dim CompDesc As String
            Dim EmptySpaces_1 As String = " "
            Dim EmptySpaces_2 As String = "  "
            Dim EmptySpaces_5 As String = "     "
            Dim EmptySpaces_7 As String = "       "
            Comp = Me.CmbCompany.SelectedItem
            CompDesc = Comp.Name
            If CompDesc.Length > 30 Then
                CompDesc = CompDesc.Substring(1, 30)
            End If
            Dim Header As String = ""
            Dim Trailer As String = ""
            Dim SHT As String = ""

            'Define Header/Trailer
            If FileBankCode = "" Then
                MsgBox("company Bank Code is Missing cannot Proceed")
                Exit Sub
            End If
            SHT = SHT & FileBankCode
            SHT = SHT & CompDesc.PadRight(30, " ")
            SHT = SHT & EmptySpaces_5
            SHT = SHT & Bank.TransferCode
            SHT = SHT & "0"
            SHT = SHT & Me.ComboBankAcc.Text.PadLeft(12, " ")
            SHT = SHT & Ds.Tables(0).Rows.Count.ToString.PadLeft(6, "0")
            AmountS = Format(TotalDebitAmount, "0.00")
            SHT = SHT & AmountS.Replace(".", "").PadLeft(9, "0")
            SHT = SHT & Format(DatePay.Value, "ddMMyyyy")
            SHT = SHT & EmptySpaces_2

            Header = "01" & SHT
            Trailer = "03" & SHT

            WriteToBankFile(Header, "")


            'Define Lines
            Dim Line As String = ""
            Dim Bnk As New cPrAnBanks
            Dim BankAcc As String
            Dim BankAccNoDash As String
            Dim Salary As Double
            Dim EmpName As String
            Dim EmpCode As String
            Dim EmpIdCard As String
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    EmpCode = DbNullToString(.Item(0))
                    Salary = DbNullToDouble(.Item(1))
                    EmpName = DbNullToString(.Item(2))
                    Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
                    BankAcc = DbNullToString(.Item(4))
                    BankAccNoDash = BankAcc.Replace("-", "")
                    EmpIdCard = DbNullToString(.Item(9))

                    If BankAccNoDash.Length > 13 Then
                        MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If EmpName.Length > 40 Then
                        EmpName = EmpName.Substring(1, 40)
                    End If

                    Line = "02"
                    Line = Line & Bnk.TransferCode
                    Line = Line & BankAccNoDash.PadLeft(13, "0")
                    AmountS = Format(Salary, "0.00")
                    Line = Line & AmountS.Replace(".", "").ToString.PadLeft(8, "0")
                    Line = Line & EmpName.PadRight(40, " ")
                    If EmpCode.Length > 7 Then
                        EmpCode = EmpCode.Substring(1, 7)
                    End If
                    Line = Line & EmpCode.PadRight(7, " ")

                    If EmpIdCard.Length > 7 Then
                        EmpIdCard = EmpIdCard.Substring(1, 7)
                    End If
                    Line = Line & EmpIdCard.PadRight(7, " ")

                    'Line = Line & EmptySpaces_7
                    'Line = Line & EmptySpaces_7
                    Line = Line & EmptySpaces_1
                    WriteToBankFile(Line, "")

                End With
            Next
            WriteToBankFile(Trailer, "")
            MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
        Else
            MsgBox("No data to Send", MsgBoxStyle.Information)
        End If

    End Sub
    Private Sub CreateBankFile_BOCConsolidate(ByVal Bank As cPrAnBanks, ByVal BankFilename As String, ByVal DaysBack As Integer, ByVal Create2Files As Boolean, ByVal ThisIsCompanyBankFile As Boolean, ByVal FileBankCode As String, ByVal EmployeeBankCode As String)
        InitFile = True
        Dim Ds As DataSet

        Dim CompanyBankAcc As String

        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim i As Integer
        Dim TotalDebitAmount As Double = 0


        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        If Create2Files Then
            Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, Create2Files, ThisIsCompanyBankFile, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        Else
            Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL(TemGrp, Period, Bank, CompanyBankAcc, False, Includeinactive, Create2Files, ThisIsCompanyBankFile, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)
        End If
        If CheckDataSet(Ds) Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    TotalDebitAmount = TotalDebitAmount + DbNullToDouble(.Item(1))
                End With
            Next
            Dim AmountS As String
            Dim Comp As New cAdMsCompany
            Dim CompDesc As String
            Dim EmptySpaces_1 As String = " "
            Dim EmptySpaces_2 As String = "  "
            Dim EmptySpaces_5 As String = "     "
            Dim EmptySpaces_7 As String = "       "
            Comp = Me.CmbCompany.SelectedItem
            CompDesc = Comp.Name
            If CompDesc.Length > 30 Then
                CompDesc = CompDesc.Substring(1, 30)
            End If
            Dim Header As String = ""
            Dim Trailer As String = ""
            Dim SHT As String = ""

            'Define Header/Trailer
            If FileBankCode = "" Then
                MsgBox("company Bank Code is Missing cannot Proceed")
                Exit Sub
            End If
            SHT = SHT & FileBankCode
            SHT = SHT & CompDesc.PadRight(30, " ")
            SHT = SHT & EmptySpaces_5
            SHT = SHT & Bank.TransferCode
            SHT = SHT & "0"
            SHT = SHT & Me.ComboBankAcc.Text.PadLeft(12, " ")
            SHT = SHT & Ds.Tables(0).Rows.Count.ToString.PadLeft(6, "0")
            AmountS = Format(TotalDebitAmount, "0.00")
            SHT = SHT & AmountS.Replace(".", "").PadLeft(9, "0")
            Dim D As Date = DatePay.Value
            If Create2Files Then
                If Not ThisIsCompanyBankFile Then
                    D = DateAdd(DateInterval.Day, -DaysBack, D)
                End If
            End If
            SHT = SHT & Format(D, "ddMMyyyy")
            SHT = SHT & EmptySpaces_2

            Header = "01" & SHT
            Trailer = "03" & SHT

            WriteToBankFile(Header, BankFilename)


            'Define Lines
            Dim Line As String = ""
            Dim Bnk As New cPrAnBanks
            Dim BankAcc As String
            Dim BankAccNoDash As String
            Dim Salary As Double
            Dim EmpName As String
            Dim EmpCode As String
            Dim EmpIdCard As String
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                With Ds.Tables(0).Rows(i)
                    EmpCode = DbNullToString(.Item(0))
                    Salary = DbNullToDouble(.Item(1))
                    EmpName = DbNullToString(.Item(2))
                    Bnk = New cPrAnBanks(DbNullToString(.Item(3)))
                    BankAcc = DbNullToString(.Item(4))
                    BankAccNoDash = BankAcc.Replace("-", "")
                    EmpIdCard = DbNullToString(.Item(9))

                    If BankAccNoDash.Length > 13 Then
                        MsgBox("ERROR - Bank Account (" & BankAcc & ") of Employee " & EmpCode & " - " & EmpName & " Is invalid.Max Lenght without Dashes must be 13 digits.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If EmpName.Length > 40 Then
                        EmpName = EmpName.Substring(1, 40)
                    End If

                    Line = "02"
                    Line = Line & Bnk.TransferCode
                    Line = Line & BankAccNoDash.PadLeft(13, "0")
                    AmountS = Format(Salary, "0.00")
                    Line = Line & AmountS.Replace(".", "").ToString.PadLeft(8, "0")
                    Line = Line & EmpName.PadRight(40, " ")
                    If EmpCode.Length > 7 Then
                        EmpCode = EmpCode.Substring(1, 7)
                    End If
                    Line = Line & EmpCode.PadRight(7, " ")

                    If EmpIdCard.Length > 7 Then
                        EmpIdCard = EmpIdCard.Substring(1, 7)
                    End If
                    Line = Line & EmpIdCard.PadRight(7, " ")

                    'Line = Line & EmptySpaces_7
                    'Line = Line & EmptySpaces_7
                    Line = Line & EmptySpaces_1
                    WriteToBankFile(Line, BankFilename)

                End With
            Next
            WriteToBankFile(Trailer, BankFilename)
            If BankFilename = "" Then
                MsgBox("File " & BankFiledir & "TRANASCI.TXT" & " Is Created ", MsgBoxStyle.Information)
            Else
                MsgBox("File " & BankFiledir & BankFilename & " Is Created ", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("No data to Send", MsgBoxStyle.Information)
        End If

    End Sub
    Private Function WriteToBankFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String
            If fName = "" Then
                FileName = BankFiledir & "TRANASCI.TXT"
            Else
                FileName = BankFiledir & fName
            End If
            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""

        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode,True )
        If CheckDataSet(ds) Then
            
            Dim F As New FrmBankReport
            F.Period = Period
            F.TemGrp = TemGrp
            F.ds = ds
            F.ShowDialog()
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function PrepareDSForReport(ByVal IncludeInactive As Boolean, ByVal EmployeeBankCode As String, ByVal ForReport As Boolean) As DataSet
        Dim Ds As DataSet
        Dim Bank As cPrAnBanks
        Dim CompanyBankAcc As String
        'CompanyBankAcc = Me.txtCompanyBankAcc.Text()
        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim TotalDebitAmount As Double = 0

        Bank = Me.cmbBnk_CodeCo.SelectedItem

        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL(TemGrp, Period, Bank, CompanyBankAcc, forreport, IncludeInactive, False, False, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)


        Return Ds
    End Function
    Private Function PrepareDSForEWallet(ByVal IncludeInactive As Boolean, ByVal EmployeeBankCode As String, ByVal ForReport As Boolean) As DataSet
        Dim Ds As DataSet
        Dim Bank As cPrAnBanks
        Dim CompanyBankAcc As String
        'CompanyBankAcc = Me.txtCompanyBankAcc.Text()
        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim TotalDebitAmount As Double = 0

        Bank = Me.cmbBnk_CodeCo.SelectedItem

        Ds = Global1.Business.GetAllPrTxHeader_EWALLET(TemGrp, Period, Bank, CompanyBankAcc, ForReport, IncludeInactive, False, False, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)


        Return Ds
    End Function
    Private Function PrepareALLIBANSReport(ByVal IncludeInactive As Boolean) As DataSet
        Dim Ds As DataSet
        Dim Bank As cPrAnBanks
        Dim CompanyBankAcc As String
        'CompanyBankAcc = Me.txtCompanyBankAcc.Text()
        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim TotalDebitAmount As Double = 0

        Bank = Me.cmbBnk_CodeCo.SelectedItem

        Ds = Global1.Business.GetAllIBANSReport(TemGrp, Period, IncludeInactive)


        Return Ds
    End Function
    Private Function PrepareDSForReport_ForAlphaBank(ByVal IncludeInactive As Boolean, ByVal EmployeeBankCode As String, ByVal OnlyAlpha As Boolean) As DataSet
        Dim Ds As DataSet
        Dim Bank As cPrAnBanks
        Dim CompanyBankAcc As String
        'CompanyBankAcc = Me.txtCompanyBankAcc.Text()
        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim TotalDebitAmount As Double = 0

        Bank = Me.cmbBnk_CodeCo.SelectedItem


        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL_Alpha(TemGrp, Period, Bank, CompanyBankAcc, False, IncludeInactive, False, False, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode, OnlyAlpha)




        Return Ds
    End Function
    Private Function PrepareDSForReport_ForSEPAGA(ByVal IncludeInactive As Boolean, ByVal EmployeeBankCode As String) As DataSet
        Dim Ds As DataSet
        Dim Bank As cPrAnBanks
        Dim CompanyBankAcc As String
        CompanyBankAcc = Me.ComboBankAcc.Text
        Dim TotalDebitAmount As Double = 0

        Bank = Me.cmbBnk_CodeCo.SelectedItem


        Ds = Global1.Business.GetAllPrTxHeader_InterfacedBankPayedCONSOL_SEPAGA(TemGrp, Period, Bank, CompanyBankAcc, False, IncludeInactive, False, False, GLBAnalysis, GLBAnalysisCode, EmployeeBankCode)


        Return Ds
    End Function

    Private Sub btnPaymentRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentRequest.Click
        CallReport(1)
    End Sub
    Private Sub CallReport(ByVal ReportCode As Integer)
        Dim ds As DataSet

        Dim Includeinactive As Boolean = False
        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If

        Dim EmployeeBankCode As String = ""
        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, True)
        Dim AmountA As Double
        Dim AmountB As Double
        Dim A_B As Double()
        A_B = Global1.Business.GetPFAmount_A_And_B(TemGrp, Period, Includeinactive)
        AmountA = A_B(0)
        AmountB = A_B(1)
        If CheckDataSet(ds) Then
            Dim RefNo As String
            RefNo = TemGrp.Code & "-" & Period.Code
            Dim F As New FrmPaymentRequest
            F.DS = ds
            F.RefNo = RefNo
            F.txtRefNo.Text = RefNo
            F.txtCompany.Text = CType(Me.CmbCompany.SelectedItem, cAdMsCompany).Name
            F.txtBank.Text = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks).DescriptionL
            F.txtBankAccount.Text = Me.ComboBankAcc.Text
            F.txtDate.Text = Format(Me.DatePay.Value.Date, "yyyy-MM-dd")
            F.AmountA = AmountA
            F.AmountB = AmountB
            F.ReportSelection = ReportCode
            F.ShowDialog()
        End If

    End Sub

    Private Sub CmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCompany.SelectedIndexChanged
        If Not Loading Then
            LoadBankAccounts()
            LoadBankFileCodes()
        End If
    End Sub

    Private Sub cmbBnk_CodeCo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBnk_CodeCo.SelectedIndexChanged
        If Not Loading Then
            LoadBankAccounts()

        End If
    End Sub
    Private Sub LoadBankAccounts()
        Dim Company As New cAdMsCompany
        Dim Bank As New cPrAnBanks
        Company = CType(Me.CmbCompany.SelectedItem, cAdMsCompany)
        Bank = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks)

        Dim Ds As DataSet
        Dim i As Integer
        Dim t As Boolean = False
        Ds = Global1.Business.FindBankAccounts(Company, Bank)
        If CheckDataSet(Ds) Then
            With Me.ComboBankAcc
                .BeginUpdate()
                .Items.Clear()
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    If Trim(DbNullToString(Ds.Tables(0).Rows(i).Item(0))) <> "" Then
                        .Items.Add(DbNullToString(Ds.Tables(0).Rows(i).Item(0)))
                        t = True
                    End If

                Next
                .EndUpdate()
                If t = True Then
                    .SelectedIndex = 0
                End If
            End With
        End If
    End Sub
    Private Sub LoadBankFileCodes()
        Dim Company As New cAdMsCompany
        Company = CType(Me.CmbCompany.SelectedItem, cAdMsCompany)


        Dim i As Integer

        Dim T As Boolean = False
        With Me.ComboBankFileCode
            .BeginUpdate()
            .Items.Clear()
            If Company.BankCode <> "" Then
                .Items.Add(Company.BankCode)
                T = True
            End If
            If Company.BankCode2 <> "" Then
                .Items.Add(Company.BankCode2)
                T = True
            End If
            If Company.BankCode3 <> "" Then
                .Items.Add(Company.BankCode3)
                T = True
            End If
            If Company.BankCode4 <> "" Then
                .Items.Add(Company.BankCode4)
                T.ToString()
            End If
            .EndUpdate()
            If T Then
                .SelectedIndex = 0
            End If
        End With

    End Sub

   
   
    Private Sub btnViewPFReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewPFReport.Click
        Dim ds As DataSet
        Dim f As New FrmPFReportByCompany
        F.TemGrp = TemGrp
        f.Period = Period
        f.PeriodDescription = Period.DescriptionL
        f.Show()

    End Sub
    Private Sub CorvertBankFileToXML(ByVal txtFineNameAndPath As String, ByVal FilePath As String, ByVal ChangeName As Boolean, ByVal IsEurobank As Boolean)

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try




            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = txtFineNameAndPath
            If Not ChangeName Then
                Me.XMLGlobalFileName = FilePath & "DPSXMLDCI6.xml"
            Else
                Me.XMLGlobalFileName = FilePath & "DPSXMLDCI6_OtherBanks.xml"
            End If
            
            InitFile = True
            Dim Exx As New Exception
            Dim Ar As String


            '------------------------------------------------------------------
            'Open for reading in order to Read Total employees and Total Amount'
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Dim TotalAmount As Double = 0
            Dim sTotalAmount As String = ""
            Dim totalEmployees As String = ""

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "02"
                        Lines = Lines + 1
                        TotalAmount = TotalAmount + Trim(Line.Substring(5, 15))
                End Select
            Loop
            sTotalAmount = StringtoDecimal2(TotalAmount.ToString)
            totalEmployees = Lines.ToString
            param_file.Close()
            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------


            '------------------------------------------------------------------
            'Open for reading in order to Write XML File
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Lines = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "01"
                        Write_SEPA_Header(Line, totalEmployees, sTotalAmount, IsEurobank)
                    Case "02"
                        Lines = Lines + 1
                        Write_SEPA_LINE(Line, Lines.ToString, IsEurobank)
                End Select
                Application.DoEvents()
            Loop

            WL("</PmtInf>")
            WL("</CstmrCdtTrfInitn>")
            WL("</Document>")

            param_file.Close()

            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------

            MsgBox("Bank File is Converted to .xml (" & Me.XMLGlobalFileName & ")", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default



    End Sub
    Public Sub Write_SEPA_Header(ByVal Line As String, ByVal Totalemployees As String, ByVal TotalAmount As String, ByVal IsEurobank As Boolean)



        Dim sCreationDateTime As String = Format(Now.Date, "yyyy-MM-dd")
        sCreationDateTime = sCreationDateTime & "T" & Now.Hour.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Minute.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Second.ToString.PadLeft(2, "0")

        Dim sTotalTransactions As String = Totalemployees
        Dim sTotalAmount As String = TotalAmount
        Dim sCompanyName As String = Trim(Line.Substring(7, 70))
        Dim sCompanyDigitCode As String = Trim(Line.Substring(2, 5))

        Dim YY As String = Trim(Line.Substring(115, 4))
        Dim MM As String = Trim(Line.Substring(113, 2))
        Dim DD As String = Trim(Line.Substring(111, 2))
        Dim sExecutionDate As String = YY & "-" & MM & "-" & DD
        Dim sIBAN As String = Trim(Line.Substring(77, 34))
        Dim SBIC As String = ""

        ' Addition for Eurobank
        'If IsEurobank Then
        ' SBIC = Trim(Line.Substring(500, 8))
        ' End If

        Debug.WriteLine(Line)





        '''''''''''
        WL(" <Document xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03"" xsi:schemaLocation=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03 pain.001.001.03.xsd"">")
        WL("<CstmrCdtTrfInitn>")
        WL("<GrpHdr>")
        WL("<MsgId>MsgId1</MsgId>")
        WL("<CreDtTm>" & sCreationDateTime & "</CreDtTm>")
        WL("<NbOfTxs>" & sTotalTransactions & "</NbOfTxs>")
        WL("<CtrlSum>" & sTotalAmount & "</CtrlSum>")
        WL("<InitgPty>")
        'WL("<Nm>" & Replace(sCompanyName, "&", "&amp;") & "</Nm>")
        WL("<Nm>" & Replace(sCompanyName, "&", " ") & "</Nm>")
        WL("<Id>")
        WL("<OrgId>")
        WL("<Othr>")
        WL("<Id>" & sCompanyDigitCode & "</Id>")
        WL("</Othr>")
        WL("</OrgId>")
        WL("</Id>")
        WL("</InitgPty>")
        WL("</GrpHdr>")
        ''''''''''
        '  If IsEurobank Then
        'WL("<PmtInf>Payroll Payment</PmtInf>")
        'Else
        WL("<PmtInf>")
        'End If
        '''''''''''
        WL("<PmtInfId>PmtInfId</PmtInfId>")
        WL("<PmtMtd>TRF</PmtMtd>")
        If IsEurobank Then
            WL("<BtchBookg>true</BtchBookg>")
        Else
            WL("<BtchBookg>1</BtchBookg>")
        End If
        WL("<PmtTpInf>")
        WL("<SvcLvl>")
        WL("<Cd>SEPA</Cd>")
        WL("</SvcLvl>")
        WL("</PmtTpInf>")
        WL("<ReqdExctnDt>" & sExecutionDate & "</ReqdExctnDt>")
        WL("<Dbtr>")
        'WL("<Nm>" & Replace(sCompanyName, "&", "&amp;") & "</Nm>")
        WL("<Nm>" & Replace(sCompanyName, "&", " ") & "</Nm>")
        WL("<PstlAdr>")
        WL("<Ctry>CY</Ctry>")
        WL("</PstlAdr>")
        WL("<Id>")
        WL("<OrgId>")
        'Addition for EUROBANK
        'If IsEurobank Then
        '    WL("<BICOrBEI>" & SBIC & "</BICOrBEI>")
        'End If
        ''''''''''''''''''''''''

        WL("<Othr>")
        WL("<Id>" & sCompanyDigitCode & "</Id>")
        WL("</Othr>")
        WL("</OrgId>")
        WL("</Id>")
        WL("</Dbtr>")
        WL("<DbtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & UCase(sIBAN) & "</IBAN>")
        WL("</Id>")
        WL("<Ccy>EUR</Ccy>")
        WL("</DbtrAcct>")
        WL("<DbtrAgt>")
        WL("<FinInstnId>")
        '  WL("<BIC>" & sBIC & "</BIC>")
        If IsEurobank Then
            WL("<BIC>ERBKCY2N</BIC>")
        End If
        WL("</FinInstnId>")
        WL("</DbtrAgt>")
        WL("<ChrgBr>SLEV</ChrgBr>")
        ''''''''''



    End Sub
    Private Function StringtoDecimal2(ByVal Str As String) As String

        Dim S As String
        S = Format(CDbl(Str) / 100, "0.00")

        S = S.Replace(",", ".")
        Return S

        'Dim L As Integer
        'Dim i As Integer
        'Dim X As String = ""
        'L = Str.Length
        'For i = 0 To Str.Length - 1
        '    X = X & Str.Substring(i, 1)
        '    If i = L - 3 Then
        '        X = X & "."
        '    End If
        'Next
        'Return X
    End Function

    Public Sub Write_SEPA_LINE(ByVal Line As String, ByVal sLineNo As String, ByVal IsEurobank As Boolean)

        Dim sAmount As String = Trim(Line.Substring(5, 15))
        sAmount = StringtoDecimal2(sAmount)


        Dim sBIC As String = Trim(Line.Substring(20, 11))
        Dim semployeename As String = Trim(Line.Substring(65, 70))
        Dim sIBAN As String = Trim(Line.Substring(31, 34))
        Dim sCountryCode As String = Trim(Line.Substring(139, 2))
        Dim sPaymentDesc As String = Trim(Line.Substring(141, 140))

        WL("<CdtTrfTxInf>")

        WL("<PmtId>")
        WL("<InstrId>" & sLineNo & "</InstrId>")
        WL("<EndToEndId>" & sLineNo & "</EndToEndId>")
        WL("</PmtId>")

        WL("<PmtTpInf>")
        WL("<SvcLvl>")
        WL("<Cd>SEPA</Cd>")
        WL("</SvcLvl>")
        WL("<CtgyPurp>")
        WL("<Cd>SALA</Cd>")
        WL("</CtgyPurp>")
        WL("</PmtTpInf>")

        WL("<Amt>")
        WL("<InstdAmt Ccy=""EUR"">" & sAmount & "</InstdAmt>")
        WL("</Amt>")

        WL("<ChrgBr>SLEV</ChrgBr>")

        WL("<CdtrAgt>")
        WL("<FinInstnId>")
        WL("<BIC>" & sBIC & "</BIC>")
        WL("</FinInstnId>")
        WL("</CdtrAgt>")

        WL("<Cdtr>")
        WL("<Nm>" & semployeename & "</Nm>")
        WL("<PstlAdr>")
        WL("<Ctry>" & sCountryCode & "</Ctry>")
        'WL("<AdrLine>address line1</AdrLine>")
        'WL("<AdrLine>address line2</AdrLine>")
        WL("</PstlAdr>")
        'WL("<Id>")
        'WL("<PrvtId>")
        'WL("<DtAndPlcOfBirth>")
        'WL("<BirthDt>1998-03-30</BirthDt>")
        'WL("<PrvcOfBirth>Nicosia</PrvcOfBirth>")
        'WL("<CityOfBirth>Nicosia</CityOfBirth>")
        'WL("<CtryOfBirth>CY</CtryOfBirth>")
        'WL("</DtAndPlcOfBirth>")
        'WL("</PrvtId>")
        'WL("</Id>")
        WL("</Cdtr>")
        WL("<CdtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & UCase(sIBAN) & "</IBAN>")
        WL("</Id>")
        WL("</CdtrAcct>")

        If IsEurobank Then
            WL("<RmtInf>")
            WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
            WL("</RmtInf>")
        End If
        If Not IsEurobank Then
            If Global1.PARAM_ShowPaymentDescOnBankFile Then
                WL("<RmtInf>")
                WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
                WL("</RmtInf>")
            End If
        End If

        WL("</CdtTrfTxInf>")
        '''''''''''''''''''''''''''''''''''''''''''
        '        <CdtTrfTxInf>
        '<PmtId>
        '<InstrId>InstrId 3</InstrId>
        '<EndToEndId>EndToEndId 3</EndToEndId>
        '</PmtId>
        '<PmtTpInf>
        '<SvcLvl>
        '<Cd>SEPA</Cd>
        '</SvcLvl>
        '<CtgyPurp>
        '<Cd>SALA</Cd>
        '</CtgyPurp>
        '</PmtTpInf>
        '<Amt>
        '<InstdAmt Ccy="EUR">1100.00</InstdAmt>
        '</Amt>
        '<ChrgBr>SLEV</ChrgBr>
        '<CdtrAgt>
        '<FinInstnId>
        '<BIC>CCBKCY2N</BIC>
        '</FinInstnId>
        '</CdtrAgt>
        '<Cdtr>
        '<Nm>Creditor 3</Nm>
        '<PstlAdr>
        '<Ctry>CY</Ctry>
        '<AdrLine>address line 1 for customer3</AdrLine>
        '</PstlAdr>
        '<Id>
        '<PrvtId>
        '<Othr>
        '<Id>U1234</Id>
        '</Othr>
        '</PrvtId>
        '</Id>
        '</Cdtr>
        '<CdtrAcct>
        '<Id>
        '<IBAN>CY38007101100000000020333607</IBAN>
        '</Id>
        '</CdtrAcct>
        'If IsEurobank Then
        '    WL("<RmtInf>")
        '    WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        '    WL("</RmtInf>")
        'End If
        '</CdtTrfTxInf>


    End Sub
    Private Function WL(ByVal Line As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(XMLGlobalFileName)
                InitFile = False
            Else
                If IO.File.Exists(XMLGlobalFileName) Then
                    TW = System.IO.File.AppendText(XMLGlobalFileName)
                Else
                    TW = System.IO.File.CreateText(XMLGlobalFileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CallReport(2)
      


    End Sub

    
 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ","
            Dim c1_SEPANonSEPAIndicator As String = "SEPA/Non-SEPA Indicator"
            Dim c2_DebitAccount As String = "Debit Account"
            Dim c3_Amount As String = "Amount"
            Dim c4_Currency As String = "Currency"
            Dim c5_IBANIndicator As String = "IBAN Indicator"
            Dim c6_IBANorAccountNumber As String = "IBAN or Account Number"
            Dim c7_BICorSortCode As String = "BIC or Sort Code"
            Dim c7_CountryofBeneficiaryBank As String = "Country of Beneficiary's Bank"
            Dim c8_BeneficiaryBankDetailsLine1 As String = "Beneficiary Bank Details Line 1"
            Dim c9_BeneficiaryBankDetailsLine2 As String = "Beneficiary Bank Details Line 2"
            Dim c10_IntermediateBank As String = "Intermediate Bank"
            Dim c11_BeneficiaryDetailsLine1 As String = "Beneficiary Details Line 1"
            Dim c12_BeneficiaryDetailsLine2 As String = "Beneficiary Details Line 2"
            Dim c13_BeneficiaryDetailsLine3 As String = "Beneficiary Details Line 3"
            Dim c14_BeneficiaryDetailsCountryISOCode As String = "Beneficiary Details Country ISO Code"
            Dim c15_BeneficiaryDetailsLine4 As String = "Beneficiary Details Line 4"
            Dim c16_DetailsofPaymentLine1 As String = "Details of Payment Line 1"
            Dim c17_DetailsofPaymentLine2 As String = "Details of Payment Line 2"
            Dim c18_DetailsofPaymentLine3 As String = "Details of Payment Line 3"
            Dim c19_DetailsofPaymentLine4 As String = "Details of Payment Line 4"
            Dim c20_ExecutionMode As String = "Execution Mode"
            Dim c21_FeeChargingMode As String = "Fee Charging Mode"

            Header = Header & c1_SEPANonSEPAIndicator & Separator
            Header = Header & c2_DebitAccount & Separator
            Header = Header & c3_Amount & Separator
            Header = Header & c4_Currency & Separator
            Header = Header & c5_IBANIndicator & Separator
            Header = Header & c6_IBANorAccountNumber & Separator
            Header = Header & c7_BICorSortCode & Separator
            Header = Header & c7_CountryofBeneficiaryBank & Separator
            Header = Header & c8_BeneficiaryBankDetailsLine1 & Separator
            Header = Header & c9_BeneficiaryBankDetailsLine2 & Separator
            Header = Header & c10_IntermediateBank & Separator
            Header = Header & c11_BeneficiaryDetailsLine1 & Separator
            Header = Header & c12_BeneficiaryDetailsLine2 & Separator
            Header = Header & c13_BeneficiaryDetailsLine3 & Separator
            Header = Header & c14_BeneficiaryDetailsCountryISOCode & Separator
            Header = Header & c15_BeneficiaryDetailsLine4 & Separator
            Header = Header & c16_DetailsofPaymentLine1 & Separator
            Header = Header & c17_DetailsofPaymentLine2 & Separator
            Header = Header & c18_DetailsofPaymentLine3 & Separator
            Header = Header & c19_DetailsofPaymentLine4 & Separator
            Header = Header & c20_ExecutionMode & Separator
            Header = Header & c21_FeeChargingMode

            WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim Bankcountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                Line = ""
                EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                Salary = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(6))
                EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(7))
                BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(8))

                BankCountry = IBAN.Substring(0, 2)

                c1_SEPANonSEPAIndicator = "SEPA"
                c2_DebitAccount = CompanyBankAcc
                c3_Amount = Salary
                c4_Currency = "EUR"
                c5_IBANIndicator = "IBAN"
                c6_IBANorAccountNumber = IBAN
                c7_BICorSortCode = ""
                c7_CountryofBeneficiaryBank = ""
                c8_BeneficiaryBankDetailsLine1 = ""
                c9_BeneficiaryBankDetailsLine2 = ""
                c10_IntermediateBank = ""
                c11_BeneficiaryDetailsLine1 = EmpName
                c12_BeneficiaryDetailsLine2 = ""
                c13_BeneficiaryDetailsLine3 = ""
                c14_BeneficiaryDetailsCountryISOCode = BankCountry
                c15_BeneficiaryDetailsLine4 = ""
                c16_DetailsofPaymentLine1 = "Salary of " & Period.DescriptionL
                c17_DetailsofPaymentLine2 = "" '"Pay Request for " & EmpID
                c18_DetailsofPaymentLine3 = "" 'Now.Date
                c19_DetailsofPaymentLine4 = ""
                c20_ExecutionMode = ""
                c21_FeeChargingMode = ""


                Line = Line & c1_SEPANonSEPAIndicator & Separator
                Line = Line & c2_DebitAccount & Separator
                Line = Line & c3_Amount & Separator
                Line = Line & c4_Currency & Separator
                Line = Line & c5_IBANIndicator & Separator
                Line = Line & c6_IBANorAccountNumber & Separator
                Line = Line & c7_BICorSortCode & Separator
                Line = Line & c7_CountryofBeneficiaryBank & Separator
                Line = Line & c8_BeneficiaryBankDetailsLine1 & Separator
                Line = Line & c9_BeneficiaryBankDetailsLine2 & Separator
                Line = Line & c10_IntermediateBank & Separator
                Line = Line & c11_BeneficiaryDetailsLine1 & Separator
                Line = Line & c12_BeneficiaryDetailsLine2 & Separator
                Line = Line & c13_BeneficiaryDetailsLine3 & Separator
                Line = Line & c14_BeneficiaryDetailsCountryISOCode & Separator
                Line = Line & c15_BeneficiaryDetailsLine4 & Separator
                Line = Line & c16_DetailsofPaymentLine1 & Separator
                Line = Line & c17_DetailsofPaymentLine2 & Separator
                Line = Line & c18_DetailsofPaymentLine3 & Separator
                Line = Line & c19_DetailsofPaymentLine4 & Separator
                Line = Line & c20_ExecutionMode & Separator
                Line = Line & c21_FeeChargingMode

                WriteToCSVFile(Line, "")

            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function WriteToCSVFile(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = BankFiledir & "BankFile.csv"
           
            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim F As Boolean = True


        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""

        Dim CompanyCode As String = CType(Me.CmbCompany.SelectedItem, cAdMsCompany).Code

        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, True)
        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ";"

            Dim c1_EmpName As String = ""
            Dim c1_IBAN As String = ""
            Dim c2_PaymentDetails As String = ""
            Dim c3_BIC As String = ""
            Dim c4_Amount As String = ""





            '   WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim Bankcountry As String

            Try


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(6))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(7))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(8))



                    '"SELECT PrTxTrxnHeader.Emp_Code," & _
                    '" PrTxTrxnHeader.TrxHdr_NetSalary," & _
                    '" PrMsEmployees.Emp_FullName, " & _
                    '" PrMsEmployees.Bnk_Code," & _
                    '" PrMsEmployees.Emp_BankAccount," & _
                    '" PrMsEmployees.Bnk_CodeCo," & _
                    '" PrMsEmployees.Emp_BankAccountCo, " & _
                    '" PrMsEmployees.PmtMth_Code," & _
                    '" PrMsEmployees.Emp_IBAN," & _
                    '" PrMsEmployees.Emp_IdentificationCard, " & _
                    '" PrMsEmployees.Emp_BankBenName, " & _


                    ' BankCountry = IBAN.Substring(0, 2)
                    If Salary <> 0 Then
                        Dim Bnk As New cPrAnBanks(BankCode)
                        Dim BIC As String
                        BIC = Me.FindSwiftCode(Bnk, False)

                        c1_EmpName = EmpName
                        c1_IBAN = IBAN
                        c2_PaymentDetails = "Salary of " & Period.DescriptionL
                        c3_BIC = BIC
                        c4_Amount = Salary


                        Line = Line & c1_EmpName & Separator
                        Line = Line & c1_IBAN & Separator
                        Line = Line & c3_BIC & Separator
                        Line = Line & c2_PaymentDetails & Separator
                        Line = Line & c4_Amount & Separator


                        WriteToCSVFile_HandelsBank(Line, "", CompanyCode)
                    End If

                Next
            Catch ex As Exception
                F = False
                Utils.ShowException(ex)
                MsgBox("Error on Employee " & c1_EmpName)
            End Try
            If F Then
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("Unable To Create File", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim F As Boolean = True


        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""

        Dim CompanyCode As String = CType(Me.CmbCompany.SelectedItem, cAdMsCompany).Code

        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ";"


            Dim c1_EmpName As String = ""
            Dim c2_Amount As String = ""
            Dim c3_Curency As String = ""
            Dim c4_IBAN As String = ""
            Dim c5_BIC As String = ""
            Dim c6_PaymentDetails As String = ""






            '   WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim Bankcountry As String

            Try


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(6))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(7))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(8))

                    ' BankCountry = IBAN.Substring(0, 2)
                    If Salary <> 0 Then
                        Dim Bnk As New cPrAnBanks(BankCode)
                        Dim BIC As String
                        BIC = Me.FindSwiftCode(Bnk, False)

                        c1_EmpName = EmpName
                        c2_Amount = Salary
                        c3_Curency = "EUR"
                        c4_IBAN = IBAN
                        c5_BIC = BIC
                        c6_PaymentDetails = "Salary of " & Period.DescriptionL



                        Line = Line & c1_EmpName & Separator
                        Line = Line & c2_Amount & Separator
                        Line = Line & c3_Curency & Separator
                        Line = Line & c4_IBAN & Separator
                        Line = Line & c5_BIC & Separator
                        Line = Line & c6_PaymentDetails & Separator



                        WriteToCSVFile_HandelsBank(Line, "", CompanyCode)
                    End If

                Next
            Catch ex As Exception
                F = False
                Utils.ShowException(ex)
                MsgBox("Error on Employee " & c1_EmpName)
            End Try
            If F Then
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("Unable To Create File", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        EcommBx()
    End Sub
    Private Sub btnEcommbx2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEcommbx2.Click
        EcommBx2()
    End Sub
    Private Sub EcommBx()

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "yyyy.MM.dd")

        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If

        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ","


            Dim c1_type As String = "type"
            Dim c2_doc_num As String = "doc_num"
            Dim c3_is_urgently As String = "is_urgently"
            Dim c4_value_date As String = "value_date"
            Dim c5_target_amount As String = "target_amount"
            Dim c6_target_currency As String = "target_currency"
            Dim c7_ben_name As String = "ben_name "
            Dim c8_ben_addr As String = "ben_addr"
            Dim c9_ben_city As String = "ben_city"
            Dim c10_ben_country As String = "ben_country"
            Dim c11_source_acc As String = "source_acc"
            Dim c12_ben_acc As String = "ben_acc "
            Dim c13_ben_bank_name As String = "ben_bank_name"
            Dim c14_bank_addr As String = "bank_addr "
            Dim c15_bank_city As String = "bank_city"
            Dim c16_bank_country As String = "bank_country "
            Dim c17_ben_bank_bic As String = "ben_bank_bic"
            Dim c18_info_remmitance As String = "info_remmitance"
            Dim c19_charges_acc As String = "charges_acc"

            Header = Header & c1_type & Separator
            Header = Header & c2_doc_num & Separator
            Header = Header & c3_is_urgently & Separator
            Header = Header & c4_value_date & Separator
            Header = Header & c5_target_amount & Separator
            Header = Header & c6_target_currency & Separator
            Header = Header & c7_ben_name & Separator
            Header = Header & c8_ben_addr & Separator
            Header = Header & c9_ben_city & Separator
            Header = Header & c10_ben_country & Separator
            Header = Header & c11_source_acc & Separator
            Header = Header & c12_ben_acc & Separator
            Header = Header & c13_ben_bank_name & Separator
            Header = Header & c14_bank_addr & Separator
            Header = Header & c15_bank_city & Separator
            Header = Header & c16_bank_country & Separator
            Header = Header & c17_ben_bank_bic & Separator
            Header = Header & c18_info_remmitance & Separator
            Header = Header & c19_charges_acc

            WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If


                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BANKcountry = IBAN.Substring(0, 2)
                    BenCountry = IBAN.Substring(0, 2)
                    Dim Bank As New cPrAnBanks(BankCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)

                    c1_type = "ACC_TO_ACC_SEPA"
                    c2_doc_num = "LINE_" & (i + 1).ToString.PadLeft(4, "0")
                    c3_is_urgently = 0
                    c4_value_date = ExecutionDate
                    c5_target_amount = Salary
                    c6_target_currency = "EUR"
                    c7_ben_name = BenefName

                    Dim Adr1 As String
                    Adr1 = Emp.Address1
                    Adr1 = Adr1.Replace(",", " ")
                    Adr1 = Adr1.Replace("@", " ")
                    Adr1 = Adr1.Replace("&", " ")
                    Adr1 = Adr1.Replace(";", " ")
                    Adr1 = Adr1.Replace("?", " ")
                    Adr1 = Adr1.Replace("#", " ")
                    Adr1 = Adr1.Replace("%", " ")

                    Dim Adr2 As String
                    Adr2 = Emp.Address2
                    Adr2 = Adr2.Replace(",", " ")
                    Adr2 = Adr2.Replace("@", " ")
                    Adr2 = Adr2.Replace("&", " ")
                    Adr2 = Adr2.Replace(";", " ")
                    Adr2 = Adr2.Replace("?", " ")
                    Adr2 = Adr2.Replace("#", " ")
                    Adr2 = Adr2.Replace("%", " ")

                    c8_ben_addr = Adr1 & " " & Emp.PostCode
                    c9_ben_city = Adr2

                    Dim Country As New cAdAnCountries(Emp.Cou_Code)
                    c10_ben_country = BenCountry

                    c11_source_acc = CompanyBankAcc
                    c12_ben_acc = IBAN
                    c13_ben_bank_name = ""
                    c14_bank_addr = ""
                    c15_bank_city = ""
                    c16_bank_country = BANKcountry

                    Dim Swift As String
                    Swift = FindSwiftCode(Bank, False)
                    c17_ben_bank_bic = Swift
                    c18_info_remmitance = "Salary of " & Period.DescriptionL
                    c19_charges_acc = ""



                    Line = Line & c1_type & Separator
                    Line = Line & c2_doc_num & Separator
                    Line = Line & c3_is_urgently & Separator
                    Line = Line & c4_value_date & Separator
                    Line = Line & c5_target_amount & Separator
                    Line = Line & c6_target_currency & Separator
                    Line = Line & c7_ben_name & Separator
                    Line = Line & c8_ben_addr & Separator
                    Line = Line & c9_ben_city & Separator
                    Line = Line & c10_ben_country & Separator
                    Line = Line & c11_source_acc & Separator
                    Line = Line & c12_ben_acc & Separator
                    Line = Line & c13_ben_bank_name & Separator
                    Line = Line & c14_bank_addr & Separator
                    Line = Line & c15_bank_city & Separator
                    Line = Line & c16_bank_country & Separator
                    Line = Line & c17_ben_bank_bic & Separator
                    Line = Line & c18_info_remmitance & Separator
                    Line = Line & c19_charges_acc & Separator

                    WriteToCSVFile(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub EcommBx2()

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "yyyy.MM.dd")

        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If

        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ";"


            Dim c1_type As String = "type"
            Dim c2_doc_num As String = "doc_num"
            Dim c3_is_urgently As String = "is_urgently"
            Dim c4_value_date As String = "value_date"
            Dim c5_target_amount As String = "target_amount"
            Dim c6_target_currency As String = "target_currency"
            Dim c7_ben_name As String = "ben_name "
            Dim c8_ben_addr As String = "ben_addr"
            Dim c9_ben_city As String = "ben_city"
            Dim c10_ben_country As String = "ben_country"
            Dim c11_source_acc As String = "source_acc"
            Dim c12_ben_acc As String = "ben_acc "
            Dim c13_ben_bank_name As String = "ben_bank_name"
            Dim c14_bank_addr As String = "bank_addr "
            Dim c15_bank_city As String = "bank_city"
            Dim c16_bank_country As String = "bank_country "
            Dim c17_ben_bank_bic As String = "ben_bank_bic"
            Dim c18_info_remmitance As String = "info_remmitance"
            Dim c19_charges_acc As String = "charges_acc"

            Header = Header & c1_type & Separator
            Header = Header & c2_doc_num & Separator
            Header = Header & c3_is_urgently & Separator
            Header = Header & c4_value_date & Separator
            Header = Header & c5_target_amount & Separator
            Header = Header & c6_target_currency & Separator
            Header = Header & c7_ben_name & Separator
            Header = Header & c8_ben_addr & Separator
            Header = Header & c9_ben_city & Separator
            Header = Header & c10_ben_country & Separator
            Header = Header & c11_source_acc & Separator
            Header = Header & c12_ben_acc & Separator
            Header = Header & c13_ben_bank_name & Separator
            Header = Header & c14_bank_addr & Separator
            Header = Header & c15_bank_city & Separator
            Header = Header & c16_bank_country & Separator
            Header = Header & c17_ben_bank_bic & Separator
            Header = Header & c18_info_remmitance & Separator
            Header = Header & c19_charges_acc

            ' WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If


                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BANKcountry = IBAN.Substring(0, 2)
                    BenCountry = IBAN.Substring(0, 2)
                    Dim Bank As New cPrAnBanks(BankCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)

                    c1_type = "ACC_TO_ACC_SEPA"
                    c2_doc_num = "LINE_" & (i + 1).ToString.PadLeft(4, "0")
                    c3_is_urgently = 0
                    c4_value_date = ExecutionDate
                    c5_target_amount = Salary
                    c6_target_currency = "EUR"
                    c7_ben_name = EmpName

                    Dim Adr1 As String
                    Adr1 = Emp.Address1
                    Adr1 = Adr1.Replace(",", " ")
                    Adr1 = Adr1.Replace("@", " ")
                    Adr1 = Adr1.Replace("&", " ")
                    Adr1 = Adr1.Replace(";", " ")
                    Adr1 = Adr1.Replace("?", " ")
                    Adr1 = Adr1.Replace("#", " ")
                    Adr1 = Adr1.Replace("%", " ")

                    Dim Adr2 As String
                    Adr2 = Emp.Address2
                    Adr2 = Adr2.Replace(",", " ")
                    Adr2 = Adr2.Replace("@", " ")
                    Adr2 = Adr2.Replace("&", " ")
                    Adr2 = Adr2.Replace(";", " ")
                    Adr2 = Adr2.Replace("?", " ")
                    Adr2 = Adr2.Replace("#", " ")
                    Adr2 = Adr2.Replace("%", " ")

                    c8_ben_addr = Adr1 & " " & Emp.PostCode
                    c9_ben_city = Adr2

                    Dim Country As New cAdAnCountries(Emp.Cou_Code)
                    c10_ben_country = BenCountry

                    c11_source_acc = CompanyBankAcc
                    c12_ben_acc = IBAN
                    c13_ben_bank_name = ""
                    c14_bank_addr = ""
                    c15_bank_city = ""
                    c16_bank_country = BANKcountry

                    Dim Swift As String
                    Swift = FindSwiftCode(Bank, False)
                    c17_ben_bank_bic = Swift
                    c18_info_remmitance = "Salary of " & Period.DescriptionL
                    c19_charges_acc = ""



                    Line = Line & i + 1 & Separator
                    Line = Line & c12_ben_acc & Separator
                    Line = Line & c5_target_amount & Separator
                    Line = Line & c18_info_remmitance & Separator
                    Line = Line & c17_ben_bank_bic & Separator
                    Line = Line & c7_ben_name


                    'Line = Line & c2_doc_num & Separator
                    'Line = Line & c3_is_urgently & Separator
                    'Line = Line & c4_value_date & Separator

                    'Line = Line & c6_target_currency & Separator
                    'Line = Line & c7_ben_name & Separator
                    'Line = Line & c8_ben_addr & Separator
                    'Line = Line & c9_ben_city & Separator
                    'Line = Line & c10_ben_country & Separator
                    'Line = Line & c11_source_acc & Separator

                    'Line = Line & c13_ben_bank_name & Separator
                    'Line = Line & c14_bank_addr & Separator
                    'Line = Line & c15_bank_city & Separator
                    'Line = Line & c16_bank_country & Separator


                    'Line = Line & c19_charges_acc & Separator

                    WriteToCSVFile(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function WriteToCSVFile_HandelsBank(ByVal Line As String, ByVal fName As String, ByVal CompanyCode As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = BankFiledir & CompanyCode & "_BankFile.csv"

            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    Private Sub CorvertBankFileToXML_RCB(ByVal txtFineNameAndPath As String, ByVal FilePath As String, ByVal ChangeName As Boolean, ByVal IsEurobank As Boolean)

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try




            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = txtFineNameAndPath
            Dim FF As String
            If Not ChangeName Then
                FF = "DPSXMLDCI6.xml"
                Me.XMLGlobalFileName = FilePath & FF
            Else
                FF = "DPSXMLDCI6_OtherBanks.xml"
                Me.XMLGlobalFileName = FilePath & FF
            End If

            InitFile = True
            Dim Exx As New Exception
            Dim Ar As String


            '------------------------------------------------------------------
            'Open for reading in order to Read Total employees and Total Amount'
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Dim TotalAmount As Double = 0
            Dim sTotalAmount As String = ""
            Dim totalEmployees As String = ""

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "02"
                        Lines = Lines + 1
                        TotalAmount = TotalAmount + Trim(Line.Substring(5, 15))
                End Select
            Loop
            sTotalAmount = StringtoDecimal2(TotalAmount.ToString)
            totalEmployees = Lines.ToString
            param_file.Close()
            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------


            '------------------------------------------------------------------
            'Open for reading in order to Write XML File
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Lines = 0


            Dim ExecutionDate As String
            Dim MycompanyName As String
            Dim CompanyIBAN As String
            Dim CompanySwiftCode As String

            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "01"
                        Dim YY As String = Trim(Line.Substring(115, 4))
                        Dim MM As String = Trim(Line.Substring(113, 2))
                        Dim DD As String = Trim(Line.Substring(111, 2))
                        ExecutionDate = YY & "-" & MM & "-" & DD
                        MycompanyName = (Trim(Line.Substring(7, 70)))
                        CompanyIBAN = Trim(Line.Substring(77, 34))
                        CompanySwiftCode = "RCBLCY2I"
                        Write_SEPA_Header_RCB(Line, totalEmployees, sTotalAmount, IsEurobank, FF)
                    Case "02"
                        Lines = Lines + 1
                        Write_SEPA_LINE_RCB(Line, Lines.ToString, IsEurobank, ExecutionDate, MycompanyName, CompanyIBAN, CompanySwiftCode)
                End Select
                Application.DoEvents()
            Loop

            'WL("</PmtInf>")
            WL("</CstmrCdtTrfInitn>")
            WL("</Document>")

            param_file.Close()

            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------

            MsgBox("Bank File is Converted to .xml (" & Me.XMLGlobalFileName & ")", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default



    End Sub
    Public Sub Write_SEPA_Header_RCB(ByVal Line As String, ByVal Totalemployees As String, ByVal TotalAmount As String, ByVal IsEurobank As Boolean, ByVal FileName As String)



        Dim sCreationDateTime As String = Format(Now.Date, "yyyy-MM-dd")
        sCreationDateTime = sCreationDateTime & "T" & Now.Hour.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Minute.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Second.ToString.PadLeft(2, "0")

        Dim sTotalTransactions As String = Totalemployees
        Dim sTotalAmount As String = TotalAmount
        Dim sCompanyName As String = Trim(Line.Substring(7, 70))
        Dim sCompanyDigitCode As String = Trim(Line.Substring(2, 5))

        Dim YY As String = Trim(Line.Substring(115, 4))
        Dim MM As String = Trim(Line.Substring(113, 2))
        Dim DD As String = Trim(Line.Substring(111, 2))
        Dim sExecutionDate As String = YY & "-" & MM & "-" & DD
        Dim sIBAN As String = Trim(Line.Substring(77, 34))
        Dim SBIC As String = ""

        ' Addition for Eurobank
        'If IsEurobank Then
        ' SBIC = Trim(Line.Substring(500, 8))
        ' End If

        Debug.WriteLine(Line)





        '''''''''''
        WL(" <Document xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03"" xsi:schemaLocation=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03 pain.001.001.03.xsd"">")
        WL("<CstmrCdtTrfInitn>")
        WL("<GrpHdr>")
        WL("<MsgId>" & FileName & "</MsgId>")
        WL("<CreDtTm>" & sCreationDateTime & "</CreDtTm>")
        WL("<NbOfTxs>" & sTotalTransactions & "</NbOfTxs>")
        WL("<CtrlSum>" & sTotalAmount & "</CtrlSum>")
        WL("<InitgPty>")
        WL("<Nm>" & Replace(sCompanyName, "&", "&amp;") & "</Nm>")
        WL("<Id>")
        WL("<OrgId>")
        WL("<Othr>")
        WL("<Id>" & sCompanyDigitCode & "</Id>")
        WL("</Othr>")
        WL("</OrgId>")
        WL("</Id>")
        WL("</InitgPty>")
        WL("</GrpHdr>")
        ''''''''''
        '  If IsEurobank Then
        'WL("<PmtInf>Payroll Payment</PmtInf>")
        'Else

        ''''''''''



    End Sub
    Public Sub Write_SEPA_LINE_RCB(ByVal Line As String, ByVal sLineNo As String, ByVal IsEurobank As Boolean, ByVal Executiondate As String, ByVal MyCompanyName As String, ByVal CompanyIBAN As String, ByVal CompanySwiftCode As String)

        Dim sAmount As String = Trim(Line.Substring(5, 15))
        sAmount = StringtoDecimal2(sAmount)


        Dim sBIC As String = Trim(Line.Substring(20, 11))
        Dim semployeename As String = Trim(Line.Substring(65, 70))
        Dim sIBAN As String = Trim(Line.Substring(31, 34))
        Dim sCountryCode As String = Trim(Line.Substring(139, 2))
        Dim sPaymentDesc As String = Trim(Line.Substring(141, 140))
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<PmtInf>")
        'End If
        '''''''''''

        WL("<PmtInfId>" & sLineNo & "</PmtInfId>")
        WL("<PmtMtd>TRF</PmtMtd>")
        WL("<PmtTpInf>")
        WL("<SvcLvl>")
        WL("<Cd>SEPA</Cd>")
        WL("</SvcLvl>")
        WL("</PmtTpInf>")
        WL("<ReqdExctnDt>" & Executiondate & "</ReqdExctnDt>")
        WL("<Dbtr>")
        WL("<Nm>" & MyCompanyName & "</Nm>")
        WL("</Dbtr>")
        WL("<DbtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & CompanyIBAN & "</IBAN>")
        WL("</Id>")
        WL("</DbtrAcct>")
        WL("<DbtrAgt>")
        WL("<FinInstnId>")
        WL("<BIC>" & CompanySwiftCode & "</BIC>")
        WL("</FinInstnId>")
        WL("</DbtrAgt>")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        WL("<CdtTrfTxInf>")

        WL("<PmtId>")
        WL("<InstrId>" & sLineNo & "</InstrId>")
        WL("<EndToEndId>" & sLineNo & "</EndToEndId>")
        WL("</PmtId>")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'WL("<ReqdExctnDt>" & Executiondate & "</ReqdExctnDt>")
        'WL("<Dbtr>")
        'WL("<Nm>" & MyCompanyName & "</Nm>")
        'WL("</Dbtr>")
        'WL("<DbtrAcct>")
        'WL("<Id>")
        'WL("<IBAN>" & CompanyIBAN & "</IBAN>")
        'WL("</Id>")
        'WL("</DbtrAcct>")
        'WL("<DbtrAgt>")
        'WL("<FinInstnId>")
        'WL("BIC>" & CompanySwiftCode & "</BIC>")
        'WL("</FinInstnId>")
        'WL("</DbtrAgt>")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        WL("<PmtTpInf>")
        WL("<SvcLvl>")
        WL("<Cd>SEPA</Cd>")
        WL("</SvcLvl>")
        WL("<CtgyPurp>")
        WL("<Cd>SALA</Cd>")
        WL("</CtgyPurp>")
        WL("</PmtTpInf>")

        WL("<Amt>")
        WL("<InstdAmt Ccy=""EUR"">" & sAmount & "</InstdAmt>")
        WL("</Amt>")

        WL("<ChrgBr>SLEV</ChrgBr>")

        WL("<CdtrAgt>")
        WL("<FinInstnId>")
        WL("<BIC>" & sBIC & "</BIC>")
        WL("</FinInstnId>")
        WL("</CdtrAgt>")

        WL("<Cdtr>")
        WL("<Nm>" & semployeename & "</Nm>")
        WL("<PstlAdr>")
        WL("<Ctry>" & sCountryCode & "</Ctry>")
        'WL("<AdrLine>address line1</AdrLine>")
        'WL("<AdrLine>address line2</AdrLine>")
        WL("</PstlAdr>")
        'WL("<Id>")
        'WL("<PrvtId>")
        'WL("<DtAndPlcOfBirth>")
        'WL("<BirthDt>1998-03-30</BirthDt>")
        'WL("<PrvcOfBirth>Nicosia</PrvcOfBirth>")
        'WL("<CityOfBirth>Nicosia</CityOfBirth>")
        'WL("<CtryOfBirth>CY</CtryOfBirth>")
        'WL("</DtAndPlcOfBirth>")
        'WL("</PrvtId>")
        'WL("</Id>")
        WL("</Cdtr>")
        WL("<CdtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & UCase(sIBAN) & "</IBAN>")
        WL("</Id>")
        WL("</CdtrAcct>")


        WL("<RmtInf>")
        WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        WL("</RmtInf>")


        WL("</CdtTrfTxInf>")
        '''''''''''''''''''''''''''''''''''''''''''
        WL("</PmtInf>")
        '        <CdtTrfTxInf>
        '<PmtId>
        '<InstrId>InstrId 3</InstrId>
        '<EndToEndId>EndToEndId 3</EndToEndId>
        '</PmtId>
        '<PmtTpInf>
        '<SvcLvl>
        '<Cd>SEPA</Cd>
        '</SvcLvl>
        '<CtgyPurp>
        '<Cd>SALA</Cd>
        '</CtgyPurp>
        '</PmtTpInf>
        '<Amt>
        '<InstdAmt Ccy="EUR">1100.00</InstdAmt>
        '</Amt>
        '<ChrgBr>SLEV</ChrgBr>
        '<CdtrAgt>
        '<FinInstnId>
        '<BIC>CCBKCY2N</BIC>
        '</FinInstnId>
        '</CdtrAgt>
        '<Cdtr>
        '<Nm>Creditor 3</Nm>
        '<PstlAdr>
        '<Ctry>CY</Ctry>
        '<AdrLine>address line 1 for customer3</AdrLine>
        '</PstlAdr>
        '<Id>
        '<PrvtId>
        '<Othr>
        '<Id>U1234</Id>
        '</Othr>
        '</PrvtId>
        '</Id>
        '</Cdtr>
        '<CdtrAcct>
        '<Id>
        '<IBAN>CY38007101100000000020333607</IBAN>
        '</Id>
        '</CdtrAcct>
        'If IsEurobank Then
        '    WL("<RmtInf>")
        '    WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        '    WL("</RmtInf>")
        'End If
        '</CdtTrfTxInf>


    End Sub

    Private Sub CorvertBankFileToXML_ASTRO(ByVal txtFineNameAndPath As String, ByVal FilePath As String, ByVal ChangeName As Boolean, ByVal IsEurobank As Boolean)

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try




            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = txtFineNameAndPath
            Dim FF As String
            If Not ChangeName Then
                FF = "DPSXMLDCI6.xml"
                Me.XMLGlobalFileName = FilePath & FF
            Else
                FF = "DPSXMLDCI6_OtherBanks.xml"
                Me.XMLGlobalFileName = FilePath & FF
            End If

            InitFile = True
            Dim Exx As New Exception
            Dim Ar As String


            '------------------------------------------------------------------
            'Open for reading in order to Read Total employees and Total Amount'
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Dim TotalAmount As Double = 0
            Dim sTotalAmount As String = ""
            Dim totalEmployees As String = ""

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "02"
                        Lines = Lines + 1
                        TotalAmount = TotalAmount + Trim(Line.Substring(5, 15))
                End Select
            Loop
            sTotalAmount = StringtoDecimal2(TotalAmount.ToString)
            totalEmployees = Lines.ToString
            param_file.Close()
            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------


            '------------------------------------------------------------------
            'Open for reading in order to Write XML File
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Lines = 0


            Dim ExecutionDate As String
            Dim MycompanyName As String
            Dim CompanyIBAN As String
            Dim CompanySwiftCode As String

            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "01"
                        Dim YY As String = Trim(Line.Substring(115, 4))
                        Dim MM As String = Trim(Line.Substring(113, 2))
                        Dim DD As String = Trim(Line.Substring(111, 2))
                        ExecutionDate = YY & "-" & MM & "-" & DD
                        MycompanyName = (Trim(Line.Substring(7, 70)))
                        CompanyIBAN = Trim(Line.Substring(77, 34))
                        CompanySwiftCode = "PIRBCY2N"
                        Write_SEPA_Header_ASTRO(Line, totalEmployees, sTotalAmount, IsEurobank, FF)

                    Case "02"
                        Lines = Lines + 1
                        Write_SEPA_LINE_ASTRO(Line, Lines.ToString, IsEurobank, ExecutionDate, MycompanyName, CompanyIBAN, CompanySwiftCode)
                End Select
                Application.DoEvents()
            Loop

            WL("</PmtInf>")
            WL("</CstmrCdtTrfInitn>")
            WL("</Document>")

            param_file.Close()

            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------

            MsgBox("Bank File is Converted to .xml (" & Me.XMLGlobalFileName & ")", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default



    End Sub
    Public Sub Write_SEPA_Header_ASTRO(ByVal Line As String, ByVal Totalemployees As String, ByVal TotalAmount As String, ByVal IsEurobank As Boolean, ByVal FileName As String)



        Dim sCreationDateTime As String = Format(Now.Date, "yyyy-MM-dd")
        sCreationDateTime = sCreationDateTime & "T" & Now.Hour.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Minute.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Second.ToString.PadLeft(2, "0")

        Dim sTotalTransactions As String = Totalemployees
        Dim sTotalAmount As String = TotalAmount
        Dim sCompanyName As String = Trim(Line.Substring(7, 70))
        Dim sCompanyDigitCode As String = Trim(Line.Substring(2, 5))

        Dim YY As String = Trim(Line.Substring(115, 4))
        Dim MM As String = Trim(Line.Substring(113, 2))
        Dim DD As String = Trim(Line.Substring(111, 2))
        Dim sExecutionDate As String = YY & "-" & MM & "-" & DD
        Dim sIBAN As String = Trim(Line.Substring(77, 34))
        Dim SBIC As String = ""

        ' Addition for Eurobank
        'If IsEurobank Then
        ' SBIC = Trim(Line.Substring(500, 8))
        ' End If

        Debug.WriteLine(Line)



        WL("<?xml version=""1.0"" encoding=""UTF-8""?>")
        WL(" <Document xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03"">")
        WL("<CstmrCdtTrfInitn>")
        WL("<GrpHdr>")
        WL("<MsgId>" & "1_" & sCreationDateTime & "</MsgId>")
        WL("<CreDtTm>" & sCreationDateTime & "</CreDtTm>")
        WL("<NbOfTxs>" & sTotalTransactions & "</NbOfTxs>")
        WL("<CtrlSum>" & sTotalAmount & "</CtrlSum>")
        WL("<InitgPty>")
        WL("<Nm>" & Replace(sCompanyName, "&", "&amp;") & "</Nm>")

        'WL("<Id>")
        'WL("<OrgId>")
        'WL("<Othr>")
        'WL("<Id>" & sCompanyDigitCode & "</Id>")
        'WL("</Othr>")
        'WL("</OrgId>")
        'WL("</Id>")
        WL("</InitgPty>")
        WL("</GrpHdr>")
        ''''''''''
        '  If IsEurobank Then
        'WL("<PmtInf>Payroll Payment</PmtInf>")
        'Else

        ''''''''''



    End Sub
    Public Sub Write_SEPA_LINE_ASTRO(ByVal Line As String, ByVal sLineNo As String, ByVal IsEurobank As Boolean, ByVal Executiondate As String, ByVal MyCompanyName As String, ByVal CompanyIBAN As String, ByVal CompanySwiftCode As String)

        Dim sAmount As String = Trim(Line.Substring(5, 15))
        sAmount = StringtoDecimal2(sAmount)


        Dim sBIC As String = Trim(Line.Substring(20, 11))
        Dim semployeename As String = Trim(Line.Substring(65, 70))
        Dim sIBAN As String = Trim(Line.Substring(31, 34))
        Dim sCountryCode As String = Trim(Line.Substring(139, 2))
        Dim sPaymentDesc As String = Trim(Line.Substring(141, 140))
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If sLineNo = "1" Then
            WL("<PmtInf>")

            WL("<PmtInfId>" & sLineNo & "</PmtInfId>")
            WL("<PmtMtd>TRF</PmtMtd>")
            WL("<PmtTpInf>")

            WL("<SvcLvl>")
            WL("<Cd>SEPA</Cd>")
            WL("</SvcLvl>")

            WL("</PmtTpInf>")

            WL("<ReqdExctnDt>" & Executiondate & "</ReqdExctnDt>")
            WL("<Dbtr>")
            WL("<Nm>" & MyCompanyName & "</Nm>")
            WL("</Dbtr>")

            WL("<DbtrAcct>")

            WL("<Id>")
            WL("<IBAN>" & CompanyIBAN & "</IBAN>")
            WL("</Id>")

            WL("</DbtrAcct>")

            WL("<DbtrAgt>")
            WL("<FinInstnId>")
            WL("<BIC>" & CompanySwiftCode & "</BIC>")
            WL("</FinInstnId>")
            WL("</DbtrAgt>")

            '  WL("</PmtInf>")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        WL("<CdtTrfTxInf>")

        WL("<PmtId>")
        WL("<InstrId>" & sLineNo & "</InstrId>")
        WL("<EndToEndId>" & sLineNo & "</EndToEndId>")
        WL("</PmtId>")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'WL("<ReqdExctnDt>" & Executiondate & "</ReqdExctnDt>")
        'WL("<Dbtr>")
        'WL("<Nm>" & MyCompanyName & "</Nm>")
        'WL("</Dbtr>")
        'WL("<DbtrAcct>")
        'WL("<Id>")
        'WL("<IBAN>" & CompanyIBAN & "</IBAN>")
        'WL("</Id>")
        'WL("</DbtrAcct>")
        'WL("<DbtrAgt>")
        'WL("<FinInstnId>")
        'WL("BIC>" & CompanySwiftCode & "</BIC>")
        'WL("</FinInstnId>")
        'WL("</DbtrAgt>")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        WL("<PmtTpInf>")

        WL("<SvcLvl>")
        WL("<Cd>SEPA</Cd>")
        WL("</SvcLvl>")

        WL("<CtgyPurp>")
        WL("<Cd>SALA</Cd>")
        WL("</CtgyPurp>")

        WL("</PmtTpInf>")

        WL("<Amt>")
        WL("<InstdAmt Ccy=""EUR"">" & sAmount & "</InstdAmt>")
        WL("</Amt>")

        WL("<ChrgBr>SHAR</ChrgBr>")

        WL("<CdtrAgt>")
        WL("<FinInstnId>")
        WL("<BIC>" & sBIC & "</BIC>")
        WL("</FinInstnId>")
        WL("</CdtrAgt>")

        WL("<Cdtr>")
        WL("<Nm>" & semployeename & "</Nm>")
        WL("<PstlAdr>")
        WL("<Ctry>" & sCountryCode & "</Ctry>")
        'WL("<AdrLine>address line1</AdrLine>")
        'WL("<AdrLine>address line2</AdrLine>")
        WL("</PstlAdr>")
        'WL("<Id>")
        'WL("<PrvtId>")
        'WL("<DtAndPlcOfBirth>")
        'WL("<BirthDt>1998-03-30</BirthDt>")
        'WL("<PrvcOfBirth>Nicosia</PrvcOfBirth>")
        'WL("<CityOfBirth>Nicosia</CityOfBirth>")
        'WL("<CtryOfBirth>CY</CtryOfBirth>")
        'WL("</DtAndPlcOfBirth>")
        'WL("</PrvtId>")
        'WL("</Id>")
        WL("</Cdtr>")
        WL("<CdtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & UCase(sIBAN) & "</IBAN>")
        WL("</Id>")
        WL("</CdtrAcct>")

        WL("<Purp>")
        WL("<Cd>CASH</Cd>")
        WL("</Purp>")


        WL("<RmtInf>")
        WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        WL("</RmtInf>")


        WL("</CdtTrfTxInf>")
        '''''''''''''''''''''''''''''''''''''''''''
        ' WL("</PmtInf>")
        '        <CdtTrfTxInf>
        '<PmtId>
        '<InstrId>InstrId 3</InstrId>
        '<EndToEndId>EndToEndId 3</EndToEndId>
        '</PmtId>
        '<PmtTpInf>
        '<SvcLvl>
        '<Cd>SEPA</Cd>
        '</SvcLvl>
        '<CtgyPurp>
        '<Cd>SALA</Cd>
        '</CtgyPurp>
        '</PmtTpInf>
        '<Amt>
        '<InstdAmt Ccy="EUR">1100.00</InstdAmt>
        '</Amt>
        '<ChrgBr>SLEV</ChrgBr>
        '<CdtrAgt>
        '<FinInstnId>
        '<BIC>CCBKCY2N</BIC>
        '</FinInstnId>
        '</CdtrAgt>
        '<Cdtr>
        '<Nm>Creditor 3</Nm>
        '<PstlAdr>
        '<Ctry>CY</Ctry>
        '<AdrLine>address line 1 for customer3</AdrLine>
        '</PstlAdr>
        '<Id>
        '<PrvtId>
        '<Othr>
        '<Id>U1234</Id>
        '</Othr>
        '</PrvtId>
        '</Id>
        '</Cdtr>
        '<CdtrAcct>
        '<Id>
        '<IBAN>CY38007101100000000020333607</IBAN>
        '</Id>
        '</CdtrAcct>
        'If IsEurobank Then
        '    WL("<RmtInf>")
        '    WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        '    WL("</RmtInf>")
        'End If
        '</CdtTrfTxInf>


    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim F As Boolean = True


        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""

        Dim CompanyCode As String = CType(Me.CmbCompany.SelectedItem, cAdMsCompany).Code

        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If




        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ";"


            Dim c1_EmpName As String = ""
            Dim c2_Amount As String = ""
            Dim c3_Curency As String = ""
            Dim c4_IBAN As String = ""
            Dim c5_BIC As String = ""
            Dim c6_PaymentDetails As String = ""






            '   WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim Bankcountry As String

            Dim RefNo As String
            Dim ExecutionDate As String

            Try
                RefNo = "Pay of " & Period.DescriptionL
                ExecutionDate = Format(Me.DatePay.Value.Date, "yyyyMMdd")

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(6))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(7))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(8))

                    ' BankCountry = IBAN.Substring(0, 2)
                    If Salary <> 0 Then
                        Dim Bnk As New cPrAnBanks(BankCode)
                        Dim BIC As String
                        BIC = Me.FindSwiftCode(Bnk, True)
                        BIC = BIC.Replace("XXX", "")

                        c1_EmpName = EmpName
                        c2_Amount = Salary
                        c3_Curency = "EUR"
                        c4_IBAN = IBAN
                        c5_BIC = BIC
                        c6_PaymentDetails = "Salary of " & Period.DescriptionL


                        Line = RefNo '1
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = ExecutionDate '2
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "EUR" '3
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = Format(Salary, "0.00") '4
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '5
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = CompanyBankAcc '6
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = BIC '7
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '8
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = BankDesc '9
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '10
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '11
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '12
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = IBAN '13
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = BenefName '14
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '15
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '16
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '17
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '18
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '19
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '20
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '21
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '22
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '23
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '24
                        WriteToTextFile_Barclays(Line, "", CompanyCode)
                        Line = "" '25
                        WriteToTextFile_Barclays(Line, "", CompanyCode)



                    End If

                Next
            Catch ex As Exception
                F = False
                Utils.ShowException(ex)
                MsgBox("Error on Employee " & c1_EmpName)
            End Try
            If F Then
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("Unable To Create File", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function WriteToTextFile_Barclays(ByVal Line As String, ByVal fName As String, ByVal CompanyCode As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = BankFiledir & CompanyCode & "_Barclays.txt"

            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

    
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        CreateSEPA_AlphaBank_Text(True)
        CreateSEPA_AlphaBank_Text(False)
    End Sub
    Private Sub CreateSEPA_AlphaBank_Text(ByVal OnlyAlpha As Boolean)

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet



        EmployeeBankCode = "ALPHA"



        ds = PrepareDSForReport_ForAlphaBank(Includeinactive, EmployeeBankCode, OnlyAlpha)


        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If



        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "dd/MM/yyyy")

        If OnlyAlpha Then
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String

                Dim Separator As String = "	"

                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c13_RemInfo As String = "From Description"
                Dim c14_RemInfo As String = "To Description"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator
                Header = Header & c13_RemInfo & Separator


                'WriteTotxtFile_AlphaBank(Header, "")

                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String

                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If


                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If


                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)
                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)



                        c1_RefNo = i + 1
                        c2_TranCode = "2"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = BankAccount
                        '    c4_BenAccount = IBAN



                        c5_Amount = Salary
                        'c5_Amount = c5_Amount.Replace(".", ",")

                        c6_Currency = "EUR"
                        c13_RemInfo = "Payroll " & Period.DescriptionL
                        c14_RemInfo = "Payroll " & Period.DescriptionL

                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_RemInfo

                        WriteTotxtFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File with ONLY Alpha Bank is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no Employees for ONLY ALPHA Bank maching the Criteria", MsgBoxStyle.Information)
            End If
        Else
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String

                Dim Separator As String = "	"


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c7_benName As String = "Beneficiary Name"
                Dim c8_benAddr As String = "Beneficiary's Address "
                Dim c9_benCity As String = "Beneficiary City "
                Dim c10_ValDate As String = "Value Date"
                Dim c11_Details As String = "Details of Charges"
                Dim c12_RemInfoCode As String = "Remittance Info Code"
                Dim c13_RemInfo As String = "Remittance Info"
                Dim c14_BenBankBIC As String = "Beneficiary Bank's BIC"
                Dim c15_InterBankBIC As String = "Intermediary bank BIC"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator

                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator


                Header = Header & c7_benName & Separator
                Header = Header & c8_benAddr & Separator

                Header = Header & "" & Separator

                Header = Header & c9_benCity & Separator

                Header = Header & "" & Separator

                Header = Header & c10_ValDate & Separator
                Header = Header & c11_Details & Separator
                Header = Header & c12_RemInfoCode & Separator
                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_BenBankBIC & Separator
                Header = Header & c15_InterBankBIC


                'WriteTotxtFile_AlphaBank(Header, "")

                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If


                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If


                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)
                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "4"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN

                        c5_Amount = Salary
                        'c5_Amount = c5_Amount.Replace(".", ",")
                        Dim Adr1 As String

                        Adr1 = Emp.Address1
                        Adr1 = Adr1.Replace(",", " ")
                        Adr1 = Adr1.Replace("@", " ")
                        Adr1 = Adr1.Replace("@", " ")
                        Adr1 = Adr1.Replace("&", " ")
                        Adr1 = Adr1.Replace(";", " ")
                        Adr1 = Adr1.Replace("?", " ")
                        Adr1 = Adr1.Replace("#", " ")
                        Adr1 = Adr1.Replace("%", " ")

                        Dim Adr2 As String
                        Adr2 = Emp.Address2
                        Adr2 = Adr2.Replace(",", " ")
                        Adr2 = Adr2.Replace("@", " ")
                        Adr2 = Adr2.Replace("@", " ")
                        Adr2 = Adr2.Replace("&", " ")
                        Adr2 = Adr2.Replace(";", " ")
                        Adr2 = Adr2.Replace("?", " ")
                        Adr2 = Adr2.Replace("#", " ")
                        Adr2 = Adr2.Replace("%", " ")


                        c6_Currency = "EUR"
                        c7_benName = EmpName
                        c8_benAddr = Adr1 & Emp.PostCode
                        c9_benCity = Adr2
                        c10_ValDate = ExecutionDate
                        c11_Details = "SHA"
                        c12_RemInfoCode = "INV"
                        c13_RemInfo = "Salary of " & Period.DescriptionL

                        Dim Swift As String
                        Swift = FindSwiftCode(Bank, False)
                        c14_BenBankBIC = Swift
                        c15_InterBankBIC = ""


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator

                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator

                        Line = Line & c7_benName & Separator
                        Line = Line & c8_benAddr & Separator

                        Line = Line & "" & Separator

                        Line = Line & c9_benCity & Separator

                        Line = Line & "" & Separator

                        Line = Line & c10_ValDate & Separator
                        Line = Line & c11_Details & Separator
                        Line = Line & c12_RemInfoCode & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_BenBankBIC & Separator
                        Line = Line & c15_InterBankBIC

                        WriteTotxtFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
            End If

        End If
    End Sub
    Private Sub CreateSEPA_AlphaBank_Text_2(ByVal OnlyAlpha As Boolean)

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet



        EmployeeBankCode = "ALPHA"



        ds = PrepareDSForReport_ForAlphaBank(Includeinactive, EmployeeBankCode, OnlyAlpha)


        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If



        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "dd/MM/yyyy")

        If OnlyAlpha Then
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String

                Dim Separator As String = "	"


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c7_benName As String = "Beneficiary Name"
                Dim c8_benAddr As String = "Beneficiary's Address "
                Dim c9_benCity As String = "Beneficiary City "
                Dim c10_ValDate As String = "Value Date"
                Dim c11_Details As String = "Details of Charges"
                Dim c12_RemInfoCode As String = "Remittance Info Code"
                Dim c13_RemInfo As String = "Remittance Info"
                Dim c14_BenBankBIC As String = "Beneficiary Bank's BIC"
                Dim c15_InterBankBIC As String = "Intermediary bank BIC"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator

                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator


                Header = Header & c7_benName & Separator
                Header = Header & c8_benAddr & Separator

                Header = Header & "" & Separator

                Header = Header & c9_benCity & Separator

                Header = Header & "" & Separator

                Header = Header & c10_ValDate & Separator
                Header = Header & c11_Details & Separator
                Header = Header & c12_RemInfoCode & Separator
                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_BenBankBIC & Separator
                Header = Header & c15_InterBankBIC


                'WriteTotxtFile_AlphaBank(Header, "")

                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If


                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If


                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)
                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "4"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN

                        c5_Amount = Salary
                        'c5_Amount = c5_Amount.Replace(".", ",")
                        Dim Adr1 As String

                        Adr1 = Emp.Address1
                        Adr1 = Adr1.Replace(",", " ")
                        Adr1 = Adr1.Replace("@", " ")
                        Adr1 = Adr1.Replace("@", " ")
                        Adr1 = Adr1.Replace("&", " ")
                        Adr1 = Adr1.Replace(";", " ")
                        Adr1 = Adr1.Replace("?", " ")
                        Adr1 = Adr1.Replace("#", " ")
                        Adr1 = Adr1.Replace("%", " ")

                        Dim Adr2 As String
                        Adr2 = Emp.Address2
                        Adr2 = Adr2.Replace(",", " ")
                        Adr2 = Adr2.Replace("@", " ")
                        Adr2 = Adr2.Replace("@", " ")
                        Adr2 = Adr2.Replace("&", " ")
                        Adr2 = Adr2.Replace(";", " ")
                        Adr2 = Adr2.Replace("?", " ")
                        Adr2 = Adr2.Replace("#", " ")
                        Adr2 = Adr2.Replace("%", " ")


                        c6_Currency = "EUR"
                        c7_benName = EmpName
                        c8_benAddr = Adr1 & Emp.PostCode
                        c9_benCity = Adr2
                        c10_ValDate = ExecutionDate
                        c11_Details = "SHA"
                        c12_RemInfoCode = "INV"
                        c13_RemInfo = "Salary of " & Period.DescriptionL

                        Dim Swift As String
                        Swift = FindSwiftCode(Bank, False)
                        c14_BenBankBIC = Swift
                        c15_InterBankBIC = ""


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator

                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator

                        Line = Line & c7_benName & Separator
                        Line = Line & c8_benAddr & Separator

                        Line = Line & "" & Separator

                        Line = Line & c9_benCity & Separator

                        Line = Line & "" & Separator

                        Line = Line & c10_ValDate & Separator
                        Line = Line & c11_Details & Separator
                        Line = Line & c12_RemInfoCode & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_BenBankBIC & Separator
                        Line = Line & c15_InterBankBIC

                        WriteTotxtFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File with ONLY Alpha Bank is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no Employees for ONLY ALPHA Bank maching the Criteria", MsgBoxStyle.Information)
            End If
            
        Else
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String

                Dim Separator As String = "	"


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c7_benName As String = "Beneficiary Name"
                Dim c8_benAddr As String = "Beneficiary's Address "
                Dim c9_benCity As String = "Beneficiary City "
                Dim c10_ValDate As String = "Value Date"
                Dim c11_Details As String = "Details of Charges"
                Dim c12_RemInfoCode As String = "Remittance Info Code"
                Dim c13_RemInfo As String = "Remittance Info"
                Dim c14_BenBankBIC As String = "Beneficiary Bank's BIC"
                Dim c15_InterBankBIC As String = "Intermediary bank BIC"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator

                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator


                Header = Header & c7_benName & Separator
                Header = Header & c8_benAddr & Separator

                Header = Header & "" & Separator

                Header = Header & c9_benCity & Separator

                Header = Header & "" & Separator

                Header = Header & c10_ValDate & Separator
                Header = Header & c11_Details & Separator
                Header = Header & c12_RemInfoCode & Separator
                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_BenBankBIC & Separator
                Header = Header & c15_InterBankBIC


                'WriteTotxtFile_AlphaBank(Header, "")

                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If


                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If


                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)
                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "4"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN

                        c5_Amount = Salary
                        'c5_Amount = c5_Amount.Replace(".", ",")
                        Dim Adr1 As String

                        Adr1 = Emp.Address1
                        Adr1 = Adr1.Replace(",", " ")
                        Adr1 = Adr1.Replace("@", " ")
                        Adr1 = Adr1.Replace("@", " ")
                        Adr1 = Adr1.Replace("&", " ")
                        Adr1 = Adr1.Replace(";", " ")
                        Adr1 = Adr1.Replace("?", " ")
                        Adr1 = Adr1.Replace("#", " ")
                        Adr1 = Adr1.Replace("%", " ")

                        Dim Adr2 As String
                        Adr2 = Emp.Address2
                        Adr2 = Adr2.Replace(",", " ")
                        Adr2 = Adr2.Replace("@", " ")
                        Adr2 = Adr2.Replace("@", " ")
                        Adr2 = Adr2.Replace("&", " ")
                        Adr2 = Adr2.Replace(";", " ")
                        Adr2 = Adr2.Replace("?", " ")
                        Adr2 = Adr2.Replace("#", " ")
                        Adr2 = Adr2.Replace("%", " ")


                        c6_Currency = "EUR"
                        c7_benName = EmpName
                        c8_benAddr = Adr1 & Emp.PostCode
                        c9_benCity = Adr2
                        c10_ValDate = ExecutionDate
                        c11_Details = "SHA"
                        c12_RemInfoCode = "INV"
                        c13_RemInfo = "Salary of " & Period.DescriptionL

                        Dim Swift As String
                        Swift = FindSwiftCode(Bank, False)
                        c14_BenBankBIC = Swift
                        c15_InterBankBIC = ""


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator

                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator

                        Line = Line & c7_benName & Separator
                        Line = Line & c8_benAddr & Separator

                        Line = Line & "" & Separator

                        Line = Line & c9_benCity & Separator

                        Line = Line & "" & Separator

                        Line = Line & c10_ValDate & Separator
                        Line = Line & c11_Details & Separator
                        Line = Line & c12_RemInfoCode & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_BenBankBIC & Separator
                        Line = Line & c15_InterBankBIC

                        WriteTotxtFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
            End If

        End If
    End Sub
    Private Function WriteTotxtFile_AlphaBank(ByVal Line As String, ByVal fName As String, ByVal OnlyAlpha As Boolean) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String
            If OnlyAlpha Then
                FileName = BankFiledir & "AlphaBank1.txt"
            Else
                FileName = BankFiledir & "AlphaBank2.txt"
            End If

            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        CreateSEPA_AlphaBank_CSV(True)
        CreateSEPA_AlphaBank_CSV(False)
    End Sub
    Private Sub CreateSEPA_AlphaBank_CSV(ByVal OnlyAlpha)
        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet



        EmployeeBankCode = "ALPHA"
        

        ds = PrepareDSForReport_ForAlphaBank(Includeinactive, EmployeeBankCode, OnlyAlpha)

        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "dd/MM/yyyy")



        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If







        If OnlyAlpha Then


            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String
                Dim Separator As String = ","


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c13_RemInfo As String = "From Description"
                Dim c14_RemInfo As String = "To Description"

                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator


                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_RemInfo & Separator



                WriteToCSVFile_AlphaBank(Header, "", OnlyAlpha)
                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If
                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)


                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "2"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN
                        c5_Amount = Salary
                        c6_Currency = "EUR"
                        c13_RemInfo = "Salary of " & Period.DescriptionL
                        c14_RemInfo = " "


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_RemInfo & " " & EmpName & Separator

                        WriteToCSVFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File For ALPHA bank ONLY is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no ALPHA BANK Only Employees maching the Criteria", MsgBoxStyle.Information)
            End If
        Else
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String
                Dim Separator As String = ","


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c7_benName As String = "Beneficiary Name"
                Dim c8_benAddr As String = "Beneficiary's Address "
                Dim c9_benCity As String = "Beneficiary City "
                Dim c10_ValDate As String = "Value Date"
                Dim c11_Details As String = "Details of Charges"
                Dim c12_RemInfoCode As String = "Remittance Info Code"
                Dim c13_RemInfo As String = "Remittance Info"
                Dim c14_BenBankBIC As String = "Beneficiary Bank's BIC"
                Dim c15_InterBankBIC As String = "Intermediary bank BIC"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator

                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator


                Header = Header & c7_benName & Separator
                Header = Header & c8_benAddr & Separator

                Header = Header & "" & Separator

                Header = Header & c9_benCity & Separator

                Header = Header & "" & Separator

                Header = Header & c10_ValDate & Separator
                Header = Header & c11_Details & Separator
                Header = Header & c12_RemInfoCode & Separator
                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_BenBankBIC & Separator
                Header = Header & c15_InterBankBIC & Separator


                WriteToCSVFile_AlphaBank(Header, "", OnlyAlpha)
                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If
                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)


                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "4"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN
                        c5_Amount = Salary
                        c6_Currency = "EUR"
                        c7_benName = EmpName
                        c8_benAddr = Emp.Address1.Replace(",", " ")
                        c9_benCity = Emp.Address2.Replace(",", " ")
                        c10_ValDate = ExecutionDate
                        c11_Details = "SHA"
                        c12_RemInfoCode = "INV"
                        c13_RemInfo = "Salary of " & Period.DescriptionL

                        Dim Swift As String
                        Swift = FindSwiftCode(Bank, False)
                        c14_BenBankBIC = Swift
                        c15_InterBankBIC = ""


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator

                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator

                        Line = Line & c7_benName & Separator
                        Line = Line & c8_benAddr & Separator

                        Line = Line & "" & Separator

                        Line = Line & c9_benCity & Separator

                        Line = Line & "" & Separator

                        Line = Line & c10_ValDate & Separator
                        Line = Line & c11_Details & Separator
                        Line = Line & c12_RemInfoCode & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_BenBankBIC & Separator
                        Line = Line & c15_InterBankBIC & Separator

                        WriteToCSVFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Sub CreateSEPA_AlphaBank_CSV_2(ByVal OnlyAlpha)
        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet



        EmployeeBankCode = "ALPHA"


        ds = PrepareDSForReport_ForAlphaBank(Includeinactive, EmployeeBankCode, OnlyAlpha)

        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "dd/MM/yyyy")



        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If







        If OnlyAlpha Then
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String
                Dim Separator As String = ","


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c7_benName As String = "Beneficiary Name"
                Dim c8_benAddr As String = "Beneficiary's Address "
                Dim c9_benCity As String = "Beneficiary City "
                Dim c10_ValDate As String = "Value Date"
                Dim c11_Details As String = "Details of Charges"
                Dim c12_RemInfoCode As String = "Remittance Info Code"
                Dim c13_RemInfo As String = "Remittance Info"
                Dim c14_BenBankBIC As String = "Beneficiary Bank's BIC"
                Dim c15_InterBankBIC As String = "Intermediary bank BIC"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator

                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator


                Header = Header & c7_benName & Separator
                Header = Header & c8_benAddr & Separator

                Header = Header & "" & Separator

                Header = Header & c9_benCity & Separator

                Header = Header & "" & Separator

                Header = Header & c10_ValDate & Separator
                Header = Header & c11_Details & Separator
                Header = Header & c12_RemInfoCode & Separator
                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_BenBankBIC & Separator
                Header = Header & c15_InterBankBIC & Separator


                WriteToCSVFile_AlphaBank(Header, "", OnlyAlpha)
                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If
                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)


                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "4"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN
                        c5_Amount = Salary
                        c6_Currency = "EUR"
                        c7_benName = EmpName
                        c8_benAddr = Emp.Address1.Replace(",", " ")
                        c9_benCity = Emp.Address2.Replace(",", " ")
                        c10_ValDate = ExecutionDate
                        c11_Details = "SHA"
                        c12_RemInfoCode = "INV"
                        c13_RemInfo = "Salary of " & Period.DescriptionL

                        Dim Swift As String
                        Swift = FindSwiftCode(Bank, False)
                        c14_BenBankBIC = Swift
                        c15_InterBankBIC = ""


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator

                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator

                        Line = Line & c7_benName & Separator
                        Line = Line & c8_benAddr & Separator

                        Line = Line & "" & Separator

                        Line = Line & c9_benCity & Separator

                        Line = Line & "" & Separator

                        Line = Line & c10_ValDate & Separator
                        Line = Line & c11_Details & Separator
                        Line = Line & c12_RemInfoCode & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_BenBankBIC & Separator
                        Line = Line & c15_InterBankBIC & Separator

                        WriteToCSVFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File For ALPHA bank ONLY is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no ALPHA BANK Only Employees maching the Criteria", MsgBoxStyle.Information)
            End If
        Else
            If CheckDataSet(ds) Then
                Dim Header As String = ""
                Dim Line As String
                Dim Separator As String = ","


                Dim c1_RefNo As String = "External Ref No"
                Dim c2_TranCode As String = "Transaction Code"
                Dim c3_FromAccount As String = "From Account"
                Dim c4_BenAccount As String = "Beneficiary Account"
                Dim c5_Amount As String = "Amount(Debit)"
                Dim c6_Currency As String = "Curency(Debit)"
                Dim c7_benName As String = "Beneficiary Name"
                Dim c8_benAddr As String = "Beneficiary's Address "
                Dim c9_benCity As String = "Beneficiary City "
                Dim c10_ValDate As String = "Value Date"
                Dim c11_Details As String = "Details of Charges"
                Dim c12_RemInfoCode As String = "Remittance Info Code"
                Dim c13_RemInfo As String = "Remittance Info"
                Dim c14_BenBankBIC As String = "Beneficiary Bank's BIC"
                Dim c15_InterBankBIC As String = "Intermediary bank BIC"


                Header = Header & c1_RefNo & Separator
                Header = Header & c2_TranCode & Separator
                Header = Header & c3_FromAccount & Separator
                Header = Header & c4_BenAccount & Separator
                Header = Header & c5_Amount & Separator
                Header = Header & c6_Currency & Separator

                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator
                Header = Header & "" & Separator


                Header = Header & c7_benName & Separator
                Header = Header & c8_benAddr & Separator

                Header = Header & "" & Separator

                Header = Header & c9_benCity & Separator

                Header = Header & "" & Separator

                Header = Header & c10_ValDate & Separator
                Header = Header & c11_Details & Separator
                Header = Header & c12_RemInfoCode & Separator
                Header = Header & c13_RemInfo & Separator
                Header = Header & c14_BenBankBIC & Separator
                Header = Header & c15_InterBankBIC & Separator


                WriteToCSVFile_AlphaBank(Header, "", OnlyAlpha)
                Dim i As Integer
                Dim EmpCode As String
                Dim EmpName As String
                Dim Salary As Double
                Dim BankCode As String
                Dim BankAccount As String
                Dim BankDesc As String
                Dim IBAN As String
                Dim EmpID As String
                Dim BenefName As String
                Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
                Dim BANKcountry As String
                Dim BenCountry As String


                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                        Line = ""
                        EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                        Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                        EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                        BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                        BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                        ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                        IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                        EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                        BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                        If BenefName <> "" Then
                            EmpName = BenefName
                        End If
                        If IBAN = "" Then
                            MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        BANKcountry = IBAN.Substring(0, 2)
                        BenCountry = IBAN.Substring(0, 2)


                        Dim Bank As New cPrAnBanks(BankCode)
                        Dim Emp As New cPrMsEmployees(EmpCode)

                        c1_RefNo = i + 1
                        c2_TranCode = "4"
                        c3_FromAccount = CompanyBankAcc
                        c4_BenAccount = IBAN
                        c5_Amount = Salary
                        c6_Currency = "EUR"
                        c7_benName = EmpName
                        c8_benAddr = Emp.Address1.Replace(",", " ")
                        c9_benCity = Emp.Address2.Replace(",", " ")
                        c10_ValDate = ExecutionDate
                        c11_Details = "SHA"
                        c12_RemInfoCode = "INV"
                        c13_RemInfo = "Salary of " & Period.DescriptionL

                        Dim Swift As String
                        Swift = FindSwiftCode(Bank, False)
                        c14_BenBankBIC = Swift
                        c15_InterBankBIC = ""


                        Line = Line & c1_RefNo & Separator
                        Line = Line & c2_TranCode & Separator
                        Line = Line & c3_FromAccount & Separator
                        Line = Line & c4_BenAccount & Separator
                        Line = Line & c5_Amount & Separator
                        Line = Line & c6_Currency & Separator

                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator
                        Line = Line & "" & Separator

                        Line = Line & c7_benName & Separator
                        Line = Line & c8_benAddr & Separator

                        Line = Line & "" & Separator

                        Line = Line & c9_benCity & Separator

                        Line = Line & "" & Separator

                        Line = Line & c10_ValDate & Separator
                        Line = Line & c11_Details & Separator
                        Line = Line & c12_RemInfoCode & Separator
                        Line = Line & c13_RemInfo & Separator
                        Line = Line & c14_BenBankBIC & Separator
                        Line = Line & c15_InterBankBIC & Separator

                        WriteToCSVFile_AlphaBank(Line, "", OnlyAlpha)
                    End If
                Next
                MsgBox("File is created", MsgBoxStyle.Information)
            Else
                MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Function WriteToCSVFile_AlphaBank(ByVal Line As String, ByVal fName As String, ByVal OnlyAlpha As Boolean) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String
            If OnlyAlpha Then
                FileName = BankFiledir & "AlphaBank1.csv"
            Else
                FileName = BankFiledir & "AlphaBank2.csv"
            End If

            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    

    Private Sub btnIBANReportWithAllemployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIBANReportWithAllemployees.Click
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""

        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        ds = PrepareALLIBANSReport(Includeinactive)
        If CheckDataSet(ds) Then
            Dim HeaderStr As New ArrayList
            Dim HeaderSize As New ArrayList
            Dim Loader As New cExcelLoader

            HeaderStr.Add("Code")
            HeaderStr.Add("FullName")
            HeaderStr.Add("Status")
            HeaderStr.Add("Payment Method")
            HeaderStr.Add("NetSalary")
            HeaderStr.Add("Emp. BankCode")
            HeaderStr.Add("Emp. Bank")
            HeaderStr.Add("Emp. Bank SwiftCode")
            HeaderStr.Add("Emp. Bank Account")
            HeaderStr.Add("Emp. IBAN")
            HeaderStr.Add("Comp. BankCode")
            HeaderStr.Add("Comp. Bank")
            HeaderStr.Add("Comp. Bank SwiftCode")
            HeaderStr.Add("Comp. IBAN")
            

            HeaderSize.Add(10)
            HeaderSize.Add(30)
            HeaderSize.Add(10)
            HeaderSize.Add(10)
            HeaderSize.Add(20)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)
            HeaderSize.Add(30)

            Me.Cursor = Cursors.Default
            Application.DoEvents()

            Loader.LoadIntoExcel(ds, HeaderStr, HeaderSize)

        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        AstroBank()
    End Sub
    Private Sub AstroBank()

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "yyyy-MM-dd")

        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If

        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ";"


            Dim c1_DebitAccount As String = "DebitAccount"
            Dim c2_BenAccount As String = "BenAccount"
            Dim c3_Ammount As String = "Amount"
            Dim c4_PaymentDetails As String = "PaymentDetails"
            Dim c5_BenName As String = "BenName"
            Dim c6_BenBank As String = "BenBank"
            Dim c7_Country As String = "Country "
            Dim c8_Currency As String = "Currency"
            Dim c9_ChargingOption As String = "ChargingOption"
            Dim c10_PurposeOfPay As String = "PurposeOfPay"
            Dim c11_TUN As String = "TUN"
            Dim c12_ExecutionDate As String = "ExecDate"
            

            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = Format(DbNullToDouble(ds.Tables(0).Rows(i).Item(1)), "0.00")
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If


                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BANKcountry = IBAN.Substring(0, 2)
                    BenCountry = IBAN.Substring(0, 2)
                    Dim Bank As New cPrAnBanks(BankCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)


                  
                  

                    Dim Swift As String
                    Swift = FindSwiftCode(Bank, False)
                    

                    c1_DebitAccount = CompanyBankAcc
                    c2_BenAccount = IBAN
                    c3_Ammount = Salary
                    c4_PaymentDetails = "Salary of " & Period.DescriptionL
                    c5_BenName = EmpName
                    c6_BenBank = Swift
                    c7_Country = BenCountry
                    c8_Currency = "EUR"
                    c9_ChargingOption = "OUR"
                    c10_PurposeOfPay = "000"
                    c11_TUN = "P" & Period.Sequence
                    c12_ExecutionDate = ExecutionDate



                    Line = Line & c1_DebitAccount & Separator
                    Line = Line & c2_BenAccount & Separator
                    Line = Line & c3_Ammount & Separator
                    Line = Line & c4_PaymentDetails & Separator
                    Line = Line & c5_BenName & Separator
                    Line = Line & c6_BenBank & Separator
                    Line = Line & c7_Country & Separator
                    Line = Line & c8_Currency & Separator
                    Line = Line & c9_ChargingOption & Separator
                    Line = Line & c10_PurposeOfPay & Separator
                    Line = Line & c11_TUN & Separator
                    Line = Line & c12_ExecutionDate


                    WriteToCSVFile(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub AstroBank_2()

        'InitFile = True
        'Dim Includeinactive As Boolean = False
        'Dim EmployeeBankCode As String = ""


        'If Me.CBInactive.CheckState = CheckState.Checked Then
        '    Includeinactive = True
        'End If
        'Dim ds As DataSet


        'If Me.ComboOnlyBank.SelectedIndex = 0 Then
        '    EmployeeBankCode = ""
        'Else
        '    EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        'End If


        'ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)
        'Dim ExecutionDate As String = ""
        'ExecutionDate = Format(Me.DatePay.Value.Date, "yyMMdd")

        'If CBSelectEmployees.CheckState = CheckState.Checked Then
        '    If Not HellenicToOther Then
        '        RunSelection = False
        '        Dim F As New FrmSelectEmployeesForBankFile
        '        F.ForHellenic = False
        '        F.Ds = ds
        '        F.Owner = Me
        '        F.ShowDialog()
        '        If Me.RunSelection Then
        '            Dim k As Integer
        '            For k = 0 To ds.Tables(0).Rows.Count - 1
        '                ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
        '            Next
        '        End If
        '    Else
        '        If Me.RunSelection Then
        '            Dim k As Integer
        '            For k = 0 To ds.Tables(0).Rows.Count - 1
        '                ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
        '            Next
        '        End If
        '    End If
        'End If

        'If CheckDataSet(ds) Then
        '    Dim Header As String = ""
        '    Dim Line As String
        '    Dim Separator As String = ";"

        '    Dim H1_recordType As String
        '    Dim H2_DateTorun As String
        '    Dim H3_OtherDescription As String
        '    Dim H4_CompanyAccount As String
        '    Dim H5_SequenceNumber As String
        '    Dim H7_ContractNumber As String
        '    Dim H8_CurrencyCode As String
        '    Dim H9_TotalAmount As String
        '    Dim H10_TotalItems As String
        '    Dim H11_FutureUse As String

        '    Dim L1_RecordType
        '    Dim L2_BenAccount As String = "BenAccount"
        '    Dim c3_Ammount As String = "Amount"
        '    Dim c4_PaymentDetails As String = "PaymentDetails"
        '    Dim c5_BenName As String = "BenName"
        '    Dim c6_BenBank As String = "BenBank"
        '    Dim c7_Country As String = "Country "
        '    Dim c8_Currency As String = "Currency"
        '    Dim c9_ChargingOption As String = "ChargingOption"
        '    Dim c10_PurposeOfPay As String = "PurposeOfPay"
        '    Dim c11_TUN As String = "TUN"
        '    Dim c12_ExecutionDate As String = "ExecDate"


        '    Dim i As Integer
        '    Dim EmpCode As String
        '    Dim EmpName As String
        '    Dim Salary As Double
        '    Dim BankCode As String
        '    Dim BankAccount As String
        '    Dim BankDesc As String
        '    Dim IBAN As String
        '    Dim EmpID As String
        '    Dim BenefName As String
        '    Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
        '    Dim BANKcountry As String
        '    Dim BenCountry As String


        '    For i = 0 To ds.Tables(0).Rows.Count - 1
        '        If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
        '            Line = ""
        '            EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
        '            Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
        '            EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
        '            BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
        '            BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
        '            ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
        '            IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
        '            EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
        '            BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
        '            If BenefName <> "" Then
        '                EmpName = BenefName
        '            End If


        '            If IBAN = "" Then
        '                MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
        '                Exit Sub
        '            End If

        '            BANKcountry = IBAN.Substring(0, 2)
        '            BenCountry = IBAN.Substring(0, 2)
        '            Dim Bank As New cPrAnBanks(BankCode)
        '            Dim Emp As New cPrMsEmployees(EmpCode)





        '            Dim Swift As String
        '            Swift = FindSwiftCode(Bank, False)


        '            c1_DebitAccount = CompanyBankAcc
        '            c2_BenAccount = IBAN
        '            c3_Ammount = Salary
        '            c4_PaymentDetails = "Salary of " & Period.DescriptionL
        '            c5_BenName = EmpName
        '            c6_BenBank = Swift
        '            c7_Country = BenCountry
        '            c8_Currency = "EUR"
        '            c9_ChargingOption = "OUR"
        '            c10_PurposeOfPay = "000"
        '            c11_TUN = "P" & Period.Sequence
        '            c12_ExecutionDate = ExecutionDate



        '            Line = Line & c1_DebitAccount & Separator
        '            Line = Line & c2_BenAccount & Separator
        '            Line = Line & c3_Ammount & Separator
        '            Line = Line & c4_PaymentDetails & Separator
        '            Line = Line & c5_BenName & Separator
        '            Line = Line & c6_BenBank & Separator
        '            Line = Line & c7_Country & Separator
        '            Line = Line & c8_Currency & Separator
        '            Line = Line & c9_ChargingOption & Separator
        '            Line = Line & c10_PurposeOfPay & Separator
        '            Line = Line & c11_TUN & Separator
        '            Line = Line & c12_ExecutionDate


        '            WriteToCSVFile(Line, "")
        '        End If
        '    Next
        '    MsgBox("File is created", MsgBoxStyle.Information)
        'Else
        '    MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        'End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Process.Start(BankFiledir)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Create_SEPAGA_CSV()
    End Sub
    Private Sub Create_SEPAGA_CSV()
        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        ds = PrepareDSForReport_ForSEPAGA(Includeinactive, EmployeeBankCode)

        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "yyMMdd")



        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If

      
        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ","



            Dim c1_TranCode As String = "K90"
            Dim c2_ValDate As String = ""
            Dim c3_Currency As String = "EUR"
            Dim c4_Amount As String = ""
            Dim c5_FromAccount As String = ""

            Dim c6_BenIntermediarySwift As String = ""
            Dim c7_BenIntermediaryAccount As String = ""
            Dim c8_BenIntermediaryClearingCode As String = ""

            Dim c9_BenBankBIC As String = ""
            Dim c10_BenIBAN As String = ""
            Dim c11_BenAccountNo As String = ""
            Dim c12_BenClearingCode As String = ""
            Dim c13_BenName As String = ""
            Dim c14_BenAddr As String = ""
            Dim c15_BenCity As String = ""
            Dim c16_BenCountry As String = ""

            Dim c17_Details1 As String = ""
            Dim c18_Details2 As String = ""
            Dim c19_ChargesTo As String = ""
            Dim c20_Priority As String = "N"
            Dim c21_RefNumber As String = ""

          
            Dim i As Integer
            Dim TrxnCode As String = "K90"
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If
                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BANKcountry = IBAN.Substring(0, 2)
                    BenCountry = IBAN.Substring(0, 2)


                    Dim Bank As New cPrAnBanks(BankCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)


                    Dim Swift As String
                    Swift = FindSwiftCode(Bank, False)
                  

                    c1_TranCode = "K90"
                    c2_ValDate = ExecutionDate
                    c3_Currency = "EUR"
                    c4_Amount = Salary
                    c5_FromAccount = CompanyBankAcc

                    c6_BenIntermediarySwift = ""
                    c7_BenIntermediaryAccount = ""
                    c8_BenIntermediaryClearingCode = ""

                    c9_BenBankBIC = Swift
                    c10_BenIBAN = IBAN
                    c11_BenAccountNo = ""
                    c12_BenClearingCode = ""
                    c13_BenName = EmpName
                    c14_BenAddr = Emp.Address1.Replace(",", " ")

                    c15_BenCity = Emp.Address2.Replace(",", " ")
                    c16_BenCountry = BenCountry

                    c17_Details1 = "Salary of " & Period.DescriptionL
                    c18_Details2 = ""
                    c19_ChargesTo = "OUR"
                    c20_Priority = "N"
                    c21_RefNumber = Period.Code & "_" & EmpCode




                    Line = Line & c1_TranCode & Separator
                    Line = Line & c2_ValDate & Separator
                    Line = Line & c3_Currency & Separator
                    Line = Line & c4_Amount & Separator
                    Line = Line & c5_FromAccount & Separator

                    Line = Line & c6_BenIntermediarySwift & Separator
                    Line = Line & c7_BenIntermediaryAccount & Separator
                    Line = Line & c8_BenIntermediaryClearingCode & Separator

                    Line = Line & c9_BenBankBIC & Separator
                    Line = Line & c10_BenIBAN & Separator
                    Line = Line & c11_BenAccountNo & Separator
                    Line = Line & c12_BenClearingCode & Separator
                    Line = Line & c13_BenName & Separator
                    Line = Line & c14_BenAddr & Separator

                    Line = Line & c15_BenCity & Separator
                    Line = Line & c16_BenCountry & Separator

                    Line = Line & c17_Details1 & Separator
                    Line = Line & c18_Details2 & Separator
                    Line = Line & c19_ChargesTo & Separator
                    Line = Line & c20_Priority & Separator
                    Line = Line & c21_RefNumber


                    WriteToCSVFile_SEPAGA(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If

    End Sub
    Private Function WriteToCSVFile_SEPAGA(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = BankFiledir & "Sepaga.csv"

            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

   
    Private Sub BtnCreateEWallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateEWallet.Click
        CreateEwalletFile(True)
    End Sub
    Private Sub BtnCreateEWalletNoNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateEWalletNoNames.Click
        CreateEwalletFile(False)
    End Sub
    Private Sub CreateEwalletFile(ByVal IncludeName As Boolean)

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If


        ds = PrepareDSForEWallet(Includeinactive, EmployeeBankCode, False)
        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "dd/MM/yyyy")

        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If

        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ","


            'Dim c1_type As String = "type"
            'Dim c2_doc_num As String = "doc_num"
            'Dim c3_is_urgently As String = "is_urgently"
            Dim c4_value_date As String = "value_date"
            Dim c5_target_amount As String = "target_amount"
            Dim c6_target_currency As String = "target_currency"
            Dim c7_ben_name As String = "ben_name "
            'Dim c8_ben_addr As String = "ben_addr"
            'Dim c9_ben_city As String = "ben_city"
            Dim c10_ben_country As String = "ben_country"
            'Dim c11_source_acc As String = "source_acc"
            Dim c12_ben_acc As String = "ben_acc "
            'Dim c13_ben_bank_name As String = "ben_bank_name"
            'Dim c14_bank_addr As String = "bank_addr "
            'Dim c15_bank_city As String = "bank_city"
            'Dim c16_bank_country As String = "bank_country "
            'Dim c17_ben_bank_bic As String = "ben_bank_bic"
            'Dim c18_info_remmitance As String = "info_remmitance"
            'Dim c19_charges_acc As String = "charges_acc"

            'Header = Header & c1_type & Separator
            'Header = Header & c2_doc_num & Separator
            'Header = Header & c3_is_urgently & Separator
            'Header = Header & c4_value_date & Separator
            'Header = Header & c5_target_amount & Separator
            'Header = Header & c6_target_currency & Separator
            'Header = Header & c7_ben_name & Separator
            'Header = Header & c8_ben_addr & Separator
            'Header = Header & c9_ben_city & Separator
            'Header = Header & c10_ben_country & Separator
            'Header = Header & c11_source_acc & Separator
            'Header = Header & c12_ben_acc & Separator
            'Header = Header & c13_ben_bank_name & Separator
            'Header = Header & c14_bank_addr & Separator
            'Header = Header & c15_bank_city & Separator
            'Header = Header & c16_bank_country & Separator
            'Header = Header & c17_ben_bank_bic & Separator
            'Header = Header & c18_info_remmitance & Separator
            'Header = Header & c19_charges_acc

            ' WriteToCSVFile(Header, "")
            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    ' EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    ' BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    '   BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    '  EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    ' BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If


                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    ' BANKcountry = IBAN.Substring(0, 2)
                    ' BenCountry = IBAN.Substring(0, 2)
                    ' Dim Bank As New cPrAnBanks(BankCode)
                    'Dim Emp As New cPrMsEmployees(EmpCode)

                    c4_value_date = ExecutionDate
                    c5_target_amount = Salary
                    c6_target_currency = "EUR"
                    c7_ben_name = EmpName

                    'Dim Adr1 As String
                    'Adr1 = Emp.Address1
                    'Adr1 = Adr1.Replace(",", " ")
                    'Adr1 = Adr1.Replace("@", " ")
                    'Adr1 = Adr1.Replace("&", " ")
                    'Adr1 = Adr1.Replace(";", " ")
                    'Adr1 = Adr1.Replace("?", " ")
                    'Adr1 = Adr1.Replace("#", " ")
                    'Adr1 = Adr1.Replace("%", " ")

                    'Dim Adr2 As String
                    'Adr2 = Emp.Address2
                    'Adr2 = Adr2.Replace(",", " ")
                    'Adr2 = Adr2.Replace("@", " ")
                    'Adr2 = Adr2.Replace("&", " ")
                    'Adr2 = Adr2.Replace(";", " ")
                    'Adr2 = Adr2.Replace("?", " ")
                    'Adr2 = Adr2.Replace("#", " ")
                    'Adr2 = Adr2.Replace("%", " ")

                    'Dim Country As New cAdAnCountries(Emp.Cou_Code)
                    'c10_ben_country = BenCountry
                    'c11_source_acc = CompanyBankAcc
                    c12_ben_acc = IBAN
                    'c13_ben_bank_name = ""
                    'c14_bank_addr = ""
                    'c15_bank_city = ""
                    'c16_bank_country = BANKcountry

                    'Dim Swift As String
                    'Swift = FindSwiftCode(Bank, False)
                    'c17_ben_bank_bic = Swift
                    'c18_info_remmitance = "Salary of " & Period.DescriptionL
                    'c19_charges_acc = ""
                    If Includename Then
                        Line = Line & c7_ben_name & Separator
                    End If
                    Line = Line & c12_ben_acc & Separator
                    Line = Line & c5_target_amount & Separator
                    Line = Line & c6_target_currency & Separator
                    Line = Line & c4_value_date

                    WriteToCSVFile(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub BtniSXMoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtniSXMoney.Click
        iSxMoney()
    End Sub
    Private Sub iSxMoney()

        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet






        ds = PrepareDSForReport(Includeinactive, EmployeeBankCode, False)

        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "yyyy-MM-dd")



        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If


        If CheckDataSet(ds) Then
            Dim Line As String
            Dim Separator As String = ","


            Dim c1_RefNo As String
            Dim c2_TranCode As String
            Dim c3_Currency As String
            Dim c4_Amount As String
            Dim c5_BenBankBIC As String
            Dim c6_CompanyName As String = CType(Me.CmbCompany.SelectedItem, cAdMsCompany).Name
            Dim c7_benName As String
            Dim c8_FromAccount As String
            Dim c9_BenAccount As String
            Dim c10_benAddr As String
            Dim c11_ValDate As String
            Dim c12_RemInfo As String


            Dim i As Integer
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If
                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BANKcountry = IBAN.Substring(0, 2)
                    BenCountry = IBAN.Substring(0, 2)


                    Dim Bank As New cPrAnBanks(BankCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)

                    c1_RefNo = "PAY" & Period.DescriptionL
                    c2_TranCode = i + 1
                    c3_Currency = "EUR"
                    c4_Amount = Salary

                    Dim Swift As String
                    Swift = FindSwiftCode(Bank, False)
                    Swift = Swift.Replace("XXX", "")

                    c5_BenBankBIC = Swift

                    c7_benName = EmpName

                    c8_FromAccount = CompanyBankAcc
                    c9_BenAccount = IBAN

                    c10_benAddr = Emp.Address1.Replace(",", " ") & Emp.Address2.Replace(",", " ")
                    c11_ValDate = ExecutionDate
                    c12_RemInfo = "Payroll " & Period.DescriptionL

                   

                    Line = Line & c1_RefNo & Separator
                    Line = Line & c2_TranCode & Separator
                    Line = Line & c3_Currency & Separator
                    Line = Line & c4_Amount & Separator
                    Line = Line & c5_BenBankBIC & Separator
                    Line = Line & c6_CompanyName & Separator
                    Line = Line & c7_benName & Separator
                    Line = Line & c8_FromAccount & Separator
                    Line = Line & c9_BenAccount & Separator
                    Line = Line & c10_benAddr & Separator
                    Line = Line & c11_ValDate & Separator
                    Line = Line & c12_RemInfo

                  
                    WriteToCSVFile_isxMoney(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If

    End Sub
    Private Function WriteToCSVFile_isxMoney(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = BankFiledir & "iSXMoney.csv"


            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function
    Private Sub btnGURUPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGURUPay.Click
        Dim Bank As cPrAnBanks
        Dim FileBankCode As String

        Bank = Me.cmbBnk_CodeCo.SelectedItem

        If Me.ComboBankFileCode.Items.Count = 0 Then
            MsgBox("Bank file Code is missing,Please add it on Company Record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        FileBankCode = Me.ComboBankFileCode.SelectedItem

        Dim EmployeeBankCode As String = ""
        If Me.ComboOnlyBank.SelectedIndex = 0 Then
            EmployeeBankCode = ""
        Else
            EmployeeBankCode = CType(Me.ComboOnlyBank.SelectedItem, cPrAnBanks).Code
        End If

        
        CreateUniversalBankFile_Consolidate(Bank, "DPS002DCI6.txt", 0, False, False, FileBankCode, False, EmployeeBankCode)
        CorvertBankFileToXML_GURUPay(BankFiledir & "DPS002DCI6.txt", BankFiledir, False, False)
    End Sub
    Private Sub CorvertBankFileToXML_GURUPay(ByVal txtFineNameAndPath As String, ByVal FilePath As String, ByVal ChangeName As Boolean, ByVal IsEurobank As Boolean)

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try




            Dim Line As String = ""
            Dim counter As Integer = 0
            Dim LoadedOK As Boolean = False
            Dim param_file As IO.StreamReader
            Dim FileName As String

            FileName = txtFineNameAndPath
            If Not ChangeName Then
                Me.XMLGlobalFileName = FilePath & "GURUPay.xml"
            Else
                Me.XMLGlobalFileName = FilePath & "GURUPay_OtherBanks.xml"
            End If

            InitFile = True
            Dim Exx As New Exception
            Dim Ar As String


            '------------------------------------------------------------------
            'Open for reading in order to Read Total employees and Total Amount'
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Dim Lines As Integer = 0
            Dim TotalAmount As Double = 0
            Dim sTotalAmount As String = ""
            Dim totalEmployees As String = ""

            Do While param_file.Peek <> -1
                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "02"
                        Lines = Lines + 1
                        TotalAmount = TotalAmount + Trim(Line.Substring(5, 15))
                End Select
            Loop
            sTotalAmount = StringtoDecimal2(TotalAmount.ToString)
            totalEmployees = Lines.ToString
            param_file.Close()
            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------


            '------------------------------------------------------------------
            'Open for reading in order to Write XML File
            '------------------------------------------------------------------
            param_file = IO.File.OpenText(FileName)

            Lines = 0
            Do While param_file.Peek <> -1

                Me.Refresh()
                Line = param_file.ReadLine
                Ar = Line.Substring(0, 2)
                Select Case Ar
                    Case "01"
                        Write_SEPA_Header_GURUPay(Line, totalEmployees, sTotalAmount, IsEurobank)
                    Case "02"
                        Lines = Lines + 1
                        Write_SEPA_LINE_GURUPay(Line, Lines.ToString, IsEurobank)
                End Select
                Application.DoEvents()
            Loop

            WL("</PmtInf>")
            WL("</CstmrCdtTrfInitn>")
            WL("</Document>")

            param_file.Close()

            '------------------------------------------------------------------
            'Close
            '------------------------------------------------------------------

            MsgBox("Bank File is Converted to .xml (" & Me.XMLGlobalFileName & ")", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Failed to create .xml File")
        End Try
        Cursor = Cursors.Default



    End Sub
    Public Sub Write_SEPA_Header_GURUPay(ByVal Line As String, ByVal Totalemployees As String, ByVal TotalAmount As String, ByVal IsEurobank As Boolean)

        Debug.WriteLine(Line)

        Dim sCreationDateTime As String = Format(Now.Date, "yyyy-MM-dd")
        sCreationDateTime = sCreationDateTime & "T" & Now.Hour.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Minute.ToString.PadLeft(2, "0")
        sCreationDateTime = sCreationDateTime & ":" & Now.Second.ToString.PadLeft(2, "0")

        Dim sTotalTransactions As String = Totalemployees
        Dim sTotalAmount As String = TotalAmount
        Dim sCompanyName As String = Trim(Line.Substring(7, 70))
        Dim sCompanyDigitCode As String = Trim(Line.Substring(2, 5))

        Dim YY As String = Trim(Line.Substring(115, 4))
        Dim MM As String = Trim(Line.Substring(113, 2))
        Dim DD As String = Trim(Line.Substring(111, 2))
        Dim sExecutionDate As String = YY & "-" & MM & "-" & DD
        Dim sIBAN As String = Trim(Line.Substring(77, 34))
        Dim SBIC As String = ""

        ' Addition for Eurobank
        'If IsEurobank Then
        ' SBIC = Trim(Line.Substring(500, 8))

        
        Dim CompBank As New cPrAnBanks
        CompBank = CType(Me.cmbBnk_CodeCo.SelectedItem, cPrAnBanks)
        SBIC = CompBank.SwiftCode

        ' End If

        Debug.WriteLine(Line)





        '''''''''''

        WL(" <Document xmlns=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03"">")

        WL("<CstmrCdtTrfInitn>")

        WL("<GrpHdr>")
        WL("<MsgId>MsgId1</MsgId>")
        WL("<CreDtTm>" & sCreationDateTime & "</CreDtTm>")
        WL("<NbOfTxs>" & sTotalTransactions & "</NbOfTxs>")
        WL("<CtrlSum>" & sTotalAmount & "</CtrlSum>")
        WL("<InitgPty>")
        WL("<Nm>" & Replace(sCompanyName, "&", "&amp;") & "</Nm>")
        WL("</InitgPty>")
        WL("</GrpHdr>")
        WL("<PmtInf>")
        WL("<PmtInfId>PmtInfId</PmtInfId>")
        WL("<PmtMtd>TRF</PmtMtd>")

        WL("<NbOfTxs>" & sTotalTransactions & "</NbOfTxs>")
        WL("<CtrlSum>" & sTotalAmount & "</CtrlSum>")

        WL("<PmtTpInf>")
        WL("<SvcLvl>")
        WL("<Cd>SEPA</Cd>")
        WL("</SvcLvl>")
        WL("</PmtTpInf>")
        WL("<ReqdExctnDt>" & sExecutionDate & "</ReqdExctnDt>")
        WL("<Dbtr>")
        WL("<Nm>" & Replace(sCompanyName, "&", "&amp;") & "</Nm>")
        WL("<PstlAdr>")
        WL("<Ctry>CY</Ctry>")
        WL("</PstlAdr>")
        WL("</Dbtr>")
        WL("<DbtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & UCase(sIBAN) & "</IBAN>")
        WL("</Id>")
        WL("</DbtrAcct>")
        WL("<DbtrAgt>")
        WL("<FinInstnId>")
        WL("<BIC>" & SBIC & "</BIC>")
        WL("</FinInstnId>")
        WL("</DbtrAgt>")
        ' WL("<ChrgBr>SLEV</ChrgBr>")




    End Sub
   

    Public Sub Write_SEPA_LINE_GURUPay(ByVal Line As String, ByVal sLineNo As String, ByVal IsEurobank As Boolean)

        Dim sAmount As String = Trim(Line.Substring(5, 15))
        sAmount = StringtoDecimal2(sAmount)


        Dim sBIC As String = Trim(Line.Substring(20, 11))
        Dim semployeename As String = Trim(Line.Substring(65, 70))
        Dim sIBAN As String = Trim(Line.Substring(31, 34))
        Dim sCountryCode As String = Trim(Line.Substring(139, 2))
        Dim sPaymentDesc As String = Trim(Line.Substring(141, 140))

        WL("<CdtTrfTxInf>")

        WL("<PmtId>")
        ' WL("<InstrId>" & sLineNo & "</InstrId>")
        WL("<EndToEndId>" & sLineNo & "</EndToEndId>")
        WL("</PmtId>")

        'WL("<PmtTpInf>")
        'WL("<SvcLvl>")
        'WL("<Cd>SEPA</Cd>")
        'WL("</SvcLvl>")
        'WL("<CtgyPurp>")
        'WL("<Cd>SALA</Cd>")
        'WL("</CtgyPurp>")
        'WL("</PmtTpInf>")

        WL("<Amt>")
        WL("<InstdAmt Ccy=""EUR"">" & sAmount & "</InstdAmt>")
        WL("</Amt>")

        ' WL("<ChrgBr>SLEV</ChrgBr>")

        WL("<CdtrAgt>")
        WL("<FinInstnId>")
        WL("<BIC>" & sBIC & "</BIC>")
        WL("</FinInstnId>")
        WL("</CdtrAgt>")

        WL("<Cdtr>")
        WL("<Nm>" & semployeename & "</Nm>")
        WL("<PstlAdr>")
        WL("<Ctry>" & sCountryCode & "</Ctry>")
        'WL("<AdrLine>address line1</AdrLine>")
        'WL("<AdrLine>address line2</AdrLine>")
        WL("</PstlAdr>")
        'WL("<Id>")
        'WL("<PrvtId>")
        'WL("<DtAndPlcOfBirth>")
        'WL("<BirthDt>1998-03-30</BirthDt>")
        'WL("<PrvcOfBirth>Nicosia</PrvcOfBirth>")
        'WL("<CityOfBirth>Nicosia</CityOfBirth>")
        'WL("<CtryOfBirth>CY</CtryOfBirth>")
        'WL("</DtAndPlcOfBirth>")
        'WL("</PrvtId>")
        'WL("</Id>")
        WL("</Cdtr>")
        WL("<CdtrAcct>")
        WL("<Id>")
        WL("<IBAN>" & UCase(sIBAN) & "</IBAN>")
        WL("</Id>")
        WL("</CdtrAcct>")


        WL("<RmtInf>")
        WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        WL("</RmtInf>")

        'If Not IsEurobank Then
        '    If Global1.PARAM_ShowPaymentDescOnBankFile Then
        '        WL("<RmtInf>")
        '        WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        '        WL("</RmtInf>")
        '    End If
        'End If

        WL("</CdtTrfTxInf>")
        '''''''''''''''''''''''''''''''''''''''''''
        '        <CdtTrfTxInf>
        '<PmtId>
        '<InstrId>InstrId 3</InstrId>
        '<EndToEndId>EndToEndId 3</EndToEndId>
        '</PmtId>
        '<PmtTpInf>
        '<SvcLvl>
        '<Cd>SEPA</Cd>
        '</SvcLvl>
        '<CtgyPurp>
        '<Cd>SALA</Cd>
        '</CtgyPurp>
        '</PmtTpInf>
        '<Amt>
        '<InstdAmt Ccy="EUR">1100.00</InstdAmt>
        '</Amt>
        '<ChrgBr>SLEV</ChrgBr>
        '<CdtrAgt>
        '<FinInstnId>
        '<BIC>CCBKCY2N</BIC>
        '</FinInstnId>
        '</CdtrAgt>
        '<Cdtr>
        '<Nm>Creditor 3</Nm>
        '<PstlAdr>
        '<Ctry>CY</Ctry>
        '<AdrLine>address line 1 for customer3</AdrLine>
        '</PstlAdr>
        '<Id>
        '<PrvtId>
        '<Othr>
        '<Id>U1234</Id>
        '</Othr>
        '</PrvtId>
        '</Id>
        '</Cdtr>
        '<CdtrAcct>
        '<Id>
        '<IBAN>CY38007101100000000020333607</IBAN>
        '</Id>
        '</CdtrAcct>
        'If IsEurobank Then
        '    WL("<RmtInf>")
        '    WL("<Ustrd>" & sPaymentDesc & "</Ustrd>")
        '    WL("</RmtInf>")
        'End If
        '</CdtTrfTxInf>


    End Sub

    Private Sub BtnMoneyGate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoneyGate.Click
        Create_MoneyGate_CSV()
    End Sub
    Private Sub Create_MoneyGate_CSV()
        InitFile = True
        Dim Includeinactive As Boolean = False
        Dim EmployeeBankCode As String = ""


        If Me.CBInactive.CheckState = CheckState.Checked Then
            Includeinactive = True
        End If
        Dim ds As DataSet


        ds = PrepareDSForReport_ForSEPAGA(Includeinactive, EmployeeBankCode)

        Dim ExecutionDate As String = ""
        ExecutionDate = Format(Me.DatePay.Value.Date, "yyMMdd")



        If CBSelectEmployees.CheckState = CheckState.Checked Then
            If Not HellenicToOther Then
                RunSelection = False
                Dim F As New FrmSelectEmployeesForBankFile
                F.ForHellenic = False
                F.Ds = ds
                F.Owner = Me
                F.ShowDialog()
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(11)
                    Next
                End If
            Else
                If Me.RunSelection Then
                    Dim k As Integer
                    For k = 0 To ds.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(k).Item(11) = DsSelection.Tables(0).Rows(k).Item(10)
                    Next
                End If
            End If
        End If


        If CheckDataSet(ds) Then
            Dim Header As String = ""
            Dim Line As String
            Dim Separator As String = ","



            Dim c1_BenIBAN As String
            Dim c2_BenName As String
            Dim c3_BenAddr As String

            Dim c4_BenCity As String
            Dim c5_BenCountry As String
            Dim c6_BenBankBIC As String
            Dim c7_Details1 As String
            Dim c8_Amount As String


            Dim i As Integer
            Dim TrxnCode As String = "K90"
            Dim EmpCode As String
            Dim EmpName As String
            Dim Salary As Double
            Dim BankCode As String
            Dim BankAccount As String
            Dim BankDesc As String
            Dim IBAN As String
            Dim EmpID As String
            Dim BenefName As String
            Dim CompanyBankAcc As String = Me.ComboBankAcc.Text
            Dim BANKcountry As String
            Dim BenCountry As String





            'Write Header
            Line = ""
            Line = Line & "Beneficiary Account Number" & Separator
            Line = Line & "Beneficiary Name" & Separator
            Line = Line & "Beneficiary Address" & Separator
            Line = Line & "Beneficiary Bank BIC" & Separator
            Line = Line & "Description" & Separator
            Line = Line & "Amount"
            WriteToCSVFile_MoneyGate(Line, "")


            For i = 0 To ds.Tables(0).Rows.Count - 1
                If DbNullToString(ds.Tables(0).Rows(i).Item(11)) = "1" Then
                    Line = ""
                    EmpCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    Salary = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    EmpName = DbNullToString(ds.Tables(0).Rows(i).Item(2))
                    BankCode = DbNullToString(ds.Tables(0).Rows(i).Item(3))
                    BankAccount = DbNullToString(ds.Tables(0).Rows(i).Item(4))
                    ' BankDesc = DbNullToString(ds.Tables(0).Rows(i).Item(5))
                    IBAN = DbNullToString(ds.Tables(0).Rows(i).Item(8))
                    EmpID = DbNullToString(ds.Tables(0).Rows(i).Item(9))
                    BenefName = DbNullToString(ds.Tables(0).Rows(i).Item(10))
                    If BenefName <> "" Then
                        EmpName = BenefName
                    End If
                    If IBAN = "" Then
                        MsgBox("Employee with Code " & EmpCode & " does not have an IBAN Number, Please correct, cannot proceed!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BANKcountry = IBAN.Substring(0, 2)
                    BenCountry = IBAN.Substring(0, 2)


                    Dim Bank As New cPrAnBanks(BankCode)
                    Dim Emp As New cPrMsEmployees(EmpCode)


                    Dim Swift As String
                    Swift = FindSwiftCode(Bank, False)


                    


                    c1_BenIBAN = IBAN
                    c2_BenName = EmpName
                    c3_BenAddr = Emp.Address1.Replace(",", " ")

                    c4_BenCity = Emp.Address2.Replace(",", " ")
                    c5_BenCountry = BenCountry
                    c6_BenBankBIC = Swift
                    c7_Details1 = "Payroll " & Period.DescriptionL
                    c8_Amount = Salary





                    Line = Line & c1_BenIBAN & Separator
                    Line = Line & c2_BenName & Separator
                    Line = Line & c3_BenAddr & " " & c4_BenCity & " " & c5_BenCountry & Separator
                    Line = Line & c6_BenBankBIC & Separator
                    Line = Line & c7_Details1 & Separator
                    Line = Line & c8_Amount

                 


                    WriteToCSVFile_MoneyGate(Line, "")
                End If
            Next
            MsgBox("File is created", MsgBoxStyle.Information)
        Else
            MsgBox("There are no Employees maching the Criteria", MsgBoxStyle.Information)
        End If

    End Sub
    Private Function WriteToCSVFile_MoneyGate(ByVal Line As String, ByVal fName As String) As Boolean
        Dim Flag As Boolean = True
        Try
            ' Dim mFile As System.IO.File
            Dim FileName As String

            FileName = BankFiledir & "MoneyGate.csv"

            Dim TW As System.IO.TextWriter

            If InitFile Then
                TW = System.IO.File.CreateText(FileName)
                InitFile = False
            Else
                If IO.File.Exists(FileName) Then
                    TW = System.IO.File.AppendText(FileName)
                Else
                    TW = System.IO.File.CreateText(FileName)
                End If
            End If
            With TW
                .Write(Line)
                .WriteLine()
                .Close()
            End With
        Catch ex As Exception
            Flag = False
        End Try
        Return Flag
    End Function

End Class