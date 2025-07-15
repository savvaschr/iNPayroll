Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Public Class FrmExcelsysWebServices



    'https://prod1wsi.exelsyslive.com/wsi/exelsyswsi.asmx?op=GetEmployeesPages
    ''https://demo1wsi.exelsyslive.com/wsi/ExelsysWSI.asmx

    Dim IsConnected As String
    Dim WSLogin As String
    Dim WSPassword As String
    Dim WSBusinessEntity As String
    Dim WSEmplloyeeFillType As String
    Dim WSURL As String


    Dim DefBank As String
    Dim DefPayslip As String
    Dim DefIBAN As String

    Dim PayrollUser As String
    Dim Loading As Boolean = True
    Dim ParamDate As New cPrSsParameters
    Private Sub FrmExcelsysWebServices_Load(sender As Object, e As EventArgs) Handles Me.Load

        ReadParameters()
        LoadComboTemplate()
        '  LoadCombo_Bank()
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
    'Private Sub LoadCombo_Bank()
    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.AG_GetAllPrAnBanks()
    '    If CheckDataSet(ds) Then
    '        Dim tPrAnBanks As New cPrAnBanks
    '        With Me.ComboCompBank
    '            .BeginUpdate()
    '            .Items.Clear()
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                tPrAnBanks = New cPrAnBanks(DbNullToString(ds.Tables(0).Rows(i).Item(0)))
    '                .Items.Add(tPrAnBanks)
    '            Next i
    '            ' .ValueMember = "Bnk_Code"
    '            .SelectedIndex = 0
    '            .EndUpdate()
    '        End With
    '    End If
    'End Sub
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
    'Private Sub LoadCombo_IBAN(ByVal TempGroupCode As String)

    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.GetAllIBANSOfTemplateGroupCode(TempGroupCode)
    '    If CheckDataSet(ds) Then
    '        With Me.comboCompanyIBAN
    '            .BeginUpdate()
    '            .Items.Clear()
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                .Items.Add(ds.Tables(0).Rows(i).Item(0))
    '            Next i
    '            ' .ValueMember = "Bnk_Code"
    '            .SelectedIndex = 0
    '            .EndUpdate()
    '        End With
    '    End If
    'End Sub
    'Private Sub LoadCombo_Payslips(ByVal TempGroupCode As String)

    '    Dim ds As DataSet
    '    Dim i As Integer
    '    ds = Global1.Business.GetAllPayslipsOfTemplateGroupCode(TempGroupCode)
    '    If CheckDataSet(ds) Then
    '        With Me.comboPayslip
    '            .BeginUpdate()
    '            .Items.Clear()
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                .Items.Add(ds.Tables(0).Rows(i).Item(0))
    '            Next i
    '            ' .ValueMember = "Bnk_Code"
    '            .SelectedIndex = 0
    '            .EndUpdate()
    '        End With
    '    End If
    'End Sub
    'Private Sub ComboTempGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTempGroups.SelectedIndexChanged
    '    If Loading Then Exit Sub
    '    Dim TempGroup As String
    '    TempGroup = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code
    '    LoadCombo_IBAN(TempGroup)
    '    LoadCombo_Payslips(TempGroup)

    'End Sub
    Private Sub ReadParameters()
        IsConnected = False
        Try

            Dim P1 As New cPrSsParameters("EXLSys", "WebsLogin")
            If P1.Value1 <> "" Then
                WSLogin = P1.Value1
            End If

            Dim P2 As New cPrSsParameters("EXLSys", "WebsPassword")
            If P2.Value1 <> "" Then
                WSPassword = P2.Value1
            End If

            Dim P3 As New cPrSsParameters("EXLSys", "WebsCompany")
            If P3.Value1 <> "" Then
                WSBusinessEntity = P3.Value1
            End If

            Dim P4 As New cPrSsParameters("EXLSys", "WebsEmpFillType")
            If P4.Value1 <> "" Then
                WSEmplloyeeFillType = P4.Value1
            End If

            Dim P5 As New cPrSsParameters("EXLSys", "DefBank")
            If P5.Value1 <> "" Then
                DefBank = P5.Value1
            End If

            Dim P6 As New cPrSsParameters("EXLSys", "DefIBAN")
            If P6.Value1 <> "" Then
                DefIBAN = P6.Value1
            End If

            Dim P7 As New cPrSsParameters("EXLSys", "DefPayslip")
            If P7.Value1 <> "" Then
                DefPayslip = P7.Value1
            End If

            Dim P8 As New cPrSsParameters("EXLSys", "PayUser")
            If P8.Value1 <> "" Then
                PayrollUser = P8.Value1
            End If

            ParamDate = New cPrSsParameters("EXLSys", "LastUpdate")

            Dim D As Date
            D = CDate(ParamDate.Value1)
            DateLastUpdate.Value = D


            Dim DD As Date = Me.DateLastUpdate.Value.Date
            DD = DateAdd(DateInterval.Day, -1, DD)
            SyncFromDate.Value = Format(DD, "yyyy-MM-dd")


            Dim firstDayOfMonth As New Date(DD.Year, DD.Month, 1)
            SyncFromDate.Value = firstDayOfMonth


            Me.txtEXLLogin.Text = WSLogin
            Me.txtEXLPass.Text = WSPassword
            Me.txtEXLCompany.Text = WSBusinessEntity
            Me.txtEXLFillType.Text = WSEmplloyeeFillType

            Me.txtCompanyBank.Text = DefBank
            Me.txtCompanyIBAN.Text = DefIBAN
            Me.txtPayslip.Text = DefPayslip
        Catch ex As Exception
            Utils.ShowException(ex)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Me.lblloading.visible = True
        EXL_GetData()
        Me.lblloading.visible = False
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub EXL_GetData()

        'Dim Login As String = "john"
        'Dim Password As String = "Demo$11"
        'Dim BusinessEntity As String = "ABC Co Ltd"
        'Dim EmployeeFillType As String = "Simple"
        Application.DoEvents()
        Dim PayU As New cAaSsUsers()

        Dim Exx As New SystemException
        Dim TemplateGroupForLoading As String
        TemplateGroupForLoading = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code

        ' Declare Employee Defaults
        Dim EmployeeCodeNumeric As String
        Dim FirstName As String
        Dim MiddleName As String
        Dim LastName As String
        Dim EmployeeCode As String
        Dim Gender As String
        Dim JobTitle As String
        Dim BirthDate As String
        Dim Status As String
        Dim EmploymentDate As String
        Dim AnnualLeave As String
        Dim MaritalStatus As String
        Dim SocialSecurityNo As String
        Dim IdentityCardNo As String
        Dim PassportNo As String
        Dim AlienNumber As String
        Dim IncomeTaxNo As String
        Dim WorkEMail As String
        Dim DepartmentCode As String
        Dim Department1 As String
        Dim Department2 As String
        Dim Department3 As String
        Dim Department4 As String
        Dim Department5 As String

        'Dim PayrollNo As String
        Dim BankName As String
        Dim BankAccountNo As String
        Dim IBAN As String
        Dim SWIFT As String
        Dim TerminationDate As String

        Dim FullAddress As String
        Dim AddressLine1 As String
        Dim AddressLine2 As String
        Dim AddressLine3 As String
        Dim PostCode As String
        Dim POBox As String
        Dim POBoxPostCode As String
        Dim City As String
        Dim PhoneNo As String
        Dim MobilePhone As String
        Dim Email As String
        Dim Email2 As String
        Dim Email22 As String
        Dim JobDescriptionCode As String
        Dim EmployeeJobDescription As String
        Dim PayrollCompanyNo As String
        Dim TemplateGroupCode As String
        Dim Notes As String
        Dim Password As String
        Dim Nationality As String
        Dim BankBenName As String
        '----------------------------------------------

        Dim DepFull1 As String
        Dim DepFull2 As String
        Dim PosFull As String
        Dim SocCatFull As String
        Dim BankCodeFull As String


        Dim DepartmentCode1 As String = ""
        Dim DepartmentCode2 As String = ""
        Dim DepartmentCode3 As String = ""
        Dim DepartmentCode4 As String = ""
        Dim DepartmentCode5 As String = ""

        Dim Position As String
        Dim PositionCode1 As String

        Dim SiCatCode As String

        Dim BankCode As String

        Dim Salary As String
        Dim SalaryLastUpdateDate As Date

        Dim BanAccount As String
        Dim HireReason As String = ""

        '----------------------------------------------
        'FindDefaults()
        Dim dsTemplateGroup As DataSet
        Dim dsAnal1 As DataSet
        Dim dsAnal2 As DataSet
        Dim dsAnal3 As DataSet
        Dim dsAnal4 As DataSet
        Dim dsAnal5 As DataSet
        Dim dsUnions As DataSet
        Dim dsCountries As DataSet
        Dim dsEmpPosition As DataSet
        Dim dsSIcategory As DataSet
        Dim dsEmpCommunity As DataSet
        Dim dsPayUnits As DataSet
        Dim dsCurCode As DataSet
        Dim dsPayMethods As DataSet
        Dim dsBanks As DataSet
        Dim dsTaxCardtype As DataSet
        Dim dsProFund As DataSet
        Dim dsMedicalFund As DataSet
        Dim dsSocialInsurance As DataSet
        Dim dsGesi As DataSet

        Dim dsIndustrial As DataSet
        Dim dsUnemployment As DataSet
        Dim dsSocialCohesion As DataSet
        Dim dsSectorPay As DataSet
        Dim dsCommissionRates As DataSet
        Dim dsPerformanceBonus As DataSet
        Dim dsdutyHours As DataSet
        Dim dsOverLay As DataSet
        Dim dsFlightHours As DataSet
        Dim ContinueWithLoading As Boolean
        Dim CompanySocialInsuranceNo As String

        Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
        Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
        Dim ALLeaveInUnits As Double
        Dim Units As String
        Dim GenAnalysis1 As String
        Dim EmpCodeFromExcel As String
        CompanySocialInsuranceNo = Comp.SIRegNo

        dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
        dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
        dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
        dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        dsUnions = Global1.Business.AG_GetAllPrAnUnions()
        dsCountries = Global1.Business.AG_GetAllAdAnCountries()
        dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
        dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
        dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
        dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
        dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
        dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
        dsBanks = Global1.Business.AG_GetAllPrAnBanks()
        dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
        dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
        dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
        dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
        dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
        dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
        dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
        dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
        dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
        dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
        dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
        dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
        dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
        dsGesi = Global1.Business.GetAllPrSsGesi



        '''''''''''''''''''''''''''''''''''''''''''''''
        ' End of Declaration





        Me.lblLoading.Text = "Please wait Connecting to Exelsys WebService"
        Application.DoEvents()


        Dim PageSize As Integer = 30
        Dim EmployeeCodeX As String = Trim(Me.txtEmployeeCode.Text)
        Dim DepartmentCodeX As String = ""

        Dim FromDate As Date = SyncFromDate.Value


        '   Dim WebServ As wsExcelsysLive.ExelsysWSI

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12


        Dim WebServ As wsExcelsysLive.ExelsysWSI
        Dim Pages As Integer
        WebServ = New wsExcelsysLive.ExelsysWSI
        Pages = WebServ.GetEmployeesPages(WSLogin, WSPassword, WSBusinessEntity, EmployeeCodeX, DepartmentCodeX, PageSize, FromDate)
        Me.lblLoading.Text = "Connected to Exelsys WebService"
        Application.DoEvents()
        'Pages = WebServ.GetEmployeesPages("NETSync@NETSync.com", "NETInfo$2024", "NETinfo", "", "", 30, "2024-01-01")

        Dim i As Integer
        'Dim Emp() As wsExcelsysDemo.EmployeeWSI


        Dim SocialInsuranceCodeForM2 As String
        SocialInsuranceCodeForM2 = Me.FindSICodeFromRates(0, 0)


        Dim Emp() As wsExcelsysLive.EmployeeWSI
        For i = 0 To Pages - 1
            Dim MyPage As Integer
            MyPage = i + 1
            Emp = WebServ.GetEmployeesPaged(WSLogin, WSPassword, WSBusinessEntity, EmployeeCodeX, DepartmentCodeX, MyPage, PageSize, FromDate, WSEmplloyeeFillType)
            Dim k As Integer
            Dim EmpCode As String = ""
            Dim ThisIsNewEmployee As String
            For k = 0 To Emp.Length - 1
                Dim AllowToSynchronize As String = 0
                Dim SIcommunity As String = "E"

                Dim l As Integer
                For l = 0 To Emp(k).UserFields.Length - 1
                    Dim ss As String
                    ss = Emp(k).UserFields(l).Name
                    Select Case ss
                        Case "ALLOWTOSYNCHRONIZE"
                            AllowToSynchronize = NothingToEmpty(Emp(k).UserFields(l).Value)
                        Case "SOCIALINSURANCECOMMUNITY"
                            Dim TempSI As String
                            Dim ArSI() As String
                            TempSI = NothingToEmpty(Emp(k).UserFields(l).Value)
                            ArSI = TempSI.Split("=")
                            SIcommunity = Trim(ArSI(0))
                            If SIcommunity = "A" Or SIcommunity = "E" Or SIcommunity = "K" Or SIcommunity = "L" Or SIcommunity = "T" Or SIcommunity = "D" Or SIcommunity = "M" Then
                                'Do Nothing
                            Else

                                SIcommunity = "E"
                            End If

                    End Select
                Next

                If UCase(AllowToSynchronize) = "YES" Then
                    EmpCode = Emp(k).EmployeeCode

                    Me.lblLoading.Text = "Please wait Loading Employee With Code: " & EmpCode
                    Application.DoEvents()

                    Dim NewEmp As New cPrMsEmployees(EmpCode)
                    If NewEmp.Code = "" Then
                        ThisIsNewEmployee = "1"
                    Else
                        ThisIsNewEmployee = "0"
                    End If
                    Application.DoEvents()
                    With NewEmp
                        .PayTyp_Code = "M01"
                        Dim AllowTosync As String = ""
                        Dim TempStatus As String
                        TempStatus = NothingToEmpty(Emp(k).Status)



                        .Code = NothingToEmpty(Emp(k).EmployeeCode)
                        '.Title = NothingToEmpty(Emp(k).NamePrefix)

                        If NothingToEmpty(Emp(k).Gender) = "Male" Then
                            .Title = "MR"
                            .Sex = "M"
                        Else
                            .Title = "MRS"
                            .Sex = "F"
                        End If
                        .TaxID = NothingToEmpty(Emp(k).TaxCode)

                        Dim SicCodeFromExelsys As String

                        SicCodeFromExelsys = NothingToEmpty(Emp(k).EmployeeStatisticalCode)
                        'If SicCodeFromExelsys <> "" Then
                        '    MsgBox(EmpCode)
                        'End If
                        If SicCodeFromExelsys = "02" Then
                            SicCodeFromExelsys = "M2"
                        ElseIf SicCodeFromExelsys = "01" Then
                            SicCodeFromExelsys = "M1"
                        Else
                            SicCodeFromExelsys = "M1"
                        End If


                        'Dim SBEN As String
                        'Dim S1() As wsExcelsysLive.EmployeeBenefitWSI

                        'S1 = Emp(k).EmployeeBenefits

                        'SBEN = Emp(k).EmployeeBenefits(0).Description



                        .Sic_Code = SicCodeFromExelsys


                        'If NothingToEmpty(Emp(k).Status) <> "Active" Then
                        '    .Status = "Innactive"
                        'Else
                        '    .Status = "Active"
                        'End If
                        If ThisIsNewEmployee Then
                            .Status = "Active"
                        End If
                        .LastName = NothingToEmpty(Emp(k).LastName)
                        .FirstName = NothingToEmpty(Emp(k).KnownAs)
                        .FullName = .LastName & " " & .FirstName
                        .StartDate = NothingToEmpty(Emp(k).EmploymentDate)
                        EmploymentDate = .StartDate
                        .BirthDate = NothingToEmpty(Emp(k).BirthDate)
                        .TerminateDate = NothingToEmpty(Emp(k).TerminationDate)
                        If NothingToEmpty(Emp(k).MaritalStatus) = "" Then
                            .MarSta_Code = "S"
                        Else
                            .MarSta_Code = FindBmaritalstatus(NothingToEmpty(Emp(k).MaritalStatus))

                        End If


                        AddressLine1 = NothingToEmpty(Emp(k).MainAddress.AddressLine1)
                        AddressLine1 = AddressLine1.Replace("!", "")
                        AddressLine1 = AddressLine1.Replace("&", "")
                        AddressLine1 = AddressLine1.Replace("$", "")
                        AddressLine1 = AddressLine1.Replace("@", "")
                        AddressLine1 = AddressLine1.Replace("/", "")
                        '  AddressLine1 = AddressLine1.Replace(",", "")
                        AddressLine1 = AddressLine1.Replace("-", "")
                        ' AddressLine1 = AddressLine1.Replace(".", "")
                        AddressLine1 = AddressLine1.Replace("'", "")

                        AddressLine2 = NothingToEmpty(Emp(k).MainAddress.AddressLine2)
                        AddressLine2 = AddressLine2.Replace("!", "")
                        AddressLine2 = AddressLine2.Replace("&", "")
                        AddressLine2 = AddressLine2.Replace("$", "")
                        AddressLine2 = AddressLine2.Replace("@", "")
                        'AddressLine2 = AddressLine2.Replace(",", "")
                        AddressLine2 = AddressLine2.Replace("-", "")
                        'AddressLine2 = AddressLine2.Replace(".", "")
                        AddressLine2 = AddressLine2.Replace("'", "")


                        .Address1 = AddressLine1
                        .Address3 = AddressLine2
                        .Address2 = NothingToEmpty(Emp(k).City)


                        .PostCode = NothingToEmpty(Emp(k).PostCode)
                        .Telephone1 = NothingToEmpty(Emp(k).MobilePhone)
                        .Telephone2 = ""
                        .Email = NothingToEmpty(Emp(k).WorkEMail)
                        '.Email2 = NothingToEmpty(Emp(k).eMail)
                        If ThisIsNewEmployee Then
                            .Email2 = ""
                        End If
                        .Password = ""

                        .SocialInsNumber = NothingToEmpty(Emp(k).SocialSecurityNo)
                        .IdentificationCard = NothingToEmpty(Emp(k).IdentityCardNo)
                        .TaxID = NothingToEmpty(Emp(k).IncomeTaxNo)
                        .AlienNumber = NothingToEmpty(Emp(k).WorkPermitReference)
                        .TicTyp_Code = "1"
                        .PassportNumber = NothingToEmpty(Emp(k).PassportNo)

                        'Department1 = NothingToEmpty(Emp(k).PayrollCompanyNo)
                        ' Dim Anl1 As New cPrAnEmployeeAnalysis1(Department1)
                        'If Anl1.Code = "" Or Anl1.Code Is Nothing Then
                        Department1 = "ENEW"
                        'End If

                        Department2 = NothingToEmpty(Emp(k).DepartmentCode)
                        If Department2.Length > 3 Then
                            Department2 = Department2.Substring(0, 3)
                        End If
                        Dim Anl2 As New cPrAnEmployeeAnalysis2(Department2)
                        If Anl2.Code = "" Or Anl2.Code Is Nothing Then
                            Department2 = "ENEW"
                        End If

                        'Department3 = NothingToEmpty(Emp(k).ParentDepartmentCode)
                        'Dim Anl3 As New cPrAnEmployeeAnalysis3(Department3)
                        'If Anl3.Code = "" Or Anl3.Code Is Nothing Then
                        Department3 = "ENEW"
                        'End If

                        Department4 = "ENEW"

                        Department5 = NothingToEmpty(NothingToEmpty(Emp(k).DepartmentCode))
                        If Department5.Length > 3 Then
                            Department5 = Department5.Substring(0, 3)
                        End If
                        Dim Anl5 As New cPrAnEmployeeAnalysis5(Department5)
                        If Anl5.EmpAn5_Code = "" Or Anl5.EmpAn5_Code Is Nothing Then
                            Department5 = "ENEW"
                        End If

                        .EmpAn1_Code = Department1
                        .EmpAn2_Code = Department2
                        .EmpAn3_Code = Department3
                        .EmpAn4_Code = Department4
                        .EmpAn5_Code = Department5

                        .Uni_Code = "ENEW"




                        Dim PositionDesc As String
                        Dim PositionCode As String
                        PositionDesc = NothingToEmpty(Emp(k).EmployeeJobDescription)
                        PositionCode = NothingToEmpty(Emp(k).EmployeeJobDescriptionCode)
                        Dim P As New cPrAnEmployeePositions(PositionCode)
                        If P.Code = "" Then
                            P.Code = PositionCode
                            If PositionDesc.Length <= 40 Then
                                P.DescriptionL = PositionDesc
                            Else
                                P.DescriptionL = PositionDesc.Substring(0, 39)
                            End If
                            If PositionDesc.Length <= 15 Then
                                P.DescriptionS = PositionDesc
                            Else
                                P.DescriptionS = PositionDesc.Substring(0, 14)
                            End If

                            P.IsActive = "Y"
                            P.Units = ""
                            P.Save()
                        End If

                        .EmpPos_Code = PositionCode

                        .EmpCmm_Code = SIcommunity

                        .PayUni_Code = NothingToEmpty(Emp(k).SalaryType)
                        If .PayUni_Code = "MonthlyGross" Then
                            .PayUni_Code = "1"
                        Else
                            .PayUni_Code = "2"
                        End If
                        .PeriodUnits = 0
                        .AnnualUnits = 0
                        .Cur_Code = "EUR"
                        .PmtMth_Code = "3"

                        .BankAccount = NothingToEmpty(Emp(k).BankAccountNo)
                        .BankAccountCo = Me.txtCompanyIBAN.Text
                        .IBAN = NothingToEmpty(Emp(k).IBAN)


                        .Bnk_Code = NothingToEmpty(Emp(k).BankName)
                        BankCode = FindBankCodeFromCode(dsBanks, .Bnk_Code)
                        .Bnk_Code = BankCode
                        If BankCode = "" Then
                            .Bnk_Code = "ENEW"
                        End If

                        'SWIFT = NothingToEmpty(Emp(k).SWIFT)
                        'If SWIFT = "" Then
                        '    BankCode = "ENEW"
                        'Else
                        '    BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
                        '    If BankCode = "" Then
                        '        BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
                        '        If BankCode = "" Then
                        '            BankCode = "ENEW"
                        '        End If
                        '    End If
                        'End If
                        '.Bnk_Code = BankCode


                        Salary = Emp(k).CurrentSalaryAmount

                        Dim strLastUpdateDate As String = ""
                        If NothingToEmpty(Emp(k).SalaryLastUpdated) = "" Then
                            SalaryLastUpdateDate = CDate("1900-01-01")
                        Else
                            SalaryLastUpdateDate = Emp(k).SalaryLastUpdated
                        End If


                        ' Emp(k).UserFields(0).Name

                        BankBenName = ""

                        GenAnalysis1 = ""
                        HireReason = "N"
                        Notes = ""

                        .EmpSta_Code = "A"
                        .TemGrp_Code = TemplateGroupForLoading
                        .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

                        '.EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                        .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                        .Cou_Code = GetFirstRecordOfDataset(dsCountries)

                        .Bnk_CodeCo = Me.txtCompanyBank.Text
                        .BankAccountCo = Me.txtCompanyIBAN.Text
                        TerminationDate = .TerminateDate
                        If TerminationDate <> "" Then
                            Dim S As String
                            Dim D As String
                            D = CdateExelsys(TerminationDate)
                            S = D

                            .TerminateDate = S
                        Else
                            .TerminateDate = ""
                        End If


                        If ThisIsNewEmployee Then
                            .PreviousEarnings = CDbl(0)
                            .Emp_PrevSIDeduct = CDbl(0)
                            .Emp_PrevSIContribute = CDbl(0)
                            .Emp_PrevITDeduct = CDbl(0)
                            .Emp_PrevPFDeduct = CDbl(0)
                            .PreviousLifeIns = CDbl(0)
                            .PreviousDis = CDbl(0)
                            .PreviousST = CDbl(0)
                            .PreviousGesiC = CDbl(0)
                            .PreviousGesiD = CDbl(0)
                            .PreviousUnion = CDbl(0)
                            .PrevMedFund = CDbl(0)
                            .PrevPensionFund = CDbl(0)


                            .OtherIncome1 = CDbl(0)
                            .OtherIncome2 = CDbl(0)
                            .OtherIncome3 = CDbl(0)
                        End If

                        .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                        .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                        '.SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance)
                        If SicCodeFromExelsys = "M1" Then
                            .SocInc_Code = CType(Me.ComboSI.SelectedItem, cPrSsSocialInsurance).Code
                        Else
                            .SocInc_Code = SocialInsuranceCodeForM2
                        End If
                        .GESICode = GetFirstRecordOfDataset(dsGesi)

                        .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                        .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                        .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)

                        If ThisIsNewEmployee Then
                            .InterfaceTemCode = TemplateGroupForLoading
                            .InterfacePFCode = TemplateGroupForLoading
                            .InterfaceMFCode = TemplateGroupForLoading
                        End If

                        .DrivingLicense = ""
                        .PensionNo = ""
                        .MyPayslipReport = Me.txtPayslip.Text


                        .OtherIncome4 = CDbl(0)

                        .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                        .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                        .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                        .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                        .OverLay = GetFirstRecordOfDataset(dsOverLay)
                        .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                        .FullPassName = ""
                        .Traveldocs = ""
                        If ThisIsNewEmployee Then
                            .FirstEmployment = "0"
                        End If
                        .IsSI = 0
                        .Splitemployement = "0"
                        .BankBenName = ""

                        If ThisIsNewEmployee Then
                            .NewEmployee = "1"
                            .FEControlAmount = 0
                            .f50PercOff = 0
                            .Force50Percent = 0
                            .Emp_GLAnal1 = ""
                            .Emp_GLAnal2 = ""
                            .Emp_GLAnal3 = ""
                            .Emp_GLAnal4 = ""
                        End If

                        .PensionType = "0"
                        If ThisIsNewEmployee Then
                            .CreationDate = Now.Date
                            .CreatedBy = PayrollUser
                        End If
                        .AmendDate = Now.Date
                        .AmendBy = PayrollUser

                        .Notes = Notes
                        .AnalGen1 = GenAnalysis1
                        .HireReason = HireReason
                        .TermReason = ""


                        Dim EmpBen() As wsExcelsysLive.EmployeeBenefitWSI
                        Dim CCcode As String
                        CCcode = NothingToEmpty(Emp(k).EmployeeCode)
                        Dim m As Integer
                        EmpBen = WebServ.GetEmployeeBenefits(WSLogin, WSPassword, WSBusinessEntity, CCcode)
                        Dim PF1 As New cTempPF
                        PF1.Code = "ENEW"
                        For m = 0 To EmpBen.Length - 1
                            Dim Type As String
                            Type = EmpBen(m).BenefitType

                            If Type = "Provident Fund" Then

                                Dim DVal As Double = EmpBen(m).EmployeeAmount
                                Dim CVal As Double = EmpBen(m).Amount
                                Dim Date1 As Date = CDate(EmpBen(m).ValidFrom)
                                Dim PFCode As String = ""
                                PFCode = FindPFCodeFromRates(DVal, CVal)
                                If PFCode = "" Then
                                    PFCode = "ENEW"
                                End If
                                If PF1.ValidFrom <= Date1 And Date1 <= Now.Date Then
                                    PF1.Code = PFCode
                                    PF1.ValidFrom = Date1
                                End If
                            End If
                        Next
                        .ProFnd_Code = pf1.Code

                        If Not .Save(False) Then
                            Throw Exx
                            MsgBox("error on employee with Code:" & EmpCode)
                        Else
                            Dim SalVal As Double = Salary
                            Salary = Replace(Salary, "$", "")
                            Salary = Replace(Salary, "€", "")
                            Salary = Replace(Salary, """", "")
                            Salary = Trim(Salary)
                            SalVal = CDbl(Salary)


                            Dim EmpSal As New cPrTxEmployeeSalary(EmpCode, SalaryLastUpdateDate)
                            If EmpSal.Id = 0 Then
                                With EmpSal
                                    ' .Id = 0
                                    .Emp_Code = EmpCode
                                    .Date1 = Now.Date
                                    .SalaryValue = CDbl(SalVal)
                                    .Basic = CDbl(0)
                                    .EffPayDate = CDate(SalaryLastUpdateDate.Date)
                                    .Cola = CDbl(0)
                                    .EffArrearsDate = CDate(SalaryLastUpdateDate.Date)
                                    .Usr_Id = PayrollUser
                                    .myRate = CDbl(0)
                                    .IsCola = "N"
                                    .EmpSal_Dif = CDbl(0)

                                    If Not .Save() Then
                                        Throw Exx
                                    End If
                                End With
                            Else
                                If EmpSal.SalaryValue <> CDbl(SalVal) Then
                                    With EmpSal
                                        .Date1 = Now.Date
                                        .SalaryValue = CDbl(SalVal)
                                        .Basic = CDbl(0)
                                        .EffPayDate = CDate(SalaryLastUpdateDate.Date)
                                        .Cola = CDbl(0)
                                        .EffArrearsDate = CDate(SalaryLastUpdateDate.Date)
                                        .Usr_Id = PayrollUser
                                        .myRate = CDbl(0)
                                        .IsCola = "N"
                                        .EmpSal_Dif = CDbl(0)
                                        If Not .Save() Then
                                            Throw Exx
                                        End If
                                    End With
                                End If
                            End If

                            Dim j As Integer
                            Dim DsErn As DataSet
                            DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupForLoading)
                            If CheckDataSet(DsErn) Then
                                For j = 0 To DsErn.Tables(0).Rows.Count - 1
                                    Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(j))
                                    Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
                                    EmpErn.EmpCode = .Code
                                    EmpErn.ErnCode = E1.ErnCodCode
                                    EmpErn.MyValue = "0.00"
                                    EmpErn.TemGrpCode = .TemGrp_Code
                                    If Not EmpErn.Save Then
                                        Throw Exx
                                    End If
                                Next
                            End If
                            'Deductions
                            Dim DsDed As DataSet
                            DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupForLoading)
                            If CheckDataSet(DsDed) Then
                                For j = 0 To DsDed.Tables(0).Rows.Count - 1
                                    Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(j))
                                    Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
                                    EmpDed.EmpCode = .Code
                                    EmpDed.DedCode = D.DedCodCode
                                    EmpDed.MyValue = "0.00"
                                    EmpDed.TemGrpCode = .TemGrp_Code
                                    If Not EmpDed.Save Then
                                        Throw Exx
                                    End If
                                Next
                            End If
                            'Contributions
                            Dim DsCon As DataSet
                            DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupForLoading)
                            If CheckDataSet(DsCon) Then
                                For j = 0 To DsCon.Tables(0).Rows.Count - 1
                                    Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(j))
                                    Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
                                    EmpCon.EmpCode = .Code
                                    EmpCon.ConCode = C.ConCodCode
                                    EmpCon.MyValue = "0.00"
                                    EmpCon.TemGrpCode = .TemGrp_Code
                                    If Not C.Save Then
                                        Throw Exx
                                    End If
                                Next
                            End If
                        End If
                    End With
                End If ' allow to Sync
            Next
        Next




        ParamDate.Value1 = Format(Now.Date, "yyyy-MM-dd")
        ParamDate.Save()
        MsgBox("Data are Loaded from Exelsys", MsgBoxStyle.Information)
        Application.DoEvents
    End Sub
    Private Function FindPFCodeFromRates(DedValue As Double, ConValue As Double)
        '  DedValue = Utils.RoundMe2(DedValue * 100, 2)
        ' ConValue = Utils.RoundMe2(ConValue * 100, 2)
        Dim Code As String
        Code = Global1.Business.FindProvFundCodeFromDedValueConValue(DedValue, ConValue)
        Return Code

    End Function
    Private Function FindSICodeFromRates(DedValue As Double, ConValue As Double)
        'DedValue = Utils.RoundMe2(DedValue * 100, 2)
        'ConValue = Utils.RoundMe2(ConValue * 100, 2)
        Dim Code As String
        Code = Global1.Business.FindSocialInsuranceCodeFromDedValueConValue(DedValue, ConValue)
        Return Code


    End Function
    Private Function FindBmaritalstatus(ExStatus As String) As String
        Dim S As String = "S"
        If UCase(ExStatus) = "SINGLE" Then
            S = "S"
        End If
        If UCase(ExStatus) = "MARRIED" Then
            S = "M"
        End If
        If UCase(ExStatus) = "WIDOWED" Then
            S = "W"
        End If
        If UCase(ExStatus) = "DIVORCED" Then
            S = "D"
        End If
        If UCase(ExStatus) = "ENGAGED" Then
            S = "E"
        End If
        Return S
    End Function

    'Private Function FindDepartment1CodeFromDesc(ByVal DepartmentDesc As String) As String
    '    Dim Code As String = ""
    '    Code = Global1.Business.GetDepartment1CodeFromDesc(DepartmentDesc)
    '    Return Code
    'End Function
    'Private Function FindDepartment2CodeFromDesc(ByVal DepartmentDesc As String) As String
    '    Dim Code As String = ""
    '    Code = Global1.Business.GetDepartment2CodeFromDesc(DepartmentDesc)
    '    Return Code
    'End Function
    'Private Function FindDepartment3CodeFromDesc(ByVal DepartmentDesc As String) As String
    '    Dim Code As String = ""
    '    Code = Global1.Business.GetDepartment3CodeFromDesc(DepartmentDesc)
    '    Return Code
    'End Function
    'Private Function FindDepartment4CodeFromDesc(ByVal DepartmentDesc As String) As String
    '    Dim Code As String = ""
    '    Code = Global1.Business.GetDepartment4CodeFromDesc(DepartmentDesc)
    '    Return Code
    'End Function
    'Private Function FindDepartment5CodeFromDesc(ByVal DepartmentDesc As String) As String
    '    Dim Code As String = ""
    '    Code = Global1.Business.GetDepartment5CodeFromDesc(DepartmentDesc)
    '    Return Code
    'End Function
    Private Function GetPositionCodeFromDesc(ByVal PositionDesc As String) As String
        Dim Code As String = ""
        Try
            Code = Global1.Business.GetPositionCodeFromDesc(PositionDesc)
            If Code = "" Then
                Code = Global1.Business.GetLastEmployeePositionCode
                Dim P As New cPrAnEmployeePositions(Code)
                If P.Code = "" Then
                    P.Code = Code
                    P.DescriptionL = PositionDesc
                    P.DescriptionS = PositionDesc
                    P.IsActive = True
                    P.Units = ""
                    P.Save()
                End If
            End If
        Catch ex As Exception

        End Try
        Return Code
    End Function
    Private Function Cdate1(ByVal S As String) As Date
        Dim Ar() As String
        Dim Ar1() As String

        Ar1 = S.Split(" ")

        S = Ar1(0)

        Ar = S.Split("/")

        Dim D As String = Ar(0)
        Dim M As String = Ar(1)
        Dim Y As String = Ar(2)

        Dim date1 As Date
        date1 = CDate(Y & "/" & M & "/" & D)
        Return date1

    End Function
    Private Function CdateExelsys(ByVal S As String) As String
        Dim Ar() As String
        Dim Ar1() As String

        Ar1 = S.Split(" ")

        S = Ar1(0)

        Ar = S.Split("/")

        Dim M As String = Ar(0).PadLeft(2, "0")
        Dim D As String = Ar(1).PadLeft(2, "0")
        Dim Y As String = Ar(2).PadLeft(2, "0")

        Dim date1 As String
        date1 = Y & "/" & M & "/" & D
        Return date1

    End Function
    Private Function GetFirstRecordOfDataset(ByVal ds As DataSet, Optional ByVal Code As String = "", Optional ByVal SearchOnDescription As Boolean = False) As String


        Dim Str As String = ""
        Dim RetCode As String = ""
        If Code = "" Then
            If CheckDataSet(ds) Then

                Str = DbNullToString(ds.Tables(0).Rows(0).Item(0))
            End If
        Else
            If CheckDataSet(ds) Then
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If SearchOnDescription Then
                        Str = DbNullToString(ds.Tables(0).Rows(i).Item(1))
                    Else
                        Str = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    End If

                    ' Debug.WriteLine(Code)
                    If Str = Code Then
                        RetCode = DbNullToString(ds.Tables(0).Rows(i).Item(0))
                    End If
                Next
                If RetCode = "" Then
                    If CheckDataSet(ds) Then
                        Str = DbNullToString(ds.Tables(0).Rows(0).Item(0))
                    End If
                Else
                    Str = RetCode
                End If

            End If
        End If

        Return Str
    End Function
    Private Function FindBankCodeFromSWIFT(ByVal dsBanks As DataSet, ByVal SWIFT As String, ByVal CheckFurther As Boolean) As String
        Dim S As String = ""
        Dim BankCode As String = ""
        Select Case SWIFT
            Case "CBCYCY2N"
                S = "01"
            Case "BCYPCY2N"
                S = "02"
            Case "LIKICY2N"
                S = "03"
            Case "HEBACY2N"
                S = "05"
            Case "ETHNCY2N"
                S = "06"
            Case "CCBKCY2N"
                S = "07"
            Case "PIRBCY2N"
                S = "08"
            Case "ABKLCY2N"
                S = "09"
            Case "EMPOCY2N"
                S = "10"
            Case "UNVKCY2N"
                S = "11"
            Case "SOGECY2N"
                S = "12"
            Case "CYDBCY2N"
                S = "14"
            Case "EFGBCY2N"
                S = "18"
            Case "CECBCY2N"
                S = "20"
            Case "CCBKCY2N"
                S = "21"
            Case "RCBLCY2I"
                S = "23"
            Case "ERBKCY2N"
                S = "24"
            Case "ANCOCY2N"
                S = "97"
            Case "INGBNL2A"
                S = "99"
            Case "ERBKGRAASEC"
                S = "98"
            Case "WIREDEMM"
                S = "90"
            Case "POALILIT"
                S = "96"
            Case "RNCBROBU"
                S = "95"
            Case "AIZKLV22"
                S = "94"
            Case "LOYDGB2L"
                S = "93"
            Case "DNBANOKK"
                S = "92"
        End Select

        If CheckDataSet(dsBanks) Then
            Dim i As Integer
            Dim Code As String = ""
            For i = 0 To dsBanks.Tables(0).Rows.Count - 1
                Code = DbNullToString(dsBanks.Tables(0).Rows(i).Item(4))
                If Code = S And Code <> "" Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(i).Item(0))
                    Exit For
                End If
            Next
            If CheckFurther Then
                If BankCode = "" Then
                    If SWIFT = "" Or SWIFT Is Nothing Then
                        BankCode = DbNullToString(dsBanks.Tables(0).Rows(0).Item(0))
                    Else
                        MsgBox("Swift number not found " & SWIFT)
                    End If
                End If
            End If
        End If

        Return BankCode

    End Function
    Private Function FindBankCodeFromSWIFT2(ByVal dsBanks As DataSet, ByVal SWIFT As String) As String
        Dim S As String = ""
        Dim BankCode As String = ""
        Dim Swift1 As String

        If CheckDataSet(dsBanks) Then
            Dim i As Integer
            Dim Code As String = ""
            For i = 0 To dsBanks.Tables(0).Rows.Count - 1
                Swift1 = DbNullToString(dsBanks.Tables(0).Rows(i).Item(5))
                If Swift1 = SWIFT Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(i).Item(0))
                    Exit For
                End If
            Next
            If BankCode = "" Then
                If SWIFT = "" Or SWIFT Is Nothing Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(0).Item(0))
                Else
                    MsgBox("Swift number not found " & SWIFT)
                End If
            End If
        End If

        Return BankCode

    End Function
    Private Function FindBankCodeFromCode(ByVal dsBanks As DataSet, ByVal BCode As String) As String
        Dim S As String = ""
        Dim BankCode As String = ""
        Dim Code1 As String

        If CheckDataSet(dsBanks) Then
            Dim i As Integer
            Dim Code As String = ""
            For i = 0 To dsBanks.Tables(0).Rows.Count - 1
                Code1 = DbNullToString(dsBanks.Tables(0).Rows(i).Item(0))
                If Code1 = BCode Then
                    BankCode = DbNullToString(dsBanks.Tables(0).Rows(i).Item(0))
                    Exit For
                End If
            Next
        End If

        Return BankCode

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        EXL_GetData_DEMO()
        Cursor.Current = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub EXL_GetData_DEMO()

        Dim Login As String = "john"
        Dim Pass1 As String = "Demo$11"
        Dim BusinessEntity As String = "ABC Co Ltd"
        Dim EmployeeFillType As String = "Simple"


        Dim Exx As New SystemException
        Dim TemplateGroupForLoading As String
        TemplateGroupForLoading = CType(Me.ComboTempGroups.SelectedItem, cPrMsTemplateGroup).Code

        ' Declare Employee Defaults
        Dim EmployeeCodeNumeric As String
        Dim FirstName As String
        Dim MiddleName As String
        Dim LastName As String
        Dim EmployeeCode As String
        Dim Gender As String
        Dim JobTitle As String
        Dim BirthDate As String
        Dim Status As String
        Dim EmploymentDate As String
        Dim AnnualLeave As String
        Dim MaritalStatus As String
        Dim SocialSecurityNo As String
        Dim IdentityCardNo As String
        Dim PassportNo As String
        Dim AlienNumber As String
        Dim IncomeTaxNo As String
        Dim WorkEMail As String
        Dim DepartmentCode As String
        Dim Department1 As String
        Dim Department2 As String
        Dim Department3 As String
        Dim Department4 As String

        'Dim PayrollNo As String
        Dim BankName As String
        Dim BankAccountNo As String
        Dim IBAN As String
        Dim SWIFT As String
        Dim TerminationDate As String

        Dim FullAddress As String
        Dim AddressLine1 As String
        Dim AddressLine2 As String
        Dim AddressLine3 As String
        Dim PostCode As String
        Dim POBox As String
        Dim POBoxPostCode As String
        Dim City As String
        Dim PhoneNo As String
        Dim MobilePhone As String
        Dim Email As String
        Dim Email2 As String
        Dim Email22 As String
        Dim JobDescriptionCode As String
        Dim EmployeeJobDescription As String
        Dim PayrollCompanyNo As String
        Dim TemplateGroupCode As String
        Dim Notes As String
        Dim Password As String
        Dim Nationality As String
        Dim BankBenName As String
        '----------------------------------------------

        Dim DepFull1 As String
        Dim DepFull2 As String
        Dim PosFull As String
        Dim SocCatFull As String
        Dim BankCodeFull As String


        Dim DepartmentCode1 As String = ""
        Dim DepartmentCode2 As String = ""
        Dim DepartmentCode3 As String = ""
        Dim DepartmentCode4 As String = ""
        Dim DepartmentCode5 As String = ""

        Dim Position As String
        Dim PositionCode1 As String

        Dim SiCatCode As String

        Dim BankCode As String

        Dim Salary As String

        Dim BanAccount As String
        Dim HireReason As String = ""

        '----------------------------------------------
        'FindDefaults()
        Dim dsTemplateGroup As DataSet
        Dim dsAnal1 As DataSet
        Dim dsAnal2 As DataSet
        Dim dsAnal3 As DataSet
        Dim dsAnal4 As DataSet
        Dim dsAnal5 As DataSet
        Dim dsUnions As DataSet
        Dim dsCountries As DataSet
        Dim dsEmpPosition As DataSet
        Dim dsSIcategory As DataSet
        Dim dsEmpCommunity As DataSet
        Dim dsPayUnits As DataSet
        Dim dsCurCode As DataSet
        Dim dsPayMethods As DataSet
        Dim dsBanks As DataSet
        Dim dsTaxCardtype As DataSet
        Dim dsProFund As DataSet
        Dim dsMedicalFund As DataSet
        Dim dsSocialInsurance As DataSet
        Dim dsGesi As DataSet

        Dim dsIndustrial As DataSet
        Dim dsUnemployment As DataSet
        Dim dsSocialCohesion As DataSet
        Dim dsSectorPay As DataSet
        Dim dsCommissionRates As DataSet
        Dim dsPerformanceBonus As DataSet
        Dim dsdutyHours As DataSet
        Dim dsOverLay As DataSet
        Dim dsFlightHours As DataSet
        Dim ContinueWithLoading As Boolean
        Dim CompanySocialInsuranceNo As String

        Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
        Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
        Dim ALLeaveInUnits As Double
        Dim Units As String
        Dim GenAnalysis1 As String
        Dim EmpCodeFromExcel As String
        CompanySocialInsuranceNo = Comp.SIRegNo

        dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
        dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
        dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
        dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
        dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
        dsUnions = Global1.Business.AG_GetAllPrAnUnions()
        dsCountries = Global1.Business.AG_GetAllAdAnCountries()
        dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
        dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
        dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
        dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
        dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
        dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
        dsBanks = Global1.Business.AG_GetAllPrAnBanks()
        dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
        dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
        dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
        dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
        dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
        dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
        dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
        dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
        dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
        dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
        dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
        dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
        dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
        dsGesi = Global1.Business.GetAllPrSsGesi



        '''''''''''''''''''''''''''''''''''''''''''''''
        ' End of Declaration








        Dim PageSize As Integer = 30
        Dim EmployeeCodeX As String = ""
        Dim DepartmentCodeX As String = ""
        Dim FromDate As String = "2024-01-01"


        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim WebServDEMO As wsExcelsysDemo.ExelsysWSI

        Dim Pages As Integer
        WebServDEMO = New wsExcelsysDemo.ExelsysWSI

        Pages = WebServDEMO.GetEmployeesPages(Login, Pass1, BusinessEntity, EmployeeCodeX, DepartmentCodeX, PageSize, FromDate)

        Dim i As Integer
        Dim Emp() As wsExcelsysDemo.EmployeeWSI

        For i = 0 To Pages - 1
            Dim MyPage As Integer
            MyPage = i + 1
            Emp = WebServDEMO.GetEmployeesPaged(Login, Pass1, BusinessEntity, EmployeeCodeX, DepartmentCodeX, MyPage, PageSize, FromDate, WSEmplloyeeFillType)
            Dim k As Integer
            Dim EmpCode As String = ""
            For k = 0 To Emp.Length - 1
                EmpCode = Emp(k).EmployeeCode
                Dim ThisIsNewEmployee As String
                Dim NewEmp As New cPrMsEmployees(EmpCode)
                If NewEmp.Code = "" Then
                    ThisIsNewEmployee = "1"
                Else
                    ThisIsNewEmployee = "0"
                End If

                With NewEmp
                    .PayTyp_Code = "M01"
                    .Code = NothingToEmpty(Emp(k).EmployeeCode)
                    .Title = NothingToEmpty(Emp(k).NamePrefix)
                    .Sex = NothingToEmpty(Emp(k).Gender)
                    .TaxID = NothingToEmpty(Emp(k).TaxCode)
                    .Sic_Code = NothingToEmpty(Emp(k).EmployeeStatisticalCode)
                    .Status = NothingToEmpty(Emp(k).Status)
                    .LastName = NothingToEmpty(Emp(k).LastName)
                    .FirstName = NothingToEmpty(Emp(k).KnownAs)
                    .FullName = .LastName & " " & .FirstName
                    .StartDate = NothingToEmpty(Emp(k).EmploymentDate)
                    .BirthDate = NothingToEmpty(Emp(k).BirthDate)
                    .TerminateDate = NothingToEmpty(Emp(k).TerminationDate)
                    .MarSta_Code = NothingToEmpty(Emp(k).MaritalStatus)

                    AddressLine1 = NothingToEmpty(Emp(k).MainAddress.AddressLine1)
                    AddressLine1 = AddressLine1.Replace("!", "")
                    AddressLine1 = AddressLine1.Replace("&", "")
                    AddressLine1 = AddressLine1.Replace("$", "")
                    AddressLine1 = AddressLine1.Replace("@", "")
                    AddressLine1 = AddressLine1.Replace("/", "")
                    AddressLine1 = AddressLine1.Replace(",", "")
                    AddressLine1 = AddressLine1.Replace("-", "")
                    AddressLine1 = AddressLine1.Replace(".", "")
                    AddressLine1 = AddressLine1.Replace("'", "")

                    AddressLine2 = NothingToEmpty(Emp(k).MainAddress.AddressLine2)
                    AddressLine2 = AddressLine2.Replace("!", "")
                    AddressLine2 = AddressLine2.Replace("&", "")
                    AddressLine2 = AddressLine2.Replace("$", "")
                    AddressLine2 = AddressLine2.Replace("@", "")
                    AddressLine2 = AddressLine2.Replace(",", "")
                    AddressLine2 = AddressLine2.Replace("-", "")
                    AddressLine2 = AddressLine2.Replace(".", "")
                    AddressLine2 = AddressLine2.Replace("'", "")


                    .Address1 = AddressLine1
                    .Address3 = AddressLine2
                    .Address2 = NothingToEmpty(Emp(k).City)


                    .PostCode = NothingToEmpty(Emp(k).PostCode)
                    .Telephone1 = NothingToEmpty(Emp(k).MobilePhone)
                    .Telephone2 = ""
                    .Email = NothingToEmpty(Emp(k).WorkEMail)
                    .Email2 = NothingToEmpty(Emp(k).eMail)
                    .Password = ""

                    .SocialInsNumber = NothingToEmpty(Emp(k).SocialSecurityNo)
                    .IdentificationCard = NothingToEmpty(Emp(k).IdentityCardNo)
                    .TaxID = NothingToEmpty(Emp(k).IncomeTaxNo)
                    .AlienNumber = NothingToEmpty(Emp(k).WorkPermitReference)
                    .TicTyp_Code = "1"
                    .PassportNumber = NothingToEmpty(Emp(k).PassportNo)
                    .EmpAn1_Code = NothingToEmpty(Emp(k).PayrollCompanyNo)
                    .EmpAn2_Code = NothingToEmpty(Emp(k).ParentDepartmentCode)
                    .EmpAn3_Code = NothingToEmpty(Emp(k).DepartmentCode)
                    .EmpAn4_Code = ""
                    .EmpAn5_Code = NothingToEmpty(NothingToEmpty(Emp(k).ParentDepartmentCode))
                    .Uni_Code = ""
                    .EmpPos_Code = NothingToEmpty(Emp(k).EmployeeJobDescriptionCode)
                    .EmpCmm_Code = "E"
                    .PayUni_Code = NothingToEmpty(Emp(k).SalaryType)
                    .PeriodUnits = 0
                    .AnnualUnits = 0
                    .Cur_Code = "EUR"
                    .PmtMth_Code = "3"
                    .BankAccount = NothingToEmpty(Emp(k).BankAccountNo)
                    .BankAccountCo = NothingToEmpty(Emp(k).BankName)
                    .IBAN = NothingToEmpty(Emp(k).IBAN)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    SWIFT = NothingToEmpty(Emp(k).SWIFT)
                    BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
                    If BankCode = "" Then
                        BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
                    End If


                    Salary = Emp(k).CurrentSalaryAmount
                    BankBenName = ""

                    GenAnalysis1 = ""
                    HireReason = "N"
                    Notes = ""

                    .EmpSta_Code = "A"
                    .TemGrp_Code = TemplateGroupForLoading
                    .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

                    .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
                    .Uni_Code = GetFirstRecordOfDataset(dsUnions)
                    .Cou_Code = GetFirstRecordOfDataset(dsCountries)

                    .Bnk_CodeCo = Me.txtCompanyBank.Text
                    .BankAccountCo = Me.txtCompanyIBAN.Text
                    If TerminationDate <> "" Then
                        Dim S As String
                        Dim D As Date
                        D = Cdate1(TerminationDate)
                        S = Format(D, "yyyy/MM/dd")

                        .TerminateDate = S
                    Else
                        .TerminateDate = ""
                    End If

                    .OtherIncome1 = CDbl(0)
                    .OtherIncome2 = CDbl(0)
                    .OtherIncome3 = CDbl(0)
                    .PreviousEarnings = CDbl(0)
                    .Emp_PrevSIDeduct = CDbl(0)
                    .Emp_PrevSIContribute = CDbl(0)
                    .Emp_PrevITDeduct = CDbl(0)
                    .Emp_PrevPFDeduct = CDbl(0)

                    .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
                    .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
                    '.SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance)
                    .SocInc_Code = CType(Me.ComboSI.SelectedItem, cPrSsSocialInsurance).Code
                    .GESICode = GetFirstRecordOfDataset(dsGesi)

                    .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
                    .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
                    .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)

                    .InterfaceTemCode = TemplateGroupForLoading
                    .InterfacePFCode = TemplateGroupForLoading
                    .InterfaceMFCode = TemplateGroupForLoading

                    .DrivingLicense = ""
                    .PensionNo = ""
                    .MyPayslipReport = Me.txtPayslip.Text

                    .PreviousLifeIns = CDbl(0)
                    .PreviousDis = CDbl(0)
                    .PreviousST = CDbl(0)
                    .OtherIncome4 = CDbl(0)

                    .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
                    .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
                    .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
                    .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
                    .OverLay = GetFirstRecordOfDataset(dsOverLay)
                    .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

                    .FullPassName = ""
                    .Traveldocs = ""

                    .FirstEmployment = "0"
                    .IsSI = 0
                    .Splitemployement = "0"
                    .BankBenName = ""

                    .NewEmployee = ThisIsNewEmployee



                    .Emp_GLAnal1 = ""
                    .Emp_GLAnal2 = ""
                    .Emp_GLAnal3 = ""
                    .Emp_GLAnal4 = ""

                    .PensionType = "0"
                    If ThisIsNewEmployee Then
                        .CreationDate = Now.Date
                        .CreatedBy = PayrollUser
                    End If
                    .AmendDate = Now.Date
                    .AmendBy = PayrollUser
                    .Notes = Notes
                    .AnalGen1 = GenAnalysis1
                    .HireReason = HireReason
                    .TermReason = ""

                    If Not .Save(False) Then
                        Throw Exx
                    End If



                End With
            Next
        Next






    End Sub

    Private Sub btnSendPayslip_Click(sender As Object, e As EventArgs) Handles btnSendPayslip.Click

        Dim Exx As New SystemException

        Try



            Dim PageSize As Integer = 30
            Dim EmployeeCodeX As String = "1022"
            Dim DepartmentCodeX As String = ""
            Dim FromDate As String = "2024-01-01"

            Dim HeaderId As Integer

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim WebServ As wsExcelsysLive.ExelsysWSI
            Dim pDocument As wsExcelsysLive.DocumentWSI
            Dim Pages As Boolean
            WebServ = New wsExcelsysLive.ExelsysWSI
            Dim Emp As New cPrMsEmployees(EmployeeCodeX)
            pDocument = New wsExcelsysLive.DocumentWSI
            Dim TrxHdr As New cPrTxTrxnHeader(HeaderId)

            Dim GuiId As Integer = 1234

            Dim filePath As String = "C:\nodalwin\Payroll\exportfiles\1022.pdf"
            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(filePath)

            pDocument.Description = "Test Payslip"
            pDocument.DocumentType = ".pdf"
            pDocument.OwnerGUID = GuiId
            pDocument.OwnerCode = "SalaryEntry"
            pDocument.CreatedBy = WSLogin
            pDocument.UpdatedBy = WSLogin
            pDocument.CreatedDate = Now.Date
            pDocument.UpdatedBy = Now.Date
            pDocument.Document = fileBytes



            Pages = WebServ.PostSalaryEntry(WSLogin, WSPassword, WSBusinessEntity, Emp.Code, Emp.StartDate, "", "EUR", 0, 0, "MonthlyNet", "Test", 0, 0, 0, 0, 0, 0, GuiId, "", Emp.Code)

            Pages = WebServ.UploadDocument(WSLogin, WSPassword, WSBusinessEntity, pDocument)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try

    End Sub


    'Private Sub Import_From_Excel_Employees_Template_4(ByVal TemplateGroupForLoading As String)



    '    Dim Ern(14) As E_Emp
    '    Dim Ded(14) As D_Emp
    '    Dim Con(14) As C_Emp


    '    Try



    '        'Do While param_file.Peek <> -1
    '        Dim Counter As Integer
    '        Counter = 0
    '        Dim StopInput As Boolean = False
    '        Counter = 3
    '        Dim ErrorM As String = ""
    '        Do While StopInput = False
    '            Me.Refresh()
    '            'Line = param_file.Read

    '            Dim EmployeeCodeNumeric As String
    '            Dim FirstName As String
    '            Dim MiddleName As String
    '            Dim LastName As String
    '            Dim EmployeeCode As String
    '            Dim Gender As String
    '            Dim JobTitle As String
    '            Dim BirthDate As String
    '            Dim Status As String
    '            Dim EmploymentDate As String
    '            Dim AnnualLeave As String
    '            Dim MaritalStatus As String
    '            Dim SocialSecurityNo As String
    '            Dim IdentityCardNo As String
    '            Dim PassportNo As String
    '            Dim AlienNumber As String
    '            Dim IncomeTaxNo As String
    '            Dim WorkEMail As String
    '            Dim DepartmentCode As String
    '            Dim Department1 As String
    '            Dim Department2 As String
    '            Dim Department3 As String
    '            Dim Department4 As String

    '            'Dim PayrollNo As String
    '            Dim BankName As String
    '            Dim BankAccountNo As String
    '            Dim IBAN As String
    '            Dim SWIFT As String
    '            Dim TerminationDate As String

    '            Dim FullAddress As String
    '            Dim AddressLine1 As String
    '            Dim AddressLine2 As String
    '            Dim AddressLine3 As String
    '            Dim PostCode As String
    '            Dim POBox As String
    '            Dim POBoxPostCode As String
    '            Dim City As String
    '            Dim PhoneNo As String
    '            Dim MobilePhone As String
    '            Dim Email As String
    '            Dim Email2 As String
    '            Dim Email22 As String
    '            Dim JobDescriptionCode As String
    '            Dim EmployeeJobDescription As String
    '            Dim PayrollCompanyNo As String
    '            Dim TemplateGroupCode As String
    '            Dim Notes As String
    '            Dim Password As String
    '            Dim Nationality As String
    '            Dim BankBenName As String
    '            '----------------------------------------------

    '            Dim DepFull1 As String
    '            Dim DepFull2 As String
    '            Dim PosFull As String
    '            Dim SocCatFull As String
    '            Dim BankCodeFull As String


    '            Dim DepartmentCode1 As String = ""
    '            Dim DepartmentCode2 As String = ""
    '            Dim DepartmentCode3 As String = ""
    '            Dim DepartmentCode4 As String = ""
    '            Dim DepartmentCode5 As String = ""

    '            Dim Position As String
    '            Dim PositionCode1 As String

    '            Dim SiCatCode As String

    '            Dim BankCode As String

    '            Dim Salary As String

    '            Dim BanAccount As String
    '            Dim HireReason As String = ""

    '            '----------------------------------------------
    '            'FindDefaults()
    '            Dim dsTemplateGroup As DataSet
    '            Dim dsAnal1 As DataSet
    '            Dim dsAnal2 As DataSet
    '            Dim dsAnal3 As DataSet
    '            Dim dsAnal4 As DataSet
    '            Dim dsAnal5 As DataSet
    '            Dim dsUnions As DataSet
    '            Dim dsCountries As DataSet
    '            Dim dsEmpPosition As DataSet
    '            Dim dsSIcategory As DataSet
    '            Dim dsEmpCommunity As DataSet
    '            Dim dsPayUnits As DataSet
    '            Dim dsCurCode As DataSet
    '            Dim dsPayMethods As DataSet
    '            Dim dsBanks As DataSet
    '            Dim dsTaxCardtype As DataSet
    '            Dim dsProFund As DataSet
    '            Dim dsMedicalFund As DataSet
    '            Dim dsSocialInsurance As DataSet
    '            Dim dsGesi As DataSet

    '            Dim dsIndustrial As DataSet
    '            Dim dsUnemployment As DataSet
    '            Dim dsSocialCohesion As DataSet
    '            Dim dsSectorPay As DataSet
    '            Dim dsCommissionRates As DataSet
    '            Dim dsPerformanceBonus As DataSet
    '            Dim dsdutyHours As DataSet
    '            Dim dsOverLay As DataSet
    '            Dim dsFlightHours As DataSet
    '            Dim ContinueWithLoading As Boolean
    '            Dim CompanySocialInsuranceNo As String

    '            Dim TGroup As New cPrMsTemplateGroup(TemplateGroupForLoading)
    '            Dim Comp As New cAdMsCompany(TGroup.CompanyCode)
    '            Dim ALLeaveInUnits As Double

    '            Dim Units As String
    '            Dim GenAnalysis1 As String

    '            Dim EmpCodeFromExcel As String

    '            CompanySocialInsuranceNo = Comp.SIRegNo




    '            dsAnal1 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis1()
    '            dsAnal2 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis2()
    '            dsAnal3 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis3()
    '            dsAnal4 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis4()
    '            dsAnal5 = Global1.Business.AG_GetAllPrAnEmployeeAnalysis5()
    '            dsUnions = Global1.Business.AG_GetAllPrAnUnions()
    '            dsCountries = Global1.Business.AG_GetAllAdAnCountries()
    '            dsEmpPosition = Global1.Business.AG_GetAllPrAnEmployeePositions(False)
    '            dsSIcategory = Global1.Business.AG_GetAllPrAnSocialInsCategories()
    '            dsEmpCommunity = Global1.Business.AG_GetAllPrAnEmployeeCommunity()
    '            dsPayUnits = Global1.Business.AG_GetAllPrSsPayrollUnits()
    '            dsCurCode = Global1.Business.AG_GetAllAdMsCurrency()
    '            dsPayMethods = Global1.Business.AG_GetAllPrAnPaymentMethods()
    '            dsBanks = Global1.Business.AG_GetAllPrAnBanks()
    '            dsTaxCardtype = Global1.Business.GetAllActivePrAnTaxCardType()
    '            dsProFund = Global1.Business.AG_GetAllPrSsProvidentFund()
    '            dsMedicalFund = Global1.Business.AG_GetAllPrSsMedicalFund()
    '            dsSocialInsurance = Global1.Business.AG_GetAllPrSsSocialInsurance()
    '            dsIndustrial = Global1.Business.AG_GetAllPrSsIndustrial()
    '            dsUnemployment = Global1.Business.AG_GetAllPrSsUnemployment()
    '            dsSocialCohesion = Global1.Business.AG_GetAllPrSsSocialCohesion()
    '            dsSectorPay = Global1.Business.AG_GetAllPrSsSectorPay()
    '            dsCommissionRates = Global1.Business.AG_GetAllPrSsCommissionRates()
    '            dsPerformanceBonus = Global1.Business.AG_GetAllPrSsPerformanceBonus
    '            dsdutyHours = Global1.Business.AG_GetAllPrSsDutyHours
    '            dsOverLay = Global1.Business.AG_GetAllPrSsOverLay
    '            dsFlightHours = Global1.Business.AG_GetAllPrSsFlightHour
    '            dsGesi = Global1.Business.GetAllPrSsGesi

    '            EmployeeCodeNumeric = Global1.Business.GetLastEmployeeCode(Me.GLBLoadingFromExcel_TemGroup)

    '            '''''''''''''''''''''''''''''''''''''''''''''''

    '            Try

    '                ContinueWithLoading = True



    '                'If EmployeeCodeNumeric = "" Then
    '                'EmployeeCodeNumeric = 0
    '                'End If
    '                'EmployeeCodeNumeric = EmployeeCodeNumeric + 1

    '                EmpCodeFromExcel = NothingToEmpty(xlWorkSheet.Cells(Counter, 2).value)
    '                If EmpCodeFromExcel <> "" Then
    '                    EmployeeCodeNumeric = EmpCodeFromExcel
    '                End If

    '                EmployeeCode = Trim(EmployeeCodeNumeric.ToString).PadLeft(4, "0")
    '                LastName = NothingToEmpty(xlWorkSheet.Cells(Counter, 5).value)
    '                FirstName = NothingToEmpty(xlWorkSheet.Cells(Counter, 3).value)


    '                If Trim(FirstName) = "" Then
    '                    Exit Do
    '                End If
    '                ' Dim arn() As String
    '                ' arn = FirstName.Split(" ")
    '                ' FirstName = arn(1)
    '                ' LastName = arn(0)

    '                MiddleName = NothingToEmpty(xlWorkSheet.Cells(Counter, 4).value)
    '                FirstName = FirstName & " " & MiddleName

    '                Gender = NothingToEmpty(xlWorkSheet.Cells(Counter, 6).value)
    '                BirthDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 7).value)


    '                EmploymentDate = NothingToEmpty(xlWorkSheet.Cells(Counter, 8).value)
    '                AnnualLeave = NothingToEmpty(xlWorkSheet.Cells(Counter, 10).value)
    '                ALLeaveInUnits = 0

    '                If AnnualLeave <> "" Then
    '                    If IsNumeric(AnnualLeave) Then
    '                        ALLeaveInUnits = RoundMe2(AnnualLeave * TGroup.DayUnits, 2)
    '                    End If
    '                End If


    '                AddressLine1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 11).value)
    '                AddressLine2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 12).value)
    '                If AddressLine1 Is Nothing Then
    '                    AddressLine1 = ""
    '                End If
    '                If AddressLine2 Is Nothing Then
    '                    AddressLine2 = ""
    '                End If
    '                AddressLine1 = AddressLine1.Replace("!", "")
    '                AddressLine1 = AddressLine1.Replace("&", "")
    '                AddressLine1 = AddressLine1.Replace("$", "")
    '                AddressLine1 = AddressLine1.Replace("@", "")
    '                AddressLine1 = AddressLine1.Replace("/", "")
    '                AddressLine1 = AddressLine1.Replace(",", "")
    '                AddressLine1 = AddressLine1.Replace("-", "")
    '                AddressLine1 = AddressLine1.Replace(".", "")
    '                AddressLine1 = AddressLine1.Replace("'", "")

    '                AddressLine2 = AddressLine2.Replace("!", "")
    '                AddressLine2 = AddressLine2.Replace("&", "")
    '                AddressLine2 = AddressLine2.Replace("$", "")
    '                AddressLine2 = AddressLine2.Replace("@", "")
    '                AddressLine2 = AddressLine2.Replace(",", "")
    '                AddressLine2 = AddressLine2.Replace("-", "")
    '                AddressLine2 = AddressLine2.Replace(".", "")
    '                AddressLine2 = AddressLine2.Replace("'", "")




    '                City = NothingToEmpty(xlWorkSheet.Cells(Counter, 13).value)
    '                PostCode = NothingToEmpty(xlWorkSheet.Cells(Counter, 14).value)

    '                POBox = ""
    '                POBoxPostCode = ""



    '                PhoneNo = ""

    '                MobilePhone = NothingToEmpty(xlWorkSheet.Cells(Counter, 15).value)
    '                If MobilePhone Is Nothing Then
    '                    MobilePhone = ""
    '                End If

    '                Email = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)
    '                If Email Is Nothing Then
    '                    Email = ""
    '                End If
    '                Email2 = NothingToEmpty(xlWorkSheet.Cells(Counter, 17).value)
    '                If Email2 Is Nothing Then
    '                    Email2 = ""
    '                End If
    '                If Email2 <> "" Then
    '                    Email = Email2
    '                End If

    '                Email22 = NothingToEmpty(xlWorkSheet.Cells(Counter, 16).value)

    '                Password = NothingToEmpty(xlWorkSheet.Cells(Counter, 18).value)
    '                If Password Is Nothing Then
    '                    Password = ""
    '                End If

    '                JobTitle = ""

    '                Status = "ACTIVE"

    '                MaritalStatus = ""

    '                SocialSecurityNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 19).value)
    '                IdentityCardNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 20).value)
    '                PassportNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 21).value)
    '                IncomeTaxNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 22).value)
    '                If IncomeTaxNo = IdentityCardNo Then
    '                    IncomeTaxNo = ""
    '                End If
    '                AlienNumber = NothingToEmpty(xlWorkSheet.Cells(Counter, 23).value)

    '                Nationality = NothingToEmpty(xlWorkSheet.Cells(Counter, 24).value)

    '                Department1 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 38).value))
    '                Department2 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 26).value))
    '                'Desk
    '                Department3 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 36).value))
    '                'Brand
    '                Department4 = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 37).value))




    '                Dim Dep() As String
    '                Dep = Department2.Split("/")
    '                If Dep.Length = 2 Then
    '                    Department2 = Trim(Dep(0))
    '                    Department3 = Trim(Dep(1))
    '                End If

    '                DepartmentCode1 = FindDepartment1CodeFromDesc(Department1)
    '                DepartmentCode2 = FindDepartment2CodeFromDesc(Department2)
    '                DepartmentCode3 = FindDepartment3CodeFromDesc(Department3)
    '                DepartmentCode4 = FindDepartment4CodeFromDesc(Department4)
    '                If DepartmentCode1 = "" Then
    '                    If ErrorM = "" Then
    '                        ErrorM = "Department 1" & Department1 & " Not found for the following Employees " & Chr(10) & Chr(10)
    '                    End If
    '                    ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 1:   " & Department1 & Chr(10)
    '                End If

    '                DepartmentCode2 = FindDepartment2CodeFromDesc(Department2)
    '                If DepartmentCode2 = "" Then
    '                    If ErrorM = "" Then
    '                        ErrorM = "Department 2" & Department2 & " Not found for the following Employees " & Chr(10) & Chr(10)
    '                    End If
    '                    ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 2:   " & Department2 & Chr(10)
    '                End If

    '                DepartmentCode3 = FindDepartment3CodeFromDesc(Department3)
    '                If DepartmentCode3 = "" Then
    '                    If ErrorM = "" Then
    '                        ErrorM = "Department 3" & Department3 & " Not found for the following Employees " & Chr(10) & Chr(10)
    '                    End If
    '                    ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 3:   " & Department3 & Chr(10)
    '                End If

    '                DepartmentCode4 = FindDepartment4CodeFromDesc(Department4)
    '                If DepartmentCode4 = "" Then
    '                    If ErrorM = "" Then
    '                        ErrorM = "Department 4" & Department4 & " Not found for the following Employees " & Chr(10) & Chr(10)
    '                    End If
    '                    ErrorM = ErrorM & FirstName & " " & LastName & "  - Department 4:   " & Department4 & Chr(10)
    '                End If

    '                Position = NothingToEmpty(xlWorkSheet.Cells(Counter, 27).value)
    '                PositionCode1 = GetPositionCodeFromDesc(Position)
    '                If PositionCode1 = "" Then
    '                    If ErrorM = "" Then
    '                        ErrorM = "Position " & Position & " Not found for the following Employees " & Chr(10) & Chr(10)
    '                    End If
    '                    ErrorM = ErrorM & FirstName & " " & LastName & "  - Position:   " & Position & Chr(10)

    '                End If

    '                SiCatCode = Nationality 'FindSICatCodeFromNationality(Nationality)




    '                BankAccountNo = NothingToEmpty(xlWorkSheet.Cells(Counter, 39).value)
    '                IBAN = NothingToEmpty(xlWorkSheet.Cells(Counter, 30).value)
    '                SWIFT = NothingToEmpty(xlWorkSheet.Cells(Counter, 31).value)


    '                BankCode = FindBankCodeFromSWIFT(dsBanks, SWIFT, False)
    '                If BankCode = "" Then
    '                    BankCode = FindBankCodeFromSWIFT2(dsBanks, SWIFT)
    '                End If



    '                TerminationDate = ""

    '                Salary = NothingToEmpty(xlWorkSheet.Cells(Counter, 9).value)
    '                BankBenName = NothingToEmpty(xlWorkSheet.Cells(Counter, 28).value)

    '                Units = NothingToEmpty(xlWorkSheet.Cells(Counter, 34).value)
    '                GenAnalysis1 = NothingToEmpty(xlWorkSheet.Cells(Counter, 35).value)


    '                HireReason = Trim(NothingToEmpty(xlWorkSheet.Cells(Counter, 40).value))
    '                If HireReason <> "N" Or HireReason <> "T" Then
    '                    HireReason = "N"
    '                End If


    '                JobDescriptionCode = ""
    '                EmployeeJobDescription = ""

    '                PayrollCompanyNo = ""
    '                Notes = ""


    '                TemplateGroupCode = TemplateGroupForLoading

    '                '

    '                dsTemplateGroup = Global1.Business.GetAllPrMsInterfaceTemplateByTemplateGroup(TemplateGroupCode)

    '                Dim NewEmployee As Boolean = False
    '                Dim Emp As New cPrMsEmployees(EmployeeCode)

    '                If Emp.Code Is Nothing Then
    '                    NewEmployee = True
    '                End If

    '                If Emp.Code = "" Then
    '                    NewEmployee = True
    '                End If

    '                If TemplateGroupCode = "" Or EmployeeCode = "" Then
    '                    If NewEmployee And Status = "Terminated" Then
    '                        ContinueWithLoading = False
    '                    Else
    '                        MsgBox("Employee " & EmployeeCode & " " & FirstName & " " & LastName & " Does not have valid 'Payroll No' OR 'Employee Statistical code' OR 'Payroll Company No'", MsgBoxStyle.Critical)
    '                        ContinueWithLoading = False
    '                        Debug.WriteLine(EmployeeCode & " " & FirstName & " " & LastName)
    '                    End If
    '                End If


    '                If ContinueWithLoading Then

    '                    If NewEmployee Then


    '                        With Emp
    '                            .Code = EmployeeCode
    '                            If Status = "INNACTIVE" Then
    '                                .Status = "I"
    '                            Else
    '                                .Status = "A"
    '                            End If
    '                            .PayTyp_Code = "M01"
    '                            .TemGrp_Code = TemplateGroupCode
    '                            .EmpSta_Code = "A"

    '                            .LastName = LastName
    '                            .FirstName = FirstName
    '                            .FullName = LastName & " " & FirstName
    '                            If Gender = "Female" Then
    '                                .Sex = "F"
    '                                .Title = "MRS"
    '                            Else
    '                                .Sex = "M"
    '                                .Title = "MR"
    '                            End If
    '                            If BirthDate = "" Or BirthDate = "12:00:00 AM" Then
    '                                .BirthDate = Now.Date
    '                            Else
    '                                Dim Ar1() As String
    '                                Ar1 = BirthDate.Split("/")
    '                                BirthDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
    '                                .BirthDate = CDate(BirthDate)
    '                            End If
    '                            If MaritalStatus = "" Or MaritalStatus = "Single" Then
    '                                .MarSta_Code = "S"
    '                            ElseIf MaritalStatus = "Married" Then
    '                                .MarSta_Code = "M"
    '                            ElseIf MaritalStatus = "Divorce" Then
    '                                .MarSta_Code = "D"
    '                            ElseIf MaritalStatus = "Widow" Then
    '                                .MarSta_Code = "W"
    '                            End If

    '                            .Address1 = AddressLine1
    '                            .Address2 = City
    '                            .Address3 = AddressLine2

    '                            .PostCode = PostCode
    '                            .Telephone1 = PhoneNo
    '                            .Telephone2 = MobilePhone
    '                            .Email = Email
    '                            .Email2 = Email22
    '                            .SocialInsNumber = SocialSecurityNo

    '                            .ComSin_EmpSocialInsNo = CompanySocialInsuranceNo

    '                            .IdentificationCard = IdentityCardNo
    '                            .TaxID = IncomeTaxNo
    '                            .PassportNumber = PassportNo
    '                            .AlienNumber = AlienNumber

    '                            If AlienNumber <> "" Then
    '                                .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "7")
    '                            End If
    '                            If IncomeTaxNo <> "" And IncomeTaxNo <> "?" Then
    '                                .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "1")
    '                            End If
    '                            If AlienNumber = "" And (IncomeTaxNo = "" Or IncomeTaxNo = "?") Then
    '                                .TicTyp_Code = GetFirstRecordOfDataset(dsTaxCardtype, "3")
    '                            End If


    '                            If DepartmentCode1 = "" Then
    '                                .EmpAn1_Code = GetFirstRecordOfDataset(dsAnal1)
    '                            Else
    '                                .EmpAn1_Code = DepartmentCode1
    '                            End If
    '                            If DepartmentCode2 = "" Then
    '                                .EmpAn2_Code = GetFirstRecordOfDataset(dsAnal2)
    '                            Else
    '                                .EmpAn2_Code = DepartmentCode2
    '                            End If
    '                            If DepartmentCode3 = "" Then
    '                                .EmpAn3_Code = GetFirstRecordOfDataset(dsAnal3)
    '                            Else
    '                                .EmpAn3_Code = DepartmentCode3
    '                            End If
    '                            If DepartmentCode4 = "" Then
    '                                .EmpAn4_Code = GetFirstRecordOfDataset(dsAnal4)
    '                            Else
    '                                .EmpAn4_Code = DepartmentCode4
    '                            End If
    '                            If DepartmentCode5 = "" Then
    '                                .EmpAn5_Code = GetFirstRecordOfDataset(dsAnal5)
    '                            Else
    '                                .EmpAn5_Code = DepartmentCode5
    '                            End If


    '                            .Uni_Code = GetFirstRecordOfDataset(dsUnions)
    '                            .Cou_Code = GetFirstRecordOfDataset(dsCountries)
    '                            '.EmpPos_Code = GetFirstRecordOfDataset(dsEmpPosition, Position)

    '                            .EmpPos_Code = PositionCode1


    '                            .Sic_Code = GetFirstRecordOfDataset(dsSIcategory)

    '                            .EmpCmm_Code = FindSICatCodeFromNationality(Nationality)
    '                            '.EmpCmm_Code = GetFirstRecordOfDataset(dsEmpCommunity, SiCatCode)

    '                            .PayUni_Code = GetFirstRecordOfDataset(dsPayUnits)
    '                            If IsNumeric(Units) Then
    '                                .PeriodUnits = Units
    '                            Else
    '                                .PeriodUnits = 0
    '                            End If

    '                            .AnnualUnits = 0
    '                            .Cur_Code = GetFirstRecordOfDataset(dsCurCode)
    '                            .PmtMth_Code = GetFirstRecordOfDataset(dsPayMethods, "3")

    '                            .Bnk_Code = BankCode 'FindBankCodeFromSWIFT(dsBanks, SWIFT)

    '                            .BankAccount = BankAccountNo
    '                            .Bnk_CodeCo = Me.GLBLoadingFromExcel_CompanyBankCode 'GetFirstRecordOfDataset(dsBanks)
    '                            .BankAccountCo = Me.GLBLoadingFromExcel_CompanyIBAN

    '                            If EmploymentDate = "" Or EmploymentDate = "12:00:00 AM" Then
    '                                .StartDate = Now.Date
    '                            Else
    '                                Dim Ar1() As String
    '                                Ar1 = EmploymentDate.Split("/")
    '                                EmploymentDate = Ar1(2) & "/" & Ar1(0) & "/" & Ar1(1)
    '                                .StartDate = CDate(EmploymentDate)

    '                            End If
    '                            If TerminationDate <> "" Then
    '                                Dim S As String
    '                                Dim D As Date
    '                                D = Cdate1(TerminationDate)
    '                                S = Format(D, "yyyy/MM/dd")

    '                                .TerminateDate = S
    '                            Else
    '                                .TerminateDate = ""
    '                            End If

    '                            .OtherIncome1 = CDbl(0)
    '                            .OtherIncome2 = CDbl(0)
    '                            .OtherIncome3 = CDbl(0)
    '                            .PreviousEarnings = CDbl(0)
    '                            .Emp_PrevSIDeduct = CDbl(0)
    '                            .Emp_PrevSIContribute = CDbl(0)
    '                            .Emp_PrevITDeduct = CDbl(0)
    '                            .Emp_PrevPFDeduct = CDbl(0)

    '                            .ProFnd_Code = GetFirstRecordOfDataset(dsProFund)
    '                            .MedFnd_Code = GetFirstRecordOfDataset(dsMedicalFund)
    '                            .SocInc_Code = GetFirstRecordOfDataset(dsSocialInsurance, GLBLoadingFromExcel_SIRateCode)
    '                            .GESICode = GetFirstRecordOfDataset(dsGesi)

    '                            .Ind_Code = GetFirstRecordOfDataset(dsIndustrial)
    '                            .Une_Code = GetFirstRecordOfDataset(dsUnemployment)
    '                            .SocCoh_Code = GetFirstRecordOfDataset(dsSocialCohesion)
    '                            .InterfaceTemCode = TemplateGroupCode
    '                            .InterfacePFCode = GetFirstRecordOfDataset(dsTemplateGroup)
    '                            .InterfaceMFCode = GetFirstRecordOfDataset(dsTemplateGroup)

    '                            .DrivingLicense = ""
    '                            .PensionNo = ""
    '                            .MyPayslipReport = Me.GLBLoadingFromExcel_PayslipReport
    '                            .IBAN = IBAN

    '                            .PreviousLifeIns = CDbl(0)
    '                            .PreviousDis = CDbl(0)
    '                            .PreviousST = CDbl(0)
    '                            .OtherIncome4 = CDbl(0)

    '                            .SectorPay = GetFirstRecordOfDataset(dsSectorPay)
    '                            .CommissionRate = GetFirstRecordOfDataset(dsCommissionRates)
    '                            .PerformanceBonus = GetFirstRecordOfDataset(dsPerformanceBonus)
    '                            .DutyHours = GetFirstRecordOfDataset(dsdutyHours)
    '                            .OverLay = GetFirstRecordOfDataset(dsOverLay)
    '                            .FlightHours = GetFirstRecordOfDataset(dsFlightHours)

    '                            .FullPassName = ""
    '                            .Traveldocs = ""

    '                            .FirstEmployment = "0"
    '                            .IsSI = 0
    '                            .Password = Password
    '                            .Splitemployement = "0"
    '                            .BankBenName = BankBenName
    '                            .NewEmployee = "1"



    '                            .Emp_GLAnal1 = ""
    '                            .Emp_GLAnal2 = ""
    '                            .Emp_GLAnal3 = ""
    '                            .Emp_GLAnal4 = ""

    '                            .PensionType = "0"

    '                            .CreationDate = Now.Date
    '                            .CreatedBy = Global1.GLBUserId
    '                            .AmendDate = Now.Date
    '                            .AmendBy = Global1.GLBUserId
    '                            .Notes = Notes
    '                            .AnalGen1 = GenAnalysis1
    '                            .HireReason = HireReason
    '                            .TermReason = ""

    '                            If Not .Save(False) Then
    '                                Throw Exx
    '                            End If

    '                            Dim SalVal As Double
    '                            Salary = Replace(Salary, "$", "")
    '                            Salary = Replace(Salary, "€", "")
    '                            Salary = Replace(Salary, """", "")
    '                            Salary = Trim(Salary)
    '                            SalVal = CDbl(Salary)


    '                            Dim EmpSal As New cPrTxEmployeeSalary
    '                            With EmpSal

    '                                .Id = 0
    '                                .Emp_Code = EmployeeCode
    '                                .Date1 = Now.Date
    '                                .SalaryValue = CDbl(SalVal)
    '                                .Basic = CDbl(0)
    '                                .EffPayDate = CDate(EmploymentDate)
    '                                .Cola = CDbl(0)
    '                                .EffArrearsDate = CDate(EmploymentDate)
    '                                .Usr_Id = Global1.GLBUserId
    '                                .myRate = CDbl(0)
    '                                .IsCola = "N"
    '                                .EmpSal_Dif = CDbl(0)

    '                                If Not .Save() Then
    '                                    Throw Exx
    '                                End If


    '                            End With


    '                            Dim EmpAL As New cPrTxEmployeeLeave
    '                            With EmpAL

    '                                .Id = 0
    '                                .EmpCode = EmployeeCode
    '                                .Status = "Approved"
    '                                .Type = "1"
    '                                .ReqDate = EmploymentDate
    '                                .ProcDate = EmploymentDate
    '                                .FromDate = EmploymentDate
    '                                .ToDate = EmploymentDate
    '                                .ProcBy = Global1.GLBUserId
    '                                .Units = ALLeaveInUnits
    '                                .Action = AN_IncreaseCODE

    '                                If Not .Save() Then
    '                                    Throw Exx
    '                                End If


    '                            End With



    '                            '''
    '                            Dim k As Integer
    '                            Dim DsErn As DataSet
    '                            DsErn = Global1.Business.GetAllPrMsTemplateEarnings(TemplateGroupCode)
    '                            If CheckDataSet(DsErn) Then
    '                                For k = 0 To DsErn.Tables(0).Rows.Count - 1
    '                                    Dim E1 As New cPrMsTemplateEarnings(DsErn.Tables(0).Rows(k))
    '                                    Dim EmpErn As New cPrMsEmployeeEarnings(.Code, E1.ErnCodCode)
    '                                    EmpErn.EmpCode = .Code
    '                                    EmpErn.ErnCode = E1.ErnCodCode
    '                                    EmpErn.MyValue = "0.00"
    '                                    EmpErn.TemGrpCode = .TemGrp_Code
    '                                    If Not EmpErn.Save Then
    '                                        Throw Exx
    '                                    End If
    '                                Next
    '                            End If
    '                            'Deductions
    '                            Dim DsDed As DataSet
    '                            DsDed = Global1.Business.GetAllPrMsTemplateDeductions(TemplateGroupCode)
    '                            If CheckDataSet(DsDed) Then
    '                                For k = 0 To DsDed.Tables(0).Rows.Count - 1
    '                                    Dim D As New cPrMsTemplateDeductions(DsDed.Tables(0).Rows(k))
    '                                    Dim EmpDed As New cPrMsEmployeeDeductions(.Code, D.DedCodCode)
    '                                    EmpDed.EmpCode = .Code
    '                                    EmpDed.DedCode = D.DedCodCode
    '                                    EmpDed.MyValue = "0.00"
    '                                    EmpDed.TemGrpCode = .TemGrp_Code
    '                                    If Not EmpDed.Save Then
    '                                        Throw Exx
    '                                    End If
    '                                Next
    '                            End If
    '                            'Contributions
    '                            Dim DsCon As DataSet
    '                            DsCon = Global1.Business.GetAllPrMsTemplateContributions(TemplateGroupCode)
    '                            If CheckDataSet(DsCon) Then
    '                                For k = 0 To DsCon.Tables(0).Rows.Count - 1
    '                                    Dim C As New cPrMsTemplateContributions(DsCon.Tables(0).Rows(k))
    '                                    Dim EmpCon As New cPrMsEmployeeContributions(.Code, C.ConCodCode)
    '                                    EmpCon.EmpCode = .Code
    '                                    EmpCon.ConCode = C.ConCodCode
    '                                    EmpCon.MyValue = "0.00"
    '                                    EmpCon.TemGrpCode = .TemGrp_Code
    '                                    If Not C.Save Then
    '                                        Throw Exx
    '                                    End If
    '                                Next
    '                            End If

    '                        End With



    '                    End If

    '                    '''''''''

    '                End If

    '            Catch ex As Exception
    '                Global1.Business.Rollback()
    '                Utils.ShowException(ex)
    '                MsgBox("Error loading employee with Code " & EmployeeCode, MsgBoxStyle.Critical)
    '            End Try

    '            Counter = Counter + 1
    '        Loop



    '        Global1.Business.CommitTransaction()
    '        MsgBox("Loading from Excel has finish", MsgBoxStyle.Information)
    '        'Update / Deletes additions, you name it all use the same technology. 
    '        If ErrorM <> "" Then
    '            MsgBox(ErrorM)
    '        End If
    '    Catch ex As Exception

    '        MessageBox.Show(ex.ToString)
    '    End Try
    '    xlWorkBook.Close()
    '    xlApp.Quit()
    '    releaseObject(xlApp)
    '    releaseObject(xlWorkBook)
    '    releaseObject(xlWorkSheet)
    'End Sub

End Class